using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ReadOnlyList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
{
	private IList<T> m_list;

	public int Count => m_list.Count;

	public bool IsReadOnly => true;

	public T this[int index]
	{
		get
		{
			return m_list[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	bool IList.IsFixedSize => true;

	bool IList.IsReadOnly => true;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			this[index] = (T)value;
		}
	}

	int ICollection.Count => Count;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => false;

	public ReadOnlyList(IList<T> list)
	{
		m_list = list;
		if (m_list == null)
		{
			m_list = Array.Empty<T>();
		}
	}

	public ReadOnlyList(IList<T> list, bool makeCopy)
	{
		if (list != null && makeCopy)
		{
			T[] array = new T[list.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = list[i];
			}
			list = array;
		}
		m_list = list;
		if (m_list == null)
		{
			m_list = Array.Empty<T>();
		}
	}

	public void Add(T item)
	{
		throw new NotSupportedException();
	}

	public void Clear()
	{
		throw new NotSupportedException();
	}

	public bool Contains(T item)
	{
		return m_list.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		m_list.CopyTo(array, arrayIndex);
	}

	public bool Remove(T item)
	{
		throw new NotSupportedException();
	}

	public int IndexOf(T item)
	{
		return m_list.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return m_list.GetEnumerator();
	}

	public IEnumerator<T> GetEnumerator()
	{
		return m_list.GetEnumerator();
	}

	public static ReadOnlyList<T> ToList(T[] values)
	{
		return new ReadOnlyList<T>(values);
	}

	public static implicit operator ReadOnlyList<T>(T[] values)
	{
		return new ReadOnlyList<T>(values);
	}

	int IList.Add(object value)
	{
		throw new NotImplementedException();
	}

	void IList.Clear()
	{
		throw new NotImplementedException();
	}

	bool IList.Contains(object value)
	{
		return Contains((T)value);
	}

	int IList.IndexOf(object value)
	{
		return IndexOf((T)value);
	}

	void IList.Insert(int index, object value)
	{
		throw new NotImplementedException();
	}

	void IList.Remove(object value)
	{
		throw new NotImplementedException();
	}

	void IList.RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

	void ICollection.CopyTo(Array array, int index)
	{
		CopyTo((T[])array, index);
	}
}
