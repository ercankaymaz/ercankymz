// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReverseConnectHost
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Bindings;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ReverseConnectHost
{
  private ITransportListener m_listener;
  private ConnectionWaitingHandlerAsync m_onConnectionWaiting;
  private EventHandler<ConnectionStatusEventArgs> m_onConnectionStatusChanged;

  public void CreateListener(
    Uri url,
    ConnectionWaitingHandlerAsync OnConnectionWaiting,
    EventHandler<ConnectionStatusEventArgs> OnConnectionStatusChanged)
  {
    if (url == (Uri) null)
      throw new ArgumentNullException(nameof (url));
    this.m_listener = TransportBindings.Listeners.GetListener(url.Scheme) ?? throw ServiceResultException.Create(2159935488U /*0x80BE0000*/, "Unsupported transport profile for scheme {0}.", (object) url.Scheme);
    this.Url = url;
    this.m_onConnectionWaiting = OnConnectionWaiting;
    this.m_onConnectionStatusChanged = OnConnectionStatusChanged;
  }

  public Uri Url { get; private set; }

  public void Open()
  {
    try
    {
      TransportListenerSettings settings = new TransportListenerSettings()
      {
        Descriptions = (EndpointDescriptionCollection) null,
        Configuration = (EndpointConfiguration) null,
        CertificateValidator = (ICertificateValidator) null,
        NamespaceUris = (NamespaceTable) null,
        Factory = (IEncodeableFactory) null,
        ServerCertificate = (X509Certificate2) null,
        ServerCertificateChain = (X509Certificate2Collection) null,
        ReverseConnectListener = true
      };
      Utils.LogInfo("Open reverse connect listener for {0}.", (object) this.Url);
      this.m_listener.Open(this.Url, settings, (ITransportListenerCallback) null);
      this.m_listener.ConnectionWaiting += this.m_onConnectionWaiting;
      this.m_listener.ConnectionStatusChanged += this.m_onConnectionStatusChanged;
    }
    catch (Exception ex)
    {
      object[] objArray = new object[1]{ (object) this.Url };
      Utils.LogError(ex, "Could not open listener for {0}.", objArray);
      throw;
    }
  }

  public void Close()
  {
    this.m_listener.ConnectionWaiting -= this.m_onConnectionWaiting;
    this.m_listener.ConnectionStatusChanged -= this.m_onConnectionStatusChanged;
    this.m_listener.Close();
  }
}
