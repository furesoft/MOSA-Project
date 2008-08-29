﻿using System;
using System.Collections.Generic;
using System.Text;
using Mosa.Runtime.CompilerFramework.IR;
using Mosa.Runtime.Vm;
using System.Diagnostics;

namespace Mosa.Runtime.CompilerFramework
{
    /// <summary>
    /// A minimalistic register assignment allocator.
    /// </summary>
    /// <remarks>
    /// This is not a real register allocator. It ensures that operations with register
    /// constraints are executed properly, but does not assign variables to fixed registers.
    /// </remarks>
    public class LinearRegisterAllocator : IMethodCompilerStage
    {
        #region Types

        private class LiveRange
        {
            public LiveRange(BasicBlock block, Operand op, int start, int end)
            {
                this.Block = block;
                this.Op = op;
                this.Reg = null;
                this.Start = start;
                this.End = end;
            }

            public BasicBlock Block;
            public Operand Op;
            public Register Reg;
            public int Start;
            public int End;
        }

        #endregion // Types

        #region Data members

        /// <summary>
        /// Holds the architecture to allocate statements with.
        /// </summary>
        private IArchitecture _architecture;

        /// <summary>
        /// List of live ranges found in the method.
        /// </summary>
        private List<LiveRange> _liveRanges = new List<LiveRange>();

        /// <summary>
        /// Holds the currently live registers and their backing stores.
        /// </summary>
        private List<Register> _registers;

        #endregion // Data members

        #region Construction

        /// <summary>
        /// Initializes a new instance of <see cref="PseudoRegisterAllocator"/>.
        /// </summary>
        public LinearRegisterAllocator()
        {
        }

        #endregion // Construction

        #region IMethodCompilerStage Members

        public string Name
        {
            get { return @"PseudoRegisterAllocator"; }
        }

        public void Run(MethodCompilerBase compiler)
        {
            // Retrieve the architecture
            _architecture = compiler.Architecture;

            // Retrieve the basic block provider
            IBasicBlockProvider blockProvider = (IBasicBlockProvider)compiler.GetPreviousStage(typeof(IBasicBlockProvider));
            if (null == blockProvider)
                throw new InvalidOperationException(@"Instruction stream must have been split to basic blocks.");

            // 1st Pass: Number all instructions in the order of appearance
            NumberInstructions(blockProvider);

            // 2nd Pass: Capture all operands and their live ranges
            CaptureLiveRanges(compiler, blockProvider);

            // 3rd Pass: Assign registers
            AssignRegisters();
        }

        private void AssignRegisters()
        {
            List<LiveRange> active = new List<LiveRange>();
            _registers = FillRegisterList();

            for (int i = 0; i < _liveRanges.Count; i++)
            {
                LiveRange lr = _liveRanges[i];
                ExpireOldRanges(lr.Start, active);

                Register reg = AllocateRegister(lr.Op);
                if (null == reg)
                {
                    reg = SpillRegister(active, lr);
                }

                Debug.Assert(null != reg, @"Failed to allocate a register type.");
                RegisterOperand rop = new RegisterOperand(lr.Op.Type, reg);
                ReplaceOperand(lr, rop); ;
                lr.Reg = reg;

                int insIdx = active.FindIndex(delegate(LiveRange match)
                {
                    return ((lr.End - match.End) > 0);
                });
                active.Insert(insIdx+1, lr);
            }
        }

        private void ReplaceOperand(LiveRange lr, RegisterOperand replacement)
        {
            int opIdx;

            // Iterate all definition sites first
            foreach (Instruction def in lr.Op.Definitions.ToArray())
            {
                if (def.Offset == lr.Start)
                {
                    opIdx = 0;
                    foreach (Operand r in def.Results)
                    {
                        // Is this the operand?
                        if (true == object.ReferenceEquals(r, lr.Op))
                            def.SetResult(opIdx, replacement);

                        opIdx++;
                    }

                    break;
                }
            }

            // Iterate all use sites
            foreach (Instruction instr in lr.Op.Uses.ToArray())
            {
                if (instr.Offset <= lr.Start)
                {
                    // A use on instr.Offset == lr.Start is one from a previous definition!!
                }
                else if (instr.Offset <= lr.End)
                {
                    opIdx = 0;
                    foreach (Operand r in instr.Operands)
                    {
                        // Is this the operand?
                        if (true == object.ReferenceEquals(r, lr.Op))
                            instr.SetOperand(opIdx, replacement);

                        opIdx++;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private Register SpillRegister(List<LiveRange> active, LiveRange current)
        {
            foreach (LiveRange lr in active)
            {
                // Does it make sense to spill this register?
                if (true == lr.Reg.IsValidSigType(current.Op.Type))
                {
                    // Yes, spill it back to its operand
                    RegisterOperand rop = new RegisterOperand(lr.Op.Type, lr.Reg);
                    MoveInstruction mi = CreateMoveInstruction(lr.Op, rop);
                    current.Block.Instructions.Insert(current.Start++, mi);

                    // Load the new value
                    mi = CreateMoveInstruction(rop, current.Op);
                    current.Block.Instructions.Insert(current.Start++, mi);

                    // Remove this live range from the active list
                    active.Remove(lr);

                    lr.Start = PickNextUse(lr.Op, current.Start, lr.End);
                    if (-1 != lr.Start)
                    {
                        ReinsertSpilledRange(lr);
                    }

                    return lr.Reg;
                }
            }

            throw new InvalidOperationException(@"Failed to spill a register.");
        }

        private Register AllocateRegister(Operand operand)
        {
            foreach (Register r in _registers)
            {
                if (true == r.IsValidSigType(operand.Type))
                {
                    _registers.Remove(r);
                    return r;
                }
            }

            return null;
        }

        private void ExpireOldRanges(int position, List<LiveRange> active)
        {
            for (int i = 0; i < active.Count; i++)
            {
                LiveRange lr = active[i];
                if (lr.End > position)
                    break;

                _registers.Add(lr.Reg);
                active.RemoveAt(i);
                i--;
            }
        }



        private void ReinsertSpilledRange(LiveRange lr)
        {
            int index = 0;
            foreach (LiveRange item in _liveRanges)
            {
                if (item.Start > lr.Start)
                {
                    _liveRanges.Insert(index, lr);
                    break;
                }

                index++;
            }
        }

        private List<Register> FillRegisterList()
        {
            return new List<Register>(_architecture.RegisterSet);
        }

        private void CaptureLiveRanges(MethodCompilerBase compiler, IBasicBlockProvider blockProvider)
        {
            // Start live ranges for the parameters of the method
            IInstructionDecoder decoder = (IInstructionDecoder)compiler.GetPreviousStage(typeof(IInstructionDecoder));
            int paramIdx = 0;
            foreach (RuntimeParameter rp in compiler.Method.Parameters)
            {
                Operand paramOp = decoder.GetParameterOperand(paramIdx++);
                if (0 != paramOp.Uses.Count)
                {
                    Sort(paramOp.Definitions);
                    Sort(paramOp.Uses);

                    int lastUse = PickLastUseForDef(paramOp, 0);
                    if (-1 != lastUse)
                    {
                        LiveRange lr = new LiveRange(blockProvider[0], paramOp, 0, lastUse);
                        _liveRanges.Add(lr);
                    }
                }
            }

            // Now process all additional definitions
            foreach (BasicBlock block in blockProvider)
            {
                foreach (Instruction instruction in block.Instructions)
                {
                    foreach (Operand op in instruction.Results)
                    {
                        if (0 != op.Uses.Count)
                        {
                            Sort(op.Uses);
                            Sort(op.Definitions);

                            int lastUse = PickLastUseForDef(op, instruction.Offset);
                            if (instruction.Offset < lastUse)
                            {
                                LiveRange lr = new LiveRange(block, op, instruction.Offset, lastUse);
                                _liveRanges.Add(lr);
                            }
                        }
                    }
                }
            }
        }

        private int PickLastUseForDef(Operand op, int defLine)
        {
            int result = -1;

            // Find the next definition after defLine
            int ubound = Int32.MaxValue;
            op.Definitions.Find(delegate(Instruction i)
            {
                if (i.Offset > defLine)
                {
                    ubound = i.Offset;
                    return true;
                }

                return false;
            });

            // Now find the last use between defLine and ubound
            op.Uses.ForEach(delegate(Instruction i)
            {
                if (i.Offset > defLine && i.Offset < ubound)
                {
                    result = i.Offset;
                }
            });

            return result;
        }

        private int PickNextUse(Operand op, int line, int end)
        {
            int result = -1;
            
            // Now find the last use between defLine and ubound
            op.Uses.ForEach(delegate(Instruction i)
            {
                if (i.Offset > line && i.Offset < end)
                {
                    result = i.Offset;
                }
            });

            return result;
        }

        private void Sort(List<Instruction> list)
        {
            list.Sort(delegate(Instruction a, Instruction b)
            {
                return a.Offset - b.Offset;
            });
        }

        #endregion // IMethodCompilerStage Members

        #region Internals

        /// <summary>
        /// Assigns every instruction an increasing offset value.
        /// </summary>
        /// <param name="blockProvider">The block provider.</param>
        private void NumberInstructions(IBasicBlockProvider blockProvider)
        {
            int offset = 0;

            foreach (BasicBlock block in blockProvider)
            {
                foreach (Instruction instruction in block.Instructions)
                {
                    instruction.Offset = offset++;
                }
            }
        }


        /// <summary>
        /// Creates a move instruction that moves the value of the operand to the specified register.
        /// </summary>
        /// <param name="register">The destination register.</param>
        /// <param name="op">The operand to move.</param>
        /// <returns>The move instruction.</returns>
        private MoveInstruction CreateMoveInstruction(Operand dest, Operand src)
        {
            return (MoveInstruction)_architecture.CreateInstruction(typeof(MoveInstruction), dest, src);
        }

        #endregion // Internals
    }
}
