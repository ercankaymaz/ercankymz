using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IdentityModel.Selectors;
using System.Runtime;
using System.Security.Authentication.ExtendedProtection;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace System.ServiceModel.Security;

internal abstract class SecurityProtocolFactory : ISecurityCommunicationObject
{
	internal const bool defaultAddTimestamp = true;

	internal const bool defaultDeriveKeys = true;

	internal const bool defaultDetectReplays = true;

	internal const string defaultMaxClockSkewString = "00:05:00";

	internal const string defaultReplayWindowString = "00:05:00";

	internal static readonly TimeSpan defaultMaxClockSkew = TimeSpan.Parse("00:05:00", CultureInfo.InvariantCulture);

	internal static readonly TimeSpan defaultReplayWindow = TimeSpan.Parse("00:05:00", CultureInfo.InvariantCulture);

	internal const int defaultMaxCachedNonces = 900000;

	internal const string defaultTimestampValidityDurationString = "00:05:00";

	internal static readonly TimeSpan defaultTimestampValidityDuration = TimeSpan.Parse("00:05:00", CultureInfo.InvariantCulture);

	internal const SecurityHeaderLayout defaultSecurityHeaderLayout = SecurityHeaderLayout.Strict;

	private static ReadOnlyCollection<SupportingTokenAuthenticatorSpecification> s_emptyTokenAuthenticators;

	private bool _addTimestamp = true;

	private bool _detectReplays = true;

	private bool _expectIncomingMessages;

	private bool _expectOutgoingMessages;

	private SecurityAlgorithmSuite _incomingAlgorithmSuite = SecurityAlgorithmSuite.Default;

	private ICollection<SupportingTokenAuthenticatorSpecification> _channelSupportingTokenAuthenticatorSpecification;

	private int _maxCachedNonces = 900000;

	private TimeSpan _maxClockSkew = defaultMaxClockSkew;

	private NonceCache _nonceCache;

	private SecurityAlgorithmSuite _outgoingAlgorithmSuite = SecurityAlgorithmSuite.Default;

	private TimeSpan _replayWindow = defaultReplayWindow;

	private SecurityStandardsManager _standardsManager = SecurityStandardsManager.DefaultInstance;

	private SecurityTokenManager _securityTokenManager;

	private SecurityBindingElement _securityBindingElement;

	private string _requestReplyErrorPropertyName;

	private TimeSpan _timestampValidityDuration = defaultTimestampValidityDuration;

	private SecurityHeaderLayout _securityHeaderLayout;

	private bool _expectChannelBasicTokens;

	private bool _expectChannelSignedTokens;

	private bool _expectChannelEndorsingTokens;

	private BufferManager _streamBufferManager;

	protected WrapperSecurityCommunicationObject CommunicationObject { get; }

	public bool ActAsInitiator { get; private set; }

	public BufferManager StreamBufferManager
	{
		get
		{
			if (_streamBufferManager == null)
			{
				_streamBufferManager = BufferManager.CreateBufferManager(0L, int.MaxValue);
			}
			return _streamBufferManager;
		}
		set
		{
			_streamBufferManager = value;
		}
	}

	public ExtendedProtectionPolicy ExtendedProtectionPolicy { get; set; }

	public bool AddTimestamp
	{
		get
		{
			return _addTimestamp;
		}
		set
		{
			ThrowIfImmutable();
			_addTimestamp = value;
		}
	}

	public bool DetectReplays
	{
		get
		{
			return _detectReplays;
		}
		set
		{
			ThrowIfImmutable();
			_detectReplays = value;
		}
	}

	private static ReadOnlyCollection<SupportingTokenAuthenticatorSpecification> EmptyTokenAuthenticators
	{
		get
		{
			if (s_emptyTokenAuthenticators == null)
			{
				s_emptyTokenAuthenticators = Array.AsReadOnly(new SupportingTokenAuthenticatorSpecification[0]);
			}
			return s_emptyTokenAuthenticators;
		}
	}

	internal bool ExpectKeyDerivation { get; set; }

	internal bool ExpectSupportingTokens { get; set; }

	public SecurityAlgorithmSuite IncomingAlgorithmSuite
	{
		get
		{
			return _incomingAlgorithmSuite;
		}
		set
		{
			ThrowIfImmutable();
			_incomingAlgorithmSuite = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public int MaxCachedNonces
	{
		get
		{
			return _maxCachedNonces;
		}
		set
		{
			ThrowIfImmutable();
			if (value <= 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_maxCachedNonces = value;
		}
	}

	public TimeSpan MaxClockSkew
	{
		get
		{
			return _maxClockSkew;
		}
		set
		{
			ThrowIfImmutable();
			if (value < TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_maxClockSkew = value;
		}
	}

	public NonceCache NonceCache
	{
		get
		{
			return _nonceCache;
		}
		set
		{
			ThrowIfImmutable();
			_nonceCache = value;
		}
	}

	public SecurityAlgorithmSuite OutgoingAlgorithmSuite
	{
		get
		{
			return _outgoingAlgorithmSuite;
		}
		set
		{
			ThrowIfImmutable();
			_outgoingAlgorithmSuite = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public TimeSpan ReplayWindow
	{
		get
		{
			return _replayWindow;
		}
		set
		{
			ThrowIfImmutable();
			if (value <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.TimeSpanMustbeGreaterThanTimeSpanZero));
			}
			_replayWindow = value;
		}
	}

	public SecurityBindingElement SecurityBindingElement
	{
		get
		{
			return _securityBindingElement;
		}
		set
		{
			ThrowIfImmutable();
			if (value != null)
			{
				value = (SecurityBindingElement)value.Clone();
			}
			_securityBindingElement = value;
		}
	}

	public SecurityTokenManager SecurityTokenManager
	{
		get
		{
			return _securityTokenManager;
		}
		set
		{
			ThrowIfImmutable();
			_securityTokenManager = value;
		}
	}

	public virtual bool SupportsDuplex => false;

	public SecurityHeaderLayout SecurityHeaderLayout
	{
		get
		{
			return _securityHeaderLayout;
		}
		set
		{
			ThrowIfImmutable();
			_securityHeaderLayout = value;
		}
	}

	public virtual bool SupportsReplayDetection => true;

	public virtual bool SupportsRequestReply => true;

	public SecurityStandardsManager StandardsManager
	{
		get
		{
			return _standardsManager;
		}
		set
		{
			ThrowIfImmutable();
			_standardsManager = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public TimeSpan TimestampValidityDuration
	{
		get
		{
			return _timestampValidityDuration;
		}
		set
		{
			ThrowIfImmutable();
			if (value <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.TimeSpanMustbeGreaterThanTimeSpanZero));
			}
			_timestampValidityDuration = value;
		}
	}

	internal MessageSecurityVersion MessageSecurityVersion { get; private set; }

	public TimeSpan DefaultOpenTimeout => ServiceDefaults.OpenTimeout;

	public TimeSpan DefaultCloseTimeout => ServiceDefaults.CloseTimeout;

	protected SecurityProtocolFactory()
	{
		_channelSupportingTokenAuthenticatorSpecification = new Collection<SupportingTokenAuthenticatorSpecification>();
		CommunicationObject = new WrapperSecurityCommunicationObject(this);
	}

	internal SecurityProtocolFactory(SecurityProtocolFactory factory)
		: this()
	{
		if (factory == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("factory");
		}
		ActAsInitiator = factory.ActAsInitiator;
		_addTimestamp = factory._addTimestamp;
		_detectReplays = factory._detectReplays;
		_incomingAlgorithmSuite = factory._incomingAlgorithmSuite;
		_maxCachedNonces = factory._maxCachedNonces;
		_maxClockSkew = factory._maxClockSkew;
		_outgoingAlgorithmSuite = factory._outgoingAlgorithmSuite;
		_replayWindow = factory._replayWindow;
		_channelSupportingTokenAuthenticatorSpecification = new Collection<SupportingTokenAuthenticatorSpecification>(new List<SupportingTokenAuthenticatorSpecification>(factory._channelSupportingTokenAuthenticatorSpecification));
		_standardsManager = factory._standardsManager;
		_timestampValidityDuration = factory._timestampValidityDuration;
		_securityBindingElement = (SecurityBindingElement)(factory._securityBindingElement?.Clone());
		_securityTokenManager = factory._securityTokenManager;
		_nonceCache = factory._nonceCache;
	}

	public void OnClosed()
	{
	}

	public void OnClosing()
	{
	}

	public void OnFaulted()
	{
	}

	public void OnOpened()
	{
	}

	public void OnOpening()
	{
	}

	public virtual void OnAbort()
	{
		if (!ActAsInitiator)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	public virtual Task OnCloseAsync(TimeSpan timeout)
	{
		if (!ActAsInitiator)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		return Task.CompletedTask;
	}

	public SecurityProtocol CreateSecurityProtocol(EndpointAddress target, Uri via, object listenerSecurityState, bool isReturnLegSecurityRequired, TimeSpan timeout)
	{
		ThrowIfNotOpen();
		SecurityProtocol securityProtocol = OnCreateSecurityProtocol(target, via, listenerSecurityState, timeout);
		if (securityProtocol == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.ProtocolFactoryCouldNotCreateProtocol));
		}
		return securityProtocol;
	}

	public virtual T GetProperty<T>()
	{
		if (typeof(T) == typeof(Collection<ISecurityContextSecurityTokenCache>))
		{
			ThrowIfNotOpen();
			Collection<ISecurityContextSecurityTokenCache> collection = new Collection<ISecurityContextSecurityTokenCache>();
			if (_channelSupportingTokenAuthenticatorSpecification != null)
			{
				foreach (SupportingTokenAuthenticatorSpecification item in _channelSupportingTokenAuthenticatorSpecification)
				{
					if (item.TokenAuthenticator is ISecurityContextSecurityTokenCacheProvider)
					{
						collection.Add(((ISecurityContextSecurityTokenCacheProvider)item.TokenAuthenticator).TokenCache);
					}
				}
			}
			return (T)(object)collection;
		}
		return default(T);
	}

	protected abstract SecurityProtocol OnCreateSecurityProtocol(EndpointAddress target, Uri via, object listenerSecurityState, TimeSpan timeout);

	internal IList<SupportingTokenAuthenticatorSpecification> GetSupportingTokenAuthenticators(string action, out bool expectSignedTokens, out bool expectBasicTokens, out bool expectEndorsingTokens)
	{
		expectSignedTokens = _expectChannelSignedTokens;
		expectBasicTokens = _expectChannelBasicTokens;
		expectEndorsingTokens = _expectChannelEndorsingTokens;
		if (_channelSupportingTokenAuthenticatorSpecification != EmptyTokenAuthenticators)
		{
			return (IList<SupportingTokenAuthenticatorSpecification>)_channelSupportingTokenAuthenticatorSpecification;
		}
		return null;
	}

	public virtual Task OnOpenAsync(TimeSpan timeout)
	{
		if (SecurityBindingElement == null)
		{
			OnPropertySettingsError("SecurityBindingElement", requiredForForwardDirection: true);
		}
		if (SecurityTokenManager == null)
		{
			OnPropertySettingsError("SecurityTokenManager", requiredForForwardDirection: true);
		}
		MessageSecurityVersion = _standardsManager.MessageSecurityVersion;
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		_expectOutgoingMessages = ActAsInitiator || SupportsRequestReply;
		_expectIncomingMessages = !ActAsInitiator || SupportsRequestReply;
		if (!ActAsInitiator)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		if (DetectReplays)
		{
			if (!SupportsReplayDetection)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("DetectReplays", System.SR.Format(System.SR.SecurityProtocolCannotDoReplayDetection, this));
			}
			if (MaxClockSkew == TimeSpan.MaxValue || ReplayWindow == TimeSpan.MaxValue)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.NoncesCachedInfinitely));
			}
			if (_nonceCache == null)
			{
				_nonceCache = new InMemoryNonceCache(ReplayWindow + MaxClockSkew + MaxClockSkew, MaxCachedNonces);
			}
		}
		return Task.CompletedTask;
	}

	public Task OpenAsync(bool actAsInitiator, TimeSpan timeout)
	{
		ActAsInitiator = actAsInitiator;
		return ((IAsyncCommunicationObject)CommunicationObject).OpenAsync(timeout);
	}

	public Task CloseAsync(bool aborted, TimeSpan timeout)
	{
		if (aborted)
		{
			CommunicationObject.Abort();
			return Task.CompletedTask;
		}
		return ((IAsyncCommunicationObject)CommunicationObject).CloseAsync(timeout);
	}

	internal void OnPropertySettingsError(string propertyName, bool requiredForForwardDirection)
	{
		if (requiredForForwardDirection)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.PropertySettingErrorOnProtocolFactory, propertyName, this), propertyName));
		}
		if (_requestReplyErrorPropertyName == null)
		{
			_requestReplyErrorPropertyName = propertyName;
		}
	}

	internal void ThrowIfImmutable()
	{
		CommunicationObject.ThrowIfDisposedOrImmutable();
	}

	private void ThrowIfNotOpen()
	{
		CommunicationObject.ThrowIfNotOpened();
	}
}
