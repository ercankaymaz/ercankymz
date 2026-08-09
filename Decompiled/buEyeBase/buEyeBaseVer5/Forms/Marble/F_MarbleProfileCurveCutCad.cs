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

public class F_MarbleProfileCurveCutCad : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleProfileCurveCutPars varProfileCurveCut = new marbleProfileCurveCutPars();

	public bool CamVisible = true;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_baseheight;

	public buSpin spn_sweepangle;

	public buSpin spn_startangle;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buSpin spn_radius;

	public buButton btn_settings;

	public buCheckBox chk_finish;

	public buCheckBox chk_rough;

	internal buLabel buLabel_0;

	public buCheckBox chk_cutprofileend;

	public buCheckBox chk_cutprofilestart;

	internal buLabel buLabel_1;

	public buSpin spn_twistEA;

	public buSpin spn_twistSA;

	public buCheckBox chk_twistenable;

	internal buLabel buLabel_2;

	internal Panel panel_0;

	public buCheckBox chk_verticalcut;

	internal buLabel buLabel_3;

	public F_MarbleProfileCurveCutCad()
	{
		Class186.smethod_792(this);
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
		spn_radius.Value = varProfileCurveCut.Radius;
		spn_baseheight.Value = varProfileCurveCut.BaseHeight;
		spn_startangle.Value = varProfileCurveCut.StartAngle;
		spn_sweepangle.Value = varProfileCurveCut.SweepAngle;
		chk_finish.Check = varProfileCurveCut.FinishEnable;
		chk_rough.Check = varProfileCurveCut.RoughEnable;
		chk_cutprofileend.Check = varProfileCurveCut.CutProfileEnd;
		chk_cutprofilestart.Check = varProfileCurveCut.CutProfileStart;
		chk_verticalcut.Check = varProfileCurveCut.VerticalCut;
		chk_twistenable.Check = varProfileCurveCut.TwistEnable;
		spn_twistEA.Value = varProfileCurveCut.TwistEndAngle;
		spn_twistSA.Value = varProfileCurveCut.TwistStartAngle;
		panel_0.Visible = CamVisible;
		if (!CamVisible)
		{
			base.Height = 530;
		}
		else
		{
			base.Height = 755;
		}
		Class186.smethod_249(this);
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
				Class186.smethod_693(this);
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
				F_MarbleProfileCurveSettings f_MarbleProfileCurveSettings = new F_MarbleProfileCurveSettings();
				f_MarbleProfileCurveSettings.varProfileCurveCut = new marbleProfileCurveCutPars(varProfileCurveCut);
				f_MarbleProfileCurveSettings.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_MarbleProfileCurveSettings.Properties.FormPosition = FormStartPosition.CenterParent;
				f_MarbleProfileCurveSettings.Init();
				f_MarbleProfileCurveSettings.ShowDialog();
				if (f_MarbleProfileCurveSettings.Properties.Result == DialogResult.OK)
				{
					varProfileCurveCut = new marbleProfileCurveCutPars(f_MarbleProfileCurveSettings.varProfileCurveCut);
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
