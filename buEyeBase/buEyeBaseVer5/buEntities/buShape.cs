// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShape
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShape : buSerilization5
{
  public NumericUpDown spn_vellfeed;
  internal Label \u0007;
  internal Label \u0008;
  internal Panel \u0002;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal PictureBox \u0003;
  internal PictureBox \u0004;
  internal Label \u000E;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label \u000F;
  internal NumericUpDown \u0001;
  internal Label \u0010;
  public NumericUpDown spn_stepcount;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal Panel \u0003;
  internal Panel \u0004;
  internal RadioButton \u0005;
  internal Label \u0011;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal Panel \u0005;
  internal RadioButton \u0008;
  internal Label \u0012;
  internal RadioButton \u000E;
  internal RadioButton \u000F;
  internal Label \u0013;
  internal Label \u0014;
  public NumericUpDown spn_finishoffset;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  internal CheckBox \u0003;
  internal Label \u0015;
  internal Label \u0016;
  public NumericUpDown spn_dissmallsafe;
  internal Label \u0017;
  public NumericUpDown spn_dissafe;
  internal Label \u0018;
  internal CheckBox \u0004;
  public NumericUpDown spn_velleave;
  internal Label \u0019;
  internal PictureBox \u0005;
  internal Label \u001A;
  public NumericUpDown spn_leadin;

  public buShape(Plane plane, Point2D first, Point2D second, Point2D third)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomData) this).StartPoint = new Point3D(first.X, first.Y);
    ((CustomData) this).MiddlePoint = new Point3D(second.X, second.Y);
    ((CustomData) this).EndPoint = new Point3D(third.X, third.Y);
    ((CustomDataSurrogate) this).Plane = (Plane) plane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 15);
  }

  public buShape(buCircle another)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(((CustomDataSurrogate) another).Center.X, ((CustomDataSurrogate) another).Center.Y, ((CustomDataSurrogate) another).Center.Z);
    ((CustomDataSurrogate) this).Radius = ((CustomDataSurrogate) another).Radius;
    ((CustomDataSurrogate) this).Plane = new Plane(((CustomDataSurrogate) another).Plane.Origin, ((CustomDataSurrogate) another).Plane.AxisX, ((CustomDataSurrogate) another).Plane.AxisY);
    ((CustomData) this).BoxMin = new Point3D(((CustomData) another).BoxMin.X, ((CustomData) another).BoxMin.Y, ((CustomData) another).BoxMin.Z);
    ((CustomData) this).BoxMax = new Point3D(((CustomData) another).BoxMax.X, ((CustomData) another).BoxMax.Y, ((CustomData) another).BoxMax.Z);
    ((CustomData) this).StartPoint = new Point3D(((CustomData) another).StartPoint.X, ((CustomData) another).StartPoint.Y, ((CustomData) another).StartPoint.Z);
    ((CustomData) this).MiddlePoint = new Point3D(((CustomData) another).MiddlePoint.X, ((CustomData) another).MiddlePoint.Y, ((CustomData) another).MiddlePoint.Z);
    ((CustomData) this).EndPoint = new Point3D(((CustomData) another).EndPoint.X, ((CustomData) another).EndPoint.Y, ((CustomData) another).EndPoint.Z);
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

  public buShape(Circle another)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(another.Center.X, another.Center.Y, another.Center.Z);
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
    ((buUpperLine) this).Update((buEntityUpdateType) 16 /*0x10*/);
  }

  public override string ToString()
  {
    string str = $"Circle Center: {buString5.Point3DToString(((CustomDataSurrogate) this).Center)} - Rad: {((CustomDataSurrogate) this).Radius.ToString()} - Dir: {((CustomData) this).sortDirection.ToString()}";
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

  public abstract void m0017D4();

  public buShape(buEllipse another)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).RadiusX = 20.0;
    ((CustomDataSurrogate) this).RadiusY = 10.0;
    ((CustomDataSurrogate) this).Angle = 0.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
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
    ((CustomData) this).StartPoint = new Point3D(((CustomData) another).StartPoint.X, ((CustomData) another).StartPoint.Y, ((CustomData) another).StartPoint.Z);
    ((CustomData) this).MiddlePoint = new Point3D(((CustomData) another).MiddlePoint.X, ((CustomData) another).MiddlePoint.Y, ((CustomData) another).MiddlePoint.Z);
    ((CustomData) this).EndPoint = new Point3D(((CustomData) another).EndPoint.X, ((CustomData) another).EndPoint.Y, ((CustomData) another).EndPoint.Z);
    ((CustomDataSurrogate) this).Center = new Point3D(((CustomDataSurrogate) another).Center.X, ((CustomDataSurrogate) another).Center.Y, ((CustomDataSurrogate) another).Center.Z);
    ((CustomDataSurrogate) this).RadiusX = ((CustomDataSurrogate) another).RadiusX;
    ((CustomDataSurrogate) this).RadiusY = ((CustomDataSurrogate) another).RadiusY;
    ((CustomDataSurrogate) this).Angle = ((CustomDataSurrogate) another).Angle;
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
    ((buUpperLine) this).Update((buEntityUpdateType) 22);
  }

  public buShape(Ellipse another)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).RadiusX = 20.0;
    ((CustomDataSurrogate) this).RadiusY = 10.0;
    ((CustomDataSurrogate) this).Angle = 0.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(another.Center.X, another.Center.Y, another.Center.Z);
    ((CustomDataSurrogate) this).RadiusX = another.RadiusX;
    ((CustomDataSurrogate) this).RadiusY = another.RadiusY;
    ((CustomDataSurrogate) this).Plane = (Plane) another.Plane.Clone();
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 22);
  }

  public buShape(Point3D center, double rx, double ry)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).RadiusX = 20.0;
    ((CustomDataSurrogate) this).RadiusY = 10.0;
    ((CustomDataSurrogate) this).Angle = 0.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y, center.Z);
    ((CustomDataSurrogate) this).RadiusX = rx;
    ((CustomDataSurrogate) this).RadiusY = ry;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    ((buUpperLine) this).Update((buEntityUpdateType) 19);
  }

  public buShape(Plane ellipsePlane, double rx, double ry)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).RadiusX = 20.0;
    ((CustomDataSurrogate) this).RadiusY = 10.0;
    ((CustomDataSurrogate) this).Angle = 0.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).RadiusX = rx;
    ((CustomDataSurrogate) this).RadiusY = ry;
    ((CustomDataSurrogate) this).Plane = (Plane) ellipsePlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 21);
  }

  public buShape(Plane ellipsePlane, Point2D center, double rx, double ry)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).RadiusX = 20.0;
    ((CustomDataSurrogate) this).RadiusY = 10.0;
    ((CustomDataSurrogate) this).Angle = 0.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y);
    ((CustomDataSurrogate) this).RadiusX = rx;
    ((CustomDataSurrogate) this).RadiusY = ry;
    ((CustomDataSurrogate) this).Plane = (Plane) ellipsePlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 21);
  }

  public buShape(Plane ellipsePlane, Point3D center, double rx, double ry)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).RadiusX = 20.0;
    ((CustomDataSurrogate) this).RadiusY = 10.0;
    ((CustomDataSurrogate) this).Angle = 0.0;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y, center.Z);
    ((CustomDataSurrogate) this).RadiusX = rx;
    ((CustomDataSurrogate) this).RadiusY = ry;
    ((CustomDataSurrogate) this).Plane = (Plane) ellipsePlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 20);
  }

  public override string ToString()
  {
    string str = $"Ellipse Center: {buString5.Point3DToString(((CustomDataSurrogate) this).Center)} - RadX: {((CustomDataSurrogate) this).RadiusY.ToString()} - RadY: {((CustomDataSurrogate) this).RadiusX.ToString()} - Dir: {((CustomData) this).sortDirection.ToString()}";
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

  public abstract void m0017DC();

  public buShape(buLinearPath another)
    : this()
  {
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

  public buShape(LinearPath another)
    : this()
  {
    for (int index = 0; index <= another.Vertices.Length - 1; ++index)
      ((CustomDataSurrogate) this).Vertices.Add(new Point3D(another.Vertices[index].X, another.Vertices[index].Y, another.Vertices[index].Z));
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 17);
  }

  public buShape(List<Point3D> points)
    : this()
  {
    for (int index = 0; index <= points.Count - 1; ++index)
      ((CustomDataSurrogate) this).Vertices.Add(new Point3D(points[index].X, points[index].Y, points[index].Z));
    ((buUpperLine) this).Update((buEntityUpdateType) 17);
  }

  public buShape(Point3D[] points)
    : this()
  {
    for (int index = 0; index <= points.Length - 1; ++index)
      ((CustomDataSurrogate) this).Vertices.Add(new Point3D(points[index].X, points[index].Y, points[index].Z));
    ((buUpperLine) this).Update((buEntityUpdateType) 17);
  }

  public buShape(Plane plane, List<Point3D> points)
    : this()
  {
    for (int index = 0; index <= points.Count - 1; ++index)
      ((CustomDataSurrogate) this).Vertices.Add(new Point3D(points[index].X, points[index].Y, points[index].Z));
    ((buUpperLine) this).Update((buEntityUpdateType) 32 /*0x20*/, plane: plane);
  }

  public override string ToString()
  {
    string str = "LinearPath ";
    if (((CustomDataSurrogate) this).Vertices.Count > 0)
      str = $"{str}SP: {buString5.Point3DToString(((CustomDataSurrogate) this).Vertices[0])} - EP: {buString5.Point3DToString(((CustomDataSurrogate) this).Vertices[((CustomDataSurrogate) this).Vertices.Count - 1])} - Dir: {((CustomData) this).sortDirection.ToString()}";
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
