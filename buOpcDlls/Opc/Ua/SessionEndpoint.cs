// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionEndpoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionEndpoint : EndpointBase, ISessionEndpoint, IEndpointBase, IDiscoveryEndpoint
{
  public SessionEndpoint() => this.CreateKnownTypes();

  public SessionEndpoint(IServiceHostBase host)
    : base(host)
  {
    this.CreateKnownTypes();
  }

  public SessionEndpoint(ServerBase server)
    : base(server)
  {
    this.CreateKnownTypes();
  }

  protected ISessionServer ServerInstance
  {
    get
    {
      if (ServiceResult.IsBad(this.ServerError))
        throw new ServiceResultException(this.ServerError);
      return this.ServerForContext as ISessionServer;
    }
  }

  public IServiceResponse FindServers(IServiceRequest incoming)
  {
    FindServersResponse response = (FindServersResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      FindServersRequest findServersRequest = (FindServersRequest) incoming;
      ApplicationDescriptionCollection servers = (ApplicationDescriptionCollection) null;
      response = new FindServersResponse();
      response.ResponseHeader = this.ServerInstance.FindServers(findServersRequest.RequestHeader, findServersRequest.EndpointUrl, findServersRequest.LocaleIds, findServersRequest.ServerUris, out servers);
      response.Servers = servers;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginFindServers(
    FindServersMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.FindServersRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.FindServersRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.FindServersRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual FindServersResponseMessage EndFindServers(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new FindServersResponseMessage((FindServersResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse FindServersOnNetwork(IServiceRequest incoming)
  {
    FindServersOnNetworkResponse response = (FindServersOnNetworkResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      FindServersOnNetworkRequest onNetworkRequest = (FindServersOnNetworkRequest) incoming;
      DateTime lastCounterResetTime = DateTime.MinValue;
      ServerOnNetworkCollection servers = (ServerOnNetworkCollection) null;
      response = new FindServersOnNetworkResponse();
      response.ResponseHeader = this.ServerInstance.FindServersOnNetwork(onNetworkRequest.RequestHeader, onNetworkRequest.StartingRecordId, onNetworkRequest.MaxRecordsToReturn, onNetworkRequest.ServerCapabilityFilter, out lastCounterResetTime, out servers);
      response.LastCounterResetTime = lastCounterResetTime;
      response.Servers = servers;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginFindServersOnNetwork(
    FindServersOnNetworkMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.FindServersOnNetworkRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.FindServersOnNetworkRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.FindServersOnNetworkRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual FindServersOnNetworkResponseMessage EndFindServersOnNetwork(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new FindServersOnNetworkResponseMessage((FindServersOnNetworkResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse GetEndpoints(IServiceRequest incoming)
  {
    GetEndpointsResponse response = (GetEndpointsResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      GetEndpointsRequest endpointsRequest = (GetEndpointsRequest) incoming;
      EndpointDescriptionCollection endpoints = (EndpointDescriptionCollection) null;
      response = new GetEndpointsResponse();
      response.ResponseHeader = this.ServerInstance.GetEndpoints(endpointsRequest.RequestHeader, endpointsRequest.EndpointUrl, endpointsRequest.LocaleIds, endpointsRequest.ProfileUris, out endpoints);
      response.Endpoints = endpoints;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginGetEndpoints(
    GetEndpointsMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.GetEndpointsRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.GetEndpointsRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.GetEndpointsRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual GetEndpointsResponseMessage EndGetEndpoints(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new GetEndpointsResponseMessage((GetEndpointsResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse CreateSession(IServiceRequest incoming)
  {
    CreateSessionResponse response = (CreateSessionResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      CreateSessionRequest createSessionRequest = (CreateSessionRequest) incoming;
      NodeId sessionId = (NodeId) null;
      NodeId authenticationToken = (NodeId) null;
      double revisedSessionTimeout = 0.0;
      byte[] serverNonce = (byte[]) null;
      byte[] serverCertificate = (byte[]) null;
      EndpointDescriptionCollection serverEndpoints = (EndpointDescriptionCollection) null;
      SignedSoftwareCertificateCollection serverSoftwareCertificates = (SignedSoftwareCertificateCollection) null;
      SignatureData serverSignature = (SignatureData) null;
      uint maxRequestMessageSize = 0;
      response = new CreateSessionResponse();
      response.ResponseHeader = this.ServerInstance.CreateSession(createSessionRequest.RequestHeader, createSessionRequest.ClientDescription, createSessionRequest.ServerUri, createSessionRequest.EndpointUrl, createSessionRequest.SessionName, createSessionRequest.ClientNonce, createSessionRequest.ClientCertificate, createSessionRequest.RequestedSessionTimeout, createSessionRequest.MaxResponseMessageSize, out sessionId, out authenticationToken, out revisedSessionTimeout, out serverNonce, out serverCertificate, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out maxRequestMessageSize);
      response.SessionId = sessionId;
      response.AuthenticationToken = authenticationToken;
      response.RevisedSessionTimeout = revisedSessionTimeout;
      response.ServerNonce = serverNonce;
      response.ServerCertificate = serverCertificate;
      response.ServerEndpoints = serverEndpoints;
      response.ServerSoftwareCertificates = serverSoftwareCertificates;
      response.ServerSignature = serverSignature;
      response.MaxRequestMessageSize = maxRequestMessageSize;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginCreateSession(
    CreateSessionMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.CreateSessionRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.CreateSessionRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.CreateSessionRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual CreateSessionResponseMessage EndCreateSession(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new CreateSessionResponseMessage((CreateSessionResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse ActivateSession(IServiceRequest incoming)
  {
    ActivateSessionResponse response = (ActivateSessionResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      ActivateSessionRequest activateSessionRequest = (ActivateSessionRequest) incoming;
      byte[] serverNonce = (byte[]) null;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new ActivateSessionResponse();
      response.ResponseHeader = this.ServerInstance.ActivateSession(activateSessionRequest.RequestHeader, activateSessionRequest.ClientSignature, activateSessionRequest.ClientSoftwareCertificates, activateSessionRequest.LocaleIds, activateSessionRequest.UserIdentityToken, activateSessionRequest.UserTokenSignature, out serverNonce, out results, out diagnosticInfos);
      response.ServerNonce = serverNonce;
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginActivateSession(
    ActivateSessionMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.ActivateSessionRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.ActivateSessionRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.ActivateSessionRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual ActivateSessionResponseMessage EndActivateSession(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new ActivateSessionResponseMessage((ActivateSessionResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse CloseSession(IServiceRequest incoming)
  {
    CloseSessionResponse response = (CloseSessionResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      CloseSessionRequest closeSessionRequest = (CloseSessionRequest) incoming;
      response = new CloseSessionResponse();
      response.ResponseHeader = this.ServerInstance.CloseSession(closeSessionRequest.RequestHeader, closeSessionRequest.DeleteSubscriptions);
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginCloseSession(
    CloseSessionMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.CloseSessionRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.CloseSessionRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.CloseSessionRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual CloseSessionResponseMessage EndCloseSession(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new CloseSessionResponseMessage((CloseSessionResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse Cancel(IServiceRequest incoming)
  {
    CancelResponse response = (CancelResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      CancelRequest cancelRequest = (CancelRequest) incoming;
      uint cancelCount = 0;
      response = new CancelResponse();
      response.ResponseHeader = this.ServerInstance.Cancel(cancelRequest.RequestHeader, cancelRequest.RequestHandle, out cancelCount);
      response.CancelCount = cancelCount;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginCancel(
    CancelMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.CancelRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.CancelRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.CancelRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual CancelResponseMessage EndCancel(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new CancelResponseMessage((CancelResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse AddNodes(IServiceRequest incoming)
  {
    AddNodesResponse response = (AddNodesResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      AddNodesRequest addNodesRequest = (AddNodesRequest) incoming;
      AddNodesResultCollection results = (AddNodesResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new AddNodesResponse();
      response.ResponseHeader = this.ServerInstance.AddNodes(addNodesRequest.RequestHeader, addNodesRequest.NodesToAdd, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginAddNodes(
    AddNodesMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.AddNodesRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.AddNodesRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.AddNodesRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual AddNodesResponseMessage EndAddNodes(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new AddNodesResponseMessage((AddNodesResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse AddReferences(IServiceRequest incoming)
  {
    AddReferencesResponse response = (AddReferencesResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      AddReferencesRequest referencesRequest = (AddReferencesRequest) incoming;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new AddReferencesResponse();
      response.ResponseHeader = this.ServerInstance.AddReferences(referencesRequest.RequestHeader, referencesRequest.ReferencesToAdd, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginAddReferences(
    AddReferencesMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.AddReferencesRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.AddReferencesRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.AddReferencesRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual AddReferencesResponseMessage EndAddReferences(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new AddReferencesResponseMessage((AddReferencesResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse DeleteNodes(IServiceRequest incoming)
  {
    DeleteNodesResponse response = (DeleteNodesResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      DeleteNodesRequest deleteNodesRequest = (DeleteNodesRequest) incoming;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new DeleteNodesResponse();
      response.ResponseHeader = this.ServerInstance.DeleteNodes(deleteNodesRequest.RequestHeader, deleteNodesRequest.NodesToDelete, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginDeleteNodes(
    DeleteNodesMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.DeleteNodesRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.DeleteNodesRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.DeleteNodesRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual DeleteNodesResponseMessage EndDeleteNodes(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new DeleteNodesResponseMessage((DeleteNodesResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse DeleteReferences(IServiceRequest incoming)
  {
    DeleteReferencesResponse response = (DeleteReferencesResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      DeleteReferencesRequest referencesRequest = (DeleteReferencesRequest) incoming;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new DeleteReferencesResponse();
      response.ResponseHeader = this.ServerInstance.DeleteReferences(referencesRequest.RequestHeader, referencesRequest.ReferencesToDelete, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginDeleteReferences(
    DeleteReferencesMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.DeleteReferencesRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.DeleteReferencesRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.DeleteReferencesRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual DeleteReferencesResponseMessage EndDeleteReferences(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new DeleteReferencesResponseMessage((DeleteReferencesResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse Browse(IServiceRequest incoming)
  {
    BrowseResponse response = (BrowseResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      BrowseRequest browseRequest = (BrowseRequest) incoming;
      BrowseResultCollection results = (BrowseResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new BrowseResponse();
      response.ResponseHeader = this.ServerInstance.Browse(browseRequest.RequestHeader, browseRequest.View, browseRequest.RequestedMaxReferencesPerNode, browseRequest.NodesToBrowse, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginBrowse(
    BrowseMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.BrowseRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.BrowseRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.BrowseRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual BrowseResponseMessage EndBrowse(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new BrowseResponseMessage((BrowseResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse BrowseNext(IServiceRequest incoming)
  {
    BrowseNextResponse response = (BrowseNextResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      BrowseNextRequest browseNextRequest = (BrowseNextRequest) incoming;
      BrowseResultCollection results = (BrowseResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new BrowseNextResponse();
      response.ResponseHeader = this.ServerInstance.BrowseNext(browseNextRequest.RequestHeader, browseNextRequest.ReleaseContinuationPoints, browseNextRequest.ContinuationPoints, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginBrowseNext(
    BrowseNextMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.BrowseNextRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.BrowseNextRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.BrowseNextRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual BrowseNextResponseMessage EndBrowseNext(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new BrowseNextResponseMessage((BrowseNextResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse TranslateBrowsePathsToNodeIds(IServiceRequest incoming)
  {
    TranslateBrowsePathsToNodeIdsResponse response = (TranslateBrowsePathsToNodeIdsResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      TranslateBrowsePathsToNodeIdsRequest toNodeIdsRequest = (TranslateBrowsePathsToNodeIdsRequest) incoming;
      BrowsePathResultCollection results = (BrowsePathResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new TranslateBrowsePathsToNodeIdsResponse();
      response.ResponseHeader = this.ServerInstance.TranslateBrowsePathsToNodeIds(toNodeIdsRequest.RequestHeader, toNodeIdsRequest.BrowsePaths, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginTranslateBrowsePathsToNodeIds(
    TranslateBrowsePathsToNodeIdsMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.TranslateBrowsePathsToNodeIdsRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.TranslateBrowsePathsToNodeIdsRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.TranslateBrowsePathsToNodeIdsRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual TranslateBrowsePathsToNodeIdsResponseMessage EndTranslateBrowsePathsToNodeIds(
    IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new TranslateBrowsePathsToNodeIdsResponseMessage((TranslateBrowsePathsToNodeIdsResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse RegisterNodes(IServiceRequest incoming)
  {
    RegisterNodesResponse response = (RegisterNodesResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      RegisterNodesRequest registerNodesRequest = (RegisterNodesRequest) incoming;
      NodeIdCollection registeredNodeIds = (NodeIdCollection) null;
      response = new RegisterNodesResponse();
      response.ResponseHeader = this.ServerInstance.RegisterNodes(registerNodesRequest.RequestHeader, registerNodesRequest.NodesToRegister, out registeredNodeIds);
      response.RegisteredNodeIds = registeredNodeIds;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginRegisterNodes(
    RegisterNodesMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.RegisterNodesRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.RegisterNodesRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.RegisterNodesRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual RegisterNodesResponseMessage EndRegisterNodes(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new RegisterNodesResponseMessage((RegisterNodesResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse UnregisterNodes(IServiceRequest incoming)
  {
    UnregisterNodesResponse response = (UnregisterNodesResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      UnregisterNodesRequest unregisterNodesRequest = (UnregisterNodesRequest) incoming;
      response = new UnregisterNodesResponse();
      response.ResponseHeader = this.ServerInstance.UnregisterNodes(unregisterNodesRequest.RequestHeader, unregisterNodesRequest.NodesToUnregister);
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginUnregisterNodes(
    UnregisterNodesMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.UnregisterNodesRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.UnregisterNodesRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.UnregisterNodesRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual UnregisterNodesResponseMessage EndUnregisterNodes(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new UnregisterNodesResponseMessage((UnregisterNodesResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse QueryFirst(IServiceRequest incoming)
  {
    QueryFirstResponse response = (QueryFirstResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      QueryFirstRequest queryFirstRequest = (QueryFirstRequest) incoming;
      QueryDataSetCollection queryDataSets = (QueryDataSetCollection) null;
      byte[] continuationPoint = (byte[]) null;
      ParsingResultCollection parsingResults = (ParsingResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      ContentFilterResult filterResult = (ContentFilterResult) null;
      response = new QueryFirstResponse();
      response.ResponseHeader = this.ServerInstance.QueryFirst(queryFirstRequest.RequestHeader, queryFirstRequest.View, queryFirstRequest.NodeTypes, queryFirstRequest.Filter, queryFirstRequest.MaxDataSetsToReturn, queryFirstRequest.MaxReferencesToReturn, out queryDataSets, out continuationPoint, out parsingResults, out diagnosticInfos, out filterResult);
      response.QueryDataSets = queryDataSets;
      response.ContinuationPoint = continuationPoint;
      response.ParsingResults = parsingResults;
      response.DiagnosticInfos = diagnosticInfos;
      response.FilterResult = filterResult;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginQueryFirst(
    QueryFirstMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.QueryFirstRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.QueryFirstRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.QueryFirstRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual QueryFirstResponseMessage EndQueryFirst(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new QueryFirstResponseMessage((QueryFirstResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse QueryNext(IServiceRequest incoming)
  {
    QueryNextResponse response = (QueryNextResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      QueryNextRequest queryNextRequest = (QueryNextRequest) incoming;
      QueryDataSetCollection queryDataSets = (QueryDataSetCollection) null;
      byte[] revisedContinuationPoint = (byte[]) null;
      response = new QueryNextResponse();
      response.ResponseHeader = this.ServerInstance.QueryNext(queryNextRequest.RequestHeader, queryNextRequest.ReleaseContinuationPoint, queryNextRequest.ContinuationPoint, out queryDataSets, out revisedContinuationPoint);
      response.QueryDataSets = queryDataSets;
      response.RevisedContinuationPoint = revisedContinuationPoint;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginQueryNext(
    QueryNextMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.QueryNextRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.QueryNextRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.QueryNextRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual QueryNextResponseMessage EndQueryNext(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new QueryNextResponseMessage((QueryNextResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse Read(IServiceRequest incoming)
  {
    ReadResponse response = (ReadResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      ReadRequest readRequest = (ReadRequest) incoming;
      DataValueCollection results = (DataValueCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new ReadResponse();
      response.ResponseHeader = this.ServerInstance.Read(readRequest.RequestHeader, readRequest.MaxAge, readRequest.TimestampsToReturn, readRequest.NodesToRead, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginRead(
    ReadMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.ReadRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.ReadRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.ReadRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual ReadResponseMessage EndRead(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new ReadResponseMessage((ReadResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse HistoryRead(IServiceRequest incoming)
  {
    HistoryReadResponse response = (HistoryReadResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      HistoryReadRequest historyReadRequest = (HistoryReadRequest) incoming;
      HistoryReadResultCollection results = (HistoryReadResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new HistoryReadResponse();
      response.ResponseHeader = this.ServerInstance.HistoryRead(historyReadRequest.RequestHeader, historyReadRequest.HistoryReadDetails, historyReadRequest.TimestampsToReturn, historyReadRequest.ReleaseContinuationPoints, historyReadRequest.NodesToRead, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginHistoryRead(
    HistoryReadMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.HistoryReadRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.HistoryReadRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.HistoryReadRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual HistoryReadResponseMessage EndHistoryRead(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new HistoryReadResponseMessage((HistoryReadResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse Write(IServiceRequest incoming)
  {
    WriteResponse response = (WriteResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      WriteRequest writeRequest = (WriteRequest) incoming;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new WriteResponse();
      response.ResponseHeader = this.ServerInstance.Write(writeRequest.RequestHeader, writeRequest.NodesToWrite, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginWrite(
    WriteMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.WriteRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.WriteRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.WriteRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual WriteResponseMessage EndWrite(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new WriteResponseMessage((WriteResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse HistoryUpdate(IServiceRequest incoming)
  {
    HistoryUpdateResponse response = (HistoryUpdateResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      HistoryUpdateRequest historyUpdateRequest = (HistoryUpdateRequest) incoming;
      HistoryUpdateResultCollection results = (HistoryUpdateResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new HistoryUpdateResponse();
      response.ResponseHeader = this.ServerInstance.HistoryUpdate(historyUpdateRequest.RequestHeader, historyUpdateRequest.HistoryUpdateDetails, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginHistoryUpdate(
    HistoryUpdateMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.HistoryUpdateRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.HistoryUpdateRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.HistoryUpdateRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual HistoryUpdateResponseMessage EndHistoryUpdate(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new HistoryUpdateResponseMessage((HistoryUpdateResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse Call(IServiceRequest incoming)
  {
    CallResponse response = (CallResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      CallRequest callRequest = (CallRequest) incoming;
      CallMethodResultCollection results = (CallMethodResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new CallResponse();
      response.ResponseHeader = this.ServerInstance.Call(callRequest.RequestHeader, callRequest.MethodsToCall, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginCall(
    CallMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.CallRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.CallRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.CallRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual CallResponseMessage EndCall(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new CallResponseMessage((CallResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse CreateMonitoredItems(IServiceRequest incoming)
  {
    CreateMonitoredItemsResponse response = (CreateMonitoredItemsResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      CreateMonitoredItemsRequest monitoredItemsRequest = (CreateMonitoredItemsRequest) incoming;
      MonitoredItemCreateResultCollection results = (MonitoredItemCreateResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new CreateMonitoredItemsResponse();
      response.ResponseHeader = this.ServerInstance.CreateMonitoredItems(monitoredItemsRequest.RequestHeader, monitoredItemsRequest.SubscriptionId, monitoredItemsRequest.TimestampsToReturn, monitoredItemsRequest.ItemsToCreate, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginCreateMonitoredItems(
    CreateMonitoredItemsMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.CreateMonitoredItemsRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.CreateMonitoredItemsRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.CreateMonitoredItemsRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual CreateMonitoredItemsResponseMessage EndCreateMonitoredItems(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new CreateMonitoredItemsResponseMessage((CreateMonitoredItemsResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse ModifyMonitoredItems(IServiceRequest incoming)
  {
    ModifyMonitoredItemsResponse response = (ModifyMonitoredItemsResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      ModifyMonitoredItemsRequest monitoredItemsRequest = (ModifyMonitoredItemsRequest) incoming;
      MonitoredItemModifyResultCollection results = (MonitoredItemModifyResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new ModifyMonitoredItemsResponse();
      response.ResponseHeader = this.ServerInstance.ModifyMonitoredItems(monitoredItemsRequest.RequestHeader, monitoredItemsRequest.SubscriptionId, monitoredItemsRequest.TimestampsToReturn, monitoredItemsRequest.ItemsToModify, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginModifyMonitoredItems(
    ModifyMonitoredItemsMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.ModifyMonitoredItemsRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.ModifyMonitoredItemsRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.ModifyMonitoredItemsRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual ModifyMonitoredItemsResponseMessage EndModifyMonitoredItems(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new ModifyMonitoredItemsResponseMessage((ModifyMonitoredItemsResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse SetMonitoringMode(IServiceRequest incoming)
  {
    SetMonitoringModeResponse response = (SetMonitoringModeResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      SetMonitoringModeRequest monitoringModeRequest = (SetMonitoringModeRequest) incoming;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new SetMonitoringModeResponse();
      response.ResponseHeader = this.ServerInstance.SetMonitoringMode(monitoringModeRequest.RequestHeader, monitoringModeRequest.SubscriptionId, monitoringModeRequest.MonitoringMode, monitoringModeRequest.MonitoredItemIds, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginSetMonitoringMode(
    SetMonitoringModeMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.SetMonitoringModeRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.SetMonitoringModeRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.SetMonitoringModeRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual SetMonitoringModeResponseMessage EndSetMonitoringMode(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new SetMonitoringModeResponseMessage((SetMonitoringModeResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse SetTriggering(IServiceRequest incoming)
  {
    SetTriggeringResponse response = (SetTriggeringResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      SetTriggeringRequest triggeringRequest = (SetTriggeringRequest) incoming;
      StatusCodeCollection addResults = (StatusCodeCollection) null;
      DiagnosticInfoCollection addDiagnosticInfos = (DiagnosticInfoCollection) null;
      StatusCodeCollection removeResults = (StatusCodeCollection) null;
      DiagnosticInfoCollection removeDiagnosticInfos = (DiagnosticInfoCollection) null;
      response = new SetTriggeringResponse();
      response.ResponseHeader = this.ServerInstance.SetTriggering(triggeringRequest.RequestHeader, triggeringRequest.SubscriptionId, triggeringRequest.TriggeringItemId, triggeringRequest.LinksToAdd, triggeringRequest.LinksToRemove, out addResults, out addDiagnosticInfos, out removeResults, out removeDiagnosticInfos);
      response.AddResults = addResults;
      response.AddDiagnosticInfos = addDiagnosticInfos;
      response.RemoveResults = removeResults;
      response.RemoveDiagnosticInfos = removeDiagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginSetTriggering(
    SetTriggeringMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.SetTriggeringRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.SetTriggeringRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.SetTriggeringRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual SetTriggeringResponseMessage EndSetTriggering(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new SetTriggeringResponseMessage((SetTriggeringResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse DeleteMonitoredItems(IServiceRequest incoming)
  {
    DeleteMonitoredItemsResponse response = (DeleteMonitoredItemsResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      DeleteMonitoredItemsRequest monitoredItemsRequest = (DeleteMonitoredItemsRequest) incoming;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new DeleteMonitoredItemsResponse();
      response.ResponseHeader = this.ServerInstance.DeleteMonitoredItems(monitoredItemsRequest.RequestHeader, monitoredItemsRequest.SubscriptionId, monitoredItemsRequest.MonitoredItemIds, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginDeleteMonitoredItems(
    DeleteMonitoredItemsMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.DeleteMonitoredItemsRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.DeleteMonitoredItemsRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.DeleteMonitoredItemsRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual DeleteMonitoredItemsResponseMessage EndDeleteMonitoredItems(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new DeleteMonitoredItemsResponseMessage((DeleteMonitoredItemsResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse CreateSubscription(IServiceRequest incoming)
  {
    CreateSubscriptionResponse response = (CreateSubscriptionResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      CreateSubscriptionRequest subscriptionRequest = (CreateSubscriptionRequest) incoming;
      uint subscriptionId = 0;
      double revisedPublishingInterval = 0.0;
      uint revisedLifetimeCount = 0;
      uint revisedMaxKeepAliveCount = 0;
      response = new CreateSubscriptionResponse();
      response.ResponseHeader = this.ServerInstance.CreateSubscription(subscriptionRequest.RequestHeader, subscriptionRequest.RequestedPublishingInterval, subscriptionRequest.RequestedLifetimeCount, subscriptionRequest.RequestedMaxKeepAliveCount, subscriptionRequest.MaxNotificationsPerPublish, subscriptionRequest.PublishingEnabled, subscriptionRequest.Priority, out subscriptionId, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
      response.SubscriptionId = subscriptionId;
      response.RevisedPublishingInterval = revisedPublishingInterval;
      response.RevisedLifetimeCount = revisedLifetimeCount;
      response.RevisedMaxKeepAliveCount = revisedMaxKeepAliveCount;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginCreateSubscription(
    CreateSubscriptionMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.CreateSubscriptionRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.CreateSubscriptionRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.CreateSubscriptionRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual CreateSubscriptionResponseMessage EndCreateSubscription(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new CreateSubscriptionResponseMessage((CreateSubscriptionResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse ModifySubscription(IServiceRequest incoming)
  {
    ModifySubscriptionResponse response = (ModifySubscriptionResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      ModifySubscriptionRequest subscriptionRequest = (ModifySubscriptionRequest) incoming;
      double revisedPublishingInterval = 0.0;
      uint revisedLifetimeCount = 0;
      uint revisedMaxKeepAliveCount = 0;
      response = new ModifySubscriptionResponse();
      response.ResponseHeader = this.ServerInstance.ModifySubscription(subscriptionRequest.RequestHeader, subscriptionRequest.SubscriptionId, subscriptionRequest.RequestedPublishingInterval, subscriptionRequest.RequestedLifetimeCount, subscriptionRequest.RequestedMaxKeepAliveCount, subscriptionRequest.MaxNotificationsPerPublish, subscriptionRequest.Priority, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
      response.RevisedPublishingInterval = revisedPublishingInterval;
      response.RevisedLifetimeCount = revisedLifetimeCount;
      response.RevisedMaxKeepAliveCount = revisedMaxKeepAliveCount;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginModifySubscription(
    ModifySubscriptionMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.ModifySubscriptionRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.ModifySubscriptionRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.ModifySubscriptionRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual ModifySubscriptionResponseMessage EndModifySubscription(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new ModifySubscriptionResponseMessage((ModifySubscriptionResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse SetPublishingMode(IServiceRequest incoming)
  {
    SetPublishingModeResponse response = (SetPublishingModeResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      SetPublishingModeRequest publishingModeRequest = (SetPublishingModeRequest) incoming;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new SetPublishingModeResponse();
      response.ResponseHeader = this.ServerInstance.SetPublishingMode(publishingModeRequest.RequestHeader, publishingModeRequest.PublishingEnabled, publishingModeRequest.SubscriptionIds, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginSetPublishingMode(
    SetPublishingModeMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.SetPublishingModeRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.SetPublishingModeRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.SetPublishingModeRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual SetPublishingModeResponseMessage EndSetPublishingMode(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new SetPublishingModeResponseMessage((SetPublishingModeResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse Publish(IServiceRequest incoming)
  {
    PublishResponse response = (PublishResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      PublishRequest publishRequest = (PublishRequest) incoming;
      uint subscriptionId = 0;
      UInt32Collection availableSequenceNumbers = (UInt32Collection) null;
      bool moreNotifications = false;
      NotificationMessage notificationMessage = (NotificationMessage) null;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new PublishResponse();
      response.ResponseHeader = this.ServerInstance.Publish(publishRequest.RequestHeader, publishRequest.SubscriptionAcknowledgements, out subscriptionId, out availableSequenceNumbers, out moreNotifications, out notificationMessage, out results, out diagnosticInfos);
      response.SubscriptionId = subscriptionId;
      response.AvailableSequenceNumbers = availableSequenceNumbers;
      response.MoreNotifications = moreNotifications;
      response.NotificationMessage = notificationMessage;
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginPublish(
    PublishMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.PublishRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.PublishRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.PublishRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual PublishResponseMessage EndPublish(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new PublishResponseMessage((PublishResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse Republish(IServiceRequest incoming)
  {
    RepublishResponse response = (RepublishResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      RepublishRequest republishRequest = (RepublishRequest) incoming;
      NotificationMessage notificationMessage = (NotificationMessage) null;
      response = new RepublishResponse();
      response.ResponseHeader = this.ServerInstance.Republish(republishRequest.RequestHeader, republishRequest.SubscriptionId, republishRequest.RetransmitSequenceNumber, out notificationMessage);
      response.NotificationMessage = notificationMessage;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginRepublish(
    RepublishMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.RepublishRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.RepublishRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.RepublishRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual RepublishResponseMessage EndRepublish(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new RepublishResponseMessage((RepublishResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse TransferSubscriptions(IServiceRequest incoming)
  {
    TransferSubscriptionsResponse response = (TransferSubscriptionsResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      TransferSubscriptionsRequest subscriptionsRequest = (TransferSubscriptionsRequest) incoming;
      TransferResultCollection results = (TransferResultCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new TransferSubscriptionsResponse();
      response.ResponseHeader = this.ServerInstance.TransferSubscriptions(subscriptionsRequest.RequestHeader, subscriptionsRequest.SubscriptionIds, subscriptionsRequest.SendInitialValues, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginTransferSubscriptions(
    TransferSubscriptionsMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.TransferSubscriptionsRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.TransferSubscriptionsRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.TransferSubscriptionsRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual TransferSubscriptionsResponseMessage EndTransferSubscriptions(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new TransferSubscriptionsResponseMessage((TransferSubscriptionsResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse DeleteSubscriptions(IServiceRequest incoming)
  {
    DeleteSubscriptionsResponse response = (DeleteSubscriptionsResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      DeleteSubscriptionsRequest subscriptionsRequest = (DeleteSubscriptionsRequest) incoming;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new DeleteSubscriptionsResponse();
      response.ResponseHeader = this.ServerInstance.DeleteSubscriptions(subscriptionsRequest.RequestHeader, subscriptionsRequest.SubscriptionIds, out results, out diagnosticInfos);
      response.Results = results;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginDeleteSubscriptions(
    DeleteSubscriptionsMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.DeleteSubscriptionsRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.DeleteSubscriptionsRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.DeleteSubscriptionsRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual DeleteSubscriptionsResponseMessage EndDeleteSubscriptions(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new DeleteSubscriptionsResponseMessage((DeleteSubscriptionsResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  protected virtual void CreateKnownTypes()
  {
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.FindServersRequest, new EndpointBase.ServiceDefinition(typeof (FindServersRequest), new EndpointBase.InvokeServiceEventHandler(this.FindServers)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.FindServersOnNetworkRequest, new EndpointBase.ServiceDefinition(typeof (FindServersOnNetworkRequest), new EndpointBase.InvokeServiceEventHandler(this.FindServersOnNetwork)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.GetEndpointsRequest, new EndpointBase.ServiceDefinition(typeof (GetEndpointsRequest), new EndpointBase.InvokeServiceEventHandler(this.GetEndpoints)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.CreateSessionRequest, new EndpointBase.ServiceDefinition(typeof (CreateSessionRequest), new EndpointBase.InvokeServiceEventHandler(this.CreateSession)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.ActivateSessionRequest, new EndpointBase.ServiceDefinition(typeof (ActivateSessionRequest), new EndpointBase.InvokeServiceEventHandler(this.ActivateSession)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.CloseSessionRequest, new EndpointBase.ServiceDefinition(typeof (CloseSessionRequest), new EndpointBase.InvokeServiceEventHandler(this.CloseSession)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.CancelRequest, new EndpointBase.ServiceDefinition(typeof (CancelRequest), new EndpointBase.InvokeServiceEventHandler(this.Cancel)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.AddNodesRequest, new EndpointBase.ServiceDefinition(typeof (AddNodesRequest), new EndpointBase.InvokeServiceEventHandler(this.AddNodes)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.AddReferencesRequest, new EndpointBase.ServiceDefinition(typeof (AddReferencesRequest), new EndpointBase.InvokeServiceEventHandler(this.AddReferences)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.DeleteNodesRequest, new EndpointBase.ServiceDefinition(typeof (DeleteNodesRequest), new EndpointBase.InvokeServiceEventHandler(this.DeleteNodes)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.DeleteReferencesRequest, new EndpointBase.ServiceDefinition(typeof (DeleteReferencesRequest), new EndpointBase.InvokeServiceEventHandler(this.DeleteReferences)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.BrowseRequest, new EndpointBase.ServiceDefinition(typeof (BrowseRequest), new EndpointBase.InvokeServiceEventHandler(this.Browse)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.BrowseNextRequest, new EndpointBase.ServiceDefinition(typeof (BrowseNextRequest), new EndpointBase.InvokeServiceEventHandler(this.BrowseNext)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.TranslateBrowsePathsToNodeIdsRequest, new EndpointBase.ServiceDefinition(typeof (TranslateBrowsePathsToNodeIdsRequest), new EndpointBase.InvokeServiceEventHandler(this.TranslateBrowsePathsToNodeIds)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.RegisterNodesRequest, new EndpointBase.ServiceDefinition(typeof (RegisterNodesRequest), new EndpointBase.InvokeServiceEventHandler(this.RegisterNodes)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.UnregisterNodesRequest, new EndpointBase.ServiceDefinition(typeof (UnregisterNodesRequest), new EndpointBase.InvokeServiceEventHandler(this.UnregisterNodes)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.QueryFirstRequest, new EndpointBase.ServiceDefinition(typeof (QueryFirstRequest), new EndpointBase.InvokeServiceEventHandler(this.QueryFirst)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.QueryNextRequest, new EndpointBase.ServiceDefinition(typeof (QueryNextRequest), new EndpointBase.InvokeServiceEventHandler(this.QueryNext)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.ReadRequest, new EndpointBase.ServiceDefinition(typeof (ReadRequest), new EndpointBase.InvokeServiceEventHandler(this.Read)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.HistoryReadRequest, new EndpointBase.ServiceDefinition(typeof (HistoryReadRequest), new EndpointBase.InvokeServiceEventHandler(this.HistoryRead)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.WriteRequest, new EndpointBase.ServiceDefinition(typeof (WriteRequest), new EndpointBase.InvokeServiceEventHandler(this.Write)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.HistoryUpdateRequest, new EndpointBase.ServiceDefinition(typeof (HistoryUpdateRequest), new EndpointBase.InvokeServiceEventHandler(this.HistoryUpdate)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.CallRequest, new EndpointBase.ServiceDefinition(typeof (CallRequest), new EndpointBase.InvokeServiceEventHandler(this.Call)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.CreateMonitoredItemsRequest, new EndpointBase.ServiceDefinition(typeof (CreateMonitoredItemsRequest), new EndpointBase.InvokeServiceEventHandler(this.CreateMonitoredItems)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.ModifyMonitoredItemsRequest, new EndpointBase.ServiceDefinition(typeof (ModifyMonitoredItemsRequest), new EndpointBase.InvokeServiceEventHandler(this.ModifyMonitoredItems)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.SetMonitoringModeRequest, new EndpointBase.ServiceDefinition(typeof (SetMonitoringModeRequest), new EndpointBase.InvokeServiceEventHandler(this.SetMonitoringMode)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.SetTriggeringRequest, new EndpointBase.ServiceDefinition(typeof (SetTriggeringRequest), new EndpointBase.InvokeServiceEventHandler(this.SetTriggering)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.DeleteMonitoredItemsRequest, new EndpointBase.ServiceDefinition(typeof (DeleteMonitoredItemsRequest), new EndpointBase.InvokeServiceEventHandler(this.DeleteMonitoredItems)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.CreateSubscriptionRequest, new EndpointBase.ServiceDefinition(typeof (CreateSubscriptionRequest), new EndpointBase.InvokeServiceEventHandler(this.CreateSubscription)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.ModifySubscriptionRequest, new EndpointBase.ServiceDefinition(typeof (ModifySubscriptionRequest), new EndpointBase.InvokeServiceEventHandler(this.ModifySubscription)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.SetPublishingModeRequest, new EndpointBase.ServiceDefinition(typeof (SetPublishingModeRequest), new EndpointBase.InvokeServiceEventHandler(this.SetPublishingMode)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.PublishRequest, new EndpointBase.ServiceDefinition(typeof (PublishRequest), new EndpointBase.InvokeServiceEventHandler(this.Publish)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.RepublishRequest, new EndpointBase.ServiceDefinition(typeof (RepublishRequest), new EndpointBase.InvokeServiceEventHandler(this.Republish)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.TransferSubscriptionsRequest, new EndpointBase.ServiceDefinition(typeof (TransferSubscriptionsRequest), new EndpointBase.InvokeServiceEventHandler(this.TransferSubscriptions)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.DeleteSubscriptionsRequest, new EndpointBase.ServiceDefinition(typeof (DeleteSubscriptionsRequest), new EndpointBase.InvokeServiceEventHandler(this.DeleteSubscriptions)));
  }
}
