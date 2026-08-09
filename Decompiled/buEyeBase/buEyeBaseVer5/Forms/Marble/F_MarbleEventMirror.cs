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

public class F_MarbleEventMirror : Form
{
	private string string_0 = "F_MarbleEventMirror";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	public buGround ground_base;

	public buButton btn_close;

	public buSpin spn_distance;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	public buCheckBox chk_deleteoriginale;

	public F_MarbleEventMirror()
	{
		Class186.smethod_128(this);
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
			spn_distance.Value = buMarbleCalc.varMarbleRunSettings.MirrorDistance;
			if (buMarbleCalc.varMarbleRunSettings.MirrorType != MirrorAxisXYType.X)
			{
				radioButton_0.Checked = true;
			}
			else
			{
				radioButton_1.Checked = true;
			}
			chk_deleteoriginale.Check = buMarbleCalc.varMarbleRunSettings.MirrorDeleteOriginale;
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
			ground_base.Text = buLangTranslate.preDef.Mirror;
			chk_deleteoriginale.Text = buLangTranslate.preDef.Originale + " " + buLangTranslate.preDef.Delete;
			spn_distance.Caption.Caption = buLangTranslate.preDef.Distance;
			radioButton_1.Text = buLangTranslate.preChar.X + " " + buLangTranslate.preDef.Direction;
			radioButton_0.Text = buLangTranslate.preChar.Y + " " + buLangTranslate.preDef.Direction;
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
			buMarbleCalc.varMarbleRunSettings.MirrorDeleteOriginale = chk_deleteoriginale.Check;
			buMarbleCalc.varMarbleRunSettings.MirrorDistance = spn_distance.Value;
			if (!radioButton_1.Checked)
			{
				buMarbleCalc.varMarbleRunSettings.MirrorType = MirrorAxisXYType.Y;
			}
			else
			{
				buMarbleCalc.varMarbleRunSettings.MirrorType = MirrorAxisXYType.X;
			}
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
