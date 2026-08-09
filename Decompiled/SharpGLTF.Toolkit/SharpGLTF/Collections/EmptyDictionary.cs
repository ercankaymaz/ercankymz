using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpGLTF.Collections;

internal sealed class EmptyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
{
	private static readonly EmptyDictionary<TKey, TValue> _Instance;

	public static IReadOnlyDictionary<TKey, TValue> Instance => _Instance;

	public TValue this[TKey key]
	{
		get
		{
			throw new KeyNotFoundException();
		}
	}

	public IEnumerable<TKey> Keys => Enumerable.Empty<TKey>();

	public IEnumerable<TValue> Values => Enumerable.Empty<TValue>();

	public int Count => 0;

	static EmptyDictionary()
	{
		_Instance = new EmptyDictionary<TKey, TValue>();
	}

	private EmptyDictionary()
	{
	}

	public bool ContainsKey(TKey key)
	{
		return false;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		value = default(TValue);
		return false;
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		yield break;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		yield break;
	}
}
