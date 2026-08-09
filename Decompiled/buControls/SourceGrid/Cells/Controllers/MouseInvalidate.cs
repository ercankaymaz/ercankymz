using System;
using System.Windows.Forms;

namespace SourceGrid.Cells.Controllers;

public class MouseInvalidate : ControllerBase
{
	public static readonly MouseInvalidate Default = new MouseInvalidate();

	public override void OnMouseDown(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseDown(sender, e);
		sender.Grid.InvalidateCell(sender.Position);
	}

	public override void OnMouseUp(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseUp(sender, e);
		sender.Grid.InvalidateCell(sender.Position);
	}

	public override void OnMouseEnter(CellContext sender, EventArgs e)
	{
		base.OnMouseEnter(sender, e);
		sender.Grid.InvalidateCell(sender.Position);
	}

	public override void OnMouseLeave(CellContext sender, EventArgs e)
	{
		base.OnMouseLeave(sender, e);
		sender.Grid.InvalidateCell(sender.Position);
	}
}
