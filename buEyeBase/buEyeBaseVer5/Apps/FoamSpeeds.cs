// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamSpeeds
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamSpeeds : buSerilization5
{
  public Point3D MinPoint;
  public Point3D MaxPoint;
  public CamStock Stock;
  public MachineGCodeExecutionResult GCodeResult;
  public List<Router3AXCAM> CamList;

  public string JobToString(Router3AXItem Item)
  {
    string str = ((FoamCreatePanelOptions) Item).ItemName;
    if (((FoamSpeeds) Item).Stock != null)
      str = $"{str} - {buLangTranslate.preDef.Stock} : {((ToolGeometry5) ((FoamSpeeds) Item).Stock).SizeStock.Width.ToString("f1")} X {((ToolGeometry5) ((FoamSpeeds) Item).Stock).SizeStock.Height.ToString("f1")} X {((ToolGeometry5) ((FoamSpeeds) Item).Stock).SizeStock.Depth.ToString("f1")}";
    return str;
  }

  public string JobStockToString(Router3AXItem Item)
  {
    string str = buLangTranslate.preDef.Stock;
    if (((FoamSpeeds) Item).Stock != null)
      str = $"{str} : {((ToolGeometry5) ((FoamSpeeds) Item).Stock).SizeStock.Width.ToString("f1")} X {((ToolGeometry5) ((FoamSpeeds) Item).Stock).SizeStock.Height.ToString("f1")} X {((ToolGeometry5) ((FoamSpeeds) Item).Stock).SizeStock.Depth.ToString("f1")}";
    return str;
  }

  public string JobCamToString(Router3AXCAM Cam)
  {
    string str = "";
    if (((FoamSettings) Cam).camMode == CamMode.WireFrame)
    {
      str += buLangTranslate.preDef.Wireframe;
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.CenterPath)
        str = $"{str} - {buLangTranslate.preDef.CenterPath}";
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Chamfer2D)
        str = $"{str} - {buLangTranslate.preDef.ChamferPath}";
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Contour)
        str = $"{str} - {buLangTranslate.preDef.Contour}";
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Engrave)
        str = $"{str} - {buLangTranslate.preDef.Engrave}";
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Face)
        str = $"{str} - {buLangTranslate.preDef.Face}";
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.FloorFinish)
        str = $"{str} - {buLangTranslate.preDef.FloorFinish}";
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Pocket)
        str = $"{str} - {buLangTranslate.preDef.Pocket}";
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.TextEngrave)
        str = $"{str} - {buLangTranslate.preDef.TextEngrave}";
      if (((FoamSettings) Cam).camWireframeType == CamWireFrameType.Trochoidal)
        str = $"{str} - {buLangTranslate.preDef.Trochoidal}";
      if (((FoamPatternInfo) Cam).CamName.Length > 0)
        str = ((FoamPatternInfo) Cam).CamName;
    }
    else if (((FoamSettings) Cam).camMode == CamMode.TriangularMesh)
    {
      str += buLangTranslate.preDef.Mesh;
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.ConstantCusp)
        str = $"{str} - {buLangTranslate.preDef.ConstantCusp}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.ConstantZ)
        str = $"{str} - {buLangTranslate.preDef.ConstantZ}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Flatlands)
        str = $"{str} - {buLangTranslate.preDef.Flatlands}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Geodesic)
        str = $"{str} - {buLangTranslate.preDef.Geodesic}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.ParallelCuts)
        str = $"{str} - {buLangTranslate.preDef.ParalelCuts}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Pencil)
        str = $"{str} - {buLangTranslate.preDef.Pencil}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.ProjectCurves)
        str = $"{str} - {buLangTranslate.preDef.ProjectCurves}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Projection)
        str = $"{str} - {buLangTranslate.preDef.Projection}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Rotary)
        str = $"{str} - {buLangTranslate.preDef.Rotary}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.RotaryFinish)
        str = $"{str} - {buLangTranslate.preDef.RotaryFinish}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.RotaryRough)
        str = $"{str} - {buLangTranslate.preDef.ConstantCusp}";
      if (((FoamSettings) Cam).camMeshType == CamTriangularMeshType.Rough)
        str = $"{str} - {buLangTranslate.preDef.Rough}";
    }
    else if (((FoamSettings) Cam).camMode == CamMode.TriangularMesh5AX)
    {
      str += buLangTranslate.preDef.Mesh;
      if (((FoamSettings) Cam).camMesh5AXType == CamTriangularMesh5AxType.ParallelCuts)
        str = $"{str} - {buLangTranslate.preDef.ParalelCuts} 5 {buLangTranslate.preDef.Axes}";
      if (((FoamSettings) Cam).camMesh5AXType == CamTriangularMesh5AxType.ConstantZ)
        str = $"{str} - {buLangTranslate.preDef.ConstantZ} 5 {buLangTranslate.preDef.Axes}";
      if (((FoamSettings) Cam).camMesh5AXType == CamTriangularMesh5AxType.Rough)
        str = $"{str} - {buLangTranslate.preDef.Rough} 5 {buLangTranslate.preDef.Axes}";
    }
    else if (((FoamSettings) Cam).camMode == CamMode.Drill)
    {
      str += buLangTranslate.preDef.Drill;
      if (((FoamSettings) Cam).camDrillType == CamDrillType.Line)
        str = $"{str} - {buLangTranslate.preDef.Line}";
      if (((FoamSettings) Cam).camDrillType == CamDrillType.Point)
        str = $"{str} - {buLangTranslate.preDef.Point}";
      if (((FoamSettings) Cam).camDrillType == CamDrillType.Surface)
        str = $"{str} - {buLangTranslate.preDef.Surface}";
    }
    return str;
  }

  public string JobCamToolToString(ToolBase5 Tool)
  {
    string str = buLangTranslate.preDef.Tool;
    if (((ToolCamData5) ((ToolGeometry5) Tool).Data).Name.Length > 0)
      str = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
    return $"{str} - {buLangTranslate.preDef.Diameter} : {((ToolGeometry5) Tool).Geometry.Diameter.ToString("f1")} - {buLangTranslate.preDef.Length} : {((ToolGeometry5) Tool).Geometry.Length.ToString("f1")}";
  }
}
