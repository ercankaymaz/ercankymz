using System;
using System.Collections.Generic;

namespace SourceGrid.Extensions.PingGrids;

public class PingGridRows : RowsSimpleBase
{
	private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;

	private int int_2;

	[Obsolete]
	private Dictionary<int, int> dictionary_0 = new Dictionary<int, int>();

	public new PingGrid Grid => (PingGrid)base.Grid;

	public override int Count
	{
		get
		{
			if (Grid.DataSource != null)
			{
				return Grid.DataSource.Count + Grid.FixedRows;
			}
			return Grid.FixedRows;
		}
	}

	public AutoSizeMode AutoSizeMode
	{
		get
		{
			return autoSizeMode_0;
		}
		set
		{
			autoSizeMode_0 = value;
		}
	}

	public int HeaderHeight
	{
		get
		{
			return int_2;
		}
		set
		{
			if (int_2 != value)
			{
				int_2 = value;
				PerformLayout();
			}
		}
	}

	public PingGridRows(PingGrid grid)
		: base(grid)
	{
		int_2 = grid.DefaultHeight;
	}

	public int IndexToDataSourceIndex(int gridRowIndex)
	{
		return gridRowIndex - Grid.FixedRows;
	}

	[Obsolete]
	public int DataSourceIndexToGridRowIndex(int dataSourceIndex)
	{
		return dataSourceIndex + Grid.FixedRows;
	}

	[Obsolete]
	public object IndexToDataSourceRow(int gridRowIndex)
	{
		IndexToDataSourceIndex(gridRowIndex);
		return null;
	}

	[Obsolete]
	public int DataSourceRowToIndex(object row)
	{
		if (Grid.DataSource == null)
		{
		}
		return -1;
	}

	public override AutoSizeMode GetAutoSizeMode(int row)
	{
		return autoSizeMode_0;
	}

	[Obsolete]
	public void ResetRowHeigth()
	{
		dictionary_0.Clear();
	}

	[Obsolete]
	public void RowDeleted(object row)
	{
		if (row != null && dictionary_0.ContainsKey(row.GetHashCode()))
		{
			dictionary_0.Remove(row.GetHashCode());
		}
	}

	public override int GetHeight(int row)
	{
		if (row != 0)
		{
			return base.GetHeight(row);
		}
		return HeaderHeight;
	}

	public override void SetHeight(int row, int height)
	{
		if (row == 0)
		{
			HeaderHeight = height;
		}
		base.SetHeight(row, height);
	}
}
