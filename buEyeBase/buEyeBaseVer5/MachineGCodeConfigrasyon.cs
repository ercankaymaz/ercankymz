// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MachineGCodeConfigrasyon
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MachineGCodeConfigrasyon : buSerilization5
{
  public static List<Color> ColorList50UnPopular;
  public static byte f00097E;
  private Bitmap \u0001;
  private IntPtr \u0001;
  private BitmapData \u0001;

  public void LineerInterpolation(
    Pnt6D FirstPoint,
    Pnt6D SecondPoint,
    int Count,
    ref List<Pnt6D> CalculatedPoints)
  {
    try
    {
      if (Count <= 1)
        return;
      double dt = 1.0 / Convert.ToDouble(Count);
      this.LineerInterpolation(FirstPoint, SecondPoint, dt, ref CalculatedPoints);
    }
    catch (Exception ex)
    {
      string str = $"FirstPoint: {FirstPoint.ToString()} - SecondPoint: {SecondPoint.ToString()} - Count: {Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LineerInterpolation(
    Pnt6D FirstPoint,
    Pnt6D SecondPoint,
    double dt,
    ref List<Pnt6D> CalculatedPoints)
  {
    try
    {
      Pnt6D pnt6D1 = new Pnt6D();
      int int32 = Convert.ToInt32(1.0 / dt);
      CalculatedPoints.Clear();
      for (int index = 0; index <= int32; ++index)
      {
        Pnt6D pnt6D2 = new Pnt6D();
        double num = (double) index * dt;
        pnt6D2.X = FirstPoint.X * (1.0 - num) + SecondPoint.X * num;
        pnt6D2.Y = FirstPoint.Y * (1.0 - num) + SecondPoint.Y * num;
        pnt6D2.Z = FirstPoint.Z * (1.0 - num) + SecondPoint.Z * num;
        pnt6D2.A = FirstPoint.A * (1.0 - num) + SecondPoint.A * num;
        pnt6D2.B = FirstPoint.B * (1.0 - num) + SecondPoint.B * num;
        pnt6D2.C = FirstPoint.C * (1.0 - num) + SecondPoint.C * num;
        CalculatedPoints.Add(pnt6D2);
      }
    }
    catch (Exception ex)
    {
      string str = $"FP: {FirstPoint.ToString()} - SP: {SecondPoint.ToString()} - dt: {dt.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LineerInterpolation(
    Pnt9D FirstPoint,
    Pnt9D SecondPoint,
    int Count,
    ref List<Pnt9D> CalculatedPoints)
  {
    try
    {
      if (Count <= 1)
        return;
      double dt = 1.0 / Convert.ToDouble(Count);
      this.LineerInterpolation(FirstPoint, SecondPoint, dt, ref CalculatedPoints);
    }
    catch (Exception ex)
    {
      string str = $"FirstPoint: {FirstPoint.ToString()} - SecondPoint: {SecondPoint.ToString()} - Count: {Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LineerInterpolation(
    Pnt9D FirstPoint,
    Pnt9D SecondPoint,
    double dt,
    ref List<Pnt9D> CalculatedPoints)
  {
    try
    {
      Pnt9D pnt9D1 = new Pnt9D();
      int int32 = Convert.ToInt32(1.0 / dt);
      CalculatedPoints.Clear();
      for (int index = 0; index <= int32; ++index)
      {
        Pnt9D pnt9D2 = new Pnt9D();
        double num = (double) index * dt;
        pnt9D2.X = FirstPoint.X * (1.0 - num) + SecondPoint.X * num;
        pnt9D2.Y = FirstPoint.Y * (1.0 - num) + SecondPoint.Y * num;
        pnt9D2.Z = FirstPoint.Z * (1.0 - num) + SecondPoint.Z * num;
        pnt9D2.A = FirstPoint.A * (1.0 - num) + SecondPoint.A * num;
        pnt9D2.B = FirstPoint.B * (1.0 - num) + SecondPoint.B * num;
        pnt9D2.C = FirstPoint.C * (1.0 - num) + SecondPoint.C * num;
        pnt9D2.U = FirstPoint.U * (1.0 - num) + SecondPoint.U * num;
        pnt9D2.V = FirstPoint.V * (1.0 - num) + SecondPoint.V * num;
        pnt9D2.W = FirstPoint.W * (1.0 - num) + SecondPoint.W * num;
        CalculatedPoints.Add(pnt9D2);
      }
    }
    catch (Exception ex)
    {
      string str = $"FP: {FirstPoint.ToString()} - SP: {SecondPoint.ToString()} - dt: {dt.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LineerInterpolation(
    Pnt6DSimMove FirstPoint,
    Pnt6DSimMove SecondPoint,
    int Count,
    ref List<Pnt6DSimMove> CalculatedPoints)
  {
    try
    {
      if (Count <= 1)
        return;
      double dt = 1.0 / Convert.ToDouble(Count);
      ((MachineAxisInfo) this).LineerInterpolation(FirstPoint, SecondPoint, dt, ref CalculatedPoints);
      if (CalculatedPoints.Count < 2)
        return;
      ((MeshToSurfacePointsCalculations) CalculatedPoints[CalculatedPoints.Count - 1]).MCode = ((MeshToSurfacePointsCalculations) SecondPoint).MCode;
      ((MeshToSurfacePointsCalculations) CalculatedPoints[CalculatedPoints.Count - 1]).isMCode = ((MeshToSurfacePointsCalculations) SecondPoint).isMCode;
    }
    catch (Exception ex)
    {
      string str = $"FirstPoint: {FirstPoint.ToString()} - SecondPoint: {SecondPoint.ToString()} - Count: {Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }
}
