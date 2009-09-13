﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Mosa.Runtime.Metadata;
using Mosa.Runtime.Metadata.Signatures;

namespace Mosa.Runtime.CompilerFramework.CIL
{
	/// <summary>
	/// 
	/// </summary>
	public class ReturnInstruction : CILInstruction, IBranchInstruction
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="ReturnInstruction"/> class.
		/// </summary>
		/// <param name="opcode">The opcode.</param>
		public ReturnInstruction(OpCode opcode)
			: base(opcode)
		{
		}

		#endregion // Construction

		#region Properties

		/// <summary>
		/// Determines flow behavior of this instruction.
		/// </summary>
		/// <value></value>
		/// <remarks>
		/// Knowledge of control flow is required for correct basic block
		/// building. Any instruction that alters the control flow must override
		/// this property and correctly identify its control flow modifications.
		/// </remarks>
		public override FlowControl FlowControl
		{
			get { return FlowControl.Return; }
		}

		#endregion // Properties

		#region ICILInstruction Overrides

		/// <summary>
		/// Decodes the specified instruction.
		/// </summary>
		/// <param name="instruction">The instruction.</param>
		/// <param name="decoder">The instruction decoder, which holds the code stream.</param>
		public override void Decode(ref InstructionData instruction, IInstructionDecoder decoder)
		{
			// Decode base classes first
			base.Decode(ref instruction, decoder);

			if (OpCode.Ret != _opcode)
				throw new ArgumentException(@"Invalid opcode.", @"code");

			MethodSignature sig = decoder.Method.Signature;
			if (sig.ReturnType.Type == CilElementType.Void) {
				//SetOperandCount(0, 0);   // ?
				return;
			}

		}

		#endregion // ICILInstruction Overrides

		/// <summary>
		/// Determines if the branch is conditional.
		/// </summary>
		/// <value></value>
		public bool IsConditional { get { return false; } }

	}
}
