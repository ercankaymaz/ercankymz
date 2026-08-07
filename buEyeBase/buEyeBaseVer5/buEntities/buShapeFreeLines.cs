// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeFreeLines
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeFreeLines : buShape
{
  public buCheckBox chk_showadvancedsettings;
  public buSpin spn_leftoffset;

  public buShapeFreeLines()
  {
    ((MyFileSerializer) this).Triangles = (List<IndexTriangle>) null;
    ((DoublePoint) this).MeshNature = Mesh.natureType.RichSmooth;
    ((DoublePoint) this).EdgeStyle = Mesh.edgeStyleType.None;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
  }

  public buShapeFreeLines(buMesh another)
  {
    ((MyFileSerializer) this).Triangles = (List<IndexTriangle>) null;
    ((DoublePoint) this).MeshNature = Mesh.natureType.RichSmooth;
    ((DoublePoint) this).EdgeStyle = Mesh.edgeStyleType.None;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    if (((CustomData) another).Shape != null)
      ((CustomData) this).Shape = (EntityShapeInfo) new SewingPunteriz(((CustomData) another).Shape);
    if (((CustomData) another).Info != null)
      ((CustomData) this).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) another).Info);
    if (((CustomData) another).Cutter != null)
      ((CustomData) this).Cutter = (CutterInfo) new AnalyseEntitiesResult(((CustomData) another).Cutter);
    if (((CustomData) another).Sewing != null)
      ((CustomData) this).Sewing = (SewingInfo) new EntityInfo(((CustomData) another).Sewing);
    if (((CustomData) another).Marble != null)
      ((CustomData) this).Marble = (MarbleInfo) new Line2D(((CustomData) another).Marble);
    if (((CustomData) another).Dimension != null)
      ((CustomData) this).Dimension = (DimensionInfo) new CharLibrary5(((CustomData) another).Dimension);
    if (((CustomDataSurrogate) another).Vertices != null)
    {
      for (int index = 0; index <= ((CustomDataSurrogate) another).Vertices.Count - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(((CustomDataSurrogate) another).Vertices[index].X, ((CustomDataSurrogate) another).Vertices[index].Y, ((CustomDataSurrogate) another).Vertices[index].Z));
    }
    ((CustomData) this).BoxMin = new Point3D(((CustomData) another).BoxMin.X, ((CustomData) another).BoxMin.Y, ((CustomData) another).BoxMin.Z);
    ((CustomData) this).BoxMax = new Point3D(((CustomData) another).BoxMax.X, ((CustomData) another).BoxMax.Y, ((CustomData) another).BoxMax.Z);
    ((CustomData) this).sortDirection = ((CustomData) another).sortDirection;
    ((CustomDataSurrogate) this).typeDefination = ((CustomDataSurrogate) another).typeDefination;
    ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CustomDataSurrogate) another).Orientation);
    ((CustomDataSurrogate) this).ToolName = ((CustomDataSurrogate) another).ToolName;
    ((CustomDataSurrogate) this).LayerName = ((CustomDataSurrogate) another).LayerName;
    ((CustomDataSurrogate) this).LayerIndex = ((CustomDataSurrogate) another).LayerIndex;
    ((CustomDataSurrogate) this).Color = ((CustomDataSurrogate) another).Color;
    ((CustomDataSurrogate) this).Thickness = ((CustomDataSurrogate) another).Thickness;
    if (((MyFileSerializer) another).Triangles == null)
      return;
    ((MyFileSerializer) this).Triangles = new List<IndexTriangle>();
    for (int index = 0; index <= ((MyFileSerializer) another).Triangles.Count - 1; ++index)
      ((MyFileSerializer) this).Triangles.Add(new IndexTriangle(((MyFileSerializer) another).Triangles[index].V1, ((MyFileSerializer) another).Triangles[index].V2, ((MyFileSerializer) another).Triangles[index].V3));
  }

  public buShapeFreeLines(IList<Point3D> vertices, IList<IndexTriangle> triangles)
  {
    ((MyFileSerializer) this).Triangles = (List<IndexTriangle>) null;
    ((DoublePoint) this).MeshNature = Mesh.natureType.RichSmooth;
    ((DoublePoint) this).EdgeStyle = Mesh.edgeStyleType.None;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    if (((CustomDataSurrogate) this).Vertices != null)
    {
      for (int index = 0; index <= vertices.Count - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(vertices[index].X, vertices[index].Y, vertices[index].Z));
    }
    if (triangles == null)
      return;
    ((MyFileSerializer) this).Triangles = new List<IndexTriangle>();
    for (int index = 0; index <= triangles.Count - 1; ++index)
      ((MyFileSerializer) this).Triangles.Add(new IndexTriangle(triangles[index].V1, triangles[index].V2, triangles[index].V3));
  }

  public buShapeFreeLines(Mesh another)
  {
    ((MyFileSerializer) this).Triangles = (List<IndexTriangle>) null;
    ((DoublePoint) this).MeshNature = Mesh.natureType.RichSmooth;
    ((DoublePoint) this).EdgeStyle = Mesh.edgeStyleType.None;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    if (another.Vertices != null)
    {
      for (int index = 0; index <= another.Vertices.Length - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(another.Vertices[index].X, another.Vertices[index].Y, another.Vertices[index].Z));
    }
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    if (another.Triangles == null)
      return;
    ((MyFileSerializer) this).Triangles = new List<IndexTriangle>();
    for (int index = 0; index <= another.Triangles.Length - 1; ++index)
      ((MyFileSerializer) this).Triangles.Add(new IndexTriangle(another.Triangles[index].V1, another.Triangles[index].V2, another.Triangles[index].V3));
  }

  public override string ToString()
  {
    string str = "Mesh ";
    if (((CustomDataSurrogate) this).Vertices.Count > 0)
      str = $"{str}Ver: {((CustomDataSurrogate) this).Vertices.Count.ToString()}";
    if (((CustomDataSurrogate) this).typeDefination != 0)
      str = $"{str} Type: {((CustomDataSurrogate) this).typeDefination.ToString()}";
    if (((AnalyseEntitiesResult) ((CustomData) this).Info).CamSelected)
      str = $"{str} CamSelected: {((AnalyseEntitiesResult) ((CustomData) this).Info).CamSelected.ToString()}";
    if (((DirectionArrowSetting) ((CustomData) this).Info).Calculated)
      str = $"{str} Calculated: {((DirectionArrowSetting) ((CustomData) this).Info).Calculated.ToString()}";
    if (((AnalyseEntitiesSetting) ((CustomData) this).Info).RefIndex >= 0)
      str = $"{str} Ref Index: {((AnalyseEntitiesSetting) ((CustomData) this).Info).RefIndex.ToString()}";
    return str;
  }
}
