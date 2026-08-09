using System.Runtime.InteropServices;
using System.ServiceModel;

namespace System.Collections.Generic;

[ComVisible(false)]
public abstract class SynchronizedKeyedCollection<K, T> : SynchronizedCollection<T>
{
	private const int defaultThreshold = 0;

	private IEqualityComparer<K> _comparer;

	private Dictionary<K, T> _dictionary;

	private int _keyCount;

	private int _threshold;

	public T this[K key]
	{
		get
		{
			if (key == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("key"));
			}
			lock (base.SyncRoot)
			{
				if (_dictionary != null)
				{
					return _dictionary[key];
				}
				for (int i = 0; i < base.Items.Count; i++)
				{
					T val = base.Items[i];
					if (_comparer.Equals(key, GetKeyForItem(val)))
					{
						return val;
					}
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new KeyNotFoundException());
			}
		}
	}

	protected IDictionary<K, T> Dictionary => _dictionary;

	protected SynchronizedKeyedCollection()
	{
		_comparer = EqualityComparer<K>.Default;
		_threshold = int.MaxValue;
	}

	protected SynchronizedKeyedCollection(object syncRoot)
		: base(syncRoot)
	{
		_comparer = EqualityComparer<K>.Default;
		_threshold = int.MaxValue;
	}

	protected SynchronizedKeyedCollection(object syncRoot, IEqualityComparer<K> comparer)
		: base(syncRoot)
	{
		_comparer = comparer ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("comparer"));
		_threshold = int.MaxValue;
	}

	protected SynchronizedKeyedCollection(object syncRoot, IEqualityComparer<K> comparer, int dictionaryCreationThreshold)
		: base(syncRoot)
	{
		if (dictionaryCreationThreshold < -1)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("dictionaryCreationThreshold", dictionaryCreationThreshold, System.SR.Format(System.SR.ValueMustBeInRange, -1, int.MaxValue)));
		}
		if (dictionaryCreationThreshold == -1)
		{
			_threshold = int.MaxValue;
		}
		else
		{
			_threshold = dictionaryCreationThreshold;
		}
		_comparer = comparer ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("comparer"));
	}

	private void AddKey(K key, T item)
	{
		if (_dictionary != null)
		{
			_dictionary.Add(key, item);
			return;
		}
		if (_keyCount == _threshold)
		{
			CreateDictionary();
			_dictionary.Add(key, item);
			return;
		}
		if (Contains(key))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.CannotAddTwoItemsWithTheSameKeyToSynchronizedKeyedCollection0));
		}
		_keyCount++;
	}

	protected void ChangeItemKey(T item, K newKey)
	{
		if (!ContainsItem(item))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.ItemDoesNotExistInSynchronizedKeyedCollection0));
		}
		K keyForItem = GetKeyForItem(item);
		if (!_comparer.Equals(newKey, keyForItem))
		{
			if (newKey != null)
			{
				AddKey(newKey, item);
			}
			if (keyForItem != null)
			{
				RemoveKey(keyForItem);
			}
		}
	}

	protected override void ClearItems()
	{
		base.ClearItems();
		if (_dictionary != null)
		{
			_dictionary.Clear();
		}
		_keyCount = 0;
	}

	public bool Contains(K key)
	{
		if (key == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("key"));
		}
		lock (base.SyncRoot)
		{
			if (_dictionary != null)
			{
				return _dictionary.ContainsKey(key);
			}
			if (key != null)
			{
				for (int i = 0; i < base.Items.Count; i++)
				{
					T item = base.Items[i];
					if (_comparer.Equals(key, GetKeyForItem(item)))
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	private bool ContainsItem(T item)
	{
		K keyForItem;
		if (_dictionary == null || (keyForItem = GetKeyForItem(item)) == null)
		{
			return base.Items.Contains(item);
		}
		if (_dictionary.TryGetValue(keyForItem, out var value))
		{
			return EqualityComparer<T>.Default.Equals(item, value);
		}
		return false;
	}

	private void CreateDictionary()
	{
		_dictionary = new Dictionary<K, T>(_comparer);
		foreach (T item in base.Items)
		{
			K keyForItem = GetKeyForItem(item);
			if (keyForItem != null)
			{
				_dictionary.Add(keyForItem, item);
			}
		}
	}

	protected abstract K GetKeyForItem(T item);

	protected override void InsertItem(int index, T item)
	{
		K keyForItem = GetKeyForItem(item);
		if (keyForItem != null)
		{
			AddKey(keyForItem, item);
		}
		base.InsertItem(index, item);
	}

	public bool Remove(K key)
	{
		if (key == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("key"));
		}
		lock (base.SyncRoot)
		{
			if (_dictionary != null)
			{
				if (_dictionary.ContainsKey(key))
				{
					return Remove(_dictionary[key]);
				}
				return false;
			}
			for (int i = 0; i < base.Items.Count; i++)
			{
				if (_comparer.Equals(key, GetKeyForItem(base.Items[i])))
				{
					RemoveItem(i);
					return true;
				}
			}
			return false;
		}
	}

	protected override void RemoveItem(int index)
	{
		K keyForItem = GetKeyForItem(base.Items[index]);
		if (keyForItem != null)
		{
			RemoveKey(keyForItem);
		}
		base.RemoveItem(index);
	}

	private void RemoveKey(K key)
	{
		if (key == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("key");
		}
		if (_dictionary != null)
		{
			_dictionary.Remove(key);
		}
		else
		{
			_keyCount--;
		}
	}

	protected override void SetItem(int index, T item)
	{
		K keyForItem = GetKeyForItem(item);
		K keyForItem2 = GetKeyForItem(base.Items[index]);
		if (_comparer.Equals(keyForItem, keyForItem2))
		{
			if (keyForItem != null && _dictionary != null)
			{
				_dictionary[keyForItem] = item;
			}
		}
		else
		{
			if (keyForItem != null)
			{
				AddKey(keyForItem, item);
			}
			if (keyForItem2 != null)
			{
				RemoveKey(keyForItem2);
			}
		}
		base.SetItem(index, item);
	}
}
