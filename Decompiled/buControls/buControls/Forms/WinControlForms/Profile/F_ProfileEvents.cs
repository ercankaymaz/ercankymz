using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Profile;

public class F_ProfileEvents : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal Button button_0;

	internal ImageList imageList_1;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	public event OkCommandWithDataEventHandler CommandOk
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public F_ProfileEvents()
	{
		Class76.smethod_142(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		Properties.Result = DialogResult.None;
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		Properties.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		Dispose();
		if (control.Name == button_0.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0(actionTypeBU.eventCopy);
		}
		if (control.Name == button_1.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0(actionTypeBU.eventMirrorX);
		}
		if (control.Name == button_2.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0(actionTypeBU.eventMirrorY);
		}
		if (control.Name == button_3.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0(actionTypeBU.eventLineerArray);
		}
		if (control.Name == button_4.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0(actionTypeBU.eventPolarArray);
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
