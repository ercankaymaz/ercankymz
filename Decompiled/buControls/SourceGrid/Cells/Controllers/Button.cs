using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace SourceGrid.Cells.Controllers;

public class Button : ControllerBase
{
	private MouseButtons mouseButtons_0 = MouseButtons.None;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	public event EventHandler Executed
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
			OnExecuted(sender, e);
		}
	}

	public override void OnKeyDown(CellContext sender, KeyEventArgs e)
	{
		base.OnKeyDown(sender, e);
		if (!e.Handled && (e.KeyCode == Keys.Space || e.KeyCode == Keys.Return))
		{
			OnExecuted(sender, e);
			e.Handled = true;
		}
	}

	public virtual void OnExecuted(CellContext sender, EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
	}
}
