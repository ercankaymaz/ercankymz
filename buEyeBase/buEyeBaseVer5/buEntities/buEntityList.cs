// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buEntityList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buEntityList : buSerilization5
{
  internal IContainer \u0001;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Label \u0001;
  public NumericUpDown spn_areaclearancevelocity;
  internal Label \u0002;
  public NumericUpDown spn_finishvelocity;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  public NumericUpDown spn_velplunge;
  internal Label \u0006;

  public buEntityList(Plane arcPlane, Point2D center, Point2D start, Point2D end)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y);
    ((CustomData) this).StartPoint = new Point3D(start.X, start.Y);
    ((CustomData) this).EndPoint = new Point3D(end.X, end.Y);
    ((CustomDataSurrogate) this).Plane = (Plane) arcPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 5);
  }

  public buEntityList(Point3D first, Point3D second, Point3D third, bool flip)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomData) this).StartPoint = new Point3D(first.X, first.Y, first.Z);
    ((CustomData) this).MiddlePoint = new Point3D(second.X, second.Y, second.Z);
    ((CustomData) this).EndPoint = new Point3D(third.X, third.Y, third.Z);
    ((CustomDataSurrogate) this).Flip = flip;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    ((buUpperLine) this).Update((buEntityUpdateType) 6);
  }

  public buEntityList(
    Plane arcPlane,
    Point3D center,
    double radius,
    double startAngle,
    double endAngle)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y, center.Z);
    ((CustomDataSurrogate) this).Radius = radius;
    ((CustomDataSurrogate) this).StartAngle = startAngle;
    ((CustomDataSurrogate) this).EndAngle = endAngle;
    ((CustomDataSurrogate) this).Plane = (Plane) arcPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 7);
  }

  public buEntityList(Plane arcPlane, Point2D first, Point2D second, Point2D third, bool flip)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomData) this).StartPoint = new Point3D(first.X, first.Y);
    ((CustomData) this).MiddlePoint = new Point3D(second.X, second.Y);
    ((CustomData) this).EndPoint = new Point3D(third.X, third.Y);
    ((CustomDataSurrogate) this).Flip = flip;
    ((CustomDataSurrogate) this).Plane = (Plane) arcPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 8);
  }

  public buEntityList(
    Plane arcPlane,
    Point3D center,
    double radius,
    Point3D start,
    Point3D end,
    bool flip)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y, center.Z);
    ((CustomData) this).StartPoint = new Point3D(start.X, start.Y, start.Z);
    ((CustomData) this).EndPoint = new Point3D(end.X, end.Y, end.Z);
    ((CustomDataSurrogate) this).Radius = radius;
    ((CustomDataSurrogate) this).Flip = flip;
    ((CustomDataSurrogate) this).Plane = (Plane) arcPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 9);
  }

  public buEntityList(buArc another)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(((CustomDataSurrogate) another).Center.X, ((CustomDataSurrogate) another).Center.Y, ((CustomDataSurrogate) another).Center.Z);
    ((CustomData) this).StartPoint = new Point3D(((CustomData) another).StartPoint.X, ((CustomData) another).StartPoint.Y, ((CustomData) another).StartPoint.Z);
    ((CustomData) this).EndPoint = new Point3D(((CustomData) another).EndPoint.X, ((CustomData) another).EndPoint.Y, ((CustomData) another).EndPoint.Z);
    ((CustomData) this).MiddlePoint = new Point3D(((CustomData) another).MiddlePoint.X, ((CustomData) another).MiddlePoint.Y, ((CustomData) another).MiddlePoint.Z);
    ((CustomDataSurrogate) this).StartAngle = ((CustomDataSurrogate) another).StartAngle;
    ((CustomDataSurrogate) this).EndAngle = ((CustomDataSurrogate) another).EndAngle;
    ((CustomDataSurrogate) this).Radius = ((CustomDataSurrogate) another).Radius;
    ((CustomDataSurrogate) this).Plane = new Plane(((CustomDataSurrogate) another).Plane.Origin, ((CustomDataSurrogate) another).Plane.AxisX, ((CustomDataSurrogate) another).Plane.AxisY);
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
    if (((CustomData) another).Dimension == null)
      return;
    ((CustomData) this).Dimension = (DimensionInfo) new CharLibrary5(((CustomData) another).Dimension);
  }

  public buEntityList(Arc another)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(another.Center.X, another.Center.Y, another.Center.Z);
    ((CustomData) this).StartPoint = new Point3D(another.StartPoint.X, another.StartPoint.Y, another.StartPoint.Z);
    ((CustomData) this).EndPoint = new Point3D(another.EndPoint.X, another.EndPoint.Y, another.EndPoint.Z);
    ((CustomData) this).MiddlePoint = new Point3D(another.MidPoint.X, another.MidPoint.Y, another.MidPoint.Z);
    ((CustomDataSurrogate) this).Radius = another.Radius;
    ((CustomDataSurrogate) this).Plane = new Plane(another.Plane.Origin, another.Plane.AxisX, another.Plane.AxisY);
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 5);
  }

  public override string ToString()
  {
    string str = $"{$"{$"Arc Center: {buString5.Point3DToString(((CustomDataSurrogate) this).Center)} - Rad: {((CustomDataSurrogate) this).Radius.ToString("f3")}"} - SP: {buString5.Point3DToString(((CustomData) this).StartPoint)} - EP : {buString5.Point3DToString(((CustomData) this).EndPoint)}"} - Dir: {((CustomData) this).sortDirection.ToString()}";
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

  public abstract void m0017CA();

  public buEntityList(Point3D center, double radius)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y, center.Z);
    ((CustomDataSurrogate) this).Radius = radius;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    ((buUpperLine) this).Update((buEntityUpdateType) 11);
  }

  public buEntityList(Plane plane, double radius)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Radius = radius;
    ((CustomDataSurrogate) this).Plane = (Plane) plane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 12);
  }

  public buEntityList(Plane plane, Point3D center, double radius)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y, center.Z);
    ((CustomDataSurrogate) this).Radius = radius;
    ((CustomDataSurrogate) this).Plane = (Plane) plane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 12);
  }

  public buEntityList(Plane plane, Point2D center, double radius)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y);
    ((CustomDataSurrogate) this).Radius = radius;
    ((CustomDataSurrogate) this).Plane = (Plane) plane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 13);
  }

  public buEntityList(Point3D first, Point3D second, Point3D third)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomData) this).StartPoint = new Point3D(first.X, first.Y, first.Z);
    ((CustomData) this).MiddlePoint = new Point3D(second.X, second.Y, second.Z);
    ((CustomData) this).EndPoint = new Point3D(third.X, third.Y, third.Z);
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    ((buUpperLine) this).Update((buEntityUpdateType) 14);
  }
}
