using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSUtilities.Attributes;

namespace CSUtilities.Extensions;

internal static class EnumExtensions
{
	[Obsolete("Use Type.GetValues()")]
	public static IEnumerable<T> GetValues<T>()
	{
		return Enum.GetValues(typeof(T)).Cast<T>();
	}

	[Obsolete("Use Type.GetNames()")]
	public static IEnumerable<string> GetNames<T>(this T value) where T : Enum
	{
		return from T o in Enum.GetValues(typeof(T))
			select o.ToString();
	}

	public static T GetValueByName<T>(string name)
	{
		return Enum.GetValues(typeof(T)).Cast<T>().FirstOrDefault((T o) => o.ToString() == name);
	}

	public static void AddFlag<T>(this ref T value, T flag) where T : struct, Enum
	{
		Type enumType = getEnumType(Convert.GetTypeCode(value));
		value = (T)Convert.ChangeType(Convert.ToUInt64(value) | Convert.ToUInt64(flag), enumType);
	}

	public static void RemoveFlag<T>(this ref T value, T flag) where T : struct, Enum
	{
		Type enumType = getEnumType(Convert.GetTypeCode(value));
		value = (T)Convert.ChangeType(Convert.ToUInt64(value) & ~Convert.ToUInt64(flag), enumType);
	}

	public static T Parse<T>(this string value, bool ignoreCase = false) where T : Enum
	{
		return (T)Enum.Parse(typeof(T), value, ignoreCase);
	}

	public static T ParseByStringValue<T>(this string value) where T : Enum
	{
		FieldInfo[] fields = typeof(T).GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.TryGetAttribute<StringValueAttribute>(out var attribute) && attribute.Value.Equals(value, StringComparison.InvariantCultureIgnoreCase))
			{
				return (T)Enum.Parse(typeof(T), fieldInfo.Name);
			}
		}
		throw new ArgumentNullException("value");
	}

	public static bool TryParseByStringValue<T>(this string value, out T result) where T : Enum
	{
		FieldInfo[] fields = typeof(T).GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.TryGetAttribute<StringValueAttribute>(out var attribute) && attribute.Value.Equals(value, StringComparison.InvariantCultureIgnoreCase))
			{
				result = (T)Enum.Parse(typeof(T), fieldInfo.Name);
				return true;
			}
		}
		result = default(T);
		return false;
	}

	public static bool TryParse<T>(this string value, out T result, bool ignoreCase = false) where T : struct
	{
		return Enum.TryParse<T>(value, ignoreCase, out result);
	}

	public static string GetStringValue<T>(this T value) where T : Enum
	{
		return value.GetType().GetField(value.ToString()).GetCustomAttribute<StringValueAttribute>()?.Value;
	}

	private static Type getEnumType(TypeCode code)
	{
		return code switch
		{
			TypeCode.Boolean => typeof(bool), 
			TypeCode.Byte => typeof(byte), 
			TypeCode.Char => typeof(char), 
			TypeCode.DateTime => typeof(DateTime), 
			TypeCode.DBNull => typeof(DBNull), 
			TypeCode.Decimal => typeof(decimal), 
			TypeCode.Double => typeof(double), 
			TypeCode.Empty => null, 
			TypeCode.Int16 => typeof(short), 
			TypeCode.Int32 => typeof(int), 
			TypeCode.Int64 => typeof(long), 
			TypeCode.Object => typeof(object), 
			TypeCode.SByte => typeof(sbyte), 
			TypeCode.Single => typeof(float), 
			TypeCode.String => typeof(string), 
			TypeCode.UInt16 => typeof(ushort), 
			TypeCode.UInt32 => typeof(uint), 
			TypeCode.UInt64 => typeof(ulong), 
			_ => null, 
		};
	}
}
