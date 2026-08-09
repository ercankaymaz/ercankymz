using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using ACadSharp.Attributes;

namespace ACadSharp;

public class DxfClassMap : DxfMapBase
{
	private static readonly ConcurrentDictionary<Type, DxfClassMap> _cache = new ConcurrentDictionary<Type, DxfClassMap>();

	public DxfClassMap()
	{
	}

	public DxfClassMap(string name)
	{
		base.Name = name;
	}

	public DxfClassMap(DxfClassMap map)
	{
		base.Name = map.Name;
		foreach (KeyValuePair<int, DxfProperty> dxfProperty in map.DxfProperties)
		{
			base.DxfProperties.Add(dxfProperty.Key, dxfProperty.Value);
		}
	}

	public static DxfClassMap Create<T>() where T : CadObject
	{
		return Create(typeof(T));
	}

	public static DxfClassMap Create<T>(T obj) where T : CadObject
	{
		return Create(typeof(T), null, obj);
	}

	public void ClearCache()
	{
		_cache.Clear();
	}

	public override string ToString()
	{
		return "DxfClassMap:" + base.Name;
	}

	internal static DxfClassMap Create(Type type, string name = null, CadObject obj = null)
	{
		if (_cache.TryGetValue(type, out var value) && obj == null)
		{
			return new DxfClassMap(value);
		}
		value = new DxfClassMap();
		if (string.IsNullOrEmpty(name))
		{
			DxfSubClassAttribute customAttribute = type.GetCustomAttribute<DxfSubClassAttribute>();
			if (customAttribute == null)
			{
				throw new ArgumentException(type.FullName + " is not a dxf subclass");
			}
			value.Name = customAttribute.ClassName;
		}
		else
		{
			value.Name = name;
		}
		DxfMapBase.addClassProperties(value, type, obj);
		DxfSubClassAttribute customAttribute2 = type.BaseType.GetCustomAttribute<DxfSubClassAttribute>();
		if (customAttribute2 != null && customAttribute2.IsEmpty)
		{
			DxfMapBase.addClassProperties(value, type.BaseType, obj);
		}
		_cache.TryAdd(type, value);
		return new DxfClassMap(value);
	}
}
