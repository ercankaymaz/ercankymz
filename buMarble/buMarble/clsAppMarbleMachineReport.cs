// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarbleMachineReport
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buEyeBaseVer5;
using buMotion;
using System;

#nullable disable
namespace buMarble;

[Serializable]
public class clsAppMarbleMachineReport : buSerilization5
{
  public string ItemName = "";
  public TechnicianLoginInfo TechnicianInfo = new TechnicianLoginInfo();
  public DateTime ItemDate = DateTime.Now;
  public bool Status = false;
  public static byte f0002A9;
  public clsAppMarbleMachineReportItem ItemSpindleUp;
  public clsAppMarbleMachineReportItem ItemSpindleDown;
  public clsAppMarbleMachineReportItem ItemVacuumUp;
  public clsAppMarbleMachineReportItem ItemVacuumDown;
  public clsAppMarbleMachineReportItem ItemLeftSuctionCup;
  public clsAppMarbleMachineReportItem ItemRightSuctionCup;
  public clsAppMarbleMachineReportItem ItemToolMeasureUp;
  public clsAppMarbleMachineReportItem ItemToolMeasureDown;
  public clsAppMarbleMachineReportItem ItemMaterialMeasureUp;
  public clsAppMarbleMachineReportItem ItemMaterialMeasureDown;
  public clsAppMarbleMachineReportItem ItemLaserOnOff;
  public clsAppMarbleMachineReportItem ItemLeftVacuumOutOk;
  public clsAppMarbleMachineReportItem IteLeftVacuumInOk;
  public clsAppMarbleMachineReportItem ItemRightVacuumOutOk;
  public clsAppMarbleMachineReportItem ItemRightVacuumInOk;
  public clsAppMarbleMachineReportItem ItemToolBlowOnOff;
  public clsAppMarbleMachineReportItem ItemSuctionCupAirOnOff;
  public clsAppMarbleMachineReportItem ItemMagazineOpen;
  public clsAppMarbleMachineReportItem ItemMagazineClose;
  public clsAppMarbleMachineReportItem ItemMagazineUp;
  public clsAppMarbleMachineReportItem ItemMagazineDown;
  public clsAppMarbleMachineReportItem ItemToolPens;
  public clsAppMarbleMachineReportItem ItemWaterOnOff;
  public clsAppMarbleMachineReportItem ItemCameraCover;

  public clsAppMarbleMachineReport()
  {
  }

  public clsAppMarbleMachineReport(string itemname)
  {
  }
}
