// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeHole3
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeHole3 : buShapeHole
{
  internal new ImageList \u0001;
  internal new PictureBox \u0001;
  public new FormProperties PropertiesForm;
  public new static List<string> Captions;

  public buShapeHole3(
    Plane sketchPlane,
    Point2D origin,
    Point2D extLine1,
    Point2D extLine2,
    Point2D dimLinePos,
    double textHeight)
  {
    ((\u000E.\u0001) this).ExtLine1 = new Point3D();
    ((IntPoint) this).ExtLine2 = new Point3D();
    ((IntPoint) this).DimLinePosition = new Point3D();
    ((IntPoint) this).InsertionPoint = new Point3D();
    ((IntRect) this).QuadrantPoint = new Point3D();
    ((IntRect) this).Origin = new Point3D();
    ((IntRect) this).Height = 20.0;
    ((IntRect) this).Plane = Plane.XY;
    ((ClipType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u000E.\u0001) this).ExtLine1 = new Point3D(extLine1.X, extLine1.Y);
    ((IntPoint) this).ExtLine2 = new Point3D(extLine2.X, extLine2.Y);
    ((IntPoint) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y);
    ((IntRect) this).Origin = new Point3D(((IntRect) this).Origin.X, ((IntRect) this).Origin.Y);
    ((IntRect) this).Height = textHeight;
    ((IntRect) this).Plane = (Plane) sketchPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 40, plane: sketchPlane);
  }

  public buShapeHole3(AngularDim another)
  {
    ((\u000E.\u0001) this).ExtLine1 = new Point3D();
    ((IntPoint) this).ExtLine2 = new Point3D();
    ((IntPoint) this).DimLinePosition = new Point3D();
    ((IntPoint) this).InsertionPoint = new Point3D();
    ((IntRect) this).QuadrantPoint = new Point3D();
    ((IntRect) this).Origin = new Point3D();
    ((IntRect) this).Height = 20.0;
    ((IntRect) this).Plane = Plane.XY;
    ((ClipType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u000E.\u0001) this).ExtLine1 = new Point3D(another.ExtLine1.X, another.ExtLine1.Y, another.ExtLine1.Z);
    ((IntPoint) this).ExtLine2 = new Point3D(another.ExtLine2.X, another.ExtLine2.Y, another.ExtLine2.Z);
    ((IntPoint) this).DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
    ((IntPoint) this).InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
    ((IntRect) this).Origin = new Point3D(another.Origin.X, another.Origin.Y, another.Origin.Z);
    ((IntRect) this).Height = another.Height;
    ((IntRect) this).Plane = (Plane) another.Plane.Clone();
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 39, plane: another.Plane);
  }

  public buShapeHole3(buAngularDim another)
  {
    ((\u000E.\u0001) this).ExtLine1 = new Point3D();
    ((IntPoint) this).ExtLine2 = new Point3D();
    ((IntPoint) this).DimLinePosition = new Point3D();
    ((IntPoint) this).InsertionPoint = new Point3D();
    ((IntRect) this).QuadrantPoint = new Point3D();
    ((IntRect) this).Origin = new Point3D();
    ((IntRect) this).Height = 20.0;
    ((IntRect) this).Plane = Plane.XY;
    ((ClipType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u000E.\u0001) this).ExtLine1 = new Point3D(((\u000E.\u0001) another).ExtLine1.X, ((\u000E.\u0001) another).ExtLine1.Y, ((\u000E.\u0001) another).ExtLine1.Z);
    ((IntPoint) this).ExtLine2 = new Point3D(((IntPoint) another).ExtLine2.X, ((IntPoint) another).ExtLine2.Y, ((IntPoint) another).ExtLine2.Z);
    ((IntPoint) this).DimLinePosition = new Point3D(((IntPoint) another).DimLinePosition.X, ((IntPoint) another).DimLinePosition.Y, ((IntPoint) another).DimLinePosition.Z);
    ((IntPoint) this).InsertionPoint = new Point3D(((IntPoint) another).InsertionPoint.X, ((IntPoint) another).InsertionPoint.Y, ((IntPoint) another).InsertionPoint.Z);
    ((IntRect) this).QuadrantPoint = new Point3D(((IntRect) another).QuadrantPoint.X, ((IntRect) another).QuadrantPoint.Y, ((IntRect) another).QuadrantPoint.Z);
    ((IntRect) this).Origin = new Point3D(((IntRect) another).Origin.X, ((IntRect) another).Origin.Y, ((IntRect) another).Origin.Z);
    ((IntRect) this).Height = ((IntRect) another).Height;
    ((IntRect) this).Plane = (Plane) ((IntRect) another).Plane.Clone();
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
    ((CustomDataSurrogate) this).ToolName = ((CustomDataSurrogate) another).ToolName;
    ((CustomDataSurrogate) this).LayerName = ((CustomDataSurrogate) another).LayerName;
    ((CustomDataSurrogate) this).LayerIndex = ((CustomDataSurrogate) another).LayerIndex;
    ((CustomDataSurrogate) this).Color = ((CustomDataSurrogate) another).Color;
    ((buUpperLine) this).Update((buEntityUpdateType) 39, plane: ((IntRect) another).Plane);
  }

  public override string ToString()
  {
    return $"AngularDim - ExtLine1 : {((\u000E.\u0001) this).ExtLine1.ToString()} - ExtLine2 : {((IntPoint) this).ExtLine2.ToString()}";
  }
}
