// Decompiled with JetBrains decompiler
// Type: buClass.Pntt6D
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
public class Pntt6D : buSerilization
{
  public double X;
  public double Y;
  public double Z;
  public double A;
  public double B;
  public double C;

  public Pntt6D()
  {
  }

  public Pntt6D(double x, double y, double z, double a, double b, double c)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
  }

  public static bool EqualXY(Pntt6D RefP1, Pntt6D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXYZ(Pntt6D RefP1, Pntt6D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    double num3 = Math.Abs(RefP1.Z - RefP2.Z);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare & num3 < buSystem.resolutionCompare;
  }

  public static bool Equal(Pntt6D RefP1, Pntt6D RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(Pntt6D RefP1, Pntt6D RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public bool Equal(Pntt6D RefP) => this.Equal(RefP, buSystem.resolutionCompare);

  public bool Equal(Pntt6D RefP, double Resolution)
  {
    if (!(RefP != (Pntt6D) null))
      return false;
    double num1 = this.X - RefP.X;
    double num2 = this.Y - RefP.Y;
    double num3 = this.Z - RefP.Z;
    double num4 = this.A - RefP.A;
    double num5 = this.B - RefP.B;
    double num6 = this.C - RefP.C;
    return Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3 + num4 * num4 + num5 * num5 + num6 * num6) < buSystem.resolutionCompare;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    Pntt6D pntt6D = new Pntt6D();
    return this.Equal((Pntt6D) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static Pntt6D Copy(Pntt6D P) => new Pntt6D(P.X, P.Y, P.Z, P.A, P.B, P.C);

  public static Pntt6D Copy(Pnt3D P) => new Pntt6D(P.X, P.Y, P.Z, 0.0, 0.0, 0.0);

  public static Pntt6D[] Copy(Pntt6D[] pts)
  {
    Pntt6D[] pntt6DArray = new Pntt6D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pntt6DArray[index] = Pntt6D.Copy(pts[index]);
    return pntt6DArray;
  }

  public static List<Pntt6D> Copy(List<Pntt6D> pts)
  {
    List<Pntt6D> pntt6DList = new List<Pntt6D>();
    for (int index = 0; index < pts.Count; ++index)
      pntt6DList.Add(Pntt6D.Copy(pts[index]));
    return pntt6DList;
  }

  public static void Copy(List<Pntt6D> pts, ref List<Pntt6D> CopiedPnt)
  {
  }

  public static void Copy(List<Pnt3D> pts, ref List<Pntt6D> CopiedPnt)
  {
  }

  public static void Copy(List<Pntt6D> pts, ref List<Pnt3D> CopiedPnt)
  {
  }

  public static void Copy(List<List<Pntt6D>> pts, ref List<List<Pntt6D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pntt6D> pntt6DList1 = new List<Pntt6D>();
      List<Pntt6D> pntt6DList2 = Pntt6D.Copy(pts[index]);
      CopiedPnt.Add(pntt6DList2);
    }
  }

  public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pntt6D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pntt6D> CopiedPnt1 = new List<Pntt6D>();
      Pntt6D.Copy(pts[index], ref CopiedPnt1);
      CopiedPnt.Add(CopiedPnt1);
    }
  }

  public static void Copy(
    List<Pnt3D> pts,
    OrientationAngle Orientation,
    ref List<Pntt6D> CopiedPnt)
  {
  }

  public static void Add(List<Pntt6D> pts, ref List<Pntt6D> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pntt6D.Copy(pts[index]));
  }

  public static void Add(List<Pnt3D> pts, ref List<Pntt6D> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pntt6D.Copy(pts[index]));
  }

  public static void Add(List<Pntt6D> pts, ref List<List<Pntt6D>> CopiedPnt)
  {
    List<Pntt6D> CopiedPnt1 = new List<Pntt6D>();
    Pntt6D.Copy(pts, ref CopiedPnt1);
    CopiedPnt.Add(CopiedPnt1);
  }

  public static void Add(List<List<Pntt6D>> SourceList, ref List<List<Pntt6D>> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
      {
        List<Pntt6D> CopiedPnt = new List<Pntt6D>();
        Pntt6D.Copy(SourceList[index], ref CopiedPnt);
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

  public void Offset(double x, double y, double z, double a, double b, double c)
  {
    this.X += x;
    this.Y += y;
    this.Z += z;
    this.A += a;
    this.B += b;
    this.C += c;
  }

  public static void Offset(
    List<Pntt6D> pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC)
  {
    for (int index = 0; index < pts.Count; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
  }

  public static void Offset(
    Pntt6D[] pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC)
  {
    for (int index = 0; index < pts.Length; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
  }

  public static void Offset(
    Pntt6D pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC)
  {
    pts.Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
  }

  public static Pntt6D operator +(Pntt6D P1, Pntt6D P2)
  {
    return new Pntt6D()
    {
      X = P1.X + P2.X,
      Y = P1.Y + P2.Y,
      Z = P1.Z + P2.Z,
      A = P1.A + P2.A,
      B = P1.B + P2.B,
      C = P1.C + P2.C
    };
  }

  public static Pntt6D operator -(Pntt6D P1, Pntt6D P2)
  {
    return new Pntt6D()
    {
      X = P1.X - P2.X,
      Y = P1.Y - P2.Y,
      Z = P1.Z - P2.Z,
      A = P1.A - P2.A,
      B = P1.B - P2.B,
      C = P1.C - P2.C
    };
  }

  public static bool operator ==(Pntt6D P1, Pntt6D P2)
  {
    try
    {
      if ((object) P1 == null && (object) P2 == null)
        return true;
      return P1.Equal(P2);
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static bool operator !=(Pntt6D P1, Pntt6D P2)
  {
    try
    {
      if ((object) P1 == null && (object) P2 == null)
        return false;
      return !P1.Equal(P2);
    }
    catch (Exception ex)
    {
      return true;
    }
  }

  public override string ToString()
  {
    return $"X:{this.X.ToString("f4")}; Y:{this.Y.ToString("f4")}; Z:{this.Z.ToString("f4")}; A:{this.A.ToString("f4")}; B:{this.B.ToString("f4")}; C:{this.C.ToString("f4")}";
  }

  public static Pntt6D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pntt6D pntt6D = new Pntt6D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("A:", "");
      Value = Value.Replace("B:", "");
      Value = Value.Replace("C:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pntt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pntt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pntt6D.Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        pntt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pntt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pntt6D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        pntt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pntt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pntt6D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pntt6D.A = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        pntt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pntt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pntt6D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pntt6D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pntt6D.B = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length >= 6)
      {
        pntt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pntt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pntt6D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pntt6D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pntt6D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pntt6D.C = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      return pntt6D;
    }
    catch (Exception ex)
    {
      return new Pntt6D();
    }
  }

  public string ToDef()
  {
    return $"X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}";
  }
}
