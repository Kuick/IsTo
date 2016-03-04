// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IsTo
{
	public static partial class ToExtender
	{
		private static bool TryParseDate(
			string value, out int[] points)
		{
			points = new int[] { 1, 1, 1, 0, 0, 0, 0 };
			var before = value.StartsWith("-");

			if(string.IsNullOrWhiteSpace(value)) {
				return false;
			} else {
				var parts = value
					.Trim()
					.Split(
						new[] { 'T', '+', '-', '/', ' ', ':', '.' },
						StringSplitOptions.RemoveEmptyEntries
					);
				if(parts.Length > 1) {
					int index = 0;
					for(int i = 0; i < parts.Length; i++) {
						if(string.IsNullOrEmpty(parts[i])) {
							continue;
						}

						if(!IsNumeric(parts[i])) {
							return false;
						}
						points[index] = parts[i].To<int>();
						if(++index > 6) { break; }
					}
					if(before) { points[0] *= -1; }
				} else {
					if(!IsNumeric(value)) { return false; }
					switch(value.Length - (before ? 1 : 0)) {
						case 5: // 1+2+2
							points[0] = value
								.Substring(0 + (before ? 1 : 0), 1)
								.To<int>() * (before ? -1 : 1);
							points[1] = value
								.Substring(1 + (before ? 1 : 0), 2)
								.To<int>();
							points[2] = value
								.Substring(3 + (before ? 1 : 0), 2)
								.To<int>();
							break;
						case 6: // 2+2+2
							points[0] = value
								.Substring(0 + (before ? 1 : 0), 2)
								.To<int>() * (before ? -1 : 1);
							points[1] = value
								.Substring(2 + (before ? 1 : 0), 2)
								.To<int>();
							points[2] = value
								.Substring(4 + (before ? 1 : 0), 2)
								.To<int>();
							break;
						case 7:// 3+2+2
							points[0] = value
								.Substring(0 + (before ? 1 : 0), 3)
								.To<int>() * (before ? -1 : 1);
							points[1] = value
								.Substring(3 + (before ? 1 : 0), 2)
								.To<int>();
							points[2] = value
								.Substring(5 + (before ? 1 : 0), 2)
								.To<int>();
							break;
						case 8:// 4+2+2
							points[0] = value
								.Substring(0 + (before ? 1 : 0), 4)
								.To<int>() * (before ? -1 : 1);
							points[1] = value
								.Substring(4 + (before ? 1 : 0), 2)
								.To<int>();
							points[2] = value
								.Substring(6 + (before ? 1 : 0), 2)
								.To<int>();
							break;
						default:
							return false;
					}
				}
			}
			return true;
		}

		private static bool IsHtmlColor(string value)
		{
			return Regex.IsMatch(
				value,
				IsToConstants.Pattern.HtmlColor,
				RegexOptions.Compiled | RegexOptions.IgnoreCase
			);
		}

		private static bool IsRGBColor(
			string value,
			out int r,
			out int g,
			out int b)
		{
			r = b = g = 0;
			var regex = new Regex(
				IsToConstants.Pattern.RGBColor,
				RegexOptions.Compiled | RegexOptions.IgnoreCase
			);
			var match = regex.Match(value);
			if(match.Success) {
				r = match.Groups["r"].Value.To<int>();
				g = match.Groups["g"].Value.To<int>();
				b = match.Groups["b"].Value.To<int>();

			}
			return
				match.Success
				&&
				0 <= r && r <= 255
				&&
				0 <= g && g <= 255
				&&
				0 <= b && b <= 255;
		}

		private static bool IsARGBColor(
			string value,
			out int a,
			out int r,
			out int g,
			out int b)
		{
			a = r = b = g = 0;
			var regex = new Regex(
				IsToConstants.Pattern.ARGBColor,
				RegexOptions.Compiled | RegexOptions.IgnoreCase
			);
			var match = regex.Match(value);
			if(match.Success) {
				var val = match.Groups["a"].Value;
				var d = 0m;
				if(val.EndsWith("%")) {
					d = val.TrimEnd('%').To<decimal>();
					if(d < 0) { return false; }
					d = (d / 100).To<decimal>();
				} else {
					d = val.To<decimal>();
					if(d < 0) { return false; }
				}
				a = (int)Math.Round((decimal)(d * 255m));
				r = match.Groups["r"].Value.To<int>();
				g = match.Groups["g"].Value.To<int>();
				b = match.Groups["b"].Value.To<int>();

			}
			return
				match.Success
				&&
				0 <= a && a <= 255
				&&
				0 <= r && r <= 255
				&&
				0 <= g && g <= 255
				&&
				0 <= b && b <= 255;
		}

		private static bool IsNumeric(string value)
		{
			return Regex.IsMatch(
				value,
				IsToConstants.Pattern.Numeric,
				RegexOptions.Compiled
			);
		}

		private static bool IsJson(string json)
		{
			json = json.Trim();

			if(
				(json.StartsWith("{") && json.EndsWith("}"))
				||
				(json.StartsWith("[") && json.EndsWith("]"))) {
				// go on
			} else {
				return false;
			}

			try {
				var obj = JToken.Parse(json);
				return true;
			} catch {
				return false;
			}
		}

		private static Dictionary<string, object> GetValues(
			object from)
		{
			var dic = new Dictionary<string, object>();
			if(null == from) { return dic; }

			var type = from.GetType();

			var fields = type.GetFields();
			foreach(var field in fields) {
				var name = field.Name;
				var value = GetValue(field, from);
				dic.Add(name, value);
			}

			var properties = type.GetProperties();
			foreach(var property in properties) {
				var name = property.Name;
				var value = GetValue(property, from);
				dic.Add(name, value);
			}

			return dic;
		}

		private static object SetValues(
			Dictionary<string, object> dic,
			Type type)
		{
			if(null == type) { return null; }
			var to = default(object);
			try {
				to = Activator.CreateInstance(type);
			} catch {
				return null;
			}

			// Field
			var fields = type.GetFields();
			foreach(var field in fields) {
				if(!dic.ContainsKey(field.Name)) {
					continue;
				}
				var value = dic[field.Name];
				SetValue(to, field, value);
			}

			// Property
			var properties = type.GetProperties();
			foreach(var property in properties) {
				if(!dic.ContainsKey(property.Name)) {
					continue;
				}
				var value = dic[property.Name];
				SetValue(to, property, value);
			}

			return to;
		}

		private static object ForceClone(object from, Type type)
		{
			var to = default(object);
			try {
				to = Activator.CreateInstance(type);
			} catch {
				return null;
			}

			// Field
			var fields = type.GetFields();
			foreach(var field in fields) {
				var value = GetValue(field, from);
				if(null == value) {
					value = GetFieldValue(field.Name, from);
				}
				if(null == value) { continue; }
				SetValue(to, field, value);
			}

			// Property
			var properties = type.GetProperties();
			foreach(var property in properties) {
				var value = GetValue(property, from);
				if(null == value) {
					value = GetPropertyValue(property.Name, from);
				}
				if(null == value) { continue; }
				SetValue(to, property, value);
			}

			return to;
		}

		private static object GetPropertyValue(string name, object obj)
		{
			if(null == obj) { return null; }
			var type = obj.GetType();
			var info = type
				.GetProperties()
				.FirstOrDefault(x => x.Name == name);
			return GetValue(info, obj);
		}

		private static object GetValue(PropertyInfo info, object obj)
		{
			try {
				if(null != info) {
					if(!info.CanRead) { return null; }
					return info.GetValue(obj, new object[0]);
				}
			} catch {
				// swallow it
			}
			return null;
		}

		private static object GetFieldValue(string name, object obj)
		{
			if(null == obj) { return null; }
			var type = obj.GetType();
			var info = type
				.GetFields()
				.FirstOrDefault(x => x.Name == name);
			return GetValue(info, obj);
		}

		private static object GetValue(FieldInfo info, object obj)
		{
			try {
				if(null != info) {
					return info.GetValue(obj);
				}
			} catch {
				// swallow it
			}
			return null;
		}

		private static bool SetValue(
			object instance, PropertyInfo info, object val)
		{
			if(!info.CanWrite) { return false; }
			if(null == val) { val = string.Empty; }

			try {
				Type type = info.PropertyType;
				if(type.IsEnum) {
					// Enum
					if(null == val) {
						var field = type
							.GetFields()
							.FirstOrDefault(x => x.IsLiteral);
						if(null != field) { val = field.Name; }
					}
					val = Enum.Parse(type, val.ToString(), true);
				} else {
					val = val.To(type);
				}

				info.SetValue(instance, val, new object[0]);
				return true;
			} catch {
				return false;
			}
		}

		private static void SetValue(
			object instance, FieldInfo info, object val)
		{
			if(null == val) { val = string.Empty; }

			try {
				Type type = info.FieldType;
				if(type.IsEnum) {
					// Enum
					if(null == val) {
						var field = type
							.GetFields()
							.FirstOrDefault(x => x.IsLiteral);
						if(null != field) { val = field.Name; }
					}
					val = Enum.Parse(type, val.ToString(), true);
				} else {
					val = val.To(type);
				}

				info.SetValue(instance, val);
			} catch {
				// swallow it
			}
		}

		private static object GetDefaultValue(TypeCategory category)
		{
			switch(category) {
				case TypeCategory.Array:
					return default(Array);
				case TypeCategory.Enum:
					return default(int);
				case TypeCategory.Interface:
					return default(object);
				case TypeCategory.Class:
					return default(object);
				case TypeCategory.Stream:
					return default(Stream);
				case TypeCategory.Color:
					return default(Color);
				case TypeCategory.String:
					return default(string);
				case TypeCategory.DateTime:
					return default(DateTime);
				case TypeCategory.Decimal:
					return default(decimal);
				case TypeCategory.Boolean:
					return default(bool);
				case TypeCategory.Char:
					return default(char);
				case TypeCategory.Byte:
					return default(byte);
				case TypeCategory.SByte:
					return default(sbyte);
				case TypeCategory.Int16:
					return default(short);
				case TypeCategory.UInt16:
					return default(ushort);
				case TypeCategory.Int32:
					return default(int);
				case TypeCategory.UInt32:
					return default(uint);
				case TypeCategory.IntPtr:
					return default(IntPtr);
				case TypeCategory.UIntPtr:
					return default(UIntPtr);
				case TypeCategory.Int64:
					return default(long);
				case TypeCategory.UInt64:
					return default(ulong);
				case TypeCategory.Single:
					return default(float);
				case TypeCategory.Double:
					return default(double);
				case TypeCategory.Struct:
					return null;
				case TypeCategory.Null:
					return null;
				case TypeCategory.Others:
					return null;
				default:
					return null;
			}
		}

		private static char _NumberDecimalSeparator;
		private static char NumberDecimalSeparator
		{
			get
			{
				if(_NumberDecimalSeparator == default(char)) {
					_NumberDecimalSeparator = NumberFormatInfo
						.CurrentInfo
						.NumberDecimalSeparator.To<Char>();
				}
				return _NumberDecimalSeparator;
			}
		}

		private static bool NumericCompare(
			object value1,
			object value2)
		{
			if(null == value1) { return false; }
			if(null == value2) { return false; }

			var info = NumberFormatInfo.CurrentInfo;

			var val1 = Double.Parse(value1.ToString());
			var v1 = val1.ToString("N2", info);
			if(!IsNumeric(v1)) { return false; }
			var val2 = Double.Parse(value2.ToString());
			var v2 = val2.ToString("N2", info);
			if(!IsNumeric(v2)) { return false; }

			var parts1 = v1.Split(NumberDecimalSeparator);
			var parts2 = v2.Split(NumberDecimalSeparator);
			if(parts1[0] != parts2[0]) { return false; }
			var _1 = parts1.Length == 2 ? Int64.Parse(parts1[1]) : 0;
			var _2 = parts2.Length == 2 ? Int64.Parse(parts2[1]) : 0;
			return _1 == _2;
		}

		private static bool TryToArray(
			XInfo from,
			XInfo to,
			object value,
			out object result,
			string format = "")
		{
			result = null;

			try {
				var elementType = to
					.ElementInfos
					.FirstOrDefault()
					.Type;
				var genericListTypeRunTime = typeof(List<>)
					.MakeGenericType(new[] { elementType });
				var genericList = Activator.CreateInstance(
					genericListTypeRunTime
				);
				var genericListType = genericList.GetType();

				// Add
				var addInfo = genericListType
					.GetMethods()
					.FirstOrDefault(x => x.Name == "Add");
				if(from.Category == TypeCategory.Array) {
					if(to.ElementInfos.Count() == 1) {
						var datas = value as IEnumerable;
						if(null != datas) {
							var en = datas.GetEnumerator();
							while(en.MoveNext()) {
								object val;
								if(TryTo(
									en.Current,
									elementType,
									out val)) {
									addInfo.Invoke(
										genericList,
										new object[] { val }
									);
								} else {
									return false;
								}
							}
						}
					} else {
						//
					}
				} else {
					if(to.ElementInfos.Count() == 1) {
						object val;

						if(value.Is(elementType)) {
							addInfo.Invoke(
								genericList,
								new object[] { value }
							);
						} else {
							if(TryTo(value, elementType, out val)) {
								addInfo.Invoke(
									genericList,
									new object[] { val }
								);
							} else {
								return false;
							}
						}
					} else {
						//
					}
				}

				if(to.Type.FullName == genericListType.FullName) {
					// List
					result = genericList;
				} else if(to.Type.Is<IQueryable>()) {
					// IQueryable
					result = ((IList)genericList).AsQueryable();
				} else if(
					to.Category == TypeCategory.Interface
					&&
					to.Type.Is<IList>()) {
					// IList
					result = (IList)genericList;
				} else {
					// Array
					var toarrayInfo = genericListType
						.GetMethods()
						.FirstOrDefault(x => x.Name == "ToArray");
					if(null == toarrayInfo) { return false; }
					result = toarrayInfo.Invoke(
						genericList,
						new object[] { }
					);
				}

				return true;

			} catch(Exception ex) {
				return false;
			}
		}
	}
}
