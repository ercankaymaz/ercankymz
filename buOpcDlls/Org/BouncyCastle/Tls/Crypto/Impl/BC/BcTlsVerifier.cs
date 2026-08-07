// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsVerifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public abstract class BcTlsVerifier : TlsVerifier
{
  protected readonly BcTlsCrypto m_crypto;
  protected readonly AsymmetricKeyParameter m_publicKey;

  protected BcTlsVerifier(BcTlsCrypto crypto, AsymmetricKeyParameter publicKey)
  {
    if (crypto == null)
      throw new ArgumentNullException(nameof (crypto));
    if (publicKey == null)
      throw new ArgumentNullException(nameof (publicKey));
    if (publicKey.IsPrivate)
      throw new ArgumentException("must be public", nameof (publicKey));
    this.m_crypto = crypto;
    this.m_publicKey = publicKey;
  }

  public virtual TlsStreamVerifier GetStreamVerifier(DigitallySigned digitallySigned)
  {
    return (TlsStreamVerifier) null;
  }

  public virtual bool VerifyRawSignature(DigitallySigned digitallySigned, byte[] hash)
  {
    throw new NotSupportedException();
  }
}
