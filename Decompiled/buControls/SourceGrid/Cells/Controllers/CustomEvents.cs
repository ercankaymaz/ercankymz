using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace SourceGrid.Cells.Controllers;

public class CustomEvents : IController
{
	[CompilerGenerated]
	private MouseEventHandler mouseEventHandler_0;

	[CompilerGenerated]
	private MouseEventHandler mouseEventHandler_1;

	[CompilerGenerated]
	private MouseEventHandler mouseEventHandler_2;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	[CompilerGenerated]
	private KeyEventHandler keyEventHandler_0;

	[CompilerGenerated]
	private KeyEventHandler keyEventHandler_1;

	[CompilerGenerated]
	private KeyPressEventHandler keyPressEventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_2;

	[CompilerGenerated]
	private EventHandler eventHandler_3;

	[CompilerGenerated]
	private CancelEventHandler cancelEventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_4;

	[CompilerGenerated]
	private CancelEventHandler cancelEventHandler_1;

	[CompilerGenerated]
	private EventHandler eventHandler_5;

	[CompilerGenerated]
	private ValueChangeEventHandler valueChangeEventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_6;

	[CompilerGenerated]
	private CancelEventHandler cancelEventHandler_2;

	[CompilerGenerated]
	private EventHandler eventHandler_7;

	[CompilerGenerated]
	private EventHandler eventHandler_8;

	[CompilerGenerated]
	private DragEventHandler dragEventHandler_0;

	[CompilerGenerated]
	private DragEventHandler dragEventHandler_1;

	[CompilerGenerated]
	private EventHandler eventHandler_9;

	[CompilerGenerated]
	private DragEventHandler dragEventHandler_2;

	[CompilerGenerated]
	private GiveFeedbackEventHandler giveFeedbackEventHandler_0;

	public event MouseEventHandler MouseDown
	{
		[CompilerGenerated]
		add
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_0;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_0, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_0;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_0, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
	}

	public event MouseEventHandler MouseUp
	{
		[CompilerGenerated]
		add
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_1;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_1, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_1;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_1, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
	}

	public event MouseEventHandler MouseMove
	{
		[CompilerGenerated]
		add
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_2;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_2, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_2;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_2, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
	}

	public event EventHandler MouseEnter
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

	public event EventHandler MouseLeave
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event KeyEventHandler KeyUp
	{
		[CompilerGenerated]
		add
		{
			KeyEventHandler keyEventHandler = keyEventHandler_0;
			KeyEventHandler keyEventHandler2;
			do
			{
				keyEventHandler2 = keyEventHandler;
				KeyEventHandler value2 = (KeyEventHandler)Delegate.Combine(keyEventHandler2, value);
				keyEventHandler = Interlocked.CompareExchange(ref keyEventHandler_0, value2, keyEventHandler2);
			}
			while ((object)keyEventHandler != keyEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyEventHandler keyEventHandler = keyEventHandler_0;
			KeyEventHandler keyEventHandler2;
			do
			{
				keyEventHandler2 = keyEventHandler;
				KeyEventHandler value2 = (KeyEventHandler)Delegate.Remove(keyEventHandler2, value);
				keyEventHandler = Interlocked.CompareExchange(ref keyEventHandler_0, value2, keyEventHandler2);
			}
			while ((object)keyEventHandler != keyEventHandler2);
		}
	}

	public event KeyEventHandler KeyDown
	{
		[CompilerGenerated]
		add
		{
			KeyEventHandler keyEventHandler = keyEventHandler_1;
			KeyEventHandler keyEventHandler2;
			do
			{
				keyEventHandler2 = keyEventHandler;
				KeyEventHandler value2 = (KeyEventHandler)Delegate.Combine(keyEventHandler2, value);
				keyEventHandler = Interlocked.CompareExchange(ref keyEventHandler_1, value2, keyEventHandler2);
			}
			while ((object)keyEventHandler != keyEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyEventHandler keyEventHandler = keyEventHandler_1;
			KeyEventHandler keyEventHandler2;
			do
			{
				keyEventHandler2 = keyEventHandler;
				KeyEventHandler value2 = (KeyEventHandler)Delegate.Remove(keyEventHandler2, value);
				keyEventHandler = Interlocked.CompareExchange(ref keyEventHandler_1, value2, keyEventHandler2);
			}
			while ((object)keyEventHandler != keyEventHandler2);
		}
	}

	public event KeyPressEventHandler KeyPress
	{
		[CompilerGenerated]
		add
		{
			KeyPressEventHandler keyPressEventHandler = keyPressEventHandler_0;
			KeyPressEventHandler keyPressEventHandler2;
			do
			{
				keyPressEventHandler2 = keyPressEventHandler;
				KeyPressEventHandler value2 = (KeyPressEventHandler)Delegate.Combine(keyPressEventHandler2, value);
				keyPressEventHandler = Interlocked.CompareExchange(ref keyPressEventHandler_0, value2, keyPressEventHandler2);
			}
			while ((object)keyPressEventHandler != keyPressEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyPressEventHandler keyPressEventHandler = keyPressEventHandler_0;
			KeyPressEventHandler keyPressEventHandler2;
			do
			{
				keyPressEventHandler2 = keyPressEventHandler;
				KeyPressEventHandler value2 = (KeyPressEventHandler)Delegate.Remove(keyPressEventHandler2, value);
				keyPressEventHandler = Interlocked.CompareExchange(ref keyPressEventHandler_0, value2, keyPressEventHandler2);
			}
			while ((object)keyPressEventHandler != keyPressEventHandler2);
		}
	}

	public event EventHandler DoubleClick
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler Click
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event CancelEventHandler FocusLeaving
	{
		[CompilerGenerated]
		add
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_0;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value2 = (CancelEventHandler)Delegate.Combine(cancelEventHandler2, value);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value2, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_0;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value2 = (CancelEventHandler)Delegate.Remove(cancelEventHandler2, value);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value2, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}
	}

	public event EventHandler FocusLeft
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event CancelEventHandler FocusEntering
	{
		[CompilerGenerated]
		add
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_1;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value2 = (CancelEventHandler)Delegate.Combine(cancelEventHandler2, value);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_1, value2, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_1;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value2 = (CancelEventHandler)Delegate.Remove(cancelEventHandler2, value);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_1, value2, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}
	}

	public event EventHandler FocusEntered
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_5;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_5;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event ValueChangeEventHandler ValueChanging
	{
		[CompilerGenerated]
		add
		{
			ValueChangeEventHandler valueChangeEventHandler = valueChangeEventHandler_0;
			ValueChangeEventHandler valueChangeEventHandler2;
			do
			{
				valueChangeEventHandler2 = valueChangeEventHandler;
				ValueChangeEventHandler value2 = (ValueChangeEventHandler)Delegate.Combine(valueChangeEventHandler2, value);
				valueChangeEventHandler = Interlocked.CompareExchange(ref valueChangeEventHandler_0, value2, valueChangeEventHandler2);
			}
			while ((object)valueChangeEventHandler != valueChangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangeEventHandler valueChangeEventHandler = valueChangeEventHandler_0;
			ValueChangeEventHandler valueChangeEventHandler2;
			do
			{
				valueChangeEventHandler2 = valueChangeEventHandler;
				ValueChangeEventHandler value2 = (ValueChangeEventHandler)Delegate.Remove(valueChangeEventHandler2, value);
				valueChangeEventHandler = Interlocked.CompareExchange(ref valueChangeEventHandler_0, value2, valueChangeEventHandler2);
			}
			while ((object)valueChangeEventHandler != valueChangeEventHandler2);
		}
	}

	public event EventHandler ValueChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event CancelEventHandler EditStarting
	{
		[CompilerGenerated]
		add
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_2;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value2 = (CancelEventHandler)Delegate.Combine(cancelEventHandler2, value);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_2, value2, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_2;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value2 = (CancelEventHandler)Delegate.Remove(cancelEventHandler2, value);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_2, value2, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}
	}

	public event EventHandler EditStarted
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_7;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_7;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler EditEnded
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_8;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_8, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_8;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_8, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event DragEventHandler DragDrop
	{
		[CompilerGenerated]
		add
		{
			DragEventHandler dragEventHandler = dragEventHandler_0;
			DragEventHandler dragEventHandler2;
			do
			{
				dragEventHandler2 = dragEventHandler;
				DragEventHandler value2 = (DragEventHandler)Delegate.Combine(dragEventHandler2, value);
				dragEventHandler = Interlocked.CompareExchange(ref dragEventHandler_0, value2, dragEventHandler2);
			}
			while ((object)dragEventHandler != dragEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DragEventHandler dragEventHandler = dragEventHandler_0;
			DragEventHandler dragEventHandler2;
			do
			{
				dragEventHandler2 = dragEventHandler;
				DragEventHandler value2 = (DragEventHandler)Delegate.Remove(dragEventHandler2, value);
				dragEventHandler = Interlocked.CompareExchange(ref dragEventHandler_0, value2, dragEventHandler2);
			}
			while ((object)dragEventHandler != dragEventHandler2);
		}
	}

	public event DragEventHandler DragEnter
	{
		[CompilerGenerated]
		add
		{
			DragEventHandler dragEventHandler = dragEventHandler_1;
			DragEventHandler dragEventHandler2;
			do
			{
				dragEventHandler2 = dragEventHandler;
				DragEventHandler value2 = (DragEventHandler)Delegate.Combine(dragEventHandler2, value);
				dragEventHandler = Interlocked.CompareExchange(ref dragEventHandler_1, value2, dragEventHandler2);
			}
			while ((object)dragEventHandler != dragEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DragEventHandler dragEventHandler = dragEventHandler_1;
			DragEventHandler dragEventHandler2;
			do
			{
				dragEventHandler2 = dragEventHandler;
				DragEventHandler value2 = (DragEventHandler)Delegate.Remove(dragEventHandler2, value);
				dragEventHandler = Interlocked.CompareExchange(ref dragEventHandler_1, value2, dragEventHandler2);
			}
			while ((object)dragEventHandler != dragEventHandler2);
		}
	}

	public event EventHandler DragLeave
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_9;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_9, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_9;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_9, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event DragEventHandler DragOver
	{
		[CompilerGenerated]
		add
		{
			DragEventHandler dragEventHandler = dragEventHandler_2;
			DragEventHandler dragEventHandler2;
			do
			{
				dragEventHandler2 = dragEventHandler;
				DragEventHandler value2 = (DragEventHandler)Delegate.Combine(dragEventHandler2, value);
				dragEventHandler = Interlocked.CompareExchange(ref dragEventHandler_2, value2, dragEventHandler2);
			}
			while ((object)dragEventHandler != dragEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DragEventHandler dragEventHandler = dragEventHandler_2;
			DragEventHandler dragEventHandler2;
			do
			{
				dragEventHandler2 = dragEventHandler;
				DragEventHandler value2 = (DragEventHandler)Delegate.Remove(dragEventHandler2, value);
				dragEventHandler = Interlocked.CompareExchange(ref dragEventHandler_2, value2, dragEventHandler2);
			}
			while ((object)dragEventHandler != dragEventHandler2);
		}
	}

	public event GiveFeedbackEventHandler GiveFeedback
	{
		[CompilerGenerated]
		add
		{
			GiveFeedbackEventHandler giveFeedbackEventHandler = giveFeedbackEventHandler_0;
			GiveFeedbackEventHandler giveFeedbackEventHandler2;
			do
			{
				giveFeedbackEventHandler2 = giveFeedbackEventHandler;
				GiveFeedbackEventHandler value2 = (GiveFeedbackEventHandler)Delegate.Combine(giveFeedbackEventHandler2, value);
				giveFeedbackEventHandler = Interlocked.CompareExchange(ref giveFeedbackEventHandler_0, value2, giveFeedbackEventHandler2);
			}
			while ((object)giveFeedbackEventHandler != giveFeedbackEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			GiveFeedbackEventHandler giveFeedbackEventHandler = giveFeedbackEventHandler_0;
			GiveFeedbackEventHandler giveFeedbackEventHandler2;
			do
			{
				giveFeedbackEventHandler2 = giveFeedbackEventHandler;
				GiveFeedbackEventHandler value2 = (GiveFeedbackEventHandler)Delegate.Remove(giveFeedbackEventHandler2, value);
				giveFeedbackEventHandler = Interlocked.CompareExchange(ref giveFeedbackEventHandler_0, value2, giveFeedbackEventHandler2);
			}
			while ((object)giveFeedbackEventHandler != giveFeedbackEventHandler2);
		}
	}

	public void OnMouseDown(CellContext sender, MouseEventArgs e)
	{
		if (mouseEventHandler_0 != null)
		{
			mouseEventHandler_0(sender, e);
		}
	}

	public void OnMouseUp(CellContext sender, MouseEventArgs e)
	{
		if (mouseEventHandler_1 != null)
		{
			mouseEventHandler_1(sender, e);
		}
	}

	public void OnMouseMove(CellContext sender, MouseEventArgs e)
	{
		if (mouseEventHandler_2 != null)
		{
			mouseEventHandler_2(sender, e);
		}
	}

	public void OnMouseEnter(CellContext sender, EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
	}

	public void OnMouseLeave(CellContext sender, EventArgs e)
	{
		if (eventHandler_1 != null)
		{
			eventHandler_1(sender, e);
		}
	}

	public void OnKeyUp(CellContext sender, KeyEventArgs e)
	{
		if (keyEventHandler_0 != null)
		{
			keyEventHandler_0(sender, e);
		}
	}

	public void OnKeyDown(CellContext sender, KeyEventArgs e)
	{
		if (keyEventHandler_1 != null)
		{
			keyEventHandler_1(sender, e);
		}
	}

	public void OnKeyPress(CellContext sender, KeyPressEventArgs e)
	{
		if (keyPressEventHandler_0 != null)
		{
			keyPressEventHandler_0(sender, e);
		}
	}

	public void OnDoubleClick(CellContext sender, EventArgs e)
	{
		if (eventHandler_2 != null)
		{
			eventHandler_2(sender, e);
		}
	}

	public void OnClick(CellContext sender, EventArgs e)
	{
		if (eventHandler_3 != null)
		{
			eventHandler_3(sender, e);
		}
	}

	public void OnFocusLeaving(CellContext sender, CancelEventArgs e)
	{
		if (cancelEventHandler_0 != null)
		{
			cancelEventHandler_0(sender, e);
		}
	}

	public void OnFocusLeft(CellContext sender, EventArgs e)
	{
		if (eventHandler_4 != null)
		{
			eventHandler_4(sender, e);
		}
	}

	public void OnFocusEntering(CellContext sender, CancelEventArgs e)
	{
		if (cancelEventHandler_1 != null)
		{
			cancelEventHandler_1(sender, e);
		}
	}

	public void OnFocusEntered(CellContext sender, EventArgs e)
	{
		if (eventHandler_5 != null)
		{
			eventHandler_5(sender, e);
		}
	}

	public void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
	{
		if (valueChangeEventHandler_0 != null)
		{
			valueChangeEventHandler_0(sender, e);
		}
	}

	public void OnValueChanged(CellContext sender, EventArgs e)
	{
		if (eventHandler_6 != null)
		{
			eventHandler_6(sender, e);
		}
	}

	public virtual void OnEditStarting(CellContext sender, CancelEventArgs e)
	{
		if (cancelEventHandler_2 != null)
		{
			cancelEventHandler_2(sender, e);
		}
	}

	public virtual void OnEditStarted(CellContext sender, EventArgs e)
	{
		if (eventHandler_7 != null)
		{
			eventHandler_7(sender, e);
		}
	}

	public virtual void OnEditEnded(CellContext sender, EventArgs e)
	{
		if (eventHandler_8 != null)
		{
			eventHandler_8(sender, e);
		}
	}

	public virtual bool CanReceiveFocus(CellContext sender, EventArgs e)
	{
		return true;
	}

	public virtual void OnDragDrop(CellContext sender, DragEventArgs e)
	{
		if (dragEventHandler_0 != null)
		{
			dragEventHandler_0(sender, e);
		}
	}

	public virtual void OnDragEnter(CellContext sender, DragEventArgs e)
	{
		if (dragEventHandler_1 != null)
		{
			dragEventHandler_1(sender, e);
		}
	}

	public virtual void OnDragLeave(CellContext sender, EventArgs e)
	{
		if (eventHandler_9 != null)
		{
			eventHandler_9(sender, e);
		}
	}

	public virtual void OnDragOver(CellContext sender, DragEventArgs e)
	{
		if (dragEventHandler_2 != null)
		{
			dragEventHandler_2(sender, e);
		}
	}

	public virtual void OnGiveFeedback(CellContext sender, GiveFeedbackEventArgs e)
	{
		if (giveFeedbackEventHandler_0 != null)
		{
			giveFeedbackEventHandler_0(sender, e);
		}
	}
}
