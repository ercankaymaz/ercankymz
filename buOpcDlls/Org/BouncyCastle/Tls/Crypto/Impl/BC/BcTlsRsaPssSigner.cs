// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsRsaPssSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsRsaPssSigner : BcTlsSigner
{
  private readonly int m_signatureScheme;

  public BcTlsRsaPssSigner(BcTlsCrypto crypto, RsaKeyParameters privateKey, int signatureScheme)
    : base(crypto, (AsymmetricKeyParameter) privateKey)
  {
    this.m_signatureScheme = SignatureScheme.IsRsaPss(signatureScheme) ? signatureScheme : throw new ArgumentException(nameof (signatureScheme));
  }

  public override byte[] GenerateRawSignature(SignatureAndHashAlgorithm algorithm, byte[] hash)
  {
    IDigest digest = algorithm != null && SignatureScheme.From(algorithm) == this.m_signatureScheme ? this.m_crypto.CreateDigest(SignatureScheme.GetCryptoHashAlgorithm(this.m_signatureScheme)) : throw new InvalidOperationException("Invalid algorithm: " + algorithm?.ToString());
    PssSigner rawSigner = PssSigner.CreateRawSigner((IAsymmetricBlockCipher) new RsaBlindedEngine(), digest, digest, digest.GetDigestSize(), (byte) 188);
    rawSigner.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) this.m_privateKey, this.m_crypto.SecureRandom));
    rawSigner.BlockUpdate(hash, 0, hash.Length);
    try
    {
      return rawSigner.GenerateSignature();
    }
    catch (CryptoException ex)
    {
      throw new TlsFatalAlert((short) 80 /*0x50*/, (Exception) ex);
    }
  }
}
