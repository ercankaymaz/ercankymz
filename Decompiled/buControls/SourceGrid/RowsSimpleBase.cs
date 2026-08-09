namespace SourceGrid;

public abstract class RowsSimpleBase : RowsBase
{
	private int int_1;

	public int RowHeight
	{
		get
		{
			return int_1;
		}
		set
		{
			if (int_1 != value)
			{
				int_1 = value;
				PerformLayout();
			}
		}
	}

	public RowsSimpleBase(GridVirtual grid)
		: base(grid)
	{
		int_1 = grid.DefaultHeight;
	}

	public override int GetHeight(int row)
	{
		return RowHeight;
	}

	public override void SetHeight(int row, int height)
	{
		RowHeight = height;
	}
}
