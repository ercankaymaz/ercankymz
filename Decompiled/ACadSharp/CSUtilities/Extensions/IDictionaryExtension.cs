using System.Collections.Generic;

namespace CSUtilities.Extensions;

public static class IDictionaryExtension
{
	public static bool Remove<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, out TValue value)
	{
		if (dictionary.TryGetValue(key, out value))
		{
			dictionary.Remove(key);
			return true;
		}
		return false;
	}
}
