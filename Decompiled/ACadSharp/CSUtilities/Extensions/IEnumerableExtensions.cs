using System.Collections.Generic;
using System.Linq;

namespace CSUtilities.Extensions;

internal static class IEnumerableExtensions
{
	public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
	{
		return enumerable.GetEnumerator() == null;
	}

	public static Queue<T> ToQueue<T>(this IEnumerable<T> enumerable)
	{
		return new Queue<T>(enumerable);
	}

	public static bool TryGet<T>(this IEnumerable<T> enumerable, int index, out T result)
	{
		if (enumerable.Count() < index)
		{
			result = default(T);
			return false;
		}
		result = enumerable.ElementAt(index);
		return true;
	}

	public static IEnumerable<T> RemoveLastEquals<T>(this IEnumerable<T> enumerable, T element)
	{
		List<T> list = new List<T>(enumerable);
		while (list.Last().Equals(element))
		{
			list.RemoveAt(list.Count - 1);
		}
		return list;
	}
}
