// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarble
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buCadCamResVer5;
using buCadCamResVer5.Marble;
using buClass;
using buComm.FTP;
using buControls;
using buControls.Components.Marble;
using buControls.Controls;
using buControls.DialogBox;
using buControls.Forms.buControlForms.Commands;
using buControls.Forms.WinControlForms.Notepad;
using buControls.Forms.WinControlForms.Settings;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Controls;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Password;
using buHandler;
using buMarble.Forms;
using buMotion;
using buOpcUA;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable disable
namespace buMarble;

public class clsAppMarble
{
  public const MarbleMaterialMeasureType Point2 = (MarbleMaterialMeasureType) 2;
  public const MarbleMaterialMeasureType Point3 = (MarbleMaterialMeasureType) 3;
  public const MarbleMaterialMeasureType Point4 = (MarbleMaterialMeasureType) 4;
  public const MarbleMaterialMeasureType Point5 = (MarbleMaterialMeasureType) 5;
  public const MarbleMaterialMeasureType Point9 = (MarbleMaterialMeasureType) 9;

  public clsAppMarble(clsAppMarbleMachineReportItem data)
  {
    ((clsAppMarbleMachineReport) this).ItemName = "";
    ((clsAppMarbleMachineReport) this).TechnicianInfo = new TechnicianLoginInfo();
    ((clsAppMarbleMachineReport) this).ItemDate = DateTime.Now;
    ((clsAppMarbleMachineReport) this).Status = false;
    // ISSUE: explicit constructor call
    ((buSerilization5) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m00008A();

  public clsAppMarble()
  {
    ((clsAppMarbleMachineReport) this).ItemSpindleUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemSpindleDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemVacuumUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemVacuumDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemLeftSuctionCup = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemRightSuctionCup = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemToolMeasureUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemToolMeasureDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMaterialMeasureUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMaterialMeasureDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemLaserOnOff = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemLeftVacuumOutOk = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).IteLeftVacuumInOk = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemRightVacuumOutOk = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemRightVacuumInOk = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemToolBlowOnOff = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemSuctionCupAirOnOff = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMagazineOpen = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMagazineClose = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMagazineUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMagazineDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemToolPens = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemWaterOnOff = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemCameraCover = (clsAppMarbleMachineReportItem) null;
    ((MarblePartZeroType) this).ItemLubrication = (clsAppMarbleMachineReportItem) null;
    ((MarblePartZeroType) this).ReportName = "";
    ((MarblePartZeroType) this).ReportID = 0;
    ((MarblePartZeroType) this).ReportDate = DateTime.Now;
    ((MarbleParkModeAfterJob) this).Status = false;
    // ISSUE: explicit constructor call
    ((buSerilization5) this).\u002Ector();
    ((clsAppMarbleMachineReport) this).ItemSpindleUp = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Spindle} {buLangTranslate.preDef.Up}");
    ((clsAppMarbleMachineReport) this).ItemSpindleDown = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Spindle} {buLangTranslate.preDef.Down}");
    ((clsAppMarbleMachineReport) this).ItemVacuumUp = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Vacuum} {buLangTranslate.preDef.Up}");
    ((clsAppMarbleMachineReport) this).ItemVacuumDown = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Vacuum} {buLangTranslate.preDef.Down}");
    ((clsAppMarbleMachineReport) this).ItemLeftSuctionCup = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.SuctionCub}");
    ((clsAppMarbleMachineReport) this).ItemRightSuctionCup = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Right} {buLangTranslate.preDef.SuctionCub}");
    ((clsAppMarbleMachineReport) this).ItemToolMeasureUp = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Up}");
    ((clsAppMarbleMachineReport) this).ItemToolMeasureDown = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Down}");
    ((clsAppMarbleMachineReport) this).ItemMaterialMeasureUp = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Slab} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Up}");
    ((clsAppMarbleMachineReport) this).ItemMaterialMeasureDown = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Slab} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Down}");
    ((clsAppMarbleMachineReport) this).ItemLaserOnOff = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Laser} {buLangTranslate.preDef.On} - {buLangTranslate.preDef.Off}");
    ((clsAppMarbleMachineReport) this).ItemLeftVacuumOutOk = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.Out} {buLangTranslate.preDef.Vacuum}");
    ((clsAppMarbleMachineReport) this).IteLeftVacuumInOk = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.In} {buLangTranslate.preDef.Vacuum}");
    ((clsAppMarbleMachineReport) this).ItemRightVacuumOutOk = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Right} {buLangTranslate.preDef.Out} {buLangTranslate.preDef.Vacuum}");
    ((clsAppMarbleMachineReport) this).ItemRightVacuumInOk = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Right} {buLangTranslate.preDef.In} {buLangTranslate.preDef.Vacuum}");
    ((clsAppMarbleMachineReport) this).ItemToolBlowOnOff = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Blow} {buLangTranslate.preDef.On} - {buLangTranslate.preDef.Off}");
    ((clsAppMarbleMachineReport) this).ItemSuctionCupAirOnOff = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Air} {buLangTranslate.preDef.On} - {buLangTranslate.preDef.Off}");
    ((clsAppMarbleMachineReport) this).ItemMagazineOpen = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Magazine} {buLangTranslate.preDef.Open}");
    ((clsAppMarbleMachineReport) this).ItemMagazineClose = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Magazine} {buLangTranslate.preDef.Close}");
    ((clsAppMarbleMachineReport) this).ItemMagazineUp = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Magazine} {buLangTranslate.preDef.Up}");
    ((clsAppMarbleMachineReport) this).ItemMagazineDown = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Magazine} {buLangTranslate.preDef.Down}");
    ((clsAppMarbleMachineReport) this).ItemToolPens = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Pens} {buLangTranslate.preDef.On} - {buLangTranslate.preDef.Off}");
    ((clsAppMarbleMachineReport) this).ItemWaterOnOff = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Water} {buLangTranslate.preDef.On} - {buLangTranslate.preDef.Off}");
    ((clsAppMarbleMachineReport) this).ItemCameraCover = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Camera} {buLangTranslate.preDef.Cover} {buLangTranslate.preDef.On} - {buLangTranslate.preDef.Off}");
    ((MarblePartZeroType) this).ItemLubrication = (clsAppMarbleMachineReportItem) new clsAppMarbleMachineReport($"{buLangTranslate.preDef.Lubricate} {buLangTranslate.preDef.On} - {buLangTranslate.preDef.Off}");
  }

  public clsAppMarble(clsAppMarbleMachineReport data)
  {
    ((clsAppMarbleMachineReport) this).ItemSpindleUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemSpindleDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemVacuumUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemVacuumDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemLeftSuctionCup = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemRightSuctionCup = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemToolMeasureUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemToolMeasureDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMaterialMeasureUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMaterialMeasureDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemLaserOnOff = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemLeftVacuumOutOk = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).IteLeftVacuumInOk = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemRightVacuumOutOk = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemRightVacuumInOk = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemToolBlowOnOff = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemSuctionCupAirOnOff = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMagazineOpen = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMagazineClose = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMagazineUp = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemMagazineDown = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemToolPens = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemWaterOnOff = (clsAppMarbleMachineReportItem) null;
    ((clsAppMarbleMachineReport) this).ItemCameraCover = (clsAppMarbleMachineReportItem) null;
    ((MarblePartZeroType) this).ItemLubrication = (clsAppMarbleMachineReportItem) null;
    ((MarblePartZeroType) this).ReportName = "";
    ((MarblePartZeroType) this).ReportID = 0;
    ((MarblePartZeroType) this).ReportDate = DateTime.Now;
    ((MarbleParkModeAfterJob) this).Status = false;
    // ISSUE: explicit constructor call
    ((buSerilization5) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m00008D();

  public event OkCommandWithFiveDataEventHandler CommandOPC;

  public event OkCommandWithFiveDataEventHandler CommandHMI;

  public clsAppMarble()
  {
    // ISSUE: reference to a compiler-generated field
    ((clsAppMarble.\u003C\u003Ec) this).\u0001 = nameof (clsAppMarble);
    // ISSUE: reference to a compiler-generated field
    ((clsAppMarble.\u003C\u003Ec) this).\u0001 = (Image) null;
    ((baslerCamcs) this).\u0002 = "";
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (!clsAppMarbleVars.\u0001(nameof (clsAppMarble)))
    {
      int num = (int) MessageBox.Show(nameof (clsAppMarble));
      throw new RegisterException(nameof (clsAppMarble));
    }
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void InitCNCSimulation()
  {
    List<Entity> entityList = new List<Entity>();
    if (ccVars.SimMachine == null)
      return;
    if (ccVars.SimMachine.MachineParts.Count > 0)
    {
      for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
        {
          bool flag1 = true;
          bool flag2 = false;
          Entity entity = buVector5.CopyEntities(ccVars.SimMachine.MachineParts[index1].Entities[index2]);
          CustomData customData = new CustomData();
          customData.typeDefination = entityTypeDefination.MachineParts;
          customData.EntityName = ccVars.SimMachine.MachineParts[index1].PartName;
          if (ccVars.SimMachine.MachineParts[index1].PartType == "Lathe")
          {
            customData.infoString = "NotDelete";
            customData.ActionName = "Lathe";
            flag2 = true;
          }
          entity.EntityData = (object) customData;
          if (flag2 & !buMarbleCalc.varMarbleMachineSettings.SimulationSettings.DrawLathe)
            flag1 = false;
          if (flag1)
          {
            entity.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) buEyeItems.viewportCNC));
            entityList.Add(entity);
          }
        }
      }
    }
    if (entityList.Count <= 0)
      return;
    for (int index = 0; index <= entityList.Count - 1; ++index)
    {
      string name = ((CustomData) entityList[index].EntityData).EntityName;
      if (name.Length == 0)
        name = "Block" + index.ToString();
      Block block = new Block(name);
      Entity entity = buVector5.CopyEntities(entityList[index]);
      entity.Regen(0.1);
      entity.Color = Color.Linen;
      if (index <= ccVars.SimMachine.MachineParts.Count - 1)
      {
        int alpha = (int) byte.MaxValue;
        if (ccVars.SimMachine.MachineParts[index].Transparency >= 0 & ccVars.SimMachine.MachineParts[index].Transparency <= (int) byte.MaxValue)
          alpha = ccVars.SimMachine.MachineParts[index].Transparency;
        entity.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[index].Color);
      }
      entity.ColorMethod = colorMethodType.byEntity;
      block.Entities.Add(entity);
      buEyeItems.viewportCNC.Blocks.Add(block);
    }
  }

  public void InitSystem()
  {
    string callMethod = "SystemInit";
    try
    {
      hmiUICommands.OpenApplicationVisualFile(AppPath.MachineSettings + "\\ApplicationVisual.prm");
      ccVars.selectionProcess = true;
      clsVar.varSelection.SmartSelection = false;
      clsVar.varSelection.DontSelectGroupItem = true;
      clsVar.varDisplay.ShowSelectedEntitiesPoint = false;
      clsVar.varProgram.EventCommandRepitation = false;
      clsVar.varScreen.ShowToolbar = false;
      clsVar.varView.DisplayMode = DisplayModeType.Rendered;
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
      buMarbleForms.frmHorizontalV4 = new F_MarbleHorVerCutV4();
      buMarbleForms.frmHorizontalV4.Init();
      buMarbleForms.frmVerticalV4 = new F_MarbleHorVerCutV4();
      buMarbleForms.frmVerticalV4.Init();
      buMarbleForms.frmHorVerHorV4 = new F_MarbleHorVerCutV4();
      buMarbleForms.frmHorVerHorV4.Init();
      buMarbleForms.frmHorVerVerV4 = new F_MarbleHorVerCutV4();
      buMarbleForms.frmHorVerVerV4.Init();
      buMarbleForms.frmSingleV2 = new F_MarbleSingleCutV2();
      buMarbleForms.frmSingleV2.Init();
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Started", "OpenPostProcessorFile", "", 0.0, 0.0, false);
      FileInfo fileInfo1 = new FileInfo(AppPath.MachinePostProcessor + "\\postMachine.bupost");
      if (fileInfo1.Exists)
        buFile5.OpenPostProcessorFile(fileInfo1.FullName, ref ccVars.PostActive);
      else
        buString5.MessageBoxWarning(AppLanguage.CadCamMessages[91]);
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Finished", "OpenPostProcessorFile", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Started", "OpenKinemticFile", "", 0.0, 0.0, false);
      FileInfo fileInfo2 = new FileInfo(AppPath.MachineKinematic + "\\Kinematic5Axis.bukinematic");
      if (fileInfo2.Exists)
        buFile5.OpenKinemticFile(fileInfo2.FullName, ref clsMarble.activeKinematic);
      else
        buString5.MessageBoxWarning(AppLanguage.CadCamMessages[90]);
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Finished", "OpenKinemticFile", "", 0.0, 0.0, false);
      ccVars.KinematicOrjinal = new KinematicBase5(clsMarble.activeKinematic);
      if (AppBool.Connected)
      {
        buFile5.SaveToFile("N10 M10", AppPath.Base + "\\Temp.cnc");
        FTPConnect ftpConnect = new FTPConnect();
        FTPConnect.ftpConnectionProperties.IP = clsAppMarbleVars.cMachine.PLCSettings.IPNumber;
        FTPConnect.ftpConnectionProperties.UserName = clsAppMarbleVars.cMachine.PLCSettings.FtpUser;
        FTPConnect.ftpConnectionProperties.Password = clsAppMarbleVars.cMachine.PLCSettings.FtpPassword;
        FTPConnect.ftpConnectionProperties.Port = clsAppMarbleVars.cMachine.PLCSettings.FtpPort;
        if (!AppBool.Offline)
        {
          ftpConnect.FtpClientConnect();
          ftpConnect.FtpClientFileTransfer(AppPath.Base + "\\Temp.cnc", clsAppMarbleVars.cMachine.PLCSettings.pathDeviceSend + "\\Temp.cnc");
        }
      }
      buMarbleCalc.activeToolSaw.Geometry.GeometryType = ToolType.Saw;
      buMarbleCalc.activeToolSaw.Geometry.LowerRadius = 0.0;
      buMarbleCalc.activeToolSaw.Geometry.UpperRadius = 0.0;
      buMarbleCalc.activeToolSaw.Geometry.DrawHolder = false;
      buMarbleCalc.activeToolSaw.Geometry.DrawArbor = false;
      buMarbleCalc.activeToolSaw.Geometry.PlaneDirection = new Vec3D(0.0, 1.0, 0.0);
      buMarbleCalc.activeToolSaw.Limits.RotationA = true;
      buMarbleCalc.activeToolSaw.Limits.RotationC = true;
      if (AppBool.Connected)
      {
        clsAppMarbleVars.cmdMarble.readDINTVar(CodesysVariableBaseType.Persistent, "appSet.toolActiveNo", ref clsAppMarbleVars.varApp.toolActiveNo);
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SpindleSpeed, "AppRun.VelSpindle");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SawSpeed, "AppRun.VelSaw");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varInterface.SawSpeedOverride, "AppRun.SawOverride");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.SpindleSpeedOverride, "sysSet.Spindle.SpindleOverride");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.OperationSpeed, "sysSet.Feed.FeedOverrideG1");
        clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varInterface.QuickSpeed, "sysSet.Feed.FeedOverrideG0");
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.SpindleSpeedUpdate");
        clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.SawSpeedUpdate");
      }
      bool flag = false;
      List<string> stringList = new List<string>();
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Backup);
      if (!directoryInfo.Exists)
      {
        flag = true;
      }
      else
      {
        buFile5.getPathsInPath(directoryInfo.FullName, ref stringList);
        stringList.Reverse();
        if (stringList.Count > 0 && stringList[0] == "Default")
          stringList.RemoveAt(0);
      }
      if (stringList.Count == 0)
      {
        flag = true;
      }
      else
      {
        int days = (DateTime.Now - DateTime.ParseExact(stringList[0], "yyyyMMdd", (IFormatProvider) CultureInfo.InvariantCulture)).Days;
        if (days > 0 & days >= clsAppMarbleVars.varInterface.AutoProgramSaveDays)
          flag = true;
      }
      int num = DateTime.Now.Year;
      string str1 = num.ToString();
      DateTime now = DateTime.Now;
      num = now.Month;
      string str2 = num.ToString("D2");
      now = DateTime.Now;
      num = now.Day;
      string str3 = num.ToString("D2");
      string Folder = str1 + str2 + str3;
      if (!(flag & !clsAppMarbleVars.cMachine.miscVar.ProgramParameterFailure & !AppBool.FileSettingBroken))
        return;
      this.DebugDefaultSet(Folder);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void DeleteSimulationEntities()
  {
    for (int index = 0; index <= buEyeItems.viewportCNC.Entities.Count - 1; ++index)
    {
      buEyeItems.viewportCNC.Entities[index].Selected = false;
      if ((buEyeItems.viewportCNC.Entities[index].EntityData == null ? 0 : (buEyeItems.viewportCNC.Entities[index].EntityData is CustomData ? 1 : 0)) != 0)
      {
        CustomData entityData = buEyeItems.viewportCNC.Entities[index].EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.MachineParts | entityData.typeDefination == entityTypeDefination.MachineBody | entityData.typeDefination == entityTypeDefination.ToolParts | entityData.typeDefination == entityTypeDefination.Tool && ((entityData.infoString == null ? 1 : 0) | (entityData.infoString == null ? 0 : (entityData.infoString != "NotDelete" ? 1 : 0))) != 0)
          buEyeItems.viewportCNC.Entities[index].Selected = true;
      }
    }
    buEyeItems.viewportCNC.Entities.DeleteSelected();
    buEyeItems.viewportCNC.Invalidate();
  }

  public void DeleteAllEntities()
  {
    if (buEyeItems.viewportCNC == null)
      return;
    for (int index = 0; index <= buEyeItems.viewportCNC.Entities.Count - 1; ++index)
    {
      buEyeItems.viewportCNC.Entities[index].Selected = false;
      if ((buEyeItems.viewportCNC.Entities[index].EntityData == null ? 0 : (buEyeItems.viewportCNC.Entities[index].EntityData is CustomData ? 1 : 0)) != 0)
      {
        CustomData entityData = buEyeItems.viewportCNC.Entities[index].EntityData as CustomData;
        if (entityData.typeDefination != entityTypeDefination.Base)
        {
          if (entityData.infoString != null)
          {
            if (entityData.infoString != "NotDelete")
              buEyeItems.viewportCNC.Entities[index].Selected = true;
          }
          else
            buEyeItems.viewportCNC.Entities[index].Selected = true;
        }
      }
      else
        buEyeItems.viewportCNC.Entities[index].Selected = true;
    }
    buEyeItems.viewportCNC.Entities.DeleteSelected();
    buEyeItems.viewportCNC.Invalidate();
  }

  public void DrawSimulationEntities(
    bool cam,
    bool machine,
    bool isSaw,
    bool isMiliing,
    bool isWaterJet,
    bool isMillingExternal = false)
  {
    // ISSUE: unable to decompile the method.
  }

  public void DrawSimulationEntitiesSaw(
    bool cam,
    bool machine,
    bool isSaw,
    bool isMiliing,
    bool isWaterJet,
    bool isMillingExternal = false)
  {
    clsAppMarbleVars.varRuntime.SimMovePartIndex.Clear();
    List<Entity> EntList = new List<Entity>();
    List<Block> Blocks = new List<Block>();
    if (buEyeItems.viewportCNC == null)
      return;
    clsInit.appMarble.GetSimulationEntities(cam, machine, buEyeItems.viewportCNC.Entities.Count, ref EntList, ref Blocks, ref clsAppMarbleVars.varRuntime.SimMovePartIndex);
    for (int index = buEyeItems.viewportCNC.Blocks.Count - 1; index >= 0; --index)
    {
      if (buEyeItems.viewportCNC.Blocks[index].Name == "ToolSaw")
        buEyeItems.viewportCNC.Blocks.RemoveAt(index);
      else if (buEyeItems.viewportCNC.Blocks[index].Name == "ToolMilling")
        buEyeItems.viewportCNC.Blocks.RemoveAt(index);
      else if (buEyeItems.viewportCNC.Blocks[index].Name == "ToolMillingHead")
        buEyeItems.viewportCNC.Blocks.RemoveAt(index);
    }
    for (int index = 0; index <= Blocks.Count - 1; ++index)
      buEyeItems.viewportCNC.Blocks.Add(Blocks[index]);
    for (int index = 0; index <= EntList.Count - 1; ++index)
      buEyeItems.viewportCNC.Entities.Add(EntList[index]);
    buEyeItems.viewportCNC.Invalidate();
  }

  public void DrawSimulationEntitiesMilling(
    bool cam,
    bool machine,
    bool isSaw,
    bool isMiliing,
    bool isWaterJet,
    bool isMillingExternal = false)
  {
    clsAppMarbleVars.varRuntime.SimMovePartIndex.Clear();
    if (buMarbleCalc.varMarbleMachineSettings.SimulationSettings.DrawHead && (!machine || ccVars.SimMachine == null ? 0 : (ccVars.SimMachine.MachineParts != null ? 1 : 0)) != 0)
    {
      for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
        {
          if (ccVars.SimMachine.MachineParts[index1].PartType != "Lathe" & ccVars.SimMachine.MachineParts[index1].PartType != "MachinePart")
          {
            buMachinePart buMachinePart = new buMachinePart(ccVars.SimMachine.MachineParts[index1].PartName);
            buMachinePart.ARotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.A;
            buMachinePart.BRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.B;
            buMachinePart.CRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.C;
            buMachinePart.XMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.X;
            buMachinePart.YMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Y;
            buMachinePart.ZMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Z;
            buMachinePart.centerPointOfB = new Point3D(clsMarble.activeKinematic.RotateCenterOffsetOfB.Y - 0.0, 0.0);
            buMachinePart.centerPointOfC = new Point3D();
            buMachinePart.Color = ccVars.SimMachine.MachineParts[index1].Color;
            buMachinePart.ColorMethod = colorMethodType.byEntity;
            double dx = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.X + buMarbleCalc.varMarbleMachineSettings.SimulationSettings.SimDrawCommonOffsetX;
            double dy = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Y + buMarbleCalc.varMarbleMachineSettings.SimulationSettings.SimDrawCommonOffsetY;
            double dz = buMarbleCalc.activeToolMilling.Geometry.Length + ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Z + buMarbleCalc.varMarbleMachineSettings.SimulationSettings.SimDrawCommonOffsetZ;
            buMachinePart.Translate(dx, dy, dz);
            buMachinePart.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) buEyeItems.viewportCNC));
            CustomData customData = new CustomData();
            customData.typeDefination = entityTypeDefination.MachineParts;
            customData.OriginalEntityIndex = buEyeItems.viewportCNC.Entities.Count;
            customData.EntityName = ccVars.SimMachine.MachineParts[index1].PartName;
            if (customData.EntityName == "AxisB")
            {
              if (buMachinePart.centerPointOfB == (Point3D) null)
                buMachinePart.centerPointOfB = new Point3D();
              buMachinePart.centerPointOfB.Z = ccVars.SimMachine.MachineParts[index1].RotationDistance;
            }
            buMachinePart.EntityData = (object) customData;
            buMachinePart.ColorMethod = colorMethodType.byEntity;
            buMachinePart.Color = Color.FromArgb(100, ccVars.SimMachine.MachineParts[index1].Color);
            buMachinePart.Regen(new RegenParams(0.01, (IWorkspace) buEyeItems.viewportCNC));
            buMachinePart.LayerName = MarbleTempVars.layerMachine.Name;
            buEyeItems.viewportCNC.Entities.Add((Entity) buMachinePart);
          }
        }
      }
    }
    this.DrawToolMilling(buMarbleCalc.activeToolMilling);
    buEyeItems.viewportCNC.Entities.Regen(new RegenOptions());
    buEyeItems.viewportCNC.Invalidate();
  }

  public void DrawToolMilling(ToolBase5 ToolMilling)
  {
    try
    {
      Block block = (Block) null;
      if (ToolMilling != null)
      {
        List<Mesh> refMeshes = new List<Mesh>();
        clsInit.appMW.CreateTool(ToolMilling, true, true, false, false, ref refMeshes);
        block = new Block(nameof (ToolMilling));
        Mesh mesh = new Mesh();
        for (int index = 0; index <= refMeshes.Count - 1; ++index)
        {
          refMeshes[index].ColorMethod = colorMethodType.byEntity;
          refMeshes[index].Regen(0.1);
          refMeshes[index].ColorMethod = colorMethodType.byEntity;
          refMeshes[index].Color = Color.FromArgb((int) byte.MaxValue, refMeshes[index].Color);
          refMeshes[index].Regen(0.1);
          refMeshes[index].Translate(0.0, 0.0);
          block.Entities.Add((Entity) refMeshes[index]);
        }
      }
      for (int index = buEyeItems.viewportCNC.Blocks.Count - 1; index >= 0; --index)
      {
        if (buEyeItems.viewportCNC.Blocks[index].Name == nameof (ToolMilling))
          buEyeItems.viewportCNC.Blocks.RemoveAt(index);
      }
      if (ToolMilling != null & block != null)
      {
        buEyeItems.viewportCNC.Blocks.Add(block);
        buTool buTool = new buTool(nameof (ToolMilling));
        buTool.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.Tool
        };
        buTool.CRotation = true;
        buTool.BRotation = true;
        buTool.ARotation = false;
        buTool.centerPointOfB = new Point3D(0.0, 0.0, clsMarble.activeKinematic.RotateCenterOffsetOfA.Y + ToolMilling.Geometry.Length);
        buTool.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) buEyeItems.viewportCNC));
        buEyeItems.viewportCNC.Entities.Add((Entity) buTool);
      }
      for (int index = 0; index <= buEyeItems.viewportCNC.Entities.Count - 1; ++index)
      {
        CustomData entityData = buEyeItems.viewportCNC.Entities[index].EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Tool | entityData.typeDefination == entityTypeDefination.MachineParts | entityData.typeDefination == entityTypeDefination.MachineBody | entityData.typeDefination == entityTypeDefination.Clamper)
          clsAppMarbleVars.varRuntime.SimMovePartIndex.Add(index);
      }
      buEyeItems.viewportCNC.Invalidate();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void MoveSimPart(Pnt6DSimMove PntMove, bool SpindleDown, ToolBase5 Tool)
  {
    // ISSUE: unable to decompile the method.
  }

  public void MoveSimSawPart(Pnt6DSimMove PntMove, bool SpindleDown, ToolBase5 Tool)
  {
    for (int index = 0; index <= clsAppMarbleVars.varRuntime.SimMovePartIndex.Count - 1; ++index)
    {
      if (clsAppMarbleVars.varRuntime.SimMovePartIndex[index] <= buEyeItems.viewportCNC.Entities.Count - 1)
      {
        Entity entity1 = buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]];
        buMachinePart entity2 = buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]] as buMachinePart;
        CustomData entityData = entity1.EntityData as CustomData;
        int num1 = clsAppMarbleVars.varRuntime.SimMovePartIndex[index];
        if (clsAppMarbleVars.varRuntime.SimMovePartIndex[index] >= 0 & clsAppMarbleVars.varRuntime.SimMovePartIndex[index] <= buEyeItems.viewportCNC.Entities.Count - 1)
        {
          if (buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]].GetType() == typeof (buTool))
          {
            double num2 = 0.0;
            if ((buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]] as buTool).BlockName == "ToolMilling")
            {
              double num3 = num2 - buMarbleCalc.activeToolMilling.Geometry.Length;
              if (SpindleDown)
                num3 -= buMarbleCalc.varMarbleMachineSettings.SimulationSettings.ExternalMillingSpindleStroke;
              ((buTool) buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]]).zPos = PntMove.Z + num3;
            }
            else
            {
              double num4 = -buMarbleCalc.varMarbleMachineSettings.SimulationSettings.SimACAxesZDistance + clsMarble.activeKinematic.RotateCenterOffsetOfA.Z;
              ((buTool) buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]]).zPos = PntMove.Z + clsMarble.activeKinematic.RotateCenterOffsetOfC.Z + buMarbleCalc.activeToolSaw.Geometry.Diameter / 2.0 + num4;
            }
            ((buTool) buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]]).xPos = PntMove.X;
            ((buTool) buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]]).yPos = PntMove.Y;
            ((buTool) buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]]).aPos = PntMove.A;
            ((buTool) buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]]).cPos = PntMove.C;
          }
          if (buEyeItems.viewportCNC.Entities[clsAppMarbleVars.varRuntime.SimMovePartIndex[index]].GetType() == typeof (buMachinePart) && entityData.typeDefination == entityTypeDefination.MachineBody | entityData.typeDefination == entityTypeDefination.MachineParts && entityData.ActionName != "Lathe")
          {
            double num5 = 0.0;
            entity2.xPos = PntMove.X;
            entity2.yPos = PntMove.Y;
            entity2.aPos = PntMove.A;
            entity2.cPos = PntMove.C;
            if (ccVars.SimMachine.MachineParts[index].PartName != "Spindle")
            {
              double num6 = -buMarbleCalc.varMarbleMachineSettings.SimulationSettings.SimACAxesZDistance + clsMarble.activeKinematic.RotateCenterOffsetOfA.Z;
              entity2.zPos = PntMove.Z + num6 + clsMarble.activeKinematic.RotateCenterOffsetOfC.Z + buMarbleCalc.activeToolSaw.Geometry.Diameter / 2.0;
            }
            else
            {
              if (SpindleDown)
                num5 -= buMarbleCalc.varMarbleMachineSettings.SimulationSettings.ExternalMillingSpindleStroke;
              entity2.zPos = PntMove.Z + num5;
            }
          }
        }
      }
    }
  }

  public Design CameraRotationUpdate(bool Rotate, Design Viewport)
  {
    Viewport.ActiveViewport.Rotate.Enabled = Rotate;
    return Viewport;
  }

  public void SetPan(PanType pType)
  {
    if (pType == PanType.panMove)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        if (buEyeItems.viewportCNC.ActionMode != devDept.Eyeshot.actionType.Pan)
          buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.Pan;
        else
          buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.None;
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewPan();
    }
    if (pType == PanType.panLeft)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.PanLeft(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewPanLeft(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
    }
    if (pType == PanType.PanRight)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.PanRight(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewPanRight(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
    }
    if (pType == PanType.panUp)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.PanUp(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewPanUp(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
    }
    if (pType != PanType.panDown)
      return;
    if (clsAppMarbleVars.varRuntime.isMainTab)
    {
      buEyeItems.viewportCNC.PanDown(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
      buEyeItems.viewportCNC.Invalidate();
    }
    else
      clsInit.appCommand.cmdViewPanDown(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
  }

  public void SetZoom(ZoomType zType)
  {
    if (zType == ZoomType.ZoomIn)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.ZoomIn(10);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewZoomIn();
    }
    if (zType == ZoomType.ZoomOut)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.ZoomOut(10);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewZoomOut();
    }
    if (zType == ZoomType.ZoomFit)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.ZoomFit(10);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
      {
        clsInit.appCommand.cmdViewZoomFit();
        clsInit.appCommand.cmdViewZoomOut();
      }
    }
    if (zType != ZoomType.ZoomWindow)
      return;
    if (clsAppMarbleVars.varRuntime.isMainTab)
    {
      if (buEyeItems.viewportCNC.ActionMode != devDept.Eyeshot.actionType.ZoomWindow)
        buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.ZoomWindow;
      else
        buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.None;
      buEyeItems.viewportCNC.Invalidate();
    }
    else
      clsInit.appCommand.cmdViewZoomWindow();
  }

  public void SetView(viewType vType)
  {
    if (vType == viewType.Trimetric)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(vType);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
      else
        clsInit.appCommand.cmdViewTrimetric(true);
    }
    if (vType == viewType.Top)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(vType);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
      else
        clsInit.appCommand.cmdViewTop(false, false, true);
    }
    if (vType == viewType.Front)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(vType);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XZ;
      }
      else
        clsInit.appCommand.cmdViewFront(false, false, true);
    }
    if (vType == viewType.Rear)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(vType);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XZ;
      }
      else
        clsInit.appCommand.cmdViewRear(false, false, true);
    }
    if (vType == viewType.Left)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(vType);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.YZ;
      }
      else
        clsInit.appCommand.cmdViewLeft(false, false, true);
    }
    if (vType != viewType.Right)
      return;
    if (clsAppMarbleVars.varRuntime.isMainTab)
    {
      buEyeItems.viewportCNC.SetView(vType);
      buEyeItems.viewportCNC.Invalidate();
      ccVars.planeActive = Plane.YZ;
    }
    else
      clsInit.appCommand.cmdViewRight(false, false, true);
  }

  public void GeneralTick()
  {
    // ISSUE: unable to decompile the method.
  }

  public void GeneralIO()
  {
    if ((clsAppMarbleItems.frmMachineSettingsV2 == null ? 0 : (clsAppMarbleItems.frmMachineSettingsV2.Visible ? 1 : 0)) != 0)
    {
      Image image1 = (Image) null;
      Image image2 = !clsAppMarbleIOVar.MO_SpindleDownValf.Value ? clsAppMarbleItems.frmMachineSettingsV2.IC48.Images[0] : clsAppMarbleItems.frmMachineSettingsV2.IC48.Images[1];
      clsAppMarbleItems.frmMachineSettingsV2.btn_rocketdownO.Image = image2;
      image1 = (Image) null;
      Image image3 = !clsAppMarbleIOVar.ME_SpindleDownSensor.Value ? clsAppMarbleItems.frmMachineSettingsV2.IC48.Images[0] : clsAppMarbleItems.frmMachineSettingsV2.IC48.Images[1];
      clsAppMarbleItems.frmMachineSettingsV2.btn_rocketdownI.Image = image3;
      Image image4 = !clsAppMarbleIOVar.MO_SpindleUpValf.Value ? clsAppMarbleItems.frmMachineSettingsV2.IC48.Images[0] : clsAppMarbleItems.frmMachineSettingsV2.IC48.Images[1];
      clsAppMarbleItems.frmMachineSettingsV2.btn_rocketupO.Image = image4;
      image1 = (Image) null;
      Image image5 = !clsAppMarbleIOVar.ME_SpindleUpSensor.Value ? clsAppMarbleItems.frmMachineSettingsV2.IC48.Images[0] : clsAppMarbleItems.frmMachineSettingsV2.IC48.Images[1];
      clsAppMarbleItems.frmMachineSettingsV2.btn_rocketupI.Image = image5;
    }
    if ((clsAppMarbleItems.frmIOConfig == null ? 0 : (clsAppMarbleItems.frmIOConfig.Visible ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= clsAppMarbleVars.cMachine.Inputs.Count - 1; ++index)
      {
        if (clsAppMarbleVars.cMachine.Inputs[index].SourceIndex - 1 >= 0)
        {
          if (clsAppMarbleVars.cMachine.Inputs[index].Status)
          {
            ((F_MarbleToolSawTypes) clsAppMarbleItems.frmIOConfig).DGV_Input.Rows[index].Cells[5].Value = (object) "On";
            ((F_MarbleToolSawTypes) clsAppMarbleItems.frmIOConfig).DGV_Input.Rows[index].Cells[5].Style.BackColor = Color.Lime;
          }
          else
          {
            ((F_MarbleToolSawTypes) clsAppMarbleItems.frmIOConfig).DGV_Input.Rows[index].Cells[5].Value = (object) "Off";
            ((F_MarbleToolSawTypes) clsAppMarbleItems.frmIOConfig).DGV_Input.Rows[index].Cells[5].Style.BackColor = Color.Gray;
          }
        }
      }
      for (int index = 0; index <= clsAppMarbleVars.cMachine.Outputs.Count - 1; ++index)
      {
        if (clsAppMarbleVars.cMachine.Outputs[index].SourceIndex - 1 >= 0)
        {
          if (clsAppMarbleVars.cMachine.Outputs[index].Status)
          {
            ((F_MarbleToolSawTypes) clsAppMarbleItems.frmIOConfig).DGV_Output.Rows[index].Cells[5].Value = (object) "On";
            ((F_MarbleToolSawTypes) clsAppMarbleItems.frmIOConfig).DGV_Output.Rows[index].Cells[5].Style.BackColor = Color.Lime;
          }
          else
          {
            ((F_MarbleToolSawTypes) clsAppMarbleItems.frmIOConfig).DGV_Output.Rows[index].Cells[5].Value = (object) "Off";
            ((F_MarbleToolSawTypes) clsAppMarbleItems.frmIOConfig).DGV_Output.Rows[index].Cells[5].Style.BackColor = Color.Gray;
          }
        }
      }
    }
    if ((clsAppMarbleItems.frmDigitalInputOutput == null ? 0 : (clsAppMarbleItems.frmDigitalInputOutput.Visible ? 1 : 0)) == 0)
      return;
    if (clsAppMarbleItems.frmDigitalInputOutput.buTab_IO.SelectedIndex == 0)
    {
      for (int index = 0; index <= clsAppMarbleVars.cMachine.Inputs.Count - 1; ++index)
      {
        int SourceIndex = clsAppMarbleVars.cMachine.Inputs[index].SourceIndex - 1;
        if (SourceIndex >= 0)
        {
          Image image = !clsAppMarbleVars.cMachine.Inputs[index].Status ? clsAppMarbleItems.frmDigitalInputOutput.IC48.Images[0] : clsAppMarbleItems.frmDigitalInputOutput.IC48.Images[1];
          if (clsAppMarbleItems.frmDigitalInputOutput.pnl_input1.Visible)
            clsAppMarbleVars.cMachine.Commands.SetStateOfControlAsImage(clsAppMarbleItems.frmDigitalInputOutput.pnl_input1.Controls, SourceIndex, clsAppMarbleVars.cMachine.Inputs[index].Caption, image);
          if (clsAppMarbleItems.frmDigitalInputOutput.pnl_input2.Visible)
            clsAppMarbleVars.cMachine.Commands.SetStateOfControlAsImage(clsAppMarbleItems.frmDigitalInputOutput.pnl_input2.Controls, SourceIndex, clsAppMarbleVars.cMachine.Inputs[index].Caption, image);
          if (clsAppMarbleItems.frmDigitalInputOutput.pnl_input3.Visible)
            clsAppMarbleVars.cMachine.Commands.SetStateOfControlAsImage(clsAppMarbleItems.frmDigitalInputOutput.pnl_input3.Controls, SourceIndex, clsAppMarbleVars.cMachine.Inputs[index].Caption, image);
          if (clsAppMarbleItems.frmDigitalInputOutput.pnl_input4.Visible)
            clsAppMarbleVars.cMachine.Commands.SetStateOfControlAsImage(clsAppMarbleItems.frmDigitalInputOutput.pnl_input4.Controls, SourceIndex, clsAppMarbleVars.cMachine.Inputs[index].Caption, image);
        }
      }
    }
    if (clsAppMarbleItems.frmDigitalInputOutput.buTab_IO.SelectedIndex != 1)
      return;
    for (int index = 0; index <= clsAppMarbleVars.cMachine.Outputs.Count - 1; ++index)
    {
      int SourceIndex = clsAppMarbleVars.cMachine.Outputs[index].SourceIndex - 1;
      if (SourceIndex >= 0)
      {
        Image image = !clsAppMarbleVars.cMachine.Outputs[index].Status ? clsAppMarbleItems.frmDigitalInputOutput.IC48.Images[0] : clsAppMarbleItems.frmDigitalInputOutput.IC48.Images[1];
        if (clsAppMarbleItems.frmDigitalInputOutput.pnl_output1.Visible)
          clsAppMarbleVars.cMachine.Commands.SetStateOfControlAsImage(clsAppMarbleItems.frmDigitalInputOutput.pnl_output1.Controls, SourceIndex, clsAppMarbleVars.cMachine.Outputs[index].Caption, image);
        if (clsAppMarbleItems.frmDigitalInputOutput.pnl_output2.Visible)
          clsAppMarbleVars.cMachine.Commands.SetStateOfControlAsImage(clsAppMarbleItems.frmDigitalInputOutput.pnl_output2.Controls, SourceIndex, clsAppMarbleVars.cMachine.Outputs[index].Caption, image);
        if (clsAppMarbleItems.frmDigitalInputOutput.pnl_output3.Visible)
          clsAppMarbleVars.cMachine.Commands.SetStateOfControlAsImage(clsAppMarbleItems.frmDigitalInputOutput.pnl_output3.Controls, SourceIndex, clsAppMarbleVars.cMachine.Outputs[index].Caption, image);
        if (clsAppMarbleItems.frmDigitalInputOutput.pnl_output4.Visible)
          clsAppMarbleVars.cMachine.Commands.SetStateOfControlAsImage(clsAppMarbleItems.frmDigitalInputOutput.pnl_output4.Controls, SourceIndex, clsAppMarbleVars.cMachine.Outputs[index].Caption, image);
      }
    }
  }

  public void ClickCommand(
    MarbleMotionCommands Cmd,
    object Data1 = null,
    object Data2 = null,
    object Data3 = null,
    object Data4 = null)
  {
    // ISSUE: unable to decompile the method.
  }

  public void clickCommandsOptions(object sender, EventArgs e)
  {
    // ISSUE: unable to decompile the method.
  }

  public void clickCommandsView(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control.Name == "btn_commands" && clsAppMarbleItems.frmCommandsV1 != null)
    {
      if (!clsAppMarbleItems.frmCommandsV1.Visible)
      {
        clsAppMarbleItems.frmCommandsV1.DryRunOffsetZ = clsAppMarbleVars.varApp.DryRunZOffset;
        clsAppMarbleItems.frmCommandsV1.StartPosition = FormStartPosition.Manual;
        clsAppMarbleItems.frmCommandsV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmCommandsV1.PropertiesForm.FormPosition = FormStartPosition.Manual;
        clsAppMarbleItems.frmCommandsV1.PropertiesForm.TopMost = true;
        clsAppMarbleItems.frmCommandsV1.Left = clsAppMarbleItems.frmMain.Width - clsAppMarbleItems.frmMain.Left - clsAppMarbleItems.frmCommandsV1.Width - 10;
        clsAppMarbleItems.frmCommandsV1.Top = clsAppMarbleItems.frmMain.Height - clsAppMarbleItems.frmMain.Top - clsAppMarbleItems.frmCommandsV1.Height - 150;
        clsAppMarbleItems.frmCommandsV1.TopMost = true;
        clsAppMarbleItems.frmCommandsV1.Init();
        clsAppMarbleItems.frmCommandsV1.Owner = clsAppMarbleItems.frmMain;
        clsAppMarbleItems.frmCommandsV1.Show();
      }
      else
      {
        clsAppMarbleVars.varApp.DryRunZOffset = clsAppMarbleItems.frmCommandsV1.DryRunOffsetZ;
        clsAppMarbleVars.varRuntime.isDryRunActivated = clsAppMarbleItems.frmCommandsV1.chk_Dryrun.Check;
        clsAppMarbleItems.frmCommandsV1.Visible = false;
      }
    }
    if (control.Name == "btn_gcodes")
    {
      buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.None;
      buEyeItems.viewportCNC.Invalidate();
      clsInit.appCommand.cmdResetAction();
      this.ShowGCodePage(1);
    }
    if (control.Name == "btn_joblist")
    {
      buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.None;
      buEyeItems.viewportCNC.Invalidate();
      clsInit.appCommand.cmdResetAction();
      this.ShowJobList(1);
    }
    if (control.Name == "btn_view" && clsAppMarbleItems.frmViewsV1 != null)
    {
      if (!clsAppMarbleItems.frmViewsV1.Visible)
      {
        clsAppMarbleItems.frmViewsV1.spn_zoomratio.Value = ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomRatio;
        clsAppMarbleItems.frmViewsV1.spn_zoomx1.Value = (double) clsAppMarbleVars.varInterface.ZoomX1;
        clsAppMarbleItems.frmViewsV1.spn_zoomy1.Value = (double) ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomY1;
        clsAppMarbleItems.frmViewsV1.spn_zoomx2.Value = (double) ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomX2;
        clsAppMarbleItems.frmViewsV1.spn_zoomy2.Value = (double) ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomY2;
        clsAppMarbleItems.frmViewsV1.spn_pandis.Value = (double) buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount;
        clsAppMarbleItems.frmViewsV1.StartPosition = FormStartPosition.Manual;
        clsAppMarbleItems.frmViewsV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmViewsV1.PropertiesForm.FormPosition = FormStartPosition.Manual;
        clsAppMarbleItems.frmViewsV1.PropertiesForm.TopMost = true;
        clsAppMarbleItems.frmViewsV1.Left = clsAppMarbleItems.frmMain.Width - clsAppMarbleItems.frmMain.Left - clsAppMarbleItems.frmViewsV1.Width - 10;
        clsAppMarbleItems.frmViewsV1.Top = clsAppMarbleItems.frmMain.Height - clsAppMarbleItems.frmMain.Top - clsAppMarbleItems.frmViewsV1.Height - 150;
        clsAppMarbleItems.frmViewsV1.TopMost = true;
        clsAppMarbleItems.frmViewsV1.Show();
        clsAppMarbleItems.frmViewsV1.spn_zoomratio.Value = !clsAppMarbleVars.varRuntime.isMainTab ? ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Camera.ZoomFactor : buEyeItems.viewportCNC.Camera.ZoomFactor;
      }
      else if (buEyeItems.viewportCNC != null)
      {
        buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.None;
        buEyeItems.viewportCNC.Invalidate();
        clsInit.appCommand.cmdResetAction();
        clsAppMarbleItems.frmViewsV1.Visible = false;
      }
    }
    if (clsAppMarbleItems.frmViewsV1 == null)
      return;
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewclose.Name)
    {
      buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.None;
      buEyeItems.viewportCNC.Invalidate();
      clsInit.appCommand.cmdResetAction();
      clsAppMarbleItems.frmViewsV1.Visible = false;
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_camerapos.Name)
    {
      if (!MarbleTempVars.CameraFrameShowed)
        this.ShowScreenCaptureSeperators();
      else
        this.HideScreenCaptureSeperators();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewiso.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.Trimetric);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
      else
        clsInit.appCommand.cmdViewTrimetric(true);
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewtopbackleft.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.vcBackFaceTopLeft);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.vcBackFaceTopLeft);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewtopfrontright.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.vcFrontFaceTopRight);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.vcFrontFaceTopRight);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewtopfrontleft.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.vcFrontFaceTopLeft);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.vcFrontFaceTopLeft);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewtopfrontmiddle.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.vcFrontFaceTop);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.vcFrontFaceTop);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewtopleftmiddle.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.vcLeftFaceTop);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.vcLeftFaceTop);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewtop.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.Top);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XY;
      }
      else
        clsInit.appCommand.cmdViewTop(false, false, true);
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewfront.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.Front);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XZ;
      }
      else
        clsInit.appCommand.cmdViewFront(false, false, true);
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewback.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.Rear);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.XZ;
      }
      else
        clsInit.appCommand.cmdViewRear(false, false, true);
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewleft.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.Left);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.YZ;
      }
      else
        clsInit.appCommand.cmdViewLeft(false, false, true);
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewright.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.SetView(viewType.Right);
        buEyeItems.viewportCNC.Invalidate();
        ccVars.planeActive = Plane.YZ;
      }
      else
        clsInit.appCommand.cmdViewRight(false, false, true);
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_zoomfit.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.ZoomFit(10);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
      {
        clsInit.appCommand.cmdViewZoomFit();
        clsInit.appCommand.cmdViewZoomOut();
      }
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_zoomin.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.ZoomIn(10);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewZoomIn();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_zoomout.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.ZoomOut(10);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewZoomOut();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_zoomwindow.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        if (buEyeItems.viewportCNC.ActionMode != devDept.Eyeshot.actionType.ZoomWindow)
          buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.ZoomWindow;
        else
          buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.None;
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewZoomWindow();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_zoomratio.Name)
    {
      ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomRatio = (double) (int) clsAppMarbleItems.frmViewsV1.spn_zoomratio.Value;
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.Camera.ZoomFactor = ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomRatio;
        buEyeItems.viewportCNC.Invalidate();
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Camera.ZoomFactor = ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomRatio;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      }
      this.SaveParameterInterface();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_zoomwindowcoords.Name)
    {
      clsAppMarbleVars.varInterface.ZoomX1 = (int) clsAppMarbleItems.frmViewsV1.spn_zoomx1.Value;
      ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomY1 = (int) clsAppMarbleItems.frmViewsV1.spn_zoomy1.Value;
      ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomX2 = (int) clsAppMarbleItems.frmViewsV1.spn_zoomx2.Value;
      ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomY2 = (int) clsAppMarbleItems.frmViewsV1.spn_zoomy2.Value;
      System.Drawing.Point p1 = new System.Drawing.Point(clsAppMarbleVars.varInterface.ZoomX1, ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomY1);
      System.Drawing.Point p2 = new System.Drawing.Point(((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomX2, ((clsAppMarbleMachineReportItem) clsAppMarbleVars.varInterface).ZoomY2);
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.ZoomWindow(p1, p2);
        buEyeItems.viewportCNC.Invalidate();
        buEyeItems.viewportCNC.Invalidate();
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomWindow(p1, p2);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      }
      this.SaveParameterInterface();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_zoomselected.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.ZoomFit(true);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit(true);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      }
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewcube.Name)
      ;
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_pandown.Name)
    {
      buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount = (int) clsAppMarbleItems.frmViewsV1.spn_pandis.Value;
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.PanDown(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewPanDown(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
      this.SaveParameterInterface();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_panup.Name)
    {
      buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount = (int) clsAppMarbleItems.frmViewsV1.spn_pandis.Value;
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.PanUp(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewPanUp(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
      this.SaveParameterInterface();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_panleft.Name)
    {
      buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount = (int) clsAppMarbleItems.frmViewsV1.spn_pandis.Value;
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.PanLeft(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewPanLeft(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
      this.SaveParameterInterface();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_panright.Name)
    {
      buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount = (int) clsAppMarbleItems.frmViewsV1.spn_pandis.Value;
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        buEyeItems.viewportCNC.PanRight(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewPanRight(buMarbleCalc.varMarbleDisplaySettings.ViewPanAmount);
      this.SaveParameterInterface();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewpan.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        if (buEyeItems.viewportCNC.ActionMode != devDept.Eyeshot.actionType.Pan)
          buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.Pan;
        else
          buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.None;
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewPan();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.btn_viewrotate.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
      {
        if (buEyeItems.viewportCNC.ActionMode != devDept.Eyeshot.actionType.Rotate)
          buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.Rotate;
        else
          buEyeItems.viewportCNC.ActionMode = devDept.Eyeshot.actionType.None;
        buEyeItems.viewportCNC.Invalidate();
      }
      else
        clsInit.appCommand.cmdViewRotate();
    }
    if (!(control.Name == clsAppMarbleItems.frmViewsV1.btn_viewsettings.Name))
      return;
    if (!clsAppMarbleItems.frmViewsV1.pnl_settings.Visible)
      clsAppMarbleItems.frmViewsV1.pnl_settings.Visible = true;
    else
      clsAppMarbleItems.frmViewsV1.pnl_settings.Visible = false;
  }

  public void clickCommandsDrawing(object sender, EventArgs e)
  {
    // ISSUE: unable to decompile the method.
  }

  public void clickCommandToolsKinematic(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (clsAppMarbleVars.cMachine.runSystem.Run)
    {
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
    }
    else
    {
      if (control.Name == clsAppMarbleItems.frmKinematic.btn_savekinemtic.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = AppPath.MachineSettings;
        saveFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          clsAppMarbleItems.frmKinematic.Apply();
          buFile5.SaveKinematicFile(saveFileDialog.FileName, clsAppMarbleItems.frmKinematic.Kinematic);
        }
      }
      if (control.Name == clsAppMarbleItems.frmKinematic.btn_openkinematic.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = AppPath.MachineSettings;
        openFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
        openFileDialog.Multiselect = false;
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          KinematicBase5 kinematicBase5 = new KinematicBase5();
          buFile5.OpenKinemticFile(openFileDialog.FileName, ref kinematicBase5);
          clsAppMarbleItems.frmKinematic.Kinematic = new KinematicBase5(kinematicBase5);
          clsAppMarbleItems.frmKinematic.Init();
        }
      }
      if (control.Name == "btn_toolmagazineopen")
      {
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
          return;
        }
        if (AppBool.Connected)
          clsAppMarbleVars.cmdMarble.cmdToolMagazineOpenClose(true);
      }
      if (control.Name == "btn_toolmagazineClose")
      {
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
          return;
        }
        if (AppBool.Connected)
          clsAppMarbleVars.cmdMarble.cmdToolMagazineOpenClose(false);
      }
      if (control.Name == "btn_pensopenclose")
      {
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.PensEnable)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
          return;
        }
        if (AppBool.Connected)
        {
          bool pensState = clsAppMarbleVars.cmdMarble.getPensState();
          clsAppMarbleVars.cmdMarble.setPensState(!pensState);
        }
      }
      if (control.Name == "btn_spindlepistonup")
      {
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
        }
        else
        {
          if (!AppBool.Connected)
            return;
          this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SpindleUp");
        }
      }
      else if (control.Name == "btn_spindlepistondown")
      {
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
        }
        else
        {
          if (!AppBool.Connected)
            return;
          this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SpindleDown");
        }
      }
      else
      {
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolstop.Name)
          this.ClickCommand((MarbleMotionCommands) 2);
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_savetools.Name)
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = AppPath.MachineTool;
          saveFileDialog.Filter = "Tools File (*.butools)|*.butools";
          saveFileDialog.FilterIndex = 1;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
            clsInit.appFiles.SaveToolFile(new List<ToolBase5>()
            {
              buMarbleCalc.activeToolSaw,
              buMarbleCalc.activeToolMilling,
              buMarbleCalc.activeToolMillingHead
            });
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_opentools.Name)
        {
          OpenFileDialog openFileDialog = new OpenFileDialog();
          openFileDialog.InitialDirectory = AppPath.MachineTool;
          openFileDialog.Filter = "Tools File (*.butools)|*.butools";
          openFileDialog.Multiselect = false;
          openFileDialog.FilterIndex = 1;
          if (openFileDialog.ShowDialog() == DialogResult.OK)
          {
            List<ToolBase5> Tools = new List<ToolBase5>();
            clsInit.appFiles.OpenToolFile(ref Tools);
            bool flag = false;
            if (Tools.Count >= 3)
            {
              if (Tools[0].Purpose == ToolPurpose.Saw)
                buMarbleCalc.activeToolSaw = new ToolBase5(Tools[1]);
              else
                flag = true;
              if (Tools[1].Purpose == ToolPurpose.Milling)
                buMarbleCalc.activeToolMilling = new ToolBase5(Tools[0]);
              else
                flag = true;
              if (Tools[2].Purpose == ToolPurpose.MillingHead)
                buMarbleCalc.activeToolMillingHead = new ToolBase5(Tools[0]);
              else
                flag = true;
            }
            else
              flag = true;
            if (flag)
              buString.MessageBoxWarning(AppLanguage.CadCamMessages[92]);
          }
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_milling_activate.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("MillingActivate", 0);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_milling_limitdisable.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("MillingZLimitDisable", 0);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_milling_measure.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("MillingMeasure", 0);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_milling_zeroposition.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("MillingSetZero", 0);
        }
        if (control.Name == ((F_MarbleMachineSettingsV2) clsAppMarbleItems.frmToolCurrent).btn_milling_gozeroposition.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("MillingGoZero", 0);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_saw_activate.Name)
          this.ToolSawCommands("SawActivate");
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_sawlimitdisable.Name)
          this.ToolSawCommands("SawZLimitDisable");
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_saw_measure.Name)
          this.ToolSawCommands("SawMeasure");
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_saw_zeroposition.Name)
          this.ToolSawCommands("SawSetZero");
        if (control.Name == ((F_MarbleMachineSettingsV2) clsAppMarbleItems.frmToolCurrent).btn_saw_gozeroposition.Name)
          this.ToolSawCommands("SawGoZero");
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_millinghead_activate.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingHeadCommands("MillingHeadActivate");
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_millinghead_limitdisable.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingHeadCommands("MillingHeadZLimitDisable");
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_millinghead_measure.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingHeadCommands("MillingHeadMeasure");
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_millinghead_zeroposition.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingHeadCommands("MillingHeadSetZero");
        }
        if (control.Name == ((F_MarbleMachineSettingsV2) clsAppMarbleItems.frmToolCurrent).btn_millinghead_gozeroposition.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingHeadCommands("MillingHeadGoZero");
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset1.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 1);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset2.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 2);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset3.Name)
        {
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 3);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset4.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 4);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset5.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 5);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset6.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 6);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset7.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 7);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset8.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 8);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset9.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 9);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagset10.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          clsAppMarbleItems.frmToolCurrent.Apply();
          this.ToolMillingCommands("SetToolActive", 10);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake1.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("TakeTool", 1);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake2.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("TakeTool", 2);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake3.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("TakeTool", 3);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake4.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("TakeTool", 4);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake5.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("TakeTool", 5);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake6.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("TakeTool", 6);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake7.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("TakeTool", 7);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake8.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("TakeTool", 8);
        }
        if (control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake9.Name)
        {
          if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
            return;
          }
          this.ToolMillingCommands("TakeTool", 9);
        }
        if (!(control.Name == clsAppMarbleItems.frmToolCurrent.btn_toolmagtake10.Name))
          return;
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
        }
        else
          this.ToolMillingCommands("TakeTool", 10);
      }
    }
  }

  public void clickCommandMaintanance(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (!AppBool.Connected)
      return;
    string str = "";
    if (control is buButton && ((buControl) control).Aux.Command != null)
      str = " " + ((buControl) control).Aux.Command.ToString();
    buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
    dialogMessageBoxYesNo.Init(buLangTranslate.preDef.Clear, $"{buLangTranslate.preSentences.DoYouWantToDelete} {buLangTranslate.preDef.Counters}{str}");
    dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
    int num = (int) dialogMessageBoxYesNo.ShowDialog();
    if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
      return;
    if (control.Name == clsAppMarbleItems.frmMaintanance.btn_clearX.Name)
    {
      this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "AxisSetX.setMeasure.maintenanceTotalMeter");
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.XAxisMaintenance.Occur");
    }
    if (control.Name == clsAppMarbleItems.frmMaintanance.btn_clearY.Name)
    {
      this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "AxisSetY.setMeasure.maintenanceTotalMeter");
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.YAxisMaintenance.Occur");
    }
    if (control.Name == clsAppMarbleItems.frmMaintanance.btn_clearZ.Name)
    {
      this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "AxisSetZ.setMeasure.maintenanceTotalMeter");
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.ZAxisMaintenance.Occur");
    }
    if (control.Name == clsAppMarbleItems.frmMaintanance.btn_clearA.Name)
    {
      this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "AxisSetA.setMeasure.maintenanceTotalMeter");
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.AAxisMaintenance.Occur");
    }
    if (control.Name == clsAppMarbleItems.frmMaintanance.btn_clearC.Name)
    {
      this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "AxisSetC.setMeasure.maintenanceTotalMeter");
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.CAxisMaintenance.Occur");
    }
    if (control.Name == clsAppMarbleItems.frmMaintanance.btn_clearAir.Name)
    {
      this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "sysSet.Measure.MaintenanceAirHour");
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.AirMaintenance.Occur");
    }
    if (control.Name == clsAppMarbleItems.frmMaintanance.btn_clearHidro.Name)
    {
      this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "sysSet.Measure.MaintenanceHydraulicHour");
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.HidroMotorMaintenance.Occur");
    }
    if (control.Name == clsAppMarbleItems.frmMaintanance.btn_clearLubricate.Name)
    {
      this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "sysSet.Measure.MaintenanceLubricateHour");
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.LubricateMaintenance.Occur");
    }
    if (control.Name == clsAppMarbleItems.frmMaintanance.btn_clearCabinet.Name)
    {
      this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "sysSet.Measure.MaintenanceCabinetHour");
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.CabinetMaintenance.Occur");
    }
    if (!(control.Name == clsAppMarbleItems.frmMaintanance.btn_clearMachineClean.Name))
      return;
    this.writeLREALVar(CodesysVariableBaseType.Persistent, 0.0, "sysSet.Measure.MaintenanceMachineCleaningHour");
    this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "AppAlarms.MachineCleaningMaintenance.Occur");
  }

  public void clickCommandWarmUp(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.WarmMotors)
    {
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
    }
    else
    {
      if (!AppBool.Connected)
        return;
      if (control is buButton && ((buControl) control).Aux.Command != null)
      {
        string str = " " + ((buControl) control).Aux.Command.ToString();
      }
      if (control.Name == clsAppMarbleItems.frmWarmUp.btn_startsaw.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init(buLangTranslate.preDef.WarmUp, $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.WarmUp}{buLangTranslate.preSentences.DoYouWantToStart}");
        dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMaterialMeasurement) clsAppMarbleItems.frmWarmUp).Apply();
        clsAppMarbleVars.cMachine.bWriteAppParameter = true;
        Thread.Sleep(200);
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SawWarmUp");
      }
      if (control.Name == ((F_MarbleMaterialMeasurement) clsAppMarbleItems.frmWarmUp).btn_stopsaw.Name)
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SawWarmUpStop");
      if (control.Name == ((F_MarbleMaterialMeasurement) clsAppMarbleItems.frmWarmUp).btn_startmilling.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init(buLangTranslate.preDef.WarmUp, $"{buLangTranslate.preDef.Spindle} {buLangTranslate.preDef.WarmUp}{buLangTranslate.preSentences.DoYouWantToStart}");
        dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMaterialMeasurement) clsAppMarbleItems.frmWarmUp).Apply();
        clsAppMarbleVars.cMachine.bWriteAppParameter = true;
        Thread.Sleep(200);
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SpindleWarmUp");
      }
      if (!(control.Name == ((F_MarbleMaterialMeasurement) clsAppMarbleItems.frmWarmUp).btn_stopmilling.Name))
        return;
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SpindleWarmUpStop");
    }
  }

  public void clickG54AndAbsoluteSet(object sender, EventArgs e)
  {
    string callMethod = nameof (clickG54AndAbsoluteSet);
    try
    {
      System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
      // ISSUE: reference to a compiler-generated field
      if (clsAppMarbleVars.cMachine.runSystem.Run && ((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
      }
      // ISSUE: reference to a compiler-generated field
      if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated && ((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
      }
      if (clsAppMarbleItems.frmG54Set != null && control.Name == clsAppMarbleItems.frmG54Set.btn_xG54set.Name | control.Name == clsAppMarbleItems.frmG54Set.btn_yG54set.Name | control.Name == clsAppMarbleItems.frmG54Set.btn_zG54set.Name)
      {
        if (!clsAppMarbleVars.cMachine.runSystem.HomingDone)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.HomingMissing, (object) null, (object) null, (object) null);
          return;
        }
        double num;
        if (control.Name == clsAppMarbleItems.frmG54Set.btn_xG54set.Name)
        {
          // ISSUE: reference to a compiler-generated field
          string str1 = ((clsAppMarble.\u003C\u003Ec) this).\u0001;
          string str2 = callMethod;
          num = clsAppMarbleItems.frmG54Set.spn_xG54.Value;
          string str3 = num.ToString();
          buLogMarbleVer5.addToLog(str1, str2, "G54.X Write", str3, "", 0.0, 0.0, false);
          clsAppMarbleVars.cMachine.G54List[0].X = clsAppMarbleItems.frmG54Set.spn_xG54.Value;
        }
        if (control.Name == clsAppMarbleItems.frmG54Set.btn_yG54set.Name)
        {
          // ISSUE: reference to a compiler-generated field
          string str4 = ((clsAppMarble.\u003C\u003Ec) this).\u0001;
          string str5 = callMethod;
          num = clsAppMarbleItems.frmG54Set.spn_yG54.Value;
          string str6 = num.ToString();
          buLogMarbleVer5.addToLog(str4, str5, "G54.Y Write", str6, "", 0.0, 0.0, false);
          clsAppMarbleVars.cMachine.G54List[0].Y = clsAppMarbleItems.frmG54Set.spn_yG54.Value;
        }
        if (control.Name == clsAppMarbleItems.frmG54Set.btn_zG54set.Name)
        {
          // ISSUE: reference to a compiler-generated field
          string str7 = ((clsAppMarble.\u003C\u003Ec) this).\u0001;
          string str8 = callMethod;
          num = clsAppMarbleItems.frmG54Set.spn_zG54.Value;
          string str9 = num.ToString();
          buLogMarbleVer5.addToLog(str7, str8, "G54.Z Write", str9, "", 0.0, 0.0, false);
          clsAppMarbleVars.cMachine.G54List[0].Z = clsAppMarbleItems.frmG54Set.spn_zG54.Value;
        }
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 7, (object) null, (object) null, (object) null, (object) null);
        }
      }
      string str10 = "";
      string str11 = "";
      string str12 = "";
      string str13 = "";
      string str14 = "";
      double Val = 0.0;
      if ((clsAppMarbleItems.frmAbsoluteSet == null ? 0 : (clsAppMarbleItems.frmAbsoluteSet.Visible ? 1 : 0)) != 0)
      {
        if (control.Name == clsAppMarbleItems.frmAbsoluteSet.btn_xrabsoluteeset.Name)
        {
          str10 = clsAppMarbleItems.frmAbsoluteSet.btn_xrabsoluteeset.Name;
          Val = clsAppMarbleItems.frmAbsoluteSet.spn_absolutesetX.Value;
        }
        if (control.Name == clsAppMarbleItems.frmAbsoluteSet.btn_yabsolutereset.Name)
        {
          str11 = clsAppMarbleItems.frmAbsoluteSet.btn_yabsolutereset.Name;
          Val = clsAppMarbleItems.frmAbsoluteSet.spn_absolutesetY.Value;
        }
        if (control.Name == clsAppMarbleItems.frmAbsoluteSet.btn_zabsolutereset.Name)
        {
          str12 = clsAppMarbleItems.frmAbsoluteSet.btn_zabsolutereset.Name;
          Val = clsAppMarbleItems.frmAbsoluteSet.spn_absolutesetZ.Value;
        }
        if (control.Name == clsAppMarbleItems.frmAbsoluteSet.btn_aabsolutereset.Name)
        {
          str13 = clsAppMarbleItems.frmAbsoluteSet.btn_aabsolutereset.Name;
          Val = clsAppMarbleItems.frmAbsoluteSet.spn_absolutesetA.Value;
        }
        if (control.Name == clsAppMarbleItems.frmAbsoluteSet.btn_cabsolutereset.Name)
        {
          str14 = clsAppMarbleItems.frmAbsoluteSet.btn_cabsolutereset.Name;
          Val = clsAppMarbleItems.frmAbsoluteSet.spn_absolutesetC.Value;
        }
      }
      if ((clsAppMarbleItems.frmMachineSettingsV2 == null ? 0 : (clsAppMarbleItems.frmMachineSettingsV2.Visible ? 1 : 0)) != 0)
      {
        if (control.Name == clsAppMarbleItems.frmMachineSettingsV2.btn_xrabsoluteeset.Name)
        {
          str10 = clsAppMarbleItems.frmMachineSettingsV2.btn_xrabsoluteeset.Name;
          Val = clsAppMarbleItems.frmMachineSettingsV2.spn_absolutesetX.Value;
        }
        if (control.Name == clsAppMarbleItems.frmMachineSettingsV2.btn_yabsolutereset.Name)
        {
          str11 = clsAppMarbleItems.frmMachineSettingsV2.btn_yabsolutereset.Name;
          Val = clsAppMarbleItems.frmMachineSettingsV2.spn_absolutesetY.Value;
        }
        if (control.Name == clsAppMarbleItems.frmMachineSettingsV2.btn_zabsolutereset.Name)
        {
          str12 = clsAppMarbleItems.frmMachineSettingsV2.btn_zabsolutereset.Name;
          Val = clsAppMarbleItems.frmMachineSettingsV2.spn_absolutesetZ.Value;
        }
        if (control.Name == clsAppMarbleItems.frmMachineSettingsV2.btn_aabsolutereset.Name)
        {
          str13 = clsAppMarbleItems.frmMachineSettingsV2.btn_aabsolutereset.Name;
          Val = clsAppMarbleItems.frmMachineSettingsV2.spn_absolutesetA.Value;
        }
        if (control.Name == clsAppMarbleItems.frmMachineSettingsV2.btn_cabsolutereset.Name)
        {
          str14 = clsAppMarbleItems.frmMachineSettingsV2.btn_cabsolutereset.Name;
          Val = clsAppMarbleItems.frmMachineSettingsV2.spn_absolutesetC.Value;
        }
      }
      if (!(str10.Length > 0 | str11.Length > 0 | str12.Length > 0 | str13.Length > 0 | str14.Length > 0))
        return;
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      if (control.Name == str10)
      {
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AbsoluteXAxis)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
        }
        else
        {
          dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Absolute} {buLangTranslate.preDef.Zero}", buLangTranslate.preSentences.DoYouWantToResetPosition + " X");
          int num = (int) dialogMessageBoxYesNo.ShowDialog();
          if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
            return;
          // ISSUE: reference to a compiler-generated field
          buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Absolute Set.X", clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition.ToString("f3") + " To 0", "", 0.0, 0.0, false);
          if (!AppBool.Connected)
            return;
          this.writeLREALVar(CodesysVariableBaseType.Global, Val, "AppRun.AbsoluteHomePositionX");
          this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.XHome");
        }
      }
      else if (control.Name == str11)
      {
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AbsoluteYAxis)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
        }
        else
        {
          dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Absolute} {buLangTranslate.preDef.Zero}", buLangTranslate.preSentences.DoYouWantToResetPosition + " Y");
          int num = (int) dialogMessageBoxYesNo.ShowDialog();
          if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
            return;
          // ISSUE: reference to a compiler-generated field
          buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Absolute Set.Y", clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition.ToString("f3") + " To 0", "", 0.0, 0.0, false);
          if (!AppBool.Connected)
            return;
          this.writeLREALVar(CodesysVariableBaseType.Global, Val, "AppRun.AbsoluteHomePositionY");
          this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.YHome");
        }
      }
      else if (control.Name == str12)
      {
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AbsoluteZAxis)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
        }
        else
        {
          dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Absolute} {buLangTranslate.preDef.Zero}", buLangTranslate.preSentences.DoYouWantToResetPosition + " Z");
          int num = (int) dialogMessageBoxYesNo.ShowDialog();
          if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
            return;
          // ISSUE: reference to a compiler-generated field
          buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Absolute Set.Z", clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition.ToString("f3") + " To 0", "", 0.0, 0.0, false);
          if (!AppBool.Connected)
            return;
          this.writeLREALVar(CodesysVariableBaseType.Global, Val, "AppRun.AbsoluteHomePositionZ");
          this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.ZHome");
        }
      }
      else if (control.Name == str13)
      {
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AbsoluteAAxis)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
        }
        else
        {
          dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Absolute} {buLangTranslate.preDef.Zero}", buLangTranslate.preSentences.DoYouWantToResetPosition + " A");
          int num = (int) dialogMessageBoxYesNo.ShowDialog();
          if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
            return;
          // ISSUE: reference to a compiler-generated field
          buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Absolute Set.A", clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition.ToString("f3") + " To 0", "", 0.0, 0.0, false);
          if (!AppBool.Connected)
            return;
          this.writeLREALVar(CodesysVariableBaseType.Global, Val, "AppRun.AbsoluteHomePositionA");
          this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.AHome");
        }
      }
      else
      {
        if (!(control.Name == str14))
          return;
        if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.AbsoluteCAxis)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
        }
        else
        {
          dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Absolute} {buLangTranslate.preDef.Zero}", buLangTranslate.preSentences.DoYouWantToResetPosition + " C");
          int num = (int) dialogMessageBoxYesNo.ShowDialog();
          if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
            return;
          // ISSUE: reference to a compiler-generated field
          buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Absolute Set.C", clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition.ToString("f3") + " To 0", "", 0.0, 0.0, false);
          if (!AppBool.Connected)
            return;
          this.writeLREALVar(CodesysVariableBaseType.Global, Val, "AppRun.AbsoluteHomePositionC");
          this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.CHome");
        }
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void clickAlarmReset(object sender, EventArgs e)
  {
    if (AppBool.Connected)
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.AlarmReset");
    clsAppMarbleVars.cMachine.AlarmList.Clear();
    clsAppMarbleItems.FrmAlarm.lst_alarm.Items.Clear();
    clsAppMarbleItems.FrmAlarm.Visible = false;
    clsAppMarbleVars.cMachine.preVar.AlarmCountPre = -1;
  }

  public void clickWarningReset(object sender, EventArgs e)
  {
    if (AppBool.Connected)
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.WarningClear");
    clsAppMarbleVars.cMachine.WarningList.Clear();
    clsAppMarbleVars.cMachine.preVar.WarningCountPre = -1;
    AppWarning.Warnings.Clear();
    clsAppMarbleItems.FrmWarning.lst_warning.Items.Clear();
    clsAppMarbleItems.FrmWarning.Visible = false;
  }

  public void checkCheckedChanged(object sender, bool CheckStatus)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    switch (sender)
    {
      case buCheckBox _:
        if (((buControl) sender).Aux.Command.Trim().Length > 0)
        {
          string command = ((buControl) sender).Aux.Command;
        }
        int num1 = ((buCheckBox) sender).Check ? 1 : 0;
        break;
      case CheckBox _:
        int num2 = ((CheckBox) sender).Checked ? 1 : 0;
        break;
    }
    if ((clsAppMarbleItems.frmJogPageV1 == null ? 0 : (AppBool.Inited ? 1 : 0)) != 0)
    {
      if (control.Name == clsAppMarbleItems.frmJogPageV1.chk_incremental.Name)
      {
        AppBool.Inited = false;
        clsAppMarbleVars.varInterface.IncrementalMode = clsAppMarbleItems.frmJogPageV1.chk_incremental.Check;
        clsAppMarbleItems.frmJogPageV1.chk_absolute.Check = false;
        clsAppMarbleVars.varInterface.AbsoluteMode = false;
        AppBool.Inited = true;
        AppBool.SaveByTick = true;
      }
      if (control.Name == clsAppMarbleItems.frmJogPageV1.chk_absolute.Name)
      {
        AppBool.Inited = false;
        clsAppMarbleVars.varInterface.AbsoluteMode = clsAppMarbleItems.frmJogPageV1.chk_absolute.Check;
        clsAppMarbleItems.frmJogPageV1.chk_incremental.Check = false;
        clsAppMarbleVars.varInterface.IncrementalMode = false;
        AppBool.Inited = true;
        AppBool.SaveByTick = true;
      }
      if (control.Name == clsAppMarbleItems.frmJogPageV1.chk_machinezero.Name)
      {
        AppBool.Inited = false;
        clsAppMarbleItems.frmJogPageV1.chk_partzero.Check = false;
        clsAppMarbleVars.varInterface.PartZeroMode = false;
        AppBool.Inited = true;
        AppBool.SaveByTick = true;
      }
      if (control.Name == clsAppMarbleItems.frmJogPageV1.chk_partzero.Name)
      {
        AppBool.Inited = false;
        clsAppMarbleItems.frmJogPageV1.chk_machinezero.Check = false;
        clsAppMarbleVars.varInterface.PartZeroMode = true;
        AppBool.Inited = true;
        AppBool.SaveByTick = true;
      }
      if (control.Name == clsAppMarbleItems.frmJogPageV1.chk_addsawthickness.Name)
      {
        AppBool.Inited = false;
        clsAppMarbleVars.varInterface.AddSawThicknessToMove = clsAppMarbleItems.frmJogPageV1.chk_addsawthickness.Check;
        AppBool.Inited = true;
        AppBool.SaveByTick = true;
      }
    }
    if (!AppBool.Inited || clsAppMarbleItems.frmViewsV1 == null)
      return;
    if (control.Name == clsAppMarbleItems.frmViewsV1.chk_grid.Name)
    {
      if (clsAppMarbleVars.varRuntime.isMainTab)
        buMarbleCalc.varMarbleRunSettings.ShowGridCNC = clsAppMarbleItems.frmViewsV1.chk_grid.Check;
      else
        buMarbleCalc.varMarbleRunSettings.ShowGridCadCam = clsAppMarbleItems.frmViewsV1.chk_grid.Check;
      clsInit.appMarble.UpdateCadCamParameters();
      clsInit.appMarble.GridUpdate();
    }
    if (control.Name == clsAppMarbleItems.frmViewsV1.chk_snap.Name)
    {
      buMarbleCalc.varMarbleRunSettings.SnapEnable = clsAppMarbleItems.frmViewsV1.chk_snap.Check;
      clsInit.appMarble.GridUpdate();
    }
    if (!(control.Name == clsAppMarbleItems.frmViewsV1.chk_viewportrotate.Name))
      return;
    if (clsAppMarbleVars.varRuntime.isMainTab)
    {
      buMarbleCalc.varMarbleRunSettings.RotateCameraCNC = clsAppMarbleItems.frmViewsV1.chk_viewportrotate.Check;
      buEyeItems.viewportCNC = this.CameraRotationUpdate(buMarbleCalc.varMarbleRunSettings.RotateCameraCNC, buEyeItems.viewportCNC);
    }
    else
    {
      buMarbleCalc.varMarbleRunSettings.RotateCameraCadCam = clsAppMarbleItems.frmViewsV1.chk_viewportrotate.Check;
      clsInit.appMarble.CameraRotationUpdate(buMarbleCalc.varMarbleRunSettings.RotateCameraCadCam);
    }
  }

  private void \u0001([In] object obj0, [In] double obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (!AppBool.Inited || clsAppMarbleItems.frmJogPageV1 == null)
      return;
    if (control.Name == clsAppMarbleItems.frmJogPageV1.spn_xpos.Name)
    {
      AppBool.Inited = false;
      clsAppMarbleItems.frmJogPageV1.btn_xplus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_xpos.Value;
      clsAppMarbleItems.frmJogPageV1.btn_xminus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_xpos.Value;
      clsAppMarbleVars.varInterface.JogMoveXValue = clsAppMarbleItems.frmJogPageV1.spn_xpos.Value;
      AppBool.Inited = true;
      AppBool.SaveByTick = true;
    }
    if (control.Name == clsAppMarbleItems.frmJogPageV1.spn_ypos.Name)
    {
      AppBool.Inited = false;
      clsAppMarbleItems.frmJogPageV1.btn_yplus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_ypos.Value;
      clsAppMarbleItems.frmJogPageV1.btn_yminus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_ypos.Value;
      clsAppMarbleVars.varInterface.JogMoveYValue = clsAppMarbleItems.frmJogPageV1.spn_ypos.Value;
      AppBool.Inited = true;
      AppBool.SaveByTick = true;
    }
    if (control.Name == clsAppMarbleItems.frmJogPageV1.spn_zpos.Name)
    {
      AppBool.Inited = false;
      ((F_MarbleInfoList) clsAppMarbleItems.frmJogPageV1).btn_zplus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_zpos.Value;
      ((F_MarbleInfoList) clsAppMarbleItems.frmJogPageV1).btn_zminus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_zpos.Value;
      clsAppMarbleVars.varInterface.JogMoveZValue = clsAppMarbleItems.frmJogPageV1.spn_zpos.Value;
      AppBool.Inited = true;
      AppBool.SaveByTick = true;
    }
    if (control.Name == clsAppMarbleItems.frmJogPageV1.spn_apos.Name)
    {
      AppBool.Inited = false;
      ((F_MarbleInfoList) clsAppMarbleItems.frmJogPageV1).btn_aplus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_apos.Value;
      ((F_MarbleInfoList) clsAppMarbleItems.frmJogPageV1).btn_aminus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_apos.Value;
      clsAppMarbleVars.varInterface.JogMoveAValue = clsAppMarbleItems.frmJogPageV1.spn_apos.Value;
      AppBool.Inited = true;
      AppBool.SaveByTick = true;
    }
    if (!(control.Name == clsAppMarbleItems.frmJogPageV1.spn_cpos.Name))
      return;
    AppBool.Inited = false;
    ((F_MarbleInfoList) clsAppMarbleItems.frmJogPageV1).btn_cplus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_cpos.Value;
    ((F_MarbleInfoList) clsAppMarbleItems.frmJogPageV1).btn_cminus.Aux.ValDouble = clsAppMarbleItems.frmJogPageV1.spn_cpos.Value;
    clsAppMarbleVars.varInterface.JogMoveCValue = clsAppMarbleItems.frmJogPageV1.spn_cpos.Value;
    AppBool.Inited = true;
    AppBool.SaveByTick = true;
  }

  public void FormKeyDownCommon(object sender, KeyEventArgs e)
  {
    if ((!e.Shift ? 0 : (e.Control ? 1 : 0)) == 0)
      return;
    if (e.KeyCode == Keys.D1 && buMarbleCalc.varMarbleSettings.ScreenCapture.SC1Enable)
      buImage5.GetScreenShotAndSaveFile(buMarbleCalc.varMarbleSettings.ScreenCapture.SC1Left, buMarbleCalc.varMarbleSettings.ScreenCapture.SC1Top, buMarbleCalc.varMarbleSettings.ScreenCapture.SC1Width, buMarbleCalc.varMarbleSettings.ScreenCapture.SC1Height, buMarbleCalc.varMarbleSettings.ScreenCapture.SC1AutoSave, "SC1.png", AppPath.ScreenCaptureImage);
    if (e.KeyCode == Keys.D2 && buMarbleCalc.varMarbleSettings.ScreenCapture.SC2Enable)
      buImage5.GetScreenShotAndSaveFile(buMarbleCalc.varMarbleSettings.ScreenCapture.SC2Left, buMarbleCalc.varMarbleSettings.ScreenCapture.SC2Top, buMarbleCalc.varMarbleSettings.ScreenCapture.SC2Width, buMarbleCalc.varMarbleSettings.ScreenCapture.SC2Height, buMarbleCalc.varMarbleSettings.ScreenCapture.SC2AutoSave, "SC2.png", AppPath.ScreenCaptureImage);
    if (e.KeyCode == Keys.D3 && buMarbleCalc.varMarbleSettings.ScreenCapture.SC3Enable)
      buImage5.GetScreenShotAndSaveFile(buMarbleCalc.varMarbleSettings.ScreenCapture.SC3Left, buMarbleCalc.varMarbleSettings.ScreenCapture.SC3Top, buMarbleCalc.varMarbleSettings.ScreenCapture.SC3Width, buMarbleCalc.varMarbleSettings.ScreenCapture.SC3Height, buMarbleCalc.varMarbleSettings.ScreenCapture.SC3AutoSave, "SC3.png", AppPath.ScreenCaptureImage);
    if (e.KeyCode == Keys.D4 && buMarbleCalc.varMarbleSettings.ScreenCapture.SC4Enable)
      buImage5.GetScreenShotAndSaveFile(buMarbleCalc.varMarbleSettings.ScreenCapture.SC4Left, buMarbleCalc.varMarbleSettings.ScreenCapture.SC4Top, buMarbleCalc.varMarbleSettings.ScreenCapture.SC4Width, buMarbleCalc.varMarbleSettings.ScreenCapture.SC4Height, buMarbleCalc.varMarbleSettings.ScreenCapture.SC4AutoSave, "SC4.png", AppPath.ScreenCaptureImage);
    if (e.KeyCode != Keys.D5 || !buMarbleCalc.varMarbleSettings.ScreenCapture.SC5Enable)
      return;
    buImage5.GetScreenShotAndSaveFile(buMarbleCalc.varMarbleSettings.ScreenCapture.SC5Left, buMarbleCalc.varMarbleSettings.ScreenCapture.SC5Top, buMarbleCalc.varMarbleSettings.ScreenCapture.SC5Width, buMarbleCalc.varMarbleSettings.ScreenCapture.SC5Height, buMarbleCalc.varMarbleSettings.ScreenCapture.SC5AutoSave, "SC5.png", AppPath.ScreenCaptureImage);
  }

  public void Jog_MouseDown(object sender, MouseEventArgs e)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    int index = AppProcess.SelectedAxis;
    double num = 1.0;
    if (clsAppMarbleVars.cMachine.runSystem.WagonUp)
    {
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentencesMarble.WagonUpPosition, (object) Color.Gold, (object) null, (object) null);
    }
    else
    {
      if (sender.GetType() == typeof (buButton))
      {
        if (((buControl) sender).Motion.AxisIndex >= 0)
          index = ((buControl) sender).Motion.AxisIndex;
        string note = ((buControl) sender).Motion.Note;
        num = ((buControl) sender).Motion.Value;
        if (num > 0.0)
        {
          AppBool.JogPlus = true;
          AppBool.JogMinus = false;
        }
        else
        {
          AppBool.JogPlus = false;
          AppBool.JogMinus = true;
        }
      }
      if (AppBool.Offline && !clsAppMarbleVars.varInterface.IncrementalMode & !clsAppMarbleVars.varInterface.AbsoluteMode)
      {
        AppBool.MouseDowned = true;
        AppBool.AxesX = false;
        AppBool.AxesY = false;
        AppBool.AxesZ = false;
        AppBool.AxesA = false;
        AppBool.AxesC = false;
        if (index == 0)
          AppBool.AxesX = true;
        if (index == 1)
          AppBool.AxesY = true;
        if (index == 2)
          AppBool.AxesZ = true;
        if (index == 3)
          AppBool.AxesC = true;
        if (index == 4)
          AppBool.AxesA = true;
      }
      if (!AppBool.Connected || clsAppMarbleVars.cMachine.runSystem.SemiAuto && index == 0 | index == 1 | index == 2)
        return;
      if (buMarbleCalc.varMarbleMachineSettings.OptionSettings.ServoAxisA)
      {
        if (!(clsAppMarbleVars.cMachine.varJog.Enable & !clsAppMarbleVars.varInterface.IncrementalMode & !clsAppMarbleVars.varInterface.AbsoluteMode))
          return;
        if (clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Runtime.Bool.bAllowToMove)
        {
          this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.boolData.bMove");
          if (num > 0.0)
            clsAppMarbleVars.cMachine.Commands.jogForward(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, true);
          else
            clsAppMarbleVars.cMachine.Commands.jogBackward(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, true);
        }
        else
        {
          string Val = "";
          string str = $"{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar} {buLangTranslate.preDef.Jog}";
          this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.CJogNotAllowMessage", ref Val);
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
        }
      }
      else if (index != 4)
      {
        if (!(clsAppMarbleVars.cMachine.varJog.Enable & !clsAppMarbleVars.varInterface.IncrementalMode & !clsAppMarbleVars.varInterface.AbsoluteMode))
          return;
        if (clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Runtime.Bool.bAllowToMove)
        {
          this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.boolData.bMove");
          if (num > 0.0)
            clsAppMarbleVars.cMachine.Commands.jogForward(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, true);
          else
            clsAppMarbleVars.cMachine.Commands.jogBackward(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, true);
        }
        else
        {
          string Val = "";
          string str = $"{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar} {buLangTranslate.preDef.Jog}";
          this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.CJogNotAllowMessage", ref Val);
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) $"{str} : {Val}", (object) null, (object) null, (object) null, (object) null);
        }
      }
      else if (clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Runtime.Bool.bAllowToMove)
      {
        if (num > 0.0)
          this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.AAxis0");
        else
          this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.AAxis45");
      }
      else
      {
        string Val = "";
        string str = $"{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar} {buLangTranslate.preDef.Jog}";
        this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.CJogNotAllowMessage", ref Val);
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) $"{str} : {Val}", (object) null, (object) null, (object) null, (object) null);
      }
    }
  }

  public void Jog_MouseUp(object sender, MouseEventArgs e)
  {
    int index = AppProcess.SelectedAxis;
    if (sender.GetType() == typeof (buButton))
    {
      if (((buControl) sender).Motion.AxisIndex >= 0)
        index = ((buControl) sender).Motion.AxisIndex;
      string note = ((buControl) sender).Motion.Note;
      double num = ((buControl) sender).Motion.Value;
    }
    if (AppBool.Offline && !clsAppMarbleVars.varInterface.IncrementalMode & !clsAppMarbleVars.varInterface.AbsoluteMode)
      AppBool.MouseDowned = false;
    AppBool.JogPlus = false;
    AppBool.JogMinus = false;
    if (!AppBool.Connected)
      return;
    if (buMarbleCalc.varMarbleMachineSettings.OptionSettings.ServoAxisA)
    {
      clsAppMarbleVars.cMachine.Commands.jogStop(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar);
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "sysRun.boolData.bMove");
    }
    else if (index != 4)
    {
      clsAppMarbleVars.cMachine.Commands.jogStop(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar);
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "sysRun.boolData.bMove");
    }
    else
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.AAxisStop");
  }

  public void Jog_Click(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    int index = AppProcess.SelectedAxis;
    double Dir = 1.0;
    if ((clsAppMarbleItems.frmJogPageV1 == null || !clsAppMarbleItems.frmJogPageV1.Visible ? 0 : (control.Name == ((F_MarbleInfoList) clsAppMarbleItems.frmJogPageV1).btn_stop.Name ? 1 : 0)) != 0)
      this.ClickCommand((MarbleMotionCommands) 2);
    else if (clsAppMarbleVars.cMachine.runSystem.WagonUp)
    {
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentencesMarble.WagonUpPosition, (object) Color.Gold, (object) null, (object) null);
    }
    else if ((clsAppMarbleItems.frmGantryMoveV1 == null ? 0 : (control.Name == clsAppMarbleItems.frmGantryMoveV1.btn_y2plusgantry.Name ? 1 : 0)) != 0)
    {
      clsAppMarbleVars.varInterface.JogGantryY2Move = clsAppMarbleItems.frmGantryMoveV1.spn_ypos.Value;
      clsAppMarbleVars.cMachine.Commands.moveIncremental(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar, 0.0, clsAppMarbleVars.varInterface.JogGantryY2Move, 1.0, true);
      AppBool.SaveByTick = true;
    }
    else if ((clsAppMarbleItems.frmGantryMoveV1 == null ? 0 : (control.Name == clsAppMarbleItems.frmGantryMoveV1.btn_y2minusgantry.Name ? 1 : 0)) != 0)
    {
      clsAppMarbleVars.varInterface.JogGantryY2Move = clsAppMarbleItems.frmGantryMoveV1.spn_ypos.Value;
      clsAppMarbleVars.cMachine.Commands.moveIncremental(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar, 0.0, clsAppMarbleVars.varInterface.JogGantryY2Move, -1.0, true);
      AppBool.SaveByTick = true;
    }
    else
    {
      if ((clsAppMarbleItems.frmJogPageV1 == null ? 0 : (clsAppMarbleItems.frmJogPageV1.Visible ? 1 : 0)) != 0)
      {
        if (control.Name == ((F_MarbleMotorWarmUp) clsAppMarbleItems.frmJogPageV1).btn_A0.Name)
        {
          this.ClickCommand((MarbleMotionCommands) 8);
          return;
        }
        if (control.Name == ((F_MarbleMotorWarmUp) clsAppMarbleItems.frmJogPageV1).btn_A45.Name)
        {
          this.ClickCommand((MarbleMotionCommands) 9);
          return;
        }
        if (control.Name == ((F_MarbleInfoList) clsAppMarbleItems.frmJogPageV1).btn_A46.Name)
        {
          this.ClickCommand((MarbleMotionCommands) 42);
          return;
        }
        if (control.Name == ((F_MarbleMotorWarmUp) clsAppMarbleItems.frmJogPageV1).btn_A90.Name)
        {
          this.ClickCommand((MarbleMotionCommands) 10);
          return;
        }
        if (control.Name == ((F_MarbleMotorWarmUp) clsAppMarbleItems.frmJogPageV1).btn_c0.Name)
        {
          this.ClickCommand((MarbleMotionCommands) 4);
          return;
        }
        if (control.Name == ((F_MarbleMotorWarmUp) clsAppMarbleItems.frmJogPageV1).btn_c90.Name)
        {
          this.ClickCommand((MarbleMotionCommands) 5);
          return;
        }
        if (control.Name == ((F_MarbleMotorWarmUp) clsAppMarbleItems.frmJogPageV1).btn_c180.Name)
        {
          this.ClickCommand((MarbleMotionCommands) 6);
          return;
        }
        if (control.Name == ((F_MarbleMotorWarmUp) clsAppMarbleItems.frmJogPageV1).btn_c270.Name)
        {
          this.ClickCommand((MarbleMotionCommands) 41);
          return;
        }
      }
      if (sender.GetType() == typeof (buButton))
      {
        if (((buControl) sender).Motion.AxisIndex >= 0)
          index = ((buControl) sender).Motion.AxisIndex;
        string note = ((buControl) sender).Motion.Note;
        Dir = ((buControl) sender).Motion.Value;
        clsAppMarbleVars.varInterface.JogMoveValue = ((buControl) sender).Aux.ValDouble;
        AppBool.SaveByTick = true;
      }
      if (AppBool.Offline)
      {
        if (clsAppMarbleVars.varInterface.AbsoluteMode)
        {
          if (index == 0)
            MarbleTempVars.SimulationPoint.X = clsAppMarbleVars.varInterface.JogMoveValue;
          if (index == 1)
            MarbleTempVars.SimulationPoint.Y = clsAppMarbleVars.varInterface.JogMoveValue;
          if (index == 2)
            MarbleTempVars.SimulationPoint.Z = clsAppMarbleVars.varInterface.JogMoveValue;
          if (index == 3)
            MarbleTempVars.SimulationPoint.C = clsAppMarbleVars.varInterface.JogMoveValue;
          if (index == 4)
            MarbleTempVars.SimulationPoint.A = clsAppMarbleVars.varInterface.JogMoveValue;
        }
        if (clsAppMarbleVars.varInterface.IncrementalMode)
        {
          double num = clsAppMarbleVars.varInterface.JogMoveValue;
          if (Dir < 0.0)
            num = -clsAppMarbleVars.varInterface.JogMoveValue;
          if (index == 0)
            MarbleTempVars.SimulationPoint.X += num;
          if (index == 1)
            MarbleTempVars.SimulationPoint.Y += num;
          if (index == 2)
            MarbleTempVars.SimulationPoint.Z += num;
          if (index == 3)
            MarbleTempVars.SimulationPoint.C += num;
          if (index == 4)
            MarbleTempVars.SimulationPoint.A += num;
        }
      }
      if (!AppBool.Connected)
        return;
      if (clsAppMarbleVars.cMachine.runSystem.SemiAuto && index == 0 | index == 1 | index == 2)
      {
        if (index == 0)
        {
          if (Dir > 0.0)
            this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.XPlusVirtual");
          else
            this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.XMinusVirtual");
        }
        if (index == 1)
        {
          if (Dir > 0.0)
            this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.YPlusVirtual");
          else
            this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.YMinusVirtual");
        }
        if (index != 2)
          return;
        if (Dir > 0.0)
          this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.ZPlusVirtual");
        else
          this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.ZMinusVirtual");
      }
      else if (buMarbleCalc.varMarbleMachineSettings.OptionSettings.ServoAxisA)
      {
        if (clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Runtime.Bool.bAllowToMove)
        {
          if (clsAppMarbleVars.varInterface.AbsoluteMode)
          {
            if (index == 4)
            {
              string Val = "";
              string str = $"{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar} {buLangTranslate.preDef.Move}";
              double num = clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Runtime.Actual.actualPosition - clsAppMarbleVars.varInterface.JogMoveValue;
              if (clsAppMarbleVars.varRuntime.APositiveMoveNotAllow & num < 0.0)
              {
                this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.AJogNotAllowMessage", ref Val);
                // ISSUE: reference to a compiler-generated field
                ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
              }
              else if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove)
                clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, clsAppMarbleVars.varInterface.JogMoveValue, true);
              else if (num > 0.0)
              {
                clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, clsAppMarbleVars.varInterface.JogMoveValue, true);
              }
              else
              {
                this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.AJogNotAllowMessage", ref Val);
                // ISSUE: reference to a compiler-generated field
                ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
              }
            }
            else
            {
              double num = 0.0;
              if (clsAppMarbleVars.varInterface.PartZeroMode)
              {
                if (index == 0)
                  num = clsAppMarbleVars.cMachine.G54List[0].X;
                if (index == 1)
                  num = clsAppMarbleVars.cMachine.G54List[0].Y;
              }
              clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, clsAppMarbleVars.varInterface.JogMoveValue + num, true);
            }
          }
          else
          {
            if (!clsAppMarbleVars.varInterface.IncrementalMode)
              return;
            double num = 0.0;
            bool flag = true;
            if (index == 0 | index == 1)
              num = buMarbleCalc.activeToolSaw.Geometry.Thickness;
            if (!clsAppMarbleVars.varInterface.AddSawThicknessToMove)
              num = 0.0;
            if (index == 4)
            {
              string Val = "";
              string str = $"{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar} {buLangTranslate.preDef.Move}";
              if (!clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove & Dir > 0.0)
              {
                this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.AJogNotAllowMessage", ref Val);
                // ISSUE: reference to a compiler-generated field
                ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
                flag = false;
              }
              if (clsAppMarbleVars.varRuntime.APositiveMoveNotAllow & Dir > 0.0)
              {
                this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.AJogNotAllowMessage", ref Val);
                // ISSUE: reference to a compiler-generated field
                ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
                flag = false;
              }
            }
            if (!flag)
              return;
            clsAppMarbleVars.cMachine.Commands.moveIncremental(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, clsAppMarbleVars.varInterface.JogMoveValue + num, Dir, true);
          }
        }
        else
        {
          string Val = "";
          string str = $"{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar} {buLangTranslate.preDef.Move}";
          this.readSTRINGVar(CodesysVariableBaseType.Global, $"AppRun.{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar}JogNotAllowMessage", ref Val);
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
        }
      }
      else if (index != 4)
      {
        if (!clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Runtime.Bool.bAllowToMove)
          return;
        if (clsAppMarbleVars.varInterface.AbsoluteMode)
        {
          double num = 0.0;
          if (clsAppMarbleVars.varInterface.PartZeroMode)
          {
            if (index == 0)
              num = clsAppMarbleVars.cMachine.G54List[0].X;
            if (index == 1)
              num = clsAppMarbleVars.cMachine.G54List[0].Y;
          }
          clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, clsAppMarbleVars.varInterface.JogMoveValue + num, true);
        }
        else
        {
          if (!clsAppMarbleVars.varInterface.IncrementalMode)
            return;
          double num = 0.0;
          if (index == 0 | index == 1)
            num = buMarbleCalc.activeToolSaw.Geometry.Thickness;
          if (!clsAppMarbleVars.varInterface.AddSawThicknessToMove)
            num = 0.0;
          clsAppMarbleVars.cMachine.Commands.moveIncremental(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar, 0.0, clsAppMarbleVars.varInterface.JogMoveValue + num, Dir, true);
        }
      }
      else
      {
        string Val = "";
        string str = $"{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar} {buLangTranslate.preDef.Move}";
        this.readSTRINGVar(CodesysVariableBaseType.Global, $"AppRun.{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar}JogNotAllowMessage", ref Val);
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
      }
    }
  }

  public void Jog_MouseLeave(object sender, EventArgs e)
  {
    int index = AppProcess.SelectedAxis;
    if (sender.GetType() == typeof (buButton))
    {
      if (((buControl) sender).Motion.AxisIndex >= 0)
        index = ((buControl) sender).Motion.AxisIndex;
      string note = ((buControl) sender).Motion.Note;
      double num = ((buControl) sender).Motion.Value;
    }
    if (AppBool.Offline && !clsAppMarbleVars.varInterface.IncrementalMode & !clsAppMarbleVars.varInterface.AbsoluteMode)
      AppBool.MouseDowned = false;
    AppBool.JogPlus = false;
    AppBool.JogMinus = false;
    if (!AppBool.Connected)
      return;
    clsAppMarbleVars.cMachine.Commands.jogStop(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar);
  }

  public void Jog_PageClose(object sender, EventArgs e)
  {
    for (int index = 0; index <= clsAppMarbleVars.cMachine.AppAxis.Count - 1; ++index)
      clsAppMarbleVars.cMachine.Commands.jogStop(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar);
  }

  public void Jog_Command(object sender, JogCommandEventArg e)
  {
    if (!AppBool.Connected)
      return;
    if (e.Command == JogCommandType.JogStop)
      clsAppMarbleVars.cMachine.Commands.jogStop(clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar);
    if (e.Command == JogCommandType.StopAll)
    {
      for (int index = 0; index <= clsAppMarbleVars.cMachine.AppAxis.Count - 1; ++index)
      {
        clsAppMarbleVars.cMachine.Commands.jogStop(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar);
        clsAppMarbleVars.cMachine.Commands.Stop(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar);
      }
    }
    if (e.Command == JogCommandType.Stop)
      clsAppMarbleVars.cMachine.Commands.Stop(clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar);
    if (clsAppMarbleVars.cMachine.runSystem.WagonUp)
    {
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentencesMarble.WagonUpPosition, (object) Color.Gold, (object) null, (object) null);
    }
    else
    {
      if (e.Command == JogCommandType.Absolute)
      {
        if (clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Runtime.Bool.bAllowToMove)
        {
          clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar, 0.0, e.Position, true);
        }
        else
        {
          string Val = "";
          string str = $"{clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Base.baseChar} {buLangTranslate.preDef.Move}";
          this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.CJogNotAllowMessage", ref Val);
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
        }
      }
      if (e.Command == JogCommandType.Incremental)
      {
        if (clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Runtime.Bool.bAllowToMove)
        {
          clsAppMarbleVars.cMachine.Commands.moveIncremental(clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar, 0.0, e.IncrementalPosition, e.Direction, true);
        }
        else
        {
          string Val = "";
          string str = $"{clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Base.baseChar} {buLangTranslate.preDef.Move}";
          this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.CJogNotAllowMessage", ref Val);
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
        }
      }
      if (e.Command == JogCommandType.VelocityMinus)
      {
        if (clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Runtime.Bool.bAllowToMove)
        {
          clsAppMarbleVars.cMachine.Commands.jogBackward(clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar, 0.0, true);
        }
        else
        {
          string Val = "";
          string str = $"{clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Base.baseChar} {buLangTranslate.preDef.Move}";
          this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.CJogNotAllowMessage", ref Val);
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
        }
      }
      if (e.Command == JogCommandType.VelocityPlus)
      {
        if (clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Runtime.Bool.bAllowToMove)
        {
          clsAppMarbleVars.cMachine.Commands.jogForward(clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar, 0.0, true);
        }
        else
        {
          string Val = "";
          string str = $"{clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Base.baseChar} {buLangTranslate.preDef.Move}";
          this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.CJogNotAllowMessage", ref Val);
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
        }
      }
      if (e.Command == JogCommandType.Home)
        clsAppMarbleVars.cMachine.Commands.GoAxisHoming(clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar, true);
      if (e.Command != JogCommandType.AutoTest)
        return;
      if (clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Runtime.Bool.bAllowToMove)
      {
        clsAppMarbleVars.cMachine.Commands.AutoTest(clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar, 0.0, e.Position1, e.Position2, true);
      }
      else
      {
        string Val = "";
        string str = $"{clsAppMarbleVars.cMachine.AppAxis[e.SelectedAxis].AxisPar.Base.baseChar} {buLangTranslate.preDef.Move}";
        this.readSTRINGVar(CodesysVariableBaseType.Global, "AppRun.CJogNotAllowMessage", ref Val);
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} : {Val}", (object) null, (object) null, (object) null);
      }
    }
  }

  public void JogSemiAuto_Click(object sender, EventArgs e)
  {
    int num1 = AppProcess.SelectedAxis;
    double num2 = 1.0;
    if (clsAppMarbleVars.cMachine.runSystem.WagonUp)
    {
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentencesMarble.WagonUpPosition, (object) Color.Gold, (object) null, (object) null);
    }
    else
    {
      if (sender.GetType() == typeof (buButton))
      {
        if (((buControl) sender).Motion.AxisIndex >= 0)
          num1 = ((buControl) sender).Motion.AxisIndex;
        string note = ((buControl) sender).Motion.Note;
        num2 = ((buControl) sender).Motion.Value;
      }
      if (!AppBool.Connected || !clsAppMarbleVars.cMachine.runSystem.SemiAuto || !(num1 == 0 | num1 == 1 | num1 == 2))
        return;
      if (num1 == 0)
      {
        if (num2 > 0.0)
          this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.XPlusVirtual");
        else
          this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.XMinusVirtual");
      }
      if (num1 == 1)
      {
        if (num2 > 0.0)
          this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.YPlusVirtual");
        else
          this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.YMinusVirtual");
      }
      if (num1 != 2)
        return;
      if (num2 > 0.0)
        this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.ZPlusVirtual");
      else
        this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.miscInfo.ZMinusVirtual");
    }
  }

  public void GoPosition(
    double XPos,
    double YPos,
    double ZPos,
    double CPos,
    double APos,
    int ZWaitMs,
    int CWaitMs,
    int AWaitMs)
  {
    if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bAllowToMove)
    {
      double Position = ZPos;
      clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, Position, true);
    }
    Thread.Sleep(ZWaitMs);
    if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove)
    {
      double Position = APos;
      clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar, 0.0, Position, true);
    }
    Thread.Sleep(AWaitMs);
    if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bAllowToMove)
    {
      double Position = CPos;
      clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar, 0.0, Position, true);
    }
    Thread.Sleep(CWaitMs);
    if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bAllowToMove)
    {
      double Position = YPos;
      clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar, 0.0, Position, true);
    }
    if (!clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bAllowToMove)
      return;
    double Position1 = XPos;
    clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar, 0.0, Position1, true);
  }

  public void CheckPartsInMaterial(ref MarbleJob Job)
  {
    if (!Job.Material.Enable)
      return;
    for (int index = 0; index <= Job.Items.Count - 1; ++index)
    {
      if (!clsInit.cVector5.isBoxSizeInsideBoxSize(Job.Material.BoxMinPoint, Job.Material.BoxMaxPoint, Job.Items[index].SizeItem.MinPoint, Job.Items[index].SizeItem.MaxPoint, Plane.XY) & !Job.Items[index].DontCheckPartLimits)
      {
        InfoType infoType = new InfoType("", $"{(index + 1).ToString()}. {buLangTranslate.preSentences.OperationOutofMaterial}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, InfoTypeCodes.ToolDiameterBig, "X", buMotionColors.clrWarning);
        clsInit.cMarble.AddInfoType(infoType, ref Job.TotalMessages);
      }
    }
  }

  public void CheckMachineLimits(ref MarbleJob Job, Pnt6D MinLimit, Pnt6D MaxLimit)
  {
    for (int index1 = 0; index1 <= Job.Cams.Count - 1; ++index1)
    {
      string str = "";
      if ((Job.Cams[index1].Obj1 == null ? 0 : (Job.Cams[index1].Obj1 is MarbleItem ? 1 : 0)) != 0)
      {
        MarbleItem marbleItem = Job.Cams[index1].Obj1 as MarbleItem;
        if (marbleItem.indexItem >= 0)
          str = $"{(marbleItem.indexItem + 1).ToString()}. {buLangTranslate.preDef.Operation} ";
      }
      bool flag = false;
      for (int index2 = 0; index2 <= Job.Cams[index1].CamPoints.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= Job.Cams[index1].CamPoints[index2].Points.Count - 1; ++index3)
        {
          TpPnt9D point = Job.Cams[index1].CamPoints[index2].Points[index3];
          double num1 = point.P9.X + clsAppMarbleVars.cMachine.G54List[0].X;
          double num2 = point.P9.Y + clsAppMarbleVars.cMachine.G54List[0].Y;
          double num3 = point.P9.Z + clsAppMarbleVars.cMachine.G54List[0].Z + buMarbleCalc.activeToolSaw.Geometry.Diameter / 2.0;
          if (Job.Cams[index1].Tool.Purpose == ToolPurpose.Milling)
          {
            num1 = point.P9.X + clsAppMarbleVars.cMachine.G54List[0].X + clsAppMarbleVars.varApp.MillingExtraG54OffsetX;
            num2 = point.P9.Y + clsAppMarbleVars.cMachine.G54List[0].Y + clsAppMarbleVars.varApp.MillingExtraG54OffsetY;
            num3 = point.P9.Z + clsAppMarbleVars.varApp.MillingExtraG54OffsetZ + buMarbleCalc.activeToolMilling.Geometry.Length;
          }
          else if (Job.Cams[index1].Tool.Purpose == ToolPurpose.MillingHead)
          {
            num1 = point.P9.X + clsAppMarbleVars.cMachine.G54List[0].X + clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetX;
            num2 = point.P9.Y + clsAppMarbleVars.cMachine.G54List[0].Y + clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetY;
            num3 = point.P9.Z + clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetZ + buMarbleCalc.activeToolMillingHead.Geometry.Length;
          }
          if (num1 < MinLimit.X)
          {
            InfoType infoType = new InfoType("", $"{str}{buLangTranslate.preSentences.OperationOutofMachineLimit} - {buLangTranslate.preChar.X} {buLangTranslate.preDef.Negative} = {num1.ToString("f2")} < {MinLimit.X.ToString("f2")}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, InfoTypeCodes.NegativeLimit, "X", buMotionColors.clrAlarm);
            clsInit.cMarble.AddInfoType(infoType, ref Job.TotalMessages);
          }
          if (num1 > MaxLimit.X)
          {
            InfoType infoType = new InfoType("", $"{str}{buLangTranslate.preSentences.OperationOutofMachineLimit} - {buLangTranslate.preChar.X} {buLangTranslate.preDef.Positive} = {num1.ToString("f2")} > {MaxLimit.X.ToString("f2")}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, InfoTypeCodes.PositiveLimit, "X", buMotionColors.clrAlarm);
            clsInit.cMarble.AddInfoType(infoType, ref Job.TotalMessages);
          }
          if (num2 < MinLimit.Y)
          {
            InfoType infoType = new InfoType("", $"{str}{buLangTranslate.preSentences.OperationOutofMachineLimit} - {buLangTranslate.preChar.Y} {buLangTranslate.preDef.Negative} = {num2.ToString("f2")} < {MinLimit.Y.ToString("f2")}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, InfoTypeCodes.NegativeLimit, "Y", buMotionColors.clrAlarm);
            clsInit.cMarble.AddInfoType(infoType, ref Job.TotalMessages);
          }
          if (num2 > MaxLimit.Y)
          {
            InfoType infoType = new InfoType("", $"{str}{buLangTranslate.preSentences.OperationOutofMachineLimit} - {buLangTranslate.preChar.Y} {buLangTranslate.preDef.Positive} = {num2.ToString("f2")} > {MaxLimit.Y.ToString("f2")}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, InfoTypeCodes.PositiveLimit, "Y", buMotionColors.clrAlarm);
            clsInit.cMarble.AddInfoType(infoType, ref Job.TotalMessages);
          }
          if (num3 > MaxLimit.Z)
          {
            InfoType infoType = new InfoType("", $"{str}{buLangTranslate.preSentences.OperationOutofMachineLimit} - {buLangTranslate.preChar.Z} {buLangTranslate.preDef.Positive} = {num3.ToString("f2")} > {MaxLimit.Z.ToString("f2")}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, InfoTypeCodes.PositiveLimit, "Z", buMotionColors.clrAlarm);
            clsInit.cMarble.AddInfoType(infoType, ref Job.TotalMessages);
          }
          if (Job.Cams[index1].CamPoints[index2].Points[index3].P9.A >= 89.5)
            flag = true;
        }
      }
      if (flag & Job.Cams[index1].Tool.Purpose == ToolPurpose.Saw | Job.Cams[index1].Tool.Purpose == ToolPurpose.MillingHead && Job.Cams[index1].Tool.CamData.SpindleSpeed > clsAppMarbleVars.varApp.SawMaxSpeedAtA90)
        Job.Cams[index1].Tool.CamData.SpindleSpeed = clsAppMarbleVars.varApp.SawMaxSpeedAtA90;
    }
  }

  public void CheckJobErrorsWarnings(ref MarbleJob Job)
  {
    // ISSUE: unable to decompile the method.
  }

  public void JobResetAll()
  {
    if (clsInit.appMarble.activeJob == null)
      clsInit.appMarble.activeJob = new MarbleJob();
    clsInit.appMarble.activeJob.Items.Clear();
    if (clsAppMarbleItems.frmJobOPListV1 == null)
      return;
    for (int index = 0; index <= clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls.Count - 1; ++index)
    {
      if (clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls[index] is buMarbleOPItem)
        this.JobItemReset(index);
    }
  }

  public void JobItemReset(int Index)
  {
    if (clsAppMarbleItems.frmJobOPListV1 == null || !(Index >= 0 & Index <= clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls.Count - 1))
      return;
    buMarbleOPItem control = clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls[Index] as buMarbleOPItem;
    control.OperationName = "";
    control.OperationID = -1;
    control.OperationEnable = false;
    control.OperationSelected = false;
    control.UpdateControl();
  }

  public void JopItemUpdateAll()
  {
    if (clsAppMarbleItems.frmJobOPListV1 == null)
      return;
    for (int index1 = 0; index1 <= clsInit.appMarble.activeJob.Items.Count - 1; ++index1)
    {
      int index2 = index1;
      for (int index3 = 0; index3 <= clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls.Count - 1; ++index3)
      {
        if (clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls[index3] is buMarbleOPItem)
        {
          buMarbleOPItem control = clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls[index3] as buMarbleOPItem;
          if (control.IndexControl == index2)
          {
            control.OperationName = clsInit.appMarble.JobItemToString(clsInit.appMarble.activeJob.Items[index2]);
            control.OperationID = clsInit.appMarble.activeJob.Items[index2].ID;
            control.OperationEnable = clsInit.appMarble.activeJob.Items[index2].Enable;
            control.OperationSelected = clsInit.appMarble.activeJob.Items[index2].Selected;
            control.UpdateControl();
          }
        }
      }
    }
    for (int count = clsInit.appMarble.activeJob.Items.Count; count <= clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls.Count - 1; ++count)
    {
      for (int index = 0; index <= clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls.Count - 1; ++index)
      {
        if (clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls[index] is buMarbleOPItem && (clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls[index] as buMarbleOPItem).IndexControl == count)
          this.JobItemReset(index);
      }
    }
  }

  public void SetJobOperationItemByJobIndex(int Index)
  {
    if (clsAppMarbleItems.frmJobOPListV1 == null)
      return;
    for (int index = 0; index <= clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls.Count - 1; ++index)
    {
      if (clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls[index] is buMarbleOPItem)
      {
        buMarbleOPItem control = clsAppMarbleItems.frmJobOPListV1.pnl_base.Controls[index] as buMarbleOPItem;
        if (control.IndexControl == Index)
        {
          control.OperationName = clsInit.appMarble.JobItemToString(clsInit.appMarble.activeJob.Items[Index]);
          control.OperationID = clsInit.appMarble.activeJob.Items[Index].ID;
          control.OperationEnable = clsInit.appMarble.activeJob.Items[Index].Enable;
          control.UpdateControl();
        }
      }
    }
  }

  public void OpValueChanged(object sender, double Value)
  {
    if (!((sender as System.Windows.Forms.Control).Name == clsAppMarbleItems.frmJobOPListV2.spn_step.Name))
      return;
    clsMarble.SimStep = Convert.ToInt32(clsAppMarbleItems.frmJobOPListV2.spn_step.Value);
  }

  public void OpItemClick(object sender, EventArgs e)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OpItemCommand(object sender, ItemCommandEventArgs e)
  {
    if (e.Command == MarbleOperationMenuCommands.IndexChanged && e.OperationIndex >= 0 & e.OperationIndex <= clsInit.appMarble.activeJob.Items.Count - 1)
    {
      buMarbleCalc.SelectedItem.ActiveItem.indexItem = e.OperationIndex;
      if (e.Selected)
        clsInit.appMarble.doSelectItemByID(e.OperationID);
      else
        clsInit.appMarble.doUnSelectItemByID(e.OperationID);
    }
    if (e.Command == MarbleOperationMenuCommands.Up)
    {
      buMarbleCalc.SelectedItem.ActiveItem.indexItem = e.OperationIndex;
      clsInit.appMarble.doMoveUpItem(ref buMarbleCalc.SelectedItem.ActiveItem.indexItem);
      this.JopItemUpdateAll();
      clsInit.appMarble.doDrawActiveJob();
    }
    if (e.Command == MarbleOperationMenuCommands.Down)
    {
      buMarbleCalc.SelectedItem.ActiveItem.indexItem = e.OperationIndex;
      clsInit.appMarble.doMoveDownItem(ref buMarbleCalc.SelectedItem.ActiveItem.indexItem);
      this.JopItemUpdateAll();
      clsInit.appMarble.doDrawActiveJob();
    }
    if (e.Command == MarbleOperationMenuCommands.Delete)
    {
      buMarbleCalc.SelectedItem.ActiveItem.indexItem = e.OperationIndex;
      clsInit.appMarble.doDeleteItems(false, -1);
    }
    if (e.Command != MarbleOperationMenuCommands.Edit)
      return;
    AppBool.EditMode = true;
  }

  public void UpdateToolListFromActiveTools()
  {
    if (!buMarbleCalc.varMarbleSettings.AutoUpdateToolListFromActiveTools)
      return;
    if (clsAppMarbleVars.varInterface.IndexToolSaw >= 0 & clsAppMarbleVars.varInterface.IndexToolSaw <= buMarbleCalc.ToolSaws.Count - 1 && buMarbleCalc.activeToolSaw.Data.Name == buMarbleCalc.ToolSaws[clsAppMarbleVars.varInterface.IndexToolSaw].Data.Name)
      buMarbleCalc.ToolSaws[clsAppMarbleVars.varInterface.IndexToolSaw] = new ToolBase5(buMarbleCalc.activeToolSaw);
    if (clsAppMarbleVars.varInterface.IndexToolMilling >= 0 & clsAppMarbleVars.varInterface.IndexToolMilling <= buMarbleCalc.ToolMillings.Count - 1 && buMarbleCalc.activeToolMilling.Data.Name == buMarbleCalc.ToolMillings[clsAppMarbleVars.varInterface.IndexToolMilling].Data.Name)
      buMarbleCalc.ToolMillings[clsAppMarbleVars.varInterface.IndexToolMilling] = new ToolBase5(buMarbleCalc.activeToolMilling);
    if (!(clsAppMarbleVars.varInterface.IndexToolMillingHead >= 0 & clsAppMarbleVars.varInterface.IndexToolMillingHead <= buMarbleCalc.ToolMillingHeads.Count - 1) || !(buMarbleCalc.activeToolMillingHead.Data.Name == buMarbleCalc.ToolMillingHeads[clsAppMarbleVars.varInterface.IndexToolMillingHead].Data.Name))
      return;
    buMarbleCalc.ToolMillingHeads[clsAppMarbleVars.varInterface.IndexToolMillingHead] = new ToolBase5(buMarbleCalc.activeToolMillingHead);
  }

  public void ToolCreate()
  {
    if (buMarbleCalc.ToolMillings.Count < clsAppMarbleVars.varApp.ToolMillingCount)
    {
      for (int count = buMarbleCalc.ToolMillings.Count; count <= clsAppMarbleVars.varApp.ToolMillingCount; ++count)
        buMarbleCalc.ToolMillings.Add(new ToolBase5()
        {
          Purpose = ToolPurpose.Milling,
          Geometry = {
            GeometryType = ToolType.Flat
          }
        });
    }
    if (buMarbleCalc.ToolMillingHeads.Count < clsAppMarbleVars.varApp.ToolMillingHeadCount)
    {
      for (int count = buMarbleCalc.ToolMillingHeads.Count; count <= clsAppMarbleVars.varApp.ToolMillingHeadCount; ++count)
        buMarbleCalc.ToolMillingHeads.Add(new ToolBase5()
        {
          Purpose = ToolPurpose.Milling,
          Geometry = {
            GeometryType = ToolType.Flat
          }
        });
    }
    if (buMarbleCalc.ToolSaws.Count < clsAppMarbleVars.varApp.ToolSawCount)
    {
      for (int count = buMarbleCalc.ToolSaws.Count; count <= clsAppMarbleVars.varApp.ToolSawCount; ++count)
        buMarbleCalc.ToolSaws.Add(new ToolBase5()
        {
          Purpose = ToolPurpose.Saw,
          Geometry = {
            GeometryType = ToolType.Saw
          }
        });
    }
    if (buMarbleCalc.ToolInMagazine.Count >= 10)
      return;
    for (int count = buMarbleCalc.ToolInMagazine.Count; count <= 10; ++count)
      buMarbleCalc.ToolInMagazine.Add(new ToolBase5()
      {
        Purpose = ToolPurpose.Milling,
        Geometry = {
          GeometryType = ToolType.Flat
        }
      });
  }

  public void ToolUpdateOnScreen()
  {
    if (clsAppMarbleControls.lblMillingDia != null)
      clsAppMarbleControls.lblMillingDia.Text = "D: " + buMarbleCalc.activeToolMilling.Geometry.Diameter.ToString("f2");
    if (clsAppMarbleControls.lblMillingLen != null)
      clsAppMarbleControls.lblMillingLen.Text = "L: " + buMarbleCalc.activeToolMilling.Geometry.Length.ToString("f2");
    if (clsAppMarbleControls.lblMillingHeadDia != null)
      clsAppMarbleControls.lblMillingHeadDia.Text = "D: " + buMarbleCalc.activeToolMillingHead.Geometry.Diameter.ToString("f2");
    if (clsAppMarbleControls.lblMillingHeadLen != null)
      clsAppMarbleControls.lblMillingHeadLen.Text = "L: " + buMarbleCalc.activeToolMillingHead.Geometry.Length.ToString("f2");
    if (clsAppMarbleControls.lblSawDia != null)
      clsAppMarbleControls.lblSawDia.Text = "D: " + buMarbleCalc.activeToolSaw.Geometry.Diameter.ToString("f2");
    if (clsAppMarbleControls.lblSawThickness == null)
      return;
    clsAppMarbleControls.lblSawThickness.Text = "T: " + buMarbleCalc.activeToolSaw.Geometry.Thickness.ToString("f2");
  }

  public void DrawTool(ToolBase5 ToolDraw)
  {
    buEyeItems.viewportDialogs.Entities.Clear();
    List<Mesh> refMeshes = new List<Mesh>();
    clsInit.appMW.CreateTool(ToolDraw, true, true, false, false, ref refMeshes);
    if (refMeshes.Count <= 0)
      return;
    for (int index = 0; index <= refMeshes.Count - 1; ++index)
    {
      if (refMeshes[index].Vertices.Length != 0)
        buEyeItems.viewportDialogs.Entities.Add((Entity) refMeshes[index]);
    }
    List<Entity> dimEntities = new List<Entity>();
    ToolDraw.Geometry.DrawArbor = false;
    ToolDraw.Geometry.DrawHolder = false;
    clsInit.cVector5.ToolDimensionEntities(ToolDraw, ref dimEntities);
    for (int index = 0; index <= dimEntities.Count - 1; ++index)
      buEyeItems.viewportDialogs.Entities.Add(dimEntities[index]);
    buEyeItems.viewportDialogs.ActiveViewport.ViewCubeIcon.Visible = false;
    buEyeItems.viewportDialogs.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    if (ToolDraw.Purpose == ToolPurpose.Saw)
    {
      if (buEyeItems.viewportDialogs.IsHandleCreated)
        buEyeItems.viewportDialogs.SetView(viewType.Top, true, false);
    }
    else if (buEyeItems.viewportDialogs.IsHandleCreated)
      buEyeItems.viewportDialogs.SetView(viewType.Front, true, false);
    buEyeItems.viewportDialogs.ZoomOut(2);
    buEyeItems.viewportDialogs.Invalidate();
  }

  public string ToolInfo(ToolBase5 Tool)
  {
    try
    {
      return $"{$"{buLangTranslate.preDef.Name} : {Tool.Data.Name}{Environment.NewLine}" + Tool.Purpose.ToString() + Environment.NewLine}{buLangTranslate.preDef.Diameter} : {Tool.Geometry.Diameter.ToString()}{Environment.NewLine}";
    }
    catch (Exception ex)
    {
      return "";
    }
  }

  public void spn_item_HorValueChanged(object sender, double Val)
  {
    if (!AppBool.Inited || MarbleTempVars.DontChangeValuesAtOperations)
      return;
    buSpin buSpin = sender as buSpin;
    if (buSpin.Aux.Explanation == "Len")
      MarbleTempVars.cutItemsHor[MarbleTempVars.HorizontalItemIndex + buSpin.Aux.ValInt].Length = buSpin.Value;
    if (buSpin.Aux.Explanation == "Cnt")
      MarbleTempVars.cutItemsHor[MarbleTempVars.HorizontalItemIndex + buSpin.Aux.ValInt].Count = (int) buSpin.Value;
    if (buSpin.Aux.Explanation == "SA")
    {
      MarbleTempVars.cutItemsHor[MarbleTempVars.HorizontalItemIndex + buSpin.Aux.ValInt].StartAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_SAimg1.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_SAimg1.ImageIndex = 1;
        else
          buMarbleForms.frmHorizontal.lbl_SAimg1.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_SAimg2.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_SAimg2.ImageIndex = 1;
        else
          buMarbleForms.frmHorizontal.lbl_SAimg2.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_SAimg3.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_SAimg3.ImageIndex = 1;
        else
          buMarbleForms.frmHorizontal.lbl_SAimg3.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_SAimg4.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_SAimg4.ImageIndex = 1;
        else
          buMarbleForms.frmHorizontal.lbl_SAimg4.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_SAimg5.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_SAimg5.ImageIndex = 1;
        else
          buMarbleForms.frmHorizontal.lbl_SAimg5.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_SAimg6.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_SAimg6.ImageIndex = 1;
        else
          buMarbleForms.frmHorizontal.lbl_SAimg6.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_SAimg7.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_SAimg7.ImageIndex = 1;
        else
          buMarbleForms.frmHorizontal.lbl_SAimg7.ImageIndex = 2;
      }
    }
    if (buSpin.Aux.Explanation == "EA")
    {
      MarbleTempVars.cutItemsHor[MarbleTempVars.HorizontalItemIndex + buSpin.Aux.ValInt].EndAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_EAimg1.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_EAimg1.ImageIndex = 4;
        else
          buMarbleForms.frmHorizontal.lbl_EAimg1.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_EAimg2.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_EAimg2.ImageIndex = 4;
        else
          buMarbleForms.frmHorizontal.lbl_EAimg2.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_EAimg3.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_EAimg3.ImageIndex = 4;
        else
          buMarbleForms.frmHorizontal.lbl_EAimg3.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_EAimg4.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_EAimg4.ImageIndex = 4;
        else
          buMarbleForms.frmHorizontal.lbl_EAimg4.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_EAimg5.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_EAimg5.ImageIndex = 4;
        else
          buMarbleForms.frmHorizontal.lbl_EAimg5.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_EAimg6.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_EAimg6.ImageIndex = 4;
        else
          buMarbleForms.frmHorizontal.lbl_EAimg6.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorizontal.lbl_EAimg7.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorizontal.lbl_EAimg7.ImageIndex = 4;
        else
          buMarbleForms.frmHorizontal.lbl_EAimg7.ImageIndex = 5;
      }
    }
    buMarbleForms.frmHorizontal.txt_info.Text = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHor, buMarbleForms.frmHorizontal.spn_itemlength.Value);
  }

  public void spn_item_VerValueChanged(object sender, double Val)
  {
    if (!AppBool.Inited || MarbleTempVars.DontChangeValuesAtOperations)
      return;
    buSpin buSpin = sender as buSpin;
    if (buSpin.Aux.Explanation == "Len")
      MarbleTempVars.cutItemsVer[MarbleTempVars.VerticalItemIndex + buSpin.Aux.ValInt].Length = buSpin.Value;
    if (buSpin.Aux.Explanation == "Cnt")
      MarbleTempVars.cutItemsVer[MarbleTempVars.VerticalItemIndex + buSpin.Aux.ValInt].Count = (int) buSpin.Value;
    if (buSpin.Aux.Explanation == "SA")
    {
      MarbleTempVars.cutItemsVer[MarbleTempVars.VerticalItemIndex + buSpin.Aux.ValInt].StartAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_SAimg1.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_SAimg1.ImageIndex = 1;
        else
          buMarbleForms.frmVertical.lbl_SAimg1.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_SAimg2.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_SAimg2.ImageIndex = 1;
        else
          buMarbleForms.frmVertical.lbl_SAimg2.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_SAimg3.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_SAimg3.ImageIndex = 1;
        else
          buMarbleForms.frmVertical.lbl_SAimg3.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_SAimg4.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_SAimg4.ImageIndex = 1;
        else
          buMarbleForms.frmVertical.lbl_SAimg4.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_SAimg5.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_SAimg5.ImageIndex = 1;
        else
          buMarbleForms.frmVertical.lbl_SAimg5.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_SAimg6.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_SAimg6.ImageIndex = 1;
        else
          buMarbleForms.frmVertical.lbl_SAimg6.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_SAimg7.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_SAimg7.ImageIndex = 1;
        else
          buMarbleForms.frmVertical.lbl_SAimg7.ImageIndex = 2;
      }
    }
    if (buSpin.Aux.Explanation == "EA")
    {
      MarbleTempVars.cutItemsVer[MarbleTempVars.VerticalItemIndex + buSpin.Aux.ValInt].EndAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_EAimg1.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_EAimg1.ImageIndex = 4;
        else
          buMarbleForms.frmVertical.lbl_EAimg1.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_EAimg2.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_EAimg2.ImageIndex = 4;
        else
          buMarbleForms.frmVertical.lbl_EAimg2.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_EAimg3.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_EAimg3.ImageIndex = 4;
        else
          buMarbleForms.frmVertical.lbl_EAimg3.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_EAimg4.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_EAimg4.ImageIndex = 4;
        else
          buMarbleForms.frmVertical.lbl_EAimg4.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_EAimg5.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_EAimg5.ImageIndex = 4;
        else
          buMarbleForms.frmVertical.lbl_EAimg5.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_EAimg6.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_EAimg6.ImageIndex = 4;
        else
          buMarbleForms.frmVertical.lbl_EAimg6.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmVertical.lbl_EAimg7.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmVertical.lbl_EAimg7.ImageIndex = 4;
        else
          buMarbleForms.frmVertical.lbl_EAimg7.ImageIndex = 5;
      }
    }
    buMarbleForms.frmVertical.txt_info.Text = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsVer, buMarbleForms.frmVertical.spn_itemlength.Value);
  }

  public void spn_item_HorVerHorValueChanged(object sender, double Val)
  {
    if (!AppBool.Inited || MarbleTempVars.DontChangeValuesAtOperations)
      return;
    buSpin buSpin = sender as buSpin;
    if (buSpin.Aux.Explanation == "Len")
      MarbleTempVars.cutItemsHorVerHor[MarbleTempVars.HorVerHorizontalItemIndex + buSpin.Aux.ValInt].Length = buSpin.Value;
    if (buSpin.Aux.Explanation == "Cnt")
      MarbleTempVars.cutItemsHorVerHor[MarbleTempVars.HorVerHorizontalItemIndex + buSpin.Aux.ValInt].Count = (int) buSpin.Value;
    if (buSpin.Aux.Explanation == "SA")
    {
      MarbleTempVars.cutItemsHorVerHor[MarbleTempVars.HorVerHorizontalItemIndex + buSpin.Aux.ValInt].StartAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgHor1.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgHor1.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgHor1.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgHor2.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgHor2.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgHor2.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgHor3.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgHor3.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgHor3.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgHor4.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgHor4.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgHor4.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgHor5.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgHor5.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgHor5.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgHor6.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgHor6.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgHor6.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgHor7.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgHor7.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgHor7.ImageIndex = 2;
      }
    }
    if (buSpin.Aux.Explanation == "EA")
    {
      MarbleTempVars.cutItemsHorVerHor[MarbleTempVars.HorVerHorizontalItemIndex + buSpin.Aux.ValInt].EndAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgHor1.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgHor1.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgHor1.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgHor2.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgHor2.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgHor2.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgHor3.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgHor3.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgHor3.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgHor4.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgHor4.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgHor4.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgHor5.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgHor5.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgHor5.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgHor6.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgHor6.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgHor6.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgHor7.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgHor7.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgHor7.ImageIndex = 5;
      }
    }
    string itemInfo1 = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHorVerHor, buMarbleForms.frmHorVer.spn_itemhorlength.Value);
    string itemInfo2 = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHorVerVer, buMarbleForms.frmHorVer.spn_itemverlength.Value);
    if (itemInfo1.Length > 0)
      buMarbleForms.frmHorVer.txt_info.Text = buMarbleForms.frmHorVer.txt_info.Text + itemInfo1 + Environment.NewLine;
    buMarbleForms.frmHorVer.txt_info.Text += itemInfo2;
  }

  public void spn_item_HorVerVerValueChanged(object sender, double Val)
  {
    if (!AppBool.Inited || MarbleTempVars.DontChangeValuesAtOperations)
      return;
    buSpin buSpin = sender as buSpin;
    if (buSpin.Aux.Explanation == "Len")
      MarbleTempVars.cutItemsHorVerVer[MarbleTempVars.HorVerVerticalItemIndex + buSpin.Aux.ValInt].Length = buSpin.Value;
    if (buSpin.Aux.Explanation == "Cnt")
      MarbleTempVars.cutItemsHorVerVer[MarbleTempVars.HorVerVerticalItemIndex + buSpin.Aux.ValInt].Count = (int) buSpin.Value;
    if (buSpin.Aux.Explanation == "SA")
    {
      MarbleTempVars.cutItemsHorVerVer[MarbleTempVars.HorVerVerticalItemIndex + buSpin.Aux.ValInt].StartAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgVer1.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgVer1.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgVer1.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgVer2.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgVer2.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgVer2.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgVer3.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgVer3.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgVer3.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgVer4.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgVer4.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgVer4.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgVer5.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgVer5.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgVer5.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgVer6.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgVer6.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgVer6.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_SAimgVer7.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_SAimgVer7.ImageIndex = 1;
        else
          buMarbleForms.frmHorVer.lbl_SAimgVer7.ImageIndex = 2;
      }
    }
    if (buSpin.Aux.Explanation == "EA")
    {
      MarbleTempVars.cutItemsHorVerVer[MarbleTempVars.HorVerVerticalItemIndex + buSpin.Aux.ValInt].EndAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgVer1.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgVer1.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgVer1.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgVer2.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgVer2.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgVer2.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgVer3.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgVer3.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgVer3.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgVer4.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgVer4.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgVer4.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgVer5.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgVer5.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgVer5.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgVer6.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgVer6.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgVer6.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVer.lbl_EAimgVer7.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVer.lbl_EAimgVer7.ImageIndex = 4;
        else
          buMarbleForms.frmHorVer.lbl_EAimgVer7.ImageIndex = 5;
      }
    }
    string itemInfo1 = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHorVerVer, buMarbleForms.frmHorVer.spn_itemhorlength.Value);
    string itemInfo2 = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHorVerVer, buMarbleForms.frmHorVer.spn_itemverlength.Value);
    if (itemInfo1.Length > 0)
      buMarbleForms.frmHorVer.txt_info.Text = buMarbleForms.frmHorVer.txt_info.Text + itemInfo1 + Environment.NewLine;
    buMarbleForms.frmHorVer.txt_info.Text += itemInfo2;
  }

  public void spn_item_HorOrVerDialogValueChanged(object sender, double Val)
  {
    if (!AppBool.Inited || MarbleTempVars.DontChangeValuesAtOperations)
      return;
    buSpin buSpin = sender as buSpin;
    if (MarbleTempVars.isHorizontal)
    {
      if (buSpin.Aux.Explanation == "Len")
        MarbleTempVars.cutItemsHor[MarbleTempVars.HorizontalItemIndex + buSpin.Aux.ValInt].Length = buSpin.Value;
      if (buSpin.Aux.Explanation == "Cnt")
        MarbleTempVars.cutItemsHor[MarbleTempVars.HorizontalItemIndex + buSpin.Aux.ValInt].Count = (int) buSpin.Value;
      if (buSpin.Aux.Explanation == "SA")
      {
        MarbleTempVars.cutItemsHor[MarbleTempVars.HorizontalItemIndex + buSpin.Aux.ValInt].StartAngle = buSpin.Value;
        if (buSpin.Aux.ValInt == 0)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg1.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg1.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg1.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 1)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg2.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg2.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg2.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 2)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg3.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg3.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg3.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 3)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg4.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg4.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg4.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 4)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg5.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg5.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg5.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 5)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg6.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg6.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg6.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 6)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg7.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg7.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg7.ImageIndex = 2;
        }
      }
      if (buSpin.Aux.Explanation == "EA")
      {
        MarbleTempVars.cutItemsHor[MarbleTempVars.HorizontalItemIndex + buSpin.Aux.ValInt].EndAngle = buSpin.Value;
        if (buSpin.Aux.ValInt == 0)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg1.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg1.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg1.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 1)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg2.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg2.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg2.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 2)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg3.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg3.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg3.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 3)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg4.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg4.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg4.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 4)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg5.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg5.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg5.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 5)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg6.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg6.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg6.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 6)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg7.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg7.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg7.ImageIndex = 5;
        }
      }
      buMarbleForms.frmHorOrVerDialog.txt_info.Text = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHor, buMarbleForms.frmHorOrVerDialog.spn_itemlength.Value);
    }
    else
    {
      if (buSpin.Aux.Explanation == "Len")
        MarbleTempVars.cutItemsVer[MarbleTempVars.VerticalItemIndex + buSpin.Aux.ValInt].Length = buSpin.Value;
      if (buSpin.Aux.Explanation == "Cnt")
        MarbleTempVars.cutItemsVer[MarbleTempVars.VerticalItemIndex + buSpin.Aux.ValInt].Count = (int) buSpin.Value;
      if (buSpin.Aux.Explanation == "SA")
      {
        MarbleTempVars.cutItemsVer[MarbleTempVars.VerticalItemIndex + buSpin.Aux.ValInt].StartAngle = buSpin.Value;
        if (buSpin.Aux.ValInt == 0)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg1.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg1.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg1.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 1)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg2.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg2.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg2.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 2)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg3.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg3.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg3.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 3)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg4.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg4.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg4.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 4)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg5.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg5.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg5.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 5)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg6.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg6.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg6.ImageIndex = 2;
        }
        else if (buSpin.Aux.ValInt == 6)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg7.ImageIndex = 0;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg7.ImageIndex = 1;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_SAimg7.ImageIndex = 2;
        }
      }
      if (buSpin.Aux.Explanation == "EA")
      {
        MarbleTempVars.cutItemsVer[MarbleTempVars.VerticalItemIndex + buSpin.Aux.ValInt].EndAngle = buSpin.Value;
        if (buSpin.Aux.ValInt == 0)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg1.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg1.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg1.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 1)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg2.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg2.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg2.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 2)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg3.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg3.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg3.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 3)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg4.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg4.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg4.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 4)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg5.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg5.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg5.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 5)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg6.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg6.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg6.ImageIndex = 5;
        }
        else if (buSpin.Aux.ValInt == 6)
        {
          if (buCompare5.EQ(buSpin.Value, 0.0))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg7.ImageIndex = 3;
          else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg7.ImageIndex = 4;
          else
            buMarbleForms.frmHorOrVerDialog.lbl_EAimg7.ImageIndex = 5;
        }
      }
      buMarbleForms.frmHorOrVerDialog.txt_info.Text = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsVer, buMarbleForms.frmHorOrVerDialog.spn_itemlength.Value);
    }
    clsInit.appMarble.doAddItemVerHorMainForm(new Point3D(), buMarbleForms.frmHorOrVerDialog.spn_angle.Value, buMarbleForms.frmHorOrVerDialog.spn_itemlength.Value);
  }

  public void spn_item_HorVerHorDialogValueChanged(object sender, double Val)
  {
    if (!AppBool.Inited || MarbleTempVars.DontChangeValuesAtOperations)
      return;
    buSpin buSpin = sender as buSpin;
    if (buSpin.Aux.Explanation == "Len")
      MarbleTempVars.cutItemsHorVerHor[MarbleTempVars.HorVerHorizontalItemIndex + buSpin.Aux.ValInt].Length = buSpin.Value;
    if (buSpin.Aux.Explanation == "Cnt")
      MarbleTempVars.cutItemsHorVerHor[MarbleTempVars.HorVerHorizontalItemIndex + buSpin.Aux.ValInt].Count = (int) buSpin.Value;
    if (buSpin.Aux.Explanation == "SA")
    {
      MarbleTempVars.cutItemsHorVerHor[MarbleTempVars.HorVerHorizontalItemIndex + buSpin.Aux.ValInt].StartAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor1.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor1.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor1.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor2.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor2.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor2.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor3.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor3.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor3.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor4.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor4.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor4.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor5.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor5.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor5.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor6.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor6.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor6.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor7.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor7.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgHor7.ImageIndex = 2;
      }
    }
    if (buSpin.Aux.Explanation == "EA")
    {
      MarbleTempVars.cutItemsHorVerHor[MarbleTempVars.HorVerHorizontalItemIndex + buSpin.Aux.ValInt].EndAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor1.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor1.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor1.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor2.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor2.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor2.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor3.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor3.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor3.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor4.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor4.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor4.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor5.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor5.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor5.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor6.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor6.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor6.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor7.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor7.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgHor7.ImageIndex = 5;
      }
    }
    if (buSpin.Aux.Explanation == "Length")
      buMarbleCalc.varMarbleRunSettings.CutLengthHorVerHorizontal = buSpin.Value;
    string itemInfo1 = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHorVerHor, buMarbleForms.frmHorVerDialog.spn_itemhorlength.Value);
    string itemInfo2 = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHorVerVer, buMarbleForms.frmHorVerDialog.spn_itemverlength.Value);
    if (itemInfo1.Length > 0)
      buMarbleForms.frmHorVerDialog.txt_info.Text = buMarbleForms.frmHorVerDialog.txt_info.Text + itemInfo1 + Environment.NewLine;
    buMarbleForms.frmHorVerDialog.txt_info.Text += itemInfo2;
    clsInit.appMarble.doAddItemVerHorBothMainForm(new Point3D(), new Point3D(), buMarbleForms.frmHorVerDialog.spn_horverangle.Value, buMarbleForms.frmHorVerDialog.spn_itemhorlength.Value, buMarbleForms.frmHorVerDialog.spn_itemverlength.Value);
  }

  public void spn_item_HorVerVerDialogValueChanged(object sender, double Val)
  {
    if (!AppBool.Inited || MarbleTempVars.DontChangeValuesAtOperations)
      return;
    buSpin buSpin = sender as buSpin;
    if (buSpin.Aux.Explanation == "Len")
      MarbleTempVars.cutItemsHorVerVer[MarbleTempVars.HorVerVerticalItemIndex + buSpin.Aux.ValInt].Length = buSpin.Value;
    if (buSpin.Aux.Explanation == "Cnt")
      MarbleTempVars.cutItemsHorVerVer[MarbleTempVars.HorVerVerticalItemIndex + buSpin.Aux.ValInt].Count = (int) buSpin.Value;
    if (buSpin.Aux.Explanation == "SA")
    {
      MarbleTempVars.cutItemsHorVerVer[MarbleTempVars.HorVerVerticalItemIndex + buSpin.Aux.ValInt].StartAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer1.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer1.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer1.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer2.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer2.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer2.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer3.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer3.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer3.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer4.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer4.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer4.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer5.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer5.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer5.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer6.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer6.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer6.ImageIndex = 2;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer7.ImageIndex = 0;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer7.ImageIndex = 1;
        else
          buMarbleForms.frmHorVerDialog.lbl_SAimgVer7.ImageIndex = 2;
      }
    }
    if (buSpin.Aux.Explanation == "EA")
    {
      MarbleTempVars.cutItemsHorVerVer[MarbleTempVars.HorVerVerticalItemIndex + buSpin.Aux.ValInt].EndAngle = buSpin.Value;
      if (buSpin.Aux.ValInt == 0)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer1.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer1.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer1.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 1)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer2.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer2.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer2.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 2)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer3.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer3.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer3.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 3)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer4.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer4.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer4.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 4)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer5.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer5.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer5.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 5)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer6.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer6.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer6.ImageIndex = 5;
      }
      else if (buSpin.Aux.ValInt == 6)
      {
        if (buCompare5.EQ(buSpin.Value, 0.0))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer7.ImageIndex = 3;
        else if (buCompare5.GT(buSpin.Value, 0.0, 0.001))
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer7.ImageIndex = 4;
        else
          buMarbleForms.frmHorVerDialog.lbl_EAimgVer7.ImageIndex = 5;
      }
    }
    if (buSpin.Aux.Explanation == "Length")
      buMarbleCalc.varMarbleRunSettings.CutLengthHorVerVertical = buSpin.Value;
    string itemInfo1 = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHorVerVer, buMarbleForms.frmHorVerDialog.spn_itemhorlength.Value);
    string itemInfo2 = clsInit.cMarble.GetItemInfo(MarbleTempVars.cutItemsHorVerVer, buMarbleForms.frmHorVerDialog.spn_itemverlength.Value);
    if (itemInfo1.Length > 0)
      buMarbleForms.frmHorVerDialog.txt_info.Text = buMarbleForms.frmHorVerDialog.txt_info.Text + itemInfo1 + Environment.NewLine;
    buMarbleForms.frmHorVerDialog.txt_info.Text += itemInfo2;
    clsInit.appMarble.doAddItemVerHorBothMainForm(new Point3D(), new Point3D(), buMarbleForms.frmHorVerDialog.spn_horverangle.Value, buMarbleForms.frmHorVerDialog.spn_itemhorlength.Value, buMarbleForms.frmHorVerDialog.spn_itemverlength.Value);
  }

  public void spn_Horitem_KeyDown(object sender, KeyEventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    if (control.Tag == null)
      return;
    int.TryParse(control.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(buMarbleForms.frmHorizontal.pnl_data.Controls, result, e.Shift);
  }

  public void spn_Veritem_KeyDown(object sender, KeyEventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(buMarbleForms.frmVertical.pnl_data.Controls, result, e.Shift);
  }

  public void spn_HorVerHoritem_KeyDown(object sender, KeyEventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    if (control.Tag == null)
      return;
    int.TryParse(control.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(buMarbleForms.frmHorVer.tabPage_Hor.Controls, result, e.Shift);
  }

  public void spn_HorVerVeritem_KeyDown(object sender, KeyEventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(buMarbleForms.frmHorVer.tabPage_Ver.Controls, result, e.Shift);
  }

  public void spn_HorVerHorDialogitem_KeyDown(object sender, KeyEventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls, result, e.Shift);
  }

  public void spn_HorVerVerDialogitem_KeyDown(object sender, KeyEventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls, result, e.Shift);
  }

  public void spn_HorOrVeritem_KeyDown(object sender, KeyEventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(buMarbleForms.frmHorOrVerDialog.pnl_data.Controls, result, e.Shift);
  }

  public void spn_item_Click(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      buSpin buSpin = sender as buSpin;
      buFunctions.ShowKeyPad(clsAppMarbleItems.frmMain, (System.Windows.Forms.Control) buSpin, buSpin.Caption.Caption, 1, "");
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 12, (object) null, (object) null, (object) null, (object) null);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  public void spn_item_Enter(object sender, EventArgs e)
  {
    buSpin buSpin = sender as buSpin;
    buSpin.Display.OldColor = buSpin.Display.BackColor;
    buSpin.Display.BackColor = buEyeVars.parVisual.colorDataFocus;
  }

  public void spn_item_Leave(object sender, EventArgs e)
  {
    buSpin buSpin = sender as buSpin;
    buSpin.Display.BackColor = buSpin.Display.OldColor;
  }

  public void btn_ItemCommand_Click(object sender, EventArgs e)
  {
    // ISSUE: unable to decompile the method.
  }

  public void btn_ItemCommandV2_Click(object sender, EventArgs e)
  {
    // ISSUE: unable to decompile the method.
  }

  public void Tab_HorVerSelectedIndexChanged(object sender, EventArgs e)
  {
    // ISSUE: unable to decompile the method.
  }

  public void Tab_HorVerDialogSelectedIndexChanged(object sender, EventArgs e)
  {
    // ISSUE: unable to decompile the method.
  }

  public void btn_ItemCommandHorOrVerDialog_Click(object sender, EventArgs e)
  {
    // ISSUE: unable to decompile the method.
  }

  public void MaterialMeasureCalc()
  {
    if (clsAppMarbleVars.varRuntime.MaterialIndex == 0 | clsAppMarbleVars.varRuntime.MaterialIndex == 1)
    {
      clsAppMarbleVars.varRuntime.MaterialIndex = 1;
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness1", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    }
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 2)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness2", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 3)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness3", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 4)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness4", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 5)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness5", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 6)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness6", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 7)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness7", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 8)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness8", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 9)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness9", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 10)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness10", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 11)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness11", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 12)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness12", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 13)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness13", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 14)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness14", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 15)
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness15", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    else if (clsAppMarbleVars.varRuntime.MaterialIndex == 16 /*0x10*/)
    {
      this.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcThickness16", ref clsAppMarbleVars.varRuntime.MaterialMeasuredThickness);
    }
    else
    {
      clsAppMarbleVars.varRuntime.MaterialIndex = -1;
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionMessage.MaterialMeasureIndexOutofRange, (object) null, (object) null, (object) null);
      }
    }
    if (clsAppMarbleVars.varRuntime.MaterialIndex >= 0 & clsAppMarbleVars.varRuntime.MaterialIndex <= clsAppMarbleVars.cMachine.MaterialMeasureList.Count)
    {
      clsAppMarbleVars.cMachine.MaterialMeasureList[clsAppMarbleVars.varRuntime.MaterialIndex - 1].Z = clsAppMarbleVars.varRuntime.MaterialMeasuredThickness;
      if (clsAppMarbleVars.varApp.MaterialMeasureMode == AutoManuel.Manuel)
      {
        buMarbleCalc.varOperation.MaterialParameter.MaterialThickness = clsAppMarbleVars.varRuntime.MaterialMeasuredThickness;
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 26, (object) clsAppMarbleVars.varRuntime.MaterialMeasuredThickness, (object) null, (object) null, (object) null);
        }
      }
    }
    if ((clsAppMarbleItems.frmMaterialMeasure == null ? 0 : (clsAppMarbleItems.frmMaterialMeasure.Visible ? 1 : 0)) == 0)
      return;
    clsAppMarbleItems.frmMaterialMeasure.FillList();
  }

  public void DebugExecute(object sender, DebugCommandEventArg e)
  {
    try
    {
      if (e.DebugCommand.ToLower() == "createdefaultcodesys")
      {
        this.DebugCreateCodesysDefault();
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) buLangTranslate.preDef.Ok);
      }
      else if (e.DebugCommand.ToLower() == "createdefaultpost")
      {
        this.DebugCreateDefaultPost();
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) buLangTranslate.preDef.Ok);
      }
      else if (e.DebugCommand.ToLower() == "createdefaultfolder")
      {
        this.DebugDefaultSet("Default");
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) buLangTranslate.preDef.Ok);
      }
      else if (e.DebugCommand.ToLower() == "createbackupfolder")
      {
        this.DebugDefaultSet(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2"));
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) buLangTranslate.preDef.Ok);
      }
      else if (e.DebugCommand.ToLower() == "showmwdialog")
      {
        string str = clsInit.appMarble.DebugExecute(e);
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) str);
      }
      else if (e.DebugCommand.ToLower() == "hidemwdialog")
      {
        string str = clsInit.appMarble.DebugExecute(e);
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) str);
      }
      else if (e.DebugCommand.ToLower().IndexOf("createuserdll") >= 0)
      {
        string userDll = this.DebugCreateUserDll(e.DebugCommand);
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) userDll);
      }
      else if (e.DebugCommand.ToLower().IndexOf("createappvisual") >= 0)
      {
        hmiUICommands.SaveApplicationVisualFile(AppPath.MachineSettings + "\\ApplicationVisual.prm");
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) buLangTranslate.preDef.Ok);
      }
      else if (e.DebugCommand.ToLower().IndexOf("createrctpcodes") >= 0)
      {
        this.DebugCreateRTCPCodesFromPointList();
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) buLangTranslate.preDef.Ok);
      }
      else if (e.DebugCommand.ToLower().IndexOf("kinematicinfo") >= 0)
      {
        this.DebugKinematicInfo();
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) buLangTranslate.preDef.Ok);
      }
      else
        clsAppMarbleItems.frmDebug.lst_commands.Items.Add((object) buLangTranslate.preDef.Error);
    }
    catch (Exception ex)
    {
    }
  }

  public void DebugCreateDefaultPost()
  {
    string callMethod = nameof (DebugCreateDefaultPost);
    try
    {
      PostProcessor postProcessor = new PostProcessor();
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) postProcessor.ToDefAll("", 0, SerilizationMode.MultiLine));
      buFile5.SaveToFile(arrayList, AppPath.Base + "\\DefultPost.txt");
      arrayList.Clear();
      buLogMarbleVer5.addToUserLog(nameof (DebugCreateDefaultPost), "Created", "", "", "", "", 0);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void DebugCreateCodesysDefault()
  {
    string callMethod = nameof (DebugCreateCodesysDefault);
    try
    {
      List<string> stringList = new List<string>();
      for (int index = 0; index <= clsAppMarbleVars.cMachine.AppAxis.Count - 1; ++index)
      {
        CodesysAxis axisPar = clsAppMarbleVars.cMachine.AppAxis[index].AxisPar;
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setUnit := {axisPar.Sets.setUnit.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setPulse := {axisPar.Sets.setPulse.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setGearRatio := {axisPar.Sets.setGearRatio.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setReverseDirection := {axisPar.Sets.setReverseDirection.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setEmergencyDec := {axisPar.Sets.setEmergencyDec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setMaxVelocity := {axisPar.Sets.setMaxVelocity.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setMaxAcc := {axisPar.Sets.setMaxAcc.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setMaxDec := {axisPar.Sets.setMaxDec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setMaxJerk := {axisPar.Sets.setMaxJerk.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setRampType := {axisPar.Sets.setRampType.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setSoftLimitEnable := {axisPar.Sets.setSoftLimitEnable.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setSoftLimitControlFromPLC := {axisPar.Sets.setSoftLimitControlFromPLC.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setSoftLimitPositive := {axisPar.Sets.setSoftLimitPositive.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setSoftLimitNegative := {axisPar.Sets.setSoftLimitNegative.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setSoftLimitErrorDecEnable := {axisPar.Sets.setSoftLimitErrorDecEnable.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setSoftLimitErrorDec := {axisPar.Sets.setSoftLimitErrorDec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setSoftLimitErrorMaxDistance  := {axisPar.Sets.setSoftLimitErrorMaxDistance.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setHardLimitEnable := {axisPar.Sets.setHardLimitEnable.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setDataLimitPositive := {axisPar.Sets.setDataLimitPositive.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setDataLimitNegative := {axisPar.Sets.setDataLimitNegative.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setParkPosition := {axisPar.Sets.setParkPosition.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setGantryEnable := {axisPar.Sets.setGantryEnable.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setGantryNumerator := {axisPar.Sets.setGantryNumerator.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setGantryDenumerator := {axisPar.Sets.setGantryDenumerator.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setPositionDoneLimit := {axisPar.Sets.setPositionDoneLimit.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setAxesType := {axisPar.Sets.setAxesType.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setData.setPositionDoneLimit := {axisPar.Sets.setPositionDoneLimit.ToString()};");
        stringList.Add(" ");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setMove.moveVelocity :={axisPar.Moves.moveVelocity.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setMove.moveAcc :={axisPar.Moves.moveAcc.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setMove.moveDec :={axisPar.Moves.moveDec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setMove.moveJerk :={axisPar.Moves.moveJerk.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setMove.moveOverrideEnable :={axisPar.Moves.moveOverrideEnable.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setMove.moveDynamicVelocityFromFeed :={axisPar.Moves.moveDynamicVelocityFromFeed.ToString()};");
        stringList.Add(" ");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogVelocity :={axisPar.Jogs.jogVelocity.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogAcc :={axisPar.Jogs.jogAcc.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogDec :={axisPar.Jogs.jogDec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogJerk :={axisPar.Jogs.jogJerk.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogFirstSpeedPersentage :={axisPar.Jogs.jogFirstSpeedPersentage.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogSecondSpeedPersentage :={axisPar.Jogs.jogSecondSpeedPersentage.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogFirstSpeedTimeSec :={axisPar.Jogs.jogFirstSpeedTimeSec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogSecondSpeedTimeSec :={axisPar.Jogs.jogSecondSpeedTimeSec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogWithAbsoluteMove :={axisPar.Jogs.jogWithAbsoluteMove.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogOverrideEnable :={axisPar.Jogs.jogOverrideEnable.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setJog.jogDynamicVelocityFromFeed :={axisPar.Jogs.jogDynamicVelocityFromFeed.ToString()};");
        stringList.Add(" ");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingFastVelocity :={axisPar.Homings.homingFastVelocity.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingSlowVelocity :={axisPar.Homings.homingSlowVelocity.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingSetPosition :={axisPar.Homings.homingSetPosition.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingOffset :={axisPar.Homings.homingOffset.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingAcc :={axisPar.Homings.homingAcc.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingDec :={axisPar.Homings.homingDec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingJerk :={axisPar.Homings.homingJerk.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingDelay :={axisPar.Homings.homingDelay.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingTimeoutSec :={axisPar.Homings.homingTimeoutSec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingMode :={axisPar.Homings.homingMode.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingMethod :={axisPar.Homings.homingMethod.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingDriveHomeMode :={axisPar.Homings.homingDriveHomeMode.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingReverseDir :={axisPar.Homings.homingReverseDir.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingSwitchNC :={axisPar.Homings.homingSwitchNC.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingDisableLimits :={axisPar.Homings.homingDisableLimits.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingUseSecondSlowSpeed :={axisPar.Homings.homingUseSecondSlowSpeed.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setHoming.homingAbsoluteHomePosition :={axisPar.Homings.homingAbsoluteHomePosition.ToString()};");
        stringList.Add(" ");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setGear.gearNumerator :={axisPar.Gear.gearNumerator.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setGear.gearDenominator :={axisPar.Gear.gearDenominator.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setGear.gearAcc :={axisPar.Gear.gearAcc.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setGear.gearDec :={axisPar.Gear.gearDec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setGear.gearJerk :={axisPar.Gear.gearJerk.ToString()};");
        stringList.Add(" ");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setCnc.cncMaxAccDec :={axisPar.Cnc.cncMaxAccDec.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setCnc.cncMaxFeed :={axisPar.Cnc.cncMaxFeed.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setCnc.cncMaxDifferance :={axisPar.Cnc.cncMaxDifferance.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setCnc.cncIncludePathSettings :={axisPar.Cnc.cncIncludePathSettings.ToString()};");
        stringList.Add($"AxisSet{axisPar.Base.baseChar}.setCnc.cncStrictlyHoldAccDecABC :={axisPar.Cnc.cncStrictlyHoldAccDecABC.ToString()};");
        stringList.Add(" ");
        stringList.Add(" ");
      }
      buFile5.SaveToFile(stringList, AppPath.Base + "\\DefaultPars.txt");
      Task.Run(baslerCamcs.\u003C\u003E9__89_0 ?? (baslerCamcs.\u003C\u003E9__89_0 = new Action(((baslerCamcs) baslerCamcs.\u003C\u003E9).\u0001)));
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void DebugCreateDefaultIOFile()
  {
    string callMethod = nameof (DebugCreateDefaultIOFile);
    try
    {
      List<string> stringList = new List<string>();
      stringList.Add("<Inputs>");
      for (int index = 0; index <= clsAppMarbleVars.cMachine.Inputs.Count - 1; ++index)
        stringList.Add($"  {clsAppMarbleVars.cMachine.Inputs[index].Name} ; {clsAppMarbleVars.cMachine.Inputs[index].SourceIndex.ToString()} {clsAppMarbleVars.cMachine.Inputs[index].Invert.ToString()} {clsAppMarbleVars.cMachine.Inputs[index].Caption}");
      stringList.Add("</Inputs>");
      stringList.Add(" ");
      stringList.Add("<Outputs>");
      for (int index = 0; index <= clsAppMarbleVars.cMachine.Outputs.Count - 1; ++index)
        stringList.Add($"  {clsAppMarbleVars.cMachine.Outputs[index].Name} ; {clsAppMarbleVars.cMachine.Outputs[index].SourceIndex.ToString()} {clsAppMarbleVars.cMachine.Outputs[index].Invert.ToString()} {clsAppMarbleVars.cMachine.Outputs[index].Caption}");
      stringList.Add("</Outputs>");
      buFile5.SaveToFile(stringList, AppPath.Base + "\\DefaultIO.txt");
      Task.Run(baslerCamcs.\u003C\u003E9__90_0 ?? (baslerCamcs.\u003C\u003E9__90_0 = new Action(((baslerCamcs) baslerCamcs.\u003C\u003E9).\u0002)));
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void DebugCreateDefaultCodesysIO()
  {
    string callMethod = nameof (DebugCreateDefaultCodesysIO);
    try
    {
      List<string> collection1 = new List<string>();
      List<string> collection2 = new List<string>();
      List<string> collection3 = new List<string>();
      List<string> collection4 = new List<string>();
      for (int index = 0; index <= clsAppMarbleVars.cMachine.Inputs.Count - 1; ++index)
      {
        if (clsAppMarbleVars.cMachine.Inputs[index].SourceIndex > 0)
          collection1.Add($"IO.{clsAppMarbleVars.cMachine.Inputs[index].Name}.SourceIndex := {clsAppMarbleVars.cMachine.Inputs[index].SourceIndex.ToString()};");
        if (clsAppMarbleVars.cMachine.Inputs[index].SourceIndex <= 0)
          collection2.Add($"IO.{clsAppMarbleVars.cMachine.Inputs[index].Name}.SourceIndex := {clsAppMarbleVars.cMachine.Inputs[index].SourceIndex.ToString()};");
      }
      for (int index = 0; index <= clsAppMarbleVars.cMachine.Outputs.Count - 1; ++index)
      {
        if (clsAppMarbleVars.cMachine.Outputs[index].SourceIndex > 0)
          collection3.Add($"IO.{clsAppMarbleVars.cMachine.Outputs[index].Name}.SourceIndex := {clsAppMarbleVars.cMachine.Outputs[index].SourceIndex.ToString()};");
        if (clsAppMarbleVars.cMachine.Outputs[index].SourceIndex <= 0)
          collection4.Add($"IO.{clsAppMarbleVars.cMachine.Outputs[index].Name}.SourceIndex := {clsAppMarbleVars.cMachine.Outputs[index].SourceIndex.ToString()};");
      }
      List<string> stringList = new List<string>();
      stringList.AddRange((IEnumerable<string>) collection1);
      stringList.Add(" ");
      stringList.AddRange((IEnumerable<string>) collection2);
      stringList.Add(" ");
      stringList.AddRange((IEnumerable<string>) collection3);
      stringList.Add(" ");
      stringList.AddRange((IEnumerable<string>) collection4);
      buFile5.SaveToFile(stringList, AppPath.Base + "\\DefaultCodesysIO.txt");
      Task.Run(baslerCamcs.\u003C\u003E9__91_0 ?? (baslerCamcs.\u003C\u003E9__91_0 = new Action(((baslerCamcs) baslerCamcs.\u003C\u003E9).\u0003)));
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public bool DebugGetLastBackUpFiles(ref string PathName)
  {
    try
    {
      List<string> stringList = new List<string>();
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Machine + "\\Backup");
      if (!directoryInfo.Exists)
        return false;
      buFile5.getPathsInPath(directoryInfo.FullName, ref stringList);
      stringList.Reverse();
      if (stringList.Count > 0 && stringList[0] == "Default")
        stringList.RemoveAt(0);
      if (stringList.Count <= 0)
        return false;
      PathName = stringList[0];
      Task.Run(F_MarbleVideoPlayer.\u003C\u003E9__92_0 ?? (F_MarbleVideoPlayer.\u003C\u003E9__92_0 = new Action(((baslerCamcs) baslerCamcs.\u003C\u003E9).\u0004)));
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public void DebugDefaultSet(string Folder)
  {
    if (Folder.Length == 0)
      Folder = "Default";
    DirectoryInfo directoryInfo1 = new DirectoryInfo(AppPath.Machine + "\\Backup");
    if (!directoryInfo1.Exists)
      directoryInfo1.Create();
    DirectoryInfo directoryInfo2 = new DirectoryInfo($"{AppPath.Machine}\\Backup\\{Folder}");
    if (!directoryInfo2.Exists)
      directoryInfo2.Create();
    buFile5.CopyFilesRecursively(AppPath.MachineSettings, $"{AppPath.Machine}\\Backup\\{Folder}");
  }

  public void DebugKinematicInfo()
  {
    buDialogMessageBoxOk dialogMessageBoxOk = new buDialogMessageBoxOk();
    dialogMessageBoxOk.Init(buLangTranslate.preDef.Kinematic, buLangTranslate.preHelpMarble.KinematicExplain);
    int num = (int) dialogMessageBoxOk.ShowDialog();
  }

  public void DebugDefaultGet()
  {
    buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
    dialogMessageBoxYesNo.Init(buLangTranslate.preDef.Default, buLangTranslate.preSentences.DoYouWanttoCallDefaultValues);
    if (dialogMessageBoxYesNo.Result == DialogResult.OK)
      ;
  }

  public string DebugCreateUserDll(string Cmd)
  {
    string[] strArray = buString5.FindStringBetweenTwoChar(Cmd, "(", ")").Split(',');
    string userDll;
    if (strArray.Length >= 3)
    {
      if (strArray.Length >= 3)
      {
        if (strArray[0].Trim().Length >= 0)
          clsVar.appDefination.MachineNo = strArray[0].Trim();
        if (strArray[1].Trim().Length >= 0)
          clsVar.appDefination.MachineSerial = strArray[1].Trim();
        if (strArray[2].Trim().Length >= 0)
          clsVar.appDefination.MachineName = strArray[1].Trim();
        this.SaveUserDll();
      }
      userDll = buLangTranslate.preDef.Ok;
    }
    else
      userDll = buLangTranslate.preDef.Error;
    return userDll;
  }

  public void DebugCreateRTCPCodesFromPointList()
  {
    FileInfo fileInfo = new FileInfo(AppPath.Base + "\\SampleCoords.txt");
    if (!fileInfo.Exists)
      return;
    List<string> stringList = new List<string>();
    buFile5.OpenFromFile(fileInfo.FullName, ref stringList);
    List<Pnt6D> PointList = new List<Pnt6D>();
    for (int index = 0; index <= stringList.Count - 1; ++index)
    {
      Pnt6D pnt6D = Pnt6D.DecodeFromString(stringList[index]);
      if (pnt6D != (Pnt6D) null)
        PointList.Add(pnt6D);
    }
    if (PointList.Count <= 0)
      return;
    clsInit.appMarble.doAddItemPointList(PointList);
  }

  public void SetTextOfControl(buControl Ctrl, string Txt)
  {
    if (Ctrl == null)
      return;
    Ctrl.Text = Txt;
  }

  public buLabel SetTextOfLabel(buLabel Ctrl, string Txt)
  {
    if (Ctrl != null)
      Ctrl.Text = Txt;
    return Ctrl;
  }

  public void clsMarbleAppCommands(
    object Data1,
    object Data2,
    object Data3,
    object Data4,
    object Data5)
  {
    // ISSUE: unable to decompile the method.
  }

  public void DisposeAll()
  {
    if (clsItem.FrmFromFile != null)
      clsItem.FrmFromFile.Dispose();
    if (clsMarble.FrmLibraryDraw != null)
      clsMarble.FrmLibraryDraw.Dispose();
    if (clsItem.frmEditorV2 != null)
      clsItem.frmEditorV2.viewport.Dispose();
    try
    {
    }
    catch (Exception ex)
    {
    }
  }

  public void SimUpdated(Pnt6DSimMove Pnt, ToolBase5 Tool, int CodeIndex)
  {
    clsAppMarbleControls.lblPartX = this.SetTextOfLabel(clsAppMarbleControls.lblPartX, Pnt.X.ToString("f2"));
    clsAppMarbleControls.lblPartY = this.SetTextOfLabel(clsAppMarbleControls.lblPartY, Pnt.Y.ToString("f2"));
    clsAppMarbleControls.lblPartZ = this.SetTextOfLabel(clsAppMarbleControls.lblPartZ, Pnt.Z.ToString("f2"));
    clsAppMarbleControls.lblPartA = this.SetTextOfLabel(clsAppMarbleControls.lblPartA, Pnt.A.ToString("f2"));
    clsAppMarbleControls.lblPartC = this.SetTextOfLabel(clsAppMarbleControls.lblPartC, Pnt.C.ToString("f2"));
  }

  public void buMotionCommandEvents(MotionCommandEventArg e)
  {
    // ISSUE: reference to a compiler-generated field
    if (e.Command == MotionCommands.ShowWarning && !clsAppMarbleVars.cMachine.bParameterWriting && ((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) e.Message, (object) null, (object) null, (object) null);
    }
    if (e.Command != MotionCommands.ShowWarningList)
      return;
    List<AppWarning> appWarningList = new List<AppWarning>();
    if (e.ErrorList.Count <= 0)
      return;
    for (int index = 0; index <= e.ErrorList.Count - 1; ++index)
      clsAppMarbleVars.cMachine.WarningList.Add(new AppWarning(e.ErrorList[index]));
  }

  public void MachineMinMaxPoints()
  {
    if (clsAppMarbleVars.cMachine.AppAxis.Count < 5)
      return;
    clsAppMarbleVars.cMachine.miscVar.MinMachinePoint.X = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitNegative;
    clsAppMarbleVars.cMachine.miscVar.MinMachinePoint.Y = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitNegative;
    clsAppMarbleVars.cMachine.miscVar.MinMachinePoint.Z = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitNegative;
    clsAppMarbleVars.cMachine.miscVar.MinMachinePoint.A = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitNegative;
    clsAppMarbleVars.cMachine.miscVar.MinMachinePoint.C = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitNegative;
    clsAppMarbleVars.cMachine.miscVar.MaxMachinePoint.X = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitPositive;
    clsAppMarbleVars.cMachine.miscVar.MaxMachinePoint.Y = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitPositive;
    clsAppMarbleVars.cMachine.miscVar.MaxMachinePoint.Z = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitPositive;
    clsAppMarbleVars.cMachine.miscVar.MaxMachinePoint.A = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitPositive;
    clsAppMarbleVars.cMachine.miscVar.MaxMachinePoint.C = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitPositive;
  }

  public void LoadFile(string FileName)
  {
    if (!(AppBool.Connected & !clsAppMarbleVars.cMachine.runSystem.Run))
      return;
    this.SentToController(FileName);
  }

  public void ToolMillingCommands(string Command, int Value)
  {
    if (!AppBool.Connected)
      return;
    if (Command == "MillingActivate")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToActivateTool} [ {buLangTranslate.preDef.Milling} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SawActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.MillingActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.MillingHeadActivated");
      this.ToolSelect((MarbleToolType) 1);
    }
    if (Command == "MillingZLimitDisable")
      this.writeLREALVar(CodesysVariableBaseType.Global, -500.0, "AppRun.ZLimitDisableExtraLimit");
    if (Command == "MillingMeasure")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToMeasureTool} [ {buLangTranslate.preDef.Milling} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.ToolMillingMasure");
    }
    if (Command == "MillingSetZero")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToMakeToolZero} [ {buLangTranslate.preDef.Milling} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      double Val = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition - buMarbleCalc.activeToolMilling.Geometry.Length, 3);
      this.writeLREALVar(CodesysVariableBaseType.Persistent, Val, "appSet.MillingExtraG54OffsetZ");
      clsAppMarbleVars.varApp.MillingExtraG54OffsetZ = Val;
      this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.activeToolMilling.Geometry.Length, "sysSet.toolActiveSpindle.Length");
      clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 15, (object) null, (object) null, (object) null, (object) null);
      }
    }
    if (Command == "MillingGoZero")
    {
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToGoToolZeroPosition} [ {buLangTranslate.preDef.Milling} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      double Position = clsAppMarbleVars.varApp.MillingExtraG54OffsetZ + buMarbleCalc.activeToolMilling.Geometry.Length;
      clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, Position, true);
    }
    if (Command == "SetToolActive")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SawActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.MillingActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.MillingHeadActivated");
      this.writeDINTVar(CodesysVariableBaseType.Global, 1, "AppRun.ActiveToolType");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.MillingSelect");
      this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.ToolInMagazine[Value].Geometry.Length, "sysSet.toolActiveSpindle.Length");
      this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.ToolInMagazine[Value].Geometry.Diameter, "sysSet.toolActiveSpindle.Diameter");
      this.writeDINTVar(CodesysVariableBaseType.Persistent, Value, "sysSet.toolActiveSpindle.No");
      this.writeDINTVar(CodesysVariableBaseType.Persistent, Value, "appSet.toolActiveNo");
      this.ClickCommand((MarbleMotionCommands) 53);
      clsAppMarbleVars.varApp.toolActiveNo = Value;
      this.ReadTools(false);
      AppBool.ToolChanged = true;
      if ((clsAppMarbleItems.frmToolCurrent == null ? 0 : (clsAppMarbleItems.frmToolCurrent.Visible ? 1 : 0)) != 0)
      {
        clsAppMarbleItems.frmToolCurrent.spn_milling_diameter.Value = buMarbleCalc.activeToolMilling.Geometry.Diameter;
        clsAppMarbleItems.frmToolCurrent.spn_milling_length.Value = buMarbleCalc.activeToolMilling.Geometry.Length;
        clsAppMarbleItems.frmToolCurrent.spn_milling_speed.Value = buMarbleCalc.activeToolMilling.CamData.SpindleSpeed;
      }
      this.SaveParameterUser();
    }
    if (!(Command == "TakeTool"))
      return;
    if (clsAppMarbleVars.cMachine.runSystem.Run)
    {
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
    }
    else
    {
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SawActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.MillingActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.MillingHeadActivated");
      this.writeDINTVar(CodesysVariableBaseType.Global, 1, "AppRun.ActiveToolType");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.MillingSelect");
      this.ClickCommand((MarbleMotionCommands) 53);
      this.writeDINTVar(CodesysVariableBaseType.Global, Value, "sysRun.toolNextSpindleNo");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.ToolChangeStart");
    }
  }

  public void ToolMillingHeadCommands(string Command)
  {
    if (!AppBool.Connected)
      return;
    if (Command == "MillingHeadActivate")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToActivateTool} [ {buLangTranslate.preDef.MillingHead} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.SawActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.MillingActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.MillingHeadActivated");
      this.ToolSelect((MarbleToolType) 3);
    }
    if (Command == "MillingHeadZLimitDisable")
      this.writeLREALVar(CodesysVariableBaseType.Global, -500.0, "AppRun.ZLimitDisableExtraLimit");
    if (Command == "MillingHeadMeasure")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToMeasureTool} [ {buLangTranslate.preDef.MillingHead} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.ToolMillingHeadMeasure");
    }
    if (Command == "MillingHeadSetZero")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToMakeToolZero} [ {buLangTranslate.preDef.MillingHead} ]");
      int num1 = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      double num2 = buMarbleCalc.activeToolMillingHead.Geometry.Length - clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition;
      this.writeLREALVar(CodesysVariableBaseType.Persistent, -num2, "appSet.MillingHeadExtraG54OffsetZ");
      clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetZ = -num2;
      this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.activeToolMillingHead.Geometry.Length, "sysSet.toolActiveSpindleHead.Length");
      clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 16 /*0x10*/, (object) null, (object) null, (object) null, (object) null);
      }
    }
    if (!(Command == "MillingHeadGoZero"))
      return;
    buDialogMessageBoxYesNo dialogMessageBoxYesNo1 = new buDialogMessageBoxYesNo();
    dialogMessageBoxYesNo1.StartPosition = FormStartPosition.CenterScreen;
    dialogMessageBoxYesNo1.Init($"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToGoToolZeroPosition} [ {buLangTranslate.preDef.MillingHead} ]");
    int num3 = (int) dialogMessageBoxYesNo1.ShowDialog();
    if (dialogMessageBoxYesNo1.Result != DialogResult.Yes)
      return;
    double Position = clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetZ + buMarbleCalc.activeToolMillingHead.Geometry.Length;
    clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, Position, true);
  }

  public void ToolSawCommands(string Command)
  {
    if (!AppBool.Connected)
      return;
    if (Command == "SawActivate")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToActivateTool} [ {buLangTranslate.preDef.Saw} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.SawActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.MillingActivated");
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "AppRun.MillingHeadActivated");
      this.ToolSelect((MarbleToolType) 0);
    }
    if (Command == "SawMeasure")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToMeasureTool} [ {buLangTranslate.preDef.Saw} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.ToolSawMeasure");
    }
    if (Command == "SawSetZero")
    {
      if (clsAppMarbleVars.cMachine.runSystem.Run)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
        return;
      }
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
      dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToMakeToolZero} [ {buLangTranslate.preDef.Saw} ]");
      int num1 = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
        return;
      this.writeLREALVar(CodesysVariableBaseType.Global, 0.0, "AppRun.ZLimitDisableExtraLimit");
      double num2 = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2) - buMarbleCalc.activeToolSaw.Geometry.Diameter / 2.0;
      clsAppMarbleVars.cMachine.G54List[0].Z = num2;
      clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
    }
    if (Command == "SawZLimitDisable")
      this.writeLREALVar(CodesysVariableBaseType.Global, -500.0, "AppRun.ZLimitDisableExtraLimit");
    if (!(Command == "SawGoZero"))
      return;
    buDialogMessageBoxYesNo dialogMessageBoxYesNo1 = new buDialogMessageBoxYesNo();
    dialogMessageBoxYesNo1.StartPosition = FormStartPosition.CenterScreen;
    dialogMessageBoxYesNo1.Init($"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Tool}", $"{buLangTranslate.preSentences.DoYouWantToGoToolZeroPosition} [ {buLangTranslate.preDef.Saw} ]");
    int num3 = (int) dialogMessageBoxYesNo1.ShowDialog();
    if (dialogMessageBoxYesNo1.Result != DialogResult.Yes)
      return;
    double Position = clsAppMarbleVars.cMachine.G54List[0].Z + buMarbleCalc.activeToolSaw.Geometry.Diameter / 2.0;
    clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, Position, true);
  }

  public void ToolSelect(MarbleToolType ToolType)
  {
    // ISSUE: unable to decompile the method.
  }

  public void UpdateParameter()
  {
    if (!AppBool.Connected)
      return;
    this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.SystemParUpdate");
    this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.AxisParUpdate");
  }

  public void UpdateScaleParameter()
  {
    if (!AppBool.Connected)
      return;
    this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.AxisParScaleUpdate");
  }

  public void UpdateCncParameter()
  {
    if (!AppBool.Connected)
      return;
    this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ParameterCNCUpdate");
  }

  public void MarbleSystemBoolConversion(bool[] SystemBoolBlock, ref CodesysMachine Mach)
  {
    if (SystemBoolBlock == null)
      return;
    for (int index = 0; index <= SystemBoolBlock.Length - 1; ++index)
    {
      if (index == 0)
        Mach.runSystem.Alarm = SystemBoolBlock[index];
      if (index == 1)
        Mach.runSystem.Run = SystemBoolBlock[index];
      if (index == 2)
        Mach.runSystem.Pause = SystemBoolBlock[index];
      if (index == 3)
        Mach.runSystem.HomingDone = SystemBoolBlock[index];
      if (index == 4)
        Mach.runSystem.Enabled = SystemBoolBlock[index];
      if (index == 5)
        Mach.runSystem.WarningOccured = SystemBoolBlock[index];
      if (index == 6)
        Mach.runSystem.GantryOk = SystemBoolBlock[index];
      if (index == 7)
        Mach.runSystem.FileLoaded = SystemBoolBlock[index];
      if (index == 8)
        Mach.runSystem.Water = SystemBoolBlock[index];
      if (index == 9)
        Mach.runSystem.Laser = SystemBoolBlock[index];
      if (index == 10)
        Mach.runSystem.Spindle = SystemBoolBlock[index];
      if (index == 11)
        Mach.runSystem.Saw = SystemBoolBlock[index];
      if (index == 12)
        Mach.runSystem.MAcOk = SystemBoolBlock[index];
      if (index == 13)
        Mach.runSystem.InitDone = SystemBoolBlock[index];
      if (index == 14)
        Mach.runSystem.Auto = SystemBoolBlock[index];
      if (index == 15)
        Mach.runSystem.Manuel = SystemBoolBlock[index];
      if (index == 16 /*0x10*/)
        Mach.runSystem.Pens = SystemBoolBlock[index];
      if (index == 17)
        Mach.runSystem.Move = SystemBoolBlock[index];
      if (index == 18)
        Mach.runSystem.RtcpActivated = SystemBoolBlock[index];
      if (index == 19)
        Mach.runSystem.Calculated = SystemBoolBlock[index];
      if (index == 20)
        Mach.runSystem.ToolUpdate = SystemBoolBlock[index];
      if (index == 21)
        Mach.runSystem.SawUpdate = SystemBoolBlock[index];
      if (index == 22)
        Mach.runSystem.PartZero = SystemBoolBlock[index];
      if (index == 23)
        Mach.runSystem.ParameterUpdated = SystemBoolBlock[index];
      if (index == 24)
        Mach.runSystem.HandWheelActivated = SystemBoolBlock[index];
      if (index == 25)
        Mach.runSystem.Finished = SystemBoolBlock[index];
      if (index == 26)
        Mach.runSystem.SimulatedAxes = SystemBoolBlock[index];
      if (index == 27)
        Mach.runSystem.SimulatedIO = SystemBoolBlock[index];
      if (index == 28)
        Mach.runSystem.CameraReady = SystemBoolBlock[index];
      if (index == 29)
        Mach.runSystem.WagonUp = SystemBoolBlock[index];
      if (index == 30)
        Mach.runSystem.SemiAuto = SystemBoolBlock[index];
      if (index == 31 /*0x1F*/)
        Mach.runSystem.CruiseControl = SystemBoolBlock[index];
    }
  }

  public void MarbleAuxBool1Conversion(bool[] SystemBoolBlock, ref CodesysMachine Mach)
  {
    if (SystemBoolBlock == null)
      return;
    for (int index = 0; index <= SystemBoolBlock.Length - 1; ++index)
    {
      if (index == 0)
        Mach.runSystem.isSawActivated = SystemBoolBlock[index];
      if (index == 1)
        Mach.runSystem.isMillingActivated = SystemBoolBlock[index];
      if (index == 2)
        Mach.runSystem.isMillingHeadActivated = SystemBoolBlock[index];
      if (index == 3)
        Mach.runSystem.isWaterJetActivated = SystemBoolBlock[index];
      if (index == 4 && clsAppMarbleVars.varRuntime.AxA >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove = SystemBoolBlock[index];
      if (index == 5)
        Mach.runSystem.EthercatResetExecuting = SystemBoolBlock[index];
      if (index == 6 && clsAppMarbleVars.varRuntime.AxX >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bAllowToMove = SystemBoolBlock[index];
      if (index == 7 && clsAppMarbleVars.varRuntime.AxY >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bAllowToMove = SystemBoolBlock[index];
      if (index == 8 && clsAppMarbleVars.varRuntime.AxZ >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bAllowToMove = SystemBoolBlock[index];
      if (index == 9 && clsAppMarbleVars.varRuntime.AxC >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bAllowToMove = SystemBoolBlock[index];
      if (index == 10)
        Mach.runSystem.isZLowerThenMaterialSafeDis = SystemBoolBlock[index];
      if (index == 11 && clsAppMarbleVars.varRuntime.AxX >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bJogPlus = SystemBoolBlock[index];
      if (index == 12 && clsAppMarbleVars.varRuntime.AxX >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bJogMinus = SystemBoolBlock[index];
      if (index == 13 && clsAppMarbleVars.varRuntime.AxY >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bJogPlus = SystemBoolBlock[index];
      if (index == 14 && clsAppMarbleVars.varRuntime.AxY >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bJogMinus = SystemBoolBlock[index];
      if (index == 15 && clsAppMarbleVars.varRuntime.AxZ >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bJogPlus = SystemBoolBlock[index];
      if (index == 16 /*0x10*/ && clsAppMarbleVars.varRuntime.AxZ >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bJogMinus = SystemBoolBlock[index];
      if (index == 17 && clsAppMarbleVars.varRuntime.AxC >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bJogPlus = SystemBoolBlock[index];
      if (index == 18 && clsAppMarbleVars.varRuntime.AxC >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bJogMinus = SystemBoolBlock[index];
      if (index == 19 && clsAppMarbleVars.varRuntime.AxA >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bJogPlus = SystemBoolBlock[index];
      if (index == 20 && clsAppMarbleVars.varRuntime.AxA >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bJogMinus = SystemBoolBlock[index];
      if (index == 21)
        clsAppMarbleVars.varRuntime.SpindleDown = SystemBoolBlock[index];
      if (index == 22)
        clsAppMarbleVars.varRuntime.isDryRunActivated = SystemBoolBlock[index];
      if (index == 23)
        clsAppMarbleVars.varRuntime.WarmUpMillingDone = SystemBoolBlock[index];
      if (index == 24)
        clsAppMarbleVars.varRuntime.WarmUpSawDone = SystemBoolBlock[index];
      if (index == 25)
        Mach.runSystem.MachineLight = SystemBoolBlock[index];
      if (index == 26)
        Mach.runSystem.MaterialUpdate = SystemBoolBlock[index];
      if (index == 27)
        Mach.runSystem.ToolChanged = SystemBoolBlock[index];
      if (index == 28)
        Mach.runSystem.InstantMessageAvailable = SystemBoolBlock[index];
      if (index == 29)
        Mach.runSystem.AxesMessageAvailable = SystemBoolBlock[index];
      if (index == 30)
        clsAppMarbleVars.varRuntime.APositiveMoveNotAllow = SystemBoolBlock[index];
      if (index == 31 /*0x1F*/)
        clsAppMarbleVars.varRuntime.VacuumNotAllowDown = SystemBoolBlock[index];
    }
  }

  public void MarbleAuxBool2Conversion(bool[] SystemBoolBlock, ref CodesysMachine Mach)
  {
    if (SystemBoolBlock == null)
      return;
    for (int index = 0; index <= SystemBoolBlock.Length - 1; ++index)
    {
      if (index == 0 && clsAppMarbleVars.varRuntime.AxX >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bMaintananceAvailable = SystemBoolBlock[index];
      if (index == 1 && clsAppMarbleVars.varRuntime.AxY >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bMaintananceAvailable = SystemBoolBlock[index];
      if (index == 2 && clsAppMarbleVars.varRuntime.AxZ >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bMaintananceAvailable = SystemBoolBlock[index];
      if (index == 3 && clsAppMarbleVars.varRuntime.AxC >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bMaintananceAvailable = SystemBoolBlock[index];
      if (index == 4 && clsAppMarbleVars.varRuntime.AxA >= 0)
        Mach.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bMaintananceAvailable = SystemBoolBlock[index];
      if (index == 5)
        Mach.runSystem.MaintananceMachineClear = SystemBoolBlock[index];
      if (index == 6)
        Mach.runSystem.MaintananceAir = SystemBoolBlock[index];
      if (index == 7)
        Mach.runSystem.MaintananceCabinet = SystemBoolBlock[index];
      if (index == 8)
        Mach.runSystem.MaintananceHidroMotor = SystemBoolBlock[index];
      if (index == 9)
        Mach.runSystem.MaintananceLubricate = SystemBoolBlock[index];
      if (index == 10)
        clsAppMarbleVars.varRuntime.SpindleDiameterTooBigForMoveUp = SystemBoolBlock[index];
      if (index == 11)
        clsAppMarbleVars.varRuntime.ZLimitControlDisable = SystemBoolBlock[index];
      if (index == 12)
        ;
      if (index == 13)
        ;
      if (index == 14)
        ;
      if (index == 15)
        ;
      if (index == 16 /*0x10*/)
        ;
      if (index == 17)
        ;
      if (index == 18)
        ;
      if (index == 19)
        ;
      if (index == 20)
        ;
      if (index == 21)
        ;
      if (index == 22)
        ;
      if (index == 23)
        ;
      if (index == 24)
        ;
      if (index == 25)
        ;
      if (index == 26)
        ;
      if (index == 27)
        ;
      if (index == 28)
        ;
      if (index == 29)
        ;
      if (index == 30)
        ;
      if (index == 31 /*0x1F*/)
        ;
    }
  }

  public void MarbleAuxBool3Conversion(bool[] SystemBoolBlock, ref CodesysMachine Mach)
  {
    if (SystemBoolBlock == null)
      return;
    for (int index = 0; index <= SystemBoolBlock.Length - 1; ++index)
    {
      if (index == 0)
        ;
      if (index == 1)
        ;
      if (index == 2)
        ;
      if (index == 3)
        ;
      if (index == 4)
        ;
      if (index == 5)
        ;
      if (index == 6)
        ;
      if (index == 7)
        ;
      if (index == 8)
        ;
      if (index == 9)
        ;
      if (index == 10)
        ;
      if (index == 11)
        ;
      if (index == 12)
        ;
      if (index == 13)
        ;
      if (index == 14)
        ;
      if (index == 15)
        ;
      if (index == 16 /*0x10*/)
        ;
      if (index == 17)
        ;
      if (index == 18)
        ;
      if (index == 19)
        ;
      if (index == 20)
        ;
      if (index == 21)
        ;
      if (index == 22)
        ;
      if (index == 23)
        ;
      if (index == 24)
        ;
      if (index == 25)
        ;
      if (index == 26)
        ;
      if (index == 27)
        ;
      if (index == 28)
        ;
      if (index == 29)
        ;
      if (index == 30)
        ;
      if (index == 31 /*0x1F*/)
        ;
    }
  }

  protected virtual bool IsFileLocked(FileInfo file)
  {
    bool flag;
    try
    {
      using (FileStream fileStream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
        fileStream.Close();
    }
    catch (IOException ex)
    {
      flag = true;
      goto label_8;
    }
    flag = false;
label_8:
    return flag;
  }

  public void CheckMotionInfoMessages()
  {
    clsAppMarbleVars.cMachine.InfoList.Clear();
    clsAppMarbleVars.cMachine.runSystem.WarningLocalCount = 0;
    clsAppMarbleVars.cMachine.runSystem.InfoCount = 0;
    if (clsAppMarbleVars.cMachine.AlarmList.Count > 0)
    {
      for (int index = 0; index <= clsAppMarbleVars.cMachine.AlarmList.Count - 1; ++index)
      {
        AppAlarm alarm = clsAppMarbleVars.cMachine.AlarmList[index];
        clsAppMarbleVars.cMachine.InfoList.Add(new InfoType("", alarm.Text, Convert.ToInt32(alarm.Code), 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm));
      }
    }
    if (clsAppMarbleVars.cMachine.WarningList.Count > 0)
    {
      for (int index = 0; index <= clsAppMarbleVars.cMachine.WarningList.Count - 1; ++index)
      {
        AppWarning warning = clsAppMarbleVars.cMachine.WarningList[index];
        clsAppMarbleVars.cMachine.InfoList.Add(new InfoType("", warning.Text, Convert.ToInt32(warning.Code), 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning));
      }
    }
    if (buMarbleCalc.varOperation.MaterialParameter.MaterialThickness <= 0.01)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentences.MaterialThicknessIsZero, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (buMarbleCalc.varOperation.MaterialParameter.MaterialThickness > clsAppMarbleVars.varApp.MaterialMaxThickness)
    {
      InfoType infoType = new InfoType("", $"{buLangTranslate.preSentences.MaterialThicknessTooHigh} = {buMarbleCalc.varOperation.MaterialParameter.MaterialThickness.ToString()} > {clsAppMarbleVars.varApp.MaterialMaxThickness.ToString()}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (buMarbleCalc.varOperation.MaterialParameter.MaterialThickness < clsAppMarbleVars.varApp.MaterialMinThickness)
    {
      InfoType infoType = new InfoType("", $"{buLangTranslate.preSentences.MaterialThicknessTooLow} = {buMarbleCalc.varOperation.MaterialParameter.MaterialThickness.ToString()} < {clsAppMarbleVars.varApp.MaterialMinThickness.ToString()}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable)
    {
      if (clsAppMarbleVars.varApp.MillingLenMeasureMinLength > 0.0 & buMarbleCalc.activeToolMilling.Geometry.Length < clsAppMarbleVars.varApp.MillingLenMeasureMinLength)
      {
        InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Length}{buLangTranslate.preSentencesMarble.LowerThenAllowedLimit} = {buMarbleCalc.activeToolMilling.Geometry.Length.ToString("f2")} < {clsAppMarbleVars.varApp.MillingLenMeasureMinLength.ToString()}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, InfoTypeCodes.ToolLengthSmall, buLangTranslate.preDef.Milling, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      }
      if (clsAppMarbleVars.varApp.MillingLenMeasureMaxLength > 0.0 & buMarbleCalc.activeToolMilling.Geometry.Length > clsAppMarbleVars.varApp.MillingLenMeasureMaxLength)
      {
        InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Length}{buLangTranslate.preSentencesMarble.BiggerThenAllowedLimit} = {buMarbleCalc.activeToolMilling.Geometry.Length.ToString("f2")} > {clsAppMarbleVars.varApp.MillingLenMeasureMaxLength.ToString()}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, InfoTypeCodes.ToolLengthBig, buLangTranslate.preDef.Milling, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      }
    }
    if (buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable)
    {
      if (clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength > 0.0 & buMarbleCalc.activeToolMillingHead.Geometry.Length < clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength)
      {
        InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Length}{buLangTranslate.preSentencesMarble.LowerThenAllowedLimit} = {buMarbleCalc.activeToolMillingHead.Geometry.Length.ToString("f2")} < {clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength.ToString()}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, InfoTypeCodes.ToolLengthSmall, buLangTranslate.preDef.MillingHead, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      }
      if (clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength > 0.0 & buMarbleCalc.activeToolMillingHead.Geometry.Length > clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength)
      {
        InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Length}{buLangTranslate.preSentencesMarble.BiggerThenAllowedLimit} = {buMarbleCalc.activeToolMillingHead.Geometry.Length.ToString("f2")} > {clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength.ToString()}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, InfoTypeCodes.ToolLengthBig, buLangTranslate.preDef.MillingHead, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      }
    }
    if (clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter > 0.0 & buMarbleCalc.activeToolSaw.Geometry.Diameter < clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter)
    {
      InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Diameter}{buLangTranslate.preSentencesMarble.LowerThenAllowedLimit} = {buMarbleCalc.activeToolSaw.Geometry.Diameter.ToString("f2")} < {clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter.ToString()}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, InfoTypeCodes.ToolDiameterSmall, buLangTranslate.preDef.Saw, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
    }
    if (clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter > 0.0 & buMarbleCalc.activeToolSaw.Geometry.Diameter > clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter)
    {
      InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Diameter}{buLangTranslate.preSentencesMarble.BiggerThenAllowedLimit} = {buMarbleCalc.activeToolSaw.Geometry.Diameter.ToString("f2")} < {clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter.ToString()}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, InfoTypeCodes.ToolDiameterBig, buLangTranslate.preDef.Saw, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
    }
    if (AppBool.Offline)
    {
      clsAppMarbleVars.cMachine.InfoList.Add(new InfoType("", buLangTranslate.preMotionWarning.SystemOffline, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning)
      {
        ShowLabel = false
      });
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (AppBool.Offline)
      return;
    if (AppBool.DontWriteParameters)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preMotionMessage.ParameterWriteToPLCModeDisabled, 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
    }
    if (clsAppMarbleVars.cMachine.runSystem.InstantMessageAvailable)
      ;
    if (clsAppMarbleVars.varRuntime.SpindleDiameterTooBigForMoveUp)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preCaptionMarble.SpindleDiameterTooBigForSpindlePistonMoveUp, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.varRuntime.ZLimitControlDisable)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preCaptionMarble.ZTooZerolLimitControlDisabled, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (!clsAppMarbleVars.cMachine.runSystem.HomingDone)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preMotionWarning.HomingMissing, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.cMachine.runSystem.WagonUp)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentencesMarble.WagonUpPosition, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.cMachine.runSystem.FeedOverrideG1 <= 0.05)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentencesMarble.CuttingSpeedisZero, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.cMachine.runSystem.FeedOverrideG0 <= 0.05)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentencesMarble.ManuelSpeedisZero, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (!clsAppMarbleVars.varRuntime.WarmUpMillingDone)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentencesMarble.SpindleMotorNotWarmUp, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (!clsAppMarbleVars.varRuntime.WarmUpSawDone)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentencesMarble.SawMotorNotWarmUp, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.cMachine.runSystem.MaintananceAir)
    {
      InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.Air} {buLangTranslate.preDef.Maintanance}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.cMachine.runSystem.MaintananceCabinet)
    {
      InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.Cabinet} {buLangTranslate.preDef.Maintanance}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.cMachine.runSystem.MaintananceHidroMotor)
    {
      InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.Hydraulic} {buLangTranslate.preDef.Maintanance}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.cMachine.runSystem.MaintananceLubricate)
    {
      InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.Lubricate} {buLangTranslate.preDef.Maintanance}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.cMachine.runSystem.MaintananceMachineClear)
    {
      InfoType infoType = new InfoType("", $"{buLangTranslate.preDef.Machine} {buLangTranslate.preDef.Cleaning} {buLangTranslate.preDef.Maintanance}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (!clsAppMarbleVars.varInterface.MachineInstallationAxesCalib)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentences.MachineAxesCalibrationNotFinished, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (!clsAppMarbleVars.varInterface.MachineInstallationKinematic)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentences.MachineKinamaticCalibrationNotFinished, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (!clsAppMarbleVars.varInterface.MachineInstallationLimits)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentences.MachineLimitCalibrationNotFinished, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (!clsAppMarbleVars.varInterface.MachineInstallationPositions)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentences.MachinePositionCalibrationNotFinished, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (!clsAppMarbleVars.varInterface.MachineInstallationSpeeds)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentences.MachineSpeedCalibrationNotFinished, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (!clsAppMarbleVars.varInterface.MachineInstallationSpindle)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentences.MAchineSpindleCalibrationNotFinished, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
      ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
    }
    if (clsAppMarbleVars.cMachine.miscVar.ProgramParameterFailure)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentences.ProgramParameterLoadFailure, 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
    }
    if (clsAppMarbleVars.cMachine.miscVar.ProgramIOFailure)
    {
      InfoType infoType = new InfoType("", buLangTranslate.preSentences.ProgramInputOutputAddressLoadFailure, 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
      clsAppMarbleVars.cMachine.InfoList.Add(infoType);
    }
    if (clsAppMarbleVars.varRuntime.AxX >= 0)
    {
      CodesysAxis axisPar = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar;
      if (axisPar.Cnc.cncMaxFeed > axisPar.Sets.setMaxVelocity)
      {
        InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Max} {buLangTranslate.preChar.CNC} {buLangTranslate.preDef.Speed}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
        ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
      }
    }
    if (clsAppMarbleVars.varRuntime.AxY >= 0)
    {
      CodesysAxis axisPar = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar;
      if (axisPar.Cnc.cncMaxFeed > axisPar.Sets.setMaxVelocity)
      {
        InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Max} {buLangTranslate.preChar.CNC} {buLangTranslate.preDef.Speed}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
        ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
      }
    }
    if (clsAppMarbleVars.varRuntime.AxZ >= 0)
    {
      CodesysAxis axisPar = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar;
      if (clsAppMarbleVars.cMachine.runSystem.AxesMessageAvailable && axisPar.Runtime.Misc.AxisNotAllowMessage.Trim().Length > 0)
      {
        InfoType infoType = new InfoType("", axisPar.Runtime.Misc.AxisNotAllowMessage, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
        ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
      }
      if (axisPar.Cnc.cncMaxFeed > axisPar.Sets.setMaxVelocity)
      {
        InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Max} {buLangTranslate.preChar.CNC} {buLangTranslate.preDef.Speed}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
        ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
      }
    }
    if (clsAppMarbleVars.varRuntime.AxY2 >= 0 & buMarbleCalc.varMarbleMachineSettings.OptionSettings.ServoAxisY2)
    {
      CodesysAxis axisPar1 = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar;
      CodesysAxis axisPar2 = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar;
      if (clsAppMarbleVars.cMachine.runSystem.AxesMessageAvailable && axisPar1.Runtime.Misc.AxisNotAllowMessage.Trim().Length > 0)
      {
        InfoType infoType = new InfoType("", axisPar1.Runtime.Misc.AxisNotAllowMessage, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
        ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
      }
      if (!axisPar2.Sets.setGantryEnable)
      {
        InfoType infoType = new InfoType("", $"{axisPar2.Base.baseChar} {buLangTranslate.preMotionMessage.GantryisDisable}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
        ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
      }
      if (buMarbleCalc.varMarbleMachineSettings.OptionSettings.GantryY2Parallel)
      {
        if (axisPar1.Sets.setGantryNumerator > 0 & axisPar2.Sets.setGantryNumerator < 0)
        {
          InfoType infoType = new InfoType("", $"{axisPar1.Base.baseChar} {axisPar2.Base.baseChar} {buLangTranslate.preMotionMessage.GantryScaleRatiosareReverse}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
        if (axisPar1.Sets.setGantryNumerator < 0 & axisPar2.Sets.setGantryNumerator > 0)
        {
          InfoType infoType = new InfoType("", $"{axisPar1.Base.baseChar} {axisPar2.Base.baseChar} {buLangTranslate.preMotionMessage.GantryScaleRatiosareReverse}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
        if (!buCompare5.EQ((double) Math.Abs(axisPar1.Sets.setGantryNumerator), (double) Math.Abs(axisPar2.Sets.setGantryNumerator), 0.0001))
        {
          InfoType infoType = new InfoType("", $"{axisPar1.Base.baseChar} {axisPar2.Base.baseChar} {buLangTranslate.preMotionMessage.GantryScaleRatiosareDifferent}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
      }
      else
      {
        if (axisPar1.Sets.setGantryNumerator > 0 & axisPar2.Sets.setGantryNumerator > 0 && !buCompare5.EQ(axisPar1.Sets.setUnit + axisPar2.Sets.setUnit, 0.0, 1.0))
        {
          InfoType infoType = new InfoType("", $"{axisPar1.Base.baseChar} {axisPar2.Base.baseChar} {buLangTranslate.preMotionMessage.GantryScaleRatiosareReverse}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
        if (axisPar1.Sets.setGantryNumerator < 0 & axisPar2.Sets.setGantryNumerator < 0 && !buCompare5.EQ(axisPar1.Sets.setUnit + axisPar2.Sets.setUnit, 0.0, 1.0))
        {
          InfoType infoType = new InfoType("", $"{axisPar1.Base.baseChar} {axisPar2.Base.baseChar} {buLangTranslate.preMotionMessage.GantryScaleRatiosareReverse}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
        if (!buCompare5.EQ((double) Math.Abs(axisPar1.Sets.setGantryNumerator), (double) Math.Abs(axisPar2.Sets.setGantryNumerator), 0.0001))
        {
          InfoType infoType = new InfoType("", $"{axisPar1.Base.baseChar} {axisPar2.Base.baseChar} {buLangTranslate.preMotionMessage.GantryScaleRatiosareDifferent}", 0, 0.0, DateTime.Now, InfoTypeMode.Alarm, buMotionColors.clrAlarm);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
      }
    }
    for (int index = 0; index <= clsAppMarbleVars.cMachine.AppAxis.Count - 1; ++index)
    {
      CodesysAxis axisPar = clsAppMarbleVars.cMachine.AppAxis[index].AxisPar;
      bool flag = true;
      if (clsAppMarbleVars.cMachine.runSystem.AxesMessageAvailable && axisPar.Runtime.Misc.AxisNotAllowMessage.Trim().Length > 0)
      {
        InfoType infoType = new InfoType($"{axisPar.Base.baseChar} - {buLangTranslate.preDef.Axis} ", axisPar.Runtime.Misc.AxisNotAllowMessage, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
        clsAppMarbleVars.cMachine.InfoList.Add(infoType);
        ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
      }
      if (axisPar.Base.baseChar == "A" & !clsAppMarbleVars.varApp.OptionServoAxisA)
        flag = false;
      if (axisPar.Base.baseChar == "Y2")
        flag = false;
      if (!axisPar.Sets.setGantryEnable & axisPar.Base.baseEnable & axisPar.Base.baseChar.Length > 0 & flag)
      {
        if (!axisPar.Sets.setSoftLimitEnable)
        {
          InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preMotionMessage.SoftwareLimitDisable}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
        else
        {
          if (axisPar.Runtime.Actual.actualPosition < axisPar.Sets.setSoftLimitNegative)
          {
            InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preMotionMessage.AxisOutofNegativeLimit} {axisPar.Runtime.Actual.actualPosition.ToString("f2")} < {axisPar.Sets.setSoftLimitNegative.ToString("f2")}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
            clsAppMarbleVars.cMachine.InfoList.Add(infoType);
            ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
          }
          if (axisPar.Runtime.Actual.actualPosition > axisPar.Sets.setSoftLimitPositive)
          {
            InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preMotionMessage.AxisOutofPositiveLimit} {axisPar.Runtime.Actual.actualPosition.ToString("f2")} > {axisPar.Sets.setSoftLimitPositive.ToString("f2")}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
            clsAppMarbleVars.cMachine.InfoList.Add(infoType);
            ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
          }
        }
        if (!axisPar.Jogs.jogWithAbsoluteMove)
        {
          InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preMotionMessage.JogLimitDisable}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
        if (buCompare5.EQ(axisPar.Sets.setDataLimitNegative, axisPar.Sets.setDataLimitPositive, 0.1))
        {
          InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preMotionMessage.DataLimitsValueAreNotCorrect}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
        }
        else if (axisPar.Sets.setDataLimitNegative > axisPar.Sets.setDataLimitPositive)
        {
          InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preMotionMessage.DataLimitsValueAreNotCorrect}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
        if (axisPar.Sets.setDataLimitNegative < axisPar.Sets.setSoftLimitNegative & axisPar.Sets.setSoftLimitEnable)
        {
          InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preMotionMessage.DataLimitsLowerThenSoftwareLimit}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
        if (axisPar.Sets.setDataLimitPositive > axisPar.Sets.setSoftLimitPositive & axisPar.Sets.setSoftLimitEnable)
        {
          InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preMotionMessage.DataLimitsHigherThenSoftwareLimit}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
        if (axisPar.Runtime.Bool.bMaintananceAvailable)
        {
          InfoType infoType = new InfoType("", $"{axisPar.Base.baseChar} {buLangTranslate.preDef.Maintanance}", 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
          clsAppMarbleVars.cMachine.InfoList.Add(infoType);
          ++clsAppMarbleVars.cMachine.runSystem.WarningLocalCount;
        }
      }
    }
    if (clsAppMarbleVars.cMachine.runSystem.SimulatedAxes)
    {
      InfoType infoType1 = new InfoType("", buLangTranslate.preMotionWarning.AxisinSimulationMode, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
    }
    if (!clsAppMarbleVars.cMachine.runSystem.SimulatedIO)
      return;
    InfoType infoType2 = new InfoType("", buLangTranslate.preMotionWarning.IOinSimulationMode, 0, 0.0, DateTime.Now, InfoTypeMode.Warning, buMotionColors.clrWarning);
  }

  public void ShowScreenCaptureSeperators()
  {
    int sc5Width = buMarbleCalc.varMarbleSettings.ScreenCapture.SC5Width;
    int sc5Height = buMarbleCalc.varMarbleSettings.ScreenCapture.SC5Height;
    int sc5Left = buMarbleCalc.varMarbleSettings.ScreenCapture.SC5Left;
    int sc5Top = buMarbleCalc.varMarbleSettings.ScreenCapture.SC5Top;
    clsAppMarbleItems.spr_camerapos1.Left = sc5Left - 5;
    clsAppMarbleItems.spr_camerapos1.Top = sc5Top - 5;
    clsAppMarbleItems.spr_camerapos1.Width = sc5Width + 10;
    clsAppMarbleItems.spr_camerapos1.Height = 5;
    clsAppMarbleItems.spr_camerapos2.Left = sc5Left - 5;
    clsAppMarbleItems.spr_camerapos2.Top = sc5Top - 5;
    clsAppMarbleItems.spr_camerapos2.Width = 5;
    clsAppMarbleItems.spr_camerapos2.Height = sc5Height + 10;
    clsAppMarbleItems.spr_camerapos3.Left = sc5Left - 5;
    clsAppMarbleItems.spr_camerapos3.Top = sc5Top + sc5Height + 5;
    clsAppMarbleItems.spr_camerapos3.Width = sc5Width + 10;
    clsAppMarbleItems.spr_camerapos3.Height = 5;
    clsAppMarbleControls.spr_camerapos4.Left = sc5Left + sc5Width + 5;
    clsAppMarbleControls.spr_camerapos4.Top = sc5Top - 5;
    clsAppMarbleControls.spr_camerapos4.Width = 5;
    clsAppMarbleControls.spr_camerapos4.Height = sc5Height + 10;
    clsAppMarbleItems.spr_camerapos1.BringToFront();
    clsAppMarbleItems.spr_camerapos1.Visible = true;
    clsAppMarbleItems.spr_camerapos2.BringToFront();
    clsAppMarbleItems.spr_camerapos2.Visible = true;
    clsAppMarbleItems.spr_camerapos3.BringToFront();
    clsAppMarbleItems.spr_camerapos3.Visible = true;
    clsAppMarbleControls.spr_camerapos4.BringToFront();
    clsAppMarbleControls.spr_camerapos4.Visible = true;
    MarbleTempVars.CameraFrameShowed = true;
  }

  public void HideScreenCaptureSeperators()
  {
    clsAppMarbleItems.spr_camerapos1.Visible = false;
    clsAppMarbleItems.spr_camerapos2.Visible = false;
    clsAppMarbleItems.spr_camerapos3.Visible = false;
    clsAppMarbleControls.spr_camerapos4.Visible = false;
    MarbleTempVars.CameraFrameShowed = false;
  }

  public void cmdStart()
  {
    string callMethod = nameof (cmdStart);
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.Start");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Ok", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdStop()
  {
    string callMethod = nameof (cmdStop);
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeDINTVar(CodesysVariableBaseType.Global, 5, "sysRun.stpSteps.Stop");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Ok", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdPause(bool Pause)
  {
    string callMethod = nameof (cmdPause);
    try
    {
      if (!AppBool.Connected)
        return;
      if (Pause)
        this.writeDINTVar(CodesysVariableBaseType.Global, 5, "sysRun.stpSteps.Pause");
      else
        this.writeBOOLVar(CodesysVariableBaseType.Global, false, "sysRun.boolData.bPause");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", Pause.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdPark()
  {
    string callMethod = nameof (cmdPark);
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.Park");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Ok", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdSpindlePark()
  {
    string callMethod = nameof (cmdSpindlePark);
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.SpindlePark");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Ok", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdSawPark()
  {
    string callMethod = nameof (cmdSawPark);
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.SawPark");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Ok", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdCameraPark()
  {
    string callMethod = nameof (cmdCameraPark);
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.CameraPark");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Ok", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdVagonPark()
  {
    string callMethod = nameof (cmdVagonPark);
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.VagonPark");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Ok", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdHoming()
  {
    string callMethod = nameof (cmdHoming);
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.Homing");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Ok", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdWaterOnOff(bool State)
  {
    string callMethod = nameof (cmdWaterOnOff);
    try
    {
      if (!AppBool.Connected)
        return;
      if (State)
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.WaterOn");
      else
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.WaterOff");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", State.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdLaserOnOff(bool State)
  {
    string callMethod = nameof (cmdLaserOnOff);
    try
    {
      if (!AppBool.Connected)
        return;
      if (State)
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.LaserOn");
      else
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.LaserOff");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", State.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdVagonUpDown(bool Up)
  {
    string callMethod = nameof (cmdVagonUpDown);
    try
    {
      if (!AppBool.Connected)
        return;
      if (Up)
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.VagonUp");
      else
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.VagonDown");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", Up.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdSpindlePensOpenClose(bool Open)
  {
    string callMethod = nameof (cmdSpindlePensOpenClose);
    try
    {
      if (!AppBool.Connected)
        return;
      if (Open)
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ToolPensOpen");
      else
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ToolPensClose");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", Open.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdToolMagazineOpenClose(bool Open)
  {
    string callMethod = nameof (cmdToolMagazineOpenClose);
    try
    {
      if (!AppBool.Connected)
        return;
      if (Open)
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ToolMagazineOpen");
      else
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ToolMagazineClose");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", Open.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdToolCoverOpenClose(bool Open)
  {
    string callMethod = nameof (cmdToolCoverOpenClose);
    try
    {
      if (!AppBool.Connected)
        return;
      if (Open)
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ToolCoverOpen");
      else
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ToolCoverOpenClose");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", Open.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdToolUpDown(bool Up)
  {
    string callMethod = nameof (cmdToolUpDown);
    try
    {
      if (!AppBool.Connected)
        return;
      if (Up)
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ToolUp");
      else
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ToolDown");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", Up.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdSpindleStartStop(bool State, double SpindleSpeed, double SpindleSpeedOverride = 100.0)
  {
    string callMethod = nameof (cmdSpindleStartStop);
    try
    {
      if (!State)
      {
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.SpindleStop");
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SpindleStop");
      }
      else
      {
        this.ToolSelect((MarbleToolType) 1);
        if (!clsAppMarbleVars.varApp.SpindlePersentageFromPLC)
          this.writeLREALVar(CodesysVariableBaseType.Persistent, SpindleSpeedOverride, "sysSet.Spindle.SpindleOverride");
        this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.SpindleSpeedUpdate");
        this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.SpindleForward");
        this.writeLREALVar(CodesysVariableBaseType.Global, SpindleSpeed, "AppRun.VelSpindle");
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.SpindleStart");
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SpindleStart");
      }
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", $"{State.ToString()} , {SpindleSpeed.ToString()} , {SpindleSpeedOverride.ToString()}", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdSawStartStop(bool State, double SawSpeed, double SawSpeedOverride = 100.0)
  {
    string callMethod = nameof (cmdSawStartStop);
    try
    {
      if (!State)
      {
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SawStop");
      }
      else
      {
        this.ToolSelect((MarbleToolType) 0);
        if (!clsAppMarbleVars.varApp.SpindlePersentageFromPLC)
          this.writeLREALVar(CodesysVariableBaseType.Global, SawSpeedOverride, "AppRun.SawOverride");
        this.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppRun.SawSpeedUpdate");
        this.writeLREALVar(CodesysVariableBaseType.Global, SawSpeed, "AppRun.VelSaw");
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "stpCase.SawStart");
      }
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", $"{State.ToString()} , {SawSpeed.ToString()} , {SawSpeedOverride.ToString()}", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdCMZSBDBridge()
  {
    string callMethod = "cmdCMZSbdBridge";
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.StartCMZBridge");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "", "", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdRtcpEnableDisable(bool Enable)
  {
    string callMethod = nameof (cmdRtcpEnableDisable);
    try
    {
      if (!AppBool.Connected)
        return;
      if (Enable)
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.RtcpEnable");
      else
        this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.RtcpDisable");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", Enable.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void cmdClosePC()
  {
    string callMethod = nameof (cmdClosePC);
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.boolData.bShotdownSystem");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Ok", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void ShowKinematic()
  {
    string callMethod = nameof (ShowKinematic);
    try
    {
      if (AppSecurity.PasswordLevel < 1)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (clsAppMarbleItems.frmKinematic == null)
          clsAppMarbleItems.frmKinematic = new F_MarbleKinematic();
        clsAppMarbleItems.frmKinematic.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmKinematic.Kinematic = new KinematicBase5(clsMarble.activeKinematic);
        clsAppMarbleItems.frmKinematic.Init();
        clsAppMarbleItems.frmKinematic.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmKinematic.ShowDialog((IWin32Window) clsItem.FrmMain);
        if (clsAppMarbleItems.frmKinematic.PropertiesForm.Result == DialogResult.OK)
        {
          clsMarble.activeKinematic = new KinematicBase5(clsAppMarbleItems.frmKinematic.Kinematic);
          ccVars.KinematicOrjinal = new KinematicBase5(clsAppMarbleItems.frmKinematic.Kinematic);
          buFile5.SaveKinematicFile(AppPath.MachineKinematic + "\\Kinematic5Axis.bukinematic", clsMarble.activeKinematic);
          clsInit.cMarble.JobCamCalculatedReset(true, true, true, -1, ref clsInit.appMarble.activeJob);
        }
        if (buMarbleCalc.varMarbleMachineSettings.SimulationSettings.DrawHead | buMarbleCalc.varMarbleMachineSettings.SimulationSettings.DrawSawTool)
        {
          this.DeleteSimulationEntities();
          this.DrawSimulationEntities(false, true, true, true, false);
        }
        if (!AppBool.Connected)
          return;
        KinematicBase Kinematic = new KinematicBase();
        KinematicBase5.Copy(clsMarble.activeKinematic, ref Kinematic);
        clsAppMarbleVars.cMachine.Commands.WriteKinematicData(CodesysMachine.RootPersistentString + "Kinematic.", Kinematic);
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowCalibration()
  {
    string callMethod = nameof (ShowCalibration);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (clsAppMarbleItems.frmMachineCalibration == null)
          clsAppMarbleItems.frmMachineCalibration = new F_MarbleMachineInstall();
        clsAppMarbleItems.frmMachineCalibration.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmMachineCalibration.Init(0);
        clsAppMarbleItems.frmMachineCalibration.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmMachineCalibration.ShowDialog((IWin32Window) clsItem.FrmMain);
        if (clsAppMarbleItems.frmMachineCalibration.PropertiesForm.Result == DialogResult.OK)
          clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
        this.MachineMinMaxPoints();
        this.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowGantryMove()
  {
    string callMethod = nameof (ShowGantryMove);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (clsAppMarbleItems.frmGantryMoveV1 == null)
          clsAppMarbleItems.frmGantryMoveV1 = new F_MarbleGantryMove();
        clsAppMarbleItems.frmGantryMoveV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmGantryMoveV1.Init();
        clsAppMarbleItems.frmGantryMoveV1.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmGantryMoveV1.ShowDialog((IWin32Window) clsItem.FrmMain);
        if (clsAppMarbleItems.frmGantryMoveV1.PropertiesForm.Result == DialogResult.OK)
          ;
        this.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowTools(int ToolIndex)
  {
    string callMethod = nameof (ShowTools);
    try
    {
      if (clsAppMarbleItems.frmToolCurrent == null)
        clsAppMarbleItems.frmToolCurrent = new F_MarbleToolCurrentAll();
      clsAppMarbleItems.frmToolCurrent.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmToolCurrent.Init();
      switch (ToolIndex)
      {
        case 0:
          clsAppMarbleItems.frmToolCurrent.buTab_tools.SelectedIndex = 0;
          ((F_MarbleMachineSettingsV2) clsAppMarbleItems.frmToolCurrent).MenuButtonColors(ToolIndex);
          break;
        case 1:
          clsAppMarbleItems.frmToolCurrent.buTab_tools.SelectedIndex = 1;
          ((F_MarbleMachineSettingsV2) clsAppMarbleItems.frmToolCurrent).MenuButtonColors(ToolIndex);
          break;
        case 2:
          clsAppMarbleItems.frmToolCurrent.buTab_tools.SelectedIndex = 2;
          ((F_MarbleMachineSettingsV2) clsAppMarbleItems.frmToolCurrent).MenuButtonColors(ToolIndex);
          break;
      }
      clsAppMarbleItems.frmToolCurrent.StartPosition = FormStartPosition.CenterParent;
      int num = (int) clsAppMarbleItems.frmToolCurrent.ShowDialog();
      if (clsAppMarbleItems.frmToolCurrent.PropertiesForm.Result != DialogResult.OK)
        return;
      buMarbleCalc.activeToolMilling.Purpose = ToolPurpose.Milling;
      buMarbleCalc.activeToolSaw.Purpose = ToolPurpose.Saw;
      buMarbleCalc.activeToolMillingHead.Purpose = ToolPurpose.MillingHead;
      if (AppBool.Connected)
        this.writeLREALVar(CodesysVariableBaseType.Global, 0.0, "AppRun.ZLimitDisableExtraLimit");
      clsInit.appMarble.SaveMarbleFile();
      this.ToolUpdateOnScreen();
      this.SaveParameterUser();
      if (buMarbleCalc.varMarbleMachineSettings.SimulationSettings.DrawHead | buMarbleCalc.varMarbleMachineSettings.SimulationSettings.DrawSawTool)
      {
        this.DeleteSimulationEntities();
        this.DrawSimulationEntities(false, true, true, true, false);
      }
      if (!AppBool.Connected)
        return;
      clsAppMarbleVars.cMachine.bWriteToolParameter = true;
      clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowMachineSettingsV1(int Index)
  {
    string callMethod = "ShowMachineSettings";
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (clsAppMarbleItems.frmMachineSettingsV1 == null)
          clsAppMarbleItems.frmMachineSettingsV1 = new F_MarbleMachineSettingsV1();
        clsAppMarbleItems.frmMachineSettingsV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmMachineSettingsV1.Init(Index);
        clsAppMarbleItems.frmMachineSettingsV1.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmMachineSettingsV1.ShowDialog((IWin32Window) clsItem.FrmMain);
        if (clsAppMarbleItems.frmMachineSettingsV1.PropertiesForm.Result == DialogResult.OK)
          clsAppMarbleVars.cMachine.bWriteAppParameter = true;
        this.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowMachineSettingsV2(int Index)
  {
    string callMethod = nameof (ShowMachineSettingsV2);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (clsAppMarbleItems.frmMachineSettingsV2 == null)
          clsAppMarbleItems.frmMachineSettingsV2 = new F_MarbleMachineSettingsV2();
        clsAppMarbleItems.frmMachineSettingsV2.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmMachineSettingsV2.Init(Index);
        clsAppMarbleItems.frmMachineSettingsV2.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmMachineSettingsV2.ShowDialog((IWin32Window) clsItem.FrmMain);
        if (clsAppMarbleItems.frmMachineSettingsV2.PropertiesForm.Result == DialogResult.OK)
        {
          if (buMarbleCalc.varMarbleMachineSettings.OptionSettings.TechnicianReportEnable)
          {
            // ISSUE: reference to a compiler-generated method
            Task.Run(new Action(((clsAppMarble.\u003C\u003Ec) this).\u0001));
          }
          clsAppMarbleVars.cMachine.bWriteAppParameter = true;
          clsAppMarbleVars.cMachine.bWriteToolParameter = true;
        }
        this.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public (int, int, int, MarbleToolType) ShowToolsList(
    MarbleToolListMode Mode,
    MarbleToolType ToolType)
  {
    // ISSUE: unable to decompile the method.
  }

  public DialogResult ShowToolsEdit(bool isSaw, ref ToolBase5 Tool)
  {
    string callMethod = nameof (ShowToolsEdit);
    try
    {
      if (AppSecurity.PasswordLevel < 1)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
        }
        return DialogResult.Cancel;
      }
      if (AppBool.Connected)
      {
        if (clsAppMarbleVars.cMachine.runSystem.Run)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
          {
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
          }
          return DialogResult.Cancel;
        }
        if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
          {
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
          }
          return DialogResult.Cancel;
        }
      }
      if (!isSaw)
      {
        if (clsAppMarbleItems.frmToolType == null)
          clsAppMarbleItems.frmToolType = new F_MarbleToolTypes();
        ((\u0002.\u0001.\u0001) clsAppMarbleItems.frmToolType).pnl_preview.Controls.Clear();
        ((\u0002.\u0001.\u0001) clsAppMarbleItems.frmToolType).pnl_preview.Controls.Add((System.Windows.Forms.Control) buEyeItems.viewportDialogs);
        clsAppMarbleItems.frmToolType.Tool = new ToolBase5(Tool);
        clsAppMarbleItems.frmToolType.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmToolType.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmToolType.Init();
        int num = (int) clsAppMarbleItems.frmToolType.ShowDialog();
        ((\u0002.\u0001.\u0001) clsAppMarbleItems.frmToolType).pnl_preview.Controls.Clear();
        if (clsAppMarbleItems.frmToolType.PropertiesForm.Result == DialogResult.OK)
        {
          this.SaveParameterUser();
          Tool = new ToolBase5(clsAppMarbleItems.frmToolType.Tool);
          return DialogResult.OK;
        }
      }
      else
      {
        if (clsAppMarbleItems.frmToolSawType == null)
          clsAppMarbleItems.frmToolSawType = new F_MarbleToolSawTypes();
        ((F_MarbleMDIV1) clsAppMarbleItems.frmToolSawType).pnl_preview.Controls.Clear();
        ((F_MarbleMDIV1) clsAppMarbleItems.frmToolSawType).pnl_preview.Controls.Add((System.Windows.Forms.Control) buEyeItems.viewportDialogs);
        ((F_MarbleUserList) clsAppMarbleItems.frmToolSawType).Tool = new ToolBase5(Tool);
        clsAppMarbleItems.frmToolSawType.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmToolSawType.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmToolSawType.Init();
        int num = (int) clsAppMarbleItems.frmToolSawType.ShowDialog();
        ((F_MarbleMDIV1) clsAppMarbleItems.frmToolSawType).pnl_preview.Controls.Clear();
        if (clsAppMarbleItems.frmToolSawType.PropertiesForm.Result == DialogResult.OK)
        {
          this.SaveParameterUser();
          Tool = new ToolBase5(((F_MarbleUserList) clsAppMarbleItems.frmToolSawType).Tool);
          return DialogResult.OK;
        }
      }
      return DialogResult.Cancel;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return DialogResult.Cancel;
    }
  }

  public void ShowCircularGeometrySettings()
  {
    string callMethod = "ShowCircularSettings";
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (buMarbleForms.frmCircularGeometySettings == null)
          buMarbleForms.frmCircularGeometySettings = new F_MarbleCircularShapeResolution();
        buMarbleForms.frmCircularGeometySettings.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        buMarbleForms.frmCircularGeometySettings.Init();
        buMarbleForms.frmCircularGeometySettings.StartPosition = FormStartPosition.CenterParent;
        int num = (int) buMarbleForms.frmCircularGeometySettings.ShowDialog((IWin32Window) clsItem.FrmMain);
        if (buMarbleForms.frmCircularGeometySettings.PropertiesForm.Result != DialogResult.OK)
          return;
        clsInit.appMarble.SaveMarbleFile();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowCircularSpeeds()
  {
    string callMethod = nameof (ShowCircularSpeeds);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (buMarbleForms.frmCircularSpeeds == null)
          buMarbleForms.frmCircularSpeeds = new F_MarbleCircularSpeed();
        buMarbleForms.frmCircularSpeeds.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        buMarbleForms.frmCircularSpeeds.Init();
        buMarbleForms.frmCircularSpeeds.StartPosition = FormStartPosition.CenterParent;
        int num = (int) buMarbleForms.frmCircularSpeeds.ShowDialog((IWin32Window) clsItem.FrmMain);
        if (buMarbleForms.frmCircularSpeeds.PropertiesForm.Result != DialogResult.OK)
          return;
        clsInit.appMarble.SaveMarbleFile();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowCamSettings()
  {
    string callMethod = nameof (ShowCamSettings);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        clsInit.appMarble.cmdCamSettingsPage();
        clsAppMarbleVars.varApp.OptionServoAxisA = buMarbleCalc.varMarbleMachineSettings.OptionSettings.ServoAxisA;
        clsAppMarbleVars.varApp.OptionAllAbsoluteEncoder = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AllAbsoluteEncoder;
        clsAppMarbleVars.varApp.OptionAutoToolChanger = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger;
        clsAppMarbleVars.varApp.OptionCameraEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable;
        clsAppMarbleVars.varApp.OptionDigitalInputCount = buMarbleCalc.varMarbleMachineSettings.OptionSettings.DigitalInputCount;
        clsAppMarbleVars.varApp.OptionDigitalOutputCount = buMarbleCalc.varMarbleMachineSettings.OptionSettings.DigitalOutputCount;
        clsAppMarbleVars.varApp.OptionGantryY2Parallel = buMarbleCalc.varMarbleMachineSettings.OptionSettings.GantryY2Parallel;
        clsAppMarbleVars.varApp.OptionServoAxisY2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.ServoAxisY2;
        clsAppMarbleVars.varApp.OptionSlabThicknessEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.SlabThicknessEnable;
        clsAppMarbleVars.varApp.OptionSpindleEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
        clsAppMarbleVars.varApp.OptionToolMeasureEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.ToolMeasureEnable;
        clsAppMarbleVars.varApp.OptionVacuumEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.VacuumEnable;
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowWagonSettings()
  {
    string callMethod = nameof (ShowWagonSettings);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (clsAppMarbleItems.frmWagonSettings == null)
          clsAppMarbleItems.frmWagonSettings = new F_MarbleWagonSettings();
        ((\u0007.\u0001) clsAppMarbleItems.frmWagonSettings).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmWagonSettings.Init();
        clsAppMarbleItems.frmWagonSettings.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmWagonSettings.ShowDialog((IWin32Window) clsItem.FrmMain);
        if (((\u0007.\u0001) clsAppMarbleItems.frmWagonSettings).PropertiesForm.Result == DialogResult.OK)
          clsAppMarbleVars.cMachine.bWriteAppParameter = true;
        this.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowCameraSettings()
  {
    string callMethod = nameof (ShowCameraSettings);
    try
    {
      if (AppSecurity.PasswordLevel < 1)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (clsAppMarbleItems.frmCameraSettings == null)
          clsAppMarbleItems.frmCameraSettings = new F_MarbleCameraSettings();
        clsAppMarbleItems.frmCameraSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmCameraSettings.Init();
        clsAppMarbleItems.frmCameraSettings.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmCameraSettings.ShowDialog((IWin32Window) clsItem.FrmMain);
        if (clsAppMarbleItems.frmCameraSettings.PropertiesForm.Result == DialogResult.OK)
          clsAppMarbleVars.cMachine.bWriteAppParameter = true;
        this.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowCameraCalibration()
  {
    string callMethod = nameof (ShowCameraCalibration);
    try
    {
      if (AppSecurity.PasswordLevel < 1)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.cMachine.runSystem.Run)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
            return;
          }
          if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
              return;
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
            return;
          }
        }
        if (clsAppMarbleItems.frmCameraCalibration == null)
          clsAppMarbleItems.frmCameraCalibration = new F_MarblePhotoCalibration();
        clsAppMarbleItems.frmCameraCalibration.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmCameraCalibration.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmCameraCalibration.Init();
        int num = (int) clsAppMarbleItems.frmCameraCalibration.ShowDialog();
        if (clsAppMarbleItems.frmCameraCalibration.PropertiesForm.Result != DialogResult.OK)
          return;
        this.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowGantySettings()
  {
    string callMethod = nameof (ShowGantySettings);
    try
    {
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowMachineSettings()
  {
    string callMethod = nameof (ShowMachineSettings);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        clsAppMarbleItems.frmSettings.Classes = new List<object>();
        clsAppMarbleItems.frmSettings.CaptionHeader.Clear();
        for (int index = 0; index <= clsAppMarbleVars.cMachine.AppAxis.Count - 1; ++index)
        {
          clsAppMarbleItems.frmSettings.CaptionHeader.Add($"{clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Base.baseChar} {buLangTranslate.preDef.Axis} - {buLangTranslate.preDef.Setting}");
          CodesysAxis codesysAxis1 = new CodesysAxis();
          CodesysAxis codesysAxis2 = new CodesysAxis(clsAppMarbleVars.cMachine.AppAxis[index].AxisPar);
          clsAppMarbleItems.frmSettings.Classes.Add((object) codesysAxis2);
        }
        clsAppMarbleItems.frmSettings.Classes.Add((object) new CodesysCNCSets(clsAppMarbleVars.cMachine.varCNC));
        clsAppMarbleItems.frmSettings.Classes.Add((object) new clsAppMarbleIODef(clsAppMarbleVars.varApp));
        clsAppMarbleItems.frmSettings.Classes.Add((object) new PlcDeviceData(clsAppMarbleVars.cMachine.PLCSettings));
        clsAppMarbleItems.frmSettings.Classes.Add((object) new setMotionProgramVar(clsAppMarbleVars.cMachine.ProgramSettings));
        clsAppMarbleItems.frmSettings.Classes.Add((object) new HandWheelSettings(clsAppMarbleVars.cMachine.varHandWheel));
        clsAppMarbleItems.frmSettings.Classes.Add((object) new JogSettings(clsAppMarbleVars.cMachine.varJog));
        clsAppMarbleItems.frmSettings.Classes.Add((object) new CodesysSystemSets(clsAppMarbleVars.cMachine.varSystem));
        clsAppMarbleItems.frmSettings.Classes.Add((object) new clsAppMarbleMachineReportItem(clsAppMarbleVars.varInterface));
        clsAppMarbleItems.frmSettings.Classes.Add((object) new AlarmActionSettings(clsAppMarbleVars.cMachine.varAlarmActions));
        clsAppMarbleItems.frmSettings.Init();
        clsAppMarbleItems.frmSettings.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmSettings.ShowDialog((IWin32Window) clsAppMarbleItems.frmMain);
        if (clsAppMarbleItems.frmSettings.Result != DialogResult.OK)
          return;
        this.ApplySettings();
        this.MachineMinMaxPoints();
        this.ClickCommand((MarbleMotionCommands) 57);
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowMiscSettings()
  {
    string callMethod = nameof (ShowMiscSettings);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (clsAppMarbleItems.frmSettingsMisc == null)
          clsAppMarbleItems.frmSettingsMisc = new F_SettingsTreeView();
        clsAppMarbleItems.frmSettingsMisc.CaptionHeader.Clear();
        clsAppMarbleItems.frmSettingsMisc.Classes = new List<object>();
        clsAppMarbleItems.frmSettingsMisc.Classes.Add((object) new clsAppMarbleInterfaceVar(clsAppMarbleVars.varForms));
        clsAppMarbleItems.frmSettingsMisc.Classes.Add((object) new clsAppMarbleMachineReportItem(clsAppMarbleVars.varInterface));
        clsAppMarbleItems.frmSettingsMisc.Init();
        clsAppMarbleItems.frmSettingsMisc.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmSettingsMisc.ShowDialog((IWin32Window) clsAppMarbleItems.frmMain);
        if (clsAppMarbleItems.frmSettingsMisc.Result != DialogResult.OK)
          return;
        this.ApplySettingsMisc();
        this.ClickCommand((MarbleMotionCommands) 57);
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowMachineDefinationSettings()
  {
    string callMethod = nameof (ShowMachineDefinationSettings);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (clsAppMarbleItems.frmMachineDefination == null)
          clsAppMarbleItems.frmMachineDefination = new F_MarbleMachineDef();
        clsAppMarbleItems.frmMachineDefination.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmMachineDefination.txt_machinename.Text = clsVar.appDefination.MachineName;
        clsAppMarbleItems.frmMachineDefination.txt_machineno.Text = clsVar.appDefination.MachineNo;
        clsAppMarbleItems.frmMachineDefination.txt_machineserial.Text = clsVar.appDefination.MachineSerial;
        clsAppMarbleItems.frmMachineDefination.Init();
        clsAppMarbleItems.frmMachineDefination.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmMachineDefination.ShowDialog();
        if (clsAppMarbleItems.frmMachineDefination.PropertiesForm.Result != DialogResult.OK)
          return;
        clsVar.appDefination.MachineName = clsAppMarbleItems.frmMachineDefination.txt_machinename.Text;
        clsVar.appDefination.MachineNo = clsAppMarbleItems.frmMachineDefination.txt_machineno.Text;
        clsVar.appDefination.MachineSerial = clsAppMarbleItems.frmMachineDefination.txt_machineserial.Text;
        this.SaveUserDll();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public int ShowG54List()
  {
    string callMethod = nameof (ShowG54List);
    try
    {
      if (AppSecurity.PasswordLevel < 1)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
        }
        return -1;
      }
      if (AppBool.Connected)
      {
        if (clsAppMarbleVars.cMachine.runSystem.Run)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
          {
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
          }
          return -1;
        }
        if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
          {
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
          }
          return -1;
        }
      }
      if (clsAppMarbleItems.frmG54List == null)
        clsAppMarbleItems.frmG54List = new F_MarbleG54List();
      ((F_MarbleToolListTab) clsAppMarbleItems.frmG54List).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      ((F_MarbleToolListTab) clsAppMarbleItems.frmG54List).G54s.Clear();
      for (int index = 0; index <= clsAppMarbleVars.cMachine.G54List.Length - 1; ++index)
        ((F_MarbleToolListTab) clsAppMarbleItems.frmG54List).G54s.Add(new Pnt9DS(clsAppMarbleVars.cMachine.G54List[index]));
      ((F_MarbleToolListTab) clsAppMarbleItems.frmG54List).indexG54 = clsAppMarbleVars.varInterface.IndexG54;
      clsAppMarbleItems.frmG54List.Init();
      clsAppMarbleItems.frmG54List.StartPosition = FormStartPosition.CenterParent;
      int num = (int) clsAppMarbleItems.frmG54List.ShowDialog((IWin32Window) clsItem.FrmMain);
      if (((F_MarbleToolListTab) clsAppMarbleItems.frmG54List).PropertiesForm.Result != DialogResult.OK)
        return -1;
      clsAppMarbleVars.varInterface.IndexG54 = ((F_MarbleToolListTab) clsAppMarbleItems.frmG54List).indexG54;
      for (int index = 1; index <= ((F_MarbleToolListTab) clsAppMarbleItems.frmG54List).G54s.Count - 1; ++index)
      {
        if (index <= clsAppMarbleVars.cMachine.G54List.Length - 1)
          clsAppMarbleVars.cMachine.G54List[index] = new Pnt9DS(((F_MarbleToolListTab) clsAppMarbleItems.frmG54List).G54s[index]);
      }
      if (clsAppMarbleVars.varInterface.IndexG54 >= 0)
        clsAppMarbleVars.cMachine.G54List[0] = ((F_MarbleToolListTab) clsAppMarbleItems.frmG54List).G54s[clsAppMarbleVars.varInterface.IndexG54];
      this.SaveParameterUser();
      this.SaveParameterInterface();
      if (AppBool.Connected)
        clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
      return clsAppMarbleVars.varInterface.IndexG54;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return -1;
    }
  }

  public int ShowParkList()
  {
    string callMethod = nameof (ShowParkList);
    try
    {
      if (AppBool.Connected)
      {
        if (clsAppMarbleVars.cMachine.runSystem.Run)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
          {
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
          }
          return -1;
        }
        if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
          {
            // ISSUE: reference to a compiler-generated field
            ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
          }
          return -1;
        }
      }
      if (clsAppMarbleItems.frmParkList == null)
        clsAppMarbleItems.frmParkList = new F_MarbleParkList();
      clsAppMarbleItems.frmParkList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmParkList.Parks.Clear();
      for (int index = 0; index <= clsAppMarbleVars.cMachine.ParkList.Length - 2; ++index)
        clsAppMarbleItems.frmParkList.Parks.Add(new Pnt9DS(clsAppMarbleVars.cMachine.ParkList[index]));
      clsAppMarbleItems.frmParkList.indexPark = clsAppMarbleVars.varApp.SelectedParkPosition;
      clsAppMarbleItems.frmParkList.ShowGeneralParks = false;
      clsAppMarbleItems.frmParkList.Init();
      clsAppMarbleItems.frmParkList.StartPosition = FormStartPosition.CenterParent;
      int num = (int) clsAppMarbleItems.frmParkList.ShowDialog((IWin32Window) clsItem.FrmMain);
      if (clsAppMarbleItems.frmParkList.PropertiesForm.Result != DialogResult.OK)
        return -1;
      clsAppMarbleVars.varApp.SelectedParkPosition = clsAppMarbleItems.frmParkList.indexPark;
      for (int index = 0; index <= clsAppMarbleItems.frmParkList.Parks.Count - 1; ++index)
      {
        if (index <= clsAppMarbleVars.cMachine.ParkList.Length - 1)
          clsAppMarbleVars.cMachine.ParkList[index] = new Pnt9DS(clsAppMarbleItems.frmParkList.Parks[index]);
      }
      this.SaveParameterUser();
      if (AppBool.Connected)
      {
        this.writeDINTVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.SelectedParkPosition, "appSet.SelectedParkPosition");
        clsAppMarbleVars.cMachine.bWriteParkParameters = true;
        clsAppMarbleVars.cMachine.bWriteAppParameter = true;
      }
      return clsAppMarbleVars.varApp.SelectedParkPosition;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return -1;
    }
  }

  public void ShowPassword()
  {
    string callMethod = nameof (ShowPassword);
    try
    {
      if (clsAppMarbleItems.frmPassword == null)
        clsAppMarbleItems.frmPassword = new F_PasswordV1();
      clsAppMarbleItems.frmPassword.textCtrl1.PasswordChar = '*';
      clsAppMarbleItems.frmPassword.StartPosition = FormStartPosition.CenterScreen;
      clsAppMarbleItems.frmPassword.ShowDialog("", (IWin32Window) clsAppMarbleItems.frmMain);
      switch (clsAppMarbleItems.frmPassword.Value)
      {
        case "200200":
          AppSecurity.PasswordLevel = 2;
          break;
        case "2016":
          AppSecurity.PasswordLevel = 10;
          break;
        default:
          int num = (int) MessageBox.Show(buLangTranslate.preDef.PasswordWrong);
          AppSecurity.PasswordLevel = 0;
          break;
      }
    }
    catch (Exception ex)
    {
      AppSecurity.PasswordLevel = 0;
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public DialogResult ShowPreset(int LeftPosition, int TopPosition)
  {
    if (buMarbleForms.frmPreset == null)
      buMarbleForms.frmPreset = new F_Preset();
    buMarbleForms.frmPreset.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    buMarbleForms.frmPreset.StartPosition = FormStartPosition.Manual;
    buMarbleForms.frmPreset.PropertiesForm.FormPosition = FormStartPosition.Manual;
    buMarbleForms.frmPreset.Left = LeftPosition;
    buMarbleForms.frmPreset.Top = TopPosition;
    buMarbleForms.frmPreset.Init();
    int num = (int) buMarbleForms.frmPreset.ShowDialog();
    return buMarbleForms.frmPreset.PropertiesForm.Result;
  }

  public void ShowUserInterfaceSettings()
  {
    if (clsAppMarbleItems.frmUISettings == null)
      clsAppMarbleItems.frmUISettings = new F_ControlUISettings();
    clsAppMarbleItems.frmUISettings.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsAppMarbleItems.frmUISettings.Init();
    clsAppMarbleItems.frmUISettings.StartPosition = FormStartPosition.CenterScreen;
    int num = (int) clsAppMarbleItems.frmUISettings.ShowDialog();
    if (clsAppMarbleItems.frmUISettings.PropertiesForm.Result != DialogResult.OK)
      return;
    hmiUICommands.SaveApplicationVisualFile(AppPath.MachineSettings + "\\ApplicationVisual.prm");
    buLogMarbleVer5.addToUserLog("User Interface Setting Changed", "", "", "", "", "", 0);
  }

  public void ShowBackupLoad()
  {
    if (clsAppMarbleItems.frmBackupV1 == null)
      clsAppMarbleItems.frmBackupV1 = new F_MarbleBackupLoad();
    clsAppMarbleItems.frmBackupV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsAppMarbleItems.frmBackupV1.Init();
    clsAppMarbleItems.frmBackupV1.StartPosition = FormStartPosition.CenterScreen;
    int num = (int) clsAppMarbleItems.frmBackupV1.ShowDialog();
    if (clsAppMarbleItems.frmBackupV1.PropertiesForm.Result != DialogResult.OK)
      return;
    buFile5.CopyFilesRecursively(clsAppMarbleItems.frmBackupV1.BackupFolder, AppPath.MachineSettings);
    buLogMarbleVer5.addToUserLog("Backup Loaded", clsAppMarbleItems.frmBackupV1.BackupFolder, "", "", "", "", 0);
  }

  public void ShowIOConfig()
  {
    if (clsAppMarbleItems.frmIOConfig == null)
      clsAppMarbleItems.frmIOConfig = new F_MarbleIOConfig();
    clsAppMarbleItems.frmIOConfig.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsAppMarbleItems.frmIOConfig.Init();
    clsAppMarbleItems.frmIOConfig.StartPosition = FormStartPosition.CenterScreen;
    int num1 = (int) clsAppMarbleItems.frmIOConfig.ShowDialog();
    if (clsAppMarbleItems.frmIOConfig.PropertiesForm.Result != DialogResult.OK)
      return;
    buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
    dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
    dialogMessageBoxYesNo.Init(buLangTranslate.preSentences.CreateCode, buLangTranslate.preSentences.DoYouWantToSaveIOConfigration);
    int num2 = (int) dialogMessageBoxYesNo.ShowDialog();
    if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
      return;
    clsAppMarbleVars.cmdMarble.SaveIO();
    clsAppMarbleVars.cMachine.bWriteIOParameter = true;
    buLogMarbleVer5.addToUserLog("IO Configs", "Changed", "", "", "", "", 0);
  }

  public void ShowReport()
  {
    string callMethod = nameof (ShowReport);
    try
    {
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowDebug()
  {
    string callMethod = nameof (ShowDebug);
    try
    {
      if (clsAppMarbleItems.frmDebug == null)
        clsAppMarbleItems.frmDebug = new F_DebugV2();
      clsAppMarbleItems.frmDebug.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmDebug.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
      clsAppMarbleItems.frmDebug.Init();
      int num = (int) clsAppMarbleItems.frmDebug.ShowDialog();
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowCalculations()
  {
    string callMethod = nameof (ShowCalculations);
    try
    {
      if (clsAppMarbleItems.frmCalculator == null)
        clsAppMarbleItems.frmCalculator = new F_MarbleCalculators();
      clsAppMarbleItems.frmCalculator.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmCalculator.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
      clsAppMarbleItems.frmCalculator.Init();
      int num = (int) clsAppMarbleItems.frmCalculator.ShowDialog();
      if (clsAppMarbleItems.frmCalculator.PropertiesForm.Result == DialogResult.OK)
        ;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowInformation()
  {
    string callMethod = nameof (ShowInformation);
    try
    {
      if (clsAppMarbleItems.frmInfoList == null)
        clsAppMarbleItems.frmInfoList = new F_MarbleInfoList();
      ((F_MarbleMotorWarmUp) clsAppMarbleItems.frmInfoList).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      ((F_MarbleMotorWarmUp) clsAppMarbleItems.frmInfoList).PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
      clsAppMarbleItems.frmInfoList.Init(clsAppMarbleVars.cMachine.InfoList);
      int num = (int) clsAppMarbleItems.frmInfoList.ShowDialog();
      if (((F_MarbleMotorWarmUp) clsAppMarbleItems.frmInfoList).PropertiesForm.Result == DialogResult.OK)
        ;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowTest()
  {
    if (!clsAppMarbleItems.frmDigitalInputOutput.Visible)
    {
      int num = buMarbleCalc.varMarbleMachineSettings.OptionSettings.DigitalInputCount;
      if (buMarbleCalc.varMarbleMachineSettings.OptionSettings.DigitalOutputCount > num)
        num = buMarbleCalc.varMarbleMachineSettings.OptionSettings.DigitalOutputCount;
      clsAppMarbleItems.frmDigitalInputOutput.pnl_input1.Visible = false;
      clsAppMarbleItems.frmDigitalInputOutput.pnl_input2.Visible = false;
      clsAppMarbleItems.frmDigitalInputOutput.pnl_input3.Visible = false;
      clsAppMarbleItems.frmDigitalInputOutput.pnl_input4.Visible = false;
      clsAppMarbleItems.frmDigitalInputOutput.pnl_output1.Visible = false;
      clsAppMarbleItems.frmDigitalInputOutput.pnl_output2.Visible = false;
      clsAppMarbleItems.frmDigitalInputOutput.pnl_output3.Visible = false;
      clsAppMarbleItems.frmDigitalInputOutput.pnl_output4.Visible = false;
      if (num <= 16 /*0x10*/)
      {
        clsAppMarbleItems.frmDigitalInputOutput.Width = 410;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input1.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output1.Visible = true;
      }
      if (num > 16 /*0x10*/ & num <= 32 /*0x20*/)
      {
        clsAppMarbleItems.frmDigitalInputOutput.Width = 800;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input1.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input2.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output1.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output2.Visible = true;
      }
      if (num > 32 /*0x20*/ & num <= 48 /*0x30*/)
      {
        clsAppMarbleItems.frmDigitalInputOutput.Width = 1190;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input1.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input2.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input3.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output1.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output2.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output3.Visible = true;
      }
      if (num > 48 /*0x30*/)
      {
        clsAppMarbleItems.frmDigitalInputOutput.Width = 1580;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input1.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input2.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input3.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_input4.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output1.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output2.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output3.Visible = true;
        clsAppMarbleItems.frmDigitalInputOutput.pnl_output4.Visible = true;
      }
      clsAppMarbleItems.frmDigitalInputOutput.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmDigitalInputOutput.PropertiesForm.FormPosition = FormStartPosition.Manual;
      clsAppMarbleItems.frmDigitalInputOutput.StartPosition = FormStartPosition.Manual;
      clsAppMarbleItems.frmDigitalInputOutput.Left = (1920 - clsAppMarbleItems.frmDigitalInputOutput.Width) / 2;
      clsAppMarbleItems.frmDigitalInputOutput.Init();
      clsAppMarbleItems.frmDigitalInputOutput.Show((IWin32Window) clsAppMarbleItems.frmMain);
    }
    else
      clsAppMarbleItems.frmDigitalInputOutput.Visible = false;
  }

  public void ShowMaintanance()
  {
    string callMethod = nameof (ShowMaintanance);
    try
    {
      if (clsAppMarbleItems.frmMaintanance == null)
        clsAppMarbleItems.frmMaintanance = new F_MarbleMaintanance();
      clsAppMarbleItems.frmMaintanance.StartPosition = FormStartPosition.CenterScreen;
      clsAppMarbleItems.frmMaintanance.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmMaintanance.Init();
      int num = (int) clsAppMarbleItems.frmMaintanance.ShowDialog();
    }
    catch (Exception ex)
    {
      AppSecurity.PasswordLevel = 0;
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowMaterialMeasure()
  {
    string callMethod = "ShowMaintanance";
    try
    {
      if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.SlabThicknessEnable)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
      }
      else
      {
        if (clsAppMarbleItems.frmMaterialMeasure == null)
          clsAppMarbleItems.frmMaterialMeasure = new F_MarbleMaterialMeasurement();
        clsAppMarbleItems.frmMaterialMeasure.StartPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmMaterialMeasure.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmMaterialMeasure.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmMaterialMeasure.Init();
        int num1 = (int) clsAppMarbleItems.frmMaterialMeasure.ShowDialog();
        if (clsAppMarbleItems.frmMaterialMeasure.PropertiesForm.Result != DialogResult.OK || clsAppMarbleVars.cMachine.MaterialMeasureList.Count <= 0)
          return;
        double num2 = 0.0;
        double num3 = -999999.0;
        double num4 = 999999.0;
        int num5 = 0;
        for (int index = 0; index <= clsAppMarbleVars.cMachine.MaterialMeasureList.Count - 1; ++index)
        {
          if (clsAppMarbleVars.cMachine.MaterialMeasureList[index].Z > clsAppMarbleVars.varApp.MaterialMeasureMinThickness & clsAppMarbleVars.cMachine.MaterialMeasureList[index].Z > 0.0)
          {
            num2 += clsAppMarbleVars.cMachine.MaterialMeasureList[index].Z;
            ++num5;
            if (clsAppMarbleVars.cMachine.MaterialMeasureList[index].Z > num3)
              num3 = clsAppMarbleVars.cMachine.MaterialMeasureList[index].Z;
            if (clsAppMarbleVars.cMachine.MaterialMeasureList[index].Z < num4)
              num4 = clsAppMarbleVars.cMachine.MaterialMeasureList[index].Z;
          }
        }
        if (num5 <= 0)
          return;
        double Data2 = num2 / (double) num5;
        double num6 = num3 - num4;
        if (num6 > clsAppMarbleVars.varApp.MaterialMeasureMaxDifference)
        {
          buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
          dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
          dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Measure}", $"{buLangTranslate.preSentences.MaxMaterialMeasurementDifferenceisHigherthenLimit} =  {num6.ToString("f2")}");
          int num7 = (int) dialogMessageBoxYesNo.ShowDialog();
          if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
            return;
        }
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 26, (object) Data2, (object) null, (object) null, (object) null);
      }
    }
    catch (Exception ex)
    {
      AppSecurity.PasswordLevel = 0;
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowCounters()
  {
    string callMethod = nameof (ShowCounters);
    try
    {
      if (clsAppMarbleItems.frmCounters == null)
        clsAppMarbleItems.frmCounters = new F_MarbleCounters();
      clsAppMarbleItems.frmCounters.StartPosition = FormStartPosition.CenterScreen;
      clsAppMarbleItems.frmCounters.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmCounters.Init();
      int num = (int) clsAppMarbleItems.frmCounters.ShowDialog();
    }
    catch (Exception ex)
    {
      AppSecurity.PasswordLevel = 0;
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowWarmUp()
  {
    string callMethod = nameof (ShowWarmUp);
    try
    {
      if (!buMarbleCalc.varMarbleMachineSettings.OptionSettings.WarmMotors)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
      }
      else
      {
        if (clsAppMarbleItems.frmWarmUp == null)
          clsAppMarbleItems.frmWarmUp = new F_MarbleMotorWarmUp();
        clsAppMarbleItems.frmWarmUp.StartPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmWarmUp.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmWarmUp.Init();
        int num = (int) clsAppMarbleItems.frmWarmUp.ShowDialog();
      }
    }
    catch (Exception ex)
    {
      AppSecurity.PasswordLevel = 0;
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowGCodeFromFile(string FileName)
  {
    string callMethod = "ShowGCode";
    try
    {
      FileInfo fileInfo = new FileInfo(FileName);
      if (!fileInfo.Exists)
        return;
      F_Notepad fNotepad = new F_Notepad();
      string Str = "";
      buFile.OpenFromFile(fileInfo.FullName, ref Str);
      fNotepad.Width = 800;
      fNotepad.Init(Str);
      fNotepad.TopMost = true;
      fNotepad.Show();
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowGCodePage(int Ver)
  {
    if (Ver != 1)
      return;
    if ((clsAppMarbleItems.frmGCodeViewV1 == null ? 0 : (!clsAppMarbleItems.frmGCodeViewV1.Visible ? 1 : 0)) != 0)
    {
      clsAppMarbleItems.frmGCodeViewV1.StartPosition = FormStartPosition.Manual;
      clsAppMarbleItems.frmGCodeViewV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmGCodeViewV1.PropertiesForm.FormPosition = FormStartPosition.Manual;
      clsAppMarbleItems.frmGCodeViewV1.PropertiesForm.TopMost = true;
      if (((clsAppMarbleInterfaceVar) clsAppMarbleVars.varForms).GCodeFormWidth > 10)
        clsAppMarbleItems.frmGCodeViewV1.Width = ((clsAppMarbleInterfaceVar) clsAppMarbleVars.varForms).GCodeFormWidth;
      if (((clsAppMarbleInterfaceVar) clsAppMarbleVars.varForms).GCodeFormHeight > 0)
        clsAppMarbleItems.frmGCodeViewV1.Width = ((clsAppMarbleInterfaceVar) clsAppMarbleVars.varForms).GCodeFormHeight;
      clsAppMarbleItems.frmGCodeViewV1.Left = clsAppMarbleItems.frmMain.Width - clsAppMarbleItems.frmMain.Left - clsAppMarbleItems.frmGCodeViewV1.Width - 10;
      clsAppMarbleItems.frmGCodeViewV1.Top = clsAppMarbleItems.frmMain.Height - clsAppMarbleItems.frmMain.Top - clsAppMarbleItems.frmGCodeViewV1.Height - 150;
      clsAppMarbleItems.frmGCodeViewV1.TopMost = true;
      clsAppMarbleItems.frmGCodeViewV1.Show();
    }
    else
    {
      if (clsAppMarbleItems.frmGCodeViewV1 == null)
        return;
      clsAppMarbleItems.frmGCodeViewV1.Visible = false;
    }
  }

  public void ShowJobList(int Ver)
  {
    if (Ver != 1 || clsAppMarbleItems.frmJobList == null)
      return;
    if (!clsAppMarbleItems.frmJobList.Visible)
    {
      clsAppMarbleItems.frmJobList.StartPosition = FormStartPosition.Manual;
      clsAppMarbleItems.frmJobList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmJobList.PropertiesForm.FormPosition = FormStartPosition.Manual;
      clsAppMarbleItems.frmJobList.PropertiesForm.TopMost = true;
      clsAppMarbleItems.frmJobList.Left = clsAppMarbleItems.frmMain.Width - clsAppMarbleItems.frmMain.Left - clsAppMarbleItems.frmJobList.Width - 10;
      clsAppMarbleItems.frmJobList.Top = clsAppMarbleItems.frmMain.Height - clsAppMarbleItems.frmMain.Top - clsAppMarbleItems.frmJobList.Height - 150;
      clsAppMarbleItems.frmJobList.TopMost = true;
      clsAppMarbleItems.frmJobList.Show();
    }
    else
      clsAppMarbleItems.frmJobList.Visible = false;
  }

  public void ShowAbsoluteSet()
  {
    string callMethod = nameof (ShowAbsoluteSet);
    try
    {
      if (AppBool.Connected)
      {
        if (clsAppMarbleVars.cMachine.runSystem.Run)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
          return;
        }
        if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
          return;
        }
      }
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
        }
        if (!clsVar.varProgram.ShowPasswordPageIfNoAccessLevel)
          return;
        this.ShowPassword();
      }
      else
      {
        this.ClickCommand((MarbleMotionCommands) 55);
        if (clsAppMarbleItems.frmAbsoluteSet == null)
          return;
        // ISSUE: reference to a compiler-generated field
        buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Absolute Set Page", "Opened", "", 0.0, 0.0, false);
        clsAppMarbleItems.frmAbsoluteSet.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmAbsoluteSet.Init();
        clsAppMarbleItems.frmAbsoluteSet.StartPosition = FormStartPosition.CenterScreen;
        int num = (int) clsAppMarbleItems.frmAbsoluteSet.ShowDialog();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowAxesGain()
  {
    string callMethod = nameof (ShowAxesGain);
    try
    {
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowG54Set()
  {
    string callMethod = nameof (ShowG54Set);
    try
    {
      if (AppBool.Connected)
      {
        if (clsAppMarbleVars.cMachine.runSystem.Run)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.SystemisRunning, (object) null, (object) null, (object) null);
          return;
        }
        if (!clsAppMarbleVars.cMachine.runSystem.HomingDone)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.HomingMissing, (object) null, (object) null, (object) null);
          return;
        }
        if (clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
        {
          // ISSUE: reference to a compiler-generated field
          if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
            return;
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.RTCPActivated, (object) null, (object) null, (object) null);
          return;
        }
      }
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
        }
        if (!clsVar.varProgram.ShowPasswordPageIfNoAccessLevel)
          return;
        this.ShowPassword();
      }
      else
      {
        this.ClickCommand((MarbleMotionCommands) 55);
        if (clsAppMarbleItems.frmG54Set == null)
          return;
        // ISSUE: reference to a compiler-generated field
        buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "G54 Page", "Opened", "", 0.0, 0.0, false);
        clsAppMarbleItems.frmG54Set.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmG54Set.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
        clsAppMarbleItems.frmG54Set.spn_xG54.Value = clsAppMarbleVars.cMachine.G54List[0].X;
        clsAppMarbleItems.frmG54Set.spn_yG54.Value = clsAppMarbleVars.cMachine.G54List[0].Y;
        clsAppMarbleItems.frmG54Set.spn_zG54.Value = clsAppMarbleVars.cMachine.G54List[0].Z;
        clsAppMarbleItems.frmG54Set.Init();
        clsAppMarbleItems.frmG54Set.StartPosition = FormStartPosition.CenterParent;
        int num = (int) clsAppMarbleItems.frmG54Set.ShowDialog();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowWatch()
  {
    string callMethod = nameof (ShowWatch);
    try
    {
      if (AppSecurity.PasswordLevel < 2)
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.LevelisnotEnoughtThisOperation, (object) null, (object) null, (object) null);
      }
      else
      {
        if (clsAppMarbleItems.frmWatchVars == null)
          return;
        clsAppMarbleItems.frmWatchVars.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmWatchVars.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmWatchVars.PropertiesForm.TopMost = true;
        clsAppMarbleItems.frmWatchVars.HideMaxVal = true;
        clsAppMarbleItems.frmWatchVars.HideMinVal = true;
        clsAppMarbleItems.frmWatchVars.Width = 840;
        clsAppMarbleItems.frmWatchVars.Init();
        clsAppMarbleItems.frmWatchVars.Show();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowMaterialPage()
  {
    string callMethod = nameof (ShowMaterialPage);
    try
    {
      if (clsAppMarbleItems.frmMaterialSize == null)
        clsAppMarbleItems.frmMaterialSize = new F_MarbleMaterialSize();
      clsAppMarbleItems.frmMaterialSize.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmMaterialSize.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
      clsAppMarbleItems.frmMaterialSize.Init();
      int num = (int) clsAppMarbleItems.frmMaterialSize.ShowDialog();
      if (clsAppMarbleItems.frmMaterialSize.PropertiesForm.Result != DialogResult.OK)
        return;
      clsInit.appMarble.doMaterialBoxCreate(clsAppMarbleItems.frmMaterialSize.Mat.Size, clsAppMarbleItems.frmMaterialSize.Mat.FileNameImage, clsAppMarbleItems.frmMaterialSize.Mat.matImage);
      clsInit.appMarble.doDrawActiveJob();
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowMDIPage()
  {
    string callMethod = nameof (ShowMDIPage);
    try
    {
      if (clsAppMarbleItems.frmMDIPageV1 != null)
      {
        clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormPosition = FormStartPosition.Manual;
        clsAppMarbleItems.frmMDIPageV1.StartPosition = FormStartPosition.Manual;
        clsAppMarbleItems.frmMDIPageV1.PropertiesForm.TopMost = true;
        clsAppMarbleItems.frmMDIPageV1.TopMost = true;
        clsAppMarbleItems.frmMDIPageV1.Init();
        clsAppMarbleItems.frmMDIPageV1.Show();
      }
      else
      {
        if (clsAppMarbleItems.frmMDIPageV2 == null)
          return;
        clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormPosition = FormStartPosition.Manual;
        clsAppMarbleItems.frmMDIPageV2.StartPosition = FormStartPosition.Manual;
        clsAppMarbleItems.frmMDIPageV2.PropertiesForm.TopMost = true;
        clsAppMarbleItems.frmMDIPageV2.TopMost = true;
        clsAppMarbleItems.frmMDIPageV2.Init();
        clsAppMarbleItems.frmMDIPageV2.Show();
      }
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowJogPage()
  {
    try
    {
      if (clsAppMarbleItems.frmJogPageV1 == null)
        return;
      clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
      clsAppMarbleItems.frmJogPageV1.Init();
      int num = (int) clsAppMarbleItems.frmJogPageV1.ShowDialog();
    }
    catch (Exception ex)
    {
    }
  }

  public void ShowLanguageMenu()
  {
    if (AppSecurity.PasswordLevel < 2)
      buString5.MessageBoxWarning(buLangTranslate.preSentences.PasswordLevelNotEnough);
    else
      clsInit.appMarble.cmdShowLanguage();
  }

  public void ApplySettings()
  {
    string callMethod = nameof (ApplySettings);
    try
    {
      for (int index = 0; index <= clsAppMarbleVars.cMachine.AppAxis.Count - 1; ++index)
        clsAppMarbleVars.cMachine.AppAxis[index].AxisPar = new CodesysAxis((CodesysAxis) clsAppMarbleItems.frmSettings.Classes[index]);
      int num = clsAppMarbleVars.cMachine.AppAxis.Count - 1;
      clsAppMarbleVars.cMachine.varCNC = new CodesysCNCSets((CodesysCNCSets) clsAppMarbleItems.frmSettings.Classes[1 + num]);
      clsAppMarbleVars.varApp = (clsAppMarbleOPVar) new clsAppMarbleIODef((clsAppMarbleOPVar) clsAppMarbleItems.frmSettings.Classes[2 + num]);
      clsAppMarbleVars.cMachine.PLCSettings = new PlcDeviceData((PlcDeviceData) clsAppMarbleItems.frmSettings.Classes[3 + num]);
      clsAppMarbleVars.cMachine.ProgramSettings = new setMotionProgramVar((setMotionProgramVar) clsAppMarbleItems.frmSettings.Classes[4 + num]);
      clsAppMarbleVars.cMachine.varHandWheel = new HandWheelSettings((HandWheelSettings) clsAppMarbleItems.frmSettings.Classes[5 + num]);
      clsAppMarbleVars.cMachine.varJog = new JogSettings((JogSettings) clsAppMarbleItems.frmSettings.Classes[6 + num]);
      clsAppMarbleVars.cMachine.varSystem = new CodesysSystemSets((CodesysSystemSets) clsAppMarbleItems.frmSettings.Classes[7 + num]);
      clsAppMarbleVars.varInterface = (clsAppMarbleInterfaceVar) new clsAppMarbleMachineReportItem((clsAppMarbleInterfaceVar) clsAppMarbleItems.frmSettings.Classes[8 + num]);
      clsAppMarbleVars.cMachine.varAlarmActions = new AlarmActionSettings((AlarmActionSettings) clsAppMarbleItems.frmSettings.Classes[9 + num]);
      clsAppMarbleVars.varApp.OptionServoAxisA = buMarbleCalc.varMarbleMachineSettings.OptionSettings.ServoAxisA;
      clsAppMarbleVars.varApp.OptionAllAbsoluteEncoder = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AllAbsoluteEncoder;
      clsAppMarbleVars.varApp.OptionAutoToolChanger = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger;
      clsAppMarbleVars.varApp.OptionCameraEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable;
      clsAppMarbleVars.varApp.OptionDigitalInputCount = buMarbleCalc.varMarbleMachineSettings.OptionSettings.DigitalInputCount;
      clsAppMarbleVars.varApp.OptionDigitalOutputCount = buMarbleCalc.varMarbleMachineSettings.OptionSettings.DigitalOutputCount;
      clsAppMarbleVars.varApp.OptionGantryY2Parallel = buMarbleCalc.varMarbleMachineSettings.OptionSettings.GantryY2Parallel;
      clsAppMarbleVars.varApp.OptionServoAxisY2 = buMarbleCalc.varMarbleMachineSettings.OptionSettings.ServoAxisY2;
      clsAppMarbleVars.varApp.OptionSlabThicknessEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.SlabThicknessEnable;
      clsAppMarbleVars.varApp.OptionSpindleEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
      clsAppMarbleVars.varApp.OptionToolMeasureEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.ToolMeasureEnable;
      clsAppMarbleVars.varApp.OptionVacuumEnable = buMarbleCalc.varMarbleMachineSettings.OptionSettings.VacuumEnable;
      AppBool.TouchPad = clsAppMarbleVars.cMachine.ProgramSettings.TouchPad;
      buSystem.resolutionCompare = clsAppMarbleVars.cMachine.ProgramSettings.Resolution;
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "MAchine Setting Changed", "Apply", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ApplySettingsMisc()
  {
    string callMethod = nameof (ApplySettingsMisc);
    try
    {
      clsAppMarbleVars.varForms = (clsAppMarbleFormVar) new clsAppMarbleInterfaceVar((clsAppMarbleFormVar) clsAppMarbleItems.frmSettings.Classes[0]);
      clsAppMarbleVars.varInterface = (clsAppMarbleInterfaceVar) new clsAppMarbleMachineReportItem((clsAppMarbleInterfaceVar) clsAppMarbleItems.frmSettings.Classes[1]);
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Misc Setting Changed", "Apply", "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, ex.Message, "Exception", "", 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
    }
  }

  public void ShowCameraLive()
  {
    // ISSUE: reference to a compiler-generated field
    if (buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable || ((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preSentences.ThisFunctionIsNotAvailable, (object) null, (object) null, (object) null);
  }

  public void TakeShotFromCamera()
  {
  }

  public void ShowDrawingMenu(int Left, int Top)
  {
    if (clsAppMarbleItems.frmDrawingV1 == null)
      return;
    if (!clsAppMarbleItems.frmDrawingV1.Visible)
    {
      clsAppMarbleItems.frmDrawingV1.StartPosition = FormStartPosition.Manual;
      clsAppMarbleItems.frmDrawingV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmDrawingV1.PropertiesForm.FormPosition = FormStartPosition.Manual;
      clsAppMarbleItems.frmDrawingV1.PropertiesForm.TopMost = true;
      clsAppMarbleItems.frmDrawingV1.Left = Left;
      clsAppMarbleItems.frmDrawingV1.Top = Top;
      clsAppMarbleItems.frmDrawingV1.TopMost = true;
      clsAppMarbleItems.frmDrawingV1.Show();
    }
    else
      clsAppMarbleItems.frmDrawingV1.Visible = false;
  }

  public void ShowUserDefine()
  {
    if (clsAppMarbleItems.frmUserPageV1 == null)
      clsAppMarbleItems.frmUserPageV1 = new F_MarbleUserList();
    clsAppMarbleItems.frmUserPageV1.StartPosition = FormStartPosition.CenterScreen;
    ((F_MarbleMDIV1) clsAppMarbleItems.frmUserPageV1).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    ((F_MarbleMDIV1) clsAppMarbleItems.frmUserPageV1).PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
    clsAppMarbleItems.frmUserPageV1.Init(clsAppMarbleVars.cMachine.UserList);
    int num = (int) clsAppMarbleItems.frmUserPageV1.ShowDialog();
    if (((F_MarbleMDIV1) clsAppMarbleItems.frmUserPageV1).PropertiesForm.Result != DialogResult.OK)
      return;
    clsAppMarbleVars.cMachine.UserList.Clear();
    for (int index = 0; index <= ((F_MarbleMDIV1) clsAppMarbleItems.frmUserPageV1).UserList.Count - 1; ++index)
      clsAppMarbleVars.cMachine.UserList.Add(new UserLoginInfo(((F_MarbleMDIV1) clsAppMarbleItems.frmUserPageV1).UserList[index]));
    this.SaveParameter();
  }

  public void ShowTechnicianDefine()
  {
    if (clsAppMarbleItems.frmTechnicianPageV1 == null)
      clsAppMarbleItems.frmTechnicianPageV1 = new F_MarbleTechnicianList();
    clsAppMarbleItems.frmTechnicianPageV1.StartPosition = FormStartPosition.CenterScreen;
    clsAppMarbleItems.frmTechnicianPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsAppMarbleItems.frmTechnicianPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
    clsAppMarbleItems.frmTechnicianPageV1.Init(clsAppMarbleVars.cMachine.TechnicianList);
    int num = (int) clsAppMarbleItems.frmTechnicianPageV1.ShowDialog();
    if (clsAppMarbleItems.frmTechnicianPageV1.PropertiesForm.Result != DialogResult.OK)
      return;
    clsAppMarbleVars.cMachine.TechnicianList.Clear();
    for (int index = 0; index <= clsAppMarbleItems.frmTechnicianPageV1.UserList.Count - 1; ++index)
      clsAppMarbleVars.cMachine.TechnicianList.Add(new TechnicianLoginInfo(clsAppMarbleItems.frmTechnicianPageV1.UserList[index]));
    this.SaveParameter();
  }

  public void Test_Output(object sender, EventArgs e)
  {
    int num = -1;
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control.Tag != null)
      num = Convert.ToInt32(control.Tag);
    if (!(num >= 0 & num <= clsAppMarbleVars.cMachine.Outputs.Count - 1))
      return;
    for (int index = 0; index <= clsAppMarbleVars.cMachine.Outputs.Count - 1; ++index)
    {
      if (clsAppMarbleVars.cMachine.Outputs[index].SourceIndex == num + 1)
      {
        bool Val = false;
        this.readBOOLVar(CodesysVariableBaseType.None, clsAppMarbleVars.cMachine.Outputs[index].Name, ref Val);
        if (!Val)
          this.writeBOOLVar(CodesysVariableBaseType.None, true, clsAppMarbleVars.cMachine.Outputs[index].Name);
        else
          this.writeBOOLVar(CodesysVariableBaseType.None, false, clsAppMarbleVars.cMachine.Outputs[index].Name);
      }
    }
  }

  public bool getPensState()
  {
    string callMethod = nameof (getPensState);
    try
    {
      bool Val = false;
      if (AppBool.Connected)
        this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.boolData.bToolPens", ref Val);
      return Val;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
      return false;
    }
  }

  public void setPensState(bool State)
  {
    string callMethod = nameof (setPensState);
    try
    {
      if (AppBool.Connected)
        this.writeBOOLVar(CodesysVariableBaseType.Global, State, "sysRun.boolData.bToolPens");
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", State.ToString(), "", 0.0, 0.0, false);
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Command", "Exception", "", 0.0, 0.0, false);
      // ISSUE: reference to a compiler-generated field
      buException.throwException(ex, callMethod, true, ((clsAppMarble.\u003C\u003Ec) this).\u0001);
    }
  }

  public void OpenParameter(bool OpenClsMarbleSettings = true)
  {
    try
    {
      if (OpenClsMarbleSettings)
      {
        clsInit.appMarble.OpenMarbleFile(AppPath.MachineSettingsCam + "\\Marble");
        if (clsInit.appNesting != null)
          clsInit.appNesting.OpenNestingFile();
      }
      string fileName = AppPath.MachineSettings + "\\Machine.prm";
      FileInfo fileInfo1 = new FileInfo(fileName);
      if (fileInfo1.Exists)
      {
        ArrayList arrayList = new ArrayList();
        TextReader textReader = (TextReader) File.OpenText(fileInfo1.FullName);
        List<List<string>> CalcList1 = new List<List<string>>();
        string str;
        while ((str = textReader.ReadLine()) != null)
          arrayList.Add((object) str);
        textReader.Close();
        if (arrayList.Count <= 20)
        {
          buLogMarbleVer5.addToCriticalLog("ProgramParameterFailure", "Machine.prm", arrayList.Count.ToString(), "", "", "", 0);
          AppBool.FileSettingBroken = true;
          string PathName = "";
          if (this.DebugGetLastBackUpFiles(ref PathName))
            File.Copy($"{AppPath.Machine}\\Backup\\{PathName}\\Machine.prm", AppPath.MachineSettings + "\\Machine.prm", true);
          arrayList.Clear();
          arrayList = new ArrayList();
          buFile5.OpenFromFile(fileName, ref arrayList);
          if (arrayList.Count <= 20)
            clsAppMarbleVars.cMachine.miscVar.ProgramParameterFailure = true;
        }
        try
        {
          List<string> CalcList2 = new List<string>();
          clsAppMarbleVars.varRuntime.AxY2 = 5;
          CodesysAxesData codesysAxesData1 = new CodesysAxesData();
          CodesysAxesData codesysAxesData2 = new CodesysAxesData();
          CodesysAxesData codesysAxesData3 = new CodesysAxesData();
          CodesysAxesData codesysAxesData4 = new CodesysAxesData();
          CodesysAxesData codesysAxesData5 = new CodesysAxesData();
          CodesysAxesData codesysAxesData6 = new CodesysAxesData();
          buSerilization.Decode(arrayList, "_X", SerilizationMode.MultiLine, (object) codesysAxesData1.AxisPar);
          buSerilization.Decode(arrayList, "_Y", SerilizationMode.MultiLine, (object) codesysAxesData2.AxisPar);
          buSerilization.Decode(arrayList, "_Z", SerilizationMode.MultiLine, (object) codesysAxesData3.AxisPar);
          buSerilization.Decode(arrayList, "_C", SerilizationMode.MultiLine, (object) codesysAxesData5.AxisPar);
          buSerilization.Decode(arrayList, "_A", SerilizationMode.MultiLine, (object) codesysAxesData4.AxisPar);
          buSerilization.Decode(arrayList, "_Y2", SerilizationMode.MultiLine, (object) codesysAxesData6.AxisPar);
          if (codesysAxesData1.AxisPar.Sets.setPulse == 50001.0)
            clsAppMarbleVars.cMachine.miscVar.ProgramParameterFailure = true;
          if (codesysAxesData2.AxisPar.Sets.setPulse == 50001.0)
            clsAppMarbleVars.cMachine.miscVar.ProgramParameterFailure = true;
          if (codesysAxesData3.AxisPar.Sets.setPulse == 50001.0)
            clsAppMarbleVars.cMachine.miscVar.ProgramParameterFailure = true;
          if (codesysAxesData4.AxisPar.Sets.setPulse == 50001.0)
            clsAppMarbleVars.cMachine.miscVar.ProgramParameterFailure = true;
          if (codesysAxesData5.AxisPar.Sets.setPulse == 50001.0)
            clsAppMarbleVars.cMachine.miscVar.ProgramParameterFailure = true;
          codesysAxesData4.AxisPar.Temps.DontReadOffsetedPosition = true;
          codesysAxesData5.AxisPar.Temps.DontReadOffsetedPosition = true;
          codesysAxesData6.AxisPar.Temps.DontReadOffsetedPosition = true;
          codesysAxesData1.AxisPar.Base.baseChar = buLangTranslate.preChar.X;
          codesysAxesData1.AxisPar.Base.baseName = buLangTranslate.preChar.X;
          codesysAxesData2.AxisPar.Base.baseChar = buLangTranslate.preChar.Y;
          codesysAxesData2.AxisPar.Base.baseName = buLangTranslate.preChar.Y;
          codesysAxesData3.AxisPar.Base.baseChar = buLangTranslate.preChar.Z;
          codesysAxesData3.AxisPar.Base.baseName = buLangTranslate.preChar.Z;
          codesysAxesData4.AxisPar.Base.baseChar = buLangTranslate.preChar.A;
          codesysAxesData4.AxisPar.Base.baseName = buLangTranslate.preChar.A;
          codesysAxesData5.AxisPar.Base.baseChar = buLangTranslate.preChar.C;
          codesysAxesData5.AxisPar.Base.baseName = buLangTranslate.preChar.C;
          codesysAxesData6.AxisPar.Base.baseChar = buLangTranslate.preChar.Y + "2";
          codesysAxesData6.AxisPar.Base.baseName = buLangTranslate.preChar.Y + "2";
          clsAppMarbleVars.cMachine.AppAxis = new List<CodesysAxesData>();
          clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData1);
          clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData2);
          clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData3);
          clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData5);
          clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData4);
          clsAppMarbleVars.cMachine.AppAxis.Add(codesysAxesData6);
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
          CalcList2.Clear();
          List<string> CalcList3 = new List<string>();
          try
          {
            buString.ListToSpecificList("<ParkList>", "</ParkList>", false, arrayList, ref CalcList3);
            for (int index = 0; index <= CalcList3.Count - 1; ++index)
            {
              if (index <= clsAppMarbleVars.cMachine.ParkList.Length - 1 & index <= 4)
                clsAppMarbleVars.cMachine.ParkList[index] = new Pnt9DS(Pnt9DS.DecodeFromString(CalcList3[index]));
            }
          }
          catch (Exception ex)
          {
          }
          CalcList3.Clear();
          List<string> CalcList4 = new List<string>();
          try
          {
            clsAppMarbleVars.cMachine.MaterialMeasureList.Clear();
            buString.ListToSpecificList("<MaterialMeasures>", "</MaterialMeasures>", false, arrayList, ref CalcList4);
            for (int index = 0; index <= CalcList4.Count - 1; ++index)
              clsAppMarbleVars.cMachine.MaterialMeasureList.Add(new Pnt9DS(Pnt9DS.DecodeFromString(CalcList4[index])));
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
            buSerilization5.Decode(AL, "Milling", (SerilizationMode5) 1, (object) buMarbleCalc.activeToolMilling);
          }
          CalcList1 = new List<List<string>>();
          buString.ListToSpecificList("<ToolActiveMillingHead>", "</ToolActiveMillingHead>", false, arrayList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            ArrayList AL = new ArrayList();
            AL.AddRange((ICollection) CalcList1[0].ToArray());
            ToolBase5 toolBase5 = new ToolBase5();
            buSerilization5.Decode(AL, "MillingHead", (SerilizationMode5) 1, (object) buMarbleCalc.activeToolMillingHead);
          }
          CalcList1 = new List<List<string>>();
          buString.ListToSpecificList("<ToolActiveSaw>", "</ToolActiveSaw>", false, arrayList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            ArrayList AL = new ArrayList();
            AL.AddRange((ICollection) CalcList1[0].ToArray());
            ToolBase5 toolBase5 = new ToolBase5();
            buSerilization5.Decode(AL, "Saw", (SerilizationMode5) 1, (object) buMarbleCalc.activeToolSaw);
          }
          List<string> CalcList5 = new List<string>();
          buString.ListToSpecificList("<ToolListMilling>", "</ToolListMilling>", false, arrayList, ref CalcList5);
          if (CalcList5.Count > 0)
          {
            if (buMarbleCalc.ToolMillings == null)
              buMarbleCalc.ToolMillings = new List<ToolBase5>();
            buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", false, CalcList5, ref CalcList1);
            for (int index = 0; index <= CalcList1.Count - 1; ++index)
            {
              ToolBase5 toolBase5 = new ToolBase5();
              ToolBase5.DecodeShort(CalcList1[index], ref toolBase5);
              buMarbleCalc.ToolMillings.Add(toolBase5);
            }
          }
          else if (buMarbleCalc.ToolMillings == null)
            buMarbleCalc.ToolMillings = new List<ToolBase5>();
          List<string> CalcList6 = new List<string>();
          buString.ListToSpecificList("<ToolListMillingHead>", "</ToolListMillingHead>", false, arrayList, ref CalcList6);
          if (CalcList6.Count > 0)
          {
            if (buMarbleCalc.ToolMillingHeads == null)
              buMarbleCalc.ToolMillingHeads = new List<ToolBase5>();
            buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", false, CalcList6, ref CalcList1);
            for (int index = 0; index <= CalcList1.Count - 1; ++index)
            {
              ToolBase5 toolBase5 = new ToolBase5();
              ToolBase5.DecodeShort(CalcList1[index], ref toolBase5);
              buMarbleCalc.ToolMillingHeads.Add(toolBase5);
            }
          }
          else if (buMarbleCalc.ToolMillingHeads == null)
            buMarbleCalc.ToolMillingHeads = new List<ToolBase5>();
          List<string> CalcList7 = new List<string>();
          buString.ListToSpecificList("<ToolListSaw>", "</ToolListSaw>", false, arrayList, ref CalcList7);
          if (CalcList7.Count > 0)
          {
            if (buMarbleCalc.ToolSaws == null)
              buMarbleCalc.ToolSaws = new List<ToolBase5>();
            buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", false, CalcList7, ref CalcList1);
            for (int index = 0; index <= CalcList1.Count - 1; ++index)
            {
              ToolBase5 toolBase5 = new ToolBase5();
              ToolBase5.DecodeShort(CalcList1[index], ref toolBase5);
              buMarbleCalc.ToolSaws.Add(toolBase5);
            }
          }
          else if (buMarbleCalc.ToolSaws == null)
            buMarbleCalc.ToolSaws = new List<ToolBase5>();
          List<string> CalcList8 = new List<string>();
          buString.ListToSpecificList("<ToolInMagazine>", "</ToolInMagazine>", false, arrayList, ref CalcList8);
          if (CalcList8.Count > 0)
          {
            if (buMarbleCalc.ToolInMagazine == null)
              buMarbleCalc.ToolInMagazine = new List<ToolBase5>();
            buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", false, CalcList8, ref CalcList1);
            for (int index = 0; index <= CalcList1.Count - 1; ++index)
            {
              ToolBase5 toolBase5 = new ToolBase5();
              ToolBase5.DecodeShort(CalcList1[index], ref toolBase5);
              buMarbleCalc.ToolInMagazine.Add(toolBase5);
            }
          }
          else if (buMarbleCalc.ToolInMagazine == null)
            buMarbleCalc.ToolInMagazine = new List<ToolBase5>();
          buMarbleCalc.activeToolMilling.Purpose = ToolPurpose.Milling;
          buMarbleCalc.activeToolSaw.Purpose = ToolPurpose.Saw;
          buMarbleCalc.activeToolSaw.Geometry.GeometryType = ToolType.Saw;
          buMarbleCalc.activeToolMillingHead.Purpose = ToolPurpose.MillingHead;
          CalcList1 = new List<List<string>>();
          buString.ListToSpecificList("<UserLoginInfo>", "</UserLoginInfo>", true, arrayList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            for (int index = 0; index <= CalcList1.Count - 1; ++index)
            {
              UserLoginInfo userLoginInfo = new UserLoginInfo();
              buSerilization.Decode(CalcList1[index], "", SerilizationMode.MultiLine, (object) userLoginInfo);
              clsAppMarbleVars.cMachine.UserList.Add(userLoginInfo);
            }
          }
          CalcList1 = new List<List<string>>();
          buString.ListToSpecificList("<TechnicianLoginInfo>", "</TechnicianLoginInfo>", true, arrayList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            for (int index = 0; index <= CalcList1.Count - 1; ++index)
            {
              TechnicianLoginInfo technicianLoginInfo = new TechnicianLoginInfo();
              buSerilization.Decode(CalcList1[index], "", SerilizationMode.MultiLine, (object) technicianLoginInfo);
              clsAppMarbleVars.cMachine.TechnicianList.Add(technicianLoginInfo);
            }
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Open Error Axes Parameter", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Open Error Axes Parameter");
        }
        try
        {
          buSerilization5.Decode(arrayList, "", (SerilizationMode5) 1, (object) clsAppMarbleVars.varInterface);
          buSerilization5.Decode(arrayList, "", (SerilizationMode5) 1, (object) clsAppMarbleVars.varApp);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.ProgramSettings);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.PLCSettings);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.varSystem);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.varJog);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.varHandWheel);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.varCNC);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.varAlarmActions);
          buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) clsAppMarbleVars.cMachine.MachineSetting);
          buSerilization5.Decode(arrayList, "", (SerilizationMode5) 1, (object) clsAppMarbleVars.varForms);
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
        buLog.addLog("Machine Parameter File Missing", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxInfo("Machine Parameter File Missing");
      }
      FileInfo fileInfo2 = new FileInfo(AppPath.MachineSettings + "\\User.prm");
      if (fileInfo2.Exists)
      {
        ArrayList RefList = new ArrayList();
        TextReader textReader = (TextReader) File.OpenText(fileInfo2.FullName);
        List<List<string>> stringListList = new List<List<string>>();
        string str;
        while ((str = textReader.ReadLine()) != null)
          RefList.Add((object) str);
        textReader.Close();
        new List<string>().Clear();
        List<string> CalcList9 = new List<string>();
        try
        {
          buString.ListToSpecificList("<G54Offset>", "</G54Offset>", false, RefList, ref CalcList9);
          for (int index = 0; index <= CalcList9.Count - 1; ++index)
          {
            if (index <= clsAppMarbleVars.cMachine.G54List.Length - 1 & index <= 4)
              clsAppMarbleVars.cMachine.G54List[index] = new Pnt9DS(Pnt9DS.DecodeFromString(CalcList9[index]));
          }
        }
        catch (Exception ex)
        {
        }
        CalcList9.Clear();
        List<string> CalcList10 = new List<string>();
        try
        {
          buString.ListToSpecificList("<ParkList>", "</ParkList>", false, RefList, ref CalcList10);
          for (int index = 0; index <= CalcList10.Count - 1; ++index)
          {
            if (index <= clsAppMarbleVars.cMachine.ParkList.Length - 1 & index <= 4)
              clsAppMarbleVars.cMachine.ParkList[index] = new Pnt9DS(Pnt9DS.DecodeFromString(CalcList10[index]));
          }
        }
        catch (Exception ex)
        {
        }
        CalcList10.Clear();
        List<string> CalcList11 = new List<string>();
        try
        {
          clsAppMarbleVars.cMachine.MaterialMeasureList.Clear();
          buString.ListToSpecificList("<MaterialMeasures>", "</MaterialMeasures>", false, RefList, ref CalcList11);
          for (int index = 0; index <= CalcList11.Count - 1; ++index)
            clsAppMarbleVars.cMachine.MaterialMeasureList.Add(new Pnt9DS(Pnt9DS.DecodeFromString(CalcList11[index])));
        }
        catch (Exception ex)
        {
        }
        List<List<string>> CalcList12 = new List<List<string>>();
        buString.ListToSpecificList("<ToolActiveMilling>", "</ToolActiveMilling>", false, RefList, ref CalcList12);
        if (CalcList12.Count > 0)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList12[0].ToArray());
          ToolBase5 toolBase5 = new ToolBase5();
          buSerilization5.Decode(AL, "Milling", (SerilizationMode5) 1, (object) buMarbleCalc.activeToolMilling);
        }
        List<List<string>> CalcList13 = new List<List<string>>();
        buString.ListToSpecificList("<ToolActiveMillingHead>", "</ToolActiveMillingHead>", false, RefList, ref CalcList13);
        if (CalcList13.Count > 0)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList13[0].ToArray());
          ToolBase5 toolBase5 = new ToolBase5();
          buSerilization5.Decode(AL, "MillingHead", (SerilizationMode5) 1, (object) buMarbleCalc.activeToolMillingHead);
        }
        List<List<string>> CalcList14 = new List<List<string>>();
        buString.ListToSpecificList("<ToolActiveSaw>", "</ToolActiveSaw>", false, RefList, ref CalcList14);
        if (CalcList14.Count > 0)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList14[0].ToArray());
          ToolBase5 toolBase5 = new ToolBase5();
          buSerilization5.Decode(AL, "Saw", (SerilizationMode5) 1, (object) buMarbleCalc.activeToolSaw);
        }
        List<string> CalcList15 = new List<string>();
        buString.ListToSpecificList("<ToolListMilling>", "</ToolListMilling>", false, RefList, ref CalcList15);
        if (CalcList15.Count > 0)
        {
          if (buMarbleCalc.ToolMillings == null)
            buMarbleCalc.ToolMillings = new List<ToolBase5>();
          buMarbleCalc.ToolMillings.Clear();
          buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", false, CalcList15, ref CalcList14);
          for (int index = 0; index <= CalcList14.Count - 1; ++index)
          {
            ToolBase5 toolBase5 = new ToolBase5();
            ToolBase5.DecodeShort(CalcList14[index], ref toolBase5);
            buMarbleCalc.ToolMillings.Add(toolBase5);
          }
        }
        else if (buMarbleCalc.ToolMillings == null)
          buMarbleCalc.ToolMillings = new List<ToolBase5>();
        List<string> CalcList16 = new List<string>();
        buString.ListToSpecificList("<ToolListMillingHead>", "</ToolListMillingHead>", false, RefList, ref CalcList16);
        if (CalcList16.Count > 0)
        {
          if (buMarbleCalc.ToolMillingHeads == null)
            buMarbleCalc.ToolMillingHeads = new List<ToolBase5>();
          buMarbleCalc.ToolMillingHeads.Clear();
          buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", false, CalcList16, ref CalcList14);
          for (int index = 0; index <= CalcList14.Count - 1; ++index)
          {
            ToolBase5 toolBase5 = new ToolBase5();
            ToolBase5.DecodeShort(CalcList14[index], ref toolBase5);
            buMarbleCalc.ToolMillingHeads.Add(toolBase5);
          }
        }
        else if (buMarbleCalc.ToolMillingHeads == null)
          buMarbleCalc.ToolMillingHeads = new List<ToolBase5>();
        List<string> CalcList17 = new List<string>();
        buString.ListToSpecificList("<ToolListSaw>", "</ToolListSaw>", false, RefList, ref CalcList17);
        if (CalcList17.Count > 0)
        {
          if (buMarbleCalc.ToolSaws == null)
            buMarbleCalc.ToolSaws = new List<ToolBase5>();
          buMarbleCalc.ToolSaws.Clear();
          buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", false, CalcList17, ref CalcList14);
          for (int index = 0; index <= CalcList14.Count - 1; ++index)
          {
            ToolBase5 toolBase5 = new ToolBase5();
            ToolBase5.DecodeShort(CalcList14[index], ref toolBase5);
            buMarbleCalc.ToolSaws.Add(toolBase5);
          }
        }
        else if (buMarbleCalc.ToolSaws == null)
          buMarbleCalc.ToolSaws = new List<ToolBase5>();
        List<string> CalcList18 = new List<string>();
        buString.ListToSpecificList("<ToolInMagazine>", "</ToolInMagazine>", false, RefList, ref CalcList18);
        if (CalcList18.Count > 0)
        {
          if (buMarbleCalc.ToolInMagazine == null)
            buMarbleCalc.ToolInMagazine = new List<ToolBase5>();
          buMarbleCalc.ToolInMagazine.Clear();
          buString.ListToSpecificList("<ToolListBase>", "</ToolListBase>", false, CalcList18, ref CalcList14);
          for (int index = 0; index <= CalcList14.Count - 1; ++index)
          {
            ToolBase5 toolBase5 = new ToolBase5();
            ToolBase5.DecodeShort(CalcList14[index], ref toolBase5);
            buMarbleCalc.ToolInMagazine.Add(toolBase5);
          }
        }
        else if (buMarbleCalc.ToolInMagazine == null)
          buMarbleCalc.ToolInMagazine = new List<ToolBase5>();
        buMarbleCalc.activeToolMilling.Purpose = ToolPurpose.Milling;
        buMarbleCalc.activeToolSaw.Purpose = ToolPurpose.Saw;
        buMarbleCalc.activeToolSaw.Geometry.GeometryType = ToolType.Saw;
        buMarbleCalc.activeToolMillingHead.Purpose = ToolPurpose.MillingHead;
      }
      FileInfo fileInfo3 = new FileInfo(AppPath.MachineSettings + "\\Interface.prm");
      if (fileInfo3.Exists)
      {
        ArrayList AL = new ArrayList();
        TextReader textReader = (TextReader) File.OpenText(fileInfo3.FullName);
        List<List<string>> stringListList = new List<List<string>>();
        string str;
        while ((str = textReader.ReadLine()) != null)
          AL.Add((object) str);
        textReader.Close();
        buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) clsAppMarbleVars.varInterface);
      }
      FileInfo fileInfo4 = new FileInfo(AppPath.MachineSettings + "\\IO.prm");
      if (fileInfo4.Exists)
      {
        ArrayList RefList = new ArrayList();
        TextReader textReader = (TextReader) File.OpenText(fileInfo4.FullName);
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
        {
          string[] strArray = stringList1[index].Split(';');
          if ((strArray == null ? 0 : (strArray.Length != 0 ? 1 : 0)) != 0)
          {
            string name = strArray[0].Trim();
            string caption = name;
            int sourceindex = -1;
            bool inverted = false;
            if (strArray.Length >= 2)
              sourceindex = int.Parse(strArray[1].Trim());
            if (strArray.Length >= 3)
              inverted = bool.Parse(strArray[2].Trim());
            if (strArray.Length >= 4)
              caption = strArray[3].Trim();
            clsAppMarbleVars.cMachine.Inputs.Add(new DigitalInputData(name, caption, sourceindex, inverted));
          }
        }
        for (int index = 0; index <= stringList2.Count - 1; ++index)
        {
          string[] strArray = stringList2[index].Split(';');
          if ((strArray == null ? 0 : (strArray.Length != 0 ? 1 : 0)) != 0)
          {
            string name = strArray[0].Trim();
            string caption = name;
            int sourceindex = -1;
            bool inverted = false;
            if (strArray.Length >= 2)
              sourceindex = int.Parse(strArray[1].Trim());
            if (strArray.Length >= 3)
              inverted = bool.Parse(strArray[2].Trim());
            if (strArray.Length >= 4)
              caption = strArray[3].Trim();
            clsAppMarbleVars.cMachine.Outputs.Add(new DigitalOutputData(name, caption, sourceindex, inverted));
          }
        }
        if (clsAppMarbleVars.cMachine.Inputs.Count == 0 | clsAppMarbleVars.cMachine.Outputs.Count == 0)
          clsAppMarbleVars.cMachine.miscVar.ProgramIOFailure = true;
        buLog.addLog("IO  File Read ", "", "", "Ok", 0);
        RefList.Clear();
      }
      else
      {
        buLog.addLog("Machine 1 IO File Missing", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxInfo("Machine 1 IO File Missing");
      }
      this.ToolCreate();
      AppBool.TouchPad = buMarbleCalc.varMarbleSettings.TouchPad;
    }
    catch (Exception ex)
    {
    }
  }

  public void SaveParameter()
  {
    if (MarbleTempVars.SavingMachine)
      return;
    // ISSUE: reference to a compiler-generated method
    Task.Run(new Action(((clsAppMarble.\u003C\u003Ec) this).\u0002));
  }

  public void SaveParameter(string Path)
  {
    try
    {
      if (MarbleTempVars.SavingMachine)
        return;
      MarbleTempVars.SavingMachine = true;
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
      StringList.Add((object) "   Alarm Actions");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.varAlarmActions.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   App Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.varApp.ToDefAll("", 2, (SerilizationMode5) 1));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Program Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.ProgramSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   X Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.ToDefAll("_X", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Y Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.ToDefAll("_Y", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Z Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.ToDefAll("_Z", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   C Axis Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.ToDefAll("_C", 2, SerilizationMode.MultiLine));
      StringList.Add((object) " ");
      if (clsAppMarbleVars.varRuntime.AxA >= 0)
      {
        StringList.Add((object) "------------------------------------------------------------------------");
        StringList.Add((object) "   A Axis Parameter");
        StringList.Add((object) "------------------------------------------------------------------------");
        StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.ToDefAll("_A", 2, SerilizationMode.MultiLine));
        StringList.Add((object) " ");
      }
      if (clsAppMarbleVars.varRuntime.AxY2 >= 0)
      {
        StringList.Add((object) "------------------------------------------------------------------------");
        StringList.Add((object) "   Y2 Axis Parameter");
        StringList.Add((object) "------------------------------------------------------------------------");
        StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.ToDefAll("_Y2", 2, SerilizationMode.MultiLine));
        StringList.Add((object) " ");
      }
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Users");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "  <UserDefine>");
      for (int index = 0; index <= clsAppMarbleVars.cMachine.UserList.Count - 1; ++index)
        StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.UserList[index].ToDefAll("", 4, SerilizationMode.MultiLine));
      StringList.Add((object) "  </UserDefine>");
      StringList.Add((object) " ");
      StringList.Add((object) "  <TechnicianDefine>");
      for (int index = 0; index <= clsAppMarbleVars.cMachine.TechnicianList.Count - 1; ++index)
        StringList.AddRange((ICollection) clsAppMarbleVars.cMachine.TechnicianList[index].ToDefAll("", 4, SerilizationMode.MultiLine));
      StringList.Add((object) "  </TechnicianDefine>");
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
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Forms Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.varForms.ToDefAll("", 2, (SerilizationMode5) 1));
      StringList.Add((object) " ");
      buFile.SaveToFile(StringList, FileName);
      MarbleTempVars.SavingMachine = false;
      this.SaveParameterUser();
      this.SaveParameterInterface();
    }
    catch (Exception ex)
    {
      MarbleTempVars.SavingMachine = false;
    }
  }

  public void SaveParameterUser()
  {
    if (MarbleTempVars.SavingUser)
      return;
    // ISSUE: reference to a compiler-generated method
    Task.Run(new Action(((clsAppMarble.\u003C\u003Ec) this).\u0003));
  }

  public void SaveParameterUser(string Path)
  {
    try
    {
      if (MarbleTempVars.SavingUser)
        return;
      MarbleTempVars.SavingUser = true;
      ArrayList arrayList = new ArrayList();
      string FileName = Path + "\\User.prm";
      ArrayList StringList = new ArrayList();
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Tool Active");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "  <ToolActiveMilling>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolMilling.ToDefAll("Milling", 4, (SerilizationMode5) 1));
      StringList.Add((object) "  </ToolActiveMilling>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveMillingHead>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolMillingHead.ToDefAll("MillingHead", 4, (SerilizationMode5) 1));
      StringList.Add((object) "  </ToolActiveMillingHead>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveSaw>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolSaw.ToDefAll("Saw", 4, (SerilizationMode5) 1));
      StringList.Add((object) "  </ToolActiveSaw>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveLaser>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolLaserPointer.ToDefAll("Laser", 4, (SerilizationMode5) 1));
      StringList.Add((object) "  </ToolActiveLaser>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveAirDry>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolAirDry.ToDefAll("airDry", 4, (SerilizationMode5) 1));
      StringList.Add((object) "  </ToolActiveAirDry>");
      StringList.Add((object) "");
      StringList.Add((object) "  <ToolActiveWaterJet>");
      StringList.AddRange((ICollection) buMarbleCalc.activeToolWaterjet.ToDefAll("Waterjet", 4, (SerilizationMode5) 1));
      StringList.Add((object) "  </ToolActiveWaterJet>");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Tool List");
      StringList.Add((object) "------------------------------------------------------------------------");
      if (buMarbleCalc.ToolMillings != null)
      {
        StringList.Add((object) "  <ToolListMilling>");
        for (int index = 0; index <= buMarbleCalc.ToolMillings.Count - 1; ++index)
        {
          if (buMarbleCalc.ToolMillings[index] != null)
          {
            StringList.Add((object) "    <ToolListBase>");
            StringList.AddRange((ICollection) ToolBase5.ToDefShort(6, buMarbleCalc.ToolMillings[index]));
            StringList.Add((object) "    </ToolListBase>");
          }
        }
        StringList.Add((object) "  </ToolListMilling>");
        StringList.Add((object) "");
      }
      if (buMarbleCalc.ToolMillingHeads != null)
      {
        StringList.Add((object) "  <ToolListMillingHead>");
        for (int index = 0; index <= buMarbleCalc.ToolMillingHeads.Count - 1; ++index)
        {
          if (buMarbleCalc.ToolMillingHeads[index] != null)
          {
            StringList.Add((object) "    <ToolListBase>");
            StringList.AddRange((ICollection) ToolBase5.ToDefShort(6, buMarbleCalc.ToolMillingHeads[index]));
            StringList.Add((object) "    </ToolListBase>");
          }
        }
        StringList.Add((object) "  </ToolListMillingHead>");
        StringList.Add((object) "");
      }
      if (buMarbleCalc.ToolSaws != null)
      {
        StringList.Add((object) "  <ToolListSaw>");
        for (int index = 0; index <= buMarbleCalc.ToolSaws.Count - 1; ++index)
        {
          if (buMarbleCalc.ToolSaws[index] != null)
          {
            StringList.Add((object) "    <ToolListBase>");
            StringList.AddRange((ICollection) ToolBase5.ToDefShort(6, buMarbleCalc.ToolSaws[index]));
            StringList.Add((object) "    </ToolListBase>");
          }
        }
        StringList.Add((object) "  </ToolListSaw>");
        StringList.Add((object) "");
      }
      if (buMarbleCalc.ToolInMagazine != null)
      {
        StringList.Add((object) "  <ToolInMagazine>");
        for (int index = 0; index <= buMarbleCalc.ToolInMagazine.Count - 1; ++index)
        {
          if (buMarbleCalc.ToolInMagazine[index] != null)
          {
            StringList.Add((object) "    <ToolListBase>");
            StringList.AddRange((ICollection) ToolBase5.ToDefShort(6, buMarbleCalc.ToolInMagazine[index]));
            StringList.Add((object) "    </ToolListBase>");
          }
        }
        StringList.Add((object) "  </ToolInMagazine>");
        StringList.Add((object) "");
      }
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
      StringList.Add((object) "   Parks");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "  <ParkList>");
      for (int index = 0; index <= clsAppMarbleVars.cMachine.ParkList.Length - 1; ++index)
      {
        if (index <= clsAppMarbleVars.cMachine.MachineSetting.ParkCount - 1)
          StringList.Add((object) ("    " + clsAppMarbleVars.cMachine.ParkList[index].ToDef()));
      }
      StringList.Add((object) "  </ParkList>");
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   MaterialMeasures");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "  <MaterialMeasures>");
      for (int index = 0; index <= clsAppMarbleVars.cMachine.MaterialMeasureList.Count - 1; ++index)
        StringList.Add((object) ("    " + clsAppMarbleVars.cMachine.MaterialMeasureList[index].ToDef()));
      StringList.Add((object) "  </MaterialMeasures>");
      StringList.Add((object) " ");
      buFile.SaveToFile(StringList, FileName);
      MarbleTempVars.SavingUser = false;
    }
    catch (Exception ex)
    {
      MarbleTempVars.SavingUser = false;
    }
  }

  public void SaveParameterInterface()
  {
    if (MarbleTempVars.SavingInterface)
      return;
    // ISSUE: reference to a compiler-generated method
    Task.Run(new Action(((clsAppMarble.\u003C\u003Ec) this).\u0004));
  }

  public void SaveParameterInterface(string Path)
  {
    try
    {
      if (MarbleTempVars.SavingInterface)
        return;
      MarbleTempVars.SavingInterface = true;
      ArrayList arrayList = new ArrayList();
      string FileName = Path + "\\Interface.prm";
      ArrayList StringList = new ArrayList();
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Interface Parameter");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) clsAppMarbleVars.varInterface.ToDefAll("", 2, (SerilizationMode5) 1));
      StringList.Add((object) " ");
      buFile.SaveToFile(StringList, FileName);
      MarbleTempVars.SavingInterface = false;
    }
    catch (Exception ex)
    {
      MarbleTempVars.SavingInterface = false;
    }
  }

  public void OpenReport()
  {
    try
    {
      FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\Report.prm");
      if (!fileInfo.Exists)
        return;
      ArrayList AL = new ArrayList();
      TextReader textReader = (TextReader) File.OpenText(fileInfo.FullName);
      string str;
      while ((str = textReader.ReadLine()) != null)
        AL.Add((object) str);
      textReader.Close();
      if (AL.Count <= 0)
        return;
      clsAppMarbleVars.reportMachine = (clsAppMarbleMachineReport) new clsAppMarble();
      buSerilization5.Decode(AL, "ItemSpindleUp", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemSpindleUp);
      buSerilization5.Decode(AL, "ItemSpindleDown", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemSpindleDown);
      buSerilization5.Decode(AL, "ItemVacuumUp", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemVacuumUp);
      buSerilization5.Decode(AL, "ItemVacuumDown", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemVacuumDown);
      buSerilization5.Decode(AL, "ItemLeftSuctionCup", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemLeftSuctionCup);
      buSerilization5.Decode(AL, "ItemRightSuctionCup", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemRightSuctionCup);
      buSerilization5.Decode(AL, "ItemToolMeasureUp", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemToolMeasureUp);
      buSerilization5.Decode(AL, "ItemToolMeasureDown", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemToolMeasureDown);
      buSerilization5.Decode(AL, "ItemMaterialMeasureUp", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemMaterialMeasureUp);
      buSerilization5.Decode(AL, "ItemMaterialMeasureDown", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemMaterialMeasureDown);
      buSerilization5.Decode(AL, "ItemLaserOnOff", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemLaserOnOff);
      buSerilization5.Decode(AL, "ItemLeftVacuumOutOk", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemLeftVacuumOutOk);
      buSerilization5.Decode(AL, "IteLeftVacuumInOk", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.IteLeftVacuumInOk);
      buSerilization5.Decode(AL, "ItemRightVacuumOutOk", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemRightVacuumOutOk);
      buSerilization5.Decode(AL, "ItemRightVacuumInOk", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemRightVacuumInOk);
      buSerilization5.Decode(AL, "ItemToolBlowOnOff", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemToolBlowOnOff);
      buSerilization5.Decode(AL, "ItemSuctionCupAirOnOff ", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemSuctionCupAirOnOff);
      buSerilization5.Decode(AL, "ItemMagazineOpen", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemMagazineOpen);
      buSerilization5.Decode(AL, "ItemMagazineClose", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemMagazineClose);
      buSerilization5.Decode(AL, "ItemMagazineUp", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemMagazineUp);
      buSerilization5.Decode(AL, "ItemMagazineDown", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemMagazineDown);
      buSerilization5.Decode(AL, "ItemToolPens", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemToolPens);
      buSerilization5.Decode(AL, "ItemWaterOnOff", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemWaterOnOff);
      buSerilization5.Decode(AL, "ItemCameraCover", (SerilizationMode5) 1, (object) clsAppMarbleVars.reportMachine.ItemCameraCover);
      buSerilization5.Decode(AL, "ItemLubrication", (SerilizationMode5) 1, (object) ((MarblePartZeroType) clsAppMarbleVars.reportMachine).ItemLubrication);
    }
    catch (Exception ex)
    {
    }
  }

  public void SaveReport()
  {
    try
    {
      if (clsAppMarbleVars.reportMachine == null)
        return;
      string FileName = AppPath.MachineSettings + "\\Report.prm";
      ArrayList StringList = new ArrayList();
      StringList.Add((object) ((MarblePartZeroType) clsAppMarbleVars.reportMachine).ReportName);
      StringList.Add((object) ((MarblePartZeroType) clsAppMarbleVars.reportMachine).ReportID.ToString());
      StringList.Add((object) ((MarblePartZeroType) clsAppMarbleVars.reportMachine).ReportDate.ToLongDateString());
      StringList.Add((object) ((MarbleParkModeAfterJob) clsAppMarbleVars.reportMachine).Status.ToString());
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemSpindleUp.ToDefAll("ItemSpindleUp", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemSpindleDown.ToDefAll("ItemSpindleDown", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemVacuumUp.ToDefAll("ItemVacuumUp", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemVacuumDown.ToDefAll("ItemVacuumDown", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemLeftSuctionCup.ToDefAll("ItemLeftSuctionCup", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemRightSuctionCup.ToDefAll("ItemRightSuctionCup", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemToolMeasureUp.ToDefAll("ItemToolMeasureUp", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemToolMeasureDown.ToDefAll("ItemToolMeasureDown", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemMaterialMeasureUp.ToDefAll("ItemMaterialMeasureUp", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemMaterialMeasureDown.ToDefAll("ItemMaterialMeasureDown", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemLaserOnOff.ToDefAll("ItemLaserOnOff", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemLeftVacuumOutOk.ToDefAll("ItemLeftVacuumOutOk", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.IteLeftVacuumInOk.ToDefAll("IteLeftVacuumInOk", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemRightVacuumOutOk.ToDefAll("ItemRightVacuumOutOk", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemRightVacuumInOk.ToDefAll("ItemRightVacuumInOk", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemToolBlowOnOff.ToDefAll("ItemToolBlowOnOff", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemSuctionCupAirOnOff.ToDefAll("ItemSuctionCupAirOnOff ", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemMagazineOpen.ToDefAll("ItemMagazineOpen", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemMagazineClose.ToDefAll("ItemMagazineClose", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemMagazineUp.ToDefAll("ItemMagazineUp", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemMagazineDown.ToDefAll("ItemMagazineDown", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemToolPens.ToDefAll("ItemToolPens", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemWaterOnOff.ToDefAll("ItemWaterOnOff", 2));
      StringList.AddRange((ICollection) clsAppMarbleVars.reportMachine.ItemCameraCover.ToDefAll("ItemCameraCover", 2));
      StringList.AddRange((ICollection) ((MarblePartZeroType) clsAppMarbleVars.reportMachine).ItemLubrication.ToDefAll("ItemLubrication", 2));
      buFile.SaveToFile(StringList, FileName);
    }
    catch (Exception ex)
    {
    }
  }

  public void SaveUserDll()
  {
    buFile5.SaveToFile(new List<string>()
    {
      "Name: " + clsVar.appDefination.Name,
      "Description: " + clsVar.appDefination.Description,
      "Vendor: " + clsVar.appDefination.Vendor,
      "Mode: " + clsVar.appDefination.Mode,
      "Web: " + clsVar.appDefination.Web,
      "Machine No: " + clsVar.appDefination.MachineNo,
      "Machine Serial: " + clsVar.appDefination.MachineSerial,
      "Machine Name: " + clsVar.appDefination.MachineName
    }, AppPath.MachineSettings + "\\UIDef.dll");
  }

  public void SaveIO(string FileName = "")
  {
    try
    {
      string str1 = "IO.prm";
      if (FileName.Trim().Length > 1)
        str1 = FileName;
      List<string> stringList = new List<string>();
      if (!(clsAppMarbleVars.cMachine.Inputs.Count > 0 & clsAppMarbleVars.cMachine.Outputs.Count > 0))
        return;
      stringList.Add("<Inputs>");
      for (int index = 0; index <= clsAppMarbleVars.cMachine.Inputs.Count - 1; ++index)
        stringList.Add($"   {clsAppMarbleVars.cMachine.Inputs[index].Name} ; {clsAppMarbleVars.cMachine.Inputs[index].SourceIndex.ToString()} ; {clsAppMarbleVars.cMachine.Inputs[index].Invert.ToString()} ; {clsAppMarbleVars.cMachine.Inputs[index].Caption.ToString()}");
      stringList.Add("</Inputs>");
      stringList.Add(" ");
      stringList.Add(" ");
      stringList.Add("<Outputs>");
      for (int index = 0; index <= clsAppMarbleVars.cMachine.Outputs.Count - 1; ++index)
        stringList.Add($"   {clsAppMarbleVars.cMachine.Outputs[index].Name} ; {clsAppMarbleVars.cMachine.Outputs[index].SourceIndex.ToString()} ; {clsAppMarbleVars.cMachine.Outputs[index].Invert.ToString()} ; {clsAppMarbleVars.cMachine.Outputs[index].Caption.ToString()}");
      stringList.Add("</Outputs>");
      string str2 = $"{AppPath.MachineSettings}\\{str1}";
      buFile5.SaveToFile(stringList, str2);
    }
    catch (Exception ex)
    {
    }
  }

  public void LoadLanguage()
  {
    clsAppMarbleItems.frmTempWaterjet.btn_hydrolic.Text = buLangTranslate.preDef.Hydraulic;
    clsAppMarbleItems.frmTempWaterjet.btn_motor.Text = buLangTranslate.preDef.Motor;
    clsAppMarbleItems.frmTempWaterjet.btn_sand.Text = buLangTranslate.preDef.Sand;
    clsAppMarbleItems.frmTempWaterjet.btn_water.Text = buLangTranslate.preDef.Water;
    clsAppMarbleItems.frmTempWaterjet.btn_valve.Text = buLangTranslate.preDef.Valve;
    clsAppMarbleItems.frmTempWaterjet.lbl_sandspeed.Text = $"{buLangTranslate.preDef.Sand} {buLangTranslate.preDef.Speed}";
    clsAppMarbleItems.frmTempCode.btn_laser.Text = buLangTranslate.preDef.Laser;
    clsAppMarbleItems.frmTempCode.btn_pause.Text = buLangTranslate.preDef.Pause;
    clsAppMarbleItems.frmTempCode.btn_spindlemain.Text = buLangTranslate.preDef.Spindle;
    clsAppMarbleItems.frmTempCode.btn_start.Text = buLangTranslate.preDef.Start;
    clsAppMarbleItems.frmTempCode.btn_stop.Text = buLangTranslate.preDef.Stop;
    clsAppMarbleItems.frmTempCode.btn_water.Text = buLangTranslate.preDef.Water;
    clsAppMarbleItems.frmTempCode.btn_laser.Text = buLangTranslate.preDef.Laser;
    clsAppMarbleItems.frmTempCode.lbl_machine.Text = buLangTranslate.preDef.Machine;
    clsAppMarbleItems.frmTempCode.lbl_part.Text = buLangTranslate.preDef.Part;
    clsAppMarbleItems.frmTempCode.lbl_operationspeed.Text = $"{buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Speed}";
    clsAppMarbleItems.frmTempCode.lbl_quickspeed.Text = $"{buLangTranslate.preDef.Quick} {buLangTranslate.preDef.Speed}";
  }

  public string readDINTVar(CodesysVariableBaseType VarType, string Address, ref int Val)
  {
    string callMethod = nameof (readDINTVar);
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        int num = 1;
        if (VarName.Length > 1)
          buPLCHandler.ReadVariableDINT(VarName, ref Val);
        str = num != 0 ? "Error" : "Ok";
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, nodeid, ref Val);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public string readINTVar(CodesysVariableBaseType VarType, string Address, ref short Val)
  {
    string callMethod = nameof (readINTVar);
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        int num = 1;
        if (VarName.Length > 1)
          buPLCHandler.ReadVariableINT(VarName, ref Val);
        str = num != 0 ? "Error" : "Ok";
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.ReadINTValue(OpcVars.opcClient.Session, nodeid, ref Val);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public string readREALVar(CodesysVariableBaseType VarType, string Address, ref float Val)
  {
    string callMethod = nameof (readREALVar);
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        int num = 1;
        if (VarName.Length > 1)
          buPLCHandler.ReadVariableREAL(VarName, ref Val);
        str = num != 0 ? "Error" : "Ok";
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.ReadREALValue(OpcVars.opcClient.Session, nodeid, ref Val);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public string readLREALVar(CodesysVariableBaseType VarType, string Address, ref double Val)
  {
    string callMethod = nameof (readLREALVar);
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        int num = 1;
        if (VarName.Length > 1)
          buPLCHandler.ReadVariableLREAL(VarName, ref Val);
        str = num != 0 ? "Error" : "Ok";
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.ReadLREALValue(OpcVars.opcClient.Session, nodeid, ref Val);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "NoConnection";
    }
  }

  public string readSTRINGVar(CodesysVariableBaseType VarType, string Address, ref string Val)
  {
    string callMethod = nameof (readSTRINGVar);
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        int num = 1;
        if (VarName.Length > 1)
          buPLCHandler.ReadVariableSTRING(VarName, ref Val);
        str = num != 0 ? "Error" : "Ok";
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.ReadSTRINGValue(OpcVars.opcClient.Session, nodeid, ref Val);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public string readBOOLVar(CodesysVariableBaseType VarType, string Address, ref bool Val)
  {
    string callMethod = nameof (readBOOLVar);
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        int num = 1;
        if (VarName.Length > 1)
          num = buPLCHandler.ReadVariableBOOL(VarName, ref Val);
        str = num != 0 ? "Error" : "Ok";
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.ReadBOOLValue(OpcVars.opcClient.Session, nodeid, ref Val);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public string writeDINTVar(CodesysVariableBaseType VarType, int Val, string Address)
  {
    string callMethod = "writeDINTVar_";
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        int num = 1;
        if (VarName.Length > 1)
          buPLCHandler.WriteVariableDINT(VarName, (object) Val);
        str = num != 0 ? "Error" : "Ok";
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.WriteDINTValue(Val, nodeid, OpcVars.opcClient.Session);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public string writeINTVar(CodesysVariableBaseType VarType, short Val, string Address)
  {
    string callMethod = nameof (writeINTVar);
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        if (VarName.Length > 1)
          buPLCHandler.WriteVariableINT(VarName, (object) Val);
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.WriteINTValue(Val, nodeid, OpcVars.opcClient.Session);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public string writeLREALVar(CodesysVariableBaseType VarType, double Val, string Address)
  {
    string callMethod = "writeLREALVar_";
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        if (VarName.Length > 1)
          buPLCHandler.WriteVariableLREAL(VarName, (object) Val);
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.WriteLREALValue(Val, nodeid, OpcVars.opcClient.Session);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public string writeREALVar(CodesysVariableBaseType VarType, float Val, string Address)
  {
    string callMethod = nameof (writeREALVar);
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        if (VarName.Length > 1)
          buPLCHandler.WriteVariableREAL(VarName, (object) Val);
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.WriteREALValue(Val, nodeid, OpcVars.opcClient.Session);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public string writeBOOLVar(CodesysVariableBaseType VarType, bool Val, string Address)
  {
    string callMethod = "writeBOOLVar_" + Address;
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        if (VarName.Length > 1)
          buPLCHandler.WriteVariableBOOL(VarName, (object) Val);
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.WriteBOOLValue(Val, nodeid, OpcVars.opcClient.Session);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, $"Exception: {Address} = {Val.ToString()}", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, $"{Address} = {Val.ToString()}");
      return "Exception";
    }
  }

  public string writeSTRINGVar(CodesysVariableBaseType VarType, string Val, string Address)
  {
    string callMethod = "writeINTVar";
    try
    {
      string str = "None";
      if (!AppBool.Connected)
        return "NoConnection";
      string VarName = "";
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = CodesysMachine.RootGlobalString;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = CodesysMachine.RootPersistentString;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = CodesysMachine.RootIOString;
        VarName += Address;
        if (VarName.Length > 1)
          buPLCHandler.WriteVariableSTRING(VarName, (object) Val);
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (VarType == CodesysVariableBaseType.Global)
          VarName = OpcVars.pathCodesysGvl;
        if (VarType == CodesysVariableBaseType.Persistent)
          VarName = OpcVars.pathCodesysPersistent;
        if (VarType == CodesysVariableBaseType.IO)
          VarName = OpcVars.pathCodesysIO;
        string nodeid = VarName + Address;
        if (nodeid.Length > 1)
        {
          if (!OpcVars.opcClient.IsConnected)
            ;
          str = OPCReadWrite.WriteSTRINGValue(Val, nodeid, OpcVars.opcClient.Session);
          if (str != "Ok")
          {
            // ISSUE: reference to a compiler-generated field
            if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{str} - {nodeid}", (object) null, (object) null, (object) null);
            }
            clsAppMarbleVars.cMachine.WarningHistory.Add(new InfoType("Variable Error", $"{Address} = {Val.ToString()}", 0, 0.0, DateTime.Now));
          }
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      // ISSUE: reference to a compiler-generated field
      buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, callMethod, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, true);
      buException.throwException(ex, callMethod, true, "");
      return "Exception";
    }
  }

  public void CommunicationVariableInit()
  {
    CodesysMachine.RootIOString = clsAppMarbleVars.cMachine.PLCSettings.RootIOString;
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "sysRun.activeData.activeFeedSpeed"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "sysRun.activeData.activeSpindleSpeed"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "sysRun.activeData.activeSawSpeed"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootPersistentString + "sysSet.Feed.FeedOverrideG0"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootPersistentString + "sysSet.Feed.FeedOverrideG1"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "AppRun.SpindleOverride"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "AppRun.SpindleCurrent"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "AxisRunX.activeAX.actualCurrent"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "AxisRunY.activeAX.actualCurrent"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "AxisRunZ.activeAX.actualCurrent"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "AxisRunA.activeAX.actualCurrent"));
    clsAppMarbleVars.cMachine.ReadVarLReal.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + "AxisRunC.activeAX.actualCurrent"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootGlobalString + "sysRun.Alarms.AlarmCount"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootGlobalString + "sysRun.Warnings.WarningCount"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootGlobalString + "sysRun.Status"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootGlobalString + "sysRun.activeData.activeLine"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootPersistentString + "appSet.toolActiveNo"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootGlobalString + "sysRun.miscInfo.systemBool32BitValue"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootGlobalString + "sysRun.miscInfo.appBool32BitValue1"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootGlobalString + "sysRun.miscInfo.appBool32BitValue2"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootGlobalString + "AppRun.ActiveToolType"));
    clsAppMarbleVars.cMachine.ReadVarDint.Add(new VariableDINTDef(CodesysMachine.RootGlobalString + "AppRun.MarbleWarningCount"));
    clsAppMarbleVars.cMachine.ReadVarBool.Add(new VariableBOOLDef(CodesysMachine.RootGlobalString + "AppRun.SawActivated"));
    clsAppMarbleVars.cMachine.ReadVarBool.Add(new VariableBOOLDef(CodesysMachine.RootGlobalString + "AppRun.MillingActivated"));
    clsAppMarbleVars.cMachine.ReadVarBool.Add(new VariableBOOLDef(CodesysMachine.RootGlobalString + "AppRun.MillingHeadActivated"));
    clsAppMarbleVars.cMachine.ReadVarBool.Add(new VariableBOOLDef(CodesysMachine.RootGlobalString + "sysRun.exeCmd.UpdateToolAtPC"));
    for (int index = 0; index <= clsAppMarbleVars.cMachine.Inputs.Count - 1; ++index)
    {
      clsAppMarbleVars.cMachine.Inputs[index].FullAddress = $"{CodesysMachine.RootGlobalString}IO.{clsAppMarbleVars.cMachine.Inputs[index].Name}";
      clsAppMarbleVars.cMachine.ReadVarInputBool.Add(new VariableBOOLDef(clsAppMarbleVars.cMachine.Inputs[index].FullAddress + ".MStatus"));
    }
    for (int index = 0; index <= clsAppMarbleVars.cMachine.Outputs.Count - 1; ++index)
    {
      clsAppMarbleVars.cMachine.Outputs[index].FullAddress = $"{CodesysMachine.RootGlobalString}IO.{clsAppMarbleVars.cMachine.Outputs[index].Name}";
      clsAppMarbleVars.cMachine.ReadVarOutputBool.Add(new VariableBOOLDef(clsAppMarbleVars.cMachine.Outputs[index].FullAddress + ".MStatus"));
    }
    buPLCHandler.CommError += new buPLCHandler.PLCHandlerCommError(clsAppMarbleVars.cmdMarble.PlcHandlerCommError);
    clsAppMarbleItems.timPlcHandlerRelease.Interval = 1000;
    clsAppMarbleItems.timPlcHandlerRelease.Tick += new EventHandler(this.tick_PlcHandleRelease);
    clsAppMarbleItems.timPlcHandlerRelease.Enabled = true;
  }

  public void OPCUAInit(bool reconnect)
  {
    OpcVars.OpcName = "CMD";
    OpcVars.OpcUrl = $"opc.tcp://{clsAppMarbleVars.cMachine.PLCSettings.IPNumber}:4840";
    OpcVars.FirstNode = clsAppMarbleVars.cMachine.PLCSettings.RootGlobalString;
    OpcVars.opcClient = new OpcClient(OpcVars.OpcName, OpcVars.OpcUrl, OpcVars.FirstNode);
    OpcVars.pathCodesysGvl = clsAppMarbleVars.cMachine.PLCSettings.RootGlobalString;
    OpcVars.pathCodesysIO = clsAppMarbleVars.cMachine.PLCSettings.RootIOString;
    OpcVars.pathCodesysCNC = clsAppMarbleVars.cMachine.PLCSettings.RootCNCString;
    OpcVars.pathCodesysPersistent = clsAppMarbleVars.cMachine.PLCSettings.RootPersistentString;
    CodesysMachine.RootPersistentString = OpcVars.pathCodesysPersistent;
    CodesysMachine.RootGlobalString = OpcVars.pathCodesysGvl;
    CodesysMachine.RootIOString = OpcVars.pathCodesysIO;
    CodesysMachine.RootCNCString = OpcVars.pathCodesysCNC;
  }

  public void PLCHanderInit(bool reconnect)
  {
    if (reconnect)
      buPLCHandler.DisConnectPLC();
    if (clsAppMarbleVars.cMachine.PLCSettings.RootGlobalString.Trim().Length > 0)
      CodesysMachine.RootGlobalString = clsAppMarbleVars.cMachine.PLCSettings.RootGlobalString.Trim();
    if (clsAppMarbleVars.cMachine.PLCSettings.RootPersistentString.Trim().Length > 0)
      CodesysMachine.RootPersistentString = clsAppMarbleVars.cMachine.PLCSettings.RootPersistentString.Trim();
    if (clsAppMarbleVars.cMachine.PLCSettings.RootIOString.Trim().Length > 0)
      CodesysMachine.RootIOString = clsAppMarbleVars.cMachine.PLCSettings.RootIOString.Trim();
    if (clsAppMarbleVars.cMachine.PLCSettings.RootCNCString.Trim().Length > 0)
      CodesysMachine.RootCNCString = clsAppMarbleVars.cMachine.PLCSettings.RootCNCString.Trim();
    buPLCHandler.DeviceAddress = clsAppMarbleVars.cMachine.PLCSettings.DeviceAddress;
    buPLCHandler.DeviceIP = clsAppMarbleVars.cMachine.PLCSettings.IPNumber;
    buPLCHandler.DeviceName = clsAppMarbleVars.cMachine.PLCSettings.DeviceName;
    if (!clsAppMarbleVars.cMachine.PLCSettings.UseSecondDeviceName)
    {
      buPLCHandler.ConnectPLC(clsAppMarbleVars.cMachine.PLCSettings.ConnectMethodByIP);
    }
    else
    {
      buPLCHandler.DeviceName = clsAppMarbleVars.cMachine.PLCSettings.DeviceNameSecond;
      buPLCHandler.ConnectPLC(clsAppMarbleVars.cMachine.PLCSettings.ConnectMethodByIP);
    }
    if (!buPLCHandler.isConnect & clsAppMarbleVars.cMachine.PLCSettings.ConnectMethodByIP)
    {
      buPLCHandler.DisConnectPLC();
      buPLCHandler.DeviceAddress = clsAppMarbleVars.cMachine.PLCSettings.DeviceAddressSecond;
      buPLCHandler.ConnectPLC(clsAppMarbleVars.cMachine.PLCSettings.ConnectMethodByIP);
    }
    AppBool.Connected = buPLCHandler.isConnect;
  }

  public void InitAxesString()
  {
    if (clsAppMarbleVars.cMachine.AppAxis.Count <= 0)
      return;
    string axisXchar = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisXChar;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strRuntimeVar = $"AxisRun{axisXchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strSettingsVar = $"AxisSet{axisXchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strRunExe = $"AxisRun{axisXchar}.exeAX.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strRunBool = $"AxisRun{axisXchar}.boolAX.";
    string axisYchar = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisYChar;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strRuntimeVar = $"AxisRun{axisYchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strSettingsVar = $"AxisSet{axisYchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strRunExe = $"AxisRun{axisYchar}.exeAX.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strRunBool = $"AxisRun{axisYchar}.boolAX.";
    string axisZchar = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisZChar;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strRuntimeVar = $"AxisRun{axisZchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strSettingsVar = $"AxisSet{axisZchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strRunExe = $"AxisRun{axisZchar}.exeAX.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strRunBool = $"AxisRun{axisZchar}.boolAX.";
    string axisCchar = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisCChar;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strRuntimeVar = $"AxisRun{axisCchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strSettingsVar = $"AxisSet{axisCchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strRunExe = $"AxisRun{axisCchar}.exeAX.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strRunBool = $"AxisRun{axisCchar}.boolAX.";
    string axisAchar = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisAChar;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strRuntimeVar = $"AxisRun{axisAchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strSettingsVar = $"AxisSet{axisAchar}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strRunExe = $"AxisRun{axisAchar}.exeAX.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strRunBool = $"AxisRun{axisAchar}.boolAX.";
    string axisY2Char = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AxisY2Char;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strRuntimeVar = $"AxisRun{axisY2Char}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strSettingsVar = $"AxisSet{axisY2Char}.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strRunExe = $"AxisRun{axisY2Char}.exeAX.";
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Strings.strRunBool = $"AxisRun{axisY2Char}.boolAX.";
    StringSystem.strAppRuntimeVar = "AppRun.";
    StringSystem.strAppSettingsVar = "appSet.";
    StringSystem.strSystemRuntimeVar = "sysRun.";
    StringSystem.strSystemSettingsVar = "sysSet.";
    StringSystem.strCNCRuntimeVar = "CncRunMaster.";
    StringSystem.strCNCSettingsVar = "CncSetMaster.";
    StringSystem.strKinematicVar = "Kinematic.";
  }

  public void ThreadLoopExtension()
  {
    if (clsAppMarbleVars.cMachine.runSystem.AxesMessageAvailable)
      this.ReadAxesAllowMessages();
    if (clsAppMarbleVars.varRuntime.isMaintanenceVisible)
      this.ReadMaintananceVariables();
    if (!clsAppMarbleVars.varRuntime.isMaintanenceVisible)
      return;
    this.ReadWarmUpVariables();
  }

  public void SentToController(string FileName)
  {
    if (!AppBool.Connected)
    {
      // ISSUE: reference to a compiler-generated field
      if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) buLangTranslate.preMotionWarning.NotConnected, (object) null, (object) null, (object) null);
    }
    else if (!new FileInfo(FileName).Exists)
    {
      buString.MessageBoxWarning(buLangTranslate.preMotionMessage.FileisNotAvailable);
    }
    else
    {
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "sysRun.boolData.bFileLoaded");
      clsAppMarbleVars.cMachine.bWriteAppParameter = true;
      FTPConnect ftpConnect = new FTPConnect();
      FTPConnect.ftpConnectionProperties.IP = clsAppMarbleVars.cMachine.PLCSettings.IPNumber;
      FTPConnect.ftpConnectionProperties.UserName = clsAppMarbleVars.cMachine.PLCSettings.FtpUser;
      FTPConnect.ftpConnectionProperties.Password = clsAppMarbleVars.cMachine.PLCSettings.FtpPassword;
      FTPConnect.ftpConnectionProperties.Port = clsAppMarbleVars.cMachine.PLCSettings.FtpPort;
      ftpConnect.FtpClientConnect();
      if (!ftpConnect.FtpClientFileTransfer(FileName, clsAppMarbleVars.cMachine.PLCSettings.pathDeviceSend + clsAppMarbleVars.cMachine.PLCSettings.pathCncFileName))
      {
        // ISSUE: reference to a compiler-generated field
        if (((clsAppMarble.\u003C\u003Ec) this).\u0002 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) $"{buLangTranslate.preMotionWarning.FileNotLoaded} : {FileName}", (object) null, (object) null, (object) null);
      }
      else
      {
        clsInit.appMarble.activeJob.isFileSend = true;
        clsAppMarbleVars.cMachine.miscVar.LoadedFileName = FileName;
        this.writeDINTVar(CodesysVariableBaseType.Global, AppProcess.GCodeTotalLineCount, "CncRunMaster.iGCodeTotalLineNumber");
        this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.boolData.bFileLoaded");
      }
    }
  }

  public void PlcHandlerCommError(string Error)
  {
    // ISSUE: reference to a compiler-generated field
    if (((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) Error, (object) null, (object) null, (object) null);
    }
    // ISSUE: reference to a compiler-generated field
    buLogMarbleVer5.addToLog(((clsAppMarble.\u003C\u003Ec) this).\u0001, nameof (PlcHandlerCommError), Error, "PLCHandlerError", "", 0.0, 0.0, true);
    buPLCHandler.ThreatCount = 0;
    buPLCHandler.ThreadWaitCount = 500000000;
  }

  public void tick_PlcHandleRelease(object sender, EventArgs e)
  {
    clsAppMarbleItems.timPlcHandlerRelease.Enabled = false;
    buPLCHandler.ThreadEnable = true;
  }

  public void WriteSettingsParameter()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      if (clsAppMarbleVars.cMachine.varSystem.ParameterTransfer == ParameterTransferType.FromVariable)
      {
        for (int index = 0; index <= clsAppMarbleVars.cMachine.AppAxis.Count - 1; ++index)
          clsAppMarbleVars.cMachine.Commands.WriteAxisData(CodesysMachine.RootPersistentString + clsAppMarbleVars.cMachine.AppAxis[index].AxisPar.Strings.strSettingsVar, clsAppMarbleVars.cMachine.AppAxis[index], false, true, true, true, true, true, true);
        clsAppMarbleVars.cMachine.Commands.WriteCNCDataFullSTring(CodesysMachine.RootPersistentString + "CncSetMaster.", clsAppMarbleVars.cMachine.varCNC);
        clsAppMarbleVars.cMachine.Commands.WriteSystemData(CodesysMachine.RootPersistentString, clsAppMarbleVars.cMachine.varSystem);
      }
      else
      {
        List<string> AxisList = new List<string>();
        clsAppMarbleVars.cMachine.Commands.CreateAxesParFileItems(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX], "AxisX", ref AxisList);
        clsAppMarbleVars.cMachine.Commands.CreateAxesParFileItems(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY], "AxisY", ref AxisList);
        clsAppMarbleVars.cMachine.Commands.CreateAxesParFileItems(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ], "AxisZ", ref AxisList);
        clsAppMarbleVars.cMachine.Commands.CreateAxesParFileItems(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC], "AxisC", ref AxisList);
        clsAppMarbleVars.cMachine.Commands.CreateAxesParFileItems(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA], "AxisA", ref AxisList);
        if (clsAppMarbleVars.varRuntime.AxY2 >= 0 & clsAppMarbleVars.varRuntime.AxY2 <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
          clsAppMarbleVars.cMachine.Commands.CreateAxesParFileItems(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2], "AxisY2", ref AxisList);
        buFile5.SaveToFile(AxisList, AppPath.Base + "\\PLCSettings.par");
        FTPConnect ftpConnect = new FTPConnect();
        FTPConnect.ftpConnectionProperties.IP = clsAppMarbleVars.cMachine.PLCSettings.IPNumber;
        FTPConnect.ftpConnectionProperties.UserName = "admin_B";
        FTPConnect.ftpConnectionProperties.Password = "admin";
        FTPConnect.ftpConnectionProperties.Port = clsAppMarbleVars.cMachine.PLCSettings.FtpPort;
        ftpConnect.FtpClientConnect();
        // ISSUE: reference to a compiler-generated field
        if (!ftpConnect.FtpClientFileTransfer(AppPath.Base + "\\PLCSettings.par", clsAppMarbleVars.cMachine.PLCSettings.pathDeviceSend + clsAppMarbleVars.cMachine.PLCSettings.pathSystemSetFileName) && ((clsAppMarble.\u003C\u003Ec) this).\u0002 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((clsAppMarble.\u003C\u003Ec) this).\u0002((object) (MarbleHMICommands) 1, (object) (buLangTranslate.preMotionWarning.FileNotLoaded + " : PLCSettings.par"), (object) null, (object) null, (object) null);
        }
      }
      this.ClickCommand((MarbleMotionCommands) 52);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void WriteAppParameter()
  {
    if (!AppBool.Connected)
      return;
    if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      buPLCHandler.ClassToPLC((object) clsAppMarbleVars.varApp, CodesysMachine.RootPersistentString + "appSet.");
    if (CodesysMachine.CommType != CommunicationType.OPCUA)
      return;
    OPCReadWrite.ClassToPLC((object) clsAppMarbleVars.varApp, CodesysMachine.RootPersistentString + "appSet.", OpcVars.opcClient.Session, "");
  }

  public void WriteMiscParameter()
  {
    int tickCount = Environment.TickCount;
    try
    {
      if (!AppBool.Connected)
        return;
      clsAppMarbleVars.cMachine.Commands.WriteAxisMiscData(CodesysMachine.RootPersistentString + clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Strings.strSettingsVar, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX]);
      clsAppMarbleVars.cMachine.Commands.WriteAxisMiscData(CodesysMachine.RootPersistentString + clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Strings.strSettingsVar, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY]);
      clsAppMarbleVars.cMachine.Commands.WriteAxisMiscData(CodesysMachine.RootPersistentString + clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Strings.strSettingsVar, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ]);
      clsAppMarbleVars.cMachine.Commands.WriteAxisMiscData(CodesysMachine.RootPersistentString + clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Strings.strSettingsVar, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC]);
      if (clsAppMarbleVars.varRuntime.AxA < 0)
        return;
      clsAppMarbleVars.cMachine.Commands.WriteAxisMiscData(CodesysMachine.RootPersistentString + clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Strings.strSettingsVar, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void WriteG54()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      clsAppMarbleVars.cMachine.Commands.WriteG54Data(CodesysMachine.RootPersistentString, 10, clsAppMarbleVars.cMachine.G54List);
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ParameterCNCUpdate");
      this.ClickCommand((MarbleMotionCommands) 52);
      this.ClickCommand((MarbleMotionCommands) 53);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void WriteIO()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      clsAppMarbleVars.cMachine.Commands.WriteIOData(clsAppMarbleVars.cMachine);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void WriteAlarmAction()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      clsAppMarbleVars.cMachine.Commands.WriteAlarmActionData(CodesysMachine.RootPersistentString, clsAppMarbleVars.cMachine.varAlarmActions);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void WriteParks()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      clsAppMarbleVars.cMachine.Commands.WriteParkData(CodesysMachine.RootPersistentString, 10, clsAppMarbleVars.cMachine.ParkList);
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ParameterCNCUpdate");
      this.ClickCommand((MarbleMotionCommands) 52);
      this.ClickCommand((MarbleMotionCommands) 53);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void WriteToolParameter(bool MillingHead)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.activeToolSaw.Geometry.Diameter, "sysSet.toolActiveSaw.Diameter");
      this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.activeToolSaw.Geometry.Thickness, "sysSet.toolActiveSaw.Thickness");
      this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.activeToolMilling.Geometry.Length, "sysSet.toolActiveSpindle.Length");
      if (MillingHead)
        this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.activeToolMillingHead.Geometry.Length, "sysSet.toolActiveSpindleHead.Length");
      if (buMarbleCalc.ToolInMagazine == null)
        return;
      for (int index = 1; index <= clsAppMarbleVars.varApp.ToolChangeCount; ++index)
      {
        if (index <= buMarbleCalc.ToolInMagazine.Count - 1)
        {
          this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.ToolInMagazine[index].Geometry.Length, $"sysSet.ToolsList[{index.ToString()}].Length");
          this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.ToolInMagazine[index].Geometry.Diameter, $"sysSet.ToolsList[{index.ToString()}].Diameter");
          this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.ToolInMagazine[index].Geometry.Thickness, $"sysSet.ToolsList[{index.ToString()}].Thickness");
          this.writeDINTVar(CodesysVariableBaseType.Persistent, buMarbleCalc.ToolInMagazine[index].Data.No, $"sysSet.ToolsList[{index.ToString()}].No");
          this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.ToolInMagazine[index].Positions.Position.X, $"sysSet.ToolsList[{index.ToString()}].XPosition");
          this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.ToolInMagazine[index].Positions.Position.Y, $"sysSet.ToolsList[{index.ToString()}].YPosition");
          this.writeLREALVar(CodesysVariableBaseType.Persistent, buMarbleCalc.ToolInMagazine[index].Positions.Position.Z, $"sysSet.ToolsList[{index.ToString()}].ZPosition");
        }
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void WriteSemiAutoParameters()
  {
    this.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.SemiAutoWidth, "appSet.SemiAutoWidth");
    this.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.SemiAutoHeight, "appSet.SemiAutoHeight");
    this.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.SemiAutoCutFeed, "appSet.SemiAutoCutFeed");
    this.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.SemiAutoPlungeFeed, "appSet.SemiAutoPlungeFeed");
    this.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.SemiAutoTargetZ, "appSet.SemiAutoTargetZ");
    this.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.SemiAutoSafeZ, "appSet.SemiAutoSafeZ");
    this.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.MaterialHeight, "appSet.MaterialHeight");
    this.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.MaterialWidth, "appSet.MaterialWidth");
    this.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.MaterialThickness, "appSet.MaterialThickness");
    AppBool.SaveByTick = true;
  }

  public void WatchWriteVariables(List<WatchItem> Items)
  {
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (Items[index].Name.Length > 2 & Items[index].VarType == VariableType.Bool & Items[index].NewValue.Length > 0 && Items[index].NewValue.ToLower() == "true" | Items[index].NewValue.ToLower() == "false")
        this.writeBOOLVar(CodesysVariableBaseType.None, Convert.ToBoolean(Items[index].NewValue), Items[index].Name);
      if (Items[index].Name.Length > 2 & Items[index].VarType == VariableType.LREAL & Items[index].NewValue.Length > 0 && buNumeric5.IsNumeric(Items[index].NewValue))
        this.writeLREALVar(CodesysVariableBaseType.None, Convert.ToDouble(Items[index].NewValue), Items[index].Name);
      if (Items[index].Name.Length > 2 & Items[index].VarType == VariableType.DINT & Items[index].NewValue.Length > 0 && buNumeric5.IsNumeric(Items[index].NewValue))
        this.writeDINTVar(CodesysVariableBaseType.None, Convert.ToInt32(Items[index].NewValue), Items[index].Name);
      if (Items[index].Name.Length > 2 & Items[index].VarType == VariableType.REAL & Items[index].NewValue.Length > 0 && buNumeric5.IsNumeric(Items[index].NewValue))
        this.writeREALVar(CodesysVariableBaseType.None, Convert.ToSingle(Items[index].NewValue), Items[index].Name);
      if (Items[index].Name.Length > 2 & Items[index].VarType == VariableType.INT & Items[index].NewValue.Length > 0 && buNumeric5.IsNumeric(Items[index].NewValue))
        this.writeINTVar(CodesysVariableBaseType.None, Convert.ToInt16(Items[index].NewValue), Items[index].Name);
    }
  }

  public void WatchListChanged(List<WatchItem> Items)
  {
  }

  public void WatchReset()
  {
  }

  public void WatchRemoveAll()
  {
  }

  public void WatchRemove(int Index)
  {
  }

  public void ReadLRealValues()
  {
    if (clsAppMarbleVars.cMachine.ReadVarLReal.Count <= 0)
      return;
    if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      buPLCHandler.ReadMultiVariableLREAL(ref clsAppMarbleVars.cMachine.ReadVarLReal);
    if (CodesysMachine.CommType == CommunicationType.OPCUA)
      OPCReadWrite.ReadLREALsValueFromVariables(OpcVars.opcClient.Session, ref clsAppMarbleVars.cMachine.ReadVarLReal);
    clsAppMarbleVars.cMachine.runCNC.FeedVelocity = clsAppMarbleVars.cMachine.ReadVarLReal[0].Value;
    clsAppMarbleVars.cMachine.runSystem.SpindleSpeed = clsAppMarbleVars.cMachine.ReadVarLReal[1].Value;
    clsAppMarbleVars.cMachine.runSystem.SawSpeed = clsAppMarbleVars.cMachine.ReadVarLReal[2].Value;
    clsAppMarbleVars.cMachine.runSystem.FeedOverrideG0 = clsAppMarbleVars.cMachine.ReadVarLReal[3].Value;
    clsAppMarbleVars.cMachine.runSystem.FeedOverrideG1 = clsAppMarbleVars.cMachine.ReadVarLReal[4].Value;
    clsAppMarbleVars.cMachine.runSystem.SpindleOverride = clsAppMarbleVars.cMachine.ReadVarLReal[5].Value;
    clsAppMarbleVars.cMachine.runSystem.SpindleActualCurrent = clsAppMarbleVars.cMachine.ReadVarLReal[6].Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualCurrent = clsAppMarbleVars.cMachine.ReadVarLReal[7].Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualCurrent = clsAppMarbleVars.cMachine.ReadVarLReal[8].Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualCurrent = clsAppMarbleVars.cMachine.ReadVarLReal[9].Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualCurrent = clsAppMarbleVars.cMachine.ReadVarLReal[10].Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualCurrent = clsAppMarbleVars.cMachine.ReadVarLReal[11].Value;
  }

  public void ReadRealValues()
  {
    if (clsAppMarbleVars.cMachine.ReadVarReal.Count <= 0)
      return;
    if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      buPLCHandler.ReadMultiVariableREAL(ref clsAppMarbleVars.cMachine.ReadVarReal);
    if (CodesysMachine.CommType != CommunicationType.OPCUA)
      return;
    OPCReadWrite.ReadREALsValueFromVariables(OpcVars.opcClient.Session, ref clsAppMarbleVars.cMachine.ReadVarReal);
  }

  public void ReadDINTValues()
  {
    if (clsAppMarbleVars.cMachine.ReadVarDint.Count <= 0)
      return;
    if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      buPLCHandler.ReadMultiVariableDINT(ref clsAppMarbleVars.cMachine.ReadVarDint);
    if (CodesysMachine.CommType == CommunicationType.OPCUA)
      OPCReadWrite.ReadDINTsValueFromVariables(OpcVars.opcClient.Session, ref clsAppMarbleVars.cMachine.ReadVarDint);
    clsAppMarbleVars.cMachine.runSystem.AlarmCount = clsAppMarbleVars.cMachine.ReadVarDint[0].Value;
    clsAppMarbleVars.cMachine.runSystem.WarningCount = clsAppMarbleVars.cMachine.ReadVarDint[1].Value;
    clsAppMarbleVars.cMachine.runSystem.Status = clsAppMarbleVars.cMachine.ReadVarDint[2].Value;
    clsAppMarbleVars.cMachine.runCNC.ActiveLine = clsAppMarbleVars.cMachine.ReadVarDint[3].Value;
    clsAppMarbleVars.cMachine.runSystem.ActiveSpindleNo = clsAppMarbleVars.cMachine.ReadVarDint[4].Value;
    clsAppMarbleVars.cMachine.miscVar.systemBool32BitValue = clsAppMarbleVars.cMachine.ReadVarDint[5].Value;
    clsAppMarbleVars.cMachine.miscVar.appBool32BitValue1 = clsAppMarbleVars.cMachine.ReadVarDint[6].Value;
    clsAppMarbleVars.cMachine.miscVar.appBool32BitValue2 = clsAppMarbleVars.cMachine.ReadVarDint[7].Value;
    clsAppMarbleVars.cMachine.runSystem.ActiveToolType = clsAppMarbleVars.cMachine.ReadVarDint[8].Value;
    clsAppMarbleVars.varRuntime.MarbleWarningCount = clsAppMarbleVars.cMachine.ReadVarDint[9].Value;
  }

  public void ReadBOOLValues()
  {
    if (clsAppMarbleVars.cMachine.ReadVarBool.Count <= 0)
      return;
    if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      buPLCHandler.ReadMultiVariableBOOL(ref clsAppMarbleVars.cMachine.ReadVarBool);
    if (CodesysMachine.CommType == CommunicationType.OPCUA)
      OPCReadWrite.ReadBOOLsValueFromVariables(OpcVars.opcClient.Session, ref clsAppMarbleVars.cMachine.ReadVarBool);
    clsAppMarbleVars.cMachine.runSystem.isSawActivated = clsAppMarbleVars.cMachine.ReadVarBool[0].Value;
    clsAppMarbleVars.cMachine.runSystem.isMillingActivated = clsAppMarbleVars.cMachine.ReadVarBool[1].Value;
    clsAppMarbleVars.cMachine.runSystem.isMillingHeadActivated = clsAppMarbleVars.cMachine.ReadVarBool[2].Value;
    clsAppMarbleVars.cMachine.runSystem.ToolUpdate = clsAppMarbleVars.cMachine.ReadVarBool[3].Value;
  }

  public void ReadMaintananceVariables()
  {
    this.readLREALVar(CodesysVariableBaseType.Persistent, "AxisSetX.setMeasure.maintenanceTotalMeter", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Misc.maintenanceTotalMeter);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "AxisSetY.setMeasure.maintenanceTotalMeter", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Misc.maintenanceTotalMeter);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "AxisSetZ.setMeasure.maintenanceTotalMeter", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Misc.maintenanceTotalMeter);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "AxisSetA.setMeasure.maintenanceTotalMeter", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Misc.maintenanceTotalMeter);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "AxisSetC.setMeasure.maintenanceTotalMeter", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Misc.maintenanceTotalMeter);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.Measure.MaintenanceAirHour", ref clsAppMarbleVars.cMachine.miscVar.MaintenanceAirHour);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.Measure.MaintenanceHydraulicHour", ref clsAppMarbleVars.cMachine.miscVar.MaintenanceHydraulicHour);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.Measure.MaintenanceLubricateHour", ref clsAppMarbleVars.cMachine.miscVar.MaintenanceLubricateHour);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.Measure.MaintenanceCabinetHour", ref clsAppMarbleVars.cMachine.miscVar.MaintenanceCabinetHour);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.Measure.MaintenanceMachineCleaningHour", ref clsAppMarbleVars.cMachine.miscVar.MaintenanceMachineCleaningHour);
  }

  public void ReadAxesAllowMessages()
  {
    this.readSTRINGVar(CodesysVariableBaseType.Global, "appRun.XJogNotAllowMessage", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Misc.AxisNotAllowMessage);
    this.readSTRINGVar(CodesysVariableBaseType.Global, "appRun.YJogNotAllowMessage", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Misc.AxisNotAllowMessage);
    this.readSTRINGVar(CodesysVariableBaseType.Global, "appRun.ZJogNotAllowMessage", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Misc.AxisNotAllowMessage);
    this.readSTRINGVar(CodesysVariableBaseType.Global, "appRun.AJogNotAllowMessage", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Misc.AxisNotAllowMessage);
    this.readSTRINGVar(CodesysVariableBaseType.Global, "appRun.CJogNotAllowMessage", ref clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Misc.AxisNotAllowMessage);
  }

  public void ReadIOData()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      clsAppMarbleVars.cMachine.Commands.ReadIOData(ref clsAppMarbleVars.cMachine);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void ReadWarmUpVariables()
  {
    this.readDINTVar(CodesysVariableBaseType.Global, "AppRun.WarmUpSawPhase", ref clsAppMarbleVars.cMachine.miscVar.WarmUpSawPhase);
    this.readDINTVar(CodesysVariableBaseType.Global, "AppRun.WarmUpMillingPhase", ref clsAppMarbleVars.cMachine.miscVar.WarmUpSpindlePhase);
  }

  public void ReadTools(bool MagazineRead)
  {
    this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.toolActiveSaw.Diameter", ref buMarbleCalc.activeToolSaw.Geometry.Diameter);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.toolActiveSaw.Thickness", ref buMarbleCalc.activeToolSaw.Geometry.Thickness);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.toolActiveSpindle.Length", ref buMarbleCalc.activeToolMilling.Geometry.Length);
    this.readDINTVar(CodesysVariableBaseType.Persistent, "sysSet.toolActiveSpindle.No", ref buMarbleCalc.activeToolMilling.Data.No);
    this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.toolActiveSpindleHead.Length", ref buMarbleCalc.activeToolMillingHead.Geometry.Length);
    if (!(MagazineRead & clsAppMarbleVars.varApp.ToolChangeCount > 0 & buMarbleCalc.ToolInMagazine != null))
      return;
    for (int index = 1; index <= clsAppMarbleVars.varApp.ToolChangeCount; ++index)
    {
      if (index <= buMarbleCalc.ToolInMagazine.Count - 1)
        this.readLREALVar(CodesysVariableBaseType.Persistent, $"sysSet.ToolsList[{index.ToString()}].Length", ref buMarbleCalc.ToolInMagazine[index].Geometry.Length);
    }
  }
}
