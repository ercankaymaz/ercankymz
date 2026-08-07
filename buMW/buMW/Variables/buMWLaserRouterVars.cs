// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWLaserRouterVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks;

#nullable disable
namespace buMW.Variables;

public class buMWLaserRouterVars
{
  public static MWParameters varCamWireDrill;
  public static MWParameters varCamWireDrill4X;
  public static MWParameters varCamWireSpin;
  public static MWParameters varCamLaserWFContour;
  public static MWParameters varCamPertinaxInCut;
  public static MWParameters varCamPertinaxOutCut;
  public static MWParameters varCamPertinaxHoleCut;
  public static MWParameters varCamPertinaxTextCut;
  public static MWParameters varCamSteelContour;
  public static MWParameters varCamSteelPocket;

  public static void Init()
  {
    buMWJewelVars.varCamMeshRough = new MWParameters(Unit.Metric, 0);
    buMWJewelVars.varCamMeshParelelCut = new MWParameters(Unit.Metric, 0);
    buMWJewelVars.varCamMeshConstantZ = new MWParameters(Unit.Metric, 0);
    buMWJewelVars.varCamWirePocket = new MWParameters(Unit.Metric, 0);
    buMWJewelVars.varCamWireContour = new MWParameters(Unit.Metric, 0);
    buMWJewelVars.varCamWireContour4X = new MWParameters(Unit.Metric, 0);
    buMWLaserRouterVars.varCamWireDrill = new MWParameters(Unit.Metric, 0);
    buMWLaserRouterVars.varCamWireDrill4X = new MWParameters(Unit.Metric, 0);
    buMWLaserRouterVars.varCamWireSpin = new MWParameters(Unit.Metric, 0);
  }
}
