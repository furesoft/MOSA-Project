// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transform.Auto.IR.ConstantFolding
{
	/// <summary>
	/// IfThenElse64AlwaysFalse
	/// </summary>
	public sealed class IfThenElse64AlwaysFalse : BaseTransformation
	{
		public IfThenElse64AlwaysFalse() : base(IRInstruction.IfThenElse64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!IsResolvedConstant(context.Operand1))
				return false;

			if (!IsZero(context.Operand1))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand3;

			context.SetInstruction(IRInstruction.Move64, result, t1);
		}
	}
}