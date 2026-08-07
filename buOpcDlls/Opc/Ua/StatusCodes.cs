// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StatusCodes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class StatusCodes
{
  public const uint Good = 0;
  public const uint Uncertain = 1073741824 /*0x40000000*/;
  public const uint Bad = 2147483648 /*0x80000000*/;
  public const uint BadUnexpectedError = 2147549184 /*0x80010000*/;
  public const uint BadInternalError = 2147614720 /*0x80020000*/;
  public const uint BadOutOfMemory = 2147680256 /*0x80030000*/;
  public const uint BadResourceUnavailable = 2147745792 /*0x80040000*/;
  public const uint BadCommunicationError = 2147811328 /*0x80050000*/;
  public const uint BadEncodingError = 2147876864 /*0x80060000*/;
  public const uint BadDecodingError = 2147942400 /*0x80070000*/;
  public const uint BadEncodingLimitsExceeded = 2148007936 /*0x80080000*/;
  public const uint BadRequestTooLarge = 2159542272 /*0x80B80000*/;
  public const uint BadResponseTooLarge = 2159607808 /*0x80B90000*/;
  public const uint BadUnknownResponse = 2148073472 /*0x80090000*/;
  public const uint BadTimeout = 2148139008 /*0x800A0000*/;
  public const uint BadServiceUnsupported = 2148204544 /*0x800B0000*/;
  public const uint BadShutdown = 2148270080 /*0x800C0000*/;
  public const uint BadServerNotConnected = 2148335616 /*0x800D0000*/;
  public const uint BadServerHalted = 2148401152 /*0x800E0000*/;
  public const uint BadNothingToDo = 2148466688 /*0x800F0000*/;
  public const uint BadTooManyOperations = 2148532224 /*0x80100000*/;
  public const uint BadTooManyMonitoredItems = 2161836032 /*0x80DB0000*/;
  public const uint BadDataTypeIdUnknown = 2148597760 /*0x80110000*/;
  public const uint BadCertificateInvalid = 2148663296 /*0x80120000*/;
  public const uint BadSecurityChecksFailed = 2148728832 /*0x80130000*/;
  public const uint BadCertificatePolicyCheckFailed = 2165571584;
  public const uint BadCertificateTimeInvalid = 2148794368 /*0x80140000*/;
  public const uint BadCertificateIssuerTimeInvalid = 2148859904 /*0x80150000*/;
  public const uint BadCertificateHostNameInvalid = 2148925440 /*0x80160000*/;
  public const uint BadCertificateUriInvalid = 2148990976 /*0x80170000*/;
  public const uint BadCertificateUseNotAllowed = 2149056512 /*0x80180000*/;
  public const uint BadCertificateIssuerUseNotAllowed = 2149122048 /*0x80190000*/;
  public const uint BadCertificateUntrusted = 2149187584 /*0x801A0000*/;
  public const uint BadCertificateRevocationUnknown = 2149253120 /*0x801B0000*/;
  public const uint BadCertificateIssuerRevocationUnknown = 2149318656 /*0x801C0000*/;
  public const uint BadCertificateRevoked = 2149384192 /*0x801D0000*/;
  public const uint BadCertificateIssuerRevoked = 2149449728 /*0x801E0000*/;
  public const uint BadCertificateChainIncomplete = 2165112832 /*0x810D0000*/;
  public const uint BadUserAccessDenied = 2149515264 /*0x801F0000*/;
  public const uint BadIdentityTokenInvalid = 2149580800 /*0x80200000*/;
  public const uint BadIdentityTokenRejected = 2149646336 /*0x80210000*/;
  public const uint BadSecureChannelIdInvalid = 2149711872 /*0x80220000*/;
  public const uint BadInvalidTimestamp = 2149777408 /*0x80230000*/;
  public const uint BadNonceInvalid = 2149842944 /*0x80240000*/;
  public const uint BadSessionIdInvalid = 2149908480 /*0x80250000*/;
  public const uint BadSessionClosed = 2149974016 /*0x80260000*/;
  public const uint BadSessionNotActivated = 2150039552 /*0x80270000*/;
  public const uint BadSubscriptionIdInvalid = 2150105088 /*0x80280000*/;
  public const uint BadRequestHeaderInvalid = 2150236160 /*0x802A0000*/;
  public const uint BadTimestampsToReturnInvalid = 2150301696 /*0x802B0000*/;
  public const uint BadRequestCancelledByClient = 2150367232 /*0x802C0000*/;
  public const uint BadTooManyArguments = 2162491392 /*0x80E50000*/;
  public const uint BadLicenseExpired = 2165178368 /*0x810E0000*/;
  public const uint BadLicenseLimitsExceeded = 2165243904 /*0x810F0000*/;
  public const uint BadLicenseNotAvailable = 2165309440 /*0x81100000*/;
  public const uint BadServerTooBusy = 2163081216 /*0x80EE0000*/;
  public const uint GoodPasswordChangeRequired = 15663104 /*0xEF0000*/;
  public const uint GoodSubscriptionTransferred = 2949120 /*0x2D0000*/;
  public const uint GoodCompletesAsynchronously = 3014656 /*0x2E0000*/;
  public const uint GoodOverload = 3080192 /*0x2F0000*/;
  public const uint GoodClamped = 3145728 /*0x300000*/;
  public const uint BadNoCommunication = 2150694912 /*0x80310000*/;
  public const uint BadWaitingForInitialData = 2150760448 /*0x80320000*/;
  public const uint BadNodeIdInvalid = 2150825984 /*0x80330000*/;
  public const uint BadNodeIdUnknown = 2150891520 /*0x80340000*/;
  public const uint BadAttributeIdInvalid = 2150957056 /*0x80350000*/;
  public const uint BadIndexRangeInvalid = 2151022592 /*0x80360000*/;
  public const uint BadIndexRangeNoData = 2151088128 /*0x80370000*/;
  public const uint BadIndexRangeDataMismatch = 2162819072 /*0x80EA0000*/;
  public const uint BadDataEncodingInvalid = 2151153664 /*0x80380000*/;
  public const uint BadDataEncodingUnsupported = 2151219200 /*0x80390000*/;
  public const uint BadNotReadable = 2151284736 /*0x803A0000*/;
  public const uint BadNotWritable = 2151350272 /*0x803B0000*/;
  public const uint BadOutOfRange = 2151415808 /*0x803C0000*/;
  public const uint BadNotSupported = 2151481344 /*0x803D0000*/;
  public const uint BadNotFound = 2151546880 /*0x803E0000*/;
  public const uint BadObjectDeleted = 2151612416 /*0x803F0000*/;
  public const uint BadNotImplemented = 2151677952 /*0x80400000*/;
  public const uint BadMonitoringModeInvalid = 2151743488 /*0x80410000*/;
  public const uint BadMonitoredItemIdInvalid = 2151809024 /*0x80420000*/;
  public const uint BadMonitoredItemFilterInvalid = 2151874560 /*0x80430000*/;
  public const uint BadMonitoredItemFilterUnsupported = 2151940096 /*0x80440000*/;
  public const uint BadFilterNotAllowed = 2152005632 /*0x80450000*/;
  public const uint BadStructureMissing = 2152071168 /*0x80460000*/;
  public const uint BadEventFilterInvalid = 2152136704 /*0x80470000*/;
  public const uint BadContentFilterInvalid = 2152202240 /*0x80480000*/;
  public const uint BadFilterOperatorInvalid = 2160132096 /*0x80C10000*/;
  public const uint BadFilterOperatorUnsupported = 2160197632 /*0x80C20000*/;
  public const uint BadFilterOperandCountMismatch = 2160263168 /*0x80C30000*/;
  public const uint BadFilterOperandInvalid = 2152267776 /*0x80490000*/;
  public const uint BadFilterElementInvalid = 2160328704 /*0x80C40000*/;
  public const uint BadFilterLiteralInvalid = 2160394240 /*0x80C50000*/;
  public const uint BadContinuationPointInvalid = 2152333312 /*0x804A0000*/;
  public const uint BadNoContinuationPoints = 2152398848 /*0x804B0000*/;
  public const uint BadReferenceTypeIdInvalid = 2152464384 /*0x804C0000*/;
  public const uint BadBrowseDirectionInvalid = 2152529920 /*0x804D0000*/;
  public const uint BadNodeNotInView = 2152595456 /*0x804E0000*/;
  public const uint BadNumericOverflow = 2165440512;
  public const uint BadLocaleNotSupported = 2163015680 /*0x80ED0000*/;
  public const uint BadServerUriInvalid = 2152660992 /*0x804F0000*/;
  public const uint BadServerNameMissing = 2152726528 /*0x80500000*/;
  public const uint BadDiscoveryUrlMissing = 2152792064 /*0x80510000*/;
  public const uint BadSempahoreFileMissing = 2152857600 /*0x80520000*/;
  public const uint BadRequestTypeInvalid = 2152923136 /*0x80530000*/;
  public const uint BadSecurityModeRejected = 2152988672 /*0x80540000*/;
  public const uint BadSecurityPolicyRejected = 2153054208 /*0x80550000*/;
  public const uint BadTooManySessions = 2153119744 /*0x80560000*/;
  public const uint BadUserSignatureInvalid = 2153185280 /*0x80570000*/;
  public const uint BadApplicationSignatureInvalid = 2153250816 /*0x80580000*/;
  public const uint BadNoValidCertificates = 2153316352 /*0x80590000*/;
  public const uint BadIdentityChangeNotSupported = 2160459776 /*0x80C60000*/;
  public const uint BadRequestCancelledByRequest = 2153381888 /*0x805A0000*/;
  public const uint BadParentNodeIdInvalid = 2153447424 /*0x805B0000*/;
  public const uint BadReferenceNotAllowed = 2153512960 /*0x805C0000*/;
  public const uint BadNodeIdRejected = 2153578496 /*0x805D0000*/;
  public const uint BadNodeIdExists = 2153644032 /*0x805E0000*/;
  public const uint BadNodeClassInvalid = 2153709568 /*0x805F0000*/;
  public const uint BadBrowseNameInvalid = 2153775104 /*0x80600000*/;
  public const uint BadBrowseNameDuplicated = 2153840640 /*0x80610000*/;
  public const uint BadNodeAttributesInvalid = 2153906176 /*0x80620000*/;
  public const uint BadTypeDefinitionInvalid = 2153971712 /*0x80630000*/;
  public const uint BadSourceNodeIdInvalid = 2154037248 /*0x80640000*/;
  public const uint BadTargetNodeIdInvalid = 2154102784 /*0x80650000*/;
  public const uint BadDuplicateReferenceNotAllowed = 2154168320 /*0x80660000*/;
  public const uint BadInvalidSelfReference = 2154233856 /*0x80670000*/;
  public const uint BadReferenceLocalOnly = 2154299392 /*0x80680000*/;
  public const uint BadNoDeleteRights = 2154364928 /*0x80690000*/;
  public const uint UncertainReferenceNotDeleted = 1086062592 /*0x40BC0000*/;
  public const uint BadServerIndexInvalid = 2154430464 /*0x806A0000*/;
  public const uint BadViewIdUnknown = 2154496000 /*0x806B0000*/;
  public const uint BadViewTimestampInvalid = 2160656384 /*0x80C90000*/;
  public const uint BadViewParameterMismatch = 2160721920 /*0x80CA0000*/;
  public const uint BadViewVersionInvalid = 2160787456 /*0x80CB0000*/;
  public const uint UncertainNotAllNodesAvailable = 1086324736 /*0x40C00000*/;
  public const uint GoodResultsMayBeIncomplete = 12189696 /*0xBA0000*/;
  public const uint BadNotTypeDefinition = 2160590848 /*0x80C80000*/;
  public const uint UncertainReferenceOutOfServer = 1080819712 /*0x406C0000*/;
  public const uint BadTooManyMatches = 2154627072 /*0x806D0000*/;
  public const uint BadQueryTooComplex = 2154692608 /*0x806E0000*/;
  public const uint BadNoMatch = 2154758144 /*0x806F0000*/;
  public const uint BadMaxAgeInvalid = 2154823680 /*0x80700000*/;
  public const uint BadSecurityModeInsufficient = 2162556928 /*0x80E60000*/;
  public const uint BadHistoryOperationInvalid = 2154889216 /*0x80710000*/;
  public const uint BadHistoryOperationUnsupported = 2154954752 /*0x80720000*/;
  public const uint BadInvalidTimestampArgument = 2159869952 /*0x80BD0000*/;
  public const uint BadWriteNotSupported = 2155020288 /*0x80730000*/;
  public const uint BadTypeMismatch = 2155085824 /*0x80740000*/;
  public const uint BadMethodInvalid = 2155151360 /*0x80750000*/;
  public const uint BadArgumentsMissing = 2155216896 /*0x80760000*/;
  public const uint BadNotExecutable = 2165374976;
  public const uint BadTooManySubscriptions = 2155282432 /*0x80770000*/;
  public const uint BadTooManyPublishRequests = 2155347968 /*0x80780000*/;
  public const uint BadNoSubscription = 2155413504 /*0x80790000*/;
  public const uint BadSequenceNumberUnknown = 2155479040 /*0x807A0000*/;
  public const uint GoodRetransmissionQueueNotSupported = 14614528 /*0xDF0000*/;
  public const uint BadMessageNotAvailable = 2155544576 /*0x807B0000*/;
  public const uint BadInsufficientClientProfile = 2155610112 /*0x807C0000*/;
  public const uint BadStateNotActive = 2160001024 /*0x80BF0000*/;
  public const uint BadAlreadyExists = 2165637120;
  public const uint BadTcpServerTooBusy = 2155675648 /*0x807D0000*/;
  public const uint BadTcpMessageTypeInvalid = 2155741184 /*0x807E0000*/;
  public const uint BadTcpSecureChannelUnknown = 2155806720 /*0x807F0000*/;
  public const uint BadTcpMessageTooLarge = 2155872256 /*0x80800000*/;
  public const uint BadTcpNotEnoughResources = 2155937792 /*0x80810000*/;
  public const uint BadTcpInternalError = 2156003328 /*0x80820000*/;
  public const uint BadTcpEndpointUrlInvalid = 2156068864 /*0x80830000*/;
  public const uint BadRequestInterrupted = 2156134400 /*0x80840000*/;
  public const uint BadRequestTimeout = 2156199936 /*0x80850000*/;
  public const uint BadSecureChannelClosed = 2156265472 /*0x80860000*/;
  public const uint BadSecureChannelTokenUnknown = 2156331008 /*0x80870000*/;
  public const uint BadSequenceNumberInvalid = 2156396544 /*0x80880000*/;
  public const uint BadProtocolVersionUnsupported = 2159935488 /*0x80BE0000*/;
  public const uint BadConfigurationError = 2156462080 /*0x80890000*/;
  public const uint BadNotConnected = 2156527616 /*0x808A0000*/;
  public const uint BadDeviceFailure = 2156593152 /*0x808B0000*/;
  public const uint BadSensorFailure = 2156658688 /*0x808C0000*/;
  public const uint BadOutOfService = 2156724224 /*0x808D0000*/;
  public const uint BadDeadbandFilterInvalid = 2156789760 /*0x808E0000*/;
  public const uint UncertainNoCommunicationLastUsableValue = 1083113472 /*0x408F0000*/;
  public const uint UncertainLastUsableValue = 1083179008 /*0x40900000*/;
  public const uint UncertainSubstituteValue = 1083244544 /*0x40910000*/;
  public const uint UncertainInitialValue = 1083310080 /*0x40920000*/;
  public const uint UncertainSensorNotAccurate = 1083375616 /*0x40930000*/;
  public const uint UncertainEngineeringUnitsExceeded = 1083441152 /*0x40940000*/;
  public const uint UncertainSubNormal = 1083506688 /*0x40950000*/;
  public const uint GoodLocalOverride = 9830400 /*0x960000*/;
  public const uint GoodSubNormal = 15400960 /*0xEB0000*/;
  public const uint BadRefreshInProgress = 2157379584 /*0x80970000*/;
  public const uint BadConditionAlreadyDisabled = 2157445120 /*0x80980000*/;
  public const uint BadConditionAlreadyEnabled = 2160852992 /*0x80CC0000*/;
  public const uint BadConditionDisabled = 2157510656 /*0x80990000*/;
  public const uint BadEventIdUnknown = 2157576192 /*0x809A0000*/;
  public const uint BadEventNotAcknowledgeable = 2159738880 /*0x80BB0000*/;
  public const uint BadDialogNotActive = 2160918528 /*0x80CD0000*/;
  public const uint BadDialogResponseInvalid = 2160984064 /*0x80CE0000*/;
  public const uint BadConditionBranchAlreadyAcked = 2161049600 /*0x80CF0000*/;
  public const uint BadConditionBranchAlreadyConfirmed = 2161115136 /*0x80D00000*/;
  public const uint BadConditionAlreadyShelved = 2161180672 /*0x80D10000*/;
  public const uint BadConditionNotShelved = 2161246208 /*0x80D20000*/;
  public const uint BadShelvingTimeOutOfRange = 2161311744 /*0x80D30000*/;
  public const uint BadNoData = 2157641728 /*0x809B0000*/;
  public const uint BadBoundNotFound = 2161573888 /*0x80D70000*/;
  public const uint BadBoundNotSupported = 2161639424 /*0x80D80000*/;
  public const uint BadDataLost = 2157772800 /*0x809D0000*/;
  public const uint BadDataUnavailable = 2157838336 /*0x809E0000*/;
  public const uint BadEntryExists = 2157903872 /*0x809F0000*/;
  public const uint BadNoEntryExists = 2157969408 /*0x80A00000*/;
  public const uint BadTimestampNotSupported = 2158034944 /*0x80A10000*/;
  public const uint GoodEntryInserted = 10616832 /*0xA20000*/;
  public const uint GoodEntryReplaced = 10682368 /*0xA30000*/;
  public const uint UncertainDataSubNormal = 1084489728 /*0x40A40000*/;
  public const uint GoodNoData = 10813440 /*0xA50000*/;
  public const uint GoodMoreData = 10878976 /*0xA60000*/;
  public const uint BadAggregateListMismatch = 2161377280 /*0x80D40000*/;
  public const uint BadAggregateNotSupported = 2161442816 /*0x80D50000*/;
  public const uint BadAggregateInvalidInputs = 2161508352 /*0x80D60000*/;
  public const uint BadAggregateConfigurationRejected = 2161770496 /*0x80DA0000*/;
  public const uint GoodDataIgnored = 14221312 /*0xD90000*/;
  public const uint BadRequestNotAllowed = 2162425856 /*0x80E40000*/;
  public const uint BadRequestNotComplete = 2165506048;
  public const uint BadTransactionPending = 2162688000 /*0x80E80000*/;
  public const uint BadTicketRequired = 2166292480;
  public const uint BadTicketInvalid = 2166358016 /*0x81200000*/;
  public const uint BadLocked = 2162753536 /*0x80E90000*/;
  public const uint BadRequiresLock = 2162950144 /*0x80EC0000*/;
  public const uint GoodEdited = 14417920 /*0xDC0000*/;
  public const uint GoodPostActionFailed = 14483456 /*0xDD0000*/;
  public const uint UncertainDominantValueChanged = 1088290816 /*0x40DE0000*/;
  public const uint GoodDependentValueChanged = 14680064 /*0xE00000*/;
  public const uint BadDominantValueChanged = 2162229248 /*0x80E10000*/;
  public const uint UncertainDependentValueChanged = 1088552960 /*0x40E20000*/;
  public const uint BadDependentValueChanged = 2162360320 /*0x80E30000*/;
  public const uint GoodEdited_DependentValueChanged = 18219008 /*0x01160000*/;
  public const uint GoodEdited_DominantValueChanged = 18284544 /*0x01170000*/;
  public const uint GoodEdited_DominantValueChanged_DependentValueChanged = 18350080 /*0x01180000*/;
  public const uint BadEdited_OutOfRange = 2165899264;
  public const uint BadInitialValue_OutOfRange = 2165964800;
  public const uint BadOutOfRange_DominantValueChanged = 2166030336;
  public const uint BadEdited_OutOfRange_DominantValueChanged = 2166095872;
  public const uint BadOutOfRange_DominantValueChanged_DependentValueChanged = 2166161408;
  public const uint BadEdited_OutOfRange_DominantValueChanged_DependentValueChanged = 2166226944;
  public const uint GoodCommunicationEvent = 10944512 /*0xA70000*/;
  public const uint GoodShutdownEvent = 11010048 /*0xA80000*/;
  public const uint GoodCallAgain = 11075584 /*0xA90000*/;
  public const uint GoodNonCriticalTimeout = 11141120 /*0xAA0000*/;
  public const uint BadInvalidArgument = 2158690304 /*0x80AB0000*/;
  public const uint BadConnectionRejected = 2158755840 /*0x80AC0000*/;
  public const uint BadDisconnect = 2158821376 /*0x80AD0000*/;
  public const uint BadConnectionClosed = 2158886912 /*0x80AE0000*/;
  public const uint BadInvalidState = 2158952448 /*0x80AF0000*/;
  public const uint BadEndOfStream = 2159017984 /*0x80B00000*/;
  public const uint BadNoDataAvailable = 2159083520 /*0x80B10000*/;
  public const uint BadWaitingForResponse = 2159149056 /*0x80B20000*/;
  public const uint BadOperationAbandoned = 2159214592 /*0x80B30000*/;
  public const uint BadExpectedStreamToBlock = 2159280128 /*0x80B40000*/;
  public const uint BadWouldBlock = 2159345664 /*0x80B50000*/;
  public const uint BadSyntaxError = 2159411200 /*0x80B60000*/;
  public const uint BadMaxConnectionsReached = 2159476736 /*0x80B70000*/;
  public const uint UncertainTransducerInManual = 1107820544 /*0x42080000*/;
  public const uint UncertainSimulatedValue = 1107886080 /*0x42090000*/;
  public const uint UncertainSensorCalibration = 1107951616 /*0x420A0000*/;
  public const uint UncertainConfigurationError = 1108279296 /*0x420F0000*/;
  public const uint GoodCascadeInitializationAcknowledged = 67174400 /*0x04010000*/;
  public const uint GoodCascadeInitializationRequest = 67239936 /*0x04020000*/;
  public const uint GoodCascadeNotInvited = 67305472 /*0x04030000*/;
  public const uint GoodCascadeNotSelected = 67371008 /*0x04040000*/;
  public const uint GoodFaultStateActive = 67567616 /*0x04070000*/;
  public const uint GoodInitiateFaultState = 67633152 /*0x04080000*/;
  public const uint GoodCascade = 67698688 /*0x04090000*/;
  public const uint BadDataSetIdInvalid = 2162622464 /*0x80E70000*/;

  public static string GetBrowseName(uint identifier)
  {
    foreach (FieldInfo field in typeof (StatusCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if ((int) identifier == (int) (uint) field.GetValue((object) typeof (StatusCodes)))
        return field.Name;
    }
    return string.Empty;
  }

  public static string[] GetBrowseNames()
  {
    FieldInfo[] fields = typeof (StatusCodes).GetFields(BindingFlags.Static | BindingFlags.Public);
    int num = 0;
    string[] browseNames = new string[fields.Length];
    foreach (FieldInfo fieldInfo in fields)
      browseNames[num++] = fieldInfo.Name;
    return browseNames;
  }

  public static uint GetIdentifier(string browseName)
  {
    foreach (FieldInfo field in typeof (StatusCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if (field.Name == browseName)
        return (uint) field.GetValue((object) typeof (StatusCodes));
    }
    return 0;
  }
}
