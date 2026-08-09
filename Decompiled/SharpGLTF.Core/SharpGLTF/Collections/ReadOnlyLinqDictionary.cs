using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpGLTF.Collections;

public readonly struct ReadOnlyLinqDictionary<TKey, TValueIn, TValueOut>(IReadOnlyDictionary<TKey, TValueIn> dict, Converter<TValueIn, TValueOut> valConverter) : IReadOnlyDictionary<TKey, TValueOut>, IEnumerable<KeyValuePair<TKey, TValueOut>>, IEnumerable, IReadOnlyCollection<KeyValuePair<TKey, TValueOut>>
{
	private readonly IReadOnlyDictionary<TKey, TValueIn> _Source = dict;

	private readonly Converter<TValueIn, TValueOut> _ValueConverter = valConverter;

	public TValueOut this[TKey key] => _ValueConverter(_Source[key]);

	public IEnumerable<TKey> Keys => _Source.Keys;

	public IEnumerable<TValueOut> Values
	{
		get
		{
			Converter<TValueIn, TValueOut> cvt = _ValueConverter;
			return _Source.Values.Select((TValueIn item) => cvt(item));
		}
	}

	public int Count => _Source.Count;

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
		value = _ValueConverter(value2);
		return true;
	}

	public IEnumerator<KeyValuePair<TKey, TValueOut>> GetEnumerator()
	{
		Converter<TValueIn, TValueOut> cvt = _ValueConverter;
		return _Source.Select((KeyValuePair<TKey, TValueIn> item) => new KeyValuePair<TKey, TValueOut>(item.Key, cvt(item.Value))).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		Converter<TValueIn, TValueOut> cvt = _ValueConverter;
		return _Source.Select((KeyValuePair<TKey, TValueIn> item) => new KeyValuePair<TKey, TValueOut>(item.Key, cvt(item.Value))).GetEnumerator();
	}
}
