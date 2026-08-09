using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UglyToad.PdfPig.Util;

internal sealed class StackDictionary<K, V> where K : notnull
{
	private readonly List<Dictionary<K, V>> values = new List<Dictionary<K, V>>();

	public V this[K key]
	{
		get
		{
			if (values.Count == 0)
			{
				throw new InvalidOperationException("Cannot get item from empty stack, call Push before use.");
			}
			if (TryGetValue(key, out var result))
			{
				return result;
			}
			throw new KeyNotFoundException($"No item with key {key} in stack.");
		}
		set
		{
			if (values.Count == 0)
			{
				throw new InvalidOperationException("Cannot set item in empty stack, call Push before use.");
			}
			values[values.Count - 1][key] = value;
		}
	}

	public bool TryGetValue(K key, [NotNullWhen(true)] out V result)
	{
		if (values.Count == 0)
		{
			result = default(V);
			return false;
		}
		for (int num = values.Count - 1; num >= 0; num--)
		{
			if (values[num].TryGetValue(key, out result))
			{
				return true;
			}
		}
		result = default(V);
		return false;
	}

	public void Push()
	{
		values.Add(new Dictionary<K, V>());
	}

	public void Pop()
	{
		if (values.Count == 0)
		{
			throw new InvalidOperationException("Cannot pop empty stacked dictionary.");
		}
		values.RemoveAt(values.Count - 1);
	}
}
