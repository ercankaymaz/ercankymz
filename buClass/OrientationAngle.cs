// Decompiled with JetBrains decompiler
// Type: buClass.OrientationAngle
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
public class OrientationAngle : buSerilization
{
  public double A;
  public double B;
  public double C;

  public OrientationAngle()
  {
  }

  public OrientationAngle(OrientationAngle Pnt)
  {
    if (!(Pnt != (OrientationAngle) null))
      return;
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
  }

  public OrientationAngle(double a, double b, double c)
  {
    this.A = a;
    this.B = b;
    this.C = c;
  }

  public OrientationAngle(Pnt6D Pnt)
  {
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
  }

  public OrientationAngle(Pnt9D Pnt)
  {
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
  }

  public double Magnitude => Math.Sqrt(this.A * this.A + this.B * this.B + this.C * this.C);

  public void Normalise()
  {
    double num = Math.Sqrt(this.A * this.A + this.B * this.B + this.C * this.C);
    if (num <= 0.001)
      return;
    this.A /= num;
    this.B /= num;
    this.C /= num;
  }

  public static bool Equal(OrientationAngle RefP1, OrientationAngle RefP2)
  {
    return !(RefP1 == (OrientationAngle) null | RefP2 == (OrientationAngle) null) && RefP1.Equal(RefP2);
  }

  public static bool Equal(OrientationAngle RefP1, OrientationAngle RefP2, double Resolution)
  {
    return !(RefP1 == (OrientationAngle) null | RefP2 == (OrientationAngle) null) && RefP1.Equal(RefP2, Resolution);
  }

  public bool Equal(OrientationAngle RefP)
  {
    return !(RefP == (OrientationAngle) null) && this.Equal(RefP, buSystem.resolutionCompare);
  }

  public bool Equal(OrientationAngle RefP, double Resolution)
  {
    if (RefP == (OrientationAngle) null)
      return false;
    double num1 = this.A - RefP.A;
    double num2 = this.B - RefP.B;
    double num3 = this.C - RefP.C;
    return Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3) < buSystem.resolutionCompare;
  }

  public bool IsInside(OrientationAngle MinPnt, OrientationAngle MaxPnt)
  {
    try
    {
      if (MinPnt == (OrientationAngle) null | MaxPnt == (OrientationAngle) null)
        return false;
      bool flag = false;
      if (this.A >= MinPnt.A & this.A <= MaxPnt.A && this.B >= MinPnt.B & this.B <= MaxPnt.B && this.C >= MinPnt.C & this.C <= MaxPnt.C)
        flag = true;
      return flag;
    }
    catch
    {
      return false;
    }
  }

  public bool IsInside(double dA, double dB, double dZ)
  {
    try
    {
      return this.IsInside(new OrientationAngle(this.A - dA, this.B - dB, this.C - dZ), new OrientationAngle(this.A + dA, this.B + dB, this.C + dZ));
    }
    catch
    {
      return false;
    }
  }

  public bool IsInside(double dA, double dB)
  {
    try
    {
      return this.IsInside(new OrientationAngle(this.A - dA, this.B - dB, this.C), new OrientationAngle(this.A + dA, this.B + dB, this.C));
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
    OrientationAngle orientationAngle = new OrientationAngle();
    return this.Equal((OrientationAngle) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static OrientationAngle Copy(OrientationAngle P) => new OrientationAngle(P.A, P.B, P.C);

  public static OrientationAngle[] Copy(OrientationAngle[] pts)
  {
    OrientationAngle[] orientationAngleArray = new OrientationAngle[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      orientationAngleArray[index] = OrientationAngle.Copy(pts[index]);
    return orientationAngleArray;
  }

  public static List<OrientationAngle> Copy(List<OrientationAngle> pts)
  {
    List<OrientationAngle> orientationAngleList = new List<OrientationAngle>();
    for (int index = 0; index < pts.Count; ++index)
      orientationAngleList.Add(OrientationAngle.Copy(pts[index]));
    return orientationAngleList;
  }

  public void Offset(double x, double y, double z)
  {
    this.A += x;
    this.B += y;
    this.C += z;
  }

  public static void Offset(
    List<OrientationAngle> pts,
    double offsetX,
    double offsetY,
    double offsetZ)
  {
    for (int index = 0; index < pts.Count; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ);
  }

  public static void Offset(
    OrientationAngle[] pts,
    double offsetX,
    double offsetY,
    double offsetZ)
  {
    for (int index = 0; index < pts.Length; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ);
  }

  public static void Offset(OrientationAngle pts, double offsetX, double offsetY, double offsetZ)
  {
    pts.Offset(offsetX, offsetY, offsetZ);
  }

  public static OrientationAngle operator +(OrientationAngle P1, OrientationAngle P2)
  {
    if (P1 == (OrientationAngle) null | P2 == (OrientationAngle) null)
      return new OrientationAngle();
    return new OrientationAngle()
    {
      A = P1.A + P2.A,
      B = P1.B + P2.B,
      C = P1.C + P2.C
    };
  }

  public static OrientationAngle operator -(OrientationAngle P1, OrientationAngle P2)
  {
    if (P1 == (OrientationAngle) null | P2 == (OrientationAngle) null)
      return new OrientationAngle();
    return new OrientationAngle()
    {
      A = P1.A - P2.A,
      B = P1.B - P2.B,
      C = P1.C - P2.C
    };
  }

  public static bool operator ==(OrientationAngle P1, OrientationAngle P2)
  {
    if ((object) P1 == null | (object) P2 == null)
      return false;
    return P1.Equal(P2);
  }

  public static bool operator !=(OrientationAngle P1, OrientationAngle P2)
  {
    if ((object) P1 == null | (object) P2 == null)
      return true;
    return !P1.Equal(P2);
  }

  public override string ToString()
  {
    return $"A:{this.A.ToString("f4")}; B:{this.B.ToString("f4")}; C:{this.C.ToString("f4")}";
  }

  public static OrientationAngle DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      OrientationAngle orientationAngle = new OrientationAngle();
      Value = Value.Replace("A:", "");
      Value = Value.Replace("B:", "");
      Value = Value.Replace("C:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        orientationAngle.A = double.Parse(strArray[0], (IFormatProvider) provider);
        orientationAngle.B = double.Parse(strArray[1], (IFormatProvider) provider);
        orientationAngle.C = 0.0;
      }
      if (strArray.Length > 2)
      {
        orientationAngle.A = double.Parse(strArray[0], (IFormatProvider) provider);
        orientationAngle.B = double.Parse(strArray[1], (IFormatProvider) provider);
        orientationAngle.C = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      return orientationAngle;
    }
    catch (Exception ex)
    {
      return new OrientationAngle();
    }
  }

  public string ToDef()
  {
    return $"A:{this.A.ToString("")}; B:{this.B.ToString("")}; C:{this.C.ToString("")}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.A.ToString("")}; Y:{this.B.ToString("")}; Z:{this.C.ToString("")}";
  }
}
