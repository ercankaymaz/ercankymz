using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.GCode;

public class F_FoamGCodeConverter : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GCodeConverter Converter = new GCodeConverter();

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal NumericUpDown numericUpDown_4;

	internal NumericUpDown numericUpDown_5;

	internal Label label_4;

	internal NumericUpDown numericUpDown_6;

	internal NumericUpDown numericUpDown_7;

	internal Label label_5;

	internal NumericUpDown numericUpDown_8;

	internal NumericUpDown numericUpDown_9;

	internal Label label_6;

	internal NumericUpDown numericUpDown_10;

	internal NumericUpDown numericUpDown_11;

	internal Label label_7;

	internal NumericUpDown numericUpDown_12;

	internal NumericUpDown numericUpDown_13;

	internal Label label_8;

	internal NumericUpDown numericUpDown_14;

	internal NumericUpDown numericUpDown_15;

	internal Label label_9;

	internal NumericUpDown numericUpDown_16;

	internal Label label_10;

	public F_FoamGCodeConverter()
	{
		Class186.smethod_717(this);
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
		numericUpDown_7.Value = (decimal)Converter.AMultiply;
		numericUpDown_9.Value = (decimal)Converter.BMultiply;
		numericUpDown_11.Value = (decimal)Converter.CMultiply;
		numericUpDown_0.Value = (decimal)Converter.XMultiply;
		numericUpDown_3.Value = (decimal)Converter.YMultiply;
		numericUpDown_5.Value = (decimal)Converter.ZMultiply;
		numericUpDown_15.Value = (decimal)Converter.SMultiply;
		numericUpDown_13.Value = (decimal)Converter.FMultiply;
		numericUpDown_6.Value = (decimal)Converter.AOffset;
		numericUpDown_8.Value = (decimal)Converter.BOffset;
		numericUpDown_10.Value = (decimal)Converter.COffset;
		numericUpDown_1.Value = (decimal)Converter.XOffset;
		numericUpDown_2.Value = (decimal)Converter.YOffset;
		numericUpDown_4.Value = (decimal)Converter.ZOffset;
		numericUpDown_12.Value = (decimal)Converter.FOffset;
		numericUpDown_14.Value = (decimal)Converter.SOffset;
		numericUpDown_16.Value = (decimal)Converter.FilterLength;
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

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		Converter.AMultiply = (double)numericUpDown_7.Value;
		Converter.BMultiply = (double)numericUpDown_9.Value;
		Converter.CMultiply = (double)numericUpDown_11.Value;
		Converter.XMultiply = (double)numericUpDown_0.Value;
		Converter.YMultiply = (double)numericUpDown_3.Value;
		Converter.ZMultiply = (double)numericUpDown_5.Value;
		Converter.SMultiply = (double)numericUpDown_15.Value;
		Converter.FMultiply = (double)numericUpDown_13.Value;
		Converter.AOffset = (double)numericUpDown_6.Value;
		Converter.BOffset = (double)numericUpDown_8.Value;
		Converter.COffset = (double)numericUpDown_10.Value;
		Converter.XOffset = (double)numericUpDown_1.Value;
		Converter.YOffset = (double)numericUpDown_2.Value;
		Converter.ZOffset = (double)numericUpDown_4.Value;
		Converter.FOffset = (double)numericUpDown_12.Value;
		Converter.SOffset = (double)numericUpDown_14.Value;
		Converter.FilterLength = (double)numericUpDown_16.Value;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
