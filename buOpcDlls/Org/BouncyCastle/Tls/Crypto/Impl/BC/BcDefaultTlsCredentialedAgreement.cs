// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcDefaultTlsCredentialedAgreement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcDefaultTlsCredentialedAgreement : TlsCredentialedAgreement, TlsCredentials
{
  protected readonly TlsCredentialedAgreement m_agreementCredentials;

  public BcDefaultTlsCredentialedAgreement(
    BcTlsCrypto crypto,
    Certificate certificate,
    AsymmetricKeyParameter privateKey)
  {
    if (crypto == null)
      throw new ArgumentNullException(nameof (crypto));
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    if (certificate.IsEmpty)
      throw new ArgumentException("cannot be empty", nameof (certificate));
    if (privateKey == null)
      throw new ArgumentNullException(nameof (privateKey));
    if (!privateKey.IsPrivate)
      throw new ArgumentException("must be private", nameof (privateKey));
    switch (privateKey)
    {
      case DHPrivateKeyParameters _:
        this.m_agreementCredentials = (TlsCredentialedAgreement) new BcDefaultTlsCredentialedAgreement.DHCredentialedAgreement(crypto, certificate, (DHPrivateKeyParameters) privateKey);
        break;
      case ECPrivateKeyParameters _:
        this.m_agreementCredentials = (TlsCredentialedAgreement) new BcDefaultTlsCredentialedAgreement.ECCredentialedAgreement(crypto, certificate, (ECPrivateKeyParameters) privateKey);
        break;
      default:
        throw new ArgumentException("'privateKey' type not supported: " + privateKey.GetType().FullName);
    }
  }

  public virtual Certificate Certificate => this.m_agreementCredentials.Certificate;

  public virtual TlsSecret GenerateAgreement(TlsCertificate peerCertificate)
  {
    return this.m_agreementCredentials.GenerateAgreement(peerCertificate);
  }

  private sealed class DHCredentialedAgreement : TlsCredentialedAgreement, TlsCredentials
  {
    private readonly BcTlsCrypto m_crypto;
    private readonly Certificate m_certificate;
    private readonly DHPrivateKeyParameters m_privateKey;

    internal DHCredentialedAgreement(
      BcTlsCrypto crypto,
      Certificate certificate,
      DHPrivateKeyParameters privateKey)
    {
      this.m_crypto = crypto;
      this.m_certificate = certificate;
      this.m_privateKey = privateKey;
    }

    public TlsSecret GenerateAgreement(TlsCertificate peerCertificate)
    {
      return (TlsSecret) BcTlsDHDomain.CalculateDHAgreement(this.m_crypto, this.m_privateKey, BcTlsCertificate.Convert(this.m_crypto, peerCertificate).GetPubKeyDH(), false);
    }

    public Certificate Certificate => this.m_certificate;
  }

  private sealed class ECCredentialedAgreement : TlsCredentialedAgreement, TlsCredentials
  {
    private readonly BcTlsCrypto m_crypto;
    private readonly Certificate m_certificate;
    private readonly ECPrivateKeyParameters m_privateKey;

    internal ECCredentialedAgreement(
      BcTlsCrypto crypto,
      Certificate certificate,
      ECPrivateKeyParameters privateKey)
    {
      this.m_crypto = crypto;
      this.m_certificate = certificate;
      this.m_privateKey = privateKey;
    }

    public TlsSecret GenerateAgreement(TlsCertificate peerCertificate)
    {
      return (TlsSecret) BcTlsECDomain.CalculateECDHAgreement(this.m_crypto, this.m_privateKey, BcTlsCertificate.Convert(this.m_crypto, peerCertificate).GetPubKeyEC());
    }

    public Certificate Certificate => this.m_certificate;
  }
}
