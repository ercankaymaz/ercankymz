// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DHKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DHKeyParameters : AsymmetricKeyParameter
{
  private readonly DHParameters parameters;
  private readonly DerObjectIdentifier algorithmOid;

  protected DHKeyParameters(bool isPrivate, DHParameters parameters)
    : this(isPrivate, parameters, PkcsObjectIdentifiers.DhKeyAgreement)
  {
  }

  protected DHKeyParameters(
    bool isPrivate,
    DHParameters parameters,
    DerObjectIdentifier algorithmOid)
    : base(isPrivate)
  {
    this.parameters = parameters;
    this.algorithmOid = algorithmOid;
  }

  public DHParameters Parameters => this.parameters;

  public DerObjectIdentifier AlgorithmOid => this.algorithmOid;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is DHKeyParameters other && this.Equals(other);
  }

  protected bool Equals(DHKeyParameters other)
  {
    return object.Equals((object) this.parameters, (object) other.parameters) && this.Equals((AsymmetricKeyParameter) other);
  }

  public override int GetHashCode()
  {
    int hashCode = base.GetHashCode();
    if (this.parameters != null)
      hashCode ^= this.parameters.GetHashCode();
    return hashCode;
  }
}
