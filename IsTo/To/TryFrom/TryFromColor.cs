// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.Drawing;

namespace IsTo
{
	public static partial class ToExtender
	{
		private static bool TryFromColor(
			Color value,
			XInfo from,
			XInfo to,
			out object result,
			string format)
		{
			result = GetDefaultValue(to.Category);

			var i = value.ToArgb();
			var n = value.Name;


			switch(to.Category) {
				case TypeCategory.Array:
					return TryToArray(
						from,
						to,
						value,
						out result,
						format
					);
				case TypeCategory.Color:
					result = value;
					return true;

				case TypeCategory.Enum:
					try {
						result = Enum.Parse(to.Type, n);
						return true;
					} catch { }
					try {
						result = Enum.Parse(to.Type, i.ToString());
						return true;
					} catch { }
					return false;

				case TypeCategory.Stream:
				case TypeCategory.String:
					var f = string.IsNullOrEmpty(format)
						? "html" : format.ToLower();
					var s = string.Empty;
					switch(f) {
						case "html":
							s = ColorTranslator.ToHtml(value);
							break;
						case "rgb":
							s = string.Format(
								"rgb({0}, {1}, {2})",
								value.R,
								value.G,
								value.B
							);
							break;
						case "argb":
							s = string.Format(
								"rgba({0}, {1}, {2}, {3}%)",
								value.R,
								value.G,
								value.B,
								value.A
							);
							break;
						case "name":
							s = value.Name;
							break;
						default:
							return false;
					}

					return TryFromString(
						s,
						XInfo.String.Value,
						to,
						out result,
						format
					);

				case TypeCategory.Decimal:
					result = (Decimal)i;
					return NumericCompare(i, result);
				case TypeCategory.Byte:
					checked { result = (Byte)i; }
					return NumericCompare(i, result);
				case TypeCategory.SByte:
					checked { result = (SByte)i; }
					return NumericCompare(i, result);
				case TypeCategory.Int16:
					checked { result = (Int16)i; }
					return NumericCompare(i, result);
				case TypeCategory.UInt16:
					checked { result = (UInt16)i; }
					return NumericCompare(i, result);
				case TypeCategory.Int32:
					result = (Int32)i;
					return NumericCompare(i, result);
				case TypeCategory.UInt32:
					checked { result = (UInt32)i; }
					return NumericCompare(i, result);
				case TypeCategory.Int64:
					result = (Int64)i;
					return NumericCompare(i, result);
				case TypeCategory.UInt64:
					result = (UInt64)i;
					return NumericCompare(i, result);
				case TypeCategory.Single:
					result = (Single)i;
					return NumericCompare(i, result);
				case TypeCategory.Double:
					result = (Double)i;
					return NumericCompare(i, result);

				case TypeCategory.DateTime:
				case TypeCategory.Boolean:
				case TypeCategory.Char:
				case TypeCategory.Class:
				case TypeCategory.Struct:
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
