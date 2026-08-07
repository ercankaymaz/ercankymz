// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buAngularDim
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.Events;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buAngularDim : buEntity
{
  public new Panel pnl_base;
  public buSpin spn_stockxminusoffset;
  public buButton btn_ok;
  public buSpin spn_stockxplusoffset;
  public buButton btn_cancel;
  public buSpin spn_stocktolorance;
  public buSpin spn_stockoffset;
  public buSpin spn_stockzminusoffset;
  public buSpin spn_stockzplusoffset;

  public void Mirror(Point3D BasePoint, Point3D MirrorPoint, Plane planeMirror)
  {
    try
    {
      Entity copiedEntity1 = (Entity) null;
      buAngularDim.Copy((buEntity) this, ref copiedEntity1);
      Vector3D X = new Vector3D(BasePoint, MirrorPoint);
      devDept.Geometry.Mirror xform = new devDept.Geometry.Mirror(new Plane(BasePoint, X, planeMirror.AxisZ));
      copiedEntity1.TransformBy((Transformation) xform);
      if (this.GetType() == typeof (buPoint))
      {
        devDept.Eyeshot.Entities.Point point = copiedEntity1 as devDept.Eyeshot.Entities.Point;
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
        devDept.Eyeshot.Entities.Region region = copiedEntity1 as devDept.Eyeshot.Entities.Region;
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
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void TransformBy(Transformation T)
  {
    try
    {
      Entity copiedEntity1 = (Entity) null;
      buAngularDim.Copy((buEntity) this, ref copiedEntity1);
      copiedEntity1.TransformBy(T);
      if (this.GetType() == typeof (buPoint))
      {
        devDept.Eyeshot.Entities.Point point = copiedEntity1 as devDept.Eyeshot.Entities.Point;
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
        devDept.Eyeshot.Entities.Region region = copiedEntity1 as devDept.Eyeshot.Entities.Region;
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
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static buEntity Copy(buEntity refEntity)
  {
    buEntity buEntity1;
    if (refEntity == null)
    {
      buEntity1 = (buEntity) null;
    }
    else
    {
      buEntity buEntity2 = (buEntity) null;
      if (refEntity.GetType() == typeof (buPoint))
        buEntity2 = (buEntity) new buMultilineText((buPoint) refEntity);
      else if (refEntity.GetType() == typeof (buLine))
        buEntity2 = (buEntity) new buMultilineText((buLine) refEntity);
      else if (refEntity.GetType() == typeof (buArc))
        buEntity2 = (buEntity) new buEntityList((buArc) refEntity);
      else if (refEntity.GetType() == typeof (buCircle))
        buEntity2 = (buEntity) new buShape((buCircle) refEntity);
      else if (refEntity.GetType() == typeof (buEllipse))
        buEntity2 = (buEntity) new buShape((buEllipse) refEntity);
      else if (refEntity.GetType() == typeof (buLinearPath))
        buEntity2 = (buEntity) new buShape((buLinearPath) refEntity);
      else if (refEntity.GetType() == typeof (buCurve))
        buEntity2 = (buEntity) new buShapeRectangle((buCurve) refEntity);
      else if (refEntity.GetType() == typeof (buCompositeCurve))
        buEntity2 = (buEntity) new buShapeCircle((buCompositeCurve) refEntity);
      else if (refEntity.GetType() == typeof (buUpperLine))
        buEntity2 = (buEntity) new buShapeFreeDraw((buUpperLine) refEntity);
      else if (refEntity.GetType() == typeof (buRegion))
        buEntity2 = (buEntity) new buShapePolygon((buRegion) refEntity);
      else if (refEntity.GetType() == typeof (buMesh))
        buEntity2 = (buEntity) new buShapeFreeLines((buMesh) refEntity);
      else if (refEntity.GetType() == typeof (buLinearDim))
        buEntity2 = (buEntity) new buShapeHole((buLinearDim) refEntity);
      else if (refEntity.GetType() == typeof (buAngularDim))
        buEntity2 = (buEntity) new buShapeHole3((buAngularDim) refEntity);
      else if (refEntity.GetType() == typeof (buDiametricDim))
        buEntity2 = (buEntity) new buShapeProfiling((buDiametricDim) refEntity);
      else if (refEntity.GetType() == typeof (buRadialDim))
        buEntity2 = (buEntity) new buShapeText((buRadialDim) refEntity);
      else if (refEntity.GetType() == typeof (buOrdinateDim))
        buEntity2 = (buEntity) new buShapeEngrave((buOrdinateDim) refEntity);
      else if (refEntity.GetType() == typeof (buText))
        buEntity2 = (buEntity) new buLinearPathCam((buText) refEntity);
      else if (refEntity.GetType() == typeof (buMultilineText))
        buEntity2 = (buEntity) new buArcCam((buMultilineText) refEntity);
      if (((CustomData) refEntity).Marble != null)
        ((CustomData) buEntity2).Marble = (MarbleInfo) new Line2D(((CustomData) refEntity).Marble);
      if (((CustomData) refEntity).Sewing != null)
        ((CustomData) buEntity2).Sewing = (SewingInfo) new EntityInfo(((CustomData) refEntity).Sewing);
      if (((CustomData) refEntity).Shape != null)
        ((CustomData) buEntity2).Shape = (EntityShapeInfo) new SewingPunteriz(((CustomData) refEntity).Shape);
      if (((CustomData) refEntity).Info != null)
        ((CustomData) buEntity2).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) refEntity).Info);
      if (((CustomData) refEntity).Cutter != null)
        ((CustomData) buEntity2).Cutter = (CutterInfo) new AnalyseEntitiesResult(((CustomData) refEntity).Cutter);
      if (((CustomData) refEntity).Dimension != null)
        ((CustomData) buEntity2).Dimension = (DimensionInfo) new CharLibrary5(((CustomData) refEntity).Dimension);
      buEntity1 = buEntity2;
    }
    return buEntity1;
  }

  public static void Copy(
    buEntity refEntity,
    ref Entity copiedEntity,
    bool CheckDuplicated = false,
    double Resolution = 0.001)
  {
    if (refEntity == null)
      return;
    if (refEntity.GetType() == typeof (buPoint))
      copiedEntity = (Entity) new devDept.Eyeshot.Entities.Point(buLinearDim.ToPoint3D(((CustomData) refEntity).StartPoint));
    else if (refEntity.GetType() == typeof (buLine))
      copiedEntity = (Entity) new Line(buLinearDim.ToPoint3D(((CustomData) refEntity).StartPoint), buLinearDim.ToPoint3D(((CustomData) refEntity).EndPoint));
    else if (refEntity.GetType() == typeof (buUpperLine))
      copiedEntity = (Entity) new Line(buLinearDim.ToPoint3D(((CustomData) refEntity).StartPoint), buLinearDim.ToPoint3D(((CustomData) refEntity).EndPoint));
    else if (refEntity.GetType() == typeof (buArc))
    {
      if (!buConversion5.EQ(((CustomDataSurrogate) refEntity).Center, new Point3D()))
      {
        ((CustomDataSurrogate) refEntity).Plane.Origin = new Point3D();
        copiedEntity = (Entity) new Arc(((CustomDataSurrogate) refEntity).Plane, buLinearDim.ToPoint3D(((CustomDataSurrogate) refEntity).Center), ((CustomDataSurrogate) refEntity).Radius, buLinearDim.ToPoint3D(((CustomData) refEntity).StartPoint), buLinearDim.ToPoint3D(((CustomData) refEntity).EndPoint), false);
      }
      else
        copiedEntity = (Entity) new Arc(((CustomDataSurrogate) refEntity).Plane, buLinearDim.ToPoint3D(((CustomDataSurrogate) refEntity).Center), ((CustomDataSurrogate) refEntity).Radius, buLinearDim.ToPoint3D(((CustomData) refEntity).StartPoint), buLinearDim.ToPoint3D(((CustomData) refEntity).EndPoint), false);
    }
    else if (refEntity.GetType() == typeof (buCircle))
      copiedEntity = (Entity) new Circle(((CustomDataSurrogate) refEntity).Plane, buLinearDim.ToPoint3D(((CustomDataSurrogate) refEntity).Center), ((CustomDataSurrogate) refEntity).Radius);
    else if (refEntity.GetType() == typeof (buEllipse))
      copiedEntity = (Entity) new Ellipse(((CustomDataSurrogate) refEntity).Plane, buLinearDim.ToPoint3D(((CustomDataSurrogate) refEntity).Center), ((CustomDataSurrogate) refEntity).RadiusX, ((CustomDataSurrogate) refEntity).RadiusY);
    else if (refEntity.GetType() == typeof (buLinearPath))
    {
      copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) buLinearDim.ToPoint3D(((CustomDataSurrogate) refEntity).Vertices));
      if (CheckDuplicated)
        buText.FixVerticeDublicated(ref copiedEntity);
    }
    else if (refEntity.GetType() == typeof (buCurve))
    {
      if (((CustomDataSurrogate) refEntity).isRational)
      {
        List<Point4D> point4DList = new List<Point4D>();
        for (int index = 0; index <= ((CustomDataSurrogate) refEntity).ControlPoints.Count - 1; ++index)
          point4DList.Add(new Point4D(((CustomDataSurrogate) refEntity).ControlPoints[index].X, ((CustomDataSurrogate) refEntity).ControlPoints[index].Y, ((CustomDataSurrogate) refEntity).ControlPoints[index].Z, ((CustomDataSurrogate) refEntity).ControlPoints[index].W));
        copiedEntity = (Entity) new Curve(((CustomDataSurrogate) refEntity).Degree, ((CustomDataSurrogate) refEntity).KnotVector.ToArray(), ((CustomDataSurrogate) refEntity).ControlPoints.ToArray());
      }
      else
      {
        List<Point3D> ctrlPoints = new List<Point3D>();
        for (int index = 0; index <= ((CustomDataSurrogate) refEntity).ControlPoints.Count - 1; ++index)
          ctrlPoints.Add(new Point3D(((CustomDataSurrogate) refEntity).ControlPoints[index].X, ((CustomDataSurrogate) refEntity).ControlPoints[index].Y, ((CustomDataSurrogate) refEntity).ControlPoints[index].Z));
        copiedEntity = (Entity) new Curve(((CustomDataSurrogate) refEntity).Degree, (IList<Point3D>) ctrlPoints);
      }
    }
    else if (refEntity.GetType() == typeof (buCompositeCurve))
    {
      List<ICurve> curveList = new List<ICurve>();
      for (int index = 0; index <= ((CustomDataSurrogate) refEntity).CurveList.Count - 1; ++index)
      {
        Entity copiedEntity1 = (Entity) null;
        buAngularDim.Copy(((CustomDataSurrogate) refEntity).CurveList[index], ref copiedEntity1);
        curveList.Add((ICurve) copiedEntity1);
      }
      copiedEntity = (Entity) new CompositeCurve((IEnumerable<ICurve>) curveList, true);
    }
    else if (refEntity.GetType() == typeof (buRegion))
    {
      List<ICurve> curveList = new List<ICurve>();
      for (int index = 0; index <= ((CustomDataSurrogate) refEntity).CurveList.Count - 1; ++index)
      {
        Entity copiedEntity2 = (Entity) null;
        buAngularDim.Copy(((CustomDataSurrogate) refEntity).CurveList[index], ref copiedEntity2);
        curveList.Add((ICurve) copiedEntity2);
      }
      copiedEntity = (Entity) new CompositeCurve((IEnumerable<ICurve>) curveList);
    }
    else if (refEntity.GetType() == typeof (buMesh))
    {
      List<Point3D> copiedPoint = new List<Point3D>();
      List<IndexTriangle> triangles = new List<IndexTriangle>();
      buVector5.Copy(((CustomDataSurrogate) refEntity).Vertices, ref copiedPoint);
      for (int index = 0; index <= ((MyFileSerializer) refEntity).Triangles.Count - 1; ++index)
        triangles.Add(new IndexTriangle(((MyFileSerializer) refEntity).Triangles[index].V1, ((MyFileSerializer) refEntity).Triangles[index].V2, ((MyFileSerializer) refEntity).Triangles[index].V3));
      copiedEntity = (Entity) new Mesh((IList<Point3D>) copiedPoint, (IList<IndexTriangle>) triangles);
    }
    else if (refEntity.GetType() == typeof (buLinearDim))
    {
      copiedEntity = (Entity) new LinearDim(((PolyNode) refEntity).Plane, ((PolyNode) refEntity).ExtLine1, ((PolyNode) refEntity).ExtLine2, ((PolyNode) refEntity).DimLinePosition, ((PolyNode) refEntity).Height);
      if (((PolyNode) refEntity).TextOverride.Trim().Length > 0)
        ((Dimension) copiedEntity).TextOverride = ((PolyNode) refEntity).TextOverride;
    }
    else if (refEntity.GetType() == typeof (buAngularDim))
    {
      copiedEntity = (Entity) new AngularDim(((IntRect) refEntity).Plane, ((\u000E.\u0001) refEntity).ExtLine1, ((IntPoint) refEntity).ExtLine2, ((IntPoint) refEntity).DimLinePosition, ((IntRect) refEntity).Height);
      if (((ClipType) refEntity).TextOverride.Trim().Length > 0)
        ((Dimension) copiedEntity).TextOverride = ((ClipType) refEntity).TextOverride;
    }
    else if (refEntity.GetType() == typeof (buDiametricDim))
    {
      Circle circle = new Circle(((PolyType) refEntity).Plane, ((ClipType) refEntity).Origin, ((PolyType) refEntity).Radius);
      copiedEntity = (Entity) new DiametricDim(circle, ((ClipType) refEntity).DimLinePosition, ((PolyType) refEntity).Height);
      if (((PolyFillType) refEntity).TextOverride.Trim().Length > 0)
        ((Dimension) copiedEntity).TextOverride = ((PolyFillType) refEntity).TextOverride;
    }
    else if (refEntity.GetType() == typeof (buRadialDim))
    {
      Circle circle = new Circle(((\u0004.\u0001) refEntity).Plane, ((EndType) refEntity).Origin, ((EndType) refEntity).Radius);
      copiedEntity = (Entity) new RadialDim(circle, ((EndType) refEntity).DimLinePosition, ((EndType) refEntity).Height);
      if (((\u0004.\u0001) refEntity).TextOverride.Trim().Length > 0)
        ((Dimension) copiedEntity).TextOverride = ((\u0004.\u0001) refEntity).TextOverride;
    }
    else if (refEntity.GetType() == typeof (buOrdinateDim))
    {
      copiedEntity = (Entity) new OrdinateDim(((JoinType) refEntity).Plane, ((PolyFillType) refEntity).DefiningPoint, ((PolyFillType) refEntity).DimLinePosition, ((JoinType) refEntity).isVertical, ((JoinType) refEntity).Height);
      if (((JoinType) refEntity).TextOverride.Trim().Length > 0)
        ((Dimension) copiedEntity).TextOverride = ((JoinType) refEntity).TextOverride;
    }
    else if (refEntity.GetType() == typeof (buText))
      copiedEntity = ((\u0084.\u0001) refEntity).StyleName.Length != 0 ? (Entity) new Text(((\u0015.\u0001) refEntity).Plane, ((\u0084.\u0001) refEntity).InsertionPoint, ((\u0015.\u0001) refEntity).TextString, ((\u0015.\u0001) refEntity).Height, ((\u0084.\u0001) refEntity).Alignment, ((\u0084.\u0001) refEntity).StyleName, ((\u0084.\u0001) refEntity).Simplify) : (Entity) new Text(((\u0015.\u0001) refEntity).Plane, ((\u0084.\u0001) refEntity).InsertionPoint, ((\u0015.\u0001) refEntity).TextString, ((\u0015.\u0001) refEntity).Height, ((\u0084.\u0001) refEntity).Alignment);
    else if (refEntity.GetType() == typeof (buMultilineText))
      copiedEntity = ((\u0084.\u0001) refEntity).StyleName.Length != 0 ? (Entity) new MultilineText(((\u0084.\u0001) refEntity).Plane, ((\u0084.\u0001) refEntity).InsertionPoint, ((\u0084.\u0001) refEntity).TextString, ((\u0084.\u0001) refEntity).RectWidth, ((\u0084.\u0001) refEntity).Height, ((\u0084.\u0001) refEntity).LineSpaceDistance, ((\u0084.\u0001) refEntity).Alignment, ((\u0084.\u0001) refEntity).StyleName, ((\u0084.\u0001) refEntity).Simplify, ((\u0084.\u0001) refEntity).Wrap) : (Entity) new MultilineText(((\u0084.\u0001) refEntity).Plane, ((\u0084.\u0001) refEntity).InsertionPoint, ((\u0084.\u0001) refEntity).TextString, ((\u0084.\u0001) refEntity).RectWidth, ((\u0084.\u0001) refEntity).Height, ((\u0084.\u0001) refEntity).LineSpaceDistance, ((\u0084.\u0001) refEntity).Alignment);
    if (copiedEntity == null)
      return;
    CustomData CD = (CustomData) new ClipperOffset();
    if (((CustomDataSurrogate) refEntity).LayerName.Length > 0)
      copiedEntity.LayerName = ((CustomDataSurrogate) refEntity).LayerName;
    copiedEntity.Color = ((CustomDataSurrogate) refEntity).Color;
    buMesh.EntityToCustomData(refEntity, ref CD);
    copiedEntity.EntityData = (object) CD;
  }

  public static void Copy(Entity refEntity, ref buEntity copiedEntity, double Deviation = 0.01)
  {
    if (refEntity == null)
    {
      copiedEntity = (buEntity) null;
    }
    else
    {
      if (refEntity.GetType() == typeof (devDept.Eyeshot.Entities.Point))
      {
        devDept.Eyeshot.Entities.Point point = refEntity as devDept.Eyeshot.Entities.Point;
        copiedEntity = (buEntity) new buMultilineText(point.StartPoint);
      }
      else if (refEntity.GetType() == typeof (Line))
      {
        Line line = refEntity as Line;
        copiedEntity = (buEntity) new buMultilineText(line.StartPoint, line.EndPoint);
      }
      else if (refEntity.GetType() == typeof (buLineCam))
      {
        buLineCam buLineCam = refEntity as buLineCam;
        copiedEntity = (buEntity) new buMultilineText(buLineCam.StartPoint, buLineCam.EndPoint);
      }
      else if (refEntity.GetType() == typeof (Arc))
      {
        Arc arc = refEntity as Arc;
        copiedEntity = (buEntity) new buEntityList(arc.Plane, arc.Center, arc.Radius, arc.StartPoint, arc.EndPoint, false);
        if (buVector5.isPlaneXYorYX(arc.Plane) | buVector5.isPlaneXZorZX(arc.Plane) | buVector5.isPlaneYZorZY(arc.Plane))
        {
          ((CustomDataSurrogate) copiedEntity).StartAngle = buVector5.PointAngleByPlane(arc.StartPoint, arc.Center, arc.Plane);
          ((CustomDataSurrogate) copiedEntity).EndAngle = buVector5.PointAngleByPlane(arc.EndPoint, arc.Center, arc.Plane);
          ((CustomDataSurrogate) copiedEntity).StartAngle = Math.Round(buString5.RadianToDegree(arc.Angle.t0), 8);
          ((CustomDataSurrogate) copiedEntity).EndAngle = Math.Round(buString5.RadianToDegree(arc.Angle.t1), 8);
        }
        else
        {
          ((CustomDataSurrogate) copiedEntity).StartAngle = Math.Round(buString5.RadianToDegree(arc.Angle.t0), 8);
          ((CustomDataSurrogate) copiedEntity).EndAngle = Math.Round(buString5.RadianToDegree(arc.Angle.t1), 8);
        }
      }
      else if (refEntity.GetType() == typeof (buArcCam))
      {
        buArcCam buArcCam = refEntity as buArcCam;
        copiedEntity = (buEntity) new buEntityList(buArcCam.Plane, buArcCam.Center, buArcCam.Radius, buArcCam.StartPoint, buArcCam.EndPoint, false);
        if (((CustomData) buArcCam).get_isReverse())
          ((CustomData) copiedEntity).sortDirection = entitySortDirection.Reverse;
        else
          ((CustomData) copiedEntity).sortDirection = entitySortDirection.Normal;
      }
      else if (refEntity.GetType() == typeof (Circle))
      {
        Circle circle = refEntity as Circle;
        copiedEntity = (buEntity) new buEntityList(circle.Plane, circle.Center, circle.Radius);
      }
      else if (refEntity.GetType() == typeof (Ellipse))
      {
        Ellipse ellipse = refEntity as Ellipse;
        copiedEntity = (buEntity) new buShape(ellipse.Plane, ellipse.Center, ellipse.RadiusX, ellipse.RadiusY);
      }
      else if (refEntity.GetType() == typeof (LinearPath))
      {
        LinearPath linearPath = refEntity as LinearPath;
        copiedEntity = (buEntity) new buShape(((IEnumerable<Point3D>) linearPath.Vertices).ToList<Point3D>());
      }
      else if (refEntity.GetType() == typeof (LinearPathEx))
      {
        LinearPathEx linearPathEx = refEntity as LinearPathEx;
        copiedEntity = (buEntity) new buShape(((IEnumerable<Point3D>) linearPathEx.Vertices).ToList<Point3D>());
      }
      else if (refEntity.GetType() == typeof (EllipticalArc))
      {
        EllipticalArc ellipticalArc = refEntity as EllipticalArc;
        if (ellipticalArc.Vertices == null)
          ellipticalArc.Regen(0.01);
        copiedEntity = (buEntity) new buShape(((IEnumerable<Point3D>) ellipticalArc.Vertices).ToList<Point3D>());
      }
      else if (refEntity.GetType() == typeof (buLinearPathCam))
      {
        buLinearPathCam buLinearPathCam = refEntity as buLinearPathCam;
        copiedEntity = (buEntity) new buShape(((IEnumerable<Point3D>) buLinearPathCam.Vertices).ToList<Point3D>());
      }
      else if (refEntity.GetType() == typeof (Curve))
      {
        Curve curve = refEntity as Curve;
        if (curve.IsRational)
        {
          copiedEntity = (buEntity) new buShapeRectangle(curve.Degree, curve.KnotVector, curve.ControlPoints);
        }
        else
        {
          List<Point3D> ctrlPoints = new List<Point3D>();
          for (int index = 0; index <= curve.ControlPoints.Length - 1; ++index)
            ctrlPoints.Add(new Point3D(curve.ControlPoints[index].X, curve.ControlPoints[index].Y, curve.ControlPoints[index].Z));
          copiedEntity = (buEntity) new buShapeRectangle(curve.Degree, ctrlPoints);
        }
      }
      else if (refEntity.GetType() == typeof (CompositeCurve))
      {
        CompositeCurve compositeCurve = refEntity as CompositeCurve;
        List<buEntity> curveList = new List<buEntity>();
        for (int index = 0; index <= compositeCurve.CurveList.Count - 1; ++index)
        {
          buEntity copiedEntity1 = (buEntity) null;
          Entity copiedEntity2 = (Entity) null;
          buRadialDim.Copy((Entity) compositeCurve.CurveList[index], ref copiedEntity2);
          buAngularDim.Copy(copiedEntity2, ref copiedEntity1);
          curveList.Add(copiedEntity1);
        }
        copiedEntity = (buEntity) new buShapeCircle(curveList);
      }
      else if (refEntity.GetType() == typeof (buCompositeCurveCam))
      {
        buCompositeCurveCam compositeCurveCam = refEntity as buCompositeCurveCam;
        List<buEntity> curveList = new List<buEntity>();
        for (int index = 0; index <= compositeCurveCam.CurveList.Count - 1; ++index)
        {
          buEntity copiedEntity3 = (buEntity) null;
          Entity copiedEntity4 = (Entity) null;
          buRadialDim.Copy((Entity) compositeCurveCam.CurveList[index], ref copiedEntity4);
          buAngularDim.Copy(copiedEntity4, ref copiedEntity3);
          curveList.Add(copiedEntity3);
        }
        copiedEntity = (buEntity) new buShapeCircle(curveList);
      }
      else if (refEntity.GetType() == typeof (devDept.Eyeshot.Entities.Region))
      {
        devDept.Eyeshot.Entities.Region region = refEntity as devDept.Eyeshot.Entities.Region;
        List<buEntity> contours = new List<buEntity>();
        for (int index = 0; index <= region.ContourList.Count - 1; ++index)
        {
          buEntity copiedEntity5 = (buEntity) null;
          Entity copiedEntity6 = (Entity) null;
          buRadialDim.Copy((Entity) region.ContourList[index], ref copiedEntity6);
          buAngularDim.Copy(copiedEntity6, ref copiedEntity5);
          contours.Add(copiedEntity5);
        }
        copiedEntity = (buEntity) new buShapeSlot(contours);
      }
      else if (refEntity.GetType() == typeof (Mesh))
      {
        Mesh mesh = refEntity as Mesh;
        copiedEntity = (buEntity) new buShapeFreeLines((IList<Point3D>) mesh.Vertices, (IList<IndexTriangle>) mesh.Triangles);
      }
      else if (refEntity.GetType() == typeof (LinearDim))
      {
        LinearDim another = refEntity as LinearDim;
        copiedEntity = (buEntity) new buShapeHoleMulti(another);
      }
      else if (refEntity.GetType() == typeof (AngularDim))
      {
        AngularDim another = refEntity as AngularDim;
        copiedEntity = (buEntity) new buShapeHole3(another);
      }
      else if (refEntity.GetType() == typeof (DiametricDim))
      {
        DiametricDim another = refEntity as DiametricDim;
        copiedEntity = (buEntity) new buShapeProfiling(another);
      }
      else if (refEntity.GetType() == typeof (RadialDim))
      {
        RadialDim another = refEntity as RadialDim;
        copiedEntity = (buEntity) new buShapeText(another);
      }
      else if (refEntity.GetType() == typeof (OrdinateDim))
      {
        OrdinateDim another = refEntity as OrdinateDim;
        copiedEntity = (buEntity) new buShapeJunction(another);
      }
      else if (refEntity.GetType() == typeof (Text))
      {
        Text another = refEntity as Text;
        copiedEntity = (buEntity) new buLinearPathCam(another);
      }
      else if (refEntity.GetType() == typeof (MultilineText))
      {
        MultilineText another = refEntity as MultilineText;
        copiedEntity = (buEntity) new buArcCam(another);
      }
      if (DrawingFinisedEventArgs.baseModel != null)
      {
        try
        {
          refEntity.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) DrawingFinisedEventArgs.baseModel));
        }
        catch (Exception ex)
        {
        }
      }
      else
        refEntity.Regen(buSystem.RegenDeviation);
      if (copiedEntity == null)
        return;
      ((CustomDataSurrogate) copiedEntity).LayerName = refEntity.LayerName;
      ((CustomDataSurrogate) copiedEntity).Color = refEntity.Color;
      if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
      {
        Color color = refEntity.Color;
        if (buConversion5.GetLayerColorFromName(refEntity.LayerName, ref color))
          ((CustomDataSurrogate) copiedEntity).Color = color;
      }
      if (refEntity.BoxMax != (Point3D) null)
      {
        ((CustomData) copiedEntity).BoxMax = new Point3D(refEntity.BoxMax.X, refEntity.BoxMax.Y, refEntity.BoxMax.Z);
        ((CustomData) copiedEntity).BoxMin = new Point3D(refEntity.BoxMin.X, refEntity.BoxMin.Y, refEntity.BoxMin.Z);
      }
      if ((refEntity.EntityData == null ? 0 : (refEntity.EntityData is CustomData ? 1 : 0)) == 0)
        return;
      buMesh.CustomDataToEntity((CustomData) refEntity.EntityData, ref copiedEntity);
    }
  }

  public static void Copy(
    buEntitiesGroup EntGroup,
    ref List<buEntity> copiedEntity,
    bool Inside = true,
    bool OpenEntities = true,
    bool Solid = false,
    bool Text = false)
  {
    copiedEntity.Clear();
    if (((\u0084.\u0001) EntGroup.Outside).Entities.Count > 0)
      buText.Add(((\u0084.\u0001) EntGroup.Outside).Entities, ref copiedEntity);
    if ((EntGroup.Inside == null ? 0 : (EntGroup.Inside.Count > 0 & Inside ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= EntGroup.Inside.Count - 1; ++index)
        buText.Add(((\u0084.\u0001) EntGroup.Inside[index]).Entities, ref copiedEntity);
    }
    if ((EntGroup.OpenEntities == null ? 0 : (EntGroup.OpenEntities.Count > 0 & OpenEntities ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= EntGroup.OpenEntities.Count - 1; ++index)
        buText.Add(((\u0084.\u0001) EntGroup.OpenEntities[index]).Entities, ref copiedEntity);
    }
    if ((((DimensionGroup) EntGroup).Text == null ? 0 : (((\u0084.\u0001) ((DimensionGroup) EntGroup).Text).Entities.Count > 0 & Text ? 1 : 0)) != 0)
      buText.Add(((\u0084.\u0001) ((DimensionGroup) EntGroup).Text).Entities, ref copiedEntity);
    if ((((DimensionGroup) EntGroup).Solid == null ? 0 : (((\u0084.\u0001) ((DimensionGroup) EntGroup).Solid).Entities.Count > 0 & Solid ? 1 : 0)) == 0)
      return;
    buText.Add(((\u0084.\u0001) ((DimensionGroup) EntGroup).Text).Entities, ref copiedEntity);
  }
}
