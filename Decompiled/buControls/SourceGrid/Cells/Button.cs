using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells;

public class Button : Cell
{
	public Button(object p_Value)
		: base(p_Value)
	{
		View = SourceGrid.Cells.Views.Button.Default;
		AddController(MouseInvalidate.Default);
	}
}
