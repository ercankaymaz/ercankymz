// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeCircle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeCircle : buShape
{
  public camParameters5 Settings;

  public override string ToString()
  {
    string str = "Curve ";
    if (((CustomDataSurrogate) this).ControlPoints.Count > 0)
      str = $"{str}SP: {buString5.Point3DToString((Point3D) ((CustomDataSurrogate) this).ControlPoints[0])} - EP: {buString5.Point3DToString((Point3D) ((CustomDataSurrogate) this).ControlPoints[((CustomDataSurrogate) this).ControlPoints.Count - 1])} - Dir: {((CustomData) this).sortDirection.ToString()}";
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

  public abstract void m0017EA();

  public buShapeCircle(buCompositeCurve another)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).\u0001 = true;
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

  public buShapeCircle(CompositeCurve another)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).\u0001 = true;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    for (int index = 0; index <= another.CurveList.Count - 1; ++index)
      ((CustomDataSurrogate) this).CurveList.Add(buRegion.convEntity(another.CurveList[index]));
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 30);
  }

  public buShapeCircle(List<buEntity> curveList)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).\u0001 = true;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    buRadialDim.Copy(curveList, ref ((CustomDataSurrogate) this).CurveList);
    ((buUpperLine) this).Update((buEntityUpdateType) 26);
  }
}
