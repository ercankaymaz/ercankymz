// Decompiled with JetBrains decompiler
// Type: buMW.buCamCalcSettings
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;

#nullable disable
namespace buMW;

public class buCamCalcSettings : buSerilization5
{
  public GeoLib mwPar;
  public bool ShowMwDialogBox;
  public double XAxisMinLimit;
  public double XAxisMaxLimit;
  public double YAxisMinLimit;
  public double YAxisMaxLimit;
  public double ZAxisMinLimit;
  public double ZAxisMaxLimit;
  public double AAxisMinLimit;
  public double AAxisMaxLimit;
  public double BAxisMinLimit;
  public double BAxisMaxLimit;
  public double CAxisMinLimit;
  public double CAxisMaxLimit;
  public bool CopyToolDataToCamData;
  public bool CopyToolFeedToCamFeed;
  public bool CopyToolPlungeFeedToCamPlungeFeed;
  public bool CopyToolRetractFeedToCamRetractFeed;
  public bool ShowProgressForm;
  public drawPropertiesType CamMarkDraw;
  public drawPropertiesType CamG0Draw;
  public drawPropertiesType CamG1Draw;
  public drawPropertiesType CamPlungeDraw;
  public drawPropertiesType CamLeaveDraw;
  public drawPropertiesType CamLeadinDraw;
  public drawPropertiesType CamLeadOutDraw;
  public drawPropertiesType CamConnectionDraw;
  public drawPropertiesType CamOtherDraw;

  public buCamCalcSettings(MWParameters data)
  {
    ((MWParameters) this).buPar = new camParameters5();
    this.mwPar = new GeoLib(Unit.Metric);
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((MWParameters) this).buPar = new camParameters5(data.buPar);
    ((buCamCalcSettings) data).mwPar.Copy(this.mwPar);
    this.mwPar.MachParam = new MachiningParams(((buCamCalcSettings) data).mwPar.MachParam);
  }

  public buCamCalcSettings()
  {
    ((buCamCalcRuntimeSettings) this).CamMarkSize = 0.5;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
