using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionEndpoint : EndpointBase, ISessionEndpoint, IEndpointBase, IDiscoveryEndpoint
{
	protected ISessionServer ServerInstance
	{
		get
		{
			if (ServiceResult.IsBad(base.ServerError))
			{
				throw new ServiceResultException(base.ServerError);
			}
			return base.ServerForContext as ISessionServer;
		}
	}

	public SessionEndpoint()
	{
		CreateKnownTypes();
	}

	public SessionEndpoint(IServiceHostBase host)
		: base(host)
	{
		CreateKnownTypes();
	}

	public SessionEndpoint(ServerBase server)
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

	public IServiceResponse CreateSession(IServiceRequest incoming)
	{
		CreateSessionResponse createSessionResponse = null;
		try
		{
			OnRequestReceived(incoming);
			CreateSessionRequest createSessionRequest = (CreateSessionRequest)incoming;
			NodeId sessionId = null;
			NodeId authenticationToken = null;
			double revisedSessionTimeout = 0.0;
			byte[] serverNonce = null;
			byte[] serverCertificate = null;
			EndpointDescriptionCollection serverEndpoints = null;
			SignedSoftwareCertificateCollection serverSoftwareCertificates = null;
			SignatureData serverSignature = null;
			uint maxRequestMessageSize = 0u;
			createSessionResponse = new CreateSessionResponse();
			createSessionResponse.ResponseHeader = ServerInstance.CreateSession(createSessionRequest.RequestHeader, createSessionRequest.ClientDescription, createSessionRequest.ServerUri, createSessionRequest.EndpointUrl, createSessionRequest.SessionName, createSessionRequest.ClientNonce, createSessionRequest.ClientCertificate, createSessionRequest.RequestedSessionTimeout, createSessionRequest.MaxResponseMessageSize, out sessionId, out authenticationToken, out revisedSessionTimeout, out serverNonce, out serverCertificate, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out maxRequestMessageSize);
			createSessionResponse.SessionId = sessionId;
			createSessionResponse.AuthenticationToken = authenticationToken;
			createSessionResponse.RevisedSessionTimeout = revisedSessionTimeout;
			createSessionResponse.ServerNonce = serverNonce;
			createSessionResponse.ServerCertificate = serverCertificate;
			createSessionResponse.ServerEndpoints = serverEndpoints;
			createSessionResponse.ServerSoftwareCertificates = serverSoftwareCertificates;
			createSessionResponse.ServerSignature = serverSignature;
			createSessionResponse.MaxRequestMessageSize = maxRequestMessageSize;
		}
		finally
		{
			OnResponseSent(createSessionResponse);
		}
		return createSessionResponse;
	}

	public virtual IAsyncResult BeginCreateSession(CreateSessionMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.CreateSessionRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.CreateSessionRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.CreateSessionRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual CreateSessionResponseMessage EndCreateSession(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new CreateSessionResponseMessage((CreateSessionResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse ActivateSession(IServiceRequest incoming)
	{
		ActivateSessionResponse activateSessionResponse = null;
		try
		{
			OnRequestReceived(incoming);
			ActivateSessionRequest activateSessionRequest = (ActivateSessionRequest)incoming;
			byte[] serverNonce = null;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			activateSessionResponse = new ActivateSessionResponse();
			activateSessionResponse.ResponseHeader = ServerInstance.ActivateSession(activateSessionRequest.RequestHeader, activateSessionRequest.ClientSignature, activateSessionRequest.ClientSoftwareCertificates, activateSessionRequest.LocaleIds, activateSessionRequest.UserIdentityToken, activateSessionRequest.UserTokenSignature, out serverNonce, out results, out diagnosticInfos);
			activateSessionResponse.ServerNonce = serverNonce;
			activateSessionResponse.Results = results;
			activateSessionResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(activateSessionResponse);
		}
		return activateSessionResponse;
	}

	public virtual IAsyncResult BeginActivateSession(ActivateSessionMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.ActivateSessionRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.ActivateSessionRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.ActivateSessionRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual ActivateSessionResponseMessage EndActivateSession(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new ActivateSessionResponseMessage((ActivateSessionResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse CloseSession(IServiceRequest incoming)
	{
		CloseSessionResponse closeSessionResponse = null;
		try
		{
			OnRequestReceived(incoming);
			CloseSessionRequest closeSessionRequest = (CloseSessionRequest)incoming;
			closeSessionResponse = new CloseSessionResponse();
			closeSessionResponse.ResponseHeader = ServerInstance.CloseSession(closeSessionRequest.RequestHeader, closeSessionRequest.DeleteSubscriptions);
		}
		finally
		{
			OnResponseSent(closeSessionResponse);
		}
		return closeSessionResponse;
	}

	public virtual IAsyncResult BeginCloseSession(CloseSessionMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.CloseSessionRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.CloseSessionRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.CloseSessionRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual CloseSessionResponseMessage EndCloseSession(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new CloseSessionResponseMessage((CloseSessionResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse Cancel(IServiceRequest incoming)
	{
		CancelResponse cancelResponse = null;
		try
		{
			OnRequestReceived(incoming);
			CancelRequest cancelRequest = (CancelRequest)incoming;
			uint cancelCount = 0u;
			cancelResponse = new CancelResponse();
			cancelResponse.ResponseHeader = ServerInstance.Cancel(cancelRequest.RequestHeader, cancelRequest.RequestHandle, out cancelCount);
			cancelResponse.CancelCount = cancelCount;
		}
		finally
		{
			OnResponseSent(cancelResponse);
		}
		return cancelResponse;
	}

	public virtual IAsyncResult BeginCancel(CancelMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.CancelRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.CancelRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.CancelRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual CancelResponseMessage EndCancel(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new CancelResponseMessage((CancelResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse AddNodes(IServiceRequest incoming)
	{
		AddNodesResponse addNodesResponse = null;
		try
		{
			OnRequestReceived(incoming);
			AddNodesRequest addNodesRequest = (AddNodesRequest)incoming;
			AddNodesResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			addNodesResponse = new AddNodesResponse();
			addNodesResponse.ResponseHeader = ServerInstance.AddNodes(addNodesRequest.RequestHeader, addNodesRequest.NodesToAdd, out results, out diagnosticInfos);
			addNodesResponse.Results = results;
			addNodesResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(addNodesResponse);
		}
		return addNodesResponse;
	}

	public virtual IAsyncResult BeginAddNodes(AddNodesMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.AddNodesRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.AddNodesRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.AddNodesRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual AddNodesResponseMessage EndAddNodes(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new AddNodesResponseMessage((AddNodesResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse AddReferences(IServiceRequest incoming)
	{
		AddReferencesResponse addReferencesResponse = null;
		try
		{
			OnRequestReceived(incoming);
			AddReferencesRequest addReferencesRequest = (AddReferencesRequest)incoming;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			addReferencesResponse = new AddReferencesResponse();
			addReferencesResponse.ResponseHeader = ServerInstance.AddReferences(addReferencesRequest.RequestHeader, addReferencesRequest.ReferencesToAdd, out results, out diagnosticInfos);
			addReferencesResponse.Results = results;
			addReferencesResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(addReferencesResponse);
		}
		return addReferencesResponse;
	}

	public virtual IAsyncResult BeginAddReferences(AddReferencesMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.AddReferencesRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.AddReferencesRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.AddReferencesRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual AddReferencesResponseMessage EndAddReferences(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new AddReferencesResponseMessage((AddReferencesResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse DeleteNodes(IServiceRequest incoming)
	{
		DeleteNodesResponse deleteNodesResponse = null;
		try
		{
			OnRequestReceived(incoming);
			DeleteNodesRequest deleteNodesRequest = (DeleteNodesRequest)incoming;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			deleteNodesResponse = new DeleteNodesResponse();
			deleteNodesResponse.ResponseHeader = ServerInstance.DeleteNodes(deleteNodesRequest.RequestHeader, deleteNodesRequest.NodesToDelete, out results, out diagnosticInfos);
			deleteNodesResponse.Results = results;
			deleteNodesResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(deleteNodesResponse);
		}
		return deleteNodesResponse;
	}

	public virtual IAsyncResult BeginDeleteNodes(DeleteNodesMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.DeleteNodesRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.DeleteNodesRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.DeleteNodesRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual DeleteNodesResponseMessage EndDeleteNodes(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new DeleteNodesResponseMessage((DeleteNodesResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse DeleteReferences(IServiceRequest incoming)
	{
		DeleteReferencesResponse deleteReferencesResponse = null;
		try
		{
			OnRequestReceived(incoming);
			DeleteReferencesRequest deleteReferencesRequest = (DeleteReferencesRequest)incoming;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			deleteReferencesResponse = new DeleteReferencesResponse();
			deleteReferencesResponse.ResponseHeader = ServerInstance.DeleteReferences(deleteReferencesRequest.RequestHeader, deleteReferencesRequest.ReferencesToDelete, out results, out diagnosticInfos);
			deleteReferencesResponse.Results = results;
			deleteReferencesResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(deleteReferencesResponse);
		}
		return deleteReferencesResponse;
	}

	public virtual IAsyncResult BeginDeleteReferences(DeleteReferencesMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.DeleteReferencesRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.DeleteReferencesRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.DeleteReferencesRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual DeleteReferencesResponseMessage EndDeleteReferences(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new DeleteReferencesResponseMessage((DeleteReferencesResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse Browse(IServiceRequest incoming)
	{
		BrowseResponse browseResponse = null;
		try
		{
			OnRequestReceived(incoming);
			BrowseRequest browseRequest = (BrowseRequest)incoming;
			BrowseResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			browseResponse = new BrowseResponse();
			browseResponse.ResponseHeader = ServerInstance.Browse(browseRequest.RequestHeader, browseRequest.View, browseRequest.RequestedMaxReferencesPerNode, browseRequest.NodesToBrowse, out results, out diagnosticInfos);
			browseResponse.Results = results;
			browseResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(browseResponse);
		}
		return browseResponse;
	}

	public virtual IAsyncResult BeginBrowse(BrowseMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.BrowseRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.BrowseRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.BrowseRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual BrowseResponseMessage EndBrowse(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new BrowseResponseMessage((BrowseResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse BrowseNext(IServiceRequest incoming)
	{
		BrowseNextResponse browseNextResponse = null;
		try
		{
			OnRequestReceived(incoming);
			BrowseNextRequest browseNextRequest = (BrowseNextRequest)incoming;
			BrowseResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			browseNextResponse = new BrowseNextResponse();
			browseNextResponse.ResponseHeader = ServerInstance.BrowseNext(browseNextRequest.RequestHeader, browseNextRequest.ReleaseContinuationPoints, browseNextRequest.ContinuationPoints, out results, out diagnosticInfos);
			browseNextResponse.Results = results;
			browseNextResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(browseNextResponse);
		}
		return browseNextResponse;
	}

	public virtual IAsyncResult BeginBrowseNext(BrowseNextMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.BrowseNextRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.BrowseNextRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.BrowseNextRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual BrowseNextResponseMessage EndBrowseNext(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new BrowseNextResponseMessage((BrowseNextResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse TranslateBrowsePathsToNodeIds(IServiceRequest incoming)
	{
		TranslateBrowsePathsToNodeIdsResponse translateBrowsePathsToNodeIdsResponse = null;
		try
		{
			OnRequestReceived(incoming);
			TranslateBrowsePathsToNodeIdsRequest translateBrowsePathsToNodeIdsRequest = (TranslateBrowsePathsToNodeIdsRequest)incoming;
			BrowsePathResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			translateBrowsePathsToNodeIdsResponse = new TranslateBrowsePathsToNodeIdsResponse();
			translateBrowsePathsToNodeIdsResponse.ResponseHeader = ServerInstance.TranslateBrowsePathsToNodeIds(translateBrowsePathsToNodeIdsRequest.RequestHeader, translateBrowsePathsToNodeIdsRequest.BrowsePaths, out results, out diagnosticInfos);
			translateBrowsePathsToNodeIdsResponse.Results = results;
			translateBrowsePathsToNodeIdsResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(translateBrowsePathsToNodeIdsResponse);
		}
		return translateBrowsePathsToNodeIdsResponse;
	}

	public virtual IAsyncResult BeginTranslateBrowsePathsToNodeIds(TranslateBrowsePathsToNodeIdsMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.TranslateBrowsePathsToNodeIdsRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.TranslateBrowsePathsToNodeIdsRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.TranslateBrowsePathsToNodeIdsRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual TranslateBrowsePathsToNodeIdsResponseMessage EndTranslateBrowsePathsToNodeIds(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new TranslateBrowsePathsToNodeIdsResponseMessage((TranslateBrowsePathsToNodeIdsResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse RegisterNodes(IServiceRequest incoming)
	{
		RegisterNodesResponse registerNodesResponse = null;
		try
		{
			OnRequestReceived(incoming);
			RegisterNodesRequest registerNodesRequest = (RegisterNodesRequest)incoming;
			NodeIdCollection registeredNodeIds = null;
			registerNodesResponse = new RegisterNodesResponse();
			registerNodesResponse.ResponseHeader = ServerInstance.RegisterNodes(registerNodesRequest.RequestHeader, registerNodesRequest.NodesToRegister, out registeredNodeIds);
			registerNodesResponse.RegisteredNodeIds = registeredNodeIds;
		}
		finally
		{
			OnResponseSent(registerNodesResponse);
		}
		return registerNodesResponse;
	}

	public virtual IAsyncResult BeginRegisterNodes(RegisterNodesMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.RegisterNodesRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.RegisterNodesRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.RegisterNodesRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual RegisterNodesResponseMessage EndRegisterNodes(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new RegisterNodesResponseMessage((RegisterNodesResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse UnregisterNodes(IServiceRequest incoming)
	{
		UnregisterNodesResponse unregisterNodesResponse = null;
		try
		{
			OnRequestReceived(incoming);
			UnregisterNodesRequest unregisterNodesRequest = (UnregisterNodesRequest)incoming;
			unregisterNodesResponse = new UnregisterNodesResponse();
			unregisterNodesResponse.ResponseHeader = ServerInstance.UnregisterNodes(unregisterNodesRequest.RequestHeader, unregisterNodesRequest.NodesToUnregister);
		}
		finally
		{
			OnResponseSent(unregisterNodesResponse);
		}
		return unregisterNodesResponse;
	}

	public virtual IAsyncResult BeginUnregisterNodes(UnregisterNodesMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.UnregisterNodesRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.UnregisterNodesRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.UnregisterNodesRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual UnregisterNodesResponseMessage EndUnregisterNodes(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new UnregisterNodesResponseMessage((UnregisterNodesResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse QueryFirst(IServiceRequest incoming)
	{
		QueryFirstResponse queryFirstResponse = null;
		try
		{
			OnRequestReceived(incoming);
			QueryFirstRequest queryFirstRequest = (QueryFirstRequest)incoming;
			QueryDataSetCollection queryDataSets = null;
			byte[] continuationPoint = null;
			ParsingResultCollection parsingResults = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			ContentFilterResult filterResult = null;
			queryFirstResponse = new QueryFirstResponse();
			queryFirstResponse.ResponseHeader = ServerInstance.QueryFirst(queryFirstRequest.RequestHeader, queryFirstRequest.View, queryFirstRequest.NodeTypes, queryFirstRequest.Filter, queryFirstRequest.MaxDataSetsToReturn, queryFirstRequest.MaxReferencesToReturn, out queryDataSets, out continuationPoint, out parsingResults, out diagnosticInfos, out filterResult);
			queryFirstResponse.QueryDataSets = queryDataSets;
			queryFirstResponse.ContinuationPoint = continuationPoint;
			queryFirstResponse.ParsingResults = parsingResults;
			queryFirstResponse.DiagnosticInfos = diagnosticInfos;
			queryFirstResponse.FilterResult = filterResult;
		}
		finally
		{
			OnResponseSent(queryFirstResponse);
		}
		return queryFirstResponse;
	}

	public virtual IAsyncResult BeginQueryFirst(QueryFirstMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.QueryFirstRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.QueryFirstRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.QueryFirstRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual QueryFirstResponseMessage EndQueryFirst(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new QueryFirstResponseMessage((QueryFirstResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse QueryNext(IServiceRequest incoming)
	{
		QueryNextResponse queryNextResponse = null;
		try
		{
			OnRequestReceived(incoming);
			QueryNextRequest queryNextRequest = (QueryNextRequest)incoming;
			QueryDataSetCollection queryDataSets = null;
			byte[] revisedContinuationPoint = null;
			queryNextResponse = new QueryNextResponse();
			queryNextResponse.ResponseHeader = ServerInstance.QueryNext(queryNextRequest.RequestHeader, queryNextRequest.ReleaseContinuationPoint, queryNextRequest.ContinuationPoint, out queryDataSets, out revisedContinuationPoint);
			queryNextResponse.QueryDataSets = queryDataSets;
			queryNextResponse.RevisedContinuationPoint = revisedContinuationPoint;
		}
		finally
		{
			OnResponseSent(queryNextResponse);
		}
		return queryNextResponse;
	}

	public virtual IAsyncResult BeginQueryNext(QueryNextMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.QueryNextRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.QueryNextRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.QueryNextRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual QueryNextResponseMessage EndQueryNext(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new QueryNextResponseMessage((QueryNextResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse Read(IServiceRequest incoming)
	{
		ReadResponse readResponse = null;
		try
		{
			OnRequestReceived(incoming);
			ReadRequest readRequest = (ReadRequest)incoming;
			DataValueCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			readResponse = new ReadResponse();
			readResponse.ResponseHeader = ServerInstance.Read(readRequest.RequestHeader, readRequest.MaxAge, readRequest.TimestampsToReturn, readRequest.NodesToRead, out results, out diagnosticInfos);
			readResponse.Results = results;
			readResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(readResponse);
		}
		return readResponse;
	}

	public virtual IAsyncResult BeginRead(ReadMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.ReadRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.ReadRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.ReadRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual ReadResponseMessage EndRead(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new ReadResponseMessage((ReadResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse HistoryRead(IServiceRequest incoming)
	{
		HistoryReadResponse historyReadResponse = null;
		try
		{
			OnRequestReceived(incoming);
			HistoryReadRequest historyReadRequest = (HistoryReadRequest)incoming;
			HistoryReadResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			historyReadResponse = new HistoryReadResponse();
			historyReadResponse.ResponseHeader = ServerInstance.HistoryRead(historyReadRequest.RequestHeader, historyReadRequest.HistoryReadDetails, historyReadRequest.TimestampsToReturn, historyReadRequest.ReleaseContinuationPoints, historyReadRequest.NodesToRead, out results, out diagnosticInfos);
			historyReadResponse.Results = results;
			historyReadResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(historyReadResponse);
		}
		return historyReadResponse;
	}

	public virtual IAsyncResult BeginHistoryRead(HistoryReadMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.HistoryReadRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.HistoryReadRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.HistoryReadRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual HistoryReadResponseMessage EndHistoryRead(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new HistoryReadResponseMessage((HistoryReadResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse Write(IServiceRequest incoming)
	{
		WriteResponse writeResponse = null;
		try
		{
			OnRequestReceived(incoming);
			WriteRequest writeRequest = (WriteRequest)incoming;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			writeResponse = new WriteResponse();
			writeResponse.ResponseHeader = ServerInstance.Write(writeRequest.RequestHeader, writeRequest.NodesToWrite, out results, out diagnosticInfos);
			writeResponse.Results = results;
			writeResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(writeResponse);
		}
		return writeResponse;
	}

	public virtual IAsyncResult BeginWrite(WriteMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.WriteRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.WriteRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.WriteRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual WriteResponseMessage EndWrite(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new WriteResponseMessage((WriteResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse HistoryUpdate(IServiceRequest incoming)
	{
		HistoryUpdateResponse historyUpdateResponse = null;
		try
		{
			OnRequestReceived(incoming);
			HistoryUpdateRequest historyUpdateRequest = (HistoryUpdateRequest)incoming;
			HistoryUpdateResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			historyUpdateResponse = new HistoryUpdateResponse();
			historyUpdateResponse.ResponseHeader = ServerInstance.HistoryUpdate(historyUpdateRequest.RequestHeader, historyUpdateRequest.HistoryUpdateDetails, out results, out diagnosticInfos);
			historyUpdateResponse.Results = results;
			historyUpdateResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(historyUpdateResponse);
		}
		return historyUpdateResponse;
	}

	public virtual IAsyncResult BeginHistoryUpdate(HistoryUpdateMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.HistoryUpdateRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.HistoryUpdateRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.HistoryUpdateRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual HistoryUpdateResponseMessage EndHistoryUpdate(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new HistoryUpdateResponseMessage((HistoryUpdateResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse Call(IServiceRequest incoming)
	{
		CallResponse callResponse = null;
		try
		{
			OnRequestReceived(incoming);
			CallRequest callRequest = (CallRequest)incoming;
			CallMethodResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			callResponse = new CallResponse();
			callResponse.ResponseHeader = ServerInstance.Call(callRequest.RequestHeader, callRequest.MethodsToCall, out results, out diagnosticInfos);
			callResponse.Results = results;
			callResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(callResponse);
		}
		return callResponse;
	}

	public virtual IAsyncResult BeginCall(CallMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.CallRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.CallRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.CallRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual CallResponseMessage EndCall(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new CallResponseMessage((CallResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse CreateMonitoredItems(IServiceRequest incoming)
	{
		CreateMonitoredItemsResponse createMonitoredItemsResponse = null;
		try
		{
			OnRequestReceived(incoming);
			CreateMonitoredItemsRequest createMonitoredItemsRequest = (CreateMonitoredItemsRequest)incoming;
			MonitoredItemCreateResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			createMonitoredItemsResponse = new CreateMonitoredItemsResponse();
			createMonitoredItemsResponse.ResponseHeader = ServerInstance.CreateMonitoredItems(createMonitoredItemsRequest.RequestHeader, createMonitoredItemsRequest.SubscriptionId, createMonitoredItemsRequest.TimestampsToReturn, createMonitoredItemsRequest.ItemsToCreate, out results, out diagnosticInfos);
			createMonitoredItemsResponse.Results = results;
			createMonitoredItemsResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(createMonitoredItemsResponse);
		}
		return createMonitoredItemsResponse;
	}

	public virtual IAsyncResult BeginCreateMonitoredItems(CreateMonitoredItemsMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.CreateMonitoredItemsRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.CreateMonitoredItemsRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.CreateMonitoredItemsRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual CreateMonitoredItemsResponseMessage EndCreateMonitoredItems(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new CreateMonitoredItemsResponseMessage((CreateMonitoredItemsResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse ModifyMonitoredItems(IServiceRequest incoming)
	{
		ModifyMonitoredItemsResponse modifyMonitoredItemsResponse = null;
		try
		{
			OnRequestReceived(incoming);
			ModifyMonitoredItemsRequest modifyMonitoredItemsRequest = (ModifyMonitoredItemsRequest)incoming;
			MonitoredItemModifyResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			modifyMonitoredItemsResponse = new ModifyMonitoredItemsResponse();
			modifyMonitoredItemsResponse.ResponseHeader = ServerInstance.ModifyMonitoredItems(modifyMonitoredItemsRequest.RequestHeader, modifyMonitoredItemsRequest.SubscriptionId, modifyMonitoredItemsRequest.TimestampsToReturn, modifyMonitoredItemsRequest.ItemsToModify, out results, out diagnosticInfos);
			modifyMonitoredItemsResponse.Results = results;
			modifyMonitoredItemsResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(modifyMonitoredItemsResponse);
		}
		return modifyMonitoredItemsResponse;
	}

	public virtual IAsyncResult BeginModifyMonitoredItems(ModifyMonitoredItemsMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.ModifyMonitoredItemsRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.ModifyMonitoredItemsRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.ModifyMonitoredItemsRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual ModifyMonitoredItemsResponseMessage EndModifyMonitoredItems(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new ModifyMonitoredItemsResponseMessage((ModifyMonitoredItemsResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse SetMonitoringMode(IServiceRequest incoming)
	{
		SetMonitoringModeResponse setMonitoringModeResponse = null;
		try
		{
			OnRequestReceived(incoming);
			SetMonitoringModeRequest setMonitoringModeRequest = (SetMonitoringModeRequest)incoming;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			setMonitoringModeResponse = new SetMonitoringModeResponse();
			setMonitoringModeResponse.ResponseHeader = ServerInstance.SetMonitoringMode(setMonitoringModeRequest.RequestHeader, setMonitoringModeRequest.SubscriptionId, setMonitoringModeRequest.MonitoringMode, setMonitoringModeRequest.MonitoredItemIds, out results, out diagnosticInfos);
			setMonitoringModeResponse.Results = results;
			setMonitoringModeResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(setMonitoringModeResponse);
		}
		return setMonitoringModeResponse;
	}

	public virtual IAsyncResult BeginSetMonitoringMode(SetMonitoringModeMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.SetMonitoringModeRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.SetMonitoringModeRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.SetMonitoringModeRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual SetMonitoringModeResponseMessage EndSetMonitoringMode(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new SetMonitoringModeResponseMessage((SetMonitoringModeResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse SetTriggering(IServiceRequest incoming)
	{
		SetTriggeringResponse setTriggeringResponse = null;
		try
		{
			OnRequestReceived(incoming);
			SetTriggeringRequest setTriggeringRequest = (SetTriggeringRequest)incoming;
			StatusCodeCollection addResults = null;
			DiagnosticInfoCollection addDiagnosticInfos = null;
			StatusCodeCollection removeResults = null;
			DiagnosticInfoCollection removeDiagnosticInfos = null;
			setTriggeringResponse = new SetTriggeringResponse();
			setTriggeringResponse.ResponseHeader = ServerInstance.SetTriggering(setTriggeringRequest.RequestHeader, setTriggeringRequest.SubscriptionId, setTriggeringRequest.TriggeringItemId, setTriggeringRequest.LinksToAdd, setTriggeringRequest.LinksToRemove, out addResults, out addDiagnosticInfos, out removeResults, out removeDiagnosticInfos);
			setTriggeringResponse.AddResults = addResults;
			setTriggeringResponse.AddDiagnosticInfos = addDiagnosticInfos;
			setTriggeringResponse.RemoveResults = removeResults;
			setTriggeringResponse.RemoveDiagnosticInfos = removeDiagnosticInfos;
		}
		finally
		{
			OnResponseSent(setTriggeringResponse);
		}
		return setTriggeringResponse;
	}

	public virtual IAsyncResult BeginSetTriggering(SetTriggeringMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.SetTriggeringRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.SetTriggeringRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.SetTriggeringRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual SetTriggeringResponseMessage EndSetTriggering(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new SetTriggeringResponseMessage((SetTriggeringResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse DeleteMonitoredItems(IServiceRequest incoming)
	{
		DeleteMonitoredItemsResponse deleteMonitoredItemsResponse = null;
		try
		{
			OnRequestReceived(incoming);
			DeleteMonitoredItemsRequest deleteMonitoredItemsRequest = (DeleteMonitoredItemsRequest)incoming;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			deleteMonitoredItemsResponse = new DeleteMonitoredItemsResponse();
			deleteMonitoredItemsResponse.ResponseHeader = ServerInstance.DeleteMonitoredItems(deleteMonitoredItemsRequest.RequestHeader, deleteMonitoredItemsRequest.SubscriptionId, deleteMonitoredItemsRequest.MonitoredItemIds, out results, out diagnosticInfos);
			deleteMonitoredItemsResponse.Results = results;
			deleteMonitoredItemsResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(deleteMonitoredItemsResponse);
		}
		return deleteMonitoredItemsResponse;
	}

	public virtual IAsyncResult BeginDeleteMonitoredItems(DeleteMonitoredItemsMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.DeleteMonitoredItemsRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.DeleteMonitoredItemsRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.DeleteMonitoredItemsRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual DeleteMonitoredItemsResponseMessage EndDeleteMonitoredItems(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new DeleteMonitoredItemsResponseMessage((DeleteMonitoredItemsResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse CreateSubscription(IServiceRequest incoming)
	{
		CreateSubscriptionResponse createSubscriptionResponse = null;
		try
		{
			OnRequestReceived(incoming);
			CreateSubscriptionRequest createSubscriptionRequest = (CreateSubscriptionRequest)incoming;
			uint subscriptionId = 0u;
			double revisedPublishingInterval = 0.0;
			uint revisedLifetimeCount = 0u;
			uint revisedMaxKeepAliveCount = 0u;
			createSubscriptionResponse = new CreateSubscriptionResponse();
			createSubscriptionResponse.ResponseHeader = ServerInstance.CreateSubscription(createSubscriptionRequest.RequestHeader, createSubscriptionRequest.RequestedPublishingInterval, createSubscriptionRequest.RequestedLifetimeCount, createSubscriptionRequest.RequestedMaxKeepAliveCount, createSubscriptionRequest.MaxNotificationsPerPublish, createSubscriptionRequest.PublishingEnabled, createSubscriptionRequest.Priority, out subscriptionId, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
			createSubscriptionResponse.SubscriptionId = subscriptionId;
			createSubscriptionResponse.RevisedPublishingInterval = revisedPublishingInterval;
			createSubscriptionResponse.RevisedLifetimeCount = revisedLifetimeCount;
			createSubscriptionResponse.RevisedMaxKeepAliveCount = revisedMaxKeepAliveCount;
		}
		finally
		{
			OnResponseSent(createSubscriptionResponse);
		}
		return createSubscriptionResponse;
	}

	public virtual IAsyncResult BeginCreateSubscription(CreateSubscriptionMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.CreateSubscriptionRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.CreateSubscriptionRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.CreateSubscriptionRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual CreateSubscriptionResponseMessage EndCreateSubscription(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new CreateSubscriptionResponseMessage((CreateSubscriptionResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse ModifySubscription(IServiceRequest incoming)
	{
		ModifySubscriptionResponse modifySubscriptionResponse = null;
		try
		{
			OnRequestReceived(incoming);
			ModifySubscriptionRequest modifySubscriptionRequest = (ModifySubscriptionRequest)incoming;
			double revisedPublishingInterval = 0.0;
			uint revisedLifetimeCount = 0u;
			uint revisedMaxKeepAliveCount = 0u;
			modifySubscriptionResponse = new ModifySubscriptionResponse();
			modifySubscriptionResponse.ResponseHeader = ServerInstance.ModifySubscription(modifySubscriptionRequest.RequestHeader, modifySubscriptionRequest.SubscriptionId, modifySubscriptionRequest.RequestedPublishingInterval, modifySubscriptionRequest.RequestedLifetimeCount, modifySubscriptionRequest.RequestedMaxKeepAliveCount, modifySubscriptionRequest.MaxNotificationsPerPublish, modifySubscriptionRequest.Priority, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
			modifySubscriptionResponse.RevisedPublishingInterval = revisedPublishingInterval;
			modifySubscriptionResponse.RevisedLifetimeCount = revisedLifetimeCount;
			modifySubscriptionResponse.RevisedMaxKeepAliveCount = revisedMaxKeepAliveCount;
		}
		finally
		{
			OnResponseSent(modifySubscriptionResponse);
		}
		return modifySubscriptionResponse;
	}

	public virtual IAsyncResult BeginModifySubscription(ModifySubscriptionMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.ModifySubscriptionRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.ModifySubscriptionRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.ModifySubscriptionRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual ModifySubscriptionResponseMessage EndModifySubscription(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new ModifySubscriptionResponseMessage((ModifySubscriptionResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse SetPublishingMode(IServiceRequest incoming)
	{
		SetPublishingModeResponse setPublishingModeResponse = null;
		try
		{
			OnRequestReceived(incoming);
			SetPublishingModeRequest setPublishingModeRequest = (SetPublishingModeRequest)incoming;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			setPublishingModeResponse = new SetPublishingModeResponse();
			setPublishingModeResponse.ResponseHeader = ServerInstance.SetPublishingMode(setPublishingModeRequest.RequestHeader, setPublishingModeRequest.PublishingEnabled, setPublishingModeRequest.SubscriptionIds, out results, out diagnosticInfos);
			setPublishingModeResponse.Results = results;
			setPublishingModeResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(setPublishingModeResponse);
		}
		return setPublishingModeResponse;
	}

	public virtual IAsyncResult BeginSetPublishingMode(SetPublishingModeMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.SetPublishingModeRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.SetPublishingModeRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.SetPublishingModeRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual SetPublishingModeResponseMessage EndSetPublishingMode(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new SetPublishingModeResponseMessage((SetPublishingModeResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse Publish(IServiceRequest incoming)
	{
		PublishResponse publishResponse = null;
		try
		{
			OnRequestReceived(incoming);
			PublishRequest publishRequest = (PublishRequest)incoming;
			uint subscriptionId = 0u;
			UInt32Collection availableSequenceNumbers = null;
			bool moreNotifications = false;
			NotificationMessage notificationMessage = null;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			publishResponse = new PublishResponse();
			publishResponse.ResponseHeader = ServerInstance.Publish(publishRequest.RequestHeader, publishRequest.SubscriptionAcknowledgements, out subscriptionId, out availableSequenceNumbers, out moreNotifications, out notificationMessage, out results, out diagnosticInfos);
			publishResponse.SubscriptionId = subscriptionId;
			publishResponse.AvailableSequenceNumbers = availableSequenceNumbers;
			publishResponse.MoreNotifications = moreNotifications;
			publishResponse.NotificationMessage = notificationMessage;
			publishResponse.Results = results;
			publishResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(publishResponse);
		}
		return publishResponse;
	}

	public virtual IAsyncResult BeginPublish(PublishMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.PublishRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.PublishRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.PublishRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual PublishResponseMessage EndPublish(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new PublishResponseMessage((PublishResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse Republish(IServiceRequest incoming)
	{
		RepublishResponse republishResponse = null;
		try
		{
			OnRequestReceived(incoming);
			RepublishRequest republishRequest = (RepublishRequest)incoming;
			NotificationMessage notificationMessage = null;
			republishResponse = new RepublishResponse();
			republishResponse.ResponseHeader = ServerInstance.Republish(republishRequest.RequestHeader, republishRequest.SubscriptionId, republishRequest.RetransmitSequenceNumber, out notificationMessage);
			republishResponse.NotificationMessage = notificationMessage;
		}
		finally
		{
			OnResponseSent(republishResponse);
		}
		return republishResponse;
	}

	public virtual IAsyncResult BeginRepublish(RepublishMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.RepublishRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.RepublishRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.RepublishRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual RepublishResponseMessage EndRepublish(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new RepublishResponseMessage((RepublishResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse TransferSubscriptions(IServiceRequest incoming)
	{
		TransferSubscriptionsResponse transferSubscriptionsResponse = null;
		try
		{
			OnRequestReceived(incoming);
			TransferSubscriptionsRequest transferSubscriptionsRequest = (TransferSubscriptionsRequest)incoming;
			TransferResultCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			transferSubscriptionsResponse = new TransferSubscriptionsResponse();
			transferSubscriptionsResponse.ResponseHeader = ServerInstance.TransferSubscriptions(transferSubscriptionsRequest.RequestHeader, transferSubscriptionsRequest.SubscriptionIds, transferSubscriptionsRequest.SendInitialValues, out results, out diagnosticInfos);
			transferSubscriptionsResponse.Results = results;
			transferSubscriptionsResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(transferSubscriptionsResponse);
		}
		return transferSubscriptionsResponse;
	}

	public virtual IAsyncResult BeginTransferSubscriptions(TransferSubscriptionsMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.TransferSubscriptionsRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.TransferSubscriptionsRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.TransferSubscriptionsRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual TransferSubscriptionsResponseMessage EndTransferSubscriptions(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new TransferSubscriptionsResponseMessage((TransferSubscriptionsResponse)serviceResponse);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public IServiceResponse DeleteSubscriptions(IServiceRequest incoming)
	{
		DeleteSubscriptionsResponse deleteSubscriptionsResponse = null;
		try
		{
			OnRequestReceived(incoming);
			DeleteSubscriptionsRequest deleteSubscriptionsRequest = (DeleteSubscriptionsRequest)incoming;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			deleteSubscriptionsResponse = new DeleteSubscriptionsResponse();
			deleteSubscriptionsResponse.ResponseHeader = ServerInstance.DeleteSubscriptions(deleteSubscriptionsRequest.RequestHeader, deleteSubscriptionsRequest.SubscriptionIds, out results, out diagnosticInfos);
			deleteSubscriptionsResponse.Results = results;
			deleteSubscriptionsResponse.DiagnosticInfos = diagnosticInfos;
		}
		finally
		{
			OnResponseSent(deleteSubscriptionsResponse);
		}
		return deleteSubscriptionsResponse;
	}

	public virtual IAsyncResult BeginDeleteSubscriptions(DeleteSubscriptionsMessage message, AsyncCallback callback, object callbackData)
	{
		try
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			OnRequestReceived(message.DeleteSubscriptionsRequest);
			SetRequestContext(RequestEncoding.Xml);
			return new ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, message.DeleteSubscriptionsRequest);
		}
		catch (Exception exception)
		{
			Exception ex = EndpointBase.CreateSoapFault(message.DeleteSubscriptionsRequest, exception);
			OnResponseFaultSent(ex);
			throw ex;
		}
	}

	public virtual DeleteSubscriptionsResponseMessage EndDeleteSubscriptions(IAsyncResult ar)
	{
		try
		{
			IServiceResponse serviceResponse = ProcessRequestAsyncResult.WaitForComplete(ar, throwOnError: true);
			OnResponseSent(serviceResponse);
			return new DeleteSubscriptionsResponseMessage((DeleteSubscriptionsResponse)serviceResponse);
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
		base.SupportedServices.Add(DataTypeIds.CreateSessionRequest, new ServiceDefinition(typeof(CreateSessionRequest), CreateSession));
		base.SupportedServices.Add(DataTypeIds.ActivateSessionRequest, new ServiceDefinition(typeof(ActivateSessionRequest), ActivateSession));
		base.SupportedServices.Add(DataTypeIds.CloseSessionRequest, new ServiceDefinition(typeof(CloseSessionRequest), CloseSession));
		base.SupportedServices.Add(DataTypeIds.CancelRequest, new ServiceDefinition(typeof(CancelRequest), Cancel));
		base.SupportedServices.Add(DataTypeIds.AddNodesRequest, new ServiceDefinition(typeof(AddNodesRequest), AddNodes));
		base.SupportedServices.Add(DataTypeIds.AddReferencesRequest, new ServiceDefinition(typeof(AddReferencesRequest), AddReferences));
		base.SupportedServices.Add(DataTypeIds.DeleteNodesRequest, new ServiceDefinition(typeof(DeleteNodesRequest), DeleteNodes));
		base.SupportedServices.Add(DataTypeIds.DeleteReferencesRequest, new ServiceDefinition(typeof(DeleteReferencesRequest), DeleteReferences));
		base.SupportedServices.Add(DataTypeIds.BrowseRequest, new ServiceDefinition(typeof(BrowseRequest), Browse));
		base.SupportedServices.Add(DataTypeIds.BrowseNextRequest, new ServiceDefinition(typeof(BrowseNextRequest), BrowseNext));
		base.SupportedServices.Add(DataTypeIds.TranslateBrowsePathsToNodeIdsRequest, new ServiceDefinition(typeof(TranslateBrowsePathsToNodeIdsRequest), TranslateBrowsePathsToNodeIds));
		base.SupportedServices.Add(DataTypeIds.RegisterNodesRequest, new ServiceDefinition(typeof(RegisterNodesRequest), RegisterNodes));
		base.SupportedServices.Add(DataTypeIds.UnregisterNodesRequest, new ServiceDefinition(typeof(UnregisterNodesRequest), UnregisterNodes));
		base.SupportedServices.Add(DataTypeIds.QueryFirstRequest, new ServiceDefinition(typeof(QueryFirstRequest), QueryFirst));
		base.SupportedServices.Add(DataTypeIds.QueryNextRequest, new ServiceDefinition(typeof(QueryNextRequest), QueryNext));
		base.SupportedServices.Add(DataTypeIds.ReadRequest, new ServiceDefinition(typeof(ReadRequest), Read));
		base.SupportedServices.Add(DataTypeIds.HistoryReadRequest, new ServiceDefinition(typeof(HistoryReadRequest), HistoryRead));
		base.SupportedServices.Add(DataTypeIds.WriteRequest, new ServiceDefinition(typeof(WriteRequest), Write));
		base.SupportedServices.Add(DataTypeIds.HistoryUpdateRequest, new ServiceDefinition(typeof(HistoryUpdateRequest), HistoryUpdate));
		base.SupportedServices.Add(DataTypeIds.CallRequest, new ServiceDefinition(typeof(CallRequest), Call));
		base.SupportedServices.Add(DataTypeIds.CreateMonitoredItemsRequest, new ServiceDefinition(typeof(CreateMonitoredItemsRequest), CreateMonitoredItems));
		base.SupportedServices.Add(DataTypeIds.ModifyMonitoredItemsRequest, new ServiceDefinition(typeof(ModifyMonitoredItemsRequest), ModifyMonitoredItems));
		base.SupportedServices.Add(DataTypeIds.SetMonitoringModeRequest, new ServiceDefinition(typeof(SetMonitoringModeRequest), SetMonitoringMode));
		base.SupportedServices.Add(DataTypeIds.SetTriggeringRequest, new ServiceDefinition(typeof(SetTriggeringRequest), SetTriggering));
		base.SupportedServices.Add(DataTypeIds.DeleteMonitoredItemsRequest, new ServiceDefinition(typeof(DeleteMonitoredItemsRequest), DeleteMonitoredItems));
		base.SupportedServices.Add(DataTypeIds.CreateSubscriptionRequest, new ServiceDefinition(typeof(CreateSubscriptionRequest), CreateSubscription));
		base.SupportedServices.Add(DataTypeIds.ModifySubscriptionRequest, new ServiceDefinition(typeof(ModifySubscriptionRequest), ModifySubscription));
		base.SupportedServices.Add(DataTypeIds.SetPublishingModeRequest, new ServiceDefinition(typeof(SetPublishingModeRequest), SetPublishingMode));
		base.SupportedServices.Add(DataTypeIds.PublishRequest, new ServiceDefinition(typeof(PublishRequest), Publish));
		base.SupportedServices.Add(DataTypeIds.RepublishRequest, new ServiceDefinition(typeof(RepublishRequest), Republish));
		base.SupportedServices.Add(DataTypeIds.TransferSubscriptionsRequest, new ServiceDefinition(typeof(TransferSubscriptionsRequest), TransferSubscriptions));
		base.SupportedServices.Add(DataTypeIds.DeleteSubscriptionsRequest, new ServiceDefinition(typeof(DeleteSubscriptionsRequest), DeleteSubscriptions));
	}
}
