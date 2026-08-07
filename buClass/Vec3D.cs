// Decompiled with JetBrains decompiler
// Type: buClass.Vec3D
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
public class Vec3D : buSerilization
{
  public double X;
  public double Y;
  public double Z;

  public Vec3D()
  {
  }

  public Vec3D(Vec3D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
  }

  public Vec3D(Pnt9D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
  }

  public Vec3D(Pnt6D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
  }

  public Vec3D(Pnt3D startPoint, Pnt3D endPoint)
  {
    this.X = endPoint.X - startPoint.X;
    this.Y = endPoint.Y - startPoint.Y;
    this.Z = endPoint.Z - startPoint.Z;
  }

  public Vec3D(double x, double y)
  {
    this.X = x;
    this.Y = y;
    this.Z = 0.0;
  }

  public Vec3D(double x, double y, double z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
  }

  public double Magnitude => Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

  public void Normalise()
  {
    double num = Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
    if (num <= 0.001)
      return;
    this.X /= num;
    this.Y /= num;
    this.Z /= num;
  }

  public static Vec3D Normalise(Vec3D RefVector)
  {
    Vec3D vec3D = new Vec3D();
    double num = Math.Sqrt(RefVector.X * RefVector.X + RefVector.Y * RefVector.Y + RefVector.Z * RefVector.Z);
    if (num > 0.001)
    {
      vec3D.X = RefVector.X / num;
      vec3D.Y = RefVector.Y / num;
      vec3D.Z = RefVector.Z / num;
    }
    return vec3D;
  }

  public static Vec3D CrossProduct(Vec3D v1, Vec3D v2)
  {
    return new Vec3D(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
  }

  public static double DotProduct(Vec3D v1, Vec3D v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

  public Vec3D CrossProduct(Vec3D v) => Vec3D.CrossProduct(this, v);

  public double DotProduct(Vec3D v) => Vec3D.DotProduct(this, v);

  public static bool isForeFace(Pnt3D pt1, Pnt3D pt2, Pnt3D pt3)
  {
    return new Vec3D(pt2, pt1).CrossProduct(new Vec3D(pt2, pt3)).DotProduct(new Vec3D(0.0, 0.0, 1.0)) < 0.0;
  }

  public static bool isBackFace(Pnt3D pt1, Pnt3D pt2, Pnt3D pt3)
  {
    return new Vec3D(pt2, pt1).CrossProduct(new Vec3D(pt2, pt3)).DotProduct(new Vec3D(0.0, 0.0, 1.0)) > 0.0;
  }

  public static bool Equal(Vec3D RefP1, Vec3D RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(Vec3D RefP1, Vec3D RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public bool Equal(Vec3D RefP) => this.Equal(RefP, buSystem.resolutionCompare);

  public bool Equal(Vec3D RefP, double Resolution)
  {
    double num1 = this.X - RefP.X;
    double num2 = this.Y - RefP.Y;
    double num3 = this.Z - RefP.Z;
    return Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3) < buSystem.resolutionCompare;
  }

  public bool IsInside(Vec3D MinPnt, Vec3D MaxPnt)
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
      return this.IsInside(new Vec3D(this.X - dX, this.Y - dY, this.Z - dZ), new Vec3D(this.X + dX, this.Y + dY, this.Z + dZ));
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
      return this.IsInside(new Vec3D(this.X - dX, this.Y - dY, this.Z), new Vec3D(this.X + dX, this.Y + dY, this.Z));
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
    Vec3D vec3D = new Vec3D();
    return this.Equal((Vec3D) obj);
  }

  public override int GetHashCode() => base.GetHashCode();

  public static Vec3D Copy(Vec3D P) => new Vec3D(P.X, P.Y, P.Z);

  public static Vec3D[] Copy(Vec3D[] pts)
  {
    Vec3D[] vec3DArray = new Vec3D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      vec3DArray[index] = Vec3D.Copy(pts[index]);
    return vec3DArray;
  }

  public static List<Vec3D> Copy(List<Vec3D> pts)
  {
    List<Vec3D> vec3DList = new List<Vec3D>();
    for (int index = 0; index < pts.Count; ++index)
      vec3DList.Add(Vec3D.Copy(pts[index]));
    return vec3DList;
  }

  public void Offset(double x, double y, double z)
  {
    this.X += x;
    this.Y += y;
    this.Z += z;
  }

  public static void Offset(List<Vec3D> pts, double offsetX, double offsetY, double offsetZ)
  {
    for (int index = 0; index < pts.Count; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ);
  }

  public static void Offset(Vec3D[] pts, double offsetX, double offsetY, double offsetZ)
  {
    for (int index = 0; index < pts.Length; ++index)
      pts[index].Offset(offsetX, offsetY, offsetZ);
  }

  public static void Offset(Vec3D pts, double offsetX, double offsetY, double offsetZ)
  {
    pts.Offset(offsetX, offsetY, offsetZ);
  }

  public static Vec3D operator +(Vec3D P1, Vec3D P2)
  {
    return new Vec3D()
    {
      X = P1.X + P2.X,
      Y = P1.Y + P2.Y,
      Z = P1.Z + P2.Z
    };
  }

  public static Vec3D operator -(Vec3D P1, Vec3D P2)
  {
    return new Vec3D()
    {
      X = P1.X - P2.X,
      Y = P1.Y - P2.Y,
      Z = P1.Z - P2.Z
    };
  }

  public static bool operator ==(Vec3D P1, Vec3D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return true;
    return P1.Equal(P2);
  }

  public static bool operator !=(Vec3D P1, Vec3D P2)
  {
    if ((object) P1 == null && (object) P2 == null)
      return false;
    return !P1.Equal(P2);
  }

  public static bool isVectorXAxis(Vec3D V)
  {
    return Math.Abs(V.X - 1.0) <= 0.001 & Math.Abs(V.Y - 0.0) <= 0.001 & Math.Abs(V.Z - 0.0) <= 0.001;
  }

  public static bool isVectorYAxis(Vec3D V)
  {
    return Math.Abs(V.X - 0.0) <= 0.001 & Math.Abs(V.Y - 1.0) <= 0.001 & Math.Abs(V.Z - 0.0) <= 0.001;
  }

  public static bool isVectorZAxis(Vec3D V)
  {
    return Math.Abs(V.X - 0.0) <= 0.001 & Math.Abs(V.Y - 0.0) <= 0.001 & Math.Abs(V.Z - 1.0) <= 0.001;
  }

  public static Vec3D XAxis() => new Vec3D(1.0, 0.0, 0.0);

  public static Vec3D YAxis() => new Vec3D(0.0, 1.0, 0.0);

  public static Vec3D ZAxis() => new Vec3D(0.0, 0.0, 1.0);

  public override string ToString()
  {
    return $"X:{this.X.ToString("f4")}; Y:{this.Y.ToString("f4")}; Z:{this.Z.ToString("f4")}";
  }

  public static Vec3D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Vec3D vec3D = new Vec3D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        vec3D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        vec3D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        vec3D.Z = 0.0;
      }
      if (strArray.Length > 2)
      {
        vec3D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        vec3D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        vec3D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      return vec3D;
    }
    catch (Exception ex)
    {
      return new Vec3D();
    }
  }

  public string ToDefNumber()
  {
    return $"{this.X.ToString("")};{this.Y.ToString("")};{this.Z.ToString("")}";
  }

  public string ToDef()
  {
    return $"X:{this.X.ToString("")}; Y:{this.Y.ToString("")}; Z:{this.Z.ToString("")}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.X.ToString("")}; Y:{this.Y.ToString("")}; Z:{this.Z.ToString("")}";
  }
}
