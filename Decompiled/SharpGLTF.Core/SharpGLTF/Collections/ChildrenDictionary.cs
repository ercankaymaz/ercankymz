using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Reflection;

namespace SharpGLTF.Collections;

[DebuggerDisplay("{Count}")]
public sealed class ChildrenDictionary<T, TParent> : IReadOnlyDictionary<string, T>, IEnumerable<KeyValuePair<string, T>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, T>>, IDictionary<string, T>, ICollection<KeyValuePair<string, T>>, IReflectionObject where T : class, IChildOfDictionary<TParent> where TParent : class
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly TParent _Parent;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private Dictionary<string, T> _Collection;

	IEnumerable<string> IReadOnlyDictionary<string, T>.Keys => Keys;

	public ICollection<string> Keys
	{
		get
		{
			if (_Collection != null)
			{
				return _Collection.Keys;
			}
			return Array.Empty<string>();
		}
	}

	IEnumerable<T> IReadOnlyDictionary<string, T>.Values => Values;

	public ICollection<T> Values
	{
		get
		{
			if (_Collection != null)
			{
				return _Collection.Values;
			}
			return Array.Empty<T>();
		}
	}

	public int Count
	{
		get
		{
			if (_Collection != null)
			{
				return _Collection.Count;
			}
			return 0;
		}
	}

	public bool IsReadOnly => false;

	public T this[string key]
	{
		get
		{
			if (!TryGetValue(key, out var value))
			{
				throw new KeyNotFoundException();
			}
			return value;
		}
		set
		{
			Add(key, value);
		}
	}

	public ChildrenDictionary(TParent parent)
	{
		Guard.NotNull(parent, "parent");
		_Parent = parent;
	}

	public void Clear()
	{
		if (_Collection == null)
		{
			return;
		}
		foreach (KeyValuePair<string, T> item in _Collection)
		{
			item.Value.SetLogicalParent(null, null);
		}
		_Collection = null;
	}

	public void Add(string key, T value)
	{
		_VerifyIsOrphan(value);
		if (_Collection == null)
		{
			_Collection = new Dictionary<string, T>();
		}
		Remove(key);
		if (value != null)
		{
			value.SetLogicalParent(_Parent, key);
			_Collection[key] = value;
		}
	}

	public bool Remove(string key)
	{
		if (_Collection == null)
		{
			return false;
		}
		if (!_Collection.TryGetValue(key, out var value))
		{
			return false;
		}
		value?.SetLogicalParent(null, null);
		bool result = _Collection.Remove(key);
		if (_Collection.Count == 0)
		{
			_Collection = null;
		}
		return result;
	}

	public bool ContainsKey(string key)
	{
		if (_Collection == null)
		{
			return false;
		}
		return _Collection.ContainsKey(key);
	}

	public bool TryGetValue(string key, out T value)
	{
		if (_Collection == null)
		{
			value = null;
			return false;
		}
		return _Collection.TryGetValue(key, out value);
	}

	public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
	{
		IEnumerable<KeyValuePair<string, T>> collection = _Collection;
		IEnumerable<KeyValuePair<string, T>> enumerable = collection ?? Enumerable.Empty<KeyValuePair<string, T>>();
		return enumerable.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		IEnumerable<KeyValuePair<string, T>> collection = _Collection;
		IEnumerable<KeyValuePair<string, T>> enumerable = collection ?? Enumerable.Empty<KeyValuePair<string, T>>();
		return enumerable.GetEnumerator();
	}

	private static void _VerifyIsOrphan(T item)
	{
		Guard.NotNull(item, "item");
		Guard.MustBeNull(item.LogicalParent, "LogicalParent");
		Guard.MustBeNull(item.LogicalKey, "LogicalKey");
	}

	[Conditional("DEBUG")]
	private void _AssertItem(T item, string key)
	{
		TParent val = ((key != null) ? _Parent : null);
	}

	public void Add(KeyValuePair<string, T> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Contains(KeyValuePair<string, T> item)
	{
		return ContainsKey(item.Key);
	}

	public bool Remove(KeyValuePair<string, T> item)
	{
		return Remove(item.Key);
	}

	public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
	{
		if (_Collection == null)
		{
			return;
		}
		foreach (KeyValuePair<string, T> item in _Collection)
		{
			array[arrayIndex++] = item;
		}
	}

	public IEnumerable<FieldInfo> GetFields()
	{
		return this.Select((KeyValuePair<string, T> kvp) => FieldInfo.From(kvp.Key, this, (ChildrenDictionary<T, TParent> dict) => dict[kvp.Key]));
	}

	public bool TryGetField(string name, out FieldInfo value)
	{
		if (TryGetValue(name, out var _))
		{
			value = FieldInfo.From(name, this, (ChildrenDictionary<T, TParent> dict) => dict[name]);
			return true;
		}
		value = default(FieldInfo);
		return false;
	}
}
