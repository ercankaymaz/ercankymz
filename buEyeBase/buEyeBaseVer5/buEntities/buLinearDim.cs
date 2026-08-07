// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buLinearDim
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buLinearDim : buEntity
{
  internal buSeparator \u0004;
  public new static List<string> Captions;
  public new FormProperties PropertiesForm;
  public new camParameters5 Settings;
  private IContainer \u0001;
  public new buButton btn_close;
  public new buGround buGround1;

  public static Point3D ToPoint3D(Point3D refPnt) => new Point3D(refPnt.X, refPnt.Y, refPnt.Z);

  public static List<Point3D> ToPoint3D(List<Point3D> refPnt)
  {
    List<Point3D> point3D = new List<Point3D>();
    for (int index = 0; index <= refPnt.Count - 1; ++index)
      point3D.Add(new Point3D(refPnt[index].X, refPnt[index].Y, refPnt[index].Z));
    return point3D;
  }

  public void Translate(double dx, double dy, double dz)
  {
    if (this.GetType() == typeof (buPoint))
    {
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buLine))
    {
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buArc))
    {
      ((CustomDataSurrogate) this).Center.X = ((CustomDataSurrogate) this).Center.X + dx;
      ((CustomDataSurrogate) this).Center.Y = ((CustomDataSurrogate) this).Center.Y + dy;
      ((CustomDataSurrogate) this).Center.Z = ((CustomDataSurrogate) this).Center.Z + dz;
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).MiddlePoint.X = ((CustomData) this).MiddlePoint.X + dx;
      ((CustomData) this).MiddlePoint.Y = ((CustomData) this).MiddlePoint.Y + dy;
      ((CustomData) this).MiddlePoint.Z = ((CustomData) this).MiddlePoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buCircle))
    {
      ((CustomDataSurrogate) this).Center.X = ((CustomDataSurrogate) this).Center.X + dx;
      ((CustomDataSurrogate) this).Center.Y = ((CustomDataSurrogate) this).Center.Y + dy;
      ((CustomDataSurrogate) this).Center.Z = ((CustomDataSurrogate) this).Center.Z + dz;
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buEllipse))
    {
      ((CustomDataSurrogate) this).Center.X = ((CustomDataSurrogate) this).Center.X + dx;
      ((CustomDataSurrogate) this).Center.Y = ((CustomDataSurrogate) this).Center.Y + dy;
      ((CustomDataSurrogate) this).Center.Z = ((CustomDataSurrogate) this).Center.Z + dz;
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buCurve))
    {
      for (int index = 0; index <= ((CustomDataSurrogate) this).ControlPoints.Count - 1; ++index)
      {
        ((CustomDataSurrogate) this).ControlPoints[index].X = ((CustomDataSurrogate) this).ControlPoints[index].X + dx;
        ((CustomDataSurrogate) this).ControlPoints[index].Y = ((CustomDataSurrogate) this).ControlPoints[index].Y + dy;
        ((CustomDataSurrogate) this).ControlPoints[index].Z = ((CustomDataSurrogate) this).ControlPoints[index].Z + dz;
      }
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buCompositeCurve))
    {
      for (int index = 0; index <= ((CustomDataSurrogate) this).CurveList.Count - 1; ++index)
        ((buLinearDim) ((CustomDataSurrogate) this).CurveList[index]).Translate(dx, dy, dz);
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buUpperLine))
    {
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buLinearPath))
    {
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buRegion))
    {
      for (int index = 0; index <= ((CustomDataSurrogate) this).CurveList.Count - 1; ++index)
        ((buLinearDim) ((CustomDataSurrogate) this).CurveList[index]).Translate(dx, dy, dz);
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buLinearDim))
    {
      ((PolyNode) this).ExtLine1.X = ((PolyNode) this).ExtLine1.X + dx;
      ((PolyNode) this).ExtLine1.Y = ((PolyNode) this).ExtLine1.Y + dy;
      ((PolyNode) this).ExtLine1.Z = ((PolyNode) this).ExtLine1.Z + dz;
      ((PolyNode) this).ExtLine2.X = ((PolyNode) this).ExtLine2.X + dx;
      ((PolyNode) this).ExtLine2.Y = ((PolyNode) this).ExtLine2.Y + dy;
      ((PolyNode) this).ExtLine2.Z = ((PolyNode) this).ExtLine2.Z + dz;
      ((PolyNode) this).InsertionPoint.X = ((PolyNode) this).InsertionPoint.X + dx;
      ((PolyNode) this).InsertionPoint.Y = ((PolyNode) this).InsertionPoint.Y + dy;
      ((PolyNode) this).InsertionPoint.Z = ((PolyNode) this).InsertionPoint.Z + dz;
      ((PolyNode) this).DimLinePosition.X = ((PolyNode) this).DimLinePosition.X + dx;
      ((PolyNode) this).DimLinePosition.Y = ((PolyNode) this).DimLinePosition.Y + dy;
      ((PolyNode) this).DimLinePosition.Z = ((PolyNode) this).DimLinePosition.Z + dz;
    }
    if (this.GetType() == typeof (buMesh))
    {
      ((CustomData) this).StartPoint.X = ((CustomData) this).StartPoint.X + dx;
      ((CustomData) this).StartPoint.Y = ((CustomData) this).StartPoint.Y + dy;
      ((CustomData) this).StartPoint.Z = ((CustomData) this).StartPoint.Z + dz;
      ((CustomData) this).EndPoint.X = ((CustomData) this).EndPoint.X + dx;
      ((CustomData) this).EndPoint.Y = ((CustomData) this).EndPoint.Y + dy;
      ((CustomData) this).EndPoint.Z = ((CustomData) this).EndPoint.Z + dz;
    }
    if (this.GetType() == typeof (buText))
    {
      ((\u0084.\u0001) this).InsertionPoint.X = ((\u0084.\u0001) this).InsertionPoint.X + dx;
      ((\u0084.\u0001) this).InsertionPoint.Y = ((\u0084.\u0001) this).InsertionPoint.Y + dy;
      ((\u0084.\u0001) this).InsertionPoint.Z = ((\u0084.\u0001) this).InsertionPoint.Z + dz;
    }
    if (this.GetType() == typeof (buMultilineText))
    {
      ((\u0084.\u0001) this).InsertionPoint.X = ((\u0084.\u0001) this).InsertionPoint.X + dx;
      ((\u0084.\u0001) this).InsertionPoint.Y = ((\u0084.\u0001) this).InsertionPoint.Y + dy;
      ((\u0084.\u0001) this).InsertionPoint.Z = ((\u0084.\u0001) this).InsertionPoint.Z + dz;
    }
    for (int index = 0; index <= ((CustomDataSurrogate) this).Vertices.Count - 1; ++index)
    {
      ((CustomDataSurrogate) this).Vertices[index].X = ((CustomDataSurrogate) this).Vertices[index].X + dx;
      ((CustomDataSurrogate) this).Vertices[index].Y = ((CustomDataSurrogate) this).Vertices[index].Y + dy;
      ((CustomDataSurrogate) this).Vertices[index].Z = ((CustomDataSurrogate) this).Vertices[index].Z + dz;
    }
    ((CustomData) this).BoxMax.X = ((CustomData) this).BoxMax.X + dx;
    ((CustomData) this).BoxMax.Y = ((CustomData) this).BoxMax.Y + dy;
    ((CustomData) this).BoxMax.Z = ((CustomData) this).BoxMax.Z + dz;
    ((CustomData) this).BoxMin.X = ((CustomData) this).BoxMin.X + dx;
    ((CustomData) this).BoxMin.Y = ((CustomData) this).BoxMin.Y + dy;
    ((CustomData) this).BoxMin.Z = ((CustomData) this).BoxMin.Z + dz;
  }

  public void Scale(Point3D fixedPoint, double sx, double sy, double sz = 1.0)
  {
    Entity copiedEntity1 = (Entity) null;
    buAngularDim.Copy((buEntity) this, ref copiedEntity1);
    copiedEntity1.Scale(fixedPoint, sx, sy, sz);
    if (this.GetType() == typeof (buPoint))
    {
      Point point = copiedEntity1 as Point;
      ((CustomData) this).StartPoint = new Point3D(point.StartPoint.X, point.StartPoint.Y, point.StartPoint.Z);
    }
    else if (this.GetType() == typeof (buLine))
    {
      Line line = copiedEntity1 as Line;
      ((CustomData) this).StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buArc))
    {
      Arc arc = copiedEntity1 as Arc;
      ((CustomDataSurrogate) this).Plane = (Plane) arc.Plane.Clone();
      ((CustomDataSurrogate) this).Center = new Point3D(arc.Center.X, arc.Center.Y, arc.Center.Z);
      ((CustomData) this).StartPoint = new Point3D(arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z);
      ((CustomData) this).MiddlePoint = new Point3D(arc.MidPoint.X, arc.MidPoint.Y, arc.MidPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buCircle))
    {
      Circle circle = copiedEntity1 as Circle;
      ((CustomDataSurrogate) this).Plane = (Plane) circle.Plane.Clone();
      ((CustomDataSurrogate) this).Center = new Point3D(circle.Center.X, circle.Center.Y, circle.Center.Z);
      ((CustomData) this).StartPoint = new Point3D(circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(circle.EndPoint.X, circle.EndPoint.Y, circle.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buEllipse))
    {
      Ellipse ellipse = copiedEntity1 as Ellipse;
      ((CustomDataSurrogate) this).Plane = (Plane) ellipse.Plane.Clone();
      ((CustomDataSurrogate) this).Center = new Point3D(ellipse.Center.X, ellipse.Center.Y, ellipse.Center.Z);
      ((CustomData) this).StartPoint = new Point3D(ellipse.StartPoint.X, ellipse.StartPoint.Y, ellipse.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(ellipse.EndPoint.X, ellipse.EndPoint.Y, ellipse.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buLinearPath))
    {
      LinearPath linearPath = copiedEntity1 as LinearPath;
      ((CustomData) this).StartPoint = new Point3D(linearPath.StartPoint.X, linearPath.StartPoint.Y, linearPath.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(linearPath.EndPoint.X, linearPath.EndPoint.Y, linearPath.EndPoint.Z);
      ((CustomDataSurrogate) this).Vertices.Clear();
      for (int index = 0; index <= linearPath.Vertices.Length - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(linearPath.Vertices[index].X, linearPath.Vertices[index].Y, linearPath.Vertices[index].Z));
    }
    else if (this.GetType() == typeof (buCurve))
    {
      Curve curve = copiedEntity1 as Curve;
      ((CustomData) this).StartPoint = new Point3D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
      ((CustomDataSurrogate) this).ControlPoints.Clear();
      for (int index = 0; index <= curve.ControlPoints.Length - 1; ++index)
        ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(curve.ControlPoints[index].X, curve.ControlPoints[index].Y, curve.ControlPoints[index].Z, curve.ControlPoints[index].W));
    }
    else if (this.GetType() == typeof (buCompositeCurve))
    {
      CompositeCurve compositeCurve = copiedEntity1 as CompositeCurve;
      ((CustomData) this).StartPoint = new Point3D(compositeCurve.StartPoint.X, compositeCurve.StartPoint.Y, compositeCurve.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(compositeCurve.EndPoint.X, compositeCurve.EndPoint.Y, compositeCurve.EndPoint.Z);
      ((CustomDataSurrogate) this).CurveList.Clear();
      for (int index = 0; index <= compositeCurve.CurveList.Count - 1; ++index)
      {
        Entity copiedEntity2 = (Entity) null;
        buRadialDim.Copy((Entity) compositeCurve.CurveList[index], ref copiedEntity2);
        ((CustomDataSurrogate) this).CurveList.Add(buDiametricDim.Copy(copiedEntity2));
      }
    }
    else if (this.GetType() == typeof (buRegion))
    {
      Region region = copiedEntity1 as Region;
      ((CustomDataSurrogate) this).CurveList.Clear();
      for (int index = 0; index <= region.ContourList.Count - 1; ++index)
      {
        Entity copiedEntity3 = (Entity) null;
        buRadialDim.Copy((Entity) region.ContourList[index], ref copiedEntity3);
        ((CustomDataSurrogate) this).CurveList.Add(buDiametricDim.Copy(copiedEntity3));
      }
    }
    else if (this.GetType() == typeof (buMesh))
    {
      Mesh mesh = copiedEntity1 as Mesh;
      ((CustomDataSurrogate) this).Vertices.Clear();
      for (int index = 0; index <= mesh.Vertices.Length - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(mesh.Vertices[index].X, mesh.Vertices[index].Y, mesh.Vertices[index].Z));
    }
    else if (this.GetType() == typeof (buText))
    {
      Text text = copiedEntity1 as Text;
      ((\u0084.\u0001) this).InsertionPoint = new Point3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
    }
    else if (this.GetType() == typeof (buMultilineText))
    {
      MultilineText multilineText = copiedEntity1 as MultilineText;
      ((\u0084.\u0001) this).InsertionPoint = new Point3D(multilineText.InsertionPoint.X, multilineText.InsertionPoint.Y, multilineText.InsertionPoint.Z);
    }
    ((buUpperLine) this).Regen(copiedEntity1);
  }

  public void Rotate(double Angle, Vector3D axis)
  {
    Entity copiedEntity1 = (Entity) null;
    buAngularDim.Copy((buEntity) this, ref copiedEntity1);
    copiedEntity1.Rotate(buString5.DegreeToRadian(Angle), axis);
    if (this.GetType() == typeof (buPoint))
    {
      Point point = copiedEntity1 as Point;
      ((CustomData) this).StartPoint = new Point3D(point.StartPoint.X, point.StartPoint.Y, point.StartPoint.Z);
    }
    else if (this.GetType() == typeof (buLine))
    {
      Line line = copiedEntity1 as Line;
      ((CustomData) this).StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buArc))
    {
      Arc arc = copiedEntity1 as Arc;
      ((CustomDataSurrogate) this).Plane = (Plane) arc.Plane.Clone();
      ((CustomDataSurrogate) this).Center = new Point3D(arc.Center.X, arc.Center.Y, arc.Center.Z);
      ((CustomData) this).StartPoint = new Point3D(arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z);
      ((CustomData) this).MiddlePoint = new Point3D(arc.MidPoint.X, arc.MidPoint.Y, arc.MidPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buCircle))
    {
      Circle circle = copiedEntity1 as Circle;
      ((CustomDataSurrogate) this).Plane = (Plane) circle.Plane.Clone();
      ((CustomDataSurrogate) this).Center = new Point3D(circle.Center.X, circle.Center.Y, circle.Center.Z);
      ((CustomData) this).StartPoint = new Point3D(circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(circle.EndPoint.X, circle.EndPoint.Y, circle.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buEllipse))
    {
      Ellipse ellipse = copiedEntity1 as Ellipse;
      ((CustomDataSurrogate) this).Plane = (Plane) ellipse.Plane.Clone();
      ((CustomDataSurrogate) this).Center = new Point3D(ellipse.Center.X, ellipse.Center.Y, ellipse.Center.Z);
      ((CustomData) this).StartPoint = new Point3D(ellipse.StartPoint.X, ellipse.StartPoint.Y, ellipse.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(ellipse.EndPoint.X, ellipse.EndPoint.Y, ellipse.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buLinearPath))
    {
      LinearPath linearPath = copiedEntity1 as LinearPath;
      ((CustomData) this).StartPoint = new Point3D(linearPath.StartPoint.X, linearPath.StartPoint.Y, linearPath.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(linearPath.EndPoint.X, linearPath.EndPoint.Y, linearPath.EndPoint.Z);
      ((CustomDataSurrogate) this).Vertices.Clear();
      for (int index = 0; index <= linearPath.Vertices.Length - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(linearPath.Vertices[index].X, linearPath.Vertices[index].Y, linearPath.Vertices[index].Z));
    }
    else if (this.GetType() == typeof (buCurve))
    {
      Curve curve = copiedEntity1 as Curve;
      ((CustomData) this).StartPoint = new Point3D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
      ((CustomDataSurrogate) this).ControlPoints.Clear();
      for (int index = 0; index <= curve.ControlPoints.Length - 1; ++index)
        ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(curve.ControlPoints[index].X, curve.ControlPoints[index].Y, curve.ControlPoints[index].Z, curve.ControlPoints[index].W));
    }
    else if (this.GetType() == typeof (buCompositeCurve))
    {
      CompositeCurve compositeCurve = copiedEntity1 as CompositeCurve;
      ((CustomData) this).StartPoint = new Point3D(compositeCurve.StartPoint.X, compositeCurve.StartPoint.Y, compositeCurve.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(compositeCurve.EndPoint.X, compositeCurve.EndPoint.Y, compositeCurve.EndPoint.Z);
      ((CustomDataSurrogate) this).CurveList.Clear();
      for (int index = 0; index <= compositeCurve.CurveList.Count - 1; ++index)
      {
        Entity copiedEntity2 = (Entity) null;
        buRadialDim.Copy((Entity) compositeCurve.CurveList[index], ref copiedEntity2);
        ((CustomDataSurrogate) this).CurveList.Add(buDiametricDim.Copy(copiedEntity2));
      }
    }
    else if (this.GetType() == typeof (buRegion))
    {
      Region region = copiedEntity1 as Region;
      ((CustomDataSurrogate) this).CurveList.Clear();
      for (int index = 0; index <= region.ContourList.Count - 1; ++index)
      {
        Entity copiedEntity3 = (Entity) null;
        buRadialDim.Copy((Entity) region.ContourList[index], ref copiedEntity3);
        ((CustomDataSurrogate) this).CurveList.Add(buDiametricDim.Copy(copiedEntity3));
      }
    }
    else if (this.GetType() == typeof (buMesh))
    {
      Mesh mesh = copiedEntity1 as Mesh;
      ((CustomDataSurrogate) this).Vertices.Clear();
      for (int index = 0; index <= mesh.Vertices.Length - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(mesh.Vertices[index].X, mesh.Vertices[index].Y, mesh.Vertices[index].Z));
    }
    else if (this.GetType() == typeof (buLinearDim))
    {
      LinearDim linearDim = copiedEntity1 as LinearDim;
      ((PolyNode) this).Plane = (Plane) linearDim.Plane.Clone();
      ((PolyNode) this).InsertionPoint = F_NotchEdit.ToPoint3D(linearDim.InsertionPoint);
      ((PolyNode) this).ExtLine1 = F_NotchEdit.ToPoint3D(linearDim.ExtLine1);
      ((PolyNode) this).ExtLine2 = F_NotchEdit.ToPoint3D(linearDim.ExtLine2);
      ((PolyNode) this).DimLinePosition = F_NotchEdit.ToPoint3D(linearDim.DimLinePosition);
    }
    else if (this.GetType() == typeof (buAngularDim))
    {
      AngularDim angularDim = copiedEntity1 as AngularDim;
      ((IntRect) this).Plane = (Plane) angularDim.Plane.Clone();
      ((\u000E.\u0001) this).ExtLine1 = F_NotchEdit.ToPoint3D(angularDim.ExtLine1);
      ((IntPoint) this).ExtLine2 = F_NotchEdit.ToPoint3D(angularDim.ExtLine2);
      ((IntPoint) this).DimLinePosition = F_NotchEdit.ToPoint3D(angularDim.DimLinePosition);
      ((IntPoint) this).InsertionPoint = F_NotchEdit.ToPoint3D(angularDim.InsertionPoint);
    }
    else if (this.GetType() == typeof (buRadialDim))
    {
      RadialDim radialDim = copiedEntity1 as RadialDim;
      ((\u0004.\u0001) this).Plane = (Plane) radialDim.Plane.Clone();
      ((EndType) this).DimLinePosition = F_NotchEdit.ToPoint3D(radialDim.DimLinePosition);
      ((EndType) this).InsertionPoint = F_NotchEdit.ToPoint3D(radialDim.InsertionPoint);
    }
    else if (this.GetType() == typeof (buDiametricDim))
    {
      DiametricDim diametricDim = copiedEntity1 as DiametricDim;
      ((PolyType) this).Plane = (Plane) diametricDim.Plane.Clone();
      ((ClipType) this).DimLinePosition = F_NotchEdit.ToPoint3D(diametricDim.DimLinePosition);
      ((ClipType) this).InsertionPoint = F_NotchEdit.ToPoint3D(diametricDim.InsertionPoint);
    }
    else if (this.GetType() == typeof (buOrdinateDim))
    {
      OrdinateDim ordinateDim = copiedEntity1 as OrdinateDim;
      ((JoinType) this).Plane = (Plane) ordinateDim.Plane.Clone();
      ((PolyFillType) this).DimLinePosition = F_NotchEdit.ToPoint3D(ordinateDim.DimLinePosition);
      ((PolyFillType) this).InsertionPoint = F_NotchEdit.ToPoint3D(ordinateDim.InsertionPoint);
      ((PolyFillType) this).DefiningPoint = F_NotchEdit.ToPoint3D(ordinateDim.DefiningPoint);
    }
    else if (this.GetType() == typeof (buText))
    {
      Text text = copiedEntity1 as Text;
      ((\u0084.\u0001) this).InsertionPoint = new Point3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
      ((CustomDataSurrogate) this).Vertices.Clear();
      if (text.Vertices != null)
      {
        for (int index = 0; index <= text.Vertices.Length - 1; ++index)
          ((CustomDataSurrogate) this).Vertices.Add(new Point3D(text.Vertices[index].X, text.Vertices[index].Y, text.Vertices[index].Z));
      }
    }
    else if (this.GetType() == typeof (buMultilineText))
    {
      MultilineText multilineText = copiedEntity1 as MultilineText;
      ((\u0084.\u0001) this).InsertionPoint = new Point3D(multilineText.InsertionPoint.X, multilineText.InsertionPoint.Y, multilineText.InsertionPoint.Z);
      ((CustomDataSurrogate) this).Vertices.Clear();
      if (multilineText.Vertices != null)
      {
        for (int index = 0; index <= multilineText.Vertices.Length - 1; ++index)
          ((CustomDataSurrogate) this).Vertices.Add(new Point3D(multilineText.Vertices[index].X, multilineText.Vertices[index].Y, multilineText.Vertices[index].Z));
      }
    }
    ((buUpperLine) this).Regen(copiedEntity1);
  }

  public void Rotate(double Angle, Vector3D axis, Point3D center)
  {
    Entity copiedEntity1 = (Entity) null;
    buAngularDim.Copy((buEntity) this, ref copiedEntity1);
    copiedEntity1.Rotate(buString5.DegreeToRadian(Angle), axis, center);
    if (this.GetType() == typeof (buPoint))
    {
      Point point = copiedEntity1 as Point;
      ((CustomData) this).StartPoint = new Point3D(point.StartPoint.X, point.StartPoint.Y, point.StartPoint.Z);
    }
    else if (this.GetType() == typeof (buLine))
    {
      Line line = copiedEntity1 as Line;
      ((CustomData) this).StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buArc))
    {
      Arc arc = copiedEntity1 as Arc;
      ((CustomDataSurrogate) this).Plane = (Plane) arc.Plane.Clone();
      ((CustomDataSurrogate) this).Center = new Point3D(arc.Center.X, arc.Center.Y, arc.Center.Z);
      ((CustomData) this).StartPoint = new Point3D(arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z);
      ((CustomData) this).MiddlePoint = new Point3D(arc.MidPoint.X, arc.MidPoint.Y, arc.MidPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buCircle))
    {
      Circle circle = copiedEntity1 as Circle;
      ((CustomDataSurrogate) this).Plane = (Plane) circle.Plane.Clone();
      ((CustomDataSurrogate) this).Center = new Point3D(circle.Center.X, circle.Center.Y, circle.Center.Z);
      ((CustomData) this).StartPoint = new Point3D(circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(circle.EndPoint.X, circle.EndPoint.Y, circle.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buEllipse))
    {
      Ellipse ellipse = copiedEntity1 as Ellipse;
      ((CustomDataSurrogate) this).Plane = (Plane) ellipse.Plane.Clone();
      ((CustomDataSurrogate) this).Center = new Point3D(ellipse.Center.X, ellipse.Center.Y, ellipse.Center.Z);
      ((CustomData) this).StartPoint = new Point3D(ellipse.StartPoint.X, ellipse.StartPoint.Y, ellipse.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(ellipse.EndPoint.X, ellipse.EndPoint.Y, ellipse.EndPoint.Z);
    }
    else if (this.GetType() == typeof (buLinearPath))
    {
      LinearPath linearPath = copiedEntity1 as LinearPath;
      ((CustomData) this).StartPoint = new Point3D(linearPath.StartPoint.X, linearPath.StartPoint.Y, linearPath.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(linearPath.EndPoint.X, linearPath.EndPoint.Y, linearPath.EndPoint.Z);
      ((CustomDataSurrogate) this).Vertices.Clear();
      for (int index = 0; index <= linearPath.Vertices.Length - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(linearPath.Vertices[index].X, linearPath.Vertices[index].Y, linearPath.Vertices[index].Z));
    }
    else if (this.GetType() == typeof (buCurve))
    {
      Curve curve = copiedEntity1 as Curve;
      ((CustomData) this).StartPoint = new Point3D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
      ((CustomDataSurrogate) this).ControlPoints.Clear();
      for (int index = 0; index <= curve.ControlPoints.Length - 1; ++index)
        ((CustomDataSurrogate) this).ControlPoints.Add(new Point4D(curve.ControlPoints[index].X, curve.ControlPoints[index].Y, curve.ControlPoints[index].Z, curve.ControlPoints[index].W));
    }
    else if (this.GetType() == typeof (buCompositeCurve))
    {
      CompositeCurve compositeCurve = copiedEntity1 as CompositeCurve;
      ((CustomData) this).StartPoint = new Point3D(compositeCurve.StartPoint.X, compositeCurve.StartPoint.Y, compositeCurve.StartPoint.Z);
      ((CustomData) this).EndPoint = new Point3D(compositeCurve.EndPoint.X, compositeCurve.EndPoint.Y, compositeCurve.EndPoint.Z);
      ((CustomDataSurrogate) this).CurveList.Clear();
      for (int index = 0; index <= compositeCurve.CurveList.Count - 1; ++index)
      {
        Entity copiedEntity2 = (Entity) null;
        buRadialDim.Copy((Entity) compositeCurve.CurveList[index], ref copiedEntity2);
        ((CustomDataSurrogate) this).CurveList.Add(buDiametricDim.Copy(copiedEntity2));
      }
    }
    else if (this.GetType() == typeof (buRegion))
    {
      Region region = copiedEntity1 as Region;
      ((CustomDataSurrogate) this).CurveList.Clear();
      for (int index = 0; index <= region.ContourList.Count - 1; ++index)
      {
        Entity copiedEntity3 = (Entity) null;
        buRadialDim.Copy((Entity) region.ContourList[index], ref copiedEntity3);
        ((CustomDataSurrogate) this).CurveList.Add(buDiametricDim.Copy(copiedEntity3));
      }
    }
    else if (this.GetType() == typeof (buMesh))
    {
      Mesh mesh = copiedEntity1 as Mesh;
      ((CustomDataSurrogate) this).Vertices.Clear();
      for (int index = 0; index <= mesh.Vertices.Length - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(mesh.Vertices[index].X, mesh.Vertices[index].Y, mesh.Vertices[index].Z));
    }
    else if (this.GetType() == typeof (buText))
    {
      Text text = copiedEntity1 as Text;
      ((\u0084.\u0001) this).InsertionPoint = new Point3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
      ((\u0015.\u0001) this).Plane = (Plane) text.Plane.Clone();
      ((CustomDataSurrogate) this).Vertices.Clear();
      if (text.Vertices != null)
      {
        for (int index = 0; index <= text.Vertices.Length - 1; ++index)
          ((CustomDataSurrogate) this).Vertices.Add(new Point3D(text.Vertices[index].X, text.Vertices[index].Y, text.Vertices[index].Z));
      }
    }
    else if (this.GetType() == typeof (buMultilineText))
    {
      ((Text) copiedEntity1).StyleName = ((Text) copiedEntity1).StyleName.Trim();
      MultilineText multilineText = copiedEntity1 as MultilineText;
      ((\u0084.\u0001) this).InsertionPoint = new Point3D(multilineText.InsertionPoint.X, multilineText.InsertionPoint.Y, multilineText.InsertionPoint.Z);
      ((\u0084.\u0001) this).Plane = (Plane) multilineText.Plane.Clone();
      ((CustomDataSurrogate) this).Vertices.Clear();
      if (multilineText.Vertices != null)
      {
        for (int index = 0; index <= multilineText.Vertices.Length - 1; ++index)
          ((CustomDataSurrogate) this).Vertices.Add(new Point3D(multilineText.Vertices[index].X, multilineText.Vertices[index].Y, multilineText.Vertices[index].Z));
      }
    }
    ((buUpperLine) this).Regen(copiedEntity1);
  }
}
