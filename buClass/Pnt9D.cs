// Decompiled with JetBrains decompiler
// Type: buClass.Pnt9D
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
public class Pnt9D : Pnt6D
{
  public double U;
  public double V;
  public double W;

  public Pnt9D()
  {
  }

  public Pnt9D(Pnt9D Pnt)
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
  }

  public Pnt9D(Pnt6D Pnt)
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

  public Pnt9D(Pnt3D Pnt)
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

  public Pnt9D(Pnt9DCam Pnt)
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

  public Pnt9D(double x, double y, double z, double a, double b, double c)
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

  public Pnt9D(
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

  public Pnt9D(double x, double y, double z)
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

  public static bool Equal(Pnt9D RefP1, Pnt9D RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(Pnt9D RefP1, Pnt9D RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public static bool EqualXY(Pnt9D RefP1, Pnt9D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXY(Pnt9D RefP1, Pnt9D RefP2, double Resolution)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXYZ(Pnt9D RefP1, Pnt9D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    double num3 = Math.Abs(RefP1.Z - RefP2.Z);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare & num3 < buSystem.resolutionCompare;
  }

  public static bool EqualXYZ(Pnt9D RefP1, Pnt9D RefP2, double Resolution)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    double num3 = Math.Abs(RefP1.Z - RefP2.Z);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare & num3 < buSystem.resolutionCompare;
  }

  public bool Equal(Pnt9D RefP) => this.Equal(RefP, buSystem.resolutionCompare);

  public bool Equal(Pnt9D RefP, double Resolution)
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
    Pnt9D pnt9D = new Pnt9D();
    return this.Equal((Pnt9D) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static Pnt9D Copy(Pnt9D P) => new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);

  public static Pnt9D Copy(Pnt6D P) => new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);

  public static Pnt9D Copy(Pnt3D P) => new Pnt9D(P.X, P.Y, P.Z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

  public static Pnt9D[] Copy(Pnt9D[] pts)
  {
    Pnt9D[] pnt9DArray = new Pnt9D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt9DArray[index] = Pnt9D.Copy(pts[index]);
    return pnt9DArray;
  }

  public static List<Pnt9D> Copy(List<Pnt3D> pts)
  {
    List<Pnt9D> pnt9DList = new List<Pnt9D>();
    for (int index = 0; index < pts.Count; ++index)
      pnt9DList.Add(Pnt9D.Copy(pts[index]));
    return pnt9DList;
  }

  public static List<Pnt9D> Copy(List<Pnt9D> pts)
  {
    List<Pnt9D> pnt9DList = new List<Pnt9D>();
    for (int index = 0; index < pts.Count; ++index)
      pnt9DList.Add(Pnt9D.Copy(pts[index]));
    return pnt9DList;
  }

  public static void Copy(List<Pnt9D> pts, ref List<Pnt9D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt9D(Pnt9D.Copy(pts[index])));
  }

  public static void Copy(List<Pnt3D> pts, ref List<Pnt9D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt9D(Pnt9D.Copy(pts[index])));
  }

  public static void Copy(List<Pnt6D> pts, ref List<Pnt9D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt9D(Pnt9D.Copy(pts[index])));
  }

  public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt9D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt9D> pnt9DList1 = new List<Pnt9D>();
      List<Pnt9D> pnt9DList2 = Pnt9D.Copy(pts[index]);
      CopiedPnt.Add(pnt9DList2);
    }
  }

  public static void Copy(List<List<Pnt9D>> pts, ref List<List<Pnt9D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt9D> pnt9DList1 = new List<Pnt9D>();
      List<Pnt9D> pnt9DList2 = Pnt9D.Copy(pts[index]);
      CopiedPnt.Add(pnt9DList2);
    }
  }

  public static void Copy(List<Pnt9D> pts, ref Pnt9D[] CopiedPnt)
  {
    try
    {
      CopiedPnt = new Pnt9D[pts.Count];
      if (pts.Count <= 0)
        return;
      for (int index = 0; index <= pts.Count - 1; ++index)
        CopiedPnt[index] = new Pnt9D(pts[index]);
    }
    catch (Exception ex)
    {
    }
  }

  public static void Add(List<Pnt9D> pts, ref List<Pnt9D> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pnt9D.Copy(pts[index]));
  }

  public new void Offset(double x, double y, double z)
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
    List<Pnt9D> pts,
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
    Pnt9D[] pts,
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
    Pnt9D pts,
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

  public static Pnt9D operator +(Pnt9D P1, Pnt9D P2)
  {
    Pnt9D pnt9D = new Pnt9D();
    pnt9D.X = P1.X + P2.X;
    pnt9D.Y = P1.Y + P2.Y;
    pnt9D.Z = P1.Z + P2.Z;
    pnt9D.A = P1.A + P2.A;
    pnt9D.B = P1.B + P2.B;
    pnt9D.C = P1.C + P2.C;
    pnt9D.U = P1.U + P2.U;
    pnt9D.V = P1.V + P2.V;
    pnt9D.W = P1.W + P2.W;
    return pnt9D;
  }

  public static Pnt9D operator -(Pnt9D P1, Pnt9D P2)
  {
    Pnt9D pnt9D = new Pnt9D();
    pnt9D.X = P1.X - P2.X;
    pnt9D.Y = P1.Y - P2.Y;
    pnt9D.Z = P1.Z - P2.Z;
    pnt9D.A = P1.A - P2.A;
    pnt9D.B = P1.B - P2.B;
    pnt9D.C = P1.C - P2.C;
    pnt9D.U = P1.U - P2.U;
    pnt9D.V = P1.V - P2.V;
    pnt9D.W = P1.W - P2.W;
    return pnt9D;
  }

  public static bool operator ==(Pnt9D P1, Pnt9D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return true;
    return P1.Equal(P2);
  }

  public static bool operator !=(Pnt9D P1, Pnt9D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return false;
    return !P1.Equal(P2);
  }

  public override string ToString()
  {
    return $"X:{this.X.ToString("f4")}; Y:{this.Y.ToString("f4")}; Z:{this.Z.ToString("f4")}; A:{this.A.ToString("f4")}; B:{this.B.ToString("f4")}; C:{this.C.ToString("f4")}; U:{this.U.ToString("f4")}; V:{this.V.ToString("f4")}; W:{this.W.ToString("f4")}";
  }

  public static Pnt9D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt9D pnt9D = new Pnt9D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("A:", "");
      Value = Value.Replace("B:", "");
      Value = Value.Replace("C:", "");
      Value = Value.Replace("U:", "");
      Value = Value.Replace("V:", "");
      Value = Value.Replace("W:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length == 6)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      if (strArray.Length == 7)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9D.U = double.Parse(strArray[6], (IFormatProvider) provider);
      }
      if (strArray.Length == 8)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt9D.V = double.Parse(strArray[7], (IFormatProvider) provider);
      }
      if (strArray.Length >= 9)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt9D.V = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt9D.W = double.Parse(strArray[8], (IFormatProvider) provider);
      }
      return pnt9D;
    }
    catch (Exception ex)
    {
      return new Pnt9D();
    }
  }

  public new string ToDef()
  {
    return $"X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}; U:{this.U.ToString()}; V:{this.V.ToString()}; W:{this.W.ToString()}";
  }

  public new string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}; U:{this.U.ToString()}; V:{this.V.ToString()}; W:{this.W.ToString()}";
  }
}
