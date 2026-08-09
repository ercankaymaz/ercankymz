using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DiscoveryClient : ClientBase, IDiscoveryClientMethods
{
	public new IDiscoveryChannel InnerChannel => (IDiscoveryChannel)base.InnerChannel;

	public static DiscoveryClient Create(ApplicationConfiguration application, Uri discoveryUrl)
	{
		EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create();
		return new DiscoveryClient(DiscoveryChannel.Create(application, discoveryUrl, endpointConfiguration, new ServiceMessageContext()));
	}

	public static DiscoveryClient Create(ApplicationConfiguration application, Uri discoveryUrl, EndpointConfiguration configuration)
	{
		if (configuration == null)
		{
			configuration = EndpointConfiguration.Create();
		}
		return new DiscoveryClient(DiscoveryChannel.Create(application, discoveryUrl, configuration, application.CreateMessageContext()));
	}

	public static DiscoveryClient Create(ApplicationConfiguration application, ITransportWaitingConnection connection, EndpointConfiguration configuration)
	{
		if (configuration == null)
		{
			configuration = EndpointConfiguration.Create();
		}
		return new DiscoveryClient(DiscoveryChannel.Create(application, connection, configuration, application.CreateMessageContext()));
	}

	public static DiscoveryClient Create(Uri discoveryUrl)
	{
		return Create(discoveryUrl, null, null);
	}

	public static DiscoveryClient Create(Uri discoveryUrl, EndpointConfiguration configuration)
	{
		return Create(discoveryUrl, configuration, null);
	}

	public static DiscoveryClient Create(ITransportWaitingConnection connection, EndpointConfiguration configuration)
	{
		if (configuration == null)
		{
			configuration = EndpointConfiguration.Create();
		}
		return new DiscoveryClient(DiscoveryChannel.Create(null, connection, configuration, new ServiceMessageContext()));
	}

	public static DiscoveryClient Create(Uri discoveryUrl, EndpointConfiguration endpointConfiguration, ApplicationConfiguration applicationConfiguration)
	{
		if (endpointConfiguration == null)
		{
			endpointConfiguration = EndpointConfiguration.Create();
		}
		X509Certificate2 clientCertificate = null;
		try
		{
			clientCertificate = applicationConfiguration?.SecurityConfiguration?.ApplicationCertificate?.Find(needPrivateKey: true).Result;
		}
		catch
		{
		}
		return new DiscoveryClient(DiscoveryChannel.Create(applicationConfiguration, discoveryUrl, endpointConfiguration, new ServiceMessageContext(), clientCertificate));
	}

	public virtual EndpointDescriptionCollection GetEndpoints(StringCollection profileUris)
	{
		EndpointDescriptionCollection endpoints = null;
		GetEndpoints(null, base.Endpoint.EndpointUrl, null, profileUris, out endpoints);
		return PatchEndpointUrls(endpoints);
	}

	public virtual async Task<EndpointDescriptionCollection> GetEndpointsAsync(StringCollection profileUris, CancellationToken ct = default(CancellationToken))
	{
		return PatchEndpointUrls((await GetEndpointsAsync(null, base.Endpoint.EndpointUrl, null, profileUris, ct).ConfigureAwait(continueOnCapturedContext: false)).Endpoints);
	}

	public virtual ApplicationDescriptionCollection FindServers(StringCollection serverUris)
	{
		ApplicationDescriptionCollection servers = null;
		FindServers(null, base.Endpoint.EndpointUrl, null, serverUris, out servers);
		return servers;
	}

	public virtual async Task<ApplicationDescriptionCollection> FindServersAsync(StringCollection serverUris, CancellationToken ct = default(CancellationToken))
	{
		return (await FindServersAsync(null, base.Endpoint.EndpointUrl, null, serverUris, ct).ConfigureAwait(continueOnCapturedContext: false)).Servers;
	}

	public virtual ServerOnNetworkCollection FindServersOnNetwork(uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, out DateTime lastCounterResetTime)
	{
		ServerOnNetworkCollection servers = null;
		FindServersOnNetwork(null, startingRecordId, maxRecordsToReturn, serverCapabilityFilter, out lastCounterResetTime, out servers);
		return servers;
	}

	private EndpointDescriptionCollection PatchEndpointUrls(EndpointDescriptionCollection endpoints)
	{
		Uri uri = Utils.ParseUri(base.Endpoint.EndpointUrl);
		if (uri != null)
		{
			foreach (EndpointDescription endpoint in endpoints)
			{
				Uri uri2 = Utils.ParseUri(endpoint.EndpointUrl);
				if (uri2 == null)
				{
					Utils.LogWarning("Discovery endpoint contains invalid Url: {0}", endpoint.EndpointUrl);
					continue;
				}
				if (uri.Scheme == uri2.Scheme && uri.Port == uri2.Port)
				{
					UriBuilder uriBuilder = new UriBuilder(uri2);
					uriBuilder.Host = uri.DnsSafeHost;
					endpoint.EndpointUrl = uriBuilder.Uri.OriginalString;
				}
				if (endpoint.Server != null && endpoint.Server.DiscoveryUrls != null)
				{
					endpoint.Server.DiscoveryUrls.Clear();
					endpoint.Server.DiscoveryUrls.Add(base.Endpoint.EndpointUrl.ToString());
				}
			}
		}
		return endpoints;
	}

	public DiscoveryClient(ITransportChannel channel)
		: base(channel)
	{
	}

	public virtual ResponseHeader FindServers(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection serverUris, out ApplicationDescriptionCollection servers)
	{
		FindServersRequest findServersRequest = new FindServersRequest();
		FindServersResponse findServersResponse = null;
		findServersRequest.RequestHeader = requestHeader;
		findServersRequest.EndpointUrl = endpointUrl;
		findServersRequest.LocaleIds = localeIds;
		findServersRequest.ServerUris = serverUris;
		UpdateRequestHeader(findServersRequest, requestHeader == null, "FindServers");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(findServersRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			findServersResponse = (FindServersResponse)obj;
			servers = findServersResponse.Servers;
		}
		finally
		{
			RequestCompleted(findServersRequest, findServersResponse, "FindServers");
		}
		return findServersResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginFindServers(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection serverUris, AsyncCallback callback, object asyncState)
	{
		FindServersRequest findServersRequest = new FindServersRequest();
		findServersRequest.RequestHeader = requestHeader;
		findServersRequest.EndpointUrl = endpointUrl;
		findServersRequest.LocaleIds = localeIds;
		findServersRequest.ServerUris = serverUris;
		UpdateRequestHeader(findServersRequest, requestHeader == null, "FindServers");
		return base.TransportChannel.BeginSendRequest(findServersRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndFindServers(IAsyncResult result, out ApplicationDescriptionCollection servers)
	{
		FindServersResponse findServersResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			findServersResponse = (FindServersResponse)obj;
			servers = findServersResponse.Servers;
		}
		finally
		{
			RequestCompleted(null, findServersResponse, "FindServers");
		}
		return findServersResponse.ResponseHeader;
	}

	public virtual async Task<FindServersResponse> FindServersAsync(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection serverUris, CancellationToken ct)
	{
		FindServersRequest request = new FindServersRequest();
		FindServersResponse response = null;
		request.RequestHeader = requestHeader;
		request.EndpointUrl = endpointUrl;
		request.LocaleIds = localeIds;
		request.ServerUris = serverUris;
		UpdateRequestHeader(request, requestHeader == null, "FindServers");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (FindServersResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "FindServers");
		}
		return response;
	}

	public virtual ResponseHeader FindServersOnNetwork(RequestHeader requestHeader, uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, out DateTime lastCounterResetTime, out ServerOnNetworkCollection servers)
	{
		FindServersOnNetworkRequest findServersOnNetworkRequest = new FindServersOnNetworkRequest();
		FindServersOnNetworkResponse findServersOnNetworkResponse = null;
		findServersOnNetworkRequest.RequestHeader = requestHeader;
		findServersOnNetworkRequest.StartingRecordId = startingRecordId;
		findServersOnNetworkRequest.MaxRecordsToReturn = maxRecordsToReturn;
		findServersOnNetworkRequest.ServerCapabilityFilter = serverCapabilityFilter;
		UpdateRequestHeader(findServersOnNetworkRequest, requestHeader == null, "FindServersOnNetwork");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(findServersOnNetworkRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			findServersOnNetworkResponse = (FindServersOnNetworkResponse)obj;
			lastCounterResetTime = findServersOnNetworkResponse.LastCounterResetTime;
			servers = findServersOnNetworkResponse.Servers;
		}
		finally
		{
			RequestCompleted(findServersOnNetworkRequest, findServersOnNetworkResponse, "FindServersOnNetwork");
		}
		return findServersOnNetworkResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginFindServersOnNetwork(RequestHeader requestHeader, uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, AsyncCallback callback, object asyncState)
	{
		FindServersOnNetworkRequest findServersOnNetworkRequest = new FindServersOnNetworkRequest();
		findServersOnNetworkRequest.RequestHeader = requestHeader;
		findServersOnNetworkRequest.StartingRecordId = startingRecordId;
		findServersOnNetworkRequest.MaxRecordsToReturn = maxRecordsToReturn;
		findServersOnNetworkRequest.ServerCapabilityFilter = serverCapabilityFilter;
		UpdateRequestHeader(findServersOnNetworkRequest, requestHeader == null, "FindServersOnNetwork");
		return base.TransportChannel.BeginSendRequest(findServersOnNetworkRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndFindServersOnNetwork(IAsyncResult result, out DateTime lastCounterResetTime, out ServerOnNetworkCollection servers)
	{
		FindServersOnNetworkResponse findServersOnNetworkResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			findServersOnNetworkResponse = (FindServersOnNetworkResponse)obj;
			lastCounterResetTime = findServersOnNetworkResponse.LastCounterResetTime;
			servers = findServersOnNetworkResponse.Servers;
		}
		finally
		{
			RequestCompleted(null, findServersOnNetworkResponse, "FindServersOnNetwork");
		}
		return findServersOnNetworkResponse.ResponseHeader;
	}

	public virtual async Task<FindServersOnNetworkResponse> FindServersOnNetworkAsync(RequestHeader requestHeader, uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, CancellationToken ct)
	{
		FindServersOnNetworkRequest request = new FindServersOnNetworkRequest();
		FindServersOnNetworkResponse response = null;
		request.RequestHeader = requestHeader;
		request.StartingRecordId = startingRecordId;
		request.MaxRecordsToReturn = maxRecordsToReturn;
		request.ServerCapabilityFilter = serverCapabilityFilter;
		UpdateRequestHeader(request, requestHeader == null, "FindServersOnNetwork");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (FindServersOnNetworkResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "FindServersOnNetwork");
		}
		return response;
	}

	public virtual ResponseHeader GetEndpoints(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection profileUris, out EndpointDescriptionCollection endpoints)
	{
		GetEndpointsRequest getEndpointsRequest = new GetEndpointsRequest();
		GetEndpointsResponse getEndpointsResponse = null;
		getEndpointsRequest.RequestHeader = requestHeader;
		getEndpointsRequest.EndpointUrl = endpointUrl;
		getEndpointsRequest.LocaleIds = localeIds;
		getEndpointsRequest.ProfileUris = profileUris;
		UpdateRequestHeader(getEndpointsRequest, requestHeader == null, "GetEndpoints");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(getEndpointsRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			getEndpointsResponse = (GetEndpointsResponse)obj;
			endpoints = getEndpointsResponse.Endpoints;
		}
		finally
		{
			RequestCompleted(getEndpointsRequest, getEndpointsResponse, "GetEndpoints");
		}
		return getEndpointsResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginGetEndpoints(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection profileUris, AsyncCallback callback, object asyncState)
	{
		GetEndpointsRequest getEndpointsRequest = new GetEndpointsRequest();
		getEndpointsRequest.RequestHeader = requestHeader;
		getEndpointsRequest.EndpointUrl = endpointUrl;
		getEndpointsRequest.LocaleIds = localeIds;
		getEndpointsRequest.ProfileUris = profileUris;
		UpdateRequestHeader(getEndpointsRequest, requestHeader == null, "GetEndpoints");
		return base.TransportChannel.BeginSendRequest(getEndpointsRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndGetEndpoints(IAsyncResult result, out EndpointDescriptionCollection endpoints)
	{
		GetEndpointsResponse getEndpointsResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			getEndpointsResponse = (GetEndpointsResponse)obj;
			endpoints = getEndpointsResponse.Endpoints;
		}
		finally
		{
			RequestCompleted(null, getEndpointsResponse, "GetEndpoints");
		}
		return getEndpointsResponse.ResponseHeader;
	}

	public virtual async Task<GetEndpointsResponse> GetEndpointsAsync(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection profileUris, CancellationToken ct)
	{
		GetEndpointsRequest request = new GetEndpointsRequest();
		GetEndpointsResponse response = null;
		request.RequestHeader = requestHeader;
		request.EndpointUrl = endpointUrl;
		request.LocaleIds = localeIds;
		request.ProfileUris = profileUris;
		UpdateRequestHeader(request, requestHeader == null, "GetEndpoints");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (GetEndpointsResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "GetEndpoints");
		}
		return response;
	}
}
