﻿// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.Drawing;
using System.IO;

namespace IsTo
{
	public static partial class ToExtender
	{
		public static T To<T>(
			this object value)
		{
			return value.To<T>(default(T));
		}

		public static T To<T>(
			this object value,
			T airbag)
		{
			return value.To<T>(default(T), "");
		}

		public static T To<T>(
			this object value,
			T airbag,
			string format)
		{
			T result;
			if(value.TryTo<T>(
				out result,
				format)) {
				return result;
			} else {
				return airbag;
			}
		}

		public static bool TryTo<T>(
			this object value,
			out T result,
			string format = "")
		{
			result = default(T);
			if(null == value) { return false; }

			if(value.Is<T>()) {
				try {
					result = (T)value;
					return true;
				} catch { }
			}

			object val;
			if(TryTo(
				value,
				typeof(T),
				out val, format)) {
				try {
					result = (T)val;
					return true;
				} catch { }
			}

			return false;
		}


		public static object To(
			this object value,
			Type type)
		{
			return value.To(type, string.Empty);
		}


		public static object To(
			this object value,
			Type type,
			string format)
		{
			object result;
			if(TryTo(value, type, out result, format)) {
				return result;
			} else {
				if(type.IsValueType) {
					return Activator.CreateInstance(type);
				} else {
					return null;
				}
			}
		}

		private static bool TryTo(
			object value,
			Type type,
			out object result,
			string format = "")
		{
			result = string.Empty;
			if(null == value || null == type) { return false; }

			var from = new XInfo(value);
			var to = new XInfo(type);

			try {
				switch(from.Category) {
					case TypeCategory.Array:
						return TryFromArray(
							value as Array,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Enum:
						return TryFromEnum(
							value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Interface:
						return TryFromInterface(
							value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Class:
						return TryFromClass(
							value,
							from,
							to,
							out result,
							format
						);

					case TypeCategory.Stream:
						return TryFromStream(
							value as Stream,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Color:
						return TryFromColor(
							(Color)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.String:
						return TryFromString(
							value as string,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.DateTime:
						return TryFromDateTime(
							(DateTime)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Decimal:
						return TryFromDecimal(
							(decimal)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Boolean:
						return TryFromBoolean(
							(bool)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Char:
						return TryFromChar(
							(char)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Byte:
						return TryFromByte(
							(byte)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.SByte:
						return TryFromSByte(
							(sbyte)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Int16:
						return TryFromInt16(
							(short)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.UInt16:
						return TryFromUInt16(
							(ushort)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Int32:
						return TryFromInt32(
							(int)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.UInt32:
						return TryFromUInt32(
							(uint)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.IntPtr:
						return TryFromIntPtr(
							(IntPtr)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.UIntPtr:
						return TryFromUIntPtr(
							(UIntPtr)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Int64:
						return TryFromInt64(
							(long)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.UInt64:
						return TryFromUInt64(
							(ulong)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Single:
						return TryFromSingle(
							(float)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Double:
						return TryFromDouble(
							(double)value,
							from,
							to,
							out result,
							format
						);
					case TypeCategory.Null:
						return false;
					case TypeCategory.Others:
						return false;
					default:
						return false;
				}
			} catch(Exception ex) {
				return false;
			}
		}
	}
}
