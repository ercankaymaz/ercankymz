// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.NaccacheSternKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class NaccacheSternKeyParameters : AsymmetricKeyParameter
{
  private readonly BigInteger g;
  private readonly BigInteger n;
  private readonly int lowerSigmaBound;

  public NaccacheSternKeyParameters(
    bool privateKey,
    BigInteger g,
    BigInteger n,
    int lowerSigmaBound)
    : base(privateKey)
  {
    this.g = g;
    this.n = n;
    this.lowerSigmaBound = lowerSigmaBound;
  }

  public BigInteger G => this.g;

  public int LowerSigmaBound => this.lowerSigmaBound;

  public BigInteger Modulus => this.n;
}
