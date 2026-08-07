// Decompiled with JetBrains decompiler
// Type: buClass.AngleVector
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class AngleVector : buSerilization
{
  public double X = 0.0;
  public double Y = 0.0;
  public double Z = 0.0;

  public AngleVector()
  {
  }

  public AngleVector(AngleVector angle)
  {
    this.X = angle.X;
    this.Y = angle.Y;
    this.Z = angle.Z;
  }

  public AngleVector(double x, double y, double z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
  }

  public override string ToString()
  {
    return $"X: {this.X.ToString("f3")}  Y: {this.Y.ToString("f3")}  Z: {this.Z.ToString()}";
  }
}
