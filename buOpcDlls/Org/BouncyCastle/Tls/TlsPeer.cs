// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsPeer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

public interface TlsPeer
{
  TlsCrypto Crypto { get; }

  void NotifyCloseHandle(TlsCloseable closehandle);

  void Cancel();

  ProtocolVersion[] GetProtocolVersions();

  int[] GetCipherSuites();

  void NotifyHandshakeBeginning();

  int GetHandshakeTimeoutMillis();

  bool AllowLegacyResumption();

  int GetMaxCertificateChainLength();

  int GetMaxHandshakeMessageSize();

  short[] GetPskKeyExchangeModes();

  bool RequiresCloseNotify();

  bool RequiresExtendedMasterSecret();

  bool ShouldUseExtendedMasterSecret();

  bool ShouldUseExtendedPadding();

  bool ShouldUseGmtUnixTime();

  void NotifySecureRenegotiation(bool secureRenegotiation);

  TlsKeyExchangeFactory GetKeyExchangeFactory();

  void NotifyAlertRaised(
    short alertLevel,
    short alertDescription,
    string message,
    Exception cause);

  void NotifyAlertReceived(short alertLevel, short alertDescription);

  void NotifyHandshakeComplete();

  TlsHeartbeat GetHeartbeat();

  short GetHeartbeatPolicy();

  bool IgnoreCorruptDtlsRecords { get; }
}
