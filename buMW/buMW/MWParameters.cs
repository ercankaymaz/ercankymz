// Decompiled with JetBrains decompiler
// Type: buMW.MWParameters
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buEyeBaseVer5;
using devDept.Eyeshot.Entities;
using ModuleWorks;
using System.Collections.Generic;

#nullable disable
namespace buMW;

public class MWParameters
{
  public static byte f000023;
  public camParameters5 buPar;

  static MWParameters()
  {
    buMWCalcs.AdvancedTriMesh = false;
    buMWCalcs.GetProgressUpdating = false;
    buMWCalcs.varCamMeshRoughPars = (MWParameters) null;
    buMWCalcs.varCamMeshParalelPars = (MWParameters) null;
    buMWCalcs.varCamMeshContantZPars = (MWParameters) null;
    buMWCalcs.varCamMeshPencilPars = (MWParameters) null;
    buMWCalcs.varCamMeshProjectionPars = (MWParameters) null;
    buMWCalcs.varCamMeshFlatlandPars = (MWParameters) null;
    buMWCalcs.varCamMeshContantCuspPars = (MWParameters) null;
    buMWCalcs.varCamWFPocketPars = (MWParameters) null;
    buMWCalcs.varCamWFContourPars = (MWParameters) null;
    buMWCalcs.varCamWFContour4XPars = (MWParameters) null;
    buMWCalcs.varCamDrillPars = (MWParameters) null;
    buMWCalcs.varCamContouringPars = (MWParameters) null;
    buMWCalcs.varCamSurfacePars = (MWParameters) null;
    buMWCalcs.varCam3AXTo5AXPars = (MWParameters) null;
    buMWCalcs.varCamGeodesicPars = (MWParameters) null;
    buMWCalcs.OrientationLines = new List<Entity>();
    buMWCalcs.CamEntities = new List<Entity>();
    buMWCalcs.entityProjection = (List<List<Entity>>) null;
  }

  public MWParameters()
  {
    ((buCamCalcSettings) this).mwPar = new GeoLib(Unit.Metric);
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public MWParameters(Unit unit, int ifVersion)
  {
    ((buCamCalcSettings) this).mwPar = new GeoLib(Unit.Metric);
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.buPar = new camParameters5();
    ((buCamCalcSettings) this).mwPar = new GeoLib(unit, ifVersion);
  }
}
