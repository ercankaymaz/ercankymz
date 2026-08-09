using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SourceGrid.Cells.Controllers;

public interface IController
{
	void OnMouseDown(CellContext sender, MouseEventArgs e);

	void OnMouseUp(CellContext sender, MouseEventArgs e);

	void OnMouseMove(CellContext sender, MouseEventArgs e);

	void OnMouseEnter(CellContext sender, EventArgs e);

	void OnMouseLeave(CellContext sender, EventArgs e);

	void OnKeyUp(CellContext sender, KeyEventArgs e);

	void OnKeyDown(CellContext sender, KeyEventArgs e);

	void OnKeyPress(CellContext sender, KeyPressEventArgs e);

	void OnDoubleClick(CellContext sender, EventArgs e);

	void OnClick(CellContext sender, EventArgs e);

	void OnFocusLeaving(CellContext sender, CancelEventArgs e);

	void OnFocusLeft(CellContext sender, EventArgs e);

	void OnFocusEntering(CellContext sender, CancelEventArgs e);

	void OnFocusEntered(CellContext sender, EventArgs e);

	void OnValueChanging(CellContext sender, ValueChangeEventArgs e);

	void OnValueChanged(CellContext sender, EventArgs e);

	void OnEditStarting(CellContext sender, CancelEventArgs e);

	void OnEditStarted(CellContext sender, EventArgs e);

	void OnEditEnded(CellContext sender, EventArgs e);

	bool CanReceiveFocus(CellContext sender, EventArgs e);

	void OnDragDrop(CellContext sender, DragEventArgs e);

	void OnDragEnter(CellContext sender, DragEventArgs e);

	void OnDragLeave(CellContext sender, EventArgs e);

	void OnDragOver(CellContext sender, DragEventArgs e);

	void OnGiveFeedback(CellContext sender, GiveFeedbackEventArgs e);
}
