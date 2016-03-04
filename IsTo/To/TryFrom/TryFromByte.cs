// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace IsTo
{
	public static partial class ToExtender
	{
		private static bool TryFromByte(
			byte value,
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
				case TypeCategory.Byte:
					result = value;
					return true;

				case TypeCategory.Stream:
					var bytes = BitConverter.GetBytes(value);
					result = new MemoryStream(bytes);
					return true;

				case TypeCategory.String:
					var input = UnicodeEncoding.UTF8.GetString(
						new[] { value }
					);
					return TryFromString(
						input,
						XInfo.String.Value,
						to,
						out result,
						format
					);

				case TypeCategory.Enum:
					result = Enum.Parse(to.Type, value.To<string>());
					return true;

				case TypeCategory.Char:
					result = Convert.ToChar(value);
					return true;

				case TypeCategory.Boolean:
					result = value > 0;
					return true;

				case TypeCategory.Decimal:
					result = (Decimal)value;
					return true;
				case TypeCategory.SByte:
					checked { result = (SByte)value; }
					return true;
				case TypeCategory.Int16:
					result = (Int16)value;
					return true;
				case TypeCategory.UInt16:
					checked { result = (UInt16)value; }
					return true;
				case TypeCategory.Int32:
					result = (Int32)value;
					return true;
				case TypeCategory.UInt32:
					checked { result = (UInt32)value;}
					return true;
				case TypeCategory.Int64:
					result = (Int64)value;
					return true;
				case TypeCategory.UInt64:
					checked { result = (UInt64)value;}
					return true;
				case TypeCategory.Single:
					result = (Single)value;
					return true;
				case TypeCategory.Double:
					result = (Double)value;
					return true;
				case TypeCategory.Color:
					result = Color.FromArgb((Int32)value);
					return true;

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
