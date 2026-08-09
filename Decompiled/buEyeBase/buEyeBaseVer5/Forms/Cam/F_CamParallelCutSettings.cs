using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Cam;

public class F_CamParallelCutSettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public camParameters5 Settings = new camParameters5();

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public Panel pnl_base;

	public buSpin spn_topoffet;

	public buButton btn_ok;

	public buSpin spn_bottomoffst;

	public buButton btn_cancel;

	public buSpin spn_toolstepover;

	public buSpin spn_depthstartoffset;

	public buSpin spn_depthendoffset;

	public buSpin spn_plungespeed;

	public buSpin spn_cuttingspeed;

	public buSpin spn_rapiddistance;

	public buSpin spn_safedistance;

	public buCheckBox chk_showadvancedsettings;

	public buSpin spn_leftoffset;

	public buSpin spn_rightoffset;

	public buButton btn_4_5AxesSettings;

	internal buLabel buLabel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	public buSpin spn_sufaceoffset;

	public F_CamParallelCutSettings()
	{
		Class186.smethod_311(this);
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
		spn_depthendoffset.Value = Settings.Steps.EndOffset;
		spn_depthstartoffset.Value = Settings.Steps.StartOffset;
		spn_safedistance.Value = Settings.Distances.Safe;
		spn_rapiddistance.Value = Settings.Distances.Rapid;
		spn_sufaceoffset.Value = Settings.Operations.SurfaceOffset;
		spn_toolstepover.Value = Settings.Operations.Stepover;
		spn_cuttingspeed.Value = Settings.Speeds.Feed;
		spn_plungespeed.Value = Settings.Speeds.Plunge;
		if (!Settings.Operations.isCircularCam)
		{
			spn_bottomoffst.Value = Settings.Operations.BorderMinOffset.Y;
			spn_topoffet.Value = Settings.Operations.BorderMaxOffset.Y;
			spn_rightoffset.Value = Settings.Operations.BorderMaxOffset.X;
			spn_leftoffset.Value = Settings.Operations.BorderMinOffset.X;
		}
		else
		{
			if (Settings.Strategy.RotaryAxis == VectorType.YVector)
			{
				spn_bottomoffst.Value = Settings.Operations.BorderMaxOffset.Y;
				spn_topoffet.Value = Settings.Operations.BorderMinOffset.Y;
				spn_rightoffset.Value = Settings.Operations.BorderMaxOffset.X;
				spn_leftoffset.Value = Settings.Operations.BorderMinOffset.X;
			}
			if (Settings.Strategy.RotaryAxis == VectorType.XVector)
			{
				spn_bottomoffst.Value = Settings.Operations.BorderMaxOffset.X;
				spn_topoffet.Value = Settings.Operations.BorderMinOffset.X;
				spn_rightoffset.Value = Settings.Operations.BorderMinOffset.Y;
				spn_leftoffset.Value = Settings.Operations.BorderMaxOffset.Y;
			}
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_285(this);
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
		Settings.Operations.SurfaceOffset = spn_sufaceoffset.Value;
		Settings.Operations.Stepover = spn_toolstepover.Value;
		Settings.Speeds.Feed = spn_cuttingspeed.Value;
		Settings.Speeds.Plunge = spn_plungespeed.Value;
		Settings.Steps.EndOffset = spn_depthendoffset.Value;
		Settings.Steps.StartOffset = spn_depthstartoffset.Value;
		Settings.Distances.Safe = spn_safedistance.Value;
		Settings.Distances.Rapid = spn_rapiddistance.Value;
		if (!Settings.Operations.isCircularCam)
		{
			Settings.Operations.BorderMinOffset.Y = spn_bottomoffst.Value;
			Settings.Operations.BorderMaxOffset.Y = spn_topoffet.Value;
			Settings.Operations.BorderMaxOffset.X = spn_rightoffset.Value;
			Settings.Operations.BorderMinOffset.X = spn_leftoffset.Value;
			return;
		}
		if (Settings.Strategy.RotaryAxis == VectorType.YVector)
		{
			Settings.Operations.BorderMaxOffset.Y = spn_bottomoffst.Value;
			Settings.Operations.BorderMinOffset.Y = spn_topoffet.Value;
			Settings.Operations.BorderMaxOffset.X = spn_rightoffset.Value;
			Settings.Operations.BorderMinOffset.X = spn_leftoffset.Value;
		}
		if (Settings.Strategy.RotaryAxis == VectorType.XVector)
		{
			Settings.Operations.BorderMaxOffset.X = spn_bottomoffst.Value;
			Settings.Operations.BorderMinOffset.X = spn_topoffet.Value;
			Settings.Operations.BorderMinOffset.Y = spn_rightoffset.Value;
			Settings.Operations.BorderMaxOffset.Y = spn_leftoffset.Value;
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
			if (control.Name == btn_4_5AxesSettings.Name)
			{
				F_Cam4And5AxisSettings f_Cam4And5AxisSettings = new F_Cam4And5AxisSettings();
				f_Cam4And5AxisSettings.Settings = Settings;
				f_Cam4And5AxisSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_Cam4And5AxisSettings.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
				f_Cam4And5AxisSettings.Init();
				f_Cam4And5AxisSettings.ShowDialog();
				if (f_Cam4And5AxisSettings.PropertiesForm.Result == DialogResult.OK)
				{
					Settings = f_Cam4And5AxisSettings.Settings;
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
