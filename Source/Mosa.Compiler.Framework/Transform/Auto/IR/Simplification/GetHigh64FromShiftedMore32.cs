// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transform.Auto.IR.Simplification
{
	/// <summary>
	/// GetHigh64FromShiftedMore32
	/// </summary>
	public sealed class GetHigh64FromShiftedMore32 : BaseTransformation
	{
		public GetHigh64FromShiftedMore32() : base(IRInstruction.GetHigh64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.ShiftRight64)
				return false;

			if (!IsGreaterThanOrEqual(And32(To32(context.Operand1.Definitions[0].Operand2), 63), 32))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var c1 = transformContext.CreateConstant(0);

			context.SetInstruction(IRInstruction.Move32, result, c1);
		}
	}
}
