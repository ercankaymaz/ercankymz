// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.MonitoredItem
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua.Client;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[KnownType(typeof (DataChangeFilter))]
[KnownType(typeof (EventFilter))]
[KnownType(typeof (AggregateFilter))]
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

  public MonitoredItem() => this.Initialize();

  public MonitoredItem(uint clientHandle)
  {
    this.Initialize();
    this.m_clientHandle = clientHandle;
  }

  public MonitoredItem(MonitoredItem template)
    : this(template, false)
  {
  }

  public MonitoredItem(MonitoredItem template, bool copyEventHandlers)
    : this(template, copyEventHandlers, false)
  {
  }

  public MonitoredItem(MonitoredItem template, bool copyEventHandlers, bool copyClientHandle)
  {
    this.Initialize();
    if (template == null)
      return;
    string str = template.DisplayName;
    if (str != null)
    {
      int length = str.LastIndexOf(' ');
      if (length != -1)
      {
        try
        {
          str = str.Substring(0, length);
        }
        catch
        {
        }
      }
    }
    this.m_handle = template.m_handle;
    this.m_displayName = Utils.Format("{0} {1}", (object) str, (object) this.m_clientHandle);
    this.m_startNodeId = template.m_startNodeId;
    this.m_relativePath = template.m_relativePath;
    this.m_attributeId = template.m_attributeId;
    this.m_indexRange = template.m_indexRange;
    this.m_encoding = template.m_encoding;
    this.m_monitoringMode = template.m_monitoringMode;
    this.m_samplingInterval = template.m_samplingInterval;
    this.m_filter = (MonitoringFilter) Utils.Clone((object) template.m_filter);
    this.m_queueSize = template.m_queueSize;
    this.m_discardOldest = template.m_discardOldest;
    this.m_attributesModified = true;
    if (copyEventHandlers)
      this.m_Notification = template.m_Notification;
    if (copyClientHandle)
      this.m_clientHandle = template.m_clientHandle;
    this.NodeClass = template.m_nodeClass;
  }

  [OnDeserializing]
  protected void Initialize(StreamingContext context)
  {
    this.m_cache = new object();
    this.Initialize();
  }

  private void Initialize()
  {
    this.m_startNodeId = (NodeId) null;
    this.m_relativePath = (string) null;
    this.m_clientHandle = 0U;
    this.m_attributeId = 13U;
    this.m_indexRange = (string) null;
    this.m_encoding = (QualifiedName) null;
    this.m_monitoringMode = MonitoringMode.Reporting;
    this.m_samplingInterval = -1;
    this.m_filter = (MonitoringFilter) null;
    this.m_queueSize = 0U;
    this.m_discardOldest = true;
    this.m_attributesModified = true;
    this.m_status = new MonitoredItemStatus();
    this.NodeClass = NodeClass.Variable;
    this.m_clientHandle = Utils.IncrementIdentifier(ref MonitoredItem.s_globalClientHandle);
  }

  [DataMember(Order = 1)]
  public string DisplayName
  {
    get => this.m_displayName;
    set => this.m_displayName = value;
  }

  [DataMember(Order = 2)]
  public NodeId StartNodeId
  {
    get => this.m_startNodeId;
    set => this.m_startNodeId = value;
  }

  [DataMember(Order = 3)]
  public string RelativePath
  {
    get => this.m_relativePath;
    set
    {
      if (this.m_relativePath != value)
        this.m_resolvedNodeId = (NodeId) null;
      this.m_relativePath = value;
    }
  }

  [DataMember(Order = 4)]
  public NodeClass NodeClass
  {
    get => this.m_nodeClass;
    set
    {
      if (this.m_nodeClass != value)
      {
        if ((value & (NodeClass.Object | NodeClass.View)) != NodeClass.Unspecified)
        {
          if (!(this.m_filter is EventFilter))
            this.UseDefaultEventFilter();
          if (this.QueueSize <= 1U)
            this.QueueSize = (uint) int.MaxValue;
          this.m_eventCache = new MonitoredItemEventCache(100);
          this.m_attributeId = 12U;
        }
        else
        {
          if (this.m_filter is EventFilter)
            this.m_filter = (MonitoringFilter) null;
          if (this.QueueSize == (uint) int.MaxValue)
            this.QueueSize = 1U;
          this.m_dataCache = new MonitoredItemDataCache(1);
        }
      }
      this.m_nodeClass = value;
    }
  }

  [DataMember(Order = 5)]
  public uint AttributeId
  {
    get => this.m_attributeId;
    set => this.m_attributeId = value;
  }

  [DataMember(Order = 6)]
  public string IndexRange
  {
    get => this.m_indexRange;
    set => this.m_indexRange = value;
  }

  [DataMember(Order = 7)]
  public QualifiedName Encoding
  {
    get => this.m_encoding;
    set => this.m_encoding = value;
  }

  [DataMember(Order = 8)]
  public MonitoringMode MonitoringMode
  {
    get => this.m_monitoringMode;
    set => this.m_monitoringMode = value;
  }

  [DataMember(Order = 9)]
  public int SamplingInterval
  {
    get => this.m_samplingInterval;
    set
    {
      if (this.m_samplingInterval != value)
        this.m_attributesModified = true;
      this.m_samplingInterval = value;
    }
  }

  [DataMember(Order = 10)]
  public MonitoringFilter Filter
  {
    get => this.m_filter;
    set
    {
      this.ValidateFilter(this.m_nodeClass, value);
      this.m_attributesModified = true;
      this.m_filter = value;
    }
  }

  [DataMember(Order = 11)]
  public uint QueueSize
  {
    get => this.m_queueSize;
    set
    {
      if ((int) this.m_queueSize != (int) value)
        this.m_attributesModified = true;
      this.m_queueSize = value;
    }
  }

  [DataMember(Order = 12)]
  public bool DiscardOldest
  {
    get => this.m_discardOldest;
    set
    {
      if (this.m_discardOldest != value)
        this.m_attributesModified = true;
      this.m_discardOldest = value;
    }
  }

  [DataMember(Order = 13)]
  public uint ServerId
  {
    get => this.m_status.Id;
    set => this.m_status.Id = value;
  }

  public Subscription Subscription
  {
    get => this.m_subscription;
    internal set => this.m_subscription = value;
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public bool Created => this.m_status.Created;

  public uint ClientHandle => this.m_clientHandle;

  public NodeId ResolvedNodeId
  {
    get => string.IsNullOrEmpty(this.m_relativePath) ? this.m_startNodeId : this.m_resolvedNodeId;
    internal set => this.m_resolvedNodeId = value;
  }

  public bool AttributesModified => this.m_attributesModified;

  public MonitoredItemStatus Status => this.m_status;

  public int CacheQueueSize
  {
    get
    {
      lock (this.m_cache)
      {
        if (this.m_dataCache != null)
          return this.m_dataCache.QueueSize;
        return this.m_eventCache != null ? this.m_eventCache.QueueSize : 0;
      }
    }
    set
    {
      lock (this.m_cache)
      {
        if (this.m_dataCache != null)
          this.m_dataCache.SetQueueSize(value);
        if (this.m_eventCache == null)
          return;
        this.m_eventCache.SetQueueSize(value);
      }
    }
  }

  public IEncodeable LastValue
  {
    get
    {
      lock (this.m_cache)
        return this.m_lastNotification;
    }
  }

  public IList<DataValue> DequeueValues()
  {
    lock (this.m_cache)
      return this.m_dataCache != null ? this.m_dataCache.Publish() : (IList<DataValue>) new List<DataValue>();
  }

  public IList<EventFieldList> DequeueEvents()
  {
    lock (this.m_cache)
      return this.m_eventCache != null ? this.m_eventCache.Publish() : (IList<EventFieldList>) new List<EventFieldList>();
  }

  public NotificationMessage LastMessage
  {
    get
    {
      lock (this.m_cache)
      {
        if (this.m_dataCache != null)
          return ((MonitoredItemNotification) this.m_lastNotification).Message;
        return this.m_eventCache != null ? ((EventFieldList) this.m_lastNotification).Message : (NotificationMessage) null;
      }
    }
  }

  public event MonitoredItemNotificationEventHandler Notification
  {
    add
    {
      lock (this.m_cache)
        this.m_Notification += value;
    }
    remove
    {
      lock (this.m_cache)
        this.m_Notification -= value;
    }
  }

  public void DetachNotificationEventHandlers()
  {
    lock (this.m_cache)
      this.m_Notification = (MonitoredItemNotificationEventHandler) null;
  }

  public void SaveValueInCache(IEncodeable newValue)
  {
    lock (this.m_cache)
    {
      bool flag = this.m_lastNotification == null;
      this.m_lastNotification = newValue;
      if (this.m_dataCache != null && newValue is MonitoredItemNotification notification1)
      {
        if (notification1.Value != null)
        {
          if (flag)
          {
            DateTime utcNow = DateTime.UtcNow;
            if (notification1.Value.ServerTimestamp > utcNow)
              Utils.LogWarning("Received ServerTimestamp {0} is in the future for MonitoredItemId {1}", (object) notification1.Value.ServerTimestamp.ToLocalTime(), (object) this.ClientHandle);
            if (notification1.Value.SourceTimestamp > utcNow)
              Utils.LogWarning("Received SourceTimestamp {0} is in the future for MonitoredItemId {1}", (object) notification1.Value.SourceTimestamp.ToLocalTime(), (object) this.ClientHandle);
          }
          if (notification1.Value.StatusCode.Overflow)
            Utils.LogWarning("Overflow bit set for data change with ServerTimestamp {0} and value {1} for MonitoredItemId {2}", (object) notification1.Value.ServerTimestamp.ToLocalTime(), notification1.Value.Value, (object) this.ClientHandle);
        }
        this.m_dataCache.OnNotification(notification1);
      }
      if (this.m_eventCache != null)
      {
        EventFieldList notification2 = newValue as EventFieldList;
        if (this.m_eventCache != null)
          this.m_eventCache.OnNotification(notification2);
      }
      if (this.m_Notification == null)
        return;
      this.m_Notification(this, new MonitoredItemNotificationEventArgs(newValue));
    }
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new MonitoredItem(this);

  public virtual MonitoredItem CloneMonitoredItem(bool copyEventHandlers, bool copyClientHandle)
  {
    return new MonitoredItem(this, copyEventHandlers, copyClientHandle);
  }

  public void SetError(ServiceResult error) => this.m_status.SetError(error);

  public void SetResolvePathResult(
    BrowsePathResult result,
    int index,
    DiagnosticInfoCollection diagnosticInfos,
    ResponseHeader responseHeader)
  {
    ServiceResult error = (ServiceResult) null;
    if (StatusCode.IsBad(result.StatusCode))
    {
      error = ClientBase.GetResult(result.StatusCode, index, diagnosticInfos, responseHeader);
    }
    else
    {
      this.ResolvedNodeId = NodeId.Null;
      if (result.Targets.Count > 0)
        this.ResolvedNodeId = ExpandedNodeId.ToNodeId(result.Targets[0].TargetId, this.m_subscription.Session.NamespaceUris);
    }
    this.m_status.SetResolvePathResult(result, error);
  }

  public void SetCreateResult(
    MonitoredItemCreateRequest request,
    MonitoredItemCreateResult result,
    int index,
    DiagnosticInfoCollection diagnosticInfos,
    ResponseHeader responseHeader)
  {
    ServiceResult error = (ServiceResult) null;
    if (StatusCode.IsBad(result.StatusCode))
      error = ClientBase.GetResult(result.StatusCode, index, diagnosticInfos, responseHeader);
    this.m_status.SetCreateResult(request, result, error);
    this.m_attributesModified = false;
  }

  public void SetModifyResult(
    MonitoredItemModifyRequest request,
    MonitoredItemModifyResult result,
    int index,
    DiagnosticInfoCollection diagnosticInfos,
    ResponseHeader responseHeader)
  {
    ServiceResult error = (ServiceResult) null;
    if (StatusCode.IsBad(result.StatusCode))
      error = ClientBase.GetResult(result.StatusCode, index, diagnosticInfos, responseHeader);
    this.m_status.SetModifyResult(request, result, error);
    this.m_attributesModified = false;
  }

  public void SetTransferResult(uint clientHandle)
  {
    int num = (int) Utils.LowerLimitIdentifier(ref MonitoredItem.s_globalClientHandle, clientHandle);
    this.m_clientHandle = clientHandle;
    this.m_status.SetTransferResult(this);
    this.m_attributesModified = false;
  }

  public void SetDeleteResult(
    StatusCode result,
    int index,
    DiagnosticInfoCollection diagnosticInfos,
    ResponseHeader responseHeader)
  {
    ServiceResult error = (ServiceResult) null;
    if (StatusCode.IsBad(result))
      error = ClientBase.GetResult(result, index, diagnosticInfos, responseHeader);
    this.m_status.SetDeleteResult(error);
  }

  public string GetFieldName(int index)
  {
    if (!(this.m_filter is EventFilter filter))
      return (string) null;
    if (index < 0 || index >= filter.SelectClauses.Count)
      return (string) null;
    return Utils.Format("{0}", (object) SimpleAttributeOperand.Format((IList<QualifiedName>) filter.SelectClauses[index].BrowsePath));
  }

  public object GetFieldValue(
    EventFieldList eventFields,
    NodeId eventTypeId,
    string browsePath,
    uint attributeId)
  {
    QualifiedNameCollection browsePath1 = SimpleAttributeOperand.Parse(browsePath);
    return this.GetFieldValue(eventFields, eventTypeId, (IList<QualifiedName>) browsePath1, attributeId);
  }

  public object GetFieldValue(
    EventFieldList eventFields,
    NodeId eventTypeId,
    QualifiedName browseName)
  {
    QualifiedNameCollection browsePath = new QualifiedNameCollection();
    browsePath.Add(browseName);
    return this.GetFieldValue(eventFields, eventTypeId, (IList<QualifiedName>) browsePath, 13U);
  }

  public object GetFieldValue(
    EventFieldList eventFields,
    NodeId eventTypeId,
    IList<QualifiedName> browsePath,
    uint attributeId)
  {
    if (eventFields == null)
      return (object) null;
    if (!(this.m_filter is EventFilter filter))
      return (object) null;
    for (int index1 = 0; index1 < filter.SelectClauses.Count; ++index1)
    {
      if (index1 >= eventFields.EventFields.Count)
        return (object) null;
      SimpleAttributeOperand selectClause = filter.SelectClauses[index1];
      if ((int) selectClause.AttributeId == (int) attributeId)
      {
        if (browsePath != null && browsePath.Count != 0)
        {
          if (!(selectClause.TypeDefinitionId != (object) eventTypeId) && selectClause.BrowsePath.Count == browsePath.Count)
          {
            bool flag = true;
            for (int index2 = 0; index2 < selectClause.BrowsePath.Count; ++index2)
            {
              if (selectClause.BrowsePath[index2] != browsePath[index2])
              {
                flag = false;
                break;
              }
            }
            if (flag)
              return eventFields.EventFields[index1].Value;
          }
        }
        else if (selectClause.BrowsePath == null || selectClause.BrowsePath.Count <= 0)
          return eventFields.EventFields[index1].Value;
      }
    }
    return (object) null;
  }

  public INode GetEventType(EventFieldList eventFields)
  {
    NodeId fieldValue = this.GetFieldValue(eventFields, (NodeId) 2041U, (QualifiedName) "EventType") as NodeId;
    return fieldValue != (object) null && this.m_subscription != null && this.m_subscription.Session != null ? this.m_subscription.Session.NodeCache.Find((ExpandedNodeId) fieldValue) : (INode) null;
  }

  public DateTime GetEventTime(EventFieldList eventFields)
  {
    DateTime? fieldValue = this.GetFieldValue(eventFields, (NodeId) 2041U, (QualifiedName) "Time") as DateTime?;
    return fieldValue.HasValue ? fieldValue.Value : DateTime.MinValue;
  }

  public static ServiceResult GetServiceResult(IEncodeable notification)
  {
    if (!(notification is MonitoredItemNotification itemNotification))
      return (ServiceResult) null;
    NotificationMessage message = itemNotification.Message;
    return message == null ? (ServiceResult) null : new ServiceResult(itemNotification.Value.StatusCode, itemNotification.DiagnosticInfo, (IList<string>) message.StringTable);
  }

  public static ServiceResult GetServiceResult(IEncodeable notification, int index)
  {
    if (!(notification is EventFieldList eventFieldList))
      return (ServiceResult) null;
    NotificationMessage message = eventFieldList.Message;
    if (message == null)
      return (ServiceResult) null;
    if (index < 0 || index >= eventFieldList.EventFields.Count)
      return (ServiceResult) null;
    return !(ExtensionObject.ToEncodeable(eventFieldList.EventFields[index].Value as ExtensionObject) is StatusResult encodeable) ? (ServiceResult) null : new ServiceResult(encodeable.StatusCode, encodeable.DiagnosticInfo, (IList<string>) message.StringTable);
  }

  private void ValidateFilter(NodeClass nodeClass, MonitoringFilter filter)
  {
    if (filter == null)
      return;
    switch (nodeClass)
    {
      case NodeClass.Object:
      case NodeClass.View:
        if (typeof (EventFilter).IsInstanceOfType((object) filter))
          break;
        this.m_nodeClass = NodeClass.Object;
        break;
      case NodeClass.Variable:
      case NodeClass.VariableType:
        if (typeof (DataChangeFilter).IsInstanceOfType((object) filter))
          break;
        this.m_nodeClass = NodeClass.Variable;
        break;
      default:
        throw ServiceResultException.Create(2152005632U /*0x80450000*/, "Filters may not be specified for nodes of class '{0}'.", (object) nodeClass);
    }
  }

  private void UseDefaultEventFilter()
  {
    EventFilter eventFilter1;
    EventFilter eventFilter2 = eventFilter1 = new EventFilter();
    eventFilter2.AddSelectClause((NodeId) 2041U, (QualifiedName) "EventId");
    eventFilter2.AddSelectClause((NodeId) 2041U, (QualifiedName) "EventType");
    eventFilter2.AddSelectClause((NodeId) 2041U, (QualifiedName) "SourceNode");
    eventFilter2.AddSelectClause((NodeId) 2041U, (QualifiedName) "SourceName");
    eventFilter2.AddSelectClause((NodeId) 2041U, (QualifiedName) "Time");
    eventFilter2.AddSelectClause((NodeId) 2041U, (QualifiedName) "ReceiveTime");
    eventFilter2.AddSelectClause((NodeId) 2041U, (QualifiedName) "LocalTime");
    eventFilter2.AddSelectClause((NodeId) 2041U, (QualifiedName) "Message");
    eventFilter2.AddSelectClause((NodeId) 2041U, (QualifiedName) "Severity");
    this.m_filter = (MonitoringFilter) eventFilter2;
  }

  private event MonitoredItemNotificationEventHandler m_Notification;
}
