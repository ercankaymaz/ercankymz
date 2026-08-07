// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleSweepPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSweepPars : buSerilization5
{
  public ColorType colorItemProfileCurve;
  public ColorType colorItemLatheHorizontal;
  public ColorType colorItemLatheVertical;
  public ColorType colorItemColumn;
  public ColorType colorItemSweep;
  public ColorType colorItemHole;
  public ColorType colorItemText;
  public ColorType colorItemSlicesHorizontal;
  public ColorType colorItemSlicesVertical;
  public ColorType colorItemSingleCut;

  public void SawExistingToolPointCamCenterCalc(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    MarbleSawCalcParameters Setting,
    List<Pnt6DList> PLL3D,
    bool UseKinematic,
    KinematicBase5 activeKinematic)
  {
    try
    {
      int num = 0;
      bool flag = false;
      Pnt6D pnt6D1 = new Pnt6D();
      Pnt6D calcPoint = new Pnt6D();
      for (int index1 = 0; index1 <= PLL3D.Count - 1; ++index1)
      {
        camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
        MarbleSawCalcParameters sawCalcParameters = (((ToolGeometry5) PLL3D[index1]).Settings == null ? 0 : (((ToolGeometry5) PLL3D[index1]).Settings is MarbleSawCalcParameters ? 1 : 0)) == 0 ? (MarbleSawCalcParameters) new \u0007.\u0001(Setting) : (MarbleSawCalcParameters) new \u0007.\u0001((MarbleSawCalcParameters) ((ToolGeometry5) PLL3D[index1]).Settings);
        List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
        List<Pnt6D> pnt6DList2 = new List<Pnt6D>();
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).DevideLength <= 0.0)
          buVector5.Copy(((ToolGeometry5) PLL3D[index1]).Points, ref pnt6DList2, 4);
        pnt6DList1.Clear();
        ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref pnt6DList2);
        Pnt6D pnt6D2 = new Pnt6D(pnt6DList2[0].X, pnt6DList2[0].Y, pnt6DList2[0].Z, pnt6DList2[0].A, 0.0, pnt6DList2[0].C);
        ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D2, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
        TpPnt9D tpPnt9D1 = !UseKinematic ? new TpPnt9D(pnt6D2, ((buMarbleForms) sawCalcParameters).PlungeSpeed, 1) : new TpPnt9D(calcPoint, ((buMarbleForms) sawCalcParameters).PlungeSpeed, 1);
        tpPnt9D1.AfterCodes.Add((object) "G38 O1");
        tpPnt9D1.AfterCodes.Add((object) "G51 D1");
        camTpPoint.Points.Add(tpPnt9D1);
        List<Point3D> point3DList = new List<Point3D>();
        point3DList.Add(new Point3D(((TpArcData) tpPnt9D1).P9.X, ((TpArcData) tpPnt9D1).P9.Y, ((TpArcData) tpPnt9D1).P9.Z));
        for (int index2 = 1; index2 <= pnt6DList2.Count - 1; ++index2)
        {
          double feed = ((buMarbleForms) sawCalcParameters).ForwardCutSpeed;
          if (flag)
            feed = ((buMarbleForms) sawCalcParameters).BackwardCutSpeed;
          Pnt6D pnt6D3 = new Pnt6D(pnt6DList2[index2].X, pnt6DList2[index2].Y, pnt6DList2[index2].Z, pnt6DList2[index2].A, 0.0, pnt6DList2[index2].C);
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D3, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
          TpPnt9D tpPnt9D2 = !UseKinematic ? new TpPnt9D(pnt6D3, ((buMarbleForms) sawCalcParameters).PlungeSpeed, 1) : new TpPnt9D(calcPoint, feed, 1);
          if (index2 == pnt6DList2.Count - 1)
          {
            tpPnt9D2.PreCodes.Add((object) "G39 O1");
            tpPnt9D2.PreCodes.Add((object) "G50");
          }
          camTpPoint.Points.Add(tpPnt9D2);
          point3DList.Add(new Point3D(((TpArcData) tpPnt9D2).P9.X, ((TpArcData) tpPnt9D2).P9.Y, ((TpArcData) tpPnt9D2).P9.Z));
        }
        ((MarbleMachineOptionsSettings) marbleCam).CamBase.CamPoints.Add(camTpPoint);
        ++num;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void SawMillingVerticalRough(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<List<Point3D>> PLL3D,
    KinematicBase5 activeKinematic)
  {
    int num1 = 0;
    Pnt6D pnt6D1 = new Pnt6D();
    Pnt6D calcPoint = new Pnt6D();
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    Entity rectangle = (Entity) CompositeCurve.CreateRectangle(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).Width, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).Height);
    rectangle.Translate(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint.X, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint.Y);
    rectangle.Regen(0.1);
    double num2 = 132.0;
    for (int index1 = 0; index1 <= PLL3D.Count - 1; ++index1)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      if (PLL3D[index1].Count > 3)
      {
        buCall.\u0001.BoxSizeCalculate(PLL3D[index1], ref MinPoint, ref MaxPoint);
        double num3 = (buCall.\u0001.Length3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint, Plane.XY) - (buCall.\u0001.Length3D(MinPoint, MaxPoint, Plane.XY) - ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter * 2.0)) / 2.0;
        int int32 = Convert.ToInt32(buFile5.RoundToUpper(num3 / ((MarbleOperationSelectionCommand) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerCutStep));
        double num4 = num3 / Convert.ToDouble(int32);
        if (int32 <= 0)
          ;
        int num5 = 1;
        for (int index2 = 1; index2 >= 1; --index2)
        {
          List<buEntity> buEntityList = new List<buEntity>();
          List<Point3D> point3DList1 = new List<Point3D>();
          List<Pnt6D> pnt6DList = new List<Pnt6D>();
          camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
          Point3D EndPnt1 = (Point3D) null;
          List<Point3D> point3DList2 = new List<Point3D>();
          List<Point3D> copiedPoint = new List<Point3D>();
          if (num5 > 1)
          {
            buVector5.Copy(PLL3D[index1], ref point3DList2);
            ICurve[] curveArray = new LinearPath((ICollection<Point3D>) point3DList2).QuickOffset(((MarbleOperationSelectionCommand) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerCutStep * (double) index2, Plane.XY, cornerType.Round);
            if (curveArray.Length != 0)
            {
              ((Entity) curveArray[0]).Regen(0.1);
              if (((Entity) curveArray[0]).Vertices.Length > 3)
              {
                ((Entity) curveArray[0]).Translate(0.0, 0.0, -((Entity) curveArray[0]).Vertices[0].Z);
                point3DList2 = new List<Point3D>();
                buVector5.Copy(((Entity) curveArray[0]).Vertices, ref point3DList2);
                buCall.\u0001.Move(0.0, 0.0, PLL3D[index1][0].Z, ref point3DList2);
              }
            }
          }
          else
            buVector5.Copy(PLL3D[index1], ref point3DList2);
          Point3D RefPoints = new Point3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint.X, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint.Y - ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter / 2.0, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint.Z);
          int num6 = 1;
          while (num6 <= point3DList2.Count - 1)
            ++num6;
          buCall.\u0001.ShiftPointsByLength(RefPoints, ref point3DList2, true);
          ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList2);
          if (((MarbleCommandsEntity) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerSplineEnable)
          {
            buVector5.Copy(point3DList2, ref copiedPoint);
            point3DList2.Clear();
            point3DList2 = new List<Point3D>();
            buCall.\u0001.BSplineCubicUniform(copiedPoint, ((MarbleMachineType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerSplineDt, false, ref point3DList2);
            ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList2);
          }
          ClockDirectionType clockDirectionType = buCall.\u0001.GetClockDirection(point3DList2);
          bool flag;
          if (num1 % 2 == 0)
          {
            if (clockDirectionType == ClockDirectionType.CW)
            {
              clockDirectionType = ClockDirectionType.CCW;
              point3DList2.Reverse();
            }
            flag = false;
          }
          else
          {
            if (clockDirectionType == ClockDirectionType.CCW)
            {
              clockDirectionType = ClockDirectionType.CW;
              point3DList2.Reverse();
            }
            flag = true;
          }
          double num7 = buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[1]), F_NotchEdit.ToPoint3D(point3DList2[0]));
          if (flag)
            num7 -= 180.0;
          Point3D EndPnt2 = (Point3D) null;
          if (index1 > 0 && Math.Abs(pnt6D1.C - num7) > 180.0)
          {
            if (num7 > pnt6D1.C)
              num7 -= 360.0;
            else
              num7 += 360.0;
          }
          buCall.\u0001.Length3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint, point3DList2[0], Plane.XY);
          buCall.\u0001.Length3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint, Plane.XY);
          double num8 = 350.0;
          if (num8 <= 0.0)
            num8 = 10.0;
          if (clockDirectionType == ClockDirectionType.CW)
          {
            EndPnt2 = new Point3D();
            buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[0]), ((MarbleOperationSelectionCommand) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerApproach + num8, num7 - 90.0, ref EndPnt2);
          }
          else
          {
            EndPnt2 = new Point3D();
            buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[0]), ((MarbleOperationSelectionCommand) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerApproach + num8, num7 - 90.0, ref EndPnt2);
          }
          buCall.\u0001.LineWithLengthAndAngle(new Point3D(point3DList2[0].X, point3DList2[0].Y, 0.0), 1000.0, num7 - 90.0, ref EndPnt1);
          Point3D point3D = F_NotchEdit.ToPoint3D(point3DList2[0]);
          Line C2_1 = new Line(new Point3D(point3DList2[0].X, point3DList2[0].Y, 0.0), EndPnt1);
          Point3D[] point3DArray1 = ((ICurve) rectangle).IntersectWith((ICurve) C2_1);
          if (point3DArray1.Length == 0 || buCall.\u0001.Length3D(point3D, point3DArray1[0], Plane.XY) > ((MarbleOperationSelectionCommand) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerMaxCutDepth)
            ;
          ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter = 1.0;
          if (index1 == 0)
          {
            Pnt6D pnt6D2 = new Pnt6D(EndPnt2.X, EndPnt2.Y, EndPnt2.Z);
            pnt6D2.A = 0.0;
            pnt6D2.C = 0.0;
            pnt6D2.Z = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.Z + ((MarbleMachineType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerSafeDistance;
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D2, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
            calcPoint = new Pnt6D(pnt6D2);
            calcPoint.X += Math.Cos(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            calcPoint.Y += Math.Sin(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            tpPnt9D1.EnableAxes.Z = false;
            TpPnt9D tpPnt9D2 = new TpPnt9D(calcPoint, 100.0, 0);
            camTpPoint.Points.Add(tpPnt9D2);
            Pnt6D pnt6D3 = new Pnt6D(EndPnt2.X, EndPnt2.Y, EndPnt2.Z);
            pnt6D3.A = 90.0;
            pnt6D3.C = num7;
            pnt6D3.Z = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.Z + ((MarbleMachineType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerSafeDistance;
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D3, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
            calcPoint = new Pnt6D(pnt6D3);
            calcPoint.X += Math.Cos(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            calcPoint.Y += Math.Sin(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            TpPnt9D tpPnt9D3 = new TpPnt9D(calcPoint, 100.0, 0);
            camTpPoint.Points.Add(tpPnt9D3);
          }
          if (index2 == num5)
          {
            Pnt6D pnt6D4 = new Pnt6D(EndPnt2.X, EndPnt2.Y, EndPnt2.Z);
            pnt6D4.A = 90.0;
            pnt6D4.C = num7;
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D4, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
            calcPoint = new Pnt6D(pnt6D4);
            calcPoint.X += Math.Cos(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            calcPoint.Y += Math.Sin(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            TpPnt9D tpPnt9D4 = new TpPnt9D(calcPoint, 100.0, 0);
            camTpPoint.Points.Add(tpPnt9D4);
          }
          Pnt6D pnt6D5 = new Pnt6D(point3DList2[0].X, point3DList2[0].Y, point3DList2[0].Z);
          pnt6D5.A = 90.0;
          pnt6D5.C = num7;
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D5, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
          calcPoint = new Pnt6D(pnt6D5);
          calcPoint.X += Math.Cos(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
          calcPoint.Y += Math.Sin(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
          tpPnt9D1 = new TpPnt9D(calcPoint, ((MarbleMachineType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerPlungeFeed, 1);
          tpPnt9D1.AfterCodes.Add((object) "G38 O1");
          tpPnt9D1.AfterCodes.Add((object) "G51 D1");
          camTpPoint.Points.Add(tpPnt9D1);
          double num9 = num7;
          List<Point3D> point3DList3 = new List<Point3D>();
          point3DList3.Add(new Point3D(((TpArcData) tpPnt9D1).P9.X, ((TpArcData) tpPnt9D1).P9.Y, ((TpArcData) tpPnt9D1).P9.Z));
          for (int index3 = 1; index3 <= point3DList2.Count - 1; ++index3)
          {
            F_NotchEdit.ToPoint3D(point3DList2[index3]);
            double num10 = index3 != 0 ? buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[index3]), F_NotchEdit.ToPoint3D(point3DList2[index3 - 1])) : buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[index3 + 1]), F_NotchEdit.ToPoint3D(point3DList2[index3]));
            if (flag)
              num10 -= 180.0;
            double num11 = num10 - num9;
            if (Math.Abs(num11) > 180.0)
            {
              if (num11 > 0.0)
                num10 -= 360.0;
              else
                num10 += 360.0;
            }
            if (!flag)
            {
              if (num10 >= num9)
                ;
            }
            else if (num10 > num9)
              ;
            buCall.\u0001.LineWithLengthAndAngle(new Point3D(point3DList2[index1].X, point3DList2[index1].Y, 0.0), 1000.0, num7 - 90.0, ref EndPnt1);
            Line C2_2 = new Line(new Point3D(point3DList2[index1].X, point3DList2[index1].Y, 0.0), EndPnt1);
            Point3D[] point3DArray2 = ((ICurve) rectangle).IntersectWith((ICurve) C2_2);
            if (point3DArray2.Length == 0 || buCall.\u0001.Length3D(point3D, point3DArray2[0], Plane.XY) > ((MarbleOperationSelectionCommand) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerMaxCutDepth)
              ;
            double feed = ((MarbleMachineType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerForwardCuttingFeed;
            if (flag)
              feed = ((MarbleMachineType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerBackwardCuttingFeed;
            Pnt6D pnt6D6 = new Pnt6D(point3DList2[index3].X, point3DList2[index3].Y, point3DList2[index3].Z);
            pnt6D6.A = 90.0;
            pnt6D6.C = num10;
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D6, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
            calcPoint = new Pnt6D(pnt6D6);
            calcPoint.X += Math.Cos(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            calcPoint.Y += Math.Sin(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            tpPnt9D1 = new TpPnt9D(calcPoint, feed, 1);
            camTpPoint.Points.Add(tpPnt9D1);
            point3DList3.Add(new Point3D(((TpArcData) tpPnt9D1).P9.X, ((TpArcData) tpPnt9D1).P9.Y, ((TpArcData) tpPnt9D1).P9.Z));
            num9 = num10;
          }
          double num12 = buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 1]), F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 2]));
          if (flag)
            num12 -= 180.0;
          double num13 = num12 - num9;
          if (Math.Abs(num13) > 180.0)
          {
            if (num13 > 0.0)
              num12 -= 360.0;
            else
              num12 += 360.0;
          }
          if (index2 == 1)
          {
            if (clockDirectionType == ClockDirectionType.CW)
            {
              EndPnt2 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 1]), ((MarbleOperationSelectionCommand) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerApproach + num8, num12 - 90.0, ref EndPnt2);
            }
            else
            {
              EndPnt2 = new Point3D();
              buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 1]), ((MarbleOperationSelectionCommand) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingRoughVerApproach + num8, num12 - 90.0, ref EndPnt2);
            }
            Pnt6D pnt6D7 = new Pnt6D(EndPnt2.X, EndPnt2.Y, EndPnt2.Z);
            pnt6D7.A = 90.0;
            pnt6D7.C = num12;
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D7, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
            calcPoint = new Pnt6D(pnt6D7);
            calcPoint.X += Math.Cos(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            calcPoint.Y += Math.Sin(buString5.DegreeToRadian(calcPoint.C - 90.0)) * num2;
            tpPnt9D1 = new TpPnt9D(calcPoint, 100.0, 0);
            tpPnt9D1.PreCodes.Add((object) "G39 O1");
            tpPnt9D1.PreCodes.Add((object) "G50");
            camTpPoint.Points.Add(tpPnt9D1);
          }
          pnt6D1 = new Pnt6D(calcPoint);
          buCall.\u0001.Move(0.0, 0.0, -50.0, ref camTpPoint.Points);
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) point3DList2);
          ((MarbleMachineOptionsSettings) marbleCam).CamBase.EntitiesG1.Add((Entity) linearPath);
          ((MarbleMachineOptionsSettings) marbleCam).CamBase.CamPoints.Add(camTpPoint);
        }
      }
      ++num1;
    }
  }

  public void SawMillingVerticalFinish(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<Point3DList> PointList,
    KinematicBase5 activeKinematic)
  {
    List<List<Pnt6D>> pnt6DListList1 = new List<List<Pnt6D>>();
    List<List<Point3D>> point3DListList = new List<List<Point3D>>();
    List<List<Pnt6D>> pnt6DListList2 = new List<List<Pnt6D>>();
    for (int index1 = 0; index1 <= PointList.Count - 1; ++index1)
    {
      if (index1 % 2 == 0)
        ((ToolGeometry5) PointList[index1]).Points.Reverse();
      List<Pnt6D> refPoints = new List<Pnt6D>();
      buShape buShape = new buShape(((ToolGeometry5) PointList[index1]).Points);
      List<Point3D> point3DList = new List<Point3D>();
      double num = (double) index1 * ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerAngleStep - 90.0;
      for (int index2 = 0; index2 <= ((ToolGeometry5) PointList[index1]).Points.Count - 1; ++index2)
      {
        Pnt6D pnt6D = new Pnt6D(((ToolGeometry5) PointList[index1]).Points[index2].X, ((ToolGeometry5) PointList[index1]).Points[index2].Y, ((ToolGeometry5) PointList[index1]).Points[index2].Z, 90.0, 0.0, num + 90.0);
        refPoints.Add(pnt6D);
        point3DList.Add(new Point3D(((ToolGeometry5) PointList[index1]).Points[index2].X, ((ToolGeometry5) PointList[index1]).Points[index2].Y, ((ToolGeometry5) PointList[index1]).Points[index2].Z));
      }
      List<Pnt6D> calcPoints = new List<Pnt6D>();
      ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoints, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints);
      pnt6DListList1.Add(refPoints);
      pnt6DListList2.Add(calcPoints);
      point3DListList.Add(point3DList);
    }
    ((MarbleMachineOptionsSettings) marbleCam).CamBase.Tool = (ToolBase5) new ToolGeometry5(((MarbleMachineOptionsSettings) marbleCam).ToolSelected);
    for (int index3 = 0; index3 <= pnt6DListList2.Count - 1; ++index3)
    {
      camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
      ((TpPnt9D) camTpPoint).ToolCam = (ToolBase5) new ToolGeometry5(((MarbleMachineOptionsSettings) marbleCam).ToolSelected);
      double feed1 = ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerForwardCuttingFeed;
      if (index3 == 0)
      {
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(pnt6DListList2[index3], ref MinPoint, ref MidPoint, ref MaxPoint);
        Pnt6D P1 = new Pnt6D(pnt6DListList2[index3][0].X, MinPoint.Y - ((MarbleItemCommands) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerApproach, pnt6DListList2[index3][0].Z + ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerSafeDistance, pnt6DListList2[index3][0].A, 0.0, pnt6DListList2[index3][0].C);
        Pnt6D P2 = new Pnt6D(pnt6DListList2[index3][0].X, MinPoint.Y - ((MarbleItemCommands) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerApproach, pnt6DListList2[index3][0].Z, pnt6DListList2[index3][0].A, 0.0, pnt6DListList2[index3][0].C);
        TpPnt9D tpPnt9D1 = new TpPnt9D(P1, feed1, 0);
        camTpPoint.Points.Add(tpPnt9D1);
        TpPnt9D tpPnt9D2 = new TpPnt9D(P2, feed1, 0);
        camTpPoint.Points.Add(tpPnt9D2);
      }
      if (index3 % 2 == 0)
        feed1 = ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerBackwardCuttingFeed;
      for (int index4 = 0; index4 <= pnt6DListList2[index3].Count - 1; ++index4)
      {
        double feed2 = feed1;
        if (index3 == 0 & index4 == 0)
          feed2 = ((MarbleCountertopInsideTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerPlungeFeed;
        TpPnt9D tpPnt9D = new TpPnt9D(pnt6DListList2[index3][index4], feed2, 1);
        camTpPoint.Points.Add(tpPnt9D);
      }
      if (index3 == pnt6DListList2.Count - 1)
      {
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(pnt6DListList2[index3], ref MinPoint, ref MidPoint, ref MaxPoint);
        Pnt6D P = new Pnt6D(pnt6DListList2[index3][pnt6DListList2[index3].Count - 1].X, MinPoint.Y - ((MarbleItemCommands) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerApproach, pnt6DListList2[index3][pnt6DListList2[index3].Count - 1].Z + ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerSafeDistance, pnt6DListList2[index3][pnt6DListList2[index3].Count - 1].A, 0.0, pnt6DListList2[index3][pnt6DListList2[index3].Count - 1].C);
        TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(pnt6DListList2[index3][pnt6DListList2[index3].Count - 1].X, MinPoint.Y - ((MarbleItemCommands) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerApproach, pnt6DListList2[index3][pnt6DListList2[index3].Count - 1].Z + ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerSafeDistance, pnt6DListList2[index3][pnt6DListList2[index3].Count - 1].A, 0.0, pnt6DListList2[index3][pnt6DListList2[index3].Count - 1].C), feed1, 0);
        camTpPoint.Points.Add(tpPnt9D3);
        TpPnt9D tpPnt9D4 = new TpPnt9D(P, feed1, 0);
        camTpPoint.Points.Add(tpPnt9D4);
      }
      ((MarbleMachineOptionsSettings) marbleCam).CamBase.CamPoints.Add(camTpPoint);
      LinearPath linearPath = new LinearPath((ICollection<Point3D>) point3DListList[index3]);
      ((MarbleMachineOptionsSettings) marbleCam).CamBase.EntitiesG1.Add((Entity) linearPath);
    }
  }

  public void ProfileRoughLevel(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<List<Point3D>> PLLSurf,
    List<Pnt6DS> OrjPL6,
    KinematicBase5 activeKinematic)
  {
    // ISSUE: unable to decompile the method.
  }

  public void ProfileRoughRegion(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<List<Point3D>> PLLSurf,
    List<Pnt6DS> OrjPL6,
    KinematicBase5 activeKinematic)
  {
    // ISSUE: unable to decompile the method.
  }
}
