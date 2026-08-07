// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWJewelVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buEyeBaseVer5;
using ModuleWorks;

#nullable disable
namespace buMW.Variables;

public class buMWJewelVars
{
  public static camParameters5 varbuDiemakerCamDrillPars;
  public static GeoLib varMWDiemakerCamScanPars;
  public static camParameters5 varbuDiemakerCamScanPars;
  public static MWParameters varCamMeshRough;
  public static MWParameters varCamMeshParelelCut;
  public static MWParameters varCamMeshConstantZ;
  public static MWParameters varCamWirePocket;
  public static MWParameters varCamWireContour;
  public static MWParameters varCamWireContour4X;

  public static void Init()
  {
    buMWDiamalerVars.varMWDiemakerCamMeshRoughPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamMeshRoughPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamMeshParalelPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamMeshParallelPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamMeshContantZPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamMeshConstantZPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamMeshPencilPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamMeshPencilPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamMeshProjectionPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamMeshProjectionPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamMeshFlatlandPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamMeshFlatlandsPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamMeshContantCuspPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamMeshConstantCuspPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamWFPocketPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamWFPocketPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamWFContourPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamWFContourPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamWFContour4XPars = new GeoLib(Unit.Metric, 0);
    buMWDiamalerVars.varbuDiemakerCamWFContour4XPars = new camParameters5();
    buMWDiamalerVars.varMWDiemakerCamDrillPars = new GeoLib(Unit.Metric, 0);
    buMWJewelVars.varbuDiemakerCamDrillPars = new camParameters5();
    buMWJewelVars.varMWDiemakerCamScanPars = new GeoLib(Unit.Metric, 0);
    buMWJewelVars.varbuDiemakerCamScanPars = new camParameters5();
  }
}
