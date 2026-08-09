using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Runtime;
using System.Security;
using System.Security.Cryptography;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Security;

internal abstract class IssuanceTokenProviderBase<T> : CommunicationObjectSecurityTokenProvider where T : IssuanceTokenProviderState
{
	internal const string defaultClientMaxTokenCachingTimeString = "10675199.02:48:05.4775807";

	internal const bool defaultClientCacheTokens = true;

	internal const int defaultServiceTokenValidityThresholdPercentage = 60;

	private EndpointAddress _issuerAddress;

	private EndpointAddress _targetAddress;

	private Uri _via;

	private bool _cacheServiceTokens = true;

	private int _serviceTokenValidityThresholdPercentage = 60;

	private TimeSpan _maxServiceTokenCachingTime;

	private SecurityStandardsManager _standardsManager;

	private SecurityAlgorithmSuite _algorithmSuite;

	private ChannelProtectionRequirements _applicationProtectionRequirements;

	private SecurityToken _cachedToken;

	private string _sctUri;

	public EndpointAddress IssuerAddress
	{
		get
		{
			return _issuerAddress;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_issuerAddress = value;
		}
	}

	public EndpointAddress TargetAddress
	{
		get
		{
			return _targetAddress;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_targetAddress = value;
		}
	}

	public bool CacheServiceTokens
	{
		get
		{
			return _cacheServiceTokens;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_cacheServiceTokens = value;
		}
	}

	internal static TimeSpan DefaultClientMaxTokenCachingTime => TimeSpan.MaxValue;

	public int ServiceTokenValidityThresholdPercentage
	{
		get
		{
			return _serviceTokenValidityThresholdPercentage;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			if (value <= 0 || value > 100)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.Format(System.SR.ValueMustBeInRange, 1, 100)));
			}
			_serviceTokenValidityThresholdPercentage = value;
		}
	}

	public SecurityAlgorithmSuite SecurityAlgorithmSuite
	{
		get
		{
			return _algorithmSuite;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_algorithmSuite = value;
		}
	}

	public TimeSpan MaxServiceTokenCachingTime
	{
		get
		{
			return _maxServiceTokenCachingTime;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			if (value <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.TimeSpanMustbeGreaterThanTimeSpanZero));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_maxServiceTokenCachingTime = value;
		}
	}

	public SecurityStandardsManager StandardsManager
	{
		get
		{
			if (_standardsManager == null)
			{
				return SecurityStandardsManager.DefaultInstance;
			}
			return _standardsManager;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_standardsManager = value;
		}
	}

	public ChannelProtectionRequirements ApplicationProtectionRequirements
	{
		get
		{
			return _applicationProtectionRequirements;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_applicationProtectionRequirements = value;
		}
	}

	public Uri Via
	{
		get
		{
			return _via;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_via = value;
		}
	}

	public override bool SupportsTokenCancellation => true;

	protected object ThisLock { get; } = new object();

	protected virtual bool IsMultiLegNegotiation => true;

	protected abstract MessageVersion MessageVersion { get; }

	protected abstract bool RequiresManualReplyAddressing { get; }

	public abstract XmlDictionaryString RequestSecurityTokenAction { get; }

	public abstract XmlDictionaryString RequestSecurityTokenResponseAction { get; }

	protected string SecurityContextTokenUri
	{
		get
		{
			ThrowIfCreated();
			return _sctUri;
		}
	}

	protected IssuanceTokenProviderBase()
	{
		_cacheServiceTokens = true;
		_serviceTokenValidityThresholdPercentage = 60;
		_maxServiceTokenCachingTime = DefaultClientMaxTokenCachingTime;
		_standardsManager = null;
	}

	protected void ThrowIfCreated()
	{
		CommunicationState state = base.CommunicationObject.State;
		if (state == CommunicationState.Created)
		{
			Exception exception = new InvalidOperationException(System.SR.Format(System.SR.CommunicationObjectCannotBeUsed, GetType().ToString(), state.ToString()));
			throw TraceUtility.ThrowHelperError(exception, Guid.Empty, this);
		}
	}

	protected void ThrowIfClosedOrCreated()
	{
		base.CommunicationObject.ThrowIfClosed();
		ThrowIfCreated();
	}

	public override Task OnOpenAsync(TimeSpan timeout)
	{
		if (_targetAddress == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TargetAddressIsNotSet, GetType())));
		}
		if (SecurityAlgorithmSuite == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SecurityAlgorithmSuiteNotSet, GetType())));
		}
		_sctUri = StandardsManager.SecureConversationDriver.TokenTypeUri;
		return Task.CompletedTask;
	}

	protected void EnsureEndpointAddressDoesNotRequireEncryption(EndpointAddress target)
	{
		if (ApplicationProtectionRequirements == null || ApplicationProtectionRequirements.OutgoingEncryptionParts == null)
		{
			return;
		}
		MessagePartSpecification channelParts = ApplicationProtectionRequirements.OutgoingEncryptionParts.ChannelParts;
		if (channelParts == null)
		{
			return;
		}
		for (int i = 0; i < _targetAddress.Headers.Count; i++)
		{
			AddressHeader addressHeader = target.Headers[i];
			if (channelParts.IsHeaderIncluded(addressHeader.Name, addressHeader.Namespace))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.SecurityNegotiationCannotProtectConfidentialEndpointHeader, target, addressHeader.Name, addressHeader.Namespace)));
			}
		}
	}

	private DateTime GetServiceTokenEffectiveExpirationTime(SecurityToken serviceToken)
	{
		if (serviceToken.ValidTo.ToUniversalTime() >= SecurityUtils.MaxUtcDateTime)
		{
			return serviceToken.ValidTo;
		}
		long ticks = (serviceToken.ValidTo.ToUniversalTime() - serviceToken.ValidFrom.ToUniversalTime()).Ticks;
		long ticks2 = Convert.ToInt64((double)ServiceTokenValidityThresholdPercentage / 100.0 * (double)ticks, NumberFormatInfo.InvariantInfo);
		DateTime dateTime = TimeoutHelper.Add(serviceToken.ValidFrom.ToUniversalTime(), new TimeSpan(ticks2));
		DateTime dateTime2 = TimeoutHelper.Add(serviceToken.ValidFrom.ToUniversalTime(), MaxServiceTokenCachingTime);
		if (dateTime <= dateTime2)
		{
			return dateTime;
		}
		return dateTime2;
	}

	private bool IsServiceTokenTimeValid(SecurityToken serviceToken)
	{
		DateTime serviceTokenEffectiveExpirationTime = GetServiceTokenEffectiveExpirationTime(serviceToken);
		return DateTime.UtcNow <= serviceTokenEffectiveExpirationTime;
	}

	private SecurityToken GetCurrentServiceToken()
	{
		if (CacheServiceTokens && _cachedToken != null && IsServiceTokenTimeValid(_cachedToken))
		{
			return _cachedToken;
		}
		return null;
	}

	protected static void ThrowIfFault(Message message, EndpointAddress target)
	{
		SecurityUtils.ThrowIfNegotiationFault(message, target);
	}

	protected override SecurityToken GetTokenCore(TimeSpan timeout)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		SecurityToken currentServiceToken;
		lock (ThisLock)
		{
			currentServiceToken = GetCurrentServiceToken();
		}
		if (currentServiceToken == null)
		{
			return DoNegotiationAsync(timeout).GetAwaiter().GetResult();
		}
		return currentServiceToken;
	}

	internal override Task<SecurityToken> GetTokenCoreInternalAsync(TimeSpan timeout)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		SecurityToken currentServiceToken;
		lock (ThisLock)
		{
			currentServiceToken = GetCurrentServiceToken();
		}
		if (currentServiceToken == null)
		{
			return DoNegotiationAsync(timeout);
		}
		return Task.FromResult(currentServiceToken);
	}

	internal override Task CancelTokenCoreInternalAsync(TimeSpan timeout, SecurityToken token)
	{
		if (CacheServiceTokens)
		{
			lock (ThisLock)
			{
				if (token == _cachedToken)
				{
					_cachedToken = null;
				}
			}
		}
		return Task.CompletedTask;
	}

	protected abstract Task<T> CreateNegotiationStateAsync(EndpointAddress target, Uri via, TimeSpan timeout);

	protected abstract BodyWriter GetFirstOutgoingMessageBody(T negotiationState, out MessageProperties properties);

	protected abstract BodyWriter GetNextOutgoingMessageBody(Message incomingMessage, T negotiationState);

	protected abstract Task InitializeChannelFactoriesAsync(EndpointAddress target, TimeSpan timeout);

	protected abstract IAsyncRequestChannel CreateClientChannel(EndpointAddress target, Uri via);

	private void PrepareRequest(Message nextMessage)
	{
		PrepareRequest(nextMessage, null);
	}

	private void PrepareRequest(Message nextMessage, RequestSecurityToken rst)
	{
		if (rst != null && !rst.IsReadOnly)
		{
			rst.Message = nextMessage;
		}
		RequestReplyCorrelator.PrepareRequest(nextMessage);
		if (RequiresManualReplyAddressing)
		{
			nextMessage.Headers.ReplyTo = EndpointAddress.AnonymousAddress;
		}
	}

	protected async Task<SecurityToken> DoNegotiationAsync(TimeSpan timeout)
	{
		ThrowIfClosedOrCreated();
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		IAsyncRequestChannel rstChannel = null;
		T negotiationState = null;
		TimeSpan timeLeft = timeout;
		int legs = 1;
		try
		{
			negotiationState = await CreateNegotiationStateAsync(_targetAddress, _via, timeoutHelper.RemainingTime());
			InitializeNegotiationState(negotiationState);
			await InitializeChannelFactoriesAsync(negotiationState.RemoteAddress, timeoutHelper.RemainingTime());
			rstChannel = CreateClientChannel(negotiationState.RemoteAddress, _via);
			await rstChannel.OpenAsync(timeoutHelper.RemainingTime());
			Message message = null;
			while (true)
			{
				Message nextOutgoingMessage = GetNextOutgoingMessage(message, negotiationState);
				message?.Close();
				if (nextOutgoingMessage == null)
				{
					break;
				}
				using (nextOutgoingMessage)
				{
					timeLeft = timeoutHelper.RemainingTime();
					message = await rstChannel.RequestAsync(nextOutgoingMessage, timeLeft);
					if (message == null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.FailToReceiveReplyFromNegotiation));
					}
				}
				legs += 2;
			}
			if (!negotiationState.IsNegotiationCompleted)
			{
				throw TraceUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.NoNegotiationMessageToSend), message);
			}
			try
			{
				rstChannel.Close(timeoutHelper.RemainingTime());
			}
			catch (CommunicationException)
			{
				rstChannel.Abort();
			}
			catch (TimeoutException)
			{
				rstChannel.Abort();
			}
			rstChannel = null;
			ValidateAndCacheServiceToken(negotiationState);
			return negotiationState.ServiceToken;
		}
		catch (Exception ex3)
		{
			if (Fx.IsFatal(ex3))
			{
				throw;
			}
			if (ex3 is TimeoutException)
			{
				ex3 = new TimeoutException(System.SR.Format(System.SR.ClientSecurityNegotiationTimeout, timeout, legs, timeLeft), ex3);
			}
			EndpointAddress targetAddress = negotiationState?.RemoteAddress;
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WrapExceptionIfRequired(ex3, targetAddress, _issuerAddress));
		}
		finally
		{
			Cleanup(rstChannel, negotiationState);
		}
	}

	private void InitializeNegotiationState(T negotiationState)
	{
		negotiationState.TargetAddress = _targetAddress;
		if (negotiationState.Context == null && IsMultiLegNegotiation)
		{
			negotiationState.Context = SecurityUtils.GenerateId();
		}
		if (IssuerAddress != null)
		{
			negotiationState.RemoteAddress = IssuerAddress;
		}
		else
		{
			negotiationState.RemoteAddress = negotiationState.TargetAddress;
		}
	}

	private Message GetNextOutgoingMessage(Message incomingMessage, T negotiationState)
	{
		MessageProperties properties = null;
		BodyWriter bodyWriter = ((incomingMessage != null) ? GetNextOutgoingMessageBody(incomingMessage, negotiationState) : GetFirstOutgoingMessageBody(negotiationState, out properties));
		if (bodyWriter != null)
		{
			Message message = ((incomingMessage != null) ? Message.CreateMessage(MessageVersion, ActionHeader.Create(RequestSecurityTokenResponseAction, MessageVersion.Addressing), bodyWriter) : Message.CreateMessage(MessageVersion, ActionHeader.Create(RequestSecurityTokenAction, MessageVersion.Addressing), bodyWriter));
			if (properties != null)
			{
				message.Properties.CopyProperties(properties);
			}
			PrepareRequest(message, bodyWriter as RequestSecurityToken);
			return message;
		}
		return null;
	}

	private void Cleanup(IChannel rstChannel, T negotiationState)
	{
		negotiationState?.Dispose();
		rstChannel?.Abort();
	}

	protected virtual void ValidateKeySize(GenericXmlSecurityToken issuedToken)
	{
		if (SecurityAlgorithmSuite != null)
		{
			ReadOnlyCollection<SecurityKey> securityKeys = issuedToken.SecurityKeys;
			if (securityKeys == null || securityKeys.Count != 1)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.CannotObtainIssuedTokenKeySize)));
			}
			if (securityKeys[0] is SymmetricSecurityKey symmetricSecurityKey && !SecurityAlgorithmSuite.IsSymmetricKeyLengthSupported(symmetricSecurityKey.KeySize))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.InvalidIssuedTokenKeySize, symmetricSecurityKey.KeySize)));
			}
		}
	}

	private static bool ShouldWrapException(Exception e)
	{
		if (!(e is Win32Exception) && !(e is XmlException) && !(e is InvalidOperationException) && !(e is ArgumentException) && !(e is QuotaExceededException) && !(e is SecurityException) && !(e is CryptographicException))
		{
			return e is SecurityTokenException;
		}
		return true;
	}

	private static Exception WrapExceptionIfRequired(Exception e, EndpointAddress targetAddress, EndpointAddress issuerAddress)
	{
		if (ShouldWrapException(e))
		{
			Uri uri = ((!(targetAddress != null)) ? null : targetAddress.Uri);
			Uri p = ((!(issuerAddress != null)) ? uri : issuerAddress.Uri);
			e = ((!(uri != null)) ? new SecurityNegotiationException(System.SR.SoapSecurityNegotiationFailed, e) : new SecurityNegotiationException(System.SR.Format(System.SR.SoapSecurityNegotiationFailedForIssuerAndTarget, p, uri), e));
		}
		return e;
	}

	private void ValidateAndCacheServiceToken(T negotiationState)
	{
		ValidateKeySize(negotiationState.ServiceToken);
		lock (ThisLock)
		{
			if (CacheServiceTokens)
			{
				_cachedToken = negotiationState.ServiceToken;
			}
		}
	}
}
