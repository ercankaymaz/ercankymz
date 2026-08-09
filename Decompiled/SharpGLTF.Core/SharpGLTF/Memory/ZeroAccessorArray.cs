using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpGLTF.Memory;

public readonly struct ZeroAccessorArray<T> : IAccessorArray<T>, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IList<T>, ICollection<T>
{
	private static readonly T _Default;

	public bool IsReadOnly => true;

	public T this[int index]
	{
		get
		{
			return _Default;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public int Count { get; }

	static ZeroAccessorArray()
	{
		_Default = default(T);
		if (typeof(T) == typeof(float[]))
		{
			_Default = (T)(object)Array.Empty<T>();
		}
	}

	public ZeroAccessorArray(int count)
	{
		Count = count;
	}

	public int IndexOf(T item)
	{
		if (Count <= 0 || !item.Equals(_Default))
		{
			return -1;
		}
		return 0;
	}

	public bool Contains(T item)
	{
		if (Count > 0)
		{
			return item.Equals(_Default);
		}
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		for (int i = 0; i < Count; i++)
		{
			array[i + arrayIndex] = default(T);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		return Enumerable.Repeat(_Default, Count).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return Enumerable.Repeat(_Default, Count).GetEnumerator();
	}

	void IList<T>.Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	void IList<T>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<T>.Add(T item)
	{
		throw new NotSupportedException();
	}

	void ICollection<T>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<T>.Remove(T item)
	{
		throw new NotSupportedException();
	}
}
