using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Progress;

public class F_ProgressCalculation : Form
{
	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal Button button_0;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	public ProgressBar progress_current;

	public ProgressBar progress_overall;

	public event CancelCommandEventHandler CancelProcess
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Combine(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Remove(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
	}

	public F_ProgressCalculation()
	{
		Class76.smethod_363(this);
	}

	public void Init(double currentvalue, double overallvalue, string operation)
	{
		if (!((currentvalue >= 0.0) & (currentvalue <= (double)progress_current.Maximum)))
		{
			if (!(currentvalue < 0.0))
			{
				if (currentvalue > (double)progress_current.Maximum)
				{
					progress_current.Value = progress_current.Maximum;
					label_4.Text = progress_current.Maximum.ToString("f1") + "%";
				}
			}
			else
			{
				progress_current.Value = 0;
				label_4.Text = "0.0%";
			}
		}
		else
		{
			progress_current.Value = (int)currentvalue;
			label_4.Text = currentvalue.ToString("f1") + "%";
		}
		if (!((overallvalue >= 0.0) & (overallvalue <= (double)progress_overall.Maximum)))
		{
			if (!(overallvalue < 0.0))
			{
				if (overallvalue > (double)progress_overall.Maximum)
				{
					progress_overall.Value = progress_overall.Maximum;
					label_5.Text = progress_overall.Maximum.ToString("f1") + "%";
				}
			}
			else
			{
				progress_overall.Value = 0;
				label_5.Text = "0.0%";
			}
		}
		else
		{
			progress_overall.Value = (int)overallvalue;
			label_5.Text = overallvalue.ToString("f1") + "%";
		}
		label_3.Text = operation;
		Class76.smethod_424(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (cancelCommandEventHandler_0 != null)
		{
			cancelCommandEventHandler_0();
		}
		buSystem.Cancel = true;
		base.Visible = false;
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
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
