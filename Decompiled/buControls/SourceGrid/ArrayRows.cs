namespace SourceGrid;

public class ArrayRows(ArrayGrid grid) : RowsSimpleBase(grid)
{
	private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;

	public new ArrayGrid Grid => (ArrayGrid)base.Grid;

	public override int Count
	{
		get
		{
			if (Grid.DataSource != null)
			{
				return Grid.DataSource.GetLength(0) + Grid.FixedRows;
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

	public override AutoSizeMode GetAutoSizeMode(int row)
	{
		return autoSizeMode_0;
	}
}
