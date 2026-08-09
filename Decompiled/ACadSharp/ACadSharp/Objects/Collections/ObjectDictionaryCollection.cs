using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ACadSharp.Objects.Collections;

public abstract class ObjectDictionaryCollection<T> : ICadCollection<T>, IEnumerable<T>, IEnumerable, IObservableCadCollection<T>, IHandledCadObject where T : NonGraphicalObject
{
	protected CadDictionary _dictionary;

	public ulong Handle => _dictionary.Handle;

	public T this[string key] => (T)_dictionary[key];

	public event EventHandler<CollectionChangedEventArgs> OnAdd
	{
		add
		{
			_dictionary.OnAdd += value;
		}
		remove
		{
			_dictionary.OnAdd -= value;
		}
	}

	public event EventHandler<CollectionChangedEventArgs> OnRemove
	{
		add
		{
			_dictionary.OnRemove += value;
		}
		remove
		{
			_dictionary.OnRemove -= value;
		}
	}

	protected ObjectDictionaryCollection(CadDictionary dictionary)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		_dictionary = dictionary;
	}

	public virtual void Add(T entry)
	{
		_dictionary.Add(entry);
	}

	public void Clear()
	{
		_dictionary.Clear();
	}

	public bool ContainsKey(string key)
	{
		return _dictionary.ContainsKey(key);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _dictionary.OfType<T>().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _dictionary.OfType<T>().GetEnumerator();
	}

	public bool Remove(string name)
	{
		T entry;
		return Remove(name, out entry);
	}

	public virtual bool Remove(string name, out T entry)
	{
		NonGraphicalObject item;
		bool result = _dictionary.Remove(name, out item);
		entry = (T)item;
		return result;
	}

	public T TryAdd(T item)
	{
		if (TryGet(item.Name, out var entry))
		{
			return entry;
		}
		Add(item);
		return item;
	}

	public bool TryGet(string name, out T entry)
	{
		return _dictionary.TryGetEntry<T>(name, out entry);
	}
}
