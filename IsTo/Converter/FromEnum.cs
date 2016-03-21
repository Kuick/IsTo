// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-03-21 - Creation

using System;

namespace IsTo
{
	public partial class IsToConverter
	{
		public class FromEnum
		{
			// ToString
			private static Func<Type, object, string> _ToString;
			public new static Func<Type, object, string> ToString
			{
				get
				{
					return null == _ToString
						? ToStringDefault
						: _ToString;
				}
				set
				{
					_ToString = value;
				}
			}

			private static string ToStringDefault(
				Type fromType,
				object value)
			{
				var result = value.ToString();
				return result;
			}
		}
	}
}
