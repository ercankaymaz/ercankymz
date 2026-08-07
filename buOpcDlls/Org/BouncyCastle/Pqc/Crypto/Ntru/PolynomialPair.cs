// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.PolynomialPair
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

internal class PolynomialPair
{
  private readonly Polynomial _a;
  private readonly Polynomial _b;

  public PolynomialPair(Polynomial a, Polynomial b)
  {
    this._a = a;
    this._b = b;
  }

  internal Polynomial F() => this._a;

  internal Polynomial G() => this._b;

  internal Polynomial R() => this._a;

  internal Polynomial M() => this._b;
}
