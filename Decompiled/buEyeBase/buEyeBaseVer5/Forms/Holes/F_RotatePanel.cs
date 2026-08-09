using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using ns71;

namespace buEyeBaseVer5.Forms.Holes;

public class F_RotatePanel : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public buShape Shape = null;

	public ClockDirectionType ClockType = ClockDirectionType.CW;

	public double Degree = 90.0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal Panel panel_0;

	public RadioButton radio_ccw;

	public RadioButton radio_cw;

	public RadioButton radio_90;

	public RadioButton radio_180;

	internal Panel panel_1;

	public F_RotatePanel()
	{
		Class186.smethod_544(this);
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
		if (Degree != 180.0)
		{
			radio_180.Checked = false;
			radio_90.Checked = true;
		}
		else
		{
			radio_180.Checked = true;
			radio_90.Checked = false;
		}
		if (ClockType != ClockDirectionType.CW)
		{
			radio_ccw.Checked = true;
			radio_cw.Checked = false;
		}
		else
		{
			radio_ccw.Checked = false;
			radio_cw.Checked = true;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			Text = buLangTranslate.preDef.Rotate;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			btn_ok.Text = buLangTranslate.preDef.Ok;
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
		if (!radio_cw.Checked)
		{
			ClockType = ClockDirectionType.CCW;
		}
		else
		{
			ClockType = ClockDirectionType.CW;
		}
		if (!radio_90.Checked)
		{
			Degree = 180.0;
		}
		else
		{
			Degree = 90.0;
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
