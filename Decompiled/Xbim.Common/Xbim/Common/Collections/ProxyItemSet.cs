using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xbim.Common.Exceptions;

namespace Xbim.Common.Collections;

public class ProxyItemSet<TInner, TOuter> : IItemSet<TOuter>, IList<TOuter>, ICollection<TOuter>, IEnumerable<TOuter>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IExpressEnumerable, IItemSet, IList, ICollection where TInner : TOuter
{
	private readonly IItemSet<TInner> _inner;

	private IList List => _inner as IList;

	object IList.this[int index]
	{
		get
		{
			return List[index];
		}
		set
		{
			List[index] = value;
		}
	}

	bool IList.IsReadOnly => List.IsReadOnly;

	public bool IsFixedSize => List.IsFixedSize;

	int ICollection.Count => ((ICollection)_inner).Count;

	public object SyncRoot => List.SyncRoot;

	public bool IsSynchronized => List.IsSynchronized;

	int ICollection<TOuter>.Count => ((ICollection)_inner).Count;

	bool ICollection<TOuter>.IsReadOnly => List.IsReadOnly;

	public TOuter this[int index]
	{
		get
		{
			return (TOuter)(object)_inner[index];
		}
		set
		{
			_inner[index] = GetIn(value);
		}
	}

	public IPersistEntity OwningEntity => _inner.OwningEntity;

	public event NotifyCollectionChangedEventHandler CollectionChanged
	{
		add
		{
			_inner.CollectionChanged += value;
		}
		remove
		{
			_inner.CollectionChanged -= value;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			_inner.PropertyChanged += value;
		}
		remove
		{
			_inner.PropertyChanged -= value;
		}
	}

	public ProxyItemSet(IItemSet<TInner> inner)
	{
		_inner = inner;
		if (List == null)
		{
			throw new XbimException("Inner list has to implement IList");
		}
	}

	public IEnumerator<TOuter> GetEnumerator()
	{
		return new ProxyEnumerator<TInner, TOuter>(_inner.GetEnumerator());
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(TOuter item)
	{
		_inner.Add(GetIn(item));
	}

	public int Add(object value)
	{
		return List.Add(value);
	}

	public bool Contains(object value)
	{
		return List.Contains(value);
	}

	void IList.Clear()
	{
		_inner.Clear();
	}

	public int IndexOf(object value)
	{
		return List.IndexOf(value);
	}

	public void Insert(int index, object value)
	{
		List.Insert(index, value);
	}

	public void Remove(object value)
	{
		List.Remove(value);
	}

	void IList.RemoveAt(int index)
	{
		List.RemoveAt(index);
	}

	void ICollection<TOuter>.Clear()
	{
		_inner.Clear();
	}

	public bool Contains(TOuter item)
	{
		return _inner.Contains(GetIn(item));
	}

	public void CopyTo(TOuter[] array, int arrayIndex)
	{
		_inner.ToArray().CopyTo(array, arrayIndex);
	}

	public bool Remove(TOuter item)
	{
		Check(item);
		return _inner.Remove(GetIn(item));
	}

	public void CopyTo(Array array, int index)
	{
		List.CopyTo(array, index);
	}

	public int IndexOf(TOuter item)
	{
		return _inner.IndexOf(GetIn(item));
	}

	public void Insert(int index, TOuter item)
	{
		_inner.Insert(index, GetIn(item));
	}

	void IList<TOuter>.RemoveAt(int index)
	{
		_inner.RemoveAt(index);
	}

	public TOuter GetAt(int index)
	{
		return (TOuter)(object)_inner.GetAt(index);
	}

	public void AddRange(IEnumerable<TOuter> values)
	{
		_inner.AddRange(values.Cast<TInner>());
	}

	public TOuter FirstOrDefault(Func<TOuter, bool> predicate)
	{
		return Enumerable.FirstOrDefault(this, predicate);
	}

	public TF FirstOrDefault<TF>(Func<TF, bool> predicate) where TF : TOuter
	{
		return this.OfType<TF>().FirstOrDefault(predicate);
	}

	public IEnumerable<TW> Where<TW>(Func<TW, bool> predicate) where TW : TOuter
	{
		return this.OfType<TW>().Where(predicate);
	}

	private static void Check(TOuter item)
	{
		if (item != null && !(item is TInner))
		{
			throw new XbimException("Invalid type for underlying collection");
		}
	}

	private static TInner GetIn(TOuter outer)
	{
		if (outer == null)
		{
			return default(TInner);
		}
		Check(outer);
		return (TInner)(object)outer;
	}
}
