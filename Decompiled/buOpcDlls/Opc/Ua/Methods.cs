using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class Methods
{
	public const uint OPCUANamespaceMetadata_NamespaceFile_Open = 15971u;

	public const uint OPCUANamespaceMetadata_NamespaceFile_Close = 15974u;

	public const uint OPCUANamespaceMetadata_NamespaceFile_Read = 15976u;

	public const uint OPCUANamespaceMetadata_NamespaceFile_Write = 15979u;

	public const uint OPCUANamespaceMetadata_NamespaceFile_GetPosition = 15981u;

	public const uint OPCUANamespaceMetadata_NamespaceFile_SetPosition = 15984u;

	public const uint ServerType_ServerCapabilities_RoleSet_AddRole = 16290u;

	public const uint ServerType_ServerCapabilities_RoleSet_RemoveRole = 16293u;

	public const uint ServerType_GetMonitoredItems = 11489u;

	public const uint ServerType_ResendData = 12871u;

	public const uint ServerType_SetSubscriptionDurable = 12746u;

	public const uint ServerType_RequestServerStateChange = 12883u;

	public const uint ServerCapabilitiesType_RoleSet_AddRole = 16296u;

	public const uint ServerCapabilitiesType_RoleSet_RemoveRole = 16299u;

	public const uint FileType_Open = 11580u;

	public const uint FileType_Close = 11583u;

	public const uint FileType_Read = 11585u;

	public const uint FileType_Write = 11588u;

	public const uint FileType_GetPosition = 11590u;

	public const uint FileType_SetPosition = 11593u;

	public const uint AddressSpaceFileType_ExportNamespace = 11615u;

	public const uint NamespaceMetadataType_NamespaceFile_Open = 11629u;

	public const uint NamespaceMetadataType_NamespaceFile_Close = 11632u;

	public const uint NamespaceMetadataType_NamespaceFile_Read = 11634u;

	public const uint NamespaceMetadataType_NamespaceFile_Write = 11637u;

	public const uint NamespaceMetadataType_NamespaceFile_GetPosition = 11639u;

	public const uint NamespaceMetadataType_NamespaceFile_SetPosition = 11642u;

	public const uint NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Open = 11659u;

	public const uint NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Close = 11662u;

	public const uint NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Read = 11664u;

	public const uint NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_Write = 11667u;

	public const uint NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_GetPosition = 11669u;

	public const uint NamespacesType_NamespaceIdentifier_Placeholder_NamespaceFile_SetPosition = 11672u;

	public const uint Server_ServerCapabilities_RoleSet_AddRole = 16301u;

	public const uint Server_ServerCapabilities_RoleSet_RemoveRole = 16304u;

	public const uint Server_GetMonitoredItems = 11492u;

	public const uint Server_ResendData = 12873u;

	public const uint Server_SetSubscriptionDurable = 12749u;

	public const uint Server_RequestServerStateChange = 12886u;

	public const uint FileDirectoryType_FileDirectoryName_Placeholder_CreateDirectory = 13355u;

	public const uint FileDirectoryType_FileDirectoryName_Placeholder_CreateFile = 13358u;

	public const uint FileDirectoryType_FileDirectoryName_Placeholder_DeleteFileSystemObject = 17718u;

	public const uint FileDirectoryType_FileDirectoryName_Placeholder_MoveOrCopy = 13363u;

	public const uint FileDirectoryType_FileName_Placeholder_Open = 13372u;

	public const uint FileDirectoryType_FileName_Placeholder_Close = 13375u;

	public const uint FileDirectoryType_FileName_Placeholder_Read = 13377u;

	public const uint FileDirectoryType_FileName_Placeholder_Write = 13380u;

	public const uint FileDirectoryType_FileName_Placeholder_GetPosition = 13382u;

	public const uint FileDirectoryType_FileName_Placeholder_SetPosition = 13385u;

	public const uint FileDirectoryType_CreateDirectory = 13387u;

	public const uint FileDirectoryType_CreateFile = 13390u;

	public const uint FileDirectoryType_DeleteFileSystemObject = 13393u;

	public const uint FileDirectoryType_MoveOrCopy = 13395u;

	public const uint FileSystem_FileDirectoryName_Placeholder_CreateDirectory = 16316u;

	public const uint FileSystem_FileDirectoryName_Placeholder_CreateFile = 16319u;

	public const uint FileSystem_FileDirectoryName_Placeholder_DeleteFileSystemObject = 17722u;

	public const uint FileSystem_FileDirectoryName_Placeholder_MoveOrCopy = 16324u;

	public const uint FileSystem_FileName_Placeholder_Open = 16333u;

	public const uint FileSystem_FileName_Placeholder_Close = 16336u;

	public const uint FileSystem_FileName_Placeholder_Read = 16338u;

	public const uint FileSystem_FileName_Placeholder_Write = 16341u;

	public const uint FileSystem_FileName_Placeholder_GetPosition = 16343u;

	public const uint FileSystem_FileName_Placeholder_SetPosition = 16346u;

	public const uint FileSystem_CreateDirectory = 16348u;

	public const uint FileSystem_CreateFile = 16351u;

	public const uint FileSystem_DeleteFileSystemObject = 16354u;

	public const uint FileSystem_MoveOrCopy = 16356u;

	public const uint TemporaryFileTransferType_GenerateFileForRead = 15746u;

	public const uint TemporaryFileTransferType_GenerateFileForWrite = 15749u;

	public const uint TemporaryFileTransferType_CloseAndCommit = 15751u;

	public const uint TemporaryFileTransferType_TransferState_Placeholder_Reset = 15794u;

	public const uint FileTransferStateMachineType_Reset = 15843u;

	public const uint RoleSetType_AddRole = 15997u;

	public const uint RoleSetType_RemoveRole = 16000u;

	public const uint RoleType_AddIdentity = 15624u;

	public const uint RoleType_RemoveIdentity = 15626u;

	public const uint RoleType_AddApplication = 16176u;

	public const uint RoleType_RemoveApplication = 16178u;

	public const uint RoleType_AddEndpoint = 16180u;

	public const uint RoleType_RemoveEndpoint = 16182u;

	public const uint WellKnownRole_Anonymous_AddIdentity = 15648u;

	public const uint WellKnownRole_Anonymous_RemoveIdentity = 15650u;

	public const uint WellKnownRole_Anonymous_AddApplication = 16195u;

	public const uint WellKnownRole_Anonymous_RemoveApplication = 16197u;

	public const uint WellKnownRole_Anonymous_AddEndpoint = 16199u;

	public const uint WellKnownRole_Anonymous_RemoveEndpoint = 16201u;

	public const uint WellKnownRole_AuthenticatedUser_AddIdentity = 15660u;

	public const uint WellKnownRole_AuthenticatedUser_RemoveIdentity = 15662u;

	public const uint WellKnownRole_AuthenticatedUser_AddApplication = 16206u;

	public const uint WellKnownRole_AuthenticatedUser_RemoveApplication = 16208u;

	public const uint WellKnownRole_AuthenticatedUser_AddEndpoint = 16210u;

	public const uint WellKnownRole_AuthenticatedUser_RemoveEndpoint = 16212u;

	public const uint WellKnownRole_Observer_AddIdentity = 15672u;

	public const uint WellKnownRole_Observer_RemoveIdentity = 15674u;

	public const uint WellKnownRole_Observer_AddApplication = 16217u;

	public const uint WellKnownRole_Observer_RemoveApplication = 16219u;

	public const uint WellKnownRole_Observer_AddEndpoint = 16221u;

	public const uint WellKnownRole_Observer_RemoveEndpoint = 16223u;

	public const uint WellKnownRole_Operator_AddIdentity = 15684u;

	public const uint WellKnownRole_Operator_RemoveIdentity = 15686u;

	public const uint WellKnownRole_Operator_AddApplication = 16228u;

	public const uint WellKnownRole_Operator_RemoveApplication = 16230u;

	public const uint WellKnownRole_Operator_AddEndpoint = 16232u;

	public const uint WellKnownRole_Operator_RemoveEndpoint = 16234u;

	public const uint WellKnownRole_Engineer_AddIdentity = 16041u;

	public const uint WellKnownRole_Engineer_RemoveIdentity = 16043u;

	public const uint WellKnownRole_Engineer_AddApplication = 16239u;

	public const uint WellKnownRole_Engineer_RemoveApplication = 16241u;

	public const uint WellKnownRole_Engineer_AddEndpoint = 16243u;

	public const uint WellKnownRole_Engineer_RemoveEndpoint = 16245u;

	public const uint WellKnownRole_Supervisor_AddIdentity = 15696u;

	public const uint WellKnownRole_Supervisor_RemoveIdentity = 15698u;

	public const uint WellKnownRole_Supervisor_AddApplication = 16250u;

	public const uint WellKnownRole_Supervisor_RemoveApplication = 16252u;

	public const uint WellKnownRole_Supervisor_AddEndpoint = 16254u;

	public const uint WellKnownRole_Supervisor_RemoveEndpoint = 16256u;

	public const uint WellKnownRole_ConfigureAdmin_AddIdentity = 15720u;

	public const uint WellKnownRole_ConfigureAdmin_RemoveIdentity = 15722u;

	public const uint WellKnownRole_ConfigureAdmin_AddApplication = 16272u;

	public const uint WellKnownRole_ConfigureAdmin_RemoveApplication = 16274u;

	public const uint WellKnownRole_ConfigureAdmin_AddEndpoint = 16276u;

	public const uint WellKnownRole_ConfigureAdmin_RemoveEndpoint = 16278u;

	public const uint WellKnownRole_SecurityAdmin_AddIdentity = 15708u;

	public const uint WellKnownRole_SecurityAdmin_RemoveIdentity = 15710u;

	public const uint WellKnownRole_SecurityAdmin_AddApplication = 16261u;

	public const uint WellKnownRole_SecurityAdmin_RemoveApplication = 16263u;

	public const uint WellKnownRole_SecurityAdmin_AddEndpoint = 16265u;

	public const uint WellKnownRole_SecurityAdmin_RemoveEndpoint = 16267u;

	public const uint ConditionType_Disable = 9028u;

	public const uint ConditionType_Enable = 9027u;

	public const uint ConditionType_AddComment = 9029u;

	public const uint ConditionType_ConditionRefresh = 3875u;

	public const uint ConditionType_ConditionRefresh2 = 12912u;

	public const uint DialogConditionType_Respond = 9069u;

	public const uint AcknowledgeableConditionType_Acknowledge = 9111u;

	public const uint AcknowledgeableConditionType_Confirm = 9113u;

	public const uint AlarmConditionType_ShelvingState_TimedShelve = 9213u;

	public const uint AlarmConditionType_ShelvingState_Unshelve = 9211u;

	public const uint AlarmConditionType_ShelvingState_OneShotShelve = 9212u;

	public const uint AlarmConditionType_Silence = 16402u;

	public const uint AlarmConditionType_Suppress = 16403u;

	public const uint AlarmConditionType_Unsuppress = 17868u;

	public const uint AlarmConditionType_RemoveFromService = 17869u;

	public const uint AlarmConditionType_PlaceInService = 17870u;

	public const uint AlarmConditionType_Reset = 18199u;

	public const uint AlarmGroupType_AlarmConditionInstance_Placeholder_Disable = 16439u;

	public const uint AlarmGroupType_AlarmConditionInstance_Placeholder_Enable = 16440u;

	public const uint AlarmGroupType_AlarmConditionInstance_Placeholder_AddComment = 16441u;

	public const uint AlarmGroupType_AlarmConditionInstance_Placeholder_Acknowledge = 16461u;

	public const uint AlarmGroupType_AlarmConditionInstance_Placeholder_ShelvingState_TimedShelve = 16517u;

	public const uint AlarmGroupType_AlarmConditionInstance_Placeholder_ShelvingState_Unshelve = 16515u;

	public const uint AlarmGroupType_AlarmConditionInstance_Placeholder_ShelvingState_OneShotShelve = 16516u;

	public const uint ShelvedStateMachineType_TimedShelve = 2949u;

	public const uint ShelvedStateMachineType_Unshelve = 2947u;

	public const uint ShelvedStateMachineType_OneShotShelve = 2948u;

	public const uint LimitAlarmType_ShelvingState_TimedShelve = 9314u;

	public const uint LimitAlarmType_ShelvingState_Unshelve = 9312u;

	public const uint LimitAlarmType_ShelvingState_OneShotShelve = 9313u;

	public const uint ExclusiveLimitAlarmType_ShelvingState_TimedShelve = 9451u;

	public const uint ExclusiveLimitAlarmType_ShelvingState_Unshelve = 9449u;

	public const uint ExclusiveLimitAlarmType_ShelvingState_OneShotShelve = 9450u;

	public const uint NonExclusiveLimitAlarmType_ShelvingState_TimedShelve = 10016u;

	public const uint NonExclusiveLimitAlarmType_ShelvingState_Unshelve = 10014u;

	public const uint NonExclusiveLimitAlarmType_ShelvingState_OneShotShelve = 10015u;

	public const uint NonExclusiveLevelAlarmType_ShelvingState_TimedShelve = 10170u;

	public const uint NonExclusiveLevelAlarmType_ShelvingState_Unshelve = 10168u;

	public const uint NonExclusiveLevelAlarmType_ShelvingState_OneShotShelve = 10169u;

	public const uint ExclusiveLevelAlarmType_ShelvingState_TimedShelve = 9592u;

	public const uint ExclusiveLevelAlarmType_ShelvingState_Unshelve = 9590u;

	public const uint ExclusiveLevelAlarmType_ShelvingState_OneShotShelve = 9591u;

	public const uint NonExclusiveDeviationAlarmType_ShelvingState_TimedShelve = 10478u;

	public const uint NonExclusiveDeviationAlarmType_ShelvingState_Unshelve = 10476u;

	public const uint NonExclusiveDeviationAlarmType_ShelvingState_OneShotShelve = 10477u;

	public const uint NonExclusiveRateOfChangeAlarmType_ShelvingState_TimedShelve = 10324u;

	public const uint NonExclusiveRateOfChangeAlarmType_ShelvingState_Unshelve = 10322u;

	public const uint NonExclusiveRateOfChangeAlarmType_ShelvingState_OneShotShelve = 10323u;

	public const uint ExclusiveDeviationAlarmType_ShelvingState_TimedShelve = 9874u;

	public const uint ExclusiveDeviationAlarmType_ShelvingState_Unshelve = 9872u;

	public const uint ExclusiveDeviationAlarmType_ShelvingState_OneShotShelve = 9873u;

	public const uint ExclusiveRateOfChangeAlarmType_ShelvingState_TimedShelve = 9733u;

	public const uint ExclusiveRateOfChangeAlarmType_ShelvingState_Unshelve = 9731u;

	public const uint ExclusiveRateOfChangeAlarmType_ShelvingState_OneShotShelve = 9732u;

	public const uint DiscreteAlarmType_ShelvingState_TimedShelve = 10633u;

	public const uint DiscreteAlarmType_ShelvingState_Unshelve = 10631u;

	public const uint DiscreteAlarmType_ShelvingState_OneShotShelve = 10632u;

	public const uint OffNormalAlarmType_ShelvingState_TimedShelve = 10747u;

	public const uint OffNormalAlarmType_ShelvingState_Unshelve = 10745u;

	public const uint OffNormalAlarmType_ShelvingState_OneShotShelve = 10746u;

	public const uint SystemOffNormalAlarmType_ShelvingState_TimedShelve = 11846u;

	public const uint SystemOffNormalAlarmType_ShelvingState_Unshelve = 11844u;

	public const uint SystemOffNormalAlarmType_ShelvingState_OneShotShelve = 11845u;

	public const uint TripAlarmType_ShelvingState_TimedShelve = 10861u;

	public const uint TripAlarmType_ShelvingState_Unshelve = 10859u;

	public const uint TripAlarmType_ShelvingState_OneShotShelve = 10860u;

	public const uint InstrumentDiagnosticAlarmType_ShelvingState_TimedShelve = 18453u;

	public const uint InstrumentDiagnosticAlarmType_ShelvingState_Unshelve = 18455u;

	public const uint InstrumentDiagnosticAlarmType_ShelvingState_OneShotShelve = 18456u;

	public const uint SystemDiagnosticAlarmType_ShelvingState_TimedShelve = 18602u;

	public const uint SystemDiagnosticAlarmType_ShelvingState_Unshelve = 18604u;

	public const uint SystemDiagnosticAlarmType_ShelvingState_OneShotShelve = 18605u;

	public const uint CertificateExpirationAlarmType_ShelvingState_TimedShelve = 13320u;

	public const uint CertificateExpirationAlarmType_ShelvingState_Unshelve = 13318u;

	public const uint CertificateExpirationAlarmType_ShelvingState_OneShotShelve = 13319u;

	public const uint DiscrepancyAlarmType_ShelvingState_TimedShelve = 17195u;

	public const uint DiscrepancyAlarmType_ShelvingState_Unshelve = 17193u;

	public const uint DiscrepancyAlarmType_ShelvingState_OneShotShelve = 17194u;

	public const uint AlarmMetricsType_Reset = 18666u;

	public const uint ProgramStateMachineType_Start = 2426u;

	public const uint ProgramStateMachineType_Suspend = 2427u;

	public const uint ProgramStateMachineType_Resume = 2428u;

	public const uint ProgramStateMachineType_Halt = 2429u;

	public const uint ProgramStateMachineType_Reset = 2430u;

	public const uint TrustListType_OpenWithMasks = 12543u;

	public const uint TrustListType_CloseAndUpdate = 12546u;

	public const uint TrustListType_AddCertificate = 12548u;

	public const uint TrustListType_RemoveCertificate = 12550u;

	public const uint TrustListOutOfDateAlarmType_ShelvingState_TimedShelve = 19403u;

	public const uint TrustListOutOfDateAlarmType_ShelvingState_Unshelve = 19405u;

	public const uint TrustListOutOfDateAlarmType_ShelvingState_OneShotShelve = 19406u;

	public const uint CertificateGroupType_TrustList_Open = 13605u;

	public const uint CertificateGroupType_TrustList_Close = 13608u;

	public const uint CertificateGroupType_TrustList_Read = 13610u;

	public const uint CertificateGroupType_TrustList_Write = 13613u;

	public const uint CertificateGroupType_TrustList_GetPosition = 13615u;

	public const uint CertificateGroupType_TrustList_SetPosition = 13618u;

	public const uint CertificateGroupType_TrustList_OpenWithMasks = 13621u;

	public const uint CertificateGroupType_CertificateExpired_Disable = 19483u;

	public const uint CertificateGroupType_CertificateExpired_Enable = 19484u;

	public const uint CertificateGroupType_CertificateExpired_AddComment = 19485u;

	public const uint CertificateGroupType_CertificateExpired_Acknowledge = 19505u;

	public const uint CertificateGroupType_CertificateExpired_ShelvingState_TimedShelve = 20097u;

	public const uint CertificateGroupType_CertificateExpired_ShelvingState_Unshelve = 20099u;

	public const uint CertificateGroupType_CertificateExpired_ShelvingState_OneShotShelve = 20100u;

	public const uint CertificateGroupType_TrustListOutOfDate_Disable = 20176u;

	public const uint CertificateGroupType_TrustListOutOfDate_Enable = 20177u;

	public const uint CertificateGroupType_TrustListOutOfDate_AddComment = 20178u;

	public const uint CertificateGroupType_TrustListOutOfDate_Acknowledge = 20198u;

	public const uint CertificateGroupType_TrustListOutOfDate_ShelvingState_TimedShelve = 20245u;

	public const uint CertificateGroupType_TrustListOutOfDate_ShelvingState_Unshelve = 20247u;

	public const uint CertificateGroupType_TrustListOutOfDate_ShelvingState_OneShotShelve = 20248u;

	public const uint CertificateGroupType_GetRejectedList = 23526u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Open = 13821u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Close = 13824u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Read = 13826u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustList_Write = 13829u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustList_GetPosition = 13831u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustList_SetPosition = 13834u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustList_OpenWithMasks = 13837u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Disable = 20324u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Enable = 20325u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_AddComment = 20326u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_Acknowledge = 20346u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ShelvingState_TimedShelve = 20393u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ShelvingState_Unshelve = 20395u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_CertificateExpired_ShelvingState_OneShotShelve = 20396u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Disable = 20474u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Enable = 20475u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_AddComment = 20476u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_Acknowledge = 20496u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_TimedShelve = 20543u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_Unshelve = 20545u;

	public const uint CertificateGroupFolderType_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_OneShotShelve = 20546u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Open = 13855u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Close = 13858u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Read = 13860u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustList_Write = 13863u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustList_GetPosition = 13865u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustList_SetPosition = 13868u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustList_OpenWithMasks = 13871u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Disable = 20622u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Enable = 20623u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_AddComment = 20624u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_Acknowledge = 20644u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ShelvingState_TimedShelve = 20691u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ShelvingState_Unshelve = 20693u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_CertificateExpired_ShelvingState_OneShotShelve = 20694u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Disable = 20770u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Enable = 20771u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_AddComment = 20772u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_Acknowledge = 20792u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_TimedShelve = 20839u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_Unshelve = 20841u;

	public const uint CertificateGroupFolderType_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_OneShotShelve = 20842u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Open = 13889u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Close = 13892u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Read = 13894u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_Write = 13897u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_GetPosition = 13899u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_SetPosition = 13902u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustList_OpenWithMasks = 13905u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Disable = 20918u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Enable = 20919u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_AddComment = 20920u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_Acknowledge = 20940u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ShelvingState_TimedShelve = 20987u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ShelvingState_Unshelve = 20989u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_CertificateExpired_ShelvingState_OneShotShelve = 20990u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Disable = 21269u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Enable = 21270u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_AddComment = 21271u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_Acknowledge = 21291u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_TimedShelve = 21338u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_Unshelve = 21340u;

	public const uint CertificateGroupFolderType_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_OneShotShelve = 21341u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Open = 13923u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Close = 13926u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Read = 13928u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_Write = 13931u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_GetPosition = 13933u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_SetPosition = 13936u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustList_OpenWithMasks = 13939u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Disable = 21417u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Enable = 21418u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_AddComment = 21419u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_Acknowledge = 21439u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ShelvingState_TimedShelve = 21486u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ShelvingState_Unshelve = 21488u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_CertificateExpired_ShelvingState_OneShotShelve = 21489u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Disable = 21565u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Enable = 21566u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_AddComment = 21567u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_Acknowledge = 21587u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ShelvingState_TimedShelve = 21634u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ShelvingState_Unshelve = 21636u;

	public const uint CertificateGroupFolderType_AdditionalGroup_Placeholder_TrustListOutOfDate_ShelvingState_OneShotShelve = 21637u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Open = 13958u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Close = 13961u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Read = 13963u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_Write = 13966u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition = 13968u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition = 13971u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks = 13974u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Disable = 21713u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Enable = 21714u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_AddComment = 21715u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Acknowledge = 21735u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_TimedShelve = 21782u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_Unshelve = 21784u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_OneShotShelve = 21785u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Disable = 21861u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Enable = 21862u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_AddComment = 21863u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Acknowledge = 21883u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_TimedShelve = 21930u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_Unshelve = 21932u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_OneShotShelve = 21933u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Open = 13992u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Close = 13995u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Read = 13997u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_Write = 14000u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition = 14002u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition = 14005u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks = 14008u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Disable = 22009u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Enable = 22010u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_AddComment = 22011u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Acknowledge = 22031u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_TimedShelve = 22078u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_Unshelve = 22080u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_OneShotShelve = 22081u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Disable = 22157u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Enable = 22158u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_AddComment = 22159u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Acknowledge = 22179u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_TimedShelve = 22226u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_Unshelve = 22228u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_OneShotShelve = 22229u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open = 14026u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close = 14029u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read = 14031u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write = 14034u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition = 14036u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition = 14039u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks = 14042u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Disable = 22305u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Enable = 22306u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_AddComment = 22307u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Acknowledge = 22327u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_TimedShelve = 22374u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_Unshelve = 22376u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_OneShotShelve = 22377u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Disable = 22453u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Enable = 22454u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_AddComment = 22455u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Acknowledge = 22475u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_TimedShelve = 22522u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_Unshelve = 22524u;

	public const uint ServerConfigurationType_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_OneShotShelve = 22525u;

	public const uint ServerConfigurationType_UpdateCertificate = 12616u;

	public const uint ServerConfigurationType_ApplyChanges = 12734u;

	public const uint ServerConfigurationType_CreateSigningRequest = 12731u;

	public const uint ServerConfigurationType_GetRejectedList = 12775u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Open = 12647u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Close = 12650u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Read = 12652u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_Write = 12655u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition = 12657u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition = 12660u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks = 12663u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate = 12666u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate = 12668u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate = 12670u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Disable = 22601u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Enable = 22602u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_AddComment = 22603u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_Acknowledge = 22623u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_TimedShelve = 22670u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_Unshelve = 22672u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_CertificateExpired_ShelvingState_OneShotShelve = 22673u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Disable = 22749u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Enable = 22750u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_AddComment = 22751u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_Acknowledge = 22771u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_TimedShelve = 22818u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_Unshelve = 22820u;

	public const uint ServerConfiguration_CertificateGroups_DefaultApplicationGroup_TrustListOutOfDate_ShelvingState_OneShotShelve = 22821u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Open = 14095u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Close = 14098u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Read = 14100u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_Write = 14103u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition = 14105u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition = 14108u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks = 14111u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate = 14114u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate = 14117u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate = 14119u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Disable = 22897u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Enable = 22898u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_AddComment = 22899u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_Acknowledge = 22919u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_TimedShelve = 22966u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_Unshelve = 22968u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_CertificateExpired_ShelvingState_OneShotShelve = 22969u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Disable = 23045u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Enable = 23046u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_AddComment = 23047u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_Acknowledge = 23067u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_TimedShelve = 23114u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_Unshelve = 23116u;

	public const uint ServerConfiguration_CertificateGroups_DefaultHttpsGroup_TrustListOutOfDate_ShelvingState_OneShotShelve = 23117u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Open = 14129u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Close = 14132u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Read = 14134u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_Write = 14137u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition = 14139u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition = 14142u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks = 14145u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate = 14148u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate = 14151u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate = 14153u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Disable = 23193u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Enable = 23194u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_AddComment = 23195u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_Acknowledge = 23215u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_TimedShelve = 23262u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_Unshelve = 23264u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_CertificateExpired_ShelvingState_OneShotShelve = 23265u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Disable = 23341u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Enable = 23342u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_AddComment = 23343u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_Acknowledge = 23363u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_TimedShelve = 23410u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_Unshelve = 23412u;

	public const uint ServerConfiguration_CertificateGroups_DefaultUserTokenGroup_TrustListOutOfDate_ShelvingState_OneShotShelve = 23413u;

	public const uint ServerConfiguration_UpdateCertificate = 13737u;

	public const uint ServerConfiguration_ApplyChanges = 12740u;

	public const uint ServerConfiguration_CreateSigningRequest = 12737u;

	public const uint ServerConfiguration_GetRejectedList = 12777u;

	public const uint KeyCredentialConfigurationFolderType_CreateCredential = 17522u;

	public const uint KeyCredentialConfigurationType_GetEncryptingKey = 17534u;

	public const uint KeyCredentialConfigurationType_UpdateCredential = 18006u;

	public const uint KeyCredentialConfigurationType_DeleteCredential = 18008u;

	public const uint PubSubKeyServiceType_GetSecurityKeys = 15907u;

	public const uint PubSubKeyServiceType_GetSecurityGroup = 15910u;

	public const uint PubSubKeyServiceType_SecurityGroups_AddSecurityGroup = 15914u;

	public const uint PubSubKeyServiceType_SecurityGroups_RemoveSecurityGroup = 15917u;

	public const uint SecurityGroupFolderType_SecurityGroupFolderName_Placeholder_AddSecurityGroup = 15454u;

	public const uint SecurityGroupFolderType_SecurityGroupFolderName_Placeholder_RemoveSecurityGroup = 15457u;

	public const uint SecurityGroupFolderType_AddSecurityGroup = 15461u;

	public const uint SecurityGroupFolderType_RemoveSecurityGroup = 15464u;

	public const uint PublishSubscribeType_SecurityGroups_AddSecurityGroup = 15435u;

	public const uint PublishSubscribeType_SecurityGroups_RemoveSecurityGroup = 15438u;

	public const uint PublishSubscribeType_ConnectionName_Placeholder_Diagnostics_Reset = 18679u;

	public const uint PublishSubscribeType_SetSecurityKeys = 17296u;

	public const uint PublishSubscribeType_AddConnection = 16598u;

	public const uint PublishSubscribeType_RemoveConnection = 14432u;

	public const uint PublishSubscribeType_Diagnostics_Reset = 18727u;

	public const uint PublishSubscribe_GetSecurityKeys = 15215u;

	public const uint PublishSubscribe_GetSecurityGroup = 15440u;

	public const uint PublishSubscribe_SecurityGroups_AddSecurityGroup = 15444u;

	public const uint PublishSubscribe_SecurityGroups_RemoveSecurityGroup = 15447u;

	public const uint PublishSubscribe_ConnectionName_Placeholder_Diagnostics_Reset = 16076u;

	public const uint PublishSubscribe_AddConnection = 17366u;

	public const uint PublishSubscribe_RemoveConnection = 17369u;

	public const uint PublishSubscribe_Diagnostics_Reset = 17421u;

	public const uint PublishedDataSetType_DataSetWriterName_Placeholder_Diagnostics_Reset = 18883u;

	public const uint PublishedDataSetType_ExtensionFields_AddExtensionField = 15482u;

	public const uint PublishedDataSetType_ExtensionFields_RemoveExtensionField = 15485u;

	public const uint ExtensionFieldsType_AddExtensionField = 15491u;

	public const uint ExtensionFieldsType_RemoveExtensionField = 15494u;

	public const uint PublishedDataItemsType_DataSetWriterName_Placeholder_Diagnostics_Reset = 18942u;

	public const uint PublishedDataItemsType_ExtensionFields_AddExtensionField = 15504u;

	public const uint PublishedDataItemsType_ExtensionFields_RemoveExtensionField = 15507u;

	public const uint PublishedDataItemsType_AddVariables = 14555u;

	public const uint PublishedDataItemsType_RemoveVariables = 14558u;

	public const uint PublishedEventsType_DataSetWriterName_Placeholder_Diagnostics_Reset = 19001u;

	public const uint PublishedEventsType_ExtensionFields_AddExtensionField = 15512u;

	public const uint PublishedEventsType_ExtensionFields_RemoveExtensionField = 15515u;

	public const uint PublishedEventsType_ModifyFieldSelection = 15052u;

	public const uint DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedDataItems = 14479u;

	public const uint DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedEvents = 14482u;

	public const uint DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedDataItemsTemplate = 16842u;

	public const uint DataSetFolderType_DataSetFolderName_Placeholder_AddPublishedEventsTemplate = 16881u;

	public const uint DataSetFolderType_DataSetFolderName_Placeholder_RemovePublishedDataSet = 14485u;

	public const uint DataSetFolderType_DataSetFolderName_Placeholder_AddDataSetFolder = 16884u;

	public const uint DataSetFolderType_DataSetFolderName_Placeholder_RemoveDataSetFolder = 16923u;

	public const uint DataSetFolderType_PublishedDataSetName_Placeholder_ExtensionFields_AddExtensionField = 15474u;

	public const uint DataSetFolderType_PublishedDataSetName_Placeholder_ExtensionFields_RemoveExtensionField = 15477u;

	public const uint DataSetFolderType_AddPublishedDataItems = 14493u;

	public const uint DataSetFolderType_AddPublishedEvents = 14496u;

	public const uint DataSetFolderType_AddPublishedDataItemsTemplate = 16935u;

	public const uint DataSetFolderType_AddPublishedEventsTemplate = 16960u;

	public const uint DataSetFolderType_RemovePublishedDataSet = 14499u;

	public const uint DataSetFolderType_AddDataSetFolder = 16994u;

	public const uint DataSetFolderType_RemoveDataSetFolder = 16997u;

	public const uint PubSubConnectionType_WriterGroupName_Placeholder_Diagnostics_Reset = 19119u;

	public const uint PubSubConnectionType_ReaderGroupName_Placeholder_Diagnostics_Reset = 19188u;

	public const uint PubSubConnectionType_Diagnostics_Reset = 19253u;

	public const uint PubSubConnectionType_AddWriterGroup = 17427u;

	public const uint PubSubConnectionType_AddReaderGroup = 17465u;

	public const uint PubSubConnectionType_RemoveGroup = 14225u;

	public const uint WriterGroupType_DataSetWriterName_Placeholder_Diagnostics_Reset = 17765u;

	public const uint WriterGroupType_Diagnostics_Reset = 17824u;

	public const uint WriterGroupType_AddDataSetWriter = 17969u;

	public const uint WriterGroupType_RemoveDataSetWriter = 17992u;

	public const uint ReaderGroupType_DataSetReaderName_Placeholder_Diagnostics_Reset = 18104u;

	public const uint ReaderGroupType_Diagnostics_Reset = 21027u;

	public const uint ReaderGroupType_AddDataSetReader = 21082u;

	public const uint ReaderGroupType_RemoveDataSetReader = 21085u;

	public const uint DataSetWriterType_Diagnostics_Reset = 19562u;

	public const uint DataSetReaderType_Diagnostics_Reset = 19621u;

	public const uint DataSetReaderType_CreateTargetVariables = 17386u;

	public const uint DataSetReaderType_CreateDataSetMirror = 17389u;

	public const uint TargetVariablesType_AddTargetVariables = 15115u;

	public const uint TargetVariablesType_RemoveTargetVariables = 15118u;

	public const uint PubSubStatusType_Enable = 14645u;

	public const uint PubSubStatusType_Disable = 14646u;

	public const uint PubSubDiagnosticsType_Reset = 19689u;

	public const uint AliasNameCategoryType_SubAliasNameCategories_Placeholder_FindAlias = 23459u;

	public const uint AliasNameCategoryType_FindAlias = 23462u;

	public const uint Aliases_SubAliasNameCategories_Placeholder_FindAlias = 23473u;

	public const uint Aliases_FindAlias = 23476u;

	public const uint TagVariables_SubAliasNameCategories_Placeholder_FindAlias = 23482u;

	public const uint TagVariables_FindAlias = 23485u;

	public const uint Topics_SubAliasNameCategories_Placeholder_FindAlias = 23491u;

	public const uint Topics_FindAlias = 23494u;
}
