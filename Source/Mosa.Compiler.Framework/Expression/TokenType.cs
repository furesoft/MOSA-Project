﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System.Collections.Generic;
using System.Diagnostics;

namespace Mosa.Compiler.Framework.Expression
{
	/// <summary>
	/// TokenType
	/// </summary>
	public enum TokenType
	{
		Unknown,

		OpenParens, // syntax:
		CloseParens,
		OpenBracket,
		CloseBracket,
		Comma,
		Transform,
		Underscore,
		Period,

		And,    // boolean logic:
		Or,
		Not,
		Questionmark,
		Colon,

		Addition,   // math:
		Subtract,
		Multiplication,
		Division,
		Modulus,
		Negate,

		IntegerConstant, // literals:
		HexIntegerConstant,
		FloatConstant,
		BooleanTrueConstant,
		BooleanFalseConstant,

		CompareEqual,   // comparisons:
		CompareNotEqual,
		CompareGreaterThanOrEqual,
		CompareLessThanOrEqual,
		CompareLessThan,
		CompareGreaterThan,

		If,

		ShiftRight,
		ShiftLeft,

		Identifier,  // temporary

		InstructionFamily,
		InstructionName,
		ClassName,
		MethodName,
		TypeVariable,
		OperandVariable,
		ConstLiteral,

		Method,     // ???
	}
}