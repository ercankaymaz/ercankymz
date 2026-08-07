// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.AbstractTlsCrypto
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public abstract class AbstractTlsCrypto : TlsCrypto
{
  public abstract bool HasAnyStreamVerifiers(
    IList<SignatureAndHashAlgorithm> signatureAndHashAlgorithms);

  public abstract bool HasAnyStreamVerifiersLegacy(short[] clientCertificateTypes);

  public abstract bool HasCryptoHashAlgorithm(int cryptoHashAlgorithm);

  public abstract bool HasCryptoSignatureAlgorithm(int cryptoSignatureAlgorithm);

  public abstract bool HasDHAgreement();

  public abstract bool HasECDHAgreement();

  public abstract bool HasEncryptionAlgorithm(int encryptionAlgorithm);

  public abstract bool HasHkdfAlgorithm(int cryptoHashAlgorithm);

  public abstract bool HasMacAlgorithm(int macAlgorithm);

  public abstract bool HasNamedGroup(int namedGroup);

  public abstract bool HasRsaEncryption();

  public abstract bool HasSignatureAlgorithm(short signatureAlgorithm);

  public abstract bool HasSignatureAndHashAlgorithm(SignatureAndHashAlgorithm sigAndHashAlgorithm);

  public abstract bool HasSignatureScheme(int signatureScheme);

  public abstract bool HasSrpAuthentication();

  public abstract TlsSecret CreateSecret(byte[] data);

  public abstract TlsSecret GenerateRsaPreMasterSecret(ProtocolVersion clientVersion);

  public abstract SecureRandom SecureRandom { get; }

  public virtual TlsCertificate CreateCertificate(byte[] encoding)
  {
    return this.CreateCertificate((short) 0, encoding);
  }

  public abstract TlsCertificate CreateCertificate(short type, byte[] encoding);

  public abstract TlsCipher CreateCipher(
    TlsCryptoParameters cryptoParams,
    int encryptionAlgorithm,
    int macAlgorithm);

  public abstract TlsDHDomain CreateDHDomain(TlsDHConfig dhConfig);

  public abstract TlsECDomain CreateECDomain(TlsECConfig ecConfig);

  public virtual TlsSecret AdoptSecret(TlsSecret secret)
  {
    return secret is AbstractTlsSecret abstractTlsSecret ? this.CreateSecret(abstractTlsSecret.CopyData()) : throw new ArgumentException("unrecognized TlsSecret - cannot copy data: " + secret.GetType().FullName);
  }

  public abstract TlsHash CreateHash(int cryptoHashAlgorithm);

  public abstract TlsHmac CreateHmac(int macAlgorithm);

  public abstract TlsHmac CreateHmacForHash(int cryptoHashAlgorithm);

  public abstract TlsNonceGenerator CreateNonceGenerator(byte[] additionalSeedMaterial);

  public abstract TlsSrp6Client CreateSrp6Client(TlsSrpConfig srpConfig);

  public abstract TlsSrp6Server CreateSrp6Server(TlsSrpConfig srpConfig, BigInteger srpVerifier);

  public abstract TlsSrp6VerifierGenerator CreateSrp6VerifierGenerator(TlsSrpConfig srpConfig);

  public abstract TlsSecret HkdfInit(int cryptoHashAlgorithm);
}
