using System.Collections.Generic;

namespace SourceGrid;

public class DataGridRows : RowsSimpleBase
{
	private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;

	private int int_2;

	private Dictionary<int, int> dictionary_0 = new Dictionary<int, int>();

	public new DataGrid Grid => (DataGrid)base.Grid;

	public override int Count
	{
		get
		{
			if (Grid.DataSource == null)
			{
				return Grid.FixedRows;
			}
			if (!Grid.DataSource.AllowNew)
			{
				return Grid.DataSource.Count + Grid.FixedRows;
			}
			return Grid.DataSource.Count + Grid.FixedRows + 1;
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

	public DataGridRows(DataGrid grid)
		: base(grid)
	{
		int_2 = grid.DefaultHeight;
	}

	public int IndexToDataSourceIndex(int gridRowIndex)
	{
		return gridRowIndex - Grid.FixedRows;
	}

	public int DataSourceIndexToGridRowIndex(int dataSourceIndex)
	{
		return dataSourceIndex + Grid.FixedRows;
	}

	public object IndexToDataSourceRow(int gridRowIndex)
	{
		int num = IndexToDataSourceIndex(gridRowIndex);
		if (Grid.DataSource == null || num < 0 || num >= Grid.DataSource.Count)
		{
			return null;
		}
		return Grid.DataSource[num];
	}

	public int DataSourceRowToIndex(object row)
	{
		if (Grid.DataSource == null)
		{
			return -1;
		}
		return Grid.DataSource.IndexOf(row);
	}

	public override AutoSizeMode GetAutoSizeMode(int row)
	{
		return autoSizeMode_0;
	}

	public void ResetRowHeigth()
	{
		dictionary_0.Clear();
	}

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
			object obj = IndexToDataSourceRow(row);
			if (obj == null || !dictionary_0.ContainsKey(obj.GetHashCode()))
			{
				return base.GetHeight(row);
			}
			return dictionary_0[obj.GetHashCode()];
		}
		return HeaderHeight;
	}

	public override void SetHeight(int row, int height)
	{
		if (row != 0)
		{
			if (IndexToDataSourceRow(row) == null)
			{
				base.SetHeight(row, height);
				return;
			}
			int hashCode = IndexToDataSourceRow(row).GetHashCode();
			if (!dictionary_0.ContainsKey(hashCode) || dictionary_0[hashCode] != height)
			{
				dictionary_0[hashCode] = height;
				PerformLayout();
			}
		}
		else
		{
			HeaderHeight = height;
		}
	}
}
