using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buMutliTextbox;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleGCodeViewV1 : Form
{
	private string string_0 = "F_MarbleGCodeViewV1";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public int BaseWidth = 555;

	public int BaseHeight = 575;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buGround ground_base;

	public buButton btn_close;

	public buMultiTextBox txt_gcode;

	public buLabel lbl_slash;

	public buLabel lbl_totalline;

	public buLabel lbl_actualline;

	public buButton btn_size_2_0;

	public buButton btn_size_1_5;

	public buButton btn_normalsize;

	public F_MarbleGCodeViewV1()
	{
		Class186.smethod_460(this);
	}

	public void UpdateVisuals()
	{
		string text = "UpdateVisuals";
		try
		{
			LoadLanguage();
			if (buEyeVars.parVisual != null && (!PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce))
			{
				FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
				if (fileInfo.Exists)
				{
					Control.ControlCollection controlCollection = null;
					controlCollection = base.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					controlCollection = ground_base.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					PropertiesForm.VisualUpdated = true;
				}
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
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			ground_base.Text = "G " + buLangTranslate.preDef.Codes;
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
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == btn_close.Name)
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
		if (control.Name == btn_size_1_5.Name)
		{
			base.Width = Convert.ToInt32((double)BaseWidth * 1.5);
			base.Height = Convert.ToInt32((double)BaseHeight * 1.5);
		}
		if (control.Name == btn_size_2_0.Name)
		{
			base.Width = Convert.ToInt32(BaseWidth * 2);
			base.Height = Convert.ToInt32((double)BaseHeight * 1.7);
		}
		if (control.Name == btn_normalsize.Name)
		{
			base.Width = Convert.ToInt32(BaseWidth);
			base.Height = Convert.ToInt32(BaseHeight);
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
