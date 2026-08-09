using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells;

public class Link : Cell
{
	public Link()
		: this(null)
	{
	}

	public Link(object p_Value)
		: base(p_Value)
	{
		View = SourceGrid.Cells.Views.Link.Default;
		AddController(MouseCursor.Hand);
	}
}
