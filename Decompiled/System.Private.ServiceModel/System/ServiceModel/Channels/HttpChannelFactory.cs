using System.Globalization;
using System.IdentityModel.Selectors;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class HttpChannelFactory<TChannel> : TransportChannelFactory<TChannel>, IHttpTransportFactorySettings, ITransportFactorySettings, IDefaultCommunicationTimeouts
{
	protected class HttpClientRequestChannel : RequestChannel
	{
		internal class HttpClientChannelAsyncRequest : IAsyncRequest, IRequestBase
		{
			private static readonly Action<object> s_cancelCts = delegate(object state)
			{
				try
				{
					((CancellationTokenSource)state).Cancel();
				}
				catch (ObjectDisposedException)
				{
				}
			};

			private HttpClientRequestChannel _channel;

			private HttpChannelFactory<IRequestChannel> _factory;

			private EndpointAddress _to;

			private Uri _via;

			private HttpRequestMessage _httpRequestMessage;

			private HttpResponseMessage _httpResponseMessage;

			private HttpAbortReason _abortReason;

			private TimeoutHelper _timeoutHelper;

			private int _httpRequestCompleted;

			private HttpClient _httpClient;

			private readonly CancellationTokenSource _httpSendCts;

			public HttpClientChannelAsyncRequest(HttpClientRequestChannel channel)
			{
				_channel = channel;
				_to = channel.RemoteAddress;
				_via = channel.Via;
				_factory = channel.Factory;
				_httpSendCts = new CancellationTokenSource();
			}

			public async Task SendRequestAsync(Message message, TimeoutHelper timeoutHelper)
			{
				_timeoutHelper = timeoutHelper;
				if (_channel.Factory.MapIdentity(_to))
				{
					HttpTransportSecurityHelpers.AddIdentityMapping(_to, message);
				}
				_factory.ApplyManualAddressing(ref _to, ref _via, message);
				_httpClient = await _channel.GetHttpClientAsync(_to, _via, _timeoutHelper);
				HttpRequestMessage httpRequestMessage = (_httpRequestMessage = _channel.GetHttpRequestMessage(_via));
				try
				{
					if (_channel.State != CommunicationState.Opened)
					{
						Cleanup();
						_channel.ThrowIfDisposedOrNotOpen();
					}
					if (!PrepareMessageHeaders(message))
					{
						httpRequestMessage.Content = MessageContent.Create(_factory, message, _timeoutHelper);
					}
					if (Fx.IsUap)
					{
						try
						{
							await SendPreauthenticationHeadRequestIfNeeded();
						}
						catch
						{
						}
					}
					bool success = false;
					CancellationToken timeoutToken = await _timeoutHelper.GetCancellationTokenAsync();
					try
					{
						using (timeoutToken.Register(s_cancelCts, _httpSendCts))
						{
							_httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead, _httpSendCts.Token);
						}
						httpRequestMessage.Dispose();
						success = true;
					}
					catch (HttpRequestException requestException)
					{
						HttpChannelUtilities.ProcessGetResponseWebException(requestException, httpRequestMessage, _abortReason);
					}
					catch (OperationCanceledException)
					{
						if (timeoutToken.IsCancellationRequested)
						{
							throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.HttpRequestTimedOut, httpRequestMessage.RequestUri, _timeoutHelper.OriginalTimeout)));
						}
						throw;
					}
					finally
					{
						if (!success)
						{
							Abort(_channel);
						}
					}
				}
				finally
				{
					if (message != message)
					{
						message.Close();
					}
				}
			}

			private void Cleanup()
			{
				s_cancelCts(_httpSendCts);
				if (_httpRequestMessage != null)
				{
					HttpRequestMessage httpRequestMessage = _httpRequestMessage;
					_httpRequestMessage = null;
					TryCompleteHttpRequest(httpRequestMessage);
					httpRequestMessage.Dispose();
				}
			}

			public void Abort(RequestChannel channel)
			{
				Cleanup();
				_abortReason = HttpAbortReason.Aborted;
			}

			public void Fault(RequestChannel channel)
			{
				Cleanup();
			}

			public async Task<Message> ReceiveReplyAsync(TimeoutHelper timeoutHelper)
			{
				try
				{
					_timeoutHelper = timeoutHelper;
					HttpResponseMessageHelper httpResponseMessageHelper = new HttpResponseMessageHelper(_httpResponseMessage, _factory);
					Message result = await httpResponseMessageHelper.ParseIncomingResponse(timeoutHelper);
					TryCompleteHttpRequest(_httpRequestMessage);
					return result;
				}
				catch (OperationCanceledException)
				{
					if (_timeoutHelper.GetCancellationToken().IsCancellationRequested)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.HttpResponseTimedOut, _httpRequestMessage.RequestUri, timeoutHelper.OriginalTimeout)));
					}
					throw;
				}
			}

			private bool PrepareMessageHeaders(Message message)
			{
				string text = message.Headers.Action;
				if (text != null)
				{
					text = string.Format(CultureInfo.InvariantCulture, "\"{0}\"", UrlUtility.UrlPathEncode(text));
				}
				bool flag = message is NullMessage;
				if (message.Properties.TryGetValue(HttpRequestMessageProperty.Name, out var value))
				{
					HttpRequestMessageProperty httpRequestMessageProperty = (HttpRequestMessageProperty)value;
					_httpRequestMessage.Method = new HttpMethod(httpRequestMessageProperty.Method);
					WebHeaderCollection headers = httpRequestMessageProperty.Headers;
					flag = flag || httpRequestMessageProperty.SuppressEntityBody;
					string[] allKeys = headers.AllKeys;
					foreach (string text2 in allKeys)
					{
						string text3 = headers[text2];
						if (string.Compare(text2, "accept", StringComparison.OrdinalIgnoreCase) == 0)
						{
							_httpRequestMessage.Headers.Accept.TryParseAdd(text3);
						}
						else if (string.Compare(text2, "connection", StringComparison.OrdinalIgnoreCase) == 0)
						{
							if (text3.IndexOf("keep-alive", StringComparison.OrdinalIgnoreCase) != -1)
							{
								_httpRequestMessage.Headers.ConnectionClose = false;
							}
							else
							{
								_httpRequestMessage.Headers.Connection.TryParseAdd(text3);
							}
						}
						else if (string.Compare(text2, "SOAPAction", StringComparison.OrdinalIgnoreCase) == 0)
						{
							if (text == null)
							{
								text = text3;
							}
							else if (!string.IsNullOrEmpty(text3) && string.Compare(text3, text, StringComparison.Ordinal) != 0)
							{
								throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.HttpSoapActionMismatch, text, text3)));
							}
						}
						else
						{
							if (string.Compare(text2, "content-length", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(text2, "content-type", StringComparison.OrdinalIgnoreCase) == 0)
							{
								continue;
							}
							if (string.Compare(text2, "expect", StringComparison.OrdinalIgnoreCase) == 0)
							{
								if (text3.ToUpperInvariant().IndexOf("100-CONTINUE", StringComparison.OrdinalIgnoreCase) != -1)
								{
									_httpRequestMessage.Headers.ExpectContinue = true;
								}
								else
								{
									_httpRequestMessage.Headers.Expect.TryParseAdd(text3);
								}
							}
							else if (string.Compare(text2, "referer", StringComparison.OrdinalIgnoreCase) == 0)
							{
								_httpRequestMessage.Headers.Referrer = new Uri(text3);
							}
							else if (string.Compare(text2, "transfer-encoding", StringComparison.OrdinalIgnoreCase) == 0)
							{
								if (text3.ToUpperInvariant().IndexOf("CHUNKED", StringComparison.OrdinalIgnoreCase) != -1)
								{
									_httpRequestMessage.Headers.TransferEncodingChunked = true;
								}
								else
								{
									_httpRequestMessage.Headers.TransferEncoding.TryParseAdd(text3);
								}
							}
							else if (string.Compare(text2, "user-agent", StringComparison.OrdinalIgnoreCase) == 0)
							{
								_httpRequestMessage.Headers.Add(text2, text3);
							}
							else if (string.Compare(text2, "if-modified-since", StringComparison.OrdinalIgnoreCase) == 0)
							{
								if (!DateTimeOffset.TryParse(text3, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out var result))
								{
									throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.HttpIfModifiedSinceParseError, text3)));
								}
								_httpRequestMessage.Headers.IfModifiedSince = result;
							}
							else
							{
								if (string.Compare(text2, "date", StringComparison.OrdinalIgnoreCase) == 0)
								{
									continue;
								}
								if (string.Compare(text2, "proxy-connection", StringComparison.OrdinalIgnoreCase) == 0)
								{
									throw ExceptionHelper.PlatformNotSupported("proxy-connection");
								}
								if (string.Compare(text2, "range", StringComparison.OrdinalIgnoreCase) != 0)
								{
									try
									{
										_httpRequestMessage.Headers.Add(text2, text3);
									}
									catch (Exception innerException)
									{
										throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.CopyHttpHeaderFailed, text2, text3, "System.Net.Http.Headers.HttpRequestHeaders"), innerException));
									}
								}
							}
						}
					}
				}
				if (text != null)
				{
					if (message.Version.Envelope == EnvelopeVersion.Soap11)
					{
						_httpRequestMessage.Headers.TryAddWithoutValidation("SOAPAction", text);
					}
					else if (message.Version.Envelope != EnvelopeVersion.Soap12 && message.Version.Envelope != EnvelopeVersion.None)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.EnvelopeVersionUnknown, message.Version.Envelope.ToString())));
					}
				}
				if (flag)
				{
					_httpRequestMessage.Headers.TransferEncodingChunked = false;
				}
				return flag;
			}

			public void OnReleaseRequest()
			{
				TryCompleteHttpRequest(_httpRequestMessage);
			}

			private void TryCompleteHttpRequest(HttpRequestMessage request)
			{
				if (request != null && Interlocked.CompareExchange(ref _httpRequestCompleted, 1, 0) == 0)
				{
					_channel.OnHttpRequestCompleted(request);
				}
			}

			private async Task SendPreauthenticationHeadRequestIfNeeded()
			{
				if (_factory.AuthenticationSchemeMayRequireResend())
				{
					Uri requestUri = _httpRequestMessage.RequestUri;
					HttpRequestMessage headHttpRequestMessage = new HttpRequestMessage
					{
						Method = HttpMethod.Head,
						RequestUri = requestUri
					};
					CancellationToken cancellationToken = await _timeoutHelper.GetCancellationTokenAsync();
					await _httpClient.SendAsync(headHttpRequestMessage, cancellationToken);
				}
			}
		}

		private SecurityTokenProviderContainer _tokenProvider;

		private SecurityTokenProviderContainer _proxyTokenProvider;

		public HttpChannelFactory<IRequestChannel> Factory { get; }

		protected ChannelParameterCollection ChannelParameters { get; private set; }

		public HttpClientRequestChannel(HttpChannelFactory<IRequestChannel> factory, EndpointAddress to, Uri via, bool manualAddressing)
			: base(factory, to, via, manualAddressing)
		{
			Factory = factory;
		}

		public override T GetProperty<T>()
		{
			if (typeof(T) == typeof(ChannelParameterCollection))
			{
				if (base.State == CommunicationState.Created)
				{
					lock (base.ThisLock)
					{
						if (ChannelParameters == null)
						{
							ChannelParameters = new ChannelParameterCollection();
						}
					}
				}
				return (T)(object)ChannelParameters;
			}
			return base.GetProperty<T>();
		}

		private void PrepareOpen()
		{
			Factory.MapIdentity(base.RemoteAddress);
		}

		private void CreateAndOpenTokenProviders(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			if (!base.ManualAddressing)
			{
				Factory.CreateAndOpenTokenProviders(base.RemoteAddress, base.Via, ChannelParameters, timeoutHelper.RemainingTime(), out _tokenProvider, out _proxyTokenProvider);
			}
		}

		private void CloseTokenProviders(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			if (_tokenProvider != null)
			{
				_tokenProvider.Close(timeoutHelper.RemainingTime());
			}
		}

		private void AbortTokenProviders()
		{
			if (_tokenProvider != null)
			{
				_tokenProvider.Abort();
			}
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

		protected internal override Task OnOpenAsync(TimeSpan timeout)
		{
			PrepareOpen();
			CreateAndOpenTokenProviders(timeout);
			return TaskHelpers.CompletedTask();
		}

		private void PrepareClose(bool aborting)
		{
		}

		protected override void OnAbort()
		{
			PrepareClose(aborting: true);
			AbortTokenProviders();
			base.OnAbort();
		}

		protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return CommunicationObjectInternal.OnBeginClose(this, timeout, callback, state);
		}

		protected override void OnEndClose(IAsyncResult result)
		{
			CommunicationObjectInternal.OnEnd(result);
		}

		protected override void OnClose(TimeSpan timeout)
		{
			CommunicationObjectInternal.OnClose(this, timeout);
		}

		protected internal override async Task OnCloseAsync(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			PrepareClose(aborting: false);
			CloseTokenProviders(timeoutHelper.RemainingTime());
			await WaitForPendingRequestsAsync(timeoutHelper.RemainingTime());
		}

		protected override IAsyncRequest CreateAsyncRequest(Message message)
		{
			return new HttpClientChannelAsyncRequest(this);
		}

		internal virtual Task<HttpClient> GetHttpClientAsync(EndpointAddress to, Uri via, TimeoutHelper timeoutHelper)
		{
			return GetHttpClientAsync(to, via, null, timeoutHelper);
		}

		protected async Task<HttpClient> GetHttpClientAsync(EndpointAddress to, Uri via, SecurityTokenContainer clientCertificateToken, TimeoutHelper timeoutHelper)
		{
			SecurityTokenProviderContainer requestTokenProvider;
			SecurityTokenProviderContainer proxyTokenProvider;
			if (base.ManualAddressing)
			{
				Factory.CreateAndOpenTokenProviders(to, via, ChannelParameters, timeoutHelper.RemainingTime(), out requestTokenProvider, out proxyTokenProvider);
			}
			else
			{
				requestTokenProvider = _tokenProvider;
				proxyTokenProvider = _proxyTokenProvider;
			}
			try
			{
				return await Factory.GetHttpClientAsync(to, via, requestTokenProvider, proxyTokenProvider, clientCertificateToken, timeoutHelper.RemainingTime());
			}
			finally
			{
				if (base.ManualAddressing)
				{
					requestTokenProvider?.Abort();
				}
			}
		}

		internal HttpRequestMessage GetHttpRequestMessage(Uri via)
		{
			return Factory.GetHttpRequestMessage(via);
		}

		internal virtual void OnHttpRequestCompleted(HttpRequestMessage request)
		{
		}
	}

	private class WebProxyFactory
	{
		private Uri _address;

		private bool _bypassOnLocal;

		internal AuthenticationSchemes AuthenticationScheme { get; }

		public WebProxyFactory(Uri address, bool bypassOnLocal, AuthenticationSchemes authenticationScheme)
		{
			_address = address;
			_bypassOnLocal = bypassOnLocal;
			if (!authenticationScheme.IsSingleton() && authenticationScheme != AuthenticationSchemes.IntegratedWindowsAuthentication)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("authenticationScheme", System.SR.Format(System.SR.HttpRequiresSingleAuthScheme, authenticationScheme));
			}
			AuthenticationScheme = authenticationScheme;
		}

		public async Task<IWebProxy> CreateWebProxyAsync(AuthenticationLevel requestAuthenticationLevel, TokenImpersonationLevel requestImpersonationLevel, SecurityTokenProviderContainer tokenProvider, TimeSpan timeout)
		{
			WebProxy result = new WebProxy(_address, _bypassOnLocal);
			if (AuthenticationScheme != AuthenticationSchemes.Anonymous)
			{
				OutWrapper<TokenImpersonationLevel> impersonationLevelWrapper = new OutWrapper<TokenImpersonationLevel>();
				OutWrapper<AuthenticationLevel> authenticationLevelWrapper = new OutWrapper<AuthenticationLevel>();
				NetworkCredential cred = await HttpChannelUtilities.GetCredentialAsync(AuthenticationScheme, tokenProvider, impersonationLevelWrapper, authenticationLevelWrapper, timeout);
				if (!TokenImpersonationLevelHelper.IsGreaterOrEqual(impersonationLevelWrapper.Value, requestImpersonationLevel))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ProxyImpersonationLevelMismatch, impersonationLevelWrapper.Value, requestImpersonationLevel)));
				}
				if (authenticationLevelWrapper.Value == AuthenticationLevel.MutualAuthRequired && requestAuthenticationLevel != AuthenticationLevel.MutualAuthRequired)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ProxyAuthenticationLevelMismatch, authenticationLevelWrapper.Value, requestAuthenticationLevel)));
				}
				CredentialCache credentialCache = new CredentialCache();
				if (AuthenticationScheme == AuthenticationSchemes.IntegratedWindowsAuthentication)
				{
					credentialCache.Add(_address, AuthenticationSchemesHelper.ToString(AuthenticationSchemes.Negotiate), cred);
					credentialCache.Add(_address, AuthenticationSchemesHelper.ToString(AuthenticationSchemes.Ntlm), cred);
				}
				else
				{
					credentialCache.Add(_address, AuthenticationSchemesHelper.ToString(AuthenticationScheme), cred);
				}
				result.Credentials = credentialCache;
			}
			return result;
		}
	}

	private static CacheControlHeaderValue s_requestCacheHeader = new CacheControlHeaderValue
	{
		NoCache = true,
		MaxAge = new TimeSpan(0L)
	};

	protected readonly ClientWebSocketFactory _clientWebSocketFactory;

	private HttpCookieContainerManager _httpCookieContainerManager;

	private volatile MruCache<Uri, Uri> _credentialCacheUriPrefixCache;

	private volatile MruCache<string, string> _credentialHashCache;

	private volatile MruCache<string, HttpClient> _httpClientCache;

	private IWebProxy _proxy;

	private WebProxyFactory _proxyFactory;

	private SecurityCredentialsManager _channelCredentials;

	private ISecurityCapabilities _securityCapabilities;

	private Func<HttpClientHandler, HttpMessageHandler> _httpMessageHandlerFactory;

	private Lazy<string> _webSocketSoapContentType;

	private SHA512 _hashAlgorithm;

	private bool _keepAliveEnabled;

	public bool AllowCookies { get; }

	public AuthenticationSchemes AuthenticationScheme { get; }

	public bool DecompressionEnabled { get; }

	public virtual bool IsChannelBindingSupportEnabled => false;

	public SecurityTokenManager SecurityTokenManager { get; private set; }

	public int MaxBufferSize { get; }

	public TransferMode TransferMode { get; }

	public override string Scheme => "http";

	public WebSocketTransportSettings WebSocketSettings { get; }

	internal string WebSocketSoapContentType => _webSocketSoapContentType.Value;

	private HashAlgorithm HashAlgorithm
	{
		[SecurityCritical]
		get
		{
			if (_hashAlgorithm == null)
			{
				_hashAlgorithm = SHA512.Create();
			}
			else
			{
				_hashAlgorithm.Initialize();
			}
			return _hashAlgorithm;
		}
	}

	protected ClientWebSocketFactory ClientWebSocketFactory => _clientWebSocketFactory;

	internal virtual bool IsExpectContinueHeaderRequired => AuthenticationSchemeMayRequireResend();

	internal HttpChannelFactory(HttpTransportBindingElement bindingElement, BindingContext context)
		: base((TransportBindingElement)bindingElement, context, HttpTransportDefaults.GetDefaultMessageEncoderFactory())
	{
		if (bindingElement.TransferMode == TransferMode.Buffered)
		{
			if (bindingElement.MaxReceivedMessageSize > int.MaxValue)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("bindingElement.MaxReceivedMessageSize", System.SR.MaxReceivedMessageSizeMustBeInIntegerRange));
			}
			if (bindingElement.MaxBufferSize != bindingElement.MaxReceivedMessageSize)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("bindingElement", System.SR.MaxBufferSizeMustMatchMaxReceivedMessageSize);
			}
		}
		else if (bindingElement.MaxBufferSize > bindingElement.MaxReceivedMessageSize)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("bindingElement", System.SR.MaxBufferSizeMustNotExceedMaxReceivedMessageSize);
		}
		if (TransferModeHelper.IsRequestStreamed(bindingElement.TransferMode) && bindingElement.AuthenticationScheme != AuthenticationSchemes.Anonymous)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("bindingElement", System.SR.HttpAuthDoesNotSupportRequestStreaming);
		}
		AllowCookies = bindingElement.AllowCookies;
		if (AllowCookies)
		{
			_httpCookieContainerManager = new HttpCookieContainerManager();
		}
		if (!bindingElement.AuthenticationScheme.IsSingleton() && bindingElement.AuthenticationScheme != AuthenticationSchemes.IntegratedWindowsAuthentication)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("value", System.SR.Format(System.SR.HttpRequiresSingleAuthScheme, bindingElement.AuthenticationScheme));
		}
		AuthenticationScheme = bindingElement.AuthenticationScheme;
		DecompressionEnabled = bindingElement.DecompressionEnabled;
		MaxBufferSize = bindingElement.MaxBufferSize;
		TransferMode = bindingElement.TransferMode;
		_keepAliveEnabled = bindingElement.KeepAliveEnabled;
		if (bindingElement.Proxy != null)
		{
			_proxy = bindingElement.Proxy;
		}
		else if (bindingElement.ProxyAddress != null)
		{
			if (bindingElement.UseDefaultWebProxy)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.UseDefaultWebProxyCantBeUsedWithExplicitProxyAddress));
			}
			if (bindingElement.ProxyAuthenticationScheme == AuthenticationSchemes.Anonymous)
			{
				_proxy = new WebProxy(bindingElement.ProxyAddress, bindingElement.BypassProxyOnLocal);
			}
			else
			{
				_proxy = null;
				_proxyFactory = new WebProxyFactory(bindingElement.ProxyAddress, bindingElement.BypassProxyOnLocal, bindingElement.ProxyAuthenticationScheme);
			}
		}
		else if (!bindingElement.UseDefaultWebProxy)
		{
			_proxy = new WebProxy();
		}
		_channelCredentials = context.BindingParameters.Find<SecurityCredentialsManager>();
		_securityCapabilities = bindingElement.GetProperty<ISecurityCapabilities>(context);
		_httpMessageHandlerFactory = context.BindingParameters.Find<Func<HttpClientHandler, HttpMessageHandler>>();
		WebSocketSettings = WebSocketHelper.GetRuntimeWebSocketSettings(bindingElement.WebSocketSettings);
		_clientWebSocketFactory = ClientWebSocketFactory.GetFactory();
		_webSocketSoapContentType = new Lazy<string>(() => base.MessageEncoderFactory.CreateSessionEncoder().ContentType, LazyThreadSafetyMode.ExecutionAndPublication);
		_httpClientCache = bindingElement.GetProperty<MruCache<string, HttpClient>>(context);
	}

	private bool AuthenticationSchemeMayRequireResend()
	{
		return AuthenticationScheme != AuthenticationSchemes.Anonymous;
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(ISecurityCapabilities))
		{
			return (T)_securityCapabilities;
		}
		if (typeof(T) == typeof(IHttpCookieContainerManager))
		{
			return (T)(object)GetHttpCookieContainerManager();
		}
		return base.GetProperty<T>();
	}

	private HttpCookieContainerManager GetHttpCookieContainerManager()
	{
		return _httpCookieContainerManager;
	}

	private Uri GetCredentialCacheUriPrefix(Uri via)
	{
		if (_credentialCacheUriPrefixCache == null)
		{
			lock (base.ThisLock)
			{
				if (_credentialCacheUriPrefixCache == null)
				{
					_credentialCacheUriPrefixCache = new MruCache<Uri, Uri>(10);
				}
			}
		}
		Uri value;
		lock (_credentialCacheUriPrefixCache)
		{
			if (!_credentialCacheUriPrefixCache.TryGetValue(via, out value))
			{
				value = new UriBuilder(via.Scheme, via.Host, via.Port).Uri;
				_credentialCacheUriPrefixCache.Add(via, value);
			}
		}
		return value;
	}

	internal async Task<HttpClient> GetHttpClientAsync(EndpointAddress to, Uri via, SecurityTokenProviderContainer tokenProvider, SecurityTokenProviderContainer proxyTokenProvider, SecurityTokenContainer clientCertificateToken, TimeSpan timeout)
	{
		OutWrapper<TokenImpersonationLevel> impersonationLevelWrapper = new OutWrapper<TokenImpersonationLevel>();
		OutWrapper<AuthenticationLevel> authenticationLevelWrapper = new OutWrapper<AuthenticationLevel>();
		NetworkCredential credential = await HttpChannelUtilities.GetCredentialAsync(AuthenticationScheme, tokenProvider, impersonationLevelWrapper, authenticationLevelWrapper, timeout);
		string connectionGroupName = GetConnectionGroupName(credential, authenticationLevelWrapper.Value, impersonationLevelWrapper.Value, clientCertificateToken);
		if (to.Identity is X509CertificateEndpointIdentity x509CertificateEndpointIdentity)
		{
			connectionGroupName = string.Format(CultureInfo.InvariantCulture, "{0}[{1}]", connectionGroupName, x509CertificateEndpointIdentity.Certificates[0].Thumbprint);
		}
		connectionGroupName = connectionGroupName ?? string.Empty;
		bool flag;
		HttpClient value;
		lock (_httpClientCache)
		{
			flag = _httpClientCache.TryGetValue(connectionGroupName, out value);
		}
		if (!flag)
		{
			HttpClientHandler clientHandler = GetHttpClientHandler(to, clientCertificateToken);
			if (DecompressionEnabled)
			{
				clientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			}
			else
			{
				clientHandler.AutomaticDecompression = DecompressionMethods.None;
			}
			if (clientHandler.SupportsProxy)
			{
				if (_proxy != null)
				{
					clientHandler.Proxy = _proxy;
					clientHandler.UseProxy = true;
				}
				else if (_proxyFactory != null)
				{
					HttpClientHandler httpClientHandler = clientHandler;
					httpClientHandler.Proxy = await _proxyFactory.CreateWebProxyAsync(authenticationLevelWrapper.Value, impersonationLevelWrapper.Value, proxyTokenProvider, timeout);
					clientHandler.UseProxy = true;
				}
			}
			clientHandler.UseCookies = AllowCookies;
			if (AllowCookies)
			{
				clientHandler.CookieContainer = _httpCookieContainerManager.CookieContainer;
			}
			clientHandler.PreAuthenticate = true;
			clientHandler.UseDefaultCredentials = false;
			if (credential == CredentialCache.DefaultCredentials || credential == null)
			{
				if (AuthenticationScheme != AuthenticationSchemes.Anonymous)
				{
					clientHandler.UseDefaultCredentials = true;
				}
			}
			else if (Fx.IsUap)
			{
				clientHandler.Credentials = credential;
			}
			else
			{
				CredentialCache credentialCache = new CredentialCache();
				Uri credentialCacheUriPrefix = GetCredentialCacheUriPrefix(via);
				if (AuthenticationScheme == AuthenticationSchemes.IntegratedWindowsAuthentication)
				{
					credentialCache.Add(credentialCacheUriPrefix, AuthenticationSchemesHelper.ToString(AuthenticationSchemes.Negotiate), credential);
					credentialCache.Add(credentialCacheUriPrefix, AuthenticationSchemesHelper.ToString(AuthenticationSchemes.Ntlm), credential);
				}
				else
				{
					credentialCache.Add(credentialCacheUriPrefix, AuthenticationSchemesHelper.ToString(AuthenticationScheme), credential);
				}
				clientHandler.Credentials = credentialCache;
			}
			HttpMessageHandler handler = clientHandler;
			if (_httpMessageHandlerFactory != null)
			{
				handler = _httpMessageHandlerFactory(clientHandler);
			}
			value = new HttpClient(handler);
			if (!_keepAliveEnabled)
			{
				value.DefaultRequestHeaders.ConnectionClose = true;
			}
			if (IsExpectContinueHeaderRequired && !Fx.IsUap)
			{
				value.DefaultRequestHeaders.ExpectContinue = true;
			}
			value.Timeout = Timeout.InfiniteTimeSpan;
			lock (_httpClientCache)
			{
				if (_httpClientCache.TryGetValue(connectionGroupName, out var value2))
				{
					value.Dispose();
					value = value2;
				}
				else
				{
					_httpClientCache.Add(connectionGroupName, value);
				}
			}
		}
		return value;
	}

	internal virtual HttpClientHandler GetHttpClientHandler(EndpointAddress to, SecurityTokenContainer clientCertificateToken)
	{
		return new HttpClientHandler();
	}

	internal ICredentials GetCredentials()
	{
		ICredentials result = null;
		if (AuthenticationScheme != AuthenticationSchemes.Anonymous)
		{
			result = CredentialCache.DefaultCredentials;
			if (_channelCredentials is ClientCredentials clientCredentials)
			{
				switch (AuthenticationScheme)
				{
				case AuthenticationSchemes.Basic:
					if (clientCredentials.UserName.UserName == null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("UserName");
					}
					if (clientCredentials.UserName.UserName == string.Empty)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.UserNameCannotBeEmpty);
					}
					result = new NetworkCredential(clientCredentials.UserName.UserName, clientCredentials.UserName.Password);
					break;
				case AuthenticationSchemes.Digest:
					if (clientCredentials.HttpDigest.ClientCredential.UserName != string.Empty)
					{
						result = clientCredentials.HttpDigest.ClientCredential;
					}
					break;
				case AuthenticationSchemes.Negotiate:
				case AuthenticationSchemes.Ntlm:
				case AuthenticationSchemes.IntegratedWindowsAuthentication:
					if (clientCredentials.Windows.ClientCredential.UserName != string.Empty)
					{
						result = clientCredentials.Windows.ClientCredential;
					}
					break;
				}
			}
		}
		return result;
	}

	internal Exception CreateToMustEqualViaException(Uri to, Uri via)
	{
		return new ArgumentException(System.SR.Format(System.SR.HttpToMustEqualVia, to, via));
	}

	public override int GetMaxBufferSize()
	{
		return MaxBufferSize;
	}

	private SecurityTokenProviderContainer CreateAndOpenTokenProvider(TimeSpan timeout, AuthenticationSchemes authenticationScheme, EndpointAddress target, Uri via, ChannelParameterCollection channelParameters)
	{
		SecurityTokenProvider securityTokenProvider = null;
		switch (authenticationScheme)
		{
		case AuthenticationSchemes.Basic:
			securityTokenProvider = TransportSecurityHelpers.GetUserNameTokenProvider(SecurityTokenManager, target, via, Scheme, authenticationScheme, channelParameters);
			break;
		case AuthenticationSchemes.Negotiate:
		case AuthenticationSchemes.Ntlm:
		case AuthenticationSchemes.IntegratedWindowsAuthentication:
			securityTokenProvider = TransportSecurityHelpers.GetSspiTokenProvider(SecurityTokenManager, target, via, Scheme, authenticationScheme, channelParameters);
			break;
		case AuthenticationSchemes.Digest:
			securityTokenProvider = TransportSecurityHelpers.GetDigestTokenProvider(SecurityTokenManager, target, via, Scheme, authenticationScheme, channelParameters);
			break;
		default:
			throw Fx.AssertAndThrow("CreateAndOpenTokenProvider: Invalid authentication scheme");
		case AuthenticationSchemes.Anonymous:
			break;
		}
		SecurityTokenProviderContainer securityTokenProviderContainer;
		if (securityTokenProvider != null)
		{
			securityTokenProviderContainer = new SecurityTokenProviderContainer(securityTokenProvider);
			securityTokenProviderContainer.Open(timeout);
		}
		else
		{
			securityTokenProviderContainer = null;
		}
		return securityTokenProviderContainer;
	}

	protected virtual void ValidateCreateChannelParameters(EndpointAddress remoteAddress, Uri via)
	{
		if (string.Compare(via.Scheme, "ws", StringComparison.OrdinalIgnoreCase) != 0)
		{
			ValidateScheme(via);
		}
		if (base.MessageVersion.Addressing == AddressingVersion.None && remoteAddress.Uri != via)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateToMustEqualViaException(remoteAddress.Uri, via));
		}
	}

	protected override TChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)
	{
		if (typeof(TChannel) != typeof(IRequestChannel))
		{
			remoteAddress = ((remoteAddress != null && !WebSocketHelper.IsWebSocketUri(remoteAddress.Uri)) ? new EndpointAddress(WebSocketHelper.NormalizeHttpSchemeWithWsScheme(remoteAddress.Uri), remoteAddress) : remoteAddress);
			via = ((!WebSocketHelper.IsWebSocketUri(via)) ? WebSocketHelper.NormalizeHttpSchemeWithWsScheme(via) : via);
		}
		return OnCreateChannelCore(remoteAddress, via);
	}

	protected virtual TChannel OnCreateChannelCore(EndpointAddress remoteAddress, Uri via)
	{
		ValidateCreateChannelParameters(remoteAddress, via);
		ValidateWebSocketTransportUsage();
		if (typeof(TChannel) == typeof(IRequestChannel))
		{
			return (TChannel)(object)new HttpClientRequestChannel((HttpChannelFactory<IRequestChannel>)(object)this, remoteAddress, via, base.ManualAddressing);
		}
		return (TChannel)(object)new ClientWebSocketTransportDuplexSessionChannel((HttpChannelFactory<IDuplexSessionChannel>)(object)this, _clientWebSocketFactory, remoteAddress, via);
	}

	protected void ValidateWebSocketTransportUsage()
	{
		Type typeFromHandle = typeof(TChannel);
		if (typeFromHandle == typeof(IRequestChannel) && WebSocketSettings.TransportUsage == WebSocketTransportUsage.Always)
		{
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.WebSocketCannotCreateRequestClientChannelWithCertainWebSocketTransportUsage, typeof(TChannel), "TransportUsage", typeof(WebSocketTransportSettings).Name, WebSocketSettings.TransportUsage)));
		}
		if (typeFromHandle == typeof(IDuplexSessionChannel) && WebSocketSettings.TransportUsage == WebSocketTransportUsage.Never)
		{
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.WebSocketCannotCreateRequestClientChannelWithCertainWebSocketTransportUsage, typeof(TChannel), "TransportUsage", typeof(WebSocketTransportSettings).Name, WebSocketSettings.TransportUsage)));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeSecurityTokenManager()
	{
		if (_channelCredentials == null)
		{
			_channelCredentials = ClientCredentials.CreateDefaultCredentials();
		}
		SecurityTokenManager = _channelCredentials.CreateSecurityTokenManager();
	}

	protected virtual bool IsSecurityTokenManagerRequired()
	{
		if (AuthenticationScheme != AuthenticationSchemes.Anonymous)
		{
			return true;
		}
		if (_proxyFactory != null && _proxyFactory.AuthenticationScheme != AuthenticationSchemes.Anonymous)
		{
			return true;
		}
		return false;
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnOpenAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		if (IsSecurityTokenManagerRequired())
		{
			InitializeSecurityTokenManager();
		}
		if (AllowCookies && !_httpCookieContainerManager.IsInitialized)
		{
			_httpCookieContainerManager.CookieContainer = new CookieContainer();
		}
	}

	protected internal override Task OnOpenAsync(TimeSpan timeout)
	{
		OnOpen(timeout);
		return TaskHelpers.CompletedTask();
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		return base.OnCloseAsync(timeout);
	}

	protected override void OnClosed()
	{
		base.OnClosed();
		if (_httpClientCache != null && !_httpClientCache.IsDisposed)
		{
			lock (_httpClientCache)
			{
				_httpClientCache.Dispose();
				_httpClientCache = null;
			}
		}
	}

	private string AppendWindowsAuthenticationInfo(string inputString, NetworkCredential credential, AuthenticationLevel authenticationLevel, TokenImpersonationLevel impersonationLevel)
	{
		return SecurityUtils.AppendWindowsAuthenticationInfo(inputString, credential, authenticationLevel, impersonationLevel);
	}

	protected virtual string OnGetConnectionGroupPrefix(SecurityTokenContainer clientCertificateToken)
	{
		return string.Empty;
	}

	internal static bool IsWindowsAuth(AuthenticationSchemes authScheme)
	{
		if (authScheme != AuthenticationSchemes.Negotiate && authScheme != AuthenticationSchemes.Ntlm)
		{
			return authScheme == AuthenticationSchemes.IntegratedWindowsAuthentication;
		}
		return true;
	}

	private string GetConnectionGroupName(NetworkCredential credential, AuthenticationLevel authenticationLevel, TokenImpersonationLevel impersonationLevel, SecurityTokenContainer clientCertificateToken)
	{
		if (_credentialHashCache == null)
		{
			lock (base.ThisLock)
			{
				if (_credentialHashCache == null)
				{
					_credentialHashCache = new MruCache<string, string>(5);
				}
			}
		}
		string text = (TransferModeHelper.IsRequestStreamed(TransferMode) ? "streamed" : string.Empty);
		if (IsWindowsAuth(AuthenticationScheme))
		{
			text = AppendWindowsAuthenticationInfo(text, credential, authenticationLevel, impersonationLevel);
		}
		text = OnGetConnectionGroupPrefix(clientCertificateToken) + text;
		string value = null;
		if (!string.IsNullOrEmpty(text))
		{
			lock (_credentialHashCache)
			{
				if (!_credentialHashCache.TryGetValue(text, out value))
				{
					byte[] bytes = new UTF8Encoding().GetBytes(text);
					byte[] inArray = HashAlgorithm.ComputeHash(bytes);
					value = Convert.ToBase64String(inArray);
					_credentialHashCache.Add(text, value);
				}
			}
		}
		return value;
	}

	internal HttpRequestMessage GetHttpRequestMessage(Uri via)
	{
		HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, via);
		if (TransferModeHelper.IsRequestStreamed(TransferMode))
		{
			httpRequestMessage.Headers.TransferEncodingChunked = true;
		}
		httpRequestMessage.Headers.CacheControl = s_requestCacheHeader;
		return httpRequestMessage;
	}

	private void ApplyManualAddressing(ref EndpointAddress to, ref Uri via, Message message)
	{
		if (base.ManualAddressing)
		{
			Uri to2 = message.Headers.To;
			if (to2 == null)
			{
				throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.ManualAddressingRequiresAddressedMessages), message);
			}
			to = new EndpointAddress(to2);
			if (base.MessageVersion.Addressing == AddressingVersion.None)
			{
				via = to2;
			}
		}
		if (!message.Properties.TryGetValue(HttpRequestMessageProperty.Name, out var value))
		{
			return;
		}
		HttpRequestMessageProperty httpRequestMessageProperty = (HttpRequestMessageProperty)value;
		if (!string.IsNullOrEmpty(httpRequestMessageProperty.QueryString))
		{
			UriBuilder uriBuilder = new UriBuilder(via);
			if (httpRequestMessageProperty.QueryString.StartsWith("?", StringComparison.Ordinal))
			{
				uriBuilder.Query = httpRequestMessageProperty.QueryString.Substring(1);
			}
			else
			{
				uriBuilder.Query = httpRequestMessageProperty.QueryString;
			}
			via = uriBuilder.Uri;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateAndOpenTokenProvidersCore(EndpointAddress to, Uri via, ChannelParameterCollection channelParameters, TimeSpan timeout, out SecurityTokenProviderContainer tokenProvider, out SecurityTokenProviderContainer proxyTokenProvider)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		tokenProvider = CreateAndOpenTokenProvider(timeoutHelper.RemainingTime(), AuthenticationScheme, to, via, channelParameters);
		if (_proxyFactory != null)
		{
			proxyTokenProvider = CreateAndOpenTokenProvider(timeoutHelper.RemainingTime(), _proxyFactory.AuthenticationScheme, to, via, channelParameters);
		}
		else
		{
			proxyTokenProvider = null;
		}
	}

	internal void CreateAndOpenTokenProviders(EndpointAddress to, Uri via, ChannelParameterCollection channelParameters, TimeSpan timeout, out SecurityTokenProviderContainer tokenProvider, out SecurityTokenProviderContainer proxyTokenProvider)
	{
		if (!IsSecurityTokenManagerRequired())
		{
			tokenProvider = null;
			proxyTokenProvider = null;
		}
		else
		{
			CreateAndOpenTokenProvidersCore(to, via, channelParameters, timeout, out tokenProvider, out proxyTokenProvider);
		}
	}

	internal static bool MapIdentity(EndpointAddress target, AuthenticationSchemes authenticationScheme)
	{
		if (target.Identity == null)
		{
			return false;
		}
		return IsWindowsAuth(authenticationScheme);
	}

	private bool MapIdentity(EndpointAddress target)
	{
		return MapIdentity(target, AuthenticationScheme);
	}
}
