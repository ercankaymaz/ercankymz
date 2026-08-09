using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Tufting;

public class F_TuftingStraightSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public TuftingSettings Settings = new TuftingSettings();

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal Label label_0;

	internal Panel panel_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_6;

	internal NumericUpDown numericUpDown_4;

	internal Panel panel_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal Label label_7;

	internal Panel panel_3;

	internal RadioButton radioButton_5;

	internal RadioButton radioButton_6;

	internal Label label_8;

	internal Panel panel_4;

	internal Label label_9;

	internal NumericUpDown numericUpDown_5;

	internal CheckBox checkBox_0;

	internal Label label_10;

	internal Panel panel_5;

	internal Label label_11;

	internal NumericUpDown numericUpDown_6;

	internal CheckBox checkBox_1;

	internal Panel panel_6;

	internal RadioButton radioButton_7;

	internal RadioButton radioButton_8;

	internal Label label_12;

	internal Label label_13;

	internal Panel panel_7;

	internal RadioButton radioButton_9;

	internal RadioButton radioButton_10;

	internal Label label_14;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	public F_TuftingStraightSettings()
	{
		Class76.smethod_501(this);
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
		if (Settings.StraightOutBorderType != tuftingBorderOffsetType.Contour)
		{
			if (Settings.StraightOutBorderType == tuftingBorderOffsetType.Spiral)
			{
				radioButton_6.Checked = true;
			}
		}
		else
		{
			radioButton_5.Checked = true;
		}
		if (Settings.StraightOutBorderFillDirection != ClockDirectionType.CCW)
		{
			if (Settings.StraightOutBorderFillDirection == ClockDirectionType.CW)
			{
				radioButton_4.Checked = true;
			}
		}
		else
		{
			radioButton_3.Checked = true;
		}
		checkBox_0.Checked = Settings.StraightOutBorderEnable;
		numericUpDown_5.Value = Settings.StraightOutBorderCount;
		if (Settings.StraightInBorderType != tuftingBorderOffsetType.Contour)
		{
			if (Settings.StraightInBorderType == tuftingBorderOffsetType.Spiral)
			{
				radioButton_8.Checked = true;
			}
		}
		else
		{
			radioButton_7.Checked = true;
		}
		if (Settings.StraightInBorderFillDirection != ClockDirectionType.CCW)
		{
			if (Settings.StraightInBorderFillDirection == ClockDirectionType.CW)
			{
				radioButton_10.Checked = true;
			}
		}
		else
		{
			radioButton_9.Checked = true;
		}
		checkBox_1.Checked = Settings.StraightInBorderEnable;
		numericUpDown_6.Value = Settings.StraightInBorderCount;
		checkBox_0.Checked = Settings.StraightOutBorderEnable;
		numericUpDown_5.Value = Settings.StraightOutBorderCount;
		checkBox_4.Checked = Settings.StraightRowLink;
		numericUpDown_1.Value = (decimal)Settings.StraightDirection;
		numericUpDown_0.Value = (decimal)Settings.StraightAngle;
		numericUpDown_2.Value = (decimal)Settings.StraightRowSpace;
		numericUpDown_4.Value = (decimal)Settings.StraightInnerOffset;
		numericUpDown_3.Value = (decimal)Settings.StraightOutterOffset;
		checkBox_2.Checked = Settings.StraightOutBorderConnect;
		checkBox_3.Checked = Settings.StraightInBorderConenct;
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
			Settings.StraightInBorderEnable = checkBox_1.Checked;
			Settings.StraightInBorderCount = (int)numericUpDown_6.Value;
			Settings.StraightDirection = (double)numericUpDown_1.Value;
			Settings.StraightAngle = (double)numericUpDown_0.Value;
			Settings.StraightRowSpace = (double)numericUpDown_2.Value;
			Settings.StraightInnerOffset = (double)numericUpDown_4.Value;
			Settings.StraightOutterOffset = (double)numericUpDown_3.Value;
			Settings.StraightOutBorderEnable = checkBox_0.Checked;
			Settings.StraightOutBorderCount = (int)numericUpDown_5.Value;
			Settings.StraightOutBorderConnect = checkBox_2.Checked;
			Settings.StraightInBorderConenct = checkBox_3.Checked;
			Settings.StraightRowLink = checkBox_4.Checked;
			if (!radioButton_5.Checked)
			{
				if (radioButton_6.Checked)
				{
					Settings.StraightOutBorderType = tuftingBorderOffsetType.Spiral;
				}
			}
			else
			{
				Settings.StraightOutBorderType = tuftingBorderOffsetType.Contour;
			}
			if (!radioButton_3.Checked)
			{
				if (radioButton_4.Checked)
				{
					Settings.StraightOutBorderFillDirection = ClockDirectionType.CW;
				}
			}
			else
			{
				Settings.StraightOutBorderFillDirection = ClockDirectionType.CCW;
			}
			if (!radioButton_7.Checked)
			{
				if (radioButton_8.Checked)
				{
					Settings.StraightInBorderType = tuftingBorderOffsetType.Spiral;
				}
			}
			else
			{
				Settings.StraightInBorderType = tuftingBorderOffsetType.Contour;
			}
			if (!radioButton_9.Checked)
			{
				if (radioButton_10.Checked)
				{
					Settings.StraightInBorderFillDirection = ClockDirectionType.CW;
				}
			}
			else
			{
				Settings.StraightInBorderFillDirection = ClockDirectionType.CCW;
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
