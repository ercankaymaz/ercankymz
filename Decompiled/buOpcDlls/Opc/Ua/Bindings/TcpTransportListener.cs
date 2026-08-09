using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpTransportListener : ITransportListener, IDisposable, ITcpChannelListener
{
	private readonly object m_lock = new object();

	private string m_listenerId;

	private Uri m_uri;

	private EndpointDescriptionCollection m_descriptions;

	private BufferManager m_bufferManager;

	private ChannelQuotas m_quotas;

	private X509Certificate2 m_serverCertificate;

	private X509Certificate2Collection m_serverCertificateChain;

	private uint m_lastChannelId;

	private Socket m_listeningSocket;

	private Socket m_listeningSocketIPv6;

	private Dictionary<uint, TcpListenerChannel> m_channels;

	private ITransportListenerCallback m_callback;

	private bool m_reverseConnectListener;

	public string UriScheme => "opc.tcp";

	public Uri EndpointUrl => m_uri;

	public event ConnectionWaitingHandlerAsync ConnectionWaiting;

	public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		lock (m_lock)
		{
			if (m_listeningSocket != null)
			{
				Utils.SilentDispose(m_listeningSocket);
				m_listeningSocket = null;
			}
			if (m_listeningSocketIPv6 != null)
			{
				Utils.SilentDispose(m_listeningSocketIPv6);
				m_listeningSocketIPv6 = null;
			}
			if (m_channels == null)
			{
				return;
			}
			foreach (TcpListenerChannel value in m_channels.Values)
			{
				Utils.SilentDispose(value);
			}
			m_channels = null;
		}
	}

	public void Open(Uri baseAddress, TransportListenerSettings settings, ITransportListenerCallback callback)
	{
		m_listenerId = Guid.NewGuid().ToString();
		m_uri = baseAddress;
		m_descriptions = settings.Descriptions;
		EndpointConfiguration configuration = settings.Configuration;
		m_quotas = new ChannelQuotas();
		ServiceMessageContext serviceMessageContext = new ServiceMessageContext
		{
			NamespaceUris = settings.NamespaceUris,
			ServerUris = new StringTable(),
			Factory = settings.Factory
		};
		if (configuration != null)
		{
			m_quotas.MaxBufferSize = configuration.MaxBufferSize;
			m_quotas.MaxMessageSize = configuration.MaxMessageSize;
			m_quotas.ChannelLifetime = configuration.ChannelLifetime;
			m_quotas.SecurityTokenLifetime = configuration.SecurityTokenLifetime;
			serviceMessageContext.MaxArrayLength = configuration.MaxArrayLength;
			serviceMessageContext.MaxByteStringLength = configuration.MaxByteStringLength;
			serviceMessageContext.MaxMessageSize = configuration.MaxMessageSize;
			serviceMessageContext.MaxStringLength = configuration.MaxStringLength;
		}
		m_quotas.MessageContext = serviceMessageContext;
		m_quotas.CertificateValidator = settings.CertificateValidator;
		m_serverCertificate = settings.ServerCertificate;
		m_serverCertificateChain = settings.ServerCertificateChain;
		m_bufferManager = new BufferManager("Server", m_quotas.MaxBufferSize);
		m_channels = new Dictionary<uint, TcpListenerChannel>();
		m_reverseConnectListener = settings.ReverseConnectListener;
		m_callback = callback;
		Start();
	}

	public void Close()
	{
		Stop();
	}

	public bool ReconnectToExistingChannel(IMessageSocket socket, uint requestId, uint sequenceNumber, uint channelId, X509Certificate2 clientCertificate, ChannelToken token, OpenSecureChannelRequest request)
	{
		TcpListenerChannel value = null;
		lock (m_lock)
		{
			if (!m_channels.TryGetValue(channelId, out value))
			{
				throw ServiceResultException.Create(2155806720u, "Could not find secure channel referenced in the OpenSecureChannel request.");
			}
		}
		value.Reconnect(socket, requestId, sequenceNumber, clientCertificate, token, request);
		Utils.LogInfo("ChannelId {0}: reconnected", channelId);
		return true;
	}

	public void ChannelClosed(uint channelId)
	{
		lock (m_lock)
		{
			if (m_channels != null)
			{
				m_channels.Remove(channelId);
			}
		}
		Utils.LogInfo("ChannelId {0}: closed", channelId);
	}

	public void CreateReverseConnection(Uri url, int timeout)
	{
		TcpServerChannel tcpServerChannel = new TcpServerChannel(m_listenerId, this, m_bufferManager, m_quotas, m_serverCertificate, m_descriptions);
		uint nextChannelId = GetNextChannelId();
		tcpServerChannel.StatusChanged += Channel_StatusChanged;
		tcpServerChannel.BeginReverseConnect(nextChannelId, url, OnReverseHelloComplete, tcpServerChannel, Math.Min(timeout, m_quotas.ChannelLifetime));
	}

	private void Channel_StatusChanged(TcpServerChannel channel, ServiceResult status, bool closed)
	{
		this.ConnectionStatusChanged?.Invoke(this, new ConnectionStatusEventArgs(channel.ReverseConnectionUrl, status, closed));
	}

	private void OnReverseHelloComplete(IAsyncResult result)
	{
		TcpServerChannel tcpServerChannel = (TcpServerChannel)result.AsyncState;
		try
		{
			tcpServerChannel.EndReverseConnect(result);
			lock (m_lock)
			{
				m_channels.Add(tcpServerChannel.Id, tcpServerChannel);
			}
			if (m_callback != null)
			{
				tcpServerChannel.SetRequestReceivedCallback(OnRequestReceived);
				tcpServerChannel.SetReportOpenSecureChannellAuditCalback(OnReportAuditOpenSecureChannelEvent);
				tcpServerChannel.SetReportCloseSecureChannellAuditCalback(OnReportAuditCloseSecureChannelEvent);
				tcpServerChannel.SetReportCertificateAuditCalback(OnReportAuditCertificateEvent);
			}
		}
		catch (Exception exception)
		{
			this.ConnectionStatusChanged?.Invoke(this, new ConnectionStatusEventArgs(tcpServerChannel.ReverseConnectionUrl, new ServiceResult(exception), closed: true));
		}
	}

	public void Start()
	{
		lock (m_lock)
		{
			int num = m_uri.Port;
			if (num <= 0 || num > 65535)
			{
				num = 4840;
			}
			bool flag = true;
			UriHostNameType uriHostNameType = Uri.CheckHostName(m_uri.Host);
			if (uriHostNameType == UriHostNameType.Dns || uriHostNameType == UriHostNameType.Unknown || uriHostNameType == UriHostNameType.Basic)
			{
				flag = false;
			}
			IPAddress iPAddress = IPAddress.Any;
			if (flag)
			{
				iPAddress = IPAddress.Parse(m_uri.Host);
			}
			try
			{
				IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, num);
				m_listeningSocket = new Socket(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				SocketAsyncEventArgs e = new SocketAsyncEventArgs();
				e.Completed += OnAccept;
				e.UserToken = m_listeningSocket;
				m_listeningSocket.Bind(iPEndPoint);
				m_listeningSocket.Listen(int.MaxValue);
				if (!m_listeningSocket.AcceptAsync(e))
				{
					OnAccept(null, e);
				}
			}
			catch (Exception ex)
			{
				if (m_listeningSocket != null)
				{
					m_listeningSocket.Dispose();
					m_listeningSocket = null;
				}
				Utils.LogWarning("Failed to create IPv4 listening socket: {0}", ex.Message);
			}
			if (iPAddress == IPAddress.Any)
			{
				try
				{
					IPEndPoint iPEndPoint2 = new IPEndPoint(IPAddress.IPv6Any, num);
					m_listeningSocketIPv6 = new Socket(iPEndPoint2.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
					SocketAsyncEventArgs e2 = new SocketAsyncEventArgs();
					e2.Completed += OnAccept;
					e2.UserToken = m_listeningSocketIPv6;
					m_listeningSocketIPv6.Bind(iPEndPoint2);
					m_listeningSocketIPv6.Listen(int.MaxValue);
					if (!m_listeningSocketIPv6.AcceptAsync(e2))
					{
						OnAccept(null, e2);
					}
				}
				catch (Exception ex2)
				{
					if (m_listeningSocketIPv6 != null)
					{
						m_listeningSocketIPv6.Dispose();
						m_listeningSocketIPv6 = null;
					}
					Utils.LogWarning("Failed to create IPv6 listening socket: {0}", ex2.Message);
				}
			}
			if (m_listeningSocketIPv6 == null && m_listeningSocket == null)
			{
				throw ServiceResultException.Create(2150694912u, "Failed to establish tcp listener sockets for Ipv4 and IPv6.");
			}
		}
	}

	public void Stop()
	{
		lock (m_lock)
		{
			this.ConnectionWaiting = null;
			this.ConnectionStatusChanged = null;
			if (m_listeningSocket != null)
			{
				m_listeningSocket.Dispose();
				m_listeningSocket = null;
			}
			if (m_listeningSocketIPv6 != null)
			{
				m_listeningSocketIPv6.Dispose();
				m_listeningSocketIPv6 = null;
			}
		}
	}

	public async Task<bool> TransferListenerChannel(uint channelId, string serverUri, Uri endpointUrl)
	{
		bool flag = false;
		TcpListenerChannel value = null;
		lock (m_lock)
		{
			if (!m_channels.TryGetValue(channelId, out value))
			{
				throw ServiceResultException.Create(2155806720u, "Could not find secure channel request.");
			}
		}
		if (this.ConnectionWaiting != null)
		{
			TcpConnectionWaitingEventArgs args = new TcpConnectionWaitingEventArgs(serverUri, endpointUrl, value.Socket);
			await this.ConnectionWaiting(this, args).ConfigureAwait(continueOnCapturedContext: false);
			flag = args.Accepted;
		}
		if (flag)
		{
			lock (m_lock)
			{
				m_channels.Remove(channelId);
			}
		}
		return flag;
	}

	public void CertificateUpdate(ICertificateValidator validator, X509Certificate2 serverCertificate, X509Certificate2Collection serverCertificateChain)
	{
		m_quotas.CertificateValidator = validator;
		m_serverCertificate = serverCertificate;
		m_serverCertificateChain = serverCertificateChain;
		foreach (EndpointDescription description in m_descriptions)
		{
			if (m_serverCertificateChain != null && m_serverCertificateChain.Count > 1)
			{
				List<byte> list = new List<byte>();
				for (int i = 0; i < m_serverCertificateChain.Count; i++)
				{
					list.AddRange(m_serverCertificateChain[i].RawData);
				}
				description.ServerCertificate = list.ToArray();
			}
			else if (description.ServerCertificate != null)
			{
				description.ServerCertificate = serverCertificate.RawData;
			}
		}
	}

	private void OnAccept(object sender, SocketAsyncEventArgs e)
	{
		TcpListenerChannel tcpListenerChannel = null;
		bool flag = false;
		do
		{
			flag = false;
			lock (m_lock)
			{
				if (!(e.UserToken is Socket socket))
				{
					Utils.LogError("OnAccept: Listensocket was null.");
					e.Dispose();
					break;
				}
				if (e.AcceptSocket != null && e.SocketError == SocketError.Success)
				{
					try
					{
						tcpListenerChannel = ((!m_reverseConnectListener) ? ((TcpListenerChannel)new TcpServerChannel(m_listenerId, this, m_bufferManager, m_quotas, m_serverCertificate, m_serverCertificateChain, m_descriptions)) : ((TcpListenerChannel)new TcpReverseConnectChannel(m_listenerId, this, m_bufferManager, m_quotas, m_descriptions)));
						if (m_callback != null)
						{
							tcpListenerChannel.SetRequestReceivedCallback(OnRequestReceived);
							tcpListenerChannel.SetReportOpenSecureChannellAuditCalback(OnReportAuditOpenSecureChannelEvent);
							tcpListenerChannel.SetReportCloseSecureChannellAuditCalback(OnReportAuditCloseSecureChannelEvent);
							tcpListenerChannel.SetReportCertificateAuditCalback(OnReportAuditCertificateEvent);
						}
						uint nextChannelId = GetNextChannelId();
						tcpListenerChannel.Attach(nextChannelId, e.AcceptSocket);
						m_channels.Add(nextChannelId, tcpListenerChannel);
					}
					catch (Exception exception)
					{
						Utils.LogError(exception, "Unexpected error accepting a new connection.");
					}
				}
				e.Dispose();
				if (e.SocketError == SocketError.OperationAborted)
				{
					continue;
				}
				try
				{
					e = new SocketAsyncEventArgs();
					e.Completed += OnAccept;
					e.UserToken = socket;
					if (!socket.AcceptAsync(e))
					{
						flag = true;
					}
				}
				catch (Exception exception2)
				{
					Utils.LogError(exception2, "Unexpected error listening for a new connection.");
				}
			}
		}
		while (flag);
	}

	private void OnRequestReceived(TcpListenerChannel channel, uint requestId, IServiceRequest request)
	{
		try
		{
			if (m_callback != null)
			{
				m_callback.BeginProcessRequest(channel.GlobalChannelId, channel.EndpointDescription, request, OnProcessRequestComplete, new object[3] { channel, requestId, request });
			}
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "TCPLISTENER - Unexpected error processing request.");
		}
	}

	private void OnReportAuditOpenSecureChannelEvent(TcpServerChannel channel, OpenSecureChannelRequest request, X509Certificate2 clientCertificate, Exception exception)
	{
		try
		{
			if (m_callback != null)
			{
				m_callback.ReportAuditOpenSecureChannelEvent(channel.GlobalChannelId, channel.EndpointDescription, request, clientCertificate, exception);
			}
		}
		catch (Exception exception2)
		{
			Utils.LogError(exception2, "TCPLISTENER - Unexpected error sending OpenSecureChannel Audit event.");
		}
	}

	private void OnReportAuditCloseSecureChannelEvent(TcpServerChannel channel, Exception exception)
	{
		try
		{
			if (m_callback != null)
			{
				m_callback.ReportAuditCloseSecureChannelEvent(channel.GlobalChannelId, exception);
			}
		}
		catch (Exception exception2)
		{
			Utils.LogError(exception2, "TCPLISTENER - Unexpected error sending CloseSecureChannel Audit event.");
		}
	}

	private void OnReportAuditCertificateEvent(X509Certificate2 clientCertificate, Exception exception)
	{
		try
		{
			if (m_callback != null)
			{
				m_callback.ReportAuditCertificateEvent(clientCertificate, exception);
			}
		}
		catch (Exception exception2)
		{
			Utils.LogError(exception2, "TCPLISTENER - Unexpected error sending Certificate Audit event.");
		}
	}

	private void OnProcessRequestComplete(IAsyncResult result)
	{
		try
		{
			object[] array = (object[])result.AsyncState;
			if (m_callback != null)
			{
				((TcpServerChannel)array[0]).SendResponse(response: m_callback.EndProcessRequest(result), requestId: (uint)array[1]);
			}
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "TCPLISTENER - Unexpected error sending result.");
		}
	}

	private uint GetNextChannelId()
	{
		lock (m_lock)
		{
			uint num;
			do
			{
				num = ++m_lastChannelId;
			}
			while (m_channels.ContainsKey(num));
			return num;
		}
	}

	private void SetUri(Uri baseAddress, string relativeAddress)
	{
		if (baseAddress == null)
		{
			throw new ArgumentNullException("baseAddress");
		}
		if (!baseAddress.IsAbsoluteUri)
		{
			throw new ArgumentException("Base address must be an absolute URI.", "baseAddress");
		}
		if (!string.Equals(baseAddress.Scheme, "opc.tcp", StringComparison.OrdinalIgnoreCase))
		{
			throw new ArgumentException("Invalid URI scheme: " + baseAddress.Scheme + ".", "baseAddress");
		}
		m_uri = baseAddress;
		if (!string.IsNullOrEmpty(relativeAddress))
		{
			if (!baseAddress.AbsolutePath.EndsWith("/", StringComparison.Ordinal))
			{
				UriBuilder uriBuilder = new UriBuilder(baseAddress);
				uriBuilder.Path += "/";
				baseAddress = uriBuilder.Uri;
			}
			m_uri = new Uri(baseAddress, relativeAddress);
		}
	}
}
