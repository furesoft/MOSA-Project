// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	/// LogicalOr32
	/// </summary>
	/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
	public sealed class LogicalOr32 : BaseIRInstruction
	{
		public LogicalOr32()
			: base(2, 1)
		{
		}

		public override bool IsCommutative { get { return true; } }
	}
}
