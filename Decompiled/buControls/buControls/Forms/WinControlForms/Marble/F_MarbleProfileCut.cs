using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Marble;

public class F_MarbleProfileCut : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleProfileCut varProfileCut = new marbleProfileCut();

	public string strMessageRoughtFinish = "Rought and  Finish Both Can't be Enabled";

	public string strMessageRoughtFinishSelect = "Rought or Finish One of them must be Selected";

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal Panel panel_1;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal Label label_3;

	internal Panel panel_2;

	internal CheckBox checkBox_0;

	internal Label label_4;

	internal Panel panel_3;

	internal CheckBox checkBox_1;

	internal Label label_5;

	internal Panel panel_4;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal Label label_6;

	internal Panel panel_5;

	internal Label label_7;

	internal Label label_8;

	internal NumericUpDown numericUpDown_2;

	internal Label label_9;

	internal NumericUpDown numericUpDown_3;

	internal Label label_10;

	internal NumericUpDown numericUpDown_4;

	internal CheckBox checkBox_2;

	internal Label label_11;

	internal NumericUpDown numericUpDown_5;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	internal Label label_12;

	internal NumericUpDown numericUpDown_6;

	internal Label label_13;

	internal NumericUpDown numericUpDown_7;

	internal Label label_14;

	internal NumericUpDown numericUpDown_8;

	internal CheckBox checkBox_5;

	internal Label label_15;

	internal NumericUpDown numericUpDown_9;

	public F_MarbleProfileCut()
	{
		Class76.smethod_289(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		checkBox_1.Checked = varProfileCut.FinishEnable;
		checkBox_0.Checked = varProfileCut.RoughEnable;
		checkBox_2.Checked = varProfileCut.MaxToMinDirection;
		checkBox_4.Checked = varProfileCut.SmoothZigzagMode;
		checkBox_3.Checked = varProfileCut.RoughZigzagMode;
		checkBox_5.Checked = varProfileCut.MoveSafeDistanceForFinishZigzagMode;
		numericUpDown_9.Value = (decimal)varProfileCut.RotationAngle;
		numericUpDown_5.Value = (decimal)varProfileCut.StartPosition;
		numericUpDown_1.Value = (decimal)varProfileCut.BaseHeight;
		numericUpDown_0.Value = (decimal)varProfileCut.Length;
		numericUpDown_2.Value = (decimal)varProfileCut.FinishStep;
		numericUpDown_3.Value = (decimal)varProfileCut.RoughtOffset;
		numericUpDown_4.Value = (decimal)varProfileCut.FinishOffset;
		numericUpDown_8.Value = (decimal)varProfileCut.RoughtDevideLen;
		numericUpDown_7.Value = (decimal)varProfileCut.FinishDevideLen;
		numericUpDown_6.Value = (decimal)varProfileCut.DownDevideLen;
		radioButton_0.Checked = true;
		if (varProfileCut.CamTypeRough != CamAxisCountType.Axis3)
		{
			radioButton_1.Checked = true;
		}
		else
		{
			radioButton_2.Checked = true;
		}
		if (varProfileCut.CamTypeFinish != CamAxisCountType.Axis3)
		{
			radioButton_3.Checked = true;
		}
		else
		{
			radioButton_4.Checked = true;
		}
		Class76.smethod_669(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
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
				if (checkBox_1.Checked & checkBox_0.Checked)
				{
					buString.MessageBoxWarning(strMessageRoughtFinish);
					return;
				}
				if (!checkBox_1.Checked & !checkBox_0.Checked)
				{
					buString.MessageBoxWarning(strMessageRoughtFinishSelect);
					return;
				}
				Class76.smethod_646(this);
				Properties.Result = DialogResult.OK;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (Properties.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if (control.Name == btn_cancel.Name)
			{
				Properties.Result = DialogResult.Cancel;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (Properties.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		new Control();
		if (!Properties.Inited)
		{
		}
	}

	internal void method_3(object sender, PaintEventArgs e)
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
