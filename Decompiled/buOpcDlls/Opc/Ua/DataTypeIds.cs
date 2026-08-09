using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class DataTypeIds
{
	public static readonly NodeId BaseDataType = new NodeId(24u);

	public static readonly NodeId Number = new NodeId(26u);

	public static readonly NodeId Integer = new NodeId(27u);

	public static readonly NodeId UInteger = new NodeId(28u);

	public static readonly NodeId Enumeration = new NodeId(29u);

	public static readonly NodeId Boolean = new NodeId(1u);

	public static readonly NodeId SByte = new NodeId(2u);

	public static readonly NodeId Byte = new NodeId(3u);

	public static readonly NodeId Int16 = new NodeId(4u);

	public static readonly NodeId UInt16 = new NodeId(5u);

	public static readonly NodeId Int32 = new NodeId(6u);

	public static readonly NodeId UInt32 = new NodeId(7u);

	public static readonly NodeId Int64 = new NodeId(8u);

	public static readonly NodeId UInt64 = new NodeId(9u);

	public static readonly NodeId Float = new NodeId(10u);

	public static readonly NodeId Double = new NodeId(11u);

	public static readonly NodeId String = new NodeId(12u);

	public static readonly NodeId DateTime = new NodeId(13u);

	public static readonly NodeId Guid = new NodeId(14u);

	public static readonly NodeId ByteString = new NodeId(15u);

	public static readonly NodeId XmlElement = new NodeId(16u);

	public static readonly NodeId NodeId = new NodeId(17u);

	public static readonly NodeId ExpandedNodeId = new NodeId(18u);

	public static readonly NodeId StatusCode = new NodeId(19u);

	public static readonly NodeId QualifiedName = new NodeId(20u);

	public static readonly NodeId LocalizedText = new NodeId(21u);

	public static readonly NodeId Structure = new NodeId(22u);

	public static readonly NodeId DataValue = new NodeId(23u);

	public static readonly NodeId DiagnosticInfo = new NodeId(25u);

	public static readonly NodeId Image = new NodeId(30u);

	public static readonly NodeId Decimal = new NodeId(50u);

	public static readonly NodeId NamingRuleType = new NodeId(120u);

	public static readonly NodeId ImageBMP = new NodeId(2000u);

	public static readonly NodeId ImageGIF = new NodeId(2001u);

	public static readonly NodeId ImageJPG = new NodeId(2002u);

	public static readonly NodeId ImagePNG = new NodeId(2003u);

	public static readonly NodeId AudioDataType = new NodeId(16307u);

	public static readonly NodeId Union = new NodeId(12756u);

	public static readonly NodeId BitFieldMaskDataType = new NodeId(11737u);

	public static readonly NodeId KeyValuePair = new NodeId(14533u);

	public static readonly NodeId AdditionalParametersType = new NodeId(16313u);

	public static readonly NodeId EphemeralKeyType = new NodeId(17548u);

	public static readonly NodeId EndpointType = new NodeId(15528u);

	public static readonly NodeId RationalNumber = new NodeId(18806u);

	public static readonly NodeId Vector = new NodeId(18807u);

	public static readonly NodeId ThreeDVector = new NodeId(18808u);

	public static readonly NodeId CartesianCoordinates = new NodeId(18809u);

	public static readonly NodeId ThreeDCartesianCoordinates = new NodeId(18810u);

	public static readonly NodeId Orientation = new NodeId(18811u);

	public static readonly NodeId ThreeDOrientation = new NodeId(18812u);

	public static readonly NodeId Frame = new NodeId(18813u);

	public static readonly NodeId ThreeDFrame = new NodeId(18814u);

	public static readonly NodeId OpenFileMode = new NodeId(11939u);

	public static readonly NodeId IdentityCriteriaType = new NodeId(15632u);

	public static readonly NodeId IdentityMappingRuleType = new NodeId(15634u);

	public static readonly NodeId CurrencyUnitType = new NodeId(23498u);

	public static readonly NodeId TrustListMasks = new NodeId(12552u);

	public static readonly NodeId TrustListDataType = new NodeId(12554u);

	public static readonly NodeId DecimalDataType = new NodeId(17861u);

	public static readonly NodeId DataTypeSchemaHeader = new NodeId(15534u);

	public static readonly NodeId DataTypeDescription = new NodeId(14525u);

	public static readonly NodeId StructureDescription = new NodeId(15487u);

	public static readonly NodeId EnumDescription = new NodeId(15488u);

	public static readonly NodeId SimpleTypeDescription = new NodeId(15005u);

	public static readonly NodeId UABinaryFileDataType = new NodeId(15006u);

	public static readonly NodeId PubSubState = new NodeId(14647u);

	public static readonly NodeId DataSetMetaDataType = new NodeId(14523u);

	public static readonly NodeId FieldMetaData = new NodeId(14524u);

	public static readonly NodeId DataSetFieldFlags = new NodeId(15904u);

	public static readonly NodeId ConfigurationVersionDataType = new NodeId(14593u);

	public static readonly NodeId PublishedDataSetDataType = new NodeId(15578u);

	public static readonly NodeId PublishedDataSetSourceDataType = new NodeId(15580u);

	public static readonly NodeId PublishedVariableDataType = new NodeId(14273u);

	public static readonly NodeId PublishedDataItemsDataType = new NodeId(15581u);

	public static readonly NodeId PublishedEventsDataType = new NodeId(15582u);

	public static readonly NodeId DataSetFieldContentMask = new NodeId(15583u);

	public static readonly NodeId DataSetWriterDataType = new NodeId(15597u);

	public static readonly NodeId DataSetWriterTransportDataType = new NodeId(15598u);

	public static readonly NodeId DataSetWriterMessageDataType = new NodeId(15605u);

	public static readonly NodeId PubSubGroupDataType = new NodeId(15609u);

	public static readonly NodeId WriterGroupDataType = new NodeId(15480u);

	public static readonly NodeId WriterGroupTransportDataType = new NodeId(15611u);

	public static readonly NodeId WriterGroupMessageDataType = new NodeId(15616u);

	public static readonly NodeId PubSubConnectionDataType = new NodeId(15617u);

	public static readonly NodeId ConnectionTransportDataType = new NodeId(15618u);

	public static readonly NodeId NetworkAddressDataType = new NodeId(15502u);

	public static readonly NodeId NetworkAddressUrlDataType = new NodeId(15510u);

	public static readonly NodeId ReaderGroupDataType = new NodeId(15520u);

	public static readonly NodeId ReaderGroupTransportDataType = new NodeId(15621u);

	public static readonly NodeId ReaderGroupMessageDataType = new NodeId(15622u);

	public static readonly NodeId DataSetReaderDataType = new NodeId(15623u);

	public static readonly NodeId DataSetReaderTransportDataType = new NodeId(15628u);

	public static readonly NodeId DataSetReaderMessageDataType = new NodeId(15629u);

	public static readonly NodeId SubscribedDataSetDataType = new NodeId(15630u);

	public static readonly NodeId TargetVariablesDataType = new NodeId(15631u);

	public static readonly NodeId FieldTargetDataType = new NodeId(14744u);

	public static readonly NodeId OverrideValueHandling = new NodeId(15874u);

	public static readonly NodeId SubscribedDataSetMirrorDataType = new NodeId(15635u);

	public static readonly NodeId PubSubConfigurationDataType = new NodeId(15530u);

	public static readonly NodeId DataSetOrderingType = new NodeId(20408u);

	public static readonly NodeId UadpNetworkMessageContentMask = new NodeId(15642u);

	public static readonly NodeId UadpWriterGroupMessageDataType = new NodeId(15645u);

	public static readonly NodeId UadpDataSetMessageContentMask = new NodeId(15646u);

	public static readonly NodeId UadpDataSetWriterMessageDataType = new NodeId(15652u);

	public static readonly NodeId UadpDataSetReaderMessageDataType = new NodeId(15653u);

	public static readonly NodeId JsonNetworkMessageContentMask = new NodeId(15654u);

	public static readonly NodeId JsonWriterGroupMessageDataType = new NodeId(15657u);

	public static readonly NodeId JsonDataSetMessageContentMask = new NodeId(15658u);

	public static readonly NodeId JsonDataSetWriterMessageDataType = new NodeId(15664u);

	public static readonly NodeId JsonDataSetReaderMessageDataType = new NodeId(15665u);

	public static readonly NodeId DatagramConnectionTransportDataType = new NodeId(17467u);

	public static readonly NodeId DatagramWriterGroupTransportDataType = new NodeId(15532u);

	public static readonly NodeId BrokerConnectionTransportDataType = new NodeId(15007u);

	public static readonly NodeId BrokerTransportQualityOfService = new NodeId(15008u);

	public static readonly NodeId BrokerWriterGroupTransportDataType = new NodeId(15667u);

	public static readonly NodeId BrokerDataSetWriterTransportDataType = new NodeId(15669u);

	public static readonly NodeId BrokerDataSetReaderTransportDataType = new NodeId(15670u);

	public static readonly NodeId DiagnosticsLevel = new NodeId(19723u);

	public static readonly NodeId PubSubDiagnosticsCounterClassification = new NodeId(19730u);

	public static readonly NodeId AliasNameDataType = new NodeId(23468u);

	public static readonly NodeId Duplex = new NodeId(24210u);

	public static readonly NodeId InterfaceAdminStatus = new NodeId(24212u);

	public static readonly NodeId InterfaceOperStatus = new NodeId(24214u);

	public static readonly NodeId NegotiationStatus = new NodeId(24216u);

	public static readonly NodeId TsnFailureCode = new NodeId(24218u);

	public static readonly NodeId TsnStreamState = new NodeId(24220u);

	public static readonly NodeId TsnTalkerStatus = new NodeId(24222u);

	public static readonly NodeId TsnListenerStatus = new NodeId(24224u);

	public static readonly NodeId UnsignedRationalNumber = new NodeId(24107u);

	public static readonly NodeId IdType = new NodeId(256u);

	public static readonly NodeId NodeClass = new NodeId(257u);

	public static readonly NodeId PermissionType = new NodeId(94u);

	public static readonly NodeId AccessLevelType = new NodeId(15031u);

	public static readonly NodeId AccessLevelExType = new NodeId(15406u);

	public static readonly NodeId EventNotifierType = new NodeId(15033u);

	public static readonly NodeId AccessRestrictionType = new NodeId(95u);

	public static readonly NodeId RolePermissionType = new NodeId(96u);

	public static readonly NodeId DataTypeDefinition = new NodeId(97u);

	public static readonly NodeId StructureType = new NodeId(98u);

	public static readonly NodeId StructureField = new NodeId(101u);

	public static readonly NodeId StructureDefinition = new NodeId(99u);

	public static readonly NodeId EnumDefinition = new NodeId(100u);

	public static readonly NodeId Node = new NodeId(258u);

	public static readonly NodeId InstanceNode = new NodeId(11879u);

	public static readonly NodeId TypeNode = new NodeId(11880u);

	public static readonly NodeId ObjectNode = new NodeId(261u);

	public static readonly NodeId ObjectTypeNode = new NodeId(264u);

	public static readonly NodeId VariableNode = new NodeId(267u);

	public static readonly NodeId VariableTypeNode = new NodeId(270u);

	public static readonly NodeId ReferenceTypeNode = new NodeId(273u);

	public static readonly NodeId MethodNode = new NodeId(276u);

	public static readonly NodeId ViewNode = new NodeId(279u);

	public static readonly NodeId DataTypeNode = new NodeId(282u);

	public static readonly NodeId ReferenceNode = new NodeId(285u);

	public static readonly NodeId Argument = new NodeId(296u);

	public static readonly NodeId EnumValueType = new NodeId(7594u);

	public static readonly NodeId EnumField = new NodeId(102u);

	public static readonly NodeId OptionSet = new NodeId(12755u);

	public static readonly NodeId NormalizedString = new NodeId(12877u);

	public static readonly NodeId DecimalString = new NodeId(12878u);

	public static readonly NodeId DurationString = new NodeId(12879u);

	public static readonly NodeId TimeString = new NodeId(12880u);

	public static readonly NodeId DateString = new NodeId(12881u);

	public static readonly NodeId Duration = new NodeId(290u);

	public static readonly NodeId UtcTime = new NodeId(294u);

	public static readonly NodeId Time = new NodeId(292u);

	public static readonly NodeId Date = new NodeId(293u);

	public static readonly NodeId LocaleId = new NodeId(295u);

	public static readonly NodeId TimeZoneDataType = new NodeId(8912u);

	public static readonly NodeId Index = new NodeId(17588u);

	public static readonly NodeId IntegerId = new NodeId(288u);

	public static readonly NodeId ApplicationType = new NodeId(307u);

	public static readonly NodeId ApplicationDescription = new NodeId(308u);

	public static readonly NodeId RequestHeader = new NodeId(389u);

	public static readonly NodeId ResponseHeader = new NodeId(392u);

	public static readonly NodeId VersionTime = new NodeId(20998u);

	public static readonly NodeId ServiceFault = new NodeId(395u);

	public static readonly NodeId SessionlessInvokeRequestType = new NodeId(15901u);

	public static readonly NodeId SessionlessInvokeResponseType = new NodeId(20999u);

	public static readonly NodeId FindServersRequest = new NodeId(420u);

	public static readonly NodeId FindServersResponse = new NodeId(423u);

	public static readonly NodeId ServerOnNetwork = new NodeId(12189u);

	public static readonly NodeId FindServersOnNetworkRequest = new NodeId(12190u);

	public static readonly NodeId FindServersOnNetworkResponse = new NodeId(12191u);

	public static readonly NodeId ApplicationInstanceCertificate = new NodeId(311u);

	public static readonly NodeId MessageSecurityMode = new NodeId(302u);

	public static readonly NodeId UserTokenType = new NodeId(303u);

	public static readonly NodeId UserTokenPolicy = new NodeId(304u);

	public static readonly NodeId EndpointDescription = new NodeId(312u);

	public static readonly NodeId GetEndpointsRequest = new NodeId(426u);

	public static readonly NodeId GetEndpointsResponse = new NodeId(429u);

	public static readonly NodeId RegisteredServer = new NodeId(432u);

	public static readonly NodeId RegisterServerRequest = new NodeId(435u);

	public static readonly NodeId RegisterServerResponse = new NodeId(438u);

	public static readonly NodeId DiscoveryConfiguration = new NodeId(12890u);

	public static readonly NodeId MdnsDiscoveryConfiguration = new NodeId(12891u);

	public static readonly NodeId RegisterServer2Request = new NodeId(12193u);

	public static readonly NodeId RegisterServer2Response = new NodeId(12194u);

	public static readonly NodeId SecurityTokenRequestType = new NodeId(315u);

	public static readonly NodeId ChannelSecurityToken = new NodeId(441u);

	public static readonly NodeId OpenSecureChannelRequest = new NodeId(444u);

	public static readonly NodeId OpenSecureChannelResponse = new NodeId(447u);

	public static readonly NodeId CloseSecureChannelRequest = new NodeId(450u);

	public static readonly NodeId CloseSecureChannelResponse = new NodeId(453u);

	public static readonly NodeId SignedSoftwareCertificate = new NodeId(344u);

	public static readonly NodeId SessionAuthenticationToken = new NodeId(388u);

	public static readonly NodeId SignatureData = new NodeId(456u);

	public static readonly NodeId CreateSessionRequest = new NodeId(459u);

	public static readonly NodeId CreateSessionResponse = new NodeId(462u);

	public static readonly NodeId UserIdentityToken = new NodeId(316u);

	public static readonly NodeId AnonymousIdentityToken = new NodeId(319u);

	public static readonly NodeId UserNameIdentityToken = new NodeId(322u);

	public static readonly NodeId X509IdentityToken = new NodeId(325u);

	public static readonly NodeId IssuedIdentityToken = new NodeId(938u);

	public static readonly NodeId RsaEncryptedSecret = new NodeId(17545u);

	public static readonly NodeId EccEncryptedSecret = new NodeId(17546u);

	public static readonly NodeId ActivateSessionRequest = new NodeId(465u);

	public static readonly NodeId ActivateSessionResponse = new NodeId(468u);

	public static readonly NodeId CloseSessionRequest = new NodeId(471u);

	public static readonly NodeId CloseSessionResponse = new NodeId(474u);

	public static readonly NodeId CancelRequest = new NodeId(477u);

	public static readonly NodeId CancelResponse = new NodeId(480u);

	public static readonly NodeId NodeAttributesMask = new NodeId(348u);

	public static readonly NodeId NodeAttributes = new NodeId(349u);

	public static readonly NodeId ObjectAttributes = new NodeId(352u);

	public static readonly NodeId VariableAttributes = new NodeId(355u);

	public static readonly NodeId MethodAttributes = new NodeId(358u);

	public static readonly NodeId ObjectTypeAttributes = new NodeId(361u);

	public static readonly NodeId VariableTypeAttributes = new NodeId(364u);

	public static readonly NodeId ReferenceTypeAttributes = new NodeId(367u);

	public static readonly NodeId DataTypeAttributes = new NodeId(370u);

	public static readonly NodeId ViewAttributes = new NodeId(373u);

	public static readonly NodeId GenericAttributeValue = new NodeId(17606u);

	public static readonly NodeId GenericAttributes = new NodeId(17607u);

	public static readonly NodeId AddNodesItem = new NodeId(376u);

	public static readonly NodeId AddNodesResult = new NodeId(483u);

	public static readonly NodeId AddNodesRequest = new NodeId(486u);

	public static readonly NodeId AddNodesResponse = new NodeId(489u);

	public static readonly NodeId AddReferencesItem = new NodeId(379u);

	public static readonly NodeId AddReferencesRequest = new NodeId(492u);

	public static readonly NodeId AddReferencesResponse = new NodeId(495u);

	public static readonly NodeId DeleteNodesItem = new NodeId(382u);

	public static readonly NodeId DeleteNodesRequest = new NodeId(498u);

	public static readonly NodeId DeleteNodesResponse = new NodeId(501u);

	public static readonly NodeId DeleteReferencesItem = new NodeId(385u);

	public static readonly NodeId DeleteReferencesRequest = new NodeId(504u);

	public static readonly NodeId DeleteReferencesResponse = new NodeId(507u);

	public static readonly NodeId AttributeWriteMask = new NodeId(347u);

	public static readonly NodeId BrowseDirection = new NodeId(510u);

	public static readonly NodeId ViewDescription = new NodeId(511u);

	public static readonly NodeId BrowseDescription = new NodeId(514u);

	public static readonly NodeId BrowseResultMask = new NodeId(517u);

	public static readonly NodeId ReferenceDescription = new NodeId(518u);

	public static readonly NodeId ContinuationPoint = new NodeId(521u);

	public static readonly NodeId BrowseResult = new NodeId(522u);

	public static readonly NodeId BrowseRequest = new NodeId(525u);

	public static readonly NodeId BrowseResponse = new NodeId(528u);

	public static readonly NodeId BrowseNextRequest = new NodeId(531u);

	public static readonly NodeId BrowseNextResponse = new NodeId(534u);

	public static readonly NodeId RelativePathElement = new NodeId(537u);

	public static readonly NodeId RelativePath = new NodeId(540u);

	public static readonly NodeId BrowsePath = new NodeId(543u);

	public static readonly NodeId BrowsePathTarget = new NodeId(546u);

	public static readonly NodeId BrowsePathResult = new NodeId(549u);

	public static readonly NodeId TranslateBrowsePathsToNodeIdsRequest = new NodeId(552u);

	public static readonly NodeId TranslateBrowsePathsToNodeIdsResponse = new NodeId(555u);

	public static readonly NodeId RegisterNodesRequest = new NodeId(558u);

	public static readonly NodeId RegisterNodesResponse = new NodeId(561u);

	public static readonly NodeId UnregisterNodesRequest = new NodeId(564u);

	public static readonly NodeId UnregisterNodesResponse = new NodeId(567u);

	public static readonly NodeId Counter = new NodeId(289u);

	public static readonly NodeId NumericRange = new NodeId(291u);

	public static readonly NodeId EndpointConfiguration = new NodeId(331u);

	public static readonly NodeId QueryDataDescription = new NodeId(570u);

	public static readonly NodeId NodeTypeDescription = new NodeId(573u);

	public static readonly NodeId FilterOperator = new NodeId(576u);

	public static readonly NodeId QueryDataSet = new NodeId(577u);

	public static readonly NodeId NodeReference = new NodeId(580u);

	public static readonly NodeId ContentFilterElement = new NodeId(583u);

	public static readonly NodeId ContentFilter = new NodeId(586u);

	public static readonly NodeId FilterOperand = new NodeId(589u);

	public static readonly NodeId ElementOperand = new NodeId(592u);

	public static readonly NodeId LiteralOperand = new NodeId(595u);

	public static readonly NodeId AttributeOperand = new NodeId(598u);

	public static readonly NodeId SimpleAttributeOperand = new NodeId(601u);

	public static readonly NodeId ContentFilterElementResult = new NodeId(604u);

	public static readonly NodeId ContentFilterResult = new NodeId(607u);

	public static readonly NodeId ParsingResult = new NodeId(610u);

	public static readonly NodeId QueryFirstRequest = new NodeId(613u);

	public static readonly NodeId QueryFirstResponse = new NodeId(616u);

	public static readonly NodeId QueryNextRequest = new NodeId(619u);

	public static readonly NodeId QueryNextResponse = new NodeId(622u);

	public static readonly NodeId TimestampsToReturn = new NodeId(625u);

	public static readonly NodeId ReadValueId = new NodeId(626u);

	public static readonly NodeId ReadRequest = new NodeId(629u);

	public static readonly NodeId ReadResponse = new NodeId(632u);

	public static readonly NodeId HistoryReadValueId = new NodeId(635u);

	public static readonly NodeId HistoryReadResult = new NodeId(638u);

	public static readonly NodeId HistoryReadDetails = new NodeId(641u);

	public static readonly NodeId ReadEventDetails = new NodeId(644u);

	public static readonly NodeId ReadRawModifiedDetails = new NodeId(647u);

	public static readonly NodeId ReadProcessedDetails = new NodeId(650u);

	public static readonly NodeId ReadAtTimeDetails = new NodeId(653u);

	public static readonly NodeId ReadAnnotationDataDetails = new NodeId(23497u);

	public static readonly NodeId HistoryData = new NodeId(656u);

	public static readonly NodeId ModificationInfo = new NodeId(11216u);

	public static readonly NodeId HistoryModifiedData = new NodeId(11217u);

	public static readonly NodeId HistoryEvent = new NodeId(659u);

	public static readonly NodeId HistoryReadRequest = new NodeId(662u);

	public static readonly NodeId HistoryReadResponse = new NodeId(665u);

	public static readonly NodeId WriteValue = new NodeId(668u);

	public static readonly NodeId WriteRequest = new NodeId(671u);

	public static readonly NodeId WriteResponse = new NodeId(674u);

	public static readonly NodeId HistoryUpdateDetails = new NodeId(677u);

	public static readonly NodeId HistoryUpdateType = new NodeId(11234u);

	public static readonly NodeId PerformUpdateType = new NodeId(11293u);

	public static readonly NodeId UpdateDataDetails = new NodeId(680u);

	public static readonly NodeId UpdateStructureDataDetails = new NodeId(11295u);

	public static readonly NodeId UpdateEventDetails = new NodeId(683u);

	public static readonly NodeId DeleteRawModifiedDetails = new NodeId(686u);

	public static readonly NodeId DeleteAtTimeDetails = new NodeId(689u);

	public static readonly NodeId DeleteEventDetails = new NodeId(692u);

	public static readonly NodeId HistoryUpdateResult = new NodeId(695u);

	public static readonly NodeId HistoryUpdateRequest = new NodeId(698u);

	public static readonly NodeId HistoryUpdateResponse = new NodeId(701u);

	public static readonly NodeId CallMethodRequest = new NodeId(704u);

	public static readonly NodeId CallMethodResult = new NodeId(707u);

	public static readonly NodeId CallRequest = new NodeId(710u);

	public static readonly NodeId CallResponse = new NodeId(713u);

	public static readonly NodeId MonitoringMode = new NodeId(716u);

	public static readonly NodeId DataChangeTrigger = new NodeId(717u);

	public static readonly NodeId DeadbandType = new NodeId(718u);

	public static readonly NodeId MonitoringFilter = new NodeId(719u);

	public static readonly NodeId DataChangeFilter = new NodeId(722u);

	public static readonly NodeId EventFilter = new NodeId(725u);

	public static readonly NodeId AggregateConfiguration = new NodeId(948u);

	public static readonly NodeId AggregateFilter = new NodeId(728u);

	public static readonly NodeId MonitoringFilterResult = new NodeId(731u);

	public static readonly NodeId EventFilterResult = new NodeId(734u);

	public static readonly NodeId AggregateFilterResult = new NodeId(737u);

	public static readonly NodeId MonitoringParameters = new NodeId(740u);

	public static readonly NodeId MonitoredItemCreateRequest = new NodeId(743u);

	public static readonly NodeId MonitoredItemCreateResult = new NodeId(746u);

	public static readonly NodeId CreateMonitoredItemsRequest = new NodeId(749u);

	public static readonly NodeId CreateMonitoredItemsResponse = new NodeId(752u);

	public static readonly NodeId MonitoredItemModifyRequest = new NodeId(755u);

	public static readonly NodeId MonitoredItemModifyResult = new NodeId(758u);

	public static readonly NodeId ModifyMonitoredItemsRequest = new NodeId(761u);

	public static readonly NodeId ModifyMonitoredItemsResponse = new NodeId(764u);

	public static readonly NodeId SetMonitoringModeRequest = new NodeId(767u);

	public static readonly NodeId SetMonitoringModeResponse = new NodeId(770u);

	public static readonly NodeId SetTriggeringRequest = new NodeId(773u);

	public static readonly NodeId SetTriggeringResponse = new NodeId(776u);

	public static readonly NodeId DeleteMonitoredItemsRequest = new NodeId(779u);

	public static readonly NodeId DeleteMonitoredItemsResponse = new NodeId(782u);

	public static readonly NodeId CreateSubscriptionRequest = new NodeId(785u);

	public static readonly NodeId CreateSubscriptionResponse = new NodeId(788u);

	public static readonly NodeId ModifySubscriptionRequest = new NodeId(791u);

	public static readonly NodeId ModifySubscriptionResponse = new NodeId(794u);

	public static readonly NodeId SetPublishingModeRequest = new NodeId(797u);

	public static readonly NodeId SetPublishingModeResponse = new NodeId(800u);

	public static readonly NodeId NotificationMessage = new NodeId(803u);

	public static readonly NodeId NotificationData = new NodeId(945u);

	public static readonly NodeId DataChangeNotification = new NodeId(809u);

	public static readonly NodeId MonitoredItemNotification = new NodeId(806u);

	public static readonly NodeId EventNotificationList = new NodeId(914u);

	public static readonly NodeId EventFieldList = new NodeId(917u);

	public static readonly NodeId HistoryEventFieldList = new NodeId(920u);

	public static readonly NodeId StatusChangeNotification = new NodeId(818u);

	public static readonly NodeId SubscriptionAcknowledgement = new NodeId(821u);

	public static readonly NodeId PublishRequest = new NodeId(824u);

	public static readonly NodeId PublishResponse = new NodeId(827u);

	public static readonly NodeId RepublishRequest = new NodeId(830u);

	public static readonly NodeId RepublishResponse = new NodeId(833u);

	public static readonly NodeId TransferResult = new NodeId(836u);

	public static readonly NodeId TransferSubscriptionsRequest = new NodeId(839u);

	public static readonly NodeId TransferSubscriptionsResponse = new NodeId(842u);

	public static readonly NodeId DeleteSubscriptionsRequest = new NodeId(845u);

	public static readonly NodeId DeleteSubscriptionsResponse = new NodeId(848u);

	public static readonly NodeId BuildInfo = new NodeId(338u);

	public static readonly NodeId RedundancySupport = new NodeId(851u);

	public static readonly NodeId ServerState = new NodeId(852u);

	public static readonly NodeId RedundantServerDataType = new NodeId(853u);

	public static readonly NodeId EndpointUrlListDataType = new NodeId(11943u);

	public static readonly NodeId NetworkGroupDataType = new NodeId(11944u);

	public static readonly NodeId SamplingIntervalDiagnosticsDataType = new NodeId(856u);

	public static readonly NodeId ServerDiagnosticsSummaryDataType = new NodeId(859u);

	public static readonly NodeId ServerStatusDataType = new NodeId(862u);

	public static readonly NodeId SessionDiagnosticsDataType = new NodeId(865u);

	public static readonly NodeId SessionSecurityDiagnosticsDataType = new NodeId(868u);

	public static readonly NodeId ServiceCounterDataType = new NodeId(871u);

	public static readonly NodeId StatusResult = new NodeId(299u);

	public static readonly NodeId SubscriptionDiagnosticsDataType = new NodeId(874u);

	public static readonly NodeId ModelChangeStructureVerbMask = new NodeId(11941u);

	public static readonly NodeId ModelChangeStructureDataType = new NodeId(877u);

	public static readonly NodeId SemanticChangeStructureDataType = new NodeId(897u);

	public static readonly NodeId Range = new NodeId(884u);

	public static readonly NodeId EUInformation = new NodeId(887u);

	public static readonly NodeId AxisScaleEnumeration = new NodeId(12077u);

	public static readonly NodeId ComplexNumberType = new NodeId(12171u);

	public static readonly NodeId DoubleComplexNumberType = new NodeId(12172u);

	public static readonly NodeId AxisInformation = new NodeId(12079u);

	public static readonly NodeId XVType = new NodeId(12080u);

	public static readonly NodeId ProgramDiagnosticDataType = new NodeId(894u);

	public static readonly NodeId ProgramDiagnostic2DataType = new NodeId(24033u);

	public static readonly NodeId Annotation = new NodeId(891u);

	public static readonly NodeId ExceptionDeviationFormat = new NodeId(890u);
}
