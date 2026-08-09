using System;

namespace SourceGrid.Cells.Controllers;

public class ColumnSelector : ControllerBase
{
	public static readonly ColumnSelector Default = new ColumnSelector();

	public override void OnClick(CellContext sender, EventArgs e)
	{
		base.OnClick(sender, e);
		sender.Grid.Selection.SelectColumn(sender.Position.Column, select: true);
	}
}
