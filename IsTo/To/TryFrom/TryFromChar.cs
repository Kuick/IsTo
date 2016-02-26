// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.IO;

namespace IsTo
{
	public static partial class ToExtender
	{
		private static bool TryFromChar(
			char value,
			XInfo from,
			XInfo to,
			out object result,
			string format)
		{
			result = GetDefaultValue(to.Category);

			var d = (int)value;
			var isNumeric = true;
			var s = value.ToString();

			switch(to.Category) {
				case TypeCategory.Array:
					return TryToArray(
						from,
						to,
						value,
						out result,
						format
					);
				case TypeCategory.Char:
					result = value;
					return true;

				case TypeCategory.Stream:
					var bytes = BitConverter.GetBytes(value);
					result = new MemoryStream(bytes);
					return true;

				case TypeCategory.Enum:
				case TypeCategory.Class:
				case TypeCategory.Color:
				case TypeCategory.String:
				case TypeCategory.DateTime:
					return TryFromString(
						s,
						XInfo.String.Value,
						to,
						out result,
						format
					);

				case TypeCategory.Boolean:
					if(isNumeric) {
						result = d > 0;
						return true;
					}
					return false;

				case TypeCategory.Decimal:
					if(isNumeric) {
						result = (Decimal)d;
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.Byte:
					if(isNumeric) {
						checked { result = (Byte)d; }
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.SByte:
					if(isNumeric) {
						checked { result = (SByte)d; }
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.Int16:
					if(isNumeric) {
						checked { result = (Int16)d; }
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.UInt16:
					if(isNumeric) {
						checked { result = (UInt16)d; }
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.Int32:
					if(isNumeric) {
						result = (Int32)d;
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.UInt32:
					if(isNumeric) {
						checked { result = (UInt32)d; }
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.Int64:
					if(isNumeric) {
						result = (Int64)d;
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.UInt64:
					if(isNumeric) {
						result = (UInt64)d;
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.Single:
					if(isNumeric) {
						result = (Single)d;
						return NumericCompare(d, result);
					}
					return false;
				case TypeCategory.Double:
					if(isNumeric) {
						result = (Double)d;
						return NumericCompare(d, result);
					}
					return false;

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
