// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ECKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public abstract class ECKeyParameters : AsymmetricKeyParameter
{
  private static readonly Dictionary<string, string> Algorithms = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
  {
    {
      "EC",
      "EC"
    },
    {
      "ECDSA",
      "ECDSA"
    },
    {
      "ECDH",
      "ECDH"
    },
    {
      "ECDHC",
      "ECDHC"
    },
    {
      "ECGOST3410",
      "ECGOST3410"
    },
    {
      "ECMQV",
      "ECMQV"
    }
  };
  private readonly string algorithm;
  private readonly ECDomainParameters parameters;
  private readonly DerObjectIdentifier publicKeyParamSet;

  protected ECKeyParameters(string algorithm, bool isPrivate, ECDomainParameters parameters)
    : base(isPrivate)
  {
    if (algorithm == null)
      throw new ArgumentNullException(nameof (algorithm));
    if (parameters == null)
      throw new ArgumentNullException(nameof (parameters));
    this.algorithm = ECKeyParameters.VerifyAlgorithmName(algorithm);
    this.parameters = parameters;
    this.publicKeyParamSet = parameters is ECNamedDomainParameters domainParameters ? domainParameters.Name : (DerObjectIdentifier) null;
  }

  protected ECKeyParameters(
    string algorithm,
    bool isPrivate,
    DerObjectIdentifier publicKeyParamSet)
    : base(isPrivate)
  {
    if (algorithm == null)
      throw new ArgumentNullException(nameof (algorithm));
    if (publicKeyParamSet == null)
      throw new ArgumentNullException(nameof (publicKeyParamSet));
    this.algorithm = ECKeyParameters.VerifyAlgorithmName(algorithm);
    this.parameters = ECKeyParameters.LookupParameters(publicKeyParamSet);
    this.publicKeyParamSet = publicKeyParamSet;
  }

  public string AlgorithmName => this.algorithm;

  public ECDomainParameters Parameters => this.parameters;

  public DerObjectIdentifier PublicKeyParamSet => this.publicKeyParamSet;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is ECDomainParameters domainParameters && this.Equals((object) domainParameters);
  }

  protected bool Equals(ECKeyParameters other)
  {
    return this.parameters.Equals((object) other.parameters) && this.Equals((AsymmetricKeyParameter) other);
  }

  public override int GetHashCode() => this.parameters.GetHashCode() ^ base.GetHashCode();

  internal ECKeyGenerationParameters CreateKeyGenerationParameters(SecureRandom random)
  {
    return this.publicKeyParamSet != null ? new ECKeyGenerationParameters(this.publicKeyParamSet, random) : new ECKeyGenerationParameters(this.parameters, random);
  }

  internal static string VerifyAlgorithmName(string algorithm)
  {
    string str;
    if (!ECKeyParameters.Algorithms.TryGetValue(algorithm, out str))
      throw new ArgumentException("unrecognised algorithm: " + algorithm, nameof (algorithm));
    return str;
  }

  internal static ECDomainParameters LookupParameters(DerObjectIdentifier publicKeyParamSet)
  {
    return new ECDomainParameters((publicKeyParamSet != null ? ECKeyPairGenerator.FindECCurveByOid(publicKeyParamSet) : throw new ArgumentNullException(nameof (publicKeyParamSet))) ?? throw new ArgumentException("OID is not a valid public key parameter set", nameof (publicKeyParamSet)));
  }
}
