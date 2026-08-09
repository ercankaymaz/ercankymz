using System;

namespace SourceGrid.Cells.Controllers;

public class RowSelector : ControllerBase
{
	public static readonly RowSelector Default = new RowSelector();

	public override void OnClick(CellContext sender, EventArgs e)
	{
		base.OnClick(sender, e);
		sender.Grid.Selection.SelectRow(sender.Position.Row, select: true);
	}
}
