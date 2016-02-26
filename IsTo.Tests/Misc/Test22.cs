// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;

namespace IsTo.Tests
{
	public class Test22<T, O> : Test21<T>, ITest22<O>
	{
		public int Property12 { get; set; }
		public int Property22 { get; set; }

		public int CompareTo(O other)
		{
			var that = other as Test22<T, O>;
			if(null == that) { return 1; }
			if(this.Property21 > that.Property21) {
				return 1;
			} else if(this.Property21 < that.Property21) {
				return -1;
			} else {
				if(this.Property22 > that.Property22) {
					return 1;
				} else if(this.Property22 < that.Property22) {
					return -1;
				} else {
					return 0;
				}
			}
		}

		public override int GetHashCode()
		{
			return new[] {
				this.Property11, 
				this.Property21,
				this.Property12, 
				this.Property22 
			}.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var that = obj as Test22<T, O>;
			if(null == that) { return false; }

			return
				this.Property11.Equals(that.Property11)
				&&
				this.Property21.Equals(that.Property21)
				&&
				this.Property12.Equals(that.Property12)
				&&
				this.Property22.Equals(that.Property22);
		}

		public static bool operator ==(Test22<T, O> a, Test22<T, O> b)
		{
			if(Object.ReferenceEquals(a, b)) { return true; }
			if(null == a || null == b) { return false; }

			return a.Equals(b);
		}

		public static bool operator !=(Test22<T, O> a, Test22<T, O> b)
		{
			return !(a == b);
		}
	}
}
