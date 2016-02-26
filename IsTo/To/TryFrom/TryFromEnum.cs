// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;

namespace IsTo
{
	public static partial class ToExtender
	{
		private static bool TryFromEnum(
			object value,
			XInfo from,
			XInfo to,
			out object result,
			string format)
		{
			result = GetDefaultValue(to.Category);

			decimal decimalVal;
			var decimalFlag = decimal.TryParse(
				((int)value).ToString(), 
				out decimalVal
			);

			switch(to.Category) {
				case TypeCategory.Array:
					return TryToArray(
						from,
						to,
						value,
						out result,
						format
					);
				case TypeCategory.Enum:
					if(from.Equals(to)) {
						result = value;
						return true;
					}
					return false;

				case TypeCategory.String:
					result = value.ToString();
					return true;
				case TypeCategory.Stream:
					return TryFromString(
						value.ToString(),
						XInfo.String.Value,
						to,
						out result,
						format
					);

				case TypeCategory.Char:
					result = Convert.ToChar((int)value);
					return true;

				case TypeCategory.Decimal:
					result = decimalVal;
					return decimalFlag;
				case TypeCategory.Byte:
					if(!decimalFlag) { return false; }
					byte byteVal;
					if(decimalVal.TryTo<byte>(out byteVal)) {
						result = byteVal;
						return true;
					} else {
						return false;
					}
				case TypeCategory.SByte:
					if(!decimalFlag) { return false; }
					sbyte sbyteVal;
					if(decimalVal.TryTo<sbyte>(out sbyteVal)) {
						result = sbyteVal;
						return true;
					} else {
						return false;
					}
				case TypeCategory.Int16:
					if(!decimalFlag) { return false; }
					Int16 int16Val;
					if(decimalVal.TryTo<Int16>(out int16Val)) {
						result = int16Val;
						return true;
					} else {
						return false;
					}
				case TypeCategory.UInt16:
					if(!decimalFlag) { return false; }
					UInt16 uint16Val;
					if(decimalVal.TryTo<UInt16>(out uint16Val)) {
						result = uint16Val;
						return true;
					} else {
						return false;
					}
				case TypeCategory.Int32:
					if(!decimalFlag) { return false; }
					Int32 int32Val;
					if(decimalVal.TryTo<Int32>(out int32Val)) {
						result = int32Val;
						return true;
					} else {
						return false;
					}
				case TypeCategory.UInt32:
					if(!decimalFlag) { return false; }
					UInt32 uint32Val;
					if(decimalVal.TryTo<UInt32>(out uint32Val)) {
						result = uint32Val;
						return true;
					} else {
						return false;
					}
				case TypeCategory.Int64:
					if(!decimalFlag) { return false; }
					Int64 int64Val;
					if(decimalVal.TryTo<Int64>(out int64Val)) {
						result = int64Val;
						return true;
					} else {
						return false;
					}
				case TypeCategory.UInt64:
					if(!decimalFlag) { return false; }
					UInt64 uint64Val;
					if(decimalVal.TryTo<UInt64>(out uint64Val)) {
						result = uint64Val;
						return true;
					} else {
						return false;
					}
				case TypeCategory.Single:
					if(!decimalFlag) { return false; }
					Single singleVal;
					if(decimalVal.TryTo<Single>(out singleVal)) {
						result = singleVal;
						return true;
					} else {
						return false;
					}
				case TypeCategory.Double:
					if(!decimalFlag) { return false; }
					Double doubleVal;
					if(decimalVal.TryTo<Double>(out doubleVal)) {
						result = doubleVal;
						return true;
					} else {
						return false;
					}

				case TypeCategory.IntPtr:
				case TypeCategory.UIntPtr:
				case TypeCategory.Interface:
				case TypeCategory.Class:
				case TypeCategory.Color:
				case TypeCategory.DateTime:
				case TypeCategory.Boolean:
				case TypeCategory.Null:
				case TypeCategory.Others:
				default:
					return false;
			}
		}
	}
}
