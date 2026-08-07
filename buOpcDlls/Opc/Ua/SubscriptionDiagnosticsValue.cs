// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SubscriptionDiagnosticsValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SubscriptionDiagnosticsValue : BaseVariableValue
{
  private SubscriptionDiagnosticsDataType m_value;
  private SubscriptionDiagnosticsState m_variable;

  public SubscriptionDiagnosticsValue(
    SubscriptionDiagnosticsState variable,
    SubscriptionDiagnosticsDataType value,
    object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new SubscriptionDiagnosticsDataType();
    this.Initialize(variable);
  }

  public SubscriptionDiagnosticsState Variable => this.m_variable;

  public SubscriptionDiagnosticsDataType Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(SubscriptionDiagnosticsState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState sessionId = (BaseVariableState) this.m_variable.SessionId;
      if (sessionId != null)
      {
        sessionId.OnReadValue = new NodeValueEventHandler(this.OnRead_SessionId);
        sessionId.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SessionId);
        updateList.Add((BaseInstanceState) sessionId);
      }
      BaseVariableState subscriptionId = (BaseVariableState) this.m_variable.SubscriptionId;
      if (subscriptionId != null)
      {
        subscriptionId.OnReadValue = new NodeValueEventHandler(this.OnRead_SubscriptionId);
        subscriptionId.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SubscriptionId);
        updateList.Add((BaseInstanceState) subscriptionId);
      }
      BaseVariableState priority = (BaseVariableState) this.m_variable.Priority;
      if (priority != null)
      {
        priority.OnReadValue = new NodeValueEventHandler(this.OnRead_Priority);
        priority.OnWriteValue = new NodeValueEventHandler(this.OnWrite_Priority);
        updateList.Add((BaseInstanceState) priority);
      }
      BaseVariableState publishingInterval = (BaseVariableState) this.m_variable.PublishingInterval;
      if (publishingInterval != null)
      {
        publishingInterval.OnReadValue = new NodeValueEventHandler(this.OnRead_PublishingInterval);
        publishingInterval.OnWriteValue = new NodeValueEventHandler(this.OnWrite_PublishingInterval);
        updateList.Add((BaseInstanceState) publishingInterval);
      }
      BaseVariableState maxKeepAliveCount = (BaseVariableState) this.m_variable.MaxKeepAliveCount;
      if (maxKeepAliveCount != null)
      {
        maxKeepAliveCount.OnReadValue = new NodeValueEventHandler(this.OnRead_MaxKeepAliveCount);
        maxKeepAliveCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_MaxKeepAliveCount);
        updateList.Add((BaseInstanceState) maxKeepAliveCount);
      }
      BaseVariableState maxLifetimeCount = (BaseVariableState) this.m_variable.MaxLifetimeCount;
      if (maxLifetimeCount != null)
      {
        maxLifetimeCount.OnReadValue = new NodeValueEventHandler(this.OnRead_MaxLifetimeCount);
        maxLifetimeCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_MaxLifetimeCount);
        updateList.Add((BaseInstanceState) maxLifetimeCount);
      }
      BaseVariableState notificationsPerPublish = (BaseVariableState) this.m_variable.MaxNotificationsPerPublish;
      if (notificationsPerPublish != null)
      {
        notificationsPerPublish.OnReadValue = new NodeValueEventHandler(this.OnRead_MaxNotificationsPerPublish);
        notificationsPerPublish.OnWriteValue = new NodeValueEventHandler(this.OnWrite_MaxNotificationsPerPublish);
        updateList.Add((BaseInstanceState) notificationsPerPublish);
      }
      BaseVariableState publishingEnabled = (BaseVariableState) this.m_variable.PublishingEnabled;
      if (publishingEnabled != null)
      {
        publishingEnabled.OnReadValue = new NodeValueEventHandler(this.OnRead_PublishingEnabled);
        publishingEnabled.OnWriteValue = new NodeValueEventHandler(this.OnWrite_PublishingEnabled);
        updateList.Add((BaseInstanceState) publishingEnabled);
      }
      BaseVariableState modifyCount = (BaseVariableState) this.m_variable.ModifyCount;
      if (modifyCount != null)
      {
        modifyCount.OnReadValue = new NodeValueEventHandler(this.OnRead_ModifyCount);
        modifyCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ModifyCount);
        updateList.Add((BaseInstanceState) modifyCount);
      }
      BaseVariableState enableCount = (BaseVariableState) this.m_variable.EnableCount;
      if (enableCount != null)
      {
        enableCount.OnReadValue = new NodeValueEventHandler(this.OnRead_EnableCount);
        enableCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_EnableCount);
        updateList.Add((BaseInstanceState) enableCount);
      }
      BaseVariableState disableCount = (BaseVariableState) this.m_variable.DisableCount;
      if (disableCount != null)
      {
        disableCount.OnReadValue = new NodeValueEventHandler(this.OnRead_DisableCount);
        disableCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_DisableCount);
        updateList.Add((BaseInstanceState) disableCount);
      }
      BaseVariableState republishRequestCount = (BaseVariableState) this.m_variable.RepublishRequestCount;
      if (republishRequestCount != null)
      {
        republishRequestCount.OnReadValue = new NodeValueEventHandler(this.OnRead_RepublishRequestCount);
        republishRequestCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_RepublishRequestCount);
        updateList.Add((BaseInstanceState) republishRequestCount);
      }
      BaseVariableState messageRequestCount = (BaseVariableState) this.m_variable.RepublishMessageRequestCount;
      if (messageRequestCount != null)
      {
        messageRequestCount.OnReadValue = new NodeValueEventHandler(this.OnRead_RepublishMessageRequestCount);
        messageRequestCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_RepublishMessageRequestCount);
        updateList.Add((BaseInstanceState) messageRequestCount);
      }
      BaseVariableState republishMessageCount = (BaseVariableState) this.m_variable.RepublishMessageCount;
      if (republishMessageCount != null)
      {
        republishMessageCount.OnReadValue = new NodeValueEventHandler(this.OnRead_RepublishMessageCount);
        republishMessageCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_RepublishMessageCount);
        updateList.Add((BaseInstanceState) republishMessageCount);
      }
      BaseVariableState transferRequestCount = (BaseVariableState) this.m_variable.TransferRequestCount;
      if (transferRequestCount != null)
      {
        transferRequestCount.OnReadValue = new NodeValueEventHandler(this.OnRead_TransferRequestCount);
        transferRequestCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_TransferRequestCount);
        updateList.Add((BaseInstanceState) transferRequestCount);
      }
      BaseVariableState toAltClientCount = (BaseVariableState) this.m_variable.TransferredToAltClientCount;
      if (toAltClientCount != null)
      {
        toAltClientCount.OnReadValue = new NodeValueEventHandler(this.OnRead_TransferredToAltClientCount);
        toAltClientCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_TransferredToAltClientCount);
        updateList.Add((BaseInstanceState) toAltClientCount);
      }
      BaseVariableState toSameClientCount = (BaseVariableState) this.m_variable.TransferredToSameClientCount;
      if (toSameClientCount != null)
      {
        toSameClientCount.OnReadValue = new NodeValueEventHandler(this.OnRead_TransferredToSameClientCount);
        toSameClientCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_TransferredToSameClientCount);
        updateList.Add((BaseInstanceState) toSameClientCount);
      }
      BaseVariableState publishRequestCount1 = (BaseVariableState) this.m_variable.PublishRequestCount;
      if (publishRequestCount1 != null)
      {
        publishRequestCount1.OnReadValue = new NodeValueEventHandler(this.OnRead_PublishRequestCount);
        publishRequestCount1.OnWriteValue = new NodeValueEventHandler(this.OnWrite_PublishRequestCount);
        updateList.Add((BaseInstanceState) publishRequestCount1);
      }
      BaseVariableState notificationsCount1 = (BaseVariableState) this.m_variable.DataChangeNotificationsCount;
      if (notificationsCount1 != null)
      {
        notificationsCount1.OnReadValue = new NodeValueEventHandler(this.OnRead_DataChangeNotificationsCount);
        notificationsCount1.OnWriteValue = new NodeValueEventHandler(this.OnWrite_DataChangeNotificationsCount);
        updateList.Add((BaseInstanceState) notificationsCount1);
      }
      BaseVariableState notificationsCount2 = (BaseVariableState) this.m_variable.EventNotificationsCount;
      if (notificationsCount2 != null)
      {
        notificationsCount2.OnReadValue = new NodeValueEventHandler(this.OnRead_EventNotificationsCount);
        notificationsCount2.OnWriteValue = new NodeValueEventHandler(this.OnWrite_EventNotificationsCount);
        updateList.Add((BaseInstanceState) notificationsCount2);
      }
      BaseVariableState notificationsCount3 = (BaseVariableState) this.m_variable.NotificationsCount;
      if (notificationsCount3 != null)
      {
        notificationsCount3.OnReadValue = new NodeValueEventHandler(this.OnRead_NotificationsCount);
        notificationsCount3.OnWriteValue = new NodeValueEventHandler(this.OnWrite_NotificationsCount);
        updateList.Add((BaseInstanceState) notificationsCount3);
      }
      BaseVariableState publishRequestCount2 = (BaseVariableState) this.m_variable.LatePublishRequestCount;
      if (publishRequestCount2 != null)
      {
        publishRequestCount2.OnReadValue = new NodeValueEventHandler(this.OnRead_LatePublishRequestCount);
        publishRequestCount2.OnWriteValue = new NodeValueEventHandler(this.OnWrite_LatePublishRequestCount);
        updateList.Add((BaseInstanceState) publishRequestCount2);
      }
      BaseVariableState currentKeepAliveCount = (BaseVariableState) this.m_variable.CurrentKeepAliveCount;
      if (currentKeepAliveCount != null)
      {
        currentKeepAliveCount.OnReadValue = new NodeValueEventHandler(this.OnRead_CurrentKeepAliveCount);
        currentKeepAliveCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CurrentKeepAliveCount);
        updateList.Add((BaseInstanceState) currentKeepAliveCount);
      }
      BaseVariableState currentLifetimeCount = (BaseVariableState) this.m_variable.CurrentLifetimeCount;
      if (currentLifetimeCount != null)
      {
        currentLifetimeCount.OnReadValue = new NodeValueEventHandler(this.OnRead_CurrentLifetimeCount);
        currentLifetimeCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CurrentLifetimeCount);
        updateList.Add((BaseInstanceState) currentLifetimeCount);
      }
      BaseVariableState unacknowledgedMessageCount = (BaseVariableState) this.m_variable.UnacknowledgedMessageCount;
      if (unacknowledgedMessageCount != null)
      {
        unacknowledgedMessageCount.OnReadValue = new NodeValueEventHandler(this.OnRead_UnacknowledgedMessageCount);
        unacknowledgedMessageCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_UnacknowledgedMessageCount);
        updateList.Add((BaseInstanceState) unacknowledgedMessageCount);
      }
      BaseVariableState discardedMessageCount = (BaseVariableState) this.m_variable.DiscardedMessageCount;
      if (discardedMessageCount != null)
      {
        discardedMessageCount.OnReadValue = new NodeValueEventHandler(this.OnRead_DiscardedMessageCount);
        discardedMessageCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_DiscardedMessageCount);
        updateList.Add((BaseInstanceState) discardedMessageCount);
      }
      BaseVariableState monitoredItemCount1 = (BaseVariableState) this.m_variable.MonitoredItemCount;
      if (monitoredItemCount1 != null)
      {
        monitoredItemCount1.OnReadValue = new NodeValueEventHandler(this.OnRead_MonitoredItemCount);
        monitoredItemCount1.OnWriteValue = new NodeValueEventHandler(this.OnWrite_MonitoredItemCount);
        updateList.Add((BaseInstanceState) monitoredItemCount1);
      }
      BaseVariableState monitoredItemCount2 = (BaseVariableState) this.m_variable.DisabledMonitoredItemCount;
      if (monitoredItemCount2 != null)
      {
        monitoredItemCount2.OnReadValue = new NodeValueEventHandler(this.OnRead_DisabledMonitoredItemCount);
        monitoredItemCount2.OnWriteValue = new NodeValueEventHandler(this.OnWrite_DisabledMonitoredItemCount);
        updateList.Add((BaseInstanceState) monitoredItemCount2);
      }
      BaseVariableState queueOverflowCount = (BaseVariableState) this.m_variable.MonitoringQueueOverflowCount;
      if (queueOverflowCount != null)
      {
        queueOverflowCount.OnReadValue = new NodeValueEventHandler(this.OnRead_MonitoringQueueOverflowCount);
        queueOverflowCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_MonitoringQueueOverflowCount);
        updateList.Add((BaseInstanceState) queueOverflowCount);
      }
      BaseVariableState nextSequenceNumber = (BaseVariableState) this.m_variable.NextSequenceNumber;
      if (nextSequenceNumber != null)
      {
        nextSequenceNumber.OnReadValue = new NodeValueEventHandler(this.OnRead_NextSequenceNumber);
        nextSequenceNumber.OnWriteValue = new NodeValueEventHandler(this.OnWrite_NextSequenceNumber);
        updateList.Add((BaseInstanceState) nextSequenceNumber);
      }
      this.SetUpdateList((IList<BaseInstanceState>) updateList);
    }
  }

  protected ServiceResult OnReadValue(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      if (this.m_value != null)
        value = (object) this.m_value;
      return this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
    }
  }

  private ServiceResult OnWriteValue(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      SubscriptionDiagnosticsDataType newValue = !(value is ExtensionObject extensionObject) ? (SubscriptionDiagnosticsDataType) value : (SubscriptionDiagnosticsDataType) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (SubscriptionDiagnosticsDataType) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref SubscriptionDiagnosticsDataType newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.SessionId, (object) newValue.SessionId))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionId, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SubscriptionId, (object) newValue.SubscriptionId))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SubscriptionId, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.Priority, (object) newValue.Priority))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Priority, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.PublishingInterval, (object) newValue.PublishingInterval))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishingInterval, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.MaxKeepAliveCount, (object) newValue.MaxKeepAliveCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MaxKeepAliveCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.MaxLifetimeCount, (object) newValue.MaxLifetimeCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MaxLifetimeCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.MaxNotificationsPerPublish, (object) newValue.MaxNotificationsPerPublish))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MaxNotificationsPerPublish, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.PublishingEnabled, (object) newValue.PublishingEnabled))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishingEnabled, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ModifyCount, (object) newValue.ModifyCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ModifyCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.EnableCount, (object) newValue.EnableCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.EnableCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.DisableCount, (object) newValue.DisableCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DisableCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.RepublishRequestCount, (object) newValue.RepublishRequestCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RepublishRequestCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.RepublishMessageRequestCount, (object) newValue.RepublishMessageRequestCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RepublishMessageRequestCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.RepublishMessageCount, (object) newValue.RepublishMessageCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RepublishMessageCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.TransferRequestCount, (object) newValue.TransferRequestCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransferRequestCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.TransferredToAltClientCount, (object) newValue.TransferredToAltClientCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransferredToAltClientCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.TransferredToSameClientCount, (object) newValue.TransferredToSameClientCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransferredToSameClientCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.PublishRequestCount, (object) newValue.PublishRequestCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishRequestCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.DataChangeNotificationsCount, (object) newValue.DataChangeNotificationsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DataChangeNotificationsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.EventNotificationsCount, (object) newValue.EventNotificationsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.EventNotificationsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.NotificationsCount, (object) newValue.NotificationsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.NotificationsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.LatePublishRequestCount, (object) newValue.LatePublishRequestCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LatePublishRequestCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CurrentKeepAliveCount, (object) newValue.CurrentKeepAliveCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentKeepAliveCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CurrentLifetimeCount, (object) newValue.CurrentLifetimeCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentLifetimeCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.UnacknowledgedMessageCount, (object) newValue.UnacknowledgedMessageCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.UnacknowledgedMessageCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.DiscardedMessageCount, (object) newValue.DiscardedMessageCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DiscardedMessageCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.MonitoredItemCount, (object) newValue.MonitoredItemCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MonitoredItemCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.DisabledMonitoredItemCount, (object) newValue.DisabledMonitoredItemCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DisabledMonitoredItemCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.MonitoringQueueOverflowCount, (object) newValue.MonitoringQueueOverflowCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MonitoringQueueOverflowCount, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.NextSequenceNumber, (object) newValue.NextSequenceNumber))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.NextSequenceNumber, ref statusCode, ref timestamp);
  }

  private void UpdateParent(
    ISystemContext context,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    this.Timestamp = timestamp;
    this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
    this.m_variable.ClearChangeMasks(context, false);
  }

  private void UpdateChildVariableStatus(
    BaseVariableState child,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (child == null)
      return;
    child.StatusCode = statusCode;
    if (timestamp == DateTime.MinValue)
      timestamp = DateTime.UtcNow;
    child.Timestamp = timestamp;
  }

  private ServiceResult OnRead_SessionId(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<NodeId> sessionId = this.m_variable?.SessionId;
      if (sessionId != null && StatusCode.IsBad(sessionId.StatusCode))
      {
        value = (object) null;
        statusCode = sessionId.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SessionId;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (sessionId != null && ServiceResult.IsNotBad(status))
      {
        timestamp = sessionId.Timestamp;
        if (statusCode != sessionId.StatusCode)
        {
          statusCode = sessionId.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SessionId(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionId, ref statusCode, ref timestamp);
      this.m_value.SessionId = (NodeId) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SubscriptionId(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> subscriptionId = this.m_variable?.SubscriptionId;
      if (subscriptionId != null && StatusCode.IsBad(subscriptionId.StatusCode))
      {
        value = (object) null;
        statusCode = subscriptionId.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SubscriptionId;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (subscriptionId != null && ServiceResult.IsNotBad(status))
      {
        timestamp = subscriptionId.Timestamp;
        if (statusCode != subscriptionId.StatusCode)
        {
          statusCode = subscriptionId.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SubscriptionId(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SubscriptionId, ref statusCode, ref timestamp);
      this.m_value.SubscriptionId = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_Priority(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<byte> priority = this.m_variable?.Priority;
      if (priority != null && StatusCode.IsBad(priority.StatusCode))
      {
        value = (object) null;
        statusCode = priority.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.Priority;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (priority != null && ServiceResult.IsNotBad(status))
      {
        timestamp = priority.Timestamp;
        if (statusCode != priority.StatusCode)
        {
          statusCode = priority.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_Priority(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Priority, ref statusCode, ref timestamp);
      this.m_value.Priority = (byte) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_PublishingInterval(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<double> publishingInterval = this.m_variable?.PublishingInterval;
      if (publishingInterval != null && StatusCode.IsBad(publishingInterval.StatusCode))
      {
        value = (object) null;
        statusCode = publishingInterval.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.PublishingInterval;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (publishingInterval != null && ServiceResult.IsNotBad(status))
      {
        timestamp = publishingInterval.Timestamp;
        if (statusCode != publishingInterval.StatusCode)
        {
          statusCode = publishingInterval.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_PublishingInterval(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishingInterval, ref statusCode, ref timestamp);
      this.m_value.PublishingInterval = (double) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_MaxKeepAliveCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> maxKeepAliveCount = this.m_variable?.MaxKeepAliveCount;
      if (maxKeepAliveCount != null && StatusCode.IsBad(maxKeepAliveCount.StatusCode))
      {
        value = (object) null;
        statusCode = maxKeepAliveCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.MaxKeepAliveCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (maxKeepAliveCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = maxKeepAliveCount.Timestamp;
        if (statusCode != maxKeepAliveCount.StatusCode)
        {
          statusCode = maxKeepAliveCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_MaxKeepAliveCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MaxKeepAliveCount, ref statusCode, ref timestamp);
      this.m_value.MaxKeepAliveCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_MaxLifetimeCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> maxLifetimeCount = this.m_variable?.MaxLifetimeCount;
      if (maxLifetimeCount != null && StatusCode.IsBad(maxLifetimeCount.StatusCode))
      {
        value = (object) null;
        statusCode = maxLifetimeCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.MaxLifetimeCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (maxLifetimeCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = maxLifetimeCount.Timestamp;
        if (statusCode != maxLifetimeCount.StatusCode)
        {
          statusCode = maxLifetimeCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_MaxLifetimeCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MaxLifetimeCount, ref statusCode, ref timestamp);
      this.m_value.MaxLifetimeCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_MaxNotificationsPerPublish(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> notificationsPerPublish = this.m_variable?.MaxNotificationsPerPublish;
      if (notificationsPerPublish != null && StatusCode.IsBad(notificationsPerPublish.StatusCode))
      {
        value = (object) null;
        statusCode = notificationsPerPublish.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.MaxNotificationsPerPublish;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (notificationsPerPublish != null && ServiceResult.IsNotBad(status))
      {
        timestamp = notificationsPerPublish.Timestamp;
        if (statusCode != notificationsPerPublish.StatusCode)
        {
          statusCode = notificationsPerPublish.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_MaxNotificationsPerPublish(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MaxNotificationsPerPublish, ref statusCode, ref timestamp);
      this.m_value.MaxNotificationsPerPublish = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_PublishingEnabled(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<bool> publishingEnabled = this.m_variable?.PublishingEnabled;
      if (publishingEnabled != null && StatusCode.IsBad(publishingEnabled.StatusCode))
      {
        value = (object) null;
        statusCode = publishingEnabled.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.PublishingEnabled;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (publishingEnabled != null && ServiceResult.IsNotBad(status))
      {
        timestamp = publishingEnabled.Timestamp;
        if (statusCode != publishingEnabled.StatusCode)
        {
          statusCode = publishingEnabled.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_PublishingEnabled(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishingEnabled, ref statusCode, ref timestamp);
      this.m_value.PublishingEnabled = (bool) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ModifyCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> modifyCount = this.m_variable?.ModifyCount;
      if (modifyCount != null && StatusCode.IsBad(modifyCount.StatusCode))
      {
        value = (object) null;
        statusCode = modifyCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ModifyCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (modifyCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = modifyCount.Timestamp;
        if (statusCode != modifyCount.StatusCode)
        {
          statusCode = modifyCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ModifyCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ModifyCount, ref statusCode, ref timestamp);
      this.m_value.ModifyCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_EnableCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> enableCount = this.m_variable?.EnableCount;
      if (enableCount != null && StatusCode.IsBad(enableCount.StatusCode))
      {
        value = (object) null;
        statusCode = enableCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.EnableCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (enableCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = enableCount.Timestamp;
        if (statusCode != enableCount.StatusCode)
        {
          statusCode = enableCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_EnableCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.EnableCount, ref statusCode, ref timestamp);
      this.m_value.EnableCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_DisableCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> disableCount = this.m_variable?.DisableCount;
      if (disableCount != null && StatusCode.IsBad(disableCount.StatusCode))
      {
        value = (object) null;
        statusCode = disableCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.DisableCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (disableCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = disableCount.Timestamp;
        if (statusCode != disableCount.StatusCode)
        {
          statusCode = disableCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_DisableCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DisableCount, ref statusCode, ref timestamp);
      this.m_value.DisableCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_RepublishRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> republishRequestCount = this.m_variable?.RepublishRequestCount;
      if (republishRequestCount != null && StatusCode.IsBad(republishRequestCount.StatusCode))
      {
        value = (object) null;
        statusCode = republishRequestCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.RepublishRequestCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (republishRequestCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = republishRequestCount.Timestamp;
        if (statusCode != republishRequestCount.StatusCode)
        {
          statusCode = republishRequestCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_RepublishRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RepublishRequestCount, ref statusCode, ref timestamp);
      this.m_value.RepublishRequestCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_RepublishMessageRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> messageRequestCount = this.m_variable?.RepublishMessageRequestCount;
      if (messageRequestCount != null && StatusCode.IsBad(messageRequestCount.StatusCode))
      {
        value = (object) null;
        statusCode = messageRequestCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.RepublishMessageRequestCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (messageRequestCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = messageRequestCount.Timestamp;
        if (statusCode != messageRequestCount.StatusCode)
        {
          statusCode = messageRequestCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_RepublishMessageRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RepublishMessageRequestCount, ref statusCode, ref timestamp);
      this.m_value.RepublishMessageRequestCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_RepublishMessageCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> republishMessageCount = this.m_variable?.RepublishMessageCount;
      if (republishMessageCount != null && StatusCode.IsBad(republishMessageCount.StatusCode))
      {
        value = (object) null;
        statusCode = republishMessageCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.RepublishMessageCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (republishMessageCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = republishMessageCount.Timestamp;
        if (statusCode != republishMessageCount.StatusCode)
        {
          statusCode = republishMessageCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_RepublishMessageCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RepublishMessageCount, ref statusCode, ref timestamp);
      this.m_value.RepublishMessageCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_TransferRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> transferRequestCount = this.m_variable?.TransferRequestCount;
      if (transferRequestCount != null && StatusCode.IsBad(transferRequestCount.StatusCode))
      {
        value = (object) null;
        statusCode = transferRequestCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.TransferRequestCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (transferRequestCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = transferRequestCount.Timestamp;
        if (statusCode != transferRequestCount.StatusCode)
        {
          statusCode = transferRequestCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_TransferRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransferRequestCount, ref statusCode, ref timestamp);
      this.m_value.TransferRequestCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_TransferredToAltClientCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> toAltClientCount = this.m_variable?.TransferredToAltClientCount;
      if (toAltClientCount != null && StatusCode.IsBad(toAltClientCount.StatusCode))
      {
        value = (object) null;
        statusCode = toAltClientCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.TransferredToAltClientCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (toAltClientCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = toAltClientCount.Timestamp;
        if (statusCode != toAltClientCount.StatusCode)
        {
          statusCode = toAltClientCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_TransferredToAltClientCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransferredToAltClientCount, ref statusCode, ref timestamp);
      this.m_value.TransferredToAltClientCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_TransferredToSameClientCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> toSameClientCount = this.m_variable?.TransferredToSameClientCount;
      if (toSameClientCount != null && StatusCode.IsBad(toSameClientCount.StatusCode))
      {
        value = (object) null;
        statusCode = toSameClientCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.TransferredToSameClientCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (toSameClientCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = toSameClientCount.Timestamp;
        if (statusCode != toSameClientCount.StatusCode)
        {
          statusCode = toSameClientCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_TransferredToSameClientCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransferredToSameClientCount, ref statusCode, ref timestamp);
      this.m_value.TransferredToSameClientCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_PublishRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> publishRequestCount = this.m_variable?.PublishRequestCount;
      if (publishRequestCount != null && StatusCode.IsBad(publishRequestCount.StatusCode))
      {
        value = (object) null;
        statusCode = publishRequestCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.PublishRequestCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (publishRequestCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = publishRequestCount.Timestamp;
        if (statusCode != publishRequestCount.StatusCode)
        {
          statusCode = publishRequestCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_PublishRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishRequestCount, ref statusCode, ref timestamp);
      this.m_value.PublishRequestCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_DataChangeNotificationsCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> notificationsCount = this.m_variable?.DataChangeNotificationsCount;
      if (notificationsCount != null && StatusCode.IsBad(notificationsCount.StatusCode))
      {
        value = (object) null;
        statusCode = notificationsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.DataChangeNotificationsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (notificationsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = notificationsCount.Timestamp;
        if (statusCode != notificationsCount.StatusCode)
        {
          statusCode = notificationsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_DataChangeNotificationsCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DataChangeNotificationsCount, ref statusCode, ref timestamp);
      this.m_value.DataChangeNotificationsCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_EventNotificationsCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> notificationsCount = this.m_variable?.EventNotificationsCount;
      if (notificationsCount != null && StatusCode.IsBad(notificationsCount.StatusCode))
      {
        value = (object) null;
        statusCode = notificationsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.EventNotificationsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (notificationsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = notificationsCount.Timestamp;
        if (statusCode != notificationsCount.StatusCode)
        {
          statusCode = notificationsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_EventNotificationsCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.EventNotificationsCount, ref statusCode, ref timestamp);
      this.m_value.EventNotificationsCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_NotificationsCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> notificationsCount = this.m_variable?.NotificationsCount;
      if (notificationsCount != null && StatusCode.IsBad(notificationsCount.StatusCode))
      {
        value = (object) null;
        statusCode = notificationsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.NotificationsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (notificationsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = notificationsCount.Timestamp;
        if (statusCode != notificationsCount.StatusCode)
        {
          statusCode = notificationsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_NotificationsCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.NotificationsCount, ref statusCode, ref timestamp);
      this.m_value.NotificationsCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_LatePublishRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> publishRequestCount = this.m_variable?.LatePublishRequestCount;
      if (publishRequestCount != null && StatusCode.IsBad(publishRequestCount.StatusCode))
      {
        value = (object) null;
        statusCode = publishRequestCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.LatePublishRequestCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (publishRequestCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = publishRequestCount.Timestamp;
        if (statusCode != publishRequestCount.StatusCode)
        {
          statusCode = publishRequestCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_LatePublishRequestCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LatePublishRequestCount, ref statusCode, ref timestamp);
      this.m_value.LatePublishRequestCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CurrentKeepAliveCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> currentKeepAliveCount = this.m_variable?.CurrentKeepAliveCount;
      if (currentKeepAliveCount != null && StatusCode.IsBad(currentKeepAliveCount.StatusCode))
      {
        value = (object) null;
        statusCode = currentKeepAliveCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CurrentKeepAliveCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (currentKeepAliveCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = currentKeepAliveCount.Timestamp;
        if (statusCode != currentKeepAliveCount.StatusCode)
        {
          statusCode = currentKeepAliveCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CurrentKeepAliveCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentKeepAliveCount, ref statusCode, ref timestamp);
      this.m_value.CurrentKeepAliveCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CurrentLifetimeCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> currentLifetimeCount = this.m_variable?.CurrentLifetimeCount;
      if (currentLifetimeCount != null && StatusCode.IsBad(currentLifetimeCount.StatusCode))
      {
        value = (object) null;
        statusCode = currentLifetimeCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CurrentLifetimeCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (currentLifetimeCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = currentLifetimeCount.Timestamp;
        if (statusCode != currentLifetimeCount.StatusCode)
        {
          statusCode = currentLifetimeCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CurrentLifetimeCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentLifetimeCount, ref statusCode, ref timestamp);
      this.m_value.CurrentLifetimeCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_UnacknowledgedMessageCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> unacknowledgedMessageCount = this.m_variable?.UnacknowledgedMessageCount;
      if (unacknowledgedMessageCount != null && StatusCode.IsBad(unacknowledgedMessageCount.StatusCode))
      {
        value = (object) null;
        statusCode = unacknowledgedMessageCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.UnacknowledgedMessageCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (unacknowledgedMessageCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = unacknowledgedMessageCount.Timestamp;
        if (statusCode != unacknowledgedMessageCount.StatusCode)
        {
          statusCode = unacknowledgedMessageCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_UnacknowledgedMessageCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.UnacknowledgedMessageCount, ref statusCode, ref timestamp);
      this.m_value.UnacknowledgedMessageCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_DiscardedMessageCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> discardedMessageCount = this.m_variable?.DiscardedMessageCount;
      if (discardedMessageCount != null && StatusCode.IsBad(discardedMessageCount.StatusCode))
      {
        value = (object) null;
        statusCode = discardedMessageCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.DiscardedMessageCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (discardedMessageCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = discardedMessageCount.Timestamp;
        if (statusCode != discardedMessageCount.StatusCode)
        {
          statusCode = discardedMessageCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_DiscardedMessageCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DiscardedMessageCount, ref statusCode, ref timestamp);
      this.m_value.DiscardedMessageCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_MonitoredItemCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> monitoredItemCount = this.m_variable?.MonitoredItemCount;
      if (monitoredItemCount != null && StatusCode.IsBad(monitoredItemCount.StatusCode))
      {
        value = (object) null;
        statusCode = monitoredItemCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.MonitoredItemCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (monitoredItemCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = monitoredItemCount.Timestamp;
        if (statusCode != monitoredItemCount.StatusCode)
        {
          statusCode = monitoredItemCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_MonitoredItemCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MonitoredItemCount, ref statusCode, ref timestamp);
      this.m_value.MonitoredItemCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_DisabledMonitoredItemCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> monitoredItemCount = this.m_variable?.DisabledMonitoredItemCount;
      if (monitoredItemCount != null && StatusCode.IsBad(monitoredItemCount.StatusCode))
      {
        value = (object) null;
        statusCode = monitoredItemCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.DisabledMonitoredItemCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (monitoredItemCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = monitoredItemCount.Timestamp;
        if (statusCode != monitoredItemCount.StatusCode)
        {
          statusCode = monitoredItemCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_DisabledMonitoredItemCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DisabledMonitoredItemCount, ref statusCode, ref timestamp);
      this.m_value.DisabledMonitoredItemCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_MonitoringQueueOverflowCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> queueOverflowCount = this.m_variable?.MonitoringQueueOverflowCount;
      if (queueOverflowCount != null && StatusCode.IsBad(queueOverflowCount.StatusCode))
      {
        value = (object) null;
        statusCode = queueOverflowCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.MonitoringQueueOverflowCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (queueOverflowCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = queueOverflowCount.Timestamp;
        if (statusCode != queueOverflowCount.StatusCode)
        {
          statusCode = queueOverflowCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_MonitoringQueueOverflowCount(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MonitoringQueueOverflowCount, ref statusCode, ref timestamp);
      this.m_value.MonitoringQueueOverflowCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_NextSequenceNumber(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<uint> nextSequenceNumber = this.m_variable?.NextSequenceNumber;
      if (nextSequenceNumber != null && StatusCode.IsBad(nextSequenceNumber.StatusCode))
      {
        value = (object) null;
        statusCode = nextSequenceNumber.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.NextSequenceNumber;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (nextSequenceNumber != null && ServiceResult.IsNotBad(status))
      {
        timestamp = nextSequenceNumber.Timestamp;
        if (statusCode != nextSequenceNumber.StatusCode)
        {
          statusCode = nextSequenceNumber.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_NextSequenceNumber(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.NextSequenceNumber, ref statusCode, ref timestamp);
      this.m_value.NextSequenceNumber = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
