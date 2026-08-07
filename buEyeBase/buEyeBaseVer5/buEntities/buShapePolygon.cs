// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapePolygon
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapePolygon : buShape
{
  public Panel pnl_base;
  public buSpin spn_topoffet;
  public buButton btn_ok;

  public override string ToString()
  {
    string str = $"CompositeCurve Cnt: {((CustomDataSurrogate) this).CurveList.Count.ToString()} - Dir: {((CustomData) this).sortDirection.ToString()}";
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

  public abstract void m0017F4();

  public buShapePolygon()
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).SortAndOrient = true;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
  }

  public buShapePolygon(devDept.Eyeshot.Entities.Region another)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).SortAndOrient = true;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    for (int index = 0; index <= another.ContourList.Count - 1; ++index)
      ((CustomDataSurrogate) this).CurveList.Add(buRegion.convEntity(another.ContourList[index]));
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 38);
  }

  public buShapePolygon(buRegion another)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).SortAndOrient = true;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    buRadialDim.Copy(((CustomDataSurrogate) another).CurveList, ref ((CustomDataSurrogate) this).CurveList);
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
    ((CustomDataSurrogate) this).Plane = new Plane(((CustomDataSurrogate) another).Plane.Origin, ((CustomDataSurrogate) another).Plane.AxisX, ((CustomDataSurrogate) another).Plane.AxisY);
    ((CustomData) this).StartPoint = new Point3D(((CustomData) another).StartPoint.X, ((CustomData) another).StartPoint.Y, ((CustomData) another).StartPoint.Z);
    ((CustomData) this).MiddlePoint = new Point3D(((CustomData) another).MiddlePoint.X, ((CustomData) another).MiddlePoint.Y, ((CustomData) another).MiddlePoint.Z);
    ((CustomData) this).EndPoint = new Point3D(((CustomData) another).EndPoint.X, ((CustomData) another).EndPoint.Y, ((CustomData) another).EndPoint.Z);
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
    for (int index = 0; index <= ((CustomDataSurrogate) another).Vertices.Count - 1; ++index)
      ((CustomDataSurrogate) this).Vertices.Add(new Point3D(((CustomDataSurrogate) another).Vertices[index].X, ((CustomDataSurrogate) another).Vertices[index].Y, ((CustomDataSurrogate) another).Vertices[index].Z));
  }
}
