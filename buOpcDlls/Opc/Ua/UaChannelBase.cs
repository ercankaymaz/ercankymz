// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UaChannelBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Bindings;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public abstract class UaChannelBase : IChannelBase, ITransportChannel, IDisposable
{
  internal TransportChannelSettings m_settings;
  internal IServiceMessageContext m_messageContext;
  internal ITransportChannel m_uaBypassChannel;
  internal int m_operationTimeout;
  internal IChannelBase m_channel;
  internal string g_ImplementationString = "Opc.Ua.ChannelBase UA Client " + Utils.GetAssemblySoftwareVersion();

  public UaChannelBase()
  {
    this.m_messageContext = (IServiceMessageContext) null;
    this.m_settings = (TransportChannelSettings) null;
    this.m_uaBypassChannel = (ITransportChannel) null;
  }

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
  }

  public bool UseBinaryEncoding
  {
    get
    {
      return this.m_settings != null && this.m_settings.Configuration != null && this.m_settings.Configuration.UseBinaryEncoding;
    }
  }

  public BinaryEncodingSupport BinaryEncodingSupport
  {
    get
    {
      if (this.m_settings == null || this.m_settings.Configuration == null)
        return BinaryEncodingSupport.Optional;
      return this.m_settings != null && this.m_settings.Configuration.UseBinaryEncoding ? BinaryEncodingSupport.Required : BinaryEncodingSupport.None;
    }
  }

  public void OpenChannel()
  {
    throw new NotImplementedException("UaBaseChannel does not implement OpenChannel()");
  }

  public void CloseChannel()
  {
    throw new NotImplementedException("UaBaseChannel does not implement CloseChannel()");
  }

  public void ScheduleOutgoingRequest(IChannelOutgoingRequest request)
  {
    throw new NotImplementedException("UaBaseChannel does not implement ScheduleOutgoingRequest()");
  }

  public TransportChannelFeatures SupportedFeatures
  {
    get
    {
      return this.m_uaBypassChannel != null ? this.m_uaBypassChannel.SupportedFeatures : TransportChannelFeatures.Reconnect | TransportChannelFeatures.BeginClose | TransportChannelFeatures.BeginSendRequest | TransportChannelFeatures.SendRequestAsync;
    }
  }

  public EndpointDescription EndpointDescription
  {
    get
    {
      if (this.m_uaBypassChannel != null)
        return this.m_uaBypassChannel.EndpointDescription;
      return this.m_settings != null ? this.m_settings.Description : (EndpointDescription) null;
    }
  }

  public EndpointConfiguration EndpointConfiguration
  {
    get
    {
      if (this.m_uaBypassChannel != null)
        return this.m_uaBypassChannel.EndpointConfiguration;
      return this.m_settings != null ? this.m_settings.Configuration : (EndpointConfiguration) null;
    }
  }

  public IServiceMessageContext MessageContext
  {
    get
    {
      return this.m_uaBypassChannel != null ? this.m_uaBypassChannel.MessageContext : this.m_messageContext;
    }
  }

  public ChannelToken CurrentToken => (ChannelToken) null;

  public int OperationTimeout
  {
    get
    {
      return this.m_uaBypassChannel != null ? this.m_uaBypassChannel.OperationTimeout : this.m_operationTimeout;
    }
    set
    {
      if (this.m_uaBypassChannel != null)
        this.m_uaBypassChannel.OperationTimeout = value;
      else
        this.m_operationTimeout = value;
    }
  }

  public void Initialize(Uri url, TransportChannelSettings settings)
  {
    if (this.m_uaBypassChannel == null)
      throw new NotSupportedException("WCF channels must be configured when they are constructed.");
    this.m_uaBypassChannel.Initialize(url, settings);
  }

  public void Initialize(ITransportWaitingConnection connection, TransportChannelSettings settings)
  {
    throw new NotSupportedException("WCF channels must be configured when they are constructed.");
  }

  public void Open()
  {
    if (this.m_uaBypassChannel == null)
      return;
    this.m_uaBypassChannel.Open();
  }

  public IAsyncResult BeginOpen(AsyncCallback callback, object callbackData)
  {
    if (this.m_uaBypassChannel == null)
      throw new NotSupportedException("WCF channels must be configured when they are constructed.");
    return this.m_uaBypassChannel.BeginOpen(callback, callbackData);
  }

  public void EndOpen(IAsyncResult result)
  {
    if (this.m_uaBypassChannel == null)
      throw new NotSupportedException("WCF channels must be configured when they are constructed.");
    this.m_uaBypassChannel.EndOpen(result);
  }

  public abstract void Reconnect();

  public abstract void Reconnect(ITransportWaitingConnection connection);

  public IAsyncResult BeginReconnect(AsyncCallback callback, object callbackData)
  {
    if (this.m_uaBypassChannel == null)
      throw new NotSupportedException("WCF channels cannot be reconnected.");
    return this.m_uaBypassChannel.BeginReconnect(callback, callbackData);
  }

  public void EndReconnect(IAsyncResult result)
  {
    if (this.m_uaBypassChannel == null)
      throw new NotSupportedException("WCF channels cannot be reconnected.");
    this.m_uaBypassChannel.EndReconnect(result);
  }

  public void Close()
  {
    if (this.m_uaBypassChannel != null)
      this.m_uaBypassChannel.Close();
    else
      this.CloseChannel();
  }

  public async Task CloseAsync(CancellationToken ct)
  {
    if (this.m_uaBypassChannel == null)
      this.CloseChannel();
    else
      await this.m_uaBypassChannel.CloseAsync(ct).ConfigureAwait(false);
  }

  public IAsyncResult BeginClose(AsyncCallback callback, object callbackData)
  {
    if (this.m_uaBypassChannel != null)
      return this.m_uaBypassChannel.BeginClose(callback, callbackData);
    AsyncResultBase asyncResultBase = new AsyncResultBase(callback, callbackData, 0);
    asyncResultBase.OperationCompleted();
    return (IAsyncResult) asyncResultBase;
  }

  public void EndClose(IAsyncResult result)
  {
    if (this.m_uaBypassChannel != null)
    {
      this.m_uaBypassChannel.EndClose(result);
    }
    else
    {
      AsyncResultBase.WaitForComplete(result);
      this.CloseChannel();
    }
  }

  public IServiceResponse SendRequest(IServiceRequest request)
  {
    return this.m_uaBypassChannel != null ? this.m_uaBypassChannel.SendRequest(request) : (IServiceResponse) BinaryDecoder.DecodeMessage(this.InvokeService(new InvokeServiceMessage(BinaryEncoder.EncodeMessage((IEncodeable) request, this.m_messageContext))).InvokeServiceResponse, (Type) null, this.m_messageContext);
  }

  public IAsyncResult BeginSendRequest(
    IServiceRequest request,
    AsyncCallback callback,
    object callbackData)
  {
    return this.m_uaBypassChannel != null ? this.m_uaBypassChannel.BeginSendRequest(request, callback, callbackData) : this.BeginInvokeService(new InvokeServiceMessage(BinaryEncoder.EncodeMessage((IEncodeable) request, this.m_messageContext)), callback, callbackData);
  }

  public IServiceResponse EndSendRequest(IAsyncResult result)
  {
    return this.m_uaBypassChannel != null ? this.m_uaBypassChannel.EndSendRequest(result) : (IServiceResponse) BinaryDecoder.DecodeMessage(this.EndInvokeService(result).InvokeServiceResponse, (Type) null, this.m_messageContext);
  }

  public Task<IServiceResponse> EndSendRequestAsync(IAsyncResult result, CancellationToken ct)
  {
    if (this.m_uaBypassChannel == null)
      throw new NotImplementedException();
    return this.m_uaBypassChannel.EndSendRequestAsync(result, ct);
  }

  public Task<IServiceResponse> SendRequestAsync(IServiceRequest request, CancellationToken ct)
  {
    return Task.Factory.FromAsync<IServiceRequest, IServiceResponse>(new Func<IServiceRequest, AsyncCallback, object, IAsyncResult>(this.BeginSendRequest), new Func<IAsyncResult, IServiceResponse>(this.EndSendRequest), request, (object) null);
  }

  public abstract InvokeServiceResponseMessage InvokeService(InvokeServiceMessage request);

  public abstract IAsyncResult BeginInvokeService(
    InvokeServiceMessage request,
    AsyncCallback callback,
    object asyncState);

  public abstract InvokeServiceResponseMessage EndInvokeService(IAsyncResult result);

  public static ITransportChannel CreateUaBinaryChannel(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    EndpointDescription description,
    EndpointConfiguration endpointConfiguration,
    X509Certificate2 clientCertificate,
    X509Certificate2Collection clientCertificateChain,
    IServiceMessageContext messageContext)
  {
    string scheme = new Uri(description.EndpointUrl).Scheme;
    ITransportChannel channel = TransportBindings.Channels.GetChannel(scheme);
    if (channel == null)
      throw ServiceResultException.Create(2159935488U /*0x80BE0000*/, "Unsupported transport profile for scheme {0}.", (object) scheme);
    TransportChannelSettings settings = new TransportChannelSettings()
    {
      Description = description,
      Configuration = endpointConfiguration,
      ClientCertificate = clientCertificate,
      ClientCertificateChain = clientCertificateChain
    };
    if (description.ServerCertificate != null && description.ServerCertificate.Length != 0)
      settings.ServerCertificate = Utils.ParseCertificateBlob(description.ServerCertificate);
    if (configuration != null)
      settings.CertificateValidator = configuration.CertificateValidator.GetChannelValidator();
    settings.NamespaceUris = messageContext.NamespaceUris;
    settings.Factory = messageContext.Factory;
    channel.Initialize(connection, settings);
    channel.Open();
    return channel;
  }

  public static ITransportChannel CreateUaBinaryChannel(
    ApplicationConfiguration configuration,
    EndpointDescription description,
    EndpointConfiguration endpointConfiguration,
    X509Certificate2 clientCertificate,
    IServiceMessageContext messageContext)
  {
    return UaChannelBase.CreateUaBinaryChannel(configuration, description, endpointConfiguration, clientCertificate, (X509Certificate2Collection) null, messageContext);
  }

  public static ITransportChannel CreateUaBinaryChannel(
    ApplicationConfiguration configuration,
    EndpointDescription description,
    EndpointConfiguration endpointConfiguration,
    X509Certificate2 clientCertificate,
    X509Certificate2Collection clientCertificateChain,
    IServiceMessageContext messageContext)
  {
    string uriScheme = new Uri(description.EndpointUrl).Scheme;
    switch (description.TransportProfileUri)
    {
      case "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary":
        uriScheme = "opc.tcp";
        break;
      case "http://opcfoundation.org/UA-Profile/Transport/https-uabinary":
        uriScheme = "opc.https";
        break;
      case "http://opcfoundation.org/UA-Profile/Transport/uawss-uasc-uabinary":
        uriScheme = "opc.wss";
        break;
    }
    ITransportChannel channel = TransportBindings.Channels.GetChannel(uriScheme);
    if (channel == null)
      throw ServiceResultException.Create(2159935488U /*0x80BE0000*/, "Unsupported transport profile for scheme {0}.", (object) uriScheme);
    TransportChannelSettings settings = new TransportChannelSettings()
    {
      Description = description,
      Configuration = endpointConfiguration,
      ClientCertificate = clientCertificate,
      ClientCertificateChain = clientCertificateChain
    };
    if (description.ServerCertificate != null && description.ServerCertificate.Length != 0)
      settings.ServerCertificate = Utils.ParseCertificateBlob(description.ServerCertificate);
    if (configuration != null)
      settings.CertificateValidator = configuration.CertificateValidator.GetChannelValidator();
    settings.NamespaceUris = messageContext.NamespaceUris;
    settings.Factory = messageContext.Factory;
    channel.Initialize(new Uri(description.EndpointUrl), settings);
    channel.Open();
    return channel;
  }
}
