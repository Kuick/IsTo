// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

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
		private static bool TryFromString(
			string value,
			XInfo from,
			XInfo to,
			out object result,
			string format)
		{
			result = GetDefaultValue(to.Category);

			decimal decimalVal;
			var decimalFlag = decimal.TryParse(value, out decimalVal);

			switch(to.Category) {
				case TypeCategory.Array:
					if(to.IsBytes) {
						result = UnicodeEncoding.UTF8.GetBytes(value);
						return true;
					}
					var firstElement = to
						.ElementInfos
						.FirstOrDefault();
					if(
						null != firstElement
						&&
						firstElement.Category
						==
						TypeCategory.Class) {
						if(!IsJson(value)) { return false; }
						result = JsonConvert.DeserializeObject(
							value,
							to.Type
						);
						return true;
					}
					return TryToArray(
						from,
						to,
						value,
						out result,
						format
					);

				case TypeCategory.String:
					result = value;
					return true;

				case TypeCategory.Stream:
					result = new MemoryStream(value.To<byte[]>());
					return true;

				case TypeCategory.Color:
					// TODO: HSL, HSLA

					if(IsHtmlColor(value)) {
						result = ColorTranslator.FromHtml(value);
						return true;
					}

					if(IsNumeric(value)) {
						var argb = value.To<int>();
						result = Color.FromArgb(argb);
						return true;
					}

					int r, g, b, a;
					if(IsRGBColor(value, out r, out g, out b)) {
						result = Color.FromArgb(r, g, b);
						return true;
					}
					if(IsARGBColor(value, out a, out r, out g, out b)) {
						result = Color.FromArgb(a, r, g, b);
						return true;
					}

					KnownColor nc;
					if(value.TryTo<KnownColor>(out nc)) {
						result = Color.FromName(value);
						return true;
					} else {
						return false;
					}

				case TypeCategory.Enum:
					if(decimalFlag) {
						int enuInt;
						if(decimalVal.TryTo<int>(out enuInt)) {
							result = Enum.Parse(
								to.Type,
								enuInt.ToString()
							);
							return true;
						}
					} else {
						result = Enum.Parse(to.Type, value);
						return true;
					}
					return false;

				case TypeCategory.Class:
					if(IsJson(value)) {
						result = JsonConvert.DeserializeObject(
							value,
							to.Type
						);
						return true;
					}
					return false;

				case TypeCategory.DateTime:
					DateTime val;
					if(DateTime.TryParse(value, out val)) {
						result = val;
						return true;
					} else {
						int[] points;
						if(TryParseDate(value, out points)) {
							result = new DateTime(
								points[0],
								points[1],
								points[2],
								points[3],
								points[4],
								points[5],
								points[6]
							);
							return true;
						} else {
							return false;
						}
					}

				case TypeCategory.Boolean:
					if(IsNumeric(value)) {
						var i = value.To<int>();
						result = i > 0;
						return true;
					}

					foreach(var one in IsToConfig.TrueStringArray) {
						if(one.Equals(
							value,
							StringComparison.OrdinalIgnoreCase)) {
							result = true;
							break;
						}
					}
					return true;

				case TypeCategory.Char:
					result = Convert.ToChar(value);
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
