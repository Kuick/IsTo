// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfTypeToChar
	{
		[Fact]
		public void BySelf()
		{
			var value = 'X';
			Assert.True((Char)value.To(typeof(Char)) == value);
		}



		[Theory]
		[InlineData("A", 'A')]
		[InlineData('A', 'A')]
		[InlineData(65, 'A')]
		public void ByPrimative<T>(T value, char expect)
		{
			Assert.True((Char)value.To(typeof(Char)) == expect);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public void ByObjectToChar_False1(object value)
		{
			//
		}

		[Fact]
		public void ByObjectToChar_False2()
		{
			//
		}

		[Fact]
		public void ByObjectToChar_False3()
		{
			//
		}
	}
}
