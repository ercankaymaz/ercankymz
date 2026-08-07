// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.BoundListBase`1
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable
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

  public int BeginAddNew()
  {
    this.mEditItem = (object) this.mEditItem == null ? this.OnAddNew() : throw new DevAgeApplicationException("There is already a row in editing state, call EndEdit first");
    this.mEditIndex = this.Count - 1;
    this.mAdding = true;
    this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, this.mEditIndex));
    return this.mEditIndex;
  }

  public void BeginEdit(int index)
  {
    this.mEditItem = (object) this.mEditItem == null ? (T) this[index] : throw new DevAgeApplicationException("There is already a row in editing state, call EndEdit first");
    this.mEditIndex = index;
  }

  public void EndEdit(bool cancel)
  {
    if ((object) this.mEditItem == null)
      return;
    if (cancel)
    {
      if (this.mAdding)
      {
        this.RemoveAt(this.mEditIndex);
      }
      else
      {
        foreach (KeyValuePair<PropertyDescriptor, object> mPreviousValue in this.mPreviousValues)
          mPreviousValue.Key.SetValue((object) this.mEditItem, mPreviousValue.Value);
      }
    }
    else if (this.mAdding)
      this.mAddedItems.Add(this.mEditItem);
    else if ((this.mEditedItems.Contains(this.mEditItem) ? 0 : (!this.mAddedItems.Contains(this.mEditItem) ? 1 : 0)) != 0)
      this.mEditedItems.Add(this.mEditItem);
    this.mEditItem = default (T);
    this.mAdding = false;
    this.mEditIndex = -1;
    this.mPreviousValues.Clear();
    this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
  }

  public object EditedObject => (object) this.mEditItem;

  public void RemoveAt(int index)
  {
    T obj = (T) this[index];
    this.OnRemoveAt(index);
    if (this.mAddedItems.Contains(obj))
    {
      this.mAddedItems.Remove(obj);
    }
    else
    {
      if (this.mEditedItems.Contains(obj))
        this.mEditedItems.Remove(obj);
      this.mRemovedItems.Add(obj);
    }
    this.OnItemDeleted(new ItemDeletedEventArgs((object) obj));
    this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
  }

  public void Clear()
  {
    this.mEditedItems.Clear();
    this.mAddedItems.Clear();
    this.mEditedItems.Clear();
    this.mEditItem = default (T);
    this.mAdding = false;
    this.mEditIndex = -1;
    this.mPreviousValues.Clear();
    this.OnListCleared(EventArgs.Empty);
    this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
  }

  public PropertyDescriptorCollection GetItemProperties()
  {
    return TypeDescriptor.GetProperties(typeof (T));
  }

  public object GetItemValue(int index, PropertyDescriptor property)
  {
    return property.GetValue(this[index]);
  }

  public void SetEditValue(PropertyDescriptor property, object value)
  {
    if ((object) this.mEditItem == null)
      throw new DevAgeApplicationException("There isn't a row in editing state, call BeginAddNew or BeginEdit first");
    if (!this.mPreviousValues.ContainsKey(property))
      this.mPreviousValues.Add(property, property.GetValue((object) this.mEditItem));
    property.SetValue((object) this.mEditItem, value);
    this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.mEditIndex, property));
  }

  public bool AllowEdit
  {
    get => this.mAllowEdit;
    set => this.mAllowEdit = value;
  }

  public bool AllowNew
  {
    get => this.mAllowNew;
    set => this.mAllowNew = value;
  }

  public bool AllowDelete
  {
    get => this.mAllowDelete;
    set => this.mAllowDelete = value;
  }

  public bool AllowSort
  {
    get => this.mAllowSort;
    set => this.mAllowSort = value;
  }

  public List<T> AddedItems => this.mAddedItems;

  public List<T> RemovedItems => this.mRemovedItems;

  public List<T> EditedItems => this.mEditedItems;

  public PropertyDescriptor GetItemProperty(string name, StringComparison comparison)
  {
    PropertyDescriptor itemProperty1;
    foreach (PropertyDescriptor itemProperty2 in this.GetItemProperties())
    {
      if (itemProperty2.Name.Equals(name, comparison))
      {
        itemProperty1 = itemProperty2;
        goto label_9;
      }
    }
    itemProperty1 = (PropertyDescriptor) null;
label_9:
    return itemProperty1;
  }

  public event ListChangedEventHandler ListChanged;

  protected virtual void OnListChanged(ListChangedEventArgs e)
  {
    if (this.ListChanged == null)
      return;
    this.ListChanged((object) this, e);
  }

  public event EventHandler ListCleared;

  protected virtual void OnListCleared(EventArgs e)
  {
    if (this.ListCleared == null)
      return;
    this.ListCleared((object) this, e);
  }

  public event ItemDeletedEventHandler ItemDeleted;

  protected virtual void OnItemDeleted(ItemDeletedEventArgs e)
  {
    if (this.ItemDeleted == null)
      return;
    this.ItemDeleted((object) this, e);
  }

  protected abstract T OnAddNew();

  public abstract int IndexOf(object item);

  protected abstract void OnRemoveAt(int index);

  protected abstract void OnClear();

  public abstract object this[int index] { get; }

  public abstract int Count { get; }

  public abstract void ApplySort(ListSortDescriptionCollection sorts);
}
