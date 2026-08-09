using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells.Virtual;

public abstract class Link : CellVirtual
{
	public Link()
	{
		View = SourceGrid.Cells.Views.Link.Default;
		AddController(MouseCursor.Hand);
	}
}
