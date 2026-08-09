using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Tufting;

public class F_TuftingTraceSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public TuftingSettings Settings = new TuftingSettings();

	internal IContainer icontainer_0 = null;

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

	internal Label label_6;

	internal CheckBox checkBox_2;

	internal Label label_7;

	internal CheckBox checkBox_3;

	internal Label label_8;

	internal CheckBox checkBox_4;

	public F_TuftingTraceSettings()
	{
		Class76.smethod_356(this);
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
		if (Settings.TraceFillDirection != ClockDirectionType.CW)
		{
			if (Settings.TraceFillDirection == ClockDirectionType.CCW)
			{
				radioButton_0.Checked = true;
			}
		}
		else
		{
			radioButton_1.Checked = true;
		}
		if (Settings.TraceInOutDirection != InOutDirection.InsideToOutside)
		{
			if (Settings.TraceInOutDirection == InOutDirection.OutsideToInside)
			{
				radioButton_2.Checked = true;
			}
		}
		else
		{
			radioButton_3.Checked = true;
		}
		numericUpDown_1.Value = (decimal)Settings.TraceInnerOffset;
		numericUpDown_0.Value = (decimal)Settings.TraceOutterOffset;
		numericUpDown_2.Value = (decimal)Settings.TraceRowSpace;
		checkBox_0.Checked = Settings.TraceInnerEnable;
		checkBox_1.Checked = Settings.TraceOutterEnable;
		checkBox_2.Checked = Settings.TraceConnection;
		checkBox_3.Checked = Settings.TraceConnectOneBefore;
		checkBox_4.Checked = Settings.TraceSplineConnection;
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
			Settings.TraceInnerOffset = (double)numericUpDown_1.Value;
			Settings.TraceOutterOffset = (double)numericUpDown_0.Value;
			Settings.TraceRowSpace = (double)numericUpDown_2.Value;
			Settings.TraceInnerEnable = checkBox_0.Checked;
			Settings.TraceOutterEnable = checkBox_1.Checked;
			Settings.TraceConnection = checkBox_2.Checked;
			Settings.TraceConnectOneBefore = checkBox_3.Checked;
			Settings.TraceSplineConnection = checkBox_4.Checked;
			if (!radioButton_0.Checked)
			{
				if (radioButton_1.Checked)
				{
					Settings.TraceFillDirection = ClockDirectionType.CW;
				}
			}
			else
			{
				Settings.TraceFillDirection = ClockDirectionType.CCW;
			}
			if (!radioButton_3.Checked)
			{
				if (radioButton_2.Checked)
				{
					Settings.TraceInOutDirection = InOutDirection.OutsideToInside;
				}
			}
			else
			{
				Settings.TraceInOutDirection = InOutDirection.InsideToOutside;
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
