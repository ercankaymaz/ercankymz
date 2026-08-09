using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEventCopyMulti : Form
{
	private string string_0 = "F_MarbleEventCopyMulti";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	public buGround ground_base;

	public buButton btn_close;

	public buSpin spn_xdistance;

	public buSpin spn_ydistance;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buSpin spn_ycount;

	public buSpin spn_xcount;

	public F_MarbleEventCopyMulti()
	{
		Class186.smethod_789(this);
	}

	public void UpdateVisuals()
	{
		string text = "UpdateVisuals";
		try
		{
			if (buEyeVars.parVisual != null)
			{
				LoadLanguage();
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void Init()
	{
		string text = "Init";
		try
		{
			PropertiesForm.Inited = false;
			if (!PropertiesForm.Updated)
			{
				PropertiesForm.Updated = true;
			}
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
			LoadLanguage();
			spn_xdistance.Value = buMarbleCalc.varMarbleRunSettings.CopyXDistance;
			spn_ydistance.Value = buMarbleCalc.varMarbleRunSettings.CopyYDistance;
			spn_xcount.Value = buMarbleCalc.varMarbleRunSettings.CopyXCount;
			spn_ycount.Value = buMarbleCalc.varMarbleRunSettings.CopyYCount;
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void LoadLanguage()
	{
		string text = "LoadLanguage";
		try
		{
			ground_base.Text = buLangTranslate.preDef.Linear + " " + buLangTranslate.preDef.Copy;
			spn_xdistance.Caption.Caption = buLangTranslate.preChar.X + " " + buLangTranslate.preDef.Distance;
			spn_ydistance.Caption.Caption = buLangTranslate.preChar.Y + " " + buLangTranslate.preDef.Distance;
			spn_xcount.Caption.Caption = buLangTranslate.preChar.X + " " + buLangTranslate.preDef.Count;
			spn_ycount.Caption.Caption = buLangTranslate.preChar.Y + " " + buLangTranslate.preDef.Count;
			btn_ok.Text = buLangTranslate.preDef.Ok;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		string text = "F_FormClosing";
		try
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
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void Apply()
	{
		string text = "Apply";
		try
		{
			buMarbleCalc.varMarbleRunSettings.CopyXDistance = spn_xdistance.Value;
			buMarbleCalc.varMarbleRunSettings.CopyYDistance = spn_ydistance.Value;
			buMarbleCalc.varMarbleRunSettings.CopyXCount = spn_xcount.Value;
			buMarbleCalc.varMarbleRunSettings.CopyYCount = spn_ycount.Value;
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		string text = "btn_Click";
		try
		{
			Control control = sender as Control;
			if ((control.Name == btn_cancel.Name) | (control.Name == btn_close.Name))
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
			if (control.Name == btn_ok.Name)
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
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		string text = "spn_Click";
		try
		{
			buSpin buSpin2 = sender as buSpin;
			if (AppBool.TouchPad)
			{
				F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
				f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
				f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
				f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
				if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
				{
					buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
				}
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
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
