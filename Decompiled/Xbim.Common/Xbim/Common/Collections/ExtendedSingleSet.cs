using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Xbim.Common.Collections;

public class ExtendedSingleSet<TInner, TOuter> : IItemSet<TOuter>, IList<TOuter>, ICollection<TOuter>, IEnumerable<TOuter>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IExpressEnumerable, IItemSet
{
	private readonly Func<TInner> _getter;

	private readonly Action<TInner> _setter;

	private readonly IItemSet<TOuter> _extended;

	private readonly Func<TInner, TOuter> _toOut;

	private readonly Func<TOuter, TInner> _toIn;

	private TInner Inner
	{
		get
		{
			return _getter();
		}
		set
		{
			TInner inner = Inner;
			_setter(value);
			if (this._collectionChanged != null)
			{
				if (inner != null)
				{
					this._collectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, inner));
				}
				if (value != null)
				{
					this._collectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
				}
			}
			if (this._propertyChanged != null)
			{
				if (inner == null && value != null)
				{
					this._propertyChanged(this, new PropertyChangedEventArgs("Count"));
				}
				if (inner != null && value == null)
				{
					this._propertyChanged(this, new PropertyChangedEventArgs("Count"));
				}
			}
		}
	}

	private TOuter InnerOut
	{
		get
		{
			if (Inner != null)
			{
				return _toOut(Inner);
			}
			return default(TOuter);
		}
		set
		{
			if (value == null)
			{
				Inner = default(TInner);
			}
			Inner = _toIn(value);
		}
	}

	private IEnumerable<TOuter> InnerSet => new TOuter[1] { _toOut(_getter()) };

	private int Increment => (Inner != null) ? 1 : 0;

	public int Count => _extended.Count + Increment;

	public bool IsReadOnly => false;

	public TOuter this[int index]
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public IPersistEntity OwningEntity => _extended.OwningEntity;

	private event NotifyCollectionChangedEventHandler _collectionChanged;

	public event NotifyCollectionChangedEventHandler CollectionChanged
	{
		add
		{
			_extended.CollectionChanged += value;
			_collectionChanged += value;
		}
		remove
		{
			_extended.CollectionChanged -= value;
			_collectionChanged -= value;
		}
	}

	private event PropertyChangedEventHandler _propertyChanged;

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			_extended.PropertyChanged += value;
			_propertyChanged += value;
		}
		remove
		{
			_extended.PropertyChanged -= value;
			_propertyChanged -= value;
		}
	}

	public ExtendedSingleSet(Func<TInner> getter, Action<TInner> setter, IItemSet<TOuter> extended, Func<TInner, TOuter> toOut, Func<TOuter, TInner> toIn)
	{
		_getter = getter;
		_setter = setter;
		_extended = extended;
		_toOut = toOut;
		_toIn = toIn;
	}

	public IEnumerator<TOuter> GetEnumerator()
	{
		if (Inner != null)
		{
			return _extended.Concat(InnerSet).GetEnumerator();
		}
		return _extended.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(TOuter item)
	{
		if (item != null)
		{
			TInner val = _toIn(item);
			if (Inner == null && val != null)
			{
				Inner = val;
			}
			else
			{
				_extended.Add(item);
			}
		}
	}

	public void Clear()
	{
		Inner = default(TInner);
		_extended.Clear();
	}

	public bool Contains(TOuter item)
	{
		if (item == null)
		{
			return false;
		}
		if (item.GetType().GetTypeInfo().IsClass)
		{
			if (!item.Equals(Inner))
			{
				return _extended.Contains(item);
			}
			return true;
		}
		if (!_toIn(item).Equals(Inner))
		{
			return _extended.Contains(item);
		}
		return true;
	}

	public void CopyTo(TOuter[] array, int arrayIndex)
	{
		this.ToArray().CopyTo(array, arrayIndex);
	}

	public bool Remove(TOuter item)
	{
		throw new NotImplementedException();
	}

	public int IndexOf(TOuter item)
	{
		if (item.Equals(InnerOut))
		{
			return 0;
		}
		return _extended.IndexOf(item) + Increment;
	}

	public void Insert(int index, TOuter item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

	public TOuter GetAt(int index)
	{
		throw new NotImplementedException();
	}

	public void AddRange(IEnumerable<TOuter> values)
	{
		throw new NotImplementedException();
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
