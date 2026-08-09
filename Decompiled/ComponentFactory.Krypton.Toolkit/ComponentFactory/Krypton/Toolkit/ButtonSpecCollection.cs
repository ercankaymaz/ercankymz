#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecCollection<T> : ButtonSpecCollectionBase, IList, ICollection, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T> where T : ButtonSpec
{
	private List<T> _specs;

	public bool IsFixedSize => false;

	object IList.this[int index]
	{
		get
		{
			return _specs[index];
		}
		set
		{
			throw new NotImplementedException("Cannot set a collection index with a new value");
		}
	}

	public T this[int index]
	{
		get
		{
			return _specs[index];
		}
		set
		{
			throw new NotImplementedException("Cannot set a collection index with a new value");
		}
	}

	public T this[string uniqueName]
	{
		get
		{
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					if (current.UniqueName == uniqueName)
					{
						return current;
					}
				}
			}
			using (IEnumerator<T> enumerator2 = GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					T current2 = enumerator2.Current;
					if (current2.Text == uniqueName)
					{
						return current2;
					}
				}
			}
			return null;
		}
	}

	public int Count => _specs.Count;

	public bool IsReadOnly => false;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public ButtonSpecCollection(object owner)
		: base(owner)
	{
		_specs = new List<T>(6);
	}

	public override string ToString()
	{
		return Count + " Instances";
	}

	public int Add(object value)
	{
		Add(value as T);
		return Count - 1;
	}

	public void AddRange(T[] array)
	{
		foreach (T item in array)
		{
			Add(item);
		}
	}

	public bool Contains(object value)
	{
		return Contains(value as T);
	}

	public int IndexOf(object value)
	{
		return IndexOf(value as T);
	}

	public void Insert(int index, object value)
	{
		Insert(index, value as T);
	}

	public void Remove(object value)
	{
		Remove(value as T);
	}

	public int IndexOf(T item)
	{
		Debug.Assert(item != null);
		return _specs.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		Debug.Assert(item != null);
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (_specs.Contains(item))
		{
			throw new ArgumentOutOfRangeException("item", "T already in collection");
		}
		OnInserting(new ButtonSpecEventArgs(item, index));
		_specs.Insert(index, item);
		OnInserted(new ButtonSpecEventArgs(item, index));
	}

	public void RemoveAt(int index)
	{
		T spec = this[index];
		OnRemoving(new ButtonSpecEventArgs(spec, index));
		_specs.RemoveAt(index);
		OnRemoved(new ButtonSpecEventArgs(spec, index));
	}

	public void Add(T item)
	{
		Debug.Assert(item != null);
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (_specs.Contains(item))
		{
			throw new ArgumentOutOfRangeException("item", "T already in collection");
		}
		OnInserting(new ButtonSpecEventArgs(item, _specs.Count));
		_specs.Add(item);
		OnInserted(new ButtonSpecEventArgs(item, _specs.Count - 1));
	}

	public bool Contains(T item)
	{
		Debug.Assert(item != null);
		return _specs.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		Debug.Assert(array != null);
		_specs.CopyTo(array, arrayIndex);
	}

	public bool Remove(T item)
	{
		Debug.Assert(item != null);
		int index = IndexOf(item);
		OnRemoving(new ButtonSpecEventArgs(item, index));
		bool result = _specs.Remove(item);
		OnRemoved(new ButtonSpecEventArgs(item, index));
		return result;
	}

	public void CopyTo(Array array, int index)
	{
		Debug.Assert(array != null);
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			array.SetValue(current, index++);
		}
	}

	public void Clear()
	{
		for (int num = Count - 1; num >= 0; num--)
		{
			RemoveAt(num);
		}
	}

	public override IEnumerable Enumerate()
	{
		return this;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _specs.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _specs.GetEnumerator();
	}
}
