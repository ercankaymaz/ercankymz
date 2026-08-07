// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ECNamedDomainParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ECNamedDomainParameters : ECDomainParameters
{
  private readonly DerObjectIdentifier name;

  public DerObjectIdentifier Name => this.name;

  public ECNamedDomainParameters(DerObjectIdentifier name, ECDomainParameters dp)
    : this(name, dp.Curve, dp.G, dp.N, dp.H, dp.GetSeed())
  {
  }

  public ECNamedDomainParameters(DerObjectIdentifier name, X9ECParameters x9)
    : base(x9)
  {
    this.name = name;
  }

  public ECNamedDomainParameters(DerObjectIdentifier name, ECCurve curve, ECPoint g, BigInteger n)
    : base(curve, g, n)
  {
    this.name = name;
  }

  public ECNamedDomainParameters(
    DerObjectIdentifier name,
    ECCurve curve,
    ECPoint g,
    BigInteger n,
    BigInteger h)
    : base(curve, g, n, h)
  {
    this.name = name;
  }

  public ECNamedDomainParameters(
    DerObjectIdentifier name,
    ECCurve curve,
    ECPoint g,
    BigInteger n,
    BigInteger h,
    byte[] seed)
    : base(curve, g, n, h, seed)
  {
    this.name = name;
  }
}
