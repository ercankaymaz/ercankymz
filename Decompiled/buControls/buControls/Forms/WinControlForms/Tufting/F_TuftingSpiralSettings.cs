using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Tufting;

public class F_TuftingSpiralSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public TuftingSettings Settings = new TuftingSettings();

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	internal Panel panel_0;

	internal Label label_0;

	public Button btn_ok;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal Panel panel_1;

	internal Label label_4;

	internal Panel panel_2;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Label label_5;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	public F_TuftingSpiralSettings()
	{
		Class76.smethod_718(this);
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
		if (Settings.SpiralFillDirection != ClockDirectionType.CW)
		{
			if (Settings.SpiralFillDirection == ClockDirectionType.CCW)
			{
				radioButton_0.Checked = true;
			}
		}
		else
		{
			radioButton_1.Checked = true;
		}
		if (Settings.SpiralInOutDirection != InOutDirection.InsideToOutside)
		{
			if (Settings.SpiralInOutDirection == InOutDirection.OutsideToInside)
			{
				radioButton_2.Checked = true;
			}
		}
		else
		{
			radioButton_3.Checked = true;
		}
		numericUpDown_1.Value = (decimal)Settings.SpiralInnerOffset;
		numericUpDown_0.Value = (decimal)Settings.SpiralOutterOffset;
		numericUpDown_2.Value = (decimal)Settings.SpiralRowSpace;
		checkBox_0.Checked = Settings.SpiralInnerEnable;
		checkBox_1.Checked = Settings.SpiralOutterEnable;
		ControlUpdate();
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
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
			Settings.SpiralInnerOffset = (double)numericUpDown_1.Value;
			Settings.SpiralOutterOffset = (double)numericUpDown_0.Value;
			Settings.SpiralRowSpace = (double)numericUpDown_2.Value;
			Settings.SpiralInnerEnable = checkBox_0.Checked;
			Settings.SpiralOutterEnable = checkBox_1.Checked;
			if (!radioButton_0.Checked)
			{
				if (radioButton_1.Checked)
				{
					Settings.SpiralFillDirection = ClockDirectionType.CW;
				}
			}
			else
			{
				Settings.SpiralFillDirection = ClockDirectionType.CCW;
			}
			if (!radioButton_3.Checked)
			{
				if (radioButton_2.Checked)
				{
					Settings.SpiralInOutDirection = InOutDirection.OutsideToInside;
				}
			}
			else
			{
				Settings.SpiralInOutDirection = InOutDirection.InsideToOutside;
			}
		}
		if (control.Name == btn_cancel.Name)
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

	public void ControlUpdate()
	{
	}

	public void Apply()
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
