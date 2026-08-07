// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buString5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class buString5
{
  public static bool EQ(Point3D Value1, Point3D Value2, double Resolution, Plane refPlane)
  {
    return (!(refPlane == Plane.XY | refPlane == Plane.YX) ? (!(refPlane == Plane.XZ | refPlane == Plane.ZX) ? (!(refPlane == Plane.YZ | refPlane == Plane.ZY) ? Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) : Math.Sqrt((Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z))) : Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z))) : Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y))) < Resolution;
  }

  public static bool EQ(Vector3D Value1, Vector3D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) < Resolution;
  }

  public static bool EQ(Pnt4D Value1, Pnt4D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.W - Value2.W) * (Value1.W - Value2.W)) < Resolution;
  }

  public static bool EQ(Pnt3D Value1, Pnt9D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) < Resolution;
  }

  public static bool EQ(Pnt9D Value1, Pnt3D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) < Resolution;
  }

  public static bool EQ(Pnt6D Value1, Pnt6D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C)) < Resolution;
  }

  public static bool EQ(Pnt6DS Value1, Pnt6DS Value2, double Resolution = 0.001)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C)) < Resolution;
  }

  public static bool EQ(Pnt6DSim Value1, Pnt6DSim Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C)) < Resolution;
  }

  public static bool EQ(Pnt6DSimMove Value1, Pnt6DSimMove Value2, double Resolution)
  {
    double num = Math.Sqrt((((MeshToSurfacePointsSettings) Value1).X - ((MeshToSurfacePointsSettings) Value2).X) * (((MeshToSurfacePointsSettings) Value1).X - ((MeshToSurfacePointsSettings) Value2).X) + (((MeshToSurfacePointsSettings) Value1).Y - ((MeshToSurfacePointsSettings) Value2).Y) * (((MeshToSurfacePointsSettings) Value1).Y - ((MeshToSurfacePointsSettings) Value2).Y) + (((MeshToSurfacePointsSettings) Value1).Z - ((MeshToSurfacePointsSettings) Value2).Z) * (((MeshToSurfacePointsSettings) Value1).Z - ((MeshToSurfacePointsSettings) Value2).Z) + (((MeshToSurfacePointsSettings) Value1).A - ((MeshToSurfacePointsSettings) Value2).A) * (((MeshToSurfacePointsSettings) Value1).A - ((MeshToSurfacePointsSettings) Value2).A) + (((MeshToSurfacePointsSettings) Value1).B - ((MeshToSurfacePointsSettings) Value2).B) * (((MeshToSurfacePointsSettings) Value1).B - ((MeshToSurfacePointsSettings) Value2).B) + (((MeshToSurfacePointsSettings) Value1).C - ((MeshToSurfacePointsSettings) Value2).C) * (((MeshToSurfacePointsSettings) Value1).C - ((MeshToSurfacePointsSettings) Value2).C));
    return ((MeshToSurfacePointsCalculations) Value1).isMCode == ((MeshToSurfacePointsCalculations) Value2).isMCode && (((MeshToSurfacePointsCalculations) Value1).isMCode != ((MeshToSurfacePointsCalculations) Value2).isMCode || ((MeshToSurfacePointsCalculations) Value1).MCode == ((MeshToSurfacePointsCalculations) Value2).MCode) && ((MeshToSurfacePointsCalculations) Value1).ToolNo == ((MeshToSurfacePointsCalculations) Value2).ToolNo && num < Resolution;
  }

  public static bool EQ(Pnt9D Value1, Pnt9D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C) + (Value1.U - Value2.U) * (Value1.U - Value2.U) + (Value1.V - Value2.V) * (Value1.V - Value2.V) + (Value1.W - Value2.W) * (Value1.W - Value2.W)) < Resolution;
  }

  public static bool EQ(Pnt3D Value1, Pnt9DCam Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.P9.X) * (Value1.X - Value2.P9.X) + (Value1.Y - Value2.P9.Y) * (Value1.Y - Value2.P9.Y) + (Value1.Z - Value2.P9.Z) * (Value1.Z - Value2.P9.Z)) < Resolution;
  }

  public static void CheckDuplicatedPointsWithPrevious(ref List<List<Pnt3D>> Points)
  {
    try
    {
      List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
      for (int index = 0; index <= Points.Count - 1; ++index)
      {
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Pnt3D.Copy(Points[index], ref pnt3DList);
        buString5.CheckDuplicatedPointsWithPrevious(ref pnt3DList);
        pnt3DListList.Add(pnt3DList);
      }
      Points.Clear();
      for (int index = 0; index <= pnt3DListList.Count - 1; ++index)
        Points.Add(pnt3DListList[index]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CheckDuplicatedPointsWithPrevious(ref List<Pnt3D> Points)
  {
    try
    {
      List<Pnt3D> CopiedPnt = new List<Pnt3D>();
      if (Points.Count <= 0)
        return;
      Pnt3D.Copy(Points, ref CopiedPnt);
      Points.Clear();
      Points.Add(new Pnt3D(CopiedPnt[0]));
      for (int index = 1; index <= CopiedPnt.Count - 1; ++index)
      {
        if (!buConversion5.EQ(Points[Points.Count - 1], CopiedPnt[index]))
          Points.Add(new Pnt3D(CopiedPnt[index]));
      }
      if (Points.Count <= 0 || buConversion5.EQ(Points[Points.Count - 1], CopiedPnt[CopiedPnt.Count - 1]))
        return;
      Points.RemoveAt(Points.Count - 1);
      Points.Add(new Pnt3D(CopiedPnt[CopiedPnt.Count - 1]));
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CheckDuplicatedPointsWithPrevious(ref List<Pnt3D> Points, double Resolution)
  {
    try
    {
      List<Pnt3D> CopiedPnt = new List<Pnt3D>();
      if (Points.Count <= 0)
        return;
      Pnt3D.Copy(Points, ref CopiedPnt);
      Points.Clear();
      Points.Add(new Pnt3D(CopiedPnt[0]));
      for (int index = 1; index <= CopiedPnt.Count - 1; ++index)
      {
        if (!buConversion5.EQ(Points[Points.Count - 1], CopiedPnt[index], Resolution))
          Points.Add(new Pnt3D(CopiedPnt[index]));
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  static buString5()
  {
    buVector5.resolutionCompare = 0.001;
    // ISSUE: reference to a compiler-generated field
    buVector5.\u003C\u003Ec.RegenDeviation = 0.001;
  }

  public buString5()
  {
    if (!buVector5.\u0001("buConversion5"))
      throw new RegisterException("buConversion5");
  }

  public static double RadianToDegree(double Radian)
  {
    try
    {
      return Radian * 180.0 / Math.PI;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return 0.0;
    }
  }

  public static double DegreeToRadian(double Degree)
  {
    try
    {
      double radian = 0.0;
      if (Degree > 360.0)
      {
        Degree -= 360.0;
        radian = Degree * Math.PI / 180.0;
        Degree += 360.0;
      }
      if (Degree <= 360.0)
        radian = Degree * Math.PI / 180.0;
      return radian;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return 0.0;
    }
  }

  public static double DegreeToRadianGreat360(double Degree)
  {
    try
    {
      double radianGreat360 = 0.0;
      if (Degree > 360.0)
      {
        Degree -= 360.0;
        radianGreat360 = Degree * Math.PI / 180.0 + 2.0 * Math.PI;
        Degree += 360.0;
      }
      if (Degree <= 360.0)
        radianGreat360 = Degree * Math.PI / 180.0;
      return radianGreat360;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return 0.0;
    }
  }

  public static string IntegerToBits(int Value, int DigitCount)
  {
    bool[] bits1 = buString5.IntegerToBits(Value);
    string bits2 = "";
    for (int index = 0; index <= bits1.Length - 1; ++index)
    {
      if (index <= DigitCount - 1)
        bits2 = !bits1[index] ? bits2 + "0" : bits2 + "1";
    }
    return bits2;
  }

  public static bool[] IntegerToBits(int Value)
  {
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int[] array = Convert.ToString(Value, 2).PadLeft(32 /*0x20*/, '0').Select<char, int>(buVector5.\u003C\u003Ec.\u003C\u003E9__5_0 ?? (buVector5.\u003C\u003Ec.\u003C\u003E9__5_0 = new Func<char, int>(((buNumeric5) buVector5.\u003C\u003Ec.\u003C\u003E9).\u0001))).ToArray<int>();
    bool[] bits = new bool[array.Length];
    int index1 = 0;
    for (int index2 = array.Length - 1; index2 >= 0; --index2)
    {
      bits[index1] = array[index2] != 0;
      ++index1;
    }
    return bits;
  }

  public static int BitsToInteger(
    bool bit0,
    bool bit1,
    bool bit2,
    bool bit3,
    bool bit4,
    bool bit5,
    bool bit6,
    bool bit7)
  {
    double num1 = 0.0;
    double y = 0.0;
    int num2 = 8;
    while (num2 != 0)
    {
      double num3 = (double) (num2 % 10);
      num1 += num3 * Math.Pow(2.0, y);
      num2 /= 10;
      ++y;
    }
    return Convert.ToInt32(num1);
  }

  public static int BitsToInteger(string binary)
  {
    double num1 = 0.0;
    double y = 0.0;
    int int32 = Convert.ToInt32(binary);
    while (int32 != 0)
    {
      double num2 = (double) (int32 % 10);
      num1 += num2 * Math.Pow(2.0, y);
      int32 /= 10;
      ++y;
    }
    return Convert.ToInt32(num1);
  }

  public static Pnt3D Point3DToPnt3D(Point3D P)
  {
    try
    {
      return P != (Point3D) null ? new Pnt3D(P.X, P.Y, P.Z) : new Pnt3D();
    }
    catch (Exception ex)
    {
      return new Pnt3D();
    }
  }

  public static Point3D Pnt6DToPoint3D(Pnt6D P)
  {
    try
    {
      return new Point3D(P.X, P.Y, P.Z);
    }
    catch (Exception ex)
    {
      return new Point3D();
    }
  }

  public static Pnt3D Pnt6DToPnt3D(Pnt6DS P)
  {
    try
    {
      return new Pnt3D(P.X, P.Y, P.Z);
    }
    catch (Exception ex)
    {
      return new Pnt3D();
    }
  }

  public static Pnt3D Pnt9DToPnt3D(Pnt9D P)
  {
    try
    {
      return new Pnt3D(P.X, P.Y, P.Z);
    }
    catch (Exception ex)
    {
      return new Pnt3D();
    }
  }

  public static string Point3DToString(Point3D P, int Decimal = 3)
  {
    try
    {
      if (!(P != (Point3D) null))
        return "";
      return $"{P.X.ToString("f" + Decimal.ToString())} , {P.Y.ToString("f" + Decimal.ToString())} , {P.Z.ToString("f" + Decimal.ToString())}";
    }
    catch (Exception ex)
    {
      return "";
    }
  }

  public static void Point3DToPnt3D(Point3D[] RefPnt, ref List<Pnt3D> CopiedPnt)
  {
    try
    {
      CopiedPnt.Clear();
      CopiedPnt = new List<Pnt3D>();
      for (int index = 0; index <= RefPnt.Length - 1; ++index)
        CopiedPnt.Add(buString5.Point3DToPnt3D(RefPnt[index]));
    }
    catch (Exception ex)
    {
    }
  }

  public static void Point3DToPnt3D(List<Point3D> RefPnt, ref List<Pnt3D> CopiedPnt)
  {
    try
    {
      CopiedPnt.Clear();
      CopiedPnt = new List<Pnt3D>();
      for (int index = 0; index <= RefPnt.Count - 1; ++index)
        CopiedPnt.Add(buString5.Point3DToPnt3D(RefPnt[index]));
    }
    catch (Exception ex)
    {
    }
  }

  public static void Point3DToPnt3D(List<List<Point3D>> RefPnt, ref List<List<Pnt3D>> CopiedPnt)
  {
    CopiedPnt = new List<List<Pnt3D>>();
    for (int index = 0; index <= RefPnt.Count - 1; ++index)
    {
      List<Pnt3D> CopiedPnt1 = new List<Pnt3D>();
      buString5.Point3DToPnt3D(RefPnt[index], ref CopiedPnt1);
      CopiedPnt.Add(CopiedPnt1);
    }
  }

  public static void Pnt9DToPnt3D(List<Pnt9D> RefPnt, ref List<Pnt3D> CopiedPnt)
  {
    try
    {
      CopiedPnt.Clear();
      CopiedPnt = new List<Pnt3D>();
      for (int index = 0; index <= RefPnt.Count - 1; ++index)
        CopiedPnt.Add(buString5.Pnt9DToPnt3D(RefPnt[index]));
    }
    catch (Exception ex)
    {
    }
  }

  public static void Pnt6DToPnt3D(List<Pnt6DS> RefPnt, ref List<Pnt3D> CopiedPnt)
  {
    try
    {
      CopiedPnt.Clear();
      CopiedPnt = new List<Pnt3D>();
      for (int index = 0; index <= RefPnt.Count - 1; ++index)
        CopiedPnt.Add(buString5.Pnt6DToPnt3D(RefPnt[index]));
    }
    catch (Exception ex)
    {
    }
  }

  public static List<Point3D> Pnt3dToPoint3D(List<Pnt3D> P)
  {
    List<Point3D> point3D = new List<Point3D>();
    for (int index = 0; index <= P.Count - 1; ++index)
      point3D.Add(new Point3D(P[index].X, P[index].Y, P[index].Z));
    return point3D;
  }

  public static Point3D Pnt3DToPoint3D(Pnt3D P)
  {
    try
    {
      return new Point3D(P.X, P.Y, P.Z);
    }
    catch (Exception ex)
    {
      return new Point3D();
    }
  }

  public static void Pnt3DToPoint3D(List<Pnt3D> RefPnt, ref Point3D[] CopiedPnt)
  {
    if (RefPnt.Count <= 0)
      return;
    CopiedPnt = new Point3D[(RefPnt.Count - 1) * 2];
    int index1 = 0;
    for (int index2 = 0; index2 <= RefPnt.Count - 2; ++index2)
    {
      if (index2 == 0)
      {
        CopiedPnt[index1] = buString5.Pnt3DToPoint3D(RefPnt[index2]);
        int index3 = index1 + 1;
        CopiedPnt[index3] = buString5.Pnt3DToPoint3D(RefPnt[index2 + 1]);
        index1 = index3 + 1;
      }
      else
      {
        CopiedPnt[index1] = buString5.Pnt3DToPoint3D(RefPnt[index2]);
        int index4 = index1 + 1;
        CopiedPnt[index4] = buString5.Pnt3DToPoint3D(RefPnt[index2 + 1]);
        index1 = index4 + 1;
      }
    }
  }

  public static void Pnt3DToPoint3D(List<Pnt3D> RefPnt, ref List<Point3D> CopiedPnt)
  {
    if (RefPnt.Count <= 0)
      return;
    CopiedPnt.Clear();
    for (int index = 0; index <= RefPnt.Count - 1; ++index)
      CopiedPnt.Add(buString5.Pnt3DToPoint3D(RefPnt[index]));
  }

  public static void Pnt3dToPoint3D(List<List<Pnt3D>> RefPnt, ref List<List<Point3D>> CopiedPnt)
  {
    if (RefPnt.Count <= 0)
      return;
    CopiedPnt.Clear();
    for (int index = 0; index <= RefPnt.Count - 1; ++index)
      CopiedPnt.Add(buString5.Pnt3dToPoint3D(RefPnt[index]));
  }

  public static string ToString(Point3D P)
  {
    return $"X : {P.X.ToString("f3")} , Y : {P.Y.ToString("f3")} , Z : {P.Z.ToString("f3")}";
  }

  public static string ToString(OrientationAngle P)
  {
    return $"A : {P.A.ToString("f3")} , B : {P.B.ToString("f3")} , C : {P.C.ToString("f3")}";
  }

  public static Vector3D Vec3dToVector3D(Vec3D P) => new Vector3D(P.X, P.Y, P.Z);

  public static Vec3D Vector3DToVec3D(Vector3D P) => new Vec3D(P.X, P.Y, P.Z);

  public static System.Drawing.Point Screen3DTo2D(Design Viewport, Point3D Pnt)
  {
    try
    {
      PointF pointF = new PointF();
      System.Drawing.Point point = new System.Drawing.Point();
      Point2D point2D = new Point2D();
      Point2D screen = (Point2D) Viewport.WorldToScreen(Pnt);
      pointF.X = (float) screen.X;
      pointF.Y = (float) screen.Y;
      point.X = (int) pointF.X;
      point.Y = Viewport.Height - (int) pointF.Y;
      if (point.X < 0)
        point.X = 1;
      if (point.Y < 0)
        point.Y = 1;
      return point;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return new System.Drawing.Point();
    }
  }

  public static Point3D Screen2DTo3D(Design Viewport, Plane refPlane, System.Drawing.Point Pnt)
  {
    try
    {
      Point3D intPoint = new Point3D();
      Viewport.ScreenToPlane(Pnt, refPlane, out intPoint);
      if (intPoint == (Point3D) null)
        intPoint = new Point3D();
      return intPoint;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return new Point3D();
    }
  }

  public static void EntityInfoToCustomData(
    EntityInfo Info,
    EntityShapeInfo ShapeInfo,
    ref CustomData CD)
  {
    ((buDiamakerCalc) CD).set_CamID(((EntityDataSet) Info).CamID);
    ((DiemakerGrindingShapeSettings) CD).set_RefIndex(((AnalyseEntitiesSetting) Info).RefIndex);
    ((buDiamakerCalc) CD).set_OriginalEntityIndex(((AnalyseEntitiesSetting) Info).OriginalEntityIndex);
    ((RollerJob) CD).set_Sequence(((AnalyseEntitiesSetting) Info).Sequence);
    ((buCutterCalc) CD).set_DontUseForCalculation(((DirectionArrowSetting) Info).DontUseForCalculation);
    ((buCutterCalc) CD).set_CamSelectable(((AnalyseEntitiesResultError) Info).CamSelectable);
    ((buCutter) CD).set_CamSelected(((AnalyseEntitiesResult) Info).CamSelected);
    ((ClipperOffset) CD).set_Tags(((EntityDataSet) Info).Tags);
    if (ShapeInfo == null)
      return;
    ((CutterNotch) CD).set_infoAngle(((SewingPunteriz) ShapeInfo).Angle);
    ((RollerJob) CD).set_infoBasePoint(new Point3D(((MarbleInfo) ShapeInfo).BasePoint.X, ((MarbleInfo) ShapeInfo).BasePoint.Y, ((MarbleInfo) ShapeInfo).BasePoint.Z));
    ((CutterProgramSettings) CD).set_infoData(((SewingPunteriz) ShapeInfo).Data);
    ((buRollerBendCalc) CD).set_infoDegree(((MarbleInfo) ShapeInfo).Degree);
    ((ToolGrindingJob) CD).set_infoDepth(((MarbleInfo) ShapeInfo).Depth);
    ((CutterNotch) CD).set_infoDirection(((SewingPunteriz) ShapeInfo).Direction);
    ((ToolGrindingRuntimeSettings) CD).set_infoHeadRadius(((MarbleInfo) ShapeInfo).HeadRadius);
    ((buToolGrindingCalc) CD).set_infoHeight(((SewingPunteriz) ShapeInfo).Height);
    ((CutterProgramSettings) CD).set_infoLength(((SewingPunteriz) ShapeInfo).Length);
    ((ToolGrindingJob) CD).set_infoRadius(((SewingPunteriz) ShapeInfo).Radius);
    ((ToolGrindingSettings) CD).set_infoSide(((MarbleInfo) ShapeInfo).Side);
    ((CutterProgramSettings) CD).set_infoString(((SewingPunteriz) ShapeInfo).String);
    ((ToolGrindingJob) CD).set_infoWidth(((MarbleInfo) ShapeInfo).Width);
    ((RollerJob) CD).set_CurveType(((MarbleInfo) ShapeInfo).CurveType);
  }

  public static void CustomDataToEntityInfo(
    CustomData CD,
    ref EntityInfo Info,
    ref EntityShapeInfo ShapeInfo)
  {
    ShapeInfo = (EntityShapeInfo) new SewingCode();
    Info = (EntityInfo) new CharLibrary5();
    ((EntityDataSet) Info).CamID = ((buDiamakerCalc) CD).get_CamID();
    ((AnalyseEntitiesSetting) Info).RefIndex = ((DiemakerGrindingShapeSettings) CD).get_RefIndex();
    ((AnalyseEntitiesSetting) Info).OriginalEntityIndex = ((buDiamakerCalc) CD).get_OriginalEntityIndex();
    ((AnalyseEntitiesSetting) Info).Sequence = ((RollerJob) CD).get_Sequence();
    ((DirectionArrowSetting) Info).DontUseForCalculation = ((buCutterCalc) CD).get_DontUseForCalculation();
    ((AnalyseEntitiesResultError) Info).CamSelectable = ((buCutterCalc) CD).get_CamSelectable();
    ((AnalyseEntitiesResult) Info).CamSelected = ((buCutter) CD).get_CamSelected();
    ((EntityDataSet) Info).Tags = ((ClipperOffset) CD).get_Tags();
    ((SewingPunteriz) ShapeInfo).Angle = ((CutterNotch) CD).get_infoAngle();
    if (((buRollerBendCalc) CD).get_infoBasePoint() != (Point3D) null)
      ((MarbleInfo) ShapeInfo).BasePoint = new Point3D(((buRollerBendCalc) CD).get_infoBasePoint().X, ((buRollerBendCalc) CD).get_infoBasePoint().Y, ((buRollerBendCalc) CD).get_infoBasePoint().Z);
    ((SewingPunteriz) ShapeInfo).Data = ((CutterProgramSettings) CD).get_infoData();
    ((MarbleInfo) ShapeInfo).Degree = ((buRollerBendCalc) CD).get_infoDegree();
    ((MarbleInfo) ShapeInfo).Depth = ((ToolGrindingJob) CD).get_infoDepth();
    ((SewingPunteriz) ShapeInfo).Direction = ((CutterNotch) CD).get_infoDirection();
    ((MarbleInfo) ShapeInfo).HeadRadius = ((ToolGrindingRuntimeSettings) CD).get_infoHeadRadius();
    ((SewingPunteriz) ShapeInfo).Height = ((buToolGrindingCalc) CD).get_infoHeight();
    ((SewingPunteriz) ShapeInfo).Length = ((CutterProgramSettings) CD).get_infoLength();
    ((SewingPunteriz) ShapeInfo).Radius = ((ToolGrindingJob) CD).get_infoRadius();
    ((MarbleInfo) ShapeInfo).Side = ((ToolGrindingSettings) CD).get_infoSide();
    ((SewingPunteriz) ShapeInfo).String = ((CutterRuntimeSettings) CD).get_infoString();
    ((MarbleInfo) ShapeInfo).Width = ((ToolGrindingJob) CD).get_infoWidth();
    ((MarbleInfo) ShapeInfo).CurveType = ((RollerJob) CD).get_CurveType();
  }

  public static void EyeCamEntityToEyeEntity(Entity CamEntity, ref Entity EyeEntity)
  {
    bool flag = false;
    if (CamEntity.GetType() == typeof (buLinearPathCam))
    {
      EyeEntity = (Entity) new LinearPath(CamEntity.Vertices);
      flag = true;
    }
    else if (CamEntity.GetType() == typeof (buLineCam))
    {
      EyeEntity = (Entity) new Line(CamEntity.Vertices[0], CamEntity.Vertices[1]);
      flag = true;
    }
    else if (CamEntity.GetType() == typeof (buArcCam))
    {
      EyeEntity = (Entity) new Arc(((PlanarEntity) CamEntity).Plane, ((Circle) CamEntity).Center, ((Circle) CamEntity).Radius, ((Circle) CamEntity).StartPoint, ((Circle) CamEntity).EndPoint, false);
      flag = true;
    }
    else if (CamEntity.GetType() == typeof (buCompositeCurveCam))
    {
      EyeEntity = (Entity) new CompositeCurve((IEnumerable<ICurve>) ((CompositeCurve) CamEntity).CurveList);
      flag = true;
    }
    if (!flag)
      return;
    if (CamEntity.EntityData == null)
    {
      EyeEntity.EntityData = (object) new ClipperOffset();
    }
    else
    {
      if (!(CamEntity.EntityData.GetType() == typeof (CustomData)))
        return;
      EyeEntity.EntityData = (object) new ClipperOffset((CustomData) CamEntity.EntityData);
    }
  }

  public static void buEntityToEyeEntity(
    List<eEntities> buEntity,
    bool SetCurrentData,
    ref List<Entity> eyeEntity,
    List<LayerBase5> Layers,
    string SceneName)
  {
    eyeEntity.Clear();
    for (int index = 0; index <= buEntity.Count - 1; ++index)
    {
      Entity eyeEntity1 = (Entity) null;
      buString5.buEntityToEyeEntity(buEntity[index], SetCurrentData, index, ref eyeEntity1, Layers, SceneName);
      if (eyeEntity1 != null)
        eyeEntity.Add(eyeEntity1);
    }
  }

  public static void buEntityToEyeEntity(
    eEntities buEntity,
    bool SetCurrentData,
    int Index,
    ref Entity eyeEntity,
    List<LayerBase5> Layers,
    string SceneName)
  {
    try
    {
      if (buEntity.GetType() == typeof (eLine))
      {
        eyeEntity = (Entity) new Line(buString5.Pnt3DToPoint3D(((eLine) buEntity).StartPoint), buString5.Pnt3DToPoint3D(((eLine) buEntity).EndPoint));
        eyeEntity.EntityData = (object) new ClipperOffset();
        ((ClipperOffset) eyeEntity.EntityData).set_SceneName(SceneName);
        ((ClipperOffset) eyeEntity.EntityData).set_EntityName("Ent" + (Index + 1).ToString());
        ((\u001D.\u0001) eyeEntity.EntityData).set_ActionName("Line");
        ((CutterProgramSettings) eyeEntity.EntityData).set_infoLength(buEntity.geoLength);
        ((CutterNotch) eyeEntity.EntityData).set_infoAngle(buEntity.geoAngleXY);
        buNumeric5.EntityCommonProperties(ref eyeEntity, buEntity, Layers);
      }
      if (buEntity.GetType() == typeof (eArc))
      {
        if (buConversion5.EQ(Math.Abs(((eArc) buEntity).EndAngle - ((eArc) buEntity).StartAngle), 360.0))
        {
          eyeEntity = (Entity) new Circle(buVector5.WorkPlaneToPlane(((ePlaneEntities) buEntity).Plane), buString5.Pnt3DToPoint3D(((ePlaneEntities) buEntity).CenterPoint), ((eCircle) buEntity).Radius);
          eyeEntity.EntityData = (object) new ClipperOffset();
          ((ClipperOffset) eyeEntity.EntityData).set_SceneName(SceneName);
          ((ClipperOffset) eyeEntity.EntityData).set_EntityName("Ent" + (Index + 1).ToString());
          ((\u001D.\u0001) eyeEntity.EntityData).set_ActionName("Circle");
          buNumeric5.EntityCommonProperties(ref eyeEntity, buEntity, Layers);
        }
        else
        {
          eyeEntity = (Entity) new Arc(buString5.Pnt3DToPoint3D(((eArc) buEntity).StartPoint), buString5.Pnt3DToPoint3D(((eArc) buEntity).MiddlePoint), buString5.Pnt3DToPoint3D(((eArc) buEntity).EndPoint), false);
          eyeEntity.EntityData = (object) new ClipperOffset();
          ((ClipperOffset) eyeEntity.EntityData).set_SceneName(SceneName);
          ((ClipperOffset) eyeEntity.EntityData).set_EntityName("Ent" + (Index + 1).ToString());
          ((\u001D.\u0001) eyeEntity.EntityData).set_ActionName("Arc");
          eyeEntity.Regen(new RegenParams(buSystem.RegenDeviation));
          buNumeric5.EntityCommonProperties(ref eyeEntity, buEntity, Layers);
        }
      }
      if (buEntity.GetType() == typeof (eCircle))
      {
        eyeEntity = (Entity) new Circle(buVector5.WorkPlaneToPlane(((ePlaneEntities) buEntity).Plane), buString5.Pnt3DToPoint3D(((ePlaneEntities) buEntity).CenterPoint), ((eCircle) buEntity).Radius);
        eyeEntity.EntityData = (object) new ClipperOffset();
        ((ClipperOffset) eyeEntity.EntityData).set_SceneName(SceneName);
        ((ClipperOffset) eyeEntity.EntityData).set_EntityName("Ent" + (Index + 1).ToString());
        ((\u001D.\u0001) eyeEntity.EntityData).set_ActionName("Circle");
        buNumeric5.EntityCommonProperties(ref eyeEntity, buEntity, Layers);
      }
      if (buEntity.GetType() == typeof (eEllipse) | buEntity.GetType() == typeof (eBSpline) | buEntity.GetType() == typeof (eBezeir) | buEntity.GetType() == typeof (ePolyline))
      {
        eyeEntity = (Entity) new LinearPath((ICollection<Point3D>) buString5.Pnt3dToPoint3D(buEntity.Vertice));
        eyeEntity.EntityData = (object) new ClipperOffset();
        ((ClipperOffset) eyeEntity.EntityData).set_SceneName(SceneName);
        ((ClipperOffset) eyeEntity.EntityData).set_EntityName("Ent" + (Index + 1).ToString());
        ((\u001D.\u0001) eyeEntity.EntityData).set_ActionName("LinearPath");
        buNumeric5.EntityCommonProperties(ref eyeEntity, buEntity, Layers);
      }
      int num;
      if (buEntity.GetType() == typeof (ePoint))
      {
        eyeEntity = (Entity) new devDept.Eyeshot.Entities.Point(buString5.Pnt3DToPoint3D(((ePoint) buEntity).StartPoint));
        eyeEntity.EntityData = (object) new ClipperOffset();
        ((ClipperOffset) eyeEntity.EntityData).set_SceneName(SceneName);
        CustomData entityData = (CustomData) eyeEntity.EntityData;
        num = Index + 1;
        string str = "Ent" + num.ToString();
        ((ClipperOffset) entityData).set_EntityName(str);
        ((\u001D.\u0001) eyeEntity.EntityData).set_ActionName("Point");
        buNumeric5.EntityCommonProperties(ref eyeEntity, buEntity, Layers);
      }
      if (buEntity.GetType() == typeof (eMesh))
      {
        eMesh cadEntity = new eMesh(buEntity);
        List<Point3D> vertices = new List<Point3D>();
        List<IndexTriangle> triangles = new List<IndexTriangle>();
        for (int index = 0; index <= cadEntity.Vertice.Count - 1; ++index)
          vertices.Add(new Point3D(cadEntity.Vertice[index].X, cadEntity.Vertice[index].Y, cadEntity.Vertice[index].Z));
        for (int index = 0; index <= cadEntity.TriIndex.Count - 1; ++index)
          triangles.Add(new IndexTriangle(cadEntity.TriIndex[index].V1, cadEntity.TriIndex[index].V2, cadEntity.TriIndex[index].V3));
        eyeEntity = (Entity) new Mesh((IList<Point3D>) vertices, (IList<IndexTriangle>) triangles);
        eyeEntity.EntityData = (object) new ClipperOffset();
        ((Mesh) eyeEntity).NormalAveragingMode = Mesh.normalAveragingType.AveragedByAngle;
        ((Mesh) eyeEntity).EdgeStyle = Mesh.edgeStyleType.Sharp;
        ((Mesh) eyeEntity).ComputeEdges();
        ((ClipperOffset) eyeEntity.EntityData).set_SceneName(SceneName);
        CustomData entityData = (CustomData) eyeEntity.EntityData;
        num = Index + 1;
        string str = "Ent" + num.ToString();
        ((ClipperOffset) entityData).set_EntityName(str);
        ((\u001D.\u0001) eyeEntity.EntityData).set_ActionName("Mesh");
        buNumeric5.EntityCommonProperties(ref eyeEntity, (eEntities) cadEntity, Layers);
      }
      if (eyeEntity == null)
        return;
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_typeDefination(buEntity.TypeDefination);
    }
    catch (Exception ex)
    {
    }
  }

  public static void geoEntityToEyeEntity(geoEntity geoEntity, ref Entity eyeEntity)
  {
    if (geoEntity.GetType() == typeof (geoLine))
    {
      eyeEntity = (Entity) new Line(buString5.Pnt3DToPoint3D(((geoLine) geoEntity).StartPoint), buString5.Pnt3DToPoint3D(((geoLine) geoEntity).EndPoint));
      eyeEntity.EntityData = (object) new ClipperOffset();
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_sortDirection(geoEntity.Direction);
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_typeDefination(geoEntity.TypeDefination);
    }
    if (geoEntity.GetType() == typeof (geoArc))
    {
      if (buConversion5.EQ(Math.Abs(((geoArc) geoEntity).EndAngle - ((geoArc) geoEntity).StartAngle), 360.0))
      {
        eyeEntity = (Entity) new Circle(buVector5.WorkPlaneToPlane(geoEntity.Plane), buString5.Pnt3DToPoint3D(((geoArc) geoEntity).CenterPoint), ((geoArc) geoEntity).Radius);
        eyeEntity.EntityData = (object) new ClipperOffset();
      }
      else
      {
        eyeEntity = (Entity) new Arc(buVector5.WorkPlaneToPlane(geoEntity.Plane), buString5.Pnt3DToPoint3D(((geoArc) geoEntity).CenterPoint), ((geoArc) geoEntity).Radius, Utility.DegToRad(((geoArc) geoEntity).StartAngle), Utility.DegToRad(((geoArc) geoEntity).EndAngle));
        eyeEntity.EntityData = (object) new ClipperOffset();
      }
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_sortDirection(geoEntity.Direction);
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_typeDefination(geoEntity.TypeDefination);
    }
    if (geoEntity.GetType() == typeof (geoCircle))
    {
      eyeEntity = (Entity) new Circle(buVector5.WorkPlaneToPlane(geoEntity.Plane), buString5.Pnt3DToPoint3D(((geoCircle) geoEntity).CenterPoint), ((geoCircle) geoEntity).Radius);
      eyeEntity.EntityData = (object) new ClipperOffset();
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_sortDirection(geoEntity.Direction);
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_typeDefination(geoEntity.TypeDefination);
    }
    if (geoEntity.GetType() == typeof (geoEllipse) | geoEntity.GetType() == typeof (geoBSpline) | geoEntity.GetType() == typeof (geoPolyline))
    {
      eyeEntity = (Entity) new LinearPath((ICollection<Point3D>) buString5.Pnt3dToPoint3D(geoEntity.Vertice));
      eyeEntity.EntityData = (object) new ClipperOffset();
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_sortDirection(geoEntity.Direction);
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_typeDefination(geoEntity.TypeDefination);
    }
    if (geoEntity.GetType() == typeof (geoPoint))
    {
      eyeEntity = (Entity) new devDept.Eyeshot.Entities.Point(buString5.Pnt3DToPoint3D(((geoPoint) geoEntity).StartPoint));
      eyeEntity.EntityData = (object) new ClipperOffset();
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_sortDirection(geoEntity.Direction);
      ((CutterRuntimeSettings) eyeEntity.EntityData).set_typeDefination(geoEntity.TypeDefination);
    }
    if (!(eyeEntity != null & geoEntity != null))
      return;
    eyeEntity.LayerName = geoEntity.LayerName;
  }

  public static void geoEntityToEyeEntity(List<geoEntity> geoEntity, ref List<Entity> eyeEntity)
  {
    eyeEntity.Clear();
    for (int index = 0; index <= geoEntity.Count - 1; ++index)
    {
      Entity eyeEntity1 = (Entity) null;
      buString5.geoEntityToEyeEntity(geoEntity[index], ref eyeEntity1);
      if (eyeEntity1 != null)
        eyeEntity.Add(eyeEntity1);
    }
  }

  public static void geoEntityToEyeEntity(
    List<List<geoEntity>> geoEntity,
    ref List<List<Entity>> eyeEntity)
  {
    eyeEntity.Clear();
    for (int index1 = 0; index1 <= geoEntity.Count - 1; ++index1)
    {
      List<Entity> entityList = new List<Entity>();
      for (int index2 = 0; index2 <= geoEntity[index1].Count - 1; ++index2)
      {
        Entity eyeEntity1 = (Entity) null;
        buString5.geoEntityToEyeEntity(geoEntity[index1][index2], ref eyeEntity1);
        if (eyeEntity1 != null)
          entityList.Add(eyeEntity1);
      }
      if (entityList.Count > 0)
        eyeEntity.Add(entityList);
    }
  }

  public static void buEntityToEEntities(buEntity eyeEntity, Color color, ref eEntities buEntity)
  {
    try
    {
      eyeEntity.GetType().ToString();
      if (eyeEntity.GetType() == typeof (devDept.Eyeshot.Entities.Point))
      {
        buEntity = (eEntities) new ePoint(buString5.Point3DToPnt3D(((CustomData) eyeEntity).StartPoint));
        buEntity.dispColor = ((CustomDataSurrogate) eyeEntity).Color;
        buEntity.dispThickness = (float) ((CustomDataSurrogate) eyeEntity).Thickness;
      }
      if (eyeEntity.GetType() == typeof (buCurve))
      {
        List<Pnt3D> Vertices = new List<Pnt3D>();
        for (int index = 0; index <= ((CustomDataSurrogate) eyeEntity).Vertices.Count - 1; ++index)
          Vertices.Add(new Pnt3D(((CustomDataSurrogate) eyeEntity).Vertices[index].X, ((CustomDataSurrogate) eyeEntity).Vertices[index].Y, ((CustomDataSurrogate) eyeEntity).Vertices[index].Z));
        buEntity = (eEntities) new ePolyline(Vertices);
        buEntity.dispColor = ((CustomDataSurrogate) eyeEntity).Color;
        buEntity.dispThickness = (float) ((CustomDataSurrogate) eyeEntity).Thickness;
      }
      if (eyeEntity.GetType() == typeof (buCompositeCurve))
      {
        List<Pnt3D> Vertices = new List<Pnt3D>();
        for (int index = 0; index <= ((CustomDataSurrogate) eyeEntity).Vertices.Count - 1; ++index)
          Vertices.Add(new Pnt3D(((CustomDataSurrogate) eyeEntity).Vertices[index].X, ((CustomDataSurrogate) eyeEntity).Vertices[index].Y, ((CustomDataSurrogate) eyeEntity).Vertices[index].Z));
        buEntity = (eEntities) new ePolyline(Vertices);
        buEntity.dispColor = ((CustomDataSurrogate) eyeEntity).Color;
        buEntity.dispThickness = (float) ((CustomDataSurrogate) eyeEntity).Thickness;
      }
      if (eyeEntity.GetType() == typeof (buLine))
      {
        buEntity = (eEntities) new eLine(buString5.Point3DToPnt3D(((CustomData) eyeEntity).StartPoint), buString5.Point3DToPnt3D(((CustomData) eyeEntity).EndPoint));
        buEntity.dispColor = ((CustomDataSurrogate) eyeEntity).Color;
        buEntity.dispThickness = (float) ((CustomDataSurrogate) eyeEntity).Thickness;
      }
      if (eyeEntity.GetType() == typeof (buArc))
      {
        buEntity = (eEntities) new eArc(buString5.Point3DToPnt3D(((CustomData) eyeEntity).StartPoint), buString5.Point3DToPnt3D(((CustomData) eyeEntity).MiddlePoint), buString5.Point3DToPnt3D(((CustomData) eyeEntity).EndPoint), new WorkPlane());
        buEntity.dispColor = ((CustomDataSurrogate) eyeEntity).Color;
        buEntity.dispThickness = (float) ((CustomDataSurrogate) eyeEntity).Thickness;
      }
      if (eyeEntity.GetType() == typeof (buCircle))
      {
        buEntity = (eEntities) new eCircle(buString5.Point3DToPnt3D(((CustomDataSurrogate) eyeEntity).Center), ((CustomDataSurrogate) eyeEntity).Radius, new WorkPlane());
        buEntity.dispColor = ((CustomDataSurrogate) eyeEntity).Color;
        buEntity.dispThickness = (float) ((CustomDataSurrogate) eyeEntity).Thickness;
      }
      if (eyeEntity.GetType() == typeof (buLinearPath))
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(((CustomDataSurrogate) eyeEntity).Vertices, ref CopiedPnt);
        buEntity = (eEntities) new ePolyline(CopiedPnt);
        buEntity.dispColor = ((CustomDataSurrogate) eyeEntity).Color;
        buEntity.dispThickness = (float) ((CustomDataSurrogate) eyeEntity).Thickness;
      }
      if (eyeEntity.GetType() == typeof (buText))
      {
        buEntity = (eEntities) new eText(buString5.Point3DToPnt3D(((\u0015.\u0001) eyeEntity).Plane.Origin), ((\u0015.\u0001) eyeEntity).TextString, ((\u0015.\u0001) eyeEntity).Height, new WorkPlane());
        buEntity.dispColor = ((CustomDataSurrogate) eyeEntity).Color;
        buEntity.dispThickness = (float) ((CustomDataSurrogate) eyeEntity).Thickness;
      }
      if (!(eyeEntity.GetType() == typeof (buMesh)))
        return;
      List<TriangleIndex> trianglesindex = new List<TriangleIndex>();
      for (int index = 0; index <= ((MyFileSerializer) eyeEntity).Triangles.Count - 1; ++index)
      {
        int num1 = int.Parse(((MyFileSerializer) eyeEntity).Triangles[index].V1.ToString());
        int num2 = int.Parse(((MyFileSerializer) eyeEntity).Triangles[index].V2.ToString());
        int num3 = int.Parse(((MyFileSerializer) eyeEntity).Triangles[index].V3.ToString());
        trianglesindex.Add(new TriangleIndex()
        {
          V1 = num1,
          V2 = num2,
          V3 = num3
        });
      }
      List<Pnt3D> vertices = new List<Pnt3D>();
      for (int index = 0; index <= ((CustomDataSurrogate) eyeEntity).Vertices.Count - 1; ++index)
      {
        Pnt3D pnt3D = new Pnt3D(((CustomDataSurrogate) eyeEntity).Vertices[index].X, ((CustomDataSurrogate) eyeEntity).Vertices[index].Y, ((CustomDataSurrogate) eyeEntity).Vertices[index].Z);
        vertices.Add(pnt3D);
      }
      buEntity = (eEntities) new eMesh(trianglesindex, vertices, color);
      if (((CustomData) eyeEntity).BoxMax != (Point3D) null)
        buEntity.geoMaxPoint = new Pnt3D(((CustomData) eyeEntity).BoxMax.X, ((CustomData) eyeEntity).BoxMax.Y, ((CustomData) eyeEntity).BoxMax.Z);
      if (!(((CustomData) eyeEntity).BoxMin != (Point3D) null))
        return;
      buEntity.geoMaxPoint = new Pnt3D(((CustomData) eyeEntity).BoxMin.X, ((CustomData) eyeEntity).BoxMin.Y, ((CustomData) eyeEntity).BoxMin.Z);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void buEntityGroupToEEntities(
    buEntitiesGroup EntGroup,
    ref List<eEntities> copiedEntity,
    bool Inside = true,
    bool OpenEntities = true,
    bool Solid = false,
    bool Text = false)
  {
    copiedEntity.Clear();
    if (((\u0084.\u0001) EntGroup.Outside).Entities.Count > 0)
    {
      for (int index = 0; index <= ((\u0084.\u0001) EntGroup.Outside).Entities.Count - 1; ++index)
      {
        eEntities buEntity = (eEntities) null;
        buString5.buEntityToEEntities(((\u0084.\u0001) EntGroup.Outside).Entities[index], ((CustomDataSurrogate) ((\u0084.\u0001) EntGroup.Outside).Entities[index]).Color, ref buEntity);
        if (buEntity != null)
          copiedEntity.Add(buEntity);
      }
    }
    if ((EntGroup.Inside == null ? 0 : (EntGroup.Inside.Count > 0 & Inside ? 1 : 0)) != 0)
    {
      for (int index1 = 0; index1 <= EntGroup.Inside.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ((\u0084.\u0001) EntGroup.Inside[index1]).Entities.Count - 1; ++index2)
        {
          eEntities buEntity = (eEntities) null;
          buString5.buEntityToEEntities(((\u0084.\u0001) EntGroup.Inside[index1]).Entities[index2], ((CustomDataSurrogate) ((\u0084.\u0001) EntGroup.Inside[index1]).Entities[index2]).Color, ref buEntity);
          if (buEntity != null)
            copiedEntity.Add(buEntity);
        }
      }
    }
    if ((EntGroup.OpenEntities == null ? 0 : (EntGroup.OpenEntities.Count > 0 & OpenEntities ? 1 : 0)) == 0)
      return;
    for (int index3 = 0; index3 <= EntGroup.OpenEntities.Count - 1; ++index3)
    {
      for (int index4 = 0; index4 <= ((\u0084.\u0001) EntGroup.OpenEntities[index3]).Entities.Count - 1; ++index4)
      {
        eEntities buEntity = (eEntities) null;
        buString5.buEntityToEEntities(((\u0084.\u0001) EntGroup.OpenEntities[index3]).Entities[index4], ((CustomDataSurrogate) ((\u0084.\u0001) EntGroup.OpenEntities[index3]).Entities[index4]).Color, ref buEntity);
        if (buEntity != null)
          copiedEntity.Add(buEntity);
      }
    }
  }

  public static void eyeEntityToEEntities(Entity eyeEntity, Color color, ref eEntities buEntity)
  {
    try
    {
      eyeEntity.GetType().ToString();
      if (eyeEntity.GetType() == typeof (devDept.Eyeshot.Entities.Point))
      {
        buEntity = (eEntities) new ePoint(buString5.Point3DToPnt3D(((devDept.Eyeshot.Entities.Point) eyeEntity).StartPoint));
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Curve))
      {
        eyeEntity.Regen(0.01);
        List<Pnt3D> Vertices = new List<Pnt3D>();
        for (int index = 0; index <= eyeEntity.Vertices.Length - 1; ++index)
          Vertices.Add(new Pnt3D(eyeEntity.Vertices[index].X, eyeEntity.Vertices[index].Y, eyeEntity.Vertices[index].Z));
        buEntity = (eEntities) new ePolyline(Vertices);
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (CompositeCurve))
      {
        eyeEntity.Regen(0.01);
        List<Pnt3D> Vertices = new List<Pnt3D>();
        for (int index = 0; index <= eyeEntity.Vertices.Length - 1; ++index)
          Vertices.Add(new Pnt3D(eyeEntity.Vertices[index].X, eyeEntity.Vertices[index].Y, eyeEntity.Vertices[index].Z));
        buEntity = (eEntities) new ePolyline(Vertices);
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Line))
      {
        buEntity = (eEntities) new eLine(buString5.Point3DToPnt3D(((Line) eyeEntity).StartPoint), buString5.Point3DToPnt3D(((Line) eyeEntity).EndPoint));
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Arc))
      {
        buEntity = (eEntities) new eArc(buString5.Point3DToPnt3D(((Circle) eyeEntity).StartPoint), buString5.Point3DToPnt3D(((Arc) eyeEntity).MidPoint), buString5.Point3DToPnt3D(((Circle) eyeEntity).EndPoint), new WorkPlane());
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Circle))
      {
        buEntity = (eEntities) new eCircle(buString5.Point3DToPnt3D(((Circle) eyeEntity).Center), ((Circle) eyeEntity).Radius, new WorkPlane());
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (LinearPath))
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        buEntity = (eEntities) new ePolyline(CopiedPnt);
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (LinearPathEx))
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        buEntity = (eEntities) new ePolyline(CopiedPnt);
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Text))
      {
        buEntity = (eEntities) new eText(buString5.Point3DToPnt3D(((PlanarEntity) eyeEntity).Plane.Origin), ((Text) eyeEntity).TextString, ((Text) eyeEntity).Height, new WorkPlane());
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (MultilineText))
      {
        string TextString_ = ((Text) eyeEntity).TextString.Replace("\r\n", " ");
        buEntity = (eEntities) new eText(buString5.Point3DToPnt3D(((PlanarEntity) eyeEntity).Plane.Origin), TextString_, ((Text) eyeEntity).Height, new WorkPlane());
        buEntity.dispColor = eyeEntity.Color;
        buEntity.dispThickness = eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Mesh))
      {
        List<TriangleIndex> trianglesindex = new List<TriangleIndex>();
        for (int index = 0; index <= ((Mesh) eyeEntity).Triangles.Length - 1; ++index)
        {
          int num1 = int.Parse(((Mesh) eyeEntity).Triangles[index].V1.ToString());
          int num2 = int.Parse(((Mesh) eyeEntity).Triangles[index].V2.ToString());
          int num3 = int.Parse(((Mesh) eyeEntity).Triangles[index].V3.ToString());
          trianglesindex.Add(new TriangleIndex()
          {
            V1 = num1,
            V2 = num2,
            V3 = num3
          });
        }
        List<Pnt3D> vertices = new List<Pnt3D>();
        for (int index = 0; index <= ((Mesh) eyeEntity).Vertices.Length - 1; ++index)
        {
          Pnt3D pnt3D = new Pnt3D(((Mesh) eyeEntity).Vertices[index].X, ((Mesh) eyeEntity).Vertices[index].Y, ((Mesh) eyeEntity).Vertices[index].Z);
          vertices.Add(pnt3D);
        }
        buEntity = (eEntities) new eMesh(trianglesindex, vertices, color);
        if (eyeEntity.BoxMax == (Point3D) null)
          eyeEntity.Regen(0.01);
        if (eyeEntity.BoxMax != (Point3D) null)
          buEntity.geoMaxPoint = new Pnt3D(eyeEntity.BoxMax.X, eyeEntity.BoxMax.Y, eyeEntity.BoxMax.Z);
        if (eyeEntity.BoxMin != (Point3D) null)
          buEntity.geoMaxPoint = new Pnt3D(eyeEntity.BoxMin.X, eyeEntity.BoxMin.Y, eyeEntity.BoxMin.Z);
      }
      if (eyeEntity.GetType() == typeof (Solid))
        buEntity = (eEntities) new eSolid3D();
      if (!(eyeEntity.GetType() == typeof (devDept.Eyeshot.Entities.Region)))
        return;
      devDept.Eyeshot.Entities.Region region1 = new devDept.Eyeshot.Entities.Region();
      devDept.Eyeshot.Entities.Region region2 = (devDept.Eyeshot.Entities.Region) eyeEntity;
      if (region2.ContourList.Count > 0)
      {
        for (int index1 = 0; index1 <= region2.ContourList.Count - 1; ++index1)
        {
          CompositeCurve compositeCurve = new CompositeCurve(Array.Empty<ICurve>());
          CompositeCurve contour = (CompositeCurve) region2.ContourList[index1];
          List<Pnt3D> pnt3DList = new List<Pnt3D>();
          for (int index2 = 0; index2 <= contour.CurveList.Count - 1; ++index2)
          {
            Entity curve = (Entity) contour.CurveList[index2];
            curve.Regen(0.01);
            if (curve.Vertices != null)
            {
              for (int index3 = 0; index3 <= curve.Vertices.Length - 1; ++index3)
                pnt3DList.Add(new Pnt3D(curve.Vertices[index3].X, curve.Vertices[index3].Y, curve.Vertices[index3].Z));
            }
          }
        }
      }
      eyeEntity.Regen(0.01);
      if (eyeEntity.EntityData == null || !(eyeEntity.EntityData is CustomData))
        return;
      buEntity.TypeDefination = ((CutterRuntimeSettings) eyeEntity.EntityData).get_typeDefination();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void eyeEntityToEEntities(
    List<Entity> eyeEntity,
    Color color,
    ref List<eEntities> buEntity)
  {
    buEntity.Clear();
    for (int index = 0; index <= eyeEntity.Count - 1; ++index)
    {
      eEntities buEntity1 = (eEntities) null;
      buString5.eyeEntityToEEntities(eyeEntity[index], color, ref buEntity1);
      if (buEntity1 != null)
        buEntity.Add(buEntity1);
    }
  }

  public static void eyeEntityToEEntities(
    List<List<Entity>> eyeEntity,
    Color color,
    ref List<List<eEntities>> buEntity)
  {
    buEntity.Clear();
    for (int index1 = 0; index1 <= eyeEntity.Count - 1; ++index1)
    {
      List<eEntities> eEntitiesList = new List<eEntities>();
      for (int index2 = 0; index2 <= eyeEntity[index1].Count - 1; ++index2)
      {
        eEntities buEntity1 = (eEntities) null;
        buString5.eyeEntityToEEntities(eyeEntity[index1][index2], color, ref buEntity1);
        if (buEntity1 != null)
          eEntitiesList.Add(buEntity1);
      }
      if (eEntitiesList.Count > 0)
        buEntity.Add(eEntitiesList);
    }
  }

  public static void eyeEntityTogeoEntities(
    Entity eyeEntity,
    Color color,
    List<LayerBase5> Layers,
    ref geoEntity geoEntity)
  {
    try
    {
      eyeEntity.GetType().ToString();
      if (eyeEntity.GetType() == typeof (devDept.Eyeshot.Entities.Point))
      {
        geoEntity = (geoEntity) new geoPoint(buString5.Point3DToPnt3D(((devDept.Eyeshot.Entities.Point) eyeEntity).StartPoint));
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Line))
      {
        geoEntity = (geoEntity) new geoLine(buString5.Point3DToPnt3D(((Line) eyeEntity).StartPoint), buString5.Point3DToPnt3D(((Line) eyeEntity).EndPoint));
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
        if (eyeEntity.EntityData != null)
          geoEntity.Direction = ((CutterIsoFileItems) eyeEntity.EntityData).get_sortDirection();
      }
      if (eyeEntity.GetType() == typeof (Arc))
      {
        geoEntity = (geoEntity) new geoArc(buString5.Point3DToPnt3D(((Circle) eyeEntity).StartPoint), buString5.Point3DToPnt3D(((Arc) eyeEntity).MidPoint), buString5.Point3DToPnt3D(((Circle) eyeEntity).EndPoint), new WorkPlane());
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Circle))
      {
        geoEntity = (geoEntity) new geoCircle(buString5.Point3DToPnt3D(((Circle) eyeEntity).Center), ((Circle) eyeEntity).Radius, new WorkPlane());
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (LinearPath))
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        geoEntity = (geoEntity) new geoPolyline(CopiedPnt);
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (CompositeCurve))
      {
        if (eyeEntity.Vertices == null)
          eyeEntity.Regen(new RegenParams(0.001));
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        geoEntity = (geoEntity) new geoPolyline(CopiedPnt);
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Curve))
      {
        if (eyeEntity.Vertices == null)
          eyeEntity.Regen(new RegenParams(0.001));
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        geoEntity = (geoEntity) new geoPolyline(CopiedPnt);
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (LinearPathEx))
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        geoEntity = (geoEntity) new geoPolyline(CopiedPnt);
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (geoEntity == null)
        return;
      geoEntity.LayerName = eyeEntity.LayerName;
      for (int index = 0; index <= Layers.Count - 1; ++index)
      {
        if (geoEntity.LayerName == ((DevideEventFormVars) Layers[index]).Name)
        {
          geoEntity.ToolName = ((ToolCamData5) ((ToolGeometry5) ((DeleteTypeEventFormVars) Layers[index]).ToolSelected).Data).Name;
          if (eyeEntity.ColorMethod == colorMethodType.byLayer)
            geoEntity.Color = ((DevideEventFormVars) Layers[index]).LayerColor;
        }
      }
      if (eyeEntity.EntityData == null)
        return;
      geoEntity.Direction = ((CutterIsoFileItems) eyeEntity.EntityData).get_sortDirection();
      geoEntity.TypeDefination = ((CutterRuntimeSettings) eyeEntity.EntityData).get_typeDefination();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void eyeEntityTogeoEntities(Entity eyeEntity, Color color, ref geoEntity geoEntity)
  {
    try
    {
      eyeEntity.GetType().ToString();
      if (eyeEntity.GetType() == typeof (devDept.Eyeshot.Entities.Point))
      {
        geoEntity = (geoEntity) new geoPoint(buString5.Point3DToPnt3D(((devDept.Eyeshot.Entities.Point) eyeEntity).StartPoint));
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Line))
      {
        geoEntity = (geoEntity) new geoLine(buString5.Point3DToPnt3D(((Line) eyeEntity).StartPoint), buString5.Point3DToPnt3D(((Line) eyeEntity).EndPoint));
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
        if (eyeEntity.EntityData != null)
          geoEntity.Direction = ((CutterIsoFileItems) eyeEntity.EntityData).get_sortDirection();
      }
      if (eyeEntity.GetType() == typeof (Arc))
      {
        geoEntity = (geoEntity) new geoArc(buString5.Point3DToPnt3D(((Circle) eyeEntity).StartPoint), buString5.Point3DToPnt3D(((Arc) eyeEntity).MidPoint), buString5.Point3DToPnt3D(((Circle) eyeEntity).EndPoint), new WorkPlane());
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Circle))
      {
        geoEntity = (geoEntity) new geoCircle(buString5.Point3DToPnt3D(((Circle) eyeEntity).Center), ((Circle) eyeEntity).Radius, new WorkPlane());
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (LinearPath))
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        geoEntity = (geoEntity) new geoPolyline(CopiedPnt);
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (CompositeCurve))
      {
        if (eyeEntity.Vertices == null)
          eyeEntity.Regen(new RegenParams(0.001));
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        geoEntity = (geoEntity) new geoPolyline(CopiedPnt);
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (Curve))
      {
        if (eyeEntity.Vertices == null)
          eyeEntity.Regen(new RegenParams(0.001));
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        geoEntity = (geoEntity) new geoPolyline(CopiedPnt);
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (eyeEntity.GetType() == typeof (LinearPathEx))
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        buString5.Point3DToPnt3D(eyeEntity.Vertices, ref CopiedPnt);
        geoEntity = (geoEntity) new geoPolyline(CopiedPnt);
        geoEntity.Color = eyeEntity.Color;
        geoEntity.Thickness = (double) eyeEntity.LineWeight;
      }
      if (geoEntity == null)
        return;
      geoEntity.LayerName = eyeEntity.LayerName;
      if (eyeEntity.EntityData == null)
        return;
      geoEntity.Direction = ((CutterIsoFileItems) eyeEntity.EntityData).get_sortDirection();
      geoEntity.TypeDefination = ((CutterRuntimeSettings) eyeEntity.EntityData).get_typeDefination();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void eyeEntityTogeoEntities(
    List<Entity> eyeEntity,
    Color color,
    ref List<geoEntity> geoEntity)
  {
    geoEntity.Clear();
    for (int index = 0; index <= eyeEntity.Count - 1; ++index)
    {
      geoEntity geoEntity1 = (geoEntity) null;
      buString5.eyeEntityTogeoEntities(eyeEntity[index], color, ref geoEntity1);
      if (geoEntity1 != null)
        geoEntity.Add(geoEntity1);
    }
  }

  public static void eyeEntityTogeoEntities(
    List<Entity> eyeEntity,
    Color color,
    List<LayerBase5> Layers,
    ref List<geoEntity> geoEntity)
  {
    geoEntity.Clear();
    for (int index = 0; index <= eyeEntity.Count - 1; ++index)
    {
      geoEntity geoEntity1 = (geoEntity) null;
      buString5.eyeEntityTogeoEntities(eyeEntity[index], color, Layers, ref geoEntity1);
      if (geoEntity1 != null)
        geoEntity.Add(geoEntity1);
    }
  }

  public static void eyeEntityTogeoEntities(
    List<List<Entity>> eyeEntity,
    Color color,
    ref List<List<geoEntity>> geoEntity)
  {
    geoEntity.Clear();
    for (int index1 = 0; index1 <= eyeEntity.Count - 1; ++index1)
    {
      List<geoEntity> geoEntityList = new List<geoEntity>();
      for (int index2 = 0; index2 <= eyeEntity[index1].Count - 1; ++index2)
      {
        geoEntity geoEntity1 = (geoEntity) null;
        buString5.eyeEntityTogeoEntities(eyeEntity[index1][index2], color, ref geoEntity1);
        if (geoEntity1 != null)
          geoEntityList.Add(geoEntity1);
      }
      if (geoEntityList.Count > 0)
        geoEntity.Add(geoEntityList);
    }
  }
}
