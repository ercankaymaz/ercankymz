// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math.EC;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ECPublicKeyParameters : ECKeyParameters
{
  private readonly ECPoint q;

  public ECPublicKeyParameters(ECPoint q, ECDomainParameters parameters)
    : this("EC", q, parameters)
  {
  }

  public ECPublicKeyParameters(string algorithm, ECPoint q, ECDomainParameters parameters)
    : base(algorithm, false, parameters)
  {
    this.q = ECDomainParameters.ValidatePublicPoint(this.Parameters.Curve, q);
  }

  public ECPublicKeyParameters(string algorithm, ECPoint q, DerObjectIdentifier publicKeyParamSet)
    : base(algorithm, false, publicKeyParamSet)
  {
    this.q = ECDomainParameters.ValidatePublicPoint(this.Parameters.Curve, q);
  }

  public ECPoint Q => this.q;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is ECPublicKeyParameters other && this.Equals(other);
  }

  protected bool Equals(ECPublicKeyParameters other)
  {
    return this.q.Equals(other.q) && this.Equals((ECKeyParameters) other);
  }

  public override int GetHashCode() => this.q.GetHashCode() ^ base.GetHashCode();
}
