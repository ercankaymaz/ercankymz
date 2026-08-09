using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class UaSCUaBinaryTransportChannel : ITransportChannel, IDisposable, IMessageSocketChannel
{
	private const int kChannelCloseDefault = 1000;

	private readonly object m_lock = new object();

	private Uri m_url;

	private int m_operationTimeout;

	private TransportChannelSettings m_settings;

	private ChannelQuotas m_quotas;

	private BufferManager m_bufferManager;

	private UaSCUaBinaryClientChannel m_channel;

	private IMessageSocketFactory m_messageSocketFactory;

	public IMessageSocket Socket
	{
		get
		{
			lock (m_lock)
			{
				return m_channel?.Socket;
			}
		}
	}

	public TransportChannelFeatures SupportedFeatures => TransportChannelFeatures.Open | TransportChannelFeatures.BeginOpen | TransportChannelFeatures.BeginSendRequest | TransportChannelFeatures.SendRequestAsync | ((Socket != null) ? Socket.MessageSocketFeatures : TransportChannelFeatures.None);

	public EndpointDescription EndpointDescription => m_settings.Description;

	public EndpointConfiguration EndpointConfiguration => m_settings.Configuration;

	public IServiceMessageContext MessageContext => m_quotas.MessageContext;

	public ChannelToken CurrentToken
	{
		get
		{
			lock (m_lock)
			{
				return m_channel?.CurrentToken;
			}
		}
	}

	public int OperationTimeout
	{
		get
		{
			return m_operationTimeout;
		}
		set
		{
			m_operationTimeout = value;
		}
	}

	public UaSCUaBinaryTransportChannel(IMessageSocketFactory messageSocketFactory)
	{
		m_messageSocketFactory = messageSocketFactory;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			Utils.SilentDispose(m_channel);
			m_channel = null;
		}
	}

	public void Initialize(Uri url, TransportChannelSettings settings)
	{
		SaveSettings(url, settings);
		CreateChannel();
	}

	public void Initialize(ITransportWaitingConnection connection, TransportChannelSettings settings)
	{
		SaveSettings(connection.EndpointUrl, settings);
		CreateChannel(connection);
	}

	public void Open()
	{
	}

	public IAsyncResult BeginOpen(AsyncCallback callback, object callbackData)
	{
		lock (m_lock)
		{
			CreateChannel();
			return m_channel.BeginConnect(m_url, m_operationTimeout, callback, callbackData);
		}
	}

	public void EndOpen(IAsyncResult result)
	{
		m_channel.EndConnect(result);
	}

	public void Reconnect()
	{
		Reconnect(null);
	}

	public void Reconnect(ITransportWaitingConnection connection)
	{
		Utils.LogInfo("TransportChannel RECONNECT: Reconnecting to {0}.", m_url);
		lock (m_lock)
		{
			UaSCUaBinaryClientChannel channel = m_channel;
			m_channel = null;
			try
			{
				CreateChannel(connection);
				IAsyncResult result = m_channel.BeginConnect(m_url, m_operationTimeout, null, null);
				m_channel.EndConnect(result);
			}
			finally
			{
				if (channel != null)
				{
					try
					{
						channel.Close(1000);
					}
					catch (Exception exception)
					{
						Utils.LogTrace(exception, "Ignoring exception while closing transport channel during Reconnect.");
					}
					finally
					{
						channel.Dispose();
					}
				}
			}
		}
	}

	public IAsyncResult BeginReconnect(AsyncCallback callback, object callbackData)
	{
		throw new NotImplementedException();
	}

	public void EndReconnect(IAsyncResult result)
	{
		throw new NotImplementedException();
	}

	public void Close()
	{
		if (m_channel == null)
		{
			return;
		}
		lock (m_lock)
		{
			if (m_channel != null)
			{
				m_channel.Close(1000);
				m_channel = null;
			}
		}
	}

	public async Task CloseAsync(CancellationToken ct)
	{
		UaSCUaBinaryClientChannel uaSCUaBinaryClientChannel = null;
		lock (m_lock)
		{
			if (m_channel != null)
			{
				uaSCUaBinaryClientChannel = m_channel;
				m_channel = null;
			}
		}
		if (uaSCUaBinaryClientChannel != null)
		{
			await uaSCUaBinaryClientChannel.CloseAsync(1000, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public IAsyncResult BeginClose(AsyncCallback callback, object callbackData)
	{
		throw new NotImplementedException();
	}

	public void EndClose(IAsyncResult result)
	{
		throw new NotImplementedException();
	}

	public IServiceResponse SendRequest(IServiceRequest request)
	{
		IAsyncResult result = BeginSendRequest(request, null, null);
		return EndSendRequest(result);
	}

	public Task<IServiceResponse> SendRequestAsync(IServiceRequest request, CancellationToken ct)
	{
		IAsyncResult result = BeginSendRequest(request, null, null);
		return EndSendRequestAsync(result, ct);
	}

	public IAsyncResult BeginSendRequest(IServiceRequest request, AsyncCallback callback, object callbackData)
	{
		UaSCUaBinaryClientChannel channel = m_channel;
		if (channel == null)
		{
			lock (m_lock)
			{
				if (m_channel == null)
				{
					CreateChannel();
				}
				channel = m_channel;
			}
		}
		return channel.BeginSendRequest(request, m_operationTimeout, callback, callbackData);
	}

	public IServiceResponse EndSendRequest(IAsyncResult result)
	{
		return (m_channel ?? throw ServiceResultException.Create(2156265472u, "Channel has been closed.")).EndSendRequest(result);
	}

	public Task<IServiceResponse> EndSendRequestAsync(IAsyncResult result, CancellationToken ct)
	{
		return (m_channel ?? throw ServiceResultException.Create(2156265472u, "Channel has been closed.")).EndSendRequestAsync(result, ct);
	}

	private void SaveSettings(Uri url, TransportChannelSettings settings)
	{
		m_url = url;
		m_settings = settings;
		m_operationTimeout = settings.Configuration.OperationTimeout;
		m_quotas = new ChannelQuotas();
		m_quotas.MaxBufferSize = m_settings.Configuration.MaxBufferSize;
		m_quotas.MaxMessageSize = m_settings.Configuration.MaxMessageSize;
		m_quotas.ChannelLifetime = m_settings.Configuration.ChannelLifetime;
		m_quotas.SecurityTokenLifetime = m_settings.Configuration.SecurityTokenLifetime;
		m_quotas.MessageContext = new ServiceMessageContext
		{
			MaxArrayLength = m_settings.Configuration.MaxArrayLength,
			MaxByteStringLength = m_settings.Configuration.MaxByteStringLength,
			MaxMessageSize = m_settings.Configuration.MaxMessageSize,
			MaxStringLength = m_settings.Configuration.MaxStringLength,
			NamespaceUris = m_settings.NamespaceUris,
			ServerUris = new StringTable(),
			Factory = m_settings.Factory
		};
		m_quotas.CertificateValidator = settings.CertificateValidator;
		m_bufferManager = new BufferManager("Client", settings.Configuration.MaxBufferSize);
	}

	private void CreateChannel(ITransportWaitingConnection connection = null)
	{
		IMessageSocket messageSocket = null;
		if (connection != null)
		{
			messageSocket = connection.Handle as IMessageSocket;
			if (messageSocket == null)
			{
				throw new ArgumentException("Connection Handle is not of type IMessageSocket.");
			}
		}
		m_channel = new UaSCUaBinaryClientChannel(Guid.NewGuid().ToString(), m_bufferManager, m_messageSocketFactory, m_quotas, m_settings.ClientCertificate, m_settings.ClientCertificateChain, m_settings.ServerCertificate, m_settings.Description);
		if (messageSocket != null)
		{
			m_channel.Socket = messageSocket;
			m_channel.Socket.ChangeSink(m_channel);
			m_channel.ReverseSocket = true;
		}
	}
}
