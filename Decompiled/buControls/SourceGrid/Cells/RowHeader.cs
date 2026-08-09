using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells;

public class RowHeader : Cell
{
	public bool ResizeEnabled
	{
		get
		{
			return FindController(typeof(Resizable)) == Resizable.ResizeHeight;
		}
		set
		{
			if (value != ResizeEnabled)
			{
				if (!value)
				{
					RemoveController(Resizable.ResizeHeight);
				}
				else
				{
					AddController(Resizable.ResizeHeight);
				}
			}
		}
	}

	public RowHeader()
		: this(null)
	{
	}

	public RowHeader(object cellValue)
		: base(cellValue)
	{
		View = SourceGrid.Cells.Views.RowHeader.Default;
		AddController(Unselectable.Default);
		AddController(MouseInvalidate.Default);
		ResizeEnabled = true;
	}
}
