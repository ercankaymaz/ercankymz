// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Robotic.Vector3DD
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using System;

#nullable disable
namespace buCadCamResVer5.Robotic;

public class Vector3DD
{
  public double X { get; set; }

  public double Y { get; set; }

  public double Z { get; set; }

  public Vector3DD(double x, double y, double z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
  }

  public double Length() => Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

  public Vector3DD Normalize()
  {
    double num = this.Length();
    return num >= 1E-10 ? new Vector3DD(this.X / num, this.Y / num, this.Z / num) : this;
  }

  public static Vector3DD Cross(Vector3DD a, Vector3DD b)
  {
    return new Vector3DD(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
  }

  public static double Dot(Vector3DD a, Vector3DD b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
}
