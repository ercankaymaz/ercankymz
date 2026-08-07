// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SubscriptionDiagnosticsState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SubscriptionDiagnosticsState(NodeState parent) : 
  BaseDataVariableState<SubscriptionDiagnosticsDataType>(parent)
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

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2172U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 874U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAIwAAAFN1YnNjcmlwdGlvbkRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQB8CAEAfAh8CAAAAQBqA/////8BAf////8fAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAH0IAC8AP30IAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABTdWJzY3JpcHRpb25JZAEAfggALwA/fggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFByaW9yaXR5AQB/CAAvAD9/CAAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHVibGlzaGluZ0ludGVydmFsAQCACAAvAD+ACAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABNYXhLZWVwQWxpdmVDb3VudAEAgQgALwA/gQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heExpZmV0aW1lQ291bnQBALgiAC8AP7giAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhOb3RpZmljYXRpb25zUGVyUHVibGlzaAEAgwgALwA/gwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFB1Ymxpc2hpbmdFbmFibGVkAQCECAAvAD+ECAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAALAAAATW9kaWZ5Q291bnQBAIUIAC8AP4UIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmFibGVDb3VudAEAhggALwA/hggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAERpc2FibGVDb3VudAEAhwgALwA/hwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlcHVibGlzaFJlcXVlc3RDb3VudAEAiAgALwA/iAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFJlcHVibGlzaE1lc3NhZ2VSZXF1ZXN0Q291bnQBAIkIAC8AP4kIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABUAAABSZXB1Ymxpc2hNZXNzYWdlQ291bnQBAIoIAC8AP4oIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABUcmFuc2ZlclJlcXVlc3RDb3VudAEAiwgALwA/iwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGwAAAFRyYW5zZmVycmVkVG9BbHRDbGllbnRDb3VudAEAjAgALwA/jAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFRyYW5zZmVycmVkVG9TYW1lQ2xpZW50Q291bnQBAI0IAC8AP40IAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQdWJsaXNoUmVxdWVzdENvdW50AQCOCAAvAD+OCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAARGF0YUNoYW5nZU5vdGlmaWNhdGlvbnNDb3VudAEAjwgALwA/jwgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAEV2ZW50Tm90aWZpY2F0aW9uc0NvdW50AQC2CwAvAD+2CwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAASAAAATm90aWZpY2F0aW9uc0NvdW50AQCRCAAvAD+RCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAATGF0ZVB1Ymxpc2hSZXF1ZXN0Q291bnQBALkiAC8AP7kiAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDdXJyZW50S2VlcEFsaXZlQ291bnQBALoiAC8AP7oiAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABDdXJyZW50TGlmZXRpbWVDb3VudAEAuyIALwA/uyIAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGgAAAFVuYWNrbm93bGVkZ2VkTWVzc2FnZUNvdW50AQC8IgAvAD+8IgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARGlzY2FyZGVkTWVzc2FnZUNvdW50AQC9IgAvAD+9IgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAASAAAATW9uaXRvcmVkSXRlbUNvdW50AQC+IgAvAD++IgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAARGlzYWJsZWRNb25pdG9yZWRJdGVtQ291bnQBAL8iAC8AP78iAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABwAAABNb25pdG9yaW5nUXVldWVPdmVyZmxvd0NvdW50AQDAIgAvAD/AIgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAASAAAATmV4dFNlcXVlbmNlTnVtYmVyAQDBIgAvAD/BIgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAARXZlbnRRdWV1ZU92ZXJmbG93Q291bnQBAMYiAC8AP8YiAAAAB/////8BAf////8AAAAA");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
  }

  public BaseDataVariableState<NodeId> SessionId
  {
    get => this.m_sessionId;
    set
    {
      if (this.m_sessionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionId = value;
    }
  }

  public BaseDataVariableState<uint> SubscriptionId
  {
    get => this.m_subscriptionId;
    set
    {
      if (this.m_subscriptionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_subscriptionId = value;
    }
  }

  public BaseDataVariableState<byte> Priority
  {
    get => this.m_priority;
    set
    {
      if (this.m_priority != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_priority = value;
    }
  }

  public BaseDataVariableState<double> PublishingInterval
  {
    get => this.m_publishingInterval;
    set
    {
      if (this.m_publishingInterval != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publishingInterval = value;
    }
  }

  public BaseDataVariableState<uint> MaxKeepAliveCount
  {
    get => this.m_maxKeepAliveCount;
    set
    {
      if (this.m_maxKeepAliveCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxKeepAliveCount = value;
    }
  }

  public BaseDataVariableState<uint> MaxLifetimeCount
  {
    get => this.m_maxLifetimeCount;
    set
    {
      if (this.m_maxLifetimeCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxLifetimeCount = value;
    }
  }

  public BaseDataVariableState<uint> MaxNotificationsPerPublish
  {
    get => this.m_maxNotificationsPerPublish;
    set
    {
      if (this.m_maxNotificationsPerPublish != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNotificationsPerPublish = value;
    }
  }

  public BaseDataVariableState<bool> PublishingEnabled
  {
    get => this.m_publishingEnabled;
    set
    {
      if (this.m_publishingEnabled != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publishingEnabled = value;
    }
  }

  public BaseDataVariableState<uint> ModifyCount
  {
    get => this.m_modifyCount;
    set
    {
      if (this.m_modifyCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_modifyCount = value;
    }
  }

  public BaseDataVariableState<uint> EnableCount
  {
    get => this.m_enableCount;
    set
    {
      if (this.m_enableCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_enableCount = value;
    }
  }

  public BaseDataVariableState<uint> DisableCount
  {
    get => this.m_disableCount;
    set
    {
      if (this.m_disableCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_disableCount = value;
    }
  }

  public BaseDataVariableState<uint> RepublishRequestCount
  {
    get => this.m_republishRequestCount;
    set
    {
      if (this.m_republishRequestCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_republishRequestCount = value;
    }
  }

  public BaseDataVariableState<uint> RepublishMessageRequestCount
  {
    get => this.m_republishMessageRequestCount;
    set
    {
      if (this.m_republishMessageRequestCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_republishMessageRequestCount = value;
    }
  }

  public BaseDataVariableState<uint> RepublishMessageCount
  {
    get => this.m_republishMessageCount;
    set
    {
      if (this.m_republishMessageCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_republishMessageCount = value;
    }
  }

  public BaseDataVariableState<uint> TransferRequestCount
  {
    get => this.m_transferRequestCount;
    set
    {
      if (this.m_transferRequestCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transferRequestCount = value;
    }
  }

  public BaseDataVariableState<uint> TransferredToAltClientCount
  {
    get => this.m_transferredToAltClientCount;
    set
    {
      if (this.m_transferredToAltClientCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transferredToAltClientCount = value;
    }
  }

  public BaseDataVariableState<uint> TransferredToSameClientCount
  {
    get => this.m_transferredToSameClientCount;
    set
    {
      if (this.m_transferredToSameClientCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transferredToSameClientCount = value;
    }
  }

  public BaseDataVariableState<uint> PublishRequestCount
  {
    get => this.m_publishRequestCount;
    set
    {
      if (this.m_publishRequestCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publishRequestCount = value;
    }
  }

  public BaseDataVariableState<uint> DataChangeNotificationsCount
  {
    get => this.m_dataChangeNotificationsCount;
    set
    {
      if (this.m_dataChangeNotificationsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataChangeNotificationsCount = value;
    }
  }

  public BaseDataVariableState<uint> EventNotificationsCount
  {
    get => this.m_eventNotificationsCount;
    set
    {
      if (this.m_eventNotificationsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_eventNotificationsCount = value;
    }
  }

  public BaseDataVariableState<uint> NotificationsCount
  {
    get => this.m_notificationsCount;
    set
    {
      if (this.m_notificationsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_notificationsCount = value;
    }
  }

  public BaseDataVariableState<uint> LatePublishRequestCount
  {
    get => this.m_latePublishRequestCount;
    set
    {
      if (this.m_latePublishRequestCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_latePublishRequestCount = value;
    }
  }

  public BaseDataVariableState<uint> CurrentKeepAliveCount
  {
    get => this.m_currentKeepAliveCount;
    set
    {
      if (this.m_currentKeepAliveCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentKeepAliveCount = value;
    }
  }

  public BaseDataVariableState<uint> CurrentLifetimeCount
  {
    get => this.m_currentLifetimeCount;
    set
    {
      if (this.m_currentLifetimeCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentLifetimeCount = value;
    }
  }

  public BaseDataVariableState<uint> UnacknowledgedMessageCount
  {
    get => this.m_unacknowledgedMessageCount;
    set
    {
      if (this.m_unacknowledgedMessageCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_unacknowledgedMessageCount = value;
    }
  }

  public BaseDataVariableState<uint> DiscardedMessageCount
  {
    get => this.m_discardedMessageCount;
    set
    {
      if (this.m_discardedMessageCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_discardedMessageCount = value;
    }
  }

  public BaseDataVariableState<uint> MonitoredItemCount
  {
    get => this.m_monitoredItemCount;
    set
    {
      if (this.m_monitoredItemCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_monitoredItemCount = value;
    }
  }

  public BaseDataVariableState<uint> DisabledMonitoredItemCount
  {
    get => this.m_disabledMonitoredItemCount;
    set
    {
      if (this.m_disabledMonitoredItemCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_disabledMonitoredItemCount = value;
    }
  }

  public BaseDataVariableState<uint> MonitoringQueueOverflowCount
  {
    get => this.m_monitoringQueueOverflowCount;
    set
    {
      if (this.m_monitoringQueueOverflowCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_monitoringQueueOverflowCount = value;
    }
  }

  public BaseDataVariableState<uint> NextSequenceNumber
  {
    get => this.m_nextSequenceNumber;
    set
    {
      if (this.m_nextSequenceNumber != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_nextSequenceNumber = value;
    }
  }

  public BaseDataVariableState<uint> EventQueueOverflowCount
  {
    get => this.m_eventQueueOverflowCount;
    set
    {
      if (this.m_eventQueueOverflowCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_eventQueueOverflowCount = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_sessionId != null)
      children.Add((BaseInstanceState) this.m_sessionId);
    if (this.m_subscriptionId != null)
      children.Add((BaseInstanceState) this.m_subscriptionId);
    if (this.m_priority != null)
      children.Add((BaseInstanceState) this.m_priority);
    if (this.m_publishingInterval != null)
      children.Add((BaseInstanceState) this.m_publishingInterval);
    if (this.m_maxKeepAliveCount != null)
      children.Add((BaseInstanceState) this.m_maxKeepAliveCount);
    if (this.m_maxLifetimeCount != null)
      children.Add((BaseInstanceState) this.m_maxLifetimeCount);
    if (this.m_maxNotificationsPerPublish != null)
      children.Add((BaseInstanceState) this.m_maxNotificationsPerPublish);
    if (this.m_publishingEnabled != null)
      children.Add((BaseInstanceState) this.m_publishingEnabled);
    if (this.m_modifyCount != null)
      children.Add((BaseInstanceState) this.m_modifyCount);
    if (this.m_enableCount != null)
      children.Add((BaseInstanceState) this.m_enableCount);
    if (this.m_disableCount != null)
      children.Add((BaseInstanceState) this.m_disableCount);
    if (this.m_republishRequestCount != null)
      children.Add((BaseInstanceState) this.m_republishRequestCount);
    if (this.m_republishMessageRequestCount != null)
      children.Add((BaseInstanceState) this.m_republishMessageRequestCount);
    if (this.m_republishMessageCount != null)
      children.Add((BaseInstanceState) this.m_republishMessageCount);
    if (this.m_transferRequestCount != null)
      children.Add((BaseInstanceState) this.m_transferRequestCount);
    if (this.m_transferredToAltClientCount != null)
      children.Add((BaseInstanceState) this.m_transferredToAltClientCount);
    if (this.m_transferredToSameClientCount != null)
      children.Add((BaseInstanceState) this.m_transferredToSameClientCount);
    if (this.m_publishRequestCount != null)
      children.Add((BaseInstanceState) this.m_publishRequestCount);
    if (this.m_dataChangeNotificationsCount != null)
      children.Add((BaseInstanceState) this.m_dataChangeNotificationsCount);
    if (this.m_eventNotificationsCount != null)
      children.Add((BaseInstanceState) this.m_eventNotificationsCount);
    if (this.m_notificationsCount != null)
      children.Add((BaseInstanceState) this.m_notificationsCount);
    if (this.m_latePublishRequestCount != null)
      children.Add((BaseInstanceState) this.m_latePublishRequestCount);
    if (this.m_currentKeepAliveCount != null)
      children.Add((BaseInstanceState) this.m_currentKeepAliveCount);
    if (this.m_currentLifetimeCount != null)
      children.Add((BaseInstanceState) this.m_currentLifetimeCount);
    if (this.m_unacknowledgedMessageCount != null)
      children.Add((BaseInstanceState) this.m_unacknowledgedMessageCount);
    if (this.m_discardedMessageCount != null)
      children.Add((BaseInstanceState) this.m_discardedMessageCount);
    if (this.m_monitoredItemCount != null)
      children.Add((BaseInstanceState) this.m_monitoredItemCount);
    if (this.m_disabledMonitoredItemCount != null)
      children.Add((BaseInstanceState) this.m_disabledMonitoredItemCount);
    if (this.m_monitoringQueueOverflowCount != null)
      children.Add((BaseInstanceState) this.m_monitoringQueueOverflowCount);
    if (this.m_nextSequenceNumber != null)
      children.Add((BaseInstanceState) this.m_nextSequenceNumber);
    if (this.m_eventQueueOverflowCount != null)
      children.Add((BaseInstanceState) this.m_eventQueueOverflowCount);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    string name = browseName.Name;
    if (name != null)
    {
      switch (name.Length)
      {
        case 8:
          if (name == "Priority")
          {
            if (createOrReplace && this.Priority == null)
              this.Priority = replacement != null ? (BaseDataVariableState<byte>) replacement : new BaseDataVariableState<byte>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Priority;
            break;
          }
          break;
        case 9:
          if (name == "SessionId")
          {
            if (createOrReplace && this.SessionId == null)
              this.SessionId = replacement != null ? (BaseDataVariableState<NodeId>) replacement : new BaseDataVariableState<NodeId>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SessionId;
            break;
          }
          break;
        case 11:
          switch (name[0])
          {
            case 'E':
              if (name == "EnableCount")
              {
                if (createOrReplace && this.EnableCount == null)
                  this.EnableCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.EnableCount;
                break;
              }
              break;
            case 'M':
              if (name == "ModifyCount")
              {
                if (createOrReplace && this.ModifyCount == null)
                  this.ModifyCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ModifyCount;
                break;
              }
              break;
          }
          break;
        case 12:
          if (name == "DisableCount")
          {
            if (createOrReplace && this.DisableCount == null)
              this.DisableCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.DisableCount;
            break;
          }
          break;
        case 14:
          if (name == "SubscriptionId")
          {
            if (createOrReplace && this.SubscriptionId == null)
              this.SubscriptionId = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SubscriptionId;
            break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "MaxLifetimeCount")
          {
            if (createOrReplace && this.MaxLifetimeCount == null)
              this.MaxLifetimeCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxLifetimeCount;
            break;
          }
          break;
        case 17:
          switch (name[0])
          {
            case 'M':
              if (name == "MaxKeepAliveCount")
              {
                if (createOrReplace && this.MaxKeepAliveCount == null)
                  this.MaxKeepAliveCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxKeepAliveCount;
                break;
              }
              break;
            case 'P':
              if (name == "PublishingEnabled")
              {
                if (createOrReplace && this.PublishingEnabled == null)
                  this.PublishingEnabled = replacement != null ? (BaseDataVariableState<bool>) replacement : new BaseDataVariableState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.PublishingEnabled;
                break;
              }
              break;
          }
          break;
        case 18:
          switch (name[2])
          {
            case 'b':
              if (name == "PublishingInterval")
              {
                if (createOrReplace && this.PublishingInterval == null)
                  this.PublishingInterval = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.PublishingInterval;
                break;
              }
              break;
            case 'n':
              if (name == "MonitoredItemCount")
              {
                if (createOrReplace && this.MonitoredItemCount == null)
                  this.MonitoredItemCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MonitoredItemCount;
                break;
              }
              break;
            case 't':
              if (name == "NotificationsCount")
              {
                if (createOrReplace && this.NotificationsCount == null)
                  this.NotificationsCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.NotificationsCount;
                break;
              }
              break;
            case 'x':
              if (name == "NextSequenceNumber")
              {
                if (createOrReplace && this.NextSequenceNumber == null)
                  this.NextSequenceNumber = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.NextSequenceNumber;
                break;
              }
              break;
          }
          break;
        case 19:
          if (name == "PublishRequestCount")
          {
            if (createOrReplace && this.PublishRequestCount == null)
              this.PublishRequestCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.PublishRequestCount;
            break;
          }
          break;
        case 20:
          switch (name[0])
          {
            case 'C':
              if (name == "CurrentLifetimeCount")
              {
                if (createOrReplace && this.CurrentLifetimeCount == null)
                  this.CurrentLifetimeCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CurrentLifetimeCount;
                break;
              }
              break;
            case 'T':
              if (name == "TransferRequestCount")
              {
                if (createOrReplace && this.TransferRequestCount == null)
                  this.TransferRequestCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.TransferRequestCount;
                break;
              }
              break;
          }
          break;
        case 21:
          switch (name[0])
          {
            case 'C':
              if (name == "CurrentKeepAliveCount")
              {
                if (createOrReplace && this.CurrentKeepAliveCount == null)
                  this.CurrentKeepAliveCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CurrentKeepAliveCount;
                break;
              }
              break;
            case 'D':
              if (name == "DiscardedMessageCount")
              {
                if (createOrReplace && this.DiscardedMessageCount == null)
                  this.DiscardedMessageCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DiscardedMessageCount;
                break;
              }
              break;
            case 'R':
              switch (name)
              {
                case "RepublishRequestCount":
                  if (createOrReplace && this.RepublishRequestCount == null)
                    this.RepublishRequestCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                  baseInstanceState = (BaseInstanceState) this.RepublishRequestCount;
                  break;
                case "RepublishMessageCount":
                  if (createOrReplace && this.RepublishMessageCount == null)
                    this.RepublishMessageCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                  baseInstanceState = (BaseInstanceState) this.RepublishMessageCount;
                  break;
              }
              break;
          }
          break;
        case 23:
          switch (name[5])
          {
            case 'N':
              if (name == "EventNotificationsCount")
              {
                if (createOrReplace && this.EventNotificationsCount == null)
                  this.EventNotificationsCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.EventNotificationsCount;
                break;
              }
              break;
            case 'Q':
              if (name == "EventQueueOverflowCount")
              {
                if (createOrReplace && this.EventQueueOverflowCount == null)
                  this.EventQueueOverflowCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.EventQueueOverflowCount;
                break;
              }
              break;
            case 'u':
              if (name == "LatePublishRequestCount")
              {
                if (createOrReplace && this.LatePublishRequestCount == null)
                  this.LatePublishRequestCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LatePublishRequestCount;
                break;
              }
              break;
          }
          break;
        case 26:
          switch (name[0])
          {
            case 'D':
              if (name == "DisabledMonitoredItemCount")
              {
                if (createOrReplace && this.DisabledMonitoredItemCount == null)
                  this.DisabledMonitoredItemCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DisabledMonitoredItemCount;
                break;
              }
              break;
            case 'M':
              if (name == "MaxNotificationsPerPublish")
              {
                if (createOrReplace && this.MaxNotificationsPerPublish == null)
                  this.MaxNotificationsPerPublish = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxNotificationsPerPublish;
                break;
              }
              break;
            case 'U':
              if (name == "UnacknowledgedMessageCount")
              {
                if (createOrReplace && this.UnacknowledgedMessageCount == null)
                  this.UnacknowledgedMessageCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.UnacknowledgedMessageCount;
                break;
              }
              break;
          }
          break;
        case 27:
          if (name == "TransferredToAltClientCount")
          {
            if (createOrReplace && this.TransferredToAltClientCount == null)
              this.TransferredToAltClientCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.TransferredToAltClientCount;
            break;
          }
          break;
        case 28:
          switch (name[0])
          {
            case 'D':
              if (name == "DataChangeNotificationsCount")
              {
                if (createOrReplace && this.DataChangeNotificationsCount == null)
                  this.DataChangeNotificationsCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DataChangeNotificationsCount;
                break;
              }
              break;
            case 'M':
              if (name == "MonitoringQueueOverflowCount")
              {
                if (createOrReplace && this.MonitoringQueueOverflowCount == null)
                  this.MonitoringQueueOverflowCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MonitoringQueueOverflowCount;
                break;
              }
              break;
            case 'R':
              if (name == "RepublishMessageRequestCount")
              {
                if (createOrReplace && this.RepublishMessageRequestCount == null)
                  this.RepublishMessageRequestCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.RepublishMessageRequestCount;
                break;
              }
              break;
            case 'T':
              if (name == "TransferredToSameClientCount")
              {
                if (createOrReplace && this.TransferredToSameClientCount == null)
                  this.TransferredToSameClientCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.TransferredToSameClientCount;
                break;
              }
              break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
