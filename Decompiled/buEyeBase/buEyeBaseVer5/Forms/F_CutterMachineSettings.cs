using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_CutterMachineSettings : Form
{
	public static List<string> Captions = new List<string>();

	public CutterProgramSettings Settings = new CutterProgramSettings();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal Panel panel_0;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_1;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Label label_3;

	public F_CutterMachineSettings()
	{
		buFunctions.CultureSettings();
		Class186.smethod_428(this);
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
		numericUpDown_0.Value = (decimal)Settings.DrillAuxDaimeterValue;
		numericUpDown_1.Value = (decimal)Settings.DrillMainDaimeterValue;
		LoadLanguage();
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "NestRectPartAdd LoadLanguage";
		try
		{
			if (Captions.Count >= 4)
			{
				Text = Captions[0];
				label_2.Text = Captions[1];
				label_1.Text = Captions[2];
				button_0.Text = Captions[3];
				button_1.Text = Captions[4];
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
			Settings.DrillAuxDaimeterValue = (double)numericUpDown_0.Value;
			Settings.DrillMainDaimeterValue = (double)numericUpDown_1.Value;
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Close)
			{
				Close();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_1.Name)
		{
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Close)
			{
				Close();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
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
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Close)
			{
				Close();
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
