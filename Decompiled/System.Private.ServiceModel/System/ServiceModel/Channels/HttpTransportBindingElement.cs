using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime;
using System.Security.Authentication.ExtendedProtection;

namespace System.ServiceModel.Channels;

public class HttpTransportBindingElement : TransportBindingElement
{
	private class BindingDeliveryCapabilitiesHelper : IBindingDeliveryCapabilities
	{
		bool IBindingDeliveryCapabilities.AssuresOrderedDelivery => false;

		bool IBindingDeliveryCapabilities.QueuedDelivery => false;

		internal BindingDeliveryCapabilitiesHelper()
		{
		}
	}

	private class TransportCompressionSupportHelper : ITransportCompressionSupport
	{
		public bool IsCompressionFormatSupported(CompressionFormat compressionFormat)
		{
			return true;
		}
	}

	private HostNameComparisonMode _hostNameComparisonMode;

	private bool _inheritBaseAddressSettings;

	private int _maxBufferSize;

	private bool _maxBufferSizeInitialized;

	private string _method;

	private AuthenticationSchemes _proxyAuthenticationScheme;

	private string _realm;

	private TimeSpan _requestInitializationTimeout;

	private TransferMode _transferMode;

	private bool _useDefaultWebProxy;

	private WebSocketTransportSettings _webSocketSettings;

	private ExtendedProtectionPolicy _extendedProtectionPolicy;

	private int _maxPendingAccepts;

	private MruCache<string, HttpClient> _httpClientCache;

	[DefaultValue(false)]
	public bool AllowCookies { get; set; }

	[DefaultValue(AuthenticationSchemes.Anonymous)]
	public AuthenticationSchemes AuthenticationScheme { get; set; }

	[DefaultValue(false)]
	public bool BypassProxyOnLocal { get; set; }

	[DefaultValue(true)]
	public bool DecompressionEnabled { get; set; }

	[DefaultValue(HostNameComparisonMode.StrongWildcard)]
	public HostNameComparisonMode HostNameComparisonMode
	{
		get
		{
			return _hostNameComparisonMode;
		}
		set
		{
			HostNameComparisonModeHelper.Validate(value);
			_hostNameComparisonMode = value;
		}
	}

	public HttpMessageHandlerFactory MessageHandlerFactory { get; set; }

	public ExtendedProtectionPolicy ExtendedProtectionPolicy
	{
		get
		{
			return _extendedProtectionPolicy;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value.PolicyEnforcement == PolicyEnforcement.Always && !ExtendedProtectionPolicy.OSSupportsExtendedProtection)
			{
				ExceptionHelper.PlatformNotSupported(System.SR.ExtendedProtectionNotSupported);
			}
			_extendedProtectionPolicy = value;
		}
	}

	internal bool InheritBaseAddressSettings
	{
		get
		{
			return _inheritBaseAddressSettings;
		}
		set
		{
			_inheritBaseAddressSettings = value;
		}
	}

	[DefaultValue(true)]
	public bool KeepAliveEnabled { get; set; }

	[DefaultValue(65536)]
	public int MaxBufferSize
	{
		get
		{
			if (_maxBufferSizeInitialized || TransferMode != TransferMode.Buffered)
			{
				return _maxBufferSize;
			}
			long maxReceivedMessageSize = MaxReceivedMessageSize;
			if (maxReceivedMessageSize > int.MaxValue)
			{
				return int.MaxValue;
			}
			return (int)maxReceivedMessageSize;
		}
		set
		{
			if (value <= 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBePositive));
			}
			_maxBufferSizeInitialized = true;
			_maxBufferSize = value;
		}
	}

	[DefaultValue(0)]
	public int MaxPendingAccepts
	{
		get
		{
			return _maxPendingAccepts;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBeNonNegative));
			}
			if (value > 100000)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.Format(System.SR.HttpMaxPendingAcceptsTooLargeError, 100000)));
			}
			_maxPendingAccepts = value;
		}
	}

	internal string Method
	{
		get
		{
			return _method;
		}
		set
		{
			_method = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	[DefaultValue(null)]
	public IWebProxy Proxy { get; set; }

	[DefaultValue(null)]
	[TypeConverter(typeof(UriTypeConverter))]
	public Uri ProxyAddress { get; set; }

	[DefaultValue(AuthenticationSchemes.Anonymous)]
	public AuthenticationSchemes ProxyAuthenticationScheme
	{
		get
		{
			return _proxyAuthenticationScheme;
		}
		set
		{
			if (!value.IsSingleton())
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("value", System.SR.Format(System.SR.HttpProxyRequiresSingleAuthScheme, value));
			}
			_proxyAuthenticationScheme = value;
		}
	}

	[DefaultValue("")]
	public string Realm
	{
		get
		{
			return _realm;
		}
		set
		{
			_realm = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	[DefaultValue(typeof(TimeSpan), "00:00:00")]
	public TimeSpan RequestInitializationTimeout
	{
		get
		{
			return _requestInitializationTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRange0));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_requestInitializationTimeout = value;
		}
	}

	public override string Scheme => "http";

	[DefaultValue(TransferMode.Buffered)]
	public TransferMode TransferMode
	{
		get
		{
			return _transferMode;
		}
		set
		{
			TransferModeHelper.Validate(value);
			_transferMode = value;
		}
	}

	public WebSocketTransportSettings WebSocketSettings
	{
		get
		{
			return _webSocketSettings;
		}
		set
		{
			_webSocketSettings = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	[DefaultValue(false)]
	public bool UnsafeConnectionNtlmAuthentication { get; set; }

	[DefaultValue(true)]
	public bool UseDefaultWebProxy
	{
		get
		{
			return _useDefaultWebProxy;
		}
		set
		{
			_useDefaultWebProxy = value;
		}
	}

	public HttpTransportBindingElement()
	{
		AllowCookies = false;
		AuthenticationScheme = AuthenticationSchemes.Anonymous;
		BypassProxyOnLocal = false;
		DecompressionEnabled = true;
		_hostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
		KeepAliveEnabled = true;
		_maxBufferSize = 65536;
		_maxPendingAccepts = 0;
		_method = string.Empty;
		_proxyAuthenticationScheme = AuthenticationSchemes.Anonymous;
		Proxy = null;
		ProxyAddress = null;
		_realm = "";
		_requestInitializationTimeout = HttpTransportDefaults.RequestInitializationTimeout;
		_transferMode = TransferMode.Buffered;
		UnsafeConnectionNtlmAuthentication = false;
		_useDefaultWebProxy = true;
		_webSocketSettings = HttpTransportDefaults.GetDefaultWebSocketTransportSettings();
	}

	protected HttpTransportBindingElement(HttpTransportBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		AllowCookies = elementToBeCloned.AllowCookies;
		AuthenticationScheme = elementToBeCloned.AuthenticationScheme;
		BypassProxyOnLocal = elementToBeCloned.BypassProxyOnLocal;
		DecompressionEnabled = elementToBeCloned.DecompressionEnabled;
		_hostNameComparisonMode = elementToBeCloned._hostNameComparisonMode;
		_inheritBaseAddressSettings = elementToBeCloned.InheritBaseAddressSettings;
		KeepAliveEnabled = elementToBeCloned.KeepAliveEnabled;
		_maxBufferSize = elementToBeCloned._maxBufferSize;
		_maxBufferSizeInitialized = elementToBeCloned._maxBufferSizeInitialized;
		_maxPendingAccepts = elementToBeCloned._maxPendingAccepts;
		_method = elementToBeCloned._method;
		Proxy = elementToBeCloned.Proxy;
		ProxyAddress = elementToBeCloned.ProxyAddress;
		_proxyAuthenticationScheme = elementToBeCloned._proxyAuthenticationScheme;
		_realm = elementToBeCloned._realm;
		_requestInitializationTimeout = elementToBeCloned._requestInitializationTimeout;
		_transferMode = elementToBeCloned._transferMode;
		UnsafeConnectionNtlmAuthentication = elementToBeCloned.UnsafeConnectionNtlmAuthentication;
		_useDefaultWebProxy = elementToBeCloned._useDefaultWebProxy;
		_webSocketSettings = elementToBeCloned._webSocketSettings.Clone();
		_extendedProtectionPolicy = elementToBeCloned.ExtendedProtectionPolicy;
		MessageHandlerFactory = elementToBeCloned.MessageHandlerFactory;
	}

	internal virtual bool GetSupportsClientAuthenticationImpl(AuthenticationSchemes effectiveAuthenticationSchemes)
	{
		if (effectiveAuthenticationSchemes != AuthenticationSchemes.None)
		{
			return effectiveAuthenticationSchemes.IsNotSet(AuthenticationSchemes.Anonymous);
		}
		return false;
	}

	internal virtual bool GetSupportsClientWindowsIdentityImpl(AuthenticationSchemes effectiveAuthenticationSchemes)
	{
		if (effectiveAuthenticationSchemes != AuthenticationSchemes.None)
		{
			return effectiveAuthenticationSchemes.IsNotSet(AuthenticationSchemes.Anonymous);
		}
		return false;
	}

	internal string GetWsdlTransportUri(bool useWebSocketTransport)
	{
		if (useWebSocketTransport)
		{
			return "http://schemas.microsoft.com/soap/websocket";
		}
		return "http://schemas.xmlsoap.org/soap/http";
	}

	public override BindingElement Clone()
	{
		return new HttpTransportBindingElement(this);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(ISecurityCapabilities))
		{
			AuthenticationSchemes authenticationScheme = AuthenticationScheme;
			return (T)(object)new SecurityCapabilities(GetSupportsClientAuthenticationImpl(authenticationScheme), authenticationScheme == AuthenticationSchemes.Negotiate, GetSupportsClientWindowsIdentityImpl(authenticationScheme), ProtectionLevel.None, ProtectionLevel.None);
		}
		if (typeof(T) == typeof(IBindingDeliveryCapabilities))
		{
			return (T)(object)new BindingDeliveryCapabilitiesHelper();
		}
		if (typeof(T) == typeof(TransferMode))
		{
			return (T)(object)TransferMode;
		}
		if (typeof(T) == typeof(ExtendedProtectionPolicy))
		{
			return (T)(object)ExtendedProtectionPolicy;
		}
		if (typeof(T) == typeof(ITransportCompressionSupport))
		{
			return (T)(object)new TransportCompressionSupportHelper();
		}
		if (typeof(T) == typeof(MruCache<string, HttpClient>))
		{
			EnsureHttpClientCache();
			return (T)(object)_httpClientCache;
		}
		if (context.BindingParameters.Find<MessageEncodingBindingElement>() == null)
		{
			context.BindingParameters.Add(new TextMessageEncodingBindingElement());
		}
		return base.GetProperty<T>(context);
	}

	private MruCache<string, HttpClient> EnsureHttpClientCache()
	{
		if (_httpClientCache == null || !_httpClientCache.AddRef())
		{
			_httpClientCache = new MruCache<string, HttpClient>(10);
		}
		return _httpClientCache;
	}

	public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (typeof(TChannel) == typeof(IRequestChannel))
		{
			return WebSocketSettings.TransportUsage != WebSocketTransportUsage.Always;
		}
		if (typeof(TChannel) == typeof(IDuplexSessionChannel))
		{
			return WebSocketSettings.TransportUsage != WebSocketTransportUsage.Never;
		}
		return false;
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (MessageHandlerFactory != null)
		{
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.HttpPipelineNotSupportedOnClientSide, "MessageHandlerFactory")));
		}
		if (!CanBuildChannelFactory<TChannel>(context))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("TChannel", System.SR.Format(System.SR.CouldnTCreateChannelForChannelType2, context.Binding.Name, typeof(TChannel)));
		}
		if (AuthenticationScheme == AuthenticationSchemes.None)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("value", System.SR.Format(System.SR.HttpAuthSchemeCannotBeNone, AuthenticationScheme));
		}
		if (!AuthenticationScheme.IsSingleton() && AuthenticationScheme != AuthenticationSchemes.IntegratedWindowsAuthentication)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("value", System.SR.Format(System.SR.HttpRequiresSingleAuthScheme, AuthenticationScheme));
		}
		return new HttpChannelFactory<TChannel>(this, context);
	}

	internal override bool IsMatch(BindingElement b)
	{
		if (!base.IsMatch(b))
		{
			return false;
		}
		if (!(b is HttpTransportBindingElement httpTransportBindingElement))
		{
			return false;
		}
		if (AllowCookies != httpTransportBindingElement.AllowCookies)
		{
			return false;
		}
		if (AuthenticationScheme != httpTransportBindingElement.AuthenticationScheme)
		{
			return false;
		}
		if (DecompressionEnabled != httpTransportBindingElement.DecompressionEnabled)
		{
			return false;
		}
		if (_hostNameComparisonMode != httpTransportBindingElement._hostNameComparisonMode)
		{
			return false;
		}
		if (_inheritBaseAddressSettings != httpTransportBindingElement._inheritBaseAddressSettings)
		{
			return false;
		}
		if (KeepAliveEnabled != httpTransportBindingElement.KeepAliveEnabled)
		{
			return false;
		}
		if (_maxBufferSize != httpTransportBindingElement._maxBufferSize)
		{
			return false;
		}
		if (_method != httpTransportBindingElement._method)
		{
			return false;
		}
		if (_realm != httpTransportBindingElement._realm)
		{
			return false;
		}
		if (_transferMode != httpTransportBindingElement._transferMode)
		{
			return false;
		}
		if (UnsafeConnectionNtlmAuthentication != httpTransportBindingElement.UnsafeConnectionNtlmAuthentication)
		{
			return false;
		}
		if (_useDefaultWebProxy != httpTransportBindingElement._useDefaultWebProxy)
		{
			return false;
		}
		if (!WebSocketSettings.Equals(httpTransportBindingElement.WebSocketSettings))
		{
			return false;
		}
		return true;
	}

	private MessageEncodingBindingElement FindMessageEncodingBindingElement(BindingElementCollection bindingElements, out bool createdNew)
	{
		createdNew = false;
		MessageEncodingBindingElement messageEncodingBindingElement = bindingElements.Find<MessageEncodingBindingElement>();
		if (messageEncodingBindingElement == null)
		{
			createdNew = true;
			messageEncodingBindingElement = new TextMessageEncodingBindingElement();
		}
		return messageEncodingBindingElement;
	}
}
