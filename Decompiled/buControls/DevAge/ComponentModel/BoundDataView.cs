using System;
using System.Collections;
using System.ComponentModel;
using System.Data;

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
	public DataView mDataView => mDataView;

	[Obsolete("Use property DataTable instead")]
	public DataTable mDataTable => mDataTable;

	public DataView DataView => m_dataView;

	public DataTable DataTable => m_dataTable;

	public virtual object EditedObject => mEditingRow;

	public virtual object this[int index]
	{
		get
		{
			if (index <= m_dataView.Table.Rows.Count)
			{
				try
				{
					return m_dataView[index];
				}
				catch (InvalidOperationException)
				{
					return null;
				}
			}
			throw new ArgumentException($"Data table does not have row with given index. It has only {m_dataView.Table.Rows.Count} number of rows,you requested to return row number {index}");
		}
	}

	public virtual int Count => m_dataView.Count;

	public virtual bool AllowEdit
	{
		get
		{
			return m_dataView.AllowEdit && mAllowEdit;
		}
		set
		{
			mAllowEdit = value;
		}
	}

	public virtual bool AllowNew
	{
		get
		{
			return m_dataView.AllowNew && mAllowNew;
		}
		set
		{
			mAllowNew = value;
		}
	}

	public virtual bool AllowDelete
	{
		get
		{
			return m_dataView.AllowDelete && mAllowDelete;
		}
		set
		{
			mAllowDelete = value;
		}
	}

	public virtual bool AllowSort
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

	public event ListChangedEventHandler ListChanged;

	public event EventHandler ListCleared;

	public event ItemDeletedEventHandler ItemDeleted;

	public BoundDataView(DataView dataView)
	{
		m_dataView = dataView;
		m_dataView.ListChanged += m_dataView_ListChanged;
		m_dataTable = m_dataView.Table;
		if (m_dataTable != null)
		{
			m_dataTable.TableCleared += m_dataTable_TableCleared;
			m_dataTable.RowDeleted += m_dataTable_RowDeleted;
		}
	}

	~BoundDataView()
	{
		if (m_dataTable != null)
		{
			m_dataTable.TableCleared -= m_dataTable_TableCleared;
			m_dataTable.RowDeleted -= m_dataTable_RowDeleted;
		}
	}

	protected virtual void OnListChanged(ListChangedEventArgs e)
	{
		if (this.ListChanged != null)
		{
			this.ListChanged(this, e);
		}
	}

	private void m_dataView_ListChanged(object sender, ListChangedEventArgs e)
	{
		OnListChanged(e);
	}

	protected virtual void OnListCleared(EventArgs e)
	{
		if (this.ListCleared != null)
		{
			this.ListCleared(this, e);
		}
	}

	private void m_dataTable_TableCleared(object sender, DataTableClearEventArgs e)
	{
		OnListCleared(EventArgs.Empty);
	}

	protected virtual void OnItemDeleted(ItemDeletedEventArgs e)
	{
		if (this.ItemDeleted != null)
		{
			this.ItemDeleted(this, e);
		}
	}

	private void m_dataTable_RowDeleted(object sender, DataRowChangeEventArgs e)
	{
		OnItemDeleted(new ItemDeletedEventArgs(e.Row));
	}

	public virtual int BeginAddNew()
	{
		if (mEditingRow != null)
		{
			throw new DevAgeApplicationException("There is already a row in editing state, call EndEdit first");
		}
		mEditingRow = m_dataView.AddNew();
		mEditingRow.BeginEdit();
		IList dataView = m_dataView;
		return dataView.IndexOf(mEditingRow);
	}

	public virtual void BeginEdit(int index)
	{
		if (mEditingRow != null)
		{
			throw new DevAgeApplicationException("There is already a row in editing state, call EndEdit first");
		}
		mEditingRow = m_dataView[index];
		mEditingRow.BeginEdit();
	}

	public virtual void EndEdit(bool cancel)
	{
		if (mEditingRow != null)
		{
			if (!cancel)
			{
				mEditingRow.EndEdit();
			}
			else
			{
				mEditingRow.CancelEdit();
			}
			mEditingRow = null;
			if (cancel)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
			}
		}
	}

	public virtual int IndexOf(object item)
	{
		IList dataView = m_dataView;
		return dataView.IndexOf(item);
	}

	public virtual void RemoveAt(int index)
	{
		m_dataView[index].Delete();
	}

	public virtual PropertyDescriptorCollection GetItemProperties()
	{
		if (m_dataView != null)
		{
			return ((ITypedList)m_dataView).GetItemProperties((PropertyDescriptor[])null);
		}
		return new PropertyDescriptorCollection(null);
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

	public virtual object GetItemValue(int index, PropertyDescriptor property)
	{
		object value = property.GetValue(m_dataView[index]);
		if (DBNull.Value != value)
		{
			return value;
		}
		return null;
	}

	public virtual void SetEditValue(PropertyDescriptor property, object value)
	{
		if (value == null)
		{
			value = DBNull.Value;
		}
		if (mEditingRow == null)
		{
			throw new DevAgeApplicationException("There isn't a row in editing state, call BeginAddNew or BeginEdit first");
		}
		property.SetValue(mEditingRow, value);
	}

	public virtual void ApplySort(ListSortDescriptionCollection sorts)
	{
		IBindingListView dataView = m_dataView;
		if (sorts == null || sorts.Count <= 0)
		{
			dataView.RemoveSort();
		}
		else
		{
			dataView.ApplySort(sorts);
		}
	}
}
