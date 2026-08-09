using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SubscriptionDiagnosticsDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_sessionId;

	private uint m_subscriptionId;

	private byte m_priority;

	private double m_publishingInterval;

	private uint m_maxKeepAliveCount;

	private uint m_maxLifetimeCount;

	private uint m_maxNotificationsPerPublish;

	private bool m_publishingEnabled;

	private uint m_modifyCount;

	private uint m_enableCount;

	private uint m_disableCount;

	private uint m_republishRequestCount;

	private uint m_republishMessageRequestCount;

	private uint m_republishMessageCount;

	private uint m_transferRequestCount;

	private uint m_transferredToAltClientCount;

	private uint m_transferredToSameClientCount;

	private uint m_publishRequestCount;

	private uint m_dataChangeNotificationsCount;

	private uint m_eventNotificationsCount;

	private uint m_notificationsCount;

	private uint m_latePublishRequestCount;

	private uint m_currentKeepAliveCount;

	private uint m_currentLifetimeCount;

	private uint m_unacknowledgedMessageCount;

	private uint m_discardedMessageCount;

	private uint m_monitoredItemCount;

	private uint m_disabledMonitoredItemCount;

	private uint m_monitoringQueueOverflowCount;

	private uint m_nextSequenceNumber;

	private uint m_eventQueueOverFlowCount;

	[DataMember(Name = "SessionId", IsRequired = false, Order = 1)]
	public NodeId SessionId
	{
		get
		{
			return m_sessionId;
		}
		set
		{
			m_sessionId = value;
		}
	}

	[DataMember(Name = "SubscriptionId", IsRequired = false, Order = 2)]
	public uint SubscriptionId
	{
		get
		{
			return m_subscriptionId;
		}
		set
		{
			m_subscriptionId = value;
		}
	}

	[DataMember(Name = "Priority", IsRequired = false, Order = 3)]
	public byte Priority
	{
		get
		{
			return m_priority;
		}
		set
		{
			m_priority = value;
		}
	}

	[DataMember(Name = "PublishingInterval", IsRequired = false, Order = 4)]
	public double PublishingInterval
	{
		get
		{
			return m_publishingInterval;
		}
		set
		{
			m_publishingInterval = value;
		}
	}

	[DataMember(Name = "MaxKeepAliveCount", IsRequired = false, Order = 5)]
	public uint MaxKeepAliveCount
	{
		get
		{
			return m_maxKeepAliveCount;
		}
		set
		{
			m_maxKeepAliveCount = value;
		}
	}

	[DataMember(Name = "MaxLifetimeCount", IsRequired = false, Order = 6)]
	public uint MaxLifetimeCount
	{
		get
		{
			return m_maxLifetimeCount;
		}
		set
		{
			m_maxLifetimeCount = value;
		}
	}

	[DataMember(Name = "MaxNotificationsPerPublish", IsRequired = false, Order = 7)]
	public uint MaxNotificationsPerPublish
	{
		get
		{
			return m_maxNotificationsPerPublish;
		}
		set
		{
			m_maxNotificationsPerPublish = value;
		}
	}

	[DataMember(Name = "PublishingEnabled", IsRequired = false, Order = 8)]
	public bool PublishingEnabled
	{
		get
		{
			return m_publishingEnabled;
		}
		set
		{
			m_publishingEnabled = value;
		}
	}

	[DataMember(Name = "ModifyCount", IsRequired = false, Order = 9)]
	public uint ModifyCount
	{
		get
		{
			return m_modifyCount;
		}
		set
		{
			m_modifyCount = value;
		}
	}

	[DataMember(Name = "EnableCount", IsRequired = false, Order = 10)]
	public uint EnableCount
	{
		get
		{
			return m_enableCount;
		}
		set
		{
			m_enableCount = value;
		}
	}

	[DataMember(Name = "DisableCount", IsRequired = false, Order = 11)]
	public uint DisableCount
	{
		get
		{
			return m_disableCount;
		}
		set
		{
			m_disableCount = value;
		}
	}

	[DataMember(Name = "RepublishRequestCount", IsRequired = false, Order = 12)]
	public uint RepublishRequestCount
	{
		get
		{
			return m_republishRequestCount;
		}
		set
		{
			m_republishRequestCount = value;
		}
	}

	[DataMember(Name = "RepublishMessageRequestCount", IsRequired = false, Order = 13)]
	public uint RepublishMessageRequestCount
	{
		get
		{
			return m_republishMessageRequestCount;
		}
		set
		{
			m_republishMessageRequestCount = value;
		}
	}

	[DataMember(Name = "RepublishMessageCount", IsRequired = false, Order = 14)]
	public uint RepublishMessageCount
	{
		get
		{
			return m_republishMessageCount;
		}
		set
		{
			m_republishMessageCount = value;
		}
	}

	[DataMember(Name = "TransferRequestCount", IsRequired = false, Order = 15)]
	public uint TransferRequestCount
	{
		get
		{
			return m_transferRequestCount;
		}
		set
		{
			m_transferRequestCount = value;
		}
	}

	[DataMember(Name = "TransferredToAltClientCount", IsRequired = false, Order = 16)]
	public uint TransferredToAltClientCount
	{
		get
		{
			return m_transferredToAltClientCount;
		}
		set
		{
			m_transferredToAltClientCount = value;
		}
	}

	[DataMember(Name = "TransferredToSameClientCount", IsRequired = false, Order = 17)]
	public uint TransferredToSameClientCount
	{
		get
		{
			return m_transferredToSameClientCount;
		}
		set
		{
			m_transferredToSameClientCount = value;
		}
	}

	[DataMember(Name = "PublishRequestCount", IsRequired = false, Order = 18)]
	public uint PublishRequestCount
	{
		get
		{
			return m_publishRequestCount;
		}
		set
		{
			m_publishRequestCount = value;
		}
	}

	[DataMember(Name = "DataChangeNotificationsCount", IsRequired = false, Order = 19)]
	public uint DataChangeNotificationsCount
	{
		get
		{
			return m_dataChangeNotificationsCount;
		}
		set
		{
			m_dataChangeNotificationsCount = value;
		}
	}

	[DataMember(Name = "EventNotificationsCount", IsRequired = false, Order = 20)]
	public uint EventNotificationsCount
	{
		get
		{
			return m_eventNotificationsCount;
		}
		set
		{
			m_eventNotificationsCount = value;
		}
	}

	[DataMember(Name = "NotificationsCount", IsRequired = false, Order = 21)]
	public uint NotificationsCount
	{
		get
		{
			return m_notificationsCount;
		}
		set
		{
			m_notificationsCount = value;
		}
	}

	[DataMember(Name = "LatePublishRequestCount", IsRequired = false, Order = 22)]
	public uint LatePublishRequestCount
	{
		get
		{
			return m_latePublishRequestCount;
		}
		set
		{
			m_latePublishRequestCount = value;
		}
	}

	[DataMember(Name = "CurrentKeepAliveCount", IsRequired = false, Order = 23)]
	public uint CurrentKeepAliveCount
	{
		get
		{
			return m_currentKeepAliveCount;
		}
		set
		{
			m_currentKeepAliveCount = value;
		}
	}

	[DataMember(Name = "CurrentLifetimeCount", IsRequired = false, Order = 24)]
	public uint CurrentLifetimeCount
	{
		get
		{
			return m_currentLifetimeCount;
		}
		set
		{
			m_currentLifetimeCount = value;
		}
	}

	[DataMember(Name = "UnacknowledgedMessageCount", IsRequired = false, Order = 25)]
	public uint UnacknowledgedMessageCount
	{
		get
		{
			return m_unacknowledgedMessageCount;
		}
		set
		{
			m_unacknowledgedMessageCount = value;
		}
	}

	[DataMember(Name = "DiscardedMessageCount", IsRequired = false, Order = 26)]
	public uint DiscardedMessageCount
	{
		get
		{
			return m_discardedMessageCount;
		}
		set
		{
			m_discardedMessageCount = value;
		}
	}

	[DataMember(Name = "MonitoredItemCount", IsRequired = false, Order = 27)]
	public uint MonitoredItemCount
	{
		get
		{
			return m_monitoredItemCount;
		}
		set
		{
			m_monitoredItemCount = value;
		}
	}

	[DataMember(Name = "DisabledMonitoredItemCount", IsRequired = false, Order = 28)]
	public uint DisabledMonitoredItemCount
	{
		get
		{
			return m_disabledMonitoredItemCount;
		}
		set
		{
			m_disabledMonitoredItemCount = value;
		}
	}

	[DataMember(Name = "MonitoringQueueOverflowCount", IsRequired = false, Order = 29)]
	public uint MonitoringQueueOverflowCount
	{
		get
		{
			return m_monitoringQueueOverflowCount;
		}
		set
		{
			m_monitoringQueueOverflowCount = value;
		}
	}

	[DataMember(Name = "NextSequenceNumber", IsRequired = false, Order = 30)]
	public uint NextSequenceNumber
	{
		get
		{
			return m_nextSequenceNumber;
		}
		set
		{
			m_nextSequenceNumber = value;
		}
	}

	[DataMember(Name = "EventQueueOverFlowCount", IsRequired = false, Order = 31)]
	public uint EventQueueOverFlowCount
	{
		get
		{
			return m_eventQueueOverFlowCount;
		}
		set
		{
			m_eventQueueOverFlowCount = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SubscriptionDiagnosticsDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SubscriptionDiagnosticsDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SubscriptionDiagnosticsDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SubscriptionDiagnosticsDataType_Encoding_DefaultJson;

	public SubscriptionDiagnosticsDataType()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_sessionId = null;
		m_subscriptionId = 0u;
		m_priority = 0;
		m_publishingInterval = 0.0;
		m_maxKeepAliveCount = 0u;
		m_maxLifetimeCount = 0u;
		m_maxNotificationsPerPublish = 0u;
		m_publishingEnabled = true;
		m_modifyCount = 0u;
		m_enableCount = 0u;
		m_disableCount = 0u;
		m_republishRequestCount = 0u;
		m_republishMessageRequestCount = 0u;
		m_republishMessageCount = 0u;
		m_transferRequestCount = 0u;
		m_transferredToAltClientCount = 0u;
		m_transferredToSameClientCount = 0u;
		m_publishRequestCount = 0u;
		m_dataChangeNotificationsCount = 0u;
		m_eventNotificationsCount = 0u;
		m_notificationsCount = 0u;
		m_latePublishRequestCount = 0u;
		m_currentKeepAliveCount = 0u;
		m_currentLifetimeCount = 0u;
		m_unacknowledgedMessageCount = 0u;
		m_discardedMessageCount = 0u;
		m_monitoredItemCount = 0u;
		m_disabledMonitoredItemCount = 0u;
		m_monitoringQueueOverflowCount = 0u;
		m_nextSequenceNumber = 0u;
		m_eventQueueOverFlowCount = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("SessionId", SessionId);
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteByte("Priority", Priority);
		encoder.WriteDouble("PublishingInterval", PublishingInterval);
		encoder.WriteUInt32("MaxKeepAliveCount", MaxKeepAliveCount);
		encoder.WriteUInt32("MaxLifetimeCount", MaxLifetimeCount);
		encoder.WriteUInt32("MaxNotificationsPerPublish", MaxNotificationsPerPublish);
		encoder.WriteBoolean("PublishingEnabled", PublishingEnabled);
		encoder.WriteUInt32("ModifyCount", ModifyCount);
		encoder.WriteUInt32("EnableCount", EnableCount);
		encoder.WriteUInt32("DisableCount", DisableCount);
		encoder.WriteUInt32("RepublishRequestCount", RepublishRequestCount);
		encoder.WriteUInt32("RepublishMessageRequestCount", RepublishMessageRequestCount);
		encoder.WriteUInt32("RepublishMessageCount", RepublishMessageCount);
		encoder.WriteUInt32("TransferRequestCount", TransferRequestCount);
		encoder.WriteUInt32("TransferredToAltClientCount", TransferredToAltClientCount);
		encoder.WriteUInt32("TransferredToSameClientCount", TransferredToSameClientCount);
		encoder.WriteUInt32("PublishRequestCount", PublishRequestCount);
		encoder.WriteUInt32("DataChangeNotificationsCount", DataChangeNotificationsCount);
		encoder.WriteUInt32("EventNotificationsCount", EventNotificationsCount);
		encoder.WriteUInt32("NotificationsCount", NotificationsCount);
		encoder.WriteUInt32("LatePublishRequestCount", LatePublishRequestCount);
		encoder.WriteUInt32("CurrentKeepAliveCount", CurrentKeepAliveCount);
		encoder.WriteUInt32("CurrentLifetimeCount", CurrentLifetimeCount);
		encoder.WriteUInt32("UnacknowledgedMessageCount", UnacknowledgedMessageCount);
		encoder.WriteUInt32("DiscardedMessageCount", DiscardedMessageCount);
		encoder.WriteUInt32("MonitoredItemCount", MonitoredItemCount);
		encoder.WriteUInt32("DisabledMonitoredItemCount", DisabledMonitoredItemCount);
		encoder.WriteUInt32("MonitoringQueueOverflowCount", MonitoringQueueOverflowCount);
		encoder.WriteUInt32("NextSequenceNumber", NextSequenceNumber);
		encoder.WriteUInt32("EventQueueOverFlowCount", EventQueueOverFlowCount);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SessionId = decoder.ReadNodeId("SessionId");
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		Priority = decoder.ReadByte("Priority");
		PublishingInterval = decoder.ReadDouble("PublishingInterval");
		MaxKeepAliveCount = decoder.ReadUInt32("MaxKeepAliveCount");
		MaxLifetimeCount = decoder.ReadUInt32("MaxLifetimeCount");
		MaxNotificationsPerPublish = decoder.ReadUInt32("MaxNotificationsPerPublish");
		PublishingEnabled = decoder.ReadBoolean("PublishingEnabled");
		ModifyCount = decoder.ReadUInt32("ModifyCount");
		EnableCount = decoder.ReadUInt32("EnableCount");
		DisableCount = decoder.ReadUInt32("DisableCount");
		RepublishRequestCount = decoder.ReadUInt32("RepublishRequestCount");
		RepublishMessageRequestCount = decoder.ReadUInt32("RepublishMessageRequestCount");
		RepublishMessageCount = decoder.ReadUInt32("RepublishMessageCount");
		TransferRequestCount = decoder.ReadUInt32("TransferRequestCount");
		TransferredToAltClientCount = decoder.ReadUInt32("TransferredToAltClientCount");
		TransferredToSameClientCount = decoder.ReadUInt32("TransferredToSameClientCount");
		PublishRequestCount = decoder.ReadUInt32("PublishRequestCount");
		DataChangeNotificationsCount = decoder.ReadUInt32("DataChangeNotificationsCount");
		EventNotificationsCount = decoder.ReadUInt32("EventNotificationsCount");
		NotificationsCount = decoder.ReadUInt32("NotificationsCount");
		LatePublishRequestCount = decoder.ReadUInt32("LatePublishRequestCount");
		CurrentKeepAliveCount = decoder.ReadUInt32("CurrentKeepAliveCount");
		CurrentLifetimeCount = decoder.ReadUInt32("CurrentLifetimeCount");
		UnacknowledgedMessageCount = decoder.ReadUInt32("UnacknowledgedMessageCount");
		DiscardedMessageCount = decoder.ReadUInt32("DiscardedMessageCount");
		MonitoredItemCount = decoder.ReadUInt32("MonitoredItemCount");
		DisabledMonitoredItemCount = decoder.ReadUInt32("DisabledMonitoredItemCount");
		MonitoringQueueOverflowCount = decoder.ReadUInt32("MonitoringQueueOverflowCount");
		NextSequenceNumber = decoder.ReadUInt32("NextSequenceNumber");
		EventQueueOverFlowCount = decoder.ReadUInt32("EventQueueOverFlowCount");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SubscriptionDiagnosticsDataType subscriptionDiagnosticsDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sessionId, subscriptionDiagnosticsDataType.m_sessionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, subscriptionDiagnosticsDataType.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_priority, subscriptionDiagnosticsDataType.m_priority))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishingInterval, subscriptionDiagnosticsDataType.m_publishingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxKeepAliveCount, subscriptionDiagnosticsDataType.m_maxKeepAliveCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxLifetimeCount, subscriptionDiagnosticsDataType.m_maxLifetimeCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxNotificationsPerPublish, subscriptionDiagnosticsDataType.m_maxNotificationsPerPublish))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishingEnabled, subscriptionDiagnosticsDataType.m_publishingEnabled))
		{
			return false;
		}
		if (!Utils.IsEqual(m_modifyCount, subscriptionDiagnosticsDataType.m_modifyCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_enableCount, subscriptionDiagnosticsDataType.m_enableCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_disableCount, subscriptionDiagnosticsDataType.m_disableCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_republishRequestCount, subscriptionDiagnosticsDataType.m_republishRequestCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_republishMessageRequestCount, subscriptionDiagnosticsDataType.m_republishMessageRequestCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_republishMessageCount, subscriptionDiagnosticsDataType.m_republishMessageCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transferRequestCount, subscriptionDiagnosticsDataType.m_transferRequestCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transferredToAltClientCount, subscriptionDiagnosticsDataType.m_transferredToAltClientCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transferredToSameClientCount, subscriptionDiagnosticsDataType.m_transferredToSameClientCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishRequestCount, subscriptionDiagnosticsDataType.m_publishRequestCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataChangeNotificationsCount, subscriptionDiagnosticsDataType.m_dataChangeNotificationsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventNotificationsCount, subscriptionDiagnosticsDataType.m_eventNotificationsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_notificationsCount, subscriptionDiagnosticsDataType.m_notificationsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_latePublishRequestCount, subscriptionDiagnosticsDataType.m_latePublishRequestCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_currentKeepAliveCount, subscriptionDiagnosticsDataType.m_currentKeepAliveCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_currentLifetimeCount, subscriptionDiagnosticsDataType.m_currentLifetimeCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_unacknowledgedMessageCount, subscriptionDiagnosticsDataType.m_unacknowledgedMessageCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_discardedMessageCount, subscriptionDiagnosticsDataType.m_discardedMessageCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_monitoredItemCount, subscriptionDiagnosticsDataType.m_monitoredItemCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_disabledMonitoredItemCount, subscriptionDiagnosticsDataType.m_disabledMonitoredItemCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_monitoringQueueOverflowCount, subscriptionDiagnosticsDataType.m_monitoringQueueOverflowCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nextSequenceNumber, subscriptionDiagnosticsDataType.m_nextSequenceNumber))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventQueueOverFlowCount, subscriptionDiagnosticsDataType.m_eventQueueOverFlowCount))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SubscriptionDiagnosticsDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SubscriptionDiagnosticsDataType obj = (SubscriptionDiagnosticsDataType)base.MemberwiseClone();
		obj.m_sessionId = (NodeId)Utils.Clone(m_sessionId);
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_priority = (byte)Utils.Clone(m_priority);
		obj.m_publishingInterval = (double)Utils.Clone(m_publishingInterval);
		obj.m_maxKeepAliveCount = (uint)Utils.Clone(m_maxKeepAliveCount);
		obj.m_maxLifetimeCount = (uint)Utils.Clone(m_maxLifetimeCount);
		obj.m_maxNotificationsPerPublish = (uint)Utils.Clone(m_maxNotificationsPerPublish);
		obj.m_publishingEnabled = (bool)Utils.Clone(m_publishingEnabled);
		obj.m_modifyCount = (uint)Utils.Clone(m_modifyCount);
		obj.m_enableCount = (uint)Utils.Clone(m_enableCount);
		obj.m_disableCount = (uint)Utils.Clone(m_disableCount);
		obj.m_republishRequestCount = (uint)Utils.Clone(m_republishRequestCount);
		obj.m_republishMessageRequestCount = (uint)Utils.Clone(m_republishMessageRequestCount);
		obj.m_republishMessageCount = (uint)Utils.Clone(m_republishMessageCount);
		obj.m_transferRequestCount = (uint)Utils.Clone(m_transferRequestCount);
		obj.m_transferredToAltClientCount = (uint)Utils.Clone(m_transferredToAltClientCount);
		obj.m_transferredToSameClientCount = (uint)Utils.Clone(m_transferredToSameClientCount);
		obj.m_publishRequestCount = (uint)Utils.Clone(m_publishRequestCount);
		obj.m_dataChangeNotificationsCount = (uint)Utils.Clone(m_dataChangeNotificationsCount);
		obj.m_eventNotificationsCount = (uint)Utils.Clone(m_eventNotificationsCount);
		obj.m_notificationsCount = (uint)Utils.Clone(m_notificationsCount);
		obj.m_latePublishRequestCount = (uint)Utils.Clone(m_latePublishRequestCount);
		obj.m_currentKeepAliveCount = (uint)Utils.Clone(m_currentKeepAliveCount);
		obj.m_currentLifetimeCount = (uint)Utils.Clone(m_currentLifetimeCount);
		obj.m_unacknowledgedMessageCount = (uint)Utils.Clone(m_unacknowledgedMessageCount);
		obj.m_discardedMessageCount = (uint)Utils.Clone(m_discardedMessageCount);
		obj.m_monitoredItemCount = (uint)Utils.Clone(m_monitoredItemCount);
		obj.m_disabledMonitoredItemCount = (uint)Utils.Clone(m_disabledMonitoredItemCount);
		obj.m_monitoringQueueOverflowCount = (uint)Utils.Clone(m_monitoringQueueOverflowCount);
		obj.m_nextSequenceNumber = (uint)Utils.Clone(m_nextSequenceNumber);
		obj.m_eventQueueOverFlowCount = (uint)Utils.Clone(m_eventQueueOverFlowCount);
		return obj;
	}
}
