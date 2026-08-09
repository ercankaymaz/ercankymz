using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEditBaseDepthAndOffsetXYPlanes : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MarbleRuntimeSettings varRuntime = new MarbleRuntimeSettings();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buSpin spn_depth;

	public buSpin spn_offsetX;

	public buSpin spn_offsetY;

	public buButton btn_topplane;

	public buButton btn_bottomplane;

	public F_MarbleEditBaseDepthAndOffsetXYPlanes()
	{
		Class186.smethod_357(this);
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
		base.StartPosition = Properties.FormPosition;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		spn_offsetY.Value = varRuntime.Shape3DInOffsetY;
		spn_offsetX.Value = varRuntime.Shape3DInOffsetX;
		spn_depth.Value = varRuntime.Shape3DDepth;
		if (varRuntime.Shape3DPlane != planeNames.Top)
		{
			btn_topplane.Display.BackColor = Color.Red;
			btn_topplane.ButtonDownDisplay.BackColor = Color.Red;
			btn_topplane.ButtonOverDisplay.BackColor = Color.Red;
			btn_bottomplane.Display.BackColor = Color.Green;
			btn_bottomplane.ButtonDownDisplay.BackColor = Color.Green;
			btn_bottomplane.ButtonOverDisplay.BackColor = Color.Green;
		}
		else
		{
			btn_topplane.Display.BackColor = Color.Green;
			btn_topplane.ButtonDownDisplay.BackColor = Color.Green;
			btn_topplane.ButtonOverDisplay.BackColor = Color.Green;
			btn_bottomplane.Display.BackColor = Color.Red;
			btn_bottomplane.ButtonDownDisplay.BackColor = Color.Red;
			btn_bottomplane.ButtonOverDisplay.BackColor = Color.Red;
		}
		Class186.smethod_634(this);
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
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_ok.Name)
			{
				Class186.smethod_10(this);
				Properties.Result = DialogResult.OK;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (Properties.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if ((control.Name == btn_cancel.Name) | (control.Name == buButton_0.Name))
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
			if (control.Name == btn_topplane.Name)
			{
				btn_topplane.Display.BackColor = Color.Green;
				btn_topplane.ButtonDownDisplay.BackColor = Color.Green;
				btn_topplane.ButtonOverDisplay.BackColor = Color.Green;
				btn_bottomplane.Display.BackColor = Color.Red;
				btn_bottomplane.ButtonDownDisplay.BackColor = Color.Red;
				btn_bottomplane.ButtonOverDisplay.BackColor = Color.Red;
				varRuntime.Shape3DPlane = planeNames.Top;
			}
			if (control.Name == btn_bottomplane.Name)
			{
				btn_topplane.Display.BackColor = Color.Red;
				btn_topplane.ButtonDownDisplay.BackColor = Color.Red;
				btn_topplane.ButtonOverDisplay.BackColor = Color.Red;
				btn_bottomplane.Display.BackColor = Color.Green;
				btn_bottomplane.ButtonDownDisplay.BackColor = Color.Green;
				btn_bottomplane.ButtonOverDisplay.BackColor = Color.Green;
				varRuntime.Shape3DPlane = planeNames.Bottom;
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
	}

	internal void method_3(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
			f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
			if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
			{
				buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
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
