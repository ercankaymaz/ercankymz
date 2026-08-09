using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.UserFiles.buCad;
using ns71;

namespace buEyeBaseVer5.Forms.Viewport;

public class F_ViewportMouseCfg : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public setMouse Settings = new setMouse();

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Label label_0;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal Panel panel_1;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	internal Label label_1;

	internal Label label_2;

	internal Panel panel_2;

	internal RadioButton radioButton_6;

	internal RadioButton radioButton_7;

	internal RadioButton radioButton_8;

	internal Panel panel_3;

	internal RadioButton radioButton_9;

	internal RadioButton radioButton_10;

	internal RadioButton radioButton_11;

	internal Label label_3;

	internal Panel panel_4;

	internal RadioButton radioButton_12;

	internal RadioButton radioButton_13;

	internal RadioButton radioButton_14;

	internal Panel panel_5;

	internal RadioButton radioButton_15;

	internal RadioButton radioButton_16;

	internal RadioButton radioButton_17;

	internal Label label_4;

	public F_ViewportMouseCfg()
	{
		Class186.smethod_141(this);
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
		if (Settings.ZoomConfigration.Button != mouseButtons.Left)
		{
			if (Settings.ZoomConfigration.Button != mouseButtons.Right)
			{
				radioButton_1.Checked = true;
			}
			else
			{
				radioButton_0.Checked = true;
			}
		}
		else
		{
			radioButton_2.Checked = true;
		}
		if (Settings.ZoomConfigration.Key != modifierKeys.Shift)
		{
			if (Settings.ZoomConfigration.Key != modifierKeys.Ctrl)
			{
				radioButton_5.Checked = true;
			}
			else
			{
				radioButton_3.Checked = true;
			}
		}
		else
		{
			radioButton_4.Checked = true;
		}
		if (Settings.PanConfigration.Button != mouseButtons.Left)
		{
			if (Settings.PanConfigration.Button != mouseButtons.Right)
			{
				radioButton_10.Checked = true;
			}
			else
			{
				radioButton_9.Checked = true;
			}
		}
		else
		{
			radioButton_11.Checked = true;
		}
		if (Settings.PanConfigration.Key != modifierKeys.Shift)
		{
			if (Settings.PanConfigration.Key != modifierKeys.Ctrl)
			{
				radioButton_8.Checked = true;
			}
			else
			{
				radioButton_6.Checked = true;
			}
		}
		else
		{
			radioButton_7.Checked = true;
		}
		if (Settings.RotateConfigration.Button != mouseButtons.Left)
		{
			if (Settings.RotateConfigration.Button != mouseButtons.Right)
			{
				radioButton_16.Checked = true;
			}
			else
			{
				radioButton_15.Checked = true;
			}
		}
		else
		{
			radioButton_17.Checked = true;
		}
		if (Settings.RotateConfigration.Key != modifierKeys.Shift)
		{
			if (Settings.RotateConfigration.Key != modifierKeys.Ctrl)
			{
				radioButton_14.Checked = true;
			}
			else
			{
				radioButton_12.Checked = true;
			}
		}
		else
		{
			radioButton_13.Checked = true;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == button_0.Name)
		{
			if (radioButton_8.Checked)
			{
				if (radioButton_11.Checked)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible + " " + buLangTranslate.preDef.Pan + " " + buLangTranslate.preDef.None + " + " + buLangTranslate.preDef.Left);
					return;
				}
				if (radioButton_9.Checked)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible + " " + buLangTranslate.preDef.Pan + " " + buLangTranslate.preDef.None + " + " + buLangTranslate.preDef.Right);
					return;
				}
			}
			if (radioButton_5.Checked)
			{
				if (radioButton_2.Checked)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible + " " + buLangTranslate.preDef.Zoom + " " + buLangTranslate.preDef.None + " + " + buLangTranslate.preDef.Left);
					return;
				}
				if (radioButton_0.Checked)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible + " " + buLangTranslate.preDef.Zoom + " " + buLangTranslate.preDef.None + " + " + buLangTranslate.preDef.Right);
					return;
				}
			}
			if (radioButton_14.Checked)
			{
				if (radioButton_17.Checked)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible + " " + buLangTranslate.preDef.Rotate + " " + buLangTranslate.preDef.None + " + " + buLangTranslate.preDef.Left);
					return;
				}
				if (radioButton_15.Checked)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible + " " + buLangTranslate.preDef.Rotate + " " + buLangTranslate.preDef.None + " + " + buLangTranslate.preDef.Right);
					return;
				}
			}
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

	public void Apply()
	{
		if (!radioButton_2.Checked)
		{
			if (!radioButton_0.Checked)
			{
				if (radioButton_2.Checked)
				{
					Settings.ZoomConfigration.Button = mouseButtons.Middle;
				}
			}
			else
			{
				Settings.ZoomConfigration.Button = mouseButtons.Right;
			}
		}
		else
		{
			Settings.ZoomConfigration.Button = mouseButtons.Left;
		}
		if (!radioButton_4.Checked)
		{
			if (!radioButton_3.Checked)
			{
				if (radioButton_5.Checked)
				{
					Settings.ZoomConfigration.Key = modifierKeys.None;
				}
			}
			else
			{
				Settings.ZoomConfigration.Key = modifierKeys.Ctrl;
			}
		}
		else
		{
			Settings.ZoomConfigration.Key = modifierKeys.Shift;
		}
		if (!radioButton_11.Checked)
		{
			if (!radioButton_9.Checked)
			{
				if (radioButton_11.Checked)
				{
					Settings.PanConfigration.Button = mouseButtons.Middle;
				}
			}
			else
			{
				Settings.PanConfigration.Button = mouseButtons.Right;
			}
		}
		else
		{
			Settings.PanConfigration.Button = mouseButtons.Left;
		}
		if (!radioButton_7.Checked)
		{
			if (!radioButton_6.Checked)
			{
				if (radioButton_8.Checked)
				{
					Settings.PanConfigration.Key = modifierKeys.None;
				}
			}
			else
			{
				Settings.PanConfigration.Key = modifierKeys.Ctrl;
			}
		}
		else
		{
			Settings.PanConfigration.Key = modifierKeys.Shift;
		}
		if (!radioButton_17.Checked)
		{
			if (!radioButton_15.Checked)
			{
				if (radioButton_17.Checked)
				{
					Settings.RotateConfigration.Button = mouseButtons.Middle;
				}
			}
			else
			{
				Settings.RotateConfigration.Button = mouseButtons.Right;
			}
		}
		else
		{
			Settings.RotateConfigration.Button = mouseButtons.Left;
		}
		if (!radioButton_13.Checked)
		{
			if (!radioButton_12.Checked)
			{
				if (radioButton_14.Checked)
				{
					Settings.RotateConfigration.Key = modifierKeys.None;
				}
			}
			else
			{
				Settings.RotateConfigration.Key = modifierKeys.Ctrl;
			}
		}
		else
		{
			Settings.RotateConfigration.Key = modifierKeys.Shift;
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
