// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_CutterOffsetEntities
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_CutterOffsetEntities : Form
{
  public SpeedUnit SpeedType;
  public static byte f000A11;
  public string AxisName;
  public double MaxSpeed;
  public double Acceleration;
  public double Deceleration;
  public double Jerk;
  public string AxisExplanation;
  public static byte f000A18;
  public string MCode;
  public string ExtraCode;
  public double TimeAsSec;
  public string MCodeExplanation;
  public static byte f000A1D;
  public string OtherCode;
  public double TimeAsSec;
  public string ExtraCode;
  public string OtherCodeExplanation;
  public static byte f000A22;
  public double TotalTimeAsSec;

  public void CheckDuplicatedPointAxesWithPrevious(
    ref List<Point3D> Points,
    AxesXYZ Axes,
    double Resolution = 0.01)
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
        if (Axes == AxesXYZ.X && !buConversion5.EQ(Points[Points.Count - 1].X, copiedPoint[index].X, Resolution))
          Points.Add(F_NotchEdit.ToPoint3D(copiedPoint[index]));
        if (Axes == AxesXYZ.Y && !buConversion5.EQ(Points[Points.Count - 1].Y, copiedPoint[index].Y, Resolution))
          Points.Add(F_NotchEdit.ToPoint3D(copiedPoint[index]));
        if (Axes == AxesXYZ.Z && !buConversion5.EQ(Points[Points.Count - 1].Z, copiedPoint[index].Z, Resolution))
          Points.Add(F_NotchEdit.ToPoint3D(copiedPoint[index]));
      }
      if (Points.Count <= 0)
        return;
      if (Axes == AxesXYZ.X && !buConversion5.EQ(Points[Points.Count - 1].X, copiedPoint[copiedPoint.Count - 1].X))
      {
        Points.RemoveAt(Points.Count - 1);
        Points.Add(copiedPoint[copiedPoint.Count - 1]);
      }
      if (Axes == AxesXYZ.Y && !buConversion5.EQ(Points[Points.Count - 1].Y, copiedPoint[copiedPoint.Count - 1].Y))
      {
        Points.RemoveAt(Points.Count - 1);
        Points.Add(copiedPoint[copiedPoint.Count - 1]);
      }
      if (Axes != AxesXYZ.Z || buConversion5.EQ(Points[Points.Count - 1].Z, copiedPoint[copiedPoint.Count - 1].Z))
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

  public void CheckDuplicatedPointAxesWithPrevious(
    ref List<Pnt6D> Points,
    AxesXYZ Axes,
    double Resolution = 0.01)
  {
    try
    {
      List<Pnt6D> CopiedPnt = new List<Pnt6D>();
      if (Points.Count <= 0)
        return;
      Pnt6D.Copy(Points, ref CopiedPnt);
      Points.Clear();
      Points.Add(new Pnt6D(CopiedPnt[0]));
      for (int index = 1; index <= CopiedPnt.Count - 1; ++index)
      {
        if (Axes == AxesXYZ.X && !buConversion5.EQ(Points[Points.Count - 1].X, CopiedPnt[index].X, Resolution))
          Points.Add(new Pnt6D(CopiedPnt[index]));
        if (Axes == AxesXYZ.Y && !buConversion5.EQ(Points[Points.Count - 1].Y, CopiedPnt[index].Y, Resolution))
          Points.Add(new Pnt6D(CopiedPnt[index]));
        if (Axes == AxesXYZ.Z && !buConversion5.EQ(Points[Points.Count - 1].Z, CopiedPnt[index].Z, Resolution))
          Points.Add(new Pnt6D(CopiedPnt[index]));
      }
      if (Points.Count <= 0)
        return;
      if (Axes == AxesXYZ.X && !buConversion5.EQ(Points[Points.Count - 1].X, CopiedPnt[CopiedPnt.Count - 1].X))
      {
        Points.RemoveAt(Points.Count - 1);
        Points.Add(CopiedPnt[CopiedPnt.Count - 1]);
      }
      if (Axes == AxesXYZ.Y && !buConversion5.EQ(Points[Points.Count - 1].Y, CopiedPnt[CopiedPnt.Count - 1].Y))
      {
        Points.RemoveAt(Points.Count - 1);
        Points.Add(CopiedPnt[CopiedPnt.Count - 1]);
      }
      if (Axes != AxesXYZ.Z || buConversion5.EQ(Points[Points.Count - 1].Z, CopiedPnt[CopiedPnt.Count - 1].Z))
        return;
      Points.RemoveAt(Points.Count - 1);
      Points.Add(CopiedPnt[CopiedPnt.Count - 1]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void VerticeToPointsList(List<Point3D> Vertice, ref List<Point3D> PointList)
  {
    PointList = new List<Point3D>();
    if (Vertice == null)
      return;
    for (int index = 0; index <= Vertice.Count - 1; ++index)
      PointList.Add(F_NotchEdit.ToPoint3D(Vertice[index]));
  }

  public static void VerticeToPointsList(Point3D[] Vertice, ref List<Point3D> PointList)
  {
    PointList = new List<Point3D>();
    if (Vertice == null)
      return;
    for (int index = 0; index <= Vertice.Length - 1; ++index)
      PointList.Add(F_NotchEdit.ToPoint3D(Vertice[index]));
  }

  public static void VerticeToPointsListAdd(Point3D[] Vertice, ref List<Point3D> PointList)
  {
    if (Vertice == null)
      return;
    for (int index = 0; index <= Vertice.Length - 1; ++index)
      PointList.Add(F_NotchEdit.ToPoint3D(Vertice[index]));
  }

  public static void VerticeToPointsList(
    Point3D[] Vertice,
    ref List<PointRGB> PointList,
    Color Color)
  {
    PointList = new List<PointRGB>();
    if (Vertice == null)
      return;
    for (int index = 0; index <= Vertice.Length - 1; ++index)
      PointList.Add(new PointRGB(Vertice[index].X, Vertice[index].Y, Vertice[index].Z, Color.R, Color.G, Color.B));
  }

  public static void VerticeToPointsList(
    List<Point3D> Vertice,
    ref List<PointRGB> PointList,
    Color Color)
  {
    PointList = new List<PointRGB>();
    if (Vertice == null)
      return;
    for (int index = 0; index <= Vertice.Count - 1; ++index)
      PointList.Add(new PointRGB(Vertice[index].X, Vertice[index].Y, Vertice[index].Z, Color.R, Color.G, Color.B));
  }

  public static List<Point3D> VerticeToPointsList(Point3D[] Vertice)
  {
    List<Point3D> PointList = new List<Point3D>();
    F_CutterOffsetEntities.VerticeToPointsList(Vertice, ref PointList);
    return PointList;
  }
}
