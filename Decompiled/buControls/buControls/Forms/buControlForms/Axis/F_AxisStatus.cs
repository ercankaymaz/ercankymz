using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.Axis;

public class F_AxisStatus : Form
{
	[CompilerGenerated]
	private StatusChangedEventHandler statusChangedEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buCheckBox buCheckBox_0;

	internal buCheckBox buCheckBox_1;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	internal buTextBox buTextBox_0;

	internal buTextBox buTextBox_1;

	public event StatusChangedEventHandler StatusChanged
	{
		[CompilerGenerated]
		add
		{
			StatusChangedEventHandler statusChangedEventHandler = statusChangedEventHandler_0;
			StatusChangedEventHandler statusChangedEventHandler2;
			do
			{
				statusChangedEventHandler2 = statusChangedEventHandler;
				StatusChangedEventHandler value2 = (StatusChangedEventHandler)Delegate.Combine(statusChangedEventHandler2, value);
				statusChangedEventHandler = Interlocked.CompareExchange(ref statusChangedEventHandler_0, value2, statusChangedEventHandler2);
			}
			while ((object)statusChangedEventHandler != statusChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			StatusChangedEventHandler statusChangedEventHandler = statusChangedEventHandler_0;
			StatusChangedEventHandler statusChangedEventHandler2;
			do
			{
				statusChangedEventHandler2 = statusChangedEventHandler;
				StatusChangedEventHandler value2 = (StatusChangedEventHandler)Delegate.Remove(statusChangedEventHandler2, value);
				statusChangedEventHandler = Interlocked.CompareExchange(ref statusChangedEventHandler_0, value2, statusChangedEventHandler2);
			}
			while ((object)statusChangedEventHandler != statusChangedEventHandler2);
		}
	}

	public F_AxisStatus()
	{
		Class76.smethod_163(this);
	}

	public void Init()
	{
	}

	public void UpdateFields(double Position, string AxisChar, string Status, string Comm)
	{
		buTextBox_0.Text = Status;
		buTextBox_1.Text = Comm;
		buLabel_1.Text = AxisChar;
		buLabel_0.Text = Position.ToString("f3");
	}

	public void UpdateFields(double Position, string AxisChar, bool Homing, bool Enable, string Status, string Comm)
	{
		buTextBox_0.Text = Status;
		buTextBox_1.Text = Comm;
		buLabel_1.Text = AxisChar;
		buLabel_0.Text = Position.ToString("f3");
		buCheckBox_0.Check = Enable;
		buCheckBox_1.Check = Homing;
	}

	internal void method_0(object sender, EventArgs e)
	{
		base.Visible = false;
	}

	internal void method_1(object object_0, bool bool_0)
	{
		Control control = new Control();
		control = (Control)object_0;
		if (control.Name == buCheckBox_0.Name && statusChangedEventHandler_0 != null)
		{
			statusChangedEventHandler_0(buCheckBox_0, buCheckBox_0.Check, buCheckBox_1.Check);
		}
		if (control.Name == buCheckBox_1.Name && statusChangedEventHandler_0 != null)
		{
			statusChangedEventHandler_0(buCheckBox_1, buCheckBox_0.Check, buCheckBox_1.Check);
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
