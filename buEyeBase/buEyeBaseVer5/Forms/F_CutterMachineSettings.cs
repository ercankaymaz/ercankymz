// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_CutterMachineSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_CutterMachineSettings : Form
{
  private readonly Pen[] \u0001;
  public static byte f000A02;
  public static readonly buVector5.\u003C\u003Ec \u003C\u003E9;
  public static Func<Entity, ICurve> \u003C\u003E9__354_0;
  public static Func<Point3D[], LinearPath> \u003C\u003E9__354_1;
  public static Func<Entity, ICurve> \u003C\u003E9__358_0;
  public static Func<Point3D[], LinearPath> \u003C\u003E9__358_1;
  public static Func<Point3D[], LinearPath> \u003C\u003E9__358_2;
  public string \u0001;
  public string \u0001;
  public List<MachineAxisInfo> AxesList;
  public List<MachineMCodeInfo> MCodeList;
  public List<MachineOtherCodeInfo> OtherCodeList;
  public double ExstraTime;
  public LengthUnit LengthType;

  public double CalculateTotalTimeFromTrapezLinearMove(
    double MaxVelocity,
    double Acceleration,
    double Deceleration,
    double Distance)
  {
    double num1 = MaxVelocity * MaxVelocity / (2.0 * Acceleration);
    double num2 = MaxVelocity * MaxVelocity / (2.0 * Deceleration);
    double trapezLinearMove;
    if (num1 + num2 < Distance)
    {
      double num3 = MaxVelocity / Acceleration;
      double num4 = MaxVelocity / Deceleration;
      double num5 = (Distance - (num1 + num2)) / MaxVelocity;
      trapezLinearMove = num3 + num5 + num4;
    }
    else
      trapezLinearMove = !buConversion5.EQ(num1 + num2, Distance, 0.1) ? Math.Sqrt(2.0 * Distance / Acceleration) : MaxVelocity / Acceleration + MaxVelocity / Deceleration;
    return trapezLinearMove;
  }

  public double CalculateTotalTimeFromConstantMove(double MaxVelocity, double Distance)
  {
    double fromConstantMove = 0.0;
    if (Math.Abs(MaxVelocity) > 0.0)
      fromConstantMove = Distance / Math.Abs(MaxVelocity);
    return fromConstantMove;
  }

  public double CalculateTotalTimeFromTrapezJerkMove(
    double MaxVelocity,
    double MaxAcceleration,
    double MaxJerk,
    double Distance)
  {
    double x1 = Math.Sqrt(MaxAcceleration / MaxJerk);
    double num1 = 1.0 / 6.0 * MaxJerk * Math.Pow(x1, 3.0);
    double fromTrapezJerkMove;
    if (num1 * 2.0 < Distance)
    {
      double x2 = (MaxVelocity - MaxAcceleration * x1) / MaxAcceleration;
      double num2 = MaxAcceleration * Math.Pow(x2, 2.0);
      double num3 = (Distance - 2.0 * num1) / MaxVelocity;
      fromTrapezJerkMove = 2.0 * x1 + num3;
    }
    else
      fromTrapezJerkMove = 2.0 * x1;
    return fromTrapezJerkMove;
  }

  public void CheckDuplicatedPointsWithPrevious(ref List<Point3D> Points)
  {
    try
    {
      List<Point3D> copiedPoint = new List<Point3D>();
      if (Points.Count <= 0)
        return;
      buVector5.Copy(Points, ref copiedPoint);
      Points.Clear();
      Points.Add(F_NotchEdit.ToPoint3D(copiedPoint[0]));
      for (int index = 1; index <= copiedPoint.Count - 1; ++index)
      {
        if (!buConversion5.EQ(Points[Points.Count - 1], copiedPoint[index]))
          Points.Add(F_NotchEdit.ToPoint3D(copiedPoint[index]));
      }
      if (Points.Count <= 0 || buConversion5.EQ(Points[Points.Count - 1], copiedPoint[copiedPoint.Count - 1]))
        return;
      Points.RemoveAt(Points.Count - 1);
      Points.Add(copiedPoint[copiedPoint.Count - 1]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CheckDuplicatedPointsWithPrevious(double Resolution, ref List<Point3D> Points)
  {
    try
    {
      List<Point3D> copiedPoint = new List<Point3D>();
      Point3D point3D = new Point3D(double.MinValue, double.MinValue, double.MinValue);
      if (Points.Count <= 0)
        return;
      buVector5.Copy(Points, ref copiedPoint);
      Points.Clear();
      Points.Add(F_NotchEdit.ToPoint3D(copiedPoint[0]));
      for (int index = 1; index <= copiedPoint.Count - 2; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        if (!buConversion5.\u003C\u003Ec.EQ(Points[Points.Count - 1], copiedPoint[index], Resolution))
          Points.Add(F_NotchEdit.ToPoint3D(copiedPoint[index]));
      }
      if (Points.Count <= 0)
        return;
      // ISSUE: reference to a compiler-generated method
      if (!buConversion5.\u003C\u003Ec.EQ(Points[Points.Count - 1], copiedPoint[copiedPoint.Count - 1], Resolution))
      {
        Points.Add(copiedPoint[copiedPoint.Count - 1]);
      }
      else
      {
        Points.RemoveAt(Points.Count - 1);
        Points.Add(copiedPoint[copiedPoint.Count - 1]);
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CheckDuplicatedPointsWithPrevious(ref List<Pnt6D> Points, double Resolution = 0.01)
  {
    try
    {
      List<Pnt6D> CopiedPnt = new List<Pnt6D>();
      Pnt6D pnt6D = new Pnt6D(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);
      if (Points.Count <= 0)
        return;
      Pnt6D.Copy(Points, ref CopiedPnt);
      Points.Clear();
      Points.Add(new Pnt6D(CopiedPnt[0]));
      for (int index = 1; index <= CopiedPnt.Count - 1; ++index)
      {
        if (!buString5.EQ(Points[Points.Count - 1], CopiedPnt[index], Resolution))
          Points.Add(new Pnt6D(CopiedPnt[index]));
      }
      if (Points.Count <= 0 || buString5.EQ(Points[Points.Count - 1], CopiedPnt[CopiedPnt.Count - 1], Resolution))
        return;
      Points.RemoveAt(Points.Count - 1);
      Points.Add(new Pnt6D(CopiedPnt[CopiedPnt.Count - 1]));
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CheckDuplicatedPointsWithPrevious(ref List<Pnt6DS> Points, double Resolution = 0.01)
  {
    try
    {
      List<Pnt6DS> CopiedPnt = new List<Pnt6DS>();
      Pnt6DS pnt6Ds = new Pnt6DS(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);
      if (Points.Count <= 0)
        return;
      Pnt6DS.Copy(Points, ref CopiedPnt);
      Points.Clear();
      Points.Add(new Pnt6DS(CopiedPnt[0]));
      for (int index = 1; index <= CopiedPnt.Count - 1; ++index)
      {
        if (!buString5.EQ(Points[Points.Count - 1], CopiedPnt[index], Resolution))
          Points.Add(new Pnt6DS(CopiedPnt[index]));
      }
      if (Points.Count <= 0 || buString5.EQ(Points[Points.Count - 1], CopiedPnt[CopiedPnt.Count - 1], Resolution))
        return;
      Points.RemoveAt(Points.Count - 1);
      Points.Add(new Pnt6DS(CopiedPnt[CopiedPnt.Count - 1]));
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CheckDuplicatedPointsWithPrevious(ref List<GCodeGraphPoint5> Points)
  {
    try
    {
      List<GCodeGraphPoint5> CopiedPnt = new List<GCodeGraphPoint5>();
      Pnt3D pnt3D = new Pnt3D(double.MinValue, double.MinValue, double.MinValue);
      if (Points.Count <= 0)
        return;
      buFunctions.Copy(Points, ref CopiedPnt);
      Points.Clear();
      Points.Add((GCodeGraphPoint5) new buFunctions(CopiedPnt[0]));
      for (int index = 1; index <= CopiedPnt.Count - 1; ++index)
      {
        if (!buConversion5.EQ(((buCompare5) Points[Points.Count - 1]).Positions, ((buCompare5) CopiedPnt[index]).Positions))
          Points.Add((GCodeGraphPoint5) new buFunctions(CopiedPnt[index]));
      }
      if (Points.Count <= 0 || buConversion5.EQ(((buCompare5) Points[Points.Count - 1]).Positions, ((buCompare5) CopiedPnt[CopiedPnt.Count - 1]).Positions))
        return;
      Points.RemoveAt(Points.Count - 1);
      Points.Add((GCodeGraphPoint5) new buFunctions(CopiedPnt[CopiedPnt.Count - 1]));
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }
}
