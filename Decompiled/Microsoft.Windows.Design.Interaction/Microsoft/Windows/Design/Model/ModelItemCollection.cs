using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Metadata;

namespace Microsoft.Windows.Design.Model;

public abstract class ModelItemCollection : ModelItem, IList<ModelItem>, ICollection<ModelItem>, IEnumerable<ModelItem>, IList, ICollection, IEnumerable, INotifyCollectionChanged
{
	public static readonly PropertyIdentifier ItemProperty = new PropertyIdentifier(typeof(ModelItemCollection), "Item");

	public abstract ModelItem this[int index] { get; set; }

	public abstract int Count { get; }

	protected virtual bool IsFixedSize => IsReadOnly;

	public abstract bool IsReadOnly { get; }

	protected virtual bool IsSynchronized => false;

	protected virtual object SyncRoot => this;

	bool IList.IsFixedSize => IsFixedSize;

	bool IList.IsReadOnly => IsReadOnly;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			this[index] = ConvertType(value);
		}
	}

	int ICollection.Count => Count;

	bool ICollection.IsSynchronized => IsSynchronized;

	object ICollection.SyncRoot => SyncRoot;

	public abstract event NotifyCollectionChangedEventHandler CollectionChanged;

	public abstract void Add(ModelItem item);

	public abstract ModelItem Add(object value);

	public abstract void Clear();

	public abstract bool Contains(ModelItem item);

	public abstract bool Contains(object value);

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

	public abstract void CopyTo(ModelItem[] array, int arrayIndex);

	public abstract IEnumerator<ModelItem> GetEnumerator();

	public abstract int IndexOf(ModelItem item);

	public abstract void Insert(int index, ModelItem item);

	public abstract ModelItem Insert(int index, object value);

	public abstract void Move(int fromIndex, int toIndex);

	public abstract bool Remove(ModelItem item);

	public abstract bool Remove(object value);

	public abstract void RemoveAt(int index);

	int IList.Add(object value)
	{
		Add(value);
		return Count - 1;
	}

	void IList.Clear()
	{
		Clear();
	}

	bool IList.Contains(object value)
	{
		return Contains(value);
	}

	int IList.IndexOf(object value)
	{
		return IndexOf(ConvertType(value));
	}

	void IList.Insert(int index, object value)
	{
		Insert(index, value);
	}

	void IList.Remove(object value)
	{
		Remove(value);
	}

	void IList.RemoveAt(int index)
	{
		RemoveAt(index);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		for (int i = 0; i < Count; i++)
		{
			array.SetValue(this[i], i + index);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		using IEnumerator<ModelItem> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			yield return enumerator.Current;
		}
	}
}
