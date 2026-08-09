using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns27;

namespace SourceGrid.Cells.Controllers;

public class MouseSelection : ControllerBase
{
	public static MouseSelection Default = new MouseSelection();

	[CompilerGenerated]
	private MouseButtons mouseButtons_0;

	internal Timer timer_0;

	internal GridVirtual gridVirtual_0;

	internal CellContext cellContext_0 = CellContext.Empty;

	internal MouseEventArgs mouseEventArgs_0 = null;

	public MouseButtons MouseButtons
	{
		[CompilerGenerated]
		get
		{
			return mouseButtons_0;
		}
		[CompilerGenerated]
		set
		{
			mouseButtons_0 = value;
		}
	}

	public MouseSelection()
	{
		MouseButtons = MouseButtons.Left;
	}

	public override void OnMouseDown(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseDown(sender, e);
		if ((e.Button & MouseButtons) == 0)
		{
			return;
		}
		GridVirtual grid = sender.Grid;
		bool flag = (Control.ModifierKeys & Keys.Control) == Keys.Control && (grid.SpecialKeys & GridSpecialKeys.Control) == GridSpecialKeys.Control;
		if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && (grid.SpecialKeys & GridSpecialKeys.Shift) == GridSpecialKeys.Shift && grid.Selection.EnableMultiSelection)
		{
			grid.Selection.ResetSelection(mantainFocus: true);
			Range range = new Range(grid.Selection.ActivePosition, sender.Position);
			grid.Selection.SelectRange(range, select: true);
		}
		else
		{
			bool flag2 = grid.Selection.EnableMultiSelection && flag;
			if (!flag || !grid.Selection.IsSelectedCell(sender.Position) || !(grid.Selection.ActivePosition != sender.Position))
			{
				grid.Selection.Focus(sender.Position, !flag2);
			}
			else
			{
				grid.Selection.SelectCell(sender.Position, select: false);
			}
		}
		if (grid.GetScrollableArea().Contains(e.Location))
		{
			Class76.smethod_493(this, grid);
		}
	}

	public override void OnMouseUp(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseUp(sender, e);
		if (e.Button == MouseButtons.Left)
		{
			sender.Grid.MouseSelectionFinish();
			Class76.smethod_284(this);
		}
	}

	public override void OnMouseMove(CellContext sender, MouseEventArgs e)
	{
		if (gridVirtual_0 != null && mouseEventArgs_0 != null)
		{
			cellContext_0 = CellContext.Empty;
			mouseEventArgs_0 = null;
		}
		base.OnMouseMove(sender, e);
		if (!sender.Grid.Selection.EnableMultiSelection || sender.Grid.MouseDownPosition.IsEmpty() || sender.Grid.MouseDownPosition != sender.Grid.Selection.ActivePosition)
		{
			return;
		}
		int? lastVisibleScrollableRow = sender.Grid.Rows.LastVisibleScrollableRow;
		int? lastVisibleScrollableColumn = sender.Grid.Columns.LastVisibleScrollableColumn;
		int? firstVisibleScrollableRow = sender.Grid.Rows.FirstVisibleScrollableRow;
		int? firstVisibleScrollableColumn = sender.Grid.Columns.FirstVisibleScrollableColumn;
		int? num = sender.Grid.Rows.RowAtPoint(e.Y);
		int? num2 = sender.Grid.Columns.ColumnAtPoint(e.X);
		if (!num.HasValue)
		{
			num = ((e.Y < 0) ? firstVisibleScrollableRow : lastVisibleScrollableRow);
		}
		if (!num2.HasValue)
		{
			num2 = ((e.X < 0) ? firstVisibleScrollableColumn : lastVisibleScrollableColumn);
		}
		if (!num2.HasValue || !num.HasValue)
		{
			return;
		}
		if (lastVisibleScrollableRow.HasValue && num.Value > lastVisibleScrollableRow.Value)
		{
			num = lastVisibleScrollableRow;
		}
		if (lastVisibleScrollableColumn.HasValue && num2.Value > lastVisibleScrollableColumn.Value)
		{
			num2 = lastVisibleScrollableColumn;
		}
		if (firstVisibleScrollableRow.HasValue && num < firstVisibleScrollableRow.Value)
		{
			num = firstVisibleScrollableRow;
		}
		if (firstVisibleScrollableColumn.HasValue && num2 < firstVisibleScrollableColumn.Value)
		{
			num2 = firstVisibleScrollableColumn;
		}
		Position position = new Position(num.Value, num2.Value);
		if (sender.Grid.GetPositionType(position) == sender.Grid.GetPositionType(sender.Grid.Selection.ActivePosition))
		{
			sender.Grid.ChangeMouseSelectionCorner(position);
			if (gridVirtual_0 != null)
			{
				cellContext_0 = sender;
				mouseEventArgs_0 = e;
			}
		}
	}

	public override void OnDoubleClick(CellContext sender, EventArgs e)
	{
		base.OnDoubleClick(sender, e);
		Class76.smethod_284(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (gridVirtual_0 == null)
		{
			return;
		}
		if (!gridVirtual_0.IsDisposed)
		{
			if (gridVirtual_0.Focused)
			{
				Point mousePoint = gridVirtual_0.PointToClient(Control.MousePosition);
				gridVirtual_0.ScrollOnPoint(mousePoint);
				if (mouseEventArgs_0 != null)
				{
					OnMouseMove(cellContext_0, new MouseEventArgs(mouseEventArgs_0.Button, mouseEventArgs_0.Clicks, mousePoint.X, mousePoint.Y, mouseEventArgs_0.Delta));
				}
			}
			else
			{
				Class76.smethod_284(this);
			}
		}
		else
		{
			Class76.smethod_284(this);
		}
	}
}
