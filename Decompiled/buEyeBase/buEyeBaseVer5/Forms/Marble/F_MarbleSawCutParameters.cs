using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawCutParameters : Form
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

	public buSpin spn_bwdvel;

	public buSpin spn_fwdvel;

	public buSpin spn_plungevel;

	public buSpin spn_matthickness;

	public buSpin spn_leavevel;

	public buSpin spn_forwardcutstep;

	public buSpin spn_safedistance;

	public buButton btn_close;

	internal RadioButton radioButton_0;

	internal buLabel buLabel_0;

	internal RadioButton radioButton_1;

	public buSpin spn_sliceoffset;

	public buCheckBox chk_RotateCForReverseDirection;

	internal Panel panel_0;

	internal buLabel buLabel_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	public F_MarbleSawCutParameters()
	{
		Class186.smethod_829(this);
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
		spn_leavevel.Value = Settings.settingMarbleCam.SawLeaveVelocity;
		spn_matthickness.Value = Settings.MaterialParameter.MaterialThickness;
		spn_forwardcutstep.Value = Settings.settingMarbleCam.SawForwardStepDownDistance;
		spn_safedistance.Value = Settings.settingMarbleCam.SawSafeDistance;
		spn_sliceoffset.Value = Settings.settingSliceCut.SliceOffset;
		chk_RotateCForReverseDirection.Check = Settings.settingSliceCut.RotateCForReverseDirection;
		if (Settings.settingSliceCut.SliceDirection != CamCuttingDirectionType.Forward)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
		}
		else
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
		if (Settings.settingSliceCut.HorizontalVerticalSequence != HorizontalVertical.Horizontal)
		{
			radioButton_2.Checked = false;
			radioButton_3.Checked = true;
		}
		else
		{
			radioButton_2.Checked = true;
			radioButton_3.Checked = false;
		}
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			buGround_0.Text = buLangTranslate.preDef.Settings;
			spn_fwdvel.Caption.Caption = buLangTranslate.preDef.Forward + " " + buLangTranslate.preDef.Direction + " " + buLangTranslate.preDef.Velocity;
			spn_bwdvel.Caption.Caption = buLangTranslate.preDef.Backward + " " + buLangTranslate.preDef.Direction + " " + buLangTranslate.preDef.Velocity;
			spn_plungevel.Caption.Caption = buLangTranslate.preDef.Plunge + " " + buLangTranslate.preDef.Velocity;
			spn_leavevel.Caption.Caption = buLangTranslate.preDef.Leave + " " + buLangTranslate.preDef.Velocity;
			spn_forwardcutstep.Caption.Caption = buLangTranslate.preDef.Forward + " " + buLangTranslate.preDef.Cutting + " " + buLangTranslate.preDef.Step;
			spn_matthickness.Caption.Caption = buLangTranslate.preDef.Material + " " + buLangTranslate.preDef.Thickness;
			spn_safedistance.Caption.Caption = buLangTranslate.preDef.SafeDistance;
			spn_sliceoffset.Caption.Caption = buLangTranslate.preDef.Slice + " " + buLangTranslate.preDef.Offset;
			buLabel_0.Text = buLangTranslate.preDef.Cutting + " " + buLangTranslate.preDef.Direction;
			buButton_0.Text = buLangTranslate.preDef.Ok;
			buButton_1.Text = buLangTranslate.preDef.Cancel;
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
		Settings.settingMarbleCam.SawLeaveVelocity = spn_leavevel.Value;
		Settings.MaterialParameter.MaterialThickness = spn_matthickness.Value;
		Settings.settingMarbleCam.SawForwardStepDownDistance = spn_forwardcutstep.Value;
		Settings.settingMarbleCam.SawSafeDistance = spn_safedistance.Value;
		Settings.settingSliceCut.SliceOffset = spn_sliceoffset.Value;
		Settings.settingSliceCut.RotateCForReverseDirection = chk_RotateCForReverseDirection.Check;
		if (!radioButton_0.Checked)
		{
			Settings.settingSliceCut.SliceDirection = CamCuttingDirectionType.ForwardBackward;
		}
		else
		{
			Settings.settingSliceCut.SliceDirection = CamCuttingDirectionType.Forward;
		}
		if (!radioButton_2.Checked)
		{
			Settings.settingSliceCut.HorizontalVerticalSequence = HorizontalVertical.Vertical;
		}
		else
		{
			Settings.settingSliceCut.HorizontalVerticalSequence = HorizontalVertical.Horizontal;
		}
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
