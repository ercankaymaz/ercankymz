// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcDefaultTlsCredentialedSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcDefaultTlsCredentialedSigner(
  TlsCryptoParameters cryptoParams,
  BcTlsCrypto crypto,
  AsymmetricKeyParameter privateKey,
  Certificate certificate,
  SignatureAndHashAlgorithm signatureAndHashAlgorithm) : DefaultTlsCredentialedSigner(cryptoParams, BcDefaultTlsCredentialedSigner.MakeSigner(crypto, privateKey, certificate, signatureAndHashAlgorithm), certificate, signatureAndHashAlgorithm)
{
  private static BcTlsCertificate GetEndEntity(BcTlsCrypto crypto, Certificate certificate)
  {
    return certificate != null && !certificate.IsEmpty ? BcTlsCertificate.Convert(crypto, certificate.GetCertificateAt(0)) : throw new ArgumentException("No certificate");
  }

  private static TlsSigner MakeSigner(
    BcTlsCrypto crypto,
    AsymmetricKeyParameter privateKey,
    Certificate certificate,
    SignatureAndHashAlgorithm signatureAndHashAlgorithm)
  {
    switch (privateKey)
    {
      case RsaKeyParameters _:
        RsaKeyParameters privateKey1 = (RsaKeyParameters) privateKey;
        if (signatureAndHashAlgorithm != null)
        {
          int signatureScheme = SignatureScheme.From(signatureAndHashAlgorithm);
          if (SignatureScheme.IsRsaPss(signatureScheme))
            return (TlsSigner) new BcTlsRsaPssSigner(crypto, privateKey1, signatureScheme);
        }
        RsaKeyParameters pubKeyRsa = BcDefaultTlsCredentialedSigner.GetEndEntity(crypto, certificate).GetPubKeyRsa();
        return (TlsSigner) new BcTlsRsaSigner(crypto, privateKey1, pubKeyRsa);
      case DsaPrivateKeyParameters _:
        return (TlsSigner) new BcTlsDsaSigner(crypto, (DsaPrivateKeyParameters) privateKey);
      case ECPrivateKeyParameters _:
        ECPrivateKeyParameters privateKey2 = (ECPrivateKeyParameters) privateKey;
        if (signatureAndHashAlgorithm != null)
        {
          int signatureScheme = SignatureScheme.From(signatureAndHashAlgorithm);
          if (SignatureScheme.IsECDsa(signatureScheme))
            return (TlsSigner) new BcTlsECDsa13Signer(crypto, privateKey2, signatureScheme);
        }
        return (TlsSigner) new BcTlsECDsaSigner(crypto, privateKey2);
      case Ed25519PrivateKeyParameters _:
        return (TlsSigner) new BcTlsEd25519Signer(crypto, (Ed25519PrivateKeyParameters) privateKey);
      case Ed448PrivateKeyParameters _:
        return (TlsSigner) new BcTlsEd448Signer(crypto, (Ed448PrivateKeyParameters) privateKey);
      default:
        throw new ArgumentException("'privateKey' type not supported: " + privateKey.GetType().FullName);
    }
  }
}
