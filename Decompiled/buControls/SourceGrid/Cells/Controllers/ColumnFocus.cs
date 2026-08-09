using System.ComponentModel;

namespace SourceGrid.Cells.Controllers;

public class ColumnFocus : ControllerBase
{
	public static readonly ColumnFocus Default = new ColumnFocus();

	public override void OnFocusEntering(CellContext sender, CancelEventArgs e)
	{
		base.OnFocusEntering(sender, e);
		sender.Grid.Selection.FocusColumn(sender.Position.Column);
	}
}
