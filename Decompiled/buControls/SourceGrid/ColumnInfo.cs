using System.ComponentModel;

namespace SourceGrid;

public class ColumnInfo
{
	private int int_0 = -1;

	private int int_1 = 0;

	private int int_2;

	private GridVirtual p_Grid;

	private object object_0;

	private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;

	private bool bool_0 = true;

	public int MaximalWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < int_1)
			{
				value = int_1;
			}
			if (value != int_0 && value >= -1)
			{
				int_0 = value;
				if (Width > int_0 && int_0 > -1)
				{
					Width = int_0;
				}
			}
		}
	}

	public int MinimalWidth
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			if (value > int_0 && int_0 > -1)
			{
				value = int_0;
			}
			if (value != int_1)
			{
				int_1 = value;
				if (Width < int_1 && Visible)
				{
					Width = int_1;
				}
			}
		}
	}

	public int Width
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value < int_1)
			{
				value = int_1;
			}
			if (value > int_0 && int_0 > -1)
			{
				value = int_0;
			}
			if (int_2 != value)
			{
				int_2 = value;
				if (Visible)
				{
					((ColumnInfoCollection)Grid.Columns).OnColumnWidthChanged(new ColumnInfoEventArgs(this));
				}
			}
		}
	}

	public int Index => ((ColumnInfoCollection)Grid.Columns).IndexOf(this);

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
			return new Range(0, Index, Grid.Rows.Count - 1, Index);
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
			return bool_0;
		}
		set
		{
			if (value != bool_0)
			{
				bool_0 = value;
				((ColumnInfoCollection)Grid.Columns).OnColumnWidthChanged(new ColumnInfoEventArgs(this));
			}
		}
	}

	public ColumnInfo(GridVirtual p_Grid)
	{
		this.p_Grid = p_Grid;
		int_2 = Grid.DefaultWidth;
	}
}
