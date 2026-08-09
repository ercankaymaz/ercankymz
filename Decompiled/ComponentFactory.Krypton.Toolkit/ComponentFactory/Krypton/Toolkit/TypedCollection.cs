#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class TypedCollection<T> : IList, ICollection, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T> where T : class
{
	private List<T> _list;

	public bool IsFixedSize => false;

	object IList.this[int index]
	{
		get
		{
			return _list[index];
		}
		set
		{
			throw new NotImplementedException("Cannot set a collection index with a new value");
		}
	}

	public T this[int index]
	{
		get
		{
			return _list[index];
		}
		set
		{
			throw new NotImplementedException("Cannot set a collection index with a new value");
		}
	}

	public virtual T this[string name] => null;

	public int Count => _list.Count;

	public bool IsReadOnly => false;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public event TypedHandler<T> Inserting;

	public event TypedHandler<T> Inserted;

	public event TypedHandler<T> Removing;

	public event TypedHandler<T> Removed;

	public event EventHandler Clearing;

	public event EventHandler Cleared;

	public event EventHandler Reordered;

	public TypedCollection()
	{
		_list = new List<T>(4);
	}

	public override string ToString()
	{
		return Count + " TypedCollection";
	}

	public virtual void AddRange(T[] itemArray)
	{
		foreach (T item in itemArray)
		{
			Add(item);
		}
	}

	public virtual int Add(object value)
	{
		Add(value as T);
		return Count - 1;
	}

	public bool Contains(object value)
	{
		return Contains(value as T);
	}

	public int IndexOf(object value)
	{
		return IndexOf(value as T);
	}

	public virtual void Insert(int index, object value)
	{
		Insert(index, value as T);
	}

	public void Remove(object value)
	{
		Remove(value as T);
	}

	public int IndexOf(T item)
	{
		Debug.Assert(item != null);
		return _list.IndexOf(item);
	}

	public virtual void Insert(int index, T item)
	{
		Debug.Assert(item != null);
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (_list.Contains(item))
		{
			throw new ArgumentOutOfRangeException("item", "Item already in collection");
		}
		OnInserting(new TypedCollectionEventArgs<T>(item, index));
		_list.Insert(index, item);
		OnInserted(new TypedCollectionEventArgs<T>(item, index));
	}

	public void RemoveAt(int index)
	{
		T item = this[index];
		OnRemoving(new TypedCollectionEventArgs<T>(item, index));
		_list.RemoveAt(index);
		OnRemoved(new TypedCollectionEventArgs<T>(item, index));
	}

	public void MoveAfter(T source, T target)
	{
		_list.Remove(source);
		_list.Insert(_list.IndexOf(target) + 1, source);
		OnReordered(EventArgs.Empty);
	}

	public void MoveBefore(T source, T target)
	{
		_list.Remove(source);
		_list.Insert(_list.IndexOf(target), source);
		OnReordered(EventArgs.Empty);
	}

	public virtual void Add(T item)
	{
		Debug.Assert(item != null);
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (_list.Contains(item))
		{
			throw new ArgumentOutOfRangeException("item", "Item already in collection");
		}
		OnInserting(new TypedCollectionEventArgs<T>(item, _list.Count));
		_list.Add(item);
		OnInserted(new TypedCollectionEventArgs<T>(item, _list.Count - 1));
	}

	public void Clear()
	{
		OnClearing(EventArgs.Empty);
		_list.Clear();
		OnCleared(EventArgs.Empty);
	}

	public bool Contains(T item)
	{
		return _list.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		Debug.Assert(array != null);
		_list.CopyTo(array, arrayIndex);
	}

	public virtual bool Remove(T item)
	{
		Debug.Assert(item != null);
		int index = IndexOf(item);
		OnRemoving(new TypedCollectionEventArgs<T>(item, index));
		bool result = _list.Remove(item);
		OnRemoved(new TypedCollectionEventArgs<T>(item, index));
		return result;
	}

	public void CopyTo(Array array, int index)
	{
		Debug.Assert(array != null);
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			array.SetValue(current, index++);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	protected virtual void OnInserting(TypedCollectionEventArgs<T> e)
	{
		if (this.Inserting != null)
		{
			this.Inserting(this, e);
		}
	}

	protected virtual void OnInserted(TypedCollectionEventArgs<T> e)
	{
		if (this.Inserted != null)
		{
			this.Inserted(this, e);
		}
	}

	protected virtual void OnRemoving(TypedCollectionEventArgs<T> e)
	{
		if (this.Removing != null)
		{
			this.Removing(this, e);
		}
	}

	protected virtual void OnRemoved(TypedCollectionEventArgs<T> e)
	{
		if (this.Removed != null)
		{
			this.Removed(this, e);
		}
	}

	protected virtual void OnClearing(EventArgs e)
	{
		if (this.Clearing != null)
		{
			this.Clearing(this, e);
		}
	}

	protected virtual void OnCleared(EventArgs e)
	{
		if (this.Cleared != null)
		{
			this.Cleared(this, e);
		}
	}

	protected virtual void OnReordered(EventArgs e)
	{
		if (this.Reordered != null)
		{
			this.Reordered(this, e);
		}
	}
}
