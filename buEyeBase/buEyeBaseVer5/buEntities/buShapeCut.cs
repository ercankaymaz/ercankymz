// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeCut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Geometry;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeCut : buShape
{
  public Printer3DSettings Settings;
  internal IContainer \u0001;
  internal new ImageList \u0001;
  public new Button btn_cancel;
  public new Button btn_ok;
  internal ImageList \u0002;
  internal Label \u0001;
  internal new NumericUpDown \u0001;

  public abstract void m00181A();

  public buShapeCut()
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
  }

  public buShapeCut(
    Plane dimPlane,
    Point3D origin,
    double radius,
    Point3D dimLinePos,
    double textHeight)
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
    ((ClipType) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y, dimLinePos.Z);
    ((ClipType) this).Origin = new Point3D(((ClipType) this).Origin.X, ((ClipType) this).Origin.Y, ((ClipType) this).Origin.Z);
    ((PolyType) this).Height = textHeight;
    ((PolyType) this).Radius = radius;
    ((PolyType) this).Plane = (Plane) dimPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 41, plane: dimPlane);
  }

  public buShapeCut(
    Plane sketchPlane,
    Point3D origin,
    double radius,
    Point2D dimLinePos,
    double textHeight)
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
    ((ClipType) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y);
    ((ClipType) this).Origin = new Point3D(((ClipType) this).Origin.X, ((ClipType) this).Origin.Y);
    ((PolyType) this).Height = textHeight;
    ((PolyType) this).Radius = radius;
    ((PolyType) this).Plane = (Plane) sketchPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 41, plane: sketchPlane);
  }
}
