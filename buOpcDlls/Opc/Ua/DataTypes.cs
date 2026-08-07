// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataTypes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class DataTypes
{
  public const uint BaseDataType = 24;
  public const uint Number = 26;
  public const uint Integer = 27;
  public const uint UInteger = 28;
  public const uint Enumeration = 29;
  public const uint Boolean = 1;
  public const uint SByte = 2;
  public const uint Byte = 3;
  public const uint Int16 = 4;
  public const uint UInt16 = 5;
  public const uint Int32 = 6;
  public const uint UInt32 = 7;
  public const uint Int64 = 8;
  public const uint UInt64 = 9;
  public const uint Float = 10;
  public const uint Double = 11;
  public const uint String = 12;
  public const uint DateTime = 13;
  public const uint Guid = 14;
  public const uint ByteString = 15;
  public const uint XmlElement = 16 /*0x10*/;
  public const uint NodeId = 17;
  public const uint ExpandedNodeId = 18;
  public const uint StatusCode = 19;
  public const uint QualifiedName = 20;
  public const uint LocalizedText = 21;
  public const uint Structure = 22;
  public const uint DataValue = 23;
  public const uint DiagnosticInfo = 25;
  public const uint Image = 30;
  public const uint Decimal = 50;
  public const uint NamingRuleType = 120;
  public const uint ImageBMP = 2000;
  public const uint ImageGIF = 2001;
  public const uint ImageJPG = 2002;
  public const uint ImagePNG = 2003;
  public const uint AudioDataType = 16307;
  public const uint Union = 12756;
  public const uint BitFieldMaskDataType = 11737;
  public const uint KeyValuePair = 14533;
  public const uint AdditionalParametersType = 16313;
  public const uint EphemeralKeyType = 17548;
  public const uint EndpointType = 15528;
  public const uint RationalNumber = 18806;
  public const uint Vector = 18807;
  public const uint ThreeDVector = 18808;
  public const uint CartesianCoordinates = 18809;
  public const uint ThreeDCartesianCoordinates = 18810;
  public const uint Orientation = 18811;
  public const uint ThreeDOrientation = 18812;
  public const uint Frame = 18813;
  public const uint ThreeDFrame = 18814;
  public const uint OpenFileMode = 11939;
  public const uint IdentityCriteriaType = 15632;
  public const uint IdentityMappingRuleType = 15634;
  public const uint CurrencyUnitType = 23498;
  public const uint TrustListMasks = 12552;
  public const uint TrustListDataType = 12554;
  public const uint DecimalDataType = 17861;
  public const uint DataTypeSchemaHeader = 15534;
  public const uint DataTypeDescription = 14525;
  public const uint StructureDescription = 15487;
  public const uint EnumDescription = 15488;
  public const uint SimpleTypeDescription = 15005;
  public const uint UABinaryFileDataType = 15006;
  public const uint PubSubState = 14647;
  public const uint DataSetMetaDataType = 14523;
  public const uint FieldMetaData = 14524;
  public const uint DataSetFieldFlags = 15904;
  public const uint ConfigurationVersionDataType = 14593;
  public const uint PublishedDataSetDataType = 15578;
  public const uint PublishedDataSetSourceDataType = 15580;
  public const uint PublishedVariableDataType = 14273;
  public const uint PublishedDataItemsDataType = 15581;
  public const uint PublishedEventsDataType = 15582;
  public const uint DataSetFieldContentMask = 15583;
  public const uint DataSetWriterDataType = 15597;
  public const uint DataSetWriterTransportDataType = 15598;
  public const uint DataSetWriterMessageDataType = 15605;
  public const uint PubSubGroupDataType = 15609;
  public const uint WriterGroupDataType = 15480;
  public const uint WriterGroupTransportDataType = 15611;
  public const uint WriterGroupMessageDataType = 15616;
  public const uint PubSubConnectionDataType = 15617;
  public const uint ConnectionTransportDataType = 15618;
  public const uint NetworkAddressDataType = 15502;
  public const uint NetworkAddressUrlDataType = 15510;
  public const uint ReaderGroupDataType = 15520;
  public const uint ReaderGroupTransportDataType = 15621;
  public const uint ReaderGroupMessageDataType = 15622;
  public const uint DataSetReaderDataType = 15623;
  public const uint DataSetReaderTransportDataType = 15628;
  public const uint DataSetReaderMessageDataType = 15629;
  public const uint SubscribedDataSetDataType = 15630;
  public const uint TargetVariablesDataType = 15631;
  public const uint FieldTargetDataType = 14744;
  public const uint OverrideValueHandling = 15874;
  public const uint SubscribedDataSetMirrorDataType = 15635;
  public const uint PubSubConfigurationDataType = 15530;
  public const uint DataSetOrderingType = 20408;
  public const uint UadpNetworkMessageContentMask = 15642;
  public const uint UadpWriterGroupMessageDataType = 15645;
  public const uint UadpDataSetMessageContentMask = 15646;
  public const uint UadpDataSetWriterMessageDataType = 15652;
  public const uint UadpDataSetReaderMessageDataType = 15653;
  public const uint JsonNetworkMessageContentMask = 15654;
  public const uint JsonWriterGroupMessageDataType = 15657;
  public const uint JsonDataSetMessageContentMask = 15658;
  public const uint JsonDataSetWriterMessageDataType = 15664;
  public const uint JsonDataSetReaderMessageDataType = 15665;
  public const uint DatagramConnectionTransportDataType = 17467;
  public const uint DatagramWriterGroupTransportDataType = 15532;
  public const uint BrokerConnectionTransportDataType = 15007;
  public const uint BrokerTransportQualityOfService = 15008;
  public const uint BrokerWriterGroupTransportDataType = 15667;
  public const uint BrokerDataSetWriterTransportDataType = 15669;
  public const uint BrokerDataSetReaderTransportDataType = 15670;
  public const uint DiagnosticsLevel = 19723;
  public const uint PubSubDiagnosticsCounterClassification = 19730;
  public const uint AliasNameDataType = 23468;
  public const uint Duplex = 24210;
  public const uint InterfaceAdminStatus = 24212;
  public const uint InterfaceOperStatus = 24214;
  public const uint NegotiationStatus = 24216;
  public const uint TsnFailureCode = 24218;
  public const uint TsnStreamState = 24220;
  public const uint TsnTalkerStatus = 24222;
  public const uint TsnListenerStatus = 24224;
  public const uint UnsignedRationalNumber = 24107;
  public const uint IdType = 256 /*0x0100*/;
  public const uint NodeClass = 257;
  public const uint PermissionType = 94;
  public const uint AccessLevelType = 15031;
  public const uint AccessLevelExType = 15406;
  public const uint EventNotifierType = 15033;
  public const uint AccessRestrictionType = 95;
  public const uint RolePermissionType = 96 /*0x60*/;
  public const uint DataTypeDefinition = 97;
  public const uint StructureType = 98;
  public const uint StructureField = 101;
  public const uint StructureDefinition = 99;
  public const uint EnumDefinition = 100;
  public const uint Node = 258;
  public const uint InstanceNode = 11879;
  public const uint TypeNode = 11880;
  public const uint ObjectNode = 261;
  public const uint ObjectTypeNode = 264;
  public const uint VariableNode = 267;
  public const uint VariableTypeNode = 270;
  public const uint ReferenceTypeNode = 273;
  public const uint MethodNode = 276;
  public const uint ViewNode = 279;
  public const uint DataTypeNode = 282;
  public const uint ReferenceNode = 285;
  public const uint Argument = 296;
  public const uint EnumValueType = 7594;
  public const uint EnumField = 102;
  public const uint OptionSet = 12755;
  public const uint NormalizedString = 12877;
  public const uint DecimalString = 12878;
  public const uint DurationString = 12879;
  public const uint TimeString = 12880;
  public const uint DateString = 12881;
  public const uint Duration = 290;
  public const uint UtcTime = 294;
  public const uint Time = 292;
  public const uint Date = 293;
  public const uint LocaleId = 295;
  public const uint TimeZoneDataType = 8912;
  public const uint Index = 17588;
  public const uint IntegerId = 288;
  public const uint ApplicationType = 307;
  public const uint ApplicationDescription = 308;
  public const uint RequestHeader = 389;
  public const uint ResponseHeader = 392;
  public const uint VersionTime = 20998;
  public const uint ServiceFault = 395;
  public const uint SessionlessInvokeRequestType = 15901;
  public const uint SessionlessInvokeResponseType = 20999;
  public const uint FindServersRequest = 420;
  public const uint FindServersResponse = 423;
  public const uint ServerOnNetwork = 12189;
  public const uint FindServersOnNetworkRequest = 12190;
  public const uint FindServersOnNetworkResponse = 12191;
  public const uint ApplicationInstanceCertificate = 311;
  public const uint MessageSecurityMode = 302;
  public const uint UserTokenType = 303;
  public const uint UserTokenPolicy = 304;
  public const uint EndpointDescription = 312;
  public const uint GetEndpointsRequest = 426;
  public const uint GetEndpointsResponse = 429;
  public const uint RegisteredServer = 432;
  public const uint RegisterServerRequest = 435;
  public const uint RegisterServerResponse = 438;
  public const uint DiscoveryConfiguration = 12890;
  public const uint MdnsDiscoveryConfiguration = 12891;
  public const uint RegisterServer2Request = 12193;
  public const uint RegisterServer2Response = 12194;
  public const uint SecurityTokenRequestType = 315;
  public const uint ChannelSecurityToken = 441;
  public const uint OpenSecureChannelRequest = 444;
  public const uint OpenSecureChannelResponse = 447;
  public const uint CloseSecureChannelRequest = 450;
  public const uint CloseSecureChannelResponse = 453;
  public const uint SignedSoftwareCertificate = 344;
  public const uint SessionAuthenticationToken = 388;
  public const uint SignatureData = 456;
  public const uint CreateSessionRequest = 459;
  public const uint CreateSessionResponse = 462;
  public const uint UserIdentityToken = 316;
  public const uint AnonymousIdentityToken = 319;
  public const uint UserNameIdentityToken = 322;
  public const uint X509IdentityToken = 325;
  public const uint IssuedIdentityToken = 938;
  public const uint RsaEncryptedSecret = 17545;
  public const uint EccEncryptedSecret = 17546;
  public const uint ActivateSessionRequest = 465;
  public const uint ActivateSessionResponse = 468;
  public const uint CloseSessionRequest = 471;
  public const uint CloseSessionResponse = 474;
  public const uint CancelRequest = 477;
  public const uint CancelResponse = 480;
  public const uint NodeAttributesMask = 348;
  public const uint NodeAttributes = 349;
  public const uint ObjectAttributes = 352;
  public const uint VariableAttributes = 355;
  public const uint MethodAttributes = 358;
  public const uint ObjectTypeAttributes = 361;
  public const uint VariableTypeAttributes = 364;
  public const uint ReferenceTypeAttributes = 367;
  public const uint DataTypeAttributes = 370;
  public const uint ViewAttributes = 373;
  public const uint GenericAttributeValue = 17606;
  public const uint GenericAttributes = 17607;
  public const uint AddNodesItem = 376;
  public const uint AddNodesResult = 483;
  public const uint AddNodesRequest = 486;
  public const uint AddNodesResponse = 489;
  public const uint AddReferencesItem = 379;
  public const uint AddReferencesRequest = 492;
  public const uint AddReferencesResponse = 495;
  public const uint DeleteNodesItem = 382;
  public const uint DeleteNodesRequest = 498;
  public const uint DeleteNodesResponse = 501;
  public const uint DeleteReferencesItem = 385;
  public const uint DeleteReferencesRequest = 504;
  public const uint DeleteReferencesResponse = 507;
  public const uint AttributeWriteMask = 347;
  public const uint BrowseDirection = 510;
  public const uint ViewDescription = 511 /*0x01FF*/;
  public const uint BrowseDescription = 514;
  public const uint BrowseResultMask = 517;
  public const uint ReferenceDescription = 518;
  public const uint ContinuationPoint = 521;
  public const uint BrowseResult = 522;
  public const uint BrowseRequest = 525;
  public const uint BrowseResponse = 528;
  public const uint BrowseNextRequest = 531;
  public const uint BrowseNextResponse = 534;
  public const uint RelativePathElement = 537;
  public const uint RelativePath = 540;
  public const uint BrowsePath = 543;
  public const uint BrowsePathTarget = 546;
  public const uint BrowsePathResult = 549;
  public const uint TranslateBrowsePathsToNodeIdsRequest = 552;
  public const uint TranslateBrowsePathsToNodeIdsResponse = 555;
  public const uint RegisterNodesRequest = 558;
  public const uint RegisterNodesResponse = 561;
  public const uint UnregisterNodesRequest = 564;
  public const uint UnregisterNodesResponse = 567;
  public const uint Counter = 289;
  public const uint NumericRange = 291;
  public const uint EndpointConfiguration = 331;
  public const uint QueryDataDescription = 570;
  public const uint NodeTypeDescription = 573;
  public const uint FilterOperator = 576;
  public const uint QueryDataSet = 577;
  public const uint NodeReference = 580;
  public const uint ContentFilterElement = 583;
  public const uint ContentFilter = 586;
  public const uint FilterOperand = 589;
  public const uint ElementOperand = 592;
  public const uint LiteralOperand = 595;
  public const uint AttributeOperand = 598;
  public const uint SimpleAttributeOperand = 601;
  public const uint ContentFilterElementResult = 604;
  public const uint ContentFilterResult = 607;
  public const uint ParsingResult = 610;
  public const uint QueryFirstRequest = 613;
  public const uint QueryFirstResponse = 616;
  public const uint QueryNextRequest = 619;
  public const uint QueryNextResponse = 622;
  public const uint TimestampsToReturn = 625;
  public const uint ReadValueId = 626;
  public const uint ReadRequest = 629;
  public const uint ReadResponse = 632;
  public const uint HistoryReadValueId = 635;
  public const uint HistoryReadResult = 638;
  public const uint HistoryReadDetails = 641;
  public const uint ReadEventDetails = 644;
  public const uint ReadRawModifiedDetails = 647;
  public const uint ReadProcessedDetails = 650;
  public const uint ReadAtTimeDetails = 653;
  public const uint ReadAnnotationDataDetails = 23497;
  public const uint HistoryData = 656;
  public const uint ModificationInfo = 11216;
  public const uint HistoryModifiedData = 11217;
  public const uint HistoryEvent = 659;
  public const uint HistoryReadRequest = 662;
  public const uint HistoryReadResponse = 665;
  public const uint WriteValue = 668;
  public const uint WriteRequest = 671;
  public const uint WriteResponse = 674;
  public const uint HistoryUpdateDetails = 677;
  public const uint HistoryUpdateType = 11234;
  public const uint PerformUpdateType = 11293;
  public const uint UpdateDataDetails = 680;
  public const uint UpdateStructureDataDetails = 11295;
  public const uint UpdateEventDetails = 683;
  public const uint DeleteRawModifiedDetails = 686;
  public const uint DeleteAtTimeDetails = 689;
  public const uint DeleteEventDetails = 692;
  public const uint HistoryUpdateResult = 695;
  public const uint HistoryUpdateRequest = 698;
  public const uint HistoryUpdateResponse = 701;
  public const uint CallMethodRequest = 704;
  public const uint CallMethodResult = 707;
  public const uint CallRequest = 710;
  public const uint CallResponse = 713;
  public const uint MonitoringMode = 716;
  public const uint DataChangeTrigger = 717;
  public const uint DeadbandType = 718;
  public const uint MonitoringFilter = 719;
  public const uint DataChangeFilter = 722;
  public const uint EventFilter = 725;
  public const uint AggregateConfiguration = 948;
  public const uint AggregateFilter = 728;
  public const uint MonitoringFilterResult = 731;
  public const uint EventFilterResult = 734;
  public const uint AggregateFilterResult = 737;
  public const uint MonitoringParameters = 740;
  public const uint MonitoredItemCreateRequest = 743;
  public const uint MonitoredItemCreateResult = 746;
  public const uint CreateMonitoredItemsRequest = 749;
  public const uint CreateMonitoredItemsResponse = 752;
  public const uint MonitoredItemModifyRequest = 755;
  public const uint MonitoredItemModifyResult = 758;
  public const uint ModifyMonitoredItemsRequest = 761;
  public const uint ModifyMonitoredItemsResponse = 764;
  public const uint SetMonitoringModeRequest = 767 /*0x02FF*/;
  public const uint SetMonitoringModeResponse = 770;
  public const uint SetTriggeringRequest = 773;
  public const uint SetTriggeringResponse = 776;
  public const uint DeleteMonitoredItemsRequest = 779;
  public const uint DeleteMonitoredItemsResponse = 782;
  public const uint CreateSubscriptionRequest = 785;
  public const uint CreateSubscriptionResponse = 788;
  public const uint ModifySubscriptionRequest = 791;
  public const uint ModifySubscriptionResponse = 794;
  public const uint SetPublishingModeRequest = 797;
  public const uint SetPublishingModeResponse = 800;
  public const uint NotificationMessage = 803;
  public const uint NotificationData = 945;
  public const uint DataChangeNotification = 809;
  public const uint MonitoredItemNotification = 806;
  public const uint EventNotificationList = 914;
  public const uint EventFieldList = 917;
  public const uint HistoryEventFieldList = 920;
  public const uint StatusChangeNotification = 818;
  public const uint SubscriptionAcknowledgement = 821;
  public const uint PublishRequest = 824;
  public const uint PublishResponse = 827;
  public const uint RepublishRequest = 830;
  public const uint RepublishResponse = 833;
  public const uint TransferResult = 836;
  public const uint TransferSubscriptionsRequest = 839;
  public const uint TransferSubscriptionsResponse = 842;
  public const uint DeleteSubscriptionsRequest = 845;
  public const uint DeleteSubscriptionsResponse = 848;
  public const uint BuildInfo = 338;
  public const uint RedundancySupport = 851;
  public const uint ServerState = 852;
  public const uint RedundantServerDataType = 853;
  public const uint EndpointUrlListDataType = 11943;
  public const uint NetworkGroupDataType = 11944;
  public const uint SamplingIntervalDiagnosticsDataType = 856;
  public const uint ServerDiagnosticsSummaryDataType = 859;
  public const uint ServerStatusDataType = 862;
  public const uint SessionDiagnosticsDataType = 865;
  public const uint SessionSecurityDiagnosticsDataType = 868;
  public const uint ServiceCounterDataType = 871;
  public const uint StatusResult = 299;
  public const uint SubscriptionDiagnosticsDataType = 874;
  public const uint ModelChangeStructureVerbMask = 11941;
  public const uint ModelChangeStructureDataType = 877;
  public const uint SemanticChangeStructureDataType = 897;
  public const uint Range = 884;
  public const uint EUInformation = 887;
  public const uint AxisScaleEnumeration = 12077;
  public const uint ComplexNumberType = 12171;
  public const uint DoubleComplexNumberType = 12172;
  public const uint AxisInformation = 12079;
  public const uint XVType = 12080;
  public const uint ProgramDiagnosticDataType = 894;
  public const uint ProgramDiagnostic2DataType = 24033;
  public const uint Annotation = 891;
  public const uint ExceptionDeviationFormat = 890;

  public static string GetBrowseName(int identifier)
  {
    foreach (FieldInfo field in typeof (DataTypes).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if ((long) identifier == (long) (uint) field.GetValue((object) typeof (DataTypes)))
        return field.Name;
    }
    return string.Empty;
  }

  public static string[] GetBrowseNames()
  {
    FieldInfo[] fields = typeof (DataTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
    int num = 0;
    string[] browseNames = new string[fields.Length];
    foreach (FieldInfo fieldInfo in fields)
      browseNames[num++] = fieldInfo.Name;
    return browseNames;
  }

  public static uint GetIdentifier(string browseName)
  {
    foreach (FieldInfo field in typeof (DataTypes).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if (field.Name == browseName)
        return (uint) field.GetValue((object) typeof (DataTypes));
    }
    return 0;
  }

  public static Opc.Ua.NodeId GetDataTypeId(object value) => TypeInfo.GetDataTypeId(value);

  public static Opc.Ua.NodeId GetDataTypeId(Type type) => TypeInfo.GetDataTypeId(type);

  public static Opc.Ua.NodeId GetDataTypeId(TypeInfo typeInfo) => TypeInfo.GetDataTypeId(typeInfo);

  public static int GetValueRank(object value) => TypeInfo.GetValueRank(value);

  public static int GetValueRank(Type type) => TypeInfo.GetValueRank(type);

  public static BuiltInType GetBuiltInType(Opc.Ua.NodeId datatypeId)
  {
    return TypeInfo.GetBuiltInType(datatypeId);
  }

  public static BuiltInType GetBuiltInType(Opc.Ua.NodeId datatypeId, ITypeTable typeTree)
  {
    return TypeInfo.GetBuiltInType(datatypeId, typeTree);
  }

  public static Type GetSystemType(Opc.Ua.NodeId datatypeId, IEncodeableFactory factory)
  {
    return TypeInfo.GetSystemType((Opc.Ua.ExpandedNodeId) datatypeId, factory);
  }
}
