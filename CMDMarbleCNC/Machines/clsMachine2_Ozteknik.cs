// Decompiled with JetBrains decompiler
// Type: MarbleCNC.Machines.clsMachine2_Ozteknik
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
using buMutliTextbox;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable disable
namespace MarbleCNC.Machines;

public class clsMachine2_Ozteknik
{
  private Point3D pntActive = new Point3D();
  private bool Inited = false;
  private string sClass = "clsMachine1_5Axis";
  private clsAppMarbleVars cMarbleVars = (clsAppMarbleVars) null;
  public const int indexMainTab = 0;
  public const int indexManuelTab = 1;
  public const int indexSawModeTab = 2;
  public const int indexOpertionTab = 3;
  private Color clrRed = Color.FromArgb((int) byte.MaxValue, 187, 30, 16 /*0x10*/);
  private Color clrWhite = Color.FromArgb((int) byte.MaxValue, 241, 240 /*0xF0*/, 234);
  private Color clrBlack = Color.FromArgb((int) byte.MaxValue, 14, 14, 16 /*0x10*/);
  private Color clrGray = Color.FromArgb((int) byte.MaxValue, 56, 62, 66);
  private Color clrGrayLight = Color.FromArgb((int) byte.MaxValue, 100, 110, 120);
  private Color clrFontColorWhite = Color.WhiteSmoke;
  private Color clrBackLabelCaption = Color.FromArgb((int) byte.MaxValue, 241, 240 /*0xF0*/, 234);
  private Color clrForeLabelCaption = Color.Black;

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
    string str = nameof (SystemInit);
    try
    {
      this.AppMarbleClassInit();
      CodesysMachine.CommType = CommunicationType.PlcHandler;
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", nameof (SystemInit));
      clsInit.appMarble.Init();
      clsAppMarbleVars.cmdMarble.Init();
      clsAppMarbleVars.cmdMarble.InitSystem();
      this.AssingControls();
      this.AddControls();
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "AddControls");
      this.UpdateVisualThings();
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "UpdateVisualThings");
      clsAppMarbleVars.cmdMarble.CommandHMI += new OkCommandWithFiveDataEventHandler(this.CommandHMI);
      clsInit.appMarble.SimUpdated += new MarbleSimCoordinateUpdated(clsAppMarbleVars.cmdMarble.SimUpdated);
      clsInit.appMarble.MarbleCoreHMICommand += new OkCommandWithFiveDataEventHandler(this.MarbleCoreCommends);
      clsInit.cMwCalc.Settings.ShowMwDialogBox = false;
      MarbleCNC.clsItem.FrmMach2.KeyPreview = true;
      MarbleCNC.clsItem.FrmMach2.KeyDown += new KeyEventHandler(this.FormKeyDown);
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "Move Controls");
      buMarbleForms.frmHorizontalV4.pnl_data.Height = MarbleCNC.clsItem.FrmMach2.pnl_hordata.Height;
      MarbleCNC.clsItem.FrmMach2.pnl_hordata.Controls.Add((Control) buMarbleForms.frmHorizontalV4.pnl_data);
      buMarbleForms.frmVerticalV4.pnl_data.Height = MarbleCNC.clsItem.FrmMach2.pnl_verdata.Height;
      MarbleCNC.clsItem.FrmMach2.pnl_verdata.Controls.Add((Control) buMarbleForms.frmVerticalV4.pnl_data);
      buMarbleForms.frmHorVerHorV4.pnl_data.Height = MarbleCNC.clsItem.FrmMach2.tabPage_Hor.Height;
      MarbleCNC.clsItem.FrmMach2.tabPage_Hor.Controls.Add((Control) buMarbleForms.frmHorVerHorV4.pnl_data);
      buMarbleForms.frmHorVerVerV4.pnl_data.Height = MarbleCNC.clsItem.FrmMach2.tabPage_Ver.Height;
      MarbleCNC.clsItem.FrmMach2.tabPage_Ver.Controls.Add((Control) buMarbleForms.frmHorVerVerV4.pnl_data);
      buMarbleForms.frmSingleV2.pnl_data.Height = MarbleCNC.clsItem.FrmMach2.pnl_singledata.Height;
      MarbleCNC.clsItem.FrmMach2.pnl_singledata.Controls.Add((Control) buMarbleForms.frmSingleV2.pnl_data);
      MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Width = 1450;
      MarbleCNC.clsItem.FrmMach2.pnl_drawingjob.Visible = false;
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "Move Controls");
      MarbleCNC.clsItem.FrmMach2.btn_menu.Click += new EventHandler(this.showMenuPage);
      MarbleCNC.clsItem.FrmMenu.btn_settings.Click += new EventHandler(this.showSettingsPage);
      MarbleCNC.clsItem.FrmMenu.btn_adminsettings.Click += new EventHandler(this.showAdminSettingsPage);
      MarbleCNC.clsItem.FrmMenu.btn_simulationpanel.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_selectmaterial.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_closepc.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_test.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_password.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_tools.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_g54offset.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_report.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_calculations.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_maintanance.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_warmup.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenu.btn_materialmeasurement.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_settingsaxes.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_millingsettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_marblecamsettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_servoconnection.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_G54Offset.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_AbsoluteHomeSet.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_calibration.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_toolsettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_vagoonsettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_camerasettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuSettings.btn_cameracalibration.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_language.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_debug.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_watch.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_counters.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_techniciandefine.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_userdefine.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_loadbackup.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMenuAdminSettings.btn_userinterfacesettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_operationsettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_contoursettings.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewback.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewfront.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewiso.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewleft.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewrgiht.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewtop.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewzoomwindow.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewzoomfit.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewzoomin.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewzoomout.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewpandown.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewpanleft.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewpanright.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_viewpanup.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_information.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.btn_main.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_manuel.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_drawing.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_viewmenu.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_single.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_horizontal.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_vertical.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_horver.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_semiAuto.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_photo.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_pointer.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_2DCad.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_3DCad.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_Functions.Click += new EventHandler(this.clickCommandMainMenuButton);
      MarbleCNC.clsItem.FrmMach2.btn_misc.Click += new EventHandler(this.clickCommandMainMenuButton);
      buMarbleForms.frmHorizontalV4.DGV_items.Tag = (object) "Hor";
      buMarbleForms.frmHorizontalV4.chk_leftbottom.Name += "Hor";
      buMarbleForms.frmHorizontalV4.chk_lefttop.Name += "Hor";
      buMarbleForms.frmHorizontalV4.chk_cutstart.Name += "Hor";
      buMarbleForms.frmHorizontalV4.chk_cutend.Name += "Hor";
      for (int index = 0; index <= buMarbleForms.frmHorizontalV4.pnl_data.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmHorizontalV4.pnl_data.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmHorizontalV4.pnl_data.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "HorVer")
          {
            control.Aux.AuxInfo = "Hor";
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmHorizontalV4.pnl_data.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmHorizontalV4.pnl_data.Controls[index] as buButton;
          control.Aux.AuxInfo = "Hor";
          control.Name += "Hor";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click);
        }
        if (buMarbleForms.frmHorizontalV4.pnl_data.Controls[index] is buCheckBox)
        {
          buCheckBox control = buMarbleForms.frmHorizontalV4.pnl_data.Controls[index] as buCheckBox;
          control.Aux.AuxInfo = "Hor";
          control.Name += "Hor";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click);
        }
      }
      buMarbleForms.frmVerticalV4.DGV_items.Tag = (object) "Ver";
      buMarbleForms.frmVerticalV4.chk_leftbottom.Name += "Ver";
      buMarbleForms.frmVerticalV4.chk_lefttop.Name += "Ver";
      buMarbleForms.frmVerticalV4.chk_cutstart.Name += "Ver";
      buMarbleForms.frmVerticalV4.chk_cutend.Name += "Ver";
      for (int index = 0; index <= buMarbleForms.frmVerticalV4.pnl_data.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmVerticalV4.pnl_data.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmVerticalV4.pnl_data.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "HorVer")
          {
            control.Aux.AuxInfo = "Ver";
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmVerticalV4.pnl_data.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmVerticalV4.pnl_data.Controls[index] as buButton;
          control.Aux.AuxInfo = "Ver";
          control.Name += "Ver";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click);
        }
        if (buMarbleForms.frmVerticalV4.pnl_data.Controls[index] is buCheckBox)
        {
          buCheckBox control = buMarbleForms.frmVerticalV4.pnl_data.Controls[index] as buCheckBox;
          control.Aux.AuxInfo = "Ver";
          control.Name += "Ver";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click);
        }
      }
      buMarbleForms.frmHorVerHorV4.DGV_items.Tag = (object) "HorVerHor";
      buMarbleForms.frmHorVerHorV4.chk_leftbottom.Name += "HorVerHor";
      buMarbleForms.frmHorVerHorV4.chk_lefttop.Name += "HorVerHor";
      buMarbleForms.frmHorVerHorV4.chk_cutstart.Name += "HorVerHor";
      buMarbleForms.frmHorVerHorV4.chk_cutend.Name += "HorVerHor";
      for (int index = 0; index <= buMarbleForms.frmHorVerHorV4.pnl_data.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmHorVerHorV4.pnl_data.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmHorVerHorV4.pnl_data.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "HorVer")
          {
            control.Aux.AuxInfo = "HorVerHor";
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmHorVerHorV4.pnl_data.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmHorVerHorV4.pnl_data.Controls[index] as buButton;
          control.Aux.AuxInfo = "HorVerHor";
          control.Name += "HorVerHor";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click);
        }
        if (buMarbleForms.frmHorVerHorV4.pnl_data.Controls[index] is buCheckBox)
        {
          buCheckBox control = buMarbleForms.frmHorVerHorV4.pnl_data.Controls[index] as buCheckBox;
          control.Aux.AuxInfo = "HorVerHor";
          control.Name += "HorVerHor";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click);
        }
      }
      buMarbleForms.frmHorVerVerV4.DGV_items.Tag = (object) "HorVerVer";
      buMarbleForms.frmHorVerVerV4.chk_leftbottom.Name += "HorVerVer";
      buMarbleForms.frmHorVerVerV4.chk_lefttop.Name += "HorVerVer";
      buMarbleForms.frmHorVerVerV4.chk_cutstart.Name += "HorVerVer";
      buMarbleForms.frmHorVerVerV4.chk_cutend.Name += "HorVerVer";
      for (int index = 0; index <= buMarbleForms.frmHorVerVerV4.pnl_data.Controls.Count - 1; ++index)
      {
        if (buMarbleForms.frmHorVerVerV4.pnl_data.Controls[index] is buSpin)
        {
          buSpin control = buMarbleForms.frmHorVerVerV4.pnl_data.Controls[index] as buSpin;
          if (control.Aux.AuxInfo == "HorVer")
          {
            control.Aux.AuxInfo = "HorVerVer";
            control.KeyDown += new KeyEventHandler(clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown);
          }
          control.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
          control.Enter += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Enter);
          control.Leave += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Leave);
        }
        if (buMarbleForms.frmHorVerVerV4.pnl_data.Controls[index] is buButton)
        {
          buButton control = buMarbleForms.frmHorVerVerV4.pnl_data.Controls[index] as buButton;
          control.Aux.AuxInfo = "HorVerVer";
          control.Name += "HorVerVer";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click);
        }
        if (buMarbleForms.frmHorVerVerV4.pnl_data.Controls[index] is buCheckBox)
        {
          buCheckBox control = buMarbleForms.frmHorVerVerV4.pnl_data.Controls[index] as buCheckBox;
          control.Aux.AuxInfo = "HorVerVer";
          control.Name += "HorVerVer";
          control.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click);
        }
      }
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
      buMarbleForms.frmSingleV2.spn_signlecutAAngle.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
      buMarbleForms.frmSingleV2.spn_signlecutlength.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
      buMarbleForms.frmSingleV2.spn_signlecutCAngle.ValueClicked += new EventHandler(clsAppMarbleVars.cmdMarble.spn_item_Click);
      buMarbleForms.frmSingleV2.btn_itemsinglecutok.Click += new EventHandler(clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click);
      MarbleCNC.clsItem.FrmMach2.btn_pointerpartpoints.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_pointersave.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_pointerslabborders.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_pointercreatematerial.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_pointercreatepart.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_pointereditdrawing.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_pointerrectmaterial.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_photodelete.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_photoget.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_photoimport.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_photodrawpart.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_photoslabborders.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_photosave.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_shape.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_library.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_contour.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_engraving.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_slices.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_profiling.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_profilecurve.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_oplist.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_text.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_sweep.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_cavity.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_tap.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_materialclean.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_saveOP.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_openOP.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_menuOP.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_move.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_rotate.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_mirror.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_scale.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_alignments.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_copy.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_copymulti.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_offset.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_slatadd.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_collopseadd.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_extend.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_break.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_vacuum.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_undo.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_eventdelete.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_eventdeleteall.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_eventdeleteall2.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_eventsetangle.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_dimensionaligned.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_dimensionlinear.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_dimensionmenu.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_dimensiondelete.Click += new EventHandler(this.clickCommandsDrawing);
      MarbleCNC.clsItem.FrmMach2.btn_dimensiondeleteall.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmRotate.btn_eventRotateminus.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmRotate.btn_eventrotateplus.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmMove.btn_eventmovedown.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmMove.btn_eventmoveleft.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmMove.btn_eventmoveright.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmMove.btn_eventmoveup.Click += new EventHandler(this.clickCommandsDrawing);
      clsAppMarbleItems.frmBottomPanelV1.btn_parkpos.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_g54list.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_laser.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_parklist.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_toolpage.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_water.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_partzero.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_gcodemaximize.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_mdi.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_material.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_GCodeUp.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_GCodeDown.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_OPDown.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmBottomPanelV1.btn_OPUp.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmCoordsV2.btn_start.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmCoordsV2.btn_pause.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmCoordsV2.btn_reset.Click += new EventHandler(this.clickCommands);
      if (clsAppMarbleItems.frmMachineSettingsV2 != null)
      {
        clsAppMarbleItems.frmMachineSettingsV2.btn_laserOnOff.Click += new EventHandler(this.clickCommands);
        clsAppMarbleItems.frmMachineSettingsV2.btn_rocketdown.Click += new EventHandler(this.clickCommands);
        clsAppMarbleItems.frmMachineSettingsV2.btn_rocketup.Click += new EventHandler(this.clickCommands);
        clsAppMarbleItems.frmMachineSettingsV2.btn_materialmeasureUpDown.Click += new EventHandler(this.clickCommands);
      }
      clsAppMarbleItems.frmCoordsV2.track_spidle.ValueChanged += new buTrack.ValueChangedEventHandler(this.trackValueChanged);
      clsAppMarbleItems.frmCoordsV2.track_operationspeed.ValueChanged += new buTrack.ValueChangedEventHandler(this.trackValueChanged);
      clsAppMarbleItems.frmCoordsV2.track_quickspeed.ValueChanged += new buTrack.ValueChangedEventHandler(this.trackValueChanged);
      MarbleCNC.clsItem.FrmMach2.btn_cancel.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_codecreate.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_codecreate2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_A0.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_A45.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_A46.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_A90.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_c180.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_c270.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_c90.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_c0.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_a0_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_a45_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_a46_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_c180_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_c_90_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_c90_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_c0_2.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_go.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_tcp.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_gozero.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_park.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_vagonpark.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_materialmeasure.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_light.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_spindlepistondown.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_spindlepistonup.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_spindlewarm.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_sawwarm.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_sawpark.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_spindlepark.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_spindleheadpark.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_cameraclose.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_cameraopen.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_camera.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_photopos.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_vacuumair.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_vacuumdown.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_vacuumup.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_vacuumleftpad.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_vacuumrightpad.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineClose.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineopen.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_pensopenclose.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_stop.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMDIPageV1.btn_pensopenclose.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      clsAppMarbleItems.frmMDIPageV1.btn_spindlepistondown.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      clsAppMarbleItems.frmMDIPageV1.btn_spindlepistonup.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineopen.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineClose.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      clsAppMarbleItems.frmKinematic.btn_openkinematic.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      clsAppMarbleItems.frmKinematic.btn_savekinemtic.Click += new EventHandler(clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic);
      MarbleCNC.clsItem.FrmMenuSettings.btn_kinematic.Click += new EventHandler(this.clickCommandsMenuAndSettings);
      MarbleCNC.clsItem.FrmMach2.chk_absolute.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(this.checkCheckedChanged);
      MarbleCNC.clsItem.FrmMach2.chk_incremental.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(this.checkCheckedChanged);
      MarbleCNC.clsItem.FrmMach2.chk_machinezero.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(this.checkCheckedChanged);
      MarbleCNC.clsItem.FrmMach2.chk_partzero.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(this.checkCheckedChanged);
      MarbleCNC.clsItem.FrmMach2.chk_addsawthickness.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(this.checkCheckedChanged);
      MarbleCNC.clsItem.FrmMach2.spn_xpos.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.spn_ypos.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.spn_zpos.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.spn_apos.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.spn_cpos.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.btn_xplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_yplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_zplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_aplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_cplus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_xminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_yminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_zminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_aminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_cminus.MouseDownWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseDown);
      MarbleCNC.clsItem.FrmMach2.btn_xplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_yplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_zplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_aplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_cplus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_xminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_yminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_zminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_aminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_cminus.MouseUpWithWndProc += new MouseEventHandler(clsAppMarbleVars.cmdMarble.Jog_MouseUp);
      MarbleCNC.clsItem.FrmMach2.btn_xplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.btn_yplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.btn_zplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.btn_aplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.btn_cplus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.btn_xminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.btn_yminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.btn_zminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.btn_aminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.btn_cminus.Click += new EventHandler(clsAppMarbleVars.cmdMarble.Jog_Click);
      MarbleCNC.clsItem.FrmMach2.spn_camcuttingspped.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_camcuttingstep.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_cammarblethickness.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_camoperationZ.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_camplungespeed.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_camsafedis.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_camspindlespeed.ValueClicked += new EventHandler(this.spinClick);
      this.SemiAutoParameterChange(false);
      MarbleCNC.clsItem.FrmMach2.btn_xplus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach2.btn_yplus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach2.btn_zplus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach2.btn_xminus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach2.btn_yminus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach2.btn_zminus_2.Click += new EventHandler(clsAppMarbleVars.cmdMarble.JogSemiAuto_Click);
      MarbleCNC.clsItem.FrmMach2.btn_stopsemiauto.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.btn_semiautoenable.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmMach2.spn_semiautohorizontallen.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialheight.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialwidth.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.spn_semiautoverticallen.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.spn_semiautohorizontallen.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialheight.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialwidth.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach2.spn_semiautoverticallen.Leave += new EventHandler(this.spinLeave);
      MarbleCNC.clsItem.FrmMach2.spn_semiautohorizontallen.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialheight.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialwidth.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_semiautoverticallen.ValueClicked += new EventHandler(this.spinClick);
      MarbleCNC.clsItem.FrmMach2.spn_semiautohorizontallen.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialheight.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialwidth.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmMach2.spn_semiautoverticallen.KeyDown += new KeyEventHandler(this.spinKeyDown);
      MarbleCNC.clsItem.FrmCameraLive.btn_camerastart.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmCameraLive.btn_camerastop.Click += new EventHandler(this.clickCommands);
      MarbleCNC.clsItem.FrmCameraLive.btn_cameratakeshot.Click += new EventHandler(this.clickCommands);
      clsAppMarbleItems.frmMove.spn_eventmovevalue.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      clsAppMarbleItems.frmRotate.spn_eventrotatevalue.ValueChanged += new buControlEvents.buValueChangedEvent(this.spinValueChanged);
      MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndexChanged += new EventHandler(this.buTabSelectedIndexChanged);
      MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndexChanged += new EventHandler(this.buTabSelectedIndexChanged);
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
      MarbleCNC.clsItem.FrmMach2.pnl_mainviewport.Controls.Add((Control) buEyeItems.viewportCNC);
      clsInit.appMarble.ViewportCadCamInit();
      MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Add((Control) buEyeItems.viewportCadCam);
      buEyeItems.viewportCadCam.ActiveViewport.Rotate.Enabled = buMarbleCalc.varMarbleRunSettings.RotateCameraCadCam;
      buVector5.baseModel = buEyeItems.viewportCadCam;
      clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelRotate;
      clsAppMarbleItems.frmMove.spn_eventmovevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelMove;
      MarbleCNC.clsItem.FrmMach2.spn_camcuttingspped.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity;
      MarbleCNC.clsItem.FrmMach2.spn_cammarblethickness.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
      MarbleCNC.clsItem.FrmMach2.spn_camoperationZ.Value = buMarbleCalc.varOperation.settingMarbleCam.TargetZ;
      MarbleCNC.clsItem.FrmMach2.spn_camplungespeed.Value = buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity;
      MarbleCNC.clsItem.FrmMach2.spn_camcuttingstep.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance;
      MarbleCNC.clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
      MarbleCNC.clsItem.FrmMach2.spn_camsafedis.Value = buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance;
      MarbleCNC.clsItem.FrmMach2.chk_incremental.Check = clsAppMarbleVars.varInterface.IncrementalMode;
      MarbleCNC.clsItem.FrmMach2.chk_absolute.Check = clsAppMarbleVars.varInterface.AbsoluteMode;
      if (!clsAppMarbleVars.varInterface.PartZeroMode)
      {
        MarbleCNC.clsItem.FrmMach2.chk_machinezero.Check = true;
        MarbleCNC.clsItem.FrmMach2.chk_partzero.Check = false;
      }
      else
      {
        MarbleCNC.clsItem.FrmMach2.chk_machinezero.Check = false;
        MarbleCNC.clsItem.FrmMach2.chk_partzero.Check = true;
      }
      MarbleCNC.clsItem.FrmMach2.chk_addsawthickness.Check = clsAppMarbleVars.varInterface.AddSawThicknessToMove;
      MarbleCNC.clsItem.FrmMach2.spn_xpos.Value = clsAppMarbleVars.varInterface.JogMoveXValue;
      MarbleCNC.clsItem.FrmMach2.spn_ypos.Value = clsAppMarbleVars.varInterface.JogMoveYValue;
      MarbleCNC.clsItem.FrmMach2.spn_zpos.Value = clsAppMarbleVars.varInterface.JogMoveZValue;
      MarbleCNC.clsItem.FrmMach2.spn_apos.Value = clsAppMarbleVars.varInterface.JogMoveAValue;
      MarbleCNC.clsItem.FrmMach2.spn_cpos.Value = clsAppMarbleVars.varInterface.JogMoveCValue;
      clsAppMarbleItems.frmBottomPanelV1.lbl_material.Text = $"{buLangTranslate.preDef.Thickness}: {buMarbleCalc.varOperation.MaterialParameter.MaterialThickness.ToString("f1")}{Environment.NewLine}{buLangTranslate.preChar.Width}: {buMarbleCalc.varOperation.MaterialParameter.MaterialWidth.ToString("f1")} - {buLangTranslate.preChar.Height}: {buMarbleCalc.varOperation.MaterialParameter.MaterialHeight.ToString("f1")}";
      buMarbleForms.frmHorizontalV4.chk_cutstart.Check = buMarbleCalc.varMarbleRunSettings.SliceHorStartCut;
      buMarbleForms.frmHorizontalV4.chk_cutend.Check = buMarbleCalc.varMarbleRunSettings.SliceHorEndCut;
      buMarbleForms.frmHorizontalV4.spn_itemlen1.Value = buMarbleCalc.varMarbleRunSettings.HorizontalWidth;
      buMarbleForms.frmHorizontalV4.spn_itemcount1.Value = buMarbleCalc.varMarbleRunSettings.HorizontalCount;
      buMarbleForms.frmHorizontalV4.spn_itemSA1.Value = buMarbleCalc.varMarbleRunSettings.HorizontalStartAngle;
      buMarbleForms.frmHorizontalV4.spn_itemEA1.Value = buMarbleCalc.varMarbleRunSettings.HorizontalEndAngle;
      buMarbleForms.frmHorizontalV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.HorizontalLenght;
      if (buMarbleCalc.varMarbleRunSettings.HorCornerType == MarbleCorners.LeftTop)
      {
        buMarbleForms.frmHorizontalV4.chk_lefttop.Check = true;
        buMarbleForms.frmHorizontalV4.chk_leftbottom.Check = false;
      }
      else
      {
        buMarbleForms.frmHorizontalV4.chk_lefttop.Check = false;
        buMarbleForms.frmHorizontalV4.chk_leftbottom.Check = true;
      }
      buMarbleForms.frmVerticalV4.chk_cutstart.Check = buMarbleCalc.varMarbleRunSettings.SliceVerStartCut;
      buMarbleForms.frmVerticalV4.chk_cutend.Check = buMarbleCalc.varMarbleRunSettings.SliceVerEndCut;
      buMarbleForms.frmVerticalV4.spn_itemlen1.Value = buMarbleCalc.varMarbleRunSettings.VerticalWidth;
      buMarbleForms.frmVerticalV4.spn_itemcount1.Value = buMarbleCalc.varMarbleRunSettings.VerticalCount;
      buMarbleForms.frmVerticalV4.spn_itemSA1.Value = buMarbleCalc.varMarbleRunSettings.VerticalStartAngle;
      buMarbleForms.frmVerticalV4.spn_itemEA1.Value = buMarbleCalc.varMarbleRunSettings.VerticalEndAngle;
      buMarbleForms.frmVerticalV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.VerticalLenght;
      if (buMarbleCalc.varMarbleRunSettings.VerCornerType == MarbleCorners.LeftTop)
      {
        buMarbleForms.frmVerticalV4.chk_lefttop.Check = true;
        buMarbleForms.frmVerticalV4.chk_leftbottom.Check = false;
      }
      else
      {
        buMarbleForms.frmVerticalV4.chk_lefttop.Check = false;
        buMarbleForms.frmVerticalV4.chk_leftbottom.Check = true;
      }
      buMarbleForms.frmHorVerHorV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.HorizontalLenght;
      buMarbleForms.frmHorVerVerV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.VerticalLenght;
      buMarbleForms.frmHorVerDialog.spn_itemhorlength.Value = buMarbleCalc.varMarbleRunSettings.HorizontalLenght;
      buMarbleForms.frmHorVerDialog.spn_itemverlength.Value = buMarbleCalc.varMarbleRunSettings.VerticalLenght;
      if (buMarbleCalc.varMarbleRunSettings.HorVerHorCornerType == MarbleCorners.LeftTop)
      {
        buMarbleForms.frmHorVerHorV4.chk_lefttop.Check = true;
        buMarbleForms.frmHorVerHorV4.chk_leftbottom.Check = false;
      }
      else
      {
        buMarbleForms.frmHorVerHorV4.chk_lefttop.Check = false;
        buMarbleForms.frmHorVerHorV4.chk_leftbottom.Check = true;
      }
      if (buMarbleCalc.varMarbleRunSettings.HorVerVerCornerType == MarbleCorners.LeftTop)
      {
        buMarbleForms.frmHorVerVerV4.chk_lefttop.Check = true;
        buMarbleForms.frmHorVerVerV4.chk_leftbottom.Check = false;
      }
      else
      {
        buMarbleForms.frmHorVerVerV4.chk_lefttop.Check = false;
        buMarbleForms.frmHorVerVerV4.chk_leftbottom.Check = true;
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
      buMarbleForms.frmSingleV2.spn_signlecutAAngle.Value = buMarbleCalc.varMarbleRunSettings.SingleCutAAngle;
      buMarbleForms.frmSingleV2.spn_signlecutlength.Value = buMarbleCalc.varMarbleRunSettings.SingleCutLength;
      MarbleCNC.clsItem.FrmMach2.spn_xpos.Value = clsAppMarbleVars.varInterface.JogMoveXValue;
      MarbleCNC.clsItem.FrmMach2.spn_ypos.Value = clsAppMarbleVars.varInterface.JogMoveYValue;
      MarbleCNC.clsItem.FrmMach2.spn_zpos.Value = clsAppMarbleVars.varInterface.JogMoveZValue;
      MarbleCNC.clsItem.FrmMach2.spn_apos.Value = clsAppMarbleVars.varInterface.JogMoveCValue;
      MarbleCNC.clsItem.FrmMach2.spn_cpos.Value = clsAppMarbleVars.varInterface.JogMoveAValue;
      MarbleCNC.clsItem.FrmMach2.btn_xplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_xpos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_xminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_xpos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_yplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_ypos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_yminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_ypos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_zplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_zpos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_zminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_zpos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_aplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_apos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_aminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_apos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_cplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_cpos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_cminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_cpos.Value;
      if (CodesysMachine.CommType == CommunicationType.PlcHandler | CodesysMachine.CommType == CommunicationType.OPCUA)
        clsAppMarbleVars.cmdMarble.CommunicationVariableInit();
      this.MenuButtonColors(0);
      this.MenuDrawButtonColors(0);
      this.MenuButtonSawModeColors(0);
      clsAppMarbleVars.cmdMarble.ToolUpdateOnScreen();
      ccVars.Pages[0].Form.UpdateForm();
      MarbleCNC.clsItem.timGeneral.Interval = 300;
      MarbleCNC.clsItem.timGeneral.Tick += new EventHandler(this.GeneralTick);
      MarbleCNC.clsItem.timGeneral.Enabled = true;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualCurrent = 0.0;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualCurrent = 0.0;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualCurrent = 0.0;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualCurrent = 0.0;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualCurrent = 0.0;
      if (AppBool.Connected)
      {
        this.ReadBOOLValues();
        this.ReadDINTValues();
        this.ReadLRealValues();
        clsAppMarbleVars.cMachine.bWriteIOParameter = true;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
        clsAppMarbleVars.cMachine.bWriteAppParameter = true;
        clsAppMarbleVars.cMachine.bWriteToolParameter = true;
        clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
        clsAppMarbleVars.cMachine.bWriteParkParameters = true;
        clsAppMarbleVars.cMachine.bWriteAlarmActionParameters = true;
        KinematicBase copyKinematic = new KinematicBase();
        KinematicBase5.Copy(clsMarble.activeKinematic, ref copyKinematic);
        clsAppMarbleVars.cMachine.Commands.WriteKinematicData(CodesysMachine.RootPersistentString + "Kinematic.", copyKinematic);
      }
      clsInit.appCommand.cmdViewZoomFit();
      MarbleCNC.clsItem.FrmMach2.WindowState = FormWindowState.Maximized;
      clsAppMarbleItems.frmMain = (Form) MarbleCNC.clsItem.FrmMach2;
      buCadCamResVer5.clsItem.FrmMain = (Form) MarbleCNC.clsItem.FrmMach2;
      AppTask.taskResult1 = Task.Run((Action) (() => this.DoInitWork()));
      AppBool.Inited = true;
      this.Inited = true;
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished");
      buLogMarbleVer5.saveLogList();
    }
    catch (Exception ex)
    {
      buLogMarbleVer5.addToLog(this.sClass, str, ex.Message, "Exception", AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void DoInitWork()
  {
    clsInit.appMarble.InitCadCamSimulation();
    this.Inited = true;
  }

  public void AssingControls()
  {
    string str = nameof (AssingControls);
    try
    {
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started");
      clsAppMarbleItems.frmCoordsV2 = new F_MarbleCoordinatesV2();
      clsAppMarbleControls.lblMachine = clsAppMarbleItems.frmCoordsV2.lbl_machine;
      clsAppMarbleControls.lblMachineX = clsAppMarbleItems.frmCoordsV2.lbl_machinex;
      clsAppMarbleControls.lblMachineY = clsAppMarbleItems.frmCoordsV2.lbl_machiney;
      clsAppMarbleControls.lblMachineZ = clsAppMarbleItems.frmCoordsV2.lbl_machinez;
      clsAppMarbleControls.lblMachineA = clsAppMarbleItems.frmCoordsV2.lbl_machinea;
      clsAppMarbleControls.lblMachineC = clsAppMarbleItems.frmCoordsV2.lbl_machinec;
      clsAppMarbleControls.lblPart = clsAppMarbleItems.frmCoordsV2.lbl_part;
      clsAppMarbleControls.lblPartX = clsAppMarbleItems.frmCoordsV2.lbl_partx;
      clsAppMarbleControls.lblPartY = clsAppMarbleItems.frmCoordsV2.lbl_party;
      clsAppMarbleControls.lblPartZ = clsAppMarbleItems.frmCoordsV2.lbl_partz;
      clsAppMarbleControls.lblPartA = clsAppMarbleItems.frmCoordsV2.lbl_parta;
      clsAppMarbleControls.lblPartC = clsAppMarbleItems.frmCoordsV2.lbl_partc;
      clsAppMarbleControls.lblStatus = MarbleCNC.clsItem.FrmMach2.lbl_status;
      clsAppMarbleControls.lblWarning = MarbleCNC.clsItem.FrmMach2.lbl_warning;
      clsAppMarbleControls.btnInformation = MarbleCNC.clsItem.FrmMach2.btn_information;
      clsAppMarbleControls.IC32 = MarbleCNC.clsItem.FrmMach2.IC32;
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished");
    }
    catch (Exception ex)
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Exception", ex.Message, AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void AddControls()
  {
    string str = nameof (AddControls);
    try
    {
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmCoordsV1");
      clsAppMarbleItems.frmCoordsV2.pnl_base.Left = 4;
      clsAppMarbleItems.frmCoordsV2.pnl_base.Top = 54;
      clsAppMarbleItems.frmCoordsV2.pnl_base.Display.BackColor = Color.Transparent;
      clsAppMarbleItems.frmCoordsV2.pnl_base.Display.Border.Visible = false;
      MarbleCNC.clsItem.FrmMach2.pnl_coords.Controls.Add((Control) clsAppMarbleItems.frmCoordsV2.pnl_base);
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmCoordinates");
      clsAppMarbleItems.frmBottomPanelV1 = new F_MarbleBottomPanelV1();
      clsAppMarbleItems.frmBottomPanelV1.Init();
      clsAppMarbleItems.frmBottomPanelV1.buTab_Main.ItemSize = new Size(1, 1);
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmCoordsV1");
      clsAppMarbleItems.frmBottomPanelV1.pnl_base.Left = -1;
      clsAppMarbleItems.frmBottomPanelV1.pnl_base.Top = -1;
      clsAppMarbleItems.frmBottomPanelV1.pnl_base.Display.BackColor = Color.Transparent;
      clsAppMarbleItems.frmBottomPanelV1.pnl_base.Display.Border.Visible = false;
      MarbleCNC.clsItem.FrmMach2.pnl_down.Controls.Add((Control) clsAppMarbleItems.frmBottomPanelV1.pnl_base);
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmCoordinates");
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmJobOPListV2");
      clsAppMarbleItems.frmJobOPListV2.pnl_base.Left = 0;
      clsAppMarbleItems.frmJobOPListV2.pnl_base.Top = 42;
      clsAppMarbleItems.frmJobOPListV2.pnl_base.Height = 670;
      clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.BackColor = Color.Transparent;
      clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.Border.Visible = false;
      MarbleCNC.clsItem.FrmMach2.pnl_drawingjob.Controls.Add((Control) clsAppMarbleItems.frmJobOPListV2.pnl_base);
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
    buLabel lblDatetime = MarbleCNC.clsItem.FrmMach2.lbl_datetime;
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
    string str1 = string.Concat(strArray);
    lblDatetime.Text = str1;
    if (!this.Inited)
      return;
    if (!AppBool.IsFirstRun)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_water = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmBottomPanelV1.btn_laser = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmBottomPanelV1.btn_sawstart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_sawstart, clsAppMarbleVars.cMachine.runSystem.Saw, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart, clsAppMarbleVars.cMachine.runSystem.Spindle, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmCoordsV2.btn_start = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmCoordsV2.btn_pause = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      MarbleCNC.clsItem.FrmMach2.btn_semiautoenable = hmiUICommands.ColorButtonLinearFromOnOff(MarbleCNC.clsItem.FrmMach2.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmBottomPanelV1.btn_rtcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_rtcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmMDIPageV1.btn_tcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_tcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmMDIPageV1.btn_light = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_light, clsAppMarbleVars.cMachine.runSystem.MachineLight, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      clsAppMarbleItems.frmCoordsV2.lbl_machine.Text = clsAppMarbleVars.cMachine.Commands.CoordinateReadModeToString(clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode);
      clsAppMarbleItems.frmCoordsV2.lbl_part.Text = clsAppMarbleVars.cMachine.Commands.CoordinateReadModeToString(clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode);
      if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0)
      {
        clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
        clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
        clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      }
      else if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1)
      {
        clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
        clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
        clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      }
      else if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2)
      {
        clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
        clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
        clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
      }
      AppBool.IsFirstRun = true;
    }
    clsAppMarbleVars.cmdMarble.GeneralTick();
    if (clsAppMarbleVars.cMachine.miscVar.WarningAvailable & clsAppMarbleVars.cMachine.miscVar.cntWarning >= 10)
    {
      clsAppMarbleVars.cMachine.miscVar.WarningAvailable = false;
      clsAppMarbleVars.cMachine.miscVar.cntWarning = 0;
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.BackColor = Color.LightSteelBlue;
      if (clsAppMarbleVars.cMachine.runSystem.Status >= 0 & clsAppMarbleVars.cMachine.runSystem.Status < 100 & clsAppMarbleVars.cMachine.runSystem.Status <= AppLanguage.SystemStatus.Count - 1 & !AppBool.FileLoading)
        MarbleCNC.clsItem.FrmMach2.lbl_status.Text = AppLanguage.SystemStatus[clsAppMarbleVars.cMachine.runSystem.Status];
      if (clsAppMarbleVars.cMachine.runSystem.Status >= 100 & clsAppMarbleVars.cMachine.runSystem.Status < 200 & clsAppMarbleVars.cMachine.runSystem.Status - 100 <= AppLanguage.Status.Count - 1 & !AppBool.FileLoading)
        MarbleCNC.clsItem.FrmMach2.lbl_status.Text = AppLanguage.Status[clsAppMarbleVars.cMachine.runSystem.Status - 100];
      MarbleCNC.clsItem.FrmMach2.lbl_warning.Visible = false;
    }
    if (clsAppMarbleItems.frmMachineSettingsV2 != null && clsAppMarbleItems.frmMachineSettingsV2.Visible & clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Visible & !MarbleCNC.clsItem.FrmMach2.lbl_warning.Visible)
    {
      clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Text = "";
      clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Visible = false;
    }
    MarbleCNC.clsItem.timGeneral.Enabled = false;
    if (!clsAppMarbleItems.frmBottomPanelV1.btn_water.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Water)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_water.ForceSelected = true;
      clsAppMarbleItems.frmBottomPanelV1.btn_water = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmBottomPanelV1.btn_water.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Water)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_water.ForceSelected = false;
      clsAppMarbleItems.frmBottomPanelV1.btn_water = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmBottomPanelV1.btn_laser.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Laser)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_laser.ForceSelected = true;
      clsAppMarbleItems.frmBottomPanelV1.btn_laser = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmBottomPanelV1.btn_laser.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Laser)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_laser.ForceSelected = false;
      clsAppMarbleItems.frmBottomPanelV1.btn_laser = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Saw)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.ForceSelected = true;
      clsAppMarbleItems.frmBottomPanelV1.btn_sawstart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_sawstart, clsAppMarbleVars.cMachine.runSystem.Saw, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Saw)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.ForceSelected = false;
      clsAppMarbleItems.frmBottomPanelV1.btn_sawstart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_sawstart, clsAppMarbleVars.cMachine.runSystem.Saw, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Spindle)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.ForceSelected = true;
      clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart, clsAppMarbleVars.cMachine.runSystem.Spindle, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Spindle)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.ForceSelected = false;
      clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart, clsAppMarbleVars.cMachine.runSystem.Spindle, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmCoordsV2.btn_start.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Run)
    {
      clsAppMarbleItems.frmCoordsV2.btn_start.ForceSelected = true;
      clsAppMarbleItems.frmCoordsV2.btn_start = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmCoordsV2.btn_start.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Run)
    {
      clsAppMarbleItems.frmCoordsV2.btn_start.ForceSelected = false;
      clsAppMarbleItems.frmCoordsV2.btn_start = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmCoordsV2.btn_pause.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Pause)
    {
      clsAppMarbleItems.frmCoordsV2.btn_pause.ForceSelected = true;
      clsAppMarbleItems.frmCoordsV2.btn_pause = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmCoordsV2.btn_pause.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Pause)
    {
      clsAppMarbleItems.frmCoordsV2.btn_pause.ForceSelected = false;
      clsAppMarbleItems.frmCoordsV2.btn_pause = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!MarbleCNC.clsItem.FrmMach2.btn_semiautoenable.ForceSelected & clsAppMarbleVars.cMachine.runSystem.SemiAuto)
    {
      MarbleCNC.clsItem.FrmMach2.btn_semiautoenable.ForceSelected = true;
      MarbleCNC.clsItem.FrmMach2.btn_semiautoenable = hmiUICommands.ColorButtonLinearFromOnOff(MarbleCNC.clsItem.FrmMach2.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (MarbleCNC.clsItem.FrmMach2.btn_semiautoenable.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.SemiAuto)
    {
      MarbleCNC.clsItem.FrmMach2.btn_semiautoenable.ForceSelected = false;
      MarbleCNC.clsItem.FrmMach2.btn_semiautoenable = hmiUICommands.ColorButtonLinearFromOnOff(MarbleCNC.clsItem.FrmMach2.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.ForceSelected & clsAppMarbleVars.cMachine.runSystem.CruiseControl)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.ForceSelected = true;
      clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.CruiseControl)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.ForceSelected = false;
      clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.ForceSelected & clsAppMarbleVars.cMachine.runSystem.CruiseControl)
    {
      clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.ForceSelected = true;
      clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.CruiseControl)
    {
      clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.ForceSelected = false;
      clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.ForceSelected & clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.ForceSelected = true;
      clsAppMarbleItems.frmBottomPanelV1.btn_rtcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_rtcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.ForceSelected = false;
      clsAppMarbleItems.frmBottomPanelV1.btn_rtcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_rtcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmMDIPageV1.btn_tcp.ForceSelected & clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
    {
      clsAppMarbleItems.frmMDIPageV1.btn_tcp.ForceSelected = true;
      clsAppMarbleItems.frmMDIPageV1.btn_tcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_tcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmMDIPageV1.btn_tcp.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
    {
      clsAppMarbleItems.frmMDIPageV1.btn_tcp.ForceSelected = false;
      clsAppMarbleItems.frmMDIPageV1.btn_tcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_tcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmMDIPageV1.btn_light.ForceSelected & clsAppMarbleVars.cMachine.runSystem.MachineLight)
    {
      clsAppMarbleItems.frmMDIPageV1.btn_light.ForceSelected = true;
      clsAppMarbleItems.frmMDIPageV1.btn_light = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_light, clsAppMarbleVars.cMachine.runSystem.MachineLight, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmMDIPageV1.btn_light.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.MachineLight)
    {
      clsAppMarbleItems.frmMDIPageV1.btn_light.ForceSelected = false;
      clsAppMarbleItems.frmMDIPageV1.btn_light = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_light, clsAppMarbleVars.cMachine.runSystem.MachineLight, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.ForceSelected & clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.ForceSelected = true;
      clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.ForceSelected & clsAppMarbleVars.cMachine.runSystem.ActiveToolType != 0)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.ForceSelected = false;
      clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.ForceSelected & clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.ForceSelected = true;
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.ForceSelected & clsAppMarbleVars.cMachine.runSystem.ActiveToolType != 1)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.ForceSelected = false;
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (!clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.ForceSelected & clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.ForceSelected = true;
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.ForceSelected & clsAppMarbleVars.cMachine.runSystem.ActiveToolType != 2)
    {
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.ForceSelected = false;
      clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    clsAppMarbleItems.frmBottomPanelV1.progress_X.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualCurrent));
    clsAppMarbleItems.frmBottomPanelV1.progress_Y.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualCurrent));
    clsAppMarbleItems.frmBottomPanelV1.progress_Z.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualCurrent));
    clsAppMarbleItems.frmBottomPanelV1.progress_A.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualCurrent));
    clsAppMarbleItems.frmBottomPanelV1.progress_C.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualCurrent));
    if (MarbleTempVars.MachineCoordShowModeChanged)
    {
      MarbleTempVars.MachineCoordShowModeChanged = false;
      int num = Convert.ToInt32((object) clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode) + 1;
      if (num > 4)
        num = 0;
      if (num < 0)
        num = 0;
      clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode = (CoordinateShowMode) num;
      clsAppMarbleItems.frmCoordsV2.lbl_machine.Text = clsAppMarbleVars.cMachine.Commands.CoordinateReadModeToString(clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode);
      AppBool.SaveByTick = true;
    }
    if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.DistanceToGo)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
    }
    else if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.Speed)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
    }
    else if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.Current)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
    }
    else if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.FollowingError)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
    }
    else if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.Part)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
    }
    else
    {
      clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
    }
    if (MarbleTempVars.PartCoordShowModeChanged)
    {
      MarbleTempVars.PartCoordShowModeChanged = false;
      int num = Convert.ToInt32((object) clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode) + 1;
      if (num > 4)
        num = 0;
      if (num < 0)
        num = 0;
      clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode = (CoordinateShowMode) num;
      clsAppMarbleItems.frmCoordsV2.lbl_part.Text = clsAppMarbleVars.cMachine.Commands.CoordinateReadModeToString(clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode);
      AppBool.SaveByTick = true;
    }
    if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.DistanceToGo)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
    }
    else if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.Speed)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
    }
    else if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.Current)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
    }
    else if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.FollowingError)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
    }
    else if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.Machine)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
    }
    else
    {
      clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
      clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
        clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
    }
    clsAppMarbleItems.frmCoordsV2.lbl_machinex.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
    clsAppMarbleItems.frmCoordsV2.lbl_machiney.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
    clsAppMarbleItems.frmCoordsV2.lbl_machinez.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
    clsAppMarbleItems.frmCoordsV2.lbl_machinec.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
    if (clsAppMarbleVars.varRuntime.AxA >= 0)
      clsAppMarbleItems.frmCoordsV2.lbl_machinea.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
    if (clsAppMarbleVars.cMachine.runSystem.Saw)
      clsAppMarbleItems.frmCoordsV2.lbl_spindlespeed.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Speed} : {clsAppMarbleVars.cMachine.runSystem.SawSpeed.ToString("f0")} Rpm";
    else
      clsAppMarbleItems.frmCoordsV2.lbl_spindlespeed.Text = $"{buLangTranslate.preDef.Spindle} {buLangTranslate.preDef.Speed} : {clsAppMarbleVars.cMachine.runSystem.SpindleSpeed.ToString("f0")} Rpm";
    clsAppMarbleItems.frmCoordsV2.lbl_operationspeed.Text = $"{buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Speed} : {clsAppMarbleVars.cMachine.runCNC.FeedVelocity.ToString("f0")}";
    clsAppMarbleItems.frmCoordsV2.lbl_quickspeed.Text = $"{buLangTranslate.preDef.Quick} {buLangTranslate.preDef.Speed} : {clsAppMarbleVars.cMachine.runCNC.FeedVelocity.ToString("f0")}";
    if (AppBool.Offline)
    {
      clsAppMarbleItems.frmCoordsV2.track_quickspeed.Value = 100;
      clsAppMarbleItems.frmCoordsV2.track_operationspeed.Value = 100;
      clsAppMarbleItems.frmCoordsV2.track_spidle.Value = 100;
      clsAppMarbleItems.frmCoordsV2.progress_spindleCurrent.Value = 0;
    }
    else
    {
      clsAppMarbleItems.frmCoordsV2.track_quickspeed.Value = Convert.ToInt32(clsAppMarbleVars.cMachine.runSystem.FeedOverrideG0);
      clsAppMarbleItems.frmCoordsV2.track_operationspeed.Value = Convert.ToInt32(clsAppMarbleVars.cMachine.runSystem.FeedOverrideG1);
      clsAppMarbleItems.frmCoordsV2.track_spidle.Value = Convert.ToInt32(clsAppMarbleVars.cMachine.runSystem.SpindleOverride);
      clsAppMarbleItems.frmCoordsV2.progress_spindleCurrent.Value = Convert.ToInt32(clsAppMarbleVars.cMachine.runSystem.SpindleActualCurrent);
    }
    if (AppBool.ToolUpdated | AppBool.ToolChanged)
    {
      AppBool.ToolChanged = false;
      AppBool.ToolUpdated = false;
      if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0)
      {
        clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = 1.0;
        clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolSaw.Geometry.Diameter;
        clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolSaw.Geometry.Thickness;
      }
      if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1)
      {
        clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = (double) buMarbleCalc.activeToolMilling.Data.No;
        clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolMilling.Geometry.Diameter;
        clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolMilling.Geometry.Length;
      }
      if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2)
      {
        clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = (double) buMarbleCalc.activeToolMillingHead.Data.No;
        clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolMillingHead.Geometry.Diameter;
        clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolMillingHead.Geometry.Length;
      }
    }
    if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0 & clsAppMarbleVars.cMachine.runSystem.ActiveToolType != clsAppMarbleVars.cMachine.tempVars.ActiveToolTypePre)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_toolname.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Saw}";
      clsAppMarbleItems.frmCoordsV2.pic_tool.Image = clsAppMarbleItems.frmCoordsV2.IC48Tool.Images[0];
      clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = 1.0;
      clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolSaw.Geometry.Diameter;
      clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolSaw.Geometry.Thickness;
      clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Caption.Caption = buLangTranslate.preDef.Thickness;
    }
    if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1 & clsAppMarbleVars.cMachine.runSystem.ActiveToolType != clsAppMarbleVars.cMachine.tempVars.ActiveToolTypePre)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_toolname.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Milling}";
      clsAppMarbleItems.frmCoordsV2.pic_tool.Image = clsAppMarbleItems.frmCoordsV2.IC48Tool.Images[1];
      clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = (double) buMarbleCalc.activeToolMilling.Data.No;
      clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolMilling.Geometry.Diameter;
      clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolMilling.Geometry.Length;
      clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Caption.Caption = buLangTranslate.preDef.Length;
    }
    if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2 & clsAppMarbleVars.cMachine.runSystem.ActiveToolType != clsAppMarbleVars.cMachine.tempVars.ActiveToolTypePre)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_toolname.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.MillingHead}";
      clsAppMarbleItems.frmCoordsV2.pic_tool.Image = clsAppMarbleItems.frmCoordsV2.IC48Tool.Images[2];
      clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = (double) buMarbleCalc.activeToolMillingHead.Data.No;
      clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolMillingHead.Geometry.Diameter;
      clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolMillingHead.Geometry.Length;
      clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Caption.Caption = buLangTranslate.preDef.Length;
    }
    clsAppMarbleVars.cMachine.tempVars.ActiveToolTypePre = clsAppMarbleVars.cMachine.runSystem.ActiveToolType;
    bool State = clsAppMarbleVars.cMachine.runSystem.Spindle | clsAppMarbleVars.cMachine.runSystem.Saw;
    if (!clsAppMarbleItems.frmCoordsV2.lbl_toolname.ForceSelected & State)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_toolname.ForceSelected = true;
      clsAppMarbleItems.frmCoordsV2.lbl_toolname = hmiUICommands.ColorLabelLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.lbl_toolname, State, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    else if (clsAppMarbleItems.frmCoordsV2.lbl_toolname.ForceSelected & !State)
    {
      clsAppMarbleItems.frmCoordsV2.lbl_toolname.ForceSelected = false;
      clsAppMarbleItems.frmCoordsV2.lbl_toolname = hmiUICommands.ColorLabelLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.lbl_toolname, State, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
    }
    if (clsAppMarbleVars.cMachine.runSystem.AlarmCount == 0 & !clsAppMarbleVars.cMachine.miscVar.WarningAvailable)
    {
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.Fonts.ForeColor = Color.WhiteSmoke;
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.BackColor = Color.DimGray;
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.LineerGradient.FirstColor = buImage5.ColorToneChange(Color.DimGray, 0.6);
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.LineerGradient.SecondColor = Color.DimGray;
      if (clsAppMarbleVars.cMachine.runSystem.Pause)
      {
        MarbleCNC.clsItem.FrmMach2.lbl_status.Display.BackColor = Color.DarkOrange;
        MarbleCNC.clsItem.FrmMach2.lbl_status.Display.LineerGradient.FirstColor = buImage5.ColorToneChange(Color.DarkOrange, 0.6);
        MarbleCNC.clsItem.FrmMach2.lbl_status.Display.LineerGradient.SecondColor = Color.DarkOrange;
      }
      if (clsAppMarbleVars.cMachine.runSystem.Status >= 0 & clsAppMarbleVars.cMachine.runSystem.Status < 100 & clsAppMarbleVars.cMachine.runSystem.Status <= AppLanguage.SystemStatus.Count - 1 & !AppBool.FileLoading)
        MarbleCNC.clsItem.FrmMach2.lbl_status.Text = AppLanguage.SystemStatus[clsAppMarbleVars.cMachine.runSystem.Status];
      if (clsAppMarbleVars.cMachine.runSystem.Status >= 100 & clsAppMarbleVars.cMachine.runSystem.Status < 200 & clsAppMarbleVars.cMachine.runSystem.Status - 100 <= AppLanguage.Status.Count - 1 & !AppBool.FileLoading)
        MarbleCNC.clsItem.FrmMach2.lbl_status.Text = AppLanguage.Status[clsAppMarbleVars.cMachine.runSystem.Status - 100];
    }
    if (clsAppMarbleVars.cMachine.InfoList.Count > 0)
    {
      if (clsAppMarbleVars.cMachine.miscVar.cntGeneralTick % 10 == 0)
      {
        ++clsAppMarbleVars.cMachine.miscVar.indexInfo;
        clsAppMarbleVars.cMachine.miscVar.InfoFlash = !clsAppMarbleVars.cMachine.miscVar.InfoFlash;
      }
      if (clsAppMarbleVars.cMachine.miscVar.indexInfo > clsAppMarbleVars.cMachine.InfoList.Count - 1)
        clsAppMarbleVars.cMachine.miscVar.indexInfo = 0;
      if (clsAppMarbleVars.cMachine.miscVar.indexInfo < 0)
        clsAppMarbleVars.cMachine.miscVar.indexInfo = 0;
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.Fonts.ForeColor = Color.Black;
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.BackColor = clsAppMarbleVars.cMachine.InfoList[clsAppMarbleVars.cMachine.miscVar.indexInfo].ColorInfo;
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.LineerGradient.FirstColor = clsAppMarbleVars.cMachine.InfoList[clsAppMarbleVars.cMachine.miscVar.indexInfo].ColorInfo;
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.LineerGradient.SecondColor = buImage5.ColorToneChange(clsAppMarbleVars.cMachine.InfoList[clsAppMarbleVars.cMachine.miscVar.indexInfo].ColorInfo, 0.8);
      MarbleCNC.clsItem.FrmMach2.lbl_status.Text = clsAppMarbleVars.cMachine.InfoList[clsAppMarbleVars.cMachine.miscVar.indexInfo].Message;
      if (clsAppMarbleVars.cMachine.miscVar.InfoFlash)
      {
        MarbleCNC.clsItem.FrmMach2.btn_information.Display.LineerGradient.FirstColor = Color.Salmon;
        MarbleCNC.clsItem.FrmMach2.btn_information.Display.LineerGradient.SecondColor = Color.LightSalmon;
      }
      else
      {
        MarbleCNC.clsItem.FrmMach2.btn_information.Display.LineerGradient.FirstColor = buImage5.ColorToneChange(Color.Salmon, 1.3);
        MarbleCNC.clsItem.FrmMach2.btn_information.Display.LineerGradient.SecondColor = buImage5.ColorToneChange(Color.LightSalmon, 1.3);
      }
      MarbleCNC.clsItem.FrmMach2.btn_information.Visible = true;
      string str2 = clsAppMarbleVars.cMachine.InfoList[0].Message;
      if (str2.Length > 50)
        str2 = str2.Substring(0, 50);
      if (clsAppMarbleVars.cMachine.runSystem.AlarmCount > 0)
      {
        MarbleCNC.clsItem.FrmMach2.btn_information.Image = MarbleCNC.clsItem.FrmMach2.IC32.Images[1];
        MarbleCNC.clsItem.FrmMach2.btn_information.Text = $"{buLangTranslate.preDef.Error}: {str2}";
      }
      else if (clsAppMarbleVars.cMachine.runSystem.WarningCount > 0 | clsAppMarbleVars.cMachine.runSystem.WarningLocalCount > 0)
      {
        MarbleCNC.clsItem.FrmMach2.btn_information.Image = MarbleCNC.clsItem.FrmMach2.IC32.Images[0];
        MarbleCNC.clsItem.FrmMach2.btn_information.Text = $"{buLangTranslate.preDef.Warning}: {str2}";
      }
      else if (clsAppMarbleVars.cMachine.runSystem.MessageCount > 0)
      {
        MarbleCNC.clsItem.FrmMach2.btn_information.Image = MarbleCNC.clsItem.FrmMach2.IC32.Images[2];
        MarbleCNC.clsItem.FrmMach2.btn_information.Text = $"{buLangTranslate.preDef.Message}: {str2}";
      }
    }
    else
    {
      clsAppMarbleVars.cMachine.miscVar.indexInfo = -1;
      MarbleCNC.clsItem.FrmMach2.btn_information.Visible = false;
    }
    MarbleCNC.clsItem.timGeneral.Enabled = true;
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
      MarbleCNC.clsItem.FrmMach2.lbl_warning.Text = "";
      MarbleCNC.clsItem.FrmMach2.lbl_warning.Visible = false;
      if (clsAppMarbleItems.frmMachineSettingsV2 != null && clsAppMarbleItems.frmMachineSettingsV2.Visible)
      {
        clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Text = "";
        clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Visible = false;
      }
    }
    if (marbleHmiCommands == MarbleHMICommands.StatusUpdate)
    {
      MarbleCNC.clsItem.FrmMach2.lbl_status.Text = (string) Data2;
      MarbleCNC.clsItem.FrmMach2.lbl_status.Display.BackColor = (Color) Data3;
    }
    if (marbleHmiCommands == MarbleHMICommands.MaterialUpdate)
    {
      MarbleCNC.clsItem.FrmMach2.spn_cammarblethickness.Value = (double) Data2;
      buMarbleCalc.varOperation.MaterialParameter.MaterialThickness = (double) Data2;
      clsAppMarbleVars.varApp.MaterialThickness = (double) Data2;
      clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.MaterialThickness, "appSet.MaterialThickness");
    }
    if (marbleHmiCommands == MarbleHMICommands.SaveCNCParameter)
      Task.Run((Action) (() => this.SaveParameter()));
    if (marbleHmiCommands == MarbleHMICommands.SaveCamParameter && !MarbleTempVars.SavingMarble)
      Task.Run((Action) (() => clsInit.appMarble.SaveMarbleFile(AppPath.MachineSettings)));
    if (marbleHmiCommands != MarbleHMICommands.UpdateMarbleCamParametersFromControls)
      return;
    this.MainControlsToParameter(true);
  }

  public void clickCommands(object sender, EventArgs e)
  {
    try
    {
      Control control = sender as Control;
      control.Name.ToString();
      string str = "";
      if (control is buControl && ((buControl) control).Aux.Command != null)
        str = ((buControl) control).Aux.Command;
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_cancel.Name)
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Cancel);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_go.Name)
        clsInit.appMarble.viewportMouseDown(new Point3D(MarbleCNC.clsItem.FrmMach2.spn_x.Value, MarbleCNC.clsItem.FrmMach2.spn_y.Value, 0.0), (object) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
      if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.Name)
        clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleStart);
      if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowTools(1);
        MarbleCNC.clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
      }
      else if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowTools(2);
        MarbleCNC.clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
      }
      else
      {
        if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.Name)
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawStart);
        if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.Name)
        {
          clsAppMarbleVars.cmdMarble.ShowTools(0);
          MarbleCNC.clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
        }
        else
        {
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_gozero.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.GoPartZero);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.Name | control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CrouseControl);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_tcp.Name | control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.RTCP);
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_partzero.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.PartZero);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_codecreate.Name | control.Name == MarbleCNC.clsItem.FrmMach2.btn_codecreate2.Name)
          {
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CodeCreate);
            this.FillOperations();
          }
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_c0.Name | control.Name == MarbleCNC.clsItem.FrmMach2.btn_c0_2.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C0);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_c90.Name | control.Name == MarbleCNC.clsItem.FrmMach2.btn_c90_2.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_c180.Name | control.Name == MarbleCNC.clsItem.FrmMach2.btn_c180_2.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C180);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_c270.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90Minus);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_c_90_2.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90Minus);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_A0.Name | control.Name == MarbleCNC.clsItem.FrmMach2.btn_a0_2.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A0);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_A45.Name | control.Name == MarbleCNC.clsItem.FrmMach2.btn_a45_2.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A45);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_A90.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A90);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_a46_2.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A46);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindlepistondown.Name | str.Length > 0 & str == MarbleMotionCommands.SpindlePistonDown.ToString())
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonDown);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindlepistonup.Name | str.Length > 0 & str == MarbleMotionCommands.SpindlePistonUp.ToString())
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonUp);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_semiautoenable.Name)
          {
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SemiAutoSwitch);
            if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
              clsAppMarbleVars.cMachine.bWriteAppParameter = true;
          }
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_water.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Water);
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_laser.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Laser);
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_parkpos.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Park);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_park.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Park);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vagonpark.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.WagonPark);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindlepark.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePark);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_sawpark.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawPark);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindleheadpark.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleHeadPark);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_photopos.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraPark);
          if (control.Name == clsAppMarbleItems.frmCoordsV2.btn_reset.Name | control.Name == clsAppMarbleItems.frmMDIPageV1.btn_stop.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Reset);
          if (control.Name == clsAppMarbleItems.frmCoordsV2.btn_start.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Start);
          if (control.Name == clsAppMarbleItems.frmCoordsV2.btn_pause.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Pause);
          if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_stopsemiauto.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumair.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumBlow);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumdown.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumDown);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumup.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumUp);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumleftpad.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumLeftPad);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumrightpad.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumRightPad);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_light.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.MachineLight);
          if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_material.Name)
            clsAppMarbleVars.cmdMarble.ShowMaterialPage();
          if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_mdi.Name)
            clsAppMarbleVars.cmdMarble.ShowMDIPage();
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_materialmeasure.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.MaterialMeasureWithXYPos);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_sawwarm.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawWarmUp);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindlewarm.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleWarmUp);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_pensopenclose.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Pens);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineClose.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.AtcClose);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineopen.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.AtcOpen);
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_parklist.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.ParkList);
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_g54list.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.G54List);
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_toolpage.Name)
          {
            clsAppMarbleVars.cmdMarble.ShowTools(-1);
            MarbleCNC.clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
          }
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_gcodemaximize.Name)
            clsAppMarbleVars.cmdMarble.ShowGCodePage(1);
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_OPUp.Name && clsAppMarbleVars.varRuntime.OperationIndex > 0)
          {
            --clsAppMarbleVars.varRuntime.OperationIndex;
            if (clsAppMarbleVars.varRuntime.OperationIndex <= clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Count - 1)
              clsAppMarbleItems.frmBottomPanelV1.tree_operation.SelectedNode = clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes[clsAppMarbleVars.varRuntime.OperationIndex];
          }
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_OPDown.Name && clsAppMarbleVars.varRuntime.OperationIndex < clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Count - 1)
          {
            ++clsAppMarbleVars.varRuntime.OperationIndex;
            if (clsAppMarbleVars.varRuntime.OperationIndex >= 0 & clsAppMarbleVars.varRuntime.OperationIndex <= clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Count - 1)
            {
              clsAppMarbleItems.frmBottomPanelV1.tree_operation.SelectedNode = clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes[clsAppMarbleVars.varRuntime.OperationIndex];
              clsAppMarbleItems.frmBottomPanelV1.tree_operation.Update();
            }
          }
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_GCodeUp.Name && clsAppMarbleVars.cMachine.runCNC.ActiveLine > 0 & clsAppMarbleVars.cMachine.runCNC.ActiveLine <= clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Lines.Count - 1)
          {
            --clsAppMarbleVars.cMachine.runCNC.ActiveLine;
            clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Selection.Start = new Place()
            {
              iLine = clsAppMarbleVars.cMachine.runCNC.ActiveLine + clsAppMarbleVars.cMachine.miscVar.StartLine
            };
            Place place = new Place();
            place.iLine = clsAppMarbleVars.cMachine.runCNC.ActiveLine + clsAppMarbleVars.cMachine.miscVar.StartLine + 1;
            clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Selection.End = place;
            clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Refresh();
            if (place.iLine <= clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Lines.Count - 1)
              clsAppMarbleItems.frmBottomPanelV1.txt_gcode.DoSelectionVisible();
          }
          if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_GCodeDown.Name)
          {
            ++clsAppMarbleVars.cMachine.runCNC.ActiveLine;
            if (clsAppMarbleVars.cMachine.runCNC.ActiveLine > 0 & clsAppMarbleVars.cMachine.runCNC.ActiveLine <= clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Lines.Count - 1)
            {
              clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Selection.Start = new Place()
              {
                iLine = clsAppMarbleVars.cMachine.runCNC.ActiveLine + clsAppMarbleVars.cMachine.miscVar.StartLine
              };
              Place place = new Place();
              place.iLine = clsAppMarbleVars.cMachine.runCNC.ActiveLine + clsAppMarbleVars.cMachine.miscVar.StartLine + 1;
              clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Selection.End = place;
              clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Refresh();
              if (place.iLine <= clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Lines.Count - 1)
                clsAppMarbleItems.frmBottomPanelV1.txt_gcode.DoSelectionVisible();
            }
          }
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_cameraopen.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverOpen);
          if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_cameraclose.Name)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverClose);
          if (!(control.Name == clsAppMarbleItems.frmMDIPageV1.btn_camera.Name) || !(!AppBool.CameraCapturing & !AppBool.CameraMakeItReady & buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable))
            return;
          clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraReady);
        }
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
      MarbleCNC.clsItem.FrmMach2.buTab_drawing.Left = 0;
      MarbleCNC.clsItem.FrmMach2.buTab_drawing.Top = 0;
      MarbleCNC.clsItem.FrmMach2.buTab_drawing.Width = 155;
      MarbleCNC.clsItem.FrmMach2.buTab_drawing.Height = 600;
      clsAppMarbleVars.varRuntime.isHorizontalTab = false;
      clsAppMarbleVars.varRuntime.isVerticalTab = false;
      clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_main.Name)
      {
        clsAppMarbleVars.varRuntime.OnlineSimulationAllow = true;
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
        MarbleCNC.clsItem.FrmMach2.pnl_view.Visible = false;
        clsAppMarbleVars.varRuntime.isMainTab = true;
        MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex = 0;
        this.MenuButtonColors(0);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_manuel.Name)
      {
        clsAppMarbleVars.varRuntime.OnlineSimulationAllow = true;
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
        MarbleCNC.clsItem.FrmMach2.pnl_view.Visible = false;
        clsAppMarbleVars.varRuntime.isMainTab = true;
        MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex = 1;
        this.MenuButtonColors(1);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_sawmode.Name)
      {
        clsAppMarbleVars.varRuntime.OnlineSimulationAllow = false;
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
        MarbleCNC.clsItem.FrmMach2.pnl_view.Visible = false;
        clsAppMarbleVars.varRuntime.isMainTab = true;
        MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex = 2;
        this.MenuButtonColors(2);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_drawing.Name)
      {
        clsAppMarbleVars.varRuntime.OnlineSimulationAllow = false;
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
        MarbleCNC.clsItem.FrmMach2.pnl_view.Visible = false;
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex = 3;
        this.MenuButtonColors(3);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewmenu.Name)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_view.Visible)
        {
          MarbleCNC.clsItem.FrmMach2.pnl_view.Visible = false;
        }
        else
        {
          if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 0)
          {
            int num = 0;
            if (!MarbleTempVars.DockRightEnable)
              num = 170;
            MarbleCNC.clsItem.FrmMach2.pnl_view.Left = 360 + num;
            MarbleCNC.clsItem.FrmMach2.pnl_view.Top = 120;
          }
          else if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 1)
          {
            int num = 0;
            if (!MarbleTempVars.DockRightEnable)
              num = 170;
            MarbleCNC.clsItem.FrmMach2.pnl_view.Left = 580 + num;
            MarbleCNC.clsItem.FrmMach2.pnl_view.Top = 120;
          }
          else if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 2)
          {
            MarbleCNC.clsItem.FrmMach2.pnl_view.Left = 360;
            MarbleCNC.clsItem.FrmMach2.pnl_view.Top = -5;
          }
          else if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 3)
          {
            int num = 0;
            if (!MarbleTempVars.DockRightEnable)
              num = 170;
            MarbleCNC.clsItem.FrmMach2.pnl_view.Left = 170 + num;
            MarbleCNC.clsItem.FrmMach2.pnl_view.Top = 170;
          }
          else if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 4)
          {
            int num = 0;
            if (!MarbleTempVars.DockRightEnable)
              num = 170;
            MarbleCNC.clsItem.FrmMach2.pnl_view.Left = 290 + num;
            MarbleCNC.clsItem.FrmMach2.pnl_view.Top = 190;
          }
          MarbleCNC.clsItem.FrmMach2.pnl_view.Visible = true;
        }
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_horizontal.Name)
      {
        clsAppMarbleVars.varRuntime.isSingleTab = false;
        clsAppMarbleVars.varRuntime.isHorizontalTab = true;
        clsAppMarbleVars.varRuntime.isVerticalTab = false;
        clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 0;
        this.MenuButtonSawModeColors(0);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_vertical.Name)
      {
        clsAppMarbleVars.varRuntime.isSingleTab = false;
        clsAppMarbleVars.varRuntime.isHorizontalTab = false;
        clsAppMarbleVars.varRuntime.isVerticalTab = true;
        clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 1;
        this.MenuButtonSawModeColors(1);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_horver.Name)
      {
        clsAppMarbleVars.varRuntime.isSingleTab = false;
        clsAppMarbleVars.varRuntime.isHorizontalTab = false;
        clsAppMarbleVars.varRuntime.isVerticalTab = false;
        clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = true;
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 2;
        this.MenuButtonSawModeColors(2);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_single.Name)
      {
        clsAppMarbleVars.varRuntime.isSingleTab = true;
        clsAppMarbleVars.varRuntime.isHorizontalTab = false;
        clsAppMarbleVars.varRuntime.isVerticalTab = false;
        clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 3;
        this.MenuButtonSawModeColors(3);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_semiAuto.Name)
      {
        clsAppMarbleVars.varRuntime.isSingleTab = false;
        clsAppMarbleVars.varRuntime.isHorizontalTab = false;
        clsAppMarbleVars.varRuntime.isVerticalTab = false;
        clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
        clsAppMarbleVars.varRuntime.isMainTab = false;
        MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 4;
        this.MenuButtonSawModeColors(4);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_photo.Name)
      {
        if (!MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible)
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = true;
        else
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
        MarbleTempVars.OperationageMode = MarbleOperationPageMode.Photo;
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.SelectedIndex = 0;
        this.MenuDrawButtonColors(0);
        clsInit.appMarble.EntitiesSelectableStates(false, false, false, false, false);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_pointer.Name)
      {
        if (!MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible)
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = true;
        else
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
        MarbleTempVars.OperationageMode = MarbleOperationPageMode.Pointer;
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.SelectedIndex = 1;
        this.MenuDrawButtonColors(1);
        clsInit.appMarble.EntitiesSelectableStates(false, false, false, false, false);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_2DCad.Name)
      {
        if (!MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible)
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = true;
        else
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
        MarbleTempVars.OperationageMode = MarbleOperationPageMode.Operation;
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.SelectedIndex = 2;
        this.MenuDrawButtonColors(2);
        clsInit.appMarble.EntitiesSelectableStates(false, false, false, false, false);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_3DCad.Name)
      {
        if (!MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible)
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = true;
        else
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
        MarbleTempVars.OperationageMode = MarbleOperationPageMode.Operation;
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.SelectedIndex = 3;
        this.MenuDrawButtonColors(3);
        clsInit.appMarble.EntitiesSelectableStates(false, false, false, false, false);
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_Functions.Name)
      {
        if (!MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible)
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = true;
        else
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
        MarbleTempVars.OperationageMode = MarbleOperationPageMode.Function;
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.SelectedIndex = 4;
        this.MenuDrawButtonColors(4);
        clsInit.appMarble.EntitiesSelectableStates(true, false, false, false, false);
      }
      if (!(control.Name == MarbleCNC.clsItem.FrmMach2.btn_misc.Name))
        return;
      if (!MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible)
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = true;
      else
        MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
      MarbleTempVars.OperationageMode = MarbleOperationPageMode.Misc;
      MarbleCNC.clsItem.FrmMach2.buTab_drawing.SelectedIndex = 5;
      this.MenuDrawButtonColors(5);
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
      this.MainControlsToParameter(true);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_menuOP.Name)
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
          clsInit.appMarble.cmd3DFileAdd();
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_shape.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdShapeMenu();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_contour.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdContourMenu();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_profiling.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdProfileMenu();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_profilecurve.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdProfileCurveMenu();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_engraving.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmd3DFileAdd();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_library.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdLibraryMenu();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_text.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdTextMenu();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_slices.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdSlicing();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_materialclean.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdCleanMaterail();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_sweep.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdSweepMenu();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_cavity.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdCavityMenu();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_tap.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdTapMenu();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_oplist.Name)
        {
          if (!MarbleCNC.clsItem.FrmMach2.pnl_drawingjob.Visible)
          {
            int num = 1410;
            if (!MarbleTempVars.DockRightEnable)
              num += 340;
            MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Width = num - MarbleCNC.clsItem.FrmMach2.pnl_drawingjob.Width;
            MarbleCNC.clsItem.FrmMach2.pnl_drawingjob.Visible = true;
          }
          else
          {
            int num = 1090;
            if (!MarbleTempVars.DockRightEnable)
              num += 340;
            MarbleCNC.clsItem.FrmMach2.pnl_drawingjob.Visible = false;
            MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Width = num + MarbleCNC.clsItem.FrmMach2.pnl_drawingjob.Width;
          }
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_pointerpartpoints.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdPointerSlabBorder();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_pointersave.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdPointerSave();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_pointereditdrawing.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdPointerDrawEdit();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_pointercreatematerial.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.doMaterialCreateFromTempDrawings();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_pointercreatepart.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.doPartCreateFromTempDrawings();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_pointerslabborders.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdPointerSlabBorder();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_pointerrectmaterial.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsAppMarbleVars.cmdMarble.ShowMaterialPage();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_photodelete.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.doDeleteCameraImage();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_photodrawpart.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsAppMarbleVars.cmdMarble.ShowDrawingMenu(180, 165);
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_photoget.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          if (!AppBool.CameraCapturing & !AppBool.CameraMakeItReady & buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable)
            clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraReady);
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_photoimport.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          Image image = (Image) null;
          clsInit.appMarble.cmdImportImage(ref image);
          AppBool.SaveByTick = true;
          if (image != null)
          {
            clsInit.appMarble.doDeleteMaterialImage();
            clsInit.appMarble.cmdTakePhoto(image);
            clsInit.appMarble.activeJob.Material.matImage = (Image) null;
          }
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_photosave.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdPointerSave();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_photoeditdrawing.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdPointerDrawEdit();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_photoslabborders.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdPointerSlabBorder();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_move.Name && clsAppMarbleItems.frmMove != null)
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_rotate.Name)
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_mirror.Name)
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_scale.Name)
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_copy.Name)
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_copymulti.Name)
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_alignments.Name && buMarbleForms.frmEventAling != null)
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_eventsetangle.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.doSetAngle();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_slatadd.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.doSlatAdd((AddSlatArgs) null);
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_collopseadd.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.doCollopseAdd((AddCollapseArgs) null);
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_extend.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.doExtend();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_break.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.doBreak();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_offset.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.doOffset();
        }
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_eventdelete.Name && !clsInit.appMarble.MoveCreatedEntity)
          clsInit.appMarble.doDeleteItems(false, -1);
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_eventdeleteall.Name | control.Name == MarbleCNC.clsItem.FrmMach2.btn_eventdeleteall2.Name && !clsInit.appMarble.MoveCreatedEntity)
          clsInit.appMarble.doDeleteItems(true, -1);
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_vacuum.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsInit.appMarble.cmdVacuum();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_dimensionaligned.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_Options.Visible = false;
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsVar.varEntities.DimensionTextHeight = 40.0;
          clsInit.appCommand.cmdDrawDimensionAligned();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_dimensionlinear.Name)
        {
          MarbleCNC.clsItem.FrmMach2.buTab_Options.Visible = false;
          MarbleCNC.clsItem.FrmMach2.buTab_drawing.Visible = false;
          clsVar.varEntities.DimensionTextHeight = 40.0;
          clsInit.appCommand.cmdDrawDimensionLinear();
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_dimensionmenu.Name)
        {
          if (!MarbleCNC.clsItem.FrmMach2.buTab_Options.Visible)
            MarbleCNC.clsItem.FrmMach2.buTab_Options.Visible = true;
          else
            MarbleCNC.clsItem.FrmMach2.buTab_Options.Visible = false;
          MarbleCNC.clsItem.FrmMach2.lst_dimensions.Items.Clear();
          int num = 1;
          for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
          {
            if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData != null)
            {
              CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
              if (entityData.typeDefination == entityTypeDefination.Dimension & ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is Dimension)
              {
                string str1 = num.ToString() + " - ";
                if (entityData.infoString != null)
                  str1 = $"{str1}{entityData.infoString} ";
                Dimension entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] as Dimension;
                string str2 = $"{str1} L: {entity.TextString}";
                MarbleCNC.clsItem.FrmMach2.lst_dimensions.Items.Add((object) str2);
                ++num;
              }
            }
          }
          MarbleCNC.clsItem.FrmMach2.buTab_Options.SelectedIndex = 0;
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_dimensiondeleteall.Name)
          clsInit.appMarble.DeleteAllDimension();
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_dimensiondelete.Name && MarbleCNC.clsItem.FrmMach2.lst_dimensions.SelectedIndex >= 0)
        {
          clsInit.appMarble.DeleteDimension(MarbleCNC.clsItem.FrmMach2.lst_dimensions.SelectedIndex);
          MarbleCNC.clsItem.FrmMach2.lst_dimensions.Items.RemoveAt(MarbleCNC.clsItem.FrmMach2.lst_dimensions.SelectedIndex);
        }
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_saveOP.Name)
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
        if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_openOP.Name)
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
        if (!(control.Name == MarbleCNC.clsItem.FrmMach2.btn_undo.Name))
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
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_selectmaterial.Name)
      {
        clsInit.cMarble.ShowMaterialPage();
        clsInit.appMarble.SaveMarbleFile();
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_tools.Name)
        clsAppMarbleVars.cmdMarble.ShowToolsList(buMarbleCalc.varMarbleSettings.ToolListMode, MarbleToolType.Saw);
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_g54offset.Name)
        clsAppMarbleVars.cmdMarble.ShowG54List();
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_password.Name)
        clsAppMarbleVars.cmdMarble.ShowPassword();
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_calculations.Name)
        clsAppMarbleVars.cmdMarble.ShowCalculations();
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_report.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowReport();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_test.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowTest();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_simulationpanel.Name)
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
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_maintanance.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowMaintanance();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_warmup.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowWarmUp();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_materialmeasurement.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowMaterialMeasure();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenu.btn_closepc.Name && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWanttoClosePC) == DialogResult.Yes)
        clsAppMarbleVars.cmdMarble.cmdClosePC();
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
        clsAppMarbleVars.cmdMarble.ShowMachineSettingsV2(0);
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_vagoonsettings.Name)
        clsAppMarbleVars.cmdMarble.ShowWagonSettings();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_camerasettings.Name)
        clsAppMarbleVars.cmdMarble.ShowCameraSettings();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_calibration.Name)
        clsAppMarbleVars.cmdMarble.ShowCalibration();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_cameracalibration.Name)
        clsAppMarbleVars.cmdMarble.ShowCameraCalibration();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_AbsoluteHomeSet.Name)
        clsAppMarbleVars.cmdMarble.ShowAbsoluteSet();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_G54Offset.Name)
        clsAppMarbleVars.cmdMarble.ShowG54Set();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_kinematic.Name)
        clsAppMarbleVars.cmdMarble.ShowKinematic();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_axesgain.Name)
        clsAppMarbleVars.cmdMarble.ShowAxesGain();
      if (control.Name == MarbleCNC.clsItem.FrmMenuSettings.btn_GantryPage.Name)
        clsAppMarbleVars.cmdMarble.ShowGantySettings();
      if (control.Name == MarbleCNC.clsItem.FrmMenuAdminSettings.btn_techniciandefine.Name)
        clsAppMarbleVars.cmdMarble.ShowTechnicianDefine();
      if (control.Name == MarbleCNC.clsItem.FrmMenuAdminSettings.btn_userdefine.Name)
        clsAppMarbleVars.cmdMarble.ShowUserDefine();
      if (control.Name == MarbleCNC.clsItem.FrmMenuAdminSettings.btn_language.Name)
      {
        if (AppSecurity.PasswordLevel < 2)
        {
          buString5.MessageBoxWarning(buLangTranslate.preSentences.PasswordLevelNotEnough);
          return;
        }
        clsAppMarbleVars.cmdMarble.ShowLanguageMenu();
        MarbleCNC.clsItem.FrmMach2.LoadLanguage();
        MarbleCNC.clsItem.FrmMenu.LoadLanguage();
        MarbleCNC.clsItem.FrmMenuSettings.LoadLanguage();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenuAdminSettings.btn_debug.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowDebug();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenuAdminSettings.btn_counters.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowCounters();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenuAdminSettings.btn_watch.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowWatch();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMenuAdminSettings.btn_userinterfacesettings.Name)
      {
        clsAppMarbleVars.cmdMarble.ShowUserInterfaceSettings();
        AppBool.VisualUpdateForce = true;
        this.UpdateVisualThings();
        if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
          MarbleCNC.clsItem.FrmMenu.Visible = false;
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_contoursettings.Name)
      {
        if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 4)
        {
          this.MainControlsToParameter(true);
          clsInit.appMarble.cmdContourUserSettingsPage();
          this.MainControlsToParameter(false);
        }
        else if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 3)
        {
          this.MainControlsToParameter(true);
          clsInit.appMarble.cmdContourSettingsPageAsLessData();
          this.MainControlsToParameter(false);
        }
      }
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_information.Name)
        clsAppMarbleVars.cmdMarble.ShowInformation();
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewback.Name)
        clsAppMarbleVars.cmdMarble.SetView(viewType.Rear);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewfront.Name)
        clsAppMarbleVars.cmdMarble.SetView(viewType.Front);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewleft.Name)
        clsAppMarbleVars.cmdMarble.SetView(viewType.Left);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewrgiht.Name)
        clsAppMarbleVars.cmdMarble.SetView(viewType.Right);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewtop.Name)
        clsAppMarbleVars.cmdMarble.SetView(viewType.Top);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewiso.Name)
        clsAppMarbleVars.cmdMarble.SetView(viewType.Trimetric);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewzoomfit.Name)
        clsAppMarbleVars.cmdMarble.SetZoom(ZoomType.ZoomFit);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewzoomin.Name)
        clsAppMarbleVars.cmdMarble.SetZoom(ZoomType.ZoomIn);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewzoomout.Name)
        clsAppMarbleVars.cmdMarble.SetZoom(ZoomType.ZoomOut);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewzoomwindow.Name)
        clsAppMarbleVars.cmdMarble.SetZoom(ZoomType.ZoomWindow);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewpandown.Name)
        clsAppMarbleVars.cmdMarble.SetPan(PanType.panDown);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewpanleft.Name)
        clsAppMarbleVars.cmdMarble.SetPan(PanType.panLeft);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewpanright.Name)
        clsAppMarbleVars.cmdMarble.SetPan(PanType.PanRight);
      if (control.Name == MarbleCNC.clsItem.FrmMach2.btn_viewpanup.Name)
        clsAppMarbleVars.cmdMarble.SetPan(PanType.panUp);
      if (!buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
        return;
      MarbleCNC.clsItem.FrmMenuSettings.Visible = false;
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
    {
      string str = $"X: {this.pntActive.X.ToString("f2")} , Y: {this.pntActive.Y.ToString("f2")} , Z: {this.pntActive.Z.ToString("f2")}";
      if (ccVars.planeActive != (Plane) null && buVector5.isPlaneXYorYX(ccVars.planeActive))
        str = $"X: {this.pntActive.X.ToString("f2")} , Y: {this.pntActive.Y.ToString("f2")}";
      if (ccVars.planeActive != (Plane) null && buVector5.isPlaneXZorZX(ccVars.planeActive))
        str = $"X: {this.pntActive.X.ToString("f2")} , Z: {this.pntActive.Z.ToString("f2")}";
      if (ccVars.planeActive != (Plane) null && buVector5.isPlaneYZorZY(ccVars.planeActive))
        str = $"Y: {this.pntActive.Y.ToString("f2")} , Z: {this.pntActive.Z.ToString("f2")}";
      MarbleCNC.clsItem.FrmMach2.lbl_coord.Text = str;
    }
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
    if (control.Name == MarbleCNC.clsItem.FrmMach2.chk_incremental.Name)
    {
      AppBool.Inited = false;
      clsAppMarbleVars.varInterface.IncrementalMode = MarbleCNC.clsItem.FrmMach2.chk_incremental.Check;
      MarbleCNC.clsItem.FrmMach2.chk_absolute.Check = false;
      clsAppMarbleVars.varInterface.AbsoluteMode = false;
      AppBool.Inited = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach2.chk_absolute.Name)
    {
      AppBool.Inited = false;
      clsAppMarbleVars.varInterface.AbsoluteMode = MarbleCNC.clsItem.FrmMach2.chk_absolute.Check;
      MarbleCNC.clsItem.FrmMach2.chk_incremental.Check = false;
      clsAppMarbleVars.varInterface.IncrementalMode = false;
      AppBool.Inited = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach2.chk_machinezero.Name)
    {
      AppBool.Inited = false;
      MarbleCNC.clsItem.FrmMach2.chk_partzero.Check = false;
      clsAppMarbleVars.varInterface.PartZeroMode = false;
      AppBool.Inited = true;
      AppBool.SaveByTick = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach2.chk_partzero.Name)
    {
      AppBool.Inited = false;
      MarbleCNC.clsItem.FrmMach2.chk_machinezero.Check = false;
      clsAppMarbleVars.varInterface.PartZeroMode = true;
      AppBool.Inited = true;
      AppBool.SaveByTick = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach2.chk_addsawthickness.Name)
    {
      AppBool.Inited = false;
      clsAppMarbleVars.varInterface.AddSawThicknessToMove = MarbleCNC.clsItem.FrmMach2.chk_addsawthickness.Check;
      AppBool.Inited = true;
    }
  }

  private void trackValueChanged(object sender, double Val)
  {
    Control control = sender as Control;
    if (AppBool.Connected)
    {
      if (control.Name == clsAppMarbleItems.frmCoordsV2.track_spidle.Name && !clsAppMarbleVars.varApp.SpindlePersentageFromPLC)
      {
        clsAppMarbleItems.frmCoordsV2.track_spidle.Value = Convert.ToInt32(Val);
        clsAppMarbleVars.varInterface.SpindleSpeedOverride = Val;
        buPLCHandler.WriteVariableLREAL(CodesysMachine.RootGlobalString + "AppRun.SpindleOverride", (object) clsAppMarbleVars.varInterface.SpindleSpeedOverride);
        buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "AppRun.SpindleSpeedUpdate", (object) true);
        clsAppMarbleVars.varInterface.SawSpeedOverride = Val;
        buPLCHandler.WriteVariableLREAL(CodesysMachine.RootGlobalString + "AppRun.SawOverride", (object) clsAppMarbleVars.varInterface.SawSpeedOverride);
        buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "AppRun.SawSpeedUpdate", (object) true);
      }
      if (!clsAppMarbleVars.cMachine.runSystem.SimulatedIO)
        return;
      if (control.Name == clsAppMarbleItems.frmCoordsV2.track_operationspeed.Name)
      {
        clsAppMarbleItems.frmSpeedsV1.track_operationspeed.Value = Convert.ToInt32(Val);
        clsAppMarbleVars.varInterface.OperationSpeed = Val;
        buPLCHandler.WriteVariableLREAL(CodesysMachine.RootPersistentString + "sysSet.Feed.FeedOverrideG1", (object) clsAppMarbleVars.varInterface.OperationSpeed);
      }
      if (control.Name == clsAppMarbleItems.frmCoordsV2.track_quickspeed.Name)
      {
        clsAppMarbleItems.frmSpeedsV1.track_quickspeed.Value = Convert.ToInt32(Val);
        clsAppMarbleVars.varInterface.QuickSpeed = Val;
        buPLCHandler.WriteVariableLREAL(CodesysMachine.RootPersistentString + "sysSet.Feed.FeedOverrideG0", (object) clsAppMarbleVars.varInterface.QuickSpeed);
      }
    }
    else if (control.Name == clsAppMarbleItems.frmCoordsV2.track_operationspeed.Name)
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
    if (control.Name == MarbleCNC.clsItem.FrmMach2.spn_xpos.Name)
    {
      AppBool.Inited = false;
      MarbleCNC.clsItem.FrmMach2.btn_xplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_xpos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_xminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_xpos.Value;
      clsAppMarbleVars.varInterface.JogMoveXValue = MarbleCNC.clsItem.FrmMach2.spn_xpos.Value;
      AppBool.Inited = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach2.spn_ypos.Name)
    {
      AppBool.Inited = false;
      MarbleCNC.clsItem.FrmMach2.btn_yplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_ypos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_yminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_ypos.Value;
      clsAppMarbleVars.varInterface.JogMoveYValue = MarbleCNC.clsItem.FrmMach2.spn_ypos.Value;
      AppBool.Inited = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach2.spn_zpos.Name)
    {
      AppBool.Inited = false;
      MarbleCNC.clsItem.FrmMach2.btn_zplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_zpos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_zminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_zpos.Value;
      clsAppMarbleVars.varInterface.JogMoveZValue = MarbleCNC.clsItem.FrmMach2.spn_zpos.Value;
      AppBool.Inited = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach2.spn_apos.Name)
    {
      AppBool.Inited = false;
      MarbleCNC.clsItem.FrmMach2.btn_aplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_apos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_aminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_apos.Value;
      clsAppMarbleVars.varInterface.JogMoveAValue = MarbleCNC.clsItem.FrmMach2.spn_apos.Value;
      AppBool.Inited = true;
    }
    if (control.Name == MarbleCNC.clsItem.FrmMach2.spn_cpos.Name)
    {
      AppBool.Inited = false;
      MarbleCNC.clsItem.FrmMach2.btn_cplus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_cpos.Value;
      MarbleCNC.clsItem.FrmMach2.btn_cminus.Aux.ValDouble = MarbleCNC.clsItem.FrmMach2.spn_cpos.Value;
      clsAppMarbleVars.varInterface.JogMoveCValue = MarbleCNC.clsItem.FrmMach2.spn_cpos.Value;
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
    clsAppMarbleVars.varApp.MaterialWidth = MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialheight.Value;
    clsAppMarbleVars.varApp.MaterialHeight = MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialwidth.Value;
    clsAppMarbleVars.varApp.MaterialThickness = MarbleCNC.clsItem.FrmMach2.spn_cammarblethickness.Value;
    clsAppMarbleVars.varApp.SemiAutoSafeZ = MarbleCNC.clsItem.FrmMach2.spn_camsafedis.Value;
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
      if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 2 && MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 4)
      {
        this.SemiAutoParameterChange(true);
        if (AppBool.Connected)
          clsAppMarbleVars.cmdMarble.WriteSemiAutoParameters();
      }
    }
  }

  private void spinLeave(object sender, EventArgs e)
  {
    if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex != 2)
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
    if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 0)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto && AppBool.Connected)
        buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "appRun.SemiAutoEnable", (object) false);
      if (MarbleCNC.clsItem.FrmMach2.pnl_mainviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_manuelviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_mainviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_manuelviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_semiautoviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_mainviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_semiautoviewport.Controls[0]);
        buEyeItems.viewportCNC.ZoomFit();
        buEyeItems.viewportCNC.ZoomOut(10);
      }
      AppBool.EditMode = false;
    }
    else if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 1)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto && AppBool.Connected)
        buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "appRun.SemiAutoEnable", (object) false);
      if (MarbleCNC.clsItem.FrmMach2.pnl_manuelviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_mainviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_manuelviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_mainviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_semiautoviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_manuelviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_semiautoviewport.Controls[0]);
        buEyeItems.viewportCNC.ZoomFit();
        buEyeItems.viewportCNC.ZoomOut(10);
      }
      AppBool.EditMode = false;
    }
    else if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 2)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto && AppBool.Connected)
        buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "appRun.SemiAutoEnable", (object) false);
      if (MarbleCNC.clsItem.FrmMach2.pnl_semiautoviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_mainviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_semiautoviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_mainviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_manuelviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_semiautoviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_manuelviewport.Controls[0]);
        buEyeItems.viewportCNC.ZoomFit();
        buEyeItems.viewportCNC.ZoomOut(10);
      }
      if (MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 0)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Count == 0)
        {
          if (MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count > 0)
          {
            if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
              MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[0]);
            else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2)
              MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[1]);
            else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 3)
              MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[2]);
          }
        }
      }
      else if (MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 1)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Count == 0)
        {
          if (MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count > 0)
          {
            if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
              MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[0]);
            else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2)
              MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[1]);
            else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 3)
              MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[2]);
          }
        }
      }
      else if (MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 2)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Count == 0)
        {
          if (MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count > 0)
          {
            if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
              MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[0]);
            else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2)
              MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[1]);
            else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 3)
              MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[2]);
          }
        }
      }
      else if (MarbleCNC.clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 3 && MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count > 0)
        {
          if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
            MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2)
            MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[1]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 3)
            MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[2]);
        }
      }
      clsInit.appMarble.DeleteSimulationEntities();
      AppBool.EditMode = true;
    }
    else if (MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex == 3)
    {
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto && AppBool.Connected)
        buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "appRun.SemiAutoEnable", (object) false);
      if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 0)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
        buEyeItems.viewportCadCam.ZoomFit();
        buEyeItems.viewportCadCam.ZoomOut(10);
      }
      else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[0] is buTab)
        {
          if (MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
          else if (MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
            MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
          buEyeItems.viewportCadCam.ZoomFit();
          buEyeItems.viewportCadCam.ZoomOut(10);
        }
      }
      else if (MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2 && MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[0] is buTab & MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls[1] is buTab)
      {
        if (MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_verviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
        else if (MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
          MarbleCNC.clsItem.FrmMach2.pnl_drawviewport.Controls.Add(MarbleCNC.clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
        buEyeItems.viewportCadCam.ZoomFit();
        buEyeItems.viewportCadCam.ZoomOut(10);
      }
      clsInit.appMarble.DeleteSimulationEntities();
      AppBool.EditMode = true;
    }
    MarbleTempVars.LastSelectedTabPage = MarbleCNC.clsItem.FrmMach2.buTab_Main.SelectedIndex;
  }

  public void FormKeyDown(object sender, KeyEventArgs e)
  {
    Control control = new Control();
    if (!(((Control) sender).Name == MarbleCNC.clsItem.FrmMach2.Name))
      return;
    if (e.KeyCode == Keys.Escape)
      this.clickCommands((object) MarbleCNC.clsItem.FrmMach2.btn_cancel, new EventArgs());
    clsAppMarbleVars.cmdMarble.FormKeyDownCommon(sender, e);
  }

  public void UpdateVisualThings()
  {
    string str = nameof (UpdateVisualThings);
    try
    {
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started");
      if (buEyeVars.parVisual == null)
        buEyeVars.parVisual = new clsVisualVars();
      MarbleCNC.clsItem.FrmMach2.buTab_Main.ItemSize = new Size(1, 1);
      MarbleCNC.clsItem.FrmMach2.buTab_drawing.ItemSize = new Size(1, 1);
      MarbleCNC.clsItem.FrmMach2.buTab_sawmode.ItemSize = new Size(1, 1);
      MarbleCNC.clsItem.FrmMach2.buTab_Options.ItemSize = new Size(1, 1);
      MarbleCNC.clsItem.FrmMach2.tabPage_photo.Text = "";
      MarbleCNC.clsItem.FrmMach2.tabPage_pointer.Text = "";
      MarbleCNC.clsItem.FrmMach2.tabPage_cad2D.Text = "";
      MarbleCNC.clsItem.FrmMach2.tabPage_function.Text = "";
      MarbleCNC.clsItem.FrmMach2.tabPage_cad3d.Text = "";
      MarbleCNC.clsItem.FrmMach2.tabPage_DimensionOptions.Text = "";
      MarbleCNC.clsItem.FrmMach2.tabPage_Misc.Text = "";
      buLogMarbleVer5.addToLogList(this.sClass, str, "Started", "frmCoordsV1");
      clsAppMarbleItems.frmCoordsV2.UpdateVisuals();
      clsAppMarbleItems.frmBottomPanelV1.UpdateVisuals();
      buLogMarbleVer5.addToLogList(this.sClass, str, "Finished", "frmCoordsV1");
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.tabPage_manuel.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.pnl_commnadtop.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.buGround1.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.pnl_cadcamevents.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.pnl_drawing.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.tabPage_photo.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.tabPage_pointer.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.tabPage_cad2D.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.tabPage_cad3d.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.tabPage_function.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.tabPage_SawMode.Controls);
      controlCollection = hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.pnl_mainmenu.Controls);
      clsAppMarbleItems.frmMDIPageV1.btn_vagonpark.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.TableEnable;
      clsAppMarbleItems.frmMDIPageV1.btn_photopos.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable;
      clsAppMarbleItems.frmMDIPageV1.btn_spindlepark.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
      clsAppMarbleItems.frmMDIPageV1.btn_spindlepistondown.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
      clsAppMarbleItems.frmMDIPageV1.btn_spindlepistonup.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
      clsAppMarbleItems.frmMDIPageV1.btn_spindleheadpark.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable;
      clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineClose.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger;
      clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineopen.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger;
      clsAppMarbleItems.frmMDIPageV1.btn_pensopenclose.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
      clsAppMarbleItems.frmMDIPageV1.btn_cameraclose.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable;
      clsAppMarbleItems.frmMDIPageV1.btn_cameraopen.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable;
      MarbleCNC.clsItem.FrmMach2.btn_contour.Visible = clsVar.UserMode.MarbleMode.FileImport;
      MarbleCNC.clsItem.FrmMach2.btn_library.Visible = clsVar.UserMode.MarbleMode.Library;
      MarbleCNC.clsItem.FrmMach2.btn_profiling.Visible = clsVar.UserMode.MarbleMode.Profile;
      MarbleCNC.clsItem.FrmMach2.btn_profilecurve.Visible = clsVar.UserMode.MarbleMode.Profile;
      MarbleCNC.clsItem.FrmMach2.btn_engraving.Visible = clsVar.UserMode.MarbleMode.Engraving3Axis;
      MarbleCNC.clsItem.FrmMach2.btn_text.Visible = clsVar.UserMode.MarbleMode.Text;
      MarbleCNC.clsItem.FrmMach2.btn_slices.Visible = clsVar.UserMode.MarbleMode.FileImport;
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
    hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.pnl_mainmenu.Controls);
    if (PageIndex == 0)
    {
      MarbleCNC.clsItem.FrmMach2.btn_main.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_main.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_main.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_main.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_main.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_main.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_main.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_main.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_main.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      MarbleCNC.clsItem.FrmMach2.btn_manuel.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_manuel.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_manuel.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_manuel.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_manuel.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_manuel.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_manuel.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_manuel.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_manuel.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 2)
    {
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
      MarbleCNC.clsItem.FrmMach2.btn_sawmode.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 3)
      return;
    MarbleCNC.clsItem.FrmMach2.btn_drawing.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach2.btn_drawing.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach2.btn_drawing.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach2.btn_drawing.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach2.btn_drawing.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach2.btn_drawing.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach2.btn_drawing.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach2.btn_drawing.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
    MarbleCNC.clsItem.FrmMach2.btn_drawing.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
  }

  public void MenuButtonSawModeColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.tabPage_SawMode.Controls);
    if (PageIndex == 0)
      MarbleCNC.clsItem.FrmMach2.btn_horizontal = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_horizontal, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
    if (PageIndex == 1)
      MarbleCNC.clsItem.FrmMach2.btn_vertical = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_vertical, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
    if (PageIndex == 2)
      MarbleCNC.clsItem.FrmMach2.btn_horver = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_horver, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
    if (PageIndex == 3)
      MarbleCNC.clsItem.FrmMach2.btn_single = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_single, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
    if (PageIndex != 4)
      return;
    MarbleCNC.clsItem.FrmMach2.btn_semiAuto = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_semiAuto, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
  }

  public void MenuDrawButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(MarbleCNC.clsItem.FrmMach2.pnl_drawing.Controls);
    if (PageIndex == 0)
      MarbleCNC.clsItem.FrmMach2.btn_photo = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_photo, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    if (PageIndex == 1)
      MarbleCNC.clsItem.FrmMach2.btn_pointer = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_pointer, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    if (PageIndex == 2)
      MarbleCNC.clsItem.FrmMach2.btn_2DCad = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_2DCad, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    if (PageIndex == 3)
      MarbleCNC.clsItem.FrmMach2.btn_3DCad = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_3DCad, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    if (PageIndex == 4)
      MarbleCNC.clsItem.FrmMach2.btn_Functions = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_Functions, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    if (PageIndex != 5)
      return;
    MarbleCNC.clsItem.FrmMach2.btn_misc = buControls.buControlCommands.SetButtonColorAll(MarbleCNC.clsItem.FrmMach2.btn_misc, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
  }

  public void OpenParameter()
  {
    try
    {
      if (this.cMarbleVars == null)
        this.cMarbleVars = new clsAppMarbleVars();
      this.cMarbleVars.Init();
      clsAppMarbleVars.cmdMarble.OpenParameter();
      Task.Run((Action) (() => clsAppMarbleVars.cmdMarble.OpenReport()));
    }
    catch (Exception ex)
    {
    }
  }

  public void SaveParameter()
  {
    try
    {
      clsAppMarbleVars.cmdMarble.SaveParameter();
    }
    catch (Exception ex)
    {
    }
  }

  public void SemiAutoParameterChange(bool FromControlToValues)
  {
    if (FromControlToValues)
    {
      clsAppMarbleVars.varApp.SemiAutoWidth = MarbleCNC.clsItem.FrmMach2.spn_semiautohorizontallen.Value;
      clsAppMarbleVars.varApp.SemiAutoHeight = MarbleCNC.clsItem.FrmMach2.spn_semiautoverticallen.Value;
      clsAppMarbleVars.varApp.SemiAutoCutFeed = MarbleCNC.clsItem.FrmMach2.spn_camcuttingspped.Value;
      clsAppMarbleVars.varApp.SemiAutoPlungeFeed = MarbleCNC.clsItem.FrmMach2.spn_camplungespeed.Value;
      clsAppMarbleVars.varApp.SemiAutoTargetZ = MarbleCNC.clsItem.FrmMach2.spn_camoperationZ.Value;
      clsAppMarbleVars.varApp.SemiAutoSafeZ = MarbleCNC.clsItem.FrmMach2.spn_camsafedis.Value;
      clsAppMarbleVars.varApp.MaterialHeight = MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialheight.Value;
      clsAppMarbleVars.varApp.MaterialWidth = MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialwidth.Value;
      clsAppMarbleVars.varApp.MaterialThickness = MarbleCNC.clsItem.FrmMach2.spn_cammarblethickness.Value;
    }
    else
    {
      MarbleCNC.clsItem.FrmMach2.spn_semiautohorizontallen.Value = clsAppMarbleVars.varApp.SemiAutoWidth;
      MarbleCNC.clsItem.FrmMach2.spn_semiautoverticallen.Value = clsAppMarbleVars.varApp.SemiAutoHeight;
      MarbleCNC.clsItem.FrmMach2.spn_camcuttingspped.Value = clsAppMarbleVars.varApp.SemiAutoCutFeed;
      MarbleCNC.clsItem.FrmMach2.spn_camplungespeed.Value = clsAppMarbleVars.varApp.SemiAutoPlungeFeed;
      MarbleCNC.clsItem.FrmMach2.spn_camoperationZ.Value = clsAppMarbleVars.varApp.SemiAutoTargetZ;
      MarbleCNC.clsItem.FrmMach2.spn_camsafedis.Value = clsAppMarbleVars.varApp.SemiAutoSafeZ;
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialheight.Value = clsAppMarbleVars.varApp.MaterialHeight;
      MarbleCNC.clsItem.FrmMach2.spn_semiautomaterialwidth.Value = clsAppMarbleVars.varApp.MaterialWidth;
      MarbleCNC.clsItem.FrmMach2.spn_cammarblethickness.Value = clsAppMarbleVars.varApp.MaterialThickness;
    }
  }

  public void MainControlsToParameter(bool FromControlToValues)
  {
    if (FromControlToValues)
    {
      buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity = MarbleCNC.clsItem.FrmMach2.spn_camcuttingspped.Value;
      buMarbleCalc.varOperation.MaterialParameter.MaterialThickness = MarbleCNC.clsItem.FrmMach2.spn_cammarblethickness.Value;
      buMarbleCalc.varOperation.settingMarbleCam.TargetZ = MarbleCNC.clsItem.FrmMach2.spn_camoperationZ.Value;
      buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity = MarbleCNC.clsItem.FrmMach2.spn_camplungespeed.Value;
      buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance = MarbleCNC.clsItem.FrmMach2.spn_camcuttingstep.Value;
      buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance = MarbleCNC.clsItem.FrmMach2.spn_camsafedis.Value;
      buMarbleCalc.varMarbleRunSettings.CutLengthVertical = buMarbleForms.frmVerticalV4.spn_length.Value;
      buMarbleCalc.varMarbleRunSettings.CutLengthHorizontal = buMarbleForms.frmHorizontalV4.spn_length.Value;
      buMarbleCalc.activeToolSaw.CamData.SpindleSpeed = MarbleCNC.clsItem.FrmMach2.spn_camspindlespeed.Value;
    }
    else
    {
      MarbleCNC.clsItem.FrmMach2.spn_camcuttingspped.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity;
      MarbleCNC.clsItem.FrmMach2.spn_cammarblethickness.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
      MarbleCNC.clsItem.FrmMach2.spn_camoperationZ.Value = buMarbleCalc.varOperation.settingMarbleCam.TargetZ;
      MarbleCNC.clsItem.FrmMach2.spn_camplungespeed.Value = buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity;
      MarbleCNC.clsItem.FrmMach2.spn_camcuttingstep.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance;
      MarbleCNC.clsItem.FrmMach2.spn_camsafedis.Value = buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance;
      buMarbleForms.frmVerticalV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.CutLengthVertical;
      buMarbleForms.frmHorizontalV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.CutLengthHorizontal;
      MarbleCNC.clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
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
        {
          string str = $"X: {Data.pntMove.X.ToString("f2")} , Y: {Data.pntMove.Y.ToString("f2")} , Z: {Data.pntMove.Z.ToString("f2")}";
          if (Data.refPlane != (Plane) null && buVector5.isPlaneXYorYX(Data.refPlane))
            str = $"X: {Data.pntMove.X.ToString("f2")} , Y: {Data.pntMove.Y.ToString("f2")}";
          if (Data.refPlane != (Plane) null && buVector5.isPlaneXZorZX(Data.refPlane))
            str = $"X: {Data.pntMove.X.ToString("f2")} , Z: {Data.pntMove.Z.ToString("f2")}";
          if (Data.refPlane != (Plane) null && buVector5.isPlaneYZorZY(Data.refPlane))
            str = $"Y: {Data.pntMove.Y.ToString("f2")} , Z: {Data.pntMove.Z.ToString("f2")}";
          MarbleCNC.clsItem.FrmMach2.lbl_coord.Text = str;
        }
        break;
    }
  }

  public void MarbleCoreCommends(
    object Data1,
    object Data2,
    object Data3,
    object Data4,
    object Data5)
  {
    marbleHmiCommands = MarbleHMICommands.None;
    if (!(Data1 is MarbleHMICommands marbleHmiCommands))
      ;
    if (marbleHmiCommands != MarbleHMICommands.MoveMouse || Data2 == null || !(Data2 is MarbleCommandArgs))
      return;
    MarbleCommandArgs marbleCommandArgs = Data2 as MarbleCommandArgs;
    string str = $"X: {marbleCommandArgs.pntMove.X.ToString("f2")} , Y: {marbleCommandArgs.pntMove.Y.ToString("f2")} , Z: {marbleCommandArgs.pntMove.Z.ToString("f2")}";
    if (marbleCommandArgs.refPlane != (Plane) null && buVector5.isPlaneXYorYX(marbleCommandArgs.refPlane))
      str = $"X: {marbleCommandArgs.pntMove.X.ToString("f2")} , Y: {marbleCommandArgs.pntMove.Y.ToString("f2")}";
    if (marbleCommandArgs.refPlane != (Plane) null && buVector5.isPlaneXZorZX(marbleCommandArgs.refPlane))
      str = $"X: {marbleCommandArgs.pntMove.X.ToString("f2")} , Z: {marbleCommandArgs.pntMove.Z.ToString("f2")}";
    if (marbleCommandArgs.refPlane != (Plane) null && buVector5.isPlaneYZorZY(marbleCommandArgs.refPlane))
      str = $"Y: {marbleCommandArgs.pntMove.Y.ToString("f2")} , Z: {marbleCommandArgs.pntMove.Z.ToString("f2")}";
    MarbleCNC.clsItem.FrmMach2.lbl_coord.Text = str;
  }

  public void ShowWarning(string Message, Color clr)
  {
    MarbleCNC.clsItem.FrmMach2.lbl_warning.Visible = true;
    MarbleCNC.clsItem.FrmMach2.lbl_warning.Text = Message;
    MarbleCNC.clsItem.FrmMach2.lbl_warning.BackColor = clr;
    clsAppMarbleVars.cMachine.miscVar.cntWarning = 0;
    clsAppMarbleVars.cMachine.miscVar.WarningAvailable = true;
    if (clsAppMarbleItems.frmMachineSettingsV2 == null || !clsAppMarbleItems.frmMachineSettingsV2.Visible)
      return;
    clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Text = Message;
    clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Visible = true;
  }

  public void FillOperations()
  {
    clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Clear();
    if (clsInit.appMarble.activeJob == null)
      return;
    for (int index = 0; index <= clsInit.appMarble.activeJob.Operations.Count - 1; ++index)
    {
      MarbleItemOperations operation = clsInit.appMarble.activeJob.Operations[index];
      int num = clsInit.appMarble.JobImageIndex(operation.ItemType, operation.ShapeType);
      TreeNodeSettings treeNodeSettings = new TreeNodeSettings(operation.OperationName);
      treeNodeSettings.ImageIndex = num;
      treeNodeSettings.SelectedImageIndex = num;
      treeNodeSettings.Tag = (object) index.ToString();
      treeNodeSettings.ClassIndex = index;
      treeNodeSettings.ClassSubIndex = -1;
      treeNodeSettings.ClassSubSubIndex = -1;
      treeNodeSettings.Command = "";
      treeNodeSettings.Checked = true;
      TreeNodeSettings node = treeNodeSettings;
      clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Add((TreeNode) node);
    }
    if (clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Count > 0)
      clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes[0].Expand();
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
    int num = (int) MarbleCNC.clsItem.FrmMenu.ShowDialog((IWin32Window) MarbleCNC.clsItem.FrmMach2);
  }

  public void showSettingsPage(object sender, EventArgs e)
  {
    MarbleCNC.clsItem.FrmMenuSettings.StartPosition = FormStartPosition.CenterParent;
    MarbleCNC.clsItem.FrmMenuSettings.LoadLanguage();
    int num = (int) MarbleCNC.clsItem.FrmMenuSettings.ShowDialog((IWin32Window) MarbleCNC.clsItem.FrmMach2);
  }

  public void showAdminSettingsPage(object sender, EventArgs e)
  {
    MarbleCNC.clsItem.FrmMenuAdminSettings.StartPosition = FormStartPosition.CenterParent;
    MarbleCNC.clsItem.FrmMenuAdminSettings.LoadLanguage();
    int num = (int) MarbleCNC.clsItem.FrmMenuAdminSettings.ShowDialog((IWin32Window) MarbleCNC.clsItem.FrmMach2);
  }

  public void ThreadLoop()
  {
    while (buPLCHandler.ThreadEnable)
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
      ++clsAppMarbleVars.cMachine.miscVar.ThreadCount;
      if (AppBool.Inited & AppBool.Connected & flag)
      {
        if (AppBool.Inited)
        {
          if (clsAppMarbleVars.cMachine.miscVar.cntCommunication % 2 == 0 & AppBool.Inited)
          {
            ReadAxisDataBits Bits = new ReadAxisDataBits(true, true, true, !buMarbleCalc.varMarbleMachineSettings.OptionSettings.AllAbsoluteEncoder);
            if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.DistanceToGo | clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.DistanceToGo)
              Bits.DistanceToGo = true;
            if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.Speed | clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.Speed)
              Bits.Velocity = true;
            if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.FollowingError | clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.FollowingError)
              Bits.FollowingError = true;
            clsAppMarbleVars.cMachine.Commands.ReadAxisGroup(Bits, ref clsAppMarbleVars.cMachine.AppAxis);
            clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualOffsetedPosition = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition;
            clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualOffsetedPosition = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition;
          }
          this.ReadLRealValues();
          this.ReadBOOLValues();
          this.ReadDINTValues();
          clsAppMarbleVars.cMachine.runSystem.FirstPLCRead = true;
        }
        clsAppMarbleVars.cmdMarble.ThreadLoopExtension();
        if (((clsAppMarbleItems.frmDigitalInputOutput.Visible ? 1 : 0) | (clsAppMarbleItems.frmMachineSettingsV2 == null ? 0 : (clsAppMarbleItems.frmMachineSettingsV2.Visible ? 1 : 0))) != 0)
          clsAppMarbleVars.cmdMarble.ReadIOBOOLValues();
        if (clsAppMarbleItems.frmIOConfig != null && clsAppMarbleItems.frmIOConfig.Visible)
          clsAppMarbleVars.cmdMarble.ReadIOBOOLValues();
        if (!AppBool.DontWriteParameters)
        {
          if (clsAppMarbleVars.cMachine.bWriteIOParameter)
          {
            clsAppMarbleVars.cMachine.bParameterWriting = true;
            clsAppMarbleVars.cmdMarble.WriteIO();
            clsAppMarbleVars.cMachine.bWriteIOParameter = false;
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
          if (clsAppMarbleVars.cMachine.bWriteAlarmActionParameters)
          {
            clsAppMarbleVars.cMachine.bParameterWriting = true;
            clsAppMarbleVars.cmdMarble.WriteAlarmAction();
            clsAppMarbleVars.cMachine.bWriteAlarmActionParameters = false;
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
          if (clsAppMarbleVars.cMachine.bWriteParkParameters)
          {
            clsAppMarbleVars.cMachine.bParameterWriting = true;
            clsAppMarbleVars.cMachine.bWriteParkParameters = false;
          }
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
