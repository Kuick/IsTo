// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.IO;

namespace IsTo
{
	public static partial class ToExtender
	{
		private static bool TryFromBoolean(
			bool value,
			XInfo from,
			XInfo to,
			out object result,
			string format)
		{
			result = GetDefaultValue(to.Category);

			switch(to.Category) {
				case TypeCategory.Array:
					if(to.IsBytes) {
						result = BitConverter.GetBytes(value);
						return true;
					}
					return TryToArray(
						from,
						to,
						value,
						out result,
						format
					);
				case TypeCategory.Boolean:
					result = value;
					return true;

				case TypeCategory.Stream:
					var bytes = BitConverter.GetBytes(value);
					result = new MemoryStream(bytes);
					return true;

				case TypeCategory.String:
					return TryFromString(
						value.ToString(),
						XInfo.String.Value,
						to,
						out result,
						format
					);

				case TypeCategory.Char:
					result = Convert.ToChar(value);
					return true;

				case TypeCategory.Decimal:
					result = (Decimal)(value ? 1 : 0);
					return true;
				case TypeCategory.Byte:
					result = (Byte)(value ? 1 : 0);
					return true;
				case TypeCategory.SByte:
					result = (SByte)(value ? 1 : 0);
					return true;
				case TypeCategory.Int16:
					result = (Int16)(value ? 1 : 0);
					return true;
				case TypeCategory.UInt16:
					result = (UInt16)(value ? 1 : 0);
					return true;
				case TypeCategory.Int32:
					result = (Int32)(value ? 1 : 0);
					return true;
				case TypeCategory.UInt32:
					result = (UInt32)(value ? 1 : 0);
					return true;
				case TypeCategory.Int64:
					result = (Int64)(value ? 1 : 0);
					return true;
				case TypeCategory.UInt64:
					result = (UInt64)(value ? 1 : 0);
					return true;
				case TypeCategory.Single:
					result = (Single)(value ? 1 : 0);
					return true;
				case TypeCategory.Double:
					result = (Double)(value ? 1 : 0);
					return true;

				case TypeCategory.Enum:
				case TypeCategory.Interface:
				case TypeCategory.Class:
				case TypeCategory.Struct:
				case TypeCategory.Color:
				case TypeCategory.DateTime:
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
