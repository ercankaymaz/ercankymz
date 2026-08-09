using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevAge.Collections;

namespace SourceGrid.Cells.Controllers;

public class ControllerContainer : IController
{
	public class ControllerList : ListByType<IController>
	{
	}

	private ControllerList controllerList_0 = null;

	public virtual IController FindController(Type modelType)
	{
		if (controllerList_0 == null)
		{
			controllerList_0 = new ControllerList();
		}
		return controllerList_0.GetByType(modelType);
	}

	public virtual void AddController(IController model)
	{
		if (controllerList_0 == null)
		{
			controllerList_0 = new ControllerList();
		}
		controllerList_0.Add(model);
	}

	public virtual void RemoveController(IController model)
	{
		if (controllerList_0 != null)
		{
			controllerList_0.Remove(model);
		}
	}

	public void OnMouseDown(CellContext sender, MouseEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnMouseDown(sender, e);
		}
	}

	public void OnMouseUp(CellContext sender, MouseEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnMouseUp(sender, e);
		}
	}

	public void OnMouseMove(CellContext sender, MouseEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnMouseMove(sender, e);
		}
	}

	public void OnMouseEnter(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnMouseEnter(sender, e);
		}
	}

	public void OnMouseLeave(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnMouseLeave(sender, e);
		}
	}

	public void OnKeyUp(CellContext sender, KeyEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnKeyUp(sender, e);
		}
	}

	public void OnKeyDown(CellContext sender, KeyEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnKeyDown(sender, e);
		}
	}

	public void OnKeyPress(CellContext sender, KeyPressEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnKeyPress(sender, e);
		}
	}

	public void OnDoubleClick(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnDoubleClick(sender, e);
		}
	}

	public void OnClick(CellContext sender, EventArgs e)
	{
		for (int i = 0; i < controllerList_0.Count; i++)
		{
			controllerList_0[i].OnClick(sender, e);
		}
	}

	public void OnFocusLeaving(CellContext sender, CancelEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnFocusLeaving(sender, e);
		}
	}

	public void OnFocusLeft(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnFocusLeft(sender, e);
		}
	}

	public void OnFocusEntering(CellContext sender, CancelEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnFocusEntering(sender, e);
		}
	}

	public void OnFocusEntered(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnFocusEntered(sender, e);
		}
	}

	public void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnValueChanging(sender, e);
		}
	}

	public void OnValueChanged(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnValueChanged(sender, e);
		}
	}

	public void OnEditStarting(CellContext sender, CancelEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnEditStarting(sender, e);
		}
	}

	public void OnEditStarted(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnEditStarted(sender, e);
		}
	}

	public void OnEditEnded(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnEditEnded(sender, e);
		}
	}

	public bool CanReceiveFocus(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			if (!item.CanReceiveFocus(sender, e))
			{
				return false;
			}
		}
		return true;
	}

	public void OnDragDrop(CellContext sender, DragEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnDragDrop(sender, e);
		}
	}

	public void OnDragEnter(CellContext sender, DragEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnDragEnter(sender, e);
		}
	}

	public void OnDragLeave(CellContext sender, EventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnDragLeave(sender, e);
		}
	}

	public void OnDragOver(CellContext sender, DragEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnDragOver(sender, e);
		}
	}

	public void OnGiveFeedback(CellContext sender, GiveFeedbackEventArgs e)
	{
		foreach (IController item in controllerList_0)
		{
			item.OnGiveFeedback(sender, e);
		}
	}
}
