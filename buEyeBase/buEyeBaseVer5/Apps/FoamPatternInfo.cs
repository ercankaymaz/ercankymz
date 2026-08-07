// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamPatternInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamPatternInfo : buSerilization5
{
  public static byte f003B8C;
  public string CamName;
  public bool isError;
  public bool Enable;
  public Point3D MinPoint;
  public Point3D MaxPoint;

  public string JobCamInfoToString(camParameters5 CamPar)
  {
    string str = $"{buLangTranslate.preDef.Feed} : {CamPar.Speeds.Feed.ToString()}";
    if (CamPar.Steps.Enable)
      str = $"{str} - {buLangTranslate.preDef.Step} : {buLangTranslate.preDef.Enable}";
    return str;
  }

  public int JobCamInfoToIndex() => 38;

  public int JobCamToolToIndex(ToolBase5 Tool)
  {
    return ((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Barrel ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Bullnose ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Chamfer ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.ConvexTip ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Dove ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Flat ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.FromFile ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Laser ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Lollipop ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Saw ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Slot ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Sphere ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.Taper ? (((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType != ToolType.WateJet ? -1 : 37) : 36) : 35) : 34) : 33) : 32 /*0x20*/) : 31 /*0x1F*/) : 30) : 29) : 28) : 27) : 26) : 25) : 24;
  }

  public int JobCamToIndex(Router3AXCAM Cam)
  {
    int index;
    if (((FoamSettings) Cam).camMode == CamMode.WireFrame)
    {
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.CenterPath)
      {
        index = 2;
        goto label_51;
      }
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Chamfer2D)
      {
        index = 3;
        goto label_51;
      }
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Contour)
      {
        index = 7;
        goto label_51;
      }
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Engrave)
      {
        index = 4;
        goto label_51;
      }
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Face)
      {
        index = 5;
        goto label_51;
      }
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.FloorFinish)
      {
        index = 6;
        goto label_51;
      }
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Pocket)
      {
        index = 8;
        goto label_51;
      }
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.TextEngrave)
      {
        index = 9;
        goto label_51;
      }
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Trochoidal)
      {
        index = 10;
        goto label_51;
      }
    }
    else if (((FoamSettings) Cam).camMode == CamMode.TriangularMesh)
    {
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.ConstantCusp)
      {
        index = 21;
        goto label_51;
      }
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.ConstantZ)
      {
        index = 17;
        goto label_51;
      }
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Flatlands)
      {
        index = 19;
        goto label_51;
      }
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.ParallelCuts)
      {
        index = 16 /*0x10*/;
        goto label_51;
      }
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Pencil)
      {
        index = 18;
        goto label_51;
      }
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.ProjectCurves)
      {
        index = 20;
        goto label_51;
      }
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Projection)
      {
        index = 22;
        goto label_51;
      }
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Rotary)
      {
        index = 23;
        goto label_51;
      }
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Rough)
      {
        index = 15;
        goto label_51;
      }
    }
    else if (((FoamSettings) Cam).camMode == CamMode.TriangularMesh5AX)
    {
      if (((FoamSettings) Cam).camMesh5AXType == CamTriangularMesh5AxType.ParallelCuts)
      {
        index = 39;
        goto label_51;
      }
      if (((FoamSettings) Cam).camMesh5AXType == CamTriangularMesh5AxType.ConstantZ)
      {
        index = 40;
        goto label_51;
      }
    }
    else if (((FoamSettings) Cam).camMode == CamMode.Drill)
    {
      if (((FoamSettings) Cam).camDrillType == CamDrillType.Line)
      {
        index = 13;
        goto label_51;
      }
      if (((FoamSettings) Cam).camDrillType == CamDrillType.Point)
      {
        index = 12;
        goto label_51;
      }
      if (((FoamSettings) Cam).camDrillType == CamDrillType.Surface)
      {
        index = 14;
        goto label_51;
      }
    }
    index = -1;
label_51:
    return index;
  }
}
