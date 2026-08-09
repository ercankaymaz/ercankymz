using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ACadSharp.Attributes;
using ACadSharp.Tables;

namespace ACadSharp;

public class DxfMap : DxfMapBase
{
	private static readonly ConcurrentDictionary<Type, DxfMap> _cache = new ConcurrentDictionary<Type, DxfMap>();

	public Dictionary<string, DxfClassMap> SubClasses { get; private set; } = new Dictionary<string, DxfClassMap>();

	public static DxfMap Create<T>() where T : CadObject
	{
		return Create(typeof(T));
	}

	internal static DxfMap Create(Type type, string name = null)
	{
		if (tryGetFromCache(type, out var map))
		{
			return map;
		}
		map = new DxfMap();
		bool flag = false;
		DxfNameAttribute customAttribute = type.GetCustomAttribute<DxfNameAttribute>();
		if (string.IsNullOrEmpty(name))
		{
			map.Name = customAttribute?.Name;
		}
		else
		{
			map.Name = name;
		}
		Type type2 = type;
		while (type2 != null)
		{
			DxfSubClassAttribute customAttribute2 = type2.GetCustomAttribute<DxfSubClassAttribute>();
			if (type2.Equals(typeof(DimensionStyle)))
			{
				flag = true;
			}
			if (type2.Equals(typeof(CadObject)))
			{
				DxfMapBase.addClassProperties(map, type2);
				break;
			}
			if (customAttribute2 != null && customAttribute2.IsEmpty)
			{
				DxfMapBase.addClassProperties(map.SubClasses.Last().Value, type2);
				if (customAttribute2.ClassName != null)
				{
					map.SubClasses.Add(customAttribute2.ClassName, new DxfClassMap(customAttribute2.ClassName));
				}
			}
			else if (type2.GetCustomAttribute<DxfSubClassAttribute>() != null)
			{
				DxfClassMap dxfClassMap = new DxfClassMap();
				dxfClassMap.Name = customAttribute2.ClassName;
				DxfMapBase.addClassProperties(dxfClassMap, type2);
				map.SubClasses.Add(dxfClassMap.Name, dxfClassMap);
			}
			type2 = type2.BaseType;
		}
		if (flag)
		{
			map.DxfProperties.Add(105, map.DxfProperties[5]);
			map.DxfProperties.Remove(5);
		}
		map.SubClasses = new Dictionary<string, DxfClassMap>(map.SubClasses.Reverse().ToDictionary((KeyValuePair<string, DxfClassMap> o) => o.Key, (KeyValuePair<string, DxfClassMap> o) => o.Value));
		_cache.TryAdd(type, map);
		tryGetFromCache(type, out map);
		return map;
	}

	public static void ClearCache()
	{
		_cache.Clear();
	}

	public override string ToString()
	{
		return "DxfMap:" + base.Name;
	}

	private static bool tryGetFromCache(Type type, out DxfMap map)
	{
		map = null;
		if (_cache.TryGetValue(type, out var value))
		{
			map = new DxfMap();
			map.Name = value.Name;
			foreach (KeyValuePair<int, DxfProperty> dxfProperty in value.DxfProperties)
			{
				map.DxfProperties.Add(dxfProperty.Key, dxfProperty.Value);
			}
			foreach (KeyValuePair<string, DxfClassMap> subClass in value.SubClasses)
			{
				map.SubClasses.Add(subClass.Key, subClass.Value);
			}
			return true;
		}
		return false;
	}
}
