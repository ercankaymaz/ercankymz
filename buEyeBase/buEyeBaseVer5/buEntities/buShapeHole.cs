// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeHole
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buClipperLib;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeHole : buShape
{
  public buSpin spn_rightoffset;
  public buButton btn_stocksettings;
  public static List<string> Captions;
  public FormProperties PropertiesForm;

  public abstract void m00180C();

  public buShapeHole()
  {
    ((PolyNode) this).ExtLine1 = new Point3D();
    ((PolyNode) this).ExtLine2 = new Point3D();
    ((PolyNode) this).DimLinePosition = new Point3D();
    ((PolyNode) this).InsertionPoint = new Point3D();
    ((PolyNode) this).Height = 20.0;
    ((PolyNode) this).TextOverride = "";
    ((PolyNode) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
  }

  public buShapeHole(
    Plane dimPlane,
    Point3D extLine1,
    Point3D extLine2,
    Point3D dimLinePos,
    double textHeight)
  {
    ((PolyNode) this).ExtLine1 = new Point3D();
    ((PolyNode) this).ExtLine2 = new Point3D();
    ((PolyNode) this).DimLinePosition = new Point3D();
    ((PolyNode) this).InsertionPoint = new Point3D();
    ((PolyNode) this).Height = 20.0;
    ((PolyNode) this).TextOverride = "";
    ((PolyNode) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((PolyNode) this).ExtLine1 = new Point3D(extLine1.X, extLine1.Y, extLine1.Z);
    ((PolyNode) this).ExtLine2 = new Point3D(extLine2.X, extLine2.Y, extLine2.Z);
    ((PolyNode) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y, dimLinePos.Z);
    ((PolyNode) this).Height = textHeight;
    ((PolyNode) this).Plane = (Plane) dimPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 39, plane: dimPlane);
  }

  public buShapeHole(
    Plane sketchPlane,
    Point2D extLine1,
    Point2D extLine2,
    Point2D dimLinePos,
    double textHeight)
  {
    ((PolyNode) this).ExtLine1 = new Point3D();
    ((PolyNode) this).ExtLine2 = new Point3D();
    ((PolyNode) this).DimLinePosition = new Point3D();
    ((PolyNode) this).InsertionPoint = new Point3D();
    ((PolyNode) this).Height = 20.0;
    ((PolyNode) this).TextOverride = "";
    ((PolyNode) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((PolyNode) this).ExtLine1 = new Point3D(extLine1.X, extLine1.Y);
    ((PolyNode) this).ExtLine2 = new Point3D(extLine2.X, extLine2.Y);
    ((PolyNode) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y);
    ((PolyNode) this).Height = textHeight;
    ((PolyNode) this).Plane = (Plane) sketchPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 39, plane: sketchPlane);
  }

  public buShapeHole(buLinearDim another)
  {
    ((PolyNode) this).ExtLine1 = new Point3D();
    ((PolyNode) this).ExtLine2 = new Point3D();
    ((PolyNode) this).DimLinePosition = new Point3D();
    ((PolyNode) this).InsertionPoint = new Point3D();
    ((PolyNode) this).Height = 20.0;
    ((PolyNode) this).TextOverride = "";
    ((PolyNode) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((PolyNode) this).ExtLine1 = new Point3D(((PolyNode) another).ExtLine1.X, ((PolyNode) another).ExtLine1.Y, ((PolyNode) another).ExtLine1.Z);
    ((PolyNode) this).ExtLine2 = new Point3D(((PolyNode) another).ExtLine2.X, ((PolyNode) another).ExtLine2.Y, ((PolyNode) another).ExtLine2.Z);
    ((PolyNode) this).DimLinePosition = new Point3D(((PolyNode) another).DimLinePosition.X, ((PolyNode) another).DimLinePosition.Y, ((PolyNode) another).DimLinePosition.Z);
    ((PolyNode) this).InsertionPoint = new Point3D(((PolyNode) another).InsertionPoint.X, ((PolyNode) another).InsertionPoint.Y, ((PolyNode) another).InsertionPoint.Z);
    ((PolyNode) this).Height = ((PolyNode) another).Height;
    ((PolyNode) this).Plane = (Plane) ((PolyNode) another).Plane.Clone();
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
    ((buUpperLine) this).Update((buEntityUpdateType) 39, plane: ((PolyNode) another).Plane);
  }
}
