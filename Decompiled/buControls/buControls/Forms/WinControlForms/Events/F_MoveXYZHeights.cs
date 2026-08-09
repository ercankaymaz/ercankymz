using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Events;

public class F_MoveXYZHeights : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MoveHeightEventVar Settings = new MoveHeightEventVar();

	internal IContainer icontainer_0 = null;

	internal RadioButton radioButton_0;

	internal Panel panel_0;

	internal RadioButton radioButton_1;

	internal NumericUpDown numericUpDown_0;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Label label_0;

	internal Button button_1;

	internal Panel panel_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Panel panel_2;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	public TextBox txt_zbottom;

	public TextBox txt_ztop;

	public TextBox txt_yfrontpos;

	public TextBox txt_ybackpos;

	public TextBox txt_xrightpos;

	public TextBox txt_xfleftpos;

	public F_MoveXYZHeights()
	{
		Class76.smethod_354(this);
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
		numericUpDown_0.Value = (decimal)Settings.MoveToPosition;
		if (Settings.ZType != TopBottomType.Top)
		{
			radioButton_1.Checked = true;
		}
		else
		{
			radioButton_0.Checked = true;
		}
		if (Settings.XType != LeftRightType.Left)
		{
			radioButton_4.Checked = true;
		}
		else
		{
			radioButton_5.Checked = true;
		}
		if (Settings.YType != FrontBackType.Back)
		{
			radioButton_2.Checked = true;
		}
		else
		{
			radioButton_3.Checked = true;
		}
		if (Settings.Axis != AxesXYZ.Z)
		{
			if (Settings.Axis != AxesXYZ.X)
			{
				if (Settings.Axis == AxesXYZ.Y)
				{
					panel_2.Visible = false;
					panel_1.Visible = true;
					panel_0.Visible = false;
					panel_1.Location = new Point(5, 7);
				}
			}
			else
			{
				panel_2.Visible = true;
				panel_1.Visible = false;
				panel_0.Visible = false;
				panel_2.Location = new Point(5, 7);
			}
		}
		else
		{
			panel_2.Visible = false;
			panel_1.Visible = false;
			panel_0.Visible = true;
			panel_0.Location = new Point(5, 7);
		}
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
		if (control.Name == button_0.Name)
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
			Apply();
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

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		Settings.MoveToPosition = (double)numericUpDown_0.Value;
		if (!radioButton_0.Checked)
		{
			Settings.ZType = TopBottomType.Bottom;
		}
		else
		{
			Settings.ZType = TopBottomType.Top;
		}
		if (!radioButton_4.Checked)
		{
			Settings.XType = LeftRightType.Left;
		}
		else
		{
			Settings.XType = LeftRightType.Right;
		}
		if (!radioButton_3.Checked)
		{
			Settings.YType = FrontBackType.Front;
		}
		else
		{
			Settings.YType = FrontBackType.Back;
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
