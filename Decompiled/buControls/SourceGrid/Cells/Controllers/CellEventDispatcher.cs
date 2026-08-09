using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SourceGrid.Cells.Controllers;

public class CellEventDispatcher : ControllerBase
{
	public static readonly CellEventDispatcher Default = new CellEventDispatcher();

	public override void OnKeyDown(CellContext sender, KeyEventArgs e)
	{
		base.OnKeyDown(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null && !e.Handled)
		{
			sender.Cell.Controller.OnKeyDown(sender, e);
		}
	}

	public override void OnKeyPress(CellContext sender, KeyPressEventArgs e)
	{
		base.OnKeyPress(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null && !e.Handled)
		{
			sender.Cell.Controller.OnKeyPress(sender, e);
		}
	}

	public override void OnDoubleClick(CellContext sender, EventArgs e)
	{
		base.OnDoubleClick(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnDoubleClick(sender, e);
		}
	}

	public override void OnClick(CellContext sender, EventArgs e)
	{
		base.OnClick(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnClick(sender, e);
		}
	}

	public override void OnFocusEntered(CellContext sender, EventArgs e)
	{
		base.OnFocusEntered(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnFocusEntered(sender, e);
		}
	}

	public override void OnFocusLeft(CellContext sender, EventArgs e)
	{
		base.OnFocusLeft(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnFocusLeft(sender, e);
		}
	}

	public override void OnValueChanged(CellContext sender, EventArgs e)
	{
		base.OnValueChanged(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnValueChanged(sender, e);
		}
	}

	public override void OnEditEnded(CellContext sender, EventArgs e)
	{
		base.OnEditEnded(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnEditEnded(sender, e);
		}
	}

	public override bool CanReceiveFocus(CellContext sender, EventArgs e)
	{
		if (base.CanReceiveFocus(sender, e))
		{
			if (sender.Cell != null)
			{
				if (sender.Cell.Controller == null)
				{
					return true;
				}
				return sender.Cell.Controller.CanReceiveFocus(sender, e);
			}
			return false;
		}
		return false;
	}

	public override void OnEditStarting(CellContext sender, CancelEventArgs e)
	{
		base.OnEditStarting(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnEditStarting(sender, e);
		}
	}

	public override void OnEditStarted(CellContext sender, EventArgs e)
	{
		base.OnEditStarted(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnEditStarted(sender, e);
		}
	}

	public override void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
	{
		base.OnValueChanging(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnValueChanging(sender, e);
		}
	}

	public override void OnFocusEntering(CellContext sender, CancelEventArgs e)
	{
		base.OnFocusEntering(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnFocusEntering(sender, e);
		}
	}

	public override void OnFocusLeaving(CellContext sender, CancelEventArgs e)
	{
		base.OnFocusLeaving(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnFocusLeaving(sender, e);
		}
	}

	public override void OnKeyUp(CellContext sender, KeyEventArgs e)
	{
		base.OnKeyUp(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnKeyUp(sender, e);
		}
	}

	public override void OnMouseDown(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseDown(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnMouseDown(sender, e);
		}
	}

	public override void OnMouseEnter(CellContext sender, EventArgs e)
	{
		base.OnMouseEnter(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnMouseEnter(sender, e);
		}
	}

	public override void OnMouseLeave(CellContext sender, EventArgs e)
	{
		base.OnMouseLeave(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnMouseLeave(sender, e);
		}
	}

	public override void OnMouseMove(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseMove(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnMouseMove(sender, e);
		}
	}

	public override void OnMouseUp(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseUp(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnMouseUp(sender, e);
		}
	}

	public override void OnDragDrop(CellContext sender, DragEventArgs e)
	{
		base.OnDragDrop(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnDragDrop(sender, e);
		}
	}

	public override void OnDragEnter(CellContext sender, DragEventArgs e)
	{
		base.OnDragEnter(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnDragEnter(sender, e);
		}
	}

	public override void OnDragLeave(CellContext sender, EventArgs e)
	{
		base.OnDragLeave(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnDragLeave(sender, e);
		}
	}

	public override void OnDragOver(CellContext sender, DragEventArgs e)
	{
		base.OnDragOver(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnDragOver(sender, e);
		}
	}

	public override void OnGiveFeedback(CellContext sender, GiveFeedbackEventArgs e)
	{
		base.OnGiveFeedback(sender, e);
		if (sender.Cell != null && sender.Cell.Controller != null)
		{
			sender.Cell.Controller.OnGiveFeedback(sender, e);
		}
	}
}
