using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DiscoveryEndpoint : EndpointBase, IDiscoveryEndpoint, IEndpointBase, IRegistrationEndpoint
{
	protected IDiscoveryServer ServerInstance
	{
		get
		{
			if (ServiceResult.IsBad(base.ServerError))
			{
				throw new ServiceResultException(base.ServerError);
			}
			return base.ServerForContext as IDiscoveryServer;
		}
	}

	public DiscoveryEndpoint()
	{
		CreateKnownTypes();
	}

	public DiscoveryEndpoint(IServiceHostBase host)
		: base(host)
	{
		CreateKnownTypes();
	}

	public DiscoveryEndpoint(ServerBase server)
		: base(server)
	{
		CreateKnownTypes();
	}

	public IServiceResponse FindServers(IServiceRequest incoming)
	{
		FindServersResponse findServersResponse = null;
		try
		{
			OnRequestReceived(incoming);
			FindServersRequest findServersRequest = (FindServersRequest)incoming;
			ApplicationDescriptionCollection servers = null;
			findServersResponse = new FindServersResponse();
			findServersResponse.ResponseHeader = ServerInstance.FindServers(findServersRequest.RequestHeader, findServersRequest.EndpointUrl, findServersRequest.LocaleIds, findServersRequest.ServerUris, out servers);
			findServersResponse.Servers = servers;
		}
		finally
		{
			OnResponseSent(findServersResponse);
		}
		return findServersResponse;
	}

	public virtual IAsyncResult BeginFindServers(FindServersMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.FindServersRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.FindServersRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.FindServersRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual FindServersResponseMessage EndFindServers(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new FindServersResponseMessage((FindServersResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse FindServersOnNetwork(IServiceRequest incoming)
	{
		FindServersOnNetworkResponse findServersOnNetworkResponse = null;
		try
		{
			OnRequestReceived(incoming);
			FindServersOnNetworkRequest findServersOnNetworkRequest = (FindServersOnNetworkRequest)incoming;
			DateTime lastCounterResetTime = DateTime.MinValue;
			ServerOnNetworkCollection servers = null;
			findServersOnNetworkResponse = new FindServersOnNetworkResponse();
			findServersOnNetworkResponse.ResponseHeader = ServerInstance.FindServersOnNetwork(findServersOnNetworkRequest.RequestHeader, findServersOnNetworkRequest.StartingRecordId, findServersOnNetworkRequest.MaxRecordsToReturn, findServersOnNetworkRequest.ServerCapabilityFilter, out lastCounterResetTime, out servers);
			findServersOnNetworkResponse.LastCounterResetTime = lastCounterResetTime;
			findServersOnNetworkResponse.Servers = servers;
		}
		finally
		{
			OnResponseSent(findServersOnNetworkResponse);
		}
		return findServersOnNetworkResponse;
	}

	public virtual IAsyncResult BeginFindServersOnNetwork(FindServersOnNetworkMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.FindServersOnNetworkRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.FindServersOnNetworkRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.FindServersOnNetworkRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual FindServersOnNetworkResponseMessage EndFindServersOnNetwork(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new FindServersOnNetworkResponseMessage((FindServersOnNetworkResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse GetEndpoints(IServiceRequest incoming)
	{
		GetEndpointsResponse getEndpointsResponse = null;
		try
		{
			OnRequestReceived(incoming);
			GetEndpointsRequest getEndpointsRequest = (GetEndpointsRequest)incoming;
			EndpointDescriptionCollection endpoints = null;
			getEndpointsResponse = new GetEndpointsResponse();
			getEndpointsResponse.ResponseHeader = ServerInstance.GetEndpoints(getEndpointsRequest.RequestHeader, getEndpointsRequest.EndpointUrl, getEndpointsRequest.LocaleIds, getEndpointsRequest.ProfileUris, out endpoints);
			getEndpointsResponse.Endpoints = endpoints;
		}
		finally
		{
			OnResponseSent(getEndpointsResponse);
		}
		return getEndpointsResponse;
	}

	public virtual IAsyncResult BeginGetEndpoints(GetEndpointsMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.GetEndpointsRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.GetEndpointsRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.GetEndpointsRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual GetEndpointsResponseMessage EndGetEndpoints(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new GetEndpointsResponseMessage((GetEndpointsResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse RegisterServer(IServiceRequest incoming)
	{
		RegisterServerResponse registerServerResponse = null;
		try
		{
			OnRequestReceived(incoming);
			RegisterServerRequest registerServerRequest = (RegisterServerRequest)incoming;
			registerServerResponse = new RegisterServerResponse();
			registerServerResponse.ResponseHeader = ServerInstance.RegisterServer(registerServerRequest.RequestHeader, registerServerRequest.Server);
		}
		finally
		{
			OnResponseSent(registerServerResponse);
		}
		return registerServerResponse;
	}

	public virtual IAsyncResult BeginRegisterServer(RegisterServerMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.RegisterServerRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.RegisterServerRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.RegisterServerRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual RegisterServerResponseMessage EndRegisterServer(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new RegisterServerResponseMessage((RegisterServerResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse RegisterServer2(IServiceRequest incoming)
	{
		RegisterServer2Response registerServer2Response = null;
		try
		{
			OnRequestReceived(incoming);
			RegisterServer2Request registerServer2Request = (RegisterServer2Request)incoming;
			StatusCodeCollection configurationResults = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			registerServer2Response = new RegisterServer2Response();
			registerServer2Response.ResponseHeader = ServerInstance.RegisterServer2(registerServer2Request.RequestHeader, registerServer2Request.Server, registerServer2Request.DiscoveryConfiguration, out configurationResults, out diagnosticInfos);
			registerServer2Response.ConfigurationResults = configurationResults;
			registerServer2Response.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(registerServer2Response);
		}
		return registerServer2Response;
	}

	public virtual IAsyncResult BeginRegisterServer2(RegisterServer2Message message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.RegisterServer2Request);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.RegisterServer2Request);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.RegisterServer2Request, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual RegisterServer2ResponseMessage EndRegisterServer2(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new RegisterServer2ResponseMessage((RegisterServer2Response)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	protected virtual void CreateKnownTypes()
	{
		base.SupportedServices.Add(DataTypeIds.FindServersRequest, new ServiceDefinition(typeof(FindServersRequest), FindServers));
		base.SupportedServices.Add(DataTypeIds.FindServersOnNetworkRequest, new ServiceDefinition(typeof(FindServersOnNetworkRequest), FindServersOnNetwork));
		base.SupportedServices.Add(DataTypeIds.GetEndpointsRequest, new ServiceDefinition(typeof(GetEndpointsRequest), GetEndpoints));
		base.SupportedServices.Add(DataTypeIds.RegisterServerRequest, new ServiceDefinition(typeof(RegisterServerRequest), RegisterServer));
		base.SupportedServices.Add(DataTypeIds.RegisterServer2Request, new ServiceDefinition(typeof(RegisterServer2Request), RegisterServer2));
	}
}
