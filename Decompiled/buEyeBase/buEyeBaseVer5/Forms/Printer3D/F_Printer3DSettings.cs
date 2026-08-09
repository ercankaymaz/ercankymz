using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms.Printer3D;

public class F_Printer3DSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public Printer3DSettings Settings = new Printer3DSettings();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal CheckBox checkBox_0;

	internal Label label_3;

	internal Label label_4;

	internal CheckBox checkBox_1;

	internal Label label_5;

	internal NumericUpDown numericUpDown_3;

	internal Label label_6;

	internal NumericUpDown numericUpDown_4;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Panel panel_0;

	internal Label label_7;

	internal NumericUpDown numericUpDown_5;

	internal Label label_8;

	internal NumericUpDown numericUpDown_6;

	internal Label label_9;

	internal NumericUpDown numericUpDown_7;

	internal Label label_10;

	internal NumericUpDown numericUpDown_8;

	internal Label label_11;

	internal NumericUpDown numericUpDown_9;

	internal Label label_12;

	internal CheckBox checkBox_2;

	internal Label label_13;

	internal CheckBox checkBox_3;

	internal Panel panel_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	public F_Printer3DSettings()
	{
		Class186.smethod_747(this);
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
		ControlUpdate();
		LoadLanguage();
		numericUpDown_2.Value = (decimal)Settings.NozzleDiameter;
		numericUpDown_1.Value = (decimal)Settings.OffsetXY;
		numericUpDown_0.Value = Settings.SliceCount;
		checkBox_0.Checked = Settings.InFill;
		checkBox_1.Checked = Settings.Simplify;
		checkBox_2.Checked = Settings.ZSpiralMove;
		checkBox_3.Checked = Settings.UseSpline;
		numericUpDown_3.Value = (decimal)Settings.FeedSpeed;
		numericUpDown_4.Value = (decimal)Settings.PlungeSpeed;
		numericUpDown_6.Value = (decimal)Settings.TopHeight;
		numericUpDown_5.Value = (decimal)Settings.SliceStep;
		numericUpDown_7.Value = (decimal)Settings.FilletRadius;
		numericUpDown_9.Value = (decimal)Settings.FilletLimitMinAngle;
		numericUpDown_8.Value = (decimal)Settings.FilletLimitMaxAngle;
		if (Settings.SliceType != Printer3DSliceType.Count)
		{
			radioButton_1.Checked = true;
		}
		else
		{
			radioButton_0.Checked = true;
		}
		if (Settings.SpiralConnection != Printer3DSpiralNextLEvelConnectionType.Linear)
		{
			if (Settings.SpiralConnection != Printer3DSpiralNextLEvelConnectionType.Quadratic)
			{
				if (Settings.SpiralConnection != Printer3DSpiralNextLEvelConnectionType.Cubic)
				{
					if (Settings.SpiralConnection == Printer3DSpiralNextLEvelConnectionType.Bezeir)
					{
						radioButton_3.Checked = true;
					}
				}
				else
				{
					radioButton_2.Checked = true;
				}
			}
			else
			{
				radioButton_5.Checked = true;
			}
		}
		else
		{
			radioButton_4.Checked = true;
		}
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

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		Settings.NozzleDiameter = (double)numericUpDown_2.Value;
		Settings.OffsetXY = (double)numericUpDown_1.Value;
		Settings.SliceCount = (int)numericUpDown_0.Value;
		Settings.InFill = checkBox_0.Checked;
		Settings.Simplify = checkBox_1.Checked;
		Settings.ZSpiralMove = checkBox_2.Checked;
		Settings.UseSpline = checkBox_3.Checked;
		Settings.FeedSpeed = (double)numericUpDown_3.Value;
		Settings.PlungeSpeed = (double)numericUpDown_4.Value;
		Settings.TopHeight = (double)numericUpDown_6.Value;
		Settings.SliceStep = (double)numericUpDown_5.Value;
		Settings.FilletRadius = (double)numericUpDown_7.Value;
		Settings.FilletLimitMinAngle = (double)numericUpDown_9.Value;
		Settings.FilletLimitMaxAngle = (double)numericUpDown_8.Value;
		if (!radioButton_0.Checked)
		{
			Settings.SliceType = Printer3DSliceType.Step;
		}
		else
		{
			Settings.SliceType = Printer3DSliceType.Count;
		}
		if (!radioButton_4.Checked)
		{
			if (!radioButton_5.Checked)
			{
				if (!radioButton_2.Checked)
				{
					Settings.SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Bezeir;
				}
				else
				{
					Settings.SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Cubic;
				}
			}
			else
			{
				Settings.SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Quadratic;
			}
		}
		else
		{
			Settings.SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Linear;
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
		if (!(control.Name == btn_ok.Name))
		{
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
		else
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
	}

	internal void method_2(object sender, EventArgs e)
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
