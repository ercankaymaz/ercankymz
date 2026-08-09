using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_ItemCutCamParameters : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public MarbleItemSettings Settings = new MarbleItemSettings();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	public buSpin spn_bwdvel;

	public buSpin spn_fwdvel;

	public buSpin spn_plungevel;

	public buSpin spn_matthickness;

	public buSpin spn_leavevel;

	public buSpin spn_backwardcutstep;

	public buSpin spn_forwardcutstep;

	public buSpin spn_safedistance;

	public buComboBox cmb_cutdir;

	public F_ItemCutCamParameters()
	{
		Class186.smethod_270(this);
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
		spn_bwdvel.Value = Settings.settingMarbleCam.SawBackwardCuttingVelocity;
		spn_fwdvel.Value = Settings.settingMarbleCam.SawForwardCuttingVelocity;
		spn_plungevel.Value = Settings.settingMarbleCam.SawPlungeVelocity;
		spn_matthickness.Value = Settings.MaterialParameter.MaterialThickness;
		spn_forwardcutstep.Value = Settings.settingMarbleCam.SawForwardStepDownDistance;
		spn_backwardcutstep.Value = Settings.settingMarbleCam.SawBackwardStepDownDistance;
		spn_safedistance.Value = Settings.settingMarbleCam.SawSafeDistance;
		LoadLanguage();
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Settings.settingMarbleCam.CuttingDirection, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Settings.settingMarbleCam.CuttingDirection), ref cmb_cutdir);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 14)
			{
				buGround_0.Text = Captions[0];
				spn_fwdvel.Caption.Caption = Captions[1];
				spn_bwdvel.Caption.Caption = Captions[2];
				spn_plungevel.Caption.Caption = Captions[5];
				spn_leavevel.Caption.Caption = Captions[6];
				spn_forwardcutstep.Caption.Caption = Captions[7];
				spn_backwardcutstep.Caption.Caption = Captions[8];
				spn_matthickness.Caption.Caption = Captions[9];
				spn_safedistance.Caption.Caption = Captions[10];
				cmb_cutdir.Caption.Caption = Captions[12];
				buButton_1.Text = Captions[13];
				buButton_2.Text = Captions[14];
			}
		}
		catch (Exception)
		{
		}
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

	internal void method_1(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(buGround_0.Controls, result, e.Shift);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)sender;
				buControlCommands.ShowKeyPad(this, buSpin2);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Settings.settingMarbleCam.SawBackwardCuttingVelocity = spn_bwdvel.Value;
		Settings.settingMarbleCam.SawForwardCuttingVelocity = spn_fwdvel.Value;
		Settings.settingMarbleCam.SawPlungeVelocity = spn_plungevel.Value;
		Settings.MaterialParameter.MaterialThickness = spn_matthickness.Value;
		Settings.settingMarbleCam.SawForwardStepDownDistance = spn_forwardcutstep.Value;
		Settings.settingMarbleCam.SawBackwardStepDownDistance = spn_backwardcutstep.Value;
		Settings.settingMarbleCam.SawSafeDistance = spn_safedistance.Value;
		Settings.settingMarbleCam.CuttingDirection = (CamCuttingDirectionType)buGeneral.EnumValueFromInt(Settings.settingMarbleCam.CuttingDirection, cmb_cutdir.SelectedIndex);
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

	internal void method_4(object sender, EventArgs e)
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

	internal void method_5(object sender, EventArgs e)
	{
		buSpin buSpin2 = (buSpin)sender;
		buSpin2.Display.BackColor = SpinFocusColor;
	}

	internal void method_6(object sender, EventArgs e)
	{
		buSpin buSpin2 = (buSpin)sender;
		buSpin2.Display.BackColor = SpinBaseColor;
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
