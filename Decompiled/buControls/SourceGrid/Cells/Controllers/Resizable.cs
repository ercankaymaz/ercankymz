using System;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using ns27;

namespace SourceGrid.Cells.Controllers;

public class Resizable : ControllerBase
{
	public static readonly Resizable ResizeBoth = new Resizable(CellResizeMode.Both);

	public static readonly Resizable ResizeWidth = new Resizable(CellResizeMode.Width);

	public static readonly Resizable ResizeHeight = new Resizable(CellResizeMode.Height);

	public RectangleBorder LogicalBorder = new RectangleBorder(new BorderLine(Color.Black, 4f), new BorderLine(Color.Black, 4f));

	private MouseCursor mouseCursor_0 = new MouseCursor(Cursors.VSplit, applyOnMouseEnter: false);

	private MouseCursor mouseCursor_1 = new MouseCursor(Cursors.HSplit, applyOnMouseEnter: false);

	private CellResizeMode p_Mode = CellResizeMode.Both;

	private bool bool_0 = false;

	private bool bool_1 = false;

	private float float_0 = 0f;

	public CellResizeMode ResizeMode => p_Mode;

	public bool IsWidthResizing => bool_0;

	public bool IsHeightResizing => bool_1;

	public Resizable(CellResizeMode p_Mode)
	{
		this.p_Mode = p_Mode;
	}

	public override void OnMouseDown(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseDown(sender, e);
		bool_1 = false;
		bool_0 = false;
		Rectangle rectangle = sender.Grid.PositionToRectangle(sender.Position);
		Point point = new Point(e.X, e.Y);
		RectanglePartType pointPartType = LogicalBorder.GetPointPartType(rectangle, point, out float_0);
		if ((ResizeMode & CellResizeMode.Width) != CellResizeMode.Width || pointPartType != RectanglePartType.RightBorder)
		{
			if ((ResizeMode & CellResizeMode.Height) == CellResizeMode.Height && pointPartType == RectanglePartType.BottomBorder)
			{
				bool_1 = true;
			}
		}
		else
		{
			bool_0 = true;
		}
	}

	public override void OnMouseUp(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseUp(sender, e);
		bool_0 = false;
		bool_1 = false;
	}

	public override void OnMouseMove(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseMove(sender, e);
		Rectangle rectangle = sender.Grid.PositionToRectangle(sender.Position);
		if (rectangle.IsEmpty)
		{
			return;
		}
		Point point = new Point(e.X, e.Y);
		float distanceFromBorder;
		RectanglePartType pointPartType = LogicalBorder.GetPointPartType(rectangle, point, out distanceFromBorder);
		if (!(sender.Grid.MouseDownPosition == sender.Position))
		{
			if (pointPartType != RectanglePartType.RightBorder || (ResizeMode & CellResizeMode.Width) != CellResizeMode.Width)
			{
				if (pointPartType != RectanglePartType.BottomBorder || (ResizeMode & CellResizeMode.Height) != CellResizeMode.Height)
				{
					mouseCursor_0.ResetCursor(sender, e);
					mouseCursor_1.ResetCursor(sender, e);
				}
				else
				{
					mouseCursor_1.ApplyCursor(sender, e);
				}
			}
			else
			{
				mouseCursor_0.ApplyCursor(sender, e);
			}
		}
		else if (!bool_0)
		{
			if (bool_1)
			{
				int num = point.Y - rectangle.Top;
				if (num > 0)
				{
					GridVirtual grid = sender.Grid;
					Position position = sender.Position;
					int int_ = (int)((float)num + float_0);
					Class76.smethod_344(position, grid, this, int_);
				}
				mouseCursor_1.ApplyCursor(sender, e);
				mouseCursor_0.ResetCursor(sender, e);
			}
		}
		else
		{
			int num2 = point.X - rectangle.Left;
			if (num2 > 0)
			{
				GridVirtual grid2 = sender.Grid;
				Position position2 = sender.Position;
				int int_2 = (int)((float)num2 + float_0);
				Class76.smethod_717(position2, grid2, this, int_2);
			}
			mouseCursor_0.ApplyCursor(sender, e);
			mouseCursor_1.ResetCursor(sender, e);
		}
	}

	public override void OnMouseLeave(CellContext sender, EventArgs e)
	{
		base.OnMouseLeave(sender, e);
		mouseCursor_0.ResetCursor(sender, e);
		mouseCursor_1.ResetCursor(sender, e);
		bool_0 = false;
		bool_1 = false;
	}

	public override void OnDoubleClick(CellContext sender, EventArgs e)
	{
		base.OnDoubleClick(sender, e);
		Point point = sender.Grid.PointToClient(Control.MousePosition);
		Rectangle rectangle = sender.Grid.PositionToRectangle(sender.Position);
		float distanceFromBorder;
		RectanglePartType pointPartType = LogicalBorder.GetPointPartType(rectangle, point, out distanceFromBorder);
		if ((ResizeMode & CellResizeMode.Width) != CellResizeMode.Width || pointPartType != RectanglePartType.RightBorder)
		{
			if ((ResizeMode & CellResizeMode.Height) == CellResizeMode.Height && pointPartType == RectanglePartType.BottomBorder)
			{
				sender.Grid.Rows.AutoSizeRow(sender.Position.Row);
			}
		}
		else
		{
			sender.Grid.Columns.AutoSizeColumn(sender.Position.Column);
		}
	}
}
