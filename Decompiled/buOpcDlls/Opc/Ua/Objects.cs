using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class Objects
{
	public const uint DefaultBinary = 3062u;

	public const uint DefaultXml = 3063u;

	public const uint ModellingRule_Mandatory = 78u;

	public const uint ModellingRule_Optional = 80u;

	public const uint ModellingRule_ExposesItsArray = 83u;

	public const uint ModellingRule_OptionalPlaceholder = 11508u;

	public const uint ModellingRule_MandatoryPlaceholder = 11510u;

	public const uint RootFolder = 84u;

	public const uint ObjectsFolder = 85u;

	public const uint TypesFolder = 86u;

	public const uint ViewsFolder = 87u;

	public const uint ObjectTypesFolder = 88u;

	public const uint VariableTypesFolder = 89u;

	public const uint DataTypesFolder = 90u;

	public const uint ReferenceTypesFolder = 91u;

	public const uint XmlSchema_TypeSystem = 92u;

	public const uint OPCBinarySchema_TypeSystem = 93u;

	public const uint OPCUANamespaceMetadata = 15957u;

	public const uint ServerType_ServerCapabilities = 2009u;

	public const uint ServerType_ServerCapabilities_ModellingRules = 3093u;

	public const uint ServerType_ServerCapabilities_AggregateFunctions = 3094u;

	public const uint ServerType_ServerDiagnostics = 2010u;

	public const uint ServerType_ServerDiagnostics_SessionsDiagnosticsSummary = 3111u;

	public const uint ServerType_VendorServerInfo = 2011u;

	public const uint ServerType_ServerRedundancy = 2012u;

	public const uint ServerType_Namespaces = 11527u;

	public const uint ServerCapabilitiesType_OperationLimits = 11551u;

	public const uint ServerCapabilitiesType_ModellingRules = 2019u;

	public const uint ServerCapabilitiesType_AggregateFunctions = 2754u;

	public const uint ServerCapabilitiesType_RoleSet = 16295u;

	public const uint ServerDiagnosticsType_SessionsDiagnosticsSummary = 2744u;

	public const uint SessionsDiagnosticsSummaryType_ClientName_Placeholder = 12097u;

	public const uint NamespaceMetadataType_NamespaceFile = 11624u;

	public const uint NamespacesType_NamespaceIdentifier_Placeholder = 11646u;

	public const uint EventTypesFolder = 3048u;

	public const uint Server = 2253u;

	public const uint Server_ServerCapabilities = 2268u;

	public const uint Server_ServerCapabilities_OperationLimits = 11704u;

	public const uint Server_ServerCapabilities_ModellingRules = 2996u;

	public const uint Server_ServerCapabilities_AggregateFunctions = 2997u;

	public const uint Server_ServerCapabilities_RoleSet = 15606u;

	public const uint Server_ServerDiagnostics = 2274u;

	public const uint Server_ServerDiagnostics_SessionsDiagnosticsSummary = 3706u;

	public const uint Server_VendorServerInfo = 2295u;

	public const uint Server_ServerRedundancy = 2296u;

	public const uint Server_Namespaces = 11715u;

	public const uint HistoryServerCapabilities = 11192u;

	public const uint HistoryServerCapabilities_AggregateFunctions = 11201u;

	public const uint FileDirectoryType_FileDirectoryName_Placeholder = 13354u;

	public const uint FileDirectoryType_FileName_Placeholder = 13366u;

	public const uint FileSystem = 16314u;

	public const uint TemporaryFileTransferType_TransferState_Placeholder = 15754u;

	public const uint FileTransferStateMachineType_Idle = 15815u;

	public const uint FileTransferStateMachineType_ReadPrepare = 15817u;

	public const uint FileTransferStateMachineType_ReadTransfer = 15819u;

	public const uint FileTransferStateMachineType_ApplyWrite = 15821u;

	public const uint FileTransferStateMachineType_Error = 15823u;

	public const uint FileTransferStateMachineType_IdleToReadPrepare = 15825u;

	public const uint FileTransferStateMachineType_ReadPrepareToReadTransfer = 15827u;

	public const uint FileTransferStateMachineType_ReadTransferToIdle = 15829u;

	public const uint FileTransferStateMachineType_IdleToApplyWrite = 15831u;

	public const uint FileTransferStateMachineType_ApplyWriteToIdle = 15833u;

	public const uint FileTransferStateMachineType_ReadPrepareToError = 15835u;

	public const uint FileTransferStateMachineType_ReadTransferToError = 15837u;

	public const uint FileTransferStateMachineType_ApplyWriteToError = 15839u;

	public const uint FileTransferStateMachineType_ErrorToIdle = 15841u;

	public const uint RoleSetType_RoleName_Placeholder = 15608u;

	public const uint WellKnownRole_Anonymous = 15644u;

	public const uint WellKnownRole_AuthenticatedUser = 15656u;

	public const uint WellKnownRole_Observer = 15668u;

	public const uint WellKnownRole_Operator = 15680u;

	public const uint WellKnownRole_Engineer = 16036u;

	public const uint WellKnownRole_Supervisor = 15692u;

	public const uint WellKnownRole_ConfigureAdmin = 15716u;

	public const uint WellKnownRole_SecurityAdmin = 15704u;

	public const uint DictionaryEntryType_DictionaryEntryName_Placeholder = 17590u;

	public const uint DictionaryFolderType_DictionaryFolderName_Placeholder = 17592u;

	public const uint DictionaryFolderType_DictionaryEntryName_Placeholder = 17593u;

	public const uint Dictionaries = 17594u;

	public const uint InterfaceTypes = 17708u;

	public const uint OrderedListType_OrderedObject_Placeholder = 23519u;

	public const uint AlarmConditionType_ShelvingState = 9178u;

	public const uint AlarmConditionType_FirstInGroup = 16398u;

	public const uint AlarmConditionType_AlarmGroup_Placeholder = 16399u;

	public const uint AlarmGroupType_AlarmConditionInstance_Placeholder = 16406u;

	public const uint ShelvedStateMachineType_Unshelved = 2930u;

	public const uint ShelvedStateMachineType_TimedShelved = 2932u;

	public const uint ShelvedStateMachineType_OneShotShelved = 2933u;

	public const uint ShelvedStateMachineType_UnshelvedToTimedShelved = 2935u;

	public const uint ShelvedStateMachineType_UnshelvedToOneShotShelved = 2936u;

	public const uint ShelvedStateMachineType_TimedShelvedToUnshelved = 2940u;

	public const uint ShelvedStateMachineType_TimedShelvedToOneShotShelved = 2942u;

	public const uint ShelvedStateMachineType_OneShotShelvedToUnshelved = 2943u;

	public const uint ShelvedStateMachineType_OneShotShelvedToTimedShelved = 2945u;

	public const uint ExclusiveLimitStateMachineType_HighHigh = 9329u;

	public const uint ExclusiveLimitStateMachineType_High = 9331u;

	public const uint ExclusiveLimitStateMachineType_Low = 9333u;

	public const uint ExclusiveLimitStateMachineType_LowLow = 9335u;

	public const uint ExclusiveLimitStateMachineType_LowLowToLow = 9337u;

	public const uint ExclusiveLimitStateMachineType_LowToLowLow = 9338u;

	public const uint ExclusiveLimitStateMachineType_HighHighToHigh = 9339u;

	public const uint ExclusiveLimitStateMachineType_HighToHighHigh = 9340u;

	public const uint ExclusiveLimitAlarmType_LimitState = 9455u;

	public const uint ProgramStateMachineType_FinalResultData = 3850u;

	public const uint ProgramStateMachineType_Halted = 2406u;

	public const uint ProgramStateMachineType_Ready = 2400u;

	public const uint ProgramStateMachineType_Running = 2402u;

	public const uint ProgramStateMachineType_Suspended = 2404u;

	public const uint ProgramStateMachineType_HaltedToReady = 2408u;

	public const uint ProgramStateMachineType_ReadyToRunning = 2410u;

	public const uint ProgramStateMachineType_RunningToHalted = 2412u;

	public const uint ProgramStateMachineType_RunningToReady = 2414u;

	public const uint ProgramStateMachineType_RunningToSuspended = 2416u;

	public const uint ProgramStateMachineType_SuspendedToRunning = 2418u;

	public const uint ProgramStateMachineType_SuspendedToHalted = 2420u;

	public const uint ProgramStateMachineType_SuspendedToReady = 2422u;

	public const uint ProgramStateMachineType_ReadyToHalted = 2424u;

	public const uint HistoricalDataConfigurationType_AggregateConfiguration = 3059u;

	public const uint HistoricalDataConfigurationType_AggregateFunctions = 11876u;

	public const uint HAConfiguration = 11202u;

	public const uint HAConfiguration_AggregateConfiguration = 11203u;

	public const uint HistoryServerCapabilitiesType_AggregateFunctions = 11172u;

	public const uint CertificateGroupType_TrustList = 13599u;

	public const uint CertificateGroupType_CertificateExpired = 19450u;

	public const uint CertificateGroupType_TrustListOutOfDate = 20143u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup = 13814u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustList = 13815u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup = 13848u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustList = 13849u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup = 13882u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustList = 13883u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder = 13916u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList = 13917u;

	public const uint ServerConfigurationType_CertificateGroups = 13950u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup = 13951u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList = 13952u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList = 13986u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList = 14020u;

	public const uint ServerConfiguration = 12637u;

	public const uint ServerConfiguration_CertificateGroups = 14053u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup = 14156u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList = 12642u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup = 14088u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList = 14089u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup = 14122u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList = 14123u;

	public const uint KeyCredentialConfigurationFolderType_ServiceName_Placeholder = 17511u;

	public const uint KeyCredentialConfiguration = 18155u;

	public const uint AuthorizationServicesConfigurationFolderType_ServiceName_Placeholder = 23557u;

	public const uint AuthorizationServices = 17732u;

	public const uint AggregateFunction_Interpolative = 2341u;

	public const uint AggregateFunction_Average = 2342u;

	public const uint AggregateFunction_TimeAverage = 2343u;

	public const uint AggregateFunction_TimeAverage2 = 11285u;

	public const uint AggregateFunction_Total = 2344u;

	public const uint AggregateFunction_Total2 = 11304u;

	public const uint AggregateFunction_Minimum = 2346u;

	public const uint AggregateFunction_Maximum = 2347u;

	public const uint AggregateFunction_MinimumActualTime = 2348u;

	public const uint AggregateFunction_MaximumActualTime = 2349u;

	public const uint AggregateFunction_Range = 2350u;

	public const uint AggregateFunction_Minimum2 = 11286u;

	public const uint AggregateFunction_Maximum2 = 11287u;

	public const uint AggregateFunction_MinimumActualTime2 = 11305u;

	public const uint AggregateFunction_MaximumActualTime2 = 11306u;

	public const uint AggregateFunction_Range2 = 11288u;

	public const uint AggregateFunction_AnnotationCount = 2351u;

	public const uint AggregateFunction_Count = 2352u;

	public const uint AggregateFunction_DurationInStateZero = 11307u;

	public const uint AggregateFunction_DurationInStateNonZero = 11308u;

	public const uint AggregateFunction_NumberOfTransitions = 2355u;

	public const uint AggregateFunction_Start = 2357u;

	public const uint AggregateFunction_End = 2358u;

	public const uint AggregateFunction_Delta = 2359u;

	public const uint AggregateFunction_StartBound = 11505u;

	public const uint AggregateFunction_EndBound = 11506u;

	public const uint AggregateFunction_DeltaBounds = 11507u;

	public const uint AggregateFunction_DurationGood = 2360u;

	public const uint AggregateFunction_DurationBad = 2361u;

	public const uint AggregateFunction_PercentGood = 2362u;

	public const uint AggregateFunction_PercentBad = 2363u;

	public const uint AggregateFunction_WorstQuality = 2364u;

	public const uint AggregateFunction_WorstQuality2 = 11292u;

	public const uint AggregateFunction_StandardDeviationSample = 11426u;

	public const uint AggregateFunction_StandardDeviationPopulation = 11427u;

	public const uint AggregateFunction_VarianceSample = 11428u;

	public const uint AggregateFunction_VariancePopulation = 11429u;

	public const uint PubSubKeyServiceType_SecurityGroups = 15913u;

	public const uint SecurityGroupFolderType_SecurityGroupFolderName_Placeholder = 15453u;

	public const uint SecurityGroupFolderType_SecurityGroupName_Placeholder = 15459u;

	public const uint PublishSubscribeType_ConnectionName_Placeholder = 14417u;

	public const uint PublishSubscribeType_ConnectionName_Placeholder_Address = 14423u;

	public const uint PublishSubscribeType_ConnectionName_Placeholder_Status = 14419u;

	public const uint PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters = 18681u;

	public const uint PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_LiveValues = 18712u;

	public const uint PublishSubscribeType_PublishedDataSets = 14434u;

	public const uint PublishSubscribeType_Status = 15844u;

	public const uint PublishSubscribeType_Diagnostics = 18715u;

	public const uint PublishSubscribeType_Diagnostics_Counters = 18729u;

	public const uint PublishSubscribeType_Diagnostics_LiveValues = 18760u;

	public const uint PublishSubscribe = 14443u;

	public const uint PublishSubscribe_SecurityGroups = 15443u;

	public const uint PublishSubscribe_ConnectionName_Placeholder_Address = 15851u;

	public const uint PublishSubscribe_ConnectionName_Placeholder_Status = 15865u;

	public const uint PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters = 16102u;

	public const uint PublishSubscribe_ConnectionName_Placeholder_Diagnostics_LiveValues = 17352u;

	public const uint PublishSubscribe_PublishedDataSets = 17371u;

	public const uint PublishSubscribe_Status = 17405u;

	public const uint PublishSubscribe_Diagnostics = 17409u;

	public const uint PublishSubscribe_Diagnostics_Counters = 17423u;

	public const uint PublishSubscribe_Diagnostics_LiveValues = 17457u;

	public const uint PublishedDataSetType_DataSetWriterName_Placeholder = 15222u;

	public const uint PublishedDataSetType_DataSetWriterName_Placeholder_Status = 15223u;

	public const uint PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters = 18885u;

	public const uint PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_LiveValues = 18916u;

	public const uint PublishedDataSetType_ExtensionFields = 15481u;

	public const uint PublishedDataItemsType_DataSetWriterName_Placeholder_Status = 15231u;

	public const uint PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters = 18944u;

	public const uint PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues = 18975u;

	public const uint PublishedEventsType_DataSetWriterName_Placeholder_Status = 15239u;

	public const uint PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters = 19003u;

	public const uint PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues = 19034u;

	public const uint DataSetFolderType_DataSetFolderName_Placeholder = 14478u;

	public const uint DataSetFolderType_PublishedDataSetName_Placeholder = 14487u;

	public const uint PubSubConnectionType_Address = 14221u;

	public const uint PubSubConnectionType_TransportSettings = 17203u;

	public const uint PubSubConnectionType_WriterGroupName_Placeholder = 17310u;

	public const uint PubSubConnectionType_WriterGroupName_Placeholder_Status = 17314u;

	public const uint PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters = 19121u;

	public const uint PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_LiveValues = 19152u;

	public const uint PubSubConnectionType_ReaderGroupName_Placeholder = 17325u;

	public const uint PubSubConnectionType_ReaderGroupName_Placeholder_Status = 17329u;

	public const uint PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters = 19190u;

	public const uint PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_LiveValues = 19221u;

	public const uint PubSubConnectionType_Status = 14600u;

	public const uint PubSubConnectionType_Diagnostics = 19241u;

	public const uint PubSubConnectionType_Diagnostics_Counters = 19255u;

	public const uint PubSubConnectionType_Diagnostics_LiveValues = 19286u;

	public const uint PubSubGroupType_Status = 15265u;

	public const uint WriterGroupType_TransportSettings = 17741u;

	public const uint WriterGroupType_MessageSettings = 17742u;

	public const uint WriterGroupType_DataSetWriterName_Placeholder = 17743u;

	public const uint WriterGroupType_DataSetWriterName_Placeholder_Status = 17749u;

	public const uint WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters = 17767u;

	public const uint WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_LiveValues = 17798u;

	public const uint WriterGroupType_Diagnostics = 17812u;

	public const uint WriterGroupType_Diagnostics_Counters = 17826u;

	public const uint WriterGroupType_Diagnostics_LiveValues = 17858u;

	public const uint ReaderGroupType_DataSetReaderName_Placeholder = 18076u;

	public const uint ReaderGroupType_DataSetReaderName_Placeholder_Status = 18088u;

	public const uint ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters = 18106u;

	public const uint ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_LiveValues = 18137u;

	public const uint ReaderGroupType_DataSetReaderName_Placeholder_SubscribedDataSet = 21006u;

	public const uint ReaderGroupType_Diagnostics = 21015u;

	public const uint ReaderGroupType_Diagnostics_Counters = 21029u;

	public const uint ReaderGroupType_Diagnostics_LiveValues = 21060u;

	public const uint ReaderGroupType_TransportSettings = 21080u;

	public const uint ReaderGroupType_MessageSettings = 21081u;

	public const uint DataSetWriterType_TransportSettings = 15303u;

	public const uint DataSetWriterType_MessageSettings = 21095u;

	public const uint DataSetWriterType_Status = 15299u;

	public const uint DataSetWriterType_Diagnostics = 19550u;

	public const uint DataSetWriterType_Diagnostics_Counters = 19564u;

	public const uint DataSetWriterType_Diagnostics_LiveValues = 19595u;

	public const uint DataSetReaderType_TransportSettings = 15311u;

	public const uint DataSetReaderType_MessageSettings = 21103u;

	public const uint DataSetReaderType_Status = 15307u;

	public const uint DataSetReaderType_Diagnostics = 19609u;

	public const uint DataSetReaderType_Diagnostics_Counters = 19623u;

	public const uint DataSetReaderType_Diagnostics_LiveValues = 19654u;

	public const uint DataSetReaderType_SubscribedDataSet = 15316u;

	public const uint PubSubDiagnosticsType_Counters = 19691u;

	public const uint PubSubDiagnosticsType_LiveValues = 19722u;

	public const uint PubSubDiagnosticsRootType_LiveValues = 19777u;

	public const uint PubSubDiagnosticsConnectionType_LiveValues = 19831u;

	public const uint PubSubDiagnosticsWriterGroupType_Counters = 19848u;

	public const uint PubSubDiagnosticsWriterGroupType_LiveValues = 19879u;

	public const uint PubSubDiagnosticsReaderGroupType_Counters = 19917u;

	public const uint PubSubDiagnosticsReaderGroupType_LiveValues = 19948u;

	public const uint PubSubDiagnosticsDataSetWriterType_Counters = 19982u;

	public const uint PubSubDiagnosticsDataSetWriterType_LiveValues = 20013u;

	public const uint PubSubDiagnosticsDataSetReaderType_Counters = 20041u;

	public const uint PubSubDiagnosticsDataSetReaderType_LiveValues = 20072u;

	public const uint DatagramConnectionTransportType_DiscoveryAddress = 15072u;

	public const uint AliasNameCategoryType_Alias_Placeholder = 23457u;

	public const uint AliasNameCategoryType_SubAliasNameCategories_Placeholder = 23458u;

	public const uint Aliases = 23470u;

	public const uint TagVariables = 23479u;

	public const uint Topics = 23488u;

	public const uint Resources = 24226u;

	public const uint Communication = 24227u;

	public const uint MappingTables = 24228u;

	public const uint NetworkInterfaces = 24229u;

	public const uint Streams = 24230u;

	public const uint TalkerStreams = 24231u;

	public const uint ListenerStreams = 24232u;

	public const uint Union_Encoding_DefaultBinary = 12766u;

	public const uint KeyValuePair_Encoding_DefaultBinary = 14846u;

	public const uint AdditionalParametersType_Encoding_DefaultBinary = 17537u;

	public const uint EphemeralKeyType_Encoding_DefaultBinary = 17549u;

	public const uint EndpointType_Encoding_DefaultBinary = 15671u;

	public const uint RationalNumber_Encoding_DefaultBinary = 18815u;

	public const uint Vector_Encoding_DefaultBinary = 18816u;

	public const uint ThreeDVector_Encoding_DefaultBinary = 18817u;

	public const uint CartesianCoordinates_Encoding_DefaultBinary = 18818u;

	public const uint ThreeDCartesianCoordinates_Encoding_DefaultBinary = 18819u;

	public const uint Orientation_Encoding_DefaultBinary = 18820u;

	public const uint ThreeDOrientation_Encoding_DefaultBinary = 18821u;

	public const uint Frame_Encoding_DefaultBinary = 18822u;

	public const uint ThreeDFrame_Encoding_DefaultBinary = 18823u;

	public const uint IdentityMappingRuleType_Encoding_DefaultBinary = 15736u;

	public const uint CurrencyUnitType_Encoding_DefaultBinary = 23507u;

	public const uint TrustListDataType_Encoding_DefaultBinary = 12680u;

	public const uint DecimalDataType_Encoding_DefaultBinary = 17863u;

	public const uint DataTypeSchemaHeader_Encoding_DefaultBinary = 15676u;

	public const uint DataTypeDescription_Encoding_DefaultBinary = 125u;

	public const uint StructureDescription_Encoding_DefaultBinary = 126u;

	public const uint EnumDescription_Encoding_DefaultBinary = 127u;

	public const uint SimpleTypeDescription_Encoding_DefaultBinary = 15421u;

	public const uint UABinaryFileDataType_Encoding_DefaultBinary = 15422u;

	public const uint DataSetMetaDataType_Encoding_DefaultBinary = 124u;

	public const uint FieldMetaData_Encoding_DefaultBinary = 14839u;

	public const uint ConfigurationVersionDataType_Encoding_DefaultBinary = 14847u;

	public const uint PublishedDataSetDataType_Encoding_DefaultBinary = 15677u;

	public const uint PublishedDataSetSourceDataType_Encoding_DefaultBinary = 15678u;

	public const uint PublishedVariableDataType_Encoding_DefaultBinary = 14323u;

	public const uint PublishedDataItemsDataType_Encoding_DefaultBinary = 15679u;

	public const uint PublishedEventsDataType_Encoding_DefaultBinary = 15681u;

	public const uint DataSetWriterDataType_Encoding_DefaultBinary = 15682u;

	public const uint DataSetWriterTransportDataType_Encoding_DefaultBinary = 15683u;

	public const uint DataSetWriterMessageDataType_Encoding_DefaultBinary = 15688u;

	public const uint PubSubGroupDataType_Encoding_DefaultBinary = 15689u;

	public const uint WriterGroupDataType_Encoding_DefaultBinary = 21150u;

	public const uint WriterGroupTransportDataType_Encoding_DefaultBinary = 15691u;

	public const uint WriterGroupMessageDataType_Encoding_DefaultBinary = 15693u;

	public const uint PubSubConnectionDataType_Encoding_DefaultBinary = 15694u;

	public const uint ConnectionTransportDataType_Encoding_DefaultBinary = 15695u;

	public const uint NetworkAddressDataType_Encoding_DefaultBinary = 21151u;

	public const uint NetworkAddressUrlDataType_Encoding_DefaultBinary = 21152u;

	public const uint ReaderGroupDataType_Encoding_DefaultBinary = 21153u;

	public const uint ReaderGroupTransportDataType_Encoding_DefaultBinary = 15701u;

	public const uint ReaderGroupMessageDataType_Encoding_DefaultBinary = 15702u;

	public const uint DataSetReaderDataType_Encoding_DefaultBinary = 15703u;

	public const uint DataSetReaderTransportDataType_Encoding_DefaultBinary = 15705u;

	public const uint DataSetReaderMessageDataType_Encoding_DefaultBinary = 15706u;

	public const uint SubscribedDataSetDataType_Encoding_DefaultBinary = 15707u;

	public const uint TargetVariablesDataType_Encoding_DefaultBinary = 15712u;

	public const uint FieldTargetDataType_Encoding_DefaultBinary = 14848u;

	public const uint SubscribedDataSetMirrorDataType_Encoding_DefaultBinary = 15713u;

	public const uint PubSubConfigurationDataType_Encoding_DefaultBinary = 21154u;

	public const uint UadpWriterGroupMessageDataType_Encoding_DefaultBinary = 15715u;

	public const uint UadpDataSetWriterMessageDataType_Encoding_DefaultBinary = 15717u;

	public const uint UadpDataSetReaderMessageDataType_Encoding_DefaultBinary = 15718u;

	public const uint JsonWriterGroupMessageDataType_Encoding_DefaultBinary = 15719u;

	public const uint JsonDataSetWriterMessageDataType_Encoding_DefaultBinary = 15724u;

	public const uint JsonDataSetReaderMessageDataType_Encoding_DefaultBinary = 15725u;

	public const uint DatagramConnectionTransportDataType_Encoding_DefaultBinary = 17468u;

	public const uint DatagramWriterGroupTransportDataType_Encoding_DefaultBinary = 21155u;

	public const uint BrokerConnectionTransportDataType_Encoding_DefaultBinary = 15479u;

	public const uint BrokerWriterGroupTransportDataType_Encoding_DefaultBinary = 15727u;

	public const uint BrokerDataSetWriterTransportDataType_Encoding_DefaultBinary = 15729u;

	public const uint BrokerDataSetReaderTransportDataType_Encoding_DefaultBinary = 15733u;

	public const uint AliasNameDataType_Encoding_DefaultBinary = 23499u;

	public const uint UnsignedRationalNumber_Encoding_DefaultBinary = 24110u;

	public const uint RolePermissionType_Encoding_DefaultBinary = 128u;

	public const uint DataTypeDefinition_Encoding_DefaultBinary = 121u;

	public const uint StructureField_Encoding_DefaultBinary = 14844u;

	public const uint StructureDefinition_Encoding_DefaultBinary = 122u;

	public const uint EnumDefinition_Encoding_DefaultBinary = 123u;

	public const uint Node_Encoding_DefaultBinary = 260u;

	public const uint InstanceNode_Encoding_DefaultBinary = 11889u;

	public const uint TypeNode_Encoding_DefaultBinary = 11890u;

	public const uint ObjectNode_Encoding_DefaultBinary = 263u;

	public const uint ObjectTypeNode_Encoding_DefaultBinary = 266u;

	public const uint VariableNode_Encoding_DefaultBinary = 269u;

	public const uint VariableTypeNode_Encoding_DefaultBinary = 272u;

	public const uint ReferenceTypeNode_Encoding_DefaultBinary = 275u;

	public const uint MethodNode_Encoding_DefaultBinary = 278u;

	public const uint ViewNode_Encoding_DefaultBinary = 281u;

	public const uint DataTypeNode_Encoding_DefaultBinary = 284u;

	public const uint ReferenceNode_Encoding_DefaultBinary = 287u;

	public const uint Argument_Encoding_DefaultBinary = 298u;

	public const uint EnumValueType_Encoding_DefaultBinary = 8251u;

	public const uint EnumField_Encoding_DefaultBinary = 14845u;

	public const uint OptionSet_Encoding_DefaultBinary = 12765u;

	public const uint TimeZoneDataType_Encoding_DefaultBinary = 8917u;

	public const uint ApplicationDescription_Encoding_DefaultBinary = 310u;

	public const uint RequestHeader_Encoding_DefaultBinary = 391u;

	public const uint ResponseHeader_Encoding_DefaultBinary = 394u;

	public const uint ServiceFault_Encoding_DefaultBinary = 397u;

	public const uint SessionlessInvokeRequestType_Encoding_DefaultBinary = 15903u;

	public const uint SessionlessInvokeResponseType_Encoding_DefaultBinary = 21001u;

	public const uint FindServersRequest_Encoding_DefaultBinary = 422u;

	public const uint FindServersResponse_Encoding_DefaultBinary = 425u;

	public const uint ServerOnNetwork_Encoding_DefaultBinary = 12207u;

	public const uint FindServersOnNetworkRequest_Encoding_DefaultBinary = 12208u;

	public const uint FindServersOnNetworkResponse_Encoding_DefaultBinary = 12209u;

	public const uint UserTokenPolicy_Encoding_DefaultBinary = 306u;

	public const uint EndpointDescription_Encoding_DefaultBinary = 314u;

	public const uint GetEndpointsRequest_Encoding_DefaultBinary = 428u;

	public const uint GetEndpointsResponse_Encoding_DefaultBinary = 431u;

	public const uint RegisteredServer_Encoding_DefaultBinary = 434u;

	public const uint RegisterServerRequest_Encoding_DefaultBinary = 437u;

	public const uint RegisterServerResponse_Encoding_DefaultBinary = 440u;

	public const uint DiscoveryConfiguration_Encoding_DefaultBinary = 12900u;

	public const uint MdnsDiscoveryConfiguration_Encoding_DefaultBinary = 12901u;

	public const uint RegisterServer2Request_Encoding_DefaultBinary = 12211u;

	public const uint RegisterServer2Response_Encoding_DefaultBinary = 12212u;

	public const uint ChannelSecurityToken_Encoding_DefaultBinary = 443u;

	public const uint OpenSecureChannelRequest_Encoding_DefaultBinary = 446u;

	public const uint OpenSecureChannelResponse_Encoding_DefaultBinary = 449u;

	public const uint CloseSecureChannelRequest_Encoding_DefaultBinary = 452u;

	public const uint CloseSecureChannelResponse_Encoding_DefaultBinary = 455u;

	public const uint SignedSoftwareCertificate_Encoding_DefaultBinary = 346u;

	public const uint SignatureData_Encoding_DefaultBinary = 458u;

	public const uint CreateSessionRequest_Encoding_DefaultBinary = 461u;

	public const uint CreateSessionResponse_Encoding_DefaultBinary = 464u;

	public const uint UserIdentityToken_Encoding_DefaultBinary = 318u;

	public const uint AnonymousIdentityToken_Encoding_DefaultBinary = 321u;

	public const uint UserNameIdentityToken_Encoding_DefaultBinary = 324u;

	public const uint X509IdentityToken_Encoding_DefaultBinary = 327u;

	public const uint IssuedIdentityToken_Encoding_DefaultBinary = 940u;

	public const uint ActivateSessionRequest_Encoding_DefaultBinary = 467u;

	public const uint ActivateSessionResponse_Encoding_DefaultBinary = 470u;

	public const uint CloseSessionRequest_Encoding_DefaultBinary = 473u;

	public const uint CloseSessionResponse_Encoding_DefaultBinary = 476u;

	public const uint CancelRequest_Encoding_DefaultBinary = 479u;

	public const uint CancelResponse_Encoding_DefaultBinary = 482u;

	public const uint NodeAttributes_Encoding_DefaultBinary = 351u;

	public const uint ObjectAttributes_Encoding_DefaultBinary = 354u;

	public const uint VariableAttributes_Encoding_DefaultBinary = 357u;

	public const uint MethodAttributes_Encoding_DefaultBinary = 360u;

	public const uint ObjectTypeAttributes_Encoding_DefaultBinary = 363u;

	public const uint VariableTypeAttributes_Encoding_DefaultBinary = 366u;

	public const uint ReferenceTypeAttributes_Encoding_DefaultBinary = 369u;

	public const uint DataTypeAttributes_Encoding_DefaultBinary = 372u;

	public const uint ViewAttributes_Encoding_DefaultBinary = 375u;

	public const uint GenericAttributeValue_Encoding_DefaultBinary = 17610u;

	public const uint GenericAttributes_Encoding_DefaultBinary = 17611u;

	public const uint AddNodesItem_Encoding_DefaultBinary = 378u;

	public const uint AddNodesResult_Encoding_DefaultBinary = 485u;

	public const uint AddNodesRequest_Encoding_DefaultBinary = 488u;

	public const uint AddNodesResponse_Encoding_DefaultBinary = 491u;

	public const uint AddReferencesItem_Encoding_DefaultBinary = 381u;

	public const uint AddReferencesRequest_Encoding_DefaultBinary = 494u;

	public const uint AddReferencesResponse_Encoding_DefaultBinary = 497u;

	public const uint DeleteNodesItem_Encoding_DefaultBinary = 384u;

	public const uint DeleteNodesRequest_Encoding_DefaultBinary = 500u;

	public const uint DeleteNodesResponse_Encoding_DefaultBinary = 503u;

	public const uint DeleteReferencesItem_Encoding_DefaultBinary = 387u;

	public const uint DeleteReferencesRequest_Encoding_DefaultBinary = 506u;

	public const uint DeleteReferencesResponse_Encoding_DefaultBinary = 509u;

	public const uint ViewDescription_Encoding_DefaultBinary = 513u;

	public const uint BrowseDescription_Encoding_DefaultBinary = 516u;

	public const uint ReferenceDescription_Encoding_DefaultBinary = 520u;

	public const uint BrowseResult_Encoding_DefaultBinary = 524u;

	public const uint BrowseRequest_Encoding_DefaultBinary = 527u;

	public const uint BrowseResponse_Encoding_DefaultBinary = 530u;

	public const uint BrowseNextRequest_Encoding_DefaultBinary = 533u;

	public const uint BrowseNextResponse_Encoding_DefaultBinary = 536u;

	public const uint RelativePathElement_Encoding_DefaultBinary = 539u;

	public const uint RelativePath_Encoding_DefaultBinary = 542u;

	public const uint BrowsePath_Encoding_DefaultBinary = 545u;

	public const uint BrowsePathTarget_Encoding_DefaultBinary = 548u;

	public const uint BrowsePathResult_Encoding_DefaultBinary = 551u;

	public const uint TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultBinary = 554u;

	public const uint TranslateBrowsePathsToNodeIdsResponse_Encoding_DefaultBinary = 557u;

	public const uint RegisterNodesRequest_Encoding_DefaultBinary = 560u;

	public const uint RegisterNodesResponse_Encoding_DefaultBinary = 563u;

	public const uint UnregisterNodesRequest_Encoding_DefaultBinary = 566u;

	public const uint UnregisterNodesResponse_Encoding_DefaultBinary = 569u;

	public const uint EndpointConfiguration_Encoding_DefaultBinary = 333u;

	public const uint QueryDataDescription_Encoding_DefaultBinary = 572u;

	public const uint NodeTypeDescription_Encoding_DefaultBinary = 575u;

	public const uint QueryDataSet_Encoding_DefaultBinary = 579u;

	public const uint NodeReference_Encoding_DefaultBinary = 582u;

	public const uint ContentFilterElement_Encoding_DefaultBinary = 585u;

	public const uint ContentFilter_Encoding_DefaultBinary = 588u;

	public const uint FilterOperand_Encoding_DefaultBinary = 591u;

	public const uint ElementOperand_Encoding_DefaultBinary = 594u;

	public const uint LiteralOperand_Encoding_DefaultBinary = 597u;

	public const uint AttributeOperand_Encoding_DefaultBinary = 600u;

	public const uint SimpleAttributeOperand_Encoding_DefaultBinary = 603u;

	public const uint ContentFilterElementResult_Encoding_DefaultBinary = 606u;

	public const uint ContentFilterResult_Encoding_DefaultBinary = 609u;

	public const uint ParsingResult_Encoding_DefaultBinary = 612u;

	public const uint QueryFirstRequest_Encoding_DefaultBinary = 615u;

	public const uint QueryFirstResponse_Encoding_DefaultBinary = 618u;

	public const uint QueryNextRequest_Encoding_DefaultBinary = 621u;

	public const uint QueryNextResponse_Encoding_DefaultBinary = 624u;

	public const uint ReadValueId_Encoding_DefaultBinary = 628u;

	public const uint ReadRequest_Encoding_DefaultBinary = 631u;

	public const uint ReadResponse_Encoding_DefaultBinary = 634u;

	public const uint HistoryReadValueId_Encoding_DefaultBinary = 637u;

	public const uint HistoryReadResult_Encoding_DefaultBinary = 640u;

	public const uint HistoryReadDetails_Encoding_DefaultBinary = 643u;

	public const uint ReadEventDetails_Encoding_DefaultBinary = 646u;

	public const uint ReadRawModifiedDetails_Encoding_DefaultBinary = 649u;

	public const uint ReadProcessedDetails_Encoding_DefaultBinary = 652u;

	public const uint ReadAtTimeDetails_Encoding_DefaultBinary = 655u;

	public const uint ReadAnnotationDataDetails_Encoding_DefaultBinary = 23500u;

	public const uint HistoryData_Encoding_DefaultBinary = 658u;

	public const uint ModificationInfo_Encoding_DefaultBinary = 11226u;

	public const uint HistoryModifiedData_Encoding_DefaultBinary = 11227u;

	public const uint HistoryEvent_Encoding_DefaultBinary = 661u;

	public const uint HistoryReadRequest_Encoding_DefaultBinary = 664u;

	public const uint HistoryReadResponse_Encoding_DefaultBinary = 667u;

	public const uint WriteValue_Encoding_DefaultBinary = 670u;

	public const uint WriteRequest_Encoding_DefaultBinary = 673u;

	public const uint WriteResponse_Encoding_DefaultBinary = 676u;

	public const uint HistoryUpdateDetails_Encoding_DefaultBinary = 679u;

	public const uint UpdateDataDetails_Encoding_DefaultBinary = 682u;

	public const uint UpdateStructureDataDetails_Encoding_DefaultBinary = 11300u;

	public const uint UpdateEventDetails_Encoding_DefaultBinary = 685u;

	public const uint DeleteRawModifiedDetails_Encoding_DefaultBinary = 688u;

	public const uint DeleteAtTimeDetails_Encoding_DefaultBinary = 691u;

	public const uint DeleteEventDetails_Encoding_DefaultBinary = 694u;

	public const uint HistoryUpdateResult_Encoding_DefaultBinary = 697u;

	public const uint HistoryUpdateRequest_Encoding_DefaultBinary = 700u;

	public const uint HistoryUpdateResponse_Encoding_DefaultBinary = 703u;

	public const uint CallMethodRequest_Encoding_DefaultBinary = 706u;

	public const uint CallMethodResult_Encoding_DefaultBinary = 709u;

	public const uint CallRequest_Encoding_DefaultBinary = 712u;

	public const uint CallResponse_Encoding_DefaultBinary = 715u;

	public const uint MonitoringFilter_Encoding_DefaultBinary = 721u;

	public const uint DataChangeFilter_Encoding_DefaultBinary = 724u;

	public const uint EventFilter_Encoding_DefaultBinary = 727u;

	public const uint AggregateConfiguration_Encoding_DefaultBinary = 950u;

	public const uint AggregateFilter_Encoding_DefaultBinary = 730u;

	public const uint MonitoringFilterResult_Encoding_DefaultBinary = 733u;

	public const uint EventFilterResult_Encoding_DefaultBinary = 736u;

	public const uint AggregateFilterResult_Encoding_DefaultBinary = 739u;

	public const uint MonitoringParameters_Encoding_DefaultBinary = 742u;

	public const uint MonitoredItemCreateRequest_Encoding_DefaultBinary = 745u;

	public const uint MonitoredItemCreateResult_Encoding_DefaultBinary = 748u;

	public const uint CreateMonitoredItemsRequest_Encoding_DefaultBinary = 751u;

	public const uint CreateMonitoredItemsResponse_Encoding_DefaultBinary = 754u;

	public const uint MonitoredItemModifyRequest_Encoding_DefaultBinary = 757u;

	public const uint MonitoredItemModifyResult_Encoding_DefaultBinary = 760u;

	public const uint ModifyMonitoredItemsRequest_Encoding_DefaultBinary = 763u;

	public const uint ModifyMonitoredItemsResponse_Encoding_DefaultBinary = 766u;

	public const uint SetMonitoringModeRequest_Encoding_DefaultBinary = 769u;

	public const uint SetMonitoringModeResponse_Encoding_DefaultBinary = 772u;

	public const uint SetTriggeringRequest_Encoding_DefaultBinary = 775u;

	public const uint SetTriggeringResponse_Encoding_DefaultBinary = 778u;

	public const uint DeleteMonitoredItemsRequest_Encoding_DefaultBinary = 781u;

	public const uint DeleteMonitoredItemsResponse_Encoding_DefaultBinary = 784u;

	public const uint CreateSubscriptionRequest_Encoding_DefaultBinary = 787u;

	public const uint CreateSubscriptionResponse_Encoding_DefaultBinary = 790u;

	public const uint ModifySubscriptionRequest_Encoding_DefaultBinary = 793u;

	public const uint ModifySubscriptionResponse_Encoding_DefaultBinary = 796u;

	public const uint SetPublishingModeRequest_Encoding_DefaultBinary = 799u;

	public const uint SetPublishingModeResponse_Encoding_DefaultBinary = 802u;

	public const uint NotificationMessage_Encoding_DefaultBinary = 805u;

	public const uint NotificationData_Encoding_DefaultBinary = 947u;

	public const uint DataChangeNotification_Encoding_DefaultBinary = 811u;

	public const uint MonitoredItemNotification_Encoding_DefaultBinary = 808u;

	public const uint EventNotificationList_Encoding_DefaultBinary = 916u;

	public const uint EventFieldList_Encoding_DefaultBinary = 919u;

	public const uint HistoryEventFieldList_Encoding_DefaultBinary = 922u;

	public const uint StatusChangeNotification_Encoding_DefaultBinary = 820u;

	public const uint SubscriptionAcknowledgement_Encoding_DefaultBinary = 823u;

	public const uint PublishRequest_Encoding_DefaultBinary = 826u;

	public const uint PublishResponse_Encoding_DefaultBinary = 829u;

	public const uint RepublishRequest_Encoding_DefaultBinary = 832u;

	public const uint RepublishResponse_Encoding_DefaultBinary = 835u;

	public const uint TransferResult_Encoding_DefaultBinary = 838u;

	public const uint TransferSubscriptionsRequest_Encoding_DefaultBinary = 841u;

	public const uint TransferSubscriptionsResponse_Encoding_DefaultBinary = 844u;

	public const uint DeleteSubscriptionsRequest_Encoding_DefaultBinary = 847u;

	public const uint DeleteSubscriptionsResponse_Encoding_DefaultBinary = 850u;

	public const uint BuildInfo_Encoding_DefaultBinary = 340u;

	public const uint RedundantServerDataType_Encoding_DefaultBinary = 855u;

	public const uint EndpointUrlListDataType_Encoding_DefaultBinary = 11957u;

	public const uint NetworkGroupDataType_Encoding_DefaultBinary = 11958u;

	public const uint SamplingIntervalDiagnosticsDataType_Encoding_DefaultBinary = 858u;

	public const uint ServerDiagnosticsSummaryDataType_Encoding_DefaultBinary = 861u;

	public const uint ServerStatusDataType_Encoding_DefaultBinary = 864u;

	public const uint SessionDiagnosticsDataType_Encoding_DefaultBinary = 867u;

	public const uint SessionSecurityDiagnosticsDataType_Encoding_DefaultBinary = 870u;

	public const uint ServiceCounterDataType_Encoding_DefaultBinary = 873u;

	public const uint StatusResult_Encoding_DefaultBinary = 301u;

	public const uint SubscriptionDiagnosticsDataType_Encoding_DefaultBinary = 876u;

	public const uint ModelChangeStructureDataType_Encoding_DefaultBinary = 879u;

	public const uint SemanticChangeStructureDataType_Encoding_DefaultBinary = 899u;

	public const uint Range_Encoding_DefaultBinary = 886u;

	public const uint EUInformation_Encoding_DefaultBinary = 889u;

	public const uint ComplexNumberType_Encoding_DefaultBinary = 12181u;

	public const uint DoubleComplexNumberType_Encoding_DefaultBinary = 12182u;

	public const uint AxisInformation_Encoding_DefaultBinary = 12089u;

	public const uint XVType_Encoding_DefaultBinary = 12090u;

	public const uint ProgramDiagnosticDataType_Encoding_DefaultBinary = 896u;

	public const uint ProgramDiagnostic2DataType_Encoding_DefaultBinary = 24034u;

	public const uint Annotation_Encoding_DefaultBinary = 893u;

	public const uint Union_Encoding_DefaultXml = 12758u;

	public const uint KeyValuePair_Encoding_DefaultXml = 14802u;

	public const uint AdditionalParametersType_Encoding_DefaultXml = 17541u;

	public const uint EphemeralKeyType_Encoding_DefaultXml = 17553u;

	public const uint EndpointType_Encoding_DefaultXml = 15949u;

	public const uint RationalNumber_Encoding_DefaultXml = 18851u;

	public const uint Vector_Encoding_DefaultXml = 18852u;

	public const uint ThreeDVector_Encoding_DefaultXml = 18853u;

	public const uint CartesianCoordinates_Encoding_DefaultXml = 18854u;

	public const uint ThreeDCartesianCoordinates_Encoding_DefaultXml = 18855u;

	public const uint Orientation_Encoding_DefaultXml = 18856u;

	public const uint ThreeDOrientation_Encoding_DefaultXml = 18857u;

	public const uint Frame_Encoding_DefaultXml = 18858u;

	public const uint ThreeDFrame_Encoding_DefaultXml = 18859u;

	public const uint IdentityMappingRuleType_Encoding_DefaultXml = 15728u;

	public const uint CurrencyUnitType_Encoding_DefaultXml = 23520u;

	public const uint TrustListDataType_Encoding_DefaultXml = 12676u;

	public const uint DecimalDataType_Encoding_DefaultXml = 17862u;

	public const uint DataTypeSchemaHeader_Encoding_DefaultXml = 15950u;

	public const uint DataTypeDescription_Encoding_DefaultXml = 14796u;

	public const uint StructureDescription_Encoding_DefaultXml = 15589u;

	public const uint EnumDescription_Encoding_DefaultXml = 15590u;

	public const uint SimpleTypeDescription_Encoding_DefaultXml = 15529u;

	public const uint UABinaryFileDataType_Encoding_DefaultXml = 15531u;

	public const uint DataSetMetaDataType_Encoding_DefaultXml = 14794u;

	public const uint FieldMetaData_Encoding_DefaultXml = 14795u;

	public const uint ConfigurationVersionDataType_Encoding_DefaultXml = 14803u;

	public const uint PublishedDataSetDataType_Encoding_DefaultXml = 15951u;

	public const uint PublishedDataSetSourceDataType_Encoding_DefaultXml = 15952u;

	public const uint PublishedVariableDataType_Encoding_DefaultXml = 14319u;

	public const uint PublishedDataItemsDataType_Encoding_DefaultXml = 15953u;

	public const uint PublishedEventsDataType_Encoding_DefaultXml = 15954u;

	public const uint DataSetWriterDataType_Encoding_DefaultXml = 15955u;

	public const uint DataSetWriterTransportDataType_Encoding_DefaultXml = 15956u;

	public const uint DataSetWriterMessageDataType_Encoding_DefaultXml = 15987u;

	public const uint PubSubGroupDataType_Encoding_DefaultXml = 15988u;

	public const uint WriterGroupDataType_Encoding_DefaultXml = 21174u;

	public const uint WriterGroupTransportDataType_Encoding_DefaultXml = 15990u;

	public const uint WriterGroupMessageDataType_Encoding_DefaultXml = 15991u;

	public const uint PubSubConnectionDataType_Encoding_DefaultXml = 15992u;

	public const uint ConnectionTransportDataType_Encoding_DefaultXml = 15993u;

	public const uint NetworkAddressDataType_Encoding_DefaultXml = 21175u;

	public const uint NetworkAddressUrlDataType_Encoding_DefaultXml = 21176u;

	public const uint ReaderGroupDataType_Encoding_DefaultXml = 21177u;

	public const uint ReaderGroupTransportDataType_Encoding_DefaultXml = 15995u;

	public const uint ReaderGroupMessageDataType_Encoding_DefaultXml = 15996u;

	public const uint DataSetReaderDataType_Encoding_DefaultXml = 16007u;

	public const uint DataSetReaderTransportDataType_Encoding_DefaultXml = 16008u;

	public const uint DataSetReaderMessageDataType_Encoding_DefaultXml = 16009u;

	public const uint SubscribedDataSetDataType_Encoding_DefaultXml = 16010u;

	public const uint TargetVariablesDataType_Encoding_DefaultXml = 16011u;

	public const uint FieldTargetDataType_Encoding_DefaultXml = 14804u;

	public const uint SubscribedDataSetMirrorDataType_Encoding_DefaultXml = 16012u;

	public const uint PubSubConfigurationDataType_Encoding_DefaultXml = 21178u;

	public const uint UadpWriterGroupMessageDataType_Encoding_DefaultXml = 16014u;

	public const uint UadpDataSetWriterMessageDataType_Encoding_DefaultXml = 16015u;

	public const uint UadpDataSetReaderMessageDataType_Encoding_DefaultXml = 16016u;

	public const uint JsonWriterGroupMessageDataType_Encoding_DefaultXml = 16017u;

	public const uint JsonDataSetWriterMessageDataType_Encoding_DefaultXml = 16018u;

	public const uint JsonDataSetReaderMessageDataType_Encoding_DefaultXml = 16019u;

	public const uint DatagramConnectionTransportDataType_Encoding_DefaultXml = 17472u;

	public const uint DatagramWriterGroupTransportDataType_Encoding_DefaultXml = 21179u;

	public const uint BrokerConnectionTransportDataType_Encoding_DefaultXml = 15579u;

	public const uint BrokerWriterGroupTransportDataType_Encoding_DefaultXml = 16021u;

	public const uint BrokerDataSetWriterTransportDataType_Encoding_DefaultXml = 16022u;

	public const uint BrokerDataSetReaderTransportDataType_Encoding_DefaultXml = 16023u;

	public const uint AliasNameDataType_Encoding_DefaultXml = 23505u;

	public const uint UnsignedRationalNumber_Encoding_DefaultXml = 24122u;

	public const uint RolePermissionType_Encoding_DefaultXml = 16126u;

	public const uint DataTypeDefinition_Encoding_DefaultXml = 14797u;

	public const uint StructureField_Encoding_DefaultXml = 14800u;

	public const uint StructureDefinition_Encoding_DefaultXml = 14798u;

	public const uint EnumDefinition_Encoding_DefaultXml = 14799u;

	public const uint Node_Encoding_DefaultXml = 259u;

	public const uint InstanceNode_Encoding_DefaultXml = 11887u;

	public const uint TypeNode_Encoding_DefaultXml = 11888u;

	public const uint ObjectNode_Encoding_DefaultXml = 262u;

	public const uint ObjectTypeNode_Encoding_DefaultXml = 265u;

	public const uint VariableNode_Encoding_DefaultXml = 268u;

	public const uint VariableTypeNode_Encoding_DefaultXml = 271u;

	public const uint ReferenceTypeNode_Encoding_DefaultXml = 274u;

	public const uint MethodNode_Encoding_DefaultXml = 277u;

	public const uint ViewNode_Encoding_DefaultXml = 280u;

	public const uint DataTypeNode_Encoding_DefaultXml = 283u;

	public const uint ReferenceNode_Encoding_DefaultXml = 286u;

	public const uint Argument_Encoding_DefaultXml = 297u;

	public const uint EnumValueType_Encoding_DefaultXml = 7616u;

	public const uint EnumField_Encoding_DefaultXml = 14801u;

	public const uint OptionSet_Encoding_DefaultXml = 12757u;

	public const uint TimeZoneDataType_Encoding_DefaultXml = 8913u;

	public const uint ApplicationDescription_Encoding_DefaultXml = 309u;

	public const uint RequestHeader_Encoding_DefaultXml = 390u;

	public const uint ResponseHeader_Encoding_DefaultXml = 393u;

	public const uint ServiceFault_Encoding_DefaultXml = 396u;

	public const uint SessionlessInvokeRequestType_Encoding_DefaultXml = 15902u;

	public const uint SessionlessInvokeResponseType_Encoding_DefaultXml = 21000u;

	public const uint FindServersRequest_Encoding_DefaultXml = 421u;

	public const uint FindServersResponse_Encoding_DefaultXml = 424u;

	public const uint ServerOnNetwork_Encoding_DefaultXml = 12195u;

	public const uint FindServersOnNetworkRequest_Encoding_DefaultXml = 12196u;

	public const uint FindServersOnNetworkResponse_Encoding_DefaultXml = 12197u;

	public const uint UserTokenPolicy_Encoding_DefaultXml = 305u;

	public const uint EndpointDescription_Encoding_DefaultXml = 313u;

	public const uint GetEndpointsRequest_Encoding_DefaultXml = 427u;

	public const uint GetEndpointsResponse_Encoding_DefaultXml = 430u;

	public const uint RegisteredServer_Encoding_DefaultXml = 433u;

	public const uint RegisterServerRequest_Encoding_DefaultXml = 436u;

	public const uint RegisterServerResponse_Encoding_DefaultXml = 439u;

	public const uint DiscoveryConfiguration_Encoding_DefaultXml = 12892u;

	public const uint MdnsDiscoveryConfiguration_Encoding_DefaultXml = 12893u;

	public const uint RegisterServer2Request_Encoding_DefaultXml = 12199u;

	public const uint RegisterServer2Response_Encoding_DefaultXml = 12200u;

	public const uint ChannelSecurityToken_Encoding_DefaultXml = 442u;

	public const uint OpenSecureChannelRequest_Encoding_DefaultXml = 445u;

	public const uint OpenSecureChannelResponse_Encoding_DefaultXml = 448u;

	public const uint CloseSecureChannelRequest_Encoding_DefaultXml = 451u;

	public const uint CloseSecureChannelResponse_Encoding_DefaultXml = 454u;

	public const uint SignedSoftwareCertificate_Encoding_DefaultXml = 345u;

	public const uint SignatureData_Encoding_DefaultXml = 457u;

	public const uint CreateSessionRequest_Encoding_DefaultXml = 460u;

	public const uint CreateSessionResponse_Encoding_DefaultXml = 463u;

	public const uint UserIdentityToken_Encoding_DefaultXml = 317u;

	public const uint AnonymousIdentityToken_Encoding_DefaultXml = 320u;

	public const uint UserNameIdentityToken_Encoding_DefaultXml = 323u;

	public const uint X509IdentityToken_Encoding_DefaultXml = 326u;

	public const uint IssuedIdentityToken_Encoding_DefaultXml = 939u;

	public const uint ActivateSessionRequest_Encoding_DefaultXml = 466u;

	public const uint ActivateSessionResponse_Encoding_DefaultXml = 469u;

	public const uint CloseSessionRequest_Encoding_DefaultXml = 472u;

	public const uint CloseSessionResponse_Encoding_DefaultXml = 475u;

	public const uint CancelRequest_Encoding_DefaultXml = 478u;

	public const uint CancelResponse_Encoding_DefaultXml = 481u;

	public const uint NodeAttributes_Encoding_DefaultXml = 350u;

	public const uint ObjectAttributes_Encoding_DefaultXml = 353u;

	public const uint VariableAttributes_Encoding_DefaultXml = 356u;

	public const uint MethodAttributes_Encoding_DefaultXml = 359u;

	public const uint ObjectTypeAttributes_Encoding_DefaultXml = 362u;

	public const uint VariableTypeAttributes_Encoding_DefaultXml = 365u;

	public const uint ReferenceTypeAttributes_Encoding_DefaultXml = 368u;

	public const uint DataTypeAttributes_Encoding_DefaultXml = 371u;

	public const uint ViewAttributes_Encoding_DefaultXml = 374u;

	public const uint GenericAttributeValue_Encoding_DefaultXml = 17608u;

	public const uint GenericAttributes_Encoding_DefaultXml = 17609u;

	public const uint AddNodesItem_Encoding_DefaultXml = 377u;

	public const uint AddNodesResult_Encoding_DefaultXml = 484u;

	public const uint AddNodesRequest_Encoding_DefaultXml = 487u;

	public const uint AddNodesResponse_Encoding_DefaultXml = 490u;

	public const uint AddReferencesItem_Encoding_DefaultXml = 380u;

	public const uint AddReferencesRequest_Encoding_DefaultXml = 493u;

	public const uint AddReferencesResponse_Encoding_DefaultXml = 496u;

	public const uint DeleteNodesItem_Encoding_DefaultXml = 383u;

	public const uint DeleteNodesRequest_Encoding_DefaultXml = 499u;

	public const uint DeleteNodesResponse_Encoding_DefaultXml = 502u;

	public const uint DeleteReferencesItem_Encoding_DefaultXml = 386u;

	public const uint DeleteReferencesRequest_Encoding_DefaultXml = 505u;

	public const uint DeleteReferencesResponse_Encoding_DefaultXml = 508u;

	public const uint ViewDescription_Encoding_DefaultXml = 512u;

	public const uint BrowseDescription_Encoding_DefaultXml = 515u;

	public const uint ReferenceDescription_Encoding_DefaultXml = 519u;

	public const uint BrowseResult_Encoding_DefaultXml = 523u;

	public const uint BrowseRequest_Encoding_DefaultXml = 526u;

	public const uint BrowseResponse_Encoding_DefaultXml = 529u;

	public const uint BrowseNextRequest_Encoding_DefaultXml = 532u;

	public const uint BrowseNextResponse_Encoding_DefaultXml = 535u;

	public const uint RelativePathElement_Encoding_DefaultXml = 538u;

	public const uint RelativePath_Encoding_DefaultXml = 541u;

	public const uint BrowsePath_Encoding_DefaultXml = 544u;

	public const uint BrowsePathTarget_Encoding_DefaultXml = 547u;

	public const uint BrowsePathResult_Encoding_DefaultXml = 550u;

	public const uint TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultXml = 553u;

	public const uint TranslateBrowsePathsToNodeIdsResponse_Encoding_DefaultXml = 556u;

	public const uint RegisterNodesRequest_Encoding_DefaultXml = 559u;

	public const uint RegisterNodesResponse_Encoding_DefaultXml = 562u;

	public const uint UnregisterNodesRequest_Encoding_DefaultXml = 565u;

	public const uint UnregisterNodesResponse_Encoding_DefaultXml = 568u;

	public const uint EndpointConfiguration_Encoding_DefaultXml = 332u;

	public const uint QueryDataDescription_Encoding_DefaultXml = 571u;

	public const uint NodeTypeDescription_Encoding_DefaultXml = 574u;

	public const uint QueryDataSet_Encoding_DefaultXml = 578u;

	public const uint NodeReference_Encoding_DefaultXml = 581u;

	public const uint ContentFilterElement_Encoding_DefaultXml = 584u;

	public const uint ContentFilter_Encoding_DefaultXml = 587u;

	public const uint FilterOperand_Encoding_DefaultXml = 590u;

	public const uint ElementOperand_Encoding_DefaultXml = 593u;

	public const uint LiteralOperand_Encoding_DefaultXml = 596u;

	public const uint AttributeOperand_Encoding_DefaultXml = 599u;

	public const uint SimpleAttributeOperand_Encoding_DefaultXml = 602u;

	public const uint ContentFilterElementResult_Encoding_DefaultXml = 605u;

	public const uint ContentFilterResult_Encoding_DefaultXml = 608u;

	public const uint ParsingResult_Encoding_DefaultXml = 611u;

	public const uint QueryFirstRequest_Encoding_DefaultXml = 614u;

	public const uint QueryFirstResponse_Encoding_DefaultXml = 617u;

	public const uint QueryNextRequest_Encoding_DefaultXml = 620u;

	public const uint QueryNextResponse_Encoding_DefaultXml = 623u;

	public const uint ReadValueId_Encoding_DefaultXml = 627u;

	public const uint ReadRequest_Encoding_DefaultXml = 630u;

	public const uint ReadResponse_Encoding_DefaultXml = 633u;

	public const uint HistoryReadValueId_Encoding_DefaultXml = 636u;

	public const uint HistoryReadResult_Encoding_DefaultXml = 639u;

	public const uint HistoryReadDetails_Encoding_DefaultXml = 642u;

	public const uint ReadEventDetails_Encoding_DefaultXml = 645u;

	public const uint ReadRawModifiedDetails_Encoding_DefaultXml = 648u;

	public const uint ReadProcessedDetails_Encoding_DefaultXml = 651u;

	public const uint ReadAtTimeDetails_Encoding_DefaultXml = 654u;

	public const uint ReadAnnotationDataDetails_Encoding_DefaultXml = 23506u;

	public const uint HistoryData_Encoding_DefaultXml = 657u;

	public const uint ModificationInfo_Encoding_DefaultXml = 11218u;

	public const uint HistoryModifiedData_Encoding_DefaultXml = 11219u;

	public const uint HistoryEvent_Encoding_DefaultXml = 660u;

	public const uint HistoryReadRequest_Encoding_DefaultXml = 663u;

	public const uint HistoryReadResponse_Encoding_DefaultXml = 666u;

	public const uint WriteValue_Encoding_DefaultXml = 669u;

	public const uint WriteRequest_Encoding_DefaultXml = 672u;

	public const uint WriteResponse_Encoding_DefaultXml = 675u;

	public const uint HistoryUpdateDetails_Encoding_DefaultXml = 678u;

	public const uint UpdateDataDetails_Encoding_DefaultXml = 681u;

	public const uint UpdateStructureDataDetails_Encoding_DefaultXml = 11296u;

	public const uint UpdateEventDetails_Encoding_DefaultXml = 684u;

	public const uint DeleteRawModifiedDetails_Encoding_DefaultXml = 687u;

	public const uint DeleteAtTimeDetails_Encoding_DefaultXml = 690u;

	public const uint DeleteEventDetails_Encoding_DefaultXml = 693u;

	public const uint HistoryUpdateResult_Encoding_DefaultXml = 696u;

	public const uint HistoryUpdateRequest_Encoding_DefaultXml = 699u;

	public const uint HistoryUpdateResponse_Encoding_DefaultXml = 702u;

	public const uint CallMethodRequest_Encoding_DefaultXml = 705u;

	public const uint CallMethodResult_Encoding_DefaultXml = 708u;

	public const uint CallRequest_Encoding_DefaultXml = 711u;

	public const uint CallResponse_Encoding_DefaultXml = 714u;

	public const uint MonitoringFilter_Encoding_DefaultXml = 720u;

	public const uint DataChangeFilter_Encoding_DefaultXml = 723u;

	public const uint EventFilter_Encoding_DefaultXml = 726u;

	public const uint AggregateConfiguration_Encoding_DefaultXml = 949u;

	public const uint AggregateFilter_Encoding_DefaultXml = 729u;

	public const uint MonitoringFilterResult_Encoding_DefaultXml = 732u;

	public const uint EventFilterResult_Encoding_DefaultXml = 735u;

	public const uint AggregateFilterResult_Encoding_DefaultXml = 738u;

	public const uint MonitoringParameters_Encoding_DefaultXml = 741u;

	public const uint MonitoredItemCreateRequest_Encoding_DefaultXml = 744u;

	public const uint MonitoredItemCreateResult_Encoding_DefaultXml = 747u;

	public const uint CreateMonitoredItemsRequest_Encoding_DefaultXml = 750u;

	public const uint CreateMonitoredItemsResponse_Encoding_DefaultXml = 753u;

	public const uint MonitoredItemModifyRequest_Encoding_DefaultXml = 756u;

	public const uint MonitoredItemModifyResult_Encoding_DefaultXml = 759u;

	public const uint ModifyMonitoredItemsRequest_Encoding_DefaultXml = 762u;

	public const uint ModifyMonitoredItemsResponse_Encoding_DefaultXml = 765u;

	public const uint SetMonitoringModeRequest_Encoding_DefaultXml = 768u;

	public const uint SetMonitoringModeResponse_Encoding_DefaultXml = 771u;

	public const uint SetTriggeringRequest_Encoding_DefaultXml = 774u;

	public const uint SetTriggeringResponse_Encoding_DefaultXml = 777u;

	public const uint DeleteMonitoredItemsRequest_Encoding_DefaultXml = 780u;

	public const uint DeleteMonitoredItemsResponse_Encoding_DefaultXml = 783u;

	public const uint CreateSubscriptionRequest_Encoding_DefaultXml = 786u;

	public const uint CreateSubscriptionResponse_Encoding_DefaultXml = 789u;

	public const uint ModifySubscriptionRequest_Encoding_DefaultXml = 792u;

	public const uint ModifySubscriptionResponse_Encoding_DefaultXml = 795u;

	public const uint SetPublishingModeRequest_Encoding_DefaultXml = 798u;

	public const uint SetPublishingModeResponse_Encoding_DefaultXml = 801u;

	public const uint NotificationMessage_Encoding_DefaultXml = 804u;

	public const uint NotificationData_Encoding_DefaultXml = 946u;

	public const uint DataChangeNotification_Encoding_DefaultXml = 810u;

	public const uint MonitoredItemNotification_Encoding_DefaultXml = 807u;

	public const uint EventNotificationList_Encoding_DefaultXml = 915u;

	public const uint EventFieldList_Encoding_DefaultXml = 918u;

	public const uint HistoryEventFieldList_Encoding_DefaultXml = 921u;

	public const uint StatusChangeNotification_Encoding_DefaultXml = 819u;

	public const uint SubscriptionAcknowledgement_Encoding_DefaultXml = 822u;

	public const uint PublishRequest_Encoding_DefaultXml = 825u;

	public const uint PublishResponse_Encoding_DefaultXml = 828u;

	public const uint RepublishRequest_Encoding_DefaultXml = 831u;

	public const uint RepublishResponse_Encoding_DefaultXml = 834u;

	public const uint TransferResult_Encoding_DefaultXml = 837u;

	public const uint TransferSubscriptionsRequest_Encoding_DefaultXml = 840u;

	public const uint TransferSubscriptionsResponse_Encoding_DefaultXml = 843u;

	public const uint DeleteSubscriptionsRequest_Encoding_DefaultXml = 846u;

	public const uint DeleteSubscriptionsResponse_Encoding_DefaultXml = 849u;

	public const uint BuildInfo_Encoding_DefaultXml = 339u;

	public const uint RedundantServerDataType_Encoding_DefaultXml = 854u;

	public const uint EndpointUrlListDataType_Encoding_DefaultXml = 11949u;

	public const uint NetworkGroupDataType_Encoding_DefaultXml = 11950u;

	public const uint SamplingIntervalDiagnosticsDataType_Encoding_DefaultXml = 857u;

	public const uint ServerDiagnosticsSummaryDataType_Encoding_DefaultXml = 860u;

	public const uint ServerStatusDataType_Encoding_DefaultXml = 863u;

	public const uint SessionDiagnosticsDataType_Encoding_DefaultXml = 866u;

	public const uint SessionSecurityDiagnosticsDataType_Encoding_DefaultXml = 869u;

	public const uint ServiceCounterDataType_Encoding_DefaultXml = 872u;

	public const uint StatusResult_Encoding_DefaultXml = 300u;

	public const uint SubscriptionDiagnosticsDataType_Encoding_DefaultXml = 875u;

	public const uint ModelChangeStructureDataType_Encoding_DefaultXml = 878u;

	public const uint SemanticChangeStructureDataType_Encoding_DefaultXml = 898u;

	public const uint Range_Encoding_DefaultXml = 885u;

	public const uint EUInformation_Encoding_DefaultXml = 888u;

	public const uint ComplexNumberType_Encoding_DefaultXml = 12173u;

	public const uint DoubleComplexNumberType_Encoding_DefaultXml = 12174u;

	public const uint AxisInformation_Encoding_DefaultXml = 12081u;

	public const uint XVType_Encoding_DefaultXml = 12082u;

	public const uint ProgramDiagnosticDataType_Encoding_DefaultXml = 895u;

	public const uint ProgramDiagnostic2DataType_Encoding_DefaultXml = 24038u;

	public const uint Annotation_Encoding_DefaultXml = 892u;

	public const uint Union_Encoding_DefaultJson = 15085u;

	public const uint KeyValuePair_Encoding_DefaultJson = 15041u;

	public const uint AdditionalParametersType_Encoding_DefaultJson = 17547u;

	public const uint EphemeralKeyType_Encoding_DefaultJson = 17557u;

	public const uint EndpointType_Encoding_DefaultJson = 16150u;

	public const uint RationalNumber_Encoding_DefaultJson = 19064u;

	public const uint Vector_Encoding_DefaultJson = 19065u;

	public const uint ThreeDVector_Encoding_DefaultJson = 19066u;

	public const uint CartesianCoordinates_Encoding_DefaultJson = 19067u;

	public const uint ThreeDCartesianCoordinates_Encoding_DefaultJson = 19068u;

	public const uint Orientation_Encoding_DefaultJson = 19069u;

	public const uint ThreeDOrientation_Encoding_DefaultJson = 19070u;

	public const uint Frame_Encoding_DefaultJson = 19071u;

	public const uint ThreeDFrame_Encoding_DefaultJson = 19072u;

	public const uint IdentityMappingRuleType_Encoding_DefaultJson = 15042u;

	public const uint CurrencyUnitType_Encoding_DefaultJson = 23528u;

	public const uint TrustListDataType_Encoding_DefaultJson = 15044u;

	public const uint DecimalDataType_Encoding_DefaultJson = 15045u;

	public const uint DataTypeSchemaHeader_Encoding_DefaultJson = 16151u;

	public const uint DataTypeDescription_Encoding_DefaultJson = 15057u;

	public const uint StructureDescription_Encoding_DefaultJson = 15058u;

	public const uint EnumDescription_Encoding_DefaultJson = 15059u;

	public const uint SimpleTypeDescription_Encoding_DefaultJson = 15700u;

	public const uint UABinaryFileDataType_Encoding_DefaultJson = 15714u;

	public const uint DataSetMetaDataType_Encoding_DefaultJson = 15050u;

	public const uint FieldMetaData_Encoding_DefaultJson = 15051u;

	public const uint ConfigurationVersionDataType_Encoding_DefaultJson = 15049u;

	public const uint PublishedDataSetDataType_Encoding_DefaultJson = 16152u;

	public const uint PublishedDataSetSourceDataType_Encoding_DefaultJson = 16153u;

	public const uint PublishedVariableDataType_Encoding_DefaultJson = 15060u;

	public const uint PublishedDataItemsDataType_Encoding_DefaultJson = 16154u;

	public const uint PublishedEventsDataType_Encoding_DefaultJson = 16155u;

	public const uint DataSetWriterDataType_Encoding_DefaultJson = 16156u;

	public const uint DataSetWriterTransportDataType_Encoding_DefaultJson = 16157u;

	public const uint DataSetWriterMessageDataType_Encoding_DefaultJson = 16158u;

	public const uint PubSubGroupDataType_Encoding_DefaultJson = 16159u;

	public const uint WriterGroupDataType_Encoding_DefaultJson = 21198u;

	public const uint WriterGroupTransportDataType_Encoding_DefaultJson = 16161u;

	public const uint WriterGroupMessageDataType_Encoding_DefaultJson = 16280u;

	public const uint PubSubConnectionDataType_Encoding_DefaultJson = 16281u;

	public const uint ConnectionTransportDataType_Encoding_DefaultJson = 16282u;

	public const uint NetworkAddressDataType_Encoding_DefaultJson = 21199u;

	public const uint NetworkAddressUrlDataType_Encoding_DefaultJson = 21200u;

	public const uint ReaderGroupDataType_Encoding_DefaultJson = 21201u;

	public const uint ReaderGroupTransportDataType_Encoding_DefaultJson = 16284u;

	public const uint ReaderGroupMessageDataType_Encoding_DefaultJson = 16285u;

	public const uint DataSetReaderDataType_Encoding_DefaultJson = 16286u;

	public const uint DataSetReaderTransportDataType_Encoding_DefaultJson = 16287u;

	public const uint DataSetReaderMessageDataType_Encoding_DefaultJson = 16288u;

	public const uint SubscribedDataSetDataType_Encoding_DefaultJson = 16308u;

	public const uint TargetVariablesDataType_Encoding_DefaultJson = 16310u;

	public const uint FieldTargetDataType_Encoding_DefaultJson = 15061u;

	public const uint SubscribedDataSetMirrorDataType_Encoding_DefaultJson = 16311u;

	public const uint PubSubConfigurationDataType_Encoding_DefaultJson = 21202u;

	public const uint UadpWriterGroupMessageDataType_Encoding_DefaultJson = 16323u;

	public const uint UadpDataSetWriterMessageDataType_Encoding_DefaultJson = 16391u;

	public const uint UadpDataSetReaderMessageDataType_Encoding_DefaultJson = 16392u;

	public const uint JsonWriterGroupMessageDataType_Encoding_DefaultJson = 16393u;

	public const uint JsonDataSetWriterMessageDataType_Encoding_DefaultJson = 16394u;

	public const uint JsonDataSetReaderMessageDataType_Encoding_DefaultJson = 16404u;

	public const uint DatagramConnectionTransportDataType_Encoding_DefaultJson = 17476u;

	public const uint DatagramWriterGroupTransportDataType_Encoding_DefaultJson = 21203u;

	public const uint BrokerConnectionTransportDataType_Encoding_DefaultJson = 15726u;

	public const uint BrokerWriterGroupTransportDataType_Encoding_DefaultJson = 16524u;

	public const uint BrokerDataSetWriterTransportDataType_Encoding_DefaultJson = 16525u;

	public const uint BrokerDataSetReaderTransportDataType_Encoding_DefaultJson = 16526u;

	public const uint AliasNameDataType_Encoding_DefaultJson = 23511u;

	public const uint UnsignedRationalNumber_Encoding_DefaultJson = 24134u;

	public const uint RolePermissionType_Encoding_DefaultJson = 15062u;

	public const uint DataTypeDefinition_Encoding_DefaultJson = 15063u;

	public const uint StructureField_Encoding_DefaultJson = 15065u;

	public const uint StructureDefinition_Encoding_DefaultJson = 15066u;

	public const uint EnumDefinition_Encoding_DefaultJson = 15067u;

	public const uint Node_Encoding_DefaultJson = 15068u;

	public const uint InstanceNode_Encoding_DefaultJson = 15069u;

	public const uint TypeNode_Encoding_DefaultJson = 15070u;

	public const uint ObjectNode_Encoding_DefaultJson = 15071u;

	public const uint ObjectTypeNode_Encoding_DefaultJson = 15073u;

	public const uint VariableNode_Encoding_DefaultJson = 15074u;

	public const uint VariableTypeNode_Encoding_DefaultJson = 15075u;

	public const uint ReferenceTypeNode_Encoding_DefaultJson = 15076u;

	public const uint MethodNode_Encoding_DefaultJson = 15077u;

	public const uint ViewNode_Encoding_DefaultJson = 15078u;

	public const uint DataTypeNode_Encoding_DefaultJson = 15079u;

	public const uint ReferenceNode_Encoding_DefaultJson = 15080u;

	public const uint Argument_Encoding_DefaultJson = 15081u;

	public const uint EnumValueType_Encoding_DefaultJson = 15082u;

	public const uint EnumField_Encoding_DefaultJson = 15083u;

	public const uint OptionSet_Encoding_DefaultJson = 15084u;

	public const uint TimeZoneDataType_Encoding_DefaultJson = 15086u;

	public const uint ApplicationDescription_Encoding_DefaultJson = 15087u;

	public const uint RequestHeader_Encoding_DefaultJson = 15088u;

	public const uint ResponseHeader_Encoding_DefaultJson = 15089u;

	public const uint ServiceFault_Encoding_DefaultJson = 15090u;

	public const uint SessionlessInvokeRequestType_Encoding_DefaultJson = 15091u;

	public const uint SessionlessInvokeResponseType_Encoding_DefaultJson = 15092u;

	public const uint FindServersRequest_Encoding_DefaultJson = 15093u;

	public const uint FindServersResponse_Encoding_DefaultJson = 15094u;

	public const uint ServerOnNetwork_Encoding_DefaultJson = 15095u;

	public const uint FindServersOnNetworkRequest_Encoding_DefaultJson = 15096u;

	public const uint FindServersOnNetworkResponse_Encoding_DefaultJson = 15097u;

	public const uint UserTokenPolicy_Encoding_DefaultJson = 15098u;

	public const uint EndpointDescription_Encoding_DefaultJson = 15099u;

	public const uint GetEndpointsRequest_Encoding_DefaultJson = 15100u;

	public const uint GetEndpointsResponse_Encoding_DefaultJson = 15101u;

	public const uint RegisteredServer_Encoding_DefaultJson = 15102u;

	public const uint RegisterServerRequest_Encoding_DefaultJson = 15103u;

	public const uint RegisterServerResponse_Encoding_DefaultJson = 15104u;

	public const uint DiscoveryConfiguration_Encoding_DefaultJson = 15105u;

	public const uint MdnsDiscoveryConfiguration_Encoding_DefaultJson = 15106u;

	public const uint RegisterServer2Request_Encoding_DefaultJson = 15107u;

	public const uint RegisterServer2Response_Encoding_DefaultJson = 15130u;

	public const uint ChannelSecurityToken_Encoding_DefaultJson = 15131u;

	public const uint OpenSecureChannelRequest_Encoding_DefaultJson = 15132u;

	public const uint OpenSecureChannelResponse_Encoding_DefaultJson = 15133u;

	public const uint CloseSecureChannelRequest_Encoding_DefaultJson = 15134u;

	public const uint CloseSecureChannelResponse_Encoding_DefaultJson = 15135u;

	public const uint SignedSoftwareCertificate_Encoding_DefaultJson = 15136u;

	public const uint SignatureData_Encoding_DefaultJson = 15137u;

	public const uint CreateSessionRequest_Encoding_DefaultJson = 15138u;

	public const uint CreateSessionResponse_Encoding_DefaultJson = 15139u;

	public const uint UserIdentityToken_Encoding_DefaultJson = 15140u;

	public const uint AnonymousIdentityToken_Encoding_DefaultJson = 15141u;

	public const uint UserNameIdentityToken_Encoding_DefaultJson = 15142u;

	public const uint X509IdentityToken_Encoding_DefaultJson = 15143u;

	public const uint IssuedIdentityToken_Encoding_DefaultJson = 15144u;

	public const uint ActivateSessionRequest_Encoding_DefaultJson = 15145u;

	public const uint ActivateSessionResponse_Encoding_DefaultJson = 15146u;

	public const uint CloseSessionRequest_Encoding_DefaultJson = 15147u;

	public const uint CloseSessionResponse_Encoding_DefaultJson = 15148u;

	public const uint CancelRequest_Encoding_DefaultJson = 15149u;

	public const uint CancelResponse_Encoding_DefaultJson = 15150u;

	public const uint NodeAttributes_Encoding_DefaultJson = 15151u;

	public const uint ObjectAttributes_Encoding_DefaultJson = 15152u;

	public const uint VariableAttributes_Encoding_DefaultJson = 15153u;

	public const uint MethodAttributes_Encoding_DefaultJson = 15157u;

	public const uint ObjectTypeAttributes_Encoding_DefaultJson = 15158u;

	public const uint VariableTypeAttributes_Encoding_DefaultJson = 15159u;

	public const uint ReferenceTypeAttributes_Encoding_DefaultJson = 15160u;

	public const uint DataTypeAttributes_Encoding_DefaultJson = 15161u;

	public const uint ViewAttributes_Encoding_DefaultJson = 15162u;

	public const uint GenericAttributeValue_Encoding_DefaultJson = 15163u;

	public const uint GenericAttributes_Encoding_DefaultJson = 15164u;

	public const uint AddNodesItem_Encoding_DefaultJson = 15165u;

	public const uint AddNodesResult_Encoding_DefaultJson = 15166u;

	public const uint AddNodesRequest_Encoding_DefaultJson = 15167u;

	public const uint AddNodesResponse_Encoding_DefaultJson = 15168u;

	public const uint AddReferencesItem_Encoding_DefaultJson = 15169u;

	public const uint AddReferencesRequest_Encoding_DefaultJson = 15170u;

	public const uint AddReferencesResponse_Encoding_DefaultJson = 15171u;

	public const uint DeleteNodesItem_Encoding_DefaultJson = 15172u;

	public const uint DeleteNodesRequest_Encoding_DefaultJson = 15173u;

	public const uint DeleteNodesResponse_Encoding_DefaultJson = 15174u;

	public const uint DeleteReferencesItem_Encoding_DefaultJson = 15175u;

	public const uint DeleteReferencesRequest_Encoding_DefaultJson = 15176u;

	public const uint DeleteReferencesResponse_Encoding_DefaultJson = 15177u;

	public const uint ViewDescription_Encoding_DefaultJson = 15179u;

	public const uint BrowseDescription_Encoding_DefaultJson = 15180u;

	public const uint ReferenceDescription_Encoding_DefaultJson = 15182u;

	public const uint BrowseResult_Encoding_DefaultJson = 15183u;

	public const uint BrowseRequest_Encoding_DefaultJson = 15184u;

	public const uint BrowseResponse_Encoding_DefaultJson = 15185u;

	public const uint BrowseNextRequest_Encoding_DefaultJson = 15186u;

	public const uint BrowseNextResponse_Encoding_DefaultJson = 15187u;

	public const uint RelativePathElement_Encoding_DefaultJson = 15188u;

	public const uint RelativePath_Encoding_DefaultJson = 15189u;

	public const uint BrowsePath_Encoding_DefaultJson = 15190u;

	public const uint BrowsePathTarget_Encoding_DefaultJson = 15191u;

	public const uint BrowsePathResult_Encoding_DefaultJson = 15192u;

	public const uint TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultJson = 15193u;

	public const uint TranslateBrowsePathsToNodeIdsResponse_Encoding_DefaultJson = 15194u;

	public const uint RegisterNodesRequest_Encoding_DefaultJson = 15195u;

	public const uint RegisterNodesResponse_Encoding_DefaultJson = 15196u;

	public const uint UnregisterNodesRequest_Encoding_DefaultJson = 15197u;

	public const uint UnregisterNodesResponse_Encoding_DefaultJson = 15198u;

	public const uint EndpointConfiguration_Encoding_DefaultJson = 15199u;

	public const uint QueryDataDescription_Encoding_DefaultJson = 15200u;

	public const uint NodeTypeDescription_Encoding_DefaultJson = 15201u;

	public const uint QueryDataSet_Encoding_DefaultJson = 15202u;

	public const uint NodeReference_Encoding_DefaultJson = 15203u;

	public const uint ContentFilterElement_Encoding_DefaultJson = 15204u;

	public const uint ContentFilter_Encoding_DefaultJson = 15205u;

	public const uint FilterOperand_Encoding_DefaultJson = 15206u;

	public const uint ElementOperand_Encoding_DefaultJson = 15207u;

	public const uint LiteralOperand_Encoding_DefaultJson = 15208u;

	public const uint AttributeOperand_Encoding_DefaultJson = 15209u;

	public const uint SimpleAttributeOperand_Encoding_DefaultJson = 15210u;

	public const uint ContentFilterElementResult_Encoding_DefaultJson = 15211u;

	public const uint ContentFilterResult_Encoding_DefaultJson = 15228u;

	public const uint ParsingResult_Encoding_DefaultJson = 15236u;

	public const uint QueryFirstRequest_Encoding_DefaultJson = 15244u;

	public const uint QueryFirstResponse_Encoding_DefaultJson = 15252u;

	public const uint QueryNextRequest_Encoding_DefaultJson = 15254u;

	public const uint QueryNextResponse_Encoding_DefaultJson = 15255u;

	public const uint ReadValueId_Encoding_DefaultJson = 15256u;

	public const uint ReadRequest_Encoding_DefaultJson = 15257u;

	public const uint ReadResponse_Encoding_DefaultJson = 15258u;

	public const uint HistoryReadValueId_Encoding_DefaultJson = 15259u;

	public const uint HistoryReadResult_Encoding_DefaultJson = 15260u;

	public const uint HistoryReadDetails_Encoding_DefaultJson = 15261u;

	public const uint ReadEventDetails_Encoding_DefaultJson = 15262u;

	public const uint ReadRawModifiedDetails_Encoding_DefaultJson = 15263u;

	public const uint ReadProcessedDetails_Encoding_DefaultJson = 15264u;

	public const uint ReadAtTimeDetails_Encoding_DefaultJson = 15269u;

	public const uint ReadAnnotationDataDetails_Encoding_DefaultJson = 23512u;

	public const uint HistoryData_Encoding_DefaultJson = 15270u;

	public const uint ModificationInfo_Encoding_DefaultJson = 15271u;

	public const uint HistoryModifiedData_Encoding_DefaultJson = 15272u;

	public const uint HistoryEvent_Encoding_DefaultJson = 15273u;

	public const uint HistoryReadRequest_Encoding_DefaultJson = 15274u;

	public const uint HistoryReadResponse_Encoding_DefaultJson = 15275u;

	public const uint WriteValue_Encoding_DefaultJson = 15276u;

	public const uint WriteRequest_Encoding_DefaultJson = 15277u;

	public const uint WriteResponse_Encoding_DefaultJson = 15278u;

	public const uint HistoryUpdateDetails_Encoding_DefaultJson = 15279u;

	public const uint UpdateDataDetails_Encoding_DefaultJson = 15280u;

	public const uint UpdateStructureDataDetails_Encoding_DefaultJson = 15281u;

	public const uint UpdateEventDetails_Encoding_DefaultJson = 15282u;

	public const uint DeleteRawModifiedDetails_Encoding_DefaultJson = 15283u;

	public const uint DeleteAtTimeDetails_Encoding_DefaultJson = 15284u;

	public const uint DeleteEventDetails_Encoding_DefaultJson = 15285u;

	public const uint HistoryUpdateResult_Encoding_DefaultJson = 15286u;

	public const uint HistoryUpdateRequest_Encoding_DefaultJson = 15287u;

	public const uint HistoryUpdateResponse_Encoding_DefaultJson = 15288u;

	public const uint CallMethodRequest_Encoding_DefaultJson = 15289u;

	public const uint CallMethodResult_Encoding_DefaultJson = 15290u;

	public const uint CallRequest_Encoding_DefaultJson = 15291u;

	public const uint CallResponse_Encoding_DefaultJson = 15292u;

	public const uint MonitoringFilter_Encoding_DefaultJson = 15293u;

	public const uint DataChangeFilter_Encoding_DefaultJson = 15294u;

	public const uint EventFilter_Encoding_DefaultJson = 15295u;

	public const uint AggregateConfiguration_Encoding_DefaultJson = 15304u;

	public const uint AggregateFilter_Encoding_DefaultJson = 15312u;

	public const uint MonitoringFilterResult_Encoding_DefaultJson = 15313u;

	public const uint EventFilterResult_Encoding_DefaultJson = 15314u;

	public const uint AggregateFilterResult_Encoding_DefaultJson = 15315u;

	public const uint MonitoringParameters_Encoding_DefaultJson = 15320u;

	public const uint MonitoredItemCreateRequest_Encoding_DefaultJson = 15321u;

	public const uint MonitoredItemCreateResult_Encoding_DefaultJson = 15322u;

	public const uint CreateMonitoredItemsRequest_Encoding_DefaultJson = 15323u;

	public const uint CreateMonitoredItemsResponse_Encoding_DefaultJson = 15324u;

	public const uint MonitoredItemModifyRequest_Encoding_DefaultJson = 15325u;

	public const uint MonitoredItemModifyResult_Encoding_DefaultJson = 15326u;

	public const uint ModifyMonitoredItemsRequest_Encoding_DefaultJson = 15327u;

	public const uint ModifyMonitoredItemsResponse_Encoding_DefaultJson = 15328u;

	public const uint SetMonitoringModeRequest_Encoding_DefaultJson = 15329u;

	public const uint SetMonitoringModeResponse_Encoding_DefaultJson = 15331u;

	public const uint SetTriggeringRequest_Encoding_DefaultJson = 15332u;

	public const uint SetTriggeringResponse_Encoding_DefaultJson = 15333u;

	public const uint DeleteMonitoredItemsRequest_Encoding_DefaultJson = 15335u;

	public const uint DeleteMonitoredItemsResponse_Encoding_DefaultJson = 15336u;

	public const uint CreateSubscriptionRequest_Encoding_DefaultJson = 15337u;

	public const uint CreateSubscriptionResponse_Encoding_DefaultJson = 15338u;

	public const uint ModifySubscriptionRequest_Encoding_DefaultJson = 15339u;

	public const uint ModifySubscriptionResponse_Encoding_DefaultJson = 15340u;

	public const uint SetPublishingModeRequest_Encoding_DefaultJson = 15341u;

	public const uint SetPublishingModeResponse_Encoding_DefaultJson = 15342u;

	public const uint NotificationMessage_Encoding_DefaultJson = 15343u;

	public const uint NotificationData_Encoding_DefaultJson = 15344u;

	public const uint DataChangeNotification_Encoding_DefaultJson = 15345u;

	public const uint MonitoredItemNotification_Encoding_DefaultJson = 15346u;

	public const uint EventNotificationList_Encoding_DefaultJson = 15347u;

	public const uint EventFieldList_Encoding_DefaultJson = 15348u;

	public const uint HistoryEventFieldList_Encoding_DefaultJson = 15349u;

	public const uint StatusChangeNotification_Encoding_DefaultJson = 15350u;

	public const uint SubscriptionAcknowledgement_Encoding_DefaultJson = 15351u;

	public const uint PublishRequest_Encoding_DefaultJson = 15352u;

	public const uint PublishResponse_Encoding_DefaultJson = 15353u;

	public const uint RepublishRequest_Encoding_DefaultJson = 15354u;

	public const uint RepublishResponse_Encoding_DefaultJson = 15355u;

	public const uint TransferResult_Encoding_DefaultJson = 15356u;

	public const uint TransferSubscriptionsRequest_Encoding_DefaultJson = 15357u;

	public const uint TransferSubscriptionsResponse_Encoding_DefaultJson = 15358u;

	public const uint DeleteSubscriptionsRequest_Encoding_DefaultJson = 15359u;

	public const uint DeleteSubscriptionsResponse_Encoding_DefaultJson = 15360u;

	public const uint BuildInfo_Encoding_DefaultJson = 15361u;

	public const uint RedundantServerDataType_Encoding_DefaultJson = 15362u;

	public const uint EndpointUrlListDataType_Encoding_DefaultJson = 15363u;

	public const uint NetworkGroupDataType_Encoding_DefaultJson = 15364u;

	public const uint SamplingIntervalDiagnosticsDataType_Encoding_DefaultJson = 15365u;

	public const uint ServerDiagnosticsSummaryDataType_Encoding_DefaultJson = 15366u;

	public const uint ServerStatusDataType_Encoding_DefaultJson = 15367u;

	public const uint SessionDiagnosticsDataType_Encoding_DefaultJson = 15368u;

	public const uint SessionSecurityDiagnosticsDataType_Encoding_DefaultJson = 15369u;

	public const uint ServiceCounterDataType_Encoding_DefaultJson = 15370u;

	public const uint StatusResult_Encoding_DefaultJson = 15371u;

	public const uint SubscriptionDiagnosticsDataType_Encoding_DefaultJson = 15372u;

	public const uint ModelChangeStructureDataType_Encoding_DefaultJson = 15373u;

	public const uint SemanticChangeStructureDataType_Encoding_DefaultJson = 15374u;

	public const uint Range_Encoding_DefaultJson = 15375u;

	public const uint EUInformation_Encoding_DefaultJson = 15376u;

	public const uint ComplexNumberType_Encoding_DefaultJson = 15377u;

	public const uint DoubleComplexNumberType_Encoding_DefaultJson = 15378u;

	public const uint AxisInformation_Encoding_DefaultJson = 15379u;

	public const uint XVType_Encoding_DefaultJson = 15380u;

	public const uint ProgramDiagnosticDataType_Encoding_DefaultJson = 15381u;

	public const uint ProgramDiagnostic2DataType_Encoding_DefaultJson = 24042u;

	public const uint Annotation_Encoding_DefaultJson = 15382u;
}
