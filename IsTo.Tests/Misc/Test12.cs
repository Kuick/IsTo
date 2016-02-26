// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;

namespace IsTo.Tests
{
	public class Test12 : Test11, ITest12
	{
		public int Property12 { get; set; }

		public int CompareTo(object obj)
		{
			var that = obj as Test12;
			if(null == that) { return 1; }
			if(this.Property11 > that.Property11) {
				return 1;
			} else if(this.Property11 < that.Property11) {
				return -1;
			} else {
				if(this.Property12 > that.Property12) {
					return 1;
				} else if(this.Property12 < that.Property12) {
					return -1;
				} else {
					return 0;
				}
			}
		}

		public override int GetHashCode()
		{
			return new[] { this.Property11, this.Property12 }
				.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var that = obj as Test12;
			if(null == that) { return false; }

			return
				this.Property11.Equals(that.Property11)
				&&
				this.Property12.Equals(that.Property12);
		}

		public static bool operator ==(Test12 a, Test12 b)
		{
			if(Object.ReferenceEquals(a, b)) { return true; }
			if(null == a || null == b) { return false; }

			return a.Equals(b);
		}

		public static bool operator !=(Test12 a, Test12 b)
		{
			return !(a == b);
		}

	}
}
