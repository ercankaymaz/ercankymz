// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buLinearPathCam
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Drawing;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buLinearPathCam : LinearPath
{
  public int DecimalPlace;
  public Font FontCaptions;
  public Font FontValues;
  public int ValueWidth;
  public bool ShowOkButton;

  public buLinearPathCam(
    Plane sketchPlane,
    Point2D insPoint,
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
    ((\u0015.\u0001) this).Plane = (Plane) sketchPlane.Clone();
    ((\u0015.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).Simplify = simplify;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buLinearPathCam(
    double x,
    double y,
    double z,
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y, z);
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buLinearPathCam(Text another)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
    ((\u0015.\u0001) this).TextString = another.TextString;
    ((\u0015.\u0001) this).Height = another.Height;
    ((\u0084.\u0001) this).Alignment = another.Alignment;
    ((\u0084.\u0001) this).StyleName = another.StyleName;
    ((\u0084.\u0001) this).Simplify = another.Simplify;
    ((\u0015.\u0001) this).Plane = (Plane) another.Plane.Clone();
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buLinearPathCam(MultilineText another)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
    ((\u0015.\u0001) this).TextString = another.TextString;
    ((\u0015.\u0001) this).Height = another.Height;
    ((\u0084.\u0001) this).Alignment = another.Alignment;
    ((\u0084.\u0001) this).StyleName = another.StyleName;
    ((\u0084.\u0001) this).Simplify = another.Simplify;
    ((\u0015.\u0001) this).Plane = (Plane) another.Plane.Clone();
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buLinearPathCam(buText another)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(((\u0084.\u0001) another).InsertionPoint.X, ((\u0084.\u0001) another).InsertionPoint.Y, ((\u0084.\u0001) another).InsertionPoint.Z);
    ((\u0015.\u0001) this).TextString = ((\u0015.\u0001) another).TextString;
    ((\u0015.\u0001) this).Height = ((\u0015.\u0001) another).Height;
    ((\u0084.\u0001) this).Alignment = ((\u0084.\u0001) another).Alignment;
    ((\u0084.\u0001) this).StyleName = ((\u0084.\u0001) another).StyleName;
    ((\u0084.\u0001) this).Simplify = ((\u0084.\u0001) another).Simplify;
    ((\u0015.\u0001) this).Plane = (Plane) ((\u0015.\u0001) another).Plane.Clone();
    ((CustomDataSurrogate) this).LayerName = ((CustomDataSurrogate) another).LayerName;
    ((CustomDataSurrogate) this).ToolName = ((CustomDataSurrogate) another).ToolName;
    ((CustomDataSurrogate) this).LayerIndex = ((CustomDataSurrogate) another).LayerIndex;
    ((CustomDataSurrogate) this).Color = ((CustomDataSurrogate) another).Color;
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public buLinearPathCam(buMultilineText another)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(((\u0084.\u0001) another).InsertionPoint.X, ((\u0084.\u0001) another).InsertionPoint.Y, ((\u0084.\u0001) another).InsertionPoint.Z);
    ((\u0015.\u0001) this).TextString = ((\u0084.\u0001) another).TextString;
    ((\u0015.\u0001) this).Height = ((\u0084.\u0001) another).Height;
    ((\u0084.\u0001) this).Alignment = ((\u0084.\u0001) another).Alignment;
    ((\u0084.\u0001) this).StyleName = ((\u0084.\u0001) another).StyleName;
    ((\u0084.\u0001) this).Simplify = ((\u0084.\u0001) another).Simplify;
    ((\u0015.\u0001) this).Plane = (Plane) ((\u0084.\u0001) another).Plane.Clone();
    ((CustomDataSurrogate) this).ToolName = ((CustomDataSurrogate) another).ToolName;
    ((CustomDataSurrogate) this).LayerName = ((CustomDataSurrogate) another).LayerName;
    ((CustomDataSurrogate) this).LayerIndex = ((CustomDataSurrogate) another).LayerIndex;
    ((CustomDataSurrogate) this).Color = ((CustomDataSurrogate) another).Color;
    ((buUpperLine) this).Update((buEntityUpdateType) 45);
  }

  public override string ToString()
  {
    return $"Text  = {((\u0015.\u0001) this).TextString} Height : {((\u0015.\u0001) this).Height.ToString()} Alignment : {((\u0084.\u0001) this).Alignment.ToString()} Pnt : ( {((\u0084.\u0001) this).InsertionPoint.X.ToString("f1")} , {((\u0084.\u0001) this).InsertionPoint.Y.ToString("f1")} , {((\u0084.\u0001) this).InsertionPoint.Y.ToString("f1")}";
  }

  public abstract void m00184A();

  public buLinearPathCam()
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
  }

  public buLinearPathCam(
    Point3D insPoint,
    string textString,
    double width,
    double height,
    double lineSpaceDistance)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    Plane textPlane,
    string textString,
    double width,
    double height,
    double lineSpaceDistance)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    Plane textPlane,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    Point3D insPoint,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    Plane textPlane,
    Point3D insPoint,
    string textString,
    double width,
    double height,
    double lineSpaceDistance)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    double x,
    double y,
    string textString,
    double width,
    double height,
    double lineSpaceDistance)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    Plane sketchPlane,
    Point2D insPoint,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Plane = (Plane) sketchPlane.Clone();
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    Plane textPlane,
    Point3D insPoint,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    Plane textPlane,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment,
    string styleName)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    Point3D insPoint,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment,
    string styleName)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buLinearPathCam(
    double x,
    double y,
    double z,
    string textString,
    double width,
    double height,
    double lineSpaceDistance)
  {
    ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).TextString = "";
    ((\u0084.\u0001) this).RectWidth = 0.0;
    ((\u0084.\u0001) this).Height = 0.0;
    ((\u0084.\u0001) this).LineSpaceDistance = 0.0;
    ((\u0084.\u0001) this).StyleName = "";
    ((\u0084.\u0001) this).Simplify = false;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Alignment = Text.alignmentType.MiddleCenter;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u0084.\u0001) this).TextString = textString;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y, z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
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

  public CamLinkType LinkType
  {
    [CompilerGenerated, SpecialName] get => ((CutterProgramSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterProgramSettings) this).\u0001 = value;
  }

  public bool isLink
  {
    [CompilerGenerated, SpecialName] get => ((CutterNotch) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterNotch) this).\u0001 = value;
  }

  public int CamID
  {
    [CompilerGenerated, SpecialName] get => ((CutterNotch) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterNotch) this).\u0001 = value;
  }
}
