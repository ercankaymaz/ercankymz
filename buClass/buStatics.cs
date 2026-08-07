// Decompiled with JetBrains decompiler
// Type: buClass.buStatics
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

#nullable disable
namespace buClass;

public class buStatics
{
  public static void LoadbuClassLanguages(string FileName, int Language)
  {
    List<Type> list = ((IEnumerable<Type>) Assembly.GetExecutingAssembly().GetTypes()).Where<Type>((Func<Type, bool>) (t => t.Namespace == "buClass")).ToList<Type>();
    List<string> StringList = new List<string>();
    buStatics.OpenFromFile(FileName, ref StringList);
    for (int index1 = 0; index1 <= list.Count - 1; ++index1)
    {
      if (list[index1].GetType().IsClass & !list[index1].GetType().IsEnum)
      {
        FieldInfo[] fields = list[index1].GetFields();
        if (fields != null)
        {
          for (int index2 = 0; index2 <= fields.Length - 1; ++index2)
          {
            if (fields[index2].IsStatic && fields[index2].Name == "Captions" | fields[index2].Name == "Caption")
            {
              List<string> CalcList = new List<string>();
              string name = list[index1].Name;
              buStatics.GetItemsAccordingToTheLang(buStatics.ReadXmlItem($"<{name}>", $"</{name}>", StringList), Language, ref CalcList);
              if (CalcList.Count > 0)
                fields[index2].SetValue((object) list[index1], (object) CalcList);
            }
          }
        }
      }
    }
  }

  public static void GetItemsAccordingToTheLang(
    List<string> RefList,
    int Language,
    ref List<string> CalcList)
  {
    try
    {
      if (RefList.Count <= 0)
        return;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        string[] strArray1 = RefList[index].Split('|');
        if (strArray1.Length > 1)
        {
          string[] strArray2 = strArray1[1].Split(';');
          if (Language <= strArray2.Length - 1)
            CalcList.Add(strArray2[Language].Trim());
        }
        else
        {
          string[] strArray3 = RefList[index].Split(';');
          if (Language <= strArray3.Length - 1)
            CalcList.Add(strArray3[Language].Trim());
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (GetItemsAccordingToTheLang), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static List<string> ReadXmlItem(
    string StartString,
    string EndString,
    List<string> SourceList)
  {
    try
    {
      List<string> stringList = new List<string>();
      bool flag = false;
      for (int index = 0; index <= SourceList.Count - 1 && !(SourceList[index].ToString().Trim() == EndString); ++index)
      {
        if (flag)
          stringList.Add(SourceList[index].ToString().Trim());
        SourceList[index].ToString().Trim();
        if (SourceList[index].ToString().Trim() == StartString)
          flag = true;
      }
      return stringList;
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (ReadXmlItem), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new List<string>();
    }
  }

  public static void BoxSizeCalculate(List<Pnt3D> Points, ref Pnt3D MinPoint, ref Pnt3D MaxPoint)
  {
    try
    {
      if (Points.Count == 0)
      {
        MinPoint = new Pnt3D();
        MaxPoint = new Pnt3D();
      }
      else
      {
        MinPoint = new Pnt3D(double.MaxValue, double.MaxValue, double.MaxValue);
        MaxPoint = new Pnt3D(double.MinValue, double.MinValue, double.MinValue);
        for (int index = 0; index <= Points.Count - 1; ++index)
        {
          if (Points[index].X > MaxPoint.X)
            MaxPoint.X = Points[index].X;
          if (Points[index].Y > MaxPoint.Y)
            MaxPoint.Y = Points[index].Y;
          if (Points[index].Z > MaxPoint.Z)
            MaxPoint.Z = Points[index].Z;
          if (Points[index].X < MinPoint.X)
            MinPoint.X = Points[index].X;
          if (Points[index].Y < MinPoint.Y)
            MinPoint.Y = Points[index].Y;
          if (Points[index].Z < MinPoint.Z)
            MinPoint.Z = Points[index].Z;
        }
      }
    }
    catch (Exception ex)
    {
      string str = "Count: " + Points.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void BoxSizeCalculate(
    List<List<Pnt3D>> Points,
    ref Pnt3D MinPoint,
    ref Pnt3D MaxPoint)
  {
    try
    {
      MinPoint = new Pnt3D(double.MaxValue, double.MaxValue, double.MaxValue);
      MaxPoint = new Pnt3D(double.MinValue, double.MinValue, double.MinValue);
      for (int index1 = 0; index1 <= Points.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= Points[index1].Count - 1; ++index2)
        {
          if (Points[index1][index2].X > MaxPoint.X)
            MaxPoint.X = Points[index1][index2].X;
          if (Points[index1][index2].Y > MaxPoint.Y)
            MaxPoint.Y = Points[index1][index2].Y;
          if (Points[index1][index2].Z > MaxPoint.Z)
            MaxPoint.Z = Points[index1][index2].Z;
          if (Points[index1][index2].X < MinPoint.X)
            MinPoint.X = Points[index1][index2].X;
          if (Points[index1][index2].Y < MinPoint.Y)
            MinPoint.Y = Points[index1][index2].Y;
          if (Points[index1][index2].Z < MinPoint.Z)
            MinPoint.Z = Points[index1][index2].Z;
        }
      }
    }
    catch (Exception ex)
    {
      string str = "Count: " + Points.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static double Length3D(Pnt3D Pnt1, Pnt3D Pnt2)
  {
    try
    {
      return Math.Sqrt((Pnt1.X - Pnt2.X) * (Pnt1.X - Pnt2.X) + (Pnt1.Y - Pnt2.Y) * (Pnt1.Y - Pnt2.Y) + (Pnt1.Z - Pnt2.Z) * (Pnt1.Z - Pnt2.Z));
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return 0.0;
    }
  }

  public static double Length3D(List<Pnt3D> Points)
  {
    double num = 0.0;
    try
    {
      for (int index = 1; index < Points.Count; ++index)
        num += Math.Sqrt((Points[index].X - Points[index - 1].X) * (Points[index].X - Points[index - 1].X) + (Points[index].Y - Points[index - 1].Y) * (Points[index].Y - Points[index - 1].Y) + (Points[index].Z - Points[index - 1].Z) * (Points[index].Z - Points[index - 1].Z));
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
    return num;
  }

  public static void EllipseToLineerByCount(
    Pnt3D Center,
    double Major,
    double Minor,
    double Angle,
    int Count,
    WorkPlane Plane,
    ref List<Pnt3D> Vertices)
  {
    try
    {
      buStatics.ArcEllipseToLineerByCount(Center, Major, Minor, 0.0, 360.0, Angle, Count, Plane, ref Vertices);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ArcEllipseToLineerByCount(
    Pnt3D Center,
    double Major,
    double Minor,
    double StartAngle,
    double EndAngle,
    double Angle,
    int Count,
    WorkPlane Plane,
    ref List<Pnt3D> Vertices)
  {
    try
    {
      double num1 = 0.0;
      double num2 = 0.0;
      Pnt3D pnt3D1 = new Pnt3D();
      Vertices.Clear();
      double num3 = EndAngle - StartAngle;
      num2 = 2.0 * Math.PI * Math.Sqrt(0.5 * (Math.Pow(Major, 2.0) + Math.Pow(Minor, 2.0)));
      if (Count <= 0)
        return;
      if (Count > 0)
        num1 = num3 / (double) Count;
      double num4 = (360.0 - Angle) * Math.PI / 180.0;
      double num5 = Math.Sin(num4);
      double num6 = Math.Cos(num4);
      for (int index = 0; index <= Count; ++index)
      {
        Pnt3D pnt3D2 = new Pnt3D();
        double Degree = StartAngle + (double) index * num1;
        double num7 = Major * Math.Cos(buStatics.DegreeToRadianGreat360(Degree));
        double num8 = Minor * Math.Sin(buStatics.DegreeToRadianGreat360(Degree));
        if (Plane.PlaneType == planeType.XY)
        {
          pnt3D2.X = Center.X + num7 * num6 + num8 * num5;
          pnt3D2.Y = Center.Y - num7 * num5 + num8 * num6;
          pnt3D2.Z = Center.Z;
        }
        if (Plane.PlaneType == planeType.XZ)
        {
          pnt3D2.X = Center.X + num7 * num6 + num8 * num5;
          pnt3D2.Y = Center.Y;
          pnt3D2.Z = Center.Z - num7 * num5 + num8 * num6;
        }
        if (Plane.PlaneType == planeType.YZ)
        {
          pnt3D2.X = Center.X;
          pnt3D2.Y = Center.Y + num7 * num6 + num8 * num5;
          pnt3D2.Z = Center.Z - num7 * num5 + num8 * num6;
        }
        Vertices.Add(pnt3D2);
      }
    }
    catch (Exception ex)
    {
      string str = $"Center: {Center.ToString()} - MajRad: {Major.ToString()} - MinRad: {Minor.ToString()} - SA: {StartAngle.ToString()} - EA: {EndAngle.ToString()} - Ang: {Angle.ToString()} - Cnt: {Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void Arc3Point(
    Pnt3D FirstPoint,
    Pnt3D SecondPoint,
    Pnt3D ThirdPoint,
    WorkPlane Plane,
    ref Pnt3D Center,
    ref double Radius,
    ref double StartAngle,
    ref double EndAngle,
    ref List<Pnt3D> Vertices)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    double num4 = 0.0;
    double num5 = 0.0;
    double num6 = 0.0;
    double num7 = 0.0;
    double num8 = 0.0;
    double num9 = 0.0;
    if (Plane.PlaneType == planeType.XY)
    {
      double num10 = 0.5 * Math.Pow((Math.Pow(SecondPoint.Y, 2.0) - 2.0 * SecondPoint.Y * ThirdPoint.Y + Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(ThirdPoint.X, 2.0) - 2.0 * SecondPoint.X * ThirdPoint.X) * (-2.0 * FirstPoint.X * ThirdPoint.X + Math.Pow(FirstPoint.X, 2.0) - 2.0 * FirstPoint.Y * ThirdPoint.Y + Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(ThirdPoint.X, 2.0)) * (Math.Pow(FirstPoint.X, 2.0) - 2.0 * SecondPoint.X * FirstPoint.X + Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(SecondPoint.Y, 2.0) - 2.0 * FirstPoint.Y * SecondPoint.Y), 0.5) / (FirstPoint.X * SecondPoint.Y - FirstPoint.X * ThirdPoint.Y - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X);
      num1 = -0.5 * Math.Pow((Math.Pow(SecondPoint.Y, 2.0) - 2.0 * SecondPoint.Y * ThirdPoint.Y + Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(ThirdPoint.X, 2.0) - 2.0 * SecondPoint.X * ThirdPoint.X) * (-2.0 * FirstPoint.X * ThirdPoint.X + Math.Pow(FirstPoint.X, 2.0) - 2.0 * FirstPoint.Y * ThirdPoint.Y + Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(ThirdPoint.X, 2.0)) * (Math.Pow(FirstPoint.X, 2.0) - 2.0 * SecondPoint.X * FirstPoint.X + Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(SecondPoint.Y, 2.0) - 2.0 * FirstPoint.Y * SecondPoint.Y), 0.5) / (FirstPoint.X * SecondPoint.Y - FirstPoint.X * ThirdPoint.Y - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X);
      double num11 = 0.5 * ((SecondPoint.Y - ThirdPoint.Y) * Math.Pow(FirstPoint.X, 2.0) - FirstPoint.Y * Math.Pow(SecondPoint.X, 2.0) + ThirdPoint.Y * Math.Pow(SecondPoint.X, 2.0) - ThirdPoint.Y * Math.Pow(FirstPoint.Y, 2.0) + FirstPoint.Y * Math.Pow(ThirdPoint.X, 2.0) - SecondPoint.Y * Math.Pow(ThirdPoint.Y, 2.0) - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.Y + Math.Pow(ThirdPoint.Y, 2.0) * FirstPoint.Y + SecondPoint.Y * Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(SecondPoint.Y, 2.0) * ThirdPoint.Y - Math.Pow(SecondPoint.Y, 2.0) * FirstPoint.Y) / ((SecondPoint.Y - ThirdPoint.Y) * FirstPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X);
      num2 = 0.5 * ((SecondPoint.Y - ThirdPoint.Y) * Math.Pow(FirstPoint.X, 2.0) - FirstPoint.Y * Math.Pow(SecondPoint.X, 2.0) + ThirdPoint.Y * Math.Pow(SecondPoint.X, 2.0) - ThirdPoint.Y * Math.Pow(FirstPoint.Y, 2.0) + FirstPoint.Y * Math.Pow(ThirdPoint.X, 2.0) - SecondPoint.Y * Math.Pow(ThirdPoint.Y, 2.0) - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.Y + Math.Pow(ThirdPoint.Y, 2.0) * FirstPoint.Y + SecondPoint.Y * Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(SecondPoint.Y, 2.0) * ThirdPoint.Y - Math.Pow(SecondPoint.Y, 2.0) * FirstPoint.Y) / ((SecondPoint.Y - ThirdPoint.Y) * FirstPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X);
      double num12 = -0.5 * ((SecondPoint.X - ThirdPoint.X) * Math.Pow(FirstPoint.X, 2.0) + (Math.Pow(ThirdPoint.X, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) - Math.Pow(SecondPoint.X, 2.0) - Math.Pow(SecondPoint.Y, 2.0)) * FirstPoint.X - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.X, 2.0) + Math.Pow(FirstPoint.Y, 2.0) * SecondPoint.X - Math.Pow(FirstPoint.Y, 2.0) * ThirdPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.Y, 2.0) - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.X) / ((SecondPoint.Y - ThirdPoint.Y) * FirstPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X);
      num3 = -0.5 * ((SecondPoint.X - ThirdPoint.X) * Math.Pow(FirstPoint.X, 2.0) + (Math.Pow(ThirdPoint.X, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) - Math.Pow(SecondPoint.X, 2.0) - Math.Pow(SecondPoint.Y, 2.0)) * FirstPoint.X - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.X, 2.0) + Math.Pow(FirstPoint.Y, 2.0) * SecondPoint.X - Math.Pow(FirstPoint.Y, 2.0) * ThirdPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.Y, 2.0) - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.X) / ((SecondPoint.Y - ThirdPoint.Y) * FirstPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X);
      Radius = Math.Abs(num10);
      Center.X = num11;
      Center.Y = num12;
      Center.Z = FirstPoint.Z;
      num5 = buStatics.PointAngle(FirstPoint.X, FirstPoint.Y, Center.X, Center.Y);
      num6 = buStatics.PointAngle(SecondPoint.X, SecondPoint.Y, Center.X, Center.Y);
      num7 = buStatics.PointAngle(ThirdPoint.X, ThirdPoint.Y, Center.X, Center.Y);
    }
    if (Plane.PlaneType == planeType.XZ)
    {
      double num13 = 0.5 * Math.Pow((Math.Pow(SecondPoint.Z, 2.0) - 2.0 * SecondPoint.Z * ThirdPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(ThirdPoint.X, 2.0) - 2.0 * SecondPoint.X * ThirdPoint.X) * (-2.0 * FirstPoint.X * ThirdPoint.X + Math.Pow(FirstPoint.X, 2.0) - 2.0 * FirstPoint.Z * ThirdPoint.Z + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(ThirdPoint.X, 2.0)) * (Math.Pow(FirstPoint.X, 2.0) - 2.0 * SecondPoint.X * FirstPoint.X + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(SecondPoint.Z, 2.0) - 2.0 * FirstPoint.Z * SecondPoint.Z), 0.5) / (FirstPoint.X * SecondPoint.Z - FirstPoint.X * ThirdPoint.Z - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X);
      num1 = -0.5 * Math.Pow((Math.Pow(SecondPoint.Z, 2.0) - 2.0 * SecondPoint.Z * ThirdPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(ThirdPoint.X, 2.0) - 2.0 * SecondPoint.X * ThirdPoint.X) * (-2.0 * FirstPoint.X * ThirdPoint.X + Math.Pow(FirstPoint.X, 2.0) - 2.0 * FirstPoint.Z * ThirdPoint.Z + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(ThirdPoint.X, 2.0)) * (Math.Pow(FirstPoint.X, 2.0) - 2.0 * SecondPoint.X * FirstPoint.X + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(SecondPoint.Z, 2.0) - 2.0 * FirstPoint.Z * SecondPoint.Z), 0.5) / (FirstPoint.X * SecondPoint.Z - FirstPoint.X * ThirdPoint.Z - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X);
      double num14 = 0.5 * ((SecondPoint.Z - ThirdPoint.Z) * Math.Pow(FirstPoint.X, 2.0) - FirstPoint.Z * Math.Pow(SecondPoint.X, 2.0) + ThirdPoint.Z * Math.Pow(SecondPoint.X, 2.0) - ThirdPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + FirstPoint.Z * Math.Pow(ThirdPoint.X, 2.0) - SecondPoint.Z * Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) * FirstPoint.Z + SecondPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Z, 2.0) * ThirdPoint.Z - Math.Pow(SecondPoint.Z, 2.0) * FirstPoint.Z) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X);
      num2 = 0.5 * ((SecondPoint.Z - ThirdPoint.Z) * Math.Pow(FirstPoint.X, 2.0) - FirstPoint.Z * Math.Pow(SecondPoint.X, 2.0) + ThirdPoint.Z * Math.Pow(SecondPoint.X, 2.0) - ThirdPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + FirstPoint.Z * Math.Pow(ThirdPoint.X, 2.0) - SecondPoint.Z * Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) * FirstPoint.Z + SecondPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Z, 2.0) * ThirdPoint.Z - Math.Pow(SecondPoint.Z, 2.0) * FirstPoint.Z) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X);
      double num15 = -0.5 * ((SecondPoint.X - ThirdPoint.X) * Math.Pow(FirstPoint.X, 2.0) + (Math.Pow(ThirdPoint.X, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(SecondPoint.X, 2.0) - Math.Pow(SecondPoint.Z, 2.0)) * FirstPoint.X - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.X, 2.0) + Math.Pow(FirstPoint.Z, 2.0) * SecondPoint.X - Math.Pow(FirstPoint.Z, 2.0) * ThirdPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.Z, 2.0) - Math.Pow(ThirdPoint.Z, 2.0) * SecondPoint.X) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X);
      num4 = -0.5 * ((SecondPoint.X - ThirdPoint.X) * Math.Pow(FirstPoint.X, 2.0) + (Math.Pow(ThirdPoint.X, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(SecondPoint.X, 2.0) - Math.Pow(SecondPoint.Z, 2.0)) * FirstPoint.X - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.X, 2.0) + Math.Pow(FirstPoint.Z, 2.0) * SecondPoint.X - Math.Pow(FirstPoint.Z, 2.0) * ThirdPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.Z, 2.0) - Math.Pow(ThirdPoint.Z, 2.0) * SecondPoint.X) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X);
      Radius = Math.Abs(num13);
      Center.X = num14;
      Center.Z = num15;
      Center.Y = FirstPoint.Y;
      num5 = buStatics.PointAngle(FirstPoint.X, FirstPoint.Z, Center.X, Center.Z);
      num6 = buStatics.PointAngle(SecondPoint.X, SecondPoint.Z, Center.X, Center.Z);
      num7 = buStatics.PointAngle(ThirdPoint.X, ThirdPoint.Z, Center.X, Center.Z);
    }
    if (Plane.PlaneType == planeType.YZ)
    {
      double num16 = 0.5 * Math.Pow((Math.Pow(SecondPoint.Z, 2.0) - 2.0 * SecondPoint.Z * ThirdPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) - 2.0 * SecondPoint.Y * ThirdPoint.Y) * (-2.0 * FirstPoint.Y * ThirdPoint.Y + Math.Pow(FirstPoint.Y, 2.0) - 2.0 * FirstPoint.Z * ThirdPoint.Z + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(ThirdPoint.Y, 2.0)) * (Math.Pow(FirstPoint.Y, 2.0) - 2.0 * SecondPoint.Y * FirstPoint.Y + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(SecondPoint.Z, 2.0) - 2.0 * FirstPoint.Z * SecondPoint.Z), 0.5) / (FirstPoint.Y * SecondPoint.Z - FirstPoint.Y * ThirdPoint.Z - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y);
      num1 = -0.5 * Math.Pow((Math.Pow(SecondPoint.Z, 2.0) - 2.0 * SecondPoint.Z * ThirdPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) - 2.0 * SecondPoint.Y * ThirdPoint.Y) * (-2.0 * FirstPoint.Y * ThirdPoint.Y + Math.Pow(FirstPoint.Y, 2.0) - 2.0 * FirstPoint.Z * ThirdPoint.Z + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(ThirdPoint.Y, 2.0)) * (Math.Pow(FirstPoint.Y, 2.0) - 2.0 * SecondPoint.Y * FirstPoint.Y + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(SecondPoint.Z, 2.0) - 2.0 * FirstPoint.Z * SecondPoint.Z), 0.5) / (FirstPoint.Y * SecondPoint.Z - FirstPoint.Y * ThirdPoint.Z - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y);
      double num17 = 0.5 * ((SecondPoint.Z - ThirdPoint.Z) * Math.Pow(FirstPoint.Y, 2.0) - FirstPoint.Z * Math.Pow(SecondPoint.Y, 2.0) + ThirdPoint.Z * Math.Pow(SecondPoint.Y, 2.0) - ThirdPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + FirstPoint.Z * Math.Pow(ThirdPoint.Y, 2.0) - SecondPoint.Z * Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) * FirstPoint.Z + SecondPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Z, 2.0) * ThirdPoint.Z - Math.Pow(SecondPoint.Z, 2.0) * FirstPoint.Z) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y);
      num3 = 0.5 * ((SecondPoint.Z - ThirdPoint.Z) * Math.Pow(FirstPoint.Y, 2.0) - FirstPoint.Z * Math.Pow(SecondPoint.Y, 2.0) + ThirdPoint.Z * Math.Pow(SecondPoint.Y, 2.0) - ThirdPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + FirstPoint.Z * Math.Pow(ThirdPoint.Y, 2.0) - SecondPoint.Z * Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) * FirstPoint.Z + SecondPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Z, 2.0) * ThirdPoint.Z - Math.Pow(SecondPoint.Z, 2.0) * FirstPoint.Z) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y);
      double num18 = -0.5 * ((SecondPoint.Y - ThirdPoint.Y) * Math.Pow(FirstPoint.Y, 2.0) + (Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(SecondPoint.Y, 2.0) - Math.Pow(SecondPoint.Z, 2.0)) * FirstPoint.Y - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.Y + ThirdPoint.Y * Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(FirstPoint.Z, 2.0) * SecondPoint.Y - Math.Pow(FirstPoint.Z, 2.0) * ThirdPoint.Y + ThirdPoint.Y * Math.Pow(SecondPoint.Z, 2.0) - Math.Pow(ThirdPoint.Z, 2.0) * SecondPoint.Y) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y);
      num4 = -0.5 * ((SecondPoint.Y - ThirdPoint.Y) * Math.Pow(FirstPoint.Y, 2.0) + (Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(SecondPoint.Y, 2.0) - Math.Pow(SecondPoint.Z, 2.0)) * FirstPoint.Y - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.Y + ThirdPoint.Y * Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(FirstPoint.Z, 2.0) * SecondPoint.Y - Math.Pow(FirstPoint.Z, 2.0) * ThirdPoint.Y + ThirdPoint.Y * Math.Pow(SecondPoint.Z, 2.0) - Math.Pow(ThirdPoint.Z, 2.0) * SecondPoint.Y) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y);
      Radius = Math.Abs(num16);
      Center.X = FirstPoint.X;
      Center.Y = num17;
      Center.Z = num18;
      num5 = buStatics.PointAngle(FirstPoint.Y, FirstPoint.Z, Center.Y, Center.Z);
      num6 = buStatics.PointAngle(SecondPoint.Y, SecondPoint.Z, Center.Y, Center.Z);
      num7 = buStatics.PointAngle(ThirdPoint.Y, ThirdPoint.Z, Center.Y, Center.Z);
    }
    if (num7 > num5)
    {
      if (num7 > num6 & num6 > num5)
      {
        num8 = num5;
        num9 = num7;
      }
      else
      {
        num9 = num5 + 360.0;
        num8 = num7;
      }
    }
    if (num5 > num7)
    {
      if (num5 > num6 & num6 > num7)
      {
        double num19 = num5;
        double num20 = num7;
        double num21 = num19;
        num8 = num20;
        num9 = num21;
      }
      else
      {
        num8 = num5;
        num9 = num7 + 360.0;
      }
    }
    StartAngle = num8;
    EndAngle = num9;
  }

  public static void ArcToLineerByCount(
    Pnt3D Center,
    double Radius,
    double SA,
    double EA,
    int Count,
    WorkPlane Plane,
    ref List<Pnt3D> Vertices)
  {
    try
    {
      double num1 = 0.0;
      double num2 = 0.0;
      Pnt3D pnt3D1 = new Pnt3D();
      if (buStatics.EQ(SA, EA))
      {
        Vertices.Clear();
      }
      else
      {
        double num3 = EA - SA;
        num2 = 2.0 * Math.PI * Radius * (EA - SA) / 360.0;
        if (Count <= 0)
        {
          Vertices.Clear();
        }
        else
        {
          if (Count > 0)
            num1 = num3 / (double) Count;
          Vertices.Clear();
          for (int index = 0; index <= Count; ++index)
          {
            Pnt3D pnt3D2 = new Pnt3D();
            if (Plane.PlaneType == planeType.XY)
            {
              pnt3D2.X = Center.X + Radius * Math.Cos(buStatics.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Y = Center.Y + Radius * Math.Sin(buStatics.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Z = Center.Z;
            }
            if (Plane.PlaneType == planeType.XZ)
            {
              pnt3D2.X = Center.X + Radius * Math.Cos(buStatics.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Y = Center.Y;
              pnt3D2.Z = Center.Z + Radius * Math.Sin(buStatics.DegreeToRadian(SA + (double) index * num1));
            }
            if (Plane.PlaneType == planeType.YZ)
            {
              pnt3D2.X = Center.X;
              pnt3D2.Y = Center.Y + Radius * Math.Cos(buStatics.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Z = Center.Z + Radius * Math.Sin(buStatics.DegreeToRadian(SA + (double) index * num1));
            }
            Vertices.Add(pnt3D2);
          }
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"Center:{Center.ToString()}R: {Radius.ToString()} - SA: {SA.ToString()} - EA: {EA.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ArcToLineer3D(
    Pnt3D Center,
    double Radius,
    double SA,
    double EA,
    double Length,
    WorkPlane Plane,
    ref List<Pnt3D> Vertices)
  {
    try
    {
      double num1 = 0.0;
      Pnt3D pnt3D1 = new Pnt3D();
      if (buStatics.EQ(SA, EA, 0.001))
      {
        Vertices.Clear();
      }
      else
      {
        double num2 = EA - SA;
        int int32 = Convert.ToInt32(2.0 * Math.PI * Radius * (EA - SA) / 360.0 / Length);
        if (int32 <= 0)
        {
          Vertices.Clear();
        }
        else
        {
          if (int32 > 0)
            num1 = num2 / (double) int32;
          Vertices.Clear();
          for (int index = 0; index <= int32; ++index)
          {
            Pnt3D pnt3D2 = new Pnt3D();
            if (Plane.PlaneType == planeType.XY)
            {
              pnt3D2.X = Center.X + Radius * Math.Cos(buStatics.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Y = Center.Y + Radius * Math.Sin(buStatics.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Z = Center.Z;
            }
            if (Plane.PlaneType == planeType.XZ)
            {
              pnt3D2.X = Center.X + Radius * Math.Cos(buStatics.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Y = Center.Y;
              pnt3D2.Z = Center.Z + Radius * Math.Sin(buStatics.DegreeToRadian(SA + (double) index * num1));
            }
            if (Plane.PlaneType == planeType.YZ)
            {
              pnt3D2.X = Center.X;
              pnt3D2.Y = Center.Y + Radius * Math.Cos(buStatics.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Z = Center.Z + Radius * Math.Sin(buStatics.DegreeToRadian(SA + (double) index * num1));
            }
            Vertices.Add(pnt3D2);
          }
        }
      }
    }
    catch (Exception ex)
    {
      string auxMessage = $"Center:{Center.ToString()}R: {Radius.ToString()} - SA: {SA.ToString()} - EA: {EA.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, auxMessage);
    }
  }

  public static void EllipseToLineer3D(
    Pnt3D Center,
    double Major,
    double Minor,
    double Angle,
    double Length,
    WorkPlane Plane,
    ref List<Pnt3D> Vertices)
  {
    try
    {
      buStatics.ArcEllipseToLineer3D(Center, Major, Minor, 0.0, 360.0, Angle, Length, Plane, ref Vertices);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ArcEllipseToLineer3D(
    Pnt3D Center,
    double Major,
    double Minor,
    double StartAngle,
    double EndAngle,
    double Angle,
    double Length,
    WorkPlane Plane,
    ref List<Pnt3D> Vertices)
  {
    try
    {
      double num1 = 0.0;
      Pnt3D pnt3D1 = new Pnt3D();
      Vertices.Clear();
      if (Length <= 0.0)
        return;
      double num2 = EndAngle - StartAngle;
      int int32 = Convert.ToInt32(2.0 * Math.PI * Math.Sqrt(0.5 * (Math.Pow(Major, 2.0) + Math.Pow(Minor, 2.0))) / Length);
      if (int32 <= 0)
        return;
      if (int32 > 0)
        num1 = num2 / (double) int32;
      double num3 = (360.0 - Angle) * Math.PI / 180.0;
      double num4 = Math.Sin(num3);
      double num5 = Math.Cos(num3);
      for (int index = 0; index <= int32; ++index)
      {
        Pnt3D pnt3D2 = new Pnt3D();
        double Degree = StartAngle + (double) index * num1;
        double num6 = Major * Math.Cos(buStatics.DegreeToRadianGreat360(Degree));
        double num7 = Minor * Math.Sin(buStatics.DegreeToRadianGreat360(Degree));
        if (Plane.PlaneType == planeType.XY)
        {
          pnt3D2.X = Center.X + num6 * num5 + num7 * num4;
          pnt3D2.Y = Center.Y - num6 * num4 + num7 * num5;
          pnt3D2.Z = Center.Z;
        }
        if (Plane.PlaneType == planeType.XZ)
        {
          pnt3D2.X = Center.X + num6 * num5 + num7 * num4;
          pnt3D2.Y = Center.Y;
          pnt3D2.Z = Center.Z - num6 * num4 + num7 * num5;
        }
        if (Plane.PlaneType == planeType.YZ)
        {
          pnt3D2.X = Center.X;
          pnt3D2.Y = Center.Y + num6 * num5 + num7 * num4;
          pnt3D2.Z = Center.Z - num6 * num4 + num7 * num5;
        }
        Vertices.Add(pnt3D2);
      }
    }
    catch (Exception ex)
    {
      string str = $"Center: {Center.ToString()} - MajRad: {Major.ToString()} - MinRad: {Minor.ToString()} - SA: {StartAngle.ToString()} - EA: {EndAngle.ToString()} - Ang: {Angle.ToString()} - Len: {Length.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static int EllipseVerticeCountByResolution(
    double MajorRadius,
    double MinorRadius,
    EntityResolution EntResolution)
  {
    try
    {
      int num = 10;
      if (EntResolution.ResolutionTypes == EntityResolutionType.ByNumber)
        num = EntResolution.GeometricCount;
      if (EntResolution.ResolutionTypes == EntityResolutionType.ByLength)
        num = Convert.ToInt32(buStatics.EllipseCircumference(MajorRadius, MinorRadius) / EntResolution.GeometricLength);
      if (EntResolution.ResolutionTypes == EntityResolutionType.ByLnRadius && MajorRadius > 0.0 | MinorRadius > 0.0)
        num = Convert.ToInt32(Math.Log((Math.Abs(MajorRadius) + Math.Abs(MinorRadius)) / 2.0, Math.E) * EntResolution.LnRatio);
      return num;
    }
    catch (Exception ex)
    {
      string str = $"Major R: {MajorRadius.ToString()} - Minor R: {MinorRadius.ToString()} - Entitiy Res: {EntResolution.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return -1;
    }
  }

  public static int ArcEllipseVerticeCountByResolution(
    double MajorRadius,
    double MinorRadius,
    double StartAngle,
    double EndAngle,
    EntityResolution EntResolution)
  {
    try
    {
      int num = 10;
      if (EntResolution.ResolutionTypes == EntityResolutionType.ByNumber)
        num = EntResolution.GeometricCount;
      if (EntResolution.ResolutionTypes == EntityResolutionType.ByLength)
        num = Convert.ToInt32(buStatics.EllipseCircumference(MajorRadius, MinorRadius) * ((EndAngle - StartAngle) / 360.0) / EntResolution.GeometricLength);
      if (EntResolution.ResolutionTypes == EntityResolutionType.ByLnRadius && MajorRadius > 0.0 | MinorRadius > 0.0)
        num = Convert.ToInt32(Math.Log((MajorRadius + MinorRadius) / 2.0, Math.E) * EntResolution.LnRatio);
      return num;
    }
    catch (Exception ex)
    {
      string str = $"Major R: {MajorRadius.ToString()} - Minor R: {MinorRadius.ToString()}- SA: {StartAngle.ToString()} - EA: {EndAngle.ToString()} - Entitiy Res: {EntResolution.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return -1;
    }
  }

  public static int ArcVerticeCountByResolution(
    double Radius,
    double StartAngle,
    double EndAngle,
    EntityResolution EntResolution)
  {
    try
    {
      int num = 10;
      if (EntResolution.ResolutionTypes == EntityResolutionType.ByNumber)
      {
        num = EntResolution.GeometricCount;
        if (num < 10)
          num = 10;
      }
      if (EntResolution.ResolutionTypes == EntityResolutionType.ByLength)
      {
        if (buStatics.IsNumeric(Radius.ToString()))
          num = Convert.ToInt32(2.0 * Math.PI * Radius * ((EndAngle - StartAngle) / 360.0) / EntResolution.GeometricLength);
        if (num < 10)
          num = 10;
      }
      if (EntResolution.ResolutionTypes == EntityResolutionType.ByLnRadius)
      {
        if (buStatics.IsNumeric(Radius.ToString()) && Radius > 0.0)
          num = Convert.ToInt32(Math.Log(Radius, Math.E) * EntResolution.LnRatio);
        if (num < 10)
          num = 10;
      }
      return num;
    }
    catch (Exception ex)
    {
      string str = $"R: {Radius.ToString()} - SA: {StartAngle.ToString()} - EA: {EndAngle.ToString()} - Ent Res:{EntResolution.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return -1;
    }
  }

  public static void ArcStartMiddleEndPoint(
    Pnt3D CenterPoint,
    double Radius,
    double StartAngle,
    double EndAngle,
    WorkPlane Plane,
    ref Pnt3D StartPoint,
    ref Pnt3D MiddlePoint,
    ref Pnt3D EndPoint)
  {
    try
    {
      if (WorkPlane.isPlaneXY(Plane))
      {
        StartPoint.X = CenterPoint.X + Radius * Math.Cos(buStatics.DegreeToRadian(StartAngle));
        StartPoint.Y = CenterPoint.Y + Radius * Math.Sin(buStatics.DegreeToRadian(StartAngle));
        StartPoint.Z = CenterPoint.Z;
        MiddlePoint.X = CenterPoint.X + Radius * Math.Cos(buStatics.DegreeToRadian((StartAngle + EndAngle) / 2.0));
        MiddlePoint.Y = CenterPoint.Y + Radius * Math.Sin(buStatics.DegreeToRadian((StartAngle + EndAngle) / 2.0));
        MiddlePoint.Z = CenterPoint.Z;
        EndPoint.X = CenterPoint.X + Radius * Math.Cos(buStatics.DegreeToRadian(EndAngle));
        EndPoint.Y = CenterPoint.Y + Radius * Math.Sin(buStatics.DegreeToRadian(EndAngle));
        EndPoint.Z = CenterPoint.Z;
      }
      if (WorkPlane.isPlaneXZ(Plane))
      {
        StartPoint.X = CenterPoint.X + Radius * Math.Cos(buStatics.DegreeToRadian(StartAngle));
        StartPoint.Y = CenterPoint.Y;
        StartPoint.Z = CenterPoint.Z + Radius * Math.Sin(buStatics.DegreeToRadian(StartAngle));
        MiddlePoint.X = CenterPoint.X + Radius * Math.Cos(buStatics.DegreeToRadian((StartAngle + EndAngle) / 2.0));
        MiddlePoint.Y = CenterPoint.Y;
        MiddlePoint.Z = CenterPoint.Z + Radius * Math.Sin(buStatics.DegreeToRadian((StartAngle + EndAngle) / 2.0));
        EndPoint.X = CenterPoint.X + Radius * Math.Cos(buStatics.DegreeToRadian(EndAngle));
        EndPoint.Y = CenterPoint.Y;
        EndPoint.Z = CenterPoint.Z + Radius * Math.Sin(buStatics.DegreeToRadian(EndAngle));
      }
      if (!WorkPlane.isPlaneYZ(Plane))
        return;
      StartPoint.X = CenterPoint.X;
      StartPoint.Y = CenterPoint.Y + Radius * Math.Cos(buStatics.DegreeToRadian(StartAngle));
      StartPoint.Z = CenterPoint.Z + Radius * Math.Sin(buStatics.DegreeToRadian(StartAngle));
      MiddlePoint.X = CenterPoint.X;
      MiddlePoint.Y = CenterPoint.Y + Radius * Math.Cos(buStatics.DegreeToRadian((StartAngle + EndAngle) / 2.0));
      MiddlePoint.Z = CenterPoint.Z + Radius * Math.Sin(buStatics.DegreeToRadian((StartAngle + EndAngle) / 2.0));
      EndPoint.X = CenterPoint.X;
      EndPoint.Y = CenterPoint.Y + Radius * Math.Cos(buStatics.DegreeToRadian(EndAngle));
      EndPoint.Z = CenterPoint.Z + Radius * Math.Sin(buStatics.DegreeToRadian(EndAngle));
    }
    catch (Exception ex)
    {
      string str = $"CenterPoint: {CenterPoint.ToString()} - Radius: {Radius.ToString()} - StartAngle: {StartAngle.ToString()} - EndAngle: {EndAngle.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static double EllipseCircumference(double MajorRadius, double MinorRadius)
  {
    try
    {
      return Math.Sqrt((MajorRadius * MajorRadius + MinorRadius * MinorRadius) * 0.5) * Math.PI * 2.0;
    }
    catch (Exception ex)
    {
      string str = $"Major R: {MajorRadius.ToString()} - Minor R: {MinorRadius.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return 0.0;
    }
  }

  public static double ArcEllipseCircumference(
    double MajorRadius,
    double MinorRadius,
    double StartAngle,
    double EndAngle)
  {
    try
    {
      return Math.Sqrt((MajorRadius * MajorRadius + MinorRadius * MinorRadius) * 0.5) * Math.PI * 2.0 * (EndAngle - StartAngle) / 360.0;
    }
    catch (Exception ex)
    {
      string str = $"Major R: {MajorRadius.ToString()} - Minor R: {MinorRadius.ToString()}- SA: {StartAngle.ToString()} - EA: {EndAngle.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return 0.0;
    }
  }

  public static void RectangleCorner(
    Pnt3D FirstPoint,
    Pnt3D SecondPoint,
    WorkPlane Plane,
    ref List<Pnt3D> Vertices)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Vertices.Clear();
      if (Plane.PlaneType == planeType.XY)
      {
        Pnt3D pnt3D2 = new Pnt3D();
        pnt3D2.X = FirstPoint.X;
        pnt3D2.Y = FirstPoint.Y;
        pnt3D2.Z = FirstPoint.Z;
        Vertices.Add(pnt3D2);
        Pnt3D pnt3D3 = new Pnt3D();
        pnt3D3.X = SecondPoint.X;
        pnt3D3.Y = FirstPoint.Y;
        pnt3D3.Z = FirstPoint.Z;
        Vertices.Add(pnt3D3);
        Pnt3D pnt3D4 = new Pnt3D();
        pnt3D4.X = SecondPoint.X;
        pnt3D4.Y = SecondPoint.Y;
        pnt3D4.Z = SecondPoint.Z;
        Vertices.Add(pnt3D4);
        Pnt3D pnt3D5 = new Pnt3D();
        pnt3D5.X = FirstPoint.X;
        pnt3D5.Y = SecondPoint.Y;
        pnt3D5.Z = FirstPoint.Z;
        Vertices.Add(pnt3D5);
        Pnt3D pnt3D6 = new Pnt3D();
        pnt3D6.X = FirstPoint.X;
        pnt3D6.Y = FirstPoint.Y;
        pnt3D6.Z = FirstPoint.Z;
        Vertices.Add(pnt3D6);
      }
      if (Plane.PlaneType == planeType.XZ)
      {
        Pnt3D pnt3D7 = new Pnt3D();
        pnt3D7.X = FirstPoint.X;
        pnt3D7.Y = FirstPoint.Y;
        pnt3D7.Z = FirstPoint.Z;
        Vertices.Add(pnt3D7);
        Pnt3D pnt3D8 = new Pnt3D();
        pnt3D8.X = SecondPoint.X;
        pnt3D8.Y = FirstPoint.Y;
        pnt3D8.Z = FirstPoint.Z;
        Vertices.Add(pnt3D8);
        Pnt3D pnt3D9 = new Pnt3D();
        pnt3D9.X = SecondPoint.X;
        pnt3D9.Y = FirstPoint.Y;
        pnt3D9.Z = SecondPoint.Z;
        Vertices.Add(pnt3D9);
        Pnt3D pnt3D10 = new Pnt3D();
        pnt3D10.X = FirstPoint.X;
        pnt3D10.Y = FirstPoint.Y;
        pnt3D10.Z = SecondPoint.Z;
        Vertices.Add(pnt3D10);
        Pnt3D pnt3D11 = new Pnt3D();
        pnt3D11.X = FirstPoint.X;
        pnt3D11.Y = FirstPoint.Y;
        pnt3D11.Z = FirstPoint.Z;
        Vertices.Add(pnt3D11);
      }
      if (Plane.PlaneType != planeType.YZ)
        return;
      Pnt3D pnt3D12 = new Pnt3D();
      pnt3D12.X = FirstPoint.X;
      pnt3D12.Y = FirstPoint.Y;
      pnt3D12.Z = FirstPoint.Z;
      Vertices.Add(pnt3D12);
      Pnt3D pnt3D13 = new Pnt3D();
      pnt3D13.X = FirstPoint.X;
      pnt3D13.Y = SecondPoint.Y;
      pnt3D13.Z = FirstPoint.Z;
      Vertices.Add(pnt3D13);
      Pnt3D pnt3D14 = new Pnt3D();
      pnt3D14.X = FirstPoint.X;
      pnt3D14.Y = SecondPoint.Y;
      pnt3D14.Z = SecondPoint.Z;
      Vertices.Add(pnt3D14);
      Pnt3D pnt3D15 = new Pnt3D();
      pnt3D15.X = FirstPoint.X;
      pnt3D15.Y = FirstPoint.Y;
      pnt3D15.Z = SecondPoint.Z;
      Vertices.Add(pnt3D15);
      Pnt3D pnt3D16 = new Pnt3D();
      pnt3D16.X = FirstPoint.X;
      pnt3D16.Y = FirstPoint.Y;
      pnt3D16.Z = FirstPoint.Z;
      Vertices.Add(pnt3D16);
    }
    catch (Exception ex)
    {
      string str = $"FirstPoint: {FirstPoint.ToString()} - SecondPoint: {SecondPoint.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static bool IsNumeric(string Value)
  {
    double result = 0.0;
    return double.TryParse(Value, out result);
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

  public static bool EQ(double Value1, double Value2) => buStatics.EQ(Value1, Value2, 0.001);

  public static bool EQ(double Value1, double Value2, double Resolution)
  {
    return Math.Abs(Value1 - Value2) < Resolution;
  }

  public static bool EQ(Pnt2D Value1, Pnt2D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y)) < Resolution;
  }

  public static bool EQ(Pnt3D Value1, Pnt3D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) < Resolution;
  }

  public static void CreatBSplineQuadraticUniform(
    List<Pnt3D> ControlPoints,
    double dt,
    bool Closed,
    ref List<Pnt3D> CalculatedPoints)
  {
    try
    {
      List<Pnt3D> ControlPoints1 = new List<Pnt3D>();
      List<Pnt3D> CalculatedPoints1 = new List<Pnt3D>();
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt3D pnt3D2 = new Pnt3D();
      double num1 = 1.0;
      double num2 = -2.0;
      double num3 = 1.0;
      double num4 = -2.0;
      double num5 = 2.0;
      double num6 = 0.0;
      double num7 = 1.0;
      double num8 = 1.0;
      double num9 = 0.0;
      CalculatedPoints.Clear();
      int int32 = Convert.ToInt32(1.0 / dt);
      if (Closed)
      {
        Pnt3D Pnt1 = new Pnt3D(ControlPoints[0]);
        Pnt3D Pnt2 = new Pnt3D(ControlPoints[ControlPoints.Count - 1]);
        for (int index = 0; index <= ControlPoints.Count - 1; ++index)
          pnt3DList.Add(new Pnt3D(ControlPoints[index]));
        pnt3DList.Insert(0, new Pnt3D(Pnt2));
        pnt3DList.Add(new Pnt3D(Pnt1));
      }
      else
      {
        for (int index = 0; index <= ControlPoints.Count - 1; ++index)
          pnt3DList.Add(new Pnt3D(ControlPoints[index]));
        if (pnt3DList.Count <= 1)
          return;
        if (pnt3DList.Count == 2)
        {
          Pnt3D Pnt = new Pnt3D(buStatics.MiddlePointOfTwoPoint(pnt3DList[0], pnt3DList[1]));
          pnt3DList.Insert(1, new Pnt3D(Pnt));
        }
      }
      for (int index1 = 1; index1 <= pnt3DList.Count - 2; ++index1)
      {
        for (int index2 = 0; index2 <= int32; ++index2)
        {
          Pnt3D pnt3D3 = new Pnt3D();
          double x = (double) index2 * dt;
          double num10 = 0.5 * (num1 * Math.Pow(x, 2.0) + num4 * x + num7) * pnt3DList[index1 - 1].X + 0.5 * (num2 * Math.Pow(x, 2.0) + num5 * x + num8) * pnt3DList[index1].X + 0.5 * (num3 * Math.Pow(x, 2.0) + num6 * x + num9) * pnt3DList[index1 + 1].X;
          double num11 = 0.5 * (num1 * Math.Pow(x, 2.0) + num4 * x + num7) * pnt3DList[index1 - 1].Y + 0.5 * (num2 * Math.Pow(x, 2.0) + num5 * x + num8) * pnt3DList[index1].Y + 0.5 * (num3 * Math.Pow(x, 2.0) + num6 * x + num9) * pnt3DList[index1 + 1].Y;
          double num12 = 0.5 * (num1 * Math.Pow(x, 2.0) + num4 * x + num7) * pnt3DList[index1 - 1].Z + 0.5 * (num2 * Math.Pow(x, 2.0) + num5 * x + num8) * pnt3DList[index1].Z + 0.5 * (num3 * Math.Pow(x, 2.0) + num6 * x + num9) * pnt3DList[index1 + 1].Z;
          pnt3D3.X = num10;
          pnt3D3.Y = num11;
          pnt3D3.Z = num12;
          CalculatedPoints.Add(pnt3D3);
        }
      }
      if (Closed || CalculatedPoints.Count <= 0)
        return;
      ControlPoints1.Add(new Pnt3D(ControlPoints[0]));
      ControlPoints1.Add(new Pnt3D(CalculatedPoints[0]));
      double x1 = ControlPoints[1].X - ControlPoints[0].X;
      double y1 = ControlPoints[1].Y - ControlPoints[0].Y;
      double z1 = ControlPoints[1].Z - ControlPoints[0].Z;
      double x2 = (CalculatedPoints[1].X - CalculatedPoints[0].X) * (1000.0 / (dt * 1000.0));
      double y2 = (CalculatedPoints[1].Y - CalculatedPoints[0].Y) * (1000.0 / (dt * 1000.0));
      double z2 = (CalculatedPoints[1].Z - CalculatedPoints[0].Z) * (1000.0 / (dt * 1000.0));
      buStatics.CreatHermiteCubicSplineWithStartEndVector(ControlPoints1, dt, 1.0, 0.0, new Vec3D(x1, y1, z1), new Vec3D(x2, y2, z2), ref CalculatedPoints1);
      for (int index = CalculatedPoints1.Count - 1; index >= 0; --index)
        CalculatedPoints.Insert(0, new Pnt3D(CalculatedPoints1[index]));
      ControlPoints1.Clear();
      CalculatedPoints1.Clear();
      ControlPoints1.Add(new Pnt3D(CalculatedPoints[CalculatedPoints.Count - 1]));
      ControlPoints1.Add(new Pnt3D(ControlPoints[ControlPoints.Count - 1]));
      double x3 = (CalculatedPoints[CalculatedPoints.Count - 1].X - CalculatedPoints[CalculatedPoints.Count - 2].X) * (1000.0 / (dt * 1000.0));
      double y3 = (CalculatedPoints[CalculatedPoints.Count - 1].Y - CalculatedPoints[CalculatedPoints.Count - 2].Y) * (1000.0 / (dt * 1000.0));
      double z3 = (CalculatedPoints[CalculatedPoints.Count - 1].Z - CalculatedPoints[CalculatedPoints.Count - 2].Z) * (1000.0 / (dt * 1000.0));
      double x4 = ControlPoints[ControlPoints.Count - 1].X - ControlPoints[ControlPoints.Count - 2].X;
      double y4 = ControlPoints[ControlPoints.Count - 1].Y - ControlPoints[ControlPoints.Count - 2].Y;
      double z4 = ControlPoints[ControlPoints.Count - 1].Z - ControlPoints[ControlPoints.Count - 2].Z;
      buStatics.CreatHermiteCubicSplineWithStartEndVector(ControlPoints1, dt, 1.0, 0.0, new Vec3D(x3, y3, z3), new Vec3D(x4, y4, z4), ref CalculatedPoints1);
      for (int index = 0; index <= CalculatedPoints1.Count - 1; ++index)
        CalculatedPoints.Add(new Pnt3D(CalculatedPoints1[index]));
    }
    catch (Exception ex)
    {
      string str = $"dt: {dt.ToString()} - ControlPoints: {ControlPoints.Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CreatBSplineCubicUniform(
    List<Pnt3D> ControlPoints,
    double dt,
    bool Closed,
    ref List<Pnt3D> CalculatedPoints)
  {
    try
    {
      List<Pnt3D> ControlPoints1 = new List<Pnt3D>();
      List<Pnt3D> CalculatedPoints1 = new List<Pnt3D>();
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt3D pnt3D2 = new Pnt3D();
      Pnt3D pnt3D3 = new Pnt3D();
      double num1 = -1.0;
      double num2 = 3.0;
      double num3 = -3.0;
      double num4 = 1.0;
      double num5 = 3.0;
      double num6 = -6.0;
      double num7 = 3.0;
      double num8 = 0.0;
      double num9 = -3.0;
      double num10 = 0.0;
      double num11 = 3.0;
      double num12 = 0.0;
      double num13 = 1.0;
      double num14 = 4.0;
      double num15 = 1.0;
      double num16 = 0.0;
      CalculatedPoints.Clear();
      if (Closed)
      {
        Pnt3D Pnt1 = new Pnt3D(ControlPoints[0]);
        Pnt3D Pnt2 = new Pnt3D(ControlPoints[1]);
        Pnt3D Pnt3 = new Pnt3D(ControlPoints[ControlPoints.Count - 1]);
        for (int index = 0; index <= ControlPoints.Count - 1; ++index)
          pnt3DList.Add(new Pnt3D(ControlPoints[index]));
        pnt3DList.Insert(0, new Pnt3D(Pnt3));
        pnt3DList.Add(new Pnt3D(Pnt1));
        pnt3DList.Add(new Pnt3D(Pnt2));
      }
      else
      {
        if (ControlPoints.Count <= 1)
          return;
        if (ControlPoints.Count == 2)
        {
          Pnt3D Pnt = new Pnt3D(buStatics.MiddlePointOfTwoPoint(ControlPoints[0], ControlPoints[1]));
          ControlPoints.Insert(1, new Pnt3D(Pnt));
        }
        for (int index = 0; index <= ControlPoints.Count - 1; ++index)
          pnt3DList.Add(new Pnt3D(ControlPoints[index]));
      }
      int int32 = Convert.ToInt32(1.0 / dt);
      for (int index1 = 1; index1 <= pnt3DList.Count - 3; ++index1)
      {
        for (int index2 = 0; index2 <= int32; ++index2)
        {
          Pnt3D pnt3D4 = new Pnt3D();
          double x = (double) index2 * dt;
          double num17 = (Math.Pow(x, 3.0) * num1 + Math.Pow(x, 2.0) * num5 + x * num9 + num13) * pnt3DList[index1 - 1].X / 6.0 + (Math.Pow(x, 3.0) * num2 + Math.Pow(x, 2.0) * num6 + x * num10 + num14) * pnt3DList[index1].X / 6.0 + (Math.Pow(x, 3.0) * num3 + Math.Pow(x, 2.0) * num7 + x * num11 + num15) * pnt3DList[index1 + 1].X / 6.0 + (Math.Pow(x, 3.0) * num4 + Math.Pow(x, 2.0) * num8 + x * num12 + num16) * pnt3DList[index1 + 2].X / 6.0;
          double num18 = (Math.Pow(x, 3.0) * num1 + Math.Pow(x, 2.0) * num5 + x * num9 + num13) * pnt3DList[index1 - 1].Y / 6.0 + (Math.Pow(x, 3.0) * num2 + Math.Pow(x, 2.0) * num6 + x * num10 + num14) * pnt3DList[index1].Y / 6.0 + (Math.Pow(x, 3.0) * num3 + Math.Pow(x, 2.0) * num7 + x * num11 + num15) * pnt3DList[index1 + 1].Y / 6.0 + (Math.Pow(x, 3.0) * num4 + Math.Pow(x, 2.0) * num8 + x * num12 + num16) * pnt3DList[index1 + 2].Y / 6.0;
          double num19 = (Math.Pow(x, 3.0) * num1 + Math.Pow(x, 2.0) * num5 + x * num9 + num13) * pnt3DList[index1 - 1].Z / 6.0 + (Math.Pow(x, 3.0) * num2 + Math.Pow(x, 2.0) * num6 + x * num10 + num14) * pnt3DList[index1].Z / 6.0 + (Math.Pow(x, 3.0) * num3 + Math.Pow(x, 2.0) * num7 + x * num11 + num15) * pnt3DList[index1 + 1].Z / 6.0 + (Math.Pow(x, 3.0) * num4 + Math.Pow(x, 2.0) * num8 + x * num12 + num16) * pnt3DList[index1 + 2].Z / 6.0;
          pnt3D4.X = num17;
          pnt3D4.Y = num18;
          pnt3D4.Z = num19;
          CalculatedPoints.Add(pnt3D4);
        }
      }
      if (Closed || CalculatedPoints.Count <= 0)
        return;
      ControlPoints1.Add(new Pnt3D(ControlPoints[0]));
      ControlPoints1.Add(new Pnt3D(CalculatedPoints[0]));
      double x1 = ControlPoints[1].X - ControlPoints[0].X;
      double y1 = ControlPoints[1].Y - ControlPoints[0].Y;
      double z1 = ControlPoints[1].Z - ControlPoints[0].Z;
      double x2 = (CalculatedPoints[1].X - CalculatedPoints[0].X) * (1000.0 / (dt * 1000.0));
      double y2 = (CalculatedPoints[1].Y - CalculatedPoints[0].Y) * (1000.0 / (dt * 1000.0));
      double z2 = (CalculatedPoints[1].Z - CalculatedPoints[0].Z) * (1000.0 / (dt * 1000.0));
      buStatics.CreatHermiteCubicSplineWithStartEndVector(ControlPoints1, dt, 1.0, 0.0, new Vec3D(x1, y1, z1), new Vec3D(x2, y2, z2), ref CalculatedPoints1);
      for (int index = CalculatedPoints1.Count - 1; index >= 0; --index)
        CalculatedPoints.Insert(0, new Pnt3D(CalculatedPoints1[index]));
      ControlPoints1.Clear();
      CalculatedPoints1.Clear();
      ControlPoints1.Add(new Pnt3D(CalculatedPoints[CalculatedPoints.Count - 1]));
      ControlPoints1.Add(new Pnt3D(ControlPoints[ControlPoints.Count - 1]));
      double x3 = (CalculatedPoints[CalculatedPoints.Count - 1].X - CalculatedPoints[CalculatedPoints.Count - 2].X) * (1000.0 / (dt * 1000.0));
      double y3 = (CalculatedPoints[CalculatedPoints.Count - 1].Y - CalculatedPoints[CalculatedPoints.Count - 2].Y) * (1000.0 / (dt * 1000.0));
      double z3 = (CalculatedPoints[CalculatedPoints.Count - 1].Z - CalculatedPoints[CalculatedPoints.Count - 2].Z) * (1000.0 / (dt * 1000.0));
      double x4 = ControlPoints[ControlPoints.Count - 1].X - ControlPoints[ControlPoints.Count - 2].X;
      double y4 = ControlPoints[ControlPoints.Count - 1].Y - ControlPoints[ControlPoints.Count - 2].Y;
      double z4 = ControlPoints[ControlPoints.Count - 1].Z - ControlPoints[ControlPoints.Count - 2].Z;
      buStatics.CreatHermiteCubicSplineWithStartEndVector(ControlPoints1, dt, 1.0, 0.0, new Vec3D(x3, y3, z3), new Vec3D(x4, y4, z4), ref CalculatedPoints1);
      for (int index = 0; index <= CalculatedPoints1.Count - 1; ++index)
        CalculatedPoints.Add(new Pnt3D(CalculatedPoints1[index]));
    }
    catch (Exception ex)
    {
      string str = $"dt: {dt.ToString()} - ControlPoints: {ControlPoints.Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CreatBsplineRationalKnotVector(
    List<Pnt3D> ControlPoints,
    int Order,
    double dt,
    List<double> Weigth,
    ref List<Pnt3D> CalculatedPoints)
  {
    try
    {
      List<int> KnotVector = new List<int>();
      List<double> BasisFunctions = new List<double>();
      Pnt3D pnt3D1 = new Pnt3D();
      CalculatedPoints.Clear();
      int num1 = ControlPoints.Count + Order;
      for (int index = 0; index <= ControlPoints.Count - 1; ++index)
        BasisFunctions.Add(0.0);
      for (int index = 0; index <= num1 - 1; ++index)
        KnotVector.Add(0);
      int int32 = Convert.ToInt32((double) ControlPoints.Count / dt);
      buStatics.KnotBSpline(ControlPoints.Count, Order, KnotVector);
      double Parameter = 0.0;
      double num2 = (double) KnotVector[num1 - 1] / (double) (int32 - 1);
      for (int index1 = 0; index1 <= int32 - 1; ++index1)
      {
        Pnt3D pnt3D2 = new Pnt3D();
        if ((double) KnotVector[num1 - 1] - Parameter < 5E-06)
          Parameter = (double) KnotVector[num1 - 1];
        buStatics.BasisRegionalBSpline(Order, Parameter, ControlPoints.Count, KnotVector, Weigth, BasisFunctions);
        double num3 = 0.0;
        double num4 = 0.0;
        double num5 = 0.0;
        for (int index2 = 0; index2 <= ControlPoints.Count - 1; ++index2)
        {
          num3 += BasisFunctions[index2] * ControlPoints[index2].X;
          num4 += BasisFunctions[index2] * ControlPoints[index2].Y;
          num5 += BasisFunctions[index2] * ControlPoints[index2].Z;
        }
        pnt3D2.X = num3;
        pnt3D2.Y = num4;
        pnt3D2.Z = num5;
        CalculatedPoints.Add(pnt3D2);
        Parameter += num2;
      }
    }
    catch (Exception ex)
    {
      string str = $"dt: {dt.ToString()} - ControlPoints: {ControlPoints.Count.ToString()} - Order: {Order.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CreatHermiteCubicSplineWithStartEndVector(
    List<Pnt3D> ControlPoints,
    double dt,
    double Multiply,
    double Offset,
    Vec3D StartVector,
    Vec3D EndVector,
    ref List<Pnt3D> CalculatedPoints)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      double num1 = 2.0;
      double num2 = -2.0;
      double num3 = 1.0;
      double num4 = 1.0;
      double num5 = -3.0;
      double num6 = 3.0;
      double num7 = -2.0;
      double num8 = -1.0;
      double num9 = 0.0;
      double num10 = 0.0;
      double num11 = 1.0;
      double num12 = 0.0;
      double num13 = 1.0;
      double num14 = 0.0;
      double num15 = 0.0;
      double num16 = 0.0;
      double num17 = 0.0;
      double num18 = 0.0;
      double num19 = 0.0;
      double num20 = 0.0;
      double num21 = 0.0;
      double num22 = 0.0;
      double num23 = 0.0;
      CalculatedPoints.Clear();
      int int32 = Convert.ToInt32(1.0 / dt);
      for (int index1 = 0; index1 <= ControlPoints.Count - 2; ++index1)
      {
        if (ControlPoints.Count > 2)
        {
          if (index1 == 0)
          {
            num23 = (180.0 - buStatics.AngleOfTwoLines(ControlPoints[index1], ControlPoints[index1 + 1], ControlPoints[index1 + 1], ControlPoints[index1 + 2])) / 2.0;
            double num24 = buStatics.PointAngle(ControlPoints[index1], ControlPoints[index1 + 1]);
            double num25 = buStatics.PointAngle(ControlPoints[index1 + 2], ControlPoints[index1 + 1]);
            double num26 = (num24 + num25) / 2.0;
            double Degree = (num25 <= num24 ? num26 - 90.0 : num26 + 90.0) + Offset;
            num17 = StartVector.X;
            num19 = StartVector.Y;
            double num27 = Math.Abs(ControlPoints[index1 + 1].X - ControlPoints[index1].X) * Multiply;
            double num28 = Math.Abs(ControlPoints[index1 + 1].Y - ControlPoints[index1].Y) * Multiply;
            double num29 = Math.Abs(ControlPoints[index1 + 1].Z - ControlPoints[index1].Z) * Multiply;
            num18 = num27 * Math.Cos(buStatics.DegreeToRadian(Degree));
            num20 = num28 * Math.Sin(buStatics.DegreeToRadian(Degree));
            num22 = num29 * Math.Cos(buStatics.DegreeToRadian(Degree));
          }
          if (index1 > 0 & index1 < ControlPoints.Count - 2)
          {
            num23 = (180.0 - buStatics.AngleOfTwoLines(ControlPoints[index1], ControlPoints[index1 + 1], ControlPoints[index1 + 1], ControlPoints[index1 + 2])) / 2.0;
            double num30 = buStatics.PointAngle(ControlPoints[index1], ControlPoints[index1 + 1]);
            double num31 = buStatics.PointAngle(ControlPoints[index1 + 2], ControlPoints[index1 + 1]);
            double num32 = (num30 + num31) / 2.0;
            double Degree = (num31 <= num30 ? num32 - 90.0 : num32 + 90.0) + Offset;
            double num33 = Math.Abs(ControlPoints[index1 + 1].X - ControlPoints[index1].X) * Multiply;
            double num34 = Math.Abs(ControlPoints[index1 + 1].Y - ControlPoints[index1].Y) * Multiply;
            double num35 = Math.Abs(ControlPoints[index1 + 1].Z - ControlPoints[index1].Z) * Multiply;
            num18 = num33 * Math.Cos(buStatics.DegreeToRadian(Degree));
            num20 = num34 * Math.Sin(buStatics.DegreeToRadian(Degree));
            num22 = num35 * Math.Cos(buStatics.DegreeToRadian(Degree));
          }
          if (index1 == ControlPoints.Count - 2)
          {
            num18 = EndVector.X;
            num20 = EndVector.Y;
            num22 = EndVector.Z;
          }
        }
        else
        {
          num17 = StartVector.X;
          num19 = StartVector.Y;
          num21 = StartVector.Z;
          num18 = EndVector.X;
          num20 = EndVector.Y;
          num22 = EndVector.Z;
        }
        for (int index2 = 0; index2 <= int32; ++index2)
        {
          Pnt3D pnt3D2 = new Pnt3D();
          double x1 = (double) index2 * dt;
          double x2 = ControlPoints[index1].X;
          double x3 = ControlPoints[index1 + 1].X;
          double num36 = num17;
          double num37 = num18;
          double num38 = (Math.Pow(x1, 3.0) * num1 + Math.Pow(x1, 2.0) * num5 + x1 * num9 + num13) * x2;
          double num39 = (Math.Pow(x1, 3.0) * num2 + Math.Pow(x1, 2.0) * num6 + x1 * num10 + num14) * x3;
          double num40 = (Math.Pow(x1, 3.0) * num3 + Math.Pow(x1, 2.0) * num7 + x1 * num11 + num15) * num36;
          double num41 = (Math.Pow(x1, 3.0) * num4 + Math.Pow(x1, 2.0) * num8 + x1 * num12 + num16) * num37;
          pnt3D2.X = num38 + num39 + num40 + num41;
          double y1 = ControlPoints[index1].Y;
          double y2 = ControlPoints[index1 + 1].Y;
          double num42 = num19;
          double num43 = num20;
          double num44 = (Math.Pow(x1, 3.0) * num1 + Math.Pow(x1, 2.0) * num5 + x1 * num9 + num13) * y1;
          double num45 = (Math.Pow(x1, 3.0) * num2 + Math.Pow(x1, 2.0) * num6 + x1 * num10 + num14) * y2;
          double num46 = (Math.Pow(x1, 3.0) * num3 + Math.Pow(x1, 2.0) * num7 + x1 * num11 + num15) * num42;
          double num47 = (Math.Pow(x1, 3.0) * num4 + Math.Pow(x1, 2.0) * num8 + x1 * num12 + num16) * num43;
          pnt3D2.Y = num44 + num45 + num46 + num47;
          double z1 = ControlPoints[index1].Z;
          double z2 = ControlPoints[index1 + 1].Z;
          double num48 = num21;
          double num49 = num22;
          double num50 = (Math.Pow(x1, 3.0) * num1 + Math.Pow(x1, 2.0) * num5 + x1 * num9 + num13) * z1;
          double num51 = (Math.Pow(x1, 3.0) * num2 + Math.Pow(x1, 2.0) * num6 + x1 * num10 + num14) * z2;
          double num52 = (Math.Pow(x1, 3.0) * num3 + Math.Pow(x1, 2.0) * num7 + x1 * num11 + num15) * num48;
          double num53 = (Math.Pow(x1, 3.0) * num4 + Math.Pow(x1, 2.0) * num8 + x1 * num12 + num16) * num49;
          pnt3D2.Z = num50 + num51 + num52 + num53;
          CalculatedPoints.Add(pnt3D2);
        }
        num17 = num18;
        num19 = num20;
        num21 = num22;
      }
    }
    catch (Exception ex)
    {
      string str = $"dt: {dt.ToString()} - ControlPoints: {ControlPoints.Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CreatBezeirCurve(
    List<Pnt3D> ControlPoints,
    double dt,
    ref List<Pnt3D> CalculatedPoints)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      double num1 = 0.0;
      CalculatedPoints.Clear();
      if (dt <= 0.0)
        dt = 0.1;
      dt /= (double) ControlPoints.Count;
      int int32 = Convert.ToInt32(1.0 / dt);
      int n = ControlPoints.Count - 1;
      for (int index1 = 0; index1 <= int32; ++index1)
      {
        Pnt3D pnt3D2 = new Pnt3D();
        double t = (double) index1 * dt;
        double num2 = 0.0;
        double num3 = 0.0;
        double num4 = 0.0;
        for (int index2 = 0; index2 <= ControlPoints.Count - 1; ++index2)
        {
          num1 = buStatics.BezeirBlend(n, index2, t);
          num2 += ControlPoints[index2].X * buStatics.BezeirBlend(n, index2, t);
          num3 += ControlPoints[index2].Y * buStatics.BezeirBlend(n, index2, t);
          num4 += ControlPoints[index2].Z * buStatics.BezeirBlend(n, index2, t);
        }
        pnt3D2.X = num2;
        pnt3D2.Y = num3;
        pnt3D2.Z = num4;
        CalculatedPoints.Add(pnt3D2);
      }
    }
    catch (Exception ex)
    {
      string str = $"dt: {dt.ToString()} - ControlPoints: {ControlPoints.Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CreatSplineCubicUniform(
    List<Pnt3D> ControlPoints,
    double dt,
    ref List<Pnt3D> CalculatedPoints)
  {
    try
    {
      if (dt <= 0.0)
        dt = 0.1;
      CalculatedPoints.Clear();
      double[] x = new double[ControlPoints.Count];
      double[] y = new double[ControlPoints.Count];
      double[] z = new double[ControlPoints.Count];
      int int32 = Convert.ToInt32(1.0 / dt * (double) ControlPoints.Count);
      for (int index = 0; index <= ControlPoints.Count - 1; ++index)
      {
        x[index] = ControlPoints[index].X;
        y[index] = ControlPoints[index].Y;
        z[index] = ControlPoints[index].Z;
      }
      double[] xs;
      double[] ys;
      double[] zs;
      CubicSpline.FitGeometric(x, y, z, int32, out xs, out ys, out zs);
      for (int index = 0; index <= xs.Length - 1; ++index)
        CalculatedPoints.Add(new Pnt3D(xs[index], ys[index], zs[index]));
    }
    catch (Exception ex)
    {
      string str = $"dt: {dt.ToString()} - ControlPoints: {ControlPoints.Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  private static double BezeirBlend(int n, int i, double t)
  {
    try
    {
      Math.Pow(t, (double) i);
      Math.Pow(1.0 - t, (double) (n - i));
      return buStatics.Factorial(n) / (buStatics.Factorial(i) * buStatics.Factorial(n - i)) * Math.Pow(t, (double) i) * Math.Pow(1.0 - t, (double) (n - i));
    }
    catch (Exception ex)
    {
      string str = $"n: {n.ToString()} - i: {i.ToString()} - t: {t.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return 0.0;
    }
  }

  private static void KnotBSpline(int PointNumber, int Order, List<int> KnotVector)
  {
    try
    {
      int num1 = PointNumber + Order;
      int num2 = PointNumber + 1;
      KnotVector.Clear();
      KnotVector.Add(0);
      for (int index = 1; index <= num1 - 1; ++index)
      {
        if (index > Order - 1 && index < num2)
          KnotVector.Add(KnotVector[index - 1] + 1);
        else
          KnotVector.Add(KnotVector[index - 1]);
      }
    }
    catch (Exception ex)
    {
      string str = $"PointNumber: {PointNumber.ToString()} - Order: {Order.ToString()} - KnotVector: {KnotVector.Count.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  private static void BasisRegionalBSpline(
    int Order,
    double Parameter,
    int PointNumber,
    List<int> KnotVector,
    List<double> Weigth,
    List<double> BasisFunctions)
  {
    try
    {
      List<double> doubleList = new List<double>();
      int num1 = PointNumber + Order;
      for (int index = 0; index <= num1 - 2; ++index)
      {
        if (Parameter >= (double) KnotVector[index] && Parameter < (double) KnotVector[index + 1])
          doubleList.Add(1.0);
        else
          doubleList.Add(0.0);
      }
      for (int index1 = 2; index1 <= Order; ++index1)
      {
        for (int index2 = 0; index2 <= num1 - index1 - 1; ++index2)
        {
          double num2 = doubleList[index2] == 0.0 ? 0.0 : (Parameter - (double) KnotVector[index2]) * doubleList[index2] / (double) (KnotVector[index2 + index1 - 1] - KnotVector[index2]);
          double num3 = doubleList[index2 + 1] == 0.0 ? 0.0 : ((double) KnotVector[index2 + index1] - Parameter) * doubleList[index2 + 1] / (double) (KnotVector[index2 + index1] - KnotVector[index2 + 1]);
          doubleList[index2] = num2 + num3;
        }
      }
      if (Parameter == (double) KnotVector[num1 - 1])
        doubleList[PointNumber - 1] = 1.0;
      double num4 = 0.0;
      for (int index = 0; index <= PointNumber - 1; ++index)
        num4 += doubleList[index] * Weigth[index];
      for (int index = 0; index <= PointNumber - 1; ++index)
        BasisFunctions[index] = num4 == 0.0 ? 0.0 : doubleList[index] * Weigth[index] / num4;
    }
    catch (Exception ex)
    {
      string str = $"Order: {Order.ToString()} - Parameter: {Parameter.ToString()} - PointNumber: {PointNumber.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  private static double Factorial(int Value)
  {
    try
    {
      int num = 1;
      for (int index = 1; index <= Value; ++index)
        num *= index;
      return (double) num;
    }
    catch (Exception ex)
    {
      string str = "Value: " + Value.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return 0.0;
    }
  }

  private static Pnt3D MiddlePointOfTwoPoint(Pnt3D Value1, Pnt3D Value2)
  {
    try
    {
      Pnt3D pnt3D = new Pnt3D();
      pnt3D.X = (Value1.X + Value2.X) / 2.0;
      pnt3D.Y = (Value1.Y + Value2.Y) / 2.0;
      pnt3D.Z = (Value1.Z + Value2.Z) / 2.0;
      return pnt3D;
    }
    catch (Exception ex)
    {
      string str = $"Value1: {Value1.ToString()} - Value2: {Value2.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return new Pnt3D();
    }
  }

  public static double PointAngle(Pnt3D PntEnd, Pnt3D PntCenter)
  {
    double XY = 0.0;
    double XZ = 0.0;
    double YZ = 0.0;
    return buStatics.PointAngle(PntEnd, PntCenter, ref XY, ref XZ, ref YZ);
  }

  public static double PointAngle(
    Pnt3D PntEnd,
    Pnt3D PntCenter,
    ref double XY,
    ref double XZ,
    ref double YZ)
  {
    double num1 = buStatics.RadianToDegree(Math.Atan(buStatics.DeltaY(PntEnd.Y, PntCenter.Y) / buStatics.DeltaX(PntEnd.X, PntCenter.X)));
    if (PntEnd.X == PntCenter.X)
      num1 = 90.0;
    if (PntEnd.Y > PntCenter.Y && num1 < 0.0)
      num1 = 180.0 + num1;
    if (PntEnd.Y < PntCenter.Y)
      num1 = num1 >= 0.0 ? 180.0 + num1 : 360.0 + num1;
    if (PntCenter.Y == PntEnd.Y & PntCenter.X > PntEnd.X)
      num1 = 180.0;
    if (PntCenter.X == PntEnd.X & PntCenter.Y == PntEnd.Y)
      num1 = -1.0;
    XY = num1;
    double num2 = buStatics.RadianToDegree(Math.Atan(buStatics.DeltaZ(PntEnd.Z, PntCenter.Z) / buStatics.DeltaX(PntEnd.X, PntCenter.X)));
    if (PntEnd.X == PntCenter.X)
      num2 = 90.0;
    if (PntEnd.Z > PntCenter.Z && num2 < 0.0)
      num2 = 180.0 + num2;
    if (PntEnd.Z < PntCenter.Z)
      num2 = num2 >= 0.0 ? 180.0 + num2 : 360.0 + num2;
    if (PntCenter.Z == PntEnd.Z & PntCenter.X > PntEnd.X)
      num2 = 180.0;
    if (PntCenter.X == PntEnd.X & PntCenter.Z == PntEnd.Z)
      num2 = -1.0;
    XZ = num2;
    double num3 = buStatics.RadianToDegree(Math.Atan(buStatics.DeltaZ(PntEnd.Z, PntCenter.Z) / buStatics.DeltaY(PntEnd.Y, PntCenter.Y)));
    if (PntEnd.Y == PntCenter.Y)
      num3 = 90.0;
    if (PntEnd.Z > PntCenter.Z && num3 < 0.0)
      num3 = 180.0 + num3;
    if (PntEnd.Z < PntCenter.Z)
      num3 = num3 >= 0.0 ? 180.0 + num3 : 360.0 + num3;
    if (PntCenter.Z == PntEnd.Z & PntCenter.Y > PntEnd.Y)
      num3 = 180.0;
    if (PntCenter.Y == PntEnd.Y & PntCenter.Z == PntEnd.Z)
      num3 = -1.0;
    YZ = num3;
    return XY;
  }

  public static float PointAngle(
    Pnt3D PntEnd,
    Pnt3D PntCenter,
    ref float XY,
    ref float XZ,
    ref float YZ)
  {
    float num1 = Convert.ToSingle(buStatics.RadianToDegree(Math.Atan(buStatics.DeltaY(PntEnd.Y, PntCenter.Y) / buStatics.DeltaX(PntEnd.X, PntCenter.X))));
    if (PntEnd.X == PntCenter.X)
      num1 = 90f;
    if (PntEnd.Y > PntCenter.Y && (double) num1 < 0.0)
      num1 = 180f + num1;
    if (PntEnd.Y < PntCenter.Y)
      num1 = (double) num1 >= 0.0 ? 180f + num1 : 360f + num1;
    if (PntCenter.Y == PntEnd.Y & PntCenter.X > PntEnd.X)
      num1 = 180f;
    if (PntCenter.X == PntEnd.X & PntCenter.Y == PntEnd.Y)
      num1 = -1f;
    XY = num1;
    float num2 = Convert.ToSingle(buStatics.RadianToDegree(Math.Atan(buStatics.DeltaZ(PntEnd.Z, PntCenter.Z) / buStatics.DeltaX(PntEnd.X, PntCenter.X))));
    if (PntEnd.X == PntCenter.X)
      num2 = 90f;
    if (PntEnd.Z > PntCenter.Z && (double) num2 < 0.0)
      num2 = 180f + num2;
    if (PntEnd.Z < PntCenter.Z)
      num2 = (double) num2 >= 0.0 ? 180f + num2 : 360f + num2;
    if (PntCenter.Z == PntEnd.Z & PntCenter.X > PntEnd.X)
      num2 = 180f;
    if (PntCenter.X == PntEnd.X & PntCenter.Z == PntEnd.Z)
      num2 = -1f;
    XZ = num2;
    float num3 = Convert.ToSingle(buStatics.RadianToDegree(Math.Atan(buStatics.DeltaZ(PntEnd.Z, PntCenter.Z) / buStatics.DeltaY(PntEnd.Y, PntCenter.Y))));
    if (PntEnd.Y == PntCenter.Y)
      num3 = 90f;
    if (PntEnd.Z > PntCenter.Z && (double) num3 < 0.0)
      num3 = 180f + num3;
    if (PntEnd.Z < PntCenter.Z)
      num3 = (double) num3 >= 0.0 ? 180f + num3 : 360f + num3;
    if (PntCenter.Z == PntEnd.Z & PntCenter.Y > PntEnd.Y)
      num3 = 180f;
    if (PntCenter.Y == PntEnd.Y & PntCenter.Z == PntEnd.Z)
      num3 = -1f;
    YZ = num3;
    return XY;
  }

  public static double PointAngle(double PointX, double PointY, double CenterX, double CenterY)
  {
    Pnt3D PntEnd = new Pnt3D();
    Pnt3D PntCenter = new Pnt3D();
    PntCenter.X = CenterX;
    PntCenter.Y = CenterY;
    PntCenter.Z = 0.0;
    PntEnd.X = PointX;
    PntEnd.Y = PointY;
    PntEnd.Z = 0.0;
    return buStatics.PointAngle(PntEnd, PntCenter);
  }

  public static double RadianToDegree(double Radian) => Radian * 180.0 / Math.PI;

  public static double DeltaX(double X1, double X2) => X2 - X1;

  public static double DeltaX(Pnt2D Pnt1, Pnt2D Pnt2) => Pnt2.X - Pnt1.X;

  public static double DeltaX(Pnt3D Pnt1, Pnt3D Pnt2) => Pnt2.X - Pnt1.X;

  public static double DeltaY(double Y1, double Y2) => Y2 - Y1;

  public static double DeltaY(Pnt2D Pnt1, Pnt2D Pnt2) => Pnt2.Y - Pnt1.Y;

  public static double DeltaY(Pnt3D Pnt1, Pnt3D Pnt2) => Pnt2.Y - Pnt1.Y;

  public static double DeltaZ(double Z1, double Z2) => Z2 - Z1;

  private static double AngleOfTwoLines(
    Pnt3D FirstLineStart,
    Pnt3D FirstLineEnd,
    Pnt3D SecondLineStart,
    Pnt3D SecondLineEnd)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    if (buStatics.EQ(FirstLineStart.X, SecondLineStart.X) & buStatics.EQ(FirstLineStart.Y, SecondLineStart.Y))
    {
      num1 = buStatics.PointAngle(FirstLineEnd.X, FirstLineEnd.Y, FirstLineStart.X, FirstLineStart.Y);
      num2 = buStatics.PointAngle(SecondLineEnd.X, SecondLineEnd.Y, SecondLineStart.X, SecondLineStart.Y);
    }
    if (buStatics.EQ(FirstLineStart.X, SecondLineEnd.X) & buStatics.EQ(FirstLineStart.Y, SecondLineEnd.Y))
    {
      num1 = buStatics.PointAngle(FirstLineEnd.X, FirstLineEnd.Y, FirstLineStart.X, FirstLineStart.Y);
      num2 = buStatics.PointAngle(SecondLineStart.X, SecondLineStart.Y, SecondLineEnd.X, SecondLineEnd.Y);
    }
    if (buStatics.EQ(FirstLineEnd.X, SecondLineEnd.X) & buStatics.EQ(FirstLineEnd.Y, SecondLineEnd.Y))
    {
      num1 = buStatics.PointAngle(FirstLineStart.X, FirstLineStart.Y, FirstLineEnd.X, FirstLineEnd.Y);
      num2 = buStatics.PointAngle(SecondLineStart.X, SecondLineStart.Y, FirstLineEnd.X, FirstLineEnd.Y);
    }
    if (buStatics.EQ(FirstLineEnd.X, SecondLineStart.X) & buStatics.EQ(FirstLineEnd.Y, SecondLineStart.Y))
    {
      num1 = buStatics.PointAngle(FirstLineStart.X, FirstLineStart.Y, FirstLineEnd.X, FirstLineEnd.Y);
      num2 = buStatics.PointAngle(SecondLineEnd.X, SecondLineEnd.Y, SecondLineStart.X, SecondLineStart.Y);
    }
    if (num1 < num2)
    {
      num3 = num2 - num1;
      if (num3 > 180.0)
        num3 = 360.0 + num1 - num2;
    }
    if (num2 < num1)
    {
      num3 = num1 - num2;
      if (num3 > 180.0)
        num3 = 360.0 + num2 - num1;
    }
    return num3;
  }

  public static string ColorToString(Color clr, ColorConvertType Type)
  {
    try
    {
      return Type == ColorConvertType.Html ? ColorTranslator.ToHtml(clr) : clr.ToString();
    }
    catch (Exception ex)
    {
      return "Black";
    }
  }

  public static Color StringToColor(string Code, ColorConvertType Type)
  {
    Color color1 = new Color();
    color1 = Color.Black;
    try
    {
      string[] strArray = Code.Split(',');
      if (strArray.Length >= 4)
      {
        strArray[0] = strArray[0].Replace("[", "");
        strArray[3] = strArray[3].Replace("]", "");
        int int32_1 = Convert.ToInt32(strArray[0].Substring(strArray[0].IndexOf('=') + 1));
        int int32_2 = Convert.ToInt32(strArray[1].Substring(strArray[1].IndexOf('=') + 1));
        int int32_3 = Convert.ToInt32(strArray[2].Substring(strArray[2].IndexOf('=') + 1));
        int int32_4 = Convert.ToInt32(strArray[3].Substring(strArray[3].IndexOf('=') + 1));
        Color color2 = new Color();
        return Color.FromArgb(int32_1, int32_2, int32_3, int32_4);
      }
      if (Type == ColorConvertType.Html)
        return ColorTranslator.FromHtml(Code);
      Code = Code.Replace("Color", "");
      Code = Code.Replace("[", "");
      Code = Code.Replace("]", "");
      Code = Code.Trim();
      return ColorTranslator.FromHtml(Code);
    }
    catch (Exception ex)
    {
      return Color.Black;
    }
  }

  public static string FontToString(Font fnt)
  {
    try
    {
      return new FontConverter().ConvertToString((object) fnt);
    }
    catch (Exception ex)
    {
      return new FontConverter().ConvertToString((object) new Font("Arial", 10f));
    }
  }

  public static DateTime StringToDateTime(string Code)
  {
    try
    {
      return DateTime.Parse(Code);
    }
    catch (Exception ex)
    {
      return DateTime.Now;
    }
  }

  public static string StringToSting(string Code)
  {
    try
    {
      return Code != null ? Code : "";
    }
    catch (Exception ex)
    {
      return "";
    }
  }

  public static Size StringToSize(string Code)
  {
    try
    {
      string[] strArray = Code.Split(';');
      Size size = new Size();
      if (strArray != null && strArray.Length >= 2)
      {
        size.Width = int.Parse(strArray[0]);
        size.Height = int.Parse(strArray[1]);
      }
      return size;
    }
    catch (Exception ex)
    {
      return new Size();
    }
  }

  public static SizeF StringToSizeF(string Code)
  {
    try
    {
      string[] strArray = Code.Split(';');
      SizeF sizeF = new SizeF();
      if (strArray != null && strArray.Length >= 2)
      {
        sizeF.Width = float.Parse(strArray[0]);
        sizeF.Height = float.Parse(strArray[1]);
      }
      return sizeF;
    }
    catch (Exception ex)
    {
      return new SizeF();
    }
  }

  public static Point StringToPoint(string Code)
  {
    try
    {
      string[] strArray = Code.Split(';');
      Point point = new Point();
      if (strArray != null && strArray.Length >= 2)
      {
        point.X = int.Parse(strArray[0]);
        point.Y = int.Parse(strArray[1]);
      }
      return point;
    }
    catch (Exception ex)
    {
      return new Point();
    }
  }

  public static PointF StringToPointF(string Code)
  {
    try
    {
      string[] strArray = Code.Split(';');
      PointF pointF = new PointF();
      if (strArray != null && strArray.Length >= 2)
      {
        pointF.X = float.Parse(strArray[0]);
        pointF.Y = float.Parse(strArray[1]);
      }
      return pointF;
    }
    catch (Exception ex)
    {
      return new PointF();
    }
  }

  public static Font StringToFont(string Code)
  {
    Font font = new Font("Arial", 10f);
    try
    {
      return new FontConverter().ConvertFromString(Code) as Font;
    }
    catch (Exception ex)
    {
      return font;
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    ArrayList RefList,
    ref List<List<string>> CalcList)
  {
    try
    {
      List<string> stringList = new List<string>();
      bool flag = false;
      CalcList = new List<List<string>>();
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = (object) ((string) RefList[index]).Trim();
        if (((string) RefList[index]).Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
        {
          if (AddStartEndKey)
            stringList.Add(EndKey);
          CalcList.Add(stringList);
          stringList = new List<string>();
          flag = false;
        }
        if (flag)
          stringList.Add(RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
        {
          flag = true;
          if (AddStartEndKey)
            stringList.Add(StartKey);
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"StartKey : {StartKey} - EndKey : {EndKey}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    ArrayList RefList,
    ref List<List<string>> CalcList)
  {
    try
    {
      List<string> stringList = new List<string>();
      bool flag = false;
      CalcList = new List<List<string>>();
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = (object) ((string) RefList[index]).Trim();
        if (((string) RefList[index]).Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
        {
          CalcList.Add(stringList);
          stringList = new List<string>();
          flag = false;
        }
        if (flag)
          stringList.Add(RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
          flag = true;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    ArrayList RefList,
    ref List<string> CalcList)
  {
    try
    {
      CalcList = new List<string>();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = (object) RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
        {
          if (AddStartEndKey)
            CalcList.Add(EndKey);
          break;
        }
        if (flag)
          CalcList.Add(RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
        {
          if (AddStartEndKey)
            CalcList.Add(StartKey);
          flag = true;
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    ArrayList RefList,
    ref ArrayList CalcList)
  {
    try
    {
      CalcList = new ArrayList();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = (object) RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
        {
          if (AddStartEndKey)
            CalcList.Add((object) EndKey);
          break;
        }
        if (flag)
          CalcList.Add((object) RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
        {
          if (AddStartEndKey)
            CalcList.Add((object) StartKey);
          flag = true;
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    List<string> RefList,
    ref ArrayList CalcList)
  {
    try
    {
      CalcList = new ArrayList();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
        {
          if (AddStartEndKey)
            CalcList.Add((object) EndKey);
          break;
        }
        if (flag)
          CalcList.Add((object) RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
        {
          if (AddStartEndKey)
            CalcList.Add((object) StartKey);
          flag = true;
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    ArrayList RefList,
    ref List<string> CalcList)
  {
    try
    {
      CalcList = new List<string>();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = (object) RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
          break;
        if (flag)
          CalcList.Add(RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
          flag = true;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    ArrayList RefList,
    ref ArrayList CalcList)
  {
    try
    {
      CalcList = new ArrayList();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = (object) RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
          break;
        if (flag)
          CalcList.Add((object) RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
          flag = true;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    List<string> RefList,
    ref List<string> CalcList)
  {
    try
    {
      CalcList = new List<string>();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
          break;
        if (flag)
          CalcList.Add(RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
          flag = true;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    List<string> RefList,
    ref List<string> CalcList)
  {
    try
    {
      CalcList = new List<string>();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
        {
          if (AddStartEndKey)
            CalcList.Add(EndKey);
          break;
        }
        if (flag)
          CalcList.Add(RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
        {
          if (AddStartEndKey)
            CalcList.Add(StartKey);
          flag = true;
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    List<string> RefList,
    ref ArrayList CalcList)
  {
    try
    {
      CalcList = new ArrayList();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
          break;
        if (flag)
          CalcList.Add((object) RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
          flag = true;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    List<string> RefList,
    ref List<List<string>> CalcList)
  {
    try
    {
      List<string> stringList = new List<string>();
      bool flag = false;
      CalcList = new List<List<string>>();
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = RefList[index].Trim();
        if (RefList[index].Length >= 2 && RefList[index].Trim() == EndKey & flag)
        {
          CalcList.Add(stringList);
          stringList = new List<string>();
          flag = false;
        }
        if (flag)
          stringList.Add(RefList[index]);
        if (RefList[index].Trim() == StartKey)
          flag = true;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    List<string> RefList,
    ref List<List<string>> CalcList)
  {
    try
    {
      List<string> stringList = new List<string>();
      bool flag = false;
      CalcList = new List<List<string>>();
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = RefList[index].Trim();
        if (RefList[index].Length >= 2 && RefList[index].Trim() == EndKey & flag)
        {
          if (AddStartEndKey)
            stringList.Add(EndKey);
          CalcList.Add(stringList);
          stringList = new List<string>();
          flag = false;
        }
        if (flag)
          stringList.Add(RefList[index]);
        if (RefList[index].Trim() == StartKey)
        {
          flag = true;
          if (AddStartEndKey)
            stringList.Add(StartKey);
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"StartKey : {StartKey} - EndKey : {EndKey}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void OpenFromFile(string FileName, ref List<string> StringList)
  {
    try
    {
      StringList = new List<string>();
      TextReader textReader = (TextReader) File.OpenText(FileName);
      string str;
      while ((str = textReader.ReadLine()) != null)
        StringList.Add(str);
      textReader.Close();
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
    }
  }
}
