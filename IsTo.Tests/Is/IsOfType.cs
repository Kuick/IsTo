// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.Drawing;
using System.IO;
using System.Text;
using Xunit;

namespace IsTo.Tests
{
	public class IsOfType
	{
		[Theory]
		[InlineData("abc def 1234", true)]
		[InlineData(true, true)]
		[InlineData(false, true)]
		[InlineData('A', true)]
		[InlineData(123, true)]
		[InlineData(123U, true)]
		[InlineData(123L, true)]
		[InlineData(123UL, true)]
		[InlineData(123F, true)]
		[InlineData(123D, true)]
		[InlineData(Animal.Cat, true)]
		public void ByPrimativeForIComparable1<T>(T value, bool expect)
		{
			var result = value.Is(typeof(IComparable));
			Assert.True(result == expect);
		}

		[Fact]
		public void ByArrayForIComparable()
		{
			var value = new[] { 1, 2, 3 };
			var result = value.Is(typeof(IComparable));
			var expect = false;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByStreamForIComparable()
		{
			var value = Encoding.UTF8.GetBytes("123123");
			var result = value.Is(typeof(IComparable));
			var expect = false;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByColorForIComparable()
		{
			var value = Color.Beige;
			var result = value.Is(typeof(IComparable));
			var expect = false;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByDateTimeForIComparable()
		{
			var value = DateTime.Now;
			var result = value.Is(typeof(IComparable));
			var expect = true;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByDecimalForIComparable()
		{
			var value = (Decimal)123.456;
			var result = value.Is(typeof(IComparable));
			var expect = true;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByByteForIComparable()
		{
			var value = (Byte)123;
			var result = value.Is(typeof(IComparable));
			var expect = true;
			Assert.True(result == expect);
		}

		[Fact]
		public void BySByteForIComparable()
		{
			var value = (SByte)123;
			var result = value.Is(typeof(IComparable));
			var expect = true;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByInt16ForIComparable()
		{
			var value = (Int16)123;
			var result = value.Is(typeof(IComparable));
			var expect = true;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByUInt16ForIComparable()
		{
			var value = (UInt16)123;
			var result = value.Is(typeof(IComparable));
			var expect = true;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByTest11ForIComparable()
		{
			var value = new Test11();
			var result = value.Is(typeof(IComparable));
			var expect = false;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByTest12ForIComparable()
		{
			var value = new Test12();
			var result = value.Is(typeof(IComparable));
			var expect = true;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByTest13ForIComparable()
		{
			var value = new Test13();
			var result = value.Is(typeof(IComparable));
			var expect = true;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByTest21ForIComparable()
		{
			var value = new Test21<string>();
			var result = value.Is(typeof(IComparable));
			var expect = false;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByTest22ForIComparable()
		{
			var value = new Test22<string, int>();
			var result = value.Is(typeof(IComparable<int>));
			var expect = true;
			Assert.True(result == expect);
		}

		[Fact]
		public void ByTest23ForIComparable()
		{
			var value = new Test23<string, int>();
			var result = value.Is(typeof(IComparable<int>));
			var expect = true;
			Assert.True(result == expect);
		}

		[Theory]
		[InlineData("A")]
		[InlineData(true)]
		[InlineData(false)]
		[InlineData('A')]
		[InlineData(123)]
		[InlineData(123U)]
		[InlineData(123L)]
		[InlineData(123UL)]
		[InlineData(123F)]
		[InlineData(123D)]
		public void ByPrimary1<T>(T value)
		{
			ByPrimaryMain<T>(value);
		}

		[Fact]
		public void ByPrimary2()
		{
			ByPrimaryMain<Color>(Color.Beige);
			ByPrimaryMain<Char>('A');
			ByPrimaryMain<Byte>(123);
			ByPrimaryMain<SByte>(123);
			ByPrimaryMain<Int16>(123);
			ByPrimaryMain<UInt16>(123);
		}

		private void ByPrimaryMain<T>(T value)
		{
			Assert.True(value.Is(typeof(T)));

			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Test11)));
		}


		[Fact]
		public void ByEnumType()
		{
			var value = typeof(Animal);
			ByEnum<Type>(value);
		}

		[Fact]
		public void ByEnumValue()
		{
			var value = Animal.Cat;
			ByEnum<Animal>(value);
		}

		public void ByEnum<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.True(value.Is(typeof(Enum)));  // True
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.True(value.Is(typeof(Animal))); // True
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByStreamType()
		{
			var value = typeof(Stream);
			ByStream<Type>(value);
		}

		[Fact]
		public void ByStreamValue()
		{
			var bytes = Encoding.UTF8.GetBytes("123 ABC 鍾春懿");
			var value = new MemoryStream(bytes);
			ByStream<Stream>(value);
		}

		public void ByStream<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.True(value.Is(typeof(Stream))); // True
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByColorType()
		{
			var value = typeof(Color);
			ByColor<Type>(value);
		}

		[Fact]
		public void ByColorValue()
		{
			var value = Color.BlueViolet;
			ByColor<Color>(value);
		}

		public void ByColor<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.True(value.Is(typeof(Color))); // True
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByStringType()
		{
			var value = typeof(String);
			ByString<Type>(value);
		}

		[Fact]
		public void ByStringValue()
		{
			var value = "123 ABC";
			ByString<String>(value);
		}

		public void ByString<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.True(value.Is(typeof(String))); // True
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByDateTimeType()
		{
			var value = typeof(DateTime);
			ByDateTime<Type>(value);
		}

		[Fact]
		public void ByDateTimeValue()
		{
			var value = DateTime.Now;
			ByDateTime<DateTime>(value);
		}

		public void ByDateTime<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.True(value.Is(typeof(DateTime))); // True
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByDecimalType()
		{
			var value = typeof(Decimal);
			ByDecimal<Type>(value);
		}

		[Fact]
		public void ByDecimalValue()
		{
			var value = 123M;
			ByDecimal<Decimal>(value);
		}

		public void ByDecimal<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.True(value.Is(typeof(Decimal))); // True
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByBooleanType()
		{
			var value = typeof(Boolean);
			ByBoolean<Type>(value);
		}

		[Fact]
		public void ByBooleanValue()
		{
			var value = true;
			ByBoolean<Boolean>(value);
		}

		public void ByBoolean<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.True(value.Is(typeof(Boolean))); // True
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByCharType()
		{
			var value = typeof(Char);
			ByChar<Type>(value);
		}

		[Fact]
		public void ByCharValue()
		{
			var value = 'A';
			ByChar<Char>(value);
		}

		public void ByChar<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.True(value.Is(typeof(Char))); // True
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByByteType()
		{
			var value = typeof(Byte);
			ByByte<Type>(value);
		}

		[Fact]
		public void ByByteValue()
		{
			var value = (Byte)123;
			ByByte<Byte>(value);
		}

		public void ByByte<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.True(value.Is(typeof(Byte))); // True
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void BySByteType()
		{
			var value = typeof(SByte);
			BySByte<Type>(value);
		}

		[Fact]
		public void BySByteValue()
		{
			var value = (SByte)123;
			BySByte<SByte>(value);
		}

		public void BySByte<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.True(value.Is(typeof(SByte))); // True
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByInt16Type()
		{
			var value = typeof(Int16);
			ByInt16<Type>(value);
		}

		[Fact]
		public void ByInt16Value()
		{
			var value = (Int16)123;
			ByInt16<Int16>(value);
		}

		public void ByInt16<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.True(value.Is(typeof(Int16))); // True
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByUInt16Type()
		{
			var value = typeof(UInt16);
			ByUInt16<Type>(value);
		}

		[Fact]
		public void ByUInt16Value()
		{
			var value = (UInt16)123;
			ByUInt16<UInt16>(value);
		}

		public void ByUInt16<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.True(value.Is(typeof(UInt16))); // True
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByInt32Type()
		{
			var value = typeof(Int32);
			ByInt32<Type>(value);
		}

		[Fact]
		public void ByInt32Value()
		{
			var value = (Int32)123;
			ByInt32<Int32>(value);
		}

		public void ByInt32<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.True(value.Is(typeof(Int32))); // True
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByUInt32Type()
		{
			var value = typeof(UInt32);
			ByUInt32<Type>(value);
		}

		[Fact]
		public void ByUInt32Value()
		{
			var value = (UInt32)123;
			ByUInt32<UInt32>(value);
		}

		public void ByUInt32<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.True(value.Is(typeof(UInt32))); // True
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByIntPtrType()
		{
			var value = typeof(IntPtr);
			ByIntPtr<Type>(value);
		}

		[Fact]
		public void ByIntPtrValue()
		{
			var value = (IntPtr)123;
			ByIntPtr<IntPtr>(value);
		}

		public void ByIntPtr<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.True(value.Is(typeof(IntPtr))); // True
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByUIntPtrType()
		{
			var value = typeof(UIntPtr);
			ByUIntPtr<Type>(value);
		}

		[Fact]
		public void ByUIntPtrValue()
		{
			var value = (UIntPtr)123;
			ByUIntPtr<UIntPtr>(value);
		}

		public void ByUIntPtr<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.True(value.Is(typeof(UIntPtr))); // True
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByInt64Type()
		{
			var value = typeof(Int64);
			ByInt64<Type>(value);
		}

		[Fact]
		public void ByInt64Value()
		{
			var value = (Int64)123;
			ByInt64<Int64>(value);
		}

		public void ByInt64<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.True(value.Is(typeof(Int64))); // True
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByUInt64Type()
		{
			var value = typeof(UInt64);
			ByUInt64<Type>(value);
		}

		[Fact]
		public void ByUInt64Value()
		{
			var value = (UInt64)123;
			ByUInt64<UInt64>(value);
		}

		public void ByUInt64<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.True(value.Is(typeof(UInt64))); // True
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void BySingleType()
		{
			var value = typeof(Single);
			BySingle<Type>(value);
		}

		[Fact]
		public void BySingleValue()
		{
			var value = (Single)123;
			BySingle<Single>(value);
		}

		public void BySingle<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.True(value.Is(typeof(Single))); // True
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByDoubleType()
		{
			var value = typeof(Double);
			ByDouble<Type>(value);
		}

		[Fact]
		public void ByDoubleValue()
		{
			var value = (Double)123;
			ByDouble<Double>(value);
		}

		public void ByDouble<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.True(value.Is(typeof(Double))); // True

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByITest11Type()
		{
			var value = typeof(ITest11);
			ByTest11<Type>(value);
		}

		[Fact]
		public void ByITest11Value()
		{
			var value = new Test11();
			ByTest11<ITest11>(value);
		}

		[Fact]
		public void ByTest11Type()
		{
			var value = typeof(Test11);
			ByTest11<Type>(value);
		}

		[Fact]
		public void ByTest11Value()
		{
			var value = new Test11();
			ByTest11<Test11>(value);
		}

		public void ByTest11<T>(T value)
		{
			var isClass = value is Type
				? (value as Type).IsClass
				: value.GetType().IsClass;

			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.True(value.Is(typeof(ITest11))); // True
			Assert.False(value.Is(typeof(ITest12)));
			Assert.True(value.Is(typeof(Test11)) == isClass);
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByITest12Type()
		{
			var value = typeof(ITest12);
			ByTest12<Type>(value);
		}

		[Fact]
		public void ByITest12Value()
		{
			var value = new Test12();
			ByTest12<ITest12>(value);
		}

		[Fact]
		public void ByTest12Type()
		{
			var value = typeof(Test12);
			ByTest12<Type>(value);
		}

		[Fact]
		public void ByTest12Value()
		{
			var value = new Test12();
			ByTest12<Test12>(value);
		}

		public void ByTest12<T>(T value)
		{
			var isClass = value is Type
				? (value as Type).IsClass
				: value.GetType().IsClass;

			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.True(value.Is(typeof(ITest11)) == isClass);
			Assert.True(value.Is(typeof(ITest12))); // True
			Assert.True(value.Is(typeof(Test11)) == isClass);
			Assert.True(value.Is(typeof(Test12)) == isClass);
			Assert.False(value.Is(typeof(Test13)));
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}
		[Fact]
		public void ByTest13Type()
		{
			var value = typeof(Test13);
			ByTest13<Type>(value);
		}

		[Fact]
		public void ByTest13Value()
		{
			var value = new Test13();
			ByTest13<Test13>(value);
		}

		public void ByTest13<T>(T value)
		{
			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.True(value.Is(typeof(ITest11))); // True
			Assert.True(value.Is(typeof(ITest12))); // True
			Assert.True(value.Is(typeof(Test11))); // True
			Assert.True(value.Is(typeof(Test12))); // True
			Assert.True(value.Is(typeof(Test13))); // True
			Assert.False(value.Is(typeof(ITest21<string>)));
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.False(value.Is(typeof(Test21<string>)));
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}


		[Fact]
		public void ByITest21Type()
		{
			var value = typeof(ITest21<string>);
			ByTest21<Type>(value);
		}

		[Fact]
		public void ByITest21Value()
		{
			var value = new Test21<string>();
			ByTest21<ITest21<string>>(value);
		}

		[Fact]
		public void ByTest21Type()
		{
			var value = typeof(Test21<string>);
			ByTest21<Type>(value);
		}

		[Fact]
		public void ByTest21Value()
		{
			var value = new Test21<string>();
			ByTest21<Test21<string>>(value);
		}

		public void ByTest21<T>(T value)
		{
			var isClass = value is Type
				? (value as Type).IsClass
				: value.GetType().IsClass;

			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.True(value.Is(typeof(ITest21<string>))); // True
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.False(value.Is(typeof(ITest22<DateTime>)));
			Assert.True(value.Is(typeof(Test21<string>)) == isClass);
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.False(value.Is(typeof(Test22<string, DateTime>)));
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}

		[Fact]
		public void ByITest22Type()
		{
			var value = typeof(ITest22<DateTime>);
			ByTest22<Type>(value);
		}

		[Fact]
		public void ByITest22Value()
		{
			var value = new Test22<string, DateTime>();
			ByTest22<ITest22<DateTime>>(value);
		}

		[Fact]
		public void ByTest22Type()
		{
			var value = typeof(Test22<string, DateTime>);
			ByTest22<Type>(value);
		}

		[Fact]
		public void ByTest22Value()
		{
			var value = new Test22<string, DateTime>();
			ByTest22<Test22<string, DateTime>>(value);
		}

		public void ByTest22<T>(T value)
		{
			var isClass = value is Type
				? (value as Type).IsClass
				: value.GetType().IsClass;

			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.True(value.Is(typeof(ITest21<string>)) == isClass);
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.True(value.Is(typeof(ITest22<DateTime>))); // True
			Assert.True(value.Is(typeof(Test21<string>)) == isClass);
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.True(value.Is(typeof(Test22<string, DateTime>)) == isClass);
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.False(value.Is(typeof(Test23<string, DateTime>)));
		}


		[Fact]
		public void ByTest23Type()
		{
			var value = typeof(Test23<string, DateTime>);
			ByTest23<Type>(value);
		}

		[Fact]
		public void ByTest23Value()
		{
			var value = new Test23<string, DateTime>();
			ByTest23<Test23<string, DateTime>>(value);
			ByTest23<Test22<string, DateTime>>(value);
			ByTest23<Test21<string>>(value);
			ByTest23<ITest22<DateTime>>(value);
			ByTest23<ITest21<string>>(value);
		}

		public void ByTest23<T>(T value)
		{
			var isClass = value is Type
				? (value as Type).IsClass
				: value.GetType().IsClass;

			Assert.False(value.Is(typeof(Array)));
			Assert.False(value.Is(typeof(Enum)));
			Assert.False(value.Is(typeof(Stream)));
			Assert.False(value.Is(typeof(Color)));
			Assert.False(value.Is(typeof(String)));
			Assert.False(value.Is(typeof(DateTime)));
			Assert.False(value.Is(typeof(Decimal)));
			Assert.False(value.Is(typeof(Boolean)));
			Assert.False(value.Is(typeof(Char)));
			Assert.False(value.Is(typeof(Byte)));
			Assert.False(value.Is(typeof(SByte)));
			Assert.False(value.Is(typeof(Int16)));
			Assert.False(value.Is(typeof(UInt16)));
			Assert.False(value.Is(typeof(Int32)));
			Assert.False(value.Is(typeof(UInt32)));
			Assert.False(value.Is(typeof(IntPtr)));
			Assert.False(value.Is(typeof(UIntPtr)));
			Assert.False(value.Is(typeof(Int64)));
			Assert.False(value.Is(typeof(UInt64)));
			Assert.False(value.Is(typeof(Single)));
			Assert.False(value.Is(typeof(Double)));

			Assert.False(value.Is(typeof(Animal)));
			Assert.False(value.Is(typeof(ITest11)));
			Assert.False(value.Is(typeof(ITest12)));
			Assert.False(value.Is(typeof(Test11)));
			Assert.False(value.Is(typeof(Test12)));
			Assert.False(value.Is(typeof(Test13)));
			Assert.True(value.Is(typeof(ITest21<string>))); // True
			Assert.False(value.Is(typeof(ITest21<DateTime>)));
			Assert.False(value.Is(typeof(ITest22<string>)));
			Assert.True(value.Is(typeof(ITest22<DateTime>))); // True
			Assert.True(value.Is(typeof(Test21<string>))); // True
			Assert.False(value.Is(typeof(Test21<DateTime>)));
			Assert.False(value.Is(typeof(Test22<string, int>)));
			Assert.True(value.Is(typeof(Test22<string, DateTime>))); // True
			Assert.False(value.Is(typeof(Test23<string, int>)));
			Assert.True(value.Is(typeof(Test23<string, DateTime>))); // True
		}
	}
}