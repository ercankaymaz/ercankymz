using System;
using System.ComponentModel;

namespace SourceGrid.Cells.Controllers;

public class Unselectable : ControllerBase
{
	public static readonly Unselectable Default = new Unselectable();

	public override void OnFocusEntering(CellContext sender, CancelEventArgs e)
	{
		base.OnFocusEntering(sender, e);
		e.Cancel = !CanReceiveFocus(sender, e);
	}

	public override bool CanReceiveFocus(CellContext sender, EventArgs e)
	{
		return false;
	}
}
