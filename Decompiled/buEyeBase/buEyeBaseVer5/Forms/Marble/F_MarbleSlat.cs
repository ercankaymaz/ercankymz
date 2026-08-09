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

public class F_MarbleSlat : Form
{
	private string string_0 = "F_MarbleSlat";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleRuntimeSettings RuntimeSettings = new MarbleRuntimeSettings();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buGround ground_base;

	public buButton btn_close;

	public buSpin spn_EA;

	public buSpin spn_SA;

	public buSpin spn_width;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buSpin spn_offset;

	public buCheckBox chk_addangletoselectededge;

	public F_MarbleSlat()
	{
		Class186.smethod_226(this);
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
		LoadLanguage();
		spn_width.Value = RuntimeSettings.SlatWidth;
		spn_SA.Value = RuntimeSettings.SlatStartAngle;
		spn_EA.Value = RuntimeSettings.SlatEndAngle;
		spn_offset.Value = RuntimeSettings.SlatOffset;
		chk_addangletoselectededge.Check = RuntimeSettings.SlatAddAngleSelectedEdge;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			ground_base.Text = buLangTranslate.preDef.Slat;
			btn_ok.Text = buLangTranslate.preDef.Ok;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			spn_width.Caption.Caption = buLangTranslate.preDef.Width;
			spn_SA.Caption.Caption = buLangTranslate.preDef.StartAngle;
			spn_EA.Caption.Caption = buLangTranslate.preDef.EndAngle;
			spn_offset.Caption.Caption = buLangTranslate.preDef.Offset;
			chk_addangletoselectededge.Text = buLangTranslate.preCaptionMarble.AddAngleValueToSelectedEdge;
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
		RuntimeSettings.SlatWidth = spn_width.Value;
		RuntimeSettings.SlatStartAngle = spn_SA.Value;
		RuntimeSettings.SlatEndAngle = spn_EA.Value;
		RuntimeSettings.SlatOffset = spn_offset.Value;
		RuntimeSettings.SlatAddAngleSelectedEdge = chk_addangletoselectededge.Check;
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
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
		}
		catch (Exception)
		{
		}
	}

	internal void method_2(object sender, EventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
