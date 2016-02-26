// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;

namespace IsTo
{
	public static partial class IsExtender
	{
		public static bool Is<T>(this object value)
		{
			if(null == value) { return false; }

			return typeof(T).IsAssignableFrom(
				value is Type
					? (Type)value
					: value.GetType()
			);
		}

		public static bool Is(this object value, Type type)
		{
			if(null == value) { return false; }
			if(null == type) { return false; }
			return type.IsAssignableFrom(
				value is Type
					? (Type)value
					: value.GetType()
			);
		}
	}
}
