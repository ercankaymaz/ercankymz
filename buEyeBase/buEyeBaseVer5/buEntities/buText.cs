// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buText
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buText : buEntity
{
  public new static List<string> Captions;
  public List<string> SourceList;
  public List<string> TargetList;
  private IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;

  public static void Add(buEntity refEntity, ref List<buEntity> copiedEntities)
  {
    copiedEntities.Add(buAngularDim.Copy(refEntity));
  }

  public static void Add(List<buEntity> refEntities, ref List<buEntity> copiedEntities)
  {
    copiedEntities.AddRange((IEnumerable<buEntity>) buDiametricDim.Copy(refEntities));
  }

  public static void Add(List<buEntity> refEntities, ref List<Entity> copiedEntities)
  {
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buAngularDim.Copy(refEntities[index], ref copiedEntity);
      if (copiedEntity != null)
        copiedEntities.Add(copiedEntity);
    }
  }

  public static bool isVerticeDublicated(buEntity Entity, double Resolution = 0.001)
  {
    string str = nameof (isVerticeDublicated);
    try
    {
      List<Point3D> point3DList = new List<Point3D>();
      Point3D point3D = new Point3D(double.MinValue, double.MinValue, double.MinValue);
      if (((CustomDataSurrogate) Entity).Vertices.Count <= 1)
        return false;
      for (int index = 1; index <= ((CustomDataSurrogate) Entity).Vertices.Count - 1; ++index)
      {
        if (buConversion5.EQ(((CustomDataSurrogate) Entity).Vertices[index - 1], ((CustomDataSurrogate) Entity).Vertices[index]))
          return true;
      }
      return false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLogException("buEntity", str, "");
      buException.throwException(ex, str, false);
      return false;
    }
  }

  public static void FixVerticeDublicated(ref buEntity Entity, double Resolution = 0.001)
  {
    string str = nameof (FixVerticeDublicated);
    try
    {
      if (((CustomDataSurrogate) Entity).Vertices.Count < 2)
        return;
      for (int index = 1; index <= ((CustomDataSurrogate) Entity).Vertices.Count - 1; ++index)
      {
        if (buConversion5.EQ(((CustomDataSurrogate) Entity).Vertices[index - 1], ((CustomDataSurrogate) Entity).Vertices[index]))
          ((CustomDataSurrogate) Entity).Vertices.RemoveAt(index);
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLogException("buEntity", str, "");
      buException.throwException(ex, str, false);
    }
  }

  public static void FixVerticeDublicated(ref Entity Entity, double Resolution = 0.001)
  {
    string str = nameof (FixVerticeDublicated);
    try
    {
      if (Entity.Vertices.Length < 2 || !(Entity is LinearPath))
        return;
      LinearPath linearPath = Entity as LinearPath;
      List<Point3D> point3DList = new List<Point3D>();
      point3DList.Add(new Point3D(Entity.Vertices[0].X, Entity.Vertices[0].Y, Entity.Vertices[0].Z));
      for (int index = 1; index <= Entity.Vertices.Length - 1; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        if (!buConversion5.\u003C\u003Ec.EQ(point3DList[point3DList.Count - 1], Entity.Vertices[index], Resolution))
          point3DList.Add(new Point3D(Entity.Vertices[index].X, Entity.Vertices[index].Y, Entity.Vertices[index].Z));
      }
      linearPath.Vertices = new Point3D[point3DList.Count];
      linearPath.Vertices = point3DList.ToArray();
      linearPath.Regen(0.01);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLogException("buEntity", str, "");
      buException.throwException(ex, str, false);
    }
  }

  public static void CopyProperties(buEntity baseEntity, ref buEntity copiedEntity)
  {
    buText.CopyProperties(baseEntity, true, true, true, true, true, true, ref copiedEntity);
  }

  public static void CopyProperties(
    buEntity baseEntity,
    bool typeDef,
    bool orientation,
    bool shape,
    bool info,
    bool modeproperties,
    bool dimension,
    ref buEntity copiedEntity)
  {
    if (orientation)
      ((CustomDataSurrogate) copiedEntity).Orientation = new OrientationAngle(((CustomDataSurrogate) baseEntity).Orientation);
    if (typeDef)
      ((CustomDataSurrogate) copiedEntity).typeDefination = ((CustomDataSurrogate) baseEntity).typeDefination;
    ((CustomDataSurrogate) copiedEntity).Color = ((CustomDataSurrogate) baseEntity).Color;
    ((CustomDataSurrogate) copiedEntity).LayerIndex = ((CustomDataSurrogate) baseEntity).LayerIndex;
    ((CustomDataSurrogate) copiedEntity).LayerName = ((CustomDataSurrogate) baseEntity).LayerName;
    if (info && ((CustomData) baseEntity).Info != null)
      ((CustomData) copiedEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) baseEntity).Info);
    if (shape && ((CustomData) baseEntity).Shape != null)
      ((CustomData) copiedEntity).Shape = (EntityShapeInfo) new SewingPunteriz(((CustomData) baseEntity).Shape);
    if (dimension && ((CustomData) baseEntity).Dimension != null)
      ((CustomData) copiedEntity).Dimension = (DimensionInfo) new CharLibrary5(((CustomData) baseEntity).Dimension);
    if (!modeproperties)
      return;
    if (((CustomData) baseEntity).Marble != null)
      ((CustomData) copiedEntity).Marble = (MarbleInfo) new Line2D(((CustomData) baseEntity).Marble);
    if (((CustomData) baseEntity).Sewing != null)
      ((CustomData) copiedEntity).Sewing = (SewingInfo) new EntityInfo(((CustomData) baseEntity).Sewing);
    if (((CustomData) baseEntity).Cutter == null)
      return;
    ((CustomData) copiedEntity).Cutter = (CutterInfo) new AnalyseEntitiesResult(((CustomData) baseEntity).Cutter);
  }

  public static void GeoEntitiyToBuEntity(geoEntity GeoEntity, ref buEntity EEntity)
  {
    if (GeoEntity.GetType() == typeof (geoPoint))
    {
      Point3D p = new Point3D(((geoPoint) GeoEntity).StartPoint.X, ((geoPoint) GeoEntity).StartPoint.Y, ((geoPoint) GeoEntity).StartPoint.Z);
      EEntity = (buEntity) new buMultilineText(p);
    }
    if (GeoEntity.GetType() == typeof (geoLine))
    {
      Point3D start = new Point3D(((geoLine) GeoEntity).StartPoint.X, ((geoLine) GeoEntity).StartPoint.Y, ((geoLine) GeoEntity).StartPoint.Z);
      Point3D end = new Point3D(((geoLine) GeoEntity).EndPoint.X, ((geoLine) GeoEntity).EndPoint.Y, ((geoLine) GeoEntity).EndPoint.Z);
      EEntity = (buEntity) new buMultilineText(start, end);
    }
    if (GeoEntity.GetType() == typeof (geoArc))
    {
      Point3D center = new Point3D(((geoArc) GeoEntity).CenterPoint.X, ((geoArc) GeoEntity).CenterPoint.Y, ((geoArc) GeoEntity).CenterPoint.Z);
      EEntity = (buEntity) new buEntityList(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center, ((geoArc) GeoEntity).Radius, ((geoArc) GeoEntity).StartAngle, ((geoArc) GeoEntity).EndAngle);
    }
    if (GeoEntity.GetType() == typeof (geoCircle))
    {
      Point3D center = new Point3D(((geoCircle) GeoEntity).CenterPoint.X, ((geoCircle) GeoEntity).CenterPoint.Y, ((geoCircle) GeoEntity).CenterPoint.Z);
      EEntity = (buEntity) new buEntityList(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center, ((geoCircle) GeoEntity).Radius);
    }
    if (GeoEntity.GetType() == typeof (geoEllipse))
    {
      Point3D center = new Point3D(((geoEllipse) GeoEntity).CenterPoint.X, ((geoEllipse) GeoEntity).CenterPoint.Y, ((geoEllipse) GeoEntity).CenterPoint.Z);
      EEntity = (buEntity) new buShape(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center, ((geoEllipse) GeoEntity).MajorRadius, ((geoEllipse) GeoEntity).MinorRadius);
    }
    if (GeoEntity.GetType() == typeof (geoPolyline))
    {
      List<Point3D> points = new List<Point3D>();
      for (int index = 0; index <= GeoEntity.Vertice.Count - 1; ++index)
        points.Add(new Point3D(GeoEntity.Vertice[index].X, GeoEntity.Vertice[index].Y, GeoEntity.Vertice[index].Z));
      EEntity = (buEntity) new buShape(points);
    }
    if (GeoEntity.GetType() == typeof (geoBSpline))
      ;
    if (GeoEntity.GetType() == typeof (geoText))
      ;
    ((EntityDataSet) ((CustomData) EEntity).Info).Tags = GeoEntity.Tag;
    ((CustomData) EEntity).sortDirection = GeoEntity.Direction;
    ((CustomDataSurrogate) EEntity).typeDefination = GeoEntity.TypeDefination;
  }

  public static void GeoEntitiyToBuEntity(List<geoEntity> GeoEntities, ref List<buEntity> EEntities)
  {
    EEntities.Clear();
    EEntities = new List<buEntity>();
    for (int index = 0; index <= GeoEntities.Count - 1; ++index)
    {
      buEntity EEntity = (buEntity) new buMultilineText();
      buText.GeoEntitiyToBuEntity(GeoEntities[index], ref EEntity);
      EEntities.Add(EEntity);
    }
  }

  public static void GeoEntitiyToBuEntity(
    List<List<geoEntity>> GeoEntities,
    ref List<List<buEntity>> EEntities)
  {
    EEntities.Clear();
    EEntities = new List<List<buEntity>>();
    for (int index = 0; index <= GeoEntities.Count - 1; ++index)
    {
      List<buEntity> EEntities1 = new List<buEntity>();
      buText.GeoEntitiyToBuEntity(GeoEntities[index], ref EEntities1);
      EEntities.Add(EEntities1);
    }
  }

  public static void GeoEntitiyToEyeEntity(geoEntity GeoEntity, ref Entity EEntity)
  {
    if (GeoEntity.GetType() == typeof (geoPoint))
    {
      Point3D p = new Point3D(((geoPoint) GeoEntity).StartPoint.X, ((geoPoint) GeoEntity).StartPoint.Y, ((geoPoint) GeoEntity).StartPoint.Z);
      EEntity = (Entity) new Point(p);
    }
    if (GeoEntity.GetType() == typeof (geoLine))
    {
      Point3D start = new Point3D(((geoLine) GeoEntity).StartPoint.X, ((geoLine) GeoEntity).StartPoint.Y, ((geoLine) GeoEntity).StartPoint.Z);
      Point3D end = new Point3D(((geoLine) GeoEntity).EndPoint.X, ((geoLine) GeoEntity).EndPoint.Y, ((geoLine) GeoEntity).EndPoint.Z);
      EEntity = (Entity) new Line(start, end);
    }
    if (GeoEntity.GetType() == typeof (geoArc))
    {
      Point3D center = new Point3D(((geoArc) GeoEntity).CenterPoint.X, ((geoArc) GeoEntity).CenterPoint.Y, ((geoArc) GeoEntity).CenterPoint.Z);
      EEntity = (Entity) new Arc(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center, ((geoArc) GeoEntity).Radius, ((geoArc) GeoEntity).StartAngle, ((geoArc) GeoEntity).EndAngle);
    }
    if (GeoEntity.GetType() == typeof (geoCircle))
    {
      Point3D center = new Point3D(((geoCircle) GeoEntity).CenterPoint.X, ((geoCircle) GeoEntity).CenterPoint.Y, ((geoCircle) GeoEntity).CenterPoint.Z);
      EEntity = (Entity) new Circle(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center, ((geoCircle) GeoEntity).Radius);
    }
    if (GeoEntity.GetType() == typeof (geoEllipse))
    {
      Point3D center = new Point3D(((geoEllipse) GeoEntity).CenterPoint.X, ((geoEllipse) GeoEntity).CenterPoint.Y, ((geoEllipse) GeoEntity).CenterPoint.Z);
      EEntity = (Entity) new Ellipse(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center, ((geoEllipse) GeoEntity).MajorRadius, ((geoEllipse) GeoEntity).MinorRadius);
    }
    if (GeoEntity.GetType() == typeof (geoPolyline))
    {
      List<Point3D> points = new List<Point3D>();
      for (int index = 0; index <= GeoEntity.Vertice.Count - 1; ++index)
        points.Add(new Point3D(GeoEntity.Vertice[index].X, GeoEntity.Vertice[index].Y, GeoEntity.Vertice[index].Z));
      EEntity = (Entity) new LinearPath((ICollection<Point3D>) points);
    }
    if (GeoEntity.GetType() == typeof (geoBSpline))
      ;
    if (GeoEntity.GetType() == typeof (geoText))
      ;
    EEntity.LayerName = GeoEntity.LayerName;
    CustomData customData = (CustomData) new ClipperOffset();
    ((CutterRuntimeSettings) customData).set_sortDirection(GeoEntity.Direction);
    EEntity.EntityData = (object) customData;
  }

  public static void GeoEntitiyToEyeEntity(List<geoEntity> GeoEntities, ref List<Entity> EEntities)
  {
    EEntities.Clear();
    EEntities = new List<Entity>();
    for (int index = 0; index <= GeoEntities.Count - 1; ++index)
    {
      Entity EEntity = (Entity) null;
      buText.GeoEntitiyToEyeEntity(GeoEntities[index], ref EEntity);
      EEntities.Add(EEntity);
    }
  }

  public static void eEntityToEyeEntity(List<eEntities> eEntity, ref List<Entity> eyeEntity)
  {
    eyeEntity.Clear();
    for (int index = 0; index <= eEntity.Count - 1; ++index)
    {
      Entity eyeEntity1 = (Entity) null;
      buText.eEntityToEyeEntity(eEntity[index], ref eyeEntity1);
      if (eyeEntity1 != null)
        eyeEntity.Add(eyeEntity1);
    }
  }

  public static void eEntityToEyeEntity(eEntities eEntity, ref Entity eyeEntity)
  {
    try
    {
      if (eEntity.GetType() == typeof (eLine))
      {
        eyeEntity = (Entity) new Line(buString5.Pnt3DToPoint3D(((eLine) eEntity).StartPoint), buString5.Pnt3DToPoint3D(((eLine) eEntity).EndPoint));
        eyeEntity.EntityData = (object) new ClipperOffset();
      }
      if (eEntity.GetType() == typeof (eArc))
      {
        if (buConversion5.EQ(Math.Abs(((eArc) eEntity).EndAngle - ((eArc) eEntity).StartAngle), 360.0))
        {
          eyeEntity = (Entity) new Circle(buVector5.WorkPlaneToPlane(((ePlaneEntities) eEntity).Plane), buString5.Pnt3DToPoint3D(((ePlaneEntities) eEntity).CenterPoint), ((eCircle) eEntity).Radius);
          eyeEntity.EntityData = (object) new ClipperOffset();
        }
        else
        {
          eyeEntity = (Entity) new Arc(buString5.Pnt3DToPoint3D(((eArc) eEntity).StartPoint), buString5.Pnt3DToPoint3D(((eArc) eEntity).MiddlePoint), buString5.Pnt3DToPoint3D(((eArc) eEntity).EndPoint), false);
          eyeEntity.EntityData = (object) new ClipperOffset();
        }
      }
      if (eEntity.GetType() == typeof (eCircle))
      {
        eyeEntity = (Entity) new Circle(buVector5.WorkPlaneToPlane(((ePlaneEntities) eEntity).Plane), buString5.Pnt3DToPoint3D(((ePlaneEntities) eEntity).CenterPoint), ((eCircle) eEntity).Radius);
        eyeEntity.EntityData = (object) new ClipperOffset();
      }
      if (eEntity.GetType() == typeof (eEllipse) | eEntity.GetType() == typeof (eBSpline) | eEntity.GetType() == typeof (eBezeir) | eEntity.GetType() == typeof (ePolyline))
      {
        eyeEntity = (Entity) new LinearPath((ICollection<Point3D>) buString5.Pnt3dToPoint3D(eEntity.Vertice));
        eyeEntity.EntityData = (object) new ClipperOffset();
      }
      if (eEntity.GetType() == typeof (ePoint))
      {
        eyeEntity = (Entity) new Point(buString5.Pnt3DToPoint3D(((ePoint) eEntity).StartPoint));
        eyeEntity.EntityData = (object) new ClipperOffset();
      }
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_typeDefination(eEntity.TypeDefination);
    }
    catch (Exception ex)
    {
    }
  }

  public static void eEntityTobuEntity(List<eEntities> eEntity, ref List<buEntity> bEntity)
  {
    bEntity.Clear();
    for (int index = 0; index <= eEntity.Count - 1; ++index)
    {
      buEntity bEntity1 = (buEntity) null;
      buText.eEntityTobuEntity(eEntity[index], ref bEntity1);
      if (bEntity1 != null)
        bEntity.Add(bEntity1);
    }
  }

  public static void eEntityTobuEntity(eEntities eEntity, ref buEntity bEntity)
  {
    try
    {
      if (eEntity.GetType() == typeof (eLine))
        bEntity = (buEntity) new buMultilineText(buString5.Pnt3DToPoint3D(((eLine) eEntity).StartPoint), buString5.Pnt3DToPoint3D(((eLine) eEntity).EndPoint));
      if (eEntity.GetType() == typeof (eArc))
        bEntity = !buConversion5.EQ(Math.Abs(((eArc) eEntity).EndAngle - ((eArc) eEntity).StartAngle), 360.0) ? (buEntity) new buEntityList(buString5.Pnt3DToPoint3D(((eArc) eEntity).StartPoint), buString5.Pnt3DToPoint3D(((eArc) eEntity).MiddlePoint), buString5.Pnt3DToPoint3D(((eArc) eEntity).EndPoint), false) : (buEntity) new buEntityList(buVector5.WorkPlaneToPlane(((ePlaneEntities) eEntity).Plane), buString5.Pnt3DToPoint3D(((ePlaneEntities) eEntity).CenterPoint), ((eCircle) eEntity).Radius);
      if (eEntity.GetType() == typeof (eCircle))
        bEntity = (buEntity) new buEntityList(buVector5.WorkPlaneToPlane(((ePlaneEntities) eEntity).Plane), buString5.Pnt3DToPoint3D(((ePlaneEntities) eEntity).CenterPoint), ((eCircle) eEntity).Radius);
      if (eEntity.GetType() == typeof (eEllipse) | eEntity.GetType() == typeof (eBSpline) | eEntity.GetType() == typeof (eBezeir) | eEntity.GetType() == typeof (ePolyline))
        bEntity = (buEntity) new buShape(buString5.Pnt3dToPoint3D(eEntity.Vertice));
      if (!(eEntity.GetType() == typeof (ePoint)))
        return;
      bEntity = (buEntity) new buMultilineText(buString5.Pnt3DToPoint3D(((ePoint) eEntity).StartPoint));
    }
    catch (Exception ex)
    {
    }
  }

  public static void Decode(List<string> SL, ref buEntity refEntity, string Char = "")
  {
    try
    {
      if (SL.Count < 2)
        return;
      if (SL[0].ToLower().Trim() == "bupoint")
      {
        Point3D p = buSerilization5.DecoderFromPoint3D(SL[1]);
        if (p != (Point3D) null)
          refEntity = (buEntity) new buMultilineText(p);
      }
      if (SL[0].ToLower().Trim() == "buline")
      {
        Point3D start = buSerilization5.DecoderFromPoint3D(SL[1]);
        Point3D end = buSerilization5.DecoderFromPoint3D(SL[2]);
        if (start != (Point3D) null & end != (Point3D) null)
          refEntity = (buEntity) new buMultilineText(start, end);
      }
      if (SL[0].ToLower().Trim() == "bucircle")
      {
        Point3D center = buSerilization5.DecoderFromPoint3D(SL[1]);
        double radius = buSerilization5.DecoderFromDouble(SL[2]);
        Plane plane = buSerilization5.DecoderFromPlane(SL[3]);
        if (center != (Point3D) null & radius > 0.0 & plane != (Plane) null)
          refEntity = (buEntity) new buEntityList(plane, center, radius);
      }
      if (SL[0].ToLower().Trim() == "buarc")
      {
        Point3D center = buSerilization5.DecoderFromPoint3D(SL[1]);
        double radius = buSerilization5.DecoderFromDouble(SL[2]);
        Point3D start = buSerilization5.DecoderFromPoint3D(SL[3]);
        Point3D end = buSerilization5.DecoderFromPoint3D(SL[4]);
        Plane arcPlane = buSerilization5.DecoderFromPlane(SL[5]);
        if (center != (Point3D) null & start != (Point3D) null & end != (Point3D) null & radius > 0.0 & arcPlane != (Plane) null)
          refEntity = (buEntity) new buEntityList(arcPlane, center, radius, start, end, false);
      }
      if (SL[0].ToLower().Trim() == "bulinearpath")
      {
        List<string> CalcList = new List<string>();
        List<Point3D> points = new List<Point3D>();
        buImage5.ListToSpecificList("<Vertices>", "</Vertices>", false, SL, ref CalcList);
        for (int index = 0; index <= CalcList.Count - 1; ++index)
          points.Add(buSerilization5.DecoderFromPoint3D(CalcList[index]));
        if (points.Count > 1)
          refEntity = (buEntity) new buShape(points);
      }
      if (SL[0].ToLower().Trim() == "buellipse")
      {
        Point3D center = buSerilization5.DecoderFromPoint3D(SL[1]);
        double rx = buSerilization5.DecoderFromDouble(SL[2]);
        double ry = buSerilization5.DecoderFromDouble(SL[3]);
        Plane ellipsePlane = buSerilization5.DecoderFromPlane(SL[4]);
        if (center != (Point3D) null & ry > 0.0 & rx > 0.0 & ellipsePlane != (Plane) null)
          refEntity = (buEntity) new buShape(ellipsePlane, center, rx, ry);
      }
      if (SL[0].ToLower().Trim() == "bucurve")
      {
        int degree = buSerilization5.DecoderFromInt(SL[1]);
        List<string> CalcList1 = new List<string>();
        List<string> CalcList2 = new List<string>();
        List<Point3D> ctrlPoints1 = new List<Point3D>();
        double[] knotVector = (double[]) null;
        buImage5.ListToSpecificList("<ControlPoints>", "</ControlPoints>", false, SL, ref CalcList1);
        buImage5.ListToSpecificList("<KnotVector>", "</KnotVector>", false, SL, ref CalcList2);
        if (CalcList2.Count > 0)
          knotVector = new double[CalcList2.Count];
        if (knotVector != null)
        {
          Point4D[] ctrlPoints2 = new Point4D[CalcList1.Count];
          for (int index = 0; index <= CalcList1.Count - 1; ++index)
            ctrlPoints2[index] = buSerilization5.DecoderFromPoint4D(CalcList1[index]);
          for (int index = 0; index <= CalcList2.Count - 1; ++index)
            knotVector[index] = buSerilization5.DecoderFromDouble(CalcList2[index]);
          if (ctrlPoints2.Length != 0 & knotVector.Length != 0)
            refEntity = (buEntity) new buShapeRectangle(degree, knotVector, ctrlPoints2);
        }
        else
        {
          for (int index = 0; index <= CalcList1.Count - 1; ++index)
          {
            Point4D point4D = buSerilization5.DecoderFromPoint4D(CalcList1[index]);
            ctrlPoints1.Add(new Point3D(point4D.X, point4D.Y, point4D.Z));
          }
          if (ctrlPoints1.Count > 0)
            refEntity = (buEntity) new buShapeRectangle(degree, ctrlPoints1);
        }
      }
      if (SL[0].ToLower().Trim() == "bucompositecurve")
      {
        List<string> CalcList3 = new List<string>();
        List<List<string>> CalcList4 = new List<List<string>>();
        List<buEntity> curveList = new List<buEntity>();
        buImage5.ListToSpecificList("<SubCurves>", "</SubCurves>", false, SL, ref CalcList3);
        buImage5.ListToSpecificList("<buEntitySub>", "</buEntitySub>", false, CalcList3, ref CalcList4);
        int index1 = -1;
        int num = -1;
        for (int index2 = 0; index2 <= SL.Count - 1; ++index2)
        {
          if (SL[index2].IndexOf("<SubCurves>") >= 0)
            index1 = index2;
          if (SL[index2].IndexOf("</SubCurves>") >= 0)
            num = index2;
        }
        if (index1 >= 0 & num >= 0 & num - index1 > 0)
          SL.RemoveRange(index1, num - index1 + 1);
        for (int index3 = 0; index3 <= CalcList4.Count - 1; ++index3)
        {
          buEntity refEntity1 = (buEntity) null;
          buText.Decode(CalcList4[index3], ref refEntity1, "Sub");
          if (refEntity1 != null)
            curveList.Add(refEntity1);
        }
        if (curveList.Count > 0)
          refEntity = (buEntity) new buShapeCircle(curveList);
      }
      if (SL[0].ToLower().Trim() == "buregion")
      {
        List<string> CalcList5 = new List<string>();
        List<List<string>> CalcList6 = new List<List<string>>();
        List<buEntity> contours = new List<buEntity>();
        buImage5.ListToSpecificList("<SubCurves>", "</SubCurves>", false, SL, ref CalcList5);
        buImage5.ListToSpecificList("<buEntitySub>", "</buEntitySub>", false, CalcList5, ref CalcList6);
        for (int index = 0; index <= CalcList6.Count - 1; ++index)
        {
          buEntity refEntity2 = (buEntity) null;
          buText.Decode(CalcList6[index], ref refEntity2, "Sub");
          if (refEntity2 != null)
            contours.Add(refEntity2);
        }
        if (contours.Count > 0)
          refEntity = (buEntity) new buShapeSlot(contours);
      }
      if (SL[0].ToLower().Trim() == "bumesh")
      {
        List<string> CalcList7 = new List<string>();
        List<string> CalcList8 = new List<string>();
        List<Point3D> vertices = new List<Point3D>();
        List<IndexTriangle> triangles = new List<IndexTriangle>();
        buImage5.ListToSpecificList("<Vertices>", "</Vertices>", false, SL, ref CalcList7);
        for (int index = 0; index <= CalcList7.Count - 1; ++index)
          vertices.Add(buSerilization5.DecoderFromPoint3D(CalcList7[index]));
        buImage5.ListToSpecificList("<Triangles>", "</Triangles>", false, SL, ref CalcList8);
        for (int index = 0; index <= CalcList8.Count - 1; ++index)
          triangles.Add(buSerilization5.DecoderFromTriangleIndex(CalcList8[index]));
        if (vertices.Count > 1)
          refEntity = (buEntity) new buShapeFreeLines((IList<Point3D>) vertices, (IList<IndexTriangle>) triangles);
      }
      if (SL[0].ToLower().Trim() == "bulineardim")
      {
        Point3D extLine1 = buSerilization5.DecoderFromPoint3D(SL[1]);
        Point3D extLine2 = buSerilization5.DecoderFromPoint3D(SL[2]);
        Point3D dimLinePos = buSerilization5.DecoderFromPoint3D(SL[3]);
        double textHeight = buSerilization5.DecoderFromDouble(SL[4]);
        Plane dimPlane = buSerilization5.DecoderFromPlane(SL[5]);
        if (extLine1 != (Point3D) null & extLine2 != (Point3D) null & dimLinePos != (Point3D) null)
          refEntity = (buEntity) new buShapeHole(dimPlane, extLine1, extLine2, dimLinePos, textHeight);
      }
      if (SL[0].ToLower().Trim() == "buangulardim")
      {
        Point3D extLine1 = buSerilization5.DecoderFromPoint3D(SL[1]);
        Point3D extLine2 = buSerilization5.DecoderFromPoint3D(SL[2]);
        Point3D dimLinePos = buSerilization5.DecoderFromPoint3D(SL[3]);
        double textHeight = buSerilization5.DecoderFromDouble(SL[4]);
        Plane dimPlane = buSerilization5.DecoderFromPlane(SL[5]);
        if (extLine1 != (Point3D) null & extLine2 != (Point3D) null & dimLinePos != (Point3D) null)
          refEntity = (buEntity) new buShapeHoleMulti(dimPlane, extLine1, extLine2, dimLinePos, textHeight);
      }
      if (SL[0].ToLower().Trim() == "buradialdim")
      {
        Point3D origin = buSerilization5.DecoderFromPoint3D(SL[1]);
        Point3D dimLinePos = buSerilization5.DecoderFromPoint3D(SL[2]);
        double radius = buSerilization5.DecoderFromDouble(SL[3]);
        double textHeight = buSerilization5.DecoderFromDouble(SL[4]);
        Plane dimPlane = buSerilization5.DecoderFromPlane(SL[5]);
        if (origin != (Point3D) null & dimLinePos != (Point3D) null & radius > 0.0)
          refEntity = (buEntity) new buShapeJunction(dimPlane, origin, radius, dimLinePos, textHeight);
      }
      if (SL[0].ToLower().Trim() == "budiametricdim")
      {
        Point3D origin = buSerilization5.DecoderFromPoint3D(SL[1]);
        Point3D dimLinePos = buSerilization5.DecoderFromPoint3D(SL[2]);
        double radius = buSerilization5.DecoderFromDouble(SL[3]);
        double textHeight = buSerilization5.DecoderFromDouble(SL[4]);
        Plane dimPlane = buSerilization5.DecoderFromPlane(SL[5]);
        if (origin != (Point3D) null & dimLinePos != (Point3D) null & radius > 0.0)
          refEntity = (buEntity) new buShapeCut(dimPlane, origin, radius, dimLinePos, textHeight);
      }
      if (SL[0].ToLower().Trim() == "buordinatedim")
      {
        Point3D definingPoint = buSerilization5.DecoderFromPoint3D(SL[1]);
        Point3D dimLinePos = buSerilization5.DecoderFromPoint3D(SL[2]);
        bool isVertical = buSerilization5.DecoderFromBool(SL[3]);
        double textHeight = buSerilization5.DecoderFromDouble(SL[4]);
        Plane dimPlane = buSerilization5.DecoderFromPlane(SL[5]);
        if (definingPoint != (Point3D) null & dimLinePos != (Point3D) null)
          refEntity = (buEntity) new buShapeEngrave(dimPlane, definingPoint, dimLinePos, isVertical, textHeight);
      }
      if (SL[0].ToLower().Trim() == "butext")
      {
        Point3D insPoint = buSerilization5.DecoderFromPoint3D(SL[1]);
        string textString = buSerilization5.DecoderFromString(SL[2]);
        double height = buSerilization5.DecoderFromDouble(SL[3]);
        string styleName = buSerilization5.DecoderFromString(SL[4]);
        bool simplify = buSerilization5.DecoderFromBool(SL[5]);
        Text.alignmentType result;
        Enum.TryParse<Text.alignmentType>(buSerilization5.DecoderFromString(SL[6]), out result);
        Plane textPlane = buSerilization5.DecoderFromPlane(SL[7]);
        if (insPoint != (Point3D) null)
          refEntity = (buEntity) new buCompositeCurveCam(textPlane, insPoint, textString, height, result, styleName, simplify);
      }
      if (SL[0].ToLower().Trim() == "bumultilinetext")
      {
        Point3D insPoint = buSerilization5.DecoderFromPoint3D(SL[1]);
        string textString = buSerilization5.DecoderFromString(SL[2]);
        double height = buSerilization5.DecoderFromDouble(SL[3]);
        string styleName = buSerilization5.DecoderFromString(SL[4]);
        bool simplify = buSerilization5.DecoderFromBool(SL[5]);
        Text.alignmentType result;
        Enum.TryParse<Text.alignmentType>(buSerilization5.DecoderFromString(SL[6]), out result);
        double width = buSerilization5.DecoderFromDouble(SL[7]);
        double lineSpaceDistance = buSerilization5.DecoderFromDouble(SL[8]);
        bool wrap = buSerilization5.DecoderFromBool(SL[9]);
        Plane textPlane = buSerilization5.DecoderFromPlane(SL[10]);
        if (insPoint != (Point3D) null)
          refEntity = (buEntity) new buArcCam(textPlane, insPoint, textString, width, height, lineSpaceDistance, result, styleName, simplify, wrap);
      }
      if (refEntity == null)
        return;
      List<string> CalcList9 = new List<string>();
      buImage5.ListToSpecificList("<Common>", "</Common>", false, SL, ref CalcList9);
      buText.DecodeCommon(CalcList9, ref refEntity);
      List<string> CalcList10 = new List<string>();
      buImage5.ListToSpecificList("<Sewing>", "</Sewing>", false, SL, ref CalcList10);
      if (CalcList10.Count > 0)
        CutterInfo.Decode(CalcList10, ref ((CustomData) refEntity).Sewing);
      List<string> CalcList11 = new List<string>();
      buImage5.ListToSpecificList("<Dimension>", "</Dimension>", false, SL, ref CalcList11);
      if (CalcList11.Count > 0)
        CharLibrary5.Decode(CalcList11, ref ((CustomData) refEntity).Dimension);
      List<string> CalcList12 = new List<string>();
      buImage5.ListToSpecificList("<Marble>", "</Marble>", false, SL, ref CalcList12);
      if (CalcList12.Count <= 0)
        return;
      Line2D.Decode(CalcList12, ref ((CustomData) refEntity).Marble);
    }
    catch (Exception ex)
    {
    }
  }

  public static buEntity Decode(List<string> SL)
  {
    try
    {
      buEntity refEntity = (buEntity) null;
      buText.Decode(SL, ref refEntity);
      return refEntity;
    }
    catch (Exception ex)
    {
      return (buEntity) null;
    }
  }

  public static void Decode(List<string> SL, ref List<buEntity> refEntity, string Char = "")
  {
    try
    {
      refEntity = new List<buEntity>();
      List<List<string>> CalcList = new List<List<string>>();
      buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, SL, ref CalcList);
      if (CalcList.Count <= 0)
        return;
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        buEntity refEntity1 = (buEntity) null;
        buText.Decode(CalcList[index], ref refEntity1, Char);
        if (refEntity1 != null)
          refEntity.Add(refEntity1);
        CalcList[index].Clear();
      }
      CalcList.Clear();
    }
    catch (Exception ex)
    {
    }
  }

  public static void Decode(List<string> SL, ref List<List<buEntity>> refEntity, string Char = "")
  {
    try
    {
      refEntity = new List<List<buEntity>>();
      List<List<string>> CalcList = new List<List<string>>();
      buStatics.ListToSpecificList("<buEntityList>", "</buEntityList>", false, SL, ref CalcList);
      if (CalcList.Count <= 0)
        return;
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        List<buEntity> refEntity1 = new List<buEntity>();
        buText.Decode(CalcList[index], ref refEntity1, Char);
        if (refEntity1.Count > 0)
          refEntity.Add(refEntity1);
        CalcList[index].Clear();
      }
      CalcList.Clear();
    }
    catch (Exception ex)
    {
    }
  }

  public static void DecodeCommon(List<string> SL, ref buEntity refEntity)
  {
    try
    {
      if (!(refEntity != null & SL.Count >= 4))
        return;
      string[] strArray1 = SL[0].Split(':');
      ((CustomData) refEntity).sortDirection = (entitySortDirection) Enum.Parse(typeof (entitySortDirection), strArray1[1], true);
      string[] strArray2 = SL[1].Split(':');
      ((CustomDataSurrogate) refEntity).typeDefination = (entityTypeDefination) Enum.Parse(typeof (entityTypeDefination), strArray2[1], true);
      string[] strArray3 = SL[2].Split(':');
      ((CustomDataSurrogate) refEntity).Orientation = buSerilization5.DecoderFromOrientationAngle(strArray3[1]);
      object info = (object) ((CustomData) refEntity).Info;
      buSerilization5.StringToClass(ref info, SL[3]);
      if (SL.Count >= 5)
      {
        string[] strArray4 = SL[4].Split(':');
        ((CustomDataSurrogate) refEntity).ToolName = strArray4[1];
      }
      if (SL.Count >= 6)
      {
        string[] strArray5 = SL[5].Split(':');
        ((CustomDataSurrogate) refEntity).LayerName = strArray5[1];
      }
      if (SL.Count >= 7)
      {
        string[] strArray6 = SL[6].Split(':');
        ((CustomDataSurrogate) refEntity).Color = buFile5.StringToColor(strArray6[1], ColorConvertType.String);
      }
      for (int index = 4; index <= SL.Count - 1; ++index)
      {
        if (SL[index].ToLower().Trim().IndexOf("shape") >= 0)
        {
          object shape = (object) ((CustomData) refEntity).Shape;
          buSerilization5.StringToClass(ref shape, SL[index]);
        }
        object ObjPar;
        if (SL[index].ToLower().Trim().IndexOf("cutter") >= 0)
        {
          ObjPar = (object) ((CustomData) refEntity).Cutter;
          buSerilization5.StringToClass(ref ObjPar, SL[index]);
        }
        if (SL[index].ToLower().Trim().IndexOf("marble") >= 0)
        {
          ObjPar = (object) ((CustomData) refEntity).Marble;
          buSerilization5.StringToClass(ref ObjPar, SL[index]);
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static ArrayList ToDefEntity(buEntity refEntity, int Space)
  {
    ArrayList AL = new ArrayList();
    buText.ToDefEntity(refEntity, Space, ref AL);
    return AL;
  }

  public static void ToDefEntity(buEntity refEntity, int Space, ref ArrayList AL)
  {
    AL.Clear();
    AL = new ArrayList();
    AL.AddRange((ICollection) ((buMultilineText) refEntity).ToDef(Space));
  }

  public static void ToDefEntity(List<buEntity> refEntities, int Space, ref ArrayList AL)
  {
    AL.Clear();
    AL = new ArrayList();
    for (int index = 0; index <= refEntities.Count - 1; ++index)
      AL.AddRange((ICollection) ((buMultilineText) refEntities[index]).ToDef(Space));
  }

  public static ArrayList ToDefEntity(List<buEntity> refEntities, int Space)
  {
    ArrayList AL = new ArrayList();
    buText.ToDefEntity(refEntities, Space, ref AL);
    return AL;
  }

  public static void ToDefEntity(List<List<buEntity>> refEntities, int Space, ref ArrayList AL)
  {
    AL.Clear();
    AL = new ArrayList();
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      AL.Add((object) (buImage5.SpaceChar(Space) + "<buEntityList>"));
      AL.AddRange((ICollection) buText.ToDefEntity(refEntities[index], Space + 2));
      AL.Add((object) (buImage5.SpaceChar(Space) + "</buEntityList>"));
    }
  }
}
