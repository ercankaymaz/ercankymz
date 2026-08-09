using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_PlaneMoveRotate : Form
{
	public FormProperties Properties = new FormProperties();

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	public Button btn_movezminus;

	internal ImageList imageList_0;

	public Button btn_movezplus;

	public Button btn_rotateplus;

	public Button btn_rotateminus;

	public Button btn_moveyminus;

	public Button btn_moveyplus;

	internal ImageList imageList_1;

	public NumericUpDown spn_value;

	public Button btn_ok;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	public event OkCommandWithTwoDataEventHandler DataChanged
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public F_PlaneMoveRotate()
	{
		Class186.smethod_176(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
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
		if (control.Name == label_1.Name)
		{
			spn_value.Value = 0.1m;
		}
		if (control.Name == label_2.Name)
		{
			spn_value.Value = 1m;
		}
		if (control.Name == label_3.Name)
		{
			spn_value.Value = 5m;
		}
		if (control.Name == label_4.Name)
		{
			spn_value.Value = 10m;
		}
		if (control.Name == btn_moveyplus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("movey", (double)spn_value.Value);
		}
		if (control.Name == btn_moveyminus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("movey", 0.0 - (double)spn_value.Value);
		}
		if (control.Name == btn_movezplus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("movez", (double)spn_value.Value);
		}
		if (control.Name == btn_movezminus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("movez", 0.0 - (double)spn_value.Value);
		}
		if (control.Name == btn_rotateminus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("rotate", (double)spn_value.Value);
		}
		if (control.Name == btn_rotateplus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("rotate", 0.0 - (double)spn_value.Value);
		}
	}

	internal void method_1(object sender, FormClosingEventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
