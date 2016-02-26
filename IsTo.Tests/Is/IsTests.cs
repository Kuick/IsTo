// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;

namespace IsTo.Tests
{
	public class IsTests
	{
		public enum IsTestEnum
		{
			Aaa,
			Bbb,
			Ccc
		}

		public interface ITest11 { }
		public interface ITest12 : IComparable { }
		public class Test11 : ITest11 { }
		public class Test12 : Test11, ITest12
		{
			public int CompareTo(object obj)
			{
				throw new NotImplementedException();
			}
		}
		public class Test13 : Test12 { }


		public interface ITest21<T> { }
		public interface ITest22<O> : IComparable<O> { }
		public class Test21<T> : ITest21<T> { }
		public class Test22<T, O> : Test21<T>, ITest22<O>
		{
			public int CompareTo(O other)
			{
				throw new NotImplementedException();
			}
		}
		public class Test23<T, O> : Test22<T, O> { }
	}
}
