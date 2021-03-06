﻿// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.Linq;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToDateTime
	{
		[Fact]
		public void BySelf()
		{
			var value = DateTime.Now;
			Assert.True(value.To<DateTime>() == value);
		}


		[Theory]
		[InlineData("2016/2", 2016, 2, 1)]
		[InlineData("2016/2/11", 2016, 2, 11)]
		[InlineData("2016/02", 2016, 2, 1)]
		[InlineData("2016/02/11", 2016, 2, 11)]
		[InlineData("2016-2", 2016, 2, 1)]
		[InlineData("2016-2-11", 2016, 2, 11)]
		[InlineData("20160201", 2016, 2, 1)]
		[InlineData("20160211", 2016, 2, 11)]
		[InlineData("10506", 1, 5, 6)]
		[InlineData("120506", 12, 5, 6)]
		[InlineData("1230506", 123, 5, 6)]
		[InlineData("12340506", 1234, 5, 6)]
		public void ByStringToDateTime(
			string value,
			int year,
			int month,
			int day)
		{
			Assert.True(
				value.To<DateTime>()
				==
				new DateTime(year, month, day)
			);
		}




		[Fact]
		public void ByDateTimeToDateTime()
		{
			var dt = new DateTime(2016, 2, 11);
			Assert.True(dt.To<DateTime>() == dt);
		}

		[Theory]
		[InlineData(true)]
		[InlineData('A')]
		[InlineData(100)]
		[InlineData(100D)]
		[InlineData(100F)]
		[InlineData(100U)]
		[InlineData(100UL)]
		public void NotSupport<T>(
			T value)
		{
			DateTime dt;
			Assert.False(value.TryTo<DateTime>(out dt));


		}

		[Fact]
		public void FromInt64()
		{
			var expect = new DateTime(
				1971, 8, 31, 11, 22, 33, 44
			);
			var value = expect.ToBinary(); //621880825530440000L;
			var result = value.To<DateTime>();
			Assert.True(result == expect);
		}

		[Fact]
		public void FromByteArray()
		{
			var value = new DateTime(
				1971, 8, 31, 11, 22, 33, 44
			);
			var expect = BitConverter.GetBytes(value.ToBinary());
			var result = value.To<byte[]>();
			Assert.True(result.SequenceEqual(expect));
		}
	}
}
