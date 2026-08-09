using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public static class SessionClientExtensions
{
	internal static IEnumerable<C> Batch<T, C>(this C collection, uint batchSize) where C : List<T>, new()
	{
		if (collection.Count < batchSize || batchSize == 0)
		{
			yield return collection;
			yield break;
		}
		C val = new C
		{
			Capacity = (int)batchSize
		};
		foreach (T item in collection)
		{
			val.Add(item);
			if (val.Count == batchSize)
			{
				yield return val;
				val = new C
				{
					Capacity = (int)batchSize
				};
			}
		}
		if (val.Count > 0)
		{
			yield return val;
		}
	}
}
