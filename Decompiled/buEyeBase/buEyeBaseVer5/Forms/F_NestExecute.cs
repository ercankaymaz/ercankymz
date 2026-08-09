using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_NestExecute : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public buNestingSettings Settings = new buNestingSettings();

	public buNestingRuntime RunTimeSettings = new buNestingRuntime();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal Panel panel_0;

	internal Label label_1;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Label label_2;

	internal Label label_3;

	internal Panel panel_1;

	internal Label label_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_0;

	internal Panel panel_2;

	public TextBox txt_name;

	internal Label label_6;

	public TextBox txt_explanation;

	public F_NestExecute()
	{
		buFunctions.CultureSettings();
		Class186.smethod_46(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
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
		if (RunTimeSettings.MaxNestingTimeSec < 1)
		{
			RunTimeSettings.MaxNestingTimeSec = 1;
		}
		if (RunTimeSettings.MaxNestingTimeSec > 10000)
		{
			RunTimeSettings.MaxNestingTimeSec = 10000;
		}
		txt_name.Text = RunTimeSettings.NestingJobName;
		txt_explanation.Text = RunTimeSettings.NestingJobExplanation;
		numericUpDown_0.Value = RunTimeSettings.MaxNestingTimeSec;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "NestPartAdd LoadLanguage";
		try
		{
			if (Captions.Count >= 6)
			{
				Text = Captions[0];
				label_1.Text = Captions[1];
				label_5.Text = Captions[2];
				label_6.Text = Captions[3];
				label_3.Text = Captions[4];
				button_0.Text = Captions[5];
				button_1.Text = Captions[6];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
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
		if (control.Name == button_1.Name)
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

	public void Apply()
	{
		RunTimeSettings.MaxNestingTimeSec = (int)numericUpDown_0.Value;
		RunTimeSettings.NestingJobName = txt_name.Text;
		RunTimeSettings.NestingJobExplanation = txt_explanation.Text;
	}

	internal void method_2(object sender, FormClosingEventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
