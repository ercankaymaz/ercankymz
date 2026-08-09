using System;
using System.Reflection;
using Xbim.Common;

namespace Xbim.IO.Parser;

public class Part21Entity
{
	public int EntityLabel;

	public int CurrentParamIndex = -1;

	public IPersist Entity { get; set; }

	public Part21Entity(int label)
	{
		EntityLabel = label;
	}

	public Part21Entity(string label)
	{
		EntityLabel = Convert.ToInt32(label.TrimStart(new char[1] { '#' }));
	}

	public Part21Entity(string label, IPersist ent)
		: this(Convert.ToInt32(label.TrimStart(new char[1] { '#' })), ent)
	{
	}

	public Part21Entity(IPersist ent)
		: this(-1, ent)
	{
	}

	public Part21Entity(int label, IPersist ent)
	{
		EntityLabel = label;
		Entity = ent;
	}

	private void ParameterEater(int i, IPropertyValue v, int[] nestedIndex)
	{
	}

	private Type GetItemTypeFromGenericType(Type genericType)
	{
		if (genericType.GetTypeInfo().IsGenericType || genericType.GetTypeInfo().IsInterface)
		{
			Type[] genericArguments = genericType.GetTypeInfo().GetGenericArguments();
			if (genericArguments.GetUpperBound(0) >= 0)
			{
				return genericArguments[genericArguments.GetUpperBound(0)];
			}
			return null;
		}
		if (genericType.GetTypeInfo().BaseType != null)
		{
			return GetItemTypeFromGenericType(genericType.GetTypeInfo().BaseType);
		}
		return null;
	}
}
