// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcX448
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Rfc7748;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcX448 : TlsAgreement
{
  protected readonly BcTlsCrypto m_crypto;
  protected readonly byte[] m_privateKey = new byte[56];
  protected readonly byte[] m_peerPublicKey = new byte[56];

  public BcX448(BcTlsCrypto crypto) => this.m_crypto = crypto;

  public virtual byte[] GenerateEphemeral()
  {
    this.m_crypto.SecureRandom.NextBytes(this.m_privateKey);
    byte[] r = new byte[56];
    X448.ScalarMultBase(this.m_privateKey, 0, r, 0);
    return r;
  }

  public virtual void ReceivePeerValue(byte[] peerValue)
  {
    if (peerValue == null || peerValue.Length != 56)
      throw new TlsFatalAlert((short) 47);
    Array.Copy((Array) peerValue, 0, (Array) this.m_peerPublicKey, 0, 56);
  }

  public virtual TlsSecret CalculateSecret()
  {
    try
    {
      byte[] numArray = new byte[56];
      if (!X448.CalculateAgreement(this.m_privateKey, 0, this.m_peerPublicKey, 0, numArray, 0))
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
