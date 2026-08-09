using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xbim.Common.Exceptions;

namespace Xbim.Common.Collections;

public class ProxyValueSet<TInner, TOuter> : IItemSet<TOuter>, IList<TOuter>, ICollection<TOuter>, IEnumerable<TOuter>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IExpressEnumerable, IItemSet, IList, ICollection
{
	private class ProxyEnumerator : IEnumerator<TOuter>, IEnumerator, IDisposable
	{
		private readonly ProxyValueSet<TInner, TOuter> _proxy;

		private readonly IEnumerator<TInner> _inner;

		public TOuter Current => _proxy._toOut(_inner.Current);

		object IEnumerator.Current => Current;

		public ProxyEnumerator(ProxyValueSet<TInner, TOuter> proxy)
		{
			_proxy = proxy;
			_inner = proxy._inner.GetEnumerator();
		}

		public void Dispose()
		{
			_inner.Dispose();
		}

		public bool MoveNext()
		{
			return _inner.MoveNext();
		}

		public void Reset()
		{
			_inner.Reset();
		}
	}

	private readonly IItemSet<TInner> _inner;

	private readonly Func<TInner, TOuter> _toOut;

	private readonly Func<TOuter, TInner> _toIn;

	private IList List => _inner as IList;

	object IList.this[int index]
	{
		get
		{
			return ((IList)_inner)[index];
		}
		set
		{
			((IList)_inner)[index] = value;
		}
	}

	bool IList.IsReadOnly => ((IList)_inner).IsReadOnly;

	public bool IsFixedSize => List.IsFixedSize;

	int ICollection.Count => ((ICollection)_inner).Count;

	public object SyncRoot => List.SyncRoot;

	public bool IsSynchronized => List.IsSynchronized;

	int ICollection<TOuter>.Count => ((ICollection)_inner).Count;

	bool ICollection<TOuter>.IsReadOnly => ((IList)_inner).IsReadOnly;

	public TOuter this[int index]
	{
		get
		{
			return _toOut(_inner[index]);
		}
		set
		{
			_inner[index] = _toIn(value);
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

	public ProxyValueSet(IItemSet<TInner> inner, Func<TInner, TOuter> toOut, Func<TOuter, TInner> toIn)
	{
		_inner = inner;
		_toOut = toOut;
		_toIn = toIn;
		if (List == null)
		{
			throw new XbimException("Inner list has to implement IList");
		}
	}

	public IEnumerator<TOuter> GetEnumerator()
	{
		return new ProxyEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(TOuter item)
	{
		_inner.Add(_toIn(item));
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
		((IList)_inner).Clear();
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
		((IList)_inner).RemoveAt(index);
	}

	void ICollection<TOuter>.Clear()
	{
		_inner.Clear();
	}

	public bool Contains(TOuter item)
	{
		return _inner.Contains(_toIn(item));
	}

	public void CopyTo(TOuter[] array, int arrayIndex)
	{
		TInner[] array2 = new TInner[array.Length];
		_inner.CopyTo(array2, arrayIndex);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _toOut(array2[i]);
		}
	}

	public bool Remove(TOuter item)
	{
		return _inner.Remove(_toIn(item));
	}

	public void CopyTo(Array array, int index)
	{
		List.CopyTo(array, index);
	}

	public int IndexOf(TOuter item)
	{
		return _inner.IndexOf(_toIn(item));
	}

	public void Insert(int index, TOuter item)
	{
		_inner.Insert(index, _toIn(item));
	}

	void IList<TOuter>.RemoveAt(int index)
	{
		_inner.RemoveAt(index);
	}

	public TOuter GetAt(int index)
	{
		return _toOut(_inner.GetAt(index));
	}

	public void AddRange(IEnumerable<TOuter> values)
	{
		_inner.AddRange(values.Select((TOuter v) => _toIn(v)));
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
}
