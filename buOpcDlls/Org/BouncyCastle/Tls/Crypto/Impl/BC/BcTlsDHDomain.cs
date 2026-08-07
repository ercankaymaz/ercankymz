// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsDHDomain
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsDHDomain : TlsDHDomain
{
  protected readonly BcTlsCrypto m_crypto;
  protected readonly TlsDHConfig m_config;
  protected readonly DHParameters m_domainParameters;

  private static byte[] EncodeValue(DHParameters dh, bool padded, BigInteger x)
  {
    return !padded ? BigIntegers.AsUnsignedByteArray(x) : BigIntegers.AsUnsignedByteArray(BcTlsDHDomain.GetValueLength(dh), x);
  }

  private static int GetValueLength(DHParameters dh) => BigIntegers.GetUnsignedByteLength(dh.P);

  public static BcTlsSecret CalculateDHAgreement(
    BcTlsCrypto crypto,
    DHPrivateKeyParameters privateKey,
    DHPublicKeyParameters publicKey,
    bool padded)
  {
    DHBasicAgreement dhBasicAgreement = new DHBasicAgreement();
    dhBasicAgreement.Init((ICipherParameters) privateKey);
    BigInteger agreement = dhBasicAgreement.CalculateAgreement((ICipherParameters) publicKey);
    byte[] data = BcTlsDHDomain.EncodeValue(privateKey.Parameters, padded, agreement);
    return crypto.AdoptLocalSecret(data);
  }

  public static DHParameters GetDomainParameters(TlsDHConfig dhConfig)
  {
    DHGroup dhGroup = TlsDHUtilities.GetDHGroup(dhConfig);
    if (dhGroup == null)
      throw new ArgumentException("No DH configuration provided");
    return new DHParameters(dhGroup.P, dhGroup.G, dhGroup.Q, dhGroup.L);
  }

  public BcTlsDHDomain(BcTlsCrypto crypto, TlsDHConfig dhConfig)
  {
    this.m_crypto = crypto;
    this.m_config = dhConfig;
    this.m_domainParameters = BcTlsDHDomain.GetDomainParameters(dhConfig);
  }

  public virtual BcTlsSecret CalculateDHAgreement(
    DHPrivateKeyParameters privateKey,
    DHPublicKeyParameters publicKey)
  {
    return BcTlsDHDomain.CalculateDHAgreement(this.m_crypto, privateKey, publicKey, this.m_config.IsPadded);
  }

  public virtual TlsAgreement CreateDH() => (TlsAgreement) new BcTlsDH(this);

  public virtual BigInteger DecodeParameter(byte[] encoding)
  {
    if (this.m_config.IsPadded && BcTlsDHDomain.GetValueLength(this.m_domainParameters) != encoding.Length)
      throw new TlsFatalAlert((short) 47);
    return new BigInteger(1, encoding);
  }

  public virtual DHPublicKeyParameters DecodePublicKey(byte[] encoding)
  {
    try
    {
      return new DHPublicKeyParameters(this.DecodeParameter(encoding), this.m_domainParameters);
    }
    catch (Exception ex)
    {
      throw new TlsFatalAlert((short) 40, ex);
    }
  }

  public virtual byte[] EncodeParameter(BigInteger x)
  {
    return BcTlsDHDomain.EncodeValue(this.m_domainParameters, this.m_config.IsPadded, x);
  }

  public virtual byte[] EncodePublicKey(DHPublicKeyParameters publicKey)
  {
    return BcTlsDHDomain.EncodeValue(this.m_domainParameters, true, publicKey.Y);
  }

  public virtual AsymmetricCipherKeyPair GenerateKeyPair()
  {
    DHBasicKeyPairGenerator keyPairGenerator = new DHBasicKeyPairGenerator();
    keyPairGenerator.Init((KeyGenerationParameters) new DHKeyGenerationParameters(this.m_crypto.SecureRandom, this.m_domainParameters));
    return keyPairGenerator.GenerateKeyPair();
  }
}
