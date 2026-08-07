// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleChamferBothSidePars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleChamferBothSidePars : buSerilization5
{
  public static List<string> Captions;
  public static byte f004C7E;
  public bool isClosed;
  public bool isReverseAngleA;
  public bool isToolSaw;

  public void EntityCornerModifyByConvexConcave(
    buEntity FirstEntity,
    buEntity LastEntity,
    ClockDirectionType ClockDir,
    bool ReverseThetaCalculation,
    double ModifyLength,
    ref buEntity ModifiedFirstEntity,
    ref buEntity ModifiedLastEntity)
  {
    ModifiedFirstEntity = (buEntity) new buMultilineText();
    ModifiedLastEntity = (buEntity) new buMultilineText();
    bool isTouch = false;
    StartEndType FirstEntityTouchPoint = StartEndType.Start;
    StartEndType SecondEntityTouchPoint = StartEndType.Start;
    buCall.\u0001.EntityEntityTouchPoint(FirstEntity, LastEntity, 0.01, ref isTouch, ref FirstEntityTouchPoint, ref SecondEntityTouchPoint);
    Point3D point3D1 = new Point3D();
    Point3D point3D2 = new Point3D();
    Point3D point3D3 = new Point3D();
    Point3D point3D4 = new Point3D();
    Point3D point3D5;
    Point3D point3D6;
    if (FirstEntityTouchPoint == StartEndType.End)
    {
      point3D5 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[((CustomDataSurrogate) FirstEntity).Vertices.Count - 1]);
      point3D6 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[((CustomDataSurrogate) FirstEntity).Vertices.Count - 2]);
    }
    else
    {
      point3D5 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[0]);
      point3D6 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[1]);
    }
    Point3D point3D7;
    Point3D point3D8;
    if (SecondEntityTouchPoint == StartEndType.End)
    {
      point3D7 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntity).Vertices[((CustomDataSurrogate) LastEntity).Vertices.Count - 1]);
      point3D8 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntity).Vertices[((CustomDataSurrogate) LastEntity).Vertices.Count - 2]);
    }
    else
    {
      point3D7 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntity).Vertices[0]);
      point3D8 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntity).Vertices[1]);
    }
    if (180.0 - Math.Abs(buCall.\u0001.AngleOfTwoLines(point3D5, point3D6, point3D7, point3D8, Plane.XY)) <= 30.0)
    {
      buDiametricDim.Copy(FirstEntity, ref ModifiedFirstEntity);
      ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
      buDiametricDim.Copy(LastEntity, ref ModifiedLastEntity);
      ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
    }
    else
    {
      double num1 = 0.0;
      double num2 = ModifyLength;
      List<Point3D> point3DList = new List<Point3D>();
      List<Point3D> Points = new List<Point3D>();
      if (FirstEntity.GetType() == typeof (buLine))
        buCall.\u0001.EntitiesToPointsWithCamDirection(FirstEntity, 0.01, ref Points);
      if (FirstEntity.GetType() == typeof (buArc))
      {
        buCall.\u0001.ArcTo3Point(FirstEntity, ref Points);
        Points.RemoveAt(0);
      }
      buVector5.Add(Points, ref point3DList);
      Points = new List<Point3D>();
      if (LastEntity.GetType() == typeof (buLine))
        buCall.\u0001.EntitiesToPointsWithCamDirection(LastEntity, 0.01, ref Points);
      if (LastEntity.GetType() == typeof (buArc))
      {
        buCall.\u0001.ArcTo3Point(LastEntity, ref Points);
        Points.RemoveAt(Points.Count - 1);
      }
      buVector5.Add(Points, ref point3DList);
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList);
      if (point3DList.Count == 3)
        num1 = buCall.\u0001.CrossProductLength(point3DList[0], point3DList[1], point3DList[point3DList.Count - 1]);
      if (point3DList.Count > 3)
      {
        num1 = buCall.\u0001.CrossProductLength(point3DList[0], point3DList[1], point3DList[2]);
        if (num1 > 0.0 & ClockDir == ClockDirectionType.CCW)
          num1 = buCall.\u0001.CrossProductLength(point3DList[0], point3DList[1], point3DList[point3DList.Count - 1]);
        if (num1 < 0.0 & ClockDir == ClockDirectionType.CW)
          num1 = buCall.\u0001.CrossProductLength(point3DList[0], point3DList[1], point3DList[point3DList.Count - 1]);
      }
      if (ReverseThetaCalculation)
        num1 *= -1.0;
      if (ClockDir == ClockDirectionType.CCW)
      {
        if (num1 <= 0.0)
        {
          buDiametricDim.Copy(FirstEntity, ref ModifiedFirstEntity);
          ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
          buDiametricDim.Copy(LastEntity, ref ModifiedLastEntity);
          ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
        }
        else
        {
          double num3 = num2 / Math.Cos(buString5.DegreeToRadian(((CustomDataSurrogate) FirstEntity).Orientation.A));
          if (FirstEntityTouchPoint == StartEndType.Start)
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num3, StartPointType.Start, ref ModifiedFirstEntity);
          if (FirstEntityTouchPoint == StartEndType.End)
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num3, StartPointType.End, ref ModifiedFirstEntity);
          if (SecondEntityTouchPoint == StartEndType.Start)
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num3, StartPointType.Start, ref ModifiedLastEntity);
          if (SecondEntityTouchPoint == StartEndType.End)
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num3, StartPointType.End, ref ModifiedLastEntity);
          ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
        }
      }
      else if (num1 >= 0.0)
      {
        buDiametricDim.Copy(FirstEntity, ref ModifiedFirstEntity);
        ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
        buDiametricDim.Copy(LastEntity, ref ModifiedLastEntity);
        ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
      }
      else
      {
        buMultilineText buMultilineText1 = new buMultilineText();
        buMultilineText buMultilineText2 = new buMultilineText();
        double num4 = num2 / Math.Cos(buString5.DegreeToRadian(((CustomDataSurrogate) FirstEntity).Orientation.A));
        if (FirstEntityTouchPoint == StartEndType.Start)
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num4, StartPointType.Start, ref ModifiedFirstEntity);
        if (FirstEntityTouchPoint == StartEndType.End)
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num4, StartPointType.End, ref ModifiedFirstEntity);
        if (SecondEntityTouchPoint == StartEndType.Start)
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num4, StartPointType.Start, ref ModifiedLastEntity);
        if (SecondEntityTouchPoint == StartEndType.End)
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num4, StartPointType.End, ref ModifiedLastEntity);
        ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
      }
    }
  }

  public void EntityCornerModifyByConvexConcave(
    buEntity FirstEntity,
    buEntity LastEntity,
    ClockDirectionType ClockDir,
    marbleConvexConcaveCalculationPars Pars,
    ref buEntity ModifiedFirstEntity,
    ref buEntity ModifiedLastEntity,
    ref List<buEntity> ConcaveEntitiesForMilling,
    ref List<buEntity> ConvexEntitiesForMilling)
  {
    ModifiedFirstEntity = (buEntity) new buMultilineText();
    ModifiedLastEntity = (buEntity) new buMultilineText();
    ConcaveEntitiesForMilling = new List<buEntity>();
    Point3D pntTouch = new Point3D();
    bool isTouch = false;
    StartEndType FirstEntityTouchPoint = StartEndType.Start;
    StartEndType SecondEntityTouchPoint = StartEndType.Start;
    buCall.\u0001.EntityEntityTouchPoint(FirstEntity, LastEntity, 0.01, ref isTouch, ref FirstEntityTouchPoint, ref SecondEntityTouchPoint, ref pntTouch);
    Point3D point3D1 = new Point3D();
    Point3D point3D2 = new Point3D();
    Point3D point3D3 = new Point3D();
    Point3D point3D4 = new Point3D();
    Point3D point3D5;
    Point3D point3D6;
    if (FirstEntityTouchPoint == StartEndType.End)
    {
      point3D5 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[((CustomDataSurrogate) FirstEntity).Vertices.Count - 1]);
      point3D6 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[((CustomDataSurrogate) FirstEntity).Vertices.Count - 2]);
    }
    else
    {
      point3D5 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[0]);
      point3D6 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) FirstEntity).Vertices[1]);
    }
    Point3D point3D7;
    Point3D point3D8;
    if (SecondEntityTouchPoint == StartEndType.End)
    {
      point3D7 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntity).Vertices[((CustomDataSurrogate) LastEntity).Vertices.Count - 1]);
      point3D8 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntity).Vertices[((CustomDataSurrogate) LastEntity).Vertices.Count - 2]);
    }
    else
    {
      point3D7 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntity).Vertices[0]);
      point3D8 = F_NotchEdit.ToPoint3D(((CustomDataSurrogate) LastEntity).Vertices[1]);
    }
    if (180.0 - Math.Abs(buCall.\u0001.AngleOfTwoLines(point3D5, point3D6, point3D7, point3D8, Plane.XY)) <= 30.0)
    {
      buDiametricDim.Copy(FirstEntity, ref ModifiedFirstEntity);
      ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
      buDiametricDim.Copy(LastEntity, ref ModifiedLastEntity);
      ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
    }
    else
    {
      double num1 = 0.0;
      double concaveLength1 = ((marbleCountertopMainData) Pars).ConcaveLength;
      double concaveLength2 = ((marbleCountertopMainData) Pars).ConcaveLength;
      List<Point3D> point3DList = new List<Point3D>();
      List<Point3D> Points = new List<Point3D>();
      if (FirstEntity.GetType() == typeof (buLine))
        buCall.\u0001.EntitiesToPointsWithCamDirection(FirstEntity, 0.01, ref Points);
      if (FirstEntity.GetType() == typeof (buArc))
      {
        buCall.\u0001.ArcTo3Point(FirstEntity, ref Points);
        Points.RemoveAt(0);
      }
      buVector5.Add(Points, ref point3DList);
      Points = new List<Point3D>();
      if (LastEntity.GetType() == typeof (buLine))
        buCall.\u0001.EntitiesToPointsWithCamDirection(LastEntity, 0.01, ref Points);
      if (LastEntity.GetType() == typeof (buArc))
      {
        buCall.\u0001.ArcTo3Point(LastEntity, ref Points);
        Points.RemoveAt(Points.Count - 1);
      }
      buVector5.Add(Points, ref point3DList);
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList);
      if (point3DList.Count == 3)
        num1 = buCall.\u0001.CrossProductLength(point3DList[0], point3DList[1], point3DList[point3DList.Count - 1]);
      if (point3DList.Count > 3)
      {
        num1 = buCall.\u0001.CrossProductLength(point3DList[0], point3DList[1], point3DList[2]);
        if (num1 > 0.0 & ClockDir == ClockDirectionType.CCW)
          num1 = buCall.\u0001.CrossProductLength(point3DList[0], point3DList[1], point3DList[point3DList.Count - 1]);
        if (num1 < 0.0 & ClockDir == ClockDirectionType.CW)
          num1 = buCall.\u0001.CrossProductLength(point3DList[0], point3DList[1], point3DList[point3DList.Count - 1]);
      }
      if (((marbleCountertopMainData) Pars).ReverseThetaCalculation)
        num1 *= -1.0;
      List<Point3D> points = new List<Point3D>();
      if (ClockDir == ClockDirectionType.CCW)
      {
        if (num1 <= 0.0)
        {
          if (!((marbleCountertopMainData) Pars).isConvex)
          {
            buDiametricDim.Copy(FirstEntity, ref ModifiedFirstEntity);
            ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
            ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
            buDiametricDim.Copy(LastEntity, ref ModifiedLastEntity);
            ((CustomData) ModifiedLastEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) LastEntity).Info);
            ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
          }
          else
          {
            double num2 = concaveLength2 / Math.Cos(buString5.DegreeToRadian(((CustomDataSurrogate) FirstEntity).Orientation.A));
            if (FirstEntityTouchPoint == StartEndType.Start)
            {
              buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num2, StartPointType.Start, ref ModifiedFirstEntity);
              points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedFirstEntity).StartPoint));
              points.Add(F_NotchEdit.ToPoint3D(pntTouch));
              ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
            }
            if (FirstEntityTouchPoint == StartEndType.End)
            {
              buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num2, StartPointType.End, ref ModifiedFirstEntity);
              points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedFirstEntity).EndPoint));
              points.Add(F_NotchEdit.ToPoint3D(pntTouch));
              ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
            }
            if (SecondEntityTouchPoint == StartEndType.Start)
            {
              buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num2, StartPointType.Start, ref ModifiedLastEntity);
              points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedLastEntity).StartPoint));
              ((CustomData) ModifiedLastEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) LastEntity).Info);
            }
            if (SecondEntityTouchPoint == StartEndType.End)
            {
              buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num2, StartPointType.End, ref ModifiedLastEntity);
              points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedLastEntity).EndPoint));
              ((CustomData) ModifiedLastEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) LastEntity).Info);
            }
            ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
            if (points.Count < 2)
              return;
            buLinearPath buLinearPath = (buLinearPath) new buShape(points);
            ConvexEntitiesForMilling.Add((buEntity) buLinearPath);
          }
        }
        else
        {
          double num3 = concaveLength1 / Math.Cos(buString5.DegreeToRadian(((CustomDataSurrogate) FirstEntity).Orientation.A));
          if (FirstEntityTouchPoint == StartEndType.Start)
          {
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num3, StartPointType.Start, ref ModifiedFirstEntity);
            points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedFirstEntity).StartPoint));
            points.Add(F_NotchEdit.ToPoint3D(pntTouch));
            ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
          }
          if (FirstEntityTouchPoint == StartEndType.End)
          {
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num3, StartPointType.End, ref ModifiedFirstEntity);
            points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedFirstEntity).EndPoint));
            points.Add(F_NotchEdit.ToPoint3D(pntTouch));
            ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
          }
          if (SecondEntityTouchPoint == StartEndType.Start)
          {
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num3, StartPointType.Start, ref ModifiedLastEntity);
            points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedLastEntity).StartPoint));
            ((CustomData) ModifiedLastEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) LastEntity).Info);
          }
          if (SecondEntityTouchPoint == StartEndType.End)
          {
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num3, StartPointType.End, ref ModifiedLastEntity);
            points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedLastEntity).EndPoint));
            ((CustomData) ModifiedLastEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) LastEntity).Info);
          }
          ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
          if (points.Count < 2)
            return;
          buLinearPath buLinearPath = (buLinearPath) new buShape(points);
          ConcaveEntitiesForMilling.Add((buEntity) buLinearPath);
        }
      }
      else if (num1 >= 0.0)
      {
        if (!((marbleCountertopMainData) Pars).isConvex)
        {
          buDiametricDim.Copy(FirstEntity, ref ModifiedFirstEntity);
          ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
          ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
          buDiametricDim.Copy(LastEntity, ref ModifiedLastEntity);
          ((CustomData) ModifiedLastEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) LastEntity).Info);
          ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
        }
        else
        {
          buMultilineText buMultilineText1 = new buMultilineText();
          buMultilineText buMultilineText2 = new buMultilineText();
          double num4 = concaveLength2 / Math.Cos(buString5.DegreeToRadian(((CustomDataSurrogate) FirstEntity).Orientation.A));
          if (FirstEntityTouchPoint == StartEndType.Start)
          {
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num4, StartPointType.Start, ref ModifiedFirstEntity);
            points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedFirstEntity).StartPoint));
            points.Add(F_NotchEdit.ToPoint3D(pntTouch));
            ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
          }
          if (FirstEntityTouchPoint == StartEndType.End)
          {
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num4, StartPointType.End, ref ModifiedFirstEntity);
            points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedFirstEntity).EndPoint));
            points.Add(F_NotchEdit.ToPoint3D(pntTouch));
            ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
          }
          if (SecondEntityTouchPoint == StartEndType.Start)
          {
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num4, StartPointType.Start, ref ModifiedLastEntity);
            points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedLastEntity).StartPoint));
            ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
          }
          if (SecondEntityTouchPoint == StartEndType.End)
          {
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num4, StartPointType.End, ref ModifiedLastEntity);
            points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedLastEntity).EndPoint));
            ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
          }
          ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
          if (points.Count < 2)
            return;
          buLinearPath buLinearPath = (buLinearPath) new buShape(points);
          ConvexEntitiesForMilling.Add((buEntity) buLinearPath);
        }
      }
      else
      {
        buMultilineText buMultilineText3 = new buMultilineText();
        buMultilineText buMultilineText4 = new buMultilineText();
        double num5 = concaveLength1 / Math.Cos(buString5.DegreeToRadian(((CustomDataSurrogate) FirstEntity).Orientation.A));
        if (FirstEntityTouchPoint == StartEndType.Start)
        {
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num5, StartPointType.Start, ref ModifiedFirstEntity);
          points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedFirstEntity).StartPoint));
          points.Add(F_NotchEdit.ToPoint3D(pntTouch));
          ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
        }
        if (FirstEntityTouchPoint == StartEndType.End)
        {
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(FirstEntity), buCall.\u0001.EntityLength(FirstEntity) - num5, StartPointType.End, ref ModifiedFirstEntity);
          points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedFirstEntity).EndPoint));
          points.Add(F_NotchEdit.ToPoint3D(pntTouch));
          ((CustomData) ModifiedFirstEntity).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) FirstEntity).Info);
        }
        if (SecondEntityTouchPoint == StartEndType.Start)
        {
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num5, StartPointType.Start, ref ModifiedLastEntity);
          points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedLastEntity).StartPoint));
          ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
        }
        if (SecondEntityTouchPoint == StartEndType.End)
        {
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(LastEntity), buCall.\u0001.EntityLength(LastEntity) - num5, StartPointType.End, ref ModifiedLastEntity);
          points.Add(F_NotchEdit.ToPoint3D(((CustomData) ModifiedLastEntity).EndPoint));
          ((AnalyseEntitiesResult) ((CustomData) ModifiedLastEntity).Info).CamSelected = false;
        }
        ((AnalyseEntitiesResult) ((CustomData) ModifiedFirstEntity).Info).CamSelected = false;
        if (points.Count < 2)
          return;
        buLinearPath buLinearPath = (buLinearPath) new buShape(points);
        ConcaveEntitiesForMilling.Add((buEntity) buLinearPath);
      }
    }
  }

  public void EntityModifyByConvexConcave(
    List<buEntity> refEntities,
    marbleConvexConcaveCalculationPars Pars,
    ToolBase5 ToolSaw,
    MarbleItemSettings Settings,
    ref List<List<buEntity>> SawEntities,
    ref List<List<buEntity>> ConcaveEntities,
    ref List<List<buEntity>> ConvexEntities)
  {
    // ISSUE: unable to decompile the method.
  }

  public void ConcaveArcOffsetCalculation(
    double arcRadius,
    double bladeDiameter,
    double materialThickness,
    ref double CalcOffset)
  {
    try
    {
      double num1 = bladeDiameter / 2.0;
      double num2 = arcRadius;
      double num3 = materialThickness;
      if ((num3 <= 0.0 || num2 <= 0.0 ? 1 : (num1 <= 0.0 ? 1 : 0)) != 0 || num3 >= num2)
        return;
      double d = Math.Acos((num2 - num3) / num2);
      CalcOffset = num1 * (1.0 - Math.Cos(d));
    }
    catch (Exception ex)
    {
    }
  }
}
