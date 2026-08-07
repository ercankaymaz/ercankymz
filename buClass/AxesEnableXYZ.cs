// Decompiled with JetBrains decompiler
// Type: buClass.AxesEnableXYZ
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class AxesEnableXYZ
{
  public bool X = true;
  public bool Y = true;
  public bool Z = true;

  public AxesEnableXYZ()
  {
  }

  public AxesEnableXYZ(bool x, bool y, bool z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
  }

  public AxesEnableXYZ(AxesEnable axis)
  {
    this.X = axis.X;
    this.Y = axis.Y;
    this.Z = axis.Z;
  }

  public override string ToString()
  {
    return $"X: {this.X.ToString()} , Y: {this.Y.ToString()} , Z: {this.Z.ToString()}";
  }
}
