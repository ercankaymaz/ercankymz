using System;

namespace Microsoft.Isam.Esent.Interop;

internal static class BoxedValueCache<T> where T : struct, IEquatable<T>
{
	private const int NumCachedBoxedValues = 257;

	private static readonly object[] BoxedValues = new object[257];

	public static object GetBoxedValue(T? value)
	{
		if (!value.HasValue)
		{
			return null;
		}
		T value2 = value.Value;
		int num = (value2.GetHashCode() & 0x7FFFFFFF) % 257;
		object obj = BoxedValues[num];
		if (obj == null || !((T)obj/*cast due to constrained. prefix*/).Equals(value2))
		{
			obj = value2;
			BoxedValues[num] = obj;
		}
		return obj;
	}
}
