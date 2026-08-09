using System.Linq;

namespace System.Collections.Generic;

public class XbimMultiValueDictionary<TKey, TValue> : IDictionary<TKey, ICollection<TValue>>, ICollection<KeyValuePair<TKey, ICollection<TValue>>>, IEnumerable<KeyValuePair<TKey, ICollection<TValue>>>, IEnumerable
{
	private class Enumerator : IEnumerator<KeyValuePair<TKey, ICollection<TValue>>>, IEnumerator, IDisposable
	{
		private enum EnumerationState
		{
			BeforeFirst,
			During,
			AfterLast
		}

		private XbimMultiValueDictionary<TKey, TValue> _xbimMultiValueDictionary;

		private int version;

		private KeyValuePair<TKey, ICollection<TValue>> current;

		private Dictionary<TKey, InnerCollectionView>.Enumerator enumerator;

		private EnumerationState state;

		public KeyValuePair<TKey, ICollection<TValue>> Current => current;

		object IEnumerator.Current => state switch
		{
			EnumerationState.BeforeFirst => throw new InvalidOperationException("Properties.Resources.InvalidOperation_EnumNotStarted"), 
			EnumerationState.AfterLast => throw new InvalidOperationException("Properties.Resources.InvalidOperation_EnumEnded"), 
			_ => current, 
		};

		internal Enumerator(XbimMultiValueDictionary<TKey, TValue> _xbimMultiValueDictionary)
		{
			this._xbimMultiValueDictionary = _xbimMultiValueDictionary;
			version = _xbimMultiValueDictionary.version;
			current = default(KeyValuePair<TKey, ICollection<TValue>>);
			enumerator = _xbimMultiValueDictionary.dictionary.GetEnumerator();
			state = EnumerationState.BeforeFirst;
		}

		public bool MoveNext()
		{
			if (version != _xbimMultiValueDictionary.version)
			{
				throw new InvalidOperationException("Properties.Resources.InvalidOperation_EnumFailedVersion");
			}
			if (enumerator.MoveNext())
			{
				current = new KeyValuePair<TKey, ICollection<TValue>>(enumerator.Current.Key, enumerator.Current.Value);
				state = EnumerationState.During;
				return true;
			}
			current = default(KeyValuePair<TKey, ICollection<TValue>>);
			state = EnumerationState.AfterLast;
			return false;
		}

		public void Reset()
		{
			if (version != _xbimMultiValueDictionary.version)
			{
				throw new InvalidOperationException("Properties.Resources.InvalidOperation_EnumFailedVersion");
			}
			enumerator.Dispose();
			enumerator = _xbimMultiValueDictionary.dictionary.GetEnumerator();
			current = default(KeyValuePair<TKey, ICollection<TValue>>);
			state = EnumerationState.BeforeFirst;
		}

		public void Dispose()
		{
			enumerator.Dispose();
		}
	}

	private class InnerCollectionView : ICollection<TValue>, IEnumerable<TValue>, IEnumerable
	{
		private TKey key;

		private ICollection<TValue> collection;

		public int Count => collection.Count;

		public bool IsReadOnly => true;

		public TKey Key => key;

		public InnerCollectionView(TKey key, ICollection<TValue> collection)
		{
			this.key = key;
			this.collection = collection;
		}

		public void AddValue(TValue item)
		{
			collection.Add(item);
		}

		public bool RemoveValue(TValue item)
		{
			return collection.Remove(item);
		}

		public bool Contains(TValue item)
		{
			return collection.Contains(item);
		}

		public void CopyTo(TValue[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex", "Properties.Resources.ArgumentOutOfRange_NeedNonNegNum");
			}
			if (arrayIndex > array.Length)
			{
				throw new ArgumentOutOfRangeException("arrayIndex", "Properties.Resources.ArgumentOutOfRange_Index");
			}
			if (array.Length - arrayIndex < collection.Count)
			{
				throw new ArgumentException("Properties.Resources.CopyTo_ArgumentsTooSmall", "arrayIndex");
			}
			collection.CopyTo(array, arrayIndex);
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			return collection.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void ICollection<TValue>.Add(TValue item)
		{
			throw new NotSupportedException("Properties.Resources.ReadOnly_Modification");
		}

		void ICollection<TValue>.Clear()
		{
			throw new NotSupportedException("Properties.Resources.ReadOnly_Modification");
		}

		bool ICollection<TValue>.Remove(TValue item)
		{
			throw new NotSupportedException("Properties.Resources.ReadOnly_Modification");
		}
	}

	private Dictionary<TKey, InnerCollectionView> dictionary;

	private Func<ICollection<TValue>> NewCollectionFactory = () => new List<TValue>();

	private int version;

	ICollection<TValue> IDictionary<TKey, ICollection<TValue>>.this[TKey key]
	{
		get
		{
			return dictionary[key];
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public IEnumerable<TKey> Keys => dictionary.Keys;

	ICollection<ICollection<TValue>> IDictionary<TKey, ICollection<TValue>>.Values => dictionary.Select((KeyValuePair<TKey, InnerCollectionView> kv) => kv.Value).Cast<ICollection<TValue>>().ToList();

	ICollection<TKey> IDictionary<TKey, ICollection<TValue>>.Keys => dictionary.Keys;

	public IEnumerable<ICollection<TValue>> Values => dictionary.Values;

	public ICollection<TValue> this[TKey key]
	{
		get
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (dictionary.TryGetValue(key, out var value))
			{
				return value;
			}
			throw new KeyNotFoundException();
		}
	}

	public int Count => dictionary.Count;

	public bool IsReadOnly => false;

	public XbimMultiValueDictionary()
	{
		dictionary = new Dictionary<TKey, InnerCollectionView>();
	}

	public XbimMultiValueDictionary(int capacity)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "ArgumentOutOfRange_NeedNonNegNum");
		}
		dictionary = new Dictionary<TKey, InnerCollectionView>(capacity);
	}

	public XbimMultiValueDictionary(IEqualityComparer<TKey> comparer)
	{
		dictionary = new Dictionary<TKey, InnerCollectionView>(comparer);
	}

	public XbimMultiValueDictionary(int capacity, IEqualityComparer<TKey> comparer)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "Properties.Resources.ArgumentOutOfRange_NeedNonNegNum");
		}
		dictionary = new Dictionary<TKey, InnerCollectionView>(capacity, comparer);
	}

	public XbimMultiValueDictionary(IEnumerable<KeyValuePair<TKey, ICollection<TValue>>> enumerable)
		: this(enumerable, (IEqualityComparer<TKey>)null)
	{
	}

	public XbimMultiValueDictionary(IEnumerable<KeyValuePair<TKey, ICollection<TValue>>> enumerable, IEqualityComparer<TKey> comparer)
	{
		if (enumerable == null)
		{
			throw new ArgumentNullException("enumerable");
		}
		dictionary = new Dictionary<TKey, InnerCollectionView>(comparer);
		foreach (KeyValuePair<TKey, ICollection<TValue>> item in enumerable)
		{
			AddRange(item.Key, item.Value);
		}
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>() where TValueCollection : ICollection<TValue>, new()
	{
		if (new TValueCollection().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		return new XbimMultiValueDictionary<TKey, TValue>
		{
			NewCollectionFactory = () => new TValueCollection()
		};
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(int capacity) where TValueCollection : ICollection<TValue>, new()
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "Properties.Resources.ArgumentOutOfRange_NeedNonNegNum");
		}
		if (new TValueCollection().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		return new XbimMultiValueDictionary<TKey, TValue>(capacity)
		{
			NewCollectionFactory = () => new TValueCollection()
		};
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEqualityComparer<TKey> comparer) where TValueCollection : ICollection<TValue>, new()
	{
		if (new TValueCollection().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		return new XbimMultiValueDictionary<TKey, TValue>(comparer)
		{
			NewCollectionFactory = () => new TValueCollection()
		};
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(int capacity, IEqualityComparer<TKey> comparer) where TValueCollection : ICollection<TValue>, new()
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "Properties.Resources.ArgumentOutOfRange_NeedNonNegNum");
		}
		if (new TValueCollection().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		return new XbimMultiValueDictionary<TKey, TValue>(capacity, comparer)
		{
			NewCollectionFactory = () => new TValueCollection()
		};
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<KeyValuePair<TKey, ICollection<TValue>>> enumerable) where TValueCollection : ICollection<TValue>, new()
	{
		if (enumerable == null)
		{
			throw new ArgumentNullException("enumerable");
		}
		if (new TValueCollection().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		XbimMultiValueDictionary<TKey, TValue> xbimMultiValueDictionary = new XbimMultiValueDictionary<TKey, TValue>();
		xbimMultiValueDictionary.NewCollectionFactory = () => new TValueCollection();
		foreach (KeyValuePair<TKey, ICollection<TValue>> item in enumerable)
		{
			xbimMultiValueDictionary.AddRange(item.Key, item.Value);
		}
		return xbimMultiValueDictionary;
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<KeyValuePair<TKey, ICollection<TValue>>> enumerable, IEqualityComparer<TKey> comparer) where TValueCollection : ICollection<TValue>, new()
	{
		if (enumerable == null)
		{
			throw new ArgumentNullException("enumerable");
		}
		if (new TValueCollection().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		XbimMultiValueDictionary<TKey, TValue> xbimMultiValueDictionary = new XbimMultiValueDictionary<TKey, TValue>(comparer);
		xbimMultiValueDictionary.NewCollectionFactory = () => new TValueCollection();
		foreach (KeyValuePair<TKey, ICollection<TValue>> item in enumerable)
		{
			xbimMultiValueDictionary.AddRange(item.Key, item.Value);
		}
		return xbimMultiValueDictionary;
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
	{
		if (collectionFactory().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		return new XbimMultiValueDictionary<TKey, TValue>
		{
			NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory
		};
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(int capacity, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "Properties.Resources.ArgumentOutOfRange_NeedNonNegNum");
		}
		if (collectionFactory().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		return new XbimMultiValueDictionary<TKey, TValue>(capacity)
		{
			NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory
		};
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEqualityComparer<TKey> comparer, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
	{
		if (collectionFactory().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		return new XbimMultiValueDictionary<TKey, TValue>(comparer)
		{
			NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory
		};
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(int capacity, IEqualityComparer<TKey> comparer, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "Properties.Resources.ArgumentOutOfRange_NeedNonNegNum");
		}
		if (collectionFactory().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		return new XbimMultiValueDictionary<TKey, TValue>(capacity, comparer)
		{
			NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory
		};
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<KeyValuePair<TKey, ICollection<TValue>>> enumerable, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
	{
		if (enumerable == null)
		{
			throw new ArgumentNullException("enumerable");
		}
		if (collectionFactory().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		XbimMultiValueDictionary<TKey, TValue> xbimMultiValueDictionary = new XbimMultiValueDictionary<TKey, TValue>();
		xbimMultiValueDictionary.NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory;
		foreach (KeyValuePair<TKey, ICollection<TValue>> item in enumerable)
		{
			xbimMultiValueDictionary.AddRange(item.Key, item.Value);
		}
		return xbimMultiValueDictionary;
	}

	public static XbimMultiValueDictionary<TKey, TValue> Create<TValueCollection>(IEnumerable<KeyValuePair<TKey, ICollection<TValue>>> enumerable, IEqualityComparer<TKey> comparer, Func<TValueCollection> collectionFactory) where TValueCollection : ICollection<TValue>
	{
		if (enumerable == null)
		{
			throw new ArgumentNullException("enumerable");
		}
		if (collectionFactory().IsReadOnly)
		{
			throw new InvalidOperationException("Properties.Resources.Create_TValueCollectionReadOnly");
		}
		XbimMultiValueDictionary<TKey, TValue> xbimMultiValueDictionary = new XbimMultiValueDictionary<TKey, TValue>(comparer);
		xbimMultiValueDictionary.NewCollectionFactory = (Func<ICollection<TValue>>)(object)collectionFactory;
		foreach (KeyValuePair<TKey, ICollection<TValue>> item in enumerable)
		{
			xbimMultiValueDictionary.AddRange(item.Key, item.Value);
		}
		return xbimMultiValueDictionary;
	}

	public void Add(TKey key, TValue value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (!dictionary.TryGetValue(key, out var value2))
		{
			value2 = new InnerCollectionView(key, NewCollectionFactory());
			dictionary.Add(key, value2);
		}
		value2.AddValue(value);
		version++;
	}

	public void AddRange(TKey key, IEnumerable<TValue> values)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (!dictionary.TryGetValue(key, out var value))
		{
			value = new InnerCollectionView(key, NewCollectionFactory());
			dictionary.Add(key, value);
		}
		foreach (TValue value2 in values)
		{
			value.AddValue(value2);
		}
		version++;
	}

	public void Add(TKey key, ICollection<TValue> value)
	{
		AddRange(key, value);
	}

	public bool Remove(TKey key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (dictionary.TryGetValue(key, out var _) && dictionary.Remove(key))
		{
			version++;
			return true;
		}
		return false;
	}

	public bool Remove(TKey key, TValue value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (dictionary.TryGetValue(key, out var value2) && value2.RemoveValue(value))
		{
			if (value2.Count == 0)
			{
				dictionary.Remove(key);
			}
			version++;
			return true;
		}
		return false;
	}

	public bool Contains(TKey key, TValue value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (dictionary.TryGetValue(key, out var value2))
		{
			return value2.Contains(value);
		}
		return false;
	}

	public bool ContainsValue(TValue value)
	{
		foreach (InnerCollectionView value2 in dictionary.Values)
		{
			if (value2.Contains(value))
			{
				return true;
			}
		}
		return false;
	}

	public void Add(KeyValuePair<TKey, ICollection<TValue>> item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		dictionary.Clear();
		version++;
	}

	public bool Contains(KeyValuePair<TKey, ICollection<TValue>> item)
	{
		throw new NotImplementedException();
	}

	public void CopyTo(KeyValuePair<TKey, ICollection<TValue>>[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex");
		}
		if (array.Length - arrayIndex < Count)
		{
			throw new ArgumentException("Not enough elements after arrayIndex in the destination array.");
		}
		for (int i = 0; i < Count; i++)
		{
			array[i + arrayIndex] = this.ElementAt(i);
		}
	}

	public bool Remove(KeyValuePair<TKey, ICollection<TValue>> item)
	{
		throw new NotImplementedException();
	}

	public bool ContainsKey(TKey key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		return dictionary.ContainsKey(key);
	}

	public bool TryGetValue(TKey key, out ICollection<TValue> value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		InnerCollectionView value2;
		bool result = dictionary.TryGetValue(key, out value2);
		value = value2;
		return result;
	}

	IEnumerator<KeyValuePair<TKey, ICollection<TValue>>> IEnumerable<KeyValuePair<TKey, ICollection<TValue>>>.GetEnumerator()
	{
		return new Enumerator(this);
	}

	public IEnumerator<KeyValuePair<TKey, ICollection<TValue>>> GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this);
	}
}
