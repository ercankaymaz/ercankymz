// Decompiled with JetBrains decompiler
// Type: buClass.ForceCamAxisStrings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class ForceCamAxisStrings
{
  public string X = "";
  public string Y = "";
  public string Z = "";
  public string A = "";
  public string B = "";
  public string C = "";
  public string U = "";
  public string V = "";
  public string W = "";

  public ForceCamAxisStrings()
  {
  }

  public ForceCamAxisStrings(string x, string y, string z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = "";
    this.B = "";
    this.C = "";
    this.U = "";
    this.V = "";
    this.W = "";
  }

  public ForceCamAxisStrings(string x, string y, string z, string a, string b, string c)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
    this.U = "";
    this.V = "";
    this.W = "";
  }

  public ForceCamAxisStrings(
    string x,
    string y,
    string z,
    string a,
    string b,
    string c,
    string u,
    string v,
    string w)
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

  public ForceCamAxisStrings(ForceCamAxisStrings axis)
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
