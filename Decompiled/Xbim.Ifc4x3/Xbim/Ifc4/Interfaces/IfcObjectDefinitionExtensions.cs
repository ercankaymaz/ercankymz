using System;
using System.Collections.Concurrent;

namespace Xbim.Ifc4.Interfaces;

public static class IfcObjectDefinitionExtensions
{
	private static ConcurrentDictionary<Type, Enum> UserDefinedEnumCache = new ConcurrentDictionary<Type, Enum>();

	public static TOut GetUserDefined<TOut>(this IIfcObjectDefinition _) where TOut : Enum
	{
		Type typeFromHandle = typeof(TOut);
		Enum orAdd = UserDefinedEnumCache.GetOrAdd(typeFromHandle, GetUserdefined(typeFromHandle));
		if (orAdd == null)
		{
			return default(TOut);
		}
		return (TOut)orAdd;
	}

	private static Enum GetUserdefined(Type enumType)
	{
		try
		{
			return (Enum)Enum.Parse(enumType, "USERDEFINED");
		}
		catch
		{
		}
		return null;
	}
}
