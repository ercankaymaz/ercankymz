using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SourceGrid.Cells.Controllers;

public class StandardBehavior : ControllerBase
{
	public static readonly StandardBehavior Default = new StandardBehavior();

	public override void OnKeyDown(CellContext sender, KeyEventArgs e)
	{
		base.OnKeyDown(sender, e);
		if (e.KeyCode == Keys.F2 && sender.Cell.Editor != null && (sender.Cell.Editor.EditableMode & EditableMode.F2Key) == EditableMode.F2Key)
		{
			e.Handled = true;
			sender.StartEdit();
		}
	}

	public override void OnKeyPress(CellContext sender, KeyPressEventArgs e)
	{
		base.OnKeyPress(sender, e);
		if (sender.Cell.Editor != null && (sender.Cell.Editor.EditableMode & EditableMode.AnyKey) == EditableMode.AnyKey && !sender.IsEditing() && !char.IsControl(e.KeyChar))
		{
			e.Handled = true;
			sender.StartEdit();
			sender.Cell.Editor.SendCharToEditor(e.KeyChar);
		}
	}

	public override void OnDoubleClick(CellContext sender, EventArgs e)
	{
		base.OnDoubleClick(sender, e);
		if (sender.Cell.Editor != null && (sender.Cell.Editor.EditableMode & EditableMode.DoubleClick) == EditableMode.DoubleClick && sender.Grid.Selection.ActivePosition == sender.Position)
		{
			sender.StartEdit();
		}
	}

	public override void OnClick(CellContext sender, EventArgs e)
	{
		base.OnClick(sender, e);
		if (sender.Cell.Editor != null && (sender.Cell.Editor.EditableMode & EditableMode.SingleClick) == EditableMode.SingleClick && sender.Grid.Selection.ActivePosition == sender.Position)
		{
			sender.StartEdit();
		}
	}

	public override void OnFocusEntered(CellContext sender, EventArgs e)
	{
		base.OnFocusEntered(sender, e);
		sender.Grid.ShowCell(sender.Position, ignorePartial: false);
		if (sender.Cell.Editor != null && (sender.Cell.Editor.EditableMode & EditableMode.Focus) == EditableMode.Focus)
		{
			sender.StartEdit();
		}
		if (sender.Grid != null)
		{
			sender.Grid.InvalidateCell(sender.Position);
		}
	}

	public override void OnFocusLeft(CellContext sender, EventArgs e)
	{
		base.OnFocusLeft(sender, e);
		if (sender.Grid != null)
		{
			sender.Grid.InvalidateCell(sender.Position);
		}
	}

	public override void OnValueChanged(CellContext sender, EventArgs e)
	{
		base.OnValueChanged(sender, e);
		if (sender.Grid != null)
		{
			sender.Grid.InvalidateCell(sender.Position);
		}
	}

	public override void OnEditEnded(CellContext sender, EventArgs e)
	{
		base.OnEditEnded(sender, e);
		sender.Grid.Selection.Invalidate();
	}

	public override void OnEditStarting(CellContext sender, CancelEventArgs e)
	{
		base.OnEditStarting(sender, e);
		sender.Grid.Selection.Invalidate();
	}

	public override bool CanReceiveFocus(CellContext sender, EventArgs e)
	{
		if (sender.Grid.Columns.IsColumnVisible(sender.Position.Column))
		{
			if (sender.Grid.Rows.IsRowVisible(sender.Position.Row))
			{
				return base.CanReceiveFocus(sender, e);
			}
			return false;
		}
		return false;
	}
}
