using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamLeadInOut : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public double Length = 0.0;

	public double Angle = 0.0;

	public bool isLeadIn = true;

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal Panel panel_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal PictureBox pictureBox_0;

	public F_FoamLeadInOut()
	{
		Class186.smethod_99(this);
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
		if (!isLeadIn)
		{
			button_7.Visible = false;
			button_5.Visible = false;
			button_0.Visible = false;
			button_2.Visible = false;
			button_6.Visible = true;
			button_4.Visible = true;
			button_1.Visible = true;
			button_3.Visible = true;
		}
		else
		{
			button_6.Visible = false;
			button_4.Visible = false;
			button_1.Visible = false;
			button_3.Visible = false;
			button_7.Visible = true;
			button_5.Visible = true;
			button_0.Visible = true;
			button_2.Visible = true;
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
		numericUpDown_0.Value = (decimal)Length;
		numericUpDown_1.Value = (decimal)Angle;
	}

	public void Apply()
	{
		Length = (double)numericUpDown_0.Value;
		Angle = (double)numericUpDown_1.Value;
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
			if (!(control.Name == btn_cancel.Name))
			{
				if (control.Name == button_7.Name)
				{
					numericUpDown_1.Value = 0m;
				}
				if (control.Name == button_6.Name)
				{
					numericUpDown_1.Value = 180m;
				}
				if (control.Name == button_5.Name)
				{
					numericUpDown_1.Value = 180m;
				}
				if (control.Name == button_4.Name)
				{
					numericUpDown_1.Value = 0m;
				}
				if (control.Name == button_0.Name)
				{
					numericUpDown_1.Value = -90m;
				}
				if (control.Name == button_1.Name)
				{
					numericUpDown_1.Value = 90m;
				}
				if (control.Name == button_2.Name)
				{
					numericUpDown_1.Value = 90m;
				}
				if (control.Name == button_3.Name)
				{
					numericUpDown_1.Value = -90m;
				}
			}
			else
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
