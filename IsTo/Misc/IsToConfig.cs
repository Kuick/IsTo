// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System.Collections.Generic;
using System.Linq;

namespace IsTo
{
	public class IsToConfig
	{
		private static object _Lock = new object();
		private static readonly string[] _DefaultTrueStringArray =
			new[] { "1", "t", "y", "true", "yes", "on", "o" };

		private static List<string> _TrueStringArray;
		public static List<string> TrueStringArray
		{
			get
			{
				if(!TrueStringArrayNullOrEmpty) {
					return _TrueStringArray;
				}
				lock(_Lock) {
					if(!TrueStringArrayNullOrEmpty) {
						return _TrueStringArray;
					}
					if(null == _TrueStringArray) {
						_TrueStringArray = new List<string>();
					}
					if(_TrueStringArray.Count() == 0) {
						_TrueStringArray.AddRange(
							_DefaultTrueStringArray
						);
					}
					return _TrueStringArray;
				}
			}
		}

		private static bool TrueStringArrayNullOrEmpty
		{
			get
			{
				return
					null == _TrueStringArray
					||
					_TrueStringArray.Count() == 0;
			}
		}
	}
}
