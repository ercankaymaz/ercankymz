using System;
using System.Collections.Generic;

internal class _003CM_System_Linq_Enumerable_CountBy__2_System_Collections_Generic_IEnumerable___0__System_Func___0___1__System_Collections_Generic_IEqualityComparer___1___g_003EFECF92F9078377704675FEFB662C59BD73FEF3D9DD56494C8CBF866F0D3FC09DA__Helpers
{
	public static IEnumerable<KeyValuePair<TKey, int>> CountByIterator<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? keyComparer) where TKey : notnull
	{
		using IEnumerator<TSource> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			yield break;
		}
		foreach (KeyValuePair<TKey, int> item in BuildCountDictionary(enumerator, keySelector, keyComparer))
		{
			yield return item;
		}
	}

	public static Dictionary<TKey, int> BuildCountDictionary<TSource, TKey>(IEnumerator<TSource> enumerator, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? keyComparer) where TKey : notnull
	{
		Dictionary<TKey, int> dictionary = new Dictionary<TKey, int>(keyComparer);
		do
		{
			TSource current = enumerator.Current;
			TKey key = keySelector(current);
			if (dictionary.TryGetValue(key, out var value))
			{
				dictionary[key] = checked(value + 1);
			}
			else
			{
				dictionary[key] = 1;
			}
		}
		while (enumerator.MoveNext());
		return dictionary;
	}
}
