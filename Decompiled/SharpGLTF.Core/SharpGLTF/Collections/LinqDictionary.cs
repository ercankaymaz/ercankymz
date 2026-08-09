using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpGLTF.Collections;

public readonly struct LinqDictionary<TKey, TValueIn, TValueOut>(IDictionary<TKey, TValueIn> dict, Converter<TValueOut, TValueIn> inConverter, Converter<TValueIn, TValueOut> outConverter) : IDictionary<TKey, TValueOut>, ICollection<KeyValuePair<TKey, TValueOut>>, IEnumerable<KeyValuePair<TKey, TValueOut>>, IEnumerable
{
	private readonly IDictionary<TKey, TValueIn> _Source = dict;

	private readonly Converter<TValueOut, TValueIn> _InConverter = inConverter;

	private readonly Converter<TValueIn, TValueOut> _OutConverter = outConverter;

	public TValueOut this[TKey key]
	{
		get
		{
			return _OutConverter(_Source[key]);
		}
		set
		{
			_Source[key] = _InConverter(value);
		}
	}

	public ICollection<TKey> Keys => _Source.Keys;

	public ICollection<TValueOut> Values
	{
		get
		{
			Converter<TValueIn, TValueOut> cvt = _OutConverter;
			return _Source.Values.Select((TValueIn item) => cvt(item)).ToList();
		}
	}

	public int Count => _Source.Count;

	public bool IsReadOnly
	{
		get
		{
			throw new InvalidOperationException();
		}
	}

	public bool ContainsKey(TKey key)
	{
		return _Source.ContainsKey(key);
	}

	public bool TryGetValue(TKey key, out TValueOut value)
	{
		if (!_Source.TryGetValue(key, out var value2))
		{
			value = default(TValueOut);
			return false;
		}
		value = _OutConverter(value2);
		return true;
	}

	public IEnumerator<KeyValuePair<TKey, TValueOut>> GetEnumerator()
	{
		Converter<TValueIn, TValueOut> cvt = _OutConverter;
		return _Source.Select((KeyValuePair<TKey, TValueIn> item) => new KeyValuePair<TKey, TValueOut>(item.Key, cvt(item.Value))).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		Converter<TValueIn, TValueOut> cvt = _OutConverter;
		return _Source.Select((KeyValuePair<TKey, TValueIn> item) => new KeyValuePair<TKey, TValueOut>(item.Key, cvt(item.Value))).GetEnumerator();
	}

	public void Add(TKey key, TValueOut value)
	{
		this[key] = value;
	}

	public bool Remove(TKey key)
	{
		return _Source.Remove(key);
	}

	public void Add(KeyValuePair<TKey, TValueOut> item)
	{
		this[item.Key] = item.Value;
	}

	public void Clear()
	{
		_Source.Clear();
	}

	public bool Contains(KeyValuePair<TKey, TValueOut> item)
	{
		throw new NotImplementedException();
	}

	public void CopyTo(KeyValuePair<TKey, TValueOut>[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public bool Remove(KeyValuePair<TKey, TValueOut> item)
	{
		throw new NotImplementedException();
	}
}
