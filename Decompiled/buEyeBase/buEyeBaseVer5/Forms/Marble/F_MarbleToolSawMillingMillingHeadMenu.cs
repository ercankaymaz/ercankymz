using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolSawMillingMillingHeadMenu : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleToolType ToolType = MarbleToolType.Saw;

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buCheckBox chk_toolsaw;

	public buCheckBox chk_toolmilling;

	public buGround buGround1;

	public buCheckBox chk_toolmillinghead;

	public F_MarbleToolSawMillingMillingHeadMenu()
	{
		Class186.smethod_685(this);
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
		chk_toolmilling.Check = false;
		chk_toolsaw.Check = false;
		chk_toolmillinghead.Check = false;
		if (ToolType != MarbleToolType.Milling)
		{
			if (ToolType != MarbleToolType.MillingHead)
			{
				if (ToolType == MarbleToolType.Saw)
				{
					chk_toolsaw.Check = true;
				}
			}
			else
			{
				chk_toolmillinghead.Check = true;
			}
		}
		else
		{
			chk_toolmilling.Check = true;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			chk_toolmilling.Text = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Tool;
			chk_toolmillinghead.Text = buLangTranslate.preDef.MillingHead + " " + buLangTranslate.preDef.Tool;
			chk_toolsaw.Text = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Tool;
			buGround1.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Menu;
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

	internal void method_2(object object_0, bool bool_0)
	{
		if (PropertiesForm.Inited)
		{
			Control control = object_0 as Control;
			if (control.Name == chk_toolsaw.Name)
			{
				chk_toolsaw.Check = true;
				chk_toolmilling.Check = false;
				chk_toolmillinghead.Check = false;
				ToolType = MarbleToolType.Saw;
			}
			if (control.Name == chk_toolmilling.Name)
			{
				chk_toolsaw.Check = false;
				chk_toolmilling.Check = true;
				chk_toolmillinghead.Check = false;
				ToolType = MarbleToolType.Milling;
			}
			if (control.Name == chk_toolmillinghead.Name)
			{
				chk_toolsaw.Check = false;
				chk_toolmilling.Check = false;
				chk_toolmillinghead.Check = true;
				ToolType = MarbleToolType.MillingHead;
			}
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
