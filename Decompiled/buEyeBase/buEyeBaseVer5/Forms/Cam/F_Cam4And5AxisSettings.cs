using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Cam;

public class F_Cam4And5AxisSettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public camParameters5 Settings = new camParameters5();

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public Panel pnl_base;

	public buSpin spn_LagAngle;

	public buButton btn_ok;

	public buSpin spn_SideTiltAngle;

	public buButton btn_cancel;

	public buSpin spn_AAngleLimitStartInYZPlane;

	public buSpin spn_AAngleLimitEndInYZPlane;

	public buSpin spn_BAngleLimitStartInXZPlane;

	public buSpin spn_BAngleLimitEndInXZPlane;

	public buSpin spn_MaxAngleChange;

	public buSpin spn_CAngleLimitStartInXYPlane;

	public buSpin spn_CAngleLimitEndInXYPlane;

	public buSpin spn_WOrtAngleLimitStart;

	public buSpin spn_WOrtAngleLimitEnd;

	public buCheckBox chk_BAngleLimit;

	public buCheckBox chk_WAngleLimit;

	public buCheckBox chk_CAngleLimit;

	public buCheckBox chk_AAngleLimit;

	public buSpin spn_smoothmaxtiltangle;

	public buCheckBox chk_smoot;

	public buButton btn_tiltstrategy;

	internal buLabel buLabel_0;

	internal buSeparator buSeparator_0;

	internal buSeparator buSeparator_1;

	internal buSeparator buSeparator_2;

	internal buLabel buLabel_1;

	public buButton btnl_sidetiltstrategy;

	public buCheckBox chk_undercut;

	internal buSeparator buSeparator_3;

	public F_Cam4And5AxisSettings()
	{
		Class186.smethod_386(this);
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
		spn_SideTiltAngle.Value = Settings.Rotary.SideTiltAngle;
		spn_LagAngle.Value = Settings.Rotary.LagAngle;
		spn_MaxAngleChange.Value = Settings.Rotary.MaxAngleChange;
		spn_smoothmaxtiltangle.Value = Settings.Rotary.MaxAngleFromInitialToolOrientation;
		spn_BAngleLimitEndInXZPlane.Value = Settings.Rotary.BAngleLimitEndInXZPlane;
		spn_BAngleLimitStartInXZPlane.Value = Settings.Rotary.BAngleLimitStartInXZPlane;
		spn_AAngleLimitStartInYZPlane.Value = Settings.Rotary.AAngleLimitStartInYZPlane;
		spn_AAngleLimitEndInYZPlane.Value = Settings.Rotary.AAngleLimitEndInYZPlane;
		spn_CAngleLimitEndInXYPlane.Value = Settings.Rotary.CAngleLimitEndInXYPlane;
		spn_CAngleLimitStartInXYPlane.Value = Settings.Rotary.CAngleLimitStartInXYPlane;
		spn_WOrtAngleLimitEnd.Value = Settings.Rotary.WOrtAngleLimitEnd;
		spn_WOrtAngleLimitStart.Value = Settings.Rotary.WOrtAngleLimitStart;
		chk_AAngleLimit.Check = Settings.Rotary.AAngleLimitInYZPlaneFlg;
		chk_BAngleLimit.Check = Settings.Rotary.BAngleLimitInXZPlaneFlg;
		chk_CAngleLimit.Check = Settings.Rotary.CAngleLimitInXYPlaneFlg;
		chk_WAngleLimit.Check = Settings.Rotary.WOrtAngleLimitFlg;
		chk_smoot.Check = Settings.Rotary.SmoothingFlg;
		chk_undercut.Check = Settings.Rotary.UndercutsFlg;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_108(this);
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

	public void Apply()
	{
		Settings.Rotary.SideTiltAngle = spn_SideTiltAngle.Value;
		Settings.Rotary.LagAngle = spn_LagAngle.Value;
		Settings.Rotary.MaxAngleChange = spn_MaxAngleChange.Value;
		Settings.Rotary.MaxAngleFromInitialToolOrientation = spn_smoothmaxtiltangle.Value;
		Settings.Rotary.BAngleLimitEndInXZPlane = spn_BAngleLimitEndInXZPlane.Value;
		Settings.Rotary.BAngleLimitStartInXZPlane = spn_BAngleLimitStartInXZPlane.Value;
		Settings.Rotary.AAngleLimitStartInYZPlane = spn_AAngleLimitStartInYZPlane.Value;
		Settings.Rotary.AAngleLimitEndInYZPlane = spn_AAngleLimitEndInYZPlane.Value;
		Settings.Rotary.CAngleLimitEndInXYPlane = spn_CAngleLimitEndInXYPlane.Value;
		Settings.Rotary.CAngleLimitStartInXYPlane = spn_CAngleLimitStartInXYPlane.Value;
		Settings.Rotary.WOrtAngleLimitEnd = spn_WOrtAngleLimitEnd.Value;
		Settings.Rotary.WOrtAngleLimitStart = spn_WOrtAngleLimitStart.Value;
		Settings.Rotary.AAngleLimitInYZPlaneFlg = chk_AAngleLimit.Check;
		Settings.Rotary.BAngleLimitInXZPlaneFlg = chk_BAngleLimit.Check;
		Settings.Rotary.CAngleLimitInXYPlaneFlg = chk_CAngleLimit.Check;
		Settings.Rotary.WOrtAngleLimitFlg = chk_WAngleLimit.Check;
		Settings.Rotary.SmoothingFlg = chk_smoot.Check;
		Settings.Rotary.UndercutsFlg = chk_undercut.Check;
		Settings.Rotary.LimitsFlg = false;
		if (Settings.Rotary.AAngleLimitInYZPlaneFlg | Settings.Rotary.BAngleLimitInXZPlaneFlg | Settings.Rotary.CAngleLimitInXYPlaneFlg | Settings.Rotary.WOrtAngleLimitFlg)
		{
			Settings.Rotary.LimitsFlg = true;
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
				Apply();
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
			if ((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name))
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

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			buSpin buSpin2 = sender as buSpin;
			buSpin2.SelectAll();
		}
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
