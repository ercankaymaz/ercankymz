// Decompiled with JetBrains decompiler
// Type: buClass.Pnt12D
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
public class Pnt12D : Pnt9D
{
  public double I;
  public double J;
  public double K;

  public Pnt12D()
  {
  }

  public Pnt12D(Pnt12D Pnt)
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
    this.I = Pnt.I;
    this.J = Pnt.J;
    this.K = Pnt.K;
  }

  public Pnt12D(Pnt9D Pnt)
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
    this.I = 0.0;
    this.J = 0.0;
    this.K = 0.0;
  }

  public Pnt12D(Pnt6D Pnt)
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
    this.I = 0.0;
    this.J = 0.0;
    this.K = 0.0;
  }

  public Pnt12D(Pnt3D Pnt)
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
    this.I = 0.0;
    this.J = 0.0;
    this.K = 0.0;
  }

  public Pnt12D(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double u,
    double v,
    double w,
    double i,
    double j,
    double k)
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
    this.I = i;
    this.J = j;
    this.K = k;
  }

  public Pnt12D(double x, double y, double z)
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
    this.I = 0.0;
    this.J = 0.0;
    this.K = 0.0;
  }

  public static bool Equal(Pnt12D RefP1, Pnt12D RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(Pnt12D RefP1, Pnt12D RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public static bool EqualXY(Pnt12D RefP1, Pnt12D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXYZ(Pnt12D RefP1, Pnt12D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    double num3 = Math.Abs(RefP1.Z - RefP2.Z);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare & num3 < buSystem.resolutionCompare;
  }

  public bool Equal(Pnt12D RefP) => this.Equal(RefP, buSystem.resolutionCompare);

  public bool Equal(Pnt12D RefP, double Resolution)
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
    double num10 = this.I - RefP.I;
    double num11 = this.J - RefP.J;
    double num12 = this.K - RefP.K;
    return Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3 + num4 * num4 + num5 * num5 + num6 * num6 + num7 * num7 + num8 * num8 + num9 * num9 + num10 * num10 + num11 * num11 + num12 * num12) < buSystem.resolutionCompare;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    Pnt12D pnt12D = new Pnt12D();
    return this.Equal((Pnt12D) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static Pnt12D Copy(Pnt12D P)
  {
    return new Pnt12D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W, P.I, P.J, P.K);
  }

  public static Pnt12D Copy(Pnt6D P)
  {
    return new Pnt12D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
  }

  public static Pnt12D Copy(Pnt3D P)
  {
    return new Pnt12D(P.X, P.Y, P.Z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
  }

  public static Pnt12D[] Copy(Pnt12D[] pts)
  {
    Pnt12D[] pnt12DArray = new Pnt12D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt12DArray[index] = Pnt12D.Copy(pts[index]);
    return pnt12DArray;
  }

  public static List<Pnt12D> Copy(List<Pnt3D> pts)
  {
    List<Pnt12D> pnt12DList = new List<Pnt12D>();
    for (int index = 0; index < pts.Count; ++index)
      pnt12DList.Add(Pnt12D.Copy(pts[index]));
    return pnt12DList;
  }

  public static List<Pnt12D> Copy(List<Pnt12D> pts)
  {
    List<Pnt12D> pnt12DList = new List<Pnt12D>();
    for (int index = 0; index < pts.Count; ++index)
      pnt12DList.Add(Pnt12D.Copy(pts[index]));
    return pnt12DList;
  }

  public static void Copy(List<Pnt12D> pts, ref List<Pnt12D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt12D(Pnt12D.Copy(pts[index])));
  }

  public static void Copy(List<Pnt3D> pts, ref List<Pnt12D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt12D(Pnt12D.Copy(pts[index])));
  }

  public static void Copy(List<Pnt6D> pts, ref List<Pnt12D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt12D(Pnt12D.Copy(pts[index])));
  }

  public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt12D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt12D> pnt12DList1 = new List<Pnt12D>();
      List<Pnt12D> pnt12DList2 = Pnt12D.Copy(pts[index]);
      CopiedPnt.Add(pnt12DList2);
    }
  }

  public static void Copy(List<List<Pnt12D>> pts, ref List<List<Pnt12D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt12D> pnt12DList1 = new List<Pnt12D>();
      List<Pnt12D> pnt12DList2 = Pnt12D.Copy(pts[index]);
      CopiedPnt.Add(pnt12DList2);
    }
  }

  public static void Copy(List<Pnt12D> pts, ref Pnt12D[] CopiedPnt)
  {
    try
    {
      CopiedPnt = new Pnt12D[pts.Count];
      if (pts.Count <= 0)
        return;
      for (int index = 0; index <= pts.Count - 1; ++index)
        CopiedPnt[index] = new Pnt12D(pts[index]);
    }
    catch (Exception ex)
    {
    }
  }

  public static void Add(List<Pnt12D> pts, ref List<Pnt12D> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pnt12D.Copy(pts[index]));
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
    double w,
    double i,
    double j,
    double k)
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
    this.I += i;
    this.J += j;
    this.K += k;
  }

  public static void Offset(
    List<Pnt12D> pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC,
    double offsetU,
    double offsetV,
    double offsetW,
    double offsetI,
    double offsetJ,
    double offsetK)
  {
    for (int index = 0; index < pts.Count; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW, offsetI, offsetJ, offsetK);
  }

  public static void Offset(
    Pnt12D[] pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC,
    double offsetU,
    double offsetV,
    double offsetW,
    double offsetI,
    double offsetJ,
    double offsetK)
  {
    for (int index = 0; index < pts.Length; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW, offsetI, offsetJ, offsetK);
  }

  public static void Offset(
    Pnt12D pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC,
    double offsetU,
    double offsetV,
    double offsetW,
    double offsetI,
    double offsetJ,
    double offsetK)
  {
    pts.Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW, offsetI, offsetJ, offsetK);
  }

  public static Pnt12D operator +(Pnt12D P1, Pnt12D P2)
  {
    Pnt12D pnt12D = new Pnt12D();
    pnt12D.X = P1.X + P2.X;
    pnt12D.Y = P1.Y + P2.Y;
    pnt12D.Z = P1.Z + P2.Z;
    pnt12D.A = P1.A + P2.A;
    pnt12D.B = P1.B + P2.B;
    pnt12D.C = P1.C + P2.C;
    pnt12D.U = P1.U + P2.U;
    pnt12D.V = P1.V + P2.V;
    pnt12D.W = P1.W + P2.W;
    pnt12D.I = P1.I + P2.I;
    pnt12D.J = P1.J + P2.J;
    pnt12D.K = P1.K + P2.K;
    return pnt12D;
  }

  public static Pnt12D operator -(Pnt12D P1, Pnt12D P2)
  {
    Pnt12D pnt12D = new Pnt12D();
    pnt12D.X = P1.X - P2.X;
    pnt12D.Y = P1.Y - P2.Y;
    pnt12D.Z = P1.Z - P2.Z;
    pnt12D.A = P1.A - P2.A;
    pnt12D.B = P1.B - P2.B;
    pnt12D.C = P1.C - P2.C;
    pnt12D.U = P1.U - P2.U;
    pnt12D.V = P1.V - P2.V;
    pnt12D.W = P1.W - P2.W;
    pnt12D.I = P1.I - P2.I;
    pnt12D.J = P1.J - P2.J;
    pnt12D.K = P1.K - P2.K;
    return pnt12D;
  }

  public static bool operator ==(Pnt12D P1, Pnt12D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return true;
    return P1.Equal(P2);
  }

  public static bool operator !=(Pnt12D P1, Pnt12D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return false;
    return !P1.Equal(P2);
  }

  public override string ToString()
  {
    return $"X:{this.X.ToString("f4")}; Y:{this.Y.ToString("f4")}; Z:{this.Z.ToString("f4")}; A:{this.A.ToString("f4")}; B:{this.B.ToString("f4")}; C:{this.C.ToString("f4")}; U:{this.U.ToString("f4")}; V:{this.V.ToString("f4")}; W:{this.W.ToString("f4")}; I:{this.I.ToString("f4")}; J:{this.J.ToString("f4")}; K:{this.K.ToString("f4")}";
  }

  public static Pnt12D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt12D pnt12D = new Pnt12D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("A:", "");
      Value = Value.Replace("B:", "");
      Value = Value.Replace("C:", "");
      Value = Value.Replace("U:", "");
      Value = Value.Replace("V:", "");
      Value = Value.Replace("W:", "");
      Value = Value.Replace("I:", "");
      Value = Value.Replace("J:", "");
      Value = Value.Replace("K:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt12D.A = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt12D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt12D.B = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length == 6)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt12D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt12D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt12D.C = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      if (strArray.Length == 7)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt12D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt12D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt12D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt12D.U = double.Parse(strArray[6], (IFormatProvider) provider);
      }
      if (strArray.Length == 8)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt12D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt12D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt12D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt12D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt12D.V = double.Parse(strArray[7], (IFormatProvider) provider);
      }
      if (strArray.Length >= 9)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt12D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt12D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt12D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt12D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt12D.V = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt12D.W = double.Parse(strArray[8], (IFormatProvider) provider);
      }
      if (strArray.Length >= 10)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt12D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt12D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt12D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt12D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt12D.V = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt12D.W = double.Parse(strArray[8], (IFormatProvider) provider);
        pnt12D.I = double.Parse(strArray[9], (IFormatProvider) provider);
      }
      if (strArray.Length >= 11)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt12D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt12D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt12D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt12D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt12D.V = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt12D.W = double.Parse(strArray[8], (IFormatProvider) provider);
        pnt12D.I = double.Parse(strArray[9], (IFormatProvider) provider);
        pnt12D.J = double.Parse(strArray[10], (IFormatProvider) provider);
      }
      if (strArray.Length >= 12)
      {
        pnt12D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt12D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt12D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt12D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt12D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt12D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt12D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt12D.V = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt12D.W = double.Parse(strArray[8], (IFormatProvider) provider);
        pnt12D.I = double.Parse(strArray[9], (IFormatProvider) provider);
        pnt12D.J = double.Parse(strArray[10], (IFormatProvider) provider);
        pnt12D.K = double.Parse(strArray[11], (IFormatProvider) provider);
      }
      return pnt12D;
    }
    catch (Exception ex)
    {
      return new Pnt12D();
    }
  }

  public new string ToDef()
  {
    return $"X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}; U:{this.U.ToString()}; V:{this.V.ToString()}; W:{this.W.ToString()}; I:{this.I.ToString()}; J:{this.J.ToString()}; K:{this.K.ToString()}";
  }

  public new string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}; U:{this.U.ToString()}; V:{this.V.ToString()}; W:{this.W.ToString()}; I:{this.U.ToString()}; J:{this.V.ToString()}; K:{this.W.ToString()}";
  }
}
