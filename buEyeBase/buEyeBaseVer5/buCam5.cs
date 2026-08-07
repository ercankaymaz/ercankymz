// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buCam5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.UserFiles.buCad;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buMarble.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class buCam5
{
  public setCam varCam = new setCam();

  static buCam5() => F_MarbleMaintanance.Captions = new List<string>();

  public event CalculationEventHandler CalculationInProgress;

  public event CalculationEventHandler CalculationStarted;

  public event CalculationEventHandler CalculationEnded;

  public event CalculationEventHandler CalculationCanceled;

  public event CalculationErrorEventHandler CalculationError;

  public buCam5()
  {
    if (!buVector5.\u0001(nameof (buCam5)))
      throw new RegisterException(nameof (buCam5));
  }

  public void CamPointsToEntities(
    camTp Cam,
    ref List<Entity> Entities,
    double MultiplyX = 1.0,
    double MultiplyY = 1.0,
    double MultiplyZ = 1.0)
  {
    this.CamPointsToEntities(new List<camTp>() { Cam }, ref Entities, MultiplyX, MultiplyY, MultiplyZ);
  }

  public void CamPointsToEntities(
    List<camTp> Cams,
    ref List<Entity> Entities,
    double MultiplyX = 1.0,
    double MultiplyY = 1.0,
    double MultiplyZ = 1.0)
  {
    Entities.Clear();
    Entities = new List<Entity>();
    for (int index1 = 0; index1 <= Cams.Count - 1; ++index1)
    {
      double num = 1.0;
      if (Cams[index1].PlaneName == planeNames.Bottom)
        num = -1.0;
      for (int index2 = 0; index2 <= Cams[index1].CamPoints.Count - 1; ++index2)
      {
        List<Point3D> points = new List<Point3D>();
        for (int index3 = 1; index3 <= Cams[index1].CamPoints[index2].Points.Count - 1; ++index3)
        {
          TpPnt9D point1 = Cams[index1].CamPoints[index2].Points[index3 - 1];
          TpPnt9D point2 = Cams[index1].CamPoints[index2].Points[index3];
          if (Cams[index1].CamPoints[index2].Points[index3].Type == 0)
          {
            if (points.Count > 0)
            {
              LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
              linearPath.EntityData = (object) new ClipperOffset();
              Entities.Add((Entity) linearPath);
              points = new List<Point3D>();
            }
          }
          else if (Cams[index1].CamPoints[index2].Points[index3].Type == 1)
          {
            if (points.Count == 0)
              points.Add(new Point3D(((TpArcData) point1).P9.X * MultiplyX, ((TpArcData) point1).P9.Y * MultiplyY, ((TpArcData) point1).P9.Z * num * MultiplyZ));
            points.Add(new Point3D(((TpArcData) point2).P9.X * MultiplyX, ((TpArcData) point2).P9.Y * MultiplyY, ((TpArcData) point2).P9.Z * num * MultiplyZ));
          }
          else if (Cams[index1].CamPoints[index2].Points[index3].Type == 2)
          {
            if (points.Count > 0)
            {
              LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
              linearPath.EntityData = (object) new ClipperOffset();
              Entities.Add((Entity) linearPath);
              points = new List<Point3D>();
            }
            Point3D ArcStartPoint = new Point3D(((TpArcData) point1).P9.X * MultiplyX, ((TpArcData) point1).P9.Y * MultiplyY, ((TpArcData) point1).P9.Z * num * MultiplyZ);
            Point3D ArcEndPoint = new Point3D(((TpArcData) point2).P9.X * MultiplyX, ((TpArcData) point2).P9.Y * MultiplyY, ((TpArcData) point2).P9.Z * num * MultiplyZ);
            Entity entArc = (Entity) null;
            buCall.\u0001.ArcWithTwoPointAndRadius(ArcStartPoint, ArcEndPoint, ((SimulationTp) Cams[index1].CamPoints[index2].Points[index3].ArcData).Radius, true, Plane.XY, ref entArc);
            Entities.Add(entArc);
          }
          else if (Cams[index1].CamPoints[index2].Points[index3].Type == 3)
          {
            if (points.Count > 0)
            {
              LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
              linearPath.EntityData = (object) new ClipperOffset();
              Entities.Add((Entity) linearPath);
              points = new List<Point3D>();
            }
            Point3D ArcStartPoint = new Point3D(((TpArcData) point1).P9.X * MultiplyX, ((TpArcData) point1).P9.Y * MultiplyY, ((TpArcData) point1).P9.Z * num * MultiplyZ);
            Point3D ArcEndPoint = new Point3D(((TpArcData) point2).P9.X * MultiplyX, ((TpArcData) point2).P9.Y * MultiplyY, ((TpArcData) point2).P9.Z * num * MultiplyZ);
            Entity entArc = (Entity) null;
            buCall.\u0001.ArcWithTwoPointAndRadius(ArcStartPoint, ArcEndPoint, ((SimulationTp) Cams[index1].CamPoints[index2].Points[index3].ArcData).Radius, false, Plane.XY, ref entArc);
            entArc.Regen(0.01);
            Entities.Add(entArc);
          }
        }
        if (points.Count > 0)
        {
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
          linearPath.EntityData = (object) new ClipperOffset();
          Entities.Add((Entity) linearPath);
          List<Point3D> point3DList = new List<Point3D>();
        }
      }
    }
  }

  public bool camEntitiesToCamPoints(
    List<Entity> Entities,
    camParameters5 Parameter,
    ToolBase5 Tool,
    ref List<camTp> Cam)
  {
    camTp Cam1 = new camTp();
    camTpPoint CamPoint = (camTpPoint) new TpPnt9D();
    for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
    {
      CustomData entityData = Entities[index1].EntityData as CustomData;
      ICurve entity1 = Entities[index1] as ICurve;
      if (index1 == 0)
      {
        if (((CutterIsoFileItems) entityData).get_sortDirection() == entitySortDirection.Normal)
        {
          TpPnt9D tpPnt9D1 = new TpPnt9D();
          tpPnt9D1.Type = 0;
          tpPnt9D1.LeaveAxisMovement = true;
          ((TpArcData) tpPnt9D1).P9 = new Pnt9D(entity1.StartPoint.X, entity1.StartPoint.Y, entity1.StartPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
          CamPoint.Points.Add(tpPnt9D1);
          TpPnt9D tpPnt9D2 = new TpPnt9D();
          tpPnt9D2.Type = 0;
          ((TpArcData) tpPnt9D2).P9 = new Pnt9D(entity1.StartPoint.X, entity1.StartPoint.Y, entity1.StartPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
          CamPoint.Points.Add(tpPnt9D2);
        }
        else
        {
          TpPnt9D tpPnt9D3 = new TpPnt9D();
          tpPnt9D3.Type = 0;
          tpPnt9D3.LeaveAxisMovement = true;
          ((TpArcData) tpPnt9D3).P9 = new Pnt9D(entity1.EndPoint.X, entity1.EndPoint.Y, entity1.EndPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
          tpPnt9D3.Feed = ((camSpeedsEnable) Parameter.Speeds).Leave;
          CamPoint.Points.Add(tpPnt9D3);
          TpPnt9D tpPnt9D4 = new TpPnt9D();
          tpPnt9D4.Type = 0;
          ((TpArcData) tpPnt9D4).P9 = new Pnt9D(entity1.EndPoint.X, entity1.EndPoint.Y, entity1.EndPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
          CamPoint.Points.Add(tpPnt9D4);
        }
      }
      if (Entities[index1].GetType() == typeof (Arc))
      {
        Arc entity2 = Entities[index1] as Arc;
        if (((CutterIsoFileItems) (Entities[index1].EntityData as CustomData)).get_sortDirection() == entitySortDirection.Reverse)
        {
          TpPnt9D tpPnt9D = new TpPnt9D();
          tpPnt9D.ArcData = (TpArcData) new camParameters5(entity2.Center, entity2.StartPoint, entity2.EndPoint);
          ((SimulationTp) tpPnt9D.ArcData).Radius = entity2.Radius;
          ((SimulationTp) tpPnt9D.ArcData).StartAngle = buCall.\u0001.PointAngle(entity2.StartPoint, entity2.Center, entity2.Plane);
          ((SimulationTp) tpPnt9D.ArcData).EndAngle = buCall.\u0001.PointAngle(entity2.EndPoint, entity2.Center, entity2.Plane);
          ((SimulationTp) tpPnt9D.ArcData).SweepAngle = ((SimulationTp) tpPnt9D.ArcData).EndAngle - ((SimulationTp) tpPnt9D.ArcData).StartAngle;
          tpPnt9D.Type = 2;
          ((TpArcData) tpPnt9D).P9 = new Pnt9D(((Circle) Entities[index1]).StartPoint.X, ((Circle) Entities[index1]).StartPoint.Y, ((Circle) Entities[index1]).StartPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
          tpPnt9D.Feed = Parameter.Speeds.Feed;
          CamPoint.Points.Add(tpPnt9D);
        }
        else
        {
          TpPnt9D tpPnt9D = new TpPnt9D();
          tpPnt9D.ArcData = (TpArcData) new camParameters5(entity2.Center, entity2.StartPoint, entity2.EndPoint);
          ((SimulationTp) tpPnt9D.ArcData).Radius = entity2.Radius;
          ((SimulationTp) tpPnt9D.ArcData).StartAngle = buCall.\u0001.PointAngle(entity2.StartPoint, entity2.Center, entity2.Plane);
          ((SimulationTp) tpPnt9D.ArcData).EndAngle = buCall.\u0001.PointAngle(entity2.EndPoint, entity2.Center, entity2.Plane);
          ((SimulationTp) tpPnt9D.ArcData).SweepAngle = ((SimulationTp) tpPnt9D.ArcData).EndAngle - ((SimulationTp) tpPnt9D.ArcData).StartAngle;
          tpPnt9D.Type = 3;
          ((TpArcData) tpPnt9D).P9 = new Pnt9D(((Circle) Entities[index1]).EndPoint.X, ((Circle) Entities[index1]).EndPoint.Y, ((Circle) Entities[index1]).EndPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
          tpPnt9D.Feed = Parameter.Speeds.Feed;
          CamPoint.Points.Add(tpPnt9D);
        }
      }
      else if (((CutterRuntimeSettings) entityData).get_typeDefination() == entityTypeDefination.CamPlunge)
      {
        TpPnt9D tpPnt9D = new TpPnt9D();
        tpPnt9D.Type = 1;
        tpPnt9D.PlungeAxisMovement = true;
        ((TpArcData) tpPnt9D).P9 = new Pnt9D(entity1.EndPoint.X, entity1.EndPoint.Y, entity1.EndPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
        tpPnt9D.Feed = Parameter.Speeds.Plunge;
        CamPoint.Points.Add(tpPnt9D);
      }
      else if (((CutterRuntimeSettings) entityData).get_typeDefination() == entityTypeDefination.CamLeave)
      {
        TpPnt9D tpPnt9D = new TpPnt9D();
        tpPnt9D.Type = 1;
        tpPnt9D.LeaveAxisMovement = true;
        ((TpArcData) tpPnt9D).P9 = new Pnt9D(entity1.EndPoint.X, entity1.EndPoint.Y, entity1.EndPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
        tpPnt9D.Feed = ((camSpeedsEnable) Parameter.Speeds).Leave;
        CamPoint.Points.Add(tpPnt9D);
      }
      else if (((CutterRuntimeSettings) entityData).get_typeDefination() == entityTypeDefination.CamG0)
      {
        TpPnt9D tpPnt9D = new TpPnt9D();
        tpPnt9D.Type = 0;
        ((TpArcData) tpPnt9D).P9 = new Pnt9D(entity1.EndPoint.X, entity1.EndPoint.Y, entity1.EndPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
        tpPnt9D.Feed = Parameter.Speeds.Rapid;
        CamPoint.Points.Add(tpPnt9D);
      }
      else if (Entities[index1].GetType() == typeof (Line))
      {
        TpPnt9D tpPnt9D = new TpPnt9D();
        tpPnt9D.Type = 1;
        ((TpArcData) tpPnt9D).P9 = new Pnt9D(((Line) Entities[index1]).EndPoint.X, ((Line) Entities[index1]).EndPoint.Y, ((Line) Entities[index1]).EndPoint.Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
        tpPnt9D.Feed = Parameter.Speeds.Feed;
        CamPoint.Points.Add(tpPnt9D);
      }
      else if (Entities[index1].GetType() == typeof (LinearPath))
      {
        LinearPath entity3 = Entities[index1] as LinearPath;
        for (int index2 = 1; index2 <= entity3.Vertices.Length - 1; ++index2)
        {
          TpPnt9D tpPnt9D = new TpPnt9D();
          tpPnt9D.Type = 1;
          ((TpArcData) tpPnt9D).P9 = new Pnt9D(entity3.Vertices[index2].X, entity3.Vertices[index2].Y, entity3.Vertices[index2].Z, ((CutterIsoEntities) entityData).get_OrientationA(), ((CutterIsoError) entityData).get_OrientationB(), ((CutterIsoFileSettings) entityData).get_OrientationC());
          tpPnt9D.Feed = Parameter.Speeds.Feed;
          CamPoint.Points.Add(tpPnt9D);
        }
      }
    }
    Cam1.Tool = (ToolBase5) new ToolGeometry5(Tool);
    this.CreateSimulationPointsFromCamPoint(ref Cam1, CamPoint);
    Cam1.CamPoints.Add(CamPoint);
    Cam.Add(Cam1);
    return true;
  }

  public bool camEntitiesToCamPoints(
    List<buEntity> Entities,
    camParameters5 Parameter,
    ToolBase5 Tool,
    ref List<camTp> Cam)
  {
    camTp camTp = new camTp();
    camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
    for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
    {
      if (index1 == 0)
      {
        if (((CustomData) Entities[index1]).sortDirection == entitySortDirection.Normal)
        {
          TpPnt9D tpPnt9D = new TpPnt9D();
          tpPnt9D.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
          tpPnt9D.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
          tpPnt9D.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
          tpPnt9D.Type = 0;
          ((TpArcData) tpPnt9D).P9 = new Pnt9D(((CustomData) Entities[index1]).StartPoint.X, ((CustomData) Entities[index1]).StartPoint.Y, ((CustomData) Entities[index1]).StartPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
          camTpPoint.Points.Add(tpPnt9D);
        }
        else
        {
          TpPnt9D tpPnt9D = new TpPnt9D();
          tpPnt9D.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
          tpPnt9D.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
          tpPnt9D.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
          tpPnt9D.Type = 0;
          ((TpArcData) tpPnt9D).P9 = new Pnt9D(((CustomData) Entities[index1]).EndPoint.X, ((CustomData) Entities[index1]).EndPoint.Y, ((CustomData) Entities[index1]).EndPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
          camTpPoint.Points.Add(tpPnt9D);
        }
      }
      if (Entities[index1].GetType() == typeof (buArc))
      {
        buArc entity = Entities[index1] as buArc;
        if (((CustomData) entity).sortDirection == entitySortDirection.Reverse)
        {
          TpPnt9D tpPnt9D = new TpPnt9D();
          tpPnt9D.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
          tpPnt9D.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
          tpPnt9D.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
          tpPnt9D.ArcData = (TpArcData) new camParameters5(((CustomDataSurrogate) entity).Center, ((CustomData) entity).StartPoint, ((CustomData) entity).EndPoint);
          ((SimulationTp) tpPnt9D.ArcData).Radius = ((CustomDataSurrogate) entity).Radius;
          ((SimulationTp) tpPnt9D.ArcData).StartAngle = buCall.\u0001.PointAngle(((CustomData) entity).StartPoint, ((CustomDataSurrogate) entity).Center, ((CustomDataSurrogate) entity).Plane);
          ((SimulationTp) tpPnt9D.ArcData).EndAngle = buCall.\u0001.PointAngle(((CustomData) entity).EndPoint, ((CustomDataSurrogate) entity).Center, ((CustomDataSurrogate) entity).Plane);
          ((SimulationTp) tpPnt9D.ArcData).SweepAngle = ((SimulationTp) tpPnt9D.ArcData).EndAngle - ((SimulationTp) tpPnt9D.ArcData).StartAngle;
          tpPnt9D.Type = 2;
          ((TpArcData) tpPnt9D).P9 = new Pnt9D(((CustomData) Entities[index1]).StartPoint.X, ((CustomData) Entities[index1]).StartPoint.Y, ((CustomData) Entities[index1]).StartPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
          tpPnt9D.Feed = Parameter.Speeds.Feed;
          if (((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed > 0.0)
            tpPnt9D.Feed = ((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed;
          camTpPoint.Points.Add(tpPnt9D);
        }
        else
        {
          TpPnt9D tpPnt9D = new TpPnt9D();
          tpPnt9D.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
          tpPnt9D.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
          tpPnt9D.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
          tpPnt9D.ArcData = (TpArcData) new camParameters5(((CustomDataSurrogate) entity).Center, ((CustomData) entity).StartPoint, ((CustomData) entity).EndPoint);
          ((SimulationTp) tpPnt9D.ArcData).Radius = ((CustomDataSurrogate) entity).Radius;
          ((SimulationTp) tpPnt9D.ArcData).StartAngle = buCall.\u0001.PointAngle(((CustomData) entity).StartPoint, ((CustomDataSurrogate) entity).Center, ((CustomDataSurrogate) entity).Plane);
          ((SimulationTp) tpPnt9D.ArcData).EndAngle = buCall.\u0001.PointAngle(((CustomData) entity).EndPoint, ((CustomDataSurrogate) entity).Center, ((CustomDataSurrogate) entity).Plane);
          ((SimulationTp) tpPnt9D.ArcData).SweepAngle = ((SimulationTp) tpPnt9D.ArcData).EndAngle - ((SimulationTp) tpPnt9D.ArcData).StartAngle;
          tpPnt9D.Type = 3;
          ((TpArcData) tpPnt9D).P9 = new Pnt9D(((CustomData) Entities[index1]).EndPoint.X, ((CustomData) Entities[index1]).EndPoint.Y, ((CustomData) Entities[index1]).EndPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
          tpPnt9D.Feed = Parameter.Speeds.Feed;
          if (((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed > 0.0)
            tpPnt9D.Feed = ((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed;
          camTpPoint.Points.Add(tpPnt9D);
        }
      }
      else if (((CustomDataSurrogate) Entities[index1]).typeDefination == entityTypeDefination.CamPlunge | ((CustomDataSurrogate) Entities[index1]).typeDefination == entityTypeDefination.CamPlungeFast)
      {
        TpPnt9D tpPnt9D1 = new TpPnt9D();
        if (camTpPoint.Points.Count > 0 && !buConversion5.EQ(new Point3D(((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.X, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Y, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Z), ((CustomData) Entities[index1]).StartPoint))
        {
          tpPnt9D1.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
          tpPnt9D1.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
          tpPnt9D1.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
          tpPnt9D1.Type = 0;
          ((TpArcData) tpPnt9D1).P9 = new Pnt9D(((CustomData) Entities[index1]).StartPoint.X, ((CustomData) Entities[index1]).StartPoint.Y, ((CustomData) Entities[index1]).StartPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
          tpPnt9D1.Feed = Parameter.Speeds.Rapid;
          camTpPoint.Points.Add(tpPnt9D1);
        }
        TpPnt9D tpPnt9D2 = new TpPnt9D();
        tpPnt9D2.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
        tpPnt9D2.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
        tpPnt9D2.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
        tpPnt9D2.Type = 1;
        tpPnt9D2.PlungeAxisMovement = true;
        if (((CustomDataSurrogate) Entities[index1]).typeDefination == entityTypeDefination.CamPlungeFast)
          tpPnt9D2.Type = 0;
        if (buConversion5.EQ(((CustomDataSurrogate) Entities[index1]).Orientation.A, 90.0) | buConversion5.EQ(((CustomDataSurrogate) Entities[index1]).Orientation.A, -90.0))
          tpPnt9D2.PlungeAxis = "Y";
        if (((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamPlungeAxis != null)
          tpPnt9D2.PlungeAxis = ((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamPlungeAxis;
        ((TpArcData) tpPnt9D2).P9 = new Pnt9D(((CustomData) Entities[index1]).EndPoint.X, ((CustomData) Entities[index1]).EndPoint.Y, ((CustomData) Entities[index1]).EndPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
        tpPnt9D2.Feed = Parameter.Speeds.Plunge;
        if (((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed > 0.0)
          tpPnt9D2.Feed = ((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed;
        camTpPoint.Points.Add(tpPnt9D2);
      }
      else if (((CustomDataSurrogate) Entities[index1]).typeDefination == entityTypeDefination.CamLeave)
      {
        TpPnt9D tpPnt9D = new TpPnt9D();
        tpPnt9D.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
        tpPnt9D.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
        tpPnt9D.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
        tpPnt9D.Type = 0;
        tpPnt9D.LeaveAxisMovement = true;
        if (!buConversion5.EQ(((CustomDataSurrogate) Entities[index1]).Orientation.A, 0.0))
          tpPnt9D.LeaveAxis = "";
        if (buConversion5.EQ(((CustomDataSurrogate) Entities[index1]).Orientation.A, 90.0) | buConversion5.EQ(((CustomDataSurrogate) Entities[index1]).Orientation.A, -90.0))
          tpPnt9D.LeaveAxis = "Y";
        if (((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamLeaveAxis != null)
          tpPnt9D.LeaveAxis = ((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamLeaveAxis;
        ((TpArcData) tpPnt9D).P9 = new Pnt9D(((CustomData) Entities[index1]).EndPoint.X, ((CustomData) Entities[index1]).EndPoint.Y, ((CustomData) Entities[index1]).EndPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
        tpPnt9D.Feed = ((camSpeedsEnable) Parameter.Speeds).Leave;
        camTpPoint.Points.Add(tpPnt9D);
      }
      else if (((CustomDataSurrogate) Entities[index1]).typeDefination == entityTypeDefination.CamG0)
      {
        TpPnt9D tpPnt9D = new TpPnt9D();
        tpPnt9D.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
        tpPnt9D.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
        tpPnt9D.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
        tpPnt9D.Type = 0;
        ((TpArcData) tpPnt9D).P9 = new Pnt9D(((CustomData) Entities[index1]).EndPoint.X, ((CustomData) Entities[index1]).EndPoint.Y, ((CustomData) Entities[index1]).EndPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
        tpPnt9D.Feed = Parameter.Speeds.Rapid;
        camTpPoint.Points.Add(tpPnt9D);
      }
      else if (Entities[index1].GetType() == typeof (buLine))
      {
        if (((CustomData) Entities[index1]).sortDirection == entitySortDirection.Normal)
        {
          TpPnt9D tpPnt9D3 = new TpPnt9D();
          if (!buConversion5.EQ(new Point3D(((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.X, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Y, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Z), ((CustomData) Entities[index1]).StartPoint))
          {
            TpPnt9D tpPnt9D4 = new TpPnt9D();
            tpPnt9D4.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
            tpPnt9D4.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
            tpPnt9D4.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
            tpPnt9D4.Type = 0;
            ((TpArcData) tpPnt9D4).P9 = new Pnt9D(((CustomData) Entities[index1]).StartPoint.X, ((CustomData) Entities[index1]).StartPoint.Y, ((CustomData) Entities[index1]).StartPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
            tpPnt9D4.Feed = Parameter.Speeds.Feed;
            camTpPoint.Points.Add(tpPnt9D4);
          }
          TpPnt9D tpPnt9D5 = new TpPnt9D();
          tpPnt9D5.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
          tpPnt9D5.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
          tpPnt9D5.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
          tpPnt9D5.Type = 1;
          ((TpArcData) tpPnt9D5).P9 = new Pnt9D(((CustomData) Entities[index1]).EndPoint.X, ((CustomData) Entities[index1]).EndPoint.Y, ((CustomData) Entities[index1]).EndPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
          tpPnt9D5.Feed = Parameter.Speeds.Feed;
          if (((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed > 0.0)
            tpPnt9D5.Feed = ((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed;
          camTpPoint.Points.Add(tpPnt9D5);
        }
        else
        {
          TpPnt9D tpPnt9D6 = new TpPnt9D();
          if (!buConversion5.EQ(new Point3D(((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.X, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Y, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Z), ((CustomData) Entities[index1]).EndPoint))
          {
            TpPnt9D tpPnt9D7 = new TpPnt9D();
            tpPnt9D7.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
            tpPnt9D7.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
            tpPnt9D7.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
            tpPnt9D7.Type = 0;
            ((TpArcData) tpPnt9D7).P9 = new Pnt9D(((CustomData) Entities[index1]).EndPoint.X, ((CustomData) Entities[index1]).EndPoint.Y, ((CustomData) Entities[index1]).EndPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
            tpPnt9D7.Feed = Parameter.Speeds.Feed;
            camTpPoint.Points.Add(tpPnt9D7);
          }
          TpPnt9D tpPnt9D8 = new TpPnt9D();
          tpPnt9D8.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
          tpPnt9D8.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
          tpPnt9D8.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
          tpPnt9D8.Type = 1;
          ((TpArcData) tpPnt9D8).P9 = new Pnt9D(((CustomData) Entities[index1]).StartPoint.X, ((CustomData) Entities[index1]).StartPoint.Y, ((CustomData) Entities[index1]).StartPoint.Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
          tpPnt9D8.Feed = Parameter.Speeds.Feed;
          if (((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed > 0.0)
            tpPnt9D8.Feed = ((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed;
          camTpPoint.Points.Add(tpPnt9D8);
        }
      }
      else if (Entities[index1].GetType() == typeof (buLinearPath))
      {
        if (((CustomData) Entities[index1]).sortDirection == entitySortDirection.Normal)
        {
          buLinearPath entity = Entities[index1] as buLinearPath;
          int num = 0;
          if (camTpPoint.Points.Count > 0 && buConversion5.EQ(new Point3D(((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.X, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Y, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Z), ((CustomDataSurrogate) entity).Vertices[0]))
            num = 1;
          for (int index2 = num; index2 <= ((CustomDataSurrogate) entity).Vertices.Count - 1; ++index2)
          {
            TpPnt9D tpPnt9D = new TpPnt9D();
            tpPnt9D.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
            tpPnt9D.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
            tpPnt9D.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
            tpPnt9D.Type = 1;
            if (index2 == 0)
            {
              tpPnt9D.Type = 0;
              if (index1 > 0 && ((CustomDataSurrogate) Entities[index1 - 1]).typeDefination == entityTypeDefination.CamPlunge | ((CustomDataSurrogate) Entities[index1 - 1]).typeDefination == entityTypeDefination.CamWireframeContour | ((CustomDataSurrogate) Entities[index1 - 1]).typeDefination == entityTypeDefination.CamWireframeContourFinish | ((CustomDataSurrogate) Entities[index1 - 1]).typeDefination == entityTypeDefination.CamWireframePocket)
                tpPnt9D.Type = 1;
            }
            ((TpArcData) tpPnt9D).P9 = new Pnt9D(((CustomDataSurrogate) entity).Vertices[index2].X, ((CustomDataSurrogate) entity).Vertices[index2].Y, ((CustomDataSurrogate) entity).Vertices[index2].Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
            tpPnt9D.Feed = Parameter.Speeds.Feed;
            if (((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed > 0.0)
              tpPnt9D.Feed = ((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed;
            camTpPoint.Points.Add(tpPnt9D);
          }
        }
        else
        {
          buLinearPath entity = Entities[index1] as buLinearPath;
          List<Point3D> copiedPoint = new List<Point3D>();
          buVector5.Copy(((CustomDataSurrogate) entity).Vertices, ref copiedPoint);
          copiedPoint.Reverse();
          int num = 0;
          if (camTpPoint.Points.Count > 0 && buConversion5.EQ(new Point3D(((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.X, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Y, ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Z), copiedPoint[0]))
            num = 1;
          for (int index3 = num; index3 <= copiedPoint.Count - 1; ++index3)
          {
            TpPnt9D tpPnt9D = new TpPnt9D();
            tpPnt9D.EnableAxes = new AxesEnableWithUVW(true, true, true, true, false, false);
            tpPnt9D.ToolNo = (double) ((ToolCamData5) ((ToolGeometry5) Tool).Data).No;
            tpPnt9D.ToolName = ((ToolCamData5) ((ToolGeometry5) Tool).Data).Name;
            tpPnt9D.Type = 1;
            if (index3 == 0)
              tpPnt9D.Type = 0;
            ((TpArcData) tpPnt9D).P9 = new Pnt9D(copiedPoint[index3].X, copiedPoint[index3].Y, copiedPoint[index3].Z, ((CustomDataSurrogate) Entities[index1]).Orientation.A, ((CustomDataSurrogate) Entities[index1]).Orientation.B, ((CustomDataSurrogate) Entities[index1]).Orientation.C);
            tpPnt9D.Feed = Parameter.Speeds.Feed;
            if (((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed > 0.0)
              tpPnt9D.Feed = ((AnalyseEntitiesResultError) ((CustomData) Entities[index1]).Info).CamSpeed;
            camTpPoint.Points.Add(tpPnt9D);
          }
        }
      }
    }
    camTp.Tool = (ToolBase5) new ToolGeometry5(Tool);
    camTp.CamPoints.Add(camTpPoint);
    Cam.Add(camTp);
    return true;
  }

  public bool camContourCenter(
    List<Entity> RefEntities,
    bool TangentCalculaton,
    ToolBase5 Tool,
    camParameters5 camPars,
    ref camTp CamCalculated)
  {
    CamCalculated.Name = "Contour  ";
    List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
    List<double> Heights1 = new List<double>();
    List<double> Heights2 = new List<double>();
    camTpPoint camTpPoint1 = (camTpPoint) new TpPnt9D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    Pnt3D pnt3D1 = new Pnt3D();
    Point3D Pnt1 = new Point3D();
    Point3D point3D1 = new Point3D();
    Point3D Pnt2 = new Point3D();
    Point3D point3D2 = new Point3D();
    int num1 = 0;
    double num2 = 0.0;
    double feed1 = camPars.Speeds.Feed;
    double plunge = camPars.Speeds.Plunge;
    double leave = ((camSpeedsEnable) camPars.Speeds).Leave;
    double rapid = camPars.Speeds.Rapid;
    CamCalculated.TypeCam = CamType.ContourOpenCenter;
    if (((ToolGeometry5) Tool).Purpose == ToolPurpose.DiamondCut | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Saw)
      ;
    buCall.\u0001.SplitArcEntitiesIfGreaterThen180Degree(ref RefEntities);
    buCall.\u0001.EntitiesSplitByUpperLine(RefEntities, ref SplitedEntitites);
    double num3 = !camPars.Steps.Enable ? camPars.Operations.Height : camPars.Steps.StartValue;
    if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions)
    {
      if (camPars.Steps.Enable)
      {
        ((MachineOtherCodeInfo) buCall.\u0001).CamStepHeightCalculation(camPars.Steps, ref Heights1);
      }
      else
      {
        Heights1.Clear();
        Heights1.Add(camPars.Operations.Height);
      }
      Heights2.Add(0.0);
    }
    else
    {
      if (camPars.Steps.Enable)
      {
        ((MachineOtherCodeInfo) buCall.\u0001).CamStepHeightCalculation(camPars.Steps, ref Heights2);
      }
      else
      {
        Heights2.Clear();
        Heights2.Add(camPars.Operations.Height);
      }
      Heights1.Add(0.0);
    }
    bool flag1 = false;
    for (int index1 = 0; index1 <= Heights2.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= SplitedEntitites.Count - 1; ++index2)
      {
        bool flag2 = false;
        List<Entity> entityList1 = new List<Entity>();
        if (index1 == Heights2.Count - 1 & index2 == SplitedEntitites.Count - 1)
          flag1 = true;
        bool flag3 = ((F_AnalyseResult) buCall.\u0001).isEntitiesClosed(SplitedEntitites[index2]);
        ClockDirectionType clockDirectionType = buCall.\u0001.EntitiesClockDirection(SplitedEntitites[index2]);
        if (flag3)
        {
          if (clockDirectionType != ((camOptions5) camPars.Operations).Direction)
            buCall.\u0001.ChangeEntitiesDirection(SplitedEntitites[index2], ref entityList1);
          else
            buVector5.CopyEntities(SplitedEntitites[index2], ref entityList1);
        }
        else
          buVector5.CopyEntities(SplitedEntitites[index2], ref entityList1);
        for (int index3 = 0; index3 <= Heights1.Count - 1; ++index3)
        {
          double z1 = Heights1[index3];
          if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
            z1 = Heights2[index1];
          List<Point3D> points = new List<Point3D>();
          List<Entity> entityList2 = new List<Entity>();
          if (!flag3)
          {
            if (camPars.Strategy.CuttingMethod == CamCuttingMethod.MachtypeZigzag)
            {
              if (index3 % 2 == 0)
                buVector5.CopyEntities(entityList1, ref entityList2);
              else
                buCall.\u0001.ChangeEntitiesDirection(entityList1, ref entityList2);
            }
            else
              buVector5.CopyEntities(entityList1, ref entityList2);
          }
          else
            buVector5.CopyEntities(entityList1, ref entityList2);
          if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions && index3 < Heights1.Count - 1)
          {
            List<Entity> entityList3 = new List<Entity>();
            if (!flag3)
            {
              if (camPars.Strategy.CuttingMethod == CamCuttingMethod.MachtypeZigzag)
              {
                if ((index3 + 1) % 2 == 0)
                  buVector5.CopyEntities(entityList1, ref entityList3);
                else
                  buCall.\u0001.ChangeEntitiesDirection(entityList1, ref entityList3);
              }
              else
                buVector5.CopyEntities(entityList1, ref entityList3);
            }
            else
              buVector5.CopyEntities(entityList1, ref entityList3);
            if (entityList3.Count > 0)
              point3D2 = ((CutterIsoFileItems) buCall.\u0001.GetEntityCustomData(entityList3[0])).get_sortDirection() != entitySortDirection.Normal ? new Point3D(((ICurve) entityList3[0]).EndPoint.X, ((ICurve) entityList3[0]).EndPoint.Y, z1) : new Point3D(((ICurve) entityList3[0]).StartPoint.X, ((ICurve) entityList3[0]).StartPoint.Y, z1);
          }
          for (int index4 = 0; index4 <= entityList2.Count - 1; ++index4)
          {
            Pnt6D Pnt3 = new Pnt6D();
            Entity entity = entityList2[index4];
            List<Point3D> point3DList = new List<Point3D>();
            bool flag4 = false;
            bool flag5 = false;
            double safe = camPars.Distances.Safe;
            double feed2 = camPars.Speeds.Feed;
            double feed3 = camPars.Speeds.Plunge;
            double feed4 = ((camSpeedsEnable) camPars.Speeds).Leave;
            double feed5 = camPars.Speeds.Rapid;
            if (camPars.Options.FeedFromEntityFeedrate && ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate() > 0.0)
            {
              feed2 = ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate();
              feed3 = ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate();
              feed4 = ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate();
              feed5 = ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate();
            }
            if (entity is ICurve)
            {
              F_CutterOffsetEntities.VerticeToPointsList(entity.Vertices, ref point3DList);
              if (!((camRotary5) camPars.Options).UseXZPlane)
                buCall.\u0001.SetValueToPointList(0.0, 0.0, z1, false, false, true, ref point3DList);
              switch (entity)
              {
                case Line _:
                  if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                  {
                    if (index4 == 0)
                    {
                      Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                      break;
                    }
                    break;
                  }
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                  break;
                case Arc _:
                  flag4 = true;
                  if (TangentCalculaton)
                    flag4 = false;
                  if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                  {
                    if (index4 == 0)
                    {
                      Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                      break;
                    }
                    break;
                  }
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                  break;
                case LinearPath _:
                  if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                  {
                    if (index4 == 0)
                    {
                      Pnt1 = !((camRotary5) camPars.Options).UseXZPlane ? new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1) : new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, entity.Vertices[0].Z);
                      break;
                    }
                    break;
                  }
                  if (index4 == 0)
                    Pnt1 = !((camRotary5) camPars.Options).UseXZPlane ? new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1) : new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, entity.Vertices[entity.Vertices.Length - 1].Z);
                  point3DList.Reverse();
                  break;
                case Curve _:
                  if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                  {
                    if (index4 == 0)
                    {
                      Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                      break;
                    }
                    break;
                  }
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                  break;
                case Ellipse _:
                  if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                  {
                    if (index4 == 0)
                    {
                      Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                      break;
                    }
                    break;
                  }
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                  break;
                default:
                  if (entity.GetType() == typeof (EllipticalArc))
                  {
                    if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                    {
                      if (index4 == 0)
                      {
                        Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                        break;
                      }
                      break;
                    }
                    if (index4 == 0)
                      Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                    point3DList.Reverse();
                    break;
                  }
                  break;
              }
            }
            double z2;
            if (index2 == 0 & index4 == 0)
            {
              z2 = camPars.Distances.Safe;
            }
            else
            {
              z2 = num3 + ((camMaterial5) camPars.Distances).Rapid;
              if (index2 > 0 & index4 == 0 & camTpPoint1.Points.Count > 0 && z2 < ((TpArcData) camTpPoint1.Points[camTpPoint1.Points.Count - 1]).P9.Z)
                z2 = ((TpArcData) camTpPoint1.Points[camTpPoint1.Points.Count - 1]).P9.Z;
            }
            if (index4 == 0)
              flag5 = true;
            if ((flag3 | flag2) & index3 > 0)
              flag5 = false;
            double RefAngle = buCall.\u0001.PointAngle(point3DList[1], point3DList[0], Plane.XY) + camPars.Strategy.TangentOffset;
            if (buConversion5.EQ(RefAngle, 0.0) && num2 > 180.0)
              RefAngle = 360.0;
            if (index3 == 0 & index4 == 0 & camPars.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle && RefAngle > 180.0)
              RefAngle -= 360.0;
            if (num1 > 0)
              ((MachineOtherCodeInfo) buCall.\u0001).CamTangentCalculation(ref RefAngle, num2, camPars);
            else
              num2 = RefAngle;
            if (flag2 && buConversion5.EQ(Math.Abs(RefAngle - num2), 0.0) | buConversion5.EQ(Math.Abs(RefAngle - num2), 180.0))
              RefAngle = num2;
            if (camPars.Strategy.UseContantTangent)
            {
              RefAngle = camPars.Strategy.ContantTangent;
              num2 = camPars.Strategy.ContantTangent;
            }
            if (!buConversion5.EQ(RefAngle, num2) & TangentCalculaton)
              flag5 = true;
            if (!TangentCalculaton)
              RefAngle = 0.0;
            if (index4 == 0)
            {
              points.Add(F_NotchEdit.ToPoint3D(Pnt1));
              Pnt3 = new Pnt6D(Pnt1.X, Pnt1.Y, Pnt1.Z, 0.0, 0.0, RefAngle);
              if (flag5)
              {
                if (index2 == 0)
                {
                  Pnt3D pnt3D2 = new Pnt3D(Pnt3);
                  camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D2.X, pnt3D2.Y, z2), feed4, 0)
                  {
                    PlungeAxis = "Z",
                    PlungeAxisMovement = true
                  });
                }
                Pnt3D pnt3D3 = new Pnt3D(Pnt3);
                TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, z2, 0.0, 0.0, Pnt3.C), feed5, 0);
                camTpPoint1.Points.Add(tpPnt9D2);
                if (z2 != num3 + ((camDrill5) camPars.Distances).EntryAndExit)
                {
                  buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(pnt3D3.X, pnt3D3.Y, z2), new Point3D(pnt3D3.X, pnt3D3.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit));
                  ((CustomData) buLineCam).set_MoveType(CamMoveType.G0);
                  buLineCam.Color = Color.Green;
                  ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesPlunge.Add((Entity) buLineCam);
                  pnt3D3 = new Pnt3D(Pnt3);
                  camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed5, 0)
                  {
                    PlungeAxis = "Z",
                    PlungeAxisMovement = true
                  });
                }
                buLineCam buLineCam1 = (buLineCam) new CustomData(new Point3D(pnt3D3.X, pnt3D3.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit), new Point3D(pnt3D3.X, pnt3D3.Y, z1));
                ((CustomData) buLineCam1).set_MoveType(CamMoveType.Plunge);
                buLineCam1.Color = Color.Green;
                ((CustomData) buLineCam1).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                CamCalculated.EntitiesPlunge.Add((Entity) buLineCam1);
                pnt3D1 = new Pnt3D(Pnt3);
                camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed3, 1)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
              }
              else
              {
                pnt3D1 = new Pnt3D(Pnt3);
                camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed3, 1)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
              }
            }
            if (index4 > 0 & TangentCalculaton && Math.Abs(RefAngle - num2) > camPars.Strategy.AngleLimit & camPars.Strategy.UseTangentLimit)
            {
              TpPnt9D tpPnt9D3 = new TpPnt9D();
              ((TpArcData) tpPnt9D3).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, num2);
              tpPnt9D3.Type = 1;
              tpPnt9D3.Feed = feed4;
              tpPnt9D3.PlungeAxisMovement = true;
              tpPnt9D3.PlungeAction = CamPlungeActionType.GoUp;
              camTpPoint1.Points.Add(tpPnt9D3);
              buLineCam buLineCam2 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid));
              ((CustomData) buLineCam2).set_MoveType(CamMoveType.Leave);
              buLineCam2.Color = Color.Blue;
              ((CustomData) buLineCam2).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
              CamCalculated.EntitiesLeave.Add((Entity) buLineCam2);
              TpPnt9D tpPnt9D4 = new TpPnt9D();
              ((TpArcData) tpPnt9D4).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, RefAngle);
              tpPnt9D4.Type = 0;
              tpPnt9D4.Feed = feed5;
              tpPnt9D4.PlungeAxisMovement = false;
              camTpPoint1.Points.Add(tpPnt9D4);
              TpPnt9D tpPnt9D5 = new TpPnt9D();
              ((TpArcData) tpPnt9D5).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z, 0.0, 0.0, RefAngle);
              tpPnt9D5.Type = 1;
              tpPnt9D5.Feed = feed3;
              tpPnt9D5.PlungeAxisMovement = true;
              tpPnt9D5.PlungeAction = CamPlungeActionType.GoDownAproach;
              camTpPoint1.Points.Add(tpPnt9D5);
              buLineCam buLineCam3 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
              ((CustomData) buLineCam3).set_MoveType(CamMoveType.Plunge);
              buLineCam3.Color = Color.Green;
              ((CustomData) buLineCam3).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
              CamCalculated.EntitiesPlunge.Add((Entity) buLineCam3);
            }
            if (!flag4)
            {
              for (int index5 = 1; index5 <= point3DList.Count - 1; ++index5)
              {
                RefAngle = buCall.\u0001.PointAngle(point3DList[index5], point3DList[index5 - 1], Plane.XY) + camPars.Strategy.TangentOffset;
                if (buConversion5.EQ(RefAngle, 0.0) && num2 > 180.0)
                  RefAngle = 360.0;
                ((MachineOtherCodeInfo) buCall.\u0001).CamTangentCalculation(ref RefAngle, num2, camPars);
                if (flag2 && buConversion5.EQ(Math.Abs(RefAngle - num2), 0.0) | buConversion5.EQ(Math.Abs(RefAngle - num2), 180.0))
                  RefAngle = num2;
                if (camPars.Strategy.UseContantTangent)
                  RefAngle = camPars.Strategy.ContantTangent;
                double num4 = RefAngle - num2;
                if (!TangentCalculaton)
                {
                  RefAngle = 0.0;
                  num2 = 0.0;
                }
                if (TangentCalculaton & index5 > 1 && Math.Abs(num4) > camPars.Strategy.AngleLimit & camPars.Strategy.UseTangentLimit)
                {
                  TpPnt9D tpPnt9D6 = new TpPnt9D();
                  ((TpArcData) tpPnt9D6).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, num2);
                  tpPnt9D6.Type = 1;
                  tpPnt9D6.Feed = feed4;
                  tpPnt9D6.PlungeAxisMovement = true;
                  tpPnt9D6.PlungeAction = CamPlungeActionType.GoUp;
                  camTpPoint1.Points.Add(tpPnt9D6);
                  buLineCam buLineCam4 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid));
                  ((CustomData) buLineCam4).set_MoveType(CamMoveType.Leave);
                  buLineCam4.Color = Color.Blue;
                  ((CustomData) buLineCam4).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesLeave.Add((Entity) buLineCam4);
                  TpPnt9D tpPnt9D7 = new TpPnt9D();
                  ((TpArcData) tpPnt9D7).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, RefAngle);
                  tpPnt9D7.Type = 0;
                  tpPnt9D7.Feed = feed5;
                  tpPnt9D7.PlungeAxisMovement = false;
                  camTpPoint1.Points.Add(tpPnt9D7);
                  TpPnt9D tpPnt9D8 = new TpPnt9D();
                  ((TpArcData) tpPnt9D8).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z, 0.0, 0.0, RefAngle);
                  tpPnt9D8.Type = 1;
                  tpPnt9D8.Feed = feed3;
                  tpPnt9D8.PlungeAxisMovement = true;
                  tpPnt9D8.PlungeAction = CamPlungeActionType.GoDownAproach;
                  camTpPoint1.Points.Add(tpPnt9D8);
                  buLineCam buLineCam5 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
                  ((CustomData) buLineCam5).set_MoveType(CamMoveType.Plunge);
                  buLineCam5.Color = Color.Green;
                  ((CustomData) buLineCam5).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesPlunge.Add((Entity) buLineCam5);
                }
                Pnt3 = new Pnt6D(point3DList[index5].X, point3DList[index5].Y, point3DList[index5].Z, 0.0, 0.0, RefAngle);
                pnt3D1 = new Pnt3D(Pnt3);
                TpPnt9D tpPnt9D9 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 1);
                camTpPoint1.Points.Add(tpPnt9D9);
                Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, z1);
                points.Add(F_NotchEdit.ToPoint3D(Pnt2));
                num2 = RefAngle;
              }
            }
            else
            {
              TpPnt9D tpPnt9D10;
              if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
              {
                Pnt3 = new Pnt6D(((ICurve) entity).EndPoint.X, ((ICurve) entity).EndPoint.Y, z1);
                pnt3D1 = new Pnt3D(Pnt3);
                if (((PlanarEntity) entity).Plane.Equation.Z > 0.0)
                {
                  tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 3);
                  tpPnt9D10.ArcType = 3;
                }
                else
                {
                  tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 2);
                  tpPnt9D10.ArcType = 2;
                }
                tpPnt9D10.Radius = ((Circle) entity).Radius;
              }
              else
              {
                Pnt3 = new Pnt6D(((ICurve) entity).StartPoint.X, ((ICurve) entity).StartPoint.Y, z1);
                pnt3D1 = new Pnt3D(Pnt3);
                if (((PlanarEntity) entity).Plane.Equation.Z > 0.0)
                {
                  tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 2);
                  tpPnt9D10.ArcType = 2;
                }
                else
                {
                  tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 3);
                  tpPnt9D10.ArcType = 3;
                }
                tpPnt9D10.Radius = ((Circle) entity).Radius;
              }
              if (((PlanarEntity) entity).Plane.Equation.Z > 0.0)
              {
                tpPnt9D10.ArcData.StartPoint = new Point3D(((Circle) entity).StartPoint.X, ((Circle) entity).StartPoint.Y, z1);
                tpPnt9D10.ArcData.EndPoint = new Point3D(((Circle) entity).EndPoint.X, ((Circle) entity).EndPoint.Y, z1);
              }
              else
              {
                tpPnt9D10.ArcData.EndPoint = new Point3D(((Circle) entity).StartPoint.X, ((Circle) entity).StartPoint.Y, z1);
                tpPnt9D10.ArcData.StartPoint = new Point3D(((Circle) entity).EndPoint.X, ((Circle) entity).EndPoint.Y, z1);
              }
              tpPnt9D10.ArcData.CenterPoint = new Point3D(((Circle) entity).Center.X, ((Circle) entity).Center.Y, z1);
              ((SimulationTp) tpPnt9D10.ArcData).SweepAngle = ((Arc) entity).AngleInDegrees;
              ((SimulationTp) tpPnt9D10.ArcData).Radius = ((Circle) entity).Radius;
              ((SimulationTp) tpPnt9D10.ArcData).Length = ((Circle) entity).Length();
              ((SimulationTp) tpPnt9D10.ArcData).StartAngle = buCall.\u0001.PointAngle(tpPnt9D10.ArcData.StartPoint, tpPnt9D10.ArcData.CenterPoint, Plane.XY);
              ((SimulationTp) tpPnt9D10.ArcData).EndAngle = buCall.\u0001.PointAngle(tpPnt9D10.ArcData.EndPoint, tpPnt9D10.ArcData.CenterPoint, Plane.XY);
              if (((SimulationTp) tpPnt9D10.ArcData).StartAngle > ((SimulationTp) tpPnt9D10.ArcData).EndAngle)
              {
                TpArcData arcData = tpPnt9D10.ArcData;
                ((SimulationTp) arcData).EndAngle = ((SimulationTp) arcData).EndAngle + 360.0;
              }
              camTpPoint1.Points.Add(tpPnt9D10);
              Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, z1);
              for (int index6 = 1; index6 <= point3DList.Count - 1; ++index6)
                points.Add(new Point3D(point3DList[index6].X, point3DList[index6].Y, z1));
            }
            flag2 = false;
            if (index4 == entityList2.Count - 1)
            {
              Point3D point3D3 = new Point3D(pnt3D1.X, pnt3D1.Y, pnt3D1.Z);
              if (flag1 & index3 == Heights1.Count - 1)
              {
                pnt3D1 = new Pnt3D(point3D3.X, point3D3.Y, point3D3.Z);
                TpPnt9D tpPnt9D11 = !((camDrill5) camPars.Distances).RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, camPars.Distances.Safe, 0.0, 0.0, Pnt3.C), feed4, 1) : new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, camPars.Distances.Safe, 0.0, 0.0, Pnt3.C), feed5, 0);
                tpPnt9D11.PlungeAxis = "Z";
                tpPnt9D11.PlungeAxisMovement = true;
                camTpPoint1.Points.Add(tpPnt9D11);
                buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(pnt3D1.X, pnt3D1.Y, camPars.Distances.Safe));
                ((CustomData) buLineCam).set_MoveType(CamMoveType.Leave);
                buLineCam.Color = Color.Green;
                ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                CamCalculated.EntitiesLeave.Add((Entity) buLineCam);
                Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit);
              }
              else if (!buConversion5.EQ(point3D2, point3D3) | camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
              {
                pnt3D1 = new Pnt3D(point3D3.X, point3D3.Y, point3D3.Z);
                TpPnt9D tpPnt9D12 = !((camDrill5) camPars.Distances).RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed4, 1) : new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed5, 0);
                tpPnt9D12.PlungeAxis = "Z";
                tpPnt9D12.PlungeAxisMovement = true;
                camTpPoint1.Points.Add(tpPnt9D12);
                buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit));
                ((CustomData) buLineCam).set_MoveType(CamMoveType.Leave);
                buLineCam.Color = Color.Green;
                ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                CamCalculated.EntitiesLeave.Add((Entity) buLineCam);
                Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit);
              }
              else
              {
                flag2 = true;
                if (index3 == Heights1.Count - 1)
                {
                  pnt3D1 = new Pnt3D(point3D3.X, point3D3.Y, point3D3.Z);
                  TpPnt9D tpPnt9D13 = !((camDrill5) camPars.Distances).RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed4, 1) : new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed5, 0);
                  tpPnt9D13.PlungeAxis = "Z";
                  tpPnt9D13.PlungeAxisMovement = true;
                  camTpPoint1.Points.Add(tpPnt9D13);
                  buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit));
                  ((CustomData) buLineCam).set_MoveType(CamMoveType.Leave);
                  buLineCam.Color = Color.Green;
                  ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesLeave.Add((Entity) buLineCam);
                  Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit);
                }
              }
            }
            num2 = RefAngle;
            ++num1;
          }
          buLinearPathCam buLinearPathCam = (buLinearPathCam) new CustomData(points);
          ((CustomData) buLinearPathCam).set_MoveType(CamMoveType.G1);
          buLinearPathCam.Color = Color.Red;
          ((CustomData) buLinearPathCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
          CamCalculated.EntitiesG1.Add((Entity) buLinearPathCam);
        }
      }
    }
    if (!TangentCalculaton)
    {
      for (int index = 0; index <= camTpPoint1.Points.Count - 1; ++index)
        ((TpArcData) camTpPoint1.Points[index]).P9.C = 0.0;
    }
    this.SimPointCreatForDetailedPoints(camTpPoint1.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
    if (camTpPoint1.Points.Count > 0)
    {
      CamCalculated.Tool = (ToolBase5) new ToolGeometry5(Tool);
      CamCalculated.CamPoints.Add(camTpPoint1);
      camTpPoint camTpPoint2 = (camTpPoint) new TpPnt9D();
    }
    return true;
  }

  public bool camContourCenter(
    List<List<Entity>> SplitedRefEntities,
    bool TangentCalculaton,
    ToolBase5 Tool,
    camParameters5 camPars,
    ref camTp CamCalculated)
  {
    CamCalculated.Name = "Contour  ";
    List<List<Entity>> copiedEnt = new List<List<Entity>>();
    List<double> Heights1 = new List<double>();
    List<double> Heights2 = new List<double>();
    camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    Pnt3D pnt3D1 = new Pnt3D();
    Point3D Pnt1 = new Point3D();
    Point3D point3D1 = new Point3D();
    Point3D Pnt2 = new Point3D();
    Point3D point3D2 = new Point3D();
    int num1 = 0;
    double num2 = 0.0;
    double feed1 = camPars.Speeds.Feed;
    double plunge = camPars.Speeds.Plunge;
    double leave = ((camSpeedsEnable) camPars.Speeds).Leave;
    double rapid = camPars.Speeds.Rapid;
    CamCalculated.TypeCam = CamType.ContourOpenCenter;
    if (((ToolGeometry5) Tool).Purpose == ToolPurpose.DiamondCut | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Saw)
      ;
    buVector5.CopyEntities(SplitedRefEntities, ref copiedEnt);
    double num3 = !camPars.Steps.Enable ? camPars.Operations.Height : camPars.Steps.StartValue;
    if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions)
    {
      if (camPars.Steps.Enable)
      {
        ((MachineOtherCodeInfo) buCall.\u0001).CamStepHeightCalculation(camPars.Steps, ref Heights1);
      }
      else
      {
        Heights1.Clear();
        Heights1.Add(camPars.Operations.Height);
      }
      Heights2.Add(0.0);
    }
    else
    {
      if (camPars.Steps.Enable)
      {
        ((MachineOtherCodeInfo) buCall.\u0001).CamStepHeightCalculation(camPars.Steps, ref Heights2);
      }
      else
      {
        Heights2.Clear();
        Heights2.Add(camPars.Operations.Height);
      }
      Heights1.Add(0.0);
    }
    bool flag1 = false;
    for (int index1 = 0; index1 <= Heights2.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= copiedEnt.Count - 1; ++index2)
      {
        camTpPoint = (camTpPoint) new TpPnt9D();
        bool flag2 = false;
        List<Entity> entityList1 = new List<Entity>();
        if (index2 == 94)
          ;
        if (index1 == Heights2.Count - 1 & index2 == copiedEnt.Count - 1)
          flag1 = true;
        bool flag3 = ((F_AnalyseResult) buCall.\u0001).isEntitiesClosed(copiedEnt[index2]);
        ClockDirectionType clockDirectionType = buCall.\u0001.EntitiesClockDirection(copiedEnt[index2]);
        if (flag3)
        {
          if (clockDirectionType != ((camOptions5) camPars.Operations).Direction)
            buCall.\u0001.ChangeEntitiesDirection(copiedEnt[index2], ref entityList1);
          else
            buVector5.CopyEntities(copiedEnt[index2], ref entityList1);
        }
        else
          buVector5.CopyEntities(copiedEnt[index2], ref entityList1);
        for (int index3 = 0; index3 <= Heights1.Count - 1; ++index3)
        {
          double z1 = Heights1[index3];
          if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
            z1 = Heights2[index1];
          List<Point3D> points = new List<Point3D>();
          List<Entity> entityList2 = new List<Entity>();
          if (!flag3)
          {
            if (camPars.Strategy.CuttingMethod == CamCuttingMethod.MachtypeZigzag)
            {
              if (index3 % 2 == 0)
                buVector5.CopyEntities(entityList1, ref entityList2);
              else
                buCall.\u0001.ChangeEntitiesDirection(entityList1, ref entityList2);
            }
            else
              buVector5.CopyEntities(entityList1, ref entityList2);
          }
          else
            buVector5.CopyEntities(entityList1, ref entityList2);
          if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions && index3 < Heights1.Count - 1)
          {
            List<Entity> entityList3 = new List<Entity>();
            if (!flag3)
            {
              if (camPars.Strategy.CuttingMethod == CamCuttingMethod.MachtypeZigzag)
              {
                if ((index3 + 1) % 2 == 0)
                  buVector5.CopyEntities(entityList1, ref entityList3);
                else
                  buCall.\u0001.ChangeEntitiesDirection(entityList1, ref entityList3);
              }
              else
                buVector5.CopyEntities(entityList1, ref entityList3);
            }
            else
              buVector5.CopyEntities(entityList1, ref entityList3);
            if (entityList3.Count > 0)
              point3D2 = ((CutterIsoFileItems) buCall.\u0001.GetEntityCustomData(entityList3[0])).get_sortDirection() != entitySortDirection.Normal ? new Point3D(((ICurve) entityList3[0]).EndPoint.X, ((ICurve) entityList3[0]).EndPoint.Y, z1) : new Point3D(((ICurve) entityList3[0]).StartPoint.X, ((ICurve) entityList3[0]).StartPoint.Y, z1);
          }
          for (int index4 = 0; index4 <= entityList2.Count - 1; ++index4)
          {
            Pnt6D Pnt3 = new Pnt6D();
            Entity entity = entityList2[index4];
            List<Point3D> point3DList = new List<Point3D>();
            bool flag4 = false;
            bool flag5 = false;
            double safe = camPars.Distances.Safe;
            double feed2 = camPars.Speeds.Feed;
            double feed3 = camPars.Speeds.Plunge;
            double feed4 = ((camSpeedsEnable) camPars.Speeds).Leave;
            double feed5 = camPars.Speeds.Rapid;
            if (camPars.Options.FeedFromEntityFeedrate && ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate() > 0.0)
            {
              feed2 = ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate();
              feed3 = ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate();
              feed4 = ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate();
              feed5 = ((buCutterCalc) entityList2[index4].EntityData).get_CamFeedrate();
            }
            if (entity is ICurve)
            {
              F_CutterOffsetEntities.VerticeToPointsList(entity.Vertices, ref point3DList);
              buCall.\u0001.SetValueToPointList(0.0, 0.0, z1, false, false, true, ref point3DList);
              if (entity is Line)
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity is Arc)
              {
                flag4 = true;
                if (TangentCalculaton)
                  flag4 = false;
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity is LinearPath)
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity is Curve)
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity is Ellipse)
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity.GetType() == typeof (EllipticalArc))
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index4 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
            }
            double z2;
            if (index2 == 0 & index4 == 0)
            {
              z2 = camPars.Distances.Safe;
            }
            else
            {
              z2 = num3 + ((camMaterial5) camPars.Distances).Rapid;
              if (index2 > 0 & index4 == 0 & camTpPoint.Points.Count > 0 && z2 < ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Z)
                z2 = ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Z;
            }
            if (index4 == 0)
              flag5 = true;
            if ((flag3 | flag2) & index3 > 0)
              flag5 = false;
            double RefAngle = buCall.\u0001.PointAngle(point3DList[1], point3DList[0], Plane.XY) + camPars.Strategy.TangentOffset;
            if (buConversion5.EQ(RefAngle, 0.0) && num2 > 180.0)
              RefAngle = 360.0;
            if (num1 > 0)
              ((MachineOtherCodeInfo) buCall.\u0001).CamTangentCalculation(ref RefAngle, num2, camPars);
            else
              num2 = RefAngle;
            if (flag2 && buConversion5.EQ(Math.Abs(RefAngle - num2), 0.0) | buConversion5.EQ(Math.Abs(RefAngle - num2), 180.0))
              RefAngle = num2;
            if (camPars.Strategy.UseContantTangent)
            {
              RefAngle = camPars.Strategy.ContantTangent;
              num2 = camPars.Strategy.ContantTangent;
            }
            if (!buConversion5.EQ(RefAngle, num2) & TangentCalculaton)
              flag5 = true;
            if (!TangentCalculaton)
            {
              RefAngle = 0.0;
              num2 = 0.0;
            }
            if (index4 == 0)
            {
              points.Add(F_NotchEdit.ToPoint3D(Pnt1));
              Pnt3 = new Pnt6D(Pnt1.X, Pnt1.Y, Pnt1.Z, 0.0, 0.0, RefAngle);
              if (flag5)
              {
                if (index2 == 0)
                {
                  Pnt3D pnt3D2 = new Pnt3D(Pnt3);
                  camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(pnt3D2.X, pnt3D2.Y, z2), feed4, 0)
                  {
                    PlungeAxis = "Z",
                    PlungeAxisMovement = true
                  });
                }
                Pnt3D pnt3D3 = new Pnt3D(Pnt3);
                TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, z2, 0.0, 0.0, Pnt3.C), feed5, 0);
                camTpPoint.Points.Add(tpPnt9D2);
                if (z2 != num3 + ((camDrill5) camPars.Distances).EntryAndExit)
                {
                  buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(pnt3D3.X, pnt3D3.Y, z2), new Point3D(pnt3D3.X, pnt3D3.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit));
                  ((CustomData) buLineCam).set_MoveType(CamMoveType.G0);
                  buLineCam.Color = Color.Green;
                  ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesPlunge.Add((Entity) buLineCam);
                  pnt3D3 = new Pnt3D(Pnt3);
                  camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed5, 0)
                  {
                    PlungeAxis = "Z",
                    PlungeAxisMovement = true
                  });
                }
                buLineCam buLineCam1 = (buLineCam) new CustomData(new Point3D(pnt3D3.X, pnt3D3.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit), new Point3D(pnt3D3.X, pnt3D3.Y, z1));
                ((CustomData) buLineCam1).set_MoveType(CamMoveType.Plunge);
                buLineCam1.Color = Color.Green;
                ((CustomData) buLineCam1).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                CamCalculated.EntitiesPlunge.Add((Entity) buLineCam1);
                pnt3D1 = new Pnt3D(Pnt3);
                camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed3, 1)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
              }
              else
              {
                pnt3D1 = new Pnt3D(Pnt3);
                camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed3, 1)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
              }
            }
            if (index4 > 0 & TangentCalculaton && Math.Abs(RefAngle - num2) > camPars.Strategy.AngleLimit & camPars.Strategy.UseTangentLimit)
            {
              TpPnt9D tpPnt9D3 = new TpPnt9D();
              ((TpArcData) tpPnt9D3).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, num2);
              tpPnt9D3.Type = 1;
              tpPnt9D3.Feed = feed4;
              tpPnt9D3.PlungeAxisMovement = true;
              tpPnt9D3.PlungeAction = CamPlungeActionType.GoUp;
              camTpPoint.Points.Add(tpPnt9D3);
              buLineCam buLineCam2 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid));
              ((CustomData) buLineCam2).set_MoveType(CamMoveType.Leave);
              buLineCam2.Color = Color.Blue;
              ((CustomData) buLineCam2).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
              CamCalculated.EntitiesLeave.Add((Entity) buLineCam2);
              TpPnt9D tpPnt9D4 = new TpPnt9D();
              ((TpArcData) tpPnt9D4).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, RefAngle);
              tpPnt9D4.Type = 0;
              tpPnt9D4.Feed = feed5;
              tpPnt9D4.PlungeAxisMovement = false;
              camTpPoint.Points.Add(tpPnt9D4);
              TpPnt9D tpPnt9D5 = new TpPnt9D();
              ((TpArcData) tpPnt9D5).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z, 0.0, 0.0, RefAngle);
              tpPnt9D5.Type = 1;
              tpPnt9D5.Feed = feed3;
              tpPnt9D5.PlungeAxisMovement = true;
              tpPnt9D5.PlungeAction = CamPlungeActionType.GoDownAproach;
              camTpPoint.Points.Add(tpPnt9D5);
              buLineCam buLineCam3 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
              ((CustomData) buLineCam3).set_MoveType(CamMoveType.Plunge);
              buLineCam3.Color = Color.Green;
              ((CustomData) buLineCam3).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
              CamCalculated.EntitiesPlunge.Add((Entity) buLineCam3);
            }
            if (!flag4)
            {
              for (int index5 = 1; index5 <= point3DList.Count - 1; ++index5)
              {
                RefAngle = buCall.\u0001.PointAngle(point3DList[index5], point3DList[index5 - 1], Plane.XY) + camPars.Strategy.TangentOffset;
                if (buConversion5.EQ(RefAngle, 0.0) && num2 > 180.0)
                  RefAngle = 360.0;
                ((MachineOtherCodeInfo) buCall.\u0001).CamTangentCalculation(ref RefAngle, num2, camPars);
                if (flag2 && buConversion5.EQ(Math.Abs(RefAngle - num2), 0.0) | buConversion5.EQ(Math.Abs(RefAngle - num2), 180.0))
                  RefAngle = num2;
                if (camPars.Strategy.UseContantTangent)
                  RefAngle = camPars.Strategy.ContantTangent;
                double num4 = RefAngle - num2;
                if (!TangentCalculaton)
                {
                  RefAngle = 0.0;
                  num2 = 0.0;
                }
                if (TangentCalculaton & index5 > 1 && Math.Abs(num4) > camPars.Strategy.AngleLimit & camPars.Strategy.UseTangentLimit)
                {
                  TpPnt9D tpPnt9D6 = new TpPnt9D();
                  ((TpArcData) tpPnt9D6).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, num2);
                  tpPnt9D6.Type = 1;
                  tpPnt9D6.Feed = feed4;
                  tpPnt9D6.PlungeAxisMovement = true;
                  tpPnt9D6.PlungeAction = CamPlungeActionType.GoUp;
                  camTpPoint.Points.Add(tpPnt9D6);
                  buLineCam buLineCam4 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid));
                  ((CustomData) buLineCam4).set_MoveType(CamMoveType.Leave);
                  buLineCam4.Color = Color.Blue;
                  ((CustomData) buLineCam4).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesLeave.Add((Entity) buLineCam4);
                  TpPnt9D tpPnt9D7 = new TpPnt9D();
                  ((TpArcData) tpPnt9D7).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, RefAngle);
                  tpPnt9D7.Type = 0;
                  tpPnt9D7.Feed = feed5;
                  tpPnt9D7.PlungeAxisMovement = false;
                  camTpPoint.Points.Add(tpPnt9D7);
                  TpPnt9D tpPnt9D8 = new TpPnt9D();
                  ((TpArcData) tpPnt9D8).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z, 0.0, 0.0, RefAngle);
                  tpPnt9D8.Type = 1;
                  tpPnt9D8.Feed = feed3;
                  tpPnt9D8.PlungeAxisMovement = true;
                  tpPnt9D8.PlungeAction = CamPlungeActionType.GoDownAproach;
                  camTpPoint.Points.Add(tpPnt9D8);
                  buLineCam buLineCam5 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
                  ((CustomData) buLineCam5).set_MoveType(CamMoveType.Plunge);
                  buLineCam5.Color = Color.Green;
                  ((CustomData) buLineCam5).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesPlunge.Add((Entity) buLineCam5);
                }
                Pnt3 = new Pnt6D(point3DList[index5].X, point3DList[index5].Y, point3DList[index5].Z, 0.0, 0.0, RefAngle);
                pnt3D1 = new Pnt3D(Pnt3);
                TpPnt9D tpPnt9D9 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 1);
                camTpPoint.Points.Add(tpPnt9D9);
                Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, z1);
                points.Add(F_NotchEdit.ToPoint3D(Pnt2));
                num2 = RefAngle;
              }
            }
            else
            {
              TpPnt9D tpPnt9D10;
              if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
              {
                Pnt3 = new Pnt6D(((ICurve) entity).EndPoint.X, ((ICurve) entity).EndPoint.Y, z1);
                pnt3D1 = new Pnt3D(Pnt3);
                if (((PlanarEntity) entity).Plane.Equation.Z > 0.0)
                {
                  tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 3);
                  tpPnt9D10.ArcType = 3;
                }
                else
                {
                  tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 2);
                  tpPnt9D10.ArcType = 2;
                }
                tpPnt9D10.Radius = ((Circle) entity).Radius;
              }
              else
              {
                Pnt3 = new Pnt6D(((ICurve) entity).StartPoint.X, ((ICurve) entity).StartPoint.Y, z1);
                pnt3D1 = new Pnt3D(Pnt3);
                if (((PlanarEntity) entity).Plane.Equation.Z > 0.0)
                {
                  tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 2);
                  tpPnt9D10.ArcType = 2;
                }
                else
                {
                  tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), feed2, 3);
                  tpPnt9D10.ArcType = 3;
                }
                tpPnt9D10.Radius = ((Circle) entity).Radius;
              }
              if (((PlanarEntity) entity).Plane.Equation.Z > 0.0)
              {
                tpPnt9D10.ArcData.StartPoint = new Point3D(((Circle) entity).StartPoint.X, ((Circle) entity).StartPoint.Y, z1);
                tpPnt9D10.ArcData.EndPoint = new Point3D(((Circle) entity).EndPoint.X, ((Circle) entity).EndPoint.Y, z1);
              }
              else
              {
                tpPnt9D10.ArcData.EndPoint = new Point3D(((Circle) entity).StartPoint.X, ((Circle) entity).StartPoint.Y, z1);
                tpPnt9D10.ArcData.StartPoint = new Point3D(((Circle) entity).EndPoint.X, ((Circle) entity).EndPoint.Y, z1);
              }
              tpPnt9D10.ArcData.CenterPoint = new Point3D(((Circle) entity).Center.X, ((Circle) entity).Center.Y, z1);
              ((SimulationTp) tpPnt9D10.ArcData).SweepAngle = ((Arc) entity).AngleInDegrees;
              ((SimulationTp) tpPnt9D10.ArcData).Radius = ((Circle) entity).Radius;
              ((SimulationTp) tpPnt9D10.ArcData).Length = ((Circle) entity).Length();
              ((SimulationTp) tpPnt9D10.ArcData).StartAngle = buCall.\u0001.PointAngle(tpPnt9D10.ArcData.StartPoint, tpPnt9D10.ArcData.CenterPoint, Plane.XY);
              ((SimulationTp) tpPnt9D10.ArcData).EndAngle = buCall.\u0001.PointAngle(tpPnt9D10.ArcData.EndPoint, tpPnt9D10.ArcData.CenterPoint, Plane.XY);
              if (((SimulationTp) tpPnt9D10.ArcData).StartAngle > ((SimulationTp) tpPnt9D10.ArcData).EndAngle)
              {
                TpArcData arcData = tpPnt9D10.ArcData;
                ((SimulationTp) arcData).EndAngle = ((SimulationTp) arcData).EndAngle + 360.0;
              }
              camTpPoint.Points.Add(tpPnt9D10);
              Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, z1);
              for (int index6 = 1; index6 <= point3DList.Count - 1; ++index6)
                points.Add(new Point3D(point3DList[index6].X, point3DList[index6].Y, z1));
            }
            flag2 = false;
            if (index4 == entityList2.Count - 1)
            {
              Point3D point3D3 = new Point3D(pnt3D1.X, pnt3D1.Y, pnt3D1.Z);
              if (flag1 & index3 == Heights1.Count - 1)
              {
                pnt3D1 = new Pnt3D(point3D3.X, point3D3.Y, point3D3.Z);
                TpPnt9D tpPnt9D11 = !((camDrill5) camPars.Distances).RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, camPars.Distances.Safe, 0.0, 0.0, Pnt3.C), feed4, 1) : new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, camPars.Distances.Safe, 0.0, 0.0, Pnt3.C), feed5, 0);
                tpPnt9D11.PlungeAxis = "Z";
                tpPnt9D11.PlungeAxisMovement = true;
                camTpPoint.Points.Add(tpPnt9D11);
                buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(pnt3D1.X, pnt3D1.Y, camPars.Distances.Safe));
                ((CustomData) buLineCam).set_MoveType(CamMoveType.Leave);
                buLineCam.Color = Color.Green;
                ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                CamCalculated.EntitiesLeave.Add((Entity) buLineCam);
                Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit);
              }
              else if (!buConversion5.EQ(point3D2, point3D3) | camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
              {
                pnt3D1 = new Pnt3D(point3D3.X, point3D3.Y, point3D3.Z);
                TpPnt9D tpPnt9D12 = !((camDrill5) camPars.Distances).RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed4, 1) : new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed5, 0);
                tpPnt9D12.PlungeAxis = "Z";
                tpPnt9D12.PlungeAxisMovement = true;
                camTpPoint.Points.Add(tpPnt9D12);
                buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit));
                ((CustomData) buLineCam).set_MoveType(CamMoveType.Leave);
                buLineCam.Color = Color.Green;
                ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                CamCalculated.EntitiesLeave.Add((Entity) buLineCam);
                Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit);
              }
              else
              {
                flag2 = true;
                if (index3 == Heights1.Count - 1)
                {
                  pnt3D1 = new Pnt3D(point3D3.X, point3D3.Y, point3D3.Z);
                  TpPnt9D tpPnt9D13 = !((camDrill5) camPars.Distances).RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed4, 1) : new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit, 0.0, 0.0, Pnt3.C), feed5, 0);
                  tpPnt9D13.PlungeAxis = "Z";
                  tpPnt9D13.PlungeAxisMovement = true;
                  camTpPoint.Points.Add(tpPnt9D13);
                  buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit));
                  ((CustomData) buLineCam).set_MoveType(CamMoveType.Leave);
                  buLineCam.Color = Color.Green;
                  ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesLeave.Add((Entity) buLineCam);
                  Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camDrill5) camPars.Distances).EntryAndExit);
                }
              }
            }
            num2 = RefAngle;
            ++num1;
          }
          buLinearPathCam buLinearPathCam = (buLinearPathCam) new CustomData(points);
          ((CustomData) buLinearPathCam).set_MoveType(CamMoveType.G1);
          buLinearPathCam.Color = Color.Red;
          ((CustomData) buLinearPathCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
          CamCalculated.EntitiesG1.Add((Entity) buLinearPathCam);
        }
        CamCalculated.CamPoints.Add(camTpPoint);
      }
    }
    for (int index = 0; index <= CamCalculated.CamPoints.Count - 1; ++index)
      this.SimPointCreatForDetailedPoints(CamCalculated.CamPoints[index].Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
    if (camTpPoint.Points.Count > 0)
      ;
    return true;
  }

  public bool camSpin(
    List<List<Entity>> SplitedRefEntities,
    bool TangentCalculaton,
    ToolBase5 Tool,
    camParameters5 camPars,
    ref camTp CamCalculated)
  {
    CamCalculated.Name = "Contour  ";
    List<List<Entity>> copiedEnt = new List<List<Entity>>();
    List<double> Heights1 = new List<double>();
    List<double> Heights2 = new List<double>();
    camTpPoint camTpPoint1 = (camTpPoint) new TpPnt9D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    Pnt3D pnt3D1 = new Pnt3D();
    Point3D Pnt1 = new Point3D();
    Point3D point3D1 = new Point3D();
    Point3D Pnt2 = new Point3D();
    Point3D point3D2 = new Point3D();
    int num1 = 0;
    double num2 = 0.0;
    CamCalculated.TypeCam = CamType.ContourOpenCenter;
    if (((ToolGeometry5) Tool).Purpose == ToolPurpose.DiamondCut | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Saw)
      ;
    buVector5.CopyEntities(SplitedRefEntities, ref copiedEnt);
    double num3 = !camPars.Steps.Enable ? camPars.Operations.Height : camPars.Steps.StartValue;
    if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions)
    {
      if (camPars.Steps.Enable)
      {
        ((MachineOtherCodeInfo) buCall.\u0001).CamStepHeightCalculation(camPars.Steps, ref Heights1);
      }
      else
      {
        Heights1.Clear();
        Heights1.Add(camPars.Operations.Height);
      }
      Heights2.Add(0.0);
    }
    else
    {
      if (camPars.Steps.Enable)
      {
        ((MachineOtherCodeInfo) buCall.\u0001).CamStepHeightCalculation(camPars.Steps, ref Heights2);
      }
      else
      {
        Heights2.Clear();
        Heights2.Add(camPars.Operations.Height);
      }
      Heights1.Add(0.0);
    }
    bool flag1 = false;
    for (int index1 = 0; index1 <= Heights2.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= copiedEnt.Count - 1; ++index2)
      {
        bool flag2 = false;
        List<Entity> entityList1 = new List<Entity>();
        if (index1 == Heights2.Count - 1 & index2 == copiedEnt.Count - 1)
          flag1 = true;
        bool flag3 = ((F_AnalyseResult) buCall.\u0001).isEntitiesClosed(copiedEnt[index2]);
        ClockDirectionType clockDirectionType = buCall.\u0001.EntitiesClockDirection(copiedEnt[index2]);
        if (flag3)
        {
          if (clockDirectionType != ((camOptions5) camPars.Operations).Direction)
            buCall.\u0001.ChangeEntitiesDirection(copiedEnt[index2], ref entityList1);
          else
            buVector5.CopyEntities(copiedEnt[index2], ref entityList1);
        }
        else
          buVector5.CopyEntities(copiedEnt[index2], ref entityList1);
        for (int index3 = 0; index3 <= Heights1.Count - 1; ++index3)
        {
          double z1 = Heights1[index3];
          if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
            z1 = Heights2[index1];
          List<Point3D> points = new List<Point3D>();
          List<Entity> entityList2 = new List<Entity>();
          if (!flag3)
          {
            if (camPars.Strategy.CuttingMethod == CamCuttingMethod.MachtypeZigzag)
            {
              if (index3 % 2 == 0)
                buVector5.CopyEntities(entityList1, ref entityList2);
              else
                buCall.\u0001.ChangeEntitiesDirection(entityList1, ref entityList2);
            }
            else
              buVector5.CopyEntities(entityList1, ref entityList2);
          }
          else
            buVector5.CopyEntities(entityList1, ref entityList2);
          if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions && index3 < Heights1.Count - 1)
          {
            List<Entity> entityList3 = new List<Entity>();
            if (!flag3)
            {
              if (camPars.Strategy.CuttingMethod == CamCuttingMethod.MachtypeZigzag)
              {
                if ((index3 + 1) % 2 == 0)
                  buVector5.CopyEntities(entityList1, ref entityList3);
                else
                  buCall.\u0001.ChangeEntitiesDirection(entityList1, ref entityList3);
              }
              else
                buVector5.CopyEntities(entityList1, ref entityList3);
            }
            else
              buVector5.CopyEntities(entityList1, ref entityList3);
            if (entityList3.Count > 0)
              point3D2 = ((CutterIsoFileItems) buCall.\u0001.GetEntityCustomData(entityList3[0])).get_sortDirection() != entitySortDirection.Normal ? new Point3D(((ICurve) entityList3[0]).EndPoint.X, ((ICurve) entityList3[0]).EndPoint.Y, z1) : new Point3D(((ICurve) entityList3[0]).StartPoint.X, ((ICurve) entityList3[0]).StartPoint.Y, z1);
          }
          double num4 = 0.0;
          for (int index4 = 0; index4 <= entityList2.Count - 1; ++index4)
            num4 += ((ICurve) entityList2[index4]).Length();
          double num5 = 0.0;
          double c = 0.0;
          double num6 = camPars.Strategy.SpinCEndAngle / num4;
          for (int index5 = 0; index5 <= entityList2.Count - 1; ++index5)
          {
            Pnt6D Pnt3 = new Pnt6D();
            Entity entity = entityList2[index5];
            List<Point3D> point3DList = new List<Point3D>();
            bool flag4 = false;
            bool flag5 = false;
            double safe = camPars.Distances.Safe;
            c = 0.0;
            if (entity is ICurve)
            {
              F_CutterOffsetEntities.VerticeToPointsList(entity.Vertices, ref point3DList);
              buCall.\u0001.SetValueToPointList(0.0, 0.0, z1, false, false, true, ref point3DList);
              if (entity is Line)
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity is Arc)
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity is LinearPath)
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity is Curve)
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity is Ellipse)
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
              else if (entity.GetType() == typeof (EllipticalArc))
              {
                if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z1);
                }
                else
                {
                  if (index5 == 0)
                    Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z1);
                  point3DList.Reverse();
                }
              }
            }
            double z2 = !(index2 == 0 & index5 == 0) ? num3 + ((camMaterial5) camPars.Distances).Rapid : camPars.Distances.Safe;
            if (index5 == 0)
              flag5 = true;
            if ((flag3 | flag2) & index3 > 0)
              flag5 = false;
            if (index5 == 0)
            {
              c = num2 + camPars.Strategy.SpinCStartAngle;
              points.Add(F_NotchEdit.ToPoint3D(Pnt1));
              Pnt3 = new Pnt6D(Pnt1.X, Pnt1.Y, Pnt1.Z, 0.0, 0.0, c);
              if (flag5)
              {
                if (index2 == 0)
                {
                  Pnt3D pnt3D2 = new Pnt3D(Pnt3);
                  camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D2.X, pnt3D2.Y, z2), ((camSpeedsEnable) camPars.Speeds).Leave, 0)
                  {
                    PlungeAxis = "Z",
                    PlungeAxisMovement = true
                  });
                }
                Pnt3D pnt3D3 = new Pnt3D(Pnt3);
                TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, z2, 0.0, 0.0, Pnt3.C), camPars.Speeds.Rapid, 0);
                camTpPoint1.Points.Add(tpPnt9D2);
                if (z2 != num3 + ((camMaterial5) camPars.Distances).Rapid)
                {
                  buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(pnt3D3.X, pnt3D3.Y, z2), new Point3D(pnt3D3.X, pnt3D3.Y, num3 + ((camMaterial5) camPars.Distances).Rapid));
                  ((CustomData) buLineCam).set_MoveType(CamMoveType.G0);
                  buLineCam.Color = Color.Green;
                  ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesPlunge.Add((Entity) buLineCam);
                  pnt3D3 = new Pnt3D(Pnt3);
                  camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, num3 + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, Pnt3.C), camPars.Speeds.Rapid, 0)
                  {
                    PlungeAxis = "Z",
                    PlungeAxisMovement = true
                  });
                }
                buLineCam buLineCam1 = (buLineCam) new CustomData(new Point3D(pnt3D3.X, pnt3D3.Y, num3 + ((camMaterial5) camPars.Distances).Rapid), new Point3D(pnt3D3.X, pnt3D3.Y, z1));
                ((CustomData) buLineCam1).set_MoveType(CamMoveType.Plunge);
                buLineCam1.Color = Color.Green;
                ((CustomData) buLineCam1).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                CamCalculated.EntitiesPlunge.Add((Entity) buLineCam1);
                pnt3D1 = new Pnt3D(Pnt3);
                camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), camPars.Speeds.Plunge, 1)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
              }
              else
              {
                pnt3D1 = new Pnt3D(Pnt3);
                camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), camPars.Speeds.Plunge, 1)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
              }
            }
            if (!flag4)
            {
              for (int index6 = 1; index6 <= point3DList.Count - 1; ++index6)
              {
                num5 += Point3D.Distance(point3DList[index6 - 1], point3DList[index6]);
                c = num2 + num5 * num6;
                Pnt3 = new Pnt6D(point3DList[index6].X, point3DList[index6].Y, point3DList[index6].Z, 0.0, 0.0, c);
                pnt3D1 = new Pnt3D(Pnt3);
                TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, z1, 0.0, 0.0, Pnt3.C), camPars.Speeds.Feed, 1);
                camTpPoint1.Points.Add(tpPnt9D3);
                Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, z1);
                points.Add(F_NotchEdit.ToPoint3D(Pnt2));
              }
            }
            flag2 = false;
            if (index5 == entityList2.Count - 1)
            {
              Point3D point3D3 = new Point3D(pnt3D1.X, pnt3D1.Y, pnt3D1.Z);
              if (flag1 & index3 == Heights1.Count - 1)
              {
                pnt3D1 = new Pnt3D(point3D3.X, point3D3.Y, point3D3.Z);
                camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + camPars.Distances.Safe, 0.0, 0.0, Pnt3.C), camPars.Speeds.Rapid, 0)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
                buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(pnt3D1.X, pnt3D1.Y, camPars.Distances.Safe));
                ((CustomData) buLineCam).set_MoveType(CamMoveType.Leave);
                buLineCam.Color = Color.Green;
                ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                CamCalculated.EntitiesLeave.Add((Entity) buLineCam);
                Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camMaterial5) camPars.Distances).Rapid);
              }
              else if (!buConversion5.EQ(point3D2, point3D3) | camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
              {
                pnt3D1 = new Pnt3D(point3D3.X, point3D3.Y, point3D3.Z);
                camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, Pnt3.C), camPars.Speeds.Rapid, 0)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
                buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camMaterial5) camPars.Distances).Rapid));
                ((CustomData) buLineCam).set_MoveType(CamMoveType.Leave);
                buLineCam.Color = Color.Green;
                ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                CamCalculated.EntitiesLeave.Add((Entity) buLineCam);
                Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camMaterial5) camPars.Distances).Rapid);
              }
              else
              {
                flag2 = true;
                if (index3 == Heights1.Count - 1)
                {
                  pnt3D1 = new Pnt3D(point3D3.X, point3D3.Y, point3D3.Z);
                  camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D1.X, pnt3D1.Y, num3 + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, Pnt3.C), camPars.Speeds.Rapid, 0)
                  {
                    PlungeAxis = "Z",
                    PlungeAxisMovement = true
                  });
                  buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camMaterial5) camPars.Distances).Rapid));
                  ((CustomData) buLineCam).set_MoveType(CamMoveType.Leave);
                  buLineCam.Color = Color.Green;
                  ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
                  CamCalculated.EntitiesLeave.Add((Entity) buLineCam);
                  Pnt2 = new Point3D(pnt3D1.X, pnt3D1.Y, num3 + ((camMaterial5) camPars.Distances).Rapid);
                }
              }
            }
            ++num1;
          }
          num2 = c;
          buLinearPathCam buLinearPathCam = (buLinearPathCam) new CustomData(points);
          ((CustomData) buLinearPathCam).set_MoveType(CamMoveType.G1);
          buLinearPathCam.Color = Color.Red;
          ((CustomData) buLinearPathCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
          CamCalculated.EntitiesG1.Add((Entity) buLinearPathCam);
        }
      }
    }
    if (!TangentCalculaton)
    {
      for (int index = 0; index <= camTpPoint1.Points.Count - 1; ++index)
        ((TpArcData) camTpPoint1.Points[index]).P9.C = 0.0;
    }
    this.SimPointCreatForDetailedPoints(camTpPoint1.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
    if (camTpPoint1.Points.Count > 0)
    {
      CamCalculated.CamPoints.Add(camTpPoint1);
      camTpPoint camTpPoint2 = (camTpPoint) new TpPnt9D();
    }
    return true;
  }

  public void camDrill(
    List<Pnt6D> RefPoints,
    ToolBase5 Tool,
    WorkPlane Plane,
    camParameters5 camPars,
    ref camTp CamCalculated)
  {
    CamCalculated.Name = "Point  ";
    camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    Pnt3D pnt3D1 = new Pnt3D();
    Pnt3D pnt3D2 = new Pnt3D();
    double num1 = 0.0;
    double num2 = ((ToolGeometry5) Tool).Geometry.Diameter;
    CamCalculated.TypeCam = CamType.Drill;
    if (((ToolGeometry5) Tool).Purpose == ToolPurpose.DiamondCut | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Saw)
      num2 = ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness;
    ((camOptions5) camPars.Operations).StepHeights.Clear();
    ((camOptions5) camPars.Operations).StepHeights.Add(((camOperation5) ((camOffset5) camPars).Drill).EndHeight);
    if (((camOperation5) ((camOffset5) camPars).Drill).PeckMode)
    {
      int int32 = Convert.ToInt32(buFile5.RoundToLower((((camOperation5) ((camOffset5) camPars).Drill).StartHeight - ((camOperation5) ((camOffset5) camPars).Drill).EndHeight) / ((camOperation5) ((camOffset5) camPars).Drill).PeckDepth));
      ((camOptions5) camPars.Operations).StepHeights.Clear();
      for (int index = 1; index <= int32; ++index)
        ((camOptions5) camPars.Operations).StepHeights.Add(((camOperation5) ((camOffset5) camPars).Drill).StartHeight - (double) index * ((camOperation5) ((camOffset5) camPars).Drill).PeckDepth);
      if (((camOptions5) camPars.Operations).StepHeights.Count > 0)
      {
        if (!buConversion5.EQ(((camOptions5) camPars.Operations).StepHeights[((camOptions5) camPars.Operations).StepHeights.Count - 1], ((camOperation5) ((camOffset5) camPars).Drill).EndHeight))
          ((camOptions5) camPars.Operations).StepHeights.Add(((camOperation5) ((camOffset5) camPars).Drill).EndHeight);
      }
      else
        ((camOptions5) camPars.Operations).StepHeights.Add(((camOperation5) ((camOffset5) camPars).Drill).EndHeight);
    }
    for (int index1 = 0; index1 <= RefPoints.Count - 1; ++index1)
    {
      Pnt6D Pnt = new Pnt6D(RefPoints[index1]);
      Pnt.C += camPars.Strategy.TangentOffset;
      if (camPars.Strategy.UseContantTangent)
        Pnt.C = camPars.Strategy.ContantTangent;
      if (index1 > 0)
      {
        double num3 = Pnt.C - num1;
        if (Math.Abs(num3) > 180.0)
        {
          if (num3 > 0.0)
            Pnt.C -= 360.0;
          else
            Pnt.C += 360.0;
        }
        if (Pnt.C > camPars.Strategy.MaxTangentValue)
        {
          if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue >= 360.0)
            Pnt.C -= 360.0;
          else
            Pnt.C -= camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
        }
        if (Pnt.C < camPars.Strategy.MinTangentValue)
        {
          if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue >= 360.0)
            Pnt.C += 360.0;
          else
            Pnt.C += camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
        }
      }
      Pnt3D pnt3D3;
      Pnt3D pnt3D4;
      if (index1 == 0)
      {
        camTpPoint = (camTpPoint) new TpPnt9D();
        Pnt3D pnt3D5 = new Pnt3D(Pnt);
        camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(pnt3D5.X, pnt3D5.Y, camPars.Distances.Safe), ((camSpeedsEnable) camPars.Speeds).Leave, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt3D pnt3D6 = new Pnt3D(Pnt);
        TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(pnt3D6.X, pnt3D6.Y, camPars.Distances.Safe, 0.0, 0.0, Pnt.C), camPars.Speeds.Rapid, 0);
        camTpPoint.Points.Add(tpPnt9D2);
        pnt3D2 = new Pnt3D(pnt3D6.X, pnt3D6.Y, camPars.Distances.Safe);
        pnt3D3 = new Pnt3D(Pnt);
        camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, Pnt.C), camPars.Speeds.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        pnt3D4 = new Pnt3D(pnt3D3.X, pnt3D3.Y, camPars.Distances.Safe);
      }
      else
      {
        pnt3D3 = new Pnt3D(Pnt);
        TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, Pnt.C), camPars.Speeds.Rapid, 0);
        camTpPoint.Points.Add(tpPnt9D3);
        pnt3D4 = new Pnt3D(pnt3D3.X, pnt3D3.Y, camPars.Distances.Safe);
      }
      for (int index2 = 0; index2 <= ((camOptions5) camPars.Operations).StepHeights.Count - 1; ++index2)
      {
        pnt3D3 = new Pnt3D(Pnt.X, Pnt.Y, ((camOptions5) camPars.Operations).StepHeights[index2]);
        camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z, 0.0, 0.0, Pnt.C), camPars.Speeds.Plunge, 1)
        {
          SimDevideLen = index2 != 0 ? (((camOptions5) camPars.Operations).StepHeights[index2 - 1] - ((camOptions5) camPars.Operations).StepHeights[index2]) / 4.0 : (((camOperation5) ((camOffset5) camPars).Drill).StartHeight - ((camOptions5) camPars.Operations).StepHeights[index2]) / 4.0
        });
        if (((camOperation5) ((camOffset5) camPars).Drill).PeckMode & index2 < ((camOptions5) camPars.Operations).StepHeights.Count - 1)
        {
          pnt3D3 = new Pnt3D(Pnt.X, Pnt.Y, ((camOptions5) camPars.Operations).StepHeights[index2] + ((camOperation5) ((camOffset5) camPars).Drill).PeckMinRetractDistance);
          if (((camOperation5) ((camOffset5) camPars).Drill).PeckFullRetract)
            pnt3D3.Z = ((camOperation5) ((camOffset5) camPars).Drill).StartHeight;
          TpPnt9D tpPnt9D4 = new TpPnt9D(new Pnt6D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z, 0.0, 0.0, Pnt.C), ((camSpeedsEnable) camPars.Speeds).Leave, 1);
          tpPnt9D4.SimDevideLen = (((TpArcData) tpPnt9D4).P9.Z - ((TpArcData) camTpPoint.Points[camTpPoint.Points.Count - 1]).P9.Z) / 4.0;
          camTpPoint.Points.Add(tpPnt9D4);
        }
      }
      buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(pnt3D4.X, pnt3D4.Y, ((camOperation5) ((camOffset5) camPars).Drill).StartHeight), new Point3D(pnt3D3.X, pnt3D3.Y, ((camOperation5) ((camOffset5) camPars).Drill).EndHeight));
      ((CustomData) buLineCam).set_MoveType(CamMoveType.G1);
      buLineCam.Color = Color.Red;
      ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
      CamCalculated.EntitiesG1.Add((Entity) buLineCam);
      buArcCam buArcCam = (buArcCam) new CustomData(new Point3D(pnt3D3.X, pnt3D3.Y, ((camOperation5) ((camOffset5) camPars).Drill).EndHeight), num2 / 2.0, 0.0, 2.0 * Math.PI);
      ((CustomData) buArcCam).set_MoveType(CamMoveType.Other);
      buArcCam.Color = Color.Red;
      ((CustomData) buArcCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
      CamCalculated.EntitiesOther.Add((Entity) buArcCam);
      pnt3D2 = new Pnt3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z);
      if (index1 < RefPoints.Count - 1)
      {
        Pnt3D pnt3D7 = new Pnt3D(Pnt);
        TpPnt9D tpPnt9D5 = !((camDrill5) camPars.Distances).RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D7.X, pnt3D7.Y, ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, Pnt.C), ((camSpeedsEnable) camPars.Speeds).Leave, 1) : new TpPnt9D(new Pnt6D(pnt3D7.X, pnt3D7.Y, ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, Pnt.C), camPars.Speeds.Rapid, 0);
        camTpPoint.Points.Add(tpPnt9D5);
        pnt3D2 = new Pnt3D(pnt3D7.X, pnt3D7.Y, ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid);
      }
      num1 = Pnt.C;
      if (index1 == RefPoints.Count - 1)
      {
        Pnt3D pnt3D8 = new Pnt3D(Pnt);
        camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(pnt3D8.X, pnt3D8.Y, camPars.Distances.Safe, 0.0, 0.0, Pnt.C), camPars.Speeds.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        pnt3D2 = new Pnt3D(pnt3D8.X, pnt3D8.Y, camPars.Distances.Safe);
      }
      this.SimPointCreatForDetailedPoints(camTpPoint.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
      if (camTpPoint.Points.Count > 0)
      {
        CamCalculated.CamPoints.Add(camTpPoint);
        camTpPoint = (camTpPoint) new TpPnt9D();
      }
    }
  }

  public void camDrillThenRotation(
    List<Pnt6D> RefPoints,
    ToolBase5 Tool,
    WorkPlane Plane,
    camParameters5 camPars,
    ref camTp CamCalculated)
  {
    CamCalculated.Name = "Point  ";
    camTpPoint camTpPoint1 = (camTpPoint) new TpPnt9D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    Pnt3D pnt3D1 = new Pnt3D();
    Pnt3D pnt3D2 = new Pnt3D();
    double num1 = 0.0;
    double num2 = ((ToolGeometry5) Tool).Geometry.Diameter;
    CamCalculated.TypeCam = CamType.Drill;
    if (((ToolGeometry5) Tool).Purpose == ToolPurpose.DiamondCut | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Saw)
      num2 = ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness;
    ((camOptions5) camPars.Operations).StepHeights.Add(camPars.Steps.EndValue);
    ((camOptions5) camPars.Operations).StepHeights.Clear();
    ((camOptions5) camPars.Operations).StepHeights.Add(camPars.Steps.EndValue);
    double num3 = 1.0;
    for (int index = 0; index <= RefPoints.Count - 1; ++index)
    {
      Pnt6D Pnt = new Pnt6D(RefPoints[index]);
      Pnt.C += camPars.Strategy.TangentOffset;
      if (camPars.Strategy.UseContantTangent)
        Pnt.C = camPars.Strategy.ContantTangent;
      if (!((camOperation5) ((camOffset5) camPars).Drill).IncremantalRotation)
        num3 = 1.0;
      if (index > 0)
      {
        double num4 = Pnt.C - num1;
        if (Math.Abs(num4) > 180.0)
        {
          if (num4 > 0.0)
            Pnt.C -= 360.0;
          else
            Pnt.C += 360.0;
        }
        if (Pnt.C > camPars.Strategy.MaxTangentValue)
        {
          if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue >= 360.0)
            Pnt.C -= 360.0;
          else
            Pnt.C -= camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
        }
        if (Pnt.C < camPars.Strategy.MinTangentValue)
        {
          if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue >= 360.0)
            Pnt.C += 360.0;
          else
            Pnt.C += camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
        }
      }
      Pnt3D pnt3D3;
      if (index == 0)
      {
        camTpPoint1 = (camTpPoint) new TpPnt9D();
        Pnt3D pnt3D4 = new Pnt3D(Pnt);
        camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D4.X, pnt3D4.Y, camPars.Distances.Safe), ((camSpeedsEnable) camPars.Speeds).Leave, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt3D pnt3D5 = new Pnt3D(Pnt);
        TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(pnt3D5.X, pnt3D5.Y, camPars.Distances.Safe, 0.0, 0.0, ((camOperation5) ((camOffset5) camPars).Drill).StartAngle * num3 + ((camOperation5) ((camOffset5) camPars).Drill).EndAngle * (num3 - 1.0)), camPars.Speeds.Rapid, 0);
        camTpPoint1.Points.Add(tpPnt9D2);
        pnt3D2 = new Pnt3D(pnt3D5.X, pnt3D5.Y, camPars.Distances.Safe);
        Pnt3D pnt3D6 = new Pnt3D(Pnt);
        camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D6.X, pnt3D6.Y, ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, ((camOperation5) ((camOffset5) camPars).Drill).StartAngle * num3 + ((camOperation5) ((camOffset5) camPars).Drill).EndAngle * (num3 - 1.0)), camPars.Speeds.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        pnt3D3 = new Pnt3D(pnt3D6.X, pnt3D6.Y, camPars.Distances.Safe);
      }
      else
      {
        Pnt3D pnt3D7 = new Pnt3D(Pnt);
        TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(pnt3D7.X, pnt3D7.Y, ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, ((camOperation5) ((camOffset5) camPars).Drill).StartAngle * num3 + ((camOperation5) ((camOffset5) camPars).Drill).EndAngle * (num3 - 1.0)), camPars.Speeds.Rapid, 0);
        camTpPoint1.Points.Add(tpPnt9D3);
        pnt3D3 = new Pnt3D(pnt3D7.X, pnt3D7.Y, camPars.Distances.Safe);
      }
      Pnt3D pnt3D8 = new Pnt3D(Pnt.X, Pnt.Y, ((camOperation5) ((camOffset5) camPars).Drill).EndHeight);
      TpPnt9D tpPnt9D4 = new TpPnt9D(new Pnt6D(pnt3D8.X, pnt3D8.Y, pnt3D8.Z, 0.0, 0.0, ((camOperation5) ((camOffset5) camPars).Drill).StartAngle * num3 + ((camOperation5) ((camOffset5) camPars).Drill).EndAngle * (num3 - 1.0)), camPars.Speeds.Plunge, 1);
      camTpPoint1.Points.Add(tpPnt9D4);
      Pnt3D pnt3D9 = new Pnt3D(Pnt.X, Pnt.Y, ((camOperation5) ((camOffset5) camPars).Drill).EndHeight);
      TpPnt9D tpPnt9D5 = new TpPnt9D(new Pnt6D(pnt3D9.X, pnt3D9.Y, pnt3D9.Z, 0.0, 0.0, ((camOperation5) ((camOffset5) camPars).Drill).EndAngle * num3), camPars.Speeds.Plunge, 1);
      camTpPoint1.Points.Add(tpPnt9D5);
      buLineCam buLineCam = (buLineCam) new CustomData(new Point3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z), new Point3D(pnt3D9.X, pnt3D9.Y, pnt3D9.Z));
      ((CustomData) buLineCam).set_MoveType(CamMoveType.G1);
      buLineCam.Color = Color.Red;
      ((CustomData) buLineCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
      CamCalculated.EntitiesG1.Add((Entity) buLineCam);
      buArcCam buArcCam = (buArcCam) new CustomData(new Point3D(pnt3D9.X, pnt3D9.Y, pnt3D9.Z), num2 / 2.0, 0.0, 2.0 * Math.PI);
      ((CustomData) buArcCam).set_MoveType(CamMoveType.Other);
      buArcCam.Color = Color.Red;
      ((CustomData) buArcCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
      CamCalculated.EntitiesOther.Add((Entity) buArcCam);
      Pnt3D pnt3D10 = new Pnt3D(pnt3D9.X, pnt3D9.Y, pnt3D9.Z);
      Pnt3D pnt3D11 = new Pnt3D(Pnt);
      TpPnt9D tpPnt9D6 = !((camDrill5) camPars.Distances).RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D11.X, pnt3D11.Y, pnt3D10.Z + ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, ((camOperation5) ((camOffset5) camPars).Drill).EndAngle * num3), ((camSpeedsEnable) camPars.Speeds).Leave, 1) : new TpPnt9D(new Pnt6D(pnt3D11.X, pnt3D11.Y, pnt3D10.Z + ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, ((camOperation5) ((camOffset5) camPars).Drill).EndAngle * num3), camPars.Speeds.Rapid, 0);
      camTpPoint1.Points.Add(tpPnt9D6);
      pnt3D2 = new Pnt3D(pnt3D11.X, pnt3D11.Y, ((camOperation5) ((camOffset5) camPars).Drill).StartHeight + ((camMaterial5) camPars.Distances).Rapid);
      num1 = Pnt.C;
      if (index == RefPoints.Count - 1)
      {
        Pnt3D pnt3D12 = new Pnt3D(Pnt);
        camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D12.X, pnt3D12.Y, camPars.Distances.Safe, 0.0, 0.0, Pnt.C), camPars.Speeds.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        pnt3D2 = new Pnt3D(pnt3D12.X, pnt3D12.Y, camPars.Distances.Safe);
      }
      ++num3;
    }
    this.SimPointCreatForDetailedPoints(camTpPoint1.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
    if (camTpPoint1.Points.Count <= 0)
      return;
    CamCalculated.CamPoints.Add(camTpPoint1);
    camTpPoint camTpPoint2 = (camTpPoint) new TpPnt9D();
  }

  public void camHatch(
    camParameters5 CamPars,
    KinematicBase Kinematic,
    ToolBase5 Tool,
    ref camTp calcCam,
    ref List<eEntities> Entities)
  {
    if (((camStrategy5) ((camOffset5) CamPars).Hatch).CutStep <= 0.0 || ((camStrategy5) ((camOffset5) CamPars).Hatch).XDirectionLength <= 0.0 || ((camStrategy5) ((camOffset5) CamPars).Hatch).YDirectionWidth <= 0.0)
      return;
    List<List<eEntities>> eEntitiesListList = new List<List<eEntities>>();
    Entities.Clear();
    if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingDirection == CamHatchCuttingDirection.XDirection)
    {
      int num1 = (int) buFile5.RoundToLower(((camStrategy5) ((camOffset5) CamPars).Hatch).YDirectionWidth / ((camStrategy5) ((camOffset5) CamPars).Hatch).CutStep);
      if (num1 == 0)
        num1 = 1;
      double num2 = ((camStrategy5) ((camOffset5) CamPars).Hatch).YDirectionWidth / (double) num1;
      Pnt3D Pnt = new Pnt3D();
      List<eEntities> eEntitiesList = new List<eEntities>();
      for (int index = 0; index <= num1; ++index)
      {
        if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingModes == CamHatchCuttingMode.Forward)
        {
          double num3 = (double) index * num2;
          eEntities eEntities = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + num3, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + ((camStrategy5) ((camOffset5) CamPars).Hatch).XDirectionLength, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + num3, CamPars.Operations.Height));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          eEntitiesListList.Add(eEntitiesList);
        }
        if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingModes == CamHatchCuttingMode.ForwardBackward)
        {
          eEntitiesList = new List<eEntities>();
          double num4 = (double) index * num2;
          eEntities eEntities1 = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + num4, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + ((camStrategy5) ((camOffset5) CamPars).Hatch).XDirectionLength, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + num4, CamPars.Operations.Height));
          Entities.Add(eEntities1);
          eEntitiesList.Add(eEntities1);
          eEntities eEntities2 = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + ((camStrategy5) ((camOffset5) CamPars).Hatch).XDirectionLength, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + num4, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + num4, CamPars.Operations.Height));
          Entities.Add(eEntities2);
          eEntitiesList.Add(eEntities2);
          eEntitiesListList.Add(eEntitiesList);
        }
        if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        {
          double y = (double) index * num2;
          eEntities eEntities = (eEntities) null;
          if (Entities.Count > 0)
          {
            eEntities = (eEntities) new eLine(new Pnt3D(Pnt), new Pnt3D(Pnt.X, y, CamPars.Operations.Height));
            Entities.Add(eEntities);
            eEntitiesList.Add(eEntities);
          }
          if (index % 2 == 0)
            eEntities = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + y, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + ((camStrategy5) ((camOffset5) CamPars).Hatch).XDirectionLength, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + y, CamPars.Operations.Height));
          if (index % 2 == 1)
            eEntities = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + ((camStrategy5) ((camOffset5) CamPars).Hatch).XDirectionLength, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + y, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + y, CamPars.Operations.Height));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Pnt = new Pnt3D(eEntities.Vertice[eEntities.Vertice.Count - 1]);
        }
      }
      if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        eEntitiesListList.Add(eEntitiesList);
    }
    if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingDirection != CamHatchCuttingDirection.YDirection)
      return;
    int num5 = (int) buFile5.RoundToLower(((camStrategy5) ((camOffset5) CamPars).Hatch).XDirectionLength / ((camStrategy5) ((camOffset5) CamPars).Hatch).CutStep);
    if (num5 == 0)
      num5 = 1;
    double num6 = ((camStrategy5) ((camOffset5) CamPars).Hatch).XDirectionLength / (double) num5;
    Pnt3D Pnt1 = new Pnt3D();
    List<eEntities> eEntitiesList1 = new List<eEntities>();
    for (int index = 0; index <= num5; ++index)
    {
      if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingModes == CamHatchCuttingMode.Forward)
      {
        eEntitiesList1 = new List<eEntities>();
        double num7 = (double) index * num6;
        eEntities eEntities = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + num7, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + num7, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + ((camStrategy5) ((camOffset5) CamPars).Hatch).YDirectionWidth, CamPars.Operations.Height));
        Entities.Add(eEntities);
        eEntitiesList1.Add(eEntities);
        eEntitiesListList.Add(eEntitiesList1);
      }
      if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingModes == CamHatchCuttingMode.ForwardBackward)
      {
        eEntitiesList1 = new List<eEntities>();
        double num8 = (double) index * num6;
        eEntities eEntities3 = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + num8, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + num8, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + ((camStrategy5) ((camOffset5) CamPars).Hatch).YDirectionWidth, CamPars.Operations.Height));
        Entities.Add(eEntities3);
        eEntitiesList1.Add(eEntities3);
        eEntities eEntities4 = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + num8, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + ((camStrategy5) ((camOffset5) CamPars).Hatch).YDirectionWidth, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + num8, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y, CamPars.Operations.Height));
        Entities.Add(eEntities4);
        eEntitiesList1.Add(eEntities4);
        eEntitiesListList.Add(eEntitiesList1);
      }
      if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
      {
        double x = (double) index * num6;
        eEntities eEntities = (eEntities) null;
        if (Entities.Count > 0)
        {
          eEntities = (eEntities) new eLine(new Pnt3D(Pnt1), new Pnt3D(x, Pnt1.Y, CamPars.Operations.Height));
          Entities.Add(eEntities);
          eEntitiesList1.Add(eEntities);
        }
        if (index % 2 == 0)
          eEntities = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + x, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + x, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + ((camStrategy5) ((camOffset5) CamPars).Hatch).YDirectionWidth, CamPars.Operations.Height));
        if (index % 2 == 1)
          eEntities = (eEntities) new eLine(new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + x, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y + ((camStrategy5) ((camOffset5) CamPars).Hatch).YDirectionWidth, CamPars.Operations.Height), new Pnt3D(((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.X + x, ((camStrategy5) ((camOffset5) CamPars).Hatch).CornerPoint.Y, CamPars.Operations.Height));
        Entities.Add(eEntities);
        eEntitiesList1.Add(eEntities);
        Pnt1 = new Pnt3D(eEntities.Vertice[eEntities.Vertice.Count - 1]);
      }
    }
    if (((camStrategy5) ((camOffset5) CamPars).Hatch).CuttingModes != CamHatchCuttingMode.ForwardNextBackward)
      return;
    eEntitiesListList.Add(eEntitiesList1);
  }

  public bool camQuilting(
    List<List<Entity>> SplitedRefEntities,
    bool TangentCalculaton,
    double HeadDistance,
    ToolBase5 Tool,
    camParameters5 camPars,
    ref camTp CamCalculated)
  {
    CamCalculated.Name = "Contour  ";
    List<List<Entity>> copiedEnt1 = new List<List<Entity>>();
    camTpPoint camTpPoint1 = (camTpPoint) new TpPnt9D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    Pnt3D pnt3D1 = new Pnt3D();
    Point3D Pnt1 = new Point3D();
    Point3D Pnt2 = new Point3D();
    int num1 = 0;
    double num2 = 0.0;
    double feed1 = camPars.Speeds.Feed;
    double plunge = camPars.Speeds.Plunge;
    double leave = ((camSpeedsEnable) camPars.Speeds).Leave;
    double rapid = camPars.Speeds.Rapid;
    CamCalculated.TypeCam = CamType.ContourOpenCenter;
    buVector5.CopyEntities(SplitedRefEntities, ref copiedEnt1);
    double num3 = !camPars.Steps.Enable ? camPars.Operations.Height : camPars.Steps.StartValue;
    int num4 = -1;
    for (int index1 = 0; index1 <= copiedEnt1.Count - 1; ++index1)
    {
      bool flag1 = false;
      ((F_AnalyseResult) buCall.\u0001).isEntitiesClosed(copiedEnt1[index1]);
      double z = 0.0;
      List<Point3D> points = new List<Point3D>();
      List<Entity> copiedEnt2 = new List<Entity>();
      buVector5.CopyEntities(copiedEnt1[index1], ref copiedEnt2);
      double Length = 0.0;
      buCall.\u0001.EntitiesLength(copiedEnt2, ref Length);
      double num5;
      if (((CutterIsoFileItems) copiedEnt2[0].EntityData).get_sortDirection() == entitySortDirection.Normal)
      {
        num5 = buString5.RadianToDegree(((ICurve) copiedEnt2[0]).StartTangent.AngleInXY);
        if (num5 < 0.0)
          num5 += 360.0;
        if (num5 >= 360.0)
          num5 -= 360.0;
      }
      else
      {
        num5 = buString5.RadianToDegree(((ICurve) copiedEnt2[0]).EndTangent.AngleInXY) + 180.0;
        if (num5 < 0.0)
          num5 += 360.0;
        if (num5 >= 360.0)
          num5 -= 360.0;
      }
      double num6 = 0.0;
      if (((F_AnalyseResult) buCall.\u0001).isEntitiesClosed(copiedEnt2))
      {
        if (((camStep5) camPars.Offsets).OverlapDistance > 0.0 & copiedEnt2.Count > 0)
        {
          Entity addedEntity = (Entity) null;
          buCall.\u0001.LineFromEntityEndPoint(copiedEnt2[copiedEnt2.Count - 1], ((camStep5) camPars.Offsets).OverlapDistance, ref addedEntity);
          if (addedEntity != null)
          {
            addedEntity.EntityData = (object) new ClipperOffset((CustomData) copiedEnt2[copiedEnt2.Count - 1].EntityData);
            ((CutterRuntimeSettings) addedEntity.EntityData).set_sortDirection(entitySortDirection.Normal);
            copiedEnt2.Add(addedEntity);
          }
        }
      }
      else if (((camRotary5) camPars.Options).ExtendPatternOutput > 0.0 & copiedEnt2.Count > 0)
      {
        Entity addedEntity = (Entity) null;
        buCall.\u0001.LineFromEntityEndPoint(copiedEnt2[copiedEnt2.Count - 1], ((camRotary5) camPars.Options).ExtendPatternOutput, ref addedEntity);
        if (addedEntity != null)
        {
          addedEntity.EntityData = (object) new ClipperOffset((CustomData) copiedEnt2[copiedEnt2.Count - 1].EntityData);
          ((CutterRuntimeSettings) addedEntity.EntityData).set_sortDirection(entitySortDirection.Normal);
          copiedEnt2.Add(addedEntity);
        }
      }
      for (int index2 = 0; index2 <= copiedEnt2.Count - 1; ++index2)
      {
        Pnt6D pnt6D = new Pnt6D();
        Entity entity = copiedEnt2[index2];
        int num7 = 0;
        if (((ClipperOffset) copiedEnt2[index2].EntityData).get_Tags().Length > 0 && buFile5.IsNumeric(((ClipperOffset) copiedEnt2[index2].EntityData).get_Tags()))
          num7 = Convert.ToInt32(((ClipperOffset) copiedEnt2[index2].EntityData).get_Tags());
        List<Point3D> point3DList = new List<Point3D>();
        bool flag2 = false;
        double num8 = camPars.Distances.Safe;
        if (index2 == copiedEnt2.Count - 1)
        {
          if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
          {
            num6 = buString5.RadianToDegree(((ICurve) entity).EndTangent.AngleInXY) + 180.0;
            if (num6 < 0.0)
              num6 += 360.0;
            if (num6 >= 360.0)
              num6 -= 360.0;
          }
          if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Reverse)
          {
            num6 = buString5.RadianToDegree(((ICurve) entity).StartTangent.AngleInXY);
            if (num6 < 0.0)
              num6 += 360.0;
            if (num6 >= 360.0)
              num6 -= 360.0;
          }
        }
        double feed2 = camPars.Speeds.Feed;
        double num9 = camPars.Speeds.Plunge;
        double num10 = ((camSpeedsEnable) camPars.Speeds).Leave;
        double feed3 = camPars.Speeds.Rapid;
        if (camPars.Options.FeedFromEntityFeedrate && ((buCutterCalc) copiedEnt2[index2].EntityData).get_CamFeedrate() > 0.0)
        {
          feed2 = ((buCutterCalc) copiedEnt2[index2].EntityData).get_CamFeedrate();
          num9 = ((buCutterCalc) copiedEnt2[index2].EntityData).get_CamFeedrate();
          num10 = ((buCutterCalc) copiedEnt2[index2].EntityData).get_CamFeedrate();
          feed3 = ((buCutterCalc) copiedEnt2[index2].EntityData).get_CamFeedrate();
        }
        if (entity is ICurve)
        {
          F_CutterOffsetEntities.VerticeToPointsList(entity.Vertices, ref point3DList);
          buCall.\u0001.SetValueToPointList(0.0, 0.0, z, false, false, true, ref point3DList);
          if (entity is Line)
          {
            if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
            }
            else
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
              point3DList.Reverse();
            }
          }
          else if (entity is Arc)
          {
            flag2 = true;
            if (TangentCalculaton)
              flag2 = false;
            if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
            }
            else
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
              point3DList.Reverse();
            }
          }
          else if (entity is LinearPath)
          {
            if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
            }
            else
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
              point3DList.Reverse();
            }
          }
          else if (entity is Curve)
          {
            if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
            }
            else
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
              point3DList.Reverse();
            }
          }
          else if (entity is Ellipse)
          {
            if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
            }
            else
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
              point3DList.Reverse();
            }
          }
          else if (entity.GetType() == typeof (EllipticalArc))
          {
            if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
            }
            else
            {
              if (index2 == 0)
                Pnt1 = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
              point3DList.Reverse();
            }
          }
        }
        if (index1 == 0 & index2 == 0)
        {
          num8 = camPars.Distances.Safe;
        }
        else
        {
          double num11 = num3 + ((camMaterial5) camPars.Distances).Rapid;
          if (index1 > 0 & index2 == 0 & camTpPoint1.Points.Count > 0 && num11 < ((TpArcData) camTpPoint1.Points[camTpPoint1.Points.Count - 1]).P9.Z)
            num8 = ((TpArcData) camTpPoint1.Points[camTpPoint1.Points.Count - 1]).P9.Z;
        }
        double RefAngle = buCall.\u0001.PointAngle(point3DList[1], point3DList[0], Plane.XY) + camPars.Strategy.TangentOffset;
        if (buConversion5.EQ(RefAngle, 0.0) && num2 > 180.0)
          RefAngle = 360.0;
        if (num1 > 0)
          ((MachineOtherCodeInfo) buCall.\u0001).CamTangentCalculation(ref RefAngle, num2, camPars);
        else
          num2 = RefAngle;
        if (flag1 && buConversion5.EQ(Math.Abs(RefAngle - num2), 0.0) | buConversion5.EQ(Math.Abs(RefAngle - num2), 180.0))
          RefAngle = num2;
        if (camPars.Strategy.UseContantTangent)
        {
          RefAngle = camPars.Strategy.ContantTangent;
          num2 = camPars.Strategy.ContantTangent;
        }
        if (index1 == 0 & index2 == 0)
        {
          points.Add(F_NotchEdit.ToPoint3D(Pnt1));
          Pnt6D Pnt3 = new Pnt6D(Pnt1.X, Pnt1.Y, Pnt1.Z, 0.0, 0.0, RefAngle);
          Pnt3D pnt3D2 = new Pnt3D(Pnt3);
          camTpPoint1.Points.Add(new TpPnt9D(new Pnt6D(pnt3D2.X, pnt3D2.Y, z, 0.0, 0.0, Pnt3.C), feed3, 0)
          {
            PreCodes = {
              (object) ("M40 K" + HeadDistance.ToString("f2"))
            },
            AfterCodes = {
              (object) ("M50 K" + num7.ToString()),
              (object) "M60",
              (object) ("M70 K" + num5.ToString("f2"))
            }
          });
          num4 = num7;
        }
        if (index2 > 0 & TangentCalculaton && Math.Abs(RefAngle - num2) > camPars.Strategy.AngleLimit & camPars.Strategy.UseTangentLimit)
        {
          TpPnt9D tpPnt9D2 = new TpPnt9D();
          ((TpArcData) tpPnt9D2).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, num2);
          tpPnt9D2.Type = 1;
          tpPnt9D2.Feed = num10;
          tpPnt9D2.PlungeAxisMovement = true;
          tpPnt9D2.PlungeAction = CamPlungeActionType.GoUp;
          camTpPoint1.Points.Add(tpPnt9D2);
          buLineCam buLineCam1 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid));
          ((CustomData) buLineCam1).set_MoveType(CamMoveType.Leave);
          buLineCam1.Color = Color.Blue;
          ((CustomData) buLineCam1).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
          CamCalculated.EntitiesLeave.Add((Entity) buLineCam1);
          TpPnt9D tpPnt9D3 = new TpPnt9D();
          ((TpArcData) tpPnt9D3).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, RefAngle);
          tpPnt9D3.Type = 0;
          tpPnt9D3.Feed = feed3;
          tpPnt9D3.PlungeAxisMovement = false;
          camTpPoint1.Points.Add(tpPnt9D3);
          TpPnt9D tpPnt9D4 = new TpPnt9D();
          ((TpArcData) tpPnt9D4).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z, 0.0, 0.0, RefAngle);
          tpPnt9D4.Type = 1;
          tpPnt9D4.Feed = num9;
          tpPnt9D4.PlungeAxisMovement = true;
          tpPnt9D4.PlungeAction = CamPlungeActionType.GoDownAproach;
          camTpPoint1.Points.Add(tpPnt9D4);
          buLineCam buLineCam2 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
          ((CustomData) buLineCam2).set_MoveType(CamMoveType.Plunge);
          buLineCam2.Color = Color.Green;
          ((CustomData) buLineCam2).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
          CamCalculated.EntitiesPlunge.Add((Entity) buLineCam2);
        }
        int num12 = 0;
        if (camTpPoint1.Points.Count > 0)
        {
          Pnt3D pnt3D3 = new Pnt3D(((TpArcData) camTpPoint1.Points[camTpPoint1.Points.Count - 1]).P9.X, ((TpArcData) camTpPoint1.Points[camTpPoint1.Points.Count - 1]).P9.Y);
          if (buConversion5.EQ(pnt3D3.X, point3DList[0].X, 0.001) & buConversion5.EQ(pnt3D3.Y, point3DList[0].Y, 0.001))
            num12 = 1;
        }
        if (!flag2)
        {
          for (int index3 = num12; index3 <= point3DList.Count - 1; ++index3)
          {
            RefAngle = (index3 != 0 ? buCall.\u0001.PointAngle(point3DList[index3], point3DList[index3 - 1], Plane.XY) : buCall.\u0001.PointAngle(point3DList[index3 + 1], point3DList[index3], Plane.XY)) + camPars.Strategy.TangentOffset;
            if (buConversion5.EQ(RefAngle, 0.0) && num2 > 180.0)
              RefAngle = 360.0;
            ((MachineOtherCodeInfo) buCall.\u0001).CamTangentCalculation(ref RefAngle, num2, camPars);
            if (flag1 && buConversion5.EQ(Math.Abs(RefAngle - num2), 0.0) | buConversion5.EQ(Math.Abs(RefAngle - num2), 180.0))
              RefAngle = num2;
            if (camPars.Strategy.UseContantTangent)
              RefAngle = camPars.Strategy.ContantTangent;
            double num13 = RefAngle - num2;
            if (TangentCalculaton & index3 > 1 && Math.Abs(num13) > camPars.Strategy.AngleLimit & camPars.Strategy.UseTangentLimit)
            {
              TpPnt9D tpPnt9D5 = new TpPnt9D();
              ((TpArcData) tpPnt9D5).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, num2);
              tpPnt9D5.Type = 1;
              tpPnt9D5.Feed = num10;
              tpPnt9D5.PlungeAxisMovement = true;
              tpPnt9D5.PlungeAction = CamPlungeActionType.GoUp;
              camTpPoint1.Points.Add(tpPnt9D5);
              buLineCam buLineCam3 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid));
              ((CustomData) buLineCam3).set_MoveType(CamMoveType.Leave);
              buLineCam3.Color = Color.Blue;
              ((CustomData) buLineCam3).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
              CamCalculated.EntitiesLeave.Add((Entity) buLineCam3);
              TpPnt9D tpPnt9D6 = new TpPnt9D();
              ((TpArcData) tpPnt9D6).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid, 0.0, 0.0, RefAngle);
              tpPnt9D6.Type = 0;
              tpPnt9D6.Feed = feed3;
              tpPnt9D6.PlungeAxisMovement = false;
              camTpPoint1.Points.Add(tpPnt9D6);
              TpPnt9D tpPnt9D7 = new TpPnt9D();
              ((TpArcData) tpPnt9D7).P9 = new Pnt9D(Pnt2.X, Pnt2.Y, Pnt2.Z, 0.0, 0.0, RefAngle);
              tpPnt9D7.Type = 1;
              tpPnt9D7.Feed = num9;
              tpPnt9D7.PlungeAxisMovement = true;
              tpPnt9D7.PlungeAction = CamPlungeActionType.GoDownAproach;
              camTpPoint1.Points.Add(tpPnt9D7);
              buLineCam buLineCam4 = (buLineCam) new CustomData(new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z + ((camMaterial5) camPars.Distances).Rapid), new Point3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
              ((CustomData) buLineCam4).set_MoveType(CamMoveType.Plunge);
              buLineCam4.Color = Color.Green;
              ((CustomData) buLineCam4).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
              CamCalculated.EntitiesPlunge.Add((Entity) buLineCam4);
            }
            int type = 1;
            if (index3 == 0)
              type = 0;
            Pnt6D Pnt4 = new Pnt6D(point3DList[index3].X, point3DList[index3].Y, point3DList[index3].Z, 0.0, 0.0, RefAngle);
            Pnt3D pnt3D4 = new Pnt3D(Pnt4);
            TpPnt9D tpPnt9D8 = new TpPnt9D(new Pnt6D(pnt3D4.X, pnt3D4.Y, z, 0.0, 0.0, Pnt4.C), feed2, type);
            if (num7 != num4)
              tpPnt9D8.AfterCodes.Add((object) ("M50 K" + num7.ToString()));
            if (index3 == 0)
            {
              tpPnt9D8.AfterCodes.Add((object) "M60");
              tpPnt9D8.AfterCodes.Add((object) ("M70 K" + num5.ToString("f2")));
            }
            if (index2 == 0 & index3 == 1)
              tpPnt9D8.PreCodes.Add((object) ("M80 K" + Length.ToString("f2")));
            camTpPoint1.Points.Add(tpPnt9D8);
            Pnt2 = new Point3D(pnt3D4.X, pnt3D4.Y, z);
            points.Add(F_NotchEdit.ToPoint3D(Pnt2));
            num2 = RefAngle;
          }
        }
        else
        {
          if (camTpPoint1.Points.Count > 0)
          {
            bool flag3 = false;
            Pnt3D pnt3D5 = new Pnt3D(((TpArcData) camTpPoint1.Points[camTpPoint1.Points.Count - 1]).P9.X, ((TpArcData) camTpPoint1.Points[camTpPoint1.Points.Count - 1]).P9.Y);
            if (buConversion5.EQ(pnt3D5.X, ((ICurve) entity).StartPoint.X, 0.001) & buConversion5.EQ(pnt3D5.Y, ((ICurve) entity).StartPoint.Y, 0.001))
              flag3 = true;
            if (buConversion5.EQ(pnt3D5.X, ((ICurve) entity).EndPoint.X, 0.001) & buConversion5.EQ(pnt3D5.Y, ((ICurve) entity).EndPoint.Y, 0.001))
              flag3 = true;
            if (!flag3)
            {
              Pnt6D Pnt5 = new Pnt6D(((ICurve) entity).StartPoint.X, ((ICurve) entity).StartPoint.Y, z);
              if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Reverse)
                Pnt5 = new Pnt6D(((ICurve) entity).EndPoint.X, ((ICurve) entity).EndPoint.Y, z);
              Pnt3D pnt3D6 = new Pnt3D(Pnt5);
              TpPnt9D tpPnt9D9 = new TpPnt9D(new Pnt6D(pnt3D6.X, pnt3D6.Y, z, 0.0, 0.0, Pnt5.C), feed3, 0);
              if (num7 != num4)
                tpPnt9D9.AfterCodes.Add((object) ("M50 K" + num7.ToString()));
              tpPnt9D9.AfterCodes.Add((object) "M60");
              tpPnt9D9.AfterCodes.Add((object) ("M70 K" + num5.ToString("f2")));
              camTpPoint1.Points.Add(tpPnt9D9);
            }
          }
          Pnt3D pnt3D7;
          TpPnt9D tpPnt9D10;
          if (((CutterIsoFileItems) entity.EntityData).get_sortDirection() == entitySortDirection.Normal)
          {
            Pnt6D Pnt6 = new Pnt6D(((ICurve) entity).EndPoint.X, ((ICurve) entity).EndPoint.Y, z);
            pnt3D7 = new Pnt3D(Pnt6);
            if (((PlanarEntity) entity).Plane.Equation.Z > 0.0)
            {
              tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D7.X, pnt3D7.Y, z, 0.0, 0.0, Pnt6.C), feed2, 3);
              tpPnt9D10.ArcType = 3;
            }
            else
            {
              tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D7.X, pnt3D7.Y, z, 0.0, 0.0, Pnt6.C), feed2, 2);
              tpPnt9D10.ArcType = 2;
            }
            tpPnt9D10.Radius = ((Circle) entity).Radius;
          }
          else
          {
            Pnt6D Pnt7 = new Pnt6D(((ICurve) entity).StartPoint.X, ((ICurve) entity).StartPoint.Y, z);
            pnt3D7 = new Pnt3D(Pnt7);
            if (((PlanarEntity) entity).Plane.Equation.Z > 0.0)
            {
              tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D7.X, pnt3D7.Y, z, 0.0, 0.0, Pnt7.C), feed2, 2);
              tpPnt9D10.ArcType = 2;
            }
            else
            {
              tpPnt9D10 = new TpPnt9D(new Pnt6D(pnt3D7.X, pnt3D7.Y, z, 0.0, 0.0, Pnt7.C), feed2, 3);
              tpPnt9D10.ArcType = 3;
            }
            tpPnt9D10.Radius = ((Circle) entity).Radius;
          }
          if (((PlanarEntity) entity).Plane.Equation.Z > 0.0)
          {
            tpPnt9D10.ArcData.StartPoint = new Point3D(((Circle) entity).StartPoint.X, ((Circle) entity).StartPoint.Y, z);
            tpPnt9D10.ArcData.EndPoint = new Point3D(((Circle) entity).EndPoint.X, ((Circle) entity).EndPoint.Y, z);
          }
          else
          {
            tpPnt9D10.ArcData.EndPoint = new Point3D(((Circle) entity).StartPoint.X, ((Circle) entity).StartPoint.Y, z);
            tpPnt9D10.ArcData.StartPoint = new Point3D(((Circle) entity).EndPoint.X, ((Circle) entity).EndPoint.Y, z);
          }
          tpPnt9D10.ArcData.CenterPoint = new Point3D(((Circle) entity).Center.X, ((Circle) entity).Center.Y, z);
          ((SimulationTp) tpPnt9D10.ArcData).SweepAngle = ((Arc) entity).AngleInDegrees;
          ((SimulationTp) tpPnt9D10.ArcData).Radius = ((Circle) entity).Radius;
          ((SimulationTp) tpPnt9D10.ArcData).Length = ((Circle) entity).Length();
          ((SimulationTp) tpPnt9D10.ArcData).StartAngle = buCall.\u0001.PointAngle(tpPnt9D10.ArcData.StartPoint, tpPnt9D10.ArcData.CenterPoint, Plane.XY);
          ((SimulationTp) tpPnt9D10.ArcData).EndAngle = buCall.\u0001.PointAngle(tpPnt9D10.ArcData.EndPoint, tpPnt9D10.ArcData.CenterPoint, Plane.XY);
          if (((SimulationTp) tpPnt9D10.ArcData).StartAngle > ((SimulationTp) tpPnt9D10.ArcData).EndAngle)
          {
            TpArcData arcData = tpPnt9D10.ArcData;
            ((SimulationTp) arcData).EndAngle = ((SimulationTp) arcData).EndAngle + 360.0;
          }
          if (index2 == 0)
            tpPnt9D10.PreCodes.Add((object) ("M80 K" + Length.ToString("f2")));
          camTpPoint1.Points.Add(tpPnt9D10);
          Pnt2 = new Point3D(pnt3D7.X, pnt3D7.Y, z);
          for (int index4 = 1; index4 <= point3DList.Count - 1; ++index4)
            points.Add(new Point3D(point3DList[index4].X, point3DList[index4].Y, z));
        }
        if (index2 == copiedEnt2.Count - 1 && camTpPoint1.Points.Count > 0)
        {
          camTpPoint1.Points[camTpPoint1.Points.Count - 1].AfterCodes.Add((object) ("M71 K" + num6.ToString("f2")));
          camTpPoint1.Points[camTpPoint1.Points.Count - 1].AfterCodes.Add((object) "M61");
        }
        flag1 = false;
        num4 = num7;
        num2 = RefAngle;
        ++num1;
      }
      buLinearPathCam buLinearPathCam = (buLinearPathCam) new CustomData(points);
      ((CustomData) buLinearPathCam).set_MoveType(CamMoveType.G1);
      buLinearPathCam.Color = Color.Red;
      ((CustomData) buLinearPathCam).set_CamID(((camOffset5) ((camOffset5) camPars).Runtime).CamID);
      CamCalculated.EntitiesG1.Add((Entity) buLinearPathCam);
    }
    this.SimPointCreatForDetailedPoints(camTpPoint1.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
    if (camTpPoint1.Points.Count > 0)
    {
      CamCalculated.Tool = (ToolBase5) new ToolGeometry5(Tool);
      CamCalculated.CamPoints.Add(camTpPoint1);
      camTpPoint camTpPoint2 = (camTpPoint) new TpPnt9D();
    }
    return true;
  }

  public void SimPointCreatForDetailedPoints(
    List<TpPnt9D> Points,
    double G0DevideRatio,
    double G1DevideRatio,
    double PointFilterLength,
    double CircularFilterLen,
    ref SimulationTp simulation)
  {
    this.SimPointCreatForDetailedPoints(Points, G0DevideRatio, G1DevideRatio, PointFilterLength, CircularFilterLen, new Pnt9D(), ref simulation);
  }

  public void SimPointCreatForDetailedPoints(
    List<TpPnt9D> Points,
    double G0DevideRatio,
    double G1DevideRatio,
    double PointFilterLength,
    double CircularFilterLen,
    Pnt9D Offsets,
    ref SimulationTp simulation)
  {
    if (G0DevideRatio <= 0.0)
      G0DevideRatio = 0.25;
    if (G1DevideRatio <= 0.0)
      G1DevideRatio = 0.1;
    int num1 = 1;
    if (Points.Count <= 0)
      return;
    if (Points[0].PlungeAxisMovement)
      num1 = 2;
    if (Points.Count > 0 & num1 <= Points.Count)
    {
      Pnt6DSimMove pnt6DsimMove = (Pnt6DSimMove) new PointsList(((TpArcData) Points[num1 - 1]).P9.X + Offsets.X, ((TpArcData) Points[num1 - 1]).P9.Y + Offsets.Y, ((TpArcData) Points[num1 - 1]).P9.Z + Offsets.Z, ((TpArcData) Points[num1 - 1]).P9.A + Offsets.A, ((TpArcData) Points[num1 - 1]).P9.B + Offsets.B, ((TpArcData) Points[num1 - 1]).P9.C + Offsets.C, Points[num1 - 1].Feed, Points[num1 - 1].ToolNo, Points[num1 - 1].SpindleSpeed, new Pnt3D(), -1, Points[num1 - 1].ToolName);
      ((camParameters5) simulation).SimMove.Add(pnt6DsimMove);
    }
    for (int index1 = num1; index1 <= Points.Count - 1; ++index1)
    {
      List<Pnt6DSimMove> Vertices1 = new List<Pnt6DSimMove>();
      if (Points[index1].Type == 0)
        ;
      if (Points[index1].Type == 0 | Points[index1].Type == 1)
      {
        double num2 = 0.0;
        double num3 = buCall.\u0001.Length3D(new Pnt3D(((TpArcData) Points[index1 - 1]).P9.X, ((TpArcData) Points[index1 - 1]).P9.Y, ((TpArcData) Points[index1 - 1]).P9.Z), new Pnt3D(((TpArcData) Points[index1]).P9.X, ((TpArcData) Points[index1]).P9.Y, ((TpArcData) Points[index1]).P9.Z));
        if (num3 == 0.0)
        {
          num3 = buCall.\u0001.Length6D(new Pnt6D(((TpArcData) Points[index1 - 1]).P9.X, ((TpArcData) Points[index1 - 1]).P9.Y, ((TpArcData) Points[index1 - 1]).P9.Z, ((TpArcData) Points[index1 - 1]).P9.A, ((TpArcData) Points[index1 - 1]).P9.B, ((TpArcData) Points[index1 - 1]).P9.C), new Pnt6D(((TpArcData) Points[index1]).P9.X, ((TpArcData) Points[index1]).P9.Y, ((TpArcData) Points[index1]).P9.Z, ((TpArcData) Points[index1]).P9.A, ((TpArcData) Points[index1]).P9.B, ((TpArcData) Points[index1]).P9.C));
          num2 = num3;
        }
        double Length = PointFilterLength;
        if (Points[index1].SimDevideLen > 0.0)
          Length = Points[index1].SimDevideLen;
        if (num3 > Length)
        {
          Pnt6DSimMove StartPoint = (Pnt6DSimMove) new PointAndIndex(((TpArcData) Points[index1 - 1]).P9.X, ((TpArcData) Points[index1 - 1]).P9.Y, ((TpArcData) Points[index1 - 1]).P9.Z, ((TpArcData) Points[index1 - 1]).P9.A, ((TpArcData) Points[index1 - 1]).P9.B, ((TpArcData) Points[index1 - 1]).P9.C);
          ((MeshToSurfacePointsSettings) StartPoint).FeedRate = Points[index1 - 1].Feed;
          ((MeshToSurfacePointsCalculations) StartPoint).SpindleRpm = Points[index1 - 1].SpindleSpeed;
          ((MeshToSurfacePointsCalculations) StartPoint).ToolNo = Points[index1 - 1].ToolNo;
          Pnt6DSimMove EndPoint = (Pnt6DSimMove) new PointAndIndex(((TpArcData) Points[index1]).P9.X, ((TpArcData) Points[index1]).P9.Y, ((TpArcData) Points[index1]).P9.Z, ((TpArcData) Points[index1]).P9.A, ((TpArcData) Points[index1]).P9.B, ((TpArcData) Points[index1]).P9.C);
          ((MeshToSurfacePointsSettings) EndPoint).FeedRate = Points[index1].Feed;
          ((MeshToSurfacePointsCalculations) EndPoint).SpindleRpm = Points[index1].SpindleSpeed;
          ((MeshToSurfacePointsCalculations) EndPoint).ToolNo = Points[index1].ToolNo;
          if (num2 > 0.0 && CircularFilterLen > 0.0)
            Length = CircularFilterLen;
          ((MachineMCodeInfo) buCall.\u0001).LineToLineer(StartPoint, EndPoint, Length, ref Vertices1);
          Vertices1.RemoveAt(0);
          for (int index2 = 0; index2 <= Vertices1.Count - 1; ++index2)
          {
            Pnt6DSimMove pnt6DsimMove = (Pnt6DSimMove) new PointAndIndex(((MeshToSurfacePointsSettings) Vertices1[index2]).X + Offsets.X, ((MeshToSurfacePointsSettings) Vertices1[index2]).Y + Offsets.Y, ((MeshToSurfacePointsSettings) Vertices1[index2]).Z + Offsets.Z, ((MeshToSurfacePointsSettings) Vertices1[index2]).A + Offsets.A, ((MeshToSurfacePointsSettings) Vertices1[index2]).B + Offsets.B, ((MeshToSurfacePointsSettings) Vertices1[index2]).C + Offsets.C, ((MeshToSurfacePointsSettings) Vertices1[index2]).FeedRate, ((MeshToSurfacePointsCalculations) Vertices1[index2]).ToolNo, ((MeshToSurfacePointsCalculations) Vertices1[index2]).SpindleRpm, new Pnt3D());
            ((camParameters5) simulation).SimMove.Add(pnt6DsimMove);
          }
        }
        else
        {
          Pnt6DSimMove pnt6DsimMove = (Pnt6DSimMove) new PointAndIndex(((TpArcData) Points[index1]).P9.X + Offsets.X, ((TpArcData) Points[index1]).P9.Y + Offsets.Y, ((TpArcData) Points[index1]).P9.Z + Offsets.Z, ((TpArcData) Points[index1]).P9.A + Offsets.A, ((TpArcData) Points[index1]).P9.B + Offsets.B, ((TpArcData) Points[index1]).P9.C + Offsets.C, Points[index1].Feed, Points[index1].ToolNo, Points[index1].SpindleSpeed, new Pnt3D());
          ((camParameters5) simulation).SimMove.Add(pnt6DsimMove);
        }
      }
      if (Points[index1].Type == 2 | Points[index1].Type == 3)
      {
        List<Pnt3D> Vertices2 = new List<Pnt3D>();
        if (Points[index1].ArcData != null)
        {
          double Length = PointFilterLength;
          if (Points[index1].SimDevideLen > 0.0)
            Length = Points[index1].SimDevideLen;
          if (Length > ((SimulationTp) Points[index1].ArcData).Length / 2.0)
            Length = ((SimulationTp) Points[index1].ArcData).Length / 2.0;
          if (!((camParameters5) Points[index1].ArcData).isCW)
          {
            ((MachineMCodeInfo) buCall.\u0001).ArcToLineer(buString5.Point3DToPnt3D(Points[index1].ArcData.CenterPoint), ((SimulationTp) Points[index1].ArcData).Radius, ((SimulationTp) Points[index1].ArcData).StartAngle, ((SimulationTp) Points[index1].ArcData).EndAngle, Length, new WorkPlane(), ref Vertices2);
          }
          else
          {
            ((MachineMCodeInfo) buCall.\u0001).ArcToLineer(buString5.Point3DToPnt3D(Points[index1].ArcData.CenterPoint), ((SimulationTp) Points[index1].ArcData).Radius, ((SimulationTp) Points[index1].ArcData).EndAngle, ((SimulationTp) Points[index1].ArcData).StartAngle, Length, new WorkPlane(), ref Vertices2);
            Vertices2.Reverse();
          }
          if (Points[index1].Type == 2)
            Vertices2.Reverse();
          if (Vertices2.Count > 0)
          {
            for (int index3 = 1; index3 <= Vertices2.Count - 1; ++index3)
            {
              Pnt6DSimMove pnt6DsimMove = (Pnt6DSimMove) new PointAndIndex(Vertices2[index3].X + Offsets.X, Vertices2[index3].Y + Offsets.Y, Vertices2[index3].Z + Offsets.Z, Offsets.A, Offsets.B, Offsets.C, Points[index1].Feed, Points[index1].ToolNo, Points[index1].SpindleSpeed, new Pnt3D());
              ((camParameters5) simulation).SimMove.Add(pnt6DsimMove);
            }
          }
        }
      }
    }
  }

  public void CamStepCalculation(camStep5 Steps, ref List<double> CalcValues)
  {
    try
    {
      CalcValues.Clear();
      if (!Steps.Enable)
        return;
      if (((camSpeeds5) Steps).StepType == CamStepType.StartByCountAndStep & ((camSpeeds5) Steps).Step != 0.0 & ((camSpeeds5) Steps).Count > 0)
      {
        for (int index = 1; index <= ((camSpeeds5) Steps).Count; ++index)
        {
          double num = Steps.StartValue + ((camSpeeds5) Steps).Step * (double) index;
          CalcValues.Add(Math.Round(num, 5));
        }
      }
      if (((camSpeeds5) Steps).StepType == CamStepType.StartToEndByStep & ((camSpeeds5) Steps).Step != 0.0)
      {
        double num1 = Steps.EndValue - Steps.StartValue;
        double num2 = 1.0;
        if (Steps.EndValue < Steps.StartValue)
          num2 = -1.0;
        int int32 = Convert.ToInt32(buNumeric.RoundToLower(Math.Abs(num1) / Math.Abs(((camSpeeds5) Steps).Step)));
        double step = ((camSpeeds5) Steps).Step;
        if (step != 0.0)
        {
          double num3 = 0.0;
          for (int index = 1; index <= int32; ++index)
          {
            double num4 = Steps.StartValue + num2 * Math.Abs(step) * (double) index;
            CalcValues.Add(Math.Round(num4, 5));
            num3 = num4;
          }
          if (CalcValues.Count > 0 && !buCompare.EQ(num3, Steps.EndValue, 0.001))
            CalcValues.Add(Steps.EndValue);
        }
      }
      if (((camSpeeds5) Steps).StepType == CamStepType.StartToEndByCount & ((camSpeeds5) Steps).Count > 0)
      {
        double num5 = Steps.EndValue - Steps.StartValue;
        double num6 = 1.0;
        if (Steps.EndValue < Steps.StartValue)
          num6 = -1.0;
        double num7 = Convert.ToDouble(Math.Abs(num5) / (double) ((camSpeeds5) Steps).Count);
        if (num7 != 0.0)
        {
          for (int index = 1; index <= ((camSpeeds5) Steps).Count; ++index)
          {
            double num8 = Steps.StartValue + num6 * Math.Abs(num7) * (double) index;
            CalcValues.Add(num8);
          }
        }
      }
      if (((camSpeeds5) Steps).StepType == CamStepType.StartToDistanceByCount & ((camSpeeds5) Steps).Count > 0)
      {
        double num9 = Steps.StartValue + Steps.Distance;
        double num10 = num9 - Steps.StartValue;
        double num11 = 1.0;
        if (num9 < Steps.StartValue)
          num11 = -1.0;
        double num12 = Convert.ToDouble(Math.Abs(num10) / (double) ((camSpeeds5) Steps).Count);
        if (num12 != 0.0)
        {
          for (int index = 1; index <= ((camSpeeds5) Steps).Count; ++index)
          {
            double num13 = Steps.StartValue + num11 * Math.Abs(num12) * (double) index;
            CalcValues.Add(num13);
          }
        }
      }
      if (((camSpeeds5) Steps).StepType == CamStepType.StartToDistanceByStep & ((camSpeeds5) Steps).Step != 0.0)
      {
        double num14 = Steps.StartValue + Steps.Distance;
        double num15 = num14 - Steps.StartValue;
        double num16 = 1.0;
        if (num14 < Steps.StartValue)
          num16 = -1.0;
        int int32 = Convert.ToInt32(buNumeric.RoundToUpper(Math.Abs(num15) / ((camSpeeds5) Steps).Step));
        double num17 = Math.Abs(num15) / (double) int32;
        if (num17 != 0.0)
        {
          for (int index = 1; index <= int32; ++index)
          {
            double num18 = Steps.StartValue + num16 * Math.Abs(num17) * (double) index;
            CalcValues.Add(Math.Round(num18, 5));
          }
        }
      }
      if (!(((camSpeeds5) Steps).StepType == CamStepType.StartToDistanceByTrueStep & ((camSpeeds5) Steps).Step != 0.0))
        return;
      double num19 = Steps.StartValue + Steps.Distance;
      double num20 = num19 - Steps.StartValue;
      double num21 = 1.0;
      if (num19 < Steps.StartValue)
        num21 = -1.0;
      int int32_1 = Convert.ToInt32(buNumeric.RoundToLower(Math.Abs(num20) / ((camSpeeds5) Steps).Step));
      double step1 = ((camSpeeds5) Steps).Step;
      if (step1 == 0.0)
        return;
      double num22 = 0.0;
      for (int index = 1; index <= int32_1; ++index)
      {
        double num23 = Steps.StartValue + num21 * Math.Abs(step1) * (double) index;
        CalcValues.Add(Math.Round(num23, 5));
        num22 = num23;
      }
      if (buCompare.EQ(num22, num19, 0.01))
        return;
      CalcValues.Add(Math.Round(num19, 5));
    }
    catch (Exception ex)
    {
      string str = "Steps : " + Steps.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void GetLastPointOfCam(camTp Cam, ref TpPnt9D LastP9)
  {
    LastP9 = new TpPnt9D();
    if (Cam == null || Cam.CamPoints.Count <= 0 || Cam.CamPoints[Cam.CamPoints.Count - 1].Points.Count <= 0)
      return;
    LastP9 = new TpPnt9D(Cam.CamPoints[Cam.CamPoints.Count - 1].Points[Cam.CamPoints[Cam.CamPoints.Count - 1].Points.Count - 1]);
  }

  public void GetLastPointOfCam(camTp Cam, int CamPointIndex, ref TpPnt9D LastP9)
  {
    LastP9 = new TpPnt9D();
    if (!(Cam != null & CamPointIndex >= 0) || !(Cam.CamPoints.Count > 0 & CamPointIndex <= Cam.CamPoints.Count - 1) || Cam.CamPoints[CamPointIndex].Points.Count <= 0)
      return;
    LastP9 = new TpPnt9D(Cam.CamPoints[CamPointIndex].Points[Cam.CamPoints[CamPointIndex].Points.Count - 1]);
  }

  public void GetFirstPointOfCam(camTp Cam, ref TpPnt9D FirstP9)
  {
    FirstP9 = new TpPnt9D();
    if (Cam == null || Cam.CamPoints.Count <= 0 || Cam.CamPoints[0].Points.Count <= 0)
      return;
    FirstP9 = new TpPnt9D(Cam.CamPoints[0].Points[0]);
  }

  public void GetFirstPointOfCam(camTp Cam, int CamPointIndex, ref TpPnt9D FirstP9)
  {
    FirstP9 = new TpPnt9D();
    if (!(Cam != null & CamPointIndex >= 0) || !(Cam.CamPoints.Count > 0 & CamPointIndex <= Cam.CamPoints.Count - 1) || Cam.CamPoints[CamPointIndex].Points.Count <= 0)
      return;
    FirstP9 = new TpPnt9D(Cam.CamPoints[CamPointIndex].Points[0]);
  }

  public string CamTypeToString(camTp Cam, bool Tool = true, bool Explanation = true)
  {
    string str1 = "";
    string str2;
    if (Cam == null)
      str2 = buLangTranslate.preDef.NoCamDefined;
    else if (Cam.Explanation.Trim().Length > 0 & Explanation)
      str2 = Cam.Explanation;
    else if (Cam.TypeCam == CamType.ContourClosedCenter | Cam.TypeCam == CamType.ContourClosedInside | Cam.TypeCam == CamType.ContourClosedOutside)
    {
      string str3 = str1 + buLangTranslate.preDef.Contour + buLangTranslate.preDef.Closed;
      if (Cam.TypeCam == CamType.ContourClosedCenter)
        str3 = $"{str3} {buLangTranslate.preDef.Center}";
      if (Cam.TypeCam == CamType.ContourClosedInside)
        str3 = $"{str3} {buLangTranslate.preDef.Inside}";
      if (Cam.TypeCam == CamType.ContourClosedOutside)
        str3 = $"{str3} {buLangTranslate.preDef.Outside}";
      string str4 = $"{$"{str3} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str4 = $"{str4} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str4;
    }
    else if (Cam.TypeCam == CamType.ContourOpenCenter | Cam.TypeCam == CamType.ContourOpenLeft | Cam.TypeCam == CamType.ContourOpenRight)
    {
      string str5 = str1 + buLangTranslate.preDef.Contour + buLangTranslate.preDef.Open;
      if (Cam.TypeCam == CamType.ContourOpenCenter)
        str5 = $"{str5} {buLangTranslate.preDef.Center}";
      if (Cam.TypeCam == CamType.ContourOpenLeft)
        str5 = $"{str5} {buLangTranslate.preDef.Left}";
      if (Cam.TypeCam == CamType.ContourOpenRight)
        str5 = $"{str5} {buLangTranslate.preDef.Right}";
      string str6 = $"{$"{str5} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str6 = $"{str6} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str6;
    }
    else if (Cam.TypeCam == CamType.PocketCircular | Cam.TypeCam == CamType.PocketFlat)
    {
      string str7 = $"{$"{str1}{buLangTranslate.preDef.Pocket} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str7 = $"{str7} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str7;
    }
    else if (Cam.TypeCam == CamType.Face)
    {
      string str8 = $"{$"{str1}{buLangTranslate.preDef.Face} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str8 = $"{str8} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str8;
    }
    else if (Cam.TypeCam == CamType.Face)
    {
      string str9 = $"{$"{str1}{buLangTranslate.preDef.FloorFinish} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str9 = $"{str9} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str9;
    }
    else if (Cam.TypeCam == CamType.Chamfer)
    {
      string str10 = $"{$"{str1}{buLangTranslate.preDef.Chamfer} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str10 = $"{str10} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str10;
    }
    else if (Cam.TypeCam == CamType.Engrave)
    {
      string str11 = $"{$"{str1}{buLangTranslate.preDef.Engrave} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str11 = $"{str11} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str11;
    }
    else if (Cam.TypeCam == CamType.TextEngrave)
    {
      string str12 = $"{$"{str1}{buLangTranslate.preDef.TextEngrave} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str12 = $"{str12} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str12;
    }
    else if (Cam.TypeCam == CamType.Face)
    {
      string str13 = $"{$"{str1}{buLangTranslate.preDef.Face} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str13 = $"{str13} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str13;
    }
    else if (Cam.TypeCam == CamType.Trochoidal)
    {
      string str14 = $"{$"{str1}{buLangTranslate.preDef.Trochoidal} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str14 = $"{str14} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str14;
    }
    else if (Cam.TypeCam == CamType.Rough)
    {
      string str15 = $"{$"{str1}{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str15 = $"{str15} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str15;
    }
    else if (Cam.TypeCam == CamType.ParallelCut)
    {
      string str16 = $"{$"{str1}{buLangTranslate.preDef.ParalelCuts} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str16 = $"{str16} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str16;
    }
    else if (Cam.TypeCam == CamType.ConstantZ)
    {
      string str17 = $"{$"{str1}{buLangTranslate.preDef.ConstantZ} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str17 = $"{str17} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str17;
    }
    else if (Cam.TypeCam == CamType.Flatlands)
    {
      string str18 = $"{$"{str1}{buLangTranslate.preDef.Flatlands} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str18 = $"{str18} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str18;
    }
    else if (Cam.TypeCam == CamType.Pencil)
    {
      string str19 = $"{$"{str1}{buLangTranslate.preDef.Pencil} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str19 = $"{str19} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str19;
    }
    else if (Cam.TypeCam == CamType.Drill | Cam.TypeCam == CamType.Drill4X)
    {
      string str20 = $"{$"{str1}{buLangTranslate.preDef.Drill} {buLangTranslate.preDef.Cam}"} - {Cam.NumberOfAxis.ToString()}{buLangTranslate.preDef.Axes}";
      if (Tool)
        str20 = $"{str20} - {buLangTranslate.preDef.Tool}: {((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType.ToString()}";
      str2 = str20;
    }
    else
      str2 = buLangTranslate.preDef.UnknownCam;
    return str2;
  }

  public string CamWireframeTypeToString(CamWireFrameType Cam)
  {
    string str;
    switch (Cam)
    {
      case CamWireFrameType.None:
        str = buLangTranslate.preDef.None;
        break;
      case CamWireFrameType.Contour:
        str = buLangTranslate.preDef.Contour;
        break;
      case CamWireFrameType.Pocket:
        str = buLangTranslate.preDef.Pocket;
        break;
      case CamWireFrameType.FloorFinish:
        str = buLangTranslate.preDef.FloorFinish;
        break;
      case CamWireFrameType.Engrave:
        str = buLangTranslate.preDef.Engraving;
        break;
      case CamWireFrameType.TextEngrave:
        str = buLangTranslate.preDef.TextEngrave;
        break;
      case CamWireFrameType.Chamfer2D:
        str = buLangTranslate.preDef.Chamfer;
        break;
      case CamWireFrameType.Face:
        str = buLangTranslate.preDef.Face;
        break;
      case CamWireFrameType.Trochoidal:
        str = buLangTranslate.preDef.Trochoidal;
        break;
      case CamWireFrameType.CenterPath:
        str = buLangTranslate.preDef.CenterPath;
        break;
      case CamWireFrameType.Profile3Axis:
        str = $"{buLangTranslate.preDef.Profile} 3 {buLangTranslate.preDef.Axis}";
        break;
      case CamWireFrameType.Profile5Axis:
        str = $"{buLangTranslate.preDef.Profile} 5 {buLangTranslate.preDef.Axis}";
        break;
      default:
        str = buLangTranslate.preDef.UnknownCam;
        break;
    }
    return str;
  }

  public string CamTriangleMestTypeToString(CamTriangularMeshType Cam)
  {
    string str;
    switch (Cam)
    {
      case CamTriangularMeshType.Rough:
        str = buLangTranslate.preDef.Rough;
        break;
      case CamTriangularMeshType.ParallelCuts:
        str = buLangTranslate.preDef.ParalelCuts;
        break;
      case CamTriangularMeshType.ProjectCurves:
        str = buLangTranslate.preDef.ProjectCurves;
        break;
      case CamTriangularMeshType.ConstantZ:
        str = buLangTranslate.preDef.ConstantZ;
        break;
      case CamTriangularMeshType.ConstantCusp:
        str = buLangTranslate.preDef.ConstantCusp;
        break;
      case CamTriangularMeshType.Flatlands:
        str = buLangTranslate.preDef.Flatlands;
        break;
      case CamTriangularMeshType.Pencil:
        str = buLangTranslate.preDef.Pencil;
        break;
      case CamTriangularMeshType.Geodesic:
        str = buLangTranslate.preDef.Geodesic;
        break;
      case CamTriangularMeshType.Projection:
        str = buLangTranslate.preDef.Projection;
        break;
      case CamTriangularMeshType.RotaryRough:
        str = buLangTranslate.preDef.RotaryRough;
        break;
      case CamTriangularMeshType.RotaryFinish:
        str = buLangTranslate.preDef.RotaryFinish;
        break;
      case CamTriangularMeshType.Rotary:
        str = buLangTranslate.preDef.Rotary;
        break;
      case CamTriangularMeshType.Trochoidal:
        str = buLangTranslate.preDef.Trochoidal;
        break;
      case CamTriangularMeshType.ConstantZPlusConstantCusp:
        str = $"{buLangTranslate.preDef.ConstantZ} + {buLangTranslate.preDef.ConstantCusp}";
        break;
      case CamTriangularMeshType.ConstantZPlusParallelCuts:
        str = $"{buLangTranslate.preDef.ConstantZ} + {buLangTranslate.preDef.ParalelCuts}";
        break;
      case CamTriangularMeshType.None:
        str = buLangTranslate.preDef.None;
        break;
      default:
        str = buLangTranslate.preDef.UnknownCam;
        break;
    }
    return str;
  }

  public void ChangeCamPointCoordinates(
    ref List<camTpPoint> CamPoints,
    CamPointChangeMethod ChangeType)
  {
    if (ChangeType == CamPointChangeMethod.XYZToXZY)
    {
      for (int index1 = 0; index1 <= CamPoints.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= CamPoints[index1].Points.Count - 1; ++index2)
        {
          TpPnt9D point = CamPoints[index1].Points[index2];
          buFile5.ExchangeTwoVaues(ref ((TpArcData) point).P9.Y, ref ((TpArcData) point).P9.Z);
          if (point.PlungeAxisMovement)
            point.PlungeAxis = "Y";
          if (point.LeaveAxisMovement)
            point.LeaveAxis = "Y";
        }
      }
    }
    if (ChangeType != CamPointChangeMethod.XZYToXYZ)
      return;
    for (int index3 = 0; index3 <= CamPoints.Count - 1; ++index3)
    {
      for (int index4 = 0; index4 <= CamPoints[index3].Points.Count - 1; ++index4)
      {
        TpPnt9D point = CamPoints[index3].Points[index4];
        buFile5.ExchangeTwoVaues(ref ((TpArcData) point).P9.Z, ref ((TpArcData) point).P9.Y);
        if (point.PlungeAxisMovement)
          point.PlungeAxis = "Z";
        if (point.LeaveAxisMovement)
          point.LeaveAxis = "Z";
      }
    }
  }

  public CamType CamWireframeTypeToCamType(CamWireFrameType WireType)
  {
    CamType camType;
    switch (WireType)
    {
      case CamWireFrameType.None:
        camType = CamType.None;
        break;
      case CamWireFrameType.Contour:
        camType = CamType.Contour;
        break;
      case CamWireFrameType.Pocket:
        camType = CamType.PocketCircular;
        break;
      case CamWireFrameType.FloorFinish:
        camType = CamType.FloorFinishing;
        break;
      case CamWireFrameType.Engrave:
        camType = CamType.Engrave;
        break;
      case CamWireFrameType.TextEngrave:
        camType = CamType.TextEngrave;
        break;
      case CamWireFrameType.Chamfer2D:
        camType = CamType.Chamfer;
        break;
      case CamWireFrameType.Face:
        camType = CamType.Face;
        break;
      case CamWireFrameType.Trochoidal:
        camType = CamType.Trochoidal;
        break;
      case CamWireFrameType.CenterPath:
        camType = CamType.Contour;
        break;
      case CamWireFrameType.Profile3Axis:
        camType = CamType.Contour;
        break;
      case CamWireFrameType.Profile5Axis:
        camType = CamType.Contour;
        break;
      default:
        camType = CamType.None;
        break;
    }
    return camType;
  }

  public CamType CamTriangularMeshTypeToCamType(CamTriangularMeshType MeshType)
  {
    CamType camType;
    switch (MeshType)
    {
      case CamTriangularMeshType.Rough:
        camType = CamType.Rough;
        break;
      case CamTriangularMeshType.ParallelCuts:
        camType = CamType.ParallelCut;
        break;
      case CamTriangularMeshType.ProjectCurves:
        camType = CamType.ProjectCurves;
        break;
      case CamTriangularMeshType.ConstantZ:
        camType = CamType.ConstantZ;
        break;
      case CamTriangularMeshType.ConstantCusp:
        camType = CamType.ConstantCusp;
        break;
      case CamTriangularMeshType.Flatlands:
        camType = CamType.Flatlands;
        break;
      case CamTriangularMeshType.Pencil:
        camType = CamType.Pencil;
        break;
      case CamTriangularMeshType.Geodesic:
        camType = CamType.Geodesic;
        break;
      case CamTriangularMeshType.Projection:
        camType = CamType.Projection;
        break;
      case CamTriangularMeshType.RotaryRough:
        camType = CamType.RotaryRough;
        break;
      case CamTriangularMeshType.RotaryFinish:
        camType = CamType.RotaryFinish;
        break;
      case CamTriangularMeshType.Rotary:
        camType = CamType.Rotary;
        break;
      case CamTriangularMeshType.Trochoidal:
        camType = CamType.Trochoidal;
        break;
      case CamTriangularMeshType.ConstantZPlusConstantCusp:
        camType = CamType.ConstantZPlusConstantCusp;
        break;
      case CamTriangularMeshType.ConstantZPlusParallelCuts:
        camType = CamType.ConstantZPlusParallelCuts;
        break;
      case CamTriangularMeshType.None:
        camType = CamType.None;
        break;
      default:
        camType = CamType.None;
        break;
    }
    return camType;
  }

  public void MoveCam(double dX, double dY, double dZ, ref camTp Cam)
  {
    if (Cam == null || Cam.CamPoints == null)
      return;
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.EntitiesG0);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.EntitiesG1);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.EntitiesG1Orj);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.EntitiesLeadIn);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.EntitiesLeadOut);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.EntitiesLeave);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.EntitiesMark);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.EntitiesOther);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.EntitiesPlunge);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.RefEntities);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.sortedEntities);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.splitedEntities);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.PrePoints);
    buCall.\u0001.Move(dX, dY, dZ, ref Cam.AfterPoints);
    for (int index = 0; index <= Cam.CamPoints.Count - 1; ++index)
    {
      camTpPoint camPoint = Cam.CamPoints[index];
      buCall.\u0001.Move(dX, dY, dZ, ref camPoint.Points);
      buCall.\u0001.Move(dX, dY, dZ, ref camPoint.PrePoints);
      buCall.\u0001.Move(dX, dY, dZ, ref camPoint.AfterPoints);
    }
  }

  public bool isCamPointsAvailable(List<camTp> Cams)
  {
    return Cams.Count > 0 && this.isCamPointsAvailable(Cams[0]);
  }

  public bool isCamPointsAvailable(camTp Cam)
  {
    return Cam != null && (Cam.CamPoints == null ? 0 : (Cam.CamPoints.Count > 0 ? 1 : 0)) != 0 && Cam.CamPoints[0].Points.Count > 0;
  }

  public void GetLastNLineCodeFromString(string Line, ref double NLine)
  {
    NLine = -1.0;
    string str = "";
    for (int startIndex = Line.Length - 2; startIndex >= 0; --startIndex)
    {
      if (Line.Substring(startIndex, 1).ToLower() == "n")
      {
        str = Line.Substring(startIndex, Line.Length - startIndex);
        startIndex = 0;
      }
    }
    if (str.Length <= 0)
      return;
    buImage5.ReadCharValue(str.Replace("\n", ""), "N", ref NLine);
  }

  public void GetGCodeExecutionResult(
    MachineGCodeConfigrasyon Configration,
    string GCodes,
    ref MachineGCodeExecutionResult Result)
  {
    List<string> Lines = new List<string>();
    LockBitmap.StringToListByNewLine(GCodes, ref Lines);
    this.GetGCodeExecutionResult(Configration, Lines, ref Result);
  }

  public void GetGCodeExecutionResult(
    MachineGCodeConfigrasyon Configration,
    List<string> GCodes,
    ref MachineGCodeExecutionResult Result)
  {
    Result = (MachineGCodeExecutionResult) new F_Scale();
    Pnt6D foundPoint = new Pnt6D();
    Pnt6D copyPoint = (Pnt6D) null;
    int LastCode = -1;
    double foundFeed = 0.0;
    double LastR = 0.0;
    bool flag1 = false;
    MachineAxisInfo AX_X = (MachineAxisInfo) null;
    MachineAxisInfo AX_Y = (MachineAxisInfo) null;
    MachineAxisInfo AX_Z = (MachineAxisInfo) null;
    MachineAxisInfo AX_A = (MachineAxisInfo) null;
    MachineAxisInfo AX_B = (MachineAxisInfo) null;
    MachineAxisInfo AX_C = (MachineAxisInfo) null;
    MachineGCodeConfigrasyon gcodeConfigrasyon = (MachineGCodeConfigrasyon) new F_Move(Configration);
    if (((F_CutterOffsetEntities) Configration).SpeedType == SpeedUnit.meterPerMin)
    {
      for (int index = 0; index <= ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList.Count - 1; ++index)
      {
        ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).MaxSpeed = Math.Round(((F_CutterOffsetEntities) ((F_CutterMachineSettings) Configration).AxesList[index]).MaxSpeed * 1000.0 / 60.0, 5);
        ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).Acceleration = Math.Round(((F_CutterOffsetEntities) ((F_CutterMachineSettings) Configration).AxesList[index]).Acceleration / 3600.0 * 1000.0, 5);
        ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).Deceleration = Math.Round(((F_CutterOffsetEntities) ((F_CutterMachineSettings) Configration).AxesList[index]).Deceleration / 3600.0 * 1000.0, 5);
        ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).Jerk = Math.Round(((F_CutterOffsetEntities) ((F_CutterMachineSettings) Configration).AxesList[index]).Jerk / 216000.0 * 1000.0, 5);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "x")
          AX_X = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "y")
          AX_Y = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "z")
          AX_Z = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "a")
          AX_A = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "b")
          AX_B = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "c")
          AX_C = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
      }
    }
    if (((F_CutterOffsetEntities) Configration).SpeedType == SpeedUnit.mmPerMin)
    {
      for (int index = 0; index <= ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList.Count - 1; ++index)
      {
        ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).MaxSpeed = Math.Round(((F_CutterOffsetEntities) ((F_CutterMachineSettings) Configration).AxesList[index]).MaxSpeed * 1.0 / 60.0, 5);
        ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).Acceleration = Math.Round(((F_CutterOffsetEntities) ((F_CutterMachineSettings) Configration).AxesList[index]).Acceleration / 3600.0 * 1.0, 5);
        ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).Deceleration = Math.Round(((F_CutterOffsetEntities) ((F_CutterMachineSettings) Configration).AxesList[index]).Deceleration / 3600.0 * 1.0, 5);
        ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).Jerk = Math.Round(((F_CutterOffsetEntities) ((F_CutterMachineSettings) Configration).AxesList[index]).Jerk / 216000.0 * 1.0, 5);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "x")
          AX_X = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "y")
          AX_Y = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "z")
          AX_Z = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "a")
          AX_A = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "b")
          AX_B = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
        if (((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]).AxisName.ToLower().Trim() == "c")
          AX_C = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) gcodeConfigrasyon).AxesList[index]);
      }
    }
    for (int index1 = 0; index1 <= GCodes.Count - 1; ++index1)
    {
      string str1 = GCodes[index1].ToLower().Trim();
      bool isContantMove = false;
      if (str1.IndexOf("m") >= 0)
      {
        LastCode = -1;
        LastR = 0.0;
        bool flag2 = false;
        double num = 0.0;
        buImage5.ReadCharValue(str1, "m", ref num);
        string str2 = "m" + num.ToString();
        for (int index2 = 0; index2 <= ((F_CutterMachineSettings) gcodeConfigrasyon).MCodeList.Count - 1; ++index2)
        {
          string str3 = ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).MCodeList[index2]).MCode.ToLower().Trim();
          if (str1.IndexOf(str3) >= 0 & str3 == str2)
          {
            ((F_CutterOffsetEntities) Result).TotalTimeAsSec = ((F_CutterOffsetEntities) Result).TotalTimeAsSec + ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).MCodeList[index2]).TimeAsSec;
            ((F_NotchEdit) Result).TotalMCodeTimeAsSec = ((F_NotchEdit) Result).TotalMCodeTimeAsSec + ((F_CutterOffsetEntities) ((F_CutterMachineSettings) gcodeConfigrasyon).MCodeList[index2]).TimeAsSec;
            flag2 = true;
          }
        }
        if (!flag2)
        {
          if (((F_NotchEdit) Result).NoDefinedMCodes.Count == 0)
            ((F_NotchEdit) Result).NoDefinedMCodes.Add(GCodes[index1].Trim());
          else if (!buFile5.isCharsInStringList(GCodes[index1].Trim(), ((F_NotchEdit) Result).NoDefinedMCodes))
            ((F_NotchEdit) Result).NoDefinedMCodes.Add(GCodes[index1].Trim());
        }
      }
      else if (str1.IndexOf("g") >= 0)
      {
        bool flag3 = false;
        if (str1.IndexOf("g0 ") >= 0)
        {
          flag3 = true;
          isContantMove = false;
          LastCode = 0;
          LastR = 0.0;
        }
        else if (str1.IndexOf("g1 ") >= 0)
        {
          flag3 = true;
          LastCode = 1;
          LastR = 0.0;
        }
        else if (str1.IndexOf("g2 ") >= 0)
        {
          buImage5.ReadCharValue(str1, "r", ref LastR);
          flag3 = true;
          isContantMove = true;
          LastCode = 2;
        }
        else if (str1.IndexOf("g3 ") >= 0)
        {
          buImage5.ReadCharValue(str1, "r", ref LastR);
          flag3 = true;
          isContantMove = true;
          LastCode = 3;
        }
        else if (str1.IndexOf("g4 ") >= 0)
        {
          LastCode = 4;
          LastR = 0.0;
        }
        else
        {
          LastCode = -1;
          LastR = 0.0;
        }
        if (flag3)
        {
          flag1 = true;
          this.GetCoordinatesFromLine(str1, ref foundPoint, ref foundFeed);
          if (copyPoint != (Pnt6D) null && !buConversion5.EQ(foundPoint, copyPoint))
            this.CalculateGCodeTimeAndLength(copyPoint, foundPoint, LastCode, foundFeed, LastR, isContantMove, AX_X, AX_Y, AX_Z, AX_A, AX_B, AX_C, ref Result);
        }
      }
      else if (LastCode >= 0)
      {
        this.GetCoordinatesFromLine(str1, ref foundPoint, ref foundFeed);
        if (!buConversion5.EQ(foundPoint, copyPoint))
          this.CalculateGCodeTimeAndLength(copyPoint, foundPoint, LastCode, foundFeed, LastR, isContantMove, AX_X, AX_Y, AX_Z, AX_A, AX_B, AX_C, ref Result);
      }
      if (flag1)
        Pnt6D.CoordinateCopy(foundPoint, ref copyPoint);
    }
    ((F_NotchEdit) Result).OperationLengthAsMeter = Math.Round(((F_NotchEdit) Result).OperationLengthAsMeter, 5);
    ((F_NotchEdit) Result).OperationTimeAsSec = Math.Round(((F_NotchEdit) Result).OperationTimeAsSec, 5);
    ((F_NotchEdit) Result).QuickMoveLengthAsMeter = Math.Round(((F_NotchEdit) Result).QuickMoveLengthAsMeter, 5);
    ((F_NotchEdit) Result).QuickMoveTimeAsSec = Math.Round(((F_NotchEdit) Result).QuickMoveTimeAsSec, 5);
    ((F_NotchEdit) Result).TotalLengthAsMeter = Math.Round(((F_NotchEdit) Result).OperationLengthAsMeter + ((F_NotchEdit) Result).QuickMoveLengthAsMeter, 5);
    ((F_NotchEdit) Result).TotalMCodeTimeAsSec = Math.Round(((F_NotchEdit) Result).TotalMCodeTimeAsSec, 5);
    ((F_CutterOffsetEntities) Result).TotalTimeAsSec = Math.Round(((F_CutterOffsetEntities) Result).TotalTimeAsSec, 5);
  }

  public void CalculateGCodeTimeAndLength(
    Pnt6D pntLast,
    Pnt6D pntCurrent,
    int LastCode,
    double LastF,
    double LastR,
    bool isContantMove,
    MachineAxisInfo AX_X,
    MachineAxisInfo AX_Y,
    MachineAxisInfo AX_Z,
    MachineAxisInfo AX_A,
    MachineAxisInfo AX_B,
    MachineAxisInfo AX_C,
    ref MachineGCodeExecutionResult Result)
  {
    Length6D Delta = new Length6D();
    Pnt6D.GetDifferences(pntLast, pntCurrent, ref Delta);
    double num1 = 0.0;
    double Distance = buCall.\u0001.Length3D(pntLast, pntCurrent);
    if ((LastCode == 2 | LastCode == 3) & LastR > 0.0)
    {
      bool CW = true;
      if (LastCode == 3)
        CW = false;
      Entity entArc = (Entity) null;
      buCall.\u0001.ArcWithTwoPointAndRadius(new Point3D(pntLast.X, pntLast.Y), new Point3D(pntCurrent.X, pntCurrent.Y), LastR, CW, Plane.XY, ref entArc);
      if (entArc != null)
        Distance = ((ICurve) entArc).Length();
    }
    switch (LastCode)
    {
      case 0:
        if (Math.Abs(Delta.dX) > 0.01 & AX_X != null)
          num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromTrapezLinearMove(((F_CutterOffsetEntities) AX_X).MaxSpeed, ((F_CutterOffsetEntities) AX_X).Acceleration, ((F_CutterOffsetEntities) AX_X).Deceleration, Math.Abs(Delta.dX));
        if (Math.Abs(Delta.dY) > 0.01 & AX_Y != null)
          num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromTrapezLinearMove(((F_CutterOffsetEntities) AX_Y).MaxSpeed, ((F_CutterOffsetEntities) AX_Y).Acceleration, ((F_CutterOffsetEntities) AX_Y).Deceleration, Math.Abs(Delta.dY));
        if (Math.Abs(Delta.dZ) > 0.01 & AX_Z != null)
        {
          num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromTrapezLinearMove(((F_CutterOffsetEntities) AX_Z).MaxSpeed, ((F_CutterOffsetEntities) AX_Z).Acceleration, ((F_CutterOffsetEntities) AX_Z).Deceleration, Math.Abs(Delta.dZ));
          break;
        }
        break;
      case 1:
        double num2 = Math.Abs(Delta.dX) / Distance;
        double num3 = Math.Abs(Delta.dY) / Distance;
        double num4 = Math.Abs(Delta.dZ) / Distance;
        if (!isContantMove)
        {
          if (Math.Abs(Delta.dX) > 0.01 & AX_X != null)
            num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromTrapezLinearMove(LastF * num2, ((F_CutterOffsetEntities) AX_X).Acceleration, ((F_CutterOffsetEntities) AX_X).Deceleration, Math.Abs(Delta.dX));
          if (Math.Abs(Delta.dY) > 0.01 & AX_Y != null)
            num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromTrapezLinearMove(LastF * num3, ((F_CutterOffsetEntities) AX_Y).Acceleration, ((F_CutterOffsetEntities) AX_Y).Deceleration, Math.Abs(Delta.dY));
          if (Math.Abs(Delta.dZ) > 0.01 & AX_Z != null)
          {
            num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromTrapezLinearMove(LastF * num4, ((F_CutterOffsetEntities) AX_Z).Acceleration, ((F_CutterOffsetEntities) AX_Z).Deceleration, Math.Abs(Delta.dZ));
            break;
          }
          break;
        }
        if (Math.Abs(Delta.dX) > 0.01 & AX_X != null)
          num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromConstantMove(LastF * num2, Math.Abs(Delta.dX));
        if (Math.Abs(Delta.dY) > 0.01 & AX_Y != null)
          num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromConstantMove(LastF * num3, Math.Abs(Delta.dY));
        if (Math.Abs(Delta.dZ) > 0.01 & AX_Z != null)
        {
          num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromConstantMove(LastF * num4, Math.Abs(Delta.dZ));
          break;
        }
        break;
      default:
        if (LastCode == 2 | LastCode == 3)
        {
          if (!isContantMove)
          {
            if (Math.Abs(Distance) > 0.01 & AX_X != null)
            {
              num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromTrapezLinearMove(LastF, ((F_CutterOffsetEntities) AX_X).Acceleration, ((F_CutterOffsetEntities) AX_X).Deceleration, Distance);
              break;
            }
            break;
          }
          num1 += ((F_CutterMachineSettings) buCall.\u0001).CalculateTotalTimeFromConstantMove(LastF, Math.Abs(Distance));
          break;
        }
        break;
    }
    ((F_CutterOffsetEntities) Result).TotalTimeAsSec = ((F_CutterOffsetEntities) Result).TotalTimeAsSec + num1;
    if (LastCode == 0)
    {
      ((F_NotchEdit) Result).QuickMoveTimeAsSec = ((F_NotchEdit) Result).QuickMoveTimeAsSec + num1;
      ((F_NotchEdit) Result).QuickMoveLengthAsMeter = ((F_NotchEdit) Result).QuickMoveLengthAsMeter + Distance / 1000.0;
    }
    if (!(LastCode == 1 | LastCode == 2 | LastCode == 3))
      return;
    ((F_NotchEdit) Result).OperationTimeAsSec = ((F_NotchEdit) Result).OperationTimeAsSec + num1;
    ((F_NotchEdit) Result).OperationLengthAsMeter = ((F_NotchEdit) Result).OperationLengthAsMeter + Distance / 1000.0;
  }

  public void GetCoordinatesFromLine(string Line, ref Pnt6D foundPoint, ref double foundFeed)
  {
    if (Line.IndexOf("f") >= 0)
    {
      double num = 0.0;
      if (buImage5.ReadCharValue(Line, "f", ref num))
        foundFeed = num;
    }
    if (Line.IndexOf("x") >= 0)
    {
      double num = 0.0;
      if (buImage5.ReadCharValue(Line, "x", ref num))
        foundPoint.X = num;
    }
    if (Line.IndexOf("y") >= 0)
    {
      double num = 0.0;
      if (buImage5.ReadCharValue(Line, "y", ref num))
        foundPoint.Y = num;
    }
    if (Line.IndexOf("z") >= 0)
    {
      double num = 0.0;
      if (buImage5.ReadCharValue(Line, "z", ref num))
        foundPoint.Z = num;
    }
    if (Line.IndexOf("a") >= 0)
    {
      double num = 0.0;
      if (buImage5.ReadCharValue(Line, "a", ref num))
        foundPoint.A = num;
    }
    if (Line.IndexOf("b") >= 0)
    {
      double num = 0.0;
      if (buImage5.ReadCharValue(Line, "b", ref num))
        foundPoint.B = num;
    }
    if (Line.IndexOf("c") < 0)
      return;
    double num1 = 0.0;
    if (!buImage5.ReadCharValue(Line, "c", ref num1))
      return;
    foundPoint.C = num1;
  }

  public void DevideSimPoints(bool ReverseCircular, ref List<Pnt6DSimMove> SimPoints)
  {
    if (SimPoints.Count == 0)
      return;
    List<Pnt6DSimMove> CopiedPnt = new List<Pnt6DSimMove>();
    PointABC.Copy(SimPoints, ref CopiedPnt);
    SimPoints.Clear();
    SimPoints = new List<Pnt6DSimMove>();
    SimPoints.Add((Pnt6DSimMove) new AlingmentPoints3D(CopiedPnt[0]));
    for (int index1 = 1; index1 <= CopiedPnt.Count - 1; ++index1)
    {
      double num1 = Math.Round(buCall.\u0001.Length6D(CopiedPnt[index1 - 1], CopiedPnt[index1]), 3);
      if (num1 > 0.0)
      {
        List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
        double DevideLength = 20.0;
        List<Pnt6DSimMove> pnt6DsimMoveList = new List<Pnt6DSimMove>();
        if (((MeshToSurfacePointsCalculations) CopiedPnt[index1]).GCode == 1)
          DevideLength = 5.0;
        if ((((MeshToSurfacePointsCalculations) CopiedPnt[index1]).GCode == 2 | ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).GCode == 3) & ((MeshToSurfacePointsSettings) CopiedPnt[index1]).R != 0.0)
        {
          bool CW = false;
          if (((MeshToSurfacePointsCalculations) CopiedPnt[index1]).GCode == 2)
            CW = true;
          if (ReverseCircular)
            CW = !CW;
          Point3D ArcStartPoint = new Point3D(((MeshToSurfacePointsSettings) CopiedPnt[index1 - 1]).X, ((MeshToSurfacePointsSettings) CopiedPnt[index1 - 1]).Y, ((MeshToSurfacePointsSettings) CopiedPnt[index1 - 1]).Z);
          Point3D ArcEndPoint = new Point3D(((MeshToSurfacePointsSettings) CopiedPnt[index1]).X, ((MeshToSurfacePointsSettings) CopiedPnt[index1]).Y, ((MeshToSurfacePointsSettings) CopiedPnt[index1]).Z);
          Entity entArc = (Entity) null;
          buCall.\u0001.ArcWithTwoPointAndRadius(ArcStartPoint, ArcEndPoint, ((MeshToSurfacePointsSettings) CopiedPnt[index1]).R, CW, Plane.XY, ref entArc);
          if (entArc != null)
          {
            double num2 = ((ICurve) entArc).Length();
            if (Convert.ToInt32(num2 / DevideLength) < 3)
              DevideLength = num2 / 5.0;
            List<Point3D> pntDevided = new List<Point3D>();
            buCall.\u0001.EntityDevide(entArc, DevideLength, ref pntDevided);
            if (CW)
              pntDevided.Reverse();
            for (int index2 = 0; index2 <= pntDevided.Count - 1; ++index2)
            {
              Pnt6DSimMove pnt6DsimMove = (Pnt6DSimMove) new PointAndIndex(pntDevided[index2]);
              ((MeshToSurfacePointsCalculations) pnt6DsimMove).ToolNo = ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).ToolNo;
              ((MeshToSurfacePointsCalculations) pnt6DsimMove).SpindleRpm = ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).SpindleRpm;
              ((MeshToSurfacePointsSettings) pnt6DsimMove).FeedRate = ((MeshToSurfacePointsSettings) CopiedPnt[index1]).FeedRate;
              ((MeshToSurfacePointsCalculations) pnt6DsimMove).GCode = ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).GCode;
              ((MeshToSurfacePointsCalculations) pnt6DsimMove).Index = ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).Index;
              ((MeshToSurfacePointsCalculations) pnt6DsimMove).isMCode = ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).isMCode;
              ((MeshToSurfacePointsCalculations) pnt6DsimMove).MCode = ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).MCode;
              ((MeshToSurfacePointsCalculations) pnt6DsimMove).Offset = ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).Offset;
              ((MeshToSurfacePointsCalculations) pnt6DsimMove).ToolName = ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).ToolName;
              ((MeshToSurfacePointsCalculations) pnt6DsimMove).Index = ((MeshToSurfacePointsCalculations) CopiedPnt[index1]).Index;
              pnt6DsimMoveList.Add(pnt6DsimMove);
            }
          }
        }
        if (pnt6DsimMoveList.Count <= 1)
        {
          if (num1 > DevideLength)
          {
            int Count = Convert.ToInt32(num1 / DevideLength);
            if (Count < 4)
              Count = 4;
            ((MachineGCodeConfigrasyon) buCall.\u0001).LineerInterpolation(CopiedPnt[index1 - 1], CopiedPnt[index1], Count, ref CalculatedPoints);
            if (CalculatedPoints.Count > 0)
            {
              CalculatedPoints.RemoveAt(0);
              SimPoints.AddRange((IEnumerable<Pnt6DSimMove>) CalculatedPoints);
            }
          }
          else
            SimPoints.Add((Pnt6DSimMove) new AlingmentPoints3D(CopiedPnt[index1]));
        }
        else
        {
          for (int index3 = 1; index3 <= pnt6DsimMoveList.Count - 1; ++index3)
            SimPoints.Add((Pnt6DSimMove) new AlingmentPoints3D(pnt6DsimMoveList[index3]));
        }
      }
      else
        SimPoints.Add((Pnt6DSimMove) new AlingmentPoints3D(CopiedPnt[index1]));
    }
  }

  public void ReCalculateSimulationPoints(ref camTp Cam)
  {
    ((camParameters5) Cam.SimilationPoint).SimMove.Clear();
    ((camParameters5) Cam.SimilationPoint).SimMove = new List<Pnt6DSimMove>();
    for (int index = 0; index <= Cam.CamPoints.Count - 1; ++index)
    {
      if (index > 0)
        this.CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[index - 1], Cam.CamPoints[index]);
      else
        this.CreateSimulationPointsFromCamPoint(ref Cam, (camTpPoint) null, Cam.CamPoints[index]);
    }
  }

  public void CreateSimulationPointsFromCamPoint(
    ref List<Pnt6DSimMove> SimPoints,
    camTpPoint CamPoint,
    double DevideLen = 5.0)
  {
    camTp Cam = new camTp();
    this.CreateSimulationPointsFromCamPoint(ref Cam, CamPoint, DevideLen);
    SimPoints.AddRange((IEnumerable<Pnt6DSimMove>) PointABC.Copy(((camParameters5) Cam.SimilationPoint).SimMove));
  }

  public void CreateSimulationPointsFromCamPoint(
    ref camTp Cam,
    camTpPoint CamPoint,
    double G0Devide = 10.0,
    double G1Devide = 2.0)
  {
    if (G0Devide <= 0.0)
      G0Devide = 5.0;
    if (G1Devide <= 0.0)
      G1Devide = 2.0;
    if (CamPoint.PrePoints.Count > 0)
    {
      ((camParameters5) Cam.SimilationPoint).SimMove.Add(TpArcData.ToPnt6DSim(CamPoint.PrePoints[0]));
      this.CreateSimulationPointsFromType(ref Cam, CamPoint.PrePoints, G0Devide, G1Devide);
    }
    if (CamPoint.Points.Count > 0)
    {
      if (CamPoint.PrePoints.Count > 0)
      {
        List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
        int int32 = Convert.ToInt32(buCall.\u0001.Length3D(new Pnt3D(((TpArcData) CamPoint.PrePoints[CamPoint.PrePoints.Count - 1]).P9.X, ((TpArcData) CamPoint.PrePoints[CamPoint.PrePoints.Count - 1]).P9.Y, ((TpArcData) CamPoint.PrePoints[CamPoint.PrePoints.Count - 1]).P9.Z), new Pnt3D(((TpArcData) CamPoint.Points[0]).P9.X, ((TpArcData) CamPoint.Points[0]).P9.Y, ((TpArcData) CamPoint.Points[0]).P9.Z)) / G0Devide);
        ((MachineGCodeConfigrasyon) buCall.\u0001).LineerInterpolation(TpArcData.ToPnt6DSim(CamPoint.PrePoints[CamPoint.PrePoints.Count - 1]), TpArcData.ToPnt6DSim(CamPoint.Points[0]), int32, ref CalculatedPoints);
        if (CalculatedPoints.Count >= 2)
        {
          CalculatedPoints.RemoveAt(0);
          ((camParameters5) Cam.SimilationPoint).SimMove.AddRange((IEnumerable<Pnt6DSimMove>) CalculatedPoints);
        }
      }
      ((camParameters5) Cam.SimilationPoint).SimMove.Add(TpArcData.ToPnt6DSim(CamPoint.Points[0]));
      this.CreateSimulationPointsFromType(ref Cam, CamPoint.Points, G0Devide, G1Devide);
    }
    if (CamPoint.AfterPoints.Count <= 0)
      return;
    if (CamPoint.Points.Count > 0)
    {
      List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
      Point3D StartPoint = new Point3D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.Y, ((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.Z);
      Point3D EndPoint = new Point3D(((TpArcData) CamPoint.AfterPoints[CamPoint.AfterPoints.Count - 1]).P9.X, ((TpArcData) CamPoint.AfterPoints[CamPoint.AfterPoints.Count - 1]).P9.Y, ((TpArcData) CamPoint.AfterPoints[CamPoint.AfterPoints.Count - 1]).P9.Z);
      int int32 = Convert.ToInt32(buCall.\u0001.Length3D(StartPoint, EndPoint) / G0Devide);
      ((MachineGCodeConfigrasyon) buCall.\u0001).LineerInterpolation(TpArcData.ToPnt6DSim(CamPoint.Points[CamPoint.Points.Count - 1]), TpArcData.ToPnt6DSim(CamPoint.AfterPoints[0]), int32, ref CalculatedPoints);
      if (CalculatedPoints.Count >= 2)
      {
        CalculatedPoints.RemoveAt(0);
        ((camParameters5) Cam.SimilationPoint).SimMove.AddRange((IEnumerable<Pnt6DSimMove>) CalculatedPoints);
      }
    }
    ((camParameters5) Cam.SimilationPoint).SimMove.Add(TpArcData.ToPnt6DSim(CamPoint.AfterPoints[0]));
    this.CreateSimulationPointsFromType(ref Cam, CamPoint.AfterPoints, G0Devide, G1Devide);
  }

  public void CreateSimulationPointsFromCamPoint(
    ref camTp Cam,
    camTpPoint PreCamPoint,
    camTpPoint CamPoint,
    double DevideLen = 5.0)
  {
    TpPnt9D pntSecond = (TpPnt9D) null;
    if (CamPoint.PrePoints.Count > 0)
      pntSecond = new TpPnt9D(CamPoint.PrePoints[0]);
    else if (CamPoint.Points.Count > 0)
      pntSecond = new TpPnt9D(CamPoint.Points[0]);
    if (PreCamPoint != null & pntSecond != null && PreCamPoint.AfterPoints.Count > 0)
    {
      List<Pnt6DSimMove> simPoints = new List<Pnt6DSimMove>();
      this.SimilationPointBetweenTwoPoints(PreCamPoint.AfterPoints[PreCamPoint.AfterPoints.Count - 1], pntSecond, ref simPoints, DevideLen);
      if (simPoints.Count >= 0)
        ((camParameters5) Cam.SimilationPoint).SimMove.AddRange((IEnumerable<Pnt6DSimMove>) simPoints);
    }
    if (CamPoint.PrePoints.Count > 0)
    {
      ((camParameters5) Cam.SimilationPoint).SimMove.Add(TpArcData.ToPnt6DSim(CamPoint.PrePoints[0]));
      this.CreateSimulationPointsFromType(ref Cam, CamPoint.PrePoints);
    }
    if (CamPoint.Points.Count > 0)
    {
      if (CamPoint.PrePoints.Count > 0)
      {
        List<Pnt6DSimMove> simPoints = new List<Pnt6DSimMove>();
        this.SimilationPointBetweenTwoPoints(CamPoint.PrePoints[CamPoint.PrePoints.Count - 1], CamPoint.Points[0], ref simPoints, DevideLen);
        if (simPoints.Count > 0)
          ((camParameters5) Cam.SimilationPoint).SimMove.AddRange((IEnumerable<Pnt6DSimMove>) simPoints);
      }
      ((camParameters5) Cam.SimilationPoint).SimMove.Add(TpArcData.ToPnt6DSim(CamPoint.Points[0]));
      this.CreateSimulationPointsFromType(ref Cam, CamPoint.Points);
    }
    if (CamPoint.AfterPoints.Count <= 0)
      return;
    if (CamPoint.Points.Count > 0)
    {
      List<Pnt6DSimMove> simPoints = new List<Pnt6DSimMove>();
      this.SimilationPointBetweenTwoPoints(CamPoint.Points[CamPoint.Points.Count - 1], CamPoint.AfterPoints[0], ref simPoints, DevideLen);
      if (simPoints.Count >= 0)
        ((camParameters5) Cam.SimilationPoint).SimMove.AddRange((IEnumerable<Pnt6DSimMove>) simPoints);
    }
    ((camParameters5) Cam.SimilationPoint).SimMove.Add(TpArcData.ToPnt6DSim(CamPoint.AfterPoints[0]));
    this.CreateSimulationPointsFromType(ref Cam, CamPoint.AfterPoints);
  }

  public void CreateSimulationPointsFromType(ref List<Pnt6DSimMove> simPoints, List<TpPnt9D> Points)
  {
    camTp Cam = new camTp();
    this.CreateSimulationPointsFromType(ref Cam, Points);
    simPoints.AddRange((IEnumerable<Pnt6DSimMove>) PointABC.Copy(((camParameters5) Cam.SimilationPoint).SimMove));
  }

  public void CreateSimulationPointsFromType(
    ref camTp Cam,
    List<TpPnt9D> Points,
    double G0Devide = 10.0,
    double G1Devide = 2.0)
  {
    if (G0Devide <= 0.0)
      G0Devide = 10.0;
    if (G1Devide <= 0.0)
      G1Devide = 2.0;
    TpPnt9D pnt = new TpPnt9D(Points[0]);
    for (int index1 = 1; index1 <= Points.Count - 1; ++index1)
    {
      TpPnt9D tpPnt9D = new TpPnt9D(Points[index1]);
      if (!tpPnt9D.EnableAxes.X)
        ((TpArcData) tpPnt9D).P9.X = ((TpArcData) pnt).P9.X;
      if (!tpPnt9D.EnableAxes.Y)
        ((TpArcData) tpPnt9D).P9.Y = ((TpArcData) pnt).P9.Y;
      if (!tpPnt9D.EnableAxes.Z)
        ((TpArcData) tpPnt9D).P9.Z = ((TpArcData) pnt).P9.Z;
      if (!tpPnt9D.EnableAxes.A)
        ((TpArcData) tpPnt9D).P9.A = ((TpArcData) pnt).P9.A;
      if (!tpPnt9D.EnableAxes.B)
        ((TpArcData) tpPnt9D).P9.B = ((TpArcData) pnt).P9.B;
      if (!tpPnt9D.EnableAxes.C)
        ((TpArcData) tpPnt9D).P9.C = ((TpArcData) pnt).P9.C;
      List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
      double num1 = buCall.\u0001.Length3D(new Pnt3D(((TpArcData) pnt).P9.X, ((TpArcData) pnt).P9.Y, ((TpArcData) pnt).P9.Z), new Pnt3D(((TpArcData) tpPnt9D).P9.X, ((TpArcData) tpPnt9D).P9.Y, ((TpArcData) tpPnt9D).P9.Z));
      if (tpPnt9D.Type == 0)
      {
        int Count = Convert.ToInt32(num1 / G0Devide);
        if (num1 <= 0.1 && !buConversion5.EQ(((TpArcData) pnt).P9.C, ((TpArcData) tpPnt9D).P9.C))
          Count = 50;
        ((MachineGCodeConfigrasyon) buCall.\u0001).LineerInterpolation(TpArcData.ToPnt6DSim(pnt), TpArcData.ToPnt6DSim(tpPnt9D), Count, ref CalculatedPoints);
      }
      else if (tpPnt9D.Type == 1)
      {
        int int32 = Convert.ToInt32(num1 / G1Devide);
        ((MachineGCodeConfigrasyon) buCall.\u0001).LineerInterpolation(TpArcData.ToPnt6DSim(pnt), TpArcData.ToPnt6DSim(tpPnt9D), int32, ref CalculatedPoints);
      }
      else if (tpPnt9D.Type == 2 | tpPnt9D.Type == 3)
      {
        double num2 = ((SimulationTp) tpPnt9D.ArcData).Length;
        if (((SimulationTp) tpPnt9D.ArcData).Length == 0.0 & ((SimulationTp) tpPnt9D.ArcData).Radius > 0.0)
          num2 = buCall.\u0001.ArcCircumference(((SimulationTp) tpPnt9D.ArcData).Radius, ((SimulationTp) tpPnt9D.ArcData).StartAngle, ((SimulationTp) tpPnt9D.ArcData).EndAngle);
        new Arc(Plane.XY, tpPnt9D.ArcData.CenterPoint, ((SimulationTp) tpPnt9D.ArcData).Radius, tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.EndPoint, false).Regen(0.01);
        List<Pnt3D> Vertices = new List<Pnt3D>();
        bool flag = ((camParameters5) Points[index1].ArcData).isReverse;
        if (tpPnt9D.Type == 2)
        {
          if (!flag)
            flag = true;
          ((camParameters5) Points[index1].ArcData).isReverse = true;
        }
        if (!flag)
        {
          buCall.\u0001.ArcToLineer(buString5.Point3DToPnt3D(tpPnt9D.ArcData.CenterPoint), ((SimulationTp) tpPnt9D.ArcData).Radius, ((SimulationTp) tpPnt9D.ArcData).StartAngle, ((SimulationTp) tpPnt9D.ArcData).EndAngle, G1Devide, new WorkPlane(), ref Vertices);
        }
        else
        {
          buCall.\u0001.ArcToLineer(buString5.Point3DToPnt3D(tpPnt9D.ArcData.CenterPoint), ((SimulationTp) tpPnt9D.ArcData).Radius, ((SimulationTp) tpPnt9D.ArcData).StartAngle, ((SimulationTp) tpPnt9D.ArcData).EndAngle, G1Devide, new WorkPlane(), ref Vertices);
          Vertices.Reverse();
        }
        if (Vertices.Count > 0)
        {
          for (int index2 = 0; index2 <= Vertices.Count - 1; ++index2)
          {
            Pnt6DSimMove pnt6DsimMove = (Pnt6DSimMove) new PointsList(Vertices[index2].X, Vertices[index2].Y, Vertices[index2].Z);
            ((MeshToSurfacePointsSettings) pnt6DsimMove).A = ((TpArcData) tpPnt9D).P9.A;
            CalculatedPoints.Add(pnt6DsimMove);
          }
        }
      }
      if (CalculatedPoints.Count >= 2)
      {
        CalculatedPoints.RemoveAt(0);
        for (int index3 = 0; index3 <= CalculatedPoints.Count - 1; ++index3)
        {
          ((MeshToSurfacePointsSettings) CalculatedPoints[index3]).FeedRate = Points[index1].Feed;
          ((MeshToSurfacePointsCalculations) CalculatedPoints[index3]).ToolNo = Points[index1].ToolNo;
          ((MeshToSurfacePointsCalculations) CalculatedPoints[index3]).SpindleRpm = Points[index1].SpindleSpeed;
          ((camParameters5) Cam.SimilationPoint).SimMove.Add(CalculatedPoints[index3]);
        }
      }
      else if (((camParameters5) Cam.SimilationPoint).SimMove.Count > 0)
      {
        Pnt6DSimMove pnt6Dsim = TpArcData.ToPnt6DSim(tpPnt9D);
        if (!buString5.EQ(((camParameters5) Cam.SimilationPoint).SimMove[((camParameters5) Cam.SimilationPoint).SimMove.Count - 1], pnt6Dsim, 0.01) && buCall.\u0001.Length6D(pnt6Dsim, ((camParameters5) Cam.SimilationPoint).SimMove[((camParameters5) Cam.SimilationPoint).SimMove.Count - 1]) >= G1Devide)
        {
          ((MeshToSurfacePointsSettings) pnt6Dsim).FeedRate = Points[index1].Feed;
          ((MeshToSurfacePointsCalculations) pnt6Dsim).ToolNo = Points[index1].ToolNo;
          ((MeshToSurfacePointsCalculations) pnt6Dsim).SpindleRpm = Points[index1].SpindleSpeed;
          ((camParameters5) Cam.SimilationPoint).SimMove.Add(pnt6Dsim);
        }
      }
      else
      {
        Pnt6DSimMove pnt6Dsim = TpArcData.ToPnt6DSim(tpPnt9D);
        ((MeshToSurfacePointsSettings) pnt6Dsim).FeedRate = Points[index1].Feed;
        ((MeshToSurfacePointsCalculations) pnt6Dsim).ToolNo = Points[index1].ToolNo;
        ((MeshToSurfacePointsCalculations) pnt6Dsim).SpindleRpm = Points[index1].SpindleSpeed;
        ((camParameters5) Cam.SimilationPoint).SimMove.Add(pnt6Dsim);
      }
      pnt = new TpPnt9D(tpPnt9D);
    }
  }

  public void SimilationPointBetweenTwoPoints(
    TpPnt9D pntFirst,
    TpPnt9D pntSecond,
    ref List<Pnt6DSimMove> simPoints,
    double DevideLength = 5.0)
  {
    simPoints = new List<Pnt6DSimMove>();
    TpPnt9D tpPnt9D1 = new TpPnt9D(pntFirst);
    TpPnt9D tpPnt9D2 = new TpPnt9D(pntSecond);
    if (!tpPnt9D2.EnableAxes.X)
      ((TpArcData) tpPnt9D2).P9.X = ((TpArcData) tpPnt9D1).P9.X;
    if (!tpPnt9D2.EnableAxes.Y)
      ((TpArcData) tpPnt9D2).P9.Y = ((TpArcData) tpPnt9D1).P9.Y;
    if (!tpPnt9D2.EnableAxes.Z)
      ((TpArcData) tpPnt9D2).P9.Z = ((TpArcData) tpPnt9D1).P9.Z;
    if (!tpPnt9D2.EnableAxes.A)
      ((TpArcData) tpPnt9D2).P9.A = ((TpArcData) tpPnt9D1).P9.A;
    if (!tpPnt9D2.EnableAxes.B)
      ((TpArcData) tpPnt9D2).P9.B = ((TpArcData) tpPnt9D1).P9.B;
    if (!tpPnt9D2.EnableAxes.C)
      ((TpArcData) tpPnt9D2).P9.C = ((TpArcData) tpPnt9D1).P9.C;
    int int32 = Convert.ToInt32(buCall.\u0001.Length3D(tpPnt9D1, tpPnt9D2) / DevideLength);
    ((MachineGCodeConfigrasyon) buCall.\u0001).LineerInterpolation(TpArcData.ToPnt6DSim(tpPnt9D1), TpArcData.ToPnt6DSim(tpPnt9D2), int32, ref simPoints);
    if (simPoints.Count < 2)
      return;
    simPoints.RemoveAt(0);
  }

  public void GetStartAndEndPointOfCam(camTp Cam, ref TpPnt9D StartPoint, ref TpPnt9D EndPoint)
  {
    bool flag1 = false;
    if (Cam == null || Cam.CamPoints.Count <= 0)
      return;
    if (Cam.CamPoints[0].PrePoints.Count > 0)
    {
      StartPoint = new TpPnt9D(Cam.CamPoints[0].PrePoints[0]);
      flag1 = true;
    }
    bool flag2;
    if (!flag1 && Cam.CamPoints[0].Points.Count > 0)
    {
      StartPoint = new TpPnt9D(Cam.CamPoints[0].Points[0]);
      flag2 = true;
    }
    if (Cam.CamPoints[Cam.CamPoints.Count - 1].Points.Count > 0)
      EndPoint = new TpPnt9D(Cam.CamPoints[Cam.CamPoints.Count - 1].Points[Cam.CamPoints[Cam.CamPoints.Count - 1].Points.Count - 1]);
    if (Cam.CamPoints[Cam.CamPoints.Count - 1].AfterPoints.Count <= 0)
      return;
    EndPoint = new TpPnt9D(Cam.CamPoints[Cam.CamPoints.Count - 1].AfterPoints[Cam.CamPoints[Cam.CamPoints.Count - 1].AfterPoints.Count - 1]);
    flag2 = true;
  }

  public void LeadInOutCalculation(
    LeadInOutEntitiesProps FirstEntity,
    LeadInOutEntitiesProps LastEntitiy,
    LeadIn5 LeadInProp,
    LeadOut5 LeadOutProp,
    Plane Plane,
    ClockDirectionType Direction,
    ref List<buEntity> LeadInEntitiy,
    ref List<buEntity> LeadOutEntitiy)
  {
    try
    {
      double pointTangentAngle1 = ((ToolBase5) FirstEntity).PointTangentAngle;
      double pointTangentAngle2 = ((ToolBase5) LastEntitiy).PointTangentAngle;
      Point3D point3D1 = new Point3D();
      Point3D point3D2 = new Point3D();
      Point3D point3D3;
      if (((CustomData) ((ToolBase5) FirstEntity).RefEntity).sortDirection == entitySortDirection.Reverse)
      {
        point3D3 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) ((ToolBase5) FirstEntity).RefEntity).Vertices[((CustomDataSurrogate) ((ToolBase5) FirstEntity).RefEntity).Vertices.Count - 1]);
        if (((MWCalculationOptions) LeadInProp).ExtendLength > 0.0)
        {
          Point3D point3D4 = F_NotchEdit.ToPoint3D(point3D3);
          Point3D EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(point3D3, ((MWCalculationOptions) LeadInProp).ExtendLength, ((ToolBase5) FirstEntity).PointTangentAngle + 180.0, Plane, ref EndPnt);
          buEntity buEntity = (buEntity) new buMultilineText(EndPnt, point3D4);
          LeadInEntitiy.Add(buEntity);
          point3D3 = F_NotchEdit.ToPoint3D(EndPnt);
        }
      }
      else
      {
        point3D3 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) ((ToolBase5) FirstEntity).RefEntity).Vertices[0]);
        if (((MWCalculationOptions) LeadInProp).ExtendLength > 0.0)
        {
          Point3D point3D5 = F_NotchEdit.ToPoint3D(point3D3);
          Point3D EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(point3D3, ((MWCalculationOptions) LeadInProp).ExtendLength, ((ToolBase5) FirstEntity).PointTangentAngle + 180.0, Plane, ref EndPnt);
          buEntity buEntity = (buEntity) new buMultilineText(EndPnt, point3D5);
          LeadInEntitiy.Add(buEntity);
          point3D3 = F_NotchEdit.ToPoint3D(EndPnt);
        }
      }
      Point3D point3D6;
      if (((CustomData) ((ToolBase5) LastEntitiy).RefEntity).sortDirection == entitySortDirection.Reverse)
      {
        point3D6 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) ((ToolBase5) LastEntitiy).RefEntity).Vertices[0]);
        if (((MWCalculationOptions) LeadOutProp).ExtendLength > 0.0)
        {
          Point3D point3D7 = F_NotchEdit.ToPoint3D(point3D6);
          Point3D EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(point3D6, ((MWCalculationOptions) LeadOutProp).ExtendLength, ((ToolBase5) LastEntitiy).PointTangentAngle, Plane, ref EndPnt);
          buEntity buEntity = (buEntity) new buMultilineText(point3D7, EndPnt);
          LeadOutEntitiy.Add(buEntity);
          point3D6 = F_NotchEdit.ToPoint3D(EndPnt);
        }
      }
      else
      {
        point3D6 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) ((ToolBase5) LastEntitiy).RefEntity).Vertices[((CustomDataSurrogate) ((ToolBase5) LastEntitiy).RefEntity).Vertices.Count - 1]);
        if (((MWCalculationOptions) LeadOutProp).ExtendLength > 0.0)
        {
          Point3D point3D8 = F_NotchEdit.ToPoint3D(point3D6);
          Point3D EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(point3D6, ((MWCalculationOptions) LeadOutProp).ExtendLength, ((ToolBase5) LastEntitiy).PointTangentAngle, Plane, ref EndPnt);
          buEntity buEntity = (buEntity) new buMultilineText(point3D8, EndPnt);
          LeadOutEntitiy.Add(buEntity);
          point3D6 = F_NotchEdit.ToPoint3D(EndPnt);
        }
      }
      if (((MWCalculationOptions) LeadInProp).LeadType == LeadInOutType.Line & ((MWCalculationOptions) LeadInProp).Enable)
      {
        Point3D EndPnt = new Point3D();
        double num = 1.0;
        if (((MWCalculationOptions) LeadOutProp).ClockDir == ClockDirectionType.CCW)
          num = -1.0;
        buCall.\u0001.LineWithLengthAndAngle(point3D3, ((MWCalculationOptions) LeadInProp).Length, pointTangentAngle1 + 180.0 + ((MWCalculationOptions) LeadInProp).TangentAngle * num, Plane, ref EndPnt);
        buEntity buEntity = (buEntity) new buMultilineText(EndPnt, point3D3);
        LeadInEntitiy.Add(buEntity);
      }
      if (((MWCalculationOptions) LeadInProp).LeadType == LeadInOutType.Arc & ((MWCalculationOptions) LeadInProp).Enable)
      {
        buArc buArc = (buArc) null;
        Point3D EndPnt = new Point3D();
        if (((MWCalculationOptions) LeadInProp).ClockDir == ClockDirectionType.CW)
        {
          buCall.\u0001.LineWithLengthAndAngle(point3D3, ((MWCalculationOptions) LeadInProp).ArcRadius, pointTangentAngle1 - 90.0, Plane, ref EndPnt);
          double startAngle = buCall.\u0001.PointAngle(point3D3, EndPnt, Plane);
          double endAngle = startAngle + ((MWCalculationOptions) LeadInProp).ArcSweepAngle;
          buArc = (buArc) new buEntityList(Plane, EndPnt, ((MWCalculationOptions) LeadInProp).ArcRadius, startAngle, endAngle);
          ((CustomData) buArc).sortDirection = entitySortDirection.Reverse;
        }
        if (((MWCalculationOptions) LeadInProp).ClockDir == ClockDirectionType.CCW)
        {
          buCall.\u0001.LineWithLengthAndAngle(point3D3, ((MWCalculationOptions) LeadInProp).ArcRadius, pointTangentAngle1 + 90.0, Plane, ref EndPnt);
          double endAngle = buCall.\u0001.PointAngle(point3D3, EndPnt, Plane);
          double startAngle = endAngle - ((MWCalculationOptions) LeadInProp).ArcSweepAngle;
          buArc = (buArc) new buEntityList(Plane, EndPnt, ((MWCalculationOptions) LeadInProp).ArcRadius, startAngle, endAngle);
        }
        if (buArc != null)
          LeadInEntitiy.Insert(0, (buEntity) buArc);
      }
      if (((MWCalculationOptions) LeadOutProp).LeadType == LeadInOutType.Line & ((MWCalculationOptions) LeadOutProp).Enable)
      {
        Point3D EndPnt = new Point3D();
        double num = 1.0;
        if (((MWCalculationOptions) LeadOutProp).ClockDir == ClockDirectionType.CW)
          num = -1.0;
        buCall.\u0001.LineWithLengthAndAngle(point3D6, ((MWCalculationOptions) LeadOutProp).Length, pointTangentAngle2 + ((MWCalculationOptions) LeadOutProp).TangentAngle * num, Plane, ref EndPnt);
        buEntity buEntity = (buEntity) new buMultilineText(point3D6, EndPnt);
        LeadOutEntitiy.Add(buEntity);
      }
      if (!(((MWCalculationOptions) LeadOutProp).LeadType == LeadInOutType.Arc & ((MWCalculationOptions) LeadOutProp).Enable))
        return;
      buArc buArc1 = (buArc) null;
      Point3D EndPnt1 = new Point3D();
      if (((MWCalculationOptions) LeadOutProp).ClockDir == ClockDirectionType.CW)
      {
        buCall.\u0001.LineWithLengthAndAngle(point3D6, ((MWCalculationOptions) LeadOutProp).ArcRadius, pointTangentAngle2 - 90.0, Plane, ref EndPnt1);
        double endAngle = buCall.\u0001.PointAngle(point3D6, EndPnt1, Plane);
        double startAngle = endAngle - ((MWCalculationOptions) LeadOutProp).ArcSweepAngle;
        buArc1 = (buArc) new buEntityList(Plane, EndPnt1, ((MWCalculationOptions) LeadOutProp).ArcRadius, startAngle, endAngle);
        ((CustomData) buArc1).sortDirection = entitySortDirection.Reverse;
      }
      if (((MWCalculationOptions) LeadOutProp).ClockDir == ClockDirectionType.CCW)
      {
        buCall.\u0001.LineWithLengthAndAngle(point3D6, ((MWCalculationOptions) LeadOutProp).ArcRadius, pointTangentAngle2 + 90.0, Plane, ref EndPnt1);
        double startAngle = buCall.\u0001.PointAngle(point3D6, EndPnt1, Plane);
        double endAngle = startAngle + ((MWCalculationOptions) LeadOutProp).ArcSweepAngle;
        buArc1 = (buArc) new buEntityList(Plane, EndPnt1, ((MWCalculationOptions) LeadOutProp).ArcRadius, startAngle, endAngle);
        ((CustomData) buArc1).sortDirection = entitySortDirection.Normal;
      }
      if (buArc1 == null)
        return;
      LeadOutEntitiy.Add((buEntity) buArc1);
    }
    catch (Exception ex)
    {
      string str = $"FirstEntity: {FirstEntity.ToString()} - LastEntitiyEntity: {LastEntitiy.ToString()} - In: {LeadInProp.ToString()} - Out: {LeadOutProp.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LeadInOutCalculation(
    buEntity FirstEntity,
    buEntity LastEntitiy,
    LeadIn In,
    LeadOut Out,
    Plane Plane,
    ClockDirectionType Direction,
    ref buEntity LeadInEntitiy,
    ref buEntity LeadOutEntitiy)
  {
    try
    {
      Point3D point3D1 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[0]);
      Point3D point3D2 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntitiy).Vertices[((CustomDataSurrogate) LastEntitiy).Vertices.Count - 1]);
      double num1 = !(FirstEntity.GetType() == typeof (buArc)) ? buCall.\u0001.PointAngle(((CustomDataSurrogate) FirstEntity).Vertices[1], ((CustomDataSurrogate) FirstEntity).Vertices[0], Plane) : ((CustomDataSurrogate) FirstEntity).StartAngle + 90.0;
      double num2 = !(LastEntitiy.GetType() == typeof (buArc)) ? buCall.\u0001.PointAngle(((CustomDataSurrogate) FirstEntity).Vertices[((CustomDataSurrogate) FirstEntity).Vertices.Count - 2], ((CustomDataSurrogate) FirstEntity).Vertices[((CustomDataSurrogate) FirstEntity).Vertices.Count - 1], Plane) : ((CustomDataSurrogate) FirstEntity).EndAngle - 90.0;
      if (((CustomData) FirstEntity).sortDirection == entitySortDirection.Reverse)
      {
        point3D1 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[((CustomDataSurrogate) FirstEntity).Vertices.Count - 1]);
        point3D2 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntitiy).Vertices[0]);
        num1 = !(FirstEntity.GetType() == typeof (buArc)) ? buCall.\u0001.PointAngle(((CustomDataSurrogate) FirstEntity).Vertices[0], ((CustomDataSurrogate) FirstEntity).Vertices[1], Plane) : ((CustomDataSurrogate) FirstEntity).EndAngle - 90.0;
        num2 = !(LastEntitiy.GetType() == typeof (buArc)) ? buCall.\u0001.PointAngle(((CustomDataSurrogate) FirstEntity).Vertices[((CustomDataSurrogate) FirstEntity).Vertices.Count - 1], ((CustomDataSurrogate) FirstEntity).Vertices[((CustomDataSurrogate) FirstEntity).Vertices.Count - 2], Plane) : ((CustomDataSurrogate) FirstEntity).StartAngle + 90.0;
      }
      if (In.LeadType == LeadInOutType.Line)
      {
        Point3D EndPnt = new Point3D();
        buCall.\u0001.LineWithLengthAndAngle(point3D1, In.Length, num1 + 180.0 + In.TangentAngle, Plane, ref EndPnt);
        LeadInEntitiy = (buEntity) new buMultilineText(EndPnt, point3D1);
      }
      if (In.LeadType == LeadInOutType.Arc)
      {
        Point3D EndPnt = new Point3D();
        buCall.\u0001.LineWithLengthAndAngle(point3D1, In.ArcRadius, num1 + In.ArcSweepAngle, Plane, ref EndPnt);
        double endAngle = buCall.\u0001.PointAngle(point3D1, EndPnt, Plane);
        double startAngle = endAngle - In.ArcSweepAngle;
        LeadInEntitiy = (buEntity) new buEntityList(Plane, EndPnt, In.ArcRadius, startAngle, endAngle);
      }
      if (Out.LeadType == LeadInOutType.Line)
      {
        Point3D EndPnt = new Point3D();
        buCall.\u0001.LineWithLengthAndAngle(point3D2, Out.Length, num2 + 180.0 + Out.TangentAngle, Plane, ref EndPnt);
        LeadOutEntitiy = (buEntity) new buMultilineText(point3D2, EndPnt);
      }
      if (Out.LeadType != LeadInOutType.Arc)
        return;
      Point3D EndPnt1 = new Point3D();
      buCall.\u0001.LineWithLengthAndAngle(point3D2, In.ArcRadius, num2 + 180.0 + In.ArcSweepAngle, Plane, ref EndPnt1);
      double startAngle1 = buCall.\u0001.PointAngle(point3D2, EndPnt1, Plane);
      double endAngle1 = startAngle1 + In.ArcSweepAngle;
      LeadOutEntitiy = (buEntity) new buEntityList(Plane, EndPnt1, In.ArcRadius, startAngle1, endAngle1);
    }
    catch (Exception ex)
    {
      string str = $"FirstEntity: {FirstEntity.ToString()} - LastEntitiyEntity: {LastEntitiy.ToString()} - In: {In.ToString()} - Out: {Out.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculateMarbleItem(
    List<List<eEntities>> Entities,
    KinematicBase Kinematic,
    ToolBase Tool,
    MarbleItemSettings OperationPars,
    marbleCamPars CamPars,
    camSpeeds Speed,
    camDistances Distance,
    ref camTp calcCam)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D P1 = new Pnt6D();
      calcCam = new camTp();
      calcCam.Tool = (ToolBase5) new ToolGeometry5(Tool);
      camTpPoint camTpPoint1 = (camTpPoint) new TpPnt9D();
      // ISSUE: reference to a compiler-generated field
      if (this.\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.\u0002(new CalculationEventArg());
      }
      int int32 = Convert.ToInt32((double) Entities.Count / 100.0);
      int num1 = 0;
      double safe1 = Distance.Safe;
      for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
      {
        eEntities copiedEnt1 = new eEntities();
        if (Entities[index1].Count > 0)
        {
          eEntities copiedEnt2 = new eEntities();
          List<Pnt3D> TargetList1 = new List<Pnt3D>();
          eEntities.CopyEntity(Entities[index1][0], ref copiedEnt2);
          buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList1);
          if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
            TargetList1.Reverse();
          camTpPoint camTpPoint2 = (camTpPoint) new TpPnt9D();
          camTpPoint2.Type = 0;
          double safe2 = Distance.Safe;
          double feed1 = Speed.Feed;
          Pnt3D calcPoint = new Pnt3D();
          Pnt3D BasePoint1 = new Pnt3D(TargetList1[0]);
          Pnt3D pnt3D2 = new Pnt3D(TargetList1[TargetList1.Count - 1]);
          Pnt3D pnt3D3 = new Pnt3D();
          OrientationAngle Orientation = new OrientationAngle(copiedEnt2.Orientation);
          OrientationAngle orientationAngle1 = new OrientationAngle();
          OrientationAngle orientationAngle2 = new OrientationAngle();
          feed1 = Speed.Feed;
          double Length1 = (safe1 - BasePoint1.Z) / Math.Cos(buConversion.DegreeToRadian(Orientation.A));
          Pnt6D CalcPoint = new Pnt6D();
          double ToolLength = Tool.Geometry.Diameter / 2.0;
          ((ToolGeometry5) calcCam.Tool).Geometry.Length = ToolLength;
          calcPoint = new Pnt3D();
          pnt3D3 = new Pnt3D(BasePoint1.X, BasePoint1.Y, 0.0);
          buCall.\u0001.LineWithOrientationAngle(BasePoint1, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length1, ref calcPoint);
          buCall.\u0001.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(calcPoint), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, Speed.Rapid, 0));
          if (index1 == 0)
            P1 = new Pnt6D(CalcPoint.X, CalcPoint.Y, CalcPoint.Z, 0.0, 0.0, Orientation.C);
          Pnt3D P2 = new Pnt3D(calcPoint);
          Pnt3D pnt3D4 = new Pnt3D(BasePoint1.X, BasePoint1.Y, BasePoint1.Z);
          buCall.\u0001.LineWithOrientationAngle(pnt3D4, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Distance.Safe, ref calcPoint);
          buCall.\u0001.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(calcPoint), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, Speed.Plunge, 1));
          Line line1 = new Line(buString5.Pnt3DToPoint3D(P2), buString5.Pnt3DToPoint3D(pnt3D4));
          line1.Color = this.varCam.CamG1Draw.Color;
          line1.ColorMethod = colorMethodType.byEntity;
          calcCam.EntitiesG1.Add((Entity) line1);
          Pnt3D P3 = new Pnt3D(calcPoint);
          for (int index2 = 0; index2 <= Entities[index1].Count - 1; ++index2)
          {
            double feed2 = Speed.Feed;
            if (Entities[index1][index2].auxText != null && Entities[index1][index2].auxText == "Backward")
              feed2 = Speed.BackwardFeed;
            copiedEnt2 = new eEntities();
            List<Pnt3D> TargetList2 = new List<Pnt3D>();
            eEntities.CopyEntity(Entities[index1][index2], ref copiedEnt2);
            buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList2);
            if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
              TargetList2.Reverse();
            calcPoint = new Pnt3D();
            Pnt3D P4 = new Pnt3D(TargetList2[0]);
            pnt3D2 = new Pnt3D(TargetList2[TargetList2.Count - 1]);
            pnt3D3 = new Pnt3D();
            Orientation = new OrientationAngle(copiedEnt2.Orientation);
            CalcPoint = new Pnt6D();
            Pnt3D Pnt1 = new Pnt3D(P4.X, P4.Y, P4.Z);
            buCall.\u0001.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(Pnt1), ref CalcPoint);
            CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
            camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, Speed.Plunge, 1));
            Line line2 = new Line(buString5.Pnt3DToPoint3D(P3), buString5.Pnt3DToPoint3D(P4));
            line2.Color = this.varCam.CamG1Draw.Color;
            line2.ColorMethod = colorMethodType.byEntity;
            calcCam.EntitiesG1.Add((Entity) line2);
            CalcPoint = new Pnt6D();
            Pnt3D Pnt2 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
            buCall.\u0001.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(Pnt2), ref CalcPoint);
            CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
            camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, feed2, 1));
            Line line3 = new Line(buString5.Pnt3DToPoint3D(P4), buString5.Pnt3DToPoint3D(pnt3D2));
            line3.Color = this.varCam.CamG1Draw.Color;
            line3.ColorMethod = colorMethodType.byEntity;
            calcCam.EntitiesG1.Add((Entity) line3);
            P3 = new Pnt3D(pnt3D2);
          }
          double Length2 = (Distance.Safe - pnt3D2.Z) / Math.Cos(buConversion.DegreeToRadian(Orientation.A));
          double num2 = (((MarbleCamType) ((MarbleMachineSimultionSettings) OperationPars).MaterialParameter).MaterialThickness + Distance.StepUp - pnt3D2.Z) / Math.Cos(buConversion.DegreeToRadian(Orientation.A));
          if (Orientation.A != orientationAngle1.A)
            ;
          if (index1 == Entities.Count - 1)
            ;
          CalcPoint = new Pnt6D();
          Pnt3D BasePoint2 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
          calcPoint = new Pnt3D();
          buCall.\u0001.LineWithOrientationAngle(BasePoint2, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length2, ref calcPoint);
          buCall.\u0001.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(calcPoint), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, Speed.Leave, 1));
          Line line4 = new Line(buString5.Pnt3DToPoint3D(pnt3D2), buString5.Pnt3DToPoint3D(calcPoint));
          line4.Color = this.varCam.CamG0Draw.Color;
          line4.ColorMethod = colorMethodType.byEntity;
          calcCam.EntitiesG0.Add((Entity) line4);
          for (int index3 = 1; index3 <= camTpPoint2.Points.Count - 1; ++index3)
          {
            List<Pnt6DSimMove> collection = new List<Pnt6DSimMove>();
            if (camTpPoint2.Points[index3].Type == 0)
              ;
            ((camParameters5) calcCam.SimilationPoint).SimMove.AddRange((IEnumerable<Pnt6DSimMove>) collection);
          }
          pnt3D1 = new Pnt3D(pnt3D2);
          eEntities.CopyEntity(copiedEnt2, ref copiedEnt1);
          calcCam.CamPoints.Add(camTpPoint2);
        }
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.\u0001(new CalculationEventArg(50.0, Convert.ToDouble((double) index1 / (double) (Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & int32 > 0 & num1 > 0 && num1 % int32 == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num1;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.\u0003 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.\u0003(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.\u0004 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.\u0004(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble Code", ""));
          }
          buLog.addLog("Calculate Marble Code", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      camTpPoint camTpPoint3 = (camTpPoint) new TpPnt9D();
      camTpPoint3.Type = 0;
      camTpPoint3.Points.Add(new TpPnt9D(P1, Speed.Rapid, 0));
      calcCam.CamPoints.Add(camTpPoint3);
      // ISSUE: reference to a compiler-generated field
      if (this.\u0003 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.\u0003(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculateMarbleWireFrameWithSaw(
    List<List<buEntity>> Entities,
    List<List<buEntity>> ReCalculatedEntities,
    KinematicBase5 Kinematic,
    ToolBase5 Tool,
    MarbleItemSettings Operation,
    camParameters5 camPar,
    EntitiesResolution Resolution,
    ref MarbleItem Item)
  {
    try
    {
      List<List<buEntity>> copiedEntities = new List<List<buEntity>>();
      if (((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).ReadSurfaceParameter).ApplySurfaceReadData & ((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).ReadSurfaceParameter).SurfaceReadDevideLength > 0.0 & MarbleProgramSettings.pntTeachGrids.Count > 0)
      {
        for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
        {
          List<buEntity> buEntityList = new List<buEntity>();
          List<Point3D> Points = new List<Point3D>();
          EntitiesResolution entitiesResolution = new EntitiesResolution()
          {
            ArcResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            CircleResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            CurveResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            EllipseResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            LineResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            OtherResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            PolylineResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength)
          };
          buCall.\u0001.EntitiesToPointsWithCamDirection(Entities[index1], 0.01, ref Points);
          Points[Points.Count - 1] = new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, 5.0);
          for (int index2 = 0; index2 <= Points.Count - 1; ++index2)
          {
            double num = 0.0;
            int index3 = Convert.ToInt32(Points[index2].X);
            int index4 = Convert.ToInt32(Points[index2].Y);
            if (index3 < 0)
              index3 = 0;
            if (index4 < 0)
              index4 = 0;
            if (index4 >= 0 & index4 <= MarbleProgramSettings.pntTeachGrids.Count - 1 && index3 >= 0 & index3 <= MarbleProgramSettings.pntTeachGrids[index4].Count - 1)
              num = MarbleProgramSettings.pntTeachGrids[index4][index3].Z;
            Points[index2] = new Point3D(Points[index2].X, Points[index2].Y, Points[index2].Z + num);
          }
          buLinearPath buLinearPath = (buLinearPath) new buShape(Points);
          ((CustomDataSurrogate) buLinearPath).Orientation = new OrientationAngle(((CustomDataSurrogate) Entities[index1][0]).Orientation);
          buEntityList.Add((buEntity) buLinearPath);
          copiedEntities.Add(buEntityList);
        }
      }
      else
        buRadialDim.Copy(Entities, ref copiedEntities);
      bool useTangentLimit = camPar.Strategy.UseTangentLimit;
      Point3D point3D1 = new Point3D();
      Pnt6D pnt6D1 = new Pnt6D();
      double angleLimit = camPar.Strategy.AngleLimit;
      List<Triangle3D> triangles = new List<Triangle3D>();
      ((MarbleScreenCaptureSettings) Item).CamList = new List<MarbleItemCam>();
      MarbleItemCam marbleItemCam = (MarbleItemCam) new marbleMenuType();
      camTp data = new camTp();
      data.Tool = (ToolBase5) new ToolGeometry5(Tool);
      data.Kinematic = (KinematicBase5) new OsnapPoint(Kinematic);
      KinematicItem kinematicItem = new KinematicItem()
      {
        Axis = {
          A = true,
          C = true
        }
      };
      eSurface eSurface = new eSurface(triangles, ((ToolCamData5) ((ToolGeometry5) Tool).Display).Solid.SkinColor);
      ((OsnapCoordinateCatch) data.Kinematic).MovePartRuntimeOffset.X = 0.0;
      ((OsnapCoordinateCatch) data.Kinematic).MovePartRuntimeOffset.Y = -((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y;
      ((OsnapCoordinateCatch) data.Kinematic).MovePartRuntimeOffset.Z = -((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z;
      camTpPoint camTpPoint1 = (camTpPoint) new TpPnt9D();
      List<List<Pnt6D>> pnt6DListList1 = new List<List<Pnt6D>>();
      int CalcEventCount = 1;
      int num1 = 0;
      Pnt6D pnt6D2 = new Pnt6D();
      Pnt6D pnt6D3 = new Pnt6D();
      OrientationAngle orientationAngle1 = new OrientationAngle();
      Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
      if (ReCalculatedEntities.Count > 0)
        buRadialDim.Copy(ReCalculatedEntities, ref copiedEntities);
      if (copiedEntities.Count <= 10)
        CalcEventCount = 1;
      buGeneral.DoEventCountCalc(copiedEntities.Count, ref CalcEventCount);
      for (int index5 = 0; index5 <= copiedEntities.Count - 1; ++index5)
      {
        List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
        List<List<Pnt6D>> pnt6DListList2 = new List<List<Pnt6D>>();
        if (copiedEntities[index5].Count >= 1)
        {
          List<Pnt6D> Points = new List<Pnt6D>();
          List<Pnt6D> pnt6DList2 = new List<Pnt6D>();
          buCall.\u0001.EntitiesToPointsWithCamDirection(copiedEntities[index5], ref Points, true);
          ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Points);
          if (Points.Count > 1)
          {
            double num2 = 0.0;
            double num3 = buCall.\u0001.PointAngle(new Point3D(Points[1].X, Points[1].Y, Points[1].Z), new Point3D(Points[0].X, Points[0].Y, Points[0].Z));
            if (((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).UseCZero)
              num3 = 0.0;
            if (copiedEntities[index5].Count == 1 & Points[0].C != 0.0)
              ;
            double c1 = num3 + ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).OffsetAngleC;
            if (c1 > 360.0)
              c1 -= 360.0;
            if (c1 < -360.0)
              c1 += 360.0;
            if (((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).UseConstantCAngle)
              c1 = ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).ConstantAngleC;
            double num4 = c1;
            pnt6DList1.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, c1));
            for (int index6 = 1; index6 <= Points.Count - 2; ++index6)
            {
              bool flag = false;
              double num5 = buCall.\u0001.PointAngle(new Point3D(Points[index6].X, Points[index6].Y, Points[index6].Z), new Point3D(Points[index6 - 1].X, Points[index6 - 1].Y, Points[index6 - 1].Z));
              if (((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).UseCZero)
                num5 = 0.0;
              if (index6 == 90)
                ;
              double c2 = num5 + ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).OffsetAngleC;
              if (c2 > 360.0)
                c2 -= 360.0;
              if (c2 < -360.0)
                c2 += 360.0;
              if (((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).UseConstantCAngle)
                c2 = ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).ConstantAngleC;
              if (((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).NoAngleCAxisCheck)
              {
                pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
              }
              else
              {
                double c3;
                double num6;
                if (useTangentLimit)
                {
                  num2 = Points[index6 - 1].A - Points[index6].A;
                  if (Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C) > 185.0)
                  {
                    if (pnt6DList1[pnt6DList1.Count - 1].C > c2)
                      c2 += 360.0;
                    else
                      c2 -= 360.0;
                  }
                  double num7 = buCall.\u0001.PointAngle(new Point3D(Points[index6 + 1].X, Points[index6 + 1].Y, Points[index6 + 1].Z), new Point3D(Points[index6].X, Points[index6].Y, Points[index6].Z));
                  if (((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).UseCZero)
                    num7 = 0.0;
                  c3 = num7 + ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).OffsetAngleC;
                  angleLimit = camPar.Strategy.AngleLimit;
                  double num8 = buCall.\u0001.AngleOfTwoLines(buString5.Pnt6DToPoint3D(pnt6DList1[pnt6DList1.Count - 1]), buString5.Pnt6DToPoint3D(Points[index6]), buString5.Pnt6DToPoint3D(Points[index6]), buString5.Pnt6DToPoint3D(Points[index6 + 1]), Plane.XY);
                  num6 = 180.0 - num8;
                  if (num6 >= 360.0 - angleLimit)
                    num6 = 360.0 - num8;
                  Math.Abs(c2 - num4);
                  if (Math.Abs(num2) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
                  {
                    pnt6DListList2.Add(pnt6DList1);
                    pnt6DList1 = new List<Pnt6D>();
                    pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c3));
                    flag = true;
                  }
                }
                else
                {
                  angleLimit = camPar.Strategy.AngleLimit;
                  double num9 = buCall.\u0001.AngleOfTwoLines(buString5.Pnt6DToPoint3D(pnt6DList1[pnt6DList1.Count - 1]), buString5.Pnt6DToPoint3D(Points[index6]), buString5.Pnt6DToPoint3D(Points[index6]), buString5.Pnt6DToPoint3D(Points[index6 + 1]), Plane.XY);
                  num6 = 180.0 - num9;
                  if (num6 >= 360.0 - angleLimit)
                    num6 = 360.0 - num9;
                  c3 = buCall.\u0001.PointAngle(buString5.Pnt6DToPoint3D(Points[index6 + 1]), buString5.Pnt6DToPoint3D(Points[index6]));
                  if (((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).UseCZero)
                    c3 = 0.0;
                  if (num6 > angleLimit)
                  {
                    pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                    pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6 + 1].A, 0.0, c3));
                    flag = true;
                  }
                  Math.Abs(c2 - num4);
                  if (Math.Abs(num2) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
                  {
                    pnt6DListList2.Add(pnt6DList1);
                    pnt6DList1 = new List<Pnt6D>();
                    pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c3));
                    flag = true;
                  }
                }
                if (!flag)
                {
                  if (num6 > angleLimit & useTangentLimit)
                  {
                    pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                    pnt6DListList2.Add(pnt6DList1);
                    pnt6DList1 = new List<Pnt6D>();
                    pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6 + 1].A, 0.0, c3));
                  }
                  else
                  {
                    if (useTangentLimit)
                    {
                      double num10 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                      if (num10 >= 360.0 - angleLimit)
                      {
                        if (c2 > pnt6DList1[pnt6DList1.Count - 1].C)
                          c2 -= 360.0;
                        else
                          c2 += 360.0;
                        num10 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                      }
                      if (num10 > 185.0)
                        c2 += 360.0;
                    }
                    pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                    if (Math.Abs(c2 - c3) > 180.1)
                    {
                      double num11 = c2 - c3;
                      if (c2 > c3)
                      {
                        double num12 = c3 + 360.0;
                        double lower = buNumeric.RoundToLower(Math.Abs(c2 - num12) / 360.0);
                        c3 = num12 + lower * 360.0;
                      }
                      else
                      {
                        double num13 = c3 - 360.0;
                        double lower = buNumeric.RoundToLower(Math.Abs(c2 - num13) / 360.0);
                        c3 = num13 - lower * 360.0;
                      }
                    }
                    if (camPar.Options.AxesLimit.MinLimit != camPar.Options.AxesLimit.MaxLimit)
                    {
                      if (c3 > camPar.Options.AxesLimit.MaxLimit.C)
                      {
                        pnt6DListList2.Add(pnt6DList1);
                        c2 -= 360.0;
                        pnt6DList1 = new List<Pnt6D>();
                        pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                      }
                      if (c3 < camPar.Options.AxesLimit.MinLimit.C)
                      {
                        pnt6DListList2.Add(pnt6DList1);
                        c2 += 360.0;
                        pnt6DList1 = new List<Pnt6D>();
                        pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                      }
                    }
                  }
                }
              }
              num4 = c2;
            }
            if (pnt6DList1.Count > 0)
            {
              double num14 = buCall.\u0001.PointAngle(buString5.Pnt6DToPoint3D(Points[Points.Count - 1]), buString5.Pnt6DToPoint3D(Points[Points.Count - 2]));
              if (((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).UseCZero)
                num14 = 0.0;
              if (copiedEntities[index5].Count == 1 & Points[Points.Count - 1].C != 0.0)
                ;
              double c4 = num14 + ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).OffsetAngleC;
              if (c4 > 360.0)
                c4 -= 360.0;
              if (c4 < -360.0)
                c4 += 360.0;
              if (((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).UseConstantCAngle)
                c4 = ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).ConstantAngleC;
              double num15 = Math.Abs(c4 - pnt6DList1[pnt6DList1.Count - 1].C);
              if (num15 >= 360.0 - angleLimit)
              {
                num15 = 360.0 - c4;
                if (c4 > pnt6DList1[pnt6DList1.Count - 1].C)
                  c4 -= 360.0;
              }
              if (num15 > 185.0)
                c4 += 360.0;
              pnt6DList1.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, c4));
              pnt6DListList2.Add(pnt6DList1);
            }
          }
        }
        for (int index7 = 0; index7 <= pnt6DListList2.Count - 1; ++index7)
        {
          double ToolLength = ((ToolGeometry5) Tool).Geometry.Diameter / 2.0;
          double num16 = 0.0;
          Pnt6D pnt6D4 = new Pnt6D();
          Pnt6D pnt6D5 = new Pnt6D();
          Pnt6D CalcPoint = new Pnt6D();
          Point3D point3D2 = new Point3D();
          Point3D calcPoint = new Point3D();
          Point3D point3D3 = new Point3D();
          OrientationAngle orientationAngle2 = new OrientationAngle();
          OrientationAngle orientationAngle3 = new OrientationAngle();
          if (index5 <= copiedEntities.Count - 2)
            orientationAngle3 = new OrientationAngle(((CustomDataSurrogate) copiedEntities[index5 + 1][0]).Orientation);
          camTpPoint camTpPoint2 = (camTpPoint) new TpPnt9D();
          camTpPoint2.Type = 0;
          Pnt6D Pnt1 = new Pnt6D(pnt6DListList2[index7][0]);
          Point3D point3D4 = F_NotchEdit.ToPoint3D(Pnt1);
          OrientationAngle orientationAngle4 = new OrientationAngle(Pnt1);
          double forwardCuttingVelocity = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).SawForwardCuttingVelocity;
          double Length1 = (!((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).AlwaysSafeDistance ? (index5 != 0 ? (((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).MaterialParameter).MaterialThickness + ((marbleCollapseItem) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).SawRapidDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A)) : (((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).MaterialParameter).MaterialThickness + ((marbleCollapseItem) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).SawSafeDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A))) : (((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).MaterialParameter).MaterialThickness + ((marbleCollapseItem) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).SawSafeDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A))) - point3D4.Z;
          CalcPoint = new Pnt6D();
          calcPoint = new Point3D();
          buCall.\u0001.LineWithOrientationAngle(point3D4, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length1, ref calcPoint);
          ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, F_NotchEdit.ToPoint3D(calcPoint), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
          if (orientationAngle4.A != orientationAngle1.A && pnt6D3.Z > CalcPoint.Z)
            CalcPoint.Z = pnt6D3.Z;
          camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, camPar.Speeds.Rapid, 0, true));
          point3D1 = F_NotchEdit.ToPoint3D(calcPoint);
          Pnt6D pnt6D6 = new Pnt6D(CalcPoint);
          CalcPoint = new Pnt6D();
          calcPoint = new Point3D();
          buCall.\u0001.LineWithOrientationAngle(point3D4, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length1, ref calcPoint);
          ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, F_NotchEdit.ToPoint3D(calcPoint), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
          camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, camPar.Speeds.Rapid, 0));
          Point3D point3D5 = F_NotchEdit.ToPoint3D(calcPoint);
          Pnt6D pnt6D7 = new Pnt6D(CalcPoint);
          if (index7 == 0)
          {
            Pnt6D pnt6D8 = new Pnt6D(CalcPoint);
          }
          CalcPoint = new Pnt6D();
          Point3D Pnt2 = new Point3D(point3D4.X, point3D4.Y, point3D4.Z);
          ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, F_NotchEdit.ToPoint3D(Pnt2), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
          camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, camPar.Speeds.Plunge, 1));
          Line line1 = new Line(F_NotchEdit.ToPoint3D(point3D5), F_NotchEdit.ToPoint3D(Pnt2));
          line1.Color = this.varCam.CamG1Draw.Color;
          line1.ColorMethod = colorMethodType.byEntity;
          data.EntitiesG1.Add((Entity) line1);
          Point3D point3D6 = F_NotchEdit.ToPoint3D(point3D4);
          Pnt6D pnt6D9 = new Pnt6D(CalcPoint);
          List<Point3D> Pnt3 = new List<Point3D>();
          Pnt3.Add(F_NotchEdit.ToPoint3D(point3D6));
          for (int index8 = 1; index8 <= pnt6DListList2[index7].Count - 1; ++index8)
          {
            Pnt1 = new Pnt6D(pnt6DListList2[index7][index8]);
            if (index8 == 1)
            {
              Pnt1.X += 0.02;
              Pnt1.Y += 0.02;
            }
            orientationAngle4 = new OrientationAngle(Pnt1);
            CalcPoint = new Pnt6D();
            Point3D point3D7 = F_NotchEdit.ToPoint3D(Pnt1);
            ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, point3D7, ref CalcPoint);
            CalcPoint.Z = CalcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
            camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, forwardCuttingVelocity, 1));
            Pnt3.Add(F_NotchEdit.ToPoint3D(point3D7));
            point3D6 = F_NotchEdit.ToPoint3D(Pnt1);
            Pnt6D pnt6D10 = new Pnt6D(CalcPoint);
            OrientationAngle orientationAngle5 = new OrientationAngle(orientationAngle4);
            if (index8 == 1)
              camTpPoint2.Points[camTpPoint2.Points.Count - 1].PreCodes.Add((object) "G38 O1");
          }
          camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add((object) "G39 O1");
          if (Pnt3.Count > 0)
          {
            LinearPath linearPath = new LinearPath((ICollection<Point3D>) F_AnalyseResult.ToPoint3D(Pnt3));
            linearPath.Color = this.varCam.CamG1Draw.Color;
            linearPath.ColorMethod = colorMethodType.byEntity;
            data.EntitiesG1.Add((Entity) linearPath);
          }
          if (((MarbleProgramSettings) Item).SawExtensionDistance > 0.0 && Pnt3.Count > 1)
          {
            Point3D EndPnt = new Point3D();
            double num17 = buCall.\u0001.PointAngle(Pnt3[1], Pnt3[0]);
            buCall.\u0001.LineWithLengthAndAngle(Pnt3[0], ((MarbleProgramSettings) Item).SawExtensionDistance, num17 + 180.0, Plane.XY, ref EndPnt);
            buLine buLine1 = (buLine) new buMultilineText(F_NotchEdit.ToPoint3D(Pnt3[0]), F_NotchEdit.ToPoint3D(EndPnt));
            ((CustomDataSurrogate) buLine1).typeDefination = entityTypeDefination.MarbleItem;
            ((CustomData) buLine1).Marble = (MarbleInfo) new Line2D();
            ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities.Add((buEntity) buLine1);
            EndPnt = new Point3D();
            double Angle = buCall.\u0001.PointAngle(Pnt3[Pnt3.Count - 1], Pnt3[Pnt3.Count - 2]);
            buCall.\u0001.LineWithLengthAndAngle(Pnt3[Pnt3.Count - 1], ((MarbleProgramSettings) Item).SawExtensionDistance, Angle, Plane.XY, ref EndPnt);
            buLine buLine2 = (buLine) new buMultilineText(F_NotchEdit.ToPoint3D(Pnt3[Pnt3.Count - 1]), F_NotchEdit.ToPoint3D(EndPnt));
            ((CustomDataSurrogate) buLine1).typeDefination = entityTypeDefination.MarbleItem;
            ((CustomData) buLine2).Marble = (MarbleInfo) new Line2D();
            ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities.Add((buEntity) buLine2);
          }
          num16 = (camPar.Distances.Safe - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
          double num18 = (((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).MaterialParameter).MaterialThickness + ((camHole5) camPar.Distances).StepUp - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
          bool flag = orientationAngle4.A != orientationAngle3.A;
          if (index5 == copiedEntities.Count - 1)
            flag = true;
          CalcPoint = new Pnt6D();
          calcPoint = new Point3D();
          double Length2 = (!((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).AlwaysSafeDistance ? (((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).MaterialParameter).MaterialThickness + ((marbleCollapseItem) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).SawRapidDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A)) : (((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).MaterialParameter).MaterialThickness + ((marbleCollapseItem) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).SawSafeDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A))) - point3D6.Z;
          buCall.\u0001.LineWithOrientationAngle(point3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length2, ref calcPoint);
          ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, calcPoint, ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
          camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, ((camSpeedsEnable) camPar.Speeds).Leave, 1));
          Line line2 = new Line(point3D6, calcPoint);
          line2.Color = this.varCam.CamG1Draw.Color;
          line2.ColorMethod = colorMethodType.byEntity;
          data.EntitiesG1.Add((Entity) line2);
          orientationAngle1 = new OrientationAngle(orientationAngle4);
          if (flag)
          {
            double Length3 = (((MarbleCamType) ((MarbleMachineSimultionSettings) Operation).MaterialParameter).MaterialThickness + ((marbleCollapseItem) ((MarbleMachineSimultionSettings) Operation).settingMarbleCam).SawSafeDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
            CalcPoint = new Pnt6D();
            calcPoint = new Point3D();
            buCall.\u0001.LineWithOrientationAngle(point3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length3, ref calcPoint);
            ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, F_NotchEdit.ToPoint3D(calcPoint), ref CalcPoint);
            CalcPoint.Z = CalcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
            camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, camPar.Speeds.Rapid, 0));
            Line line3 = new Line(point3D6, calcPoint);
            line3.Color = this.varCam.CamG0Draw.Color;
            line3.ColorMethod = colorMethodType.byEntity;
            data.EntitiesG1.Add((Entity) line3);
          }
          pnt6D3 = new Pnt6D(CalcPoint);
          if (camTpPoint2.Points.Count > 0)
            ;
          data.CamPoints.Add(camTpPoint2);
        }
        int num19 = 0;
        while (num19 <= copiedEntities[index5].Count - 1)
          ++num19;
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.\u0001 != null && CalcEventCount > 0 & num1 > 0 && num1 % CalcEventCount == 0)
        {
          // ISSUE: reference to a compiler-generated field
          this.\u0001(new CalculationEventArg(Convert.ToDouble((double) index5 / (double) (copiedEntities.Count - 1)) * 100.0, Convert.ToDouble((double) index5 / (double) (copiedEntities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & CalcEventCount > 0 & num1 > 0 && num1 % CalcEventCount == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num1;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.\u0003 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.\u0003(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.\u0004 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.\u0004(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
          }
          buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      ((MarbleMachineOptionsSettings) marbleItemCam).CamBase = new camTp(data);
      ((MarbleMachineOptionsSettings) marbleItemCam).ToolSelected = (ToolBase5) new ToolGeometry5(Tool);
      ((MarbleScreenCaptureSettings) Item).CamList.Add(marbleItemCam);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculatePointsWithKinematic(
    List<Pnt6D> refPoints,
    KinematicBase5 Kinematic,
    ToolBase5 Tool,
    ref List<Pnt6D> calcPoints)
  {
    try
    {
      double ToolLength = ((ToolGeometry5) Tool).Geometry.Diameter / 2.0;
      for (int index = 0; index <= refPoints.Count - 1; ++index)
      {
        Pnt6D refPoint = refPoints[index];
        OrientationAngle Orientation = new OrientationAngle(refPoints[index].A, refPoints[index].B, refPoints[index].C);
        Pnt6D CalcPoint = new Pnt6D();
        Point3D point3D = F_NotchEdit.ToPoint3D(refPoints[index]);
        ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, point3D, ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
        calcPoints.Add(CalcPoint);
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculatePointsWithKinematicMilling(
    List<Pnt6D> refPoints,
    KinematicBase5 Kinematic,
    ToolBase5 Tool,
    ref List<Pnt6D> calcPoints)
  {
    try
    {
      for (int index = 0; index <= refPoints.Count - 1; ++index)
      {
        Pnt6D refPoint = refPoints[index];
        OrientationAngle Orientation = new OrientationAngle(refPoints[index].A, refPoints[index].B, refPoints[index].C);
        Pnt6D CalcPoint = new Pnt6D();
        Point3D point3D = F_NotchEdit.ToPoint3D(refPoints[index]);
        ((buConversion5) buCall.\u0001).ForwardKinematix5AxMilling(((ToolGeometry5) Tool).Geometry.Length, Kinematic, Orientation, point3D, ref CalcPoint);
        CalcPoint.Z += ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z;
        calcPoints.Add(CalcPoint);
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }
}
