using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xbim.Common.Exceptions;

namespace Xbim.Common.Collections;

public class ExtendedItemSet<TInner, TOuter> : IItemSet<TOuter>, IList<TOuter>, ICollection<TOuter>, IEnumerable<TOuter>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IExpressEnumerable, IItemSet, IList, ICollection
{
	private readonly IItemSet<TOuter> _extendedSet;

	private readonly Func<TInner, TOuter> _transformOut;

	private readonly Func<TOuter, TInner> _transformIn;

	private readonly IItemSet<TInner> _innerSet;

	private IList InnerList => _innerSet as IList;

	private IList ExtendedList => _extendedSet as IList;

	private IEnumerable<TOuter> Transformed => _innerSet.Select((TInner inner) => _transformOut(inner));

	object IList.this[int index]
	{
		get
		{
			return ((IList<TOuter>)this)[index];
		}
		set
		{
			if (value == null)
			{
				((IList<TOuter>)this)[index] = default(TOuter);
				return;
			}
			if (!(value is TOuter))
			{
				throw new ArgumentException("It isn't possible to insert object which is not " + typeof(TOuter).FullName, "value");
			}
			((IList<TOuter>)this)[index] = (TOuter)value;
		}
	}

	bool IList.IsReadOnly => false;

	public bool IsFixedSize => false;

	int ICollection.Count => ((ICollection)_extendedSet).Count + ((ICollection)_innerSet).Count;

	public object SyncRoot => InnerList.SyncRoot;

	public bool IsSynchronized
	{
		get
		{
			if (InnerList.IsSynchronized)
			{
				return ExtendedList.IsSynchronized;
			}
			return false;
		}
	}

	int ICollection<TOuter>.Count => ((ICollection)this).Count;

	bool ICollection<TOuter>.IsReadOnly => false;

	public TOuter this[int index]
	{
		get
		{
			int count = ((ICollection)_innerSet).Count;
			if (index < count)
			{
				TInner arg = _innerSet[index];
				return _transformOut(arg);
			}
			return _extendedSet[index - count];
		}
		set
		{
			int count = ((ICollection)_innerSet).Count;
			if (index < count)
			{
				_innerSet[index] = _transformIn(value);
			}
			else
			{
				_extendedSet[index - count] = value;
			}
		}
	}

	public IPersistEntity OwningEntity => _innerSet.OwningEntity;

	public event NotifyCollectionChangedEventHandler CollectionChanged
	{
		add
		{
			_innerSet.CollectionChanged += value;
			_extendedSet.CollectionChanged += value;
		}
		remove
		{
			_innerSet.CollectionChanged -= value;
			_extendedSet.CollectionChanged -= value;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			_innerSet.PropertyChanged += value;
			_extendedSet.PropertyChanged += value;
		}
		remove
		{
			_innerSet.PropertyChanged -= value;
			_extendedSet.PropertyChanged -= value;
		}
	}

	public ExtendedItemSet(IItemSet<TInner> innerSet, IItemSet<TOuter> extendedSet, Func<TInner, TOuter> transformOut, Func<TOuter, TInner> transformIn)
	{
		_innerSet = innerSet;
		_extendedSet = extendedSet;
		if (InnerList == null || ExtendedList == null)
		{
			throw new XbimException("Both inner and extended lists must implement IList");
		}
		_transformOut = transformOut;
		_transformIn = transformIn;
	}

	public IEnumerator<TOuter> GetEnumerator()
	{
		return Transformed.Concat(_extendedSet).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(TOuter item)
	{
		if (item == null)
		{
			return;
		}
		if (_extendedSet.Any())
		{
			_extendedSet.Add(item);
			return;
		}
		TInner val = _transformIn(item);
		if (val == null)
		{
			_extendedSet.Add(item);
		}
		else
		{
			_innerSet.Add(val);
		}
	}

	public int Add(object value)
	{
		if (!(value is TOuter val))
		{
			return -1;
		}
		TInner val2 = _transformIn(val);
		if (val2 != null)
		{
			return InnerList.Add(val2);
		}
		int num = ExtendedList.Add(val);
		return _innerSet.Count + num;
	}

	public bool Contains(object value)
	{
		if (!(value is TOuter))
		{
			return false;
		}
		if (!_innerSet.Contains(_transformIn((TOuter)value)))
		{
			return ExtendedList.Contains(value);
		}
		return true;
	}

	void IList.Clear()
	{
		if (_innerSet.Any())
		{
			((IList)_innerSet).Clear();
		}
		if (_extendedSet.Any())
		{
			((IList)_extendedSet).Clear();
		}
	}

	public int IndexOf(object value)
	{
		if (!(value is TOuter item))
		{
			return -1;
		}
		return IndexOf(item);
	}

	public void Insert(int index, object value)
	{
		if (!(value is TOuter))
		{
			throw new ArgumentException("It isn't possible to insert object which is not " + typeof(TOuter).FullName, "value");
		}
		Insert(index, (TOuter)value);
	}

	public void Remove(object value)
	{
		if (value is TOuter)
		{
			Remove((TOuter)value);
		}
	}

	void IList.RemoveAt(int index)
	{
		int count = ((ICollection)_innerSet).Count;
		IList obj = ((index < count) ? InnerList : ExtendedList);
		int index2 = ((index < count) ? index : (index - count));
		obj.RemoveAt(index2);
	}

	void ICollection<TOuter>.Clear()
	{
		((IList)this).Clear();
	}

	public bool Contains(TOuter item)
	{
		if (item == null)
		{
			return false;
		}
		if (!_extendedSet.Contains(item))
		{
			return _innerSet.Contains(_transformIn(item));
		}
		return true;
	}

	public void CopyTo(TOuter[] array, int arrayIndex)
	{
		int num = 0;
		for (int i = arrayIndex; i < ((ICollection)this).Count; i++)
		{
			array[num++] = this[i];
		}
	}

	public bool Remove(TOuter item)
	{
		if (item == null)
		{
			return false;
		}
		if (!_extendedSet.Remove(item))
		{
			return _innerSet.Remove(_transformIn(item));
		}
		return true;
	}

	public void CopyTo(Array array, int index)
	{
		int num = 0;
		for (int i = index; i < ((ICollection)this).Count; i++)
		{
			array.SetValue(this[i], num++);
		}
	}

	public int IndexOf(TOuter item)
	{
		int num = _innerSet.IndexOf(_transformIn(item));
		if (num < 0)
		{
			num = _extendedSet.IndexOf(item);
		}
		return num;
	}

	public void Insert(int index, TOuter item)
	{
		int count = ((ICollection)_innerSet).Count;
		if (index <= count)
		{
			TInner item2 = _transformIn(item);
			_innerSet.Insert(index, item2);
		}
		else
		{
			int index2 = index - count;
			_extendedSet.Insert(index2, item);
		}
	}

	void IList<TOuter>.RemoveAt(int index)
	{
		((IList)this).RemoveAt(index);
	}

	public TOuter GetAt(int index)
	{
		return _transformOut(_innerSet.GetAt(index));
	}

	public void AddRange(IEnumerable<TOuter> values)
	{
		foreach (TOuter value in values)
		{
			if (value == null)
			{
				InnerList.Add(null);
				continue;
			}
			TInner val = _transformIn(value);
			if (val != null)
			{
				_innerSet.Add(val);
			}
			else
			{
				_extendedSet.Add(value);
			}
		}
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
