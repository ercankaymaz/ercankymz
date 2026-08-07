// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionDiagnosticsVariableValue
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
public class SessionDiagnosticsVariableValue : BaseVariableValue
{
  private SessionDiagnosticsDataType m_value;
  private SessionDiagnosticsVariableState m_variable;

  public SessionDiagnosticsVariableValue(
    SessionDiagnosticsVariableState variable,
    SessionDiagnosticsDataType value,
    object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new SessionDiagnosticsDataType();
    this.Initialize(variable);
  }

  public SessionDiagnosticsVariableState Variable => this.m_variable;

  public SessionDiagnosticsDataType Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(SessionDiagnosticsVariableState variable)
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
      BaseVariableState sessionName = (BaseVariableState) this.m_variable.SessionName;
      if (sessionName != null)
      {
        sessionName.OnReadValue = new NodeValueEventHandler(this.OnRead_SessionName);
        sessionName.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SessionName);
        updateList.Add((BaseInstanceState) sessionName);
      }
      BaseVariableState clientDescription = (BaseVariableState) this.m_variable.ClientDescription;
      if (clientDescription != null)
      {
        clientDescription.OnReadValue = new NodeValueEventHandler(this.OnRead_ClientDescription);
        clientDescription.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ClientDescription);
        updateList.Add((BaseInstanceState) clientDescription);
      }
      BaseVariableState serverUri = (BaseVariableState) this.m_variable.ServerUri;
      if (serverUri != null)
      {
        serverUri.OnReadValue = new NodeValueEventHandler(this.OnRead_ServerUri);
        serverUri.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ServerUri);
        updateList.Add((BaseInstanceState) serverUri);
      }
      BaseVariableState endpointUrl = (BaseVariableState) this.m_variable.EndpointUrl;
      if (endpointUrl != null)
      {
        endpointUrl.OnReadValue = new NodeValueEventHandler(this.OnRead_EndpointUrl);
        endpointUrl.OnWriteValue = new NodeValueEventHandler(this.OnWrite_EndpointUrl);
        updateList.Add((BaseInstanceState) endpointUrl);
      }
      BaseVariableState localeIds = (BaseVariableState) this.m_variable.LocaleIds;
      if (localeIds != null)
      {
        localeIds.OnReadValue = new NodeValueEventHandler(this.OnRead_LocaleIds);
        localeIds.OnWriteValue = new NodeValueEventHandler(this.OnWrite_LocaleIds);
        updateList.Add((BaseInstanceState) localeIds);
      }
      BaseVariableState actualSessionTimeout = (BaseVariableState) this.m_variable.ActualSessionTimeout;
      if (actualSessionTimeout != null)
      {
        actualSessionTimeout.OnReadValue = new NodeValueEventHandler(this.OnRead_ActualSessionTimeout);
        actualSessionTimeout.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ActualSessionTimeout);
        updateList.Add((BaseInstanceState) actualSessionTimeout);
      }
      BaseVariableState responseMessageSize = (BaseVariableState) this.m_variable.MaxResponseMessageSize;
      if (responseMessageSize != null)
      {
        responseMessageSize.OnReadValue = new NodeValueEventHandler(this.OnRead_MaxResponseMessageSize);
        responseMessageSize.OnWriteValue = new NodeValueEventHandler(this.OnWrite_MaxResponseMessageSize);
        updateList.Add((BaseInstanceState) responseMessageSize);
      }
      BaseVariableState clientConnectionTime = (BaseVariableState) this.m_variable.ClientConnectionTime;
      if (clientConnectionTime != null)
      {
        clientConnectionTime.OnReadValue = new NodeValueEventHandler(this.OnRead_ClientConnectionTime);
        clientConnectionTime.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ClientConnectionTime);
        updateList.Add((BaseInstanceState) clientConnectionTime);
      }
      BaseVariableState clientLastContactTime = (BaseVariableState) this.m_variable.ClientLastContactTime;
      if (clientLastContactTime != null)
      {
        clientLastContactTime.OnReadValue = new NodeValueEventHandler(this.OnRead_ClientLastContactTime);
        clientLastContactTime.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ClientLastContactTime);
        updateList.Add((BaseInstanceState) clientLastContactTime);
      }
      BaseVariableState subscriptionsCount1 = (BaseVariableState) this.m_variable.CurrentSubscriptionsCount;
      if (subscriptionsCount1 != null)
      {
        subscriptionsCount1.OnReadValue = new NodeValueEventHandler(this.OnRead_CurrentSubscriptionsCount);
        subscriptionsCount1.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CurrentSubscriptionsCount);
        updateList.Add((BaseInstanceState) subscriptionsCount1);
      }
      BaseVariableState monitoredItemsCount1 = (BaseVariableState) this.m_variable.CurrentMonitoredItemsCount;
      if (monitoredItemsCount1 != null)
      {
        monitoredItemsCount1.OnReadValue = new NodeValueEventHandler(this.OnRead_CurrentMonitoredItemsCount);
        monitoredItemsCount1.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CurrentMonitoredItemsCount);
        updateList.Add((BaseInstanceState) monitoredItemsCount1);
      }
      BaseVariableState publishRequestsInQueue = (BaseVariableState) this.m_variable.CurrentPublishRequestsInQueue;
      if (publishRequestsInQueue != null)
      {
        publishRequestsInQueue.OnReadValue = new NodeValueEventHandler(this.OnRead_CurrentPublishRequestsInQueue);
        publishRequestsInQueue.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CurrentPublishRequestsInQueue);
        updateList.Add((BaseInstanceState) publishRequestsInQueue);
      }
      BaseVariableState totalRequestCount = (BaseVariableState) this.m_variable.TotalRequestCount;
      if (totalRequestCount != null)
      {
        totalRequestCount.OnReadValue = new NodeValueEventHandler(this.OnRead_TotalRequestCount);
        totalRequestCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_TotalRequestCount);
        updateList.Add((BaseInstanceState) totalRequestCount);
      }
      BaseVariableState unauthorizedRequestCount = (BaseVariableState) this.m_variable.UnauthorizedRequestCount;
      if (unauthorizedRequestCount != null)
      {
        unauthorizedRequestCount.OnReadValue = new NodeValueEventHandler(this.OnRead_UnauthorizedRequestCount);
        unauthorizedRequestCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_UnauthorizedRequestCount);
        updateList.Add((BaseInstanceState) unauthorizedRequestCount);
      }
      BaseVariableState readCount = (BaseVariableState) this.m_variable.ReadCount;
      if (readCount != null)
      {
        readCount.OnReadValue = new NodeValueEventHandler(this.OnRead_ReadCount);
        readCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ReadCount);
        updateList.Add((BaseInstanceState) readCount);
      }
      BaseVariableState historyReadCount = (BaseVariableState) this.m_variable.HistoryReadCount;
      if (historyReadCount != null)
      {
        historyReadCount.OnReadValue = new NodeValueEventHandler(this.OnRead_HistoryReadCount);
        historyReadCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_HistoryReadCount);
        updateList.Add((BaseInstanceState) historyReadCount);
      }
      BaseVariableState writeCount = (BaseVariableState) this.m_variable.WriteCount;
      if (writeCount != null)
      {
        writeCount.OnReadValue = new NodeValueEventHandler(this.OnRead_WriteCount);
        writeCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_WriteCount);
        updateList.Add((BaseInstanceState) writeCount);
      }
      BaseVariableState historyUpdateCount = (BaseVariableState) this.m_variable.HistoryUpdateCount;
      if (historyUpdateCount != null)
      {
        historyUpdateCount.OnReadValue = new NodeValueEventHandler(this.OnRead_HistoryUpdateCount);
        historyUpdateCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_HistoryUpdateCount);
        updateList.Add((BaseInstanceState) historyUpdateCount);
      }
      BaseVariableState callCount = (BaseVariableState) this.m_variable.CallCount;
      if (callCount != null)
      {
        callCount.OnReadValue = new NodeValueEventHandler(this.OnRead_CallCount);
        callCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CallCount);
        updateList.Add((BaseInstanceState) callCount);
      }
      BaseVariableState monitoredItemsCount2 = (BaseVariableState) this.m_variable.CreateMonitoredItemsCount;
      if (monitoredItemsCount2 != null)
      {
        monitoredItemsCount2.OnReadValue = new NodeValueEventHandler(this.OnRead_CreateMonitoredItemsCount);
        monitoredItemsCount2.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CreateMonitoredItemsCount);
        updateList.Add((BaseInstanceState) monitoredItemsCount2);
      }
      BaseVariableState monitoredItemsCount3 = (BaseVariableState) this.m_variable.ModifyMonitoredItemsCount;
      if (monitoredItemsCount3 != null)
      {
        monitoredItemsCount3.OnReadValue = new NodeValueEventHandler(this.OnRead_ModifyMonitoredItemsCount);
        monitoredItemsCount3.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ModifyMonitoredItemsCount);
        updateList.Add((BaseInstanceState) monitoredItemsCount3);
      }
      BaseVariableState monitoringModeCount = (BaseVariableState) this.m_variable.SetMonitoringModeCount;
      if (monitoringModeCount != null)
      {
        monitoringModeCount.OnReadValue = new NodeValueEventHandler(this.OnRead_SetMonitoringModeCount);
        monitoringModeCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SetMonitoringModeCount);
        updateList.Add((BaseInstanceState) monitoringModeCount);
      }
      BaseVariableState setTriggeringCount = (BaseVariableState) this.m_variable.SetTriggeringCount;
      if (setTriggeringCount != null)
      {
        setTriggeringCount.OnReadValue = new NodeValueEventHandler(this.OnRead_SetTriggeringCount);
        setTriggeringCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SetTriggeringCount);
        updateList.Add((BaseInstanceState) setTriggeringCount);
      }
      BaseVariableState monitoredItemsCount4 = (BaseVariableState) this.m_variable.DeleteMonitoredItemsCount;
      if (monitoredItemsCount4 != null)
      {
        monitoredItemsCount4.OnReadValue = new NodeValueEventHandler(this.OnRead_DeleteMonitoredItemsCount);
        monitoredItemsCount4.OnWriteValue = new NodeValueEventHandler(this.OnWrite_DeleteMonitoredItemsCount);
        updateList.Add((BaseInstanceState) monitoredItemsCount4);
      }
      BaseVariableState subscriptionCount1 = (BaseVariableState) this.m_variable.CreateSubscriptionCount;
      if (subscriptionCount1 != null)
      {
        subscriptionCount1.OnReadValue = new NodeValueEventHandler(this.OnRead_CreateSubscriptionCount);
        subscriptionCount1.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CreateSubscriptionCount);
        updateList.Add((BaseInstanceState) subscriptionCount1);
      }
      BaseVariableState subscriptionCount2 = (BaseVariableState) this.m_variable.ModifySubscriptionCount;
      if (subscriptionCount2 != null)
      {
        subscriptionCount2.OnReadValue = new NodeValueEventHandler(this.OnRead_ModifySubscriptionCount);
        subscriptionCount2.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ModifySubscriptionCount);
        updateList.Add((BaseInstanceState) subscriptionCount2);
      }
      BaseVariableState publishingModeCount = (BaseVariableState) this.m_variable.SetPublishingModeCount;
      if (publishingModeCount != null)
      {
        publishingModeCount.OnReadValue = new NodeValueEventHandler(this.OnRead_SetPublishingModeCount);
        publishingModeCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SetPublishingModeCount);
        updateList.Add((BaseInstanceState) publishingModeCount);
      }
      BaseVariableState publishCount = (BaseVariableState) this.m_variable.PublishCount;
      if (publishCount != null)
      {
        publishCount.OnReadValue = new NodeValueEventHandler(this.OnRead_PublishCount);
        publishCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_PublishCount);
        updateList.Add((BaseInstanceState) publishCount);
      }
      BaseVariableState republishCount = (BaseVariableState) this.m_variable.RepublishCount;
      if (republishCount != null)
      {
        republishCount.OnReadValue = new NodeValueEventHandler(this.OnRead_RepublishCount);
        republishCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_RepublishCount);
        updateList.Add((BaseInstanceState) republishCount);
      }
      BaseVariableState subscriptionsCount2 = (BaseVariableState) this.m_variable.TransferSubscriptionsCount;
      if (subscriptionsCount2 != null)
      {
        subscriptionsCount2.OnReadValue = new NodeValueEventHandler(this.OnRead_TransferSubscriptionsCount);
        subscriptionsCount2.OnWriteValue = new NodeValueEventHandler(this.OnWrite_TransferSubscriptionsCount);
        updateList.Add((BaseInstanceState) subscriptionsCount2);
      }
      BaseVariableState subscriptionsCount3 = (BaseVariableState) this.m_variable.DeleteSubscriptionsCount;
      if (subscriptionsCount3 != null)
      {
        subscriptionsCount3.OnReadValue = new NodeValueEventHandler(this.OnRead_DeleteSubscriptionsCount);
        subscriptionsCount3.OnWriteValue = new NodeValueEventHandler(this.OnWrite_DeleteSubscriptionsCount);
        updateList.Add((BaseInstanceState) subscriptionsCount3);
      }
      BaseVariableState addNodesCount = (BaseVariableState) this.m_variable.AddNodesCount;
      if (addNodesCount != null)
      {
        addNodesCount.OnReadValue = new NodeValueEventHandler(this.OnRead_AddNodesCount);
        addNodesCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_AddNodesCount);
        updateList.Add((BaseInstanceState) addNodesCount);
      }
      BaseVariableState addReferencesCount = (BaseVariableState) this.m_variable.AddReferencesCount;
      if (addReferencesCount != null)
      {
        addReferencesCount.OnReadValue = new NodeValueEventHandler(this.OnRead_AddReferencesCount);
        addReferencesCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_AddReferencesCount);
        updateList.Add((BaseInstanceState) addReferencesCount);
      }
      BaseVariableState deleteNodesCount = (BaseVariableState) this.m_variable.DeleteNodesCount;
      if (deleteNodesCount != null)
      {
        deleteNodesCount.OnReadValue = new NodeValueEventHandler(this.OnRead_DeleteNodesCount);
        deleteNodesCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_DeleteNodesCount);
        updateList.Add((BaseInstanceState) deleteNodesCount);
      }
      BaseVariableState deleteReferencesCount = (BaseVariableState) this.m_variable.DeleteReferencesCount;
      if (deleteReferencesCount != null)
      {
        deleteReferencesCount.OnReadValue = new NodeValueEventHandler(this.OnRead_DeleteReferencesCount);
        deleteReferencesCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_DeleteReferencesCount);
        updateList.Add((BaseInstanceState) deleteReferencesCount);
      }
      BaseVariableState browseCount = (BaseVariableState) this.m_variable.BrowseCount;
      if (browseCount != null)
      {
        browseCount.OnReadValue = new NodeValueEventHandler(this.OnRead_BrowseCount);
        browseCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_BrowseCount);
        updateList.Add((BaseInstanceState) browseCount);
      }
      BaseVariableState browseNextCount = (BaseVariableState) this.m_variable.BrowseNextCount;
      if (browseNextCount != null)
      {
        browseNextCount.OnReadValue = new NodeValueEventHandler(this.OnRead_BrowseNextCount);
        browseNextCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_BrowseNextCount);
        updateList.Add((BaseInstanceState) browseNextCount);
      }
      BaseVariableState pathsToNodeIdsCount = (BaseVariableState) this.m_variable.TranslateBrowsePathsToNodeIdsCount;
      if (pathsToNodeIdsCount != null)
      {
        pathsToNodeIdsCount.OnReadValue = new NodeValueEventHandler(this.OnRead_TranslateBrowsePathsToNodeIdsCount);
        pathsToNodeIdsCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_TranslateBrowsePathsToNodeIdsCount);
        updateList.Add((BaseInstanceState) pathsToNodeIdsCount);
      }
      BaseVariableState queryFirstCount = (BaseVariableState) this.m_variable.QueryFirstCount;
      if (queryFirstCount != null)
      {
        queryFirstCount.OnReadValue = new NodeValueEventHandler(this.OnRead_QueryFirstCount);
        queryFirstCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_QueryFirstCount);
        updateList.Add((BaseInstanceState) queryFirstCount);
      }
      BaseVariableState queryNextCount = (BaseVariableState) this.m_variable.QueryNextCount;
      if (queryNextCount != null)
      {
        queryNextCount.OnReadValue = new NodeValueEventHandler(this.OnRead_QueryNextCount);
        queryNextCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_QueryNextCount);
        updateList.Add((BaseInstanceState) queryNextCount);
      }
      BaseVariableState registerNodesCount = (BaseVariableState) this.m_variable.RegisterNodesCount;
      if (registerNodesCount != null)
      {
        registerNodesCount.OnReadValue = new NodeValueEventHandler(this.OnRead_RegisterNodesCount);
        registerNodesCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_RegisterNodesCount);
        updateList.Add((BaseInstanceState) registerNodesCount);
      }
      BaseVariableState unregisterNodesCount = (BaseVariableState) this.m_variable.UnregisterNodesCount;
      if (unregisterNodesCount != null)
      {
        unregisterNodesCount.OnReadValue = new NodeValueEventHandler(this.OnRead_UnregisterNodesCount);
        unregisterNodesCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_UnregisterNodesCount);
        updateList.Add((BaseInstanceState) unregisterNodesCount);
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
      SessionDiagnosticsDataType newValue = !(value is ExtensionObject extensionObject) ? (SessionDiagnosticsDataType) value : (SessionDiagnosticsDataType) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (SessionDiagnosticsDataType) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref SessionDiagnosticsDataType newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.SessionId, (object) newValue.SessionId))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionId, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SessionName, (object) newValue.SessionName))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionName, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ClientDescription, (object) newValue.ClientDescription))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientDescription, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ServerUri, (object) newValue.ServerUri))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ServerUri, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.EndpointUrl, (object) newValue.EndpointUrl))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.EndpointUrl, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.LocaleIds, (object) newValue.LocaleIds))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LocaleIds, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ActualSessionTimeout, (object) newValue.ActualSessionTimeout))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ActualSessionTimeout, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.MaxResponseMessageSize, (object) newValue.MaxResponseMessageSize))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MaxResponseMessageSize, ref statusCode, ref timestamp);
    if (!Utils.IsEqual(this.m_value.ClientConnectionTime, newValue.ClientConnectionTime))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientConnectionTime, ref statusCode, ref timestamp);
    if (!Utils.IsEqual(this.m_value.ClientLastContactTime, newValue.ClientLastContactTime))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientLastContactTime, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CurrentSubscriptionsCount, (object) newValue.CurrentSubscriptionsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentSubscriptionsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CurrentMonitoredItemsCount, (object) newValue.CurrentMonitoredItemsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentMonitoredItemsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CurrentPublishRequestsInQueue, (object) newValue.CurrentPublishRequestsInQueue))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentPublishRequestsInQueue, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.TotalRequestCount, (object) newValue.TotalRequestCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TotalRequestCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.UnauthorizedRequestCount, (object) newValue.UnauthorizedRequestCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.UnauthorizedRequestCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ReadCount, (object) newValue.ReadCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ReadCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.HistoryReadCount, (object) newValue.HistoryReadCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.HistoryReadCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.WriteCount, (object) newValue.WriteCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.WriteCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.HistoryUpdateCount, (object) newValue.HistoryUpdateCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.HistoryUpdateCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CallCount, (object) newValue.CallCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CallCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CreateMonitoredItemsCount, (object) newValue.CreateMonitoredItemsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CreateMonitoredItemsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ModifyMonitoredItemsCount, (object) newValue.ModifyMonitoredItemsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ModifyMonitoredItemsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SetMonitoringModeCount, (object) newValue.SetMonitoringModeCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SetMonitoringModeCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SetTriggeringCount, (object) newValue.SetTriggeringCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SetTriggeringCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.DeleteMonitoredItemsCount, (object) newValue.DeleteMonitoredItemsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DeleteMonitoredItemsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CreateSubscriptionCount, (object) newValue.CreateSubscriptionCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CreateSubscriptionCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ModifySubscriptionCount, (object) newValue.ModifySubscriptionCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ModifySubscriptionCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SetPublishingModeCount, (object) newValue.SetPublishingModeCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SetPublishingModeCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.PublishCount, (object) newValue.PublishCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.RepublishCount, (object) newValue.RepublishCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RepublishCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.TransferSubscriptionsCount, (object) newValue.TransferSubscriptionsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransferSubscriptionsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.DeleteSubscriptionsCount, (object) newValue.DeleteSubscriptionsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DeleteSubscriptionsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.AddNodesCount, (object) newValue.AddNodesCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.AddNodesCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.AddReferencesCount, (object) newValue.AddReferencesCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.AddReferencesCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.DeleteNodesCount, (object) newValue.DeleteNodesCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DeleteNodesCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.DeleteReferencesCount, (object) newValue.DeleteReferencesCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DeleteReferencesCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.BrowseCount, (object) newValue.BrowseCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BrowseCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.BrowseNextCount, (object) newValue.BrowseNextCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BrowseNextCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.TranslateBrowsePathsToNodeIdsCount, (object) newValue.TranslateBrowsePathsToNodeIdsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TranslateBrowsePathsToNodeIdsCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.QueryFirstCount, (object) newValue.QueryFirstCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.QueryFirstCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.QueryNextCount, (object) newValue.QueryNextCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.QueryNextCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.RegisterNodesCount, (object) newValue.RegisterNodesCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RegisterNodesCount, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.UnregisterNodesCount, (object) newValue.UnregisterNodesCount))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.UnregisterNodesCount, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_SessionName(
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
      BaseDataVariableState<string> sessionName = this.m_variable?.SessionName;
      if (sessionName != null && StatusCode.IsBad(sessionName.StatusCode))
      {
        value = (object) null;
        statusCode = sessionName.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SessionName;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (sessionName != null && ServiceResult.IsNotBad(status))
      {
        timestamp = sessionName.Timestamp;
        if (statusCode != sessionName.StatusCode)
        {
          statusCode = sessionName.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SessionName(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionName, ref statusCode, ref timestamp);
      this.m_value.SessionName = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ClientDescription(
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
      BaseDataVariableState<ApplicationDescription> clientDescription = this.m_variable?.ClientDescription;
      if (clientDescription != null && StatusCode.IsBad(clientDescription.StatusCode))
      {
        value = (object) null;
        statusCode = clientDescription.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ClientDescription;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (clientDescription != null && ServiceResult.IsNotBad(status))
      {
        timestamp = clientDescription.Timestamp;
        if (statusCode != clientDescription.StatusCode)
        {
          statusCode = clientDescription.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ClientDescription(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientDescription, ref statusCode, ref timestamp);
      this.m_value.ClientDescription = (ApplicationDescription) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ServerUri(
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
      BaseDataVariableState<string> serverUri = this.m_variable?.ServerUri;
      if (serverUri != null && StatusCode.IsBad(serverUri.StatusCode))
      {
        value = (object) null;
        statusCode = serverUri.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ServerUri;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (serverUri != null && ServiceResult.IsNotBad(status))
      {
        timestamp = serverUri.Timestamp;
        if (statusCode != serverUri.StatusCode)
        {
          statusCode = serverUri.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ServerUri(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ServerUri, ref statusCode, ref timestamp);
      this.m_value.ServerUri = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_EndpointUrl(
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
      BaseDataVariableState<string> endpointUrl = this.m_variable?.EndpointUrl;
      if (endpointUrl != null && StatusCode.IsBad(endpointUrl.StatusCode))
      {
        value = (object) null;
        statusCode = endpointUrl.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.EndpointUrl;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (endpointUrl != null && ServiceResult.IsNotBad(status))
      {
        timestamp = endpointUrl.Timestamp;
        if (statusCode != endpointUrl.StatusCode)
        {
          statusCode = endpointUrl.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_EndpointUrl(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.EndpointUrl, ref statusCode, ref timestamp);
      this.m_value.EndpointUrl = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_LocaleIds(
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
      BaseDataVariableState<string[]> localeIds = this.m_variable?.LocaleIds;
      if (localeIds != null && StatusCode.IsBad(localeIds.StatusCode))
      {
        value = (object) null;
        statusCode = localeIds.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.LocaleIds;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (localeIds != null && ServiceResult.IsNotBad(status))
      {
        timestamp = localeIds.Timestamp;
        if (statusCode != localeIds.StatusCode)
        {
          statusCode = localeIds.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_LocaleIds(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LocaleIds, ref statusCode, ref timestamp);
      this.m_value.LocaleIds = (StringCollection) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ActualSessionTimeout(
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
      BaseDataVariableState<double> actualSessionTimeout = this.m_variable?.ActualSessionTimeout;
      if (actualSessionTimeout != null && StatusCode.IsBad(actualSessionTimeout.StatusCode))
      {
        value = (object) null;
        statusCode = actualSessionTimeout.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ActualSessionTimeout;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (actualSessionTimeout != null && ServiceResult.IsNotBad(status))
      {
        timestamp = actualSessionTimeout.Timestamp;
        if (statusCode != actualSessionTimeout.StatusCode)
        {
          statusCode = actualSessionTimeout.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ActualSessionTimeout(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ActualSessionTimeout, ref statusCode, ref timestamp);
      this.m_value.ActualSessionTimeout = (double) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_MaxResponseMessageSize(
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
      BaseDataVariableState<uint> responseMessageSize = this.m_variable?.MaxResponseMessageSize;
      if (responseMessageSize != null && StatusCode.IsBad(responseMessageSize.StatusCode))
      {
        value = (object) null;
        statusCode = responseMessageSize.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.MaxResponseMessageSize;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (responseMessageSize != null && ServiceResult.IsNotBad(status))
      {
        timestamp = responseMessageSize.Timestamp;
        if (statusCode != responseMessageSize.StatusCode)
        {
          statusCode = responseMessageSize.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_MaxResponseMessageSize(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.MaxResponseMessageSize, ref statusCode, ref timestamp);
      this.m_value.MaxResponseMessageSize = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ClientConnectionTime(
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
      BaseDataVariableState<DateTime> clientConnectionTime = this.m_variable?.ClientConnectionTime;
      if (clientConnectionTime != null && StatusCode.IsBad(clientConnectionTime.StatusCode))
      {
        value = (object) null;
        statusCode = clientConnectionTime.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ClientConnectionTime;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (clientConnectionTime != null && ServiceResult.IsNotBad(status))
      {
        timestamp = clientConnectionTime.Timestamp;
        if (statusCode != clientConnectionTime.StatusCode)
        {
          statusCode = clientConnectionTime.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ClientConnectionTime(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientConnectionTime, ref statusCode, ref timestamp);
      this.m_value.ClientConnectionTime = (DateTime) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ClientLastContactTime(
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
      BaseDataVariableState<DateTime> clientLastContactTime = this.m_variable?.ClientLastContactTime;
      if (clientLastContactTime != null && StatusCode.IsBad(clientLastContactTime.StatusCode))
      {
        value = (object) null;
        statusCode = clientLastContactTime.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ClientLastContactTime;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (clientLastContactTime != null && ServiceResult.IsNotBad(status))
      {
        timestamp = clientLastContactTime.Timestamp;
        if (statusCode != clientLastContactTime.StatusCode)
        {
          statusCode = clientLastContactTime.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ClientLastContactTime(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientLastContactTime, ref statusCode, ref timestamp);
      this.m_value.ClientLastContactTime = (DateTime) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CurrentSubscriptionsCount(
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
      BaseDataVariableState<uint> subscriptionsCount = this.m_variable?.CurrentSubscriptionsCount;
      if (subscriptionsCount != null && StatusCode.IsBad(subscriptionsCount.StatusCode))
      {
        value = (object) null;
        statusCode = subscriptionsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CurrentSubscriptionsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (subscriptionsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = subscriptionsCount.Timestamp;
        if (statusCode != subscriptionsCount.StatusCode)
        {
          statusCode = subscriptionsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CurrentSubscriptionsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentSubscriptionsCount, ref statusCode, ref timestamp);
      this.m_value.CurrentSubscriptionsCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CurrentMonitoredItemsCount(
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
      BaseDataVariableState<uint> monitoredItemsCount = this.m_variable?.CurrentMonitoredItemsCount;
      if (monitoredItemsCount != null && StatusCode.IsBad(monitoredItemsCount.StatusCode))
      {
        value = (object) null;
        statusCode = monitoredItemsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CurrentMonitoredItemsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (monitoredItemsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = monitoredItemsCount.Timestamp;
        if (statusCode != monitoredItemsCount.StatusCode)
        {
          statusCode = monitoredItemsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CurrentMonitoredItemsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentMonitoredItemsCount, ref statusCode, ref timestamp);
      this.m_value.CurrentMonitoredItemsCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CurrentPublishRequestsInQueue(
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
      BaseDataVariableState<uint> publishRequestsInQueue = this.m_variable?.CurrentPublishRequestsInQueue;
      if (publishRequestsInQueue != null && StatusCode.IsBad(publishRequestsInQueue.StatusCode))
      {
        value = (object) null;
        statusCode = publishRequestsInQueue.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CurrentPublishRequestsInQueue;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (publishRequestsInQueue != null && ServiceResult.IsNotBad(status))
      {
        timestamp = publishRequestsInQueue.Timestamp;
        if (statusCode != publishRequestsInQueue.StatusCode)
        {
          statusCode = publishRequestsInQueue.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CurrentPublishRequestsInQueue(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentPublishRequestsInQueue, ref statusCode, ref timestamp);
      this.m_value.CurrentPublishRequestsInQueue = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_TotalRequestCount(
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
      BaseDataVariableState<ServiceCounterDataType> totalRequestCount = this.m_variable?.TotalRequestCount;
      if (totalRequestCount != null && StatusCode.IsBad(totalRequestCount.StatusCode))
      {
        value = (object) null;
        statusCode = totalRequestCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.TotalRequestCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (totalRequestCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = totalRequestCount.Timestamp;
        if (statusCode != totalRequestCount.StatusCode)
        {
          statusCode = totalRequestCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_TotalRequestCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TotalRequestCount, ref statusCode, ref timestamp);
      this.m_value.TotalRequestCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_UnauthorizedRequestCount(
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
      BaseDataVariableState<uint> unauthorizedRequestCount = this.m_variable?.UnauthorizedRequestCount;
      if (unauthorizedRequestCount != null && StatusCode.IsBad(unauthorizedRequestCount.StatusCode))
      {
        value = (object) null;
        statusCode = unauthorizedRequestCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.UnauthorizedRequestCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (unauthorizedRequestCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = unauthorizedRequestCount.Timestamp;
        if (statusCode != unauthorizedRequestCount.StatusCode)
        {
          statusCode = unauthorizedRequestCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_UnauthorizedRequestCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.UnauthorizedRequestCount, ref statusCode, ref timestamp);
      this.m_value.UnauthorizedRequestCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ReadCount(
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
      BaseDataVariableState<ServiceCounterDataType> readCount = this.m_variable?.ReadCount;
      if (readCount != null && StatusCode.IsBad(readCount.StatusCode))
      {
        value = (object) null;
        statusCode = readCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ReadCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (readCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = readCount.Timestamp;
        if (statusCode != readCount.StatusCode)
        {
          statusCode = readCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ReadCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ReadCount, ref statusCode, ref timestamp);
      this.m_value.ReadCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_HistoryReadCount(
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
      BaseDataVariableState<ServiceCounterDataType> historyReadCount = this.m_variable?.HistoryReadCount;
      if (historyReadCount != null && StatusCode.IsBad(historyReadCount.StatusCode))
      {
        value = (object) null;
        statusCode = historyReadCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.HistoryReadCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (historyReadCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = historyReadCount.Timestamp;
        if (statusCode != historyReadCount.StatusCode)
        {
          statusCode = historyReadCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_HistoryReadCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.HistoryReadCount, ref statusCode, ref timestamp);
      this.m_value.HistoryReadCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_WriteCount(
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
      BaseDataVariableState<ServiceCounterDataType> writeCount = this.m_variable?.WriteCount;
      if (writeCount != null && StatusCode.IsBad(writeCount.StatusCode))
      {
        value = (object) null;
        statusCode = writeCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.WriteCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (writeCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = writeCount.Timestamp;
        if (statusCode != writeCount.StatusCode)
        {
          statusCode = writeCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_WriteCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.WriteCount, ref statusCode, ref timestamp);
      this.m_value.WriteCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_HistoryUpdateCount(
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
      BaseDataVariableState<ServiceCounterDataType> historyUpdateCount = this.m_variable?.HistoryUpdateCount;
      if (historyUpdateCount != null && StatusCode.IsBad(historyUpdateCount.StatusCode))
      {
        value = (object) null;
        statusCode = historyUpdateCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.HistoryUpdateCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (historyUpdateCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = historyUpdateCount.Timestamp;
        if (statusCode != historyUpdateCount.StatusCode)
        {
          statusCode = historyUpdateCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_HistoryUpdateCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.HistoryUpdateCount, ref statusCode, ref timestamp);
      this.m_value.HistoryUpdateCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CallCount(
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
      BaseDataVariableState<ServiceCounterDataType> callCount = this.m_variable?.CallCount;
      if (callCount != null && StatusCode.IsBad(callCount.StatusCode))
      {
        value = (object) null;
        statusCode = callCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CallCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (callCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = callCount.Timestamp;
        if (statusCode != callCount.StatusCode)
        {
          statusCode = callCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CallCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CallCount, ref statusCode, ref timestamp);
      this.m_value.CallCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CreateMonitoredItemsCount(
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
      BaseDataVariableState<ServiceCounterDataType> monitoredItemsCount = this.m_variable?.CreateMonitoredItemsCount;
      if (monitoredItemsCount != null && StatusCode.IsBad(monitoredItemsCount.StatusCode))
      {
        value = (object) null;
        statusCode = monitoredItemsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CreateMonitoredItemsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (monitoredItemsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = monitoredItemsCount.Timestamp;
        if (statusCode != monitoredItemsCount.StatusCode)
        {
          statusCode = monitoredItemsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CreateMonitoredItemsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CreateMonitoredItemsCount, ref statusCode, ref timestamp);
      this.m_value.CreateMonitoredItemsCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ModifyMonitoredItemsCount(
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
      BaseDataVariableState<ServiceCounterDataType> monitoredItemsCount = this.m_variable?.ModifyMonitoredItemsCount;
      if (monitoredItemsCount != null && StatusCode.IsBad(monitoredItemsCount.StatusCode))
      {
        value = (object) null;
        statusCode = monitoredItemsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ModifyMonitoredItemsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (monitoredItemsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = monitoredItemsCount.Timestamp;
        if (statusCode != monitoredItemsCount.StatusCode)
        {
          statusCode = monitoredItemsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ModifyMonitoredItemsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ModifyMonitoredItemsCount, ref statusCode, ref timestamp);
      this.m_value.ModifyMonitoredItemsCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SetMonitoringModeCount(
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
      BaseDataVariableState<ServiceCounterDataType> monitoringModeCount = this.m_variable?.SetMonitoringModeCount;
      if (monitoringModeCount != null && StatusCode.IsBad(monitoringModeCount.StatusCode))
      {
        value = (object) null;
        statusCode = monitoringModeCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SetMonitoringModeCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (monitoringModeCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = monitoringModeCount.Timestamp;
        if (statusCode != monitoringModeCount.StatusCode)
        {
          statusCode = monitoringModeCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SetMonitoringModeCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SetMonitoringModeCount, ref statusCode, ref timestamp);
      this.m_value.SetMonitoringModeCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SetTriggeringCount(
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
      BaseDataVariableState<ServiceCounterDataType> setTriggeringCount = this.m_variable?.SetTriggeringCount;
      if (setTriggeringCount != null && StatusCode.IsBad(setTriggeringCount.StatusCode))
      {
        value = (object) null;
        statusCode = setTriggeringCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SetTriggeringCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (setTriggeringCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = setTriggeringCount.Timestamp;
        if (statusCode != setTriggeringCount.StatusCode)
        {
          statusCode = setTriggeringCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SetTriggeringCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SetTriggeringCount, ref statusCode, ref timestamp);
      this.m_value.SetTriggeringCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_DeleteMonitoredItemsCount(
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
      BaseDataVariableState<ServiceCounterDataType> monitoredItemsCount = this.m_variable?.DeleteMonitoredItemsCount;
      if (monitoredItemsCount != null && StatusCode.IsBad(monitoredItemsCount.StatusCode))
      {
        value = (object) null;
        statusCode = monitoredItemsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.DeleteMonitoredItemsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (monitoredItemsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = monitoredItemsCount.Timestamp;
        if (statusCode != monitoredItemsCount.StatusCode)
        {
          statusCode = monitoredItemsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_DeleteMonitoredItemsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DeleteMonitoredItemsCount, ref statusCode, ref timestamp);
      this.m_value.DeleteMonitoredItemsCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CreateSubscriptionCount(
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
      BaseDataVariableState<ServiceCounterDataType> subscriptionCount = this.m_variable?.CreateSubscriptionCount;
      if (subscriptionCount != null && StatusCode.IsBad(subscriptionCount.StatusCode))
      {
        value = (object) null;
        statusCode = subscriptionCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CreateSubscriptionCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (subscriptionCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = subscriptionCount.Timestamp;
        if (statusCode != subscriptionCount.StatusCode)
        {
          statusCode = subscriptionCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CreateSubscriptionCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CreateSubscriptionCount, ref statusCode, ref timestamp);
      this.m_value.CreateSubscriptionCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ModifySubscriptionCount(
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
      BaseDataVariableState<ServiceCounterDataType> subscriptionCount = this.m_variable?.ModifySubscriptionCount;
      if (subscriptionCount != null && StatusCode.IsBad(subscriptionCount.StatusCode))
      {
        value = (object) null;
        statusCode = subscriptionCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ModifySubscriptionCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (subscriptionCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = subscriptionCount.Timestamp;
        if (statusCode != subscriptionCount.StatusCode)
        {
          statusCode = subscriptionCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ModifySubscriptionCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ModifySubscriptionCount, ref statusCode, ref timestamp);
      this.m_value.ModifySubscriptionCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SetPublishingModeCount(
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
      BaseDataVariableState<ServiceCounterDataType> publishingModeCount = this.m_variable?.SetPublishingModeCount;
      if (publishingModeCount != null && StatusCode.IsBad(publishingModeCount.StatusCode))
      {
        value = (object) null;
        statusCode = publishingModeCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SetPublishingModeCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (publishingModeCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = publishingModeCount.Timestamp;
        if (statusCode != publishingModeCount.StatusCode)
        {
          statusCode = publishingModeCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SetPublishingModeCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SetPublishingModeCount, ref statusCode, ref timestamp);
      this.m_value.SetPublishingModeCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_PublishCount(
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
      BaseDataVariableState<ServiceCounterDataType> publishCount = this.m_variable?.PublishCount;
      if (publishCount != null && StatusCode.IsBad(publishCount.StatusCode))
      {
        value = (object) null;
        statusCode = publishCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.PublishCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (publishCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = publishCount.Timestamp;
        if (statusCode != publishCount.StatusCode)
        {
          statusCode = publishCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_PublishCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishCount, ref statusCode, ref timestamp);
      this.m_value.PublishCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_RepublishCount(
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
      BaseDataVariableState<ServiceCounterDataType> republishCount = this.m_variable?.RepublishCount;
      if (republishCount != null && StatusCode.IsBad(republishCount.StatusCode))
      {
        value = (object) null;
        statusCode = republishCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.RepublishCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (republishCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = republishCount.Timestamp;
        if (statusCode != republishCount.StatusCode)
        {
          statusCode = republishCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_RepublishCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RepublishCount, ref statusCode, ref timestamp);
      this.m_value.RepublishCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_TransferSubscriptionsCount(
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
      BaseDataVariableState<ServiceCounterDataType> subscriptionsCount = this.m_variable?.TransferSubscriptionsCount;
      if (subscriptionsCount != null && StatusCode.IsBad(subscriptionsCount.StatusCode))
      {
        value = (object) null;
        statusCode = subscriptionsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.TransferSubscriptionsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (subscriptionsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = subscriptionsCount.Timestamp;
        if (statusCode != subscriptionsCount.StatusCode)
        {
          statusCode = subscriptionsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_TransferSubscriptionsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransferSubscriptionsCount, ref statusCode, ref timestamp);
      this.m_value.TransferSubscriptionsCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_DeleteSubscriptionsCount(
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
      BaseDataVariableState<ServiceCounterDataType> subscriptionsCount = this.m_variable?.DeleteSubscriptionsCount;
      if (subscriptionsCount != null && StatusCode.IsBad(subscriptionsCount.StatusCode))
      {
        value = (object) null;
        statusCode = subscriptionsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.DeleteSubscriptionsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (subscriptionsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = subscriptionsCount.Timestamp;
        if (statusCode != subscriptionsCount.StatusCode)
        {
          statusCode = subscriptionsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_DeleteSubscriptionsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DeleteSubscriptionsCount, ref statusCode, ref timestamp);
      this.m_value.DeleteSubscriptionsCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_AddNodesCount(
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
      BaseDataVariableState<ServiceCounterDataType> addNodesCount = this.m_variable?.AddNodesCount;
      if (addNodesCount != null && StatusCode.IsBad(addNodesCount.StatusCode))
      {
        value = (object) null;
        statusCode = addNodesCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.AddNodesCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (addNodesCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = addNodesCount.Timestamp;
        if (statusCode != addNodesCount.StatusCode)
        {
          statusCode = addNodesCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_AddNodesCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.AddNodesCount, ref statusCode, ref timestamp);
      this.m_value.AddNodesCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_AddReferencesCount(
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
      BaseDataVariableState<ServiceCounterDataType> addReferencesCount = this.m_variable?.AddReferencesCount;
      if (addReferencesCount != null && StatusCode.IsBad(addReferencesCount.StatusCode))
      {
        value = (object) null;
        statusCode = addReferencesCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.AddReferencesCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (addReferencesCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = addReferencesCount.Timestamp;
        if (statusCode != addReferencesCount.StatusCode)
        {
          statusCode = addReferencesCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_AddReferencesCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.AddReferencesCount, ref statusCode, ref timestamp);
      this.m_value.AddReferencesCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_DeleteNodesCount(
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
      BaseDataVariableState<ServiceCounterDataType> deleteNodesCount = this.m_variable?.DeleteNodesCount;
      if (deleteNodesCount != null && StatusCode.IsBad(deleteNodesCount.StatusCode))
      {
        value = (object) null;
        statusCode = deleteNodesCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.DeleteNodesCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (deleteNodesCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = deleteNodesCount.Timestamp;
        if (statusCode != deleteNodesCount.StatusCode)
        {
          statusCode = deleteNodesCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_DeleteNodesCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DeleteNodesCount, ref statusCode, ref timestamp);
      this.m_value.DeleteNodesCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_DeleteReferencesCount(
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
      BaseDataVariableState<ServiceCounterDataType> deleteReferencesCount = this.m_variable?.DeleteReferencesCount;
      if (deleteReferencesCount != null && StatusCode.IsBad(deleteReferencesCount.StatusCode))
      {
        value = (object) null;
        statusCode = deleteReferencesCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.DeleteReferencesCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (deleteReferencesCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = deleteReferencesCount.Timestamp;
        if (statusCode != deleteReferencesCount.StatusCode)
        {
          statusCode = deleteReferencesCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_DeleteReferencesCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.DeleteReferencesCount, ref statusCode, ref timestamp);
      this.m_value.DeleteReferencesCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_BrowseCount(
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
      BaseDataVariableState<ServiceCounterDataType> browseCount = this.m_variable?.BrowseCount;
      if (browseCount != null && StatusCode.IsBad(browseCount.StatusCode))
      {
        value = (object) null;
        statusCode = browseCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.BrowseCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (browseCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = browseCount.Timestamp;
        if (statusCode != browseCount.StatusCode)
        {
          statusCode = browseCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_BrowseCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BrowseCount, ref statusCode, ref timestamp);
      this.m_value.BrowseCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_BrowseNextCount(
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
      BaseDataVariableState<ServiceCounterDataType> browseNextCount = this.m_variable?.BrowseNextCount;
      if (browseNextCount != null && StatusCode.IsBad(browseNextCount.StatusCode))
      {
        value = (object) null;
        statusCode = browseNextCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.BrowseNextCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (browseNextCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = browseNextCount.Timestamp;
        if (statusCode != browseNextCount.StatusCode)
        {
          statusCode = browseNextCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_BrowseNextCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BrowseNextCount, ref statusCode, ref timestamp);
      this.m_value.BrowseNextCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_TranslateBrowsePathsToNodeIdsCount(
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
      BaseDataVariableState<ServiceCounterDataType> pathsToNodeIdsCount = this.m_variable?.TranslateBrowsePathsToNodeIdsCount;
      if (pathsToNodeIdsCount != null && StatusCode.IsBad(pathsToNodeIdsCount.StatusCode))
      {
        value = (object) null;
        statusCode = pathsToNodeIdsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.TranslateBrowsePathsToNodeIdsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (pathsToNodeIdsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = pathsToNodeIdsCount.Timestamp;
        if (statusCode != pathsToNodeIdsCount.StatusCode)
        {
          statusCode = pathsToNodeIdsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_TranslateBrowsePathsToNodeIdsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TranslateBrowsePathsToNodeIdsCount, ref statusCode, ref timestamp);
      this.m_value.TranslateBrowsePathsToNodeIdsCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_QueryFirstCount(
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
      BaseDataVariableState<ServiceCounterDataType> queryFirstCount = this.m_variable?.QueryFirstCount;
      if (queryFirstCount != null && StatusCode.IsBad(queryFirstCount.StatusCode))
      {
        value = (object) null;
        statusCode = queryFirstCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.QueryFirstCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (queryFirstCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = queryFirstCount.Timestamp;
        if (statusCode != queryFirstCount.StatusCode)
        {
          statusCode = queryFirstCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_QueryFirstCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.QueryFirstCount, ref statusCode, ref timestamp);
      this.m_value.QueryFirstCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_QueryNextCount(
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
      BaseDataVariableState<ServiceCounterDataType> queryNextCount = this.m_variable?.QueryNextCount;
      if (queryNextCount != null && StatusCode.IsBad(queryNextCount.StatusCode))
      {
        value = (object) null;
        statusCode = queryNextCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.QueryNextCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (queryNextCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = queryNextCount.Timestamp;
        if (statusCode != queryNextCount.StatusCode)
        {
          statusCode = queryNextCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_QueryNextCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.QueryNextCount, ref statusCode, ref timestamp);
      this.m_value.QueryNextCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_RegisterNodesCount(
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
      BaseDataVariableState<ServiceCounterDataType> registerNodesCount = this.m_variable?.RegisterNodesCount;
      if (registerNodesCount != null && StatusCode.IsBad(registerNodesCount.StatusCode))
      {
        value = (object) null;
        statusCode = registerNodesCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.RegisterNodesCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (registerNodesCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = registerNodesCount.Timestamp;
        if (statusCode != registerNodesCount.StatusCode)
        {
          statusCode = registerNodesCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_RegisterNodesCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RegisterNodesCount, ref statusCode, ref timestamp);
      this.m_value.RegisterNodesCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_UnregisterNodesCount(
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
      BaseDataVariableState<ServiceCounterDataType> unregisterNodesCount = this.m_variable?.UnregisterNodesCount;
      if (unregisterNodesCount != null && StatusCode.IsBad(unregisterNodesCount.StatusCode))
      {
        value = (object) null;
        statusCode = unregisterNodesCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.UnregisterNodesCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (unregisterNodesCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = unregisterNodesCount.Timestamp;
        if (statusCode != unregisterNodesCount.StatusCode)
        {
          statusCode = unregisterNodesCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_UnregisterNodesCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.UnregisterNodesCount, ref statusCode, ref timestamp);
      this.m_value.UnregisterNodesCount = (ServiceCounterDataType) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
