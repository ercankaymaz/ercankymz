using System.Collections.Generic;
using System.Linq;

namespace CSUtilities.Extensions;

internal static class QueueExtensions
{
	public static T TryDequeue<T>(this Queue<T> q)
	{
		if (!q.Any())
		{
			return default(T);
		}
		return q.Dequeue();
	}

	public static bool TryDequeue<T>(this Queue<T> q, out T element)
	{
		if (!q.Any())
		{
			element = default(T);
			return false;
		}
		element = q.Dequeue();
		return true;
	}
}
