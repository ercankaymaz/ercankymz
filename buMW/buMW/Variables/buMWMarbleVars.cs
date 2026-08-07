// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWMarbleVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks;

#nullable disable
namespace buMW.Variables;

public class buMWMarbleVars
{
  public static MWParameters varCamMeshRough;
  public static MWParameters varCamFoam;
  public static MWParameters varCamCutter;
  public static MWParameters varCamMarbleMesh5AxisRotaryRough;
  public static MWParameters varCamMarbleMesh5AxisRotaryFinish;
  public static MWParameters varCamMarbleMesh4AxisRotaryFinish;
  public static MWParameters varCamMarbleSawMillingHorizontalRough;
  public static MWParameters varCamMarbleSawMillingHorizontalFinish;
  public static MWParameters varCamMarbleSawMillingVerticalRough;
  public static MWParameters varCamMarbleSawMillingVerticalFinish;
  public static MWParameters varCamMarbleSawCornerCleaning;
  public static MWParameters varCamMarbleMeshRough;
  public static MWParameters varCamMarbleMeshParelelCut;
  public static MWParameters varCamMarbleMeshConstantZ;
  public static MWParameters varCamMarbleMeshFlatland;
  public static MWParameters varCamMarbleMeshPencil;
  public static MWParameters varCamMarbleMeshConstantCusp;
  public static MWParameters varCamMarbleMeshProjectionAroundFinish;
  public static MWParameters varCamMarbleMeshProjectionAroundRough;
  public static MWParameters varCamMarbleMeshProjectionAlongFinish;
  public static MWParameters varCamMarbleMeshProjectionAlongRough;
  public static MWParameters varCamMarbleMesh5DParelelCut;
  public static MWParameters varCamMarbleMesh5DConstantZ;
  public static MWParameters varCamMarbleMesh5DGeodesic;
  public static MWParameters varCamMarbleMilling2DRough;
  public static MWParameters varCamMarbleMilling2DContour;
  public static MWParameters varCamMarbleMilling2DCenter;
  public static MWParameters varCamMarbleMilling2DFace;
  public static MWParameters varCamMarbleMilling2DFloorFinish;
  public static MWParameters varCamMarbleMilling2DChamfer;
  public static MWParameters varCamMarbleMilling2DEngrave;
  public static MWParameters varCamMarbleMilling2DTextEngrave;
  public static MWParameters varCamMarbleMilling2DTrochoidal;
  public static MWParameters varCamMarbleWaterJetContour;
  public static MWParameters varCamMarbleAirDry;
  public static MWParameters varCamMarbleMaterialClean;
  public static MWParameters varCamMarbleSurfaceClean;
  public static MWParameters varCamMarbleDrill;
  public static MWParameters varCamMarbleContour;
  public static MWParameters varCamMarbleProfileRough;
  public static MWParameters varCamMarbleProfileFinish;
  public static MWParameters varCamMarbleSweep;
  public static MWParameters varCamMarbleColumns;
  public static MWParameters varCamMarbleLatheHor;
  public static MWParameters varCamMarbleLatheVer;
  public static MWParameters varCamMarbleOpenContourSaw;
  public static MWParameters varCamMarbleClosedContourSaw;
  public static MWParameters varCamMarbleOpenContourMilling;
  public static MWParameters varCamMarbleClosedContourMilling;
  public static MWParameters varCamMarbleOpenContourWaterJet;

  public static void Init() => buMWMarbleVars.varCamCutter = new MWParameters(Unit.Metric, 0);
}
