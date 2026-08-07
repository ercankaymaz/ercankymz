// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeEngrave
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using devDept.Geometry;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeEngrave : buShape
{
  internal Label \u0004;
  internal Label \u0005;
  internal new CheckBox \u0002;
  internal Label \u0006;

  public buShapeEngrave()
  {
    ((PolyFillType) this).DefiningPoint = new Point3D();
    ((PolyFillType) this).DimLinePosition = new Point3D();
    ((PolyFillType) this).InsertionPoint = new Point3D();
    ((JoinType) this).Height = 20.0;
    ((JoinType) this).isVertical = false;
    ((JoinType) this).Plane = Plane.XY;
    ((JoinType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
  }

  public buShapeEngrave(
    Plane dimPlane,
    Point3D definingPoint,
    Point3D dimLinePos,
    bool isVertical,
    double textHeight)
  {
    ((PolyFillType) this).DefiningPoint = new Point3D();
    ((PolyFillType) this).DimLinePosition = new Point3D();
    ((PolyFillType) this).InsertionPoint = new Point3D();
    ((JoinType) this).Height = 20.0;
    ((JoinType) this).isVertical = false;
    ((JoinType) this).Plane = Plane.XY;
    ((JoinType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((PolyFillType) this).DefiningPoint = new Point3D(definingPoint.X, definingPoint.Y, definingPoint.Z);
    ((PolyFillType) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y, dimLinePos.Z);
    ((JoinType) this).Height = textHeight;
    ((JoinType) this).isVertical = isVertical;
    ((JoinType) this).Plane = (Plane) dimPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 42, plane: dimPlane);
  }

  public buShapeEngrave(
    Plane sketchPlane,
    Point2D definingPoint,
    Point2D dimLinePos,
    bool isVertical,
    double textHeight)
  {
    ((PolyFillType) this).DefiningPoint = new Point3D();
    ((PolyFillType) this).DimLinePosition = new Point3D();
    ((PolyFillType) this).InsertionPoint = new Point3D();
    ((JoinType) this).Height = 20.0;
    ((JoinType) this).isVertical = false;
    ((JoinType) this).Plane = Plane.XY;
    ((JoinType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((PolyFillType) this).DefiningPoint = new Point3D(definingPoint.X, definingPoint.Y);
    ((PolyFillType) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y);
    ((JoinType) this).Height = textHeight;
    ((JoinType) this).isVertical = isVertical;
    ((JoinType) this).Plane = (Plane) sketchPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 42, plane: sketchPlane);
  }

  public buShapeEngrave(buOrdinateDim another)
  {
    ((PolyFillType) this).DefiningPoint = new Point3D();
    ((PolyFillType) this).DimLinePosition = new Point3D();
    ((PolyFillType) this).InsertionPoint = new Point3D();
    ((JoinType) this).Height = 20.0;
    ((JoinType) this).isVertical = false;
    ((JoinType) this).Plane = Plane.XY;
    ((JoinType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((PolyFillType) this).DefiningPoint = new Point3D(((PolyFillType) another).DefiningPoint.X, ((PolyFillType) another).DefiningPoint.Y, ((PolyFillType) another).DefiningPoint.Z);
    ((PolyFillType) this).DimLinePosition = new Point3D(((PolyFillType) another).DimLinePosition.X, ((PolyFillType) another).DimLinePosition.Y, ((PolyFillType) another).DimLinePosition.Z);
    ((PolyFillType) this).InsertionPoint = new Point3D(((PolyFillType) another).InsertionPoint.X, ((PolyFillType) another).InsertionPoint.Y, ((PolyFillType) another).InsertionPoint.Z);
    ((JoinType) this).Height = ((JoinType) another).Height;
    ((JoinType) this).isVertical = ((JoinType) another).isVertical;
    ((JoinType) this).Plane = (Plane) ((JoinType) another).Plane.Clone();
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
    ((buUpperLine) this).Update((buEntityUpdateType) 42, plane: ((JoinType) another).Plane);
  }
}
