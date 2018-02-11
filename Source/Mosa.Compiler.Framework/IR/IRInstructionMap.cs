﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using System.Collections.Generic;

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	/// IR Instruction Map
	/// </summary>
	public static class IRInstructionMap
	{
		public static readonly Dictionary<string,BaseInstruction> Map = new Dictionary<string, BaseInstruction>() {
			{ "AddFloatR4", IRInstruction.AddFloatR4 },
			{ "AddFloatR8", IRInstruction.AddFloatR8 },
			{ "AddressOf", IRInstruction.AddressOf },
			{ "AddSigned32", IRInstruction.AddSigned32 },
			{ "AddSigned64", IRInstruction.AddSigned64 },
			{ "AddUnsigned32", IRInstruction.AddUnsigned32 },
			{ "AddUnsigned64", IRInstruction.AddUnsigned64 },
			{ "ArithmeticShiftRight32", IRInstruction.ArithmeticShiftRight32 },
			{ "ArithmeticShiftRight64", IRInstruction.ArithmeticShiftRight64 },
			{ "BlockEnd", IRInstruction.BlockEnd },
			{ "BlockStart", IRInstruction.BlockStart },
			{ "Break", IRInstruction.Break },
			{ "Call", IRInstruction.Call },
			{ "CallDirect", IRInstruction.CallDirect },
			{ "CallDynamic", IRInstruction.CallDynamic },
			{ "CallInterface", IRInstruction.CallInterface },
			{ "CallStatic", IRInstruction.CallStatic },
			{ "CallVirtual", IRInstruction.CallVirtual },
			{ "CompareFloatR4", IRInstruction.CompareFloatR4 },
			{ "CompareFloatR8", IRInstruction.CompareFloatR8 },
			{ "CompareInteger32x32", IRInstruction.CompareInteger32x32 },
			{ "CompareInteger64x32", IRInstruction.CompareInteger64x32 },
			{ "CompareInteger64x64", IRInstruction.CompareInteger64x64 },
			{ "CompareIntegerBranch", IRInstruction.CompareIntegerBranch },
			{ "ConversionFloatR4ToFloatR8", IRInstruction.ConversionFloatR4ToFloatR8 },
			{ "ConversionFloatR4ToInteger", IRInstruction.ConversionFloatR4ToInteger },
			{ "ConversionFloatR8ToFloatR4", IRInstruction.ConversionFloatR8ToFloatR4 },
			{ "ConversionFloatR8ToInteger", IRInstruction.ConversionFloatR8ToInteger },
			{ "ConversionIntegerToFloatR4", IRInstruction.ConversionIntegerToFloatR4 },
			{ "ConversionIntegerToFloatR8", IRInstruction.ConversionIntegerToFloatR8 },
			{ "DivFloatR4", IRInstruction.DivFloatR4 },
			{ "DivFloatR8", IRInstruction.DivFloatR8 },
			{ "DivSigned32", IRInstruction.DivSigned32 },
			{ "DivSigned64", IRInstruction.DivSigned64 },
			{ "DivUnsigned32", IRInstruction.DivUnsigned32 },
			{ "DivUnsigned64", IRInstruction.DivUnsigned64 },
			{ "Epilogue", IRInstruction.Epilogue },
			{ "ExceptionEnd", IRInstruction.ExceptionEnd },
			{ "ExceptionStart", IRInstruction.ExceptionStart },
			{ "FilterEnd", IRInstruction.FilterEnd },
			{ "FilterStart", IRInstruction.FilterStart },
			{ "FinallyEnd", IRInstruction.FinallyEnd },
			{ "FinallyStart", IRInstruction.FinallyStart },
			{ "Flow", IRInstruction.Flow },
			{ "Gen", IRInstruction.Gen },
			{ "GotoLeaveTarget", IRInstruction.GotoLeaveTarget },
			{ "IntrinsicMethodCall", IRInstruction.IntrinsicMethodCall },
			{ "IsInstanceOfType", IRInstruction.IsInstanceOfType },
			{ "IsInstanceOfInterfaceType", IRInstruction.IsInstanceOfInterfaceType },
			{ "Jmp", IRInstruction.Jmp },
			{ "Kill", IRInstruction.Kill },
			{ "KillAll", IRInstruction.KillAll },
			{ "KillAllExcept", IRInstruction.KillAllExcept },
			{ "LoadConstant32", IRInstruction.LoadConstant32 },
			{ "LoadConstant64", IRInstruction.LoadConstant64 },
			{ "LoadCompound", IRInstruction.LoadCompound },
			{ "LoadFloatR4", IRInstruction.LoadFloatR4 },
			{ "LoadFloatR8", IRInstruction.LoadFloatR8 },
			{ "LoadInteger", IRInstruction.LoadInteger },
			{ "LoadSignExtended", IRInstruction.LoadSignExtended },
			{ "LoadZeroExtended", IRInstruction.LoadZeroExtended },
			{ "LoadInteger32", IRInstruction.LoadInteger32 },
			{ "LoadInteger64", IRInstruction.LoadInteger64 },
			{ "LoadSignExtended8x32", IRInstruction.LoadSignExtended8x32 },
			{ "LoadSignExtended8x64", IRInstruction.LoadSignExtended8x64 },
			{ "LoadSignExtended16x64", IRInstruction.LoadSignExtended16x64 },
			{ "LoadSignExtended32x64", IRInstruction.LoadSignExtended32x64 },
			{ "LoadZeroExtended8x32", IRInstruction.LoadZeroExtended8x32 },
			{ "LoadZeroExtended16x32", IRInstruction.LoadZeroExtended16x32 },
			{ "LoadZeroExtended8x64", IRInstruction.LoadZeroExtended8x64 },
			{ "LoadZeroExtended16x64", IRInstruction.LoadZeroExtended16x64 },
			{ "LoadZeroExtended32x64", IRInstruction.LoadZeroExtended32x64 },
			{ "LoadParameterCompound", IRInstruction.LoadParameterCompound },
			{ "LoadParameterFloatR4", IRInstruction.LoadParameterFloatR4 },
			{ "LoadParameterFloatR8", IRInstruction.LoadParameterFloatR8 },
			{ "LoadParameterInteger32", IRInstruction.LoadParameterInteger32 },
			{ "LoadParameterInteger64", IRInstruction.LoadParameterInteger64 },
			{ "LoadParameterSignExtended8x32", IRInstruction.LoadParameterSignExtended8x32 },
			{ "LoadParameterSignExtended16x32", IRInstruction.LoadParameterSignExtended16x32 },
			{ "LoadParameterSignExtended8x64", IRInstruction.LoadParameterSignExtended8x64 },
			{ "LoadParameterSignExtended16x64", IRInstruction.LoadParameterSignExtended16x64 },
			{ "LoadParameterSignExtended32x64", IRInstruction.LoadParameterSignExtended32x64 },
			{ "LoadParameterZeroExtended8x32", IRInstruction.LoadParameterZeroExtended8x32 },
			{ "LoadParameterZeroExtended16x32", IRInstruction.LoadParameterZeroExtended16x32 },
			{ "LoadParameterZeroExtended8x64", IRInstruction.LoadParameterZeroExtended8x64 },
			{ "LoadParameterZeroExtended16x64", IRInstruction.LoadParameterZeroExtended16x64 },
			{ "LoadParameterZeroExtended32x64", IRInstruction.LoadParameterZeroExtended32x64 },
			{ "LogicalAnd32", IRInstruction.LogicalAnd32 },
			{ "LogicalAnd64", IRInstruction.LogicalAnd64 },
			{ "LogicalNot32", IRInstruction.LogicalNot32 },
			{ "LogicalNot64", IRInstruction.LogicalNot64 },
			{ "LogicalOr32", IRInstruction.LogicalOr32 },
			{ "LogicalOr64", IRInstruction.LogicalOr64 },
			{ "LogicalXor32", IRInstruction.LogicalXor32 },
			{ "LogicalXor64", IRInstruction.LogicalXor64 },
			{ "MemorySet", IRInstruction.MemorySet },
			{ "MoveCompound", IRInstruction.MoveCompound },
			{ "MoveFloatR4", IRInstruction.MoveFloatR4 },
			{ "MoveFloatR8", IRInstruction.MoveFloatR8 },
			{ "MoveInteger", IRInstruction.MoveInteger },
			{ "MoveSignExtended", IRInstruction.MoveSignExtended },
			{ "MoveZeroExtended", IRInstruction.MoveZeroExtended },
			{ "MoveInteger32", IRInstruction.MoveInteger32 },
			{ "MoveInteger64", IRInstruction.MoveInteger64 },
			{ "MulFloatR4", IRInstruction.MulFloatR4 },
			{ "MulFloatR8", IRInstruction.MulFloatR8 },
			{ "MulSigned32", IRInstruction.MulSigned32 },
			{ "MulSigned64", IRInstruction.MulSigned64 },
			{ "MulUnsigned64", IRInstruction.MulUnsigned64 },
			{ "MulUnsigned32", IRInstruction.MulUnsigned32 },
			{ "NewArray", IRInstruction.NewArray },
			{ "NewObject", IRInstruction.NewObject },
			{ "NewString", IRInstruction.NewString },
			{ "Nop", IRInstruction.Nop },
			{ "Phi", IRInstruction.Phi },
			{ "Prologue", IRInstruction.Prologue },
			{ "RemFloatR4", IRInstruction.RemFloatR4 },
			{ "RemFloatR8", IRInstruction.RemFloatR8 },
			{ "RemSigned32", IRInstruction.RemSigned32 },
			{ "RemSigned64", IRInstruction.RemSigned64 },
			{ "RemUnsigned32", IRInstruction.RemUnsigned32 },
			{ "RemUnsigned64", IRInstruction.RemUnsigned64 },
			{ "SetReturnR4", IRInstruction.SetReturnR4 },
			{ "SetReturnR8", IRInstruction.SetReturnR8 },
			{ "SetReturn32", IRInstruction.SetReturn32 },
			{ "SetReturn64", IRInstruction.SetReturn64 },
			{ "SetReturnCompound", IRInstruction.SetReturnCompound },
			{ "SetLeaveTarget", IRInstruction.SetLeaveTarget },
			{ "ShiftLeft32", IRInstruction.ShiftLeft32 },
			{ "ShiftLeft64", IRInstruction.ShiftLeft64 },
			{ "ShiftRight32", IRInstruction.ShiftRight32 },
			{ "ShiftRight64", IRInstruction.ShiftRight64 },
			{ "StableObjectTracking", IRInstruction.StableObjectTracking },
			{ "StoreCompound", IRInstruction.StoreCompound },
			{ "StoreFloatR4", IRInstruction.StoreFloatR4 },
			{ "StoreFloatR8", IRInstruction.StoreFloatR8 },
			{ "StoreInteger8", IRInstruction.StoreInteger8 },
			{ "StoreInteger16", IRInstruction.StoreInteger16 },
			{ "StoreInteger32", IRInstruction.StoreInteger32 },
			{ "StoreInteger64", IRInstruction.StoreInteger64 },
			{ "StoreParameterCompound", IRInstruction.StoreParameterCompound },
			{ "StoreParameterFloatR4", IRInstruction.StoreParameterFloatR4 },
			{ "StoreParameterFloatR8", IRInstruction.StoreParameterFloatR8 },
			{ "StoreParameterInteger8", IRInstruction.StoreParameterInteger8 },
			{ "StoreParameterInteger16", IRInstruction.StoreParameterInteger16 },
			{ "StoreParameterInteger32", IRInstruction.StoreParameterInteger32 },
			{ "StoreParameterInteger64", IRInstruction.StoreParameterInteger64 },
			{ "SubFloatR4", IRInstruction.SubFloatR4 },
			{ "SubFloatR8", IRInstruction.SubFloatR8 },
			{ "SubSigned32", IRInstruction.SubSigned32 },
			{ "SubSigned64", IRInstruction.SubSigned64 },
			{ "SubUnsigned32", IRInstruction.SubUnsigned32 },
			{ "SubUnsigned64", IRInstruction.SubUnsigned64 },
			{ "Switch", IRInstruction.Switch },
			{ "Throw", IRInstruction.Throw },
			{ "TryEnd", IRInstruction.TryEnd },
			{ "TryStart", IRInstruction.TryStart },
			{ "UnstableObjectTracking", IRInstruction.UnstableObjectTracking },
			{ "Rethrow", IRInstruction.Rethrow },
			{ "GetVirtualFunctionPtr", IRInstruction.GetVirtualFunctionPtr },
			{ "MemoryCopy", IRInstruction.MemoryCopy },
			{ "Box", IRInstruction.Box },
			{ "Box32", IRInstruction.Box32 },
			{ "Box64", IRInstruction.Box64 },
			{ "BoxR4", IRInstruction.BoxR4 },
			{ "BoxR8", IRInstruction.BoxR8 },
			{ "Unbox", IRInstruction.Unbox },
			{ "Unbox32", IRInstruction.Unbox32 },
			{ "Unbox64", IRInstruction.Unbox64 },
			{ "To64", IRInstruction.To64 },
			{ "Split64", IRInstruction.Split64 },
		};
	}
}
