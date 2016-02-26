// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using Xunit;

namespace IsTo.Tests
{
	public class ToOfTypeToEnum
	{
		[Fact]
		public void BySelf()
		{
			var value = Animal.Bird;
			Assert.True((Animal)value.To(typeof(Animal)) == value);
		}



		[Theory]
		[InlineData("Cat", Animal.Cat)]
		[InlineData("Dog", Animal.Dog)]
		[InlineData("1", Animal.Cat)]
		[InlineData("2", Animal.Dog)]
		[InlineData("1.0", Animal.Cat)]
		[InlineData("2.0", Animal.Dog)]
		[InlineData(1, Animal.Cat)]
		[InlineData(2, Animal.Dog)]
		[InlineData(1.0, Animal.Cat)]
		[InlineData(2.0, Animal.Dog)]
		[InlineData(false, Animal.Bird)]
		[InlineData(true, Animal.Bird)]
		public void ByPrimative<T>(T value, Animal expect)
		{
			Assert.True((Animal)value.To(typeof(Animal)) == expect);
		}


		[Fact]
		public void ByEnumToEnum()
		{
			var enu = Animal.Dog;
			Assert.True((Animal)enu.To(typeof(Animal)) == Animal.Dog);
		}


		[Theory]
		[InlineData("Dog", Animal.Cat)]
		[InlineData("Cat", Animal.Dog)]
		[InlineData("2", Animal.Cat)]
		[InlineData("1", Animal.Dog)]
		[InlineData("2.0", Animal.Cat)]
		[InlineData("1.0", Animal.Dog)]
		[InlineData(2, Animal.Cat)]
		[InlineData(1, Animal.Dog)]
		[InlineData(2.0, Animal.Cat)]
		[InlineData(1.0, Animal.Dog)]
		[InlineData(true, Animal.Dog)]
		[InlineData(false, Animal.Dog)]
		public void ByObjectToEnum_False(object value, Animal expect)
		{
			Assert.False((Animal)value.To(typeof(Animal)) == expect);
		}

	}
}
