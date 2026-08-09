using System.ComponentModel;
using SourceGrid.Cells.Controllers;

namespace SourceGrid.Extensions.PingGrids;

public class PingGridCellController : ControllerBase
{
	public override void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
	{
		base.OnValueChanging(sender, e);
	}

	public override void OnEditStarting(CellContext sender, CancelEventArgs e)
	{
		base.OnEditStarting(sender, e);
	}
}
