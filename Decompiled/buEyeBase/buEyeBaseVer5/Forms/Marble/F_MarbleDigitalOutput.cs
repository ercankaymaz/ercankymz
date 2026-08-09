using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleDigitalOutput : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	internal buGround buGround_0;

	public buButton btn_close;

	public buButton btn_DO31;

	public buButton btn_DO16;

	public buButton btn_DO30;

	public buButton btn_DO17;

	public buButton btn_DO29;

	public buButton btn_DO18;

	public buButton btn_DO28;

	public buButton btn_DO19;

	public buButton btn_DO27;

	public buButton btn_DO20;

	public buButton btn_DO26;

	public buButton btn_DO21;

	public buButton btn_DO25;

	public buButton btn_DO22;

	public buButton btn_DO24;

	public buButton btn_DO23;

	public buButton btn_DO47;

	public buButton btn_DO32;

	public buButton btn_DO46;

	public buButton btn_DO33;

	public buButton btn_DO45;

	public buButton btn_DO34;

	public buButton btn_DO44;

	public buButton btn_DO35;

	public buButton btn_DO43;

	public buButton btn_DO36;

	public buButton btn_DO42;

	public buButton btn_DO37;

	public buButton btn_DO41;

	public buButton btn_DO38;

	public buButton btn_DO40;

	public buButton btn_DO39;

	public buPanel pnl_output1;

	public buButton btn_DO15;

	public buButton btn_DO14;

	public buButton btn_DO13;

	public buButton btn_DO12;

	public buButton btn_DO11;

	public buButton btn_DO10;

	public buButton btn_DO9;

	public buButton btn_DO8;

	public buButton btn_DO7;

	public buButton btn_DO6;

	public buButton btn_DO5;

	public buButton btn_DO4;

	public buButton btn_DO3;

	public buButton btn_DO2;

	public buButton btn_DO1;

	public buButton btn_DO0;

	public buButton btn_DO63;

	public buButton btn_DO48;

	public buButton btn_DO62;

	public buButton btn_DO49;

	public buButton btn_DO61;

	public buButton btn_DO50;

	public buButton btn_DO60;

	public buButton btn_DO51;

	public buButton btn_DO59;

	public buButton btn_DO52;

	public buButton btn_DO58;

	public buButton btn_DO53;

	public buButton btn_DO57;

	public buButton btn_DO54;

	public buButton btn_DO56;

	public buButton btn_DO55;

	public ImageList IC48;

	public buPanel pnl_output2;

	public buPanel pnl_output3;

	public buPanel pnl_output4;

	public F_MarbleDigitalOutput()
	{
		Class186.smethod_496(this);
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
			buGround_0.Text = buLangTranslate.preDef.Digital + " " + buLangTranslate.preDef.Output;
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
