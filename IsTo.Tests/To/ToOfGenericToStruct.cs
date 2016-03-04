// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-03-04 - Creation

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToStruct
	{
		[Fact]
		public void FromClass()
		{
			var value = new Test13() {
				Property11 = 1,
				Property12 = 2,
				Property13 = 3
			};
			var result = value.To<TestStruct>();
			var expect = new TestStruct {
				Property11 = 1,
				Property12 = 2,
				Property13 = 3
			};
			Assert.True(result.Equals(expect));
		}

		[Fact]
		public void FromStruct()
		{
			var value = new TestStruct {
				Property11 = 1,
				Property12 = 2,
				Property13 = 3
			};
			var result = value.To<TestStruct>();
			var expect = new TestStruct {
				Property11 = 1,
				Property12 = 2,
				Property13 = 3
			};
			Assert.True(result.Equals(expect));
		}
	}
}
