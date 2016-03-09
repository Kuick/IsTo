// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-03-08 - Creation

using System;
using System.Collections.Generic;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToDynamic
	{
		[Fact]
		public void ByString()
		{
			var value = @"
{
	""A"": ""abc"",
	""B"": 123
}
";
			var result = value.To<dynamic>();
			var date = new DateTime(2016, 3, 8);
			result.C = date;

			Assert.True(result.A == "abc");
			Assert.True(result.B == 123);
			Assert.True(result.C == date);
		}
	}
}
