// Decompiled with JetBrains decompiler
// Type: buClass.Pnt2D
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
public class Pnt2D : buSerilization
{
  public double X;
  public double Y;
  public double Option;

  public Pnt2D()
  {
  }

  public Pnt2D(Pnt2D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
  }

  public Pnt2D(Pnt9D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
  }

  public Pnt2D(Pnt6D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
  }

  public Pnt2D(double x, double y)
  {
    this.X = x;
    this.Y = y;
  }

  public static bool Equal(Pnt2D RefP1, Pnt2D RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(Pnt2D RefP1, Pnt2D RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public bool Equal(Pnt2D RefP)
  {
    double num1 = this.X - RefP.X;
    double num2 = this.Y - RefP.Y;
    return Math.Sqrt(num1 * num1 + num2 * num2) < buSystem.resolutionCompare;
  }

  public bool Equal(Pnt2D RefP, double Resolution)
  {
    double num1 = this.X - RefP.X;
    double num2 = this.Y - RefP.Y;
    return Math.Sqrt(num1 * num1 + num2 * num2) < buSystem.resolutionCompare;
  }

  public bool IsInside(Pnt2D MinPnt, Pnt2D MaxPnt)
  {
    try
    {
      bool flag = false;
      if (this.X >= MinPnt.X & this.X <= MaxPnt.X && this.Y >= MinPnt.Y & this.Y <= MaxPnt.Y)
        flag = true;
      return flag;
    }
    catch
    {
      return false;
    }
  }

  public bool IsInside(double dX, double dY)
  {
    try
    {
      return this.IsInside(new Pnt2D(this.X - dX, this.Y - dY), new Pnt2D(this.X + dX, this.Y + dY));
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
    Pnt2D pnt2D = new Pnt2D();
    return this.Equal((Pnt2D) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static Pnt2D Copy(Pnt2D P) => new Pnt2D(P.X, P.Y);

  public static Pnt2D[] Copy(Pnt2D[] pts)
  {
    Pnt2D[] pnt2DArray = new Pnt2D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt2DArray[index] = Pnt2D.Copy(pts[index]);
    return pnt2DArray;
  }

  public static List<Pnt2D> Copy(List<Pnt2D> pts)
  {
    List<Pnt2D> pnt2DList = new List<Pnt2D>();
    for (int index = 0; index < pts.Count; ++index)
      pnt2DList.Add(Pnt2D.Copy(pts[index]));
    return pnt2DList;
  }

  public void Offset(double x, double y)
  {
    this.X += x;
    this.Y += y;
  }

  public static void Offset(List<Pnt2D> pts, double offsetX, double offsetY)
  {
    for (int index = 0; index < pts.Count; ++index)
      pts[index].Offset(offsetX, offsetY);
  }

  public static void Offset(Pnt2D[] pts, double offsetX, double offsetY)
  {
    for (int index = 0; index < pts.Length; ++index)
      pts[index].Offset(offsetX, offsetY);
  }

  public static void Offset(Pnt2D pts, double offsetX, double offsetY)
  {
    pts.Offset(offsetX, offsetY);
  }

  public static Pnt2D operator +(Pnt2D P1, Pnt2D P2)
  {
    return new Pnt2D() { X = P1.X + P2.X, Y = P1.Y + P2.Y };
  }

  public static Pnt2D operator -(Pnt2D P1, Pnt2D P2)
  {
    return new Pnt2D() { X = P1.X - P2.X, Y = P1.Y - P2.Y };
  }

  public static bool operator ==(Pnt2D P1, Pnt2D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return true;
    return P1.Equal(P2);
  }

  public static bool operator !=(Pnt2D P1, Pnt2D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return false;
    return !P1.Equal(P2);
  }

  public override string ToString() => $"X:{this.X.ToString("f4")}; Y:{this.Y.ToString("f4")}";

  public static Pnt2D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt2D pnt2D = new Pnt2D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pnt2D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt2D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
      }
      return pnt2D;
    }
    catch (Exception ex)
    {
      return new Pnt2D();
    }
  }

  public string ToDef() => $"X:{this.X.ToString("")}; Y:{this.Y.ToString("")}";

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.X.ToString("")}; Y:{this.Y.ToString("")}";
  }
}
