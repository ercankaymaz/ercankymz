using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xbim.Common.Exceptions;

namespace Xbim.Common.Collections;

public class ProxyNestedValueSet<TInner, TOuter> : IItemSet<IItemSet<TOuter>>, IList<IItemSet<TOuter>>, ICollection<IItemSet<TOuter>>, IEnumerable<IItemSet<TOuter>>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IExpressEnumerable, IItemSet, IList, ICollection
{
	private class ProxyEnumerator : IEnumerator<IItemSet<TOuter>>, IEnumerator, IDisposable
	{
		private ProxyNestedValueSet<TInner, TOuter> inner;

		private IItemSet<TOuter> current;

		private int currentIdx = -1;

		public IItemSet<TOuter> Current => current;

		object IEnumerator.Current => current;

		public ProxyEnumerator(ProxyNestedValueSet<TInner, TOuter> inner)
		{
			this.inner = inner;
		}

		public void Dispose()
		{
			inner = null;
		}

		public bool MoveNext()
		{
			currentIdx++;
			if (currentIdx > inner.Count - 1)
			{
				return false;
			}
			current = inner[currentIdx];
			return true;
		}

		public void Reset()
		{
			currentIdx = -1;
		}
	}

	private readonly IItemSet<IItemSet<TInner>> _inner;

	private readonly Func<TInner, TOuter> _toOut;

	private readonly Func<TOuter, TInner> _toIn;

	private IList List => _inner as IList;

	public int Count => _inner.Count;

	public bool IsReadOnly => false;

	public IPersistEntity OwningEntity => _inner.OwningEntity;

	public bool IsFixedSize => false;

	public object SyncRoot => _inner;

	public bool IsSynchronized => true;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			this[index] = value as IItemSet<TOuter>;
		}
	}

	public IItemSet<TOuter> this[int index]
	{
		get
		{
			return new ProxyValueSet<TInner, TOuter>(_inner[index], _toOut, _toIn);
		}
		set
		{
			if (value == null)
			{
				_inner[index] = null;
				return;
			}
			_inner.GetAt(index).AddRange(value.Select((TOuter v) => _toIn(v)));
		}
	}

	public event NotifyCollectionChangedEventHandler CollectionChanged;

	public event PropertyChangedEventHandler PropertyChanged;

	public ProxyNestedValueSet(IItemSet<IItemSet<TInner>> inner, Func<TInner, TOuter> toOut, Func<TOuter, TInner> toIn)
	{
		_inner = inner;
		_toOut = toOut;
		_toIn = toIn;
		if (List == null)
		{
			throw new XbimException("Inner list must implement IList");
		}
		_inner.CollectionChanged += delegate(object s, NotifyCollectionChangedEventArgs a)
		{
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(a.Action));
		};
		_inner.PropertyChanged += delegate(object s, PropertyChangedEventArgs a)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a.PropertyName));
		};
	}

	public IItemSet<TOuter> GetAt(int index)
	{
		return new ProxyValueSet<TInner, TOuter>(_inner.GetAt(index), _toOut, _toIn);
	}

	public void AddRange(IEnumerable<IItemSet<TOuter>> values)
	{
		int num = _inner.Count;
		foreach (IItemSet<TOuter> value in values)
		{
			_inner.GetAt(num).AddRange(value.Select((TOuter v) => _toIn(v)));
			num++;
		}
	}

	public IItemSet<TOuter> FirstOrDefault(Func<IItemSet<TOuter>, bool> predicate)
	{
		IItemSet<TInner> itemSet = _inner.FirstOrDefault((IItemSet<TInner> i) => predicate(new ProxyValueSet<TInner, TOuter>(i, _toOut, _toIn)));
		if (itemSet == null)
		{
			return null;
		}
		return new ProxyValueSet<TInner, TOuter>(itemSet, _toOut, _toIn);
	}

	TF IItemSet<IItemSet<TOuter>>.FirstOrDefault<TF>(Func<TF, bool> predicate)
	{
		return _inner.Select((IItemSet<TInner> i) => new ProxyValueSet<TInner, TOuter>(i, _toOut, _toIn)).OfType<TF>().FirstOrDefault(predicate);
	}

	public IEnumerable<TW> Where<TW>(Func<TW, bool> predicate) where TW : IItemSet<TOuter>
	{
		return _inner.Select((IItemSet<TInner> i) => new ProxyValueSet<TInner, TOuter>(i, _toOut, _toIn)).OfType<TW>().Where(predicate);
	}

	public int IndexOf(IItemSet<TOuter> item)
	{
		List<TInner> inner = item.Select((TOuter i) => _toIn(i)).ToList();
		IItemSet<TInner> itemSet = _inner.FirstOrDefault((IItemSet<TInner> i) => inner.SequenceEqual(i));
		if (itemSet == null)
		{
			return -1;
		}
		return _inner.IndexOf(itemSet);
	}

	public void Insert(int index, IItemSet<TOuter> item)
	{
		this[index] = item;
	}

	public void RemoveAt(int index)
	{
		_inner.RemoveAt(index);
	}

	public void Add(IItemSet<TOuter> item)
	{
		_inner.GetAt(_inner.Count).AddRange(item.Select((TOuter i) => _toIn(i)));
	}

	public void Clear()
	{
		_inner.Clear();
	}

	public bool Contains(IItemSet<TOuter> item)
	{
		return IndexOf(item) > -1;
	}

	public void CopyTo(IItemSet<TOuter>[] array, int arrayIndex)
	{
		for (int i = 0; i < _inner.Count; i++)
		{
			array[arrayIndex + i] = new ProxyValueSet<TInner, TOuter>(_inner[i], _toOut, _toIn);
		}
	}

	public bool Remove(IItemSet<TOuter> item)
	{
		int num = IndexOf(item);
		if (num < 0)
		{
			return false;
		}
		RemoveAt(num);
		return true;
	}

	public IEnumerator<IItemSet<TOuter>> GetEnumerator()
	{
		return new ProxyEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public int Add(object value)
	{
		if (!(value is IItemSet<TOuter> item))
		{
			throw new ArgumentException("Invalid type", "value");
		}
		Add(item);
		return Count - 1;
	}

	public bool Contains(object value)
	{
		if (!(value is IItemSet<TOuter> item))
		{
			throw new ArgumentException("Invalid type", "value");
		}
		return Contains(item);
	}

	public int IndexOf(object value)
	{
		if (!(value is IItemSet<TOuter> item))
		{
			throw new ArgumentException("Invalid type", "value");
		}
		return IndexOf(item);
	}

	public void Insert(int index, object value)
	{
		if (!(value is IItemSet<TOuter> item))
		{
			throw new ArgumentException("Invalid type", "value");
		}
		Insert(index, item);
	}

	public void Remove(object value)
	{
		if (!(value is IItemSet<TOuter> item))
		{
			throw new ArgumentException("Invalid type", "value");
		}
		Remove(item);
	}

	public void CopyTo(Array array, int index)
	{
		for (int i = 0; i < _inner.Count; i++)
		{
			array.SetValue(new ProxyValueSet<TInner, TOuter>(_inner[i], _toOut, _toIn), index + i);
		}
	}
}
