using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevAge.ComponentModel;
using SourceGrid.Cells;
using SourceGrid.Cells.DataGrid;
using SourceGrid.Selection;
using ns27;

namespace SourceGrid;

[ToolboxItem(true)]
public class DataGrid : GridVirtual
{
	private IBoundList iboundList_0;

	private bool bool_7 = true;

	private bool bool_8 = true;

	private bool bool_9 = true;

	private string string_0 = "Are you sure to delete all the selected rows?";

	private int? nullable_0;

	public override bool EnableSort
	{
		get
		{
			if (DataSource != null)
			{
				return DataSource.AllowSort;
			}
			return false;
		}
		set
		{
			if (DataSource != null)
			{
				DataSource.AllowSort = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IBoundList DataSource
	{
		get
		{
			return iboundList_0;
		}
		set
		{
			Unbind();
			iboundList_0 = value;
			if (iboundList_0 != null)
			{
				Bind();
			}
		}
	}

	public new DataGridRows Rows => (DataGridRows)base.Rows;

	public new DataGridColumns Columns => (DataGridColumns)base.Columns;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object[] SelectedDataRows
	{
		get
		{
			if (iboundList_0 != null)
			{
				int[] rowsIndex = base.Selection.GetSelectionRegion().GetRowsIndex();
				int num = 0;
				for (int i = 0; i < rowsIndex.Length; i++)
				{
					object obj = Rows.IndexToDataSourceRow(rowsIndex[i]);
					if (obj != null)
					{
						num++;
					}
				}
				object[] array = new object[num];
				int num2 = 0;
				for (int j = 0; j < rowsIndex.Length; j++)
				{
					object obj2 = Rows.IndexToDataSourceRow(rowsIndex[j]);
					if (obj2 != null)
					{
						array[num2] = obj2;
						num2++;
					}
				}
				return array;
			}
			return new DataRowView[0];
		}
		set
		{
			base.Selection.ResetSelection(mantainFocus: false);
			if (iboundList_0 == null || value == null)
			{
				return;
			}
			for (int i = 0; i < value.Length; i++)
			{
				for (int j = base.FixedRows; j < Rows.Count; j++)
				{
					object obj = Rows.IndexToDataSourceRow(j);
					if (obj == value[i])
					{
						base.Selection.SelectRow(j, select: true);
						break;
					}
				}
			}
		}
	}

	[DefaultValue(true)]
	public bool EndEditingRowOnValidate
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	[DefaultValue(true)]
	public bool DeleteRowsWithDeleteKey
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	[DefaultValue(true)]
	public bool CancelEditingWithEscapeKey
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public string DeleteQuestionMessage
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public DataGrid()
	{
		base.FixedRows = 1;
		base.FixedColumns = 0;
		base.Controller.AddController(new DataGridCellController());
		base.SelectionMode = GridSelectionMode.Row;
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override RowsBase CreateRowsObject()
	{
		return new DataGridRows(this);
	}

	protected override ColumnsBase CreateColumnsObject()
	{
		return new DataGridColumns(this);
	}

	protected override SelectionBase CreateSelectionObject()
	{
		SelectionBase selectionBase = base.CreateSelectionObject();
		selectionBase.EnableMultiSelection = false;
		selectionBase.FocusStyle = FocusStyle.RemoveFocusCellOnLeave;
		selectionBase.FocusRowLeaving += method_1;
		return selectionBase;
	}

	protected virtual void Unbind()
	{
		if (iboundList_0 != null)
		{
			iboundList_0.ListChanged -= mBoundList_ListChanged;
			iboundList_0.ItemDeleted -= iboundList_0_ItemDeleted;
			iboundList_0.ListCleared -= iboundList_0_ListCleared;
		}
		Rows.RowsChanged();
	}

	protected virtual void Bind()
	{
		if (Columns.Count == 0)
		{
			CreateColumns();
		}
		Class76.smethod_107(this);
		iboundList_0.ListChanged += mBoundList_ListChanged;
		iboundList_0.ItemDeleted += iboundList_0_ItemDeleted;
		iboundList_0.ListCleared += iboundList_0_ListCleared;
		Rows.RowsChanged();
		Rows.ResetRowHeigth();
	}

	private void iboundList_0_ListCleared(object sender, EventArgs e)
	{
		Rows.ResetRowHeigth();
	}

	private void iboundList_0_ItemDeleted(object sender, ItemDeletedEventArgs e)
	{
		Rows.RowDeleted(e.Item);
	}

	protected virtual void mBoundList_ListChanged(object sender, ListChangedEventArgs e)
	{
		if (!IsSuspended())
		{
			Rows.RowsChanged();
			Invalidate(invalidateChildren: true);
		}
	}

	public override ICellVirtual GetCell(int p_iRow, int p_iCol)
	{
		if (iboundList_0 != null)
		{
			if (p_iCol < Columns.Count)
			{
				if (p_iRow >= base.FixedRows)
				{
					return Columns[p_iCol].GetDataCell(p_iRow);
				}
				return Columns[p_iCol].HeaderCell;
			}
			return null;
		}
		return null;
	}

	protected override void OnSortingRangeRows(SortRangeRowsEventArgs e)
	{
		base.OnSortingRangeRows(e);
		if (DataSource != null && DataSource.AllowSort)
		{
			PropertyDescriptor propertyColumn = Columns[e.KeyColumn].PropertyColumn;
			if (propertyColumn == null)
			{
				DataSource.ApplySort(null);
				return;
			}
			ListSortDirection direction = ((!e.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending);
			ListSortDescription[] sorts = new ListSortDescription[1]
			{
				new ListSortDescription(propertyColumn, direction)
			};
			DataSource.ApplySort(new ListSortDescriptionCollection(sorts));
		}
	}

	public void CreateColumns()
	{
		Columns.Clear();
		if (DataSource == null)
		{
			return;
		}
		int num = 0;
		if (base.FixedColumns > 0)
		{
			Columns.Insert(num, DataGridColumn.CreateRowHeader(this));
			num++;
		}
		foreach (PropertyDescriptor itemProperty in DataSource.GetItemProperties())
		{
			Columns.Add(itemProperty.Name, itemProperty.DisplayName, SourceGrid.Cells.DataGrid.Cell.Create(itemProperty.PropertyType, !itemProperty.IsReadOnly));
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		if (e.KeyCode != Keys.Delete || iboundList_0 == null || !iboundList_0.AllowDelete || e.Handled || !bool_8)
		{
			if (e.KeyCode == Keys.Escape && !e.Handled && bool_9)
			{
				EndEditingRow(cancel: true);
				e.Handled = true;
			}
			return;
		}
		object[] selectedDataRows = SelectedDataRows;
		if (selectedDataRows != null && selectedDataRows.Length != 0)
		{
			DeleteSelectedRows();
		}
		e.Handled = true;
	}

	protected override void OnValidating(CancelEventArgs e)
	{
		base.OnValidating(e);
		try
		{
			if (EndEditingRowOnValidate)
			{
				EndEditingRow(cancel: false);
			}
		}
		catch (Exception p_Exception)
		{
			OnUserException(new ExceptionEventArgs(p_Exception));
		}
	}

	public virtual bool DeleteSelectedRows()
	{
		if (!string.IsNullOrEmpty(string_0) && MessageBox.Show(this, string_0, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return false;
		}
		int[] rowsIndex = base.Selection.GetSelectionRegion().GetRowsIndex();
		foreach (int gridRowIndex in rowsIndex)
		{
			int num = Rows.IndexToDataSourceIndex(gridRowIndex);
			if (num < DataSource.Count)
			{
				DataSource.RemoveAt(num);
			}
		}
		return true;
	}

	public override void AutoSizeCells()
	{
		Columns.AutoSizeView();
		for (int i = 0; i < Rows.Count; i++)
		{
			Rows.AutoSizeRow(i);
		}
	}

	private void method_1(object sender, RowCancelEventArgs e)
	{
		try
		{
			EndEditingRow(cancel: false);
		}
		catch (Exception innerException)
		{
			OnUserException(new ExceptionEventArgs(new EndEditingException(innerException)));
			e.Cancel = true;
		}
	}

	public bool BeginEditRow(int gridRow)
	{
		if (!nullable_0.HasValue || nullable_0.Value != gridRow)
		{
			EndEditingRow(cancel: false);
			if (DataSource != null)
			{
				int num = Rows.IndexToDataSourceIndex(gridRow);
				if (!DataSource.AllowEdit)
				{
					return false;
				}
				if (num != DataSource.Count || !DataSource.AllowNew)
				{
					if (num < DataSource.Count)
					{
						DataSource.BeginEdit(num);
					}
				}
				else
				{
					DataSource.BeginAddNew();
				}
			}
			nullable_0 = gridRow;
			return true;
		}
		return true;
	}

	public void EndEditingRow(bool cancel)
	{
		if (iboundList_0 != null)
		{
			iboundList_0.EndEdit(cancel);
		}
		nullable_0 = null;
	}
}
