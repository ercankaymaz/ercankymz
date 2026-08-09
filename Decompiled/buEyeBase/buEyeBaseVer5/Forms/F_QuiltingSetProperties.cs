using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_QuiltingSetProperties : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public QuiltingRuntimeSettings Setting = new QuiltingRuntimeSettings();

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal Panel panel_0;

	internal Label label_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	public F_QuiltingSetProperties()
	{
		Class186.smethod_549(this);
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
		if (Setting.Heads != quiltingHeadType.First)
		{
			if (Setting.Heads != quiltingHeadType.Second)
			{
				radioButton_0.Checked = true;
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

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
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

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		if (!radioButton_1.Checked)
		{
			if (!radioButton_2.Checked)
			{
				if (radioButton_0.Checked)
				{
					Setting.Heads = quiltingHeadType.Both;
				}
			}
			else
			{
				Setting.Heads = quiltingHeadType.Second;
			}
		}
		else
		{
			Setting.Heads = quiltingHeadType.First;
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
