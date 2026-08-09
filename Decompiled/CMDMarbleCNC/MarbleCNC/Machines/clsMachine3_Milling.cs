using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
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
using buMarble;
using buMotion;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace MarbleCNC.Machines;

public class clsMachine3_Milling
{
	private Point3D pntActive = new Point3D();

	private System.Windows.Forms.Timer timPlcHandlerRelease = new System.Windows.Forms.Timer();

	private bool Inited = false;

	private string sClass = "clsMachine3_Milling";

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
			clsItem.FrmMach3Milling.lbl_warning.Height = 85;
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
			AssingControls();
			AddControls();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "AddControls");
			UpdateVisualThings();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "UpdateVisualThings");
			clsInit.appMarble.SimUpdated += clsAppMarbleVars.cmdMarble.SimUpdated;
			clsItem.FrmMach3Milling.KeyPreview = true;
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
			clsItem.FrmMach3Milling.pnl_drawviewport.Width = 1450;
			clsItem.FrmMach3Milling.pnl_drawingjob.Visible = false;
			clsItem.FrmMach3Milling.btn_vacuumup.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.VacuumEnable;
			clsItem.FrmMach3Milling.btn_vacuumdown.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.VacuumEnable;
			clsItem.FrmMach3Milling.btn_vacuumclose.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.VacuumEnable;
			clsItem.FrmMach3Milling.btn_vacuumopen.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.VacuumEnable;
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "Move Controls");
			clsItem.FrmMach3Milling.btn_menu.Click += showMenuPage;
			clsItem.FrmMenu.btn_settings.Click += showSettingsPage;
			clsItem.FrmMenu.btn_adminsettings.Click += showAdminSettingsPage;
			clsItem.FrmMenu.btn_simulationpanel.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_selectmaterial.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_closepc.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_test.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_password.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_tools.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_g54offset.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_report.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_calculations.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_warmup.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_maintanance.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_materialmeasurement.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_settingsaxes.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_millingsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_programsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_marblecamsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_servoconnection.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_G54Offset.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_AbsoluteHomeSet.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_calibration.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_toolsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_vagoonsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_camerasettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_cameracalibration.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_machinedefination.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_GantryPage.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_language.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_debug.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_watch.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_counters.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_techniciandefine.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_userdefine.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_loadbackup.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_userinterfacesettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach3Milling.btn_information.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach3Milling.btn_main.Click += clickCommandMainMenuButton;
			clsItem.FrmMach3Milling.btn_manuel.Click += clickCommandMainMenuButton;
			clsItem.FrmMach3Milling.btn_drawing.Click += clickCommandMainMenuButton;
			clsItem.FrmMach3Milling.btn_drawmode.Click += clickCommandMainMenuButton;
			clsItem.FrmMach3Milling.btn_eventmode.Click += clickCommandMainMenuButton;
			clsItem.FrmMach3Milling.btn_functionsmode.Click += clickCommandMainMenuButton;
			clsItem.FrmMach3Milling.btn_caddraw.Click += clickCommandMainMenuButton;
			clsItem.FrmMach3Milling.btn_shape.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_library.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_contour.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_engraving.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_slices.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_profiling.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_profilecurve.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_drill.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_text.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_OPMenu.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_saveOP.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_openOP.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_move.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_rotate.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_mirror.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_scale.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_alignments.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_copy.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_copymulti.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_offset.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_eventdelete.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmRotate.btn_eventRotateminus.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmRotate.btn_eventrotateplus.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmovedown.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmoveleft.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmoveright.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmoveup.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_setangle2.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_slatadd.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_collopseadd.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_extend.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_break.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_vacuum.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_cadoutside.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_cadinside.Click += clickCommandsDrawing;
			clsItem.FrmMach3Milling.btn_gcodes.Click += clsAppMarbleVars.cmdMarble.clickCommandsView;
			clsItem.FrmMach3Milling.btn_view.Click += clsAppMarbleVars.cmdMarble.clickCommandsView;
			clsItem.FrmMach3Milling.btn_commands.Click += clsAppMarbleVars.cmdMarble.clickCommandsView;
			clsItem.FrmMach3Milling.btn_reset.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_start.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_stop.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_pause.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_water.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_laser.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_homing.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_park.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_vagonpark.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_sawpark.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_spindlepark.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_spindleheadpark.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_photopos.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_codecreate.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_partzero.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_A0.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_A45.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_A90.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_c180.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_c270.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_c90.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_c0.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_gozero.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_crousecontrol.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_rtcp.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_cameraclose.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_cameraopen.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_open.Click += clickCommands;
			if (clsAppMarbleItems.frmGantryMoveV1 != null)
			{
				clsAppMarbleItems.frmGantryMoveV1.btn_disableallgantry.Click += clickCommands;
				clsAppMarbleItems.frmGantryMoveV1.btn_disabley2gantry.Click += clickCommands;
				clsAppMarbleItems.frmGantryMoveV1.btn_enableallgantry.Click += clickCommands;
				clsAppMarbleItems.frmGantryMoveV1.btn_enabley2gantry.Click += clickCommands;
				clsAppMarbleItems.frmGantryMoveV1.btn_stopgantry.Click += clickCommands;
				clsAppMarbleItems.frmGantryMoveV1.btn_gantrydisable.Click += clickCommands;
				clsAppMarbleItems.frmGantryMoveV1.btn_gantryenable.Click += clickCommands;
			}
			clsAppMarbleItems.frmSpeedsV1.track_sawspeed.ValueChanged += trackValueChanged;
			clsAppMarbleItems.frmSpeedsV1.track_Spindlespeed.ValueChanged += trackValueChanged;
			clsAppMarbleItems.frmSpeedsV1.track_operationspeed.ValueChanged += trackValueChanged;
			clsAppMarbleItems.frmSpeedsV1.track_quickspeed.ValueChanged += trackValueChanged;
			clsItem.FrmMach3Milling.btn_pensopenclose.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach3Milling.btn_spindlepistondown.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach3Milling.btn_spindlepistonup.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach3Milling.btn_toolmagazineopen.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach3Milling.btn_toolmagazineClose.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmKinematic.btn_openkinematic.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmKinematic.btn_savekinemtic.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMach3Milling.btn_tool.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_kinematic.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach3Milling.chk_absolute.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach3Milling.chk_incremental.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach3Milling.chk_addsawthickness.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach3Milling.spn_go.ValueChanged += spinValueChanged;
			clsItem.FrmMach3Milling.btn_xplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_yplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_zplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_aplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_cplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_xminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_yminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_zminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_aminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_cminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach3Milling.btn_xplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_yplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_zplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_aplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_cplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_xminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_yminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_zminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_aminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_cminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach3Milling.btn_xplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_yplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_zplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_aplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_cplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_xminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_yminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_zminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_aminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_cminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach3Milling.btn_stopmanuel.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_preset.Click += clickCommandsMenuAndSettings;
			clsAppMarbleItems.frmSpeedsV1.btn_saw.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_spindle.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_sawminus.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_sawplus.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_spindleminus.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_spindleplus.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_toolsawset.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset.Click += clickCommands;
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_vacuumdown.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_vacuumup.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_vacuumopen.Click += clickCommands;
			clsItem.FrmMach3Milling.btn_vacuumclose.Click += clickCommands;
			clsItem.FrmMach3Milling.KeyDown += FormKeyDown;
			clsAppMarbleItems.frmMove.spn_eventmovevalue.ValueChanged += spinValueChanged;
			clsAppMarbleItems.frmRotate.spn_eventrotatevalue.ValueChanged += spinValueChanged;
			clsItem.FrmMach3Milling.buTab_Main.SelectedIndexChanged += buTabSelectedIndexChanged;
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
			clsItem.FrmMach3Milling.pnl_mainviewport.Controls.Add(buEyeItems.viewportCNC);
			clsInit.appMarble.ViewportCadCamInit();
			buEyeItems.viewportCadCam.ActiveViewport.Rotate.Enabled = buMarbleCalc.varMarbleRunSettings.RotateCameraCadCam;
			buVector5.baseModel = buEyeItems.viewportCadCam;
			clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelRotate;
			clsAppMarbleItems.frmMove.spn_eventmovevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelMove;
			clsItem.FrmMach3Milling.chk_incremental.Check = clsAppMarbleVars.varInterface.IncrementalMode;
			clsItem.FrmMach3Milling.chk_absolute.Check = clsAppMarbleVars.varInterface.AbsoluteMode;
			clsItem.FrmMach3Milling.chk_addsawthickness.Check = clsAppMarbleVars.varInterface.AddSawThicknessToMove;
			clsItem.FrmMach3Milling.spn_go.Value = clsAppMarbleVars.varInterface.JogMoveValue;
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
			buMarbleCalc.activeToolSaw.Geometry.Diameter = 350.0;
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
				clsItem.FrmMach3Milling.btn_homing = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
				clsItem.FrmMach3Milling.btn_homing.ForceSelected = false;
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
				clsAppMarbleVars.cMachine.bWriteAppParameter = true;
				clsAppMarbleVars.cMachine.bWriteToolParameter = true;
				clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
				clsAppMarbleVars.cMachine.bWriteParkParameters = true;
				KinematicBase copyKinematic = new KinematicBase();
				KinematicBase5.Copy(clsMarble.activeKinematic, ref copyKinematic);
				clsAppMarbleVars.cMachine.Commands.WriteKinematicData(CodesysMachine.RootPersistentString + "Kinematic.", copyKinematic);
			}
			clsAppMarbleVars.cmdMarble.ToolUpdateOnScreen();
			clsInit.appCommand.cmdViewZoomFit();
			clsItem.FrmMach3Milling.WindowState = FormWindowState.Maximized;
			clsAppMarbleItems.frmMain = clsItem.FrmMach3Milling;
			buCadCamResVer5.clsItem.FrmMain = clsItem.FrmMach3Milling;
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

	public void AssingControls()
	{
		string text = "AssingControls";
		try
		{
			buLogMarbleVer5.addToLogList(sClass, text, "Started");
			clsAppMarbleControls.lblMachine = clsAppMarbleItems.frmCoordsV1.lbl_machine;
			clsAppMarbleControls.lblMachineX = clsAppMarbleItems.frmCoordsV1.lbl_machinex;
			clsAppMarbleControls.lblMachineY = clsAppMarbleItems.frmCoordsV1.lbl_machiney;
			clsAppMarbleControls.lblMachineZ = clsAppMarbleItems.frmCoordsV1.lbl_machinez;
			clsAppMarbleControls.lblMachineA = clsAppMarbleItems.frmCoordsV1.lbl_machinea;
			clsAppMarbleControls.lblMachineC = clsAppMarbleItems.frmCoordsV1.lbl_machinec;
			clsAppMarbleControls.lblPart = clsAppMarbleItems.frmCoordsV1.lbl_part;
			clsAppMarbleControls.lblPartX = clsAppMarbleItems.frmCoordsV1.lbl_partx;
			clsAppMarbleControls.lblPartY = clsAppMarbleItems.frmCoordsV1.lbl_party;
			clsAppMarbleControls.lblPartZ = clsAppMarbleItems.frmCoordsV1.lbl_partz;
			clsAppMarbleControls.lblPartA = clsAppMarbleItems.frmCoordsV1.lbl_parta;
			clsAppMarbleControls.lblPartC = clsAppMarbleItems.frmCoordsV1.lbl_partc;
			clsAppMarbleControls.lblStatus = clsItem.FrmMach3Milling.lbl_status;
			clsAppMarbleControls.lblWarning = clsItem.FrmMach3Milling.lbl_warning;
			clsAppMarbleControls.btnInformation = clsItem.FrmMach3Milling.btn_information;
			clsAppMarbleControls.IC32 = clsItem.FrmMach3Milling.IC32;
			buLogMarbleVer5.addToLogList(sClass, text, "Finished");
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, "", 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void AddControls()
	{
		string text = "AddControls";
		try
		{
			buLogMarbleVer5.addToLogList(sClass, text, "Started");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmCoordsV1");
			clsAppMarbleItems.frmCoordsV1.pnl_base.Left = 4;
			clsAppMarbleItems.frmCoordsV1.pnl_base.Top = clsItem.FrmMach3Milling.pic_imagecompany.Top + clsItem.FrmMach3Milling.pic_imagecompany.Height + 2;
			clsAppMarbleItems.frmCoordsV1.pnl_base.Display.BackColor = Color.Transparent;
			clsAppMarbleItems.frmCoordsV1.pnl_base.Display.Border.Visible = false;
			clsItem.FrmMach3Milling.pnl_left.Controls.Add(clsAppMarbleItems.frmCoordsV1.pnl_base);
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmCoordinates");
			buSeparator buSeparator2 = new buSeparator();
			buSeparator2.Display.BackColor = Color.Black;
			buSeparator2.Display.GradientType = GradientMode.Solid;
			buSeparator2.Size = new Size(clsItem.FrmMach3Milling.pnl_left.Width + 2, 2);
			buSeparator2.Location = new System.Drawing.Point(-1, clsAppMarbleItems.frmCoordsV1.pnl_base.Top + clsAppMarbleItems.frmCoordsV1.pnl_base.Height + 2);
			clsItem.FrmMach3Milling.pnl_left.Controls.Add(buSeparator2);
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmSpeedsV1");
			clsAppMarbleItems.frmSpeedsV1.pnl_base.Left = 4;
			clsAppMarbleItems.frmSpeedsV1.pnl_base.Top = buSeparator2.Top + buSeparator2.Height + 2;
			clsAppMarbleItems.frmSpeedsV1.pnl_base.Display.BackColor = Color.Transparent;
			clsAppMarbleItems.frmSpeedsV1.pnl_base.Display.Border.Visible = false;
			clsItem.FrmMach3Milling.pnl_left.Controls.Add(clsAppMarbleItems.frmSpeedsV1.pnl_base);
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmSpeedsV1");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmJobOPListV2");
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Left = 0;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Top = 42;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.BackColor = Color.Transparent;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.Border.Visible = false;
			clsItem.FrmMach3Milling.pnl_drawingjob.Controls.Add(clsAppMarbleItems.frmJobOPListV2.pnl_base);
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
		clsItem.FrmMach3Milling.lbl_datetime.Text = " " + DateTime.Now.Date.ToShortDateString() + " - " + DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + ":" + DateTime.Now.Second.ToString("D2") + "   ";
		if (clsAppMarbleVars.cMachine.miscVar.cntGeneralTick % 150 == 0 && AppBool.SaveByTick)
		{
			clsInit.appMarble.SaveMarbleFile();
			AppBool.SaveByTick = false;
		}
		if (!Inited)
		{
			return;
		}
		if (!AppBool.IsFirstRun)
		{
			clsItem.FrmMach3Milling.btn_water = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach3Milling.btn_homing = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach3Milling.btn_laser = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach3Milling.btn_start = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach3Milling.btn_pause = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach3Milling.btn_crousecontrol = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsItem.FrmMach3Milling.btn_rtcp = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_rtcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: false, "AppRun.SawActivated");
			clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, "AppRun.MillingActivated");
			clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: false, "AppRun.MillingHeadActivated");
			clsAppMarbleVars.cmdMarble.ToolSelect(MarbleToolType.Milling);
			if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0)
			{
				clsAppMarbleItems.frmSpeedsV1.btn_toolsawset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolsawset, State: true, buEyeVars.parVisual.colorLinearGradientEnableDisable);
				clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
				clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			}
			else if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1)
			{
				clsAppMarbleItems.frmSpeedsV1.btn_toolsawset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolsawset, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
				clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset, State: true, buEyeVars.parVisual.colorLinearGradientEnableDisable);
				clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			}
			else if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2)
			{
				clsAppMarbleItems.frmSpeedsV1.btn_toolsawset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolsawset, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
				clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
				clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset, State: true, buEyeVars.parVisual.colorLinearGradientEnableDisable);
			}
			AppBool.IsFirstRun = true;
		}
		clsAppMarbleVars.cmdMarble.GeneralTick();
		if (AppBool.Offline)
		{
			clsItem.FrmMach3Milling.lbl_warning.Visible = false;
			clsItem.FrmMach3Milling.lbl_warning.Text = buLangTranslate.preMotionWarning.SystemOffline;
		}
		clsItem.timGeneral.Enabled = false;
		if (clsAppMarbleVars.cMachine.bParameterWriting)
		{
			clsItem.FrmMach3Milling.lbl_warning.Text = buLangTranslate.preMotionWarning.ParameterWriting;
			clsItem.FrmMach3Milling.lbl_warning.Visible = clsAppMarbleVars.cMachine.bParameterWriting;
		}
		if (clsAppMarbleVars.cMachine.preVar.ParWriting & !clsAppMarbleVars.cMachine.bParameterWriting)
		{
			clsItem.FrmMach3Milling.lbl_warning.Text = "";
			clsItem.FrmMach3Milling.lbl_warning.Visible = false;
		}
		clsAppMarbleVars.cMachine.preVar.ParWriting = clsAppMarbleVars.cMachine.bParameterWriting;
		if (!clsItem.FrmMach3Milling.btn_homing.ForceSelected & clsAppMarbleVars.cMachine.runSystem.HomingDone)
		{
			clsItem.FrmMach3Milling.btn_homing.ForceSelected = true;
			clsItem.FrmMach3Milling.btn_homing = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach3Milling.btn_homing.ForceSelected = !clsAppMarbleVars.cMachine.runSystem.HomingDone)
		{
			clsItem.FrmMach3Milling.btn_homing.ForceSelected = false;
			clsItem.FrmMach3Milling.btn_homing = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach3Milling.btn_water.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Water)
		{
			clsItem.FrmMach3Milling.btn_water.ForceSelected = true;
			clsItem.FrmMach3Milling.btn_water = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach3Milling.btn_water.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Water)
		{
			clsItem.FrmMach3Milling.btn_water.ForceSelected = false;
			clsItem.FrmMach3Milling.btn_water = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach3Milling.btn_laser.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Laser)
		{
			clsItem.FrmMach3Milling.btn_laser.ForceSelected = true;
			clsItem.FrmMach3Milling.btn_laser = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach3Milling.btn_laser.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Laser)
		{
			clsItem.FrmMach3Milling.btn_laser.ForceSelected = false;
			clsItem.FrmMach3Milling.btn_laser = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach3Milling.btn_start.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Run)
		{
			clsItem.FrmMach3Milling.btn_start.ForceSelected = true;
			clsItem.FrmMach3Milling.btn_start = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach3Milling.btn_start.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Run)
		{
			clsItem.FrmMach3Milling.btn_start.ForceSelected = false;
			clsItem.FrmMach3Milling.btn_start = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach3Milling.btn_pause.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Pause)
		{
			clsItem.FrmMach3Milling.btn_pause.ForceSelected = true;
			clsItem.FrmMach3Milling.btn_pause = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach3Milling.btn_pause.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Pause)
		{
			clsItem.FrmMach3Milling.btn_pause.ForceSelected = false;
			clsItem.FrmMach3Milling.btn_pause = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach3Milling.btn_crousecontrol.ForceSelected & clsAppMarbleVars.cMachine.runSystem.CruiseControl)
		{
			clsItem.FrmMach3Milling.btn_crousecontrol.ForceSelected = true;
			clsItem.FrmMach3Milling.btn_crousecontrol = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach3Milling.btn_crousecontrol.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.CruiseControl)
		{
			clsItem.FrmMach3Milling.btn_crousecontrol.ForceSelected = false;
			clsItem.FrmMach3Milling.btn_crousecontrol = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsItem.FrmMach3Milling.btn_rtcp.ForceSelected & clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
		{
			clsItem.FrmMach3Milling.btn_rtcp.ForceSelected = true;
			clsItem.FrmMach3Milling.btn_rtcp = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_rtcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsItem.FrmMach3Milling.btn_rtcp.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
		{
			clsItem.FrmMach3Milling.btn_rtcp.ForceSelected = false;
			clsItem.FrmMach3Milling.btn_rtcp = buControlCommands.ColorButtonLinearFromEnable(clsItem.FrmMach3Milling.btn_rtcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsAppMarbleItems.frmSpeedsV1.btn_toolsawset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0))
		{
			clsAppMarbleItems.frmSpeedsV1.btn_toolsawset.ForceSelected = true;
			clsAppMarbleItems.frmSpeedsV1.btn_toolsawset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolsawset, State: true, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsAppMarbleItems.frmSpeedsV1.btn_toolsawset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType != 0))
		{
			clsAppMarbleItems.frmSpeedsV1.btn_toolsawset.ForceSelected = false;
			clsAppMarbleItems.frmSpeedsV1.btn_toolsawset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolsawset, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1))
		{
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset.ForceSelected = true;
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset, State: true, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType != 1))
		{
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset.ForceSelected = false;
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinset, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		if (!clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2))
		{
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset.ForceSelected = true;
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset, State: true, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		else if (clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType != 2))
		{
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset.ForceSelected = false;
			clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset = buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_toolmillinheadset, State: false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
		}
		clsItem.FrmMach3Milling.chk_connected.Check = AppBool.Connected;
		clsItem.FrmMach3Milling.chk_inited.Check = clsAppMarbleVars.cMachine.runSystem.InitDone;
		clsItem.FrmMach3Milling.chk_home.Check = clsAppMarbleVars.cMachine.runSystem.HomingDone;
		clsItem.FrmMach3Milling.chk_run.Check = clsAppMarbleVars.cMachine.runSystem.Run;
		clsItem.FrmMach3Milling.chk_rtcp.Check = clsAppMarbleVars.cMachine.runSystem.RtcpActivated;
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
			clsItem.FrmMach3Milling.lbl_warning.Text = "";
			clsItem.FrmMach3Milling.lbl_warning.Visible = false;
		}
		if (marbleHMICommands == MarbleHMICommands.StatusUpdate)
		{
			clsItem.FrmMach3Milling.lbl_status.Text = (string)Data2;
			clsItem.FrmMach3Milling.lbl_status.Display.BackColor = (Color)Data3;
		}
		if (marbleHMICommands == MarbleHMICommands.SaveCNCParameter)
		{
			SaveParameter();
		}
		if (marbleHMICommands == MarbleHMICommands.SaveCamParameter)
		{
			Task.Run(delegate
			{
				clsInit.appMarble.SaveMarbleFile(AppPath.MachineSettings);
			});
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
			if (control.Name == clsItem.FrmMach3Milling.btn_gozero.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.GoPartZero);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_crousecontrol.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CrouseControl);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_rtcp.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.RTCP);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_partzero.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.PartZero);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_open.Name)
			{
				clsInit.appMarble.activeJob.Items.Clear();
				clsInit.appMarble.cmdExternalGCode();
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CodeCreate);
				Thread.Sleep(500);
				string localFilePath = AppPath.Base + "\\GCode.cnc";
				if (XinjeFTP.UploadCncFile(localFilePath, "CncFile.cnc"))
				{
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, "sysRun.boolData.bFileLoaded");
				}
				else
				{
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: false, "sysRun.boolData.bFileLoaded");
				}
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_codecreate.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CodeCreate);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_c0.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C0);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_c90.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_c180.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C180);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_c270.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90Minus);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_A0.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A0);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_A45.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A45);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_A90.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A90);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_spindlepistondown.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonDown);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_spindlepistonup.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonUp);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_homing.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Homing);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_water.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Water);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_laser.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Laser);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_park.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Park);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_vagonpark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.WagonPark);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_spindlepark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePark);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_sawpark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawPark);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_spindleheadpark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleHeadPark);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_photopos.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraPark);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_reset.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Reset);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_start.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Start);
			}
			if ((control.Name == clsItem.FrmMach3Milling.btn_stop.Name) | (control.Name == clsItem.FrmMach3Milling.btn_stopmanuel.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_pause.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Pause);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_cameraopen.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverOpen);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_cameraclose.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverClose);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_vacuumup.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumUp);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_vacuumdown.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumDown);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_vacuumopen.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumSuctionEnable);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_vacuumclose.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumSuctionDisable);
			}
			if (clsAppMarbleItems.frmGantryMoveV1 != null)
			{
				if (control.Name == clsAppMarbleItems.frmGantryMoveV1.btn_disabley2gantry.Name)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Y2Disable);
				}
				if (control.Name == clsAppMarbleItems.frmGantryMoveV1.btn_enabley2gantry.Name)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Y2Enable);
				}
				if (control.Name == clsAppMarbleItems.frmGantryMoveV1.btn_disableallgantry.Name)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.DisableAll);
				}
				if (control.Name == clsAppMarbleItems.frmGantryMoveV1.btn_enableallgantry.Name)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.EnableAll);
				}
				if (control.Name == clsAppMarbleItems.frmGantryMoveV1.btn_gantrydisable.Name)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.GantryDisable);
				}
				if (control.Name == clsAppMarbleItems.frmGantryMoveV1.btn_gantryenable.Name)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.GantryEnable);
				}
				if (control.Name == clsAppMarbleItems.frmGantryMoveV1.btn_stopgantry.Name)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
				}
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
			if (control.Name == clsItem.FrmMach3Milling.btn_main.Name)
			{
				clsAppMarbleVars.varRuntime.OnlineSimulationAllow = true;
				clsAppMarbleVars.varRuntime.isMainTab = true;
				clsItem.FrmMach3Milling.buTab_Main.SelectedIndex = 0;
				MenuButtonColors(0);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_manuel.Name)
			{
				clsAppMarbleVars.varRuntime.OnlineSimulationAllow = true;
				clsAppMarbleVars.varRuntime.isMainTab = true;
				clsItem.FrmMach3Milling.buTab_Main.SelectedIndex = 1;
				MenuButtonColors(1);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_drawing.Name)
			{
				clsAppMarbleVars.varRuntime.OnlineSimulationAllow = false;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach3Milling.buTab_Main.SelectedIndex = 2;
				MenuButtonColors(2);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_drawmode.Name)
			{
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Operation;
				clsItem.FrmMach3Milling.buTab_drawing.SelectedIndex = 0;
				MenuDrawButtonColors(0);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_eventmode.Name)
			{
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Event;
				clsItem.FrmMach3Milling.buTab_drawing.SelectedIndex = 1;
				MenuDrawButtonColors(1);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: true, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_functionsmode.Name)
			{
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Function;
				clsItem.FrmMach3Milling.buTab_drawing.SelectedIndex = 2;
				MenuDrawButtonColors(2);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: true, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_caddraw.Name)
			{
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.CadDraw;
				clsItem.FrmMach3Milling.buTab_drawing.SelectedIndex = 3;
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
			if (control.Name == clsItem.FrmMach3Milling.btn_OPMenu.Name)
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
					clickCommandsDrawing(clsItem.FrmMach3Milling.btn_contour, null);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Shape)
				{
					clickCommandsDrawing(clsItem.FrmMach3Milling.btn_shape, null);
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
					clsInit.appMarble.cmd3DFileAdd();
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
			if (control.Name == clsItem.FrmMach3Milling.btn_shape.Name)
			{
				clsInit.appMarble.cmdShapeMenu();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_contour.Name)
			{
				clsInit.appMarble.cmdContourMenu();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_profiling.Name)
			{
				clsInit.appMarble.cmdProfileMenu();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_profilecurve.Name)
			{
				clsInit.appMarble.cmdProfileCurveMenu();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_engraving.Name)
			{
				clsInit.appMarble.cmd3DFileAdd();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_drill.Name)
			{
				clsInit.appMarble.cmdDrillMenu();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_library.Name)
			{
				clsInit.appMarble.cmdLibraryMenu();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_text.Name)
			{
				clsInit.appMarble.cmdTextMenu();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_slices.Name)
			{
				clsInit.appMarble.cmdSlicing();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_cadoutside.Name)
			{
				List<buEntity> refEntities = new List<buEntity>();
				DialogResult dialogResult = clsInit.appMarble.cmdCadDrawMenu(ref refEntities);
				if (dialogResult == DialogResult.OK)
				{
					clsInit.appMarble.cmdCadDrawOutside(refEntities);
				}
				refEntities.Clear();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_cadinside.Name)
			{
				List<buEntity> refEntities2 = new List<buEntity>();
				DialogResult dialogResult2 = clsInit.appMarble.cmdCadDrawMenu(ref refEntities2);
				if (dialogResult2 == DialogResult.OK)
				{
					clsInit.appMarble.cmdCadDrawInside(refEntities2);
				}
				refEntities2.Clear();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_move.Name && clsAppMarbleItems.frmMove != null)
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
			if (control.Name == clsItem.FrmMach3Milling.btn_rotate.Name)
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
			if (control.Name == clsItem.FrmMach3Milling.btn_mirror.Name)
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
			if (control.Name == clsItem.FrmMach3Milling.btn_scale.Name)
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
			if (control.Name == clsItem.FrmMach3Milling.btn_copy.Name)
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
			if (control.Name == clsItem.FrmMach3Milling.btn_copymulti.Name)
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
			if (control.Name == clsItem.FrmMach3Milling.btn_alignments.Name && buMarbleForms.frmEventAling != null)
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
			if (control.Name == clsItem.FrmMach3Milling.btn_setangle2.Name)
			{
				clsInit.appMarble.doSetAngle();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_slatadd.Name)
			{
				clsInit.appMarble.doSlatAdd(null);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_collopseadd.Name)
			{
				clsInit.appMarble.doCollopseAdd(null);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_extend.Name)
			{
				clsInit.appMarble.doExtend();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_break.Name)
			{
				clsInit.appMarble.doBreak();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_offset.Name)
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
			if (control.Name == clsItem.FrmMach3Milling.btn_eventdelete.Name && !clsInit.appMarble.MoveCreatedEntity)
			{
				clsInit.appMarble.doDeleteItems(All: false, -1);
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_vacuum.Name)
			{
				clsInit.appMarble.cmdVacuum();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_saveOP.Name)
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
			if (control.Name == clsItem.FrmMach3Milling.btn_openOP.Name)
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
			if (control.Name == clsItem.FrmMenu.btn_selectmaterial.Name)
			{
				clsInit.cMarble.ShowMaterialPage();
				clsInit.appMarble.SaveMarbleFile();
			}
			if (control.Name == clsItem.FrmMenu.btn_tools.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowToolsList(buMarbleCalc.varMarbleSettings.ToolListMode, MarbleToolType.Saw);
			}
			if (control.Name == clsItem.FrmMenu.btn_g54offset.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowG54List();
			}
			if (control.Name == clsItem.FrmMenu.btn_password.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowPassword();
			}
			if (control.Name == clsItem.FrmMenu.btn_calculations.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCalculations();
			}
			if (control.Name == clsItem.FrmMenu.btn_report.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowReport();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_test.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowTest();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_simulationpanel.Name)
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
			if (control.Name == clsItem.FrmMenu.btn_maintanance.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMaintanance();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_warmup.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowWarmUp();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_materialmeasurement.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMaterialMeasure();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_closepc.Name && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWanttoClosePC) == DialogResult.Yes)
			{
				clsAppMarbleVars.cmdMarble.cmdClosePC();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_marblecamsettings.Name)
			{
				clsInit.appMarble.cmdCamSettingsPage();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_millingsettings.Name)
			{
				clsInit.appMarble.cmdSettingsMilling2D(MarbleCamType.MillingContour2D);
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_programsettings.Name)
			{
				clsInit.appMarble.cmdSettingProgram();
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
				clsAppMarbleVars.cmdMarble.ShowMachineSettingsV2(0);
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
			if (control.Name == clsItem.FrmMenuSettings.btn_cameracalibration.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCameraCalibration();
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
			if (control.Name == clsItem.FrmMenuSettings.btn_axesgain.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowAxesGain();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_GantryPage.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowGantryMove();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_machinedefination.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMachineDefinationSettings();
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_techniciandefine.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowTechnicianDefine();
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_userdefine.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowUserDefine();
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_watch.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowWatch();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_counters.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCounters();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_debug.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowDebug();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_language.Name)
			{
				if (AppSecurity.PasswordLevel < 2)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentences.PasswordLevelNotEnough);
					return;
				}
				clsAppMarbleVars.cmdMarble.ShowLanguageMenu();
				clsItem.FrmMach3Milling.LoadLanguage();
				clsItem.FrmMenu.LoadLanguage();
				clsItem.FrmMenuSettings.LoadLanguage();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_loadbackup.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowBackupLoad();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_userinterfacesettings.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowUserInterfaceSettings();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
				AppBool.VisualUpdateForce = true;
				UpdateVisualThings();
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_preset.Name)
			{
				if (clsAppMarbleVars.cmdMarble.ShowPreset(1050, clsItem.FrmMach3Milling.chk_addsawthickness.Top) == DialogResult.OK)
				{
					clsItem.FrmMach3Milling.spn_go.Value = buMarbleForms.frmPreset.ReturnVal;
				}
				return;
			}
			if (control.Name == clsItem.FrmMach3Milling.btn_information.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowInformation();
			}
			if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
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
				clsItem.FrmMach3Milling.lbl_viewportcoords.Text = "X: " + pntActive.X.ToString("f2") + " , Y: " + pntActive.Y.ToString("f2") + " , Z: " + pntActive.Z.ToString("f2");
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
			if (control.Name == clsItem.FrmMach3Milling.chk_incremental.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.IncrementalMode = clsItem.FrmMach3Milling.chk_incremental.Check;
				clsItem.FrmMach3Milling.chk_absolute.Check = false;
				clsAppMarbleVars.varInterface.AbsoluteMode = false;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach3Milling.chk_absolute.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.AbsoluteMode = clsItem.FrmMach3Milling.chk_absolute.Check;
				clsItem.FrmMach3Milling.chk_incremental.Check = false;
				clsAppMarbleVars.varInterface.IncrementalMode = false;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach3Milling.chk_addsawthickness.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.AddSawThicknessToMove = clsItem.FrmMach3Milling.chk_addsawthickness.Check;
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
			if (control.Name == clsItem.FrmMach3Milling.spn_go.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.JogMoveValue = clsItem.FrmMach3Milling.spn_go.Value;
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
		if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
		{
			buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
			if (clsItem.FrmMach3Milling.buTab_Main.SelectedIndex == 6 && AppBool.Connected)
			{
				clsAppMarbleVars.cmdMarble.WriteSemiAutoParameters();
			}
		}
	}

	private void spinLeave(object sender, EventArgs e)
	{
		if (clsItem.FrmMach3Milling.buTab_Main.SelectedIndex == 6 && AppBool.Connected)
		{
			clsAppMarbleVars.cmdMarble.WriteSemiAutoParameters();
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
		if (clsItem.FrmMach3Milling.buTab_Main.SelectedIndex == 0)
		{
			if (clsItem.FrmMach3Milling.pnl_mainviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach3Milling.pnl_manuelviewport.Controls.Count > 0)
				{
					clsItem.FrmMach3Milling.pnl_mainviewport.Controls.Add(clsItem.FrmMach3Milling.pnl_manuelviewport.Controls[0]);
				}
				buEyeItems.viewportCadCam.ZoomFit();
				buEyeItems.viewportCadCam.ZoomOut(10);
			}
			AppBool.EditMode = false;
		}
		else if (clsItem.FrmMach3Milling.buTab_Main.SelectedIndex == 1)
		{
			if (clsItem.FrmMach3Milling.pnl_manuelviewport.Controls.Count == 0 && clsItem.FrmMach3Milling.pnl_mainviewport.Controls.Count > 0)
			{
				clsItem.FrmMach3Milling.pnl_manuelviewport.Controls.Add(clsItem.FrmMach3Milling.pnl_mainviewport.Controls[0]);
			}
			AppBool.EditMode = false;
		}
		else if (clsItem.FrmMach3Milling.buTab_Main.SelectedIndex == 2)
		{
			clsInit.appMarble.DeleteSimulationEntities();
			AppBool.EditMode = true;
		}
		MarbleTempVars.LastSelectedTabPage = clsItem.FrmMach3Milling.buTab_Main.SelectedIndex;
	}

	public void FormKeyDown(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == clsItem.FrmMach3Milling.Name && e.KeyCode != Keys.Escape)
		{
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
			clsItem.FrmMach3Milling.buTab_Main.ItemSize = new Size(1, 1);
			clsItem.FrmMach3Milling.buTab_drawing.ItemSize = new Size(1, 1);
			clsItem.FrmMach3Milling.tabPage_Drawing.Text = "";
			clsItem.FrmMach3Milling.tabPage_Event.Text = "";
			clsItem.FrmMach3Milling.tabPage_Functions.Text = "";
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmCoordsV1");
			clsAppMarbleItems.frmCoordsV1.Init();
			clsAppMarbleItems.frmCoordsV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmCoordsV1");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmSpeeds");
			clsAppMarbleItems.frmSpeedsV1.ShowSpindle = buMarbleCalc.varMarbleSettings.ShowSpindleTrack;
			clsAppMarbleItems.frmSpeedsV1.ShowSaw = buMarbleCalc.varMarbleSettings.ShowSawTrack;
			clsAppMarbleItems.frmSpeedsV1.Init();
			clsAppMarbleItems.frmSpeedsV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmSpeeds");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmViewV1");
			clsAppMarbleItems.frmViewsV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmViewV1");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmViewGCodeV1");
			clsAppMarbleItems.frmGCodeViewV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmViewGCodeV1");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmJobOPListV2");
			clsAppMarbleItems.frmJobOPListV2.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmJobOPListV2");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmCommandsV1");
			clsAppMarbleItems.frmCommandsV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmCommandsV1");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmStartLine");
			clsAppMarbleItems.frmStartLine.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmStartLine");
			if (buEyeVars.parVisual != null)
			{
				FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
				if (fileInfo.Exists)
				{
					Control.ControlCollection controlCollection = null;
					controlCollection = clsItem.FrmMach3Milling.pnl_maincmd.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					controlCollection = clsItem.FrmMach3Milling.buGround1.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
				}
				clsItem.FrmMach3Milling.btn_contour.Visible = clsVar.UserMode.MarbleMode.FileImport;
				clsItem.FrmMach3Milling.btn_library.Visible = clsVar.UserMode.MarbleMode.Library;
				clsItem.FrmMach3Milling.btn_profiling.Visible = clsVar.UserMode.MarbleMode.Profile;
				clsItem.FrmMach3Milling.btn_profilecurve.Visible = clsVar.UserMode.MarbleMode.Profile;
				clsItem.FrmMach3Milling.btn_drill.Visible = clsVar.UserMode.MarbleMode.Hole;
				clsItem.FrmMach3Milling.btn_engraving.Visible = clsVar.UserMode.MarbleMode.Engraving3Axis;
				clsItem.FrmMach3Milling.btn_text.Visible = clsVar.UserMode.MarbleMode.Text;
				clsItem.FrmMach3Milling.btn_slices.Visible = clsVar.UserMode.MarbleMode.FileImport;
				clsItem.FrmMach3Milling.btn_OPMenu.Visible = clsVar.UserMode.MarbleMode.OPMenu;
				buLogMarbleVer5.addToLogList(sClass, text, "Finished");
				buLogMarbleVer5.saveLogList();
			}
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, "", 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controls = clsItem.FrmMach3Milling.buGround1.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			clsItem.FrmMach3Milling.btn_main.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_main.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_main.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_main.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_main.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_main.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 1)
		{
			clsItem.FrmMach3Milling.btn_manuel.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_manuel.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_manuel.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_manuel.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_manuel.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_manuel.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 2)
		{
			clsItem.FrmMach3Milling.btn_drawing.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawing.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawing.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawing.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawing.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawing.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
		}
	}

	public void MenuDrawButtonColors(int PageIndex)
	{
		Control.ControlCollection controls = clsItem.FrmMach3Milling.pnl_drawing.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			clsItem.FrmMach3Milling.btn_drawmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawmode.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawmode.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawmode.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_drawmode.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 1)
		{
			clsItem.FrmMach3Milling.btn_eventmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_eventmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_eventmode.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_eventmode.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_eventmode.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_eventmode.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 2)
		{
			clsItem.FrmMach3Milling.btn_functionsmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_functionsmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_functionsmode.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_functionsmode.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_functionsmode.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_functionsmode.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 3)
		{
			clsItem.FrmMach3Milling.btn_caddraw.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_caddraw.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_caddraw.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_caddraw.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_caddraw.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			clsItem.FrmMach3Milling.btn_caddraw.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
	}

	public void OpenParameter()
	{
		try
		{
			if (cMarbleVars == null)
			{
				cMarbleVars = new clsAppMarbleVars();
			}
			cMarbleVars.Init();
			clsAppMarbleVars.cmdMarble.OpenParameter();
		}
		catch (Exception)
		{
		}
	}

	public void SaveParameter()
	{
		try
		{
			clsAppMarbleVars.cmdMarble.SaveParameter();
		}
		catch (Exception)
		{
		}
	}

	public void MainControlsToParameter(bool FromControlToValues)
	{
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
				clsItem.FrmMach3Milling.lbl_viewportcoords.Text = "X: " + Data.pntMove.X.ToString("f2") + " , Y: " + Data.pntMove.Y.ToString("f2") + " , Z: " + Data.pntMove.Z.ToString("f2");
			}
			break;
		}
	}

	public void ShowWarning(string Message, Color clr)
	{
		clsItem.FrmMach3Milling.lbl_warning.Visible = true;
		clsItem.FrmMach3Milling.lbl_warning.Text = Message;
		clsItem.FrmMach3Milling.lbl_warning.BackColor = clr;
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
		clsItem.FrmMenu.ShowDialog(clsItem.FrmMach3Milling);
	}

	public void showSettingsPage(object sender, EventArgs e)
	{
		clsItem.FrmMenuSettings.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmMenuSettings.LoadLanguage();
		clsItem.FrmMenuSettings.ShowDialog(clsItem.FrmMach3Milling);
	}

	public void showAdminSettingsPage(object sender, EventArgs e)
	{
		clsItem.FrmMenuAdminSettings.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmMenuAdminSettings.LoadLanguage();
		clsItem.FrmMenuAdminSettings.ShowDialog(clsItem.FrmMach2);
	}

	public void ThreadLoop()
	{
		while (clsAppMarbleVars.cMachine.miscVar.ThreadEnable)
		{
			bool flag = true;
			if (clsAppMarbleVars.cMachine.PLCSettings.ThreadWaitCount > 0)
			{
				if (clsAppMarbleVars.cMachine.miscVar.ThreadCount < clsAppMarbleVars.cMachine.PLCSettings.ThreadWaitCount)
				{
					flag = false;
				}
				else
				{
					clsAppMarbleVars.cMachine.miscVar.ThreadCount = 0;
					flag = true;
				}
			}
			clsAppMarbleVars.cMachine.miscVar.ThreadCount++;
			if (!((AppBool.Inited & AppBool.Connected) && flag))
			{
				continue;
			}
			if (AppBool.Inited)
			{
				if ((clsAppMarbleVars.cMachine.miscVar.cntCommunication % 2 == 0) & AppBool.Inited)
				{
					ReadAxisDataBits readAxisDataBits = new ReadAxisDataBits(position: true, offsetedPosition: true, enabled: true, !buMarbleCalc.varMarbleMachineSettings.OptionSettings.AllAbsoluteEncoder);
					if ((clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.DistanceToGo) | (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.DistanceToGo))
					{
						readAxisDataBits.DistanceToGo = true;
					}
					if ((clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.Speed) | (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.Speed))
					{
						readAxisDataBits.Velocity = true;
					}
					if ((clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.FollowingError) | (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.FollowingError))
					{
						readAxisDataBits.FollowingError = true;
					}
					clsAppMarbleVars.cMachine.Commands.ReadAxisGroup(readAxisDataBits, ref clsAppMarbleVars.cMachine.AppAxis);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualOffsetedPosition = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition;
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualOffsetedPosition = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition;
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
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.ParameterUpdate);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = false;
			}
			if (clsAppMarbleVars.cMachine.bWriteG54Parameter)
			{
				clsAppMarbleVars.cMachine.bParameterWriting = true;
				clsAppMarbleVars.cmdMarble.WriteG54();
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CNCParameterUpdate);
				clsAppMarbleVars.cMachine.bWriteG54Parameter = false;
			}
			if (clsAppMarbleVars.cMachine.bWriteAlarmActionParameters)
			{
				clsAppMarbleVars.cMachine.bParameterWriting = true;
				clsAppMarbleVars.cmdMarble.WriteAlarmAction();
				clsAppMarbleVars.cMachine.bWriteAlarmActionParameters = false;
			}
			if (clsAppMarbleVars.cMachine.bWriteToolParameter)
			{
				clsAppMarbleVars.cMachine.bParameterWriting = true;
				clsAppMarbleVars.cmdMarble.WriteToolParameter(MillingHead: true);
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CNCParameterUpdate);
				clsAppMarbleVars.cMachine.bWriteToolParameter = false;
			}
			if (clsAppMarbleVars.cMachine.bWriteAppParameter)
			{
				clsAppMarbleVars.cMachine.bParameterWriting = true;
				clsAppMarbleVars.cmdMarble.WriteAppParameter();
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CNCParameterUpdate);
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
