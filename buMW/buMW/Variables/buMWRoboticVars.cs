// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWRoboticVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks;

#nullable disable
namespace buMW.Variables;

public class buMWRoboticVars
{
  public static MWParameters varCamWoodTop;
  public static MWParameters varCamWoodBottom;
  public static MWParameters varCamQuilting;
  public static MWParameters varCamMeshRough3Axis;
  public static MWParameters varCamMeshRough4Axis;
  public static MWParameters varCamMeshParallel3Axis;
  public static MWParameters varCamMeshParallel4Axis;
  public static MWParameters varCamMeshParallel5Axis;
  public static MWParameters varCamMeshConstantZ3Axis;
  public static MWParameters varCamMeshConstantZ4Axis;
  public static MWParameters varCamMeshConstantZ5Axis;
  public static MWParameters varCamWFPocket;
  public static MWParameters varCamWFContour;
  public static MWParameters varCamDrill;

  public static void Init() => buMWRoboticVars.varCamQuilting = new MWParameters(Unit.Metric, 0);
}
