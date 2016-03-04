// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-03-04 - Creation

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace IsTo
{
	public static partial class ToExtender
	{
		private static bool TryFromStruct(
			object value,
			XInfo from,
			XInfo to,
			out object result,
			string format)
		{
			result = GetDefaultValue(to.Category);

			var str = value.ToString();

			if(from.Equals(to)) {
				result = value;
				return true;
			}

			switch(to.Category) {
				case TypeCategory.Struct:
				case TypeCategory.Class:
					var dic = GetValues(value);
					result = SetValues(dic, to.Type);
					return true;

				case TypeCategory.Array:
				case TypeCategory.String:
				case TypeCategory.Stream:
				case TypeCategory.Color:
				case TypeCategory.Enum:
				case TypeCategory.DateTime:
				case TypeCategory.Boolean:
				case TypeCategory.Char:
				case TypeCategory.Decimal:
				case TypeCategory.Byte:
				case TypeCategory.SByte:
				case TypeCategory.Int16:
				case TypeCategory.UInt16:
				case TypeCategory.Int32:
				case TypeCategory.UInt32:
				case TypeCategory.Int64:
				case TypeCategory.UInt64:
				case TypeCategory.Single:
				case TypeCategory.Double:
					return TryFromString(
						str,
						from,
						to,
						out result,
						format
					);

				case TypeCategory.Interface:
				case TypeCategory.IntPtr:
				case TypeCategory.UIntPtr:
				case TypeCategory.Null:
				case TypeCategory.Others:
				default:
					return false;
			}
		}
	}
}
