// Decompiled with JetBrains decompiler
// Type: buClass.Pnt4D
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

#nullable disable
namespace buClass;

[Serializable]
public class Pnt4D : Pnt3D
{
  public double W;

  public Pnt4D()
  {
  }

  public Pnt4D(Pnt4D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.W = Pnt.W;
  }

  public Pnt4D(Pnt9D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.W = 0.0;
  }

  public Pnt4D(Pnt6D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.W = 0.0;
  }

  public Pnt4D(double x, double y, double z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.W = 0.0;
  }

  public Pnt4D(double x, double y, double z, double w)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.W = w;
  }

  public static bool Equal(Pnt4D RefP1, Pnt4D RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(Pnt4D RefP1, Pnt4D RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public static bool EqualXY(Pnt4D RefP1, Pnt4D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXYZ(Pnt4D RefP1, Pnt4D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    double num3 = Math.Abs(RefP1.Z - RefP2.Z);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare & num3 < buSystem.resolutionCompare;
  }

  public bool Equal(Pnt4D RefP) => this.Equal(RefP, buSystem.resolutionCompare);

  public bool Equal(Pnt4D RefP, double Resolution)
  {
    double num1 = this.X - RefP.X;
    double num2 = this.Y - RefP.Y;
    double num3 = this.Z - RefP.Z;
    double num4 = this.W - RefP.W;
    return Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3 + num4 * num4) < buSystem.resolutionCompare;
  }

  public bool IsInside(Pnt4D MinPnt, Pnt4D MaxPnt)
  {
    try
    {
      bool flag = false;
      if (this.X >= MinPnt.X & this.X <= MaxPnt.X && this.Y >= MinPnt.Y & this.Y <= MaxPnt.Y && this.Z >= MinPnt.Z & this.Z <= MaxPnt.Z && this.W >= MinPnt.W & this.W <= MaxPnt.W)
        flag = true;
      return flag;
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
    Pnt4D pnt4D = new Pnt4D();
    return this.Equal((Pnt4D) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static Pnt4D Copy(Pnt4D P) => new Pnt4D(P.X, P.Y, P.Z, P.W);

  public static Pnt4D[] Copy(Pnt4D[] pts)
  {
    Pnt4D[] pnt4DArray = new Pnt4D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt4DArray[index] = Pnt4D.Copy(pts[index]);
    return pnt4DArray;
  }

  public static List<Pnt4D> Copy(List<Pnt4D> pts)
  {
    List<Pnt4D> pnt4DList = new List<Pnt4D>();
    for (int index = 0; index < pts.Count; ++index)
      pnt4DList.Add(Pnt4D.Copy(pts[index]));
    return pnt4DList;
  }

  public static void Copy(List<Pnt4D> pts, ref List<Pnt4D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt4D(Pnt4D.Copy(pts[index])));
  }

  public static void Copy(List<Pnt4D> pts, ref List<List<Pnt4D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    List<Pnt4D> CopiedPnt1 = new List<Pnt4D>();
    Pnt4D.Copy(pts, ref CopiedPnt1);
    CopiedPnt.Add(CopiedPnt1);
  }

  public static void Copy(List<List<Pnt4D>> pts, ref List<List<Pnt4D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt4D> pnt4DList1 = new List<Pnt4D>();
      List<Pnt4D> pnt4DList2 = Pnt4D.Copy(pts[index]);
      CopiedPnt.Add(pnt4DList2);
    }
  }

  public static void Copy(List<Pnt4D> pts, ref Pnt4D[] CopiedPnt)
  {
    try
    {
      CopiedPnt = new Pnt4D[pts.Count];
      if (pts.Count <= 0)
        return;
      for (int index = 0; index <= pts.Count - 1; ++index)
        CopiedPnt[index] = new Pnt4D(pts[index]);
    }
    catch (Exception ex)
    {
    }
  }

  public static void Copy(List<List<Pnt4D>> SourceList, ref List<Pnt4D> TargetList)
  {
    try
    {
      if (SourceList == null)
        return;
      TargetList = new List<Pnt4D>();
      for (int index1 = 0; index1 <= SourceList.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= SourceList[index1].Count - 1; ++index2)
          TargetList.Add(new Pnt4D(SourceList[index1][index2]));
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static void Add(List<Pnt4D> pts, ref List<Pnt4D> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pnt4D.Copy(pts[index]));
  }

  public static void Add(List<Pnt4D> pts, ref List<List<Pnt4D>> CopiedPnt)
  {
    List<Pnt4D> CopiedPnt1 = new List<Pnt4D>();
    Pnt4D.Copy(pts, ref CopiedPnt1);
    CopiedPnt.Add(CopiedPnt1);
  }

  public static void Add(List<List<Pnt4D>> SourceList, ref List<List<Pnt4D>> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
      {
        List<Pnt4D> CopiedPnt = new List<Pnt4D>();
        Pnt4D.Copy(SourceList[index], ref CopiedPnt);
        TargetList.Add(CopiedPnt);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static Pnt4D operator +(Pnt4D P1, Pnt4D P2)
  {
    Pnt4D pnt4D = new Pnt4D();
    pnt4D.X = P1.X + P2.X;
    pnt4D.Y = P1.Y + P2.Y;
    pnt4D.Z = P1.Z + P2.Z;
    pnt4D.W = P1.W + P2.W;
    return pnt4D;
  }

  public static Pnt4D operator -(Pnt4D P1, Pnt4D P2)
  {
    Pnt4D pnt4D = new Pnt4D();
    pnt4D.X = P1.X - P2.X;
    pnt4D.Y = P1.Y - P2.Y;
    pnt4D.Z = P1.Z - P2.Z;
    pnt4D.W = P1.W - P2.W;
    return pnt4D;
  }

  public static bool operator ==(Pnt4D P1, Pnt4D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return true;
    return P1.Equal(P2);
  }

  public static bool operator !=(Pnt4D P1, Pnt4D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return false;
    return !P1.Equal(P2);
  }

  public override string ToString()
  {
    return $"X:{this.X.ToString("f4")}; Y:{this.Y.ToString("f4")}; Z:{this.Z.ToString("f4")}; W:{this.W.ToString("f4")}";
  }

  public new string ToString(int Decimal)
  {
    return $"X:{this.X.ToString("f" + Decimal.ToString())}; Y:{this.Y.ToString("f" + Decimal.ToString())}; Z:{this.Z.ToString("f" + Decimal.ToString())}; W:{this.W.ToString("f" + Decimal.ToString())}";
  }

  public static Pnt4D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt4D pnt4D = new Pnt4D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("W:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pnt4D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt4D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt4D.Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        pnt4D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt4D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt4D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length > 3)
      {
        pnt4D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt4D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt4D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt4D.W = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      return pnt4D;
    }
    catch (Exception ex)
    {
      return new Pnt4D();
    }
  }

  public new string ToDef()
  {
    return $"X:{this.X.ToString("")}; Y:{this.Y.ToString("")}; Z:{this.Z.ToString("")}; W:{this.W.ToString("")}";
  }

  public new string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.X.ToString("")}; Y:{this.Y.ToString("")}; Z:{this.Z.ToString("")}; W:{this.W.ToString("")}";
  }
}
