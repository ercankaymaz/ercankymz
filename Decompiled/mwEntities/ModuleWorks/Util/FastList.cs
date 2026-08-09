using System;
using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks.Util;

[Serializable]
[Obsolete("Deprecated since Release 2018.04.")]
public class FastList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private T[] m_array;

	private int m_count;

	internal int modifycount { get; private set; }

	public T[] InternalArray => m_array;

	public int Count => m_count;

	public T this[int index]
	{
		get
		{
			return m_array[index];
		}
		set
		{
			m_array[index] = value;
		}
	}

	public bool IsReadOnly => false;

	public FastList()
		: this(100)
	{
	}

	public FastList(int capacity)
	{
		m_array = new T[capacity];
		m_count = 0;
	}

	public void Add(IEnumerable<T> elements)
	{
		foreach (T element in elements)
		{
			Add(element);
		}
	}

	public void Add(T element)
	{
		if (m_count == m_array.Length)
		{
			Array.Resize(ref m_array, m_array.Length * 2);
		}
		m_array[m_count++] = element;
		int num = modifycount + 1;
		modifycount = num;
	}

	public void Add(T element1, T element2)
	{
		Add(element1);
		Add(element2);
	}

	public void Add(T element1, T element2, T element3)
	{
		Add(element1);
		Add(element2);
		Add(element3);
	}

	public void Add(T element1, T element2, T element3, T element4)
	{
		Add(element1);
		Add(element2);
		Add(element3);
		Add(element4);
	}

	public void Clear()
	{
		m_count = 0;
		int num = modifycount + 1;
		modifycount = num;
	}

	public bool Contains(T element)
	{
		return IndexOf(element) >= 0;
	}

	public int IndexOf(T element)
	{
		for (int i = 0; i != m_count; i++)
		{
			if (m_array[i].Equals(element))
			{
				return i;
			}
		}
		return -1;
	}

	public bool Remove(T element)
	{
		int num = modifycount + 1;
		modifycount = num;
		int num2 = IndexOf(element);
		if (num2 >= 0)
		{
			RemoveAt(num2, 1);
			return true;
		}
		return false;
	}

	public void RemoveAt(int index)
	{
		RemoveAt(index, 1);
	}

	public void RemoveAt(int index, int nItems)
	{
		int num = modifycount + 1;
		modifycount = num;
		RangeCheck(index);
		RangeCheck(index + nItems - 1);
		for (int i = index; i != m_count - nItems; i++)
		{
			m_array[i] = m_array[i + nItems];
		}
		m_count -= nItems;
	}

	private void RangeCheck(int index)
	{
		if (index < 0 || index >= m_count)
		{
			throw new IndexOutOfRangeException();
		}
	}

	public void Insert(int index, T item)
	{
		int num = modifycount + 1;
		modifycount = num;
		List<T> list = new List<T>(this);
		list.Insert(index, item);
		Clear();
		Add(list);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException();
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (Count + arrayIndex > array.Length)
		{
			throw new ArgumentException();
		}
		Array.Copy(m_array, 0, array, arrayIndex, Count);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return new FastListEnumerator<T>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
