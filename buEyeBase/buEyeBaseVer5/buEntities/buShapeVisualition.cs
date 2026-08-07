// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeVisualition
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buShapeVisualition : buSerilization5
{
  internal CheckBox \u0004;
  internal Panel \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  public static byte f0037A0;
  public object EditValue;
  public object EditValue;
  public object EditValue;
  public object EditValue;
  public object EditValue;
  public object EditValue;

  public buShapeVisualition(Plane sketchPlane, Point2D insPoint, string textString, double height)
  {
    ((\u0015.\u0001) this).Plane = Plane.XY;
    ((\u0015.\u0001) this).TextString = "";
    ((\u0015.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0015.\u0001) this).TextString = textString;
    ((\u0015.\u0001) this).Height = height;
    ((\u0015.\u0001) this).Plane = (Plane) sketchPlane.Clone();
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buShapeVisualition(
    Point3D insPoint,
    string textString,
    double height,
    Text.alignmentType alignment)
  {
    ((\u0015.\u0001) this).Plane = Plane.XY;
    ((\u0015.\u0001) this).TextString = "";
    ((\u0015.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0015.\u0001) this).TextString = textString;
    ((\u0015.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }
}
