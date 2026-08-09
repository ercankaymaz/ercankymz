using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SubscriptionDiagnosticsState : BaseDataVariableState<SubscriptionDiagnosticsDataType>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAIwAAAFN1YnNjcmlwdGlvbkRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQB8CAEAfAh8CAAAAQBqA/////8BAf////8fAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAH0IAC8AP30IAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABTdWJzY3JpcHRpb25JZAEAfggALwA/fggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFByaW9yaXR5AQB/CAAvAD9/CAAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHVibGlzaGluZ0ludGVydmFsAQCACAAvAD+ACAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABNYXhLZWVwQWxpdmVDb3VudAEAgQgALwA/gQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heExpZmV0aW1lQ291bnQBALgiAC8AP7giAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhOb3RpZmljYXRpb25zUGVyUHVibGlzaAEAgwgALwA/gwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFB1Ymxpc2hpbmdFbmFibGVkAQCECAAvAD+ECAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAALAAAATW9kaWZ5Q291bnQBAIUIAC8AP4UIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmFibGVDb3VudAEAhggALwA/hggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAERpc2FibGVDb3VudAEAhwgALwA/hwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlcHVibGlzaFJlcXVlc3RDb3VudAEAiAgALwA/iAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFJlcHVibGlzaE1lc3NhZ2VSZXF1ZXN0Q291bnQBAIkIAC8AP4kIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABUAAABSZXB1Ymxpc2hNZXNzYWdlQ291bnQBAIoIAC8AP4oIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABUcmFuc2ZlclJlcXVlc3RDb3VudAEAiwgALwA/iwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGwAAAFRyYW5zZmVycmVkVG9BbHRDbGllbnRDb3VudAEAjAgALwA/jAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFRyYW5zZmVycmVkVG9TYW1lQ2xpZW50Q291bnQBAI0IAC8AP40IAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQdWJsaXNoUmVxdWVzdENvdW50AQCOCAAvAD+OCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAARGF0YUNoYW5nZU5vdGlmaWNhdGlvbnNDb3VudAEAjwgALwA/jwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAEV2ZW50Tm90aWZpY2F0aW9uc0NvdW50AQC2CwAvAD+2CwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAASAAAATm90aWZpY2F0aW9uc0NvdW50AQCRCAAvAD+RCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAATGF0ZVB1Ymxpc2hSZXF1ZXN0Q291bnQBALkiAC8AP7kiAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDdXJyZW50S2VlcEFsaXZlQ291bnQBALoiAC8AP7oiAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABDdXJyZW50TGlmZXRpbWVDb3VudAEAuyIALwA/uyIAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGgAAAFVuYWNrbm93bGVkZ2VkTWVzc2FnZUNvdW50AQC8IgAvAD+8IgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARGlzY2FyZGVkTWVzc2FnZUNvdW50AQC9IgAvAD+9IgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAASAAAATW9uaXRvcmVkSXRlbUNvdW50AQC+IgAvAD++IgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAARGlzYWJsZWRNb25pdG9yZWRJdGVtQ291bnQBAL8iAC8AP78iAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABwAAABNb25pdG9yaW5nUXVldWVPdmVyZmxvd0NvdW50AQDAIgAvAD/AIgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAASAAAATmV4dFNlcXVlbmNlTnVtYmVyAQDBIgAvAD/BIgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAARXZlbnRRdWV1ZU92ZXJmbG93Q291bnQBAMYiAC8AP8YiAAAAB/////8BAf////8AAAAA";

	private BaseDataVariableState<NodeId> m_sessionId;

	private BaseDataVariableState<uint> m_subscriptionId;

	private BaseDataVariableState<byte> m_priority;

	private BaseDataVariableState<double> m_publishingInterval;

	private BaseDataVariableState<uint> m_maxKeepAliveCount;

	private BaseDataVariableState<uint> m_maxLifetimeCount;

	private BaseDataVariableState<uint> m_maxNotificationsPerPublish;

	private BaseDataVariableState<bool> m_publishingEnabled;

	private BaseDataVariableState<uint> m_modifyCount;

	private BaseDataVariableState<uint> m_enableCount;

	private BaseDataVariableState<uint> m_disableCount;

	private BaseDataVariableState<uint> m_republishRequestCount;

	private BaseDataVariableState<uint> m_republishMessageRequestCount;

	private BaseDataVariableState<uint> m_republishMessageCount;

	private BaseDataVariableState<uint> m_transferRequestCount;

	private BaseDataVariableState<uint> m_transferredToAltClientCount;

	private BaseDataVariableState<uint> m_transferredToSameClientCount;

	private BaseDataVariableState<uint> m_publishRequestCount;

	private BaseDataVariableState<uint> m_dataChangeNotificationsCount;

	private BaseDataVariableState<uint> m_eventNotificationsCount;

	private BaseDataVariableState<uint> m_notificationsCount;

	private BaseDataVariableState<uint> m_latePublishRequestCount;

	private BaseDataVariableState<uint> m_currentKeepAliveCount;

	private BaseDataVariableState<uint> m_currentLifetimeCount;

	private BaseDataVariableState<uint> m_unacknowledgedMessageCount;

	private BaseDataVariableState<uint> m_discardedMessageCount;

	private BaseDataVariableState<uint> m_monitoredItemCount;

	private BaseDataVariableState<uint> m_disabledMonitoredItemCount;

	private BaseDataVariableState<uint> m_monitoringQueueOverflowCount;

	private BaseDataVariableState<uint> m_nextSequenceNumber;

	private BaseDataVariableState<uint> m_eventQueueOverflowCount;

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

	public BaseDataVariableState<uint> SubscriptionId
	{
		get
		{
			return m_subscriptionId;
		}
		set
		{
			if (m_subscriptionId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_subscriptionId = value;
		}
	}

	public BaseDataVariableState<byte> Priority
	{
		get
		{
			return m_priority;
		}
		set
		{
			if (m_priority != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_priority = value;
		}
	}

	public BaseDataVariableState<double> PublishingInterval
	{
		get
		{
			return m_publishingInterval;
		}
		set
		{
			if (m_publishingInterval != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_publishingInterval = value;
		}
	}

	public BaseDataVariableState<uint> MaxKeepAliveCount
	{
		get
		{
			return m_maxKeepAliveCount;
		}
		set
		{
			if (m_maxKeepAliveCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxKeepAliveCount = value;
		}
	}

	public BaseDataVariableState<uint> MaxLifetimeCount
	{
		get
		{
			return m_maxLifetimeCount;
		}
		set
		{
			if (m_maxLifetimeCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxLifetimeCount = value;
		}
	}

	public BaseDataVariableState<uint> MaxNotificationsPerPublish
	{
		get
		{
			return m_maxNotificationsPerPublish;
		}
		set
		{
			if (m_maxNotificationsPerPublish != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNotificationsPerPublish = value;
		}
	}

	public BaseDataVariableState<bool> PublishingEnabled
	{
		get
		{
			return m_publishingEnabled;
		}
		set
		{
			if (m_publishingEnabled != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_publishingEnabled = value;
		}
	}

	public BaseDataVariableState<uint> ModifyCount
	{
		get
		{
			return m_modifyCount;
		}
		set
		{
			if (m_modifyCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_modifyCount = value;
		}
	}

	public BaseDataVariableState<uint> EnableCount
	{
		get
		{
			return m_enableCount;
		}
		set
		{
			if (m_enableCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_enableCount = value;
		}
	}

	public BaseDataVariableState<uint> DisableCount
	{
		get
		{
			return m_disableCount;
		}
		set
		{
			if (m_disableCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_disableCount = value;
		}
	}

	public BaseDataVariableState<uint> RepublishRequestCount
	{
		get
		{
			return m_republishRequestCount;
		}
		set
		{
			if (m_republishRequestCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_republishRequestCount = value;
		}
	}

	public BaseDataVariableState<uint> RepublishMessageRequestCount
	{
		get
		{
			return m_republishMessageRequestCount;
		}
		set
		{
			if (m_republishMessageRequestCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_republishMessageRequestCount = value;
		}
	}

	public BaseDataVariableState<uint> RepublishMessageCount
	{
		get
		{
			return m_republishMessageCount;
		}
		set
		{
			if (m_republishMessageCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_republishMessageCount = value;
		}
	}

	public BaseDataVariableState<uint> TransferRequestCount
	{
		get
		{
			return m_transferRequestCount;
		}
		set
		{
			if (m_transferRequestCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transferRequestCount = value;
		}
	}

	public BaseDataVariableState<uint> TransferredToAltClientCount
	{
		get
		{
			return m_transferredToAltClientCount;
		}
		set
		{
			if (m_transferredToAltClientCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transferredToAltClientCount = value;
		}
	}

	public BaseDataVariableState<uint> TransferredToSameClientCount
	{
		get
		{
			return m_transferredToSameClientCount;
		}
		set
		{
			if (m_transferredToSameClientCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transferredToSameClientCount = value;
		}
	}

	public BaseDataVariableState<uint> PublishRequestCount
	{
		get
		{
			return m_publishRequestCount;
		}
		set
		{
			if (m_publishRequestCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_publishRequestCount = value;
		}
	}

	public BaseDataVariableState<uint> DataChangeNotificationsCount
	{
		get
		{
			return m_dataChangeNotificationsCount;
		}
		set
		{
			if (m_dataChangeNotificationsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataChangeNotificationsCount = value;
		}
	}

	public BaseDataVariableState<uint> EventNotificationsCount
	{
		get
		{
			return m_eventNotificationsCount;
		}
		set
		{
			if (m_eventNotificationsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_eventNotificationsCount = value;
		}
	}

	public BaseDataVariableState<uint> NotificationsCount
	{
		get
		{
			return m_notificationsCount;
		}
		set
		{
			if (m_notificationsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_notificationsCount = value;
		}
	}

	public BaseDataVariableState<uint> LatePublishRequestCount
	{
		get
		{
			return m_latePublishRequestCount;
		}
		set
		{
			if (m_latePublishRequestCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_latePublishRequestCount = value;
		}
	}

	public BaseDataVariableState<uint> CurrentKeepAliveCount
	{
		get
		{
			return m_currentKeepAliveCount;
		}
		set
		{
			if (m_currentKeepAliveCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentKeepAliveCount = value;
		}
	}

	public BaseDataVariableState<uint> CurrentLifetimeCount
	{
		get
		{
			return m_currentLifetimeCount;
		}
		set
		{
			if (m_currentLifetimeCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentLifetimeCount = value;
		}
	}

	public BaseDataVariableState<uint> UnacknowledgedMessageCount
	{
		get
		{
			return m_unacknowledgedMessageCount;
		}
		set
		{
			if (m_unacknowledgedMessageCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_unacknowledgedMessageCount = value;
		}
	}

	public BaseDataVariableState<uint> DiscardedMessageCount
	{
		get
		{
			return m_discardedMessageCount;
		}
		set
		{
			if (m_discardedMessageCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_discardedMessageCount = value;
		}
	}

	public BaseDataVariableState<uint> MonitoredItemCount
	{
		get
		{
			return m_monitoredItemCount;
		}
		set
		{
			if (m_monitoredItemCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_monitoredItemCount = value;
		}
	}

	public BaseDataVariableState<uint> DisabledMonitoredItemCount
	{
		get
		{
			return m_disabledMonitoredItemCount;
		}
		set
		{
			if (m_disabledMonitoredItemCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_disabledMonitoredItemCount = value;
		}
	}

	public BaseDataVariableState<uint> MonitoringQueueOverflowCount
	{
		get
		{
			return m_monitoringQueueOverflowCount;
		}
		set
		{
			if (m_monitoringQueueOverflowCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_monitoringQueueOverflowCount = value;
		}
	}

	public BaseDataVariableState<uint> NextSequenceNumber
	{
		get
		{
			return m_nextSequenceNumber;
		}
		set
		{
			if (m_nextSequenceNumber != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_nextSequenceNumber = value;
		}
	}

	public BaseDataVariableState<uint> EventQueueOverflowCount
	{
		get
		{
			return m_eventQueueOverflowCount;
		}
		set
		{
			if (m_eventQueueOverflowCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_eventQueueOverflowCount = value;
		}
	}

	public SubscriptionDiagnosticsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2172u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(874u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAIwAAAFN1YnNjcmlwdGlvbkRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQB8CAEAfAh8CAAAAQBqA/////8BAf////8fAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAH0IAC8AP30IAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABTdWJzY3JpcHRpb25JZAEAfggALwA/fggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFByaW9yaXR5AQB/CAAvAD9/CAAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHVibGlzaGluZ0ludGVydmFsAQCACAAvAD+ACAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABNYXhLZWVwQWxpdmVDb3VudAEAgQgALwA/gQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heExpZmV0aW1lQ291bnQBALgiAC8AP7giAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhOb3RpZmljYXRpb25zUGVyUHVibGlzaAEAgwgALwA/gwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFB1Ymxpc2hpbmdFbmFibGVkAQCECAAvAD+ECAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAALAAAATW9kaWZ5Q291bnQBAIUIAC8AP4UIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmFibGVDb3VudAEAhggALwA/hggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAERpc2FibGVDb3VudAEAhwgALwA/hwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlcHVibGlzaFJlcXVlc3RDb3VudAEAiAgALwA/iAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFJlcHVibGlzaE1lc3NhZ2VSZXF1ZXN0Q291bnQBAIkIAC8AP4kIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABUAAABSZXB1Ymxpc2hNZXNzYWdlQ291bnQBAIoIAC8AP4oIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABUcmFuc2ZlclJlcXVlc3RDb3VudAEAiwgALwA/iwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGwAAAFRyYW5zZmVycmVkVG9BbHRDbGllbnRDb3VudAEAjAgALwA/jAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFRyYW5zZmVycmVkVG9TYW1lQ2xpZW50Q291bnQBAI0IAC8AP40IAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQdWJsaXNoUmVxdWVzdENvdW50AQCOCAAvAD+OCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAARGF0YUNoYW5nZU5vdGlmaWNhdGlvbnNDb3VudAEAjwgALwA/jwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAEV2ZW50Tm90aWZpY2F0aW9uc0NvdW50AQC2CwAvAD+2CwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAASAAAATm90aWZpY2F0aW9uc0NvdW50AQCRCAAvAD+RCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAATGF0ZVB1Ymxpc2hSZXF1ZXN0Q291bnQBALkiAC8AP7kiAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDdXJyZW50S2VlcEFsaXZlQ291bnQBALoiAC8AP7oiAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABDdXJyZW50TGlmZXRpbWVDb3VudAEAuyIALwA/uyIAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGgAAAFVuYWNrbm93bGVkZ2VkTWVzc2FnZUNvdW50AQC8IgAvAD+8IgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARGlzY2FyZGVkTWVzc2FnZUNvdW50AQC9IgAvAD+9IgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAASAAAATW9uaXRvcmVkSXRlbUNvdW50AQC+IgAvAD++IgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAARGlzYWJsZWRNb25pdG9yZWRJdGVtQ291bnQBAL8iAC8AP78iAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABwAAABNb25pdG9yaW5nUXVldWVPdmVyZmxvd0NvdW50AQDAIgAvAD/AIgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAASAAAATmV4dFNlcXVlbmNlTnVtYmVyAQDBIgAvAD/BIgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAARXZlbnRRdWV1ZU92ZXJmbG93Q291bnQBAMYiAC8AP8YiAAAAB/////8BAf////8AAAAA");
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
		if (m_subscriptionId != null)
		{
			children.Add(m_subscriptionId);
		}
		if (m_priority != null)
		{
			children.Add(m_priority);
		}
		if (m_publishingInterval != null)
		{
			children.Add(m_publishingInterval);
		}
		if (m_maxKeepAliveCount != null)
		{
			children.Add(m_maxKeepAliveCount);
		}
		if (m_maxLifetimeCount != null)
		{
			children.Add(m_maxLifetimeCount);
		}
		if (m_maxNotificationsPerPublish != null)
		{
			children.Add(m_maxNotificationsPerPublish);
		}
		if (m_publishingEnabled != null)
		{
			children.Add(m_publishingEnabled);
		}
		if (m_modifyCount != null)
		{
			children.Add(m_modifyCount);
		}
		if (m_enableCount != null)
		{
			children.Add(m_enableCount);
		}
		if (m_disableCount != null)
		{
			children.Add(m_disableCount);
		}
		if (m_republishRequestCount != null)
		{
			children.Add(m_republishRequestCount);
		}
		if (m_republishMessageRequestCount != null)
		{
			children.Add(m_republishMessageRequestCount);
		}
		if (m_republishMessageCount != null)
		{
			children.Add(m_republishMessageCount);
		}
		if (m_transferRequestCount != null)
		{
			children.Add(m_transferRequestCount);
		}
		if (m_transferredToAltClientCount != null)
		{
			children.Add(m_transferredToAltClientCount);
		}
		if (m_transferredToSameClientCount != null)
		{
			children.Add(m_transferredToSameClientCount);
		}
		if (m_publishRequestCount != null)
		{
			children.Add(m_publishRequestCount);
		}
		if (m_dataChangeNotificationsCount != null)
		{
			children.Add(m_dataChangeNotificationsCount);
		}
		if (m_eventNotificationsCount != null)
		{
			children.Add(m_eventNotificationsCount);
		}
		if (m_notificationsCount != null)
		{
			children.Add(m_notificationsCount);
		}
		if (m_latePublishRequestCount != null)
		{
			children.Add(m_latePublishRequestCount);
		}
		if (m_currentKeepAliveCount != null)
		{
			children.Add(m_currentKeepAliveCount);
		}
		if (m_currentLifetimeCount != null)
		{
			children.Add(m_currentLifetimeCount);
		}
		if (m_unacknowledgedMessageCount != null)
		{
			children.Add(m_unacknowledgedMessageCount);
		}
		if (m_discardedMessageCount != null)
		{
			children.Add(m_discardedMessageCount);
		}
		if (m_monitoredItemCount != null)
		{
			children.Add(m_monitoredItemCount);
		}
		if (m_disabledMonitoredItemCount != null)
		{
			children.Add(m_disabledMonitoredItemCount);
		}
		if (m_monitoringQueueOverflowCount != null)
		{
			children.Add(m_monitoringQueueOverflowCount);
		}
		if (m_nextSequenceNumber != null)
		{
			children.Add(m_nextSequenceNumber);
		}
		if (m_eventQueueOverflowCount != null)
		{
			children.Add(m_eventQueueOverflowCount);
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
		case "SubscriptionId":
			if (createOrReplace && SubscriptionId == null)
			{
				if (replacement == null)
				{
					SubscriptionId = new BaseDataVariableState<uint>(this);
				}
				else
				{
					SubscriptionId = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = SubscriptionId;
			break;
		case "Priority":
			if (createOrReplace && Priority == null)
			{
				if (replacement == null)
				{
					Priority = new BaseDataVariableState<byte>(this);
				}
				else
				{
					Priority = (BaseDataVariableState<byte>)replacement;
				}
			}
			baseInstanceState = Priority;
			break;
		case "PublishingInterval":
			if (createOrReplace && PublishingInterval == null)
			{
				if (replacement == null)
				{
					PublishingInterval = new BaseDataVariableState<double>(this);
				}
				else
				{
					PublishingInterval = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = PublishingInterval;
			break;
		case "MaxKeepAliveCount":
			if (createOrReplace && MaxKeepAliveCount == null)
			{
				if (replacement == null)
				{
					MaxKeepAliveCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					MaxKeepAliveCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = MaxKeepAliveCount;
			break;
		case "MaxLifetimeCount":
			if (createOrReplace && MaxLifetimeCount == null)
			{
				if (replacement == null)
				{
					MaxLifetimeCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					MaxLifetimeCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = MaxLifetimeCount;
			break;
		case "MaxNotificationsPerPublish":
			if (createOrReplace && MaxNotificationsPerPublish == null)
			{
				if (replacement == null)
				{
					MaxNotificationsPerPublish = new BaseDataVariableState<uint>(this);
				}
				else
				{
					MaxNotificationsPerPublish = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNotificationsPerPublish;
			break;
		case "PublishingEnabled":
			if (createOrReplace && PublishingEnabled == null)
			{
				if (replacement == null)
				{
					PublishingEnabled = new BaseDataVariableState<bool>(this);
				}
				else
				{
					PublishingEnabled = (BaseDataVariableState<bool>)replacement;
				}
			}
			baseInstanceState = PublishingEnabled;
			break;
		case "ModifyCount":
			if (createOrReplace && ModifyCount == null)
			{
				if (replacement == null)
				{
					ModifyCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					ModifyCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = ModifyCount;
			break;
		case "EnableCount":
			if (createOrReplace && EnableCount == null)
			{
				if (replacement == null)
				{
					EnableCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					EnableCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = EnableCount;
			break;
		case "DisableCount":
			if (createOrReplace && DisableCount == null)
			{
				if (replacement == null)
				{
					DisableCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					DisableCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = DisableCount;
			break;
		case "RepublishRequestCount":
			if (createOrReplace && RepublishRequestCount == null)
			{
				if (replacement == null)
				{
					RepublishRequestCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					RepublishRequestCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = RepublishRequestCount;
			break;
		case "RepublishMessageRequestCount":
			if (createOrReplace && RepublishMessageRequestCount == null)
			{
				if (replacement == null)
				{
					RepublishMessageRequestCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					RepublishMessageRequestCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = RepublishMessageRequestCount;
			break;
		case "RepublishMessageCount":
			if (createOrReplace && RepublishMessageCount == null)
			{
				if (replacement == null)
				{
					RepublishMessageCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					RepublishMessageCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = RepublishMessageCount;
			break;
		case "TransferRequestCount":
			if (createOrReplace && TransferRequestCount == null)
			{
				if (replacement == null)
				{
					TransferRequestCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					TransferRequestCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = TransferRequestCount;
			break;
		case "TransferredToAltClientCount":
			if (createOrReplace && TransferredToAltClientCount == null)
			{
				if (replacement == null)
				{
					TransferredToAltClientCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					TransferredToAltClientCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = TransferredToAltClientCount;
			break;
		case "TransferredToSameClientCount":
			if (createOrReplace && TransferredToSameClientCount == null)
			{
				if (replacement == null)
				{
					TransferredToSameClientCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					TransferredToSameClientCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = TransferredToSameClientCount;
			break;
		case "PublishRequestCount":
			if (createOrReplace && PublishRequestCount == null)
			{
				if (replacement == null)
				{
					PublishRequestCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					PublishRequestCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = PublishRequestCount;
			break;
		case "DataChangeNotificationsCount":
			if (createOrReplace && DataChangeNotificationsCount == null)
			{
				if (replacement == null)
				{
					DataChangeNotificationsCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					DataChangeNotificationsCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = DataChangeNotificationsCount;
			break;
		case "EventNotificationsCount":
			if (createOrReplace && EventNotificationsCount == null)
			{
				if (replacement == null)
				{
					EventNotificationsCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					EventNotificationsCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = EventNotificationsCount;
			break;
		case "NotificationsCount":
			if (createOrReplace && NotificationsCount == null)
			{
				if (replacement == null)
				{
					NotificationsCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					NotificationsCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = NotificationsCount;
			break;
		case "LatePublishRequestCount":
			if (createOrReplace && LatePublishRequestCount == null)
			{
				if (replacement == null)
				{
					LatePublishRequestCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					LatePublishRequestCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = LatePublishRequestCount;
			break;
		case "CurrentKeepAliveCount":
			if (createOrReplace && CurrentKeepAliveCount == null)
			{
				if (replacement == null)
				{
					CurrentKeepAliveCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					CurrentKeepAliveCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = CurrentKeepAliveCount;
			break;
		case "CurrentLifetimeCount":
			if (createOrReplace && CurrentLifetimeCount == null)
			{
				if (replacement == null)
				{
					CurrentLifetimeCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					CurrentLifetimeCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = CurrentLifetimeCount;
			break;
		case "UnacknowledgedMessageCount":
			if (createOrReplace && UnacknowledgedMessageCount == null)
			{
				if (replacement == null)
				{
					UnacknowledgedMessageCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					UnacknowledgedMessageCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = UnacknowledgedMessageCount;
			break;
		case "DiscardedMessageCount":
			if (createOrReplace && DiscardedMessageCount == null)
			{
				if (replacement == null)
				{
					DiscardedMessageCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					DiscardedMessageCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = DiscardedMessageCount;
			break;
		case "MonitoredItemCount":
			if (createOrReplace && MonitoredItemCount == null)
			{
				if (replacement == null)
				{
					MonitoredItemCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					MonitoredItemCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = MonitoredItemCount;
			break;
		case "DisabledMonitoredItemCount":
			if (createOrReplace && DisabledMonitoredItemCount == null)
			{
				if (replacement == null)
				{
					DisabledMonitoredItemCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					DisabledMonitoredItemCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = DisabledMonitoredItemCount;
			break;
		case "MonitoringQueueOverflowCount":
			if (createOrReplace && MonitoringQueueOverflowCount == null)
			{
				if (replacement == null)
				{
					MonitoringQueueOverflowCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					MonitoringQueueOverflowCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = MonitoringQueueOverflowCount;
			break;
		case "NextSequenceNumber":
			if (createOrReplace && NextSequenceNumber == null)
			{
				if (replacement == null)
				{
					NextSequenceNumber = new BaseDataVariableState<uint>(this);
				}
				else
				{
					NextSequenceNumber = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = NextSequenceNumber;
			break;
		case "EventQueueOverflowCount":
			if (createOrReplace && EventQueueOverflowCount == null)
			{
				if (replacement == null)
				{
					EventQueueOverflowCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					EventQueueOverflowCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = EventQueueOverflowCount;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
