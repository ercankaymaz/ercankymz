// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public abstract class BcTlsSigner : TlsSigner
{
  protected readonly BcTlsCrypto m_crypto;
  protected readonly AsymmetricKeyParameter m_privateKey;

  protected BcTlsSigner(BcTlsCrypto crypto, AsymmetricKeyParameter privateKey)
  {
    if (crypto == null)
      throw new ArgumentNullException(nameof (crypto));
    if (privateKey == null)
      throw new ArgumentNullException(nameof (privateKey));
    if (!privateKey.IsPrivate)
      throw new ArgumentException("must be private", nameof (privateKey));
    this.m_crypto = crypto;
    this.m_privateKey = privateKey;
  }

  public virtual byte[] GenerateRawSignature(SignatureAndHashAlgorithm algorithm, byte[] hash)
  {
    throw new NotSupportedException();
  }

  public virtual TlsStreamSigner GetStreamSigner(SignatureAndHashAlgorithm algorithm)
  {
    return (TlsStreamSigner) null;
  }
}
