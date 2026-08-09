using System.ComponentModel;

namespace SourceGrid;

public class RowInfo
{
	private int int_0;

	private GridVirtual p_Grid;

	private object object_0;

	private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;

	public int Height
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			if (int_0 != value)
			{
				int_0 = value;
				((RowInfoCollection)p_Grid.Rows).OnRowHeightChanged(new RowInfoEventArgs(this));
			}
		}
	}

	public int Index => ((RowInfoCollection)Grid.Rows).IndexOf(this);

	[Browsable(false)]
	public GridVirtual Grid => p_Grid;

	public Range Range
	{
		get
		{
			if (p_Grid == null)
			{
				throw new SourceGridException("Invalid Grid object");
			}
			return new Range(Index, 0, Index, Grid.Columns.Count - 1);
		}
	}

	[Browsable(false)]
	public object Tag
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
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

	public bool Visible
	{
		get
		{
			return Grid.Rows.IsRowVisible(Index);
		}
		set
		{
			Grid.Rows.ShowRow(Index, value);
		}
	}

	public RowInfo(GridVirtual p_Grid)
	{
		this.p_Grid = p_Grid;
		int_0 = Grid.DefaultHeight;
	}
}
