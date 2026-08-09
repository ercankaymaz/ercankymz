using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCavity : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleCavityPars varSettings = new marbleCavityPars();

	public MarbleToolType ToolType = MarbleToolType.Saw;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_ang;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buSpin spn_length;

	public buSpin spn_height;

	public buSpin spn_count;

	public buSpin spn_depth;

	public buSpin spn_space;

	public buCheckBox chk_zigzag;

	internal PictureBox pictureBox_0;

	public buCheckBox chk_toolmillinghead;

	public buCheckBox chk_toolsaw;

	public buCheckBox chk_toolmilling;

	public buButton btn_closecross;

	public F_MarbleCavity()
	{
		Class186.smethod_136(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		spn_length.Value = varSettings.CavityLength;
		spn_height.Value = varSettings.CavityHeight;
		spn_ang.Value = varSettings.CavityAngle;
		spn_count.Value = varSettings.CavityCount;
		spn_space.Value = varSettings.CavitySpace;
		spn_depth.Value = varSettings.CavityDepth;
		chk_zigzag.Check = varSettings.CavityZigzagMode;
		chk_toolmilling.Check = false;
		chk_toolmillinghead.Check = false;
		chk_toolsaw.Check = false;
		if (ToolType != MarbleToolType.Saw)
		{
			if (ToolType != MarbleToolType.MillingHead)
			{
				chk_toolsaw.Check = true;
			}
			else
			{
				chk_toolmillinghead.Check = true;
			}
		}
		else
		{
			chk_toolsaw.Check = true;
		}
		Class186.smethod_338(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
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
			if (control.Name == chk_toolsaw.Name)
			{
				ToolType = MarbleToolType.Saw;
				chk_toolsaw.Check = true;
				chk_toolmilling.Check = false;
				chk_toolmillinghead.Check = false;
			}
			if (control.Name == chk_toolmilling.Name)
			{
				ToolType = MarbleToolType.Milling;
				chk_toolsaw.Check = false;
				chk_toolmilling.Check = true;
				chk_toolmillinghead.Check = false;
			}
			if (control.Name == chk_toolmillinghead.Name)
			{
				ToolType = MarbleToolType.MillingHead;
				chk_toolsaw.Check = false;
				chk_toolmilling.Check = false;
				chk_toolmillinghead.Check = true;
			}
			if (control.Name == btn_ok.Name)
			{
				Class186.smethod_435(this);
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if ((control.Name == btn_cancel.Name) | (control.Name == btn_closecross.Name))
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
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
