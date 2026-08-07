// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.UaSCUaBinaryTransportChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class UaSCUaBinaryTransportChannel : ITransportChannel, IDisposable, IMessageSocketChannel
{
  private const int kChannelCloseDefault = 1000;
  private readonly object m_lock = new object();
  private Uri m_url;
  private int m_operationTimeout;
  private TransportChannelSettings m_settings;
  private ChannelQuotas m_quotas;
  private BufferManager m_bufferManager;
  private UaSCUaBinaryClientChannel m_channel;
  private IMessageSocketFactory m_messageSocketFactory;

  public UaSCUaBinaryTransportChannel(IMessageSocketFactory messageSocketFactory)
  {
    this.m_messageSocketFactory = messageSocketFactory;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    Utils.SilentDispose((IDisposable) this.m_channel);
    this.m_channel = (UaSCUaBinaryClientChannel) null;
  }

  public IMessageSocket Socket
  {
    get
    {
      lock (this.m_lock)
        return this.m_channel?.Socket;
    }
  }

  public TransportChannelFeatures SupportedFeatures
  {
    get
    {
      return (TransportChannelFeatures) (163 | (this.Socket != null ? (int) this.Socket.MessageSocketFeatures : 0));
    }
  }

  public EndpointDescription EndpointDescription => this.m_settings.Description;

  public EndpointConfiguration EndpointConfiguration => this.m_settings.Configuration;

  public IServiceMessageContext MessageContext => this.m_quotas.MessageContext;

  public ChannelToken CurrentToken
  {
    get
    {
      lock (this.m_lock)
        return this.m_channel?.CurrentToken;
    }
  }

  public int OperationTimeout
  {
    get => this.m_operationTimeout;
    set => this.m_operationTimeout = value;
  }

  public void Initialize(Uri url, TransportChannelSettings settings)
  {
    this.SaveSettings(url, settings);
    this.CreateChannel();
  }

  public void Initialize(ITransportWaitingConnection connection, TransportChannelSettings settings)
  {
    this.SaveSettings(connection.EndpointUrl, settings);
    this.CreateChannel(connection);
  }

  public void Open()
  {
  }

  public IAsyncResult BeginOpen(AsyncCallback callback, object callbackData)
  {
    lock (this.m_lock)
    {
      this.CreateChannel();
      return this.m_channel.BeginConnect(this.m_url, this.m_operationTimeout, callback, callbackData);
    }
  }

  public void EndOpen(IAsyncResult result) => this.m_channel.EndConnect(result);

  public void Reconnect() => this.Reconnect((ITransportWaitingConnection) null);

  public void Reconnect(ITransportWaitingConnection connection)
  {
    Utils.LogInfo("TransportChannel RECONNECT: Reconnecting to {0}.", (object) this.m_url);
    lock (this.m_lock)
    {
      UaSCUaBinaryClientChannel channel = this.m_channel;
      this.m_channel = (UaSCUaBinaryClientChannel) null;
      try
      {
        this.CreateChannel(connection);
        this.m_channel.EndConnect(this.m_channel.BeginConnect(this.m_url, this.m_operationTimeout, (AsyncCallback) null, (object) null));
      }
      finally
      {
        if (channel != null)
        {
          try
          {
            channel.Close(1000);
          }
          catch (Exception ex)
          {
            object[] objArray = Array.Empty<object>();
            Utils.LogTrace(ex, "Ignoring exception while closing transport channel during Reconnect.", objArray);
          }
          finally
          {
            channel.Dispose();
          }
        }
      }
    }
  }

  public IAsyncResult BeginReconnect(AsyncCallback callback, object callbackData)
  {
    throw new NotImplementedException();
  }

  public void EndReconnect(IAsyncResult result) => throw new NotImplementedException();

  public void Close()
  {
    if (this.m_channel == null)
      return;
    lock (this.m_lock)
    {
      if (this.m_channel == null)
        return;
      this.m_channel.Close(1000);
      this.m_channel = (UaSCUaBinaryClientChannel) null;
    }
  }

  public async Task CloseAsync(CancellationToken ct)
  {
    UaSCUaBinaryClientChannel binaryClientChannel = (UaSCUaBinaryClientChannel) null;
    lock (this.m_lock)
    {
      if (this.m_channel != null)
      {
        binaryClientChannel = this.m_channel;
        this.m_channel = (UaSCUaBinaryClientChannel) null;
      }
    }
    if (binaryClientChannel == null)
      return;
    await binaryClientChannel.CloseAsync(1000, ct).ConfigureAwait(false);
  }

  public IAsyncResult BeginClose(AsyncCallback callback, object callbackData)
  {
    throw new NotImplementedException();
  }

  public void EndClose(IAsyncResult result) => throw new NotImplementedException();

  public IServiceResponse SendRequest(IServiceRequest request)
  {
    return this.EndSendRequest(this.BeginSendRequest(request, (AsyncCallback) null, (object) null));
  }

  public Task<IServiceResponse> SendRequestAsync(IServiceRequest request, CancellationToken ct)
  {
    return this.EndSendRequestAsync(this.BeginSendRequest(request, (AsyncCallback) null, (object) null), ct);
  }

  public IAsyncResult BeginSendRequest(
    IServiceRequest request,
    AsyncCallback callback,
    object callbackData)
  {
    UaSCUaBinaryClientChannel channel = this.m_channel;
    if (channel == null)
    {
      lock (this.m_lock)
      {
        if (this.m_channel == null)
          this.CreateChannel();
        channel = this.m_channel;
      }
    }
    return channel.BeginSendRequest(request, this.m_operationTimeout, callback, callbackData);
  }

  public IServiceResponse EndSendRequest(IAsyncResult result)
  {
    return (this.m_channel ?? throw ServiceResultException.Create(2156265472U /*0x80860000*/, "Channel has been closed.")).EndSendRequest(result);
  }

  public Task<IServiceResponse> EndSendRequestAsync(IAsyncResult result, CancellationToken ct)
  {
    return (this.m_channel ?? throw ServiceResultException.Create(2156265472U /*0x80860000*/, "Channel has been closed.")).EndSendRequestAsync(result, ct);
  }

  private void SaveSettings(Uri url, TransportChannelSettings settings)
  {
    this.m_url = url;
    this.m_settings = settings;
    this.m_operationTimeout = settings.Configuration.OperationTimeout;
    this.m_quotas = new ChannelQuotas();
    this.m_quotas.MaxBufferSize = this.m_settings.Configuration.MaxBufferSize;
    this.m_quotas.MaxMessageSize = this.m_settings.Configuration.MaxMessageSize;
    this.m_quotas.ChannelLifetime = this.m_settings.Configuration.ChannelLifetime;
    this.m_quotas.SecurityTokenLifetime = this.m_settings.Configuration.SecurityTokenLifetime;
    this.m_quotas.MessageContext = (IServiceMessageContext) new ServiceMessageContext()
    {
      MaxArrayLength = this.m_settings.Configuration.MaxArrayLength,
      MaxByteStringLength = this.m_settings.Configuration.MaxByteStringLength,
      MaxMessageSize = this.m_settings.Configuration.MaxMessageSize,
      MaxStringLength = this.m_settings.Configuration.MaxStringLength,
      NamespaceUris = this.m_settings.NamespaceUris,
      ServerUris = new StringTable(),
      Factory = this.m_settings.Factory
    };
    this.m_quotas.CertificateValidator = settings.CertificateValidator;
    this.m_bufferManager = new BufferManager("Client", settings.Configuration.MaxBufferSize);
  }

  private void CreateChannel(ITransportWaitingConnection connection = null)
  {
    messageSocket = (IMessageSocket) null;
    if (connection != null && !(connection.Handle is IMessageSocket messageSocket))
      throw new ArgumentException("Connection Handle is not of type IMessageSocket.");
    this.m_channel = new UaSCUaBinaryClientChannel(Guid.NewGuid().ToString(), this.m_bufferManager, this.m_messageSocketFactory, this.m_quotas, this.m_settings.ClientCertificate, this.m_settings.ClientCertificateChain, this.m_settings.ServerCertificate, this.m_settings.Description);
    if (messageSocket == null)
      return;
    this.m_channel.Socket = messageSocket;
    this.m_channel.Socket.ChangeSink((IMessageSink) this.m_channel);
    this.m_channel.ReverseSocket = true;
  }
}
