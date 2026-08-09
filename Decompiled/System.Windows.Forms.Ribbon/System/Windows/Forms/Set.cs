using System.Collections;
using System.Collections.Generic;

namespace System.Windows.Forms;

[Serializable]
public class Set<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
	private readonly Dictionary<T, object> _items = new Dictionary<T, object>();

	public int Count => _items.Count;

	public bool IsReadOnly => false;

	public void Add(T item)
	{
		if (item != null)
		{
			_items[item] = null;
		}
	}

	public void Clear()
	{
		_items.Clear();
	}

	public bool Contains(T item)
	{
		if (item == null)
		{
			return false;
		}
		return _items.ContainsKey(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		_items.Keys.CopyTo(array, arrayIndex);
	}

	public bool Remove(T item)
	{
		if (item == null)
		{
			return false;
		}
		return _items.Remove(item);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _items.Keys.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _items.Keys.GetEnumerator();
	}

	public void AddRange(IEnumerable<T> items)
	{
		if (items == null)
		{
			return;
		}
		foreach (T item in items)
		{
			Add(item);
		}
	}

	public T[] ToArray()
	{
		T[] array = new T[_items.Count];
		CopyTo(array, 0);
		return array;
	}
}
