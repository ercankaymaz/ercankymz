using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DevAge.ComponentModel;

[Serializable]
public abstract class BoundListBase<T> : IBoundList
{
	private int mEditIndex;

	private T mEditItem;

	private bool mAdding = false;

	private Dictionary<PropertyDescriptor, object> mPreviousValues = new Dictionary<PropertyDescriptor, object>();

	private bool mAllowEdit = false;

	private bool mAllowNew = false;

	private bool mAllowDelete = false;

	private bool mAllowSort = false;

	private List<T> mAddedItems = new List<T>();

	private List<T> mRemovedItems = new List<T>();

	private List<T> mEditedItems = new List<T>();

	public object EditedObject => mEditItem;

	public bool AllowEdit
	{
		get
		{
			return mAllowEdit;
		}
		set
		{
			mAllowEdit = value;
		}
	}

	public bool AllowNew
	{
		get
		{
			return mAllowNew;
		}
		set
		{
			mAllowNew = value;
		}
	}

	public bool AllowDelete
	{
		get
		{
			return mAllowDelete;
		}
		set
		{
			mAllowDelete = value;
		}
	}

	public bool AllowSort
	{
		get
		{
			return mAllowSort;
		}
		set
		{
			mAllowSort = value;
		}
	}

	public List<T> AddedItems => mAddedItems;

	public List<T> RemovedItems => mRemovedItems;

	public List<T> EditedItems => mEditedItems;

	public abstract object this[int index] { get; }

	public abstract int Count { get; }

	public event ListChangedEventHandler ListChanged;

	public event EventHandler ListCleared;

	public event ItemDeletedEventHandler ItemDeleted;

	public int BeginAddNew()
	{
		if (mEditItem != null)
		{
			throw new DevAgeApplicationException("There is already a row in editing state, call EndEdit first");
		}
		mEditItem = OnAddNew();
		mEditIndex = Count - 1;
		mAdding = true;
		OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, mEditIndex));
		return mEditIndex;
	}

	public void BeginEdit(int index)
	{
		if (mEditItem != null)
		{
			throw new DevAgeApplicationException("There is already a row in editing state, call EndEdit first");
		}
		mEditItem = (T)this[index];
		mEditIndex = index;
	}

	public void EndEdit(bool cancel)
	{
		if (mEditItem == null)
		{
			return;
		}
		if (!cancel)
		{
			if (!mAdding)
			{
				if (!mEditedItems.Contains(mEditItem) && !mAddedItems.Contains(mEditItem))
				{
					mEditedItems.Add(mEditItem);
				}
			}
			else
			{
				mAddedItems.Add(mEditItem);
			}
		}
		else if (!mAdding)
		{
			foreach (KeyValuePair<PropertyDescriptor, object> mPreviousValue in mPreviousValues)
			{
				mPreviousValue.Key.SetValue(mEditItem, mPreviousValue.Value);
			}
		}
		else
		{
			RemoveAt(mEditIndex);
		}
		mEditItem = default(T);
		mAdding = false;
		mEditIndex = -1;
		mPreviousValues.Clear();
		OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
	}

	public void RemoveAt(int index)
	{
		T val = (T)this[index];
		OnRemoveAt(index);
		if (!mAddedItems.Contains(val))
		{
			if (mEditedItems.Contains(val))
			{
				mEditedItems.Remove(val);
			}
			mRemovedItems.Add(val);
		}
		else
		{
			mAddedItems.Remove(val);
		}
		OnItemDeleted(new ItemDeletedEventArgs(val));
		OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
	}

	public void Clear()
	{
		mEditedItems.Clear();
		mAddedItems.Clear();
		mEditedItems.Clear();
		mEditItem = default(T);
		mAdding = false;
		mEditIndex = -1;
		mPreviousValues.Clear();
		OnListCleared(EventArgs.Empty);
		OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
	}

	public PropertyDescriptorCollection GetItemProperties()
	{
		return TypeDescriptor.GetProperties(typeof(T));
	}

	public object GetItemValue(int index, PropertyDescriptor property)
	{
		return property.GetValue(this[index]);
	}

	public void SetEditValue(PropertyDescriptor property, object value)
	{
		if (mEditItem != null)
		{
			if (!mPreviousValues.ContainsKey(property))
			{
				mPreviousValues.Add(property, property.GetValue(mEditItem));
			}
			property.SetValue(mEditItem, value);
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, mEditIndex, property));
			return;
		}
		throw new DevAgeApplicationException("There isn't a row in editing state, call BeginAddNew or BeginEdit first");
	}

	public PropertyDescriptor GetItemProperty(string name, StringComparison comparison)
	{
		foreach (PropertyDescriptor itemProperty in GetItemProperties())
		{
			if (itemProperty.Name.Equals(name, comparison))
			{
				return itemProperty;
			}
		}
		return null;
	}

	protected virtual void OnListChanged(ListChangedEventArgs e)
	{
		if (this.ListChanged != null)
		{
			this.ListChanged(this, e);
		}
	}

	protected virtual void OnListCleared(EventArgs e)
	{
		if (this.ListCleared != null)
		{
			this.ListCleared(this, e);
		}
	}

	protected virtual void OnItemDeleted(ItemDeletedEventArgs e)
	{
		if (this.ItemDeleted != null)
		{
			this.ItemDeleted(this, e);
		}
	}

	protected abstract T OnAddNew();

	public abstract int IndexOf(object item);

	protected abstract void OnRemoveAt(int index);

	protected abstract void OnClear();

	public abstract void ApplySort(ListSortDescriptionCollection sorts);
}
