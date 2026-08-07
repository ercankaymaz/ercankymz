// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleSlicesPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSlicesPars : buSerilization5
{
  public DisplayModeType DialogViewportDisplayType;
  public ProjectionModeType DialogViewportProjection;
  public bool DialogViewportShowCubeBox;
  public bool DialogViewportShowUcsArrow;
  public bool DialogViewportShowOrigineSembol;
  public bool DialogViewportShowMouseCoordinates;
  public int SolidTranperancy;
  public ColorType colorItemBase;
  public ColorType colorItem;
  public ColorType colorItemContour;
  public ColorType colorItemEngrave;
  public ColorType colorItemInside;
  public ColorType colorItemProfile;

  public void ExtensionCalculation(
    ref MarbleItemCam marbleCam,
    ref List<List<buEntity>> calcEntities,
    ref List<List<buEntity>> calcEntitiesStrip)
  {
    if ((((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities == null ? 0 : (((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities.Count > 0 ? 1 : 0)) != 0)
    {
      List<buEntity> buEntityList1 = new List<buEntity>();
      for (int index1 = ((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities.Count - 1; index1 >= 0; --index1)
      {
        if (((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities[index1] != null)
        {
          List<buEntity> buEntityList2 = new List<buEntity>();
          for (int index2 = 0; index2 <= ((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities[index1].Count - 1; ++index2)
          {
            if (((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities[index1][index2] != null)
            {
              buEntity buEntity = (buEntity) null;
              buDiametricDim.Copy(((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities[index1][index2], ref buEntity);
              if (((DirectionArrowSetting) ((CustomData) buEntity).Info).Enable)
              {
                if (((CustomDataSurrogate) buEntity).Orientation.A < 0.0)
                {
                  ((CustomDataSurrogate) buEntity).Orientation.A = -((CustomDataSurrogate) buEntity).Orientation.A;
                  buCall.\u0001.ChangeEntitiesDirection(ref buEntity);
                }
                if (buEntityList1.Count == 0)
                  buEntityList1.Add(buEntity);
                else if (((EntityInfo) ((CustomData) buEntityList1[buEntityList1.Count - 1]).Marble).CommandID == ((EntityInfo) ((CustomData) buEntity).Marble).CommandID)
                {
                  buEntityList1.Add(buEntity);
                }
                else
                {
                  for (int index3 = 0; index3 <= buEntityList1.Count - 1; ++index3)
                    calcEntitiesStrip.Add(new List<buEntity>()
                    {
                      buEntityList1[index3]
                    });
                  buEntityList1.Clear();
                  buEntityList1.Add(buEntity);
                }
              }
            }
          }
        }
      }
      if (buEntityList1.Count > 0)
      {
        for (int index = 0; index <= buEntityList1.Count - 1; ++index)
          calcEntitiesStrip.Add(new List<buEntity>()
          {
            buEntityList1[index]
          });
      }
    }
    if ((((MarbleMachineOptionsSettings) marbleCam).WireEntities == null ? 0 : (((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities != null ? 1 : 0)) != 0)
    {
      for (int index4 = 0; index4 <= ((MarbleMachineOptionsSettings) marbleCam).WireEntities.Count - 1; ++index4)
      {
        if (((MarbleMachineOptionsSettings) marbleCam).WireEntities[index4] != null)
        {
          List<buEntity> buEntityList = new List<buEntity>();
          for (int index5 = 0; index5 <= ((MarbleMachineOptionsSettings) marbleCam).WireEntities[index4].Count - 1; ++index5)
          {
            if (((MarbleMachineOptionsSettings) marbleCam).WireEntities[index4][index5] != null)
            {
              buEntity ChangedEntities = ((MarbleMachineOptionsSettings) marbleCam).WireEntities[index4][index5];
              for (int index6 = 0; index6 <= ((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities.Count - 1; ++index6)
              {
                if (((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities[index6] != null)
                {
                  for (int index7 = 0; index7 <= ((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities[index6].Count - 1; ++index7)
                  {
                    if (((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities[index6][index7] != null)
                    {
                      buEntity buEntity = ((MarbleMachineOptionsSettings) marbleCam).WireAuxEntities[index6][index7];
                      Point3D pntIntersect = new Point3D();
                      if (buCall.\u0001.LineLineIntersection(((CustomData) ChangedEntities).StartPoint, ((CustomData) ChangedEntities).EndPoint, ((CustomData) buEntity).StartPoint, ((CustomData) buEntity).EndPoint, Plane.XY, ref pntIntersect))
                      {
                        double num1 = buCall.\u0001.Length3D(((CustomData) ChangedEntities).StartPoint, pntIntersect);
                        double num2 = buCall.\u0001.Length3D(((CustomData) ChangedEntities).EndPoint, pntIntersect);
                        if (num1 < num2)
                        {
                          if (num1 < 100.0)
                            ((CustomData) ChangedEntities).StartPoint = F_NotchEdit.ToPoint3D(pntIntersect);
                        }
                        else if (num2 < 100.0)
                          ((CustomData) ChangedEntities).EndPoint = F_NotchEdit.ToPoint3D(pntIntersect);
                        ((buUpperLine) ChangedEntities).Update();
                        if (((CustomDataSurrogate) ChangedEntities).Orientation.A < 0.0)
                        {
                          ((CustomDataSurrogate) ChangedEntities).Orientation.A = -((CustomDataSurrogate) ChangedEntities).Orientation.A;
                          buCall.\u0001.ChangeEntitiesDirection(ref ChangedEntities);
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
    buRadialDim.Copy(((MarbleMachineOptionsSettings) marbleCam).WireEntities, ref calcEntities);
  }

  public void SawMillingHorizontalRough(
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

  public void SawMillingHorizontalRough(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    ref bool isReverse,
    MarbleSawCalcParameters Setting,
    List<Point3DList> PLL3D,
    double CutDepth,
    KinematicBase5 activeKinematic)
  {
    ToolBase5 Tool = (ToolBase5) new ToolGeometry5(((MarbleMachineOptionsSettings) marbleCam).ToolSelected);
    ((ToolGeometry5) Tool).Geometry.Diameter = 0.1;
    List<List<Pnt6D>> pnt6DListList1 = new List<List<Pnt6D>>();
    List<List<Point3D>> point3DListList = new List<List<Point3D>>();
    List<List<Pnt6D>> pnt6DListList2 = new List<List<Pnt6D>>();
    for (int index1 = 0; index1 <= PLL3D.Count - 1; ++index1)
    {
      MarbleSawCalcParameters sawCalcParameters = (((ToolGeometry5) PLL3D[index1]).Settings == null ? 0 : (((ToolGeometry5) PLL3D[index1]).Settings is MarbleSawCalcParameters ? 1 : 0)) == 0 ? (MarbleSawCalcParameters) new \u0007.\u0001(Setting) : (MarbleSawCalcParameters) new \u0007.\u0001((MarbleSawCalcParameters) ((ToolGeometry5) PLL3D[index1]).Settings);
      List<Point3D> copiedPoint = new List<Point3D>();
      buVector5.Copy(((ToolGeometry5) PLL3D[index1]).Points, ref copiedPoint);
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
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic)
        {
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoints, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoints);
        }
        else
        {
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoints, activeKinematic, Tool, ref calcPoints);
          for (int index3 = 0; index3 <= calcPoints.Count - 1; ++index3)
            calcPoints[index3].Z -= ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter / 2.0;
        }
        pnt6DListList1.Add(refPoints);
        pnt6DListList2.Add(calcPoints);
        point3DListList.Add(point3DList);
      }
    }
    ((MarbleMachineOptionsSettings) marbleCam).CamBase.Tool = (ToolBase5) new ToolGeometry5(((MarbleMachineOptionsSettings) marbleCam).ToolSelected);
    for (int index4 = 0; index4 <= pnt6DListList2.Count - 1; ++index4)
    {
      camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
      ((TpPnt9D) camTpPoint).ToolCam = (ToolBase5) new ToolGeometry5(((MarbleMachineOptionsSettings) marbleCam).ToolSelected);
      double feed1 = ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerForwardCuttingFeed;
      if (index4 >= 0)
      {
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(pnt6DListList2[index4], ref MinPoint, ref MidPoint, ref MaxPoint);
        Pnt6D P1 = new Pnt6D(pnt6DListList2[index4][0].X, MinPoint.Y - ((MarbleItemCommands) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerApproach, pnt6DListList2[index4][0].Z + ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerSafeDistance, pnt6DListList2[index4][0].A, 0.0, pnt6DListList2[index4][0].C);
        Pnt6D P2 = new Pnt6D(pnt6DListList2[index4][0].X, MinPoint.Y - ((MarbleItemCommands) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerApproach, pnt6DListList2[index4][0].Z, pnt6DListList2[index4][0].A, 0.0, pnt6DListList2[index4][0].C);
        TpPnt9D tpPnt9D1 = new TpPnt9D(P1, feed1, 0);
        camTpPoint.Points.Add(tpPnt9D1);
        TpPnt9D tpPnt9D2 = new TpPnt9D(P2, feed1, 0);
        camTpPoint.Points.Add(tpPnt9D2);
      }
      if (index4 % 2 == 0)
        feed1 = ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerBackwardCuttingFeed;
      for (int index5 = 0; index5 <= pnt6DListList2[index4].Count - 1; ++index5)
      {
        double feed2 = feed1;
        if (index4 == 0 & index5 == 0)
          feed2 = ((MarbleCountertopInsideTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerPlungeFeed;
        TpPnt9D tpPnt9D = new TpPnt9D(pnt6DListList2[index4][index5], feed2, 1);
        camTpPoint.Points.Add(tpPnt9D);
      }
      if (index4 >= 0)
      {
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(pnt6DListList2[index4], ref MinPoint, ref MidPoint, ref MaxPoint);
        Pnt6D P = new Pnt6D(pnt6DListList2[index4][pnt6DListList2[index4].Count - 1].X, MinPoint.Y - ((MarbleItemCommands) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerApproach, pnt6DListList2[index4][pnt6DListList2[index4].Count - 1].Z + ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerSafeDistance, pnt6DListList2[index4][pnt6DListList2[index4].Count - 1].A, 0.0, pnt6DListList2[index4][pnt6DListList2[index4].Count - 1].C);
        TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(pnt6DListList2[index4][pnt6DListList2[index4].Count - 1].X, MinPoint.Y - ((MarbleItemCommands) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerApproach, pnt6DListList2[index4][pnt6DListList2[index4].Count - 1].Z + ((MarbleCountertopCornerTypes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingFinishVerSafeDistance, pnt6DListList2[index4][pnt6DListList2[index4].Count - 1].A, 0.0, pnt6DListList2[index4][pnt6DListList2[index4].Count - 1].C), feed1, 0);
        camTpPoint.Points.Add(tpPnt9D3);
        TpPnt9D tpPnt9D4 = new TpPnt9D(P, feed1, 0);
        camTpPoint.Points.Add(tpPnt9D4);
      }
      ((MarbleMachineOptionsSettings) marbleCam).CamBase.CamPoints.Add(camTpPoint);
      LinearPath linearPath = new LinearPath((ICollection<Point3D>) point3DListList[index4]);
      ((MarbleMachineOptionsSettings) marbleCam).CamBase.EntitiesG1.Add((Entity) linearPath);
    }
  }

  public void SawMillingVerticalToolPointCamCalc(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    ref bool isReverse,
    MarbleSawCalcParameters Setting,
    List<Point3DList> PLL3D,
    KinematicBase5 activeKinematic)
  {
    try
    {
      int num1 = 0;
      Pnt6D pnt6D = new Pnt6D();
      Pnt6D calcPoint = new Pnt6D();
      ToolBase5 Tool = (ToolBase5) new ToolGeometry5(((MarbleMachineOptionsSettings) marbleCam).ToolSelected);
      ((ToolGeometry5) Tool).Geometry.Diameter = 0.1;
      for (int index1 = 0; index1 <= PLL3D.Count - 1; ++index1)
      {
        camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
        Point3D EndPnt = (Point3D) null;
        MarbleSawCalcParameters sawCalcParameters = (((ToolGeometry5) PLL3D[index1]).Settings == null ? 0 : (((ToolGeometry5) PLL3D[index1]).Settings is MarbleSawCalcParameters ? 1 : 0)) == 0 ? (MarbleSawCalcParameters) new \u0007.\u0001(Setting) : (MarbleSawCalcParameters) new \u0007.\u0001((MarbleSawCalcParameters) ((ToolGeometry5) PLL3D[index1]).Settings);
        List<Point3D> point3DList1 = new List<Point3D>();
        List<Point3D> point3DList2 = new List<Point3D>();
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).DevideLength > 0.0)
          buCall.\u0001.DevidePointsByLength(((ToolGeometry5) PLL3D[index1]).Points, ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).DevideLength, ref point3DList1);
        else
          buVector5.Copy(((ToolGeometry5) PLL3D[index1]).Points, ref point3DList1, 4);
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ShiftPoint != (Point3D) null & ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ShiftEnable)
          buCall.\u0001.ShiftPointsByLength(((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ShiftPoint, ref point3DList1, true);
        if (((buMarbleForms) sawCalcParameters).SplineEnable)
          buCall.\u0001.BSplineAtSharpCorner(point3DList1, ((buMarbleForms) sawCalcParameters).Splinedt, 20.0, false, ref point3DList2);
        else
          buVector5.Copy(point3DList1, ref point3DList2, 4);
        point3DList1.Clear();
        ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList2);
        ClockDirectionType clockDirectionType = buCall.\u0001.GetClockDirection(point3DList2);
        if (clockDirectionType == ClockDirectionType.CW)
        {
          clockDirectionType = ClockDirectionType.CCW;
          point3DList2.Reverse();
        }
        double num2 = buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[1]), F_NotchEdit.ToPoint3D(point3DList2[0]));
        if (isReverse)
          num2 -= 180.0;
        if (index1 > 0 && Math.Abs(pnt6D.C - num2) > 180.0)
        {
          if (num2 > pnt6D.C)
            num2 -= 360.0;
          else
            num2 += 360.0;
        }
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseContantAngle)
          num2 = ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ConstantAngle;
        double Length1 = ((buMarbleForms) sawCalcParameters).SafeDistanceXY;
        if (((RoboticSettings) sawCalcParameters).LeadInDistance > 0.0)
          Length1 = ((RoboticSettings) sawCalcParameters).LeadInDistance;
        if (clockDirectionType == ClockDirectionType.CW)
        {
          EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[0]), Length1, num2 - 90.0, ref EndPnt);
        }
        else
        {
          EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[0]), Length1, num2 - 90.0, ref EndPnt);
        }
        if (index1 == 0)
        {
          if (((RoboticSettings) sawCalcParameters).MoveSafeZDistance)
          {
            Pnt6D refPoint1 = new Pnt6D(EndPnt.X, EndPnt.Y, EndPnt.Z);
            refPoint1.A = 0.0;
            refPoint1.C = 0.0;
            refPoint1.Z = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.Z + ((buMarbleForms) sawCalcParameters).SafeDistanceZ;
            TpPnt9D tpPnt9D1;
            if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic)
            {
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint1, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
              tpPnt9D1 = new TpPnt9D(calcPoint, 100.0, 0);
            }
            else
            {
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint1, activeKinematic, Tool, ref calcPoint);
              if (buConversion5.EQ(refPoint1.A, 90.0))
                calcPoint.Z -= ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter / 2.0;
              tpPnt9D1 = new TpPnt9D(calcPoint, 100.0, 0);
            }
            tpPnt9D1.EnableAxes.Z = false;
            camTpPoint.Points.Add(tpPnt9D1);
            Pnt6D refPoint2 = new Pnt6D(EndPnt.X, EndPnt.Y, EndPnt.Z);
            refPoint2.A = 90.0;
            refPoint2.C = num2;
            refPoint2.Z = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.Z + ((buMarbleForms) sawCalcParameters).SafeDistanceZ;
            TpPnt9D tpPnt9D2;
            if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic)
            {
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint2, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
              tpPnt9D2 = new TpPnt9D(calcPoint, 100.0, 0);
            }
            else
            {
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint2, activeKinematic, Tool, ref calcPoint);
              if (buConversion5.EQ(refPoint2.A, 90.0))
                calcPoint.Z -= ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter / 2.0;
              tpPnt9D2 = new TpPnt9D(calcPoint, 100.0, 0);
            }
            camTpPoint.Points.Add(tpPnt9D2);
          }
          else
          {
            Pnt6D refPoint = new Pnt6D(EndPnt.X, EndPnt.Y, point3DList2[0].Z);
            refPoint.A = 90.0;
            refPoint.C = num2;
            TpPnt9D tpPnt9D;
            if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic)
            {
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
              tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
            }
            else
            {
              ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint, activeKinematic, Tool, ref calcPoint);
              if (buConversion5.EQ(refPoint.A, 90.0))
                calcPoint.Z -= ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter / 2.0;
              tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
            }
            camTpPoint.Points.Add(tpPnt9D);
          }
        }
        Pnt6D refPoint3 = new Pnt6D(point3DList2[0].X, point3DList2[0].Y, point3DList2[0].Z);
        refPoint3.A = 90.0;
        refPoint3.C = num2;
        TpPnt9D tpPnt9D3;
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic)
        {
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint3, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
          tpPnt9D3 = new TpPnt9D(calcPoint, ((buMarbleForms) sawCalcParameters).PlungeSpeed, 1);
        }
        else
        {
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint3, activeKinematic, Tool, ref calcPoint);
          if (buConversion5.EQ(refPoint3.A, 90.0))
            calcPoint.Z -= ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter / 2.0;
          tpPnt9D3 = new TpPnt9D(calcPoint, ((buMarbleForms) sawCalcParameters).PlungeSpeed, 1);
        }
        tpPnt9D3.AfterCodes.Add((object) "G38 O1");
        tpPnt9D3.AfterCodes.Add((object) "G51 D1");
        camTpPoint.Points.Add(tpPnt9D3);
        double num3 = num2;
        List<Point3D> point3DList3 = new List<Point3D>();
        point3DList3.Add(new Point3D(((TpArcData) tpPnt9D3).P9.X, ((TpArcData) tpPnt9D3).P9.Y, ((TpArcData) tpPnt9D3).P9.Z));
        for (int index2 = 1; index2 <= point3DList2.Count - 1; ++index2)
        {
          F_NotchEdit.ToPoint3D(point3DList2[index2]);
          double num4 = index2 != 0 ? buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[index2]), F_NotchEdit.ToPoint3D(point3DList2[index2 - 1])) : buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[index2 + 1]), F_NotchEdit.ToPoint3D(point3DList2[index2]));
          if (isReverse)
            num4 -= 180.0;
          double num5 = num4 - num3;
          if (Math.Abs(num5) > 180.0)
          {
            if (num5 > 0.0)
              num4 -= 360.0;
            else
              num4 += 360.0;
          }
          if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseContantAngle)
            num4 = ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ConstantAngle;
          double feed = ((buMarbleForms) sawCalcParameters).ForwardCutSpeed;
          if (isReverse)
            feed = ((buMarbleForms) sawCalcParameters).BackwardCutSpeed;
          Pnt6D refPoint4 = new Pnt6D(point3DList2[index2].X, point3DList2[index2].Y, point3DList2[index2].Z);
          refPoint4.A = 90.0;
          refPoint4.C = num4;
          TpPnt9D tpPnt9D4;
          if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic)
          {
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint4, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
            tpPnt9D4 = new TpPnt9D(calcPoint, feed, 1);
          }
          else
          {
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint4, activeKinematic, Tool, ref calcPoint);
            if (buConversion5.EQ(refPoint4.A, 90.0))
              calcPoint.Z -= ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter / 2.0;
            tpPnt9D4 = new TpPnt9D(calcPoint, feed, 1);
          }
          camTpPoint.Points.Add(tpPnt9D4);
          point3DList3.Add(new Point3D(((TpArcData) tpPnt9D4).P9.X, ((TpArcData) tpPnt9D4).P9.Y, ((TpArcData) tpPnt9D4).P9.Z));
          num3 = num4;
        }
        double num6 = buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 1]), F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 2]));
        if (isReverse)
          num6 -= 180.0;
        double num7 = num6 - num3;
        if (Math.Abs(num7) > 180.0)
        {
          if (num7 > 0.0)
            num6 -= 360.0;
          else
            num6 += 360.0;
        }
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseContantAngle)
          num6 = ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ConstantAngle;
        if (index1 == PLL3D.Count - 1)
        {
          double Length2 = ((buMarbleForms) sawCalcParameters).SafeDistanceXY;
          if (((RoboticSettings) sawCalcParameters).LeadOutDistance > 0.0)
            Length2 = ((RoboticSettings) sawCalcParameters).LeadOutDistance;
          if (clockDirectionType == ClockDirectionType.CW)
          {
            EndPnt = new Point3D();
            buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 1]), Length2, num6 - 90.0, ref EndPnt);
          }
          else
          {
            EndPnt = new Point3D();
            buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 1]), Length2, num6 - 90.0, ref EndPnt);
          }
          Pnt6D refPoint5 = new Pnt6D(EndPnt.X, EndPnt.Y, EndPnt.Z);
          refPoint5.A = 90.0;
          refPoint5.C = num6;
          TpPnt9D tpPnt9D5;
          if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic)
          {
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint5, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
            tpPnt9D5 = new TpPnt9D(calcPoint, 100.0, 0);
          }
          else
          {
            ((marbleSawMillingPars) this).CalculatePointsWithKinematic(refPoint5, activeKinematic, Tool, ref calcPoint);
            if (buConversion5.EQ(refPoint5.A, 90.0))
              calcPoint.Z -= ((ToolGeometry5) ((MarbleMachineOptionsSettings) marbleCam).ToolSelected).Geometry.Diameter / 2.0;
            tpPnt9D5 = new TpPnt9D(calcPoint, 100.0, 0);
          }
          tpPnt9D5.PreCodes.Add((object) "G39 O1");
          tpPnt9D5.PreCodes.Add((object) "G50");
          camTpPoint.Points.Add(tpPnt9D5);
        }
        pnt6D = new Pnt6D(calcPoint);
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) point3DList2);
        linearPath.Color = ((MarbleCountertopModes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingCamColor;
        linearPath.ColorMethod = colorMethodType.byEntity;
        ((MarbleMachineOptionsSettings) marbleCam).CamBase.EntitiesG1.Add((Entity) linearPath);
        ((MarbleMachineOptionsSettings) marbleCam).CamBase.CamPoints.Add(camTpPoint);
        if (((MarbleMachineOptionsSettings) marbleCam).CamBase != null)
          ((MarbleMachineOptionsSettings) marbleCam).CamBase.TypeCam = CamType.SawCut;
        isReverse = !isReverse;
        ++num1;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void SawMillingVerticalToolPointCamCenterCalc(
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam,
    MarbleSawCalcParameters Setting,
    List<Point3DList> PLL3D,
    KinematicBase5 activeKinematic)
  {
    try
    {
      int num1 = 0;
      bool flag = false;
      Pnt6D pnt6D1 = new Pnt6D();
      Pnt6D calcPoint = new Pnt6D();
      for (int index1 = 0; index1 <= PLL3D.Count - 1; ++index1)
      {
        camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
        Point3D EndPnt = (Point3D) null;
        MarbleSawCalcParameters sawCalcParameters = (((ToolGeometry5) PLL3D[index1]).Settings == null ? 0 : (((ToolGeometry5) PLL3D[index1]).Settings is MarbleSawCalcParameters ? 1 : 0)) == 0 ? (MarbleSawCalcParameters) new \u0007.\u0001(Setting) : (MarbleSawCalcParameters) new \u0007.\u0001((MarbleSawCalcParameters) ((ToolGeometry5) PLL3D[index1]).Settings);
        List<Point3D> point3DList1 = new List<Point3D>();
        List<Point3D> point3DList2 = new List<Point3D>();
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).DevideLength > 0.0)
          buCall.\u0001.DevidePointsByLength(((ToolGeometry5) PLL3D[index1]).Points, ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).DevideLength, ref point3DList1);
        else
          buVector5.Copy(((ToolGeometry5) PLL3D[index1]).Points, ref point3DList1, 4);
        if (((buMarbleForms) sawCalcParameters).SplineEnable)
          buCall.\u0001.BSplineQuadraticUniform(point3DList1, ((buMarbleForms) sawCalcParameters).Splinedt, true, ref point3DList2);
        else
          buVector5.Copy(point3DList1, ref point3DList2, 4);
        point3DList1.Clear();
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ShiftPoint != (Point3D) null & ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ShiftEnable)
          buCall.\u0001.ShiftPointsByLength(((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ShiftPoint, ref point3DList2, true);
        ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList2);
        ClockDirectionType clockDirectionType = buCall.\u0001.GetClockDirection(point3DList2);
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseClockDirection)
        {
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
        }
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseClockDirection)
          clockDirectionType = ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).SetClockDir;
        double num2 = buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[1]), F_NotchEdit.ToPoint3D(point3DList2[0]));
        if (flag)
          num2 -= 180.0;
        if (index1 > 0 && Math.Abs(pnt6D1.C - num2) > 180.0)
        {
          if (num2 > pnt6D1.C)
            num2 -= 360.0;
          else
            num2 += 360.0;
        }
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseContantAngle)
          num2 = ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ConstantAngle;
        double Length1 = ((buMarbleForms) sawCalcParameters).SafeDistanceXY;
        if (((RoboticSettings) sawCalcParameters).LeadInDistance > 0.0)
          Length1 = ((RoboticSettings) sawCalcParameters).LeadInDistance;
        if (clockDirectionType == ClockDirectionType.CW)
        {
          EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[0]), Length1, num2 - 90.0, ref EndPnt);
        }
        else
        {
          EndPnt = new Point3D();
          buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[0]), Length1, num2 - 90.0, ref EndPnt);
        }
        if (index1 == 0 & ((RoboticSettings) sawCalcParameters).isFirst)
        {
          Pnt6D pnt6D2 = new Pnt6D(EndPnt.X, EndPnt.Y, EndPnt.Z);
          pnt6D2.A = 0.0;
          pnt6D2.C = 0.0;
          pnt6D2.Z = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.Z + ((buMarbleForms) sawCalcParameters).SafeDistanceZ;
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D2, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
          TpPnt9D tpPnt9D1 = !((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic ? new TpPnt9D(pnt6D2, 100.0, 0) : new TpPnt9D(calcPoint, 100.0, 0);
          tpPnt9D1.EnableAxes.Z = false;
          camTpPoint.Points.Add(tpPnt9D1);
          Pnt6D pnt6D3 = new Pnt6D(EndPnt.X, EndPnt.Y, EndPnt.Z);
          pnt6D3.A = 90.0;
          pnt6D3.C = num2;
          pnt6D3.Z = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.Z + ((buMarbleForms) sawCalcParameters).SafeDistanceZ;
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D3, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
          TpPnt9D tpPnt9D2 = !((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic ? new TpPnt9D(pnt6D3, 100.0, 0) : new TpPnt9D(calcPoint, 100.0, 0);
          camTpPoint.Points.Add(tpPnt9D2);
        }
        Pnt6D pnt6D4 = new Pnt6D(point3DList2[0].X, point3DList2[0].Y, point3DList2[0].Z);
        pnt6D4.A = 90.0;
        pnt6D4.C = num2;
        ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D4, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
        TpPnt9D tpPnt9D3 = !((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic ? new TpPnt9D(pnt6D4, ((buMarbleForms) sawCalcParameters).PlungeSpeed, 1) : new TpPnt9D(calcPoint, ((buMarbleForms) sawCalcParameters).PlungeSpeed, 1);
        tpPnt9D3.AfterCodes.Add((object) "G38 O1");
        tpPnt9D3.AfterCodes.Add((object) "G51 D1");
        camTpPoint.Points.Add(tpPnt9D3);
        double num3 = num2;
        List<Point3D> point3DList3 = new List<Point3D>();
        point3DList3.Add(new Point3D(((TpArcData) tpPnt9D3).P9.X, ((TpArcData) tpPnt9D3).P9.Y, ((TpArcData) tpPnt9D3).P9.Z));
        for (int index2 = 1; index2 <= point3DList2.Count - 1; ++index2)
        {
          F_NotchEdit.ToPoint3D(point3DList2[index2]);
          double num4 = index2 != 0 ? buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[index2]), F_NotchEdit.ToPoint3D(point3DList2[index2 - 1])) : buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[index2 + 1]), F_NotchEdit.ToPoint3D(point3DList2[index2]));
          if (flag)
            num4 -= 180.0;
          double num5 = num4 - num3;
          if (Math.Abs(num5) > 180.0)
          {
            if (num5 > 0.0)
              num4 -= 360.0;
            else
              num4 += 360.0;
          }
          if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseContantAngle)
            num4 = ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ConstantAngle;
          double feed = ((buMarbleForms) sawCalcParameters).ForwardCutSpeed;
          if (flag)
            feed = ((buMarbleForms) sawCalcParameters).BackwardCutSpeed;
          Pnt6D pnt6D5 = new Pnt6D(point3DList2[index2].X, point3DList2[index2].Y, point3DList2[index2].Z);
          pnt6D5.A = 90.0;
          pnt6D5.C = num4;
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D5, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
          TpPnt9D tpPnt9D4 = !((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic ? new TpPnt9D(pnt6D5, feed, 1) : new TpPnt9D(calcPoint, feed, 1);
          camTpPoint.Points.Add(tpPnt9D4);
          point3DList3.Add(new Point3D(((TpArcData) tpPnt9D4).P9.X, ((TpArcData) tpPnt9D4).P9.Y, ((TpArcData) tpPnt9D4).P9.Z));
          num3 = num4;
        }
        double num6 = buCall.\u0001.PointAngle(F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 1]), F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 2]));
        if (flag)
          num6 -= 180.0;
        double num7 = num6 - num3;
        if (Math.Abs(num7) > 180.0)
        {
          if (num7 > 0.0)
            num6 -= 360.0;
          else
            num6 += 360.0;
        }
        if (((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseContantAngle)
          num6 = ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).ConstantAngle;
        if (index1 == PLL3D.Count - 1)
        {
          double Length2 = ((buMarbleForms) sawCalcParameters).SafeDistanceXY;
          if (((RoboticSettings) sawCalcParameters).LeadOutDistance > 0.0)
            Length2 = ((RoboticSettings) sawCalcParameters).LeadOutDistance;
          if (clockDirectionType == ClockDirectionType.CW)
          {
            EndPnt = new Point3D();
            buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 1]), Length2, num6 - 90.0, ref EndPnt);
          }
          else
          {
            EndPnt = new Point3D();
            buCall.\u0001.LineWithLengthAndAngle(F_NotchEdit.ToPoint3D(point3DList2[point3DList2.Count - 1]), ((buMarbleForms) sawCalcParameters).SafeDistanceXY, num6 - 90.0, ref EndPnt);
          }
          Pnt6D pnt6D6 = new Pnt6D(EndPnt.X, EndPnt.Y, EndPnt.Z);
          pnt6D6.A = 90.0;
          pnt6D6.C = num6;
          ((marbleSawMillingPars) this).CalculatePointsWithKinematic(pnt6D6, activeKinematic, ((MarbleMachineOptionsSettings) marbleCam).ToolSelected, ref calcPoint);
          TpPnt9D tpPnt9D5 = !((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters).UseKinematic ? new TpPnt9D(pnt6D6, 100.0, 0) : new TpPnt9D(calcPoint, 100.0, 0);
          tpPnt9D5.PreCodes.Add((object) "G39 O1");
          tpPnt9D5.PreCodes.Add((object) "G50");
          if (((RoboticSettings) sawCalcParameters).UseLeadOut)
            camTpPoint.Points.Add(tpPnt9D5);
        }
        pnt6D1 = new Pnt6D(calcPoint);
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) point3DList2);
        linearPath.Color = ((MarbleCountertopModes) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).settingSawMilling).SawMillingCamColor;
        linearPath.ColorMethod = colorMethodType.byEntity;
        ((MarbleMachineOptionsSettings) marbleCam).CamBase.EntitiesG1.Add((Entity) linearPath);
        ((MarbleMachineOptionsSettings) marbleCam).CamBase.CamPoints.Add(camTpPoint);
        ++num1;
      }
      if (((MarbleMachineOptionsSettings) marbleCam).CamBase == null)
        return;
      ((MarbleMachineOptionsSettings) marbleCam).CamBase.TypeCam = CamType.SawCut;
    }
    catch (Exception ex)
    {
    }
  }
}
