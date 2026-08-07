// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Gost3410KeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public abstract class Gost3410KeyParameters : AsymmetricKeyParameter
{
  private readonly Gost3410Parameters parameters;
  private readonly DerObjectIdentifier publicKeyParamSet;

  protected Gost3410KeyParameters(bool isPrivate, Gost3410Parameters parameters)
    : base(isPrivate)
  {
    this.parameters = parameters;
  }

  protected Gost3410KeyParameters(bool isPrivate, DerObjectIdentifier publicKeyParamSet)
    : base(isPrivate)
  {
    this.parameters = Gost3410KeyParameters.LookupParameters(publicKeyParamSet);
    this.publicKeyParamSet = publicKeyParamSet;
  }

  public Gost3410Parameters Parameters => this.parameters;

  public DerObjectIdentifier PublicKeyParamSet => this.publicKeyParamSet;

  private static Gost3410Parameters LookupParameters(DerObjectIdentifier publicKeyParamSet)
  {
    Gost3410ParamSetParameters paramSetParameters = publicKeyParamSet != null ? Gost3410NamedParameters.GetByOid(publicKeyParamSet) : throw new ArgumentNullException(nameof (publicKeyParamSet));
    if (paramSetParameters == null)
      throw new ArgumentException("OID is not a valid CryptoPro public key parameter set", nameof (publicKeyParamSet));
    return new Gost3410Parameters(paramSetParameters.P, paramSetParameters.Q, paramSetParameters.A);
  }
}
