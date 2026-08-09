using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua;

[ComVisible(true)]
public class ClientBase : IClientBase, IDisposable
{
	private readonly object m_lock = new object();

	private ITransportChannel m_channel;

	private NodeId m_authenticationToken;

	private DiagnosticsMasks m_returnDiagnostics;

	private int m_nextRequestHandle;

	private int m_pendingRequestCount;

	private bool m_disposed;

	private bool m_useTransportChannel;

	public EndpointDescription Endpoint => TransportChannel?.EndpointDescription;

	public EndpointConfiguration EndpointConfiguration => TransportChannel?.EndpointConfiguration;

	public IServiceMessageContext MessageContext => TransportChannel?.MessageContext;

	public ITransportChannel TransportChannel
	{
		get
		{
			ITransportChannel channel = m_channel;
			if (channel != null && m_disposed)
			{
				throw new ObjectDisposedException("ClientBase has been disposed.");
			}
			return channel;
		}
		protected set
		{
			if (m_channel == value)
			{
				return;
			}
			ITransportChannel channel = m_channel;
			m_channel = null;
			if (channel != null)
			{
				try
				{
					channel.Close();
					channel.Dispose();
				}
				catch
				{
				}
			}
			m_channel = value;
		}
	}

	internal IChannelBase InnerChannel
	{
		get
		{
			if (TransportChannel != null)
			{
				return m_channel as IChannelBase;
			}
			return null;
		}
	}

	public DiagnosticsMasks ReturnDiagnostics
	{
		get
		{
			return m_returnDiagnostics;
		}
		set
		{
			m_returnDiagnostics = value;
		}
	}

	public int OperationTimeout
	{
		get
		{
			if (TransportChannel != null)
			{
				return m_channel.OperationTimeout;
			}
			return 0;
		}
		set
		{
			if (TransportChannel != null)
			{
				m_channel.OperationTimeout = value;
			}
		}
	}

	protected bool UseTransportChannel
	{
		get
		{
			if (TransportChannel == null)
			{
				throw new ObjectDisposedException("TransportChannel is not available.");
			}
			return m_useTransportChannel;
		}
	}

	public bool Disposed => m_disposed;

	protected object SyncRoot => m_lock;

	protected NodeId AuthenticationToken
	{
		get
		{
			return m_authenticationToken;
		}
		set
		{
			m_authenticationToken = value;
		}
	}

	public ClientBase(ITransportChannel channel)
	{
		if (channel == null)
		{
			throw new ArgumentNullException("channel");
		}
		InitializeChannel(channel);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		CloseChannel();
		m_disposed = true;
	}

	public void AttachChannel(ITransportChannel channel)
	{
		InitializeChannel(channel);
	}

	public void DetachChannel()
	{
		m_channel = null;
	}

	public virtual StatusCode Close()
	{
		if (m_channel != null)
		{
			m_channel.Close();
			m_channel = null;
		}
		m_authenticationToken = null;
		return 0u;
	}

	public virtual async Task<StatusCode> CloseAsync(CancellationToken ct = default(CancellationToken))
	{
		if (m_channel != null)
		{
			await m_channel.CloseAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			m_channel = null;
		}
		m_authenticationToken = null;
		return 0u;
	}

	public uint NewRequestHandle()
	{
		return (uint)Utils.IncrementIdentifier(ref m_nextRequestHandle);
	}

	protected void InitializeChannel(ITransportChannel channel)
	{
		m_channel = channel;
		m_useTransportChannel = true;
		if (channel is UaChannelBase uaChannelBase)
		{
			m_useTransportChannel = uaChannelBase.m_uaBypassChannel != null || uaChannelBase.UseBinaryEncoding;
		}
	}

	protected void CloseChannel()
	{
		if (m_channel != null)
		{
			try
			{
				m_channel.Close();
			}
			catch
			{
			}
			DisposeChannel();
		}
	}

	protected void DisposeChannel()
	{
		if (m_channel != null)
		{
			try
			{
				m_channel.Dispose();
			}
			catch
			{
			}
			m_channel = null;
		}
	}

	[Obsolete("Must override the version with useDefault parameter.")]
	protected virtual void UpdateRequestHeader(IServiceRequest request)
	{
		UpdateRequestHeader(request, request == null);
	}

	protected virtual void UpdateRequestHeader(IServiceRequest request, bool useDefaults)
	{
		lock (m_lock)
		{
			if (request.RequestHeader == null)
			{
				request.RequestHeader = new RequestHeader();
			}
			if (useDefaults)
			{
				request.RequestHeader.ReturnDiagnostics = (uint)m_returnDiagnostics;
			}
			if (request.RequestHeader.RequestHandle == 0)
			{
				request.RequestHeader.RequestHandle = (uint)Utils.IncrementIdentifier(ref m_nextRequestHandle);
			}
			if (NodeId.IsNull(request.RequestHeader.AuthenticationToken))
			{
				request.RequestHeader.AuthenticationToken = m_authenticationToken;
			}
			request.RequestHeader.Timestamp = DateTime.UtcNow;
			request.RequestHeader.AuditEntryId = CreateAuditLogEntry(request);
		}
	}

	protected virtual void UpdateRequestHeader(IServiceRequest request, bool useDefaults, string serviceName)
	{
		UpdateRequestHeader(request, useDefaults);
		int pendingRequestCount = Interlocked.Increment(ref m_pendingRequestCount);
		Utils.EventLog.ServiceCallStart(serviceName, (int)request.RequestHeader.RequestHandle, pendingRequestCount);
	}

	protected virtual void RequestCompleted(IServiceRequest request, IServiceResponse response, string serviceName)
	{
		uint requestHandle = 0u;
		StatusCode statusCode = 0u;
		if (request != null)
		{
			requestHandle = request.RequestHeader.RequestHandle;
		}
		else if (response != null)
		{
			requestHandle = response.ResponseHeader.RequestHandle;
			statusCode = response.ResponseHeader.ServiceResult;
		}
		if (response == null)
		{
			statusCode = 2147483648u;
		}
		int pendingRequestCount = Interlocked.Decrement(ref m_pendingRequestCount);
		if (statusCode != 0u)
		{
			Utils.EventLog.ServiceCallBadStop(serviceName, (int)requestHandle, (int)statusCode.Code, pendingRequestCount);
		}
		else
		{
			Utils.EventLog.ServiceCallStop(serviceName, (int)requestHandle, pendingRequestCount);
		}
	}

	protected virtual string CreateAuditLogEntry(IServiceRequest request)
	{
		return request.RequestHeader.AuditEntryId;
	}

	protected static void ValidateResponse(ResponseHeader header)
	{
		if (header == null)
		{
			throw new ServiceResultException(2148073472u, "Null header in response.");
		}
		if (StatusCode.IsBad(header.ServiceResult))
		{
			throw new ServiceResultException(new ServiceResult(header.ServiceResult, header.ServiceDiagnostics, header.StringTable));
		}
	}

	public static void ValidateResponse(IList response, IList request)
	{
		if (response is DiagnosticInfoCollection)
		{
			throw new ArgumentException("Must call ValidateDiagnosticInfos() for DiagnosticInfoCollections.", "response");
		}
		if (response == null || response.Count != request.Count)
		{
			throw new ServiceResultException(2147549184u, "The server returned a list without the expected number of elements.");
		}
	}

	public static void ValidateDiagnosticInfos(DiagnosticInfoCollection response, IList request)
	{
		if (response != null && response.Count != 0 && response.Count != request.Count)
		{
			throw new ServiceResultException(2147549184u, "The server forgot to fill in the DiagnosticInfos array correctly when returning an operation level error.");
		}
	}

	public static ServiceResult GetResult(StatusCode statusCode, int index, DiagnosticInfoCollection diagnosticInfos, ResponseHeader responseHeader)
	{
		if (diagnosticInfos != null && diagnosticInfos.Count > index)
		{
			return new ServiceResult(statusCode.Code, diagnosticInfos[index], responseHeader.StringTable);
		}
		return new ServiceResult(statusCode.Code);
	}

	public static ServiceResult ValidateDataValue(DataValue value, Type expectedType, int index, DiagnosticInfoCollection diagnosticInfos, ResponseHeader responseHeader)
	{
		if (value == null)
		{
			return new ServiceResult(2147549184u, "The server returned a value for a data value.");
		}
		if (StatusCode.IsBad(value.StatusCode))
		{
			return GetResult(value.StatusCode, index, diagnosticInfos, responseHeader);
		}
		if (expectedType != null && !expectedType.IsInstanceOfType(value.Value))
		{
			return ServiceResult.Create(2147549184u, "The server returned data value of type {0} when a value of type {1} was expected.", (value.Value != null) ? value.Value.GetType().Name : "(null)", expectedType.Name);
		}
		return null;
	}
}
