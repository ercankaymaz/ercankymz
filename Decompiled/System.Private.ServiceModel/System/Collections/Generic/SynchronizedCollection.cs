using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceModel;

namespace System.Collections.Generic;

[ComVisible(false)]
public class SynchronizedCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
{
	private object _sync;

	public int Count
	{
		get
		{
			lock (_sync)
			{
				return Items.Count;
			}
		}
	}

	protected List<T> Items { get; }

	public object SyncRoot => _sync;

	public T this[int index]
	{
		get
		{
			lock (_sync)
			{
				return Items[index];
			}
		}
		set
		{
			lock (_sync)
			{
				if (index < 0 || index >= Items.Count)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", index, System.SR.Format(System.SR.ValueMustBeInRange, 0, Items.Count - 1)));
				}
				SetItem(index, value);
			}
		}
	}

	bool ICollection<T>.IsReadOnly => false;

	bool ICollection.IsSynchronized => true;

	object ICollection.SyncRoot => _sync;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			VerifyValueType(value);
			this[index] = (T)value;
		}
	}

	bool IList.IsReadOnly => false;

	bool IList.IsFixedSize => false;

	public SynchronizedCollection()
	{
		Items = new List<T>();
		_sync = new object();
	}

	public SynchronizedCollection(object syncRoot)
	{
		Items = new List<T>();
		_sync = syncRoot ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("syncRoot"));
	}

	public SynchronizedCollection(object syncRoot, IEnumerable<T> list)
	{
		if (list == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("list"));
		}
		Items = new List<T>(list);
		_sync = syncRoot ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("syncRoot"));
	}

	public SynchronizedCollection(object syncRoot, params T[] list)
	{
		if (list == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("list"));
		}
		Items = new List<T>(list.Length);
		for (int i = 0; i < list.Length; i++)
		{
			Items.Add(list[i]);
		}
		_sync = syncRoot ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("syncRoot"));
	}

	public void Add(T item)
	{
		lock (_sync)
		{
			int count = Items.Count;
			InsertItem(count, item);
		}
	}

	public void Clear()
	{
		lock (_sync)
		{
			ClearItems();
		}
	}

	public void CopyTo(T[] array, int index)
	{
		lock (_sync)
		{
			Items.CopyTo(array, index);
		}
	}

	public bool Contains(T item)
	{
		lock (_sync)
		{
			return Items.Contains(item);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		lock (_sync)
		{
			return Items.GetEnumerator();
		}
	}

	public int IndexOf(T item)
	{
		lock (_sync)
		{
			return InternalIndexOf(item);
		}
	}

	public void Insert(int index, T item)
	{
		lock (_sync)
		{
			if (index < 0 || index > Items.Count)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", index, System.SR.Format(System.SR.ValueMustBeInRange, 0, Items.Count)));
			}
			InsertItem(index, item);
		}
	}

	private int InternalIndexOf(T item)
	{
		int count = Items.Count;
		for (int i = 0; i < count; i++)
		{
			if (object.Equals(Items[i], item))
			{
				return i;
			}
		}
		return -1;
	}

	public bool Remove(T item)
	{
		lock (_sync)
		{
			int num = InternalIndexOf(item);
			if (num < 0)
			{
				return false;
			}
			RemoveItem(num);
			return true;
		}
	}

	public void RemoveAt(int index)
	{
		lock (_sync)
		{
			if (index < 0 || index >= Items.Count)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", index, System.SR.Format(System.SR.ValueMustBeInRange, 0, Items.Count - 1)));
			}
			RemoveItem(index);
		}
	}

	protected virtual void ClearItems()
	{
		Items.Clear();
	}

	protected virtual void InsertItem(int index, T item)
	{
		Items.Insert(index, item);
	}

	protected virtual void RemoveItem(int index)
	{
		Items.RemoveAt(index);
	}

	protected virtual void SetItem(int index, T item)
	{
		Items[index] = item;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)Items).GetEnumerator();
	}

	void ICollection.CopyTo(Array array, int index)
	{
		lock (_sync)
		{
			((ICollection)Items).CopyTo(array, index);
		}
	}

	int IList.Add(object value)
	{
		VerifyValueType(value);
		lock (_sync)
		{
			Add((T)value);
			return Count - 1;
		}
	}

	bool IList.Contains(object value)
	{
		VerifyValueType(value);
		return Contains((T)value);
	}

	int IList.IndexOf(object value)
	{
		VerifyValueType(value);
		return IndexOf((T)value);
	}

	void IList.Insert(int index, object value)
	{
		VerifyValueType(value);
		Insert(index, (T)value);
	}

	void IList.Remove(object value)
	{
		VerifyValueType(value);
		Remove((T)value);
	}

	private static void VerifyValueType(object value)
	{
		if (value == null)
		{
			if (typeof(T).GetTypeInfo().IsValueType)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SynchronizedCollectionWrongTypeNull));
			}
		}
		else if (!(value is T))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.SynchronizedCollectionWrongType1, value.GetType().FullName)));
		}
	}
}
