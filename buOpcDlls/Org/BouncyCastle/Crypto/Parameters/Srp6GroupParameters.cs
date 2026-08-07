// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Srp6GroupParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class Srp6GroupParameters
{
  private readonly BigInteger n;
  private readonly BigInteger g;

  public Srp6GroupParameters(BigInteger N, BigInteger g)
  {
    this.n = N;
    this.g = g;
  }

  public BigInteger G => this.g;

  public BigInteger N => this.n;
}
