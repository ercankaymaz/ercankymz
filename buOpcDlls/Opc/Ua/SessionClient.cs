// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionClient
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionClient(ITransportChannel channel) : 
  ClientBase(channel),
  ISessionClient,
  ISessionClientMethods,
  IClientBase,
  IDisposable
{
  private readonly object m_lock = new object();
  private NodeId m_sessionId;

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.m_sessionId = (NodeId) null;
    base.Dispose(disposing);
  }

  public NodeId SessionId => this.m_sessionId;

  public bool Connected => this.m_sessionId != (object) null;

  public virtual void SessionCreated(NodeId sessionId, NodeId sessionCookie)
  {
    lock (this.m_lock)
    {
      this.m_sessionId = sessionId;
      this.AuthenticationToken = sessionCookie;
    }
  }

  public ISessionChannel InnerChannel => (ISessionChannel) base.InnerChannel;

  public virtual ResponseHeader CreateSession(
    RequestHeader requestHeader,
    ApplicationDescription clientDescription,
    string serverUri,
    string endpointUrl,
    string sessionName,
    byte[] clientNonce,
    byte[] clientCertificate,
    double requestedSessionTimeout,
    uint maxResponseMessageSize,
    out NodeId sessionId,
    out NodeId authenticationToken,
    out double revisedSessionTimeout,
    out byte[] serverNonce,
    out byte[] serverCertificate,
    out EndpointDescriptionCollection serverEndpoints,
    out SignedSoftwareCertificateCollection serverSoftwareCertificates,
    out SignatureData serverSignature,
    out uint maxRequestMessageSize)
  {
    CreateSessionRequest request = new CreateSessionRequest();
    CreateSessionResponse response = (CreateSessionResponse) null;
    request.RequestHeader = requestHeader;
    request.ClientDescription = clientDescription;
    request.ServerUri = serverUri;
    request.EndpointUrl = endpointUrl;
    request.SessionName = sessionName;
    request.ClientNonce = clientNonce;
    request.ClientCertificate = clientCertificate;
    request.RequestedSessionTimeout = requestedSessionTimeout;
    request.MaxResponseMessageSize = maxResponseMessageSize;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (CreateSession));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CreateSessionResponse) serviceResponse;
      sessionId = response.SessionId;
      authenticationToken = response.AuthenticationToken;
      revisedSessionTimeout = response.RevisedSessionTimeout;
      serverNonce = response.ServerNonce;
      serverCertificate = response.ServerCertificate;
      serverEndpoints = response.ServerEndpoints;
      serverSoftwareCertificates = response.ServerSoftwareCertificates;
      serverSignature = response.ServerSignature;
      maxRequestMessageSize = response.MaxRequestMessageSize;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (CreateSession));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginCreateSession(
    RequestHeader requestHeader,
    ApplicationDescription clientDescription,
    string serverUri,
    string endpointUrl,
    string sessionName,
    byte[] clientNonce,
    byte[] clientCertificate,
    double requestedSessionTimeout,
    uint maxResponseMessageSize,
    AsyncCallback callback,
    object asyncState)
  {
    CreateSessionRequest request = new CreateSessionRequest();
    request.RequestHeader = requestHeader;
    request.ClientDescription = clientDescription;
    request.ServerUri = serverUri;
    request.EndpointUrl = endpointUrl;
    request.SessionName = sessionName;
    request.ClientNonce = clientNonce;
    request.ClientCertificate = clientCertificate;
    request.RequestedSessionTimeout = requestedSessionTimeout;
    request.MaxResponseMessageSize = maxResponseMessageSize;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "CreateSession");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndCreateSession(
    IAsyncResult result,
    out NodeId sessionId,
    out NodeId authenticationToken,
    out double revisedSessionTimeout,
    out byte[] serverNonce,
    out byte[] serverCertificate,
    out EndpointDescriptionCollection serverEndpoints,
    out SignedSoftwareCertificateCollection serverSoftwareCertificates,
    out SignatureData serverSignature,
    out uint maxRequestMessageSize)
  {
    CreateSessionResponse response = (CreateSessionResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CreateSessionResponse) serviceResponse;
      sessionId = response.SessionId;
      authenticationToken = response.AuthenticationToken;
      revisedSessionTimeout = response.RevisedSessionTimeout;
      serverNonce = response.ServerNonce;
      serverCertificate = response.ServerCertificate;
      serverEndpoints = response.ServerEndpoints;
      serverSoftwareCertificates = response.ServerSoftwareCertificates;
      serverSignature = response.ServerSignature;
      maxRequestMessageSize = response.MaxRequestMessageSize;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "CreateSession");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<CreateSessionResponse> CreateSessionAsync(
    RequestHeader requestHeader,
    ApplicationDescription clientDescription,
    string serverUri,
    string endpointUrl,
    string sessionName,
    byte[] clientNonce,
    byte[] clientCertificate,
    double requestedSessionTimeout,
    uint maxResponseMessageSize,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    CreateSessionRequest request = new CreateSessionRequest();
    CreateSessionResponse response = (CreateSessionResponse) null;
    request.RequestHeader = requestHeader;
    request.ClientDescription = clientDescription;
    request.ServerUri = serverUri;
    request.EndpointUrl = endpointUrl;
    request.SessionName = sessionName;
    request.ClientNonce = clientNonce;
    request.ClientCertificate = clientCertificate;
    request.RequestedSessionTimeout = requestedSessionTimeout;
    request.MaxResponseMessageSize = maxResponseMessageSize;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "CreateSession");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CreateSessionResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "CreateSession");
    }
    CreateSessionResponse sessionAsync = response;
    request = (CreateSessionRequest) null;
    response = (CreateSessionResponse) null;
    return sessionAsync;
  }

  public virtual ResponseHeader ActivateSession(
    RequestHeader requestHeader,
    SignatureData clientSignature,
    SignedSoftwareCertificateCollection clientSoftwareCertificates,
    StringCollection localeIds,
    ExtensionObject userIdentityToken,
    SignatureData userTokenSignature,
    out byte[] serverNonce,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ActivateSessionRequest request = new ActivateSessionRequest();
    ActivateSessionResponse response = (ActivateSessionResponse) null;
    request.RequestHeader = requestHeader;
    request.ClientSignature = clientSignature;
    request.ClientSoftwareCertificates = clientSoftwareCertificates;
    request.LocaleIds = localeIds;
    request.UserIdentityToken = userIdentityToken;
    request.UserTokenSignature = userTokenSignature;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (ActivateSession));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ActivateSessionResponse) serviceResponse;
      serverNonce = response.ServerNonce;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (ActivateSession));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginActivateSession(
    RequestHeader requestHeader,
    SignatureData clientSignature,
    SignedSoftwareCertificateCollection clientSoftwareCertificates,
    StringCollection localeIds,
    ExtensionObject userIdentityToken,
    SignatureData userTokenSignature,
    AsyncCallback callback,
    object asyncState)
  {
    ActivateSessionRequest request = new ActivateSessionRequest();
    request.RequestHeader = requestHeader;
    request.ClientSignature = clientSignature;
    request.ClientSoftwareCertificates = clientSoftwareCertificates;
    request.LocaleIds = localeIds;
    request.UserIdentityToken = userIdentityToken;
    request.UserTokenSignature = userTokenSignature;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "ActivateSession");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndActivateSession(
    IAsyncResult result,
    out byte[] serverNonce,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ActivateSessionResponse response = (ActivateSessionResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ActivateSessionResponse) serviceResponse;
      serverNonce = response.ServerNonce;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "ActivateSession");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<ActivateSessionResponse> ActivateSessionAsync(
    RequestHeader requestHeader,
    SignatureData clientSignature,
    SignedSoftwareCertificateCollection clientSoftwareCertificates,
    StringCollection localeIds,
    ExtensionObject userIdentityToken,
    SignatureData userTokenSignature,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    ActivateSessionRequest request = new ActivateSessionRequest();
    ActivateSessionResponse response = (ActivateSessionResponse) null;
    request.RequestHeader = requestHeader;
    request.ClientSignature = clientSignature;
    request.ClientSoftwareCertificates = clientSoftwareCertificates;
    request.LocaleIds = localeIds;
    request.UserIdentityToken = userIdentityToken;
    request.UserTokenSignature = userTokenSignature;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "ActivateSession");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ActivateSessionResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "ActivateSession");
    }
    ActivateSessionResponse activateSessionResponse = response;
    request = (ActivateSessionRequest) null;
    response = (ActivateSessionResponse) null;
    return activateSessionResponse;
  }

  public virtual ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions)
  {
    CloseSessionRequest request = new CloseSessionRequest();
    CloseSessionResponse response = (CloseSessionResponse) null;
    request.RequestHeader = requestHeader;
    request.DeleteSubscriptions = deleteSubscriptions;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (CloseSession));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CloseSessionResponse) serviceResponse;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (CloseSession));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginCloseSession(
    RequestHeader requestHeader,
    bool deleteSubscriptions,
    AsyncCallback callback,
    object asyncState)
  {
    CloseSessionRequest request = new CloseSessionRequest();
    request.RequestHeader = requestHeader;
    request.DeleteSubscriptions = deleteSubscriptions;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "CloseSession");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndCloseSession(IAsyncResult result)
  {
    CloseSessionResponse response = (CloseSessionResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CloseSessionResponse) serviceResponse;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "CloseSession");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<CloseSessionResponse> CloseSessionAsync(
    RequestHeader requestHeader,
    bool deleteSubscriptions,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    CloseSessionRequest request = new CloseSessionRequest();
    CloseSessionResponse response = (CloseSessionResponse) null;
    request.RequestHeader = requestHeader;
    request.DeleteSubscriptions = deleteSubscriptions;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "CloseSession");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CloseSessionResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "CloseSession");
    }
    CloseSessionResponse closeSessionResponse = response;
    request = (CloseSessionRequest) null;
    response = (CloseSessionResponse) null;
    return closeSessionResponse;
  }

  public virtual ResponseHeader Cancel(
    RequestHeader requestHeader,
    uint requestHandle,
    out uint cancelCount)
  {
    CancelRequest request = new CancelRequest();
    CancelResponse response = (CancelResponse) null;
    request.RequestHeader = requestHeader;
    request.RequestHandle = requestHandle;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (Cancel));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CancelResponse) serviceResponse;
      cancelCount = response.CancelCount;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (Cancel));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginCancel(
    RequestHeader requestHeader,
    uint requestHandle,
    AsyncCallback callback,
    object asyncState)
  {
    CancelRequest request = new CancelRequest();
    request.RequestHeader = requestHeader;
    request.RequestHandle = requestHandle;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Cancel");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndCancel(IAsyncResult result, out uint cancelCount)
  {
    CancelResponse response = (CancelResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CancelResponse) serviceResponse;
      cancelCount = response.CancelCount;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "Cancel");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<CancelResponse> CancelAsync(
    RequestHeader requestHeader,
    uint requestHandle,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    CancelRequest request = new CancelRequest();
    CancelResponse response = (CancelResponse) null;
    request.RequestHeader = requestHeader;
    request.RequestHandle = requestHandle;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Cancel");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CancelResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "Cancel");
    }
    CancelResponse cancelResponse = response;
    request = (CancelRequest) null;
    response = (CancelResponse) null;
    return cancelResponse;
  }

  public virtual ResponseHeader AddNodes(
    RequestHeader requestHeader,
    AddNodesItemCollection nodesToAdd,
    out AddNodesResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    AddNodesRequest request = new AddNodesRequest();
    AddNodesResponse response = (AddNodesResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToAdd = nodesToAdd;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (AddNodes));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (AddNodesResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (AddNodes));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginAddNodes(
    RequestHeader requestHeader,
    AddNodesItemCollection nodesToAdd,
    AsyncCallback callback,
    object asyncState)
  {
    AddNodesRequest request = new AddNodesRequest();
    request.RequestHeader = requestHeader;
    request.NodesToAdd = nodesToAdd;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "AddNodes");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndAddNodes(
    IAsyncResult result,
    out AddNodesResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    AddNodesResponse response = (AddNodesResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (AddNodesResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "AddNodes");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<AddNodesResponse> AddNodesAsync(
    RequestHeader requestHeader,
    AddNodesItemCollection nodesToAdd,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    AddNodesRequest request = new AddNodesRequest();
    AddNodesResponse response = (AddNodesResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToAdd = nodesToAdd;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "AddNodes");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (AddNodesResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "AddNodes");
    }
    AddNodesResponse addNodesResponse = response;
    request = (AddNodesRequest) null;
    response = (AddNodesResponse) null;
    return addNodesResponse;
  }

  public virtual ResponseHeader AddReferences(
    RequestHeader requestHeader,
    AddReferencesItemCollection referencesToAdd,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    AddReferencesRequest request = new AddReferencesRequest();
    AddReferencesResponse response = (AddReferencesResponse) null;
    request.RequestHeader = requestHeader;
    request.ReferencesToAdd = referencesToAdd;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (AddReferences));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (AddReferencesResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (AddReferences));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginAddReferences(
    RequestHeader requestHeader,
    AddReferencesItemCollection referencesToAdd,
    AsyncCallback callback,
    object asyncState)
  {
    AddReferencesRequest request = new AddReferencesRequest();
    request.RequestHeader = requestHeader;
    request.ReferencesToAdd = referencesToAdd;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "AddReferences");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndAddReferences(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    AddReferencesResponse response = (AddReferencesResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (AddReferencesResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "AddReferences");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<AddReferencesResponse> AddReferencesAsync(
    RequestHeader requestHeader,
    AddReferencesItemCollection referencesToAdd,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    AddReferencesRequest request = new AddReferencesRequest();
    AddReferencesResponse response = (AddReferencesResponse) null;
    request.RequestHeader = requestHeader;
    request.ReferencesToAdd = referencesToAdd;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "AddReferences");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (AddReferencesResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "AddReferences");
    }
    AddReferencesResponse referencesResponse = response;
    request = (AddReferencesRequest) null;
    response = (AddReferencesResponse) null;
    return referencesResponse;
  }

  public virtual ResponseHeader DeleteNodes(
    RequestHeader requestHeader,
    DeleteNodesItemCollection nodesToDelete,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    DeleteNodesRequest request = new DeleteNodesRequest();
    DeleteNodesResponse response = (DeleteNodesResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToDelete = nodesToDelete;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (DeleteNodes));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteNodesResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (DeleteNodes));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginDeleteNodes(
    RequestHeader requestHeader,
    DeleteNodesItemCollection nodesToDelete,
    AsyncCallback callback,
    object asyncState)
  {
    DeleteNodesRequest request = new DeleteNodesRequest();
    request.RequestHeader = requestHeader;
    request.NodesToDelete = nodesToDelete;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "DeleteNodes");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndDeleteNodes(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    DeleteNodesResponse response = (DeleteNodesResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteNodesResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "DeleteNodes");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<DeleteNodesResponse> DeleteNodesAsync(
    RequestHeader requestHeader,
    DeleteNodesItemCollection nodesToDelete,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    DeleteNodesRequest request = new DeleteNodesRequest();
    DeleteNodesResponse response = (DeleteNodesResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToDelete = nodesToDelete;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "DeleteNodes");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteNodesResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "DeleteNodes");
    }
    DeleteNodesResponse deleteNodesResponse = response;
    request = (DeleteNodesRequest) null;
    response = (DeleteNodesResponse) null;
    return deleteNodesResponse;
  }

  public virtual ResponseHeader DeleteReferences(
    RequestHeader requestHeader,
    DeleteReferencesItemCollection referencesToDelete,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    DeleteReferencesRequest request = new DeleteReferencesRequest();
    DeleteReferencesResponse response = (DeleteReferencesResponse) null;
    request.RequestHeader = requestHeader;
    request.ReferencesToDelete = referencesToDelete;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (DeleteReferences));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteReferencesResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (DeleteReferences));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginDeleteReferences(
    RequestHeader requestHeader,
    DeleteReferencesItemCollection referencesToDelete,
    AsyncCallback callback,
    object asyncState)
  {
    DeleteReferencesRequest request = new DeleteReferencesRequest();
    request.RequestHeader = requestHeader;
    request.ReferencesToDelete = referencesToDelete;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "DeleteReferences");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndDeleteReferences(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    DeleteReferencesResponse response = (DeleteReferencesResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteReferencesResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "DeleteReferences");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<DeleteReferencesResponse> DeleteReferencesAsync(
    RequestHeader requestHeader,
    DeleteReferencesItemCollection referencesToDelete,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    DeleteReferencesRequest request = new DeleteReferencesRequest();
    DeleteReferencesResponse response = (DeleteReferencesResponse) null;
    request.RequestHeader = requestHeader;
    request.ReferencesToDelete = referencesToDelete;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "DeleteReferences");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteReferencesResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "DeleteReferences");
    }
    DeleteReferencesResponse referencesResponse = response;
    request = (DeleteReferencesRequest) null;
    response = (DeleteReferencesResponse) null;
    return referencesResponse;
  }

  public virtual ResponseHeader Browse(
    RequestHeader requestHeader,
    ViewDescription view,
    uint requestedMaxReferencesPerNode,
    BrowseDescriptionCollection nodesToBrowse,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    BrowseRequest request = new BrowseRequest();
    BrowseResponse response = (BrowseResponse) null;
    request.RequestHeader = requestHeader;
    request.View = view;
    request.RequestedMaxReferencesPerNode = requestedMaxReferencesPerNode;
    request.NodesToBrowse = nodesToBrowse;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (Browse));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (BrowseResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (Browse));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginBrowse(
    RequestHeader requestHeader,
    ViewDescription view,
    uint requestedMaxReferencesPerNode,
    BrowseDescriptionCollection nodesToBrowse,
    AsyncCallback callback,
    object asyncState)
  {
    BrowseRequest request = new BrowseRequest();
    request.RequestHeader = requestHeader;
    request.View = view;
    request.RequestedMaxReferencesPerNode = requestedMaxReferencesPerNode;
    request.NodesToBrowse = nodesToBrowse;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Browse");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndBrowse(
    IAsyncResult result,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    BrowseResponse response = (BrowseResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (BrowseResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "Browse");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<BrowseResponse> BrowseAsync(
    RequestHeader requestHeader,
    ViewDescription view,
    uint requestedMaxReferencesPerNode,
    BrowseDescriptionCollection nodesToBrowse,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    BrowseRequest request = new BrowseRequest();
    BrowseResponse response = (BrowseResponse) null;
    request.RequestHeader = requestHeader;
    request.View = view;
    request.RequestedMaxReferencesPerNode = requestedMaxReferencesPerNode;
    request.NodesToBrowse = nodesToBrowse;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Browse");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (BrowseResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "Browse");
    }
    BrowseResponse browseResponse = response;
    request = (BrowseRequest) null;
    response = (BrowseResponse) null;
    return browseResponse;
  }

  public virtual ResponseHeader BrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoints,
    ByteStringCollection continuationPoints,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    BrowseNextRequest request = new BrowseNextRequest();
    BrowseNextResponse response = (BrowseNextResponse) null;
    request.RequestHeader = requestHeader;
    request.ReleaseContinuationPoints = releaseContinuationPoints;
    request.ContinuationPoints = continuationPoints;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (BrowseNext));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (BrowseNextResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (BrowseNext));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginBrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoints,
    ByteStringCollection continuationPoints,
    AsyncCallback callback,
    object asyncState)
  {
    BrowseNextRequest request = new BrowseNextRequest();
    request.RequestHeader = requestHeader;
    request.ReleaseContinuationPoints = releaseContinuationPoints;
    request.ContinuationPoints = continuationPoints;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "BrowseNext");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndBrowseNext(
    IAsyncResult result,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    BrowseNextResponse response = (BrowseNextResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (BrowseNextResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "BrowseNext");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<BrowseNextResponse> BrowseNextAsync(
    RequestHeader requestHeader,
    bool releaseContinuationPoints,
    ByteStringCollection continuationPoints,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    BrowseNextRequest request = new BrowseNextRequest();
    BrowseNextResponse response = (BrowseNextResponse) null;
    request.RequestHeader = requestHeader;
    request.ReleaseContinuationPoints = releaseContinuationPoints;
    request.ContinuationPoints = continuationPoints;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "BrowseNext");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (BrowseNextResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "BrowseNext");
    }
    BrowseNextResponse browseNextResponse = response;
    request = (BrowseNextRequest) null;
    response = (BrowseNextResponse) null;
    return browseNextResponse;
  }

  public virtual ResponseHeader TranslateBrowsePathsToNodeIds(
    RequestHeader requestHeader,
    BrowsePathCollection browsePaths,
    out BrowsePathResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    TranslateBrowsePathsToNodeIdsRequest request = new TranslateBrowsePathsToNodeIdsRequest();
    TranslateBrowsePathsToNodeIdsResponse response = (TranslateBrowsePathsToNodeIdsResponse) null;
    request.RequestHeader = requestHeader;
    request.BrowsePaths = browsePaths;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (TranslateBrowsePathsToNodeIds));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (TranslateBrowsePathsToNodeIdsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (TranslateBrowsePathsToNodeIds));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginTranslateBrowsePathsToNodeIds(
    RequestHeader requestHeader,
    BrowsePathCollection browsePaths,
    AsyncCallback callback,
    object asyncState)
  {
    TranslateBrowsePathsToNodeIdsRequest request = new TranslateBrowsePathsToNodeIdsRequest();
    request.RequestHeader = requestHeader;
    request.BrowsePaths = browsePaths;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "TranslateBrowsePathsToNodeIds");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndTranslateBrowsePathsToNodeIds(
    IAsyncResult result,
    out BrowsePathResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    TranslateBrowsePathsToNodeIdsResponse response = (TranslateBrowsePathsToNodeIdsResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (TranslateBrowsePathsToNodeIdsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "TranslateBrowsePathsToNodeIds");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<TranslateBrowsePathsToNodeIdsResponse> TranslateBrowsePathsToNodeIdsAsync(
    RequestHeader requestHeader,
    BrowsePathCollection browsePaths,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    TranslateBrowsePathsToNodeIdsRequest request = new TranslateBrowsePathsToNodeIdsRequest();
    TranslateBrowsePathsToNodeIdsResponse response = (TranslateBrowsePathsToNodeIdsResponse) null;
    request.RequestHeader = requestHeader;
    request.BrowsePaths = browsePaths;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "TranslateBrowsePathsToNodeIds");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (TranslateBrowsePathsToNodeIdsResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "TranslateBrowsePathsToNodeIds");
    }
    TranslateBrowsePathsToNodeIdsResponse nodeIdsAsync = response;
    request = (TranslateBrowsePathsToNodeIdsRequest) null;
    response = (TranslateBrowsePathsToNodeIdsResponse) null;
    return nodeIdsAsync;
  }

  public virtual ResponseHeader RegisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToRegister,
    out NodeIdCollection registeredNodeIds)
  {
    RegisterNodesRequest request = new RegisterNodesRequest();
    RegisterNodesResponse response = (RegisterNodesResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToRegister = nodesToRegister;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (RegisterNodes));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RegisterNodesResponse) serviceResponse;
      registeredNodeIds = response.RegisteredNodeIds;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (RegisterNodes));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginRegisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToRegister,
    AsyncCallback callback,
    object asyncState)
  {
    RegisterNodesRequest request = new RegisterNodesRequest();
    request.RequestHeader = requestHeader;
    request.NodesToRegister = nodesToRegister;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "RegisterNodes");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndRegisterNodes(
    IAsyncResult result,
    out NodeIdCollection registeredNodeIds)
  {
    RegisterNodesResponse response = (RegisterNodesResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RegisterNodesResponse) serviceResponse;
      registeredNodeIds = response.RegisteredNodeIds;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "RegisterNodes");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<RegisterNodesResponse> RegisterNodesAsync(
    RequestHeader requestHeader,
    NodeIdCollection nodesToRegister,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    RegisterNodesRequest request = new RegisterNodesRequest();
    RegisterNodesResponse response = (RegisterNodesResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToRegister = nodesToRegister;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "RegisterNodes");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RegisterNodesResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "RegisterNodes");
    }
    RegisterNodesResponse registerNodesResponse = response;
    request = (RegisterNodesRequest) null;
    response = (RegisterNodesResponse) null;
    return registerNodesResponse;
  }

  public virtual ResponseHeader UnregisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToUnregister)
  {
    UnregisterNodesRequest request = new UnregisterNodesRequest();
    UnregisterNodesResponse response = (UnregisterNodesResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToUnregister = nodesToUnregister;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (UnregisterNodes));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (UnregisterNodesResponse) serviceResponse;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (UnregisterNodes));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginUnregisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToUnregister,
    AsyncCallback callback,
    object asyncState)
  {
    UnregisterNodesRequest request = new UnregisterNodesRequest();
    request.RequestHeader = requestHeader;
    request.NodesToUnregister = nodesToUnregister;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "UnregisterNodes");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndUnregisterNodes(IAsyncResult result)
  {
    UnregisterNodesResponse response = (UnregisterNodesResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (UnregisterNodesResponse) serviceResponse;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "UnregisterNodes");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<UnregisterNodesResponse> UnregisterNodesAsync(
    RequestHeader requestHeader,
    NodeIdCollection nodesToUnregister,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    UnregisterNodesRequest request = new UnregisterNodesRequest();
    UnregisterNodesResponse response = (UnregisterNodesResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToUnregister = nodesToUnregister;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "UnregisterNodes");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (UnregisterNodesResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "UnregisterNodes");
    }
    UnregisterNodesResponse unregisterNodesResponse = response;
    request = (UnregisterNodesRequest) null;
    response = (UnregisterNodesResponse) null;
    return unregisterNodesResponse;
  }

  public virtual ResponseHeader QueryFirst(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeTypeDescriptionCollection nodeTypes,
    ContentFilter filter,
    uint maxDataSetsToReturn,
    uint maxReferencesToReturn,
    out QueryDataSetCollection queryDataSets,
    out byte[] continuationPoint,
    out ParsingResultCollection parsingResults,
    out DiagnosticInfoCollection diagnosticInfos,
    out ContentFilterResult filterResult)
  {
    QueryFirstRequest request = new QueryFirstRequest();
    QueryFirstResponse response = (QueryFirstResponse) null;
    request.RequestHeader = requestHeader;
    request.View = view;
    request.NodeTypes = nodeTypes;
    request.Filter = filter;
    request.MaxDataSetsToReturn = maxDataSetsToReturn;
    request.MaxReferencesToReturn = maxReferencesToReturn;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (QueryFirst));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (QueryFirstResponse) serviceResponse;
      queryDataSets = response.QueryDataSets;
      continuationPoint = response.ContinuationPoint;
      parsingResults = response.ParsingResults;
      diagnosticInfos = response.DiagnosticInfos;
      filterResult = response.FilterResult;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (QueryFirst));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginQueryFirst(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeTypeDescriptionCollection nodeTypes,
    ContentFilter filter,
    uint maxDataSetsToReturn,
    uint maxReferencesToReturn,
    AsyncCallback callback,
    object asyncState)
  {
    QueryFirstRequest request = new QueryFirstRequest();
    request.RequestHeader = requestHeader;
    request.View = view;
    request.NodeTypes = nodeTypes;
    request.Filter = filter;
    request.MaxDataSetsToReturn = maxDataSetsToReturn;
    request.MaxReferencesToReturn = maxReferencesToReturn;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "QueryFirst");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndQueryFirst(
    IAsyncResult result,
    out QueryDataSetCollection queryDataSets,
    out byte[] continuationPoint,
    out ParsingResultCollection parsingResults,
    out DiagnosticInfoCollection diagnosticInfos,
    out ContentFilterResult filterResult)
  {
    QueryFirstResponse response = (QueryFirstResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (QueryFirstResponse) serviceResponse;
      queryDataSets = response.QueryDataSets;
      continuationPoint = response.ContinuationPoint;
      parsingResults = response.ParsingResults;
      diagnosticInfos = response.DiagnosticInfos;
      filterResult = response.FilterResult;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "QueryFirst");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<QueryFirstResponse> QueryFirstAsync(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeTypeDescriptionCollection nodeTypes,
    ContentFilter filter,
    uint maxDataSetsToReturn,
    uint maxReferencesToReturn,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    QueryFirstRequest request = new QueryFirstRequest();
    QueryFirstResponse response = (QueryFirstResponse) null;
    request.RequestHeader = requestHeader;
    request.View = view;
    request.NodeTypes = nodeTypes;
    request.Filter = filter;
    request.MaxDataSetsToReturn = maxDataSetsToReturn;
    request.MaxReferencesToReturn = maxReferencesToReturn;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "QueryFirst");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (QueryFirstResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "QueryFirst");
    }
    QueryFirstResponse queryFirstResponse = response;
    request = (QueryFirstRequest) null;
    response = (QueryFirstResponse) null;
    return queryFirstResponse;
  }

  public virtual ResponseHeader QueryNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    out QueryDataSetCollection queryDataSets,
    out byte[] revisedContinuationPoint)
  {
    QueryNextRequest request = new QueryNextRequest();
    QueryNextResponse response = (QueryNextResponse) null;
    request.RequestHeader = requestHeader;
    request.ReleaseContinuationPoint = releaseContinuationPoint;
    request.ContinuationPoint = continuationPoint;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (QueryNext));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (QueryNextResponse) serviceResponse;
      queryDataSets = response.QueryDataSets;
      revisedContinuationPoint = response.RevisedContinuationPoint;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (QueryNext));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginQueryNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    AsyncCallback callback,
    object asyncState)
  {
    QueryNextRequest request = new QueryNextRequest();
    request.RequestHeader = requestHeader;
    request.ReleaseContinuationPoint = releaseContinuationPoint;
    request.ContinuationPoint = continuationPoint;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "QueryNext");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndQueryNext(
    IAsyncResult result,
    out QueryDataSetCollection queryDataSets,
    out byte[] revisedContinuationPoint)
  {
    QueryNextResponse response = (QueryNextResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (QueryNextResponse) serviceResponse;
      queryDataSets = response.QueryDataSets;
      revisedContinuationPoint = response.RevisedContinuationPoint;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "QueryNext");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<QueryNextResponse> QueryNextAsync(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    QueryNextRequest request = new QueryNextRequest();
    QueryNextResponse response = (QueryNextResponse) null;
    request.RequestHeader = requestHeader;
    request.ReleaseContinuationPoint = releaseContinuationPoint;
    request.ContinuationPoint = continuationPoint;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "QueryNext");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (QueryNextResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "QueryNext");
    }
    QueryNextResponse queryNextResponse = response;
    request = (QueryNextRequest) null;
    response = (QueryNextResponse) null;
    return queryNextResponse;
  }

  public virtual ResponseHeader Read(
    RequestHeader requestHeader,
    double maxAge,
    TimestampsToReturn timestampsToReturn,
    ReadValueIdCollection nodesToRead,
    out DataValueCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ReadRequest request = new ReadRequest();
    ReadResponse response = (ReadResponse) null;
    request.RequestHeader = requestHeader;
    request.MaxAge = maxAge;
    request.TimestampsToReturn = timestampsToReturn;
    request.NodesToRead = nodesToRead;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (Read));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ReadResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (Read));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginRead(
    RequestHeader requestHeader,
    double maxAge,
    TimestampsToReturn timestampsToReturn,
    ReadValueIdCollection nodesToRead,
    AsyncCallback callback,
    object asyncState)
  {
    ReadRequest request = new ReadRequest();
    request.RequestHeader = requestHeader;
    request.MaxAge = maxAge;
    request.TimestampsToReturn = timestampsToReturn;
    request.NodesToRead = nodesToRead;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Read");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndRead(
    IAsyncResult result,
    out DataValueCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ReadResponse response = (ReadResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ReadResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "Read");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<ReadResponse> ReadAsync(
    RequestHeader requestHeader,
    double maxAge,
    TimestampsToReturn timestampsToReturn,
    ReadValueIdCollection nodesToRead,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    ReadRequest request = new ReadRequest();
    ReadResponse response = (ReadResponse) null;
    request.RequestHeader = requestHeader;
    request.MaxAge = maxAge;
    request.TimestampsToReturn = timestampsToReturn;
    request.NodesToRead = nodesToRead;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Read");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ReadResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "Read");
    }
    ReadResponse readResponse = response;
    request = (ReadRequest) null;
    response = (ReadResponse) null;
    return readResponse;
  }

  public virtual ResponseHeader HistoryRead(
    RequestHeader requestHeader,
    ExtensionObject historyReadDetails,
    TimestampsToReturn timestampsToReturn,
    bool releaseContinuationPoints,
    HistoryReadValueIdCollection nodesToRead,
    out HistoryReadResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    HistoryReadRequest request = new HistoryReadRequest();
    HistoryReadResponse response = (HistoryReadResponse) null;
    request.RequestHeader = requestHeader;
    request.HistoryReadDetails = historyReadDetails;
    request.TimestampsToReturn = timestampsToReturn;
    request.ReleaseContinuationPoints = releaseContinuationPoints;
    request.NodesToRead = nodesToRead;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (HistoryRead));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (HistoryReadResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (HistoryRead));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginHistoryRead(
    RequestHeader requestHeader,
    ExtensionObject historyReadDetails,
    TimestampsToReturn timestampsToReturn,
    bool releaseContinuationPoints,
    HistoryReadValueIdCollection nodesToRead,
    AsyncCallback callback,
    object asyncState)
  {
    HistoryReadRequest request = new HistoryReadRequest();
    request.RequestHeader = requestHeader;
    request.HistoryReadDetails = historyReadDetails;
    request.TimestampsToReturn = timestampsToReturn;
    request.ReleaseContinuationPoints = releaseContinuationPoints;
    request.NodesToRead = nodesToRead;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "HistoryRead");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndHistoryRead(
    IAsyncResult result,
    out HistoryReadResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    HistoryReadResponse response = (HistoryReadResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (HistoryReadResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "HistoryRead");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<HistoryReadResponse> HistoryReadAsync(
    RequestHeader requestHeader,
    ExtensionObject historyReadDetails,
    TimestampsToReturn timestampsToReturn,
    bool releaseContinuationPoints,
    HistoryReadValueIdCollection nodesToRead,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    HistoryReadRequest request = new HistoryReadRequest();
    HistoryReadResponse response = (HistoryReadResponse) null;
    request.RequestHeader = requestHeader;
    request.HistoryReadDetails = historyReadDetails;
    request.TimestampsToReturn = timestampsToReturn;
    request.ReleaseContinuationPoints = releaseContinuationPoints;
    request.NodesToRead = nodesToRead;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "HistoryRead");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (HistoryReadResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "HistoryRead");
    }
    HistoryReadResponse historyReadResponse = response;
    request = (HistoryReadRequest) null;
    response = (HistoryReadResponse) null;
    return historyReadResponse;
  }

  public virtual ResponseHeader Write(
    RequestHeader requestHeader,
    WriteValueCollection nodesToWrite,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    WriteRequest request = new WriteRequest();
    WriteResponse response = (WriteResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToWrite = nodesToWrite;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (Write));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (WriteResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (Write));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginWrite(
    RequestHeader requestHeader,
    WriteValueCollection nodesToWrite,
    AsyncCallback callback,
    object asyncState)
  {
    WriteRequest request = new WriteRequest();
    request.RequestHeader = requestHeader;
    request.NodesToWrite = nodesToWrite;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Write");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndWrite(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    WriteResponse response = (WriteResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (WriteResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "Write");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<WriteResponse> WriteAsync(
    RequestHeader requestHeader,
    WriteValueCollection nodesToWrite,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    WriteRequest request = new WriteRequest();
    WriteResponse response = (WriteResponse) null;
    request.RequestHeader = requestHeader;
    request.NodesToWrite = nodesToWrite;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Write");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (WriteResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "Write");
    }
    WriteResponse writeResponse = response;
    request = (WriteRequest) null;
    response = (WriteResponse) null;
    return writeResponse;
  }

  public virtual ResponseHeader HistoryUpdate(
    RequestHeader requestHeader,
    ExtensionObjectCollection historyUpdateDetails,
    out HistoryUpdateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    HistoryUpdateRequest request = new HistoryUpdateRequest();
    HistoryUpdateResponse response = (HistoryUpdateResponse) null;
    request.RequestHeader = requestHeader;
    request.HistoryUpdateDetails = historyUpdateDetails;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (HistoryUpdate));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (HistoryUpdateResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (HistoryUpdate));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginHistoryUpdate(
    RequestHeader requestHeader,
    ExtensionObjectCollection historyUpdateDetails,
    AsyncCallback callback,
    object asyncState)
  {
    HistoryUpdateRequest request = new HistoryUpdateRequest();
    request.RequestHeader = requestHeader;
    request.HistoryUpdateDetails = historyUpdateDetails;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "HistoryUpdate");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndHistoryUpdate(
    IAsyncResult result,
    out HistoryUpdateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    HistoryUpdateResponse response = (HistoryUpdateResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (HistoryUpdateResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "HistoryUpdate");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<HistoryUpdateResponse> HistoryUpdateAsync(
    RequestHeader requestHeader,
    ExtensionObjectCollection historyUpdateDetails,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    HistoryUpdateRequest request = new HistoryUpdateRequest();
    HistoryUpdateResponse response = (HistoryUpdateResponse) null;
    request.RequestHeader = requestHeader;
    request.HistoryUpdateDetails = historyUpdateDetails;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "HistoryUpdate");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (HistoryUpdateResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "HistoryUpdate");
    }
    HistoryUpdateResponse historyUpdateResponse = response;
    request = (HistoryUpdateRequest) null;
    response = (HistoryUpdateResponse) null;
    return historyUpdateResponse;
  }

  public virtual ResponseHeader Call(
    RequestHeader requestHeader,
    CallMethodRequestCollection methodsToCall,
    out CallMethodResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    CallRequest request = new CallRequest();
    CallResponse response = (CallResponse) null;
    request.RequestHeader = requestHeader;
    request.MethodsToCall = methodsToCall;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (Call));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CallResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (Call));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginCall(
    RequestHeader requestHeader,
    CallMethodRequestCollection methodsToCall,
    AsyncCallback callback,
    object asyncState)
  {
    CallRequest request = new CallRequest();
    request.RequestHeader = requestHeader;
    request.MethodsToCall = methodsToCall;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Call");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndCall(
    IAsyncResult result,
    out CallMethodResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    CallResponse response = (CallResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CallResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "Call");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<CallResponse> CallAsync(
    RequestHeader requestHeader,
    CallMethodRequestCollection methodsToCall,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    CallRequest request = new CallRequest();
    CallResponse response = (CallResponse) null;
    request.RequestHeader = requestHeader;
    request.MethodsToCall = methodsToCall;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Call");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CallResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "Call");
    }
    CallResponse callResponse = response;
    request = (CallRequest) null;
    response = (CallResponse) null;
    return callResponse;
  }

  public virtual ResponseHeader CreateMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemCreateRequestCollection itemsToCreate,
    out MonitoredItemCreateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    CreateMonitoredItemsRequest request = new CreateMonitoredItemsRequest();
    CreateMonitoredItemsResponse response = (CreateMonitoredItemsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.TimestampsToReturn = timestampsToReturn;
    request.ItemsToCreate = itemsToCreate;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (CreateMonitoredItems));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CreateMonitoredItemsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (CreateMonitoredItems));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginCreateMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemCreateRequestCollection itemsToCreate,
    AsyncCallback callback,
    object asyncState)
  {
    CreateMonitoredItemsRequest request = new CreateMonitoredItemsRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.TimestampsToReturn = timestampsToReturn;
    request.ItemsToCreate = itemsToCreate;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "CreateMonitoredItems");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndCreateMonitoredItems(
    IAsyncResult result,
    out MonitoredItemCreateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    CreateMonitoredItemsResponse response = (CreateMonitoredItemsResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CreateMonitoredItemsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "CreateMonitoredItems");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<CreateMonitoredItemsResponse> CreateMonitoredItemsAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemCreateRequestCollection itemsToCreate,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    CreateMonitoredItemsRequest request = new CreateMonitoredItemsRequest();
    CreateMonitoredItemsResponse response = (CreateMonitoredItemsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.TimestampsToReturn = timestampsToReturn;
    request.ItemsToCreate = itemsToCreate;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "CreateMonitoredItems");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CreateMonitoredItemsResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "CreateMonitoredItems");
    }
    CreateMonitoredItemsResponse monitoredItemsAsync = response;
    request = (CreateMonitoredItemsRequest) null;
    response = (CreateMonitoredItemsResponse) null;
    return monitoredItemsAsync;
  }

  public virtual ResponseHeader ModifyMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemModifyRequestCollection itemsToModify,
    out MonitoredItemModifyResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ModifyMonitoredItemsRequest request = new ModifyMonitoredItemsRequest();
    ModifyMonitoredItemsResponse response = (ModifyMonitoredItemsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.TimestampsToReturn = timestampsToReturn;
    request.ItemsToModify = itemsToModify;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (ModifyMonitoredItems));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ModifyMonitoredItemsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (ModifyMonitoredItems));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginModifyMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemModifyRequestCollection itemsToModify,
    AsyncCallback callback,
    object asyncState)
  {
    ModifyMonitoredItemsRequest request = new ModifyMonitoredItemsRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.TimestampsToReturn = timestampsToReturn;
    request.ItemsToModify = itemsToModify;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "ModifyMonitoredItems");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndModifyMonitoredItems(
    IAsyncResult result,
    out MonitoredItemModifyResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ModifyMonitoredItemsResponse response = (ModifyMonitoredItemsResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ModifyMonitoredItemsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "ModifyMonitoredItems");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<ModifyMonitoredItemsResponse> ModifyMonitoredItemsAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemModifyRequestCollection itemsToModify,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    ModifyMonitoredItemsRequest request = new ModifyMonitoredItemsRequest();
    ModifyMonitoredItemsResponse response = (ModifyMonitoredItemsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.TimestampsToReturn = timestampsToReturn;
    request.ItemsToModify = itemsToModify;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "ModifyMonitoredItems");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ModifyMonitoredItemsResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "ModifyMonitoredItems");
    }
    ModifyMonitoredItemsResponse monitoredItemsResponse = response;
    request = (ModifyMonitoredItemsRequest) null;
    response = (ModifyMonitoredItemsResponse) null;
    return monitoredItemsResponse;
  }

  public virtual ResponseHeader SetMonitoringMode(
    RequestHeader requestHeader,
    uint subscriptionId,
    MonitoringMode monitoringMode,
    UInt32Collection monitoredItemIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    SetMonitoringModeRequest request = new SetMonitoringModeRequest();
    SetMonitoringModeResponse response = (SetMonitoringModeResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.MonitoringMode = monitoringMode;
    request.MonitoredItemIds = monitoredItemIds;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (SetMonitoringMode));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (SetMonitoringModeResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (SetMonitoringMode));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginSetMonitoringMode(
    RequestHeader requestHeader,
    uint subscriptionId,
    MonitoringMode monitoringMode,
    UInt32Collection monitoredItemIds,
    AsyncCallback callback,
    object asyncState)
  {
    SetMonitoringModeRequest request = new SetMonitoringModeRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.MonitoringMode = monitoringMode;
    request.MonitoredItemIds = monitoredItemIds;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "SetMonitoringMode");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndSetMonitoringMode(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    SetMonitoringModeResponse response = (SetMonitoringModeResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (SetMonitoringModeResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "SetMonitoringMode");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<SetMonitoringModeResponse> SetMonitoringModeAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    MonitoringMode monitoringMode,
    UInt32Collection monitoredItemIds,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    SetMonitoringModeRequest request = new SetMonitoringModeRequest();
    SetMonitoringModeResponse response = (SetMonitoringModeResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.MonitoringMode = monitoringMode;
    request.MonitoredItemIds = monitoredItemIds;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "SetMonitoringMode");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (SetMonitoringModeResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "SetMonitoringMode");
    }
    SetMonitoringModeResponse monitoringModeResponse = response;
    request = (SetMonitoringModeRequest) null;
    response = (SetMonitoringModeResponse) null;
    return monitoringModeResponse;
  }

  public virtual ResponseHeader SetTriggering(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint triggeringItemId,
    UInt32Collection linksToAdd,
    UInt32Collection linksToRemove,
    out StatusCodeCollection addResults,
    out DiagnosticInfoCollection addDiagnosticInfos,
    out StatusCodeCollection removeResults,
    out DiagnosticInfoCollection removeDiagnosticInfos)
  {
    SetTriggeringRequest request = new SetTriggeringRequest();
    SetTriggeringResponse response = (SetTriggeringResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.TriggeringItemId = triggeringItemId;
    request.LinksToAdd = linksToAdd;
    request.LinksToRemove = linksToRemove;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (SetTriggering));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (SetTriggeringResponse) serviceResponse;
      addResults = response.AddResults;
      addDiagnosticInfos = response.AddDiagnosticInfos;
      removeResults = response.RemoveResults;
      removeDiagnosticInfos = response.RemoveDiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (SetTriggering));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginSetTriggering(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint triggeringItemId,
    UInt32Collection linksToAdd,
    UInt32Collection linksToRemove,
    AsyncCallback callback,
    object asyncState)
  {
    SetTriggeringRequest request = new SetTriggeringRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.TriggeringItemId = triggeringItemId;
    request.LinksToAdd = linksToAdd;
    request.LinksToRemove = linksToRemove;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "SetTriggering");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndSetTriggering(
    IAsyncResult result,
    out StatusCodeCollection addResults,
    out DiagnosticInfoCollection addDiagnosticInfos,
    out StatusCodeCollection removeResults,
    out DiagnosticInfoCollection removeDiagnosticInfos)
  {
    SetTriggeringResponse response = (SetTriggeringResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (SetTriggeringResponse) serviceResponse;
      addResults = response.AddResults;
      addDiagnosticInfos = response.AddDiagnosticInfos;
      removeResults = response.RemoveResults;
      removeDiagnosticInfos = response.RemoveDiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "SetTriggering");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<SetTriggeringResponse> SetTriggeringAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint triggeringItemId,
    UInt32Collection linksToAdd,
    UInt32Collection linksToRemove,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    SetTriggeringRequest request = new SetTriggeringRequest();
    SetTriggeringResponse response = (SetTriggeringResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.TriggeringItemId = triggeringItemId;
    request.LinksToAdd = linksToAdd;
    request.LinksToRemove = linksToRemove;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "SetTriggering");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (SetTriggeringResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "SetTriggering");
    }
    SetTriggeringResponse triggeringResponse = response;
    request = (SetTriggeringRequest) null;
    response = (SetTriggeringResponse) null;
    return triggeringResponse;
  }

  public virtual ResponseHeader DeleteMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    UInt32Collection monitoredItemIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    DeleteMonitoredItemsRequest request = new DeleteMonitoredItemsRequest();
    DeleteMonitoredItemsResponse response = (DeleteMonitoredItemsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.MonitoredItemIds = monitoredItemIds;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (DeleteMonitoredItems));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteMonitoredItemsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (DeleteMonitoredItems));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginDeleteMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    UInt32Collection monitoredItemIds,
    AsyncCallback callback,
    object asyncState)
  {
    DeleteMonitoredItemsRequest request = new DeleteMonitoredItemsRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.MonitoredItemIds = monitoredItemIds;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "DeleteMonitoredItems");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndDeleteMonitoredItems(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    DeleteMonitoredItemsResponse response = (DeleteMonitoredItemsResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteMonitoredItemsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "DeleteMonitoredItems");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<DeleteMonitoredItemsResponse> DeleteMonitoredItemsAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    UInt32Collection monitoredItemIds,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    DeleteMonitoredItemsRequest request = new DeleteMonitoredItemsRequest();
    DeleteMonitoredItemsResponse response = (DeleteMonitoredItemsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.MonitoredItemIds = monitoredItemIds;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "DeleteMonitoredItems");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteMonitoredItemsResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "DeleteMonitoredItems");
    }
    DeleteMonitoredItemsResponse monitoredItemsResponse = response;
    request = (DeleteMonitoredItemsRequest) null;
    response = (DeleteMonitoredItemsResponse) null;
    return monitoredItemsResponse;
  }

  public virtual ResponseHeader CreateSubscription(
    RequestHeader requestHeader,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    bool publishingEnabled,
    byte priority,
    out uint subscriptionId,
    out double revisedPublishingInterval,
    out uint revisedLifetimeCount,
    out uint revisedMaxKeepAliveCount)
  {
    CreateSubscriptionRequest request = new CreateSubscriptionRequest();
    CreateSubscriptionResponse response = (CreateSubscriptionResponse) null;
    request.RequestHeader = requestHeader;
    request.RequestedPublishingInterval = requestedPublishingInterval;
    request.RequestedLifetimeCount = requestedLifetimeCount;
    request.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
    request.MaxNotificationsPerPublish = maxNotificationsPerPublish;
    request.PublishingEnabled = publishingEnabled;
    request.Priority = priority;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (CreateSubscription));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CreateSubscriptionResponse) serviceResponse;
      subscriptionId = response.SubscriptionId;
      revisedPublishingInterval = response.RevisedPublishingInterval;
      revisedLifetimeCount = response.RevisedLifetimeCount;
      revisedMaxKeepAliveCount = response.RevisedMaxKeepAliveCount;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (CreateSubscription));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginCreateSubscription(
    RequestHeader requestHeader,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    bool publishingEnabled,
    byte priority,
    AsyncCallback callback,
    object asyncState)
  {
    CreateSubscriptionRequest request = new CreateSubscriptionRequest();
    request.RequestHeader = requestHeader;
    request.RequestedPublishingInterval = requestedPublishingInterval;
    request.RequestedLifetimeCount = requestedLifetimeCount;
    request.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
    request.MaxNotificationsPerPublish = maxNotificationsPerPublish;
    request.PublishingEnabled = publishingEnabled;
    request.Priority = priority;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "CreateSubscription");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndCreateSubscription(
    IAsyncResult result,
    out uint subscriptionId,
    out double revisedPublishingInterval,
    out uint revisedLifetimeCount,
    out uint revisedMaxKeepAliveCount)
  {
    CreateSubscriptionResponse response = (CreateSubscriptionResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CreateSubscriptionResponse) serviceResponse;
      subscriptionId = response.SubscriptionId;
      revisedPublishingInterval = response.RevisedPublishingInterval;
      revisedLifetimeCount = response.RevisedLifetimeCount;
      revisedMaxKeepAliveCount = response.RevisedMaxKeepAliveCount;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "CreateSubscription");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<CreateSubscriptionResponse> CreateSubscriptionAsync(
    RequestHeader requestHeader,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    bool publishingEnabled,
    byte priority,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    CreateSubscriptionRequest request = new CreateSubscriptionRequest();
    CreateSubscriptionResponse response = (CreateSubscriptionResponse) null;
    request.RequestHeader = requestHeader;
    request.RequestedPublishingInterval = requestedPublishingInterval;
    request.RequestedLifetimeCount = requestedLifetimeCount;
    request.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
    request.MaxNotificationsPerPublish = maxNotificationsPerPublish;
    request.PublishingEnabled = publishingEnabled;
    request.Priority = priority;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "CreateSubscription");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (CreateSubscriptionResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "CreateSubscription");
    }
    CreateSubscriptionResponse subscriptionAsync = response;
    request = (CreateSubscriptionRequest) null;
    response = (CreateSubscriptionResponse) null;
    return subscriptionAsync;
  }

  public virtual ResponseHeader ModifySubscription(
    RequestHeader requestHeader,
    uint subscriptionId,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    byte priority,
    out double revisedPublishingInterval,
    out uint revisedLifetimeCount,
    out uint revisedMaxKeepAliveCount)
  {
    ModifySubscriptionRequest request = new ModifySubscriptionRequest();
    ModifySubscriptionResponse response = (ModifySubscriptionResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.RequestedPublishingInterval = requestedPublishingInterval;
    request.RequestedLifetimeCount = requestedLifetimeCount;
    request.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
    request.MaxNotificationsPerPublish = maxNotificationsPerPublish;
    request.Priority = priority;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (ModifySubscription));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ModifySubscriptionResponse) serviceResponse;
      revisedPublishingInterval = response.RevisedPublishingInterval;
      revisedLifetimeCount = response.RevisedLifetimeCount;
      revisedMaxKeepAliveCount = response.RevisedMaxKeepAliveCount;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (ModifySubscription));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginModifySubscription(
    RequestHeader requestHeader,
    uint subscriptionId,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    byte priority,
    AsyncCallback callback,
    object asyncState)
  {
    ModifySubscriptionRequest request = new ModifySubscriptionRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.RequestedPublishingInterval = requestedPublishingInterval;
    request.RequestedLifetimeCount = requestedLifetimeCount;
    request.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
    request.MaxNotificationsPerPublish = maxNotificationsPerPublish;
    request.Priority = priority;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "ModifySubscription");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndModifySubscription(
    IAsyncResult result,
    out double revisedPublishingInterval,
    out uint revisedLifetimeCount,
    out uint revisedMaxKeepAliveCount)
  {
    ModifySubscriptionResponse response = (ModifySubscriptionResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ModifySubscriptionResponse) serviceResponse;
      revisedPublishingInterval = response.RevisedPublishingInterval;
      revisedLifetimeCount = response.RevisedLifetimeCount;
      revisedMaxKeepAliveCount = response.RevisedMaxKeepAliveCount;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "ModifySubscription");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<ModifySubscriptionResponse> ModifySubscriptionAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    byte priority,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    ModifySubscriptionRequest request = new ModifySubscriptionRequest();
    ModifySubscriptionResponse response = (ModifySubscriptionResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.RequestedPublishingInterval = requestedPublishingInterval;
    request.RequestedLifetimeCount = requestedLifetimeCount;
    request.RequestedMaxKeepAliveCount = requestedMaxKeepAliveCount;
    request.MaxNotificationsPerPublish = maxNotificationsPerPublish;
    request.Priority = priority;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "ModifySubscription");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (ModifySubscriptionResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "ModifySubscription");
    }
    ModifySubscriptionResponse subscriptionResponse = response;
    request = (ModifySubscriptionRequest) null;
    response = (ModifySubscriptionResponse) null;
    return subscriptionResponse;
  }

  public virtual ResponseHeader SetPublishingMode(
    RequestHeader requestHeader,
    bool publishingEnabled,
    UInt32Collection subscriptionIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    SetPublishingModeRequest request = new SetPublishingModeRequest();
    SetPublishingModeResponse response = (SetPublishingModeResponse) null;
    request.RequestHeader = requestHeader;
    request.PublishingEnabled = publishingEnabled;
    request.SubscriptionIds = subscriptionIds;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (SetPublishingMode));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (SetPublishingModeResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (SetPublishingMode));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginSetPublishingMode(
    RequestHeader requestHeader,
    bool publishingEnabled,
    UInt32Collection subscriptionIds,
    AsyncCallback callback,
    object asyncState)
  {
    SetPublishingModeRequest request = new SetPublishingModeRequest();
    request.RequestHeader = requestHeader;
    request.PublishingEnabled = publishingEnabled;
    request.SubscriptionIds = subscriptionIds;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "SetPublishingMode");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndSetPublishingMode(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    SetPublishingModeResponse response = (SetPublishingModeResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (SetPublishingModeResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "SetPublishingMode");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<SetPublishingModeResponse> SetPublishingModeAsync(
    RequestHeader requestHeader,
    bool publishingEnabled,
    UInt32Collection subscriptionIds,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    SetPublishingModeRequest request = new SetPublishingModeRequest();
    SetPublishingModeResponse response = (SetPublishingModeResponse) null;
    request.RequestHeader = requestHeader;
    request.PublishingEnabled = publishingEnabled;
    request.SubscriptionIds = subscriptionIds;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "SetPublishingMode");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (SetPublishingModeResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "SetPublishingMode");
    }
    SetPublishingModeResponse publishingModeResponse = response;
    request = (SetPublishingModeRequest) null;
    response = (SetPublishingModeResponse) null;
    return publishingModeResponse;
  }

  public virtual ResponseHeader Publish(
    RequestHeader requestHeader,
    SubscriptionAcknowledgementCollection subscriptionAcknowledgements,
    out uint subscriptionId,
    out UInt32Collection availableSequenceNumbers,
    out bool moreNotifications,
    out NotificationMessage notificationMessage,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    PublishRequest request = new PublishRequest();
    PublishResponse response = (PublishResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionAcknowledgements = subscriptionAcknowledgements;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (Publish));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (PublishResponse) serviceResponse;
      subscriptionId = response.SubscriptionId;
      availableSequenceNumbers = response.AvailableSequenceNumbers;
      moreNotifications = response.MoreNotifications;
      notificationMessage = response.NotificationMessage;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (Publish));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginPublish(
    RequestHeader requestHeader,
    SubscriptionAcknowledgementCollection subscriptionAcknowledgements,
    AsyncCallback callback,
    object asyncState)
  {
    PublishRequest request = new PublishRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionAcknowledgements = subscriptionAcknowledgements;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Publish");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndPublish(
    IAsyncResult result,
    out uint subscriptionId,
    out UInt32Collection availableSequenceNumbers,
    out bool moreNotifications,
    out NotificationMessage notificationMessage,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    PublishResponse response = (PublishResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (PublishResponse) serviceResponse;
      subscriptionId = response.SubscriptionId;
      availableSequenceNumbers = response.AvailableSequenceNumbers;
      moreNotifications = response.MoreNotifications;
      notificationMessage = response.NotificationMessage;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "Publish");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<PublishResponse> PublishAsync(
    RequestHeader requestHeader,
    SubscriptionAcknowledgementCollection subscriptionAcknowledgements,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    PublishRequest request = new PublishRequest();
    PublishResponse response = (PublishResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionAcknowledgements = subscriptionAcknowledgements;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Publish");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (PublishResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "Publish");
    }
    PublishResponse publishResponse = response;
    request = (PublishRequest) null;
    response = (PublishResponse) null;
    return publishResponse;
  }

  public virtual ResponseHeader Republish(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint retransmitSequenceNumber,
    out NotificationMessage notificationMessage)
  {
    RepublishRequest request = new RepublishRequest();
    RepublishResponse response = (RepublishResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.RetransmitSequenceNumber = retransmitSequenceNumber;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (Republish));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RepublishResponse) serviceResponse;
      notificationMessage = response.NotificationMessage;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (Republish));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginRepublish(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint retransmitSequenceNumber,
    AsyncCallback callback,
    object asyncState)
  {
    RepublishRequest request = new RepublishRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.RetransmitSequenceNumber = retransmitSequenceNumber;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Republish");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndRepublish(
    IAsyncResult result,
    out NotificationMessage notificationMessage)
  {
    RepublishResponse response = (RepublishResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RepublishResponse) serviceResponse;
      notificationMessage = response.NotificationMessage;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "Republish");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<RepublishResponse> RepublishAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint retransmitSequenceNumber,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    RepublishRequest request = new RepublishRequest();
    RepublishResponse response = (RepublishResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionId = subscriptionId;
    request.RetransmitSequenceNumber = retransmitSequenceNumber;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "Republish");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RepublishResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "Republish");
    }
    RepublishResponse republishResponse = response;
    request = (RepublishRequest) null;
    response = (RepublishResponse) null;
    return republishResponse;
  }

  public virtual ResponseHeader TransferSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    bool sendInitialValues,
    out TransferResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    TransferSubscriptionsRequest request = new TransferSubscriptionsRequest();
    TransferSubscriptionsResponse response = (TransferSubscriptionsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionIds = subscriptionIds;
    request.SendInitialValues = sendInitialValues;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (TransferSubscriptions));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (TransferSubscriptionsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (TransferSubscriptions));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginTransferSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    bool sendInitialValues,
    AsyncCallback callback,
    object asyncState)
  {
    TransferSubscriptionsRequest request = new TransferSubscriptionsRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionIds = subscriptionIds;
    request.SendInitialValues = sendInitialValues;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "TransferSubscriptions");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndTransferSubscriptions(
    IAsyncResult result,
    out TransferResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    TransferSubscriptionsResponse response = (TransferSubscriptionsResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (TransferSubscriptionsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "TransferSubscriptions");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<TransferSubscriptionsResponse> TransferSubscriptionsAsync(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    bool sendInitialValues,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    TransferSubscriptionsRequest request = new TransferSubscriptionsRequest();
    TransferSubscriptionsResponse response = (TransferSubscriptionsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionIds = subscriptionIds;
    request.SendInitialValues = sendInitialValues;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "TransferSubscriptions");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (TransferSubscriptionsResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "TransferSubscriptions");
    }
    TransferSubscriptionsResponse subscriptionsResponse = response;
    request = (TransferSubscriptionsRequest) null;
    response = (TransferSubscriptionsResponse) null;
    return subscriptionsResponse;
  }

  public virtual ResponseHeader DeleteSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    DeleteSubscriptionsRequest request = new DeleteSubscriptionsRequest();
    DeleteSubscriptionsResponse response = (DeleteSubscriptionsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionIds = subscriptionIds;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (DeleteSubscriptions));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteSubscriptionsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (DeleteSubscriptions));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginDeleteSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    AsyncCallback callback,
    object asyncState)
  {
    DeleteSubscriptionsRequest request = new DeleteSubscriptionsRequest();
    request.RequestHeader = requestHeader;
    request.SubscriptionIds = subscriptionIds;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "DeleteSubscriptions");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndDeleteSubscriptions(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    DeleteSubscriptionsResponse response = (DeleteSubscriptionsResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteSubscriptionsResponse) serviceResponse;
      results = response.Results;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "DeleteSubscriptions");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<DeleteSubscriptionsResponse> DeleteSubscriptionsAsync(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    CancellationToken ct)
  {
    SessionClient sessionClient = this;
    DeleteSubscriptionsRequest request = new DeleteSubscriptionsRequest();
    DeleteSubscriptionsResponse response = (DeleteSubscriptionsResponse) null;
    request.RequestHeader = requestHeader;
    request.SubscriptionIds = subscriptionIds;
    sessionClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "DeleteSubscriptions");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (sessionClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (DeleteSubscriptionsResponse) serviceResponse;
    }
    finally
    {
      sessionClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "DeleteSubscriptions");
    }
    DeleteSubscriptionsResponse subscriptionsResponse = response;
    request = (DeleteSubscriptionsRequest) null;
    response = (DeleteSubscriptionsResponse) null;
    return subscriptionsResponse;
  }
}
