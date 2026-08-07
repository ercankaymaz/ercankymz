// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsClient
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public interface TlsClient : TlsPeer
{
  void Init(TlsClientContext context);

  TlsSession GetSessionToResume();

  IList<TlsPskExternal> GetExternalPsks();

  bool IsFallback();

  IDictionary<int, byte[]> GetClientExtensions();

  IList<int> GetEarlyKeyShareGroups();

  void NotifyServerVersion(ProtocolVersion selectedVersion);

  void NotifySessionToResume(TlsSession session);

  void NotifySessionID(byte[] sessionID);

  void NotifySelectedCipherSuite(int selectedCipherSuite);

  void NotifySelectedPsk(TlsPsk selectedPsk);

  void ProcessServerExtensions(IDictionary<int, byte[]> serverExtensions);

  void ProcessServerSupplementalData(
    IList<SupplementalDataEntry> serverSupplementalData);

  TlsPskIdentity GetPskIdentity();

  TlsSrpIdentity GetSrpIdentity();

  TlsDHGroupVerifier GetDHGroupVerifier();

  TlsSrpConfigVerifier GetSrpConfigVerifier();

  TlsAuthentication GetAuthentication();

  IList<SupplementalDataEntry> GetClientSupplementalData();

  void NotifyNewSessionTicket(NewSessionTicket newSessionTicket);
}
