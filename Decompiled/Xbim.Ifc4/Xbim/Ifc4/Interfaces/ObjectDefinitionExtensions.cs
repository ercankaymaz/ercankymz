using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common.Metadata;

namespace Xbim.Ifc4.Interfaces;

public static class ObjectDefinitionExtensions
{
	private const string PredefinedType = "PredefinedType";

	private static ConcurrentDictionary<Type, Func<object, object>> _predefinedGetterDict = new ConcurrentDictionary<Type, Func<object, object>>();

	private static ConcurrentDictionary<Type, (Type, Action<object, object>)> _predefinedSetterDict = new ConcurrentDictionary<Type, (Type, Action<object, object>)>();

	public static string GetPredefinedTypeValue(this IIfcObjectDefinition instance)
	{
		if (instance == null)
		{
			return null;
		}
		return _predefinedGetterDict.GetOrAdd(instance.GetType(), (Type _) => BuildPredefinedTypeGetter(instance))?.Invoke(instance)?.ToString();
	}

	public static bool SetPredefinedTypeValue(this IIfcObjectDefinition instance, string value)
	{
		if (instance == null)
		{
			return false;
		}
		var (enumType, action) = _predefinedSetterDict.GetOrAdd(instance.GetType(), (Type _) => BuildPredefinedTypeSetter(instance));
		if (action != null)
		{
			object enumValue = GetEnumValue(instance, value, enumType);
			if (enumValue != null)
			{
				action(instance, enumValue);
				return true;
			}
		}
		return false;
	}

	public static bool IsPredefinedTypeEnum(this IIfcObjectDefinition instance, string value)
	{
		if (instance == null)
		{
			return false;
		}
		(Type, Action<object, object>) orAdd = _predefinedSetterDict.GetOrAdd(instance.GetType(), (Type _) => BuildPredefinedTypeSetter(instance));
		var (enumType, _) = orAdd;
		if (orAdd.Item2 != null)
		{
			return GetEnumValue(instance, value, enumType) != null;
		}
		return false;
	}

	private static object GetEnumValue(IIfcObjectDefinition instance, string value, Type enumType)
	{
		if (instance == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (enumType != null && !string.IsNullOrEmpty(value))
		{
			try
			{
				if (IsNullable(enumType))
				{
					enumType = Nullable.GetUnderlyingType(enumType);
				}
				return Enum.Parse(enumType, value, ignoreCase: true);
			}
			catch (ArgumentException)
			{
			}
			catch (OverflowException)
			{
			}
		}
		return null;
	}

	private static bool IsNullable(Type type)
	{
		if (type.IsValueType)
		{
			if (type.IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(Nullable<>);
			}
			return false;
		}
		return true;
	}

	private static Func<object, object> BuildPredefinedTypeGetter(IIfcObjectDefinition obj)
	{
		ExpressMetaProperty value = obj.ExpressType.Properties.FirstOrDefault((KeyValuePair<int, ExpressMetaProperty> p) => p.Value.Name == "PredefinedType").Value;
		if (value != null)
		{
			return value.PropertyInfo.GetValue;
		}
		return null;
	}

	private static (Type, Action<object, object>) BuildPredefinedTypeSetter(IIfcObjectDefinition obj)
	{
		ExpressMetaProperty value = obj.ExpressType.Properties.FirstOrDefault((KeyValuePair<int, ExpressMetaProperty> p) => p.Value.Name == "PredefinedType").Value;
		if (value != null)
		{
			return (value.PropertyInfo.PropertyType, value.PropertyInfo.SetValue);
		}
		return (null, null);
	}
}
