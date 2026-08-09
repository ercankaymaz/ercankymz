using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime;
using System.Security.Authentication.ExtendedProtection;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal abstract class ReceiveSecurityHeader : SecurityHeader
{
	private struct OrderTracker
	{
		private enum ReceiverProcessingOrder
		{
			None,
			Verify,
			Decrypt,
			DecryptVerify,
			VerifyDecrypt,
			Mixed
		}

		private static readonly ReceiverProcessingOrder[] s_stateTransitionTableOnDecrypt = new ReceiverProcessingOrder[6]
		{
			ReceiverProcessingOrder.Decrypt,
			ReceiverProcessingOrder.VerifyDecrypt,
			ReceiverProcessingOrder.Decrypt,
			ReceiverProcessingOrder.Mixed,
			ReceiverProcessingOrder.VerifyDecrypt,
			ReceiverProcessingOrder.Mixed
		};

		private static readonly ReceiverProcessingOrder[] s_stateTransitionTableOnVerify = new ReceiverProcessingOrder[6]
		{
			ReceiverProcessingOrder.Verify,
			ReceiverProcessingOrder.Verify,
			ReceiverProcessingOrder.DecryptVerify,
			ReceiverProcessingOrder.DecryptVerify,
			ReceiverProcessingOrder.Mixed,
			ReceiverProcessingOrder.Mixed
		};

		private const int MaxAllowedWrappedKeys = 1;

		private int _referenceListCount;

		private ReceiverProcessingOrder _state;

		private int _signatureCount;

		private int _unencryptedSignatureCount;

		private MessageProtectionOrder _protectionOrder;

		private bool _enforce;

		public bool AllSignaturesEncrypted => _unencryptedSignatureCount == 0;

		public bool EncryptBeforeSignMode
		{
			get
			{
				if (_enforce)
				{
					return _protectionOrder == MessageProtectionOrder.EncryptBeforeSign;
				}
				return false;
			}
		}

		public bool EncryptBeforeSignOrderRequirementMet
		{
			get
			{
				if (_state != ReceiverProcessingOrder.DecryptVerify)
				{
					return _state != ReceiverProcessingOrder.Mixed;
				}
				return false;
			}
		}

		public bool PrimarySignatureDone => _signatureCount > 0;

		public bool SignBeforeEncryptOrderRequirementMet
		{
			get
			{
				if (_state != ReceiverProcessingOrder.VerifyDecrypt)
				{
					return _state != ReceiverProcessingOrder.Mixed;
				}
				return false;
			}
		}

		private void EnforceProtectionOrder()
		{
			switch (_protectionOrder)
			{
			case MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature:
				throw ExceptionHelper.PlatformNotSupported();
			case MessageProtectionOrder.SignBeforeEncrypt:
				if (!SignBeforeEncryptOrderRequirementMet)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.MessageProtectionOrderMismatch, _protectionOrder)));
				}
				break;
			case MessageProtectionOrder.EncryptBeforeSign:
				throw ExceptionHelper.PlatformNotSupported();
			}
		}

		public void OnProcessReferenceList()
		{
			if (_referenceListCount > 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.AtMostOneReferenceListIsSupportedWithDefaultPolicyCheck));
			}
			_referenceListCount++;
			_state = s_stateTransitionTableOnDecrypt[(int)_state];
			if (_enforce)
			{
				EnforceProtectionOrder();
			}
		}

		public void SetRequiredProtectionOrder(MessageProtectionOrder protectionOrder)
		{
			_protectionOrder = protectionOrder;
			_enforce = true;
		}
	}

	private struct OperationTracker
	{
		private bool _isDerivedToken;

		public MessagePartSpecification Parts { get; set; }

		public SecurityToken Token { get; private set; }

		public bool IsDerivedToken => _isDerivedToken;

		public void RecordToken(SecurityToken token)
		{
			if (Token == null)
			{
				Token = token;
			}
			else if (Token != token)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.MismatchInSecurityOperationToken));
			}
		}

		public void SetDerivationSourceIfRequired()
		{
			if (Token is DerivedKeySecurityToken derivedKeySecurityToken)
			{
				Token = derivedKeySecurityToken.TokenToDerive;
				_isDerivedToken = true;
			}
		}
	}

	private SecurityTokenAuthenticator _primaryTokenAuthenticator;

	private bool _allowFirstTokenMismatch;

	private SecurityToken _outOfBandPrimaryToken;

	private IList<SecurityToken> _outOfBandPrimaryTokenCollection;

	private SecurityTokenParameters _primaryTokenParameters;

	private TokenTracker _primaryTokenTracker;

	private SecurityToken _wrappingToken;

	private SecurityTokenParameters _wrappingTokenParameters;

	private SecurityTokenAuthenticator _derivedTokenAuthenticator;

	private IList<SupportingTokenAuthenticatorSpecification> _supportingTokenAuthenticators;

	private ChannelBinding _channelBinding;

	private ExtendedProtectionPolicy _extendedProtectionPolicy;

	private bool _expectBasicTokens;

	private bool _expectSignedTokens;

	private bool _expectEndorsingTokens;

	private bool _expectSignatureConfirmation;

	private List<TokenTracker> _supportingTokenTrackers;

	private List<SecurityTokenAuthenticator> _allowedAuthenticators;

	private SecurityTokenAuthenticator _pendingSupportingTokenAuthenticator;

	private Collection<SecurityToken> _signedEndorsingTokens;

	private Dictionary<SecurityToken, ReadOnlyCollection<IAuthorizationPolicy>> _tokenPoliciesMapping;

	private SecurityTimestamp _timestamp;

	private SecurityHeaderTokenResolver _universalTokenResolver;

	private SecurityHeaderTokenResolver _primaryTokenResolver;

	private ReadOnlyCollection<SecurityTokenResolver> _outOfBandTokenResolver;

	private SecurityTokenResolver _combinedPrimaryTokenResolver;

	private XmlAttributeHolder[] _securityElementAttributes;

	private OrderTracker _orderTracker;

	private OperationTracker _signatureTracker;

	private OperationTracker _encryptionTracker;

	private int _maxDerivedKeys;

	private int _numDerivedKeys;

	private bool _enforceDerivedKeyRequirement = true;

	private NonceCache _nonceCache;

	private TimeSpan _replayWindow;

	private TimeSpan _clockSkew;

	private TimeoutHelper _timeoutHelper;

	private long _maxReceivedMessageSize = 65536L;

	private XmlDictionaryReaderQuotas _readerQuotas;

	private MessageProtectionOrder _protectionOrder;

	private bool _hasEndorsingOrSignedEndorsingSupportingTokens;

	private SignatureResourcePool _resourcePool;

	private bool _replayDetectionEnabled;

	private const int AppendPosition = -1;

	public Collection<SecurityToken> BasicSupportingTokens { get; }

	public Collection<SecurityToken> SignedSupportingTokens { get; }

	public Collection<SecurityToken> EndorsingSupportingTokens { get; }

	public Collection<SecurityToken> SignedEndorsingSupportingTokens => _signedEndorsingTokens;

	public bool EnforceDerivedKeyRequirement
	{
		get
		{
			return _enforceDerivedKeyRequirement;
		}
		set
		{
			ThrowIfProcessingStarted();
			_enforceDerivedKeyRequirement = value;
		}
	}

	public byte[] PrimarySignatureValue { get; }

	public SecurityToken EncryptionToken => _encryptionTracker.Token;

	public bool ExpectBasicTokens
	{
		get
		{
			return _expectBasicTokens;
		}
		set
		{
			ThrowIfProcessingStarted();
			_expectBasicTokens = value;
		}
	}

	public ReceiveSecurityHeaderElementManager ElementManager { get; }

	public SecurityTokenAuthenticator DerivedTokenAuthenticator
	{
		get
		{
			return _derivedTokenAuthenticator;
		}
		set
		{
			ThrowIfProcessingStarted();
			_derivedTokenAuthenticator = value;
		}
	}

	public bool ReplayDetectionEnabled
	{
		get
		{
			return _replayDetectionEnabled;
		}
		set
		{
			ThrowIfProcessingStarted();
			_replayDetectionEnabled = value;
		}
	}

	public bool ExpectSignatureConfirmation
	{
		get
		{
			return _expectSignatureConfirmation;
		}
		set
		{
			ThrowIfProcessingStarted();
			_expectSignatureConfirmation = value;
		}
	}

	public bool ExpectSignedTokens
	{
		get
		{
			return _expectSignedTokens;
		}
		set
		{
			ThrowIfProcessingStarted();
			_expectSignedTokens = value;
		}
	}

	public bool ExpectEndorsingTokens
	{
		get
		{
			return _expectEndorsingTokens;
		}
		set
		{
			ThrowIfProcessingStarted();
			_expectEndorsingTokens = value;
		}
	}

	public SecurityTokenResolver CombinedUniversalTokenResolver { get; private set; }

	internal int HeaderIndex { get; }

	internal long MaxReceivedMessageSize
	{
		get
		{
			return _maxReceivedMessageSize;
		}
		set
		{
			ThrowIfProcessingStarted();
			_maxReceivedMessageSize = value;
		}
	}

	internal XmlDictionaryReaderQuotas ReaderQuotas
	{
		get
		{
			return _readerQuotas;
		}
		set
		{
			ThrowIfProcessingStarted();
			_readerQuotas = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	public override string Name => base.StandardsManager.SecurityVersion.HeaderName.Value;

	public override string Namespace => base.StandardsManager.SecurityVersion.HeaderNamespace.Value;

	public Message ProcessedMessage => base.Message;

	protected SignatureResourcePool ResourcePool
	{
		get
		{
			if (_resourcePool == null)
			{
				_resourcePool = new SignatureResourcePool();
			}
			return _resourcePool;
		}
	}

	internal SecurityVerifiedMessage SecurityVerifiedMessage { get; private set; }

	public SecurityToken SignatureToken => _signatureTracker.Token;

	public Dictionary<SecurityToken, ReadOnlyCollection<IAuthorizationPolicy>> SecurityTokenAuthorizationPoliciesMapping
	{
		get
		{
			if (_tokenPoliciesMapping == null)
			{
				_tokenPoliciesMapping = new Dictionary<SecurityToken, ReadOnlyCollection<IAuthorizationPolicy>>();
			}
			return _tokenPoliciesMapping;
		}
	}

	public int MaxDerivedKeyLength { get; private set; }

	protected ReceiveSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, int headerIndex, MessageDirection direction)
		: base(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, direction)
	{
		HeaderIndex = headerIndex;
		ElementManager = new ReceiveSecurityHeaderElementManager(this);
	}

	internal XmlDictionaryReader CreateSecurityHeaderReader()
	{
		return SecurityVerifiedMessage.GetReaderAtSecurityHeader();
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		XmlDictionaryReader readerAtSecurityHeader = GetReaderAtSecurityHeader();
		readerAtSecurityHeader.ReadStartElement();
		for (int i = 0; i < ElementManager.Count; i++)
		{
			ElementManager.GetElementEntry(i, out var element);
			XmlDictionaryReader xmlDictionaryReader = null;
			if (element._encrypted)
			{
				xmlDictionaryReader = ElementManager.GetReader(i, requiresEncryptedFormReader: false);
				writer.WriteNode(xmlDictionaryReader, defattr: false);
				xmlDictionaryReader.Close();
				readerAtSecurityHeader.Skip();
			}
			else
			{
				writer.WriteNode(readerAtSecurityHeader, defattr: false);
			}
		}
		readerAtSecurityHeader.Close();
	}

	private XmlDictionaryReader GetReaderAtSecurityHeader()
	{
		XmlDictionaryReader readerAtFirstHeader = SecurityVerifiedMessage.GetReaderAtFirstHeader();
		for (int i = 0; i < HeaderIndex; i++)
		{
			readerAtFirstHeader.Skip();
		}
		return readerAtFirstHeader;
	}

	public void SetTimeParameters(NonceCache nonceCache, TimeSpan replayWindow, TimeSpan clockSkew)
	{
		_nonceCache = nonceCache;
		_replayWindow = replayWindow;
		_clockSkew = clockSkew;
	}

	public void Process(TimeSpan timeout, ChannelBinding channelBinding, ExtendedProtectionPolicy extendedProtectionPolicy)
	{
		MessageProtectionOrder protectionOrder = _protectionOrder;
		bool flag = false;
		if (_protectionOrder == MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		_channelBinding = channelBinding;
		_extendedProtectionPolicy = extendedProtectionPolicy;
		_orderTracker.SetRequiredProtectionOrder(protectionOrder);
		SetProcessingStarted();
		_timeoutHelper = new TimeoutHelper(timeout);
		SecurityVerifiedMessage message = (SecurityVerifiedMessage = new SecurityVerifiedMessage(base.Message, this));
		base.Message = message;
		XmlDictionaryReader xmlDictionaryReader = CreateSecurityHeaderReader();
		xmlDictionaryReader.MoveToStartElement();
		if (xmlDictionaryReader.IsEmptyElement)
		{
			throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.SecurityHeaderIsEmpty), base.Message);
		}
		if (base.RequireMessageProtection)
		{
			_securityElementAttributes = XmlAttributeHolder.ReadAttributes(xmlDictionaryReader);
		}
		else
		{
			_securityElementAttributes = XmlAttributeHolder.emptyArray;
		}
		xmlDictionaryReader.ReadStartElement();
		if (_primaryTokenParameters != null)
		{
			_primaryTokenTracker = new TokenTracker(null, _outOfBandPrimaryToken, _allowFirstTokenMismatch);
		}
		_universalTokenResolver = new SecurityHeaderTokenResolver(this);
		_primaryTokenResolver = new SecurityHeaderTokenResolver(this);
		if (_outOfBandPrimaryToken != null)
		{
			_universalTokenResolver.Add(_outOfBandPrimaryToken, SecurityTokenReferenceStyle.External, _primaryTokenParameters);
			_primaryTokenResolver.Add(_outOfBandPrimaryToken, SecurityTokenReferenceStyle.External, _primaryTokenParameters);
		}
		else if (_outOfBandPrimaryTokenCollection != null)
		{
			for (int i = 0; i < _outOfBandPrimaryTokenCollection.Count; i++)
			{
				_universalTokenResolver.Add(_outOfBandPrimaryTokenCollection[i], SecurityTokenReferenceStyle.External, _primaryTokenParameters);
				_primaryTokenResolver.Add(_outOfBandPrimaryTokenCollection[i], SecurityTokenReferenceStyle.External, _primaryTokenParameters);
			}
		}
		if (_wrappingToken != null)
		{
			_universalTokenResolver.ExpectedWrapper = _wrappingToken;
			_universalTokenResolver.ExpectedWrapperTokenParameters = _wrappingTokenParameters;
			_primaryTokenResolver.ExpectedWrapper = _wrappingToken;
			_primaryTokenResolver.ExpectedWrapperTokenParameters = _wrappingTokenParameters;
		}
		if (_outOfBandTokenResolver == null)
		{
			CombinedUniversalTokenResolver = _universalTokenResolver;
			_combinedPrimaryTokenResolver = _primaryTokenResolver;
		}
		else
		{
			CombinedUniversalTokenResolver = new AggregateSecurityHeaderTokenResolver(_universalTokenResolver, _outOfBandTokenResolver);
			_combinedPrimaryTokenResolver = new AggregateSecurityHeaderTokenResolver(_primaryTokenResolver, _outOfBandTokenResolver);
		}
		_allowedAuthenticators = new List<SecurityTokenAuthenticator>();
		if (_primaryTokenAuthenticator != null)
		{
			_allowedAuthenticators.Add(_primaryTokenAuthenticator);
		}
		if (DerivedTokenAuthenticator != null)
		{
			_allowedAuthenticators.Add(DerivedTokenAuthenticator);
		}
		_pendingSupportingTokenAuthenticator = null;
		int num = 0;
		if (_supportingTokenAuthenticators != null && _supportingTokenAuthenticators.Count > 0)
		{
			_supportingTokenTrackers = new List<TokenTracker>(_supportingTokenAuthenticators.Count);
			for (int j = 0; j < _supportingTokenAuthenticators.Count; j++)
			{
				SupportingTokenAuthenticatorSpecification supportingTokenAuthenticatorSpecification = _supportingTokenAuthenticators[j];
				switch (supportingTokenAuthenticatorSpecification.SecurityTokenAttachmentMode)
				{
				case SecurityTokenAttachmentMode.Endorsing:
					_hasEndorsingOrSignedEndorsingSupportingTokens = true;
					break;
				case SecurityTokenAttachmentMode.SignedEndorsing:
					_hasEndorsingOrSignedEndorsingSupportingTokens = true;
					break;
				}
				if (_primaryTokenAuthenticator != null && _primaryTokenAuthenticator.GetType().Equals(supportingTokenAuthenticatorSpecification.TokenAuthenticator.GetType()))
				{
					_pendingSupportingTokenAuthenticator = supportingTokenAuthenticatorSpecification.TokenAuthenticator;
				}
				else
				{
					_allowedAuthenticators.Add(supportingTokenAuthenticatorSpecification.TokenAuthenticator);
				}
				if (supportingTokenAuthenticatorSpecification.TokenParameters.RequireDerivedKeys && !supportingTokenAuthenticatorSpecification.TokenParameters.HasAsymmetricKey && (supportingTokenAuthenticatorSpecification.SecurityTokenAttachmentMode == SecurityTokenAttachmentMode.Endorsing || supportingTokenAuthenticatorSpecification.SecurityTokenAttachmentMode == SecurityTokenAttachmentMode.SignedEndorsing))
				{
					num++;
				}
				_supportingTokenTrackers.Add(new TokenTracker(supportingTokenAuthenticatorSpecification));
			}
		}
		if (DerivedTokenAuthenticator != null)
		{
			int num2 = ((base.AlgorithmSuite.DefaultEncryptionKeyDerivationLength >= base.AlgorithmSuite.DefaultSignatureKeyDerivationLength) ? base.AlgorithmSuite.DefaultEncryptionKeyDerivationLength : base.AlgorithmSuite.DefaultSignatureKeyDerivationLength);
			MaxDerivedKeyLength = num2 / 8;
			_maxDerivedKeys = (2 + num) * 2;
		}
		SecurityHeaderElementInferenceEngine inferenceEngine = SecurityHeaderElementInferenceEngine.GetInferenceEngine(base.Layout);
		inferenceEngine.ExecuteProcessingPasses(this, xmlDictionaryReader);
		if (base.RequireMessageProtection)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		EnsureDecryptionComplete();
		_signatureTracker.SetDerivationSourceIfRequired();
		_encryptionTracker.SetDerivationSourceIfRequired();
		if (EncryptionToken != null)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		if (EnforceDerivedKeyRequirement)
		{
			if (SignatureToken != null)
			{
				if (_primaryTokenParameters != null)
				{
					if (_primaryTokenParameters.RequireDerivedKeys && !_primaryTokenParameters.HasAsymmetricKey && !_primaryTokenTracker.IsDerivedFrom)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.PrimarySignatureWasNotSignedByDerivedKey, _primaryTokenParameters)));
					}
				}
				else if (_wrappingTokenParameters != null && _wrappingTokenParameters.RequireDerivedKeys && !_signatureTracker.IsDerivedToken)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.PrimarySignatureWasNotSignedByDerivedWrappedKey, _wrappingTokenParameters)));
				}
			}
			if (EncryptionToken != null)
			{
				throw ExceptionHelper.PlatformNotSupported();
			}
		}
		if (flag && BasicSupportingTokens != null && BasicSupportingTokens.Count > 0)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		if (_supportingTokenTrackers != null && _supportingTokenTrackers.Count > 0)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		if (_replayDetectionEnabled)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		if (ExpectSignatureConfirmation)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		MarkHeaderAsUnderstood();
	}

	protected abstract void EnsureDecryptionComplete();

	internal void ExecuteFullPass(XmlDictionaryReader reader)
	{
		bool flag = !base.RequireMessageProtection;
		int num = 0;
		while (reader.IsStartElement())
		{
			if (IsReaderAtSignature(reader))
			{
				throw ExceptionHelper.PlatformNotSupported();
			}
			if (IsReaderAtReferenceList(reader))
			{
				throw ExceptionHelper.PlatformNotSupported();
			}
			if (base.StandardsManager.WSUtilitySpecificationVersion.IsReaderAtTimestamp(reader))
			{
				ReadTimestamp(reader);
			}
			else
			{
				if (IsReaderAtEncryptedKey(reader))
				{
					throw ExceptionHelper.PlatformNotSupported();
				}
				if (IsReaderAtEncryptedData(reader))
				{
					throw ExceptionHelper.PlatformNotSupported();
				}
				if (base.StandardsManager.SecurityVersion.IsReaderAtSignatureConfirmation(reader))
				{
					throw ExceptionHelper.PlatformNotSupported();
				}
				if (IsReaderAtSecurityTokenReference(reader))
				{
					throw ExceptionHelper.PlatformNotSupported();
				}
				ReadToken(reader, -1, null, null, null, _timeoutHelper.RemainingTime());
			}
			num++;
		}
		reader.ReadEndElement();
		reader.Close();
	}

	internal void EnsureDerivedKeyLimitNotReached()
	{
		_numDerivedKeys++;
		if (_numDerivedKeys > _maxDerivedKeys)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.DerivedKeyLimitExceeded, _maxDerivedKeys)));
		}
	}

	protected TokenTracker GetSupportingTokenTracker(SecurityTokenAuthenticator tokenAuthenticator, out SupportingTokenAuthenticatorSpecification spec)
	{
		spec = null;
		if (_supportingTokenAuthenticators == null)
		{
			return null;
		}
		for (int i = 0; i < _supportingTokenAuthenticators.Count; i++)
		{
			if (_supportingTokenAuthenticators[i].TokenAuthenticator == tokenAuthenticator)
			{
				spec = _supportingTokenAuthenticators[i];
				return _supportingTokenTrackers[i];
			}
		}
		return null;
	}

	private void ReadTimestamp(XmlDictionaryReader reader)
	{
		if (_timestamp != null)
		{
			throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.DuplicateTimestampInSecurityHeader), base.Message);
		}
		bool flag = base.RequireMessageProtection || _hasEndorsingOrSignedEndorsingSupportingTokens;
		string digestAlgorithm = (flag ? base.AlgorithmSuite.DefaultDigestAlgorithm : null);
		SignatureResourcePool resourcePool = (flag ? ResourcePool : null);
		_timestamp = base.StandardsManager.WSUtilitySpecificationVersion.ReadTimestamp(reader, digestAlgorithm, resourcePool);
		_timestamp.ValidateRangeAndFreshness(_replayWindow, _clockSkew);
		ElementManager.AppendTimestamp(_timestamp);
	}

	private bool IsPrimaryToken(SecurityToken token)
	{
		bool flag = token == _outOfBandPrimaryToken || (_primaryTokenTracker != null && token == _primaryTokenTracker.Token);
		if (!flag && _outOfBandPrimaryTokenCollection != null)
		{
			for (int i = 0; i < _outOfBandPrimaryTokenCollection.Count; i++)
			{
				if (_outOfBandPrimaryTokenCollection[i] == token)
				{
					flag = true;
					break;
				}
			}
		}
		return flag;
	}

	private void ReadToken(XmlDictionaryReader reader, int position, byte[] decryptedBuffer, SecurityToken encryptionToken, string idInEncryptedForm, TimeSpan timeout)
	{
		string localName = reader.LocalName;
		string namespaceURI = reader.NamespaceURI;
		string attribute = reader.GetAttribute(XD.SecurityJan2004Dictionary.ValueType, null);
		SecurityTokenAuthenticator usedTokenAuthenticator;
		SecurityToken securityToken = ReadToken(reader, CombinedUniversalTokenResolver, _allowedAuthenticators, out usedTokenAuthenticator);
		if (securityToken == null)
		{
			throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.TokenManagerCouldNotReadToken, localName, namespaceURI, attribute)), base.Message);
		}
		if (securityToken is DerivedKeySecurityToken derivedKeySecurityToken)
		{
			EnsureDerivedKeyLimitNotReached();
			derivedKeySecurityToken.InitializeDerivedKey(MaxDerivedKeyLength);
		}
		if (usedTokenAuthenticator == _primaryTokenAuthenticator)
		{
			_allowedAuthenticators.Remove(usedTokenAuthenticator);
		}
		TokenTracker tokenTracker = null;
		ReceiveSecurityHeaderBindingModes mode;
		if (usedTokenAuthenticator == _primaryTokenAuthenticator)
		{
			_universalTokenResolver.Add(securityToken, SecurityTokenReferenceStyle.Internal, _primaryTokenParameters);
			_primaryTokenResolver.Add(securityToken, SecurityTokenReferenceStyle.Internal, _primaryTokenParameters);
			if (_pendingSupportingTokenAuthenticator != null)
			{
				_allowedAuthenticators.Add(_pendingSupportingTokenAuthenticator);
				_pendingSupportingTokenAuthenticator = null;
			}
			_primaryTokenTracker.RecordToken(securityToken);
			mode = ReceiveSecurityHeaderBindingModes.Primary;
		}
		else if (usedTokenAuthenticator == DerivedTokenAuthenticator)
		{
			if (securityToken is DerivedKeySecurityTokenStub)
			{
				if (base.Layout == SecurityHeaderLayout.Strict)
				{
					DerivedKeySecurityTokenStub derivedKeySecurityTokenStub = (DerivedKeySecurityTokenStub)securityToken;
					throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.UnableToResolveKeyInfoClauseInDerivedKeyToken, derivedKeySecurityTokenStub.TokenToDeriveIdentifier)), base.Message);
				}
			}
			else
			{
				AddDerivedKeyTokenToResolvers(securityToken);
			}
			mode = ReceiveSecurityHeaderBindingModes.Unknown;
		}
		else
		{
			tokenTracker = GetSupportingTokenTracker(usedTokenAuthenticator, out var spec);
			if (tokenTracker == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.UnknownTokenAuthenticatorUsedInTokenProcessing, usedTokenAuthenticator)));
			}
			if (tokenTracker.Token != null)
			{
				tokenTracker = new TokenTracker(spec);
				_supportingTokenTrackers.Add(tokenTracker);
			}
			tokenTracker.RecordToken(securityToken);
			if (encryptionToken != null)
			{
				tokenTracker.IsEncrypted = true;
			}
			SecurityTokenAttachmentModeHelper.Categorize(spec.SecurityTokenAttachmentMode, out var isBasic, out var isSignedButNotBasic, out mode);
			if (isBasic)
			{
				if (!ExpectBasicTokens)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.BasicTokenNotExpected));
				}
				if (base.RequireMessageProtection && encryptionToken != null)
				{
					throw ExceptionHelper.PlatformNotSupported();
				}
			}
			if (isSignedButNotBasic && !ExpectSignedTokens)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.SignedSupportingTokenNotExpected));
			}
			_universalTokenResolver.Add(securityToken, SecurityTokenReferenceStyle.Internal, spec.TokenParameters);
		}
		if (position == -1)
		{
			ElementManager.AppendToken(securityToken, mode, tokenTracker);
		}
		else
		{
			ElementManager.SetTokenAfterDecryption(position, securityToken, mode, decryptedBuffer, tokenTracker);
		}
	}

	private SecurityToken GetRootToken(SecurityToken token)
	{
		if (token is DerivedKeySecurityToken)
		{
			return ((DerivedKeySecurityToken)token).TokenToDerive;
		}
		return token;
	}

	private SecurityToken ReadToken(XmlReader reader, SecurityTokenResolver tokenResolver, IList<SecurityTokenAuthenticator> allowedTokenAuthenticators, out SecurityTokenAuthenticator usedTokenAuthenticator)
	{
		SecurityToken securityToken = base.StandardsManager.SecurityTokenSerializer.ReadToken(reader, tokenResolver);
		if (securityToken is DerivedKeySecurityTokenStub)
		{
			if (DerivedTokenAuthenticator == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.UnableToFindTokenAuthenticator, typeof(DerivedKeySecurityToken))));
			}
			usedTokenAuthenticator = DerivedTokenAuthenticator;
			return securityToken;
		}
		for (int i = 0; i < allowedTokenAuthenticators.Count; i++)
		{
			SecurityTokenAuthenticator securityTokenAuthenticator = allowedTokenAuthenticators[i];
			if (securityTokenAuthenticator.CanValidateToken(securityToken))
			{
				ReadOnlyCollection<IAuthorizationPolicy> value = securityTokenAuthenticator.ValidateToken(securityToken);
				SecurityTokenAuthorizationPoliciesMapping.Add(securityToken, value);
				usedTokenAuthenticator = securityTokenAuthenticator;
				return securityToken;
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.UnableToFindTokenAuthenticator, securityToken.GetType())));
	}

	private void AddDerivedKeyTokenToResolvers(SecurityToken token)
	{
		_universalTokenResolver.Add(token);
		SecurityToken rootToken = GetRootToken(token);
		if (IsPrimaryToken(rootToken))
		{
			_primaryTokenResolver.Add(token);
		}
	}

	protected abstract bool IsReaderAtEncryptedKey(XmlDictionaryReader reader);

	protected abstract bool IsReaderAtEncryptedData(XmlDictionaryReader reader);

	protected abstract bool IsReaderAtReferenceList(XmlDictionaryReader reader);

	protected abstract bool IsReaderAtSignature(XmlDictionaryReader reader);

	protected abstract bool IsReaderAtSecurityTokenReference(XmlDictionaryReader reader);

	private void MarkHeaderAsUnderstood()
	{
		MessageHeaderInfo headerInfo = base.Message.Headers[HeaderIndex];
		base.Message.Headers.UnderstoodHeaders.Add(headerInfo);
	}
}
