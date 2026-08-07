// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ECKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ECKeyGenerationParameters : KeyGenerationParameters
{
  private readonly ECDomainParameters domainParams;
  private readonly DerObjectIdentifier publicKeyParamSet;

  public ECKeyGenerationParameters(ECDomainParameters domainParameters, SecureRandom random)
    : base(random, domainParameters.N.BitLength)
  {
    this.domainParams = domainParameters;
  }

  public ECKeyGenerationParameters(DerObjectIdentifier publicKeyParamSet, SecureRandom random)
    : this(ECKeyParameters.LookupParameters(publicKeyParamSet), random)
  {
    this.publicKeyParamSet = publicKeyParamSet;
  }

  public ECDomainParameters DomainParameters => this.domainParams;

  public DerObjectIdentifier PublicKeyParamSet => this.publicKeyParamSet;
}
