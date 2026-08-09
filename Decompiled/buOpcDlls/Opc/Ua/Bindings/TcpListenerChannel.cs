using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpListenerChannel : UaSCUaBinaryChannel
{
	private ITcpChannelListener m_listener;

	private bool m_responseRequired;

	private TcpChannelRequestEventHandler m_requestReceived;

	private ReportAuditOpenSecureChannelEventHandler m_reportAuditOpenSecureChannelEvent;

	private ReportAuditCloseSecureChannelEventHandler m_reportAuditCloseSecureChannelEvent;

	private ReportAuditCertificateEventHandler m_reportAuditCertificateEvent;

	private long m_lastTokenId;

	private Timer m_cleanupTimer;

	public virtual string ChannelName => "TCPLISTENERCHANNEL";

	protected ITcpChannelListener Listener => m_listener;

	protected TcpChannelRequestEventHandler RequestReceived => m_requestReceived;

	protected ReportAuditOpenSecureChannelEventHandler ReportAuditOpenSecureChannelEvent => m_reportAuditOpenSecureChannelEvent;

	protected ReportAuditCloseSecureChannelEventHandler ReportAuditCloseSecureChannelEvent => m_reportAuditCloseSecureChannelEvent;

	protected ReportAuditCertificateEventHandler ReportAuditCertificateEvent => m_reportAuditCertificateEvent;

	public TcpListenerChannel(string contextId, ITcpChannelListener listener, BufferManager bufferManager, ChannelQuotas quotas, X509Certificate2 serverCertificate, EndpointDescriptionCollection endpoints)
		: this(contextId, listener, bufferManager, quotas, serverCertificate, null, endpoints)
	{
	}

	public TcpListenerChannel(string contextId, ITcpChannelListener listener, BufferManager bufferManager, ChannelQuotas quotas, X509Certificate2 serverCertificate, X509Certificate2Collection serverCertificateChain, EndpointDescriptionCollection endpoints)
		: base(contextId, bufferManager, quotas, serverCertificate, serverCertificateChain, endpoints, MessageSecurityMode.None, "http://opcfoundation.org/UA/SecurityPolicy#None")
	{
		m_listener = listener;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Utils.SilentDispose(m_cleanupTimer);
			m_cleanupTimer = null;
		}
		base.Dispose(disposing);
	}

	public void SetRequestReceivedCallback(TcpChannelRequestEventHandler callback)
	{
		lock (base.DataLock)
		{
			m_requestReceived = callback;
		}
	}

	public void SetReportOpenSecureChannellAuditCalback(ReportAuditOpenSecureChannelEventHandler callback)
	{
		lock (base.DataLock)
		{
			m_reportAuditOpenSecureChannelEvent = callback;
		}
	}

	public void SetReportCloseSecureChannellAuditCalback(ReportAuditCloseSecureChannelEventHandler callback)
	{
		lock (base.DataLock)
		{
			m_reportAuditCloseSecureChannelEvent = callback;
		}
	}

	public void SetReportCertificateAuditCalback(ReportAuditCertificateEventHandler callback)
	{
		lock (base.DataLock)
		{
			m_reportAuditCertificateEvent = callback;
		}
	}

	public void Attach(uint channelId, Socket socket)
	{
		if (socket == null)
		{
			throw new ArgumentNullException("socket");
		}
		lock (base.DataLock)
		{
			if (base.Socket != null)
			{
				throw new InvalidOperationException("Channel is already attached to a socket.");
			}
			base.ChannelId = channelId;
			base.State = TcpChannelState.Connecting;
			base.Socket = new TcpMessageSocket(this, socket, base.BufferManager, base.Quotas.MaxBufferSize);
			Utils.LogInfo("{0} SOCKET ATTACHED: {1:X8}, ChannelId={2}", ChannelName, base.Socket.Handle, base.ChannelId);
			base.Socket.ReadNextMessage();
			StartCleanupTimer(2148139008u);
		}
	}

	protected override void HandleSocketError(ServiceResult result)
	{
		lock (base.DataLock)
		{
			if (ServiceResult.IsBad(result))
			{
				ForceChannelFault(result);
			}
			else
			{
				ChannelClosed();
			}
		}
	}

	protected void ForceChannelFault(uint statusCode, string format, params object[] args)
	{
		ForceChannelFault(ServiceResult.Create(statusCode, format, args));
	}

	protected void ForceChannelFault(Exception exception, uint defaultCode, string format, params object[] args)
	{
		ForceChannelFault(ServiceResult.Create(exception, defaultCode, format, args));
	}

	protected void ForceChannelFault(ServiceResult reason)
	{
		lock (base.DataLock)
		{
			Utils.LogError("{0} ForceChannelFault Socket={1:X8}, ChannelId={2}, TokenId={3}, Reason={4}", ChannelName, (base.Socket != null) ? base.Socket.Handle : 0, (base.CurrentToken != null) ? base.CurrentToken.ChannelId : 0u, (base.CurrentToken != null) ? base.CurrentToken.TokenId : 0u, reason);
			CompleteReverseHello(new ServiceResultException(reason));
			if (base.State != TcpChannelState.Faulted)
			{
				if (base.Socket != null && m_responseRequired)
				{
					SendErrorMessage(reason);
				}
				base.State = TcpChannelState.Faulted;
				m_responseRequired = false;
				NotifyMonitors(reason, closed: false);
				StartCleanupTimer(reason);
			}
		}
	}

	protected void StartCleanupTimer(ServiceResult reason)
	{
		CleanupTimer();
		m_cleanupTimer = new Timer(OnCleanup, reason, base.Quotas.ChannelLifetime, -1);
	}

	protected void CleanupTimer()
	{
		if (m_cleanupTimer != null)
		{
			m_cleanupTimer.Dispose();
			m_cleanupTimer = null;
		}
	}

	private void OnCleanup(object state)
	{
		lock (base.DataLock)
		{
			CleanupTimer();
			if (base.State != TcpChannelState.Closed && base.State != TcpChannelState.Open)
			{
				ServiceResult serviceResult = state as ServiceResult;
				if (serviceResult == null)
				{
					serviceResult = new ServiceResult(2148139008u);
				}
				Utils.LogInfo("{0} Cleanup Socket={1:X8}, ChannelId={2}, TokenId={3}, Reason={4}", ChannelName, (base.Socket != null) ? base.Socket.Handle : 0, (base.CurrentToken != null) ? base.CurrentToken.ChannelId : 0u, (base.CurrentToken != null) ? base.CurrentToken.TokenId : 0u, serviceResult.ToString());
				ChannelClosed();
			}
		}
	}

	protected void ChannelClosed()
	{
		try
		{
			if (base.Socket != null)
			{
				base.Socket.Close();
			}
		}
		finally
		{
			base.State = TcpChannelState.Closed;
			m_listener.ChannelClosed(base.ChannelId);
			NotifyMonitors(new ServiceResult(2158886912u), closed: true);
			CleanupTimer();
		}
	}

	protected void SendErrorMessage(ServiceResult error)
	{
		Utils.LogTrace("ChannelId {0}: SendErrorMessage={1}", base.ChannelId, error.StatusCode);
		byte[] array = base.BufferManager.TakeBuffer(base.SendBufferSize, "SendErrorMessage");
		try
		{
			using BinaryEncoder binaryEncoder = new BinaryEncoder(array, 0, base.SendBufferSize, base.Quotas.MessageContext);
			binaryEncoder.WriteUInt32(null, 1179800133u);
			binaryEncoder.WriteUInt32(null, 0u);
			UaSCUaBinaryChannel.WriteErrorMessageBody(binaryEncoder, error);
			int num = binaryEncoder.Close();
			UaSCUaBinaryChannel.UpdateMessageSize(array, 0, num);
			BeginWriteMessage(new ArraySegment<byte>(array, 0, num), null);
			array = null;
		}
		finally
		{
			if (array != null)
			{
				base.BufferManager.ReturnBuffer(array, "SendErrorMessage");
			}
		}
	}

	protected void SendServiceFault(ChannelToken token, uint requestId, ServiceResult fault)
	{
		Utils.LogTrace("ChannelId {0}: Request {1}: SendServiceFault={2}", base.ChannelId, requestId, fault.StatusCode);
		BufferCollection bufferCollection = null;
		try
		{
			ServiceFault serviceFault = new ServiceFault();
			serviceFault.ResponseHeader.ServiceResult = fault.Code;
			StringTable stringTable = new StringTable();
			serviceFault.ResponseHeader.ServiceDiagnostics = new DiagnosticInfo(fault, DiagnosticsMasks.NoInnerStatus, serviceLevel: true, stringTable);
			serviceFault.ResponseHeader.StringTable = stringTable.ToArray();
			bool limitsExceeded = false;
			bufferCollection = WriteSymmetricMessage(4674381u, requestId, token, serviceFault, isRequest: false, out limitsExceeded);
			BeginWriteMessage(bufferCollection, null);
			bufferCollection = null;
		}
		catch (Exception e)
		{
			bufferCollection?.Release(base.BufferManager, "SendServiceFault");
			ForceChannelFault(ServiceResult.Create(e, 2156003328u, "Unexpected error sending a service fault."));
		}
	}

	protected virtual void NotifyMonitors(ServiceResult status, bool closed)
	{
	}

	protected virtual void CompleteReverseHello(Exception e)
	{
	}

	protected void SendServiceFault(uint requestId, ServiceResult fault)
	{
		Utils.LogTrace("ChannelId {0}: Request {1}: SendServiceFault={2}", base.ChannelId, requestId, fault.StatusCode);
		BufferCollection bufferCollection = null;
		try
		{
			ServiceFault obj = new ServiceFault
			{
				ResponseHeader = 
				{
					ServiceResult = fault.Code
				}
			};
			StringTable stringTable = new StringTable();
			obj.ResponseHeader.ServiceDiagnostics = new DiagnosticInfo(fault, DiagnosticsMasks.NoInnerStatus, serviceLevel: true, stringTable);
			obj.ResponseHeader.StringTable = stringTable.ToArray();
			byte[] array = BinaryEncoder.EncodeMessage(obj, base.Quotas.MessageContext);
			bufferCollection = WriteAsymmetricMessage(5132367u, requestId, base.ServerCertificate, base.ClientCertificate, new ArraySegment<byte>(array, 0, array.Length));
			BeginWriteMessage(bufferCollection, null);
			bufferCollection = null;
		}
		catch (Exception e)
		{
			bufferCollection?.Release(base.BufferManager, "SendServiceFault");
			ForceChannelFault(ServiceResult.Create(e, 2156003328u, "Unexpected error sending a service fault."));
		}
	}

	public virtual void Reconnect(IMessageSocket socket, uint requestId, uint sequenceNumber, X509Certificate2 clientCertificate, ChannelToken token, OpenSecureChannelRequest request)
	{
		throw new NotImplementedException();
	}

	protected void SetResponseRequired(bool responseRequired)
	{
		m_responseRequired = responseRequired;
	}

	protected uint GetNewTokenId()
	{
		return Utils.IncrementIdentifier(ref m_lastTokenId);
	}
}
