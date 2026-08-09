using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.Tufting;

public class F_TuftUserSettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private Timer timer_0 = new Timer();

	private IContainer icontainer_0 = null;

	public buGround buGround1;

	public buButton btn_closecross;

	public buButton btn_close;

	public buButton buButton10;

	public buButton btn_ok;

	public buSpin spn_cornerdistance;

	public buSpin spn_cornerangle;

	public RadioButton radio_speedred100;

	public RadioButton radio_speedred90;

	public RadioButton radio_speedred80;

	public RadioButton radio_speedred70;

	public RadioButton radio_speedred60;

	public RadioButton radioButton_0;

	public RadioButton radioButton_1;

	public RadioButton radioButton_2;

	public RadioButton radioButton_3;

	public RadioButton radioButton_4;

	public buSpin spn_autocutlooptimiing;

	public buSpin spn_extrayarnoncutexit;

	public buSpin spn_extrayarnonloopexit;

	public buSpin spn_headsensordelay;

	public buSpin spn_loopcuttingcycle;

	public buCheckBox chk_yarnsensorenable;

	public buCheckBox chk_stitcheachcorner;

	public buSpin spn_creelsensordelay;

	public buCheckBox chk_creelsensorenable;

	public RadioButton radio_dynamicveryfast;

	public RadioButton radio_dynamicfast;

	public RadioButton radio_dynamicmedium;

	public RadioButton radio_dynamicslow;

	public RadioButton radio_dynamicveryslow;

	public buCheckBox chk_Dynamicalmoda;

	public buSpin spn_desingdevidelen;

	public buSpin spn_yarntalecutstart;

	public buSpin spn_extrayarnonloopcutterexit;

	public buGroup grp_cornersmooth;

	public buGroup grp_cornerspeedchange;

	public buGroup grp_Sensorsettings;

	public buGroup grp_loopsettings;

	public buGroup grp_dynamicalmode;

	public buGroup grp_continuesmode;

	public buGroup grp_othersettings;

	public buGroup buGroup1;

	public buSpin spn_g0acc;

	public buSpin spn_maxjerk;

	public buSpin spn_g1acc;

	public buSpin spn_g1dec;

	public buSpin spn_g0dec;

	public F_TuftUserSettings()
	{
		Class76.smethod_182(this);
		timer_0.Tick += timer_0_Tick;
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
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		Refresh();
		timer_0.Interval = 500;
		timer_0.Enabled = true;
	}

	public void LoadLanguage()
	{
		buGround1.Text = Captions[0];
		grp_Sensorsettings.Text = Captions[1];
		chk_yarnsensorenable.Text = Captions[2];
		chk_creelsensorenable.Text = Captions[3];
		spn_headsensordelay.Text = Captions[4];
		spn_creelsensordelay.Text = Captions[5];
		grp_othersettings.Text = Captions[6];
		spn_desingdevidelen.Text = Captions[7];
		grp_loopsettings.Text = Captions[8];
		spn_loopcuttingcycle.Text = Captions[9];
		spn_extrayarnonloopexit.Text = Captions[10];
		spn_extrayarnonloopcutterexit.Text = Captions[11];
		spn_extrayarnoncutexit.Text = Captions[12];
		spn_yarntalecutstart.Text = Captions[13];
		spn_autocutlooptimiing.Text = Captions[14];
		grp_continuesmode.Text = Captions[15];
		grp_cornerspeedchange.Text = Captions[16];
		spn_cornerangle.Text = Captions[17];
		spn_cornerdistance.Text = Captions[18];
		grp_cornersmooth.Text = Captions[19];
		chk_stitcheachcorner.Text = Captions[20];
		grp_dynamicalmode.Text = Captions[21];
		radio_dynamicveryslow.Text = Captions[22];
		radio_dynamicslow.Text = Captions[23];
		radio_dynamicmedium.Text = Captions[24];
		radio_dynamicfast.Text = Captions[25];
		radio_dynamicveryfast.Text = Captions[26];
		btn_ok.Text = Captions[27];
		btn_close.Text = Captions[28];
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		ControlsUpdate();
		timer_0.Enabled = false;
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

	internal void method_2(object sender, EventArgs e)
	{
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

	public void ControlsUpdate()
	{
		if (chk_Dynamicalmoda.Check)
		{
			grp_continuesmode.Enabled = false;
		}
		else
		{
			grp_continuesmode.Enabled = true;
		}
	}

	internal void method_3(object object_0, bool bool_0)
	{
		if (PropertiesForm.Inited)
		{
			ControlsUpdate();
			if (!chk_Dynamicalmoda.Check)
			{
				radio_speedred70.Checked = true;
				spn_cornerangle.Value = 150.0;
			}
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
		f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
		f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
		f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
		if (buNumeric.IsNumeric(f_KeyPadNumV.Value))
		{
			buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
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
