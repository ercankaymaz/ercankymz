using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using buCadCamResVer5;
using buCadCamResVer5.Marble;
using buClass;
using buControls;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.buEntities;
using buHandler;
using buMarble;
using buMotion;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace MarbleCNC.Machines;

public class clsMachine3_10AxisDoubleHead
{
	private Point3D pntActive = new Point3D();

	private Timer timPlcHandlerRelease = new Timer();

	private bool Inited = false;

	private string sClass = "clsMachine1_5Axis";

	private clsAppMarbleVars cMarbleVars = null;

	public void AppMarbleClassInit()
	{
		clsAppMarbleVars.cmdMarble.InitAxesString();
		if (cMarbleVars == null)
		{
			cMarbleVars = new clsAppMarbleVars();
			cMarbleVars.Init();
		}
	}

	public void SystemInit()
	{
		string text = "SystemInit";
		try
		{
			AppMarbleClassInit();
			string text2 = "";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisXChar + "1";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisYChar + "1";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisZChar + "1";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisCChar + "1";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisAChar + "1";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisXChar + "2";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisYChar + "2";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisZChar + "2";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisCChar + "2";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			text2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisAChar + "2";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.Strings.strRuntimeVar = "AxisRun" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.Strings.strSettingsVar = "AxisSet" + text2 + ".";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.Strings.strRunExe = "AxisRun" + text2 + ".exeAX.";
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.Strings.strRunBool = "AxisRun" + text2 + ".boolAX.";
			if (cMarbleVars == null)
			{
				cMarbleVars = new clsAppMarbleVars();
				cMarbleVars.Init();
			}
			clsItem.FrmMach1.lbl_warning.Height = 85;
			clsAppMarbleVars.cmdMarble.CommandHMI += CommandHMI;
			buMarbleForms.frmHorizontal = new F_MarbleHorVerCutV2();
			buMarbleForms.frmVertical = new F_MarbleHorVerCutV2();
			buMarbleForms.frmHorVer = new F_MarbleHorVerCutV3();
			buMarbleForms.frmHorVerDialog = new F_MarbleHorVerCutV3();
			buMarbleForms.frmHorOrVerDialog = new F_MarbleHorVerCutV2();
			buMarbleForms.frmSingle = new F_MarbleSingleCut();
			buMarbleForms.frmHorizontal.LoadLanguage();
			buMarbleForms.frmVertical.LoadLanguage();
			buMarbleForms.frmHorVer.LoadLanguage();
			buMarbleForms.frmHorVerDialog.LoadLanguage();
			buMarbleForms.frmHorOrVerDialog.LoadLanguage();
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "SystemInit");
			clsInit.appMarble.Init();
			clsAppMarbleVars.cmdMarble.Init();
			clsAppMarbleVars.cmdMarble.InitSystem();
			AddControls();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "AddControls");
			UpdateVisualThings();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "UpdateVisualThings");
			clsMarble.secondKinematic = new KinematicBase5();
			clsMarble.secondKinematic.RotateCenterOffsetOfB.Y = 300.0;
			clsMarble.secondKinematic.Type = KinemeticType.CartezianXYZ_WristBC_5Axis;
			clsInit.appMarble.SimUpdated += clsAppMarbleVars.cmdMarble.SimUpdated;
			clsItem.FrmMach1.KeyPreview = true;
			ccVars.selectionProcess = true;
			clsInit.cMwCalc.Settings.ShowMwDialogBox = false;
			clsVar.varSelection.SmartSelection = false;
			clsVar.varSelection.DontSelectGroupItem = true;
			clsVar.varDisplay.ShowSelectedEntitiesPoint = false;
			clsVar.varProgram.EventCommandRepitation = false;
			clsVar.varScreen.ShowOrigineIcon = false;
			clsVar.varScreen.ShowCubeIcon = false;
			clsVar.varScreen.ShowToolbar = false;
			clsVar.varView.DisplayMode = DisplayModeType.Rendered;
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "Move Controls");
			clsItem.FrmMach1.pnl_hordata.Controls.Add(buMarbleForms.frmHorizontal.pnl_data);
			clsItem.FrmMach1.pnl_verdata.Controls.Add(buMarbleForms.frmVertical.pnl_data);
			clsItem.FrmMach1.pnl_horverdata.Controls.Add(buMarbleForms.frmHorVer.pnl_data);
			clsItem.FrmMach1.pnl_drawviewport.Width = 1450;
			clsItem.FrmMach1.pnl_drawingjob.Visible = false;
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "Move Controls");
			clsItem.FrmMach1.btn_menu.Click += showMenuPage;
			clsItem.FrmMenuAdminSettings.btn_watch.Click += showWatch;
			clsItem.FrmMenu.btn_report.Click += showReportPage;
			clsItem.FrmMenu.btn_simulationpanel.Click += showSimulationPanel;
			clsItem.FrmMenu.btn_test.Click += showTestPage;
			clsItem.FrmMenu.btn_settings.Click += showSettingsPage;
			clsItem.FrmMenu.btn_selectmaterial.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_closepc.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_language.Click += showLanguageMenu;
			clsItem.FrmMenu.btn_password.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_tools.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_g54offset.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_settingsaxes.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_millingsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_marblecamsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_servoconnection.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach1.btn_contoursettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_G54Offset.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_AbsoluteHomeSet.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_calibration.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_toolsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_vagoonsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_camerasettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_debug.Click += showDebug;
			clsItem.FrmMach1.btn_main.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_manuel.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_horizontal.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_vertical.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_horver.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_drawing.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_semiAuto.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_drawmode.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_eventmode.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_functionsmode.Click += clickCommandMainMenuButton;
			clsItem.FrmMach1.btn_misc.Click += clickCommandMainMenuButton;
			buMarbleForms.frmHorizontal.chk_horleftbottom.Name = buMarbleForms.frmHorizontal.chk_horleftbottom.Name + "Hor";
			buMarbleForms.frmHorizontal.chk_horlefttop.Name = buMarbleForms.frmHorizontal.chk_horlefttop.Name + "Hor";
			buMarbleForms.frmHorizontal.chk_cutstart.Name = buMarbleForms.frmHorizontal.chk_cutstart.Name + "Hor";
			buMarbleForms.frmHorizontal.chk_cutend.Name = buMarbleForms.frmHorizontal.chk_cutend.Name + "Hor";
			for (int i = 0; i <= buMarbleForms.frmHorizontal.pnl_data.Controls.Count - 1; i++)
			{
				if (buMarbleForms.frmHorizontal.pnl_data.Controls[i] is buSpin)
				{
					buSpin buSpin2 = buMarbleForms.frmHorizontal.pnl_data.Controls[i] as buSpin;
					if (buSpin2.Aux.AuxInfo == "HorVer")
					{
						buSpin2.Aux.AuxInfo = "Hor";
						buSpin2.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_HorValueChanged;
						buSpin2.KeyDown += clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown;
					}
					buSpin2.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin2.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin2.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorizontal.pnl_data.Controls[i] is buButton)
				{
					buButton buButton2 = buMarbleForms.frmHorizontal.pnl_data.Controls[i] as buButton;
					buButton2.Aux.AuxInfo = "Hor";
					buButton2.Name += "Hor";
					buButton2.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
				}
			}
			buMarbleForms.frmHorizontal.chk_horleftbottom.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorizontal.chk_horlefttop.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorizontal.chk_cutstart.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorizontal.chk_cutend.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmVertical.chk_horleftbottom.Name = buMarbleForms.frmVertical.chk_horleftbottom.Name + "Ver";
			buMarbleForms.frmVertical.chk_horlefttop.Name = buMarbleForms.frmVertical.chk_horlefttop.Name + "Ver";
			buMarbleForms.frmVertical.chk_cutstart.Name = buMarbleForms.frmVertical.chk_cutstart.Name + "Ver";
			buMarbleForms.frmVertical.chk_cutend.Name = buMarbleForms.frmVertical.chk_cutend.Name + "Ver";
			for (int j = 0; j <= buMarbleForms.frmVertical.pnl_data.Controls.Count - 1; j++)
			{
				if (buMarbleForms.frmVertical.pnl_data.Controls[j] is buSpin)
				{
					buSpin buSpin3 = buMarbleForms.frmVertical.pnl_data.Controls[j] as buSpin;
					if (buSpin3.Aux.AuxInfo == "HorVer")
					{
						buSpin3.Aux.AuxInfo = "Ver";
						buSpin3.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_VerValueChanged;
						buSpin3.KeyDown += clsAppMarbleVars.cmdMarble.spn_Veritem_KeyDown;
					}
					buSpin3.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin3.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin3.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmVertical.pnl_data.Controls[j] is buButton)
				{
					buButton buButton3 = buMarbleForms.frmVertical.pnl_data.Controls[j] as buButton;
					buButton3.Aux.AuxInfo = "Ver";
					buButton3.Name += "Ver";
					buButton3.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
				}
			}
			buMarbleForms.frmVertical.chk_horleftbottom.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmVertical.chk_horlefttop.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmVertical.chk_cutstart.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmVertical.chk_cutend.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			for (int k = 0; k <= buMarbleForms.frmHorVer.tabPage_Hor.Controls.Count - 1; k++)
			{
				if (buMarbleForms.frmHorVer.tabPage_Hor.Controls[k] is buSpin)
				{
					buSpin buSpin4 = buMarbleForms.frmHorVer.tabPage_Hor.Controls[k] as buSpin;
					if (buSpin4.Aux.AuxInfo == "Hor")
					{
						buSpin4.Aux.AuxInfo = "Hor";
						buSpin4.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_HorVerHorValueChanged;
						buSpin4.KeyDown += clsAppMarbleVars.cmdMarble.spn_HorVerHoritem_KeyDown;
					}
					buSpin4.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin4.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin4.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorVer.tabPage_Hor.Controls[k] is buButton)
				{
					buButton buButton4 = buMarbleForms.frmHorVer.tabPage_Hor.Controls[k] as buButton;
					buButton4.Aux.AuxInfo = "Hor";
					buButton4.Name += "Hor";
					buButton4.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
				}
			}
			for (int l = 0; l <= buMarbleForms.frmHorVer.tabPage_Ver.Controls.Count - 1; l++)
			{
				if (buMarbleForms.frmHorVer.tabPage_Ver.Controls[l] is buSpin)
				{
					buSpin buSpin5 = buMarbleForms.frmHorVer.tabPage_Ver.Controls[l] as buSpin;
					if (buSpin5.Aux.AuxInfo == "Ver")
					{
						buSpin5.Aux.AuxInfo = "Ver";
						buSpin5.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_HorVerVerValueChanged;
						buSpin5.KeyDown += clsAppMarbleVars.cmdMarble.spn_HorVerVeritem_KeyDown;
					}
					buSpin5.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin5.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin5.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorVer.tabPage_Ver.Controls[l] is buButton)
				{
					buButton buButton5 = buMarbleForms.frmHorVer.tabPage_Ver.Controls[l] as buButton;
					buButton5.Aux.AuxInfo = "Ver";
					buButton5.Name += "Ver";
					buButton5.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
				}
			}
			buMarbleForms.frmHorVer.chk_horverleftbottom.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVer.chk_horverlefttop.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVer.btn_addtolist.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVer.btn_horveropen.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVer.btn_horversave.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVer.btn_itemhorverendpos.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVer.btn_itemhorverok.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVer.btn_itemhorverstartpos.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVer.buTab1.SelectedIndexChanged += clsAppMarbleVars.cmdMarble.Tab_HorVerSelectedIndexChanged;
			for (int m = 0; m <= buMarbleForms.frmHorOrVerDialog.pnl_data.Controls.Count - 1; m++)
			{
				if (buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[m] is buSpin)
				{
					buSpin buSpin6 = buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[m] as buSpin;
					if (buSpin6.Aux.AuxInfo == "HorVer")
					{
						buSpin6.Aux.AuxInfo = "Hor";
						buSpin6.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_HorOrVerDialogValueChanged;
						buSpin6.KeyDown += clsAppMarbleVars.cmdMarble.spn_HorOrVeritem_KeyDown;
					}
					buSpin6.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin6.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin6.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[m] is buButton)
				{
					buButton buButton6 = buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[m] as buButton;
					buButton6.Aux.AuxInfo = "Hor";
					buButton6.Name += "Hor";
					buButton6.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandHorOrVerDialog_Click;
				}
			}
			buMarbleForms.frmHorOrVerDialog.chk_horleftbottom.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandHorOrVerDialog_Click;
			buMarbleForms.frmHorOrVerDialog.chk_horlefttop.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandHorOrVerDialog_Click;
			buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Name = buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Name + "Dialog";
			buMarbleForms.frmHorVerDialog.chk_horverlefttop.Name = buMarbleForms.frmHorVerDialog.chk_horverlefttop.Name + "Dialog";
			buMarbleForms.frmHorVerDialog.btn_itemhorverok.Name = buMarbleForms.frmHorVerDialog.btn_itemhorverok.Name + "Dialog";
			for (int n = 0; n <= buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls.Count - 1; n++)
			{
				if (buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[n] is buSpin)
				{
					buSpin buSpin7 = buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[n] as buSpin;
					if (buSpin7.Aux.AuxInfo == "Hor")
					{
						buSpin7.Aux.AuxInfo = "Hor";
						buSpin7.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_HorVerHorDialogValueChanged;
						buSpin7.KeyDown += clsAppMarbleVars.cmdMarble.spn_HorVerHorDialogitem_KeyDown;
					}
					buSpin7.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin7.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin7.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[n] is buButton)
				{
					buButton buButton7 = buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[n] as buButton;
					buButton7.Aux.AuxInfo = "Hor";
					buButton7.Name += "Hor";
					buButton7.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
				}
			}
			for (int num = 0; num <= buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls.Count - 1; num++)
			{
				if (buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[num] is buSpin)
				{
					buSpin buSpin8 = buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[num] as buSpin;
					if (buSpin8.Aux.AuxInfo == "Ver")
					{
						buSpin8.Aux.AuxInfo = "Ver";
						buSpin8.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_HorVerVerDialogValueChanged;
						buSpin8.KeyDown += clsAppMarbleVars.cmdMarble.spn_HorVerVerDialogitem_KeyDown;
					}
					buSpin8.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin8.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin8.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[num] is buButton)
				{
					buButton buButton8 = buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[num] as buButton;
					buButton8.Aux.AuxInfo = "Ver";
					buButton8.Name += "Ver";
					buButton8.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
				}
			}
			buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVerDialog.chk_horverlefttop.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVerDialog.buTab1.SelectedIndexChanged += clsAppMarbleVars.cmdMarble.Tab_HorVerDialogSelectedIndexChanged;
			for (int num2 = 0; num2 <= clsItem.FrmMach1.pnl_OpSettings.Controls.Count - 1; num2++)
			{
				if (clsItem.FrmMach1.pnl_OpSettings.Controls[num2] is buSpin)
				{
					buSpin buSpin9 = clsItem.FrmMach1.pnl_OpSettings.Controls[num2] as buSpin;
					buSpin9.Aux.AuxInfo = "OPSettings";
					buSpin9.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin9.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin9.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
			}
			clsItem.FrmMach1.btn_shape.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_library.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_contour.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_engraving.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_profiling.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_profilecurve.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_oplist.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_text.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_OPMenu.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_saveOP.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_openOP.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_move.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_rotate.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_mirror.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_scale.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_alignments.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_copy.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_copymulti.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_offset.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_undo.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_eventdelete.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_eventdeleteall.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmRotate.btn_eventRotateminus.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmRotate.btn_eventrotateplus.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmovedown.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmoveleft.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmoveright.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmoveup.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_setangle2.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_slatadd.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_collopseadd.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_extend.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_break.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_vacuum.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_cadoutside.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_cadinside.Click += clickCommandsDrawing;
			clsItem.FrmMach1.btn_gcodes.Click += clsAppMarbleVars.cmdMarble.clickCommandsView;
			clsItem.FrmMach1.btn_view.Click += clsAppMarbleVars.cmdMarble.clickCommandsView;
			clsItem.FrmMach1.btn_joblist.Click += clsAppMarbleVars.cmdMarble.clickCommandsView;
			clsItem.FrmMach1.btn_commands.Click += clsAppMarbleVars.cmdMarble.clickCommandsView;
			clsItem.FrmMach1.btn_cancel.Click += clickCommands;
			clsItem.FrmMach1.btn_reset.Click += clickCommands;
			clsItem.FrmMach1.btn_start.Click += clickCommands;
			clsItem.FrmMach1.btn_stop.Click += clickCommands;
			clsItem.FrmMach1.btn_pause.Click += clickCommands;
			clsItem.FrmMach1.btn_water.Click += clickCommands;
			clsItem.FrmMach1.btn_laser.Click += clickCommands;
			clsItem.FrmMach1.btn_camera.Click += clickCommands;
			clsItem.FrmMach1.btn_homing.Click += clickCommands;
			clsItem.FrmMach1.btn_park.Click += clickCommands;
			clsItem.FrmMach1.btn_vagonpark.Click += clickCommands;
			clsItem.FrmMach1.btn_sawpark.Click += clickCommands;
			clsItem.FrmMach1.btn_spindlepark.Click += clickCommands;
			clsItem.FrmMach1.btn_spindleheadpark.Click += clickCommands;
			clsItem.FrmMach1.btn_photopos.Click += clickCommands;
			clsItem.FrmMach1.btn_codecreate.Click += clickCommands;
			clsItem.FrmMach1.btn_partzero.Click += clickCommands;
			clsItem.FrmMach1.btn_A0.Click += clickCommands;
			clsItem.FrmMach1.btn_A45.Click += clickCommands;
			clsItem.FrmMach1.btn_A90.Click += clickCommands;
			clsItem.FrmMach1.btn_c180.Click += clickCommands;
			clsItem.FrmMach1.btn_c270.Click += clickCommands;
			clsItem.FrmMach1.btn_c90.Click += clickCommands;
			clsItem.FrmMach1.btn_c0.Click += clickCommands;
			clsItem.FrmMach1.btn_gozero.Click += clickCommands;
			clsItem.FrmMach1.btn_crousecontrol.Click += clickCommands;
			clsItem.FrmMach1.btn_cameraclose.Click += clickCommands;
			clsItem.FrmMach1.btn_cameraopen.Click += clickCommands;
			clsItem.FrmMach1.btn_a0_2.Click += clickCommands;
			clsItem.FrmMach1.btn_a45_2.Click += clickCommands;
			clsItem.FrmMach1.btn_a46_2.Click += clickCommands;
			clsItem.FrmMach1.btn_c180_2.Click += clickCommands;
			clsItem.FrmMach1.btn_c_90_2.Click += clickCommands;
			clsItem.FrmMach1.btn_c90_2.Click += clickCommands;
			clsItem.FrmMach1.btn_c0_2.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.track_sawspeed.ValueChanged += trackValueChanged;
			clsAppMarbleItems.frmSpeedsV1.track_Spindlespeed.ValueChanged += trackValueChanged;
			clsAppMarbleItems.frmSpeedsV1.track_operationspeed.ValueChanged += trackValueChanged;
			clsAppMarbleItems.frmSpeedsV1.track_quickspeed.ValueChanged += trackValueChanged;
			clsItem.FrmMach1.btn_pensopenclose.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach1.btn_spindlepistondown.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach1.btn_spindlepistonup.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach1.btn_toolmagazineopen.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach1.btn_toolmagazineClose.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmKinematic.btn_openkinematic.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmKinematic.btn_savekinemtic.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach1.btn_tool.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_kinematic.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach1.chk_absolute.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach1.chk_incremental.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach1.chk_addsawthickness.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach1.spn_go.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.btn_xplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_yplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_zplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_aplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_cplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_xminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_yminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_zminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_aminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_cminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach1.btn_xplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_yplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_zplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_aplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_cplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_xminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_yminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_zminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_aminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_cminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach1.btn_xplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_yplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_zplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_aplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_cplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_xminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_yminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_zminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_aminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_cminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach1.btn_stopmanuel.Click += clickCommands;
			clsItem.FrmMach1.btn_preset.Click += clickCommandsMenuAndSettings;
			clsAppMarbleItems.frmSpeedsV1.btn_saw.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_spindle.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_sawminus.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_sawplus.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_spindleminus.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_spindleplus.Click += clickCommands;
			SemiAutoParameterChange(FromControlToValues: false);
			clsItem.FrmMach1.btn_xplus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach1.btn_yplus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach1.btn_zplus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach1.btn_xminus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach1.btn_yminus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach1.btn_zminus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach1.btn_stopsemiauto.Click += clickCommands;
			clsItem.FrmMach1.btn_semiautoenable.Click += clickCommands;
			clsItem.FrmMach1.spn_semiautocuttingspeed.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.spn_semiautohorizontallen.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.spn_semiautomaterialheight.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.spn_semiautomaterialthickness.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.spn_semiautomaterialwidth.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.spn_semiautooperationz.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.spn_semiautoverticallen.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.spn_semiautoplungespeed.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.spn_semiautosafedis.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.spn_semiautocuttingspeed.Leave += spinLeave;
			clsItem.FrmMach1.spn_semiautohorizontallen.Leave += spinLeave;
			clsItem.FrmMach1.spn_semiautomaterialheight.Leave += spinLeave;
			clsItem.FrmMach1.spn_semiautomaterialthickness.Leave += spinLeave;
			clsItem.FrmMach1.spn_semiautomaterialwidth.Leave += spinLeave;
			clsItem.FrmMach1.spn_semiautooperationz.Leave += spinLeave;
			clsItem.FrmMach1.spn_semiautoverticallen.Leave += spinLeave;
			clsItem.FrmMach1.spn_semiautoplungespeed.Leave += spinLeave;
			clsItem.FrmMach1.spn_semiautosafedis.Leave += spinLeave;
			clsItem.FrmMach1.spn_semiautocuttingspeed.ValueClicked += spinClick;
			clsItem.FrmMach1.spn_semiautohorizontallen.ValueClicked += spinClick;
			clsItem.FrmMach1.spn_semiautomaterialheight.ValueClicked += spinClick;
			clsItem.FrmMach1.spn_semiautomaterialthickness.ValueClicked += spinClick;
			clsItem.FrmMach1.spn_semiautomaterialwidth.ValueClicked += spinClick;
			clsItem.FrmMach1.spn_semiautooperationz.ValueClicked += spinClick;
			clsItem.FrmMach1.spn_semiautoverticallen.ValueClicked += spinClick;
			clsItem.FrmMach1.spn_semiautoplungespeed.ValueClicked += spinClick;
			clsItem.FrmMach1.spn_semiautosafedis.ValueClicked += spinClick;
			clsItem.FrmMach1.spn_semiautocuttingspeed.KeyDown += spinKeyDown;
			clsItem.FrmMach1.spn_semiautohorizontallen.KeyDown += spinKeyDown;
			clsItem.FrmMach1.spn_semiautomaterialheight.KeyDown += spinKeyDown;
			clsItem.FrmMach1.spn_semiautomaterialthickness.KeyDown += spinKeyDown;
			clsItem.FrmMach1.spn_semiautomaterialwidth.KeyDown += spinKeyDown;
			clsItem.FrmMach1.spn_semiautooperationz.KeyDown += spinKeyDown;
			clsItem.FrmMach1.spn_semiautoverticallen.KeyDown += spinKeyDown;
			clsItem.FrmMach1.spn_semiautoplungespeed.KeyDown += spinKeyDown;
			clsItem.FrmMach1.spn_semiautosafedis.KeyDown += spinKeyDown;
			clsItem.FrmCameraLive.btn_camerastart.Click += clickCommands;
			clsItem.FrmCameraLive.btn_camerastop.Click += clickCommands;
			clsItem.FrmCameraLive.btn_cameratakeshot.Click += clickCommands;
			clsItem.FrmMach1.KeyDown += FormKeyDown;
			clsAppMarbleItems.frmMove.spn_eventmovevalue.ValueChanged += spinValueChanged;
			clsAppMarbleItems.frmRotate.spn_eventrotatevalue.ValueChanged += spinValueChanged;
			clsItem.FrmMach1.buTab_Main.SelectedIndexChanged += buTabSelectedIndexChanged;
			clsInit.appCommand.MainFormUpdate += MainFormUpdate;
			clsInit.appCommand.MainFormStatusUpdate += MainFormStatusUpdate;
			clsInit.appCommand.MainFormXYZUpdate += MainFormXYZUpdate;
			clsInit.appCommand.EntityAddToPage += PageEntityAdd;
			clsInit.appCommand.RunCommand += RunCommands;
			clsInit.appCommand.GeneralCommand += RunGeneralCommand;
			buMarbleCalc.varMarbleRunSettings.fileWood = AppPath.Base + "\\Images\\Wood\\BaseMaterial.png";
			buMarbleCalc.varMarbleRunSettings.fileMarble = AppPath.Base + "\\Images\\Marble\\MarbleBlackAndWhile.png";
			clsInit.appMarble.ViewportDialogsInit();
			clsInit.appMarble.ViewportCNCInit();
			buEyeItems.viewportCNC.MouseMove += mouseMoveViewport;
			buEyeItems.viewportCNC.MouseDown += mouseDownViewport;
			buEyeItems.viewportCNC.MouseUp += mouseUpViewport;
			clsItem.FrmMach1.pnl_mainviewport.Controls.Add(buEyeItems.viewportCNC);
			clsInit.appMarble.ViewportCadCamInit();
			clsItem.FrmMach1.pnl_horviewport.Controls.Add(buEyeItems.viewportCadCam);
			buEyeItems.viewportCadCam.ActiveViewport.Rotate.Enabled = buMarbleCalc.varMarbleRunSettings.RotateCameraCadCam;
			buVector5.baseModel = buEyeItems.viewportCadCam;
			clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelRotate;
			clsAppMarbleItems.frmMove.spn_eventmovevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelMove;
			clsItem.FrmMach1.spn_camcuttingspped.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity;
			clsItem.FrmMach1.spn_cammarblethickness.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
			clsItem.FrmMach1.spn_camoperationZ.Value = buMarbleCalc.varOperation.settingMarbleCam.TargetZ;
			clsItem.FrmMach1.spn_camplungespeed.Value = buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity;
			clsItem.FrmMach1.spn_camcuttingstep.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance;
			clsItem.FrmMach1.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
			clsItem.FrmMach1.spn_camsafedis.Value = buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance;
			clsItem.FrmMach1.chk_incremental.Check = clsAppMarbleVars.varInterface.IncrementalMode;
			clsItem.FrmMach1.chk_absolute.Check = clsAppMarbleVars.varInterface.AbsoluteMode;
			clsItem.FrmMach1.chk_addsawthickness.Check = clsAppMarbleVars.varInterface.AddSawThicknessToMove;
			clsItem.FrmMach1.spn_go.Value = clsAppMarbleVars.varInterface.JogMoveValue;
			if (clsAppMarbleItems.frmViewsV1 != null)
			{
				clsAppMarbleItems.frmViewsV1.chk_grid.Check = buMarbleCalc.varMarbleRunSettings.ShowGridCNC;
				clsAppMarbleItems.frmViewsV1.chk_snap.Check = buMarbleCalc.varMarbleRunSettings.SnapEnable;
				clsAppMarbleItems.frmViewsV1.chk_viewportrotate.Check = buMarbleCalc.varMarbleRunSettings.RotateCameraCNC;
				clsAppMarbleItems.frmViewsV1.chk_grid.Check = buMarbleCalc.varMarbleRunSettings.ShowGridCNC;
				clsAppMarbleItems.frmViewsV1.chk_snap.Check = buMarbleCalc.varMarbleRunSettings.SnapEnable;
			}
			buMarbleForms.frmHorizontal.spn_itemlength.Value = buMarbleCalc.varMarbleRunSettings.HorizontalLenght;
			buMarbleForms.frmVertical.spn_itemlength.Value = buMarbleCalc.varMarbleRunSettings.VerticalLenght;
			buMarbleForms.frmHorVer.spn_itemhorlength.Value = buMarbleCalc.varMarbleRunSettings.HorizontalLenght;
			buMarbleForms.frmHorVer.spn_itemverlength.Value = buMarbleCalc.varMarbleRunSettings.VerticalLenght;
			buMarbleForms.frmHorVerDialog.spn_itemhorlength.Value = buMarbleCalc.varMarbleRunSettings.HorizontalLenght;
			buMarbleForms.frmHorVerDialog.spn_itemverlength.Value = buMarbleCalc.varMarbleRunSettings.VerticalLenght;
			buMarbleForms.frmHorVer.chk_horverlefttop.Check = true;
			buMarbleForms.frmHorVer.chk_horverleftbottom.Check = false;
			if (buMarbleForms.frmHorVer.buTab1.SelectedIndex == 0)
			{
				if (buMarbleCalc.varMarbleRunSettings.HorVerHorCornerType == MarbleCorners.LeftTop)
				{
					buMarbleForms.frmHorVer.chk_horverlefttop.Check = true;
					buMarbleForms.frmHorVer.chk_horverleftbottom.Check = false;
				}
				else
				{
					buMarbleForms.frmHorVer.chk_horverlefttop.Check = false;
					buMarbleForms.frmHorVer.chk_horverleftbottom.Check = true;
				}
			}
			else if (buMarbleCalc.varMarbleRunSettings.HorVerVerCornerType == MarbleCorners.LeftTop)
			{
				buMarbleForms.frmHorVer.chk_horverlefttop.Check = true;
				buMarbleForms.frmHorVer.chk_horverleftbottom.Check = false;
			}
			else
			{
				buMarbleForms.frmHorVer.chk_horverlefttop.Check = false;
				buMarbleForms.frmHorVer.chk_horverleftbottom.Check = true;
			}
			buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = true;
			buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = false;
			if (buMarbleForms.frmHorVerDialog.buTab1.SelectedIndex == 0)
			{
				if (buMarbleCalc.varMarbleRunSettings.HorVerHorCornerType == MarbleCorners.LeftTop)
				{
					buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = true;
					buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = false;
				}
				else
				{
					buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = false;
					buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = true;
				}
			}
			else if (buMarbleCalc.varMarbleRunSettings.HorVerVerCornerType == MarbleCorners.LeftTop)
			{
				buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = true;
				buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = false;
			}
			else
			{
				buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = false;
				buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = true;
			}
			buMarbleForms.frmHorizontal.chk_cutstart.Check = buMarbleCalc.varMarbleRunSettings.SliceHorStartCut;
			buMarbleForms.frmHorizontal.chk_cutend.Check = buMarbleCalc.varMarbleRunSettings.SliceHorEndCut;
			buMarbleForms.frmHorizontal.chk_horlefttop.Check = true;
			buMarbleForms.frmHorizontal.chk_horleftbottom.Check = false;
			if (buMarbleCalc.varMarbleRunSettings.HorCornerType == MarbleCorners.LeftTop)
			{
				buMarbleForms.frmHorizontal.chk_horlefttop.Check = true;
				buMarbleForms.frmHorizontal.chk_horleftbottom.Check = false;
			}
			else if (buMarbleCalc.varMarbleRunSettings.HorCornerType == MarbleCorners.LeftBottom)
			{
				buMarbleForms.frmHorizontal.chk_horlefttop.Check = false;
				buMarbleForms.frmHorizontal.chk_horleftbottom.Check = true;
			}
			buMarbleForms.frmVertical.chk_cutstart.Check = buMarbleCalc.varMarbleRunSettings.SliceVerStartCut;
			buMarbleForms.frmVertical.chk_cutend.Check = buMarbleCalc.varMarbleRunSettings.SliceVerEndCut;
			buMarbleForms.frmVertical.chk_horlefttop.Check = true;
			buMarbleForms.frmVertical.chk_horleftbottom.Check = false;
			if (buMarbleCalc.varMarbleRunSettings.VerCornerType == MarbleCorners.LeftTop)
			{
				buMarbleForms.frmVertical.chk_horlefttop.Check = true;
				buMarbleForms.frmVertical.chk_horleftbottom.Check = false;
			}
			else if (buMarbleCalc.varMarbleRunSettings.VerCornerType == MarbleCorners.LeftBottom)
			{
				buMarbleForms.frmVertical.chk_horlefttop.Check = false;
				buMarbleForms.frmVertical.chk_horleftbottom.Check = true;
			}
			clsAppMarbleItems.frmSpeedsV1.btn_saw = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_saw, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsAppMarbleItems.frmSpeedsV1.btn_spindle = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_spindle, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsAppMarbleItems.frmSpeedsV1.track_operationspeed.Value = (int)clsAppMarbleVars.varInterface.OperationSpeed;
			clsAppMarbleItems.frmSpeedsV1.track_quickspeed.Value = (int)clsAppMarbleVars.varInterface.QuickSpeed;
			clsAppMarbleItems.frmSpeedsV1.track_Spindlespeed.Value = (int)clsAppMarbleVars.varInterface.SpindleSpeedOverride;
			clsAppMarbleItems.frmSpeedsV1.track_sawspeed.Value = (int)clsAppMarbleVars.varInterface.SawSpeedOverride;
			clsAppMarbleItems.frmSpeedsV1.spn_spindlespeed.Value = clsAppMarbleVars.varInterface.SpindleSpeed;
			clsAppMarbleItems.frmSpeedsV1.spn_sawspeed.Value = clsAppMarbleVars.varInterface.SawSpeed;
			if ((CodesysMachine.CommType == CommunicationType.PlcHandler) | (CodesysMachine.CommType == CommunicationType.OPCUA))
			{
				clsAppMarbleVars.cmdMarble.CommunicationVariableInit();
			}
			buMarbleCalc.activeToolSaw.Geometry.GeometryType = ToolType.Saw;
			buMarbleCalc.activeToolSaw.Geometry.LowerRadius = 0.0;
			buMarbleCalc.activeToolSaw.Geometry.UpperRadius = 0.0;
			buMarbleCalc.activeToolSaw.Geometry.DrawHolder = false;
			buMarbleCalc.activeToolSaw.Geometry.DrawArbor = false;
			buMarbleCalc.activeToolSaw.Geometry.PlaneDirection = new Vec3D(0.0, 1.0, 0.0);
			buMarbleCalc.activeToolSaw.Limits.RotationA = true;
			buMarbleCalc.activeToolSaw.Limits.RotationC = true;
			MenuButtonColors(0);
			MenuDrawButtonColors(0);
			FileInfo fileInfo = null;
			ccVars.Pages[0].Form.UpdateForm();
			clsItem.timGeneral.Interval = 300;
			clsItem.timGeneral.Tick += GeneralTick;
			clsItem.timGeneral.Enabled = true;
			if (AppBool.Connected)
			{
				ReadBOOLValues();
				ReadDINTValues();
				ReadLRealValues();
				clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SpindleSpeed, "AppRun.VelSpindle");
				clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SawSpeed, "AppRun.VelSaw");
				clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SawSpeedOverride, "AppRun.SawOverride");
				clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.SpindleSpeedOverride, "sysSet.Spindle.SpindleOverride");
				clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.OperationSpeed, "sysSet.Feed.FeedOverrideG1");
				clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.QuickSpeed, "sysSet.Feed.FeedOverrideG0");
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, "AppRun.SpindleSpeedUpdate");
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, "AppRun.SawSpeedUpdate");
				clsItem.FrmMach1.btn_homing = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
				clsItem.FrmMach1.btn_homing.ForceSelected = false;
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
				clsAppMarbleVars.cMachine.bWriteAppParameter = true;
				clsAppMarbleVars.cMachine.bWriteToolParameter = true;
				clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
				KinematicBase copyKinematic = new KinematicBase();
				KinematicBase5.Copy(clsMarble.activeKinematic, ref copyKinematic);
				clsAppMarbleVars.cMachine.Commands.WriteKinematicData(CodesysMachine.RootPersistentString + "Kinematic.", copyKinematic);
			}
			clsInit.appCommand.cmdViewZoomFit();
			clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
			clsAppMarbleItems.frmMain = clsItem.FrmMach1;
			buCadCamResVer5.clsItem.FrmMain = clsItem.FrmMach1;
			AppBool.Inited = true;
			Task task = Task.Run(delegate
			{
				DoInitWork();
			});
			Inited = true;
			buLogMarbleVer5.addToLogList(sClass, text, "Finished");
			buLogMarbleVer5.saveLogList();
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, ex.Message, "Exception", "", 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void DoInitWork()
	{
		clsInit.appMarble.InitCadCamSimulation();
		Inited = true;
	}

	public void AddControls()
	{
		string text = "AddControls";
		try
		{
			buLogMarbleVer5.addToLogList(sClass, text, "Started");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmCoordsV1");
			clsAppMarbleItems.frmCoordsV1.pnl_base.Left = 4;
			clsAppMarbleItems.frmCoordsV1.pnl_base.Top = clsItem.FrmMach1.pic_imagecompany.Top + clsItem.FrmMach1.pic_imagecompany.Height + 2;
			clsAppMarbleItems.frmCoordsV1.pnl_base.Display.BackColor = Color.Transparent;
			clsAppMarbleItems.frmCoordsV1.pnl_base.Display.Border.Visible = false;
			clsItem.FrmMach1.pnl_left.Controls.Add(clsAppMarbleItems.frmCoordsV1.pnl_base);
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmCoordinates");
			buSeparator buSeparator2 = new buSeparator();
			buSeparator2.Display.BackColor = Color.Black;
			buSeparator2.Display.GradientType = GradientMode.Solid;
			buSeparator2.Size = new Size(clsItem.FrmMach1.pnl_left.Width + 2, 2);
			buSeparator2.Location = new System.Drawing.Point(-1, clsAppMarbleItems.frmCoordsV1.pnl_base.Top + clsAppMarbleItems.frmCoordsV1.pnl_base.Height + 2);
			clsItem.FrmMach1.pnl_left.Controls.Add(buSeparator2);
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmSpeedsV1");
			clsAppMarbleItems.frmSpeedsV1.pnl_base.Left = 4;
			clsAppMarbleItems.frmSpeedsV1.pnl_base.Top = buSeparator2.Top + buSeparator2.Height + 2;
			clsAppMarbleItems.frmSpeedsV1.pnl_base.Display.BackColor = Color.Transparent;
			clsAppMarbleItems.frmSpeedsV1.pnl_base.Display.Border.Visible = false;
			clsItem.FrmMach1.pnl_left.Controls.Add(clsAppMarbleItems.frmSpeedsV1.pnl_base);
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmSpeedsV1");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmJobOPListV2");
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Left = 0;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Top = 38;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.BackColor = Color.Transparent;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.Border.Visible = false;
			clsItem.FrmMach1.pnl_drawingjob.Controls.Add(clsAppMarbleItems.frmJobOPListV2.pnl_base);
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmJobOPListV2");
			buLogMarbleVer5.addToLogList(sClass, text, "Finished");
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, "", 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void GeneralTick(object sender, EventArgs e)
	{
		clsAppMarbleVars.cMachine.miscVar.cntGeneralTick++;
		clsAppMarbleVars.cMachine.miscVar.cntWarning++;
		clsAppMarbleVars.cMachine.miscVar.tickCameraImage++;
		clsItem.FrmMach1.lbl_datetime.Text = " " + DateTime.Now.Date.ToShortDateString() + " - " + DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + ":" + DateTime.Now.Second.ToString("D2") + "   ";
		if (!Inited)
		{
			return;
		}
		if (!AppBool.IsFirstRun)
		{
			clsItem.FrmMach1.btn_water = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach1.btn_homing = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach1.btn_laser = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach1.btn_start = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach1.btn_pause = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach1.btn_semiautoenable = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach1.btn_crousecontrol = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			AppBool.IsFirstRun = true;
		}
		clsAppMarbleVars.cmdMarble.GeneralTick();
		if (clsAppMarbleVars.cMachine.miscVar.WarningAvailable & (clsAppMarbleVars.cMachine.miscVar.cntWarning >= 10))
		{
			clsAppMarbleVars.cMachine.miscVar.WarningAvailable = false;
			clsAppMarbleVars.cMachine.miscVar.cntWarning = 0;
			clsItem.FrmMach1.lbl_status.Display.BackColor = Color.LightSteelBlue;
			if ((clsAppMarbleVars.cMachine.runSystem.Status >= 0) & (clsAppMarbleVars.cMachine.runSystem.Status < 100) & (clsAppMarbleVars.cMachine.runSystem.Status <= AppLanguage.SystemStatus.Count - 1) & !AppBool.FileLoading)
			{
				clsItem.FrmMach1.lbl_status.Text = AppLanguage.SystemStatus[clsAppMarbleVars.cMachine.runSystem.Status];
			}
			if ((clsAppMarbleVars.cMachine.runSystem.Status >= 100) & (clsAppMarbleVars.cMachine.runSystem.Status < 200) & (clsAppMarbleVars.cMachine.runSystem.Status - 100 <= AppLanguage.Status.Count - 1) & !AppBool.FileLoading)
			{
				clsItem.FrmMach1.lbl_status.Text = AppLanguage.Status[clsAppMarbleVars.cMachine.runSystem.Status - 100];
			}
			clsItem.FrmMach1.lbl_warning.Visible = false;
		}
		if (AppBool.Offline)
		{
			clsItem.FrmMach1.lbl_warning.Visible = false;
			clsItem.FrmMach1.lbl_warning.Text = buLangTranslate.preMotionWarning.SystemOffline;
			return;
		}
		clsItem.timGeneral.Enabled = false;
		if (clsAppMarbleVars.cMachine.bParameterWriting)
		{
			clsItem.FrmMach1.lbl_warning.Text = buLangTranslate.preMotionWarning.ParameterWriting;
			clsItem.FrmMach1.lbl_warning.Visible = clsAppMarbleVars.cMachine.bParameterWriting;
		}
		if (clsAppMarbleVars.cMachine.preVar.ParWriting & !clsAppMarbleVars.cMachine.bParameterWriting)
		{
			clsItem.FrmMach1.lbl_warning.Text = "";
			clsItem.FrmMach1.lbl_warning.Visible = false;
		}
		clsAppMarbleVars.cMachine.preVar.ParWriting = clsAppMarbleVars.cMachine.bParameterWriting;
		if (!clsItem.FrmMach1.btn_homing.ForceSelected & clsAppMarbleVars.cMachine.runSystem.HomingDone)
		{
			clsItem.FrmMach1.btn_homing.ForceSelected = true;
			clsItem.FrmMach1.btn_homing = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach1.btn_homing.ForceSelected = !clsAppMarbleVars.cMachine.runSystem.HomingDone)
		{
			clsItem.FrmMach1.btn_homing.ForceSelected = false;
			clsItem.FrmMach1.btn_homing = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach1.btn_water.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Water)
		{
			clsItem.FrmMach1.btn_water.ForceSelected = true;
			clsItem.FrmMach1.btn_water = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach1.btn_water.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Water)
		{
			clsItem.FrmMach1.btn_water.ForceSelected = false;
			clsItem.FrmMach1.btn_water = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach1.btn_laser.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Laser)
		{
			clsItem.FrmMach1.btn_laser.ForceSelected = true;
			clsItem.FrmMach1.btn_laser = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach1.btn_laser.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Laser)
		{
			clsItem.FrmMach1.btn_laser.ForceSelected = false;
			clsItem.FrmMach1.btn_laser = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach1.btn_start.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Run)
		{
			clsItem.FrmMach1.btn_start.ForceSelected = true;
			clsItem.FrmMach1.btn_start = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach1.btn_start.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Run)
		{
			clsItem.FrmMach1.btn_start.ForceSelected = false;
			clsItem.FrmMach1.btn_start = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach1.btn_pause.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Pause)
		{
			clsItem.FrmMach1.btn_pause.ForceSelected = true;
			clsItem.FrmMach1.btn_pause = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach1.btn_pause.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Pause)
		{
			clsItem.FrmMach1.btn_pause.ForceSelected = false;
			clsItem.FrmMach1.btn_pause = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach1.btn_semiautoenable.ForceSelected & clsAppMarbleVars.cMachine.runSystem.SemiAuto)
		{
			clsItem.FrmMach1.btn_semiautoenable.ForceSelected = true;
			clsItem.FrmMach1.btn_semiautoenable = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach1.btn_semiautoenable.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.SemiAuto)
		{
			clsItem.FrmMach1.btn_semiautoenable.ForceSelected = false;
			clsItem.FrmMach1.btn_semiautoenable = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach1.btn_crousecontrol.ForceSelected & clsAppMarbleVars.cMachine.runSystem.CruiseControl)
		{
			clsItem.FrmMach1.btn_crousecontrol.ForceSelected = true;
			clsItem.FrmMach1.btn_crousecontrol = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach1.btn_crousecontrol.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.CruiseControl)
		{
			clsItem.FrmMach1.btn_crousecontrol.ForceSelected = false;
			clsItem.FrmMach1.btn_crousecontrol = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		clsItem.FrmMach1.chk_connected.Check = AppBool.Connected;
		clsItem.FrmMach1.chk_inited.Check = clsAppMarbleVars.cMachine.runSystem.InitDone;
		clsItem.FrmMach1.chk_home.Check = clsAppMarbleVars.cMachine.runSystem.HomingDone;
		clsItem.FrmMach1.chk_run.Check = clsAppMarbleVars.cMachine.runSystem.Run;
		clsItem.FrmMach1.chk_rtcp.Check = clsAppMarbleVars.cMachine.runSystem.RtcpActivated;
		if ((clsAppMarbleVars.cMachine.runSystem.AlarmCount == 0) & !clsAppMarbleVars.cMachine.miscVar.WarningAvailable)
		{
			clsItem.FrmMach1.lbl_status.Display.BackColor = Color.LightSteelBlue;
			if ((clsAppMarbleVars.cMachine.runSystem.Status >= 0) & (clsAppMarbleVars.cMachine.runSystem.Status < 100) & (clsAppMarbleVars.cMachine.runSystem.Status <= AppLanguage.SystemStatus.Count - 1) & !AppBool.FileLoading)
			{
				clsItem.FrmMach1.lbl_status.Text = AppLanguage.SystemStatus[clsAppMarbleVars.cMachine.runSystem.Status];
			}
			if ((clsAppMarbleVars.cMachine.runSystem.Status >= 100) & (clsAppMarbleVars.cMachine.runSystem.Status < 200) & (clsAppMarbleVars.cMachine.runSystem.Status - 100 <= AppLanguage.Status.Count - 1) & !AppBool.FileLoading)
			{
				clsItem.FrmMach1.lbl_status.Text = AppLanguage.Status[clsAppMarbleVars.cMachine.runSystem.Status - 100];
			}
		}
		clsItem.timGeneral.Enabled = true;
	}

	private void CommandHMI(object Data1, object Data2, object Data3, object Data4, object Data5)
	{
		MarbleHMICommands marbleHMICommands = MarbleHMICommands.None;
		if (Data1 is MarbleHMICommands)
		{
			marbleHMICommands = (MarbleHMICommands)Data1;
		}
		if (marbleHMICommands == MarbleHMICommands.ShowWarning)
		{
			ShowWarning((string)Data2, Color.Gold);
		}
		if (marbleHMICommands == MarbleHMICommands.HideWarning)
		{
			clsItem.FrmMach1.lbl_warning.Text = "";
			clsItem.FrmMach1.lbl_warning.Visible = false;
		}
		if (marbleHMICommands == MarbleHMICommands.StatusUpdate)
		{
			clsItem.FrmMach1.lbl_status.Text = (string)Data2;
			clsItem.FrmMach1.lbl_status.Display.BackColor = (Color)Data3;
		}
		if (marbleHMICommands == MarbleHMICommands.SaveCNCParameter)
		{
			SaveParameter();
		}
		if (marbleHMICommands == MarbleHMICommands.UpdateMarbleCamParametersFromControls)
		{
			MainControlsToParameter(FromControlToValues: true);
		}
	}

	public void clickCommands(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (control.Name == clsItem.FrmMach1.btn_cancel.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Cancel);
			}
			if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_spindle.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleStart);
				return;
			}
			if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_spindleminus.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleMinus);
				return;
			}
			if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_spindleplus.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePlus);
				return;
			}
			if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_saw.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawStart);
				return;
			}
			if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_sawminus.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawMinus);
				return;
			}
			if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_sawplus.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawPlus);
				return;
			}
			if (control.Name == clsItem.FrmMach1.btn_gozero.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.GoPartZero);
			}
			if (control.Name == clsItem.FrmMach1.btn_crousecontrol.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CrouseControl);
			}
			if (control.Name == clsItem.FrmMach1.btn_partzero.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.PartZero);
			}
			if (control.Name == clsItem.FrmMach1.btn_codecreate.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CodeCreate);
			}
			if ((control.Name == clsItem.FrmMach1.btn_c0.Name) | (control.Name == clsItem.FrmMach1.btn_c0_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C0);
			}
			if ((control.Name == clsItem.FrmMach1.btn_c90.Name) | (control.Name == clsItem.FrmMach1.btn_c90_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90);
			}
			if ((control.Name == clsItem.FrmMach1.btn_c180.Name) | (control.Name == clsItem.FrmMach1.btn_c180_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C180);
			}
			if (control.Name == clsItem.FrmMach1.btn_c270.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C270);
			}
			if (control.Name == clsItem.FrmMach1.btn_c_90_2.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90Minus);
			}
			if ((control.Name == clsItem.FrmMach1.btn_A0.Name) | (control.Name == clsItem.FrmMach1.btn_a0_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A0);
			}
			if ((control.Name == clsItem.FrmMach1.btn_A45.Name) | (control.Name == clsItem.FrmMach1.btn_a45_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A45);
			}
			if (control.Name == clsItem.FrmMach1.btn_A90.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A90);
			}
			if (control.Name == clsItem.FrmMach1.btn_a46_2.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A46);
			}
			if (control.Name == clsItem.FrmMach1.btn_spindlepistondown.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonDown);
			}
			if (control.Name == clsItem.FrmMach1.btn_spindlepistonup.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonUp);
			}
			if (control.Name == clsItem.FrmMach1.btn_semiautoenable.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SemiAutoSwitch);
				if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
				{
					clsAppMarbleVars.cMachine.bWriteAppParameter = true;
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_homing.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Homing);
			}
			if (control.Name == clsItem.FrmMach1.btn_water.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Water);
			}
			if (control.Name == clsItem.FrmMach1.btn_laser.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Laser);
			}
			if (control.Name == clsItem.FrmMach1.btn_park.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Park);
			}
			if (control.Name == clsItem.FrmMach1.btn_vagonpark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.WagonPark);
			}
			if (control.Name == clsItem.FrmMach1.btn_spindlepark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePark);
			}
			if (control.Name == clsItem.FrmMach1.btn_sawpark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawPark);
			}
			if (control.Name == clsItem.FrmMach1.btn_spindleheadpark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleHeadPark);
			}
			if (control.Name == clsItem.FrmMach1.btn_photopos.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraPark);
			}
			if (control.Name == clsItem.FrmMach1.btn_reset.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Reset);
			}
			if (control.Name == clsItem.FrmMach1.btn_start.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Start);
			}
			if ((control.Name == clsItem.FrmMach1.btn_stop.Name) | (control.Name == clsItem.FrmMach1.btn_stopmanuel.Name) | (control.Name == clsItem.FrmMach1.btn_stopsemiauto.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
			}
			if (control.Name == clsItem.FrmMach1.btn_cameraopen.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverOpen);
			}
			if (control.Name == clsItem.FrmMach1.btn_cameraclose.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverClose);
			}
			if (control.Name == clsItem.FrmMach1.btn_camera.Name && (!AppBool.CameraCapturing & !AppBool.CameraMakeItReady & buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraReady);
			}
		}
		catch (Exception)
		{
		}
	}

	public void clickCommandMainMenuButton(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			MainControlsToParameter(FromControlToValues: true);
			clsAppMarbleVars.varRuntime.isHorizontalTab = false;
			clsAppMarbleVars.varRuntime.isVerticalTab = false;
			clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
			if (control.Name == clsItem.FrmMach1.btn_main.Name)
			{
				clsAppMarbleVars.varRuntime.isMainTab = true;
				clsItem.FrmMach1.buTab_Main.SelectedIndex = 0;
				MenuButtonColors(0);
			}
			if (control.Name == clsItem.FrmMach1.btn_manuel.Name)
			{
				clsAppMarbleVars.varRuntime.isMainTab = true;
				clsItem.FrmMach1.buTab_Main.SelectedIndex = 1;
				MenuButtonColors(1);
			}
			if (control.Name == clsItem.FrmMach1.btn_horizontal.Name)
			{
				clsAppMarbleVars.varRuntime.isHorizontalTab = true;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach1.buTab_Main.SelectedIndex = 2;
				MenuButtonColors(2);
			}
			if (control.Name == clsItem.FrmMach1.btn_vertical.Name)
			{
				clsAppMarbleVars.varRuntime.isVerticalTab = true;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach1.buTab_Main.SelectedIndex = 3;
				MenuButtonColors(3);
			}
			if (control.Name == clsItem.FrmMach1.btn_horver.Name)
			{
				clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = true;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach1.buTab_Main.SelectedIndex = 4;
				MenuButtonColors(4);
			}
			if (control.Name == clsItem.FrmMach1.btn_drawing.Name)
			{
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach1.buTab_Main.SelectedIndex = 5;
				MenuButtonColors(5);
			}
			if (control.Name == clsItem.FrmMach1.btn_semiAuto.Name)
			{
				clsAppMarbleVars.varRuntime.isMainTab = true;
				clsItem.FrmMach1.buTab_Main.SelectedIndex = 6;
				MenuButtonColors(6);
			}
			if (control.Name == clsItem.FrmMach1.btn_drawmode.Name)
			{
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Operation;
				clsItem.FrmMach1.buTab_drawing.SelectedIndex = 0;
				MenuDrawButtonColors(0);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach1.btn_eventmode.Name)
			{
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Event;
				clsItem.FrmMach1.buTab_drawing.SelectedIndex = 1;
				MenuDrawButtonColors(1);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: true, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach1.btn_functionsmode.Name)
			{
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Function;
				clsItem.FrmMach1.buTab_drawing.SelectedIndex = 2;
				MenuDrawButtonColors(2);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: true, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach1.btn_misc.Name)
			{
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.CadDraw;
				clsItem.FrmMach1.buTab_drawing.SelectedIndex = 3;
				MenuDrawButtonColors(3);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
		}
		catch (Exception)
		{
		}
	}

	public void clickCommandsDrawing(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (control.Name == clsItem.FrmMach1.btn_OPMenu.Name)
			{
				clsMarble.frmOPCommands.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				clsMarble.frmOPCommands.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsMarble.frmOPCommands.Init();
				clsMarble.frmOPCommands.ShowDialog();
				if (clsMarble.frmOPCommands.CommandType == MarbleItemType.HorizontalCut)
				{
					clsInit.appMarble.cmdHorVerCut(isHorizontal: true);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.VerticalCut)
				{
					clsInit.appMarble.cmdHorVerCut(isHorizontal: false);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.SingleCut)
				{
					clsInit.appMarble.cmdSingleCut();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Contour)
				{
					clickCommandsDrawing(clsItem.FrmMach1.btn_contour, null);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Shape)
				{
					clickCommandsDrawing(clsItem.FrmMach1.btn_shape, null);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Slices)
				{
					clsInit.appMarble.cmdSlicing();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Profiling)
				{
					clsInit.appMarble.cmdProfileMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.ProfileCurve)
				{
					clsInit.appMarble.cmdProfileCurveMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Text)
				{
					clsInit.appMarble.cmdTextMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Library)
				{
					clsInit.appMarble.cmdLibraryMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Engraving)
				{
					clsInit.appMarble.cmdEngravingMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.GCode)
				{
					clsInit.appMarble.cmdExternalGCode();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Columns)
				{
					clsInit.appMarble.cmdColumnsMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Sweep)
				{
					clsInit.appMarble.cmdSweepMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.LatheHorizontal)
				{
					clsInit.appMarble.cmdLatheMenu(isHorizontal: true);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.LatheVertical)
				{
					clsInit.appMarble.cmdLatheMenu(isHorizontal: false);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Drill)
				{
					clsInit.appMarble.cmdDrillMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Editor)
				{
					clsInit.appMarble.cmdContourMenu(EditorMode: true);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.MaterialClean)
				{
					clsInit.appMarble.cmdCleanMaterail();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.AirDry)
				{
					clsInit.appMarble.cmdAirDryMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.SawHorizontalMillingRough)
				{
					clsInit.appMarble.cmdSawHorizontalMillingRoughMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.SawVerticalMillingRough)
				{
					clsInit.appMarble.cmdSawVerticalMillingRoughMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.EasyDraw)
				{
					clsInit.appMarble.cmdEasyDrawing();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.PocketByDrill)
				{
					clsInit.appMarble.cmdPocketByDrillMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Milling5AxisRotary)
				{
					clsInit.appMarble.cmdMilling5AxisRotaryMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Milling5AxisFlat)
				{
					clsInit.appMarble.cmdMilling5AxisFlatMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.HorizontalVerticalCut)
				{
					clsInit.appMarble.cmdHorVerBothCut();
				}
				return;
			}
			if (control.Name == clsItem.FrmMach1.btn_shape.Name)
			{
				clsInit.appMarble.cmdShapeMenu();
			}
			if (control.Name == clsItem.FrmMach1.btn_contour.Name)
			{
				clsInit.appMarble.cmdContourMenu();
			}
			if (control.Name == clsItem.FrmMach1.btn_profiling.Name)
			{
				clsInit.appMarble.cmdProfileMenu();
			}
			if (control.Name == clsItem.FrmMach1.btn_profilecurve.Name)
			{
				clsInit.appMarble.cmdProfileCurveMenu();
			}
			if (control.Name == clsItem.FrmMach1.btn_engraving.Name)
			{
				clsInit.appMarble.cmdEngravingMenu();
			}
			if (control.Name == clsItem.FrmMach1.btn_library.Name)
			{
				clsInit.appMarble.cmdLibraryMenu();
			}
			if (control.Name == clsItem.FrmMach1.btn_text.Name)
			{
				clsInit.appMarble.cmdTextMenu();
			}
			if (control.Name == clsItem.FrmMach1.btn_oplist.Name)
			{
				if (!clsItem.FrmMach1.pnl_drawingjob.Visible)
				{
					clsItem.FrmMach1.pnl_drawviewport.Width = 1120;
					clsItem.FrmMach1.pnl_drawingjob.Visible = true;
				}
				else
				{
					clsItem.FrmMach1.pnl_drawingjob.Visible = false;
					clsItem.FrmMach1.pnl_drawviewport.Width = 1450;
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_cadoutside.Name)
			{
				List<buEntity> refEntities = new List<buEntity>();
				DialogResult dialogResult = clsInit.appMarble.cmdCadDrawMenu(ref refEntities);
				if (dialogResult == DialogResult.OK)
				{
					clsInit.appMarble.cmdCadDrawOutside(refEntities);
				}
				refEntities.Clear();
			}
			if (control.Name == clsItem.FrmMach1.btn_cadinside.Name)
			{
				List<buEntity> refEntities2 = new List<buEntity>();
				DialogResult dialogResult2 = clsInit.appMarble.cmdCadDrawMenu(ref refEntities2);
				if (dialogResult2 == DialogResult.OK)
				{
					clsInit.appMarble.cmdCadDrawInside(refEntities2);
				}
				refEntities2.Clear();
			}
			if (control.Name == clsItem.FrmMach1.btn_move.Name && clsAppMarbleItems.frmMove != null)
			{
				if (!clsAppMarbleItems.frmMove.Visible)
				{
					clsAppMarbleItems.frmMove.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					clsAppMarbleItems.frmMove.PropertiesForm.FormPosition = FormStartPosition.Manual;
					clsAppMarbleItems.frmMove.PropertiesForm.TopMost = true;
					clsAppMarbleItems.frmMove.TopMost = true;
					clsAppMarbleItems.frmMove.Left = 450;
					clsAppMarbleItems.frmMove.Top = 55;
					clsAppMarbleItems.frmMove.Init();
					clsAppMarbleItems.frmMove.Visible = true;
				}
				else
				{
					clsAppMarbleItems.frmMove.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_rotate.Name)
			{
				if (!clsAppMarbleItems.frmRotate.Visible)
				{
					clsAppMarbleItems.frmRotate.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					clsAppMarbleItems.frmRotate.PropertiesForm.FormPosition = FormStartPosition.Manual;
					clsAppMarbleItems.frmRotate.PropertiesForm.TopMost = true;
					clsAppMarbleItems.frmRotate.TopMost = true;
					clsAppMarbleItems.frmRotate.Left = 450;
					clsAppMarbleItems.frmRotate.Top = 55;
					clsAppMarbleItems.frmRotate.Init();
					clsAppMarbleItems.frmRotate.Visible = true;
				}
				else
				{
					clsAppMarbleItems.frmRotate.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_mirror.Name)
			{
				if (clsAppMarbleItems.frmMirror == null)
				{
					clsAppMarbleItems.frmMirror = new F_MarbleEventMirror();
				}
				clsAppMarbleItems.frmMirror.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmMirror.PropertiesForm.FormPosition = FormStartPosition.Manual;
				clsAppMarbleItems.frmMirror.TopMost = false;
				clsAppMarbleItems.frmMirror.Left = 450;
				clsAppMarbleItems.frmMirror.Top = 55;
				clsAppMarbleItems.frmMirror.Init();
				clsAppMarbleItems.frmMirror.ShowDialog();
				if (clsAppMarbleItems.frmMirror.PropertiesForm.Result == DialogResult.OK)
				{
					clsInit.appMarble.doMirrorSelectedItem();
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_scale.Name)
			{
				if (clsAppMarbleItems.frmScale == null)
				{
					clsAppMarbleItems.frmScale = new F_MarbleEventScale();
				}
				clsAppMarbleItems.frmScale.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmScale.PropertiesForm.FormPosition = FormStartPosition.Manual;
				clsAppMarbleItems.frmScale.TopMost = false;
				clsAppMarbleItems.frmScale.Left = 450;
				clsAppMarbleItems.frmScale.Top = 55;
				List<Entity> list = new List<Entity>();
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
				{
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
					if (entity.Selected && ((entity.EntityData != null) & (entity.EntityData is CustomData)))
					{
						list.Add(entity);
					}
				}
				if (list.Count > 0)
				{
					Point3D MinPoint = new Point3D();
					Point3D MidPoint = new Point3D();
					Point3D MaxPoint = new Point3D();
					clsInit.cVector5.BoxSizeCalculate(list, ref MinPoint, ref MidPoint, ref MaxPoint);
					buMarbleCalc.varMarbleRunSettings.ScaleWidth = Math.Round(MaxPoint.X - MinPoint.X, 3);
					buMarbleCalc.varMarbleRunSettings.ScaleHeight = Math.Round(MaxPoint.Y - MinPoint.Y, 3);
					clsAppMarbleItems.frmScale.Init();
					clsAppMarbleItems.frmScale.ShowDialog();
					if (clsAppMarbleItems.frmScale.PropertiesForm.Result == DialogResult.OK)
					{
						clsInit.appMarble.doScaleSelectedItem();
					}
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_copy.Name)
			{
				if (clsAppMarbleItems.frmCopy == null)
				{
					clsAppMarbleItems.frmCopy = new F_MarbleEventCopy();
				}
				clsAppMarbleItems.frmCopy.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmCopy.PropertiesForm.FormPosition = FormStartPosition.Manual;
				clsAppMarbleItems.frmCopy.Left = 450;
				clsAppMarbleItems.frmCopy.Top = 55;
				clsAppMarbleItems.frmCopy.Init();
				clsAppMarbleItems.frmCopy.ShowDialog();
				if (clsAppMarbleItems.frmCopy.PropertiesForm.Result == DialogResult.OK)
				{
					clsInit.appMarble.doCopySelectedItem(buMarbleCalc.varMarbleRunSettings.CopyXDistance, buMarbleCalc.varMarbleRunSettings.CopyYDistance);
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_copymulti.Name)
			{
				if (clsAppMarbleItems.frmCopyMulti == null)
				{
					clsAppMarbleItems.frmCopyMulti = new F_MarbleEventCopyMulti();
				}
				clsAppMarbleItems.frmCopyMulti.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmCopyMulti.PropertiesForm.FormPosition = FormStartPosition.Manual;
				clsAppMarbleItems.frmCopyMulti.Left = 450;
				clsAppMarbleItems.frmCopyMulti.Top = 55;
				clsAppMarbleItems.frmCopyMulti.Init();
				clsAppMarbleItems.frmCopyMulti.ShowDialog();
				if (clsAppMarbleItems.frmCopyMulti.PropertiesForm.Result == DialogResult.OK)
				{
					clsInit.appMarble.doCopySelectedItem(buMarbleCalc.varMarbleRunSettings.CopyXDistance, buMarbleCalc.varMarbleRunSettings.CopyYDistance, buMarbleCalc.varMarbleRunSettings.CopyXCount, buMarbleCalc.varMarbleRunSettings.CopyYCount);
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_alignments.Name && buMarbleForms.frmEventAling != null)
			{
				if (!buMarbleForms.frmEventAling.Visible)
				{
					buMarbleForms.frmEventAling.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					buMarbleForms.frmEventAling.PropertiesForm.FormPosition = FormStartPosition.Manual;
					buMarbleForms.frmEventAling.PropertiesForm.TopMost = true;
					buMarbleForms.frmEventAling.TopMost = true;
					buMarbleForms.frmEventAling.Left = 450;
					buMarbleForms.frmEventAling.Top = 55;
					buMarbleForms.frmEventAling.Init();
					buMarbleForms.frmEventAling.Visible = true;
				}
				else
				{
					buMarbleForms.frmEventAling.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_slatadd.Name)
			{
				clsInit.appMarble.doSlatAdd(null);
			}
			if (control.Name == clsItem.FrmMach1.btn_collopseadd.Name)
			{
				clsInit.appMarble.doCollopseAdd(null);
			}
			if (control.Name == clsItem.FrmMach1.btn_extend.Name)
			{
				clsInit.appMarble.doExtend();
			}
			if (control.Name == clsItem.FrmMach1.btn_break.Name)
			{
				clsInit.appMarble.doBreak();
			}
			if (control.Name == clsItem.FrmMach1.btn_offset.Name)
			{
				clsInit.appMarble.doOffset();
			}
			if (control.Name == clsAppMarbleItems.frmRotate.btn_eventrotateplus.Name)
			{
				clsInit.appMarble.doRotateSelectedItem(0.0 - clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value);
				buMarbleCalc.varMarbleRunSettings.ManuelRotate = clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmRotate.btn_eventRotateminus.Name)
			{
				clsInit.appMarble.doRotateSelectedItem(clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value);
				buMarbleCalc.varMarbleRunSettings.ManuelRotate = clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmMove.btn_eventmoveleft.Name)
			{
				clsInit.appMarble.doMoveSelectedItem(0.0 - clsAppMarbleItems.frmMove.spn_eventmovevalue.Value, 0.0);
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmMove.btn_eventmoveright.Name)
			{
				clsInit.appMarble.doMoveSelectedItem(clsAppMarbleItems.frmMove.spn_eventmovevalue.Value, 0.0);
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmMove.btn_eventmoveup.Name)
			{
				clsInit.appMarble.doMoveSelectedItem(0.0, clsAppMarbleItems.frmMove.spn_eventmovevalue.Value);
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmMove.btn_eventmovedown.Name)
			{
				clsInit.appMarble.doMoveSelectedItem(0.0, 0.0 - clsAppMarbleItems.frmMove.spn_eventmovevalue.Value);
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
			}
			if (control.Name == clsItem.FrmMach1.btn_eventdelete.Name && !clsInit.appMarble.MoveCreatedEntity)
			{
				clsInit.appMarble.doDeleteItems(All: false, -1);
			}
			if (control.Name == clsItem.FrmMach1.btn_eventdeleteall.Name && !clsInit.appMarble.MoveCreatedEntity)
			{
				clsInit.appMarble.doDeleteItems(All: true, -1);
			}
			if (control.Name == clsItem.FrmMach1.btn_vacuum.Name)
			{
				clsInit.appMarble.cmdVacuum();
			}
			if (control.Name == clsItem.FrmMach1.btn_saveOP.Name)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathJob;
				saveFileDialog.Filter = "buMarble Job File (*.bumarble)|*.bumarble";
				saveFileDialog.FilterIndex = 1;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					buMarbleCalc.varMarbleRunSettings.pathJob = buFile.GetPath(saveFileDialog.FileName);
					clsInit.appMarble.SaveMarbleJob(saveFileDialog.FileName, clsInit.appMarble.activeJob);
					AppBool.SaveByTick = true;
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_openOP.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathJob;
				openFileDialog.Filter = "buMarble Job File (*.bumarble)|*.bumarble";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					buMarbleCalc.varMarbleRunSettings.pathJob = buFile.GetPath(openFileDialog.FileName);
					clsInit.appMarble.OpenMarbleJob(openFileDialog.FileName, ref clsInit.appMarble.activeJob);
					AppBool.SaveByTick = true;
				}
			}
			if (control.Name == clsItem.FrmMach1.btn_undo.Name)
			{
				clsInit.appMarble.UndoGetback();
			}
		}
		catch (Exception)
		{
		}
	}

	public void clickCommandsMenuAndSettings(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (control.Name == clsItem.FrmMenu.btn_closepc.Name && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWanttoClosePC) == DialogResult.Yes)
			{
				clsAppMarbleVars.cmdMarble.cmdClosePC();
			}
			if (control.Name == clsItem.FrmMenu.btn_selectmaterial.Name)
			{
				clsInit.cMarble.ShowMaterialPage();
				clsInit.appMarble.SaveMarbleFile();
			}
			if (control.Name == clsItem.FrmMach1.btn_contoursettings.Name)
			{
				MainControlsToParameter(FromControlToValues: true);
				clsInit.appMarble.cmdContourUserSettingsPage();
				MainControlsToParameter(FromControlToValues: false);
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_marblecamsettings.Name)
			{
				clsInit.appMarble.cmdCamSettingsPage();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_millingsettings.Name)
			{
				clsInit.appMarble.cmdSettingsMilling2D(MarbleCamType.MillingContour2D);
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_settingsaxes.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMachineSettings();
				SaveParameter();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_servoconnection.Name)
			{
				clsAppMarbleVars.cmdMarble.cmdCMZSBDBridge();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_toolsettings.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMachineSettingsV1(0);
			}
			if (control.Name == clsItem.FrmMenu.btn_tools.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowToolsList(buMarbleCalc.varMarbleSettings.ToolListMode, MarbleToolType.Saw);
			}
			if (control.Name == clsItem.FrmMenu.btn_g54offset.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowG54List();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_vagoonsettings.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowWagonSettings();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_camerasettings.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCameraSettings();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_calibration.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCalibration();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_AbsoluteHomeSet.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowAbsoluteSet();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_G54Offset.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowG54Set();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_kinematic.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowKinematic();
			}
			if (control.Name == clsItem.FrmMenu.btn_password.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowPassword();
			}
			if (control.Name == clsItem.FrmMach1.btn_tool.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowTools(-1);
				clsItem.FrmMach1.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
			}
			if (control.Name == clsItem.FrmMach1.btn_preset.Name)
			{
				if (clsAppMarbleVars.cmdMarble.ShowPreset(1050, clsItem.FrmMach1.chk_addsawthickness.Top) == DialogResult.OK)
				{
					clsItem.FrmMach1.spn_go.Value = buMarbleForms.frmPreset.ReturnVal;
				}
			}
			else if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
			{
				clsItem.FrmMenuSettings.Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	private void mouseMoveViewport(object sender, MouseEventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buEyeItems.viewportCNC.Name)
		{
			buEyeItems.viewportCNC.ScreenToPlane(e.Location, ccVars.planeActive, out pntActive);
			if (pntActive != null)
			{
				clsItem.FrmMach1.lbl_viewportcoords.Text = "X: " + pntActive.X.ToString("f2") + " , Y: " + pntActive.Y.ToString("f2") + " , Z: " + pntActive.Z.ToString("f2");
			}
		}
	}

	private void mouseDownViewport(object sender, MouseEventArgs e)
	{
		Control control = sender as Control;
		if (!(control.Name == buEyeItems.viewportCNC.Name))
		{
		}
	}

	private void mouseUpViewport(object sender, MouseEventArgs e)
	{
		Control control = sender as Control;
		if (e.Button == MouseButtons.Left && !(control.Name == buEyeItems.viewportCNC.Name))
		{
		}
	}

	private void checkCheckedChanged(object sender, bool CheckStatus)
	{
		Control control = sender as Control;
		if (AppBool.Inited)
		{
			if (control.Name == clsItem.FrmMach1.chk_incremental.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.IncrementalMode = clsItem.FrmMach1.chk_incremental.Check;
				clsItem.FrmMach1.chk_absolute.Check = false;
				clsAppMarbleVars.varInterface.AbsoluteMode = false;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach1.chk_absolute.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.AbsoluteMode = clsItem.FrmMach1.chk_absolute.Check;
				clsItem.FrmMach1.chk_incremental.Check = false;
				clsAppMarbleVars.varInterface.IncrementalMode = false;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach1.chk_addsawthickness.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.AddSawThicknessToMove = clsItem.FrmMach1.chk_addsawthickness.Check;
				AppBool.Inited = true;
			}
		}
	}

	private void trackValueChanged(object sender, double Val)
	{
		Control control = sender as Control;
		if (AppBool.Connected)
		{
			if (control.Name == clsAppMarbleItems.frmSpeedsV1.track_Spindlespeed.Name && !clsAppMarbleVars.varApp.SpindlePersentageFromPLC)
			{
				clsAppMarbleItems.frmSpeedsV1.track_Spindlespeed.Value = Convert.ToInt32(Val);
				clsAppMarbleVars.varInterface.SpindleSpeedOverride = Val;
				clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SpindleSpeedOverride, "AppRun.SpindleOverride");
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, "AppRun.SpindleSpeedUpdate");
			}
			if (control.Name == clsAppMarbleItems.frmSpeedsV1.track_sawspeed.Name && !clsAppMarbleVars.varApp.SpindlePersentageFromPLC)
			{
				clsAppMarbleItems.frmSpeedsV1.track_sawspeed.Value = Convert.ToInt32(Val);
				clsAppMarbleVars.varInterface.SawSpeedOverride = Val;
				clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SawSpeedOverride, "AppRun.SawOverride");
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, "AppRun.SawSpeedUpdate");
			}
			if (clsAppMarbleVars.cMachine.runSystem.SimulatedIO)
			{
				if (control.Name == clsAppMarbleItems.frmSpeedsV1.track_operationspeed.Name)
				{
					clsAppMarbleItems.frmSpeedsV1.track_operationspeed.Value = Convert.ToInt32(Val);
					clsAppMarbleVars.varInterface.OperationSpeed = Val;
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.OperationSpeed, "sysSet.Feed.FeedOverrideG1");
				}
				if (control.Name == clsAppMarbleItems.frmSpeedsV1.track_quickspeed.Name)
				{
					clsAppMarbleItems.frmSpeedsV1.track_quickspeed.Value = Convert.ToInt32(Val);
					clsAppMarbleVars.varInterface.QuickSpeed = Val;
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.QuickSpeed, "sysSet.Feed.FeedOverrideG0");
				}
			}
		}
		else
		{
			if (!(control.Name == clsAppMarbleItems.frmSpeedsV1.track_operationspeed.Name))
			{
				return;
			}
			clsMarble.SimStep = Convert.ToInt32(Val / 10.0);
			clsInit.appMarble.timSim.Interval = 20;
			if (clsMarble.SimStep <= 0)
			{
				clsMarble.SimStep = 1;
				clsInit.appMarble.timSim.Interval = 50;
				if (Val == 2.0)
				{
					clsInit.appMarble.timSim.Interval = 100;
				}
				if (Val == 1.0)
				{
					clsInit.appMarble.timSim.Interval = 200;
				}
			}
		}
	}

	private void spinValueChanged(object sender, double Val)
	{
		Control control = sender as Control;
		if (AppBool.Inited)
		{
			if (control.Name == clsItem.FrmMach1.spn_go.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.JogMoveValue = clsItem.FrmMach1.spn_go.Value;
				AppBool.Inited = true;
			}
			if (control.Name == clsAppMarbleItems.frmMove.spn_eventmovevalue.Name)
			{
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
				AppBool.SaveByTick = true;
			}
			if (control.Name == clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Name)
			{
				buMarbleCalc.varMarbleRunSettings.ManuelRotate = clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value;
				AppBool.SaveByTick = true;
			}
			clsAppMarbleVars.varApp.MaterialWidth = clsItem.FrmMach1.spn_semiautomaterialheight.Value;
			clsAppMarbleVars.varApp.MaterialHeight = clsItem.FrmMach1.spn_semiautomaterialwidth.Value;
			clsAppMarbleVars.varApp.MaterialThickness = clsItem.FrmMach1.spn_semiautomaterialthickness.Value;
			clsAppMarbleVars.varApp.SemiAutoSafeZ = clsItem.FrmMach1.spn_semiautosafedis.Value;
		}
	}

	private void spinClick(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (!AppBool.TouchPad)
		{
			return;
		}
		F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
		f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
		f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
		f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
		if (!buNumeric5.IsNumeric(f_KeyPadNumV.Value))
		{
			return;
		}
		buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
		if (clsItem.FrmMach1.buTab_Main.SelectedIndex == 6)
		{
			SemiAutoParameterChange(FromControlToValues: true);
			if (AppBool.Connected)
			{
				clsAppMarbleVars.cmdMarble.WriteSemiAutoParameters();
			}
		}
	}

	private void spinLeave(object sender, EventArgs e)
	{
		if (clsItem.FrmMach1.buTab_Main.SelectedIndex == 6)
		{
			SemiAutoParameterChange(FromControlToValues: true);
			if (AppBool.Connected)
			{
				clsAppMarbleVars.cmdMarble.WriteSemiAutoParameters();
			}
		}
	}

	private void spinKeyDown(object sender, KeyEventArgs e)
	{
	}

	private void controlEnter(object sender, EventArgs e)
	{
		Control control = sender as Control;
	}

	private void buTabSelectedIndexChanged(object sender, EventArgs e)
	{
		if (clsItem.FrmMach1.buTab_Main.SelectedIndex == 0)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
			{
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: false, "AppRun.SemiAutoEnable");
			}
			if (clsItem.FrmMach1.pnl_mainviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach1.pnl_manuelviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_mainviewport.Controls.Add(clsItem.FrmMach1.pnl_manuelviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_semiauto.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_mainviewport.Controls.Add(clsItem.FrmMach1.pnl_semiauto.Controls[0]);
				}
				buEyeItems.viewportCadCam.ZoomFit();
				buEyeItems.viewportCadCam.ZoomOut(10);
			}
			AppBool.EditMode = false;
		}
		else if (clsItem.FrmMach1.buTab_Main.SelectedIndex == 1)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
			{
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: false, "AppRun.SemiAutoEnable");
			}
			if (clsItem.FrmMach1.pnl_manuelviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach1.pnl_mainviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_manuelviewport.Controls.Add(clsItem.FrmMach1.pnl_mainviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_semiauto.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_manuelviewport.Controls.Add(clsItem.FrmMach1.pnl_semiauto.Controls[0]);
				}
			}
			AppBool.EditMode = false;
		}
		else if (clsItem.FrmMach1.buTab_Main.SelectedIndex == 2)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
			{
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: false, "AppRun.SemiAutoEnable");
			}
			if (clsItem.FrmMach1.pnl_horviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach1.pnl_verviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_horviewport.Controls.Add(clsItem.FrmMach1.pnl_verviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_horverviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_horviewport.Controls.Add(clsItem.FrmMach1.pnl_horverviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_drawviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_horviewport.Controls.Add(clsItem.FrmMach1.pnl_drawviewport.Controls[0]);
				}
				if (clsItem.FrmMach1.pnl_horsettings.Controls.Count == 0)
				{
					if (clsItem.FrmMach1.pnl_versettings.Controls.Count > 0)
					{
						clsItem.FrmMach1.pnl_horsettings.Controls.Add(clsItem.FrmMach1.pnl_versettings.Controls[0]);
					}
					else if (clsItem.FrmMach1.pnl_horversettings.Controls.Count > 0)
					{
						clsItem.FrmMach1.pnl_horsettings.Controls.Add(clsItem.FrmMach1.pnl_horversettings.Controls[0]);
					}
				}
				buEyeItems.viewportCadCam.ZoomFit();
				buEyeItems.viewportCadCam.ZoomOut(10);
			}
			clsInit.appMarble.DeleteSimulationEntities();
			AppBool.EditMode = true;
		}
		else if (clsItem.FrmMach1.buTab_Main.SelectedIndex == 3)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
			{
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: false, "AppRun.SemiAutoEnable");
			}
			if (clsItem.FrmMach1.pnl_verviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach1.pnl_horviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_verviewport.Controls.Add(clsItem.FrmMach1.pnl_horviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_horverviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_verviewport.Controls.Add(clsItem.FrmMach1.pnl_horverviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_drawviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_verviewport.Controls.Add(clsItem.FrmMach1.pnl_drawviewport.Controls[0]);
				}
				if (clsItem.FrmMach1.pnl_versettings.Controls.Count == 0)
				{
					if (clsItem.FrmMach1.pnl_horsettings.Controls.Count > 0)
					{
						clsItem.FrmMach1.pnl_versettings.Controls.Add(clsItem.FrmMach1.pnl_horsettings.Controls[0]);
					}
					else if (clsItem.FrmMach1.pnl_horversettings.Controls.Count > 0)
					{
						clsItem.FrmMach1.pnl_versettings.Controls.Add(clsItem.FrmMach1.pnl_horversettings.Controls[0]);
					}
				}
				buEyeItems.viewportCadCam.ZoomFit();
				buEyeItems.viewportCadCam.ZoomOut(10);
			}
			clsInit.appMarble.DeleteSimulationEntities();
			AppBool.EditMode = true;
		}
		else if (clsItem.FrmMach1.buTab_Main.SelectedIndex == 4)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
			{
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: false, "AppRun.SemiAutoEnable");
			}
			if (clsItem.FrmMach1.pnl_horverviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach1.pnl_horviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_horverviewport.Controls.Add(clsItem.FrmMach1.pnl_horviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_verviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_horverviewport.Controls.Add(clsItem.FrmMach1.pnl_verviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_drawviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_horverviewport.Controls.Add(clsItem.FrmMach1.pnl_drawviewport.Controls[0]);
				}
				if (clsItem.FrmMach1.pnl_horversettings.Controls.Count == 0)
				{
					if (clsItem.FrmMach1.pnl_horsettings.Controls.Count > 0)
					{
						clsItem.FrmMach1.pnl_horversettings.Controls.Add(clsItem.FrmMach1.pnl_horsettings.Controls[0]);
					}
					else if (clsItem.FrmMach1.pnl_versettings.Controls.Count > 0)
					{
						clsItem.FrmMach1.pnl_horversettings.Controls.Add(clsItem.FrmMach1.pnl_versettings.Controls[0]);
					}
				}
				buEyeItems.viewportCadCam.ZoomFit();
				buEyeItems.viewportCadCam.ZoomOut(10);
			}
			clsInit.appMarble.DeleteSimulationEntities();
			AppBool.EditMode = true;
		}
		else if (clsItem.FrmMach1.buTab_Main.SelectedIndex == 5)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
			{
				clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: false, "AppRun.SemiAutoEnable");
			}
			if (clsItem.FrmMach1.pnl_drawviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach1.pnl_horviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_drawviewport.Controls.Add(clsItem.FrmMach1.pnl_horviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_verviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_drawviewport.Controls.Add(clsItem.FrmMach1.pnl_verviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_horverviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_drawviewport.Controls.Add(clsItem.FrmMach1.pnl_horverviewport.Controls[0]);
				}
				buEyeItems.viewportCadCam.ZoomFit();
				buEyeItems.viewportCadCam.ZoomOut(10);
			}
			clsInit.appMarble.DeleteSimulationEntities();
			AppBool.EditMode = true;
		}
		else if (clsItem.FrmMach1.buTab_Main.SelectedIndex == 6)
		{
			if (clsItem.FrmMach1.pnl_semiauto.Controls.Count == 0)
			{
				if (clsItem.FrmMach1.pnl_mainviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_semiauto.Controls.Add(clsItem.FrmMach1.pnl_mainviewport.Controls[0]);
				}
				else if (clsItem.FrmMach1.pnl_manuelviewport.Controls.Count > 0)
				{
					clsItem.FrmMach1.pnl_semiauto.Controls.Add(clsItem.FrmMach1.pnl_manuelviewport.Controls[0]);
				}
			}
			AppBool.EditMode = false;
		}
		MarbleTempVars.LastSelectedTabPage = clsItem.FrmMach1.buTab_Main.SelectedIndex;
	}

	public void FormKeyDown(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == clsItem.FrmMach1.Name && e.KeyCode == Keys.Escape)
		{
			clickCommands(clsItem.FrmMach1.btn_cancel, new EventArgs());
		}
	}

	public void UpdateVisualThings()
	{
		string text = "UpdateVisualThings";
		try
		{
			buLogMarbleVer5.addToLogList(sClass, text, "Started");
			if (buEyeVars.parVisual == null)
			{
				buEyeVars.parVisual = new clsVisualVars();
			}
			clsItem.FrmMach1.buTab_Main.ItemSize = new Size(1, 1);
			clsItem.FrmMach1.buTab_drawing.ItemSize = new Size(1, 1);
			clsItem.FrmMach1.tabPage_Drawing.Text = "";
			clsItem.FrmMach1.tabPage_Event.Text = "";
			clsItem.FrmMach1.tabPage_Functions.Text = "";
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmCoordsV1");
			clsAppMarbleItems.frmCoordsV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmCoordsV1");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmSpeeds");
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmSpeeds");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmViewV1");
			clsAppMarbleItems.frmViewsV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmViewV1");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmViewGCodeV1");
			clsAppMarbleItems.frmGCodeViewV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmViewGCodeV1");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmCommandsV1");
			clsAppMarbleItems.frmCommandsV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmCommandsV1");
			clsItem.FrmMach1.btn_contour.Visible = clsVar.UserMode.MarbleMode.FileImport;
			clsItem.FrmMach1.btn_library.Visible = clsVar.UserMode.MarbleMode.Library;
			clsItem.FrmMach1.btn_profiling.Visible = clsVar.UserMode.MarbleMode.Profile;
			clsItem.FrmMach1.btn_profilecurve.Visible = clsVar.UserMode.MarbleMode.Profile;
			clsItem.FrmMach1.btn_engraving.Visible = clsVar.UserMode.MarbleMode.Engraving3Axis;
			clsItem.FrmMach1.btn_text.Visible = clsVar.UserMode.MarbleMode.Text;
			clsItem.FrmMach1.btn_OPMenu.Visible = clsVar.UserMode.MarbleMode.OPMenu;
			buLogMarbleVer5.addToLogList(sClass, text, "Finished");
			buLogMarbleVer5.saveLogList();
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, "", 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controls = clsItem.FrmMach1.buGround1.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			clsItem.FrmMach1.btn_main.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_main.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 1)
		{
			clsItem.FrmMach1.btn_manuel.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_manuel.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 2)
		{
			clsItem.FrmMach1.btn_horizontal.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_horizontal.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 3)
		{
			clsItem.FrmMach1.btn_vertical.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_vertical.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 4)
		{
			clsItem.FrmMach1.btn_horver.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_horver.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 5)
		{
			clsItem.FrmMach1.btn_drawing.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_drawing.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 6)
		{
			clsItem.FrmMach1.btn_semiAuto.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_semiAuto.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
	}

	public void MenuDrawButtonColors(int PageIndex)
	{
		Control.ControlCollection controls = clsItem.FrmMach1.pnl_drawing.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			clsItem.FrmMach1.btn_drawmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_drawmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 1)
		{
			clsItem.FrmMach1.btn_eventmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_eventmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 2)
		{
			clsItem.FrmMach1.btn_functionsmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_functionsmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 3)
		{
			clsItem.FrmMach1.btn_misc.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach1.btn_misc.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
	}

	public void OpenParameter()
	{
		try
		{
			clsInit.appMarble.OpenMarbleFile(AppPath.MachineSettingsCam + "\\Marble");
			if (clsInit.appNesting != null)
			{
				clsInit.appNesting.OpenNestingFile();
			}
			if (cMarbleVars == null)
			{
				cMarbleVars = new clsAppMarbleVars();
			}
			cMarbleVars.Init();
			string fileName = AppPath.MachineSettings + "\\Machine.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (fileInfo.Exists)
			{
				ArrayList arrayList = new ArrayList();
				TextReader textReader = File.OpenText(fileInfo.FullName);
				List<List<string>> CalcList = new List<List<string>>();
				string text = "";
				while ((text = textReader.ReadLine()) != null)
				{
					arrayList.Add(text);
				}
				textReader.Close();
				try
				{
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsAppMarbleVars.cMachine.MachineSetting);
					buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, clsAppMarbleVars.varForms);
					clsAppMarbleVars.cMachine.varCNC2 = new CodesysCNCSets();
					clsAppMarbleVars.cMachine.varCNC3 = new CodesysCNCSets();
					CodesysAxesData codesysAxesData = new CodesysAxesData();
					CodesysAxesData codesysAxesData2 = new CodesysAxesData();
					CodesysAxesData codesysAxesData3 = new CodesysAxesData();
					CodesysAxesData codesysAxesData4 = new CodesysAxesData();
					CodesysAxesData codesysAxesData5 = new CodesysAxesData();
					CodesysAxesData codesysAxesData6 = new CodesysAxesData();
					CodesysAxesData codesysAxesData7 = new CodesysAxesData();
					CodesysAxesData codesysAxesData8 = new CodesysAxesData();
					CodesysAxesData codesysAxesData9 = new CodesysAxesData();
					CodesysAxesData codesysAxesData10 = new CodesysAxesData();
					clsAppMarbleVars.varRuntime.AxX2 = 5;
					clsAppMarbleVars.varRuntime.AxY2 = 6;
					clsAppMarbleVars.varRuntime.AxZ2 = 7;
					clsAppMarbleVars.varRuntime.AxC2 = 8;
					clsAppMarbleVars.varRuntime.AxA2 = 9;
					buSerilization.Decode(arrayList, "_X", SerilizationMode.MultiLine, codesysAxesData.AxisPar);
					buSerilization.Decode(arrayList, "_Y", SerilizationMode.MultiLine, codesysAxesData2.AxisPar);
					buSerilization.Decode(arrayList, "_Z", SerilizationMode.MultiLine, codesysAxesData3.AxisPar);
					buSerilization.Decode(arrayList, "_C", SerilizationMode.MultiLine, codesysAxesData5.AxisPar);
					buSerilization.Decode(arrayList, "_A", SerilizationMode.MultiLine, codesysAxesData4.AxisPar);
					buSerilization.Decode(arrayList, "_X2", SerilizationMode.MultiLine, codesysAxesData6.AxisPar);
					buSerilization.Decode(arrayList, "_Y2", SerilizationMode.MultiLine, codesysAxesData7.AxisPar);
					buSerilization.Decode(arrayList, "_Z2", SerilizationMode.MultiLine, codesysAxesData8.AxisPar);
					buSerilization.Decode(arrayList, "_C2", SerilizationMode.MultiLine, codesysAxesData10.AxisPar);
					buSerilization.Decode(arrayList, "_A2", SerilizationMode.MultiLine, codesysAxesData9.AxisPar);
					codesysAxesData.AxisPar.Base.baseChar = buLangTranslate.preChar.X + "_1";
					codesysAxesData.AxisPar.Base.baseName = buLangTranslate.preChar.X + "_1";
					codesysAxesData2.AxisPar.Base.baseChar = buLangTranslate.preChar.Y + "_1";
					codesysAxesData2.AxisPar.Base.baseName = buLangTranslate.preChar.Y + "_1";
					codesysAxesData3.AxisPar.Base.baseChar = buLangTranslate.preChar.Z + "_1";
					codesysAxesData3.AxisPar.Base.baseName = buLangTranslate.preChar.Z + "_1";
					codesysAxesData4.AxisPar.Base.baseChar = buLangTranslate.preChar.A + "_1";
					codesysAxesData4.AxisPar.Base.baseName = buLangTranslate.preChar.A + "_1";
					codesysAxesData5.AxisPar.Base.baseChar = buLangTranslate.preChar.C + "_1";
					codesysAxesData5.AxisPar.Base.baseName = buLangTranslate.preChar.C + "_1";
					codesysAxesData6.AxisPar.Base.baseChar = buLangTranslate.preChar.X + "_2";
					codesysAxesData6.AxisPar.Base.baseName = buLangTranslate.preChar.X + "_2";
					codesysAxesData7.AxisPar.Base.baseChar = buLangTranslate.preChar.Y + "_2";
					codesysAxesData7.AxisPar.Base.baseName = buLangTranslate.preChar.Y + "_2";
					codesysAxesData8.AxisPar.Base.baseChar = buLangTranslate.preChar.Z + "_2";
					codesysAxesData8.AxisPar.Base.baseName = buLangTranslate.preChar.Z + "_2";
					codesysAxesData9.AxisPar.Base.baseChar = buLangTranslate.preChar.A + "_2";
					codesysAxesData9.AxisPar.Base.baseName = buLangTranslate.preChar.A + "_2";
					codesysAxesData10.AxisPar.Base.baseChar = buLangTranslate.preChar.C + "_2";
					codesysAxesData10.AxisPar.Base.baseName = buLangTranslate.preChar.C + "_2";
					clsAppMarbleVars.cMachine.AppAxis = new List<CodesysAxesData>();
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData);
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData2);
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData3);
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData5);
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData4);
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData6);
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData7);
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData8);
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData10);
					clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData9);
					List<string> CalcList2 = new List<string>();
					try
					{
						buString.ListToSpecificList("<G54Offset>", "</G54Offset>", AddStartEndKey: false, arrayList, ref CalcList2);
						for (int i = 0; i <= CalcList2.Count - 1; i++)
						{
							if (i <= clsAppMarbleVars.cMachine.G54List.Length - 1 && i <= 4)
							{
								clsAppMarbleVars.cMachine.G54List[i] = new Pnt9DS(Pnt9DS.DecodeFromString(CalcList2[i]));
							}
						}
					}
					catch (Exception)
					{
					}
					CalcList = new List<List<string>>();
					buString.ListToSpecificList("<ToolActiveMilling>", "</ToolActiveMilling>", AddStartEndKey: false, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						ArrayList arrayList2 = new ArrayList();
						arrayList2.AddRange(CalcList[0].ToArray());
						ToolBase5 toolBase = new ToolBase5();
						buSerilization5.Decode(arrayList2, "Milling", SerilizationMode5.MultiLine, buMarbleCalc.activeToolMilling);
					}
					CalcList = new List<List<string>>();
					buString.ListToSpecificList("<ToolActiveMillingHead>", "</ToolActiveMillingHead>", AddStartEndKey: false, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						ArrayList arrayList3 = new ArrayList();
						arrayList3.AddRange(CalcList[0].ToArray());
						ToolBase5 toolBase2 = new ToolBase5();
						buSerilization5.Decode(arrayList3, "MillingHead", SerilizationMode5.MultiLine, buMarbleCalc.activeToolMillingHead);
					}
					CalcList = new List<List<string>>();
					buString.ListToSpecificList("<ToolActiveSaw>", "</ToolActiveSaw>", AddStartEndKey: false, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						ArrayList arrayList4 = new ArrayList();
						arrayList4.AddRange(CalcList[0].ToArray());
						ToolBase5 toolBase3 = new ToolBase5();
						buSerilization5.Decode(arrayList4, "Saw", SerilizationMode5.MultiLine, buMarbleCalc.activeToolSaw);
					}
					CalcList2 = new List<string>();
					buString.ListToSpecificList("<ToolList>", "</ToolList>", AddStartEndKey: false, arrayList, ref CalcList2);
					if (CalcList2.Count > 0)
					{
						if (buMarbleCalc.ToolMillings == null)
						{
							buMarbleCalc.ToolMillings = new List<ToolBase5>();
						}
						buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", AddStartEndKey: false, CalcList2, ref CalcList);
						for (int j = 0; j <= CalcList.Count - 1; j++)
						{
							ToolBase5 Tool = new ToolBase5();
							ToolBase5.DecodeShort(CalcList[j], ref Tool);
							buMarbleCalc.ToolMillings.Add(Tool);
						}
					}
					else
					{
						if (buMarbleCalc.ToolMillings == null)
						{
							buMarbleCalc.ToolMillings = new List<ToolBase5>();
						}
						ToolBase5 toolBase4 = new ToolBase5();
						toolBase4.Geometry.Diameter = 350.0;
						toolBase4.Geometry.Thickness = 3.0;
						toolBase4.Geometry.GeometryType = ToolType.Saw;
						toolBase4.Purpose = ToolPurpose.Saw;
						buMarbleCalc.ToolMillings.Add(toolBase4);
						for (int k = buMarbleCalc.ToolMillings.Count; k <= 9; k++)
						{
							toolBase4 = new ToolBase5();
							toolBase4.Geometry.Diameter = 10.0;
							toolBase4.Geometry.Length = 100.0;
							toolBase4.Geometry.GeometryType = ToolType.Flat;
							toolBase4.Purpose = ToolPurpose.Milling;
							buMarbleCalc.ToolMillings.Add(toolBase4);
						}
					}
					buMarbleCalc.activeToolMilling.Purpose = ToolPurpose.Milling;
					buMarbleCalc.activeToolSaw.Purpose = ToolPurpose.Saw;
					buMarbleCalc.activeToolSaw.Geometry.GeometryType = ToolType.Saw;
					buMarbleCalc.activeToolMillingHead.Purpose = ToolPurpose.MillingHead;
				}
				catch (Exception mSException)
				{
					buLog.addLog("Open Error Axes Parameter", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Open Error Axes Parameter");
				}
				try
				{
					buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, clsAppMarbleVars.varInterface);
					buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, clsAppMarbleVars.varApp);
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsAppMarbleVars.cMachine.ProgramSettings);
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsAppMarbleVars.cMachine.PLCSettings);
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsAppMarbleVars.cMachine.varSystem);
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsAppMarbleVars.cMachine.varJog);
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsAppMarbleVars.cMachine.varHandWheel);
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsAppMarbleVars.cMachine.varCNC);
					buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buMarbleCalc.varMarbleRunSettings);
					buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buMarbleCalc.varMarbleSettings);
					CodesysMachine.CommType = clsAppMarbleVars.cMachine.PLCSettings.CommType;
				}
				catch (Exception mSException2)
				{
					buLog.addLog("Open Error System Parameter", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Open Error System Parameter");
				}
				arrayList.Clear();
				CalcList.Clear();
			}
			else
			{
				buLog.addLog("Machine 1 Parameter File Missing", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxInfo("Machine 1 Parameter File Missing");
			}
			fileName = AppPath.MachineSettings + "\\IO.prm";
			fileInfo = new FileInfo(fileName);
			if (fileInfo.Exists)
			{
				ArrayList arrayList5 = new ArrayList();
				TextReader textReader2 = File.OpenText(fileInfo.FullName);
				string text2 = "";
				while ((text2 = textReader2.ReadLine()) != null)
				{
					arrayList5.Add(text2);
				}
				textReader2.Close();
				List<string> CalcList3 = new List<string>();
				List<string> CalcList4 = new List<string>();
				buString.ListToSpecificList("<Inputs>", "</Inputs>", AddStartEndKey: false, arrayList5, ref CalcList3);
				buString.ListToSpecificList("<Outputs>", "</Outputs>", AddStartEndKey: false, arrayList5, ref CalcList4);
				buString.RemoveCharsFromString(Trim: true, Tab: true, new List<string>(), ref CalcList3);
				buString.RemoveCharsFromString(Trim: true, Tab: true, new List<string>(), ref CalcList4);
				for (int l = 0; l <= CalcList3.Count - 1; l++)
				{
					clsAppMarbleVars.cMachine.Inputs.Add(new DigitalInputData(CalcList3[l]));
				}
				for (int m = 0; m <= CalcList4.Count - 1; m++)
				{
					clsAppMarbleVars.cMachine.Outputs.Add(new DigitalOutputData(CalcList4[m]));
				}
				buLog.addLog("IO  File Read ", "", "", "Ok", 0);
				arrayList5.Clear();
			}
			else
			{
				buLog.addLog("Machine 1 IO File Missing", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxInfo("Machine 1 IO File Missing");
			}
			AppBool.TouchPad = buMarbleCalc.varMarbleSettings.TouchPad;
		}
		catch (Exception)
		{
		}
	}

	public void SaveParameter()
	{
		SaveParameter(AppPath.MachineSettings);
	}

	public void SaveParameter(string Path)
	{
		try
		{
			clsInit.appMarble.SaveMarbleFile(Path);
			ArrayList arrayList = new ArrayList();
			string fileName = Path + "\\Machine.prm";
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Machine  Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.MachineSetting.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   PLC  Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.PLCSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   CNC  Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.varCNC.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   App Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.varApp.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Program Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.ProgramSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Interface Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.varInterface.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Machine Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(buMarbleCalc.varMarbleMachineSettings.OptionSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Forms Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.varForms.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add(" ");
			if (buMarbleCalc.ToolMillings != null)
			{
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.Add("   Tool List");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.Add("  <ToolList>");
				for (int i = 0; i <= buMarbleCalc.ToolMillings.Count - 1; i++)
				{
					if (buMarbleCalc.ToolMillings[i] != null)
					{
						arrayList.Add("    <ToolListBase>");
						arrayList.AddRange(ToolBase5.ToDefShort(6, buMarbleCalc.ToolMillings[i]));
						arrayList.Add("    </ToolListBase>");
					}
				}
				arrayList.Add("  </ToolList>");
				arrayList.Add("");
			}
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Tool Active");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <ToolActiveMilling>");
			arrayList.AddRange(buMarbleCalc.activeToolMilling.ToDefAll("Milling", 4, SerilizationMode5.MultiLine));
			arrayList.Add("  </ToolActiveMilling>");
			arrayList.Add("");
			arrayList.Add("  <ToolActiveMillingHead>");
			arrayList.AddRange(buMarbleCalc.activeToolMillingHead.ToDefAll("MillingHead", 4, SerilizationMode5.MultiLine));
			arrayList.Add("  </ToolActiveMillingHead>");
			arrayList.Add("");
			arrayList.Add("  <ToolActiveSaw>");
			arrayList.AddRange(buMarbleCalc.activeToolSaw.ToDefAll("Saw", 4, SerilizationMode5.MultiLine));
			arrayList.Add("  </ToolActiveSaw>");
			arrayList.Add("");
			arrayList.Add("  <ToolActiveLaser>");
			arrayList.AddRange(buMarbleCalc.activeToolLaserPointer.ToDefAll("Laser", 4, SerilizationMode5.MultiLine));
			arrayList.Add("  </ToolActiveLaser>");
			arrayList.Add("");
			arrayList.Add("  <ToolActiveAirDry>");
			arrayList.AddRange(buMarbleCalc.activeToolAirDry.ToDefAll("airDry", 4, SerilizationMode5.MultiLine));
			arrayList.Add("  </ToolActiveAirDry>");
			arrayList.Add("");
			arrayList.Add("  <ToolActiveWaterJet>");
			arrayList.AddRange(buMarbleCalc.activeToolWaterjet.ToDefAll("Waterjet", 4, SerilizationMode5.MultiLine));
			arrayList.Add("  </ToolActiveWaterJet>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   G54 Offsets");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <G54Offset>");
			for (int j = 0; j <= clsAppMarbleVars.cMachine.G54List.Length - 1; j++)
			{
				if (j <= clsAppMarbleVars.cMachine.MachineSetting.G54Count - 1)
				{
					arrayList.Add("    " + clsAppMarbleVars.cMachine.G54List[j].ToDef());
				}
			}
			arrayList.Add("  </G54Offset>");
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   X1 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.ToDefAll("_X", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Y1 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.ToDefAll("_Y", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Z1 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.ToDefAll("_Z", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   C1 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.ToDefAll("_C", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   A1 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.ToDefAll("_A", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   X2 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.ToDefAll("_X2", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Y2 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.ToDefAll("_Y2", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Z2 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.ToDefAll("_Z2", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   C2 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.ToDefAll("_C2", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   A2 Axis Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.ToDefAll("_A2", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   System Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.varSystem.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Jog Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.varJog.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Handwheel Parameter");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsAppMarbleVars.cMachine.varHandWheel.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add(" ");
			buFile.SaveToFile(arrayList, fileName);
		}
		catch (Exception)
		{
		}
	}

	public void SemiAutoParameterChange(bool FromControlToValues)
	{
		if (FromControlToValues)
		{
			clsAppMarbleVars.varApp.SemiAutoWidth = clsItem.FrmMach1.spn_semiautohorizontallen.Value;
			clsAppMarbleVars.varApp.SemiAutoHeight = clsItem.FrmMach1.spn_semiautoverticallen.Value;
			clsAppMarbleVars.varApp.SemiAutoCutFeed = clsItem.FrmMach1.spn_semiautocuttingspeed.Value;
			clsAppMarbleVars.varApp.SemiAutoPlungeFeed = clsItem.FrmMach1.spn_semiautoplungespeed.Value;
			clsAppMarbleVars.varApp.SemiAutoTargetZ = clsItem.FrmMach1.spn_semiautooperationz.Value;
			clsAppMarbleVars.varApp.SemiAutoSafeZ = clsItem.FrmMach1.spn_semiautosafedis.Value;
			clsAppMarbleVars.varApp.MaterialHeight = clsItem.FrmMach1.spn_semiautomaterialheight.Value;
			clsAppMarbleVars.varApp.MaterialWidth = clsItem.FrmMach1.spn_semiautomaterialwidth.Value;
			clsAppMarbleVars.varApp.MaterialThickness = clsItem.FrmMach1.spn_semiautomaterialthickness.Value;
		}
		else
		{
			clsItem.FrmMach1.spn_semiautohorizontallen.Value = clsAppMarbleVars.varApp.SemiAutoWidth;
			clsItem.FrmMach1.spn_semiautoverticallen.Value = clsAppMarbleVars.varApp.SemiAutoHeight;
			clsItem.FrmMach1.spn_semiautocuttingspeed.Value = clsAppMarbleVars.varApp.SemiAutoCutFeed;
			clsItem.FrmMach1.spn_semiautoplungespeed.Value = clsAppMarbleVars.varApp.SemiAutoPlungeFeed;
			clsItem.FrmMach1.spn_semiautooperationz.Value = clsAppMarbleVars.varApp.SemiAutoTargetZ;
			clsItem.FrmMach1.spn_semiautosafedis.Value = clsAppMarbleVars.varApp.SemiAutoSafeZ;
			clsItem.FrmMach1.spn_semiautomaterialheight.Value = clsAppMarbleVars.varApp.MaterialHeight;
			clsItem.FrmMach1.spn_semiautomaterialwidth.Value = clsAppMarbleVars.varApp.MaterialWidth;
			clsItem.FrmMach1.spn_semiautomaterialthickness.Value = clsAppMarbleVars.varApp.MaterialThickness;
		}
	}

	public void MainControlsToParameter(bool FromControlToValues)
	{
		if (FromControlToValues)
		{
			buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity = clsItem.FrmMach1.spn_camcuttingspped.Value;
			buMarbleCalc.varOperation.MaterialParameter.MaterialThickness = clsItem.FrmMach1.spn_cammarblethickness.Value;
			buMarbleCalc.varOperation.settingMarbleCam.TargetZ = clsItem.FrmMach1.spn_camoperationZ.Value;
			buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity = clsItem.FrmMach1.spn_camplungespeed.Value;
			buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance = clsItem.FrmMach1.spn_camcuttingstep.Value;
			buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance = clsItem.FrmMach1.spn_camsafedis.Value;
			buMarbleCalc.varMarbleRunSettings.CutLengthVertical = buMarbleForms.frmVertical.spn_itemlength.Value;
			buMarbleCalc.varMarbleRunSettings.CutLengthHorizontal = buMarbleForms.frmHorizontal.spn_itemlength.Value;
			buMarbleCalc.activeToolSaw.CamData.SpindleSpeed = clsItem.FrmMach1.spn_camspindlespeed.Value;
		}
		else
		{
			clsItem.FrmMach1.spn_camcuttingspped.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity;
			clsItem.FrmMach1.spn_cammarblethickness.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
			clsItem.FrmMach1.spn_camoperationZ.Value = buMarbleCalc.varOperation.settingMarbleCam.TargetZ;
			clsItem.FrmMach1.spn_camplungespeed.Value = buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity;
			clsItem.FrmMach1.spn_camcuttingstep.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance;
			clsItem.FrmMach1.spn_camsafedis.Value = buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance;
			buMarbleForms.frmVertical.spn_itemlength.Value = buMarbleCalc.varMarbleRunSettings.CutLengthVertical;
			buMarbleForms.frmHorizontal.spn_itemlength.Value = buMarbleCalc.varMarbleRunSettings.CutLengthHorizontal;
			clsItem.FrmMach1.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
		}
	}

	public void MarbleCoreCommends(MarbleEventCommands Cmd, MarbleCommandArgs Data)
	{
		switch (Cmd)
		{
		case MarbleEventCommands.JobUpdate:
		{
			for (int i = 0; i <= clsInit.appMarble.activeJob.Items.Count - 1; i++)
			{
				clsAppMarbleVars.cmdMarble.SetJobOperationItemByJobIndex(i);
			}
			break;
		}
		case MarbleEventCommands.SelectionUpdate:
			clsAppMarbleVars.cmdMarble.JopItemUpdateAll();
			break;
		case MarbleEventCommands.MoveMouse:
			if (Data != null)
			{
				clsItem.FrmMach1.lbl_viewportcoords.Text = "X: " + Data.pntMove.X.ToString("f2") + " , Y: " + Data.pntMove.Y.ToString("f2") + " , Z: " + Data.pntMove.Z.ToString("f2");
			}
			break;
		}
	}

	public void ShowWarning(string Message, Color clr)
	{
		clsItem.FrmMach1.lbl_warning.Visible = true;
		clsItem.FrmMach1.lbl_warning.Text = Message;
		clsItem.FrmMach1.lbl_warning.BackColor = clr;
		clsAppMarbleVars.cMachine.miscVar.cntWarning = 0;
		clsAppMarbleVars.cMachine.miscVar.WarningAvailable = true;
	}

	public void MainFormUpdate(bool MenuUpdate, bool SettinsUpdate, bool ControlUpdate)
	{
	}

	public void MainFormStatusUpdate(string status)
	{
	}

	public void MainFormXYZUpdate(string X, string Y, string Z)
	{
	}

	public void PageEntityAdd(object Entity, int EntityIndex)
	{
	}

	public bool RunCommands(string Command, ArrayList Args)
	{
		try
		{
			return false;
		}
		catch (Exception mSException)
		{
			string command = "";
			if (Args.Count > 0)
			{
				command = Args[0].ToString();
			}
			buLog.addLog(command, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	public void RunGeneralCommand(GeneralCommandEventArg e)
	{
	}

	public void showMenuPage(object sender, EventArgs e)
	{
		clsItem.FrmMenu.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmMenu.LoadLanguage();
		clsItem.FrmMenu.ShowDialog(clsItem.FrmMach1);
	}

	public void showSettingsPage(object sender, EventArgs e)
	{
		clsItem.FrmMenuSettings.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmMenuSettings.LoadLanguage();
		clsItem.FrmMenuSettings.ShowDialog(clsItem.FrmMach1);
	}

	public void showLanguageMenu(object sender, EventArgs e)
	{
		if (AppSecurity.PasswordLevel < 2)
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentences.PasswordLevelNotEnough);
			return;
		}
		clsAppMarbleVars.cmdMarble.ShowLanguageMenu();
		clsItem.FrmMach1.LoadLanguage();
		clsItem.FrmMenu.LoadLanguage();
		clsItem.FrmMenuSettings.LoadLanguage();
		if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
		{
			clsItem.FrmMenu.Visible = false;
		}
	}

	public void showReportPage(object sender, EventArgs e)
	{
		clsAppMarbleVars.cmdMarble.ShowReport();
		if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
		{
			clsItem.FrmMenu.Visible = false;
		}
	}

	public void showDebug(object sender, EventArgs e)
	{
		clsAppMarbleVars.cmdMarble.ShowReport();
		if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
		{
			clsItem.FrmMenu.Visible = false;
		}
	}

	public void showWatch(object sender, EventArgs e)
	{
		clsAppMarbleVars.cmdMarble.ShowWatch();
		if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
		{
			clsItem.FrmMenu.Visible = false;
		}
	}

	public void showTestPage(object sender, EventArgs e)
	{
		clsAppMarbleVars.cmdMarble.ShowTest();
		if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
		{
			clsItem.FrmMenu.Visible = false;
		}
	}

	public void showSimulationPanel(object sender, EventArgs e)
	{
		clsInit.appMarble.doSimulationCalculate(ref clsInit.appMarble.activeJob);
		clsInit.appMarble.cmdShowSimulationPanel();
		if (!ccVars.Pages[ccVars.PageIndex].Form.viewportcad.IsAnimationRunning)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartAnimation();
		}
		clsInit.appMarble.DeleteSimulationEntities();
		clsInit.appMarble.DrawSimulationEntities(cam: false, machine: true, DrawAllTool: true, MarbleToolType.Saw);
		clsInit.appMarble.MoveSimPart(new Pnt6DSimMove(-290.0, -200.0, 500.0, 0.0, 0.0, 0.0), SpindleDown: false, buMarbleCalc.activeToolSaw);
		clsItem.FrmMenu.Visible = false;
	}

	public void ThreadLoop()
	{
		while (buPLCHandler.ThreadEnable)
		{
			bool flag = true;
			if (!((AppBool.Inited & AppBool.Connected) && flag))
			{
				continue;
			}
			if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
			{
				if (buPLCHandler.PLCStatus != 4)
				{
				}
				if ((clsAppMarbleVars.cMachine.miscVar.cntCommunication % 2 == 0) & AppBool.Inited)
				{
					clsAppMarbleVars.cMachine.Commands.ReadAxisGroup(new ReadAxisDataBits(position: true, offsetedPosition: true, enabled: true, homingdone: true), ref clsAppMarbleVars.cMachine.AppAxis);
				}
			}
			if (AppBool.Inited)
			{
				if ((clsAppMarbleVars.cMachine.miscVar.cntCommunication % 2 == 0) & AppBool.Inited)
				{
					clsAppMarbleVars.cMachine.Commands.ReadAxisGroup(new ReadAxisDataBits(position: true, offsetedPosition: true, enabled: true, homingdone: true), ref clsAppMarbleVars.cMachine.AppAxis);
				}
				ReadLRealValues();
				ReadBOOLValues();
				ReadDINTValues();
				clsAppMarbleVars.cMachine.runSystem.FirstPLCRead = true;
			}
			if (clsAppMarbleItems.frmDigitalInputOutput.Visible)
			{
				clsAppMarbleVars.cmdMarble.ReadIOBOOLValues();
			}
			if (clsAppMarbleVars.cMachine.bWriteSettingsParameter)
			{
				clsAppMarbleVars.cMachine.bParameterWriting = true;
				clsAppMarbleVars.cmdMarble.WriteSettingsParameter();
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = false;
			}
			if (clsAppMarbleVars.cMachine.bWriteG54Parameter)
			{
				clsAppMarbleVars.cMachine.bParameterWriting = true;
				clsAppMarbleVars.cmdMarble.WriteG54();
				clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ParameterCNCUpdate");
				clsAppMarbleVars.cMachine.bWriteG54Parameter = false;
			}
			if (clsAppMarbleVars.cMachine.bWriteToolParameter)
			{
				clsAppMarbleVars.cMachine.bParameterWriting = true;
				clsAppMarbleVars.cmdMarble.WriteToolParameter(MillingHead: true);
				clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ParameterCNCUpdate");
				clsAppMarbleVars.cMachine.bWriteToolParameter = false;
			}
			if (clsAppMarbleVars.cMachine.bWriteAppParameter)
			{
				clsAppMarbleVars.cMachine.bParameterWriting = true;
				clsAppMarbleVars.cmdMarble.WriteAppParameter();
				clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ParameterCNCUpdate");
				clsAppMarbleVars.cMachine.bWriteAppParameter = false;
			}
			clsAppMarbleVars.cMachine.bParameterWriting = false;
		}
	}

	public void ReadLRealValues()
	{
		clsAppMarbleVars.cmdMarble.ReadLRealValues();
	}

	public void ReadRealValues()
	{
		clsAppMarbleVars.cmdMarble.ReadRealValues();
	}

	public void ReadDINTValues()
	{
		clsAppMarbleVars.cmdMarble.ReadDINTValues();
	}

	public void ReadBOOLValues()
	{
		clsAppMarbleVars.cmdMarble.ReadBOOLValues();
	}
}
