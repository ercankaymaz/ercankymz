using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Metadata;

namespace Microsoft.Windows.Design.Model;

public abstract class ModelItemDictionary : ModelItem, IDictionary<ModelItem, ModelItem>, ICollection<KeyValuePair<ModelItem, ModelItem>>, IEnumerable<KeyValuePair<ModelItem, ModelItem>>, IDictionary, ICollection, IEnumerable, INotifyCollectionChanged
{
	private struct DictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		private IEnumerator<KeyValuePair<ModelItem, ModelItem>> _real;

		public DictionaryEntry Entry => new DictionaryEntry(_real.Current.Key, _real.Current.Value);

		public object Key => _real.Current.Key;

		public object Value => _real.Current.Value;

		public object Current => Entry;

		internal DictionaryEnumerator(IEnumerator<KeyValuePair<ModelItem, ModelItem>> real)
		{
			_real = real;
		}

		public bool MoveNext()
		{
			return _real.MoveNext();
		}

		public void Reset()
		{
			_real.Reset();
		}
	}

	public static readonly PropertyIdentifier KeyProperty = new PropertyIdentifier(typeof(ModelItemDictionary), "Key");

	public abstract ModelItem this[ModelItem key] { get; set; }

	public abstract ModelItem this[object key] { get; set; }

	public abstract int Count { get; }

	protected virtual bool IsFixedSize => IsReadOnly;

	public abstract bool IsReadOnly { get; }

	protected virtual bool IsSynchronized => false;

	public abstract ICollection<ModelItem> Keys { get; }

	protected virtual object SyncRoot => this;

	public abstract ICollection<ModelItem> Values { get; }

	bool IDictionary.IsFixedSize => IsFixedSize;

	bool IDictionary.IsReadOnly => IsReadOnly;

	ICollection IDictionary.Keys
	{
		get
		{
			object[] array = new object[Count];
			int num = 0;
			using IEnumerator<KeyValuePair<ModelItem, ModelItem>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<ModelItem, ModelItem> current = enumerator.Current;
				array[num++] = current.Key;
			}
			return array;
		}
	}

	ICollection IDictionary.Values
	{
		get
		{
			object[] array = new object[Count];
			int num = 0;
			using IEnumerator<KeyValuePair<ModelItem, ModelItem>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<ModelItem, ModelItem> current = enumerator.Current;
				array[num++] = current.Value;
			}
			return array;
		}
	}

	object IDictionary.this[object key]
	{
		get
		{
			return this[ConvertType(key)];
		}
		set
		{
			this[ConvertType(key)] = ConvertType(value);
		}
	}

	int ICollection.Count => Count;

	bool ICollection.IsSynchronized => IsSynchronized;

	object ICollection.SyncRoot => SyncRoot;

	public abstract event NotifyCollectionChangedEventHandler CollectionChanged;

	public abstract void Add(ModelItem key, ModelItem value);

	public abstract ModelItem Add(object key, object value);

	public abstract void Clear();

	protected virtual void CopyTo(KeyValuePair<ModelItem, ModelItem>[] array, int arrayIndex)
	{
		using IEnumerator<KeyValuePair<ModelItem, ModelItem>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<ModelItem, ModelItem> current = enumerator.Current;
			array[arrayIndex++] = current;
		}
	}

	protected virtual bool Contains(KeyValuePair<ModelItem, ModelItem> item)
	{
		if (TryGetValue(item.Key, out var value))
		{
			return value == item.Value;
		}
		return false;
	}

	public abstract bool ContainsKey(ModelItem key);

	public abstract bool ContainsKey(object key);

	private static ModelItem ConvertType(object value)
	{
		try
		{
			return (ModelItem)value;
		}
		catch (InvalidCastException)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ArgIncorrectType, new object[2]
			{
				"value",
				typeof(ModelItem).FullName
			}));
		}
	}

	public abstract IEnumerator<KeyValuePair<ModelItem, ModelItem>> GetEnumerator();

	public abstract bool Remove(ModelItem key);

	public abstract bool Remove(object key);

	public abstract bool TryGetValue(ModelItem key, out ModelItem value);

	public abstract bool TryGetValue(object key, out ModelItem value);

	void IDictionary.Add(object key, object value)
	{
		Add(key, value);
	}

	void IDictionary.Clear()
	{
		Clear();
	}

	bool IDictionary.Contains(object key)
	{
		return ContainsKey(key);
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new DictionaryEnumerator(GetEnumerator());
	}

	void IDictionary.Remove(object key)
	{
		Remove(key);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		if (Count > 0)
		{
			int length = array.GetLength(0);
			if (index >= length)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_InvalidArrayIndex, new object[1] { index }));
			}
			KeyValuePair<ModelItem, ModelItem>[] array2 = new KeyValuePair<ModelItem, ModelItem>[length];
			CopyTo(array2, index);
			while (index < array2.Length)
			{
				array.SetValue(array2[index], index);
				index++;
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		using IEnumerator<KeyValuePair<ModelItem, ModelItem>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<ModelItem, ModelItem> kv = enumerator.Current;
			yield return kv;
		}
	}

	void ICollection<KeyValuePair<ModelItem, ModelItem>>.Add(KeyValuePair<ModelItem, ModelItem> item)
	{
		Add(item.Key, item.Value);
	}

	bool ICollection<KeyValuePair<ModelItem, ModelItem>>.Contains(KeyValuePair<ModelItem, ModelItem> item)
	{
		return Contains(item);
	}

	void ICollection<KeyValuePair<ModelItem, ModelItem>>.CopyTo(KeyValuePair<ModelItem, ModelItem>[] array, int arrayIndex)
	{
		if (arrayIndex >= array.Length)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_InvalidArrayIndex, new object[1] { arrayIndex }));
		}
		CopyTo(array, arrayIndex);
	}

	bool ICollection<KeyValuePair<ModelItem, ModelItem>>.Remove(KeyValuePair<ModelItem, ModelItem> item)
	{
		if (TryGetValue(item.Key, out var value) && value == item.Value)
		{
			return Remove(item.Key);
		}
		return false;
	}
}
