// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToChar
	{
		[Fact]
		public void BySelf()
		{
			var value = 'X';
			Assert.True(value.To<Char>() == value);
		}



		[Theory]
		[InlineData("A", 'A')]
		[InlineData('A', 'A')]
		[InlineData(65, 'A')]
		public void ByPrimative<T>(T value, char expect)
		{
			Assert.True(value.To<Char>() == expect);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public void ByObjectToChar_False1(object value)
		{
			char c;
			Assert.False(value.TryTo<Char>(out c));
		}

		[Fact]
		public void ByObjectToChar_False2()
		{
			char c;
			Assert.False(DateTime.Now.TryTo<Char>(out c));
		}

		[Fact]
		public void ByObjectToChar_False3()
		{
			char c;
			Assert.False(123M.TryTo<Char>(out c));
		}
	}
}
