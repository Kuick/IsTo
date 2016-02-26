// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System.IO;
using System.Linq;
using Xunit;

namespace IsTo.Tests
{
	public class TestHelper
	{
		internal static void StreamComparison(
			Stream stream1,
			Stream stream2)
		{

			var bufferSize = 2048;
			var buffer1 = new byte[bufferSize];
			var buffer2 = new byte[bufferSize];
			while(true) {
				var count1 = stream1.Read(buffer1, 0, bufferSize);
				var count2 = stream2.Read(buffer2, 0, bufferSize);

				Assert.True(count1 == count2);
				if(count1 == 0) { return; }

				Assert.True(
					buffer1
						.Take(count1)
						.SequenceEqual(buffer2.Take(count2))
				);
			}
		}

	}
}
