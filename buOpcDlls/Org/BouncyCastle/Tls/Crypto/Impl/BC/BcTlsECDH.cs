// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsECDH
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsECDH : TlsAgreement
{
  protected readonly BcTlsECDomain m_domain;
  protected AsymmetricCipherKeyPair m_localKeyPair;
  protected ECPublicKeyParameters m_peerPublicKey;

  public BcTlsECDH(BcTlsECDomain domain) => this.m_domain = domain;

  public virtual byte[] GenerateEphemeral()
  {
    this.m_localKeyPair = this.m_domain.GenerateKeyPair();
    return this.m_domain.EncodePublicKey((ECPublicKeyParameters) this.m_localKeyPair.Public);
  }

  public virtual void ReceivePeerValue(byte[] peerValue)
  {
    this.m_peerPublicKey = this.m_domain.DecodePublicKey(peerValue);
  }

  public virtual TlsSecret CalculateSecret()
  {
    return (TlsSecret) this.m_domain.CalculateECDHAgreement((ECPrivateKeyParameters) this.m_localKeyPair.Private, this.m_peerPublicKey);
  }
}
