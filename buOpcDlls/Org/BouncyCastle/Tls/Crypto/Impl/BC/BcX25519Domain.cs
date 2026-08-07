// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcX25519Domain
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcX25519Domain : TlsECDomain
{
  protected readonly BcTlsCrypto m_crypto;

  public BcX25519Domain(BcTlsCrypto crypto) => this.m_crypto = crypto;

  public virtual TlsAgreement CreateECDH() => (TlsAgreement) new BcX25519(this.m_crypto);
}
