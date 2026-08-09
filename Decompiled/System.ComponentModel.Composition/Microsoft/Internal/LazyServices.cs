using System;

namespace Microsoft.Internal;

internal static class LazyServices
{
	public static T GetNotNullValue<T>(this Lazy<T> lazy, string argument) where T : class
	{
		ArgumentNullException.ThrowIfNull(lazy, "lazy");
		T value = lazy.Value;
		if (value == null)
		{
			throw new InvalidOperationException(System.SR.Format(System.SR.LazyServices_LazyResolvesToNull, typeof(T), argument));
		}
		return value;
	}
}
