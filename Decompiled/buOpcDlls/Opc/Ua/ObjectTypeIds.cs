using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class ObjectTypeIds
{
	public static readonly NodeId BaseObjectType = new NodeId(58u);

	public static readonly NodeId FolderType = new NodeId(61u);

	public static readonly NodeId DataTypeSystemType = new NodeId(75u);

	public static readonly NodeId DataTypeEncodingType = new NodeId(76u);

	public static readonly NodeId ModellingRuleType = new NodeId(77u);

	public static readonly NodeId ServerType = new NodeId(2004u);

	public static readonly NodeId ServerCapabilitiesType = new NodeId(2013u);

	public static readonly NodeId ServerDiagnosticsType = new NodeId(2020u);

	public static readonly NodeId SessionsDiagnosticsSummaryType = new NodeId(2026u);

	public static readonly NodeId SessionDiagnosticsObjectType = new NodeId(2029u);

	public static readonly NodeId VendorServerInfoType = new NodeId(2033u);

	public static readonly NodeId ServerRedundancyType = new NodeId(2034u);

	public static readonly NodeId TransparentRedundancyType = new NodeId(2036u);

	public static readonly NodeId NonTransparentRedundancyType = new NodeId(2039u);

	public static readonly NodeId NonTransparentNetworkRedundancyType = new NodeId(11945u);

	public static readonly NodeId OperationLimitsType = new NodeId(11564u);

	public static readonly NodeId FileType = new NodeId(11575u);

	public static readonly NodeId AddressSpaceFileType = new NodeId(11595u);

	public static readonly NodeId NamespaceMetadataType = new NodeId(11616u);

	public static readonly NodeId NamespacesType = new NodeId(11645u);

	public static readonly NodeId BaseEventType = new NodeId(2041u);

	public static readonly NodeId AuditEventType = new NodeId(2052u);

	public static readonly NodeId AuditSecurityEventType = new NodeId(2058u);

	public static readonly NodeId AuditChannelEventType = new NodeId(2059u);

	public static readonly NodeId AuditOpenSecureChannelEventType = new NodeId(2060u);

	public static readonly NodeId AuditSessionEventType = new NodeId(2069u);

	public static readonly NodeId AuditCreateSessionEventType = new NodeId(2071u);

	public static readonly NodeId AuditUrlMismatchEventType = new NodeId(2748u);

	public static readonly NodeId AuditActivateSessionEventType = new NodeId(2075u);

	public static readonly NodeId AuditCancelEventType = new NodeId(2078u);

	public static readonly NodeId AuditCertificateEventType = new NodeId(2080u);

	public static readonly NodeId AuditCertificateDataMismatchEventType = new NodeId(2082u);

	public static readonly NodeId AuditCertificateExpiredEventType = new NodeId(2085u);

	public static readonly NodeId AuditCertificateInvalidEventType = new NodeId(2086u);

	public static readonly NodeId AuditCertificateUntrustedEventType = new NodeId(2087u);

	public static readonly NodeId AuditCertificateRevokedEventType = new NodeId(2088u);

	public static readonly NodeId AuditCertificateMismatchEventType = new NodeId(2089u);

	public static readonly NodeId AuditNodeManagementEventType = new NodeId(2090u);

	public static readonly NodeId AuditAddNodesEventType = new NodeId(2091u);

	public static readonly NodeId AuditDeleteNodesEventType = new NodeId(2093u);

	public static readonly NodeId AuditAddReferencesEventType = new NodeId(2095u);

	public static readonly NodeId AuditDeleteReferencesEventType = new NodeId(2097u);

	public static readonly NodeId AuditUpdateEventType = new NodeId(2099u);

	public static readonly NodeId AuditWriteUpdateEventType = new NodeId(2100u);

	public static readonly NodeId AuditHistoryUpdateEventType = new NodeId(2104u);

	public static readonly NodeId AuditUpdateMethodEventType = new NodeId(2127u);

	public static readonly NodeId SystemEventType = new NodeId(2130u);

	public static readonly NodeId DeviceFailureEventType = new NodeId(2131u);

	public static readonly NodeId SystemStatusChangeEventType = new NodeId(11446u);

	public static readonly NodeId BaseModelChangeEventType = new NodeId(2132u);

	public static readonly NodeId GeneralModelChangeEventType = new NodeId(2133u);

	public static readonly NodeId SemanticChangeEventType = new NodeId(2738u);

	public static readonly NodeId EventQueueOverflowEventType = new NodeId(3035u);

	public static readonly NodeId ProgressEventType = new NodeId(11436u);

	public static readonly NodeId AggregateFunctionType = new NodeId(2340u);

	public static readonly NodeId StateMachineType = new NodeId(2299u);

	public static readonly NodeId FiniteStateMachineType = new NodeId(2771u);

	public static readonly NodeId StateType = new NodeId(2307u);

	public static readonly NodeId InitialStateType = new NodeId(2309u);

	public static readonly NodeId TransitionType = new NodeId(2310u);

	public static readonly NodeId ChoiceStateType = new NodeId(15109u);

	public static readonly NodeId TransitionEventType = new NodeId(2311u);

	public static readonly NodeId AuditUpdateStateEventType = new NodeId(2315u);

	public static readonly NodeId FileDirectoryType = new NodeId(13353u);

	public static readonly NodeId TemporaryFileTransferType = new NodeId(15744u);

	public static readonly NodeId FileTransferStateMachineType = new NodeId(15803u);

	public static readonly NodeId RoleSetType = new NodeId(15607u);

	public static readonly NodeId RoleType = new NodeId(15620u);

	public static readonly NodeId RoleMappingRuleChangedAuditEventType = new NodeId(17641u);

	public static readonly NodeId DictionaryEntryType = new NodeId(17589u);

	public static readonly NodeId DictionaryFolderType = new NodeId(17591u);

	public static readonly NodeId IrdiDictionaryEntryType = new NodeId(17598u);

	public static readonly NodeId UriDictionaryEntryType = new NodeId(17600u);

	public static readonly NodeId BaseInterfaceType = new NodeId(17602u);

	public static readonly NodeId IOrderedObjectType = new NodeId(23513u);

	public static readonly NodeId OrderedListType = new NodeId(23518u);

	public static readonly NodeId ConditionType = new NodeId(2782u);

	public static readonly NodeId DialogConditionType = new NodeId(2830u);

	public static readonly NodeId AcknowledgeableConditionType = new NodeId(2881u);

	public static readonly NodeId AlarmConditionType = new NodeId(2915u);

	public static readonly NodeId AlarmGroupType = new NodeId(16405u);

	public static readonly NodeId ShelvedStateMachineType = new NodeId(2929u);

	public static readonly NodeId LimitAlarmType = new NodeId(2955u);

	public static readonly NodeId ExclusiveLimitStateMachineType = new NodeId(9318u);

	public static readonly NodeId ExclusiveLimitAlarmType = new NodeId(9341u);

	public static readonly NodeId NonExclusiveLimitAlarmType = new NodeId(9906u);

	public static readonly NodeId NonExclusiveLevelAlarmType = new NodeId(10060u);

	public static readonly NodeId ExclusiveLevelAlarmType = new NodeId(9482u);

	public static readonly NodeId NonExclusiveDeviationAlarmType = new NodeId(10368u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType = new NodeId(10214u);

	public static readonly NodeId ExclusiveDeviationAlarmType = new NodeId(9764u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType = new NodeId(9623u);

	public static readonly NodeId DiscreteAlarmType = new NodeId(10523u);

	public static readonly NodeId OffNormalAlarmType = new NodeId(10637u);

	public static readonly NodeId SystemOffNormalAlarmType = new NodeId(11753u);

	public static readonly NodeId TripAlarmType = new NodeId(10751u);

	public static readonly NodeId InstrumentDiagnosticAlarmType = new NodeId(18347u);

	public static readonly NodeId SystemDiagnosticAlarmType = new NodeId(18496u);

	public static readonly NodeId CertificateExpirationAlarmType = new NodeId(13225u);

	public static readonly NodeId DiscrepancyAlarmType = new NodeId(17080u);

	public static readonly NodeId BaseConditionClassType = new NodeId(11163u);

	public static readonly NodeId ProcessConditionClassType = new NodeId(11164u);

	public static readonly NodeId MaintenanceConditionClassType = new NodeId(11165u);

	public static readonly NodeId SystemConditionClassType = new NodeId(11166u);

	public static readonly NodeId SafetyConditionClassType = new NodeId(17218u);

	public static readonly NodeId HighlyManagedAlarmConditionClassType = new NodeId(17219u);

	public static readonly NodeId TrainingConditionClassType = new NodeId(17220u);

	public static readonly NodeId StatisticalConditionClassType = new NodeId(18665u);

	public static readonly NodeId TestingConditionClassType = new NodeId(17221u);

	public static readonly NodeId AuditConditionEventType = new NodeId(2790u);

	public static readonly NodeId AuditConditionEnableEventType = new NodeId(2803u);

	public static readonly NodeId AuditConditionCommentEventType = new NodeId(2829u);

	public static readonly NodeId AuditConditionRespondEventType = new NodeId(8927u);

	public static readonly NodeId AuditConditionAcknowledgeEventType = new NodeId(8944u);

	public static readonly NodeId AuditConditionConfirmEventType = new NodeId(8961u);

	public static readonly NodeId AuditConditionShelvingEventType = new NodeId(11093u);

	public static readonly NodeId AuditConditionSuppressionEventType = new NodeId(17225u);

	public static readonly NodeId AuditConditionSilenceEventType = new NodeId(17242u);

	public static readonly NodeId AuditConditionResetEventType = new NodeId(15013u);

	public static readonly NodeId AuditConditionOutOfServiceEventType = new NodeId(17259u);

	public static readonly NodeId RefreshStartEventType = new NodeId(2787u);

	public static readonly NodeId RefreshEndEventType = new NodeId(2788u);

	public static readonly NodeId RefreshRequiredEventType = new NodeId(2789u);

	public static readonly NodeId AlarmMetricsType = new NodeId(17279u);

	public static readonly NodeId ProgramStateMachineType = new NodeId(2391u);

	public static readonly NodeId ProgramTransitionEventType = new NodeId(2378u);

	public static readonly NodeId AuditProgramTransitionEventType = new NodeId(11856u);

	public static readonly NodeId ProgramTransitionAuditEventType = new NodeId(3806u);

	public static readonly NodeId HistoricalDataConfigurationType = new NodeId(2318u);

	public static readonly NodeId HistoryServerCapabilitiesType = new NodeId(2330u);

	public static readonly NodeId AuditHistoryEventUpdateEventType = new NodeId(2999u);

	public static readonly NodeId AuditHistoryValueUpdateEventType = new NodeId(3006u);

	public static readonly NodeId AuditHistoryAnnotationUpdateEventType = new NodeId(19095u);

	public static readonly NodeId AuditHistoryDeleteEventType = new NodeId(3012u);

	public static readonly NodeId AuditHistoryRawModifyDeleteEventType = new NodeId(3014u);

	public static readonly NodeId AuditHistoryAtTimeDeleteEventType = new NodeId(3019u);

	public static readonly NodeId AuditHistoryEventDeleteEventType = new NodeId(3022u);

	public static readonly NodeId TrustListType = new NodeId(12522u);

	public static readonly NodeId TrustListOutOfDateAlarmType = new NodeId(19297u);

	public static readonly NodeId CertificateGroupType = new NodeId(12555u);

	public static readonly NodeId CertificateGroupFolderType = new NodeId(13813u);

	public static readonly NodeId CertificateType = new NodeId(12556u);

	public static readonly NodeId ApplicationCertificateType = new NodeId(12557u);

	public static readonly NodeId HttpsCertificateType = new NodeId(12558u);

	public static readonly NodeId UserCredentialCertificateType = new NodeId(15181u);

	public static readonly NodeId RsaMinApplicationCertificateType = new NodeId(12559u);

	public static readonly NodeId RsaSha256ApplicationCertificateType = new NodeId(12560u);

	public static readonly NodeId EccApplicationCertificateType = new NodeId(23537u);

	public static readonly NodeId EccNistP256ApplicationCertificateType = new NodeId(23538u);

	public static readonly NodeId EccNistP384ApplicationCertificateType = new NodeId(23539u);

	public static readonly NodeId EccBrainpoolP256r1ApplicationCertificateType = new NodeId(23540u);

	public static readonly NodeId EccBrainpoolP384r1ApplicationCertificateType = new NodeId(23541u);

	public static readonly NodeId EccCurve25519ApplicationCertificateType = new NodeId(23542u);

	public static readonly NodeId EccCurve448ApplicationCertificateType = new NodeId(23543u);

	public static readonly NodeId TrustListUpdatedAuditEventType = new NodeId(12561u);

	public static readonly NodeId ServerConfigurationType = new NodeId(12581u);

	public static readonly NodeId CertificateUpdatedAuditEventType = new NodeId(12620u);

	public static readonly NodeId KeyCredentialConfigurationFolderType = new NodeId(17496u);

	public static readonly NodeId KeyCredentialConfigurationType = new NodeId(18001u);

	public static readonly NodeId KeyCredentialAuditEventType = new NodeId(18011u);

	public static readonly NodeId KeyCredentialUpdatedAuditEventType = new NodeId(18029u);

	public static readonly NodeId KeyCredentialDeletedAuditEventType = new NodeId(18047u);

	public static readonly NodeId AuthorizationServicesConfigurationFolderType = new NodeId(23556u);

	public static readonly NodeId AuthorizationServiceConfigurationType = new NodeId(17852u);

	public static readonly NodeId AggregateConfigurationType = new NodeId(11187u);

	public static readonly NodeId PubSubKeyServiceType = new NodeId(15906u);

	public static readonly NodeId SecurityGroupFolderType = new NodeId(15452u);

	public static readonly NodeId SecurityGroupType = new NodeId(15471u);

	public static readonly NodeId PublishSubscribeType = new NodeId(14416u);

	public static readonly NodeId PublishedDataSetType = new NodeId(14509u);

	public static readonly NodeId ExtensionFieldsType = new NodeId(15489u);

	public static readonly NodeId PublishedDataItemsType = new NodeId(14534u);

	public static readonly NodeId PublishedEventsType = new NodeId(14572u);

	public static readonly NodeId DataSetFolderType = new NodeId(14477u);

	public static readonly NodeId PubSubConnectionType = new NodeId(14209u);

	public static readonly NodeId ConnectionTransportType = new NodeId(17721u);

	public static readonly NodeId PubSubGroupType = new NodeId(14232u);

	public static readonly NodeId WriterGroupType = new NodeId(17725u);

	public static readonly NodeId WriterGroupTransportType = new NodeId(17997u);

	public static readonly NodeId WriterGroupMessageType = new NodeId(17998u);

	public static readonly NodeId ReaderGroupType = new NodeId(17999u);

	public static readonly NodeId ReaderGroupTransportType = new NodeId(21090u);

	public static readonly NodeId ReaderGroupMessageType = new NodeId(21091u);

	public static readonly NodeId DataSetWriterType = new NodeId(15298u);

	public static readonly NodeId DataSetWriterTransportType = new NodeId(15305u);

	public static readonly NodeId DataSetWriterMessageType = new NodeId(21096u);

	public static readonly NodeId DataSetReaderType = new NodeId(15306u);

	public static readonly NodeId DataSetReaderTransportType = new NodeId(15319u);

	public static readonly NodeId DataSetReaderMessageType = new NodeId(21104u);

	public static readonly NodeId SubscribedDataSetType = new NodeId(15108u);

	public static readonly NodeId TargetVariablesType = new NodeId(15111u);

	public static readonly NodeId SubscribedDataSetMirrorType = new NodeId(15127u);

	public static readonly NodeId PubSubStatusType = new NodeId(14643u);

	public static readonly NodeId PubSubDiagnosticsType = new NodeId(19677u);

	public static readonly NodeId PubSubDiagnosticsRootType = new NodeId(19732u);

	public static readonly NodeId PubSubDiagnosticsConnectionType = new NodeId(19786u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType = new NodeId(19834u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType = new NodeId(19903u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType = new NodeId(19968u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType = new NodeId(20027u);

	public static readonly NodeId PubSubStatusEventType = new NodeId(15535u);

	public static readonly NodeId PubSubTransportLimitsExceedEventType = new NodeId(15548u);

	public static readonly NodeId PubSubCommunicationFailureEventType = new NodeId(15563u);

	public static readonly NodeId UadpWriterGroupMessageType = new NodeId(21105u);

	public static readonly NodeId UadpDataSetWriterMessageType = new NodeId(21111u);

	public static readonly NodeId UadpDataSetReaderMessageType = new NodeId(21116u);

	public static readonly NodeId JsonWriterGroupMessageType = new NodeId(21126u);

	public static readonly NodeId JsonDataSetWriterMessageType = new NodeId(21128u);

	public static readonly NodeId JsonDataSetReaderMessageType = new NodeId(21130u);

	public static readonly NodeId DatagramConnectionTransportType = new NodeId(15064u);

	public static readonly NodeId DatagramWriterGroupTransportType = new NodeId(21133u);

	public static readonly NodeId BrokerConnectionTransportType = new NodeId(15155u);

	public static readonly NodeId BrokerWriterGroupTransportType = new NodeId(21136u);

	public static readonly NodeId BrokerDataSetWriterTransportType = new NodeId(21138u);

	public static readonly NodeId BrokerDataSetReaderTransportType = new NodeId(21142u);

	public static readonly NodeId NetworkAddressType = new NodeId(21145u);

	public static readonly NodeId NetworkAddressUrlType = new NodeId(21147u);

	public static readonly NodeId AliasNameType = new NodeId(23455u);

	public static readonly NodeId AliasNameCategoryType = new NodeId(23456u);

	public static readonly NodeId IIetfBaseNetworkInterfaceType = new NodeId(24148u);

	public static readonly NodeId IIeeeBaseEthernetPortType = new NodeId(24158u);

	public static readonly NodeId IIeeeAutoNegotiationStatusType = new NodeId(24233u);

	public static readonly NodeId IBaseEthernetCapabilitiesType = new NodeId(24167u);

	public static readonly NodeId ISrClassType = new NodeId(24169u);

	public static readonly NodeId IIeeeBaseTsnStreamType = new NodeId(24173u);

	public static readonly NodeId IIeeeBaseTsnTrafficSpecificationType = new NodeId(24179u);

	public static readonly NodeId IIeeeBaseTsnStatusStreamType = new NodeId(24183u);

	public static readonly NodeId IIeeeTsnInterfaceConfigurationType = new NodeId(24188u);

	public static readonly NodeId IIeeeTsnInterfaceConfigurationTalkerType = new NodeId(24191u);

	public static readonly NodeId IIeeeTsnInterfaceConfigurationListenerType = new NodeId(24195u);

	public static readonly NodeId IIeeeTsnMacAddressType = new NodeId(24199u);

	public static readonly NodeId IIeeeTsnVlanTagType = new NodeId(24202u);

	public static readonly NodeId IPriorityMappingEntryType = new NodeId(24205u);
}
