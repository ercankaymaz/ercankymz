using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class VariableIds
{
	public static readonly NodeId DataTypeDescriptionType_DataTypeVersion = new NodeId(104u);

	public static readonly NodeId DataTypeDescriptionType_DictionaryFragment = new NodeId(105u);

	public static readonly NodeId DataTypeDictionaryType_DataTypeVersion = new NodeId(106u);

	public static readonly NodeId DataTypeDictionaryType_NamespaceUri = new NodeId(107u);

	public static readonly NodeId DataTypeDictionaryType_Deprecated = new NodeId(15001u);

	public static readonly NodeId NamingRuleType_EnumValues = new NodeId(12169u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceUri = new NodeId(15958u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceVersion = new NodeId(15959u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespacePublicationDate = new NodeId(15960u);

	public static readonly NodeId OPCUANamespaceMetadata_IsNamespaceSubset = new NodeId(15961u);

	public static readonly NodeId OPCUANamespaceMetadata_StaticNodeIdTypes = new NodeId(15962u);

	public static readonly NodeId OPCUANamespaceMetadata_StaticNumericNodeIdRange = new NodeId(15963u);

	public static readonly NodeId OPCUANamespaceMetadata_StaticStringNodeIdPattern = new NodeId(15964u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_Size = new NodeId(15966u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_Writable = new NodeId(15967u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_UserWritable = new NodeId(15968u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_OpenCount = new NodeId(15969u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_Open_InputArguments = new NodeId(15972u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_Open_OutputArguments = new NodeId(15973u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_Close_InputArguments = new NodeId(15975u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_Read_InputArguments = new NodeId(15977u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_Read_OutputArguments = new NodeId(15978u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_Write_InputArguments = new NodeId(15980u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_GetPosition_InputArguments = new NodeId(15982u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = new NodeId(15983u);

	public static readonly NodeId OPCUANamespaceMetadata_NamespaceFile_SetPosition_InputArguments = new NodeId(15985u);

	public static readonly NodeId OPCUANamespaceMetadata_DefaultRolePermissions = new NodeId(16134u);

	public static readonly NodeId OPCUANamespaceMetadata_DefaultUserRolePermissions = new NodeId(16135u);

	public static readonly NodeId OPCUANamespaceMetadata_DefaultAccessRestrictions = new NodeId(16136u);

	public static readonly NodeId NodeVersion = new NodeId(3068u);

	public static readonly NodeId ViewVersion = new NodeId(12170u);

	public static readonly NodeId Icon = new NodeId(3067u);

	public static readonly NodeId LocalTime = new NodeId(3069u);

	public static readonly NodeId AllowNulls = new NodeId(3070u);

	public static readonly NodeId ValueAsText = new NodeId(11433u);

	public static readonly NodeId MaxStringLength = new NodeId(11498u);

	public static readonly NodeId MaxCharacters = new NodeId(15002u);

	public static readonly NodeId MaxByteStringLength = new NodeId(12908u);

	public static readonly NodeId MaxArrayLength = new NodeId(11512u);

	public static readonly NodeId EngineeringUnits = new NodeId(11513u);

	public static readonly NodeId EnumStrings = new NodeId(11432u);

	public static readonly NodeId EnumValues = new NodeId(3071u);

	public static readonly NodeId OptionSetValues = new NodeId(12745u);

	public static readonly NodeId InputArguments = new NodeId(3072u);

	public static readonly NodeId OutputArguments = new NodeId(3073u);

	public static readonly NodeId DefaultInstanceBrowseName = new NodeId(17605u);

	public static readonly NodeId ServerType_ServerArray = new NodeId(2005u);

	public static readonly NodeId ServerType_NamespaceArray = new NodeId(2006u);

	public static readonly NodeId ServerType_UrisVersion = new NodeId(15003u);

	public static readonly NodeId ServerType_ServerStatus = new NodeId(2007u);

	public static readonly NodeId ServerType_ServerStatus_StartTime = new NodeId(3074u);

	public static readonly NodeId ServerType_ServerStatus_CurrentTime = new NodeId(3075u);

	public static readonly NodeId ServerType_ServerStatus_State = new NodeId(3076u);

	public static readonly NodeId ServerType_ServerStatus_BuildInfo = new NodeId(3077u);

	public static readonly NodeId ServerType_ServerStatus_BuildInfo_ProductUri = new NodeId(3078u);

	public static readonly NodeId ServerType_ServerStatus_BuildInfo_ManufacturerName = new NodeId(3079u);

	public static readonly NodeId ServerType_ServerStatus_BuildInfo_ProductName = new NodeId(3080u);

	public static readonly NodeId ServerType_ServerStatus_BuildInfo_SoftwareVersion = new NodeId(3081u);

	public static readonly NodeId ServerType_ServerStatus_BuildInfo_BuildNumber = new NodeId(3082u);

	public static readonly NodeId ServerType_ServerStatus_BuildInfo_BuildDate = new NodeId(3083u);

	public static readonly NodeId ServerType_ServerStatus_SecondsTillShutdown = new NodeId(3084u);

	public static readonly NodeId ServerType_ServerStatus_ShutdownReason = new NodeId(3085u);

	public static readonly NodeId ServerType_ServiceLevel = new NodeId(2008u);

	public static readonly NodeId ServerType_Auditing = new NodeId(2742u);

	public static readonly NodeId ServerType_EstimatedReturnTime = new NodeId(12882u);

	public static readonly NodeId ServerType_LocalTime = new NodeId(17612u);

	public static readonly NodeId ServerType_ServerCapabilities_ServerProfileArray = new NodeId(3086u);

	public static readonly NodeId ServerType_ServerCapabilities_LocaleIdArray = new NodeId(3087u);

	public static readonly NodeId ServerType_ServerCapabilities_MinSupportedSampleRate = new NodeId(3088u);

	public static readonly NodeId ServerType_ServerCapabilities_MaxBrowseContinuationPoints = new NodeId(3089u);

	public static readonly NodeId ServerType_ServerCapabilities_MaxQueryContinuationPoints = new NodeId(3090u);

	public static readonly NodeId ServerType_ServerCapabilities_MaxHistoryContinuationPoints = new NodeId(3091u);

	public static readonly NodeId ServerType_ServerCapabilities_SoftwareCertificates = new NodeId(3092u);

	public static readonly NodeId ServerType_ServerCapabilities_RoleSet_AddRole_InputArguments = new NodeId(16291u);

	public static readonly NodeId ServerType_ServerCapabilities_RoleSet_AddRole_OutputArguments = new NodeId(16292u);

	public static readonly NodeId ServerType_ServerCapabilities_RoleSet_RemoveRole_InputArguments = new NodeId(16294u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary = new NodeId(3095u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_ServerViewCount = new NodeId(3096u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_CurrentSessionCount = new NodeId(3097u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_CumulatedSessionCount = new NodeId(3098u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_SecurityRejectedSessionCount = new NodeId(3099u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_RejectedSessionCount = new NodeId(3100u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_SessionTimeoutCount = new NodeId(3101u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_SessionAbortCount = new NodeId(3102u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_PublishingIntervalCount = new NodeId(3104u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_CurrentSubscriptionCount = new NodeId(3105u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_CumulatedSubscriptionCount = new NodeId(3106u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_SecurityRejectedRequestsCount = new NodeId(3107u);

	public static readonly NodeId ServerType_ServerDiagnostics_ServerDiagnosticsSummary_RejectedRequestsCount = new NodeId(3108u);

	public static readonly NodeId ServerType_ServerDiagnostics_SubscriptionDiagnosticsArray = new NodeId(3110u);

	public static readonly NodeId ServerType_ServerDiagnostics_SessionsDiagnosticsSummary_SessionDiagnosticsArray = new NodeId(3112u);

	public static readonly NodeId ServerType_ServerDiagnostics_SessionsDiagnosticsSummary_SessionSecurityDiagnosticsArray = new NodeId(3113u);

	public static readonly NodeId ServerType_ServerDiagnostics_EnabledFlag = new NodeId(3114u);

	public static readonly NodeId ServerType_ServerRedundancy_RedundancySupport = new NodeId(3115u);

	public static readonly NodeId ServerType_GetMonitoredItems_InputArguments = new NodeId(11490u);

	public static readonly NodeId ServerType_GetMonitoredItems_OutputArguments = new NodeId(11491u);

	public static readonly NodeId ServerType_ResendData_InputArguments = new NodeId(12872u);

	public static readonly NodeId ServerType_SetSubscriptionDurable_InputArguments = new NodeId(12747u);

	public static readonly NodeId ServerType_SetSubscriptionDurable_OutputArguments = new NodeId(12748u);

	public static readonly NodeId ServerType_RequestServerStateChange_InputArguments = new NodeId(12884u);

	public static readonly NodeId ServerCapabilitiesType_ServerProfileArray = new NodeId(2014u);

	public static readonly NodeId ServerCapabilitiesType_LocaleIdArray = new NodeId(2016u);

	public static readonly NodeId ServerCapabilitiesType_MinSupportedSampleRate = new NodeId(2017u);

	public static readonly NodeId ServerCapabilitiesType_MaxBrowseContinuationPoints = new NodeId(2732u);

	public static readonly NodeId ServerCapabilitiesType_MaxQueryContinuationPoints = new NodeId(2733u);

	public static readonly NodeId ServerCapabilitiesType_MaxHistoryContinuationPoints = new NodeId(2734u);

	public static readonly NodeId ServerCapabilitiesType_SoftwareCertificates = new NodeId(3049u);

	public static readonly NodeId ServerCapabilitiesType_MaxArrayLength = new NodeId(11549u);

	public static readonly NodeId ServerCapabilitiesType_MaxStringLength = new NodeId(11550u);

	public static readonly NodeId ServerCapabilitiesType_MaxByteStringLength = new NodeId(12910u);

	public static readonly NodeId ServerCapabilitiesType_VendorCapability_Placeholder = new NodeId(11562u);

	public static readonly NodeId ServerCapabilitiesType_RoleSet_AddRole_InputArguments = new NodeId(16297u);

	public static readonly NodeId ServerCapabilitiesType_RoleSet_AddRole_OutputArguments = new NodeId(16298u);

	public static readonly NodeId ServerCapabilitiesType_RoleSet_RemoveRole_InputArguments = new NodeId(16300u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary = new NodeId(2021u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_ServerViewCount = new NodeId(3116u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_CurrentSessionCount = new NodeId(3117u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_CumulatedSessionCount = new NodeId(3118u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_SecurityRejectedSessionCount = new NodeId(3119u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_RejectedSessionCount = new NodeId(3120u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_SessionTimeoutCount = new NodeId(3121u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_SessionAbortCount = new NodeId(3122u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_PublishingIntervalCount = new NodeId(3124u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_CurrentSubscriptionCount = new NodeId(3125u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_CumulatedSubscriptionCount = new NodeId(3126u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_SecurityRejectedRequestsCount = new NodeId(3127u);

	public static readonly NodeId ServerDiagnosticsType_ServerDiagnosticsSummary_RejectedRequestsCount = new NodeId(3128u);

	public static readonly NodeId ServerDiagnosticsType_SamplingIntervalDiagnosticsArray = new NodeId(2022u);

	public static readonly NodeId ServerDiagnosticsType_SubscriptionDiagnosticsArray = new NodeId(2023u);

	public static readonly NodeId ServerDiagnosticsType_SessionsDiagnosticsSummary_SessionDiagnosticsArray = new NodeId(3129u);

	public static readonly NodeId ServerDiagnosticsType_SessionsDiagnosticsSummary_SessionSecurityDiagnosticsArray = new NodeId(3130u);

	public static readonly NodeId ServerDiagnosticsType_EnabledFlag = new NodeId(2025u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_SessionDiagnosticsArray = new NodeId(2027u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_SessionSecurityDiagnosticsArray = new NodeId(2028u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics = new NodeId(12098u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_SessionId = new NodeId(12099u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_SessionName = new NodeId(12100u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_ClientDescription = new NodeId(12101u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_ServerUri = new NodeId(12102u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_EndpointUrl = new NodeId(12103u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_LocaleIds = new NodeId(12104u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_ActualSessionTimeout = new NodeId(12105u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_MaxResponseMessageSize = new NodeId(12106u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_ClientConnectionTime = new NodeId(12107u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_ClientLastContactTime = new NodeId(12108u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_CurrentSubscriptionsCount = new NodeId(12109u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_CurrentMonitoredItemsCount = new NodeId(12110u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_CurrentPublishRequestsInQueue = new NodeId(12111u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_TotalRequestCount = new NodeId(12112u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_UnauthorizedRequestCount = new NodeId(12113u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_ReadCount = new NodeId(12114u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_HistoryReadCount = new NodeId(12115u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_WriteCount = new NodeId(12116u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_HistoryUpdateCount = new NodeId(12117u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_CallCount = new NodeId(12118u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_CreateMonitoredItemsCount = new NodeId(12119u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_ModifyMonitoredItemsCount = new NodeId(12120u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_SetMonitoringModeCount = new NodeId(12121u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_SetTriggeringCount = new NodeId(12122u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_DeleteMonitoredItemsCount = new NodeId(12123u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_CreateSubscriptionCount = new NodeId(12124u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_ModifySubscriptionCount = new NodeId(12125u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_SetPublishingModeCount = new NodeId(12126u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_PublishCount = new NodeId(12127u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_RepublishCount = new NodeId(12128u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_TransferSubscriptionsCount = new NodeId(12129u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_DeleteSubscriptionsCount = new NodeId(12130u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_AddNodesCount = new NodeId(12131u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_AddReferencesCount = new NodeId(12132u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_DeleteNodesCount = new NodeId(12133u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_DeleteReferencesCount = new NodeId(12134u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_BrowseCount = new NodeId(12135u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_BrowseNextCount = new NodeId(12136u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_TranslateBrowsePathsToNodeIdsCount = new NodeId(12137u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_QueryFirstCount = new NodeId(12138u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_QueryNextCount = new NodeId(12139u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_RegisterNodesCount = new NodeId(12140u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionDiagnostics_UnregisterNodesCount = new NodeId(12141u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics = new NodeId(12142u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics_SessionId = new NodeId(12143u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics_ClientUserIdOfSession = new NodeId(12144u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics_ClientUserIdHistory = new NodeId(12145u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics_AuthenticationMechanism = new NodeId(12146u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics_Encoding = new NodeId(12147u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics_TransportProtocol = new NodeId(12148u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics_SecurityMode = new NodeId(12149u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics_SecurityPolicyUri = new NodeId(12150u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SessionSecurityDiagnostics_ClientCertificate = new NodeId(12151u);

	public static readonly NodeId SessionsDiagnosticsSummaryType_ClientName_Placeholder_SubscriptionDiagnosticsArray = new NodeId(12152u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics = new NodeId(2030u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_SessionId = new NodeId(3131u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_SessionName = new NodeId(3132u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_ClientDescription = new NodeId(3133u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_ServerUri = new NodeId(3134u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_EndpointUrl = new NodeId(3135u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_LocaleIds = new NodeId(3136u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_ActualSessionTimeout = new NodeId(3137u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_MaxResponseMessageSize = new NodeId(3138u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_ClientConnectionTime = new NodeId(3139u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_ClientLastContactTime = new NodeId(3140u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_CurrentSubscriptionsCount = new NodeId(3141u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_CurrentMonitoredItemsCount = new NodeId(3142u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_CurrentPublishRequestsInQueue = new NodeId(3143u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_TotalRequestCount = new NodeId(8898u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_UnauthorizedRequestCount = new NodeId(11891u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_ReadCount = new NodeId(3151u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_HistoryReadCount = new NodeId(3152u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_WriteCount = new NodeId(3153u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_HistoryUpdateCount = new NodeId(3154u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_CallCount = new NodeId(3155u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_CreateMonitoredItemsCount = new NodeId(3156u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_ModifyMonitoredItemsCount = new NodeId(3157u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_SetMonitoringModeCount = new NodeId(3158u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_SetTriggeringCount = new NodeId(3159u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_DeleteMonitoredItemsCount = new NodeId(3160u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_CreateSubscriptionCount = new NodeId(3161u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_ModifySubscriptionCount = new NodeId(3162u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_SetPublishingModeCount = new NodeId(3163u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_PublishCount = new NodeId(3164u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_RepublishCount = new NodeId(3165u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_TransferSubscriptionsCount = new NodeId(3166u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_DeleteSubscriptionsCount = new NodeId(3167u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_AddNodesCount = new NodeId(3168u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_AddReferencesCount = new NodeId(3169u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_DeleteNodesCount = new NodeId(3170u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_DeleteReferencesCount = new NodeId(3171u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_BrowseCount = new NodeId(3172u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_BrowseNextCount = new NodeId(3173u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_TranslateBrowsePathsToNodeIdsCount = new NodeId(3174u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_QueryFirstCount = new NodeId(3175u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_QueryNextCount = new NodeId(3176u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_RegisterNodesCount = new NodeId(3177u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionDiagnostics_UnregisterNodesCount = new NodeId(3178u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics = new NodeId(2031u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics_SessionId = new NodeId(3179u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics_ClientUserIdOfSession = new NodeId(3180u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics_ClientUserIdHistory = new NodeId(3181u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics_AuthenticationMechanism = new NodeId(3182u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics_Encoding = new NodeId(3183u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics_TransportProtocol = new NodeId(3184u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics_SecurityMode = new NodeId(3185u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics_SecurityPolicyUri = new NodeId(3186u);

	public static readonly NodeId SessionDiagnosticsObjectType_SessionSecurityDiagnostics_ClientCertificate = new NodeId(3187u);

	public static readonly NodeId SessionDiagnosticsObjectType_SubscriptionDiagnosticsArray = new NodeId(2032u);

	public static readonly NodeId ServerRedundancyType_RedundancySupport = new NodeId(2035u);

	public static readonly NodeId TransparentRedundancyType_CurrentServerId = new NodeId(2037u);

	public static readonly NodeId TransparentRedundancyType_RedundantServerArray = new NodeId(2038u);

	public static readonly NodeId NonTransparentRedundancyType_ServerUriArray = new NodeId(2040u);

	public static readonly NodeId NonTransparentNetworkRedundancyType_ServerNetworkGroups = new NodeId(11948u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerRead = new NodeId(11565u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerHistoryReadData = new NodeId(12161u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerHistoryReadEvents = new NodeId(12162u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerWrite = new NodeId(11567u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerHistoryUpdateData = new NodeId(12163u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerHistoryUpdateEvents = new NodeId(12164u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerMethodCall = new NodeId(11569u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerBrowse = new NodeId(11570u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerRegisterNodes = new NodeId(11571u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerTranslateBrowsePathsToNodeIds = new NodeId(11572u);

	public static readonly NodeId OperationLimitsType_MaxNodesPerNodeManagement = new NodeId(11573u);

	public static readonly NodeId OperationLimitsType_MaxMonitoredItemsPerCall = new NodeId(11574u);

	public static readonly NodeId FileType_Size = new NodeId(11576u);

	public static readonly NodeId FileType_Writable = new NodeId(12686u);

	public static readonly NodeId FileType_UserWritable = new NodeId(12687u);

	public static readonly NodeId FileType_OpenCount = new NodeId(11579u);

	public static readonly NodeId FileType_MimeType = new NodeId(13341u);

	public static readonly NodeId FileType_MaxByteStringLength = new NodeId(24244u);

	public static readonly NodeId FileType_Open_InputArguments = new NodeId(11581u);

	public static readonly NodeId FileType_Open_OutputArguments = new NodeId(11582u);

	public static readonly NodeId FileType_Close_InputArguments = new NodeId(11584u);

	public static readonly NodeId FileType_Read_InputArguments = new NodeId(11586u);

	public static readonly NodeId FileType_Read_OutputArguments = new NodeId(11587u);

	public static readonly NodeId FileType_Write_InputArguments = new NodeId(11589u);

	public static readonly NodeId FileType_GetPosition_InputArguments = new NodeId(11591u);

	public static readonly NodeId FileType_GetPosition_OutputArguments = new NodeId(11592u);

	public static readonly NodeId FileType_SetPosition_InputArguments = new NodeId(11594u);

	public static readonly NodeId AddressSpaceFileType_Open_InputArguments = new NodeId(11601u);

	public static readonly NodeId AddressSpaceFileType_Open_OutputArguments = new NodeId(11602u);

	public static readonly NodeId AddressSpaceFileType_Close_InputArguments = new NodeId(11604u);

	public static readonly NodeId AddressSpaceFileType_Read_InputArguments = new NodeId(11606u);

	public static readonly NodeId AddressSpaceFileType_Read_OutputArguments = new NodeId(11607u);

	public static readonly NodeId AddressSpaceFileType_Write_InputArguments = new NodeId(11609u);

	public static readonly NodeId AddressSpaceFileType_GetPosition_InputArguments = new NodeId(11611u);

	public static readonly NodeId AddressSpaceFileType_GetPosition_OutputArguments = new NodeId(11612u);

	public static readonly NodeId AddressSpaceFileType_SetPosition_InputArguments = new NodeId(11614u);

	public static readonly NodeId NamespaceMetadataType_NamespaceUri = new NodeId(11617u);

	public static readonly NodeId NamespaceMetadataType_NamespaceVersion = new NodeId(11618u);

	public static readonly NodeId NamespaceMetadataType_NamespacePublicationDate = new NodeId(11619u);

	public static readonly NodeId NamespaceMetadataType_IsNamespaceSubset = new NodeId(11620u);

	public static readonly NodeId NamespaceMetadataType_StaticNodeIdTypes = new NodeId(11621u);

	public static readonly NodeId NamespaceMetadataType_StaticNumericNodeIdRange = new NodeId(11622u);

	public static readonly NodeId NamespaceMetadataType_StaticStringNodeIdPattern = new NodeId(11623u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_Size = new NodeId(11625u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_Writable = new NodeId(12690u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_UserWritable = new NodeId(12691u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_OpenCount = new NodeId(11628u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_Open_InputArguments = new NodeId(11630u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_Open_OutputArguments = new NodeId(11631u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_Close_InputArguments = new NodeId(11633u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_Read_InputArguments = new NodeId(11635u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_Read_OutputArguments = new NodeId(11636u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_Write_InputArguments = new NodeId(11638u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_GetPosition_InputArguments = new NodeId(11640u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_GetPosition_OutputArguments = new NodeId(11641u);

	public static readonly NodeId NamespaceMetadataType_NamespaceFile_SetPosition_InputArguments = new NodeId(11643u);

	public static readonly NodeId NamespaceMetadataType_DefaultRolePermissions = new NodeId(16137u);

	public static readonly NodeId NamespaceMetadataType_DefaultUserRolePermissions = new NodeId(16138u);

	public static readonly NodeId NamespaceMetadataType_DefaultAccessRestrictions = new NodeId(16139u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceUri = new NodeId(11647u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceVersion = new NodeId(11648u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespacePublicationDate = new NodeId(11649u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_IsNamespaceSubset = new NodeId(11650u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_StaticNodeIdTypes = new NodeId(11651u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_StaticNumericNodeIdRange = new NodeId(11652u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_StaticStringNodeIdPattern = new NodeId(11653u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Size = new NodeId(11655u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Writable = new NodeId(12692u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_UserWritable = new NodeId(12693u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_OpenCount = new NodeId(11658u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Open_InputArguments = new NodeId(11660u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Open_OutputArguments = new NodeId(11661u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Close_InputArguments = new NodeId(11663u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Read_InputArguments = new NodeId(11665u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Read_OutputArguments = new NodeId(11666u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Write_InputArguments = new NodeId(11668u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_GetPosition_InputArguments = new NodeId(11670u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_GetPosition_OutputArguments = new NodeId(11671u);

	public static readonly NodeId NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_SetPosition_InputArguments = new NodeId(11673u);

	public static readonly NodeId BaseEventType_EventId = new NodeId(2042u);

	public static readonly NodeId BaseEventType_EventType = new NodeId(2043u);

	public static readonly NodeId BaseEventType_SourceNode = new NodeId(2044u);

	public static readonly NodeId BaseEventType_SourceName = new NodeId(2045u);

	public static readonly NodeId BaseEventType_Time = new NodeId(2046u);

	public static readonly NodeId BaseEventType_ReceiveTime = new NodeId(2047u);

	public static readonly NodeId BaseEventType_LocalTime = new NodeId(3190u);

	public static readonly NodeId BaseEventType_Message = new NodeId(2050u);

	public static readonly NodeId BaseEventType_Severity = new NodeId(2051u);

	public static readonly NodeId AuditEventType_ActionTimeStamp = new NodeId(2053u);

	public static readonly NodeId AuditEventType_Status = new NodeId(2054u);

	public static readonly NodeId AuditEventType_ServerId = new NodeId(2055u);

	public static readonly NodeId AuditEventType_ClientAuditEntryId = new NodeId(2056u);

	public static readonly NodeId AuditEventType_ClientUserId = new NodeId(2057u);

	public static readonly NodeId AuditSecurityEventType_StatusCodeId = new NodeId(17615u);

	public static readonly NodeId AuditChannelEventType_SecureChannelId = new NodeId(2745u);

	public static readonly NodeId AuditOpenSecureChannelEventType_ClientCertificate = new NodeId(2061u);

	public static readonly NodeId AuditOpenSecureChannelEventType_ClientCertificateThumbprint = new NodeId(2746u);

	public static readonly NodeId AuditOpenSecureChannelEventType_RequestType = new NodeId(2062u);

	public static readonly NodeId AuditOpenSecureChannelEventType_SecurityPolicyUri = new NodeId(2063u);

	public static readonly NodeId AuditOpenSecureChannelEventType_SecurityMode = new NodeId(2065u);

	public static readonly NodeId AuditOpenSecureChannelEventType_RequestedLifetime = new NodeId(2066u);

	public static readonly NodeId AuditOpenSecureChannelEventType_CertificateErrorEventId = new NodeId(24135u);

	public static readonly NodeId AuditSessionEventType_SessionId = new NodeId(2070u);

	public static readonly NodeId AuditCreateSessionEventType_SecureChannelId = new NodeId(2072u);

	public static readonly NodeId AuditCreateSessionEventType_ClientCertificate = new NodeId(2073u);

	public static readonly NodeId AuditCreateSessionEventType_ClientCertificateThumbprint = new NodeId(2747u);

	public static readonly NodeId AuditCreateSessionEventType_RevisedSessionTimeout = new NodeId(2074u);

	public static readonly NodeId AuditUrlMismatchEventType_EndpointUrl = new NodeId(2749u);

	public static readonly NodeId AuditActivateSessionEventType_ClientSoftwareCertificates = new NodeId(2076u);

	public static readonly NodeId AuditActivateSessionEventType_UserIdentityToken = new NodeId(2077u);

	public static readonly NodeId AuditActivateSessionEventType_SecureChannelId = new NodeId(11485u);

	public static readonly NodeId AuditCancelEventType_RequestHandle = new NodeId(2079u);

	public static readonly NodeId AuditCertificateEventType_Certificate = new NodeId(2081u);

	public static readonly NodeId AuditCertificateDataMismatchEventType_InvalidHostname = new NodeId(2083u);

	public static readonly NodeId AuditCertificateDataMismatchEventType_InvalidUri = new NodeId(2084u);

	public static readonly NodeId AuditAddNodesEventType_NodesToAdd = new NodeId(2092u);

	public static readonly NodeId AuditDeleteNodesEventType_NodesToDelete = new NodeId(2094u);

	public static readonly NodeId AuditAddReferencesEventType_ReferencesToAdd = new NodeId(2096u);

	public static readonly NodeId AuditDeleteReferencesEventType_ReferencesToDelete = new NodeId(2098u);

	public static readonly NodeId AuditWriteUpdateEventType_AttributeId = new NodeId(2750u);

	public static readonly NodeId AuditWriteUpdateEventType_IndexRange = new NodeId(2101u);

	public static readonly NodeId AuditWriteUpdateEventType_OldValue = new NodeId(2102u);

	public static readonly NodeId AuditWriteUpdateEventType_NewValue = new NodeId(2103u);

	public static readonly NodeId AuditHistoryUpdateEventType_ParameterDataTypeId = new NodeId(2751u);

	public static readonly NodeId AuditUpdateMethodEventType_MethodId = new NodeId(2128u);

	public static readonly NodeId AuditUpdateMethodEventType_InputArguments = new NodeId(2129u);

	public static readonly NodeId SystemStatusChangeEventType_SystemState = new NodeId(11696u);

	public static readonly NodeId GeneralModelChangeEventType_Changes = new NodeId(2134u);

	public static readonly NodeId SemanticChangeEventType_Changes = new NodeId(2739u);

	public static readonly NodeId ProgressEventType_Context = new NodeId(12502u);

	public static readonly NodeId ProgressEventType_Progress = new NodeId(12503u);

	public static readonly NodeId ServerStatusType_StartTime = new NodeId(2139u);

	public static readonly NodeId ServerStatusType_CurrentTime = new NodeId(2140u);

	public static readonly NodeId ServerStatusType_State = new NodeId(2141u);

	public static readonly NodeId ServerStatusType_BuildInfo = new NodeId(2142u);

	public static readonly NodeId ServerStatusType_BuildInfo_ProductUri = new NodeId(3698u);

	public static readonly NodeId ServerStatusType_BuildInfo_ManufacturerName = new NodeId(3699u);

	public static readonly NodeId ServerStatusType_BuildInfo_ProductName = new NodeId(3700u);

	public static readonly NodeId ServerStatusType_BuildInfo_SoftwareVersion = new NodeId(3701u);

	public static readonly NodeId ServerStatusType_BuildInfo_BuildNumber = new NodeId(3702u);

	public static readonly NodeId ServerStatusType_BuildInfo_BuildDate = new NodeId(3703u);

	public static readonly NodeId ServerStatusType_SecondsTillShutdown = new NodeId(2752u);

	public static readonly NodeId ServerStatusType_ShutdownReason = new NodeId(2753u);

	public static readonly NodeId BuildInfoType_ProductUri = new NodeId(3052u);

	public static readonly NodeId BuildInfoType_ManufacturerName = new NodeId(3053u);

	public static readonly NodeId BuildInfoType_ProductName = new NodeId(3054u);

	public static readonly NodeId BuildInfoType_SoftwareVersion = new NodeId(3055u);

	public static readonly NodeId BuildInfoType_BuildNumber = new NodeId(3056u);

	public static readonly NodeId BuildInfoType_BuildDate = new NodeId(3057u);

	public static readonly NodeId ServerDiagnosticsSummaryType_ServerViewCount = new NodeId(2151u);

	public static readonly NodeId ServerDiagnosticsSummaryType_CurrentSessionCount = new NodeId(2152u);

	public static readonly NodeId ServerDiagnosticsSummaryType_CumulatedSessionCount = new NodeId(2153u);

	public static readonly NodeId ServerDiagnosticsSummaryType_SecurityRejectedSessionCount = new NodeId(2154u);

	public static readonly NodeId ServerDiagnosticsSummaryType_RejectedSessionCount = new NodeId(2155u);

	public static readonly NodeId ServerDiagnosticsSummaryType_SessionTimeoutCount = new NodeId(2156u);

	public static readonly NodeId ServerDiagnosticsSummaryType_SessionAbortCount = new NodeId(2157u);

	public static readonly NodeId ServerDiagnosticsSummaryType_PublishingIntervalCount = new NodeId(2159u);

	public static readonly NodeId ServerDiagnosticsSummaryType_CurrentSubscriptionCount = new NodeId(2160u);

	public static readonly NodeId ServerDiagnosticsSummaryType_CumulatedSubscriptionCount = new NodeId(2161u);

	public static readonly NodeId ServerDiagnosticsSummaryType_SecurityRejectedRequestsCount = new NodeId(2162u);

	public static readonly NodeId ServerDiagnosticsSummaryType_RejectedRequestsCount = new NodeId(2163u);

	public static readonly NodeId SamplingIntervalDiagnosticsArrayType_SamplingIntervalDiagnostics = new NodeId(12779u);

	public static readonly NodeId SamplingIntervalDiagnosticsArrayType_SamplingIntervalDiagnostics_SamplingInterval = new NodeId(12780u);

	public static readonly NodeId SamplingIntervalDiagnosticsArrayType_SamplingIntervalDiagnostics_SampledMonitoredItemsCount = new NodeId(12781u);

	public static readonly NodeId SamplingIntervalDiagnosticsArrayType_SamplingIntervalDiagnostics_MaxSampledMonitoredItemsCount = new NodeId(12782u);

	public static readonly NodeId SamplingIntervalDiagnosticsArrayType_SamplingIntervalDiagnostics_DisabledMonitoredItemsSamplingCount = new NodeId(12783u);

	public static readonly NodeId SamplingIntervalDiagnosticsType_SamplingInterval = new NodeId(2166u);

	public static readonly NodeId SamplingIntervalDiagnosticsType_SampledMonitoredItemsCount = new NodeId(11697u);

	public static readonly NodeId SamplingIntervalDiagnosticsType_MaxSampledMonitoredItemsCount = new NodeId(11698u);

	public static readonly NodeId SamplingIntervalDiagnosticsType_DisabledMonitoredItemsSamplingCount = new NodeId(11699u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics = new NodeId(12784u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_SessionId = new NodeId(12785u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_SubscriptionId = new NodeId(12786u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_Priority = new NodeId(12787u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_PublishingInterval = new NodeId(12788u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_MaxKeepAliveCount = new NodeId(12789u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_MaxLifetimeCount = new NodeId(12790u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_MaxNotificationsPerPublish = new NodeId(12791u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_PublishingEnabled = new NodeId(12792u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_ModifyCount = new NodeId(12793u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_EnableCount = new NodeId(12794u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_DisableCount = new NodeId(12795u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_RepublishRequestCount = new NodeId(12796u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_RepublishMessageRequestCount = new NodeId(12797u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_RepublishMessageCount = new NodeId(12798u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_TransferRequestCount = new NodeId(12799u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_TransferredToAltClientCount = new NodeId(12800u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_TransferredToSameClientCount = new NodeId(12801u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_PublishRequestCount = new NodeId(12802u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_DataChangeNotificationsCount = new NodeId(12803u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_EventNotificationsCount = new NodeId(12804u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_NotificationsCount = new NodeId(12805u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_LatePublishRequestCount = new NodeId(12806u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_CurrentKeepAliveCount = new NodeId(12807u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_CurrentLifetimeCount = new NodeId(12808u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_UnacknowledgedMessageCount = new NodeId(12809u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_DiscardedMessageCount = new NodeId(12810u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_MonitoredItemCount = new NodeId(12811u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_DisabledMonitoredItemCount = new NodeId(12812u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_MonitoringQueueOverflowCount = new NodeId(12813u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_NextSequenceNumber = new NodeId(12814u);

	public static readonly NodeId SubscriptionDiagnosticsArrayType_SubscriptionDiagnostics_EventQueueOverflowCount = new NodeId(12815u);

	public static readonly NodeId SubscriptionDiagnosticsType_SessionId = new NodeId(2173u);

	public static readonly NodeId SubscriptionDiagnosticsType_SubscriptionId = new NodeId(2174u);

	public static readonly NodeId SubscriptionDiagnosticsType_Priority = new NodeId(2175u);

	public static readonly NodeId SubscriptionDiagnosticsType_PublishingInterval = new NodeId(2176u);

	public static readonly NodeId SubscriptionDiagnosticsType_MaxKeepAliveCount = new NodeId(2177u);

	public static readonly NodeId SubscriptionDiagnosticsType_MaxLifetimeCount = new NodeId(8888u);

	public static readonly NodeId SubscriptionDiagnosticsType_MaxNotificationsPerPublish = new NodeId(2179u);

	public static readonly NodeId SubscriptionDiagnosticsType_PublishingEnabled = new NodeId(2180u);

	public static readonly NodeId SubscriptionDiagnosticsType_ModifyCount = new NodeId(2181u);

	public static readonly NodeId SubscriptionDiagnosticsType_EnableCount = new NodeId(2182u);

	public static readonly NodeId SubscriptionDiagnosticsType_DisableCount = new NodeId(2183u);

	public static readonly NodeId SubscriptionDiagnosticsType_RepublishRequestCount = new NodeId(2184u);

	public static readonly NodeId SubscriptionDiagnosticsType_RepublishMessageRequestCount = new NodeId(2185u);

	public static readonly NodeId SubscriptionDiagnosticsType_RepublishMessageCount = new NodeId(2186u);

	public static readonly NodeId SubscriptionDiagnosticsType_TransferRequestCount = new NodeId(2187u);

	public static readonly NodeId SubscriptionDiagnosticsType_TransferredToAltClientCount = new NodeId(2188u);

	public static readonly NodeId SubscriptionDiagnosticsType_TransferredToSameClientCount = new NodeId(2189u);

	public static readonly NodeId SubscriptionDiagnosticsType_PublishRequestCount = new NodeId(2190u);

	public static readonly NodeId SubscriptionDiagnosticsType_DataChangeNotificationsCount = new NodeId(2191u);

	public static readonly NodeId SubscriptionDiagnosticsType_EventNotificationsCount = new NodeId(2998u);

	public static readonly NodeId SubscriptionDiagnosticsType_NotificationsCount = new NodeId(2193u);

	public static readonly NodeId SubscriptionDiagnosticsType_LatePublishRequestCount = new NodeId(8889u);

	public static readonly NodeId SubscriptionDiagnosticsType_CurrentKeepAliveCount = new NodeId(8890u);

	public static readonly NodeId SubscriptionDiagnosticsType_CurrentLifetimeCount = new NodeId(8891u);

	public static readonly NodeId SubscriptionDiagnosticsType_UnacknowledgedMessageCount = new NodeId(8892u);

	public static readonly NodeId SubscriptionDiagnosticsType_DiscardedMessageCount = new NodeId(8893u);

	public static readonly NodeId SubscriptionDiagnosticsType_MonitoredItemCount = new NodeId(8894u);

	public static readonly NodeId SubscriptionDiagnosticsType_DisabledMonitoredItemCount = new NodeId(8895u);

	public static readonly NodeId SubscriptionDiagnosticsType_MonitoringQueueOverflowCount = new NodeId(8896u);

	public static readonly NodeId SubscriptionDiagnosticsType_NextSequenceNumber = new NodeId(8897u);

	public static readonly NodeId SubscriptionDiagnosticsType_EventQueueOverflowCount = new NodeId(8902u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics = new NodeId(12816u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_SessionId = new NodeId(12817u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_SessionName = new NodeId(12818u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_ClientDescription = new NodeId(12819u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_ServerUri = new NodeId(12820u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_EndpointUrl = new NodeId(12821u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_LocaleIds = new NodeId(12822u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_ActualSessionTimeout = new NodeId(12823u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_MaxResponseMessageSize = new NodeId(12824u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_ClientConnectionTime = new NodeId(12825u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_ClientLastContactTime = new NodeId(12826u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_CurrentSubscriptionsCount = new NodeId(12827u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_CurrentMonitoredItemsCount = new NodeId(12828u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_CurrentPublishRequestsInQueue = new NodeId(12829u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_TotalRequestCount = new NodeId(12830u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_UnauthorizedRequestCount = new NodeId(12831u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_ReadCount = new NodeId(12832u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_HistoryReadCount = new NodeId(12833u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_WriteCount = new NodeId(12834u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_HistoryUpdateCount = new NodeId(12835u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_CallCount = new NodeId(12836u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_CreateMonitoredItemsCount = new NodeId(12837u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_ModifyMonitoredItemsCount = new NodeId(12838u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_SetMonitoringModeCount = new NodeId(12839u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_SetTriggeringCount = new NodeId(12840u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_DeleteMonitoredItemsCount = new NodeId(12841u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_CreateSubscriptionCount = new NodeId(12842u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_ModifySubscriptionCount = new NodeId(12843u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_SetPublishingModeCount = new NodeId(12844u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_PublishCount = new NodeId(12845u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_RepublishCount = new NodeId(12846u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_TransferSubscriptionsCount = new NodeId(12847u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_DeleteSubscriptionsCount = new NodeId(12848u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_AddNodesCount = new NodeId(12849u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_AddReferencesCount = new NodeId(12850u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_DeleteNodesCount = new NodeId(12851u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_DeleteReferencesCount = new NodeId(12852u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_BrowseCount = new NodeId(12853u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_BrowseNextCount = new NodeId(12854u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_TranslateBrowsePathsToNodeIdsCount = new NodeId(12855u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_QueryFirstCount = new NodeId(12856u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_QueryNextCount = new NodeId(12857u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_RegisterNodesCount = new NodeId(12858u);

	public static readonly NodeId SessionDiagnosticsArrayType_SessionDiagnostics_UnregisterNodesCount = new NodeId(12859u);

	public static readonly NodeId SessionDiagnosticsVariableType_SessionId = new NodeId(2198u);

	public static readonly NodeId SessionDiagnosticsVariableType_SessionName = new NodeId(2199u);

	public static readonly NodeId SessionDiagnosticsVariableType_ClientDescription = new NodeId(2200u);

	public static readonly NodeId SessionDiagnosticsVariableType_ServerUri = new NodeId(2201u);

	public static readonly NodeId SessionDiagnosticsVariableType_EndpointUrl = new NodeId(2202u);

	public static readonly NodeId SessionDiagnosticsVariableType_LocaleIds = new NodeId(2203u);

	public static readonly NodeId SessionDiagnosticsVariableType_ActualSessionTimeout = new NodeId(2204u);

	public static readonly NodeId SessionDiagnosticsVariableType_MaxResponseMessageSize = new NodeId(3050u);

	public static readonly NodeId SessionDiagnosticsVariableType_ClientConnectionTime = new NodeId(2205u);

	public static readonly NodeId SessionDiagnosticsVariableType_ClientLastContactTime = new NodeId(2206u);

	public static readonly NodeId SessionDiagnosticsVariableType_CurrentSubscriptionsCount = new NodeId(2207u);

	public static readonly NodeId SessionDiagnosticsVariableType_CurrentMonitoredItemsCount = new NodeId(2208u);

	public static readonly NodeId SessionDiagnosticsVariableType_CurrentPublishRequestsInQueue = new NodeId(2209u);

	public static readonly NodeId SessionDiagnosticsVariableType_TotalRequestCount = new NodeId(8900u);

	public static readonly NodeId SessionDiagnosticsVariableType_UnauthorizedRequestCount = new NodeId(11892u);

	public static readonly NodeId SessionDiagnosticsVariableType_ReadCount = new NodeId(2217u);

	public static readonly NodeId SessionDiagnosticsVariableType_HistoryReadCount = new NodeId(2218u);

	public static readonly NodeId SessionDiagnosticsVariableType_WriteCount = new NodeId(2219u);

	public static readonly NodeId SessionDiagnosticsVariableType_HistoryUpdateCount = new NodeId(2220u);

	public static readonly NodeId SessionDiagnosticsVariableType_CallCount = new NodeId(2221u);

	public static readonly NodeId SessionDiagnosticsVariableType_CreateMonitoredItemsCount = new NodeId(2222u);

	public static readonly NodeId SessionDiagnosticsVariableType_ModifyMonitoredItemsCount = new NodeId(2223u);

	public static readonly NodeId SessionDiagnosticsVariableType_SetMonitoringModeCount = new NodeId(2224u);

	public static readonly NodeId SessionDiagnosticsVariableType_SetTriggeringCount = new NodeId(2225u);

	public static readonly NodeId SessionDiagnosticsVariableType_DeleteMonitoredItemsCount = new NodeId(2226u);

	public static readonly NodeId SessionDiagnosticsVariableType_CreateSubscriptionCount = new NodeId(2227u);

	public static readonly NodeId SessionDiagnosticsVariableType_ModifySubscriptionCount = new NodeId(2228u);

	public static readonly NodeId SessionDiagnosticsVariableType_SetPublishingModeCount = new NodeId(2229u);

	public static readonly NodeId SessionDiagnosticsVariableType_PublishCount = new NodeId(2230u);

	public static readonly NodeId SessionDiagnosticsVariableType_RepublishCount = new NodeId(2231u);

	public static readonly NodeId SessionDiagnosticsVariableType_TransferSubscriptionsCount = new NodeId(2232u);

	public static readonly NodeId SessionDiagnosticsVariableType_DeleteSubscriptionsCount = new NodeId(2233u);

	public static readonly NodeId SessionDiagnosticsVariableType_AddNodesCount = new NodeId(2234u);

	public static readonly NodeId SessionDiagnosticsVariableType_AddReferencesCount = new NodeId(2235u);

	public static readonly NodeId SessionDiagnosticsVariableType_DeleteNodesCount = new NodeId(2236u);

	public static readonly NodeId SessionDiagnosticsVariableType_DeleteReferencesCount = new NodeId(2237u);

	public static readonly NodeId SessionDiagnosticsVariableType_BrowseCount = new NodeId(2238u);

	public static readonly NodeId SessionDiagnosticsVariableType_BrowseNextCount = new NodeId(2239u);

	public static readonly NodeId SessionDiagnosticsVariableType_TranslateBrowsePathsToNodeIdsCount = new NodeId(2240u);

	public static readonly NodeId SessionDiagnosticsVariableType_QueryFirstCount = new NodeId(2241u);

	public static readonly NodeId SessionDiagnosticsVariableType_QueryNextCount = new NodeId(2242u);

	public static readonly NodeId SessionDiagnosticsVariableType_RegisterNodesCount = new NodeId(2730u);

	public static readonly NodeId SessionDiagnosticsVariableType_UnregisterNodesCount = new NodeId(2731u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics = new NodeId(12860u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics_SessionId = new NodeId(12861u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics_ClientUserIdOfSession = new NodeId(12862u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics_ClientUserIdHistory = new NodeId(12863u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics_AuthenticationMechanism = new NodeId(12864u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics_Encoding = new NodeId(12865u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics_TransportProtocol = new NodeId(12866u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics_SecurityMode = new NodeId(12867u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics_SecurityPolicyUri = new NodeId(12868u);

	public static readonly NodeId SessionSecurityDiagnosticsArrayType_SessionSecurityDiagnostics_ClientCertificate = new NodeId(12869u);

	public static readonly NodeId SessionSecurityDiagnosticsType_SessionId = new NodeId(2245u);

	public static readonly NodeId SessionSecurityDiagnosticsType_ClientUserIdOfSession = new NodeId(2246u);

	public static readonly NodeId SessionSecurityDiagnosticsType_ClientUserIdHistory = new NodeId(2247u);

	public static readonly NodeId SessionSecurityDiagnosticsType_AuthenticationMechanism = new NodeId(2248u);

	public static readonly NodeId SessionSecurityDiagnosticsType_Encoding = new NodeId(2249u);

	public static readonly NodeId SessionSecurityDiagnosticsType_TransportProtocol = new NodeId(2250u);

	public static readonly NodeId SessionSecurityDiagnosticsType_SecurityMode = new NodeId(2251u);

	public static readonly NodeId SessionSecurityDiagnosticsType_SecurityPolicyUri = new NodeId(2252u);

	public static readonly NodeId SessionSecurityDiagnosticsType_ClientCertificate = new NodeId(3058u);

	public static readonly NodeId OptionSetType_OptionSetValues = new NodeId(11488u);

	public static readonly NodeId OptionSetType_BitMask = new NodeId(11701u);

	public static readonly NodeId SelectionListType_Selections = new NodeId(17632u);

	public static readonly NodeId SelectionListType_SelectionDescriptions = new NodeId(17633u);

	public static readonly NodeId SelectionListType_RestrictToList = new NodeId(16312u);

	public static readonly NodeId AudioVariableType_ListId = new NodeId(17988u);

	public static readonly NodeId AudioVariableType_AgencyId = new NodeId(17989u);

	public static readonly NodeId AudioVariableType_VersionId = new NodeId(17990u);

	public static readonly NodeId Server_ServerArray = new NodeId(2254u);

	public static readonly NodeId Server_NamespaceArray = new NodeId(2255u);

	public static readonly NodeId Server_ServerStatus = new NodeId(2256u);

	public static readonly NodeId Server_ServerStatus_StartTime = new NodeId(2257u);

	public static readonly NodeId Server_ServerStatus_CurrentTime = new NodeId(2258u);

	public static readonly NodeId Server_ServerStatus_State = new NodeId(2259u);

	public static readonly NodeId Server_ServerStatus_BuildInfo = new NodeId(2260u);

	public static readonly NodeId Server_ServerStatus_BuildInfo_ProductUri = new NodeId(2262u);

	public static readonly NodeId Server_ServerStatus_BuildInfo_ManufacturerName = new NodeId(2263u);

	public static readonly NodeId Server_ServerStatus_BuildInfo_ProductName = new NodeId(2261u);

	public static readonly NodeId Server_ServerStatus_BuildInfo_SoftwareVersion = new NodeId(2264u);

	public static readonly NodeId Server_ServerStatus_BuildInfo_BuildNumber = new NodeId(2265u);

	public static readonly NodeId Server_ServerStatus_BuildInfo_BuildDate = new NodeId(2266u);

	public static readonly NodeId Server_ServerStatus_SecondsTillShutdown = new NodeId(2992u);

	public static readonly NodeId Server_ServerStatus_ShutdownReason = new NodeId(2993u);

	public static readonly NodeId Server_ServiceLevel = new NodeId(2267u);

	public static readonly NodeId Server_Auditing = new NodeId(2994u);

	public static readonly NodeId Server_EstimatedReturnTime = new NodeId(12885u);

	public static readonly NodeId Server_LocalTime = new NodeId(17634u);

	public static readonly NodeId Server_ServerCapabilities_ServerProfileArray = new NodeId(2269u);

	public static readonly NodeId Server_ServerCapabilities_LocaleIdArray = new NodeId(2271u);

	public static readonly NodeId Server_ServerCapabilities_MinSupportedSampleRate = new NodeId(2272u);

	public static readonly NodeId Server_ServerCapabilities_MaxBrowseContinuationPoints = new NodeId(2735u);

	public static readonly NodeId Server_ServerCapabilities_MaxQueryContinuationPoints = new NodeId(2736u);

	public static readonly NodeId Server_ServerCapabilities_MaxHistoryContinuationPoints = new NodeId(2737u);

	public static readonly NodeId Server_ServerCapabilities_SoftwareCertificates = new NodeId(3704u);

	public static readonly NodeId Server_ServerCapabilities_MaxArrayLength = new NodeId(11702u);

	public static readonly NodeId Server_ServerCapabilities_MaxStringLength = new NodeId(11703u);

	public static readonly NodeId Server_ServerCapabilities_MaxByteStringLength = new NodeId(12911u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerRead = new NodeId(11705u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerHistoryReadData = new NodeId(12165u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerHistoryReadEvents = new NodeId(12166u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerWrite = new NodeId(11707u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerHistoryUpdateData = new NodeId(12167u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerHistoryUpdateEvents = new NodeId(12168u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerMethodCall = new NodeId(11709u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerBrowse = new NodeId(11710u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerRegisterNodes = new NodeId(11711u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerTranslateBrowsePathsToNodeIds = new NodeId(11712u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxNodesPerNodeManagement = new NodeId(11713u);

	public static readonly NodeId Server_ServerCapabilities_OperationLimits_MaxMonitoredItemsPerCall = new NodeId(11714u);

	public static readonly NodeId Server_ServerCapabilities_RoleSet_AddRole_InputArguments = new NodeId(16302u);

	public static readonly NodeId Server_ServerCapabilities_RoleSet_AddRole_OutputArguments = new NodeId(16303u);

	public static readonly NodeId Server_ServerCapabilities_RoleSet_RemoveRole_InputArguments = new NodeId(16305u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary = new NodeId(2275u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_ServerViewCount = new NodeId(2276u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_CurrentSessionCount = new NodeId(2277u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_CumulatedSessionCount = new NodeId(2278u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_SecurityRejectedSessionCount = new NodeId(2279u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_RejectedSessionCount = new NodeId(3705u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_SessionTimeoutCount = new NodeId(2281u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_SessionAbortCount = new NodeId(2282u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_PublishingIntervalCount = new NodeId(2284u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_CurrentSubscriptionCount = new NodeId(2285u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_CumulatedSubscriptionCount = new NodeId(2286u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_SecurityRejectedRequestsCount = new NodeId(2287u);

	public static readonly NodeId Server_ServerDiagnostics_ServerDiagnosticsSummary_RejectedRequestsCount = new NodeId(2288u);

	public static readonly NodeId Server_ServerDiagnostics_SamplingIntervalDiagnosticsArray = new NodeId(2289u);

	public static readonly NodeId Server_ServerDiagnostics_SubscriptionDiagnosticsArray = new NodeId(2290u);

	public static readonly NodeId Server_ServerDiagnostics_SessionsDiagnosticsSummary_SessionDiagnosticsArray = new NodeId(3707u);

	public static readonly NodeId Server_ServerDiagnostics_SessionsDiagnosticsSummary_SessionSecurityDiagnosticsArray = new NodeId(3708u);

	public static readonly NodeId Server_ServerDiagnostics_EnabledFlag = new NodeId(2294u);

	public static readonly NodeId Server_ServerRedundancy_RedundancySupport = new NodeId(3709u);

	public static readonly NodeId Server_GetMonitoredItems_InputArguments = new NodeId(11493u);

	public static readonly NodeId Server_GetMonitoredItems_OutputArguments = new NodeId(11494u);

	public static readonly NodeId Server_ResendData_InputArguments = new NodeId(12874u);

	public static readonly NodeId Server_SetSubscriptionDurable_InputArguments = new NodeId(12750u);

	public static readonly NodeId Server_SetSubscriptionDurable_OutputArguments = new NodeId(12751u);

	public static readonly NodeId Server_RequestServerStateChange_InputArguments = new NodeId(12887u);

	public static readonly NodeId Server_ServerRedundancy_CurrentServerId = new NodeId(11312u);

	public static readonly NodeId Server_ServerRedundancy_RedundantServerArray = new NodeId(11313u);

	public static readonly NodeId Server_ServerRedundancy_ServerUriArray = new NodeId(11314u);

	public static readonly NodeId Server_ServerRedundancy_ServerNetworkGroups = new NodeId(14415u);

	public static readonly NodeId HistoryServerCapabilities_AccessHistoryDataCapability = new NodeId(11193u);

	public static readonly NodeId HistoryServerCapabilities_AccessHistoryEventsCapability = new NodeId(11242u);

	public static readonly NodeId HistoryServerCapabilities_MaxReturnDataValues = new NodeId(11273u);

	public static readonly NodeId HistoryServerCapabilities_MaxReturnEventValues = new NodeId(11274u);

	public static readonly NodeId HistoryServerCapabilities_InsertDataCapability = new NodeId(11196u);

	public static readonly NodeId HistoryServerCapabilities_ReplaceDataCapability = new NodeId(11197u);

	public static readonly NodeId HistoryServerCapabilities_UpdateDataCapability = new NodeId(11198u);

	public static readonly NodeId HistoryServerCapabilities_DeleteRawCapability = new NodeId(11199u);

	public static readonly NodeId HistoryServerCapabilities_DeleteAtTimeCapability = new NodeId(11200u);

	public static readonly NodeId HistoryServerCapabilities_InsertEventCapability = new NodeId(11281u);

	public static readonly NodeId HistoryServerCapabilities_ReplaceEventCapability = new NodeId(11282u);

	public static readonly NodeId HistoryServerCapabilities_UpdateEventCapability = new NodeId(11283u);

	public static readonly NodeId HistoryServerCapabilities_DeleteEventCapability = new NodeId(11502u);

	public static readonly NodeId HistoryServerCapabilities_InsertAnnotationCapability = new NodeId(11275u);

	public static readonly NodeId HistoryServerCapabilities_ServerTimestampSupported = new NodeId(19091u);

	public static readonly NodeId StateMachineType_CurrentState = new NodeId(2769u);

	public static readonly NodeId StateMachineType_CurrentState_Id = new NodeId(3720u);

	public static readonly NodeId StateMachineType_LastTransition = new NodeId(2770u);

	public static readonly NodeId StateMachineType_LastTransition_Id = new NodeId(3724u);

	public static readonly NodeId StateVariableType_Id = new NodeId(2756u);

	public static readonly NodeId StateVariableType_Name = new NodeId(2757u);

	public static readonly NodeId StateVariableType_Number = new NodeId(2758u);

	public static readonly NodeId StateVariableType_EffectiveDisplayName = new NodeId(2759u);

	public static readonly NodeId TransitionVariableType_Id = new NodeId(2763u);

	public static readonly NodeId TransitionVariableType_Name = new NodeId(2764u);

	public static readonly NodeId TransitionVariableType_Number = new NodeId(2765u);

	public static readonly NodeId TransitionVariableType_TransitionTime = new NodeId(2766u);

	public static readonly NodeId TransitionVariableType_EffectiveTransitionTime = new NodeId(11456u);

	public static readonly NodeId FiniteStateMachineType_CurrentState = new NodeId(2772u);

	public static readonly NodeId FiniteStateMachineType_CurrentState_Id = new NodeId(3728u);

	public static readonly NodeId FiniteStateMachineType_LastTransition = new NodeId(2773u);

	public static readonly NodeId FiniteStateMachineType_LastTransition_Id = new NodeId(3732u);

	public static readonly NodeId FiniteStateMachineType_AvailableStates = new NodeId(17635u);

	public static readonly NodeId FiniteStateMachineType_AvailableTransitions = new NodeId(17636u);

	public static readonly NodeId FiniteStateVariableType_Id = new NodeId(2761u);

	public static readonly NodeId FiniteTransitionVariableType_Id = new NodeId(2768u);

	public static readonly NodeId StateType_StateNumber = new NodeId(2308u);

	public static readonly NodeId TransitionType_TransitionNumber = new NodeId(2312u);

	public static readonly NodeId ExpressionGuardVariableType_Expression = new NodeId(15129u);

	public static readonly NodeId RationalNumberType_Numerator = new NodeId(17712u);

	public static readonly NodeId RationalNumberType_Denominator = new NodeId(17713u);

	public static readonly NodeId VectorType_VectorUnit = new NodeId(17715u);

	public static readonly NodeId ThreeDVectorType_X = new NodeId(18769u);

	public static readonly NodeId ThreeDVectorType_Y = new NodeId(18770u);

	public static readonly NodeId ThreeDVectorType_Z = new NodeId(18771u);

	public static readonly NodeId CartesianCoordinatesType_LengthUnit = new NodeId(18773u);

	public static readonly NodeId ThreeDCartesianCoordinatesType_X = new NodeId(18776u);

	public static readonly NodeId ThreeDCartesianCoordinatesType_Y = new NodeId(18777u);

	public static readonly NodeId ThreeDCartesianCoordinatesType_Z = new NodeId(18778u);

	public static readonly NodeId OrientationType_AngleUnit = new NodeId(18780u);

	public static readonly NodeId ThreeDOrientationType_A = new NodeId(18783u);

	public static readonly NodeId ThreeDOrientationType_B = new NodeId(18784u);

	public static readonly NodeId ThreeDOrientationType_C = new NodeId(18785u);

	public static readonly NodeId FrameType_CartesianCoordinates = new NodeId(18801u);

	public static readonly NodeId FrameType_Orientation = new NodeId(18787u);

	public static readonly NodeId FrameType_Constant = new NodeId(18788u);

	public static readonly NodeId FrameType_BaseFrame = new NodeId(18789u);

	public static readonly NodeId FrameType_FixedBase = new NodeId(18790u);

	public static readonly NodeId ThreeDFrameType_CartesianCoordinates = new NodeId(18796u);

	public static readonly NodeId ThreeDFrameType_Orientation = new NodeId(18792u);

	public static readonly NodeId ThreeDFrameType_CartesianCoordinates_X = new NodeId(18798u);

	public static readonly NodeId ThreeDFrameType_CartesianCoordinates_Y = new NodeId(18799u);

	public static readonly NodeId ThreeDFrameType_CartesianCoordinates_Z = new NodeId(18800u);

	public static readonly NodeId ThreeDFrameType_Orientation_A = new NodeId(19074u);

	public static readonly NodeId ThreeDFrameType_Orientation_B = new NodeId(19075u);

	public static readonly NodeId ThreeDFrameType_Orientation_C = new NodeId(19076u);

	public static readonly NodeId TransitionEventType_Transition = new NodeId(2774u);

	public static readonly NodeId TransitionEventType_Transition_Id = new NodeId(3754u);

	public static readonly NodeId TransitionEventType_FromState = new NodeId(2775u);

	public static readonly NodeId TransitionEventType_FromState_Id = new NodeId(3746u);

	public static readonly NodeId TransitionEventType_ToState = new NodeId(2776u);

	public static readonly NodeId TransitionEventType_ToState_Id = new NodeId(3750u);

	public static readonly NodeId AuditUpdateStateEventType_OldStateId = new NodeId(2777u);

	public static readonly NodeId AuditUpdateStateEventType_NewStateId = new NodeId(2778u);

	public static readonly NodeId OpenFileMode_EnumValues = new NodeId(11940u);

	public static readonly NodeId FileDirectoryType_FileDirectoryName_Placeholder_CreateDirectory_InputArguments = new NodeId(13356u);

	public static readonly NodeId FileDirectoryType_FileDirectoryName_Placeholder_CreateDirectory_OutputArguments = new NodeId(13357u);

	public static readonly NodeId FileDirectoryType_FileDirectoryName_Placeholder_CreateFile_InputArguments = new NodeId(13359u);

	public static readonly NodeId FileDirectoryType_FileDirectoryName_Placeholder_CreateFile_OutputArguments = new NodeId(13360u);

	public static readonly NodeId FileDirectoryType_FileDirectoryName_Placeholder_DeleteFileSystemObject_InputArguments = new NodeId(17719u);

	public static readonly NodeId FileDirectoryType_FileDirectoryName_Placeholder_MoveOrCopy_InputArguments = new NodeId(13364u);

	public static readonly NodeId FileDirectoryType_FileDirectoryName_Placeholder_MoveOrCopy_OutputArguments = new NodeId(13365u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_Size = new NodeId(13367u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_Writable = new NodeId(13368u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_UserWritable = new NodeId(13369u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_OpenCount = new NodeId(13370u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_Open_InputArguments = new NodeId(13373u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_Open_OutputArguments = new NodeId(13374u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_Close_InputArguments = new NodeId(13376u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_Read_InputArguments = new NodeId(13378u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_Read_OutputArguments = new NodeId(13379u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_Write_InputArguments = new NodeId(13381u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_GetPosition_InputArguments = new NodeId(13383u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_GetPosition_OutputArguments = new NodeId(13384u);

	public static readonly NodeId FileDirectoryType_FileName_Placeholder_SetPosition_InputArguments = new NodeId(13386u);

	public static readonly NodeId FileDirectoryType_CreateDirectory_InputArguments = new NodeId(13388u);

	public static readonly NodeId FileDirectoryType_CreateDirectory_OutputArguments = new NodeId(13389u);

	public static readonly NodeId FileDirectoryType_CreateFile_InputArguments = new NodeId(13391u);

	public static readonly NodeId FileDirectoryType_CreateFile_OutputArguments = new NodeId(13392u);

	public static readonly NodeId FileDirectoryType_DeleteFileSystemObject_InputArguments = new NodeId(13394u);

	public static readonly NodeId FileDirectoryType_MoveOrCopy_InputArguments = new NodeId(13396u);

	public static readonly NodeId FileDirectoryType_MoveOrCopy_OutputArguments = new NodeId(13397u);

	public static readonly NodeId FileSystem_FileDirectoryName_Placeholder_CreateDirectory_InputArguments = new NodeId(16317u);

	public static readonly NodeId FileSystem_FileDirectoryName_Placeholder_CreateDirectory_OutputArguments = new NodeId(16318u);

	public static readonly NodeId FileSystem_FileDirectoryName_Placeholder_CreateFile_InputArguments = new NodeId(16320u);

	public static readonly NodeId FileSystem_FileDirectoryName_Placeholder_CreateFile_OutputArguments = new NodeId(16321u);

	public static readonly NodeId FileSystem_FileDirectoryName_Placeholder_DeleteFileSystemObject_InputArguments = new NodeId(17723u);

	public static readonly NodeId FileSystem_FileDirectoryName_Placeholder_MoveOrCopy_InputArguments = new NodeId(16325u);

	public static readonly NodeId FileSystem_FileDirectoryName_Placeholder_MoveOrCopy_OutputArguments = new NodeId(16326u);

	public static readonly NodeId FileSystem_FileName_Placeholder_Size = new NodeId(16328u);

	public static readonly NodeId FileSystem_FileName_Placeholder_Writable = new NodeId(16329u);

	public static readonly NodeId FileSystem_FileName_Placeholder_UserWritable = new NodeId(16330u);

	public static readonly NodeId FileSystem_FileName_Placeholder_OpenCount = new NodeId(16331u);

	public static readonly NodeId FileSystem_FileName_Placeholder_Open_InputArguments = new NodeId(16334u);

	public static readonly NodeId FileSystem_FileName_Placeholder_Open_OutputArguments = new NodeId(16335u);

	public static readonly NodeId FileSystem_FileName_Placeholder_Close_InputArguments = new NodeId(16337u);

	public static readonly NodeId FileSystem_FileName_Placeholder_Read_InputArguments = new NodeId(16339u);

	public static readonly NodeId FileSystem_FileName_Placeholder_Read_OutputArguments = new NodeId(16340u);

	public static readonly NodeId FileSystem_FileName_Placeholder_Write_InputArguments = new NodeId(16342u);

	public static readonly NodeId FileSystem_FileName_Placeholder_GetPosition_InputArguments = new NodeId(16344u);

	public static readonly NodeId FileSystem_FileName_Placeholder_GetPosition_OutputArguments = new NodeId(16345u);

	public static readonly NodeId FileSystem_FileName_Placeholder_SetPosition_InputArguments = new NodeId(16347u);

	public static readonly NodeId FileSystem_CreateDirectory_InputArguments = new NodeId(16349u);

	public static readonly NodeId FileSystem_CreateDirectory_OutputArguments = new NodeId(16350u);

	public static readonly NodeId FileSystem_CreateFile_InputArguments = new NodeId(16352u);

	public static readonly NodeId FileSystem_CreateFile_OutputArguments = new NodeId(16353u);

	public static readonly NodeId FileSystem_DeleteFileSystemObject_InputArguments = new NodeId(16355u);

	public static readonly NodeId FileSystem_MoveOrCopy_InputArguments = new NodeId(16357u);

	public static readonly NodeId FileSystem_MoveOrCopy_OutputArguments = new NodeId(16358u);

	public static readonly NodeId TemporaryFileTransferType_ClientProcessingTimeout = new NodeId(15745u);

	public static readonly NodeId TemporaryFileTransferType_GenerateFileForRead_InputArguments = new NodeId(15747u);

	public static readonly NodeId TemporaryFileTransferType_GenerateFileForRead_OutputArguments = new NodeId(15748u);

	public static readonly NodeId TemporaryFileTransferType_GenerateFileForWrite_InputArguments = new NodeId(16359u);

	public static readonly NodeId TemporaryFileTransferType_GenerateFileForWrite_OutputArguments = new NodeId(15750u);

	public static readonly NodeId TemporaryFileTransferType_CloseAndCommit_InputArguments = new NodeId(15752u);

	public static readonly NodeId TemporaryFileTransferType_CloseAndCommit_OutputArguments = new NodeId(15753u);

	public static readonly NodeId TemporaryFileTransferType_TransferState_Placeholder_CurrentState = new NodeId(15755u);

	public static readonly NodeId TemporaryFileTransferType_TransferState_Placeholder_CurrentState_Id = new NodeId(15756u);

	public static readonly NodeId TemporaryFileTransferType_TransferState_Placeholder_LastTransition_Id = new NodeId(15761u);

	public static readonly NodeId FileTransferStateMachineType_CurrentState_Id = new NodeId(15805u);

	public static readonly NodeId FileTransferStateMachineType_LastTransition_Id = new NodeId(15810u);

	public static readonly NodeId FileTransferStateMachineType_Idle_StateNumber = new NodeId(15816u);

	public static readonly NodeId FileTransferStateMachineType_ReadPrepare_StateNumber = new NodeId(15818u);

	public static readonly NodeId FileTransferStateMachineType_ReadTransfer_StateNumber = new NodeId(15820u);

	public static readonly NodeId FileTransferStateMachineType_ApplyWrite_StateNumber = new NodeId(15822u);

	public static readonly NodeId FileTransferStateMachineType_Error_StateNumber = new NodeId(15824u);

	public static readonly NodeId FileTransferStateMachineType_IdleToReadPrepare_TransitionNumber = new NodeId(15826u);

	public static readonly NodeId FileTransferStateMachineType_ReadPrepareToReadTransfer_TransitionNumber = new NodeId(15828u);

	public static readonly NodeId FileTransferStateMachineType_ReadTransferToIdle_TransitionNumber = new NodeId(15830u);

	public static readonly NodeId FileTransferStateMachineType_IdleToApplyWrite_TransitionNumber = new NodeId(15832u);

	public static readonly NodeId FileTransferStateMachineType_ApplyWriteToIdle_TransitionNumber = new NodeId(15834u);

	public static readonly NodeId FileTransferStateMachineType_ReadPrepareToError_TransitionNumber = new NodeId(15836u);

	public static readonly NodeId FileTransferStateMachineType_ReadTransferToError_TransitionNumber = new NodeId(15838u);

	public static readonly NodeId FileTransferStateMachineType_ApplyWriteToError_TransitionNumber = new NodeId(15840u);

	public static readonly NodeId FileTransferStateMachineType_ErrorToIdle_TransitionNumber = new NodeId(15842u);

	public static readonly NodeId RoleSetType_RoleName_Placeholder_Identities = new NodeId(16162u);

	public static readonly NodeId RoleSetType_RoleName_Placeholder_AddIdentity_InputArguments = new NodeId(15613u);

	public static readonly NodeId RoleSetType_RoleName_Placeholder_RemoveIdentity_InputArguments = new NodeId(15615u);

	public static readonly NodeId RoleSetType_RoleName_Placeholder_AddApplication_InputArguments = new NodeId(16166u);

	public static readonly NodeId RoleSetType_RoleName_Placeholder_RemoveApplication_InputArguments = new NodeId(16168u);

	public static readonly NodeId RoleSetType_RoleName_Placeholder_AddEndpoint_InputArguments = new NodeId(16170u);

	public static readonly NodeId RoleSetType_RoleName_Placeholder_RemoveEndpoint_InputArguments = new NodeId(16172u);

	public static readonly NodeId RoleSetType_AddRole_InputArguments = new NodeId(15998u);

	public static readonly NodeId RoleSetType_AddRole_OutputArguments = new NodeId(15999u);

	public static readonly NodeId RoleSetType_RemoveRole_InputArguments = new NodeId(16001u);

	public static readonly NodeId RoleType_Identities = new NodeId(16173u);

	public static readonly NodeId RoleType_Applications = new NodeId(16174u);

	public static readonly NodeId RoleType_ApplicationsExclude = new NodeId(15410u);

	public static readonly NodeId RoleType_Endpoints = new NodeId(16175u);

	public static readonly NodeId RoleType_EndpointsExclude = new NodeId(15411u);

	public static readonly NodeId RoleType_AddIdentity_InputArguments = new NodeId(15625u);

	public static readonly NodeId RoleType_RemoveIdentity_InputArguments = new NodeId(15627u);

	public static readonly NodeId RoleType_AddApplication_InputArguments = new NodeId(16177u);

	public static readonly NodeId RoleType_RemoveApplication_InputArguments = new NodeId(16179u);

	public static readonly NodeId RoleType_AddEndpoint_InputArguments = new NodeId(16181u);

	public static readonly NodeId RoleType_RemoveEndpoint_InputArguments = new NodeId(16183u);

	public static readonly NodeId IdentityCriteriaType_EnumValues = new NodeId(15633u);

	public static readonly NodeId WellKnownRole_Anonymous_Identities = new NodeId(16192u);

	public static readonly NodeId WellKnownRole_Anonymous_Applications = new NodeId(16193u);

	public static readonly NodeId WellKnownRole_Anonymous_ApplicationsExclude = new NodeId(15412u);

	public static readonly NodeId WellKnownRole_Anonymous_Endpoints = new NodeId(16194u);

	public static readonly NodeId WellKnownRole_Anonymous_EndpointsExclude = new NodeId(15413u);

	public static readonly NodeId WellKnownRole_Anonymous_AddIdentity_InputArguments = new NodeId(15649u);

	public static readonly NodeId WellKnownRole_Anonymous_RemoveIdentity_InputArguments = new NodeId(15651u);

	public static readonly NodeId WellKnownRole_Anonymous_AddApplication_InputArguments = new NodeId(16196u);

	public static readonly NodeId WellKnownRole_Anonymous_RemoveApplication_InputArguments = new NodeId(16198u);

	public static readonly NodeId WellKnownRole_Anonymous_AddEndpoint_InputArguments = new NodeId(16200u);

	public static readonly NodeId WellKnownRole_Anonymous_RemoveEndpoint_InputArguments = new NodeId(16202u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_Identities = new NodeId(16203u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_Applications = new NodeId(16204u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_ApplicationsExclude = new NodeId(15414u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_Endpoints = new NodeId(16205u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_EndpointsExclude = new NodeId(15415u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_AddIdentity_InputArguments = new NodeId(15661u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_RemoveIdentity_InputArguments = new NodeId(15663u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_AddApplication_InputArguments = new NodeId(16207u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_RemoveApplication_InputArguments = new NodeId(16209u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_AddEndpoint_InputArguments = new NodeId(16211u);

	public static readonly NodeId WellKnownRole_AuthenticatedUser_RemoveEndpoint_InputArguments = new NodeId(16213u);

	public static readonly NodeId WellKnownRole_Observer_Identities = new NodeId(16214u);

	public static readonly NodeId WellKnownRole_Observer_Applications = new NodeId(16215u);

	public static readonly NodeId WellKnownRole_Observer_ApplicationsExclude = new NodeId(15416u);

	public static readonly NodeId WellKnownRole_Observer_Endpoints = new NodeId(16216u);

	public static readonly NodeId WellKnownRole_Observer_EndpointsExclude = new NodeId(15417u);

	public static readonly NodeId WellKnownRole_Observer_AddIdentity_InputArguments = new NodeId(15673u);

	public static readonly NodeId WellKnownRole_Observer_RemoveIdentity_InputArguments = new NodeId(15675u);

	public static readonly NodeId WellKnownRole_Observer_AddApplication_InputArguments = new NodeId(16218u);

	public static readonly NodeId WellKnownRole_Observer_RemoveApplication_InputArguments = new NodeId(16220u);

	public static readonly NodeId WellKnownRole_Observer_AddEndpoint_InputArguments = new NodeId(16222u);

	public static readonly NodeId WellKnownRole_Observer_RemoveEndpoint_InputArguments = new NodeId(16224u);

	public static readonly NodeId WellKnownRole_Operator_Identities = new NodeId(16225u);

	public static readonly NodeId WellKnownRole_Operator_Applications = new NodeId(16226u);

	public static readonly NodeId WellKnownRole_Operator_ApplicationsExclude = new NodeId(15418u);

	public static readonly NodeId WellKnownRole_Operator_Endpoints = new NodeId(16227u);

	public static readonly NodeId WellKnownRole_Operator_EndpointsExclude = new NodeId(15423u);

	public static readonly NodeId WellKnownRole_Operator_AddIdentity_InputArguments = new NodeId(15685u);

	public static readonly NodeId WellKnownRole_Operator_RemoveIdentity_InputArguments = new NodeId(15687u);

	public static readonly NodeId WellKnownRole_Operator_AddApplication_InputArguments = new NodeId(16229u);

	public static readonly NodeId WellKnownRole_Operator_RemoveApplication_InputArguments = new NodeId(16231u);

	public static readonly NodeId WellKnownRole_Operator_AddEndpoint_InputArguments = new NodeId(16233u);

	public static readonly NodeId WellKnownRole_Operator_RemoveEndpoint_InputArguments = new NodeId(16235u);

	public static readonly NodeId WellKnownRole_Engineer_Identities = new NodeId(16236u);

	public static readonly NodeId WellKnownRole_Engineer_Applications = new NodeId(16237u);

	public static readonly NodeId WellKnownRole_Engineer_ApplicationsExclude = new NodeId(15424u);

	public static readonly NodeId WellKnownRole_Engineer_Endpoints = new NodeId(16238u);

	public static readonly NodeId WellKnownRole_Engineer_EndpointsExclude = new NodeId(15425u);

	public static readonly NodeId WellKnownRole_Engineer_AddIdentity_InputArguments = new NodeId(16042u);

	public static readonly NodeId WellKnownRole_Engineer_RemoveIdentity_InputArguments = new NodeId(16044u);

	public static readonly NodeId WellKnownRole_Engineer_AddApplication_InputArguments = new NodeId(16240u);

	public static readonly NodeId WellKnownRole_Engineer_RemoveApplication_InputArguments = new NodeId(16242u);

	public static readonly NodeId WellKnownRole_Engineer_AddEndpoint_InputArguments = new NodeId(16244u);

	public static readonly NodeId WellKnownRole_Engineer_RemoveEndpoint_InputArguments = new NodeId(16246u);

	public static readonly NodeId WellKnownRole_Supervisor_Identities = new NodeId(16247u);

	public static readonly NodeId WellKnownRole_Supervisor_Applications = new NodeId(16248u);

	public static readonly NodeId WellKnownRole_Supervisor_ApplicationsExclude = new NodeId(15426u);

	public static readonly NodeId WellKnownRole_Supervisor_Endpoints = new NodeId(16249u);

	public static readonly NodeId WellKnownRole_Supervisor_EndpointsExclude = new NodeId(15427u);

	public static readonly NodeId WellKnownRole_Supervisor_AddIdentity_InputArguments = new NodeId(15697u);

	public static readonly NodeId WellKnownRole_Supervisor_RemoveIdentity_InputArguments = new NodeId(15699u);

	public static readonly NodeId WellKnownRole_Supervisor_AddApplication_InputArguments = new NodeId(16251u);

	public static readonly NodeId WellKnownRole_Supervisor_RemoveApplication_InputArguments = new NodeId(16253u);

	public static readonly NodeId WellKnownRole_Supervisor_AddEndpoint_InputArguments = new NodeId(16255u);

	public static readonly NodeId WellKnownRole_Supervisor_RemoveEndpoint_InputArguments = new NodeId(16257u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_Identities = new NodeId(16269u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_Applications = new NodeId(16270u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_ApplicationsExclude = new NodeId(15428u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_Endpoints = new NodeId(16271u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_EndpointsExclude = new NodeId(15429u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_AddIdentity_InputArguments = new NodeId(15721u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_RemoveIdentity_InputArguments = new NodeId(15723u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_AddApplication_InputArguments = new NodeId(16273u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_RemoveApplication_InputArguments = new NodeId(16275u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_AddEndpoint_InputArguments = new NodeId(16277u);

	public static readonly NodeId WellKnownRole_ConfigureAdmin_RemoveEndpoint_InputArguments = new NodeId(16279u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_Identities = new NodeId(16258u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_Applications = new NodeId(16259u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_ApplicationsExclude = new NodeId(15430u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_Endpoints = new NodeId(16260u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_EndpointsExclude = new NodeId(15527u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_AddIdentity_InputArguments = new NodeId(15709u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_RemoveIdentity_InputArguments = new NodeId(15711u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_AddApplication_InputArguments = new NodeId(16262u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_RemoveApplication_InputArguments = new NodeId(16264u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_AddEndpoint_InputArguments = new NodeId(16266u);

	public static readonly NodeId WellKnownRole_SecurityAdmin_RemoveEndpoint_InputArguments = new NodeId(16268u);

	public static readonly NodeId CurrencyUnit = new NodeId(23501u);

	public static readonly NodeId IOrderedObjectType_NumberInList = new NodeId(23517u);

	public static readonly NodeId OrderedListType_OrderedObject_Placeholder_NumberInList = new NodeId(23521u);

	public static readonly NodeId OrderedListType_NodeVersion = new NodeId(23525u);

	public static readonly NodeId DataItemType_Definition = new NodeId(2366u);

	public static readonly NodeId DataItemType_ValuePrecision = new NodeId(2367u);

	public static readonly NodeId BaseAnalogType_InstrumentRange = new NodeId(17567u);

	public static readonly NodeId BaseAnalogType_EURange = new NodeId(17568u);

	public static readonly NodeId BaseAnalogType_EngineeringUnits = new NodeId(17569u);

	public static readonly NodeId AnalogItemType_EURange = new NodeId(2369u);

	public static readonly NodeId AnalogUnitType_EngineeringUnits = new NodeId(17502u);

	public static readonly NodeId AnalogUnitRangeType_EngineeringUnits = new NodeId(17575u);

	public static readonly NodeId TwoStateDiscreteType_FalseState = new NodeId(2374u);

	public static readonly NodeId TwoStateDiscreteType_TrueState = new NodeId(2375u);

	public static readonly NodeId MultiStateDiscreteType_EnumStrings = new NodeId(2377u);

	public static readonly NodeId MultiStateValueDiscreteType_EnumValues = new NodeId(11241u);

	public static readonly NodeId MultiStateValueDiscreteType_ValueAsText = new NodeId(11461u);

	public static readonly NodeId ArrayItemType_InstrumentRange = new NodeId(12024u);

	public static readonly NodeId ArrayItemType_EURange = new NodeId(12025u);

	public static readonly NodeId ArrayItemType_EngineeringUnits = new NodeId(12026u);

	public static readonly NodeId ArrayItemType_Title = new NodeId(12027u);

	public static readonly NodeId ArrayItemType_AxisScaleType = new NodeId(12028u);

	public static readonly NodeId YArrayItemType_XAxisDefinition = new NodeId(12037u);

	public static readonly NodeId XYArrayItemType_XAxisDefinition = new NodeId(12046u);

	public static readonly NodeId ImageItemType_XAxisDefinition = new NodeId(12055u);

	public static readonly NodeId ImageItemType_YAxisDefinition = new NodeId(12056u);

	public static readonly NodeId CubeItemType_XAxisDefinition = new NodeId(12065u);

	public static readonly NodeId CubeItemType_YAxisDefinition = new NodeId(12066u);

	public static readonly NodeId CubeItemType_ZAxisDefinition = new NodeId(12067u);

	public static readonly NodeId NDimensionArrayItemType_AxisDefinition = new NodeId(12076u);

	public static readonly NodeId TwoStateVariableType_Id = new NodeId(8996u);

	public static readonly NodeId TwoStateVariableType_TransitionTime = new NodeId(9000u);

	public static readonly NodeId TwoStateVariableType_EffectiveTransitionTime = new NodeId(9001u);

	public static readonly NodeId TwoStateVariableType_TrueState = new NodeId(11110u);

	public static readonly NodeId TwoStateVariableType_FalseState = new NodeId(11111u);

	public static readonly NodeId ConditionVariableType_SourceTimestamp = new NodeId(9003u);

	public static readonly NodeId ConditionType_ConditionClassId = new NodeId(11112u);

	public static readonly NodeId ConditionType_ConditionClassName = new NodeId(11113u);

	public static readonly NodeId ConditionType_ConditionSubClassId = new NodeId(16363u);

	public static readonly NodeId ConditionType_ConditionSubClassName = new NodeId(16364u);

	public static readonly NodeId ConditionType_ConditionName = new NodeId(9009u);

	public static readonly NodeId ConditionType_BranchId = new NodeId(9010u);

	public static readonly NodeId ConditionType_Retain = new NodeId(3874u);

	public static readonly NodeId ConditionType_EnabledState = new NodeId(9011u);

	public static readonly NodeId ConditionType_EnabledState_Id = new NodeId(9012u);

	public static readonly NodeId ConditionType_EnabledState_EffectiveDisplayName = new NodeId(9015u);

	public static readonly NodeId ConditionType_EnabledState_TransitionTime = new NodeId(9016u);

	public static readonly NodeId ConditionType_EnabledState_EffectiveTransitionTime = new NodeId(9017u);

	public static readonly NodeId ConditionType_EnabledState_TrueState = new NodeId(9018u);

	public static readonly NodeId ConditionType_EnabledState_FalseState = new NodeId(9019u);

	public static readonly NodeId ConditionType_Quality = new NodeId(9020u);

	public static readonly NodeId ConditionType_Quality_SourceTimestamp = new NodeId(9021u);

	public static readonly NodeId ConditionType_LastSeverity = new NodeId(9022u);

	public static readonly NodeId ConditionType_LastSeverity_SourceTimestamp = new NodeId(9023u);

	public static readonly NodeId ConditionType_Comment = new NodeId(9024u);

	public static readonly NodeId ConditionType_Comment_SourceTimestamp = new NodeId(9025u);

	public static readonly NodeId ConditionType_ClientUserId = new NodeId(9026u);

	public static readonly NodeId ConditionType_AddComment_InputArguments = new NodeId(9030u);

	public static readonly NodeId ConditionType_ConditionRefresh_InputArguments = new NodeId(3876u);

	public static readonly NodeId ConditionType_ConditionRefresh2_InputArguments = new NodeId(12913u);

	public static readonly NodeId DialogConditionType_EnabledState = new NodeId(9035u);

	public static readonly NodeId DialogConditionType_EnabledState_Id = new NodeId(9036u);

	public static readonly NodeId DialogConditionType_Quality_SourceTimestamp = new NodeId(9045u);

	public static readonly NodeId DialogConditionType_LastSeverity_SourceTimestamp = new NodeId(9047u);

	public static readonly NodeId DialogConditionType_Comment_SourceTimestamp = new NodeId(9049u);

	public static readonly NodeId DialogConditionType_AddComment_InputArguments = new NodeId(9054u);

	public static readonly NodeId DialogConditionType_ConditionRefresh_InputArguments = new NodeId(4199u);

	public static readonly NodeId DialogConditionType_ConditionRefresh2_InputArguments = new NodeId(12917u);

	public static readonly NodeId DialogConditionType_DialogState = new NodeId(9055u);

	public static readonly NodeId DialogConditionType_DialogState_Id = new NodeId(9056u);

	public static readonly NodeId DialogConditionType_DialogState_TransitionTime = new NodeId(9060u);

	public static readonly NodeId DialogConditionType_DialogState_TrueState = new NodeId(9062u);

	public static readonly NodeId DialogConditionType_DialogState_FalseState = new NodeId(9063u);

	public static readonly NodeId DialogConditionType_Prompt = new NodeId(2831u);

	public static readonly NodeId DialogConditionType_ResponseOptionSet = new NodeId(9064u);

	public static readonly NodeId DialogConditionType_DefaultResponse = new NodeId(9065u);

	public static readonly NodeId DialogConditionType_OkResponse = new NodeId(9066u);

	public static readonly NodeId DialogConditionType_CancelResponse = new NodeId(9067u);

	public static readonly NodeId DialogConditionType_LastResponse = new NodeId(9068u);

	public static readonly NodeId DialogConditionType_Respond_InputArguments = new NodeId(9070u);

	public static readonly NodeId AcknowledgeableConditionType_EnabledState = new NodeId(9073u);

	public static readonly NodeId AcknowledgeableConditionType_EnabledState_Id = new NodeId(9074u);

	public static readonly NodeId AcknowledgeableConditionType_Quality_SourceTimestamp = new NodeId(9083u);

	public static readonly NodeId AcknowledgeableConditionType_LastSeverity_SourceTimestamp = new NodeId(9085u);

	public static readonly NodeId AcknowledgeableConditionType_Comment_SourceTimestamp = new NodeId(9087u);

	public static readonly NodeId AcknowledgeableConditionType_AddComment_InputArguments = new NodeId(9092u);

	public static readonly NodeId AcknowledgeableConditionType_ConditionRefresh_InputArguments = new NodeId(5124u);

	public static readonly NodeId AcknowledgeableConditionType_ConditionRefresh2_InputArguments = new NodeId(12919u);

	public static readonly NodeId AcknowledgeableConditionType_AckedState = new NodeId(9093u);

	public static readonly NodeId AcknowledgeableConditionType_AckedState_Id = new NodeId(9094u);

	public static readonly NodeId AcknowledgeableConditionType_AckedState_TransitionTime = new NodeId(9098u);

	public static readonly NodeId AcknowledgeableConditionType_AckedState_TrueState = new NodeId(9100u);

	public static readonly NodeId AcknowledgeableConditionType_AckedState_FalseState = new NodeId(9101u);

	public static readonly NodeId AcknowledgeableConditionType_ConfirmedState = new NodeId(9102u);

	public static readonly NodeId AcknowledgeableConditionType_ConfirmedState_Id = new NodeId(9103u);

	public static readonly NodeId AcknowledgeableConditionType_ConfirmedState_TransitionTime = new NodeId(9107u);

	public static readonly NodeId AcknowledgeableConditionType_ConfirmedState_TrueState = new NodeId(9109u);

	public static readonly NodeId AcknowledgeableConditionType_ConfirmedState_FalseState = new NodeId(9110u);

	public static readonly NodeId AcknowledgeableConditionType_Acknowledge_InputArguments = new NodeId(9112u);

	public static readonly NodeId AcknowledgeableConditionType_Confirm_InputArguments = new NodeId(9114u);

	public static readonly NodeId AlarmConditionType_EnabledState = new NodeId(9118u);

	public static readonly NodeId AlarmConditionType_EnabledState_Id = new NodeId(9119u);

	public static readonly NodeId AlarmConditionType_Quality_SourceTimestamp = new NodeId(9128u);

	public static readonly NodeId AlarmConditionType_LastSeverity_SourceTimestamp = new NodeId(9130u);

	public static readonly NodeId AlarmConditionType_Comment_SourceTimestamp = new NodeId(9132u);

	public static readonly NodeId AlarmConditionType_AddComment_InputArguments = new NodeId(9137u);

	public static readonly NodeId AlarmConditionType_ConditionRefresh_InputArguments = new NodeId(5551u);

	public static readonly NodeId AlarmConditionType_ConditionRefresh2_InputArguments = new NodeId(12985u);

	public static readonly NodeId AlarmConditionType_AckedState_Id = new NodeId(9139u);

	public static readonly NodeId AlarmConditionType_ConfirmedState_Id = new NodeId(9148u);

	public static readonly NodeId AlarmConditionType_Acknowledge_InputArguments = new NodeId(9157u);

	public static readonly NodeId AlarmConditionType_Confirm_InputArguments = new NodeId(9159u);

	public static readonly NodeId AlarmConditionType_ActiveState = new NodeId(9160u);

	public static readonly NodeId AlarmConditionType_ActiveState_Id = new NodeId(9161u);

	public static readonly NodeId AlarmConditionType_ActiveState_EffectiveDisplayName = new NodeId(9164u);

	public static readonly NodeId AlarmConditionType_ActiveState_TransitionTime = new NodeId(9165u);

	public static readonly NodeId AlarmConditionType_ActiveState_EffectiveTransitionTime = new NodeId(9166u);

	public static readonly NodeId AlarmConditionType_ActiveState_TrueState = new NodeId(9167u);

	public static readonly NodeId AlarmConditionType_ActiveState_FalseState = new NodeId(9168u);

	public static readonly NodeId AlarmConditionType_InputNode = new NodeId(11120u);

	public static readonly NodeId AlarmConditionType_SuppressedState = new NodeId(9169u);

	public static readonly NodeId AlarmConditionType_SuppressedState_Id = new NodeId(9170u);

	public static readonly NodeId AlarmConditionType_SuppressedState_TransitionTime = new NodeId(9174u);

	public static readonly NodeId AlarmConditionType_SuppressedState_TrueState = new NodeId(9176u);

	public static readonly NodeId AlarmConditionType_SuppressedState_FalseState = new NodeId(9177u);

	public static readonly NodeId AlarmConditionType_OutOfServiceState = new NodeId(16371u);

	public static readonly NodeId AlarmConditionType_OutOfServiceState_Id = new NodeId(16372u);

	public static readonly NodeId AlarmConditionType_OutOfServiceState_TransitionTime = new NodeId(16376u);

	public static readonly NodeId AlarmConditionType_OutOfServiceState_TrueState = new NodeId(16378u);

	public static readonly NodeId AlarmConditionType_OutOfServiceState_FalseState = new NodeId(16379u);

	public static readonly NodeId AlarmConditionType_ShelvingState_CurrentState = new NodeId(9179u);

	public static readonly NodeId AlarmConditionType_ShelvingState_CurrentState_Id = new NodeId(9180u);

	public static readonly NodeId AlarmConditionType_ShelvingState_LastTransition = new NodeId(9184u);

	public static readonly NodeId AlarmConditionType_ShelvingState_LastTransition_Id = new NodeId(9185u);

	public static readonly NodeId AlarmConditionType_ShelvingState_LastTransition_TransitionTime = new NodeId(9188u);

	public static readonly NodeId AlarmConditionType_ShelvingState_UnshelveTime = new NodeId(9189u);

	public static readonly NodeId AlarmConditionType_ShelvingState_TimedShelve_InputArguments = new NodeId(9214u);

	public static readonly NodeId AlarmConditionType_SuppressedOrShelved = new NodeId(9215u);

	public static readonly NodeId AlarmConditionType_MaxTimeShelved = new NodeId(9216u);

	public static readonly NodeId AlarmConditionType_AudibleEnabled = new NodeId(16389u);

	public static readonly NodeId AlarmConditionType_AudibleSound = new NodeId(16390u);

	public static readonly NodeId AlarmConditionType_SilenceState = new NodeId(16380u);

	public static readonly NodeId AlarmConditionType_SilenceState_Id = new NodeId(16381u);

	public static readonly NodeId AlarmConditionType_SilenceState_TransitionTime = new NodeId(16385u);

	public static readonly NodeId AlarmConditionType_SilenceState_TrueState = new NodeId(16387u);

	public static readonly NodeId AlarmConditionType_SilenceState_FalseState = new NodeId(16388u);

	public static readonly NodeId AlarmConditionType_OnDelay = new NodeId(16395u);

	public static readonly NodeId AlarmConditionType_OffDelay = new NodeId(16396u);

	public static readonly NodeId AlarmConditionType_FirstInGroupFlag = new NodeId(16397u);

	public static readonly NodeId AlarmConditionType_LatchedState = new NodeId(18190u);

	public static readonly NodeId AlarmConditionType_LatchedState_Id = new NodeId(18191u);

	public static readonly NodeId AlarmConditionType_LatchedState_TransitionTime = new NodeId(18195u);

	public static readonly NodeId AlarmConditionType_LatchedState_TrueState = new NodeId(18197u);

	public static readonly NodeId AlarmConditionType_LatchedState_FalseState = new NodeId(18198u);

	public static readonly NodeId AlarmConditionType_ReAlarmTime = new NodeId(16400u);

	public static readonly NodeId AlarmConditionType_ReAlarmRepeatCount = new NodeId(16401u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_EventId = new NodeId(16407u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_EventType = new NodeId(16408u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_SourceNode = new NodeId(16409u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_SourceName = new NodeId(16410u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Time = new NodeId(16411u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ReceiveTime = new NodeId(16412u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Message = new NodeId(16414u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Severity = new NodeId(16415u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ConditionClassId = new NodeId(16416u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ConditionClassName = new NodeId(16417u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ConditionName = new NodeId(16420u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_BranchId = new NodeId(16421u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Retain = new NodeId(16422u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_EnabledState = new NodeId(16423u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_EnabledState_Id = new NodeId(16424u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Quality = new NodeId(16432u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Quality_SourceTimestamp = new NodeId(16433u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_LastSeverity = new NodeId(16434u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_LastSeverity_SourceTimestamp = new NodeId(16435u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Comment = new NodeId(16436u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Comment_SourceTimestamp = new NodeId(16437u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ClientUserId = new NodeId(16438u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_AddComment_InputArguments = new NodeId(16442u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_AckedState = new NodeId(16443u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_AckedState_Id = new NodeId(16444u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ConfirmedState_Id = new NodeId(16453u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Acknowledge_InputArguments = new NodeId(16462u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_Confirm_InputArguments = new NodeId(16464u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ActiveState = new NodeId(16465u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ActiveState_Id = new NodeId(16466u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_InputNode = new NodeId(16474u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_SuppressedState_Id = new NodeId(16476u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_OutOfServiceState_Id = new NodeId(16485u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ShelvingState_CurrentState = new NodeId(16503u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ShelvingState_CurrentState_Id = new NodeId(16504u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ShelvingState_LastTransition_Id = new NodeId(16509u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ShelvingState_UnshelveTime = new NodeId(16514u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_ShelvingState_TimedShelve_InputArguments = new NodeId(16518u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_SuppressedOrShelved = new NodeId(16519u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_SilenceState_Id = new NodeId(16494u);

	public static readonly NodeId AlarmGroupType_AlarmConditionInstance_Placeholder_LatchedState_Id = new NodeId(18204u);

	public static readonly NodeId ShelvedStateMachineType_CurrentState_Id = new NodeId(6089u);

	public static readonly NodeId ShelvedStateMachineType_LastTransition_Id = new NodeId(6094u);

	public static readonly NodeId ShelvedStateMachineType_UnshelveTime = new NodeId(9115u);

	public static readonly NodeId ShelvedStateMachineType_Unshelved_StateNumber = new NodeId(6098u);

	public static readonly NodeId ShelvedStateMachineType_TimedShelved_StateNumber = new NodeId(6100u);

	public static readonly NodeId ShelvedStateMachineType_OneShotShelved_StateNumber = new NodeId(6101u);

	public static readonly NodeId ShelvedStateMachineType_UnshelvedToTimedShelved_TransitionNumber = new NodeId(11322u);

	public static readonly NodeId ShelvedStateMachineType_UnshelvedToOneShotShelved_TransitionNumber = new NodeId(11323u);

	public static readonly NodeId ShelvedStateMachineType_TimedShelvedToUnshelved_TransitionNumber = new NodeId(11324u);

	public static readonly NodeId ShelvedStateMachineType_TimedShelvedToOneShotShelved_TransitionNumber = new NodeId(11325u);

	public static readonly NodeId ShelvedStateMachineType_OneShotShelvedToUnshelved_TransitionNumber = new NodeId(11326u);

	public static readonly NodeId ShelvedStateMachineType_OneShotShelvedToTimedShelved_TransitionNumber = new NodeId(11327u);

	public static readonly NodeId ShelvedStateMachineType_TimedShelve_InputArguments = new NodeId(2991u);

	public static readonly NodeId LimitAlarmType_EnabledState_Id = new NodeId(9220u);

	public static readonly NodeId LimitAlarmType_Quality_SourceTimestamp = new NodeId(9229u);

	public static readonly NodeId LimitAlarmType_LastSeverity_SourceTimestamp = new NodeId(9231u);

	public static readonly NodeId LimitAlarmType_Comment_SourceTimestamp = new NodeId(9233u);

	public static readonly NodeId LimitAlarmType_AddComment_InputArguments = new NodeId(9238u);

	public static readonly NodeId LimitAlarmType_ConditionRefresh_InputArguments = new NodeId(6127u);

	public static readonly NodeId LimitAlarmType_ConditionRefresh2_InputArguments = new NodeId(12987u);

	public static readonly NodeId LimitAlarmType_AckedState_Id = new NodeId(9240u);

	public static readonly NodeId LimitAlarmType_ConfirmedState_Id = new NodeId(9249u);

	public static readonly NodeId LimitAlarmType_Acknowledge_InputArguments = new NodeId(9258u);

	public static readonly NodeId LimitAlarmType_Confirm_InputArguments = new NodeId(9260u);

	public static readonly NodeId LimitAlarmType_ActiveState_Id = new NodeId(9262u);

	public static readonly NodeId LimitAlarmType_SuppressedState_Id = new NodeId(9271u);

	public static readonly NodeId LimitAlarmType_OutOfServiceState_Id = new NodeId(16539u);

	public static readonly NodeId LimitAlarmType_ShelvingState_CurrentState = new NodeId(9280u);

	public static readonly NodeId LimitAlarmType_ShelvingState_CurrentState_Id = new NodeId(9281u);

	public static readonly NodeId LimitAlarmType_ShelvingState_LastTransition_Id = new NodeId(9286u);

	public static readonly NodeId LimitAlarmType_ShelvingState_UnshelveTime = new NodeId(9290u);

	public static readonly NodeId LimitAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(9315u);

	public static readonly NodeId LimitAlarmType_SilenceState_Id = new NodeId(16548u);

	public static readonly NodeId LimitAlarmType_LatchedState_Id = new NodeId(18214u);

	public static readonly NodeId LimitAlarmType_HighHighLimit = new NodeId(11124u);

	public static readonly NodeId LimitAlarmType_HighLimit = new NodeId(11125u);

	public static readonly NodeId LimitAlarmType_LowLimit = new NodeId(11126u);

	public static readonly NodeId LimitAlarmType_LowLowLimit = new NodeId(11127u);

	public static readonly NodeId LimitAlarmType_BaseHighHighLimit = new NodeId(16572u);

	public static readonly NodeId LimitAlarmType_BaseHighLimit = new NodeId(16573u);

	public static readonly NodeId LimitAlarmType_BaseLowLimit = new NodeId(16574u);

	public static readonly NodeId LimitAlarmType_BaseLowLowLimit = new NodeId(16575u);

	public static readonly NodeId ExclusiveLimitStateMachineType_CurrentState_Id = new NodeId(9320u);

	public static readonly NodeId ExclusiveLimitStateMachineType_LastTransition_Id = new NodeId(9325u);

	public static readonly NodeId ExclusiveLimitStateMachineType_HighHigh_StateNumber = new NodeId(9330u);

	public static readonly NodeId ExclusiveLimitStateMachineType_High_StateNumber = new NodeId(9332u);

	public static readonly NodeId ExclusiveLimitStateMachineType_Low_StateNumber = new NodeId(9334u);

	public static readonly NodeId ExclusiveLimitStateMachineType_LowLow_StateNumber = new NodeId(9336u);

	public static readonly NodeId ExclusiveLimitStateMachineType_LowLowToLow_TransitionNumber = new NodeId(11340u);

	public static readonly NodeId ExclusiveLimitStateMachineType_LowToLowLow_TransitionNumber = new NodeId(11341u);

	public static readonly NodeId ExclusiveLimitStateMachineType_HighHighToHigh_TransitionNumber = new NodeId(11342u);

	public static readonly NodeId ExclusiveLimitStateMachineType_HighToHighHigh_TransitionNumber = new NodeId(11343u);

	public static readonly NodeId ExclusiveLimitAlarmType_EnabledState_Id = new NodeId(9355u);

	public static readonly NodeId ExclusiveLimitAlarmType_Quality_SourceTimestamp = new NodeId(9364u);

	public static readonly NodeId ExclusiveLimitAlarmType_LastSeverity_SourceTimestamp = new NodeId(9366u);

	public static readonly NodeId ExclusiveLimitAlarmType_Comment_SourceTimestamp = new NodeId(9368u);

	public static readonly NodeId ExclusiveLimitAlarmType_AddComment_InputArguments = new NodeId(9373u);

	public static readonly NodeId ExclusiveLimitAlarmType_ConditionRefresh_InputArguments = new NodeId(9375u);

	public static readonly NodeId ExclusiveLimitAlarmType_ConditionRefresh2_InputArguments = new NodeId(12989u);

	public static readonly NodeId ExclusiveLimitAlarmType_AckedState_Id = new NodeId(9377u);

	public static readonly NodeId ExclusiveLimitAlarmType_ConfirmedState_Id = new NodeId(9386u);

	public static readonly NodeId ExclusiveLimitAlarmType_Acknowledge_InputArguments = new NodeId(9395u);

	public static readonly NodeId ExclusiveLimitAlarmType_Confirm_InputArguments = new NodeId(9397u);

	public static readonly NodeId ExclusiveLimitAlarmType_ActiveState = new NodeId(9398u);

	public static readonly NodeId ExclusiveLimitAlarmType_ActiveState_Id = new NodeId(9399u);

	public static readonly NodeId ExclusiveLimitAlarmType_SuppressedState_Id = new NodeId(9408u);

	public static readonly NodeId ExclusiveLimitAlarmType_OutOfServiceState_Id = new NodeId(16579u);

	public static readonly NodeId ExclusiveLimitAlarmType_ShelvingState_CurrentState = new NodeId(9417u);

	public static readonly NodeId ExclusiveLimitAlarmType_ShelvingState_CurrentState_Id = new NodeId(9418u);

	public static readonly NodeId ExclusiveLimitAlarmType_ShelvingState_LastTransition_Id = new NodeId(9423u);

	public static readonly NodeId ExclusiveLimitAlarmType_ShelvingState_UnshelveTime = new NodeId(9427u);

	public static readonly NodeId ExclusiveLimitAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(9452u);

	public static readonly NodeId ExclusiveLimitAlarmType_SilenceState_Id = new NodeId(16588u);

	public static readonly NodeId ExclusiveLimitAlarmType_LatchedState_Id = new NodeId(18224u);

	public static readonly NodeId ExclusiveLimitAlarmType_LimitState_CurrentState = new NodeId(9456u);

	public static readonly NodeId ExclusiveLimitAlarmType_LimitState_CurrentState_Id = new NodeId(9457u);

	public static readonly NodeId ExclusiveLimitAlarmType_LimitState_LastTransition = new NodeId(9461u);

	public static readonly NodeId ExclusiveLimitAlarmType_LimitState_LastTransition_Id = new NodeId(9462u);

	public static readonly NodeId ExclusiveLimitAlarmType_LimitState_LastTransition_TransitionTime = new NodeId(9465u);

	public static readonly NodeId NonExclusiveLimitAlarmType_EnabledState_Id = new NodeId(9920u);

	public static readonly NodeId NonExclusiveLimitAlarmType_Quality_SourceTimestamp = new NodeId(9929u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LastSeverity_SourceTimestamp = new NodeId(9931u);

	public static readonly NodeId NonExclusiveLimitAlarmType_Comment_SourceTimestamp = new NodeId(9933u);

	public static readonly NodeId NonExclusiveLimitAlarmType_AddComment_InputArguments = new NodeId(9938u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ConditionRefresh_InputArguments = new NodeId(9940u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ConditionRefresh2_InputArguments = new NodeId(12991u);

	public static readonly NodeId NonExclusiveLimitAlarmType_AckedState_Id = new NodeId(9942u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ConfirmedState_Id = new NodeId(9951u);

	public static readonly NodeId NonExclusiveLimitAlarmType_Acknowledge_InputArguments = new NodeId(9960u);

	public static readonly NodeId NonExclusiveLimitAlarmType_Confirm_InputArguments = new NodeId(9962u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ActiveState = new NodeId(9963u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ActiveState_Id = new NodeId(9964u);

	public static readonly NodeId NonExclusiveLimitAlarmType_SuppressedState_Id = new NodeId(9973u);

	public static readonly NodeId NonExclusiveLimitAlarmType_OutOfServiceState_Id = new NodeId(16619u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ShelvingState_CurrentState = new NodeId(9982u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ShelvingState_CurrentState_Id = new NodeId(9983u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ShelvingState_LastTransition_Id = new NodeId(9988u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ShelvingState_UnshelveTime = new NodeId(9992u);

	public static readonly NodeId NonExclusiveLimitAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(10017u);

	public static readonly NodeId NonExclusiveLimitAlarmType_SilenceState_Id = new NodeId(16628u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LatchedState_Id = new NodeId(18234u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighHighState = new NodeId(10020u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighHighState_Id = new NodeId(10021u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighHighState_TransitionTime = new NodeId(10025u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighHighState_TrueState = new NodeId(10027u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighHighState_FalseState = new NodeId(10028u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighState = new NodeId(10029u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighState_Id = new NodeId(10030u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighState_TransitionTime = new NodeId(10034u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighState_TrueState = new NodeId(10036u);

	public static readonly NodeId NonExclusiveLimitAlarmType_HighState_FalseState = new NodeId(10037u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowState = new NodeId(10038u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowState_Id = new NodeId(10039u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowState_TransitionTime = new NodeId(10043u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowState_TrueState = new NodeId(10045u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowState_FalseState = new NodeId(10046u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowLowState = new NodeId(10047u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowLowState_Id = new NodeId(10048u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowLowState_TransitionTime = new NodeId(10052u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowLowState_TrueState = new NodeId(10054u);

	public static readonly NodeId NonExclusiveLimitAlarmType_LowLowState_FalseState = new NodeId(10055u);

	public static readonly NodeId NonExclusiveLevelAlarmType_EnabledState_Id = new NodeId(10074u);

	public static readonly NodeId NonExclusiveLevelAlarmType_Quality_SourceTimestamp = new NodeId(10083u);

	public static readonly NodeId NonExclusiveLevelAlarmType_LastSeverity_SourceTimestamp = new NodeId(10085u);

	public static readonly NodeId NonExclusiveLevelAlarmType_Comment_SourceTimestamp = new NodeId(10087u);

	public static readonly NodeId NonExclusiveLevelAlarmType_AddComment_InputArguments = new NodeId(10092u);

	public static readonly NodeId NonExclusiveLevelAlarmType_ConditionRefresh_InputArguments = new NodeId(10094u);

	public static readonly NodeId NonExclusiveLevelAlarmType_ConditionRefresh2_InputArguments = new NodeId(12993u);

	public static readonly NodeId NonExclusiveLevelAlarmType_AckedState_Id = new NodeId(10096u);

	public static readonly NodeId NonExclusiveLevelAlarmType_ConfirmedState_Id = new NodeId(10105u);

	public static readonly NodeId NonExclusiveLevelAlarmType_Acknowledge_InputArguments = new NodeId(10114u);

	public static readonly NodeId NonExclusiveLevelAlarmType_Confirm_InputArguments = new NodeId(10116u);

	public static readonly NodeId NonExclusiveLevelAlarmType_ActiveState_Id = new NodeId(10118u);

	public static readonly NodeId NonExclusiveLevelAlarmType_SuppressedState_Id = new NodeId(10127u);

	public static readonly NodeId NonExclusiveLevelAlarmType_OutOfServiceState_Id = new NodeId(16659u);

	public static readonly NodeId NonExclusiveLevelAlarmType_ShelvingState_CurrentState = new NodeId(10136u);

	public static readonly NodeId NonExclusiveLevelAlarmType_ShelvingState_CurrentState_Id = new NodeId(10137u);

	public static readonly NodeId NonExclusiveLevelAlarmType_ShelvingState_LastTransition_Id = new NodeId(10142u);

	public static readonly NodeId NonExclusiveLevelAlarmType_ShelvingState_UnshelveTime = new NodeId(10146u);

	public static readonly NodeId NonExclusiveLevelAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(10171u);

	public static readonly NodeId NonExclusiveLevelAlarmType_SilenceState_Id = new NodeId(16668u);

	public static readonly NodeId NonExclusiveLevelAlarmType_LatchedState_Id = new NodeId(18247u);

	public static readonly NodeId NonExclusiveLevelAlarmType_HighHighState_Id = new NodeId(10175u);

	public static readonly NodeId NonExclusiveLevelAlarmType_HighState_Id = new NodeId(10184u);

	public static readonly NodeId NonExclusiveLevelAlarmType_LowState_Id = new NodeId(10193u);

	public static readonly NodeId NonExclusiveLevelAlarmType_LowLowState_Id = new NodeId(10202u);

	public static readonly NodeId ExclusiveLevelAlarmType_EnabledState_Id = new NodeId(9496u);

	public static readonly NodeId ExclusiveLevelAlarmType_Quality_SourceTimestamp = new NodeId(9505u);

	public static readonly NodeId ExclusiveLevelAlarmType_LastSeverity_SourceTimestamp = new NodeId(9507u);

	public static readonly NodeId ExclusiveLevelAlarmType_Comment_SourceTimestamp = new NodeId(9509u);

	public static readonly NodeId ExclusiveLevelAlarmType_AddComment_InputArguments = new NodeId(9514u);

	public static readonly NodeId ExclusiveLevelAlarmType_ConditionRefresh_InputArguments = new NodeId(9516u);

	public static readonly NodeId ExclusiveLevelAlarmType_ConditionRefresh2_InputArguments = new NodeId(12995u);

	public static readonly NodeId ExclusiveLevelAlarmType_AckedState_Id = new NodeId(9518u);

	public static readonly NodeId ExclusiveLevelAlarmType_ConfirmedState_Id = new NodeId(9527u);

	public static readonly NodeId ExclusiveLevelAlarmType_Acknowledge_InputArguments = new NodeId(9536u);

	public static readonly NodeId ExclusiveLevelAlarmType_Confirm_InputArguments = new NodeId(9538u);

	public static readonly NodeId ExclusiveLevelAlarmType_ActiveState_Id = new NodeId(9540u);

	public static readonly NodeId ExclusiveLevelAlarmType_SuppressedState_Id = new NodeId(9549u);

	public static readonly NodeId ExclusiveLevelAlarmType_OutOfServiceState_Id = new NodeId(16699u);

	public static readonly NodeId ExclusiveLevelAlarmType_ShelvingState_CurrentState = new NodeId(9558u);

	public static readonly NodeId ExclusiveLevelAlarmType_ShelvingState_CurrentState_Id = new NodeId(9559u);

	public static readonly NodeId ExclusiveLevelAlarmType_ShelvingState_LastTransition_Id = new NodeId(9564u);

	public static readonly NodeId ExclusiveLevelAlarmType_ShelvingState_UnshelveTime = new NodeId(9568u);

	public static readonly NodeId ExclusiveLevelAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(9593u);

	public static readonly NodeId ExclusiveLevelAlarmType_SilenceState_Id = new NodeId(16708u);

	public static readonly NodeId ExclusiveLevelAlarmType_LatchedState_Id = new NodeId(18258u);

	public static readonly NodeId ExclusiveLevelAlarmType_LimitState_CurrentState = new NodeId(9597u);

	public static readonly NodeId ExclusiveLevelAlarmType_LimitState_CurrentState_Id = new NodeId(9598u);

	public static readonly NodeId ExclusiveLevelAlarmType_LimitState_LastTransition_Id = new NodeId(9603u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_EnabledState_Id = new NodeId(10382u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_Quality_SourceTimestamp = new NodeId(10391u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_LastSeverity_SourceTimestamp = new NodeId(10393u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_Comment_SourceTimestamp = new NodeId(10395u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_AddComment_InputArguments = new NodeId(10400u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_ConditionRefresh_InputArguments = new NodeId(10402u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_ConditionRefresh2_InputArguments = new NodeId(12997u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_AckedState_Id = new NodeId(10404u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_ConfirmedState_Id = new NodeId(10413u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_Acknowledge_InputArguments = new NodeId(10422u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_Confirm_InputArguments = new NodeId(10424u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_ActiveState_Id = new NodeId(10426u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_SuppressedState_Id = new NodeId(10435u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_OutOfServiceState_Id = new NodeId(16739u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_ShelvingState_CurrentState = new NodeId(10444u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_ShelvingState_CurrentState_Id = new NodeId(10445u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_ShelvingState_LastTransition_Id = new NodeId(10450u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_ShelvingState_UnshelveTime = new NodeId(10454u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(10479u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_SilenceState_Id = new NodeId(16748u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_LatchedState_Id = new NodeId(18268u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_HighHighState_Id = new NodeId(10483u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_HighState_Id = new NodeId(10492u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_LowState_Id = new NodeId(10501u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_LowLowState_Id = new NodeId(10510u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_SetpointNode = new NodeId(10522u);

	public static readonly NodeId NonExclusiveDeviationAlarmType_BaseSetpointNode = new NodeId(16776u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_EnabledState_Id = new NodeId(10228u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_Quality_SourceTimestamp = new NodeId(10237u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_LastSeverity_SourceTimestamp = new NodeId(10239u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_Comment_SourceTimestamp = new NodeId(10241u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_AddComment_InputArguments = new NodeId(10246u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_ConditionRefresh_InputArguments = new NodeId(10248u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_ConditionRefresh2_InputArguments = new NodeId(13001u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_AckedState_Id = new NodeId(10250u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_ConfirmedState_Id = new NodeId(10259u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_Acknowledge_InputArguments = new NodeId(10268u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_Confirm_InputArguments = new NodeId(10270u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_ActiveState_Id = new NodeId(10272u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_SuppressedState_Id = new NodeId(10281u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_OutOfServiceState_Id = new NodeId(16821u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_ShelvingState_CurrentState = new NodeId(10290u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_ShelvingState_CurrentState_Id = new NodeId(10291u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_ShelvingState_LastTransition_Id = new NodeId(10296u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_ShelvingState_UnshelveTime = new NodeId(10300u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(10325u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_SilenceState_Id = new NodeId(16830u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_LatchedState_Id = new NodeId(18278u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_HighHighState_Id = new NodeId(10329u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_HighState_Id = new NodeId(10338u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_LowState_Id = new NodeId(10347u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_LowLowState_Id = new NodeId(10356u);

	public static readonly NodeId NonExclusiveRateOfChangeAlarmType_EngineeringUnits = new NodeId(16858u);

	public static readonly NodeId ExclusiveDeviationAlarmType_EnabledState_Id = new NodeId(9778u);

	public static readonly NodeId ExclusiveDeviationAlarmType_Quality_SourceTimestamp = new NodeId(9787u);

	public static readonly NodeId ExclusiveDeviationAlarmType_LastSeverity_SourceTimestamp = new NodeId(9789u);

	public static readonly NodeId ExclusiveDeviationAlarmType_Comment_SourceTimestamp = new NodeId(9791u);

	public static readonly NodeId ExclusiveDeviationAlarmType_AddComment_InputArguments = new NodeId(9796u);

	public static readonly NodeId ExclusiveDeviationAlarmType_ConditionRefresh_InputArguments = new NodeId(9798u);

	public static readonly NodeId ExclusiveDeviationAlarmType_ConditionRefresh2_InputArguments = new NodeId(12999u);

	public static readonly NodeId ExclusiveDeviationAlarmType_AckedState_Id = new NodeId(9800u);

	public static readonly NodeId ExclusiveDeviationAlarmType_ConfirmedState_Id = new NodeId(9809u);

	public static readonly NodeId ExclusiveDeviationAlarmType_Acknowledge_InputArguments = new NodeId(9818u);

	public static readonly NodeId ExclusiveDeviationAlarmType_Confirm_InputArguments = new NodeId(9820u);

	public static readonly NodeId ExclusiveDeviationAlarmType_ActiveState_Id = new NodeId(9822u);

	public static readonly NodeId ExclusiveDeviationAlarmType_SuppressedState_Id = new NodeId(9831u);

	public static readonly NodeId ExclusiveDeviationAlarmType_OutOfServiceState_Id = new NodeId(16780u);

	public static readonly NodeId ExclusiveDeviationAlarmType_ShelvingState_CurrentState = new NodeId(9840u);

	public static readonly NodeId ExclusiveDeviationAlarmType_ShelvingState_CurrentState_Id = new NodeId(9841u);

	public static readonly NodeId ExclusiveDeviationAlarmType_ShelvingState_LastTransition_Id = new NodeId(9846u);

	public static readonly NodeId ExclusiveDeviationAlarmType_ShelvingState_UnshelveTime = new NodeId(9850u);

	public static readonly NodeId ExclusiveDeviationAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(9875u);

	public static readonly NodeId ExclusiveDeviationAlarmType_SilenceState_Id = new NodeId(16789u);

	public static readonly NodeId ExclusiveDeviationAlarmType_LatchedState_Id = new NodeId(18288u);

	public static readonly NodeId ExclusiveDeviationAlarmType_LimitState_CurrentState = new NodeId(9879u);

	public static readonly NodeId ExclusiveDeviationAlarmType_LimitState_CurrentState_Id = new NodeId(9880u);

	public static readonly NodeId ExclusiveDeviationAlarmType_LimitState_LastTransition_Id = new NodeId(9885u);

	public static readonly NodeId ExclusiveDeviationAlarmType_SetpointNode = new NodeId(9905u);

	public static readonly NodeId ExclusiveDeviationAlarmType_BaseSetpointNode = new NodeId(16817u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_EnabledState_Id = new NodeId(9637u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_Quality_SourceTimestamp = new NodeId(9646u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_LastSeverity_SourceTimestamp = new NodeId(9648u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_Comment_SourceTimestamp = new NodeId(9650u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_AddComment_InputArguments = new NodeId(9655u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_ConditionRefresh_InputArguments = new NodeId(9657u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_ConditionRefresh2_InputArguments = new NodeId(13003u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_AckedState_Id = new NodeId(9659u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_ConfirmedState_Id = new NodeId(9668u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_Acknowledge_InputArguments = new NodeId(9677u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_Confirm_InputArguments = new NodeId(9679u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_ActiveState_Id = new NodeId(9681u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_SuppressedState_Id = new NodeId(9690u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_OutOfServiceState_Id = new NodeId(16862u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_ShelvingState_CurrentState = new NodeId(9699u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_ShelvingState_CurrentState_Id = new NodeId(9700u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_ShelvingState_LastTransition_Id = new NodeId(9705u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_ShelvingState_UnshelveTime = new NodeId(9709u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(9734u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_SilenceState_Id = new NodeId(16871u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_LatchedState_Id = new NodeId(18298u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_LimitState_CurrentState = new NodeId(9738u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_LimitState_CurrentState_Id = new NodeId(9739u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_LimitState_LastTransition_Id = new NodeId(9744u);

	public static readonly NodeId ExclusiveRateOfChangeAlarmType_EngineeringUnits = new NodeId(16899u);

	public static readonly NodeId DiscreteAlarmType_EnabledState_Id = new NodeId(10537u);

	public static readonly NodeId DiscreteAlarmType_Quality_SourceTimestamp = new NodeId(10546u);

	public static readonly NodeId DiscreteAlarmType_LastSeverity_SourceTimestamp = new NodeId(10548u);

	public static readonly NodeId DiscreteAlarmType_Comment_SourceTimestamp = new NodeId(10550u);

	public static readonly NodeId DiscreteAlarmType_AddComment_InputArguments = new NodeId(10555u);

	public static readonly NodeId DiscreteAlarmType_ConditionRefresh_InputArguments = new NodeId(10557u);

	public static readonly NodeId DiscreteAlarmType_ConditionRefresh2_InputArguments = new NodeId(13005u);

	public static readonly NodeId DiscreteAlarmType_AckedState_Id = new NodeId(10559u);

	public static readonly NodeId DiscreteAlarmType_ConfirmedState_Id = new NodeId(10568u);

	public static readonly NodeId DiscreteAlarmType_Acknowledge_InputArguments = new NodeId(10577u);

	public static readonly NodeId DiscreteAlarmType_Confirm_InputArguments = new NodeId(10579u);

	public static readonly NodeId DiscreteAlarmType_ActiveState_Id = new NodeId(10581u);

	public static readonly NodeId DiscreteAlarmType_SuppressedState_Id = new NodeId(10590u);

	public static readonly NodeId DiscreteAlarmType_OutOfServiceState_Id = new NodeId(16903u);

	public static readonly NodeId DiscreteAlarmType_ShelvingState_CurrentState = new NodeId(10599u);

	public static readonly NodeId DiscreteAlarmType_ShelvingState_CurrentState_Id = new NodeId(10600u);

	public static readonly NodeId DiscreteAlarmType_ShelvingState_LastTransition_Id = new NodeId(10605u);

	public static readonly NodeId DiscreteAlarmType_ShelvingState_UnshelveTime = new NodeId(10609u);

	public static readonly NodeId DiscreteAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(10634u);

	public static readonly NodeId DiscreteAlarmType_SilenceState_Id = new NodeId(16912u);

	public static readonly NodeId DiscreteAlarmType_LatchedState_Id = new NodeId(18308u);

	public static readonly NodeId OffNormalAlarmType_EnabledState_Id = new NodeId(10651u);

	public static readonly NodeId OffNormalAlarmType_Quality_SourceTimestamp = new NodeId(10660u);

	public static readonly NodeId OffNormalAlarmType_LastSeverity_SourceTimestamp = new NodeId(10662u);

	public static readonly NodeId OffNormalAlarmType_Comment_SourceTimestamp = new NodeId(10664u);

	public static readonly NodeId OffNormalAlarmType_AddComment_InputArguments = new NodeId(10669u);

	public static readonly NodeId OffNormalAlarmType_ConditionRefresh_InputArguments = new NodeId(10671u);

	public static readonly NodeId OffNormalAlarmType_ConditionRefresh2_InputArguments = new NodeId(13007u);

	public static readonly NodeId OffNormalAlarmType_AckedState_Id = new NodeId(10673u);

	public static readonly NodeId OffNormalAlarmType_ConfirmedState_Id = new NodeId(10682u);

	public static readonly NodeId OffNormalAlarmType_Acknowledge_InputArguments = new NodeId(10691u);

	public static readonly NodeId OffNormalAlarmType_Confirm_InputArguments = new NodeId(10693u);

	public static readonly NodeId OffNormalAlarmType_ActiveState_Id = new NodeId(10695u);

	public static readonly NodeId OffNormalAlarmType_SuppressedState_Id = new NodeId(10704u);

	public static readonly NodeId OffNormalAlarmType_OutOfServiceState_Id = new NodeId(16939u);

	public static readonly NodeId OffNormalAlarmType_ShelvingState_CurrentState = new NodeId(10713u);

	public static readonly NodeId OffNormalAlarmType_ShelvingState_CurrentState_Id = new NodeId(10714u);

	public static readonly NodeId OffNormalAlarmType_ShelvingState_LastTransition_Id = new NodeId(10719u);

	public static readonly NodeId OffNormalAlarmType_ShelvingState_UnshelveTime = new NodeId(10723u);

	public static readonly NodeId OffNormalAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(10748u);

	public static readonly NodeId OffNormalAlarmType_SilenceState_Id = new NodeId(16948u);

	public static readonly NodeId OffNormalAlarmType_LatchedState_Id = new NodeId(18318u);

	public static readonly NodeId OffNormalAlarmType_NormalState = new NodeId(11158u);

	public static readonly NodeId SystemOffNormalAlarmType_EnabledState_Id = new NodeId(11769u);

	public static readonly NodeId SystemOffNormalAlarmType_Quality_SourceTimestamp = new NodeId(11778u);

	public static readonly NodeId SystemOffNormalAlarmType_LastSeverity_SourceTimestamp = new NodeId(11780u);

	public static readonly NodeId SystemOffNormalAlarmType_Comment_SourceTimestamp = new NodeId(11782u);

	public static readonly NodeId SystemOffNormalAlarmType_AddComment_InputArguments = new NodeId(11787u);

	public static readonly NodeId SystemOffNormalAlarmType_ConditionRefresh_InputArguments = new NodeId(11789u);

	public static readonly NodeId SystemOffNormalAlarmType_ConditionRefresh2_InputArguments = new NodeId(13009u);

	public static readonly NodeId SystemOffNormalAlarmType_AckedState_Id = new NodeId(11791u);

	public static readonly NodeId SystemOffNormalAlarmType_ConfirmedState_Id = new NodeId(11800u);

	public static readonly NodeId SystemOffNormalAlarmType_Acknowledge_InputArguments = new NodeId(11809u);

	public static readonly NodeId SystemOffNormalAlarmType_Confirm_InputArguments = new NodeId(11811u);

	public static readonly NodeId SystemOffNormalAlarmType_ActiveState_Id = new NodeId(11813u);

	public static readonly NodeId SystemOffNormalAlarmType_SuppressedState_Id = new NodeId(11823u);

	public static readonly NodeId SystemOffNormalAlarmType_OutOfServiceState_Id = new NodeId(16975u);

	public static readonly NodeId SystemOffNormalAlarmType_ShelvingState_CurrentState = new NodeId(11832u);

	public static readonly NodeId SystemOffNormalAlarmType_ShelvingState_CurrentState_Id = new NodeId(11833u);

	public static readonly NodeId SystemOffNormalAlarmType_ShelvingState_LastTransition_Id = new NodeId(11838u);

	public static readonly NodeId SystemOffNormalAlarmType_ShelvingState_UnshelveTime = new NodeId(11843u);

	public static readonly NodeId SystemOffNormalAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(11847u);

	public static readonly NodeId SystemOffNormalAlarmType_SilenceState_Id = new NodeId(16984u);

	public static readonly NodeId SystemOffNormalAlarmType_LatchedState_Id = new NodeId(18328u);

	public static readonly NodeId TripAlarmType_EnabledState_Id = new NodeId(10765u);

	public static readonly NodeId TripAlarmType_Quality_SourceTimestamp = new NodeId(10774u);

	public static readonly NodeId TripAlarmType_LastSeverity_SourceTimestamp = new NodeId(10776u);

	public static readonly NodeId TripAlarmType_Comment_SourceTimestamp = new NodeId(10778u);

	public static readonly NodeId TripAlarmType_AddComment_InputArguments = new NodeId(10783u);

	public static readonly NodeId TripAlarmType_ConditionRefresh_InputArguments = new NodeId(10785u);

	public static readonly NodeId TripAlarmType_ConditionRefresh2_InputArguments = new NodeId(13011u);

	public static readonly NodeId TripAlarmType_AckedState_Id = new NodeId(10787u);

	public static readonly NodeId TripAlarmType_ConfirmedState_Id = new NodeId(10796u);

	public static readonly NodeId TripAlarmType_Acknowledge_InputArguments = new NodeId(10805u);

	public static readonly NodeId TripAlarmType_Confirm_InputArguments = new NodeId(10807u);

	public static readonly NodeId TripAlarmType_ActiveState_Id = new NodeId(10809u);

	public static readonly NodeId TripAlarmType_SuppressedState_Id = new NodeId(10818u);

	public static readonly NodeId TripAlarmType_OutOfServiceState_Id = new NodeId(17011u);

	public static readonly NodeId TripAlarmType_ShelvingState_CurrentState = new NodeId(10827u);

	public static readonly NodeId TripAlarmType_ShelvingState_CurrentState_Id = new NodeId(10828u);

	public static readonly NodeId TripAlarmType_ShelvingState_LastTransition_Id = new NodeId(10833u);

	public static readonly NodeId TripAlarmType_ShelvingState_UnshelveTime = new NodeId(10837u);

	public static readonly NodeId TripAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(10862u);

	public static readonly NodeId TripAlarmType_SilenceState_Id = new NodeId(17020u);

	public static readonly NodeId TripAlarmType_LatchedState_Id = new NodeId(18338u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_EnabledState_Id = new NodeId(18365u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_Quality_SourceTimestamp = new NodeId(18374u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_LastSeverity_SourceTimestamp = new NodeId(18376u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_Comment_SourceTimestamp = new NodeId(18378u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_AddComment_InputArguments = new NodeId(18383u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_ConditionRefresh_InputArguments = new NodeId(18385u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_ConditionRefresh2_InputArguments = new NodeId(18387u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_AckedState_Id = new NodeId(18389u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_ConfirmedState_Id = new NodeId(18398u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_Acknowledge_InputArguments = new NodeId(18407u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_Confirm_InputArguments = new NodeId(18409u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_ActiveState_Id = new NodeId(18411u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_SuppressedState_Id = new NodeId(18421u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_OutOfServiceState_Id = new NodeId(18430u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_ShelvingState_CurrentState = new NodeId(18439u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_ShelvingState_CurrentState_Id = new NodeId(18440u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_ShelvingState_LastTransition_Id = new NodeId(18445u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_ShelvingState_UnshelveTime = new NodeId(18452u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(18454u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_SilenceState_Id = new NodeId(18465u);

	public static readonly NodeId InstrumentDiagnosticAlarmType_LatchedState_Id = new NodeId(18478u);

	public static readonly NodeId SystemDiagnosticAlarmType_EnabledState_Id = new NodeId(18514u);

	public static readonly NodeId SystemDiagnosticAlarmType_Quality_SourceTimestamp = new NodeId(18523u);

	public static readonly NodeId SystemDiagnosticAlarmType_LastSeverity_SourceTimestamp = new NodeId(18525u);

	public static readonly NodeId SystemDiagnosticAlarmType_Comment_SourceTimestamp = new NodeId(18527u);

	public static readonly NodeId SystemDiagnosticAlarmType_AddComment_InputArguments = new NodeId(18532u);

	public static readonly NodeId SystemDiagnosticAlarmType_ConditionRefresh_InputArguments = new NodeId(18534u);

	public static readonly NodeId SystemDiagnosticAlarmType_ConditionRefresh2_InputArguments = new NodeId(18536u);

	public static readonly NodeId SystemDiagnosticAlarmType_AckedState_Id = new NodeId(18538u);

	public static readonly NodeId SystemDiagnosticAlarmType_ConfirmedState_Id = new NodeId(18547u);

	public static readonly NodeId SystemDiagnosticAlarmType_Acknowledge_InputArguments = new NodeId(18556u);

	public static readonly NodeId SystemDiagnosticAlarmType_Confirm_InputArguments = new NodeId(18558u);

	public static readonly NodeId SystemDiagnosticAlarmType_ActiveState_Id = new NodeId(18560u);

	public static readonly NodeId SystemDiagnosticAlarmType_SuppressedState_Id = new NodeId(18570u);

	public static readonly NodeId SystemDiagnosticAlarmType_OutOfServiceState_Id = new NodeId(18579u);

	public static readonly NodeId SystemDiagnosticAlarmType_ShelvingState_CurrentState = new NodeId(18588u);

	public static readonly NodeId SystemDiagnosticAlarmType_ShelvingState_CurrentState_Id = new NodeId(18589u);

	public static readonly NodeId SystemDiagnosticAlarmType_ShelvingState_LastTransition_Id = new NodeId(18594u);

	public static readonly NodeId SystemDiagnosticAlarmType_ShelvingState_UnshelveTime = new NodeId(18601u);

	public static readonly NodeId SystemDiagnosticAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(18603u);

	public static readonly NodeId SystemDiagnosticAlarmType_SilenceState_Id = new NodeId(18614u);

	public static readonly NodeId SystemDiagnosticAlarmType_LatchedState_Id = new NodeId(18627u);

	public static readonly NodeId CertificateExpirationAlarmType_EnabledState_Id = new NodeId(13241u);

	public static readonly NodeId CertificateExpirationAlarmType_Quality_SourceTimestamp = new NodeId(13250u);

	public static readonly NodeId CertificateExpirationAlarmType_LastSeverity_SourceTimestamp = new NodeId(13252u);

	public static readonly NodeId CertificateExpirationAlarmType_Comment_SourceTimestamp = new NodeId(13254u);

	public static readonly NodeId CertificateExpirationAlarmType_AddComment_InputArguments = new NodeId(13259u);

	public static readonly NodeId CertificateExpirationAlarmType_ConditionRefresh_InputArguments = new NodeId(13261u);

	public static readonly NodeId CertificateExpirationAlarmType_ConditionRefresh2_InputArguments = new NodeId(13263u);

	public static readonly NodeId CertificateExpirationAlarmType_AckedState_Id = new NodeId(13265u);

	public static readonly NodeId CertificateExpirationAlarmType_ConfirmedState_Id = new NodeId(13274u);

	public static readonly NodeId CertificateExpirationAlarmType_Acknowledge_InputArguments = new NodeId(13283u);

	public static readonly NodeId CertificateExpirationAlarmType_Confirm_InputArguments = new NodeId(13285u);

	public static readonly NodeId CertificateExpirationAlarmType_ActiveState_Id = new NodeId(13287u);

	public static readonly NodeId CertificateExpirationAlarmType_SuppressedState_Id = new NodeId(13297u);

	public static readonly NodeId CertificateExpirationAlarmType_OutOfServiceState_Id = new NodeId(17047u);

	public static readonly NodeId CertificateExpirationAlarmType_ShelvingState_CurrentState = new NodeId(13306u);

	public static readonly NodeId CertificateExpirationAlarmType_ShelvingState_CurrentState_Id = new NodeId(13307u);

	public static readonly NodeId CertificateExpirationAlarmType_ShelvingState_LastTransition_Id = new NodeId(13312u);

	public static readonly NodeId CertificateExpirationAlarmType_ShelvingState_UnshelveTime = new NodeId(13317u);

	public static readonly NodeId CertificateExpirationAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(13321u);

	public static readonly NodeId CertificateExpirationAlarmType_SilenceState_Id = new NodeId(17056u);

	public static readonly NodeId CertificateExpirationAlarmType_LatchedState_Id = new NodeId(18646u);

	public static readonly NodeId CertificateExpirationAlarmType_ExpirationDate = new NodeId(13325u);

	public static readonly NodeId CertificateExpirationAlarmType_ExpirationLimit = new NodeId(14900u);

	public static readonly NodeId CertificateExpirationAlarmType_CertificateType = new NodeId(13326u);

	public static readonly NodeId CertificateExpirationAlarmType_Certificate = new NodeId(13327u);

	public static readonly NodeId DiscrepancyAlarmType_EnabledState_Id = new NodeId(17098u);

	public static readonly NodeId DiscrepancyAlarmType_Quality_SourceTimestamp = new NodeId(17107u);

	public static readonly NodeId DiscrepancyAlarmType_LastSeverity_SourceTimestamp = new NodeId(17109u);

	public static readonly NodeId DiscrepancyAlarmType_Comment_SourceTimestamp = new NodeId(17111u);

	public static readonly NodeId DiscrepancyAlarmType_AddComment_InputArguments = new NodeId(17116u);

	public static readonly NodeId DiscrepancyAlarmType_ConditionRefresh_InputArguments = new NodeId(17118u);

	public static readonly NodeId DiscrepancyAlarmType_ConditionRefresh2_InputArguments = new NodeId(17120u);

	public static readonly NodeId DiscrepancyAlarmType_AckedState_Id = new NodeId(17122u);

	public static readonly NodeId DiscrepancyAlarmType_ConfirmedState_Id = new NodeId(17131u);

	public static readonly NodeId DiscrepancyAlarmType_Acknowledge_InputArguments = new NodeId(17140u);

	public static readonly NodeId DiscrepancyAlarmType_Confirm_InputArguments = new NodeId(17142u);

	public static readonly NodeId DiscrepancyAlarmType_ActiveState_Id = new NodeId(17144u);

	public static readonly NodeId DiscrepancyAlarmType_SuppressedState_Id = new NodeId(17154u);

	public static readonly NodeId DiscrepancyAlarmType_OutOfServiceState_Id = new NodeId(17163u);

	public static readonly NodeId DiscrepancyAlarmType_ShelvingState_CurrentState = new NodeId(17181u);

	public static readonly NodeId DiscrepancyAlarmType_ShelvingState_CurrentState_Id = new NodeId(17182u);

	public static readonly NodeId DiscrepancyAlarmType_ShelvingState_LastTransition_Id = new NodeId(17187u);

	public static readonly NodeId DiscrepancyAlarmType_ShelvingState_UnshelveTime = new NodeId(17192u);

	public static readonly NodeId DiscrepancyAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(17196u);

	public static readonly NodeId DiscrepancyAlarmType_SilenceState_Id = new NodeId(17172u);

	public static readonly NodeId DiscrepancyAlarmType_LatchedState_Id = new NodeId(18656u);

	public static readonly NodeId DiscrepancyAlarmType_TargetValueNode = new NodeId(17215u);

	public static readonly NodeId DiscrepancyAlarmType_ExpectedTime = new NodeId(17216u);

	public static readonly NodeId DiscrepancyAlarmType_Tolerance = new NodeId(17217u);

	public static readonly NodeId AuditConditionCommentEventType_ConditionEventId = new NodeId(17222u);

	public static readonly NodeId AuditConditionCommentEventType_Comment = new NodeId(11851u);

	public static readonly NodeId AuditConditionRespondEventType_SelectedResponse = new NodeId(11852u);

	public static readonly NodeId AuditConditionAcknowledgeEventType_ConditionEventId = new NodeId(17223u);

	public static readonly NodeId AuditConditionAcknowledgeEventType_Comment = new NodeId(11853u);

	public static readonly NodeId AuditConditionConfirmEventType_ConditionEventId = new NodeId(17224u);

	public static readonly NodeId AuditConditionConfirmEventType_Comment = new NodeId(11854u);

	public static readonly NodeId AuditConditionShelvingEventType_ShelvingTime = new NodeId(11855u);

	public static readonly NodeId AlarmMetricsType_AlarmCount = new NodeId(17280u);

	public static readonly NodeId AlarmMetricsType_StartTime = new NodeId(17991u);

	public static readonly NodeId AlarmMetricsType_MaximumActiveState = new NodeId(17281u);

	public static readonly NodeId AlarmMetricsType_MaximumUnAck = new NodeId(17282u);

	public static readonly NodeId AlarmMetricsType_CurrentAlarmRate = new NodeId(17284u);

	public static readonly NodeId AlarmMetricsType_CurrentAlarmRate_Rate = new NodeId(17285u);

	public static readonly NodeId AlarmMetricsType_MaximumAlarmRate = new NodeId(17286u);

	public static readonly NodeId AlarmMetricsType_MaximumAlarmRate_Rate = new NodeId(17287u);

	public static readonly NodeId AlarmMetricsType_MaximumReAlarmCount = new NodeId(17283u);

	public static readonly NodeId AlarmMetricsType_AverageAlarmRate = new NodeId(17288u);

	public static readonly NodeId AlarmMetricsType_AverageAlarmRate_Rate = new NodeId(17289u);

	public static readonly NodeId AlarmRateVariableType_Rate = new NodeId(17278u);

	public static readonly NodeId ProgramStateMachineType_CurrentState = new NodeId(3830u);

	public static readonly NodeId ProgramStateMachineType_CurrentState_Id = new NodeId(3831u);

	public static readonly NodeId ProgramStateMachineType_CurrentState_Number = new NodeId(3833u);

	public static readonly NodeId ProgramStateMachineType_LastTransition = new NodeId(3835u);

	public static readonly NodeId ProgramStateMachineType_LastTransition_Id = new NodeId(3836u);

	public static readonly NodeId ProgramStateMachineType_LastTransition_Number = new NodeId(3838u);

	public static readonly NodeId ProgramStateMachineType_LastTransition_TransitionTime = new NodeId(3839u);

	public static readonly NodeId ProgramStateMachineType_Creatable = new NodeId(2392u);

	public static readonly NodeId ProgramStateMachineType_Deletable = new NodeId(2393u);

	public static readonly NodeId ProgramStateMachineType_AutoDelete = new NodeId(2394u);

	public static readonly NodeId ProgramStateMachineType_RecycleCount = new NodeId(2395u);

	public static readonly NodeId ProgramStateMachineType_InstanceCount = new NodeId(2396u);

	public static readonly NodeId ProgramStateMachineType_MaxInstanceCount = new NodeId(2397u);

	public static readonly NodeId ProgramStateMachineType_MaxRecycleCount = new NodeId(2398u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic = new NodeId(2399u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_CreateSessionId = new NodeId(3840u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_CreateClientName = new NodeId(3841u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_InvocationCreationTime = new NodeId(3842u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_LastTransitionTime = new NodeId(3843u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_LastMethodCall = new NodeId(3844u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_LastMethodSessionId = new NodeId(3845u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_LastMethodInputArguments = new NodeId(3846u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_LastMethodOutputArguments = new NodeId(3847u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_LastMethodInputValues = new NodeId(15038u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_LastMethodOutputValues = new NodeId(15040u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_LastMethodCallTime = new NodeId(3848u);

	public static readonly NodeId ProgramStateMachineType_ProgramDiagnostic_LastMethodReturnStatus = new NodeId(3849u);

	public static readonly NodeId ProgramStateMachineType_Halted_StateNumber = new NodeId(2407u);

	public static readonly NodeId ProgramStateMachineType_Ready_StateNumber = new NodeId(2401u);

	public static readonly NodeId ProgramStateMachineType_Running_StateNumber = new NodeId(2403u);

	public static readonly NodeId ProgramStateMachineType_Suspended_StateNumber = new NodeId(2405u);

	public static readonly NodeId ProgramStateMachineType_HaltedToReady_TransitionNumber = new NodeId(2409u);

	public static readonly NodeId ProgramStateMachineType_ReadyToRunning_TransitionNumber = new NodeId(2411u);

	public static readonly NodeId ProgramStateMachineType_RunningToHalted_TransitionNumber = new NodeId(2413u);

	public static readonly NodeId ProgramStateMachineType_RunningToReady_TransitionNumber = new NodeId(2415u);

	public static readonly NodeId ProgramStateMachineType_RunningToSuspended_TransitionNumber = new NodeId(2417u);

	public static readonly NodeId ProgramStateMachineType_SuspendedToRunning_TransitionNumber = new NodeId(2419u);

	public static readonly NodeId ProgramStateMachineType_SuspendedToHalted_TransitionNumber = new NodeId(2421u);

	public static readonly NodeId ProgramStateMachineType_SuspendedToReady_TransitionNumber = new NodeId(2423u);

	public static readonly NodeId ProgramStateMachineType_ReadyToHalted_TransitionNumber = new NodeId(2425u);

	public static readonly NodeId ProgramTransitionEventType_Transition_Id = new NodeId(3802u);

	public static readonly NodeId ProgramTransitionEventType_FromState_Id = new NodeId(3792u);

	public static readonly NodeId ProgramTransitionEventType_ToState_Id = new NodeId(3797u);

	public static readonly NodeId ProgramTransitionEventType_IntermediateResult = new NodeId(2379u);

	public static readonly NodeId AuditProgramTransitionEventType_TransitionNumber = new NodeId(11875u);

	public static readonly NodeId ProgramTransitionAuditEventType_Transition = new NodeId(3825u);

	public static readonly NodeId ProgramTransitionAuditEventType_Transition_Id = new NodeId(3826u);

	public static readonly NodeId ProgramDiagnosticType_CreateSessionId = new NodeId(2381u);

	public static readonly NodeId ProgramDiagnosticType_CreateClientName = new NodeId(2382u);

	public static readonly NodeId ProgramDiagnosticType_InvocationCreationTime = new NodeId(2383u);

	public static readonly NodeId ProgramDiagnosticType_LastTransitionTime = new NodeId(2384u);

	public static readonly NodeId ProgramDiagnosticType_LastMethodCall = new NodeId(2385u);

	public static readonly NodeId ProgramDiagnosticType_LastMethodSessionId = new NodeId(2386u);

	public static readonly NodeId ProgramDiagnosticType_LastMethodInputArguments = new NodeId(2387u);

	public static readonly NodeId ProgramDiagnosticType_LastMethodOutputArguments = new NodeId(2388u);

	public static readonly NodeId ProgramDiagnosticType_LastMethodCallTime = new NodeId(2389u);

	public static readonly NodeId ProgramDiagnosticType_LastMethodReturnStatus = new NodeId(2390u);

	public static readonly NodeId ProgramDiagnostic2Type_CreateSessionId = new NodeId(15384u);

	public static readonly NodeId ProgramDiagnostic2Type_CreateClientName = new NodeId(15385u);

	public static readonly NodeId ProgramDiagnostic2Type_InvocationCreationTime = new NodeId(15386u);

	public static readonly NodeId ProgramDiagnostic2Type_LastTransitionTime = new NodeId(15387u);

	public static readonly NodeId ProgramDiagnostic2Type_LastMethodCall = new NodeId(15388u);

	public static readonly NodeId ProgramDiagnostic2Type_LastMethodSessionId = new NodeId(15389u);

	public static readonly NodeId ProgramDiagnostic2Type_LastMethodInputArguments = new NodeId(15390u);

	public static readonly NodeId ProgramDiagnostic2Type_LastMethodOutputArguments = new NodeId(15391u);

	public static readonly NodeId ProgramDiagnostic2Type_LastMethodInputValues = new NodeId(15392u);

	public static readonly NodeId ProgramDiagnostic2Type_LastMethodOutputValues = new NodeId(15393u);

	public static readonly NodeId ProgramDiagnostic2Type_LastMethodCallTime = new NodeId(15394u);

	public static readonly NodeId ProgramDiagnostic2Type_LastMethodReturnStatus = new NodeId(15395u);

	public static readonly NodeId Annotations = new NodeId(11214u);

	public static readonly NodeId HistoricalDataConfigurationType_AggregateConfiguration_TreatUncertainAsBad = new NodeId(11168u);

	public static readonly NodeId HistoricalDataConfigurationType_AggregateConfiguration_PercentDataBad = new NodeId(11169u);

	public static readonly NodeId HistoricalDataConfigurationType_AggregateConfiguration_PercentDataGood = new NodeId(11170u);

	public static readonly NodeId HistoricalDataConfigurationType_AggregateConfiguration_UseSlopedExtrapolation = new NodeId(11171u);

	public static readonly NodeId HistoricalDataConfigurationType_Stepped = new NodeId(2323u);

	public static readonly NodeId HistoricalDataConfigurationType_Definition = new NodeId(2324u);

	public static readonly NodeId HistoricalDataConfigurationType_MaxTimeInterval = new NodeId(2325u);

	public static readonly NodeId HistoricalDataConfigurationType_MinTimeInterval = new NodeId(2326u);

	public static readonly NodeId HistoricalDataConfigurationType_ExceptionDeviation = new NodeId(2327u);

	public static readonly NodeId HistoricalDataConfigurationType_ExceptionDeviationFormat = new NodeId(2328u);

	public static readonly NodeId HistoricalDataConfigurationType_StartOfArchive = new NodeId(11499u);

	public static readonly NodeId HistoricalDataConfigurationType_StartOfOnlineArchive = new NodeId(11500u);

	public static readonly NodeId HistoricalDataConfigurationType_ServerTimestampSupported = new NodeId(19092u);

	public static readonly NodeId HAConfiguration_AggregateConfiguration_TreatUncertainAsBad = new NodeId(11204u);

	public static readonly NodeId HAConfiguration_AggregateConfiguration_PercentDataBad = new NodeId(11205u);

	public static readonly NodeId HAConfiguration_AggregateConfiguration_PercentDataGood = new NodeId(11206u);

	public static readonly NodeId HAConfiguration_AggregateConfiguration_UseSlopedExtrapolation = new NodeId(11207u);

	public static readonly NodeId HAConfiguration_Stepped = new NodeId(11208u);

	public static readonly NodeId HistoricalEventFilter = new NodeId(11215u);

	public static readonly NodeId HistoryServerCapabilitiesType_AccessHistoryDataCapability = new NodeId(2331u);

	public static readonly NodeId HistoryServerCapabilitiesType_AccessHistoryEventsCapability = new NodeId(2332u);

	public static readonly NodeId HistoryServerCapabilitiesType_MaxReturnDataValues = new NodeId(11268u);

	public static readonly NodeId HistoryServerCapabilitiesType_MaxReturnEventValues = new NodeId(11269u);

	public static readonly NodeId HistoryServerCapabilitiesType_InsertDataCapability = new NodeId(2334u);

	public static readonly NodeId HistoryServerCapabilitiesType_ReplaceDataCapability = new NodeId(2335u);

	public static readonly NodeId HistoryServerCapabilitiesType_UpdateDataCapability = new NodeId(2336u);

	public static readonly NodeId HistoryServerCapabilitiesType_DeleteRawCapability = new NodeId(2337u);

	public static readonly NodeId HistoryServerCapabilitiesType_DeleteAtTimeCapability = new NodeId(2338u);

	public static readonly NodeId HistoryServerCapabilitiesType_InsertEventCapability = new NodeId(11278u);

	public static readonly NodeId HistoryServerCapabilitiesType_ReplaceEventCapability = new NodeId(11279u);

	public static readonly NodeId HistoryServerCapabilitiesType_UpdateEventCapability = new NodeId(11280u);

	public static readonly NodeId HistoryServerCapabilitiesType_DeleteEventCapability = new NodeId(11501u);

	public static readonly NodeId HistoryServerCapabilitiesType_InsertAnnotationCapability = new NodeId(11270u);

	public static readonly NodeId HistoryServerCapabilitiesType_ServerTimestampSupported = new NodeId(19094u);

	public static readonly NodeId AuditHistoryEventUpdateEventType_UpdatedNode = new NodeId(3025u);

	public static readonly NodeId AuditHistoryEventUpdateEventType_PerformInsertReplace = new NodeId(3028u);

	public static readonly NodeId AuditHistoryEventUpdateEventType_Filter = new NodeId(3003u);

	public static readonly NodeId AuditHistoryEventUpdateEventType_NewValues = new NodeId(3029u);

	public static readonly NodeId AuditHistoryEventUpdateEventType_OldValues = new NodeId(3030u);

	public static readonly NodeId AuditHistoryValueUpdateEventType_UpdatedNode = new NodeId(3026u);

	public static readonly NodeId AuditHistoryValueUpdateEventType_PerformInsertReplace = new NodeId(3031u);

	public static readonly NodeId AuditHistoryValueUpdateEventType_NewValues = new NodeId(3032u);

	public static readonly NodeId AuditHistoryValueUpdateEventType_OldValues = new NodeId(3033u);

	public static readonly NodeId AuditHistoryAnnotationUpdateEventType_PerformInsertReplace = new NodeId(19293u);

	public static readonly NodeId AuditHistoryAnnotationUpdateEventType_NewValues = new NodeId(19294u);

	public static readonly NodeId AuditHistoryAnnotationUpdateEventType_OldValues = new NodeId(19295u);

	public static readonly NodeId AuditHistoryDeleteEventType_UpdatedNode = new NodeId(3027u);

	public static readonly NodeId AuditHistoryRawModifyDeleteEventType_IsDeleteModified = new NodeId(3015u);

	public static readonly NodeId AuditHistoryRawModifyDeleteEventType_StartTime = new NodeId(3016u);

	public static readonly NodeId AuditHistoryRawModifyDeleteEventType_EndTime = new NodeId(3017u);

	public static readonly NodeId AuditHistoryRawModifyDeleteEventType_OldValues = new NodeId(3034u);

	public static readonly NodeId AuditHistoryAtTimeDeleteEventType_ReqTimes = new NodeId(3020u);

	public static readonly NodeId AuditHistoryAtTimeDeleteEventType_OldValues = new NodeId(3021u);

	public static readonly NodeId AuditHistoryEventDeleteEventType_EventIds = new NodeId(3023u);

	public static readonly NodeId AuditHistoryEventDeleteEventType_OldValues = new NodeId(3024u);

	public static readonly NodeId TrustListType_Open_InputArguments = new NodeId(12528u);

	public static readonly NodeId TrustListType_Open_OutputArguments = new NodeId(12529u);

	public static readonly NodeId TrustListType_Close_InputArguments = new NodeId(12531u);

	public static readonly NodeId TrustListType_Read_InputArguments = new NodeId(12533u);

	public static readonly NodeId TrustListType_Read_OutputArguments = new NodeId(12534u);

	public static readonly NodeId TrustListType_Write_InputArguments = new NodeId(12536u);

	public static readonly NodeId TrustListType_GetPosition_InputArguments = new NodeId(12538u);

	public static readonly NodeId TrustListType_GetPosition_OutputArguments = new NodeId(12539u);

	public static readonly NodeId TrustListType_SetPosition_InputArguments = new NodeId(12541u);

	public static readonly NodeId TrustListType_LastUpdateTime = new NodeId(12542u);

	public static readonly NodeId TrustListType_UpdateFrequency = new NodeId(19296u);

	public static readonly NodeId TrustListType_OpenWithMasks_InputArguments = new NodeId(12544u);

	public static readonly NodeId TrustListType_OpenWithMasks_OutputArguments = new NodeId(12545u);

	public static readonly NodeId TrustListType_CloseAndUpdate_InputArguments = new NodeId(12705u);

	public static readonly NodeId TrustListType_CloseAndUpdate_OutputArguments = new NodeId(12547u);

	public static readonly NodeId TrustListType_AddCertificate_InputArguments = new NodeId(12549u);

	public static readonly NodeId TrustListType_RemoveCertificate_InputArguments = new NodeId(12551u);

	public static readonly NodeId TrustListMasks_EnumValues = new NodeId(12553u);

	public static readonly NodeId TrustListOutOfDateAlarmType_EnabledState_Id = new NodeId(19315u);

	public static readonly NodeId TrustListOutOfDateAlarmType_Quality_SourceTimestamp = new NodeId(19324u);

	public static readonly NodeId TrustListOutOfDateAlarmType_LastSeverity_SourceTimestamp = new NodeId(19326u);

	public static readonly NodeId TrustListOutOfDateAlarmType_Comment_SourceTimestamp = new NodeId(19328u);

	public static readonly NodeId TrustListOutOfDateAlarmType_AddComment_InputArguments = new NodeId(19333u);

	public static readonly NodeId TrustListOutOfDateAlarmType_ConditionRefresh_InputArguments = new NodeId(19335u);

	public static readonly NodeId TrustListOutOfDateAlarmType_ConditionRefresh2_InputArguments = new NodeId(19337u);

	public static readonly NodeId TrustListOutOfDateAlarmType_AckedState_Id = new NodeId(19339u);

	public static readonly NodeId TrustListOutOfDateAlarmType_ConfirmedState_Id = new NodeId(19348u);

	public static readonly NodeId TrustListOutOfDateAlarmType_Acknowledge_InputArguments = new NodeId(19357u);

	public static readonly NodeId TrustListOutOfDateAlarmType_Confirm_InputArguments = new NodeId(19359u);

	public static readonly NodeId TrustListOutOfDateAlarmType_ActiveState_Id = new NodeId(19361u);

	public static readonly NodeId TrustListOutOfDateAlarmType_SuppressedState_Id = new NodeId(19371u);

	public static readonly NodeId TrustListOutOfDateAlarmType_OutOfServiceState_Id = new NodeId(19380u);

	public static readonly NodeId TrustListOutOfDateAlarmType_ShelvingState_CurrentState = new NodeId(19389u);

	public static readonly NodeId TrustListOutOfDateAlarmType_ShelvingState_CurrentState_Id = new NodeId(19390u);

	public static readonly NodeId TrustListOutOfDateAlarmType_ShelvingState_LastTransition_Id = new NodeId(19395u);

	public static readonly NodeId TrustListOutOfDateAlarmType_ShelvingState_UnshelveTime = new NodeId(19402u);

	public static readonly NodeId TrustListOutOfDateAlarmType_ShelvingState_TimedShelve_InputArguments = new NodeId(19404u);

	public static readonly NodeId TrustListOutOfDateAlarmType_SilenceState_Id = new NodeId(19415u);

	public static readonly NodeId TrustListOutOfDateAlarmType_LatchedState_Id = new NodeId(19428u);

	public static readonly NodeId TrustListOutOfDateAlarmType_TrustListId = new NodeId(19446u);

	public static readonly NodeId TrustListOutOfDateAlarmType_LastUpdateTime = new NodeId(19447u);

	public static readonly NodeId TrustListOutOfDateAlarmType_UpdateFrequency = new NodeId(19448u);

	public static readonly NodeId CertificateGroupType_TrustList_Size = new NodeId(13600u);

	public static readonly NodeId CertificateGroupType_TrustList_Writable = new NodeId(13601u);

	public static readonly NodeId CertificateGroupType_TrustList_UserWritable = new NodeId(13602u);

	public static readonly NodeId CertificateGroupType_TrustList_OpenCount = new NodeId(13603u);

	public static readonly NodeId CertificateGroupType_TrustList_Open_InputArguments = new NodeId(13606u);

	public static readonly NodeId CertificateGroupType_TrustList_Open_OutputArguments = new NodeId(13607u);

	public static readonly NodeId CertificateGroupType_TrustList_Close_InputArguments = new NodeId(13609u);

	public static readonly NodeId CertificateGroupType_TrustList_Read_InputArguments = new NodeId(13611u);

	public static readonly NodeId CertificateGroupType_TrustList_Read_OutputArguments = new NodeId(13612u);

	public static readonly NodeId CertificateGroupType_TrustList_Write_InputArguments = new NodeId(13614u);

	public static readonly NodeId CertificateGroupType_TrustList_GetPosition_InputArguments = new NodeId(13616u);

	public static readonly NodeId CertificateGroupType_TrustList_GetPosition_OutputArguments = new NodeId(13617u);

	public static readonly NodeId CertificateGroupType_TrustList_SetPosition_InputArguments = new NodeId(13619u);

	public static readonly NodeId CertificateGroupType_TrustList_LastUpdateTime = new NodeId(13620u);

	public static readonly NodeId CertificateGroupType_TrustList_OpenWithMasks_InputArguments = new NodeId(13622u);

	public static readonly NodeId CertificateGroupType_TrustList_OpenWithMasks_OutputArguments = new NodeId(13623u);

	public static readonly NodeId CertificateGroupType_TrustList_CloseAndUpdate_InputArguments = new NodeId(13625u);

	public static readonly NodeId CertificateGroupType_TrustList_CloseAndUpdate_OutputArguments = new NodeId(13626u);

	public static readonly NodeId CertificateGroupType_TrustList_AddCertificate_InputArguments = new NodeId(13628u);

	public static readonly NodeId CertificateGroupType_TrustList_RemoveCertificate_InputArguments = new NodeId(13630u);

	public static readonly NodeId CertificateGroupType_CertificateTypes = new NodeId(13631u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_EventId = new NodeId(19451u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_EventType = new NodeId(19452u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_SourceNode = new NodeId(19453u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_SourceName = new NodeId(19454u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Time = new NodeId(19455u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ReceiveTime = new NodeId(19456u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Message = new NodeId(19458u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Severity = new NodeId(19459u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ConditionClassId = new NodeId(19460u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ConditionClassName = new NodeId(19461u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ConditionName = new NodeId(19464u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_BranchId = new NodeId(19465u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Retain = new NodeId(19466u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_EnabledState = new NodeId(19467u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_EnabledState_Id = new NodeId(19468u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Quality = new NodeId(19476u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Quality_SourceTimestamp = new NodeId(19477u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_LastSeverity = new NodeId(19478u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(19479u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Comment = new NodeId(19480u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Comment_SourceTimestamp = new NodeId(19481u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ClientUserId = new NodeId(19482u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_AddComment_InputArguments = new NodeId(19486u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_AckedState = new NodeId(19487u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_AckedState_Id = new NodeId(19488u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ConfirmedState_Id = new NodeId(19497u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Acknowledge_InputArguments = new NodeId(19506u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Confirm_InputArguments = new NodeId(19508u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ActiveState = new NodeId(19509u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ActiveState_Id = new NodeId(19510u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_InputNode = new NodeId(19518u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_SuppressedState_Id = new NodeId(19520u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_OutOfServiceState_Id = new NodeId(19529u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ShelvingState_CurrentState = new NodeId(19538u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(19539u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(19544u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(20096u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(20098u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_SuppressedOrShelved = new NodeId(20101u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_SilenceState_Id = new NodeId(20109u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_LatchedState_Id = new NodeId(20122u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_NormalState = new NodeId(20138u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_ExpirationDate = new NodeId(20139u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_CertificateType = new NodeId(20141u);

	public static readonly NodeId CertificateGroupType_CertificateExpired_Certificate = new NodeId(20142u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_EventId = new NodeId(20144u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_EventType = new NodeId(20145u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_SourceNode = new NodeId(20146u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_SourceName = new NodeId(20147u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Time = new NodeId(20148u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ReceiveTime = new NodeId(20149u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Message = new NodeId(20151u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Severity = new NodeId(20152u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ConditionClassId = new NodeId(20153u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ConditionClassName = new NodeId(20154u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ConditionName = new NodeId(20157u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_BranchId = new NodeId(20158u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Retain = new NodeId(20159u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_EnabledState = new NodeId(20160u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_EnabledState_Id = new NodeId(20161u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Quality = new NodeId(20169u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(20170u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_LastSeverity = new NodeId(20171u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(20172u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Comment = new NodeId(20173u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(20174u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ClientUserId = new NodeId(20175u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_AddComment_InputArguments = new NodeId(20179u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_AckedState = new NodeId(20180u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_AckedState_Id = new NodeId(20181u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ConfirmedState_Id = new NodeId(20190u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(20199u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_Confirm_InputArguments = new NodeId(20201u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ActiveState = new NodeId(20202u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ActiveState_Id = new NodeId(20203u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_InputNode = new NodeId(20211u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_SuppressedState_Id = new NodeId(20213u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(20222u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(20231u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(20232u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(20237u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(20244u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(20246u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_SuppressedOrShelved = new NodeId(20249u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_SilenceState_Id = new NodeId(20257u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_LatchedState_Id = new NodeId(20270u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_NormalState = new NodeId(20286u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_TrustListId = new NodeId(20287u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_LastUpdateTime = new NodeId(20288u);

	public static readonly NodeId CertificateGroupType_TrustListOutOfDate_UpdateFrequency = new NodeId(20289u);

	public static readonly NodeId CertificateGroupType_GetRejectedList_OutputArguments = new NodeId(23527u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Size = new NodeId(13816u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Writable = new NodeId(13817u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_UserWritable = new NodeId(13818u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_OpenCount = new NodeId(13819u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Open_InputArguments = new NodeId(13822u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Open_OutputArguments = new NodeId(13823u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Close_InputArguments = new NodeId(13825u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Read_InputArguments = new NodeId(13827u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Read_OutputArguments = new NodeId(13828u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Write_InputArguments = new NodeId(13830u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_GetPosition_InputArguments = new NodeId(13832u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments = new NodeId(13833u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_SetPosition_InputArguments = new NodeId(13835u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_LastUpdateTime = new NodeId(13836u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments = new NodeId(13838u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments = new NodeId(13839u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments = new NodeId(13841u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments = new NodeId(13842u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments = new NodeId(13844u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments = new NodeId(13846u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateTypes = new NodeId(13847u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_EventId = new NodeId(20292u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_EventType = new NodeId(20293u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_SourceNode = new NodeId(20294u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_SourceName = new NodeId(20295u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Time = new NodeId(20296u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ReceiveTime = new NodeId(20297u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Message = new NodeId(20299u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Severity = new NodeId(20300u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ConditionClassId = new NodeId(20301u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ConditionClassName = new NodeId(20302u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ConditionName = new NodeId(20305u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_BranchId = new NodeId(20306u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Retain = new NodeId(20307u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_EnabledState = new NodeId(20308u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_EnabledState_Id = new NodeId(20309u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Quality = new NodeId(20317u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Quality_SourceTimestamp = new NodeId(20318u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_LastSeverity = new NodeId(20319u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(20320u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Comment = new NodeId(20321u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Comment_SourceTimestamp = new NodeId(20322u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ClientUserId = new NodeId(20323u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_AddComment_InputArguments = new NodeId(20327u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_AckedState = new NodeId(20328u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_AckedState_Id = new NodeId(20329u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ConfirmedState_Id = new NodeId(20338u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Acknowledge_InputArguments = new NodeId(20347u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Confirm_InputArguments = new NodeId(20349u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ActiveState = new NodeId(20350u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ActiveState_Id = new NodeId(20351u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_InputNode = new NodeId(20359u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_SuppressedState_Id = new NodeId(20361u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_OutOfServiceState_Id = new NodeId(20370u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ShelvingState_CurrentState = new NodeId(20379u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(20380u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(20385u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(20392u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(20394u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_SuppressedOrShelved = new NodeId(20397u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_SilenceState_Id = new NodeId(20405u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_LatchedState_Id = new NodeId(20420u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_NormalState = new NodeId(20436u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ExpirationDate = new NodeId(20437u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_CertificateType = new NodeId(20439u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Certificate = new NodeId(20440u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_EventId = new NodeId(20442u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_EventType = new NodeId(20443u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_SourceNode = new NodeId(20444u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_SourceName = new NodeId(20445u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Time = new NodeId(20446u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ReceiveTime = new NodeId(20447u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Message = new NodeId(20449u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Severity = new NodeId(20450u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ConditionClassId = new NodeId(20451u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ConditionClassName = new NodeId(20452u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ConditionName = new NodeId(20455u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_BranchId = new NodeId(20456u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Retain = new NodeId(20457u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_EnabledState = new NodeId(20458u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_EnabledState_Id = new NodeId(20459u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Quality = new NodeId(20467u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(20468u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_LastSeverity = new NodeId(20469u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(20470u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Comment = new NodeId(20471u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(20472u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ClientUserId = new NodeId(20473u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_AddComment_InputArguments = new NodeId(20477u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_AckedState = new NodeId(20478u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_AckedState_Id = new NodeId(20479u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ConfirmedState_Id = new NodeId(20488u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(20497u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Confirm_InputArguments = new NodeId(20499u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ActiveState = new NodeId(20500u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ActiveState_Id = new NodeId(20501u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_InputNode = new NodeId(20509u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_SuppressedState_Id = new NodeId(20511u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(20520u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(20529u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(20530u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(20535u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(20542u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(20544u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_SuppressedOrShelved = new NodeId(20547u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_SilenceState_Id = new NodeId(20555u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_LatchedState_Id = new NodeId(20568u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_NormalState = new NodeId(20584u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_TrustListId = new NodeId(20585u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_LastUpdateTime = new NodeId(20586u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_UpdateFrequency = new NodeId(20587u);

	public static readonly NodeId CertificateGroupFolderType_DefaultApplicationGroup_GetRejectedList_OutputArguments = new NodeId(23530u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Size = new NodeId(13850u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Writable = new NodeId(13851u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_UserWritable = new NodeId(13852u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_OpenCount = new NodeId(13853u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Open_InputArguments = new NodeId(13856u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Open_OutputArguments = new NodeId(13857u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Close_InputArguments = new NodeId(13859u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Read_InputArguments = new NodeId(13861u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Read_OutputArguments = new NodeId(13862u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Write_InputArguments = new NodeId(13864u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_GetPosition_InputArguments = new NodeId(13866u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments = new NodeId(13867u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_SetPosition_InputArguments = new NodeId(13869u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_LastUpdateTime = new NodeId(13870u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments = new NodeId(13872u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments = new NodeId(13873u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments = new NodeId(13875u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments = new NodeId(13876u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments = new NodeId(13878u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments = new NodeId(13880u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateTypes = new NodeId(13881u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_EventId = new NodeId(20590u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_EventType = new NodeId(20591u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_SourceNode = new NodeId(20592u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_SourceName = new NodeId(20593u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Time = new NodeId(20594u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ReceiveTime = new NodeId(20595u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Message = new NodeId(20597u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Severity = new NodeId(20598u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ConditionClassId = new NodeId(20599u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ConditionClassName = new NodeId(20600u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ConditionName = new NodeId(20603u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_BranchId = new NodeId(20604u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Retain = new NodeId(20605u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_EnabledState = new NodeId(20606u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_EnabledState_Id = new NodeId(20607u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Quality = new NodeId(20615u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Quality_SourceTimestamp = new NodeId(20616u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_LastSeverity = new NodeId(20617u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(20618u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Comment = new NodeId(20619u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Comment_SourceTimestamp = new NodeId(20620u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ClientUserId = new NodeId(20621u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_AddComment_InputArguments = new NodeId(20625u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_AckedState = new NodeId(20626u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_AckedState_Id = new NodeId(20627u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ConfirmedState_Id = new NodeId(20636u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Acknowledge_InputArguments = new NodeId(20645u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Confirm_InputArguments = new NodeId(20647u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ActiveState = new NodeId(20648u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ActiveState_Id = new NodeId(20649u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_InputNode = new NodeId(20657u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_SuppressedState_Id = new NodeId(20659u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_OutOfServiceState_Id = new NodeId(20668u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ShelvingState_CurrentState = new NodeId(20677u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(20678u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(20683u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(20690u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(20692u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_SuppressedOrShelved = new NodeId(20695u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_SilenceState_Id = new NodeId(20703u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_LatchedState_Id = new NodeId(20716u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_NormalState = new NodeId(20732u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ExpirationDate = new NodeId(20733u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_CertificateType = new NodeId(20735u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Certificate = new NodeId(20736u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_EventId = new NodeId(20738u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_EventType = new NodeId(20739u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_SourceNode = new NodeId(20740u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_SourceName = new NodeId(20741u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Time = new NodeId(20742u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ReceiveTime = new NodeId(20743u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Message = new NodeId(20745u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Severity = new NodeId(20746u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ConditionClassId = new NodeId(20747u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ConditionClassName = new NodeId(20748u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ConditionName = new NodeId(20751u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_BranchId = new NodeId(20752u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Retain = new NodeId(20753u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_EnabledState = new NodeId(20754u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_EnabledState_Id = new NodeId(20755u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Quality = new NodeId(20763u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(20764u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_LastSeverity = new NodeId(20765u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(20766u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Comment = new NodeId(20767u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(20768u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ClientUserId = new NodeId(20769u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_AddComment_InputArguments = new NodeId(20773u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_AckedState = new NodeId(20774u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_AckedState_Id = new NodeId(20775u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ConfirmedState_Id = new NodeId(20784u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(20793u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Confirm_InputArguments = new NodeId(20795u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ActiveState = new NodeId(20796u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ActiveState_Id = new NodeId(20797u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_InputNode = new NodeId(20805u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_SuppressedState_Id = new NodeId(20807u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(20816u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(20825u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(20826u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(20831u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(20838u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(20840u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_SuppressedOrShelved = new NodeId(20843u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_SilenceState_Id = new NodeId(20851u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_LatchedState_Id = new NodeId(20864u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_NormalState = new NodeId(20880u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_TrustListId = new NodeId(20881u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_LastUpdateTime = new NodeId(20882u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_UpdateFrequency = new NodeId(20883u);

	public static readonly NodeId CertificateGroupFolderType_DefaultHttpsGroup_GetRejectedList_OutputArguments = new NodeId(23532u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Size = new NodeId(13884u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Writable = new NodeId(13885u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_UserWritable = new NodeId(13886u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_OpenCount = new NodeId(13887u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Open_InputArguments = new NodeId(13890u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Open_OutputArguments = new NodeId(13891u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Close_InputArguments = new NodeId(13893u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Read_InputArguments = new NodeId(13895u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Read_OutputArguments = new NodeId(13896u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Write_InputArguments = new NodeId(13898u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments = new NodeId(13900u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments = new NodeId(13901u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments = new NodeId(13903u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_LastUpdateTime = new NodeId(13904u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments = new NodeId(13906u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments = new NodeId(13907u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments = new NodeId(13909u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments = new NodeId(13910u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments = new NodeId(13912u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments = new NodeId(13914u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateTypes = new NodeId(13915u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_EventId = new NodeId(20886u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_EventType = new NodeId(20887u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_SourceNode = new NodeId(20888u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_SourceName = new NodeId(20889u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Time = new NodeId(20890u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ReceiveTime = new NodeId(20891u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Message = new NodeId(20893u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Severity = new NodeId(20894u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ConditionClassId = new NodeId(20895u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ConditionClassName = new NodeId(20896u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ConditionName = new NodeId(20899u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_BranchId = new NodeId(20900u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Retain = new NodeId(20901u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_EnabledState = new NodeId(20902u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_EnabledState_Id = new NodeId(20903u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Quality = new NodeId(20911u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Quality_SourceTimestamp = new NodeId(20912u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_LastSeverity = new NodeId(20913u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(20914u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Comment = new NodeId(20915u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Comment_SourceTimestamp = new NodeId(20916u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ClientUserId = new NodeId(20917u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_AddComment_InputArguments = new NodeId(20921u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_AckedState = new NodeId(20922u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_AckedState_Id = new NodeId(20923u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ConfirmedState_Id = new NodeId(20932u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Acknowledge_InputArguments = new NodeId(20941u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Confirm_InputArguments = new NodeId(20943u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ActiveState = new NodeId(20944u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ActiveState_Id = new NodeId(20945u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_InputNode = new NodeId(20953u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_SuppressedState_Id = new NodeId(20955u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_OutOfServiceState_Id = new NodeId(20964u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ShelvingState_CurrentState = new NodeId(20973u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(20974u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(20979u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(20986u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(20988u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_SuppressedOrShelved = new NodeId(20991u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_SilenceState_Id = new NodeId(21008u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_LatchedState_Id = new NodeId(21215u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_NormalState = new NodeId(21231u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ExpirationDate = new NodeId(21232u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_CertificateType = new NodeId(21234u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Certificate = new NodeId(21235u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_EventId = new NodeId(21237u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_EventType = new NodeId(21238u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_SourceNode = new NodeId(21239u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_SourceName = new NodeId(21240u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Time = new NodeId(21241u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ReceiveTime = new NodeId(21242u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Message = new NodeId(21244u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Severity = new NodeId(21245u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ConditionClassId = new NodeId(21246u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ConditionClassName = new NodeId(21247u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ConditionName = new NodeId(21250u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_BranchId = new NodeId(21251u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Retain = new NodeId(21252u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_EnabledState = new NodeId(21253u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_EnabledState_Id = new NodeId(21254u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Quality = new NodeId(21262u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(21263u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_LastSeverity = new NodeId(21264u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(21265u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Comment = new NodeId(21266u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(21267u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ClientUserId = new NodeId(21268u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_AddComment_InputArguments = new NodeId(21272u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_AckedState = new NodeId(21273u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_AckedState_Id = new NodeId(21274u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ConfirmedState_Id = new NodeId(21283u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(21292u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Confirm_InputArguments = new NodeId(21294u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ActiveState = new NodeId(21295u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ActiveState_Id = new NodeId(21296u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_InputNode = new NodeId(21304u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_SuppressedState_Id = new NodeId(21306u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(21315u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(21324u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(21325u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(21330u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(21337u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(21339u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_SuppressedOrShelved = new NodeId(21342u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_SilenceState_Id = new NodeId(21350u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_LatchedState_Id = new NodeId(21363u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_NormalState = new NodeId(21379u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_TrustListId = new NodeId(21380u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_LastUpdateTime = new NodeId(21381u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_UpdateFrequency = new NodeId(21382u);

	public static readonly NodeId CertificateGroupFolderType_DefaultUserTokenGroup_GetRejectedList_OutputArguments = new NodeId(23534u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Size = new NodeId(13918u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Writable = new NodeId(13919u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_UserWritable = new NodeId(13920u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_OpenCount = new NodeId(13921u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Open_InputArguments = new NodeId(13924u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Open_OutputArguments = new NodeId(13925u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Close_InputArguments = new NodeId(13927u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Read_InputArguments = new NodeId(13929u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Read_OutputArguments = new NodeId(13930u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Write_InputArguments = new NodeId(13932u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_GetPosition_InputArguments = new NodeId(13934u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_GetPosition_OutputArguments = new NodeId(13935u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_SetPosition_InputArguments = new NodeId(13937u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_LastUpdateTime = new NodeId(13938u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_OpenWithMasks_InputArguments = new NodeId(13940u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_OpenWithMasks_OutputArguments = new NodeId(13941u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_CloseAndUpdate_InputArguments = new NodeId(13943u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_CloseAndUpdate_OutputArguments = new NodeId(13944u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_AddCertificate_InputArguments = new NodeId(13946u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_RemoveCertificate_InputArguments = new NodeId(13948u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateTypes = new NodeId(13949u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_EventId = new NodeId(21385u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_EventType = new NodeId(21386u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_SourceNode = new NodeId(21387u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_SourceName = new NodeId(21388u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Time = new NodeId(21389u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ReceiveTime = new NodeId(21390u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Message = new NodeId(21392u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Severity = new NodeId(21393u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ConditionClassId = new NodeId(21394u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ConditionClassName = new NodeId(21395u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ConditionName = new NodeId(21398u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_BranchId = new NodeId(21399u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Retain = new NodeId(21400u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_EnabledState = new NodeId(21401u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_EnabledState_Id = new NodeId(21402u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Quality = new NodeId(21410u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Quality_SourceTimestamp = new NodeId(21411u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_LastSeverity = new NodeId(21412u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(21413u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Comment = new NodeId(21414u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Comment_SourceTimestamp = new NodeId(21415u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ClientUserId = new NodeId(21416u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_AddComment_InputArguments = new NodeId(21420u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_AckedState = new NodeId(21421u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_AckedState_Id = new NodeId(21422u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ConfirmedState_Id = new NodeId(21431u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Acknowledge_InputArguments = new NodeId(21440u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Confirm_InputArguments = new NodeId(21442u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ActiveState = new NodeId(21443u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ActiveState_Id = new NodeId(21444u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_InputNode = new NodeId(21452u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_SuppressedState_Id = new NodeId(21454u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_OutOfServiceState_Id = new NodeId(21463u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ShelvingState_CurrentState = new NodeId(21472u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(21473u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(21478u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(21485u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(21487u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_SuppressedOrShelved = new NodeId(21490u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_SilenceState_Id = new NodeId(21498u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_LatchedState_Id = new NodeId(21511u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_NormalState = new NodeId(21527u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ExpirationDate = new NodeId(21528u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_CertificateType = new NodeId(21530u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Certificate = new NodeId(21531u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_EventId = new NodeId(21533u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_EventType = new NodeId(21534u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_SourceNode = new NodeId(21535u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_SourceName = new NodeId(21536u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Time = new NodeId(21537u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ReceiveTime = new NodeId(21538u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Message = new NodeId(21540u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Severity = new NodeId(21541u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ConditionClassId = new NodeId(21542u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ConditionClassName = new NodeId(21543u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ConditionName = new NodeId(21546u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_BranchId = new NodeId(21547u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Retain = new NodeId(21548u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_EnabledState = new NodeId(21549u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_EnabledState_Id = new NodeId(21550u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Quality = new NodeId(21558u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(21559u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_LastSeverity = new NodeId(21560u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(21561u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Comment = new NodeId(21562u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(21563u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ClientUserId = new NodeId(21564u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_AddComment_InputArguments = new NodeId(21568u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_AckedState = new NodeId(21569u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_AckedState_Id = new NodeId(21570u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ConfirmedState_Id = new NodeId(21579u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(21588u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Confirm_InputArguments = new NodeId(21590u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ActiveState = new NodeId(21591u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ActiveState_Id = new NodeId(21592u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_InputNode = new NodeId(21600u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_SuppressedState_Id = new NodeId(21602u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(21611u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(21620u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(21621u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(21626u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(21633u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(21635u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_SuppressedOrShelved = new NodeId(21638u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_SilenceState_Id = new NodeId(21646u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_LatchedState_Id = new NodeId(21659u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_NormalState = new NodeId(21675u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_TrustListId = new NodeId(21676u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_LastUpdateTime = new NodeId(21677u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_UpdateFrequency = new NodeId(21678u);

	public static readonly NodeId CertificateGroupFolderType_AdditionalGroup_Placeholder_GetRejectedList_OutputArguments = new NodeId(23536u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Size = new NodeId(13953u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Writable = new NodeId(13954u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable = new NodeId(13955u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount = new NodeId(13956u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments = new NodeId(13959u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments = new NodeId(13960u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments = new NodeId(13962u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments = new NodeId(13964u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments = new NodeId(13965u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments = new NodeId(13967u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments = new NodeId(13969u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments = new NodeId(13970u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments = new NodeId(13972u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime = new NodeId(13973u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments = new NodeId(13975u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments = new NodeId(13976u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments = new NodeId(13978u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments = new NodeId(13979u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments = new NodeId(13981u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments = new NodeId(13983u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateTypes = new NodeId(13984u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_EventId = new NodeId(21681u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_EventType = new NodeId(21682u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SourceNode = new NodeId(21683u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SourceName = new NodeId(21684u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Time = new NodeId(21685u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ReceiveTime = new NodeId(21686u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Message = new NodeId(21688u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Severity = new NodeId(21689u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ConditionClassId = new NodeId(21690u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ConditionClassName = new NodeId(21691u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ConditionName = new NodeId(21694u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_BranchId = new NodeId(21695u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Retain = new NodeId(21696u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_EnabledState = new NodeId(21697u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_EnabledState_Id = new NodeId(21698u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Quality = new NodeId(21706u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Quality_SourceTimestamp = new NodeId(21707u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_LastSeverity = new NodeId(21708u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(21709u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Comment = new NodeId(21710u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Comment_SourceTimestamp = new NodeId(21711u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ClientUserId = new NodeId(21712u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_AddComment_InputArguments = new NodeId(21716u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_AckedState = new NodeId(21717u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_AckedState_Id = new NodeId(21718u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ConfirmedState_Id = new NodeId(21727u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Acknowledge_InputArguments = new NodeId(21736u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Confirm_InputArguments = new NodeId(21738u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ActiveState = new NodeId(21739u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ActiveState_Id = new NodeId(21740u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_InputNode = new NodeId(21748u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SuppressedState_Id = new NodeId(21750u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_OutOfServiceState_Id = new NodeId(21759u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_CurrentState = new NodeId(21768u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(21769u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(21774u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(21781u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(21783u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SuppressedOrShelved = new NodeId(21786u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SilenceState_Id = new NodeId(21794u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_LatchedState_Id = new NodeId(21807u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_NormalState = new NodeId(21823u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ExpirationDate = new NodeId(21824u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_CertificateType = new NodeId(21826u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Certificate = new NodeId(21827u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_EventId = new NodeId(21829u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_EventType = new NodeId(21830u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SourceNode = new NodeId(21831u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SourceName = new NodeId(21832u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Time = new NodeId(21833u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ReceiveTime = new NodeId(21834u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Message = new NodeId(21836u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Severity = new NodeId(21837u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ConditionClassId = new NodeId(21838u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ConditionClassName = new NodeId(21839u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ConditionName = new NodeId(21842u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_BranchId = new NodeId(21843u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Retain = new NodeId(21844u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_EnabledState = new NodeId(21845u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_EnabledState_Id = new NodeId(21846u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Quality = new NodeId(21854u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(21855u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_LastSeverity = new NodeId(21856u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(21857u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Comment = new NodeId(21858u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(21859u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ClientUserId = new NodeId(21860u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_AddComment_InputArguments = new NodeId(21864u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_AckedState = new NodeId(21865u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_AckedState_Id = new NodeId(21866u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ConfirmedState_Id = new NodeId(21875u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(21884u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Confirm_InputArguments = new NodeId(21886u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ActiveState = new NodeId(21887u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ActiveState_Id = new NodeId(21888u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_InputNode = new NodeId(21896u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SuppressedState_Id = new NodeId(21898u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(21907u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(21916u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(21917u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(21922u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(21929u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(21931u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SuppressedOrShelved = new NodeId(21934u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SilenceState_Id = new NodeId(21942u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_LatchedState_Id = new NodeId(21955u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_NormalState = new NodeId(21971u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_TrustListId = new NodeId(21972u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_LastUpdateTime = new NodeId(21973u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_UpdateFrequency = new NodeId(21974u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_GetRejectedList_OutputArguments = new NodeId(23545u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Size = new NodeId(13987u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Writable = new NodeId(13988u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable = new NodeId(13989u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount = new NodeId(13990u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments = new NodeId(13993u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments = new NodeId(13994u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments = new NodeId(13996u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments = new NodeId(13998u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments = new NodeId(13999u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments = new NodeId(14001u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments = new NodeId(14003u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments = new NodeId(14004u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments = new NodeId(14006u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime = new NodeId(14007u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments = new NodeId(14009u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments = new NodeId(14010u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments = new NodeId(14012u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments = new NodeId(14013u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments = new NodeId(14015u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments = new NodeId(14017u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateTypes = new NodeId(14018u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_EventId = new NodeId(21977u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_EventType = new NodeId(21978u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SourceNode = new NodeId(21979u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SourceName = new NodeId(21980u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Time = new NodeId(21981u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ReceiveTime = new NodeId(21982u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Message = new NodeId(21984u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Severity = new NodeId(21985u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ConditionClassId = new NodeId(21986u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ConditionClassName = new NodeId(21987u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ConditionName = new NodeId(21990u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_BranchId = new NodeId(21991u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Retain = new NodeId(21992u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_EnabledState = new NodeId(21993u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_EnabledState_Id = new NodeId(21994u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Quality = new NodeId(22002u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Quality_SourceTimestamp = new NodeId(22003u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_LastSeverity = new NodeId(22004u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(22005u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Comment = new NodeId(22006u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Comment_SourceTimestamp = new NodeId(22007u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ClientUserId = new NodeId(22008u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_AddComment_InputArguments = new NodeId(22012u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_AckedState = new NodeId(22013u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_AckedState_Id = new NodeId(22014u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ConfirmedState_Id = new NodeId(22023u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Acknowledge_InputArguments = new NodeId(22032u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Confirm_InputArguments = new NodeId(22034u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ActiveState = new NodeId(22035u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ActiveState_Id = new NodeId(22036u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_InputNode = new NodeId(22044u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SuppressedState_Id = new NodeId(22046u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_OutOfServiceState_Id = new NodeId(22055u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_CurrentState = new NodeId(22064u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(22065u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(22070u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(22077u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(22079u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SuppressedOrShelved = new NodeId(22082u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SilenceState_Id = new NodeId(22090u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_LatchedState_Id = new NodeId(22103u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_NormalState = new NodeId(22119u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ExpirationDate = new NodeId(22120u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_CertificateType = new NodeId(22122u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Certificate = new NodeId(22123u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_EventId = new NodeId(22125u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_EventType = new NodeId(22126u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SourceNode = new NodeId(22127u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SourceName = new NodeId(22128u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Time = new NodeId(22129u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ReceiveTime = new NodeId(22130u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Message = new NodeId(22132u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Severity = new NodeId(22133u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ConditionClassId = new NodeId(22134u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ConditionClassName = new NodeId(22135u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ConditionName = new NodeId(22138u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_BranchId = new NodeId(22139u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Retain = new NodeId(22140u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_EnabledState = new NodeId(22141u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_EnabledState_Id = new NodeId(22142u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Quality = new NodeId(22150u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(22151u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_LastSeverity = new NodeId(22152u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(22153u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Comment = new NodeId(22154u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(22155u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ClientUserId = new NodeId(22156u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_AddComment_InputArguments = new NodeId(22160u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_AckedState = new NodeId(22161u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_AckedState_Id = new NodeId(22162u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ConfirmedState_Id = new NodeId(22171u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(22180u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Confirm_InputArguments = new NodeId(22182u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ActiveState = new NodeId(22183u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ActiveState_Id = new NodeId(22184u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_InputNode = new NodeId(22192u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SuppressedState_Id = new NodeId(22194u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(22203u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(22212u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(22213u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(22218u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(22225u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(22227u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SuppressedOrShelved = new NodeId(22230u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SilenceState_Id = new NodeId(22238u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_LatchedState_Id = new NodeId(22251u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_NormalState = new NodeId(22267u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_TrustListId = new NodeId(22268u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_LastUpdateTime = new NodeId(22269u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_UpdateFrequency = new NodeId(22270u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_GetRejectedList_OutputArguments = new NodeId(23547u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Size = new NodeId(14021u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable = new NodeId(14022u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable = new NodeId(14023u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount = new NodeId(14024u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments = new NodeId(14027u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments = new NodeId(14028u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments = new NodeId(14030u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments = new NodeId(14032u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments = new NodeId(14033u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments = new NodeId(14035u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments = new NodeId(14037u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments = new NodeId(14038u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments = new NodeId(14040u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime = new NodeId(14041u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments = new NodeId(14043u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments = new NodeId(14044u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments = new NodeId(14046u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments = new NodeId(14047u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments = new NodeId(14049u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments = new NodeId(14051u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateTypes = new NodeId(14052u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_EventId = new NodeId(22273u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_EventType = new NodeId(22274u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SourceNode = new NodeId(22275u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SourceName = new NodeId(22276u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Time = new NodeId(22277u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ReceiveTime = new NodeId(22278u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Message = new NodeId(22280u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Severity = new NodeId(22281u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ConditionClassId = new NodeId(22282u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ConditionClassName = new NodeId(22283u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ConditionName = new NodeId(22286u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_BranchId = new NodeId(22287u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Retain = new NodeId(22288u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_EnabledState = new NodeId(22289u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_EnabledState_Id = new NodeId(22290u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Quality = new NodeId(22298u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Quality_SourceTimestamp = new NodeId(22299u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_LastSeverity = new NodeId(22300u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(22301u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Comment = new NodeId(22302u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Comment_SourceTimestamp = new NodeId(22303u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ClientUserId = new NodeId(22304u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_AddComment_InputArguments = new NodeId(22308u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_AckedState = new NodeId(22309u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_AckedState_Id = new NodeId(22310u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ConfirmedState_Id = new NodeId(22319u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Acknowledge_InputArguments = new NodeId(22328u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Confirm_InputArguments = new NodeId(22330u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ActiveState = new NodeId(22331u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ActiveState_Id = new NodeId(22332u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_InputNode = new NodeId(22340u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SuppressedState_Id = new NodeId(22342u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_OutOfServiceState_Id = new NodeId(22351u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_CurrentState = new NodeId(22360u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(22361u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(22366u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(22373u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(22375u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SuppressedOrShelved = new NodeId(22378u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SilenceState_Id = new NodeId(22386u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_LatchedState_Id = new NodeId(22399u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_NormalState = new NodeId(22415u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ExpirationDate = new NodeId(22416u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_CertificateType = new NodeId(22418u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Certificate = new NodeId(22419u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_EventId = new NodeId(22421u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_EventType = new NodeId(22422u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SourceNode = new NodeId(22423u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SourceName = new NodeId(22424u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Time = new NodeId(22425u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ReceiveTime = new NodeId(22426u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Message = new NodeId(22428u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Severity = new NodeId(22429u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ConditionClassId = new NodeId(22430u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ConditionClassName = new NodeId(22431u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ConditionName = new NodeId(22434u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_BranchId = new NodeId(22435u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Retain = new NodeId(22436u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_EnabledState = new NodeId(22437u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_EnabledState_Id = new NodeId(22438u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Quality = new NodeId(22446u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(22447u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_LastSeverity = new NodeId(22448u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(22449u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Comment = new NodeId(22450u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(22451u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ClientUserId = new NodeId(22452u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_AddComment_InputArguments = new NodeId(22456u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_AckedState = new NodeId(22457u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_AckedState_Id = new NodeId(22458u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ConfirmedState_Id = new NodeId(22467u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(22476u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Confirm_InputArguments = new NodeId(22478u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ActiveState = new NodeId(22479u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ActiveState_Id = new NodeId(22480u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_InputNode = new NodeId(22488u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SuppressedState_Id = new NodeId(22490u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(22499u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(22508u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(22509u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(22514u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(22521u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(22523u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SuppressedOrShelved = new NodeId(22526u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SilenceState_Id = new NodeId(22534u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_LatchedState_Id = new NodeId(22547u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_NormalState = new NodeId(22563u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_TrustListId = new NodeId(22564u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_LastUpdateTime = new NodeId(22565u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_UpdateFrequency = new NodeId(22566u);

	public static readonly NodeId ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_GetRejectedList_OutputArguments = new NodeId(23549u);

	public static readonly NodeId ServerConfigurationType_ServerCapabilities = new NodeId(12708u);

	public static readonly NodeId ServerConfigurationType_SupportedPrivateKeyFormats = new NodeId(12583u);

	public static readonly NodeId ServerConfigurationType_MaxTrustListSize = new NodeId(12584u);

	public static readonly NodeId ServerConfigurationType_MulticastDnsEnabled = new NodeId(12585u);

	public static readonly NodeId ServerConfigurationType_UpdateCertificate_InputArguments = new NodeId(12617u);

	public static readonly NodeId ServerConfigurationType_UpdateCertificate_OutputArguments = new NodeId(12618u);

	public static readonly NodeId ServerConfigurationType_CreateSigningRequest_InputArguments = new NodeId(12732u);

	public static readonly NodeId ServerConfigurationType_CreateSigningRequest_OutputArguments = new NodeId(12733u);

	public static readonly NodeId ServerConfigurationType_GetRejectedList_OutputArguments = new NodeId(12776u);

	public static readonly NodeId CertificateUpdatedAuditEventType_CertificateGroup = new NodeId(13735u);

	public static readonly NodeId CertificateUpdatedAuditEventType_CertificateType = new NodeId(13736u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Size = new NodeId(12643u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Writable = new NodeId(14157u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable = new NodeId(14158u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount = new NodeId(12646u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments = new NodeId(12648u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments = new NodeId(12649u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments = new NodeId(12651u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments = new NodeId(12653u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments = new NodeId(12654u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments = new NodeId(12656u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments = new NodeId(12658u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments = new NodeId(12659u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments = new NodeId(12661u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime = new NodeId(12662u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments = new NodeId(12664u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments = new NodeId(12665u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments = new NodeId(14160u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments = new NodeId(12667u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments = new NodeId(12669u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments = new NodeId(12671u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateTypes = new NodeId(14161u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_EventId = new NodeId(22569u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_EventType = new NodeId(22570u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SourceNode = new NodeId(22571u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SourceName = new NodeId(22572u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Time = new NodeId(22573u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ReceiveTime = new NodeId(22574u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Message = new NodeId(22576u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Severity = new NodeId(22577u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ConditionClassId = new NodeId(22578u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ConditionClassName = new NodeId(22579u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ConditionName = new NodeId(22582u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_BranchId = new NodeId(22583u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Retain = new NodeId(22584u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_EnabledState = new NodeId(22585u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_EnabledState_Id = new NodeId(22586u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Quality = new NodeId(22594u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Quality_SourceTimestamp = new NodeId(22595u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_LastSeverity = new NodeId(22596u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(22597u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Comment = new NodeId(22598u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Comment_SourceTimestamp = new NodeId(22599u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ClientUserId = new NodeId(22600u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_AddComment_InputArguments = new NodeId(22604u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_AckedState = new NodeId(22605u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_AckedState_Id = new NodeId(22606u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ConfirmedState_Id = new NodeId(22615u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Acknowledge_InputArguments = new NodeId(22624u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Confirm_InputArguments = new NodeId(22626u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ActiveState = new NodeId(22627u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ActiveState_Id = new NodeId(22628u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_InputNode = new NodeId(22636u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SuppressedState_Id = new NodeId(22638u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_OutOfServiceState_Id = new NodeId(22647u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_CurrentState = new NodeId(22656u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(22657u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(22662u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(22669u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(22671u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SuppressedOrShelved = new NodeId(22674u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_SilenceState_Id = new NodeId(22682u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_LatchedState_Id = new NodeId(22695u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_NormalState = new NodeId(22711u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ExpirationDate = new NodeId(22712u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_CertificateType = new NodeId(22714u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Certificate = new NodeId(22715u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_EventId = new NodeId(22717u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_EventType = new NodeId(22718u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SourceNode = new NodeId(22719u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SourceName = new NodeId(22720u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Time = new NodeId(22721u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ReceiveTime = new NodeId(22722u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Message = new NodeId(22724u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Severity = new NodeId(22725u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ConditionClassId = new NodeId(22726u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ConditionClassName = new NodeId(22727u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ConditionName = new NodeId(22730u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_BranchId = new NodeId(22731u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Retain = new NodeId(22732u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_EnabledState = new NodeId(22733u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_EnabledState_Id = new NodeId(22734u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Quality = new NodeId(22742u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(22743u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_LastSeverity = new NodeId(22744u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(22745u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Comment = new NodeId(22746u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(22747u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ClientUserId = new NodeId(22748u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_AddComment_InputArguments = new NodeId(22752u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_AckedState = new NodeId(22753u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_AckedState_Id = new NodeId(22754u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ConfirmedState_Id = new NodeId(22763u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(22772u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Confirm_InputArguments = new NodeId(22774u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ActiveState = new NodeId(22775u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ActiveState_Id = new NodeId(22776u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_InputNode = new NodeId(22784u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SuppressedState_Id = new NodeId(22786u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(22795u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(22804u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(22805u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(22810u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(22817u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(22819u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SuppressedOrShelved = new NodeId(22822u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_SilenceState_Id = new NodeId(22830u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_LatchedState_Id = new NodeId(22843u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_NormalState = new NodeId(22859u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_TrustListId = new NodeId(22860u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_LastUpdateTime = new NodeId(22861u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_UpdateFrequency = new NodeId(22862u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultApplicationGroup_GetRejectedList_OutputArguments = new NodeId(23551u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Size = new NodeId(14090u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Writable = new NodeId(14091u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable = new NodeId(14092u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount = new NodeId(14093u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments = new NodeId(14096u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments = new NodeId(14097u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments = new NodeId(14099u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments = new NodeId(14101u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments = new NodeId(14102u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments = new NodeId(14104u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments = new NodeId(14106u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments = new NodeId(14107u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments = new NodeId(14109u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime = new NodeId(14110u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments = new NodeId(14112u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments = new NodeId(14113u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments = new NodeId(14115u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments = new NodeId(14116u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments = new NodeId(14118u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments = new NodeId(14120u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateTypes = new NodeId(14121u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_EventId = new NodeId(22865u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_EventType = new NodeId(22866u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SourceNode = new NodeId(22867u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SourceName = new NodeId(22868u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Time = new NodeId(22869u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ReceiveTime = new NodeId(22870u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Message = new NodeId(22872u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Severity = new NodeId(22873u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ConditionClassId = new NodeId(22874u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ConditionClassName = new NodeId(22875u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ConditionName = new NodeId(22878u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_BranchId = new NodeId(22879u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Retain = new NodeId(22880u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_EnabledState = new NodeId(22881u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_EnabledState_Id = new NodeId(22882u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Quality = new NodeId(22890u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Quality_SourceTimestamp = new NodeId(22891u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_LastSeverity = new NodeId(22892u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(22893u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Comment = new NodeId(22894u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Comment_SourceTimestamp = new NodeId(22895u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ClientUserId = new NodeId(22896u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_AddComment_InputArguments = new NodeId(22900u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_AckedState = new NodeId(22901u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_AckedState_Id = new NodeId(22902u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ConfirmedState_Id = new NodeId(22911u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Acknowledge_InputArguments = new NodeId(22920u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Confirm_InputArguments = new NodeId(22922u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ActiveState = new NodeId(22923u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ActiveState_Id = new NodeId(22924u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_InputNode = new NodeId(22932u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SuppressedState_Id = new NodeId(22934u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_OutOfServiceState_Id = new NodeId(22943u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_CurrentState = new NodeId(22952u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(22953u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(22958u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(22965u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(22967u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SuppressedOrShelved = new NodeId(22970u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_SilenceState_Id = new NodeId(22978u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_LatchedState_Id = new NodeId(22991u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_NormalState = new NodeId(23007u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ExpirationDate = new NodeId(23008u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_CertificateType = new NodeId(23010u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Certificate = new NodeId(23011u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_EventId = new NodeId(23013u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_EventType = new NodeId(23014u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SourceNode = new NodeId(23015u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SourceName = new NodeId(23016u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Time = new NodeId(23017u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ReceiveTime = new NodeId(23018u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Message = new NodeId(23020u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Severity = new NodeId(23021u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ConditionClassId = new NodeId(23022u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ConditionClassName = new NodeId(23023u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ConditionName = new NodeId(23026u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_BranchId = new NodeId(23027u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Retain = new NodeId(23028u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_EnabledState = new NodeId(23029u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_EnabledState_Id = new NodeId(23030u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Quality = new NodeId(23038u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(23039u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_LastSeverity = new NodeId(23040u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(23041u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Comment = new NodeId(23042u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(23043u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ClientUserId = new NodeId(23044u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_AddComment_InputArguments = new NodeId(23048u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_AckedState = new NodeId(23049u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_AckedState_Id = new NodeId(23050u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ConfirmedState_Id = new NodeId(23059u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(23068u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Confirm_InputArguments = new NodeId(23070u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ActiveState = new NodeId(23071u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ActiveState_Id = new NodeId(23072u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_InputNode = new NodeId(23080u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SuppressedState_Id = new NodeId(23082u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(23091u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(23100u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(23101u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(23106u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(23113u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(23115u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SuppressedOrShelved = new NodeId(23118u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_SilenceState_Id = new NodeId(23126u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_LatchedState_Id = new NodeId(23139u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_NormalState = new NodeId(23155u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_TrustListId = new NodeId(23156u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_LastUpdateTime = new NodeId(23157u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_UpdateFrequency = new NodeId(23158u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultHttpsGroup_GetRejectedList_OutputArguments = new NodeId(23553u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Size = new NodeId(14124u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable = new NodeId(14125u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable = new NodeId(14126u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount = new NodeId(14127u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments = new NodeId(14130u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments = new NodeId(14131u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments = new NodeId(14133u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments = new NodeId(14135u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments = new NodeId(14136u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments = new NodeId(14138u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments = new NodeId(14140u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments = new NodeId(14141u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments = new NodeId(14143u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime = new NodeId(14144u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments = new NodeId(14146u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments = new NodeId(14147u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments = new NodeId(14149u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments = new NodeId(14150u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments = new NodeId(14152u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments = new NodeId(14154u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateTypes = new NodeId(14155u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_EventId = new NodeId(23161u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_EventType = new NodeId(23162u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SourceNode = new NodeId(23163u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SourceName = new NodeId(23164u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Time = new NodeId(23165u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ReceiveTime = new NodeId(23166u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Message = new NodeId(23168u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Severity = new NodeId(23169u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ConditionClassId = new NodeId(23170u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ConditionClassName = new NodeId(23171u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ConditionName = new NodeId(23174u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_BranchId = new NodeId(23175u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Retain = new NodeId(23176u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_EnabledState = new NodeId(23177u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_EnabledState_Id = new NodeId(23178u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Quality = new NodeId(23186u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Quality_SourceTimestamp = new NodeId(23187u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_LastSeverity = new NodeId(23188u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_LastSeverity_SourceTimestamp = new NodeId(23189u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Comment = new NodeId(23190u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Comment_SourceTimestamp = new NodeId(23191u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ClientUserId = new NodeId(23192u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_AddComment_InputArguments = new NodeId(23196u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_AckedState = new NodeId(23197u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_AckedState_Id = new NodeId(23198u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ConfirmedState_Id = new NodeId(23207u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Acknowledge_InputArguments = new NodeId(23216u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Confirm_InputArguments = new NodeId(23218u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ActiveState = new NodeId(23219u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ActiveState_Id = new NodeId(23220u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_InputNode = new NodeId(23228u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SuppressedState_Id = new NodeId(23230u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_OutOfServiceState_Id = new NodeId(23239u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_CurrentState = new NodeId(23248u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_CurrentState_Id = new NodeId(23249u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_LastTransition_Id = new NodeId(23254u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_UnshelveTime = new NodeId(23261u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_TimedShelve_InputArguments = new NodeId(23263u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SuppressedOrShelved = new NodeId(23266u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_SilenceState_Id = new NodeId(23274u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_LatchedState_Id = new NodeId(23287u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_NormalState = new NodeId(23303u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ExpirationDate = new NodeId(23304u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_CertificateType = new NodeId(23306u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Certificate = new NodeId(23307u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_EventId = new NodeId(23309u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_EventType = new NodeId(23310u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SourceNode = new NodeId(23311u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SourceName = new NodeId(23312u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Time = new NodeId(23313u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ReceiveTime = new NodeId(23314u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Message = new NodeId(23316u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Severity = new NodeId(23317u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ConditionClassId = new NodeId(23318u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ConditionClassName = new NodeId(23319u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ConditionName = new NodeId(23322u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_BranchId = new NodeId(23323u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Retain = new NodeId(23324u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_EnabledState = new NodeId(23325u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_EnabledState_Id = new NodeId(23326u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Quality = new NodeId(23334u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Quality_SourceTimestamp = new NodeId(23335u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_LastSeverity = new NodeId(23336u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_LastSeverity_SourceTimestamp = new NodeId(23337u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Comment = new NodeId(23338u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Comment_SourceTimestamp = new NodeId(23339u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ClientUserId = new NodeId(23340u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_AddComment_InputArguments = new NodeId(23344u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_AckedState = new NodeId(23345u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_AckedState_Id = new NodeId(23346u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ConfirmedState_Id = new NodeId(23355u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Acknowledge_InputArguments = new NodeId(23364u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Confirm_InputArguments = new NodeId(23366u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ActiveState = new NodeId(23367u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ActiveState_Id = new NodeId(23368u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_InputNode = new NodeId(23376u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SuppressedState_Id = new NodeId(23378u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_OutOfServiceState_Id = new NodeId(23387u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_CurrentState = new NodeId(23396u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_CurrentState_Id = new NodeId(23397u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_LastTransition_Id = new NodeId(23402u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_UnshelveTime = new NodeId(23409u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_TimedShelve_InputArguments = new NodeId(23411u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SuppressedOrShelved = new NodeId(23414u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_SilenceState_Id = new NodeId(23422u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_LatchedState_Id = new NodeId(23435u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_NormalState = new NodeId(23451u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_TrustListId = new NodeId(23452u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_LastUpdateTime = new NodeId(23453u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_UpdateFrequency = new NodeId(23454u);

	public static readonly NodeId ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_GetRejectedList_OutputArguments = new NodeId(23555u);

	public static readonly NodeId ServerConfiguration_ServerCapabilities = new NodeId(12710u);

	public static readonly NodeId ServerConfiguration_SupportedPrivateKeyFormats = new NodeId(12639u);

	public static readonly NodeId ServerConfiguration_MaxTrustListSize = new NodeId(12640u);

	public static readonly NodeId ServerConfiguration_MulticastDnsEnabled = new NodeId(12641u);

	public static readonly NodeId ServerConfiguration_UpdateCertificate_InputArguments = new NodeId(13738u);

	public static readonly NodeId ServerConfiguration_UpdateCertificate_OutputArguments = new NodeId(13739u);

	public static readonly NodeId ServerConfiguration_CreateSigningRequest_InputArguments = new NodeId(12738u);

	public static readonly NodeId ServerConfiguration_CreateSigningRequest_OutputArguments = new NodeId(12739u);

	public static readonly NodeId ServerConfiguration_GetRejectedList_OutputArguments = new NodeId(12778u);

	public static readonly NodeId KeyCredentialConfigurationFolderType_ServiceName_Placeholder_ResourceUri = new NodeId(17512u);

	public static readonly NodeId KeyCredentialConfigurationFolderType_ServiceName_Placeholder_ProfileUri = new NodeId(17513u);

	public static readonly NodeId KeyCredentialConfigurationFolderType_ServiceName_Placeholder_GetEncryptingKey_InputArguments = new NodeId(17517u);

	public static readonly NodeId KeyCredentialConfigurationFolderType_ServiceName_Placeholder_GetEncryptingKey_OutputArguments = new NodeId(17518u);

	public static readonly NodeId KeyCredentialConfigurationFolderType_ServiceName_Placeholder_UpdateCredential_InputArguments = new NodeId(17520u);

	public static readonly NodeId KeyCredentialConfigurationFolderType_CreateCredential_InputArguments = new NodeId(17523u);

	public static readonly NodeId KeyCredentialConfigurationFolderType_CreateCredential_OutputArguments = new NodeId(17524u);

	public static readonly NodeId KeyCredentialConfiguration_ServiceName_Placeholder_ResourceUri = new NodeId(18157u);

	public static readonly NodeId KeyCredentialConfiguration_ServiceName_Placeholder_ProfileUri = new NodeId(18164u);

	public static readonly NodeId KeyCredentialConfiguration_ServiceName_Placeholder_GetEncryptingKey_InputArguments = new NodeId(17526u);

	public static readonly NodeId KeyCredentialConfiguration_ServiceName_Placeholder_GetEncryptingKey_OutputArguments = new NodeId(17527u);

	public static readonly NodeId KeyCredentialConfiguration_ServiceName_Placeholder_UpdateCredential_InputArguments = new NodeId(18162u);

	public static readonly NodeId KeyCredentialConfiguration_CreateCredential_InputArguments = new NodeId(17529u);

	public static readonly NodeId KeyCredentialConfiguration_CreateCredential_OutputArguments = new NodeId(17530u);

	public static readonly NodeId KeyCredentialConfigurationType_ResourceUri = new NodeId(18069u);

	public static readonly NodeId KeyCredentialConfigurationType_ProfileUri = new NodeId(18165u);

	public static readonly NodeId KeyCredentialConfigurationType_EndpointUrls = new NodeId(18004u);

	public static readonly NodeId KeyCredentialConfigurationType_ServiceStatus = new NodeId(18005u);

	public static readonly NodeId KeyCredentialConfigurationType_GetEncryptingKey_InputArguments = new NodeId(17535u);

	public static readonly NodeId KeyCredentialConfigurationType_GetEncryptingKey_OutputArguments = new NodeId(17536u);

	public static readonly NodeId KeyCredentialConfigurationType_UpdateCredential_InputArguments = new NodeId(18007u);

	public static readonly NodeId KeyCredentialAuditEventType_ResourceUri = new NodeId(18028u);

	public static readonly NodeId AuthorizationServicesConfigurationFolderType_ServiceName_Placeholder_ServiceUri = new NodeId(23558u);

	public static readonly NodeId AuthorizationServicesConfigurationFolderType_ServiceName_Placeholder_ServiceCertificate = new NodeId(23559u);

	public static readonly NodeId AuthorizationServicesConfigurationFolderType_ServiceName_Placeholder_IssuerEndpointUrl = new NodeId(23560u);

	public static readonly NodeId AuthorizationServiceConfigurationType_ServiceUri = new NodeId(18072u);

	public static readonly NodeId AuthorizationServiceConfigurationType_ServiceCertificate = new NodeId(17860u);

	public static readonly NodeId AuthorizationServiceConfigurationType_IssuerEndpointUrl = new NodeId(18073u);

	public static readonly NodeId AggregateConfigurationType_TreatUncertainAsBad = new NodeId(11188u);

	public static readonly NodeId AggregateConfigurationType_PercentDataBad = new NodeId(11189u);

	public static readonly NodeId AggregateConfigurationType_PercentDataGood = new NodeId(11190u);

	public static readonly NodeId AggregateConfigurationType_UseSlopedExtrapolation = new NodeId(11191u);

	public static readonly NodeId PubSubState_EnumStrings = new NodeId(14648u);

	public static readonly NodeId DataSetFieldFlags_OptionSetValues = new NodeId(15577u);

	public static readonly NodeId DataSetFieldContentMask_OptionSetValues = new NodeId(15584u);

	public static readonly NodeId OverrideValueHandling_EnumStrings = new NodeId(15875u);

	public static readonly NodeId DataSetOrderingType_EnumStrings = new NodeId(15641u);

	public static readonly NodeId UadpNetworkMessageContentMask_OptionSetValues = new NodeId(15643u);

	public static readonly NodeId UadpDataSetMessageContentMask_OptionSetValues = new NodeId(15647u);

	public static readonly NodeId JsonNetworkMessageContentMask_OptionSetValues = new NodeId(15655u);

	public static readonly NodeId JsonDataSetMessageContentMask_OptionSetValues = new NodeId(15659u);

	public static readonly NodeId BrokerTransportQualityOfService_EnumStrings = new NodeId(15009u);

	public static readonly NodeId PubSubKeyServiceType_GetSecurityKeys_InputArguments = new NodeId(15908u);

	public static readonly NodeId PubSubKeyServiceType_GetSecurityKeys_OutputArguments = new NodeId(15909u);

	public static readonly NodeId PubSubKeyServiceType_GetSecurityGroup_InputArguments = new NodeId(15911u);

	public static readonly NodeId PubSubKeyServiceType_GetSecurityGroup_OutputArguments = new NodeId(15912u);

	public static readonly NodeId PubSubKeyServiceType_SecurityGroups_AddSecurityGroup_InputArguments = new NodeId(15915u);

	public static readonly NodeId PubSubKeyServiceType_SecurityGroups_AddSecurityGroup_OutputArguments = new NodeId(15916u);

	public static readonly NodeId PubSubKeyServiceType_SecurityGroups_RemoveSecurityGroup_InputArguments = new NodeId(15918u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupFolderName_Placeholder_AddSecurityGroup_InputArguments = new NodeId(15455u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupFolderName_Placeholder_AddSecurityGroup_OutputArguments = new NodeId(15456u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupFolderName_Placeholder_RemoveSecurityGroup_InputArguments = new NodeId(15458u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupName_Placeholder_SecurityGroupId = new NodeId(15460u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupName_Placeholder_KeyLifetime = new NodeId(15010u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupName_Placeholder_SecurityPolicyUri = new NodeId(15011u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupName_Placeholder_MaxFutureKeyCount = new NodeId(15012u);

	public static readonly NodeId SecurityGroupFolderType_SecurityGroupName_Placeholder_MaxPastKeyCount = new NodeId(15043u);

	public static readonly NodeId SecurityGroupFolderType_AddSecurityGroup_InputArguments = new NodeId(15462u);

	public static readonly NodeId SecurityGroupFolderType_AddSecurityGroup_OutputArguments = new NodeId(15463u);

	public static readonly NodeId SecurityGroupFolderType_RemoveSecurityGroup_InputArguments = new NodeId(15465u);

	public static readonly NodeId SecurityGroupType_SecurityGroupId = new NodeId(15472u);

	public static readonly NodeId SecurityGroupType_KeyLifetime = new NodeId(15046u);

	public static readonly NodeId SecurityGroupType_SecurityPolicyUri = new NodeId(15047u);

	public static readonly NodeId SecurityGroupType_MaxFutureKeyCount = new NodeId(15048u);

	public static readonly NodeId SecurityGroupType_MaxPastKeyCount = new NodeId(15056u);

	public static readonly NodeId PublishSubscribeType_GetSecurityKeys_InputArguments = new NodeId(15213u);

	public static readonly NodeId PublishSubscribeType_GetSecurityKeys_OutputArguments = new NodeId(15214u);

	public static readonly NodeId PublishSubscribeType_GetSecurityGroup_InputArguments = new NodeId(15432u);

	public static readonly NodeId PublishSubscribeType_GetSecurityGroup_OutputArguments = new NodeId(15433u);

	public static readonly NodeId PublishSubscribeType_SecurityGroups_AddSecurityGroup_InputArguments = new NodeId(15436u);

	public static readonly NodeId PublishSubscribeType_SecurityGroups_AddSecurityGroup_OutputArguments = new NodeId(15437u);

	public static readonly NodeId PublishSubscribeType_SecurityGroups_RemoveSecurityGroup_InputArguments = new NodeId(15439u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_PublisherId = new NodeId(14418u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_TransportProfileUri = new NodeId(17292u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_TransportProfileUri_Selections = new NodeId(17706u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_ConnectionProperties = new NodeId(17478u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Address_NetworkInterface = new NodeId(15533u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Address_NetworkInterface_Selections = new NodeId(17503u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Status_State = new NodeId(14420u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_DiagnosticsLevel = new NodeId(18668u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_TotalInformation = new NodeId(18669u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_TotalInformation_Active = new NodeId(18670u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_TotalInformation_Classification = new NodeId(18671u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(18672u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_TotalError = new NodeId(18674u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_TotalError_Active = new NodeId(18675u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_TotalError_Classification = new NodeId(18676u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(18677u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_SubError = new NodeId(18680u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateError = new NodeId(18682u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateError_Active = new NodeId(18683u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateError_Classification = new NodeId(18684u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(18685u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByMethod = new NodeId(18687u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(18688u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(18689u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(18690u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByParent = new NodeId(18692u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(18693u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(18694u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(18695u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalFromError = new NodeId(18697u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(18698u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(18699u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(18700u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StatePausedByParent = new NodeId(18702u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(18703u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(18704u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(18705u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateDisabledByMethod = new NodeId(18707u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(18708u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(18709u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(18710u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_LiveValues_ResolvedAddress = new NodeId(18713u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_LiveValues_ResolvedAddress_DiagnosticsLevel = new NodeId(18714u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_AddWriterGroup_InputArguments = new NodeId(16558u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_AddWriterGroup_OutputArguments = new NodeId(16559u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_AddReaderGroup_InputArguments = new NodeId(16561u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_AddReaderGroup_OutputArguments = new NodeId(16571u);

	public static readonly NodeId PublishSubscribeType_ConnectionName_Placeholder_RemoveGroup_InputArguments = new NodeId(14425u);

	public static readonly NodeId PublishSubscribeType_SetSecurityKeys_InputArguments = new NodeId(17297u);

	public static readonly NodeId PublishSubscribeType_AddConnection_InputArguments = new NodeId(16599u);

	public static readonly NodeId PublishSubscribeType_AddConnection_OutputArguments = new NodeId(16600u);

	public static readonly NodeId PublishSubscribeType_RemoveConnection_InputArguments = new NodeId(14433u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddPublishedDataItems_InputArguments = new NodeId(14436u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddPublishedDataItems_OutputArguments = new NodeId(14437u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddPublishedEvents_InputArguments = new NodeId(14439u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddPublishedEvents_OutputArguments = new NodeId(14440u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddPublishedDataItemsTemplate_InputArguments = new NodeId(16611u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddPublishedDataItemsTemplate_OutputArguments = new NodeId(16638u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddPublishedEventsTemplate_InputArguments = new NodeId(16640u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddPublishedEventsTemplate_OutputArguments = new NodeId(16641u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_RemovePublishedDataSet_InputArguments = new NodeId(14442u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddDataSetFolder_InputArguments = new NodeId(16678u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_AddDataSetFolder_OutputArguments = new NodeId(16679u);

	public static readonly NodeId PublishSubscribeType_PublishedDataSets_RemoveDataSetFolder_InputArguments = new NodeId(16681u);

	public static readonly NodeId PublishSubscribeType_Status_State = new NodeId(15845u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_DiagnosticsLevel = new NodeId(18716u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_TotalInformation = new NodeId(18717u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_TotalInformation_Active = new NodeId(18718u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_TotalInformation_Classification = new NodeId(18719u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(18720u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_TotalError = new NodeId(18722u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_TotalError_Active = new NodeId(18723u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_TotalError_Classification = new NodeId(18724u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(18725u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_SubError = new NodeId(18728u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateError = new NodeId(18730u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateError_Active = new NodeId(18731u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateError_Classification = new NodeId(18732u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(18733u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalByMethod = new NodeId(18735u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(18736u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(18737u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(18738u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalByParent = new NodeId(18740u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(18741u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(18742u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(18743u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalFromError = new NodeId(18745u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(18746u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(18747u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(18748u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StatePausedByParent = new NodeId(18750u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(18751u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(18752u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(18753u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateDisabledByMethod = new NodeId(18755u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(18756u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(18757u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(18758u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_LiveValues_ConfiguredDataSetWriters = new NodeId(18761u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_LiveValues_ConfiguredDataSetWriters_DiagnosticsLevel = new NodeId(18762u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_LiveValues_ConfiguredDataSetReaders = new NodeId(18763u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_LiveValues_ConfiguredDataSetReaders_DiagnosticsLevel = new NodeId(18764u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_LiveValues_OperationalDataSetWriters = new NodeId(18765u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_LiveValues_OperationalDataSetWriters_DiagnosticsLevel = new NodeId(18766u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_LiveValues_OperationalDataSetReaders = new NodeId(18767u);

	public static readonly NodeId PublishSubscribeType_Diagnostics_LiveValues_OperationalDataSetReaders_DiagnosticsLevel = new NodeId(18768u);

	public static readonly NodeId PublishSubscribeType_SupportedTransportProfiles = new NodeId(17479u);

	public static readonly NodeId PublishSubscribe_GetSecurityKeys_InputArguments = new NodeId(15216u);

	public static readonly NodeId PublishSubscribe_GetSecurityKeys_OutputArguments = new NodeId(15217u);

	public static readonly NodeId PublishSubscribe_GetSecurityGroup_InputArguments = new NodeId(15441u);

	public static readonly NodeId PublishSubscribe_GetSecurityGroup_OutputArguments = new NodeId(15442u);

	public static readonly NodeId PublishSubscribe_SecurityGroups_AddSecurityGroup_InputArguments = new NodeId(15445u);

	public static readonly NodeId PublishSubscribe_SecurityGroups_AddSecurityGroup_OutputArguments = new NodeId(15446u);

	public static readonly NodeId PublishSubscribe_SecurityGroups_RemoveSecurityGroup_InputArguments = new NodeId(15448u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_PublisherId = new NodeId(15791u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_TransportProfileUri = new NodeId(15792u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_TransportProfileUri_Selections = new NodeId(15848u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_ConnectionProperties = new NodeId(17480u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Address_NetworkInterface = new NodeId(15863u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Address_NetworkInterface_Selections = new NodeId(17506u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Status_State = new NodeId(15892u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_DiagnosticsLevel = new NodeId(15938u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_TotalInformation = new NodeId(15939u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_TotalInformation_Active = new NodeId(15989u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_TotalInformation_Classification = new NodeId(15994u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(16013u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_TotalError = new NodeId(16059u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_TotalError_Active = new NodeId(16060u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_TotalError_Classification = new NodeId(16061u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(16074u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_SubError = new NodeId(16101u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateError = new NodeId(16103u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateError_Active = new NodeId(16122u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateError_Classification = new NodeId(16123u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(16124u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByMethod = new NodeId(16283u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(16322u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(16523u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(17300u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByParent = new NodeId(17304u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(17305u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(17320u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(17335u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalFromError = new NodeId(17337u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(17338u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(17339u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(17340u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StatePausedByParent = new NodeId(17342u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(17343u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(17344u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(17345u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateDisabledByMethod = new NodeId(17347u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(17348u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(17349u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(17350u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_LiveValues_ResolvedAddress = new NodeId(17353u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_Diagnostics_LiveValues_ResolvedAddress_DiagnosticsLevel = new NodeId(17354u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_AddWriterGroup_InputArguments = new NodeId(17357u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_AddWriterGroup_OutputArguments = new NodeId(17358u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_AddReaderGroup_InputArguments = new NodeId(17360u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_AddReaderGroup_OutputArguments = new NodeId(17361u);

	public static readonly NodeId PublishSubscribe_ConnectionName_Placeholder_RemoveGroup_InputArguments = new NodeId(17363u);

	public static readonly NodeId PublishSubscribe_SetSecurityKeys_InputArguments = new NodeId(17365u);

	public static readonly NodeId PublishSubscribe_AddConnection_InputArguments = new NodeId(17367u);

	public static readonly NodeId PublishSubscribe_AddConnection_OutputArguments = new NodeId(17368u);

	public static readonly NodeId PublishSubscribe_RemoveConnection_InputArguments = new NodeId(17370u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddPublishedDataItems_InputArguments = new NodeId(17373u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddPublishedDataItems_OutputArguments = new NodeId(17374u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddPublishedEvents_InputArguments = new NodeId(17376u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddPublishedEvents_OutputArguments = new NodeId(17377u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddPublishedDataItemsTemplate_InputArguments = new NodeId(17379u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddPublishedDataItemsTemplate_OutputArguments = new NodeId(17380u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddPublishedEventsTemplate_InputArguments = new NodeId(17382u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddPublishedEventsTemplate_OutputArguments = new NodeId(17383u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_RemovePublishedDataSet_InputArguments = new NodeId(17385u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddDataSetFolder_InputArguments = new NodeId(17401u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_AddDataSetFolder_OutputArguments = new NodeId(17402u);

	public static readonly NodeId PublishSubscribe_PublishedDataSets_RemoveDataSetFolder_InputArguments = new NodeId(17404u);

	public static readonly NodeId PublishSubscribe_Status_State = new NodeId(17406u);

	public static readonly NodeId PublishSubscribe_Diagnostics_DiagnosticsLevel = new NodeId(17410u);

	public static readonly NodeId PublishSubscribe_Diagnostics_TotalInformation = new NodeId(17411u);

	public static readonly NodeId PublishSubscribe_Diagnostics_TotalInformation_Active = new NodeId(17412u);

	public static readonly NodeId PublishSubscribe_Diagnostics_TotalInformation_Classification = new NodeId(17413u);

	public static readonly NodeId PublishSubscribe_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(17414u);

	public static readonly NodeId PublishSubscribe_Diagnostics_TotalError = new NodeId(17416u);

	public static readonly NodeId PublishSubscribe_Diagnostics_TotalError_Active = new NodeId(17417u);

	public static readonly NodeId PublishSubscribe_Diagnostics_TotalError_Classification = new NodeId(17418u);

	public static readonly NodeId PublishSubscribe_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(17419u);

	public static readonly NodeId PublishSubscribe_Diagnostics_SubError = new NodeId(17422u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateError = new NodeId(17424u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateError_Active = new NodeId(17425u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateError_Classification = new NodeId(17426u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(17429u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalByMethod = new NodeId(17431u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(17432u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(17433u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(17434u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalByParent = new NodeId(17436u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(17437u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(17438u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(17439u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalFromError = new NodeId(17441u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(17442u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(17443u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(17444u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StatePausedByParent = new NodeId(17446u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(17447u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(17448u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(17449u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateDisabledByMethod = new NodeId(17451u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(17452u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(17453u);

	public static readonly NodeId PublishSubscribe_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(17454u);

	public static readonly NodeId PublishSubscribe_Diagnostics_LiveValues_ConfiguredDataSetWriters = new NodeId(17458u);

	public static readonly NodeId PublishSubscribe_Diagnostics_LiveValues_ConfiguredDataSetWriters_DiagnosticsLevel = new NodeId(17459u);

	public static readonly NodeId PublishSubscribe_Diagnostics_LiveValues_ConfiguredDataSetReaders = new NodeId(17460u);

	public static readonly NodeId PublishSubscribe_Diagnostics_LiveValues_ConfiguredDataSetReaders_DiagnosticsLevel = new NodeId(17461u);

	public static readonly NodeId PublishSubscribe_Diagnostics_LiveValues_OperationalDataSetWriters = new NodeId(17462u);

	public static readonly NodeId PublishSubscribe_Diagnostics_LiveValues_OperationalDataSetWriters_DiagnosticsLevel = new NodeId(17463u);

	public static readonly NodeId PublishSubscribe_Diagnostics_LiveValues_OperationalDataSetReaders = new NodeId(17464u);

	public static readonly NodeId PublishSubscribe_Diagnostics_LiveValues_OperationalDataSetReaders_DiagnosticsLevel = new NodeId(17466u);

	public static readonly NodeId PublishSubscribe_SupportedTransportProfiles = new NodeId(17481u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_DataSetWriterId = new NodeId(16720u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_DataSetFieldContentMask = new NodeId(16721u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_DataSetWriterProperties = new NodeId(17482u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Status_State = new NodeId(15224u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_DiagnosticsLevel = new NodeId(18872u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation = new NodeId(18873u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_Active = new NodeId(18874u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_Classification = new NodeId(18875u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(18876u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_TotalError = new NodeId(18878u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_TotalError_Active = new NodeId(18879u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_TotalError_Classification = new NodeId(18880u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(18881u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_SubError = new NodeId(18884u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError = new NodeId(18886u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_Active = new NodeId(18887u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_Classification = new NodeId(18888u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(18889u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod = new NodeId(18891u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(18892u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(18893u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(18894u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent = new NodeId(18896u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(18897u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(18898u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(18899u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError = new NodeId(18901u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(18902u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(18903u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(18904u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent = new NodeId(18906u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(18907u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(18908u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(18909u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod = new NodeId(18911u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(18912u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(18913u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(18914u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages = new NodeId(18917u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Active = new NodeId(18918u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Classification = new NodeId(18919u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_DiagnosticsLevel = new NodeId(18920u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MessageSequenceNumber_DiagnosticsLevel = new NodeId(18923u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_StatusCode_DiagnosticsLevel = new NodeId(18925u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MajorVersion_DiagnosticsLevel = new NodeId(18927u);

	public static readonly NodeId PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MinorVersion_DiagnosticsLevel = new NodeId(18929u);

	public static readonly NodeId PublishedDataSetType_ConfigurationVersion = new NodeId(14519u);

	public static readonly NodeId PublishedDataSetType_DataSetMetaData = new NodeId(15229u);

	public static readonly NodeId PublishedDataSetType_DataSetClassId = new NodeId(16759u);

	public static readonly NodeId PublishedDataSetType_ExtensionFields_AddExtensionField_InputArguments = new NodeId(15483u);

	public static readonly NodeId PublishedDataSetType_ExtensionFields_AddExtensionField_OutputArguments = new NodeId(15484u);

	public static readonly NodeId PublishedDataSetType_ExtensionFields_RemoveExtensionField_InputArguments = new NodeId(15486u);

	public static readonly NodeId ExtensionFieldsType_ExtensionFieldName_Placeholder = new NodeId(15490u);

	public static readonly NodeId ExtensionFieldsType_AddExtensionField_InputArguments = new NodeId(15492u);

	public static readonly NodeId ExtensionFieldsType_AddExtensionField_OutputArguments = new NodeId(15493u);

	public static readonly NodeId ExtensionFieldsType_RemoveExtensionField_InputArguments = new NodeId(15495u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_DataSetWriterId = new NodeId(16760u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_DataSetFieldContentMask = new NodeId(16761u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_DataSetWriterProperties = new NodeId(17483u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Status_State = new NodeId(15232u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_DiagnosticsLevel = new NodeId(18931u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation = new NodeId(18932u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_Active = new NodeId(18933u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_Classification = new NodeId(18934u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(18935u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_TotalError = new NodeId(18937u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_TotalError_Active = new NodeId(18938u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_TotalError_Classification = new NodeId(18939u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(18940u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_SubError = new NodeId(18943u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError = new NodeId(18945u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_Active = new NodeId(18946u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_Classification = new NodeId(18947u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(18948u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod = new NodeId(18950u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(18951u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(18952u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(18953u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent = new NodeId(18955u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(18956u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(18957u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(18958u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError = new NodeId(18960u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(18961u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(18962u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(18963u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent = new NodeId(18965u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(18966u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(18967u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(18968u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod = new NodeId(18970u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(18971u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(18972u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(18973u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages = new NodeId(18976u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Active = new NodeId(18977u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Classification = new NodeId(18978u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_DiagnosticsLevel = new NodeId(18979u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MessageSequenceNumber_DiagnosticsLevel = new NodeId(18982u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_StatusCode_DiagnosticsLevel = new NodeId(18984u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MajorVersion_DiagnosticsLevel = new NodeId(18986u);

	public static readonly NodeId PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MinorVersion_DiagnosticsLevel = new NodeId(18988u);

	public static readonly NodeId PublishedDataItemsType_ExtensionFields_AddExtensionField_InputArguments = new NodeId(15505u);

	public static readonly NodeId PublishedDataItemsType_ExtensionFields_AddExtensionField_OutputArguments = new NodeId(15506u);

	public static readonly NodeId PublishedDataItemsType_ExtensionFields_RemoveExtensionField_InputArguments = new NodeId(15508u);

	public static readonly NodeId PublishedDataItemsType_PublishedData = new NodeId(14548u);

	public static readonly NodeId PublishedDataItemsType_AddVariables_InputArguments = new NodeId(14556u);

	public static readonly NodeId PublishedDataItemsType_AddVariables_OutputArguments = new NodeId(14557u);

	public static readonly NodeId PublishedDataItemsType_RemoveVariables_InputArguments = new NodeId(14559u);

	public static readonly NodeId PublishedDataItemsType_RemoveVariables_OutputArguments = new NodeId(14560u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_DataSetWriterId = new NodeId(16801u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_DataSetFieldContentMask = new NodeId(16802u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_DataSetWriterProperties = new NodeId(17484u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Status_State = new NodeId(15240u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_DiagnosticsLevel = new NodeId(18990u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation = new NodeId(18991u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_Active = new NodeId(18992u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_Classification = new NodeId(18993u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(18994u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_TotalError = new NodeId(18996u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_TotalError_Active = new NodeId(18997u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_TotalError_Classification = new NodeId(18998u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(18999u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_SubError = new NodeId(19002u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError = new NodeId(19004u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_Active = new NodeId(19005u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_Classification = new NodeId(19006u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(19007u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod = new NodeId(19009u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(19010u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(19011u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19012u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent = new NodeId(19014u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(19015u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(19016u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19017u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError = new NodeId(19019u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(19020u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(19021u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19022u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent = new NodeId(19024u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(19025u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(19026u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19027u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod = new NodeId(19029u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(19030u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(19031u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19032u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages = new NodeId(19035u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Active = new NodeId(19036u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Classification = new NodeId(19037u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_DiagnosticsLevel = new NodeId(19038u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MessageSequenceNumber_DiagnosticsLevel = new NodeId(19041u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_StatusCode_DiagnosticsLevel = new NodeId(19043u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MajorVersion_DiagnosticsLevel = new NodeId(19045u);

	public static readonly NodeId PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MinorVersion_DiagnosticsLevel = new NodeId(19047u);

	public static readonly NodeId PublishedEventsType_ExtensionFields_AddExtensionField_InputArguments = new NodeId(15513u);

	public static readonly NodeId PublishedEventsType_ExtensionFields_AddExtensionField_OutputArguments = new NodeId(15514u);

	public static readonly NodeId PublishedEventsType_ExtensionFields_RemoveExtensionField_InputArguments = new NodeId(15516u);

	public static readonly NodeId PublishedEventsType_PubSubEventNotifier = new NodeId(14586u);

	public static readonly NodeId PublishedEventsType_SelectedFields = new NodeId(14587u);

	public static readonly NodeId PublishedEventsType_Filter = new NodeId(14588u);

	public static readonly NodeId PublishedEventsType_ModifyFieldSelection_InputArguments = new NodeId(15053u);

	public static readonly NodeId PublishedEventsType_ModifyFieldSelection_OutputArguments = new NodeId(15517u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedDataItems_InputArguments = new NodeId(14480u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedDataItems_OutputArguments = new NodeId(14481u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedEvents_InputArguments = new NodeId(14483u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedEvents_OutputArguments = new NodeId(14484u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedDataItemsTemplate_InputArguments = new NodeId(16843u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedDataItemsTemplate_OutputArguments = new NodeId(16853u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedEventsTemplate_InputArguments = new NodeId(16882u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedEventsTemplate_OutputArguments = new NodeId(16883u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_RemovePublishedDataSet_InputArguments = new NodeId(14486u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddDataSetFolder_InputArguments = new NodeId(16894u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_AddDataSetFolder_OutputArguments = new NodeId(16922u);

	public static readonly NodeId DataSetFolderType_DataSetFolderName_Placeholder_RemoveDataSetFolder_InputArguments = new NodeId(16924u);

	public static readonly NodeId DataSetFolderType_PublishedDataSetName_Placeholder_ConfigurationVersion = new NodeId(14489u);

	public static readonly NodeId DataSetFolderType_PublishedDataSetName_Placeholder_DataSetMetaData = new NodeId(15221u);

	public static readonly NodeId DataSetFolderType_PublishedDataSetName_Placeholder_ExtensionFields_AddExtensionField_InputArguments = new NodeId(15475u);

	public static readonly NodeId DataSetFolderType_PublishedDataSetName_Placeholder_ExtensionFields_AddExtensionField_OutputArguments = new NodeId(15476u);

	public static readonly NodeId DataSetFolderType_PublishedDataSetName_Placeholder_ExtensionFields_RemoveExtensionField_InputArguments = new NodeId(15478u);

	public static readonly NodeId DataSetFolderType_AddPublishedDataItems_InputArguments = new NodeId(14494u);

	public static readonly NodeId DataSetFolderType_AddPublishedDataItems_OutputArguments = new NodeId(14495u);

	public static readonly NodeId DataSetFolderType_AddPublishedEvents_InputArguments = new NodeId(14497u);

	public static readonly NodeId DataSetFolderType_AddPublishedEvents_OutputArguments = new NodeId(14498u);

	public static readonly NodeId DataSetFolderType_AddPublishedDataItemsTemplate_InputArguments = new NodeId(16958u);

	public static readonly NodeId DataSetFolderType_AddPublishedDataItemsTemplate_OutputArguments = new NodeId(16959u);

	public static readonly NodeId DataSetFolderType_AddPublishedEventsTemplate_InputArguments = new NodeId(16961u);

	public static readonly NodeId DataSetFolderType_AddPublishedEventsTemplate_OutputArguments = new NodeId(16971u);

	public static readonly NodeId DataSetFolderType_RemovePublishedDataSet_InputArguments = new NodeId(14500u);

	public static readonly NodeId DataSetFolderType_AddDataSetFolder_InputArguments = new NodeId(16995u);

	public static readonly NodeId DataSetFolderType_AddDataSetFolder_OutputArguments = new NodeId(16996u);

	public static readonly NodeId DataSetFolderType_RemoveDataSetFolder_InputArguments = new NodeId(17007u);

	public static readonly NodeId PubSubConnectionType_PublisherId = new NodeId(14595u);

	public static readonly NodeId PubSubConnectionType_TransportProfileUri = new NodeId(17306u);

	public static readonly NodeId PubSubConnectionType_TransportProfileUri_Selections = new NodeId(17710u);

	public static readonly NodeId PubSubConnectionType_ConnectionProperties = new NodeId(17485u);

	public static readonly NodeId PubSubConnectionType_Address_NetworkInterface = new NodeId(17202u);

	public static readonly NodeId PubSubConnectionType_Address_NetworkInterface_Selections = new NodeId(17576u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_SecurityMode = new NodeId(17311u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_MaxNetworkMessageSize = new NodeId(17204u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_GroupProperties = new NodeId(17486u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Status_State = new NodeId(17315u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_WriterGroupId = new NodeId(17214u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_PublishingInterval = new NodeId(17318u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_KeepAliveTime = new NodeId(17319u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Priority = new NodeId(17321u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_LocaleIds = new NodeId(17322u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_HeaderLayoutUri = new NodeId(17558u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_DiagnosticsLevel = new NodeId(19108u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_TotalInformation = new NodeId(19109u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_TotalInformation_Active = new NodeId(19110u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_TotalInformation_Classification = new NodeId(19111u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(19112u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_TotalError = new NodeId(19114u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_TotalError_Active = new NodeId(19115u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_TotalError_Classification = new NodeId(19116u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(19117u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_SubError = new NodeId(19120u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateError = new NodeId(19122u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateError_Active = new NodeId(19123u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateError_Classification = new NodeId(19124u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(19125u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalByMethod = new NodeId(19127u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(19128u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(19129u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19130u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalByParent = new NodeId(19132u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(19133u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(19134u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19135u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalFromError = new NodeId(19137u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(19138u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(19139u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19140u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StatePausedByParent = new NodeId(19142u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(19143u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(19144u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19145u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateDisabledByMethod = new NodeId(19147u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(19148u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(19149u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19150u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_SentNetworkMessages = new NodeId(19153u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_SentNetworkMessages_Active = new NodeId(19154u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_SentNetworkMessages_Classification = new NodeId(19155u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_SentNetworkMessages_DiagnosticsLevel = new NodeId(19156u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_FailedTransmissions = new NodeId(19158u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_FailedTransmissions_Active = new NodeId(19159u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_FailedTransmissions_Classification = new NodeId(19160u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_FailedTransmissions_DiagnosticsLevel = new NodeId(19161u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_EncryptionErrors = new NodeId(19163u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_EncryptionErrors_Active = new NodeId(19164u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_EncryptionErrors_Classification = new NodeId(19165u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Counters_EncryptionErrors_DiagnosticsLevel = new NodeId(19166u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_LiveValues_ConfiguredDataSetWriters = new NodeId(19168u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_LiveValues_ConfiguredDataSetWriters_DiagnosticsLevel = new NodeId(19169u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_LiveValues_OperationalDataSetWriters = new NodeId(19170u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_LiveValues_OperationalDataSetWriters_DiagnosticsLevel = new NodeId(19171u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_LiveValues_SecurityTokenID_DiagnosticsLevel = new NodeId(19173u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_LiveValues_TimeToNextTokenID_DiagnosticsLevel = new NodeId(19175u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_AddDataSetWriter_InputArguments = new NodeId(17294u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_AddDataSetWriter_OutputArguments = new NodeId(17301u);

	public static readonly NodeId PubSubConnectionType_WriterGroupName_Placeholder_RemoveDataSetWriter_InputArguments = new NodeId(17324u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_SecurityMode = new NodeId(17326u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_MaxNetworkMessageSize = new NodeId(17302u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_GroupProperties = new NodeId(17487u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Status_State = new NodeId(17330u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_DiagnosticsLevel = new NodeId(19177u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_TotalInformation = new NodeId(19178u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_TotalInformation_Active = new NodeId(19179u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_TotalInformation_Classification = new NodeId(19180u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(19181u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_TotalError = new NodeId(19183u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_TotalError_Active = new NodeId(19184u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_TotalError_Classification = new NodeId(19185u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(19186u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_SubError = new NodeId(19189u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateError = new NodeId(19191u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateError_Active = new NodeId(19192u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateError_Classification = new NodeId(19193u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(19194u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalByMethod = new NodeId(19196u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(19197u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(19198u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19199u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalByParent = new NodeId(19201u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(19202u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(19203u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19204u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalFromError = new NodeId(19206u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(19207u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(19208u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19209u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StatePausedByParent = new NodeId(19211u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(19212u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(19213u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19214u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateDisabledByMethod = new NodeId(19216u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(19217u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(19218u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19219u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_ReceivedNetworkMessages = new NodeId(19222u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_ReceivedNetworkMessages_Active = new NodeId(19223u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_ReceivedNetworkMessages_Classification = new NodeId(19224u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_ReceivedNetworkMessages_DiagnosticsLevel = new NodeId(19225u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_ReceivedInvalidNetworkMessages_Active = new NodeId(19228u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_ReceivedInvalidNetworkMessages_Classification = new NodeId(19229u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_ReceivedInvalidNetworkMessages_DiagnosticsLevel = new NodeId(19230u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_DecryptionErrors_Active = new NodeId(19233u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_DecryptionErrors_Classification = new NodeId(19234u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Counters_DecryptionErrors_DiagnosticsLevel = new NodeId(19235u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_LiveValues_ConfiguredDataSetReaders = new NodeId(19237u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_LiveValues_ConfiguredDataSetReaders_DiagnosticsLevel = new NodeId(19238u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_LiveValues_OperationalDataSetReaders = new NodeId(19239u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_LiveValues_OperationalDataSetReaders_DiagnosticsLevel = new NodeId(19240u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_AddDataSetReader_InputArguments = new NodeId(17399u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_AddDataSetReader_OutputArguments = new NodeId(17400u);

	public static readonly NodeId PubSubConnectionType_ReaderGroupName_Placeholder_RemoveDataSetReader_InputArguments = new NodeId(17334u);

	public static readonly NodeId PubSubConnectionType_Status_State = new NodeId(14601u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_DiagnosticsLevel = new NodeId(19242u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_TotalInformation = new NodeId(19243u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_TotalInformation_Active = new NodeId(19244u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_TotalInformation_Classification = new NodeId(19245u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(19246u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_TotalError = new NodeId(19248u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_TotalError_Active = new NodeId(19249u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_TotalError_Classification = new NodeId(19250u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(19251u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_SubError = new NodeId(19254u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateError = new NodeId(19256u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateError_Active = new NodeId(19257u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateError_Classification = new NodeId(19258u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(19259u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalByMethod = new NodeId(19261u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(19262u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(19263u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19264u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalByParent = new NodeId(19266u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(19267u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(19268u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19269u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalFromError = new NodeId(19271u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(19272u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(19273u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19274u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StatePausedByParent = new NodeId(19276u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(19277u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(19278u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19279u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateDisabledByMethod = new NodeId(19281u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(19282u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(19283u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19284u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_LiveValues_ResolvedAddress = new NodeId(19287u);

	public static readonly NodeId PubSubConnectionType_Diagnostics_LiveValues_ResolvedAddress_DiagnosticsLevel = new NodeId(19288u);

	public static readonly NodeId PubSubConnectionType_AddWriterGroup_InputArguments = new NodeId(17428u);

	public static readonly NodeId PubSubConnectionType_AddWriterGroup_OutputArguments = new NodeId(17456u);

	public static readonly NodeId PubSubConnectionType_AddReaderGroup_InputArguments = new NodeId(17507u);

	public static readonly NodeId PubSubConnectionType_AddReaderGroup_OutputArguments = new NodeId(17508u);

	public static readonly NodeId PubSubConnectionType_RemoveGroup_InputArguments = new NodeId(14226u);

	public static readonly NodeId PubSubGroupType_SecurityMode = new NodeId(15926u);

	public static readonly NodeId PubSubGroupType_SecurityGroupId = new NodeId(15927u);

	public static readonly NodeId PubSubGroupType_SecurityKeyServices = new NodeId(15928u);

	public static readonly NodeId PubSubGroupType_MaxNetworkMessageSize = new NodeId(17724u);

	public static readonly NodeId PubSubGroupType_GroupProperties = new NodeId(17488u);

	public static readonly NodeId PubSubGroupType_Status_State = new NodeId(15266u);

	public static readonly NodeId WriterGroupType_Status_State = new NodeId(17731u);

	public static readonly NodeId WriterGroupType_WriterGroupId = new NodeId(17736u);

	public static readonly NodeId WriterGroupType_PublishingInterval = new NodeId(17737u);

	public static readonly NodeId WriterGroupType_KeepAliveTime = new NodeId(17738u);

	public static readonly NodeId WriterGroupType_Priority = new NodeId(17739u);

	public static readonly NodeId WriterGroupType_LocaleIds = new NodeId(17740u);

	public static readonly NodeId WriterGroupType_HeaderLayoutUri = new NodeId(17559u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_DataSetWriterId = new NodeId(17744u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_DataSetFieldContentMask = new NodeId(17745u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_DataSetWriterProperties = new NodeId(17490u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Status_State = new NodeId(17750u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_DiagnosticsLevel = new NodeId(17754u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation = new NodeId(17755u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_Active = new NodeId(17756u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_Classification = new NodeId(17757u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(17758u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_TotalError = new NodeId(17760u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_TotalError_Active = new NodeId(17761u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_TotalError_Classification = new NodeId(17762u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(17763u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_SubError = new NodeId(17766u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError = new NodeId(17768u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_Active = new NodeId(17769u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_Classification = new NodeId(17770u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(17771u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod = new NodeId(17773u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(17774u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(17775u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(17776u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent = new NodeId(17778u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(17779u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(17780u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(17781u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError = new NodeId(17783u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(17784u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(17785u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(17786u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent = new NodeId(17788u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(17789u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(17790u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(17791u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod = new NodeId(17793u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(17794u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(17795u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(17796u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages = new NodeId(17799u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Active = new NodeId(17800u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Classification = new NodeId(17801u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_DiagnosticsLevel = new NodeId(17802u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MessageSequenceNumber_DiagnosticsLevel = new NodeId(17805u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_StatusCode_DiagnosticsLevel = new NodeId(17807u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MajorVersion_DiagnosticsLevel = new NodeId(17809u);

	public static readonly NodeId WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_LiveValues_MinorVersion_DiagnosticsLevel = new NodeId(17811u);

	public static readonly NodeId WriterGroupType_Diagnostics_DiagnosticsLevel = new NodeId(17813u);

	public static readonly NodeId WriterGroupType_Diagnostics_TotalInformation = new NodeId(17814u);

	public static readonly NodeId WriterGroupType_Diagnostics_TotalInformation_Active = new NodeId(17815u);

	public static readonly NodeId WriterGroupType_Diagnostics_TotalInformation_Classification = new NodeId(17816u);

	public static readonly NodeId WriterGroupType_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(17817u);

	public static readonly NodeId WriterGroupType_Diagnostics_TotalError = new NodeId(17819u);

	public static readonly NodeId WriterGroupType_Diagnostics_TotalError_Active = new NodeId(17820u);

	public static readonly NodeId WriterGroupType_Diagnostics_TotalError_Classification = new NodeId(17821u);

	public static readonly NodeId WriterGroupType_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(17822u);

	public static readonly NodeId WriterGroupType_Diagnostics_SubError = new NodeId(17825u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateError = new NodeId(17827u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateError_Active = new NodeId(17828u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateError_Classification = new NodeId(17829u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(17830u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalByMethod = new NodeId(17832u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(17833u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(17834u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(17835u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalByParent = new NodeId(17837u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(17838u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(17839u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(17840u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalFromError = new NodeId(17842u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(17843u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(17844u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(17845u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StatePausedByParent = new NodeId(17847u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(17848u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(17849u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(17850u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateDisabledByMethod = new NodeId(17853u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(17854u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(17855u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(17856u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_SentNetworkMessages = new NodeId(17859u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_SentNetworkMessages_Active = new NodeId(17864u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_SentNetworkMessages_Classification = new NodeId(17871u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_SentNetworkMessages_DiagnosticsLevel = new NodeId(17872u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_FailedTransmissions = new NodeId(17874u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_FailedTransmissions_Active = new NodeId(17878u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_FailedTransmissions_Classification = new NodeId(17885u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_FailedTransmissions_DiagnosticsLevel = new NodeId(17892u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_EncryptionErrors = new NodeId(17900u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_EncryptionErrors_Active = new NodeId(17901u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_EncryptionErrors_Classification = new NodeId(17902u);

	public static readonly NodeId WriterGroupType_Diagnostics_Counters_EncryptionErrors_DiagnosticsLevel = new NodeId(17903u);

	public static readonly NodeId WriterGroupType_Diagnostics_LiveValues_ConfiguredDataSetWriters = new NodeId(17913u);

	public static readonly NodeId WriterGroupType_Diagnostics_LiveValues_ConfiguredDataSetWriters_DiagnosticsLevel = new NodeId(17920u);

	public static readonly NodeId WriterGroupType_Diagnostics_LiveValues_OperationalDataSetWriters = new NodeId(17927u);

	public static readonly NodeId WriterGroupType_Diagnostics_LiveValues_OperationalDataSetWriters_DiagnosticsLevel = new NodeId(17934u);

	public static readonly NodeId WriterGroupType_Diagnostics_LiveValues_SecurityTokenID_DiagnosticsLevel = new NodeId(17948u);

	public static readonly NodeId WriterGroupType_Diagnostics_LiveValues_TimeToNextTokenID_DiagnosticsLevel = new NodeId(17962u);

	public static readonly NodeId WriterGroupType_AddDataSetWriter_InputArguments = new NodeId(17976u);

	public static readonly NodeId WriterGroupType_AddDataSetWriter_OutputArguments = new NodeId(17987u);

	public static readonly NodeId WriterGroupType_RemoveDataSetWriter_InputArguments = new NodeId(17993u);

	public static readonly NodeId ReaderGroupType_Status_State = new NodeId(18068u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_PublisherId = new NodeId(18077u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_WriterGroupId = new NodeId(18078u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_DataSetWriterId = new NodeId(18079u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_DataSetMetaData = new NodeId(18080u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_DataSetFieldContentMask = new NodeId(18081u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_MessageReceiveTimeout = new NodeId(18082u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_KeyFrameCount = new NodeId(17560u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_HeaderLayoutUri = new NodeId(17562u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_DataSetReaderProperties = new NodeId(17492u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Status_State = new NodeId(18089u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_DiagnosticsLevel = new NodeId(18093u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_TotalInformation = new NodeId(18094u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_TotalInformation_Active = new NodeId(18095u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_TotalInformation_Classification = new NodeId(18096u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(18097u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_TotalError = new NodeId(18099u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_TotalError_Active = new NodeId(18100u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_TotalError_Classification = new NodeId(18101u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(18102u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_SubError = new NodeId(18105u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateError = new NodeId(18107u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateError_Active = new NodeId(18108u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateError_Classification = new NodeId(18109u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(18110u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalByMethod = new NodeId(18112u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(18113u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(18114u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(18115u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalByParent = new NodeId(18117u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(18118u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(18119u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(18120u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalFromError = new NodeId(18122u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(18123u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(18124u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(18125u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StatePausedByParent = new NodeId(18127u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(18128u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(18129u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(18130u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateDisabledByMethod = new NodeId(18132u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(18133u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(18134u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(18135u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_FailedDataSetMessages = new NodeId(18138u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Active = new NodeId(18139u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_Classification = new NodeId(18140u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_FailedDataSetMessages_DiagnosticsLevel = new NodeId(18141u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_DecryptionErrors_Active = new NodeId(18144u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_DecryptionErrors_Classification = new NodeId(18145u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Counters_DecryptionErrors_DiagnosticsLevel = new NodeId(18146u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_LiveValues_MessageSequenceNumber_DiagnosticsLevel = new NodeId(18149u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_LiveValues_StatusCode_DiagnosticsLevel = new NodeId(18151u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_LiveValues_MajorVersion_DiagnosticsLevel = new NodeId(18153u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_LiveValues_MinorVersion_DiagnosticsLevel = new NodeId(18158u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_LiveValues_SecurityTokenID_DiagnosticsLevel = new NodeId(21003u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_LiveValues_TimeToNextTokenID_DiagnosticsLevel = new NodeId(21005u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_CreateTargetVariables_InputArguments = new NodeId(21010u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_CreateTargetVariables_OutputArguments = new NodeId(21011u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_CreateDataSetMirror_InputArguments = new NodeId(21013u);

	public static readonly NodeId ReaderGroupType_DataSetReaderName_Placeholder_CreateDataSetMirror_OutputArguments = new NodeId(21014u);

	public static readonly NodeId ReaderGroupType_Diagnostics_DiagnosticsLevel = new NodeId(21016u);

	public static readonly NodeId ReaderGroupType_Diagnostics_TotalInformation = new NodeId(21017u);

	public static readonly NodeId ReaderGroupType_Diagnostics_TotalInformation_Active = new NodeId(21018u);

	public static readonly NodeId ReaderGroupType_Diagnostics_TotalInformation_Classification = new NodeId(21019u);

	public static readonly NodeId ReaderGroupType_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(21020u);

	public static readonly NodeId ReaderGroupType_Diagnostics_TotalError = new NodeId(21022u);

	public static readonly NodeId ReaderGroupType_Diagnostics_TotalError_Active = new NodeId(21023u);

	public static readonly NodeId ReaderGroupType_Diagnostics_TotalError_Classification = new NodeId(21024u);

	public static readonly NodeId ReaderGroupType_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(21025u);

	public static readonly NodeId ReaderGroupType_Diagnostics_SubError = new NodeId(21028u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateError = new NodeId(21030u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateError_Active = new NodeId(21031u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateError_Classification = new NodeId(21032u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(21033u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalByMethod = new NodeId(21035u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(21036u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(21037u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(21038u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalByParent = new NodeId(21040u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(21041u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(21042u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(21043u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalFromError = new NodeId(21045u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(21046u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(21047u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(21048u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StatePausedByParent = new NodeId(21050u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(21051u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(21052u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(21053u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateDisabledByMethod = new NodeId(21055u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(21056u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(21057u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(21058u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_ReceivedNetworkMessages = new NodeId(21061u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_ReceivedNetworkMessages_Active = new NodeId(21062u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_ReceivedNetworkMessages_Classification = new NodeId(21063u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_ReceivedNetworkMessages_DiagnosticsLevel = new NodeId(21064u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_ReceivedInvalidNetworkMessages_Active = new NodeId(21067u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_ReceivedInvalidNetworkMessages_Classification = new NodeId(21068u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_ReceivedInvalidNetworkMessages_DiagnosticsLevel = new NodeId(21069u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_DecryptionErrors_Active = new NodeId(21072u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_DecryptionErrors_Classification = new NodeId(21073u);

	public static readonly NodeId ReaderGroupType_Diagnostics_Counters_DecryptionErrors_DiagnosticsLevel = new NodeId(21074u);

	public static readonly NodeId ReaderGroupType_Diagnostics_LiveValues_ConfiguredDataSetReaders = new NodeId(21076u);

	public static readonly NodeId ReaderGroupType_Diagnostics_LiveValues_ConfiguredDataSetReaders_DiagnosticsLevel = new NodeId(21077u);

	public static readonly NodeId ReaderGroupType_Diagnostics_LiveValues_OperationalDataSetReaders = new NodeId(21078u);

	public static readonly NodeId ReaderGroupType_Diagnostics_LiveValues_OperationalDataSetReaders_DiagnosticsLevel = new NodeId(21079u);

	public static readonly NodeId ReaderGroupType_AddDataSetReader_InputArguments = new NodeId(21083u);

	public static readonly NodeId ReaderGroupType_AddDataSetReader_OutputArguments = new NodeId(21084u);

	public static readonly NodeId ReaderGroupType_RemoveDataSetReader_InputArguments = new NodeId(21086u);

	public static readonly NodeId DataSetWriterType_DataSetWriterId = new NodeId(21092u);

	public static readonly NodeId DataSetWriterType_DataSetFieldContentMask = new NodeId(21093u);

	public static readonly NodeId DataSetWriterType_KeyFrameCount = new NodeId(21094u);

	public static readonly NodeId DataSetWriterType_DataSetWriterProperties = new NodeId(17493u);

	public static readonly NodeId DataSetWriterType_Status_State = new NodeId(15300u);

	public static readonly NodeId DataSetWriterType_Diagnostics_DiagnosticsLevel = new NodeId(19551u);

	public static readonly NodeId DataSetWriterType_Diagnostics_TotalInformation = new NodeId(19552u);

	public static readonly NodeId DataSetWriterType_Diagnostics_TotalInformation_Active = new NodeId(19553u);

	public static readonly NodeId DataSetWriterType_Diagnostics_TotalInformation_Classification = new NodeId(19554u);

	public static readonly NodeId DataSetWriterType_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(19555u);

	public static readonly NodeId DataSetWriterType_Diagnostics_TotalError = new NodeId(19557u);

	public static readonly NodeId DataSetWriterType_Diagnostics_TotalError_Active = new NodeId(19558u);

	public static readonly NodeId DataSetWriterType_Diagnostics_TotalError_Classification = new NodeId(19559u);

	public static readonly NodeId DataSetWriterType_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(19560u);

	public static readonly NodeId DataSetWriterType_Diagnostics_SubError = new NodeId(19563u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateError = new NodeId(19565u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateError_Active = new NodeId(19566u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateError_Classification = new NodeId(19567u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(19568u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalByMethod = new NodeId(19570u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(19571u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(19572u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19573u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalByParent = new NodeId(19575u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(19576u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(19577u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19578u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalFromError = new NodeId(19580u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(19581u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(19582u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19583u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StatePausedByParent = new NodeId(19585u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(19586u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(19587u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19588u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateDisabledByMethod = new NodeId(19590u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(19591u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(19592u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19593u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_FailedDataSetMessages = new NodeId(19596u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_FailedDataSetMessages_Active = new NodeId(19597u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_FailedDataSetMessages_Classification = new NodeId(19598u);

	public static readonly NodeId DataSetWriterType_Diagnostics_Counters_FailedDataSetMessages_DiagnosticsLevel = new NodeId(19599u);

	public static readonly NodeId DataSetWriterType_Diagnostics_LiveValues_MessageSequenceNumber_DiagnosticsLevel = new NodeId(19602u);

	public static readonly NodeId DataSetWriterType_Diagnostics_LiveValues_StatusCode_DiagnosticsLevel = new NodeId(19604u);

	public static readonly NodeId DataSetWriterType_Diagnostics_LiveValues_MajorVersion_DiagnosticsLevel = new NodeId(19606u);

	public static readonly NodeId DataSetWriterType_Diagnostics_LiveValues_MinorVersion_DiagnosticsLevel = new NodeId(19608u);

	public static readonly NodeId DataSetReaderType_PublisherId = new NodeId(21097u);

	public static readonly NodeId DataSetReaderType_WriterGroupId = new NodeId(21098u);

	public static readonly NodeId DataSetReaderType_DataSetWriterId = new NodeId(21099u);

	public static readonly NodeId DataSetReaderType_DataSetMetaData = new NodeId(21100u);

	public static readonly NodeId DataSetReaderType_DataSetFieldContentMask = new NodeId(21101u);

	public static readonly NodeId DataSetReaderType_MessageReceiveTimeout = new NodeId(21102u);

	public static readonly NodeId DataSetReaderType_KeyFrameCount = new NodeId(17563u);

	public static readonly NodeId DataSetReaderType_HeaderLayoutUri = new NodeId(17564u);

	public static readonly NodeId DataSetReaderType_SecurityMode = new NodeId(15932u);

	public static readonly NodeId DataSetReaderType_SecurityGroupId = new NodeId(15933u);

	public static readonly NodeId DataSetReaderType_SecurityKeyServices = new NodeId(15934u);

	public static readonly NodeId DataSetReaderType_DataSetReaderProperties = new NodeId(17494u);

	public static readonly NodeId DataSetReaderType_Status_State = new NodeId(15308u);

	public static readonly NodeId DataSetReaderType_Diagnostics_DiagnosticsLevel = new NodeId(19610u);

	public static readonly NodeId DataSetReaderType_Diagnostics_TotalInformation = new NodeId(19611u);

	public static readonly NodeId DataSetReaderType_Diagnostics_TotalInformation_Active = new NodeId(19612u);

	public static readonly NodeId DataSetReaderType_Diagnostics_TotalInformation_Classification = new NodeId(19613u);

	public static readonly NodeId DataSetReaderType_Diagnostics_TotalInformation_DiagnosticsLevel = new NodeId(19614u);

	public static readonly NodeId DataSetReaderType_Diagnostics_TotalError = new NodeId(19616u);

	public static readonly NodeId DataSetReaderType_Diagnostics_TotalError_Active = new NodeId(19617u);

	public static readonly NodeId DataSetReaderType_Diagnostics_TotalError_Classification = new NodeId(19618u);

	public static readonly NodeId DataSetReaderType_Diagnostics_TotalError_DiagnosticsLevel = new NodeId(19619u);

	public static readonly NodeId DataSetReaderType_Diagnostics_SubError = new NodeId(19622u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateError = new NodeId(19624u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateError_Active = new NodeId(19625u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateError_Classification = new NodeId(19626u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateError_DiagnosticsLevel = new NodeId(19627u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalByMethod = new NodeId(19629u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalByMethod_Active = new NodeId(19630u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalByMethod_Classification = new NodeId(19631u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19632u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalByParent = new NodeId(19634u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalByParent_Active = new NodeId(19635u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalByParent_Classification = new NodeId(19636u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19637u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalFromError = new NodeId(19639u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalFromError_Active = new NodeId(19640u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalFromError_Classification = new NodeId(19641u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19642u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StatePausedByParent = new NodeId(19644u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StatePausedByParent_Active = new NodeId(19645u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StatePausedByParent_Classification = new NodeId(19646u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19647u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateDisabledByMethod = new NodeId(19649u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateDisabledByMethod_Active = new NodeId(19650u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateDisabledByMethod_Classification = new NodeId(19651u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19652u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_FailedDataSetMessages = new NodeId(19655u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_FailedDataSetMessages_Active = new NodeId(19656u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_FailedDataSetMessages_Classification = new NodeId(19657u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_FailedDataSetMessages_DiagnosticsLevel = new NodeId(19658u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_DecryptionErrors_Active = new NodeId(19661u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_DecryptionErrors_Classification = new NodeId(19662u);

	public static readonly NodeId DataSetReaderType_Diagnostics_Counters_DecryptionErrors_DiagnosticsLevel = new NodeId(19663u);

	public static readonly NodeId DataSetReaderType_Diagnostics_LiveValues_MessageSequenceNumber_DiagnosticsLevel = new NodeId(19666u);

	public static readonly NodeId DataSetReaderType_Diagnostics_LiveValues_StatusCode_DiagnosticsLevel = new NodeId(19668u);

	public static readonly NodeId DataSetReaderType_Diagnostics_LiveValues_MajorVersion_DiagnosticsLevel = new NodeId(19670u);

	public static readonly NodeId DataSetReaderType_Diagnostics_LiveValues_MinorVersion_DiagnosticsLevel = new NodeId(19672u);

	public static readonly NodeId DataSetReaderType_Diagnostics_LiveValues_SecurityTokenID_DiagnosticsLevel = new NodeId(19674u);

	public static readonly NodeId DataSetReaderType_Diagnostics_LiveValues_TimeToNextTokenID_DiagnosticsLevel = new NodeId(19676u);

	public static readonly NodeId DataSetReaderType_CreateTargetVariables_InputArguments = new NodeId(17387u);

	public static readonly NodeId DataSetReaderType_CreateTargetVariables_OutputArguments = new NodeId(17388u);

	public static readonly NodeId DataSetReaderType_CreateDataSetMirror_InputArguments = new NodeId(17390u);

	public static readonly NodeId DataSetReaderType_CreateDataSetMirror_OutputArguments = new NodeId(17391u);

	public static readonly NodeId TargetVariablesType_TargetVariables = new NodeId(15114u);

	public static readonly NodeId TargetVariablesType_AddTargetVariables_InputArguments = new NodeId(15116u);

	public static readonly NodeId TargetVariablesType_AddTargetVariables_OutputArguments = new NodeId(15117u);

	public static readonly NodeId TargetVariablesType_RemoveTargetVariables_InputArguments = new NodeId(15119u);

	public static readonly NodeId TargetVariablesType_RemoveTargetVariables_OutputArguments = new NodeId(15120u);

	public static readonly NodeId PubSubStatusType_State = new NodeId(14644u);

	public static readonly NodeId PubSubDiagnosticsType_DiagnosticsLevel = new NodeId(19678u);

	public static readonly NodeId PubSubDiagnosticsType_TotalInformation = new NodeId(19679u);

	public static readonly NodeId PubSubDiagnosticsType_TotalInformation_Active = new NodeId(19680u);

	public static readonly NodeId PubSubDiagnosticsType_TotalInformation_Classification = new NodeId(19681u);

	public static readonly NodeId PubSubDiagnosticsType_TotalInformation_DiagnosticsLevel = new NodeId(19682u);

	public static readonly NodeId PubSubDiagnosticsType_TotalError = new NodeId(19684u);

	public static readonly NodeId PubSubDiagnosticsType_TotalError_Active = new NodeId(19685u);

	public static readonly NodeId PubSubDiagnosticsType_TotalError_Classification = new NodeId(19686u);

	public static readonly NodeId PubSubDiagnosticsType_TotalError_DiagnosticsLevel = new NodeId(19687u);

	public static readonly NodeId PubSubDiagnosticsType_SubError = new NodeId(19690u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateError = new NodeId(19692u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateError_Active = new NodeId(19693u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateError_Classification = new NodeId(19694u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateError_DiagnosticsLevel = new NodeId(19695u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalByMethod = new NodeId(19697u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalByMethod_Active = new NodeId(19698u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalByMethod_Classification = new NodeId(19699u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19700u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalByParent = new NodeId(19702u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalByParent_Active = new NodeId(19703u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalByParent_Classification = new NodeId(19704u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19705u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalFromError = new NodeId(19707u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalFromError_Active = new NodeId(19708u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalFromError_Classification = new NodeId(19709u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19710u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StatePausedByParent = new NodeId(19712u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StatePausedByParent_Active = new NodeId(19713u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StatePausedByParent_Classification = new NodeId(19714u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19715u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateDisabledByMethod = new NodeId(19717u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateDisabledByMethod_Active = new NodeId(19718u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateDisabledByMethod_Classification = new NodeId(19719u);

	public static readonly NodeId PubSubDiagnosticsType_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19720u);

	public static readonly NodeId DiagnosticsLevel_EnumStrings = new NodeId(19724u);

	public static readonly NodeId PubSubDiagnosticsCounterType_Active = new NodeId(19726u);

	public static readonly NodeId PubSubDiagnosticsCounterType_Classification = new NodeId(19727u);

	public static readonly NodeId PubSubDiagnosticsCounterType_DiagnosticsLevel = new NodeId(19728u);

	public static readonly NodeId PubSubDiagnosticsCounterType_TimeFirstChange = new NodeId(19729u);

	public static readonly NodeId PubSubDiagnosticsCounterClassification_EnumStrings = new NodeId(19731u);

	public static readonly NodeId PubSubDiagnosticsRootType_TotalInformation_Active = new NodeId(19735u);

	public static readonly NodeId PubSubDiagnosticsRootType_TotalInformation_Classification = new NodeId(19736u);

	public static readonly NodeId PubSubDiagnosticsRootType_TotalInformation_DiagnosticsLevel = new NodeId(19737u);

	public static readonly NodeId PubSubDiagnosticsRootType_TotalError_Active = new NodeId(19740u);

	public static readonly NodeId PubSubDiagnosticsRootType_TotalError_Classification = new NodeId(19741u);

	public static readonly NodeId PubSubDiagnosticsRootType_TotalError_DiagnosticsLevel = new NodeId(19742u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateError = new NodeId(19747u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateError_Active = new NodeId(19748u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateError_Classification = new NodeId(19749u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateError_DiagnosticsLevel = new NodeId(19750u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalByMethod = new NodeId(19752u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalByMethod_Active = new NodeId(19753u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalByMethod_Classification = new NodeId(19754u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19755u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalByParent = new NodeId(19757u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalByParent_Active = new NodeId(19758u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalByParent_Classification = new NodeId(19759u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19760u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalFromError = new NodeId(19762u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalFromError_Active = new NodeId(19763u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalFromError_Classification = new NodeId(19764u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19765u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StatePausedByParent = new NodeId(19767u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StatePausedByParent_Active = new NodeId(19768u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StatePausedByParent_Classification = new NodeId(19769u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19770u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateDisabledByMethod = new NodeId(19772u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateDisabledByMethod_Active = new NodeId(19773u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateDisabledByMethod_Classification = new NodeId(19774u);

	public static readonly NodeId PubSubDiagnosticsRootType_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19775u);

	public static readonly NodeId PubSubDiagnosticsRootType_LiveValues_ConfiguredDataSetWriters = new NodeId(19778u);

	public static readonly NodeId PubSubDiagnosticsRootType_LiveValues_ConfiguredDataSetWriters_DiagnosticsLevel = new NodeId(19779u);

	public static readonly NodeId PubSubDiagnosticsRootType_LiveValues_ConfiguredDataSetReaders = new NodeId(19780u);

	public static readonly NodeId PubSubDiagnosticsRootType_LiveValues_ConfiguredDataSetReaders_DiagnosticsLevel = new NodeId(19781u);

	public static readonly NodeId PubSubDiagnosticsRootType_LiveValues_OperationalDataSetWriters = new NodeId(19782u);

	public static readonly NodeId PubSubDiagnosticsRootType_LiveValues_OperationalDataSetWriters_DiagnosticsLevel = new NodeId(19783u);

	public static readonly NodeId PubSubDiagnosticsRootType_LiveValues_OperationalDataSetReaders = new NodeId(19784u);

	public static readonly NodeId PubSubDiagnosticsRootType_LiveValues_OperationalDataSetReaders_DiagnosticsLevel = new NodeId(19785u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_TotalInformation_Active = new NodeId(19789u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_TotalInformation_Classification = new NodeId(19790u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_TotalInformation_DiagnosticsLevel = new NodeId(19791u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_TotalError_Active = new NodeId(19794u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_TotalError_Classification = new NodeId(19795u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_TotalError_DiagnosticsLevel = new NodeId(19796u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateError = new NodeId(19801u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateError_Active = new NodeId(19802u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateError_Classification = new NodeId(19803u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateError_DiagnosticsLevel = new NodeId(19804u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalByMethod = new NodeId(19806u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalByMethod_Active = new NodeId(19807u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalByMethod_Classification = new NodeId(19808u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19809u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalByParent = new NodeId(19811u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalByParent_Active = new NodeId(19812u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalByParent_Classification = new NodeId(19813u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19814u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalFromError = new NodeId(19816u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalFromError_Active = new NodeId(19817u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalFromError_Classification = new NodeId(19818u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19819u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StatePausedByParent = new NodeId(19821u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StatePausedByParent_Active = new NodeId(19822u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StatePausedByParent_Classification = new NodeId(19823u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19824u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateDisabledByMethod = new NodeId(19826u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateDisabledByMethod_Active = new NodeId(19827u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateDisabledByMethod_Classification = new NodeId(19828u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19829u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_LiveValues_ResolvedAddress = new NodeId(19832u);

	public static readonly NodeId PubSubDiagnosticsConnectionType_LiveValues_ResolvedAddress_DiagnosticsLevel = new NodeId(19833u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_TotalInformation_Active = new NodeId(19837u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_TotalInformation_Classification = new NodeId(19838u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_TotalInformation_DiagnosticsLevel = new NodeId(19839u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_TotalError_Active = new NodeId(19842u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_TotalError_Classification = new NodeId(19843u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_TotalError_DiagnosticsLevel = new NodeId(19844u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateError = new NodeId(19849u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateError_Active = new NodeId(19850u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateError_Classification = new NodeId(19851u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateError_DiagnosticsLevel = new NodeId(19852u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalByMethod = new NodeId(19854u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalByMethod_Active = new NodeId(19855u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalByMethod_Classification = new NodeId(19856u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19857u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalByParent = new NodeId(19859u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalByParent_Active = new NodeId(19860u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalByParent_Classification = new NodeId(19861u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19862u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalFromError = new NodeId(19864u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalFromError_Active = new NodeId(19865u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalFromError_Classification = new NodeId(19866u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19867u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StatePausedByParent = new NodeId(19869u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StatePausedByParent_Active = new NodeId(19870u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StatePausedByParent_Classification = new NodeId(19871u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19872u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateDisabledByMethod = new NodeId(19874u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateDisabledByMethod_Active = new NodeId(19875u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateDisabledByMethod_Classification = new NodeId(19876u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19877u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_SentNetworkMessages = new NodeId(19880u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_SentNetworkMessages_Active = new NodeId(19881u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_SentNetworkMessages_Classification = new NodeId(19882u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_SentNetworkMessages_DiagnosticsLevel = new NodeId(19883u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_FailedTransmissions = new NodeId(19885u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_FailedTransmissions_Active = new NodeId(19886u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_FailedTransmissions_Classification = new NodeId(19887u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_FailedTransmissions_DiagnosticsLevel = new NodeId(19888u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_EncryptionErrors = new NodeId(19890u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_EncryptionErrors_Active = new NodeId(19891u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_EncryptionErrors_Classification = new NodeId(19892u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_Counters_EncryptionErrors_DiagnosticsLevel = new NodeId(19893u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_LiveValues_ConfiguredDataSetWriters = new NodeId(19895u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_LiveValues_ConfiguredDataSetWriters_DiagnosticsLevel = new NodeId(19896u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_LiveValues_OperationalDataSetWriters = new NodeId(19897u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_LiveValues_OperationalDataSetWriters_DiagnosticsLevel = new NodeId(19898u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_LiveValues_SecurityTokenID = new NodeId(19899u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_LiveValues_SecurityTokenID_DiagnosticsLevel = new NodeId(19900u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_LiveValues_TimeToNextTokenID = new NodeId(19901u);

	public static readonly NodeId PubSubDiagnosticsWriterGroupType_LiveValues_TimeToNextTokenID_DiagnosticsLevel = new NodeId(19902u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_TotalInformation_Active = new NodeId(19906u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_TotalInformation_Classification = new NodeId(19907u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_TotalInformation_DiagnosticsLevel = new NodeId(19908u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_TotalError_Active = new NodeId(19911u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_TotalError_Classification = new NodeId(19912u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_TotalError_DiagnosticsLevel = new NodeId(19913u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateError = new NodeId(19918u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateError_Active = new NodeId(19919u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateError_Classification = new NodeId(19920u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateError_DiagnosticsLevel = new NodeId(19921u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalByMethod = new NodeId(19923u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalByMethod_Active = new NodeId(19924u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalByMethod_Classification = new NodeId(19925u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19926u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalByParent = new NodeId(19928u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalByParent_Active = new NodeId(19929u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalByParent_Classification = new NodeId(19930u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19931u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalFromError = new NodeId(19933u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalFromError_Active = new NodeId(19934u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalFromError_Classification = new NodeId(19935u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(19936u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StatePausedByParent = new NodeId(19938u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StatePausedByParent_Active = new NodeId(19939u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StatePausedByParent_Classification = new NodeId(19940u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(19941u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateDisabledByMethod = new NodeId(19943u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateDisabledByMethod_Active = new NodeId(19944u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateDisabledByMethod_Classification = new NodeId(19945u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(19946u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_ReceivedNetworkMessages = new NodeId(19949u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_ReceivedNetworkMessages_Active = new NodeId(19950u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_ReceivedNetworkMessages_Classification = new NodeId(19951u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_ReceivedNetworkMessages_DiagnosticsLevel = new NodeId(19952u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_ReceivedInvalidNetworkMessages = new NodeId(19954u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_ReceivedInvalidNetworkMessages_Active = new NodeId(19955u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_ReceivedInvalidNetworkMessages_Classification = new NodeId(19956u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_ReceivedInvalidNetworkMessages_DiagnosticsLevel = new NodeId(19957u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_DecryptionErrors = new NodeId(19959u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_DecryptionErrors_Active = new NodeId(19960u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_DecryptionErrors_Classification = new NodeId(19961u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_Counters_DecryptionErrors_DiagnosticsLevel = new NodeId(19962u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_LiveValues_ConfiguredDataSetReaders = new NodeId(19964u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_LiveValues_ConfiguredDataSetReaders_DiagnosticsLevel = new NodeId(19965u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_LiveValues_OperationalDataSetReaders = new NodeId(19966u);

	public static readonly NodeId PubSubDiagnosticsReaderGroupType_LiveValues_OperationalDataSetReaders_DiagnosticsLevel = new NodeId(19967u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_TotalInformation_Active = new NodeId(19971u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_TotalInformation_Classification = new NodeId(19972u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_TotalInformation_DiagnosticsLevel = new NodeId(19973u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_TotalError_Active = new NodeId(19976u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_TotalError_Classification = new NodeId(19977u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_TotalError_DiagnosticsLevel = new NodeId(19978u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateError = new NodeId(19983u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateError_Active = new NodeId(19984u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateError_Classification = new NodeId(19985u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateError_DiagnosticsLevel = new NodeId(19986u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalByMethod = new NodeId(19988u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalByMethod_Active = new NodeId(19989u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalByMethod_Classification = new NodeId(19990u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(19991u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalByParent = new NodeId(19993u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalByParent_Active = new NodeId(19994u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalByParent_Classification = new NodeId(19995u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(19996u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalFromError = new NodeId(19998u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalFromError_Active = new NodeId(19999u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalFromError_Classification = new NodeId(20000u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(20001u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StatePausedByParent = new NodeId(20003u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StatePausedByParent_Active = new NodeId(20004u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StatePausedByParent_Classification = new NodeId(20005u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(20006u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateDisabledByMethod = new NodeId(20008u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateDisabledByMethod_Active = new NodeId(20009u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateDisabledByMethod_Classification = new NodeId(20010u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(20011u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_FailedDataSetMessages = new NodeId(20014u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_FailedDataSetMessages_Active = new NodeId(20015u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_FailedDataSetMessages_Classification = new NodeId(20016u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_Counters_FailedDataSetMessages_DiagnosticsLevel = new NodeId(20017u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_LiveValues_MessageSequenceNumber = new NodeId(20019u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_LiveValues_MessageSequenceNumber_DiagnosticsLevel = new NodeId(20020u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_LiveValues_StatusCode = new NodeId(20021u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_LiveValues_StatusCode_DiagnosticsLevel = new NodeId(20022u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_LiveValues_MajorVersion = new NodeId(20023u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_LiveValues_MajorVersion_DiagnosticsLevel = new NodeId(20024u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_LiveValues_MinorVersion = new NodeId(20025u);

	public static readonly NodeId PubSubDiagnosticsDataSetWriterType_LiveValues_MinorVersion_DiagnosticsLevel = new NodeId(20026u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_TotalInformation_Active = new NodeId(20030u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_TotalInformation_Classification = new NodeId(20031u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_TotalInformation_DiagnosticsLevel = new NodeId(20032u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_TotalError_Active = new NodeId(20035u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_TotalError_Classification = new NodeId(20036u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_TotalError_DiagnosticsLevel = new NodeId(20037u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateError = new NodeId(20042u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateError_Active = new NodeId(20043u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateError_Classification = new NodeId(20044u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateError_DiagnosticsLevel = new NodeId(20045u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalByMethod = new NodeId(20047u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalByMethod_Active = new NodeId(20048u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalByMethod_Classification = new NodeId(20049u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalByMethod_DiagnosticsLevel = new NodeId(20050u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalByParent = new NodeId(20052u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalByParent_Active = new NodeId(20053u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalByParent_Classification = new NodeId(20054u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalByParent_DiagnosticsLevel = new NodeId(20055u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalFromError = new NodeId(20057u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalFromError_Active = new NodeId(20058u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalFromError_Classification = new NodeId(20059u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateOperationalFromError_DiagnosticsLevel = new NodeId(20060u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StatePausedByParent = new NodeId(20062u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StatePausedByParent_Active = new NodeId(20063u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StatePausedByParent_Classification = new NodeId(20064u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StatePausedByParent_DiagnosticsLevel = new NodeId(20065u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateDisabledByMethod = new NodeId(20067u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateDisabledByMethod_Active = new NodeId(20068u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateDisabledByMethod_Classification = new NodeId(20069u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_StateDisabledByMethod_DiagnosticsLevel = new NodeId(20070u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_FailedDataSetMessages = new NodeId(20073u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_FailedDataSetMessages_Active = new NodeId(20074u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_FailedDataSetMessages_Classification = new NodeId(20075u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_FailedDataSetMessages_DiagnosticsLevel = new NodeId(20076u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_DecryptionErrors = new NodeId(20078u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_DecryptionErrors_Active = new NodeId(20079u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_DecryptionErrors_Classification = new NodeId(20080u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_Counters_DecryptionErrors_DiagnosticsLevel = new NodeId(20081u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_MessageSequenceNumber = new NodeId(20083u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_MessageSequenceNumber_DiagnosticsLevel = new NodeId(20084u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_StatusCode = new NodeId(20085u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_StatusCode_DiagnosticsLevel = new NodeId(20086u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_MajorVersion = new NodeId(20087u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_MajorVersion_DiagnosticsLevel = new NodeId(20088u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_MinorVersion = new NodeId(20089u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_MinorVersion_DiagnosticsLevel = new NodeId(20090u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_SecurityTokenID = new NodeId(20091u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_SecurityTokenID_DiagnosticsLevel = new NodeId(20092u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_TimeToNextTokenID = new NodeId(20093u);

	public static readonly NodeId PubSubDiagnosticsDataSetReaderType_LiveValues_TimeToNextTokenID_DiagnosticsLevel = new NodeId(20094u);

	public static readonly NodeId PubSubStatusEventType_ConnectionId = new NodeId(15545u);

	public static readonly NodeId PubSubStatusEventType_GroupId = new NodeId(15546u);

	public static readonly NodeId PubSubStatusEventType_State = new NodeId(15547u);

	public static readonly NodeId PubSubTransportLimitsExceedEventType_Actual = new NodeId(15561u);

	public static readonly NodeId PubSubTransportLimitsExceedEventType_Maximum = new NodeId(15562u);

	public static readonly NodeId PubSubCommunicationFailureEventType_Error = new NodeId(15576u);

	public static readonly NodeId UadpWriterGroupMessageType_GroupVersion = new NodeId(21106u);

	public static readonly NodeId UadpWriterGroupMessageType_DataSetOrdering = new NodeId(21107u);

	public static readonly NodeId UadpWriterGroupMessageType_NetworkMessageContentMask = new NodeId(21108u);

	public static readonly NodeId UadpWriterGroupMessageType_SamplingOffset = new NodeId(21109u);

	public static readonly NodeId UadpWriterGroupMessageType_PublishingOffset = new NodeId(21110u);

	public static readonly NodeId UadpDataSetWriterMessageType_DataSetMessageContentMask = new NodeId(21112u);

	public static readonly NodeId UadpDataSetWriterMessageType_ConfiguredSize = new NodeId(21113u);

	public static readonly NodeId UadpDataSetWriterMessageType_NetworkMessageNumber = new NodeId(21114u);

	public static readonly NodeId UadpDataSetWriterMessageType_DataSetOffset = new NodeId(21115u);

	public static readonly NodeId UadpDataSetReaderMessageType_GroupVersion = new NodeId(21117u);

	public static readonly NodeId UadpDataSetReaderMessageType_NetworkMessageNumber = new NodeId(21119u);

	public static readonly NodeId UadpDataSetReaderMessageType_DataSetOffset = new NodeId(17477u);

	public static readonly NodeId UadpDataSetReaderMessageType_DataSetClassId = new NodeId(21120u);

	public static readonly NodeId UadpDataSetReaderMessageType_NetworkMessageContentMask = new NodeId(21121u);

	public static readonly NodeId UadpDataSetReaderMessageType_DataSetMessageContentMask = new NodeId(21122u);

	public static readonly NodeId UadpDataSetReaderMessageType_PublishingInterval = new NodeId(21123u);

	public static readonly NodeId UadpDataSetReaderMessageType_ProcessingOffset = new NodeId(21124u);

	public static readonly NodeId UadpDataSetReaderMessageType_ReceiveOffset = new NodeId(21125u);

	public static readonly NodeId JsonWriterGroupMessageType_NetworkMessageContentMask = new NodeId(21127u);

	public static readonly NodeId JsonDataSetWriterMessageType_DataSetMessageContentMask = new NodeId(21129u);

	public static readonly NodeId JsonDataSetReaderMessageType_NetworkMessageContentMask = new NodeId(21131u);

	public static readonly NodeId JsonDataSetReaderMessageType_DataSetMessageContentMask = new NodeId(21132u);

	public static readonly NodeId DatagramConnectionTransportType_DiscoveryAddress_NetworkInterface = new NodeId(15154u);

	public static readonly NodeId DatagramConnectionTransportType_DiscoveryAddress_NetworkInterface_Selections = new NodeId(17579u);

	public static readonly NodeId DatagramWriterGroupTransportType_MessageRepeatCount = new NodeId(21134u);

	public static readonly NodeId DatagramWriterGroupTransportType_MessageRepeatDelay = new NodeId(21135u);

	public static readonly NodeId BrokerConnectionTransportType_ResourceUri = new NodeId(15156u);

	public static readonly NodeId BrokerConnectionTransportType_AuthenticationProfileUri = new NodeId(15178u);

	public static readonly NodeId BrokerWriterGroupTransportType_QueueName = new NodeId(21137u);

	public static readonly NodeId BrokerWriterGroupTransportType_ResourceUri = new NodeId(15246u);

	public static readonly NodeId BrokerWriterGroupTransportType_AuthenticationProfileUri = new NodeId(15247u);

	public static readonly NodeId BrokerWriterGroupTransportType_RequestedDeliveryGuarantee = new NodeId(15249u);

	public static readonly NodeId BrokerDataSetWriterTransportType_QueueName = new NodeId(21139u);

	public static readonly NodeId BrokerDataSetWriterTransportType_MetaDataQueueName = new NodeId(21140u);

	public static readonly NodeId BrokerDataSetWriterTransportType_ResourceUri = new NodeId(15250u);

	public static readonly NodeId BrokerDataSetWriterTransportType_AuthenticationProfileUri = new NodeId(15251u);

	public static readonly NodeId BrokerDataSetWriterTransportType_RequestedDeliveryGuarantee = new NodeId(15330u);

	public static readonly NodeId BrokerDataSetWriterTransportType_MetaDataUpdateTime = new NodeId(21141u);

	public static readonly NodeId BrokerDataSetReaderTransportType_QueueName = new NodeId(21143u);

	public static readonly NodeId BrokerDataSetReaderTransportType_ResourceUri = new NodeId(15334u);

	public static readonly NodeId BrokerDataSetReaderTransportType_AuthenticationProfileUri = new NodeId(15419u);

	public static readonly NodeId BrokerDataSetReaderTransportType_RequestedDeliveryGuarantee = new NodeId(15420u);

	public static readonly NodeId BrokerDataSetReaderTransportType_MetaDataQueueName = new NodeId(21144u);

	public static readonly NodeId NetworkAddressType_NetworkInterface = new NodeId(21146u);

	public static readonly NodeId NetworkAddressType_NetworkInterface_Selections = new NodeId(17582u);

	public static readonly NodeId NetworkAddressUrlType_NetworkInterface_Selections = new NodeId(17585u);

	public static readonly NodeId NetworkAddressUrlType_Url = new NodeId(21149u);

	public static readonly NodeId AliasNameCategoryType_SubAliasNameCategories_Placeholder_FindAlias_InputArguments = new NodeId(23460u);

	public static readonly NodeId AliasNameCategoryType_SubAliasNameCategories_Placeholder_FindAlias_OutputArguments = new NodeId(23461u);

	public static readonly NodeId AliasNameCategoryType_FindAlias_InputArguments = new NodeId(23463u);

	public static readonly NodeId AliasNameCategoryType_FindAlias_OutputArguments = new NodeId(23464u);

	public static readonly NodeId Aliases_SubAliasNameCategories_Placeholder_FindAlias_InputArguments = new NodeId(23474u);

	public static readonly NodeId Aliases_SubAliasNameCategories_Placeholder_FindAlias_OutputArguments = new NodeId(23475u);

	public static readonly NodeId Aliases_FindAlias_InputArguments = new NodeId(23477u);

	public static readonly NodeId Aliases_FindAlias_OutputArguments = new NodeId(23478u);

	public static readonly NodeId TagVariables_SubAliasNameCategories_Placeholder_FindAlias_InputArguments = new NodeId(23483u);

	public static readonly NodeId TagVariables_SubAliasNameCategories_Placeholder_FindAlias_OutputArguments = new NodeId(23484u);

	public static readonly NodeId TagVariables_FindAlias_InputArguments = new NodeId(23486u);

	public static readonly NodeId TagVariables_FindAlias_OutputArguments = new NodeId(23487u);

	public static readonly NodeId Topics_SubAliasNameCategories_Placeholder_FindAlias_InputArguments = new NodeId(23492u);

	public static readonly NodeId Topics_SubAliasNameCategories_Placeholder_FindAlias_OutputArguments = new NodeId(23493u);

	public static readonly NodeId Topics_FindAlias_InputArguments = new NodeId(23495u);

	public static readonly NodeId Topics_FindAlias_OutputArguments = new NodeId(23496u);

	public static readonly NodeId MultiStateDictionaryEntryDiscreteBaseType_EnumDictionaryEntries = new NodeId(19082u);

	public static readonly NodeId MultiStateDictionaryEntryDiscreteBaseType_ValueAsDictionaryEntries = new NodeId(19083u);

	public static readonly NodeId MultiStateDictionaryEntryDiscreteType_ValueAsDictionaryEntries = new NodeId(19090u);

	public static readonly NodeId IIetfBaseNetworkInterfaceType_AdminStatus = new NodeId(24149u);

	public static readonly NodeId IIetfBaseNetworkInterfaceType_OperStatus = new NodeId(24150u);

	public static readonly NodeId IIetfBaseNetworkInterfaceType_PhysAddress = new NodeId(24151u);

	public static readonly NodeId IIetfBaseNetworkInterfaceType_Speed = new NodeId(24152u);

	public static readonly NodeId IIetfBaseNetworkInterfaceType_Speed_EngineeringUnits = new NodeId(24157u);

	public static readonly NodeId IIeeeBaseEthernetPortType_Speed = new NodeId(24159u);

	public static readonly NodeId IIeeeBaseEthernetPortType_Speed_EngineeringUnits = new NodeId(24164u);

	public static readonly NodeId IIeeeBaseEthernetPortType_Duplex = new NodeId(24165u);

	public static readonly NodeId IIeeeBaseEthernetPortType_MaxFrameLength = new NodeId(24166u);

	public static readonly NodeId IIeeeAutoNegotiationStatusType_NegotiationStatus = new NodeId(24234u);

	public static readonly NodeId IBaseEthernetCapabilitiesType_VlanTagCapable = new NodeId(24168u);

	public static readonly NodeId ISrClassType_Id = new NodeId(24170u);

	public static readonly NodeId ISrClassType_Priority = new NodeId(24171u);

	public static readonly NodeId ISrClassType_Vid = new NodeId(24172u);

	public static readonly NodeId IIeeeBaseTsnStreamType_StreamId = new NodeId(24174u);

	public static readonly NodeId IIeeeBaseTsnStreamType_StreamName = new NodeId(24175u);

	public static readonly NodeId IIeeeBaseTsnStreamType_State = new NodeId(24176u);

	public static readonly NodeId IIeeeBaseTsnStreamType_AccumulatedLatency = new NodeId(24177u);

	public static readonly NodeId IIeeeBaseTsnStreamType_SrClassId = new NodeId(24178u);

	public static readonly NodeId IIeeeBaseTsnTrafficSpecificationType_MaxIntervalFrames = new NodeId(24180u);

	public static readonly NodeId IIeeeBaseTsnTrafficSpecificationType_MaxFrameSize = new NodeId(24181u);

	public static readonly NodeId IIeeeBaseTsnTrafficSpecificationType_Interval = new NodeId(24182u);

	public static readonly NodeId IIeeeBaseTsnStatusStreamType_TalkerStatus = new NodeId(24184u);

	public static readonly NodeId IIeeeBaseTsnStatusStreamType_ListenerStatus = new NodeId(24185u);

	public static readonly NodeId IIeeeBaseTsnStatusStreamType_FailureCode = new NodeId(24186u);

	public static readonly NodeId IIeeeBaseTsnStatusStreamType_FailureSystemIdentifier = new NodeId(24187u);

	public static readonly NodeId IIeeeTsnInterfaceConfigurationType_MacAddress = new NodeId(24189u);

	public static readonly NodeId IIeeeTsnInterfaceConfigurationType_InterfaceName = new NodeId(24190u);

	public static readonly NodeId IIeeeTsnInterfaceConfigurationTalkerType_TimeAwareOffset = new NodeId(24194u);

	public static readonly NodeId IIeeeTsnInterfaceConfigurationListenerType_ReceiveOffset = new NodeId(24198u);

	public static readonly NodeId IIeeeTsnMacAddressType_DestinationAddress = new NodeId(24200u);

	public static readonly NodeId IIeeeTsnMacAddressType_SourceAddress = new NodeId(24201u);

	public static readonly NodeId IIeeeTsnVlanTagType_VlanId = new NodeId(24203u);

	public static readonly NodeId IIeeeTsnVlanTagType_PriorityCodePoint = new NodeId(24204u);

	public static readonly NodeId IPriorityMappingEntryType_MappingUri = new NodeId(24206u);

	public static readonly NodeId IPriorityMappingEntryType_PriorityLabel = new NodeId(24207u);

	public static readonly NodeId IPriorityMappingEntryType_PriorityValue_PCP = new NodeId(24208u);

	public static readonly NodeId IPriorityMappingEntryType_PriorityValue_DSCP = new NodeId(24209u);

	public static readonly NodeId Duplex_EnumValues = new NodeId(24235u);

	public static readonly NodeId InterfaceAdminStatus_EnumValues = new NodeId(24236u);

	public static readonly NodeId InterfaceOperStatus_EnumValues = new NodeId(24237u);

	public static readonly NodeId NegotiationStatus_EnumValues = new NodeId(24238u);

	public static readonly NodeId TsnFailureCode_EnumValues = new NodeId(24239u);

	public static readonly NodeId TsnStreamState_EnumValues = new NodeId(24240u);

	public static readonly NodeId TsnTalkerStatus_EnumValues = new NodeId(24241u);

	public static readonly NodeId TsnListenerStatus_EnumValues = new NodeId(24242u);

	public static readonly NodeId IdType_EnumStrings = new NodeId(7591u);

	public static readonly NodeId NodeClass_EnumValues = new NodeId(11878u);

	public static readonly NodeId PermissionType_OptionSetValues = new NodeId(15030u);

	public static readonly NodeId AccessLevelType_OptionSetValues = new NodeId(15032u);

	public static readonly NodeId AccessLevelExType_OptionSetValues = new NodeId(15407u);

	public static readonly NodeId EventNotifierType_OptionSetValues = new NodeId(15034u);

	public static readonly NodeId AccessRestrictionType_OptionSetValues = new NodeId(15035u);

	public static readonly NodeId StructureType_EnumStrings = new NodeId(14528u);

	public static readonly NodeId ApplicationType_EnumStrings = new NodeId(7597u);

	public static readonly NodeId MessageSecurityMode_EnumStrings = new NodeId(7595u);

	public static readonly NodeId UserTokenType_EnumStrings = new NodeId(7596u);

	public static readonly NodeId SecurityTokenRequestType_EnumStrings = new NodeId(7598u);

	public static readonly NodeId NodeAttributesMask_EnumValues = new NodeId(11881u);

	public static readonly NodeId AttributeWriteMask_OptionSetValues = new NodeId(15036u);

	public static readonly NodeId BrowseDirection_EnumStrings = new NodeId(7603u);

	public static readonly NodeId BrowseResultMask_EnumValues = new NodeId(11883u);

	public static readonly NodeId FilterOperator_EnumStrings = new NodeId(7605u);

	public static readonly NodeId TimestampsToReturn_EnumStrings = new NodeId(7606u);

	public static readonly NodeId HistoryUpdateType_EnumValues = new NodeId(11884u);

	public static readonly NodeId PerformUpdateType_EnumValues = new NodeId(11885u);

	public static readonly NodeId MonitoringMode_EnumStrings = new NodeId(7608u);

	public static readonly NodeId DataChangeTrigger_EnumStrings = new NodeId(7609u);

	public static readonly NodeId DeadbandType_EnumStrings = new NodeId(7610u);

	public static readonly NodeId RedundancySupport_EnumStrings = new NodeId(7611u);

	public static readonly NodeId ServerState_EnumStrings = new NodeId(7612u);

	public static readonly NodeId ModelChangeStructureVerbMask_EnumValues = new NodeId(11942u);

	public static readonly NodeId AxisScaleEnumeration_EnumStrings = new NodeId(12078u);

	public static readonly NodeId ExceptionDeviationFormat_EnumStrings = new NodeId(7614u);

	public static readonly NodeId OpcUa_BinarySchema = new NodeId(7617u);

	public static readonly NodeId OpcUa_BinarySchema_NamespaceUri = new NodeId(7619u);

	public static readonly NodeId OpcUa_BinarySchema_Deprecated = new NodeId(15037u);

	public static readonly NodeId OpcUa_BinarySchema_Union = new NodeId(12770u);

	public static readonly NodeId OpcUa_BinarySchema_KeyValuePair = new NodeId(14873u);

	public static readonly NodeId OpcUa_BinarySchema_AdditionalParametersType = new NodeId(17538u);

	public static readonly NodeId OpcUa_BinarySchema_EphemeralKeyType = new NodeId(17550u);

	public static readonly NodeId OpcUa_BinarySchema_EndpointType = new NodeId(15734u);

	public static readonly NodeId OpcUa_BinarySchema_RationalNumber = new NodeId(18824u);

	public static readonly NodeId OpcUa_BinarySchema_Vector = new NodeId(18827u);

	public static readonly NodeId OpcUa_BinarySchema_ThreeDVector = new NodeId(18830u);

	public static readonly NodeId OpcUa_BinarySchema_CartesianCoordinates = new NodeId(18833u);

	public static readonly NodeId OpcUa_BinarySchema_ThreeDCartesianCoordinates = new NodeId(18836u);

	public static readonly NodeId OpcUa_BinarySchema_Orientation = new NodeId(18839u);

	public static readonly NodeId OpcUa_BinarySchema_ThreeDOrientation = new NodeId(18842u);

	public static readonly NodeId OpcUa_BinarySchema_Frame = new NodeId(18845u);

	public static readonly NodeId OpcUa_BinarySchema_ThreeDFrame = new NodeId(18848u);

	public static readonly NodeId OpcUa_BinarySchema_IdentityMappingRuleType = new NodeId(15738u);

	public static readonly NodeId OpcUa_BinarySchema_CurrencyUnitType = new NodeId(23514u);

	public static readonly NodeId OpcUa_BinarySchema_TrustListDataType = new NodeId(12681u);

	public static readonly NodeId OpcUa_BinarySchema_DataTypeSchemaHeader = new NodeId(15741u);

	public static readonly NodeId OpcUa_BinarySchema_DataTypeDescription = new NodeId(14855u);

	public static readonly NodeId OpcUa_BinarySchema_StructureDescription = new NodeId(15599u);

	public static readonly NodeId OpcUa_BinarySchema_EnumDescription = new NodeId(15602u);

	public static readonly NodeId OpcUa_BinarySchema_SimpleTypeDescription = new NodeId(15501u);

	public static readonly NodeId OpcUa_BinarySchema_UABinaryFileDataType = new NodeId(15521u);

	public static readonly NodeId OpcUa_BinarySchema_DataSetMetaDataType = new NodeId(14849u);

	public static readonly NodeId OpcUa_BinarySchema_FieldMetaData = new NodeId(14852u);

	public static readonly NodeId OpcUa_BinarySchema_ConfigurationVersionDataType = new NodeId(14876u);

	public static readonly NodeId OpcUa_BinarySchema_PublishedDataSetDataType = new NodeId(15766u);

	public static readonly NodeId OpcUa_BinarySchema_PublishedDataSetSourceDataType = new NodeId(15769u);

	public static readonly NodeId OpcUa_BinarySchema_PublishedVariableDataType = new NodeId(14324u);

	public static readonly NodeId OpcUa_BinarySchema_PublishedDataItemsDataType = new NodeId(15772u);

	public static readonly NodeId OpcUa_BinarySchema_PublishedEventsDataType = new NodeId(15775u);

	public static readonly NodeId OpcUa_BinarySchema_DataSetWriterDataType = new NodeId(15778u);

	public static readonly NodeId OpcUa_BinarySchema_DataSetWriterTransportDataType = new NodeId(15781u);

	public static readonly NodeId OpcUa_BinarySchema_DataSetWriterMessageDataType = new NodeId(15784u);

	public static readonly NodeId OpcUa_BinarySchema_PubSubGroupDataType = new NodeId(15787u);

	public static readonly NodeId OpcUa_BinarySchema_WriterGroupDataType = new NodeId(21156u);

	public static readonly NodeId OpcUa_BinarySchema_WriterGroupTransportDataType = new NodeId(15793u);

	public static readonly NodeId OpcUa_BinarySchema_WriterGroupMessageDataType = new NodeId(15854u);

	public static readonly NodeId OpcUa_BinarySchema_PubSubConnectionDataType = new NodeId(15857u);

	public static readonly NodeId OpcUa_BinarySchema_ConnectionTransportDataType = new NodeId(15860u);

	public static readonly NodeId OpcUa_BinarySchema_NetworkAddressDataType = new NodeId(21159u);

	public static readonly NodeId OpcUa_BinarySchema_NetworkAddressUrlDataType = new NodeId(21162u);

	public static readonly NodeId OpcUa_BinarySchema_ReaderGroupDataType = new NodeId(21165u);

	public static readonly NodeId OpcUa_BinarySchema_ReaderGroupTransportDataType = new NodeId(15866u);

	public static readonly NodeId OpcUa_BinarySchema_ReaderGroupMessageDataType = new NodeId(15869u);

	public static readonly NodeId OpcUa_BinarySchema_DataSetReaderDataType = new NodeId(15872u);

	public static readonly NodeId OpcUa_BinarySchema_DataSetReaderTransportDataType = new NodeId(15877u);

	public static readonly NodeId OpcUa_BinarySchema_DataSetReaderMessageDataType = new NodeId(15880u);

	public static readonly NodeId OpcUa_BinarySchema_SubscribedDataSetDataType = new NodeId(15883u);

	public static readonly NodeId OpcUa_BinarySchema_TargetVariablesDataType = new NodeId(15886u);

	public static readonly NodeId OpcUa_BinarySchema_FieldTargetDataType = new NodeId(21002u);

	public static readonly NodeId OpcUa_BinarySchema_SubscribedDataSetMirrorDataType = new NodeId(15889u);

	public static readonly NodeId OpcUa_BinarySchema_PubSubConfigurationDataType = new NodeId(21168u);

	public static readonly NodeId OpcUa_BinarySchema_UadpWriterGroupMessageDataType = new NodeId(15895u);

	public static readonly NodeId OpcUa_BinarySchema_UadpDataSetWriterMessageDataType = new NodeId(15898u);

	public static readonly NodeId OpcUa_BinarySchema_UadpDataSetReaderMessageDataType = new NodeId(15919u);

	public static readonly NodeId OpcUa_BinarySchema_JsonWriterGroupMessageDataType = new NodeId(15922u);

	public static readonly NodeId OpcUa_BinarySchema_JsonDataSetWriterMessageDataType = new NodeId(15925u);

	public static readonly NodeId OpcUa_BinarySchema_JsonDataSetReaderMessageDataType = new NodeId(15931u);

	public static readonly NodeId OpcUa_BinarySchema_DatagramConnectionTransportDataType = new NodeId(17469u);

	public static readonly NodeId OpcUa_BinarySchema_DatagramWriterGroupTransportDataType = new NodeId(21171u);

	public static readonly NodeId OpcUa_BinarySchema_BrokerConnectionTransportDataType = new NodeId(15524u);

	public static readonly NodeId OpcUa_BinarySchema_BrokerWriterGroupTransportDataType = new NodeId(15940u);

	public static readonly NodeId OpcUa_BinarySchema_BrokerDataSetWriterTransportDataType = new NodeId(15943u);

	public static readonly NodeId OpcUa_BinarySchema_BrokerDataSetReaderTransportDataType = new NodeId(15946u);

	public static readonly NodeId OpcUa_BinarySchema_AliasNameDataType = new NodeId(23502u);

	public static readonly NodeId OpcUa_BinarySchema_UnsignedRationalNumber = new NodeId(24117u);

	public static readonly NodeId OpcUa_BinarySchema_RolePermissionType = new NodeId(16131u);

	public static readonly NodeId OpcUa_BinarySchema_DataTypeDefinition = new NodeId(18178u);

	public static readonly NodeId OpcUa_BinarySchema_StructureField = new NodeId(18181u);

	public static readonly NodeId OpcUa_BinarySchema_StructureDefinition = new NodeId(18184u);

	public static readonly NodeId OpcUa_BinarySchema_EnumDefinition = new NodeId(18187u);

	public static readonly NodeId OpcUa_BinarySchema_Argument = new NodeId(7650u);

	public static readonly NodeId OpcUa_BinarySchema_EnumValueType = new NodeId(7656u);

	public static readonly NodeId OpcUa_BinarySchema_EnumField = new NodeId(14870u);

	public static readonly NodeId OpcUa_BinarySchema_OptionSet = new NodeId(12767u);

	public static readonly NodeId OpcUa_BinarySchema_TimeZoneDataType = new NodeId(8914u);

	public static readonly NodeId OpcUa_BinarySchema_ApplicationDescription = new NodeId(7665u);

	public static readonly NodeId OpcUa_BinarySchema_ServerOnNetwork = new NodeId(12213u);

	public static readonly NodeId OpcUa_BinarySchema_UserTokenPolicy = new NodeId(7662u);

	public static readonly NodeId OpcUa_BinarySchema_EndpointDescription = new NodeId(7668u);

	public static readonly NodeId OpcUa_BinarySchema_RegisteredServer = new NodeId(7782u);

	public static readonly NodeId OpcUa_BinarySchema_DiscoveryConfiguration = new NodeId(12902u);

	public static readonly NodeId OpcUa_BinarySchema_MdnsDiscoveryConfiguration = new NodeId(12905u);

	public static readonly NodeId OpcUa_BinarySchema_SignedSoftwareCertificate = new NodeId(7698u);

	public static readonly NodeId OpcUa_BinarySchema_UserIdentityToken = new NodeId(7671u);

	public static readonly NodeId OpcUa_BinarySchema_AnonymousIdentityToken = new NodeId(7674u);

	public static readonly NodeId OpcUa_BinarySchema_UserNameIdentityToken = new NodeId(7677u);

	public static readonly NodeId OpcUa_BinarySchema_X509IdentityToken = new NodeId(7680u);

	public static readonly NodeId OpcUa_BinarySchema_IssuedIdentityToken = new NodeId(7683u);

	public static readonly NodeId OpcUa_BinarySchema_AddNodesItem = new NodeId(7728u);

	public static readonly NodeId OpcUa_BinarySchema_AddReferencesItem = new NodeId(7731u);

	public static readonly NodeId OpcUa_BinarySchema_DeleteNodesItem = new NodeId(7734u);

	public static readonly NodeId OpcUa_BinarySchema_DeleteReferencesItem = new NodeId(7737u);

	public static readonly NodeId OpcUa_BinarySchema_RelativePathElement = new NodeId(12718u);

	public static readonly NodeId OpcUa_BinarySchema_RelativePath = new NodeId(12721u);

	public static readonly NodeId OpcUa_BinarySchema_EndpointConfiguration = new NodeId(7686u);

	public static readonly NodeId OpcUa_BinarySchema_ContentFilterElement = new NodeId(7929u);

	public static readonly NodeId OpcUa_BinarySchema_ContentFilter = new NodeId(7932u);

	public static readonly NodeId OpcUa_BinarySchema_FilterOperand = new NodeId(7935u);

	public static readonly NodeId OpcUa_BinarySchema_ElementOperand = new NodeId(7938u);

	public static readonly NodeId OpcUa_BinarySchema_LiteralOperand = new NodeId(7941u);

	public static readonly NodeId OpcUa_BinarySchema_AttributeOperand = new NodeId(7944u);

	public static readonly NodeId OpcUa_BinarySchema_SimpleAttributeOperand = new NodeId(7947u);

	public static readonly NodeId OpcUa_BinarySchema_HistoryEvent = new NodeId(8004u);

	public static readonly NodeId OpcUa_BinarySchema_MonitoringFilter = new NodeId(8067u);

	public static readonly NodeId OpcUa_BinarySchema_EventFilter = new NodeId(8073u);

	public static readonly NodeId OpcUa_BinarySchema_AggregateConfiguration = new NodeId(8076u);

	public static readonly NodeId OpcUa_BinarySchema_HistoryEventFieldList = new NodeId(8172u);

	public static readonly NodeId OpcUa_BinarySchema_BuildInfo = new NodeId(7692u);

	public static readonly NodeId OpcUa_BinarySchema_RedundantServerDataType = new NodeId(8208u);

	public static readonly NodeId OpcUa_BinarySchema_EndpointUrlListDataType = new NodeId(11959u);

	public static readonly NodeId OpcUa_BinarySchema_NetworkGroupDataType = new NodeId(11962u);

	public static readonly NodeId OpcUa_BinarySchema_SamplingIntervalDiagnosticsDataType = new NodeId(8211u);

	public static readonly NodeId OpcUa_BinarySchema_ServerDiagnosticsSummaryDataType = new NodeId(8214u);

	public static readonly NodeId OpcUa_BinarySchema_ServerStatusDataType = new NodeId(8217u);

	public static readonly NodeId OpcUa_BinarySchema_SessionDiagnosticsDataType = new NodeId(8220u);

	public static readonly NodeId OpcUa_BinarySchema_SessionSecurityDiagnosticsDataType = new NodeId(8223u);

	public static readonly NodeId OpcUa_BinarySchema_ServiceCounterDataType = new NodeId(8226u);

	public static readonly NodeId OpcUa_BinarySchema_StatusResult = new NodeId(7659u);

	public static readonly NodeId OpcUa_BinarySchema_SubscriptionDiagnosticsDataType = new NodeId(8229u);

	public static readonly NodeId OpcUa_BinarySchema_ModelChangeStructureDataType = new NodeId(8232u);

	public static readonly NodeId OpcUa_BinarySchema_SemanticChangeStructureDataType = new NodeId(8235u);

	public static readonly NodeId OpcUa_BinarySchema_Range = new NodeId(8238u);

	public static readonly NodeId OpcUa_BinarySchema_EUInformation = new NodeId(8241u);

	public static readonly NodeId OpcUa_BinarySchema_ComplexNumberType = new NodeId(12183u);

	public static readonly NodeId OpcUa_BinarySchema_DoubleComplexNumberType = new NodeId(12186u);

	public static readonly NodeId OpcUa_BinarySchema_AxisInformation = new NodeId(12091u);

	public static readonly NodeId OpcUa_BinarySchema_XVType = new NodeId(12094u);

	public static readonly NodeId OpcUa_BinarySchema_ProgramDiagnosticDataType = new NodeId(8247u);

	public static readonly NodeId OpcUa_BinarySchema_ProgramDiagnostic2DataType = new NodeId(24035u);

	public static readonly NodeId OpcUa_BinarySchema_Annotation = new NodeId(8244u);

	public static readonly NodeId OpcUa_XmlSchema = new NodeId(8252u);

	public static readonly NodeId OpcUa_XmlSchema_NamespaceUri = new NodeId(8254u);

	public static readonly NodeId OpcUa_XmlSchema_Deprecated = new NodeId(15039u);

	public static readonly NodeId OpcUa_XmlSchema_Union = new NodeId(12762u);

	public static readonly NodeId OpcUa_XmlSchema_KeyValuePair = new NodeId(14829u);

	public static readonly NodeId OpcUa_XmlSchema_AdditionalParametersType = new NodeId(17542u);

	public static readonly NodeId OpcUa_XmlSchema_EphemeralKeyType = new NodeId(17554u);

	public static readonly NodeId OpcUa_XmlSchema_EndpointType = new NodeId(16024u);

	public static readonly NodeId OpcUa_XmlSchema_RationalNumber = new NodeId(18860u);

	public static readonly NodeId OpcUa_XmlSchema_Vector = new NodeId(18863u);

	public static readonly NodeId OpcUa_XmlSchema_ThreeDVector = new NodeId(18866u);

	public static readonly NodeId OpcUa_XmlSchema_CartesianCoordinates = new NodeId(18869u);

	public static readonly NodeId OpcUa_XmlSchema_ThreeDCartesianCoordinates = new NodeId(19049u);

	public static readonly NodeId OpcUa_XmlSchema_Orientation = new NodeId(19052u);

	public static readonly NodeId OpcUa_XmlSchema_ThreeDOrientation = new NodeId(19055u);

	public static readonly NodeId OpcUa_XmlSchema_Frame = new NodeId(19058u);

	public static readonly NodeId OpcUa_XmlSchema_ThreeDFrame = new NodeId(19061u);

	public static readonly NodeId OpcUa_XmlSchema_IdentityMappingRuleType = new NodeId(15730u);

	public static readonly NodeId OpcUa_XmlSchema_CurrencyUnitType = new NodeId(23522u);

	public static readonly NodeId OpcUa_XmlSchema_TrustListDataType = new NodeId(12677u);

	public static readonly NodeId OpcUa_XmlSchema_DataTypeSchemaHeader = new NodeId(16027u);

	public static readonly NodeId OpcUa_XmlSchema_DataTypeDescription = new NodeId(14811u);

	public static readonly NodeId OpcUa_XmlSchema_StructureDescription = new NodeId(15591u);

	public static readonly NodeId OpcUa_XmlSchema_EnumDescription = new NodeId(15594u);

	public static readonly NodeId OpcUa_XmlSchema_SimpleTypeDescription = new NodeId(15585u);

	public static readonly NodeId OpcUa_XmlSchema_UABinaryFileDataType = new NodeId(15588u);

	public static readonly NodeId OpcUa_XmlSchema_DataSetMetaDataType = new NodeId(14805u);

	public static readonly NodeId OpcUa_XmlSchema_FieldMetaData = new NodeId(14808u);

	public static readonly NodeId OpcUa_XmlSchema_ConfigurationVersionDataType = new NodeId(14832u);

	public static readonly NodeId OpcUa_XmlSchema_PublishedDataSetDataType = new NodeId(16030u);

	public static readonly NodeId OpcUa_XmlSchema_PublishedDataSetSourceDataType = new NodeId(16033u);

	public static readonly NodeId OpcUa_XmlSchema_PublishedVariableDataType = new NodeId(14320u);

	public static readonly NodeId OpcUa_XmlSchema_PublishedDataItemsDataType = new NodeId(16037u);

	public static readonly NodeId OpcUa_XmlSchema_PublishedEventsDataType = new NodeId(16040u);

	public static readonly NodeId OpcUa_XmlSchema_DataSetWriterDataType = new NodeId(16047u);

	public static readonly NodeId OpcUa_XmlSchema_DataSetWriterTransportDataType = new NodeId(16050u);

	public static readonly NodeId OpcUa_XmlSchema_DataSetWriterMessageDataType = new NodeId(16053u);

	public static readonly NodeId OpcUa_XmlSchema_PubSubGroupDataType = new NodeId(16056u);

	public static readonly NodeId OpcUa_XmlSchema_WriterGroupDataType = new NodeId(21180u);

	public static readonly NodeId OpcUa_XmlSchema_WriterGroupTransportDataType = new NodeId(16062u);

	public static readonly NodeId OpcUa_XmlSchema_WriterGroupMessageDataType = new NodeId(16065u);

	public static readonly NodeId OpcUa_XmlSchema_PubSubConnectionDataType = new NodeId(16068u);

	public static readonly NodeId OpcUa_XmlSchema_ConnectionTransportDataType = new NodeId(16071u);

	public static readonly NodeId OpcUa_XmlSchema_NetworkAddressDataType = new NodeId(21183u);

	public static readonly NodeId OpcUa_XmlSchema_NetworkAddressUrlDataType = new NodeId(21186u);

	public static readonly NodeId OpcUa_XmlSchema_ReaderGroupDataType = new NodeId(21189u);

	public static readonly NodeId OpcUa_XmlSchema_ReaderGroupTransportDataType = new NodeId(16077u);

	public static readonly NodeId OpcUa_XmlSchema_ReaderGroupMessageDataType = new NodeId(16080u);

	public static readonly NodeId OpcUa_XmlSchema_DataSetReaderDataType = new NodeId(16083u);

	public static readonly NodeId OpcUa_XmlSchema_DataSetReaderTransportDataType = new NodeId(16086u);

	public static readonly NodeId OpcUa_XmlSchema_DataSetReaderMessageDataType = new NodeId(16089u);

	public static readonly NodeId OpcUa_XmlSchema_SubscribedDataSetDataType = new NodeId(16092u);

	public static readonly NodeId OpcUa_XmlSchema_TargetVariablesDataType = new NodeId(16095u);

	public static readonly NodeId OpcUa_XmlSchema_FieldTargetDataType = new NodeId(14835u);

	public static readonly NodeId OpcUa_XmlSchema_SubscribedDataSetMirrorDataType = new NodeId(16098u);

	public static readonly NodeId OpcUa_XmlSchema_PubSubConfigurationDataType = new NodeId(21192u);

	public static readonly NodeId OpcUa_XmlSchema_UadpWriterGroupMessageDataType = new NodeId(16104u);

	public static readonly NodeId OpcUa_XmlSchema_UadpDataSetWriterMessageDataType = new NodeId(16107u);

	public static readonly NodeId OpcUa_XmlSchema_UadpDataSetReaderMessageDataType = new NodeId(16110u);

	public static readonly NodeId OpcUa_XmlSchema_JsonWriterGroupMessageDataType = new NodeId(16113u);

	public static readonly NodeId OpcUa_XmlSchema_JsonDataSetWriterMessageDataType = new NodeId(16116u);

	public static readonly NodeId OpcUa_XmlSchema_JsonDataSetReaderMessageDataType = new NodeId(16119u);

	public static readonly NodeId OpcUa_XmlSchema_DatagramConnectionTransportDataType = new NodeId(17473u);

	public static readonly NodeId OpcUa_XmlSchema_DatagramWriterGroupTransportDataType = new NodeId(21195u);

	public static readonly NodeId OpcUa_XmlSchema_BrokerConnectionTransportDataType = new NodeId(15640u);

	public static readonly NodeId OpcUa_XmlSchema_BrokerWriterGroupTransportDataType = new NodeId(16125u);

	public static readonly NodeId OpcUa_XmlSchema_BrokerDataSetWriterTransportDataType = new NodeId(16144u);

	public static readonly NodeId OpcUa_XmlSchema_BrokerDataSetReaderTransportDataType = new NodeId(16147u);

	public static readonly NodeId OpcUa_XmlSchema_AliasNameDataType = new NodeId(23508u);

	public static readonly NodeId OpcUa_XmlSchema_UnsignedRationalNumber = new NodeId(24129u);

	public static readonly NodeId OpcUa_XmlSchema_RolePermissionType = new NodeId(16127u);

	public static readonly NodeId OpcUa_XmlSchema_DataTypeDefinition = new NodeId(18166u);

	public static readonly NodeId OpcUa_XmlSchema_StructureField = new NodeId(18169u);

	public static readonly NodeId OpcUa_XmlSchema_StructureDefinition = new NodeId(18172u);

	public static readonly NodeId OpcUa_XmlSchema_EnumDefinition = new NodeId(18175u);

	public static readonly NodeId OpcUa_XmlSchema_Argument = new NodeId(8285u);

	public static readonly NodeId OpcUa_XmlSchema_EnumValueType = new NodeId(8291u);

	public static readonly NodeId OpcUa_XmlSchema_EnumField = new NodeId(14826u);

	public static readonly NodeId OpcUa_XmlSchema_OptionSet = new NodeId(12759u);

	public static readonly NodeId OpcUa_XmlSchema_TimeZoneDataType = new NodeId(8918u);

	public static readonly NodeId OpcUa_XmlSchema_ApplicationDescription = new NodeId(8300u);

	public static readonly NodeId OpcUa_XmlSchema_ServerOnNetwork = new NodeId(12201u);

	public static readonly NodeId OpcUa_XmlSchema_UserTokenPolicy = new NodeId(8297u);

	public static readonly NodeId OpcUa_XmlSchema_EndpointDescription = new NodeId(8303u);

	public static readonly NodeId OpcUa_XmlSchema_RegisteredServer = new NodeId(8417u);

	public static readonly NodeId OpcUa_XmlSchema_DiscoveryConfiguration = new NodeId(12894u);

	public static readonly NodeId OpcUa_XmlSchema_MdnsDiscoveryConfiguration = new NodeId(12897u);

	public static readonly NodeId OpcUa_XmlSchema_SignedSoftwareCertificate = new NodeId(8333u);

	public static readonly NodeId OpcUa_XmlSchema_UserIdentityToken = new NodeId(8306u);

	public static readonly NodeId OpcUa_XmlSchema_AnonymousIdentityToken = new NodeId(8309u);

	public static readonly NodeId OpcUa_XmlSchema_UserNameIdentityToken = new NodeId(8312u);

	public static readonly NodeId OpcUa_XmlSchema_X509IdentityToken = new NodeId(8315u);

	public static readonly NodeId OpcUa_XmlSchema_IssuedIdentityToken = new NodeId(8318u);

	public static readonly NodeId OpcUa_XmlSchema_AddNodesItem = new NodeId(8363u);

	public static readonly NodeId OpcUa_XmlSchema_AddReferencesItem = new NodeId(8366u);

	public static readonly NodeId OpcUa_XmlSchema_DeleteNodesItem = new NodeId(8369u);

	public static readonly NodeId OpcUa_XmlSchema_DeleteReferencesItem = new NodeId(8372u);

	public static readonly NodeId OpcUa_XmlSchema_RelativePathElement = new NodeId(12712u);

	public static readonly NodeId OpcUa_XmlSchema_RelativePath = new NodeId(12715u);

	public static readonly NodeId OpcUa_XmlSchema_EndpointConfiguration = new NodeId(8321u);

	public static readonly NodeId OpcUa_XmlSchema_ContentFilterElement = new NodeId(8564u);

	public static readonly NodeId OpcUa_XmlSchema_ContentFilter = new NodeId(8567u);

	public static readonly NodeId OpcUa_XmlSchema_FilterOperand = new NodeId(8570u);

	public static readonly NodeId OpcUa_XmlSchema_ElementOperand = new NodeId(8573u);

	public static readonly NodeId OpcUa_XmlSchema_LiteralOperand = new NodeId(8576u);

	public static readonly NodeId OpcUa_XmlSchema_AttributeOperand = new NodeId(8579u);

	public static readonly NodeId OpcUa_XmlSchema_SimpleAttributeOperand = new NodeId(8582u);

	public static readonly NodeId OpcUa_XmlSchema_HistoryEvent = new NodeId(8639u);

	public static readonly NodeId OpcUa_XmlSchema_MonitoringFilter = new NodeId(8702u);

	public static readonly NodeId OpcUa_XmlSchema_EventFilter = new NodeId(8708u);

	public static readonly NodeId OpcUa_XmlSchema_AggregateConfiguration = new NodeId(8711u);

	public static readonly NodeId OpcUa_XmlSchema_HistoryEventFieldList = new NodeId(8807u);

	public static readonly NodeId OpcUa_XmlSchema_BuildInfo = new NodeId(8327u);

	public static readonly NodeId OpcUa_XmlSchema_RedundantServerDataType = new NodeId(8843u);

	public static readonly NodeId OpcUa_XmlSchema_EndpointUrlListDataType = new NodeId(11951u);

	public static readonly NodeId OpcUa_XmlSchema_NetworkGroupDataType = new NodeId(11954u);

	public static readonly NodeId OpcUa_XmlSchema_SamplingIntervalDiagnosticsDataType = new NodeId(8846u);

	public static readonly NodeId OpcUa_XmlSchema_ServerDiagnosticsSummaryDataType = new NodeId(8849u);

	public static readonly NodeId OpcUa_XmlSchema_ServerStatusDataType = new NodeId(8852u);

	public static readonly NodeId OpcUa_XmlSchema_SessionDiagnosticsDataType = new NodeId(8855u);

	public static readonly NodeId OpcUa_XmlSchema_SessionSecurityDiagnosticsDataType = new NodeId(8858u);

	public static readonly NodeId OpcUa_XmlSchema_ServiceCounterDataType = new NodeId(8861u);

	public static readonly NodeId OpcUa_XmlSchema_StatusResult = new NodeId(8294u);

	public static readonly NodeId OpcUa_XmlSchema_SubscriptionDiagnosticsDataType = new NodeId(8864u);

	public static readonly NodeId OpcUa_XmlSchema_ModelChangeStructureDataType = new NodeId(8867u);

	public static readonly NodeId OpcUa_XmlSchema_SemanticChangeStructureDataType = new NodeId(8870u);

	public static readonly NodeId OpcUa_XmlSchema_Range = new NodeId(8873u);

	public static readonly NodeId OpcUa_XmlSchema_EUInformation = new NodeId(8876u);

	public static readonly NodeId OpcUa_XmlSchema_ComplexNumberType = new NodeId(12175u);

	public static readonly NodeId OpcUa_XmlSchema_DoubleComplexNumberType = new NodeId(12178u);

	public static readonly NodeId OpcUa_XmlSchema_AxisInformation = new NodeId(12083u);

	public static readonly NodeId OpcUa_XmlSchema_XVType = new NodeId(12086u);

	public static readonly NodeId OpcUa_XmlSchema_ProgramDiagnosticDataType = new NodeId(8882u);

	public static readonly NodeId OpcUa_XmlSchema_ProgramDiagnostic2DataType = new NodeId(24039u);

	public static readonly NodeId OpcUa_XmlSchema_Annotation = new NodeId(8879u);
}
