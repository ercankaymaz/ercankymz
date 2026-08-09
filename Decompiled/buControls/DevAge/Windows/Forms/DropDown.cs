using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DropDown : Form
{
	internal Point point_0 = new Point(0, 0);

	internal Panel panel_0;

	private Container container_0 = null;

	internal Control parentControl = null;

	internal Control innerControl = null;

	private DropDownFlags dropDownFlags_0 = DropDownFlags.CloseOnEscape | DropDownFlags.CloseOnEnter;

	private bool bool_0 = false;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	public Control ParentControl
	{
		get
		{
			return parentControl;
		}
		set
		{
			parentControl = value;
		}
	}

	public Control InnerControl
	{
		get
		{
			return innerControl;
		}
		set
		{
			innerControl = value;
		}
	}

	public DropDownFlags DropDownFlags
	{
		get
		{
			return dropDownFlags_0;
		}
		set
		{
			dropDownFlags_0 = value;
		}
	}

	public event EventHandler DropDownOpen
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

	public event EventHandler DropDownClosed
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

	public DropDown()
	{
		Class76.smethod_770(this);
	}

	public DropDown(Control innerControl, Control parentControl, Form owner)
		: this()
	{
		base.Owner = owner;
		this.innerControl = innerControl;
		this.parentControl = parentControl;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	internal void method_0(object sender, LayoutEventArgs e)
	{
		SuspendLayout();
		Class76.smethod_346(this);
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if ((dropDownFlags_0 & DropDownFlags.CloseOnEscape) == DropDownFlags.CloseOnEscape && keyData == Keys.Escape)
		{
			base.DialogResult = DialogResult.Cancel;
			CloseDropDown();
		}
		if ((dropDownFlags_0 & DropDownFlags.CloseOnEnter) == DropDownFlags.CloseOnEnter && keyData == Keys.Return)
		{
			base.DialogResult = DialogResult.OK;
			CloseDropDown();
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}

	internal void method_1(object sender, EventArgs e)
	{
		CloseDropDown();
	}

	public void ShowDropDown()
	{
		if (!bool_0)
		{
			bool_0 = true;
			if (InnerControl == null)
			{
				throw new ApplicationException("InnerControl is null");
			}
			if (ParentControl == null)
			{
				throw new ApplicationException("ParentControl is null");
			}
			if (base.Owner == null)
			{
				throw new ApplicationException("Owner is null");
			}
			OnDropDownOpen(EventArgs.Empty);
		}
	}

	public void CloseDropDown()
	{
		if (bool_0)
		{
			OnDropDownClosed(EventArgs.Empty);
			bool_0 = false;
		}
	}

	protected virtual void OnDropDownOpen(EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
		panel_0.Controls.Add(innerControl);
		try
		{
			Class76.smethod_346(this);
			Show();
			while (bool_0)
			{
				Application.DoEvents();
				Thread.Sleep(1);
			}
		}
		finally
		{
			panel_0.Controls.Remove(innerControl);
		}
	}

	protected virtual void OnDropDownClosed(EventArgs e)
	{
		base.Owner.Activate();
		Hide();
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, e);
		}
	}
}
