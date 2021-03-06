﻿// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.IO;

namespace IsTo
{
	public static partial class ToExtender
	{
		private static bool TryFromUInt16(
			ushort value,
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
				case TypeCategory.UInt16:
					result = value;
					return true;

				case TypeCategory.Stream:
					var bytes = BitConverter.GetBytes(value);
					result = new MemoryStream(bytes);
					return true;

				case TypeCategory.Enum:
				case TypeCategory.String:
					var s = value.ToString();
					return TryFromString(
						s,
						XInfo.String.Value,
						to,
						out result,
						format
					);

				case TypeCategory.Char:
					result = Convert.ToChar(value);
					return true;

				case TypeCategory.Boolean:
					result = value > 0;
					return true;

				case TypeCategory.Color:
					var i = (Int32)value;
					return TryFromInt32(
						i,
						XInfo.Int32.Value,
						to,
						out result,
						format
					);

				case TypeCategory.Decimal:
					result = (Decimal)value;
					return NumericCompare(value, result);
				case TypeCategory.Byte:
					checked { result = (Byte)value; }
					return NumericCompare(value, result);
				case TypeCategory.SByte:
					checked {result = (SByte)value;}
					return NumericCompare(value, result);
				case TypeCategory.Int16:
					checked {result = (Int16)value;}
					return NumericCompare(value, result);
				case TypeCategory.Int32:
					result = (Int32)value;
					return NumericCompare(value, result);
				case TypeCategory.UInt32:
					result = (UInt32)value;
					return NumericCompare(value, result);
				case TypeCategory.Int64:
					result = (Int64)value;
					return NumericCompare(value, result);
				case TypeCategory.UInt64:
					result = (UInt64)value;
					return NumericCompare(value, result);
				case TypeCategory.Single:
					result = (Single)value;
					return NumericCompare(value, result);
				case TypeCategory.Double:
					result = (Double)value;
					return NumericCompare(value, result);

				case TypeCategory.Interface:
				case TypeCategory.Class:
				case TypeCategory.Struct:
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
