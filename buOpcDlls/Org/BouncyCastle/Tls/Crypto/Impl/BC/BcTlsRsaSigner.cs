// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsRsaSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsRsaSigner : BcTlsSigner
{
  private readonly RsaKeyParameters m_publicKey;

  public BcTlsRsaSigner(
    BcTlsCrypto crypto,
    RsaKeyParameters privateKey,
    RsaKeyParameters publicKey)
    : base(crypto, (AsymmetricKeyParameter) privateKey)
  {
    this.m_publicKey = publicKey;
  }

  public override byte[] GenerateRawSignature(SignatureAndHashAlgorithm algorithm, byte[] hash)
  {
    IDigest digest = (IDigest) new NullDigest();
    ISigner signer;
    if (algorithm != null)
    {
      if (algorithm.Signature != (short) 1)
        throw new InvalidOperationException("Invalid algorithm: " + algorithm?.ToString());
      signer = (ISigner) new RsaDigestSigner(digest, TlsUtilities.GetOidForHashAlgorithm(algorithm.Hash));
    }
    else
      signer = (ISigner) new GenericSigner((IAsymmetricBlockCipher) new Pkcs1Encoding((IAsymmetricBlockCipher) new RsaBlindedEngine()), digest);
    signer.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) this.m_privateKey, this.m_crypto.SecureRandom));
    signer.BlockUpdate(hash, 0, hash.Length);
    try
    {
      byte[] signature = signer.GenerateSignature();
      signer.Init(false, (ICipherParameters) this.m_publicKey);
      signer.BlockUpdate(hash, 0, hash.Length);
      if (signer.VerifySignature(signature))
        return signature;
    }
    catch (CryptoException ex)
    {
      throw new TlsFatalAlert((short) 80 /*0x50*/, (Exception) ex);
    }
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }
}
