using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MS.Internal;

internal class ObservableCollectionAggregate<T> : INotifyCollectionChanged, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private List<ICollection<T>> _collections = new List<ICollection<T>>();

	public int Count
	{
		get
		{
			int num = 0;
			foreach (ICollection<T> collection in _collections)
			{
				num += collection.Count;
			}
			return num;
		}
	}

	public bool IsReadOnly => true;

	public event NotifyCollectionChangedEventHandler CollectionChanged;

	public void AddCollection(ICollection<T> collection)
	{
		if (collection == null)
		{
			throw new ArgumentNullException("collection");
		}
		_collections.Add(collection);
		ConsumeCollection(collection);
	}

	public void Reset()
	{
		foreach (ICollection<T> collection in _collections)
		{
			if (collection is INotifyCollectionChanged notifyCollectionChanged)
			{
				notifyCollectionChanged.CollectionChanged -= OnIndividualCollectionChanged;
			}
		}
		_collections.Clear();
	}

	private void ConsumeCollection(ICollection<T> collection)
	{
		if (collection is INotifyCollectionChanged notifyCollectionChanged)
		{
			notifyCollectionChanged.CollectionChanged += OnIndividualCollectionChanged;
		}
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}

	private void OnIndividualCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		int num = 0;
		if (e.Action != NotifyCollectionChangedAction.Reset)
		{
			foreach (ICollection<T> collection in _collections)
			{
				if (!object.Equals(collection, sender))
				{
					num += collection.Count;
					continue;
				}
				break;
			}
		}
		OnCollectionChanged(e.Action switch
		{
			NotifyCollectionChangedAction.Add => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, e.NewItems, e.NewStartingIndex + num), 
			NotifyCollectionChangedAction.Remove => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, e.OldItems, e.OldStartingIndex + num), 
			NotifyCollectionChangedAction.Replace => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, e.NewItems, e.OldItems, e.NewStartingIndex + num), 
			NotifyCollectionChangedAction.Move => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, e.OldItems, e.NewStartingIndex + num, e.OldStartingIndex + num), 
			_ => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset), 
		});
	}

	private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		if (this.CollectionChanged != null)
		{
			this.CollectionChanged(this, e);
		}
	}

	public void Add(T item)
	{
		throw new InvalidOperationException();
	}

	public bool Contains(T item)
	{
		foreach (ICollection<T> collection in _collections)
		{
			if (collection.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		foreach (ICollection<T> collection in _collections)
		{
			collection.CopyTo(array, arrayIndex);
			arrayIndex += collection.Count;
		}
	}

	public bool Remove(T item)
	{
		throw new InvalidOperationException();
	}

	public void Clear()
	{
		throw new InvalidOperationException();
	}

	public IEnumerator<T> GetEnumerator()
	{
		foreach (ICollection<T> collection in _collections)
		{
			foreach (T item in collection)
			{
				yield return item;
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
