// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsServer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public interface TlsServer : TlsPeer
{
  void Init(TlsServerContext context);

  TlsSession GetSessionToResume(byte[] sessionID);

  byte[] GetNewSessionID();

  TlsPskExternal GetExternalPsk(IList<PskIdentity> identities);

  void NotifySession(TlsSession session);

  void NotifyClientVersion(ProtocolVersion clientVersion);

  void NotifyFallback(bool isFallback);

  void NotifyOfferedCipherSuites(int[] offeredCipherSuites);

  void ProcessClientExtensions(IDictionary<int, byte[]> clientExtensions);

  ProtocolVersion GetServerVersion();

  int[] GetSupportedGroups();

  int GetSelectedCipherSuite();

  IDictionary<int, byte[]> GetServerExtensions();

  void GetServerExtensionsForConnection(IDictionary<int, byte[]> serverExtensions);

  IList<SupplementalDataEntry> GetServerSupplementalData();

  TlsCredentials GetCredentials();

  CertificateStatus GetCertificateStatus();

  CertificateRequest GetCertificateRequest();

  TlsPskIdentityManager GetPskIdentityManager();

  TlsSrpLoginParameters GetSrpLoginParameters();

  TlsDHConfig GetDHConfig();

  TlsECConfig GetECDHConfig();

  void ProcessClientSupplementalData(
    IList<SupplementalDataEntry> clientSupplementalData);

  void NotifyClientCertificate(Certificate clientCertificate);

  NewSessionTicket GetNewSessionTicket();
}
