// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillMoveOptions
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
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillMoveOptions : buSerilization5
{
  public double WaveFormCShapeWidth;
  public double WaveFormCShapeBaseHeight;
  public double WaveFormZShapeHeight;
  public double WaveFormZShapeWidth;
  public double WaveFormZShapeBaseHeight;
  public double WaveFormRectShapeHeight;
  public double WaveFormRectShapeWidth;
  public double WaveFormRectShapeBaseHeight;
  public double WaveFormShapeCommonHeight;
  public double WaveFormShapeCommonWidth;
  public double WaveFormShapeCommonBaseHeight;
  public double WaveFormShapeCommonCount;
  public double WaveFormShapeCommonRoundRad;
  public double WaveFormShapeCommonChamferLen;
  public int WaveFormRepeatCount;
  public double WaveFormSpace;
  public double SlicesHeight;
  public double ShapeLength;
  public double WaveFormTopHeight;
  public double WaveFormBottomHeight;
  public double WaveFormZHeight;
  public double WaveFormStartOffset;
  public double WaveFormEndOffset;
  public double MoveX;
  public string BlockName;
  public double BlockWidth;

  public void WavePyramitShape(
    FoamWaveShapeArgs Args,
    FoamType Type,
    ref List<FoamPattern> calcPatterns)
  {
    calcPatterns = new List<FoamPattern>();
    Plane refPlane = Plane.XZ;
    if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
      refPlane = Plane.YZ;
    for (double num1 = 0.0; num1 <= (double) (((DrillCNCSettings) Args).RepeatCount - 1); ++num1)
    {
      FoamPattern foamPattern = (FoamPattern) new DrillJobCreateEventHandler();
      double num2 = num1 * ((DrillCNCSettings) Args).Width * (double) ((DrillCNCSettings) Args).WaveCount;
      double x1 = 0.0;
      double x2 = 0.0;
      double x3 = 0.0;
      double x4 = 0.0;
      double y1 = 0.0;
      double y2 = 0.0;
      double y3 = 0.0;
      double y4 = 0.0;
      double z1 = 0.0;
      double z2 = 0.0;
      double z3 = 0.0;
      double z4 = 0.0;
      List<Point3D> refPoint1 = new List<Point3D>();
      List<Point3D> refPoint2 = new List<Point3D>();
      for (double num3 = 0.0; num3 <= (double) (((DrillCNCSettings) Args).WaveCount - 1); ++num3)
      {
        double x5 = 0.0;
        double x6 = 0.0;
        double x7 = 0.0;
        double x8 = 0.0;
        double x9 = 0.0;
        double x10 = 0.0;
        double x11 = 0.0;
        double x12 = 0.0;
        double x13 = 0.0;
        double x14 = 0.0;
        double y5 = 0.0;
        double y6 = 0.0;
        double y7 = 0.0;
        double y8 = 0.0;
        double y9 = 0.0;
        double y10 = 0.0;
        double y11 = 0.0;
        double y12 = 0.0;
        double y13 = 0.0;
        double y14 = 0.0;
        if (Type == FoamType.Pyramid)
        {
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
          {
            x5 = ((DrillCNCSettings) Args).StartWidthOffset + ((DrillCNCSettings) Args).Width / 2.0 + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x6 = ((DrillCNCSettings) Args).StartWidthOffset + ((DrillCNCSettings) Args).Width / 2.0 + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x7 = ((DrillCNCSettings) Args).StartWidthOffset + ((DrillCNCSettings) Args).Width / 2.0 + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x1 = x5;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x2 = x7;
            x8 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x9 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x10 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x3 = x8;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x4 = x10;
          }
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
          {
            y5 = ((DrillCNCSettings) Args).StartWidthOffset + ((DrillCNCSettings) Args).Width / 2.0 + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y6 = ((DrillCNCSettings) Args).StartWidthOffset + ((DrillCNCSettings) Args).Width / 2.0 + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y7 = ((DrillCNCSettings) Args).StartWidthOffset + ((DrillCNCSettings) Args).Width / 2.0 + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y1 = y5;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y2 = y7;
            y8 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y9 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y10 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y3 = y8;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y4 = y10;
          }
          double z5 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z6 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z7 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z8 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z9 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z10 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          z2 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z1 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).BaseHeight - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          z4 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          z3 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          refPoint1.Add(new Point3D(x5, y5, z5));
          refPoint1.Add(new Point3D(x6, y6, z6));
          refPoint1.Add(new Point3D(x7, y7, z7));
          refPoint2.Add(new Point3D(x8, y8, z8));
          refPoint2.Add(new Point3D(x9, y9, z9));
          refPoint2.Add(new Point3D(x10, y10, z10));
        }
        if (Type == FoamType.Rectangle)
        {
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
          {
            x5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x8 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x9 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x1 = x5;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x2 = x8;
            x10 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x11 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x12 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x13 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x14 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x3 = x10;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x4 = x13;
          }
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
          {
            y5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y8 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y9 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + ((DrillCNCSettings) Args).Width / 2.0 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y1 = y5;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y2 = y8;
            y10 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y11 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y12 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y13 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y14 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y3 = y10;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y4 = y13;
          }
          double z11 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z12 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z13 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z14 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z15 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z16 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z17 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z18 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z19 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z20 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z2 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          z1 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          z4 = z2 - ((DrillCNCSettings) Args).Height;
          z3 = ((DrillCNCSettings) Args).ZPos - (((DrillCNCSettings) Args).BaseHeight - ((DrillCNCSettings) Args).Height) + ((DrillCNCSettings) Args).ZOffset;
          refPoint1.Add(new Point3D(x5, y5, z11));
          refPoint1.Add(new Point3D(x6, y6, z12));
          refPoint1.Add(new Point3D(x7, y7, z13));
          refPoint1.Add(new Point3D(x8, y8, z14));
          if (num3 != (double) (((DrillCNCSettings) Args).WaveCount - 1))
            refPoint1.Add(new Point3D(x9, y9, z15));
          refPoint2.Add(new Point3D(x10, y10, z16));
          refPoint2.Add(new Point3D(x11, y11, z17));
          refPoint2.Add(new Point3D(x12, y12, z18));
          refPoint2.Add(new Point3D(x13, y13, z19));
          if (num3 != (double) (((DrillCNCSettings) Args).WaveCount - 1))
            refPoint2.Add(new Point3D(x14, y14, z20));
        }
      }
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref refPoint1);
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref refPoint2);
      if (((DrillCNCSettings) Args).RoundRadius > 0.0)
      {
        List<Point3D> copiedPoint1 = new List<Point3D>();
        buVector5.Copy(refPoint1, ref copiedPoint1);
        refPoint1.Clear();
        refPoint1 = new List<Point3D>();
        buCall.\u0001.FilletPointList(copiedPoint1, ((DrillCNCSettings) Args).RoundRadius, refPlane, ref refPoint1);
        List<Point3D> copiedPoint2 = new List<Point3D>();
        buVector5.Copy(refPoint2, ref copiedPoint2);
        refPoint2.Clear();
        refPoint2 = new List<Point3D>();
        buCall.\u0001.FilletPointList(copiedPoint2, ((DrillCNCSettings) Args).RoundRadius, refPlane, ref refPoint2);
      }
      else if (((DrillCNCSettings) Args).ChamferLen > 0.0)
      {
        List<Point3D> copiedPoint3 = new List<Point3D>();
        buVector5.Copy(refPoint1, ref copiedPoint3);
        refPoint1.Clear();
        refPoint1 = new List<Point3D>();
        buCall.\u0001.ChamferPointList(copiedPoint3, ((DrillCNCSettings) Args).ChamferLen, refPlane, ref refPoint1);
        List<Point3D> copiedPoint4 = new List<Point3D>();
        buVector5.Copy(refPoint2, ref copiedPoint4);
        refPoint2.Clear();
        refPoint2 = new List<Point3D>();
        buCall.\u0001.ChamferPointList(copiedPoint4, ((DrillCNCSettings) Args).ChamferLen, refPlane, ref refPoint2);
      }
      List<Point3D> point3DList1 = new List<Point3D>();
      FoamEntities foamEntities1 = (FoamEntities) new buTuftingCalc();
      buVector5.Copy(refPoint1, ref point3DList1);
      point3DList1.Add(new Point3D(x2, y2, z1));
      point3DList1.Add(new Point3D(x1, y1, z1));
      point3DList1.Add(new Point3D(x1, y1, z2));
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList1);
      double num4 = buCall.\u0001.PolygonArea(point3DList1, this.ConvertPlane(((DrillCNCSettings) Args).refPlane));
      double num5 = buCall.\u0001.Length3D(point3DList1);
      ((\u0084.\u0001) ((DrillItem) foamEntities1).GroupEntity.Outside).Entities.Add((buEntity) new buShape(point3DList1));
      List<Point3D> point3DList2 = new List<Point3D>();
      FoamEntities foamEntities2 = (FoamEntities) new buTuftingCalc();
      buVector5.Copy(refPoint2, ref point3DList2);
      point3DList2.Add(new Point3D(x4, y4, z3));
      point3DList2.Add(new Point3D(x3, y3, z3));
      point3DList2.Add(new Point3D(x3, y3, z4));
      double num6 = buCall.\u0001.PolygonArea(point3DList2, this.ConvertPlane(((DrillCNCSettings) Args).refPlane));
      double num7 = buCall.\u0001.Length3D(point3DList1);
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList2);
      ((\u0084.\u0001) ((DrillItem) foamEntities2).GroupEntity.Outside).Entities.Add((buEntity) new buShape(point3DList2));
      ((DrillItem) foamPattern).foamEntities.Add(foamEntities1);
      ((DrillItem) foamPattern).foamEntities.Add(foamEntities2);
      List<Point3D> points = new List<Point3D>();
      if (Type == FoamType.Pyramid)
      {
        buVector5.Copy(point3DList1, ref points);
        points.Add(new Point3D(point3DList2[0].X, point3DList2[0].Y, point3DList2[0].Z));
        points.Add(new Point3D(x3, y3, z3));
        points.Add(new Point3D(x4, y4, z3));
        points.Add(new Point3D(x4, y4, z4));
        points.Add(new Point3D(x2, y2, z2));
      }
      if (Type == FoamType.Rectangle)
      {
        buVector5.Copy(point3DList1, ref points);
        points.Add(new Point3D(x3, y3, z2));
        points.Add(new Point3D(x3, y3, z3));
        points.Add(new Point3D(x4, y4, z3));
        points.Add(new Point3D(x4, y4, z4));
        points.Add(new Point3D(x2, y2, z4));
        points.Add(new Point3D(x2, y2, z2));
        points.Add(new Point3D(x2 + ((DrillCNCSettings) Args).Width / 2.0, y2, z2));
      }
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref points);
      ((DrillItem) foamPattern).sortEntities.Add((buEntity) new buShape(points));
      ((DrillItem) foamPattern).planeName = ((DrillCNCSettings) Args).refPlane;
      this.FoamEntitiesBoxSize(((DrillItem) foamPattern).foamEntities, ref ((DrillItemBase) foamPattern).BoxMinItem, ref ((DrillItemBase) foamPattern).BoxMaxItem);
      ((DrillItem) ((DrillItem) foamPattern).Info).TotalArea = Math.Round(num4 + num6, 3);
      ((DrillItem) ((DrillItem) foamPattern).Info).TotalCuttingLength = Math.Round(num5 + num7, 3);
      if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
        ((DrillItem) ((DrillItem) foamPattern).Info).BoxArea = Math.Round((((DrillItemBase) foamPattern).BoxMaxItem.X - ((DrillItemBase) foamPattern).BoxMinItem.X) * (((DrillItemBase) foamPattern).BoxMaxItem.Z - ((DrillItemBase) foamPattern).BoxMinItem.Z), 3);
      if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
        ((DrillItem) ((DrillItem) foamPattern).Info).BoxArea = Math.Round((((DrillItemBase) foamPattern).BoxMaxItem.Y - ((DrillItemBase) foamPattern).BoxMinItem.Y) * (((DrillItemBase) foamPattern).BoxMaxItem.Z - ((DrillItemBase) foamPattern).BoxMinItem.Z), 3);
      if (((DrillItem) ((DrillItem) foamPattern).Info).BoxArea > 0.0)
        ((DrillItem) ((DrillItem) foamPattern).Info).UsedPersentageFromBoxArea = Math.Round(((DrillItem) ((DrillItem) foamPattern).Info).TotalArea / ((DrillItem) ((DrillItem) foamPattern).Info).BoxArea * 100.0, 3);
      if (DrillCalcItem.UnitsSpeed == SpeedUnit.mmPerSec)
        ((DrillItem) ((DrillItem) foamPattern).Info).TimeCutting = Math.Round(((DrillItem) ((DrillItem) foamPattern).Info).TotalCuttingLength / ((DrillCNCSettings) Args).CuttingSpeed, 3);
      if (DrillCalcItem.UnitsSpeed == SpeedUnit.mmPerMin)
        ((DrillItem) ((DrillItem) foamPattern).Info).TimeCutting = Math.Round(((DrillItem) ((DrillItem) foamPattern).Info).TotalCuttingLength / ((DrillCNCSettings) Args).CuttingSpeed * 60.0, 3);
      calcPatterns.Add(foamPattern);
    }
  }

  public void WaveTypeShape(
    FoamWaveShapeArgs Args,
    FoamType Type,
    ref List<FoamPattern> calcPatterns)
  {
    calcPatterns = new List<FoamPattern>();
    Plane refPlane = Plane.XZ;
    if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
      refPlane = Plane.YZ;
    double lnRatio = 0.25 / ((DrillItem) DrillCalcItem.varFoamSettings).GCodeRegenDEviation;
    if (lnRatio < 4.0)
      lnRatio = 4.0;
    for (double num1 = 0.0; num1 <= (double) (((DrillCNCSettings) Args).RepeatCount - 1); ++num1)
    {
      FoamPattern foamPattern = (FoamPattern) new DrillJobCreateEventHandler();
      double num2 = num1 * ((DrillCNCSettings) Args).Width * (double) ((DrillCNCSettings) Args).WaveCount;
      double x1 = 0.0;
      double x2 = 0.0;
      double y1 = 0.0;
      double y2 = 0.0;
      double z1 = 0.0;
      double z2 = 0.0;
      double z3 = 0.0;
      List<Point3D> refPoint = new List<Point3D>();
      for (double num3 = 0.0; num3 <= (double) (((DrillCNCSettings) Args).WaveCount - 1); ++num3)
      {
        double x3 = 0.0;
        double x4 = 0.0;
        double x5 = 0.0;
        double x6 = 0.0;
        double x7 = 0.0;
        double x8 = 0.0;
        double x9 = 0.0;
        double y3 = 0.0;
        double y4 = 0.0;
        double y5 = 0.0;
        double y6 = 0.0;
        double y7 = 0.0;
        double y8 = 0.0;
        double y9 = 0.0;
        if (Type == FoamType.ZForm)
        {
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
          {
            x3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.25;
            x5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.75;
            x7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x1 = x3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x2 = x7;
          }
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
          {
            y3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.25;
            y5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.75;
            y7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y1 = y3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y2 = y7;
          }
          double z4 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z5 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z6 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z7 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z8 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z3 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z2 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          z1 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          refPoint.Add(new Point3D(x3, y3, z4));
          refPoint.Add(new Point3D(x4, y4, z5));
          refPoint.Add(new Point3D(x5, y5, z6));
          refPoint.Add(new Point3D(x6, y6, z7));
          refPoint.Add(new Point3D(x7, y7, z8));
        }
        if (Type == FoamType.VForm)
        {
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
          {
            x3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x1 = x3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x2 = x5;
          }
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
          {
            y3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y1 = y3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y2 = y5;
          }
          double z9 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z10 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z11 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z3 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z2 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          z1 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          refPoint.Add(new Point3D(x3, y3, z9));
          refPoint.Add(new Point3D(x4, y4, z10));
          refPoint.Add(new Point3D(x5, y5, z11));
        }
        if (Type == FoamType.SForm)
        {
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
          {
            x3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.25;
            x5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.75;
            x7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x1 = x3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x2 = x7;
          }
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
          {
            y3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.25;
            y5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.75;
            y7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y1 = y3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y2 = y7;
          }
          double z12 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z13 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z14 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z15 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z16 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z3 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z2 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          z1 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          List<Point3D> Vertices = new List<Point3D>();
          buCall.\u0001.Arc3Point(new Point3D(x3, y3, z12), new Point3D(x4, y4, z13), new Point3D(x5, y5, z14), this.ConvertPlane(((DrillCNCSettings) Args).refPlane), new EntityResolution(0.5, 10, lnRatio, EntityResolutionType.ByLnRadius, 25), ref Vertices);
          Vertices.Reverse();
          refPoint.AddRange((IEnumerable<Point3D>) Vertices);
          Vertices = new List<Point3D>();
          buCall.\u0001.Arc3Point(new Point3D(x5, y5, z14), new Point3D(x6, y6, z15), new Point3D(x7, y7, z16), this.ConvertPlane(((DrillCNCSettings) Args).refPlane), new EntityResolution(0.5, 10, lnRatio, EntityResolutionType.ByLnRadius, 25), ref Vertices);
          refPoint.AddRange((IEnumerable<Point3D>) Vertices);
        }
        if (Type == FoamType.CForm)
        {
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
          {
            x3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x1 = x3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x2 = x5;
          }
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
          {
            y3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y1 = y3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y2 = y5;
          }
          double z17 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z18 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z19 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z3 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z2 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          z1 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          List<Point3D> Vertices = new List<Point3D>();
          buCall.\u0001.Arc3Point(new Point3D(x3, y3, z17), new Point3D(x4, y4, z18), new Point3D(x5, y5, z19), this.ConvertPlane(((DrillCNCSettings) Args).refPlane), new EntityResolution(0.5, 10, lnRatio, EntityResolutionType.ByLnRadius, 25), ref Vertices);
          Vertices.Reverse();
          refPoint.AddRange((IEnumerable<Point3D>) Vertices);
        }
        if (Type == FoamType.Rectangle)
        {
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
          {
            x3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x8 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            x9 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x1 = x3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x2 = x9;
          }
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
          {
            y3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y8 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            y9 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y1 = y3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y2 = y9;
          }
          double z20 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z21 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z22 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z23 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z24 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z25 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z26 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z3 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z2 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          z1 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          refPoint.Add(new Point3D(x3, y3, z20));
          refPoint.Add(new Point3D(x4, y4, z21));
          refPoint.Add(new Point3D(x5, y5, z22));
          refPoint.Add(new Point3D(x6, y6, z23));
          refPoint.Add(new Point3D(x7, y7, z24));
          refPoint.Add(new Point3D(x8, y8, z25));
          refPoint.Add(new Point3D(x9, y9, z26));
        }
        if (Type == FoamType.UForm)
        {
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
          {
            x3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            x5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            x8 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            x9 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              x1 = x3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              x2 = x9;
          }
          if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
          {
            y3 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y4 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.0;
            y5 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y6 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y7 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 0.5;
            y8 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            y9 = ((DrillCNCSettings) Args).StartWidthOffset + num2 + num3 * ((DrillCNCSettings) Args).Width + ((DrillCNCSettings) Args).Width * 1.0;
            if (num3 == 0.0)
              y1 = y3;
            if (num3 == (double) (((DrillCNCSettings) Args).WaveCount - 1))
              y2 = y9;
          }
          double z27 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z28 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z29 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z30 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          double z31 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z32 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).Height + ((DrillCNCSettings) Args).ZOffset;
          double z33 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z3 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).ZOffset;
          z2 = ((DrillCNCSettings) Args).ZPos + ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          z1 = ((DrillCNCSettings) Args).ZPos - ((DrillCNCSettings) Args).BaseHeight + ((DrillCNCSettings) Args).ZOffset;
          refPoint.Add(new Point3D(x3, y3, z27));
          refPoint.Add(new Point3D(x4, y4, z28));
          refPoint.Add(new Point3D(x5, y5, z29));
          refPoint.Add(new Point3D(x6, y6, z30));
          refPoint.Add(new Point3D(x7, y7, z31));
          refPoint.Add(new Point3D(x8, y8, z32));
          refPoint.Add(new Point3D(x9, y9, z33));
        }
      }
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref refPoint);
      if (((DrillCNCSettings) Args).RoundRadius > 0.0)
      {
        List<Point3D> copiedPoint = new List<Point3D>();
        buVector5.Copy(refPoint, ref copiedPoint);
        refPoint.Clear();
        refPoint = new List<Point3D>();
        buCall.\u0001.FilletPointList(copiedPoint, ((DrillCNCSettings) Args).RoundRadius, refPlane, ref refPoint);
      }
      else if (((DrillCNCSettings) Args).ChamferLen > 0.0)
      {
        List<Point3D> copiedPoint = new List<Point3D>();
        buVector5.Copy(refPoint, ref copiedPoint);
        refPoint.Clear();
        refPoint = new List<Point3D>();
        buCall.\u0001.ChamferPointList(copiedPoint, ((DrillCNCSettings) Args).ChamferLen, refPlane, ref refPoint);
      }
      List<Point3D> point3DList1 = new List<Point3D>();
      FoamEntities foamEntities1 = (FoamEntities) new buTuftingCalc();
      buVector5.Copy(refPoint, ref point3DList1);
      point3DList1.Add(new Point3D(x2, y2, z2));
      point3DList1.Add(new Point3D(x1, y1, z2));
      point3DList1.Add(new Point3D(x1, y1, z3));
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList1);
      double num4 = buCall.\u0001.PolygonArea(point3DList1, this.ConvertPlane(((DrillCNCSettings) Args).refPlane));
      double num5 = buCall.\u0001.Length3D(point3DList1);
      ((\u0084.\u0001) ((DrillItem) foamEntities1).GroupEntity.Outside).Entities.Add((buEntity) new buShape(point3DList1));
      List<Point3D> point3DList2 = new List<Point3D>();
      FoamEntities foamEntities2 = (FoamEntities) new buTuftingCalc();
      buVector5.Copy(refPoint, ref point3DList2);
      point3DList2.Add(new Point3D(x2, y2, z1));
      point3DList2.Add(new Point3D(x1, y1, z1));
      point3DList2.Add(new Point3D(x1, y1, z3));
      double num6 = buCall.\u0001.PolygonArea(point3DList2, this.ConvertPlane(((DrillCNCSettings) Args).refPlane));
      double num7 = buCall.\u0001.Length3D(point3DList1);
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList2);
      ((\u0084.\u0001) ((DrillItem) foamEntities2).GroupEntity.Outside).Entities.Add((buEntity) new buShape(point3DList2));
      ((DrillItem) foamPattern).foamEntities.Add(foamEntities1);
      ((DrillItem) foamPattern).foamEntities.Add(foamEntities2);
      List<Point3D> points = new List<Point3D>();
      buVector5.Copy(refPoint, ref points);
      points.Add(new Point3D(x2, y2, z2));
      points.Add(new Point3D(x1, y1, z2));
      points.Add(new Point3D(x1, y1, z3));
      points.Add(new Point3D(x1, y1, z1));
      points.Add(new Point3D(x2, y2, z1));
      points.Add(new Point3D(x2, y2, z3));
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref points);
      ((DrillItem) foamPattern).sortEntities.Add((buEntity) new buShape(points));
      ((DrillItem) foamPattern).planeName = ((DrillCNCSettings) Args).refPlane;
      this.FoamEntitiesBoxSize(((DrillItem) foamPattern).foamEntities, ref ((DrillItemBase) foamPattern).BoxMinItem, ref ((DrillItemBase) foamPattern).BoxMaxItem);
      ((DrillItem) ((DrillItem) foamPattern).Info).TotalArea = Math.Round(num4 + num6, 3);
      ((DrillItem) ((DrillItem) foamPattern).Info).TotalCuttingLength = Math.Round(num5 + num7, 3);
      if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.XZ)
        ((DrillItem) ((DrillItem) foamPattern).Info).BoxArea = Math.Round((((DrillItemBase) foamPattern).BoxMaxItem.X - ((DrillItemBase) foamPattern).BoxMinItem.X) * (((DrillItemBase) foamPattern).BoxMaxItem.Z - ((DrillItemBase) foamPattern).BoxMinItem.Z), 3);
      if (((DrillCNCSettings) Args).refPlane == FoamPlaneType.YZ)
        ((DrillItem) ((DrillItem) foamPattern).Info).BoxArea = Math.Round((((DrillItemBase) foamPattern).BoxMaxItem.Y - ((DrillItemBase) foamPattern).BoxMinItem.Y) * (((DrillItemBase) foamPattern).BoxMaxItem.Z - ((DrillItemBase) foamPattern).BoxMinItem.Z), 3);
      if (((DrillItem) ((DrillItem) foamPattern).Info).BoxArea > 0.0)
        ((DrillItem) ((DrillItem) foamPattern).Info).UsedPersentageFromBoxArea = Math.Round(((DrillItem) ((DrillItem) foamPattern).Info).TotalArea / ((DrillItem) ((DrillItem) foamPattern).Info).BoxArea * 100.0, 3);
      if (DrillCalcItem.UnitsSpeed == SpeedUnit.mmPerSec)
        ((DrillItem) ((DrillItem) foamPattern).Info).TimeCutting = Math.Round(((DrillItem) ((DrillItem) foamPattern).Info).TotalCuttingLength / ((DrillCNCSettings) Args).CuttingSpeed, 3);
      if (DrillCalcItem.UnitsSpeed == SpeedUnit.mmPerMin)
        ((DrillItem) ((DrillItem) foamPattern).Info).TimeCutting = Math.Round(((DrillItem) ((DrillItem) foamPattern).Info).TotalCuttingLength / ((DrillCNCSettings) Args).CuttingSpeed * 60.0, 3);
      calcPatterns.Add(foamPattern);
    }
  }

  public void FoamEntitiesToEntities(List<FoamEntities> FoamEntity, ref List<buEntity> refEntities)
  {
    refEntities.Clear();
    for (int index1 = 0; index1 <= FoamEntity.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((DrillItem) FoamEntity[index1]).GroupEntity.Inside.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= ((\u0084.\u0001) ((DrillItem) FoamEntity[index1]).GroupEntity.Inside[index2]).Entities.Count - 1; ++index3)
        {
          buEntity copiedEntity = (buEntity) null;
          buDiametricDim.Copy(((\u0084.\u0001) ((DrillItem) FoamEntity[index1]).GroupEntity.Inside[index2]).Entities[index3], ref copiedEntity);
          if (copiedEntity != null)
            refEntities.Add(copiedEntity);
        }
      }
      for (int index4 = 0; index4 <= ((\u0084.\u0001) ((DrillItem) FoamEntity[index1]).GroupEntity.Outside).Entities.Count - 1; ++index4)
      {
        buEntity copiedEntity = (buEntity) null;
        buDiametricDim.Copy(((\u0084.\u0001) ((DrillItem) FoamEntity[index1]).GroupEntity.Outside).Entities[index4], ref copiedEntity);
        if (copiedEntity != null)
          refEntities.Add(copiedEntity);
      }
    }
  }

  public void FoamEntitiesMove(
    double dX,
    double dY,
    double dZ,
    ref List<FoamEntities> refEntities)
  {
    for (int index1 = 0; index1 <= refEntities.Count - 1; ++index1)
    {
      FoamEntities foamEntities = refEntities[index1];
      for (int index2 = 0; index2 <= ((DrillItem) foamEntities).GroupEntity.Inside.Count - 1; ++index2)
        buCall.\u0001.Move(dX, dY, dZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Inside[index2]).Entities);
      buCall.\u0001.Move(dX, dY, dZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Outside).Entities);
    }
  }

  public void FoamEntitiesBoxSize(
    List<FoamEntities> refEntities,
    ref Point3D minPoint,
    ref Point3D maxPoint)
  {
    List<buEntity> refEntities1 = new List<buEntity>();
    this.FoamEntitiesToEntities(refEntities, ref refEntities1);
    buCall.\u0001.BoxSizeCalculate(refEntities1, ref minPoint, ref maxPoint);
  }

  public void FoamEntitiesRotate(double Degree, Vector3D Axis, ref List<FoamEntities> refEntities)
  {
    for (int index1 = 0; index1 <= refEntities.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((\u0084.\u0001) ((DrillItem) refEntities[index1]).GroupEntity.Outside).Entities.Count - 1; ++index2)
        ((buLinearDim) ((\u0084.\u0001) ((DrillItem) refEntities[index1]).GroupEntity.Outside).Entities[index2]).Rotate(Degree, Axis);
      for (int index3 = 0; index3 <= ((DrillItem) refEntities[index1]).GroupEntity.Inside.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= ((\u0084.\u0001) ((DrillItem) refEntities[index1]).GroupEntity.Inside[index3]).Entities.Count - 1; ++index4)
          ((buLinearDim) ((\u0084.\u0001) ((DrillItem) refEntities[index1]).GroupEntity.Inside[index3]).Entities[index4]).Rotate(Degree, Axis);
      }
    }
  }

  public void FoamEntitiesMirror(
    bool MirrorHor,
    bool MirrorVer,
    FoamPlaneType refPlane,
    ref List<FoamEntities> refEntities)
  {
    Point3D minPoint1 = new Point3D();
    Point3D maxPoint1 = new Point3D();
    this.FoamEntitiesBoxSize(refEntities, ref minPoint1, ref maxPoint1);
    for (int index1 = 0; index1 <= refEntities.Count - 1; ++index1)
    {
      FoamEntities foamEntities = refEntities[index1];
      if (refPlane == FoamPlaneType.XZ)
      {
        if (MirrorHor)
        {
          if (((DrillItem) foamEntities).GroupEntity.Outside != null)
            buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.XZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Outside).Entities);
          if (((DrillItem) foamEntities).GroupEntity.Inside != null)
          {
            for (int index2 = 0; index2 <= ((DrillItem) foamEntities).GroupEntity.Inside.Count - 1; ++index2)
              buCall.\u0001.Mirror(new Point3D(), new Point3D(10.0, 0.0, 0.0), Plane.XZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Inside[index2]).Entities);
          }
          if (((DrillItem) foamEntities).GroupEntity.OpenEntities != null)
          {
            for (int index3 = 0; index3 <= ((DrillItem) foamEntities).GroupEntity.OpenEntities.Count - 1; ++index3)
              buCall.\u0001.Mirror(new Point3D(), new Point3D(10.0, 0.0, 0.0), Plane.XZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.OpenEntities[index3]).Entities);
          }
        }
        if (MirrorVer)
        {
          if (((DrillItem) foamEntities).GroupEntity.Outside != null)
            buCall.\u0001.Mirror(new Point3D(), new Point3D(10.0, 0.0, 0.0), Plane.XZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Outside).Entities);
          if (((DrillItem) foamEntities).GroupEntity.Inside != null)
          {
            for (int index4 = 0; index4 <= ((DrillItem) foamEntities).GroupEntity.Inside.Count - 1; ++index4)
              buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.XZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Inside[index4]).Entities);
          }
          if (((DrillItem) foamEntities).GroupEntity.OpenEntities != null)
          {
            for (int index5 = 0; index5 <= ((DrillItem) foamEntities).GroupEntity.OpenEntities.Count - 1; ++index5)
              buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.XZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.OpenEntities[index5]).Entities);
          }
        }
      }
      if (refPlane == FoamPlaneType.YZ)
      {
        if (MirrorHor)
        {
          if (((DrillItem) foamEntities).GroupEntity.Outside != null)
            buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 10.0, 0.0), Plane.YZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Outside).Entities);
          if (((DrillItem) foamEntities).GroupEntity.Inside != null)
          {
            for (int index6 = 0; index6 <= ((DrillItem) foamEntities).GroupEntity.Inside.Count - 1; ++index6)
              buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 10.0, 0.0), Plane.YZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Inside[index6]).Entities);
          }
          if (((DrillItem) foamEntities).GroupEntity.OpenEntities != null)
          {
            for (int index7 = 0; index7 <= ((DrillItem) foamEntities).GroupEntity.OpenEntities.Count - 1; ++index7)
              buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 10.0, 0.0), Plane.YZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.OpenEntities[index7]).Entities);
          }
        }
        if (MirrorVer)
        {
          if (((DrillItem) foamEntities).GroupEntity.Outside != null)
            buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Outside).Entities);
          if (((DrillItem) foamEntities).GroupEntity.Inside != null)
          {
            for (int index8 = 0; index8 <= ((DrillItem) foamEntities).GroupEntity.Inside.Count - 1; ++index8)
              buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Inside[index8]).Entities);
          }
          if (((DrillItem) foamEntities).GroupEntity.OpenEntities != null)
          {
            for (int index9 = 0; index9 <= ((DrillItem) foamEntities).GroupEntity.OpenEntities.Count - 1; ++index9)
              buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.OpenEntities[index9]).Entities);
          }
        }
      }
    }
    Point3D minPoint2 = new Point3D();
    Point3D maxPoint2 = new Point3D();
    this.FoamEntitiesBoxSize(refEntities, ref minPoint2, ref maxPoint2);
    this.FoamEntitiesMove(-minPoint2.X, -minPoint2.Y, -minPoint2.Z, ref refEntities);
  }

  public void EntitiesMirror(
    bool MirrorHor,
    bool MirrorVer,
    FoamPlaneType refPlane,
    ref List<buEntity> refEntities)
  {
    if (refPlane == FoamPlaneType.XZ)
    {
      if (MirrorHor)
      {
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
        double x = MinPoint.X;
        buCall.\u0001.Mirror(new Point3D(0.0, 0.0, 0.0), new Point3D(0.0, 0.0, 10.0), Plane.XZ, ref refEntities);
        buCall.\u0001.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
        buCall.\u0001.Move(-MinPoint.X + x, -MinPoint.Y, -MinPoint.Z, ref refEntities);
      }
      if (MirrorVer)
      {
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
        double x = MinPoint.X;
        buCall.\u0001.Mirror(new Point3D(), new Point3D(10.0, 0.0, 0.0), Plane.XZ, ref refEntities);
        buCall.\u0001.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
        buCall.\u0001.Move(-MinPoint.X + x, -MinPoint.Y, -MinPoint.Z, ref refEntities);
      }
    }
    if (refPlane != FoamPlaneType.YZ)
      return;
    if (MirrorHor)
    {
      buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 10.0, 0.0), Plane.YZ, ref refEntities);
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      buCall.\u0001.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
      buCall.\u0001.Move(-MinPoint.X, -MinPoint.Y, -MinPoint.Z, ref refEntities);
    }
    if (!MirrorVer)
      return;
    buCall.\u0001.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref refEntities);
    Point3D MinPoint1 = new Point3D();
    Point3D MaxPoint1 = new Point3D();
    buCall.\u0001.BoxSizeCalculate(refEntities, ref MinPoint1, ref MaxPoint1);
    buCall.\u0001.Move(-MinPoint1.X, -MinPoint1.Y, -MinPoint1.Z, ref refEntities);
  }

  public void PatternInfo(
    List<FoamPattern> Patterns,
    SizeObject SizeFoam,
    FoamSettings Settings,
    FoamRuntimeSettings RunSettings,
    ref string Info)
  {
    Info = "";
    if (Patterns.Count <= 0)
      return;
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    double num4 = 0.0;
    double num5 = ((DrillItem) Patterns[0]).planeName != FoamPlaneType.XZ ? SizeFoam.Height * SizeFoam.Depth : SizeFoam.Width * SizeFoam.Depth;
    double num6 = ((DrillMoveOptions) RunSettings).BlockWidth * ((DrillCNCSettings) RunSettings).BlockHeight;
    for (int index = 0; index <= Patterns.Count - 1; ++index)
    {
      num1 += ((DrillItem) ((DrillItem) Patterns[index]).Info).TotalCuttingLength;
      num2 += ((DrillItem) ((DrillItem) Patterns[index]).Info).TimeCutting;
      num4 += ((DrillItem) ((DrillItem) Patterns[index]).Info).TotalArea;
      num3 += ((DrillItem) ((DrillItem) Patterns[index]).Info).UsedPersentageFromBoxArea;
    }
    double num7 = num3 / (double) Patterns.Count;
    Info = $"{Info}{buLangTranslate.preDef.Pattern} {buLangTranslate.preDef.Information}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} : {num1.ToString("f3")} {DrillCalcItem.UnitLength.ToString()}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Time} : {num2.ToString("f3")} {buLangTranslate.preDef.Second}   -  {buLangTranslate.preDef.Pattern} %{num7.ToString("f3")} {buLangTranslate.preDef.Efficiency}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Block} {buLangTranslate.preDef.Information}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Block} %{(num4 / num6 * 100.0).ToString("f3")} {buLangTranslate.preDef.Efficiency}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Foam} {buLangTranslate.preDef.Information}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Block} %{(num4 / num5 * 100.0).ToString("f3")} {buLangTranslate.preDef.Efficiency}{Environment.NewLine}";
  }

  public void PatternInfo(
    FoamPattern Patterns,
    SizeObject SizeFoam,
    double HorCount,
    double VerCount,
    FoamSettings Settings,
    FoamRuntimeSettings RunSettings,
    ref string Info)
  {
    Info = "";
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    double num4 = 0.0;
    double num5 = ((DrillItem) Patterns).planeName != FoamPlaneType.XZ ? SizeFoam.Height * SizeFoam.Depth : SizeFoam.Width * SizeFoam.Depth;
    double num6 = ((DrillCNCSettings) RunSettings).BlockIdealWidth * ((DrillCNCSettings) RunSettings).BlockIdealHeight;
    double num7 = num1 + ((DrillItem) ((DrillItem) Patterns).Info).TotalCuttingLength * HorCount * VerCount;
    double num8 = num2 + ((DrillItem) ((DrillItem) Patterns).Info).TimeCutting * HorCount * VerCount;
    double num9 = num4 + ((DrillItem) ((DrillItem) Patterns).Info).TotalArea * HorCount * VerCount;
    double num10 = num3 + ((DrillItem) ((DrillItem) Patterns).Info).UsedPersentageFromBoxArea;
    Info = $"{Info}{buLangTranslate.preDef.Pattern} {buLangTranslate.preDef.Information}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} : {num7.ToString("f3")} {DrillCalcItem.UnitLength.ToString()}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Time} : {num8.ToString("f3")} {buLangTranslate.preDef.Second}   -  {buLangTranslate.preDef.Pattern} %{num10.ToString("f3")} {buLangTranslate.preDef.Efficiency}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Block} {buLangTranslate.preDef.Information}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Block} %{(num9 / num6 * 100.0).ToString("f3")} {buLangTranslate.preDef.Efficiency}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Foam} {buLangTranslate.preDef.Information}{Environment.NewLine}";
    Info = $"{Info}{buLangTranslate.preDef.Block} %{(num9 / num5 * 100.0).ToString("f3")} {buLangTranslate.preDef.Efficiency}{Environment.NewLine}";
  }

  public void BlocksInfo(List<FoamBlock> Blocks)
  {
  }

  public Plane ConvertPlane(FoamPlaneType refPlane)
  {
    return refPlane != FoamPlaneType.XZ ? Plane.YZ : Plane.XZ;
  }
}
