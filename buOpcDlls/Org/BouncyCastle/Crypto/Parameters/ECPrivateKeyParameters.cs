// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ECPrivateKeyParameters : ECKeyParameters
{
  private readonly BigInteger d;

  public ECPrivateKeyParameters(BigInteger d, ECDomainParameters parameters)
    : this("EC", d, parameters)
  {
  }

  public ECPrivateKeyParameters(string algorithm, BigInteger d, ECDomainParameters parameters)
    : base(algorithm, true, parameters)
  {
    this.d = this.Parameters.ValidatePrivateScalar(d);
  }

  public ECPrivateKeyParameters(
    string algorithm,
    BigInteger d,
    DerObjectIdentifier publicKeyParamSet)
    : base(algorithm, true, publicKeyParamSet)
  {
    this.d = this.Parameters.ValidatePrivateScalar(d);
  }

  public BigInteger D => this.d;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is ECPrivateKeyParameters other && this.Equals(other);
  }

  protected bool Equals(ECPrivateKeyParameters other)
  {
    return this.d.Equals(other.d) && this.Equals((ECKeyParameters) other);
  }

  public override int GetHashCode() => this.d.GetHashCode() ^ base.GetHashCode();
}
