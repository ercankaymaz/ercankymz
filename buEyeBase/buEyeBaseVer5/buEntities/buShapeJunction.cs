// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeJunction
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

public class buShapeJunction : buShape
{
  internal NumericUpDown \u0004;
  internal new Label \u0007;
  internal NumericUpDown \u0005;
  internal RadioButton \u0001;
  internal RadioButton \u0002;

  public buShapeJunction(OrdinateDim another)
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
    ((PolyFillType) this).DefiningPoint = new Point3D(another.DefiningPoint.X, another.DefiningPoint.Y, another.DefiningPoint.Z);
    ((PolyFillType) this).DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
    ((PolyFillType) this).InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
    ((JoinType) this).Height = another.Height;
    ((JoinType) this).isVertical = another.IsVertical;
    ((JoinType) this).Plane = (Plane) another.Plane.Clone();
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 42, plane: another.Plane);
  }

  public abstract void m001827();

  public buShapeJunction()
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
  }

  public buShapeJunction(
    Plane dimPlane,
    Point3D origin,
    double radius,
    Point3D dimLinePos,
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
    ((EndType) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y, dimLinePos.Z);
    ((EndType) this).Origin = new Point3D(((EndType) this).Origin.X, ((EndType) this).Origin.Y, ((EndType) this).Origin.Z);
    ((EndType) this).Height = textHeight;
    ((EndType) this).Radius = radius;
    ((\u0004.\u0001) this).Plane = (Plane) dimPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 43, plane: dimPlane);
  }
}
