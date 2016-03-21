// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace IsTo
{
	public class XInfo
	{
		internal XInfo(object value)
		{
			if(null == value) {
				Init(null);
			} else {
				Init(value.GetType());
			}
		}

		internal XInfo(Type type)
		{
			Init(type);
		}

		private void Init(Type type)
		{
			if(null == type) {
				IsNull = true;
				Category = TypeCategory.Null;
				return;
			}

			IsNull = false;
			Type = type;
			FullName = type.FullName;
			IsValueType = type.IsValueType;
			IsPrimitive = type.IsPrimitive;
			ElementInfos = new List<XInfo>();

			switch(FullName) {
				case "System.String":
					Category = TypeCategory.String;
					break;
				case "System.DateTime":
					Category = TypeCategory.DateTime;
					break;
				case "System.Decimal":
					Category = TypeCategory.Decimal;
					break;
				case "System.Boolean":
					Category = TypeCategory.Boolean;
					break;
				case "System.Char":
					Category = TypeCategory.Char;
					break;
				case "System.Byte":
					Category = TypeCategory.Byte;
					break;
				case "System.SByte":
					Category = TypeCategory.SByte;
					break;
				case "System.Int16":
					Category = TypeCategory.Int16;
					break;
				case "System.UInt16":
					Category = TypeCategory.UInt16;
					break;
				case "System.Int32":
					Category = TypeCategory.Int32;
					break;
				case "System.UInt32":
					Category = TypeCategory.UInt32;
					break;
				case "System.IntPtr":
					Category = TypeCategory.IntPtr;
					break;
				case "stem.UIntPtr":
					Category = TypeCategory.UIntPtr;
					break;
				case "System.Int64":
					Category = TypeCategory.Int64;
					break;
				case "System.UInt64":
					Category = TypeCategory.UInt64;
					break;
				case "System.Single":
					Category = TypeCategory.Single;
					break;
				case "System.Double":
					Category = TypeCategory.Double;
					break;
				case "System.IO.Stream":
					Category = TypeCategory.Stream;
					break;
				case "System.Drawing.Color":
					Category = TypeCategory.Color;
					break;
				//case "Array":
				//case "Enum":
				//case "Interface":
				//case "Class":
				//case "Struct":
				//case "Others":
				default:
					if(type.IsArray || type.Is<IEnumerable>()) {
						Category = TypeCategory.Array;
						break;
					}
					if(type.IsEnum) {
						Category = TypeCategory.Enum;
						break;
					}
					if(type.IsInterface) {
						Category = TypeCategory.Interface;
						break;
					}
					if(type.IsClass) {
						this.Category = TypeCategory.Class;
						break;
					}
					if(
						type.IsValueType
						&&
						!type.IsPrimitive
						&&
						!type.IsClass
						&&
						!type.IsEnum
						) {
						this.Category = TypeCategory.Struct;
						break;
					}

					this.Category = TypeCategory.Others;
					break;
			}

			if(Category == TypeCategory.Array) {
				var elementType = type.GetElementType();
				if(null == elementType) {
					var genericTypes = type.GenericTypeArguments;
					if(null != genericTypes) {
						foreach(var genericType in genericTypes) {
							var info = ToCache.Get(genericType);
							ElementInfos.Add(info);
							IsBytes = info.Category == TypeCategory.Byte;
						}
					} else {
						//
					}
				} else {
					var info = ToCache.Get(elementType);
					ElementInfos.Add(info);
					IsBytes = info.Category == TypeCategory.Byte;
				}
			}
		}

		public bool IsNull { get; private set; }
		public Type Type { get; private set; }
		public string FullName { get; private set; }
		public bool IsValueType { get; private set; }
		public bool IsPrimitive { get; private set; }
		public TypeCategory Category { get; private set; }
		public List<XInfo> ElementInfos { get; private set; }
		public bool IsBytes { get; private set; }

		public override int GetHashCode()
		{
			return FullName.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			try {
				if(IsNull) { return false; }
				var one = (XInfo)obj;
				if(one.IsNull) { return false; }
				return FullName == one.FullName;
			} catch {
				return false;
			}
		}

		internal static readonly Lazy<XInfo> String =
			new Lazy<XInfo>(() => ToCache.Get(typeof(string)));
		internal static readonly Lazy<XInfo> DateTime =
			new Lazy<XInfo>(() => ToCache.Get(typeof(DateTime)));
		internal static readonly Lazy<XInfo> Decimal =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Decimal)));
		internal static readonly Lazy<XInfo> Boolean =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Boolean)));
		internal static readonly Lazy<XInfo> Char =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Char)));
		internal static readonly Lazy<XInfo> Byte =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Byte)));
		internal static readonly Lazy<XInfo> SByte =
			new Lazy<XInfo>(() => ToCache.Get(typeof(SByte)));
		internal static readonly Lazy<XInfo> Int16 =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Int16)));
		internal static readonly Lazy<XInfo> UInt16 =
			new Lazy<XInfo>(() => ToCache.Get(typeof(UInt16)));
		internal static readonly Lazy<XInfo> Int32 =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Int32)));
		internal static readonly Lazy<XInfo> UInt32 =
			new Lazy<XInfo>(() => ToCache.Get(typeof(UInt32)));
		internal static readonly Lazy<XInfo> IntPtr =
			new Lazy<XInfo>(() => ToCache.Get(typeof(IntPtr)));
		internal static readonly Lazy<XInfo> UIntPtr =
			new Lazy<XInfo>(() => ToCache.Get(typeof(UIntPtr)));
		internal static readonly Lazy<XInfo> Int64 =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Int64)));
		internal static readonly Lazy<XInfo> UInt64 =
			new Lazy<XInfo>(() => ToCache.Get(typeof(UInt64)));
		internal static readonly Lazy<XInfo> Single =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Single)));
		internal static readonly Lazy<XInfo> Double =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Double)));
		internal static readonly Lazy<XInfo> Stream =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Stream)));
		internal static readonly Lazy<XInfo> Color =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Color)));
		internal static readonly Lazy<XInfo> Array =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Array)));
		internal static readonly Lazy<XInfo> Enum =
			new Lazy<XInfo>(() => ToCache.Get(typeof(Enum)));
	}
}
