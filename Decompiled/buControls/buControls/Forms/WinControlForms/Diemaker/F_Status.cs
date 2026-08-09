using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_Status : Form
{
	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private IContainer icontainer_0 = null;

	public Label lbl_status;

	public ProgressBar progressBar1;

	public Label lbl_time;

	public event EventHandler StatusClick
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

	public F_Status()
	{
		Class76.smethod_177(this);
	}

	public void Init()
	{
		Class76.smethod_421(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
