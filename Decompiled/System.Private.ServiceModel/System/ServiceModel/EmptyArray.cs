using System.Collections.Generic;

namespace System.ServiceModel;

internal static class EmptyArray<T>
{
	internal static T[] Allocate(int n)
	{
		if (n == 0)
		{
			return Array.Empty<T>();
		}
		return new T[n];
	}

	internal static T[] ToArray(IList<T> collection)
	{
		if (collection.Count == 0)
		{
			return Array.Empty<T>();
		}
		T[] array = new T[collection.Count];
		collection.CopyTo(array, 0);
		return array;
	}

	internal static T[] ToArray(SynchronizedCollection<T> collection)
	{
		lock (collection.SyncRoot)
		{
			return ToArray((IList<T>)collection);
		}
	}
}
