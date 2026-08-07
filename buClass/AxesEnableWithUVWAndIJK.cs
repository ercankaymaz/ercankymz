// Decompiled with JetBrains decompiler
// Type: buClass.AxesEnableWithUVWAndIJK
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class AxesEnableWithUVWAndIJK
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
  public bool I = false;
  public bool J = false;
  public bool K = false;

  public AxesEnableWithUVWAndIJK()
  {
  }

  public AxesEnableWithUVWAndIJK(bool x, bool y, bool z)
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
    this.I = false;
    this.J = false;
    this.J = false;
  }

  public AxesEnableWithUVWAndIJK(bool x, bool y, bool z, bool a, bool b, bool c)
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
    this.I = false;
    this.J = false;
    this.J = false;
  }

  public AxesEnableWithUVWAndIJK(
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
    this.I = false;
    this.J = false;
    this.J = false;
  }

  public AxesEnableWithUVWAndIJK(
    bool x,
    bool y,
    bool z,
    bool a,
    bool b,
    bool c,
    bool u,
    bool v,
    bool w,
    bool i,
    bool j,
    bool k)
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
    this.I = i;
    this.J = j;
    this.J = k;
  }

  public AxesEnableWithUVWAndIJK(AxesEnableWithUVWAndIJK axis)
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
    this.I = axis.I;
    this.J = axis.J;
    this.J = axis.K;
  }

  public override string ToString()
  {
    return $"X: {this.X.ToString()} , Y: {this.Y.ToString()} , Z: {this.Z.ToString()} , A: {this.A.ToString()} , B: {this.B.ToString()} , C: {this.C.ToString()} , U: {this.U.ToString()} , V: {this.V.ToString()} , W: {this.W.ToString()} , I: {this.U.ToString()} , J: {this.V.ToString()} , K: {this.W.ToString()}";
  }
}
