using System;
using System.Reflection;

namespace Xbim.IO;

public static class TypeExtensions
{
	public static Type GetItemTypeFromGenericType(this Type genericType)
	{
		while (true)
		{
			if (genericType.GetTypeInfo().IsGenericType || genericType.GetTypeInfo().IsInterface)
			{
				Type[] genericArguments = genericType.GetTypeInfo().GetGenericArguments();
				if (genericArguments.GetUpperBound(0) < 0)
				{
					return null;
				}
				return genericArguments[genericArguments.GetUpperBound(0)];
			}
			if (genericType.GetTypeInfo().BaseType == null)
			{
				break;
			}
			genericType = genericType.GetTypeInfo().BaseType;
		}
		return null;
	}

	public static bool GenericTypeArgumentIsAssignableFrom(this Type genericType, Type assignableType)
	{
		if (genericType.GetTypeInfo().IsGenericType && !genericType.GetTypeInfo().IsGenericTypeDefinition)
		{
			Type[] genericArguments = genericType.GetTypeInfo().GetGenericArguments();
			if (genericArguments.Length != 0)
			{
				return genericArguments[0].GetTypeInfo().IsAssignableFrom(assignableType);
			}
		}
		return false;
	}
}
