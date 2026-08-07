// Decompiled with JetBrains decompiler
// Type: buClass.Pnt3D
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass;

[Serializable]
public class Pnt3D : Pnt2D
{
  public double Z;

  public Pnt3D()
  {
  }

  public Pnt3D(Pnt3D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
  }

  public Pnt3D(Vec3D Vec)
  {
    this.X = Vec.X;
    this.Y = Vec.Y;
    this.Z = Vec.Z;
  }

  public Pnt3D(Pnt9D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
  }

  public Pnt3D(Pnt9DCam Pnt)
  {
    this.X = Pnt.P9.X;
    this.Y = Pnt.P9.Y;
    this.Z = Pnt.P9.Z;
  }

  public Pnt3D(Pnt4D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
  }

  public Pnt3D(Pnt6D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
  }

  public Pnt3D(Pnt6DSim Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
  }

  public Pnt3D(double x, double y)
  {
    this.X = x;
    this.Y = y;
    this.Z = 0.0;
  }

  public Pnt3D(double x, double y, double z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
  }

  public static bool Equal(Pnt3D RefP1, Pnt3D RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(Pnt3D RefP1, Pnt3D RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public static bool EqualXY(Pnt3D RefP1, Pnt3D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXY(Pnt3D RefP1, Pnt3D RefP2, double Resolution)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXYZ(Pnt3D RefP1, Pnt3D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    double num3 = Math.Abs(RefP1.Z - RefP2.Z);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare & num3 < buSystem.resolutionCompare;
  }

  public static void SetValue(double value, AxesXYZ Axis, ref Pnt3D RefPoint)
  {
    if (Axis == AxesXYZ.X)
      RefPoint.X = value;
    if (Axis == AxesXYZ.Y)
      RefPoint.Y = value;
    if (Axis != AxesXYZ.Z)
      return;
    RefPoint.Z = value;
  }

  public static void SetValue(double value, AxesXYZ Axis, ref List<Pnt3D> RefPoint)
  {
    for (int index = 0; index <= RefPoint.Count - 1; ++index)
    {
      Pnt3D Pnt = new Pnt3D(RefPoint[index]);
      if (Axis == AxesXYZ.X)
        Pnt.X = value;
      if (Axis == AxesXYZ.Y)
        Pnt.Y = value;
      if (Axis == AxesXYZ.Z)
        Pnt.Z = value;
      RefPoint[index] = new Pnt3D(Pnt);
    }
  }

  public static void SetValue(double value, AxesXYZ Axis, ref List<List<Pnt3D>> RefPoint)
  {
    for (int index1 = 0; index1 <= RefPoint.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= RefPoint[index1].Count - 1; ++index2)
      {
        Pnt3D Pnt = new Pnt3D(RefPoint[index1][index2]);
        if (Axis == AxesXYZ.X)
          Pnt.X = value;
        if (Axis == AxesXYZ.Y)
          Pnt.Y = value;
        if (Axis == AxesXYZ.Z)
          Pnt.Z = value;
        RefPoint[index1][index2] = new Pnt3D(Pnt);
      }
    }
  }

  public bool Equal(Pnt3D RefP) => this.Equal(RefP, buSystem.resolutionCompare);

  public bool Equal(Pnt3D RefP, double Resolution)
  {
    double num1 = this.X - RefP.X;
    double num2 = this.Y - RefP.Y;
    double num3 = this.Z - RefP.Z;
    return Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3) < buSystem.resolutionCompare;
  }

  public bool IsInside(Pnt3D MinPnt, Pnt3D MaxPnt)
  {
    try
    {
      bool flag = false;
      if (this.X >= MinPnt.X & this.X <= MaxPnt.X && this.Y >= MinPnt.Y & this.Y <= MaxPnt.Y && this.Z >= MinPnt.Z & this.Z <= MaxPnt.Z)
        flag = true;
      return flag;
    }
    catch
    {
      return false;
    }
  }

  public bool IsInside(double dX, double dY, double dZ)
  {
    try
    {
      return this.IsInside(new Pnt3D(this.X - dX, this.Y - dY, this.Z - dZ), new Pnt3D(this.X + dX, this.Y + dY, this.Z + dZ));
    }
    catch
    {
      return false;
    }
  }

  public new bool IsInside(double dX, double dY)
  {
    try
    {
      return this.IsInside(new Pnt3D(this.X - dX, this.Y - dY, this.Z), new Pnt3D(this.X + dX, this.Y + dY, this.Z));
    }
    catch
    {
      return false;
    }
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    Pnt3D pnt3D = new Pnt3D();
    return this.Equal((Pnt3D) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static Pnt3D Copy(Pnt3D P) => new Pnt3D(P.X, P.Y, P.Z);

  public static Pnt3D[] Copy(Pnt3D[] pts)
  {
    Pnt3D[] pnt3DArray = new Pnt3D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt3DArray[index] = Pnt3D.Copy(pts[index]);
    return pnt3DArray;
  }

  public static List<Pnt3D> Copy(List<Pnt3D> pts)
  {
    List<Pnt3D> pnt3DList = new List<Pnt3D>();
    for (int index = 0; index < pts.Count; ++index)
      pnt3DList.Add(Pnt3D.Copy(pts[index]));
    return pnt3DList;
  }

  public static void Copy(List<Pnt3D> pts, ref List<Pnt3D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt3D(Pnt3D.Copy(pts[index])));
  }

  public static void Copy(List<Pnt3D> pts, ref List<List<Pnt3D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    List<Pnt3D> CopiedPnt1 = new List<Pnt3D>();
    Pnt3D.Copy(pts, ref CopiedPnt1);
    CopiedPnt.Add(CopiedPnt1);
  }

  public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt3D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt3D> pnt3DList1 = new List<Pnt3D>();
      List<Pnt3D> pnt3DList2 = Pnt3D.Copy(pts[index]);
      CopiedPnt.Add(pnt3DList2);
    }
  }

  public static void Copy(List<Pnt3D> pts, ref Pnt3D[] CopiedPnt)
  {
    try
    {
      CopiedPnt = new Pnt3D[pts.Count];
      if (pts.Count <= 0)
        return;
      for (int index = 0; index <= pts.Count - 1; ++index)
        CopiedPnt[index] = new Pnt3D(pts[index]);
    }
    catch (Exception ex)
    {
    }
  }

  public static void Copy(List<List<Pnt3D>> SourceList, ref List<Pnt3D> TargetList)
  {
    try
    {
      if (SourceList == null)
        return;
      TargetList = new List<Pnt3D>();
      for (int index1 = 0; index1 <= SourceList.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= SourceList[index1].Count - 1; ++index2)
          TargetList.Add(new Pnt3D(SourceList[index1][index2]));
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static void Add(List<Pnt3D> pts, ref List<Pnt3D> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pnt3D.Copy(pts[index]));
  }

  public static void Add(List<Pnt3D> pts, ref List<List<Pnt3D>> CopiedPnt)
  {
    List<Pnt3D> CopiedPnt1 = new List<Pnt3D>();
    Pnt3D.Copy(pts, ref CopiedPnt1);
    CopiedPnt.Add(CopiedPnt1);
  }

  public static void Add(List<List<Pnt3D>> SourceList, ref List<List<Pnt3D>> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        Pnt3D.Copy(SourceList[index], ref CopiedPnt);
        TargetList.Add(CopiedPnt);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void Offset(double x, double y, double z)
  {
    this.X += x;
    this.Y += y;
    this.Z += z;
  }

  public void Offset(Pnt3D AdditionalPnt)
  {
    this.X += AdditionalPnt.X;
    this.Y += AdditionalPnt.Y;
    this.Z += AdditionalPnt.Z;
  }

  public static void Offset(ref Pnt3D RefPoint, Pnt3D AdditionalPnt)
  {
    RefPoint.X += AdditionalPnt.X;
    RefPoint.Y += AdditionalPnt.Y;
    RefPoint.Z += AdditionalPnt.Z;
  }

  public static void Offset(ref List<Pnt3D> pnt, double offsetX, double offsetY, double offsetZ)
  {
    for (int index = 0; index < pnt.Count; ++index)
    {
      Pnt3D RefPoint = new Pnt3D(pnt[index]);
      Pnt3D.Offset(ref RefPoint, new Pnt3D(offsetX, offsetY, offsetZ));
      pnt[index] = RefPoint;
    }
  }

  public static void Offset(ref Pnt3D[] pts, double offsetX, double offsetY, double offsetZ)
  {
    for (int index = 0; index < pts.Length; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ);
  }

  public static void Offset(ref Pnt3D pts, double offsetX, double offsetY, double offsetZ)
  {
    pts.Offset(offsetX, offsetY, offsetZ);
  }

  public static void BoxSizeOfPoint(
    Pnt3D FirstPoint,
    Pnt3D SecondPoint,
    ref Pnt3D MinPoint,
    ref Pnt3D MidPoint,
    ref Pnt3D MaxPoint)
  {
    Pnt3D.BoxSizeOfPoint(new List<Pnt3D>()
    {
      FirstPoint,
      SecondPoint
    }, ref MinPoint, ref MidPoint, ref MaxPoint);
  }

  public static void BoxSizeOfPoint(
    List<Pnt3D> Points,
    ref Pnt3D MinPoint,
    ref Pnt3D MidPoint,
    ref Pnt3D MaxPoint)
  {
    try
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
      Pnt3D.MiddlePointOfLine(MinPoint, MaxPoint, ref MidPoint);
    }
    catch (Exception ex)
    {
      string str = "Count: " + Points.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void BoxSizeOfPoint(
    List<List<Pnt3D>> Points,
    ref Pnt3D MinPoint,
    ref Pnt3D MidPoint,
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
      Pnt3D.MiddlePointOfLine(MinPoint, MaxPoint, ref MidPoint);
    }
    catch (Exception ex)
    {
      string str = "Count: " + Points.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static Pnt3D MiddlePointOfLine(Pnt3D Pnt1, Pnt3D Pnt2)
  {
    try
    {
      Pnt3D pnt3D = new Pnt3D();
      pnt3D.X = (Pnt1.X + Pnt2.X) / 2.0;
      pnt3D.Y = (Pnt1.Y + Pnt2.Y) / 2.0;
      pnt3D.Z = (Pnt1.Z + Pnt2.Z) / 2.0;
      return pnt3D;
    }
    catch (Exception ex)
    {
      string str = $"Pnt1: {Pnt1.ToString()} - Pnt2: {Pnt2.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return new Pnt3D();
    }
  }

  public static void MiddlePointOfLine(Pnt3D Pnt1, Pnt3D Pnt2, ref Pnt3D MiddlePoint)
  {
    MiddlePoint = new Pnt3D(Pnt3D.MiddlePointOfLine(Pnt1, Pnt2));
  }

  public static Pnt3D operator +(Pnt3D P1, Pnt3D P2)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = P1.X + P2.X;
    pnt3D.Y = P1.Y + P2.Y;
    pnt3D.Z = P1.Z + P2.Z;
    return pnt3D;
  }

  public static Pnt3D operator -(Pnt3D P1, Pnt3D P2)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = P1.X - P2.X;
    pnt3D.Y = P1.Y - P2.Y;
    pnt3D.Z = P1.Z - P2.Z;
    return pnt3D;
  }

  public static bool operator ==(Pnt3D P1, Pnt3D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return true;
    return P1.Equal(P2);
  }

  public static bool operator !=(Pnt3D P1, Pnt3D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return false;
    return !P1.Equal(P2);
  }

  public override string ToString()
  {
    return $"X:{this.X.ToString("f4")}; Y:{this.Y.ToString("f4")}; Z:{this.Z.ToString("f4")}";
  }

  public string ToString(int Decimal)
  {
    return $"X:{this.X.ToString("f" + Decimal.ToString())}; Y:{this.Y.ToString("f" + Decimal.ToString())}; Z:{this.Z.ToString("f" + Decimal.ToString())}";
  }

  public static Pnt3D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt3D pnt3D = new Pnt3D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pnt3D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt3D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt3D.Z = 0.0;
      }
      if (strArray.Length > 2)
      {
        pnt3D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt3D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt3D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      return pnt3D;
    }
    catch (Exception ex)
    {
      return new Pnt3D();
    }
  }

  public new string ToDef()
  {
    return $"X:{this.X.ToString("")}; Y:{this.Y.ToString("")}; Z:{this.Z.ToString("")}";
  }

  public string ToDefNumber()
  {
    return $"{this.X.ToString("")};{this.Y.ToString("")};{this.Z.ToString("")}";
  }

  public new string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.X.ToString("")}; Y:{this.Y.ToString("")}; Z:{this.Z.ToString("")}";
  }
}
