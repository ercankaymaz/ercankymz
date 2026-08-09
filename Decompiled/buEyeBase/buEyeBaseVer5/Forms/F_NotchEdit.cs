using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_NotchEdit : Form
{
	public static List<string> Captions = new List<string>();

	public CutterNotch Notch = new CutterNotch();

	public bool ChangeDirection;

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_0;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Panel panel_0;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_1;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Panel panel_2;

	internal ComboBox comboBox_0;

	internal Label label_6;

	internal Label label_7;

	internal Panel panel_3;

	internal Label label_8;

	internal Label label_9;

	internal CheckBox checkBox_0;

	public F_NotchEdit()
	{
		buFunctions.CultureSettings();
		Class186.smethod_60(this);
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
		numericUpDown_0.Value = (decimal)Notch.Length;
		numericUpDown_1.Value = (decimal)Notch.Width;
		ArrayList EnumItems = new ArrayList();
		buFunctions.GetEnumTypeValues(Notch.NotchType, ref EnumItems);
		buFunctions.ComboboxAddItem(EnumItems, Convert.ToInt32(Notch.NotchType), ref comboBox_0);
		if (Notch.NotchType != CutterNotchType.VNotch)
		{
			comboBox_0.SelectedIndex = 0;
		}
		else
		{
			comboBox_0.SelectedIndex = 1;
		}
		LoadLanguage();
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "NestRectPartAdd LoadLanguage";
		try
		{
			if (Captions.Count >= 6)
			{
				Text = Captions[0];
				label_5.Text = Captions[1];
				label_2.Text = Captions[2];
				label_7.Text = Captions[3];
				label_9.Text = Captions[4];
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
			Notch.Length = (double)numericUpDown_0.Value;
			Notch.Width = (double)numericUpDown_0.Value;
			Notch.NotchType = (CutterNotchType)buGeneral.EnumValueFromInt(Notch.NotchType, comboBox_0.SelectedIndex);
			ChangeDirection = checkBox_0.Checked;
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
