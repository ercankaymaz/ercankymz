// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buCompositeCurveCam
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buCompositeCurveCam : CompositeCurve
{
  public object EditValue;
  public int RowHeight;
  public int RowSpace;

  public buCompositeCurveCam(Plane textPlane, Point3D insPoint, string textString, double height)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buCompositeCurveCam(double x, double y, string textString, double height)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y);
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buCompositeCurveCam(
    Plane sketchPlane,
    Point2D insPoint,
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
    ((\u0015.\u0001) this).Plane = (Plane) sketchPlane.Clone();
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
    ((\u0084.\u0001) this).Alignment = alignment;
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buCompositeCurveCam(
    Plane textPlane,
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
    ((\u0015.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0084.\u0001) this).Alignment = alignment;
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buCompositeCurveCam(
    Plane textPlane,
    string textString,
    double height,
    Text.alignmentType alignment,
    string styleName)
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
    ((\u0084.\u0001) this).StyleName = styleName;
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buCompositeCurveCam(
    Point3D insPoint,
    string textString,
    double height,
    Text.alignmentType alignment,
    string styleName)
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
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buCompositeCurveCam(double x, double y, double z, string textString, double height)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y, z);
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buCompositeCurveCam(
    Point3D insPoint,
    string textString,
    double height,
    Text.alignmentType alignment,
    string styleName,
    bool simplify)
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
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).Simplify = simplify;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buCompositeCurveCam(
    Plane textPlane,
    string textString,
    double height,
    Text.alignmentType alignment,
    string styleName,
    bool simplify)
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
    ((\u0015.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0015.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).Simplify = simplify;
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buCompositeCurveCam(
    Plane textPlane,
    Point3D insPoint,
    string textString,
    double height,
    Text.alignmentType alignment,
    string styleName)
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
    ((\u0015.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0015.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buCompositeCurveCam(
    double x,
    double y,
    double z,
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y, z);
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public buCompositeCurveCam(
    Plane sketchPlane,
    Point2D insPoint,
    string textString,
    double height,
    Text.alignmentType alignment,
    string styleName)
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
    ((\u0015.\u0001) this).Plane = (Plane) sketchPlane.Clone();
    ((\u0015.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buCompositeCurveCam(
    Plane textPlane,
    Point3D insPoint,
    string textString,
    double height,
    Text.alignmentType alignment,
    string styleName,
    bool simplify)
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
    ((\u0015.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0015.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).Simplify = simplify;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buCompositeCurveCam(
    double x,
    double y,
    double z,
    string textString,
    double height,
    Text.alignmentType alignment,
    string styleName)
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
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y, z);
    ((buUpperLine) this).Update((buEntityUpdateType) 44);
  }

  public double DirArrowDistances
  {
    [CompilerGenerated, SpecialName] get => ((CutterProgramSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterProgramSettings) this).\u0001 = value;
  }

  public CamMoveType MoveType
  {
    [CompilerGenerated, SpecialName] get => ((CutterProgramSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterProgramSettings) this).\u0001 = value;
  }

  public int CamID
  {
    [CompilerGenerated, SpecialName] get => ((CutterProgramSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterProgramSettings) this).\u0001 = value;
  }
}
