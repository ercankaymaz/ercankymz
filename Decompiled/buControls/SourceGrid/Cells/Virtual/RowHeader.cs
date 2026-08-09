using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells.Virtual;

public class RowHeader : CellVirtual
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
	{
		View = SourceGrid.Cells.Views.RowHeader.Default;
		AddController(Unselectable.Default);
		AddController(MouseInvalidate.Default);
		ResizeEnabled = true;
	}
}
