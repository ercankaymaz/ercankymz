// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeHoleMulti
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeHoleMulti : buShapeHole
{
  private IContainer \u0001;
  public new Button btn_ok;
  internal TextBox \u0001;
  public new Button btn_cancel;
  public Button btn_save;

  public buShapeHoleMulti(LinearDim another)
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
    ((PolyNode) this).ExtLine1 = new Point3D(another.ExtLine1.X, another.ExtLine1.Y, another.ExtLine1.Z);
    ((PolyNode) this).ExtLine2 = new Point3D(another.ExtLine2.X, another.ExtLine2.Y, another.ExtLine2.Z);
    ((PolyNode) this).DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
    ((PolyNode) this).InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
    ((PolyNode) this).Height = another.Height;
    ((PolyNode) this).Plane = (Plane) another.Plane.Clone();
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 39, plane: another.Plane);
  }

  public override string ToString()
  {
    return $"LinarDim - ExtLine1 : {((PolyNode) this).ExtLine1.ToString()} - ExtLine2 : {((PolyNode) this).ExtLine2.ToString()}";
  }

  public abstract void m001813();

  public buShapeHoleMulti()
  {
    ((\u000E.\u0001) this).ExtLine1 = new Point3D();
    ((IntPoint) this).ExtLine2 = new Point3D();
    ((IntPoint) this).DimLinePosition = new Point3D();
    ((IntPoint) this).InsertionPoint = new Point3D();
    ((IntRect) this).QuadrantPoint = new Point3D();
    ((IntRect) this).Origin = new Point3D();
    ((IntRect) this).Height = 20.0;
    ((IntRect) this).Plane = Plane.XY;
    ((ClipType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
  }

  public buShapeHoleMulti(
    Plane dimPlane,
    Point3D extLine1,
    Point3D extLine2,
    Point3D dimLinePos,
    double textHeight)
  {
    ((\u000E.\u0001) this).ExtLine1 = new Point3D();
    ((IntPoint) this).ExtLine2 = new Point3D();
    ((IntPoint) this).DimLinePosition = new Point3D();
    ((IntPoint) this).InsertionPoint = new Point3D();
    ((IntRect) this).QuadrantPoint = new Point3D();
    ((IntRect) this).Origin = new Point3D();
    ((IntRect) this).Height = 20.0;
    ((IntRect) this).Plane = Plane.XY;
    ((ClipType) this).TextOverride = "";
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((\u000E.\u0001) this).ExtLine1 = new Point3D(extLine1.X, extLine1.Y, extLine1.Z);
    ((IntPoint) this).ExtLine2 = new Point3D(extLine2.X, extLine2.Y, extLine2.Z);
    ((IntPoint) this).DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y, dimLinePos.Z);
    ((IntRect) this).Height = textHeight;
    ((IntRect) this).Plane = (Plane) dimPlane.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 40, plane: dimPlane);
  }
}
