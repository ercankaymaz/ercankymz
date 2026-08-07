// Decompiled with JetBrains decompiler
// Type: buClass.AxesEnable
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class AxesEnable
{
  public bool X = true;
  public bool Y = true;
  public bool Z = true;
  public bool A = false;
  public bool B = false;
  public bool C = false;

  public AxesEnable()
  {
  }

  public AxesEnable(bool x, bool y, bool z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = false;
    this.B = false;
    this.C = false;
  }

  public AxesEnable(bool x, bool y, bool z, bool a, bool b, bool c)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
  }

  public AxesEnable(AxesEnable axis)
  {
    this.X = axis.X;
    this.Y = axis.Y;
    this.Z = axis.Z;
    this.A = axis.A;
    this.B = axis.B;
    this.C = axis.C;
  }

  public override string ToString()
  {
    return $"X: {this.X.ToString()} , Y: {this.Y.ToString()} , Z: {this.Z.ToString()} , A: {this.A.ToString()} , B: {this.B.ToString()} , C: {this.C.ToString()}";
  }
}
