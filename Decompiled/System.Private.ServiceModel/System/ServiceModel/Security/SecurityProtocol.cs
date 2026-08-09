using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace System.ServiceModel.Security;

internal abstract class SecurityProtocol : ISecurityCommunicationObject
{
	private static ReadOnlyCollection<SupportingTokenProviderSpecification> s_emptyTokenProviders;

	private Dictionary<string, Collection<SupportingTokenProviderSpecification>> _mergedSupportingTokenProvidersMap;

	private ChannelParameterCollection _channelParameters;

	protected WrapperSecurityCommunicationObject CommunicationObject { get; }

	public SecurityProtocolFactory SecurityProtocolFactory { get; }

	public EndpointAddress Target { get; }

	public Uri Via { get; }

	public ICollection<SupportingTokenProviderSpecification> ChannelSupportingTokenProviderSpecification { get; private set; }

	public Dictionary<string, ICollection<SupportingTokenProviderSpecification>> ScopedSupportingTokenProviderSpecification { get; private set; }

	private static ReadOnlyCollection<SupportingTokenProviderSpecification> EmptyTokenProviders
	{
		get
		{
			if (s_emptyTokenProviders == null)
			{
				s_emptyTokenProviders = new ReadOnlyCollection<SupportingTokenProviderSpecification>(new List<SupportingTokenProviderSpecification>());
			}
			return s_emptyTokenProviders;
		}
	}

	public ChannelParameterCollection ChannelParameters
	{
		get
		{
			return _channelParameters;
		}
		set
		{
			CommunicationObject.ThrowIfDisposedOrImmutable();
			_channelParameters = value;
		}
	}

	public TimeSpan DefaultOpenTimeout => ServiceDefaults.OpenTimeout;

	public TimeSpan DefaultCloseTimeout => ServiceDefaults.CloseTimeout;

	protected SecurityProtocol(SecurityProtocolFactory factory, EndpointAddress target, Uri via)
	{
		SecurityProtocolFactory = factory;
		Target = target;
		Via = via;
		CommunicationObject = new WrapperSecurityCommunicationObject(this);
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

	internal IList<SupportingTokenProviderSpecification> GetSupportingTokenProviders(string action)
	{
		if (_mergedSupportingTokenProvidersMap != null && _mergedSupportingTokenProvidersMap.Count > 0)
		{
			if (action != null && _mergedSupportingTokenProvidersMap.ContainsKey(action))
			{
				return _mergedSupportingTokenProvidersMap[action];
			}
			if (_mergedSupportingTokenProvidersMap.ContainsKey("*"))
			{
				return _mergedSupportingTokenProvidersMap["*"];
			}
		}
		if (ChannelSupportingTokenProviderSpecification != EmptyTokenProviders)
		{
			return (IList<SupportingTokenProviderSpecification>)ChannelSupportingTokenProviderSpecification;
		}
		return null;
	}

	protected InitiatorServiceModelSecurityTokenRequirement CreateInitiatorSecurityTokenRequirement()
	{
		InitiatorServiceModelSecurityTokenRequirement initiatorServiceModelSecurityTokenRequirement = new InitiatorServiceModelSecurityTokenRequirement();
		initiatorServiceModelSecurityTokenRequirement.TargetAddress = Target;
		initiatorServiceModelSecurityTokenRequirement.Via = Via;
		initiatorServiceModelSecurityTokenRequirement.SecurityBindingElement = SecurityProtocolFactory.SecurityBindingElement;
		initiatorServiceModelSecurityTokenRequirement.SecurityAlgorithmSuite = SecurityProtocolFactory.OutgoingAlgorithmSuite;
		initiatorServiceModelSecurityTokenRequirement.MessageSecurityVersion = SecurityProtocolFactory.MessageSecurityVersion.SecurityTokenVersion;
		if (_channelParameters != null)
		{
			initiatorServiceModelSecurityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.ChannelParametersCollectionProperty] = _channelParameters;
		}
		return initiatorServiceModelSecurityTokenRequirement;
	}

	private InitiatorServiceModelSecurityTokenRequirement CreateInitiatorSecurityTokenRequirement(SecurityTokenParameters parameters, SecurityTokenAttachmentMode attachmentMode)
	{
		InitiatorServiceModelSecurityTokenRequirement initiatorServiceModelSecurityTokenRequirement = CreateInitiatorSecurityTokenRequirement();
		parameters.InitializeSecurityTokenRequirement(initiatorServiceModelSecurityTokenRequirement);
		initiatorServiceModelSecurityTokenRequirement.KeyUsage = SecurityKeyUsage.Signature;
		initiatorServiceModelSecurityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.MessageDirectionProperty] = MessageDirection.Output;
		initiatorServiceModelSecurityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.SupportingTokenAttachmentModeProperty] = attachmentMode;
		return initiatorServiceModelSecurityTokenRequirement;
	}

	private void AddSupportingTokenProviders(SupportingTokenParameters supportingTokenParameters, bool isOptional, IList<SupportingTokenProviderSpecification> providerSpecList)
	{
		for (int i = 0; i < supportingTokenParameters.Endorsing.Count; i++)
		{
			SecurityTokenRequirement securityTokenRequirement = CreateInitiatorSecurityTokenRequirement(supportingTokenParameters.Endorsing[i], SecurityTokenAttachmentMode.Endorsing);
			try
			{
				if (isOptional)
				{
					securityTokenRequirement.IsOptionalToken = true;
				}
				SecurityTokenProvider securityTokenProvider = SecurityProtocolFactory.SecurityTokenManager.CreateSecurityTokenProvider(securityTokenRequirement);
				if (securityTokenProvider != null)
				{
					SupportingTokenProviderSpecification item = new SupportingTokenProviderSpecification(securityTokenProvider, SecurityTokenAttachmentMode.Endorsing, supportingTokenParameters.Endorsing[i]);
					providerSpecList.Add(item);
				}
			}
			catch (Exception exception)
			{
				if (!isOptional || Fx.IsFatal(exception))
				{
					throw;
				}
			}
		}
		for (int j = 0; j < supportingTokenParameters.SignedEndorsing.Count; j++)
		{
			SecurityTokenRequirement securityTokenRequirement2 = CreateInitiatorSecurityTokenRequirement(supportingTokenParameters.SignedEndorsing[j], SecurityTokenAttachmentMode.SignedEndorsing);
			try
			{
				if (isOptional)
				{
					securityTokenRequirement2.IsOptionalToken = true;
				}
				SecurityTokenProvider securityTokenProvider2 = SecurityProtocolFactory.SecurityTokenManager.CreateSecurityTokenProvider(securityTokenRequirement2);
				if (securityTokenProvider2 != null)
				{
					SupportingTokenProviderSpecification item2 = new SupportingTokenProviderSpecification(securityTokenProvider2, SecurityTokenAttachmentMode.SignedEndorsing, supportingTokenParameters.SignedEndorsing[j]);
					providerSpecList.Add(item2);
				}
			}
			catch (Exception exception2)
			{
				if (!isOptional || Fx.IsFatal(exception2))
				{
					throw;
				}
			}
		}
		for (int k = 0; k < supportingTokenParameters.SignedEncrypted.Count; k++)
		{
			SecurityTokenRequirement securityTokenRequirement3 = CreateInitiatorSecurityTokenRequirement(supportingTokenParameters.SignedEncrypted[k], SecurityTokenAttachmentMode.SignedEncrypted);
			try
			{
				if (isOptional)
				{
					securityTokenRequirement3.IsOptionalToken = true;
				}
				SecurityTokenProvider securityTokenProvider3 = SecurityProtocolFactory.SecurityTokenManager.CreateSecurityTokenProvider(securityTokenRequirement3);
				if (securityTokenProvider3 != null)
				{
					SupportingTokenProviderSpecification item3 = new SupportingTokenProviderSpecification(securityTokenProvider3, SecurityTokenAttachmentMode.SignedEncrypted, supportingTokenParameters.SignedEncrypted[k]);
					providerSpecList.Add(item3);
				}
			}
			catch (Exception exception3)
			{
				if (!isOptional || Fx.IsFatal(exception3))
				{
					throw;
				}
			}
		}
		for (int l = 0; l < supportingTokenParameters.Signed.Count; l++)
		{
			SecurityTokenRequirement securityTokenRequirement4 = CreateInitiatorSecurityTokenRequirement(supportingTokenParameters.Signed[l], SecurityTokenAttachmentMode.Signed);
			try
			{
				if (isOptional)
				{
					securityTokenRequirement4.IsOptionalToken = true;
				}
				SecurityTokenProvider securityTokenProvider4 = SecurityProtocolFactory.SecurityTokenManager.CreateSecurityTokenProvider(securityTokenRequirement4);
				if (securityTokenProvider4 != null)
				{
					SupportingTokenProviderSpecification item4 = new SupportingTokenProviderSpecification(securityTokenProvider4, SecurityTokenAttachmentMode.Signed, supportingTokenParameters.Signed[l]);
					providerSpecList.Add(item4);
				}
			}
			catch (Exception exception4)
			{
				if (!isOptional || Fx.IsFatal(exception4))
				{
					throw;
				}
			}
		}
	}

	private async Task MergeSupportingTokenProvidersAsync(TimeSpan timeout)
	{
		if (ScopedSupportingTokenProviderSpecification.Count == 0)
		{
			_mergedSupportingTokenProvidersMap = null;
			return;
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		SecurityProtocolFactory.ExpectSupportingTokens = true;
		_mergedSupportingTokenProvidersMap = new Dictionary<string, Collection<SupportingTokenProviderSpecification>>();
		foreach (string action in ScopedSupportingTokenProviderSpecification.Keys)
		{
			ICollection<SupportingTokenProviderSpecification> collection = ScopedSupportingTokenProviderSpecification[action];
			if (collection == null || collection.Count == 0)
			{
				continue;
			}
			Collection<SupportingTokenProviderSpecification> mergedProviders = new Collection<SupportingTokenProviderSpecification>();
			foreach (SupportingTokenProviderSpecification item in ChannelSupportingTokenProviderSpecification)
			{
				mergedProviders.Add(item);
			}
			foreach (SupportingTokenProviderSpecification spec in collection)
			{
				await SecurityUtils.OpenTokenProviderIfRequiredAsync(spec.TokenProvider, timeoutHelper.RemainingTime());
				if ((spec.SecurityTokenAttachmentMode == SecurityTokenAttachmentMode.Endorsing || spec.SecurityTokenAttachmentMode == SecurityTokenAttachmentMode.SignedEndorsing) && spec.TokenParameters.RequireDerivedKeys && !spec.TokenParameters.HasAsymmetricKey)
				{
					SecurityProtocolFactory.ExpectKeyDerivation = true;
				}
				mergedProviders.Add(spec);
			}
			_mergedSupportingTokenProvidersMap.Add(action, mergedProviders);
		}
	}

	public Task OpenAsync(TimeSpan timeout)
	{
		return ((IAsyncCommunicationObject)CommunicationObject).OpenAsync(timeout);
	}

	public virtual async Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!SecurityProtocolFactory.ActAsInitiator)
		{
			return;
		}
		ChannelSupportingTokenProviderSpecification = new Collection<SupportingTokenProviderSpecification>();
		ScopedSupportingTokenProviderSpecification = new Dictionary<string, ICollection<SupportingTokenProviderSpecification>>();
		AddSupportingTokenProviders(SecurityProtocolFactory.SecurityBindingElement.EndpointSupportingTokenParameters, isOptional: false, (IList<SupportingTokenProviderSpecification>)ChannelSupportingTokenProviderSpecification);
		AddSupportingTokenProviders(SecurityProtocolFactory.SecurityBindingElement.OptionalEndpointSupportingTokenParameters, isOptional: true, (IList<SupportingTokenProviderSpecification>)ChannelSupportingTokenProviderSpecification);
		foreach (string key in SecurityProtocolFactory.SecurityBindingElement.OperationSupportingTokenParameters.Keys)
		{
			Collection<SupportingTokenProviderSpecification> collection = new Collection<SupportingTokenProviderSpecification>();
			AddSupportingTokenProviders(SecurityProtocolFactory.SecurityBindingElement.OperationSupportingTokenParameters[key], isOptional: false, collection);
			ScopedSupportingTokenProviderSpecification.Add(key, collection);
		}
		foreach (string key2 in SecurityProtocolFactory.SecurityBindingElement.OptionalOperationSupportingTokenParameters.Keys)
		{
			Collection<SupportingTokenProviderSpecification> collection2;
			if (ScopedSupportingTokenProviderSpecification.TryGetValue(key2, out var value))
			{
				collection2 = (Collection<SupportingTokenProviderSpecification>)value;
			}
			else
			{
				collection2 = new Collection<SupportingTokenProviderSpecification>();
				ScopedSupportingTokenProviderSpecification.Add(key2, collection2);
			}
			AddSupportingTokenProviders(SecurityProtocolFactory.SecurityBindingElement.OptionalOperationSupportingTokenParameters[key2], isOptional: true, collection2);
		}
		if (!ChannelSupportingTokenProviderSpecification.IsReadOnly)
		{
			if (ChannelSupportingTokenProviderSpecification.Count == 0)
			{
				ChannelSupportingTokenProviderSpecification = EmptyTokenProviders;
			}
			else
			{
				SecurityProtocolFactory.ExpectSupportingTokens = true;
				foreach (SupportingTokenProviderSpecification tokenProviderSpec in ChannelSupportingTokenProviderSpecification)
				{
					await SecurityUtils.OpenTokenProviderIfRequiredAsync(tokenProviderSpec.TokenProvider, timeoutHelper.RemainingTime());
					if ((tokenProviderSpec.SecurityTokenAttachmentMode == SecurityTokenAttachmentMode.Endorsing || tokenProviderSpec.SecurityTokenAttachmentMode == SecurityTokenAttachmentMode.SignedEndorsing) && tokenProviderSpec.TokenParameters.RequireDerivedKeys && !tokenProviderSpec.TokenParameters.HasAsymmetricKey)
					{
						SecurityProtocolFactory.ExpectKeyDerivation = true;
					}
				}
				ChannelSupportingTokenProviderSpecification = new ReadOnlyCollection<SupportingTokenProviderSpecification>((Collection<SupportingTokenProviderSpecification>)ChannelSupportingTokenProviderSpecification);
			}
		}
		await MergeSupportingTokenProvidersAsync(timeoutHelper.RemainingTime());
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

	public virtual void OnAbort()
	{
		if (!SecurityProtocolFactory.ActAsInitiator)
		{
			return;
		}
		foreach (SupportingTokenProviderSpecification item in ChannelSupportingTokenProviderSpecification)
		{
			SecurityUtils.AbortTokenProviderIfRequired(item.TokenProvider);
		}
		foreach (string key in ScopedSupportingTokenProviderSpecification.Keys)
		{
			ICollection<SupportingTokenProviderSpecification> collection = ScopedSupportingTokenProviderSpecification[key];
			foreach (SupportingTokenProviderSpecification item2 in collection)
			{
				SecurityUtils.AbortTokenProviderIfRequired(item2.TokenProvider);
			}
		}
	}

	public virtual async Task OnCloseAsync(TimeSpan timeout)
	{
		if (!SecurityProtocolFactory.ActAsInitiator)
		{
			return;
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		foreach (SupportingTokenProviderSpecification item in ChannelSupportingTokenProviderSpecification)
		{
			await SecurityUtils.CloseTokenProviderIfRequiredAsync(item.TokenProvider, timeoutHelper.RemainingTime());
		}
		foreach (string key in ScopedSupportingTokenProviderSpecification.Keys)
		{
			ICollection<SupportingTokenProviderSpecification> collection = ScopedSupportingTokenProviderSpecification[key];
			foreach (SupportingTokenProviderSpecification item2 in collection)
			{
				await SecurityUtils.CloseTokenProviderIfRequiredAsync(item2.TokenProvider, timeoutHelper.RemainingTime());
			}
		}
	}

	private static void SetSecurityHeaderId(SendSecurityHeader securityHeader, Message message)
	{
		SecurityMessageProperty security = message.Properties.Security;
		if (security != null)
		{
			securityHeader.IdPrefix = security.SenderIdPrefix;
		}
	}

	private void AddSupportingTokenSpecification(SecurityMessageProperty security, IList<SecurityToken> tokens, SecurityTokenAttachmentMode attachmentMode, IDictionary<SecurityToken, ReadOnlyCollection<IAuthorizationPolicy>> tokenPoliciesMapping)
	{
		if (tokens != null && tokens.Count != 0)
		{
			for (int i = 0; i < tokens.Count; i++)
			{
				security.IncomingSupportingTokens.Add(new SupportingTokenSpecification(tokens[i], tokenPoliciesMapping[tokens[i]], attachmentMode));
			}
		}
	}

	protected void AddSupportingTokenSpecification(SecurityMessageProperty security, IList<SecurityToken> basicTokens, IList<SecurityToken> endorsingTokens, IList<SecurityToken> signedEndorsingTokens, IList<SecurityToken> signedTokens, IDictionary<SecurityToken, ReadOnlyCollection<IAuthorizationPolicy>> tokenPoliciesMapping)
	{
		AddSupportingTokenSpecification(security, basicTokens, SecurityTokenAttachmentMode.SignedEncrypted, tokenPoliciesMapping);
		AddSupportingTokenSpecification(security, endorsingTokens, SecurityTokenAttachmentMode.Endorsing, tokenPoliciesMapping);
		AddSupportingTokenSpecification(security, signedEndorsingTokens, SecurityTokenAttachmentMode.SignedEndorsing, tokenPoliciesMapping);
		AddSupportingTokenSpecification(security, signedTokens, SecurityTokenAttachmentMode.Signed, tokenPoliciesMapping);
	}

	protected SendSecurityHeader CreateSendSecurityHeader(Message message, string actor, SecurityProtocolFactory factory)
	{
		return CreateSendSecurityHeader(message, actor, factory, requireMessageProtection: true);
	}

	protected SendSecurityHeader CreateSendSecurityHeaderForTransportProtocol(Message message, string actor, SecurityProtocolFactory factory)
	{
		return CreateSendSecurityHeader(message, actor, factory, requireMessageProtection: false);
	}

	private SendSecurityHeader CreateSendSecurityHeader(Message message, string actor, SecurityProtocolFactory factory, bool requireMessageProtection)
	{
		MessageDirection direction = ((!factory.ActAsInitiator) ? MessageDirection.Output : MessageDirection.Input);
		SendSecurityHeader sendSecurityHeader = factory.StandardsManager.CreateSendSecurityHeader(message, actor, mustUnderstand: true, relay: false, factory.OutgoingAlgorithmSuite, direction);
		sendSecurityHeader.Layout = factory.SecurityHeaderLayout;
		sendSecurityHeader.RequireMessageProtection = requireMessageProtection;
		SetSecurityHeaderId(sendSecurityHeader, message);
		if (factory.AddTimestamp)
		{
			sendSecurityHeader.AddTimestamp(factory.TimestampValidityDuration);
		}
		sendSecurityHeader.StreamBufferManager = factory.StreamBufferManager;
		return sendSecurityHeader;
	}

	internal void AddMessageSupportingTokens(Message message, ref IList<SupportingTokenSpecification> supportingTokens)
	{
		SecurityMessageProperty security = message.Properties.Security;
		if (security == null || !security.HasOutgoingSupportingTokens)
		{
			return;
		}
		if (supportingTokens == null)
		{
			supportingTokens = new Collection<SupportingTokenSpecification>();
		}
		for (int i = 0; i < security.OutgoingSupportingTokens.Count; i++)
		{
			SupportingTokenSpecification supportingTokenSpecification = security.OutgoingSupportingTokens[i];
			if (supportingTokenSpecification.SecurityTokenParameters == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.SenderSideSupportingTokensMustSpecifySecurityTokenParameters));
			}
			supportingTokens.Add(supportingTokenSpecification);
		}
	}

	internal async Task<IList<SupportingTokenSpecification>> TryGetSupportingTokensAsync(SecurityProtocolFactory factory, EndpointAddress target, Uri via, Message message, TimeSpan timeout)
	{
		IList<SupportingTokenSpecification> supportingTokens = null;
		if (!factory.ActAsInitiator)
		{
			return null;
		}
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		IList<SupportingTokenProviderSpecification> supportingTokenProviders = GetSupportingTokenProviders(message.Headers.Action);
		if (supportingTokenProviders != null && supportingTokenProviders.Count > 0)
		{
			supportingTokens = new Collection<SupportingTokenSpecification>();
			int i = 0;
			while (i < supportingTokenProviders.Count)
			{
				SupportingTokenProviderSpecification spec = supportingTokenProviders[i];
				SecurityToken token = await spec.TokenProvider.GetTokenAsync(timeoutHelper.RemainingTime());
				supportingTokens.Add(new SupportingTokenSpecification(token, EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance, spec.SecurityTokenAttachmentMode, spec.TokenParameters));
				int num = i + 1;
				i = num;
			}
		}
		AddMessageSupportingTokens(message, ref supportingTokens);
		return supportingTokens;
	}

	protected ReadOnlyCollection<SecurityTokenResolver> MergeOutOfBandResolvers(IList<SupportingTokenAuthenticatorSpecification> supportingAuthenticators, ReadOnlyCollection<SecurityTokenResolver> primaryResolvers)
	{
		Collection<SecurityTokenResolver> collection = null;
		if (supportingAuthenticators != null && supportingAuthenticators.Count > 0)
		{
			for (int i = 0; i < supportingAuthenticators.Count; i++)
			{
				if (supportingAuthenticators[i].TokenResolver != null)
				{
					collection = collection ?? new Collection<SecurityTokenResolver>();
					collection.Add(supportingAuthenticators[i].TokenResolver);
				}
			}
		}
		if (collection != null)
		{
			if (primaryResolvers != null)
			{
				for (int j = 0; j < primaryResolvers.Count; j++)
				{
					collection.Insert(0, primaryResolvers[j]);
				}
			}
			return new ReadOnlyCollection<SecurityTokenResolver>(collection);
		}
		return primaryResolvers ?? EmptyReadOnlyCollection<SecurityTokenResolver>.Instance;
	}

	protected void AddSupportingTokens(SendSecurityHeader securityHeader, IList<SupportingTokenSpecification> supportingTokens)
	{
		if (supportingTokens == null)
		{
			return;
		}
		for (int i = 0; i < supportingTokens.Count; i++)
		{
			SecurityToken securityToken = supportingTokens[i].SecurityToken;
			SecurityTokenParameters securityTokenParameters = supportingTokens[i].SecurityTokenParameters;
			switch (supportingTokens[i].SecurityTokenAttachmentMode)
			{
			case SecurityTokenAttachmentMode.Signed:
				securityHeader.AddSignedSupportingToken(securityToken, securityTokenParameters);
				break;
			case SecurityTokenAttachmentMode.Endorsing:
				securityHeader.AddEndorsingSupportingToken(securityToken, securityTokenParameters);
				break;
			case SecurityTokenAttachmentMode.SignedEncrypted:
				securityHeader.AddBasicSupportingToken(securityToken, securityTokenParameters);
				break;
			case SecurityTokenAttachmentMode.SignedEndorsing:
				securityHeader.AddSignedEndorsingSupportingToken(securityToken, securityTokenParameters);
				break;
			default:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnknownTokenAttachmentMode, supportingTokens[i].SecurityTokenAttachmentMode.ToString())));
			}
		}
	}

	internal static async Task<SecurityToken> GetTokenAsync(SecurityTokenProvider provider, EndpointAddress target, TimeSpan timeout)
	{
		if (provider == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.TokenProviderCannotGetTokensForTarget, target)));
		}
		try
		{
			return await provider.GetTokenAsync(timeout);
		}
		catch (SecurityTokenException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.TokenProviderCannotGetTokensForTarget, target), innerException));
		}
		catch (SecurityNegotiationException innerException2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.TokenProviderCannotGetTokensForTarget, target), innerException2));
		}
	}

	public abstract Task<Message> SecureOutgoingMessageAsync(Message message, TimeSpan timeout);

	public virtual async Task<(SecurityProtocolCorrelationState, Message)> SecureOutgoingMessageAsync(Message message, TimeSpan timeout, SecurityProtocolCorrelationState correlationState)
	{
		return (null, await SecureOutgoingMessageAsync(message, timeout));
	}

	protected virtual void OnOutgoingMessageSecured(Message securedMessage)
	{
	}

	protected virtual void OnSecureOutgoingMessageFailure(Message message)
	{
	}

	public abstract void VerifyIncomingMessage(ref Message message, TimeSpan timeout);

	public virtual SecurityProtocolCorrelationState VerifyIncomingMessage(ref Message message, TimeSpan timeout, params SecurityProtocolCorrelationState[] correlationStates)
	{
		VerifyIncomingMessage(ref message, timeout);
		return null;
	}

	protected virtual void OnIncomingMessageVerified(Message verifiedMessage)
	{
	}

	protected virtual void OnVerifyIncomingMessageFailure(Message message, Exception exception)
	{
	}
}
