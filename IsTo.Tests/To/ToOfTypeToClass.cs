// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using Xunit;

namespace IsTo.Tests
{
	public class ToOfTypeToClass
	{
		[Fact]
		public void BySelf()
		{
			var value = new Test12() {
				Property11 = 2,
				Property12 = 4
			};
			var result = value.To(typeof(Test12));
			var expect = new Test12() {
				Property11 = 2,
				Property12 = 4
			};
			Assert.True(result.Equals(expect));
		}


		[Fact]
		public void ByDerived()
		{
			var value = new Test12() {
				Property11 = 2,
				Property12 = 4
			};
			var result = value.To(typeof(Test11));
			var expect = new Test11() {
				Property11 = 2
			};
			Assert.True(expect.Equals(result));
		}

		[Fact]
		public void ByJson()
		{
			var value = @"
{
	""Property11"": 123,
	""Property12"": 456
}
";
			var result = value.To(typeof(Test12));
			var expect = new Test12() {
				Property11 = 123,
				Property12 = 456
			};
			Assert.True(result.Equals(expect));
		}
	}
}
