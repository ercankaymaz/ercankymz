// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.AbstractTlsPeer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class AbstractTlsPeer : TlsPeer
{
  private readonly TlsCrypto m_crypto;
  private volatile TlsCloseable m_closeHandle;

  protected AbstractTlsPeer(TlsCrypto crypto) => this.m_crypto = crypto;

  protected virtual ProtocolVersion[] GetSupportedVersions()
  {
    return ProtocolVersion.TLSv13.DownTo(ProtocolVersion.TLSv12);
  }

  protected abstract int[] GetSupportedCipherSuites();

  public virtual void Cancel() => this.m_closeHandle?.Close();

  public virtual TlsCrypto Crypto => this.m_crypto;

  public virtual void NotifyCloseHandle(TlsCloseable closeHandle)
  {
    this.m_closeHandle = closeHandle;
  }

  public abstract ProtocolVersion[] GetProtocolVersions();

  public abstract int[] GetCipherSuites();

  public virtual void NotifyHandshakeBeginning()
  {
  }

  public virtual int GetHandshakeTimeoutMillis() => 0;

  public virtual int GetHandshakeResendTimeMillis() => 1000;

  public virtual bool AllowLegacyResumption() => false;

  public virtual int GetMaxCertificateChainLength() => 10;

  public virtual int GetMaxHandshakeMessageSize() => 32768 /*0x8000*/;

  public virtual short[] GetPskKeyExchangeModes()
  {
    return new short[1]{ (short) 1 };
  }

  public virtual bool RequiresCloseNotify() => true;

  public virtual bool RequiresExtendedMasterSecret() => false;

  public virtual bool ShouldCheckSigAlgOfPeerCerts() => true;

  public virtual bool ShouldUseExtendedMasterSecret() => true;

  public virtual bool ShouldUseExtendedPadding() => false;

  public virtual bool ShouldUseGmtUnixTime() => false;

  public virtual void NotifySecureRenegotiation(bool secureRenegotiation)
  {
    if (!secureRenegotiation)
      throw new TlsFatalAlert((short) 40);
  }

  public virtual TlsKeyExchangeFactory GetKeyExchangeFactory()
  {
    return (TlsKeyExchangeFactory) new DefaultTlsKeyExchangeFactory();
  }

  public virtual void NotifyAlertRaised(
    short alertLevel,
    short alertDescription,
    string message,
    Exception cause)
  {
  }

  public virtual void NotifyAlertReceived(short alertLevel, short alertDescription)
  {
  }

  public virtual void NotifyHandshakeComplete()
  {
  }

  public virtual TlsHeartbeat GetHeartbeat() => (TlsHeartbeat) null;

  public virtual short GetHeartbeatPolicy() => 2;

  public virtual bool IgnoreCorruptDtlsRecords => false;
}
