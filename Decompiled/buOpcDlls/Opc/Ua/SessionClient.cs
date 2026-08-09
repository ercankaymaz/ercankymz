using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionClient : ClientBase, ISessionClient, ISessionClientMethods, IClientBase, IDisposable
{
	private readonly object m_lock = new object();

	private NodeId m_sessionId;

	public NodeId SessionId => m_sessionId;

	public bool Connected => m_sessionId != null;

	public new ISessionChannel InnerChannel => (ISessionChannel)base.InnerChannel;

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			m_sessionId = null;
		}
		base.Dispose(disposing);
	}

	public virtual void SessionCreated(NodeId sessionId, NodeId sessionCookie)
	{
		lock (m_lock)
		{
			m_sessionId = sessionId;
			base.AuthenticationToken = sessionCookie;
		}
	}

	public SessionClient(ITransportChannel channel)
		: base(channel)
	{
	}

	public virtual ResponseHeader CreateSession(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, out NodeId sessionId, out NodeId authenticationToken, out double revisedSessionTimeout, out byte[] serverNonce, out byte[] serverCertificate, out EndpointDescriptionCollection serverEndpoints, out SignedSoftwareCertificateCollection serverSoftwareCertificates, out SignatureData serverSignature, out uint maxRequestMessageSize)
	{
		CreateSessionRequest createSessionRequest = new CreateSessionRequest();
		CreateSessionResponse createSessionResponse = null;
		createSessionRequest.RequestHeader = requestHeader;
		createSessionRequest.ClientDescription = clientDescription;
		createSessionRequest.ServerUri = serverUri;
		createSessionRequest.EndpointUrl = endpointUrl;
		createSessionRequest.SessionName = sessionName;
		createSessionRequest.ClientNonce = clientNonce;
		createSessionRequest.ClientCertificate = clientCertificate;
		createSessionRequest.RequestedSessionTimeout = requestedSessionTimeout;
		createSessionRequest.MaxResponseMessageSize = maxResponseMessageSize;
		UpdateRequestHeader(createSessionRequest, requestHeader == null, "CreateSession");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(createSessionRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			createSessionResponse = (CreateSessionResponse)obj;
			sessionId = createSessionResponse.SessionId;
			authenticationToken = createSessionResponse.AuthenticationToken;
			revisedSessionTimeout = createSessionResponse.RevisedSessionTimeout;
			serverNonce = createSessionResponse.ServerNonce;
			serverCertificate = createSessionResponse.ServerCertificate;
			serverEndpoints = createSessionResponse.ServerEndpoints;
			serverSoftwareCertificates = createSessionResponse.ServerSoftwareCertificates;
			serverSignature = createSessionResponse.ServerSignature;
			maxRequestMessageSize = createSessionResponse.MaxRequestMessageSize;
		}
		finally
		{
			RequestCompleted(createSessionRequest, createSessionResponse, "CreateSession");
		}
		return createSessionResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginCreateSession(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, AsyncCallback callback, object asyncState)
	{
		CreateSessionRequest createSessionRequest = new CreateSessionRequest();
		createSessionRequest.RequestHeader = requestHeader;
		createSessionRequest.ClientDescription = clientDescription;
		createSessionRequest.ServerUri = serverUri;
		createSessionRequest.EndpointUrl = endpointUrl;
		createSessionRequest.SessionName = sessionName;
		createSessionRequest.ClientNonce = clientNonce;
		createSessionRequest.ClientCertificate = clientCertificate;
		createSessionRequest.RequestedSessionTimeout = requestedSessionTimeout;
		createSessionRequest.MaxResponseMessageSize = maxResponseMessageSize;
		UpdateRequestHeader(createSessionRequest, requestHeader == null, "CreateSession");
		return base.TransportChannel.BeginSendRequest(createSessionRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndCreateSession(IAsyncResult result, out NodeId sessionId, out NodeId authenticationToken, out double revisedSessionTimeout, out byte[] serverNonce, out byte[] serverCertificate, out EndpointDescriptionCollection serverEndpoints, out SignedSoftwareCertificateCollection serverSoftwareCertificates, out SignatureData serverSignature, out uint maxRequestMessageSize)
	{
		CreateSessionResponse createSessionResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			createSessionResponse = (CreateSessionResponse)obj;
			sessionId = createSessionResponse.SessionId;
			authenticationToken = createSessionResponse.AuthenticationToken;
			revisedSessionTimeout = createSessionResponse.RevisedSessionTimeout;
			serverNonce = createSessionResponse.ServerNonce;
			serverCertificate = createSessionResponse.ServerCertificate;
			serverEndpoints = createSessionResponse.ServerEndpoints;
			serverSoftwareCertificates = createSessionResponse.ServerSoftwareCertificates;
			serverSignature = createSessionResponse.ServerSignature;
			maxRequestMessageSize = createSessionResponse.MaxRequestMessageSize;
		}
		finally
		{
			RequestCompleted(null, createSessionResponse, "CreateSession");
		}
		return createSessionResponse.ResponseHeader;
	}

	public virtual async Task<CreateSessionResponse> CreateSessionAsync(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, CancellationToken ct)
	{
		CreateSessionRequest request = new CreateSessionRequest();
		CreateSessionResponse response = null;
		request.RequestHeader = requestHeader;
		request.ClientDescription = clientDescription;
		request.ServerUri = serverUri;
		request.EndpointUrl = endpointUrl;
		request.SessionName = sessionName;
		request.ClientNonce = clientNonce;
		request.ClientCertificate = clientCertificate;
		request.RequestedSessionTimeout = requestedSessionTimeout;
		request.MaxResponseMessageSize = maxResponseMessageSize;
		UpdateRequestHeader(request, requestHeader == null, "CreateSession");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (CreateSessionResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "CreateSession");
		}
		return response;
	}

	public virtual ResponseHeader ActivateSession(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, out byte[] serverNonce, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ActivateSessionRequest activateSessionRequest = new ActivateSessionRequest();
		ActivateSessionResponse activateSessionResponse = null;
		activateSessionRequest.RequestHeader = requestHeader;
		activateSessionRequest.ClientSignature = clientSignature;
		activateSessionRequest.ClientSoftwareCertificates = clientSoftwareCertificates;
		activateSessionRequest.LocaleIds = localeIds;
		activateSessionRequest.UserIdentityToken = userIdentityToken;
		activateSessionRequest.UserTokenSignature = userTokenSignature;
		UpdateRequestHeader(activateSessionRequest, requestHeader == null, "ActivateSession");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(activateSessionRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			activateSessionResponse = (ActivateSessionResponse)obj;
			serverNonce = activateSessionResponse.ServerNonce;
			results = activateSessionResponse.Results;
			diagnosticInfos = activateSessionResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(activateSessionRequest, activateSessionResponse, "ActivateSession");
		}
		return activateSessionResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginActivateSession(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, AsyncCallback callback, object asyncState)
	{
		ActivateSessionRequest activateSessionRequest = new ActivateSessionRequest();
		activateSessionRequest.RequestHeader = requestHeader;
		activateSessionRequest.ClientSignature = clientSignature;
		activateSessionRequest.ClientSoftwareCertificates = clientSoftwareCertificates;
		activateSessionRequest.LocaleIds = localeIds;
		activateSessionRequest.UserIdentityToken = userIdentityToken;
		activateSessionRequest.UserTokenSignature = userTokenSignature;
		UpdateRequestHeader(activateSessionRequest, requestHeader == null, "ActivateSession");
		return base.TransportChannel.BeginSendRequest(activateSessionRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndActivateSession(IAsyncResult result, out byte[] serverNonce, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ActivateSessionResponse activateSessionResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			activateSessionResponse = (ActivateSessionResponse)obj;
			serverNonce = activateSessionResponse.ServerNonce;
			results = activateSessionResponse.Results;
			diagnosticInfos = activateSessionResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, activateSessionResponse, "ActivateSession");
		}
		return activateSessionResponse.ResponseHeader;
	}

	public virtual async Task<ActivateSessionResponse> ActivateSessionAsync(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, CancellationToken ct)
	{
		ActivateSessionRequest request = new ActivateSessionRequest();
		ActivateSessionResponse response = null;
		request.RequestHeader = requestHeader;
		request.ClientSignature = clientSignature;
		request.ClientSoftwareCertificates = clientSoftwareCertificates;
		request.LocaleIds = localeIds;
		request.UserIdentityToken = userIdentityToken;
		request.UserTokenSignature = userTokenSignature;
		UpdateRequestHeader(request, requestHeader == null, "ActivateSession");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (ActivateSessionResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "ActivateSession");
		}
		return response;
	}

	public virtual ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions)
	{
		CloseSessionRequest closeSessionRequest = new CloseSessionRequest();
		CloseSessionResponse closeSessionResponse = null;
		closeSessionRequest.RequestHeader = requestHeader;
		closeSessionRequest.DeleteSubscriptions = deleteSubscriptions;
		UpdateRequestHeader(closeSessionRequest, requestHeader == null, "CloseSession");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(closeSessionRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			closeSessionResponse = (CloseSessionResponse)obj;
		}
		finally
		{
			RequestCompleted(closeSessionRequest, closeSessionResponse, "CloseSession");
		}
		return closeSessionResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginCloseSession(RequestHeader requestHeader, bool deleteSubscriptions, AsyncCallback callback, object asyncState)
	{
		CloseSessionRequest closeSessionRequest = new CloseSessionRequest();
		closeSessionRequest.RequestHeader = requestHeader;
		closeSessionRequest.DeleteSubscriptions = deleteSubscriptions;
		UpdateRequestHeader(closeSessionRequest, requestHeader == null, "CloseSession");
		return base.TransportChannel.BeginSendRequest(closeSessionRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndCloseSession(IAsyncResult result)
	{
		CloseSessionResponse closeSessionResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			closeSessionResponse = (CloseSessionResponse)obj;
		}
		finally
		{
			RequestCompleted(null, closeSessionResponse, "CloseSession");
		}
		return closeSessionResponse.ResponseHeader;
	}

	public virtual async Task<CloseSessionResponse> CloseSessionAsync(RequestHeader requestHeader, bool deleteSubscriptions, CancellationToken ct)
	{
		CloseSessionRequest request = new CloseSessionRequest();
		CloseSessionResponse response = null;
		request.RequestHeader = requestHeader;
		request.DeleteSubscriptions = deleteSubscriptions;
		UpdateRequestHeader(request, requestHeader == null, "CloseSession");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (CloseSessionResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "CloseSession");
		}
		return response;
	}

	public virtual ResponseHeader Cancel(RequestHeader requestHeader, uint requestHandle, out uint cancelCount)
	{
		CancelRequest cancelRequest = new CancelRequest();
		CancelResponse cancelResponse = null;
		cancelRequest.RequestHeader = requestHeader;
		cancelRequest.RequestHandle = requestHandle;
		UpdateRequestHeader(cancelRequest, requestHeader == null, "Cancel");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(cancelRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			cancelResponse = (CancelResponse)obj;
			cancelCount = cancelResponse.CancelCount;
		}
		finally
		{
			RequestCompleted(cancelRequest, cancelResponse, "Cancel");
		}
		return cancelResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginCancel(RequestHeader requestHeader, uint requestHandle, AsyncCallback callback, object asyncState)
	{
		CancelRequest cancelRequest = new CancelRequest();
		cancelRequest.RequestHeader = requestHeader;
		cancelRequest.RequestHandle = requestHandle;
		UpdateRequestHeader(cancelRequest, requestHeader == null, "Cancel");
		return base.TransportChannel.BeginSendRequest(cancelRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndCancel(IAsyncResult result, out uint cancelCount)
	{
		CancelResponse cancelResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			cancelResponse = (CancelResponse)obj;
			cancelCount = cancelResponse.CancelCount;
		}
		finally
		{
			RequestCompleted(null, cancelResponse, "Cancel");
		}
		return cancelResponse.ResponseHeader;
	}

	public virtual async Task<CancelResponse> CancelAsync(RequestHeader requestHeader, uint requestHandle, CancellationToken ct)
	{
		CancelRequest request = new CancelRequest();
		CancelResponse response = null;
		request.RequestHeader = requestHeader;
		request.RequestHandle = requestHandle;
		UpdateRequestHeader(request, requestHeader == null, "Cancel");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (CancelResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "Cancel");
		}
		return response;
	}

	public virtual ResponseHeader AddNodes(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, out AddNodesResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		AddNodesRequest addNodesRequest = new AddNodesRequest();
		AddNodesResponse addNodesResponse = null;
		addNodesRequest.RequestHeader = requestHeader;
		addNodesRequest.NodesToAdd = nodesToAdd;
		UpdateRequestHeader(addNodesRequest, requestHeader == null, "AddNodes");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(addNodesRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			addNodesResponse = (AddNodesResponse)obj;
			results = addNodesResponse.Results;
			diagnosticInfos = addNodesResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(addNodesRequest, addNodesResponse, "AddNodes");
		}
		return addNodesResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginAddNodes(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, AsyncCallback callback, object asyncState)
	{
		AddNodesRequest addNodesRequest = new AddNodesRequest();
		addNodesRequest.RequestHeader = requestHeader;
		addNodesRequest.NodesToAdd = nodesToAdd;
		UpdateRequestHeader(addNodesRequest, requestHeader == null, "AddNodes");
		return base.TransportChannel.BeginSendRequest(addNodesRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndAddNodes(IAsyncResult result, out AddNodesResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		AddNodesResponse addNodesResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			addNodesResponse = (AddNodesResponse)obj;
			results = addNodesResponse.Results;
			diagnosticInfos = addNodesResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, addNodesResponse, "AddNodes");
		}
		return addNodesResponse.ResponseHeader;
	}

	public virtual async Task<AddNodesResponse> AddNodesAsync(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, CancellationToken ct)
	{
		AddNodesRequest request = new AddNodesRequest();
		AddNodesResponse response = null;
		request.RequestHeader = requestHeader;
		request.NodesToAdd = nodesToAdd;
		UpdateRequestHeader(request, requestHeader == null, "AddNodes");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (AddNodesResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "AddNodes");
		}
		return response;
	}

	public virtual ResponseHeader AddReferences(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		AddReferencesRequest addReferencesRequest = new AddReferencesRequest();
		AddReferencesResponse addReferencesResponse = null;
		addReferencesRequest.RequestHeader = requestHeader;
		addReferencesRequest.ReferencesToAdd = referencesToAdd;
		UpdateRequestHeader(addReferencesRequest, requestHeader == null, "AddReferences");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(addReferencesRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			addReferencesResponse = (AddReferencesResponse)obj;
			results = addReferencesResponse.Results;
			diagnosticInfos = addReferencesResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(addReferencesRequest, addReferencesResponse, "AddReferences");
		}
		return addReferencesResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginAddReferences(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, AsyncCallback callback, object asyncState)
	{
		AddReferencesRequest addReferencesRequest = new AddReferencesRequest();
		addReferencesRequest.RequestHeader = requestHeader;
		addReferencesRequest.ReferencesToAdd = referencesToAdd;
		UpdateRequestHeader(addReferencesRequest, requestHeader == null, "AddReferences");
		return base.TransportChannel.BeginSendRequest(addReferencesRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndAddReferences(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		AddReferencesResponse addReferencesResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			addReferencesResponse = (AddReferencesResponse)obj;
			results = addReferencesResponse.Results;
			diagnosticInfos = addReferencesResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, addReferencesResponse, "AddReferences");
		}
		return addReferencesResponse.ResponseHeader;
	}

	public virtual async Task<AddReferencesResponse> AddReferencesAsync(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, CancellationToken ct)
	{
		AddReferencesRequest request = new AddReferencesRequest();
		AddReferencesResponse response = null;
		request.RequestHeader = requestHeader;
		request.ReferencesToAdd = referencesToAdd;
		UpdateRequestHeader(request, requestHeader == null, "AddReferences");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (AddReferencesResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "AddReferences");
		}
		return response;
	}

	public virtual ResponseHeader DeleteNodes(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		DeleteNodesRequest deleteNodesRequest = new DeleteNodesRequest();
		DeleteNodesResponse deleteNodesResponse = null;
		deleteNodesRequest.RequestHeader = requestHeader;
		deleteNodesRequest.NodesToDelete = nodesToDelete;
		UpdateRequestHeader(deleteNodesRequest, requestHeader == null, "DeleteNodes");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(deleteNodesRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			deleteNodesResponse = (DeleteNodesResponse)obj;
			results = deleteNodesResponse.Results;
			diagnosticInfos = deleteNodesResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(deleteNodesRequest, deleteNodesResponse, "DeleteNodes");
		}
		return deleteNodesResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginDeleteNodes(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, AsyncCallback callback, object asyncState)
	{
		DeleteNodesRequest deleteNodesRequest = new DeleteNodesRequest();
		deleteNodesRequest.RequestHeader = requestHeader;
		deleteNodesRequest.NodesToDelete = nodesToDelete;
		UpdateRequestHeader(deleteNodesRequest, requestHeader == null, "DeleteNodes");
		return base.TransportChannel.BeginSendRequest(deleteNodesRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndDeleteNodes(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		DeleteNodesResponse deleteNodesResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			deleteNodesResponse = (DeleteNodesResponse)obj;
			results = deleteNodesResponse.Results;
			diagnosticInfos = deleteNodesResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, deleteNodesResponse, "DeleteNodes");
		}
		return deleteNodesResponse.ResponseHeader;
	}

	public virtual async Task<DeleteNodesResponse> DeleteNodesAsync(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, CancellationToken ct)
	{
		DeleteNodesRequest request = new DeleteNodesRequest();
		DeleteNodesResponse response = null;
		request.RequestHeader = requestHeader;
		request.NodesToDelete = nodesToDelete;
		UpdateRequestHeader(request, requestHeader == null, "DeleteNodes");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (DeleteNodesResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "DeleteNodes");
		}
		return response;
	}

	public virtual ResponseHeader DeleteReferences(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		DeleteReferencesRequest deleteReferencesRequest = new DeleteReferencesRequest();
		DeleteReferencesResponse deleteReferencesResponse = null;
		deleteReferencesRequest.RequestHeader = requestHeader;
		deleteReferencesRequest.ReferencesToDelete = referencesToDelete;
		UpdateRequestHeader(deleteReferencesRequest, requestHeader == null, "DeleteReferences");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(deleteReferencesRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			deleteReferencesResponse = (DeleteReferencesResponse)obj;
			results = deleteReferencesResponse.Results;
			diagnosticInfos = deleteReferencesResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(deleteReferencesRequest, deleteReferencesResponse, "DeleteReferences");
		}
		return deleteReferencesResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginDeleteReferences(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, AsyncCallback callback, object asyncState)
	{
		DeleteReferencesRequest deleteReferencesRequest = new DeleteReferencesRequest();
		deleteReferencesRequest.RequestHeader = requestHeader;
		deleteReferencesRequest.ReferencesToDelete = referencesToDelete;
		UpdateRequestHeader(deleteReferencesRequest, requestHeader == null, "DeleteReferences");
		return base.TransportChannel.BeginSendRequest(deleteReferencesRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndDeleteReferences(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		DeleteReferencesResponse deleteReferencesResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			deleteReferencesResponse = (DeleteReferencesResponse)obj;
			results = deleteReferencesResponse.Results;
			diagnosticInfos = deleteReferencesResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, deleteReferencesResponse, "DeleteReferences");
		}
		return deleteReferencesResponse.ResponseHeader;
	}

	public virtual async Task<DeleteReferencesResponse> DeleteReferencesAsync(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, CancellationToken ct)
	{
		DeleteReferencesRequest request = new DeleteReferencesRequest();
		DeleteReferencesResponse response = null;
		request.RequestHeader = requestHeader;
		request.ReferencesToDelete = referencesToDelete;
		UpdateRequestHeader(request, requestHeader == null, "DeleteReferences");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (DeleteReferencesResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "DeleteReferences");
		}
		return response;
	}

	public virtual ResponseHeader Browse(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		BrowseRequest browseRequest = new BrowseRequest();
		BrowseResponse browseResponse = null;
		browseRequest.RequestHeader = requestHeader;
		browseRequest.View = view;
		browseRequest.RequestedMaxReferencesPerNode = requestedMaxReferencesPerNode;
		browseRequest.NodesToBrowse = nodesToBrowse;
		UpdateRequestHeader(browseRequest, requestHeader == null, "Browse");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(browseRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			browseResponse = (BrowseResponse)obj;
			results = browseResponse.Results;
			diagnosticInfos = browseResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(browseRequest, browseResponse, "Browse");
		}
		return browseResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginBrowse(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, AsyncCallback callback, object asyncState)
	{
		BrowseRequest browseRequest = new BrowseRequest();
		browseRequest.RequestHeader = requestHeader;
		browseRequest.View = view;
		browseRequest.RequestedMaxReferencesPerNode = requestedMaxReferencesPerNode;
		browseRequest.NodesToBrowse = nodesToBrowse;
		UpdateRequestHeader(browseRequest, requestHeader == null, "Browse");
		return base.TransportChannel.BeginSendRequest(browseRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndBrowse(IAsyncResult result, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		BrowseResponse browseResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			browseResponse = (BrowseResponse)obj;
			results = browseResponse.Results;
			diagnosticInfos = browseResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, browseResponse, "Browse");
		}
		return browseResponse.ResponseHeader;
	}

	public virtual async Task<BrowseResponse> BrowseAsync(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, CancellationToken ct)
	{
		BrowseRequest request = new BrowseRequest();
		BrowseResponse response = null;
		request.RequestHeader = requestHeader;
		request.View = view;
		request.RequestedMaxReferencesPerNode = requestedMaxReferencesPerNode;
		request.NodesToBrowse = nodesToBrowse;
		UpdateRequestHeader(request, requestHeader == null, "Browse");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (BrowseResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "Browse");
		}
		return response;
	}

	public virtual ResponseHeader BrowseNext(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		BrowseNextRequest browseNextRequest = new BrowseNextRequest();
		BrowseNextResponse browseNextResponse = null;
		browseNextRequest.RequestHeader = requestHeader;
		browseNextRequest.ReleaseContinuationPoints = releaseContinuationPoints;
		browseNextRequest.ContinuationPoints = continuationPoints;
		UpdateRequestHeader(browseNextRequest, requestHeader == null, "BrowseNext");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(browseNextRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			browseNextResponse = (BrowseNextResponse)obj;
			results = browseNextResponse.Results;
			diagnosticInfos = browseNextResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(browseNextRequest, browseNextResponse, "BrowseNext");
		}
		return browseNextResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginBrowseNext(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, AsyncCallback callback, object asyncState)
	{
		BrowseNextRequest browseNextRequest = new BrowseNextRequest();
		browseNextRequest.RequestHeader = requestHeader;
		browseNextRequest.ReleaseContinuationPoints = releaseContinuationPoints;
		browseNextRequest.ContinuationPoints = continuationPoints;
		UpdateRequestHeader(browseNextRequest, requestHeader == null, "BrowseNext");
		return base.TransportChannel.BeginSendRequest(browseNextRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndBrowseNext(IAsyncResult result, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		BrowseNextResponse browseNextResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			browseNextResponse = (BrowseNextResponse)obj;
			results = browseNextResponse.Results;
			diagnosticInfos = browseNextResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, browseNextResponse, "BrowseNext");
		}
		return browseNextResponse.ResponseHeader;
	}

	public virtual async Task<BrowseNextResponse> BrowseNextAsync(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, CancellationToken ct)
	{
		BrowseNextRequest request = new BrowseNextRequest();
		BrowseNextResponse response = null;
		request.RequestHeader = requestHeader;
		request.ReleaseContinuationPoints = releaseContinuationPoints;
		request.ContinuationPoints = continuationPoints;
		UpdateRequestHeader(request, requestHeader == null, "BrowseNext");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (BrowseNextResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "BrowseNext");
		}
		return response;
	}

	public virtual ResponseHeader TranslateBrowsePathsToNodeIds(RequestHeader requestHeader, BrowsePathCollection browsePaths, out BrowsePathResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		TranslateBrowsePathsToNodeIdsRequest translateBrowsePathsToNodeIdsRequest = new TranslateBrowsePathsToNodeIdsRequest();
		TranslateBrowsePathsToNodeIdsResponse translateBrowsePathsToNodeIdsResponse = null;
		translateBrowsePathsToNodeIdsRequest.RequestHeader = requestHeader;
		translateBrowsePathsToNodeIdsRequest.BrowsePaths = browsePaths;
		UpdateRequestHeader(translateBrowsePathsToNodeIdsRequest, requestHeader == null, "TranslateBrowsePathsToNodeIds");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(translateBrowsePathsToNodeIdsRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			translateBrowsePathsToNodeIdsResponse = (TranslateBrowsePathsToNodeIdsResponse)obj;
			results = translateBrowsePathsToNodeIdsResponse.Results;
			diagnosticInfos = translateBrowsePathsToNodeIdsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(translateBrowsePathsToNodeIdsRequest, translateBrowsePathsToNodeIdsResponse, "TranslateBrowsePathsToNodeIds");
		}
		return translateBrowsePathsToNodeIdsResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginTranslateBrowsePathsToNodeIds(RequestHeader requestHeader, BrowsePathCollection browsePaths, AsyncCallback callback, object asyncState)
	{
		TranslateBrowsePathsToNodeIdsRequest translateBrowsePathsToNodeIdsRequest = new TranslateBrowsePathsToNodeIdsRequest();
		translateBrowsePathsToNodeIdsRequest.RequestHeader = requestHeader;
		translateBrowsePathsToNodeIdsRequest.BrowsePaths = browsePaths;
		UpdateRequestHeader(translateBrowsePathsToNodeIdsRequest, requestHeader == null, "TranslateBrowsePathsToNodeIds");
		return base.TransportChannel.BeginSendRequest(translateBrowsePathsToNodeIdsRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndTranslateBrowsePathsToNodeIds(IAsyncResult result, out BrowsePathResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		TranslateBrowsePathsToNodeIdsResponse translateBrowsePathsToNodeIdsResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			translateBrowsePathsToNodeIdsResponse = (TranslateBrowsePathsToNodeIdsResponse)obj;
			results = translateBrowsePathsToNodeIdsResponse.Results;
			diagnosticInfos = translateBrowsePathsToNodeIdsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, translateBrowsePathsToNodeIdsResponse, "TranslateBrowsePathsToNodeIds");
		}
		return translateBrowsePathsToNodeIdsResponse.ResponseHeader;
	}

	public virtual async Task<TranslateBrowsePathsToNodeIdsResponse> TranslateBrowsePathsToNodeIdsAsync(RequestHeader requestHeader, BrowsePathCollection browsePaths, CancellationToken ct)
	{
		TranslateBrowsePathsToNodeIdsRequest request = new TranslateBrowsePathsToNodeIdsRequest();
		TranslateBrowsePathsToNodeIdsResponse response = null;
		request.RequestHeader = requestHeader;
		request.BrowsePaths = browsePaths;
		UpdateRequestHeader(request, requestHeader == null, "TranslateBrowsePathsToNodeIds");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (TranslateBrowsePathsToNodeIdsResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "TranslateBrowsePathsToNodeIds");
		}
		return response;
	}

	public virtual ResponseHeader RegisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToRegister, out NodeIdCollection registeredNodeIds)
	{
		RegisterNodesRequest registerNodesRequest = new RegisterNodesRequest();
		RegisterNodesResponse registerNodesResponse = null;
		registerNodesRequest.RequestHeader = requestHeader;
		registerNodesRequest.NodesToRegister = nodesToRegister;
		UpdateRequestHeader(registerNodesRequest, requestHeader == null, "RegisterNodes");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(registerNodesRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			registerNodesResponse = (RegisterNodesResponse)obj;
			registeredNodeIds = registerNodesResponse.RegisteredNodeIds;
		}
		finally
		{
			RequestCompleted(registerNodesRequest, registerNodesResponse, "RegisterNodes");
		}
		return registerNodesResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginRegisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToRegister, AsyncCallback callback, object asyncState)
	{
		RegisterNodesRequest registerNodesRequest = new RegisterNodesRequest();
		registerNodesRequest.RequestHeader = requestHeader;
		registerNodesRequest.NodesToRegister = nodesToRegister;
		UpdateRequestHeader(registerNodesRequest, requestHeader == null, "RegisterNodes");
		return base.TransportChannel.BeginSendRequest(registerNodesRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndRegisterNodes(IAsyncResult result, out NodeIdCollection registeredNodeIds)
	{
		RegisterNodesResponse registerNodesResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			registerNodesResponse = (RegisterNodesResponse)obj;
			registeredNodeIds = registerNodesResponse.RegisteredNodeIds;
		}
		finally
		{
			RequestCompleted(null, registerNodesResponse, "RegisterNodes");
		}
		return registerNodesResponse.ResponseHeader;
	}

	public virtual async Task<RegisterNodesResponse> RegisterNodesAsync(RequestHeader requestHeader, NodeIdCollection nodesToRegister, CancellationToken ct)
	{
		RegisterNodesRequest request = new RegisterNodesRequest();
		RegisterNodesResponse response = null;
		request.RequestHeader = requestHeader;
		request.NodesToRegister = nodesToRegister;
		UpdateRequestHeader(request, requestHeader == null, "RegisterNodes");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (RegisterNodesResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "RegisterNodes");
		}
		return response;
	}

	public virtual ResponseHeader UnregisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToUnregister)
	{
		UnregisterNodesRequest unregisterNodesRequest = new UnregisterNodesRequest();
		UnregisterNodesResponse unregisterNodesResponse = null;
		unregisterNodesRequest.RequestHeader = requestHeader;
		unregisterNodesRequest.NodesToUnregister = nodesToUnregister;
		UpdateRequestHeader(unregisterNodesRequest, requestHeader == null, "UnregisterNodes");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(unregisterNodesRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			unregisterNodesResponse = (UnregisterNodesResponse)obj;
		}
		finally
		{
			RequestCompleted(unregisterNodesRequest, unregisterNodesResponse, "UnregisterNodes");
		}
		return unregisterNodesResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginUnregisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToUnregister, AsyncCallback callback, object asyncState)
	{
		UnregisterNodesRequest unregisterNodesRequest = new UnregisterNodesRequest();
		unregisterNodesRequest.RequestHeader = requestHeader;
		unregisterNodesRequest.NodesToUnregister = nodesToUnregister;
		UpdateRequestHeader(unregisterNodesRequest, requestHeader == null, "UnregisterNodes");
		return base.TransportChannel.BeginSendRequest(unregisterNodesRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndUnregisterNodes(IAsyncResult result)
	{
		UnregisterNodesResponse unregisterNodesResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			unregisterNodesResponse = (UnregisterNodesResponse)obj;
		}
		finally
		{
			RequestCompleted(null, unregisterNodesResponse, "UnregisterNodes");
		}
		return unregisterNodesResponse.ResponseHeader;
	}

	public virtual async Task<UnregisterNodesResponse> UnregisterNodesAsync(RequestHeader requestHeader, NodeIdCollection nodesToUnregister, CancellationToken ct)
	{
		UnregisterNodesRequest request = new UnregisterNodesRequest();
		UnregisterNodesResponse response = null;
		request.RequestHeader = requestHeader;
		request.NodesToUnregister = nodesToUnregister;
		UpdateRequestHeader(request, requestHeader == null, "UnregisterNodes");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (UnregisterNodesResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "UnregisterNodes");
		}
		return response;
	}

	public virtual ResponseHeader QueryFirst(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, out QueryDataSetCollection queryDataSets, out byte[] continuationPoint, out ParsingResultCollection parsingResults, out DiagnosticInfoCollection diagnosticInfos, out ContentFilterResult filterResult)
	{
		QueryFirstRequest queryFirstRequest = new QueryFirstRequest();
		QueryFirstResponse queryFirstResponse = null;
		queryFirstRequest.RequestHeader = requestHeader;
		queryFirstRequest.View = view;
		queryFirstRequest.NodeTypes = nodeTypes;
		queryFirstRequest.Filter = filter;
		queryFirstRequest.MaxDataSetsToReturn = maxDataSetsToReturn;
		queryFirstRequest.MaxReferencesToReturn = maxReferencesToReturn;
		UpdateRequestHeader(queryFirstRequest, requestHeader == null, "QueryFirst");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(queryFirstRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			queryFirstResponse = (QueryFirstResponse)obj;
			queryDataSets = queryFirstResponse.QueryDataSets;
			continuationPoint = queryFirstResponse.ContinuationPoint;
			parsingResults = queryFirstResponse.ParsingResults;
			diagnosticInfos = queryFirstResponse.DiagnosticInfos;
			filterResult = queryFirstResponse.FilterResult;
		}
		finally
		{
			RequestCompleted(queryFirstRequest, queryFirstResponse, "QueryFirst");
		}
		return queryFirstResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginQueryFirst(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, AsyncCallback callback, object asyncState)
	{
		QueryFirstRequest queryFirstRequest = new QueryFirstRequest();
		queryFirstRequest.RequestHeader = requestHeader;
		queryFirstRequest.View = view;
		queryFirstRequest.NodeTypes = nodeTypes;
		queryFirstRequest.Filter = filter;
		queryFirstRequest.MaxDataSetsToReturn = maxDataSetsToReturn;
		queryFirstRequest.MaxReferencesToReturn = maxReferencesToReturn;
		UpdateRequestHeader(queryFirstRequest, requestHeader == null, "QueryFirst");
		return base.TransportChannel.BeginSendRequest(queryFirstRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndQueryFirst(IAsyncResult result, out QueryDataSetCollection queryDataSets, out byte[] continuationPoint, out ParsingResultCollection parsingResults, out DiagnosticInfoCollection diagnosticInfos, out ContentFilterResult filterResult)
	{
		QueryFirstResponse queryFirstResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			queryFirstResponse = (QueryFirstResponse)obj;
			queryDataSets = queryFirstResponse.QueryDataSets;
			continuationPoint = queryFirstResponse.ContinuationPoint;
			parsingResults = queryFirstResponse.ParsingResults;
			diagnosticInfos = queryFirstResponse.DiagnosticInfos;
			filterResult = queryFirstResponse.FilterResult;
		}
		finally
		{
			RequestCompleted(null, queryFirstResponse, "QueryFirst");
		}
		return queryFirstResponse.ResponseHeader;
	}

	public virtual async Task<QueryFirstResponse> QueryFirstAsync(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, CancellationToken ct)
	{
		QueryFirstRequest request = new QueryFirstRequest();
		QueryFirstResponse response = null;
		request.RequestHeader = requestHeader;
		request.View = view;
		request.NodeTypes = nodeTypes;
		request.Filter = filter;
		request.MaxDataSetsToReturn = maxDataSetsToReturn;
		request.MaxReferencesToReturn = maxReferencesToReturn;
		UpdateRequestHeader(request, requestHeader == null, "QueryFirst");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (QueryFirstResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "QueryFirst");
		}
		return response;
	}

	public virtual ResponseHeader QueryNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, out QueryDataSetCollection queryDataSets, out byte[] revisedContinuationPoint)
	{
		QueryNextRequest queryNextRequest = new QueryNextRequest();
		QueryNextResponse queryNextResponse = null;
		queryNextRequest.RequestHeader = requestHeader;
		queryNextRequest.ReleaseContinuationPoint = releaseContinuationPoint;
		queryNextRequest.ContinuationPoint = continuationPoint;
		UpdateRequestHeader(queryNextRequest, requestHeader == null, "QueryNext");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(queryNextRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			queryNextResponse = (QueryNextResponse)obj;
			queryDataSets = queryNextResponse.QueryDataSets;
			revisedContinuationPoint = queryNextResponse.RevisedContinuationPoint;
		}
		finally
		{
			RequestCompleted(queryNextRequest, queryNextResponse, "QueryNext");
		}
		return queryNextResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginQueryNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, AsyncCallback callback, object asyncState)
	{
		QueryNextRequest queryNextRequest = new QueryNextRequest();
		queryNextRequest.RequestHeader = requestHeader;
		queryNextRequest.ReleaseContinuationPoint = releaseContinuationPoint;
		queryNextRequest.ContinuationPoint = continuationPoint;
		UpdateRequestHeader(queryNextRequest, requestHeader == null, "QueryNext");
		return base.TransportChannel.BeginSendRequest(queryNextRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndQueryNext(IAsyncResult result, out QueryDataSetCollection queryDataSets, out byte[] revisedContinuationPoint)
	{
		QueryNextResponse queryNextResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			queryNextResponse = (QueryNextResponse)obj;
			queryDataSets = queryNextResponse.QueryDataSets;
			revisedContinuationPoint = queryNextResponse.RevisedContinuationPoint;
		}
		finally
		{
			RequestCompleted(null, queryNextResponse, "QueryNext");
		}
		return queryNextResponse.ResponseHeader;
	}

	public virtual async Task<QueryNextResponse> QueryNextAsync(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, CancellationToken ct)
	{
		QueryNextRequest request = new QueryNextRequest();
		QueryNextResponse response = null;
		request.RequestHeader = requestHeader;
		request.ReleaseContinuationPoint = releaseContinuationPoint;
		request.ContinuationPoint = continuationPoint;
		UpdateRequestHeader(request, requestHeader == null, "QueryNext");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (QueryNextResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "QueryNext");
		}
		return response;
	}

	public virtual ResponseHeader Read(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, out DataValueCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ReadRequest readRequest = new ReadRequest();
		ReadResponse readResponse = null;
		readRequest.RequestHeader = requestHeader;
		readRequest.MaxAge = maxAge;
		readRequest.TimestampsToReturn = timestampsToReturn;
		readRequest.NodesToRead = nodesToRead;
		UpdateRequestHeader(readRequest, requestHeader == null, "Read");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(readRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			readResponse = (ReadResponse)obj;
			results = readResponse.Results;
			diagnosticInfos = readResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(readRequest, readResponse, "Read");
		}
		return readResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginRead(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, AsyncCallback callback, object asyncState)
	{
		ReadRequest readRequest = new ReadRequest();
		readRequest.RequestHeader = requestHeader;
		readRequest.MaxAge = maxAge;
		readRequest.TimestampsToReturn = timestampsToReturn;
		readRequest.NodesToRead = nodesToRead;
		UpdateRequestHeader(readRequest, requestHeader == null, "Read");
		return base.TransportChannel.BeginSendRequest(readRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndRead(IAsyncResult result, out DataValueCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ReadResponse readResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			readResponse = (ReadResponse)obj;
			results = readResponse.Results;
			diagnosticInfos = readResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, readResponse, "Read");
		}
		return readResponse.ResponseHeader;
	}

	public virtual async Task<ReadResponse> ReadAsync(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, CancellationToken ct)
	{
		ReadRequest request = new ReadRequest();
		ReadResponse response = null;
		request.RequestHeader = requestHeader;
		request.MaxAge = maxAge;
		request.TimestampsToReturn = timestampsToReturn;
		request.NodesToRead = nodesToRead;
		UpdateRequestHeader(request, requestHeader == null, "Read");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (ReadResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "Read");
		}
		return response;
	}

	public virtual ResponseHeader HistoryRead(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, out HistoryReadResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		HistoryReadRequest historyReadRequest = new HistoryReadRequest();
		HistoryReadResponse historyReadResponse = null;
		historyReadRequest.RequestHeader = requestHeader;
		historyReadRequest.HistoryReadDetails = historyReadDetails;
		historyReadRequest.TimestampsToReturn = timestampsToReturn;
		historyReadRequest.ReleaseContinuationPoints = releaseContinuationPoints;
		historyReadRequest.NodesToRead = nodesToRead;
		UpdateRequestHeader(historyReadRequest, requestHeader == null, "HistoryRead");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(historyReadRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			historyReadResponse = (HistoryReadResponse)obj;
			results = historyReadResponse.Results;
			diagnosticInfos = historyReadResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(historyReadRequest, historyReadResponse, "HistoryRead");
		}
		return historyReadResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginHistoryRead(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, AsyncCallback callback, object asyncState)
	{
		HistoryReadRequest historyReadRequest = new HistoryReadRequest();
		historyReadRequest.RequestHeader = requestHeader;
		historyReadRequest.HistoryReadDetails = historyReadDetails;
		historyReadRequest.TimestampsToReturn = timestampsToReturn;
		historyReadRequest.ReleaseContinuationPoints = releaseContinuationPoints;
		historyReadRequest.NodesToRead = nodesToRead;
		UpdateRequestHeader(historyReadRequest, requestHeader == null, "HistoryRead");
		return base.TransportChannel.BeginSendRequest(historyReadRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndHistoryRead(IAsyncResult result, out HistoryReadResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		HistoryReadResponse historyReadResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			historyReadResponse = (HistoryReadResponse)obj;
			results = historyReadResponse.Results;
			diagnosticInfos = historyReadResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, historyReadResponse, "HistoryRead");
		}
		return historyReadResponse.ResponseHeader;
	}

	public virtual async Task<HistoryReadResponse> HistoryReadAsync(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, CancellationToken ct)
	{
		HistoryReadRequest request = new HistoryReadRequest();
		HistoryReadResponse response = null;
		request.RequestHeader = requestHeader;
		request.HistoryReadDetails = historyReadDetails;
		request.TimestampsToReturn = timestampsToReturn;
		request.ReleaseContinuationPoints = releaseContinuationPoints;
		request.NodesToRead = nodesToRead;
		UpdateRequestHeader(request, requestHeader == null, "HistoryRead");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (HistoryReadResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "HistoryRead");
		}
		return response;
	}

	public virtual ResponseHeader Write(RequestHeader requestHeader, WriteValueCollection nodesToWrite, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		WriteRequest writeRequest = new WriteRequest();
		WriteResponse writeResponse = null;
		writeRequest.RequestHeader = requestHeader;
		writeRequest.NodesToWrite = nodesToWrite;
		UpdateRequestHeader(writeRequest, requestHeader == null, "Write");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(writeRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			writeResponse = (WriteResponse)obj;
			results = writeResponse.Results;
			diagnosticInfos = writeResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(writeRequest, writeResponse, "Write");
		}
		return writeResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginWrite(RequestHeader requestHeader, WriteValueCollection nodesToWrite, AsyncCallback callback, object asyncState)
	{
		WriteRequest writeRequest = new WriteRequest();
		writeRequest.RequestHeader = requestHeader;
		writeRequest.NodesToWrite = nodesToWrite;
		UpdateRequestHeader(writeRequest, requestHeader == null, "Write");
		return base.TransportChannel.BeginSendRequest(writeRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndWrite(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		WriteResponse writeResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			writeResponse = (WriteResponse)obj;
			results = writeResponse.Results;
			diagnosticInfos = writeResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, writeResponse, "Write");
		}
		return writeResponse.ResponseHeader;
	}

	public virtual async Task<WriteResponse> WriteAsync(RequestHeader requestHeader, WriteValueCollection nodesToWrite, CancellationToken ct)
	{
		WriteRequest request = new WriteRequest();
		WriteResponse response = null;
		request.RequestHeader = requestHeader;
		request.NodesToWrite = nodesToWrite;
		UpdateRequestHeader(request, requestHeader == null, "Write");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (WriteResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "Write");
		}
		return response;
	}

	public virtual ResponseHeader HistoryUpdate(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, out HistoryUpdateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		HistoryUpdateRequest historyUpdateRequest = new HistoryUpdateRequest();
		HistoryUpdateResponse historyUpdateResponse = null;
		historyUpdateRequest.RequestHeader = requestHeader;
		historyUpdateRequest.HistoryUpdateDetails = historyUpdateDetails;
		UpdateRequestHeader(historyUpdateRequest, requestHeader == null, "HistoryUpdate");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(historyUpdateRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			historyUpdateResponse = (HistoryUpdateResponse)obj;
			results = historyUpdateResponse.Results;
			diagnosticInfos = historyUpdateResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(historyUpdateRequest, historyUpdateResponse, "HistoryUpdate");
		}
		return historyUpdateResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginHistoryUpdate(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, AsyncCallback callback, object asyncState)
	{
		HistoryUpdateRequest historyUpdateRequest = new HistoryUpdateRequest();
		historyUpdateRequest.RequestHeader = requestHeader;
		historyUpdateRequest.HistoryUpdateDetails = historyUpdateDetails;
		UpdateRequestHeader(historyUpdateRequest, requestHeader == null, "HistoryUpdate");
		return base.TransportChannel.BeginSendRequest(historyUpdateRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndHistoryUpdate(IAsyncResult result, out HistoryUpdateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		HistoryUpdateResponse historyUpdateResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			historyUpdateResponse = (HistoryUpdateResponse)obj;
			results = historyUpdateResponse.Results;
			diagnosticInfos = historyUpdateResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, historyUpdateResponse, "HistoryUpdate");
		}
		return historyUpdateResponse.ResponseHeader;
	}

	public virtual async Task<HistoryUpdateResponse> HistoryUpdateAsync(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, CancellationToken ct)
	{
		HistoryUpdateRequest request = new HistoryUpdateRequest();
		HistoryUpdateResponse response = null;
		request.RequestHeader = requestHeader;
		request.HistoryUpdateDetails = historyUpdateDetails;
		UpdateRequestHeader(request, requestHeader == null, "HistoryUpdate");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (HistoryUpdateResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "HistoryUpdate");
		}
		return response;
	}

	public virtual ResponseHeader Call(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, out CallMethodResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		CallRequest callRequest = new CallRequest();
		CallResponse callResponse = null;
		callRequest.RequestHeader = requestHeader;
		callRequest.MethodsToCall = methodsToCall;
		UpdateRequestHeader(callRequest, requestHeader == null, "Call");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(callRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			callResponse = (CallResponse)obj;
			results = callResponse.Results;
			diagnosticInfos = callResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(callRequest, callResponse, "Call");
		}
		return callResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginCall(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, AsyncCallback callback, object asyncState)
	{
		CallRequest callRequest = new CallRequest();
		callRequest.RequestHeader = requestHeader;
		callRequest.MethodsToCall = methodsToCall;
		UpdateRequestHeader(callRequest, requestHeader == null, "Call");
		return base.TransportChannel.BeginSendRequest(callRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndCall(IAsyncResult result, out CallMethodResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		CallResponse callResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			callResponse = (CallResponse)obj;
			results = callResponse.Results;
			diagnosticInfos = callResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, callResponse, "Call");
		}
		return callResponse.ResponseHeader;
	}

	public virtual async Task<CallResponse> CallAsync(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, CancellationToken ct)
	{
		CallRequest request = new CallRequest();
		CallResponse response = null;
		request.RequestHeader = requestHeader;
		request.MethodsToCall = methodsToCall;
		UpdateRequestHeader(request, requestHeader == null, "Call");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (CallResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "Call");
		}
		return response;
	}

	public virtual ResponseHeader CreateMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, out MonitoredItemCreateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		CreateMonitoredItemsRequest createMonitoredItemsRequest = new CreateMonitoredItemsRequest();
		CreateMonitoredItemsResponse createMonitoredItemsResponse = null;
		createMonitoredItemsRequest.RequestHeader = requestHeader;
		createMonitoredItemsRequest.SubscriptionId = subscriptionId;
		createMonitoredItemsRequest.TimestampsToReturn = timestampsToReturn;
		createMonitoredItemsRequest.ItemsToCreate = itemsToCreate;
		UpdateRequestHeader(createMonitoredItemsRequest, requestHeader == null, "CreateMonitoredItems");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(createMonitoredItemsRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			createMonitoredItemsResponse = (CreateMonitoredItemsResponse)obj;
			results = createMonitoredItemsResponse.Results;
			diagnosticInfos = createMonitoredItemsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(createMonitoredItemsRequest, createMonitoredItemsResponse, "CreateMonitoredItems");
		}
		return createMonitoredItemsResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginCreateMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, AsyncCallback callback, object asyncState)
	{
		CreateMonitoredItemsRequest createMonitoredItemsRequest = new CreateMonitoredItemsRequest();
		createMonitoredItemsRequest.RequestHeader = requestHeader;
		createMonitoredItemsRequest.SubscriptionId = subscriptionId;
		createMonitoredItemsRequest.TimestampsToReturn = timestampsToReturn;
		createMonitoredItemsRequest.ItemsToCreate = itemsToCreate;
		UpdateRequestHeader(createMonitoredItemsRequest, requestHeader == null, "CreateMonitoredItems");
		return base.TransportChannel.BeginSendRequest(createMonitoredItemsRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndCreateMonitoredItems(IAsyncResult result, out MonitoredItemCreateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		CreateMonitoredItemsResponse createMonitoredItemsResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			createMonitoredItemsResponse = (CreateMonitoredItemsResponse)obj;
			results = createMonitoredItemsResponse.Results;
			diagnosticInfos = createMonitoredItemsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, createMonitoredItemsResponse, "CreateMonitoredItems");
		}
		return createMonitoredItemsResponse.ResponseHeader;
	}

	public virtual async Task<CreateMonitoredItemsResponse> CreateMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, CancellationToken ct)
	{
		CreateMonitoredItemsRequest request = new CreateMonitoredItemsRequest();
		CreateMonitoredItemsResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionId = subscriptionId;
		request.TimestampsToReturn = timestampsToReturn;
		request.ItemsToCreate = itemsToCreate;
		UpdateRequestHeader(request, requestHeader == null, "CreateMonitoredItems");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (CreateMonitoredItemsResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "CreateMonitoredItems");
		}
		return response;
	}

	public virtual ResponseHeader ModifyMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, out MonitoredItemModifyResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ModifyMonitoredItemsRequest modifyMonitoredItemsRequest = new ModifyMonitoredItemsRequest();
		ModifyMonitoredItemsResponse modifyMonitoredItemsResponse = null;
		modifyMonitoredItemsRequest.RequestHeader = requestHeader;
		modifyMonitoredItemsRequest.SubscriptionId = subscriptionId;
		modifyMonitoredItemsRequest.TimestampsToReturn = timestampsToReturn;
		modifyMonitoredItemsRequest.ItemsToModify = itemsToModify;
		UpdateRequestHeader(modifyMonitoredItemsRequest, requestHeader == null, "ModifyMonitoredItems");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(modifyMonitoredItemsRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			modifyMonitoredItemsResponse = (ModifyMonitoredItemsResponse)obj;
			results = modifyMonitoredItemsResponse.Results;
			diagnosticInfos = modifyMonitoredItemsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(modifyMonitoredItemsRequest, modifyMonitoredItemsResponse, "ModifyMonitoredItems");
		}
		return modifyMonitoredItemsResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginModifyMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, AsyncCallback callback, object asyncState)
	{
		ModifyMonitoredItemsRequest modifyMonitoredItemsRequest = new ModifyMonitoredItemsRequest();
		modifyMonitoredItemsRequest.RequestHeader = requestHeader;
		modifyMonitoredItemsRequest.SubscriptionId = subscriptionId;
		modifyMonitoredItemsRequest.TimestampsToReturn = timestampsToReturn;
		modifyMonitoredItemsRequest.ItemsToModify = itemsToModify;
		UpdateRequestHeader(modifyMonitoredItemsRequest, requestHeader == null, "ModifyMonitoredItems");
		return base.TransportChannel.BeginSendRequest(modifyMonitoredItemsRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndModifyMonitoredItems(IAsyncResult result, out MonitoredItemModifyResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ModifyMonitoredItemsResponse modifyMonitoredItemsResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			modifyMonitoredItemsResponse = (ModifyMonitoredItemsResponse)obj;
			results = modifyMonitoredItemsResponse.Results;
			diagnosticInfos = modifyMonitoredItemsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, modifyMonitoredItemsResponse, "ModifyMonitoredItems");
		}
		return modifyMonitoredItemsResponse.ResponseHeader;
	}

	public virtual async Task<ModifyMonitoredItemsResponse> ModifyMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, CancellationToken ct)
	{
		ModifyMonitoredItemsRequest request = new ModifyMonitoredItemsRequest();
		ModifyMonitoredItemsResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionId = subscriptionId;
		request.TimestampsToReturn = timestampsToReturn;
		request.ItemsToModify = itemsToModify;
		UpdateRequestHeader(request, requestHeader == null, "ModifyMonitoredItems");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (ModifyMonitoredItemsResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "ModifyMonitoredItems");
		}
		return response;
	}

	public virtual ResponseHeader SetMonitoringMode(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		SetMonitoringModeRequest setMonitoringModeRequest = new SetMonitoringModeRequest();
		SetMonitoringModeResponse setMonitoringModeResponse = null;
		setMonitoringModeRequest.RequestHeader = requestHeader;
		setMonitoringModeRequest.SubscriptionId = subscriptionId;
		setMonitoringModeRequest.MonitoringMode = monitoringMode;
		setMonitoringModeRequest.MonitoredItemIds = monitoredItemIds;
		UpdateRequestHeader(setMonitoringModeRequest, requestHeader == null, "SetMonitoringMode");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(setMonitoringModeRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			setMonitoringModeResponse = (SetMonitoringModeResponse)obj;
			results = setMonitoringModeResponse.Results;
			diagnosticInfos = setMonitoringModeResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(setMonitoringModeRequest, setMonitoringModeResponse, "SetMonitoringMode");
		}
		return setMonitoringModeResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginSetMonitoringMode(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, AsyncCallback callback, object asyncState)
	{
		SetMonitoringModeRequest setMonitoringModeRequest = new SetMonitoringModeRequest();
		setMonitoringModeRequest.RequestHeader = requestHeader;
		setMonitoringModeRequest.SubscriptionId = subscriptionId;
		setMonitoringModeRequest.MonitoringMode = monitoringMode;
		setMonitoringModeRequest.MonitoredItemIds = monitoredItemIds;
		UpdateRequestHeader(setMonitoringModeRequest, requestHeader == null, "SetMonitoringMode");
		return base.TransportChannel.BeginSendRequest(setMonitoringModeRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndSetMonitoringMode(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		SetMonitoringModeResponse setMonitoringModeResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			setMonitoringModeResponse = (SetMonitoringModeResponse)obj;
			results = setMonitoringModeResponse.Results;
			diagnosticInfos = setMonitoringModeResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, setMonitoringModeResponse, "SetMonitoringMode");
		}
		return setMonitoringModeResponse.ResponseHeader;
	}

	public virtual async Task<SetMonitoringModeResponse> SetMonitoringModeAsync(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, CancellationToken ct)
	{
		SetMonitoringModeRequest request = new SetMonitoringModeRequest();
		SetMonitoringModeResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionId = subscriptionId;
		request.MonitoringMode = monitoringMode;
		request.MonitoredItemIds = monitoredItemIds;
		UpdateRequestHeader(request, requestHeader == null, "SetMonitoringMode");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (SetMonitoringModeResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "SetMonitoringMode");
		}
		return response;
	}

	public virtual ResponseHeader SetTriggering(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, out StatusCodeCollection addResults, out DiagnosticInfoCollection addDiagnosticInfos, out StatusCodeCollection removeResults, out DiagnosticInfoCollection removeDiagnosticInfos)
	{
		SetTriggeringRequest setTriggeringRequest = new SetTriggeringRequest();
		SetTriggeringResponse setTriggeringResponse = null;
		setTriggeringRequest.RequestHeader = requestHeader;
		setTriggeringRequest.SubscriptionId = subscriptionId;
		setTriggeringRequest.TriggeringItemId = triggeringItemId;
		setTriggeringRequest.LinksToAdd = linksToAdd;
		setTriggeringRequest.LinksToRemove = linksToRemove;
		UpdateRequestHeader(setTriggeringRequest, requestHeader == null, "SetTriggering");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(setTriggeringRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			setTriggeringResponse = (SetTriggeringResponse)obj;
			addResults = setTriggeringResponse.AddResults;
			addDiagnosticInfos = setTriggeringResponse.AddDiagnosticInfos;
			removeResults = setTriggeringResponse.RemoveResults;
			removeDiagnosticInfos = setTriggeringResponse.RemoveDiagnosticInfos;
		}
		finally
		{
			RequestCompleted(setTriggeringRequest, setTriggeringResponse, "SetTriggering");
		}
		return setTriggeringResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginSetTriggering(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, AsyncCallback callback, object asyncState)
	{
		SetTriggeringRequest setTriggeringRequest = new SetTriggeringRequest();
		setTriggeringRequest.RequestHeader = requestHeader;
		setTriggeringRequest.SubscriptionId = subscriptionId;
		setTriggeringRequest.TriggeringItemId = triggeringItemId;
		setTriggeringRequest.LinksToAdd = linksToAdd;
		setTriggeringRequest.LinksToRemove = linksToRemove;
		UpdateRequestHeader(setTriggeringRequest, requestHeader == null, "SetTriggering");
		return base.TransportChannel.BeginSendRequest(setTriggeringRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndSetTriggering(IAsyncResult result, out StatusCodeCollection addResults, out DiagnosticInfoCollection addDiagnosticInfos, out StatusCodeCollection removeResults, out DiagnosticInfoCollection removeDiagnosticInfos)
	{
		SetTriggeringResponse setTriggeringResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			setTriggeringResponse = (SetTriggeringResponse)obj;
			addResults = setTriggeringResponse.AddResults;
			addDiagnosticInfos = setTriggeringResponse.AddDiagnosticInfos;
			removeResults = setTriggeringResponse.RemoveResults;
			removeDiagnosticInfos = setTriggeringResponse.RemoveDiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, setTriggeringResponse, "SetTriggering");
		}
		return setTriggeringResponse.ResponseHeader;
	}

	public virtual async Task<SetTriggeringResponse> SetTriggeringAsync(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, CancellationToken ct)
	{
		SetTriggeringRequest request = new SetTriggeringRequest();
		SetTriggeringResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionId = subscriptionId;
		request.TriggeringItemId = triggeringItemId;
		request.LinksToAdd = linksToAdd;
		request.LinksToRemove = linksToRemove;
		UpdateRequestHeader(request, requestHeader == null, "SetTriggering");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (SetTriggeringResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "SetTriggering");
		}
		return response;
	}

	public virtual ResponseHeader DeleteMonitoredItems(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		DeleteMonitoredItemsRequest deleteMonitoredItemsRequest = new DeleteMonitoredItemsRequest();
		DeleteMonitoredItemsResponse deleteMonitoredItemsResponse = null;
		deleteMonitoredItemsRequest.RequestHeader = requestHeader;
		deleteMonitoredItemsRequest.SubscriptionId = subscriptionId;
		deleteMonitoredItemsRequest.MonitoredItemIds = monitoredItemIds;
		UpdateRequestHeader(deleteMonitoredItemsRequest, requestHeader == null, "DeleteMonitoredItems");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(deleteMonitoredItemsRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			deleteMonitoredItemsResponse = (DeleteMonitoredItemsResponse)obj;
			results = deleteMonitoredItemsResponse.Results;
			diagnosticInfos = deleteMonitoredItemsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(deleteMonitoredItemsRequest, deleteMonitoredItemsResponse, "DeleteMonitoredItems");
		}
		return deleteMonitoredItemsResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginDeleteMonitoredItems(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, AsyncCallback callback, object asyncState)
	{
		DeleteMonitoredItemsRequest deleteMonitoredItemsRequest = new DeleteMonitoredItemsRequest();
		deleteMonitoredItemsRequest.RequestHeader = requestHeader;
		deleteMonitoredItemsRequest.SubscriptionId = subscriptionId;
		deleteMonitoredItemsRequest.MonitoredItemIds = monitoredItemIds;
		UpdateRequestHeader(deleteMonitoredItemsRequest, requestHeader == null, "DeleteMonitoredItems");
		return base.TransportChannel.BeginSendRequest(deleteMonitoredItemsRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndDeleteMonitoredItems(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		DeleteMonitoredItemsResponse deleteMonitoredItemsResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			deleteMonitoredItemsResponse = (DeleteMonitoredItemsResponse)obj;
			results = deleteMonitoredItemsResponse.Results;
			diagnosticInfos = deleteMonitoredItemsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, deleteMonitoredItemsResponse, "DeleteMonitoredItems");
		}
		return deleteMonitoredItemsResponse.ResponseHeader;
	}

	public virtual async Task<DeleteMonitoredItemsResponse> DeleteMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, CancellationToken ct)
	{
		DeleteMonitoredItemsRequest request = new DeleteMonitoredItemsRequest();
		DeleteMonitoredItemsResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionId = subscriptionId;
		request.MonitoredItemIds = monitoredItemIds;
		UpdateRequestHeader(request, requestHeader == null, "DeleteMonitoredItems");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (DeleteMonitoredItemsResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "DeleteMonitoredItems");
		}
		return response;
	}

	public virtual ResponseHeader CreateSubscription(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, out uint subscriptionId, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount)
	{
		CreateSubscriptionRequest createSubscriptionRequest = new CreateSubscriptionRequest();
		CreateSubscriptionResponse createSubscriptionResponse = null;
		createSubscriptionRequest.RequestHeader = requestHeader;
		createSubscriptionRequest.RequestedPublishingInterval = requestedPublishingInterval;
		createSubscriptionRequest.RequestedLifetimeCount = requestedLifetimeCount;
		createSubscriptionRequest.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
		createSubscriptionRequest.MaxNotificationsPerPublish = maxNotificationsPerPublish;
		createSubscriptionRequest.PublishingEnabled = publishingEnabled;
		createSubscriptionRequest.Priority = priority;
		UpdateRequestHeader(createSubscriptionRequest, requestHeader == null, "CreateSubscription");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(createSubscriptionRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			createSubscriptionResponse = (CreateSubscriptionResponse)obj;
			subscriptionId = createSubscriptionResponse.SubscriptionId;
			revisedPublishingInterval = createSubscriptionResponse.RevisedPublishingInterval;
			revisedLifetimeCount = createSubscriptionResponse.RevisedLifetimeCount;
			revisedMaxKeepAliveCount = createSubscriptionResponse.RevisedMaxKeepAliveCount;
		}
		finally
		{
			RequestCompleted(createSubscriptionRequest, createSubscriptionResponse, "CreateSubscription");
		}
		return createSubscriptionResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginCreateSubscription(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, AsyncCallback callback, object asyncState)
	{
		CreateSubscriptionRequest createSubscriptionRequest = new CreateSubscriptionRequest();
		createSubscriptionRequest.RequestHeader = requestHeader;
		createSubscriptionRequest.RequestedPublishingInterval = requestedPublishingInterval;
		createSubscriptionRequest.RequestedLifetimeCount = requestedLifetimeCount;
		createSubscriptionRequest.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
		createSubscriptionRequest.MaxNotificationsPerPublish = maxNotificationsPerPublish;
		createSubscriptionRequest.PublishingEnabled = publishingEnabled;
		createSubscriptionRequest.Priority = priority;
		UpdateRequestHeader(createSubscriptionRequest, requestHeader == null, "CreateSubscription");
		return base.TransportChannel.BeginSendRequest(createSubscriptionRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndCreateSubscription(IAsyncResult result, out uint subscriptionId, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount)
	{
		CreateSubscriptionResponse createSubscriptionResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			createSubscriptionResponse = (CreateSubscriptionResponse)obj;
			subscriptionId = createSubscriptionResponse.SubscriptionId;
			revisedPublishingInterval = createSubscriptionResponse.RevisedPublishingInterval;
			revisedLifetimeCount = createSubscriptionResponse.RevisedLifetimeCount;
			revisedMaxKeepAliveCount = createSubscriptionResponse.RevisedMaxKeepAliveCount;
		}
		finally
		{
			RequestCompleted(null, createSubscriptionResponse, "CreateSubscription");
		}
		return createSubscriptionResponse.ResponseHeader;
	}

	public virtual async Task<CreateSubscriptionResponse> CreateSubscriptionAsync(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, CancellationToken ct)
	{
		CreateSubscriptionRequest request = new CreateSubscriptionRequest();
		CreateSubscriptionResponse response = null;
		request.RequestHeader = requestHeader;
		request.RequestedPublishingInterval = requestedPublishingInterval;
		request.RequestedLifetimeCount = requestedLifetimeCount;
		request.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
		request.MaxNotificationsPerPublish = maxNotificationsPerPublish;
		request.PublishingEnabled = publishingEnabled;
		request.Priority = priority;
		UpdateRequestHeader(request, requestHeader == null, "CreateSubscription");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (CreateSubscriptionResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "CreateSubscription");
		}
		return response;
	}

	public virtual ResponseHeader ModifySubscription(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount)
	{
		ModifySubscriptionRequest modifySubscriptionRequest = new ModifySubscriptionRequest();
		ModifySubscriptionResponse modifySubscriptionResponse = null;
		modifySubscriptionRequest.RequestHeader = requestHeader;
		modifySubscriptionRequest.SubscriptionId = subscriptionId;
		modifySubscriptionRequest.RequestedPublishingInterval = requestedPublishingInterval;
		modifySubscriptionRequest.RequestedLifetimeCount = requestedLifetimeCount;
		modifySubscriptionRequest.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
		modifySubscriptionRequest.MaxNotificationsPerPublish = maxNotificationsPerPublish;
		modifySubscriptionRequest.Priority = priority;
		UpdateRequestHeader(modifySubscriptionRequest, requestHeader == null, "ModifySubscription");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(modifySubscriptionRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			modifySubscriptionResponse = (ModifySubscriptionResponse)obj;
			revisedPublishingInterval = modifySubscriptionResponse.RevisedPublishingInterval;
			revisedLifetimeCount = modifySubscriptionResponse.RevisedLifetimeCount;
			revisedMaxKeepAliveCount = modifySubscriptionResponse.RevisedMaxKeepAliveCount;
		}
		finally
		{
			RequestCompleted(modifySubscriptionRequest, modifySubscriptionResponse, "ModifySubscription");
		}
		return modifySubscriptionResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginModifySubscription(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, AsyncCallback callback, object asyncState)
	{
		ModifySubscriptionRequest modifySubscriptionRequest = new ModifySubscriptionRequest();
		modifySubscriptionRequest.RequestHeader = requestHeader;
		modifySubscriptionRequest.SubscriptionId = subscriptionId;
		modifySubscriptionRequest.RequestedPublishingInterval = requestedPublishingInterval;
		modifySubscriptionRequest.RequestedLifetimeCount = requestedLifetimeCount;
		modifySubscriptionRequest.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
		modifySubscriptionRequest.MaxNotificationsPerPublish = maxNotificationsPerPublish;
		modifySubscriptionRequest.Priority = priority;
		UpdateRequestHeader(modifySubscriptionRequest, requestHeader == null, "ModifySubscription");
		return base.TransportChannel.BeginSendRequest(modifySubscriptionRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndModifySubscription(IAsyncResult result, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount)
	{
		ModifySubscriptionResponse modifySubscriptionResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			modifySubscriptionResponse = (ModifySubscriptionResponse)obj;
			revisedPublishingInterval = modifySubscriptionResponse.RevisedPublishingInterval;
			revisedLifetimeCount = modifySubscriptionResponse.RevisedLifetimeCount;
			revisedMaxKeepAliveCount = modifySubscriptionResponse.RevisedMaxKeepAliveCount;
		}
		finally
		{
			RequestCompleted(null, modifySubscriptionResponse, "ModifySubscription");
		}
		return modifySubscriptionResponse.ResponseHeader;
	}

	public virtual async Task<ModifySubscriptionResponse> ModifySubscriptionAsync(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, CancellationToken ct)
	{
		ModifySubscriptionRequest request = new ModifySubscriptionRequest();
		ModifySubscriptionResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionId = subscriptionId;
		request.RequestedPublishingInterval = requestedPublishingInterval;
		request.RequestedLifetimeCount = requestedLifetimeCount;
		request.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
		request.MaxNotificationsPerPublish = maxNotificationsPerPublish;
		request.Priority = priority;
		UpdateRequestHeader(request, requestHeader == null, "ModifySubscription");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (ModifySubscriptionResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "ModifySubscription");
		}
		return response;
	}

	public virtual ResponseHeader SetPublishingMode(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		SetPublishingModeRequest setPublishingModeRequest = new SetPublishingModeRequest();
		SetPublishingModeResponse setPublishingModeResponse = null;
		setPublishingModeRequest.RequestHeader = requestHeader;
		setPublishingModeRequest.PublishingEnabled = publishingEnabled;
		setPublishingModeRequest.SubscriptionIds = subscriptionIds;
		UpdateRequestHeader(setPublishingModeRequest, requestHeader == null, "SetPublishingMode");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(setPublishingModeRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			setPublishingModeResponse = (SetPublishingModeResponse)obj;
			results = setPublishingModeResponse.Results;
			diagnosticInfos = setPublishingModeResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(setPublishingModeRequest, setPublishingModeResponse, "SetPublishingMode");
		}
		return setPublishingModeResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginSetPublishingMode(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, AsyncCallback callback, object asyncState)
	{
		SetPublishingModeRequest setPublishingModeRequest = new SetPublishingModeRequest();
		setPublishingModeRequest.RequestHeader = requestHeader;
		setPublishingModeRequest.PublishingEnabled = publishingEnabled;
		setPublishingModeRequest.SubscriptionIds = subscriptionIds;
		UpdateRequestHeader(setPublishingModeRequest, requestHeader == null, "SetPublishingMode");
		return base.TransportChannel.BeginSendRequest(setPublishingModeRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndSetPublishingMode(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		SetPublishingModeResponse setPublishingModeResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			setPublishingModeResponse = (SetPublishingModeResponse)obj;
			results = setPublishingModeResponse.Results;
			diagnosticInfos = setPublishingModeResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, setPublishingModeResponse, "SetPublishingMode");
		}
		return setPublishingModeResponse.ResponseHeader;
	}

	public virtual async Task<SetPublishingModeResponse> SetPublishingModeAsync(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, CancellationToken ct)
	{
		SetPublishingModeRequest request = new SetPublishingModeRequest();
		SetPublishingModeResponse response = null;
		request.RequestHeader = requestHeader;
		request.PublishingEnabled = publishingEnabled;
		request.SubscriptionIds = subscriptionIds;
		UpdateRequestHeader(request, requestHeader == null, "SetPublishingMode");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (SetPublishingModeResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "SetPublishingMode");
		}
		return response;
	}

	public virtual ResponseHeader Publish(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, out uint subscriptionId, out UInt32Collection availableSequenceNumbers, out bool moreNotifications, out NotificationMessage notificationMessage, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		PublishRequest publishRequest = new PublishRequest();
		PublishResponse publishResponse = null;
		publishRequest.RequestHeader = requestHeader;
		publishRequest.SubscriptionAcknowledgements = subscriptionAcknowledgements;
		UpdateRequestHeader(publishRequest, requestHeader == null, "Publish");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(publishRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			publishResponse = (PublishResponse)obj;
			subscriptionId = publishResponse.SubscriptionId;
			availableSequenceNumbers = publishResponse.AvailableSequenceNumbers;
			moreNotifications = publishResponse.MoreNotifications;
			notificationMessage = publishResponse.NotificationMessage;
			results = publishResponse.Results;
			diagnosticInfos = publishResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(publishRequest, publishResponse, "Publish");
		}
		return publishResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginPublish(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, AsyncCallback callback, object asyncState)
	{
		PublishRequest publishRequest = new PublishRequest();
		publishRequest.RequestHeader = requestHeader;
		publishRequest.SubscriptionAcknowledgements = subscriptionAcknowledgements;
		UpdateRequestHeader(publishRequest, requestHeader == null, "Publish");
		return base.TransportChannel.BeginSendRequest(publishRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndPublish(IAsyncResult result, out uint subscriptionId, out UInt32Collection availableSequenceNumbers, out bool moreNotifications, out NotificationMessage notificationMessage, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		PublishResponse publishResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			publishResponse = (PublishResponse)obj;
			subscriptionId = publishResponse.SubscriptionId;
			availableSequenceNumbers = publishResponse.AvailableSequenceNumbers;
			moreNotifications = publishResponse.MoreNotifications;
			notificationMessage = publishResponse.NotificationMessage;
			results = publishResponse.Results;
			diagnosticInfos = publishResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, publishResponse, "Publish");
		}
		return publishResponse.ResponseHeader;
	}

	public virtual async Task<PublishResponse> PublishAsync(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, CancellationToken ct)
	{
		PublishRequest request = new PublishRequest();
		PublishResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionAcknowledgements = subscriptionAcknowledgements;
		UpdateRequestHeader(request, requestHeader == null, "Publish");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (PublishResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "Publish");
		}
		return response;
	}

	public virtual ResponseHeader Republish(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, out NotificationMessage notificationMessage)
	{
		RepublishRequest republishRequest = new RepublishRequest();
		RepublishResponse republishResponse = null;
		republishRequest.RequestHeader = requestHeader;
		republishRequest.SubscriptionId = subscriptionId;
		republishRequest.RetransmitSequenceNumber = retransmitSequenceNumber;
		UpdateRequestHeader(republishRequest, requestHeader == null, "Republish");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(republishRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			republishResponse = (RepublishResponse)obj;
			notificationMessage = republishResponse.NotificationMessage;
		}
		finally
		{
			RequestCompleted(republishRequest, republishResponse, "Republish");
		}
		return republishResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginRepublish(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, AsyncCallback callback, object asyncState)
	{
		RepublishRequest republishRequest = new RepublishRequest();
		republishRequest.RequestHeader = requestHeader;
		republishRequest.SubscriptionId = subscriptionId;
		republishRequest.RetransmitSequenceNumber = retransmitSequenceNumber;
		UpdateRequestHeader(republishRequest, requestHeader == null, "Republish");
		return base.TransportChannel.BeginSendRequest(republishRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndRepublish(IAsyncResult result, out NotificationMessage notificationMessage)
	{
		RepublishResponse republishResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			republishResponse = (RepublishResponse)obj;
			notificationMessage = republishResponse.NotificationMessage;
		}
		finally
		{
			RequestCompleted(null, republishResponse, "Republish");
		}
		return republishResponse.ResponseHeader;
	}

	public virtual async Task<RepublishResponse> RepublishAsync(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, CancellationToken ct)
	{
		RepublishRequest request = new RepublishRequest();
		RepublishResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionId = subscriptionId;
		request.RetransmitSequenceNumber = retransmitSequenceNumber;
		UpdateRequestHeader(request, requestHeader == null, "Republish");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (RepublishResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "Republish");
		}
		return response;
	}

	public virtual ResponseHeader TransferSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, out TransferResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		TransferSubscriptionsRequest transferSubscriptionsRequest = new TransferSubscriptionsRequest();
		TransferSubscriptionsResponse transferSubscriptionsResponse = null;
		transferSubscriptionsRequest.RequestHeader = requestHeader;
		transferSubscriptionsRequest.SubscriptionIds = subscriptionIds;
		transferSubscriptionsRequest.SendInitialValues = sendInitialValues;
		UpdateRequestHeader(transferSubscriptionsRequest, requestHeader == null, "TransferSubscriptions");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(transferSubscriptionsRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			transferSubscriptionsResponse = (TransferSubscriptionsResponse)obj;
			results = transferSubscriptionsResponse.Results;
			diagnosticInfos = transferSubscriptionsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(transferSubscriptionsRequest, transferSubscriptionsResponse, "TransferSubscriptions");
		}
		return transferSubscriptionsResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginTransferSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, AsyncCallback callback, object asyncState)
	{
		TransferSubscriptionsRequest transferSubscriptionsRequest = new TransferSubscriptionsRequest();
		transferSubscriptionsRequest.RequestHeader = requestHeader;
		transferSubscriptionsRequest.SubscriptionIds = subscriptionIds;
		transferSubscriptionsRequest.SendInitialValues = sendInitialValues;
		UpdateRequestHeader(transferSubscriptionsRequest, requestHeader == null, "TransferSubscriptions");
		return base.TransportChannel.BeginSendRequest(transferSubscriptionsRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndTransferSubscriptions(IAsyncResult result, out TransferResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		TransferSubscriptionsResponse transferSubscriptionsResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			transferSubscriptionsResponse = (TransferSubscriptionsResponse)obj;
			results = transferSubscriptionsResponse.Results;
			diagnosticInfos = transferSubscriptionsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, transferSubscriptionsResponse, "TransferSubscriptions");
		}
		return transferSubscriptionsResponse.ResponseHeader;
	}

	public virtual async Task<TransferSubscriptionsResponse> TransferSubscriptionsAsync(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, CancellationToken ct)
	{
		TransferSubscriptionsRequest request = new TransferSubscriptionsRequest();
		TransferSubscriptionsResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionIds = subscriptionIds;
		request.SendInitialValues = sendInitialValues;
		UpdateRequestHeader(request, requestHeader == null, "TransferSubscriptions");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (TransferSubscriptionsResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "TransferSubscriptions");
		}
		return response;
	}

	public virtual ResponseHeader DeleteSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		DeleteSubscriptionsRequest deleteSubscriptionsRequest = new DeleteSubscriptionsRequest();
		DeleteSubscriptionsResponse deleteSubscriptionsResponse = null;
		deleteSubscriptionsRequest.RequestHeader = requestHeader;
		deleteSubscriptionsRequest.SubscriptionIds = subscriptionIds;
		UpdateRequestHeader(deleteSubscriptionsRequest, requestHeader == null, "DeleteSubscriptions");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(deleteSubscriptionsRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			deleteSubscriptionsResponse = (DeleteSubscriptionsResponse)obj;
			results = deleteSubscriptionsResponse.Results;
			diagnosticInfos = deleteSubscriptionsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(deleteSubscriptionsRequest, deleteSubscriptionsResponse, "DeleteSubscriptions");
		}
		return deleteSubscriptionsResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginDeleteSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, AsyncCallback callback, object asyncState)
	{
		DeleteSubscriptionsRequest deleteSubscriptionsRequest = new DeleteSubscriptionsRequest();
		deleteSubscriptionsRequest.RequestHeader = requestHeader;
		deleteSubscriptionsRequest.SubscriptionIds = subscriptionIds;
		UpdateRequestHeader(deleteSubscriptionsRequest, requestHeader == null, "DeleteSubscriptions");
		return base.TransportChannel.BeginSendRequest(deleteSubscriptionsRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndDeleteSubscriptions(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		DeleteSubscriptionsResponse deleteSubscriptionsResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			deleteSubscriptionsResponse = (DeleteSubscriptionsResponse)obj;
			results = deleteSubscriptionsResponse.Results;
			diagnosticInfos = deleteSubscriptionsResponse.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, deleteSubscriptionsResponse, "DeleteSubscriptions");
		}
		return deleteSubscriptionsResponse.ResponseHeader;
	}

	public virtual async Task<DeleteSubscriptionsResponse> DeleteSubscriptionsAsync(RequestHeader requestHeader, UInt32Collection subscriptionIds, CancellationToken ct)
	{
		DeleteSubscriptionsRequest request = new DeleteSubscriptionsRequest();
		DeleteSubscriptionsResponse response = null;
		request.RequestHeader = requestHeader;
		request.SubscriptionIds = subscriptionIds;
		UpdateRequestHeader(request, requestHeader == null, "DeleteSubscriptions");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (DeleteSubscriptionsResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "DeleteSubscriptions");
		}
		return response;
	}
}
