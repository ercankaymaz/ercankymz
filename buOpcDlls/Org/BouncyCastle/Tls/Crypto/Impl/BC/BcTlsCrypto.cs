// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsCrypto
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsCrypto : AbstractTlsCrypto
{
  private readonly SecureRandom m_entropySource;

  public BcTlsCrypto()
    : this(CryptoServicesRegistrar.GetSecureRandom())
  {
  }

  public BcTlsCrypto(SecureRandom entropySource)
  {
    this.m_entropySource = entropySource != null ? entropySource : throw new ArgumentNullException(nameof (entropySource));
  }

  internal virtual BcTlsSecret AdoptLocalSecret(byte[] data) => new BcTlsSecret(this, data);

  public override SecureRandom SecureRandom => this.m_entropySource;

  public override TlsCertificate CreateCertificate(short type, byte[] encoding)
  {
    if (type == (short) 0)
      return (TlsCertificate) new BcTlsCertificate(this, encoding);
    if (type != (short) 2)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    return (TlsCertificate) new BcTlsRawKeyCertificate(this, encoding);
  }

  public override TlsCipher CreateCipher(
    TlsCryptoParameters cryptoParams,
    int encryptionAlgorithm,
    int macAlgorithm)
  {
    switch (encryptionAlgorithm)
    {
      case 0:
        return (TlsCipher) this.CreateNullCipher(cryptoParams, macAlgorithm);
      case 7:
        return this.CreateCipher_Cbc(cryptoParams, encryptionAlgorithm, 24, macAlgorithm);
      case 8:
      case 12:
      case 14:
      case 22:
      case 28:
        return this.CreateCipher_Cbc(cryptoParams, encryptionAlgorithm, 16 /*0x10*/, macAlgorithm);
      case 9:
      case 13:
      case 23:
        return this.CreateCipher_Cbc(cryptoParams, encryptionAlgorithm, 32 /*0x20*/, macAlgorithm);
      case 10:
        return (TlsCipher) this.CreateCipher_Aes_Gcm(cryptoParams, 16 /*0x10*/, 16 /*0x10*/);
      case 11:
        return (TlsCipher) this.CreateCipher_Aes_Gcm(cryptoParams, 32 /*0x20*/, 16 /*0x10*/);
      case 15:
        return (TlsCipher) this.CreateCipher_Aes_Ccm(cryptoParams, 16 /*0x10*/, 16 /*0x10*/);
      case 16 /*0x10*/:
        return (TlsCipher) this.CreateCipher_Aes_Ccm(cryptoParams, 16 /*0x10*/, 8);
      case 17:
        return (TlsCipher) this.CreateCipher_Aes_Ccm(cryptoParams, 32 /*0x20*/, 16 /*0x10*/);
      case 18:
        return (TlsCipher) this.CreateCipher_Aes_Ccm(cryptoParams, 32 /*0x20*/, 8);
      case 19:
        return (TlsCipher) this.CreateCipher_Camellia_Gcm(cryptoParams, 16 /*0x10*/, 16 /*0x10*/);
      case 20:
        return (TlsCipher) this.CreateCipher_Camellia_Gcm(cryptoParams, 32 /*0x20*/, 16 /*0x10*/);
      case 21:
        return this.CreateChaCha20Poly1305(cryptoParams);
      case 24:
        return (TlsCipher) this.CreateCipher_Aria_Gcm(cryptoParams, 16 /*0x10*/, 16 /*0x10*/);
      case 25:
        return (TlsCipher) this.CreateCipher_Aria_Gcm(cryptoParams, 32 /*0x20*/, 16 /*0x10*/);
      case 26:
        return (TlsCipher) this.CreateCipher_SM4_Ccm(cryptoParams);
      case 27:
        return (TlsCipher) this.CreateCipher_SM4_Gcm(cryptoParams);
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  public override TlsDHDomain CreateDHDomain(TlsDHConfig dhConfig)
  {
    return (TlsDHDomain) new BcTlsDHDomain(this, dhConfig);
  }

  public override TlsECDomain CreateECDomain(TlsECConfig ecConfig)
  {
    switch (ecConfig.NamedGroup)
    {
      case 29:
        return (TlsECDomain) new BcX25519Domain(this);
      case 30:
        return (TlsECDomain) new BcX448Domain(this);
      default:
        return (TlsECDomain) new BcTlsECDomain(this, ecConfig);
    }
  }

  public override TlsNonceGenerator CreateNonceGenerator(byte[] additionalSeedMaterial)
  {
    IDigest digest = this.CreateDigest(4);
    byte[] numArray = new byte[2 * TlsCryptoUtilities.GetHashOutputSize(4)];
    this.SecureRandom.NextBytes(numArray);
    DigestRandomGenerator digestRandomGenerator = new DigestRandomGenerator(digest);
    digestRandomGenerator.AddSeedMaterial(additionalSeedMaterial);
    digestRandomGenerator.AddSeedMaterial(numArray);
    return (TlsNonceGenerator) new BcTlsNonceGenerator((IRandomGenerator) digestRandomGenerator);
  }

  public override bool HasAnyStreamVerifiers(
    IList<SignatureAndHashAlgorithm> signatureAndHashAlgorithms)
  {
    foreach (SignatureAndHashAlgorithm andHashAlgorithm in (IEnumerable<SignatureAndHashAlgorithm>) signatureAndHashAlgorithms)
    {
      switch (SignatureScheme.From(andHashAlgorithm))
      {
        case 2055:
        case 2056:
          return true;
        default:
          continue;
      }
    }
    return false;
  }

  public override bool HasAnyStreamVerifiersLegacy(short[] clientCertificateTypes) => false;

  public override bool HasCryptoHashAlgorithm(int cryptoHashAlgorithm)
  {
    switch (cryptoHashAlgorithm)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
        return true;
      default:
        return false;
    }
  }

  public override bool HasCryptoSignatureAlgorithm(int cryptoSignatureAlgorithm)
  {
    switch (cryptoSignatureAlgorithm)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
        return true;
      default:
        return false;
    }
  }

  public override bool HasDHAgreement() => true;

  public override bool HasECDHAgreement() => true;

  public override bool HasEncryptionAlgorithm(int encryptionAlgorithm)
  {
    switch (encryptionAlgorithm)
    {
      case 0:
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
      case 12:
      case 13:
      case 14:
      case 15:
      case 16 /*0x10*/:
      case 17:
      case 18:
      case 19:
      case 20:
      case 21:
      case 22:
      case 23:
      case 24:
      case 25:
      case 26:
      case 27:
      case 28:
        return true;
      default:
        return false;
    }
  }

  public override bool HasHkdfAlgorithm(int cryptoHashAlgorithm)
  {
    switch (cryptoHashAlgorithm)
    {
      case 4:
      case 5:
      case 6:
      case 7:
        return true;
      default:
        return false;
    }
  }

  public override bool HasMacAlgorithm(int macAlgorithm)
  {
    switch (macAlgorithm)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
        return true;
      default:
        return false;
    }
  }

  public override bool HasNamedGroup(int namedGroup)
  {
    return NamedGroup.RefersToASpecificGroup(namedGroup);
  }

  public override bool HasRsaEncryption() => true;

  public override bool HasSignatureAlgorithm(short signatureAlgorithm)
  {
    switch (signatureAlgorithm)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
      case 26:
      case 27:
      case 28:
        return true;
      default:
        return false;
    }
  }

  public override bool HasSignatureAndHashAlgorithm(SignatureAndHashAlgorithm sigAndHashAlgorithm)
  {
    short signature = sigAndHashAlgorithm.Signature;
    if (sigAndHashAlgorithm.Hash != (short) 1)
      return this.HasSignatureAlgorithm(signature);
    return (short) 1 == signature && this.HasSignatureAlgorithm(signature);
  }

  public override bool HasSignatureScheme(int signatureScheme)
  {
    if (signatureScheme == 1800)
      return false;
    short signatureAlgorithm = SignatureScheme.GetSignatureAlgorithm(signatureScheme);
    if (SignatureScheme.GetCryptoHashAlgorithm(signatureScheme) != 1)
      return this.HasSignatureAlgorithm(signatureAlgorithm);
    return (short) 1 == signatureAlgorithm && this.HasSignatureAlgorithm(signatureAlgorithm);
  }

  public override bool HasSrpAuthentication() => true;

  public override TlsSecret CreateSecret(byte[] data)
  {
    return (TlsSecret) this.AdoptLocalSecret(Arrays.Clone(data));
  }

  public override TlsSecret GenerateRsaPreMasterSecret(ProtocolVersion version)
  {
    byte[] numArray = new byte[48 /*0x30*/];
    this.SecureRandom.NextBytes(numArray);
    TlsUtilities.WriteVersion(version, numArray, 0);
    return (TlsSecret) this.AdoptLocalSecret(numArray);
  }

  public virtual IDigest CloneDigest(int cryptoHashAlgorithm, IDigest digest)
  {
    switch (cryptoHashAlgorithm)
    {
      case 1:
        return (IDigest) new MD5Digest((MD5Digest) digest);
      case 2:
        return (IDigest) new Sha1Digest((Sha1Digest) digest);
      case 3:
        return (IDigest) new Sha224Digest((Sha224Digest) digest);
      case 4:
        return (IDigest) new Sha256Digest((Sha256Digest) digest);
      case 5:
        return (IDigest) new Sha384Digest((Sha384Digest) digest);
      case 6:
        return (IDigest) new Sha512Digest((Sha512Digest) digest);
      case 7:
        return (IDigest) new SM3Digest((SM3Digest) digest);
      default:
        throw new ArgumentException("invalid CryptoHashAlgorithm: " + cryptoHashAlgorithm.ToString());
    }
  }

  public virtual IDigest CreateDigest(int cryptoHashAlgorithm)
  {
    switch (cryptoHashAlgorithm)
    {
      case 1:
        return (IDigest) new MD5Digest();
      case 2:
        return (IDigest) new Sha1Digest();
      case 3:
        return (IDigest) new Sha224Digest();
      case 4:
        return (IDigest) new Sha256Digest();
      case 5:
        return (IDigest) new Sha384Digest();
      case 6:
        return (IDigest) new Sha512Digest();
      case 7:
        return (IDigest) new SM3Digest();
      default:
        throw new ArgumentException("invalid CryptoHashAlgorithm: " + cryptoHashAlgorithm.ToString());
    }
  }

  public override TlsHash CreateHash(int cryptoHashAlgorithm)
  {
    return (TlsHash) new BcTlsHash(this, cryptoHashAlgorithm);
  }

  protected virtual IBlockCipher CreateBlockCipher(int encryptionAlgorithm)
  {
    switch (encryptionAlgorithm)
    {
      case 7:
        return this.CreateDesEdeEngine();
      case 8:
      case 9:
        return this.CreateAesEngine();
      case 12:
      case 13:
        return this.CreateCamelliaEngine();
      case 14:
        return this.CreateSeedEngine();
      case 22:
      case 23:
        return this.CreateAriaEngine();
      case 28:
        return this.CreateSM4Engine();
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  protected virtual IBlockCipher CreateCbcBlockCipher(IBlockCipher blockCipher)
  {
    return (IBlockCipher) new CbcBlockCipher(blockCipher);
  }

  protected virtual IBlockCipher CreateCbcBlockCipher(int encryptionAlgorithm)
  {
    return this.CreateCbcBlockCipher(this.CreateBlockCipher(encryptionAlgorithm));
  }

  protected virtual TlsCipher CreateChaCha20Poly1305(TlsCryptoParameters cryptoParams)
  {
    BcChaCha20Poly1305 encryptCipher = new BcChaCha20Poly1305(true);
    BcChaCha20Poly1305 decryptCipher = new BcChaCha20Poly1305(false);
    return (TlsCipher) new TlsAeadCipher(cryptoParams, (TlsAeadCipherImpl) encryptCipher, (TlsAeadCipherImpl) decryptCipher, 32 /*0x20*/, 16 /*0x10*/, 2);
  }

  protected virtual TlsAeadCipher CreateCipher_Aes_Ccm(
    TlsCryptoParameters cryptoParams,
    int cipherKeySize,
    int macSize)
  {
    BcTlsCcmImpl encryptCipher = new BcTlsCcmImpl(this.CreateAeadCipher_Aes_Ccm(), true);
    BcTlsCcmImpl decryptCipher = new BcTlsCcmImpl(this.CreateAeadCipher_Aes_Ccm(), false);
    return new TlsAeadCipher(cryptoParams, (TlsAeadCipherImpl) encryptCipher, (TlsAeadCipherImpl) decryptCipher, cipherKeySize, macSize, 1);
  }

  protected virtual TlsAeadCipher CreateCipher_Aes_Gcm(
    TlsCryptoParameters cryptoParams,
    int cipherKeySize,
    int macSize)
  {
    BcTlsAeadCipherImpl encryptCipher = new BcTlsAeadCipherImpl(this.CreateAeadCipher_Aes_Gcm(), true);
    BcTlsAeadCipherImpl decryptCipher = new BcTlsAeadCipherImpl(this.CreateAeadCipher_Aes_Gcm(), false);
    return new TlsAeadCipher(cryptoParams, (TlsAeadCipherImpl) encryptCipher, (TlsAeadCipherImpl) decryptCipher, cipherKeySize, macSize, 3);
  }

  protected virtual TlsAeadCipher CreateCipher_Aria_Gcm(
    TlsCryptoParameters cryptoParams,
    int cipherKeySize,
    int macSize)
  {
    BcTlsAeadCipherImpl encryptCipher = new BcTlsAeadCipherImpl(this.CreateAeadCipher_Aria_Gcm(), true);
    BcTlsAeadCipherImpl decryptCipher = new BcTlsAeadCipherImpl(this.CreateAeadCipher_Aria_Gcm(), false);
    return new TlsAeadCipher(cryptoParams, (TlsAeadCipherImpl) encryptCipher, (TlsAeadCipherImpl) decryptCipher, cipherKeySize, macSize, 3);
  }

  protected virtual TlsAeadCipher CreateCipher_Camellia_Gcm(
    TlsCryptoParameters cryptoParams,
    int cipherKeySize,
    int macSize)
  {
    BcTlsAeadCipherImpl encryptCipher = new BcTlsAeadCipherImpl(this.CreateAeadCipher_Camellia_Gcm(), true);
    BcTlsAeadCipherImpl decryptCipher = new BcTlsAeadCipherImpl(this.CreateAeadCipher_Camellia_Gcm(), false);
    return new TlsAeadCipher(cryptoParams, (TlsAeadCipherImpl) encryptCipher, (TlsAeadCipherImpl) decryptCipher, cipherKeySize, macSize, 3);
  }

  protected virtual TlsCipher CreateCipher_Cbc(
    TlsCryptoParameters cryptoParams,
    int encryptionAlgorithm,
    int cipherKeySize,
    int macAlgorithm)
  {
    BcTlsBlockCipherImpl encryptCipher = new BcTlsBlockCipherImpl(this.CreateCbcBlockCipher(encryptionAlgorithm), true);
    BcTlsBlockCipherImpl decryptCipher = new BcTlsBlockCipherImpl(this.CreateCbcBlockCipher(encryptionAlgorithm), false);
    TlsHmac mac1 = this.CreateMac(cryptoParams, macAlgorithm);
    TlsHmac mac2 = this.CreateMac(cryptoParams, macAlgorithm);
    return (TlsCipher) new TlsBlockCipher(cryptoParams, (TlsBlockCipherImpl) encryptCipher, (TlsBlockCipherImpl) decryptCipher, mac1, mac2, cipherKeySize);
  }

  protected virtual TlsAeadCipher CreateCipher_SM4_Ccm(TlsCryptoParameters cryptoParams)
  {
    BcTlsCcmImpl encryptCipher = new BcTlsCcmImpl(this.CreateAeadCipher_SM4_Ccm(), true);
    BcTlsCcmImpl decryptCipher = new BcTlsCcmImpl(this.CreateAeadCipher_SM4_Ccm(), false);
    return new TlsAeadCipher(cryptoParams, (TlsAeadCipherImpl) encryptCipher, (TlsAeadCipherImpl) decryptCipher, 16 /*0x10*/, 16 /*0x10*/, 1);
  }

  protected virtual TlsAeadCipher CreateCipher_SM4_Gcm(TlsCryptoParameters cryptoParams)
  {
    BcTlsAeadCipherImpl encryptCipher = new BcTlsAeadCipherImpl(this.CreateAeadCipher_SM4_Gcm(), true);
    BcTlsAeadCipherImpl decryptCipher = new BcTlsAeadCipherImpl(this.CreateAeadCipher_SM4_Gcm(), false);
    return new TlsAeadCipher(cryptoParams, (TlsAeadCipherImpl) encryptCipher, (TlsAeadCipherImpl) decryptCipher, 16 /*0x10*/, 16 /*0x10*/, 3);
  }

  protected virtual TlsNullCipher CreateNullCipher(
    TlsCryptoParameters cryptoParams,
    int macAlgorithm)
  {
    return new TlsNullCipher(cryptoParams, this.CreateMac(cryptoParams, macAlgorithm), this.CreateMac(cryptoParams, macAlgorithm));
  }

  protected virtual IBlockCipher CreateAesEngine() => AesUtilities.CreateEngine();

  protected virtual IBlockCipher CreateAriaEngine() => (IBlockCipher) new AriaEngine();

  protected virtual IBlockCipher CreateCamelliaEngine() => (IBlockCipher) new CamelliaEngine();

  protected virtual IBlockCipher CreateDesEdeEngine() => (IBlockCipher) new DesEdeEngine();

  protected virtual IBlockCipher CreateSeedEngine() => (IBlockCipher) new SeedEngine();

  protected virtual IBlockCipher CreateSM4Engine() => (IBlockCipher) new SM4Engine();

  protected virtual CcmBlockCipher CreateCcmMode(IBlockCipher engine) => new CcmBlockCipher(engine);

  protected virtual IAeadCipher CreateGcmMode(IBlockCipher engine)
  {
    return (IAeadCipher) new GcmBlockCipher(engine);
  }

  protected virtual CcmBlockCipher CreateAeadCipher_Aes_Ccm()
  {
    return this.CreateCcmMode(this.CreateAesEngine());
  }

  protected virtual IAeadCipher CreateAeadCipher_Aes_Gcm()
  {
    return this.CreateGcmMode(this.CreateAesEngine());
  }

  protected virtual IAeadCipher CreateAeadCipher_Aria_Gcm()
  {
    return this.CreateGcmMode(this.CreateAriaEngine());
  }

  protected virtual IAeadCipher CreateAeadCipher_Camellia_Gcm()
  {
    return this.CreateGcmMode(this.CreateCamelliaEngine());
  }

  protected virtual CcmBlockCipher CreateAeadCipher_SM4_Ccm()
  {
    return this.CreateCcmMode(this.CreateSM4Engine());
  }

  protected virtual IAeadCipher CreateAeadCipher_SM4_Gcm()
  {
    return this.CreateGcmMode(this.CreateSM4Engine());
  }

  public override TlsHmac CreateHmac(int macAlgorithm)
  {
    switch (macAlgorithm)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
        return this.CreateHmacForHash(TlsCryptoUtilities.GetHashForHmac(macAlgorithm));
      default:
        throw new ArgumentException("invalid MacAlgorithm: " + macAlgorithm.ToString());
    }
  }

  public override TlsHmac CreateHmacForHash(int cryptoHashAlgorithm)
  {
    return (TlsHmac) new BcTlsHmac(new HMac(this.CreateDigest(cryptoHashAlgorithm)));
  }

  protected virtual TlsHmac CreateHmac_Ssl(int macAlgorithm)
  {
    switch (macAlgorithm)
    {
      case 1:
        return (TlsHmac) new BcSsl3Hmac(this.CreateDigest(1));
      case 2:
        return (TlsHmac) new BcSsl3Hmac(this.CreateDigest(2));
      case 3:
        return (TlsHmac) new BcSsl3Hmac(this.CreateDigest(4));
      case 4:
        return (TlsHmac) new BcSsl3Hmac(this.CreateDigest(5));
      case 5:
        return (TlsHmac) new BcSsl3Hmac(this.CreateDigest(6));
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  protected virtual TlsHmac CreateMac(TlsCryptoParameters cryptoParams, int macAlgorithm)
  {
    return TlsImplUtilities.IsSsl(cryptoParams) ? this.CreateHmac_Ssl(macAlgorithm) : this.CreateHmac(macAlgorithm);
  }

  public override TlsSrp6Client CreateSrp6Client(TlsSrpConfig srpConfig)
  {
    BigInteger[] explicitNg = srpConfig.GetExplicitNG();
    Srp6GroupParameters group = new Srp6GroupParameters(explicitNg[0], explicitNg[1]);
    Srp6Client srpClient = new Srp6Client();
    srpClient.Init(group, this.CreateDigest(2), this.SecureRandom);
    return (TlsSrp6Client) new BcTlsSrp6Client(srpClient);
  }

  public override TlsSrp6Server CreateSrp6Server(TlsSrpConfig srpConfig, BigInteger srpVerifier)
  {
    BigInteger[] explicitNg = srpConfig.GetExplicitNG();
    Srp6GroupParameters group = new Srp6GroupParameters(explicitNg[0], explicitNg[1]);
    Srp6Server srp6Server = new Srp6Server();
    srp6Server.Init(group, srpVerifier, this.CreateDigest(2), this.SecureRandom);
    return (TlsSrp6Server) new BcTlsSrp6Server(srp6Server);
  }

  public override TlsSrp6VerifierGenerator CreateSrp6VerifierGenerator(TlsSrpConfig srpConfig)
  {
    BigInteger[] explicitNg = srpConfig.GetExplicitNG();
    Srp6VerifierGenerator srp6VerifierGenerator = new Srp6VerifierGenerator();
    srp6VerifierGenerator.Init(explicitNg[0], explicitNg[1], this.CreateDigest(2));
    return (TlsSrp6VerifierGenerator) new BcTlsSrp6VerifierGenerator(srp6VerifierGenerator);
  }

  public override TlsSecret HkdfInit(int cryptoHashAlgorithm)
  {
    return (TlsSecret) this.AdoptLocalSecret(new byte[TlsCryptoUtilities.GetHashOutputSize(cryptoHashAlgorithm)]);
  }
}
