using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingPunteriz : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public double PunterizWidth = 30.0;

	public double PunterizHeight = 3.0;

	public double PunterizLength = 2.0;

	public SewingPunterizType PunterizType = SewingPunterizType.CenterLeft;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Panel panel_0;

	internal Label label_3;

	public F_SewingPunteriz()
	{
		Class186.smethod_8(this);
	}

	public void Init()
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
		numericUpDown_0.Value = (decimal)PunterizLength;
		numericUpDown_1.Value = (decimal)PunterizWidth;
		numericUpDown_2.Value = (decimal)PunterizHeight;
		if (PunterizType != SewingPunterizType.CenterLeft)
		{
			if (PunterizType != SewingPunterizType.CenterRigth)
			{
				if (PunterizType != SewingPunterizType.MinLeft)
				{
					if (PunterizType == SewingPunterizType.MinRigth)
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
				radioButton_1.Checked = true;
			}
		}
		else
		{
			radioButton_0.Checked = true;
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 1)
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
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
			Class186.smethod_392(this);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
