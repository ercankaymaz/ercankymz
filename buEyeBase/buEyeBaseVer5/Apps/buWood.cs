// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buWood
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buWood
{
  public double MaterialThickness;
  public double VShapeTargetAngle;
  public double VShapeHeightWidth;
  public double VShapeHeightRoughDepth;
  public double VShapeHeightFinishDepth;
  public double VShapeHeightRoughVel;
  public double VShapeHeightFinishVel;

  public void doGrindingVShape1(
    DiemakerGrindingShapeSettings Pars,
    ToolBase5 ToolGrinding,
    ToolBase5 ToolNick,
    ref List<Entity> calcEntities,
    ref camTp Cam)
  {
    Cam = new camTp();
    double Angle1 = 0.0;
    double Angle2 = 0.0;
    Point3D point3D1 = new Point3D();
    Point3D point3D2 = new Point3D();
    Point3D point3D3 = new Point3D();
    Point3D point3D4 = new Point3D();
    Point3D point3D5 = new Point3D();
    Point3D point3D6 = new Point3D();
    Point3D EndPnt1 = new Point3D();
    Point3D EndPnt2 = new Point3D();
    Point3D point3D7 = new Point3D();
    Entity rectangleEntity = (Entity) null;
    buCall.\u0001.DrawRectangle(new Point3D(), ((buWood) Pars).MaterialThickness, ((PipeBendMoveCommand) Pars).BaseMaterialHeight, Plane.XY, ref rectangleEntity);
    rectangleEntity.Translate(-((buWood) Pars).MaterialThickness / 2.0, 0.0);
    calcEntities.Add(rectangleEntity);
    double num1 = ((buWood) Pars).MaterialThickness / 2.0 / Math.Tan(buString5.DegreeToRadian(((buWood) Pars).VShapeTargetAngle / 2.0));
    List<Point3D> points = new List<Point3D>();
    points.Add(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, 0.0));
    points.Add(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - num1));
    points.Add(new Point3D(((buWood) Pars).MaterialThickness / 2.0 - ((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight));
    points.Add(new Point3D(((buWood) Pars).MaterialThickness - ((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - num1));
    points.Add(new Point3D(((buWood) Pars).MaterialThickness - ((buWood) Pars).MaterialThickness / 2.0, 0.0));
    points.Add(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, 0.0));
    buCall.\u0001.MiddlePointOfLine(points[1], points[2]);
    buCall.\u0001.MiddlePointOfLine(points[2], points[3]);
    LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
    linearPath.ColorMethod = colorMethodType.byEntity;
    linearPath.Color = Color.Lime;
    calcEntities.Add((Entity) linearPath);
    Cam.Tool = (ToolBase5) new ToolGeometry5(ToolGrinding);
    ((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType = ToolType.Flat;
    ((ToolGeometry5) Cam.Tool).Geometry.Length = ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness;
    ((ToolDisplay5) ((ToolGeometry5) Cam.Tool).Geometry).Thickness = 2.0;
    double num2 = 5.0;
    camTpPoint CamPoint = (camTpPoint) new TpPnt9D();
    Pnt6D pnt6D = new Pnt6D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    double num3 = ((PipeBendMoveCommand) Pars).BaseMaterialHeight - ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).VShapeHeightFinishDepth;
    int int32_1 = Convert.ToInt32(buFile5.RoundToUpper(num3 / ((buWood) Pars).VShapeHeightRoughDepth));
    double num4 = Math.Round(num3 / (double) int32_1, 3);
    double x = 0.0;
    double num5 = ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness - ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness;
    int upper = (int) buFile5.RoundToUpper(((WoodJob) Pars).GrindingLength / num5);
    double num6 = 0.0;
    if (((WoodSettings) Pars).NickEnable)
    {
      camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
      camTpPoint.PreCodes.Add((object) "G75");
      if (((WoodSettings) Pars).NickToolNo == 1)
        camTpPoint.PreCodes.Add((object) "M21 K1");
      if (((WoodSettings) Pars).NickToolNo == 2)
        camTpPoint.PreCodes.Add((object) "M22 K1");
      if (((WoodSettings) Pars).NickToolNo == 3)
        camTpPoint.PreCodes.Add((object) "M23 K1");
      camTpPoint.PreCodes.Add((object) "M154");
      camTpPoint.PreCodes.Add((object) "G75");
      camTpPoint.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      camTpPoint.PreCodes.Add((object) "G75");
      Pnt6D P1 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 5.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P1, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.Points[camTpPoint.Points.Count - 1].EnableAxes.Y = false;
      Pnt6D P2 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 5.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P2, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P3 = new Pnt6D(0.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P3, ((WoodSettings) Pars).NickRoughVel, 1, false));
      Pnt6D P4 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 0.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P4, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P5 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P5, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P6 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P6, ((WoodSettings) Pars).NickFinishVel, 1, false));
      Pnt6D P7 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 10.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P7, ((WoodSettings) Pars).NickRoughVel, 0, false));
      x = P7.X;
      camTpPoint.AfterCodes.Add((object) "M32");
      camTpPoint.AfterCodes.Add((object) ("M40 K" + (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness / 2.0).ToString("f2")));
      num6 += ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness / 2.0;
      camTpPoint.AfterCodes.Add((object) "M31");
      Cam.CamPoints.Add(camTpPoint);
    }
    CamPoint.PreCodes.Add((object) "G75");
    if (((WoodJob) Pars).VShapeHeightToolNo == 1)
      CamPoint.PreCodes.Add((object) "M21 K1");
    if (((WoodJob) Pars).VShapeHeightToolNo == 2)
      CamPoint.PreCodes.Add((object) "M22 K1");
    if (((WoodJob) Pars).VShapeHeightToolNo == 3)
      CamPoint.PreCodes.Add((object) "M23 K1");
    CamPoint.PreCodes.Add((object) "M154");
    CamPoint.PreCodes.Add((object) "G75");
    CamPoint.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
    CamPoint.PreCodes.Add((object) "G75");
    for (int index1 = 1; index1 <= upper; ++index1)
    {
      Pnt6D P8 = new Pnt6D(x, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 10.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P8, ((buWood) Pars).VShapeHeightRoughVel, 0, false)
      {
        EnableAxes = {
          X = false
        }
      });
      TpPnt9D tpPnt9D2 = new TpPnt9D(P8, ((buWood) Pars).VShapeHeightRoughVel, 0, false);
      CamPoint.Points.Add(tpPnt9D2);
      if (((WoodJob) Pars).VShapeHeightZigzag)
      {
        Pnt6D P9 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P9, ((buWood) Pars).VShapeHeightRoughVel, 0, false));
        CamPoint.Points[CamPoint.Points.Count - 1].EnableAxes.Y = false;
        Pnt6D P10 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P10, ((buWood) Pars).VShapeHeightRoughVel, 0, false));
      }
      for (int index2 = 1; index2 <= int32_1; ++index2)
      {
        if (!((WoodJob) Pars).VShapeHeightZigzag)
        {
          Pnt6D P11 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P11, ((buWood) Pars).VShapeHeightRoughVel, 0, false));
          Pnt6D P12 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P12, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          Pnt6D P13 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P13, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          Pnt6D P14 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P14, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
        }
        else if (index2 % 2 == 1)
        {
          Pnt6D P15 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P15, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          Pnt6D P16 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P16, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
        }
        else
        {
          Pnt6D P17 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P17, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          Pnt6D P18 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P18, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
        }
        Line line = new Line(new Point3D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num4), new Point3D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num4));
        line.ColorMethod = colorMethodType.byEntity;
        line.Color = Color.Cyan;
        calcEntities.Add((Entity) line);
      }
      if (((buWood) Pars).VShapeHeightFinishDepth != 0.0)
      {
        if (!((WoodJob) Pars).VShapeHeightZigzag)
        {
          Pnt6D P19 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P19, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          Pnt6D P20 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P20, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          Pnt6D P21 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P21, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          Pnt6D P22 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P22, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
        }
        else if (((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X > 0.0)
        {
          Pnt6D P23 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P23, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          Pnt6D P24 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P24, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
        }
        else
        {
          Pnt6D P25 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P25, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          Pnt6D P26 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P26, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
        }
        Line line = new Line(new Point3D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight), new Point3D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight));
        line.ColorMethod = colorMethodType.byEntity;
        line.Color = Color.Blue;
        calcEntities.Add((Entity) line);
      }
      if (((WoodJob) Pars).VShapeHeightZigzag)
      {
        Pnt6D P27 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P27, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
      }
      Pnt6D P28 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P28, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
      Pnt6D P29 = new Pnt6D(-Math.Abs(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X) - ((ToolGeometry5) ToolGrinding).Geometry.Diameter / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P29, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
      double num7 = ((buWood) Pars).MaterialThickness / 2.0 - ((WoodRuntimeSettings) Pars).VShapeAngleFinishDepth;
      int int32_2 = Convert.ToInt32(buFile5.RoundToUpper(num7 / ((WoodRuntimeSettings) Pars).VShapeAngleRoughDepth));
      double num8 = Math.Round(num7 / (double) int32_2, 3);
      double num9 = 1.0;
      Point3D EndPnt3 = new Point3D();
      for (int index3 = int32_2; index3 >= 1; --index3)
      {
        EndPnt1 = new Point3D();
        EndPnt2 = new Point3D();
        if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
        {
          point3D3 = F_NotchEdit.ToPoint3D(points[1]);
          point3D4 = F_NotchEdit.ToPoint3D(points[2]);
          Angle1 = buCall.\u0001.PointAngle(points[2], points[1]);
          buCall.\u0001.LineWithLengthAndAngle(point3D3, (double) index3 * num8, Angle1 + 90.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(point3D4, (double) index3 * num8, Angle1 + 90.0, ref EndPnt2);
          Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle1 + 90.0, ref EndPnt3);
          Pnt6D P30 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P30, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
          Pnt6D P31 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P31, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
          Pnt6D P32 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P32, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle1 + 90.0, ref EndPnt3);
          Pnt6D P33 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P33, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
        }
        else
        {
          point3D3 = F_NotchEdit.ToPoint3D(points[2]);
          point3D4 = F_NotchEdit.ToPoint3D(points[1]);
          Angle1 = buCall.\u0001.PointAngle(points[1], points[2]);
          buCall.\u0001.LineWithLengthAndAngle(point3D3, (double) index3 * num8, Angle1 - 90.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(point3D4, (double) index3 * num8, Angle1 - 90.0, ref EndPnt2);
          Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle1 - 90.0, ref EndPnt3);
          Pnt6D P34 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P34, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
          Pnt6D P35 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P35, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
          Pnt6D P36 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P36, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle1 - 90.0, ref EndPnt3);
          Pnt6D P37 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P37, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
        }
        Line line = new Line(EndPnt1, EndPnt2);
        line.ColorMethod = colorMethodType.byEntity;
        line.Color = Color.Red;
        calcEntities.Add((Entity) line);
      }
      for (int index4 = 1; index4 <= ((WoodTempVars) Pars).VShapeAngleFinishCount; ++index4)
      {
        if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
        {
          EndPnt1 = new Point3D();
          EndPnt2 = new Point3D();
          Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(point3D3, point3D4);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle1 + 90.0, ref EndPnt3);
          Pnt6D P38 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P38, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
          Pnt6D P39 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P39, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
          Pnt6D P40 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P40, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle1 + 90.0, ref EndPnt3);
          Pnt6D P41 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P41, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
        }
        else
        {
          EndPnt1 = new Point3D();
          EndPnt2 = new Point3D();
          Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(point3D3, point3D4);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle1 - 90.0, ref EndPnt3);
          Pnt6D P42 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P42, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
          Pnt6D P43 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P43, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
          Pnt6D P44 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P44, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle1 - 90.0, ref EndPnt3);
          Pnt6D P45 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P45, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
        }
      }
      Line line1 = new Line(EndPnt1, EndPnt2);
      line1.ColorMethod = colorMethodType.byEntity;
      line1.Color = Color.Red;
      calcEntities.Add((Entity) line1);
      Pnt6D P46 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P46, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
      Pnt6D P47 = new Pnt6D(((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 10.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P47, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
      double num10 = ((buWood) Pars).MaterialThickness / 2.0 - ((WoodRuntimeSettings) Pars).VShapeAngleFinishDepth;
      int int32_3 = Convert.ToInt32(buFile5.RoundToUpper(num10 / ((WoodRuntimeSettings) Pars).VShapeAngleRoughDepth));
      double num11 = Math.Round(num10 / (double) int32_3, 3);
      int num12 = 0;
      for (int index5 = int32_3; index5 >= 1; --index5)
      {
        if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
        {
          Angle2 = buCall.\u0001.PointAngle(points[2], points[3]);
          point3D5 = F_NotchEdit.ToPoint3D(points[3]);
          point3D6 = F_NotchEdit.ToPoint3D(points[2]);
          EndPnt1 = new Point3D();
          EndPnt2 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(point3D5, (double) index5 * num11, Angle2 - 90.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(point3D6, (double) index5 * num11, Angle2 - 90.0, ref EndPnt2);
          Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle2 - 90.0, ref EndPnt3);
          Pnt6D P48 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          if (num12 == 0)
          {
            TpPnt9D tpPnt9D3 = new TpPnt9D(P48, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
            if (((WoodJob) Pars).VShapeHeightToolNo == 1)
              tpPnt9D3.PreCodes.Add((object) "M21 K-1");
            if (((WoodJob) Pars).VShapeHeightToolNo == 2)
              tpPnt9D3.PreCodes.Add((object) "M22 K-1");
            if (((WoodJob) Pars).VShapeHeightToolNo == 3)
              tpPnt9D3.PreCodes.Add((object) "M23 K-1");
            CamPoint.Points.Add(tpPnt9D3);
          }
          else
            CamPoint.Points.Add(new TpPnt9D(P48, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 - 90.0, ref EndPnt3);
          Pnt6D P49 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P49, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 - 90.0, ref EndPnt3);
          Pnt6D P50 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P50, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle2 - 90.0, ref EndPnt3);
          Pnt6D P51 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P51, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          Line line2 = new Line(EndPnt1, EndPnt2);
          line2.ColorMethod = colorMethodType.byEntity;
          line2.Color = Color.Red;
          calcEntities.Add((Entity) line2);
          ++num12;
        }
        else
        {
          point3D5 = F_NotchEdit.ToPoint3D(points[2]);
          point3D6 = F_NotchEdit.ToPoint3D(points[3]);
          Angle2 = buCall.\u0001.PointAngle(points[3], points[2]);
          EndPnt1 = new Point3D();
          EndPnt2 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(point3D5, (double) index5 * num11, Angle2 + 90.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(point3D6, (double) index5 * num11, Angle2 + 90.0, ref EndPnt2);
          Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle2 + 90.0, ref EndPnt3);
          Pnt6D P52 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          if (num12 == 0)
          {
            TpPnt9D tpPnt9D4 = new TpPnt9D(P52, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
            if (((WoodJob) Pars).VShapeHeightToolNo == 1)
              tpPnt9D4.PreCodes.Add((object) "M21 K-1");
            if (((WoodJob) Pars).VShapeHeightToolNo == 2)
              tpPnt9D4.PreCodes.Add((object) "M22 K-1");
            if (((WoodJob) Pars).VShapeHeightToolNo == 3)
              tpPnt9D4.PreCodes.Add((object) "M23 K-1");
            CamPoint.Points.Add(tpPnt9D4);
          }
          else
            CamPoint.Points.Add(new TpPnt9D(P52, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 + 90.0, ref EndPnt3);
          Pnt6D P53 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P53, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 + 90.0, ref EndPnt3);
          Pnt6D P54 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P54, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle2 + 90.0, ref EndPnt3);
          Pnt6D P55 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P55, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
          Line line3 = new Line(EndPnt1, EndPnt2);
          line3.ColorMethod = colorMethodType.byEntity;
          line3.Color = Color.Red;
          calcEntities.Add((Entity) line3);
          ++num12;
        }
      }
      for (int index6 = 1; index6 <= ((WoodTempVars) Pars).VShapeAngleFinishCount; ++index6)
      {
        if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
        {
          EndPnt1 = new Point3D();
          EndPnt2 = new Point3D();
          Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(point3D5, point3D6);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle2 - 90.0, ref EndPnt3);
          Pnt6D P56 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P56, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 - 90.0, ref EndPnt3);
          Pnt6D P57 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P57, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 - 90.0, ref EndPnt3);
          Pnt6D P58 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P58, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle2 - 90.0, ref EndPnt3);
          Pnt6D P59 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P59, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          Pnt6D P60 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P60, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
        }
        else
        {
          EndPnt1 = new Point3D();
          EndPnt2 = new Point3D();
          Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(point3D5, point3D6);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
          buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle2 + 90.0, ref EndPnt3);
          Pnt6D P61 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P61, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 + 90.0, ref EndPnt3);
          Pnt6D P62 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P62, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 + 90.0, ref EndPnt3);
          Pnt6D P63 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P63, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
          EndPnt3 = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num9, Angle2 + 90.0, ref EndPnt3);
          Pnt6D P64 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P64, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
        }
      }
      Pnt6D P65 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P65, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
      Line line4 = new Line(EndPnt1, EndPnt2);
      line4.ColorMethod = colorMethodType.byEntity;
      line4.Color = Color.Red;
      calcEntities.Add((Entity) line4);
      if (!((WoodSettings) Pars).NickEnable)
      {
        if (index1 < upper)
        {
          if (index1 == upper - 1)
          {
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num6)).ToString("f2")));
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
            num6 += ((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num6);
          }
          else
          {
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num5.ToString("f2")));
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
            num6 += num5;
          }
        }
      }
      else if (index1 < upper)
      {
        if (index1 == upper - 1)
        {
          CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
          CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - num5 * ((double) upper - 1.0)).ToString("f2")));
          CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
          num6 += ((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - num5 * ((double) upper - 1.0);
        }
        else
        {
          CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
          CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num5.ToString("f2")));
          CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
          num6 += num5;
        }
      }
    }
    CamPoint.AfterCodes.Add((object) "M32");
    double num13;
    if (!((WoodSettings) Pars).NickEnable)
    {
      ArrayList afterCodes = CamPoint.AfterCodes;
      num13 = ((WoodJob) Pars).FeedDistance + ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness;
      string str = "M40 K" + num13.ToString("f2");
      afterCodes.Add((object) str);
    }
    else
    {
      ArrayList afterCodes = CamPoint.AfterCodes;
      num13 = ((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 1.0 - num6;
      string str = "M40 K" + num13.ToString("f2");
      afterCodes.Add((object) str);
      double num14 = num6 + (((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - num6);
    }
    CamPoint.AfterCodes.Add((object) "M31");
    Cam.CamPoints.Add(CamPoint);
    if (((WoodSettings) Pars).NickEnable)
    {
      camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
      camTpPoint.PreCodes.Add((object) "G75");
      if (((WoodSettings) Pars).NickToolNo == 1)
        camTpPoint.PreCodes.Add((object) "M21 K1");
      if (((WoodSettings) Pars).NickToolNo == 2)
        camTpPoint.PreCodes.Add((object) "M22 K1");
      if (((WoodSettings) Pars).NickToolNo == 3)
        camTpPoint.PreCodes.Add((object) "M23 K1");
      camTpPoint.PreCodes.Add((object) "M154");
      camTpPoint.PreCodes.Add((object) "G75");
      camTpPoint.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      camTpPoint.PreCodes.Add((object) "G75");
      Pnt6D P66 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 5.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P66, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.Points[camTpPoint.Points.Count - 1].EnableAxes.Y = false;
      Pnt6D P67 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 5.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P67, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P68 = new Pnt6D(0.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P68, ((WoodSettings) Pars).NickRoughVel, 1, false));
      Pnt6D P69 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 0.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P69, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P70 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P70, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P71 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P71, ((WoodSettings) Pars).NickFinishVel, 1, false));
      Pnt6D P72 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 10.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P72, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.AfterCodes.Add((object) "M32");
      ArrayList afterCodes = camTpPoint.AfterCodes;
      num13 = ((WoodJob) Pars).FeedDistance + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness;
      string str = "M40 K" + num13.ToString("f2");
      afterCodes.Add((object) str);
      camTpPoint.AfterCodes.Add((object) "M31");
      Cam.CamPoints.Add(camTpPoint);
    }
    Cam.PreCodes.Add((object) ("//Count = " + ((WoodJob) Pars).FeedCount.ToString()));
    buCall.\u0001.CreateSimulationPointsFromCamPoint(ref Cam, CamPoint, 0.9, 0.2);
  }
}
