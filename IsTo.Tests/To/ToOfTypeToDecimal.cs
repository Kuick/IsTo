// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfTypeToDecimal
	{
		[Fact]
		public void BySelf()
		{
			var value = (Decimal)123.456;
			Assert.True((Decimal)value.To(typeof(Decimal)) == value);
		}

		[Theory]
		[InlineData(null, 0)]
		[InlineData(true, 1)]
		[InlineData(false, 0)]
		[InlineData("A", 0)]
		[InlineData("1", 1)]
		[InlineData('A', 65)]
		[InlineData('1', 49)]
		[InlineData(-8.12345678901234, -8.12345678901234)]
		[InlineData(-8.12345678, -8.12345678)]
		[InlineData(-8.1234567, -8.1234567)]
		[InlineData(-9223372036854775808, -9223372036854775808)]
		[InlineData(-2147483649, -2147483649)]
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
		[InlineData(2147483648, 2147483648)]
		[InlineData(4294967295, 4294967295)]
		[InlineData(4294967296, 4294967296)]
		[InlineData(9223372036854775807, 9223372036854775807)]
		[InlineData(9223372036854775808, 9223372036854775808)]
		[InlineData(18446744073709551615, 18446744073709551615)]
		[InlineData(8.1234567, 8.1234567)]
		[InlineData(8.12345678, 8.12345678)]
		[InlineData(8.12345678901234, 8.12345678901234)]
		[InlineData("-8.12345678901234", -8.12345678901234)]
		[InlineData("-8.12345678", -8.12345678)]
		[InlineData("-8.1234567", -8.1234567)]
		[InlineData("-9223372036854775808", -9223372036854775808)]
		[InlineData("-2147483649", -2147483649)]
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
		[InlineData("2147483648", 2147483648)]
		[InlineData("4294967295", 4294967295)]
		[InlineData("4294967296", 4294967296)]
		[InlineData("9223372036854775807", 9223372036854775807)]
		[InlineData("9223372036854775808", 9223372036854775808)]
		[InlineData("18446744073709551615", 18446744073709551615)]
		[InlineData("8.1234567", 8.1234567)]
		[InlineData("8.12345678", 8.12345678)]
		[InlineData("8.12345678901234", 8.12345678901234)]
		public void ByPrimative<T>(T value, decimal expect)
		{
			Assert.True((Decimal)value.To(typeof(Decimal)) == expect);
		}


		[Fact]
		public void ByDecimalToDecimal()
		{
			var d = 8.12345678901234567890123456M;
			Assert.True((Decimal)d.To(typeof(Decimal)) == d);
		}

	}
}
