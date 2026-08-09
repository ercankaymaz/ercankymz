using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class ObjectIds
{
	public static readonly NodeId DefaultBinary = new NodeId(3062u);

	public static readonly NodeId DefaultXml = new NodeId(3063u);

	public static readonly NodeId ModellingRule_Mandatory = new NodeId(78u);

	public static readonly NodeId ModellingRule_Optional = new NodeId(80u);

	public static readonly NodeId ModellingRule_ExposesItsArray = new NodeId(83u);

	public static readonly NodeId ModellingRule_OptionalPlaceholder = new NodeId(11508u);

	public static readonly NodeId ModellingRule_MandatoryPlaceholder = new NodeId(11510u);

	public static readonly NodeId RootFolder = new NodeId(84u);

	public static readonly NodeId ObjectsFolder = new NodeId(85u);

	public static readonly NodeId TypesFolder = new NodeId(86u);

	public static readonly NodeId ViewsFolder = new NodeId(87u);

	public static readonly NodeId ObjectTypesFolder = new NodeId(88u);

	public static readonly NodeId VariableTypesFolder = new NodeId(89u);

	public static readonly NodeId DataTypesFolder = new NodeId(90u);

	public static readonly NodeId ReferenceTypesFolder = new NodeId(91u);

	public static readonly NodeId XmlSchema_TypeSystem = new NodeId(92u);

	public static readonly NodeId OPCBinarySchema_TypeSystem = new NodeId(93u);

	public static readonly NodeId OPCUANamespaceMetadata = new NodeId(15957u);

	public static readonly NodeId ServerType_ServerCapabilities = new NodeId(2009u);

	public static readonly NodeId ServerType_ServerCapabilities_ModellingRules = new NodeId(3093u);

	public static readonly NodeId ServerType_ServerCapabilities_AggregateFunctions = new NodeId(3094u);

	public static readonly NodeId ServerType_ServerDiagnostics = new NodeId(2010u);

	public static readonly NodeId ServerType_ServerDiagnostics_SessionsDiagnosticsSummary = new NodeId(3111u);

	public static readonly NodeId ServerType_VendorServerInfo = new NodeId(2011u);

	public static readonly NodeId ServerType_ServerRedundancy = new NodeId(2012u);

	public static readonly NodeId ServerType_Namespaces = new NodeId(11527u);

	public static readonly NodeId ServerCapabilitiesType_OperationLimits = new NodeId(11551u);

	public static readonly NodeId ServerCapabilitiesType_ModellingRules = new NodeId(2019u);

	public static readonly NodeId ServerCapabilitiesType_AggregateFunctions = new NodeId(2754u);

	public static readonly NodeId ServerCapabilitiesType_RoleSet = new NodeId(16295u);

	public static readonly NodeId ServerDiagnosticsType_SessionsDiagnosticsSummary = new NodeId(2744u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder = new NodeId(12097u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile = new NodeId(11624u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder = new NodeId(11646u);

	public static readonly NodeId EventTypesFolder = new NodeId(3048u);

	public static readonly NodeId Server = new NodeId(2253u);

	public static readonly NodeId Server_ServerCapabilities = new NodeId(2268u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits = new NodeId(11704u);

	public static readonly NodeId Server_ServerCapabilities_ModellingRules = new NodeId(2996u);

	public static readonly NodeId Server_ServerCapabilities_AggregateFunctions = new NodeId(2997u);

	public static readonly NodeId Server_ServerCapabilities_RoleSet = new NodeId(15606u);

	public static readonly NodeId Server_ServerDiagnostics = new NodeId(2274u);

	public static readonly NodeId Server_ServerDiagnostics_SessionsDiagnosticsSummary = new NodeId(3706u);

	public static readonly NodeId Server_VendorServerInfo = new NodeId(2295u);

	public static readonly NodeId Server_ServerRedundancy = new NodeId(2296u);

	public static readonly NodeId Server_Namespaces = new NodeId(11715u);

	public static readonly NodeId HistoryServerCapabilities = new NodeId(11192u);

	public static readonly NodeId HistoryServerCapabilities_AggregateFunctions = new NodeId(11201u);

	public static readonly NodeId FileDirectoryType_FileDirectoryName_Placeholder = new NodeId(13354u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder = new NodeId(13366u);

	public static readonly NodeId FileSystem = new NodeId(16314u);

	public static readonly NodeId TemporaryFileTransferType_TransferState_Placeholder = new NodeId(15754u);

	public static readonly NodeId FileTransferStateMachineType_Idle = new NodeId(15815u);

	public static readonly NodeId FileTransferStateMachineType_ReadPrepare = new NodeId(15817u);

	public static readonly NodeId FileTransferStateMachineType_ReadTransfer = new NodeId(15819u);

	public static readonly NodeId FileTransferStateMachineType_ApplyWrite = new NodeId(15821u);

	public static readonly NodeId FileTransferStateMachineType_Error = new NodeId(15823u);

	public static readonly NodeId FileTransferStateMachineType_IdleToReadPrepare = new NodeId(15825u);

	public static readonly NodeId FileTransferStateMachineType_ReadPrepareToReadTransfer = new NodeId(15827u);

	public static readonly NodeId FileTransferStateMachineType_ReadTransferToIdle = new NodeId(15829u);

	public static readonly NodeId FileTransferStateMachineType_IdleToApplyWrite = new NodeId(15831u);

	public static readonly NodeId FileTransferStateMachineType_ApplyWriteToIdle = new NodeId(15833u);

	public static readonly NodeId FileTransferStateMachineType_ReadPrepareToError = new NodeId(15835u);

	public static readonly NodeId FileTransferStateMachineType_ReadTransferToError = new NodeId(15837u);

	public static readonly NodeId FileTransferStateMachineType_ApplyWriteToError = new NodeId(15839u);

	public static readonly NodeId FileTransferStateMachineType_ErrorToIdle = new NodeId(15841u);

	public static readonly NodeId RoleSetType_RoleName_Placeholder = new NodeId(15608u);

	public static readonly NodeId WellKnownRole_Anonymous = new NodeId(15644u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser = new NodeId(15656u);

	public static readonly NodeId WellKnownRole_Observer = new NodeId(15668u);

	public static readonly NodeId WellKnownRole_Operator = new NodeId(15680u);

	public static readonly NodeId WellKnownRole_Engineer = new NodeId(16036u);

	public static readonly NodeId WellKnownRole_Supervisor = new NodeId(15692u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin = new NodeId(15716u);

	public static readonly NodeId WellKnownRole_SecurityAdmin = new NodeId(15704u);

	public static readonly NodeId DictionaryEntryType_DictionaryEntryName_Placeholder = new NodeId(17590u);

	public static readonly NodeId DictionaryFolderType_DictionaryFolderName_Placeholder = new NodeId(17592u);

	public static readonly NodeId DictionaryFolderType_DictionaryEntryName_Placeholder = new NodeId(17593u);

	public static readonly NodeId Dictionaries = new NodeId(17594u);

	public static readonly NodeId InterfaceTypes = new NodeId(17708u);

	public static readonly NodeId OrderedListType_OrderedObject_Placeholder = new NodeId(23519u);

	public static readonly NodeId AlarmConditionType_ShelvingState = new NodeId(9178u);

	public static readonly NodeId AlarmConditionType_FirstInGroup = new NodeId(16398u);

	public static readonly NodeId AlarmConditionType_AlarmGroup_Placeholder = new NodeId(16399u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder = new NodeId(16406u);

	public static readonly NodeId ShelvedStateMachineType_Unshelved = new NodeId(2930u);

	public static readonly NodeId ShelvedStateMachineType_TimedShelved = new NodeId(2932u);

	public static readonly NodeId ShelvedStateMachineType_OneShotShelved = new NodeId(2933u);

	public static readonly NodeId ShelvedStateMachineType_UnshelvedToTimedShelved = new NodeId(2935u);

	public static readonly NodeId ShelvedStateMachineType_UnshelvedToOneShotShelved = new NodeId(2936u);

	public static readonly NodeId ShelvedStateMachineType_TimedShelvedToUnshelved = new NodeId(2940u);

	public static readonly NodeId ShelvedStateMachineType_TimedShelvedToOneShotShelved = new NodeId(2942u);

	public static readonly NodeId ShelvedStateMachineType_OneShotShelvedToUnshelved = new NodeId(2943u);

	public static readonly NodeId ShelvedStateMachineType_OneShotShelvedToTimedShelved = new NodeId(2945u);

	public static readonly NodeId ExclusiveLimitStateMachineType_HighHigh = new NodeId(9329u);

	public static readonly NodeId ExclusiveLimitStateMachineType_High = new NodeId(9331u);

	public static readonly NodeId ExclusiveLimitStateMachineType_Low = new NodeId(9333u);

	public static readonly NodeId ExclusiveLimitStateMachineType_LowLow = new NodeId(9335u);

	public static readonly NodeId ExclusiveLimitStateMachineType_LowLowToLow = new NodeId(9337u);

	public static readonly NodeId ExclusiveLimitStateMachineType_LowToLowLow = new NodeId(9338u);

	public static readonly NodeId ExclusiveLimitStateMachineType_HighHighToHigh = new NodeId(9339u);

	public static readonly NodeId ExclusiveLimitStateMachineType_HighToHighHigh = new NodeId(9340u);

	public static readonly NodeId ExclusiveLimitAlarmType_LimitState = new NodeId(9455u);

	public static readonly NodeId ProgramStateMachineType_FinalResultData = new NodeId(3850u);

	public static readonly NodeId ProgramStateMachineType_Halted = new NodeId(2406u);

	public static readonly NodeId ProgramStateMachineType_Ready = new NodeId(2400u);

	public static readonly NodeId ProgramStateMachineType_Running = new NodeId(2402u);

	public static readonly NodeId ProgramStateMachineType_Suspended = new NodeId(2404u);

	public static readonly NodeId ProgramStateMachineType_HaltedToReady = new NodeId(2408u);

	public static readonly NodeId ProgramStateMachineType_ReadyToRunning = new NodeId(2410u);

	public static readonly NodeId ProgramStateMachineType_RunningToHalted = new NodeId(2412u);

	public static readonly NodeId ProgramStateMachineType_RunningToReady = new NodeId(2414u);

	public static readonly NodeId ProgramStateMachineType_RunningToSuspended = new NodeId(2416u);

	public static readonly NodeId ProgramStateMachineType_SuspendedToRunning = new NodeId(2418u);

	public static readonly NodeId ProgramStateMachineType_SuspendedToHalted = new NodeId(2420u);

	public static readonly NodeId ProgramStateMachineType_SuspendedToReady = new NodeId(2422u);

	public static readonly NodeId ProgramStateMachineType_ReadyToHalted = new NodeId(2424u);

	public static readonly NodeId HistoricalDataConfigurationType_AggregateConfiguration = new NodeId(3059u);

	public static readonly NodeId HistoricalDataConfigurationType_AggregateFunctions = new NodeId(11876u);

	public static readonly NodeId HAConfiguration = new NodeId(11202u);

	public static readonly NodeId HAConfiguration_AggregateConfiguration = new NodeId(11203u);

	public static readonly NodeId HistoryServerCapabilitiesType_AggregateFunctions = new NodeId(11172u);

	public static readonly NodeId CertificateGroupType_TrustList = new NodeId(13599u);

	public static readonly NodeId CertificateGroupType_CertificateExpired = new NodeId(19450u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate = new NodeId(20143u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup = new NodeId(13814u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList = new NodeId(13815u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup = new NodeId(13848u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList = new NodeId(13849u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup = new NodeId(13882u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList = new NodeId(13883u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder = new NodeId(13916u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList = new NodeId(13917u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups = new NodeId(13950u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup = new NodeId(13951u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList = new NodeId(13952u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList = new NodeId(13986u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList = new NodeId(14020u);

	public static readonly NodeId ServerConfiguration = new NodeId(12637u);

	public static readonly NodeId ServerConfiguration_CertificateGroups = new NodeId(14053u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup = new NodeId(14156u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList = new NodeId(12642u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup = new NodeId(14088u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList = new NodeId(14089u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup = new NodeId(14122u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList = new NodeId(14123u);

	public static readonly NodeId KeyCredentialConfigurationFolderType_ServiceName_Placeholder = new NodeId(17511u);

	public static readonly NodeId KeyCredentialConfiguration = new NodeId(18155u);

	public static readonly NodeId AuthorizationServicesConfigurationFolderType_ServiceName_Placeholder = new NodeId(23557u);

	public static readonly NodeId AuthorizationServices = new NodeId(17732u);

	public static readonly NodeId AggregateFunction_Interpolative = new NodeId(2341u);

	public static readonly NodeId AggregateFunction_Average = new NodeId(2342u);

	public static readonly NodeId AggregateFunction_TimeAverage = new NodeId(2343u);

	public static readonly NodeId AggregateFunction_TimeAverage2 = new NodeId(11285u);

	public static readonly NodeId AggregateFunction_Total = new NodeId(2344u);

	public static readonly NodeId AggregateFunction_Total2 = new NodeId(11304u);

	public static readonly NodeId AggregateFunction_Minimum = new NodeId(2346u);

	public static readonly NodeId AggregateFunction_Maximum = new NodeId(2347u);

	public static readonly NodeId AggregateFunction_MinimumActualTime = new NodeId(2348u);

	public static readonly NodeId AggregateFunction_MaximumActualTime = new NodeId(2349u);

	public static readonly NodeId AggregateFunction_Range = new NodeId(2350u);

	public static readonly NodeId AggregateFunction_Minimum2 = new NodeId(11286u);

	public static readonly NodeId AggregateFunction_Maximum2 = new NodeId(11287u);

	public static readonly NodeId AggregateFunction_MinimumActualTime2 = new NodeId(11305u);

	public static readonly NodeId AggregateFunction_MaximumActualTime2 = new NodeId(11306u);

	public static readonly NodeId AggregateFunction_Range2 = new NodeId(11288u);

	public static readonly NodeId AggregateFunction_AnnotationCount = new NodeId(2351u);

	public static readonly NodeId AggregateFunction_Count = new NodeId(2352u);

	public static readonly NodeId AggregateFunction_DurationInStateZero = new NodeId(11307u);

	public static readonly NodeId AggregateFunction_DurationInStateNonZero = new NodeId(11308u);

	public static readonly NodeId AggregateFunction_NumberOfTransitions = new NodeId(2355u);

	public static readonly NodeId AggregateFunction_Start = new NodeId(2357u);

	public static readonly NodeId AggregateFunction_End = new NodeId(2358u);

	public static readonly NodeId AggregateFunction_Delta = new NodeId(2359u);

	public static readonly NodeId AggregateFunction_StartBound = new NodeId(11505u);

	public static readonly NodeId AggregateFunction_EndBound = new NodeId(11506u);

	public static readonly NodeId AggregateFunction_DeltaBounds = new NodeId(11507u);

	public static readonly NodeId AggregateFunction_DurationGood = new NodeId(2360u);

	public static readonly NodeId AggregateFunction_DurationBad = new NodeId(2361u);

	public static readonly NodeId AggregateFunction_PercentGood = new NodeId(2362u);

	public static readonly NodeId AggregateFunction_PercentBad = new NodeId(2363u);

	public static readonly NodeId AggregateFunction_WorstQuality = new NodeId(2364u);

	public static readonly NodeId AggregateFunction_WorstQuality2 = new NodeId(11292u);

	public static readonly NodeId AggregateFunction_StandardDeviationSample = new NodeId(11426u);

	public static readonly NodeId AggregateFunction_StandardDeviationPopulation = new NodeId(11427u);

	public static readonly NodeId AggregateFunction_VarianceSample = new NodeId(11428u);

	public static readonly NodeId AggregateFunction_VariancePopulation = new NodeId(11429u);

	public static readonly NodeId PubSubKeyServiceType_SecurityGroups = new NodeId(15913u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupFolderName_Placeholder = new NodeId(15453u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupName_Placeholder = new NodeId(15459u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder = new NodeId(14417u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Address = new NodeId(14423u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Status = new NodeId(14419u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters = new NodeId(18681u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_LiveValues = new NodeId(18712u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets = new NodeId(14434u);

	public static readonly NodeId PublishSubscribeType_Status = new NodeId(15844u);

	public static readonly NodeId PublishSubscribeType_Diagnostics = new NodeId(18715u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters = new NodeId(18729u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_LiveValues = new NodeId(18760u);

	public static readonly NodeId PublishSubscribe = new NodeId(14443u);

	public static readonly NodeId PublishSubscribe_SecurityGroups = new NodeId(15443u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Address = new NodeId(15851u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Status = new NodeId(15865u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters = new NodeId(16102u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_LiveValues = new NodeId(17352u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets = new NodeId(17371u);

	public static readonly NodeId PublishSubscribe_Status = new NodeId(17405u);

	public static readonly NodeId PublishSubscribe_Diagnostics = new NodeId(17409u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters = new NodeId(17423u);

	public static readonly NodeId PublishSubscribe_Diagnostics_LiveValues = new NodeId(17457u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder = new NodeId(15222u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Status = new NodeId(15223u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters = new NodeId(18885u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_LiveValues = new NodeId(18916u);

	public static readonly NodeId PublishedDataSetType_ExtensionFields = new NodeId(15481u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Status = new NodeId(15231u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters = new NodeId(18944u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues = new NodeId(18975u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Status = new NodeId(15239u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters = new NodeId(19003u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues = new NodeId(19034u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder = new NodeId(14478u);

	public static readonly NodeId DataSetFolderType_PublishedDataSetName_Placeholder = new NodeId(14487u);

	public static readonly NodeId PubSubConnectionType_Address = new NodeId(14221u);

	public static readonly NodeId PubSubConnectionType_TransportSettings = new NodeId(17203u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder = new NodeId(17310u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Status = new NodeId(17314u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters = new NodeId(19121u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_LiveValues = new NodeId(19152u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder = new NodeId(17325u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Status = new NodeId(17329u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters = new NodeId(19190u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_LiveValues = new NodeId(19221u);

	public static readonly NodeId PubSubConnectionType_Status = new NodeId(14600u);

	public static readonly NodeId PubSubConnectionType_Diagnostics = new NodeId(19241u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters = new NodeId(19255u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_LiveValues = new NodeId(19286u);

	public static readonly NodeId PubSubGroupType_Status = new NodeId(15265u);

	public static readonly NodeId WriterGroupType_TransportSettings = new NodeId(17741u);

	public static readonly NodeId WriterGroupType_MessageSettings = new NodeId(17742u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder = new NodeId(17743u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Status = new NodeId(17749u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters = new NodeId(17767u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_LiveValues = new NodeId(17798u);

	public static readonly NodeId WriterGroupType_Diagnostics = new NodeId(17812u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters = new NodeId(17826u);

	public static readonly NodeId WriterGroupType_Diagnostics_LiveValues = new NodeId(17858u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder = new NodeId(18076u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Status = new NodeId(18088u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters = new NodeId(18106u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_LiveValues = new NodeId(18137u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_SubscribedDataSet = new NodeId(21006u);

	public static readonly NodeId ReaderGroupType_Diagnostics = new NodeId(21015u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters = new NodeId(21029u);

	public static readonly NodeId ReaderGroupType_Diagnostics_LiveValues = new NodeId(21060u);

	public static readonly NodeId ReaderGroupType_TransportSettings = new NodeId(21080u);

	public static readonly NodeId ReaderGroupType_MessageSettings = new NodeId(21081u);

	public static readonly NodeId DataSetWriterType_TransportSettings = new NodeId(15303u);

	public static readonly NodeId DataSetWriterType_MessageSettings = new NodeId(21095u);

	public static readonly NodeId DataSetWriterType_Status = new NodeId(15299u);

	public static readonly NodeId DataSetWriterType_Diagnostics = new NodeId(19550u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters = new NodeId(19564u);

	public static readonly NodeId DataSetWriterType_Diagnostics_LiveValues = new NodeId(19595u);

	public static readonly NodeId DataSetReaderType_TransportSettings = new NodeId(15311u);

	public static readonly NodeId DataSetReaderType_MessageSettings = new NodeId(21103u);

	public static readonly NodeId DataSetReaderType_Status = new NodeId(15307u);

	public static readonly NodeId DataSetReaderType_Diagnostics = new NodeId(19609u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters = new NodeId(19623u);

	public static readonly NodeId DataSetReaderType_Diagnostics_LiveValues = new NodeId(19654u);

	public static readonly NodeId DataSetReaderType_SubscribedDataSet = new NodeId(15316u);

	public static readonly NodeId PubSubDiagnosticsType_Counters = new NodeId(19691u);

	public static readonly NodeId PubSubDiagnosticsType_LiveValues = new NodeId(19722u);

	public static readonly NodeId PubSubDiagnosticsRootType_LiveValues = new NodeId(19777u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_LiveValues = new NodeId(19831u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters = new NodeId(19848u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_LiveValues = new NodeId(19879u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters = new NodeId(19917u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_LiveValues = new NodeId(19948u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters = new NodeId(19982u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_LiveValues = new NodeId(20013u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters = new NodeId(20041u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues = new NodeId(20072u);

	public static readonly NodeId DatagramConnectionTransportType_DiscoveryAddress = new NodeId(15072u);

	public static readonly NodeId AliasNameCategoryType_Alias_Placeholder = new NodeId(23457u);

	public static readonly NodeId AliasNameCategoryType_SubAliasNameCategories_Placeholder = new NodeId(23458u);

	public static readonly NodeId Aliases = new NodeId(23470u);

	public static readonly NodeId TagVariables = new NodeId(23479u);

	public static readonly NodeId Topics = new NodeId(23488u);

	public static readonly NodeId Resources = new NodeId(24226u);

	public static readonly NodeId Communication = new NodeId(24227u);

	public static readonly NodeId MappingTables = new NodeId(24228u);

	public static readonly NodeId NetworkInterfaces = new NodeId(24229u);

	public static readonly NodeId Streams = new NodeId(24230u);

	public static readonly NodeId TalkerStreams = new NodeId(24231u);

	public static readonly NodeId ListenerStreams = new NodeId(24232u);

	public static readonly NodeId Union_Encoding_DefaultBinary = new NodeId(12766u);

	public static readonly NodeId KeyValuePair_Encoding_DefaultBinary = new NodeId(14846u);

	public static readonly NodeId AdditionalParametersType_Encoding_DefaultBinary = new NodeId(17537u);

	public static readonly NodeId EphemeralKeyType_Encoding_DefaultBinary = new NodeId(17549u);

	public static readonly NodeId EndpointType_Encoding_DefaultBinary = new NodeId(15671u);

	public static readonly NodeId RationalNumber_Encoding_DefaultBinary = new NodeId(18815u);

	public static readonly NodeId Vector_Encoding_DefaultBinary = new NodeId(18816u);

	public static readonly NodeId ThreeDVector_Encoding_DefaultBinary = new NodeId(18817u);

	public static readonly NodeId CartesianCoordinates_Encoding_DefaultBinary = new NodeId(18818u);

	public static readonly NodeId ThreeDCartesianCoordinates_Encoding_DefaultBinary = new NodeId(18819u);

	public static readonly NodeId Orientation_Encoding_DefaultBinary = new NodeId(18820u);

	public static readonly NodeId ThreeDOrientation_Encoding_DefaultBinary = new NodeId(18821u);

	public static readonly NodeId Frame_Encoding_DefaultBinary = new NodeId(18822u);

	public static readonly NodeId ThreeDFrame_Encoding_DefaultBinary = new NodeId(18823u);

	public static readonly NodeId IdentityMappingRuleType_Encoding_DefaultBinary = new NodeId(15736u);

	public static readonly NodeId CurrencyUnitType_Encoding_DefaultBinary = new NodeId(23507u);

	public static readonly NodeId TrustListDataType_Encoding_DefaultBinary = new NodeId(12680u);

	public static readonly NodeId DecimalDataType_Encoding_DefaultBinary = new NodeId(17863u);

	public static readonly NodeId DataTypeSchemaHeader_Encoding_DefaultBinary = new NodeId(15676u);

	public static readonly NodeId DataTypeDescription_Encoding_DefaultBinary = new NodeId(125u);

	public static readonly NodeId StructureDescription_Encoding_DefaultBinary = new NodeId(126u);

	public static readonly NodeId EnumDescription_Encoding_DefaultBinary = new NodeId(127u);

	public static readonly NodeId SimpleTypeDescription_Encoding_DefaultBinary = new NodeId(15421u);

	public static readonly NodeId UABinaryFileDataType_Encoding_DefaultBinary = new NodeId(15422u);

	public static readonly NodeId DataSetMetaDataType_Encoding_DefaultBinary = new NodeId(124u);

	public static readonly NodeId FieldMetaData_Encoding_DefaultBinary = new NodeId(14839u);

	public static readonly NodeId ConfigurationVersionDataType_Encoding_DefaultBinary = new NodeId(14847u);

	public static readonly NodeId PublishedDataSetDataType_Encoding_DefaultBinary = new NodeId(15677u);

	public static readonly NodeId PublishedDataSetSourceDataType_Encoding_DefaultBinary = new NodeId(15678u);

	public static readonly NodeId PublishedVariableDataType_Encoding_DefaultBinary = new NodeId(14323u);

	public static readonly NodeId PublishedDataItemsDataType_Encoding_DefaultBinary = new NodeId(15679u);

	public static readonly NodeId PublishedEventsDataType_Encoding_DefaultBinary = new NodeId(15681u);

	public static readonly NodeId DataSetWriterDataType_Encoding_DefaultBinary = new NodeId(15682u);

	public static readonly NodeId DataSetWriterTransportDataType_Encoding_DefaultBinary = new NodeId(15683u);

	public static readonly NodeId DataSetWriterMessageDataType_Encoding_DefaultBinary = new NodeId(15688u);

	public static readonly NodeId PubSubGroupDataType_Encoding_DefaultBinary = new NodeId(15689u);

	public static readonly NodeId WriterGroupDataType_Encoding_DefaultBinary = new NodeId(21150u);

	public static readonly NodeId WriterGroupTransportDataType_Encoding_DefaultBinary = new NodeId(15691u);

	public static readonly NodeId WriterGroupMessageDataType_Encoding_DefaultBinary = new NodeId(15693u);

	public static readonly NodeId PubSubConnectionDataType_Encoding_DefaultBinary = new NodeId(15694u);

	public static readonly NodeId ConnectionTransportDataType_Encoding_DefaultBinary = new NodeId(15695u);

	public static readonly NodeId NetworkAddressDataType_Encoding_DefaultBinary = new NodeId(21151u);

	public static readonly NodeId NetworkAddressUrlDataType_Encoding_DefaultBinary = new NodeId(21152u);

	public static readonly NodeId ReaderGroupDataType_Encoding_DefaultBinary = new NodeId(21153u);

	public static readonly NodeId ReaderGroupTransportDataType_Encoding_DefaultBinary = new NodeId(15701u);

	public static readonly NodeId ReaderGroupMessageDataType_Encoding_DefaultBinary = new NodeId(15702u);

	public static readonly NodeId DataSetReaderDataType_Encoding_DefaultBinary = new NodeId(15703u);

	public static readonly NodeId DataSetReaderTransportDataType_Encoding_DefaultBinary = new NodeId(15705u);

	public static readonly NodeId DataSetReaderMessageDataType_Encoding_DefaultBinary = new NodeId(15706u);

	public static readonly NodeId SubscribedDataSetDataType_Encoding_DefaultBinary = new NodeId(15707u);

	public static readonly NodeId TargetVariablesDataType_Encoding_DefaultBinary = new NodeId(15712u);

	public static readonly NodeId FieldTargetDataType_Encoding_DefaultBinary = new NodeId(14848u);

	public static readonly NodeId SubscribedDataSetMirrorDataType_Encoding_DefaultBinary = new NodeId(15713u);

	public static readonly NodeId PubSubConfigurationDataType_Encoding_DefaultBinary = new NodeId(21154u);

	public static readonly NodeId UadpWriterGroupMessageDataType_Encoding_DefaultBinary = new NodeId(15715u);

	public static readonly NodeId UadpDataSetWriterMessageDataType_Encoding_DefaultBinary = new NodeId(15717u);

	public static readonly NodeId UadpDataSetReaderMessageDataType_Encoding_DefaultBinary = new NodeId(15718u);

	public static readonly NodeId JsonWriterGroupMessageDataType_Encoding_DefaultBinary = new NodeId(15719u);

	public static readonly NodeId JsonDataSetWriterMessageDataType_Encoding_DefaultBinary = new NodeId(15724u);

	public static readonly NodeId JsonDataSetReaderMessageDataType_Encoding_DefaultBinary = new NodeId(15725u);

	public static readonly NodeId DatagramConnectionTransportDataType_Encoding_DefaultBinary = new NodeId(17468u);

	public static readonly NodeId DatagramWriterGroupTransportDataType_Encoding_DefaultBinary = new NodeId(21155u);

	public static readonly NodeId BrokerConnectionTransportDataType_Encoding_DefaultBinary = new NodeId(15479u);

	public static readonly NodeId BrokerWriterGroupTransportDataType_Encoding_DefaultBinary = new NodeId(15727u);

	public static readonly NodeId BrokerDataSetWriterTransportDataType_Encoding_DefaultBinary = new NodeId(15729u);

	public static readonly NodeId BrokerDataSetReaderTransportDataType_Encoding_DefaultBinary = new NodeId(15733u);

	public static readonly NodeId AliasNameDataType_Encoding_DefaultBinary = new NodeId(23499u);

	public static readonly NodeId UnsignedRationalNumber_Encoding_DefaultBinary = new NodeId(24110u);

	public static readonly NodeId RolePermissionType_Encoding_DefaultBinary = new NodeId(128u);

	public static readonly NodeId DataTypeDefinition_Encoding_DefaultBinary = new NodeId(121u);

	public static readonly NodeId StructureField_Encoding_DefaultBinary = new NodeId(14844u);

	public static readonly NodeId StructureDefinition_Encoding_DefaultBinary = new NodeId(122u);

	public static readonly NodeId EnumDefinition_Encoding_DefaultBinary = new NodeId(123u);

	public static readonly NodeId Node_Encoding_DefaultBinary = new NodeId(260u);

	public static readonly NodeId InstanceNode_Encoding_DefaultBinary = new NodeId(11889u);

	public static readonly NodeId TypeNode_Encoding_DefaultBinary = new NodeId(11890u);

	public static readonly NodeId ObjectNode_Encoding_DefaultBinary = new NodeId(263u);

	public static readonly NodeId ObjectTypeNode_Encoding_DefaultBinary = new NodeId(266u);

	public static readonly NodeId VariableNode_Encoding_DefaultBinary = new NodeId(269u);

	public static readonly NodeId VariableTypeNode_Encoding_DefaultBinary = new NodeId(272u);

	public static readonly NodeId ReferenceTypeNode_Encoding_DefaultBinary = new NodeId(275u);

	public static readonly NodeId MethodNode_Encoding_DefaultBinary = new NodeId(278u);

	public static readonly NodeId ViewNode_Encoding_DefaultBinary = new NodeId(281u);

	public static readonly NodeId DataTypeNode_Encoding_DefaultBinary = new NodeId(284u);

	public static readonly NodeId ReferenceNode_Encoding_DefaultBinary = new NodeId(287u);

	public static readonly NodeId Argument_Encoding_DefaultBinary = new NodeId(298u);

	public static readonly NodeId EnumValueType_Encoding_DefaultBinary = new NodeId(8251u);

	public static readonly NodeId EnumField_Encoding_DefaultBinary = new NodeId(14845u);

	public static readonly NodeId OptionSet_Encoding_DefaultBinary = new NodeId(12765u);

	public static readonly NodeId TimeZoneDataType_Encoding_DefaultBinary = new NodeId(8917u);

	public static readonly NodeId ApplicationDescription_Encoding_DefaultBinary = new NodeId(310u);

	public static readonly NodeId RequestHeader_Encoding_DefaultBinary = new NodeId(391u);

	public static readonly NodeId ResponseHeader_Encoding_DefaultBinary = new NodeId(394u);

	public static readonly NodeId ServiceFault_Encoding_DefaultBinary = new NodeId(397u);

	public static readonly NodeId SessionlessInvokeRequestType_Encoding_DefaultBinary = new NodeId(15903u);

	public static readonly NodeId SessionlessInvokeResponseType_Encoding_DefaultBinary = new NodeId(21001u);

	public static readonly NodeId FindServersRequest_Encoding_DefaultBinary = new NodeId(422u);

	public static readonly NodeId FindServersResponse_Encoding_DefaultBinary = new NodeId(425u);

	public static readonly NodeId ServerOnNetwork_Encoding_DefaultBinary = new NodeId(12207u);

	public static readonly NodeId FindServersOnNetworkRequest_Encoding_DefaultBinary = new NodeId(12208u);

	public static readonly NodeId FindServersOnNetworkResponse_Encoding_DefaultBinary = new NodeId(12209u);

	public static readonly NodeId UserTokenPolicy_Encoding_DefaultBinary = new NodeId(306u);

	public static readonly NodeId EndpointDescription_Encoding_DefaultBinary = new NodeId(314u);

	public static readonly NodeId GetEndpointsRequest_Encoding_DefaultBinary = new NodeId(428u);

	public static readonly NodeId GetEndpointsResponse_Encoding_DefaultBinary = new NodeId(431u);

	public static readonly NodeId RegisteredServer_Encoding_DefaultBinary = new NodeId(434u);

	public static readonly NodeId RegisterServerRequest_Encoding_DefaultBinary = new NodeId(437u);

	public static readonly NodeId RegisterServerResponse_Encoding_DefaultBinary = new NodeId(440u);

	public static readonly NodeId DiscoveryConfiguration_Encoding_DefaultBinary = new NodeId(12900u);

	public static readonly NodeId MdnsDiscoveryConfiguration_Encoding_DefaultBinary = new NodeId(12901u);

	public static readonly NodeId RegisterServer2Request_Encoding_DefaultBinary = new NodeId(12211u);

	public static readonly NodeId RegisterServer2Response_Encoding_DefaultBinary = new NodeId(12212u);

	public static readonly NodeId ChannelSecurityToken_Encoding_DefaultBinary = new NodeId(443u);

	public static readonly NodeId OpenSecureChannelRequest_Encoding_DefaultBinary = new NodeId(446u);

	public static readonly NodeId OpenSecureChannelResponse_Encoding_DefaultBinary = new NodeId(449u);

	public static readonly NodeId CloseSecureChannelRequest_Encoding_DefaultBinary = new NodeId(452u);

	public static readonly NodeId CloseSecureChannelResponse_Encoding_DefaultBinary = new NodeId(455u);

	public static readonly NodeId SignedSoftwareCertificate_Encoding_DefaultBinary = new NodeId(346u);

	public static readonly NodeId SignatureData_Encoding_DefaultBinary = new NodeId(458u);

	public static readonly NodeId CreateSessionRequest_Encoding_DefaultBinary = new NodeId(461u);

	public static readonly NodeId CreateSessionResponse_Encoding_DefaultBinary = new NodeId(464u);

	public static readonly NodeId UserIdentityToken_Encoding_DefaultBinary = new NodeId(318u);

	public static readonly NodeId AnonymousIdentityToken_Encoding_DefaultBinary = new NodeId(321u);

	public static readonly NodeId UserNameIdentityToken_Encoding_DefaultBinary = new NodeId(324u);

	public static readonly NodeId X509IdentityToken_Encoding_DefaultBinary = new NodeId(327u);

	public static readonly NodeId IssuedIdentityToken_Encoding_DefaultBinary = new NodeId(940u);

	public static readonly NodeId ActivateSessionRequest_Encoding_DefaultBinary = new NodeId(467u);

	public static readonly NodeId ActivateSessionResponse_Encoding_DefaultBinary = new NodeId(470u);

	public static readonly NodeId CloseSessionRequest_Encoding_DefaultBinary = new NodeId(473u);

	public static readonly NodeId CloseSessionResponse_Encoding_DefaultBinary = new NodeId(476u);

	public static readonly NodeId CancelRequest_Encoding_DefaultBinary = new NodeId(479u);

	public static readonly NodeId CancelResponse_Encoding_DefaultBinary = new NodeId(482u);

	public static readonly NodeId NodeAttributes_Encoding_DefaultBinary = new NodeId(351u);

	public static readonly NodeId ObjectAttributes_Encoding_DefaultBinary = new NodeId(354u);

	public static readonly NodeId VariableAttributes_Encoding_DefaultBinary = new NodeId(357u);

	public static readonly NodeId MethodAttributes_Encoding_DefaultBinary = new NodeId(360u);

	public static readonly NodeId ObjectTypeAttributes_Encoding_DefaultBinary = new NodeId(363u);

	public static readonly NodeId VariableTypeAttributes_Encoding_DefaultBinary = new NodeId(366u);

	public static readonly NodeId ReferenceTypeAttributes_Encoding_DefaultBinary = new NodeId(369u);

	public static readonly NodeId DataTypeAttributes_Encoding_DefaultBinary = new NodeId(372u);

	public static readonly NodeId ViewAttributes_Encoding_DefaultBinary = new NodeId(375u);

	public static readonly NodeId GenericAttributeValue_Encoding_DefaultBinary = new NodeId(17610u);

	public static readonly NodeId GenericAttributes_Encoding_DefaultBinary = new NodeId(17611u);

	public static readonly NodeId AddNodesItem_Encoding_DefaultBinary = new NodeId(378u);

	public static readonly NodeId AddNodesResult_Encoding_DefaultBinary = new NodeId(485u);

	public static readonly NodeId AddNodesRequest_Encoding_DefaultBinary = new NodeId(488u);

	public static readonly NodeId AddNodesResponse_Encoding_DefaultBinary = new NodeId(491u);

	public static readonly NodeId AddReferencesItem_Encoding_DefaultBinary = new NodeId(381u);

	public static readonly NodeId AddReferencesRequest_Encoding_DefaultBinary = new NodeId(494u);

	public static readonly NodeId AddReferencesResponse_Encoding_DefaultBinary = new NodeId(497u);

	public static readonly NodeId DeleteNodesItem_Encoding_DefaultBinary = new NodeId(384u);

	public static readonly NodeId DeleteNodesRequest_Encoding_DefaultBinary = new NodeId(500u);

	public static readonly NodeId DeleteNodesResponse_Encoding_DefaultBinary = new NodeId(503u);

	public static readonly NodeId DeleteReferencesItem_Encoding_DefaultBinary = new NodeId(387u);

	public static readonly NodeId DeleteReferencesRequest_Encoding_DefaultBinary = new NodeId(506u);

	public static readonly NodeId DeleteReferencesResponse_Encoding_DefaultBinary = new NodeId(509u);

	public static readonly NodeId ViewDescription_Encoding_DefaultBinary = new NodeId(513u);

	public static readonly NodeId BrowseDescription_Encoding_DefaultBinary = new NodeId(516u);

	public static readonly NodeId ReferenceDescription_Encoding_DefaultBinary = new NodeId(520u);

	public static readonly NodeId BrowseResult_Encoding_DefaultBinary = new NodeId(524u);

	public static readonly NodeId BrowseRequest_Encoding_DefaultBinary = new NodeId(527u);

	public static readonly NodeId BrowseResponse_Encoding_DefaultBinary = new NodeId(530u);

	public static readonly NodeId BrowseNextRequest_Encoding_DefaultBinary = new NodeId(533u);

	public static readonly NodeId BrowseNextResponse_Encoding_DefaultBinary = new NodeId(536u);

	public static readonly NodeId RelativePathElement_Encoding_DefaultBinary = new NodeId(539u);

	public static readonly NodeId RelativePath_Encoding_DefaultBinary = new NodeId(542u);

	public static readonly NodeId BrowsePath_Encoding_DefaultBinary = new NodeId(545u);

	public static readonly NodeId BrowsePathTarget_Encoding_DefaultBinary = new NodeId(548u);

	public static readonly NodeId BrowsePathResult_Encoding_DefaultBinary = new NodeId(551u);

	public static readonly NodeId TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultBinary = new NodeId(554u);

	public static readonly NodeId TranslateBrowsePathsToNodeIdsResponse_Encoding_DefaultBinary = new NodeId(557u);

	public static readonly NodeId RegisterNodesRequest_Encoding_DefaultBinary = new NodeId(560u);

	public static readonly NodeId RegisterNodesResponse_Encoding_DefaultBinary = new NodeId(563u);

	public static readonly NodeId UnregisterNodesRequest_Encoding_DefaultBinary = new NodeId(566u);

	public static readonly NodeId UnregisterNodesResponse_Encoding_DefaultBinary = new NodeId(569u);

	public static readonly NodeId EndpointConfiguration_Encoding_DefaultBinary = new NodeId(333u);

	public static readonly NodeId QueryDataDescription_Encoding_DefaultBinary = new NodeId(572u);

	public static readonly NodeId NodeTypeDescription_Encoding_DefaultBinary = new NodeId(575u);

	public static readonly NodeId QueryDataSet_Encoding_DefaultBinary = new NodeId(579u);

	public static readonly NodeId NodeReference_Encoding_DefaultBinary = new NodeId(582u);

	public static readonly NodeId ContentFilterElement_Encoding_DefaultBinary = new NodeId(585u);

	public static readonly NodeId ContentFilter_Encoding_DefaultBinary = new NodeId(588u);

	public static readonly NodeId FilterOperand_Encoding_DefaultBinary = new NodeId(591u);

	public static readonly NodeId ElementOperand_Encoding_DefaultBinary = new NodeId(594u);

	public static readonly NodeId LiteralOperand_Encoding_DefaultBinary = new NodeId(597u);

	public static readonly NodeId AttributeOperand_Encoding_DefaultBinary = new NodeId(600u);

	public static readonly NodeId SimpleAttributeOperand_Encoding_DefaultBinary = new NodeId(603u);

	public static readonly NodeId ContentFilterElementResult_Encoding_DefaultBinary = new NodeId(606u);

	public static readonly NodeId ContentFilterResult_Encoding_DefaultBinary = new NodeId(609u);

	public static readonly NodeId ParsingResult_Encoding_DefaultBinary = new NodeId(612u);

	public static readonly NodeId QueryFirstRequest_Encoding_DefaultBinary = new NodeId(615u);

	public static readonly NodeId QueryFirstResponse_Encoding_DefaultBinary = new NodeId(618u);

	public static readonly NodeId QueryNextRequest_Encoding_DefaultBinary = new NodeId(621u);

	public static readonly NodeId QueryNextResponse_Encoding_DefaultBinary = new NodeId(624u);

	public static readonly NodeId ReadValueId_Encoding_DefaultBinary = new NodeId(628u);

	public static readonly NodeId ReadRequest_Encoding_DefaultBinary = new NodeId(631u);

	public static readonly NodeId ReadResponse_Encoding_DefaultBinary = new NodeId(634u);

	public static readonly NodeId HistoryReadValueId_Encoding_DefaultBinary = new NodeId(637u);

	public static readonly NodeId HistoryReadResult_Encoding_DefaultBinary = new NodeId(640u);

	public static readonly NodeId HistoryReadDetails_Encoding_DefaultBinary = new NodeId(643u);

	public static readonly NodeId ReadEventDetails_Encoding_DefaultBinary = new NodeId(646u);

	public static readonly NodeId ReadRawModifiedDetails_Encoding_DefaultBinary = new NodeId(649u);

	public static readonly NodeId ReadProcessedDetails_Encoding_DefaultBinary = new NodeId(652u);

	public static readonly NodeId ReadAtTimeDetails_Encoding_DefaultBinary = new NodeId(655u);

	public static readonly NodeId ReadAnnotationDataDetails_Encoding_DefaultBinary = new NodeId(23500u);

	public static readonly NodeId HistoryData_Encoding_DefaultBinary = new NodeId(658u);

	public static readonly NodeId ModificationInfo_Encoding_DefaultBinary = new NodeId(11226u);

	public static readonly NodeId HistoryModifiedData_Encoding_DefaultBinary = new NodeId(11227u);

	public static readonly NodeId HistoryEvent_Encoding_DefaultBinary = new NodeId(661u);

	public static readonly NodeId HistoryReadRequest_Encoding_DefaultBinary = new NodeId(664u);

	public static readonly NodeId HistoryReadResponse_Encoding_DefaultBinary = new NodeId(667u);

	public static readonly NodeId WriteValue_Encoding_DefaultBinary = new NodeId(670u);

	public static readonly NodeId WriteRequest_Encoding_DefaultBinary = new NodeId(673u);

	public static readonly NodeId WriteResponse_Encoding_DefaultBinary = new NodeId(676u);

	public static readonly NodeId HistoryUpdateDetails_Encoding_DefaultBinary = new NodeId(679u);

	public static readonly NodeId UpdateDataDetails_Encoding_DefaultBinary = new NodeId(682u);

	public static readonly NodeId UpdateStructureDataDetails_Encoding_DefaultBinary = new NodeId(11300u);

	public static readonly NodeId UpdateEventDetails_Encoding_DefaultBinary = new NodeId(685u);

	public static readonly NodeId DeleteRawModifiedDetails_Encoding_DefaultBinary = new NodeId(688u);

	public static readonly NodeId DeleteAtTimeDetails_Encoding_DefaultBinary = new NodeId(691u);

	public static readonly NodeId DeleteEventDetails_Encoding_DefaultBinary = new NodeId(694u);

	public static readonly NodeId HistoryUpdateResult_Encoding_DefaultBinary = new NodeId(697u);

	public static readonly NodeId HistoryUpdateRequest_Encoding_DefaultBinary = new NodeId(700u);

	public static readonly NodeId HistoryUpdateResponse_Encoding_DefaultBinary = new NodeId(703u);

	public static readonly NodeId CallMethodRequest_Encoding_DefaultBinary = new NodeId(706u);

	public static readonly NodeId CallMethodResult_Encoding_DefaultBinary = new NodeId(709u);

	public static readonly NodeId CallRequest_Encoding_DefaultBinary = new NodeId(712u);

	public static readonly NodeId CallResponse_Encoding_DefaultBinary = new NodeId(715u);

	public static readonly NodeId MonitoringFilter_Encoding_DefaultBinary = new NodeId(721u);

	public static readonly NodeId DataChangeFilter_Encoding_DefaultBinary = new NodeId(724u);

	public static readonly NodeId EventFilter_Encoding_DefaultBinary = new NodeId(727u);

	public static readonly NodeId AggregateConfiguration_Encoding_DefaultBinary = new NodeId(950u);

	public static readonly NodeId AggregateFilter_Encoding_DefaultBinary = new NodeId(730u);

	public static readonly NodeId MonitoringFilterResult_Encoding_DefaultBinary = new NodeId(733u);

	public static readonly NodeId EventFilterResult_Encoding_DefaultBinary = new NodeId(736u);

	public static readonly NodeId AggregateFilterResult_Encoding_DefaultBinary = new NodeId(739u);

	public static readonly NodeId MonitoringParameters_Encoding_DefaultBinary = new NodeId(742u);

	public static readonly NodeId MonitoredItemCreateRequest_Encoding_DefaultBinary = new NodeId(745u);

	public static readonly NodeId MonitoredItemCreateResult_Encoding_DefaultBinary = new NodeId(748u);

	public static readonly NodeId CreateMonitoredItemsRequest_Encoding_DefaultBinary = new NodeId(751u);

	public static readonly NodeId CreateMonitoredItemsResponse_Encoding_DefaultBinary = new NodeId(754u);

	public static readonly NodeId MonitoredItemModifyRequest_Encoding_DefaultBinary = new NodeId(757u);

	public static readonly NodeId MonitoredItemModifyResult_Encoding_DefaultBinary = new NodeId(760u);

	public static readonly NodeId ModifyMonitoredItemsRequest_Encoding_DefaultBinary = new NodeId(763u);

	public static readonly NodeId ModifyMonitoredItemsResponse_Encoding_DefaultBinary = new NodeId(766u);

	public static readonly NodeId SetMonitoringModeRequest_Encoding_DefaultBinary = new NodeId(769u);

	public static readonly NodeId SetMonitoringModeResponse_Encoding_DefaultBinary = new NodeId(772u);

	public static readonly NodeId SetTriggeringRequest_Encoding_DefaultBinary = new NodeId(775u);

	public static readonly NodeId SetTriggeringResponse_Encoding_DefaultBinary = new NodeId(778u);

	public static readonly NodeId DeleteMonitoredItemsRequest_Encoding_DefaultBinary = new NodeId(781u);

	public static readonly NodeId DeleteMonitoredItemsResponse_Encoding_DefaultBinary = new NodeId(784u);

	public static readonly NodeId CreateSubscriptionRequest_Encoding_DefaultBinary = new NodeId(787u);

	public static readonly NodeId CreateSubscriptionResponse_Encoding_DefaultBinary = new NodeId(790u);

	public static readonly NodeId ModifySubscriptionRequest_Encoding_DefaultBinary = new NodeId(793u);

	public static readonly NodeId ModifySubscriptionResponse_Encoding_DefaultBinary = new NodeId(796u);

	public static readonly NodeId SetPublishingModeRequest_Encoding_DefaultBinary = new NodeId(799u);

	public static readonly NodeId SetPublishingModeResponse_Encoding_DefaultBinary = new NodeId(802u);

	public static readonly NodeId NotificationMessage_Encoding_DefaultBinary = new NodeId(805u);

	public static readonly NodeId NotificationData_Encoding_DefaultBinary = new NodeId(947u);

	public static readonly NodeId DataChangeNotification_Encoding_DefaultBinary = new NodeId(811u);

	public static readonly NodeId MonitoredItemNotification_Encoding_DefaultBinary = new NodeId(808u);

	public static readonly NodeId EventNotificationList_Encoding_DefaultBinary = new NodeId(916u);

	public static readonly NodeId EventFieldList_Encoding_DefaultBinary = new NodeId(919u);

	public static readonly NodeId HistoryEventFieldList_Encoding_DefaultBinary = new NodeId(922u);

	public static readonly NodeId StatusChangeNotification_Encoding_DefaultBinary = new NodeId(820u);

	public static readonly NodeId SubscriptionAcknowledgement_Encoding_DefaultBinary = new NodeId(823u);

	public static readonly NodeId PublishRequest_Encoding_DefaultBinary = new NodeId(826u);

	public static readonly NodeId PublishResponse_Encoding_DefaultBinary = new NodeId(829u);

	public static readonly NodeId RepublishRequest_Encoding_DefaultBinary = new NodeId(832u);

	public static readonly NodeId RepublishResponse_Encoding_DefaultBinary = new NodeId(835u);

	public static readonly NodeId TransferResult_Encoding_DefaultBinary = new NodeId(838u);

	public static readonly NodeId TransferSubscriptionsRequest_Encoding_DefaultBinary = new NodeId(841u);

	public static readonly NodeId TransferSubscriptionsResponse_Encoding_DefaultBinary = new NodeId(844u);

	public static readonly NodeId DeleteSubscriptionsRequest_Encoding_DefaultBinary = new NodeId(847u);

	public static readonly NodeId DeleteSubscriptionsResponse_Encoding_DefaultBinary = new NodeId(850u);

	public static readonly NodeId BuildInfo_Encoding_DefaultBinary = new NodeId(340u);

	public static readonly NodeId RedundantServerDataType_Encoding_DefaultBinary = new NodeId(855u);

	public static readonly NodeId EndpointUrlListDataType_Encoding_DefaultBinary = new NodeId(11957u);

	public static readonly NodeId NetworkGroupDataType_Encoding_DefaultBinary = new NodeId(11958u);

	public static readonly NodeId SamplingIntervalDiagnosticsDataType_Encoding_DefaultBinary = new NodeId(858u);

	public static readonly NodeId ServerDiagnosticsSummaryDataType_Encoding_DefaultBinary = new NodeId(861u);

	public static readonly NodeId ServerStatusDataType_Encoding_DefaultBinary = new NodeId(864u);

	public static readonly NodeId SessionDiagnosticsDataType_Encoding_DefaultBinary = new NodeId(867u);

	public static readonly NodeId SessionSecurityDiagnosticsDataType_Encoding_DefaultBinary = new NodeId(870u);

	public static readonly NodeId ServiceCounterDataType_Encoding_DefaultBinary = new NodeId(873u);

	public static readonly NodeId StatusResult_Encoding_DefaultBinary = new NodeId(301u);

	public static readonly NodeId SubscriptionDiagnosticsDataType_Encoding_DefaultBinary = new NodeId(876u);

	public static readonly NodeId ModelChangeStructureDataType_Encoding_DefaultBinary = new NodeId(879u);

	public static readonly NodeId SemanticChangeStructureDataType_Encoding_DefaultBinary = new NodeId(899u);

	public static readonly NodeId Range_Encoding_DefaultBinary = new NodeId(886u);

	public static readonly NodeId EUInformation_Encoding_DefaultBinary = new NodeId(889u);

	public static readonly NodeId ComplexNumberType_Encoding_DefaultBinary = new NodeId(12181u);

	public static readonly NodeId DoubleComplexNumberType_Encoding_DefaultBinary = new NodeId(12182u);

	public static readonly NodeId AxisInformation_Encoding_DefaultBinary = new NodeId(12089u);

	public static readonly NodeId XVType_Encoding_DefaultBinary = new NodeId(12090u);

	public static readonly NodeId ProgramDiagnosticDataType_Encoding_DefaultBinary = new NodeId(896u);

	public static readonly NodeId ProgramDiagnostic2DataType_Encoding_DefaultBinary = new NodeId(24034u);

	public static readonly NodeId Annotation_Encoding_DefaultBinary = new NodeId(893u);

	public static readonly NodeId Union_Encoding_DefaultXml = new NodeId(12758u);

	public static readonly NodeId KeyValuePair_Encoding_DefaultXml = new NodeId(14802u);

	public static readonly NodeId AdditionalParametersType_Encoding_DefaultXml = new NodeId(17541u);

	public static readonly NodeId EphemeralKeyType_Encoding_DefaultXml = new NodeId(17553u);

	public static readonly NodeId EndpointType_Encoding_DefaultXml = new NodeId(15949u);

	public static readonly NodeId RationalNumber_Encoding_DefaultXml = new NodeId(18851u);

	public static readonly NodeId Vector_Encoding_DefaultXml = new NodeId(18852u);

	public static readonly NodeId ThreeDVector_Encoding_DefaultXml = new NodeId(18853u);

	public static readonly NodeId CartesianCoordinates_Encoding_DefaultXml = new NodeId(18854u);

	public static readonly NodeId ThreeDCartesianCoordinates_Encoding_DefaultXml = new NodeId(18855u);

	public static readonly NodeId Orientation_Encoding_DefaultXml = new NodeId(18856u);

	public static readonly NodeId ThreeDOrientation_Encoding_DefaultXml = new NodeId(18857u);

	public static readonly NodeId Frame_Encoding_DefaultXml = new NodeId(18858u);

	public static readonly NodeId ThreeDFrame_Encoding_DefaultXml = new NodeId(18859u);

	public static readonly NodeId IdentityMappingRuleType_Encoding_DefaultXml = new NodeId(15728u);

	public static readonly NodeId CurrencyUnitType_Encoding_DefaultXml = new NodeId(23520u);

	public static readonly NodeId TrustListDataType_Encoding_DefaultXml = new NodeId(12676u);

	public static readonly NodeId DecimalDataType_Encoding_DefaultXml = new NodeId(17862u);

	public static readonly NodeId DataTypeSchemaHeader_Encoding_DefaultXml = new NodeId(15950u);

	public static readonly NodeId DataTypeDescription_Encoding_DefaultXml = new NodeId(14796u);

	public static readonly NodeId StructureDescription_Encoding_DefaultXml = new NodeId(15589u);

	public static readonly NodeId EnumDescription_Encoding_DefaultXml = new NodeId(15590u);

	public static readonly NodeId SimpleTypeDescription_Encoding_DefaultXml = new NodeId(15529u);

	public static readonly NodeId UABinaryFileDataType_Encoding_DefaultXml = new NodeId(15531u);

	public static readonly NodeId DataSetMetaDataType_Encoding_DefaultXml = new NodeId(14794u);

	public static readonly NodeId FieldMetaData_Encoding_DefaultXml = new NodeId(14795u);

	public static readonly NodeId ConfigurationVersionDataType_Encoding_DefaultXml = new NodeId(14803u);

	public static readonly NodeId PublishedDataSetDataType_Encoding_DefaultXml = new NodeId(15951u);

	public static readonly NodeId PublishedDataSetSourceDataType_Encoding_DefaultXml = new NodeId(15952u);

	public static readonly NodeId PublishedVariableDataType_Encoding_DefaultXml = new NodeId(14319u);

	public static readonly NodeId PublishedDataItemsDataType_Encoding_DefaultXml = new NodeId(15953u);

	public static readonly NodeId PublishedEventsDataType_Encoding_DefaultXml = new NodeId(15954u);

	public static readonly NodeId DataSetWriterDataType_Encoding_DefaultXml = new NodeId(15955u);

	public static readonly NodeId DataSetWriterTransportDataType_Encoding_DefaultXml = new NodeId(15956u);

	public static readonly NodeId DataSetWriterMessageDataType_Encoding_DefaultXml = new NodeId(15987u);

	public static readonly NodeId PubSubGroupDataType_Encoding_DefaultXml = new NodeId(15988u);

	public static readonly NodeId WriterGroupDataType_Encoding_DefaultXml = new NodeId(21174u);

	public static readonly NodeId WriterGroupTransportDataType_Encoding_DefaultXml = new NodeId(15990u);

	public static readonly NodeId WriterGroupMessageDataType_Encoding_DefaultXml = new NodeId(15991u);

	public static readonly NodeId PubSubConnectionDataType_Encoding_DefaultXml = new NodeId(15992u);

	public static readonly NodeId ConnectionTransportDataType_Encoding_DefaultXml = new NodeId(15993u);

	public static readonly NodeId NetworkAddressDataType_Encoding_DefaultXml = new NodeId(21175u);

	public static readonly NodeId NetworkAddressUrlDataType_Encoding_DefaultXml = new NodeId(21176u);

	public static readonly NodeId ReaderGroupDataType_Encoding_DefaultXml = new NodeId(21177u);

	public static readonly NodeId ReaderGroupTransportDataType_Encoding_DefaultXml = new NodeId(15995u);

	public static readonly NodeId ReaderGroupMessageDataType_Encoding_DefaultXml = new NodeId(15996u);

	public static readonly NodeId DataSetReaderDataType_Encoding_DefaultXml = new NodeId(16007u);

	public static readonly NodeId DataSetReaderTransportDataType_Encoding_DefaultXml = new NodeId(16008u);

	public static readonly NodeId DataSetReaderMessageDataType_Encoding_DefaultXml = new NodeId(16009u);

	public static readonly NodeId SubscribedDataSetDataType_Encoding_DefaultXml = new NodeId(16010u);

	public static readonly NodeId TargetVariablesDataType_Encoding_DefaultXml = new NodeId(16011u);

	public static readonly NodeId FieldTargetDataType_Encoding_DefaultXml = new NodeId(14804u);

	public static readonly NodeId SubscribedDataSetMirrorDataType_Encoding_DefaultXml = new NodeId(16012u);

	public static readonly NodeId PubSubConfigurationDataType_Encoding_DefaultXml = new NodeId(21178u);

	public static readonly NodeId UadpWriterGroupMessageDataType_Encoding_DefaultXml = new NodeId(16014u);

	public static readonly NodeId UadpDataSetWriterMessageDataType_Encoding_DefaultXml = new NodeId(16015u);

	public static readonly NodeId UadpDataSetReaderMessageDataType_Encoding_DefaultXml = new NodeId(16016u);

	public static readonly NodeId JsonWriterGroupMessageDataType_Encoding_DefaultXml = new NodeId(16017u);

	public static readonly NodeId JsonDataSetWriterMessageDataType_Encoding_DefaultXml = new NodeId(16018u);

	public static readonly NodeId JsonDataSetReaderMessageDataType_Encoding_DefaultXml = new NodeId(16019u);

	public static readonly NodeId DatagramConnectionTransportDataType_Encoding_DefaultXml = new NodeId(17472u);

	public static readonly NodeId DatagramWriterGroupTransportDataType_Encoding_DefaultXml = new NodeId(21179u);

	public static readonly NodeId BrokerConnectionTransportDataType_Encoding_DefaultXml = new NodeId(15579u);

	public static readonly NodeId BrokerWriterGroupTransportDataType_Encoding_DefaultXml = new NodeId(16021u);

	public static readonly NodeId BrokerDataSetWriterTransportDataType_Encoding_DefaultXml = new NodeId(16022u);

	public static readonly NodeId BrokerDataSetReaderTransportDataType_Encoding_DefaultXml = new NodeId(16023u);

	public static readonly NodeId AliasNameDataType_Encoding_DefaultXml = new NodeId(23505u);

	public static readonly NodeId UnsignedRationalNumber_Encoding_DefaultXml = new NodeId(24122u);

	public static readonly NodeId RolePermissionType_Encoding_DefaultXml = new NodeId(16126u);

	public static readonly NodeId DataTypeDefinition_Encoding_DefaultXml = new NodeId(14797u);

	public static readonly NodeId StructureField_Encoding_DefaultXml = new NodeId(14800u);

	public static readonly NodeId StructureDefinition_Encoding_DefaultXml = new NodeId(14798u);

	public static readonly NodeId EnumDefinition_Encoding_DefaultXml = new NodeId(14799u);

	public static readonly NodeId Node_Encoding_DefaultXml = new NodeId(259u);

	public static readonly NodeId InstanceNode_Encoding_DefaultXml = new NodeId(11887u);

	public static readonly NodeId TypeNode_Encoding_DefaultXml = new NodeId(11888u);

	public static readonly NodeId ObjectNode_Encoding_DefaultXml = new NodeId(262u);

	public static readonly NodeId ObjectTypeNode_Encoding_DefaultXml = new NodeId(265u);

	public static readonly NodeId VariableNode_Encoding_DefaultXml = new NodeId(268u);

	public static readonly NodeId VariableTypeNode_Encoding_DefaultXml = new NodeId(271u);

	public static readonly NodeId ReferenceTypeNode_Encoding_DefaultXml = new NodeId(274u);

	public static readonly NodeId MethodNode_Encoding_DefaultXml = new NodeId(277u);

	public static readonly NodeId ViewNode_Encoding_DefaultXml = new NodeId(280u);

	public static readonly NodeId DataTypeNode_Encoding_DefaultXml = new NodeId(283u);

	public static readonly NodeId ReferenceNode_Encoding_DefaultXml = new NodeId(286u);

	public static readonly NodeId Argument_Encoding_DefaultXml = new NodeId(297u);

	public static readonly NodeId EnumValueType_Encoding_DefaultXml = new NodeId(7616u);

	public static readonly NodeId EnumField_Encoding_DefaultXml = new NodeId(14801u);

	public static readonly NodeId OptionSet_Encoding_DefaultXml = new NodeId(12757u);

	public static readonly NodeId TimeZoneDataType_Encoding_DefaultXml = new NodeId(8913u);

	public static readonly NodeId ApplicationDescription_Encoding_DefaultXml = new NodeId(309u);

	public static readonly NodeId RequestHeader_Encoding_DefaultXml = new NodeId(390u);

	public static readonly NodeId ResponseHeader_Encoding_DefaultXml = new NodeId(393u);

	public static readonly NodeId ServiceFault_Encoding_DefaultXml = new NodeId(396u);

	public static readonly NodeId SessionlessInvokeRequestType_Encoding_DefaultXml = new NodeId(15902u);

	public static readonly NodeId SessionlessInvokeResponseType_Encoding_DefaultXml = new NodeId(21000u);

	public static readonly NodeId FindServersRequest_Encoding_DefaultXml = new NodeId(421u);

	public static readonly NodeId FindServersResponse_Encoding_DefaultXml = new NodeId(424u);

	public static readonly NodeId ServerOnNetwork_Encoding_DefaultXml = new NodeId(12195u);

	public static readonly NodeId FindServersOnNetworkRequest_Encoding_DefaultXml = new NodeId(12196u);

	public static readonly NodeId FindServersOnNetworkResponse_Encoding_DefaultXml = new NodeId(12197u);

	public static readonly NodeId UserTokenPolicy_Encoding_DefaultXml = new NodeId(305u);

	public static readonly NodeId EndpointDescription_Encoding_DefaultXml = new NodeId(313u);

	public static readonly NodeId GetEndpointsRequest_Encoding_DefaultXml = new NodeId(427u);

	public static readonly NodeId GetEndpointsResponse_Encoding_DefaultXml = new NodeId(430u);

	public static readonly NodeId RegisteredServer_Encoding_DefaultXml = new NodeId(433u);

	public static readonly NodeId RegisterServerRequest_Encoding_DefaultXml = new NodeId(436u);

	public static readonly NodeId RegisterServerResponse_Encoding_DefaultXml = new NodeId(439u);

	public static readonly NodeId DiscoveryConfiguration_Encoding_DefaultXml = new NodeId(12892u);

	public static readonly NodeId MdnsDiscoveryConfiguration_Encoding_DefaultXml = new NodeId(12893u);

	public static readonly NodeId RegisterServer2Request_Encoding_DefaultXml = new NodeId(12199u);

	public static readonly NodeId RegisterServer2Response_Encoding_DefaultXml = new NodeId(12200u);

	public static readonly NodeId ChannelSecurityToken_Encoding_DefaultXml = new NodeId(442u);

	public static readonly NodeId OpenSecureChannelRequest_Encoding_DefaultXml = new NodeId(445u);

	public static readonly NodeId OpenSecureChannelResponse_Encoding_DefaultXml = new NodeId(448u);

	public static readonly NodeId CloseSecureChannelRequest_Encoding_DefaultXml = new NodeId(451u);

	public static readonly NodeId CloseSecureChannelResponse_Encoding_DefaultXml = new NodeId(454u);

	public static readonly NodeId SignedSoftwareCertificate_Encoding_DefaultXml = new NodeId(345u);

	public static readonly NodeId SignatureData_Encoding_DefaultXml = new NodeId(457u);

	public static readonly NodeId CreateSessionRequest_Encoding_DefaultXml = new NodeId(460u);

	public static readonly NodeId CreateSessionResponse_Encoding_DefaultXml = new NodeId(463u);

	public static readonly NodeId UserIdentityToken_Encoding_DefaultXml = new NodeId(317u);

	public static readonly NodeId AnonymousIdentityToken_Encoding_DefaultXml = new NodeId(320u);

	public static readonly NodeId UserNameIdentityToken_Encoding_DefaultXml = new NodeId(323u);

	public static readonly NodeId X509IdentityToken_Encoding_DefaultXml = new NodeId(326u);

	public static readonly NodeId IssuedIdentityToken_Encoding_DefaultXml = new NodeId(939u);

	public static readonly NodeId ActivateSessionRequest_Encoding_DefaultXml = new NodeId(466u);

	public static readonly NodeId ActivateSessionResponse_Encoding_DefaultXml = new NodeId(469u);

	public static readonly NodeId CloseSessionRequest_Encoding_DefaultXml = new NodeId(472u);

	public static readonly NodeId CloseSessionResponse_Encoding_DefaultXml = new NodeId(475u);

	public static readonly NodeId CancelRequest_Encoding_DefaultXml = new NodeId(478u);

	public static readonly NodeId CancelResponse_Encoding_DefaultXml = new NodeId(481u);

	public static readonly NodeId NodeAttributes_Encoding_DefaultXml = new NodeId(350u);

	public static readonly NodeId ObjectAttributes_Encoding_DefaultXml = new NodeId(353u);

	public static readonly NodeId VariableAttributes_Encoding_DefaultXml = new NodeId(356u);

	public static readonly NodeId MethodAttributes_Encoding_DefaultXml = new NodeId(359u);

	public static readonly NodeId ObjectTypeAttributes_Encoding_DefaultXml = new NodeId(362u);

	public static readonly NodeId VariableTypeAttributes_Encoding_DefaultXml = new NodeId(365u);

	public static readonly NodeId ReferenceTypeAttributes_Encoding_DefaultXml = new NodeId(368u);

	public static readonly NodeId DataTypeAttributes_Encoding_DefaultXml = new NodeId(371u);

	public static readonly NodeId ViewAttributes_Encoding_DefaultXml = new NodeId(374u);

	public static readonly NodeId GenericAttributeValue_Encoding_DefaultXml = new NodeId(17608u);

	public static readonly NodeId GenericAttributes_Encoding_DefaultXml = new NodeId(17609u);

	public static readonly NodeId AddNodesItem_Encoding_DefaultXml = new NodeId(377u);

	public static readonly NodeId AddNodesResult_Encoding_DefaultXml = new NodeId(484u);

	public static readonly NodeId AddNodesRequest_Encoding_DefaultXml = new NodeId(487u);

	public static readonly NodeId AddNodesResponse_Encoding_DefaultXml = new NodeId(490u);

	public static readonly NodeId AddReferencesItem_Encoding_DefaultXml = new NodeId(380u);

	public static readonly NodeId AddReferencesRequest_Encoding_DefaultXml = new NodeId(493u);

	public static readonly NodeId AddReferencesResponse_Encoding_DefaultXml = new NodeId(496u);

	public static readonly NodeId DeleteNodesItem_Encoding_DefaultXml = new NodeId(383u);

	public static readonly NodeId DeleteNodesRequest_Encoding_DefaultXml = new NodeId(499u);

	public static readonly NodeId DeleteNodesResponse_Encoding_DefaultXml = new NodeId(502u);

	public static readonly NodeId DeleteReferencesItem_Encoding_DefaultXml = new NodeId(386u);

	public static readonly NodeId DeleteReferencesRequest_Encoding_DefaultXml = new NodeId(505u);

	public static readonly NodeId DeleteReferencesResponse_Encoding_DefaultXml = new NodeId(508u);

	public static readonly NodeId ViewDescription_Encoding_DefaultXml = new NodeId(512u);

	public static readonly NodeId BrowseDescription_Encoding_DefaultXml = new NodeId(515u);

	public static readonly NodeId ReferenceDescription_Encoding_DefaultXml = new NodeId(519u);

	public static readonly NodeId BrowseResult_Encoding_DefaultXml = new NodeId(523u);

	public static readonly NodeId BrowseRequest_Encoding_DefaultXml = new NodeId(526u);

	public static readonly NodeId BrowseResponse_Encoding_DefaultXml = new NodeId(529u);

	public static readonly NodeId BrowseNextRequest_Encoding_DefaultXml = new NodeId(532u);

	public static readonly NodeId BrowseNextResponse_Encoding_DefaultXml = new NodeId(535u);

	public static readonly NodeId RelativePathElement_Encoding_DefaultXml = new NodeId(538u);

	public static readonly NodeId RelativePath_Encoding_DefaultXml = new NodeId(541u);

	public static readonly NodeId BrowsePath_Encoding_DefaultXml = new NodeId(544u);

	public static readonly NodeId BrowsePathTarget_Encoding_DefaultXml = new NodeId(547u);

	public static readonly NodeId BrowsePathResult_Encoding_DefaultXml = new NodeId(550u);

	public static readonly NodeId TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultXml = new NodeId(553u);

	public static readonly NodeId TranslateBrowsePathsToNodeIdsResponse_Encoding_DefaultXml = new NodeId(556u);

	public static readonly NodeId RegisterNodesRequest_Encoding_DefaultXml = new NodeId(559u);

	public static readonly NodeId RegisterNodesResponse_Encoding_DefaultXml = new NodeId(562u);

	public static readonly NodeId UnregisterNodesRequest_Encoding_DefaultXml = new NodeId(565u);

	public static readonly NodeId UnregisterNodesResponse_Encoding_DefaultXml = new NodeId(568u);

	public static readonly NodeId EndpointConfiguration_Encoding_DefaultXml = new NodeId(332u);

	public static readonly NodeId QueryDataDescription_Encoding_DefaultXml = new NodeId(571u);

	public static readonly NodeId NodeTypeDescription_Encoding_DefaultXml = new NodeId(574u);

	public static readonly NodeId QueryDataSet_Encoding_DefaultXml = new NodeId(578u);

	public static readonly NodeId NodeReference_Encoding_DefaultXml = new NodeId(581u);

	public static readonly NodeId ContentFilterElement_Encoding_DefaultXml = new NodeId(584u);

	public static readonly NodeId ContentFilter_Encoding_DefaultXml = new NodeId(587u);

	public static readonly NodeId FilterOperand_Encoding_DefaultXml = new NodeId(590u);

	public static readonly NodeId ElementOperand_Encoding_DefaultXml = new NodeId(593u);

	public static readonly NodeId LiteralOperand_Encoding_DefaultXml = new NodeId(596u);

	public static readonly NodeId AttributeOperand_Encoding_DefaultXml = new NodeId(599u);

	public static readonly NodeId SimpleAttributeOperand_Encoding_DefaultXml = new NodeId(602u);

	public static readonly NodeId ContentFilterElementResult_Encoding_DefaultXml = new NodeId(605u);

	public static readonly NodeId ContentFilterResult_Encoding_DefaultXml = new NodeId(608u);

	public static readonly NodeId ParsingResult_Encoding_DefaultXml = new NodeId(611u);

	public static readonly NodeId QueryFirstRequest_Encoding_DefaultXml = new NodeId(614u);

	public static readonly NodeId QueryFirstResponse_Encoding_DefaultXml = new NodeId(617u);

	public static readonly NodeId QueryNextRequest_Encoding_DefaultXml = new NodeId(620u);

	public static readonly NodeId QueryNextResponse_Encoding_DefaultXml = new NodeId(623u);

	public static readonly NodeId ReadValueId_Encoding_DefaultXml = new NodeId(627u);

	public static readonly NodeId ReadRequest_Encoding_DefaultXml = new NodeId(630u);

	public static readonly NodeId ReadResponse_Encoding_DefaultXml = new NodeId(633u);

	public static readonly NodeId HistoryReadValueId_Encoding_DefaultXml = new NodeId(636u);

	public static readonly NodeId HistoryReadResult_Encoding_DefaultXml = new NodeId(639u);

	public static readonly NodeId HistoryReadDetails_Encoding_DefaultXml = new NodeId(642u);

	public static readonly NodeId ReadEventDetails_Encoding_DefaultXml = new NodeId(645u);

	public static readonly NodeId ReadRawModifiedDetails_Encoding_DefaultXml = new NodeId(648u);

	public static readonly NodeId ReadProcessedDetails_Encoding_DefaultXml = new NodeId(651u);

	public static readonly NodeId ReadAtTimeDetails_Encoding_DefaultXml = new NodeId(654u);

	public static readonly NodeId ReadAnnotationDataDetails_Encoding_DefaultXml = new NodeId(23506u);

	public static readonly NodeId HistoryData_Encoding_DefaultXml = new NodeId(657u);

	public static readonly NodeId ModificationInfo_Encoding_DefaultXml = new NodeId(11218u);

	public static readonly NodeId HistoryModifiedData_Encoding_DefaultXml = new NodeId(11219u);

	public static readonly NodeId HistoryEvent_Encoding_DefaultXml = new NodeId(660u);

	public static readonly NodeId HistoryReadRequest_Encoding_DefaultXml = new NodeId(663u);

	public static readonly NodeId HistoryReadResponse_Encoding_DefaultXml = new NodeId(666u);

	public static readonly NodeId WriteValue_Encoding_DefaultXml = new NodeId(669u);

	public static readonly NodeId WriteRequest_Encoding_DefaultXml = new NodeId(672u);

	public static readonly NodeId WriteResponse_Encoding_DefaultXml = new NodeId(675u);

	public static readonly NodeId HistoryUpdateDetails_Encoding_DefaultXml = new NodeId(678u);

	public static readonly NodeId UpdateDataDetails_Encoding_DefaultXml = new NodeId(681u);

	public static readonly NodeId UpdateStructureDataDetails_Encoding_DefaultXml = new NodeId(11296u);

	public static readonly NodeId UpdateEventDetails_Encoding_DefaultXml = new NodeId(684u);

	public static readonly NodeId DeleteRawModifiedDetails_Encoding_DefaultXml = new NodeId(687u);

	public static readonly NodeId DeleteAtTimeDetails_Encoding_DefaultXml = new NodeId(690u);

	public static readonly NodeId DeleteEventDetails_Encoding_DefaultXml = new NodeId(693u);

	public static readonly NodeId HistoryUpdateResult_Encoding_DefaultXml = new NodeId(696u);

	public static readonly NodeId HistoryUpdateRequest_Encoding_DefaultXml = new NodeId(699u);

	public static readonly NodeId HistoryUpdateResponse_Encoding_DefaultXml = new NodeId(702u);

	public static readonly NodeId CallMethodRequest_Encoding_DefaultXml = new NodeId(705u);

	public static readonly NodeId CallMethodResult_Encoding_DefaultXml = new NodeId(708u);

	public static readonly NodeId CallRequest_Encoding_DefaultXml = new NodeId(711u);

	public static readonly NodeId CallResponse_Encoding_DefaultXml = new NodeId(714u);

	public static readonly NodeId MonitoringFilter_Encoding_DefaultXml = new NodeId(720u);

	public static readonly NodeId DataChangeFilter_Encoding_DefaultXml = new NodeId(723u);

	public static readonly NodeId EventFilter_Encoding_DefaultXml = new NodeId(726u);

	public static readonly NodeId AggregateConfiguration_Encoding_DefaultXml = new NodeId(949u);

	public static readonly NodeId AggregateFilter_Encoding_DefaultXml = new NodeId(729u);

	public static readonly NodeId MonitoringFilterResult_Encoding_DefaultXml = new NodeId(732u);

	public static readonly NodeId EventFilterResult_Encoding_DefaultXml = new NodeId(735u);

	public static readonly NodeId AggregateFilterResult_Encoding_DefaultXml = new NodeId(738u);

	public static readonly NodeId MonitoringParameters_Encoding_DefaultXml = new NodeId(741u);

	public static readonly NodeId MonitoredItemCreateRequest_Encoding_DefaultXml = new NodeId(744u);

	public static readonly NodeId MonitoredItemCreateResult_Encoding_DefaultXml = new NodeId(747u);

	public static readonly NodeId CreateMonitoredItemsRequest_Encoding_DefaultXml = new NodeId(750u);

	public static readonly NodeId CreateMonitoredItemsResponse_Encoding_DefaultXml = new NodeId(753u);

	public static readonly NodeId MonitoredItemModifyRequest_Encoding_DefaultXml = new NodeId(756u);

	public static readonly NodeId MonitoredItemModifyResult_Encoding_DefaultXml = new NodeId(759u);

	public static readonly NodeId ModifyMonitoredItemsRequest_Encoding_DefaultXml = new NodeId(762u);

	public static readonly NodeId ModifyMonitoredItemsResponse_Encoding_DefaultXml = new NodeId(765u);

	public static readonly NodeId SetMonitoringModeRequest_Encoding_DefaultXml = new NodeId(768u);

	public static readonly NodeId SetMonitoringModeResponse_Encoding_DefaultXml = new NodeId(771u);

	public static readonly NodeId SetTriggeringRequest_Encoding_DefaultXml = new NodeId(774u);

	public static readonly NodeId SetTriggeringResponse_Encoding_DefaultXml = new NodeId(777u);

	public static readonly NodeId DeleteMonitoredItemsRequest_Encoding_DefaultXml = new NodeId(780u);

	public static readonly NodeId DeleteMonitoredItemsResponse_Encoding_DefaultXml = new NodeId(783u);

	public static readonly NodeId CreateSubscriptionRequest_Encoding_DefaultXml = new NodeId(786u);

	public static readonly NodeId CreateSubscriptionResponse_Encoding_DefaultXml = new NodeId(789u);

	public static readonly NodeId ModifySubscriptionRequest_Encoding_DefaultXml = new NodeId(792u);

	public static readonly NodeId ModifySubscriptionResponse_Encoding_DefaultXml = new NodeId(795u);

	public static readonly NodeId SetPublishingModeRequest_Encoding_DefaultXml = new NodeId(798u);

	public static readonly NodeId SetPublishingModeResponse_Encoding_DefaultXml = new NodeId(801u);

	public static readonly NodeId NotificationMessage_Encoding_DefaultXml = new NodeId(804u);

	public static readonly NodeId NotificationData_Encoding_DefaultXml = new NodeId(946u);

	public static readonly NodeId DataChangeNotification_Encoding_DefaultXml = new NodeId(810u);

	public static readonly NodeId MonitoredItemNotification_Encoding_DefaultXml = new NodeId(807u);

	public static readonly NodeId EventNotificationList_Encoding_DefaultXml = new NodeId(915u);

	public static readonly NodeId EventFieldList_Encoding_DefaultXml = new NodeId(918u);

	public static readonly NodeId HistoryEventFieldList_Encoding_DefaultXml = new NodeId(921u);

	public static readonly NodeId StatusChangeNotification_Encoding_DefaultXml = new NodeId(819u);

	public static readonly NodeId SubscriptionAcknowledgement_Encoding_DefaultXml = new NodeId(822u);

	public static readonly NodeId PublishRequest_Encoding_DefaultXml = new NodeId(825u);

	public static readonly NodeId PublishResponse_Encoding_DefaultXml = new NodeId(828u);

	public static readonly NodeId RepublishRequest_Encoding_DefaultXml = new NodeId(831u);

	public static readonly NodeId RepublishResponse_Encoding_DefaultXml = new NodeId(834u);

	public static readonly NodeId TransferResult_Encoding_DefaultXml = new NodeId(837u);

	public static readonly NodeId TransferSubscriptionsRequest_Encoding_DefaultXml = new NodeId(840u);

	public static readonly NodeId TransferSubscriptionsResponse_Encoding_DefaultXml = new NodeId(843u);

	public static readonly NodeId DeleteSubscriptionsRequest_Encoding_DefaultXml = new NodeId(846u);

	public static readonly NodeId DeleteSubscriptionsResponse_Encoding_DefaultXml = new NodeId(849u);

	public static readonly NodeId BuildInfo_Encoding_DefaultXml = new NodeId(339u);

	public static readonly NodeId RedundantServerDataType_Encoding_DefaultXml = new NodeId(854u);

	public static readonly NodeId EndpointUrlListDataType_Encoding_DefaultXml = new NodeId(11949u);

	public static readonly NodeId NetworkGroupDataType_Encoding_DefaultXml = new NodeId(11950u);

	public static readonly NodeId SamplingIntervalDiagnosticsDataType_Encoding_DefaultXml = new NodeId(857u);

	public static readonly NodeId ServerDiagnosticsSummaryDataType_Encoding_DefaultXml = new NodeId(860u);

	public static readonly NodeId ServerStatusDataType_Encoding_DefaultXml = new NodeId(863u);

	public static readonly NodeId SessionDiagnosticsDataType_Encoding_DefaultXml = new NodeId(866u);

	public static readonly NodeId SessionSecurityDiagnosticsDataType_Encoding_DefaultXml = new NodeId(869u);

	public static readonly NodeId ServiceCounterDataType_Encoding_DefaultXml = new NodeId(872u);

	public static readonly NodeId StatusResult_Encoding_DefaultXml = new NodeId(300u);

	public static readonly NodeId SubscriptionDiagnosticsDataType_Encoding_DefaultXml = new NodeId(875u);

	public static readonly NodeId ModelChangeStructureDataType_Encoding_DefaultXml = new NodeId(878u);

	public static readonly NodeId SemanticChangeStructureDataType_Encoding_DefaultXml = new NodeId(898u);

	public static readonly NodeId Range_Encoding_DefaultXml = new NodeId(885u);

	public static readonly NodeId EUInformation_Encoding_DefaultXml = new NodeId(888u);

	public static readonly NodeId ComplexNumberType_Encoding_DefaultXml = new NodeId(12173u);

	public static readonly NodeId DoubleComplexNumberType_Encoding_DefaultXml = new NodeId(12174u);

	public static readonly NodeId AxisInformation_Encoding_DefaultXml = new NodeId(12081u);

	public static readonly NodeId XVType_Encoding_DefaultXml = new NodeId(12082u);

	public static readonly NodeId ProgramDiagnosticDataType_Encoding_DefaultXml = new NodeId(895u);

	public static readonly NodeId ProgramDiagnostic2DataType_Encoding_DefaultXml = new NodeId(24038u);

	public static readonly NodeId Annotation_Encoding_DefaultXml = new NodeId(892u);

	public static readonly NodeId Union_Encoding_DefaultJson = new NodeId(15085u);

	public static readonly NodeId KeyValuePair_Encoding_DefaultJson = new NodeId(15041u);

	public static readonly NodeId AdditionalParametersType_Encoding_DefaultJson = new NodeId(17547u);

	public static readonly NodeId EphemeralKeyType_Encoding_DefaultJson = new NodeId(17557u);

	public static readonly NodeId EndpointType_Encoding_DefaultJson = new NodeId(16150u);

	public static readonly NodeId RationalNumber_Encoding_DefaultJson = new NodeId(19064u);

	public static readonly NodeId Vector_Encoding_DefaultJson = new NodeId(19065u);

	public static readonly NodeId ThreeDVector_Encoding_DefaultJson = new NodeId(19066u);

	public static readonly NodeId CartesianCoordinates_Encoding_DefaultJson = new NodeId(19067u);

	public static readonly NodeId ThreeDCartesianCoordinates_Encoding_DefaultJson = new NodeId(19068u);

	public static readonly NodeId Orientation_Encoding_DefaultJson = new NodeId(19069u);

	public static readonly NodeId ThreeDOrientation_Encoding_DefaultJson = new NodeId(19070u);

	public static readonly NodeId Frame_Encoding_DefaultJson = new NodeId(19071u);

	public static readonly NodeId ThreeDFrame_Encoding_DefaultJson = new NodeId(19072u);

	public static readonly NodeId IdentityMappingRuleType_Encoding_DefaultJson = new NodeId(15042u);

	public static readonly NodeId CurrencyUnitType_Encoding_DefaultJson = new NodeId(23528u);

	public static readonly NodeId TrustListDataType_Encoding_DefaultJson = new NodeId(15044u);

	public static readonly NodeId DecimalDataType_Encoding_DefaultJson = new NodeId(15045u);

	public static readonly NodeId DataTypeSchemaHeader_Encoding_DefaultJson = new NodeId(16151u);

	public static readonly NodeId DataTypeDescription_Encoding_DefaultJson = new NodeId(15057u);

	public static readonly NodeId StructureDescription_Encoding_DefaultJson = new NodeId(15058u);

	public static readonly NodeId EnumDescription_Encoding_DefaultJson = new NodeId(15059u);

	public static readonly NodeId SimpleTypeDescription_Encoding_DefaultJson = new NodeId(15700u);

	public static readonly NodeId UABinaryFileDataType_Encoding_DefaultJson = new NodeId(15714u);

	public static readonly NodeId DataSetMetaDataType_Encoding_DefaultJson = new NodeId(15050u);

	public static readonly NodeId FieldMetaData_Encoding_DefaultJson = new NodeId(15051u);

	public static readonly NodeId ConfigurationVersionDataType_Encoding_DefaultJson = new NodeId(15049u);

	public static readonly NodeId PublishedDataSetDataType_Encoding_DefaultJson = new NodeId(16152u);

	public static readonly NodeId PublishedDataSetSourceDataType_Encoding_DefaultJson = new NodeId(16153u);

	public static readonly NodeId PublishedVariableDataType_Encoding_DefaultJson = new NodeId(15060u);

	public static readonly NodeId PublishedDataItemsDataType_Encoding_DefaultJson = new NodeId(16154u);

	public static readonly NodeId PublishedEventsDataType_Encoding_DefaultJson = new NodeId(16155u);

	public static readonly NodeId DataSetWriterDataType_Encoding_DefaultJson = new NodeId(16156u);

	public static readonly NodeId DataSetWriterTransportDataType_Encoding_DefaultJson = new NodeId(16157u);

	public static readonly NodeId DataSetWriterMessageDataType_Encoding_DefaultJson = new NodeId(16158u);

	public static readonly NodeId PubSubGroupDataType_Encoding_DefaultJson = new NodeId(16159u);

	public static readonly NodeId WriterGroupDataType_Encoding_DefaultJson = new NodeId(21198u);

	public static readonly NodeId WriterGroupTransportDataType_Encoding_DefaultJson = new NodeId(16161u);

	public static readonly NodeId WriterGroupMessageDataType_Encoding_DefaultJson = new NodeId(16280u);

	public static readonly NodeId PubSubConnectionDataType_Encoding_DefaultJson = new NodeId(16281u);

	public static readonly NodeId ConnectionTransportDataType_Encoding_DefaultJson = new NodeId(16282u);

	public static readonly NodeId NetworkAddressDataType_Encoding_DefaultJson = new NodeId(21199u);

	public static readonly NodeId NetworkAddressUrlDataType_Encoding_DefaultJson = new NodeId(21200u);

	public static readonly NodeId ReaderGroupDataType_Encoding_DefaultJson = new NodeId(21201u);

	public static readonly NodeId ReaderGroupTransportDataType_Encoding_DefaultJson = new NodeId(16284u);

	public static readonly NodeId ReaderGroupMessageDataType_Encoding_DefaultJson = new NodeId(16285u);

	public static readonly NodeId DataSetReaderDataType_Encoding_DefaultJson = new NodeId(16286u);

	public static readonly NodeId DataSetReaderTransportDataType_Encoding_DefaultJson = new NodeId(16287u);

	public static readonly NodeId DataSetReaderMessageDataType_Encoding_DefaultJson = new NodeId(16288u);

	public static readonly NodeId SubscribedDataSetDataType_Encoding_DefaultJson = new NodeId(16308u);

	public static readonly NodeId TargetVariablesDataType_Encoding_DefaultJson = new NodeId(16310u);

	public static readonly NodeId FieldTargetDataType_Encoding_DefaultJson = new NodeId(15061u);

	public static readonly NodeId SubscribedDataSetMirrorDataType_Encoding_DefaultJson = new NodeId(16311u);

	public static readonly NodeId PubSubConfigurationDataType_Encoding_DefaultJson = new NodeId(21202u);

	public static readonly NodeId UadpWriterGroupMessageDataType_Encoding_DefaultJson = new NodeId(16323u);

	public static readonly NodeId UadpDataSetWriterMessageDataType_Encoding_DefaultJson = new NodeId(16391u);

	public static readonly NodeId UadpDataSetReaderMessageDataType_Encoding_DefaultJson = new NodeId(16392u);

	public static readonly NodeId JsonWriterGroupMessageDataType_Encoding_DefaultJson = new NodeId(16393u);

	public static readonly NodeId JsonDataSetWriterMessageDataType_Encoding_DefaultJson = new NodeId(16394u);

	public static readonly NodeId JsonDataSetReaderMessageDataType_Encoding_DefaultJson = new NodeId(16404u);

	public static readonly NodeId DatagramConnectionTransportDataType_Encoding_DefaultJson = new NodeId(17476u);

	public static readonly NodeId DatagramWriterGroupTransportDataType_Encoding_DefaultJson = new NodeId(21203u);

	public static readonly NodeId BrokerConnectionTransportDataType_Encoding_DefaultJson = new NodeId(15726u);

	public static readonly NodeId BrokerWriterGroupTransportDataType_Encoding_DefaultJson = new NodeId(16524u);

	public static readonly NodeId BrokerDataSetWriterTransportDataType_Encoding_DefaultJson = new NodeId(16525u);

	public static readonly NodeId BrokerDataSetReaderTransportDataType_Encoding_DefaultJson = new NodeId(16526u);

	public static readonly NodeId AliasNameDataType_Encoding_DefaultJson = new NodeId(23511u);

	public static readonly NodeId UnsignedRationalNumber_Encoding_DefaultJson = new NodeId(24134u);

	public static readonly NodeId RolePermissionType_Encoding_DefaultJson = new NodeId(15062u);

	public static readonly NodeId DataTypeDefinition_Encoding_DefaultJson = new NodeId(15063u);

	public static readonly NodeId StructureField_Encoding_DefaultJson = new NodeId(15065u);

	public static readonly NodeId StructureDefinition_Encoding_DefaultJson = new NodeId(15066u);

	public static readonly NodeId EnumDefinition_Encoding_DefaultJson = new NodeId(15067u);

	public static readonly NodeId Node_Encoding_DefaultJson = new NodeId(15068u);

	public static readonly NodeId InstanceNode_Encoding_DefaultJson = new NodeId(15069u);

	public static readonly NodeId TypeNode_Encoding_DefaultJson = new NodeId(15070u);

	public static readonly NodeId ObjectNode_Encoding_DefaultJson = new NodeId(15071u);

	public static readonly NodeId ObjectTypeNode_Encoding_DefaultJson = new NodeId(15073u);

	public static readonly NodeId VariableNode_Encoding_DefaultJson = new NodeId(15074u);

	public static readonly NodeId VariableTypeNode_Encoding_DefaultJson = new NodeId(15075u);

	public static readonly NodeId ReferenceTypeNode_Encoding_DefaultJson = new NodeId(15076u);

	public static readonly NodeId MethodNode_Encoding_DefaultJson = new NodeId(15077u);

	public static readonly NodeId ViewNode_Encoding_DefaultJson = new NodeId(15078u);

	public static readonly NodeId DataTypeNode_Encoding_DefaultJson = new NodeId(15079u);

	public static readonly NodeId ReferenceNode_Encoding_DefaultJson = new NodeId(15080u);

	public static readonly NodeId Argument_Encoding_DefaultJson = new NodeId(15081u);

	public static readonly NodeId EnumValueType_Encoding_DefaultJson = new NodeId(15082u);

	public static readonly NodeId EnumField_Encoding_DefaultJson = new NodeId(15083u);

	public static readonly NodeId OptionSet_Encoding_DefaultJson = new NodeId(15084u);

	public static readonly NodeId TimeZoneDataType_Encoding_DefaultJson = new NodeId(15086u);

	public static readonly NodeId ApplicationDescription_Encoding_DefaultJson = new NodeId(15087u);

	public static readonly NodeId RequestHeader_Encoding_DefaultJson = new NodeId(15088u);

	public static readonly NodeId ResponseHeader_Encoding_DefaultJson = new NodeId(15089u);

	public static readonly NodeId ServiceFault_Encoding_DefaultJson = new NodeId(15090u);

	public static readonly NodeId SessionlessInvokeRequestType_Encoding_DefaultJson = new NodeId(15091u);

	public static readonly NodeId SessionlessInvokeResponseType_Encoding_DefaultJson = new NodeId(15092u);

	public static readonly NodeId FindServersRequest_Encoding_DefaultJson = new NodeId(15093u);

	public static readonly NodeId FindServersResponse_Encoding_DefaultJson = new NodeId(15094u);

	public static readonly NodeId ServerOnNetwork_Encoding_DefaultJson = new NodeId(15095u);

	public static readonly NodeId FindServersOnNetworkRequest_Encoding_DefaultJson = new NodeId(15096u);

	public static readonly NodeId FindServersOnNetworkResponse_Encoding_DefaultJson = new NodeId(15097u);

	public static readonly NodeId UserTokenPolicy_Encoding_DefaultJson = new NodeId(15098u);

	public static readonly NodeId EndpointDescription_Encoding_DefaultJson = new NodeId(15099u);

	public static readonly NodeId GetEndpointsRequest_Encoding_DefaultJson = new NodeId(15100u);

	public static readonly NodeId GetEndpointsResponse_Encoding_DefaultJson = new NodeId(15101u);

	public static readonly NodeId RegisteredServer_Encoding_DefaultJson = new NodeId(15102u);

	public static readonly NodeId RegisterServerRequest_Encoding_DefaultJson = new NodeId(15103u);

	public static readonly NodeId RegisterServerResponse_Encoding_DefaultJson = new NodeId(15104u);

	public static readonly NodeId DiscoveryConfiguration_Encoding_DefaultJson = new NodeId(15105u);

	public static readonly NodeId MdnsDiscoveryConfiguration_Encoding_DefaultJson = new NodeId(15106u);

	public static readonly NodeId RegisterServer2Request_Encoding_DefaultJson = new NodeId(15107u);

	public static readonly NodeId RegisterServer2Response_Encoding_DefaultJson = new NodeId(15130u);

	public static readonly NodeId ChannelSecurityToken_Encoding_DefaultJson = new NodeId(15131u);

	public static readonly NodeId OpenSecureChannelRequest_Encoding_DefaultJson = new NodeId(15132u);

	public static readonly NodeId OpenSecureChannelResponse_Encoding_DefaultJson = new NodeId(15133u);

	public static readonly NodeId CloseSecureChannelRequest_Encoding_DefaultJson = new NodeId(15134u);

	public static readonly NodeId CloseSecureChannelResponse_Encoding_DefaultJson = new NodeId(15135u);

	public static readonly NodeId SignedSoftwareCertificate_Encoding_DefaultJson = new NodeId(15136u);

	public static readonly NodeId SignatureData_Encoding_DefaultJson = new NodeId(15137u);

	public static readonly NodeId CreateSessionRequest_Encoding_DefaultJson = new NodeId(15138u);

	public static readonly NodeId CreateSessionResponse_Encoding_DefaultJson = new NodeId(15139u);

	public static readonly NodeId UserIdentityToken_Encoding_DefaultJson = new NodeId(15140u);

	public static readonly NodeId AnonymousIdentityToken_Encoding_DefaultJson = new NodeId(15141u);

	public static readonly NodeId UserNameIdentityToken_Encoding_DefaultJson = new NodeId(15142u);

	public static readonly NodeId X509IdentityToken_Encoding_DefaultJson = new NodeId(15143u);

	public static readonly NodeId IssuedIdentityToken_Encoding_DefaultJson = new NodeId(15144u);

	public static readonly NodeId ActivateSessionRequest_Encoding_DefaultJson = new NodeId(15145u);

	public static readonly NodeId ActivateSessionResponse_Encoding_DefaultJson = new NodeId(15146u);

	public static readonly NodeId CloseSessionRequest_Encoding_DefaultJson = new NodeId(15147u);

	public static readonly NodeId CloseSessionResponse_Encoding_DefaultJson = new NodeId(15148u);

	public static readonly NodeId CancelRequest_Encoding_DefaultJson = new NodeId(15149u);

	public static readonly NodeId CancelResponse_Encoding_DefaultJson = new NodeId(15150u);

	public static readonly NodeId NodeAttributes_Encoding_DefaultJson = new NodeId(15151u);

	public static readonly NodeId ObjectAttributes_Encoding_DefaultJson = new NodeId(15152u);

	public static readonly NodeId VariableAttributes_Encoding_DefaultJson = new NodeId(15153u);

	public static readonly NodeId MethodAttributes_Encoding_DefaultJson = new NodeId(15157u);

	public static readonly NodeId ObjectTypeAttributes_Encoding_DefaultJson = new NodeId(15158u);

	public static readonly NodeId VariableTypeAttributes_Encoding_DefaultJson = new NodeId(15159u);

	public static readonly NodeId ReferenceTypeAttributes_Encoding_DefaultJson = new NodeId(15160u);

	public static readonly NodeId DataTypeAttributes_Encoding_DefaultJson = new NodeId(15161u);

	public static readonly NodeId ViewAttributes_Encoding_DefaultJson = new NodeId(15162u);

	public static readonly NodeId GenericAttributeValue_Encoding_DefaultJson = new NodeId(15163u);

	public static readonly NodeId GenericAttributes_Encoding_DefaultJson = new NodeId(15164u);

	public static readonly NodeId AddNodesItem_Encoding_DefaultJson = new NodeId(15165u);

	public static readonly NodeId AddNodesResult_Encoding_DefaultJson = new NodeId(15166u);

	public static readonly NodeId AddNodesRequest_Encoding_DefaultJson = new NodeId(15167u);

	public static readonly NodeId AddNodesResponse_Encoding_DefaultJson = new NodeId(15168u);

	public static readonly NodeId AddReferencesItem_Encoding_DefaultJson = new NodeId(15169u);

	public static readonly NodeId AddReferencesRequest_Encoding_DefaultJson = new NodeId(15170u);

	public static readonly NodeId AddReferencesResponse_Encoding_DefaultJson = new NodeId(15171u);

	public static readonly NodeId DeleteNodesItem_Encoding_DefaultJson = new NodeId(15172u);

	public static readonly NodeId DeleteNodesRequest_Encoding_DefaultJson = new NodeId(15173u);

	public static readonly NodeId DeleteNodesResponse_Encoding_DefaultJson = new NodeId(15174u);

	public static readonly NodeId DeleteReferencesItem_Encoding_DefaultJson = new NodeId(15175u);

	public static readonly NodeId DeleteReferencesRequest_Encoding_DefaultJson = new NodeId(15176u);

	public static readonly NodeId DeleteReferencesResponse_Encoding_DefaultJson = new NodeId(15177u);

	public static readonly NodeId ViewDescription_Encoding_DefaultJson = new NodeId(15179u);

	public static readonly NodeId BrowseDescription_Encoding_DefaultJson = new NodeId(15180u);

	public static readonly NodeId ReferenceDescription_Encoding_DefaultJson = new NodeId(15182u);

	public static readonly NodeId BrowseResult_Encoding_DefaultJson = new NodeId(15183u);

	public static readonly NodeId BrowseRequest_Encoding_DefaultJson = new NodeId(15184u);

	public static readonly NodeId BrowseResponse_Encoding_DefaultJson = new NodeId(15185u);

	public static readonly NodeId BrowseNextRequest_Encoding_DefaultJson = new NodeId(15186u);

	public static readonly NodeId BrowseNextResponse_Encoding_DefaultJson = new NodeId(15187u);

	public static readonly NodeId RelativePathElement_Encoding_DefaultJson = new NodeId(15188u);

	public static readonly NodeId RelativePath_Encoding_DefaultJson = new NodeId(15189u);

	public static readonly NodeId BrowsePath_Encoding_DefaultJson = new NodeId(15190u);

	public static readonly NodeId BrowsePathTarget_Encoding_DefaultJson = new NodeId(15191u);

	public static readonly NodeId BrowsePathResult_Encoding_DefaultJson = new NodeId(15192u);

	public static readonly NodeId TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultJson = new NodeId(15193u);

	public static readonly NodeId TranslateBrowsePathsToNodeIdsResponse_Encoding_DefaultJson = new NodeId(15194u);

	public static readonly NodeId RegisterNodesRequest_Encoding_DefaultJson = new NodeId(15195u);

	public static readonly NodeId RegisterNodesResponse_Encoding_DefaultJson = new NodeId(15196u);

	public static readonly NodeId UnregisterNodesRequest_Encoding_DefaultJson = new NodeId(15197u);

	public static readonly NodeId UnregisterNodesResponse_Encoding_DefaultJson = new NodeId(15198u);

	public static readonly NodeId EndpointConfiguration_Encoding_DefaultJson = new NodeId(15199u);

	public static readonly NodeId QueryDataDescription_Encoding_DefaultJson = new NodeId(15200u);

	public static readonly NodeId NodeTypeDescription_Encoding_DefaultJson = new NodeId(15201u);

	public static readonly NodeId QueryDataSet_Encoding_DefaultJson = new NodeId(15202u);

	public static readonly NodeId NodeReference_Encoding_DefaultJson = new NodeId(15203u);

	public static readonly NodeId ContentFilterElement_Encoding_DefaultJson = new NodeId(15204u);

	public static readonly NodeId ContentFilter_Encoding_DefaultJson = new NodeId(15205u);

	public static readonly NodeId FilterOperand_Encoding_DefaultJson = new NodeId(15206u);

	public static readonly NodeId ElementOperand_Encoding_DefaultJson = new NodeId(15207u);

	public static readonly NodeId LiteralOperand_Encoding_DefaultJson = new NodeId(15208u);

	public static readonly NodeId AttributeOperand_Encoding_DefaultJson = new NodeId(15209u);

	public static readonly NodeId SimpleAttributeOperand_Encoding_DefaultJson = new NodeId(15210u);

	public static readonly NodeId ContentFilterElementResult_Encoding_DefaultJson = new NodeId(15211u);

	public static readonly NodeId ContentFilterResult_Encoding_DefaultJson = new NodeId(15228u);

	public static readonly NodeId ParsingResult_Encoding_DefaultJson = new NodeId(15236u);

	public static readonly NodeId QueryFirstRequest_Encoding_DefaultJson = new NodeId(15244u);

	public static readonly NodeId QueryFirstResponse_Encoding_DefaultJson = new NodeId(15252u);

	public static readonly NodeId QueryNextRequest_Encoding_DefaultJson = new NodeId(15254u);

	public static readonly NodeId QueryNextResponse_Encoding_DefaultJson = new NodeId(15255u);

	public static readonly NodeId ReadValueId_Encoding_DefaultJson = new NodeId(15256u);

	public static readonly NodeId ReadRequest_Encoding_DefaultJson = new NodeId(15257u);

	public static readonly NodeId ReadResponse_Encoding_DefaultJson = new NodeId(15258u);

	public static readonly NodeId HistoryReadValueId_Encoding_DefaultJson = new NodeId(15259u);

	public static readonly NodeId HistoryReadResult_Encoding_DefaultJson = new NodeId(15260u);

	public static readonly NodeId HistoryReadDetails_Encoding_DefaultJson = new NodeId(15261u);

	public static readonly NodeId ReadEventDetails_Encoding_DefaultJson = new NodeId(15262u);

	public static readonly NodeId ReadRawModifiedDetails_Encoding_DefaultJson = new NodeId(15263u);

	public static readonly NodeId ReadProcessedDetails_Encoding_DefaultJson = new NodeId(15264u);

	public static readonly NodeId ReadAtTimeDetails_Encoding_DefaultJson = new NodeId(15269u);

	public static readonly NodeId ReadAnnotationDataDetails_Encoding_DefaultJson = new NodeId(23512u);

	public static readonly NodeId HistoryData_Encoding_DefaultJson = new NodeId(15270u);

	public static readonly NodeId ModificationInfo_Encoding_DefaultJson = new NodeId(15271u);

	public static readonly NodeId HistoryModifiedData_Encoding_DefaultJson = new NodeId(15272u);

	public static readonly NodeId HistoryEvent_Encoding_DefaultJson = new NodeId(15273u);

	public static readonly NodeId HistoryReadRequest_Encoding_DefaultJson = new NodeId(15274u);

	public static readonly NodeId HistoryReadResponse_Encoding_DefaultJson = new NodeId(15275u);

	public static readonly NodeId WriteValue_Encoding_DefaultJson = new NodeId(15276u);

	public static readonly NodeId WriteRequest_Encoding_DefaultJson = new NodeId(15277u);

	public static readonly NodeId WriteResponse_Encoding_DefaultJson = new NodeId(15278u);

	public static readonly NodeId HistoryUpdateDetails_Encoding_DefaultJson = new NodeId(15279u);

	public static readonly NodeId UpdateDataDetails_Encoding_DefaultJson = new NodeId(15280u);

	public static readonly NodeId UpdateStructureDataDetails_Encoding_DefaultJson = new NodeId(15281u);

	public static readonly NodeId UpdateEventDetails_Encoding_DefaultJson = new NodeId(15282u);

	public static readonly NodeId DeleteRawModifiedDetails_Encoding_DefaultJson = new NodeId(15283u);

	public static readonly NodeId DeleteAtTimeDetails_Encoding_DefaultJson = new NodeId(15284u);

	public static readonly NodeId DeleteEventDetails_Encoding_DefaultJson = new NodeId(15285u);

	public static readonly NodeId HistoryUpdateResult_Encoding_DefaultJson = new NodeId(15286u);

	public static readonly NodeId HistoryUpdateRequest_Encoding_DefaultJson = new NodeId(15287u);

	public static readonly NodeId HistoryUpdateResponse_Encoding_DefaultJson = new NodeId(15288u);

	public static readonly NodeId CallMethodRequest_Encoding_DefaultJson = new NodeId(15289u);

	public static readonly NodeId CallMethodResult_Encoding_DefaultJson = new NodeId(15290u);

	public static readonly NodeId CallRequest_Encoding_DefaultJson = new NodeId(15291u);

	public static readonly NodeId CallResponse_Encoding_DefaultJson = new NodeId(15292u);

	public static readonly NodeId MonitoringFilter_Encoding_DefaultJson = new NodeId(15293u);

	public static readonly NodeId DataChangeFilter_Encoding_DefaultJson = new NodeId(15294u);

	public static readonly NodeId EventFilter_Encoding_DefaultJson = new NodeId(15295u);

	public static readonly NodeId AggregateConfiguration_Encoding_DefaultJson = new NodeId(15304u);

	public static readonly NodeId AggregateFilter_Encoding_DefaultJson = new NodeId(15312u);

	public static readonly NodeId MonitoringFilterResult_Encoding_DefaultJson = new NodeId(15313u);

	public static readonly NodeId EventFilterResult_Encoding_DefaultJson = new NodeId(15314u);

	public static readonly NodeId AggregateFilterResult_Encoding_DefaultJson = new NodeId(15315u);

	public static readonly NodeId MonitoringParameters_Encoding_DefaultJson = new NodeId(15320u);

	public static readonly NodeId MonitoredItemCreateRequest_Encoding_DefaultJson = new NodeId(15321u);

	public static readonly NodeId MonitoredItemCreateResult_Encoding_DefaultJson = new NodeId(15322u);

	public static readonly NodeId CreateMonitoredItemsRequest_Encoding_DefaultJson = new NodeId(15323u);

	public static readonly NodeId CreateMonitoredItemsResponse_Encoding_DefaultJson = new NodeId(15324u);

	public static readonly NodeId MonitoredItemModifyRequest_Encoding_DefaultJson = new NodeId(15325u);

	public static readonly NodeId MonitoredItemModifyResult_Encoding_DefaultJson = new NodeId(15326u);

	public static readonly NodeId ModifyMonitoredItemsRequest_Encoding_DefaultJson = new NodeId(15327u);

	public static readonly NodeId ModifyMonitoredItemsResponse_Encoding_DefaultJson = new NodeId(15328u);

	public static readonly NodeId SetMonitoringModeRequest_Encoding_DefaultJson = new NodeId(15329u);

	public static readonly NodeId SetMonitoringModeResponse_Encoding_DefaultJson = new NodeId(15331u);

	public static readonly NodeId SetTriggeringRequest_Encoding_DefaultJson = new NodeId(15332u);

	public static readonly NodeId SetTriggeringResponse_Encoding_DefaultJson = new NodeId(15333u);

	public static readonly NodeId DeleteMonitoredItemsRequest_Encoding_DefaultJson = new NodeId(15335u);

	public static readonly NodeId DeleteMonitoredItemsResponse_Encoding_DefaultJson = new NodeId(15336u);

	public static readonly NodeId CreateSubscriptionRequest_Encoding_DefaultJson = new NodeId(15337u);

	public static readonly NodeId CreateSubscriptionResponse_Encoding_DefaultJson = new NodeId(15338u);

	public static readonly NodeId ModifySubscriptionRequest_Encoding_DefaultJson = new NodeId(15339u);

	public static readonly NodeId ModifySubscriptionResponse_Encoding_DefaultJson = new NodeId(15340u);

	public static readonly NodeId SetPublishingModeRequest_Encoding_DefaultJson = new NodeId(15341u);

	public static readonly NodeId SetPublishingModeResponse_Encoding_DefaultJson = new NodeId(15342u);

	public static readonly NodeId NotificationMessage_Encoding_DefaultJson = new NodeId(15343u);

	public static readonly NodeId NotificationData_Encoding_DefaultJson = new NodeId(15344u);

	public static readonly NodeId DataChangeNotification_Encoding_DefaultJson = new NodeId(15345u);

	public static readonly NodeId MonitoredItemNotification_Encoding_DefaultJson = new NodeId(15346u);

	public static readonly NodeId EventNotificationList_Encoding_DefaultJson = new NodeId(15347u);

	public static readonly NodeId EventFieldList_Encoding_DefaultJson = new NodeId(15348u);

	public static readonly NodeId HistoryEventFieldList_Encoding_DefaultJson = new NodeId(15349u);

	public static readonly NodeId StatusChangeNotification_Encoding_DefaultJson = new NodeId(15350u);

	public static readonly NodeId SubscriptionAcknowledgement_Encoding_DefaultJson = new NodeId(15351u);

	public static readonly NodeId PublishRequest_Encoding_DefaultJson = new NodeId(15352u);

	public static readonly NodeId PublishResponse_Encoding_DefaultJson = new NodeId(15353u);

	public static readonly NodeId RepublishRequest_Encoding_DefaultJson = new NodeId(15354u);

	public static readonly NodeId RepublishResponse_Encoding_DefaultJson = new NodeId(15355u);

	public static readonly NodeId TransferResult_Encoding_DefaultJson = new NodeId(15356u);

	public static readonly NodeId TransferSubscriptionsRequest_Encoding_DefaultJson = new NodeId(15357u);

	public static readonly NodeId TransferSubscriptionsResponse_Encoding_DefaultJson = new NodeId(15358u);

	public static readonly NodeId DeleteSubscriptionsRequest_Encoding_DefaultJson = new NodeId(15359u);

	public static readonly NodeId DeleteSubscriptionsResponse_Encoding_DefaultJson = new NodeId(15360u);

	public static readonly NodeId BuildInfo_Encoding_DefaultJson = new NodeId(15361u);

	public static readonly NodeId RedundantServerDataType_Encoding_DefaultJson = new NodeId(15362u);

	public static readonly NodeId EndpointUrlListDataType_Encoding_DefaultJson = new NodeId(15363u);

	public static readonly NodeId NetworkGroupDataType_Encoding_DefaultJson = new NodeId(15364u);

	public static readonly NodeId SamplingIntervalDiagnosticsDataType_Encoding_DefaultJson = new NodeId(15365u);

	public static readonly NodeId ServerDiagnosticsSummaryDataType_Encoding_DefaultJson = new NodeId(15366u);

	public static readonly NodeId ServerStatusDataType_Encoding_DefaultJson = new NodeId(15367u);

	public static readonly NodeId SessionDiagnosticsDataType_Encoding_DefaultJson = new NodeId(15368u);

	public static readonly NodeId SessionSecurityDiagnosticsDataType_Encoding_DefaultJson = new NodeId(15369u);

	public static readonly NodeId ServiceCounterDataType_Encoding_DefaultJson = new NodeId(15370u);

	public static readonly NodeId StatusResult_Encoding_DefaultJson = new NodeId(15371u);

	public static readonly NodeId SubscriptionDiagnosticsDataType_Encoding_DefaultJson = new NodeId(15372u);

	public static readonly NodeId ModelChangeStructureDataType_Encoding_DefaultJson = new NodeId(15373u);

	public static readonly NodeId SemanticChangeStructureDataType_Encoding_DefaultJson = new NodeId(15374u);

	public static readonly NodeId Range_Encoding_DefaultJson = new NodeId(15375u);

	public static readonly NodeId EUInformation_Encoding_DefaultJson = new NodeId(15376u);

	public static readonly NodeId ComplexNumberType_Encoding_DefaultJson = new NodeId(15377u);

	public static readonly NodeId DoubleComplexNumberType_Encoding_DefaultJson = new NodeId(15378u);

	public static readonly NodeId AxisInformation_Encoding_DefaultJson = new NodeId(15379u);

	public static readonly NodeId XVType_Encoding_DefaultJson = new NodeId(15380u);

	public static readonly NodeId ProgramDiagnosticDataType_Encoding_DefaultJson = new NodeId(15381u);

	public static readonly NodeId ProgramDiagnostic2DataType_Encoding_DefaultJson = new NodeId(24042u);

	public static readonly NodeId Annotation_Encoding_DefaultJson = new NodeId(15382u);
}
