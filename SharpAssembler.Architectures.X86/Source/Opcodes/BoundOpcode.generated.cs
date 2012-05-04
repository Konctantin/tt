﻿//////////////////////////////////////////////////////
//                     WARNING                      //
//     The contents of this file is generated.      //
//    DO NOT MODIFY, your changes will be lost!     //
//////////////////////////////////////////////////////
#region Copyright and License
/*
 * SharpAssembler
 * Library for .NET that assembles a predetermined list of
 * instructions into machine code.
 * 
 * Copyright (C) 2011-2012 Daniël Pelsmaeker
 * 
 * This file is part of SharpAssembler.
 * 
 * SharpAssembler is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * SharpAssembler is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with SharpAssembler.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using SharpAssembler.Architectures.X86.Opcodes;
using SharpAssembler.Architectures.X86.Operands;

namespace SharpAssembler.Architectures.X86.Opcodes
{
	/// <summary>
	/// The BOUND (Check Array Bound) instruction opcode.
	/// </summary>
	public class BoundOpcode : X86Opcode
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BoundOpcode"/> class.
		/// </summary>
		public BoundOpcode()
			: base("bound", GetOpcodeVariants())
		{ /* Nothing to do. */ }
		#endregion

		/// <summary>
		/// Returns the opcode variants of this opcode.
		/// </summary>
		/// <returns>An enumerable collection of <see cref="X86OpcodeVariant"/> objects.</returns>
		private static IEnumerable<X86OpcodeVariant> GetOpcodeVariants()
		{
			return new X86OpcodeVariant[]{
				// BOUND reg16, mem16
				new X86OpcodeVariant(
					new byte[] { 0x62 },
					new OperandDescriptor(OperandType.RegisterOperand, RegisterType.GeneralPurpose16Bit),
					new OperandDescriptor(OperandType.MemoryOperand, DataSize.Bit16))
					{ SupportedModes = ProcessorModes.ProtectedReal },
				// BOUND reg32, mem32
				new X86OpcodeVariant(
					new byte[] { 0x62 },
					new OperandDescriptor(OperandType.RegisterOperand, RegisterType.GeneralPurpose32Bit),
					new OperandDescriptor(OperandType.MemoryOperand, DataSize.Bit32))
					{ SupportedModes = ProcessorModes.ProtectedReal },
			};
		}
	}
}

namespace SharpAssembler.Architectures.X86
{
	partial class Instr
	{
		/// <summary>
		/// Creates a new BOUND (Check Array Bound) instruction.
		/// </summary>
		/// <param name="index">A register.</param>
		/// <param name="bounds">A memory operand.</param>
		/// <returns>The created instruction.</returns>
		public static X86Instruction Bound(Register index, EffectiveAddress bounds)
		{ return X86Opcode.Bound.CreateInstruction(new RegisterOperand(index), bounds); }
	}

	partial class X86Opcode
	{
		/// <summary>
		/// The BOUND (Check Array Bound) instruction opcode.
		/// </summary>
		public static readonly X86Opcode Bound = new BoundOpcode();
	}
}

//////////////////////////////////////////////////////
//                     WARNING                      //
//     The contents of this file is generated.      //
//    DO NOT MODIFY, your changes will be lost!     //
//////////////////////////////////////////////////////
