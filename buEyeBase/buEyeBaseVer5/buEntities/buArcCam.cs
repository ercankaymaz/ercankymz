// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buArcCam
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buArcCam : Arc
{
  public bool ShowCancelButton;
  public string OkButtonText;
  public string CancelButtonText;
  public object ClassObject;

  public buArcCam(
    Point3D insPoint,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment,
    string styleName,
    bool simplify,
    bool wrap = true)
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
    ((\u0084.\u0001) this).Simplify = simplify;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((\u0084.\u0001) this).Wrap = wrap;
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(
    Plane textPlane,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment,
    string styleName,
    bool simplify,
    bool wrap = true)
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
    ((\u0084.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).Simplify = simplify;
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).Wrap = wrap;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(
    Plane textPlane,
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
    ((\u0084.\u0001) this).Plane = (Plane) textPlane.Clone();
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(
    double x,
    double y,
    double z,
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y, z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buArcCam(
    Plane sketchPlane,
    Point2D insPoint,
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
    if (sketchPlane != (Plane) null)
      ((\u0084.\u0001) this).Plane = (Plane) sketchPlane.Clone();
    else
      ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(
    Plane textPlane,
    Point3D insPoint,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment,
    string styleName,
    bool simplify,
    bool wrap = true)
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
    if (textPlane != (Plane) null)
      ((\u0084.\u0001) this).Plane = (Plane) textPlane.Clone();
    else
      ((\u0084.\u0001) this).Plane = Plane.XY;
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).Simplify = simplify;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((\u0084.\u0001) this).Wrap = wrap;
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(
    double x,
    double y,
    double z,
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y, z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((buUpperLine) this).Update((buEntityUpdateType) 46);
  }

  public buArcCam(
    Plane sketchPlane,
    Point2D insPoint,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment,
    string styleName,
    bool simplify,
    bool wrap = true)
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
    ((\u0084.\u0001) this).Plane = (Plane) sketchPlane.Clone();
    ((\u0084.\u0001) this).Height = height;
    ((\u0084.\u0001) this).Alignment = alignment;
    ((\u0084.\u0001) this).StyleName = styleName;
    ((\u0084.\u0001) this).Simplify = simplify;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((\u0084.\u0001) this).Wrap = wrap;
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(
    double x,
    double y,
    double z,
    string textString,
    double width,
    double height,
    double lineSpaceDistance,
    Text.alignmentType alignment,
    string styleName,
    bool simplify,
    bool wrap = true)
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
    ((\u0084.\u0001) this).Simplify = simplify;
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(x, y, z);
    ((\u0084.\u0001) this).RectWidth = width;
    ((\u0084.\u0001) this).LineSpaceDistance = lineSpaceDistance;
    ((\u0084.\u0001) this).Wrap = wrap;
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(MultilineText another)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
    ((\u0084.\u0001) this).TextString = another.TextString;
    ((\u0084.\u0001) this).Height = another.Height;
    ((\u0084.\u0001) this).RectWidth = another.RectWidth;
    ((\u0084.\u0001) this).LineSpaceDistance = another.LineSpaceDistance;
    ((\u0084.\u0001) this).Alignment = another.Alignment;
    ((\u0084.\u0001) this).StyleName = another.StyleName;
    ((\u0084.\u0001) this).Simplify = another.Simplify;
    ((\u0084.\u0001) this).Wrap = another.Wrap;
    ((\u0084.\u0001) this).Plane = (Plane) another.Plane.Clone();
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(buMultilineText another)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(((\u0084.\u0001) another).InsertionPoint.X, ((\u0084.\u0001) another).InsertionPoint.Y, ((\u0084.\u0001) another).InsertionPoint.Z);
    ((\u0084.\u0001) this).TextString = ((\u0084.\u0001) another).TextString;
    ((\u0084.\u0001) this).Height = ((\u0084.\u0001) another).Height;
    ((\u0084.\u0001) this).LineSpaceDistance = ((\u0084.\u0001) another).LineSpaceDistance;
    ((\u0084.\u0001) this).RectWidth = ((\u0084.\u0001) another).RectWidth;
    ((\u0084.\u0001) this).Height = ((\u0084.\u0001) another).Height;
    ((\u0084.\u0001) this).Alignment = ((\u0084.\u0001) another).Alignment;
    ((\u0084.\u0001) this).StyleName = ((\u0084.\u0001) another).StyleName;
    ((\u0084.\u0001) this).Simplify = ((\u0084.\u0001) another).Simplify;
    ((\u0084.\u0001) this).Wrap = ((\u0084.\u0001) another).Wrap;
    ((\u0084.\u0001) this).Plane = (Plane) ((\u0084.\u0001) another).Plane.Clone();
    ((CustomDataSurrogate) this).ToolName = ((CustomDataSurrogate) another).ToolName;
    ((CustomDataSurrogate) this).LayerName = ((CustomDataSurrogate) another).LayerName;
    ((CustomDataSurrogate) this).LayerIndex = ((CustomDataSurrogate) another).LayerIndex;
    ((CustomDataSurrogate) this).Color = ((CustomDataSurrogate) another).Color;
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(buText another)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(((\u0084.\u0001) another).InsertionPoint.X, ((\u0084.\u0001) another).InsertionPoint.Y, ((\u0084.\u0001) another).InsertionPoint.Z);
    ((\u0084.\u0001) this).TextString = ((\u0015.\u0001) another).TextString;
    ((\u0084.\u0001) this).Height = ((\u0015.\u0001) another).Height;
    ((\u0084.\u0001) this).Height = ((\u0015.\u0001) another).Height;
    ((\u0084.\u0001) this).Alignment = ((\u0084.\u0001) another).Alignment;
    ((\u0084.\u0001) this).StyleName = ((\u0084.\u0001) another).StyleName;
    ((\u0084.\u0001) this).Simplify = ((\u0084.\u0001) another).Simplify;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Plane = (Plane) ((\u0015.\u0001) another).Plane.Clone();
    ((CustomDataSurrogate) this).ToolName = ((CustomDataSurrogate) another).ToolName;
    ((CustomDataSurrogate) this).LayerName = ((CustomDataSurrogate) another).LayerName;
    ((CustomDataSurrogate) this).LayerIndex = ((CustomDataSurrogate) another).LayerIndex;
    ((CustomDataSurrogate) this).Color = ((CustomDataSurrogate) another).Color;
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public buArcCam(Text another)
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
    ((\u0084.\u0001) this).InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
    ((\u0084.\u0001) this).TextString = another.TextString;
    ((\u0084.\u0001) this).Height = another.Height;
    ((\u0084.\u0001) this).Alignment = another.Alignment;
    ((\u0084.\u0001) this).StyleName = another.StyleName;
    ((\u0084.\u0001) this).Simplify = another.Simplify;
    ((\u0084.\u0001) this).Wrap = true;
    ((\u0084.\u0001) this).Plane = (Plane) another.Plane.Clone();
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 47);
  }

  public override string ToString()
  {
    return $"MultilineText  = {((\u0084.\u0001) this).TextString} Height : {((\u0084.\u0001) this).Height.ToString()} Alignment : {((\u0084.\u0001) this).Alignment.ToString()} Pnt : ( {((\u0084.\u0001) this).InsertionPoint.X.ToString("f1")} , {((\u0084.\u0001) this).InsertionPoint.Y.ToString("f1")} , {((\u0084.\u0001) this).InsertionPoint.Y.ToString("f1")}";
  }

  public abstract void m001865();

  public buArcCam()
  {
    ((\u0084.\u0001) this).Entities = new List<buEntity>();
    ((\u0084.\u0001) this).Points = (List<Point3D>) null;
    ((IntersectNode) this).pntMassCenter = (Point3D) null;
    ((IntersectNode) this).GroupInfo = "";
    ((IntersectNode) this).Depth = 0.0;
    ((\u0008.\u0001) this).GroupType = entityGroupType.None;
    ((\u0008.\u0001) this).ToolType = entityToolType.None;
    ((\u0008.\u0001) this).Direction = ClockDirectionType.CCW;
    ((\u0008.\u0001) this).InOutType = entityInOutDirectionType.None;
    ((\u0018.\u0001) this).Tool = (ToolBase5) null;
    ((\u0018.\u0001) this).Layer = (LayerBase5) null;
    ((\u0012.\u0001) this).Aux = "";
    ((\u0012.\u0001) this).Marble = (marbleEntityData) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buArcCam(List<buEntity> entities)
  {
    ((\u0084.\u0001) this).Entities = new List<buEntity>();
    ((\u0084.\u0001) this).Points = (List<Point3D>) null;
    ((IntersectNode) this).pntMassCenter = (Point3D) null;
    ((IntersectNode) this).GroupInfo = "";
    ((IntersectNode) this).Depth = 0.0;
    ((\u0008.\u0001) this).GroupType = entityGroupType.None;
    ((\u0008.\u0001) this).ToolType = entityToolType.None;
    ((\u0008.\u0001) this).Direction = ClockDirectionType.CCW;
    ((\u0008.\u0001) this).InOutType = entityInOutDirectionType.None;
    ((\u0018.\u0001) this).Tool = (ToolBase5) null;
    ((\u0018.\u0001) this).Layer = (LayerBase5) null;
    ((\u0012.\u0001) this).Aux = "";
    ((\u0012.\u0001) this).Marble = (marbleEntityData) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    buRadialDim.Copy(entities, ref ((\u0084.\u0001) this).Entities);
  }

  public buArcCam(buEntityList Data)
  {
    ((\u0084.\u0001) this).Entities = new List<buEntity>();
    ((\u0084.\u0001) this).Points = (List<Point3D>) null;
    ((IntersectNode) this).pntMassCenter = (Point3D) null;
    ((IntersectNode) this).GroupInfo = "";
    ((IntersectNode) this).Depth = 0.0;
    ((\u0008.\u0001) this).GroupType = entityGroupType.None;
    ((\u0008.\u0001) this).ToolType = entityToolType.None;
    ((\u0008.\u0001) this).Direction = ClockDirectionType.CCW;
    ((\u0008.\u0001) this).InOutType = entityInOutDirectionType.None;
    ((\u0018.\u0001) this).Tool = (ToolBase5) null;
    ((\u0018.\u0001) this).Layer = (LayerBase5) null;
    ((\u0012.\u0001) this).Aux = "";
    ((\u0012.\u0001) this).Marble = (marbleEntityData) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((\u0084.\u0001) this).Entities = new List<buEntity>();
    for (int index = 0; index <= ((\u0084.\u0001) Data).Entities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buDiametricDim.Copy(((\u0084.\u0001) Data).Entities[index], ref copiedEntity);
      ((\u0084.\u0001) this).Entities.Add(copiedEntity);
    }
    if (((\u0084.\u0001) Data).Points != null)
    {
      ((\u0084.\u0001) this).Points = new List<Point3D>();
      buVector5.Copy(((\u0084.\u0001) Data).Points, ref ((\u0084.\u0001) this).Points);
    }
    if (((IntersectNode) Data).pntMassCenter != (Point3D) null)
      ((IntersectNode) this).pntMassCenter = F_NotchEdit.ToPoint3D(((IntersectNode) Data).pntMassCenter);
    if (((\u0018.\u0001) Data).Layer != null)
      ((\u0018.\u0001) this).Layer = (LayerBase5) new EditorCustomData(((\u0018.\u0001) Data).Layer);
    if (((\u0018.\u0001) Data).Tool != null)
      ((\u0018.\u0001) this).Tool = (ToolBase5) new ToolGeometry5(((\u0018.\u0001) Data).Tool);
    if (((\u0012.\u0001) Data).Marble == null)
      return;
    ((\u0012.\u0001) this).Marble = (marbleEntityData) new \u0007.\u0001(((\u0012.\u0001) Data).Marble);
  }

  public new void Translate(double dX, double dY, double dZ = 0.0)
  {
    for (int index = 0; index <= ((\u0084.\u0001) this).Entities.Count - 1; ++index)
      ((buLinearDim) ((\u0084.\u0001) this).Entities[index]).Translate(dX, dY, dZ);
    if (((\u0084.\u0001) this).Points == null)
      return;
    for (int index = 0; index <= ((\u0084.\u0001) this).Points.Count - 1; ++index)
    {
      ((\u0084.\u0001) this).Points[index].X = ((\u0084.\u0001) this).Points[index].X + dX;
      ((\u0084.\u0001) this).Points[index].Y = ((\u0084.\u0001) this).Points[index].Y + dY;
      ((\u0084.\u0001) this).Points[index].Z = ((\u0084.\u0001) this).Points[index].Y + dZ;
    }
  }

  public new void Rotate(double Angle, Vector3D axis, Point3D center)
  {
    for (int index = 0; index <= ((\u0084.\u0001) this).Entities.Count - 1; ++index)
      ((buLinearDim) ((\u0084.\u0001) this).Entities[index]).Rotate(Angle, axis, center);
    if (((\u0084.\u0001) this).Points == null)
      return;
    buCall.\u0001.Rotate(center, Angle, axis, ref ((\u0084.\u0001) this).Points);
  }

  public static ArrayList ToDefEntity(buEntityList refEntity, int Space)
  {
    ArrayList AL = new ArrayList();
    buLineCam.ToDefEntity(refEntity, Space, ref AL);
    return AL;
  }

  public double DirArrowDistances
  {
    [CompilerGenerated, SpecialName] get => ((CutterNotch) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterNotch) this).\u0001 = value;
  }

  public CamMoveType MoveType
  {
    [CompilerGenerated, SpecialName] get => ((CutterNotch) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterNotch) this).\u0001 = value;
  }

  public int CamID
  {
    [CompilerGenerated, SpecialName] get => ((CutterNotch) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterNotch) this).\u0001 = value;
  }

  public bool isReverse
  {
    [CompilerGenerated, SpecialName] get => ((CutterNotch) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterNotch) this).\u0001 = value;
  }
}
