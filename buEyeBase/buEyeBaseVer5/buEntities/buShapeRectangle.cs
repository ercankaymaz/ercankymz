// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeRectangle
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

public class buShapeRectangle : buShape
{
  internal Label \u001B;
  public NumericUpDown spn_leadout;
  public static byte f003753;
  public static List<string> Captions;
  public FormProperties PropertiesForm;

  public abstract void m0017E3();

  public buShapeRectangle(int degree, Point3D[] ctrlPoints)
  {
    ((CustomDataSurrogate) this).ControlPoints = new List<Point4D>();
    ((CustomDataSurrogate) this).KnotVector = new List<double>();
    ((CustomDataSurrogate) this).Degree = 2;
    ((CustomDataSurrogate) this).isRational = false;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Degree = degree;
    for (int index = 0; index <= ctrlPoints.Length - 1; ++index)
      ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(ctrlPoints[index].X, ctrlPoints[index].Y, ctrlPoints[index].Z));
    ((buUpperLine) this).Update((buEntityUpdateType) 23);
  }

  public buShapeRectangle(int degree, List<Point3D> ctrlPoints)
  {
    ((CustomDataSurrogate) this).ControlPoints = new List<Point4D>();
    ((CustomDataSurrogate) this).KnotVector = new List<double>();
    ((CustomDataSurrogate) this).Degree = 2;
    ((CustomDataSurrogate) this).isRational = false;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Degree = degree;
    for (int index = 0; index <= ctrlPoints.Count - 1; ++index)
      ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(ctrlPoints[index].X, ctrlPoints[index].Y, ctrlPoints[index].Z));
    ((buUpperLine) this).Update((buEntityUpdateType) 23);
  }

  public buShapeRectangle(
    int degree,
    double[] knotVector,
    Point4D[] ctrlPoints,
    bool checkKnotsAndCtrlPts = true)
  {
    ((CustomDataSurrogate) this).ControlPoints = new List<Point4D>();
    ((CustomDataSurrogate) this).KnotVector = new List<double>();
    ((CustomDataSurrogate) this).Degree = 2;
    ((CustomDataSurrogate) this).isRational = false;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Degree = degree;
    for (int index = 0; index <= ctrlPoints.Length - 1; ++index)
      ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(ctrlPoints[index].X, ctrlPoints[index].Y, ctrlPoints[index].Z, ctrlPoints[index].W));
    for (int index = 0; index <= knotVector.Length - 1; ++index)
      ((CustomDataSurrogate) this).KnotVector.Add(knotVector[index]);
    ((CustomDataSurrogate) this).isRational = true;
    ((buUpperLine) this).Update((buEntityUpdateType) 24);
  }

  public buShapeRectangle(buCurve another)
  {
    ((CustomDataSurrogate) this).ControlPoints = new List<Point4D>();
    ((CustomDataSurrogate) this).KnotVector = new List<double>();
    ((CustomDataSurrogate) this).Degree = 2;
    ((CustomDataSurrogate) this).isRational = false;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    if (((CustomDataSurrogate) another).ControlPoints != null)
    {
      if (((CustomDataSurrogate) another).isRational)
      {
        for (int index = 0; index <= ((CustomDataSurrogate) another).KnotVector.Count - 1; ++index)
          ((CustomDataSurrogate) this).KnotVector.Add(((CustomDataSurrogate) another).KnotVector[index]);
        for (int index = 0; index <= ((CustomDataSurrogate) another).ControlPoints.Count - 1; ++index)
          ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(((CustomDataSurrogate) another).ControlPoints[index].X, ((CustomDataSurrogate) another).ControlPoints[index].Y, ((CustomDataSurrogate) another).ControlPoints[index].Z, ((CustomDataSurrogate) another).ControlPoints[index].W));
      }
      else
      {
        for (int index = 0; index <= ((CustomDataSurrogate) another).ControlPoints.Count - 1; ++index)
          ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(((CustomDataSurrogate) another).ControlPoints[index].X, ((CustomDataSurrogate) another).ControlPoints[index].Y, ((CustomDataSurrogate) another).ControlPoints[index].Z, ((CustomDataSurrogate) another).ControlPoints[index].W));
      }
    }
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

  public buShapeRectangle(Curve another)
  {
    ((CustomDataSurrogate) this).ControlPoints = new List<Point4D>();
    ((CustomDataSurrogate) this).KnotVector = new List<double>();
    ((CustomDataSurrogate) this).Degree = 2;
    ((CustomDataSurrogate) this).isRational = false;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).Degree = another.Degree;
    if (!another.IsRational)
    {
      for (int index = 0; index <= another.ControlPoints.Length - 1; ++index)
        ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(another.ControlPoints[index].X, another.ControlPoints[index].Y, another.ControlPoints[index].Z, another.ControlPoints[index].W));
    }
    else
    {
      for (int index = 0; index <= another.ControlPoints.Length - 1; ++index)
        ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(another.ControlPoints[index].X, another.ControlPoints[index].Y, another.ControlPoints[index].Z, another.ControlPoints[index].W));
      for (int index = 0; index <= another.KnotVector.Length - 1; ++index)
        ((CustomDataSurrogate) this).KnotVector.Add(another.KnotVector[index]);
    }
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 25);
  }
}
