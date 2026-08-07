// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.BoundDataView
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;

#nullable disable
namespace DevAge.ComponentModel;

[Serializable]
public class BoundDataView : IBoundList
{
  private DataView m_dataView;
  private DataTable m_dataTable;
  private DataRowView mEditingRow;
  private bool mAllowEdit = true;
  private bool mAllowNew = true;
  private bool mAllowDelete = true;
  private bool mAllowSort = true;

  [Obsolete("Use property DataView instead")]
  public DataView mDataView => this.mDataView;

  [Obsolete("Use property DataTable instead")]
  public DataTable mDataTable => this.mDataTable;

  public DataView DataView => this.m_dataView;

  public DataTable DataTable => this.m_dataTable;

  public BoundDataView(DataView dataView)
  {
    this.m_dataView = dataView;
    this.m_dataView.ListChanged += new ListChangedEventHandler(this.m_dataView_ListChanged);
    this.m_dataTable = this.m_dataView.Table;
    if (this.m_dataTable == null)
      return;
    this.m_dataTable.TableCleared += new DataTableClearEventHandler(this.m_dataTable_TableCleared);
    this.m_dataTable.RowDeleted += new DataRowChangeEventHandler(this.m_dataTable_RowDeleted);
  }

  ~BoundDataView()
  {
    if (this.m_dataTable == null)
      return;
    this.m_dataTable.TableCleared -= new DataTableClearEventHandler(this.m_dataTable_TableCleared);
    this.m_dataTable.RowDeleted -= new DataRowChangeEventHandler(this.m_dataTable_RowDeleted);
  }

  public event ListChangedEventHandler ListChanged;

  protected virtual void OnListChanged(ListChangedEventArgs e)
  {
    if (this.ListChanged == null)
      return;
    this.ListChanged((object) this, e);
  }

  private void m_dataView_ListChanged(object sender, ListChangedEventArgs e)
  {
    this.OnListChanged(e);
  }

  public event EventHandler ListCleared;

  protected virtual void OnListCleared(EventArgs e)
  {
    if (this.ListCleared == null)
      return;
    this.ListCleared((object) this, e);
  }

  private void m_dataTable_TableCleared(object sender, DataTableClearEventArgs e)
  {
    this.OnListCleared(EventArgs.Empty);
  }

  public event ItemDeletedEventHandler ItemDeleted;

  protected virtual void OnItemDeleted(ItemDeletedEventArgs e)
  {
    if (this.ItemDeleted == null)
      return;
    this.ItemDeleted((object) this, e);
  }

  private void m_dataTable_RowDeleted(object sender, DataRowChangeEventArgs e)
  {
    this.OnItemDeleted(new ItemDeletedEventArgs((object) e.Row));
  }

  public virtual int BeginAddNew()
  {
    this.mEditingRow = this.mEditingRow == null ? this.m_dataView.AddNew() : throw new DevAgeApplicationException("There is already a row in editing state, call EndEdit first");
    this.mEditingRow.BeginEdit();
    return ((IList) this.m_dataView).IndexOf((object) this.mEditingRow);
  }

  public virtual void BeginEdit(int index)
  {
    this.mEditingRow = this.mEditingRow == null ? this.m_dataView[index] : throw new DevAgeApplicationException("There is already a row in editing state, call EndEdit first");
    this.mEditingRow.BeginEdit();
  }

  public virtual void EndEdit(bool cancel)
  {
    if (this.mEditingRow == null)
      return;
    if (cancel)
      this.mEditingRow.CancelEdit();
    else
      this.mEditingRow.EndEdit();
    this.mEditingRow = (DataRowView) null;
    if (!cancel)
      return;
    this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
  }

  public virtual object EditedObject => (object) this.mEditingRow;

  public virtual int IndexOf(object item) => ((IList) this.m_dataView).IndexOf(item);

  public virtual void RemoveAt(int index) => this.m_dataView[index].Delete();

  public virtual object this[int index]
  {
    get
    {
      if (index > this.m_dataView.Table.Rows.Count)
        throw new ArgumentException($"Data table does not have row with given index. It has only {this.m_dataView.Table.Rows.Count} number of rows,you requested to return row number {index}");
      try
      {
        return (object) this.m_dataView[index];
      }
      catch (InvalidOperationException ex)
      {
        return (object) null;
      }
    }
  }

  public virtual int Count => this.m_dataView.Count;

  public virtual PropertyDescriptorCollection GetItemProperties()
  {
    return this.m_dataView != null ? ((ITypedList) this.m_dataView).GetItemProperties((PropertyDescriptor[]) null) : new PropertyDescriptorCollection((PropertyDescriptor[]) null);
  }

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

  public virtual object GetItemValue(int index, PropertyDescriptor property)
  {
    object obj = property.GetValue((object) this.m_dataView[index]);
    return DBNull.Value != obj ? obj : (object) null;
  }

  public virtual void SetEditValue(PropertyDescriptor property, object value)
  {
    if (value == null)
      value = (object) DBNull.Value;
    if (this.mEditingRow == null)
      throw new DevAgeApplicationException("There isn't a row in editing state, call BeginAddNew or BeginEdit first");
    property.SetValue((object) this.mEditingRow, value);
  }

  public virtual void ApplySort(ListSortDescriptionCollection sorts)
  {
    IBindingListView dataView = (IBindingListView) this.m_dataView;
    if ((sorts == null ? 0 : (sorts.Count > 0 ? 1 : 0)) != 0)
      dataView.ApplySort(sorts);
    else
      dataView.RemoveSort();
  }

  public virtual bool AllowEdit
  {
    get => this.m_dataView.AllowEdit && this.mAllowEdit;
    set => this.mAllowEdit = value;
  }

  public virtual bool AllowNew
  {
    get => this.m_dataView.AllowNew && this.mAllowNew;
    set => this.mAllowNew = value;
  }

  public virtual bool AllowDelete
  {
    get => this.m_dataView.AllowDelete && this.mAllowDelete;
    set => this.mAllowDelete = value;
  }

  public virtual bool AllowSort
  {
    get => this.mAllowSort;
    set => this.mAllowSort = value;
  }
}
