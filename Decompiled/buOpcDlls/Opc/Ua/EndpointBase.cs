using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public abstract class EndpointBase : IEndpointBase, ITransportListenerCallback, IAuditEventCallback
{
	protected class ServiceDefinition
	{
		private Type m_requestType;

		private InvokeServiceEventHandler m_InvokeService;

		public Type RequestType => m_requestType;

		public Type ResponseType => m_requestType;

		public ServiceDefinition(Type requestType, InvokeServiceEventHandler invokeMethod)
		{
			m_requestType = requestType;
			m_InvokeService = invokeMethod;
		}

		public IServiceResponse Invoke(IServiceRequest request)
		{
			if (m_InvokeService != null)
			{
				return m_InvokeService(request);
			}
			return null;
		}
	}

	protected delegate IServiceResponse InvokeServiceEventHandler(IServiceRequest request);

	protected class ProcessRequestAsyncResult : AsyncResultBase, IEndpointIncomingRequest
	{
		private EndpointBase m_endpoint;

		private SecureChannelContext m_context;

		private IServiceRequest m_request;

		private IServiceResponse m_response;

		private ServiceDefinition m_service;

		private Exception m_error;

		private object m_calldata;

		public IServiceRequest Request => m_request;

		public SecureChannelContext SecureChannelContext => m_context;

		public object Calldata
		{
			get
			{
				return m_calldata;
			}
			set
			{
				m_calldata = value;
			}
		}

		public ProcessRequestAsyncResult(EndpointBase endpoint, AsyncCallback callback, object callbackData, int timeout)
			: base(callback, callbackData, timeout)
		{
			m_endpoint = endpoint;
		}

		public void CallSynchronously()
		{
			OnProcessRequest(null);
		}

		public void OperationCompleted(IServiceResponse response, ServiceResult error)
		{
			m_error = null;
			m_response = response;
			if (ServiceResult.IsBad(error))
			{
				m_error = new ServiceResultException(error);
				m_response = SaveExceptionAsResponse(m_error);
			}
			OperationCompleted();
		}

		public IAsyncResult BeginProcessRequest(SecureChannelContext context, byte[] requestData)
		{
			m_context = context;
			try
			{
				m_request = BinaryDecoder.DecodeMessage(requestData, null, m_endpoint.MessageContext) as IServiceRequest;
				m_service = m_endpoint.FindService(m_request.TypeId);
				if (m_service == null)
				{
					throw ServiceResultException.Create(2148204544u, "'{0}' is an unrecognized service type.", m_request.TypeId);
				}
				m_endpoint.ServerForContext.ScheduleIncomingRequest(this);
			}
			catch (Exception error)
			{
				m_response = SaveExceptionAsResponse(m_error = error);
				OperationCompleted();
			}
			return this;
		}

		public IAsyncResult BeginProcessRequest(SecureChannelContext context, IServiceRequest request)
		{
			m_context = context;
			m_request = request;
			try
			{
				m_service = m_endpoint.FindService(m_request.TypeId);
				if (m_service == null)
				{
					throw ServiceResultException.Create(2148204544u, "'{0}' is an unrecognized service type.", m_request.TypeId);
				}
				m_endpoint.ServerForContext.ScheduleIncomingRequest(this);
			}
			catch (Exception error)
			{
				m_response = SaveExceptionAsResponse(m_error = error);
				OperationCompleted();
			}
			return this;
		}

		public static IServiceResponse WaitForComplete(IAsyncResult ar, bool throwOnError)
		{
			if (!(ar is ProcessRequestAsyncResult processRequestAsyncResult))
			{
				throw new ArgumentException("End called with an invalid IAsyncResult object.", "ar");
			}
			if (processRequestAsyncResult.m_response == null && !processRequestAsyncResult.WaitForComplete())
			{
				throw new TimeoutException();
			}
			if (throwOnError && processRequestAsyncResult.m_error != null)
			{
				throw new ServiceResultException(processRequestAsyncResult.m_error, 2147614720u);
			}
			return processRequestAsyncResult.m_response;
		}

		public static IServiceRequest GetRequest(IAsyncResult ar)
		{
			if (ar is ProcessRequestAsyncResult processRequestAsyncResult)
			{
				return processRequestAsyncResult.m_request;
			}
			return null;
		}

		private IServiceResponse SaveExceptionAsResponse(Exception e)
		{
			try
			{
				return CreateFault(m_request, e);
			}
			catch (Exception exception)
			{
				return CreateFault(null, exception);
			}
		}

		private void OnProcessRequest(object state)
		{
			try
			{
				SecureChannelContext.Current = m_context;
				m_response = m_service.Invoke(m_request);
			}
			catch (Exception error)
			{
				m_response = SaveExceptionAsResponse(m_error = error);
			}
			OperationCompleted();
		}
	}

	private ServiceResult m_serverError;

	private IServiceMessageContext m_messageContext;

	private EndpointDescription m_endpointDescription;

	private Dictionary<ExpandedNodeId, ServiceDefinition> m_supportedServices;

	private IServiceHostBase m_host;

	private IServerBase m_server;

	private string g_ImplementationString = "Opc.Ua.EndpointBase UA Service " + Utils.GetAssemblySoftwareVersion();

	protected IServiceHostBase HostForContext
	{
		get
		{
			if (m_host == null)
			{
				m_host = GetHostForContext();
			}
			return m_host;
		}
	}

	protected IServerBase ServerForContext
	{
		get
		{
			if (m_server == null)
			{
				m_server = GetServerForContext();
			}
			return m_server;
		}
	}

	protected IServiceMessageContext MessageContext
	{
		get
		{
			return m_messageContext;
		}
		set
		{
			m_messageContext = value;
		}
	}

	protected EndpointDescription EndpointDescription
	{
		get
		{
			return m_endpointDescription;
		}
		set
		{
			m_endpointDescription = value;
		}
	}

	protected ServiceResult ServerError
	{
		get
		{
			return m_serverError;
		}
		set
		{
			m_serverError = value;
		}
	}

	protected Dictionary<ExpandedNodeId, ServiceDefinition> SupportedServices
	{
		get
		{
			return m_supportedServices;
		}
		set
		{
			m_supportedServices = value;
		}
	}

	protected EndpointBase()
	{
		SupportedServices = new Dictionary<ExpandedNodeId, ServiceDefinition>();
		try
		{
			m_host = GetHostForContext();
			m_server = GetServerForContext();
			MessageContext = m_server.MessageContext;
			EndpointDescription = GetEndpointDescription();
		}
		catch (Exception exception)
		{
			ServerError = new ServiceResult(exception);
			EndpointDescription = null;
			m_host = null;
			m_server = null;
		}
	}

	protected EndpointBase(IServiceHostBase host)
	{
		if (host == null)
		{
			throw new ArgumentNullException("host");
		}
		m_host = host;
		m_server = host.Server;
		SupportedServices = new Dictionary<ExpandedNodeId, ServiceDefinition>();
	}

	protected EndpointBase(ServerBase server)
	{
		if (server == null)
		{
			throw new ArgumentNullException("server");
		}
		m_host = null;
		m_server = server;
		SupportedServices = new Dictionary<ExpandedNodeId, ServiceDefinition>();
	}

	public IAsyncResult BeginProcessRequest(string channeId, EndpointDescription endpointDescription, IServiceRequest request, AsyncCallback callback, object callbackData)
	{
		if (channeId == null)
		{
			throw new ArgumentNullException("channeId");
		}
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		ProcessRequestAsyncResult processRequestAsyncResult = new ProcessRequestAsyncResult(this, callback, callbackData, 0);
		SecureChannelContext context = new SecureChannelContext(channeId, endpointDescription, RequestEncoding.Binary);
		return processRequestAsyncResult.BeginProcessRequest(context, request);
	}

	public IServiceResponse EndProcessRequest(IAsyncResult result)
	{
		return ProcessRequestAsyncResult.WaitForComplete(result, throwOnError: false);
	}

	public void ReportAuditOpenSecureChannelEvent(string globalChannelId, EndpointDescription endpointDescription, OpenSecureChannelRequest request, X509Certificate2 clientCertificate, Exception exception)
	{
		ServerForContext?.ReportAuditOpenSecureChannelEvent(globalChannelId, endpointDescription, request, clientCertificate, exception);
	}

	public void ReportAuditCloseSecureChannelEvent(string globalChannelId, Exception exception)
	{
		ServerForContext?.ReportAuditCloseSecureChannelEvent(globalChannelId, exception);
	}

	public void ReportAuditCertificateEvent(X509Certificate2 clientCertificate, Exception exception)
	{
		ServerForContext?.ReportAuditCertificateEvent(clientCertificate, exception);
	}

	public virtual IServiceResponse ProcessRequest(IServiceRequest incoming)
	{
		try
		{
			SetRequestContext(RequestEncoding.Binary);
			ServiceDefinition value = null;
			if (!SupportedServices.TryGetValue(incoming.TypeId, out value))
			{
				throw new ServiceResultException(2148204544u, Utils.Format("'{0}' is an unrecognized service identifier.", incoming.TypeId));
			}
			return value.Invoke(incoming);
		}
		catch (Exception exception)
		{
			return CreateFault(incoming, exception);
		}
	}

	public virtual IAsyncResult BeginInvokeService(InvokeServiceMessage request, AsyncCallback callback, object asyncState)
	{
		try
		{
			if (request == null)
			{
				throw new ServiceResultException(2158690304u);
			}
			SetRequestContext(RequestEncoding.Binary);
			return new ProcessRequestAsyncResult(this, callback, asyncState, 0).BeginProcessRequest(SecureChannelContext.Current, request.InvokeServiceRequest);
		}
		catch (Exception exception)
		{
			throw CreateSoapFault(null, exception);
		}
	}

	public virtual InvokeServiceResponseMessage EndInvokeService(IAsyncResult result)
	{
		try
		{
			IServiceResponse message = ProcessRequestAsyncResult.WaitForComplete(result, throwOnError: false);
			return new InvokeServiceResponseMessage
			{
				InvokeServiceResponse = BinaryEncoder.EncodeMessage(message, MessageContext)
			};
		}
		catch (Exception exception)
		{
			ServiceFault message2 = CreateFault(ProcessRequestAsyncResult.GetRequest(result), exception);
			return new InvokeServiceResponseMessage
			{
				InvokeServiceResponse = BinaryEncoder.EncodeMessage(message2, MessageContext)
			};
		}
	}

	protected static IServiceHostBase GetHostForContext()
	{
		throw new ServiceResultException(2147614720u, "The endpoint is not associated with a host that supports IServerHostBase.");
	}

	protected IServerBase GetServerForContext()
	{
		IServerBase server = HostForContext.Server;
		if (server == null)
		{
			throw new ServiceResultException(2147614720u, "The endpoint is not associated with a server instance.");
		}
		if (ServiceResult.IsBad(server.ServerError))
		{
			throw new ServiceResultException(server.ServerError);
		}
		return server;
	}

	protected EndpointDescription GetEndpointDescription()
	{
		return null;
	}

	protected ServiceDefinition FindService(ExpandedNodeId requestTypeId)
	{
		ServiceDefinition value = null;
		if (!SupportedServices.TryGetValue(requestTypeId, out value))
		{
			throw ServiceResultException.Create(2148204544u, "'{0}' is an unrecognized service identifier.", requestTypeId);
		}
		return value;
	}

	public static ServiceFault CreateFault(IServiceRequest request, Exception exception)
	{
		DiagnosticsMasks diagnosticsMask = DiagnosticsMasks.ServiceNoInnerStatus;
		ServiceFault serviceFault = new ServiceFault();
		if (request != null)
		{
			serviceFault.ResponseHeader.Timestamp = DateTime.UtcNow;
			serviceFault.ResponseHeader.RequestHandle = request.RequestHeader.RequestHandle;
			if (request.RequestHeader != null)
			{
				diagnosticsMask = (DiagnosticsMasks)request.RequestHeader.ReturnDiagnostics;
			}
		}
		ServiceResult serviceResult = null;
		if (exception is ServiceResultException ex)
		{
			serviceResult = new ServiceResult(ex);
			Utils.LogWarning("SERVER - Service Fault Occurred. Reason={0}", serviceResult.StatusCode);
			if (ex.StatusCode == 2147549184u)
			{
				Utils.LogWarning(4, ex, ex.ToString());
			}
		}
		else
		{
			serviceResult = new ServiceResult(exception, 2147549184u);
			Utils.LogError(exception, "SERVER - Unexpected Service Fault: {0}", exception.Message);
		}
		serviceFault.ResponseHeader.ServiceResult = serviceResult.Code;
		StringTable stringTable = new StringTable();
		serviceFault.ResponseHeader.ServiceDiagnostics = new DiagnosticInfo(serviceResult, diagnosticsMask, serviceLevel: true, stringTable);
		serviceFault.ResponseHeader.StringTable = stringTable.ToArray();
		return serviceFault;
	}

	public static Exception CreateSoapFault(IServiceRequest request, Exception exception)
	{
		ServiceResult serviceResult = CreateFault(request, exception).ResponseHeader.ServiceResult;
		if (serviceResult == null)
		{
			serviceResult = ServiceResult.Create(2147549184u, "An unknown error occurred.");
		}
		string browseName = StatusCodes.GetBrowseName(serviceResult.Code);
		return new ServiceResultException((uint)serviceResult.StatusCode, browseName, exception);
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
}
