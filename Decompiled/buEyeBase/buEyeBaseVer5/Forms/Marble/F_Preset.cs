using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_Preset : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public double ReturnVal = 0.0;

	public double Preset1 = 0.01;

	public double Preset2 = 0.1;

	public double Preset3 = 1.0;

	public double Preset4 = 5.0;

	public double Preset5 = 10.0;

	public double Preset6 = 45.0;

	public double Preset7 = 100.0;

	public double Preset8 = 500.0;

	public double Preset9 = 1000.0;

	private IContainer icontainer_0 = null;

	internal buPanel buPanel_0;

	internal buGround buGround_0;

	public buButton btn_close;

	public buButton btn_preset9;

	public buButton btn_preset8;

	public buButton btn_preset7;

	public buButton btn_preset6;

	public buButton btn_preset5;

	public buButton btn_preset4;

	public buButton btn_preset3;

	public buButton btn_preset2;

	public buButton btn_preset1;

	public F_Preset()
	{
		Class186.smethod_103(this);
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
		btn_preset1.Text = Preset1.ToString();
		btn_preset1.Aux.ValDouble = Preset1;
		btn_preset2.Text = Preset2.ToString();
		btn_preset2.Aux.ValDouble = Preset2;
		btn_preset3.Text = Preset3.ToString();
		btn_preset3.Aux.ValDouble = Preset3;
		btn_preset4.Text = Preset4.ToString();
		btn_preset4.Aux.ValDouble = Preset4;
		btn_preset5.Text = Preset5.ToString();
		btn_preset5.Aux.ValDouble = Preset5;
		btn_preset6.Text = Preset6.ToString();
		btn_preset6.Aux.ValDouble = Preset6;
		btn_preset7.Text = Preset7.ToString();
		btn_preset7.Aux.ValDouble = Preset7;
		btn_preset8.Text = Preset8.ToString();
		btn_preset8.Aux.ValDouble = Preset8;
		btn_preset9.Text = Preset9.ToString();
		btn_preset9.Aux.ValDouble = Preset9;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			Text = buLangTranslate.preDef.Preset;
		}
		catch (Exception)
		{
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

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		buButton buButton2 = sender as buButton;
		ReturnVal = buButton2.Aux.ValDouble;
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

	internal void method_2(object sender, EventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
