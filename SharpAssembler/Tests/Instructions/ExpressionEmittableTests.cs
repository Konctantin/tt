﻿#region Copyright and License
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
using System.IO;
using NUnit.Framework;
using SharpAssembler.Instructions;

namespace SharpAssembler.Core.Tests.Instructions
{
	/// <summary>
	/// Tests the <see cref="ExpressionEmittable"/> class.
	/// </summary>
	[TestFixture]
	public class ExpressionEmittableTests : InstructionTestsBase
	{
		/// <summary>
		/// Tests the <see cref="ExpressionEmittable"/> general behavior.
		/// </summary>
		[Test]
		public void ExpressionEmittableTest()
		{
			var expression = new SimpleExpression(0xFEDCBA98);
			var size = DataSize.Bit32;

			var emittable = new ExpressionEmittable(expression, size);
			Assert.AreEqual(expression, emittable.Expression);
			Assert.AreEqual(size, emittable.Size);

			Assert.AreEqual(4, emittable.Emit(Writer, Context));
			Assert.AreEqual(new byte[]{0x98, 0xBA, 0xDC, 0xFE}, Stream.ToArray());
		}
	}
}
