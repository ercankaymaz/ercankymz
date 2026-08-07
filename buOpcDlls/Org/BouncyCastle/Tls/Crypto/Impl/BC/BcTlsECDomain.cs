// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsECDomain
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsECDomain : TlsECDomain
{
  protected readonly BcTlsCrypto m_crypto;
  protected readonly TlsECConfig m_config;
  protected readonly ECDomainParameters m_domainParameters;

  public static BcTlsSecret CalculateECDHAgreement(
    BcTlsCrypto crypto,
    ECPrivateKeyParameters privateKey,
    ECPublicKeyParameters publicKey)
  {
    ECDHBasicAgreement ecdhBasicAgreement = new ECDHBasicAgreement();
    ecdhBasicAgreement.Init((ICipherParameters) privateKey);
    BigInteger agreement = ecdhBasicAgreement.CalculateAgreement((ICipherParameters) publicKey);
    byte[] data = BigIntegers.AsUnsignedByteArray(ecdhBasicAgreement.GetFieldSize(), agreement);
    return crypto.AdoptLocalSecret(data);
  }

  public static ECDomainParameters GetDomainParameters(TlsECConfig ecConfig)
  {
    return BcTlsECDomain.GetDomainParameters(ecConfig.NamedGroup);
  }

  public static ECDomainParameters GetDomainParameters(int namedGroup)
  {
    if (!NamedGroup.RefersToASpecificCurve(namedGroup))
      return (ECDomainParameters) null;
    X9ECParameters ecCurveByName = ECKeyPairGenerator.FindECCurveByName(NamedGroup.GetCurveName(namedGroup));
    return ecCurveByName == null ? (ECDomainParameters) null : new ECDomainParameters(ecCurveByName.Curve, ecCurveByName.G, ecCurveByName.N, ecCurveByName.H, ecCurveByName.GetSeed());
  }

  public BcTlsECDomain(BcTlsCrypto crypto, TlsECConfig ecConfig)
  {
    this.m_crypto = crypto;
    this.m_config = ecConfig;
    this.m_domainParameters = BcTlsECDomain.GetDomainParameters(ecConfig);
  }

  public virtual BcTlsSecret CalculateECDHAgreement(
    ECPrivateKeyParameters privateKey,
    ECPublicKeyParameters publicKey)
  {
    return BcTlsECDomain.CalculateECDHAgreement(this.m_crypto, privateKey, publicKey);
  }

  public virtual TlsAgreement CreateECDH() => (TlsAgreement) new BcTlsECDH(this);

  public virtual ECPoint DecodePoint(byte[] encoding)
  {
    return this.m_domainParameters.Curve.DecodePoint(encoding);
  }

  public virtual ECPublicKeyParameters DecodePublicKey(byte[] encoding)
  {
    try
    {
      return new ECPublicKeyParameters(this.DecodePoint(encoding), this.m_domainParameters);
    }
    catch (IOException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new TlsFatalAlert((short) 47, ex);
    }
  }

  public virtual byte[] EncodePoint(ECPoint point) => point.GetEncoded(false);

  public virtual byte[] EncodePublicKey(ECPublicKeyParameters publicKey)
  {
    return this.EncodePoint(publicKey.Q);
  }

  public virtual AsymmetricCipherKeyPair GenerateKeyPair()
  {
    ECKeyPairGenerator keyPairGenerator = new ECKeyPairGenerator();
    keyPairGenerator.Init((KeyGenerationParameters) new ECKeyGenerationParameters(this.m_domainParameters, this.m_crypto.SecureRandom));
    return keyPairGenerator.GenerateKeyPair();
  }
}
