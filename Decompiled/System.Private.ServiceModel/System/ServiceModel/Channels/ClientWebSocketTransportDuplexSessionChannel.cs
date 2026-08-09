using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.WebSockets;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class ClientWebSocketTransportDuplexSessionChannel : WebSocketTransportDuplexSessionChannel
{
	private readonly ClientWebSocketFactory _connectionFactory;

	private HttpChannelFactory<IDuplexSessionChannel> _channelFactory;

	private SecurityTokenProviderContainer _webRequestTokenProvider;

	private SecurityTokenProviderContainer _webRequestProxyTokenProvider;

	private volatile bool _cleanupStarted;

	protected override bool IsStreamedOutput => TransferModeHelper.IsRequestStreamed(base.TransferMode);

	public ClientWebSocketTransportDuplexSessionChannel(HttpChannelFactory<IDuplexSessionChannel> channelFactory, ClientWebSocketFactory connectionFactory, EndpointAddress remoteAddress, Uri via)
		: base(channelFactory, remoteAddress, via)
	{
		_channelFactory = channelFactory;
		_connectionFactory = connectionFactory;
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CommunicationObjectInternal.OnBeginOpen(this, timeout, callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		CommunicationObjectInternal.OnEnd(result);
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		CommunicationObjectInternal.OnOpen(this, timeout);
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		bool success = false;
		try
		{
			if (WcfEventSource.Instance.WebSocketConnectionRequestSendStartIsEnabled())
			{
				WcfEventSource.Instance.WebSocketConnectionRequestSendStart(base.EventTraceActivity, (RemoteAddress != null) ? RemoteAddress.ToString() : string.Empty);
			}
			ChannelParameterCollection channelParameters = new ChannelParameterCollection();
			X509Certificate2 certificate = null;
			if (_channelFactory is HttpsChannelFactory<IDuplexSessionChannel> { RequireClientCertificate: not false } httpsChannelFactory)
			{
				SecurityTokenProvider certificateProvider = httpsChannelFactory.CreateAndOpenCertificateTokenProvider(RemoteAddress, Via, channelParameters, timeoutHelper.RemainingTime());
				SecurityTokenContainer certificateSecurityToken = httpsChannelFactory.GetCertificateSecurityToken(certificateProvider, RemoteAddress, Via, channelParameters, ref timeoutHelper);
				X509SecurityToken x509SecurityToken = (X509SecurityToken)certificateSecurityToken.Token;
				certificate = x509SecurityToken.Certificate;
			}
			try
			{
				base.WebSocket = await CreateWebSocketWithFactoryAsync(certificate, timeoutHelper);
			}
			finally
			{
				if (base.WebSocket != null && _cleanupStarted)
				{
					base.WebSocket.Abort();
					CommunicationObjectAbortedException ex = new CommunicationObjectAbortedException(new WebSocketException(WebSocketError.ConnectionClosedPrematurely).Message);
					FxTrace.Exception.AsWarning(ex);
					throw ex;
				}
			}
			bool useStreaming = TransferModeHelper.IsResponseStreamed(base.TransferMode);
			SetMessageSource(new WebSocketMessageSource(this, base.WebSocket, useStreaming, this));
			success = true;
			if (WcfEventSource.Instance.WebSocketConnectionRequestSendStopIsEnabled())
			{
				WcfEventSource.Instance.WebSocketConnectionRequestSendStop(base.EventTraceActivity, (base.WebSocket != null) ? base.WebSocket.GetHashCode() : (-1));
			}
		}
		catch (WebSocketException ex2)
		{
			if (WcfEventSource.Instance.WebSocketConnectionFailedIsEnabled())
			{
				WcfEventSource.Instance.WebSocketConnectionFailed(base.EventTraceActivity, ex2.Message);
			}
			TryConvertAndThrow(ex2);
		}
		finally
		{
			CleanupTokenProviders();
			if (!success)
			{
				CleanupOnError();
			}
		}
	}

	protected override void OnCleanup()
	{
		_cleanupStarted = true;
		base.OnCleanup();
	}

	private static void TryConvertAndThrow(WebSocketException ex)
	{
		switch (ex.WebSocketErrorCode)
		{
		case WebSocketError.UnsupportedVersion:
			throw FxTrace.Exception.AsError(new CommunicationException(System.SR.Format(System.SR.WebSocketVersionMismatchFromServer, ""), ex));
		case WebSocketError.UnsupportedProtocol:
			throw FxTrace.Exception.AsError(new CommunicationException(System.SR.Format(System.SR.WebSocketSubProtocolMismatchFromServer, ""), ex));
		default:
			throw FxTrace.Exception.AsError(new CommunicationException(ex.Message, ex));
		}
	}

	private void CleanupOnError()
	{
		Cleanup();
	}

	private void CleanupTokenProviders()
	{
		if (_webRequestTokenProvider != null)
		{
			_webRequestTokenProvider.Abort();
			_webRequestTokenProvider = null;
		}
		if (_webRequestProxyTokenProvider != null)
		{
			_webRequestProxyTokenProvider.Abort();
			_webRequestProxyTokenProvider = null;
		}
	}

	private async Task<WebSocket> CreateWebSocketWithFactoryAsync(X509Certificate2 certificate, TimeoutHelper timeoutHelper)
	{
		if (WcfEventSource.Instance.WebSocketCreateClientWebSocketWithFactoryIsEnabled())
		{
			WcfEventSource.Instance.WebSocketCreateClientWebSocketWithFactory(base.EventTraceActivity, _connectionFactory.GetType().FullName);
		}
		WebSocket webSocket;
		try
		{
			if (certificate != null)
			{
				throw ExceptionHelper.PlatformNotSupported("client certificates not supported yet");
			}
			WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
			webHeaderCollection["soap-content-type"] = _channelFactory.WebSocketSoapContentType;
			if (_channelFactory.MessageEncoderFactory is BinaryMessageEncoderFactory)
			{
				webHeaderCollection["microsoft-binary-transfer-mode"] = _channelFactory.TransferMode.ToString();
			}
			if (HttpChannelFactory<IDuplexSessionChannel>.MapIdentity(RemoteAddress, _channelFactory.AuthenticationScheme))
			{
				webHeaderCollection[HttpRequestHeader.Host] = HttpTransportSecurityHelpers.GeIdentityHostHeader(RemoteAddress);
			}
			ICredentials credentials = _channelFactory.GetCredentials();
			webSocket = await _connectionFactory.CreateWebSocketAsync(Via, webHeaderCollection, credentials, base.WebSocketSettings.Clone(), timeoutHelper);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.ClientWebSocketFactory_CreateWebSocketFailed, _connectionFactory.GetType().Name), ex));
		}
		if (webSocket == null)
		{
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.ClientWebSocketFactory_InvalidWebSocket, _connectionFactory.GetType().Name)));
		}
		if (webSocket.State != WebSocketState.Open)
		{
			webSocket.Dispose();
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.ClientWebSocketFactory_InvalidWebSocket, _connectionFactory.GetType().Name)));
		}
		string subProtocol = base.WebSocketSettings.SubProtocol;
		string subProtocol2 = webSocket.SubProtocol;
		if (!(subProtocol?.Equals(subProtocol2, StringComparison.OrdinalIgnoreCase) ?? string.IsNullOrWhiteSpace(subProtocol2)))
		{
			webSocket.Dispose();
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.ClientWebSocketFactory_InvalidSubProtocol, _connectionFactory.GetType().Name, subProtocol2, subProtocol)));
		}
		return webSocket;
	}
}
