// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToInt32
	{
		[Fact]
		public void BySelf()
		{
			var value = (Int32)123;
			Assert.True(value.To<Int32>() == value);
		}


		[Theory]
		[InlineData(null, 0)]
		[InlineData(true, 1)]
		[InlineData(false, 0)]
		[InlineData("A", 0)]
		[InlineData("1", 1)]
		[InlineData('A', 65)]
		[InlineData('1', 49)]
		[InlineData(-8.12345678901234, 0)]
		[InlineData(-8.12345678, 0)]
		[InlineData(-8.1234567, 0)]
		[InlineData(-9223372036854775808, 0)]
		[InlineData(-2147483649, 0)]
		[InlineData(-2147483648, -2147483648)]
		[InlineData(-32769, -32769)]
		[InlineData(-32768, -32768)]
		[InlineData(-128, -128)]
		[InlineData(-127, -127)]
		[InlineData(-1, -1)]
		[InlineData(0, 0)]
		[InlineData(128, 128)]
		[InlineData(129, 129)]
		[InlineData(255, 255)]
		[InlineData(256, 256)]
		[InlineData(32767, 32767)]
		[InlineData(32768, 32768)]
		[InlineData(65535, 65535)]
		[InlineData(65536, 65536)]
		[InlineData(2147483647, 2147483647)]
		[InlineData(2147483648, 0)]
		[InlineData(4294967295, 0)]
		[InlineData(4294967296, 0)]
		[InlineData(9223372036854775807, 0)]
		[InlineData(9223372036854775808, 0)]
		[InlineData(18446744073709551615, 0)]
		[InlineData(8.1234567, 0)]
		[InlineData(8.12345678, 0)]
		[InlineData(8.12345678901234, 0)]
		[InlineData("-8.12345678901234", 0)]
		[InlineData("-8.12345678", 0)]
		[InlineData("-8.1234567", 0)]
		[InlineData("-9223372036854775808", 0)]
		[InlineData("-2147483649", 0)]
		[InlineData("-2147483648", -2147483648)]
		[InlineData("-32769", -32769)]
		[InlineData("-32768", -32768)]
		[InlineData("-128", -128)]
		[InlineData("-127", -127)]
		[InlineData("-1", -1)]
		[InlineData("0", 0)]
		[InlineData("128", 128)]
		[InlineData("129", 129)]
		[InlineData("255", 255)]
		[InlineData("256", 256)]
		[InlineData("32767", 32767)]
		[InlineData("32768", 32768)]
		[InlineData("65535", 65535)]
		[InlineData("65536", 65536)]
		[InlineData("2147483647", 2147483647)]
		[InlineData("2147483648", 0)]
		[InlineData("4294967295", 0)]
		[InlineData("4294967296", 0)]
		[InlineData("9223372036854775807", 0)]
		[InlineData("9223372036854775808", 0)]
		[InlineData("18446744073709551615", 0)]
		[InlineData("8.1234567", 0)]
		[InlineData("8.12345678", 0)]
		[InlineData("8.12345678901234", 0)]
		public void ByPrimative<T>(T value, Int32 expect)
		{
			Assert.True(value.To<Int32>() == expect);
		}


		[Fact]
		public void ByIntegerToInteger()
		{
			var i = 123;
			Assert.True(i.To<Int32>() == i);
		}

		[Theory]
		[InlineData("123", 123)]
		[InlineData("123.0", 123)]
		[InlineData("-123", -123)]
		[InlineData("-123.0", -123)]
		[InlineData(123, 123)]
		[InlineData(123.0, 123)]
		[InlineData(-123, -123)]
		[InlineData(-123.0, -123)]
		[InlineData(true, 1)]
		[InlineData(false, 0)]
		public void ByObjectToInteger_True(object value, int expect)
		{
			Assert.True(value.To<Int32>() == expect);
		}


		[Theory]
		[InlineData("123.4", 123)]
		[InlineData("-123.4", -123)]
		[InlineData(123.4, 123)]
		[InlineData(-123.4, -123)]
		[InlineData(true, 2)]
		[InlineData(false, -1)]
		public void ByObjectToInteger_False(object value, int expect)
		{
			Assert.False(value.To<Int32>() == expect);
		}

		[Theory]
		[InlineData("")]
		[InlineData("Number")]
		public void ByObjectToInteger_False2(object value)
		{
			int val;
			Assert.False(value.TryTo<Int32>(out val));
		}

		[Fact]
		public void ByDateTimeToInteger_False3()
		{
			int val;
			Assert.False(DateTime.Now.TryTo<Int32>(out val));
		}

		[Fact]
		public void FromDateTime()
		{
			var value = DateTime.Now;
			Int32 flag;
			Assert.False(value.TryTo<Int32>(out flag));
		}
	}
}
