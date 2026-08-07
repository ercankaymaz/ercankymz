// Decompiled with JetBrains decompiler
// Type: buClass.Pnt6D
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
public class Pnt6D : buSerilization
{
  public double X;
  public double Y;
  public double Z;
  public double A;
  public double B;
  public double C;

  public Pnt6D()
  {
  }

  public Pnt6D(Pnt6D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
  }

  public Pnt6D(Pnt6DS Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
  }

  public Pnt6D(Pnt6D Pnt, int Round)
  {
    if (Round <= 0)
    {
      this.X = Pnt.X;
      this.Y = Pnt.Y;
      this.Z = Pnt.Z;
      this.A = Pnt.A;
      this.B = Pnt.B;
      this.C = Pnt.C;
    }
    else
    {
      this.X = Math.Round(Pnt.X, Round);
      this.Y = Math.Round(Pnt.Y, Round);
      this.Z = Math.Round(Pnt.Z, Round);
      this.A = Math.Round(Pnt.A, Round);
      this.B = Math.Round(Pnt.B, Round);
      this.C = Math.Round(Pnt.C, Round);
    }
  }

  public Pnt6D(Pnt9D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
  }

  public Pnt6D(Pnt9DCam Pnt)
  {
    this.X = Pnt.P9.X;
    this.Y = Pnt.P9.Y;
    this.Z = Pnt.P9.Z;
    this.A = Pnt.P9.A;
    this.B = Pnt.P9.B;
    this.C = Pnt.P9.C;
  }

  public Pnt6D(Pnt3D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = 0.0;
    this.B = 0.0;
    this.C = 0.0;
  }

  public Pnt6D(Pnt3D Pnt, double a, double b, double c)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = a;
    this.B = b;
    this.C = c;
  }

  public Pnt6D(Pnt3D Pnt, OrientationAngle Angles)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Angles.A;
    this.B = Angles.B;
    this.C = Angles.C;
  }

  public Pnt6D(double x, double y, double z, double a, double b, double c)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
  }

  public Pnt6D(double x, double y, double z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = 0.0;
    this.B = 0.0;
    this.C = 0.0;
  }

  public static bool EqualXY(Pnt6D RefP1, Pnt6D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare;
  }

  public static bool EqualXYZ(Pnt6D RefP1, Pnt6D RefP2)
  {
    double num1 = Math.Abs(RefP1.X - RefP2.X);
    double num2 = Math.Abs(RefP1.Y - RefP2.Y);
    double num3 = Math.Abs(RefP1.Z - RefP2.Z);
    return num1 < buSystem.resolutionCompare & num2 < buSystem.resolutionCompare & num3 < buSystem.resolutionCompare;
  }

  public static bool Equal(Pnt6D RefP1, Pnt6D RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(Pnt6D RefP1, Pnt6D RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public bool Equal(Pnt6D RefP) => this.Equal(RefP, buSystem.resolutionCompare);

  public bool Equal(Pnt6D RefP, double Resolution)
  {
    if (!(RefP != (Pnt6D) null))
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
    Pnt6D pnt6D = new Pnt6D();
    return this.Equal((Pnt6D) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static void CoordinateCopy(Pnt6D refPoint, ref Pnt6D copyPoint)
  {
    if (!(refPoint != (Pnt6D) null))
      return;
    if (copyPoint == (Pnt6D) null)
      copyPoint = new Pnt6D();
    copyPoint.X = refPoint.X;
    copyPoint.Y = refPoint.Y;
    copyPoint.Z = refPoint.Z;
    copyPoint.A = refPoint.A;
    copyPoint.B = refPoint.B;
    copyPoint.C = refPoint.C;
  }

  public static Pnt6D Copy(Pnt6D P) => new Pnt6D(P.X, P.Y, P.Z, P.A, P.B, P.C);

  public static Pnt6D Copy(Pnt3D P) => new Pnt6D(P.X, P.Y, P.Z, 0.0, 0.0, 0.0);

  public static Pnt6D[] Copy(Pnt6D[] pts)
  {
    Pnt6D[] pnt6DArray = new Pnt6D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt6DArray[index] = Pnt6D.Copy(pts[index]);
    return pnt6DArray;
  }

  public static List<Pnt6D> Copy(List<Pnt6D> pts)
  {
    List<Pnt6D> pnt6DList = new List<Pnt6D>();
    for (int index = 0; index < pts.Count; ++index)
      pnt6DList.Add(Pnt6D.Copy(pts[index]));
    return pnt6DList;
  }

  public static void Copy(List<Pnt6D> pts, ref List<Pnt6D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt6D(Pnt6D.Copy(pts[index])));
  }

  public static void Copy(List<Pnt3D> pts, ref List<Pnt6D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt6D(pts[index]));
  }

  public static void Copy(List<Pnt6D> pts, ref List<Pnt3D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt3D(pts[index]));
  }

  public static void Copy(List<List<Pnt6D>> pts, ref List<List<Pnt6D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
      List<Pnt6D> pnt6DList2 = Pnt6D.Copy(pts[index]);
      CopiedPnt.Add(pnt6DList2);
    }
  }

  public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt6D>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt6D> CopiedPnt1 = new List<Pnt6D>();
      Pnt6D.Copy(pts[index], ref CopiedPnt1);
      CopiedPnt.Add(CopiedPnt1);
    }
  }

  public static void Copy(List<Pnt3D> pts, OrientationAngle Orientation, ref List<Pnt6D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt6D(new Pnt3D(pts[index]), new OrientationAngle(Orientation)));
  }

  public static void Add(List<Pnt6D> pts, ref List<Pnt6D> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pnt6D.Copy(pts[index]));
  }

  public static void Add(List<Pnt3D> pts, ref List<Pnt6D> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pnt6D.Copy(pts[index]));
  }

  public static void Add(List<Pnt6D> pts, ref List<List<Pnt6D>> CopiedPnt)
  {
    List<Pnt6D> CopiedPnt1 = new List<Pnt6D>();
    Pnt6D.Copy(pts, ref CopiedPnt1);
    CopiedPnt.Add(CopiedPnt1);
  }

  public static void Add(List<List<Pnt6D>> SourceList, ref List<List<Pnt6D>> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
      {
        List<Pnt6D> CopiedPnt = new List<Pnt6D>();
        Pnt6D.Copy(SourceList[index], ref CopiedPnt);
        TargetList.Add(CopiedPnt);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static void GetDifferences(Pnt6D First, Pnt6D Second, ref Length6D Delta)
  {
    Delta.dX = Second.X - First.X;
    Delta.dY = Second.Y - First.Y;
    Delta.dZ = Second.Z - First.Z;
    Delta.dA = Second.A - First.A;
    Delta.dB = Second.B - First.B;
    Delta.dC = Second.C - First.C;
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
    List<Pnt6D> pts,
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
    Pnt6D[] pts,
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
    Pnt6D pts,
    double offsetX,
    double offsetY,
    double offsetZ,
    double offsetA,
    double offsetB,
    double offsetC)
  {
    pts.Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
  }

  public static Pnt6D operator +(Pnt6D P1, Pnt6D P2)
  {
    return new Pnt6D()
    {
      X = P1.X + P2.X,
      Y = P1.Y + P2.Y,
      Z = P1.Z + P2.Z,
      A = P1.A + P2.A,
      B = P1.B + P2.B,
      C = P1.C + P2.C
    };
  }

  public static Pnt6D operator -(Pnt6D P1, Pnt6D P2)
  {
    return new Pnt6D()
    {
      X = P1.X - P2.X,
      Y = P1.Y - P2.Y,
      Z = P1.Z - P2.Z,
      A = P1.A - P2.A,
      B = P1.B - P2.B,
      C = P1.C - P2.C
    };
  }

  public static bool operator ==(Pnt6D P1, Pnt6D P2)
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

  public static bool operator !=(Pnt6D P1, Pnt6D P2)
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

  public static Pnt6D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt6D pnt6D = new Pnt6D();
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
        pnt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6D.Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        pnt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        pnt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt6D.A = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        pnt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt6D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt6D.B = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length >= 6)
      {
        pnt6D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt6D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt6D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt6D.C = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      return pnt6D;
    }
    catch (Exception ex)
    {
      return new Pnt6D();
    }
  }

  public string ToDefNumber()
  {
    return $"{this.X.ToString()};{this.Y.ToString()};{this.Z.ToString()};{this.A.ToString()};{this.B.ToString()};{this.C.ToString()}";
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
