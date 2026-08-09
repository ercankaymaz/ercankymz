using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using DevAge.Windows.Forms;

namespace SourceGrid.Cells.Controllers;

public class RowFocus : ControllerBase
{
	public static readonly RowFocus Default = new RowFocus();

	public RectangleBorder LogicalBorder = new RectangleBorder(new BorderLine(Color.Black, 4f), new BorderLine(Color.Black, 4f));

	private MouseCursor mouseCursor_0 = new MouseCursor(Resources.CursorRightArrow, applyOnMouseEnter: false);

	public override void OnMouseMove(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseMove(sender, e);
		Rectangle rectangle = sender.Grid.PositionToRectangle(sender.Position);
		Point point = new Point(e.X, e.Y);
		float distanceFromBorder;
		RectanglePartType pointPartType = LogicalBorder.GetPointPartType(rectangle, point, out distanceFromBorder);
		if (pointPartType == RectanglePartType.ContentArea)
		{
			mouseCursor_0.ApplyCursor(sender, e);
		}
	}

	public override void OnMouseLeave(CellContext sender, EventArgs e)
	{
		base.OnMouseLeave(sender, e);
		mouseCursor_0.ResetCursor(sender, e);
	}

	public override void OnFocusEntering(CellContext sender, CancelEventArgs e)
	{
		base.OnFocusEntering(sender, e);
		sender.Grid.Selection.FocusRow(sender.Position.Row);
	}
}
