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

public class F_MarbleBottomPanelV1 : Form
{
	private string string_0 = "F_MarbleCoordinatesV2";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public buPanel pnl_base;

	public buButton btn_parkpos;

	public buButton btn_sawstart;

	public buButton btn_water;

	public buButton btn_laser;

	public buTab buTab_Main;

	public TabPage tabPage_horizontal;

	public TabPage tabPage_vertical;

	internal TabPage tabPage_0;

	public buButton btn_motorcurrent;

	public buMultiTextBox txt_gcode;

	public buButton btn_operation;

	public buButton btn_gcode;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	internal buLabel buLabel_2;

	internal buLabel buLabel_3;

	internal buLabel buLabel_4;

	public buButton btn_toolpage;

	public buButton btn_g54list;

	public buButton btn_parklist;

	public buButton btn_spindlestart;

	public buButton btn_partzero;

	public buProgressBar progress_X;

	public buProgressBar progress_A;

	public buProgressBar progress_C;

	public buProgressBar progress_Z;

	public buProgressBar progress_Y;

	public buButton btn_crousecontrol;

	public buButton btn_rtcp;

	public buLabel lbl_totalline;

	public buLabel lbl_actualline;

	internal buSeparator buSeparator_0;

	public buButton btn_gcodemaximize;

	public buButton btn_material;

	public buLabel lbl_millingheadlen;

	public buLabel lbl_millingheaddia;

	public buLabel lbl_millinglen;

	public buLabel lbl_millingdia;

	public buLabel lbl_sawtickness;

	public buButton btn_toolmillinheadset;

	public buButton btn_toolmillinset;

	public buButton btn_toolsawset;

	public buLabel lbl_sawdia;

	public buLabel lbl_material;

	internal buSeparator buSeparator_1;

	internal buSeparator buSeparator_2;

	public TreeView tree_operation;

	public buButton btn_OPDown;

	public buButton btn_OPUp;

	public buButton btn_GCodeDown;

	public buButton btn_GCodeUp;

	public Panel pnl_info;

	public buButton btn_mdi;

	public F_MarbleBottomPanelV1()
	{
		Class186.smethod_80(this);
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
			if (!PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce)
			{
				FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
				if (fileInfo.Exists)
				{
					Control.ControlCollection controlCollection = null;
					controlCollection = pnl_base.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					controlCollection = pnl_info.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					PropertiesForm.VisualUpdated = true;
				}
			}
			LoadLanguage();
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
		if (control.Name == btn_motorcurrent.Name)
		{
			buTab_Main.SelectedIndex = 0;
		}
		if (control.Name == btn_gcode.Name)
		{
			buTab_Main.SelectedIndex = 1;
		}
		if (control.Name == btn_operation.Name)
		{
			buTab_Main.SelectedIndex = 2;
		}
		MenuButtonColors(buTab_Main.SelectedIndex);
	}

	public void MenuButtonColors(int PageIndex)
	{
		if (buEyeVars.parVisual != null)
		{
			Control.ControlCollection controls = pnl_info.Controls;
			controls = hmiUICommands.SetVisualItem(controls);
			if (PageIndex == 0)
			{
				btn_motorcurrent.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_motorcurrent.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_motorcurrent.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_motorcurrent.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_motorcurrent.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_motorcurrent.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_motorcurrent.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_motorcurrent.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_motorcurrent.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			}
			if (PageIndex == 1)
			{
				btn_gcode.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_gcode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_gcode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_gcode.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_gcode.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_gcode.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_gcode.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_gcode.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_gcode.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			}
			if (PageIndex == 2)
			{
				btn_operation.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_operation.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_operation.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_operation.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_operation.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_operation.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_operation.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_operation.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
				btn_operation.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
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
