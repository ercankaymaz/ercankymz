// Decompiled with JetBrains decompiler
// Type: MarbleCNC.Machines.clsMachine3_10AxisDoubleHead
// Assembly: CMDMarbleCNC, Version=3.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 99805DCC-380E-4FBC-B708-84554BBCD25B
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\CMDMarbleCNC.exe

using buCadCamResVer5;
using buCadCamResVer5.Marble;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Marble;
using buHandler;
using buMarble;
using buMotion;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable disable
namespace MarbleCNC.Machines;

public class clsMachine3_10AxisDoubleHead
{
  private Point3D pntActive = new Point3D();
  private Timer timPlcHandlerRelease = new Timer();
  private bool Inited = false;
  private string sClass = "clsMachine1_5Axis";
  private clsAppMarbleVars cMarbleVars = (clsAppMarbleVars) null;

  public void AppMarbleClassInit()
  {
    clsAppMarbleVars.cmdMarble.InitAxesString();
    if (this.cMarbleVars != null)
      return;
    this.cMarbleVars = new clsAppMarbleVars();
    this.cMarbleVars.Init();
  }

  public void SystemInit()
  {
    string str1 = nameof (SystemInit);
    try
    {
      this.AppMarbleClassInit();
      string str2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisXChar + "1";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strRuntimeVar = $"AxisRun{str2}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strSettingsVar = $"AxisSet{str2}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strRunExe = $"AxisRun{str2}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strRunBool = $"AxisRun{str2}.boolAX.";
      string str3 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisYChar + "1";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strRuntimeVar = $"AxisRun{str3}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strSettingsVar = $"AxisSet{str3}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strRunExe = $"AxisRun{str3}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strRunBool = $"AxisRun{str3}.boolAX.";
      string str4 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisZChar + "1";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strRuntimeVar = $"AxisRun{str4}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strSettingsVar = $"AxisSet{str4}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strRunExe = $"AxisRun{str4}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strRunBool = $"AxisRun{str4}.boolAX.";
      string str5 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisCChar + "1";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strRuntimeVar = $"AxisRun{str5}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strSettingsVar = $"AxisSet{str5}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strRunExe = $"AxisRun{str5}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strRunBool = $"AxisRun{str5}.boolAX.";
      string str6 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisAChar + "1";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strRuntimeVar = $"AxisRun{str6}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strSettingsVar = $"AxisSet{str6}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strRunExe = $"AxisRun{str6}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strRunBool = $"AxisRun{str6}.boolAX.";
      string str7 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisXChar + "2";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.Strings.strRuntimeVar = $"AxisRun{str7}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.Strings.strSettingsVar = $"AxisSet{str7}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.Strings.strRunExe = $"AxisRun{str7}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.Strings.strRunBool = $"AxisRun{str7}.boolAX.";
      string str8 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisYChar + "2";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strRuntimeVar = $"AxisRun{str8}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strSettingsVar = $"AxisSet{str8}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strRunExe = $"AxisRun{str8}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strRunBool = $"AxisRun{str8}.boolAX.";
      string str9 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisZChar + "2";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.Strings.strRuntimeVar = $"AxisRun{str9}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.Strings.strSettingsVar = $"AxisSet{str9}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.Strings.strRunExe = $"AxisRun{str9}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.Strings.strRunBool = $"AxisRun{str9}.boolAX.";
      string str10 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisCChar + "2";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.Strings.strRuntimeVar = $"AxisRun{str10}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.Strings.strSettingsVar = $"AxisSet{str10}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.Strings.strRunExe = $"AxisRun{str10}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.Strings.strRunBool = $"AxisRun{str10}.boolAX.";
      string str11 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisAChar + "2";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.Strings.strRuntimeVar = $"AxisRun{str11}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.Strings.strSettingsVar = $"AxisSet{str11}.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.Strings.strRunExe = $"AxisRun{str11}.exeAX.";
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.Strings.strRunBool = $"AxisRun{str11}.boolAX.";
      if (this.cMarbleVars == null)
      {
        this.cMarbleVars = new clsAppMarbleVars();
        this.cMarbleVars.Init();
      }
      MarbleCNC.clsItem.FrmMach1.lbl_warning.Height = 85;
      clsAppMarbleVars.cmdMarble.CommandHMI += new OkCommandWithFiveDataEventHandler(this.CommandHMI);
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
      buLogMarbleVer5.addToLogList(this.sClass, str1, "Started", nameof (SystemInit));
      clsInit.appMarble.Init();
      clsAppMarbleVars.cmdMarble.Init();
      clsAppMarbleVars.cmdMarble.InitSystem();
      this.AddControls();
      buLogMarbleVer5.addToLogList(this.sClass, str1, "Finished", "AddControls");
      this.UpdateVisualThings();
      buLogMarbleVer5.addToLogList(this.sClass, str1, "Finished", "UpdateVisualThings");
      clsMarble.secondKinematic = new KinematicBase5();
      clsMarble.secondKinematic.RotateCenterOffsetOfB.Y = 300.0;
      clsMarble.secondKinematic.Type = KinemeticType.CartezianXYZ_WristBC_5Axis;
      clsInit.appMarble.SimUpdated += new MarbleSimCoordinateUpdated(clsAppMarbleVars.cmdMarble.SimUpdated);
      MarbleCNC.clsItem.FrmMach1.KeyPreview = true;
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
      buLogMarbleVer5.addToLogList(this.sClass, str1, "Started", "Move Controls");
      MarbleCNC.clsItem.FrmMach1.pnl_hordata.Controls.Add((Control) buMarbleForms.frmHorizontal.pnl_data);
      MarbleCNC.clsItem.FrmMach1.pnl_verdata.Controls.Add((Control) buMarbleForms.frmVertical.pnl_data);
      MarbleCNC.clsItem.FrmMach1.pnl_horverdata.Controls.Add((Control) buMarbleForms.frmHorVer.pnl_data);
      MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Width = 1450;
      MarbleCNC.clsItem.FrmMach1.pnl_drawingjob.Visible = false;
      buLogMarbleVer5.addToLogList(this.sClass, str1, "Finished", "Move Controls");
      MarbleCNC.clsItem.FrmMach1.btn_menu.Click += new EventHandler(this.showMenuPage);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_watch.Click += new EventHandler(this.showWatch);
      MarbleCNC.clsItem.FrmMenu.btn_report.Click += new EventHandler(this.showReportPage);
      MarbleCNC.clsItem.FrmMenu.btn_simulationpanel.Click += new EventHandler(this.showSimulationPanel);
      MarbleCNC.clsItem.FrmMenu.btn_test.Click += new EventHandler(this.showTestPage);
      MarbleCNC.clsItem.FrmMenu.btn_settings.Click += new EventHandler(this.showSettingsPage);
      MarbleCNC.clsItem.FrmMenu.btn_selectmaterial.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_closepc.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_language.Click += new EventHandler(this.showLanguageMenu);
      MarbleCNC.clsItem.FrmMenu.btn_password.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_tools.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_g54offset.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_settingsaxes.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_millingsettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_marblecamsettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_servoconnection.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach1.btn_contoursettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_G54Offset.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_AbsoluteHomeSet.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_calibration.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_toolsettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_vagoonsettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_camerasettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_debug.Click += new EventHandler(this.showDebug);
      MarbleCNC.clsItem.FrmMach1.btn_main.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_manuel.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_horizontal.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_vertical.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_horver.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_drawing.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_semiAuto.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_drawmode.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_eventmode.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_functionsmode.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach1.btn_misc.Click += new EventHandler(this.clickCommandMainMenuButton);
      buMarbleForms.frmHorizontal.chk_horleftbottom.Name += "Hor";
      buMarbleForms.frmHorizontal.chk_horlefttop.Name += "Hor";
      buMarbleForms.frmHorizontal.chk_cutstart.Name += "Hor";
      buMarbleForms.frmHorizontal.chk_cutend.Name += "Hor";
      for (int index = 0; index <= buMarbleForms.frmHorizontal.pnl_data.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmHorizontal.pnl_data.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmHorizontal.pnl_data.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "HorVer")
          {
            control.Aux.AuxInfo = "Hor";
            control.ValueChanged += new buControlEvents.buValueChangedEvent(clsAppMarbleVars.cmdMarble.spn_item_HorValueChanged);
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmHorizontal.pnl_data.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmHorizontal.pnl_data.Controls[index] as buButton;
          control.Aux.AuxInfo = "Hor";
          control.Name += "Hor";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
        }
      }
      buMarbleForms.frmHorizontal.chk_horleftbottom.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorizontal.chk_horlefttop.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorizontal.chk_cutstart.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorizontal.chk_cutend.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmVertical.chk_horleftbottom.Name += "Ver";
      buMarbleForms.frmVertical.chk_horlefttop.Name += "Ver";
      buMarbleForms.frmVertical.chk_cutstart.Name += "Ver";
      buMarbleForms.frmVertical.chk_cutend.Name += "Ver";
      for (int index = 0; index <= buMarbleForms.frmVertical.pnl_data.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmVertical.pnl_data.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmVertical.pnl_data.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "HorVer")
          {
            control.Aux.AuxInfo = "Ver";
            control.ValueChanged += new buControlEvents.buValueChangedEvent(clsAppMarbleVars.cmdMarble.spn_item_VerValueChanged);
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_Veritem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmVertical.pnl_data.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmVertical.pnl_data.Controls[index] as buButton;
          control.Aux.AuxInfo = "Ver";
          control.Name += "Ver";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
        }
      }
      buMarbleForms.frmVertical.chk_horleftbottom.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmVertical.chk_horlefttop.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmVertical.chk_cutstart.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmVertical.chk_cutend.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      for (int index = 0; index <= buMarbleForms.frmHorVer.tabPage_Hor.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmHorVer.tabPage_Hor.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmHorVer.tabPage_Hor.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "Hor")
          {
            control.Aux.AuxInfo = "Hor";
            control.ValueChanged += new buControlEvents.buValueChangedEvent(clsAppMarbleVars.cmdMarble.spn_item_HorVerHorValueChanged);
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_HorVerHoritem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmHorVer.tabPage_Hor.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmHorVer.tabPage_Hor.Controls[index] as buButton;
          control.Aux.AuxInfo = "Hor";
          control.Name += "Hor";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
        }
      }
      for (int index = 0; index <= buMarbleForms.frmHorVer.tabPage_Ver.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmHorVer.tabPage_Ver.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmHorVer.tabPage_Ver.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "Ver")
          {
            control.Aux.AuxInfo = "Ver";
            control.ValueChanged += new buControlEvents.buValueChangedEvent(clsAppMarbleVars.cmdMarble.spn_item_HorVerVerValueChanged);
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_HorVerVeritem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmHorVer.tabPage_Ver.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmHorVer.tabPage_Ver.Controls[index] as buButton;
          control.Aux.AuxInfo = "Ver";
          control.Name += "Ver";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
        }
      }
      buMarbleForms.frmHorVer.chk_horverleftbottom.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVer.chk_horverlefttop.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVer.btn_addtolist.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVer.btn_horveropen.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVer.btn_horversave.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVer.btn_itemhorverendpos.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVer.btn_itemhorverok.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVer.btn_itemhorverstartpos.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVer.buTab1.SelectedIndexChanged += new EventHandler(clsAppMarbleVars.cmdMarble.Tab_HorVerSelectedIndexChanged);
      for (int index = 0; index <= buMarbleForms.frmHorOrVerDialog.pnl_data.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "HorVer")
          {
            control.Aux.AuxInfo = "Hor";
            control.ValueChanged += new buControlEvents.buValueChangedEvent(clsAppMarbleVars.cmdMarble.spn_item_HorOrVerDialogValueChanged);
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_HorOrVeritem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[index] as buButton;
          control.Aux.AuxInfo = "Hor";
          control.Name += "Hor";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandHorOrVerDialog_Click);
        }
      }
      buMarbleForms.frmHorOrVerDialog.chk_horleftbottom.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandHorOrVerDialog_Click);
      buMarbleForms.frmHorOrVerDialog.chk_horlefttop.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandHorOrVerDialog_Click);
      buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Name += "Dialog";
      buMarbleForms.frmHorVerDialog.chk_horverlefttop.Name += "Dialog";
      buMarbleForms.frmHorVerDialog.btn_itemhorverok.Name += "Dialog";
      for (int index = 0; index <= buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "Hor")
          {
            control.Aux.AuxInfo = "Hor";
            control.ValueChanged += new buControlEvents.buValueChangedEvent(clsAppMarbleVars.cmdMarble.spn_item_HorVerHorDialogValueChanged);
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_HorVerHorDialogitem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[index] as buButton;
          control.Aux.AuxInfo = "Hor";
          control.Name += "Hor";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
        }
      }
      for (int index = 0; index <= buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "Ver")
          {
            control.Aux.AuxInfo = "Ver";
            control.ValueChanged += new buControlEvents.buValueChangedEvent(clsAppMarbleVars.cmdMarble.spn_item_HorVerVerDialogValueChanged);
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_HorVerVerDialogitem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[index] as buButton;
          control.Aux.AuxInfo = "Ver";
          control.Name += "Ver";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
        }
      }
      buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVerDialog.chk_horverlefttop.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click);
      buMarbleForms.frmHorVerDialog.buTab1.SelectedIndexChanged += new EventHandler(clsAppMarbleVars.cmdMarble.Tab_HorVerDialogSelectedIndexChanged);
      for (int index = 0; index <= MarbleCNC.clsItem.FrmMach1.pnl_OpSettings.Controls.Count - 1; ++index)
      {
        if (MarbleCNC.clsItem.FrmMach1.pnl_OpSettings.Controls[index] is buSpin)
        {
          buSpin control = MarbleCNC.clsItem.FrmMach1.pnl_OpSettings.Controls[index] as buSpin;
          control.Aux.AuxInfo = "OPSettings";
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
      }
      MarbleCNC.clsItem.FrmMach1.btn_shape.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_library.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_contour.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_engraving.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_profiling.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_profilecurve.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_oplist.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_text.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_OPMenu.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_saveOP.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_openOP.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_move.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_rotate.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_mirror.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_scale.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_alignments.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_copy.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_copymulti.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_offset.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_undo.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_eventdelete.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_eventdeleteall.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmRotate.btn_eventRotateminus.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmRotate.btn_eventrotateplus.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmMove.btn_eventmovedown.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmMove.btn_eventmoveleft.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmMove.btn_eventmoveright.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmMove.btn_eventmoveup.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_setangle2.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_slatadd.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_collopseadd.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_extend.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_break.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_vacuum.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_cadoutside.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_cadinside.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach1.btn_gcodes.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandsView);
      MarbleCNC.clsItem.FrmMach1.btn_view.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandsView);
      MarbleCNC.clsItem.FrmMach1.btn_joblist.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandsView);
      MarbleCNC.clsItem.FrmMach1.btn_commands.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandsView);
      MarbleCNC.clsItem.FrmMach1.btn_cancel.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_reset.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_start.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_stop.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_pause.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_water.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_laser.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_camera.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_homing.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_park.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_vagonpark.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_sawpark.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_spindlepark.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_spindleheadpark.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_photopos.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_codecreate.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_partzero.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_A0.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_A45.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_A90.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_c180.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_c270.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_c90.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_c0.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_gozero.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_crousecontrol.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_cameraclose.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_cameraopen.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_a0_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_a45_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_a46_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_c180_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_c_90_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_c90_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_c0_2.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmSpeedsV1.track_sawspeed.ValueChanged += new buTrack.ValueChangedEventHandler(this.trackValueChanged);
      clsAppMarbleItems.frmSpeedsV1.track_Spindlespeed.ValueChanged += new buTrack.ValueChangedEventHandler(this.trackValueChanged);
      clsAppMarbleItems.frmSpeedsV1.track_operationspeed.ValueChanged += new buTrack.ValueChangedEventHandler(this.trackValueChanged);
      clsAppMarbleItems.frmSpeedsV1.track_quickspeed.ValueChanged += new buTrack.ValueChangedEventHandler(this.trackValueChanged);
      MarbleCNC.clsItem.FrmMach1.btn_pensopenclose.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      MarbleCNC.clsItem.FrmMach1.btn_spindlepistondown.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      MarbleCNC.clsItem.FrmMach1.btn_spindlepistonup.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      MarbleCNC.clsItem.FrmMach1.btn_toolmagazineopen.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      MarbleCNC.clsItem.FrmMach1.btn_toolmagazineClose.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      clsAppMarbleItems.frmKinematic.btn_openkinematic.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      clsAppMarbleItems.frmKinematic.btn_savekinemtic.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      MarbleCNC.clsItem.FrmMach1.btn_tool.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_kinematic.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach1.chk_absolute.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(this.checkCheckedChanged);
      MarbleCNC.clsItem.FrmMach1.chk_incremental.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(this.checkCheckedChanged);
      MarbleCNC.clsItem.FrmMach1.chk_addsawthickness.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(this.checkCheckedChanged);
      MarbleCNC.clsItem.FrmMach1.spn_go.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.btn_xplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_yplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_zplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_aplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_cplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_xminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_yminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_zminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_aminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_cminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach1.btn_xplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_yplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_zplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_aplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_cplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_xminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_yminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_zminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_aminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_cminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach1.btn_xplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_yplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_zplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_aplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_cplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_xminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_yminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_zminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_aminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_cminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach1.btn_stopmanuel.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_preset.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      clsAppMarbleItems.frmSpeedsV1.btn_saw.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmSpeedsV1.btn_spindle.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmSpeedsV1.btn_sawminus.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmSpeedsV1.btn_sawplus.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmSpeedsV1.btn_spindleminus.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmSpeedsV1.btn_spindleplus.Click += new EventHandler(this.clickCommands);
      this.SemiAutoParameterChange(false);
      MarbleCNC.clsItem.FrmMach1.btn_xplus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach1.btn_yplus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach1.btn_zplus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach1.btn_xminus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach1.btn_yminus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach1.btn_zminus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach1.btn_stopsemiauto.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.btn_semiautoenable.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.spn_semiautocuttingspeed.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.spn_semiautohorizontallen.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialheight.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialthickness.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialwidth.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.spn_semiautooperationz.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.spn_semiautoverticallen.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.spn_semiautoplungespeed.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.spn_semiautosafedis.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.spn_semiautocuttingspeed.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach1.spn_semiautohorizontallen.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialheight.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialthickness.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialwidth.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach1.spn_semiautooperationz.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach1.spn_semiautoverticallen.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach1.spn_semiautoplungespeed.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach1.spn_semiautosafedis.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach1.spn_semiautocuttingspeed.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach1.spn_semiautohorizontallen.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialheight.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialthickness.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialwidth.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach1.spn_semiautooperationz.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach1.spn_semiautoverticallen.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach1.spn_semiautoplungespeed.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach1.spn_semiautosafedis.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach1.spn_semiautocuttingspeed.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach1.spn_semiautohorizontallen.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialheight.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialthickness.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialwidth.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach1.spn_semiautooperationz.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach1.spn_semiautoverticallen.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach1.spn_semiautoplungespeed.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach1.spn_semiautosafedis.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmCameraLive.btn_camerastart.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmCameraLive.btn_camerastop.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmCameraLive.btn_cameratakeshot.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach1.KeyDown += new KeyEventHandler(this.FormKeyDown);
      clsAppMarbleItems.frmMove.spn_eventmovevalue.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      clsAppMarbleItems.frmRotate.spn_eventrotatevalue.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndexChanged += new EventHandler(this.buTabSelectedIndexChanged);
      clsInit.appCommand.MainFormUpdate += new FormUpdate(this.MainFormUpdate);
      clsInit.appCommand.MainFormStatusUpdate += new FormStatusUpdate(this.MainFormStatusUpdate);
      clsInit.appCommand.MainFormXYZUpdate += new FormXYZUpdate(this.MainFormXYZUpdate);
      clsInit.appCommand.EntityAddToPage += new buClass.PageEntityAdd(this.PageEntityAdd);
      clsInit.appCommand.RunCommand += new buClass.RunCommands(this.RunCommands);
      clsInit.appCommand.GeneralCommand += new GeneralCommands(this.RunGeneralCommand);
      buMarbleCalc.varMarbleRunSettings.fileWood = AppPath.Base + "\\Images\\Wood\\BaseMaterial.png";
      buMarbleCalc.varMarbleRunSettings.fileMarble = AppPath.Base + "\\Images\\Marble\\MarbleBlackAndWhile.png";
      clsInit.appMarble.ViewportDialogsInit();
      clsInit.appMarble.ViewportCNCInit();
      buEyeItems.viewportCNC.MouseMove += new MouseEventHandler(this.mouseMoveViewport);
      buEyeItems.viewportCNC.MouseDown += new MouseEventHandler(this.mouseDownViewport);
      buEyeItems.viewportCNC.MouseUp += new MouseEventHandler(this.mouseUpViewport);
      MarbleCNC.clsItem.FrmMach1.pnl_mainviewport.Controls.Add((Control) buEyeItems.viewportCNC);
      clsInit.appMarble.ViewportCadCamInit();
      MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls.Add((Control) buEyeItems.viewportCadCam);
      buEyeItems.viewportCadCam.ActiveViewport.Rotate.Enabled = buMarbleCalc.varMarbleRunSettings.RotateCameraCadCam;
      buVector5.baseModel = buEyeItems.viewportCadCam;
      clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelRotate;
      clsAppMarbleItems.frmMove.spn_eventmovevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelMove;
      MarbleCNC.clsItem.FrmMach1.spn_camcuttingspped.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity;
      MarbleCNC.clsItem.FrmMach1.spn_cammarblethickness.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
      MarbleCNC.clsItem.FrmMach1.spn_camoperationZ.Value = buMarbleCalc.varOperation.settingMarbleCam.TargetZ;
      MarbleCNC.clsItem.FrmMach1.spn_camplungespeed.Value = buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity;
      MarbleCNC.clsItem.FrmMach1.spn_camcuttingstep.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance;
      MarbleCNC.clsItem.FrmMach1.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
      MarbleCNC.clsItem.FrmMach1.spn_camsafedis.Value = buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance;
      MarbleCNC.clsItem.FrmMach1.chk_incremental.Check = clsAppMarbleVars.varInterface.IncrementalMode;
      MarbleCNC.clsItem.FrmMach1.chk_absolute.Check = clsAppMarbleVars.varInterface.AbsoluteMode;
      MarbleCNC.clsItem.FrmMach1.chk_addsawthickness.Check = clsAppMarbleVars.varInterface.AddSawThicknessToMove;
      MarbleCNC.clsItem.FrmMach1.spn_go.Value = clsAppMarbleVars.varInterface.JogMoveValue;
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
      clsAppMarbleItems.frmSpeedsV1.btn_saw = buControls.buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_saw, false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      clsAppMarbleItems.frmSpeedsV1.btn_spindle = buControls.buControlCommands.ColorButtonLinearFromEnable(clsAppMarbleItems.frmSpeedsV1.btn_spindle, false, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      clsAppMarbleItems.frmSpeedsV1.track_operationspeed.Value = (int) clsAppMarbleVars.varInterface.OperationSpeed;
      clsAppMarbleItems.frmSpeedsV1.track_quickspeed.Value = (int) clsAppMarbleVars.varInterface.QuickSpeed;
      clsAppMarbleItems.frmSpeedsV1.track_Spindlespeed.Value = (int) clsAppMarbleVars.varInterface.SpindleSpeedOverride;
      clsAppMarbleItems.frmSpeedsV1.track_sawspeed.Value = (int) clsAppMarbleVars.varInterface.SawSpeedOverride;
      clsAppMarbleItems.frmSpeedsV1.spn_spindlespeed.Value = clsAppMarbleVars.varInterface.SpindleSpeed;
      clsAppMarbleItems.frmSpeedsV1.spn_sawspeed.Value = clsAppMarbleVars.varInterface.SawSpeed;
      if (CodesysMachine.CommType == CommunicationType.PlcHandler | CodesysMachine.CommType == CommunicationType.OPCUA)
        clsAppMarbleVars.cmdMarble.CommunicationVariableInit();
      buMarbleCalc.activeToolSaw.Geometry.GeometryType = ToolType.Saw;
      buMarbleCalc.activeToolSaw.Geometry.LowerRadius = 0.0;
      buMarbleCalc.activeToolSaw.Geometry.UpperRadius = 0.0;
      buMarbleCalc.activeToolSaw.Geometry.DrawHolder = false;
      buMarbleCalc.activeToolSaw.Geometry.DrawArbor = false;
      buMarbleCalc.activeToolSaw.Geometry.PlaneDirection = new Vec3D(0.0, 1.0, 0.0);
      buMarbleCalc.activeToolSaw.Limits.RotationA = true;
      buMarbleCalc.activeToolSaw.Limits.RotationC = true;
      this.MenuButtonColors(0);
      this.MenuDrawButtonColors(0);
      ccVars.Pages[0].Form.UpdateForm();
      MarbleCNC.clsItem.timGeneral.Interval = 300;
      MarbleCNC.clsItem.timGeneral.Tick += new EventHandler(this.GeneralTick);
      MarbleCNC.clsItem.timGeneral.Enabled = true;
      if (AppBool.Connected)
      {
        this.ReadBOOLValues();
        this.ReadDINTValues();
        this.ReadLRealValues();
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SpindleSpeed, "AppRun.VelSpindle");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SawSpeed, "AppRun.VelSaw");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SawSpeedOverride, "AppRun.SawOverride");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.SpindleSpeedOverride, "sysSet.Spindle.SpindleOverride");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.OperationSpeed, "sysSet.Feed.FeedOverrideG1");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.QuickSpeed, "sysSet.Feed.FeedOverrideG0");
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.SpindleSpeedUpdate");
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.SawSpeedUpdate");
        MarbleCNC.clsItem.FrmMach1.btn_homing = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
        MarbleCNC.clsItem.FrmMach1.btn_homing.ForceSelected = false;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
        clsAppMarbleVars.cMachine.bWriteAppParameter = true;
        clsAppMarbleVars.cMachine.bWriteToolParameter = true;
        clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
        KinematicBase copyKinematic = new KinematicBase();
        KinematicBase5.Copy(clsMarble.activeKinematic, ref copyKinematic);
        clsAppMarbleVars.cMachine.Commands.WriteKinematicData(CodesysMachine.RootPersistentString + "Kinematic.", copyKinematic);
      }
      clsInit.appCommand.cmdViewZoomFit();
      MarbleCNC.clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
      clsAppMarbleItems.frmMain = (Form) MarbleCNC.clsItem.FrmMach1;
      buCadCamResVer5.clsItem.FrmMain = (Form) MarbleCNC.clsItem.FrmMach1;
      AppBool.Inited = true;
      Task.Run((Action) (() => this.DoInitWork()));
      this.Inited = true;
      buLogMarbleVer5.addToLogList(this.sClass, str1, "Finished");
      buLogMarbleVer5.saveLogList();
    }
    catch (Exception ex)
    {
      buLogMarbleVer5.addToLog(this.sClass, str1, ex.Message, "Exception", AddException: true);
      buException.throwException(ex, str1, true, "");
    }
  }

  public void DoInitWork()
  {
    clsInit.appMarble.InitCadCamSimulation();
    this.Inited = true;
  }

  public void AddControls()
  {
    string str = nameof (AddControls);
    try
    {
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmCoordsV1");
      clsAppMarbleItems.frmCoordsV1.pnl_base.Left = 4;
      clsAppMarbleItems.frmCoordsV1.pnl_base.Top = MarbleCNC.clsItem.FrmMach1.pic_imagecompany.Top + MarbleCNC.clsItem.FrmMach1.pic_imagecompany.Height + 2;
      clsAppMarbleItems.frmCoordsV1.pnl_base.Display.BackColor = Color.Transparent;
      clsAppMarbleItems.frmCoordsV1.pnl_base.Display.Border.Visible = false;
      MarbleCNC.clsItem.FrmMach1.pnl_left.Controls.Add((Control) clsAppMarbleItems.frmCoordsV1.pnl_base);
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmCoordinates");
      buSeparator buSeparator = new buSeparator();
      buSeparator.Display.BackColor = Color.Black;
      buSeparator.Display.GradientType = GradientMode.Solid;
      buSeparator.Size = new Size(MarbleCNC.clsItem.FrmMach1.pnl_left.Width + 2, 2);
      buSeparator.Location = new System.Drawing.Point(-1, clsAppMarbleItems.frmCoordsV1.pnl_base.Top + clsAppMarbleItems.frmCoordsV1.pnl_base.Height + 2);
      MarbleCNC.clsItem.FrmMach1.pnl_left.Controls.Add((Control) buSeparator);
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmSpeedsV1");
      clsAppMarbleItems.frmSpeedsV1.pnl_base.Left = 4;
      clsAppMarbleItems.frmSpeedsV1.pnl_base.Top = buSeparator.Top + buSeparator.Height + 2;
      clsAppMarbleItems.frmSpeedsV1.pnl_base.Display.BackColor = Color.Transparent;
      clsAppMarbleItems.frmSpeedsV1.pnl_base.Display.Border.Visible = false;
      MarbleCNC.clsItem.FrmMach1.pnl_left.Controls.Add((Control) clsAppMarbleItems.frmSpeedsV1.pnl_base);
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmSpeedsV1");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmJobOPListV2");
      clsAppMarbleItems.frmJobOPListV2.pnl_base.Left = 0;
      clsAppMarbleItems.frmJobOPListV2.pnl_base.Top = 38;
      clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.BackColor = Color.Transparent;
      clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.Border.Visible = false;
      MarbleCNC.clsItem.FrmMach1.pnl_drawingjob.Controls.Add((Control) clsAppMarbleItems.frmJobOPListV2.pnl_base);
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmJobOPListV2");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished");
    }
    catch (Exception ex)
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Exception", ex.Message, AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void GeneralTick(object sender, EventArgs e)
  {
    ++clsAppMarbleVars.cMachine.miscVar.cntGeneralTick;
    ++clsAppMarbleVars.cMachine.miscVar.cntWarning;
    ++clsAppMarbleVars.cMachine.miscVar.tickCameraImage;
    buLabel lblDatetime = MarbleCNC.clsItem.FrmMach1.lbl_datetime;
    string[] strArray = new string[9];
    strArray[0] = " ";
    DateTime dateTime = DateTime.Now;
    dateTime = dateTime.Date;
    strArray[1] = dateTime.ToShortDateString();
    strArray[2] = " - ";
    strArray[3] = DateTime.Now.Hour.ToString("D2");
    strArray[4] = ":";
    strArray[5] = DateTime.Now.Minute.ToString("D2");
    strArray[6] = ":";
    strArray[7] = DateTime.Now.Second.ToString("D2");
    strArray[8] = "   ";
    string str = string.Concat(strArray);
    lblDatetime.Text = str;
    if (!this.Inited)
      return;
    if (!AppBool.IsFirstRun)
    {
      MarbleCNC.clsItem.FrmMach1.btn_water = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      MarbleCNC.clsItem.FrmMach1.btn_homing = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      MarbleCNC.clsItem.FrmMach1.btn_laser = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      MarbleCNC.clsItem.FrmMach1.btn_start = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      MarbleCNC.clsItem.FrmMach1.btn_pause = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      MarbleCNC.clsItem.FrmMach1.btn_semiautoenable = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      MarbleCNC.clsItem.FrmMach1.btn_crousecontrol = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      AppBool.IsFirstRun = true;
    }
    clsAppMarbleVars.cmdMarble.GeneralTick();
    if (clsAppMarbleVars.cMachine.miscVar.WarningAvailable & clsAppMarbleVars.cMachine.miscVar.cntWarning >= 10)
    {
      clsAppMarbleVars.cMachine.miscVar.WarningAvailable = false;
      clsAppMarbleVars.cMachine.miscVar.cntWarning = 0;
      MarbleCNC.clsItem.FrmMach1.lbl_status.Display.BackColor = Color.LightSteelBlue;
      if (clsAppMarbleVars.cMachine.runSystem.Status >= 0 & clsAppMarbleVars.cMachine.runSystem.Status < 100 & clsAppMarbleVars.cMachine.runSystem.Status <= AppLanguage.SystemStatus.Count - 1 & !AppBool.FileLoading)
        MarbleCNC.clsItem.FrmMach1.lbl_status.Text = AppLanguage.SystemStatus[clsAppMarbleVars.cMachine.runSystem.Status];
      if (clsAppMarbleVars.cMachine.runSystem.Status >= 100 & clsAppMarbleVars.cMachine.runSystem.Status < 200 & clsAppMarbleVars.cMachine.runSystem.Status - 100 <= AppLanguage.Status.Count - 1 & !AppBool.FileLoading)
        MarbleCNC.clsItem.FrmMach1.lbl_status.Text = AppLanguage.Status[clsAppMarbleVars.cMachine.runSystem.Status - 100];
      MarbleCNC.clsItem.FrmMach1.lbl_warning.Visible = false;
    }
    if (AppBool.Offline)
    {
      MarbleCNC.clsItem.FrmMach1.lbl_warning.Visible = false;
      MarbleCNC.clsItem.FrmMach1.lbl_warning.Text = buLangTranslate.preMotionWarning.SystemOffline;
    }
    else
    {
      MarbleCNC.clsItem.timGeneral.Enabled = false;
      if (clsAppMarbleVars.cMachine.bParameterWriting)
      {
        MarbleCNC.clsItem.FrmMach1.lbl_warning.Text = buLangTranslate.preMotionWarning.ParameterWriting;
        MarbleCNC.clsItem.FrmMach1.lbl_warning.Visible = clsAppMarbleVars.cMachine.bParameterWriting;
      }
      if (clsAppMarbleVars.cMachine.preVar.ParWriting & !clsAppMarbleVars.cMachine.bParameterWriting)
      {
        MarbleCNC.clsItem.FrmMach1.lbl_warning.Text = "";
        MarbleCNC.clsItem.FrmMach1.lbl_warning.Visible = false;
      }
      clsAppMarbleVars.cMachine.preVar.ParWriting = clsAppMarbleVars.cMachine.bParameterWriting;
      if (!MarbleCNC.clsItem.FrmMach1.btn_homing.ForceSelected & clsAppMarbleVars.cMachine.runSystem.HomingDone)
      {
        MarbleCNC.clsItem.FrmMach1.btn_homing.ForceSelected = true;
        MarbleCNC.clsItem.FrmMach1.btn_homing = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      else if (MarbleCNC.clsItem.FrmMach1.btn_homing.ForceSelected = !clsAppMarbleVars.cMachine.runSystem.HomingDone)
      {
        MarbleCNC.clsItem.FrmMach1.btn_homing.ForceSelected = false;
        MarbleCNC.clsItem.FrmMach1.btn_homing = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_homing, clsAppMarbleVars.cMachine.runSystem.HomingDone, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      if (!MarbleCNC.clsItem.FrmMach1.btn_water.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Water)
      {
        MarbleCNC.clsItem.FrmMach1.btn_water.ForceSelected = true;
        MarbleCNC.clsItem.FrmMach1.btn_water = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      else if (MarbleCNC.clsItem.FrmMach1.btn_water.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Water)
      {
        MarbleCNC.clsItem.FrmMach1.btn_water.ForceSelected = false;
        MarbleCNC.clsItem.FrmMach1.btn_water = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      if (!MarbleCNC.clsItem.FrmMach1.btn_laser.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Laser)
      {
        MarbleCNC.clsItem.FrmMach1.btn_laser.ForceSelected = true;
        MarbleCNC.clsItem.FrmMach1.btn_laser = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      else if (MarbleCNC.clsItem.FrmMach1.btn_laser.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Laser)
      {
        MarbleCNC.clsItem.FrmMach1.btn_laser.ForceSelected = false;
        MarbleCNC.clsItem.FrmMach1.btn_laser = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      if (!MarbleCNC.clsItem.FrmMach1.btn_start.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Run)
      {
        MarbleCNC.clsItem.FrmMach1.btn_start.ForceSelected = true;
        MarbleCNC.clsItem.FrmMach1.btn_start = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      else if (MarbleCNC.clsItem.FrmMach1.btn_start.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Run)
      {
        MarbleCNC.clsItem.FrmMach1.btn_start.ForceSelected = false;
        MarbleCNC.clsItem.FrmMach1.btn_start = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      if (!MarbleCNC.clsItem.FrmMach1.btn_pause.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Pause)
      {
        MarbleCNC.clsItem.FrmMach1.btn_pause.ForceSelected = true;
        MarbleCNC.clsItem.FrmMach1.btn_pause = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      else if (MarbleCNC.clsItem.FrmMach1.btn_pause.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Pause)
      {
        MarbleCNC.clsItem.FrmMach1.btn_pause.ForceSelected = false;
        MarbleCNC.clsItem.FrmMach1.btn_pause = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      if (!MarbleCNC.clsItem.FrmMach1.btn_semiautoenable.ForceSelected & clsAppMarbleVars.cMachine.runSystem.SemiAuto)
      {
        MarbleCNC.clsItem.FrmMach1.btn_semiautoenable.ForceSelected = true;
        MarbleCNC.clsItem.FrmMach1.btn_semiautoenable = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      else if (MarbleCNC.clsItem.FrmMach1.btn_semiautoenable.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.SemiAuto)
      {
        MarbleCNC.clsItem.FrmMach1.btn_semiautoenable.ForceSelected = false;
        MarbleCNC.clsItem.FrmMach1.btn_semiautoenable = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      if (!MarbleCNC.clsItem.FrmMach1.btn_crousecontrol.ForceSelected & clsAppMarbleVars.cMachine.runSystem.CruiseControl)
      {
        MarbleCNC.clsItem.FrmMach1.btn_crousecontrol.ForceSelected = true;
        MarbleCNC.clsItem.FrmMach1.btn_crousecontrol = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      else if (MarbleCNC.clsItem.FrmMach1.btn_crousecontrol.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.CruiseControl)
      {
        MarbleCNC.clsItem.FrmMach1.btn_crousecontrol.ForceSelected = false;
        MarbleCNC.clsItem.FrmMach1.btn_crousecontrol = buControls.buControlCommands.ColorButtonLinearFromEnable(MarbleCNC.clsItem.FrmMach1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.colorLinearGradientEnableDisable);
      }
      MarbleCNC.clsItem.FrmMach1.chk_connected.Check = AppBool.Connected;
      MarbleCNC.clsItem.FrmMach1.chk_inited.Check = clsAppMarbleVars.cMachine.runSystem.InitDone;
      MarbleCNC.clsItem.FrmMach1.chk_home.Check = clsAppMarbleVars.cMachine.runSystem.HomingDone;
      MarbleCNC.clsItem.FrmMach1.chk_run.Check = clsAppMarbleVars.cMachine.runSystem.Run;
      MarbleCNC.clsItem.FrmMach1.chk_rtcp.Check = clsAppMarbleVars.cMachine.runSystem.RtcpActivated;
      if (clsAppMarbleVars.cMachine.runSystem.AlarmCount == 0 & !clsAppMarbleVars.cMachine.miscVar.WarningAvailable)
      {
        MarbleCNC.clsItem.FrmMach1.lbl_status.Display.BackColor = Color.LightSteelBlue;
        if (clsAppMarbleVars.cMachine.runSystem.Status >= 0 & clsAppMarbleVars.cMachine.runSystem.Status < 100 & clsAppMarbleVars.cMachine.runSystem.Status <= AppLanguage.SystemStatus.Count - 1 & !AppBool.FileLoading)
          MarbleCNC.clsItem.FrmMach1.lbl_status.Text = AppLanguage.SystemStatus[clsAppMarbleVars.cMachine.runSystem.Status];
        if (clsAppMarbleVars.cMachine.runSystem.Status >= 100 & clsAppMarbleVars.cMachine.runSystem.Status < 200 & clsAppMarbleVars.cMachine.runSystem.Status - 100 <= AppLanguage.Status.Count - 1 & !AppBool.FileLoading)
          MarbleCNC.clsItem.FrmMach1.lbl_status.Text = AppLanguage.Status[clsAppMarbleVars.cMachine.runSystem.Status - 100];
      }
      MarbleCNC.clsItem.timGeneral.Enabled = true;
    }
  }

  private void CommandHMI(object Data1, object Data2, object Data3, object Data4, object Data5)
  {
    marbleHmiCommands = MarbleHMICommands.None;
    if (!(Data1 is MarbleHMICommands marbleHmiCommands))
      ;
    if (marbleHmiCommands == MarbleHMICommands.ShowWarning)
      this.ShowWarning((string) Data2, Color.Gold);
    if (marbleHmiCommands == MarbleHMICommands.HideWarning)
    {
      MarbleCNC.clsItem.FrmMach1.lbl_warning.Text = "";
      MarbleCNC.clsItem.FrmMach1.lbl_warning.Visible = false;
    }
    if (marbleHmiCommands == MarbleHMICommands.StatusUpdate)
    {
      MarbleCNC.clsItem.FrmMach1.lbl_status.Text = (string) Data2;
      MarbleCNC.clsItem.FrmMach1.lbl_status.Display.BackColor = (Color) Data3;
    }
    if (marbleHmiCommands == MarbleHMICommands.SaveCNCParameter)
      this.SaveParameter();
    if (marbleHmiCommands != MarbleHMICommands.UpdateMarbleCamParametersFromControls)
      return;
    this.MainControlsToParameter(true);
  }

  public void clickCommands(object sender, EventArgs e)
  {
    try
    {
      Control control = sender as Control;
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_cancel.Name)
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Cancel);
      if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_spindle.Name)
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleStart);
      else if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_spindleminus.Name)
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleMinus);
      else if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_spindleplus.Name)
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePlus);
      else if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_saw.Name)
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawStart);
      else if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_sawminus.Name)
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawMinus);
      else if (control.Name == clsAppMarbleItems.frmSpeedsV1.btn_sawplus.Name)
      {
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawPlus);
      }
      else
      {
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_gozero.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.GoPartZero);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_crousecontrol.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CrouseControl);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_partzero.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.PartZero);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_codecreate.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CodeCreate);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_c0.Name | control.Name == MarbleCNC.clsItem.FrmMach1.btn_c0_2.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C0);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_c90.Name | control.Name == MarbleCNC.clsItem.FrmMach1.btn_c90_2.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_c180.Name | control.Name == MarbleCNC.clsItem.FrmMach1.btn_c180_2.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C180);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_c270.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C270);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_c_90_2.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90Minus);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_A0.Name | control.Name == MarbleCNC.clsItem.FrmMach1.btn_a0_2.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A0);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_A45.Name | control.Name == MarbleCNC.clsItem.FrmMach1.btn_a45_2.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A45);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_A90.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A90);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_a46_2.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A46);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_spindlepistondown.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonDown);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_spindlepistonup.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonUp);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_semiautoenable.Name)
        {
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SemiAutoSwitch);
          if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
            clsAppMarbleVars.cMachine.bWriteAppParameter = true;
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_homing.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Homing);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_water.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Water);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_laser.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Laser);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_park.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Park);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_vagonpark.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.WagonPark);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_spindlepark.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePark);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_sawpark.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawPark);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_spindleheadpark.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleHeadPark);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_photopos.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraPark);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_reset.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Reset);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_start.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Start);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_stop.Name | control.Name == MarbleCNC.clsItem.FrmMach1.btn_stopmanuel.Name | control.Name == MarbleCNC.clsItem.FrmMach1.btn_stopsemiauto.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_cameraopen.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverOpen);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_cameraclose.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverClose);
        if (!(control.Name == MarbleCNC.clsItem.FrmMach1.btn_camera.Name) || !(!AppBool.CameraCapturing & !AppBool.CameraMakeItReady & buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable))
          return;
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraReady);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void clickCommandMainMenuButton(object sender, EventArgs e)
  {
    try
    {
      Control control = sender as Control;
      this.MainControlsToParameter(true);
      clsAppMarbleVars.varRuntime.isHorizontalTab = false;
      clsAppMarbleVars.varRuntime.isVerticalTab = false;
      clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_main.Name)
      {
        clsAppMarbleVars.varRuntime.isMainTab = true;
        MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex = 0;
        this.MenuButtonColors(0);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_manuel.Name)
      {
        clsAppMarbleVars.varRuntime.isMainTab = true;
        MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex = 1;
        this.MenuButtonColors(1);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_horizontal.Name)
      {
        clsAppMarbleVars.varRuntime.isHorizontalTab = true;
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex = 2;
        this.MenuButtonColors(2);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_vertical.Name)
      {
        clsAppMarbleVars.varRuntime.isVerticalTab = true;
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex = 3;
        this.MenuButtonColors(3);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_horver.Name)
      {
        clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = true;
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex = 4;
        this.MenuButtonColors(4);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_drawing.Name)
      {
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex = 5;
        this.MenuButtonColors(5);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_semiAuto.Name)
      {
        clsAppMarbleVars.varRuntime.isMainTab = true;
        MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex = 6;
        this.MenuButtonColors(6);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_drawmode.Name)
      {
        MarbleTempVars.OperationageMode = MarbleOperationPageMode.Operation;
        MarbleCNC.clsItem.FrmMach1.buTab_drawing.SelectedIndex = 0;
        this.MenuDrawButtonColors(0);
        clsInit.appMarble.EntitiesSelectableStates(false, false, false, false, false);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_eventmode.Name)
      {
        MarbleTempVars.OperationageMode = MarbleOperationPageMode.Event;
        MarbleCNC.clsItem.FrmMach1.buTab_drawing.SelectedIndex = 1;
        this.MenuDrawButtonColors(1);
        clsInit.appMarble.EntitiesSelectableStates(false, true, false, false, false);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_functionsmode.Name)
      {
        MarbleTempVars.OperationageMode = MarbleOperationPageMode.Function;
        MarbleCNC.clsItem.FrmMach1.buTab_drawing.SelectedIndex = 2;
        this.MenuDrawButtonColors(2);
        clsInit.appMarble.EntitiesSelectableStates(true, false, false, false, false);
      }
      if (!(control.Name == MarbleCNC.clsItem.FrmMach1.btn_misc.Name))
        return;
      MarbleTempVars.OperationageMode = MarbleOperationPageMode.CadDraw;
      MarbleCNC.clsItem.FrmMach1.buTab_drawing.SelectedIndex = 3;
      this.MenuDrawButtonColors(3);
      clsInit.appMarble.EntitiesSelectableStates(false, false, false, false, false);
    }
    catch (Exception ex)
    {
    }
  }

  public void clickCommandsDrawing(object sender, EventArgs e)
  {
    try
    {
      Control control = sender as Control;
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_OPMenu.Name)
      {
        clsMarble.frmOPCommands.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsMarble.frmOPCommands.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsMarble.frmOPCommands.Init();
        int num = (int) clsMarble.frmOPCommands.ShowDialog();
        if (clsMarble.frmOPCommands.CommandType == MarbleItemType.HorizontalCut)
          clsInit.appMarble.cmdHorVerCut(true);
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.VerticalCut)
          clsInit.appMarble.cmdHorVerCut(false);
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.SingleCut)
          clsInit.appMarble.cmdSingleCut();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Contour)
          this.clickCommandsDrawing((object) MarbleCNC.clsItem.FrmMach1.btn_contour, (EventArgs) null);
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Shape)
          this.clickCommandsDrawing((object) MarbleCNC.clsItem.FrmMach1.btn_shape, (EventArgs) null);
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Slices)
          clsInit.appMarble.cmdSlicing();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Profiling)
          clsInit.appMarble.cmdProfileMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.ProfileCurve)
          clsInit.appMarble.cmdProfileCurveMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Text)
          clsInit.appMarble.cmdTextMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Library)
          clsInit.appMarble.cmdLibraryMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Engraving)
          clsInit.appMarble.cmdEngravingMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.GCode)
          clsInit.appMarble.cmdExternalGCode();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Columns)
          clsInit.appMarble.cmdColumnsMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Sweep)
          clsInit.appMarble.cmdSweepMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.LatheHorizontal)
          clsInit.appMarble.cmdLatheMenu(true);
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.LatheVertical)
          clsInit.appMarble.cmdLatheMenu(false);
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Drill)
          clsInit.appMarble.cmdDrillMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Editor)
          clsInit.appMarble.cmdContourMenu(true);
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.MaterialClean)
          clsInit.appMarble.cmdCleanMaterail();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.AirDry)
          clsInit.appMarble.cmdAirDryMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.SawHorizontalMillingRough)
          clsInit.appMarble.cmdSawHorizontalMillingRoughMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.SawVerticalMillingRough)
          clsInit.appMarble.cmdSawVerticalMillingRoughMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.EasyDraw)
          clsInit.appMarble.cmdEasyDrawing();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.PocketByDrill)
          clsInit.appMarble.cmdPocketByDrillMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Milling5AxisRotary)
          clsInit.appMarble.cmdMilling5AxisRotaryMenu();
        else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Milling5AxisFlat)
        {
          clsInit.appMarble.cmdMilling5AxisFlatMenu();
        }
        else
        {
          if (clsMarble.frmOPCommands.CommandType != MarbleItemType.HorizontalVerticalCut)
            return;
          clsInit.appMarble.cmdHorVerBothCut();
        }
      }
      else
      {
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_shape.Name)
          clsInit.appMarble.cmdShapeMenu();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_contour.Name)
          clsInit.appMarble.cmdContourMenu();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_profiling.Name)
          clsInit.appMarble.cmdProfileMenu();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_profilecurve.Name)
          clsInit.appMarble.cmdProfileCurveMenu();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_engraving.Name)
          clsInit.appMarble.cmdEngravingMenu();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_library.Name)
          clsInit.appMarble.cmdLibraryMenu();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_text.Name)
          clsInit.appMarble.cmdTextMenu();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_oplist.Name)
        {
          if (!MarbleCNC.clsItem.FrmMach1.pnl_drawingjob.Visible)
          {
            MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Width = 1120;
            MarbleCNC.clsItem.FrmMach1.pnl_drawingjob.Visible = true;
          }
          else
          {
            MarbleCNC.clsItem.FrmMach1.pnl_drawingjob.Visible = false;
            MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Width = 1450;
          }
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_cadoutside.Name)
        {
          List<buEntity> refEntities = new List<buEntity>();
          if (clsInit.appMarble.cmdCadDrawMenu(ref refEntities) == DialogResult.OK)
            clsInit.appMarble.cmdCadDrawOutside(refEntities);
          refEntities.Clear();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_cadinside.Name)
        {
          List<buEntity> refEntities = new List<buEntity>();
          if (clsInit.appMarble.cmdCadDrawMenu(ref refEntities) == DialogResult.OK)
            clsInit.appMarble.cmdCadDrawInside(refEntities);
          refEntities.Clear();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_move.Name && clsAppMarbleItems.frmMove != null)
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
            clsAppMarbleItems.frmMove.Visible = false;
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_rotate.Name)
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
            clsAppMarbleItems.frmRotate.Visible = false;
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_mirror.Name)
        {
          if (clsAppMarbleItems.frmMirror == null)
            clsAppMarbleItems.frmMirror = new F_MarbleEventMirror();
          clsAppMarbleItems.frmMirror.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
          clsAppMarbleItems.frmMirror.PropertiesForm.FormPosition = FormStartPosition.Manual;
          clsAppMarbleItems.frmMirror.TopMost = false;
          clsAppMarbleItems.frmMirror.Left = 450;
          clsAppMarbleItems.frmMirror.Top = 55;
          clsAppMarbleItems.frmMirror.Init();
          int num = (int) clsAppMarbleItems.frmMirror.ShowDialog();
          if (clsAppMarbleItems.frmMirror.PropertiesForm.Result == DialogResult.OK)
            clsInit.appMarble.doMirrorSelectedItem();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_scale.Name)
        {
          if (clsAppMarbleItems.frmScale == null)
            clsAppMarbleItems.frmScale = new F_MarbleEventScale();
          clsAppMarbleItems.frmScale.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
          clsAppMarbleItems.frmScale.PropertiesForm.FormPosition = FormStartPosition.Manual;
          clsAppMarbleItems.frmScale.TopMost = false;
          clsAppMarbleItems.frmScale.Left = 450;
          clsAppMarbleItems.frmScale.Top = 55;
          List<Entity> refEntities = new List<Entity>();
          for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
          {
            Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
            if (entity.Selected && entity.EntityData != null & entity.EntityData is CustomData)
              refEntities.Add(entity);
          }
          if (refEntities.Count > 0)
          {
            Point3D MinPoint = new Point3D();
            Point3D MidPoint = new Point3D();
            Point3D MaxPoint = new Point3D();
            clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
            buMarbleCalc.varMarbleRunSettings.ScaleWidth = Math.Round(MaxPoint.X - MinPoint.X, 3);
            buMarbleCalc.varMarbleRunSettings.ScaleHeight = Math.Round(MaxPoint.Y - MinPoint.Y, 3);
            clsAppMarbleItems.frmScale.Init();
            int num = (int) clsAppMarbleItems.frmScale.ShowDialog();
            if (clsAppMarbleItems.frmScale.PropertiesForm.Result == DialogResult.OK)
              clsInit.appMarble.doScaleSelectedItem();
          }
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_copy.Name)
        {
          if (clsAppMarbleItems.frmCopy == null)
            clsAppMarbleItems.frmCopy = new F_MarbleEventCopy();
          clsAppMarbleItems.frmCopy.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
          clsAppMarbleItems.frmCopy.PropertiesForm.FormPosition = FormStartPosition.Manual;
          clsAppMarbleItems.frmCopy.Left = 450;
          clsAppMarbleItems.frmCopy.Top = 55;
          clsAppMarbleItems.frmCopy.Init();
          int num = (int) clsAppMarbleItems.frmCopy.ShowDialog();
          if (clsAppMarbleItems.frmCopy.PropertiesForm.Result == DialogResult.OK)
            clsInit.appMarble.doCopySelectedItem(buMarbleCalc.varMarbleRunSettings.CopyXDistance, buMarbleCalc.varMarbleRunSettings.CopyYDistance);
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_copymulti.Name)
        {
          if (clsAppMarbleItems.frmCopyMulti == null)
            clsAppMarbleItems.frmCopyMulti = new F_MarbleEventCopyMulti();
          clsAppMarbleItems.frmCopyMulti.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
          clsAppMarbleItems.frmCopyMulti.PropertiesForm.FormPosition = FormStartPosition.Manual;
          clsAppMarbleItems.frmCopyMulti.Left = 450;
          clsAppMarbleItems.frmCopyMulti.Top = 55;
          clsAppMarbleItems.frmCopyMulti.Init();
          int num = (int) clsAppMarbleItems.frmCopyMulti.ShowDialog();
          if (clsAppMarbleItems.frmCopyMulti.PropertiesForm.Result == DialogResult.OK)
            clsInit.appMarble.doCopySelectedItem(buMarbleCalc.varMarbleRunSettings.CopyXDistance, buMarbleCalc.varMarbleRunSettings.CopyYDistance, buMarbleCalc.varMarbleRunSettings.CopyXCount, buMarbleCalc.varMarbleRunSettings.CopyYCount);
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_alignments.Name && buMarbleForms.frmEventAling != null)
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
            buMarbleForms.frmEventAling.Visible = false;
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_slatadd.Name)
          clsInit.appMarble.doSlatAdd((AddSlatArgs) null);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_collopseadd.Name)
          clsInit.appMarble.doCollopseAdd((AddCollapseArgs) null);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_extend.Name)
          clsInit.appMarble.doExtend();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_break.Name)
          clsInit.appMarble.doBreak();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_offset.Name)
          clsInit.appMarble.doOffset();
        if (control.Name == clsAppMarbleItems.frmRotate.btn_eventrotateplus.Name)
        {
          clsInit.appMarble.doRotateSelectedItem(-clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value);
          buMarbleCalc.varMarbleRunSettings.ManuelRotate = clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value;
        }
        if (control.Name == clsAppMarbleItems.frmRotate.btn_eventRotateminus.Name)
        {
          clsInit.appMarble.doRotateSelectedItem(clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value);
          buMarbleCalc.varMarbleRunSettings.ManuelRotate = clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value;
        }
        if (control.Name == clsAppMarbleItems.frmMove.btn_eventmoveleft.Name)
        {
          clsInit.appMarble.doMoveSelectedItem(-clsAppMarbleItems.frmMove.spn_eventmovevalue.Value, 0.0);
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
          clsInit.appMarble.doMoveSelectedItem(0.0, -clsAppMarbleItems.frmMove.spn_eventmovevalue.Value);
          buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_eventdelete.Name && !clsInit.appMarble.MoveCreatedEntity)
          clsInit.appMarble.doDeleteItems(false, -1);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_eventdeleteall.Name && !clsInit.appMarble.MoveCreatedEntity)
          clsInit.appMarble.doDeleteItems(true, -1);
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_vacuum.Name)
          clsInit.appMarble.cmdVacuum();
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_saveOP.Name)
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
        if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_openOP.Name)
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
        if (!(control.Name == MarbleCNC.clsItem.FrmMach1.btn_undo.Name))
          return;
        clsInit.appMarble.UndoGetback();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void clickCommandsMenuAndSettings(object sender, EventArgs e)
  {
    try
    {
      Control control = sender as Control;
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_closepc.Name && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWanttoClosePC) == DialogResult.Yes)
        clsAppMarbleVars.cmdMarble.cmdClosePC();
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_selectmaterial.Name)
      {
        clsInit.cMarble.ShowMaterialPage();
        clsInit.appMarble.SaveMarbleFile();
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_contoursettings.Name)
      {
        this.MainControlsToParameter(true);
        clsInit.appMarble.cmdContourUserSettingsPage();
        this.MainControlsToParameter(false);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_marblecamsettings.Name)
        clsInit.appMarble.cmdCamSettingsPage();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_millingsettings.Name)
        clsInit.appMarble.cmdSettingsMilling2D(MarbleCamType.MillingContour2D);
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_settingsaxes.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowMachineSettings();
        this.SaveParameter();
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_servoconnection.Name)
        clsAppMarbleVars.cmdMarble.cmdCMZSBDBridge();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_toolsettings.Name)
        clsAppMarbleVars.cmdMarble.ShowMachineSettingsV1(0);
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_tools.Name)
        clsAppMarbleVars.cmdMarble.ShowToolsList(buMarbleCalc.varMarbleSettings.ToolListMode, MarbleToolType.Saw);
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_g54offset.Name)
        clsAppMarbleVars.cmdMarble.ShowG54List();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_vagoonsettings.Name)
        clsAppMarbleVars.cmdMarble.ShowWagonSettings();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_camerasettings.Name)
        clsAppMarbleVars.cmdMarble.ShowCameraSettings();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_calibration.Name)
        clsAppMarbleVars.cmdMarble.ShowCalibration();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_AbsoluteHomeSet.Name)
        clsAppMarbleVars.cmdMarble.ShowAbsoluteSet();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_G54Offset.Name)
        clsAppMarbleVars.cmdMarble.ShowG54Set();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_kinematic.Name)
        clsAppMarbleVars.cmdMarble.ShowKinematic();
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_password.Name)
        clsAppMarbleVars.cmdMarble.ShowPassword();
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_tool.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowTools(-1);
        MarbleCNC.clsItem.FrmMach1.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach1.btn_preset.Name)
      {
        if (clsAppMarbleVars.cmdMarble.ShowPreset(1050, MarbleCNC.clsItem.FrmMach1.chk_addsawthickness.Top) != DialogResult.OK)
          return;
        MarbleCNC.clsItem.FrmMach1.spn_go.Value = buMarbleForms.frmPreset.ReturnVal;
      }
      else
      {
        if (!buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          return;
        MarbleCNC.clsItem.FrmMenuSettings.Visible = false;
      }
    }
    catch (Exception ex)
    {
    }
  }

  private void mouseMoveViewport(object sender, MouseEventArgs e)
  {
    if (!((sender as Control).Name == buEyeItems.viewportCNC.Name))
      return;
    buEyeItems.viewportCNC.ScreenToPlane(e.Location, ccVars.planeActive, out this.pntActive);
    if (this.pntActive != (Point3D) null)
      MarbleCNC.clsItem.FrmMach1.lbl_viewportcoords.Text = $"X: {this.pntActive.X.ToString("f2")} , Y: {this.pntActive.Y.ToString("f2")} , Z: {this.pntActive.Z.ToString("f2")}";
  }

  private void mouseDownViewport(object sender, MouseEventArgs e)
  {
    if (!((sender as Control).Name == buEyeItems.viewportCNC.Name))
      ;
  }

  private void mouseUpViewport(object sender, MouseEventArgs e)
  {
    Control control = sender as Control;
    if (e.Button != MouseButtons.Left || !(control.Name == buEyeItems.viewportCNC.Name))
      ;
  }

  private void checkCheckedChanged(object sender, bool CheckStatus)
  {
    Control control = sender as Control;
    if (!AppBool.Inited)
      return;
    if (control.Name == MarbleCNC.clsItem.FrmMach1.chk_incremental.Name)
    {
      AppBool.Inited = false;
      clsAppMarbleVars.varInterface.IncrementalMode = MarbleCNC.clsItem.FrmMach1.chk_incremental.Check;
      MarbleCNC.clsItem.FrmMach1.chk_absolute.Check = false;
      clsAppMarbleVars.varInterface.AbsoluteMode = false;
      AppBool.Inited = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach1.chk_absolute.Name)
    {
      AppBool.Inited = false;
      clsAppMarbleVars.varInterface.AbsoluteMode = MarbleCNC.clsItem.FrmMach1.chk_absolute.Check;
      MarbleCNC.clsItem.FrmMach1.chk_incremental.Check = false;
      clsAppMarbleVars.varInterface.IncrementalMode = false;
      AppBool.Inited = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach1.chk_addsawthickness.Name)
    {
      AppBool.Inited = false;
      clsAppMarbleVars.varInterface.AddSawThicknessToMove = MarbleCNC.clsItem.FrmMach1.chk_addsawthickness.Check;
      AppBool.Inited = true;
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
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.SpindleSpeedUpdate");
      }
      if (control.Name == clsAppMarbleItems.frmSpeedsV1.track_sawspeed.Name && !clsAppMarbleVars.varApp.SpindlePersentageFromPLC)
      {
        clsAppMarbleItems.frmSpeedsV1.track_sawspeed.Value = Convert.ToInt32(Val);
        clsAppMarbleVars.varInterface.SawSpeedOverride = Val;
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SawSpeedOverride, "AppRun.SawOverride");
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.SawSpeedUpdate");
      }
      if (!clsAppMarbleVars.cMachine.runSystem.SimulatedIO)
        return;
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
    else if (control.Name == clsAppMarbleItems.frmSpeedsV1.track_operationspeed.Name)
    {
      clsMarble.SimStep = Convert.ToInt32(Val / 10.0);
      clsInit.appMarble.timSim.Interval = 20;
      if (clsMarble.SimStep <= 0)
      {
        clsMarble.SimStep = 1;
        clsInit.appMarble.timSim.Interval = 50;
        if (Val == 2.0)
          clsInit.appMarble.timSim.Interval = 100;
        if (Val == 1.0)
          clsInit.appMarble.timSim.Interval = 200;
      }
    }
  }

  private void spinValueChanged(object sender, double Val)
  {
    Control control = sender as Control;
    if (!AppBool.Inited)
      return;
    if (control.Name == MarbleCNC.clsItem.FrmMach1.spn_go.Name)
    {
      AppBool.Inited = false;
      clsAppMarbleVars.varInterface.JogMoveValue = MarbleCNC.clsItem.FrmMach1.spn_go.Value;
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
    clsAppMarbleVars.varApp.MaterialWidth = MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialheight.Value;
    clsAppMarbleVars.varApp.MaterialHeight = MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialwidth.Value;
    clsAppMarbleVars.varApp.MaterialThickness = MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialthickness.Value;
    clsAppMarbleVars.varApp.SemiAutoSafeZ = MarbleCNC.clsItem.FrmMach1.spn_semiautosafedis.Value;
  }

  private void spinClick(object sender, EventArgs e)
  {
    buSpin buSpin = sender as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (buNumeric5.IsNumeric(fKeyPadNumV1.Value))
    {
      buSpin.Value = double.Parse(fKeyPadNumV1.Value);
      if (MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex == 6)
      {
        this.SemiAutoParameterChange(true);
        if (AppBool.Connected)
          clsAppMarbleVars.cmdMarble.WriteSemiAutoParameters();
      }
    }
  }

  private void spinLeave(object sender, EventArgs e)
  {
    if (MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex != 6)
      return;
    this.SemiAutoParameterChange(true);
    if (AppBool.Connected)
      clsAppMarbleVars.cmdMarble.WriteSemiAutoParameters();
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
    if (MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex == 0)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SemiAutoEnable");
      if (MarbleCNC.clsItem.FrmMach1.pnl_mainviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach1.pnl_manuelviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_mainviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_manuelviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_semiauto.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_mainviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_semiauto.Controls[0]);
        buEyeItems.viewportCadCam.ZoomFit();
        buEyeItems.viewportCadCam.ZoomOut(10);
      }
      AppBool.EditMode = false;
    }
    else if (MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex == 1)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SemiAutoEnable");
      if (MarbleCNC.clsItem.FrmMach1.pnl_manuelviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach1.pnl_mainviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_manuelviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_mainviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_semiauto.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_manuelviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_semiauto.Controls[0]);
      }
      AppBool.EditMode = false;
    }
    else if (MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex == 2)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SemiAutoEnable");
      if (MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls[0]);
        if (MarbleCNC.clsItem.FrmMach1.pnl_horsettings.Controls.Count == 0)
        {
          if (MarbleCNC.clsItem.FrmMach1.pnl_versettings.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach1.pnl_horsettings.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_versettings.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach1.pnl_horversettings.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach1.pnl_horsettings.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horversettings.Controls[0]);
        }
        buEyeItems.viewportCadCam.ZoomFit();
        buEyeItems.viewportCadCam.ZoomOut(10);
      }
      clsInit.appMarble.DeleteSimulationEntities();
      AppBool.EditMode = true;
    }
    else if (MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex == 3)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SemiAutoEnable");
      if (MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls[0]);
        if (MarbleCNC.clsItem.FrmMach1.pnl_versettings.Controls.Count == 0)
        {
          if (MarbleCNC.clsItem.FrmMach1.pnl_horsettings.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach1.pnl_versettings.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horsettings.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach1.pnl_horversettings.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach1.pnl_versettings.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horversettings.Controls[0]);
        }
        buEyeItems.viewportCadCam.ZoomFit();
        buEyeItems.viewportCadCam.ZoomOut(10);
      }
      clsInit.appMarble.DeleteSimulationEntities();
      AppBool.EditMode = true;
    }
    else if (MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex == 4)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SemiAutoEnable");
      if (MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls[0]);
        if (MarbleCNC.clsItem.FrmMach1.pnl_horversettings.Controls.Count == 0)
        {
          if (MarbleCNC.clsItem.FrmMach1.pnl_horsettings.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach1.pnl_horversettings.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horsettings.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach1.pnl_versettings.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach1.pnl_horversettings.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_versettings.Controls[0]);
        }
        buEyeItems.viewportCadCam.ZoomFit();
        buEyeItems.viewportCadCam.ZoomOut(10);
      }
      clsInit.appMarble.DeleteSimulationEntities();
      AppBool.EditMode = true;
    }
    else if (MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex == 5)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SemiAutoEnable");
      if (MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_verviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_horverviewport.Controls[0]);
        buEyeItems.viewportCadCam.ZoomFit();
        buEyeItems.viewportCadCam.ZoomOut(10);
      }
      clsInit.appMarble.DeleteSimulationEntities();
      AppBool.EditMode = true;
    }
    else if (MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex == 6)
    {
      if (MarbleCNC.clsItem.FrmMach1.pnl_semiauto.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach1.pnl_mainviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_semiauto.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_mainviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach1.pnl_manuelviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach1.pnl_semiauto.Controls.Add(MarbleCNC.clsItem.FrmMach1.pnl_manuelviewport.Controls[0]);
      }
      AppBool.EditMode = false;
    }
    MarbleTempVars.LastSelectedTabPage = MarbleCNC.clsItem.FrmMach1.buTab_Main.SelectedIndex;
  }

  public void FormKeyDown(object sender, KeyEventArgs e)
  {
    Control control = new Control();
    if (!(((Control) sender).Name == MarbleCNC.clsItem.FrmMach1.Name) || e.KeyCode != Keys.Escape)
      return;
    this.clickCommands((object) MarbleCNC.clsItem.FrmMach1.btn_cancel, new EventArgs());
  }

  public void UpdateVisualThings()
  {
    string str = nameof (UpdateVisualThings);
    try
    {
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started");
      if (buEyeVars.parVisual == null)
        buEyeVars.parVisual = new clsVisualVars();
      MarbleCNC.clsItem.FrmMach1.buTab_Main.ItemSize = new Size(1, 1);
      MarbleCNC.clsItem.FrmMach1.buTab_drawing.ItemSize = new Size(1, 1);
      MarbleCNC.clsItem.FrmMach1.tabPage_Drawing.Text = "";
      MarbleCNC.clsItem.FrmMach1.tabPage_Event.Text = "";
      MarbleCNC.clsItem.FrmMach1.tabPage_Functions.Text = "";
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmCoordsV1");
      clsAppMarbleItems.frmCoordsV1.UpdateVisuals();
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmCoordsV1");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmSpeeds");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmSpeeds");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmViewV1");
      clsAppMarbleItems.frmViewsV1.UpdateVisuals();
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmViewV1");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmViewGCodeV1");
      clsAppMarbleItems.frmGCodeViewV1.UpdateVisuals();
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmViewGCodeV1");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmCommandsV1");
      clsAppMarbleItems.frmCommandsV1.UpdateVisuals();
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmCommandsV1");
      MarbleCNC.clsItem.FrmMach1.btn_contour.Visible = clsVar.UserMode.MarbleMode.FileImport;
      MarbleCNC.clsItem.FrmMach1.btn_library.Visible = clsVar.UserMode.MarbleMode.Library;
      MarbleCNC.clsItem.FrmMach1.btn_profiling.Visible = clsVar.UserMode.MarbleMode.Profile;
      MarbleCNC.clsItem.FrmMach1.btn_profilecurve.Visible = clsVar.UserMode.MarbleMode.Profile;
      MarbleCNC.clsItem.FrmMach1.btn_engraving.Visible = clsVar.UserMode.MarbleMode.Engraving3Axis;
      MarbleCNC.clsItem.FrmMach1.btn_text.Visible = clsVar.UserMode.MarbleMode.Text;
      MarbleCNC.clsItem.FrmMach1.btn_OPMenu.Visible = clsVar.UserMode.MarbleMode.OPMenu;
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished");
      buLogMarbleVer5.saveLogList();
    }
    catch (Exception ex)
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Exception", ex.Message, AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach1.buGround1.Controls);
    if (PageIndex == 0)
    {
      MarbleCNC.clsItem.FrmMach1.btn_main.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach1.btn_main.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      MarbleCNC.clsItem.FrmMach1.btn_manuel.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach1.btn_manuel.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 2)
    {
      MarbleCNC.clsItem.FrmMach1.btn_horizontal.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach1.btn_horizontal.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 3)
    {
      MarbleCNC.clsItem.FrmMach1.btn_vertical.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach1.btn_vertical.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 4)
    {
      MarbleCNC.clsItem.FrmMach1.btn_horver.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach1.btn_horver.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 5)
    {
      MarbleCNC.clsItem.FrmMach1.btn_drawing.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach1.btn_drawing.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 6)
      return;
    MarbleCNC.clsItem.FrmMach1.btn_semiAuto.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach1.btn_semiAuto.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  public void MenuDrawButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach1.pnl_drawing.Controls);
    if (PageIndex == 0)
    {
      MarbleCNC.clsItem.FrmMach1.btn_drawmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach1.btn_drawmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      MarbleCNC.clsItem.FrmMach1.btn_eventmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach1.btn_eventmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 2)
    {
      MarbleCNC.clsItem.FrmMach1.btn_functionsmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach1.btn_functionsmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 3)
      return;
    MarbleCNC.clsItem.FrmMach1.btn_misc.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach1.btn_misc.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  public void OpenParameter()
  {
    try
    {
      clsInit.appMarble.OpenMarbleFile(AppPath.MachineSettingsCam + "\\Marble");
      if (clsInit.appNesting != null)
        clsInit.appNesting.OpenNestingFile();
      if (this.cMarbleVars == null)
        this.cMarbleVars = new clsAppMarbleVars();
      this.cMarbleVars.Init();
      FileInfo fileInfo1 = new FileInfo(AppPath.MachineSettings + "\\Machine.prm");
      if (fileInfo1.Exists)
      {
        ArrayList arrayList = new ArrayList();
        TextReader textReader = (TextReader) File.OpenText(fileInfo1.FullName);
        List<List<string>> CalcList1 = new List<List<string>>();
        string str;
        while ((str = textReader.ReadLine()) != null)
          arrayList.Add((object) str);
        textReader.Close();
        try
        {
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.MachineSetting);
          buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, (object) clsAppMarbleVars.varForms);
          clsAppMarbleVars.cMachine.varCNC2 = new CodesysCNCSets();
          clsAppMarbleVars.cMachine.varCNC3 = new CodesysCNCSets();
          CodesysAxesData codesysAxesData1 = new CodesysAxesData();
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
          buSerilization.Decode(arrayList, "_X", SerilizationMode.MultiLine, (object) codesysAxesData1.AxisPar);
          buSerilization.Decode(arrayList, "_Y", SerilizationMode.MultiLine, (object) codesysAxesData2.AxisPar);
          buSerilization.Decode(arrayList, "_Z", SerilizationMode.MultiLine, (object) codesysAxesData3.AxisPar);
          buSerilization.Decode(arrayList, "_C", SerilizationMode.MultiLine, (object) codesysAxesData5.AxisPar);
          buSerilization.Decode(arrayList, "_A", SerilizationMode.MultiLine, (object) codesysAxesData4.AxisPar);
          buSerilization.Decode(arrayList, "_X2", SerilizationMode.MultiLine, (object) codesysAxesData6.AxisPar);
          buSerilization.Decode(arrayList, "_Y2", SerilizationMode.MultiLine, (object) codesysAxesData7.AxisPar);
          buSerilization.Decode(arrayList, "_Z2", SerilizationMode.MultiLine, (object) codesysAxesData8.AxisPar);
          buSerilization.Decode(arrayList, "_C2", SerilizationMode.MultiLine, (object) codesysAxesData10.AxisPar);
          buSerilization.Decode(arrayList, "_A2", SerilizationMode.MultiLine, (object) codesysAxesData9.AxisPar);
          codesysAxesData1.AxisPar.Base.baseChar = buLangTranslate.preChar.X + "_1";
          codesysAxesData1.AxisPar.Base.baseName = buLangTranslate.preChar.X + "_1";
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
          clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData1);
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
            buString.ListToSpecificList("<G54Offset>", "</G54Offset>", false, arrayList, ref CalcList2);
            for (int index = 0; index <= CalcList2.Count - 1; ++index)
            {
              if (index <= clsAppMarbleVars.cMachine.G54List.Length - 1 & index <= 4)
                clsAppMarbleVars.cMachine.G54List[index] = new Pnt9DS(Pnt9DS.DecodeFromString(CalcList2[index]));
            }
          }
          catch (Exception ex)
          {
          }
          CalcList1 = new List<List<string>>();
          buString.ListToSpecificList("<ToolActiveMilling>", "</ToolActiveMilling>", false, arrayList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            ArrayList AL = new ArrayList();
            AL.AddRange((ICollection) CalcList1[0].ToArray());
            ToolBase5 toolBase5 = new ToolBase5();
            buSerilization5.Decode(AL, "Milling", SerilizationMode5.MultiLine, (object) buMarbleCalc.activeToolMilling);
          }
          CalcList1 = new List<List<string>>();
          buString.ListToSpecificList("<ToolActiveMillingHead>", "</ToolActiveMillingHead>", false, arrayList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            ArrayList AL = new ArrayList();
            AL.AddRange((ICollection) CalcList1[0].ToArray());
            ToolBase5 toolBase5 = new ToolBase5();
            buSerilization5.Decode(AL, "MillingHead", SerilizationMode5.MultiLine, (object) buMarbleCalc.activeToolMillingHead);
          }
          CalcList1 = new List<List<string>>();
          buString.ListToSpecificList("<ToolActiveSaw>", "</ToolActiveSaw>", false, arrayList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            ArrayList AL = new ArrayList();
            AL.AddRange((ICollection) CalcList1[0].ToArray());
            ToolBase5 toolBase5 = new ToolBase5();
            buSerilization5.Decode(AL, "Saw", SerilizationMode5.MultiLine, (object) buMarbleCalc.activeToolSaw);
          }
          List<string> CalcList3 = new List<string>();
          buString.ListToSpecificList("<ToolList>", "</ToolList>", false, arrayList, ref CalcList3);
          if (CalcList3.Count > 0)
          {
            if (buMarbleCalc.ToolMillings == null)
              buMarbleCalc.ToolMillings = new List<ToolBase5>();
            buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", false, CalcList3, ref CalcList1);
            for (int index = 0; index <= CalcList1.Count - 1; ++index)
            {
              ToolBase5 Tool = new ToolBase5();
              ToolBase5.DecodeShort(CalcList1[index], ref Tool);
              buMarbleCalc.ToolMillings.Add(Tool);
            }
          }
          else
          {
            if (buMarbleCalc.ToolMillings == null)
              buMarbleCalc.ToolMillings = new List<ToolBase5>();
            buMarbleCalc.ToolMillings.Add(new ToolBase5()
            {
              Geometry = {
                Diameter = 350.0,
                Thickness = 3.0,
                GeometryType = ToolType.Saw
              },
              Purpose = ToolPurpose.Saw
            });
            for (int count = buMarbleCalc.ToolMillings.Count; count <= 9; ++count)
              buMarbleCalc.ToolMillings.Add(new ToolBase5()
              {
                Geometry = {
                  Diameter = 10.0,
                  Length = 100.0,
                  GeometryType = ToolType.Flat
                },
                Purpose = ToolPurpose.Milling
              });
          }
          buMarbleCalc.activeToolMilling.Purpose = ToolPurpose.Milling;
          buMarbleCalc.activeToolSaw.Purpose = ToolPurpose.Saw;
          buMarbleCalc.activeToolSaw.Geometry.GeometryType = ToolType.Saw;
          buMarbleCalc.activeToolMillingHead.Purpose = ToolPurpose.MillingHead;
        }
        catch (Exception ex)
        {
          buLog.addLog("Open Error Axes Parameter", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Open Error Axes Parameter");
        }
        try
        {
          buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, (object) clsAppMarbleVars.varInterface);
          buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, (object) clsAppMarbleVars.varApp);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.ProgramSettings);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.PLCSettings);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.varSystem);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.varJog);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.varHandWheel);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.varCNC);
          buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, (object) buMarbleCalc.varMarbleRunSettings);
          buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, (object) buMarbleCalc.varMarbleSettings);
          CodesysMachine.CommType = clsAppMarbleVars.cMachine.PLCSettings.CommType;
        }
        catch (Exception ex)
        {
          buLog.addLog("Open Error System Parameter", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Open Error System Parameter");
        }
        arrayList.Clear();
        CalcList1.Clear();
      }
      else
      {
        buLog.addLog("Machine 1 Parameter File Missing", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxInfo("Machine 1 Parameter File Missing");
      }
      FileInfo fileInfo2 = new FileInfo(AppPath.MachineSettings + "\\IO.prm");
      if (fileInfo2.Exists)
      {
        ArrayList RefList = new ArrayList();
        TextReader textReader = (TextReader) File.OpenText(fileInfo2.FullName);
        string str;
        while ((str = textReader.ReadLine()) != null)
          RefList.Add((object) str);
        textReader.Close();
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();
        buString.ListToSpecificList("<Inputs>", "</Inputs>", false, RefList, ref stringList1);
        buString.ListToSpecificList("<Outputs>", "</Outputs>", false, RefList, ref stringList2);
        buString.RemoveCharsFromString(true, true, new List<string>(), ref stringList1);
        buString.RemoveCharsFromString(true, true, new List<string>(), ref stringList2);
        for (int index = 0; index <= stringList1.Count - 1; ++index)
          clsAppMarbleVars.cMachine.Inputs.Add(new DigitalInputData(stringList1[index]));
        for (int index = 0; index <= stringList2.Count - 1; ++index)
          clsAppMarbleVars.cMachine.Outputs.Add(new DigitalOutputData(stringList2[index]));
        buLog.addLog("IO  File Read ", "", "", "Ok", 0);
        RefList.Clear();
      }
      else
      {
        buLog.addLog("Machine 1 IO File Missing", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxInfo("Machine 1 IO File Missing");
      }
      AppBool.TouchPad = buMarbleCalc.varMarbleSettings.TouchPad;
    }
    catch (Exception ex)
    {
    }
  }

  public void SaveParameter() => this.SaveParameter(AppPath.MachineSettings);

  public void SaveParameter(string Path)
  {
    try
    {
      clsInit.appMarble.SaveMarbleFile(Path);
      ArrayList arrayList = new ArrayList();
      string FileName = Path + "\\Machine.prm";
      ArrayList StringList = new ArrayList();
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Machine  Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.MachineSetting.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   PLC  Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.PLCSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   CNC  Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.varCNC.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   App Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.varApp.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Program Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.ProgramSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Interface Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.varInterface.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Machine Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) buMarbleCalc.varMarbleMachineSettings.OptionSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Forms Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.varForms.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) " ");
      if (buMarbleCalc.ToolMillings != null)
      {
        StringList.Add((object) "------------------------------------------------------------------------");
        StringList.Add((object) "   Tool List");
        StringList.Add((object) "------------------------------------------------------------------------");
        StringList.Add((object) "  <ToolList>");
        for (int index = 0; index <= buMarbleCalc.ToolMillings.Count - 1; ++index)
        {
          if (buMarbleCalc.ToolMillings[index] != null)
          {
            StringList.Add((object) "    <ToolListBase>");
            StringList.AddRange((ICollection) ToolBase5.ToDefShort(6, buMarbleCalc.ToolMillings[index]));
            StringList.Add((object) "    </ToolListBase>");
          }
        }
        StringList.Add((object) "  </ToolList>");
        StringList.Add((object) "");
      }
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Tool Active");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "  <ToolActiveMilling>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolMilling.ToDefAll("Milling", 4, SerilizationMode5.MultiLine));
      StringList.Add((object) "  </ToolActiveMilling>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveMillingHead>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolMillingHead.ToDefAll("MillingHead", 4, SerilizationMode5.MultiLine));
      StringList.Add((object) "  </ToolActiveMillingHead>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveSaw>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolSaw.ToDefAll("Saw", 4, SerilizationMode5.MultiLine));
      StringList.Add((object) "  </ToolActiveSaw>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveLaser>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolLaserPointer.ToDefAll("Laser", 4, SerilizationMode5.MultiLine));
      StringList.Add((object) "  </ToolActiveLaser>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveAirDry>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolAirDry.ToDefAll("airDry", 4, SerilizationMode5.MultiLine));
      StringList.Add((object) "  </ToolActiveAirDry>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveWaterJet>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolWaterjet.ToDefAll("Waterjet", 4, SerilizationMode5.MultiLine));
      StringList.Add((object) "  </ToolActiveWaterJet>");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   G54 Offsets");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "  <G54Offset>");
      for (int index = 0; index <= clsAppMarbleVars.cMachine.G54List.Length - 1; ++index)
      {
        if (index <= clsAppMarbleVars.cMachine.MachineSetting.G54Count - 1)
          StringList.Add((object) ("    " + clsAppMarbleVars.cMachine.G54List[index].ToDef()));
      }
      StringList.Add((object) "  </G54Offset>");
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   X1 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.ToDefAll("_X", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Y1 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.ToDefAll("_Y", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Z1 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.ToDefAll("_Z", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   C1 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.ToDefAll("_C", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   A1 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.ToDefAll("_A", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   X2 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX2].AxisPar.ToDefAll("_X2", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Y2 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.ToDefAll("_Y2", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Z2 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ2].AxisPar.ToDefAll("_Z2", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   C2 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC2].AxisPar.ToDefAll("_C2", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   A2 Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA2].AxisPar.ToDefAll("_A2", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   System Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.varSystem.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Jog Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.varJog.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Handwheel Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.varHandWheel.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      buFile.SaveToFile(StringList, FileName);
    }
    catch (Exception ex)
    {
    }
  }

  public void SemiAutoParameterChange(bool FromControlToValues)
  {
    if (FromControlToValues)
    {
      clsAppMarbleVars.varApp.SemiAutoWidth = MarbleCNC.clsItem.FrmMach1.spn_semiautohorizontallen.Value;
      clsAppMarbleVars.varApp.SemiAutoHeight = MarbleCNC.clsItem.FrmMach1.spn_semiautoverticallen.Value;
      clsAppMarbleVars.varApp.SemiAutoCutFeed = MarbleCNC.clsItem.FrmMach1.spn_semiautocuttingspeed.Value;
      clsAppMarbleVars.varApp.SemiAutoPlungeFeed = MarbleCNC.clsItem.FrmMach1.spn_semiautoplungespeed.Value;
      clsAppMarbleVars.varApp.SemiAutoTargetZ = MarbleCNC.clsItem.FrmMach1.spn_semiautooperationz.Value;
      clsAppMarbleVars.varApp.SemiAutoSafeZ = MarbleCNC.clsItem.FrmMach1.spn_semiautosafedis.Value;
      clsAppMarbleVars.varApp.MaterialHeight = MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialheight.Value;
      clsAppMarbleVars.varApp.MaterialWidth = MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialwidth.Value;
      clsAppMarbleVars.varApp.MaterialThickness = MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialthickness.Value;
    }
    else
    {
      MarbleCNC.clsItem.FrmMach1.spn_semiautohorizontallen.Value = clsAppMarbleVars.varApp.SemiAutoWidth;
      MarbleCNC.clsItem.FrmMach1.spn_semiautoverticallen.Value = clsAppMarbleVars.varApp.SemiAutoHeight;
      MarbleCNC.clsItem.FrmMach1.spn_semiautocuttingspeed.Value = clsAppMarbleVars.varApp.SemiAutoCutFeed;
      MarbleCNC.clsItem.FrmMach1.spn_semiautoplungespeed.Value = clsAppMarbleVars.varApp.SemiAutoPlungeFeed;
      MarbleCNC.clsItem.FrmMach1.spn_semiautooperationz.Value = clsAppMarbleVars.varApp.SemiAutoTargetZ;
      MarbleCNC.clsItem.FrmMach1.spn_semiautosafedis.Value = clsAppMarbleVars.varApp.SemiAutoSafeZ;
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialheight.Value = clsAppMarbleVars.varApp.MaterialHeight;
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialwidth.Value = clsAppMarbleVars.varApp.MaterialWidth;
      MarbleCNC.clsItem.FrmMach1.spn_semiautomaterialthickness.Value = clsAppMarbleVars.varApp.MaterialThickness;
    }
  }

  public void MainControlsToParameter(bool FromControlToValues)
  {
    if (FromControlToValues)
    {
      buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity = MarbleCNC.clsItem.FrmMach1.spn_camcuttingspped.Value;
      buMarbleCalc.varOperation.MaterialParameter.MaterialThickness = MarbleCNC.clsItem.FrmMach1.spn_cammarblethickness.Value;
      buMarbleCalc.varOperation.settingMarbleCam.TargetZ = MarbleCNC.clsItem.FrmMach1.spn_camoperationZ.Value;
      buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity = MarbleCNC.clsItem.FrmMach1.spn_camplungespeed.Value;
      buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance = MarbleCNC.clsItem.FrmMach1.spn_camcuttingstep.Value;
      buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance = MarbleCNC.clsItem.FrmMach1.spn_camsafedis.Value;
      buMarbleCalc.varMarbleRunSettings.CutLengthVertical = buMarbleForms.frmVertical.spn_itemlength.Value;
      buMarbleCalc.varMarbleRunSettings.CutLengthHorizontal = buMarbleForms.frmHorizontal.spn_itemlength.Value;
      buMarbleCalc.activeToolSaw.CamData.SpindleSpeed = MarbleCNC.clsItem.FrmMach1.spn_camspindlespeed.Value;
    }
    else
    {
      MarbleCNC.clsItem.FrmMach1.spn_camcuttingspped.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity;
      MarbleCNC.clsItem.FrmMach1.spn_cammarblethickness.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
      MarbleCNC.clsItem.FrmMach1.spn_camoperationZ.Value = buMarbleCalc.varOperation.settingMarbleCam.TargetZ;
      MarbleCNC.clsItem.FrmMach1.spn_camplungespeed.Value = buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity;
      MarbleCNC.clsItem.FrmMach1.spn_camcuttingstep.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance;
      MarbleCNC.clsItem.FrmMach1.spn_camsafedis.Value = buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance;
      buMarbleForms.frmVertical.spn_itemlength.Value = buMarbleCalc.varMarbleRunSettings.CutLengthVertical;
      buMarbleForms.frmHorizontal.spn_itemlength.Value = buMarbleCalc.varMarbleRunSettings.CutLengthHorizontal;
      MarbleCNC.clsItem.FrmMach1.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
    }
  }

  public void MarbleCoreCommends(MarbleEventCommands Cmd, MarbleCommandArgs Data)
  {
    switch (Cmd)
    {
      case MarbleEventCommands.JobUpdate:
        for (int Index = 0; Index <= clsInit.appMarble.activeJob.Items.Count - 1; ++Index)
          clsAppMarbleVars.cmdMarble.SetJobOperationItemByJobIndex(Index);
        break;
      case MarbleEventCommands.SelectionUpdate:
        clsAppMarbleVars.cmdMarble.JopItemUpdateAll();
        break;
      case MarbleEventCommands.MoveMouse:
        if (Data != null)
          MarbleCNC.clsItem.FrmMach1.lbl_viewportcoords.Text = $"X: {Data.pntMove.X.ToString("f2")} , Y: {Data.pntMove.Y.ToString("f2")} , Z: {Data.pntMove.Z.ToString("f2")}";
        break;
    }
  }

  public void ShowWarning(string Message, Color clr)
  {
    MarbleCNC.clsItem.FrmMach1.lbl_warning.Visible = true;
    MarbleCNC.clsItem.FrmMach1.lbl_warning.Text = Message;
    MarbleCNC.clsItem.FrmMach1.lbl_warning.BackColor = clr;
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
    catch (Exception ex)
    {
      string Command1 = "";
      if (Args.Count > 0)
        Command1 = Args[0].ToString();
      buLog.addLog(Command1, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return false;
    }
  }

  public void RunGeneralCommand(GeneralCommandEventArg e)
  {
  }

  public void showMenuPage(object sender, EventArgs e)
  {
    MarbleCNC.clsItem.FrmMenu.StartPosition = FormStartPosition.CenterParent;
    MarbleCNC.clsItem.FrmMenu.LoadLanguage();
    int num = (int) MarbleCNC.clsItem.FrmMenu.ShowDialog((IWin32Window) MarbleCNC.clsItem.FrmMach1);
  }

  public void showSettingsPage(object sender, EventArgs e)
  {
    MarbleCNC.clsItem.FrmMenuSettings.StartPosition = FormStartPosition.CenterParent;
    MarbleCNC.clsItem.FrmMenuSettings.LoadLanguage();
    int num = (int) MarbleCNC.clsItem.FrmMenuSettings.ShowDialog((IWin32Window) MarbleCNC.clsItem.FrmMach1);
  }

  public void showLanguageMenu(object sender, EventArgs e)
  {
    if (AppSecurity.PasswordLevel < 2)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentences.PasswordLevelNotEnough);
    }
    else
    {
      clsAppMarbleVars.cmdMarble.ShowLanguageMenu();
      MarbleCNC.clsItem.FrmMach1.LoadLanguage();
      MarbleCNC.clsItem.FrmMenu.LoadLanguage();
      MarbleCNC.clsItem.FrmMenuSettings.LoadLanguage();
      if (!buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
        return;
      MarbleCNC.clsItem.FrmMenu.Visible = false;
    }
  }

  public void showReportPage(object sender, EventArgs e)
  {
    clsAppMarbleVars.cmdMarble.ShowReport();
    if (!buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
      return;
    MarbleCNC.clsItem.FrmMenu.Visible = false;
  }

  public void showDebug(object sender, EventArgs e)
  {
    clsAppMarbleVars.cmdMarble.ShowReport();
    if (!buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
      return;
    MarbleCNC.clsItem.FrmMenu.Visible = false;
  }

  public void showWatch(object sender, EventArgs e)
  {
    clsAppMarbleVars.cmdMarble.ShowWatch();
    if (!buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
      return;
    MarbleCNC.clsItem.FrmMenu.Visible = false;
  }

  public void showTestPage(object sender, EventArgs e)
  {
    clsAppMarbleVars.cmdMarble.ShowTest();
    if (!buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
      return;
    MarbleCNC.clsItem.FrmMenu.Visible = false;
  }

  public void showSimulationPanel(object sender, EventArgs e)
  {
    clsInit.appMarble.doSimulationCalculate(ref clsInit.appMarble.activeJob);
    clsInit.appMarble.cmdShowSimulationPanel();
    if (!ccVars.Pages[ccVars.PageIndex].Form.viewportcad.IsAnimationRunning)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartAnimation();
    clsInit.appMarble.DeleteSimulationEntities();
    clsInit.appMarble.DrawSimulationEntities(false, true, true, MarbleToolType.Saw);
    clsInit.appMarble.MoveSimPart(new Pnt6DSimMove(-290.0, -200.0, 500.0, 0.0, 0.0, 0.0), false, buMarbleCalc.activeToolSaw);
    MarbleCNC.clsItem.FrmMenu.Visible = false;
  }

  public void ThreadLoop()
  {
    while (buPLCHandler.ThreadEnable)
    {
      bool flag = true;
      if (AppBool.Inited & AppBool.Connected & flag)
      {
        if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
        {
          if (buPLCHandler.PLCStatus == 4)
            ;
          if (clsAppMarbleVars.cMachine.miscVar.cntCommunication % 2 == 0 & AppBool.Inited)
            clsAppMarbleVars.cMachine.Commands.ReadAxisGroup(new ReadAxisDataBits(true, true, true, true), ref clsAppMarbleVars.cMachine.AppAxis);
        }
        if (AppBool.Inited)
        {
          if (clsAppMarbleVars.cMachine.miscVar.cntCommunication % 2 == 0 & AppBool.Inited)
            clsAppMarbleVars.cMachine.Commands.ReadAxisGroup(new ReadAxisDataBits(true, true, true, true), ref clsAppMarbleVars.cMachine.AppAxis);
          this.ReadLRealValues();
          this.ReadBOOLValues();
          this.ReadDINTValues();
          clsAppMarbleVars.cMachine.runSystem.FirstPLCRead = true;
        }
        if (clsAppMarbleItems.frmDigitalInputOutput.Visible)
          clsAppMarbleVars.cmdMarble.ReadIOBOOLValues();
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
          clsAppMarbleVars.cmdMarble.WriteToolParameter(true);
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
  }

  public void ReadLRealValues() => clsAppMarbleVars.cmdMarble.ReadLRealValues();

  public void ReadRealValues() => clsAppMarbleVars.cmdMarble.ReadRealValues();

  public void ReadDINTValues() => clsAppMarbleVars.cmdMarble.ReadDINTValues();

  public void ReadBOOLValues() => clsAppMarbleVars.cmdMarble.ReadBOOLValues();
}
