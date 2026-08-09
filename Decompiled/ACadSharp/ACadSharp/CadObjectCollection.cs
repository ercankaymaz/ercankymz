using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CSUtilities.Extensions;

namespace ACadSharp;

public class CadObjectCollection<T> : IObservableCadCollection<T>, IEnumerable<T>, IEnumerable where T : CadObject
{
	protected readonly HashSet<T> _entries = new HashSet<T>();

	public CadObject Owner { get; }

	public int Count => _entries.Count;

	public T this[int index] => _entries.ElementAtOrDefault(index);

	public event EventHandler<CollectionChangedEventArgs> OnAdd;

	public event EventHandler<CollectionChangedEventArgs> OnRemove;

	public CadObjectCollection(CadObject owner)
	{
		Owner = owner;
	}

	public virtual void Add(T item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (item.Owner != null)
		{
			throw new ArgumentException("Item " + item.GetType().FullName + " already has an owner", "item");
		}
		if (_entries.Contains(item))
		{
			throw new ArgumentException("Item " + item.GetType().FullName + " is already in the collection", "item");
		}
		_entries.Add(item);
		item.Owner = Owner;
		this.OnAdd?.Invoke(this, new CollectionChangedEventArgs(item));
	}

	public void AddRange(IEnumerable<T> items)
	{
		foreach (T item in items)
		{
			Add(item);
		}
	}

	public void Clear()
	{
		Queue<T> q = new Queue<T>(_entries.ToList());
		T element;
		while (q.TryDequeue(out element))
		{
			Remove(element);
		}
	}

	public virtual T Remove(T item)
	{
		if (!_entries.Remove(item))
		{
			return null;
		}
		item.Owner = null;
		this.OnRemove?.Invoke(this, new CollectionChangedEventArgs(item));
		return item;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _entries.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _entries.GetEnumerator();
	}
}
