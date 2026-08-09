using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization;

internal static class CachedAttributeGetter<T> where T : Attribute
{
	[Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	private static readonly ThreadSafeStore<object, T> TypeAttributeCache = new ThreadSafeStore<object, T>(JsonTypeReflector.GetAttribute<T>);

	[Newtonsoft_002EJson_002ENullableContext(1)]
	[return: Newtonsoft_002EJson_002ENullable(2)]
	public static T GetAttribute(object type)
	{
		return TypeAttributeCache.Get(type);
	}
}
