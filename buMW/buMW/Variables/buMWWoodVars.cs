// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWWoodVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks;

#nullable disable
namespace buMW.Variables;

public class buMWWoodVars
{
  public static MWParameters varCamMarbleHatch;
  public static MWParameters varCamRough;

  public static void Init()
  {
    buMWWoodVars.varCamRough = new MWParameters(Unit.Metric, 0);
    buMWDoorVars.varCamContour = new MWParameters(Unit.Metric, 0);
  }
}
