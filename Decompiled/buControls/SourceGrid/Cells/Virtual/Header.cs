using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells.Virtual;

public abstract class Header : CellVirtual
{
	public bool ResizeEnabled
	{
		get
		{
			return FindController(typeof(Resizable)) == Resizable.ResizeBoth;
		}
		set
		{
			if (value != ResizeEnabled)
			{
				if (!value)
				{
					RemoveController(Resizable.ResizeBoth);
				}
				else
				{
					AddController(Resizable.ResizeBoth);
				}
			}
		}
	}

	public Header()
	{
		View = SourceGrid.Cells.Views.Header.Default;
		AddController(Unselectable.Default);
		AddController(MouseInvalidate.Default);
		ResizeEnabled = true;
	}
}
