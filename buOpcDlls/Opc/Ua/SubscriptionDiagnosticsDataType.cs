// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SubscriptionDiagnosticsDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
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

  public SubscriptionDiagnosticsDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_sessionId = (NodeId) null;
    this.m_subscriptionId = 0U;
    this.m_priority = (byte) 0;
    this.m_publishingInterval = 0.0;
    this.m_maxKeepAliveCount = 0U;
    this.m_maxLifetimeCount = 0U;
    this.m_maxNotificationsPerPublish = 0U;
    this.m_publishingEnabled = true;
    this.m_modifyCount = 0U;
    this.m_enableCount = 0U;
    this.m_disableCount = 0U;
    this.m_republishRequestCount = 0U;
    this.m_republishMessageRequestCount = 0U;
    this.m_republishMessageCount = 0U;
    this.m_transferRequestCount = 0U;
    this.m_transferredToAltClientCount = 0U;
    this.m_transferredToSameClientCount = 0U;
    this.m_publishRequestCount = 0U;
    this.m_dataChangeNotificationsCount = 0U;
    this.m_eventNotificationsCount = 0U;
    this.m_notificationsCount = 0U;
    this.m_latePublishRequestCount = 0U;
    this.m_currentKeepAliveCount = 0U;
    this.m_currentLifetimeCount = 0U;
    this.m_unacknowledgedMessageCount = 0U;
    this.m_discardedMessageCount = 0U;
    this.m_monitoredItemCount = 0U;
    this.m_disabledMonitoredItemCount = 0U;
    this.m_monitoringQueueOverflowCount = 0U;
    this.m_nextSequenceNumber = 0U;
    this.m_eventQueueOverFlowCount = 0U;
  }

  [DataMember(Name = "SessionId", IsRequired = false, Order = 1)]
  public NodeId SessionId
  {
    get => this.m_sessionId;
    set => this.m_sessionId = value;
  }

  [DataMember(Name = "SubscriptionId", IsRequired = false, Order = 2)]
  public uint SubscriptionId
  {
    get => this.m_subscriptionId;
    set => this.m_subscriptionId = value;
  }

  [DataMember(Name = "Priority", IsRequired = false, Order = 3)]
  public byte Priority
  {
    get => this.m_priority;
    set => this.m_priority = value;
  }

  [DataMember(Name = "PublishingInterval", IsRequired = false, Order = 4)]
  public double PublishingInterval
  {
    get => this.m_publishingInterval;
    set => this.m_publishingInterval = value;
  }

  [DataMember(Name = "MaxKeepAliveCount", IsRequired = false, Order = 5)]
  public uint MaxKeepAliveCount
  {
    get => this.m_maxKeepAliveCount;
    set => this.m_maxKeepAliveCount = value;
  }

  [DataMember(Name = "MaxLifetimeCount", IsRequired = false, Order = 6)]
  public uint MaxLifetimeCount
  {
    get => this.m_maxLifetimeCount;
    set => this.m_maxLifetimeCount = value;
  }

  [DataMember(Name = "MaxNotificationsPerPublish", IsRequired = false, Order = 7)]
  public uint MaxNotificationsPerPublish
  {
    get => this.m_maxNotificationsPerPublish;
    set => this.m_maxNotificationsPerPublish = value;
  }

  [DataMember(Name = "PublishingEnabled", IsRequired = false, Order = 8)]
  public bool PublishingEnabled
  {
    get => this.m_publishingEnabled;
    set => this.m_publishingEnabled = value;
  }

  [DataMember(Name = "ModifyCount", IsRequired = false, Order = 9)]
  public uint ModifyCount
  {
    get => this.m_modifyCount;
    set => this.m_modifyCount = value;
  }

  [DataMember(Name = "EnableCount", IsRequired = false, Order = 10)]
  public uint EnableCount
  {
    get => this.m_enableCount;
    set => this.m_enableCount = value;
  }

  [DataMember(Name = "DisableCount", IsRequired = false, Order = 11)]
  public uint DisableCount
  {
    get => this.m_disableCount;
    set => this.m_disableCount = value;
  }

  [DataMember(Name = "RepublishRequestCount", IsRequired = false, Order = 12)]
  public uint RepublishRequestCount
  {
    get => this.m_republishRequestCount;
    set => this.m_republishRequestCount = value;
  }

  [DataMember(Name = "RepublishMessageRequestCount", IsRequired = false, Order = 13)]
  public uint RepublishMessageRequestCount
  {
    get => this.m_republishMessageRequestCount;
    set => this.m_republishMessageRequestCount = value;
  }

  [DataMember(Name = "RepublishMessageCount", IsRequired = false, Order = 14)]
  public uint RepublishMessageCount
  {
    get => this.m_republishMessageCount;
    set => this.m_republishMessageCount = value;
  }

  [DataMember(Name = "TransferRequestCount", IsRequired = false, Order = 15)]
  public uint TransferRequestCount
  {
    get => this.m_transferRequestCount;
    set => this.m_transferRequestCount = value;
  }

  [DataMember(Name = "TransferredToAltClientCount", IsRequired = false, Order = 16 /*0x10*/)]
  public uint TransferredToAltClientCount
  {
    get => this.m_transferredToAltClientCount;
    set => this.m_transferredToAltClientCount = value;
  }

  [DataMember(Name = "TransferredToSameClientCount", IsRequired = false, Order = 17)]
  public uint TransferredToSameClientCount
  {
    get => this.m_transferredToSameClientCount;
    set => this.m_transferredToSameClientCount = value;
  }

  [DataMember(Name = "PublishRequestCount", IsRequired = false, Order = 18)]
  public uint PublishRequestCount
  {
    get => this.m_publishRequestCount;
    set => this.m_publishRequestCount = value;
  }

  [DataMember(Name = "DataChangeNotificationsCount", IsRequired = false, Order = 19)]
  public uint DataChangeNotificationsCount
  {
    get => this.m_dataChangeNotificationsCount;
    set => this.m_dataChangeNotificationsCount = value;
  }

  [DataMember(Name = "EventNotificationsCount", IsRequired = false, Order = 20)]
  public uint EventNotificationsCount
  {
    get => this.m_eventNotificationsCount;
    set => this.m_eventNotificationsCount = value;
  }

  [DataMember(Name = "NotificationsCount", IsRequired = false, Order = 21)]
  public uint NotificationsCount
  {
    get => this.m_notificationsCount;
    set => this.m_notificationsCount = value;
  }

  [DataMember(Name = "LatePublishRequestCount", IsRequired = false, Order = 22)]
  public uint LatePublishRequestCount
  {
    get => this.m_latePublishRequestCount;
    set => this.m_latePublishRequestCount = value;
  }

  [DataMember(Name = "CurrentKeepAliveCount", IsRequired = false, Order = 23)]
  public uint CurrentKeepAliveCount
  {
    get => this.m_currentKeepAliveCount;
    set => this.m_currentKeepAliveCount = value;
  }

  [DataMember(Name = "CurrentLifetimeCount", IsRequired = false, Order = 24)]
  public uint CurrentLifetimeCount
  {
    get => this.m_currentLifetimeCount;
    set => this.m_currentLifetimeCount = value;
  }

  [DataMember(Name = "UnacknowledgedMessageCount", IsRequired = false, Order = 25)]
  public uint UnacknowledgedMessageCount
  {
    get => this.m_unacknowledgedMessageCount;
    set => this.m_unacknowledgedMessageCount = value;
  }

  [DataMember(Name = "DiscardedMessageCount", IsRequired = false, Order = 26)]
  public uint DiscardedMessageCount
  {
    get => this.m_discardedMessageCount;
    set => this.m_discardedMessageCount = value;
  }

  [DataMember(Name = "MonitoredItemCount", IsRequired = false, Order = 27)]
  public uint MonitoredItemCount
  {
    get => this.m_monitoredItemCount;
    set => this.m_monitoredItemCount = value;
  }

  [DataMember(Name = "DisabledMonitoredItemCount", IsRequired = false, Order = 28)]
  public uint DisabledMonitoredItemCount
  {
    get => this.m_disabledMonitoredItemCount;
    set => this.m_disabledMonitoredItemCount = value;
  }

  [DataMember(Name = "MonitoringQueueOverflowCount", IsRequired = false, Order = 29)]
  public uint MonitoringQueueOverflowCount
  {
    get => this.m_monitoringQueueOverflowCount;
    set => this.m_monitoringQueueOverflowCount = value;
  }

  [DataMember(Name = "NextSequenceNumber", IsRequired = false, Order = 30)]
  public uint NextSequenceNumber
  {
    get => this.m_nextSequenceNumber;
    set => this.m_nextSequenceNumber = value;
  }

  [DataMember(Name = "EventQueueOverFlowCount", IsRequired = false, Order = 31 /*0x1F*/)]
  public uint EventQueueOverFlowCount
  {
    get => this.m_eventQueueOverFlowCount;
    set => this.m_eventQueueOverFlowCount = value;
  }

  public virtual ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.SubscriptionDiagnosticsDataType;
  }

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SubscriptionDiagnosticsDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SubscriptionDiagnosticsDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SubscriptionDiagnosticsDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("SessionId", this.SessionId);
    encoder.WriteUInt32("SubscriptionId", this.SubscriptionId);
    encoder.WriteByte("Priority", this.Priority);
    encoder.WriteDouble("PublishingInterval", this.PublishingInterval);
    encoder.WriteUInt32("MaxKeepAliveCount", this.MaxKeepAliveCount);
    encoder.WriteUInt32("MaxLifetimeCount", this.MaxLifetimeCount);
    encoder.WriteUInt32("MaxNotificationsPerPublish", this.MaxNotificationsPerPublish);
    encoder.WriteBoolean("PublishingEnabled", this.PublishingEnabled);
    encoder.WriteUInt32("ModifyCount", this.ModifyCount);
    encoder.WriteUInt32("EnableCount", this.EnableCount);
    encoder.WriteUInt32("DisableCount", this.DisableCount);
    encoder.WriteUInt32("RepublishRequestCount", this.RepublishRequestCount);
    encoder.WriteUInt32("RepublishMessageRequestCount", this.RepublishMessageRequestCount);
    encoder.WriteUInt32("RepublishMessageCount", this.RepublishMessageCount);
    encoder.WriteUInt32("TransferRequestCount", this.TransferRequestCount);
    encoder.WriteUInt32("TransferredToAltClientCount", this.TransferredToAltClientCount);
    encoder.WriteUInt32("TransferredToSameClientCount", this.TransferredToSameClientCount);
    encoder.WriteUInt32("PublishRequestCount", this.PublishRequestCount);
    encoder.WriteUInt32("DataChangeNotificationsCount", this.DataChangeNotificationsCount);
    encoder.WriteUInt32("EventNotificationsCount", this.EventNotificationsCount);
    encoder.WriteUInt32("NotificationsCount", this.NotificationsCount);
    encoder.WriteUInt32("LatePublishRequestCount", this.LatePublishRequestCount);
    encoder.WriteUInt32("CurrentKeepAliveCount", this.CurrentKeepAliveCount);
    encoder.WriteUInt32("CurrentLifetimeCount", this.CurrentLifetimeCount);
    encoder.WriteUInt32("UnacknowledgedMessageCount", this.UnacknowledgedMessageCount);
    encoder.WriteUInt32("DiscardedMessageCount", this.DiscardedMessageCount);
    encoder.WriteUInt32("MonitoredItemCount", this.MonitoredItemCount);
    encoder.WriteUInt32("DisabledMonitoredItemCount", this.DisabledMonitoredItemCount);
    encoder.WriteUInt32("MonitoringQueueOverflowCount", this.MonitoringQueueOverflowCount);
    encoder.WriteUInt32("NextSequenceNumber", this.NextSequenceNumber);
    encoder.WriteUInt32("EventQueueOverFlowCount", this.EventQueueOverFlowCount);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SessionId = decoder.ReadNodeId("SessionId");
    this.SubscriptionId = decoder.ReadUInt32("SubscriptionId");
    this.Priority = decoder.ReadByte("Priority");
    this.PublishingInterval = decoder.ReadDouble("PublishingInterval");
    this.MaxKeepAliveCount = decoder.ReadUInt32("MaxKeepAliveCount");
    this.MaxLifetimeCount = decoder.ReadUInt32("MaxLifetimeCount");
    this.MaxNotificationsPerPublish = decoder.ReadUInt32("MaxNotificationsPerPublish");
    this.PublishingEnabled = decoder.ReadBoolean("PublishingEnabled");
    this.ModifyCount = decoder.ReadUInt32("ModifyCount");
    this.EnableCount = decoder.ReadUInt32("EnableCount");
    this.DisableCount = decoder.ReadUInt32("DisableCount");
    this.RepublishRequestCount = decoder.ReadUInt32("RepublishRequestCount");
    this.RepublishMessageRequestCount = decoder.ReadUInt32("RepublishMessageRequestCount");
    this.RepublishMessageCount = decoder.ReadUInt32("RepublishMessageCount");
    this.TransferRequestCount = decoder.ReadUInt32("TransferRequestCount");
    this.TransferredToAltClientCount = decoder.ReadUInt32("TransferredToAltClientCount");
    this.TransferredToSameClientCount = decoder.ReadUInt32("TransferredToSameClientCount");
    this.PublishRequestCount = decoder.ReadUInt32("PublishRequestCount");
    this.DataChangeNotificationsCount = decoder.ReadUInt32("DataChangeNotificationsCount");
    this.EventNotificationsCount = decoder.ReadUInt32("EventNotificationsCount");
    this.NotificationsCount = decoder.ReadUInt32("NotificationsCount");
    this.LatePublishRequestCount = decoder.ReadUInt32("LatePublishRequestCount");
    this.CurrentKeepAliveCount = decoder.ReadUInt32("CurrentKeepAliveCount");
    this.CurrentLifetimeCount = decoder.ReadUInt32("CurrentLifetimeCount");
    this.UnacknowledgedMessageCount = decoder.ReadUInt32("UnacknowledgedMessageCount");
    this.DiscardedMessageCount = decoder.ReadUInt32("DiscardedMessageCount");
    this.MonitoredItemCount = decoder.ReadUInt32("MonitoredItemCount");
    this.DisabledMonitoredItemCount = decoder.ReadUInt32("DisabledMonitoredItemCount");
    this.MonitoringQueueOverflowCount = decoder.ReadUInt32("MonitoringQueueOverflowCount");
    this.NextSequenceNumber = decoder.ReadUInt32("NextSequenceNumber");
    this.EventQueueOverFlowCount = decoder.ReadUInt32("EventQueueOverFlowCount");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SubscriptionDiagnosticsDataType diagnosticsDataType && Utils.IsEqual((object) this.m_sessionId, (object) diagnosticsDataType.m_sessionId) && Utils.IsEqual((object) this.m_subscriptionId, (object) diagnosticsDataType.m_subscriptionId) && Utils.IsEqual((object) this.m_priority, (object) diagnosticsDataType.m_priority) && Utils.IsEqual((object) this.m_publishingInterval, (object) diagnosticsDataType.m_publishingInterval) && Utils.IsEqual((object) this.m_maxKeepAliveCount, (object) diagnosticsDataType.m_maxKeepAliveCount) && Utils.IsEqual((object) this.m_maxLifetimeCount, (object) diagnosticsDataType.m_maxLifetimeCount) && Utils.IsEqual((object) this.m_maxNotificationsPerPublish, (object) diagnosticsDataType.m_maxNotificationsPerPublish) && Utils.IsEqual((object) this.m_publishingEnabled, (object) diagnosticsDataType.m_publishingEnabled) && Utils.IsEqual((object) this.m_modifyCount, (object) diagnosticsDataType.m_modifyCount) && Utils.IsEqual((object) this.m_enableCount, (object) diagnosticsDataType.m_enableCount) && Utils.IsEqual((object) this.m_disableCount, (object) diagnosticsDataType.m_disableCount) && Utils.IsEqual((object) this.m_republishRequestCount, (object) diagnosticsDataType.m_republishRequestCount) && Utils.IsEqual((object) this.m_republishMessageRequestCount, (object) diagnosticsDataType.m_republishMessageRequestCount) && Utils.IsEqual((object) this.m_republishMessageCount, (object) diagnosticsDataType.m_republishMessageCount) && Utils.IsEqual((object) this.m_transferRequestCount, (object) diagnosticsDataType.m_transferRequestCount) && Utils.IsEqual((object) this.m_transferredToAltClientCount, (object) diagnosticsDataType.m_transferredToAltClientCount) && Utils.IsEqual((object) this.m_transferredToSameClientCount, (object) diagnosticsDataType.m_transferredToSameClientCount) && Utils.IsEqual((object) this.m_publishRequestCount, (object) diagnosticsDataType.m_publishRequestCount) && Utils.IsEqual((object) this.m_dataChangeNotificationsCount, (object) diagnosticsDataType.m_dataChangeNotificationsCount) && Utils.IsEqual((object) this.m_eventNotificationsCount, (object) diagnosticsDataType.m_eventNotificationsCount) && Utils.IsEqual((object) this.m_notificationsCount, (object) diagnosticsDataType.m_notificationsCount) && Utils.IsEqual((object) this.m_latePublishRequestCount, (object) diagnosticsDataType.m_latePublishRequestCount) && Utils.IsEqual((object) this.m_currentKeepAliveCount, (object) diagnosticsDataType.m_currentKeepAliveCount) && Utils.IsEqual((object) this.m_currentLifetimeCount, (object) diagnosticsDataType.m_currentLifetimeCount) && Utils.IsEqual((object) this.m_unacknowledgedMessageCount, (object) diagnosticsDataType.m_unacknowledgedMessageCount) && Utils.IsEqual((object) this.m_discardedMessageCount, (object) diagnosticsDataType.m_discardedMessageCount) && Utils.IsEqual((object) this.m_monitoredItemCount, (object) diagnosticsDataType.m_monitoredItemCount) && Utils.IsEqual((object) this.m_disabledMonitoredItemCount, (object) diagnosticsDataType.m_disabledMonitoredItemCount) && Utils.IsEqual((object) this.m_monitoringQueueOverflowCount, (object) diagnosticsDataType.m_monitoringQueueOverflowCount) && Utils.IsEqual((object) this.m_nextSequenceNumber, (object) diagnosticsDataType.m_nextSequenceNumber) && Utils.IsEqual((object) this.m_eventQueueOverFlowCount, (object) diagnosticsDataType.m_eventQueueOverFlowCount);
  }

  public virtual object Clone()
  {
    return (object) (SubscriptionDiagnosticsDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    SubscriptionDiagnosticsDataType diagnosticsDataType = (SubscriptionDiagnosticsDataType) base.MemberwiseClone();
    diagnosticsDataType.m_sessionId = (NodeId) Utils.Clone((object) this.m_sessionId);
    diagnosticsDataType.m_subscriptionId = (uint) Utils.Clone((object) this.m_subscriptionId);
    diagnosticsDataType.m_priority = (byte) Utils.Clone((object) this.m_priority);
    diagnosticsDataType.m_publishingInterval = (double) Utils.Clone((object) this.m_publishingInterval);
    diagnosticsDataType.m_maxKeepAliveCount = (uint) Utils.Clone((object) this.m_maxKeepAliveCount);
    diagnosticsDataType.m_maxLifetimeCount = (uint) Utils.Clone((object) this.m_maxLifetimeCount);
    diagnosticsDataType.m_maxNotificationsPerPublish = (uint) Utils.Clone((object) this.m_maxNotificationsPerPublish);
    diagnosticsDataType.m_publishingEnabled = (bool) Utils.Clone((object) this.m_publishingEnabled);
    diagnosticsDataType.m_modifyCount = (uint) Utils.Clone((object) this.m_modifyCount);
    diagnosticsDataType.m_enableCount = (uint) Utils.Clone((object) this.m_enableCount);
    diagnosticsDataType.m_disableCount = (uint) Utils.Clone((object) this.m_disableCount);
    diagnosticsDataType.m_republishRequestCount = (uint) Utils.Clone((object) this.m_republishRequestCount);
    diagnosticsDataType.m_republishMessageRequestCount = (uint) Utils.Clone((object) this.m_republishMessageRequestCount);
    diagnosticsDataType.m_republishMessageCount = (uint) Utils.Clone((object) this.m_republishMessageCount);
    diagnosticsDataType.m_transferRequestCount = (uint) Utils.Clone((object) this.m_transferRequestCount);
    diagnosticsDataType.m_transferredToAltClientCount = (uint) Utils.Clone((object) this.m_transferredToAltClientCount);
    diagnosticsDataType.m_transferredToSameClientCount = (uint) Utils.Clone((object) this.m_transferredToSameClientCount);
    diagnosticsDataType.m_publishRequestCount = (uint) Utils.Clone((object) this.m_publishRequestCount);
    diagnosticsDataType.m_dataChangeNotificationsCount = (uint) Utils.Clone((object) this.m_dataChangeNotificationsCount);
    diagnosticsDataType.m_eventNotificationsCount = (uint) Utils.Clone((object) this.m_eventNotificationsCount);
    diagnosticsDataType.m_notificationsCount = (uint) Utils.Clone((object) this.m_notificationsCount);
    diagnosticsDataType.m_latePublishRequestCount = (uint) Utils.Clone((object) this.m_latePublishRequestCount);
    diagnosticsDataType.m_currentKeepAliveCount = (uint) Utils.Clone((object) this.m_currentKeepAliveCount);
    diagnosticsDataType.m_currentLifetimeCount = (uint) Utils.Clone((object) this.m_currentLifetimeCount);
    diagnosticsDataType.m_unacknowledgedMessageCount = (uint) Utils.Clone((object) this.m_unacknowledgedMessageCount);
    diagnosticsDataType.m_discardedMessageCount = (uint) Utils.Clone((object) this.m_discardedMessageCount);
    diagnosticsDataType.m_monitoredItemCount = (uint) Utils.Clone((object) this.m_monitoredItemCount);
    diagnosticsDataType.m_disabledMonitoredItemCount = (uint) Utils.Clone((object) this.m_disabledMonitoredItemCount);
    diagnosticsDataType.m_monitoringQueueOverflowCount = (uint) Utils.Clone((object) this.m_monitoringQueueOverflowCount);
    diagnosticsDataType.m_nextSequenceNumber = (uint) Utils.Clone((object) this.m_nextSequenceNumber);
    diagnosticsDataType.m_eventQueueOverFlowCount = (uint) Utils.Clone((object) this.m_eventQueueOverFlowCount);
    return (object) diagnosticsDataType;
  }
}
