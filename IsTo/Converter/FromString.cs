// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-03-21 - Creation

using System;

namespace IsTo
{
	public partial class IsToConverter
	{
		public class FromString
		{
			// ToEnum
			private static Func<Type, string, object> _ToEnum;
			public static Func<Type, string, object> ToEnum
			{
				get
				{
					return null == _ToEnum
						? ToEnumDefault
						: _ToEnum;
				}
				set
				{
					_ToEnum = value;
				}
			}

			private static object ToEnumDefault(
				Type toType,
				string value)
			{
				var result = Enum.Parse(toType, value);
				return result;
			}
		}
	}
}
