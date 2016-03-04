// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.ComponentModel;

namespace IsTo
{
	public static partial class ToExtender
	{
		private static bool TryFromClass(
			object value,
			XInfo from,
			XInfo to,
			out object result,
			string format)
		{
			result = GetDefaultValue(to.Category);

			switch(to.Category) {
				case TypeCategory.Array:
					return TryToArray(
						from,
						to,
						value,
						out result,
						format
					);
				case TypeCategory.Class:
					if(from.Equals(to)) {
						result = value;
						return true;
					}

					var underlyingType = Nullable.GetUnderlyingType(
						to.Type
					);
					var converter = underlyingType == null
						? TypeDescriptor.GetConverter(to.Type)
						: TypeDescriptor.GetConverter(underlyingType);
					if(null != converter) {
						try {
							result = converter.ConvertFrom(value);
							return true;
						} catch(Exception ex) {
							//
						}
					}
					result = ForceClone(value, to.Type);
					return true;

				case TypeCategory.Struct:
					var dic = GetValues(value);
					result = SetValues(dic, to.Type);
					return true;

				case TypeCategory.Enum:
				case TypeCategory.Interface:
				case TypeCategory.Stream:
				case TypeCategory.Color:
				case TypeCategory.String:
				case TypeCategory.DateTime:
				case TypeCategory.Decimal:
				case TypeCategory.Boolean:
				case TypeCategory.Char:
				case TypeCategory.Byte:
				case TypeCategory.SByte:
				case TypeCategory.Int16:
				case TypeCategory.UInt16:
				case TypeCategory.Int32:
				case TypeCategory.UInt32:
				case TypeCategory.IntPtr:
				case TypeCategory.UIntPtr:
				case TypeCategory.Int64:
				case TypeCategory.UInt64:
				case TypeCategory.Single:
				case TypeCategory.Double:
				case TypeCategory.Null:
				case TypeCategory.Others:
				default:
					return false;
			}
		}
	}
}
