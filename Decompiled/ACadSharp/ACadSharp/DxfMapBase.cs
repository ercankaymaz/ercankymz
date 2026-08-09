using System;
using System.Collections.Generic;
using System.Reflection;
using ACadSharp.Attributes;

namespace ACadSharp;

public abstract class DxfMapBase
{
	public string Name { get; set; }

	public Dictionary<int, DxfProperty> DxfProperties { get; } = new Dictionary<int, DxfProperty>();

	protected static void addClassProperties(DxfMapBase map, Type type, CadObject obj = null)
	{
		foreach (KeyValuePair<int, DxfProperty> item in cadObjectMapDxf(type))
		{
			map.DxfProperties.Add(item.Key, item.Value);
			if (obj != null)
			{
				item.Value.StoredValue = item.Value.GetRawValue(obj);
			}
		}
	}

	protected static IEnumerable<KeyValuePair<int, DxfProperty>> cadObjectMapDxf(Type type)
	{
		PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
		foreach (PropertyInfo p in properties)
		{
			DxfCodeValueAttribute customAttribute = p.GetCustomAttribute<DxfCodeValueAttribute>();
			if (customAttribute != null)
			{
				DxfCode[] valueCodes = customAttribute.ValueCodes;
				foreach (DxfCode dxfCode in valueCodes)
				{
					yield return new KeyValuePair<int, DxfProperty>((int)dxfCode, new DxfProperty((int)dxfCode, p));
				}
			}
		}
	}
}
