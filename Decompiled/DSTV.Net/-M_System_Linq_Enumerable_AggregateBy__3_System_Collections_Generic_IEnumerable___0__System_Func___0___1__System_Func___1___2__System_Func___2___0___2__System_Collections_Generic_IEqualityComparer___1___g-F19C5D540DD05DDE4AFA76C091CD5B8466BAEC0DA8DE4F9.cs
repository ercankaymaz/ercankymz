using System;
using System.Collections.Generic;

internal class _003CM_System_Linq_Enumerable_AggregateBy__3_System_Collections_Generic_IEnumerable___0__System_Func___0___1__System_Func___1___2__System_Func___2___0___2__System_Collections_Generic_IEqualityComparer___1___g_003EF19C5D540DD05DDE4AFA76C091CD5B8466BAEC0DA8DE4F9542E2200B89FD59FCB__Helpers
{
	public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateByIterator<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer) where TKey : notnull
	{
		using (IEnumerator<TSource> enumerator = source.GetEnumerator())
		{
			if (!enumerator.MoveNext())
			{
				yield break;
			}
			foreach (KeyValuePair<TKey, TAccumulate> item in PopulateDictionary(enumerator, keySelector, seedSelector, func, keyComparer))
			{
				yield return item;
			}
		}
		static Dictionary<TKey, TAccumulate> PopulateDictionary(IEnumerator<TSource> enumerator3, Func<TSource, TKey> func2, Func<TKey, TAccumulate> func4, Func<TAccumulate, TSource, TAccumulate> func3, IEqualityComparer<TKey>? comparer)
		{
			Dictionary<TKey, TAccumulate> dictionary = new Dictionary<TKey, TAccumulate>(comparer);
			do
			{
				TSource current = enumerator3.Current;
				TKey val = func2(current);
				TAccumulate value;
				bool flag = dictionary.TryGetValue(val, out value);
				dictionary[val] = func3(flag ? value : func4(val), current);
			}
			while (enumerator3.MoveNext());
			return dictionary;
		}
	}
}
