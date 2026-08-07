// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWFoamVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks;

#nullable disable
namespace buMW.Variables;

public class buMWFoamVars
{
  public static MWParameters varCamContour;

  public static void Init()
  {
    buMWDrillVars.varCamRough = new MWParameters(Unit.Metric, 0);
    buMWFoamVars.varCamContour = new MWParameters(Unit.Metric, 0);
    buMWCutterVars.varCamMeshParalelCut = new MWParameters(Unit.Metric, 0);
    buMWMarbleVars.varCamMeshRough = new MWParameters(Unit.Metric, 0);
  }
}
