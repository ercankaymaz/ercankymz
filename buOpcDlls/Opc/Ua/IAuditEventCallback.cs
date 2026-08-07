// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IAuditEventCallback
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface IAuditEventCallback
{
  void ReportAuditOpenSecureChannelEvent(
    string globalChannelId,
    EndpointDescription endpointDescription,
    OpenSecureChannelRequest request,
    X509Certificate2 clientCertificate,
    Exception exception);

  void ReportAuditCloseSecureChannelEvent(string globalChannelId, Exception exception);

  void ReportAuditCertificateEvent(X509Certificate2 clientCertificate, Exception exception);
}
