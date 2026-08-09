using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SourceGrid.Cells;
using SourceGrid.Selection;

namespace SourceGrid.Extensions.PingGrids;

[ToolboxItem(true)]
public class PingGrid : GridVirtual
{
	private IPingData ipingData_0;

	private bool bool_7 = true;

	private bool bool_8 = true;

	private bool bool_9 = true;

	private string string_0 = "Are you sure to delete all the selected rows?";

	public override bool EnableSort
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public IPingData DataSource
	{
		get
		{
			return ipingData_0;
		}
		set
		{
			Unbind();
			if (value != null)
			{
				ipingData_0 = value;
			}
			else
			{
				ipingData_0 = new EmptyPingSource();
			}
			if (ipingData_0 != null)
			{
				Bind();
			}
		}
	}

	public new PingGridRows Rows => (PingGridRows)base.Rows;

	public new PingGridColumns Columns => (PingGridColumns)base.Columns;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete]
	public object[] SelectedDataRows
	{
		get
		{
			if (ipingData_0 != null)
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
			if (ipingData_0 == null || value == null)
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
	[Obsolete]
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

	public PingGrid()
	{
		base.FixedRows = 1;
		base.FixedColumns = 0;
		base.Controller.AddController(new PingGridCellController());
		DataSource = new EmptyPingSource();
		base.SelectionMode = GridSelectionMode.Row;
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override RowsBase CreateRowsObject()
	{
		return new PingGridRows(this);
	}

	protected override ColumnsBase CreateColumnsObject()
	{
		return new PingGridColumns(this);
	}

	protected override SelectionBase CreateSelectionObject()
	{
		SelectionBase selectionBase = base.CreateSelectionObject();
		selectionBase.EnableMultiSelection = true;
		selectionBase.FocusStyle = FocusStyle.RemoveFocusCellOnLeave;
		selectionBase.FocusRowLeaving += method_1;
		return selectionBase;
	}

	protected virtual void Unbind()
	{
		if (ipingData_0 == null)
		{
		}
		Rows.RowsChanged();
	}

	protected virtual void Bind()
	{
		Rows.RowsChanged();
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
		if (ipingData_0 != null)
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
			string propertyName = Columns[e.KeyColumn].PropertyName;
			DataSource.ApplySort(propertyName, e.Ascending);
			Invalidate();
		}
	}

	protected override void OnValidating(CancelEventArgs e)
	{
		base.OnValidating(e);
		try
		{
		}
		catch (Exception p_Exception)
		{
			OnUserException(new ExceptionEventArgs(p_Exception));
		}
	}

	[Obsolete]
	public virtual bool DeleteSelectedRows()
	{
		if (!string.IsNullOrEmpty(string_0) && MessageBox.Show(this, string_0, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return false;
		}
		int[] rowsIndex = base.Selection.GetSelectionRegion().GetRowsIndex();
		foreach (int gridRowIndex in rowsIndex)
		{
			Rows.IndexToDataSourceIndex(gridRowIndex);
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
		}
		catch (Exception innerException)
		{
			OnUserException(new ExceptionEventArgs(new EndEditingException(innerException)));
			e.Cancel = true;
		}
	}

	[Obsolete]
	public bool BeginEditRow(int gridRow)
	{
		return true;
	}

	[Obsolete]
	public void EndEditingRow(bool cancel)
	{
	}
}
