// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EndpointBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public abstract class EndpointBase : IEndpointBase, ITransportListenerCallback, IAuditEventCallback
{
  private ServiceResult m_serverError;
  private IServiceMessageContext m_messageContext;
  private EndpointDescription m_endpointDescription;
  private Dictionary<ExpandedNodeId, EndpointBase.ServiceDefinition> m_supportedServices;
  private IServiceHostBase m_host;
  private IServerBase m_server;
  private string g_ImplementationString = "Opc.Ua.EndpointBase UA Service " + Utils.GetAssemblySoftwareVersion();

  protected EndpointBase()
  {
    this.SupportedServices = new Dictionary<ExpandedNodeId, EndpointBase.ServiceDefinition>();
    try
    {
      this.m_host = EndpointBase.GetHostForContext();
      this.m_server = this.GetServerForContext();
      this.MessageContext = this.m_server.MessageContext;
      this.EndpointDescription = this.GetEndpointDescription();
    }
    catch (Exception ex)
    {
      this.ServerError = new ServiceResult(ex);
      this.EndpointDescription = (EndpointDescription) null;
      this.m_host = (IServiceHostBase) null;
      this.m_server = (IServerBase) null;
    }
  }

  protected EndpointBase(IServiceHostBase host)
  {
    this.m_host = host != null ? host : throw new ArgumentNullException(nameof (host));
    this.m_server = host.Server;
    this.SupportedServices = new Dictionary<ExpandedNodeId, EndpointBase.ServiceDefinition>();
  }

  protected EndpointBase(ServerBase server)
  {
    if (server == null)
      throw new ArgumentNullException(nameof (server));
    this.m_host = (IServiceHostBase) null;
    this.m_server = (IServerBase) server;
    this.SupportedServices = new Dictionary<ExpandedNodeId, EndpointBase.ServiceDefinition>();
  }

  public IAsyncResult BeginProcessRequest(
    string channeId,
    EndpointDescription endpointDescription,
    IServiceRequest request,
    AsyncCallback callback,
    object callbackData)
  {
    if (channeId == null)
      throw new ArgumentNullException(nameof (channeId));
    if (request == null)
      throw new ArgumentNullException(nameof (request));
    return new EndpointBase.ProcessRequestAsyncResult(this, callback, callbackData, 0).BeginProcessRequest(new SecureChannelContext(channeId, endpointDescription, RequestEncoding.Binary), request);
  }

  public IServiceResponse EndProcessRequest(IAsyncResult result)
  {
    return EndpointBase.ProcessRequestAsyncResult.WaitForComplete(result, false);
  }

  public void ReportAuditOpenSecureChannelEvent(
    string globalChannelId,
    EndpointDescription endpointDescription,
    OpenSecureChannelRequest request,
    X509Certificate2 clientCertificate,
    Exception exception)
  {
    this.ServerForContext?.ReportAuditOpenSecureChannelEvent(globalChannelId, endpointDescription, request, clientCertificate, exception);
  }

  public void ReportAuditCloseSecureChannelEvent(string globalChannelId, Exception exception)
  {
    this.ServerForContext?.ReportAuditCloseSecureChannelEvent(globalChannelId, exception);
  }

  public void ReportAuditCertificateEvent(X509Certificate2 clientCertificate, Exception exception)
  {
    this.ServerForContext?.ReportAuditCertificateEvent(clientCertificate, exception);
  }

  public virtual IServiceResponse ProcessRequest(IServiceRequest incoming)
  {
    try
    {
      this.SetRequestContext(RequestEncoding.Binary);
      EndpointBase.ServiceDefinition serviceDefinition = (EndpointBase.ServiceDefinition) null;
      if (!this.SupportedServices.TryGetValue(incoming.TypeId, out serviceDefinition))
        throw new ServiceResultException(2148204544U /*0x800B0000*/, Utils.Format("'{0}' is an unrecognized service identifier.", (object) incoming.TypeId));
      return serviceDefinition.Invoke(incoming);
    }
    catch (Exception ex)
    {
      return (IServiceResponse) EndpointBase.CreateFault(incoming, ex);
    }
  }

  public virtual IAsyncResult BeginInvokeService(
    InvokeServiceMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    try
    {
      if (request == null)
        throw new ServiceResultException(2158690304U /*0x80AB0000*/);
      this.SetRequestContext(RequestEncoding.Binary);
      return new EndpointBase.ProcessRequestAsyncResult(this, callback, asyncState, 0).BeginProcessRequest(SecureChannelContext.Current, request.InvokeServiceRequest);
    }
    catch (Exception ex)
    {
      throw EndpointBase.CreateSoapFault((IServiceRequest) null, ex);
    }
  }

  public virtual InvokeServiceResponseMessage EndInvokeService(IAsyncResult result)
  {
    try
    {
      IServiceResponse message = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(result, false);
      return new InvokeServiceResponseMessage()
      {
        InvokeServiceResponse = BinaryEncoder.EncodeMessage((IEncodeable) message, this.MessageContext)
      };
    }
    catch (Exception ex)
    {
      ServiceFault fault = EndpointBase.CreateFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(result), ex);
      return new InvokeServiceResponseMessage()
      {
        InvokeServiceResponse = BinaryEncoder.EncodeMessage((IEncodeable) fault, this.MessageContext)
      };
    }
  }

  protected IServiceHostBase HostForContext
  {
    get
    {
      if (this.m_host == null)
        this.m_host = EndpointBase.GetHostForContext();
      return this.m_host;
    }
  }

  protected static IServiceHostBase GetHostForContext()
  {
    throw new ServiceResultException(2147614720U /*0x80020000*/, "The endpoint is not associated with a host that supports IServerHostBase.");
  }

  protected IServerBase ServerForContext
  {
    get
    {
      if (this.m_server == null)
        this.m_server = this.GetServerForContext();
      return this.m_server;
    }
  }

  protected IServerBase GetServerForContext()
  {
    IServerBase server = this.HostForContext.Server;
    if (server == null)
      throw new ServiceResultException(2147614720U /*0x80020000*/, "The endpoint is not associated with a server instance.");
    return !ServiceResult.IsBad(server.ServerError) ? server : throw new ServiceResultException(server.ServerError);
  }

  protected EndpointDescription GetEndpointDescription() => (EndpointDescription) null;

  protected EndpointBase.ServiceDefinition FindService(ExpandedNodeId requestTypeId)
  {
    EndpointBase.ServiceDefinition service = (EndpointBase.ServiceDefinition) null;
    if (!this.SupportedServices.TryGetValue(requestTypeId, out service))
      throw ServiceResultException.Create(2148204544U /*0x800B0000*/, "'{0}' is an unrecognized service identifier.", (object) requestTypeId);
    return service;
  }

  public static ServiceFault CreateFault(IServiceRequest request, Exception exception)
  {
    DiagnosticsMasks diagnosticsMask = DiagnosticsMasks.ServiceNoInnerStatus;
    ServiceFault fault = new ServiceFault();
    if (request != null)
    {
      fault.ResponseHeader.Timestamp = DateTime.UtcNow;
      fault.ResponseHeader.RequestHandle = request.RequestHeader.RequestHandle;
      if (request.RequestHeader != null)
        diagnosticsMask = (DiagnosticsMasks) request.RequestHeader.ReturnDiagnostics;
    }
    ServiceResult result;
    if (exception is ServiceResultException serviceResultException)
    {
      result = new ServiceResult((Exception) serviceResultException);
      Utils.LogWarning("SERVER - Service Fault Occurred. Reason={0}", (object) result.StatusCode);
      if (serviceResultException.StatusCode == 2147549184U /*0x80010000*/)
        Utils.LogWarning((EventId) 4, (Exception) serviceResultException, serviceResultException.ToString());
    }
    else
    {
      result = new ServiceResult(exception, 2147549184U /*0x80010000*/);
      Utils.LogError(exception, "SERVER - Unexpected Service Fault: {0}", (object) exception.Message);
    }
    fault.ResponseHeader.ServiceResult = (StatusCode) result.Code;
    StringTable stringTable = new StringTable();
    fault.ResponseHeader.ServiceDiagnostics = new DiagnosticInfo(result, diagnosticsMask, true, stringTable);
    fault.ResponseHeader.StringTable = (StringCollection) stringTable.ToArray();
    return fault;
  }

  public static Exception CreateSoapFault(IServiceRequest request, Exception exception)
  {
    ServiceResult serviceResult = (ServiceResult) EndpointBase.CreateFault(request, exception).ResponseHeader.ServiceResult ?? ServiceResult.Create(2147549184U /*0x80010000*/, "An unknown error occurred.");
    string browseName = StatusCodes.GetBrowseName(serviceResult.Code);
    return (Exception) new ServiceResultException((uint) serviceResult.StatusCode, browseName, exception);
  }

  protected IServiceMessageContext MessageContext
  {
    get => this.m_messageContext;
    set => this.m_messageContext = value;
  }

  protected EndpointDescription EndpointDescription
  {
    get => this.m_endpointDescription;
    set => this.m_endpointDescription = value;
  }

  protected ServiceResult ServerError
  {
    get => this.m_serverError;
    set => this.m_serverError = value;
  }

  protected Dictionary<ExpandedNodeId, EndpointBase.ServiceDefinition> SupportedServices
  {
    get => this.m_supportedServices;
    set => this.m_supportedServices = value;
  }

  protected void SetRequestContext(RequestEncoding encoding)
  {
  }

  protected virtual void OnRequestReceived(IServiceRequest request)
  {
  }

  protected virtual void OnResponseSent(IServiceResponse response)
  {
  }

  protected virtual void OnResponseFaultSent(Exception fault)
  {
  }

  protected class ServiceDefinition
  {
    private Type m_requestType;
    private EndpointBase.InvokeServiceEventHandler m_InvokeService;

    public ServiceDefinition(
      Type requestType,
      EndpointBase.InvokeServiceEventHandler invokeMethod)
    {
      this.m_requestType = requestType;
      this.m_InvokeService = invokeMethod;
    }

    public Type RequestType => this.m_requestType;

    public Type ResponseType => this.m_requestType;

    public IServiceResponse Invoke(IServiceRequest request)
    {
      return this.m_InvokeService != null ? this.m_InvokeService(request) : (IServiceResponse) null;
    }
  }

  protected delegate IServiceResponse InvokeServiceEventHandler(IServiceRequest request);

  protected class ProcessRequestAsyncResult : AsyncResultBase, IEndpointIncomingRequest
  {
    private EndpointBase m_endpoint;
    private SecureChannelContext m_context;
    private IServiceRequest m_request;
    private IServiceResponse m_response;
    private EndpointBase.ServiceDefinition m_service;
    private Exception m_error;
    private object m_calldata;

    public ProcessRequestAsyncResult(
      EndpointBase endpoint,
      AsyncCallback callback,
      object callbackData,
      int timeout)
      : base(callback, callbackData, timeout)
    {
      this.m_endpoint = endpoint;
    }

    public IServiceRequest Request => this.m_request;

    public SecureChannelContext SecureChannelContext => this.m_context;

    public object Calldata
    {
      get => this.m_calldata;
      set => this.m_calldata = value;
    }

    public void CallSynchronously() => this.OnProcessRequest((object) null);

    public void OperationCompleted(IServiceResponse response, ServiceResult error)
    {
      this.m_error = (Exception) null;
      this.m_response = response;
      if (ServiceResult.IsBad(error))
      {
        this.m_error = (Exception) new ServiceResultException(error);
        this.m_response = this.SaveExceptionAsResponse(this.m_error);
      }
      this.OperationCompleted();
    }

    public IAsyncResult BeginProcessRequest(SecureChannelContext context, byte[] requestData)
    {
      this.m_context = context;
      try
      {
        this.m_request = BinaryDecoder.DecodeMessage(requestData, (Type) null, this.m_endpoint.MessageContext) as IServiceRequest;
        this.m_service = this.m_endpoint.FindService(this.m_request.TypeId);
        if (this.m_service == null)
          throw ServiceResultException.Create(2148204544U /*0x800B0000*/, "'{0}' is an unrecognized service type.", (object) this.m_request.TypeId);
        this.m_endpoint.ServerForContext.ScheduleIncomingRequest((IEndpointIncomingRequest) this);
      }
      catch (Exception ex)
      {
        this.m_error = ex;
        this.m_response = this.SaveExceptionAsResponse(ex);
        this.OperationCompleted();
      }
      return (IAsyncResult) this;
    }

    public IAsyncResult BeginProcessRequest(SecureChannelContext context, IServiceRequest request)
    {
      this.m_context = context;
      this.m_request = request;
      try
      {
        this.m_service = this.m_endpoint.FindService(this.m_request.TypeId);
        if (this.m_service == null)
          throw ServiceResultException.Create(2148204544U /*0x800B0000*/, "'{0}' is an unrecognized service type.", (object) this.m_request.TypeId);
        this.m_endpoint.ServerForContext.ScheduleIncomingRequest((IEndpointIncomingRequest) this);
      }
      catch (Exception ex)
      {
        this.m_error = ex;
        this.m_response = this.SaveExceptionAsResponse(ex);
        this.OperationCompleted();
      }
      return (IAsyncResult) this;
    }

    public static IServiceResponse WaitForComplete(IAsyncResult ar, bool throwOnError)
    {
      if (!(ar is EndpointBase.ProcessRequestAsyncResult requestAsyncResult))
        throw new ArgumentException("End called with an invalid IAsyncResult object.", nameof (ar));
      if (requestAsyncResult.m_response == null && !requestAsyncResult.WaitForComplete())
        throw new TimeoutException();
      if (throwOnError && requestAsyncResult.m_error != null)
        throw new ServiceResultException(requestAsyncResult.m_error, 2147614720U /*0x80020000*/);
      return requestAsyncResult.m_response;
    }

    public static IServiceRequest GetRequest(IAsyncResult ar)
    {
      return ar is EndpointBase.ProcessRequestAsyncResult requestAsyncResult ? requestAsyncResult.m_request : (IServiceRequest) null;
    }

    private IServiceResponse SaveExceptionAsResponse(Exception e)
    {
      try
      {
        return (IServiceResponse) EndpointBase.CreateFault(this.m_request, e);
      }
      catch (Exception ex)
      {
        return (IServiceResponse) EndpointBase.CreateFault((IServiceRequest) null, ex);
      }
    }

    private void OnProcessRequest(object state)
    {
      try
      {
        SecureChannelContext.Current = this.m_context;
        this.m_response = this.m_service.Invoke(this.m_request);
      }
      catch (Exception ex)
      {
        this.m_error = ex;
        this.m_response = this.SaveExceptionAsResponse(ex);
      }
      this.OperationCompleted();
    }
  }
}
