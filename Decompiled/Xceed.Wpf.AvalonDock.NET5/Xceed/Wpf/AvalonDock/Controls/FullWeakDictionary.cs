using System;
using System.Collections.Generic;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class FullWeakDictionary<K, V> where K : class
{
	private List<WeakReference> _keys = new List<WeakReference>();

	private List<WeakReference> _values = new List<WeakReference>();

	public V this[K key]
	{
		get
		{
			if (!GetValue(key, out var value))
			{
				throw new ArgumentException();
			}
			return value;
		}
		set
		{
			SetValue(key, value);
		}
	}

	public bool ContainsKey(K key)
	{
		CollectGarbage();
		return -1 != _keys.FindIndex((WeakReference k) => k.GetValueOrDefault<K>() == key);
	}

	public void SetValue(K key, V value)
	{
		CollectGarbage();
		int num = _keys.FindIndex((WeakReference k) => k.GetValueOrDefault<K>() == key);
		if (num > -1)
		{
			_values[num] = new WeakReference(value);
			return;
		}
		_values.Add(new WeakReference(value));
		_keys.Add(new WeakReference(key));
	}

	public bool GetValue(K key, out V value)
	{
		CollectGarbage();
		int num = _keys.FindIndex((WeakReference k) => k.GetValueOrDefault<K>() == key);
		value = default(V);
		if (num == -1)
		{
			return false;
		}
		value = _values[num].GetValueOrDefault<V>();
		return true;
	}

	private void CollectGarbage()
	{
		int num = 0;
		do
		{
			num = _keys.FindIndex(num, (WeakReference k) => !k.IsAlive);
			if (num >= 0)
			{
				_keys.RemoveAt(num);
				_values.RemoveAt(num);
			}
		}
		while (num >= 0);
		num = 0;
		do
		{
			num = _values.FindIndex(num, (WeakReference v) => !v.IsAlive);
			if (num >= 0)
			{
				_values.RemoveAt(num);
				_keys.RemoveAt(num);
			}
		}
		while (num >= 0);
	}
}
