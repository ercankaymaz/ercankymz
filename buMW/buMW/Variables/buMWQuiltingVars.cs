// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWQuiltingVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks;

#nullable disable
namespace buMW.Variables;

public class buMWQuiltingVars
{
  public static MWParameters varCamSteelText;

  public static void Init()
  {
    buMWLaserRouterVars.varCamLaserWFContour = new MWParameters(Unit.Metric, 0);
    buMWLaserRouterVars.varCamPertinaxInCut = new MWParameters(Unit.Metric, 0);
    buMWLaserRouterVars.varCamPertinaxOutCut = new MWParameters(Unit.Metric, 0);
    buMWLaserRouterVars.varCamPertinaxHoleCut = new MWParameters(Unit.Metric, 0);
    buMWLaserRouterVars.varCamPertinaxTextCut = new MWParameters(Unit.Metric, 0);
    buMWLaserRouterVars.varCamSteelContour = new MWParameters(Unit.Metric, 0);
    buMWLaserRouterVars.varCamSteelPocket = new MWParameters(Unit.Metric, 0);
    buMWQuiltingVars.varCamSteelText = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamWoodTop = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamWoodBottom = new MWParameters(Unit.Metric, 0);
  }
}
