// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToArray
	{
		[Fact]
		public void BySelf()
		{
			var value = new Int32[] { 1, 2 };
			Assert.True(value.To<Int32[]>() == value);
		}


		[Theory]
		[InlineData("abc def 1234")]
		[InlineData(true)]
		[InlineData(false)]
		[InlineData('A')]
		[InlineData(123)]
		[InlineData(123U)]
		[InlineData(123L)]
		[InlineData(123UL)]
		[InlineData(123F)]
		[InlineData(123D)]
		[InlineData(Animal.Cat)]
		public void ByPrimative<T>(T value)
		{
			var values = new T[] { value };
			var expect = value.To<T[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByStream()
		{
			var value = "123123";
			var value1 = new MemoryStream(
				Encoding.UTF8.GetBytes(value)
			);
			var value2 = new MemoryStream(
				Encoding.UTF8.GetBytes(value)
			);
			var values = new MemoryStream[] { value1 };
			var expect = value2.To<MemoryStream[]>();
			TestHelper.StreamComparison(values[0], expect[0]);
		}

		[Fact]
		public void ByColor()
		{
			var value = Color.Beige;
			var values = new Color[] { value };
			var expect = value.To<Color[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByDateTime()
		{
			var value = DateTime.Now;
			var values = new DateTime[] { value };
			var expect = value.To<DateTime[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByDecimal()
		{
			var value = (Decimal)123.456;
			var values = new Decimal[] { value };
			var expect = value.To<Decimal[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByByte()
		{
			var value = (Byte)123;
			var values = new Byte[] { value };
			var expect = value.To<Byte[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void BySByte()
		{
			var value = (SByte)123;
			var values = new SByte[] { value };
			var expect = value.To<SByte[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByInt16()
		{
			var value = (Int16)123;
			var values = new Int16[] { value };
			var expect = value.To<Int16[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByUInt16()
		{
			var value = (UInt16)123;
			var values = new UInt16[] { value };
			var expect = value.To<UInt16[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByTest11()
		{
			var value = new Test11();
			var values = new Test11[] { value };
			var expect = value.To<Test11[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByTest12()
		{
			var value = new Test12();
			var values = new Test12[] { value };
			var expect = value.To<Test12[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByTest13()
		{
			var value = new Test13();
			var values = new Test13[] { value };
			var expect = value.To<Test13[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByTest21()
		{
			var value = new Test21<string>();
			var values = new Test21<string>[] { value };
			var expect = value.To<Test21<string>[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByTest22()
		{
			var value = new Test22<string, int>();
			var values = new Test22<string, int>[] { value };
			var expect = value.To<Test22<string, int>[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByTest23()
		{
			var value = new Test23<string, int>();
			var values = new Test23<string, int>[] { value };
			var expect = value.To<Test23<string, int>[]>();
			Assert.True(values.SequenceEqual(expect));
		}




		[Fact]
		public void ByEnumToArrayOfInteger()
		{
			var value = Animal.Dog;
			var values = new int[] { (int)value };
			var expect = value.To<int[]>();
			Assert.True(values.SequenceEqual(expect));
		}

		[Fact]
		public void ByEnumToArrayOfString()
		{
			var value = Animal.Dog;
			var values = new string[] { value.ToString() };
			var expect = value.To<string[]>();
			Assert.True(values.SequenceEqual(expect));
		}



		[Fact]
		public void ByIntegerToArrayOfByte()
		{
			byte value = 111;
			var values = new byte[] { value };
			var expect = value.To<Byte[]>();
			Assert.True(values.SequenceEqual(expect));
		}





		[Fact]
		public void ByArrayOfEnumToArrayOfString()
		{
			var result = new[] { Animal.Bird, Animal.Cat }
				.To<string[]>();
			var expect = new string[] {
				Animal.Bird.ToString(),
				Animal.Cat.ToString()
			};
			Assert.True(result.SequenceEqual(expect));
		}

		[Fact]
		public void ByArrayOfEnumToArrayOfInteger()
		{
			var result = new[] { Animal.Bird, Animal.Cat }
				.To<int[]>();
			var expect = new int[] {
				(int)Animal.Bird,
				(int)Animal.Cat
			};
			Assert.True(result.SequenceEqual(expect));
		}

		[Fact]
		public void ByArrayOfEnumToArrayOfEnum()
		{
			var result = new[] {
				Animal.Bird,
				Animal.Cat
			}.To<Animal[]>();
			var expect = new Animal[] {
				Animal.Bird,
				Animal.Cat
			};
			Assert.True(result.SequenceEqual(expect));
		}

		[Fact]
		public void ByArrayOfStringToArrayOfEnum()
		{
			var result = new[] { "Bird", "Cat" }
				.To<Animal[]>();
			var expect = new Animal[] {
				Animal.Bird,
				Animal.Cat
			};
			Assert.True(result.SequenceEqual(expect));
		}

		[Fact]
		public void ByArrayOfIntegerToArrayOfEnum()
		{
			var result = new[] { 0, 1 }
				.To<Animal[]>();
			var expect = new Animal[] {
				Animal.Bird,
				Animal.Cat
			};
			Assert.True(result.SequenceEqual(expect));
		}


		[Theory]
		[InlineData(true, false, true)]
		[InlineData(100, 101, true)]
		[InlineData(100.1, 101.1, false)]
		[InlineData(100, 300, false)]
		[InlineData(100, 300.1, false)]
		[InlineData("100", "101", true)]
		[InlineData("1001.", "101.1", false)]
		[InlineData("100", "300", false)]
		[InlineData("100.1", "300.1", false)]
		[InlineData("A", "B", false)]
		[InlineData('A', 'B', true)]
		[InlineData('1', '2', true)]
		[InlineData(100U, 101U, true)]
		[InlineData(100U, 300U, false)]
		[InlineData(100L, 101L, true)]
		[InlineData(100UL, 300UL, false)]
		[InlineData(100F, 101F, true)]
		[InlineData(100D, 300D, false)]
		public void ByArrayToArrayOfByte<T>(
			T value1,
			T value2,
			bool expect)
		{
			byte[] result;
			Assert.True(
				new[] { value1, value2 }.TryTo<byte[]>(out result)
				==
				expect
			);
		}




		[Fact]
		public void ByArrayToArrayOfClass()
		{
			var classA = new Test22<string, int>() {
				Property11 = 1,
				Property21 = 3,
				Property12 = 5,
				Property22 = 7
			};
			var classB = new Test22<string, int>() {
				Property11 = 2,
				Property21 = 4,
				Property12 = 6,
				Property22 = 8
			};
			var result = new[] { classA, classB }.To<Test11[]>();

			var expect = new[] {
				new Test11(){Property11 = 1},
				new Test11(){Property11 = 2}
			};
			Assert.True(expect.SequenceEqual(result));
		}

		[Fact]
		public void ByArrayToIQueryableOfClass()
		{
			var classA = new Test22<string, int>() {
				Property11 = 1,
				Property21 = 3,
				Property12 = 5,
				Property22 = 7
			};
			var classB = new Test22<string, int>() {
				Property11 = 2,
				Property21 = 4,
				Property12 = 6,
				Property22 = 8
			};
			var result = new[] { classA, classB }.To<IQueryable<Test11>>();

			var expect = new[] {
				new Test11(){Property11 = 1},
				new Test11(){Property11 = 2}
			};
			Assert.True(expect.SequenceEqual(result));
		}

		[Fact]
		public void ByJson()
		{
			var value = @"
[
	{
		""Property11"": 123,
		""Property12"": 456
	},
	{
		""Property11"": 135,
		""Property12"": 246
	}
]";
			var result = value.To<List<Test12>>();
			var expect = new List<Test12>();
			expect.Add(new Test12() {
				Property11 = 123,
				Property12 = 456
			});
			expect.Add(new Test12() {
				Property11 = 135,
				Property12 = 246
			});
			Assert.True(result.SequenceEqual(expect));
		}


		[Fact]
		public void ByDictionary()
		{
			// Not support yet!

			//var value = new Dictionary<string, Animal>();
			//value.Add("Bird", Animal.Bird);
			//value.Add("Cat", Animal.Cat);
			//var result = value.To<Dictionary<Animal, string>>();

			//var expect = new Dictionary<Animal, string>();
			//expect.Add(Animal.Bird, "Bird");
			//expect.Add(Animal.Cat, "Cat");

			//Assert.True(result.SequenceEqual(expect));
		}
	}
}
