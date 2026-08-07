// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.AgreementUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Agreement.Kdf;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class AgreementUtilities
{
  private static readonly IDictionary<string, string> Algorithms = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static AgreementUtilities()
  {
    AgreementUtilities.Algorithms[X9ObjectIdentifiers.DHSinglePassCofactorDHSha1KdfScheme.Id] = "ECCDHWITHSHA1KDF";
    AgreementUtilities.Algorithms[X9ObjectIdentifiers.DHSinglePassStdDHSha1KdfScheme.Id] = "ECDHWITHSHA1KDF";
    AgreementUtilities.Algorithms[X9ObjectIdentifiers.MqvSinglePassSha1KdfScheme.Id] = "ECMQVWITHSHA1KDF";
    AgreementUtilities.Algorithms[EdECObjectIdentifiers.id_X25519.Id] = "X25519";
    AgreementUtilities.Algorithms[EdECObjectIdentifiers.id_X448.Id] = "X448";
  }

  public static IBasicAgreement GetBasicAgreement(DerObjectIdentifier oid)
  {
    return AgreementUtilities.GetBasicAgreement(oid.Id);
  }

  public static IBasicAgreement GetBasicAgreement(string algorithm)
  {
    switch (AgreementUtilities.GetMechanism(algorithm))
    {
      case "DH":
      case "DIFFIEHELLMAN":
        return (IBasicAgreement) new DHBasicAgreement();
      case "ECDH":
        return (IBasicAgreement) new ECDHBasicAgreement();
      case "ECDHC":
      case "ECCDH":
        return (IBasicAgreement) new ECDHCBasicAgreement();
      case "ECMQV":
        return (IBasicAgreement) new ECMqvBasicAgreement();
      default:
        throw new SecurityUtilityException($"Basic Agreement {algorithm} not recognised.");
    }
  }

  public static IBasicAgreement GetBasicAgreementWithKdf(
    DerObjectIdentifier oid,
    string wrapAlgorithm)
  {
    return AgreementUtilities.GetBasicAgreementWithKdf(oid.Id, wrapAlgorithm);
  }

  public static IBasicAgreement GetBasicAgreementWithKdf(
    string agreeAlgorithm,
    string wrapAlgorithm)
  {
    switch (AgreementUtilities.GetMechanism(agreeAlgorithm))
    {
      case "DHWITHSHA1KDF":
      case "ECDHWITHSHA1KDF":
        return (IBasicAgreement) new ECDHWithKdfBasicAgreement(wrapAlgorithm, (IDerivationFunction) new ECDHKekGenerator((IDigest) new Sha1Digest()));
      case "ECMQVWITHSHA1KDF":
        return (IBasicAgreement) new ECMqvWithKdfBasicAgreement(wrapAlgorithm, (IDerivationFunction) new ECDHKekGenerator((IDigest) new Sha1Digest()));
      default:
        throw new SecurityUtilityException($"Basic Agreement (with KDF) {agreeAlgorithm} not recognised.");
    }
  }

  public static IRawAgreement GetRawAgreement(DerObjectIdentifier oid)
  {
    return AgreementUtilities.GetRawAgreement(oid.Id);
  }

  public static IRawAgreement GetRawAgreement(string algorithm)
  {
    switch (AgreementUtilities.GetMechanism(algorithm))
    {
      case "X25519":
        return (IRawAgreement) new X25519Agreement();
      case "X448":
        return (IRawAgreement) new X448Agreement();
      default:
        throw new SecurityUtilityException($"Raw Agreement {algorithm} not recognised.");
    }
  }

  public static string GetAlgorithmName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<string, string>(AgreementUtilities.Algorithms, oid.Id);
  }

  private static string GetMechanism(string algorithm)
  {
    return CollectionUtilities.GetValueOrKey<string>(AgreementUtilities.Algorithms, algorithm).ToUpperInvariant();
  }
}
