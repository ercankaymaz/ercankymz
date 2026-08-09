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

public class F_MarbleCollapse : Form
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

	public buSpin spn_collapseoffset;

	public buSpin spn_collapsedepth;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buCheckBox chk_collapseenable;

	public buCheckBox chk_collapseoutside;

	public buCheckBox chk_collapseinside;

	internal buCheckBox buCheckBox_0;

	internal buCheckBox buCheckBox_1;

	public buLabel lbl_Tool;

	public F_MarbleCollapse()
	{
		Class186.smethod_360(this);
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
		spn_collapsedepth.Value = RuntimeSettings.CollapseDepth;
		spn_collapseoffset.Value = RuntimeSettings.CollapseOffset;
		chk_collapseenable.Check = RuntimeSettings.CollapseEnable;
		if (RuntimeSettings.CollapseDirection != OutsideInsideType.Outside)
		{
			chk_collapseoutside.Check = false;
			chk_collapseinside.Check = true;
		}
		else
		{
			chk_collapseoutside.Check = true;
			chk_collapseinside.Check = false;
		}
		if (RuntimeSettings.CollapseToolType != MarbleToolType.Milling)
		{
			buCheckBox_1.Check = false;
			buCheckBox_0.Check = true;
		}
		else
		{
			buCheckBox_1.Check = true;
			buCheckBox_0.Check = false;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			ground_base.Text = buLangTranslate.preDef.Collapse;
			btn_ok.Text = buLangTranslate.preDef.Ok;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			spn_collapsedepth.Caption.Caption = buLangTranslate.preDef.Depth;
			spn_collapseoffset.Caption.Caption = buLangTranslate.preDef.Offset;
			chk_collapseenable.Text = buLangTranslate.preDef.Enable;
			chk_collapseinside.Text = buLangTranslate.preDef.Inside;
			chk_collapseoutside.Text = buLangTranslate.preDef.Outside;
			lbl_Tool.Text = buLangTranslate.preDef.Tool;
			buCheckBox_0.Text = buLangTranslate.preDef.MillingHead;
			buCheckBox_1.Text = buLangTranslate.preDef.Milling;
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
		RuntimeSettings.CollapseDepth = spn_collapsedepth.Value;
		RuntimeSettings.CollapseOffset = spn_collapseoffset.Value;
		RuntimeSettings.CollapseEnable = chk_collapseenable.Check;
		if (!chk_collapseoutside.Check)
		{
			RuntimeSettings.CollapseDirection = OutsideInsideType.Inside;
		}
		else
		{
			RuntimeSettings.CollapseDirection = OutsideInsideType.Outside;
		}
		if (!buCheckBox_1.Check)
		{
			RuntimeSettings.CollapseToolType = MarbleToolType.MillingHead;
		}
		else
		{
			RuntimeSettings.CollapseToolType = MarbleToolType.Milling;
		}
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
			if (control.Name == buCheckBox_0.Name)
			{
				buCheckBox_0.Check = true;
				buCheckBox_1.Check = false;
			}
			if (control.Name == buCheckBox_1.Name)
			{
				buCheckBox_0.Check = false;
				buCheckBox_1.Check = true;
			}
			if (control.Name == chk_collapseoutside.Name)
			{
				chk_collapseoutside.Check = true;
				chk_collapseinside.Check = false;
			}
			if (control.Name == chk_collapseinside.Name)
			{
				chk_collapseoutside.Check = false;
				chk_collapseinside.Check = true;
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
