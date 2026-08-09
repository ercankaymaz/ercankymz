using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Plane;

public class F_PlaneMoveRotate : Form
{
	public FormProperties Properties = new FormProperties();

	internal IContainer icontainer_0 = null;

	public Button btn_movezminus;

	internal ImageList imageList_0;

	public Button btn_movezplus;

	public Button btn_rotateplus;

	public Button btn_rotateminus;

	public Button btn_moveyminus;

	public Button btn_movexplus;

	public Button btn_moveyplus;

	public Button btn_movexminus;

	internal ImageList imageList_1;

	public Button btn_cancel;

	public NumericUpDown spn_movez;

	public NumericUpDown spn_rotate;

	public NumericUpDown spn_movey;

	public NumericUpDown spn_movex;

	public F_PlaneMoveRotate()
	{
		Class76.smethod_544(this);
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
		if (control.Name == btn_cancel.Name)
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
