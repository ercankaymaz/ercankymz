// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleMatrialCleanPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleMatrialCleanPars : buSerilization5
{
  public static List<string> Captions;
  public static byte f004BAB;
  public Color colorDataFocus;
  public Color colorAxesDisable;
  public Color colorAxesNoHoming;
  public Color colorCoordinateColor;
  public static List<string> Captions;
  public static byte f004BB1;
  public double SolidOnlineDrawDeviation;
  public double WireframeOnlineDrawZOffset;
  public double DirectionArrowZOffset;
  public double DirectionArrowWidth;
  public double DirectionArrowHeight;
  public bool CamLeavePlungeAsArrowDraw;
  public double CamArrowConeLength;
  public double CamArrowBodyDiameter;

  public void defaultToolWaterJet(ref ToolBase5 ToolWaterjet)
  {
    ((ToolGeometry5) ToolWaterjet).Purpose = ToolPurpose.WaterJet;
    ((ToolData5) ((ToolGeometry5) ToolWaterjet).Geometry).GeometryType = ToolType.WateJet;
    ((ToolGeometry5) ToolWaterjet).Geometry.Diameter = 5.0;
    ((ToolGeometry5) ToolWaterjet).Geometry.Length = 100.0;
  }

  public void defaultToolMillingHead(ref ToolBase5 ToolMilling)
  {
    ((ToolGeometry5) ToolMilling).Purpose = ToolPurpose.MillingHead;
    ((ToolData5) ((ToolGeometry5) ToolMilling).Geometry).GeometryType = ToolType.Flat;
    ((ToolGeometry5) ToolMilling).Geometry.Diameter = 25.0;
    ((ToolGeometry5) ToolMilling).Geometry.Length = 80.0;
  }

  public void GetToolThickness(MarbleToolType ToolType, ref double ToolThickness)
  {
    // ISSUE: unable to decompile the method.
  }

  public void CreateShape(
    MarbleShapeTypes Type,
    double Thickness,
    ref Entity solidEntity,
    ref ICurve wireEntity)
  {
    switch (Type)
    {
      case MarbleShapeTypes.Circle:
        wireEntity = (ICurve) new Circle(Plane.XY, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeCircleDiameter / 2.0);
        ((Entity) wireEntity).Translate(((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeCircleDiameter / 2.0, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeCircleDiameter / 2.0);
        devDept.Eyeshot.Entities.Region region1 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region1.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.Rectangle:
        wireEntity = (ICurve) CompositeCurve.CreateRectangle(((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleWidth, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleHeight);
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region2.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.RoundRectangle:
        if (((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundRadius > 0.0)
        {
          wireEntity = (ICurve) CompositeCurve.CreateRoundedRectangle(((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundWidth, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundHeight, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundRadius);
          ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
          devDept.Eyeshot.Entities.Region region3 = new devDept.Eyeshot.Entities.Region(wireEntity);
          solidEntity = (Entity) region3.ExtrudeAsBrep(Thickness, 0.0, 0.0);
          break;
        }
        wireEntity = (ICurve) CompositeCurve.CreateRectangle(((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundWidth, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundHeight);
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        devDept.Eyeshot.Entities.Region region4 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region4.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.Ellipse:
        wireEntity = (ICurve) new Ellipse(Plane.XY, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseWidth / 2.0, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseHeight / 2.0);
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region5 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region5.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.Polygon:
        List<Point3D> Vertices = new List<Point3D>();
        buCall.\u0001.PolygonCenter(new Point3D(), ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonRadius / 2.0, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonSide, Plane.XY, ref Vertices);
        Vertices.Reverse();
        List<ICurve> curveList1 = new List<ICurve>();
        for (int index = 1; index <= Vertices.Count - 1; ++index)
          curveList1.Add((ICurve) new Line(Vertices[index - 1], Vertices[index]));
        wireEntity = (ICurve) new CompositeCurve((IEnumerable<ICurve>) curveList1);
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region6 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region6.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.Triangle:
        List<Point3D> Points1 = new List<Point3D>();
        Triangle3D Triangles = new Triangle3D(new Pnt3D(), new Pnt3D(((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleWidth, 0.0, 0.0), new Pnt3D(0.0, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleHeight, 0.0));
        buCall.\u0001.Triangle3DoPoints(Triangles, ref Points1);
        List<ICurve> curveList2 = new List<ICurve>();
        for (int index = 1; index <= Points1.Count - 1; ++index)
          curveList2.Add((ICurve) new Line(Points1[index - 1], Points1[index]));
        wireEntity = (ICurve) new CompositeCurve((IEnumerable<ICurve>) curveList2);
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region7 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region7.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.Slot:
        wireEntity = (ICurve) CompositeCurve.CreateSlot(0.0, 0.0, ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotWidth - ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotHeight, ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotHeight / 2.0, ((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation, true);
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region8 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region8.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.Trepezoid:
        List<Point3D> Vertice2D = new List<Point3D>();
        buCall.\u0001.TrapezoidPerpendicular(new Point3D(), ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLength2, ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLength1, ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezHeight, ((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation, Thickness, true, ref Vertice2D, ref wireEntity, ref solidEntity);
        break;
      case MarbleShapeTypes.Arc:
        double arcOutsideLength = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcOutsideLength;
        double shapeArcHeight = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcHeight;
        Arc arc1 = new Arc(Plane.XY, (Point2D) new Point3D(arcOutsideLength, 0.0, 0.0), (Point2D) new Point3D(arcOutsideLength / 2.0, shapeArcHeight, 0.0), (Point2D) new Point3D(), false);
        double Degree1 = buCall.\u0001.PointAngle(arc1.StartPoint, arc1.Center);
        double Degree2 = buCall.\u0001.PointAngle(arc1.EndPoint, arc1.Center);
        if (Degree1 > Degree2)
          Degree1 -= 360.0;
        Arc arc2 = new Arc(Plane.XY, F_NotchEdit.ToPoint3D(arc1.Center), arc1.Radius - ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcThickness, buString5.DegreeToRadian(Degree1), buString5.DegreeToRadian(Degree2));
        Line line1 = new Line(F_NotchEdit.ToPoint3D(arc1.EndPoint), F_NotchEdit.ToPoint3D(arc2.EndPoint));
        Line line2 = new Line(F_NotchEdit.ToPoint3D(arc2.StartPoint), F_NotchEdit.ToPoint3D(arc1.StartPoint));
        wireEntity = (ICurve) new CompositeCurve((IEnumerable<ICurve>) new List<ICurve>()
        {
          (ICurve) arc1,
          (ICurve) line1,
          (ICurve) arc2,
          (ICurve) line2
        });
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region9 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region9.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.ShipNose:
        double x = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseWidth - ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcXDistance * 2.0;
        double y = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseHeight - ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcYDistance * 2.0;
        Arc arc3 = new Arc(Plane.XY, (Point2D) new Point3D(), (Point2D) new Point3D(x / 2.0, -((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcYDistance, 0.0), (Point2D) new Point3D(x, 0.0, 0.0), false);
        Arc arc4 = new Arc(Plane.XY, (Point2D) new Point3D(x, 0.0, 0.0), (Point2D) new Point3D(x + ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcXDistance, y / 2.0, 0.0), (Point2D) new Point3D(x, y, 0.0), false);
        Arc arc5 = new Arc(Plane.XY, (Point2D) new Point3D(x, y, 0.0), (Point2D) new Point3D(x / 2.0, y + ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcYDistance, 0.0), (Point2D) new Point3D(0.0, y, 0.0), false);
        Arc arc6 = new Arc(Plane.XY, (Point2D) new Point3D(0.0, y, 0.0), (Point2D) new Point3D(-((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcXDistance, y / 2.0, 0.0), (Point2D) new Point3D(0.0, 0.0, 0.0), false);
        List<ICurve> curveList3 = new List<ICurve>();
        if (((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRadius <= 0.0)
        {
          curveList3.Add((ICurve) arc3);
          curveList3.Add((ICurve) arc4);
          curveList3.Add((ICurve) arc5);
          curveList3.Add((ICurve) arc6);
        }
        else
        {
          Arc fillet1 = (Arc) null;
          Arc fillet2 = (Arc) null;
          Arc fillet3 = (Arc) null;
          Arc fillet4 = (Arc) null;
          if (Curve.Fillet((ICurve) arc3, (ICurve) arc4, ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRadius, false, false, true, true, out fillet1))
          {
            fillet1.Regen(0.05);
            fillet1 = new Arc(fillet1.StartPoint, fillet1.MidPoint, fillet1.EndPoint, false);
          }
          if (Curve.Fillet((ICurve) arc4, (ICurve) arc5, ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRadius, false, false, true, true, out fillet2))
          {
            fillet2.Regen(0.05);
            fillet2 = new Arc(fillet2.StartPoint, fillet2.MidPoint, fillet2.EndPoint, false);
          }
          if (Curve.Fillet((ICurve) arc5, (ICurve) arc6, ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRadius, false, false, true, true, out fillet3))
          {
            fillet3.Regen(0.05);
            fillet3 = new Arc(fillet3.StartPoint, fillet3.MidPoint, fillet3.EndPoint, false);
          }
          if (Curve.Fillet((ICurve) arc6, (ICurve) arc3, ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRadius, false, false, true, true, out fillet4))
          {
            fillet4.Regen(0.05);
            fillet4 = new Arc(fillet4.StartPoint, fillet4.MidPoint, fillet4.EndPoint, false);
          }
          curveList3.Add((ICurve) arc3);
          curveList3.Add((ICurve) fillet1);
          curveList3.Add((ICurve) arc4);
          curveList3.Add((ICurve) fillet2);
          curveList3.Add((ICurve) arc5);
          curveList3.Add((ICurve) fillet3);
          curveList3.Add((ICurve) arc6);
          curveList3.Add((ICurve) fillet4);
        }
        wireEntity = (ICurve) new CompositeCurve((IEnumerable<ICurve>) curveList3);
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region10 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region10.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.ChamferRectangle:
        if (((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferLength > 0.0)
        {
          List<Point3D> Points2 = new List<Point3D>();
          buCall.\u0001.RectangleChamfer(new Point3D(), ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferWidth, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferHeight, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferLength, Plane.XY, ref Points2);
          List<ICurve> curveList4 = new List<ICurve>();
          for (int index = 1; index <= Points2.Count - 1; ++index)
            curveList4.Add((ICurve) new Line(Points2[index - 1], Points2[index]));
          wireEntity = (ICurve) new CompositeCurve((IEnumerable<ICurve>) curveList4);
          ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
          devDept.Eyeshot.Entities.Region region11 = new devDept.Eyeshot.Entities.Region(wireEntity);
          solidEntity = (Entity) region11.ExtrudeAsBrep(Thickness, 0.0, 0.0);
          break;
        }
        wireEntity = (ICurve) CompositeCurve.CreateRectangle(((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferWidth, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferHeight);
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        devDept.Eyeshot.Entities.Region region12 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region12.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.CrossRectangle:
        wireEntity = (ICurve) CompositeCurve.CreateRectangle(((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossWidth, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossHeight);
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Rotate(Utility.DegToRad(45.0), new Vector3D(0.0, 0.0, 1.0));
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region13 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region13.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.ArcPie:
        Arc arc7 = new Arc(Plane.XY, new Point3D(), ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieRadius, buString5.DegreeToRadian(0.0), buString5.DegreeToRadian(((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieSweepAngle));
        Line line3 = new Line(F_NotchEdit.ToPoint3D(arc7.Center), F_NotchEdit.ToPoint3D(arc7.StartPoint));
        Line line4 = new Line(F_NotchEdit.ToPoint3D(arc7.EndPoint), F_NotchEdit.ToPoint3D(arc7.Center));
        wireEntity = (ICurve) new CompositeCurve((IEnumerable<ICurve>) new List<ICurve>()
        {
          (ICurve) line3,
          (ICurve) arc7,
          (ICurve) line4
        });
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region14 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region14.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.EllipsePie:
        EllipticalArc ellipticalArc = new EllipticalArc(Plane.XY, new Point3D(), ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieWidth, ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieHeight, buString5.DegreeToRadian(0.0), buString5.DegreeToRadian(((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieSweepAngle));
        Line line5 = new Line(F_NotchEdit.ToPoint3D(ellipticalArc.Center), F_NotchEdit.ToPoint3D(ellipticalArc.StartPoint));
        Line line6 = new Line(F_NotchEdit.ToPoint3D(ellipticalArc.EndPoint), F_NotchEdit.ToPoint3D(ellipticalArc.Center));
        wireEntity = (ICurve) new CompositeCurve((IEnumerable<ICurve>) new List<ICurve>()
        {
          (ICurve) line5,
          (ICurve) ellipticalArc,
          (ICurve) line6
        });
        ((Entity) wireEntity).Rotate(Utility.DegToRad(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region15 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region15.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
      case MarbleShapeTypes.ArcSweep:
        Arc arc8 = new Arc(Plane.XY, new Point3D(), ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcBigRadius, buString5.DegreeToRadian(((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcSweepAngle));
        Arc arc9 = new Arc(Plane.XY, new Point3D(), ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcSmallRadius, buString5.DegreeToRadian(((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcSweepAngle));
        Line line7 = new Line(arc8.EndPoint, arc9.EndPoint);
        Line line8 = new Line(arc9.StartPoint, arc8.StartPoint);
        CompositeCurve compositeCurve = new CompositeCurve((IEnumerable<ICurve>) new List<ICurve>()
        {
          (ICurve) arc8,
          (ICurve) line7,
          (ICurve) arc9,
          (ICurve) line8
        });
        compositeCurve.Rotate(buString5.DegreeToRadian(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation), Vector3D.AxisZ);
        wireEntity = (ICurve) compositeCurve;
        ((Entity) wireEntity).Regen(0.1);
        ((Entity) wireEntity).Translate(-((Entity) wireEntity).BoxMin.X, -((Entity) wireEntity).BoxMin.Y);
        devDept.Eyeshot.Entities.Region region16 = new devDept.Eyeshot.Entities.Region(wireEntity);
        solidEntity = (Entity) region16.ExtrudeAsBrep(Thickness, 0.0, 0.0);
        break;
    }
  }

  public void ItemOsnapCalculation(
    ref MarbleItem Item,
    MarbleOsnapCalcType OsnapType,
    double OffsetVal)
  {
    // ISSUE: unable to decompile the method.
  }
}
