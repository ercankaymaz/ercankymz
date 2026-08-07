// Decompiled with JetBrains decompiler
// Type: buClass.Pnt9DS
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
public class Pnt9DS : buSerilization
{
  public double X;
  public double Y;
  public double Z;
  public double A;
  public double B;
  public double C;
  public double U;
  public double V;
  public double W;
  public string S = "";

  public Pnt9DS()
  {
  }

  public Pnt9DS(Pnt9DS Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
    this.U = Pnt.U;
    this.V = Pnt.V;
    this.W = Pnt.W;
    this.S = Pnt.S;
  }

  public Pnt9DS(Pnt6D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
    this.U = 0.0;
    this.V = 0.0;
    this.W = 0.0;
  }

  public Pnt9DS(Pnt3D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = 0.0;
    this.B = 0.0;
    this.C = 0.0;
    this.U = 0.0;
    this.V = 0.0;
    this.W = 0.0;
  }

  public Pnt9DS(Pnt9DCam Pnt)
  {
    this.X = Pnt.P9.X;
    this.Y = Pnt.P9.Y;
    this.Z = Pnt.P9.Z;
    this.A = Pnt.P9.A;
    this.B = Pnt.P9.B;
    this.C = Pnt.P9.C;
    this.U = Pnt.P9.U;
    this.V = Pnt.P9.V;
    this.W = Pnt.P9.W;
  }

  public Pnt9DS(double x, double y, double z, double a, double b, double c)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
    this.U = 0.0;
    this.V = 0.0;
    this.W = 0.0;
  }

  public Pnt9DS(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double u,
    double v,
    double w)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
    this.U = u;
    this.V = v;
    this.W = w;
  }

  public Pnt9DS(double x, double y, double z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = 0.0;
    this.B = 0.0;
    this.C = 0.0;
    this.A = 0.0;
    this.B = 0.0;
    this.C = 0.0;
    this.U = 0.0;
    this.V = 0.0;
    this.W = 0.0;
  }

  public static bool Equal(Pnt9DS RefP1, Pnt9DS RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(Pnt9DS RefP1, Pnt9DS RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public static bool EqualXY(Pnt9DS RefP1, Pnt9DS RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXY(Pnt9DS RefP1, Pnt9DS RefP2, double Resolution)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXYZ(Pnt9DS RefP1, Pnt9DS RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    double num3 = Math.Abs(RefP1.Z - RefP2.Z);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare & num3 < buSystem.resolutionCompare;
  }

  public static bool EqualXYZ(Pnt9DS RefP1, Pnt9DS RefP2, double Resolution)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    double num3 = Math.Abs(RefP1.Z - RefP2.Z);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare & num3 < buSystem.resolutionCompare;
  }

  public bool Equal(Pnt9DS RefP) => this.Equal(RefP, buSystem.resolutionCompare);

  public bool Equal(Pnt9DS RefP, double Resolution)
  {
    double num1 = this.X - RefP.X;
    double num2 = this.Y - RefP.Y;
    double num3 = this.Z - RefP.Z;
    double num4 = this.A - RefP.A;
    double num5 = this.B - RefP.B;
    double num6 = this.C - RefP.C;
    double num7 = this.U - RefP.U;
    double num8 = this.V - RefP.V;
    double num9 = this.W - RefP.W;
    return Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3 + num4 * num4 + num5 * num5 + num6 * num6 + num7 * num7 + num8 * num8 + num9 * num9) < buSystem.resolutionCompare;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    Pnt9DS pnt9Ds = new Pnt9DS();
    return this.Equal((Pnt9DS) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static Pnt9DS Copy(Pnt9DS P) => new Pnt9DS(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);

  public static Pnt9DS Copy(Pnt6D P) => new Pnt9DS(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);

  public static Pnt9DS Copy(Pnt3D P) => new Pnt9DS(P.X, P.Y, P.Z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

  public static Pnt9DS[] Copy(Pnt9DS[] pts)
  {
    Pnt9DS[] pnt9DsArray = new Pnt9DS[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt9DsArray[index] = Pnt9DS.Copy(pts[index]);
    return pnt9DsArray;
  }

  public static List<Pnt9DS> Copy(List<Pnt3D> pts)
  {
    List<Pnt9DS> pnt9DsList = new List<Pnt9DS>();
    for (int index = 0; index < pts.Count; ++index)
      pnt9DsList.Add(Pnt9DS.Copy(pts[index]));
    return pnt9DsList;
  }

  public static List<Pnt9DS> Copy(List<Pnt9DS> pts)
  {
    List<Pnt9DS> pnt9DsList = new List<Pnt9DS>();
    for (int index = 0; index < pts.Count; ++index)
      pnt9DsList.Add(Pnt9DS.Copy(pts[index]));
    return pnt9DsList;
  }

  public static void Copy(List<Pnt9DS> pts, ref List<Pnt9DS> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt9DS(Pnt9DS.Copy(pts[index])));
  }

  public static void Copy(List<Pnt3D> pts, ref List<Pnt9DS> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt9DS(Pnt9DS.Copy(pts[index])));
  }

  public static void Copy(List<Pnt6D> pts, ref List<Pnt9DS> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt9DS(Pnt9DS.Copy(pts[index])));
  }

  public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt9DS>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt9DS> pnt9DsList1 = new List<Pnt9DS>();
      List<Pnt9DS> pnt9DsList2 = Pnt9DS.Copy(pts[index]);
      CopiedPnt.Add(pnt9DsList2);
    }
  }

  public static void Copy(List<List<Pnt9DS>> pts, ref List<List<Pnt9DS>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt9DS> pnt9DsList1 = new List<Pnt9DS>();
      List<Pnt9DS> pnt9DsList2 = Pnt9DS.Copy(pts[index]);
      CopiedPnt.Add(pnt9DsList2);
    }
  }

  public static void Copy(List<Pnt9DS> pts, ref Pnt9DS[] CopiedPnt)
  {
    try
    {
      CopiedPnt = new Pnt9DS[pts.Count];
      if (pts.Count <= 0)
        return;
      for (int index = 0; index <= pts.Count - 1; ++index)
        CopiedPnt[index] = new Pnt9DS(pts[index]);
    }
    catch (Exception ex)
    {
    }
  }

  public static void Add(List<Pnt9DS> pts, ref List<Pnt9DS> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pnt9DS.Copy(pts[index]));
  }

  public void Offset(double x, double y, double z)
  {
    this.X += x;
    this.Y += y;
    this.Z += z;
  }

  public void Offset(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double u,
    double v,
    double w)
  {
    this.X += x;
    this.Y += y;
    this.Z += z;
    this.A += a;
    this.B += b;
    this.C += c;
    this.U += u;
    this.V += v;
    this.W += w;
  }

  public static void Offset(
    List<Pnt9DS> pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC,
    double offsetU,
    double offsetV,
    double offsetW)
  {
    for (int index = 0; index < pts.Count; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW);
  }

  public static void Offset(
    Pnt9DS[] pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC,
    double offsetU,
    double offsetV,
    double offsetW)
  {
    for (int index = 0; index < pts.Length; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW);
  }

  public static void Offset(
    Pnt9DS pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC,
    double offsetU,
    double offsetV,
    double offsetW)
  {
    pts.Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW);
  }

  public static Pnt9DS operator +(Pnt9DS P1, Pnt9DS P2)
  {
    return new Pnt9DS()
    {
      X = P1.X + P2.X,
      Y = P1.Y + P2.Y,
      Z = P1.Z + P2.Z,
      A = P1.A + P2.A,
      B = P1.B + P2.B,
      C = P1.C + P2.C,
      U = P1.U + P2.U,
      V = P1.V + P2.V,
      W = P1.W + P2.W
    };
  }

  public static Pnt9DS operator -(Pnt9DS P1, Pnt9DS P2)
  {
    return new Pnt9DS()
    {
      X = P1.X - P2.X,
      Y = P1.Y - P2.Y,
      Z = P1.Z - P2.Z,
      A = P1.A - P2.A,
      B = P1.B - P2.B,
      C = P1.C - P2.C,
      U = P1.U - P2.U,
      V = P1.V - P2.V,
      W = P1.W - P2.W
    };
  }

  public static bool operator ==(Pnt9DS P1, Pnt9DS P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return true;
    return P1.Equal(P2);
  }

  public static bool operator !=(Pnt9DS P1, Pnt9DS P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return false;
    return !P1.Equal(P2);
  }

  public override string ToString()
  {
    return $"X:{this.X.ToString("f4")}; Y:{this.Y.ToString("f4")}; Z:{this.Z.ToString("f4")}; A:{this.A.ToString("f4")}; B:{this.B.ToString("f4")}; C:{this.C.ToString("f4")}; U:{this.U.ToString("f4")}; V:{this.V.ToString("f4")}; W:{this.W.ToString("f4")}; S:{this.S}";
  }

  public static Pnt9DS DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt9DS pnt9Ds = new Pnt9DS();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("A:", "");
      Value = Value.Replace("B:", "");
      Value = Value.Replace("C:", "");
      Value = Value.Replace("U:", "");
      Value = Value.Replace("V:", "");
      Value = Value.Replace("W:", "");
      Value = Value.Replace("S:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pnt9Ds.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9Ds.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9Ds.Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        pnt9Ds.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9Ds.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9Ds.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        pnt9Ds.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9Ds.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9Ds.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9Ds.A = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        pnt9Ds.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9Ds.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9Ds.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9Ds.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9Ds.B = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length == 6)
      {
        pnt9Ds.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9Ds.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9Ds.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9Ds.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9Ds.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9Ds.C = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      if (strArray.Length == 7)
      {
        pnt9Ds.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9Ds.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9Ds.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9Ds.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9Ds.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9Ds.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9Ds.U = double.Parse(strArray[6], (IFormatProvider) provider);
      }
      if (strArray.Length == 8)
      {
        pnt9Ds.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9Ds.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9Ds.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9Ds.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9Ds.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9Ds.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9Ds.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt9Ds.V = double.Parse(strArray[7], (IFormatProvider) provider);
      }
      if (strArray.Length >= 9)
      {
        pnt9Ds.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9Ds.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9Ds.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9Ds.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9Ds.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9Ds.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9Ds.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt9Ds.V = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt9Ds.W = double.Parse(strArray[8], (IFormatProvider) provider);
      }
      if (strArray.Length >= 10)
      {
        pnt9Ds.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9Ds.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9Ds.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9Ds.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9Ds.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9Ds.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9Ds.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt9Ds.V = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt9Ds.W = double.Parse(strArray[8], (IFormatProvider) provider);
        pnt9Ds.S = strArray[9];
      }
      return pnt9Ds;
    }
    catch (Exception ex)
    {
      return new Pnt9DS();
    }
  }

  public string ToDef()
  {
    return $"X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}; U:{this.U.ToString()}; V:{this.V.ToString()}; W:{this.W.ToString()};S:{this.S}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}; U:{this.U.ToString()}; V:{this.V.ToString()}; W:{this.W.ToString()};S:{this.S}";
  }
}
