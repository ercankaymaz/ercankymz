using System;
using System.ComponentModel;
using SourceGrid.Cells;
using SourceGrid.Cells.Editors;
using SourceGrid.Extensions.PingGrids.Cells;

namespace SourceGrid.Extensions.PingGrids;

public class PingGridColumns : ColumnInfoCollection
{
	public new PingGrid Grid => (PingGrid)base.Grid;

	public new PingGridColumn this[int index] => base[index] as PingGridColumn;

	public PingGridColumns(PingGrid grid)
		: base(grid)
	{
	}

	[Obsolete]
	public PropertyDescriptor IndexToPropertyColumn(int gridColumnIndex)
	{
		return Grid.Columns[gridColumnIndex].PropertyColumn;
	}

	[Obsolete]
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

	public PingGridColumn Add(string property, string caption, Type propertyType)
	{
		ICellVirtual cell = SourceGrid.Extensions.PingGrids.Cells.Cell.Create(propertyType, editable: true);
		return Add(property, caption, cell);
	}

	public PingGridColumn Add(string property, string caption, EditorBase editor)
	{
		SourceGrid.Extensions.PingGrids.Cells.Cell cell = new SourceGrid.Extensions.PingGrids.Cells.Cell();
		cell.Editor = editor;
		return Add(property, caption, cell);
	}

	public PingGridColumn Add(string property, string caption, ICellVirtual cell)
	{
		PingGridColumn pingGridColumn = new PingGridColumn(Grid, new SourceGrid.Extensions.PingGrids.Cells.ColumnHeader(caption), cell, property);
		Insert(Count, pingGridColumn);
		return pingGridColumn;
	}
}
