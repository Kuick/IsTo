// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;

namespace IsTo.Tests
{
	public class Test21<T> : ITest21<T>
	{
		public int Property11 { get; set; }
		public int Property21 { get; set; }

		public override int GetHashCode()
		{
			return new[] { this.Property11, this.Property21 }
				.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var that = obj as Test21<T>;
			if(null == that) { return false; }

			return
				this.Property11.Equals(that.Property11)
				&&
				this.Property21.Equals(that.Property21);
		}

		public static bool operator ==(Test21<T> a, Test21<T> b)
		{
			if(Object.ReferenceEquals(a, b)) { return true; }
			if(null == a || null == b) { return false; }

			return a.Equals(b);
		}

		public static bool operator !=(Test21<T> a, Test21<T> b)
		{
			return !(a == b);
		}
	}
}
