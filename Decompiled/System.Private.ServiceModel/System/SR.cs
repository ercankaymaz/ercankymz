using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.System.Private.ServiceModel;

namespace System;

internal static class SR
{
	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static CultureInfo Culture { get; set; }

	internal static string NoIPEndpointsFoundForHost => GetResourceString("NoIPEndpointsFoundForHost");

	internal static string DnsResolveFailed => GetResourceString("DnsResolveFailed");

	internal static string RequiredAttributeMissing => GetResourceString("RequiredAttributeMissing");

	internal static string SecurityTokenManagerCannotCreateProviderForRequirement => GetResourceString("SecurityTokenManagerCannotCreateProviderForRequirement");

	internal static string SecurityTokenManagerCannotCreateAuthenticatorForRequirement => GetResourceString("SecurityTokenManagerCannotCreateAuthenticatorForRequirement");

	internal static string EncodingBindingElementDoesNotHandleReaderQuotas => GetResourceString("EncodingBindingElementDoesNotHandleReaderQuotas");

	internal static string ErrorDeserializingKeyIdentifierClauseFromTokenXml => GetResourceString("ErrorDeserializingKeyIdentifierClauseFromTokenXml");

	internal static string ErrorDeserializingTokenXml => GetResourceString("ErrorDeserializingTokenXml");

	internal static string TokenRequirementDoesNotSpecifyTargetAddress => GetResourceString("TokenRequirementDoesNotSpecifyTargetAddress");

	internal static string DerivedKeyNotInitialized => GetResourceString("DerivedKeyNotInitialized");

	internal static string MultipleSecurityCredentialsManagersInChannelBindingParameters => GetResourceString("MultipleSecurityCredentialsManagersInChannelBindingParameters");

	internal static string DerivedKeyTokenOffsetTooHigh => GetResourceString("DerivedKeyTokenOffsetTooHigh");

	internal static string DerivedKeyTokenGenerationAndLengthTooHigh => GetResourceString("DerivedKeyTokenGenerationAndLengthTooHigh");

	internal static string Psha1KeyLengthInvalid => GetResourceString("Psha1KeyLengthInvalid");

	internal static string CloneNotImplementedCorrectly => GetResourceString("CloneNotImplementedCorrectly");

	internal static string NegotiationFailedIO => GetResourceString("NegotiationFailedIO");

	internal static string AnonymousLogonsAreNotAllowed => GetResourceString("AnonymousLogonsAreNotAllowed");

	internal static string MultipleSupportingAuthenticatorsOfSameType => GetResourceString("MultipleSupportingAuthenticatorsOfSameType");

	internal static string SecurityTokenParametersCloneInvalidResult => GetResourceString("SecurityTokenParametersCloneInvalidResult");

	internal static string CertificateUnsupportedForHttpTransportCredentialOnly => GetResourceString("CertificateUnsupportedForHttpTransportCredentialOnly");

	internal static string NoncesCachedInfinitely => GetResourceString("NoncesCachedInfinitely");

	internal static string TrustDriverVersionDoesNotSupportSession => GetResourceString("TrustDriverVersionDoesNotSupportSession");

	internal static string TrustDriverVersionDoesNotSupportIssuedTokens => GetResourceString("TrustDriverVersionDoesNotSupportIssuedTokens");

	internal static string SignatureConfirmationNotSupported => GetResourceString("SignatureConfirmationNotSupported");

	internal static string SecureConversationDriverVersionDoesNotSupportSession => GetResourceString("SecureConversationDriverVersionDoesNotSupportSession");

	internal static string OneWayOperationReturnedFault => GetResourceString("OneWayOperationReturnedFault");

	internal static string OneWayOperationReturnedLargeFault => GetResourceString("OneWayOperationReturnedLargeFault");

	internal static string OneWayOperationReturnedMessage => GetResourceString("OneWayOperationReturnedMessage");

	internal static string KeyLifetimeNotWithinTokenLifetime => GetResourceString("KeyLifetimeNotWithinTokenLifetime");

	internal static string EffectiveGreaterThanExpiration => GetResourceString("EffectiveGreaterThanExpiration");

	internal static string LengthMustBeGreaterThanZero => GetResourceString("LengthMustBeGreaterThanZero");

	internal static string OperationCannotBeDoneAfterProcessingIsStarted => GetResourceString("OperationCannotBeDoneAfterProcessingIsStarted");

	internal static string ClientCredentialsUnableToCreateLocalTokenProvider => GetResourceString("ClientCredentialsUnableToCreateLocalTokenProvider");

	internal static string SecurityProtocolCannotDoReplayDetection => GetResourceString("SecurityProtocolCannotDoReplayDetection");

	internal static string CannotReadToken => GetResourceString("CannotReadToken");

	internal static string ExpectedElementMissing => GetResourceString("ExpectedElementMissing");

	internal static string MissingMessageID => GetResourceString("MissingMessageID");

	internal static string OnlyBodyReturnValuesSupported => GetResourceString("OnlyBodyReturnValuesSupported");

	internal static string UnexpectedEndOfFile => GetResourceString("UnexpectedEndOfFile");

	internal static string TimeStampHasCreationAheadOfExpiry => GetResourceString("TimeStampHasCreationAheadOfExpiry");

	internal static string TimeStampHasExpiryTimeInPast => GetResourceString("TimeStampHasExpiryTimeInPast");

	internal static string TimeStampHasCreationTimeInFuture => GetResourceString("TimeStampHasCreationTimeInFuture");

	internal static string TimeStampWasCreatedTooLongAgo => GetResourceString("TimeStampWasCreatedTooLongAgo");

	internal static string ItemNotAvailableInDeserializedRST => GetResourceString("ItemNotAvailableInDeserializedRST");

	internal static string ItemAvailableInDeserializedRSTOnly => GetResourceString("ItemAvailableInDeserializedRSTOnly");

	internal static string ItemNotAvailableInDeserializedRSTR => GetResourceString("ItemNotAvailableInDeserializedRSTR");

	internal static string ItemAvailableInDeserializedRSTROnly => GetResourceString("ItemAvailableInDeserializedRSTROnly");

	internal static string Hosting_ServiceActivationFailed => GetResourceString("Hosting_ServiceActivationFailed");

	internal static string Sharing_ConnectionDispatchFailed => GetResourceString("Sharing_ConnectionDispatchFailed");

	internal static string Sharing_EndpointUnavailable => GetResourceString("Sharing_EndpointUnavailable");

	internal static string UnexpectedEmptyElementExpectingClaim => GetResourceString("UnexpectedEmptyElementExpectingClaim");

	internal static string UnexpectedElementExpectingElement => GetResourceString("UnexpectedElementExpectingElement");

	internal static string UnexpectedDuplicateElement => GetResourceString("UnexpectedDuplicateElement");

	internal static string MultipleIdentities => GetResourceString("MultipleIdentities");

	internal static string InvalidUriValue => GetResourceString("InvalidUriValue");

	internal static string UnrecognizedIdentityType => GetResourceString("UnrecognizedIdentityType");

	internal static string InvalidIdentityElement => GetResourceString("InvalidIdentityElement");

	internal static string UnrecognizedClaimTypeForIdentity => GetResourceString("UnrecognizedClaimTypeForIdentity");

	internal static string SendCannotBeCalledAfterCloseOutputSession => GetResourceString("SendCannotBeCalledAfterCloseOutputSession");

	internal static string CommunicationObjectCannotBeModifiedInState => GetResourceString("CommunicationObjectCannotBeModifiedInState");

	internal static string CommunicationObjectCannotBeUsed => GetResourceString("CommunicationObjectCannotBeUsed");

	internal static string CommunicationObjectFaulted1 => GetResourceString("CommunicationObjectFaulted1");

	internal static string CommunicationObjectAborted1 => GetResourceString("CommunicationObjectAborted1");

	internal static string CommunicationObjectBaseClassMethodNotCalled => GetResourceString("CommunicationObjectBaseClassMethodNotCalled");

	internal static string CommunicationObjectInInvalidState => GetResourceString("CommunicationObjectInInvalidState");

	internal static string ChannelFactoryCannotBeUsedToCreateChannels => GetResourceString("ChannelFactoryCannotBeUsedToCreateChannels");

	internal static string ChannelParametersCannotBeModified => GetResourceString("ChannelParametersCannotBeModified");

	internal static string ChannelParametersCannotBePropagated => GetResourceString("ChannelParametersCannotBePropagated");

	internal static string ChannelTypeNotSupported => GetResourceString("ChannelTypeNotSupported");

	internal static string InvalidEnumValue => GetResourceString("InvalidEnumValue");

	internal static string InvalidDecoderStateMachine => GetResourceString("InvalidDecoderStateMachine");

	internal static string ObjectDisposed => GetResourceString("ObjectDisposed");

	internal static string InvalidReaderPositionOnCreateMessage => GetResourceString("InvalidReaderPositionOnCreateMessage");

	internal static string DuplicateMessageProperty => GetResourceString("DuplicateMessageProperty");

	internal static string MessagePropertyNotFound => GetResourceString("MessagePropertyNotFound");

	internal static string HeaderAlreadyUnderstood => GetResourceString("HeaderAlreadyUnderstood");

	internal static string HeaderAlreadyNotUnderstood => GetResourceString("HeaderAlreadyNotUnderstood");

	internal static string MultipleMessageHeaders => GetResourceString("MultipleMessageHeaders");

	internal static string MultipleMessageHeadersWithActor => GetResourceString("MultipleMessageHeadersWithActor");

	internal static string MultipleRelatesToHeaders => GetResourceString("MultipleRelatesToHeaders");

	internal static string ExtraContentIsPresentInFaultDetail => GetResourceString("ExtraContentIsPresentInFaultDetail");

	internal static string MessageIsEmpty => GetResourceString("MessageIsEmpty");

	internal static string MessageClosed => GetResourceString("MessageClosed");

	internal static string BodyWriterReturnedIsNotBuffered => GetResourceString("BodyWriterReturnedIsNotBuffered");

	internal static string BodyWriterCanOnlyBeWrittenOnce => GetResourceString("BodyWriterCanOnlyBeWrittenOnce");

	internal static string RequestMessageDoesNotHaveAMessageID => GetResourceString("RequestMessageDoesNotHaveAMessageID");

	internal static string HeaderNotFound => GetResourceString("HeaderNotFound");

	internal static string MessageBufferIsClosed => GetResourceString("MessageBufferIsClosed");

	internal static string MessageTextEncodingNotSupported => GetResourceString("MessageTextEncodingNotSupported");

	internal static string AtLeastOneFaultReasonMustBeSpecified => GetResourceString("AtLeastOneFaultReasonMustBeSpecified");

	internal static string NoNullTranslations => GetResourceString("NoNullTranslations");

	internal static string FaultDoesNotHaveAnyDetail => GetResourceString("FaultDoesNotHaveAnyDetail");

	internal static string InvalidXmlQualifiedName => GetResourceString("InvalidXmlQualifiedName");

	internal static string UnboundPrefixInQName => GetResourceString("UnboundPrefixInQName");

	internal static string MessageBodyIsUnknown => GetResourceString("MessageBodyIsUnknown");

	internal static string MessageBodyIsStream => GetResourceString("MessageBodyIsStream");

	internal static string MessageBodyToStringError => GetResourceString("MessageBodyToStringError");

	internal static string NoMatchingTranslationFoundForFaultText => GetResourceString("NoMatchingTranslationFoundForFaultText");

	internal static string CannotDetermineSPNBasedOnAddress => GetResourceString("CannotDetermineSPNBasedOnAddress");

	internal static string XmlLangAttributeMissing => GetResourceString("XmlLangAttributeMissing");

	internal static string EncoderUnrecognizedCharSet => GetResourceString("EncoderUnrecognizedCharSet");

	internal static string EncoderUnrecognizedContentType => GetResourceString("EncoderUnrecognizedContentType");

	internal static string EncoderBadContentType => GetResourceString("EncoderBadContentType");

	internal static string EncoderEnvelopeVersionMismatch => GetResourceString("EncoderEnvelopeVersionMismatch");

	internal static string EncoderMessageVersionMismatch => GetResourceString("EncoderMessageVersionMismatch");

	internal static string SPS_SeekNotSupported => GetResourceString("SPS_SeekNotSupported");

	internal static string SocketCloseReadTimeout => GetResourceString("SocketCloseReadTimeout");

	internal static string SocketCloseReadReceivedData => GetResourceString("SocketCloseReadReceivedData");

	internal static string SessionValueInvalid => GetResourceString("SessionValueInvalid");

	internal static string SocketAbortedReceiveTimedOut => GetResourceString("SocketAbortedReceiveTimedOut");

	internal static string SocketAbortedSendTimedOut => GetResourceString("SocketAbortedSendTimedOut");

	internal static string OperationInvalidBeforeSecurityNegotiation => GetResourceString("OperationInvalidBeforeSecurityNegotiation");

	internal static string FramingError => GetResourceString("FramingError");

	internal static string FramingPrematureEOF => GetResourceString("FramingPrematureEOF");

	internal static string FramingRecordTypeMismatch => GetResourceString("FramingRecordTypeMismatch");

	internal static string FramingVersionNotSupported => GetResourceString("FramingVersionNotSupported");

	internal static string FramingModeNotSupported => GetResourceString("FramingModeNotSupported");

	internal static string FramingSizeTooLarge => GetResourceString("FramingSizeTooLarge");

	internal static string FramingViaTooLong => GetResourceString("FramingViaTooLong");

	internal static string FramingViaNotUri => GetResourceString("FramingViaNotUri");

	internal static string FramingFaultTooLong => GetResourceString("FramingFaultTooLong");

	internal static string FramingContentTypeTooLong => GetResourceString("FramingContentTypeTooLong");

	internal static string FramingValueNotAvailable => GetResourceString("FramingValueNotAvailable");

	internal static string FramingAtEnd => GetResourceString("FramingAtEnd");

	internal static string BinaryEncoderSessionTooLarge => GetResourceString("BinaryEncoderSessionTooLarge");

	internal static string BinaryEncoderSessionInvalid => GetResourceString("BinaryEncoderSessionInvalid");

	internal static string BinaryEncoderSessionMalformed => GetResourceString("BinaryEncoderSessionMalformed");

	internal static string ReceiveShutdownReturnedFault => GetResourceString("ReceiveShutdownReturnedFault");

	internal static string ReceiveShutdownReturnedLargeFault => GetResourceString("ReceiveShutdownReturnedLargeFault");

	internal static string ReceiveShutdownReturnedMessage => GetResourceString("ReceiveShutdownReturnedMessage");

	internal static string MaxReceivedMessageSizeExceeded => GetResourceString("MaxReceivedMessageSizeExceeded");

	internal static string MaxSentMessageSizeExceeded => GetResourceString("MaxSentMessageSizeExceeded");

	internal static string FramingMaxMessageSizeExceeded => GetResourceString("FramingMaxMessageSizeExceeded");

	internal static string StreamDoesNotSupportTimeout => GetResourceString("StreamDoesNotSupportTimeout");

	internal static string AddressingVersionNotSupported => GetResourceString("AddressingVersionNotSupported");

	internal static string MessagePropertyReturnedNullCopy => GetResourceString("MessagePropertyReturnedNullCopy");

	internal static string MessageVersionUnknown => GetResourceString("MessageVersionUnknown");

	internal static string EnvelopeVersionUnknown => GetResourceString("EnvelopeVersionUnknown");

	internal static string EnvelopeVersionNotSupported => GetResourceString("EnvelopeVersionNotSupported");

	internal static string CannotDetectAddressingVersion => GetResourceString("CannotDetectAddressingVersion");

	internal static string HeadersCannotBeAddedToEnvelopeVersion => GetResourceString("HeadersCannotBeAddedToEnvelopeVersion");

	internal static string AddressingHeadersCannotBeAddedToAddressingVersion => GetResourceString("AddressingHeadersCannotBeAddedToAddressingVersion");

	internal static string AddressingExtensionInBadNS => GetResourceString("AddressingExtensionInBadNS");

	internal static string MessageHeaderVersionNotSupported => GetResourceString("MessageHeaderVersionNotSupported");

	internal static string MessageHasBeenCopied => GetResourceString("MessageHasBeenCopied");

	internal static string MessageHasBeenWritten => GetResourceString("MessageHasBeenWritten");

	internal static string MessageHasBeenRead => GetResourceString("MessageHasBeenRead");

	internal static string InvalidMessageState => GetResourceString("InvalidMessageState");

	internal static string MessageBodyReaderInvalidReadState => GetResourceString("MessageBodyReaderInvalidReadState");

	internal static string XmlBufferQuotaExceeded => GetResourceString("XmlBufferQuotaExceeded");

	internal static string XmlBufferInInvalidState => GetResourceString("XmlBufferInInvalidState");

	internal static string MessageBodyMissing => GetResourceString("MessageBodyMissing");

	internal static string MessageHeaderVersionMismatch => GetResourceString("MessageHeaderVersionMismatch");

	internal static string ManualAddressingRequiresAddressedMessages => GetResourceString("ManualAddressingRequiresAddressedMessages");

	internal static string ReceiveTimedOut2 => GetResourceString("ReceiveTimedOut2");

	internal static string WaitForMessageTimedOut => GetResourceString("WaitForMessageTimedOut");

	internal static string SendToViaTimedOut => GetResourceString("SendToViaTimedOut");

	internal static string CloseTimedOut => GetResourceString("CloseTimedOut");

	internal static string OpenTimedOutEstablishingTransportSession => GetResourceString("OpenTimedOutEstablishingTransportSession");

	internal static string RequestTimedOutEstablishingTransportSession => GetResourceString("RequestTimedOutEstablishingTransportSession");

	internal static string TcpConnectingToViaTimedOut => GetResourceString("TcpConnectingToViaTimedOut");

	internal static string RequestChannelSendTimedOut => GetResourceString("RequestChannelSendTimedOut");

	internal static string RequestChannelWaitForReplyTimedOut => GetResourceString("RequestChannelWaitForReplyTimedOut");

	internal static string HttpProxyRequiresSingleAuthScheme => GetResourceString("HttpProxyRequiresSingleAuthScheme");

	internal static string UseDefaultWebProxyCantBeUsedWithExplicitProxyAddress => GetResourceString("UseDefaultWebProxyCantBeUsedWithExplicitProxyAddress");

	internal static string ProxyImpersonationLevelMismatch => GetResourceString("ProxyImpersonationLevelMismatch");

	internal static string ProxyAuthenticationLevelMismatch => GetResourceString("ProxyAuthenticationLevelMismatch");

	internal static string HttpIfModifiedSinceParseError => GetResourceString("HttpIfModifiedSinceParseError");

	internal static string HttpSoapActionMismatch => GetResourceString("HttpSoapActionMismatch");

	internal static string HttpSoapActionMismatchContentType => GetResourceString("HttpSoapActionMismatchContentType");

	internal static string HttpContentTypeFormatException => GetResourceString("HttpContentTypeFormatException");

	internal static string HttpServerTooBusy => GetResourceString("HttpServerTooBusy");

	internal static string HttpRequestTimedOut => GetResourceString("HttpRequestTimedOut");

	internal static string HttpResponseTimedOut => GetResourceString("HttpResponseTimedOut");

	internal static string HttpReceiveFailure => GetResourceString("HttpReceiveFailure");

	internal static string HttpAuthDoesNotSupportRequestStreaming => GetResourceString("HttpAuthDoesNotSupportRequestStreaming");

	internal static string ReplyAlreadySent => GetResourceString("ReplyAlreadySent");

	internal static string RequestContextAborted => GetResourceString("RequestContextAborted");

	internal static string InnerChannelFactoryWasNotSet => GetResourceString("InnerChannelFactoryWasNotSet");

	internal static string PropertySettingErrorOnProtocolFactory => GetResourceString("PropertySettingErrorOnProtocolFactory");

	internal static string ProtocolFactoryCouldNotCreateProtocol => GetResourceString("ProtocolFactoryCouldNotCreateProtocol");

	internal static string IdentityCheckFailedForOutgoingMessage => GetResourceString("IdentityCheckFailedForOutgoingMessage");

	internal static string IdentityCheckFailedForIncomingMessage => GetResourceString("IdentityCheckFailedForIncomingMessage");

	internal static string DnsIdentityCheckFailedForIncomingMessageLackOfDnsClaim => GetResourceString("DnsIdentityCheckFailedForIncomingMessageLackOfDnsClaim");

	internal static string DnsIdentityCheckFailedForOutgoingMessageLackOfDnsClaim => GetResourceString("DnsIdentityCheckFailedForOutgoingMessageLackOfDnsClaim");

	internal static string DnsIdentityCheckFailedForIncomingMessage => GetResourceString("DnsIdentityCheckFailedForIncomingMessage");

	internal static string DnsIdentityCheckFailedForOutgoingMessage => GetResourceString("DnsIdentityCheckFailedForOutgoingMessage");

	internal static string ClientCertificateNotProvidedOnClientCredentials => GetResourceString("ClientCertificateNotProvidedOnClientCredentials");

	internal static string UserNamePasswordNotProvidedOnClientCredentials => GetResourceString("UserNamePasswordNotProvidedOnClientCredentials");

	internal static string ObjectIsReadOnly => GetResourceString("ObjectIsReadOnly");

	internal static string EmptyXmlElementError => GetResourceString("EmptyXmlElementError");

	internal static string UnexpectedXmlChildNode => GetResourceString("UnexpectedXmlChildNode");

	internal static string InvalidQName => GetResourceString("InvalidQName");

	internal static string SuiteDoesNotAcceptAlgorithm => GetResourceString("SuiteDoesNotAcceptAlgorithm");

	internal static string CannotFindCert => GetResourceString("CannotFindCert");

	internal static string CannotFindCertForTarget => GetResourceString("CannotFindCertForTarget");

	internal static string FoundMultipleCerts => GetResourceString("FoundMultipleCerts");

	internal static string FoundMultipleCertsForTarget => GetResourceString("FoundMultipleCertsForTarget");

	internal static string SigningTokenHasNoKeys => GetResourceString("SigningTokenHasNoKeys");

	internal static string SigningTokenHasNoKeysSupportingTheAlgorithmSuite => GetResourceString("SigningTokenHasNoKeysSupportingTheAlgorithmSuite");

	internal static string EmptyBase64Attribute => GetResourceString("EmptyBase64Attribute");

	internal static string CouldNotFindNamespaceForPrefix => GetResourceString("CouldNotFindNamespaceForPrefix");

	internal static string ChildNodeTypeMissing => GetResourceString("ChildNodeTypeMissing");

	internal static string SPS_InvalidAsyncResult => GetResourceString("SPS_InvalidAsyncResult");

	internal static string NonceLengthTooShort => GetResourceString("NonceLengthTooShort");

	internal static string IncorrectBinaryNegotiationValueType => GetResourceString("IncorrectBinaryNegotiationValueType");

	internal static string CreationTimeUtcIsAfterExpiryTime => GetResourceString("CreationTimeUtcIsAfterExpiryTime");

	internal static string CacheQuotaReached => GetResourceString("CacheQuotaReached");

	internal static string UnrecognizedIdentityPropertyType => GetResourceString("UnrecognizedIdentityPropertyType");

	internal static string EndpointNotFound => GetResourceString("EndpointNotFound");

	internal static string MaxReceivedMessageSizeMustBeInIntegerRange => GetResourceString("MaxReceivedMessageSizeMustBeInIntegerRange");

	internal static string MaxBufferSizeMustMatchMaxReceivedMessageSize => GetResourceString("MaxBufferSizeMustMatchMaxReceivedMessageSize");

	internal static string MaxBufferSizeMustNotExceedMaxReceivedMessageSize => GetResourceString("MaxBufferSizeMustNotExceedMaxReceivedMessageSize");

	internal static string InValidateIdPrefix => GetResourceString("InValidateIdPrefix");

	internal static string InValidateId => GetResourceString("InValidateId");

	internal static string UnexpectedHttpResponseCode => GetResourceString("UnexpectedHttpResponseCode");

	internal static string HttpContentLengthIncorrect => GetResourceString("HttpContentLengthIncorrect");

	internal static string MissingContentType => GetResourceString("MissingContentType");

	internal static string DuplexChannelAbortedDuringOpen => GetResourceString("DuplexChannelAbortedDuringOpen");

	internal static string OperationAbortedDuringConnectionEstablishment => GetResourceString("OperationAbortedDuringConnectionEstablishment");

	internal static string HttpAddressingNoneHeaderOnWire => GetResourceString("HttpAddressingNoneHeaderOnWire");

	internal static string MessageXmlProtocolError => GetResourceString("MessageXmlProtocolError");

	internal static string TcpConnectNoBufs => GetResourceString("TcpConnectNoBufs");

	internal static string InsufficentMemory => GetResourceString("InsufficentMemory");

	internal static string TcpConnectError => GetResourceString("TcpConnectError");

	internal static string TcpConnectErrorWithTimeSpan => GetResourceString("TcpConnectErrorWithTimeSpan");

	internal static string TcpTransferError => GetResourceString("TcpTransferError");

	internal static string TcpLocalConnectionAborted => GetResourceString("TcpLocalConnectionAborted");

	internal static string TcpConnectionResetError => GetResourceString("TcpConnectionResetError");

	internal static string TcpConnectionTimedOut => GetResourceString("TcpConnectionTimedOut");

	internal static string SocketConnectionDisposed => GetResourceString("SocketConnectionDisposed");

	internal static string HttpContentTypeHeaderRequired => GetResourceString("HttpContentTypeHeaderRequired");

	internal static string ResponseContentTypeMismatch => GetResourceString("ResponseContentTypeMismatch");

	internal static string HttpToMustEqualVia => GetResourceString("HttpToMustEqualVia");

	internal static string FramingContentTypeMismatch => GetResourceString("FramingContentTypeMismatch");

	internal static string FramingFaultUnrecognized => GetResourceString("FramingFaultUnrecognized");

	internal static string FramingContentTypeTooLongFault => GetResourceString("FramingContentTypeTooLongFault");

	internal static string FramingViaTooLongFault => GetResourceString("FramingViaTooLongFault");

	internal static string FramingModeNotSupportedFault => GetResourceString("FramingModeNotSupportedFault");

	internal static string FramingVersionNotSupportedFault => GetResourceString("FramingVersionNotSupportedFault");

	internal static string FramingUpgradeInvalid => GetResourceString("FramingUpgradeInvalid");

	internal static string ServerTooBusy => GetResourceString("ServerTooBusy");

	internal static string PreambleAckIncorrect => GetResourceString("PreambleAckIncorrect");

	internal static string PreambleAckIncorrectMaybeHttp => GetResourceString("PreambleAckIncorrectMaybeHttp");

	internal static string StreamError => GetResourceString("StreamError");

	internal static string ServerRejectedUpgradeRequest => GetResourceString("ServerRejectedUpgradeRequest");

	internal static string ServerRejectedSessionPreamble => GetResourceString("ServerRejectedSessionPreamble");

	internal static string UnableToResolveHost => GetResourceString("UnableToResolveHost");

	internal static string HttpRequiresSingleAuthScheme => GetResourceString("HttpRequiresSingleAuthScheme");

	internal static string HttpAuthSchemeCannotBeNone => GetResourceString("HttpAuthSchemeCannotBeNone");

	internal static string HttpAuthorizationFailed => GetResourceString("HttpAuthorizationFailed");

	internal static string HttpAuthorizationForbidden => GetResourceString("HttpAuthorizationForbidden");

	internal static string InvalidUriScheme => GetResourceString("InvalidUriScheme");

	internal static string HttpsServerCertThumbprintMismatch => GetResourceString("HttpsServerCertThumbprintMismatch");

	internal static string TrustFailure => GetResourceString("TrustFailure");

	internal static string StreamMutualAuthNotSatisfied => GetResourceString("StreamMutualAuthNotSatisfied");

	internal static string InvalidTokenProvided => GetResourceString("InvalidTokenProvided");

	internal static string NoUserNameTokenProvided => GetResourceString("NoUserNameTokenProvided");

	internal static string RemoteIdentityFailedVerification => GetResourceString("RemoteIdentityFailedVerification");

	internal static string CredentialDisallowsNtlm => GetResourceString("CredentialDisallowsNtlm");

	internal static string UriGeneratorSchemeMustNotBeEmpty => GetResourceString("UriGeneratorSchemeMustNotBeEmpty");

	internal static string UnsupportedSslProtectionLevel => GetResourceString("UnsupportedSslProtectionLevel");

	internal static string TimeoutServiceChannelConcurrentOpen1 => GetResourceString("TimeoutServiceChannelConcurrentOpen1");

	internal static string TimeoutServiceChannelConcurrentOpen2 => GetResourceString("TimeoutServiceChannelConcurrentOpen2");

	internal static string TimeSpanMustbeGreaterThanTimeSpanZero => GetResourceString("TimeSpanMustbeGreaterThanTimeSpanZero");

	internal static string AsyncResultCompletedTwice => GetResourceString("AsyncResultCompletedTwice");

	internal static string ValueMustBeNonNegative => GetResourceString("ValueMustBeNonNegative");

	internal static string ValueMustBePositive => GetResourceString("ValueMustBePositive");

	internal static string ValueMustBeGreaterThanZero => GetResourceString("ValueMustBeGreaterThanZero");

	internal static string ValueMustBeInRange => GetResourceString("ValueMustBeInRange");

	internal static string OffsetExceedsBufferSize => GetResourceString("OffsetExceedsBufferSize");

	internal static string SizeExceedsRemainingBufferSpace => GetResourceString("SizeExceedsRemainingBufferSpace");

	internal static string SpaceNeededExceedsMessageFrameOffset => GetResourceString("SpaceNeededExceedsMessageFrameOffset");

	internal static string FaultConverterDidNotCreateFaultMessage => GetResourceString("FaultConverterDidNotCreateFaultMessage");

	internal static string FaultConverterCreatedFaultMessage => GetResourceString("FaultConverterCreatedFaultMessage");

	internal static string FaultConverterDidNotCreateException => GetResourceString("FaultConverterDidNotCreateException");

	internal static string FaultConverterCreatedException => GetResourceString("FaultConverterCreatedException");

	internal static string UnsupportedUpgradeInitiator => GetResourceString("UnsupportedUpgradeInitiator");

	internal static string StreamUpgradeUnsupportedChannelBindingKind => GetResourceString("StreamUpgradeUnsupportedChannelBindingKind");

	internal static string ExtendedProtectionNotSupported => GetResourceString("ExtendedProtectionNotSupported");

	internal static string HttpClientCredentialTypeInvalid => GetResourceString("HttpClientCredentialTypeInvalid");

	internal static string TransportDoesNotSupportCompression => GetResourceString("TransportDoesNotSupportCompression");

	internal static string UnsupportedSecuritySetting => GetResourceString("UnsupportedSecuritySetting");

	internal static string UnsupportedBindingProperty => GetResourceString("UnsupportedBindingProperty");

	internal static string HttpMaxPendingAcceptsTooLargeError => GetResourceString("HttpMaxPendingAcceptsTooLargeError");

	internal static string UnsupportedTokenImpersonationLevel => GetResourceString("UnsupportedTokenImpersonationLevel");

	internal static string TimeoutOnOpen => GetResourceString("TimeoutOnOpen");

	internal static string TimeoutOnRequest => GetResourceString("TimeoutOnRequest");

	internal static string SFxActionDemuxerDuplicate => GetResourceString("SFxActionDemuxerDuplicate");

	internal static string SFXBindingNameCannotBeNullOrEmpty => GetResourceString("SFXBindingNameCannotBeNullOrEmpty");

	internal static string SFXUnvalidNamespaceValue => GetResourceString("SFXUnvalidNamespaceValue");

	internal static string SFXUnvalidNamespaceParam => GetResourceString("SFXUnvalidNamespaceParam");

	internal static string SFXHeaderNameCannotBeNullOrEmpty => GetResourceString("SFXHeaderNameCannotBeNullOrEmpty");

	internal static string SFxBadByReferenceParameterMetadata => GetResourceString("SFxBadByReferenceParameterMetadata");

	internal static string SFxBadByValueParameterMetadata => GetResourceString("SFxBadByValueParameterMetadata");

	internal static string SFxBindingMustContainTransport2 => GetResourceString("SFxBindingMustContainTransport2");

	internal static string SFxBodyCannotBeNull => GetResourceString("SFxBodyCannotBeNull");

	internal static string SFxCallbackBehaviorAttributeOnlyOnDuplex => GetResourceString("SFxCallbackBehaviorAttributeOnlyOnDuplex");

	internal static string SFxCallbackRequestReplyInOrder1 => GetResourceString("SFxCallbackRequestReplyInOrder1");

	internal static string SfxCallbackTypeCannotBeNull => GetResourceString("SfxCallbackTypeCannotBeNull");

	internal static string SFxCannotActivateCallbackInstace => GetResourceString("SFxCannotActivateCallbackInstace");

	internal static string SFxCannotCallAutoOpenWhenExplicitOpenCalled => GetResourceString("SFxCannotCallAutoOpenWhenExplicitOpenCalled");

	internal static string SFxCannotSetExtensionsByIndex => GetResourceString("SFxCannotSetExtensionsByIndex");

	internal static string SFxChannelDispatcherNoMessageVersion => GetResourceString("SFxChannelDispatcherNoMessageVersion");

	internal static string SFxChannelDispatcherUnableToOpen1 => GetResourceString("SFxChannelDispatcherUnableToOpen1");

	internal static string SFxChannelDispatcherUnableToOpen2 => GetResourceString("SFxChannelDispatcherUnableToOpen2");

	internal static string SFxChannelFactoryTypeMustBeInterface => GetResourceString("SFxChannelFactoryTypeMustBeInterface");

	internal static string SFxChannelFactoryCannotCreateFactoryWithoutDescription => GetResourceString("SFxChannelFactoryCannotCreateFactoryWithoutDescription");

	internal static string SFxClientOutputSessionAutoClosed => GetResourceString("SFxClientOutputSessionAutoClosed");

	internal static string SFxCollectionDoesNotSupportSet0 => GetResourceString("SFxCollectionDoesNotSupportSet0");

	internal static string SFxCollectionReadOnly => GetResourceString("SFxCollectionReadOnly");

	internal static string SFxCollectionWrongType2 => GetResourceString("SFxCollectionWrongType2");

	internal static string SFxContextModifiedInsideScope0 => GetResourceString("SFxContextModifiedInsideScope0");

	internal static string SFxContractDescriptionNameCannotBeEmpty => GetResourceString("SFxContractDescriptionNameCannotBeEmpty");

	internal static string SFxContractHasZeroOperations => GetResourceString("SFxContractHasZeroOperations");

	internal static string SFxContractHasZeroInitiatingOperations => GetResourceString("SFxContractHasZeroInitiatingOperations");

	internal static string SFxContractInheritanceRequiresInterfaces => GetResourceString("SFxContractInheritanceRequiresInterfaces");

	internal static string SFxContractInheritanceRequiresInterfaces2 => GetResourceString("SFxContractInheritanceRequiresInterfaces2");

	internal static string SFxCopyToRequiresICollection => GetResourceString("SFxCopyToRequiresICollection");

	internal static string SFxCreateDuplexChannel1 => GetResourceString("SFxCreateDuplexChannel1");

	internal static string SFxCreateDuplexChannelNoCallback => GetResourceString("SFxCreateDuplexChannelNoCallback");

	internal static string SFxCreateDuplexChannelNoCallback1 => GetResourceString("SFxCreateDuplexChannelNoCallback1");

	internal static string SFxCreateDuplexChannelNoCallbackUserObject => GetResourceString("SFxCreateDuplexChannelNoCallbackUserObject");

	internal static string SFxCreateDuplexChannelBadCallbackUserObject => GetResourceString("SFxCreateDuplexChannelBadCallbackUserObject");

	internal static string SFxCreateNonDuplexChannel1 => GetResourceString("SFxCreateNonDuplexChannel1");

	internal static string SFxCustomBindingNeedsTransport1 => GetResourceString("SFxCustomBindingNeedsTransport1");

	internal static string SFxDeserializationFailed1 => GetResourceString("SFxDeserializationFailed1");

	internal static string SFxDisallowedAttributeCombination => GetResourceString("SFxDisallowedAttributeCombination");

	internal static string SFxInitializationUINotCalled => GetResourceString("SFxInitializationUINotCalled");

	internal static string SFxInitializationUIDisallowed => GetResourceString("SFxInitializationUIDisallowed");

	internal static string SFxDocEncodedNotSupported => GetResourceString("SFxDocEncodedNotSupported");

	internal static string SFxDuplicateMessageParts => GetResourceString("SFxDuplicateMessageParts");

	internal static string SFXEndpointBehaviorUsedOnWrongSide => GetResourceString("SFXEndpointBehaviorUsedOnWrongSide");

	internal static string SFxEndpointDispatcherMultipleChannelDispatcher0 => GetResourceString("SFxEndpointDispatcherMultipleChannelDispatcher0");

	internal static string SFxEndpointDispatcherDifferentChannelDispatcher0 => GetResourceString("SFxEndpointDispatcherDifferentChannelDispatcher0");

	internal static string SFxErrorDeserializingRequestBody => GetResourceString("SFxErrorDeserializingRequestBody");

	internal static string SFxErrorDeserializingRequestBodyMore => GetResourceString("SFxErrorDeserializingRequestBodyMore");

	internal static string SFxErrorDeserializingReplyBody => GetResourceString("SFxErrorDeserializingReplyBody");

	internal static string SFxErrorDeserializingReplyBodyMore => GetResourceString("SFxErrorDeserializingReplyBodyMore");

	internal static string SFxErrorSerializingBody => GetResourceString("SFxErrorSerializingBody");

	internal static string SFxErrorDeserializingHeader => GetResourceString("SFxErrorDeserializingHeader");

	internal static string SFxErrorSerializingHeader => GetResourceString("SFxErrorSerializingHeader");

	internal static string SFxErrorDeserializingFault => GetResourceString("SFxErrorDeserializingFault");

	internal static string SFxErrorReflectingOnType2 => GetResourceString("SFxErrorReflectingOnType2");

	internal static string SFxErrorReflectingOnMethod3 => GetResourceString("SFxErrorReflectingOnMethod3");

	internal static string SFxErrorReflectingOnParameter4 => GetResourceString("SFxErrorReflectingOnParameter4");

	internal static string SFxErrorReflectionOnUnknown1 => GetResourceString("SFxErrorReflectionOnUnknown1");

	internal static string SFxExceptionDetailEndOfInner => GetResourceString("SFxExceptionDetailEndOfInner");

	internal static string SFxExceptionDetailFormat => GetResourceString("SFxExceptionDetailFormat");

	internal static string SFxFaultContractDuplicateDetailType => GetResourceString("SFxFaultContractDuplicateDetailType");

	internal static string SFxFaultContractDuplicateElement => GetResourceString("SFxFaultContractDuplicateElement");

	internal static string SFxFaultExceptionToString3 => GetResourceString("SFxFaultExceptionToString3");

	internal static string SFxFaultReason => GetResourceString("SFxFaultReason");

	internal static string SFxFaultTypeAnonymous => GetResourceString("SFxFaultTypeAnonymous");

	internal static string SFxHeaderNameMismatchInMessageContract => GetResourceString("SFxHeaderNameMismatchInMessageContract");

	internal static string SFxHeaderNameMismatchInOperation => GetResourceString("SFxHeaderNameMismatchInOperation");

	internal static string SFxHeaderNamespaceMismatchInMessageContract => GetResourceString("SFxHeaderNamespaceMismatchInMessageContract");

	internal static string SFxHeaderNamespaceMismatchInOperation => GetResourceString("SFxHeaderNamespaceMismatchInOperation");

	internal static string SFxHeaderNotUnderstood => GetResourceString("SFxHeaderNotUnderstood");

	internal static string SFxImmutableServiceHostBehavior0 => GetResourceString("SFxImmutableServiceHostBehavior0");

	internal static string SFxImmutableChannelFactoryBehavior0 => GetResourceString("SFxImmutableChannelFactoryBehavior0");

	internal static string SFxInputParametersToServiceInvalid => GetResourceString("SFxInputParametersToServiceInvalid");

	internal static string SFxInputParametersToServiceNull => GetResourceString("SFxInputParametersToServiceNull");

	internal static string SFxInstanceNotInitialized => GetResourceString("SFxInstanceNotInitialized");

	internal static string SFxInterleavedContextScopes0 => GetResourceString("SFxInterleavedContextScopes0");

	internal static string SFxInternalServerError => GetResourceString("SFxInternalServerError");

	internal static string SFxInternalCallbackError => GetResourceString("SFxInternalCallbackError");

	internal static string SFxInvalidAsyncResultState0 => GetResourceString("SFxInvalidAsyncResultState0");

	internal static string SFxInvalidCallbackIAsyncResult => GetResourceString("SFxInvalidCallbackIAsyncResult");

	internal static string SFxInvalidCallbackContractType => GetResourceString("SFxInvalidCallbackContractType");

	internal static string SFxInvalidChannelToOperationContext => GetResourceString("SFxInvalidChannelToOperationContext");

	internal static string SFxInvalidMessageBody => GetResourceString("SFxInvalidMessageBody");

	internal static string SFxInvalidMessageBodyEmptyMessage => GetResourceString("SFxInvalidMessageBodyEmptyMessage");

	internal static string SFxInvalidMessageBodyErrorSerializingParameter => GetResourceString("SFxInvalidMessageBodyErrorSerializingParameter");

	internal static string SFxInvalidMessageBodyErrorDeserializingParameter => GetResourceString("SFxInvalidMessageBodyErrorDeserializingParameter");

	internal static string SFxInvalidMessageBodyErrorDeserializingParameterMore => GetResourceString("SFxInvalidMessageBodyErrorDeserializingParameterMore");

	internal static string SFxInvalidMessageContractSignature => GetResourceString("SFxInvalidMessageContractSignature");

	internal static string SFxInvalidMessageHeaderArrayType => GetResourceString("SFxInvalidMessageHeaderArrayType");

	internal static string SFxInvalidRequestAction => GetResourceString("SFxInvalidRequestAction");

	internal static string SFxInvalidReplyAction => GetResourceString("SFxInvalidReplyAction");

	internal static string SFxInvalidStreamInTypedMessage => GetResourceString("SFxInvalidStreamInTypedMessage");

	internal static string SFxInvalidStreamInRequest => GetResourceString("SFxInvalidStreamInRequest");

	internal static string SFxInvalidStreamInResponse => GetResourceString("SFxInvalidStreamInResponse");

	internal static string SFxInvalidStreamOffsetLength => GetResourceString("SFxInvalidStreamOffsetLength");

	internal static string SFxInvalidUseOfPrimitiveOperationFormatter => GetResourceString("SFxInvalidUseOfPrimitiveOperationFormatter");

	internal static string SFxInvalidStaticOverloadCalledForDuplexChannelFactory1 => GetResourceString("SFxInvalidStaticOverloadCalledForDuplexChannelFactory1");

	internal static string SFxInvalidXmlAttributeInBare => GetResourceString("SFxInvalidXmlAttributeInBare");

	internal static string SFxInvalidXmlAttributeInWrapped => GetResourceString("SFxInvalidXmlAttributeInWrapped");

	internal static string SFxKnownTypeAttributeInvalid1 => GetResourceString("SFxKnownTypeAttributeInvalid1");

	internal static string SFxKnownTypeAttributeReturnType3 => GetResourceString("SFxKnownTypeAttributeReturnType3");

	internal static string SFxKnownTypeAttributeUnknownMethod3 => GetResourceString("SFxKnownTypeAttributeUnknownMethod3");

	internal static string SFxKnownTypeNull => GetResourceString("SFxKnownTypeNull");

	internal static string SFxMessageContractBaseTypeNotValid => GetResourceString("SFxMessageContractBaseTypeNotValid");

	internal static string SFxMessageContractRequiresDefaultConstructor => GetResourceString("SFxMessageContractRequiresDefaultConstructor");

	internal static string SFxMetadataReferenceInvalidLocation => GetResourceString("SFxMetadataReferenceInvalidLocation");

	internal static string SFxMethodNotSupported1 => GetResourceString("SFxMethodNotSupported1");

	internal static string SFxMethodNotSupportedOnCallback1 => GetResourceString("SFxMethodNotSupportedOnCallback1");

	internal static string SFxMismatchedOperationParent => GetResourceString("SFxMismatchedOperationParent");

	internal static string SFxMissingActionHeader => GetResourceString("SFxMissingActionHeader");

	internal static string SFxMultipleCallbackFromSynchronizationContext => GetResourceString("SFxMultipleCallbackFromSynchronizationContext");

	internal static string SFxMultipleCallbackFromAsyncOperation => GetResourceString("SFxMultipleCallbackFromAsyncOperation");

	internal static string SFxMultipleUnknownHeaders => GetResourceString("SFxMultipleUnknownHeaders");

	internal static string SFxMultipleContractStarOperations0 => GetResourceString("SFxMultipleContractStarOperations0");

	internal static string SFxNameCannotBeEmpty => GetResourceString("SFxNameCannotBeEmpty");

	internal static string SFxConfigurationNameCannotBeEmpty => GetResourceString("SFxConfigurationNameCannotBeEmpty");

	internal static string SFxNeedProxyBehaviorOperationSelector2 => GetResourceString("SFxNeedProxyBehaviorOperationSelector2");

	internal static string SFxNoDefaultConstructor => GetResourceString("SFxNoDefaultConstructor");

	internal static string SFxNoMostDerivedContract => GetResourceString("SFxNoMostDerivedContract");

	internal static string SFxNullReplyFromFormatter2 => GetResourceString("SFxNullReplyFromFormatter2");

	internal static string SFxServiceChannelIdleAborted => GetResourceString("SFxServiceChannelIdleAborted");

	internal static string SFxSetEnableFaultsOnChannelDispatcher0 => GetResourceString("SFxSetEnableFaultsOnChannelDispatcher0");

	internal static string SFxSetManualAddressingOnChannelDispatcher0 => GetResourceString("SFxSetManualAddressingOnChannelDispatcher0");

	internal static string SFxNoServiceObject => GetResourceString("SFxNoServiceObject");

	internal static string SFxNonExceptionThrown => GetResourceString("SFxNonExceptionThrown");

	internal static string SFxNonInitiatingOperation1 => GetResourceString("SFxNonInitiatingOperation1");

	internal static string SFxOneWayMessageToTwoWayMethod0 => GetResourceString("SFxOneWayMessageToTwoWayMethod0");

	internal static string SFxOperationContractOnNonServiceContract => GetResourceString("SFxOperationContractOnNonServiceContract");

	internal static string SFxOperationContractProviderOnNonServiceContract => GetResourceString("SFxOperationContractProviderOnNonServiceContract");

	internal static string SFxOperationDescriptionNameCannotBeEmpty => GetResourceString("SFxOperationDescriptionNameCannotBeEmpty");

	internal static string SFxParameterNameCannotBeNull => GetResourceString("SFxParameterNameCannotBeNull");

	internal static string SFxOperationMustHaveOneOrTwoMessages => GetResourceString("SFxOperationMustHaveOneOrTwoMessages");

	internal static string SFxParameterCountMismatch => GetResourceString("SFxParameterCountMismatch");

	internal static string SFxParameterMustBeMessage => GetResourceString("SFxParameterMustBeMessage");

	internal static string SFxParametersMustBeEmpty => GetResourceString("SFxParametersMustBeEmpty");

	internal static string SFxParameterMustBeArrayOfOneElement => GetResourceString("SFxParameterMustBeArrayOfOneElement");

	internal static string SFxRequestHasInvalidReplyToOnClient => GetResourceString("SFxRequestHasInvalidReplyToOnClient");

	internal static string SFxRequestHasInvalidFaultToOnClient => GetResourceString("SFxRequestHasInvalidFaultToOnClient");

	internal static string SFxRequestReplyNone => GetResourceString("SFxRequestReplyNone");

	internal static string SFxRequestTimedOut1 => GetResourceString("SFxRequestTimedOut1");

	internal static string SFxRequestTimedOut2 => GetResourceString("SFxRequestTimedOut2");

	internal static string SFxReplyActionMismatch3 => GetResourceString("SFxReplyActionMismatch3");

	internal static string SFxResultMustBeMessage => GetResourceString("SFxResultMustBeMessage");

	internal static string SFxRpcMessageBodyPartNameInvalid => GetResourceString("SFxRpcMessageBodyPartNameInvalid");

	internal static string SFxServerDidNotReply => GetResourceString("SFxServerDidNotReply");

	internal static string SFxStaticMessageHeaderPropertiesNotAllowed => GetResourceString("SFxStaticMessageHeaderPropertiesNotAllowed");

	internal static string SFxStreamIOException => GetResourceString("SFxStreamIOException");

	internal static string SFxStreamRequestMessageClosed => GetResourceString("SFxStreamRequestMessageClosed");

	internal static string SFxStreamResponseMessageClosed => GetResourceString("SFxStreamResponseMessageClosed");

	internal static string SFxTimeoutOutOfRange0 => GetResourceString("SFxTimeoutOutOfRange0");

	internal static string SFxTimeoutOutOfRangeTooBig => GetResourceString("SFxTimeoutOutOfRangeTooBig");

	internal static string SFxTypedMessageCannotBeNull => GetResourceString("SFxTypedMessageCannotBeNull");

	internal static string SFxTypedMessageCannotBeRpcLiteral => GetResourceString("SFxTypedMessageCannotBeRpcLiteral");

	internal static string SFxTypedOrUntypedMessageCannotBeMixedWithParameters => GetResourceString("SFxTypedOrUntypedMessageCannotBeMixedWithParameters");

	internal static string SFxTypedOrUntypedMessageCannotBeMixedWithVoidInRpc => GetResourceString("SFxTypedOrUntypedMessageCannotBeMixedWithVoidInRpc");

	internal static string SFxUnknownFaultNoMatchingTranslation1 => GetResourceString("SFxUnknownFaultNoMatchingTranslation1");

	internal static string SFxUnknownFaultNullReason0 => GetResourceString("SFxUnknownFaultNullReason0");

	internal static string SFxUnknownFaultZeroReasons0 => GetResourceString("SFxUnknownFaultZeroReasons0");

	internal static string SFxVersionMismatchInOperationContextAndMessage2 => GetResourceString("SFxVersionMismatchInOperationContextAndMessage2");

	internal static string SFxWrapperNameCannotBeEmpty => GetResourceString("SFxWrapperNameCannotBeEmpty");

	internal static string SFxXmlArrayNotAllowedForMultiple => GetResourceString("SFxXmlArrayNotAllowedForMultiple");

	internal static string SFxXmlSerializerIsNotFound => GetResourceString("SFxXmlSerializerIsNotFound");

	internal static string SFxChannelFactoryEndpointAddressUri => GetResourceString("SFxChannelFactoryEndpointAddressUri");

	internal static string SFxCloseTimedOut1 => GetResourceString("SFxCloseTimedOut1");

	internal static string SfxCloseTimedOutWaitingForDispatchToComplete => GetResourceString("SfxCloseTimedOutWaitingForDispatchToComplete");

	internal static string SFxChannelFactoryNoBindingFoundInConfig1 => GetResourceString("SFxChannelFactoryNoBindingFoundInConfig1");

	internal static string SFxChannelFactoryNoBindingFoundInConfigOrCode => GetResourceString("SFxChannelFactoryNoBindingFoundInConfigOrCode");

	internal static string SFxProxyRuntimeMessageCannotBeNull => GetResourceString("SFxProxyRuntimeMessageCannotBeNull");

	internal static string SFxDispatchRuntimeMessageCannotBeNull => GetResourceString("SFxDispatchRuntimeMessageCannotBeNull");

	internal static string SFxMessagePartDescriptionMissingType => GetResourceString("SFxMessagePartDescriptionMissingType");

	internal static string AChannelServiceEndpointSBindingIsNull0 => GetResourceString("AChannelServiceEndpointSBindingIsNull0");

	internal static string AChannelServiceEndpointSContractIsNull0 => GetResourceString("AChannelServiceEndpointSContractIsNull0");

	internal static string AChannelServiceEndpointSContractSNameIsNull0 => GetResourceString("AChannelServiceEndpointSContractSNameIsNull0");

	internal static string AChannelServiceEndpointSContractSNamespace0 => GetResourceString("AChannelServiceEndpointSContractSNamespace0");

	internal static string SFxNoEndpointMatchingContract => GetResourceString("SFxNoEndpointMatchingContract");

	internal static string SFxNoEndpointMatchingAddress => GetResourceString("SFxNoEndpointMatchingAddress");

	internal static string SFxNoEndpointMatchingAddressForConnectionOpeningMessage => GetResourceString("SFxNoEndpointMatchingAddressForConnectionOpeningMessage");

	internal static string SFxServiceChannelCannotBeCalledBecauseIsSessionOpenNotificationEnabled => GetResourceString("SFxServiceChannelCannotBeCalledBecauseIsSessionOpenNotificationEnabled");

	internal static string EndMethodsCannotBeDecoratedWithOperationContractAttribute => GetResourceString("EndMethodsCannotBeDecoratedWithOperationContractAttribute");

	internal static string DispatchRuntimeRequiresFormatter0 => GetResourceString("DispatchRuntimeRequiresFormatter0");

	internal static string ClientRuntimeRequiresFormatter0 => GetResourceString("ClientRuntimeRequiresFormatter0");

	internal static string RuntimeRequiresInvoker0 => GetResourceString("RuntimeRequiresInvoker0");

	internal static string CouldnTCreateChannelForType2 => GetResourceString("CouldnTCreateChannelForType2");

	internal static string CouldnTCreateChannelForChannelType2 => GetResourceString("CouldnTCreateChannelForChannelType2");

	internal static string EndpointListenerRequirementsCannotBeMetBy3 => GetResourceString("EndpointListenerRequirementsCannotBeMetBy3");

	internal static string UnknownListenerType1 => GetResourceString("UnknownListenerType1");

	internal static string BindingDoesnTSupportSessionButContractRequires1 => GetResourceString("BindingDoesnTSupportSessionButContractRequires1");

	internal static string BindingDoesntSupportDatagramButContractRequires => GetResourceString("BindingDoesntSupportDatagramButContractRequires");

	internal static string BindingDoesnTSupportOneWayButContractRequires1 => GetResourceString("BindingDoesnTSupportOneWayButContractRequires1");

	internal static string BindingDoesnTSupportTwoWayButContractRequires1 => GetResourceString("BindingDoesnTSupportTwoWayButContractRequires1");

	internal static string BindingDoesnTSupportRequestReplyButContract1 => GetResourceString("BindingDoesnTSupportRequestReplyButContract1");

	internal static string BindingDoesnTSupportDuplexButContractRequires1 => GetResourceString("BindingDoesnTSupportDuplexButContractRequires1");

	internal static string BindingDoesnTSupportAnyChannelTypes1 => GetResourceString("BindingDoesnTSupportAnyChannelTypes1");

	internal static string ContractIsNotSelfConsistentItHasOneOrMore2 => GetResourceString("ContractIsNotSelfConsistentItHasOneOrMore2");

	internal static string ContractIsNotSelfConsistentWhenIsSessionOpenNotificationEnabled => GetResourceString("ContractIsNotSelfConsistentWhenIsSessionOpenNotificationEnabled");

	internal static string SynchronizedCollectionWrongType1 => GetResourceString("SynchronizedCollectionWrongType1");

	internal static string SynchronizedCollectionWrongTypeNull => GetResourceString("SynchronizedCollectionWrongTypeNull");

	internal static string CannotAddTwoItemsWithTheSameKeyToSynchronizedKeyedCollection0 => GetResourceString("CannotAddTwoItemsWithTheSameKeyToSynchronizedKeyedCollection0");

	internal static string ItemDoesNotExistInSynchronizedKeyedCollection0 => GetResourceString("ItemDoesNotExistInSynchronizedKeyedCollection0");

	internal static string SuppliedMessageIsNotAReplyItHasNoRelatesTo0 => GetResourceString("SuppliedMessageIsNotAReplyItHasNoRelatesTo0");

	internal static string channelIsNotAvailable0 => GetResourceString("channelIsNotAvailable0");

	internal static string channelDoesNotHaveADuplexSession0 => GetResourceString("channelDoesNotHaveADuplexSession0");

	internal static string UnsupportedEnvelopeVersion => GetResourceString("UnsupportedEnvelopeVersion");

	internal static string ServicesWithoutAServiceContractAttributeCan2 => GetResourceString("ServicesWithoutAServiceContractAttributeCan2");

	internal static string tooManyAttributesOfTypeOn2 => GetResourceString("tooManyAttributesOfTypeOn2");

	internal static string couldnTFindRequiredAttributeOfTypeOn2 => GetResourceString("couldnTFindRequiredAttributeOfTypeOn2");

	internal static string AttemptedToGetContractTypeForButThatTypeIs1 => GetResourceString("AttemptedToGetContractTypeForButThatTypeIs1");

	internal static string NoEndMethodFoundForAsyncBeginMethod3 => GetResourceString("NoEndMethodFoundForAsyncBeginMethod3");

	internal static string MoreThanOneEndMethodFoundForAsyncBeginMethod3 => GetResourceString("MoreThanOneEndMethodFoundForAsyncBeginMethod3");

	internal static string InvalidAsyncEndMethodSignatureForMethod2 => GetResourceString("InvalidAsyncEndMethodSignatureForMethod2");

	internal static string InvalidAsyncBeginMethodSignatureForMethod2 => GetResourceString("InvalidAsyncBeginMethodSignatureForMethod2");

	internal static string InAContractInheritanceHierarchyIfParentHasCallbackChildMustToo => GetResourceString("InAContractInheritanceHierarchyIfParentHasCallbackChildMustToo");

	internal static string InAContractInheritanceHierarchyTheServiceContract3_2 => GetResourceString("InAContractInheritanceHierarchyTheServiceContract3_2");

	internal static string CannotHaveTwoOperationsWithTheSameName3 => GetResourceString("CannotHaveTwoOperationsWithTheSameName3");

	internal static string CannotInheritTwoOperationsWithTheSameName3 => GetResourceString("CannotInheritTwoOperationsWithTheSameName3");

	internal static string SyncAsyncMatchConsistency_Parameters5 => GetResourceString("SyncAsyncMatchConsistency_Parameters5");

	internal static string SyncTaskMatchConsistency_Parameters5 => GetResourceString("SyncTaskMatchConsistency_Parameters5");

	internal static string TaskAsyncMatchConsistency_Parameters5 => GetResourceString("TaskAsyncMatchConsistency_Parameters5");

	internal static string SyncAsyncMatchConsistency_ReturnType5 => GetResourceString("SyncAsyncMatchConsistency_ReturnType5");

	internal static string SyncTaskMatchConsistency_ReturnType5 => GetResourceString("SyncTaskMatchConsistency_ReturnType5");

	internal static string TaskAsyncMatchConsistency_ReturnType5 => GetResourceString("TaskAsyncMatchConsistency_ReturnType5");

	internal static string SyncAsyncMatchConsistency_Attributes6 => GetResourceString("SyncAsyncMatchConsistency_Attributes6");

	internal static string SyncTaskMatchConsistency_Attributes6 => GetResourceString("SyncTaskMatchConsistency_Attributes6");

	internal static string TaskAsyncMatchConsistency_Attributes6 => GetResourceString("TaskAsyncMatchConsistency_Attributes6");

	internal static string SyncAsyncMatchConsistency_Property6 => GetResourceString("SyncAsyncMatchConsistency_Property6");

	internal static string SyncTaskMatchConsistency_Property6 => GetResourceString("SyncTaskMatchConsistency_Property6");

	internal static string TaskAsyncMatchConsistency_Property6 => GetResourceString("TaskAsyncMatchConsistency_Property6");

	internal static string ServiceOperationsMarkedWithIsOneWayTrueMust0 => GetResourceString("ServiceOperationsMarkedWithIsOneWayTrueMust0");

	internal static string OneWayOperationShouldNotSpecifyAReplyAction1 => GetResourceString("OneWayOperationShouldNotSpecifyAReplyAction1");

	internal static string OneWayAndFaultsIncompatible2 => GetResourceString("OneWayAndFaultsIncompatible2");

	internal static string AsyncEndCalledOnWrongChannel => GetResourceString("AsyncEndCalledOnWrongChannel");

	internal static string AsyncEndCalledWithAnIAsyncResult => GetResourceString("AsyncEndCalledWithAnIAsyncResult");

	internal static string MessageHeaderIsNull0 => GetResourceString("MessageHeaderIsNull0");

	internal static string MessagePropertiesArraySize0 => GetResourceString("MessagePropertiesArraySize0");

	internal static string DuplicateBehavior1 => GetResourceString("DuplicateBehavior1");

	internal static string CantCreateChannelWithManualAddressing => GetResourceString("CantCreateChannelWithManualAddressing");

	internal static string XDCannotFindValueInDictionaryString => GetResourceString("XDCannotFindValueInDictionaryString");

	internal static string NoChannelBuilderAvailable => GetResourceString("NoChannelBuilderAvailable");

	internal static string InvalidBindingScheme => GetResourceString("InvalidBindingScheme");

	internal static string CustomBindingRequiresTransport => GetResourceString("CustomBindingRequiresTransport");

	internal static string TransportBindingElementMustBeLast => GetResourceString("TransportBindingElementMustBeLast");

	internal static string MessageVersionMissingFromBinding => GetResourceString("MessageVersionMissingFromBinding");

	internal static string NotAllBindingElementsBuilt => GetResourceString("NotAllBindingElementsBuilt");

	internal static string MultipleMebesInParameters => GetResourceString("MultipleMebesInParameters");

	internal static string MultipleStreamUpgradeProvidersInParameters => GetResourceString("MultipleStreamUpgradeProvidersInParameters");

	internal static string SecurityCapabilitiesMismatched => GetResourceString("SecurityCapabilitiesMismatched");

	internal static string BaseAddressMustBeAbsolute => GetResourceString("BaseAddressMustBeAbsolute");

	internal static string BaseAddressDuplicateScheme => GetResourceString("BaseAddressDuplicateScheme");

	internal static string BaseAddressCannotHaveUserInfo => GetResourceString("BaseAddressCannotHaveUserInfo");

	internal static string BaseAddressCannotHaveQuery => GetResourceString("BaseAddressCannotHaveQuery");

	internal static string BaseAddressCannotHaveFragment => GetResourceString("BaseAddressCannotHaveFragment");

	internal static string UriMustBeAbsolute => GetResourceString("UriMustBeAbsolute");

	internal static string ClaimTypeCannotBeEmpty => GetResourceString("ClaimTypeCannotBeEmpty");

	internal static string MissingCustomCertificateValidator => GetResourceString("MissingCustomCertificateValidator");

	internal static string SecurityAuditPlatformNotSupported => GetResourceString("SecurityAuditPlatformNotSupported");

	internal static string ActivityCallback => GetResourceString("ActivityCallback");

	internal static string ActivityClose => GetResourceString("ActivityClose");

	internal static string ActivityConstructChannelFactory => GetResourceString("ActivityConstructChannelFactory");

	internal static string ActivityExecuteMethod => GetResourceString("ActivityExecuteMethod");

	internal static string ActivityCloseClientBase => GetResourceString("ActivityCloseClientBase");

	internal static string ActivityOpenClientBase => GetResourceString("ActivityOpenClientBase");

	internal static string ActivityProcessAction => GetResourceString("ActivityProcessAction");

	internal static string ActivityProcessingMessage => GetResourceString("ActivityProcessingMessage");

	internal static string TraceCodeConnectionPoolIdleTimeoutReached => GetResourceString("TraceCodeConnectionPoolIdleTimeoutReached");

	internal static string TraceCodeConnectionPoolLeaseTimeoutReached => GetResourceString("TraceCodeConnectionPoolLeaseTimeoutReached");

	internal static string TraceCodeConnectionPoolMaxOutboundConnectionsPerEndpointQuotaReached => GetResourceString("TraceCodeConnectionPoolMaxOutboundConnectionsPerEndpointQuotaReached");

	internal static string InputTypeListEmptyError => GetResourceString("InputTypeListEmptyError");

	internal static string DelegatingHandlerArrayHasNonNullInnerHandler => GetResourceString("DelegatingHandlerArrayHasNonNullInnerHandler");

	internal static string DelegatingHandlerArrayFromFuncContainsNullItem => GetResourceString("DelegatingHandlerArrayFromFuncContainsNullItem");

	internal static string HttpMessageHandlerTypeNotSupported => GetResourceString("HttpMessageHandlerTypeNotSupported");

	internal static string HttpPipelineNotSupportedOnClientSide => GetResourceString("HttpPipelineNotSupportedOnClientSide");

	internal static string WebSocketInvalidProtocolInvalidCharInProtocolString => GetResourceString("WebSocketInvalidProtocolInvalidCharInProtocolString");

	internal static string WebSocketInvalidProtocolContainsMultipleSubProtocolString => GetResourceString("WebSocketInvalidProtocolContainsMultipleSubProtocolString");

	internal static string WebSocketInvalidProtocolEmptySubprotocolString => GetResourceString("WebSocketInvalidProtocolEmptySubprotocolString");

	internal static string WebSocketUnexpectedCloseMessageError => GetResourceString("WebSocketUnexpectedCloseMessageError");

	internal static string WebSocketStreamWriteCalledAfterEOMSent => GetResourceString("WebSocketStreamWriteCalledAfterEOMSent");

	internal static string WebSocketCannotCreateRequestClientChannelWithCertainWebSocketTransportUsage => GetResourceString("WebSocketCannotCreateRequestClientChannelWithCertainWebSocketTransportUsage");

	internal static string ClientWebSocketFactory_CreateWebSocketFailed => GetResourceString("ClientWebSocketFactory_CreateWebSocketFailed");

	internal static string ClientWebSocketFactory_InvalidWebSocket => GetResourceString("ClientWebSocketFactory_InvalidWebSocket");

	internal static string ClientWebSocketFactory_InvalidSubProtocol => GetResourceString("ClientWebSocketFactory_InvalidSubProtocol");

	internal static string WebSocketSendTimedOut => GetResourceString("WebSocketSendTimedOut");

	internal static string WebSocketReceiveTimedOut => GetResourceString("WebSocketReceiveTimedOut");

	internal static string WebSocketOperationTimedOut => GetResourceString("WebSocketOperationTimedOut");

	internal static string WebSocketVersionMismatchFromServer => GetResourceString("WebSocketVersionMismatchFromServer");

	internal static string WebSocketSubProtocolMismatchFromServer => GetResourceString("WebSocketSubProtocolMismatchFromServer");

	internal static string CopyHttpHeaderFailed => GetResourceString("CopyHttpHeaderFailed");

	internal static string XmlInvalidConversion => GetResourceString("XmlInvalidConversion");

	internal static string XmlInvalidStream => GetResourceString("XmlInvalidStream");

	internal static string LockTimeoutExceptionMessage => GetResourceString("LockTimeoutExceptionMessage");

	internal static string InvalidEnumArgument => GetResourceString("InvalidEnumArgument");

	internal static string InvalidTypedProxyMethodHandle => GetResourceString("InvalidTypedProxyMethodHandle");

	internal static string FailedToCreateTypedProxy => GetResourceString("FailedToCreateTypedProxy");

	internal static string SecurityTokenRequirementDoesNotContainProperty => GetResourceString("SecurityTokenRequirementDoesNotContainProperty");

	internal static string SecurityTokenRequirementHasInvalidTypeForProperty => GetResourceString("SecurityTokenRequirementHasInvalidTypeForProperty");

	internal static string TokenCancellationNotSupported => GetResourceString("TokenCancellationNotSupported");

	internal static string TokenProviderUnableToGetToken => GetResourceString("TokenProviderUnableToGetToken");

	internal static string TokenProviderUnableToRenewToken => GetResourceString("TokenProviderUnableToRenewToken");

	internal static string TokenRenewalNotSupported => GetResourceString("TokenRenewalNotSupported");

	internal static string UserNameCannotBeEmpty => GetResourceString("UserNameCannotBeEmpty");

	internal static string ActivityBoundary => GetResourceString("ActivityBoundary");

	internal static string StringNullOrEmpty => GetResourceString("StringNullOrEmpty");

	internal static string GenericCallbackException => GetResourceString("GenericCallbackException");

	internal static string ArgumentCannotBeEmptyString => GetResourceString("ArgumentCannotBeEmptyString");

	internal static string KeyIdentifierClauseDoesNotSupportKeyCreation => GetResourceString("KeyIdentifierClauseDoesNotSupportKeyCreation");

	internal static string SymmetricKeyLengthTooShort => GetResourceString("SymmetricKeyLengthTooShort");

	internal static string KeyIdentifierCannotCreateKey => GetResourceString("KeyIdentifierCannotCreateKey");

	internal static string NoKeyIdentifierClauseFound => GetResourceString("NoKeyIdentifierClauseFound");

	internal static string LocalIdCannotBeEmpty => GetResourceString("LocalIdCannotBeEmpty");

	internal static string CannotValidateSecurityTokenType => GetResourceString("CannotValidateSecurityTokenType");

	internal static string UnauthorizedAccess_MemStreamBuffer => GetResourceString("UnauthorizedAccess_MemStreamBuffer");

	internal static string ConfigurationFilesNotSupported => GetResourceString("ConfigurationFilesNotSupported");

	internal static string X509ChainBuildFail => GetResourceString("X509ChainBuildFail");

	internal static string ImpersonationLevelNotSupported => GetResourceString("ImpersonationLevelNotSupported");

	internal static string ProvidedNetworkCredentialsForKerberosHasInvalidUserName => GetResourceString("ProvidedNetworkCredentialsForKerberosHasInvalidUserName");

	internal static string SSLProtocolNegotiationFailed => GetResourceString("SSLProtocolNegotiationFailed");

	internal static string ssl_io_cert_validation => GetResourceString("ssl_io_cert_validation");

	internal static string X509InvalidUsageTime => GetResourceString("X509InvalidUsageTime");

	internal static string X509IsInUntrustedStore => GetResourceString("X509IsInUntrustedStore");

	internal static string X509IsNotInTrustedStore => GetResourceString("X509IsNotInTrustedStore");

	internal static string Xml_InvalidNodeType => GetResourceString("Xml_InvalidNodeType");

	internal static string SFxRpcMessageMustHaveASingleBody => GetResourceString("SFxRpcMessageMustHaveASingleBody");

	internal static string SFxBodyObjectTypeCannotBeInherited => GetResourceString("SFxBodyObjectTypeCannotBeInherited");

	internal static string SFxBodyObjectTypeCannotBeInterface => GetResourceString("SFxBodyObjectTypeCannotBeInterface");

	internal static string SFxHeadersAreNotSupportedInEncoded => GetResourceString("SFxHeadersAreNotSupportedInEncoded");

	internal static string SFxMultiplePartsNotAllowedInEncoded => GetResourceString("SFxMultiplePartsNotAllowedInEncoded");

	internal static string SFxInvalidSoapAttribute => GetResourceString("SFxInvalidSoapAttribute");

	internal static string SFxTerminatingOperationAlreadyCalled1 => GetResourceString("SFxTerminatingOperationAlreadyCalled1");

	internal static string SFxChannelTerminated0 => GetResourceString("SFxChannelTerminated0");

	internal static string PeerTrustNotSupportedOnOSX => GetResourceString("PeerTrustNotSupportedOnOSX");

	internal static string SFxNone2004 => GetResourceString("SFxNone2004");

	internal static string SFxRequestHasInvalidFromOnClient => GetResourceString("SFxRequestHasInvalidFromOnClient");

	internal static string ClientCredentialTypeMustBeSpecifiedForMixedMode => GetResourceString("ClientCredentialTypeMustBeSpecifiedForMixedMode");

	internal static string SecureConversationSecurityTokenParametersRequireBootstrapBinding => GetResourceString("SecureConversationSecurityTokenParametersRequireBootstrapBinding");

	internal static string ProtocolMustBeInitiator => GetResourceString("ProtocolMustBeInitiator");

	internal static string SecurityProtocolFactoryShouldBeSetBeforeThisOperation => GetResourceString("SecurityProtocolFactoryShouldBeSetBeforeThisOperation");

	internal static string IssuedSecurityTokenParametersNotSet => GetResourceString("IssuedSecurityTokenParametersNotSet");

	internal static string KeyRolloverGreaterThanKeyRenewal => GetResourceString("KeyRolloverGreaterThanKeyRenewal");

	internal static string SecuritySessionProtocolFactoryShouldBeSetBeforeThisOperation => GetResourceString("SecuritySessionProtocolFactoryShouldBeSetBeforeThisOperation");

	internal static string SecurityStandardsManagerNotSet => GetResourceString("SecurityStandardsManagerNotSet");

	internal static string ActivitySecurityClose => GetResourceString("ActivitySecurityClose");

	internal static string ClientSecurityCloseTimeout => GetResourceString("ClientSecurityCloseTimeout");

	internal static string ClientSecurityOutputSessionCloseTimeout => GetResourceString("ClientSecurityOutputSessionCloseTimeout");

	internal static string DelayedSecurityApplicationAlreadyCompleted => GetResourceString("DelayedSecurityApplicationAlreadyCompleted");

	internal static string MessageBodyOperationNotValidInBodyState => GetResourceString("MessageBodyOperationNotValidInBodyState");

	internal static string MessageSecurityVerificationFailed => GetResourceString("MessageSecurityVerificationFailed");

	internal static string OutputNotExpected => GetResourceString("OutputNotExpected");

	internal static string PrimarySignatureMustBeComputedBeforeSupportingTokenSignatures => GetResourceString("PrimarySignatureMustBeComputedBeforeSupportingTokenSignatures");

	internal static string ProtocolMisMatch => GetResourceString("ProtocolMisMatch");

	internal static string SenderSideSupportingTokensMustSpecifySecurityTokenParameters => GetResourceString("SenderSideSupportingTokensMustSpecifySecurityTokenParameters");

	internal static string SigningWithoutPrimarySignatureRequiresTimestamp => GetResourceString("SigningWithoutPrimarySignatureRequiresTimestamp");

	internal static string SupportingTokenSignaturesNotExpected => GetResourceString("SupportingTokenSignaturesNotExpected");

	internal static string TimestampAlreadySetForSecurityHeader => GetResourceString("TimestampAlreadySetForSecurityHeader");

	internal static string TokenDoesNotSupportKeyIdentifierClauseCreation => GetResourceString("TokenDoesNotSupportKeyIdentifierClauseCreation");

	internal static string TokenManagerCannotCreateTokenReference => GetResourceString("TokenManagerCannotCreateTokenReference");

	internal static string TokenMustBeNullWhenTokenParametersAre => GetResourceString("TokenMustBeNullWhenTokenParametersAre");

	internal static string TokenProviderCannotGetTokensForTarget => GetResourceString("TokenProviderCannotGetTokensForTarget");

	internal static string UnableToCreateTokenReference => GetResourceString("UnableToCreateTokenReference");

	internal static string UnableToFindSecurityHeaderInMessage => GetResourceString("UnableToFindSecurityHeaderInMessage");

	internal static string UnableToFindSecurityHeaderInMessageNoActor => GetResourceString("UnableToFindSecurityHeaderInMessageNoActor");

	internal static string UnknownTokenAttachmentMode => GetResourceString("UnknownTokenAttachmentMode");

	internal static string UnsupportedTokenInclusionMode => GetResourceString("UnsupportedTokenInclusionMode");

	internal static string MismatchInSecurityOperationToken => GetResourceString("MismatchInSecurityOperationToken");

	internal static string ResolvingExternalTokensRequireSecurityTokenParameters => GetResourceString("ResolvingExternalTokensRequireSecurityTokenParameters");

	internal static string SecurityHeaderIsEmpty => GetResourceString("SecurityHeaderIsEmpty");

	internal static string AlgorithmAndPrivateKeyMisMatch => GetResourceString("AlgorithmAndPrivateKeyMisMatch");

	internal static string DuplicateTimestampInSecurityHeader => GetResourceString("DuplicateTimestampInSecurityHeader");

	internal static string EmptyOrNullArgumentString => GetResourceString("EmptyOrNullArgumentString");

	internal static string ErrorDeserializingKeyIdentifierClause => GetResourceString("ErrorDeserializingKeyIdentifierClause");

	internal static string InvalidX509RawData => GetResourceString("InvalidX509RawData");

	internal static string MissingPrivateKey => GetResourceString("MissingPrivateKey");

	internal static string NoKeyInfoClausesToWrite => GetResourceString("NoKeyInfoClausesToWrite");

	internal static string PrivateKeyNotSupported => GetResourceString("PrivateKeyNotSupported");

	internal static string UnableToResolveKeyReference => GetResourceString("UnableToResolveKeyReference");

	internal static string UnableToResolveTokenReference => GetResourceString("UnableToResolveTokenReference");

	internal static string UnsupportedCryptoAlgorithm => GetResourceString("UnsupportedCryptoAlgorithm");

	internal static string AlgorithmAndPublicKeyMisMatch => GetResourceString("AlgorithmAndPublicKeyMisMatch");

	internal static string PublicKeyNotSupported => GetResourceString("PublicKeyNotSupported");

	internal static string AtMostOneReferenceListIsSupportedWithDefaultPolicyCheck => GetResourceString("AtMostOneReferenceListIsSupportedWithDefaultPolicyCheck");

	internal static string CustomCryptoAlgorithmIsNotValidHashAlgorithm => GetResourceString("CustomCryptoAlgorithmIsNotValidHashAlgorithm");

	internal static string DuplicateIdInMessageToBeVerified => GetResourceString("DuplicateIdInMessageToBeVerified");

	internal static string ID6002 => GetResourceString("ID6002");

	internal static string ID6033 => GetResourceString("ID6033");

	internal static string MessageProtectionOrderMismatch => GetResourceString("MessageProtectionOrderMismatch");

	internal static string PrimarySignatureWasNotSignedByDerivedKey => GetResourceString("PrimarySignatureWasNotSignedByDerivedKey");

	internal static string PrimarySignatureWasNotSignedByDerivedWrappedKey => GetResourceString("PrimarySignatureWasNotSignedByDerivedWrappedKey");

	internal static string RequiredSecurityHeaderElementNotSigned => GetResourceString("RequiredSecurityHeaderElementNotSigned");

	internal static string RequiredSecurityTokenNotEncrypted => GetResourceString("RequiredSecurityTokenNotEncrypted");

	internal static string RequiredSecurityTokenNotSigned => GetResourceString("RequiredSecurityTokenNotSigned");

	internal static string BadCloseTarget => GetResourceString("BadCloseTarget");

	internal static string ChannelMustBeOpenedToGetSessionId => GetResourceString("ChannelMustBeOpenedToGetSessionId");

	internal static string CommunicationObjectCloseInterrupted1 => GetResourceString("CommunicationObjectCloseInterrupted1");

	internal static string ElementToSignMustHaveId => GetResourceString("ElementToSignMustHaveId");

	internal static string InvalidCloseResponseAction => GetResourceString("InvalidCloseResponseAction");

	internal static string InvalidRstRequestType => GetResourceString("InvalidRstRequestType");

	internal static string MoreThanOneRSTRInRSTRC => GetResourceString("MoreThanOneRSTRInRSTRC");

	internal static string NoCloseTargetSpecified => GetResourceString("NoCloseTargetSpecified");

	internal static string NoPartsOfMessageMatchedPartsToSign => GetResourceString("NoPartsOfMessageMatchedPartsToSign");

	internal static string SecuritySessionFaultReplyWasSent => GetResourceString("SecuritySessionFaultReplyWasSent");

	internal static string SessionKeyRenewalNotSupported => GetResourceString("SessionKeyRenewalNotSupported");

	internal static string SessionTokenIsNotGenericXmlToken => GetResourceString("SessionTokenIsNotGenericXmlToken");

	internal static string SessionTokenWasNotClosed => GetResourceString("SessionTokenWasNotClosed");

	internal static string TimeoutOnOperation => GetResourceString("TimeoutOnOperation");

	internal static string TimestampToSignHasNoId => GetResourceString("TimestampToSignHasNoId");

	internal static string TransportSecuredMessageHasMoreThanOneToHeader => GetResourceString("TransportSecuredMessageHasMoreThanOneToHeader");

	internal static string TransportSecurityRequireToHeader => GetResourceString("TransportSecurityRequireToHeader");

	internal static string UnableToCreateHashAlgorithmFromAsymmetricCrypto => GetResourceString("UnableToCreateHashAlgorithmFromAsymmetricCrypto");

	internal static string UnableToCreateKeyedHashAlgorithm => GetResourceString("UnableToCreateKeyedHashAlgorithm");

	internal static string UnableToRenewSessionKey => GetResourceString("UnableToRenewSessionKey");

	internal static string UnexpectedSecuritySessionClose => GetResourceString("UnexpectedSecuritySessionClose");

	internal static string UnexpectedSecuritySessionCloseResponse => GetResourceString("UnexpectedSecuritySessionCloseResponse");

	internal static string UnknownICryptoType => GetResourceString("UnknownICryptoType");

	internal static string UnsecuredMessageFaultReceived => GetResourceString("UnsecuredMessageFaultReceived");

	internal static string UnsupportedCanonicalizationAlgorithm => GetResourceString("UnsupportedCanonicalizationAlgorithm");

	internal static string ChannelNotOpen => GetResourceString("ChannelNotOpen");

	internal static string ReceiveTimedOut => GetResourceString("ReceiveTimedOut");

	internal static string ReceiveTimedOutNoLocalAddress => GetResourceString("ReceiveTimedOutNoLocalAddress");

	internal static string TimeoutOnSend => GetResourceString("TimeoutOnSend");

	internal static string CannotReadKeyIdentifierClause => GetResourceString("CannotReadKeyIdentifierClause");

	internal static string ErrorSerializingKeyIdentifier => GetResourceString("ErrorSerializingKeyIdentifier");

	internal static string ErrorSerializingKeyIdentifierClause => GetResourceString("ErrorSerializingKeyIdentifierClause");

	internal static string MessageSecurityVersionOutOfRange => GetResourceString("MessageSecurityVersionOutOfRange");

	internal static string PrivateKeyNotDSA => GetResourceString("PrivateKeyNotDSA");

	internal static string PrivateKeyNotRSA => GetResourceString("PrivateKeyNotRSA");

	internal static string PublicKeyNotDSA => GetResourceString("PublicKeyNotDSA");

	internal static string PublicKeyNotRSA => GetResourceString("PublicKeyNotRSA");

	internal static string StandardsManagerCannotWriteObject => GetResourceString("StandardsManagerCannotWriteObject");

	internal static string UnsupportedAlgorithmForCryptoOperation => GetResourceString("UnsupportedAlgorithmForCryptoOperation");

	internal static string DerivedKeyLengthSpecifiedInImplicitDerivedKeyClauseTooLong => GetResourceString("DerivedKeyLengthSpecifiedInImplicitDerivedKeyClauseTooLong");

	internal static string MultipleMatchingCryptosFound => GetResourceString("MultipleMatchingCryptosFound");

	internal static string UnableToDeriveKeyFromKeyInfoClause => GetResourceString("UnableToDeriveKeyFromKeyInfoClause");

	internal static string CannotFindMatchingCrypto => GetResourceString("CannotFindMatchingCrypto");

	internal static string DerivedKeyCannotDeriveFromSecret => GetResourceString("DerivedKeyCannotDeriveFromSecret");

	internal static string DerivedKeyLengthTooLong => GetResourceString("DerivedKeyLengthTooLong");

	internal static string DerivedKeyLimitExceeded => GetResourceString("DerivedKeyLimitExceeded");

	internal static string DerivedKeyPosAndGenBothSpecified => GetResourceString("DerivedKeyPosAndGenBothSpecified");

	internal static string DerivedKeyPosAndGenNotSpecified => GetResourceString("DerivedKeyPosAndGenNotSpecified");

	internal static string ExtendedProtectionPolicyCustomChannelBindingNotSupported => GetResourceString("ExtendedProtectionPolicyCustomChannelBindingNotSupported");

	internal static string CantInferReferenceForToken => GetResourceString("CantInferReferenceForToken");

	internal static string Remoting_SOAPInteropxsdInvalid => GetResourceString("Remoting_SOAPInteropxsdInvalid");

	internal static string SecurityTokenManagerCannotCreateSerializerForVersion => GetResourceString("SecurityTokenManagerCannotCreateSerializerForVersion");

	internal static string TransportBindingElementNotFound => GetResourceString("TransportBindingElementNotFound");

	internal static string UnknownEncodingInBinarySecurityToken => GetResourceString("UnknownEncodingInBinarySecurityToken");

	internal static string UnsupportedPasswordType => GetResourceString("UnsupportedPasswordType");

	internal static string BootstrapSecurityBindingElementNotSet => GetResourceString("BootstrapSecurityBindingElementNotSet");

	internal static string IssuerBuildContextNotSet => GetResourceString("IssuerBuildContextNotSet");

	internal static string SecurityAlgorithmSuiteNotSet => GetResourceString("SecurityAlgorithmSuiteNotSet");

	internal static string TargetAddressIsNotSet => GetResourceString("TargetAddressIsNotSet");

	internal static string TokenProviderRequiresSecurityBindingElement => GetResourceString("TokenProviderRequiresSecurityBindingElement");

	internal static string BadSecurityNegotiationContext => GetResourceString("BadSecurityNegotiationContext");

	internal static string CannotObtainIssuedTokenKeySize => GetResourceString("CannotObtainIssuedTokenKeySize");

	internal static string ClientSecurityNegotiationTimeout => GetResourceString("ClientSecurityNegotiationTimeout");

	internal static string ClientSecuritySessionRequestTimeout => GetResourceString("ClientSecuritySessionRequestTimeout");

	internal static string FailToReceiveReplyFromNegotiation => GetResourceString("FailToReceiveReplyFromNegotiation");

	internal static string InvalidActionForNegotiationMessage => GetResourceString("InvalidActionForNegotiationMessage");

	internal static string InvalidIssuedTokenKeySize => GetResourceString("InvalidIssuedTokenKeySize");

	internal static string InvalidRenewResponseAction => GetResourceString("InvalidRenewResponseAction");

	internal static string IssuerBindingNotPresentInTokenRequirement => GetResourceString("IssuerBindingNotPresentInTokenRequirement");

	internal static string KeyLengthMustBeMultipleOfEight => GetResourceString("KeyLengthMustBeMultipleOfEight");

	internal static string NegotiationIsCompleted => GetResourceString("NegotiationIsCompleted");

	internal static string NegotiationIsNotCompleted => GetResourceString("NegotiationIsNotCompleted");

	internal static string NoNegotiationMessageToSend => GetResourceString("NoNegotiationMessageToSend");

	internal static string SecurityEndpointNotFound => GetResourceString("SecurityEndpointNotFound");

	internal static string SecurityNegotiationCannotProtectConfidentialEndpointHeader => GetResourceString("SecurityNegotiationCannotProtectConfidentialEndpointHeader");

	internal static string SecurityServerTooBusy => GetResourceString("SecurityServerTooBusy");

	internal static string SoapSecurityNegotiationFailed => GetResourceString("SoapSecurityNegotiationFailed");

	internal static string SoapSecurityNegotiationFailedForIssuerAndTarget => GetResourceString("SoapSecurityNegotiationFailedForIssuerAndTarget");

	internal static string BadIssuedTokenType => GetResourceString("BadIssuedTokenType");

	internal static string BearerKeyTypeCannotHaveProofKey => GetResourceString("BearerKeyTypeCannotHaveProofKey");

	internal static string DerivedKeyInvalidGenerationSpecified => GetResourceString("DerivedKeyInvalidGenerationSpecified");

	internal static string DerivedKeyInvalidOffsetSpecified => GetResourceString("DerivedKeyInvalidOffsetSpecified");

	internal static string DerivedKeyTokenLabelTooLong => GetResourceString("DerivedKeyTokenLabelTooLong");

	internal static string DerivedKeyTokenNonceTooLong => GetResourceString("DerivedKeyTokenNonceTooLong");

	internal static string DerivedKeyTokenRequiresTokenReference => GetResourceString("DerivedKeyTokenRequiresTokenReference");

	internal static string EntropyModeCannotHaveComputedKey => GetResourceString("EntropyModeCannotHaveComputedKey");

	internal static string EntropyModeCannotHaveProofTokenOrIssuerEntropy => GetResourceString("EntropyModeCannotHaveProofTokenOrIssuerEntropy");

	internal static string EntropyModeCannotHaveRequestorEntropy => GetResourceString("EntropyModeCannotHaveRequestorEntropy");

	internal static string EntropyModeRequiresComputedKey => GetResourceString("EntropyModeRequiresComputedKey");

	internal static string EntropyModeRequiresIssuerEntropy => GetResourceString("EntropyModeRequiresIssuerEntropy");

	internal static string EntropyModeRequiresProofToken => GetResourceString("EntropyModeRequiresProofToken");

	internal static string EntropyModeRequiresRequestorEntropy => GetResourceString("EntropyModeRequiresRequestorEntropy");

	internal static string ErrorSerializingSecurityToken => GetResourceString("ErrorSerializingSecurityToken");

	internal static string InvalidKeyLengthRequested => GetResourceString("InvalidKeyLengthRequested");

	internal static string InvalidKeySizeSpecifiedInNegotiation => GetResourceString("InvalidKeySizeSpecifiedInNegotiation");

	internal static string NoLicenseXml => GetResourceString("NoLicenseXml");

	internal static string NoRequestSecurityTokenResponseElements => GetResourceString("NoRequestSecurityTokenResponseElements");

	internal static string RstrHasMultipleIssuedTokens => GetResourceString("RstrHasMultipleIssuedTokens");

	internal static string RstrHasMultipleProofTokens => GetResourceString("RstrHasMultipleProofTokens");

	internal static string RstrKeySizeNotProvided => GetResourceString("RstrKeySizeNotProvided");

	internal static string TokenCannotCreateSymmetricCrypto => GetResourceString("TokenCannotCreateSymmetricCrypto");

	internal static string TrustDriverIsUnableToCreatedNecessaryAttachedOrUnattachedReferences => GetResourceString("TrustDriverIsUnableToCreatedNecessaryAttachedOrUnattachedReferences");

	internal static string UnexpectedBinarySecretType => GetResourceString("UnexpectedBinarySecretType");

	internal static string UnknownComputedKeyAlgorithm => GetResourceString("UnknownComputedKeyAlgorithm");

	internal static string UnknownEncodingInKeyIdentifier => GetResourceString("UnknownEncodingInKeyIdentifier");

	internal static string UnsupportedBinaryEncoding => GetResourceString("UnsupportedBinaryEncoding");

	internal static string UnsupportedIssuerEntropyType => GetResourceString("UnsupportedIssuerEntropyType");

	internal static string UnsupportedKeyDerivationAlgorithm => GetResourceString("UnsupportedKeyDerivationAlgorithm");

	internal static string BasicTokenNotExpected => GetResourceString("BasicTokenNotExpected");

	internal static string CustomCryptoAlgorithmIsNotValidKeyedHashAlgorithm => GetResourceString("CustomCryptoAlgorithmIsNotValidKeyedHashAlgorithm");

	internal static string SignedSupportingTokenNotExpected => GetResourceString("SignedSupportingTokenNotExpected");

	internal static string TokenManagerCouldNotReadToken => GetResourceString("TokenManagerCouldNotReadToken");

	internal static string UnableToFindTokenAuthenticator => GetResourceString("UnableToFindTokenAuthenticator");

	internal static string UnableToResolveKeyInfoClauseInDerivedKeyToken => GetResourceString("UnableToResolveKeyInfoClauseInDerivedKeyToken");

	internal static string UnknownTokenAuthenticatorUsedInTokenProcessing => GetResourceString("UnknownTokenAuthenticatorUsedInTokenProcessing");

	internal static string BasicHttpMessageSecurityRequiresCertificate => GetResourceString("BasicHttpMessageSecurityRequiresCertificate");

	internal static string NoCookieInSct => GetResourceString("NoCookieInSct");

	internal static string NoSecurityContextIdentifier => GetResourceString("NoSecurityContextIdentifier");

	internal static string SecurityContextNotRegistered => GetResourceString("SecurityContextNotRegistered");

	internal static string AcksToMustBeSameAsRemoteAddress => GetResourceString("AcksToMustBeSameAsRemoteAddress");

	internal static string AcksToMustBeSameAsRemoteAddressReason => GetResourceString("AcksToMustBeSameAsRemoteAddressReason");

	internal static string CloseOutputSessionErrorReason => GetResourceString("CloseOutputSessionErrorReason");

	internal static string CouldNotParseWithAction => GetResourceString("CouldNotParseWithAction");

	internal static string CSRefused => GetResourceString("CSRefused");

	internal static string CSRefusedAcksToMustEqualEndpoint => GetResourceString("CSRefusedAcksToMustEqualEndpoint");

	internal static string CSRefusedAcksToMustEqualReplyTo => GetResourceString("CSRefusedAcksToMustEqualReplyTo");

	internal static string CSRefusedInvalidIncompleteSequenceBehavior => GetResourceString("CSRefusedInvalidIncompleteSequenceBehavior");

	internal static string CSRefusedNoSTRWSSecurity => GetResourceString("CSRefusedNoSTRWSSecurity");

	internal static string CSRefusedRequiredSecurityElementMissing => GetResourceString("CSRefusedRequiredSecurityElementMissing");

	internal static string CSRefusedSSLNotSupported => GetResourceString("CSRefusedSSLNotSupported");

	internal static string CSRefusedSTRNoWSSecurity => GetResourceString("CSRefusedSTRNoWSSecurity");

	internal static string CSRefusedUnexpectedElementAtEndOfCSMessage => GetResourceString("CSRefusedUnexpectedElementAtEndOfCSMessage");

	internal static string CSResponseOfferRejected => GetResourceString("CSResponseOfferRejected");

	internal static string CSResponseOfferRejectedReason => GetResourceString("CSResponseOfferRejectedReason");

	internal static string CSResponseWithInvalidIncompleteSequenceBehavior => GetResourceString("CSResponseWithInvalidIncompleteSequenceBehavior");

	internal static string CSResponseWithOffer => GetResourceString("CSResponseWithOffer");

	internal static string CSResponseWithOfferReason => GetResourceString("CSResponseWithOfferReason");

	internal static string CSResponseWithoutOffer => GetResourceString("CSResponseWithoutOffer");

	internal static string CSResponseWithoutOfferReason => GetResourceString("CSResponseWithoutOfferReason");

	internal static string EarlySecurityClose => GetResourceString("EarlySecurityClose");

	internal static string EarlySecurityFaulted => GetResourceString("EarlySecurityFaulted");

	internal static string EarlyTerminateSequence => GetResourceString("EarlyTerminateSequence");

	internal static string InconsistentLastMsgNumberExceptionString => GetResourceString("InconsistentLastMsgNumberExceptionString");

	internal static string InvalidAcknowledgementFaultReason => GetResourceString("InvalidAcknowledgementFaultReason");

	internal static string InvalidAcknowledgementReceived => GetResourceString("InvalidAcknowledgementReceived");

	internal static string InvalidBufferRemaining => GetResourceString("InvalidBufferRemaining");

	internal static string InvalidSequenceNumber => GetResourceString("InvalidSequenceNumber");

	internal static string InvalidSequenceRange => GetResourceString("InvalidSequenceRange");

	internal static string InvalidWsrmResponseChannelNotOpened => GetResourceString("InvalidWsrmResponseChannelNotOpened");

	internal static string InvalidWsrmResponseSessionFaultedExceptionString => GetResourceString("InvalidWsrmResponseSessionFaultedExceptionString");

	internal static string InvalidWsrmResponseSessionFaultedFaultString => GetResourceString("InvalidWsrmResponseSessionFaultedFaultString");

	internal static string LastMessageNumberExceeded => GetResourceString("LastMessageNumberExceeded");

	internal static string LastMessageNumberExceededFaultReason => GetResourceString("LastMessageNumberExceededFaultReason");

	internal static string ManualAddressingNotSupported => GetResourceString("ManualAddressingNotSupported");

	internal static string MaximumRetryCountExceeded => GetResourceString("MaximumRetryCountExceeded");

	internal static string MessageExceptionOccurred => GetResourceString("MessageExceptionOccurred");

	internal static string MessageNumberRollover => GetResourceString("MessageNumberRollover");

	internal static string MessageNumberRolloverFaultReason => GetResourceString("MessageNumberRolloverFaultReason");

	internal static string MissingFinalAckExceptionString => GetResourceString("MissingFinalAckExceptionString");

	internal static string MissingMessageIdOnWsrmRequest => GetResourceString("MissingMessageIdOnWsrmRequest");

	internal static string MissingRelatesToOnWsrmResponseReason => GetResourceString("MissingRelatesToOnWsrmResponseReason");

	internal static string MissingReplyToOnWsrmRequest => GetResourceString("MissingReplyToOnWsrmRequest");

	internal static string NoActionNoSequenceHeaderReason => GetResourceString("NoActionNoSequenceHeaderReason");

	internal static string NonEmptyWsrmMessageIsEmpty => GetResourceString("NonEmptyWsrmMessageIsEmpty");

	internal static string NonWsrmFeb2005ActionNotSupported => GetResourceString("NonWsrmFeb2005ActionNotSupported");

	internal static string ReceivedResponseBeforeRequestExceptionString => GetResourceString("ReceivedResponseBeforeRequestExceptionString");

	internal static string ReceivedResponseBeforeRequestFaultString => GetResourceString("ReceivedResponseBeforeRequestFaultString");

	internal static string ReplyMissingAcknowledgement => GetResourceString("ReplyMissingAcknowledgement");

	internal static string SecureConversationRequiredByReliableSession => GetResourceString("SecureConversationRequiredByReliableSession");

	internal static string SequenceClosedFaultString => GetResourceString("SequenceClosedFaultString");

	internal static string SequenceTerminatedAddLastToWindowTimedOut => GetResourceString("SequenceTerminatedAddLastToWindowTimedOut");

	internal static string SequenceTerminatedEarlyTerminateSequence => GetResourceString("SequenceTerminatedEarlyTerminateSequence");

	internal static string SequenceTerminatedInactivityTimeoutExceeded => GetResourceString("SequenceTerminatedInactivityTimeoutExceeded");

	internal static string SequenceTerminatedInconsistentLastMsgNumber => GetResourceString("SequenceTerminatedInconsistentLastMsgNumber");

	internal static string SequenceTerminatedMaximumRetryCountExceeded => GetResourceString("SequenceTerminatedMaximumRetryCountExceeded");

	internal static string SequenceTerminatedMissingFinalAck => GetResourceString("SequenceTerminatedMissingFinalAck");

	internal static string SequenceTerminatedOnAbort => GetResourceString("SequenceTerminatedOnAbort");

	internal static string SequenceTerminatedQuotaExceededException => GetResourceString("SequenceTerminatedQuotaExceededException");

	internal static string SequenceTerminatedReliableRequestThrew => GetResourceString("SequenceTerminatedReliableRequestThrew");

	internal static string SequenceTerminatedReplyMissingAcknowledgement => GetResourceString("SequenceTerminatedReplyMissingAcknowledgement");

	internal static string SequenceTerminatedSessionClosedBeforeDone => GetResourceString("SequenceTerminatedSessionClosedBeforeDone");

	internal static string SequenceTerminatedSmallLastMsgNumber => GetResourceString("SequenceTerminatedSmallLastMsgNumber");

	internal static string SequenceTerminatedUnexpectedAckRequested => GetResourceString("SequenceTerminatedUnexpectedAckRequested");

	internal static string SequenceTerminatedUnexpectedCloseSequenceResponse => GetResourceString("SequenceTerminatedUnexpectedCloseSequenceResponse");

	internal static string SequenceTerminatedUnexpectedCS => GetResourceString("SequenceTerminatedUnexpectedCS");

	internal static string SequenceTerminatedUnexpectedCSROfferId => GetResourceString("SequenceTerminatedUnexpectedCSROfferId");

	internal static string SequenceTerminatedUnexpectedTerminateSequence => GetResourceString("SequenceTerminatedUnexpectedTerminateSequence");

	internal static string SequenceTerminatedUnknownAddToWindowError => GetResourceString("SequenceTerminatedUnknownAddToWindowError");

	internal static string SequenceTerminatedUnsupportedClose => GetResourceString("SequenceTerminatedUnsupportedClose");

	internal static string SequenceTerminatedUnsupportedTerminateSequence => GetResourceString("SequenceTerminatedUnsupportedTerminateSequence");

	internal static string SessionClosedBeforeDone => GetResourceString("SessionClosedBeforeDone");

	internal static string SmallLastMsgNumberExceptionString => GetResourceString("SmallLastMsgNumberExceptionString");

	internal static string TimeoutOnAddToWindow => GetResourceString("TimeoutOnAddToWindow");

	internal static string TimeoutOnClose => GetResourceString("TimeoutOnClose");

	internal static string TraceCodeWsrmNegativeElapsedTimeDetected => GetResourceString("TraceCodeWsrmNegativeElapsedTimeDetected");

	internal static string TransferModeNotSupported => GetResourceString("TransferModeNotSupported");

	internal static string UnexpectedAckRequested => GetResourceString("UnexpectedAckRequested");

	internal static string UnexpectedCloseSequenceResponse => GetResourceString("UnexpectedCloseSequenceResponse");

	internal static string UnexpectedCS => GetResourceString("UnexpectedCS");

	internal static string UnexpectedCSROfferId => GetResourceString("UnexpectedCSROfferId");

	internal static string UnexpectedTerminateSequence => GetResourceString("UnexpectedTerminateSequence");

	internal static string UnknownSequenceFaultReason => GetResourceString("UnknownSequenceFaultReason");

	internal static string UnknownSequenceFaultReceived => GetResourceString("UnknownSequenceFaultReceived");

	internal static string UnknownSequenceMessageReceived => GetResourceString("UnknownSequenceMessageReceived");

	internal static string UnparsableCSResponse => GetResourceString("UnparsableCSResponse");

	internal static string UnrecognizedFaultReceived => GetResourceString("UnrecognizedFaultReceived");

	internal static string UnrecognizedFaultReceivedOnOpen => GetResourceString("UnrecognizedFaultReceivedOnOpen");

	internal static string UnsupportedCloseExceptionString => GetResourceString("UnsupportedCloseExceptionString");

	internal static string UnsupportedTerminateSequenceExceptionString => GetResourceString("UnsupportedTerminateSequenceExceptionString");

	internal static string WrongIdentifierFault => GetResourceString("WrongIdentifierFault");

	internal static string WsrmFaultReceived => GetResourceString("WsrmFaultReceived");

	internal static string WsrmMessageProcessingError => GetResourceString("WsrmMessageProcessingError");

	internal static string WsrmMessageWithWrongRelatesToExceptionString => GetResourceString("WsrmMessageWithWrongRelatesToExceptionString");

	internal static string WsrmMessageWithWrongRelatesToFaultString => GetResourceString("WsrmMessageWithWrongRelatesToFaultString");

	internal static string WsrmRequestIncorrectReplyToExceptionString => GetResourceString("WsrmRequestIncorrectReplyToExceptionString");

	internal static string WsrmRequestIncorrectReplyToFaultString => GetResourceString("WsrmRequestIncorrectReplyToFaultString");

	internal static string WsrmRequiredExceptionString => GetResourceString("WsrmRequiredExceptionString");

	internal static string WsrmRequiredFaultString => GetResourceString("WsrmRequiredFaultString");

	internal static string BindingRequirementsAttributeDisallowsQueuedDelivery1 => GetResourceString("BindingRequirementsAttributeDisallowsQueuedDelivery1");

	internal static string BindingRequirementsAttributeRequiresQueuedDelivery1 => GetResourceString("BindingRequirementsAttributeRequiresQueuedDelivery1");

	internal static string SinceTheBindingForDoesnTSupportIBindingCapabilities1_1 => GetResourceString("SinceTheBindingForDoesnTSupportIBindingCapabilities1_1");

	internal static string SinceTheBindingForDoesnTSupportIBindingCapabilities2_1 => GetResourceString("SinceTheBindingForDoesnTSupportIBindingCapabilities2_1");

	internal static string TheBindingForDoesnTSupportOrderedDelivery1 => GetResourceString("TheBindingForDoesnTSupportOrderedDelivery1");

	internal static string HttpsExplicitIdentity => GetResourceString("HttpsExplicitIdentity");

	internal static string HttpsIdentityMultipleCerts => GetResourceString("HttpsIdentityMultipleCerts");

	internal static string OnlyDefaultSpnServiceSupported => GetResourceString("OnlyDefaultSpnServiceSupported");

	internal static string MtomBoundaryInvalid => GetResourceString("MtomBoundaryInvalid");

	internal static string MtomBufferQuotaExceeded => GetResourceString("MtomBufferQuotaExceeded");

	internal static string MtomContentTransferEncodingNotPresent => GetResourceString("MtomContentTransferEncodingNotPresent");

	internal static string MtomContentTransferEncodingNotSupported => GetResourceString("MtomContentTransferEncodingNotSupported");

	internal static string MtomContentTypeInvalid => GetResourceString("MtomContentTypeInvalid");

	internal static string MtomDataMustNotContainXopInclude => GetResourceString("MtomDataMustNotContainXopInclude");

	internal static string MtomExceededMaxSizeInBytes => GetResourceString("MtomExceededMaxSizeInBytes");

	internal static string MtomInvalidCIDUri => GetResourceString("MtomInvalidCIDUri");

	internal static string MtomInvalidEmptyURI => GetResourceString("MtomInvalidEmptyURI");

	internal static string MtomInvalidStartUri => GetResourceString("MtomInvalidStartUri");

	internal static string MtomInvalidTransferEncodingForMimePart => GetResourceString("MtomInvalidTransferEncodingForMimePart");

	internal static string MtomMessageContentTypeNotFound => GetResourceString("MtomMessageContentTypeNotFound");

	internal static string MtomMessageInvalidContent => GetResourceString("MtomMessageInvalidContent");

	internal static string MtomMessageInvalidContentInMimePart => GetResourceString("MtomMessageInvalidContentInMimePart");

	internal static string MtomMessageInvalidMimeVersion => GetResourceString("MtomMessageInvalidMimeVersion");

	internal static string MtomMessageNotApplicationXopXml => GetResourceString("MtomMessageNotApplicationXopXml");

	internal static string MtomMessageNotMultipart => GetResourceString("MtomMessageNotMultipart");

	internal static string MtomMessageRequiredParamNotSpecified => GetResourceString("MtomMessageRequiredParamNotSpecified");

	internal static string MtomMimePartReferencedMoreThanOnce => GetResourceString("MtomMimePartReferencedMoreThanOnce");

	internal static string MtomPartNotFound => GetResourceString("MtomPartNotFound");

	internal static string MtomRootContentTypeNotFound => GetResourceString("MtomRootContentTypeNotFound");

	internal static string MtomRootNotApplicationXopXml => GetResourceString("MtomRootNotApplicationXopXml");

	internal static string MtomRootPartNotFound => GetResourceString("MtomRootPartNotFound");

	internal static string MtomRootRequiredParamNotSpecified => GetResourceString("MtomRootRequiredParamNotSpecified");

	internal static string MtomRootUnexpectedCharset => GetResourceString("MtomRootUnexpectedCharset");

	internal static string MtomRootUnexpectedType => GetResourceString("MtomRootUnexpectedType");

	internal static string MtomXopIncludeHrefNotSpecified => GetResourceString("MtomXopIncludeHrefNotSpecified");

	internal static string MtomXopIncludeInvalidXopAttributes => GetResourceString("MtomXopIncludeInvalidXopAttributes");

	internal static string MtomXopIncludeInvalidXopElement => GetResourceString("MtomXopIncludeInvalidXopElement");

	internal static string XmlInvalidBinHexSequence => GetResourceString("XmlInvalidBinHexSequence");

	internal static string XmlInvalidBinHexLength => GetResourceString("XmlInvalidBinHexLength");

	internal static string XmlArrayTooSmall => GetResourceString("XmlArrayTooSmall");

	internal static string XmlMaxStringContentLengthExceeded => GetResourceString("XmlMaxStringContentLengthExceeded");

	internal static string XmlLineInfo => GetResourceString("XmlLineInfo");

	internal static string MimeContentTypeHeaderInvalid => GetResourceString("MimeContentTypeHeaderInvalid");

	internal static string MimeHeaderInvalidCharacter => GetResourceString("MimeHeaderInvalidCharacter");

	internal static string MimeMessageGetContentStreamCalledAlready => GetResourceString("MimeMessageGetContentStreamCalledAlready");

	internal static string MaxMimePartsExceeded => GetResourceString("MaxMimePartsExceeded");

	internal static string MimeReaderHeaderAlreadyExists => GetResourceString("MimeReaderHeaderAlreadyExists");

	internal static string MimeReaderMalformedHeader => GetResourceString("MimeReaderMalformedHeader");

	internal static string MimeReaderResetCalledBeforeEOF => GetResourceString("MimeReaderResetCalledBeforeEOF");

	internal static string MimeReaderTruncated => GetResourceString("MimeReaderTruncated");

	internal static string MimeVersionHeaderInvalid => GetResourceString("MimeVersionHeaderInvalid");

	internal static string MimeWriterInvalidStateForClose => GetResourceString("MimeWriterInvalidStateForClose");

	internal static string MimeWriterInvalidStateForHeader => GetResourceString("MimeWriterInvalidStateForHeader");

	internal static string MimeWriterInvalidStateForContent => GetResourceString("MimeWriterInvalidStateForContent");

	internal static string MimeWriterInvalidStateForStartPart => GetResourceString("MimeWriterInvalidStateForStartPart");

	internal static string MimeWriterInvalidStateForStartPreface => GetResourceString("MimeWriterInvalidStateForStartPreface");

	internal static string ReadNotSupportedOnStream => GetResourceString("ReadNotSupportedOnStream");

	internal static string SeekNotSupportedOnStream => GetResourceString("SeekNotSupportedOnStream");

	internal static string WriteBufferOverflow => GetResourceString("WriteBufferOverflow");

	internal static string WriteNotSupportedOnStream => GetResourceString("WriteNotSupportedOnStream");

	internal static string XmlWriterClosed => GetResourceString("XmlWriterClosed");

	internal static string MtomEncoderBadMessageVersion => GetResourceString("MtomEncoderBadMessageVersion");

	internal static string SFxErrorCreatingMtomReader => GetResourceString("SFxErrorCreatingMtomReader");

	internal static string SFxImmutableClientBaseCacheSetting => GetResourceString("SFxImmutableClientBaseCacheSetting");

	internal static string SFxMessageContractAttributeRequired => GetResourceString("SFxMessageContractAttributeRequired");

	internal static string SFxActionMismatch => GetResourceString("SFxActionMismatch");

	internal static string SFxNullReplyFromExtension2 => GetResourceString("SFxNullReplyFromExtension2");

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool UsingResourceKeys()
	{
		return false;
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static string GetResourceString(string resourceKey, string defaultValue = null)
	{
		return ResourceManager.GetString(resourceKey, Culture);
	}
}
