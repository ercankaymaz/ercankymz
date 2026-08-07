// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiscoveryChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DiscoveryChannel : UaChannelBase<IDiscoveryChannel>, IDiscoveryChannel, IChannelBase
{
  public static ITransportChannel Create(
    Uri discoveryUrl,
    EndpointConfiguration endpointConfiguration,
    IServiceMessageContext messageContext,
    X509Certificate2 clientCertificate = null)
  {
    EndpointDescription description = new EndpointDescription()
    {
      EndpointUrl = discoveryUrl.OriginalString,
      SecurityMode = MessageSecurityMode.None,
      SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None"
    };
    description.Server.ApplicationUri = description.EndpointUrl;
    description.Server.ApplicationType = ApplicationType.DiscoveryServer;
    return UaChannelBase.CreateUaBinaryChannel((ApplicationConfiguration) null, description, endpointConfiguration, clientCertificate, messageContext);
  }

  public static ITransportChannel Create(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    EndpointConfiguration endpointConfiguration,
    IServiceMessageContext messageContext,
    X509Certificate2 clientCertificate = null)
  {
    EndpointDescription description = new EndpointDescription()
    {
      EndpointUrl = connection.EndpointUrl.OriginalString,
      SecurityMode = MessageSecurityMode.None,
      SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None"
    };
    description.Server.ApplicationUri = description.EndpointUrl;
    description.Server.ApplicationType = ApplicationType.DiscoveryServer;
    return UaChannelBase.CreateUaBinaryChannel(configuration, connection, description, endpointConfiguration, clientCertificate, (X509Certificate2Collection) null, messageContext);
  }

  public static ITransportChannel Create(
    ApplicationConfiguration configuration,
    Uri discoveryUrl,
    EndpointConfiguration endpointConfiguration,
    IServiceMessageContext messageContext,
    X509Certificate2 clientCertificate = null)
  {
    EndpointDescription description = new EndpointDescription()
    {
      EndpointUrl = discoveryUrl.OriginalString,
      SecurityMode = MessageSecurityMode.None,
      SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None"
    };
    description.Server.ApplicationUri = description.EndpointUrl;
    description.Server.ApplicationType = ApplicationType.DiscoveryServer;
    return UaChannelBase.CreateUaBinaryChannel(configuration, description, endpointConfiguration, clientCertificate, (X509Certificate2Collection) null, messageContext);
  }

  internal DiscoveryChannel()
  {
  }

  public FindServersResponseMessage FindServers(FindServersMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginFindServers(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndFindServers(result);
  }

  public IAsyncResult BeginFindServers(
    FindServersMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult servers = new UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (servers.Lock)
      servers.InnerResult = servers.Channel.BeginFindServers(request, new AsyncCallback(servers.OnOperationCompleted), (object) null);
    return (IAsyncResult) servers;
  }

  public FindServersResponseMessage EndFindServers(IAsyncResult result)
  {
    UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndFindServers(channelAsyncResult.InnerResult);
  }

  public Task<FindServersResponseMessage> FindServersAsync(FindServersMessage request)
  {
    return this.Channel.FindServersAsync(request);
  }

  public FindServersOnNetworkResponseMessage FindServersOnNetwork(
    FindServersOnNetworkMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginFindServersOnNetwork(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndFindServersOnNetwork(result);
  }

  public IAsyncResult BeginFindServersOnNetwork(
    FindServersOnNetworkMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult serversOnNetwork = new UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (serversOnNetwork.Lock)
      serversOnNetwork.InnerResult = serversOnNetwork.Channel.BeginFindServersOnNetwork(request, new AsyncCallback(serversOnNetwork.OnOperationCompleted), (object) null);
    return (IAsyncResult) serversOnNetwork;
  }

  public FindServersOnNetworkResponseMessage EndFindServersOnNetwork(IAsyncResult result)
  {
    UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndFindServersOnNetwork(channelAsyncResult.InnerResult);
  }

  public Task<FindServersOnNetworkResponseMessage> FindServersOnNetworkAsync(
    FindServersOnNetworkMessage request)
  {
    return this.Channel.FindServersOnNetworkAsync(request);
  }

  public GetEndpointsResponseMessage GetEndpoints(GetEndpointsMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginGetEndpoints(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndGetEndpoints(result);
  }

  public IAsyncResult BeginGetEndpoints(
    GetEndpointsMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult endpoints = new UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (endpoints.Lock)
      endpoints.InnerResult = endpoints.Channel.BeginGetEndpoints(request, new AsyncCallback(endpoints.OnOperationCompleted), (object) null);
    return (IAsyncResult) endpoints;
  }

  public GetEndpointsResponseMessage EndGetEndpoints(IAsyncResult result)
  {
    UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<IDiscoveryChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndGetEndpoints(channelAsyncResult.InnerResult);
  }

  public Task<GetEndpointsResponseMessage> GetEndpointsAsync(GetEndpointsMessage request)
  {
    return this.Channel.GetEndpointsAsync(request);
  }
}
