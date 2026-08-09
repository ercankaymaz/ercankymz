using System;

namespace SourceGrid;

public abstract class ColumnsSimpleBase : ColumnsBase
{
	private int int_1;

	public int ColumnWidth
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

	public ColumnsSimpleBase(GridVirtual grid)
		: base(grid)
	{
		int_1 = grid.DefaultWidth;
	}

	public override int GetWidth(int column)
	{
		return ColumnWidth;
	}

	public override void SetWidth(int column, int width)
	{
		ColumnWidth = width;
	}

	public override bool IsColumnVisible(int column)
	{
		return true;
	}

	public override void HideColumn(int column)
	{
		throw new NotSupportedException("ColumnsSimpleBase does not support column hiding");
	}

	public override void ShowColumn(int column)
	{
	}
}
