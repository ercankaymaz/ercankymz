// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopTapData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buCore;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopTapData : buSerilization5
{
  public int UndoLimit;
  public static List<string> Captions;
  public static List<string> CaptionsUnits;
  public static byte f004CB5;
  public camParameters5 CamPar;
  public marbleOperation Operation;
  public marbleCamParameters CamMarblePar;
  public List<List<buEntity>> ReCalcEntities;
  public List<List<buEntity>> ReCalcAfterEntities;
  public List<List<Pnt6D>> CalculatedPnt6D;
  public int CamIndex;

  public void MarbleItemHeightByDirection(
    CamCuttingDirectionType CutDir,
    HeightStepCalculationType StepType,
    double ForwardStep,
    double BackwardStep,
    double StartZ,
    double EndZ,
    Point3D StartPoint,
    Point3D EndPoint,
    ref List<Point3D> CalcPoints)
  {
    try
    {
      List<double> doubleList = new List<double>();
      CalcPoints.Clear();
      if (CutDir == CamCuttingDirectionType.Forward)
      {
        buCall.\u0001.StepLengthCalculation(StepType, ForwardStep, StartZ, EndZ, ref doubleList);
        for (int index = 0; index <= doubleList.Count - 1; ++index)
        {
          Point3D CalcPoint = new Point3D();
          buCall.\u0001.XYFromZ(StartPoint, EndPoint, doubleList[index], ref CalcPoint);
          CalcPoints.Add(CalcPoint);
        }
      }
      if (CutDir == CamCuttingDirectionType.Backward)
      {
        buCall.\u0001.StepLengthCalculation(StepType, BackwardStep, StartZ, EndZ, ref doubleList);
        for (int index = 0; index <= doubleList.Count - 1; ++index)
        {
          Point3D CalcPoint = new Point3D();
          buCall.\u0001.XYFromZ(StartPoint, EndPoint, doubleList[index], ref CalcPoint);
          CalcPoints.Add(CalcPoint);
        }
      }
      if (CutDir != CamCuttingDirectionType.ForwardBackward)
        return;
      buCall.\u0001.StepLengthCalculation(StepType, ForwardStep + BackwardStep, StartZ, EndZ, ref doubleList);
      List<double> SourceList = new List<double>();
      double num1 = StartZ;
      for (int index = 0; index <= doubleList.Count - 1; ++index)
      {
        double num2 = num1 - doubleList[index];
        double num3 = BackwardStep / num2;
        if (num2 >= ForwardStep + BackwardStep)
        {
          SourceList.Add(num2 * num3 + doubleList[index]);
          SourceList.Add(doubleList[index]);
        }
        else
          SourceList.Add(doubleList[index]);
        num1 = doubleList[index];
      }
      buGeneral.CopyLists(SourceList, ref doubleList);
      for (int index = 0; index <= doubleList.Count - 1; ++index)
      {
        Point3D CalcPoint = new Point3D();
        buCall.\u0001.XYFromZ(StartPoint, EndPoint, doubleList[index], ref CalcPoint);
        CalcPoints.Add(CalcPoint);
      }
    }
    catch (Exception ex)
    {
      string str = $"CutDir: {CutDir.ToString()} - StepType: {StepType.ToString()} - ForwardStep: {ForwardStep.ToString()} - BackwardStep: {BackwardStep.ToString()} - StepStartZ: {StartZ.ToString()} - EndZ: {EndZ.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void calcProfileVectors(
    List<List<Point3D>> refPoints,
    VectorType Direction,
    ToolBase5 Tool,
    bool MaxToMinDirection,
    marbleProfileCutPars varProfileCut,
    ref List<Point3D> calcProfilePoints)
  {
    double num1 = -1.0;
    Point3D point3D1 = new Point3D();
    calcProfilePoints.Clear();
    calcProfilePoints = new List<Point3D>();
    List<Point3D> point3DList = new List<Point3D>();
    for (int index1 = 0; index1 <= refPoints.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= refPoints[index1].Count - 1; ++index2)
      {
        bool flag = false;
        Point3D SecondLineStart = F_NotchEdit.ToPoint3D(refPoints[index1][index2]);
        Point3D SecondLineEnd = new Point3D();
        Point3D point3D2 = new Point3D();
        Point3D point3D3 = new Point3D();
        Point3D point3D4 = F_NotchEdit.ToPoint3D(refPoints[index1][index2]);
        double num2 = 0.0;
        double num3 = -1.0;
        if (index2 == 40)
          ;
        if (index2 == 0)
        {
          if (Direction == VectorType.XVector)
          {
            num2 = buCall.\u0001.PointAngle(refPoints[index1][index2 + 1], refPoints[index1][index2], Plane.YZ);
            if (index2 < refPoints[index1].Count - 2)
              num3 = buCall.\u0001.PointAngle(refPoints[index1][index2 + 2], refPoints[index1][index2 + 1], Plane.YZ);
          }
          if (Direction == VectorType.YVector)
          {
            num2 = buCall.\u0001.PointAngle(refPoints[index1][index2 + 1], refPoints[index1][index2], Plane.XZ);
            if (index2 < refPoints[index1].Count - 2)
              num3 = buCall.\u0001.PointAngle(refPoints[index1][index2 + 2], refPoints[index1][index2 + 1], Plane.XZ);
          }
        }
        else
        {
          if (Direction == VectorType.XVector)
          {
            num2 = buCall.\u0001.PointAngle(refPoints[index1][index2], refPoints[index1][index2 - 1], Plane.YZ);
            if (index2 < refPoints[index1].Count - 1)
              num3 = buCall.\u0001.PointAngle(refPoints[index1][index2 + 1], refPoints[index1][index2], Plane.YZ);
          }
          if (Direction == VectorType.YVector)
          {
            num2 = buCall.\u0001.PointAngle(refPoints[index1][index2], refPoints[index1][index2 - 1], Plane.XZ);
            if (index2 < refPoints[index1].Count - 1)
              num3 = buCall.\u0001.PointAngle(refPoints[index1][index2 + 1], refPoints[index1][index2], Plane.XZ);
          }
        }
        double num4 = Math.Round(num2, 3);
        double num5 = Math.Round(num3, 3);
        if (index2 < refPoints[index1].Count - 1)
          point3D3 = F_NotchEdit.ToPoint3D(refPoints[index1][index2 + 1]);
        if (((MarbleSawCalcParameters) varProfileCut).CamTypeFinish == CamAxisCountType.Axis3)
        {
          if (Direction == VectorType.XVector && !MaxToMinDirection)
          {
            if (num4 > 180.0 & num1 < 180.0 & num1 > 0.0 & calcProfilePoints.Count > 0 & index2 < refPoints[index1].Count - 1)
              ;
            SecondLineStart = num4 >= 180.0 ? new Point3D(point3D4.X, point3D4.Y + ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D4.Z) : new Point3D(point3D4.X, point3D4.Y - ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D4.Z);
            SecondLineEnd = num5 >= 180.0 ? new Point3D(point3D3.X, point3D3.Y + ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D3.Z) : new Point3D(point3D3.X, point3D3.Y - ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D3.Z);
            if (num4 <= 180.0 & (num1 > 180.0 | num1 == 0.0) & num4 != num1 & Math.Abs(num4 - num1) < 360.0 & num1 >= 0.0 & calcProfilePoints.Count > 0 & index2 < refPoints[index1].Count - 1)
            {
              Point3D pntIntersect = new Point3D();
              buCall.\u0001.LineLineIntersection(calcProfilePoints[calcProfilePoints.Count - 2], calcProfilePoints[calcProfilePoints.Count - 1], SecondLineStart, SecondLineEnd, Plane.YZ, ref pntIntersect);
              if (buFile5.IsNumeric(pntIntersect.Y.ToString()))
              {
                for (int index3 = 0; index3 <= calcProfilePoints.Count - 1; ++index3)
                {
                  if (calcProfilePoints[index3].Y > pntIntersect.Y)
                  {
                    calcProfilePoints.RemoveRange(index3, calcProfilePoints.Count - index3);
                    index3 = calcProfilePoints.Count;
                  }
                }
                calcProfilePoints.Add(F_NotchEdit.ToPoint3D(pntIntersect));
              }
            }
          }
          if (Direction == VectorType.XVector && MaxToMinDirection)
          {
            if (num4 < 180.0 & num1 > 180.0 & num1 > 0.0 & calcProfilePoints.Count > 0 & index2 < refPoints[index1].Count - 1)
              ;
            if (buConversion5.EQ(num4, 180.0, 0.1))
              SecondLineStart = new Point3D(point3D4.X, point3D4.Y, point3D4.Z);
            else if (num4 < 180.0)
              SecondLineStart = new Point3D(point3D4.X, point3D4.Y + ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D4.Z);
            else if (num4 > 180.0)
              SecondLineStart = new Point3D(point3D4.X, point3D4.Y - ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D4.Z);
            if (buConversion5.EQ(num5, 180.0, 0.1))
              SecondLineEnd = new Point3D(point3D3.X, point3D3.Y, point3D3.Z);
            else if (num5 < 180.0)
              SecondLineEnd = new Point3D(point3D3.X, point3D3.Y + ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D3.Z);
            else if (num5 > 180.0)
              SecondLineEnd = new Point3D(point3D3.X, point3D3.Y - ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D3.Z);
            if (num4 <= 180.0 & (num1 >= 180.0 | num1 == 0.0) & num4 != num1 & num1 >= 0.0 & calcProfilePoints.Count > 0 & index2 < refPoints[index1].Count - 1)
            {
              Point3D pntIntersect = new Point3D();
              buCall.\u0001.LineLineIntersection(calcProfilePoints[calcProfilePoints.Count - 2], calcProfilePoints[calcProfilePoints.Count - 1], SecondLineStart, SecondLineEnd, Plane.YZ, ref pntIntersect);
              if (buFile5.IsNumeric(pntIntersect.Y.ToString()))
              {
                for (int index4 = 0; index4 <= calcProfilePoints.Count - 1; ++index4)
                {
                  if (calcProfilePoints[index4].Y < pntIntersect.Y)
                  {
                    calcProfilePoints.RemoveRange(index4, calcProfilePoints.Count - index4);
                    index4 = calcProfilePoints.Count;
                  }
                }
                calcProfilePoints.Add(F_NotchEdit.ToPoint3D(pntIntersect));
              }
            }
          }
          if (Direction == VectorType.YVector && MaxToMinDirection)
          {
            if (num4 < 180.0 & num1 > 180.0 & num1 > 0.0 & calcProfilePoints.Count > 0 & index2 < refPoints[index1].Count - 1)
              ;
            if (buConversion5.EQ(num4, 180.0, 0.1))
              SecondLineStart = new Point3D(point3D4.X, point3D4.Y, point3D4.Z);
            else if (num4 < 180.0)
              SecondLineStart = new Point3D(point3D4.X + ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D4.Y, point3D4.Z);
            else if (num4 > 180.0)
              SecondLineStart = new Point3D(point3D4.X, point3D4.Y - ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D4.Z);
            if (buConversion5.EQ(num5, 180.0, 0.1))
              SecondLineEnd = new Point3D(point3D3.X, point3D3.Y, point3D3.Z);
            else if (num5 < 180.0)
              SecondLineEnd = new Point3D(point3D3.X, point3D3.Y + ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D3.Z);
            else if (num5 > 180.0)
              SecondLineEnd = new Point3D(point3D3.X, point3D3.Y - ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, point3D3.Z);
            if (num4 <= 180.0 & (num1 >= 180.0 | num1 == 0.0) & num4 != num1 & num1 >= 0.0 & calcProfilePoints.Count > 0 & index2 < refPoints[index1].Count - 1)
            {
              Point3D pntIntersect = new Point3D();
              buCall.\u0001.LineLineIntersection(calcProfilePoints[calcProfilePoints.Count - 2], calcProfilePoints[calcProfilePoints.Count - 1], SecondLineStart, SecondLineEnd, Plane.YZ, ref pntIntersect);
              if (buFile5.IsNumeric(pntIntersect.Y.ToString()))
              {
                for (int index5 = 0; index5 <= calcProfilePoints.Count - 1; ++index5)
                {
                  if (calcProfilePoints[index5].Y < pntIntersect.Y)
                  {
                    calcProfilePoints.RemoveRange(index5, calcProfilePoints.Count - index5);
                    index5 = calcProfilePoints.Count;
                  }
                }
                calcProfilePoints.Add(F_NotchEdit.ToPoint3D(pntIntersect));
              }
            }
          }
        }
        num1 = num4;
        if (flag)
          calcProfilePoints.Add(new Point3D(point3D2.X, point3D2.Y, point3D2.Z));
        if (((MarbleSawCalcParameters) varProfileCut).CamTypeFinish == CamAxisCountType.Axis3)
        {
          if (calcProfilePoints.Count == 0)
            calcProfilePoints.Add(new Point3D(SecondLineStart.X, SecondLineStart.Y, SecondLineStart.Z));
          else if (Direction == VectorType.XVector)
          {
            if (!MaxToMinDirection)
            {
              if (SecondLineStart.Y >= calcProfilePoints[calcProfilePoints.Count - 1].Y | buConversion5.EQ(SecondLineStart.Y, calcProfilePoints[calcProfilePoints.Count - 1].Y))
                calcProfilePoints.Add(new Point3D(SecondLineStart.X, SecondLineStart.Y, SecondLineStart.Z));
            }
            else if (SecondLineStart.Y <= calcProfilePoints[calcProfilePoints.Count - 1].Y | buConversion5.EQ(SecondLineStart.Y, calcProfilePoints[calcProfilePoints.Count - 1].Y))
              calcProfilePoints.Add(new Point3D(SecondLineStart.X, SecondLineStart.Y, SecondLineStart.Z));
          }
        }
        F_NotchEdit.ToPoint3D(refPoints[index1][index2]);
      }
    }
  }

  public void calcAnalayseGeometryForProfileCut(
    List<buEntity> entSorted,
    ToolBase5 Tool,
    bool MaxToMinDirection,
    Plane entPlane,
    double FinishResolutionLen,
    double RoughtResolutionLen,
    double DownResolutionLen,
    ref List<List<Point3D>> reCalcRoughPoints,
    ref List<List<Point3D>> reCalcSmoothPoints)
  {
    ClockDirectionType clockDirectionType1 = ClockDirectionType.CCW;
    reCalcRoughPoints.Clear();
    reCalcSmoothPoints.Clear();
    for (int index1 = 0; index1 <= entSorted.Count - 1; ++index1)
    {
      List<Point3D> Vertices = new List<Point3D>();
      ClockDirectionType clockDirectionType2 = ClockDirectionType.CCW;
      List<Point3D> Points1 = new List<Point3D>();
      List<Point3D> Points2 = new List<Point3D>();
      buEntity refEntity = (buEntity) new buMultilineText();
      buDiametricDim.Copy(entSorted[index1], ref refEntity);
      if (index1 <= entSorted.Count - 1)
      {
        int index2 = index1;
        if (index1 == entSorted.Count - 1)
          index2 = index1 - 1;
        if (entSorted.Count == 1)
          index2 = index1;
        List<Point3D> pts1 = new List<Point3D>();
        if (((CustomData) entSorted[index2]).sortDirection == entitySortDirection.Normal)
        {
          pts1.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) entSorted[index2]).Vertices[((CustomDataSurrogate) entSorted[index2]).Vertices.Count - 2]));
          pts1.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) entSorted[index2]).Vertices[((CustomDataSurrogate) entSorted[index2]).Vertices.Count - 1]));
          buVector5.Add(pts1, ref Vertices);
        }
        if (((CustomData) entSorted[index2]).sortDirection == entitySortDirection.Reverse)
        {
          pts1.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) entSorted[index2]).Vertices[1]));
          pts1.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) entSorted[index2]).Vertices[0]));
          buVector5.Add(pts1, ref Vertices);
        }
        List<Point3D> pts2 = new List<Point3D>();
        if (((CustomData) entSorted[index2 + 1]).sortDirection == entitySortDirection.Normal)
        {
          pts2.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) entSorted[index2 + 1]).Vertices[0]));
          pts2.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) entSorted[index2 + 1]).Vertices[1]));
          buVector5.Add(pts2, ref Vertices);
        }
        if (((CustomData) entSorted[index2 + 1]).sortDirection == entitySortDirection.Reverse)
        {
          pts2.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) entSorted[index2 + 1]).Vertices[((CustomDataSurrogate) entSorted[index2 + 1]).Vertices.Count - 1]));
          pts2.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) entSorted[index2 + 1]).Vertices[((CustomDataSurrogate) entSorted[index2 + 1]).Vertices.Count - 2]));
          buVector5.Add(pts2, ref Vertices);
        }
        ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Vertices);
        if (Vertices.Count >= 3)
        {
          Vertices.Add(F_NotchEdit.ToPoint3D(Vertices[0]));
          clockDirectionType2 = buCall.\u0001.GetClockDirection(Vertices);
        }
      }
      if (index1 == 0)
      {
        if (!MaxToMinDirection)
        {
          if (entSorted[index1].GetType() == typeof (buLine))
          {
            if (clockDirectionType2 == ClockDirectionType.CCW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.End, entPlane, ref refEntity);
            if (clockDirectionType2 == ClockDirectionType.CW)
              buDiametricDim.Copy(entSorted[index1], ref refEntity);
          }
          if (entSorted[index1].GetType() == typeof (buArc))
          {
            if (clockDirectionType2 == ClockDirectionType.CCW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.End, entPlane, ref refEntity);
            if (clockDirectionType2 == ClockDirectionType.CW)
              buDiametricDim.Copy(entSorted[index1], ref refEntity);
          }
        }
        else
        {
          if (entSorted[index1].GetType() == typeof (buLine))
          {
            if (clockDirectionType2 == ClockDirectionType.CW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.End, entPlane, ref refEntity);
            if (clockDirectionType2 == ClockDirectionType.CCW)
              buDiametricDim.Copy(entSorted[index1], ref refEntity);
          }
          if (entSorted[index1].GetType() == typeof (buArc))
          {
            if (clockDirectionType2 == ClockDirectionType.CW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.End, entPlane, ref refEntity);
            if (clockDirectionType2 == ClockDirectionType.CCW)
              buDiametricDim.Copy(entSorted[index1], ref refEntity);
          }
        }
      }
      if (index1 > 0 & index1 < entSorted.Count - 1)
      {
        if (!MaxToMinDirection)
        {
          if (entSorted[index1].GetType() == typeof (buLine))
          {
            if (clockDirectionType1 == ClockDirectionType.CCW & clockDirectionType2 == ClockDirectionType.CCW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.StartAndEnd, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CCW & clockDirectionType2 == ClockDirectionType.CW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.Start, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CW & clockDirectionType2 == ClockDirectionType.CCW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.End, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CW & clockDirectionType2 == ClockDirectionType.CW)
              buDiametricDim.Copy(entSorted[index1], ref refEntity);
          }
          if (entSorted[index1].GetType() == typeof (buArc))
          {
            if (clockDirectionType1 == ClockDirectionType.CCW & clockDirectionType2 == ClockDirectionType.CCW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.StartAndEnd, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CCW & clockDirectionType2 == ClockDirectionType.CW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.Start, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CW & clockDirectionType2 == ClockDirectionType.CCW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.End, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CW & clockDirectionType2 == ClockDirectionType.CW)
              buDiametricDim.Copy(entSorted[index1], ref refEntity);
          }
        }
        else
        {
          if (entSorted[index1].GetType() == typeof (buLine))
          {
            if (clockDirectionType1 == ClockDirectionType.CCW & clockDirectionType2 == ClockDirectionType.CCW)
              buDiametricDim.Copy(entSorted[index1], ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CCW & clockDirectionType2 == ClockDirectionType.CW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.End, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CW & clockDirectionType2 == ClockDirectionType.CCW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.Start, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CW & clockDirectionType2 == ClockDirectionType.CW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.StartAndEnd, entPlane, ref refEntity);
          }
          if (entSorted[index1].GetType() == typeof (buArc))
          {
            if (clockDirectionType1 == ClockDirectionType.CCW & clockDirectionType2 == ClockDirectionType.CCW)
              buDiametricDim.Copy(entSorted[index1], ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CCW & clockDirectionType2 == ClockDirectionType.CW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.End, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CW & clockDirectionType2 == ClockDirectionType.CCW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.Start, entPlane, ref refEntity);
            if (clockDirectionType1 == ClockDirectionType.CW & clockDirectionType2 == ClockDirectionType.CW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.StartAndEnd, entPlane, ref refEntity);
          }
        }
      }
      if (index1 == entSorted.Count - 1)
      {
        if (!MaxToMinDirection)
        {
          if (entSorted[index1].GetType() == typeof (buLine))
          {
            if (clockDirectionType2 == ClockDirectionType.CCW)
              buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.Start, entPlane, ref refEntity);
            if (clockDirectionType2 == ClockDirectionType.CW)
              buDiametricDim.Copy(entSorted[index1], ref refEntity);
          }
          if (entSorted[index1].GetType() == typeof (buArc))
            buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.Start, entPlane, ref refEntity);
        }
        else
        {
          if (clockDirectionType2 == ClockDirectionType.CW)
            buCall.\u0001.EntityUpdateByLengthUsingCamDirection(entSorted[index1], ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0, StartPointType.Start, entPlane, ref refEntity);
          if (clockDirectionType2 == ClockDirectionType.CCW)
            buDiametricDim.Copy(entSorted[index1], ref refEntity);
        }
      }
      if (refEntity is buLine)
      {
        double num = buCall.\u0001.PointAngle(((CustomData) refEntity).EndPoint, ((CustomData) refEntity).StartPoint);
        if (buConversion5.EQ(num, 90.0, 0.1) | buConversion5.EQ(num, 270.0, 0.1))
        {
          buCall.\u0001.EntitiesToPointsWithCamDirection(refEntity, DownResolutionLen, ref Points1);
          buCall.\u0001.EntitiesToPointsWithCamDirection(refEntity, DownResolutionLen, ref Points2);
        }
        else
        {
          buCall.\u0001.EntitiesToPointsWithCamDirection(refEntity, RoughtResolutionLen, ref Points1);
          buCall.\u0001.EntitiesToPointsWithCamDirection(refEntity, FinishResolutionLen, ref Points2);
        }
      }
      else
      {
        buCall.\u0001.EntitiesToPointsWithCamDirection(refEntity, RoughtResolutionLen, ref Points1);
        buCall.\u0001.EntitiesToPointsWithCamDirection(refEntity, FinishResolutionLen, ref Points2);
      }
      if (((CustomData) entSorted[index1]).sortDirection == entitySortDirection.Reverse)
      {
        Points1.Reverse();
        Points2.Reverse();
      }
      reCalcRoughPoints.Add(new List<Point3D>((IEnumerable<Point3D>) Points1));
      reCalcSmoothPoints.Add(new List<Point3D>((IEnumerable<Point3D>) Points2));
      clockDirectionType1 = clockDirectionType2;
    }
  }
}
