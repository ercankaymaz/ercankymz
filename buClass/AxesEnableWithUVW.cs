// Decompiled with JetBrains decompiler
// Type: buClass.AxesEnableWithUVW
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class AxesEnableWithUVW
{
  public bool X = true;
  public bool Y = true;
  public bool Z = true;
  public bool A = false;
  public bool B = false;
  public bool C = false;
  public bool U = false;
  public bool V = false;
  public bool W = false;

  public AxesEnableWithUVW()
  {
  }

  public AxesEnableWithUVW(bool x, bool y, bool z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = false;
    this.B = false;
    this.C = false;
    this.U = false;
    this.V = false;
    this.W = false;
  }

  public AxesEnableWithUVW(bool x, bool y, bool z, bool a, bool b, bool c)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
    this.U = false;
    this.V = false;
    this.W = false;
  }

  public AxesEnableWithUVW(
    bool x,
    bool y,
    bool z,
    bool a,
    bool b,
    bool c,
    bool u,
    bool v,
    bool w)
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
  }

  public AxesEnableWithUVW(AxesEnableWithUVW axis)
  {
    this.X = axis.X;
    this.Y = axis.Y;
    this.Z = axis.Z;
    this.A = axis.A;
    this.B = axis.B;
    this.C = axis.C;
    this.U = axis.U;
    this.V = axis.V;
    this.W = axis.W;
  }

  public override string ToString()
  {
    return $"X: {this.X.ToString()} , Y: {this.Y.ToString()} , Z: {this.Z.ToString()} , A: {this.A.ToString()} , B: {this.B.ToString()} , C: {this.C.ToString()} , U: {this.U.ToString()} , V: {this.V.ToString()} , W: {this.W.ToString()}";
  }
}
