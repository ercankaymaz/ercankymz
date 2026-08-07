// Decompiled with JetBrains decompiler
// Type: buClass.Quaternion
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

public struct Quaternion
{
  public double X;
  public double Y;
  public double Z;
  public double W;

  public Quaternion(double w, double x, double y, double z)
  {
    this.W = w;
    this.X = x;
    this.Y = y;
    this.Z = z;
  }

  public Quaternion(double w, Vec3D v)
  {
    this.W = w;
    this.X = v.X;
    this.Y = v.Y;
    this.Z = v.Z;
  }

  public Vec3D V
  {
    set
    {
      this.X = value.X;
      this.Y = value.Y;
      this.Z = value.Z;
    }
    get => new Vec3D(this.X, this.Y, this.Z);
  }

  public void Normalise()
  {
    double d = this.W * this.W + this.X * this.X + this.Y * this.Y + this.Z * this.Z;
    if (d > 0.001)
    {
      double num = Math.Sqrt(d);
      this.W /= num;
      this.X /= num;
      this.Y /= num;
      this.Z /= num;
    }
    else
    {
      this.W = 1.0;
      this.X = 0.0;
      this.Y = 0.0;
      this.Z = 0.0;
    }
  }

  public void Conjugate()
  {
    this.X = -this.X;
    this.Y = -this.Y;
    this.Z = -this.Z;
  }

  public void FromAxisAngle(Vec3D axis, double angleRadian)
  {
    double magnitude = axis.Magnitude;
    if (magnitude > 0.0001)
    {
      double num1 = Math.Cos(angleRadian / 2.0);
      double num2 = Math.Sin(angleRadian / 2.0);
      this.X = axis.X / magnitude * num2;
      this.Y = axis.Y / magnitude * num2;
      this.Z = axis.Z / magnitude * num2;
      this.W = num1;
    }
    else
    {
      this.W = 1.0;
      this.X = 0.0;
      this.Y = 0.0;
      this.Z = 0.0;
    }
  }

  public Quaternion Copy() => new Quaternion(this.W, this.X, this.Y, this.Z);

  public void Multiply(Quaternion q) => this = this * q;

  public void Rotate(Pnt3D pt)
  {
    this.Normalise();
    Quaternion quaternion1 = this.Copy();
    quaternion1.Conjugate();
    Quaternion quaternion2 = this * new Quaternion(0.0, pt.X, pt.Y, pt.Z) * quaternion1;
    pt.X = quaternion2.X;
    pt.Y = quaternion2.Y;
    pt.Z = quaternion2.Z;
  }

  public void Rotate(Pnt3D[] nodes)
  {
    this.Normalise();
    Quaternion quaternion1 = this.Copy();
    quaternion1.Conjugate();
    for (int index = 0; index < nodes.Length; ++index)
    {
      Quaternion quaternion2 = new Quaternion(0.0, nodes[index].X, nodes[index].Y, nodes[index].Z);
      quaternion2 = this * quaternion2 * quaternion1;
      nodes[index].X = quaternion2.X;
      nodes[index].Y = quaternion2.Y;
      nodes[index].Z = quaternion2.Z;
    }
  }

  public static Quaternion operator *(Quaternion q1, Quaternion q2)
  {
    return new Quaternion(q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z, q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y, q1.W * q2.Y + q1.Y * q2.W + q1.Z * q2.X - q1.X * q2.Z, q1.W * q2.Z + q1.Z * q2.W + q1.X * q2.Y - q1.Y * q2.X);
  }
}
