using System;
using System.Collections.Generic;
using System.ComponentModel;
using SourceGrid.Cells;
using SourceGrid.Cells.DataGrid;
using SourceGrid.Conditions;

namespace SourceGrid;

public class DataGridColumn : ColumnInfo
{
	private string propertyName;

	private PropertyDescriptor propertyDescriptor_0;

	private ICellVirtual headerCell;

	private ICellVirtual dataCell;

	private List<ICondition> list_0 = new List<ICondition>();

	private Dictionary<ICondition, ICellVirtual> dictionary_0 = new Dictionary<ICondition, ICellVirtual>();

	public new DataGrid Grid => (DataGrid)base.Grid;

	public string PropertyName
	{
		get
		{
			return propertyName;
		}
		set
		{
			propertyName = value;
			propertyDescriptor_0 = null;
		}
	}

	public PropertyDescriptor PropertyColumn
	{
		get
		{
			if (propertyDescriptor_0 == null && Grid.DataSource != null)
			{
				propertyDescriptor_0 = Grid.DataSource.GetItemProperty(PropertyName, StringComparison.InvariantCultureIgnoreCase);
			}
			return propertyDescriptor_0;
		}
	}

	public ICellVirtual HeaderCell
	{
		get
		{
			return headerCell;
		}
		set
		{
			headerCell = value;
		}
	}

	public ICellVirtual DataCell
	{
		get
		{
			return dataCell;
		}
		set
		{
			dataCell = value;
		}
	}

	public List<ICondition> Conditions => list_0;

	public DataGridColumn(DataGrid grid)
		: base(grid)
	{
		headerCell = new SourceGrid.Cells.DataGrid.ColumnHeader(string.Empty);
		dataCell = new SourceGrid.Cells.DataGrid.Cell();
	}

	public DataGridColumn(DataGrid grid, ICellVirtual headerCell, ICellVirtual dataCell, string propertyName)
		: base(grid)
	{
		this.propertyName = propertyName;
		this.headerCell = headerCell;
		this.dataCell = dataCell;
	}

	public static DataGridColumn CreateRowHeader(DataGrid grid)
	{
		return new DataGridColumn(grid, new SourceGrid.Cells.DataGrid.Header(), new SourceGrid.Cells.DataGrid.RowHeader(), null);
	}

	public void Invalidate()
	{
		propertyDescriptor_0 = null;
	}

	public virtual ICellVirtual GetDataCell(int gridRow)
	{
		object itemRow = Grid.Rows.IndexToDataSourceRow(gridRow);
		foreach (ICondition condition in Conditions)
		{
			if (condition.Evaluate(this, gridRow, itemRow))
			{
				if (!dictionary_0.TryGetValue(condition, out var value))
				{
					value = condition.ApplyCondition(DataCell);
					dictionary_0.Add(condition, value);
				}
				return value;
			}
		}
		return DataCell;
	}
}
