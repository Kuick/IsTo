// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfTypeToBoolean
	{
		[Fact]
		public void BySelf()
		{
			var value = false;
			Assert.True(value.To(typeof(Boolean)).Equals(value));
		}



		[Theory]
		[InlineData(true, true)]
		[InlineData(1, true)]
		[InlineData(0, false)]
		[InlineData(0U, false)]
		[InlineData(0L, false)]
		[InlineData(0UL, false)]
		[InlineData(0F, false)]
		[InlineData(0D, false)]
		[InlineData(999, true)]
		[InlineData(999U, true)]
		[InlineData(999L, true)]
		[InlineData(999UL, true)]
		[InlineData(999F, true)]
		[InlineData(999D, true)]
		[InlineData("1", true)]
		[InlineData("99", true)]
		[InlineData("Yes", true)]
		[InlineData("Y", true)]
		[InlineData("On", true)]
		[InlineData("True", true)]
		[InlineData("T", true)]
		[InlineData("O", true)]
		[InlineData(false, false)]
		[InlineData(-1, false)]
		[InlineData(-999, false)]
		[InlineData(null, false)]
		[InlineData("", false)]
		[InlineData("-1", false)]
		[InlineData("-99", false)]
		[InlineData("0", false)]
		[InlineData("No", false)]
		[InlineData("N", false)]
		[InlineData("Off", false)]
		[InlineData("False", false)]
		[InlineData("F", false)]
		[InlineData("X", false)]
		public void ByPrimative<T>(T value, bool expect)
		{
			Assert.True(value.To(typeof(bool)).Equals(expect));
		}


		[Fact]
		public void ByBoolenToBoolen()
		{
			var b = true;
			Assert.True(b.To(typeof(bool)).Equals(b));
		}


	}
}
