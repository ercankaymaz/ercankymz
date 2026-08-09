using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Machine;

public class F_MachineOtherCodeCfg : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	public MachineOtherCodeInfo OtherCode = new MachineOtherCodeInfo();

	internal string string_0 = "MachineOtherCodeInfo";

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal TextBox textBox_0;

	internal TextBox textBox_1;

	public NumericUpDown spn_time;

	internal Label label_3;

	internal TextBox textBox_2;

	public F_MachineOtherCodeCfg()
	{
		Class186.smethod_160(this);
	}

	public void Init()
	{
		string text = string_0 + " Init";
		try
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
			spn_time.Value = (decimal)OtherCode.TimeAsSec;
			textBox_1.Text = OtherCode.OtherCodeExplanation;
			textBox_0.Text = OtherCode.OtherCode;
			textBox_2.Text = OtherCode.ExtraCode;
			Properties.Result = DialogResult.None;
			Properties.Inited = true;
			LoadLangueage();
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message);
			buException.throwException(ex, text, ShowMessageBox: true);
		}
	}

	public void LoadLangueage()
	{
		string text = string_0 + " LoadLangueage";
		try
		{
			Text = buLangTranslate.preDef.Other + " " + buLangTranslate.preDef.Code + " " + buLangTranslate.preDef.Configuration;
			label_0.Text = buLangTranslate.preDef.Extra;
			label_1.Text = buLangTranslate.preDef.Other + " " + buLangTranslate.preDef.Code;
			label_3.Text = buLangTranslate.preDef.Time;
			label_2.Text = buLangTranslate.preDef.Explanation;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			btn_ok.Text = buLangTranslate.preDef.Ok;
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message);
			buException.throwException(ex, text, ShowMessageBox: true);
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		string text = string_0 + " F_FormClosing";
		try
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
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message);
			buException.throwException(ex, text, ShowMessageBox: true);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		string text = string_0 + " btn_Click";
		try
		{
			if (Properties.Result == DialogResult.OK)
			{
				return;
			}
			Control control = sender as Control;
			if (control.Name == btn_ok.Name)
			{
				if (!Properties.Inited)
				{
					return;
				}
				if (Properties.ReadOnly)
				{
					Dispose();
					return;
				}
				Class186.smethod_673(this);
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
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message);
			buException.throwException(ex, text, ShowMessageBox: true);
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
