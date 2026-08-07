// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopCavityPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopCavityPars : buSerilization5
{
  public bool isA45First;
  public bool InsideCutSizeFromTop;
  public bool CommonPathCalculation;
  public double CommonPathGapDistance;
  public double OutsideContourLeadIn;
  public double OutsideContourLeadOut;
  public bool OutsideContourLeadInOutForArc;
  public double CutSawDistanceOverlap;
  public double InnerCutSafeDistance;

  public void AnalyzeImportEntities(ref List<buEntity> refEntities)
  {
    List<buEntity> copiedEntities = new List<buEntity>();
    buRadialDim.Copy(refEntities, ref copiedEntities);
    refEntities.Clear();
    for (int index1 = 0; index1 <= copiedEntities.Count - 1; ++index1)
    {
      if (copiedEntities[index1] is buLinearPath)
      {
        for (int index2 = 1; index2 <= ((CustomDataSurrogate) copiedEntities[index1]).Vertices.Count - 1; ++index2)
        {
          buLine buLine = (buLine) new buMultilineText(((CustomDataSurrogate) copiedEntities[index1]).Vertices[index2 - 1], ((CustomDataSurrogate) copiedEntities[index1]).Vertices[index2]);
          refEntities.Add((buEntity) buLine);
        }
      }
      else if (copiedEntities[index1] is buCompositeCurve)
      {
        buCompositeCurve buCompositeCurve = copiedEntities[index1] as buCompositeCurve;
        for (int index3 = 0; index3 <= ((CustomDataSurrogate) buCompositeCurve).CurveList.Count - 1; ++index3)
        {
          buEntity copiedEntity = (buEntity) null;
          buDiametricDim.Copy(((CustomDataSurrogate) buCompositeCurve).CurveList[index3], ref copiedEntity);
          refEntities.Add(copiedEntity);
        }
      }
      else if (copiedEntities[index1] is buLine | copiedEntities[index1] is buArc | copiedEntities[index1] is buCircle | copiedEntities[index1] is buEllipse | copiedEntities[index1] is buCurve)
        refEntities.Add(buAngularDim.Copy(copiedEntities[index1]));
    }
  }

  public void DevideProfileCutPoints(
    List<Point3D> refPoints,
    double MinZ,
    double DevideLength,
    double VerticalDevideLength,
    bool isCurveProfilie,
    bool isRough,
    ref List<Point3D> devidedPoints)
  {
    bool flag = false;
    Point3D point3D1 = new Point3D();
    for (int index = 0; index <= refPoints.Count - 1; ++index)
    {
      if (refPoints[index].Z < MinZ & flag)
      {
        double num1 = MinZ - refPoints[index].Z;
        Point3D point3D2 = new Point3D();
        Point3D point3D3 = num1 <= 0.1 ? new Point3D(refPoints[index].X, refPoints[index].Y, refPoints[index].Z) : new Point3D(refPoints[index].X, refPoints[index].Y, MinZ);
        if (Point3D.Distance(point3D1, point3D3) > DevideLength)
        {
          double num2 = buCall.\u0001.PointAngle(point3D3, point3D1, Plane.YZ);
          if (buConversion5.EQ(num2, 90.0, 0.5) | buConversion5.EQ(num2, 270.0, 0.5))
          {
            List<Point3D> PointsDevided = new List<Point3D>();
            buCall.\u0001.DevideLinePointsByLength(point3D1, point3D3, VerticalDevideLength, ref PointsDevided);
            PointsDevided.RemoveAt(0);
            devidedPoints.AddRange((IEnumerable<Point3D>) PointsDevided);
            point3D1 = F_NotchEdit.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
            if ((index == 0 | index == 1) & isRough)
              devidedPoints.Reverse();
          }
          else
          {
            List<Point3D> PointsDevided = new List<Point3D>();
            buCall.\u0001.DevideLinePointsByLength(point3D1, point3D3, DevideLength, ref PointsDevided);
            PointsDevided.RemoveAt(0);
            devidedPoints.AddRange((IEnumerable<Point3D>) PointsDevided);
            point3D1 = F_NotchEdit.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
          }
        }
        else
        {
          devidedPoints.Add(F_NotchEdit.ToPoint3D(point3D3));
          point3D1 = F_NotchEdit.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
        }
        flag = false;
      }
      if (refPoints[index].Z > MinZ & !flag)
      {
        if (refPoints[index].Z - MinZ > 0.1 & !isCurveProfilie && devidedPoints.Count == 0)
        {
          devidedPoints.Add(new Point3D(refPoints[index].X, refPoints[index].Y, MinZ));
          point3D1 = F_NotchEdit.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
        }
        flag = true;
      }
      if (flag)
      {
        if (devidedPoints.Count == 0)
        {
          devidedPoints.Add(F_NotchEdit.ToPoint3D(refPoints[index]));
          point3D1 = F_NotchEdit.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
        }
        else if (Point3D.Distance(point3D1, refPoints[index]) > DevideLength)
        {
          double num = buCall.\u0001.PointAngle(refPoints[index], point3D1, Plane.YZ);
          if (buConversion5.EQ(num, 90.0, 0.5) | buConversion5.EQ(num, 270.0, 0.5))
          {
            List<Point3D> PointsDevided = new List<Point3D>();
            buCall.\u0001.DevideLinePointsByLength(point3D1, refPoints[index], VerticalDevideLength, ref PointsDevided);
            PointsDevided.RemoveAt(0);
            devidedPoints.AddRange((IEnumerable<Point3D>) PointsDevided);
            point3D1 = F_NotchEdit.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
            if ((index == 0 | index == 1) & isRough)
              devidedPoints.Reverse();
          }
          else
          {
            List<Point3D> PointsDevided = new List<Point3D>();
            buCall.\u0001.DevideLinePointsByLength(point3D1, refPoints[index], DevideLength, ref PointsDevided);
            PointsDevided.RemoveAt(0);
            devidedPoints.AddRange((IEnumerable<Point3D>) PointsDevided);
            point3D1 = F_NotchEdit.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
          }
        }
        else
        {
          devidedPoints.Add(F_NotchEdit.ToPoint3D(refPoints[index]));
          point3D1 = F_NotchEdit.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
        }
      }
    }
  }

  public void MoveItem(ref MarbleItem Item, double dX, double dY, double dZ)
  {
    ((MarbleScreenCaptureSettings) Item).BasePoint.X = ((MarbleScreenCaptureSettings) Item).BasePoint.X + dX;
    ((MarbleScreenCaptureSettings) Item).BasePoint.Y = ((MarbleScreenCaptureSettings) Item).BasePoint.Y + dY;
    ((MarbleScreenCaptureSettings) Item).BasePoint.Z = ((MarbleScreenCaptureSettings) Item).BasePoint.Z + dZ;
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity.Count - 1; ++index)
        ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity[index].Translate(dX, dY, dZ);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities[index]).Translate(dX, dY, dZ);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities[index]).Translate(dX, dY, dZ);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities != null)
    {
      for (int index1 = 0; index1 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1].Count - 1; ++index2)
          ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1][index2]).Translate(dX, dY, dZ);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities[index]).Translate(dX, dY, dZ);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities[index]).Translate(dX, dY, dZ);
    }
    if (((MarbleScreenCaptureSettings) Item).EntGroup != null)
    {
      ((MarbleScreenCaptureSettings) Item).EntGroup.Translate(dX, dY, dZ);
      if ((((MarbleScreenCaptureSettings) Item).EntGroup.Outside == null || ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities.Count <= 0 ? 0 : (((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter != (Point3D) null ? 1 : 0)) != 0)
      {
        ((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter.X = ((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter.X + dX;
        ((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter.Y = ((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter.Y + dY;
        ((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter.Z = ((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter.Z + dZ;
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities != null)
    {
      for (int index3 = 0; index3 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities[index3].Count - 1; ++index4)
          ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities[index3][index4]).Translate(dX, dY, dZ);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities != null)
    {
      for (int index5 = 0; index5 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities.Count - 1; ++index5)
      {
        for (int index6 = 0; index6 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities[index5].Count - 1; ++index6)
          ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities[index5][index6]).Translate(dX, dY, dZ);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities[index]).Translate(dX, dY, dZ);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities[index]).Translate(dX, dY, dZ);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities[index]).Translate(dX, dY, dZ);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities[index]).Translate(dX, dY, dZ);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities[index]).Translate(dX, dY, dZ);
    }
    for (int index = 0; index <= ((MarbleScreenCaptureSettings) Item).Edges.Count - 1; ++index)
    {
      ((buLinearDim) ((MarbleSliceType) ((MarbleScreenCaptureSettings) Item).Edges[index]).refEntity).Translate(dX, dY, dZ);
      ((buLinearDim) ((MarbleSliceType) ((MarbleScreenCaptureSettings) Item).Edges[index]).drawEntity).Translate(dX, dY, dZ);
      if (((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid != null)
        ((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid.Translate(dX, dY, dZ);
    }
    for (int index7 = 0; index7 <= ((MarbleScreenCaptureSettings) Item).Collapses.Count - 1; ++index7)
    {
      if (((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).entSolid != null)
        ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).entSolid.Translate(dX, dY, dZ);
      if (((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).refEntity != null)
      {
        for (int index8 = 0; index8 <= ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).refEntity.Count - 1; ++index8)
          ((buLinearDim) ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).refEntity[index8]).Translate(dX, dY, dZ);
      }
      if (((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).ContourEntity != null)
      {
        for (int index9 = 0; index9 <= ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).ContourEntity.Count - 1; ++index9)
          ((buLinearDim) ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).ContourEntity[index9]).Translate(dX, dY, dZ);
      }
    }
    if ((((MarbleScreenCaptureSettings) Item).CamList == null ? 0 : (((MarbleScreenCaptureSettings) Item).CamList.Count > 0 ? 1 : 0)) != 0)
    {
      for (int index10 = 0; index10 <= ((MarbleScreenCaptureSettings) Item).CamList.Count - 1; ++index10)
      {
        ((MarbleScreenCaptureSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).isCamCalculated = false;
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase != null)
        {
          for (int index11 = 0; index11 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesG0.Count - 1; ++index11)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesG0[index11].Translate(dX, dY, dZ);
          for (int index12 = 0; index12 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesG1.Count - 1; ++index12)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesG1[index12].Translate(dX, dY, dZ);
          for (int index13 = 0; index13 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeave.Count - 1; ++index13)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeave[index13].Translate(dX, dY, dZ);
          for (int index14 = 0; index14 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesPlunge.Count - 1; ++index14)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesPlunge[index14].Translate(dX, dY, dZ);
          for (int index15 = 0; index15 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeadIn.Count - 1; ++index15)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeadIn[index15].Translate(dX, dY, dZ);
          for (int index16 = 0; index16 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeadOut.Count - 1; ++index16)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeadOut[index16].Translate(dX, dY, dZ);
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireEntities != null)
        {
          for (int index17 = 0; index17 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireEntities.Count - 1; ++index17)
          {
            for (int index18 = 0; index18 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireEntities[index17].Count - 1; ++index18)
              ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireEntities[index17][index18]).Translate(dX, dY, dZ);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList != null)
        {
          ((buArcCam) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).Translate(dX, dY, dZ);
          if ((((\u0084.\u0001) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).Entities == null || ((\u0084.\u0001) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).Entities.Count <= 0 ? 0 : (((IntersectNode) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).pntMassCenter != (Point3D) null ? 1 : 0)) != 0)
          {
            ((IntersectNode) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).pntMassCenter.X = ((IntersectNode) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).pntMassCenter.X + dX;
            ((IntersectNode) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).pntMassCenter.Y = ((IntersectNode) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).pntMassCenter.Y + dY;
            ((IntersectNode) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).pntMassCenter.Z = ((IntersectNode) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).pntMassCenter.Z + dZ;
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireAuxEntities != null)
        {
          for (int index19 = 0; index19 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireAuxEntities.Count - 1; ++index19)
          {
            for (int index20 = 0; index20 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireAuxEntities[index19].Count - 1; ++index20)
              ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireAuxEntities[index19][index20]).Translate(dX, dY, dZ);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConcaveEntities != null)
        {
          for (int index21 = 0; index21 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConcaveEntities.Count - 1; ++index21)
          {
            for (int index22 = 0; index22 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConcaveEntities[index21].Count - 1; ++index22)
              ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConcaveEntities[index21][index22]).Translate(dX, dY, dZ);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConvexEntities != null)
        {
          for (int index23 = 0; index23 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConvexEntities.Count - 1; ++index23)
          {
            for (int index24 = 0; index24 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConvexEntities[index23].Count - 1; ++index24)
              ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConvexEntities[index23][index24]).Translate(dX, dY, dZ);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).DrillEntities != null)
        {
          for (int index25 = 0; index25 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).DrillEntities.Count - 1; ++index25)
            ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).DrillEntities[index25]).Translate(dX, dY, dZ);
        }
      }
    }
    ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint.X = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint.X + dX;
    ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint.Y = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint.Y + dY;
    ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint.X = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint.X + dX;
    ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint.Y = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint.Y + dY;
    ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.X = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.X + dX;
    ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.Y = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint.Y + dY;
  }

  public void RotateItem(ref MarbleItem Item, double Rotation, Point3D pointRotate)
  {
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity.Count - 1; ++index)
        ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity[index].Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities[index]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities[index]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities != null)
    {
      for (int index1 = 0; index1 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1].Count - 1; ++index2)
          ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1][index2]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities[index]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities[index]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    if (((MarbleScreenCaptureSettings) Item).EntGroup != null)
    {
      ((MarbleScreenCaptureSettings) Item).EntGroup.Rotate(Rotation, Vector3D.AxisZ, pointRotate);
      if ((((MarbleScreenCaptureSettings) Item).EntGroup.Outside == null || ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities.Count <= 0 ? 0 : (((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter != (Point3D) null ? 1 : 0)) != 0)
        buCall.\u0001.Rotate(pointRotate, Rotation, Plane.XY, ref ((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities != null)
    {
      for (int index3 = 0; index3 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities[index3].Count - 1; ++index4)
          ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities[index3][index4]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities != null)
    {
      for (int index5 = 0; index5 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities.Count - 1; ++index5)
      {
        for (int index6 = 0; index6 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities[index5].Count - 1; ++index6)
          ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities[index5][index6]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities[index]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities[index]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities[index]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities[index]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities.Count - 1; ++index)
        ((buLinearDim) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities[index]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    for (int index = 0; index <= ((MarbleScreenCaptureSettings) Item).Edges.Count - 1; ++index)
    {
      ((buLinearDim) ((MarbleSliceType) ((MarbleScreenCaptureSettings) Item).Edges[index]).refEntity).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
      ((buLinearDim) ((MarbleSliceType) ((MarbleScreenCaptureSettings) Item).Edges[index]).drawEntity).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
      if (((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid != null)
        ((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid.Rotate(Rotation, Vector3D.AxisZ, pointRotate);
    }
    for (int index7 = 0; index7 <= ((MarbleScreenCaptureSettings) Item).Collapses.Count - 1; ++index7)
    {
      if (((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).entSolid != null)
        ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).entSolid.Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
      if (((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).refEntity != null)
      {
        for (int index8 = 0; index8 <= ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).refEntity.Count - 1; ++index8)
          ((buLinearDim) ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).refEntity[index8]).Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
      }
      if (((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).ContourEntity != null)
      {
        for (int index9 = 0; index9 <= ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).ContourEntity.Count - 1; ++index9)
          ((buLinearDim) ((MarbleItemType) ((MarbleScreenCaptureSettings) Item).Collapses[index7]).ContourEntity[index9]).Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
      }
    }
    if ((((MarbleScreenCaptureSettings) Item).CamList == null ? 0 : (((MarbleScreenCaptureSettings) Item).CamList.Count > 0 ? 1 : 0)) != 0)
    {
      for (int index10 = 0; index10 <= ((MarbleScreenCaptureSettings) Item).CamList.Count - 1; ++index10)
      {
        ((MarbleScreenCaptureSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).isCamCalculated = false;
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase != null)
        {
          for (int index11 = 0; index11 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesG0.Count - 1; ++index11)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesG0[index11].Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
          for (int index12 = 0; index12 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesG1.Count - 1; ++index12)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesG1[index12].Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
          for (int index13 = 0; index13 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeave.Count - 1; ++index13)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeave[index13].Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
          for (int index14 = 0; index14 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesPlunge.Count - 1; ++index14)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesPlunge[index14].Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
          for (int index15 = 0; index15 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeadIn.Count - 1; ++index15)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeadIn[index15].Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
          for (int index16 = 0; index16 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeadOut.Count - 1; ++index16)
            ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).CamBase.EntitiesLeadOut[index16].Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireEntities != null)
        {
          for (int index17 = 0; index17 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireEntities.Count - 1; ++index17)
          {
            for (int index18 = 0; index18 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireEntities[index17].Count - 1; ++index18)
              ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireEntities[index17][index18]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList != null)
        {
          ((buArcCam) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
          if ((((\u0084.\u0001) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).Entities == null || ((\u0084.\u0001) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).Entities.Count <= 0 ? 0 : (((IntersectNode) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).pntMassCenter != (Point3D) null ? 1 : 0)) != 0)
            buCall.\u0001.Rotate(pointRotate, Rotation, Plane.XY, ref ((IntersectNode) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).EntityList).pntMassCenter);
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireAuxEntities != null)
        {
          for (int index19 = 0; index19 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireAuxEntities.Count - 1; ++index19)
          {
            for (int index20 = 0; index20 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireAuxEntities[index19].Count - 1; ++index20)
              ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).WireAuxEntities[index19][index20]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConcaveEntities != null)
        {
          for (int index21 = 0; index21 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConcaveEntities.Count - 1; ++index21)
          {
            for (int index22 = 0; index22 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConcaveEntities[index21].Count - 1; ++index22)
              ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConcaveEntities[index21][index22]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConvexEntities != null)
        {
          for (int index23 = 0; index23 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConvexEntities.Count - 1; ++index23)
          {
            for (int index24 = 0; index24 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConvexEntities[index23].Count - 1; ++index24)
              ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).ConvexEntities[index23][index24]).Rotate(Rotation, Vector3D.AxisZ, pointRotate);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).DrillEntities != null)
        {
          for (int index25 = 0; index25 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).DrillEntities.Count - 1; ++index25)
            ((buLinearDim) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index10]).DrillEntities[index25]).Rotate(buString5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
        }
      }
    }
    ((marbleMaterialPars) this).ItemSizeCalculation(ref Item);
  }
}
