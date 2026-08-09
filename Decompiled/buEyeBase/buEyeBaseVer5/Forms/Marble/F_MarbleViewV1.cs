using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleViewV1 : Form
{
	private string string_0 = "F_MarbleViewV1";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buButton btn_viewleft;

	public buButton btn_viewfront;

	public buButton btn_zoomfit;

	public buButton btn_viewiso;

	public buButton btn_viewtop;

	public buButton btn_zoomwindow;

	public buButton btn_viewclose;

	public buButton btn_viewrotate;

	public buButton btn_viewpan;

	public buButton btn_zoomout;

	public buButton btn_zoomin;

	public buButton btn_viewsettings;

	public buCheckBox chk_snap;

	public buCheckBox chk_grid;

	public buGround ground_base;

	public buButton btn_close;

	public buCheckBox chk_viewportrotate;

	public buButton btn_viewback;

	public buButton btn_viewright;

	public buButton btn_panright;

	public buButton btn_panleft;

	public buButton btn_panup;

	public buButton btn_pandown;

	public buButton btn_zoomratio;

	public buButton btn_viewcube;

	internal Panel panel_0;

	public buButton btn_viewtopfrontleft;

	public buButton btn_viewtopfrontright;

	public buButton btn_viewtopfrontmiddle;

	public buButton btn_viewtopbackleft;

	public buButton btn_viewtopleftmiddle;

	public buSpin spn_zoomratio;

	public buButton btn_camerapos;

	public buButton btn_zoomselected;

	public buSpin spn_zoomy1;

	public buSpin spn_zoomx1;

	public buButton btn_zoomwindowcoords;

	public buSpin spn_pandis;

	public buSpin spn_zoomy2;

	public buSpin spn_zoomx2;

	public Panel pnl_settings;

	public F_MarbleViewV1()
	{
		Class186.smethod_574(this);
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
		btn_viewcube.Visible = AppBool.DeveloperMode;
		btn_zoomratio.Visible = AppBool.DeveloperMode;
		spn_zoomratio.Visible = AppBool.DeveloperMode;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			ground_base.Text = buLangTranslate.preDef.View;
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
		if (control.Name == btn_viewcube.Name)
		{
			if (!panel_0.Visible)
			{
				panel_0.Visible = true;
			}
			else
			{
				panel_0.Visible = false;
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
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
