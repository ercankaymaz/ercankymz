using System;
using System.Collections.Generic;

internal class _003CM_System_Linq_Enumerable_AggregateBy__3_System_Collections_Generic_IEnumerable___0__System_Func___0___1____2_System_Func___2___0___2__System_Collections_Generic_IEqualityComparer___1___g_003EF77FC9F9100F71522FFC008D4FF7C92E24FD25102F14A9A9D395B7B2E8AE69A5A__Helpers
{
	public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateByIterator<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer) where TKey : notnull
	{
		using (IEnumerator<TSource> enumerator = source.GetEnumerator())
		{
			if (!enumerator.MoveNext())
			{
				yield break;
			}
			foreach (KeyValuePair<TKey, TAccumulate> item in PopulateDictionary(enumerator, keySelector, seed, func, keyComparer))
			{
				yield return item;
			}
		}
		static Dictionary<TKey, TAccumulate> PopulateDictionary(IEnumerator<TSource> enumerator3, Func<TSource, TKey> func2, TAccumulate val, Func<TAccumulate, TSource, TAccumulate> func3, IEqualityComparer<TKey>? comparer)
		{
			Dictionary<TKey, TAccumulate> dictionary = new Dictionary<TKey, TAccumulate>(comparer);
			do
			{
				TSource current = enumerator3.Current;
				TKey key = func2(current);
				TAccumulate value;
				bool flag = dictionary.TryGetValue(key, out value);
				dictionary[key] = func3(flag ? value : val, current);
			}
			while (enumerator3.MoveNext());
			return dictionary;
		}
	}
}
