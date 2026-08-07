// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpTransportListener
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpTransportListener : ITransportListener, IDisposable, ITcpChannelListener
{
  private readonly object m_lock = new object();
  private string m_listenerId;
  private Uri m_uri;
  private EndpointDescriptionCollection m_descriptions;
  private BufferManager m_bufferManager;
  private ChannelQuotas m_quotas;
  private X509Certificate2 m_serverCertificate;
  private X509Certificate2Collection m_serverCertificateChain;
  private uint m_lastChannelId;
  private Socket m_listeningSocket;
  private Socket m_listeningSocketIPv6;
  private Dictionary<uint, TcpListenerChannel> m_channels;
  private ITransportListenerCallback m_callback;
  private bool m_reverseConnectListener;

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    lock (this.m_lock)
    {
      if (this.m_listeningSocket != null)
      {
        Utils.SilentDispose((IDisposable) this.m_listeningSocket);
        this.m_listeningSocket = (Socket) null;
      }
      if (this.m_listeningSocketIPv6 != null)
      {
        Utils.SilentDispose((IDisposable) this.m_listeningSocketIPv6);
        this.m_listeningSocketIPv6 = (Socket) null;
      }
      if (this.m_channels == null)
        return;
      foreach (IDisposable disposable in this.m_channels.Values)
        Utils.SilentDispose(disposable);
      this.m_channels = (Dictionary<uint, TcpListenerChannel>) null;
    }
  }

  public string UriScheme => "opc.tcp";

  public void Open(
    Uri baseAddress,
    TransportListenerSettings settings,
    ITransportListenerCallback callback)
  {
    this.m_listenerId = Guid.NewGuid().ToString();
    this.m_uri = baseAddress;
    this.m_descriptions = settings.Descriptions;
    EndpointConfiguration configuration = settings.Configuration;
    this.m_quotas = new ChannelQuotas();
    ServiceMessageContext serviceMessageContext = new ServiceMessageContext()
    {
      NamespaceUris = settings.NamespaceUris,
      ServerUris = new StringTable(),
      Factory = settings.Factory
    };
    if (configuration != null)
    {
      this.m_quotas.MaxBufferSize = configuration.MaxBufferSize;
      this.m_quotas.MaxMessageSize = configuration.MaxMessageSize;
      this.m_quotas.ChannelLifetime = configuration.ChannelLifetime;
      this.m_quotas.SecurityTokenLifetime = configuration.SecurityTokenLifetime;
      serviceMessageContext.MaxArrayLength = configuration.MaxArrayLength;
      serviceMessageContext.MaxByteStringLength = configuration.MaxByteStringLength;
      serviceMessageContext.MaxMessageSize = configuration.MaxMessageSize;
      serviceMessageContext.MaxStringLength = configuration.MaxStringLength;
    }
    this.m_quotas.MessageContext = (IServiceMessageContext) serviceMessageContext;
    this.m_quotas.CertificateValidator = settings.CertificateValidator;
    this.m_serverCertificate = settings.ServerCertificate;
    this.m_serverCertificateChain = settings.ServerCertificateChain;
    this.m_bufferManager = new BufferManager("Server", this.m_quotas.MaxBufferSize);
    this.m_channels = new Dictionary<uint, TcpListenerChannel>();
    this.m_reverseConnectListener = settings.ReverseConnectListener;
    this.m_callback = callback;
    this.Start();
  }

  public void Close() => this.Stop();

  public Uri EndpointUrl => this.m_uri;

  public bool ReconnectToExistingChannel(
    IMessageSocket socket,
    uint requestId,
    uint sequenceNumber,
    uint channelId,
    X509Certificate2 clientCertificate,
    ChannelToken token,
    OpenSecureChannelRequest request)
  {
    TcpListenerChannel tcpListenerChannel = (TcpListenerChannel) null;
    lock (this.m_lock)
    {
      if (!this.m_channels.TryGetValue(channelId, out tcpListenerChannel))
        throw ServiceResultException.Create(2155806720U /*0x807F0000*/, "Could not find secure channel referenced in the OpenSecureChannel request.");
    }
    tcpListenerChannel.Reconnect(socket, requestId, sequenceNumber, clientCertificate, token, request);
    Utils.LogInfo("ChannelId {0}: reconnected", (object) channelId);
    return true;
  }

  public void ChannelClosed(uint channelId)
  {
    lock (this.m_lock)
    {
      if (this.m_channels != null)
        this.m_channels.Remove(channelId);
    }
    Utils.LogInfo("ChannelId {0}: closed", (object) channelId);
  }

  public event ConnectionWaitingHandlerAsync ConnectionWaiting;

  public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

  public void CreateReverseConnection(Uri url, int timeout)
  {
    TcpServerChannel callbackData = new TcpServerChannel(this.m_listenerId, (ITcpChannelListener) this, this.m_bufferManager, this.m_quotas, this.m_serverCertificate, this.m_descriptions);
    uint nextChannelId = this.GetNextChannelId();
    callbackData.StatusChanged += new TcpChannelStatusEventHandler(this.Channel_StatusChanged);
    callbackData.BeginReverseConnect(nextChannelId, url, new AsyncCallback(this.OnReverseHelloComplete), (object) callbackData, Math.Min(timeout, this.m_quotas.ChannelLifetime));
  }

  private void Channel_StatusChanged(TcpServerChannel channel, ServiceResult status, bool closed)
  {
    EventHandler<ConnectionStatusEventArgs> connectionStatusChanged = this.ConnectionStatusChanged;
    if (connectionStatusChanged == null)
      return;
    connectionStatusChanged((object) this, new ConnectionStatusEventArgs(channel.ReverseConnectionUrl, status, closed));
  }

  private void OnReverseHelloComplete(IAsyncResult result)
  {
    TcpServerChannel asyncState = (TcpServerChannel) result.AsyncState;
    try
    {
      asyncState.EndReverseConnect(result);
      lock (this.m_lock)
        this.m_channels.Add(asyncState.Id, (TcpListenerChannel) asyncState);
      if (this.m_callback == null)
        return;
      asyncState.SetRequestReceivedCallback(new TcpChannelRequestEventHandler(this.OnRequestReceived));
      asyncState.SetReportOpenSecureChannellAuditCalback(new ReportAuditOpenSecureChannelEventHandler(this.OnReportAuditOpenSecureChannelEvent));
      asyncState.SetReportCloseSecureChannellAuditCalback(new ReportAuditCloseSecureChannelEventHandler(this.OnReportAuditCloseSecureChannelEvent));
      asyncState.SetReportCertificateAuditCalback(new ReportAuditCertificateEventHandler(this.OnReportAuditCertificateEvent));
    }
    catch (Exception ex)
    {
      EventHandler<ConnectionStatusEventArgs> connectionStatusChanged = this.ConnectionStatusChanged;
      if (connectionStatusChanged == null)
        return;
      connectionStatusChanged((object) this, new ConnectionStatusEventArgs(asyncState.ReverseConnectionUrl, new ServiceResult(ex), true));
    }
  }

  public void Start()
  {
    lock (this.m_lock)
    {
      int port = this.m_uri.Port;
      if (port <= 0 || port > (int) ushort.MaxValue)
        port = 4840;
      bool flag = true;
      switch (Uri.CheckHostName(this.m_uri.Host))
      {
        case UriHostNameType.Unknown:
        case UriHostNameType.Basic:
        case UriHostNameType.Dns:
          flag = false;
          break;
      }
      IPAddress any = IPAddress.Any;
      if (flag)
        any = IPAddress.Parse(this.m_uri.Host);
      try
      {
        IPEndPoint localEP = new IPEndPoint(any, port);
        this.m_listeningSocket = new Socket(localEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        SocketAsyncEventArgs e = new SocketAsyncEventArgs();
        e.Completed += new EventHandler<SocketAsyncEventArgs>(this.OnAccept);
        e.UserToken = (object) this.m_listeningSocket;
        this.m_listeningSocket.Bind((EndPoint) localEP);
        this.m_listeningSocket.Listen(int.MaxValue);
        if (!this.m_listeningSocket.AcceptAsync(e))
          this.OnAccept((object) null, e);
      }
      catch (Exception ex)
      {
        if (this.m_listeningSocket != null)
        {
          this.m_listeningSocket.Dispose();
          this.m_listeningSocket = (Socket) null;
        }
        Utils.LogWarning("Failed to create IPv4 listening socket: {0}", (object) ex.Message);
      }
      if (any == IPAddress.Any)
      {
        try
        {
          IPEndPoint localEP = new IPEndPoint(IPAddress.IPv6Any, port);
          this.m_listeningSocketIPv6 = new Socket(localEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
          SocketAsyncEventArgs e = new SocketAsyncEventArgs();
          e.Completed += new EventHandler<SocketAsyncEventArgs>(this.OnAccept);
          e.UserToken = (object) this.m_listeningSocketIPv6;
          this.m_listeningSocketIPv6.Bind((EndPoint) localEP);
          this.m_listeningSocketIPv6.Listen(int.MaxValue);
          if (!this.m_listeningSocketIPv6.AcceptAsync(e))
            this.OnAccept((object) null, e);
        }
        catch (Exception ex)
        {
          if (this.m_listeningSocketIPv6 != null)
          {
            this.m_listeningSocketIPv6.Dispose();
            this.m_listeningSocketIPv6 = (Socket) null;
          }
          Utils.LogWarning("Failed to create IPv6 listening socket: {0}", (object) ex.Message);
        }
      }
      if (this.m_listeningSocketIPv6 == null && this.m_listeningSocket == null)
        throw ServiceResultException.Create(2150694912U /*0x80310000*/, "Failed to establish tcp listener sockets for Ipv4 and IPv6.");
    }
  }

  public void Stop()
  {
    lock (this.m_lock)
    {
      this.ConnectionWaiting = (ConnectionWaitingHandlerAsync) null;
      this.ConnectionStatusChanged = (EventHandler<ConnectionStatusEventArgs>) null;
      if (this.m_listeningSocket != null)
      {
        this.m_listeningSocket.Dispose();
        this.m_listeningSocket = (Socket) null;
      }
      if (this.m_listeningSocketIPv6 == null)
        return;
      this.m_listeningSocketIPv6.Dispose();
      this.m_listeningSocketIPv6 = (Socket) null;
    }
  }

  public async Task<bool> TransferListenerChannel(
    uint channelId,
    string serverUri,
    Uri endpointUrl)
  {
    TcpTransportListener sender = this;
    bool flag = false;
    TcpListenerChannel tcpListenerChannel = (TcpListenerChannel) null;
    lock (sender.m_lock)
    {
      if (!sender.m_channels.TryGetValue(channelId, out tcpListenerChannel))
        throw ServiceResultException.Create(2155806720U /*0x807F0000*/, "Could not find secure channel request.");
    }
    if (sender.ConnectionWaiting != null)
    {
      TcpConnectionWaitingEventArgs args = new TcpConnectionWaitingEventArgs(serverUri, endpointUrl, tcpListenerChannel.Socket);
      await sender.ConnectionWaiting((object) sender, (ConnectionWaitingEventArgs) args).ConfigureAwait(false);
      flag = args.Accepted;
      args = (TcpConnectionWaitingEventArgs) null;
    }
    if (flag)
    {
      lock (sender.m_lock)
        sender.m_channels.Remove(channelId);
    }
    return flag;
  }

  public void CertificateUpdate(
    ICertificateValidator validator,
    X509Certificate2 serverCertificate,
    X509Certificate2Collection serverCertificateChain)
  {
    this.m_quotas.CertificateValidator = validator;
    this.m_serverCertificate = serverCertificate;
    this.m_serverCertificateChain = serverCertificateChain;
    foreach (EndpointDescription description in (List<EndpointDescription>) this.m_descriptions)
    {
      if (this.m_serverCertificateChain != null && this.m_serverCertificateChain.Count > 1)
      {
        List<byte> byteList = new List<byte>();
        for (int index = 0; index < this.m_serverCertificateChain.Count; ++index)
          byteList.AddRange((IEnumerable<byte>) this.m_serverCertificateChain[index].RawData);
        description.ServerCertificate = byteList.ToArray();
      }
      else if (description.ServerCertificate != null)
        description.ServerCertificate = serverCertificate.RawData;
    }
  }

  private void OnAccept(object sender, SocketAsyncEventArgs e)
  {
    bool flag;
    do
    {
      flag = false;
      lock (this.m_lock)
      {
        if (!(e.UserToken is Socket userToken))
        {
          Utils.LogError("OnAccept: Listensocket was null.");
          e.Dispose();
          break;
        }
        if (e.AcceptSocket != null)
        {
          if (e.SocketError == SocketError.Success)
          {
            try
            {
              TcpListenerChannel tcpListenerChannel = !this.m_reverseConnectListener ? (TcpListenerChannel) new TcpServerChannel(this.m_listenerId, (ITcpChannelListener) this, this.m_bufferManager, this.m_quotas, this.m_serverCertificate, this.m_serverCertificateChain, this.m_descriptions) : (TcpListenerChannel) new TcpReverseConnectChannel(this.m_listenerId, (ITcpChannelListener) this, this.m_bufferManager, this.m_quotas, this.m_descriptions);
              if (this.m_callback != null)
              {
                tcpListenerChannel.SetRequestReceivedCallback(new TcpChannelRequestEventHandler(this.OnRequestReceived));
                tcpListenerChannel.SetReportOpenSecureChannellAuditCalback(new ReportAuditOpenSecureChannelEventHandler(this.OnReportAuditOpenSecureChannelEvent));
                tcpListenerChannel.SetReportCloseSecureChannellAuditCalback(new ReportAuditCloseSecureChannelEventHandler(this.OnReportAuditCloseSecureChannelEvent));
                tcpListenerChannel.SetReportCertificateAuditCalback(new ReportAuditCertificateEventHandler(this.OnReportAuditCertificateEvent));
              }
              uint nextChannelId = this.GetNextChannelId();
              tcpListenerChannel.Attach(nextChannelId, e.AcceptSocket);
              this.m_channels.Add(nextChannelId, tcpListenerChannel);
            }
            catch (Exception ex)
            {
              object[] objArray = Array.Empty<object>();
              Utils.LogError(ex, "Unexpected error accepting a new connection.", objArray);
            }
          }
        }
        e.Dispose();
        if (e.SocketError != SocketError.OperationAborted)
        {
          try
          {
            e = new SocketAsyncEventArgs();
            e.Completed += new EventHandler<SocketAsyncEventArgs>(this.OnAccept);
            e.UserToken = (object) userToken;
            if (!userToken.AcceptAsync(e))
              flag = true;
          }
          catch (Exception ex)
          {
            object[] objArray = Array.Empty<object>();
            Utils.LogError(ex, "Unexpected error listening for a new connection.", objArray);
          }
        }
      }
    }
    while (flag);
  }

  private void OnRequestReceived(
    TcpListenerChannel channel,
    uint requestId,
    IServiceRequest request)
  {
    try
    {
      if (this.m_callback == null)
        return;
      this.m_callback.BeginProcessRequest(channel.GlobalChannelId, channel.EndpointDescription, request, new AsyncCallback(this.OnProcessRequestComplete), (object) new object[3]
      {
        (object) channel,
        (object) requestId,
        (object) request
      });
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "TCPLISTENER - Unexpected error processing request.", objArray);
    }
  }

  private void OnReportAuditOpenSecureChannelEvent(
    TcpServerChannel channel,
    OpenSecureChannelRequest request,
    X509Certificate2 clientCertificate,
    Exception exception)
  {
    try
    {
      if (this.m_callback == null)
        return;
      this.m_callback.ReportAuditOpenSecureChannelEvent(channel.GlobalChannelId, channel.EndpointDescription, request, clientCertificate, exception);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "TCPLISTENER - Unexpected error sending OpenSecureChannel Audit event.", objArray);
    }
  }

  private void OnReportAuditCloseSecureChannelEvent(TcpServerChannel channel, Exception exception)
  {
    try
    {
      if (this.m_callback == null)
        return;
      this.m_callback.ReportAuditCloseSecureChannelEvent(channel.GlobalChannelId, exception);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "TCPLISTENER - Unexpected error sending CloseSecureChannel Audit event.", objArray);
    }
  }

  private void OnReportAuditCertificateEvent(
    X509Certificate2 clientCertificate,
    Exception exception)
  {
    try
    {
      if (this.m_callback == null)
        return;
      this.m_callback.ReportAuditCertificateEvent(clientCertificate, exception);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "TCPLISTENER - Unexpected error sending Certificate Audit event.", objArray);
    }
  }

  private void OnProcessRequestComplete(IAsyncResult result)
  {
    try
    {
      object[] asyncState = (object[]) result.AsyncState;
      if (this.m_callback == null)
        return;
      TcpServerChannel tcpServerChannel = (TcpServerChannel) asyncState[0];
      IServiceResponse serviceResponse = this.m_callback.EndProcessRequest(result);
      int requestId = (int) (uint) asyncState[1];
      IServiceResponse response = serviceResponse;
      tcpServerChannel.SendResponse((uint) requestId, response);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "TCPLISTENER - Unexpected error sending result.", objArray);
    }
  }

  private uint GetNextChannelId()
  {
    lock (this.m_lock)
    {
      uint key;
      do
      {
        key = ++this.m_lastChannelId;
      }
      while (this.m_channels.ContainsKey(key));
      return key;
    }
  }

  private void SetUri(Uri baseAddress, string relativeAddress)
  {
    if (baseAddress == (Uri) null)
      throw new ArgumentNullException(nameof (baseAddress));
    if (!baseAddress.IsAbsoluteUri)
      throw new ArgumentException("Base address must be an absolute URI.", nameof (baseAddress));
    this.m_uri = string.Equals(baseAddress.Scheme, "opc.tcp", StringComparison.OrdinalIgnoreCase) ? baseAddress : throw new ArgumentException($"Invalid URI scheme: {baseAddress.Scheme}.", nameof (baseAddress));
    if (string.IsNullOrEmpty(relativeAddress))
      return;
    if (!baseAddress.AbsolutePath.EndsWith("/", StringComparison.Ordinal))
    {
      UriBuilder uriBuilder = new UriBuilder(baseAddress);
      uriBuilder.Path += "/";
      baseAddress = uriBuilder.Uri;
    }
    this.m_uri = new Uri(baseAddress, relativeAddress);
  }
}
