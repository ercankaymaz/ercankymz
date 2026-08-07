// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeText
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeText : buShape
{
  internal Panel \u0001;
  internal new Label \u0008;
  internal NumericUpDown \u0006;
  internal new Label \u000E;
  internal NumericUpDown \u0007;
  internal new Label \u000F;

  public buShapeText(
    Plane sketchPlane,
    Point3D origin,
    double radius,
    Point2D dimLinePos,
    double textHeight)
  {
    ((EndType) this).DimLinePosition = new Point3D();
    ((EndType) this).InsertionPoint = new Point3D();
    ((EndType) this).Origin = new Point3D();
    ((EndType) this).Height = 20.0;
    ((EndType) this).Radius = 20.0;
    ((\u0004.\u0001) this).Plane = Plane.XY;
    ((\u0004.\u0001) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((EndType) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y);
    ((EndType) this).Origin = new Point3D(((EndType) this).Origin.X, ((EndType) this).Origin.Y);
    ((EndType) this).Height = textHeight;
    ((EndType) this).Radius = radius;
    ((\u0004.\u0001) this).Plane = (Plane) sketchPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 43, plane: sketchPlane);
  }

  public buShapeText(RadialDim another)
  {
    ((EndType) this).DimLinePosition = new Point3D();
    ((EndType) this).InsertionPoint = new Point3D();
    ((EndType) this).Origin = new Point3D();
    ((EndType) this).Height = 20.0;
    ((EndType) this).Radius = 20.0;
    ((\u0004.\u0001) this).Plane = Plane.XY;
    ((\u0004.\u0001) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((EndType) this).DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
    ((EndType) this).InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
    ((EndType) this).Origin = new Point3D(another.Plane.Origin.X, another.Plane.Origin.Y, another.Plane.Origin.Z);
    ((EndType) this).Height = another.Height;
    ((EndType) this).Radius = another.Radius;
    ((\u0004.\u0001) this).Plane = (Plane) another.Plane.Clone();
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 43, plane: another.Plane);
  }

  public buShapeText(buRadialDim another)
  {
    ((EndType) this).DimLinePosition = new Point3D();
    ((EndType) this).InsertionPoint = new Point3D();
    ((EndType) this).Origin = new Point3D();
    ((EndType) this).Height = 20.0;
    ((EndType) this).Radius = 20.0;
    ((\u0004.\u0001) this).Plane = Plane.XY;
    ((\u0004.\u0001) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((EndType) this).DimLinePosition = new Point3D(((EndType) another).DimLinePosition.X, ((EndType) another).DimLinePosition.Y, ((EndType) another).DimLinePosition.Z);
    ((EndType) this).InsertionPoint = new Point3D(((EndType) another).InsertionPoint.X, ((EndType) another).InsertionPoint.Y, ((EndType) another).InsertionPoint.Z);
    ((EndType) this).Origin = new Point3D(((EndType) another).Origin.X, ((EndType) another).Origin.Y, ((EndType) another).Origin.Z);
    ((EndType) this).Height = ((EndType) another).Height;
    ((EndType) this).Radius = ((EndType) another).Radius;
    ((\u0004.\u0001) this).Plane = (Plane) ((\u0004.\u0001) another).Plane.Clone();
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
    ((buUpperLine) this).Update((buEntityUpdateType) 43, plane: ((\u0004.\u0001) another).Plane);
  }

  public override string ToString()
  {
    return $"RadisDim - Origin : {((EndType) this).Origin.ToString()} - Radius : {((EndType) this).Radius.ToString()}";
  }

  public abstract void m00182E();
}
