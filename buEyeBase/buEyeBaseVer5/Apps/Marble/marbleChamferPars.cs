// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleChamferPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleChamferPars : buSerilization5
{
  public ColorType colorItemMaterialClean;
  public ColorType colorItemAirDry;
  public ColorType colorAngleText;
  public ColorType colorSequenceText;
  public ColorType colorMaterial;

  public void ProfileFinish(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<List<Point3D>> PLLSurf,
    KinematicBase5 activeKinematic)
  {
    if (PLLSurf.Count <= 0)
      return;
    camTp CamSawRough = new camTp();
    List<Point3D> copiedPoint = new List<Point3D>();
    List<double> doubleList1 = new List<double>();
    List<double> doubleList2 = new List<double>();
    double Angle = 0.0;
    int index1 = 0;
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    if (((MarbleSawCalcParameters) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).TwistEnable)
    {
      index1 = 0;
      Angle = doubleList2[0];
      buCall.\u0001.BoxSizeCalculate(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
    }
    for (int index2 = 0; index2 <= PLLSurf.Count - 1; ++index2)
    {
      List<Point3D> Points1 = PLLSurf[index2];
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Points1);
      copiedPoint.Clear();
      buVector5.Copy(Points1, ref copiedPoint);
      if (copiedPoint.Count > 0)
      {
        doubleList1.Clear();
        for (int index3 = 0; index3 <= Points1.Count - 1; ++index3)
        {
          double num1 = index3 != 0 ? buCall.\u0001.PointAngle(Points1[index3], Points1[index3 - 1], Plane.XZ) : buCall.\u0001.PointAngle(Points1[index3 + 1], Points1[index3], Plane.XZ);
          if (num1 > 180.0)
          {
            double num2 = 360.0 - num1;
            if (num2 >= 0.0 & num2 <= 90.0)
              doubleList1.Add(Math.Round(num2, 5));
            else
              doubleList1.Add(0.0);
          }
          else
            doubleList1.Add(0.0);
        }
        ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingMarbleCam).OffsetAngleC = 0.0;
        bool isReverse = false;
        List<List<Pnt6D>> arrPL6 = new List<List<Pnt6D>>();
        List<List<Point3D>> arrPLCam = new List<List<Point3D>>();
        List<List<Pnt6D>> arrCalcPL6 = new List<List<Pnt6D>>();
        if (((EntityCommandArgs) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishReverseCAngle)
          ;
        double upper = buFile5.RoundToUpper(((buLogMarbleVer5) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).Length / ((CounterTopFormImageIndex) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishStep);
        List<double> Values = new List<double>();
        buFile5.DevideMinMaxValueByNumber(copiedPoint[0].X - ((CounterTopFormImageIndex) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishLeadIn, copiedPoint[0].X + ((buLogMarbleVer5) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).Length + ((CounterTopFormImageIndex) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishLeadOut, (int) upper, ref Values);
        for (int index4 = 0; index4 <= Values.Count - 1; ++index4)
        {
          if (!((MarbleSawCalcParameters) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).TwistEnable)
          {
            List<Pnt6D> refPoints = new List<Pnt6D>();
            List<Point3D> point3DList = new List<Point3D>();
            for (int index5 = 0; index5 <= copiedPoint.Count - 1; ++index5)
            {
              double a = 0.0;
              if (((EntityCommandArgs) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).Finish5Axis && index5 <= doubleList1.Count - 1)
              {
                a = doubleList1[index5];
                if (index5 > 0 && Math.Abs(doubleList1[index5] - doubleList1[index5 - 1]) > 8.0)
                {
                  Pnt6D Pnt = new Pnt6D(refPoints[refPoints.Count - 1]);
                  if (Pnt.A <= 0.1)
                  {
                    Pnt6D pnt6D = new Pnt6D(Pnt);
                    pnt6D.Z += 10.0;
                    refPoints.Add(pnt6D);
                  }
                  else
                  {
                    double Degree = 360.0 - doubleList1[index5 - 1] + 90.0;
                    Pnt6D pnt6D = new Pnt6D(Pnt);
                    double num3 = 10.0 * Math.Cos(buString5.DegreeToRadian(Degree));
                    double num4 = 10.0 * Math.Sin(buString5.DegreeToRadian(Degree));
                    double num5 = Math.Cos(buString5.DegreeToRadian(pnt6D.C - 90.0));
                    double num6 = Math.Cos(buString5.DegreeToRadian(pnt6D.C - 90.0));
                    pnt6D.X += num3 * num5;
                    pnt6D.Y = pnt6D.X + num3 * num6;
                    pnt6D.Z += num4;
                    refPoints.Add(pnt6D);
                  }
                  Pnt.A = doubleList1[index5];
                  refPoints.Add(Pnt);
                }
              }
              Pnt6D pnt6D1 = new Pnt6D(Values[index4], copiedPoint[index5].Y, copiedPoint[index5].Z, a, 0.0, 0.0);
              Point3D point3D = new Point3D(Values[index4], copiedPoint[index5].Y, copiedPoint[index5].Z);
              refPoints.Add(pnt6D1);
              point3DList.Add(point3D);
            }
            if (refPoints.Count > 0)
            {
              arrPL6.Add(refPoints);
              List<Pnt6D> calcPoints = new List<Pnt6D>();
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoints, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints);
              arrCalcPL6.Add(calcPoints);
              arrPLCam.Add(point3DList);
            }
          }
          else
          {
            List<Pnt6D> refPoints = new List<Pnt6D>();
            List<Point3D> point3DList = new List<Point3D>();
            for (int index6 = 0; index6 <= copiedPoint.Count - 1; ++index6)
            {
              double a = 0.0;
              if (((EntityCommandArgs) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).Finish5Axis && index6 <= doubleList1.Count - 1)
              {
                a = doubleList1[index6];
                if (index6 > 0 && Math.Abs(doubleList1[index6] - doubleList1[index6 - 1]) > 8.0)
                {
                  Pnt6D Pnt = new Pnt6D(refPoints[refPoints.Count - 1]);
                  if (Pnt.A <= 0.1)
                  {
                    Pnt6D pnt6D = new Pnt6D(Pnt);
                    pnt6D.Z += 10.0;
                    refPoints.Add(pnt6D);
                  }
                  else
                  {
                    double Degree = 360.0 - doubleList1[index6 - 1] + 90.0;
                    Pnt6D pnt6D = new Pnt6D(Pnt);
                    double num7 = 10.0 * Math.Cos(buString5.DegreeToRadian(Degree));
                    double num8 = 10.0 * Math.Sin(buString5.DegreeToRadian(Degree));
                    double num9 = Math.Cos(buString5.DegreeToRadian(pnt6D.C - 90.0));
                    double num10 = Math.Cos(buString5.DegreeToRadian(pnt6D.C - 90.0));
                    pnt6D.X += num7 * num9;
                    pnt6D.Y = pnt6D.X + num7 * num10;
                    pnt6D.Z += num8;
                    refPoints.Add(pnt6D);
                  }
                  Pnt.A = doubleList1[index6];
                  refPoints.Add(Pnt);
                }
              }
              Pnt6D Points2 = new Pnt6D(Values[index4], copiedPoint[index6].Y, copiedPoint[index6].Z, a, 0.0, 0.0);
              Point3D Points3 = new Point3D(Values[index4], copiedPoint[index6].Y, copiedPoint[index6].Z);
              if (index1 <= doubleList2.Count - 1)
                Angle = doubleList2[index1];
              buCall.\u0001.Rotate(MidPoint, Angle, Plane.XZ, ref Points2);
              buCall.\u0001.Rotate(MidPoint, Angle, Plane.XZ, ref Points3);
              refPoints.Add(Points2);
              point3DList.Add(Points3);
            }
            if (refPoints.Count > 0)
            {
              arrPL6.Add(refPoints);
              List<Pnt6D> calcPoints = new List<Pnt6D>();
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoints, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints);
              arrCalcPL6.Add(calcPoints);
              arrPLCam.Add(point3DList);
            }
            ++index1;
          }
        }
        MarbleProfileCalcParameters Pars = (MarbleProfileCalcParameters) new \u0007.\u0001(((CounterTopDrawEventArg) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishPlungeFeed, ((CounterTopCreateEventArg) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishCutForwardFeed, ((CounterTopCreateEventArg) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishCutBackwardFeed, ((CounterTopCreateEventArg) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishSafeDis, 20.0, ((CounterTopFormImageIndex) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishZigzagMode, (MarbleCamAreaMode) 1, ((EntityCommandArgs) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).FinishMoveUpSafe, false, true, false);
        ((marbleVacuumPars) this).ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, arrPL6, arrCalcPL6, arrPLCam, ref isReverse, activeKinematic, Pars);
        CamSawRough.Mode = CamMode.WireFrame;
        CamSawRough.CamWireframeType = ((MarbleMachineOptionsSettings) marbleCam).WireType;
        CamSawRough.CamTriMeshType = ((MarbleMachineOptionsSettings) marbleCam).MeshType;
        CamSawRough.NumberOfAxis = 5;
        CamSawRough.TypeCam = CamType.SawCut;
        CamSawRough.Explanation = ((MarbleScreenCaptureSettings) marbleCam).CamName;
        ((MarbleMachineOptionsSettings) marbleCam).CamBase = new camTp(CamSawRough);
        ((MarbleScreenCaptureSettings) marbleCam).isCamCalculated = true;
        buCall.\u0001.BoxSizeCalculate(((MarbleMachineOptionsSettings) marbleCam).CamBase, ref ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint, ref ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint);
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MidPoint = buCall.\u0001.MiddlePointOfLine(((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint, ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint);
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).Width = ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint.X - ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint.X;
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).Height = ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint.Y - ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint.Y;
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).Depth = ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint.Z - ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint.Z;
      }
    }
  }

  public void ProfileOffset(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<List<Point3D>> PLLSurf,
    KinematicBase5 activeKinematic)
  {
    if (PLLSurf.Count <= 0)
      return;
    camTp CamSawRough = new camTp();
    List<Point3D> copiedPoint = new List<Point3D>();
    for (int index1 = 0; index1 <= PLLSurf.Count - 1; ++index1)
    {
      List<Point3D> Points = PLLSurf[index1];
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Points);
      copiedPoint.Clear();
      buVector5.Copy(Points, ref copiedPoint);
      if (copiedPoint.Count > 0)
      {
        ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingMarbleCam).OffsetAngleC = 0.0;
        bool isReverse = false;
        List<List<Pnt6D>> arrPL6 = new List<List<Pnt6D>>();
        List<List<Point3D>> arrPLCam = new List<List<Point3D>>();
        List<List<Pnt6D>> arrCalcPL6 = new List<List<Pnt6D>>();
        double a = 0.0;
        if (((MarbleSelection) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetReverseCAngle)
          ;
        for (int index2 = 0; index2 <= copiedPoint.Count - 1; ++index2)
        {
          List<Pnt6D> refPoints = new List<Pnt6D>();
          List<Point3D> point3DList = new List<Point3D>();
          double z = copiedPoint[index2].Z;
          refPoints.Add(new Pnt6D(copiedPoint[index2].X - ((AddSlatArgs) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).RoughLeadIn, copiedPoint[index2].Y, z, a, 0.0, 0.0));
          refPoints.Add(new Pnt6D(copiedPoint[index2].X + ((buLogMarbleVer5) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).Length + ((MarbleSelectionItems) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetLeadOut, copiedPoint[index2].Y, z, a, 0.0, 0.0));
          point3DList.Add(new Point3D(copiedPoint[index2].X - ((AddSlatArgs) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).RoughLeadIn, copiedPoint[index2].Y, z));
          point3DList.Add(new Point3D(copiedPoint[index2].X + ((buLogMarbleVer5) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).Length + ((MarbleSelectionItems) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetLeadOut, copiedPoint[index2].Y, z));
          if (refPoints.Count > 0)
          {
            arrPL6.Add(refPoints);
            List<Pnt6D> calcPoints = new List<Pnt6D>();
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoints, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints);
            arrCalcPL6.Add(calcPoints);
            arrPLCam.Add(point3DList);
          }
        }
        if (((MarbleProfileCalcParameters) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetCutEdges)
        {
          List<Pnt6D> refPoints1 = new List<Pnt6D>();
          List<Point3D> point3DList1 = new List<Point3D>();
          Pnt6D BasePoint1 = new Pnt6D(arrPL6[0][0]);
          Pnt6D TipPoint1 = new Pnt6D(arrPL6[1][0]);
          BasePoint1.C = buCall.\u0001.PointAngle(TipPoint1, BasePoint1);
          BasePoint1.A = 0.0;
          TipPoint1.C = buCall.\u0001.PointAngle(TipPoint1, BasePoint1);
          TipPoint1.A = 0.0;
          refPoints1.Add(BasePoint1);
          refPoints1.Add(TipPoint1);
          arrPL6.Add(refPoints1);
          point3DList1.Add(new Point3D(arrPLCam[0][0].X, arrPLCam[0][0].Y, arrPLCam[0][0].Z));
          point3DList1.Add(new Point3D(arrPLCam[1][0].X, arrPLCam[1][0].Y, arrPLCam[1][0].Z));
          List<Pnt6D> calcPoints1 = new List<Pnt6D>();
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoints1, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints1);
          arrCalcPL6.Add(calcPoints1);
          arrPLCam.Add(point3DList1);
          List<Pnt6D> refPoints2 = new List<Pnt6D>();
          List<Point3D> point3DList2 = new List<Point3D>();
          Pnt6D TipPoint2 = new Pnt6D(arrPL6[0][arrPL6[0].Count - 1]);
          TipPoint2.A = 0.0;
          Pnt6D BasePoint2 = new Pnt6D(arrPL6[1][arrPL6[1].Count - 1]);
          BasePoint2.A = 0.0;
          TipPoint2.C = buCall.\u0001.PointAngle(TipPoint2, BasePoint2);
          BasePoint2.C = buCall.\u0001.PointAngle(TipPoint2, BasePoint2);
          refPoints2.Add(BasePoint2);
          refPoints2.Add(TipPoint2);
          arrPL6.Add(refPoints2);
          point3DList2.Add(new Point3D(arrPLCam[0][arrPLCam[0].Count - 1].X, arrPLCam[0][arrPLCam[0].Count - 1].Y, arrPLCam[0][arrPLCam[0].Count - 1].Z));
          point3DList2.Add(new Point3D(arrPLCam[1][arrPLCam[1].Count - 1].X, arrPLCam[1][arrPLCam[1].Count - 1].Y, arrPLCam[1][arrPLCam[1].Count - 1].Z));
          List<Pnt6D> calcPoints2 = new List<Pnt6D>();
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoints2, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints2);
          arrCalcPL6.Add(calcPoints2);
          arrPLCam.Add(point3DList2);
        }
        if (!((MarbleG54Offset) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetCutOutside)
        {
          arrPL6.RemoveAt(1);
          arrCalcPL6.RemoveAt(1);
          arrPLCam.RemoveAt(1);
        }
        if (!((MarbleG54Offset) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetCutInisde)
        {
          arrPL6.RemoveAt(0);
          arrCalcPL6.RemoveAt(0);
          arrPLCam.RemoveAt(0);
        }
        MarbleProfileCalcParameters Pars = (MarbleProfileCalcParameters) new \u0007.\u0001(((MarbleCamParameterSetArg) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetPlungeFeed, ((MarbleCamParameterSetArg) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetCutForwardFeed, ((MarbleSelectionItems) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetCutBackwardFeed, ((MarbleSelectionItems) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetSafeDis, 20.0, ((MarbleSelection) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).OffsetZigzagMode, (MarbleCamAreaMode) 1, ((MarbleCamParameterSetArg) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCut).RoughMoveUpSafeDistance, false, false, true);
        ((marbleVacuumPars) this).ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, arrPL6, arrCalcPL6, arrPLCam, ref isReverse, activeKinematic, Pars);
        CamSawRough.Mode = CamMode.WireFrame;
        CamSawRough.CamWireframeType = ((MarbleMachineOptionsSettings) marbleCam).WireType;
        CamSawRough.CamTriMeshType = ((MarbleMachineOptionsSettings) marbleCam).MeshType;
        CamSawRough.NumberOfAxis = 5;
        CamSawRough.TypeCam = CamType.SawCut;
        CamSawRough.Explanation = ((MarbleScreenCaptureSettings) marbleCam).CamName;
        ((MarbleMachineOptionsSettings) marbleCam).CamBase = new camTp(CamSawRough);
        ((MarbleScreenCaptureSettings) marbleCam).isCamCalculated = true;
        buCall.\u0001.BoxSizeCalculate(((MarbleMachineOptionsSettings) marbleCam).CamBase, ref ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint, ref ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint);
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MidPoint = buCall.\u0001.MiddlePointOfLine(((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint, ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint);
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).Width = ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint.X - ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint.X;
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).Height = ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint.Y - ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint.Y;
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).Depth = ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint.Z - ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint.Z;
      }
    }
  }

  public void ProfileCurveRoughLevel(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<List<Point3D>> PLLSurf,
    List<Pnt6DS> OrjPL6,
    KinematicBase5 activeKinematic)
  {
    // ISSUE: unable to decompile the method.
  }

  public void ProfileCurveRoughRegion(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<List<Point3D>> PLLSurf,
    List<Pnt6DS> OrjPL6,
    KinematicBase5 activeKinematic)
  {
    // ISSUE: unable to decompile the method.
  }

  public void ProfileCurveFinish(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<List<Point3D>> PLLSurf,
    KinematicBase5 activeKinematic)
  {
    if (PLLSurf.Count <= 0)
      return;
    camTp CamSawRough = new camTp();
    List<Point3D> copiedPoint = new List<Point3D>();
    List<double> doubleList = new List<double>();
    List<double> Values = new List<double>();
    double Angle1 = 0.0;
    int index1 = 0;
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    double upper = buFile5.RoundToUpper(((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).SweepAngle / ((marbleCountertopCornerData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishAngleStep);
    double num1 = ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).SweepAngle / upper;
    if (((DeleteEntitiesType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).TwistEnable)
    {
      buFile5.DevideMinMaxValueByNumber(((buLogMarbleVer5) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingProfileCurveCut).TwistEndAngle, ((DeleteEntitiesType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingProfileCurveCut).TwistStartAngle, (int) upper + 1, ref Values);
      index1 = 0;
      Angle1 = Values[0];
      buCall.\u0001.BoxSizeCalculate(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
      MidPoint.X += ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius;
    }
    for (int index2 = 0; index2 <= PLLSurf.Count - 1; ++index2)
    {
      List<Point3D> Points1 = PLLSurf[index2];
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Points1);
      copiedPoint.Clear();
      buVector5.Copy(Points1, ref copiedPoint);
      if (copiedPoint.Count > 0)
      {
        doubleList.Clear();
        for (int index3 = 0; index3 <= Points1.Count - 1; ++index3)
        {
          double num2 = index3 != 0 ? buCall.\u0001.PointAngle(Points1[index3], Points1[index3 - 1], Plane.XZ) : buCall.\u0001.PointAngle(Points1[index3 + 1], Points1[index3], Plane.XZ);
          if (num2 > 180.0)
          {
            double num3 = 360.0 - num2;
            if (num3 >= 0.0 & num3 <= 90.0)
              doubleList.Add(Math.Round(num3, 5));
            else
              doubleList.Add(0.0);
          }
          else
            doubleList.Add(0.0);
        }
        ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingMarbleCam).OffsetAngleC = 0.0;
        bool isReverse = false;
        List<List<Pnt6D>> arrPL6 = new List<List<Pnt6D>>();
        List<List<Point3D>> arrPLCam = new List<List<Point3D>>();
        List<List<Pnt6D>> arrCalcPL6 = new List<List<Pnt6D>>();
        double num4 = 0.0;
        if (((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishReverseCAngle)
          num4 = 180.0;
        for (double Angle2 = ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).StartAngle - ((marbleMaterialType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishLeadInAngle; Angle2 <= ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).StartAngle + ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).SweepAngle + ((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishLeadOutAngle; Angle2 += num1)
        {
          if (!((DeleteEntitiesType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).TwistEnable)
          {
            List<Pnt6D> Points2 = new List<Pnt6D>();
            List<Point3D> refPoints = new List<Point3D>();
            for (int index4 = 0; index4 <= copiedPoint.Count - 1; ++index4)
            {
              double a = 0.0;
              if (((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Finish5Axis && index4 <= doubleList.Count - 1)
              {
                a = doubleList[index4];
                if (index4 > 0 && Math.Abs(doubleList[index4] - doubleList[index4 - 1]) > 8.0)
                {
                  Pnt6D Pnt = new Pnt6D(Points2[Points2.Count - 1]);
                  if (Pnt.A <= 0.1)
                  {
                    Pnt6D pnt6D = new Pnt6D(Pnt);
                    pnt6D.Z += 10.0;
                    Points2.Add(pnt6D);
                  }
                  else
                  {
                    double Degree = 360.0 - doubleList[index4 - 1] + 90.0;
                    Pnt6D pnt6D = new Pnt6D(Pnt);
                    double num5 = 10.0 * Math.Cos(buString5.DegreeToRadian(Degree));
                    double num6 = 10.0 * Math.Sin(buString5.DegreeToRadian(Degree));
                    double num7 = Math.Cos(buString5.DegreeToRadian(pnt6D.C - 90.0));
                    double num8 = Math.Cos(buString5.DegreeToRadian(pnt6D.C - 90.0));
                    pnt6D.X += num5 * num7;
                    pnt6D.Y = pnt6D.X + num5 * num8;
                    pnt6D.Z += num6;
                    Points2.Add(pnt6D);
                  }
                  Pnt.A = doubleList[index4];
                  Points2.Add(Pnt);
                }
              }
              Pnt6D Points3 = new Pnt6D(copiedPoint[index4].X + ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius, copiedPoint[index4].Y, copiedPoint[index4].Z, a, 0.0, num4 + 90.0 + Angle2);
              Point3D Points4 = new Point3D(copiedPoint[index4].X + ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius, copiedPoint[index4].Y, copiedPoint[index4].Z);
              buCall.\u0001.Rotate(new Point3D(((MarbleScreenCaptureSettings) Item).BasePoint.X, ((MarbleScreenCaptureSettings) Item).BasePoint.Y, ((MarbleScreenCaptureSettings) Item).BasePoint.Z), Angle2, Plane.XY, ref Points3);
              buCall.\u0001.Rotate(new Point3D(((MarbleScreenCaptureSettings) Item).BasePoint.X, ((MarbleScreenCaptureSettings) Item).BasePoint.Y, ((MarbleScreenCaptureSettings) Item).BasePoint.Z), Angle2, Plane.XY, ref Points4);
              Points2.Add(Points3);
              refPoints.Add(Points4);
            }
            if (Points2.Count > 0)
            {
              buCall.\u0001.Move(-((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius + ((MarbleScreenCaptureSettings) Item).CalcMovePoint.X, -((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius + ((MarbleScreenCaptureSettings) Item).CalcMovePoint.Y, ((MarbleScreenCaptureSettings) Item).CalcMovePoint.Z, ref Points2);
              buCall.\u0001.Move(-((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius + ((MarbleScreenCaptureSettings) Item).CalcMovePoint.X, -((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius + ((MarbleScreenCaptureSettings) Item).CalcMovePoint.Y, ((MarbleScreenCaptureSettings) Item).CalcMovePoint.Z, ref refPoints);
              arrPL6.Add(Points2);
              List<Pnt6D> calcPoints = new List<Pnt6D>();
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(Points2, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints);
              arrCalcPL6.Add(calcPoints);
              arrPLCam.Add(refPoints);
            }
          }
          else
          {
            List<Pnt6D> Points5 = new List<Pnt6D>();
            List<Point3D> refPoints = new List<Point3D>();
            for (int index5 = 0; index5 <= copiedPoint.Count - 1; ++index5)
            {
              double a = 0.0;
              if (((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Finish5Axis && index5 <= doubleList.Count - 1)
              {
                a = doubleList[index5];
                if (index5 > 0 && Math.Abs(doubleList[index5] - doubleList[index5 - 1]) > 8.0)
                {
                  Pnt6D Pnt = new Pnt6D(Points5[Points5.Count - 1]);
                  if (Pnt.A <= 0.1)
                  {
                    Pnt6D pnt6D = new Pnt6D(Pnt);
                    pnt6D.Z += 10.0;
                    Points5.Add(pnt6D);
                  }
                  else
                  {
                    double Degree = 360.0 - doubleList[index5 - 1] + 90.0;
                    Pnt6D pnt6D = new Pnt6D(Pnt);
                    double num9 = 10.0 * Math.Cos(buString5.DegreeToRadian(Degree));
                    double num10 = 10.0 * Math.Sin(buString5.DegreeToRadian(Degree));
                    double num11 = Math.Cos(buString5.DegreeToRadian(pnt6D.C - 90.0));
                    double num12 = Math.Cos(buString5.DegreeToRadian(pnt6D.C - 90.0));
                    pnt6D.X += num9 * num11;
                    pnt6D.Y = pnt6D.X + num9 * num12;
                    pnt6D.Z += num10;
                    Points5.Add(pnt6D);
                  }
                  Pnt.A = doubleList[index5];
                  Points5.Add(Pnt);
                }
              }
              Pnt6D Points6 = new Pnt6D(copiedPoint[index5].X + ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius, copiedPoint[index5].Y, copiedPoint[index5].Z, a, 0.0, num4 + 90.0 + Angle2);
              Point3D Points7 = new Point3D(copiedPoint[index5].X + ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius, copiedPoint[index5].Y, copiedPoint[index5].Z);
              if (index1 <= Values.Count - 1)
                Angle1 = Values[index1];
              buCall.\u0001.Rotate(MidPoint, Angle1, Plane.XZ, ref Points6);
              buCall.\u0001.Rotate(MidPoint, Angle1, Plane.XZ, ref Points7);
              buCall.\u0001.Rotate(new Point3D(((MarbleScreenCaptureSettings) Item).BasePoint.X, ((MarbleScreenCaptureSettings) Item).BasePoint.Y, ((MarbleScreenCaptureSettings) Item).BasePoint.Z), Angle2, Plane.XY, ref Points6);
              buCall.\u0001.Rotate(new Point3D(((MarbleScreenCaptureSettings) Item).BasePoint.X, ((MarbleScreenCaptureSettings) Item).BasePoint.Y, ((MarbleScreenCaptureSettings) Item).BasePoint.Z), Angle2, Plane.XY, ref Points7);
              Points5.Add(Points6);
              refPoints.Add(Points7);
            }
            if (Points5.Count > 0)
            {
              buCall.\u0001.Move(-((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius + ((MarbleScreenCaptureSettings) Item).CalcMovePoint.X, -((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius + ((MarbleScreenCaptureSettings) Item).CalcMovePoint.Y, ((MarbleScreenCaptureSettings) Item).CalcMovePoint.Z, ref Points5);
              buCall.\u0001.Move(-((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius + ((MarbleScreenCaptureSettings) Item).CalcMovePoint.X, -((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius + ((MarbleScreenCaptureSettings) Item).CalcMovePoint.Y, ((MarbleScreenCaptureSettings) Item).CalcMovePoint.Z, ref refPoints);
              arrPL6.Add(Points5);
              List<Pnt6D> calcPoints = new List<Pnt6D>();
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(Points5, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints);
              arrCalcPL6.Add(calcPoints);
              arrPLCam.Add(refPoints);
            }
            ++index1;
          }
        }
        MarbleProfileCalcParameters Pars = (MarbleProfileCalcParameters) new \u0007.\u0001(((marbleChamferBothSideData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishPlungeFeed, ((marbleCountertopPocketData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishCutForwardFeed, ((marbleCountertopPocketData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishCutBackwardFeed, ((marbleCountertopPocketData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishSafeDis, 20.0, ((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishZigzagMode, (MarbleCamAreaMode) 1, ((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).FinishMoveUpSafe, false, true, false);
        ((marbleVacuumPars) this).ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, arrPL6, arrCalcPL6, arrPLCam, ref isReverse, activeKinematic, Pars);
        CamSawRough.Mode = CamMode.WireFrame;
        CamSawRough.CamWireframeType = ((MarbleMachineOptionsSettings) marbleCam).WireType;
        CamSawRough.CamTriMeshType = ((MarbleMachineOptionsSettings) marbleCam).MeshType;
        CamSawRough.NumberOfAxis = 5;
        CamSawRough.TypeCam = CamType.SawCut;
        CamSawRough.Explanation = ((MarbleScreenCaptureSettings) marbleCam).CamName;
        ((MarbleMachineOptionsSettings) marbleCam).CamBase = new camTp(CamSawRough);
        ((MarbleScreenCaptureSettings) marbleCam).isCamCalculated = true;
        buCall.\u0001.BoxSizeCalculate(((MarbleMachineOptionsSettings) marbleCam).CamBase, ref ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint, ref ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint);
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MidPoint = buCall.\u0001.MiddlePointOfLine(((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint, ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint);
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).Width = ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint.X - ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint.X;
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).Height = ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint.Y - ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint.Y;
        ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).Depth = ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MaxPoint.Z - ((ViewportDrawOptions) ((MarbleMachineOptionsSettings) marbleCam).SizeCamItem).MinPoint.Z;
      }
    }
  }
}
