// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ITransportListener
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface ITransportListener : IDisposable
{
  string UriScheme { get; }

  void Open(
    Uri baseAddress,
    TransportListenerSettings settings,
    ITransportListenerCallback callback);

  void Close();

  void CertificateUpdate(
    ICertificateValidator validator,
    X509Certificate2 serverCertificate,
    X509Certificate2Collection serverCertificateChain);

  event ConnectionWaitingHandlerAsync ConnectionWaiting;

  event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

  void CreateReverseConnection(Uri url, int timeout);
}
