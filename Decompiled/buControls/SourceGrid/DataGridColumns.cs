using System;
using System.ComponentModel;
using SourceGrid.Cells;
using SourceGrid.Cells.DataGrid;
using SourceGrid.Cells.Editors;

namespace SourceGrid;

public class DataGridColumns : ColumnInfoCollection
{
	public new DataGrid Grid => (DataGrid)base.Grid;

	public new DataGridColumn this[int index] => base[index] as DataGridColumn;

	public DataGridColumns(DataGrid grid)
		: base(grid)
	{
	}

	public PropertyDescriptor IndexToPropertyColumn(int gridColumnIndex)
	{
		return Grid.Columns[gridColumnIndex].PropertyColumn;
	}

	public int DataSourceColumnToIndex(PropertyDescriptor propertyColumn)
	{
		for (int i = 0; i < Grid.Columns.Count; i++)
		{
			if (Grid.Columns[i].PropertyColumn == propertyColumn)
			{
				return i;
			}
		}
		return -1;
	}

	public DataGridColumn Add(string property, string caption, Type propertyType)
	{
		ICellVirtual cell = SourceGrid.Cells.DataGrid.Cell.Create(propertyType, editable: true);
		return Add(property, caption, cell);
	}

	public DataGridColumn Add(string property, string caption, EditorBase editor)
	{
		SourceGrid.Cells.DataGrid.Cell cell = new SourceGrid.Cells.DataGrid.Cell();
		cell.Editor = editor;
		return Add(property, caption, cell);
	}

	public DataGridColumn Add(string property, string caption, ICellVirtual cell)
	{
		DataGridColumn dataGridColumn = new DataGridColumn(Grid, new SourceGrid.Cells.DataGrid.ColumnHeader(caption), cell, property);
		Insert(Count, dataGridColumn);
		return dataGridColumn;
	}
}
