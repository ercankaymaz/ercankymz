// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MachineAxisInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MachineAxisInfo : buSerilization5
{
  public static byte f000986;
  internal static double \u0001;
  internal static double \u0002;

  public void LineerInterpolation(
    Pnt6DSimMove FirstPoint,
    Pnt6DSimMove SecondPoint,
    double dt,
    ref List<Pnt6DSimMove> CalculatedPoints)
  {
    try
    {
      Pnt6DSimMove pnt6DsimMove1 = (Pnt6DSimMove) new AlingmentPoints3D();
      int int32 = Convert.ToInt32(1.0 / dt);
      CalculatedPoints.Clear();
      for (int index = 0; index <= int32; ++index)
      {
        Pnt6DSimMove pnt6DsimMove2 = (Pnt6DSimMove) new AlingmentPoints3D();
        double num = (double) index * dt;
        ((MeshToSurfacePointsSettings) pnt6DsimMove2).X = ((MeshToSurfacePointsSettings) FirstPoint).X * (1.0 - num) + ((MeshToSurfacePointsSettings) SecondPoint).X * num;
        ((MeshToSurfacePointsSettings) pnt6DsimMove2).Y = ((MeshToSurfacePointsSettings) FirstPoint).Y * (1.0 - num) + ((MeshToSurfacePointsSettings) SecondPoint).Y * num;
        ((MeshToSurfacePointsSettings) pnt6DsimMove2).Z = ((MeshToSurfacePointsSettings) FirstPoint).Z * (1.0 - num) + ((MeshToSurfacePointsSettings) SecondPoint).Z * num;
        ((MeshToSurfacePointsSettings) pnt6DsimMove2).A = ((MeshToSurfacePointsSettings) FirstPoint).A * (1.0 - num) + ((MeshToSurfacePointsSettings) SecondPoint).A * num;
        ((MeshToSurfacePointsSettings) pnt6DsimMove2).B = ((MeshToSurfacePointsSettings) FirstPoint).B * (1.0 - num) + ((MeshToSurfacePointsSettings) SecondPoint).B * num;
        ((MeshToSurfacePointsSettings) pnt6DsimMove2).C = ((MeshToSurfacePointsSettings) FirstPoint).C * (1.0 - num) + ((MeshToSurfacePointsSettings) SecondPoint).C * num;
        ((MeshToSurfacePointsSettings) pnt6DsimMove2).FeedRate = ((MeshToSurfacePointsSettings) SecondPoint).FeedRate;
        ((MeshToSurfacePointsCalculations) pnt6DsimMove2).SpindleRpm = ((MeshToSurfacePointsCalculations) SecondPoint).SpindleRpm;
        ((MeshToSurfacePointsCalculations) pnt6DsimMove2).ToolNo = ((MeshToSurfacePointsCalculations) SecondPoint).ToolNo;
        ((MeshToSurfacePointsCalculations) pnt6DsimMove2).ToolName = ((MeshToSurfacePointsCalculations) SecondPoint).ToolName;
        ((MeshToSurfacePointsCalculations) pnt6DsimMove2).Aux1 = ((MeshToSurfacePointsCalculations) FirstPoint).Aux1;
        ((MeshToSurfacePointsCalculations) pnt6DsimMove2).Aux2 = ((MeshToSurfacePointsCalculations) FirstPoint).Aux2;
        ((MeshToSurfacePointsCalculations) pnt6DsimMove2).Index = ((MeshToSurfacePointsCalculations) SecondPoint).Index;
        if (index == 0)
          ((MeshToSurfacePointsCalculations) pnt6DsimMove2).GCode = ((MeshToSurfacePointsCalculations) FirstPoint).GCode;
        else
          ((MeshToSurfacePointsCalculations) pnt6DsimMove2).GCode = ((MeshToSurfacePointsCalculations) SecondPoint).GCode;
        if (index == int32)
        {
          ((MeshToSurfacePointsCalculations) pnt6DsimMove2).Aux1 = ((MeshToSurfacePointsCalculations) SecondPoint).Aux1;
          ((MeshToSurfacePointsCalculations) pnt6DsimMove2).Aux2 = ((MeshToSurfacePointsCalculations) SecondPoint).Aux2;
        }
        CalculatedPoints.Add(pnt6DsimMove2);
      }
    }
    catch (Exception ex)
    {
      string str = $"FP: {FirstPoint.ToString()} - SP: {SecondPoint.ToString()} - dt: {dt.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LineToLineer(
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    double Length,
    ref List<Pnt3D> Vertices)
  {
    try
    {
      double num = ((buVector5) this).Length3D(StartPoint, EndPoint);
      if (Length <= 0.0)
      {
        Vertices.Add(new Pnt3D(StartPoint));
        Vertices.Add(new Pnt3D(EndPoint));
      }
      else
      {
        int int32 = Convert.ToInt32(num / Length);
        Vertices.Clear();
        if (int32 <= 1)
        {
          Vertices.Add(new Pnt3D(StartPoint));
          Vertices.Add(new Pnt3D(EndPoint));
        }
        else
        {
          double dt = 1.0 / (double) int32;
          // ISSUE: reference to a compiler-generated method
          ((buVector5.\u0002) this).LineerInterpolation(StartPoint, EndPoint, dt, ref Vertices);
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"SP: {StartPoint.ToString()} - EP: {EndPoint.ToString()} - Len: {Length.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LineToLineer(
    Point3D StartPoint,
    Point3D EndPoint,
    double Length,
    ref List<Point3D> Vertices)
  {
    try
    {
      double num = ((buVector5) this).Length3D(StartPoint, EndPoint);
      if (Length <= 0.0)
      {
        Vertices.Add(F_NotchEdit.ToPoint3D(StartPoint));
        Vertices.Add(F_NotchEdit.ToPoint3D(EndPoint));
      }
      else
      {
        int int32 = Convert.ToInt32(num / Length);
        Vertices.Clear();
        if (int32 <= 1)
        {
          Vertices.Add(F_NotchEdit.ToPoint3D(StartPoint));
          Vertices.Add(F_NotchEdit.ToPoint3D(EndPoint));
        }
        else
        {
          double dt = 1.0 / (double) int32;
          // ISSUE: reference to a compiler-generated method
          ((buVector5.\u0002) this).LineerInterpolation(StartPoint, EndPoint, dt, ref Vertices);
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"SP: {StartPoint.ToString()} - EP: {EndPoint.ToString()} - Len: {Length.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LineToLineer(
    Pnt6D StartPoint,
    Pnt6D EndPoint,
    double Length,
    ref List<Pnt6D> Vertices)
  {
    try
    {
      double num = ((buVector5) this).Length3D(StartPoint, EndPoint);
      if (Length <= 0.0)
      {
        Vertices.Add(new Pnt6D(StartPoint));
        Vertices.Add(new Pnt6D(EndPoint));
      }
      else
      {
        int int32 = Convert.ToInt32(num / Length);
        Vertices.Clear();
        if (int32 <= 1)
        {
          Vertices.Add(new Pnt6D(StartPoint));
          Vertices.Add(new Pnt6D(EndPoint));
        }
        else
        {
          double dt = 1.0 / (double) int32;
          ((MachineGCodeConfigrasyon) this).LineerInterpolation(StartPoint, EndPoint, dt, ref Vertices);
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"SP: {StartPoint.ToString()} - EP: {EndPoint.ToString()} - Len: {Length.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }
}
