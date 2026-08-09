using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Machine;

public class F_MachineAxisCfg : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	public MachineAxisInfo Axis = new MachineAxisInfo();

	internal string string_0 = "F_MachineAxisCfg";

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public NumericUpDown spn_acc;

	internal Label label_0;

	internal Label label_1;

	public NumericUpDown spn_dec;

	internal Label label_2;

	public NumericUpDown spn_jerk;

	internal Label label_3;

	internal Label label_4;

	internal TextBox textBox_0;

	internal TextBox textBox_1;

	public NumericUpDown spn_speed;

	internal Label label_5;

	public F_MachineAxisCfg()
	{
		Class186.smethod_638(this);
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
			spn_acc.Value = (decimal)Axis.Acceleration;
			spn_dec.Value = (decimal)Axis.Deceleration;
			spn_jerk.Value = (decimal)Axis.Jerk;
			spn_speed.Value = (decimal)Axis.MaxSpeed;
			textBox_1.Text = Axis.AxisExplanation;
			textBox_0.Text = Axis.AxisName;
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
			Text = buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Configuration;
			label_0.Text = buLangTranslate.preDef.Acceleration;
			label_2.Text = buLangTranslate.preDef.Deceleration;
			label_3.Text = buLangTranslate.preDef.Jerk;
			label_1.Text = buLangTranslate.preDef.Name;
			label_5.Text = buLangTranslate.preDef.Speed;
			label_4.Text = buLangTranslate.preDef.Explanation;
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
				Class186.smethod_550(this);
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
