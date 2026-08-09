using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Client;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[KnownType(typeof(DataChangeFilter))]
[KnownType(typeof(EventFilter))]
[KnownType(typeof(AggregateFilter))]
[ComVisible(true)]
public class MonitoredItem : ICloneable
{
	private Subscription m_subscription;

	private object m_handle;

	private string m_displayName;

	private NodeId m_startNodeId;

	private string m_relativePath;

	private NodeId m_resolvedNodeId;

	private NodeClass m_nodeClass;

	private uint m_attributeId;

	private string m_indexRange;

	private QualifiedName m_encoding;

	private MonitoringMode m_monitoringMode;

	private int m_samplingInterval;

	private MonitoringFilter m_filter;

	private uint m_queueSize;

	private bool m_discardOldest;

	private uint m_clientHandle;

	private MonitoredItemStatus m_status;

	private bool m_attributesModified;

	private static long s_globalClientHandle;

	private object m_cache = new object();

	private MonitoredItemDataCache m_dataCache;

	private MonitoredItemEventCache m_eventCache;

	private IEncodeable m_lastNotification;

	[DataMember(Order = 1)]
	public string DisplayName
	{
		get
		{
			return m_displayName;
		}
		set
		{
			m_displayName = value;
		}
	}

	[DataMember(Order = 2)]
	public NodeId StartNodeId
	{
		get
		{
			return m_startNodeId;
		}
		set
		{
			m_startNodeId = value;
		}
	}

	[DataMember(Order = 3)]
	public string RelativePath
	{
		get
		{
			return m_relativePath;
		}
		set
		{
			if (m_relativePath != value)
			{
				m_resolvedNodeId = null;
			}
			m_relativePath = value;
		}
	}

	[DataMember(Order = 4)]
	public NodeClass NodeClass
	{
		get
		{
			return m_nodeClass;
		}
		set
		{
			if (m_nodeClass != value)
			{
				if ((value & (NodeClass)129) != NodeClass.Unspecified)
				{
					if (!(m_filter is EventFilter))
					{
						UseDefaultEventFilter();
					}
					if (QueueSize <= 1)
					{
						QueueSize = 2147483647u;
					}
					m_eventCache = new MonitoredItemEventCache(100);
					m_attributeId = 12u;
				}
				else
				{
					if (m_filter is EventFilter)
					{
						m_filter = null;
					}
					if (QueueSize == int.MaxValue)
					{
						QueueSize = 1u;
					}
					m_dataCache = new MonitoredItemDataCache(1);
				}
			}
			m_nodeClass = value;
		}
	}

	[DataMember(Order = 5)]
	public uint AttributeId
	{
		get
		{
			return m_attributeId;
		}
		set
		{
			m_attributeId = value;
		}
	}

	[DataMember(Order = 6)]
	public string IndexRange
	{
		get
		{
			return m_indexRange;
		}
		set
		{
			m_indexRange = value;
		}
	}

	[DataMember(Order = 7)]
	public QualifiedName Encoding
	{
		get
		{
			return m_encoding;
		}
		set
		{
			m_encoding = value;
		}
	}

	[DataMember(Order = 8)]
	public MonitoringMode MonitoringMode
	{
		get
		{
			return m_monitoringMode;
		}
		set
		{
			m_monitoringMode = value;
		}
	}

	[DataMember(Order = 9)]
	public int SamplingInterval
	{
		get
		{
			return m_samplingInterval;
		}
		set
		{
			if (m_samplingInterval != value)
			{
				m_attributesModified = true;
			}
			m_samplingInterval = value;
		}
	}

	[DataMember(Order = 10)]
	public MonitoringFilter Filter
	{
		get
		{
			return m_filter;
		}
		set
		{
			ValidateFilter(m_nodeClass, value);
			m_attributesModified = true;
			m_filter = value;
		}
	}

	[DataMember(Order = 11)]
	public uint QueueSize
	{
		get
		{
			return m_queueSize;
		}
		set
		{
			if (m_queueSize != value)
			{
				m_attributesModified = true;
			}
			m_queueSize = value;
		}
	}

	[DataMember(Order = 12)]
	public bool DiscardOldest
	{
		get
		{
			return m_discardOldest;
		}
		set
		{
			if (m_discardOldest != value)
			{
				m_attributesModified = true;
			}
			m_discardOldest = value;
		}
	}

	[DataMember(Order = 13)]
	public uint ServerId
	{
		get
		{
			return m_status.Id;
		}
		set
		{
			m_status.Id = value;
		}
	}

	public Subscription Subscription
	{
		get
		{
			return m_subscription;
		}
		internal set
		{
			m_subscription = value;
		}
	}

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	public bool Created => m_status.Created;

	public uint ClientHandle => m_clientHandle;

	public NodeId ResolvedNodeId
	{
		get
		{
			if (string.IsNullOrEmpty(m_relativePath))
			{
				return m_startNodeId;
			}
			return m_resolvedNodeId;
		}
		internal set
		{
			m_resolvedNodeId = value;
		}
	}

	public bool AttributesModified => m_attributesModified;

	public MonitoredItemStatus Status => m_status;

	public int CacheQueueSize
	{
		get
		{
			lock (m_cache)
			{
				if (m_dataCache != null)
				{
					return m_dataCache.QueueSize;
				}
				if (m_eventCache != null)
				{
					return m_eventCache.QueueSize;
				}
				return 0;
			}
		}
		set
		{
			lock (m_cache)
			{
				if (m_dataCache != null)
				{
					m_dataCache.SetQueueSize(value);
				}
				if (m_eventCache != null)
				{
					m_eventCache.SetQueueSize(value);
				}
			}
		}
	}

	public IEncodeable LastValue
	{
		get
		{
			lock (m_cache)
			{
				return m_lastNotification;
			}
		}
	}

	public NotificationMessage LastMessage
	{
		get
		{
			lock (m_cache)
			{
				if (m_dataCache != null)
				{
					return ((MonitoredItemNotification)m_lastNotification).Message;
				}
				if (m_eventCache != null)
				{
					return ((EventFieldList)m_lastNotification).Message;
				}
				return null;
			}
		}
	}

	public event MonitoredItemNotificationEventHandler Notification
	{
		add
		{
			lock (m_cache)
			{
				m_Notification += value;
			}
		}
		remove
		{
			lock (m_cache)
			{
				m_Notification -= value;
			}
		}
	}

	private event MonitoredItemNotificationEventHandler m_Notification;

	public MonitoredItem()
	{
		Initialize();
	}

	public MonitoredItem(uint clientHandle)
	{
		Initialize();
		m_clientHandle = clientHandle;
	}

	public MonitoredItem(MonitoredItem template)
		: this(template, copyEventHandlers: false)
	{
	}

	public MonitoredItem(MonitoredItem template, bool copyEventHandlers)
		: this(template, copyEventHandlers, copyClientHandle: false)
	{
	}

	public MonitoredItem(MonitoredItem template, bool copyEventHandlers, bool copyClientHandle)
	{
		Initialize();
		if (template == null)
		{
			return;
		}
		string text = template.DisplayName;
		if (text != null)
		{
			int num = text.LastIndexOf(' ');
			if (num != -1)
			{
				try
				{
					text = text.Substring(0, num);
				}
				catch
				{
				}
			}
		}
		m_handle = template.m_handle;
		m_displayName = Utils.Format("{0} {1}", text, m_clientHandle);
		m_startNodeId = template.m_startNodeId;
		m_relativePath = template.m_relativePath;
		m_attributeId = template.m_attributeId;
		m_indexRange = template.m_indexRange;
		m_encoding = template.m_encoding;
		m_monitoringMode = template.m_monitoringMode;
		m_samplingInterval = template.m_samplingInterval;
		m_filter = (MonitoringFilter)Utils.Clone(template.m_filter);
		m_queueSize = template.m_queueSize;
		m_discardOldest = template.m_discardOldest;
		m_attributesModified = true;
		if (copyEventHandlers)
		{
			this.m_Notification = template.m_Notification;
		}
		if (copyClientHandle)
		{
			m_clientHandle = template.m_clientHandle;
		}
		NodeClass = template.m_nodeClass;
	}

	[OnDeserializing]
	protected void Initialize(StreamingContext context)
	{
		m_cache = new object();
		Initialize();
	}

	private void Initialize()
	{
		m_startNodeId = null;
		m_relativePath = null;
		m_clientHandle = 0u;
		m_attributeId = 13u;
		m_indexRange = null;
		m_encoding = null;
		m_monitoringMode = MonitoringMode.Reporting;
		m_samplingInterval = -1;
		m_filter = null;
		m_queueSize = 0u;
		m_discardOldest = true;
		m_attributesModified = true;
		m_status = new MonitoredItemStatus();
		NodeClass = NodeClass.Variable;
		m_clientHandle = Utils.IncrementIdentifier(ref s_globalClientHandle);
	}

	public IList<DataValue> DequeueValues()
	{
		lock (m_cache)
		{
			if (m_dataCache != null)
			{
				return m_dataCache.Publish();
			}
			return new List<DataValue>();
		}
	}

	public IList<EventFieldList> DequeueEvents()
	{
		lock (m_cache)
		{
			if (m_eventCache != null)
			{
				return m_eventCache.Publish();
			}
			return new List<EventFieldList>();
		}
	}

	public void DetachNotificationEventHandlers()
	{
		lock (m_cache)
		{
			this.m_Notification = null;
		}
	}

	public void SaveValueInCache(IEncodeable newValue)
	{
		lock (m_cache)
		{
			bool flag = m_lastNotification == null;
			m_lastNotification = newValue;
			if (m_dataCache != null && newValue is MonitoredItemNotification monitoredItemNotification)
			{
				if (monitoredItemNotification.Value != null)
				{
					if (flag)
					{
						DateTime utcNow = DateTime.UtcNow;
						if (monitoredItemNotification.Value.ServerTimestamp > utcNow)
						{
							Utils.LogWarning("Received ServerTimestamp {0} is in the future for MonitoredItemId {1}", monitoredItemNotification.Value.ServerTimestamp.ToLocalTime(), ClientHandle);
						}
						if (monitoredItemNotification.Value.SourceTimestamp > utcNow)
						{
							Utils.LogWarning("Received SourceTimestamp {0} is in the future for MonitoredItemId {1}", monitoredItemNotification.Value.SourceTimestamp.ToLocalTime(), ClientHandle);
						}
					}
					if (monitoredItemNotification.Value.StatusCode.Overflow)
					{
						Utils.LogWarning("Overflow bit set for data change with ServerTimestamp {0} and value {1} for MonitoredItemId {2}", monitoredItemNotification.Value.ServerTimestamp.ToLocalTime(), monitoredItemNotification.Value.Value, ClientHandle);
					}
				}
				m_dataCache.OnNotification(monitoredItemNotification);
			}
			if (m_eventCache != null)
			{
				EventFieldList notification = newValue as EventFieldList;
				if (m_eventCache != null)
				{
					m_eventCache.OnNotification(notification);
				}
			}
			if (this.m_Notification != null)
			{
				this.m_Notification(this, new MonitoredItemNotificationEventArgs(newValue));
			}
		}
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new MonitoredItem(this);
	}

	public virtual MonitoredItem CloneMonitoredItem(bool copyEventHandlers, bool copyClientHandle)
	{
		return new MonitoredItem(this, copyEventHandlers, copyClientHandle);
	}

	public void SetError(ServiceResult error)
	{
		m_status.SetError(error);
	}

	public void SetResolvePathResult(BrowsePathResult result, int index, DiagnosticInfoCollection diagnosticInfos, ResponseHeader responseHeader)
	{
		ServiceResult error = null;
		if (StatusCode.IsBad(result.StatusCode))
		{
			error = ClientBase.GetResult(result.StatusCode, index, diagnosticInfos, responseHeader);
		}
		else
		{
			ResolvedNodeId = NodeId.Null;
			if (result.Targets.Count > 0)
			{
				ResolvedNodeId = ExpandedNodeId.ToNodeId(result.Targets[0].TargetId, m_subscription.Session.NamespaceUris);
			}
		}
		m_status.SetResolvePathResult(result, error);
	}

	public void SetCreateResult(MonitoredItemCreateRequest request, MonitoredItemCreateResult result, int index, DiagnosticInfoCollection diagnosticInfos, ResponseHeader responseHeader)
	{
		ServiceResult error = null;
		if (StatusCode.IsBad(result.StatusCode))
		{
			error = ClientBase.GetResult(result.StatusCode, index, diagnosticInfos, responseHeader);
		}
		m_status.SetCreateResult(request, result, error);
		m_attributesModified = false;
	}

	public void SetModifyResult(MonitoredItemModifyRequest request, MonitoredItemModifyResult result, int index, DiagnosticInfoCollection diagnosticInfos, ResponseHeader responseHeader)
	{
		ServiceResult error = null;
		if (StatusCode.IsBad(result.StatusCode))
		{
			error = ClientBase.GetResult(result.StatusCode, index, diagnosticInfos, responseHeader);
		}
		m_status.SetModifyResult(request, result, error);
		m_attributesModified = false;
	}

	public void SetTransferResult(uint clientHandle)
	{
		Utils.LowerLimitIdentifier(ref s_globalClientHandle, clientHandle);
		m_clientHandle = clientHandle;
		m_status.SetTransferResult(this);
		m_attributesModified = false;
	}

	public void SetDeleteResult(StatusCode result, int index, DiagnosticInfoCollection diagnosticInfos, ResponseHeader responseHeader)
	{
		ServiceResult deleteResult = null;
		if (StatusCode.IsBad(result))
		{
			deleteResult = ClientBase.GetResult(result, index, diagnosticInfos, responseHeader);
		}
		m_status.SetDeleteResult(deleteResult);
	}

	public string GetFieldName(int index)
	{
		if (!(m_filter is EventFilter eventFilter))
		{
			return null;
		}
		if (index < 0 || index >= eventFilter.SelectClauses.Count)
		{
			return null;
		}
		return Utils.Format("{0}", SimpleAttributeOperand.Format(eventFilter.SelectClauses[index].BrowsePath));
	}

	public object GetFieldValue(EventFieldList eventFields, NodeId eventTypeId, string browsePath, uint attributeId)
	{
		QualifiedNameCollection browsePath2 = SimpleAttributeOperand.Parse(browsePath);
		return GetFieldValue(eventFields, eventTypeId, browsePath2, attributeId);
	}

	public object GetFieldValue(EventFieldList eventFields, NodeId eventTypeId, QualifiedName browseName)
	{
		QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection();
		qualifiedNameCollection.Add(browseName);
		return GetFieldValue(eventFields, eventTypeId, qualifiedNameCollection, 13u);
	}

	public object GetFieldValue(EventFieldList eventFields, NodeId eventTypeId, IList<QualifiedName> browsePath, uint attributeId)
	{
		if (eventFields == null)
		{
			return null;
		}
		if (!(m_filter is EventFilter eventFilter))
		{
			return null;
		}
		for (int i = 0; i < eventFilter.SelectClauses.Count; i++)
		{
			if (i >= eventFields.EventFields.Count)
			{
				return null;
			}
			SimpleAttributeOperand simpleAttributeOperand = eventFilter.SelectClauses[i];
			if (simpleAttributeOperand.AttributeId != attributeId)
			{
				continue;
			}
			if (browsePath == null || browsePath.Count == 0)
			{
				if (simpleAttributeOperand.BrowsePath == null || simpleAttributeOperand.BrowsePath.Count <= 0)
				{
					return eventFields.EventFields[i].Value;
				}
			}
			else
			{
				if (simpleAttributeOperand.TypeDefinitionId != eventTypeId || simpleAttributeOperand.BrowsePath.Count != browsePath.Count)
				{
					continue;
				}
				bool flag = true;
				for (int j = 0; j < simpleAttributeOperand.BrowsePath.Count; j++)
				{
					if (simpleAttributeOperand.BrowsePath[j] != browsePath[j])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return eventFields.EventFields[i].Value;
				}
			}
		}
		return null;
	}

	public INode GetEventType(EventFieldList eventFields)
	{
		NodeId nodeId = GetFieldValue(eventFields, 2041u, "EventType") as NodeId;
		if (nodeId != null && m_subscription != null && m_subscription.Session != null)
		{
			return m_subscription.Session.NodeCache.Find(nodeId);
		}
		return null;
	}

	public DateTime GetEventTime(EventFieldList eventFields)
	{
		DateTime? dateTime = GetFieldValue(eventFields, 2041u, "Time") as DateTime?;
		if (dateTime.HasValue)
		{
			return dateTime.Value;
		}
		return DateTime.MinValue;
	}

	public static ServiceResult GetServiceResult(IEncodeable notification)
	{
		if (!(notification is MonitoredItemNotification { Message: var message } monitoredItemNotification))
		{
			return null;
		}
		if (message == null)
		{
			return null;
		}
		return new ServiceResult(monitoredItemNotification.Value.StatusCode, monitoredItemNotification.DiagnosticInfo, message.StringTable);
	}

	public static ServiceResult GetServiceResult(IEncodeable notification, int index)
	{
		if (!(notification is EventFieldList { Message: var message } eventFieldList))
		{
			return null;
		}
		if (message == null)
		{
			return null;
		}
		if (index < 0 || index >= eventFieldList.EventFields.Count)
		{
			return null;
		}
		if (!(ExtensionObject.ToEncodeable(eventFieldList.EventFields[index].Value as ExtensionObject) is StatusResult statusResult))
		{
			return null;
		}
		return new ServiceResult(statusResult.StatusCode, statusResult.DiagnosticInfo, message.StringTable);
	}

	private void ValidateFilter(NodeClass nodeClass, MonitoringFilter filter)
	{
		if (filter == null)
		{
			return;
		}
		switch (nodeClass)
		{
		case NodeClass.Variable:
		case NodeClass.VariableType:
			if (!typeof(DataChangeFilter).IsInstanceOfType(filter))
			{
				m_nodeClass = NodeClass.Variable;
			}
			break;
		case NodeClass.Object:
		case NodeClass.View:
			if (!typeof(EventFilter).IsInstanceOfType(filter))
			{
				m_nodeClass = NodeClass.Object;
			}
			break;
		default:
			throw ServiceResultException.Create(2152005632u, "Filters may not be specified for nodes of class '{0}'.", nodeClass);
		}
	}

	private void UseDefaultEventFilter()
	{
		EventFilter eventFilter = (eventFilter = new EventFilter());
		eventFilter.AddSelectClause(2041u, "EventId");
		eventFilter.AddSelectClause(2041u, "EventType");
		eventFilter.AddSelectClause(2041u, "SourceNode");
		eventFilter.AddSelectClause(2041u, "SourceName");
		eventFilter.AddSelectClause(2041u, "Time");
		eventFilter.AddSelectClause(2041u, "ReceiveTime");
		eventFilter.AddSelectClause(2041u, "LocalTime");
		eventFilter.AddSelectClause(2041u, "Message");
		eventFilter.AddSelectClause(2041u, "Severity");
		m_filter = eventFilter;
	}
}
