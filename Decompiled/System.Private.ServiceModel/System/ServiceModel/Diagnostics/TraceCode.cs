namespace System.ServiceModel.Diagnostics;

internal static class TraceCode
{
	public const int Administration = 65536;

	public const int WmiPut = 65537;

	public const int Diagnostics = 131072;

	public const int AppDomainUnload = 131073;

	public const int EventLog = 131074;

	public const int ThrowingException = 131075;

	public const int TraceHandledException = 131076;

	public const int UnhandledException = 131077;

	public const int FailedToAddAnActivityIdHeader = 131078;

	public const int FailedToReadAnActivityIdHeader = 131079;

	public const int FilterNotMatchedNodeQuotaExceeded = 131080;

	public const int MessageCountLimitExceeded = 131081;

	public const int DiagnosticsFailedMessageTrace = 131082;

	public const int MessageNotLoggedQuotaExceeded = 131083;

	public const int TraceTruncatedQuotaExceeded = 131084;

	public const int ActivityBoundary = 131085;

	public const int Serialization = 196608;

	public const int ElementIgnored = 196615;

	public const int Channels = 262144;

	public const int ConnectionAbandoned = 262145;

	public const int ConnectionPoolCloseException = 262146;

	public const int ConnectionPoolIdleTimeoutReached = 262147;

	public const int ConnectionPoolLeaseTimeoutReached = 262148;

	public const int ConnectionPoolMaxOutboundConnectionsPerEndpointQuotaReached = 262149;

	public const int ServerMaxPooledConnectionsQuotaReached = 262150;

	public const int EndpointListenerClose = 262151;

	public const int EndpointListenerOpen = 262152;

	public const int HttpResponseReceived = 262153;

	public const int HttpChannelConcurrentReceiveQuotaReached = 262154;

	public const int HttpChannelMessageReceiveFailed = 262155;

	public const int HttpChannelUnexpectedResponse = 262156;

	public const int HttpChannelRequestAborted = 262157;

	public const int HttpChannelResponseAborted = 262158;

	public const int HttpsClientCertificateInvalid = 262159;

	public const int HttpsClientCertificateNotPresent = 262160;

	public const int NamedPipeChannelMessageReceiveFailed = 262161;

	public const int NamedPipeChannelMessageReceived = 262162;

	public const int MessageReceived = 262163;

	public const int MessageSent = 262164;

	public const int RequestChannelReplyReceived = 262165;

	public const int TcpChannelMessageReceiveFailed = 262166;

	public const int TcpChannelMessageReceived = 262167;

	public const int ConnectToIPEndpoint = 262168;

	public const int SocketConnectionCreate = 262169;

	public const int SocketConnectionClose = 262170;

	public const int SocketConnectionAbort = 262171;

	public const int SocketConnectionAbortClose = 262172;

	public const int PipeConnectionAbort = 262173;

	public const int RequestContextAbort = 262174;

	public const int ChannelCreated = 262175;

	public const int ChannelDisposed = 262176;

	public const int ListenerCreated = 262177;

	public const int ListenerDisposed = 262178;

	public const int PrematureDatagramEof = 262179;

	public const int MaxPendingConnectionsReached = 262180;

	public const int MaxAcceptedChannelsReached = 262181;

	public const int ChannelConnectionDropped = 262182;

	public const int HttpAuthFailed = 262183;

	public const int NoExistingTransportManager = 262184;

	public const int IncompatibleExistingTransportManager = 262185;

	public const int InitiatingNamedPipeConnection = 262186;

	public const int InitiatingTcpConnection = 262187;

	public const int OpenedListener = 262188;

	public const int SslClientCertMissing = 262189;

	public const int StreamSecurityUpgradeAccepted = 262190;

	public const int TcpConnectError = 262191;

	public const int FailedAcceptFromPool = 262192;

	public const int FailedPipeConnect = 262193;

	public const int SystemTimeResolution = 262194;

	public const int PeerNeighborCloseFailed = 262195;

	public const int PeerNeighborClosingFailed = 262196;

	public const int PeerNeighborNotAccepted = 262197;

	public const int PeerNeighborNotFound = 262198;

	public const int PeerNeighborOpenFailed = 262199;

	public const int PeerNeighborStateChanged = 262200;

	public const int PeerNeighborStateChangeFailed = 262201;

	public const int PeerNeighborMessageReceived = 262202;

	public const int PeerNeighborManagerOffline = 262203;

	public const int PeerNeighborManagerOnline = 262204;

	public const int PeerChannelMessageReceived = 262205;

	public const int PeerChannelMessageSent = 262206;

	public const int PeerNodeAddressChanged = 262207;

	public const int PeerNodeOpening = 262208;

	public const int PeerNodeOpened = 262209;

	public const int PeerNodeOpenFailed = 262210;

	public const int PeerNodeClosing = 262211;

	public const int PeerNodeClosed = 262212;

	public const int PeerFloodedMessageReceived = 262213;

	public const int PeerFloodedMessageNotPropagated = 262214;

	public const int PeerFloodedMessageNotMatched = 262215;

	public const int PnrpRegisteredAddresses = 262216;

	public const int PnrpUnregisteredAddresses = 262217;

	public const int PnrpResolvedAddresses = 262218;

	public const int PnrpResolveException = 262219;

	public const int PeerReceiveMessageAuthenticationFailure = 262220;

	public const int PeerNodeAuthenticationFailure = 262221;

	public const int PeerNodeAuthenticationTimeout = 262222;

	public const int PeerFlooderReceiveMessageQuotaExceeded = 262223;

	public const int PeerServiceOpened = 262224;

	public const int PeerMaintainerActivity = 262225;

	public const int WsrmNegativeElapsedTimeDetected = 262254;

	public const int TcpTransferError = 262255;

	public const int TcpConnectionResetError = 262256;

	public const int TcpConnectionTimedOut = 262257;

	public const int ComIntegration = 327680;

	public const int ComIntegrationServiceHostStartingService = 327681;

	public const int ComIntegrationServiceHostStartedService = 327682;

	public const int ComIntegrationServiceHostCreatedServiceContract = 327683;

	public const int ComIntegrationServiceHostStartedServiceDetails = 327684;

	public const int ComIntegrationServiceHostCreatedServiceEndpoint = 327685;

	public const int ComIntegrationServiceHostStoppingService = 327686;

	public const int ComIntegrationServiceHostStoppedService = 327687;

	public const int ComIntegrationDllHostInitializerStarting = 327688;

	public const int ComIntegrationDllHostInitializerAddingHost = 327689;

	public const int ComIntegrationDllHostInitializerStarted = 327690;

	public const int ComIntegrationDllHostInitializerStopping = 327691;

	public const int ComIntegrationDllHostInitializerStopped = 327692;

	public const int ComIntegrationTLBImportStarting = 327693;

	public const int ComIntegrationTLBImportFromAssembly = 327694;

	public const int ComIntegrationTLBImportFromTypelib = 327695;

	public const int ComIntegrationTLBImportConverterEvent = 327696;

	public const int ComIntegrationTLBImportFinished = 327697;

	public const int ComIntegrationInstanceCreationRequest = 327698;

	public const int ComIntegrationInstanceCreationSuccess = 327699;

	public const int ComIntegrationInstanceReleased = 327700;

	public const int ComIntegrationEnteringActivity = 327701;

	public const int ComIntegrationExecutingCall = 327702;

	public const int ComIntegrationLeftActivity = 327703;

	public const int ComIntegrationInvokingMethod = 327704;

	public const int ComIntegrationInvokedMethod = 327705;

	public const int ComIntegrationInvokingMethodNewTransaction = 327706;

	public const int ComIntegrationInvokingMethodContextTransaction = 327707;

	public const int ComIntegrationServiceMonikerParsed = 327708;

	public const int ComIntegrationWsdlChannelBuilderLoaded = 327709;

	public const int ComIntegrationTypedChannelBuilderLoaded = 327710;

	public const int ComIntegrationChannelCreated = 327711;

	public const int ComIntegrationDispatchMethod = 327712;

	public const int ComIntegrationTxProxyTxCommitted = 327713;

	public const int ComIntegrationTxProxyTxAbortedByContext = 327714;

	public const int ComIntegrationTxProxyTxAbortedByTM = 327715;

	public const int ComIntegrationMexMonikerMetadataExchangeComplete = 327716;

	public const int ComIntegrationMexChannelBuilderLoaded = 327717;

	public const int Security = 458752;

	public const int SecurityIdentityVerificationSuccess = 458753;

	public const int SecurityIdentityVerificationFailure = 458754;

	public const int SecurityIdentityDeterminationSuccess = 458755;

	public const int SecurityIdentityDeterminationFailure = 458756;

	public const int SecurityIdentityHostNameNormalizationFailure = 458757;

	public const int SecurityImpersonationSuccess = 458758;

	public const int SecurityImpersonationFailure = 458759;

	public const int SecurityNegotiationProcessingFailure = 458760;

	public const int IssuanceTokenProviderRemovedCachedToken = 458761;

	public const int IssuanceTokenProviderUsingCachedToken = 458762;

	public const int IssuanceTokenProviderBeginSecurityNegotiation = 458763;

	public const int IssuanceTokenProviderEndSecurityNegotiation = 458764;

	public const int IssuanceTokenProviderRedirectApplied = 458765;

	public const int IssuanceTokenProviderServiceTokenCacheFull = 458766;

	public const int NegotiationTokenProviderAttached = 458767;

	public const int SpnegoClientNegotiationCompleted = 458784;

	public const int SpnegoServiceNegotiationCompleted = 458785;

	public const int SpnegoClientNegotiation = 458786;

	public const int SpnegoServiceNegotiation = 458787;

	public const int NegotiationAuthenticatorAttached = 458788;

	public const int ServiceSecurityNegotiationCompleted = 458789;

	public const int SecurityContextTokenCacheFull = 458790;

	public const int ExportSecurityChannelBindingEntry = 458791;

	public const int ExportSecurityChannelBindingExit = 458792;

	public const int ImportSecurityChannelBindingEntry = 458793;

	public const int ImportSecurityChannelBindingExit = 458794;

	public const int SecurityTokenProviderOpened = 458795;

	public const int SecurityTokenProviderClosed = 458796;

	public const int SecurityTokenAuthenticatorOpened = 458797;

	public const int SecurityTokenAuthenticatorClosed = 458798;

	public const int SecurityBindingOutgoingMessageSecured = 458799;

	public const int SecurityBindingIncomingMessageVerified = 458800;

	public const int SecurityBindingSecureOutgoingMessageFailure = 458801;

	public const int SecurityBindingVerifyIncomingMessageFailure = 458802;

	public const int SecuritySpnToSidMappingFailure = 458803;

	public const int SecuritySessionRedirectApplied = 458804;

	public const int SecurityClientSessionCloseSent = 458805;

	public const int SecurityClientSessionCloseResponseSent = 458806;

	public const int SecurityClientSessionCloseMessageReceived = 458807;

	public const int SecuritySessionKeyRenewalFaultReceived = 458808;

	public const int SecuritySessionAbortedFaultReceived = 458809;

	public const int SecuritySessionClosedResponseReceived = 458810;

	public const int SecurityClientSessionPreviousKeyDiscarded = 458811;

	public const int SecurityClientSessionKeyRenewed = 458812;

	public const int SecurityPendingServerSessionAdded = 458813;

	public const int SecurityPendingServerSessionClosed = 458814;

	public const int SecurityPendingServerSessionActivated = 458815;

	public const int SecurityActiveServerSessionRemoved = 458816;

	public const int SecurityNewServerSessionKeyIssued = 458817;

	public const int SecurityInactiveSessionFaulted = 458818;

	public const int SecurityServerSessionKeyUpdated = 458819;

	public const int SecurityServerSessionCloseReceived = 458820;

	public const int SecurityServerSessionRenewalFaultSent = 458821;

	public const int SecurityServerSessionAbortedFaultSent = 458822;

	public const int SecuritySessionCloseResponseSent = 458823;

	public const int SecuritySessionServerCloseSent = 458824;

	public const int SecurityServerSessionCloseResponseReceived = 458825;

	public const int SecuritySessionRenewFaultSendFailure = 458826;

	public const int SecuritySessionAbortedFaultSendFailure = 458827;

	public const int SecuritySessionClosedResponseSendFailure = 458828;

	public const int SecuritySessionServerCloseSendFailure = 458829;

	public const int SecuritySessionRequestorStartOperation = 458830;

	public const int SecuritySessionRequestorOperationSuccess = 458831;

	public const int SecuritySessionRequestorOperationFailure = 458832;

	public const int SecuritySessionResponderOperationFailure = 458833;

	public const int SecuritySessionDemuxFailure = 458834;

	public const int SecurityAuditWrittenSuccess = 458835;

	public const int SecurityAuditWrittenFailure = 458836;

	public const int ServiceModel = 524288;

	public const int AsyncCallbackThrewException = 524289;

	public const int CommunicationObjectAborted = 524290;

	public const int CommunicationObjectAbortFailed = 524291;

	public const int CommunicationObjectCloseFailed = 524292;

	public const int CommunicationObjectOpenFailed = 524293;

	public const int CommunicationObjectClosing = 524294;

	public const int CommunicationObjectClosed = 524295;

	public const int CommunicationObjectCreated = 524296;

	public const int CommunicationObjectDisposing = 524297;

	public const int CommunicationObjectFaultReason = 524298;

	public const int CommunicationObjectFaulted = 524299;

	public const int CommunicationObjectOpening = 524300;

	public const int CommunicationObjectOpened = 524301;

	public const int DidNotUnderstandMessageHeader = 524302;

	public const int UnderstoodMessageHeader = 524303;

	public const int MessageClosed = 524304;

	public const int MessageClosedAgain = 524305;

	public const int MessageCopied = 524306;

	public const int MessageRead = 524307;

	public const int MessageWritten = 524308;

	public const int BeginExecuteMethod = 524309;

	public const int ConfigurationIsReadOnly = 524310;

	public const int ConfiguredExtensionTypeNotFound = 524311;

	public const int EvaluationContextNotFound = 524312;

	public const int EndExecuteMethod = 524313;

	public const int ExtensionCollectionDoesNotExist = 524314;

	public const int ExtensionCollectionNameNotFound = 524315;

	public const int ExtensionCollectionIsEmpty = 524316;

	public const int ExtensionElementAlreadyExistsInCollection = 524317;

	public const int ElementTypeDoesntMatchConfiguredType = 524318;

	public const int ErrorInvokingUserCode = 524319;

	public const int GetBehaviorElement = 524320;

	public const int GetCommonBehaviors = 524321;

	public const int GetConfiguredBinding = 524322;

	public const int GetChannelEndpointElement = 524323;

	public const int GetConfigurationSection = 524324;

	public const int GetDefaultConfiguredBinding = 524325;

	public const int GetServiceElement = 524326;

	public const int MessageProcessingPaused = 524327;

	public const int ManualFlowThrottleLimitReached = 524328;

	public const int OverridingDuplicateConfigurationKey = 524329;

	public const int RemoveBehavior = 524330;

	public const int ServiceChannelLifetime = 524331;

	public const int ServiceHostCreation = 524332;

	public const int ServiceHostBaseAddresses = 524333;

	public const int ServiceHostTimeoutOnClose = 524334;

	public const int ServiceHostFaulted = 524335;

	public const int ServiceHostErrorOnReleasePerformanceCounter = 524336;

	public const int ServiceThrottleLimitReached = 524337;

	public const int ServiceOperationMissingReply = 524338;

	public const int ServiceOperationMissingReplyContext = 524339;

	public const int ServiceOperationExceptionOnReply = 524340;

	public const int SkipBehavior = 524341;

	public const int TransportListen = 524342;

	public const int UnhandledAction = 524343;

	public const int PerformanceCounterFailedToLoad = 524344;

	public const int PerformanceCountersFailed = 524345;

	public const int PerformanceCountersFailedDuringUpdate = 524346;

	public const int PerformanceCountersFailedForService = 524347;

	public const int PerformanceCountersFailedOnRelease = 524348;

	public const int WsmexNonCriticalWsdlExportError = 524349;

	public const int WsmexNonCriticalWsdlImportError = 524350;

	public const int FailedToOpenIncomingChannel = 524351;

	public const int UnhandledExceptionInUserOperation = 524352;

	public const int DroppedAMessage = 524353;

	public const int CannotBeImportedInCurrentFormat = 524354;

	public const int GetConfiguredEndpoint = 524355;

	public const int GetDefaultConfiguredEndpoint = 524356;

	public const int ExtensionTypeNotFound = 524357;

	public const int DefaultEndpointsAdded = 524358;

	public const int MetadataExchangeClientSendRequest = 524379;

	public const int MetadataExchangeClientReceiveReply = 524380;

	public const int WarnHelpPageEnabledNoBaseAddress = 524381;

	public const int PortSharing = 655360;

	public const int PortSharingClosed = 655361;

	public const int PortSharingDuplicatedPipe = 655362;

	public const int PortSharingDupHandleGranted = 655363;

	public const int PortSharingDuplicatedSocket = 655364;

	public const int PortSharingListening = 655365;

	public const int SharedManagerServiceEndpointNotExist = 655374;

	public const int ServiceModelTransaction = 917504;

	public const int TxSourceTxScopeRequiredIsTransactedTransport = 917505;

	public const int TxSourceTxScopeRequiredIsTransactionFlow = 917506;

	public const int TxSourceTxScopeRequiredIsAttachedTransaction = 917507;

	public const int TxSourceTxScopeRequiredIsCreateNewTransaction = 917508;

	public const int TxCompletionStatusCompletedForAutocomplete = 917509;

	public const int TxCompletionStatusCompletedForError = 917510;

	public const int TxCompletionStatusCompletedForSetComplete = 917511;

	public const int TxCompletionStatusCompletedForTACOSC = 917512;

	public const int TxCompletionStatusCompletedForAsyncAbort = 917513;

	public const int TxCompletionStatusRemainsAttached = 917514;

	public const int TxCompletionStatusAbortedOnSessionClose = 917515;

	public const int TxReleaseServiceInstanceOnCompletion = 917516;

	public const int TxAsyncAbort = 917517;

	public const int TxFailedToNegotiateOleTx = 917518;

	public const int TxSourceTxScopeRequiredUsingExistingTransaction = 917519;

	public const int NetFx35 = 983040;

	public const int ActivatingMessageReceived = 983040;

	public const int InstanceContextBoundToDurableInstance = 983041;

	public const int InstanceContextDetachedFromDurableInstance = 983042;

	public const int ContextChannelFactoryChannelCreated = 983043;

	public const int ContextChannelListenerChannelAccepted = 983044;

	public const int ContextProtocolContextAddedToMessage = 983045;

	public const int ContextProtocolContextRetrievedFromMessage = 983046;

	public const int DICPInstanceContextCached = 983047;

	public const int DICPInstanceContextRemovedFromCache = 983048;

	public const int ServiceDurableInstanceDeleted = 983049;

	public const int ServiceDurableInstanceDisposed = 983050;

	public const int ServiceDurableInstanceLoaded = 983051;

	public const int ServiceDurableInstanceSaved = 983052;

	public const int SqlPersistenceProviderSQLCallStart = 983053;

	public const int SqlPersistenceProviderSQLCallEnd = 983054;

	public const int SqlPersistenceProviderOpenParameters = 983055;

	public const int SyncContextSchedulerServiceTimerCancelled = 983056;

	public const int SyncContextSchedulerServiceTimerCreated = 983057;

	public const int WorkflowDurableInstanceLoaded = 983058;

	public const int WorkflowDurableInstanceAborted = 983059;

	public const int WorkflowDurableInstanceActivated = 983060;

	public const int WorkflowOperationInvokerItemQueued = 983061;

	public const int WorkflowRequestContextReplySent = 983062;

	public const int WorkflowRequestContextFaultSent = 983063;

	public const int WorkflowServiceHostCreated = 983064;

	public const int SyndicationReadFeedBegin = 983065;

	public const int SyndicationReadFeedEnd = 983066;

	public const int SyndicationReadItemBegin = 983067;

	public const int SyndicationReadItemEnd = 983068;

	public const int SyndicationWriteFeedBegin = 983069;

	public const int SyndicationWriteFeedEnd = 983070;

	public const int SyndicationWriteItemBegin = 983071;

	public const int SyndicationWriteItemEnd = 983072;

	public const int SyndicationProtocolElementIgnoredOnRead = 983073;

	public const int SyndicationProtocolElementIgnoredOnWrite = 983074;

	public const int SyndicationProtocolElementInvalid = 983075;

	public const int WebUnknownQueryParameterIgnored = 983076;

	public const int WebRequestMatchesOperation = 983077;

	public const int WebRequestDoesNotMatchOperations = 983078;

	public const int WebRequestRedirect = 983079;

	public const int SyndicationReadServiceDocumentBegin = 983080;

	public const int SyndicationReadServiceDocumentEnd = 983081;

	public const int SyndicationReadCategoriesDocumentBegin = 983082;

	public const int SyndicationReadCategoriesDocumentEnd = 983083;

	public const int SyndicationWriteServiceDocumentBegin = 983084;

	public const int SyndicationWriteServiceDocumentEnd = 983085;

	public const int SyndicationWriteCategoriesDocumentBegin = 983086;

	public const int SyndicationWriteCategoriesDocumentEnd = 983087;

	public const int AutomaticFormatSelectedOperationDefault = 983088;

	public const int AutomaticFormatSelectedRequestBased = 983089;

	public const int RequestFormatSelectedFromContentTypeMapper = 983090;

	public const int RequestFormatSelectedByEncoderDefaults = 983091;

	public const int AddingResponseToOutputCache = 983092;

	public const int AddingAuthenticatedResponseToOutputCache = 983093;

	public const int JsonpCallbackNameSet = 983095;
}
