using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Opc.Ua.Bindings;

namespace Opc.Ua;

[ComVisible(true)]
public abstract class UaChannelBase : IChannelBase, ITransportChannel, IDisposable
{
	internal TransportChannelSettings m_settings;

	internal IServiceMessageContext m_messageContext;

	internal ITransportChannel m_uaBypassChannel;

	internal int m_operationTimeout;

	internal IChannelBase m_channel;

	internal string g_ImplementationString = "Opc.Ua.ChannelBase UA Client " + Utils.GetAssemblySoftwareVersion();

	public bool UseBinaryEncoding
	{
		get
		{
			if (m_settings != null && m_settings.Configuration != null)
			{
				return m_settings.Configuration.UseBinaryEncoding;
			}
			return false;
		}
	}

	public BinaryEncodingSupport BinaryEncodingSupport
	{
		get
		{
			if (m_settings != null && m_settings.Configuration != null)
			{
				if (m_settings != null && m_settings.Configuration.UseBinaryEncoding)
				{
					return BinaryEncodingSupport.Required;
				}
				return BinaryEncodingSupport.None;
			}
			return BinaryEncodingSupport.Optional;
		}
	}

	public TransportChannelFeatures SupportedFeatures
	{
		get
		{
			if (m_uaBypassChannel != null)
			{
				return m_uaBypassChannel.SupportedFeatures;
			}
			return TransportChannelFeatures.Reconnect | TransportChannelFeatures.BeginClose | TransportChannelFeatures.BeginSendRequest | TransportChannelFeatures.SendRequestAsync;
		}
	}

	public EndpointDescription EndpointDescription
	{
		get
		{
			if (m_uaBypassChannel != null)
			{
				return m_uaBypassChannel.EndpointDescription;
			}
			if (m_settings != null)
			{
				return m_settings.Description;
			}
			return null;
		}
	}

	public EndpointConfiguration EndpointConfiguration
	{
		get
		{
			if (m_uaBypassChannel != null)
			{
				return m_uaBypassChannel.EndpointConfiguration;
			}
			if (m_settings != null)
			{
				return m_settings.Configuration;
			}
			return null;
		}
	}

	public IServiceMessageContext MessageContext
	{
		get
		{
			if (m_uaBypassChannel != null)
			{
				return m_uaBypassChannel.MessageContext;
			}
			return m_messageContext;
		}
	}

	public ChannelToken CurrentToken => null;

	public int OperationTimeout
	{
		get
		{
			if (m_uaBypassChannel != null)
			{
				return m_uaBypassChannel.OperationTimeout;
			}
			return m_operationTimeout;
		}
		set
		{
			if (m_uaBypassChannel != null)
			{
				m_uaBypassChannel.OperationTimeout = value;
			}
			else
			{
				m_operationTimeout = value;
			}
		}
	}

	public UaChannelBase()
	{
		m_messageContext = null;
		m_settings = null;
		m_uaBypassChannel = null;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public void OpenChannel()
	{
		throw new NotImplementedException("UaBaseChannel does not implement OpenChannel()");
	}

	public void CloseChannel()
	{
		throw new NotImplementedException("UaBaseChannel does not implement CloseChannel()");
	}

	public void ScheduleOutgoingRequest(IChannelOutgoingRequest request)
	{
		throw new NotImplementedException("UaBaseChannel does not implement ScheduleOutgoingRequest()");
	}

	public void Initialize(Uri url, TransportChannelSettings settings)
	{
		if (m_uaBypassChannel != null)
		{
			m_uaBypassChannel.Initialize(url, settings);
			return;
		}
		throw new NotSupportedException("WCF channels must be configured when they are constructed.");
	}

	public void Initialize(ITransportWaitingConnection connection, TransportChannelSettings settings)
	{
		throw new NotSupportedException("WCF channels must be configured when they are constructed.");
	}

	public void Open()
	{
		if (m_uaBypassChannel != null)
		{
			m_uaBypassChannel.Open();
		}
	}

	public IAsyncResult BeginOpen(AsyncCallback callback, object callbackData)
	{
		if (m_uaBypassChannel != null)
		{
			return m_uaBypassChannel.BeginOpen(callback, callbackData);
		}
		throw new NotSupportedException("WCF channels must be configured when they are constructed.");
	}

	public void EndOpen(IAsyncResult result)
	{
		if (m_uaBypassChannel != null)
		{
			m_uaBypassChannel.EndOpen(result);
			return;
		}
		throw new NotSupportedException("WCF channels must be configured when they are constructed.");
	}

	public abstract void Reconnect();

	public abstract void Reconnect(ITransportWaitingConnection connection);

	public IAsyncResult BeginReconnect(AsyncCallback callback, object callbackData)
	{
		if (m_uaBypassChannel != null)
		{
			return m_uaBypassChannel.BeginReconnect(callback, callbackData);
		}
		throw new NotSupportedException("WCF channels cannot be reconnected.");
	}

	public void EndReconnect(IAsyncResult result)
	{
		if (m_uaBypassChannel != null)
		{
			m_uaBypassChannel.EndReconnect(result);
			return;
		}
		throw new NotSupportedException("WCF channels cannot be reconnected.");
	}

	public void Close()
	{
		if (m_uaBypassChannel != null)
		{
			m_uaBypassChannel.Close();
		}
		else
		{
			CloseChannel();
		}
	}

	public async Task CloseAsync(CancellationToken ct)
	{
		if (m_uaBypassChannel != null)
		{
			await m_uaBypassChannel.CloseAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		else
		{
			CloseChannel();
		}
	}

	public IAsyncResult BeginClose(AsyncCallback callback, object callbackData)
	{
		if (m_uaBypassChannel != null)
		{
			return m_uaBypassChannel.BeginClose(callback, callbackData);
		}
		AsyncResultBase asyncResultBase = new AsyncResultBase(callback, callbackData, 0);
		asyncResultBase.OperationCompleted();
		return asyncResultBase;
	}

	public void EndClose(IAsyncResult result)
	{
		if (m_uaBypassChannel != null)
		{
			m_uaBypassChannel.EndClose(result);
			return;
		}
		AsyncResultBase.WaitForComplete(result);
		CloseChannel();
	}

	public IServiceResponse SendRequest(IServiceRequest request)
	{
		if (m_uaBypassChannel != null)
		{
			return m_uaBypassChannel.SendRequest(request);
		}
		byte[] invokeServiceRequest = BinaryEncoder.EncodeMessage(request, m_messageContext);
		return (IServiceResponse)BinaryDecoder.DecodeMessage(InvokeService(new InvokeServiceMessage(invokeServiceRequest)).InvokeServiceResponse, null, m_messageContext);
	}

	public IAsyncResult BeginSendRequest(IServiceRequest request, AsyncCallback callback, object callbackData)
	{
		if (m_uaBypassChannel != null)
		{
			return m_uaBypassChannel.BeginSendRequest(request, callback, callbackData);
		}
		byte[] invokeServiceRequest = BinaryEncoder.EncodeMessage(request, m_messageContext);
		return BeginInvokeService(new InvokeServiceMessage(invokeServiceRequest), callback, callbackData);
	}

	public IServiceResponse EndSendRequest(IAsyncResult result)
	{
		if (m_uaBypassChannel != null)
		{
			return m_uaBypassChannel.EndSendRequest(result);
		}
		return (IServiceResponse)BinaryDecoder.DecodeMessage(EndInvokeService(result).InvokeServiceResponse, null, m_messageContext);
	}

	public Task<IServiceResponse> EndSendRequestAsync(IAsyncResult result, CancellationToken ct)
	{
		if (m_uaBypassChannel != null)
		{
			return m_uaBypassChannel.EndSendRequestAsync(result, ct);
		}
		throw new NotImplementedException();
	}

	public Task<IServiceResponse> SendRequestAsync(IServiceRequest request, CancellationToken ct)
	{
		return Task.Factory.FromAsync((Func<IServiceRequest, AsyncCallback, object, IAsyncResult>)BeginSendRequest, (Func<IAsyncResult, IServiceResponse>)EndSendRequest, request, (object)null);
	}

	public abstract InvokeServiceResponseMessage InvokeService(InvokeServiceMessage request);

	public abstract IAsyncResult BeginInvokeService(InvokeServiceMessage request, AsyncCallback callback, object asyncState);

	public abstract InvokeServiceResponseMessage EndInvokeService(IAsyncResult result);

	public static ITransportChannel CreateUaBinaryChannel(ApplicationConfiguration configuration, ITransportWaitingConnection connection, EndpointDescription description, EndpointConfiguration endpointConfiguration, X509Certificate2 clientCertificate, X509Certificate2Collection clientCertificateChain, IServiceMessageContext messageContext)
	{
		string scheme = new Uri(description.EndpointUrl).Scheme;
		ITransportChannel channel = TransportBindings.Channels.GetChannel(scheme);
		if (channel == null)
		{
			throw ServiceResultException.Create(2159935488u, "Unsupported transport profile for scheme {0}.", scheme);
		}
		TransportChannelSettings transportChannelSettings = new TransportChannelSettings
		{
			Description = description,
			Configuration = endpointConfiguration,
			ClientCertificate = clientCertificate,
			ClientCertificateChain = clientCertificateChain
		};
		if (description.ServerCertificate != null && description.ServerCertificate.Length != 0)
		{
			transportChannelSettings.ServerCertificate = Utils.ParseCertificateBlob(description.ServerCertificate);
		}
		if (configuration != null)
		{
			transportChannelSettings.CertificateValidator = configuration.CertificateValidator.GetChannelValidator();
		}
		transportChannelSettings.NamespaceUris = messageContext.NamespaceUris;
		transportChannelSettings.Factory = messageContext.Factory;
		channel.Initialize(connection, transportChannelSettings);
		channel.Open();
		return channel;
	}

	public static ITransportChannel CreateUaBinaryChannel(ApplicationConfiguration configuration, EndpointDescription description, EndpointConfiguration endpointConfiguration, X509Certificate2 clientCertificate, IServiceMessageContext messageContext)
	{
		return CreateUaBinaryChannel(configuration, description, endpointConfiguration, clientCertificate, null, messageContext);
	}

	public static ITransportChannel CreateUaBinaryChannel(ApplicationConfiguration configuration, EndpointDescription description, EndpointConfiguration endpointConfiguration, X509Certificate2 clientCertificate, X509Certificate2Collection clientCertificateChain, IServiceMessageContext messageContext)
	{
		string text = new Uri(description.EndpointUrl).Scheme;
		switch (description.TransportProfileUri)
		{
		case "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary":
			text = "opc.tcp";
			break;
		case "http://opcfoundation.org/UA-Profile/Transport/https-uabinary":
			text = "opc.https";
			break;
		case "http://opcfoundation.org/UA-Profile/Transport/uawss-uasc-uabinary":
			text = "opc.wss";
			break;
		}
		ITransportChannel channel = TransportBindings.Channels.GetChannel(text);
		if (channel == null)
		{
			throw ServiceResultException.Create(2159935488u, "Unsupported transport profile for scheme {0}.", text);
		}
		TransportChannelSettings transportChannelSettings = new TransportChannelSettings
		{
			Description = description,
			Configuration = endpointConfiguration,
			ClientCertificate = clientCertificate,
			ClientCertificateChain = clientCertificateChain
		};
		if (description.ServerCertificate != null && description.ServerCertificate.Length != 0)
		{
			transportChannelSettings.ServerCertificate = Utils.ParseCertificateBlob(description.ServerCertificate);
		}
		if (configuration != null)
		{
			transportChannelSettings.CertificateValidator = configuration.CertificateValidator.GetChannelValidator();
		}
		transportChannelSettings.NamespaceUris = messageContext.NamespaceUris;
		transportChannelSettings.Factory = messageContext.Factory;
		channel.Initialize(new Uri(description.EndpointUrl), transportChannelSettings);
		channel.Open();
		return channel;
	}
}
[ComVisible(true)]
public class UaChannelBase<TChannel> : UaChannelBase where TChannel : class, IChannelBase
{
	protected class UaChannelAsyncResult : AsyncResultBase
	{
		private TChannel m_channel;

		public TChannel Channel => m_channel;

		public UaChannelAsyncResult(TChannel channel, AsyncCallback callback, object callbackData)
			: base(callback, callbackData, 0)
		{
			m_channel = channel;
		}

		public void OnOperationCompleted(IAsyncResult ar)
		{
			try
			{
				lock (base.Lock)
				{
					if (base.InnerResult == null)
					{
						base.InnerResult = ar;
					}
				}
				OperationCompleted();
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Unexpected exception invoking UaChannelAsyncResult callback function.");
			}
		}

		public new static UaChannelAsyncResult WaitForComplete(IAsyncResult ar)
		{
			UaChannelAsyncResult obj = (ar as UaChannelAsyncResult) ?? throw new ArgumentException("End called with an invalid IAsyncResult object.", "ar");
			if (!obj.WaitForComplete())
			{
				throw new ServiceResultException(2148139008u);
			}
			return obj;
		}
	}

	private new TChannel m_channel;

	protected TChannel Channel => m_channel;

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Utils.SilentDispose(m_channel);
			m_channel = null;
		}
		base.Dispose(disposing);
	}

	public override InvokeServiceResponseMessage InvokeService(InvokeServiceMessage request)
	{
		IAsyncResult result = null;
		lock (Channel)
		{
			result = Channel.BeginInvokeService(request, null, null);
		}
		return Channel.EndInvokeService(result);
	}

	public override IAsyncResult BeginInvokeService(InvokeServiceMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(m_channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginInvokeService(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public override InvokeServiceResponseMessage EndInvokeService(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndInvokeService(uaChannelAsyncResult.InnerResult);
	}

	public override void Reconnect()
	{
		if (m_uaBypassChannel != null)
		{
			m_uaBypassChannel.Reconnect();
			return;
		}
		Utils.LogInfo("RECONNECT: Reconnecting to {0}.", m_settings.Description.EndpointUrl);
	}

	public override void Reconnect(ITransportWaitingConnection connection)
	{
		throw new NotImplementedException("Reconnect for waiting connections is not supported for this channel");
	}
}
