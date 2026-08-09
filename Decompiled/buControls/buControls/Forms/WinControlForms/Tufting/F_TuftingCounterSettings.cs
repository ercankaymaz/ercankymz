using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Tufting;

public class F_TuftingCounterSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public TuftingSettings Settings = new TuftingSettings();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Label label_2;

	internal Panel panel_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Label label_3;

	internal Panel panel_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_2;

	internal Label label_5;

	internal Panel panel_3;

	internal Label label_6;

	internal NumericUpDown numericUpDown_3;

	internal Panel panel_4;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	internal Label label_7;

	internal Label label_8;

	internal Panel panel_5;

	internal RadioButton radioButton_6;

	internal RadioButton radioButton_7;

	internal Label label_9;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	public F_TuftingCounterSettings()
	{
		Class76.smethod_200(this);
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
		if (Settings.ContourOutBorderType != tuftingBorderOffsetType.Contour)
		{
			if (Settings.ContourOutBorderType == tuftingBorderOffsetType.Spiral)
			{
				radioButton_3.Checked = true;
			}
		}
		else
		{
			radioButton_2.Checked = true;
		}
		if (Settings.ContourOutBorderFillDirection != ClockDirectionType.CCW)
		{
			if (Settings.ContourOutBorderFillDirection == ClockDirectionType.CW)
			{
				radioButton_1.Checked = true;
			}
		}
		else
		{
			radioButton_0.Checked = true;
		}
		numericUpDown_2.Value = Settings.ContourOutBorderCount;
		if (Settings.ContourInBorderType != tuftingBorderOffsetType.Contour)
		{
			if (Settings.ContourInBorderType == tuftingBorderOffsetType.Spiral)
			{
				radioButton_5.Checked = true;
			}
		}
		else
		{
			radioButton_4.Checked = true;
		}
		if (Settings.ContourInBorderFillDirection != ClockDirectionType.CCW)
		{
			if (Settings.ContourInBorderFillDirection == ClockDirectionType.CW)
			{
				radioButton_7.Checked = true;
			}
		}
		else
		{
			radioButton_6.Checked = true;
		}
		numericUpDown_3.Value = Settings.ContourInBorderCount;
		numericUpDown_2.Value = Settings.ContourOutBorderCount;
		numericUpDown_1.Value = (decimal)Settings.ContourInnerOffset;
		numericUpDown_0.Value = (decimal)Settings.ContourOutterOffset;
		checkBox_1.Checked = Settings.ContourOutBorderConnect;
		checkBox_0.Checked = Settings.ContourInBorderConenct;
		checkBox_3.Checked = Settings.ContourOutBorderEnable;
		checkBox_2.Checked = Settings.ContourInBorderEnable;
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
			Settings.ContourInBorderCount = (int)numericUpDown_3.Value;
			Settings.ContourInnerOffset = (double)numericUpDown_1.Value;
			Settings.ContourOutterOffset = (double)numericUpDown_0.Value;
			Settings.ContourOutBorderCount = (int)numericUpDown_2.Value;
			Settings.ContourOutBorderConnect = checkBox_1.Checked;
			Settings.ContourInBorderConenct = checkBox_0.Checked;
			Settings.ContourOutBorderEnable = checkBox_3.Checked;
			Settings.ContourInBorderEnable = checkBox_2.Checked;
			if (!radioButton_2.Checked)
			{
				if (radioButton_3.Checked)
				{
					Settings.ContourOutBorderType = tuftingBorderOffsetType.Spiral;
				}
			}
			else
			{
				Settings.ContourOutBorderType = tuftingBorderOffsetType.Contour;
			}
			if (!radioButton_0.Checked)
			{
				if (radioButton_1.Checked)
				{
					Settings.ContourOutBorderFillDirection = ClockDirectionType.CW;
				}
			}
			else
			{
				Settings.ContourOutBorderFillDirection = ClockDirectionType.CCW;
			}
			if (!radioButton_4.Checked)
			{
				if (radioButton_5.Checked)
				{
					Settings.ContourInBorderType = tuftingBorderOffsetType.Spiral;
				}
			}
			else
			{
				Settings.ContourInBorderType = tuftingBorderOffsetType.Contour;
			}
			if (!radioButton_6.Checked)
			{
				if (radioButton_7.Checked)
				{
					Settings.ContourInBorderFillDirection = ClockDirectionType.CW;
				}
			}
			else
			{
				Settings.ContourInBorderFillDirection = ClockDirectionType.CCW;
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
