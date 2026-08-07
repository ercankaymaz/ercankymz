// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsCrypto
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public interface TlsCrypto
{
  bool HasAnyStreamVerifiers(
    IList<SignatureAndHashAlgorithm> signatureAndHashAlgorithms);

  bool HasAnyStreamVerifiersLegacy(short[] clientCertificateTypes);

  bool HasCryptoHashAlgorithm(int cryptoHashAlgorithm);

  bool HasCryptoSignatureAlgorithm(int cryptoSignatureAlgorithm);

  bool HasDHAgreement();

  bool HasECDHAgreement();

  bool HasEncryptionAlgorithm(int encryptionAlgorithm);

  bool HasHkdfAlgorithm(int cryptoHashAlgorithm);

  bool HasMacAlgorithm(int macAlgorithm);

  bool HasNamedGroup(int namedGroup);

  bool HasRsaEncryption();

  bool HasSignatureAlgorithm(short signatureAlgorithm);

  bool HasSignatureAndHashAlgorithm(SignatureAndHashAlgorithm sigAndHashAlgorithm);

  bool HasSignatureScheme(int signatureScheme);

  bool HasSrpAuthentication();

  TlsSecret CreateSecret(byte[] data);

  TlsSecret GenerateRsaPreMasterSecret(ProtocolVersion clientVersion);

  SecureRandom SecureRandom { get; }

  TlsCertificate CreateCertificate(byte[] encoding);

  TlsCertificate CreateCertificate(short type, byte[] encoding);

  TlsCipher CreateCipher(
    TlsCryptoParameters cryptoParams,
    int encryptionAlgorithm,
    int macAlgorithm);

  TlsDHDomain CreateDHDomain(TlsDHConfig dhConfig);

  TlsECDomain CreateECDomain(TlsECConfig ecConfig);

  TlsSecret AdoptSecret(TlsSecret secret);

  TlsHash CreateHash(int cryptoHashAlgorithm);

  TlsHmac CreateHmac(int macAlgorithm);

  TlsHmac CreateHmacForHash(int cryptoHashAlgorithm);

  TlsNonceGenerator CreateNonceGenerator(byte[] additionalSeedMaterial);

  TlsSrp6Client CreateSrp6Client(TlsSrpConfig srpConfig);

  TlsSrp6Server CreateSrp6Server(TlsSrpConfig srpConfig, BigInteger srpVerifier);

  TlsSrp6VerifierGenerator CreateSrp6VerifierGenerator(TlsSrpConfig srpConfig);

  TlsSecret HkdfInit(int cryptoHashAlgorithm);
}
