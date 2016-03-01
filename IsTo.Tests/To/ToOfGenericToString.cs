// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToString
	{
		[Fact]
		public void BySelf()
		{
			var value = "123 ABC";
			Assert.True(value.To<String>() == value);
		}



		[Theory]
		[InlineData("123", "123")]
		[InlineData(123, "123")]
		[InlineData(123.0, "123")]
		[InlineData(123.456, "123.456")]
		[InlineData(true, "True")]
		[InlineData(false, "False")]
		[InlineData('A', "A")]
		[InlineData(Animal.Cat, "Cat")]
		public void ByPrimative<T>(T value, string expect)
		{
			Assert.True(value.To<String>() == expect);
		}

		[Fact]
		public void ByDateTimeToString1()
		{
			var value = new DateTime(2016, 2, 11, 14, 2, 3, 4);
			var result = value.To<String>();
			var expect = "2016-02-11 14:02:03.0040000";
			Assert.True(result == expect);
		}


		[Fact]
		public void ByDateTimeToString2()
		{
			var value = new DateTime(2016, 2, 11, 14, 2, 3, 4);
			var result = value.To<String>("", format: "yyyy/MM/dd");
			var expect = "2016/02/11";
			Assert.True(result == expect);
		}



		[Fact]
		public void ByStringToString()
		{
			var str = "Qwe!23";
			Assert.True(str.To<String>() == str);
		}
	}
}
