﻿// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.IO;
using System.Text;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToStream
	{
		[Fact]
		public void BySelf()
		{
		}


		[Theory]
		[InlineData("abc")]
		[InlineData("abc qweqw 鍾春懿		dfgdf  22- ")]
		public void ByStringToStream(string value)
		{
			var result = value.To<Stream>();
			var bytes = Encoding.UTF8.GetBytes(value);
			var expect = new MemoryStream(bytes);

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public void ByBooleanToStream(bool value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData('1')]
		[InlineData('A')]
		[InlineData('!')]
		public void ByCharToStream(char value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData(1D)]
		[InlineData(123.456D)]
		[InlineData(-1D)]
		[InlineData(-123.456D)]
		public void ByDoubleToStream(double value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData(1F)]
		[InlineData(123.456F)]
		[InlineData(-1F)]
		[InlineData(-123.456F)]
		public void ByFloatToStream(float value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData(123)]
		[InlineData(-123)]
		public void ByIntegerToStream(int value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData(123L)]
		[InlineData(123456L)]
		[InlineData(-123L)]
		[InlineData(-123456L)]
		public void ByLongToStream(long value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(123)]
		[InlineData(-1)]
		[InlineData(-123)]
		public void ByShortToStream(short value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(123)]
		public void ByUIntToStream(uint value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(123)]
		public void ByULongToStream(ulong value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(123)]
		public void ByUShortToStream(ushort value)
		{
			var bytes = BitConverter.GetBytes(value);
			var expect = new MemoryStream(bytes);
			var result = value.To<Stream>();

			TestHelper.StreamComparison(result, expect);
		}


		[Fact]
		public void ByStreamToStream()
		{
			var bytes = new byte[] { 0x1, 0x2, 0x3, 0x4, 0x5, 0x6 };
			var strm1 = new MemoryStream(bytes);
			var strm2 = new MemoryStream(bytes);

			var result = strm2.To<Stream>();
			TestHelper.StreamComparison(result, strm1);
		}


		[Fact]
		public void FromDateTime()
		{
			var value = DateTime.Now;
			Stream flag;
			Assert.True(value.TryTo<Stream>(out flag));
		}
	}
}
