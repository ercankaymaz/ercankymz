// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DHPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DHPrivateKeyParameters : DHKeyParameters
{
  private readonly BigInteger x;

  public DHPrivateKeyParameters(BigInteger x, DHParameters parameters)
    : base(true, parameters)
  {
    this.x = x;
  }

  public DHPrivateKeyParameters(
    BigInteger x,
    DHParameters parameters,
    DerObjectIdentifier algorithmOid)
    : base(true, parameters, algorithmOid)
  {
    this.x = x;
  }

  public BigInteger X => this.x;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is DHPrivateKeyParameters other && this.Equals(other);
  }

  protected bool Equals(DHPrivateKeyParameters other)
  {
    return this.x.Equals(other.x) && this.Equals((DHKeyParameters) other);
  }

  public override int GetHashCode() => this.x.GetHashCode() ^ base.GetHashCode();
}
