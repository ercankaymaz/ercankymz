// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleVacuumPars
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
public class marbleVacuumPars : buSerilization5
{
  public ColorType colorMaterialDimension;
  public ColorType colorPartDimension;
  public ColorType colorDirArrow;

  public void ProfileCurveOffset(
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
      List<Point3D> Points1 = PLLSurf[index1];
      ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Points1);
      copiedPoint.Clear();
      buVector5.Copy(Points1, ref copiedPoint);
      if (copiedPoint.Count > 0)
      {
        ((marbleCountertopMainPars) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingMarbleCam).OffsetAngleC = 0.0;
        bool isReverse = false;
        double upper = buFile5.RoundToUpper(((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).SweepAngle / ((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetAngleStep);
        double num1 = ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).SweepAngle / upper;
        List<List<Pnt6D>> arrPL6 = new List<List<Pnt6D>>();
        List<List<Point3D>> arrPLCam = new List<List<Point3D>>();
        List<List<Pnt6D>> arrCalcPL6 = new List<List<Pnt6D>>();
        double num2 = 0.0;
        if (((marbleEntityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetReverseCAngle)
          num2 = 180.0;
        for (int index2 = 0; index2 <= copiedPoint.Count - 1; ++index2)
        {
          List<Pnt6D> refPoints = new List<Pnt6D>();
          List<Point3D> point3DList = new List<Point3D>();
          double z = copiedPoint[index2].Z;
          for (double Angle = ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).StartAngle - ((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetLeadInAngle; Angle <= ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).StartAngle + ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).SweepAngle + ((marbleDrillType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetLeadOutAngle; Angle += num1)
          {
            double a = 0.0;
            if (index2 == 0)
              a = ((marbleEntityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetInnerCutAAngle;
            Pnt6D Points2 = new Pnt6D(copiedPoint[index2].X + ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius, copiedPoint[index2].Y, z, a, 0.0, num2 + 90.0 + Angle);
            Point3D Points3 = new Point3D(copiedPoint[index2].X + ((marbleCountertopCavityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).Radius, copiedPoint[index2].Y, z);
            buCall.\u0001.Rotate(new Point3D(((MarbleScreenCaptureSettings) Item).BasePoint.X, ((MarbleScreenCaptureSettings) Item).BasePoint.Y, ((MarbleScreenCaptureSettings) Item).BasePoint.Z), Angle, Plane.XY, ref Points2);
            buCall.\u0001.Rotate(new Point3D(((MarbleScreenCaptureSettings) Item).BasePoint.X, ((MarbleScreenCaptureSettings) Item).BasePoint.Y, ((MarbleScreenCaptureSettings) Item).BasePoint.Z), Angle, Plane.XY, ref Points3);
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
        }
        if (((marbleEntityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetCutEdges)
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
        if (!((marbleEntityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetCutOutside)
        {
          arrPL6.RemoveAt(1);
          arrCalcPL6.RemoveAt(1);
          arrPLCam.RemoveAt(1);
        }
        if (!((marbleEntityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetCutInisde)
        {
          arrPL6.RemoveAt(0);
          arrCalcPL6.RemoveAt(0);
          arrPLCam.RemoveAt(0);
        }
        MarbleProfileCalcParameters Pars = (MarbleProfileCalcParameters) new \u0007.\u0001(((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetPlungeFeed, ((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetCutForwardFeed, ((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetCutBackwardFeed, ((marbleMenuType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetSafeDis, 20.0, ((marbleEntityData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).OffsetZigzagMode, (MarbleCamAreaMode) 1, ((marbleChamferBothSideData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingProfileCurveCut).RoughMoveUpSafeDistance, false, false, true);
        this.ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, arrPL6, arrCalcPL6, arrPLCam, ref isReverse, activeKinematic, Pars);
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

  public void ProfileCamCalcFromPnt6DList(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    ref camTp CamSawRough,
    List<List<Pnt6D>> arrPL6,
    List<List<Pnt6D>> arrCalcPL6,
    List<List<Point3D>> arrPLCam,
    ref bool isReverse,
    KinematicBase5 activeKinematic,
    MarbleProfileCalcParameters Pars)
  {
    // ISSUE: unable to decompile the method.
  }

  public void ProfileSettingToCamSetting(
    marbleProfileCutPars settingProfile,
    bool isFinish,
    ref camParameters5 settingCam)
  {
    if (isFinish)
    {
      settingCam.Distances.Safe = ((CounterTopCreateEventArg) settingProfile).FinishSafeDis;
      ((camMaterial5) settingCam.Distances).Rapid = ((CounterTopFormImageIndex) settingProfile).FinishRapid;
      settingCam.Speeds.Plunge = ((CounterTopDrawEventArg) settingProfile).FinishPlungeFeed;
      settingCam.Speeds.Feed = ((CounterTopCreateEventArg) settingProfile).FinishCutForwardFeed;
    }
    else
    {
      settingCam.Distances.Safe = ((EntityCommandArgs) settingProfile).RoughSafeDis;
      ((camMaterial5) settingCam.Distances).Rapid = ((EntityCommandArgs) settingProfile).RoughRapid;
      settingCam.Speeds.Plunge = ((EntityCommandArgs) settingProfile).RoughPlungeFeed;
      settingCam.Speeds.Feed = ((EntityCommandArgs) settingProfile).RoughCutForwardFeed;
    }
  }

  public void ProfileCurveSettingToCamSetting(
    marbleProfileCurveCutPars settingProfileCurve,
    bool isFinish,
    ref camParameters5 settingCam)
  {
    if (isFinish)
    {
      settingCam.Distances.Safe = ((marbleCountertopPocketData) settingProfileCurve).FinishSafeDis;
      ((camMaterial5) settingCam.Distances).Rapid = ((marbleCountertopPocketData) settingProfileCurve).FinishRapid;
      settingCam.Speeds.Plunge = ((marbleChamferBothSideData) settingProfileCurve).FinishPlungeFeed;
      settingCam.Speeds.Feed = ((marbleCountertopPocketData) settingProfileCurve).FinishCutForwardFeed;
    }
    else
    {
      settingCam.Distances.Safe = ((marbleCountertopCavityData) settingProfileCurve).RoughSafeDis;
      ((camMaterial5) settingCam.Distances).Rapid = ((marbleCountertopCavityData) settingProfileCurve).RoughRapid;
      settingCam.Speeds.Plunge = ((marbleCountertopCavityData) settingProfileCurve).RoughPlungeFeed;
      settingCam.Speeds.Feed = ((marbleCountertopCavityData) settingProfileCurve).RoughCutForwardFeed;
    }
  }

  public void PocketByDrilling(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    List<List<Point3D>> PLL3D,
    double CutDepth,
    KinematicBase5 activeKinematic)
  {
    List<List<Pnt6D>> pnt6DListList1 = new List<List<Pnt6D>>();
    List<List<Point3D>> point3DListList = new List<List<Point3D>>();
    List<List<Pnt6D>> pnt6DListList2 = new List<List<Pnt6D>>();
    for (int index1 = 0; index1 <= PLL3D.Count - 1; ++index1)
    {
      List<Point3D> copiedPoint = new List<Point3D>();
      buVector5.Copy(PLL3D[index1], ref copiedPoint);
      double num1 = buCall.\u0001.Length3D(copiedPoint);
      double num2 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter, CutDepth, 0.0, 0.0, 0.0);
      if (num1 > num2 + 10.0)
      {
        Point3D CenterPnt = buCall.\u0001.MiddlePointOfLine(copiedPoint[0], copiedPoint[copiedPoint.Count - 1]);
        double Angle = buCall.\u0001.PointAngle(copiedPoint[copiedPoint.Count - 1], copiedPoint[0]);
        Point3D EndPnt1 = new Point3D();
        Point3D EndPnt2 = new Point3D();
        buCall.\u0001.LineWithLengthAndAngle(CenterPnt, num1 / 2.0 - num2, Angle + 180.0, ref EndPnt1);
        buCall.\u0001.LineWithLengthAndAngle(CenterPnt, num1 / 2.0 - num2, Angle, ref EndPnt2);
        copiedPoint[0] = EndPnt1;
        copiedPoint[copiedPoint.Count - 1] = EndPnt2;
        if (index1 % 2 == 0)
          copiedPoint.Reverse();
        List<Pnt6D> refPoints = new List<Pnt6D>();
        buShape buShape = new buShape(copiedPoint);
        List<Point3D> point3DList = new List<Point3D>();
        double c = 0.0;
        for (int index2 = 0; index2 <= copiedPoint.Count - 1; ++index2)
        {
          Pnt6D pnt6D = new Pnt6D(copiedPoint[index2].X, copiedPoint[index2].Y, copiedPoint[index2].Z, 0.0, 0.0, c);
          refPoints.Add(pnt6D);
          point3DList.Add(new Point3D(copiedPoint[index2].X, copiedPoint[index2].Y, copiedPoint[index2].Z));
        }
        List<Pnt6D> calcPoints = new List<Pnt6D>();
        ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoints, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints);
        pnt6DListList1.Add(refPoints);
        pnt6DListList2.Add(calcPoints);
        point3DListList.Add(point3DList);
      }
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
}
