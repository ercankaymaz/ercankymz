// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsECDsa13Signer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsECDsa13Signer : BcTlsSigner
{
  private readonly int m_signatureScheme;

  public BcTlsECDsa13Signer(
    BcTlsCrypto crypto,
    ECPrivateKeyParameters privateKey,
    int signatureScheme)
    : base(crypto, (AsymmetricKeyParameter) privateKey)
  {
    this.m_signatureScheme = SignatureScheme.IsECDsa(signatureScheme) ? signatureScheme : throw new ArgumentException(nameof (signatureScheme));
  }

  public override byte[] GenerateRawSignature(SignatureAndHashAlgorithm algorithm, byte[] hash)
  {
    ISigner signer = algorithm != null && SignatureScheme.From(algorithm) == this.m_signatureScheme ? (ISigner) new DsaDigestSigner((IDsa) new ECDsaSigner((IDsaKCalculator) new HMacDsaKCalculator(this.m_crypto.CreateDigest(SignatureScheme.GetCryptoHashAlgorithm(this.m_signatureScheme)))), (IDigest) new NullDigest()) : throw new InvalidOperationException("Invalid algorithm: " + algorithm?.ToString());
    signer.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) this.m_privateKey, this.m_crypto.SecureRandom));
    signer.BlockUpdate(hash, 0, hash.Length);
    try
    {
      return signer.GenerateSignature();
    }
    catch (CryptoException ex)
    {
      throw new TlsFatalAlert((short) 80 /*0x50*/, (Exception) ex);
    }
  }
}
