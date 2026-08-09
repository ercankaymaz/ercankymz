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

public class F_MarbleProfileCutCad : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleProfileCutPars varProfileCut = new marbleProfileCutPars();

	public bool CamVisible = true;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_ang;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buSpin spn_length;

	public buButton btn_settings;

	public buCheckBox chk_finish;

	public buCheckBox chk_rough;

	public buSpin spn_baseheight;

	public buCheckBox chk_cutprofileend;

	public buCheckBox chk_cutprofilestart;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	public buSpin spn_twistEA;

	public buSpin spn_twistSA;

	public buCheckBox chk_twistenable;

	internal buLabel buLabel_2;

	internal Panel panel_0;

	public F_MarbleProfileCutCad()
	{
		Class186.smethod_663(this);
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
		spn_length.Value = varProfileCut.Length;
		spn_baseheight.Value = varProfileCut.BaseHeight;
		spn_ang.Value = varProfileCut.RotationAngle;
		chk_finish.Check = varProfileCut.FinishEnable;
		chk_rough.Check = varProfileCut.RoughEnable;
		chk_cutprofileend.Check = varProfileCut.CutProfileStart;
		chk_cutprofilestart.Check = varProfileCut.CutProfileEnd;
		chk_twistenable.Check = varProfileCut.TwistEnable;
		spn_twistEA.Value = varProfileCut.TwistEndAngle;
		spn_twistSA.Value = varProfileCut.TwistStartAngle;
		panel_0.Visible = CamVisible;
		if (!CamVisible)
		{
			base.Height = 410;
		}
		else
		{
			base.Height = 645;
		}
		Class186.smethod_483(this);
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
				Class186.smethod_292(this);
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
			if (control.Name == btn_settings.Name)
			{
				F_MarbleProfileSettings f_MarbleProfileSettings = new F_MarbleProfileSettings();
				f_MarbleProfileSettings.varProfileCut = new marbleProfileCutPars(varProfileCut);
				f_MarbleProfileSettings.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_MarbleProfileSettings.Properties.FormPosition = FormStartPosition.CenterParent;
				f_MarbleProfileSettings.Init();
				f_MarbleProfileSettings.ShowDialog();
				if (f_MarbleProfileSettings.Properties.Result == DialogResult.OK)
				{
					varProfileCut = new marbleProfileCutPars(f_MarbleProfileSettings.varProfileCut);
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
