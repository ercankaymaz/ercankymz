using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using SourceGrid.Cells.Models;

namespace SourceGrid.Cells.Controllers;

public class CheckBox : ControllerBase
{
	public static readonly CheckBox Default = new CheckBox();

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private MouseButtons mouseButtons_0 = MouseButtons.None;

	private bool p_bAutoChangeValueOfSelectedCells = false;

	public bool AutoChangeValueOfSelectedCells => p_bAutoChangeValueOfSelectedCells;

	public event EventHandler CheckedChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void OnCheckedChanged(EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
	}

	public CheckBox()
	{
	}

	public CheckBox(bool p_bAutoChangeValueOfSelectedCells)
	{
		this.p_bAutoChangeValueOfSelectedCells = p_bAutoChangeValueOfSelectedCells;
	}

	public override void OnKeyPress(CellContext sender, KeyPressEventArgs e)
	{
		base.OnKeyPress(sender, e);
		if (e.KeyChar == ' ')
		{
			method_0(sender, e);
		}
	}

	public override void OnMouseDown(CellContext sender, MouseEventArgs e)
	{
		base.OnMouseDown(sender, e);
		mouseButtons_0 = e.Button;
	}

	public override void OnClick(CellContext sender, EventArgs e)
	{
		base.OnClick(sender, e);
		if (mouseButtons_0 == MouseButtons.Left)
		{
			method_0(sender, e);
		}
	}

	private void method_0(CellContext cellContext_0, EventArgs eventArgs_0)
	{
		ICheckBox checkBox = (ICheckBox)cellContext_0.Cell.Model.FindModel(typeof(ICheckBox));
		if (checkBox != null)
		{
			CheckBoxStatus checkBoxStatus = checkBox.GetCheckBoxStatus(cellContext_0);
			if (checkBoxStatus.CheckEnable)
			{
				bool flag = true;
				if (checkBoxStatus.Checked.HasValue)
				{
					flag = !checkBoxStatus.Checked.Value;
				}
				cellContext_0.StartEdit();
				try
				{
					checkBox.SetCheckedValue(cellContext_0, flag);
					cellContext_0.EndEdit(cancel: false);
					OnCheckedChanged(EventArgs.Empty);
				}
				catch (Exception innerException)
				{
					cellContext_0.EndEdit(cancel: true);
					throw new Exception(string.Empty, innerException);
				}
				if (AutoChangeValueOfSelectedCells)
				{
					method_1(cellContext_0, flag);
				}
			}
			return;
		}
		throw new SourceGridException("Models.ICheckBox not found");
	}

	private void method_1(CellContext cellContext_0, bool bool_0)
	{
		foreach (Position cellsPosition in cellContext_0.Grid.Selection.GetSelectionRegion().GetCellsPositions())
		{
			ICellVirtual cell = cellContext_0.Grid.GetCell(cellsPosition);
			ICheckBox checkBox;
			if (cell != this && cell != null && (checkBox = (ICheckBox)cell.Model.FindModel(typeof(ICheckBox))) != null)
			{
				CellContext cellContext = new CellContext(cellContext_0.Grid, cellsPosition, cell);
				cellContext.StartEdit();
				try
				{
					checkBox.SetCheckedValue(cellContext, bool_0);
					cellContext.EndEdit(cancel: false);
				}
				catch (Exception)
				{
					cellContext.EndEdit(cancel: true);
					throw;
				}
			}
		}
	}
}
