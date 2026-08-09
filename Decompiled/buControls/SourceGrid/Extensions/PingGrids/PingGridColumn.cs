using System;
using System.Collections.Generic;
using System.ComponentModel;
using SourceGrid.Cells;
using SourceGrid.Conditions;
using SourceGrid.Extensions.PingGrids.Cells;

namespace SourceGrid.Extensions.PingGrids;

public class PingGridColumn : ColumnInfo
{
	private string propertyName;

	[Obsolete]
	private PropertyDescriptor propertyDescriptor_0 = null;

	private ICellVirtual headerCell;

	private ICellVirtual dataCell;

	[Obsolete]
	private List<ICondition> list_0 = new List<ICondition>();

	[Obsolete]
	private Dictionary<ICondition, ICellVirtual> dictionary_0 = new Dictionary<ICondition, ICellVirtual>();

	public new PingGrid Grid => (PingGrid)base.Grid;

	public string PropertyName
	{
		get
		{
			return propertyName;
		}
		set
		{
			propertyName = value;
		}
	}

	[Obsolete]
	public PropertyDescriptor PropertyColumn => propertyDescriptor_0;

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

	[Obsolete]
	public List<ICondition> Conditions => list_0;

	public PingGridColumn(PingGrid grid)
		: base(grid)
	{
		headerCell = new SourceGrid.Extensions.PingGrids.Cells.ColumnHeader(string.Empty);
		dataCell = new SourceGrid.Extensions.PingGrids.Cells.Cell();
	}

	public PingGridColumn(PingGrid grid, ICellVirtual headerCell, ICellVirtual dataCell, string propertyName)
		: base(grid)
	{
		this.propertyName = propertyName;
		this.headerCell = headerCell;
		this.dataCell = dataCell;
	}

	public static PingGridColumn CreateRowHeader(PingGrid grid)
	{
		return new PingGridColumn(grid, new SourceGrid.Extensions.PingGrids.Cells.Header(), new SourceGrid.Extensions.PingGrids.Cells.RowHeader(), null);
	}

	[Obsolete]
	public void Invalidate()
	{
	}

	public virtual ICellVirtual GetDataCell(int gridRow)
	{
		return DataCell;
	}
}
