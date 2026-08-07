// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PipeBendTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendTempVars
{
  public const int ioReverseSolution = 1;
  public const int ioStrictlySimple = 2;
  public const int ioPreserveCollinear = 4;
  internal ClipType \u0001;
  internal \u0012.\u0001 \u0001;
  internal \u0084.\u0001 \u0001;
  internal List<IntersectNode> \u0001;
  internal IComparer<IntersectNode> \u0001;
  private bool \u0001;
  internal PolyFillType \u0001;
  internal PolyFillType \u0002;
  internal List<\u0081.\u0001> \u0001;
  internal List<\u0081.\u0001> \u0002;
  internal bool \u0002;
  public static byte f003AAD;
  [SpecialName]
  public int value__;
  public const buClipper.\u0001 \u0001 = ; // Unable to render the field
  public const buClipper.\u0001 \u0002 = ; // Unable to render the field
  public const buClipper.\u0001 \u0003 = ; // Unable to render the field
  private static string \u0001;
  private static string \u0002;
  internal List<List<IntPoint>> \u0001;
  internal List<IntPoint> \u0001;
  internal List<IntPoint> \u0002;
  internal List<DoublePoint> \u0001;
  internal double \u0001;
  internal double \u0002;
  internal double \u0003;
  internal double \u0004;
  internal double \u0005;
  internal double \u0006;
  internal IntPoint \u0001;
  internal PolyNode \u0001;
  public static byte f003AC2;
  public static string UnlockString;
  public static byte f003AC4;
  public static DiemakerGrindingShapeSettings varGrindingShape;
  public static byte f003AC6;

  public void doGrindingVShape(
    DiemakerGrindingShapeSettings Pars,
    ToolBase5 ToolGrinding,
    ToolBase5 ToolNick,
    bool isCircular,
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
    List<Point3D> Vertices = new List<Point3D>();
    Vertices.Add(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, 0.0));
    Vertices.Add(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - num1));
    Vertices.Add(new Point3D(((buWood) Pars).MaterialThickness / 2.0 - ((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight));
    Vertices.Add(new Point3D(((buWood) Pars).MaterialThickness - ((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - num1));
    Vertices.Add(new Point3D(((buWood) Pars).MaterialThickness - ((buWood) Pars).MaterialThickness / 2.0, 0.0));
    Vertices.Add(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, 0.0));
    buCall.\u0001.MiddlePointOfLine(Vertices[1], Vertices[2]);
    buCall.\u0001.MiddlePointOfLine(Vertices[2], Vertices[3]);
    if (isCircular)
    {
      Vertices = new List<Point3D>();
      buCall.\u0001.Arc3Point(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), new Point3D(0.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight), new Point3D(((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), Plane.XY, new EntityResolution(0.002, 50, 20.0, EntityResolutionType.ByLength), ref Vertices);
      F_NotchEdit.ToPoint3D(Vertices[0]);
      F_NotchEdit.ToPoint3D(Vertices[Vertices.Count - 1]);
    }
    double num2 = 5.0;
    LinearPath linearPath = new LinearPath((ICollection<Point3D>) Vertices);
    linearPath.ColorMethod = colorMethodType.byEntity;
    linearPath.Color = Color.Lime;
    calcEntities.Add((Entity) linearPath);
    Cam.Tool = (ToolBase5) new ToolGeometry5(ToolGrinding);
    ((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType = ToolType.Flat;
    ((ToolGeometry5) Cam.Tool).Geometry.Length = ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness;
    ((ToolDisplay5) ((ToolGeometry5) Cam.Tool).Geometry).Thickness = 2.0;
    double num3 = 5.0;
    double num4 = 1.0;
    camTpPoint CamPoint = (camTpPoint) new TpPnt9D();
    Pnt6D pnt6D = new Pnt6D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    double num5 = ((PipeBendMoveCommand) Pars).BaseMaterialHeight - ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).VShapeHeightFinishDepth;
    int int32_1 = Convert.ToInt32(buFile5.RoundToUpper(num5 / ((buWood) Pars).VShapeHeightRoughDepth));
    double num6 = Math.Round(num5 / (double) int32_1, 3);
    double x = 0.0;
    double num7 = ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness * ((WoodJob) Pars).ToolPersentage / 100.0;
    int upper = (int) buFile5.RoundToUpper(((WoodJob) Pars).GrindingLength / num7);
    double num8 = 0.0;
    if (((WoodSettings) Pars).NickEnable)
    {
      camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
      camTpPoint.PreCodes.Add((object) "G75");
      string str = " K1";
      if (((WoodSettings) Pars).NickReverseDir)
        str = " K-1";
      if (((WoodSettings) Pars).NickToolNo == 1)
        camTpPoint.PreCodes.Add((object) ("M21" + str));
      if (((WoodSettings) Pars).NickToolNo == 2)
        camTpPoint.PreCodes.Add((object) ("M22" + str));
      if (((WoodSettings) Pars).NickToolNo == 3)
        camTpPoint.PreCodes.Add((object) ("M23" + str));
      camTpPoint.PreCodes.Add((object) "M154");
      camTpPoint.PreCodes.Add((object) "G75");
      camTpPoint.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      camTpPoint.PreCodes.Add((object) "G75");
      Pnt6D P1 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P1, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.Points[camTpPoint.Points.Count - 1].EnableAxes.Y = false;
      Pnt6D P2 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P2, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P3 = new Pnt6D(0.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P3, ((WoodSettings) Pars).NickRoughVel, 1, false));
      Pnt6D P4 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 0.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P4, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P5 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P5, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P6 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P6, ((WoodSettings) Pars).NickFinishVel, 1, false));
      Pnt6D P7 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P7, ((WoodSettings) Pars).NickRoughVel, 0, false));
      x = P7.X;
      camTpPoint.AfterCodes.Add((object) "M32");
      camTpPoint.AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 1.0).ToString("f2")));
      num8 += ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness / 2.0;
      camTpPoint.AfterCodes.Add((object) "M31");
      Cam.CamPoints.Add(camTpPoint);
    }
    if (((WoodSettings) Pars).NickEnable)
    {
      camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
      camTpPoint.PreCodes.Add((object) "G75");
      string str = " K1";
      if (((WoodSettings) Pars).NickReverseDir)
        str = " K-1";
      if (((WoodSettings) Pars).NickToolNo == 1)
        camTpPoint.PreCodes.Add((object) ("M21" + str));
      if (((WoodSettings) Pars).NickToolNo == 2)
        camTpPoint.PreCodes.Add((object) ("M22" + str));
      if (((WoodSettings) Pars).NickToolNo == 3)
        camTpPoint.PreCodes.Add((object) ("M23" + str));
      camTpPoint.PreCodes.Add((object) "M154");
      camTpPoint.PreCodes.Add((object) "G75");
      camTpPoint.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      camTpPoint.PreCodes.Add((object) "G75");
      Pnt6D P8 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P8, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.Points[camTpPoint.Points.Count - 1].EnableAxes.Y = false;
      Pnt6D P9 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P9, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P10 = new Pnt6D(0.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P10, ((WoodSettings) Pars).NickRoughVel, 1, false));
      Pnt6D P11 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 0.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P11, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P12 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P12, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P13 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P13, ((WoodSettings) Pars).NickFinishVel, 1, false));
      Pnt6D P14 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P14, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.AfterCodes.Add((object) "M32");
      camTpPoint.AfterCodes.Add((object) ("M40 K" + (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness / 2.0 - (((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 1.0)).ToString("f2")));
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
    double num9 = 0.0;
    double num10 = 0.0;
    double num11 = 0.0;
    if (!isCircular)
    {
      for (int index1 = 1; index1 <= upper; ++index1)
      {
        Pnt6D P15 = new Pnt6D(x, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P15, ((buWood) Pars).VShapeHeightRoughVel, 0, false)
        {
          EnableAxes = {
            X = false
          }
        });
        TpPnt9D tpPnt9D2 = new TpPnt9D(P15, ((buWood) Pars).VShapeHeightRoughVel, 0, false);
        CamPoint.Points.Add(tpPnt9D2);
        if (((WoodJob) Pars).VShapeHeightZigzag)
        {
          Pnt6D P16 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P16, ((buWood) Pars).VShapeHeightRoughVel, 0, false));
          CamPoint.Points[CamPoint.Points.Count - 1].EnableAxes.Y = false;
          Pnt6D P17 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P17, ((buWood) Pars).VShapeHeightRoughVel, 0, false));
        }
        for (int index2 = 1; index2 <= int32_1; ++index2)
        {
          if (!((WoodJob) Pars).VShapeHeightZigzag)
          {
            Pnt6D P18 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P18, ((buWood) Pars).VShapeHeightRoughVel, 0, false));
            Pnt6D P19 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num6 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P19, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P20 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num6 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P20, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P21 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P21, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          }
          else if (index2 % 2 == 1)
          {
            Pnt6D P22 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num6 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P22, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P23 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num6 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P23, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          }
          else
          {
            Pnt6D P24 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num6 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P24, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P25 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num6 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P25, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          }
          Line line = new Line(new Point3D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num6), new Point3D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num6));
          line.ColorMethod = colorMethodType.byEntity;
          line.Color = Color.Cyan;
          calcEntities.Add((Entity) line);
        }
        if (((buWood) Pars).VShapeHeightFinishDepth != 0.0)
        {
          if (!((WoodJob) Pars).VShapeHeightZigzag)
          {
            Pnt6D P26 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P26, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P27 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P27, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P28 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P28, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P29 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P29, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          }
          else if (((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X > 0.0)
          {
            Pnt6D P30 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P30, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P31 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P31, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          }
          else
          {
            Pnt6D P32 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P32, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P33 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P33, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          }
          Line line = new Line(new Point3D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight), new Point3D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight));
          line.ColorMethod = colorMethodType.byEntity;
          line.Color = Color.Blue;
          calcEntities.Add((Entity) line);
        }
        if (((WoodJob) Pars).VShapeHeightZigzag)
        {
          Pnt6D P34 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P34, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
        }
        Pnt6D P35 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P35, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
        if (index1 == upper)
        {
          Pnt6D P36 = new Pnt6D(-Math.Abs(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X) - ((ToolGeometry5) ToolGrinding).Geometry.Diameter / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P36, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
        }
        if (!((WoodSettings) Pars).NickEnable)
        {
          if (index1 < upper)
          {
            if (index1 == upper - 1)
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num8)).ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num8 += ((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num8);
            }
            else
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num7.ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num8 += num7;
            }
          }
        }
        else if (index1 < upper)
        {
          if (index1 == upper - 1)
          {
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength - num7 * ((double) upper - 1.0)).ToString("f2")));
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
            num8 += ((WoodJob) Pars).GrindingLength - num7 * ((double) upper - 1.0);
            num9 += ((WoodJob) Pars).GrindingLength - num7 * ((double) upper - 1.0);
          }
          else
          {
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num7.ToString("f2")));
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
            num8 += num7;
            num9 += num7;
          }
        }
      }
      if (num9 != 0.0)
      {
        CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
        CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (-num9).ToString("f2")));
        CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
      }
      double num12 = 0.0;
      for (int index3 = 1; index3 <= upper; ++index3)
      {
        if (index3 == 1)
        {
          Pnt6D P37 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P37, ((buWood) Pars).VShapeHeightRoughVel, 0, false)
          {
            EnableAxes = {
              X = false
            }
          });
          TpPnt9D tpPnt9D3 = new TpPnt9D(P37, ((buWood) Pars).VShapeHeightRoughVel, 0, false);
          CamPoint.Points.Add(tpPnt9D3);
          Pnt6D P38 = new Pnt6D(-Math.Abs(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X) - ((ToolGeometry5) ToolGrinding).Geometry.Diameter / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P38, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
        }
        if (((WoodSettings) Pars).VShapeAngleEnable)
        {
          double num13 = ((buWood) Pars).MaterialThickness / 2.0 - ((WoodRuntimeSettings) Pars).VShapeAngleFinishDepth;
          int int32_2 = Convert.ToInt32(buFile5.RoundToUpper(num13 / ((WoodRuntimeSettings) Pars).VShapeAngleRoughDepth));
          double num14 = Math.Round(num13 / (double) int32_2, 3);
          num4 = 1.0;
          Point3D EndPnt3 = new Point3D();
          int num15 = 0;
          for (int index4 = int32_2; index4 >= 1; --index4)
          {
            EndPnt1 = new Point3D();
            EndPnt2 = new Point3D();
            if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
            {
              point3D3 = F_NotchEdit.ToPoint3D(Vertices[1]);
              point3D4 = F_NotchEdit.ToPoint3D(Vertices[2]);
              Angle1 = buCall.\u0001.PointAngle(Vertices[2], Vertices[1]);
              buCall.\u0001.LineWithLengthAndAngle(point3D3, (double) index4 * num14, Angle1 + 90.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(point3D4, (double) index4 * num14, Angle1 + 90.0, ref EndPnt2);
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P39 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              num10 = EndPnt3.X;
              num11 = EndPnt3.Y;
              if (num15 == 0)
              {
                TpPnt9D tpPnt9D4 = new TpPnt9D(P39, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                if (((WoodJob) Pars).VShapeHeightToolNo == 1)
                  tpPnt9D4.PreCodes.Add((object) "M21 K1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 2)
                  tpPnt9D4.PreCodes.Add((object) "M22 K1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 3)
                  tpPnt9D4.PreCodes.Add((object) "M23 K1");
                CamPoint.Points.Add(tpPnt9D4);
              }
              else
              {
                TpPnt9D tpPnt9D5 = new TpPnt9D(P39, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                CamPoint.Points.Add(tpPnt9D5);
              }
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P40 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P40, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P41 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P41, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P42 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P42, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              ++num15;
            }
            else
            {
              point3D3 = F_NotchEdit.ToPoint3D(Vertices[2]);
              point3D4 = F_NotchEdit.ToPoint3D(Vertices[1]);
              Angle1 = buCall.\u0001.PointAngle(Vertices[1], Vertices[2]);
              buCall.\u0001.LineWithLengthAndAngle(point3D3, (double) index4 * num14, Angle1 - 90.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(point3D4, (double) index4 * num14, Angle1 - 90.0, ref EndPnt2);
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P43 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              num10 = EndPnt3.X;
              num11 = EndPnt3.Y;
              if (num15 == 0)
              {
                TpPnt9D tpPnt9D6 = new TpPnt9D(P43, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                if (((WoodJob) Pars).VShapeHeightToolNo == 1)
                  tpPnt9D6.PreCodes.Add((object) "M21 K1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 2)
                  tpPnt9D6.PreCodes.Add((object) "M22 K1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 3)
                  tpPnt9D6.PreCodes.Add((object) "M23 K1");
                CamPoint.Points.Add(tpPnt9D6);
              }
              else
              {
                TpPnt9D tpPnt9D7 = new TpPnt9D(P43, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                CamPoint.Points.Add(tpPnt9D7);
              }
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P44 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P44, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P45 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P45, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P46 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P46, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              ++num15;
            }
            Line line = new Line(EndPnt1, EndPnt2);
            line.ColorMethod = colorMethodType.byEntity;
            line.Color = Color.Red;
            calcEntities.Add((Entity) line);
          }
          for (int index5 = 1; index5 <= ((WoodTempVars) Pars).VShapeAngleFinishCount; ++index5)
          {
            if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
            {
              EndPnt1 = new Point3D();
              EndPnt2 = new Point3D();
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(point3D3, point3D4);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P47 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P47, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P48 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P48, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P49 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P49, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P50 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P50, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
            }
            else
            {
              EndPnt1 = new Point3D();
              EndPnt2 = new Point3D();
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(point3D3, point3D4);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P51 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P51, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P52 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P52, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P53 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P53, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P54 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P54, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
            }
          }
          Line line1 = new Line(EndPnt1, EndPnt2);
          line1.ColorMethod = colorMethodType.byEntity;
          line1.Color = Color.Red;
          calcEntities.Add((Entity) line1);
          if (index3 == upper)
          {
            Pnt6D P55 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P55, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
            Pnt6D P56 = new Pnt6D(((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 10.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P56, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          }
          else
          {
            Pnt6D P = new Pnt6D(num10 - 1.0, num11 + 1.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          }
          if (!((WoodSettings) Pars).NickEnable)
          {
            if (index3 < upper)
            {
              if (index3 == upper - 1)
              {
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num8)).ToString("f2")));
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
                num8 += ((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num8);
              }
              else
              {
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num7.ToString("f2")));
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
                num8 += num7;
              }
            }
          }
          else if (index3 < upper)
          {
            if (index3 == upper - 1)
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength - num7 * ((double) upper - 1.0)).ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num8 += ((WoodJob) Pars).GrindingLength - num7 * ((double) upper - 1.0);
              num12 += ((WoodJob) Pars).GrindingLength - num7 * ((double) upper - 1.0);
            }
            else
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num7.ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num8 += num7;
              num12 += num7;
            }
          }
        }
      }
      if (num12 != 0.0)
      {
        CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
        CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (-num12).ToString("f2")));
        CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
      }
      double num16 = 0.0;
      for (int index6 = 1; index6 <= upper; ++index6)
      {
        if (index6 == 1)
        {
          Pnt6D P = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P, ((buWood) Pars).VShapeHeightRoughVel, 0, false)
          {
            EnableAxes = {
              X = false
            }
          });
          TpPnt9D tpPnt9D8 = new TpPnt9D(P, ((buWood) Pars).VShapeHeightRoughVel, 0, false);
          CamPoint.Points.Add(tpPnt9D8);
        }
        if (((WoodSettings) Pars).VShapeAngleEnable)
        {
          if (index6 == 1)
          {
            Pnt6D P57 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P57, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
            Pnt6D P58 = new Pnt6D(((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 10.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P58, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          }
          double num17 = ((buWood) Pars).MaterialThickness / 2.0 - ((WoodRuntimeSettings) Pars).VShapeAngleFinishDepth;
          int int32_3 = Convert.ToInt32(buFile5.RoundToUpper(num17 / ((WoodRuntimeSettings) Pars).VShapeAngleRoughDepth));
          double num18 = Math.Round(num17 / (double) int32_3, 3);
          int num19 = 0;
          for (int index7 = int32_3; index7 >= 1; --index7)
          {
            if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
            {
              Angle2 = buCall.\u0001.PointAngle(Vertices[2], Vertices[3]);
              point3D5 = F_NotchEdit.ToPoint3D(Vertices[3]);
              point3D6 = F_NotchEdit.ToPoint3D(Vertices[2]);
              EndPnt1 = new Point3D();
              EndPnt2 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(point3D5, (double) index7 * num18, Angle2 - 90.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(point3D6, (double) index7 * num18, Angle2 - 90.0, ref EndPnt2);
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
              Point3D EndPnt4 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle2 - 90.0, ref EndPnt4);
              Pnt6D P59 = new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0);
              num10 = EndPnt4.X;
              num11 = EndPnt4.Y;
              if (num19 == 0)
              {
                TpPnt9D tpPnt9D9 = new TpPnt9D(P59, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                if (((WoodJob) Pars).VShapeHeightToolNo == 1)
                  tpPnt9D9.PreCodes.Add((object) "M21 K-1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 2)
                  tpPnt9D9.PreCodes.Add((object) "M22 K-1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 3)
                  tpPnt9D9.PreCodes.Add((object) "M23 K-1");
                CamPoint.Points.Add(tpPnt9D9);
              }
              else
                CamPoint.Points.Add(new TpPnt9D(P59, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt4 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 - 90.0, ref EndPnt4);
              Pnt6D P60 = new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P60, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt4 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 - 90.0, ref EndPnt4);
              Pnt6D P61 = new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P61, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt4 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle2 - 90.0, ref EndPnt4);
              Pnt6D P62 = new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P62, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              Line line = new Line(EndPnt1, EndPnt2);
              line.ColorMethod = colorMethodType.byEntity;
              line.Color = Color.Red;
              calcEntities.Add((Entity) line);
              ++num19;
            }
            else
            {
              point3D5 = F_NotchEdit.ToPoint3D(Vertices[2]);
              point3D6 = F_NotchEdit.ToPoint3D(Vertices[3]);
              Angle2 = buCall.\u0001.PointAngle(Vertices[3], Vertices[2]);
              EndPnt1 = new Point3D();
              EndPnt2 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(point3D5, (double) index7 * num18, Angle2 + 90.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(point3D6, (double) index7 * num18, Angle2 + 90.0, ref EndPnt2);
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
              Point3D EndPnt5 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle2 + 90.0, ref EndPnt5);
              num10 = EndPnt5.X;
              num11 = EndPnt5.Y;
              Pnt6D P63 = new Pnt6D(EndPnt5.X, EndPnt5.Y, 0.0);
              if (num19 == 0)
              {
                TpPnt9D tpPnt9D10 = new TpPnt9D(P63, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                if (((WoodJob) Pars).VShapeHeightToolNo == 1)
                  tpPnt9D10.PreCodes.Add((object) "M21 K-1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 2)
                  tpPnt9D10.PreCodes.Add((object) "M22 K-1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 3)
                  tpPnt9D10.PreCodes.Add((object) "M23 K-1");
                CamPoint.Points.Add(tpPnt9D10);
              }
              else
                CamPoint.Points.Add(new TpPnt9D(P63, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt5 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 + 90.0, ref EndPnt5);
              Pnt6D P64 = new Pnt6D(EndPnt5.X, EndPnt5.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P64, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt5 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 + 90.0, ref EndPnt5);
              Pnt6D P65 = new Pnt6D(EndPnt5.X, EndPnt5.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P65, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt5 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle2 + 90.0, ref EndPnt5);
              Pnt6D P66 = new Pnt6D(EndPnt5.X, EndPnt5.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P66, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              Line line = new Line(EndPnt1, EndPnt2);
              line.ColorMethod = colorMethodType.byEntity;
              line.Color = Color.Red;
              calcEntities.Add((Entity) line);
              ++num19;
            }
          }
          for (int index8 = 1; index8 <= ((WoodTempVars) Pars).VShapeAngleFinishCount; ++index8)
          {
            if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
            {
              EndPnt1 = new Point3D();
              EndPnt2 = new Point3D();
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(point3D5, point3D6);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
              Point3D EndPnt6 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle2 - 90.0, ref EndPnt6);
              Pnt6D P67 = new Pnt6D(EndPnt6.X, EndPnt6.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P67, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              Point3D EndPnt7 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 - 90.0, ref EndPnt7);
              Pnt6D P68 = new Pnt6D(EndPnt7.X, EndPnt7.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P68, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              Point3D EndPnt8 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 - 90.0, ref EndPnt8);
              Pnt6D P69 = new Pnt6D(EndPnt8.X, EndPnt8.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P69, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              Point3D EndPnt9 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle2 - 90.0, ref EndPnt9);
              Pnt6D P70 = new Pnt6D(EndPnt9.X, EndPnt9.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P70, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              Pnt6D P71 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P71, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
            }
            else
            {
              EndPnt1 = new Point3D();
              EndPnt2 = new Point3D();
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(point3D5, point3D6);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
              Point3D EndPnt10 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle2 + 90.0, ref EndPnt10);
              Pnt6D P72 = new Pnt6D(EndPnt10.X, EndPnt10.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P72, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              Point3D EndPnt11 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 + 90.0, ref EndPnt11);
              Pnt6D P73 = new Pnt6D(EndPnt11.X, EndPnt11.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P73, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              Point3D EndPnt12 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle2 + 90.0, ref EndPnt12);
              Pnt6D P74 = new Pnt6D(EndPnt12.X, EndPnt12.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P74, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              Point3D EndPnt13 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num4, Angle2 + 90.0, ref EndPnt13);
              Pnt6D P75 = new Pnt6D(EndPnt13.X, EndPnt13.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P75, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
            }
          }
          if (index6 == upper)
          {
            Pnt6D P = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          }
          else
          {
            Pnt6D P = new Pnt6D(num10 + 1.0, num11 + 1.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          }
          if (!((WoodSettings) Pars).NickEnable)
          {
            if (index6 < upper)
            {
              if (index6 == upper - 1)
              {
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num8)).ToString("f2")));
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
                num8 += ((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num8);
              }
              else
              {
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num7.ToString("f2")));
                CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
                num8 += num7;
              }
            }
          }
          else if (index6 < upper)
          {
            if (index6 == upper - 1)
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength - num7 * ((double) upper - 1.0)).ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num8 += ((WoodJob) Pars).GrindingLength - num7 * ((double) upper - 1.0);
              num16 += ((WoodJob) Pars).GrindingLength - num7 * ((double) upper - 1.0);
            }
            else
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num7.ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num8 += num7;
              num16 += num7;
            }
          }
          Line line2 = new Line(EndPnt1, EndPnt2);
          line2.ColorMethod = colorMethodType.byEntity;
          line2.Color = Color.Red;
          calcEntities.Add((Entity) line2);
        }
      }
    }
    CamPoint.AfterCodes.Add((object) "M32");
    if (!((WoodSettings) Pars).NickEnable)
    {
      CamPoint.AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).FeedDistance + ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness).ToString("f2")));
    }
    else
    {
      CamPoint.AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 1.0 - num8).ToString("f2")));
      double num20 = num8 + (((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - num8);
    }
    CamPoint.AfterCodes.Add((object) "M31");
    Cam.CamPoints.Add(CamPoint);
    Cam.PreCodes.Add((object) ("//Count = " + ((WoodJob) Pars).FeedCount.ToString()));
    buCall.\u0001.CreateSimulationPointsFromCamPoint(ref Cam, CamPoint, 0.9, 0.2);
  }

  public void doGrindingVShape1(
    DiemakerGrindingShapeSettings Pars,
    ToolBase5 ToolGrinding,
    ToolBase5 ToolNick,
    bool isCircular,
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
    List<Point3D> Vertices1 = new List<Point3D>();
    Vertices1.Add(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, 0.0));
    Vertices1.Add(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - num1));
    Vertices1.Add(new Point3D(((buWood) Pars).MaterialThickness / 2.0 - ((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight));
    Vertices1.Add(new Point3D(((buWood) Pars).MaterialThickness - ((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - num1));
    Vertices1.Add(new Point3D(((buWood) Pars).MaterialThickness - ((buWood) Pars).MaterialThickness / 2.0, 0.0));
    Vertices1.Add(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, 0.0));
    buCall.\u0001.MiddlePointOfLine(Vertices1[1], Vertices1[2]);
    buCall.\u0001.MiddlePointOfLine(Vertices1[2], Vertices1[3]);
    Point3D point3D8 = (Point3D) null;
    Point3D point3D9 = (Point3D) null;
    if (isCircular)
    {
      Vertices1 = new List<Point3D>();
      buCall.\u0001.Arc3Point(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), new Point3D(0.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight), new Point3D(((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), Plane.XY, new EntityResolution(0.002, 50, 20.0, EntityResolutionType.ByLength), ref Vertices1);
      point3D8 = F_NotchEdit.ToPoint3D(Vertices1[0]);
      point3D9 = F_NotchEdit.ToPoint3D(Vertices1[Vertices1.Count - 1]);
    }
    double num2 = 5.0;
    LinearPath linearPath1 = new LinearPath((ICollection<Point3D>) Vertices1);
    linearPath1.ColorMethod = colorMethodType.byEntity;
    linearPath1.Color = Color.Lime;
    calcEntities.Add((Entity) linearPath1);
    Cam.Tool = (ToolBase5) new ToolGeometry5(ToolGrinding);
    ((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType = ToolType.Flat;
    ((ToolGeometry5) Cam.Tool).Geometry.Length = ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness;
    ((ToolDisplay5) ((ToolGeometry5) Cam.Tool).Geometry).Thickness = 2.0;
    double num3 = 5.0;
    camTpPoint CamPoint = (camTpPoint) new TpPnt9D();
    Pnt6D pnt6D = new Pnt6D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    double num4 = ((PipeBendMoveCommand) Pars).BaseMaterialHeight - ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).VShapeHeightFinishDepth;
    int int32_1 = Convert.ToInt32(buFile5.RoundToUpper(num4 / ((buWood) Pars).VShapeHeightRoughDepth));
    double num5 = Math.Round(num4 / (double) int32_1, 3);
    double x = 0.0;
    double num6 = ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness - ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness;
    int upper = (int) buFile5.RoundToUpper(((WoodJob) Pars).GrindingLength / num6);
    double num7 = 0.0;
    if (((WoodSettings) Pars).NickEnable)
    {
      camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
      camTpPoint.PreCodes.Add((object) "G75");
      string str = " K1";
      if (((WoodSettings) Pars).NickReverseDir)
        str = " K-1";
      if (((WoodSettings) Pars).NickToolNo == 1)
        camTpPoint.PreCodes.Add((object) ("M21" + str));
      if (((WoodSettings) Pars).NickToolNo == 2)
        camTpPoint.PreCodes.Add((object) ("M22" + str));
      if (((WoodSettings) Pars).NickToolNo == 3)
        camTpPoint.PreCodes.Add((object) ("M23" + str));
      camTpPoint.PreCodes.Add((object) "M154");
      camTpPoint.PreCodes.Add((object) "G75");
      camTpPoint.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      camTpPoint.PreCodes.Add((object) "G75");
      Pnt6D P1 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P1, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.Points[camTpPoint.Points.Count - 1].EnableAxes.Y = false;
      Pnt6D P2 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P2, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P3 = new Pnt6D(0.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P3, ((WoodSettings) Pars).NickRoughVel, 1, false));
      Pnt6D P4 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 0.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P4, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P5 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P5, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P6 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P6, ((WoodSettings) Pars).NickFinishVel, 1, false));
      Pnt6D P7 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P7, ((WoodSettings) Pars).NickRoughVel, 0, false));
      x = P7.X;
      camTpPoint.AfterCodes.Add((object) "M32");
      camTpPoint.AfterCodes.Add((object) ("M40 K" + (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness / 2.0).ToString("f2")));
      num7 += ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness / 2.0;
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
    if (!isCircular)
    {
      for (int index1 = 1; index1 <= upper; ++index1)
      {
        Pnt6D P8 = new Pnt6D(x, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
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
            Pnt6D P12 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num5 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P12, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P13 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num5 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P13, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P14 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P14, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          }
          else if (index2 % 2 == 1)
          {
            Pnt6D P15 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num5 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P15, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P16 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num5 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P16, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          }
          else
          {
            Pnt6D P17 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num5 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P17, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P18 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num5 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P18, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          }
          Line line = new Line(new Point3D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num5), new Point3D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index2 * num5));
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
        Pnt6D P28 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P28, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
        Pnt6D P29 = new Pnt6D(-Math.Abs(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X) - ((ToolGeometry5) ToolGrinding).Geometry.Diameter / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P29, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
        if (((WoodSettings) Pars).VShapeAngleEnable)
        {
          double num8 = ((buWood) Pars).MaterialThickness / 2.0 - ((WoodRuntimeSettings) Pars).VShapeAngleFinishDepth;
          int int32_2 = Convert.ToInt32(buFile5.RoundToUpper(num8 / ((WoodRuntimeSettings) Pars).VShapeAngleRoughDepth));
          double num9 = Math.Round(num8 / (double) int32_2, 3);
          double num10 = 1.0;
          Point3D EndPnt3 = new Point3D();
          int num11 = 0;
          for (int index3 = int32_2; index3 >= 1; --index3)
          {
            EndPnt1 = new Point3D();
            EndPnt2 = new Point3D();
            if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
            {
              point3D3 = F_NotchEdit.ToPoint3D(Vertices1[1]);
              point3D4 = F_NotchEdit.ToPoint3D(Vertices1[2]);
              Angle1 = buCall.\u0001.PointAngle(Vertices1[2], Vertices1[1]);
              buCall.\u0001.LineWithLengthAndAngle(point3D3, (double) index3 * num9, Angle1 + 90.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(point3D4, (double) index3 * num9, Angle1 + 90.0, ref EndPnt2);
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P30 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              if (num11 == 0)
              {
                TpPnt9D tpPnt9D3 = new TpPnt9D(P30, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                if (((WoodJob) Pars).VShapeHeightToolNo == 1)
                  tpPnt9D3.PreCodes.Add((object) "M21 K1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 2)
                  tpPnt9D3.PreCodes.Add((object) "M22 K1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 3)
                  tpPnt9D3.PreCodes.Add((object) "M23 K1");
                CamPoint.Points.Add(tpPnt9D3);
              }
              else
              {
                TpPnt9D tpPnt9D4 = new TpPnt9D(P30, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                CamPoint.Points.Add(tpPnt9D4);
              }
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P31 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P31, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P32 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P32, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle1 + 90.0, ref EndPnt3);
              Pnt6D P33 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P33, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              ++num11;
            }
            else
            {
              point3D3 = F_NotchEdit.ToPoint3D(Vertices1[2]);
              point3D4 = F_NotchEdit.ToPoint3D(Vertices1[1]);
              Angle1 = buCall.\u0001.PointAngle(Vertices1[1], Vertices1[2]);
              buCall.\u0001.LineWithLengthAndAngle(point3D3, (double) index3 * num9, Angle1 - 90.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(point3D4, (double) index3 * num9, Angle1 - 90.0, ref EndPnt2);
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle1, ref EndPnt2);
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P34 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              if (num11 == 0)
              {
                TpPnt9D tpPnt9D5 = new TpPnt9D(P34, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                if (((WoodJob) Pars).VShapeHeightToolNo == 1)
                  tpPnt9D5.PreCodes.Add((object) "M21 K1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 2)
                  tpPnt9D5.PreCodes.Add((object) "M22 K1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 3)
                  tpPnt9D5.PreCodes.Add((object) "M23 K1");
                CamPoint.Points.Add(tpPnt9D5);
              }
              else
              {
                TpPnt9D tpPnt9D6 = new TpPnt9D(P34, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                CamPoint.Points.Add(tpPnt9D6);
              }
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P35 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P35, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P36 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P36, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P37 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P37, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              ++num11;
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle1 + 90.0, ref EndPnt3);
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle1 + 90.0, ref EndPnt3);
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle1 - 90.0, ref EndPnt3);
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle1 - 90.0, ref EndPnt3);
              Pnt6D P45 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P45, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
            }
          }
          Line line1 = new Line(EndPnt1, EndPnt2);
          line1.ColorMethod = colorMethodType.byEntity;
          line1.Color = Color.Red;
          calcEntities.Add((Entity) line1);
          Pnt6D P46 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P46, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          Pnt6D P47 = new Pnt6D(((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 10.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P47, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          double num12 = ((buWood) Pars).MaterialThickness / 2.0 - ((WoodRuntimeSettings) Pars).VShapeAngleFinishDepth;
          int int32_3 = Convert.ToInt32(buFile5.RoundToUpper(num12 / ((WoodRuntimeSettings) Pars).VShapeAngleRoughDepth));
          double num13 = Math.Round(num12 / (double) int32_3, 3);
          int num14 = 0;
          for (int index5 = int32_3; index5 >= 1; --index5)
          {
            if (((WoodItemType) Pars).VShapeAngleUpDownMode == UpDownDirectionType.DownToUp)
            {
              Angle2 = buCall.\u0001.PointAngle(Vertices1[2], Vertices1[3]);
              point3D5 = F_NotchEdit.ToPoint3D(Vertices1[3]);
              point3D6 = F_NotchEdit.ToPoint3D(Vertices1[2]);
              EndPnt1 = new Point3D();
              EndPnt2 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(point3D5, (double) index5 * num13, Angle2 - 90.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(point3D6, (double) index5 * num13, Angle2 - 90.0, ref EndPnt2);
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle2 - 90.0, ref EndPnt3);
              Pnt6D P48 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              if (num14 == 0)
              {
                TpPnt9D tpPnt9D7 = new TpPnt9D(P48, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                if (((WoodJob) Pars).VShapeHeightToolNo == 1)
                  tpPnt9D7.PreCodes.Add((object) "M21 K-1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 2)
                  tpPnt9D7.PreCodes.Add((object) "M22 K-1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 3)
                  tpPnt9D7.PreCodes.Add((object) "M23 K-1");
                CamPoint.Points.Add(tpPnt9D7);
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle2 - 90.0, ref EndPnt3);
              Pnt6D P51 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P51, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              Line line2 = new Line(EndPnt1, EndPnt2);
              line2.ColorMethod = colorMethodType.byEntity;
              line2.Color = Color.Red;
              calcEntities.Add((Entity) line2);
              ++num14;
            }
            else
            {
              point3D5 = F_NotchEdit.ToPoint3D(Vertices1[2]);
              point3D6 = F_NotchEdit.ToPoint3D(Vertices1[3]);
              Angle2 = buCall.\u0001.PointAngle(Vertices1[3], Vertices1[2]);
              EndPnt1 = new Point3D();
              EndPnt2 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(point3D5, (double) index5 * num13, Angle2 + 90.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(point3D6, (double) index5 * num13, Angle2 + 90.0, ref EndPnt2);
              Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(EndPnt1, EndPnt2);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2 - 180.0, ref EndPnt1);
              buCall.\u0001.LineWithLengthAndAngle(CenterPnt, ((WoodRuntimeSettings) Pars).VShapeAngleWidth / 2.0, Angle2, ref EndPnt2);
              EndPnt3 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle2 + 90.0, ref EndPnt3);
              Pnt6D P52 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              if (num14 == 0)
              {
                TpPnt9D tpPnt9D8 = new TpPnt9D(P52, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false);
                if (((WoodJob) Pars).VShapeHeightToolNo == 1)
                  tpPnt9D8.PreCodes.Add((object) "M21 K-1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 2)
                  tpPnt9D8.PreCodes.Add((object) "M22 K-1");
                if (((WoodJob) Pars).VShapeHeightToolNo == 3)
                  tpPnt9D8.PreCodes.Add((object) "M23 K-1");
                CamPoint.Points.Add(tpPnt9D8);
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle2 + 90.0, ref EndPnt3);
              Pnt6D P55 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P55, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              Line line3 = new Line(EndPnt1, EndPnt2);
              line3.ColorMethod = colorMethodType.byEntity;
              line3.Color = Color.Red;
              calcEntities.Add((Entity) line3);
              ++num14;
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle2 - 90.0, ref EndPnt3);
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle2 - 90.0, ref EndPnt3);
              Pnt6D P59 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P59, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
              Pnt6D P60 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt1, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle2 + 90.0, ref EndPnt3);
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
              buCall.\u0001.LineWithLengthAndAngle(EndPnt2, ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + num10, Angle2 + 90.0, ref EndPnt3);
              Pnt6D P64 = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P64, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
            }
          }
          Pnt6D P65 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num3 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P65, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          Line line4 = new Line(EndPnt1, EndPnt2);
          line4.ColorMethod = colorMethodType.byEntity;
          line4.Color = Color.Red;
          calcEntities.Add((Entity) line4);
        }
        if (!((WoodSettings) Pars).NickEnable)
        {
          if (index1 < upper)
          {
            if (index1 == upper - 1)
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num7)).ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num7 += ((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num7);
            }
            else
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num6.ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num7 += num6;
            }
          }
        }
        else if (index1 < upper)
        {
          if (index1 == upper - 1)
          {
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - num6 * ((double) upper - 1.0)).ToString("f2")));
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
            num7 += ((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - num6 * ((double) upper - 1.0);
          }
          else
          {
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num6.ToString("f2")));
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
            num7 += num6;
          }
        }
      }
    }
    else
    {
      for (int index7 = 1; index7 <= upper; ++index7)
      {
        double num15 = ((PipeBendMoveCommand) Pars).BaseMaterialHeight - ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).VShapeHeightFinishDepth;
        int int32_4 = Convert.ToInt32(buFile5.RoundToUpper(num15 / ((buWood) Pars).VShapeHeightRoughDepth));
        double num16 = Math.Round(num15 / (double) int32_4, 3);
        if (((WoodJob) Pars).VShapeHeightZigzag)
        {
          Pnt6D P = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P, ((buWood) Pars).VShapeHeightRoughVel, 0, false)
          {
            EnableAxes = {
              X = false
            }
          });
          TpPnt9D tpPnt9D9 = new TpPnt9D(P, ((buWood) Pars).VShapeHeightRoughVel, 0, false);
          CamPoint.Points.Add(tpPnt9D9);
        }
        for (int index8 = 1; index8 <= int32_4; ++index8)
        {
          if (!((WoodJob) Pars).VShapeHeightZigzag)
          {
            Pnt6D P66 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P66, ((buWood) Pars).VShapeHeightRoughVel, 0, false));
            Pnt6D P67 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index8 * num16 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P67, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P68 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index8 * num16 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P68, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P69 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P69, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          }
          else if (index8 % 2 == 1)
          {
            Pnt6D P70 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index8 * num16 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P70, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P71 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index8 * num16 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P71, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          }
          else
          {
            Pnt6D P72 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index8 * num16 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P72, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
            Pnt6D P73 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index8 * num16 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P73, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
          }
          Line line = new Line(new Point3D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index8 * num16), new Point3D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index8 * num16));
          line.ColorMethod = colorMethodType.byEntity;
          line.Color = Color.Cyan;
          calcEntities.Add((Entity) line);
        }
        if (((buWood) Pars).VShapeHeightFinishDepth != 0.0)
        {
          if (!((WoodJob) Pars).VShapeHeightZigzag)
          {
            Pnt6D P74 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P74, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P75 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P75, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P76 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P76, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P77 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P77, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          }
          else if (((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X > 0.0)
          {
            Pnt6D P78 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P78, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P79 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P79, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          }
          else
          {
            Pnt6D P80 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P80, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
            Pnt6D P81 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P81, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
          }
          Line line = new Line(new Point3D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight), new Point3D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight));
          line.ColorMethod = colorMethodType.byEntity;
          line.Color = Color.Blue;
          calcEntities.Add((Entity) line);
        }
        if (((WoodJob) Pars).VShapeHeightZigzag)
        {
          Pnt6D P = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
        }
        if (((WoodSettings) Pars).VShapeAngleEnable)
        {
          Pnt6D P82 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P82, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          Pnt6D P83 = new Pnt6D(-Math.Abs(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X) - 20.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P83, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          double num17 = ((PipeBendMoveCommand) Pars).TargetMaterialHeight - point3D8.Y - ((WoodRuntimeSettings) Pars).VShapeAngleFinishDepth;
          int int32_5 = Convert.ToInt32(buFile5.RoundToUpper(num17 / ((WoodRuntimeSettings) Pars).VShapeAngleRoughDepth));
          double num18 = Math.Round(num17 / (double) int32_5, 3);
          Point3D point3D10 = new Point3D();
          EntityResolution EntResolution = new EntityResolution(0.001, 20, 20.0, EntityResolutionType.ByLength);
          EntResolution.MinPointCount = 50;
          for (int index9 = 1; index9 <= int32_5; ++index9)
          {
            List<Point3D> Vertices2 = new List<Point3D>();
            Point3D FirstPoint = new Point3D(point3D8.X, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - (double) index9 * num18);
            Point3D SecondPoint = new Point3D((point3D8.X + point3D9.X) / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight);
            Point3D ThirdPoint = new Point3D(point3D9.X, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - (double) index9 * num18);
            buCall.\u0001.Arc3Point(FirstPoint, SecondPoint, ThirdPoint, Plane.XY, EntResolution, ref Vertices2);
            LinearPath linearPath2 = new LinearPath((ICollection<Point3D>) Vertices2);
            linearPath2.ColorMethod = colorMethodType.byEntity;
            linearPath2.Color = Color.Red;
            calcEntities.Add((Entity) linearPath2);
            if (!((WoodTempVars) Pars).VShapeAngleZigzag)
            {
              Vertices2.Reverse();
              for (int index10 = 0; index10 <= Vertices2.Count - 2; ++index10)
              {
                double num19 = buCall.\u0001.PointAngle(Vertices2[index10 + 1], Vertices2[index10]);
                Point3D EndPnt4 = new Point3D();
                buCall.\u0001.LineWithLengthAndAngle(Vertices2[index10], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num19 + 90.0, ref EndPnt4);
                Pnt6D P84 = new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0);
                CamPoint.Points.Add(new TpPnt9D(P84, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              }
              Pnt6D P85 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P85, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
              Pnt6D P86 = new Pnt6D(-((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X - 20.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P86, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
            }
            else if (index9 % 2 == 1)
            {
              Vertices2.Reverse();
              for (int index11 = 0; index11 <= Vertices2.Count - 2; ++index11)
              {
                double num20 = buCall.\u0001.PointAngle(Vertices2[index11 + 1], Vertices2[index11]);
                Point3D EndPnt5 = new Point3D();
                buCall.\u0001.LineWithLengthAndAngle(Vertices2[index11], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num20 + 90.0, ref EndPnt5);
                Pnt6D P87 = new Pnt6D(EndPnt5.X, EndPnt5.Y, 0.0);
                CamPoint.Points.Add(new TpPnt9D(P87, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              }
              double num21 = buCall.\u0001.PointAngle(Vertices2[Vertices2.Count - 2], Vertices2[Vertices2.Count - 1]) + 180.0;
              Point3D EndPnt6 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(Vertices2[Vertices2.Count - 1], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num21 + 90.0, ref EndPnt6);
              Pnt6D P88 = new Pnt6D(EndPnt6.X, EndPnt6.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P88, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              Pnt6D P89 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X + 10.0, ((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P89, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
            }
            else
            {
              for (int index12 = 0; index12 <= Vertices2.Count - 2; ++index12)
              {
                double num22 = buCall.\u0001.PointAngle(Vertices2[index12 + 1], Vertices2[index12]);
                Point3D EndPnt7 = new Point3D();
                buCall.\u0001.LineWithLengthAndAngle(Vertices2[index12], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num22 - 90.0, ref EndPnt7);
                Pnt6D P90 = new Pnt6D(EndPnt7.X, EndPnt7.Y, 0.0);
                CamPoint.Points.Add(new TpPnt9D(P90, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              }
              double num23 = buCall.\u0001.PointAngle(Vertices2[Vertices2.Count - 2], Vertices2[Vertices2.Count - 1]) + 180.0;
              Point3D EndPnt8 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(Vertices2[Vertices2.Count - 1], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num23 - 90.0, ref EndPnt8);
              Pnt6D P91 = new Pnt6D(EndPnt8.X, EndPnt8.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P91, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
              Pnt6D P92 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X - 10.0, ((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P92, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
            }
          }
          List<Point3D> Vertices3 = new List<Point3D>();
          buCall.\u0001.Arc3Point(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), new Point3D(0.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight), new Point3D(((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), Plane.XY, EntResolution, ref Vertices3);
          if (!((WoodTempVars) Pars).VShapeAngleZigzag)
          {
            Vertices3.Reverse();
            for (int index13 = 0; index13 <= Vertices3.Count - 2; ++index13)
            {
              double num24 = buCall.\u0001.PointAngle(Vertices3[index13 + 1], Vertices3[index13]);
              Point3D EndPnt9 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(Vertices3[index13], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num24 + 90.0, ref EndPnt9);
              Pnt6D P93 = new Pnt6D(EndPnt9.X, EndPnt9.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P93, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
            }
            Pnt6D P94 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P94, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          }
          else if (((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X > 0.0)
          {
            for (int index14 = 0; index14 <= Vertices3.Count - 2; ++index14)
            {
              double num25 = buCall.\u0001.PointAngle(Vertices3[index14 + 1], Vertices3[index14]);
              Point3D EndPnt10 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(Vertices3[index14], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num25 - 90.0, ref EndPnt10);
              Pnt6D P95 = new Pnt6D(EndPnt10.X, EndPnt10.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P95, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
            }
            Pnt6D P96 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P96, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          }
          else
          {
            Vertices3.Reverse();
            for (int index15 = 0; index15 <= Vertices3.Count - 2; ++index15)
            {
              double num26 = buCall.\u0001.PointAngle(Vertices3[index15 + 1], Vertices3[index15]);
              Point3D EndPnt11 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(Vertices3[index15], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num26 + 90.0, ref EndPnt11);
              Pnt6D P97 = new Pnt6D(EndPnt11.X, EndPnt11.Y, 0.0);
              CamPoint.Points.Add(new TpPnt9D(P97, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
            }
            Pnt6D P98 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
            CamPoint.Points.Add(new TpPnt9D(P98, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
          }
        }
        if (!((WoodSettings) Pars).NickEnable)
        {
          if (index7 < upper)
          {
            if (index7 == upper - 1)
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num7)).ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num7 += ((WoodJob) Pars).GrindingLength - (((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness + num7);
            }
            else
            {
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num6.ToString("f2")));
              CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
              num7 += num6;
            }
          }
        }
        else if (index7 < upper)
        {
          if (index7 == upper - 1)
          {
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - num6 * ((double) upper - 1.0)).ToString("f2")));
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
            num7 += ((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - num6 * ((double) upper - 1.0);
          }
          else
          {
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M32");
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) ("M40 K" + num6.ToString("f2")));
            CamPoint.Points[CamPoint.Points.Count - 1].AfterCodes.Add((object) "M31");
            num7 += num6;
          }
        }
      }
    }
    CamPoint.AfterCodes.Add((object) "M32");
    double num27;
    if (!((WoodSettings) Pars).NickEnable)
    {
      ArrayList afterCodes = CamPoint.AfterCodes;
      num27 = ((WoodJob) Pars).FeedDistance + ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness;
      string str = "M40 K" + num27.ToString("f2");
      afterCodes.Add((object) str);
    }
    else
    {
      ArrayList afterCodes = CamPoint.AfterCodes;
      num27 = ((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 1.0 - num7;
      string str = "M40 K" + num27.ToString("f2");
      afterCodes.Add((object) str);
      double num28 = num7 + (((WoodJob) Pars).GrindingLength + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - num7);
    }
    CamPoint.AfterCodes.Add((object) "M31");
    Cam.CamPoints.Add(CamPoint);
    if (((WoodSettings) Pars).NickEnable)
    {
      camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
      camTpPoint.PreCodes.Add((object) "G75");
      string str1 = " K1";
      if (((WoodSettings) Pars).NickReverseDir)
        str1 = " K-1";
      if (((WoodSettings) Pars).NickToolNo == 1)
        camTpPoint.PreCodes.Add((object) ("M21" + str1));
      if (((WoodSettings) Pars).NickToolNo == 2)
        camTpPoint.PreCodes.Add((object) ("M22" + str1));
      if (((WoodSettings) Pars).NickToolNo == 3)
        camTpPoint.PreCodes.Add((object) ("M23" + str1));
      camTpPoint.PreCodes.Add((object) "M154");
      camTpPoint.PreCodes.Add((object) "G75");
      camTpPoint.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      camTpPoint.PreCodes.Add((object) "G75");
      Pnt6D P99 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P99, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.Points[camTpPoint.Points.Count - 1].EnableAxes.Y = false;
      Pnt6D P100 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P100, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P101 = new Pnt6D(0.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P101, ((WoodSettings) Pars).NickRoughVel, 1, false));
      Pnt6D P102 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 0.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P102, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P103 = new Pnt6D(-((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P103, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P104 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P104, ((WoodSettings) Pars).NickFinishVel, 1, false));
      Pnt6D P105 = new Pnt6D(((WoodJob) Pars).NickWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P105, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.AfterCodes.Add((object) "M32");
      ArrayList afterCodes = camTpPoint.AfterCodes;
      num27 = ((WoodJob) Pars).FeedDistance + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness;
      string str2 = "M40 K" + num27.ToString("f2");
      afterCodes.Add((object) str2);
      camTpPoint.AfterCodes.Add((object) "M31");
      Cam.CamPoints.Add(camTpPoint);
    }
    Cam.PreCodes.Add((object) ("//Count = " + ((WoodJob) Pars).FeedCount.ToString()));
    buCall.\u0001.CreateSimulationPointsFromCamPoint(ref Cam, CamPoint, 0.9, 0.2);
  }

  public void doGrindingCircularShape(
    DiemakerGrindingShapeSettings Pars,
    ToolBase5 ToolGrinding,
    ToolBase5 ToolNick,
    ref List<Entity> calcEntities,
    ref camTp Cam)
  {
    Cam = new camTp();
    Point3D point3D1 = new Point3D();
    Point3D point3D2 = new Point3D();
    Point3D point3D3 = new Point3D();
    Point3D point3D4 = new Point3D();
    Point3D point3D5 = new Point3D();
    Point3D point3D6 = new Point3D();
    Point3D point3D7 = new Point3D();
    Point3D point3D8 = new Point3D();
    Point3D point3D9 = new Point3D();
    Entity rectangleEntity = (Entity) null;
    buCall.\u0001.DrawRectangle(new Point3D(), ((buWood) Pars).MaterialThickness, ((PipeBendMoveCommand) Pars).BaseMaterialHeight, Plane.XY, ref rectangleEntity);
    rectangleEntity.Translate(-((buWood) Pars).MaterialThickness / 2.0, 0.0);
    calcEntities.Add(rectangleEntity);
    double num1 = ((buWood) Pars).MaterialThickness / 2.0 / Math.Tan(buString5.DegreeToRadian(((buWood) Pars).VShapeTargetAngle / 2.0));
    List<Point3D> Vertices1 = new List<Point3D>();
    buCall.\u0001.Arc3Point(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), new Point3D(0.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight), new Point3D(((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), Plane.XY, new EntityResolution(0.002, 50, 20.0, EntityResolutionType.ByLength), ref Vertices1);
    Point3D point3D10 = F_NotchEdit.ToPoint3D(Vertices1[0]);
    Point3D point3D11 = F_NotchEdit.ToPoint3D(Vertices1[Vertices1.Count - 1]);
    double num2 = 5.0;
    LinearPath linearPath1 = new LinearPath((ICollection<Point3D>) Vertices1);
    linearPath1.ColorMethod = colorMethodType.byEntity;
    linearPath1.Color = Color.Red;
    linearPath1.LineWeightMethod = colorMethodType.byEntity;
    linearPath1.LineWeight = 3f;
    calcEntities.Add((Entity) linearPath1);
    Cam.Tool = (ToolBase5) new ToolGeometry5(ToolGrinding);
    ((ToolData5) ((ToolGeometry5) Cam.Tool).Geometry).GeometryType = ToolType.Flat;
    ((ToolGeometry5) Cam.Tool).Geometry.Length = ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness;
    ((ToolDisplay5) ((ToolGeometry5) Cam.Tool).Geometry).Thickness = 2.0;
    camTpPoint CamPoint = (camTpPoint) new TpPnt9D();
    Pnt6D pnt6D = new Pnt6D();
    TpPnt9D tpPnt9D = new TpPnt9D();
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
      Pnt6D P4 = new Pnt6D(0.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 2.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P4, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P5 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 2.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P5, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P6 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P6, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P7 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P7, ((WoodSettings) Pars).NickFinishVel, 1, false));
      Pnt6D P8 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 10.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P8, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.AfterCodes.Add((object) "M32");
      camTpPoint.AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).FeedDistance + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness / 2.0).ToString("f2")));
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
    double num3 = ((PipeBendMoveCommand) Pars).BaseMaterialHeight - ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).VShapeHeightFinishDepth;
    int int32_1 = Convert.ToInt32(buFile5.RoundToUpper(num3 / ((buWood) Pars).VShapeHeightRoughDepth));
    double num4 = Math.Round(num3 / (double) int32_1, 3);
    if (((WoodJob) Pars).VShapeHeightZigzag)
    {
      Pnt6D P = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P, ((buWood) Pars).VShapeHeightRoughVel, 0, false));
    }
    for (int index = 1; index <= int32_1; ++index)
    {
      if (!((WoodJob) Pars).VShapeHeightZigzag)
      {
        Pnt6D P9 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P9, ((buWood) Pars).VShapeHeightRoughVel, 0, false));
        Pnt6D P10 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P10, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
        Pnt6D P11 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P11, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
        Pnt6D P12 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P12, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
      }
      else if (index % 2 == 1)
      {
        Pnt6D P13 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P13, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
        Pnt6D P14 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P14, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
      }
      else
      {
        Pnt6D P15 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P15, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
        Pnt6D P16 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index * num4 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P16, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
      }
      Line line = new Line(new Point3D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index * num4), new Point3D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight - (double) index * num4));
      line.ColorMethod = colorMethodType.byEntity;
      line.Color = Color.Cyan;
      calcEntities.Add((Entity) line);
    }
    if (((buWood) Pars).VShapeHeightFinishDepth != 0.0)
    {
      if (!((WoodJob) Pars).VShapeHeightZigzag)
      {
        Pnt6D P17 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P17, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
        Pnt6D P18 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P18, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
        Pnt6D P19 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P19, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
        Pnt6D P20 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P20, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
      }
      else if (((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X > 0.0)
      {
        Pnt6D P21 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P21, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
        Pnt6D P22 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P22, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
      }
      else
      {
        Pnt6D P23 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P23, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
        Pnt6D P24 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P24, ((buWood) Pars).VShapeHeightFinishVel, 1, false));
      }
      Line line = new Line(new Point3D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight), new Point3D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight));
      line.ColorMethod = colorMethodType.byEntity;
      line.Color = Color.Blue;
      calcEntities.Add((Entity) line);
    }
    if (((WoodJob) Pars).VShapeHeightZigzag)
    {
      Pnt6D P = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 1.0 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P, ((buWood) Pars).VShapeHeightRoughVel, 1, false));
    }
    Pnt6D P25 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
    CamPoint.Points.Add(new TpPnt9D(P25, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
    Pnt6D P26 = new Pnt6D(-Math.Abs(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X) - 20.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
    CamPoint.Points.Add(new TpPnt9D(P26, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
    double num5 = ((PipeBendMoveCommand) Pars).TargetMaterialHeight - point3D10.Y - ((WoodRuntimeSettings) Pars).VShapeAngleFinishDepth;
    int int32_2 = Convert.ToInt32(buFile5.RoundToUpper(num5 / ((WoodRuntimeSettings) Pars).VShapeAngleRoughDepth));
    double num6 = Math.Round(num5 / (double) int32_2, 3);
    Point3D point3D12 = new Point3D();
    EntityResolution EntResolution = new EntityResolution(0.001, 20, 20.0, EntityResolutionType.ByLength);
    EntResolution.MinPointCount = 50;
    for (int index1 = 1; index1 <= int32_2; ++index1)
    {
      List<Point3D> Vertices2 = new List<Point3D>();
      Point3D FirstPoint = new Point3D(point3D10.X, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - (double) index1 * num6);
      Point3D SecondPoint = new Point3D((point3D10.X + point3D11.X) / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight);
      Point3D ThirdPoint = new Point3D(point3D11.X, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - (double) index1 * num6);
      buCall.\u0001.Arc3Point(FirstPoint, SecondPoint, ThirdPoint, Plane.XY, EntResolution, ref Vertices2);
      LinearPath linearPath2 = new LinearPath((ICollection<Point3D>) Vertices2);
      linearPath2.ColorMethod = colorMethodType.byEntity;
      linearPath2.Color = Color.Red;
      calcEntities.Add((Entity) linearPath2);
      if (!((WoodTempVars) Pars).VShapeAngleZigzag)
      {
        Vertices2.Reverse();
        for (int index2 = 0; index2 <= Vertices2.Count - 2; ++index2)
        {
          double num7 = buCall.\u0001.PointAngle(Vertices2[index2 + 1], Vertices2[index2]);
          Point3D EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(Vertices2[index2], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num7 + 90.0, ref EndPnt);
          Pnt6D P27 = new Pnt6D(EndPnt.X, EndPnt.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P27, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
        }
        Pnt6D P28 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P28, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
        Pnt6D P29 = new Pnt6D(-((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X - 20.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P29, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
      }
      else if (index1 % 2 == 1)
      {
        Vertices2.Reverse();
        for (int index3 = 0; index3 <= Vertices2.Count - 2; ++index3)
        {
          double num8 = buCall.\u0001.PointAngle(Vertices2[index3 + 1], Vertices2[index3]);
          Point3D EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(Vertices2[index3], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num8 + 90.0, ref EndPnt);
          Pnt6D P30 = new Pnt6D(EndPnt.X, EndPnt.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P30, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
        }
        double num9 = buCall.\u0001.PointAngle(Vertices2[Vertices2.Count - 2], Vertices2[Vertices2.Count - 1]) + 180.0;
        Point3D EndPnt1 = new Point3D();
        buCall.\u0001.LineWithLengthAndAngle(Vertices2[Vertices2.Count - 1], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num9 + 90.0, ref EndPnt1);
        Pnt6D P31 = new Pnt6D(EndPnt1.X, EndPnt1.Y, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P31, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
        Pnt6D P32 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X + 10.0, ((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.Y, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P32, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
      }
      else
      {
        for (int index4 = 0; index4 <= Vertices2.Count - 2; ++index4)
        {
          double num10 = buCall.\u0001.PointAngle(Vertices2[index4 + 1], Vertices2[index4]);
          Point3D EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(Vertices2[index4], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num10 - 90.0, ref EndPnt);
          Pnt6D P33 = new Pnt6D(EndPnt.X, EndPnt.Y, 0.0);
          CamPoint.Points.Add(new TpPnt9D(P33, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
        }
        double num11 = buCall.\u0001.PointAngle(Vertices2[Vertices2.Count - 2], Vertices2[Vertices2.Count - 1]) + 180.0;
        Point3D EndPnt2 = new Point3D();
        buCall.\u0001.LineWithLengthAndAngle(Vertices2[Vertices2.Count - 1], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num11 - 90.0, ref EndPnt2);
        Pnt6D P34 = new Pnt6D(EndPnt2.X, EndPnt2.Y, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P34, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
        Pnt6D P35 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X - 10.0, ((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.Y, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P35, ((WoodRuntimeSettings) Pars).VShapeAngleRoughVel, 1, false));
      }
    }
    List<Point3D> Vertices3 = new List<Point3D>();
    buCall.\u0001.Arc3Point(new Point3D(-((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), new Point3D(0.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight), new Point3D(((buWood) Pars).MaterialThickness / 2.0, ((PipeBendMoveCommand) Pars).TargetMaterialHeight - ((buWood) Pars).MaterialThickness / 3.0), Plane.XY, EntResolution, ref Vertices3);
    if (!((WoodTempVars) Pars).VShapeAngleZigzag)
    {
      Vertices3.Reverse();
      for (int index = 0; index <= Vertices3.Count - 2; ++index)
      {
        double num12 = buCall.\u0001.PointAngle(Vertices3[index + 1], Vertices3[index]);
        Point3D EndPnt = new Point3D();
        buCall.\u0001.LineWithLengthAndAngle(Vertices3[index], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num12 + 90.0, ref EndPnt);
        Pnt6D P36 = new Pnt6D(EndPnt.X, EndPnt.Y, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P36, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
      }
      Pnt6D P37 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P37, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
    }
    else if (((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X > 0.0)
    {
      for (int index = 0; index <= Vertices3.Count - 2; ++index)
      {
        double num13 = buCall.\u0001.PointAngle(Vertices3[index + 1], Vertices3[index]);
        Point3D EndPnt = new Point3D();
        buCall.\u0001.LineWithLengthAndAngle(Vertices3[index], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num13 - 90.0, ref EndPnt);
        Pnt6D P38 = new Pnt6D(EndPnt.X, EndPnt.Y, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P38, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
      }
      Pnt6D P39 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P39, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
    }
    else
    {
      Vertices3.Reverse();
      for (int index = 0; index <= Vertices3.Count - 2; ++index)
      {
        double num14 = buCall.\u0001.PointAngle(Vertices3[index + 1], Vertices3[index]);
        Point3D EndPnt = new Point3D();
        buCall.\u0001.LineWithLengthAndAngle(Vertices3[index], ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0 + 0.0, num14 + 90.0, ref EndPnt);
        Pnt6D P40 = new Pnt6D(EndPnt.X, EndPnt.Y, 0.0);
        CamPoint.Points.Add(new TpPnt9D(P40, ((WoodRuntimeSettings) Pars).VShapeAngleFinishVel, 1, false));
      }
      Pnt6D P41 = new Pnt6D(((TpArcData) CamPoint.Points[CamPoint.Points.Count - 1]).P9.X, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + num2 + ((ToolGeometry5) Cam.Tool).Geometry.Diameter / 2.0, 0.0);
      CamPoint.Points.Add(new TpPnt9D(P41, ((buWood) Pars).VShapeHeightFinishVel, 0, false));
    }
    CamPoint.AfterCodes.Add((object) "M32");
    if (!((WoodSettings) Pars).NickEnable)
      CamPoint.AfterCodes.Add((object) ("M40 K" + ((WoodJob) Pars).FeedDistance.ToString("f2")));
    else
      CamPoint.AfterCodes.Add((object) ("M40 K" + (((WoodJob) Pars).FeedDistance + ((ToolDisplay5) ((ToolGeometry5) ToolNick).Geometry).Thickness / 2.0 - ((ToolDisplay5) ((ToolGeometry5) ToolGrinding).Geometry).Thickness / 2.0).ToString("f2")));
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
      Pnt6D P42 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 5.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P42, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.Points[camTpPoint.Points.Count - 1].EnableAxes.Y = false;
      Pnt6D P43 = new Pnt6D(0.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 5.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P43, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P44 = new Pnt6D(0.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P44, ((WoodSettings) Pars).NickRoughVel, 1, false));
      Pnt6D P45 = new Pnt6D(0.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 2.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P45, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P46 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((WoodJob) Pars).NickDepth + ((WoodSettings) Pars).NickFinishDepth + 2.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P46, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P47 = new Pnt6D(-((buWood) Pars).VShapeHeightWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P47, ((WoodSettings) Pars).NickRoughVel, 0, false));
      Pnt6D P48 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((WoodJob) Pars).NickDepth + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P48, ((WoodSettings) Pars).NickFinishVel, 1, false));
      Pnt6D P49 = new Pnt6D(((buWood) Pars).VShapeHeightWidth / 2.0, ((PipeBendMoveCommand) Pars).BaseMaterialHeight + 10.0 + ((ToolGeometry5) ToolNick).Geometry.Diameter / 2.0, 0.0);
      camTpPoint.Points.Add(new TpPnt9D(P49, ((WoodSettings) Pars).NickRoughVel, 0, false));
      camTpPoint.AfterCodes.Add((object) "M32");
      camTpPoint.AfterCodes.Add((object) ("M40 K" + ((WoodJob) Pars).FeedDistance.ToString("f2")));
      camTpPoint.AfterCodes.Add((object) "M31");
      Cam.CamPoints.Add(camTpPoint);
    }
    buCall.\u0001.CreateSimulationPointsFromCamPoint(ref Cam, CamPoint, 0.9, 0.2);
  }
}
