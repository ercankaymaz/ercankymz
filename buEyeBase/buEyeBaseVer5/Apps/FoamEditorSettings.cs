// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamEditorSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamEditorSettings : buSerilization5
{
  public static byte f003C32;
  public string Name;
  public double PipeDiameter;
  public List<BendingLRAMaterialData> BendingList;
  public List<PipeBendMove> Moves;
  public List<PipeBendSimulationMove> SimMoves;

  public abstract void m001ACC();

  public FoamEditorSettings()
  {
    ((FoamPatternInfo) this).CamName = "";
    ((FoamPatternInfo) this).isError = false;
    ((FoamPatternInfo) this).Enable = true;
    ((FoamPatternInfo) this).MinPoint = new Point3D();
    ((FoamPatternInfo) this).MaxPoint = new Point3D();
    ((FoamSettings) this).planeName = planeBoxNames.Top;
    ((FoamSettings) this).CamData = new camTp();
    ((FoamSettings) this).Tool = (ToolBase5) new ToolGeometry5();
    ((FoamSettings) this).CamPars = new camParameters5();
    ((FoamSettings) this).CamEntities = new List<buEntity>();
    ((FoamSettings) this).entitiesPlane = (Router3AXCamPlane) null;
    ((FoamSettings) this).camMode = CamMode.WireFrame;
    ((FoamSettings) this).camWireframeType = CamWireFrameType.Contour;
    ((FoamSettings) this).camMeshType = CamTriangularMeshType.ParallelCuts;
    ((FoamSettings) this).camMesh5AXType = CamTriangularMesh5AxType.ParallelCuts;
    ((FoamSettings) this).camSurfType = CamSurfaceType.SurfaceParalel;
    ((FoamSettings) this).camDrillType = CamDrillType.Point;
    ((FoamSettings) this).Purpose = Router3AXLayerPurpose.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
