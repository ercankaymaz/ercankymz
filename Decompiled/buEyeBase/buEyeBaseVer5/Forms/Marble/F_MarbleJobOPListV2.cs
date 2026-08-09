using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleJobOPListV2 : Form
{
	private string string_0 = "F_MarbleCoordinatesV1";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	public buPanel pnl_base;

	public TreeView tree_jobs;

	public buButton btn_opUp;

	public buButton btn_opDown;

	internal ImageList imageList_0;

	public buButton btn_opdirchange;

	public buButton btn_opDisable;

	public buButton btn_opAddcam;

	public buButton btn_opDelete;

	public buButton btn_opEdit;

	public buButton btn_opvisible;

	public buButton btn_next;

	public buButton btn_pre;

	public buButton btn_pause;

	public buButton btn_stop;

	public buSpin spn_step;

	public buButton btn_start;

	public buButton btn_OPpauseafter;

	public buButton btn_menuclose;

	public buButton btn_opMenu;

	public Panel pnl_menu;

	public Panel pnl_coords;

	public buButton btn_coords;

	public buLabel lbl_x;

	public buLabel lbl_c;

	public buLabel lbl_y;

	public buLabel lbl_a;

	public buLabel lbl_z;

	internal buSeparator buSeparator_0;

	public buButton btn_OPtoolchange;

	public buCheckBox chk_showdimensiondraws;

	public F_MarbleJobOPListV2()
	{
		Class186.smethod_396(this);
	}

	public void UpdateVisuals()
	{
		string text = "UpdateVisuals";
		try
		{
			if (buEyeVars.parVisual == null)
			{
				return;
			}
			LoadLanguage();
			if (!PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce)
			{
				FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
				if (fileInfo.Exists)
				{
					Control.ControlCollection controlCollection = null;
					controlCollection = base.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					controlCollection = pnl_base.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					controlCollection = pnl_menu.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					controlCollection = pnl_coords.Controls;
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
			spn_step.Caption.Caption = buLangTranslate.preDef.Simulation;
			btn_coords.Text = buLangTranslate.preDef.Coordinate;
			btn_OPpauseafter.Text = buLangTranslate.preSentencesMarble.PauseAfterOperation;
			btn_OPtoolchange.Text = buLangTranslate.preDef.ToolChange;
			btn_menuclose.Text = buLangTranslate.preDef.Menu + " " + buLangTranslate.preDef.Close;
			chk_showdimensiondraws.Text = buLangTranslate.preDef.Show + " " + buLangTranslate.preDef.Dimension + " " + buLangTranslate.preDef.Draw;
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
		if (control.Name == btn_menuclose.Name)
		{
			pnl_menu.Visible = false;
		}
		if (control.Name == btn_coords.Name)
		{
			if (pnl_coords.Visible)
			{
				pnl_coords.Visible = false;
			}
			else
			{
				pnl_coords.Visible = true;
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
