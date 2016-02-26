// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToByte
	{
		[Fact]
		public void BySelf()
		{
			byte _byte = 0x1;
			Assert.True(_byte.To<Byte>() == _byte);
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
		[InlineData(-2147483648, 0)]
		[InlineData(-32769, 0)]
		[InlineData(-32768, 0)]
		[InlineData(-128, 0)]
		[InlineData(-127, 0)]
		[InlineData(-1, 0)]
		[InlineData(0, 0)]
		[InlineData(128, 128)]
		[InlineData(129, 129)]
		[InlineData(255, 255)]
		[InlineData(256, 0)]
		[InlineData(32767, 0)]
		[InlineData(32768, 0)]
		[InlineData(65535, 0)]
		[InlineData(65536, 0)]
		[InlineData(2147483647, 0)]
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
		[InlineData("-2147483648", 0)]
		[InlineData("-32769", 0)]
		[InlineData("-32768", 0)]
		[InlineData("-128", 0)]
		[InlineData("-127", 0)]
		[InlineData("-1", 0)]
		[InlineData("0", 0)]
		[InlineData("128", 128)]
		[InlineData("129", 129)]
		[InlineData("255", 255)]
		[InlineData("256", 0)]
		[InlineData("32767", 0)]
		[InlineData("32768", 0)]
		[InlineData("65535", 0)]
		[InlineData("65536", 0)]
		[InlineData("2147483647", 0)]
		[InlineData("2147483648", 0)]
		[InlineData("4294967295", 0)]
		[InlineData("4294967296", 0)]
		[InlineData("9223372036854775807", 0)]
		[InlineData("9223372036854775808", 0)]
		[InlineData("18446744073709551615", 0)]
		[InlineData("8.1234567", 0)]
		[InlineData("8.12345678", 0)]
		[InlineData("8.12345678901234", 0)]
		public void ByPrimative<T>(T value, byte expect)
		{
			Assert.True(value.To<Byte>() == expect);
		}


	}
}
