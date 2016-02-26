// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;

namespace IsTo.Tests
{
	public class Test11 : ITest11
	{
		public int Property11 { get; set; }

		public override int GetHashCode()
		{
			return this.Property11.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var that = obj as Test11;
			if(null == that) { return false; }

			return this.Property11.Equals(that.Property11);
		}

		public static bool operator ==(Test11 a, Test11 b)
		{
			if(Object.ReferenceEquals(a, b)) { return true; }
			if(null == a || null == b) { return false; }

			return a.Equals(b);
		}

		public static bool operator !=(Test11 a, Test11 b)
		{
			return !(a == b);
		}
	}
}
