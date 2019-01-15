// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// MovssStore
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class MovssStore : X64Instruction
	{
		public override int ID { get { return 456; } }

		internal MovssStore()
			: base(0, 3)
		{
		}

		public override bool IsMemoryWrite { get { return true; } }

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 0);
			System.Diagnostics.Debug.Assert(node.OperandCount == 3);

			if ((node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 5) && node.Operand2.IsConstantZero && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b01);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(0b101);
				emitter.OpcodeEncoder.AppendByte(0x00);
				return;
			}

			if ((node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 5) && node.Operand2.IsCPURegister && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit((node.Operand2.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b01);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(0b100);
				emitter.OpcodeEncoder.Append2Bits(0b00);
				emitter.OpcodeEncoder.Append3Bits(node.Operand2.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(0b101);
				emitter.OpcodeEncoder.AppendByte(0x00);
				return;
			}

			if ((node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 4) && node.Operand2.IsConstantZero && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b00);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(0b100);
				emitter.OpcodeEncoder.Append2Bits(0b00);
				emitter.OpcodeEncoder.Append3Bits(0b100);
				emitter.OpcodeEncoder.Append3Bits(0b100);
				return;
			}

			if ((node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 4) && (node.Operand2.IsConstant && node.Operand2.ConstantSignedInteger >= -128 && node.Operand2.ConstantSignedInteger <= 127) && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b01);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(0b100);
				emitter.OpcodeEncoder.Append2Bits(0b00);
				emitter.OpcodeEncoder.Append3Bits(0b100);
				emitter.OpcodeEncoder.Append3Bits(0b100);
				emitter.OpcodeEncoder.Append8BitImmediate(node.Operand2);
				return;
			}

			if ((node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 4) && node.Operand2.IsConstant && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b10);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(0b100);
				emitter.OpcodeEncoder.Append8BitImmediate(node.Operand2);
				return;
			}

			if (node.Operand1.IsCPURegister && node.Operand2.IsCPURegister && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit((node.Operand2.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b00);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(0b100);
				emitter.OpcodeEncoder.Append2Bits(0b00);
				emitter.OpcodeEncoder.Append3Bits(node.Operand2.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
				return;
			}

			if (node.Operand1.IsCPURegister && node.Operand2.IsConstantZero && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand1.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b00);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
				return;
			}

			if (node.Operand1.IsCPURegister && (node.Operand2.IsConstant && node.Operand2.ConstantSignedInteger >= -128 && node.Operand2.ConstantSignedInteger <= 127) && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand1.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b01);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
				emitter.OpcodeEncoder.Append8BitImmediate(node.Operand2);
				return;
			}

			if (node.Operand1.IsCPURegister && node.Operand2.IsConstant && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand1.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b10);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
				emitter.OpcodeEncoder.Append32BitImmediate(node.Operand2);
				return;
			}

			if (node.Operand1.IsConstant && node.Operand2.IsConstantZero && node.Operand3.IsCPURegister)
			{
				emitter.OpcodeEncoder.AppendByte(0xF3);
				emitter.OpcodeEncoder.AppendByte(0x0F);
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand3.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendByte(0x11);
				emitter.OpcodeEncoder.Append2Bits(0b00);
				emitter.OpcodeEncoder.Append3Bits(node.Operand3.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(0b101);
				emitter.OpcodeEncoder.Append32BitImmediate(node.Operand1);
				return;
			}

			throw new Compiler.Common.Exceptions.CompilerException("Invalid Opcode");
		}
	}
}