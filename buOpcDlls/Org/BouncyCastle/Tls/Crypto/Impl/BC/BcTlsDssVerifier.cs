// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsDssVerifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Signers;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public abstract class BcTlsDssVerifier(BcTlsCrypto crypto, AsymmetricKeyParameter publicKey) : 
  BcTlsVerifier(crypto, publicKey)
{
  protected abstract IDsa CreateDsaImpl();

  protected abstract short SignatureAlgorithm { get; }

  public override bool VerifyRawSignature(DigitallySigned digitallySigned, byte[] hash)
  {
    SignatureAndHashAlgorithm algorithm = digitallySigned.Algorithm;
    if (algorithm != null && (int) algorithm.Signature != (int) this.SignatureAlgorithm)
      throw new InvalidOperationException("Invalid algorithm: " + algorithm?.ToString());
    ISigner signer = (ISigner) new DsaDigestSigner(this.CreateDsaImpl(), (IDigest) new NullDigest());
    signer.Init(false, (ICipherParameters) this.m_publicKey);
    if (algorithm == null)
      signer.BlockUpdate(hash, 16 /*0x10*/, 20);
    else
      signer.BlockUpdate(hash, 0, hash.Length);
    return signer.VerifySignature(digitallySigned.Signature);
  }
}
