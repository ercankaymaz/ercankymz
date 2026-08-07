// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeNotch
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeNotch : buShape
{
  internal NumericUpDown \u0008;
  internal new Label \u0010;
  internal NumericUpDown \u000E;
  internal new Label \u0011;
  internal NumericUpDown \u000F;
  internal new Label \u0012;
  internal new CheckBox \u0003;
  internal new Label \u0013;

  public buShapeNotch()
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
  }

  public buShapeNotch(Point3D insPoint, string textString, double height)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0015.\u0001) this).TextString = textString;
    ((\u0015.\u0001) this).Height = height;
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buShapeNotch(Plane textPlane, string textString, double height)
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
    ((\u0015.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buShapeNotch(
    Plane textPlane,
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
    ((\u0015.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0084.\u0001) this).Alignment = alignment;
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }
}
