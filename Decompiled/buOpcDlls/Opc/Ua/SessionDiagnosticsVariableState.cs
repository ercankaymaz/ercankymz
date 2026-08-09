using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionDiagnosticsVariableState : BaseDataVariableState<SessionDiagnosticsDataType>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAJgAAAFNlc3Npb25EaWFnbm9zdGljc1ZhcmlhYmxlVHlwZUluc3RhbmNlAQCVCAEAlQiVCAAAAQBhA/////8BAf////8rAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAJYIAC8AP5YIAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABTZXNzaW9uTmFtZQEAlwgALwA/lwgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudERlc2NyaXB0aW9uAQCYCAAvAD+YCAAAAQA0Af////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXJ2ZXJVcmkBAJkIAC8AP5kIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmRwb2ludFVybAEAmggALwA/mggAAAAM/////wEB/////wAAAAAXYIkKAgAAAAAACQAAAExvY2FsZUlkcwEAmwgALwA/mwgAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABQAAABBY3R1YWxTZXNzaW9uVGltZW91dAEAnAgALwA/nAgAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAWAAAATWF4UmVzcG9uc2VNZXNzYWdlU2l6ZQEA6gsALwA/6gsAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAENsaWVudENvbm5lY3Rpb25UaW1lAQCdCAAvAD+dCAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDbGllbnRMYXN0Q29udGFjdFRpbWUBAJ4IAC8AP54IAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAEN1cnJlbnRTdWJzY3JpcHRpb25zQ291bnQBAJ8IAC8AP58IAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABDdXJyZW50TW9uaXRvcmVkSXRlbXNDb3VudAEAoAgALwA/oAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHQAAAEN1cnJlbnRQdWJsaXNoUmVxdWVzdHNJblF1ZXVlAQChCAAvAD+hCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAARAAAAVG90YWxSZXF1ZXN0Q291bnQBAMQiAC8AP8QiAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFVuYXV0aG9yaXplZFJlcXVlc3RDb3VudAEAdC4ALwA/dC4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFJlYWRDb3VudAEAqQgALwA/qQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAASGlzdG9yeVJlYWRDb3VudAEAqggALwA/qggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAV3JpdGVDb3VudAEAqwgALwA/qwgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAASGlzdG9yeVVwZGF0ZUNvdW50AQCsCAAvAD+sCAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABDYWxsQ291bnQBAK0IAC8AP60IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAENyZWF0ZU1vbml0b3JlZEl0ZW1zQ291bnQBAK4IAC8AP64IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE1vZGlmeU1vbml0b3JlZEl0ZW1zQ291bnQBAK8IAC8AP68IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAFNldE1vbml0b3JpbmdNb2RlQ291bnQBALAIAC8AP7AIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAFNldFRyaWdnZXJpbmdDb3VudAEAsQgALwA/sQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAZAAAARGVsZXRlTW9uaXRvcmVkSXRlbXNDb3VudAEAsggALwA/sggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAQ3JlYXRlU3Vic2NyaXB0aW9uQ291bnQBALMIAC8AP7MIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAE1vZGlmeVN1YnNjcmlwdGlvbkNvdW50AQC0CAAvAD+0CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABYAAABTZXRQdWJsaXNoaW5nTW9kZUNvdW50AQC1CAAvAD+1CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABQdWJsaXNoQ291bnQBALYIAC8AP7YIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFJlcHVibGlzaENvdW50AQC3CAAvAD+3CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABUcmFuc2ZlclN1YnNjcmlwdGlvbnNDb3VudAEAuAgALwA/uAgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAYAAAARGVsZXRlU3Vic2NyaXB0aW9uc0NvdW50AQC5CAAvAD+5CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABBZGROb2Rlc0NvdW50AQC6CAAvAD+6CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABIAAABBZGRSZWZlcmVuY2VzQ291bnQBALsIAC8AP7sIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERlbGV0ZU5vZGVzQ291bnQBALwIAC8AP7wIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAERlbGV0ZVJlZmVyZW5jZXNDb3VudAEAvQgALwA/vQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAALAAAAQnJvd3NlQ291bnQBAL4IAC8AP74IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEJyb3dzZU5leHRDb3VudAEAvwgALwA/vwgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAiAAAAVHJhbnNsYXRlQnJvd3NlUGF0aHNUb05vZGVJZHNDb3VudAEAwAgALwA/wAgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUXVlcnlGaXJzdENvdW50AQDBCAAvAD/BCAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABRdWVyeU5leHRDb3VudAEAwggALwA/wggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUmVnaXN0ZXJOb2Rlc0NvdW50AQCqCgAvAD+qCgAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABVbnJlZ2lzdGVyTm9kZXNDb3VudAEAqwoALwA/qwoAAAEAZwP/////AQH/////AAAAAA==";

	private BaseDataVariableState<NodeId> m_sessionId;

	private BaseDataVariableState<string> m_sessionName;

	private BaseDataVariableState<ApplicationDescription> m_clientDescription;

	private BaseDataVariableState<string> m_serverUri;

	private BaseDataVariableState<string> m_endpointUrl;

	private BaseDataVariableState<string[]> m_localeIds;

	private BaseDataVariableState<double> m_actualSessionTimeout;

	private BaseDataVariableState<uint> m_maxResponseMessageSize;

	private BaseDataVariableState<DateTime> m_clientConnectionTime;

	private BaseDataVariableState<DateTime> m_clientLastContactTime;

	private BaseDataVariableState<uint> m_currentSubscriptionsCount;

	private BaseDataVariableState<uint> m_currentMonitoredItemsCount;

	private BaseDataVariableState<uint> m_currentPublishRequestsInQueue;

	private BaseDataVariableState<ServiceCounterDataType> m_totalRequestCount;

	private BaseDataVariableState<uint> m_unauthorizedRequestCount;

	private BaseDataVariableState<ServiceCounterDataType> m_readCount;

	private BaseDataVariableState<ServiceCounterDataType> m_historyReadCount;

	private BaseDataVariableState<ServiceCounterDataType> m_writeCount;

	private BaseDataVariableState<ServiceCounterDataType> m_historyUpdateCount;

	private BaseDataVariableState<ServiceCounterDataType> m_callCount;

	private BaseDataVariableState<ServiceCounterDataType> m_createMonitoredItemsCount;

	private BaseDataVariableState<ServiceCounterDataType> m_modifyMonitoredItemsCount;

	private BaseDataVariableState<ServiceCounterDataType> m_setMonitoringModeCount;

	private BaseDataVariableState<ServiceCounterDataType> m_setTriggeringCount;

	private BaseDataVariableState<ServiceCounterDataType> m_deleteMonitoredItemsCount;

	private BaseDataVariableState<ServiceCounterDataType> m_createSubscriptionCount;

	private BaseDataVariableState<ServiceCounterDataType> m_modifySubscriptionCount;

	private BaseDataVariableState<ServiceCounterDataType> m_setPublishingModeCount;

	private BaseDataVariableState<ServiceCounterDataType> m_publishCount;

	private BaseDataVariableState<ServiceCounterDataType> m_republishCount;

	private BaseDataVariableState<ServiceCounterDataType> m_transferSubscriptionsCount;

	private BaseDataVariableState<ServiceCounterDataType> m_deleteSubscriptionsCount;

	private BaseDataVariableState<ServiceCounterDataType> m_addNodesCount;

	private BaseDataVariableState<ServiceCounterDataType> m_addReferencesCount;

	private BaseDataVariableState<ServiceCounterDataType> m_deleteNodesCount;

	private BaseDataVariableState<ServiceCounterDataType> m_deleteReferencesCount;

	private BaseDataVariableState<ServiceCounterDataType> m_browseCount;

	private BaseDataVariableState<ServiceCounterDataType> m_browseNextCount;

	private BaseDataVariableState<ServiceCounterDataType> m_translateBrowsePathsToNodeIdsCount;

	private BaseDataVariableState<ServiceCounterDataType> m_queryFirstCount;

	private BaseDataVariableState<ServiceCounterDataType> m_queryNextCount;

	private BaseDataVariableState<ServiceCounterDataType> m_registerNodesCount;

	private BaseDataVariableState<ServiceCounterDataType> m_unregisterNodesCount;

	public BaseDataVariableState<NodeId> SessionId
	{
		get
		{
			return m_sessionId;
		}
		set
		{
			if (m_sessionId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sessionId = value;
		}
	}

	public BaseDataVariableState<string> SessionName
	{
		get
		{
			return m_sessionName;
		}
		set
		{
			if (m_sessionName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sessionName = value;
		}
	}

	public BaseDataVariableState<ApplicationDescription> ClientDescription
	{
		get
		{
			return m_clientDescription;
		}
		set
		{
			if (m_clientDescription != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientDescription = value;
		}
	}

	public BaseDataVariableState<string> ServerUri
	{
		get
		{
			return m_serverUri;
		}
		set
		{
			if (m_serverUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverUri = value;
		}
	}

	public BaseDataVariableState<string> EndpointUrl
	{
		get
		{
			return m_endpointUrl;
		}
		set
		{
			if (m_endpointUrl != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_endpointUrl = value;
		}
	}

	public BaseDataVariableState<string[]> LocaleIds
	{
		get
		{
			return m_localeIds;
		}
		set
		{
			if (m_localeIds != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_localeIds = value;
		}
	}

	public BaseDataVariableState<double> ActualSessionTimeout
	{
		get
		{
			return m_actualSessionTimeout;
		}
		set
		{
			if (m_actualSessionTimeout != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_actualSessionTimeout = value;
		}
	}

	public BaseDataVariableState<uint> MaxResponseMessageSize
	{
		get
		{
			return m_maxResponseMessageSize;
		}
		set
		{
			if (m_maxResponseMessageSize != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxResponseMessageSize = value;
		}
	}

	public BaseDataVariableState<DateTime> ClientConnectionTime
	{
		get
		{
			return m_clientConnectionTime;
		}
		set
		{
			if (m_clientConnectionTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientConnectionTime = value;
		}
	}

	public BaseDataVariableState<DateTime> ClientLastContactTime
	{
		get
		{
			return m_clientLastContactTime;
		}
		set
		{
			if (m_clientLastContactTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientLastContactTime = value;
		}
	}

	public BaseDataVariableState<uint> CurrentSubscriptionsCount
	{
		get
		{
			return m_currentSubscriptionsCount;
		}
		set
		{
			if (m_currentSubscriptionsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentSubscriptionsCount = value;
		}
	}

	public BaseDataVariableState<uint> CurrentMonitoredItemsCount
	{
		get
		{
			return m_currentMonitoredItemsCount;
		}
		set
		{
			if (m_currentMonitoredItemsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentMonitoredItemsCount = value;
		}
	}

	public BaseDataVariableState<uint> CurrentPublishRequestsInQueue
	{
		get
		{
			return m_currentPublishRequestsInQueue;
		}
		set
		{
			if (m_currentPublishRequestsInQueue != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentPublishRequestsInQueue = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> TotalRequestCount
	{
		get
		{
			return m_totalRequestCount;
		}
		set
		{
			if (m_totalRequestCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_totalRequestCount = value;
		}
	}

	public BaseDataVariableState<uint> UnauthorizedRequestCount
	{
		get
		{
			return m_unauthorizedRequestCount;
		}
		set
		{
			if (m_unauthorizedRequestCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_unauthorizedRequestCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> ReadCount
	{
		get
		{
			return m_readCount;
		}
		set
		{
			if (m_readCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_readCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> HistoryReadCount
	{
		get
		{
			return m_historyReadCount;
		}
		set
		{
			if (m_historyReadCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_historyReadCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> WriteCount
	{
		get
		{
			return m_writeCount;
		}
		set
		{
			if (m_writeCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_writeCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> HistoryUpdateCount
	{
		get
		{
			return m_historyUpdateCount;
		}
		set
		{
			if (m_historyUpdateCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_historyUpdateCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> CallCount
	{
		get
		{
			return m_callCount;
		}
		set
		{
			if (m_callCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_callCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> CreateMonitoredItemsCount
	{
		get
		{
			return m_createMonitoredItemsCount;
		}
		set
		{
			if (m_createMonitoredItemsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createMonitoredItemsCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> ModifyMonitoredItemsCount
	{
		get
		{
			return m_modifyMonitoredItemsCount;
		}
		set
		{
			if (m_modifyMonitoredItemsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_modifyMonitoredItemsCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> SetMonitoringModeCount
	{
		get
		{
			return m_setMonitoringModeCount;
		}
		set
		{
			if (m_setMonitoringModeCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_setMonitoringModeCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> SetTriggeringCount
	{
		get
		{
			return m_setTriggeringCount;
		}
		set
		{
			if (m_setTriggeringCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_setTriggeringCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> DeleteMonitoredItemsCount
	{
		get
		{
			return m_deleteMonitoredItemsCount;
		}
		set
		{
			if (m_deleteMonitoredItemsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deleteMonitoredItemsCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> CreateSubscriptionCount
	{
		get
		{
			return m_createSubscriptionCount;
		}
		set
		{
			if (m_createSubscriptionCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createSubscriptionCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> ModifySubscriptionCount
	{
		get
		{
			return m_modifySubscriptionCount;
		}
		set
		{
			if (m_modifySubscriptionCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_modifySubscriptionCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> SetPublishingModeCount
	{
		get
		{
			return m_setPublishingModeCount;
		}
		set
		{
			if (m_setPublishingModeCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_setPublishingModeCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> PublishCount
	{
		get
		{
			return m_publishCount;
		}
		set
		{
			if (m_publishCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_publishCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> RepublishCount
	{
		get
		{
			return m_republishCount;
		}
		set
		{
			if (m_republishCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_republishCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> TransferSubscriptionsCount
	{
		get
		{
			return m_transferSubscriptionsCount;
		}
		set
		{
			if (m_transferSubscriptionsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transferSubscriptionsCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> DeleteSubscriptionsCount
	{
		get
		{
			return m_deleteSubscriptionsCount;
		}
		set
		{
			if (m_deleteSubscriptionsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deleteSubscriptionsCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> AddNodesCount
	{
		get
		{
			return m_addNodesCount;
		}
		set
		{
			if (m_addNodesCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addNodesCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> AddReferencesCount
	{
		get
		{
			return m_addReferencesCount;
		}
		set
		{
			if (m_addReferencesCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addReferencesCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> DeleteNodesCount
	{
		get
		{
			return m_deleteNodesCount;
		}
		set
		{
			if (m_deleteNodesCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deleteNodesCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> DeleteReferencesCount
	{
		get
		{
			return m_deleteReferencesCount;
		}
		set
		{
			if (m_deleteReferencesCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deleteReferencesCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> BrowseCount
	{
		get
		{
			return m_browseCount;
		}
		set
		{
			if (m_browseCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_browseCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> BrowseNextCount
	{
		get
		{
			return m_browseNextCount;
		}
		set
		{
			if (m_browseNextCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_browseNextCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> TranslateBrowsePathsToNodeIdsCount
	{
		get
		{
			return m_translateBrowsePathsToNodeIdsCount;
		}
		set
		{
			if (m_translateBrowsePathsToNodeIdsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_translateBrowsePathsToNodeIdsCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> QueryFirstCount
	{
		get
		{
			return m_queryFirstCount;
		}
		set
		{
			if (m_queryFirstCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_queryFirstCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> QueryNextCount
	{
		get
		{
			return m_queryNextCount;
		}
		set
		{
			if (m_queryNextCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_queryNextCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> RegisterNodesCount
	{
		get
		{
			return m_registerNodesCount;
		}
		set
		{
			if (m_registerNodesCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_registerNodesCount = value;
		}
	}

	public BaseDataVariableState<ServiceCounterDataType> UnregisterNodesCount
	{
		get
		{
			return m_unregisterNodesCount;
		}
		set
		{
			if (m_unregisterNodesCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_unregisterNodesCount = value;
		}
	}

	public SessionDiagnosticsVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2197u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(865u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAJgAAAFNlc3Npb25EaWFnbm9zdGljc1ZhcmlhYmxlVHlwZUluc3RhbmNlAQCVCAEAlQiVCAAAAQBhA/////8BAf////8rAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAJYIAC8AP5YIAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABTZXNzaW9uTmFtZQEAlwgALwA/lwgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudERlc2NyaXB0aW9uAQCYCAAvAD+YCAAAAQA0Af////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXJ2ZXJVcmkBAJkIAC8AP5kIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmRwb2ludFVybAEAmggALwA/mggAAAAM/////wEB/////wAAAAAXYIkKAgAAAAAACQAAAExvY2FsZUlkcwEAmwgALwA/mwgAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABQAAABBY3R1YWxTZXNzaW9uVGltZW91dAEAnAgALwA/nAgAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAWAAAATWF4UmVzcG9uc2VNZXNzYWdlU2l6ZQEA6gsALwA/6gsAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAENsaWVudENvbm5lY3Rpb25UaW1lAQCdCAAvAD+dCAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDbGllbnRMYXN0Q29udGFjdFRpbWUBAJ4IAC8AP54IAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAEN1cnJlbnRTdWJzY3JpcHRpb25zQ291bnQBAJ8IAC8AP58IAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABDdXJyZW50TW9uaXRvcmVkSXRlbXNDb3VudAEAoAgALwA/oAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHQAAAEN1cnJlbnRQdWJsaXNoUmVxdWVzdHNJblF1ZXVlAQChCAAvAD+hCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAARAAAAVG90YWxSZXF1ZXN0Q291bnQBAMQiAC8AP8QiAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFVuYXV0aG9yaXplZFJlcXVlc3RDb3VudAEAdC4ALwA/dC4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFJlYWRDb3VudAEAqQgALwA/qQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAASGlzdG9yeVJlYWRDb3VudAEAqggALwA/qggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAV3JpdGVDb3VudAEAqwgALwA/qwgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAASGlzdG9yeVVwZGF0ZUNvdW50AQCsCAAvAD+sCAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABDYWxsQ291bnQBAK0IAC8AP60IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAENyZWF0ZU1vbml0b3JlZEl0ZW1zQ291bnQBAK4IAC8AP64IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE1vZGlmeU1vbml0b3JlZEl0ZW1zQ291bnQBAK8IAC8AP68IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAFNldE1vbml0b3JpbmdNb2RlQ291bnQBALAIAC8AP7AIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAFNldFRyaWdnZXJpbmdDb3VudAEAsQgALwA/sQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAZAAAARGVsZXRlTW9uaXRvcmVkSXRlbXNDb3VudAEAsggALwA/sggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAQ3JlYXRlU3Vic2NyaXB0aW9uQ291bnQBALMIAC8AP7MIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAE1vZGlmeVN1YnNjcmlwdGlvbkNvdW50AQC0CAAvAD+0CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABYAAABTZXRQdWJsaXNoaW5nTW9kZUNvdW50AQC1CAAvAD+1CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABQdWJsaXNoQ291bnQBALYIAC8AP7YIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFJlcHVibGlzaENvdW50AQC3CAAvAD+3CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABUcmFuc2ZlclN1YnNjcmlwdGlvbnNDb3VudAEAuAgALwA/uAgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAYAAAARGVsZXRlU3Vic2NyaXB0aW9uc0NvdW50AQC5CAAvAD+5CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABBZGROb2Rlc0NvdW50AQC6CAAvAD+6CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABIAAABBZGRSZWZlcmVuY2VzQ291bnQBALsIAC8AP7sIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERlbGV0ZU5vZGVzQ291bnQBALwIAC8AP7wIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAERlbGV0ZVJlZmVyZW5jZXNDb3VudAEAvQgALwA/vQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAALAAAAQnJvd3NlQ291bnQBAL4IAC8AP74IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEJyb3dzZU5leHRDb3VudAEAvwgALwA/vwgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAiAAAAVHJhbnNsYXRlQnJvd3NlUGF0aHNUb05vZGVJZHNDb3VudAEAwAgALwA/wAgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUXVlcnlGaXJzdENvdW50AQDBCAAvAD/BCAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABRdWVyeU5leHRDb3VudAEAwggALwA/wggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUmVnaXN0ZXJOb2Rlc0NvdW50AQCqCgAvAD+qCgAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABVbnJlZ2lzdGVyTm9kZXNDb3VudAEAqwoALwA/qwoAAAEAZwP/////AQH/////AAAAAA==");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_sessionId != null)
		{
			children.Add(m_sessionId);
		}
		if (m_sessionName != null)
		{
			children.Add(m_sessionName);
		}
		if (m_clientDescription != null)
		{
			children.Add(m_clientDescription);
		}
		if (m_serverUri != null)
		{
			children.Add(m_serverUri);
		}
		if (m_endpointUrl != null)
		{
			children.Add(m_endpointUrl);
		}
		if (m_localeIds != null)
		{
			children.Add(m_localeIds);
		}
		if (m_actualSessionTimeout != null)
		{
			children.Add(m_actualSessionTimeout);
		}
		if (m_maxResponseMessageSize != null)
		{
			children.Add(m_maxResponseMessageSize);
		}
		if (m_clientConnectionTime != null)
		{
			children.Add(m_clientConnectionTime);
		}
		if (m_clientLastContactTime != null)
		{
			children.Add(m_clientLastContactTime);
		}
		if (m_currentSubscriptionsCount != null)
		{
			children.Add(m_currentSubscriptionsCount);
		}
		if (m_currentMonitoredItemsCount != null)
		{
			children.Add(m_currentMonitoredItemsCount);
		}
		if (m_currentPublishRequestsInQueue != null)
		{
			children.Add(m_currentPublishRequestsInQueue);
		}
		if (m_totalRequestCount != null)
		{
			children.Add(m_totalRequestCount);
		}
		if (m_unauthorizedRequestCount != null)
		{
			children.Add(m_unauthorizedRequestCount);
		}
		if (m_readCount != null)
		{
			children.Add(m_readCount);
		}
		if (m_historyReadCount != null)
		{
			children.Add(m_historyReadCount);
		}
		if (m_writeCount != null)
		{
			children.Add(m_writeCount);
		}
		if (m_historyUpdateCount != null)
		{
			children.Add(m_historyUpdateCount);
		}
		if (m_callCount != null)
		{
			children.Add(m_callCount);
		}
		if (m_createMonitoredItemsCount != null)
		{
			children.Add(m_createMonitoredItemsCount);
		}
		if (m_modifyMonitoredItemsCount != null)
		{
			children.Add(m_modifyMonitoredItemsCount);
		}
		if (m_setMonitoringModeCount != null)
		{
			children.Add(m_setMonitoringModeCount);
		}
		if (m_setTriggeringCount != null)
		{
			children.Add(m_setTriggeringCount);
		}
		if (m_deleteMonitoredItemsCount != null)
		{
			children.Add(m_deleteMonitoredItemsCount);
		}
		if (m_createSubscriptionCount != null)
		{
			children.Add(m_createSubscriptionCount);
		}
		if (m_modifySubscriptionCount != null)
		{
			children.Add(m_modifySubscriptionCount);
		}
		if (m_setPublishingModeCount != null)
		{
			children.Add(m_setPublishingModeCount);
		}
		if (m_publishCount != null)
		{
			children.Add(m_publishCount);
		}
		if (m_republishCount != null)
		{
			children.Add(m_republishCount);
		}
		if (m_transferSubscriptionsCount != null)
		{
			children.Add(m_transferSubscriptionsCount);
		}
		if (m_deleteSubscriptionsCount != null)
		{
			children.Add(m_deleteSubscriptionsCount);
		}
		if (m_addNodesCount != null)
		{
			children.Add(m_addNodesCount);
		}
		if (m_addReferencesCount != null)
		{
			children.Add(m_addReferencesCount);
		}
		if (m_deleteNodesCount != null)
		{
			children.Add(m_deleteNodesCount);
		}
		if (m_deleteReferencesCount != null)
		{
			children.Add(m_deleteReferencesCount);
		}
		if (m_browseCount != null)
		{
			children.Add(m_browseCount);
		}
		if (m_browseNextCount != null)
		{
			children.Add(m_browseNextCount);
		}
		if (m_translateBrowsePathsToNodeIdsCount != null)
		{
			children.Add(m_translateBrowsePathsToNodeIdsCount);
		}
		if (m_queryFirstCount != null)
		{
			children.Add(m_queryFirstCount);
		}
		if (m_queryNextCount != null)
		{
			children.Add(m_queryNextCount);
		}
		if (m_registerNodesCount != null)
		{
			children.Add(m_registerNodesCount);
		}
		if (m_unregisterNodesCount != null)
		{
			children.Add(m_unregisterNodesCount);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		switch (browseName.Name)
		{
		case "SessionId":
			if (createOrReplace && SessionId == null)
			{
				if (replacement == null)
				{
					SessionId = new BaseDataVariableState<NodeId>(this);
				}
				else
				{
					SessionId = (BaseDataVariableState<NodeId>)replacement;
				}
			}
			baseInstanceState = SessionId;
			break;
		case "SessionName":
			if (createOrReplace && SessionName == null)
			{
				if (replacement == null)
				{
					SessionName = new BaseDataVariableState<string>(this);
				}
				else
				{
					SessionName = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = SessionName;
			break;
		case "ClientDescription":
			if (createOrReplace && ClientDescription == null)
			{
				if (replacement == null)
				{
					ClientDescription = new BaseDataVariableState<ApplicationDescription>(this);
				}
				else
				{
					ClientDescription = (BaseDataVariableState<ApplicationDescription>)replacement;
				}
			}
			baseInstanceState = ClientDescription;
			break;
		case "ServerUri":
			if (createOrReplace && ServerUri == null)
			{
				if (replacement == null)
				{
					ServerUri = new BaseDataVariableState<string>(this);
				}
				else
				{
					ServerUri = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = ServerUri;
			break;
		case "EndpointUrl":
			if (createOrReplace && EndpointUrl == null)
			{
				if (replacement == null)
				{
					EndpointUrl = new BaseDataVariableState<string>(this);
				}
				else
				{
					EndpointUrl = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = EndpointUrl;
			break;
		case "LocaleIds":
			if (createOrReplace && LocaleIds == null)
			{
				if (replacement == null)
				{
					LocaleIds = new BaseDataVariableState<string[]>(this);
				}
				else
				{
					LocaleIds = (BaseDataVariableState<string[]>)replacement;
				}
			}
			baseInstanceState = LocaleIds;
			break;
		case "ActualSessionTimeout":
			if (createOrReplace && ActualSessionTimeout == null)
			{
				if (replacement == null)
				{
					ActualSessionTimeout = new BaseDataVariableState<double>(this);
				}
				else
				{
					ActualSessionTimeout = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = ActualSessionTimeout;
			break;
		case "MaxResponseMessageSize":
			if (createOrReplace && MaxResponseMessageSize == null)
			{
				if (replacement == null)
				{
					MaxResponseMessageSize = new BaseDataVariableState<uint>(this);
				}
				else
				{
					MaxResponseMessageSize = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = MaxResponseMessageSize;
			break;
		case "ClientConnectionTime":
			if (createOrReplace && ClientConnectionTime == null)
			{
				if (replacement == null)
				{
					ClientConnectionTime = new BaseDataVariableState<DateTime>(this);
				}
				else
				{
					ClientConnectionTime = (BaseDataVariableState<DateTime>)replacement;
				}
			}
			baseInstanceState = ClientConnectionTime;
			break;
		case "ClientLastContactTime":
			if (createOrReplace && ClientLastContactTime == null)
			{
				if (replacement == null)
				{
					ClientLastContactTime = new BaseDataVariableState<DateTime>(this);
				}
				else
				{
					ClientLastContactTime = (BaseDataVariableState<DateTime>)replacement;
				}
			}
			baseInstanceState = ClientLastContactTime;
			break;
		case "CurrentSubscriptionsCount":
			if (createOrReplace && CurrentSubscriptionsCount == null)
			{
				if (replacement == null)
				{
					CurrentSubscriptionsCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					CurrentSubscriptionsCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = CurrentSubscriptionsCount;
			break;
		case "CurrentMonitoredItemsCount":
			if (createOrReplace && CurrentMonitoredItemsCount == null)
			{
				if (replacement == null)
				{
					CurrentMonitoredItemsCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					CurrentMonitoredItemsCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = CurrentMonitoredItemsCount;
			break;
		case "CurrentPublishRequestsInQueue":
			if (createOrReplace && CurrentPublishRequestsInQueue == null)
			{
				if (replacement == null)
				{
					CurrentPublishRequestsInQueue = new BaseDataVariableState<uint>(this);
				}
				else
				{
					CurrentPublishRequestsInQueue = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = CurrentPublishRequestsInQueue;
			break;
		case "TotalRequestCount":
			if (createOrReplace && TotalRequestCount == null)
			{
				if (replacement == null)
				{
					TotalRequestCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					TotalRequestCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = TotalRequestCount;
			break;
		case "UnauthorizedRequestCount":
			if (createOrReplace && UnauthorizedRequestCount == null)
			{
				if (replacement == null)
				{
					UnauthorizedRequestCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					UnauthorizedRequestCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = UnauthorizedRequestCount;
			break;
		case "ReadCount":
			if (createOrReplace && ReadCount == null)
			{
				if (replacement == null)
				{
					ReadCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					ReadCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = ReadCount;
			break;
		case "HistoryReadCount":
			if (createOrReplace && HistoryReadCount == null)
			{
				if (replacement == null)
				{
					HistoryReadCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					HistoryReadCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = HistoryReadCount;
			break;
		case "WriteCount":
			if (createOrReplace && WriteCount == null)
			{
				if (replacement == null)
				{
					WriteCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					WriteCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = WriteCount;
			break;
		case "HistoryUpdateCount":
			if (createOrReplace && HistoryUpdateCount == null)
			{
				if (replacement == null)
				{
					HistoryUpdateCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					HistoryUpdateCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = HistoryUpdateCount;
			break;
		case "CallCount":
			if (createOrReplace && CallCount == null)
			{
				if (replacement == null)
				{
					CallCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					CallCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = CallCount;
			break;
		case "CreateMonitoredItemsCount":
			if (createOrReplace && CreateMonitoredItemsCount == null)
			{
				if (replacement == null)
				{
					CreateMonitoredItemsCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					CreateMonitoredItemsCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = CreateMonitoredItemsCount;
			break;
		case "ModifyMonitoredItemsCount":
			if (createOrReplace && ModifyMonitoredItemsCount == null)
			{
				if (replacement == null)
				{
					ModifyMonitoredItemsCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					ModifyMonitoredItemsCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = ModifyMonitoredItemsCount;
			break;
		case "SetMonitoringModeCount":
			if (createOrReplace && SetMonitoringModeCount == null)
			{
				if (replacement == null)
				{
					SetMonitoringModeCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					SetMonitoringModeCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = SetMonitoringModeCount;
			break;
		case "SetTriggeringCount":
			if (createOrReplace && SetTriggeringCount == null)
			{
				if (replacement == null)
				{
					SetTriggeringCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					SetTriggeringCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = SetTriggeringCount;
			break;
		case "DeleteMonitoredItemsCount":
			if (createOrReplace && DeleteMonitoredItemsCount == null)
			{
				if (replacement == null)
				{
					DeleteMonitoredItemsCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					DeleteMonitoredItemsCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = DeleteMonitoredItemsCount;
			break;
		case "CreateSubscriptionCount":
			if (createOrReplace && CreateSubscriptionCount == null)
			{
				if (replacement == null)
				{
					CreateSubscriptionCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					CreateSubscriptionCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = CreateSubscriptionCount;
			break;
		case "ModifySubscriptionCount":
			if (createOrReplace && ModifySubscriptionCount == null)
			{
				if (replacement == null)
				{
					ModifySubscriptionCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					ModifySubscriptionCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = ModifySubscriptionCount;
			break;
		case "SetPublishingModeCount":
			if (createOrReplace && SetPublishingModeCount == null)
			{
				if (replacement == null)
				{
					SetPublishingModeCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					SetPublishingModeCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = SetPublishingModeCount;
			break;
		case "PublishCount":
			if (createOrReplace && PublishCount == null)
			{
				if (replacement == null)
				{
					PublishCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					PublishCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = PublishCount;
			break;
		case "RepublishCount":
			if (createOrReplace && RepublishCount == null)
			{
				if (replacement == null)
				{
					RepublishCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					RepublishCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = RepublishCount;
			break;
		case "TransferSubscriptionsCount":
			if (createOrReplace && TransferSubscriptionsCount == null)
			{
				if (replacement == null)
				{
					TransferSubscriptionsCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					TransferSubscriptionsCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = TransferSubscriptionsCount;
			break;
		case "DeleteSubscriptionsCount":
			if (createOrReplace && DeleteSubscriptionsCount == null)
			{
				if (replacement == null)
				{
					DeleteSubscriptionsCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					DeleteSubscriptionsCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = DeleteSubscriptionsCount;
			break;
		case "AddNodesCount":
			if (createOrReplace && AddNodesCount == null)
			{
				if (replacement == null)
				{
					AddNodesCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					AddNodesCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = AddNodesCount;
			break;
		case "AddReferencesCount":
			if (createOrReplace && AddReferencesCount == null)
			{
				if (replacement == null)
				{
					AddReferencesCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					AddReferencesCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = AddReferencesCount;
			break;
		case "DeleteNodesCount":
			if (createOrReplace && DeleteNodesCount == null)
			{
				if (replacement == null)
				{
					DeleteNodesCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					DeleteNodesCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = DeleteNodesCount;
			break;
		case "DeleteReferencesCount":
			if (createOrReplace && DeleteReferencesCount == null)
			{
				if (replacement == null)
				{
					DeleteReferencesCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					DeleteReferencesCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = DeleteReferencesCount;
			break;
		case "BrowseCount":
			if (createOrReplace && BrowseCount == null)
			{
				if (replacement == null)
				{
					BrowseCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					BrowseCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = BrowseCount;
			break;
		case "BrowseNextCount":
			if (createOrReplace && BrowseNextCount == null)
			{
				if (replacement == null)
				{
					BrowseNextCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					BrowseNextCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = BrowseNextCount;
			break;
		case "TranslateBrowsePathsToNodeIdsCount":
			if (createOrReplace && TranslateBrowsePathsToNodeIdsCount == null)
			{
				if (replacement == null)
				{
					TranslateBrowsePathsToNodeIdsCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					TranslateBrowsePathsToNodeIdsCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = TranslateBrowsePathsToNodeIdsCount;
			break;
		case "QueryFirstCount":
			if (createOrReplace && QueryFirstCount == null)
			{
				if (replacement == null)
				{
					QueryFirstCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					QueryFirstCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = QueryFirstCount;
			break;
		case "QueryNextCount":
			if (createOrReplace && QueryNextCount == null)
			{
				if (replacement == null)
				{
					QueryNextCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					QueryNextCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = QueryNextCount;
			break;
		case "RegisterNodesCount":
			if (createOrReplace && RegisterNodesCount == null)
			{
				if (replacement == null)
				{
					RegisterNodesCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					RegisterNodesCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = RegisterNodesCount;
			break;
		case "UnregisterNodesCount":
			if (createOrReplace && UnregisterNodesCount == null)
			{
				if (replacement == null)
				{
					UnregisterNodesCount = new BaseDataVariableState<ServiceCounterDataType>(this);
				}
				else
				{
					UnregisterNodesCount = (BaseDataVariableState<ServiceCounterDataType>)replacement;
				}
			}
			baseInstanceState = UnregisterNodesCount;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
