using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class DataTypes
{
	public const uint BaseDataType = 24u;

	public const uint Number = 26u;

	public const uint Integer = 27u;

	public const uint UInteger = 28u;

	public const uint Enumeration = 29u;

	public const uint Boolean = 1u;

	public const uint SByte = 2u;

	public const uint Byte = 3u;

	public const uint Int16 = 4u;

	public const uint UInt16 = 5u;

	public const uint Int32 = 6u;

	public const uint UInt32 = 7u;

	public const uint Int64 = 8u;

	public const uint UInt64 = 9u;

	public const uint Float = 10u;

	public const uint Double = 11u;

	public const uint String = 12u;

	public const uint DateTime = 13u;

	public const uint Guid = 14u;

	public const uint ByteString = 15u;

	public const uint XmlElement = 16u;

	public const uint NodeId = 17u;

	public const uint ExpandedNodeId = 18u;

	public const uint StatusCode = 19u;

	public const uint QualifiedName = 20u;

	public const uint LocalizedText = 21u;

	public const uint Structure = 22u;

	public const uint DataValue = 23u;

	public const uint DiagnosticInfo = 25u;

	public const uint Image = 30u;

	public const uint Decimal = 50u;

	public const uint NamingRuleType = 120u;

	public const uint ImageBMP = 2000u;

	public const uint ImageGIF = 2001u;

	public const uint ImageJPG = 2002u;

	public const uint ImagePNG = 2003u;

	public const uint AudioDataType = 16307u;

	public const uint Union = 12756u;

	public const uint BitFieldMaskDataType = 11737u;

	public const uint KeyValuePair = 14533u;

	public const uint AdditionalParametersType = 16313u;

	public const uint EphemeralKeyType = 17548u;

	public const uint EndpointType = 15528u;

	public const uint RationalNumber = 18806u;

	public const uint Vector = 18807u;

	public const uint ThreeDVector = 18808u;

	public const uint CartesianCoordinates = 18809u;

	public const uint ThreeDCartesianCoordinates = 18810u;

	public const uint Orientation = 18811u;

	public const uint ThreeDOrientation = 18812u;

	public const uint Frame = 18813u;

	public const uint ThreeDFrame = 18814u;

	public const uint OpenFileMode = 11939u;

	public const uint IdentityCriteriaType = 15632u;

	public const uint IdentityMappingRuleType = 15634u;

	public const uint CurrencyUnitType = 23498u;

	public const uint TrustListMasks = 12552u;

	public const uint TrustListDataType = 12554u;

	public const uint DecimalDataType = 17861u;

	public const uint DataTypeSchemaHeader = 15534u;

	public const uint DataTypeDescription = 14525u;

	public const uint StructureDescription = 15487u;

	public const uint EnumDescription = 15488u;

	public const uint SimpleTypeDescription = 15005u;

	public const uint UABinaryFileDataType = 15006u;

	public const uint PubSubState = 14647u;

	public const uint DataSetMetaDataType = 14523u;

	public const uint FieldMetaData = 14524u;

	public const uint DataSetFieldFlags = 15904u;

	public const uint ConfigurationVersionDataType = 14593u;

	public const uint PublishedDataSetDataType = 15578u;

	public const uint PublishedDataSetSourceDataType = 15580u;

	public const uint PublishedVariableDataType = 14273u;

	public const uint PublishedDataItemsDataType = 15581u;

	public const uint PublishedEventsDataType = 15582u;

	public const uint DataSetFieldContentMask = 15583u;

	public const uint DataSetWriterDataType = 15597u;

	public const uint DataSetWriterTransportDataType = 15598u;

	public const uint DataSetWriterMessageDataType = 15605u;

	public const uint PubSubGroupDataType = 15609u;

	public const uint WriterGroupDataType = 15480u;

	public const uint WriterGroupTransportDataType = 15611u;

	public const uint WriterGroupMessageDataType = 15616u;

	public const uint PubSubConnectionDataType = 15617u;

	public const uint ConnectionTransportDataType = 15618u;

	public const uint NetworkAddressDataType = 15502u;

	public const uint NetworkAddressUrlDataType = 15510u;

	public const uint ReaderGroupDataType = 15520u;

	public const uint ReaderGroupTransportDataType = 15621u;

	public const uint ReaderGroupMessageDataType = 15622u;

	public const uint DataSetReaderDataType = 15623u;

	public const uint DataSetReaderTransportDataType = 15628u;

	public const uint DataSetReaderMessageDataType = 15629u;

	public const uint SubscribedDataSetDataType = 15630u;

	public const uint TargetVariablesDataType = 15631u;

	public const uint FieldTargetDataType = 14744u;

	public const uint OverrideValueHandling = 15874u;

	public const uint SubscribedDataSetMirrorDataType = 15635u;

	public const uint PubSubConfigurationDataType = 15530u;

	public const uint DataSetOrderingType = 20408u;

	public const uint UadpNetworkMessageContentMask = 15642u;

	public const uint UadpWriterGroupMessageDataType = 15645u;

	public const uint UadpDataSetMessageContentMask = 15646u;

	public const uint UadpDataSetWriterMessageDataType = 15652u;

	public const uint UadpDataSetReaderMessageDataType = 15653u;

	public const uint JsonNetworkMessageContentMask = 15654u;

	public const uint JsonWriterGroupMessageDataType = 15657u;

	public const uint JsonDataSetMessageContentMask = 15658u;

	public const uint JsonDataSetWriterMessageDataType = 15664u;

	public const uint JsonDataSetReaderMessageDataType = 15665u;

	public const uint DatagramConnectionTransportDataType = 17467u;

	public const uint DatagramWriterGroupTransportDataType = 15532u;

	public const uint BrokerConnectionTransportDataType = 15007u;

	public const uint BrokerTransportQualityOfService = 15008u;

	public const uint BrokerWriterGroupTransportDataType = 15667u;

	public const uint BrokerDataSetWriterTransportDataType = 15669u;

	public const uint BrokerDataSetReaderTransportDataType = 15670u;

	public const uint DiagnosticsLevel = 19723u;

	public const uint PubSubDiagnosticsCounterClassification = 19730u;

	public const uint AliasNameDataType = 23468u;

	public const uint Duplex = 24210u;

	public const uint InterfaceAdminStatus = 24212u;

	public const uint InterfaceOperStatus = 24214u;

	public const uint NegotiationStatus = 24216u;

	public const uint TsnFailureCode = 24218u;

	public const uint TsnStreamState = 24220u;

	public const uint TsnTalkerStatus = 24222u;

	public const uint TsnListenerStatus = 24224u;

	public const uint UnsignedRationalNumber = 24107u;

	public const uint IdType = 256u;

	public const uint NodeClass = 257u;

	public const uint PermissionType = 94u;

	public const uint AccessLevelType = 15031u;

	public const uint AccessLevelExType = 15406u;

	public const uint EventNotifierType = 15033u;

	public const uint AccessRestrictionType = 95u;

	public const uint RolePermissionType = 96u;

	public const uint DataTypeDefinition = 97u;

	public const uint StructureType = 98u;

	public const uint StructureField = 101u;

	public const uint StructureDefinition = 99u;

	public const uint EnumDefinition = 100u;

	public const uint Node = 258u;

	public const uint InstanceNode = 11879u;

	public const uint TypeNode = 11880u;

	public const uint ObjectNode = 261u;

	public const uint ObjectTypeNode = 264u;

	public const uint VariableNode = 267u;

	public const uint VariableTypeNode = 270u;

	public const uint ReferenceTypeNode = 273u;

	public const uint MethodNode = 276u;

	public const uint ViewNode = 279u;

	public const uint DataTypeNode = 282u;

	public const uint ReferenceNode = 285u;

	public const uint Argument = 296u;

	public const uint EnumValueType = 7594u;

	public const uint EnumField = 102u;

	public const uint OptionSet = 12755u;

	public const uint NormalizedString = 12877u;

	public const uint DecimalString = 12878u;

	public const uint DurationString = 12879u;

	public const uint TimeString = 12880u;

	public const uint DateString = 12881u;

	public const uint Duration = 290u;

	public const uint UtcTime = 294u;

	public const uint Time = 292u;

	public const uint Date = 293u;

	public const uint LocaleId = 295u;

	public const uint TimeZoneDataType = 8912u;

	public const uint Index = 17588u;

	public const uint IntegerId = 288u;

	public const uint ApplicationType = 307u;

	public const uint ApplicationDescription = 308u;

	public const uint RequestHeader = 389u;

	public const uint ResponseHeader = 392u;

	public const uint VersionTime = 20998u;

	public const uint ServiceFault = 395u;

	public const uint SessionlessInvokeRequestType = 15901u;

	public const uint SessionlessInvokeResponseType = 20999u;

	public const uint FindServersRequest = 420u;

	public const uint FindServersResponse = 423u;

	public const uint ServerOnNetwork = 12189u;

	public const uint FindServersOnNetworkRequest = 12190u;

	public const uint FindServersOnNetworkResponse = 12191u;

	public const uint ApplicationInstanceCertificate = 311u;

	public const uint MessageSecurityMode = 302u;

	public const uint UserTokenType = 303u;

	public const uint UserTokenPolicy = 304u;

	public const uint EndpointDescription = 312u;

	public const uint GetEndpointsRequest = 426u;

	public const uint GetEndpointsResponse = 429u;

	public const uint RegisteredServer = 432u;

	public const uint RegisterServerRequest = 435u;

	public const uint RegisterServerResponse = 438u;

	public const uint DiscoveryConfiguration = 12890u;

	public const uint MdnsDiscoveryConfiguration = 12891u;

	public const uint RegisterServer2Request = 12193u;

	public const uint RegisterServer2Response = 12194u;

	public const uint SecurityTokenRequestType = 315u;

	public const uint ChannelSecurityToken = 441u;

	public const uint OpenSecureChannelRequest = 444u;

	public const uint OpenSecureChannelResponse = 447u;

	public const uint CloseSecureChannelRequest = 450u;

	public const uint CloseSecureChannelResponse = 453u;

	public const uint SignedSoftwareCertificate = 344u;

	public const uint SessionAuthenticationToken = 388u;

	public const uint SignatureData = 456u;

	public const uint CreateSessionRequest = 459u;

	public const uint CreateSessionResponse = 462u;

	public const uint UserIdentityToken = 316u;

	public const uint AnonymousIdentityToken = 319u;

	public const uint UserNameIdentityToken = 322u;

	public const uint X509IdentityToken = 325u;

	public const uint IssuedIdentityToken = 938u;

	public const uint RsaEncryptedSecret = 17545u;

	public const uint EccEncryptedSecret = 17546u;

	public const uint ActivateSessionRequest = 465u;

	public const uint ActivateSessionResponse = 468u;

	public const uint CloseSessionRequest = 471u;

	public const uint CloseSessionResponse = 474u;

	public const uint CancelRequest = 477u;

	public const uint CancelResponse = 480u;

	public const uint NodeAttributesMask = 348u;

	public const uint NodeAttributes = 349u;

	public const uint ObjectAttributes = 352u;

	public const uint VariableAttributes = 355u;

	public const uint MethodAttributes = 358u;

	public const uint ObjectTypeAttributes = 361u;

	public const uint VariableTypeAttributes = 364u;

	public const uint ReferenceTypeAttributes = 367u;

	public const uint DataTypeAttributes = 370u;

	public const uint ViewAttributes = 373u;

	public const uint GenericAttributeValue = 17606u;

	public const uint GenericAttributes = 17607u;

	public const uint AddNodesItem = 376u;

	public const uint AddNodesResult = 483u;

	public const uint AddNodesRequest = 486u;

	public const uint AddNodesResponse = 489u;

	public const uint AddReferencesItem = 379u;

	public const uint AddReferencesRequest = 492u;

	public const uint AddReferencesResponse = 495u;

	public const uint DeleteNodesItem = 382u;

	public const uint DeleteNodesRequest = 498u;

	public const uint DeleteNodesResponse = 501u;

	public const uint DeleteReferencesItem = 385u;

	public const uint DeleteReferencesRequest = 504u;

	public const uint DeleteReferencesResponse = 507u;

	public const uint AttributeWriteMask = 347u;

	public const uint BrowseDirection = 510u;

	public const uint ViewDescription = 511u;

	public const uint BrowseDescription = 514u;

	public const uint BrowseResultMask = 517u;

	public const uint ReferenceDescription = 518u;

	public const uint ContinuationPoint = 521u;

	public const uint BrowseResult = 522u;

	public const uint BrowseRequest = 525u;

	public const uint BrowseResponse = 528u;

	public const uint BrowseNextRequest = 531u;

	public const uint BrowseNextResponse = 534u;

	public const uint RelativePathElement = 537u;

	public const uint RelativePath = 540u;

	public const uint BrowsePath = 543u;

	public const uint BrowsePathTarget = 546u;

	public const uint BrowsePathResult = 549u;

	public const uint TranslateBrowsePathsToNodeIdsRequest = 552u;

	public const uint TranslateBrowsePathsToNodeIdsResponse = 555u;

	public const uint RegisterNodesRequest = 558u;

	public const uint RegisterNodesResponse = 561u;

	public const uint UnregisterNodesRequest = 564u;

	public const uint UnregisterNodesResponse = 567u;

	public const uint Counter = 289u;

	public const uint NumericRange = 291u;

	public const uint EndpointConfiguration = 331u;

	public const uint QueryDataDescription = 570u;

	public const uint NodeTypeDescription = 573u;

	public const uint FilterOperator = 576u;

	public const uint QueryDataSet = 577u;

	public const uint NodeReference = 580u;

	public const uint ContentFilterElement = 583u;

	public const uint ContentFilter = 586u;

	public const uint FilterOperand = 589u;

	public const uint ElementOperand = 592u;

	public const uint LiteralOperand = 595u;

	public const uint AttributeOperand = 598u;

	public const uint SimpleAttributeOperand = 601u;

	public const uint ContentFilterElementResult = 604u;

	public const uint ContentFilterResult = 607u;

	public const uint ParsingResult = 610u;

	public const uint QueryFirstRequest = 613u;

	public const uint QueryFirstResponse = 616u;

	public const uint QueryNextRequest = 619u;

	public const uint QueryNextResponse = 622u;

	public const uint TimestampsToReturn = 625u;

	public const uint ReadValueId = 626u;

	public const uint ReadRequest = 629u;

	public const uint ReadResponse = 632u;

	public const uint HistoryReadValueId = 635u;

	public const uint HistoryReadResult = 638u;

	public const uint HistoryReadDetails = 641u;

	public const uint ReadEventDetails = 644u;

	public const uint ReadRawModifiedDetails = 647u;

	public const uint ReadProcessedDetails = 650u;

	public const uint ReadAtTimeDetails = 653u;

	public const uint ReadAnnotationDataDetails = 23497u;

	public const uint HistoryData = 656u;

	public const uint ModificationInfo = 11216u;

	public const uint HistoryModifiedData = 11217u;

	public const uint HistoryEvent = 659u;

	public const uint HistoryReadRequest = 662u;

	public const uint HistoryReadResponse = 665u;

	public const uint WriteValue = 668u;

	public const uint WriteRequest = 671u;

	public const uint WriteResponse = 674u;

	public const uint HistoryUpdateDetails = 677u;

	public const uint HistoryUpdateType = 11234u;

	public const uint PerformUpdateType = 11293u;

	public const uint UpdateDataDetails = 680u;

	public const uint UpdateStructureDataDetails = 11295u;

	public const uint UpdateEventDetails = 683u;

	public const uint DeleteRawModifiedDetails = 686u;

	public const uint DeleteAtTimeDetails = 689u;

	public const uint DeleteEventDetails = 692u;

	public const uint HistoryUpdateResult = 695u;

	public const uint HistoryUpdateRequest = 698u;

	public const uint HistoryUpdateResponse = 701u;

	public const uint CallMethodRequest = 704u;

	public const uint CallMethodResult = 707u;

	public const uint CallRequest = 710u;

	public const uint CallResponse = 713u;

	public const uint MonitoringMode = 716u;

	public const uint DataChangeTrigger = 717u;

	public const uint DeadbandType = 718u;

	public const uint MonitoringFilter = 719u;

	public const uint DataChangeFilter = 722u;

	public const uint EventFilter = 725u;

	public const uint AggregateConfiguration = 948u;

	public const uint AggregateFilter = 728u;

	public const uint MonitoringFilterResult = 731u;

	public const uint EventFilterResult = 734u;

	public const uint AggregateFilterResult = 737u;

	public const uint MonitoringParameters = 740u;

	public const uint MonitoredItemCreateRequest = 743u;

	public const uint MonitoredItemCreateResult = 746u;

	public const uint CreateMonitoredItemsRequest = 749u;

	public const uint CreateMonitoredItemsResponse = 752u;

	public const uint MonitoredItemModifyRequest = 755u;

	public const uint MonitoredItemModifyResult = 758u;

	public const uint ModifyMonitoredItemsRequest = 761u;

	public const uint ModifyMonitoredItemsResponse = 764u;

	public const uint SetMonitoringModeRequest = 767u;

	public const uint SetMonitoringModeResponse = 770u;

	public const uint SetTriggeringRequest = 773u;

	public const uint SetTriggeringResponse = 776u;

	public const uint DeleteMonitoredItemsRequest = 779u;

	public const uint DeleteMonitoredItemsResponse = 782u;

	public const uint CreateSubscriptionRequest = 785u;

	public const uint CreateSubscriptionResponse = 788u;

	public const uint ModifySubscriptionRequest = 791u;

	public const uint ModifySubscriptionResponse = 794u;

	public const uint SetPublishingModeRequest = 797u;

	public const uint SetPublishingModeResponse = 800u;

	public const uint NotificationMessage = 803u;

	public const uint NotificationData = 945u;

	public const uint DataChangeNotification = 809u;

	public const uint MonitoredItemNotification = 806u;

	public const uint EventNotificationList = 914u;

	public const uint EventFieldList = 917u;

	public const uint HistoryEventFieldList = 920u;

	public const uint StatusChangeNotification = 818u;

	public const uint SubscriptionAcknowledgement = 821u;

	public const uint PublishRequest = 824u;

	public const uint PublishResponse = 827u;

	public const uint RepublishRequest = 830u;

	public const uint RepublishResponse = 833u;

	public const uint TransferResult = 836u;

	public const uint TransferSubscriptionsRequest = 839u;

	public const uint TransferSubscriptionsResponse = 842u;

	public const uint DeleteSubscriptionsRequest = 845u;

	public const uint DeleteSubscriptionsResponse = 848u;

	public const uint BuildInfo = 338u;

	public const uint RedundancySupport = 851u;

	public const uint ServerState = 852u;

	public const uint RedundantServerDataType = 853u;

	public const uint EndpointUrlListDataType = 11943u;

	public const uint NetworkGroupDataType = 11944u;

	public const uint SamplingIntervalDiagnosticsDataType = 856u;

	public const uint ServerDiagnosticsSummaryDataType = 859u;

	public const uint ServerStatusDataType = 862u;

	public const uint SessionDiagnosticsDataType = 865u;

	public const uint SessionSecurityDiagnosticsDataType = 868u;

	public const uint ServiceCounterDataType = 871u;

	public const uint StatusResult = 299u;

	public const uint SubscriptionDiagnosticsDataType = 874u;

	public const uint ModelChangeStructureVerbMask = 11941u;

	public const uint ModelChangeStructureDataType = 877u;

	public const uint SemanticChangeStructureDataType = 897u;

	public const uint Range = 884u;

	public const uint EUInformation = 887u;

	public const uint AxisScaleEnumeration = 12077u;

	public const uint ComplexNumberType = 12171u;

	public const uint DoubleComplexNumberType = 12172u;

	public const uint AxisInformation = 12079u;

	public const uint XVType = 12080u;

	public const uint ProgramDiagnosticDataType = 894u;

	public const uint ProgramDiagnostic2DataType = 24033u;

	public const uint Annotation = 891u;

	public const uint ExceptionDeviationFormat = 890u;

	public static string GetBrowseName(int identifier)
	{
		FieldInfo[] fields = typeof(DataTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (identifier == (uint)fieldInfo.GetValue(typeof(DataTypes)))
			{
				return fieldInfo.Name;
			}
		}
		return string.Empty;
	}

	public static string[] GetBrowseNames()
	{
		FieldInfo[] fields = typeof(DataTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
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
		FieldInfo[] fields = typeof(DataTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.Name == browseName)
			{
				return (uint)fieldInfo.GetValue(typeof(DataTypes));
			}
		}
		return 0u;
	}

	public static NodeId GetDataTypeId(object value)
	{
		return TypeInfo.GetDataTypeId(value);
	}

	public static NodeId GetDataTypeId(Type type)
	{
		return TypeInfo.GetDataTypeId(type);
	}

	public static NodeId GetDataTypeId(TypeInfo typeInfo)
	{
		return TypeInfo.GetDataTypeId(typeInfo);
	}

	public static int GetValueRank(object value)
	{
		return TypeInfo.GetValueRank(value);
	}

	public static int GetValueRank(Type type)
	{
		return TypeInfo.GetValueRank(type);
	}

	public static BuiltInType GetBuiltInType(NodeId datatypeId)
	{
		return TypeInfo.GetBuiltInType(datatypeId);
	}

	public static BuiltInType GetBuiltInType(NodeId datatypeId, ITypeTable typeTree)
	{
		return TypeInfo.GetBuiltInType(datatypeId, typeTree);
	}

	public static Type GetSystemType(NodeId datatypeId, IEncodeableFactory factory)
	{
		return TypeInfo.GetSystemType(datatypeId, factory);
	}
}
