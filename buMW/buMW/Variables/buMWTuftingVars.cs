// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWTuftingVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks;

#nullable disable
namespace buMW.Variables;

public class buMWTuftingVars
{
  public static MWParameters varCamContouring;
  public static MWParameters varCamSurface4Axis;

  public static void Init()
  {
    buMWRoboticVars.varCamMeshRough3Axis = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamMeshRough4Axis = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamMeshParallel3Axis = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamMeshParallel4Axis = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamMeshParallel5Axis = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamMeshConstantZ3Axis = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamMeshConstantZ4Axis = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamMeshConstantZ5Axis = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamWFContour = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamWFPocket = new MWParameters(Unit.Metric, 0);
    buMWRoboticVars.varCamDrill = new MWParameters(Unit.Metric, 0);
    buMWTuftingVars.varCamContouring = new MWParameters(Unit.Metric, 0);
    buMWTuftingVars.varCamSurface4Axis = new MWParameters(Unit.Metric, 0);
    buMWProfileVars.varCamSurface5Axis = new MWParameters(Unit.Metric, 0);
  }
}
