// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeProfiling
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

public class buShapeProfiling : buShape
{
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0003;
  internal new CheckBox \u0001;

  public buShapeProfiling(DiametricDim another)
  {
    ((ClipType) this).DimLinePosition = new Point3D();
    ((ClipType) this).InsertionPoint = new Point3D();
    ((ClipType) this).Origin = new Point3D();
    ((PolyType) this).Height = 20.0;
    ((PolyType) this).Radius = 20.0;
    ((PolyType) this).Plane = Plane.XY;
    ((PolyFillType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((ClipType) this).DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
    ((ClipType) this).InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
    ((ClipType) this).Origin = new Point3D(another.Plane.Origin.X, another.Plane.Origin.Y, another.Plane.Origin.Z);
    ((PolyType) this).Height = another.Height;
    ((PolyType) this).Radius = another.Radius;
    ((PolyType) this).Plane = (Plane) another.Plane.Clone();
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 41, plane: another.Plane);
  }

  public buShapeProfiling(buDiametricDim another)
  {
    ((ClipType) this).DimLinePosition = new Point3D();
    ((ClipType) this).InsertionPoint = new Point3D();
    ((ClipType) this).Origin = new Point3D();
    ((PolyType) this).Height = 20.0;
    ((PolyType) this).Radius = 20.0;
    ((PolyType) this).Plane = Plane.XY;
    ((PolyFillType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((ClipType) this).DimLinePosition = new Point3D(((ClipType) another).DimLinePosition.X, ((ClipType) another).DimLinePosition.Y, ((ClipType) another).DimLinePosition.Z);
    ((ClipType) this).InsertionPoint = new Point3D(((ClipType) another).InsertionPoint.X, ((ClipType) another).InsertionPoint.Y, ((ClipType) another).InsertionPoint.Z);
    ((ClipType) this).Origin = new Point3D(((ClipType) another).Origin.X, ((ClipType) another).Origin.Y, ((ClipType) another).Origin.Z);
    ((PolyType) this).Height = ((PolyType) another).Height;
    ((PolyType) this).Radius = ((PolyType) another).Radius;
    ((PolyType) this).Plane = (Plane) ((PolyType) another).Plane.Clone();
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
    ((buUpperLine) this).Update((buEntityUpdateType) 41, plane: ((PolyType) another).Plane);
  }

  public override string ToString()
  {
    return $"DiametricDim - Origin : {((ClipType) this).Origin.ToString()} - Radius : {((PolyType) this).Radius.ToString()}";
  }

  public abstract void m001821();
}
