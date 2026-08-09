using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCutRemailMaterial : Form
{
	public static List<string> Captions = new List<string>();

	public marbleCutRemainMaterial Settings = new marbleCutRemainMaterial();

	public marbleMaterialPars SettingsMaterial = new marbleMaterialPars();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	public buSpin spn_materialcutheight;

	public buSpin spn_matrialcutWidth;

	public buSpin spn_verticaloffset;

	public buSpin spn_horizontaloffset;

	public buButton btn_close;

	public buCheckBox chk_verticalcutenable;

	public buCheckBox chk_horizontalcutenable;

	public buCheckBox chk_pasueaftercut;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal buSeparator buSeparator_0;

	public buSpin spn_materialheight;

	public buSpin spn_materialwidth;

	public buSpin spn_materialverlimit;

	public buSpin spn_materialhorlimit;

	public F_MarbleCutRemailMaterial()
	{
		Class186.smethod_804(this);
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
		spn_materialheight.Value = SettingsMaterial.MaterialHeight;
		spn_materialwidth.Value = SettingsMaterial.MaterialWidth;
		spn_materialhorlimit.Value = Settings.MaterialHorizontalMinDistance;
		spn_materialverlimit.Value = Settings.MaterialVerticalMinDistance;
		spn_materialcutheight.Value = Settings.MaterialCutHeight;
		spn_matrialcutWidth.Value = Settings.MaterialCutWidth;
		spn_verticaloffset.Value = Settings.VerticalOffset;
		spn_horizontaloffset.Value = Settings.HorizontalOffset;
		chk_pasueaftercut.Check = Settings.PauseAfterCut;
		chk_horizontalcutenable.Check = Settings.HorizontalCutEnable;
		chk_verticalcutenable.Check = Settings.VerticalCutEnable;
		if (!Settings.UseMaterialData)
		{
			radioButton_1.Checked = false;
			radioButton_0.Checked = true;
		}
		else
		{
			radioButton_1.Checked = true;
			radioButton_0.Checked = false;
		}
		LoadLanguage();
		if (!PropertiesForm.VisualUpdated)
		{
			InitVisual();
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void InitVisual()
	{
		FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
		if (fileInfo.Exists)
		{
			Control.ControlCollection controlCollection = null;
			controlCollection = buGround_0.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
		}
		PropertiesForm.VisualUpdated = true;
	}

	public void LoadLanguage()
	{
		try
		{
			buGround_0.Text = buLangTranslate.preDef.Settings;
			spn_materialhorlimit.Caption.Caption = buLangTranslate.preDef.Material + " " + buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Limit;
			spn_materialverlimit.Caption.Caption = buLangTranslate.preDef.Material + " " + buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Limit;
			spn_matrialcutWidth.Caption.Caption = buLangTranslate.preDef.Material + " " + buLangTranslate.preDef.Width;
			spn_materialheight.Caption.Caption = buLangTranslate.preDef.Material + " " + buLangTranslate.preDef.Height;
			spn_matrialcutWidth.Caption.Caption = buLangTranslate.preDef.User + " " + buLangTranslate.preDef.Cut + " " + buLangTranslate.preDef.Width;
			spn_materialcutheight.Caption.Caption = buLangTranslate.preDef.User + " " + buLangTranslate.preDef.Cut + " " + buLangTranslate.preDef.Height;
			spn_verticaloffset.Caption.Caption = buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Offset;
			spn_horizontaloffset.Caption.Caption = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Offset;
			chk_horizontalcutenable.Text = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Cut + " " + buLangTranslate.preDef.Enable;
			chk_verticalcutenable.Text = buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Cut + " " + buLangTranslate.preDef.Enable;
			chk_pasueaftercut.Text = buLangTranslate.preDef.Pause + " " + buLangTranslate.preDef.After + " " + buLangTranslate.preDef.Cut;
			radioButton_1.Text = buLangTranslate.preDef.Material + " " + buLangTranslate.preDef.Data + " " + buLangTranslate.preDef.Use;
			radioButton_0.Text = buLangTranslate.preDef.User + " " + buLangTranslate.preDef.Data + " " + buLangTranslate.preDef.Use;
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
		SettingsMaterial.MaterialHeight = spn_materialheight.Value;
		SettingsMaterial.MaterialWidth = spn_materialwidth.Value;
		Settings.MaterialHorizontalMinDistance = spn_materialhorlimit.Value;
		Settings.MaterialVerticalMinDistance = spn_materialverlimit.Value;
		Settings.MaterialCutHeight = spn_materialcutheight.Value;
		Settings.MaterialCutWidth = spn_matrialcutWidth.Value;
		Settings.VerticalOffset = spn_verticaloffset.Value;
		Settings.HorizontalOffset = spn_horizontaloffset.Value;
		Settings.PauseAfterCut = chk_pasueaftercut.Check;
		Settings.HorizontalCutEnable = chk_horizontalcutenable.Check;
		Settings.VerticalCutEnable = chk_verticalcutenable.Check;
		if (!radioButton_1.Checked)
		{
			Settings.UseMaterialData = false;
		}
		else
		{
			Settings.UseMaterialData = true;
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
	}

	internal void method_6(object sender, EventArgs e)
	{
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
