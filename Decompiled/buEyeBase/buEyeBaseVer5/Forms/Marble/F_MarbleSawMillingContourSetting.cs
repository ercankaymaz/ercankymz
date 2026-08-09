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

public class F_MarbleSawMillingContourSetting : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public marbleCamPars Settings = new marbleCamPars();

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public Panel pnl_base;

	public buSpin spn_sawstraightcutstep;

	public buButton btn_ok;

	public buSpin spn_sawsafedistance;

	public buSpin spn_sawplungespeed;

	public buSpin spn_sawstraightcuttingsspeed;

	public buButton btn_cancel;

	internal buLabel buLabel_0;

	public buSpin spn_sawcircularcutstep;

	public buSpin spn_sawrapiddistance;

	public buSpin spn_millingcutspeed;

	public buSpin spn_millingplungespeed;

	public buSpin spn_millingfirstcutspeed;

	public buSpin spn_millingcutstep;

	internal buLabel buLabel_1;

	internal buLabel buLabel_2;

	public buSpin spn_millingheaddrillspeed;

	public buSpin spn_millingheadcutspeed;

	public buSpin spn_millingheadplungespeed;

	public buSpin spn_millingheadfirstcutspeed;

	public buSpin spn_millingheadcutstep;

	public buButton btn_advancesettings;

	public buSpin spn_sawcircularcutspeed;

	public buSpin spn_sawstraightcutfirststep;

	public buSpin spn_sawstraightcutfirstspeed;

	public buSpin spn_millingfirstcutstep;

	public buSpin spn_sawcircularcutfirststep;

	public buSpin spn_sawcircularcutfirstspeed;

	public buSpin spn_millingdrillspeed;

	public buSpin spn_millingheadfirstcutstep;

	public F_MarbleSawMillingContourSetting()
	{
		Class186.smethod_748(this);
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
		spn_sawcircularcutstep.Value = Settings.SawForwardCircularStepDownDistance;
		spn_sawcircularcutspeed.Value = Settings.SawForwardCircularCuttingVelocity;
		spn_sawcircularcutfirstspeed.Value = Settings.SawForwardCircularFirstCuttingVelocity;
		spn_sawcircularcutfirststep.Value = Settings.SawForwardCircularStepFirstDownDistance;
		spn_sawstraightcuttingsspeed.Value = Settings.SawForwardCuttingVelocity;
		spn_sawstraightcutstep.Value = Settings.SawForwardStepDownDistance;
		spn_sawstraightcutfirstspeed.Value = Settings.SawForwardFirstCuttingVelocity;
		spn_sawstraightcutfirststep.Value = Settings.SawForwardStepFirstDownDistance;
		spn_sawplungespeed.Value = Settings.SawPlungeVelocity;
		spn_sawrapiddistance.Value = Settings.SawRapidDistance;
		spn_sawsafedistance.Value = Settings.SawSafeDistance;
		spn_millingcutspeed.Value = Settings.MillingCuttingVelocity;
		spn_millingcutstep.Value = Settings.MillingStepDown;
		spn_millingfirstcutspeed.Value = Settings.MillingFirstCuttingVelocity;
		spn_millingfirstcutstep.Value = Settings.MillingFirstStepDown;
		spn_millingplungespeed.Value = Settings.MillingPlungeVelocity;
		spn_millingdrillspeed.Value = Settings.MillingDrillVelocity;
		spn_millingheadcutspeed.Value = Settings.MillingHeadCuttingVelocity;
		spn_millingheadcutstep.Value = Settings.MillingHeadStepDown;
		spn_millingheadfirstcutspeed.Value = Settings.MillingHeadFirstCuttingVelocity;
		spn_millingheadfirstcutstep.Value = Settings.MillingHeadFirstStepDown;
		spn_millingheaddrillspeed.Value = Settings.MillingHeadDrillVelocity;
		spn_millingheadplungespeed.Value = Settings.MillingHeadPlungeVelocity;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_381(this);
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
		Settings.SawForwardCircularStepDownDistance = spn_sawcircularcutstep.Value;
		Settings.SawForwardCircularCuttingVelocity = spn_sawcircularcutspeed.Value;
		Settings.SawForwardCircularFirstCuttingVelocity = spn_sawcircularcutfirstspeed.Value;
		Settings.SawForwardCircularStepFirstDownDistance = spn_sawcircularcutfirststep.Value;
		Settings.SawForwardCuttingVelocity = spn_sawstraightcuttingsspeed.Value;
		Settings.SawForwardStepDownDistance = spn_sawstraightcutstep.Value;
		Settings.SawForwardFirstCuttingVelocity = spn_sawstraightcutfirstspeed.Value;
		Settings.SawForwardStepFirstDownDistance = spn_sawstraightcutfirststep.Value;
		Settings.SawPlungeVelocity = spn_sawplungespeed.Value;
		Settings.SawRapidDistance = spn_sawrapiddistance.Value;
		Settings.SawSafeDistance = spn_sawsafedistance.Value;
		Settings.MillingCuttingVelocity = spn_millingcutspeed.Value;
		Settings.MillingStepDown = spn_millingcutstep.Value;
		Settings.MillingFirstCuttingVelocity = spn_millingfirstcutspeed.Value;
		Settings.MillingFirstStepDown = spn_millingfirstcutstep.Value;
		Settings.MillingPlungeVelocity = spn_millingplungespeed.Value;
		Settings.MillingDrillVelocity = spn_millingdrillspeed.Value;
		Settings.MillingHeadCuttingVelocity = spn_millingheadcutspeed.Value;
		Settings.MillingHeadStepDown = spn_millingheadcutstep.Value;
		Settings.MillingHeadFirstCuttingVelocity = spn_millingheadfirstcutspeed.Value;
		Settings.MillingHeadFirstStepDown = spn_millingheadfirstcutstep.Value;
		Settings.MillingHeadDrillVelocity = spn_millingheaddrillspeed.Value;
		Settings.MillingHeadPlungeVelocity = spn_millingheadplungespeed.Value;
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
			buSpin2.Display.BackColor = buEyeVars.parVisual.colorDataFocus;
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
