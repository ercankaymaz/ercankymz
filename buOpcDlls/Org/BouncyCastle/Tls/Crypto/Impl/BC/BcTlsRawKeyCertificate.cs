// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsRawKeyCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsRawKeyCertificate : TlsCertificate
{
  protected readonly BcTlsCrypto m_crypto;
  protected readonly SubjectPublicKeyInfo m_keyInfo;
  protected DHPublicKeyParameters m_pubKeyDH;
  protected ECPublicKeyParameters m_pubKeyEC;
  protected Ed25519PublicKeyParameters m_pubKeyEd25519;
  protected Ed448PublicKeyParameters m_pubKeyEd448;
  protected RsaKeyParameters m_pubKeyRsa;

  public BcTlsRawKeyCertificate(BcTlsCrypto crypto, byte[] encoding)
    : this(crypto, SubjectPublicKeyInfo.GetInstance((object) encoding))
  {
  }

  public BcTlsRawKeyCertificate(BcTlsCrypto crypto, SubjectPublicKeyInfo keyInfo)
  {
    this.m_crypto = crypto;
    this.m_keyInfo = keyInfo;
  }

  public virtual SubjectPublicKeyInfo SubjectPublicKeyInfo => this.m_keyInfo;

  public virtual TlsEncryptor CreateEncryptor(int tlsCertificateRole)
  {
    this.ValidateKeyUsage(32 /*0x20*/);
    if (tlsCertificateRole != 3)
      throw new TlsFatalAlert((short) 46);
    this.m_pubKeyRsa = this.GetPubKeyRsa();
    return (TlsEncryptor) new BcTlsRsaEncryptor(this.m_crypto, this.m_pubKeyRsa);
  }

  public virtual TlsVerifier CreateVerifier(short signatureAlgorithm)
  {
    switch (signatureAlgorithm)
    {
      case 7:
      case 8:
        int signatureScheme1 = SignatureScheme.From((short) 8, signatureAlgorithm);
        Tls13Verifier verifier = this.CreateVerifier(signatureScheme1);
        return (TlsVerifier) new LegacyTls13Verifier(signatureScheme1, verifier);
      default:
        this.ValidateKeyUsage(128 /*0x80*/);
        switch (signatureAlgorithm)
        {
          case 1:
            this.ValidateRsa_Pkcs1();
            return (TlsVerifier) new BcTlsRsaVerifier(this.m_crypto, this.GetPubKeyRsa());
          case 2:
            return (TlsVerifier) new BcTlsDsaVerifier(this.m_crypto, this.GetPubKeyDss());
          case 3:
            return (TlsVerifier) new BcTlsECDsaVerifier(this.m_crypto, this.GetPubKeyEC());
          case 4:
          case 5:
          case 6:
            this.ValidateRsa_Pss_Rsae();
            int signatureScheme2 = SignatureScheme.From((short) 8, signatureAlgorithm);
            return (TlsVerifier) new BcTlsRsaPssVerifier(this.m_crypto, this.GetPubKeyRsa(), signatureScheme2);
          case 9:
          case 10:
          case 11:
            this.ValidateRsa_Pss_Pss(signatureAlgorithm);
            int signatureScheme3 = SignatureScheme.From((short) 8, signatureAlgorithm);
            return (TlsVerifier) new BcTlsRsaPssVerifier(this.m_crypto, this.GetPubKeyRsa(), signatureScheme3);
          default:
            throw new TlsFatalAlert((short) 46);
        }
    }
  }

  public virtual Tls13Verifier CreateVerifier(int signatureScheme)
  {
    this.ValidateKeyUsage(128 /*0x80*/);
    switch (signatureScheme)
    {
      case 513:
      case 1025:
      case 1281:
      case 1537:
        this.ValidateRsa_Pkcs1();
        int cryptoHashAlgorithm = SignatureScheme.GetCryptoHashAlgorithm(signatureScheme);
        RsaDigestSigner verifier1 = new RsaDigestSigner(this.m_crypto.CreateDigest(cryptoHashAlgorithm), TlsCryptoUtilities.GetOidForHash(cryptoHashAlgorithm));
        verifier1.Init(false, (ICipherParameters) this.GetPubKeyRsa());
        return (Tls13Verifier) new BcTls13Verifier((ISigner) verifier1);
      case 515:
      case 1027:
      case 1283:
      case 1539:
      case 2074:
      case 2075:
      case 2076:
        DsaDigestSigner verifier2 = new DsaDigestSigner((IDsa) new ECDsaSigner(), this.m_crypto.CreateDigest(SignatureScheme.GetCryptoHashAlgorithm(signatureScheme)));
        verifier2.Init(false, (ICipherParameters) this.GetPubKeyEC());
        return (Tls13Verifier) new BcTls13Verifier((ISigner) verifier2);
      case 2052:
      case 2053:
      case 2054:
        this.ValidateRsa_Pss_Rsae();
        IDigest digest1 = this.m_crypto.CreateDigest(SignatureScheme.GetCryptoHashAlgorithm(signatureScheme));
        PssSigner verifier3 = new PssSigner((IAsymmetricBlockCipher) new RsaEngine(), digest1, digest1.GetDigestSize());
        verifier3.Init(false, (ICipherParameters) this.GetPubKeyRsa());
        return (Tls13Verifier) new BcTls13Verifier((ISigner) verifier3);
      case 2055:
        Ed25519Signer verifier4 = new Ed25519Signer();
        verifier4.Init(false, (ICipherParameters) this.GetPubKeyEd25519());
        return (Tls13Verifier) new BcTls13Verifier((ISigner) verifier4);
      case 2056:
        Ed448Signer verifier5 = new Ed448Signer(TlsUtilities.EmptyBytes);
        verifier5.Init(false, (ICipherParameters) this.GetPubKeyEd448());
        return (Tls13Verifier) new BcTls13Verifier((ISigner) verifier5);
      case 2057:
      case 2058:
      case 2059:
        this.ValidateRsa_Pss_Pss(SignatureScheme.GetSignatureAlgorithm(signatureScheme));
        IDigest digest2 = this.m_crypto.CreateDigest(SignatureScheme.GetCryptoHashAlgorithm(signatureScheme));
        PssSigner verifier6 = new PssSigner((IAsymmetricBlockCipher) new RsaEngine(), digest2, digest2.GetDigestSize());
        verifier6.Init(false, (ICipherParameters) this.GetPubKeyRsa());
        return (Tls13Verifier) new BcTls13Verifier((ISigner) verifier6);
      default:
        throw new TlsFatalAlert((short) 46);
    }
  }

  public virtual byte[] GetEncoded() => this.m_keyInfo.GetEncoded("DER");

  public virtual byte[] GetExtension(DerObjectIdentifier extensionOid) => (byte[]) null;

  public virtual BigInteger SerialNumber => (BigInteger) null;

  public virtual string SigAlgOid => (string) null;

  public virtual Asn1Encodable GetSigAlgParams() => (Asn1Encodable) null;

  public virtual short GetLegacySignatureAlgorithm()
  {
    AsymmetricKeyParameter publicKey = this.GetPublicKey();
    if (publicKey.IsPrivate)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (!this.SupportsKeyUsage(128 /*0x80*/))
      return -1;
    switch (publicKey)
    {
      case RsaKeyParameters _:
        return 1;
      case DsaPublicKeyParameters _:
        return 2;
      case ECPublicKeyParameters _:
        return 3;
      default:
        return -1;
    }
  }

  public virtual DHPublicKeyParameters GetPubKeyDH()
  {
    try
    {
      return (DHPublicKeyParameters) this.GetPublicKey();
    }
    catch (InvalidCastException ex)
    {
      throw new TlsFatalAlert((short) 46, (Exception) ex);
    }
  }

  public virtual DsaPublicKeyParameters GetPubKeyDss()
  {
    try
    {
      return (DsaPublicKeyParameters) this.GetPublicKey();
    }
    catch (InvalidCastException ex)
    {
      throw new TlsFatalAlert((short) 46, (Exception) ex);
    }
  }

  public virtual ECPublicKeyParameters GetPubKeyEC()
  {
    try
    {
      return (ECPublicKeyParameters) this.GetPublicKey();
    }
    catch (InvalidCastException ex)
    {
      throw new TlsFatalAlert((short) 46, (Exception) ex);
    }
  }

  public virtual Ed25519PublicKeyParameters GetPubKeyEd25519()
  {
    try
    {
      return (Ed25519PublicKeyParameters) this.GetPublicKey();
    }
    catch (InvalidCastException ex)
    {
      throw new TlsFatalAlert((short) 46, (Exception) ex);
    }
  }

  public virtual Ed448PublicKeyParameters GetPubKeyEd448()
  {
    try
    {
      return (Ed448PublicKeyParameters) this.GetPublicKey();
    }
    catch (InvalidCastException ex)
    {
      throw new TlsFatalAlert((short) 46, (Exception) ex);
    }
  }

  public virtual RsaKeyParameters GetPubKeyRsa()
  {
    try
    {
      return (RsaKeyParameters) this.GetPublicKey();
    }
    catch (InvalidCastException ex)
    {
      throw new TlsFatalAlert((short) 46, (Exception) ex);
    }
  }

  public virtual bool SupportsSignatureAlgorithm(short signatureAlgorithm)
  {
    return this.SupportsSignatureAlgorithm(signatureAlgorithm, 128 /*0x80*/);
  }

  public virtual bool SupportsSignatureAlgorithmCA(short signatureAlgorithm)
  {
    return this.SupportsSignatureAlgorithm(signatureAlgorithm, 4);
  }

  public virtual TlsCertificate CheckUsageInRole(int tlsCertificateRole)
  {
    if (tlsCertificateRole != 1)
    {
      if (tlsCertificateRole != 2)
        throw new TlsFatalAlert((short) 46);
      this.ValidateKeyUsage(8);
      this.m_pubKeyEC = this.GetPubKeyEC();
      return (TlsCertificate) this;
    }
    this.ValidateKeyUsage(8);
    this.m_pubKeyDH = this.GetPubKeyDH();
    return (TlsCertificate) this;
  }

  protected virtual AsymmetricKeyParameter GetPublicKey()
  {
    try
    {
      return PublicKeyFactory.CreateKey(this.m_keyInfo);
    }
    catch (Exception ex)
    {
      throw new TlsFatalAlert((short) 43, ex);
    }
  }

  protected virtual bool SupportsKeyUsage(int keyUsageBits) => true;

  protected virtual bool SupportsRsa_Pkcs1()
  {
    return RsaUtilities.SupportsPkcs1(this.m_keyInfo.AlgorithmID);
  }

  protected virtual bool SupportsRsa_Pss_Pss(short signatureAlgorithm)
  {
    AlgorithmIdentifier algorithmId = this.m_keyInfo.AlgorithmID;
    return RsaUtilities.SupportsPss_Pss(signatureAlgorithm, algorithmId);
  }

  protected virtual bool SupportsRsa_Pss_Rsae()
  {
    return RsaUtilities.SupportsPss_Rsae(this.m_keyInfo.AlgorithmID);
  }

  protected virtual bool SupportsSignatureAlgorithm(short signatureAlgorithm, int keyUsage)
  {
    if (!this.SupportsKeyUsage(keyUsage))
      return false;
    AsymmetricKeyParameter publicKey = this.GetPublicKey();
    switch (signatureAlgorithm)
    {
      case 1:
        return this.SupportsRsa_Pkcs1() && publicKey is RsaKeyParameters;
      case 2:
        return publicKey is DsaPublicKeyParameters;
      case 3:
      case 26:
      case 27:
      case 28:
        return publicKey is ECPublicKeyParameters;
      case 4:
      case 5:
      case 6:
        return this.SupportsRsa_Pss_Rsae() && publicKey is RsaKeyParameters;
      case 7:
        return publicKey is Ed25519PublicKeyParameters;
      case 8:
        return publicKey is Ed448PublicKeyParameters;
      case 9:
      case 10:
      case 11:
        return this.SupportsRsa_Pss_Pss(signatureAlgorithm) && publicKey is RsaKeyParameters;
      default:
        return false;
    }
  }

  public virtual void ValidateKeyUsage(int keyUsageBits)
  {
    if (!this.SupportsKeyUsage(keyUsageBits))
      throw new TlsFatalAlert((short) 46);
  }

  protected virtual void ValidateRsa_Pkcs1()
  {
    if (!this.SupportsRsa_Pkcs1())
      throw new TlsFatalAlert((short) 46);
  }

  protected virtual void ValidateRsa_Pss_Pss(short signatureAlgorithm)
  {
    if (!this.SupportsRsa_Pss_Pss(signatureAlgorithm))
      throw new TlsFatalAlert((short) 46);
  }

  protected virtual void ValidateRsa_Pss_Rsae()
  {
    if (!this.SupportsRsa_Pss_Rsae())
      throw new TlsFatalAlert((short) 46);
  }
}
