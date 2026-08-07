// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcX25519
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Rfc7748;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcX25519 : TlsAgreement
{
  protected readonly BcTlsCrypto m_crypto;
  protected readonly byte[] m_privateKey = new byte[32 /*0x20*/];
  protected readonly byte[] m_peerPublicKey = new byte[32 /*0x20*/];

  public BcX25519(BcTlsCrypto crypto) => this.m_crypto = crypto;

  public virtual byte[] GenerateEphemeral()
  {
    this.m_crypto.SecureRandom.NextBytes(this.m_privateKey);
    byte[] r = new byte[32 /*0x20*/];
    X25519.ScalarMultBase(this.m_privateKey, 0, r, 0);
    return r;
  }

  public virtual void ReceivePeerValue(byte[] peerValue)
  {
    if (peerValue == null || peerValue.Length != 32 /*0x20*/)
      throw new TlsFatalAlert((short) 47);
    Array.Copy((Array) peerValue, 0, (Array) this.m_peerPublicKey, 0, 32 /*0x20*/);
  }

  public virtual TlsSecret CalculateSecret()
  {
    try
    {
      byte[] numArray = new byte[32 /*0x20*/];
      if (!X25519.CalculateAgreement(this.m_privateKey, 0, this.m_peerPublicKey, 0, numArray, 0))
        throw new TlsFatalAlert((short) 40);
      return (TlsSecret) this.m_crypto.AdoptLocalSecret(numArray);
    }
    finally
    {
      Array.Clear((Array) this.m_privateKey, 0, this.m_privateKey.Length);
      Array.Clear((Array) this.m_peerPublicKey, 0, this.m_peerPublicKey.Length);
    }
  }
}
