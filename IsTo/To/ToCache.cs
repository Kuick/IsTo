// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-03-13 - Creation

using System;
using System.Collections.Concurrent;

namespace IsTo
{
	using CD = ConcurrentDictionary<Type, XInfo>;

	internal class ToCache
	{
		private static CD _Cache = new CD();

		internal static XInfo Get<T>()
		{
			return Get(typeof(T));
		}

		internal static XInfo Get(object value)
		{
			if(null == value) {
				throw new ArgumentNullException("value");
			}

			var type = value is Type
				? (Type)value
				: value.GetType();

			XInfo info;
			if(!_Cache.TryGetValue(type, out info)) {
				info = new XInfo(type);
				_Cache.TryAdd(type, info);
			}
			return info;
		}
	}
}
