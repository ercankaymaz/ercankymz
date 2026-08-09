using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class StatusCodes
{
	public const uint Good = 0u;

	public const uint Uncertain = 1073741824u;

	public const uint Bad = 2147483648u;

	public const uint BadUnexpectedError = 2147549184u;

	public const uint BadInternalError = 2147614720u;

	public const uint BadOutOfMemory = 2147680256u;

	public const uint BadResourceUnavailable = 2147745792u;

	public const uint BadCommunicationError = 2147811328u;

	public const uint BadEncodingError = 2147876864u;

	public const uint BadDecodingError = 2147942400u;

	public const uint BadEncodingLimitsExceeded = 2148007936u;

	public const uint BadRequestTooLarge = 2159542272u;

	public const uint BadResponseTooLarge = 2159607808u;

	public const uint BadUnknownResponse = 2148073472u;

	public const uint BadTimeout = 2148139008u;

	public const uint BadServiceUnsupported = 2148204544u;

	public const uint BadShutdown = 2148270080u;

	public const uint BadServerNotConnected = 2148335616u;

	public const uint BadServerHalted = 2148401152u;

	public const uint BadNothingToDo = 2148466688u;

	public const uint BadTooManyOperations = 2148532224u;

	public const uint BadTooManyMonitoredItems = 2161836032u;

	public const uint BadDataTypeIdUnknown = 2148597760u;

	public const uint BadCertificateInvalid = 2148663296u;

	public const uint BadSecurityChecksFailed = 2148728832u;

	public const uint BadCertificatePolicyCheckFailed = 2165571584u;

	public const uint BadCertificateTimeInvalid = 2148794368u;

	public const uint BadCertificateIssuerTimeInvalid = 2148859904u;

	public const uint BadCertificateHostNameInvalid = 2148925440u;

	public const uint BadCertificateUriInvalid = 2148990976u;

	public const uint BadCertificateUseNotAllowed = 2149056512u;

	public const uint BadCertificateIssuerUseNotAllowed = 2149122048u;

	public const uint BadCertificateUntrusted = 2149187584u;

	public const uint BadCertificateRevocationUnknown = 2149253120u;

	public const uint BadCertificateIssuerRevocationUnknown = 2149318656u;

	public const uint BadCertificateRevoked = 2149384192u;

	public const uint BadCertificateIssuerRevoked = 2149449728u;

	public const uint BadCertificateChainIncomplete = 2165112832u;

	public const uint BadUserAccessDenied = 2149515264u;

	public const uint BadIdentityTokenInvalid = 2149580800u;

	public const uint BadIdentityTokenRejected = 2149646336u;

	public const uint BadSecureChannelIdInvalid = 2149711872u;

	public const uint BadInvalidTimestamp = 2149777408u;

	public const uint BadNonceInvalid = 2149842944u;

	public const uint BadSessionIdInvalid = 2149908480u;

	public const uint BadSessionClosed = 2149974016u;

	public const uint BadSessionNotActivated = 2150039552u;

	public const uint BadSubscriptionIdInvalid = 2150105088u;

	public const uint BadRequestHeaderInvalid = 2150236160u;

	public const uint BadTimestampsToReturnInvalid = 2150301696u;

	public const uint BadRequestCancelledByClient = 2150367232u;

	public const uint BadTooManyArguments = 2162491392u;

	public const uint BadLicenseExpired = 2165178368u;

	public const uint BadLicenseLimitsExceeded = 2165243904u;

	public const uint BadLicenseNotAvailable = 2165309440u;

	public const uint BadServerTooBusy = 2163081216u;

	public const uint GoodPasswordChangeRequired = 15663104u;

	public const uint GoodSubscriptionTransferred = 2949120u;

	public const uint GoodCompletesAsynchronously = 3014656u;

	public const uint GoodOverload = 3080192u;

	public const uint GoodClamped = 3145728u;

	public const uint BadNoCommunication = 2150694912u;

	public const uint BadWaitingForInitialData = 2150760448u;

	public const uint BadNodeIdInvalid = 2150825984u;

	public const uint BadNodeIdUnknown = 2150891520u;

	public const uint BadAttributeIdInvalid = 2150957056u;

	public const uint BadIndexRangeInvalid = 2151022592u;

	public const uint BadIndexRangeNoData = 2151088128u;

	public const uint BadIndexRangeDataMismatch = 2162819072u;

	public const uint BadDataEncodingInvalid = 2151153664u;

	public const uint BadDataEncodingUnsupported = 2151219200u;

	public const uint BadNotReadable = 2151284736u;

	public const uint BadNotWritable = 2151350272u;

	public const uint BadOutOfRange = 2151415808u;

	public const uint BadNotSupported = 2151481344u;

	public const uint BadNotFound = 2151546880u;

	public const uint BadObjectDeleted = 2151612416u;

	public const uint BadNotImplemented = 2151677952u;

	public const uint BadMonitoringModeInvalid = 2151743488u;

	public const uint BadMonitoredItemIdInvalid = 2151809024u;

	public const uint BadMonitoredItemFilterInvalid = 2151874560u;

	public const uint BadMonitoredItemFilterUnsupported = 2151940096u;

	public const uint BadFilterNotAllowed = 2152005632u;

	public const uint BadStructureMissing = 2152071168u;

	public const uint BadEventFilterInvalid = 2152136704u;

	public const uint BadContentFilterInvalid = 2152202240u;

	public const uint BadFilterOperatorInvalid = 2160132096u;

	public const uint BadFilterOperatorUnsupported = 2160197632u;

	public const uint BadFilterOperandCountMismatch = 2160263168u;

	public const uint BadFilterOperandInvalid = 2152267776u;

	public const uint BadFilterElementInvalid = 2160328704u;

	public const uint BadFilterLiteralInvalid = 2160394240u;

	public const uint BadContinuationPointInvalid = 2152333312u;

	public const uint BadNoContinuationPoints = 2152398848u;

	public const uint BadReferenceTypeIdInvalid = 2152464384u;

	public const uint BadBrowseDirectionInvalid = 2152529920u;

	public const uint BadNodeNotInView = 2152595456u;

	public const uint BadNumericOverflow = 2165440512u;

	public const uint BadLocaleNotSupported = 2163015680u;

	public const uint BadServerUriInvalid = 2152660992u;

	public const uint BadServerNameMissing = 2152726528u;

	public const uint BadDiscoveryUrlMissing = 2152792064u;

	public const uint BadSempahoreFileMissing = 2152857600u;

	public const uint BadRequestTypeInvalid = 2152923136u;

	public const uint BadSecurityModeRejected = 2152988672u;

	public const uint BadSecurityPolicyRejected = 2153054208u;

	public const uint BadTooManySessions = 2153119744u;

	public const uint BadUserSignatureInvalid = 2153185280u;

	public const uint BadApplicationSignatureInvalid = 2153250816u;

	public const uint BadNoValidCertificates = 2153316352u;

	public const uint BadIdentityChangeNotSupported = 2160459776u;

	public const uint BadRequestCancelledByRequest = 2153381888u;

	public const uint BadParentNodeIdInvalid = 2153447424u;

	public const uint BadReferenceNotAllowed = 2153512960u;

	public const uint BadNodeIdRejected = 2153578496u;

	public const uint BadNodeIdExists = 2153644032u;

	public const uint BadNodeClassInvalid = 2153709568u;

	public const uint BadBrowseNameInvalid = 2153775104u;

	public const uint BadBrowseNameDuplicated = 2153840640u;

	public const uint BadNodeAttributesInvalid = 2153906176u;

	public const uint BadTypeDefinitionInvalid = 2153971712u;

	public const uint BadSourceNodeIdInvalid = 2154037248u;

	public const uint BadTargetNodeIdInvalid = 2154102784u;

	public const uint BadDuplicateReferenceNotAllowed = 2154168320u;

	public const uint BadInvalidSelfReference = 2154233856u;

	public const uint BadReferenceLocalOnly = 2154299392u;

	public const uint BadNoDeleteRights = 2154364928u;

	public const uint UncertainReferenceNotDeleted = 1086062592u;

	public const uint BadServerIndexInvalid = 2154430464u;

	public const uint BadViewIdUnknown = 2154496000u;

	public const uint BadViewTimestampInvalid = 2160656384u;

	public const uint BadViewParameterMismatch = 2160721920u;

	public const uint BadViewVersionInvalid = 2160787456u;

	public const uint UncertainNotAllNodesAvailable = 1086324736u;

	public const uint GoodResultsMayBeIncomplete = 12189696u;

	public const uint BadNotTypeDefinition = 2160590848u;

	public const uint UncertainReferenceOutOfServer = 1080819712u;

	public const uint BadTooManyMatches = 2154627072u;

	public const uint BadQueryTooComplex = 2154692608u;

	public const uint BadNoMatch = 2154758144u;

	public const uint BadMaxAgeInvalid = 2154823680u;

	public const uint BadSecurityModeInsufficient = 2162556928u;

	public const uint BadHistoryOperationInvalid = 2154889216u;

	public const uint BadHistoryOperationUnsupported = 2154954752u;

	public const uint BadInvalidTimestampArgument = 2159869952u;

	public const uint BadWriteNotSupported = 2155020288u;

	public const uint BadTypeMismatch = 2155085824u;

	public const uint BadMethodInvalid = 2155151360u;

	public const uint BadArgumentsMissing = 2155216896u;

	public const uint BadNotExecutable = 2165374976u;

	public const uint BadTooManySubscriptions = 2155282432u;

	public const uint BadTooManyPublishRequests = 2155347968u;

	public const uint BadNoSubscription = 2155413504u;

	public const uint BadSequenceNumberUnknown = 2155479040u;

	public const uint GoodRetransmissionQueueNotSupported = 14614528u;

	public const uint BadMessageNotAvailable = 2155544576u;

	public const uint BadInsufficientClientProfile = 2155610112u;

	public const uint BadStateNotActive = 2160001024u;

	public const uint BadAlreadyExists = 2165637120u;

	public const uint BadTcpServerTooBusy = 2155675648u;

	public const uint BadTcpMessageTypeInvalid = 2155741184u;

	public const uint BadTcpSecureChannelUnknown = 2155806720u;

	public const uint BadTcpMessageTooLarge = 2155872256u;

	public const uint BadTcpNotEnoughResources = 2155937792u;

	public const uint BadTcpInternalError = 2156003328u;

	public const uint BadTcpEndpointUrlInvalid = 2156068864u;

	public const uint BadRequestInterrupted = 2156134400u;

	public const uint BadRequestTimeout = 2156199936u;

	public const uint BadSecureChannelClosed = 2156265472u;

	public const uint BadSecureChannelTokenUnknown = 2156331008u;

	public const uint BadSequenceNumberInvalid = 2156396544u;

	public const uint BadProtocolVersionUnsupported = 2159935488u;

	public const uint BadConfigurationError = 2156462080u;

	public const uint BadNotConnected = 2156527616u;

	public const uint BadDeviceFailure = 2156593152u;

	public const uint BadSensorFailure = 2156658688u;

	public const uint BadOutOfService = 2156724224u;

	public const uint BadDeadbandFilterInvalid = 2156789760u;

	public const uint UncertainNoCommunicationLastUsableValue = 1083113472u;

	public const uint UncertainLastUsableValue = 1083179008u;

	public const uint UncertainSubstituteValue = 1083244544u;

	public const uint UncertainInitialValue = 1083310080u;

	public const uint UncertainSensorNotAccurate = 1083375616u;

	public const uint UncertainEngineeringUnitsExceeded = 1083441152u;

	public const uint UncertainSubNormal = 1083506688u;

	public const uint GoodLocalOverride = 9830400u;

	public const uint GoodSubNormal = 15400960u;

	public const uint BadRefreshInProgress = 2157379584u;

	public const uint BadConditionAlreadyDisabled = 2157445120u;

	public const uint BadConditionAlreadyEnabled = 2160852992u;

	public const uint BadConditionDisabled = 2157510656u;

	public const uint BadEventIdUnknown = 2157576192u;

	public const uint BadEventNotAcknowledgeable = 2159738880u;

	public const uint BadDialogNotActive = 2160918528u;

	public const uint BadDialogResponseInvalid = 2160984064u;

	public const uint BadConditionBranchAlreadyAcked = 2161049600u;

	public const uint BadConditionBranchAlreadyConfirmed = 2161115136u;

	public const uint BadConditionAlreadyShelved = 2161180672u;

	public const uint BadConditionNotShelved = 2161246208u;

	public const uint BadShelvingTimeOutOfRange = 2161311744u;

	public const uint BadNoData = 2157641728u;

	public const uint BadBoundNotFound = 2161573888u;

	public const uint BadBoundNotSupported = 2161639424u;

	public const uint BadDataLost = 2157772800u;

	public const uint BadDataUnavailable = 2157838336u;

	public const uint BadEntryExists = 2157903872u;

	public const uint BadNoEntryExists = 2157969408u;

	public const uint BadTimestampNotSupported = 2158034944u;

	public const uint GoodEntryInserted = 10616832u;

	public const uint GoodEntryReplaced = 10682368u;

	public const uint UncertainDataSubNormal = 1084489728u;

	public const uint GoodNoData = 10813440u;

	public const uint GoodMoreData = 10878976u;

	public const uint BadAggregateListMismatch = 2161377280u;

	public const uint BadAggregateNotSupported = 2161442816u;

	public const uint BadAggregateInvalidInputs = 2161508352u;

	public const uint BadAggregateConfigurationRejected = 2161770496u;

	public const uint GoodDataIgnored = 14221312u;

	public const uint BadRequestNotAllowed = 2162425856u;

	public const uint BadRequestNotComplete = 2165506048u;

	public const uint BadTransactionPending = 2162688000u;

	public const uint BadTicketRequired = 2166292480u;

	public const uint BadTicketInvalid = 2166358016u;

	public const uint BadLocked = 2162753536u;

	public const uint BadRequiresLock = 2162950144u;

	public const uint GoodEdited = 14417920u;

	public const uint GoodPostActionFailed = 14483456u;

	public const uint UncertainDominantValueChanged = 1088290816u;

	public const uint GoodDependentValueChanged = 14680064u;

	public const uint BadDominantValueChanged = 2162229248u;

	public const uint UncertainDependentValueChanged = 1088552960u;

	public const uint BadDependentValueChanged = 2162360320u;

	public const uint GoodEdited_DependentValueChanged = 18219008u;

	public const uint GoodEdited_DominantValueChanged = 18284544u;

	public const uint GoodEdited_DominantValueChanged_DependentValueChanged = 18350080u;

	public const uint BadEdited_OutOfRange = 2165899264u;

	public const uint BadInitialValue_OutOfRange = 2165964800u;

	public const uint BadOutOfRange_DominantValueChanged = 2166030336u;

	public const uint BadEdited_OutOfRange_DominantValueChanged = 2166095872u;

	public const uint BadOutOfRange_DominantValueChanged_DependentValueChanged = 2166161408u;

	public const uint BadEdited_OutOfRange_DominantValueChanged_DependentValueChanged = 2166226944u;

	public const uint GoodCommunicationEvent = 10944512u;

	public const uint GoodShutdownEvent = 11010048u;

	public const uint GoodCallAgain = 11075584u;

	public const uint GoodNonCriticalTimeout = 11141120u;

	public const uint BadInvalidArgument = 2158690304u;

	public const uint BadConnectionRejected = 2158755840u;

	public const uint BadDisconnect = 2158821376u;

	public const uint BadConnectionClosed = 2158886912u;

	public const uint BadInvalidState = 2158952448u;

	public const uint BadEndOfStream = 2159017984u;

	public const uint BadNoDataAvailable = 2159083520u;

	public const uint BadWaitingForResponse = 2159149056u;

	public const uint BadOperationAbandoned = 2159214592u;

	public const uint BadExpectedStreamToBlock = 2159280128u;

	public const uint BadWouldBlock = 2159345664u;

	public const uint BadSyntaxError = 2159411200u;

	public const uint BadMaxConnectionsReached = 2159476736u;

	public const uint UncertainTransducerInManual = 1107820544u;

	public const uint UncertainSimulatedValue = 1107886080u;

	public const uint UncertainSensorCalibration = 1107951616u;

	public const uint UncertainConfigurationError = 1108279296u;

	public const uint GoodCascadeInitializationAcknowledged = 67174400u;

	public const uint GoodCascadeInitializationRequest = 67239936u;

	public const uint GoodCascadeNotInvited = 67305472u;

	public const uint GoodCascadeNotSelected = 67371008u;

	public const uint GoodFaultStateActive = 67567616u;

	public const uint GoodInitiateFaultState = 67633152u;

	public const uint GoodCascade = 67698688u;

	public const uint BadDataSetIdInvalid = 2162622464u;

	public static string GetBrowseName(uint identifier)
	{
		FieldInfo[] fields = typeof(StatusCodes).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (identifier == (uint)fieldInfo.GetValue(typeof(StatusCodes)))
			{
				return fieldInfo.Name;
			}
		}
		return string.Empty;
	}

	public static string[] GetBrowseNames()
	{
		FieldInfo[] fields = typeof(StatusCodes).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		string[] array = new string[fields.Length];
		FieldInfo[] array2 = fields;
		foreach (FieldInfo fieldInfo in array2)
		{
			array[num++] = fieldInfo.Name;
		}
		return array;
	}

	public static uint GetIdentifier(string browseName)
	{
		FieldInfo[] fields = typeof(StatusCodes).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.Name == browseName)
			{
				return (uint)fieldInfo.GetValue(typeof(StatusCodes));
			}
		}
		return 0u;
	}
}
