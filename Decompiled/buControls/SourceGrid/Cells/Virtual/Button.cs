using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells.Virtual;

public abstract class Button : CellVirtual
{
	public Button()
	{
		View = SourceGrid.Cells.Views.Button.Default;
		AddController(MouseInvalidate.Default);
	}
}
