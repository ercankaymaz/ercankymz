using System.Runtime.InteropServices;
using System.ServiceModel;

namespace System.Collections.Generic;

[ComVisible(false)]
public class SynchronizedReadOnlyCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
{
	internal sealed class EnumeratorAdapter : IEnumerator, IDisposable
	{
		private IList<T> _list;

		private IEnumerator<T> _e;

		public object Current => _e.Current;

		public EnumeratorAdapter(IList<T> list)
		{
			_list = list;
			_e = list.GetEnumerator();
		}

		public bool MoveNext()
		{
			return _e.MoveNext();
		}

		public void Dispose()
		{
			_e.Dispose();
		}

		public void Reset()
		{
			_e = _list.GetEnumerator();
		}
	}

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

	protected IList<T> Items { get; }

	public T this[int index]
	{
		get
		{
			lock (_sync)
			{
				return Items[index];
			}
		}
	}

	bool ICollection<T>.IsReadOnly => true;

	T IList<T>.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			ThrowReadOnly();
		}
	}

	bool ICollection.IsSynchronized => true;

	object ICollection.SyncRoot => _sync;

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
			ThrowReadOnly();
		}
	}

	public SynchronizedReadOnlyCollection()
	{
		Items = new List<T>();
		_sync = new object();
	}

	public SynchronizedReadOnlyCollection(object syncRoot)
	{
		Items = new List<T>();
		_sync = syncRoot ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("syncRoot"));
	}

	public SynchronizedReadOnlyCollection(object syncRoot, IEnumerable<T> list)
	{
		if (list == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("list"));
		}
		Items = new List<T>(list);
		_sync = syncRoot ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("syncRoot"));
	}

	public SynchronizedReadOnlyCollection(object syncRoot, params T[] list)
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

	internal SynchronizedReadOnlyCollection(object syncRoot, List<T> list, bool makeCopy)
	{
		if (list == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("list"));
		}
		if (makeCopy)
		{
			Items = new List<T>(list);
		}
		else
		{
			Items = list;
		}
		_sync = syncRoot ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("syncRoot"));
	}

	public bool Contains(T value)
	{
		lock (_sync)
		{
			return Items.Contains(value);
		}
	}

	public void CopyTo(T[] array, int index)
	{
		lock (_sync)
		{
			Items.CopyTo(array, index);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		lock (_sync)
		{
			return Items.GetEnumerator();
		}
	}

	public int IndexOf(T value)
	{
		lock (_sync)
		{
			return Items.IndexOf(value);
		}
	}

	private void ThrowReadOnly()
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.SFxCollectionReadOnly));
	}

	void ICollection<T>.Add(T value)
	{
		ThrowReadOnly();
	}

	void ICollection<T>.Clear()
	{
		ThrowReadOnly();
	}

	bool ICollection<T>.Remove(T value)
	{
		ThrowReadOnly();
		return false;
	}

	void IList<T>.Insert(int index, T value)
	{
		ThrowReadOnly();
	}

	void IList<T>.RemoveAt(int index)
	{
		ThrowReadOnly();
	}

	void ICollection.CopyTo(Array array, int index)
	{
		if (!(Items is ICollection collection))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.SFxCopyToRequiresICollection));
		}
		lock (_sync)
		{
			collection.CopyTo(array, index);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		lock (_sync)
		{
			IEnumerable items = Items;
			if (items != null)
			{
				return items.GetEnumerator();
			}
			return new EnumeratorAdapter(Items);
		}
	}

	int IList.Add(object value)
	{
		ThrowReadOnly();
		return 0;
	}

	void IList.Clear()
	{
		ThrowReadOnly();
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
		ThrowReadOnly();
	}

	void IList.Remove(object value)
	{
		ThrowReadOnly();
	}

	void IList.RemoveAt(int index)
	{
		ThrowReadOnly();
	}

	private static void VerifyValueType(object value)
	{
		if (value is T || (value == null && !typeof(T).IsValueType()))
		{
			return;
		}
		Type type = ((value == null) ? typeof(object) : value.GetType());
		string message = System.SR.Format(System.SR.SFxCollectionWrongType2, type.ToString(), typeof(T).ToString());
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(message));
	}
}
