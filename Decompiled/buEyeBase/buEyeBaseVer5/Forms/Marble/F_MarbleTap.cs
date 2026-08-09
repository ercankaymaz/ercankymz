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

public class F_MarbleTap : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleTapPars varSettings = new marbleTapPars();

	public MarbleToolType ToolType = MarbleToolType.Saw;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_lefttapdepth;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buSpin spn_tapdiameter;

	public buSpin spn_tapdepth;

	public buSpin spn_righttapdiameter;

	public buSpin spn_lefttapdiameter;

	public buSpin spn_righttapdepth;

	public buCheckBox chk_lefttapenable;

	internal PictureBox pictureBox_0;

	public buCheckBox chk_toolmillinghead;

	public buCheckBox chk_toolmilling;

	public buButton btn_closecross;

	public buSpin spn_righttapxoffset;

	public buSpin spn_righttapyoffset;

	public buSpin spn_lefttapxoffset;

	public buSpin spn_lefttapyoffset;

	public buCheckBox chk_righttapenable;

	public F_MarbleTap()
	{
		Class186.smethod_113(this);
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
		spn_tapdiameter.Value = varSettings.TapDiameter;
		spn_tapdepth.Value = varSettings.TapDepth;
		spn_lefttapdepth.Value = varSettings.TapLeftDepth;
		spn_lefttapdiameter.Value = varSettings.TapLeftDiameter;
		spn_lefttapxoffset.Value = varSettings.TapLeftXOffset;
		spn_lefttapyoffset.Value = varSettings.TapLeftYOffset;
		spn_righttapdiameter.Value = varSettings.TapRightDiameter;
		spn_righttapdepth.Value = varSettings.TapRightDepth;
		spn_righttapxoffset.Value = varSettings.TapRightXOffset;
		spn_righttapyoffset.Value = varSettings.TapRightYOffset;
		chk_lefttapenable.Check = varSettings.LeftEnable;
		chk_righttapenable.Check = varSettings.RightEnable;
		chk_toolmilling.Check = false;
		chk_toolmillinghead.Check = false;
		if (ToolType != MarbleToolType.MillingHead)
		{
			chk_toolmilling.Check = true;
		}
		else
		{
			chk_toolmillinghead.Check = true;
		}
		Class186.smethod_384(this);
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
			if (control.Name == chk_toolmilling.Name)
			{
				ToolType = MarbleToolType.Milling;
				chk_toolmilling.Check = true;
				chk_toolmillinghead.Check = false;
			}
			if (control.Name == chk_toolmillinghead.Name)
			{
				ToolType = MarbleToolType.MillingHead;
				chk_toolmilling.Check = false;
				chk_toolmillinghead.Check = true;
			}
			if (control.Name == btn_ok.Name)
			{
				Class186.smethod_417(this);
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
