﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	/// Intermediate representation of the floating point add operation.
	/// </summary>
	/// <remarks>
	/// The add instruction is a three-address instruction, where the result receives
	/// the value of the first operand (index 0) added with the second operand (index 1).
	/// <para />
	/// Both the first and second operand must be the same integral type. If the second operand
	/// is statically or dynamically equal to or larger than the number of bits in the first
	/// operand, the result is undefined.
	/// </remarks>
	public sealed class AddFloat : ThreeOperandInstruction
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AddFloat"/>.
		/// </summary>
		public AddFloat()
		{
		}

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor object.</param>
		/// <param name="context">The context.</param>
		public override void Visit(IIRVisitor visitor, Context context)
		{
			visitor.AddFloat(context);
		}
	}
}
