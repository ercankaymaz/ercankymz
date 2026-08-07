// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiscoveryClient
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DiscoveryClient(ITransportChannel channel) : ClientBase(channel), IDiscoveryClientMethods
{
  public static DiscoveryClient Create(ApplicationConfiguration application, Uri discoveryUrl)
  {
    EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create();
    return new DiscoveryClient(DiscoveryChannel.Create(application, discoveryUrl, endpointConfiguration, (IServiceMessageContext) new ServiceMessageContext()));
  }

  public static DiscoveryClient Create(
    ApplicationConfiguration application,
    Uri discoveryUrl,
    EndpointConfiguration configuration)
  {
    if (configuration == null)
      configuration = EndpointConfiguration.Create();
    return new DiscoveryClient(DiscoveryChannel.Create(application, discoveryUrl, configuration, (IServiceMessageContext) application.CreateMessageContext()));
  }

  public static DiscoveryClient Create(
    ApplicationConfiguration application,
    ITransportWaitingConnection connection,
    EndpointConfiguration configuration)
  {
    if (configuration == null)
      configuration = EndpointConfiguration.Create();
    return new DiscoveryClient(DiscoveryChannel.Create(application, connection, configuration, (IServiceMessageContext) application.CreateMessageContext()));
  }

  public static DiscoveryClient Create(Uri discoveryUrl)
  {
    return DiscoveryClient.Create(discoveryUrl, (EndpointConfiguration) null, (ApplicationConfiguration) null);
  }

  public static DiscoveryClient Create(Uri discoveryUrl, EndpointConfiguration configuration)
  {
    return DiscoveryClient.Create(discoveryUrl, configuration, (ApplicationConfiguration) null);
  }

  public static DiscoveryClient Create(
    ITransportWaitingConnection connection,
    EndpointConfiguration configuration)
  {
    if (configuration == null)
      configuration = EndpointConfiguration.Create();
    return new DiscoveryClient(DiscoveryChannel.Create((ApplicationConfiguration) null, connection, configuration, (IServiceMessageContext) new ServiceMessageContext()));
  }

  public static DiscoveryClient Create(
    Uri discoveryUrl,
    EndpointConfiguration endpointConfiguration,
    ApplicationConfiguration applicationConfiguration)
  {
    if (endpointConfiguration == null)
      endpointConfiguration = EndpointConfiguration.Create();
    X509Certificate2 clientCertificate = (X509Certificate2) null;
    try
    {
      clientCertificate = applicationConfiguration?.SecurityConfiguration?.ApplicationCertificate?.Find(true).Result;
    }
    catch
    {
    }
    return new DiscoveryClient(DiscoveryChannel.Create(applicationConfiguration, discoveryUrl, endpointConfiguration, (IServiceMessageContext) new ServiceMessageContext(), clientCertificate));
  }

  public virtual EndpointDescriptionCollection GetEndpoints(StringCollection profileUris)
  {
    EndpointDescriptionCollection endpoints = (EndpointDescriptionCollection) null;
    this.GetEndpoints((RequestHeader) null, this.Endpoint.EndpointUrl, (StringCollection) null, profileUris, out endpoints);
    return this.PatchEndpointUrls(endpoints);
  }

  public virtual async Task<EndpointDescriptionCollection> GetEndpointsAsync(
    StringCollection profileUris,
    CancellationToken ct = default (CancellationToken))
  {
    DiscoveryClient discoveryClient = this;
    // ISSUE: explicit non-virtual call
    GetEndpointsResponse endpointsResponse = await discoveryClient.GetEndpointsAsync((RequestHeader) null, __nonvirtual (discoveryClient.Endpoint).EndpointUrl, (StringCollection) null, profileUris, ct).ConfigureAwait(false);
    return discoveryClient.PatchEndpointUrls(endpointsResponse.Endpoints);
  }

  public virtual ApplicationDescriptionCollection FindServers(StringCollection serverUris)
  {
    ApplicationDescriptionCollection servers = (ApplicationDescriptionCollection) null;
    this.FindServers((RequestHeader) null, this.Endpoint.EndpointUrl, (StringCollection) null, serverUris, out servers);
    return servers;
  }

  public virtual async Task<ApplicationDescriptionCollection> FindServersAsync(
    StringCollection serverUris,
    CancellationToken ct = default (CancellationToken))
  {
    DiscoveryClient discoveryClient = this;
    // ISSUE: explicit non-virtual call
    return (await discoveryClient.FindServersAsync((RequestHeader) null, __nonvirtual (discoveryClient.Endpoint).EndpointUrl, (StringCollection) null, serverUris, ct).ConfigureAwait(false)).Servers;
  }

  public virtual ServerOnNetworkCollection FindServersOnNetwork(
    uint startingRecordId,
    uint maxRecordsToReturn,
    StringCollection serverCapabilityFilter,
    out DateTime lastCounterResetTime)
  {
    ServerOnNetworkCollection servers = (ServerOnNetworkCollection) null;
    this.FindServersOnNetwork((RequestHeader) null, startingRecordId, maxRecordsToReturn, serverCapabilityFilter, out lastCounterResetTime, out servers);
    return servers;
  }

  private EndpointDescriptionCollection PatchEndpointUrls(EndpointDescriptionCollection endpoints)
  {
    Uri uri1 = Utils.ParseUri(this.Endpoint.EndpointUrl);
    if (uri1 != (Uri) null)
    {
      foreach (EndpointDescription endpoint in (List<EndpointDescription>) endpoints)
      {
        Uri uri2 = Utils.ParseUri(endpoint.EndpointUrl);
        if (uri2 == (Uri) null)
        {
          Utils.LogWarning("Discovery endpoint contains invalid Url: {0}", (object) endpoint.EndpointUrl);
        }
        else
        {
          if (uri1.Scheme == uri2.Scheme && uri1.Port == uri2.Port)
            endpoint.EndpointUrl = new UriBuilder(uri2)
            {
              Host = uri1.DnsSafeHost
            }.Uri.OriginalString;
          if (endpoint.Server != null && endpoint.Server.DiscoveryUrls != null)
          {
            endpoint.Server.DiscoveryUrls.Clear();
            endpoint.Server.DiscoveryUrls.Add(this.Endpoint.EndpointUrl.ToString());
          }
        }
      }
    }
    return endpoints;
  }

  public IDiscoveryChannel InnerChannel => (IDiscoveryChannel) base.InnerChannel;

  public virtual ResponseHeader FindServers(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection serverUris,
    out ApplicationDescriptionCollection servers)
  {
    FindServersRequest request = new FindServersRequest();
    FindServersResponse response = (FindServersResponse) null;
    request.RequestHeader = requestHeader;
    request.EndpointUrl = endpointUrl;
    request.LocaleIds = localeIds;
    request.ServerUris = serverUris;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (FindServers));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (FindServersResponse) serviceResponse;
      servers = response.Servers;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (FindServers));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginFindServers(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection serverUris,
    AsyncCallback callback,
    object asyncState)
  {
    FindServersRequest request = new FindServersRequest();
    request.RequestHeader = requestHeader;
    request.EndpointUrl = endpointUrl;
    request.LocaleIds = localeIds;
    request.ServerUris = serverUris;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "FindServers");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndFindServers(
    IAsyncResult result,
    out ApplicationDescriptionCollection servers)
  {
    FindServersResponse response = (FindServersResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (FindServersResponse) serviceResponse;
      servers = response.Servers;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "FindServers");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<FindServersResponse> FindServersAsync(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection serverUris,
    CancellationToken ct)
  {
    DiscoveryClient discoveryClient = this;
    FindServersRequest request = new FindServersRequest();
    FindServersResponse response = (FindServersResponse) null;
    request.RequestHeader = requestHeader;
    request.EndpointUrl = endpointUrl;
    request.LocaleIds = localeIds;
    request.ServerUris = serverUris;
    discoveryClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "FindServers");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (discoveryClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (FindServersResponse) serviceResponse;
    }
    finally
    {
      discoveryClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "FindServers");
    }
    FindServersResponse serversAsync = response;
    request = (FindServersRequest) null;
    response = (FindServersResponse) null;
    return serversAsync;
  }

  public virtual ResponseHeader FindServersOnNetwork(
    RequestHeader requestHeader,
    uint startingRecordId,
    uint maxRecordsToReturn,
    StringCollection serverCapabilityFilter,
    out DateTime lastCounterResetTime,
    out ServerOnNetworkCollection servers)
  {
    FindServersOnNetworkRequest request = new FindServersOnNetworkRequest();
    FindServersOnNetworkResponse response = (FindServersOnNetworkResponse) null;
    request.RequestHeader = requestHeader;
    request.StartingRecordId = startingRecordId;
    request.MaxRecordsToReturn = maxRecordsToReturn;
    request.ServerCapabilityFilter = serverCapabilityFilter;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (FindServersOnNetwork));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (FindServersOnNetworkResponse) serviceResponse;
      lastCounterResetTime = response.LastCounterResetTime;
      servers = response.Servers;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (FindServersOnNetwork));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginFindServersOnNetwork(
    RequestHeader requestHeader,
    uint startingRecordId,
    uint maxRecordsToReturn,
    StringCollection serverCapabilityFilter,
    AsyncCallback callback,
    object asyncState)
  {
    FindServersOnNetworkRequest request = new FindServersOnNetworkRequest();
    request.RequestHeader = requestHeader;
    request.StartingRecordId = startingRecordId;
    request.MaxRecordsToReturn = maxRecordsToReturn;
    request.ServerCapabilityFilter = serverCapabilityFilter;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "FindServersOnNetwork");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndFindServersOnNetwork(
    IAsyncResult result,
    out DateTime lastCounterResetTime,
    out ServerOnNetworkCollection servers)
  {
    FindServersOnNetworkResponse response = (FindServersOnNetworkResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (FindServersOnNetworkResponse) serviceResponse;
      lastCounterResetTime = response.LastCounterResetTime;
      servers = response.Servers;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "FindServersOnNetwork");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<FindServersOnNetworkResponse> FindServersOnNetworkAsync(
    RequestHeader requestHeader,
    uint startingRecordId,
    uint maxRecordsToReturn,
    StringCollection serverCapabilityFilter,
    CancellationToken ct)
  {
    DiscoveryClient discoveryClient = this;
    FindServersOnNetworkRequest request = new FindServersOnNetworkRequest();
    FindServersOnNetworkResponse response = (FindServersOnNetworkResponse) null;
    request.RequestHeader = requestHeader;
    request.StartingRecordId = startingRecordId;
    request.MaxRecordsToReturn = maxRecordsToReturn;
    request.ServerCapabilityFilter = serverCapabilityFilter;
    discoveryClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "FindServersOnNetwork");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (discoveryClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (FindServersOnNetworkResponse) serviceResponse;
    }
    finally
    {
      discoveryClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "FindServersOnNetwork");
    }
    FindServersOnNetworkResponse serversOnNetworkAsync = response;
    request = (FindServersOnNetworkRequest) null;
    response = (FindServersOnNetworkResponse) null;
    return serversOnNetworkAsync;
  }

  public virtual ResponseHeader GetEndpoints(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection profileUris,
    out EndpointDescriptionCollection endpoints)
  {
    GetEndpointsRequest request = new GetEndpointsRequest();
    GetEndpointsResponse response = (GetEndpointsResponse) null;
    request.RequestHeader = requestHeader;
    request.EndpointUrl = endpointUrl;
    request.LocaleIds = localeIds;
    request.ProfileUris = profileUris;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (GetEndpoints));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (GetEndpointsResponse) serviceResponse;
      endpoints = response.Endpoints;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (GetEndpoints));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginGetEndpoints(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection profileUris,
    AsyncCallback callback,
    object asyncState)
  {
    GetEndpointsRequest request = new GetEndpointsRequest();
    request.RequestHeader = requestHeader;
    request.EndpointUrl = endpointUrl;
    request.LocaleIds = localeIds;
    request.ProfileUris = profileUris;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "GetEndpoints");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndGetEndpoints(
    IAsyncResult result,
    out EndpointDescriptionCollection endpoints)
  {
    GetEndpointsResponse response = (GetEndpointsResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (GetEndpointsResponse) serviceResponse;
      endpoints = response.Endpoints;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "GetEndpoints");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<GetEndpointsResponse> GetEndpointsAsync(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection profileUris,
    CancellationToken ct)
  {
    DiscoveryClient discoveryClient = this;
    GetEndpointsRequest request = new GetEndpointsRequest();
    GetEndpointsResponse response = (GetEndpointsResponse) null;
    request.RequestHeader = requestHeader;
    request.EndpointUrl = endpointUrl;
    request.LocaleIds = localeIds;
    request.ProfileUris = profileUris;
    discoveryClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "GetEndpoints");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (discoveryClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (GetEndpointsResponse) serviceResponse;
    }
    finally
    {
      discoveryClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "GetEndpoints");
    }
    GetEndpointsResponse endpointsAsync = response;
    request = (GetEndpointsRequest) null;
    response = (GetEndpointsResponse) null;
    return endpointsAsync;
  }
}
