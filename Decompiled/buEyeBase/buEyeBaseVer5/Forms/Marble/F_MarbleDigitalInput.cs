using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleDigitalInput : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	internal buGround buGround_0;

	public buButton btn_close;

	public buButton btn_DI31;

	public buButton btn_DI16;

	public buButton btn_DI30;

	public buButton btn_DI17;

	public buButton btn_DI29;

	public buButton btn_DI18;

	public buButton btn_DI28;

	public buButton btn_DI19;

	public buButton btn_DI27;

	public buButton btn_DI20;

	public buButton btn_DI26;

	public buButton btn_DI21;

	public buButton btn_DI25;

	public buButton btn_DI22;

	public buButton btn_DI24;

	public buButton btn_DI23;

	public buButton btn_DI47;

	public buButton btn_DI32;

	public buButton btn_DI46;

	public buButton btn_DI33;

	public buButton btn_DI45;

	public buButton btn_DI34;

	public buButton btn_DI44;

	public buButton btn_DI35;

	public buButton btn_DI43;

	public buButton btn_DI36;

	public buButton btn_DI42;

	public buButton btn_DI37;

	public buButton btn_DI41;

	public buButton btn_DI38;

	public buButton btn_DI40;

	public buButton btn_DI39;

	public buPanel pnl_input1;

	public buButton btn_DI15;

	public buButton btn_DI14;

	public buButton btn_DI13;

	public buButton btn_DI12;

	public buButton btn_DI11;

	public buButton btn_DI10;

	public buButton btn_DI9;

	public buButton btn_DI8;

	public buButton btn_DI7;

	public buButton btn_DI6;

	public buButton btn_DI5;

	public buButton btn_DI4;

	public buButton btn_DI3;

	public buButton btn_DI2;

	public buButton btn_DI1;

	public buButton btn_DI0;

	public buButton btn_DI63;

	public buButton btn_DI48;

	public buButton btn_DI62;

	public buButton btn_DI49;

	public buButton btn_DI61;

	public buButton btn_DI50;

	public buButton btn_DI60;

	public buButton btn_DI51;

	public buButton btn_DI59;

	public buButton btn_DI52;

	public buButton btn_DI58;

	public buButton btn_DI53;

	public buButton btn_DI57;

	public buButton btn_DI54;

	public buButton btn_DI56;

	public buButton btn_DI55;

	public ImageList IC48;

	public buPanel pnl_input2;

	public buPanel pnl_input3;

	public buPanel pnl_input4;

	public F_MarbleDigitalInput()
	{
		Class186.smethod_305(this);
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
			buGround_0.Text = buLangTranslate.preDef.Digital + " " + buLangTranslate.preDef.Input;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
