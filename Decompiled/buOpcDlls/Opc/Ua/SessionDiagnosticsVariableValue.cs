using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionDiagnosticsVariableValue : BaseVariableValue
{
	private SessionDiagnosticsDataType m_value;

	private SessionDiagnosticsVariableState m_variable;

	public SessionDiagnosticsVariableState Variable => m_variable;

	public SessionDiagnosticsDataType Value
	{
		get
		{
			return m_value;
		}
		set
		{
			m_value = value;
		}
	}

	public SessionDiagnosticsVariableValue(SessionDiagnosticsVariableState variable, SessionDiagnosticsDataType value, object dataLock)
		: base(dataLock)
	{
		m_value = value;
		if (m_value == null)
		{
			m_value = new SessionDiagnosticsDataType();
		}
		Initialize(variable);
	}

	private void Initialize(SessionDiagnosticsVariableState variable)
	{
		lock (base.Lock)
		{
			m_variable = variable;
			variable.Value = m_value;
			variable.OnReadValue = OnReadValue;
			variable.OnWriteValue = OnWriteValue;
			BaseVariableState baseVariableState = null;
			List<BaseInstanceState> list = new List<BaseInstanceState>();
			list.Add(variable);
			baseVariableState = m_variable.SessionId;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SessionId;
				baseVariableState.OnWriteValue = OnWrite_SessionId;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SessionName;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SessionName;
				baseVariableState.OnWriteValue = OnWrite_SessionName;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ClientDescription;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ClientDescription;
				baseVariableState.OnWriteValue = OnWrite_ClientDescription;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ServerUri;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ServerUri;
				baseVariableState.OnWriteValue = OnWrite_ServerUri;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.EndpointUrl;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_EndpointUrl;
				baseVariableState.OnWriteValue = OnWrite_EndpointUrl;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LocaleIds;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LocaleIds;
				baseVariableState.OnWriteValue = OnWrite_LocaleIds;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ActualSessionTimeout;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ActualSessionTimeout;
				baseVariableState.OnWriteValue = OnWrite_ActualSessionTimeout;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.MaxResponseMessageSize;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_MaxResponseMessageSize;
				baseVariableState.OnWriteValue = OnWrite_MaxResponseMessageSize;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ClientConnectionTime;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ClientConnectionTime;
				baseVariableState.OnWriteValue = OnWrite_ClientConnectionTime;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ClientLastContactTime;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ClientLastContactTime;
				baseVariableState.OnWriteValue = OnWrite_ClientLastContactTime;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CurrentSubscriptionsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CurrentSubscriptionsCount;
				baseVariableState.OnWriteValue = OnWrite_CurrentSubscriptionsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CurrentMonitoredItemsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CurrentMonitoredItemsCount;
				baseVariableState.OnWriteValue = OnWrite_CurrentMonitoredItemsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CurrentPublishRequestsInQueue;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CurrentPublishRequestsInQueue;
				baseVariableState.OnWriteValue = OnWrite_CurrentPublishRequestsInQueue;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.TotalRequestCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_TotalRequestCount;
				baseVariableState.OnWriteValue = OnWrite_TotalRequestCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.UnauthorizedRequestCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_UnauthorizedRequestCount;
				baseVariableState.OnWriteValue = OnWrite_UnauthorizedRequestCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ReadCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ReadCount;
				baseVariableState.OnWriteValue = OnWrite_ReadCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.HistoryReadCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_HistoryReadCount;
				baseVariableState.OnWriteValue = OnWrite_HistoryReadCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.WriteCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_WriteCount;
				baseVariableState.OnWriteValue = OnWrite_WriteCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.HistoryUpdateCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_HistoryUpdateCount;
				baseVariableState.OnWriteValue = OnWrite_HistoryUpdateCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CallCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CallCount;
				baseVariableState.OnWriteValue = OnWrite_CallCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CreateMonitoredItemsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CreateMonitoredItemsCount;
				baseVariableState.OnWriteValue = OnWrite_CreateMonitoredItemsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ModifyMonitoredItemsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ModifyMonitoredItemsCount;
				baseVariableState.OnWriteValue = OnWrite_ModifyMonitoredItemsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SetMonitoringModeCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SetMonitoringModeCount;
				baseVariableState.OnWriteValue = OnWrite_SetMonitoringModeCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SetTriggeringCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SetTriggeringCount;
				baseVariableState.OnWriteValue = OnWrite_SetTriggeringCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.DeleteMonitoredItemsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_DeleteMonitoredItemsCount;
				baseVariableState.OnWriteValue = OnWrite_DeleteMonitoredItemsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CreateSubscriptionCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CreateSubscriptionCount;
				baseVariableState.OnWriteValue = OnWrite_CreateSubscriptionCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ModifySubscriptionCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ModifySubscriptionCount;
				baseVariableState.OnWriteValue = OnWrite_ModifySubscriptionCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SetPublishingModeCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SetPublishingModeCount;
				baseVariableState.OnWriteValue = OnWrite_SetPublishingModeCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.PublishCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_PublishCount;
				baseVariableState.OnWriteValue = OnWrite_PublishCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.RepublishCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_RepublishCount;
				baseVariableState.OnWriteValue = OnWrite_RepublishCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.TransferSubscriptionsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_TransferSubscriptionsCount;
				baseVariableState.OnWriteValue = OnWrite_TransferSubscriptionsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.DeleteSubscriptionsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_DeleteSubscriptionsCount;
				baseVariableState.OnWriteValue = OnWrite_DeleteSubscriptionsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.AddNodesCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_AddNodesCount;
				baseVariableState.OnWriteValue = OnWrite_AddNodesCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.AddReferencesCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_AddReferencesCount;
				baseVariableState.OnWriteValue = OnWrite_AddReferencesCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.DeleteNodesCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_DeleteNodesCount;
				baseVariableState.OnWriteValue = OnWrite_DeleteNodesCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.DeleteReferencesCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_DeleteReferencesCount;
				baseVariableState.OnWriteValue = OnWrite_DeleteReferencesCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.BrowseCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_BrowseCount;
				baseVariableState.OnWriteValue = OnWrite_BrowseCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.BrowseNextCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_BrowseNextCount;
				baseVariableState.OnWriteValue = OnWrite_BrowseNextCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.TranslateBrowsePathsToNodeIdsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_TranslateBrowsePathsToNodeIdsCount;
				baseVariableState.OnWriteValue = OnWrite_TranslateBrowsePathsToNodeIdsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.QueryFirstCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_QueryFirstCount;
				baseVariableState.OnWriteValue = OnWrite_QueryFirstCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.QueryNextCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_QueryNextCount;
				baseVariableState.OnWriteValue = OnWrite_QueryNextCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.RegisterNodesCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_RegisterNodesCount;
				baseVariableState.OnWriteValue = OnWrite_RegisterNodesCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.UnregisterNodesCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_UnregisterNodesCount;
				baseVariableState.OnWriteValue = OnWrite_UnregisterNodesCount;
				list.Add(baseVariableState);
			}
			SetUpdateList(list);
		}
	}

	protected ServiceResult OnReadValue(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			if (m_value != null)
			{
				value = m_value;
			}
			return Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
		}
	}

	private ServiceResult OnWriteValue(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			SessionDiagnosticsDataType newValue = ((!(value is ExtensionObject extensionObject)) ? ((SessionDiagnosticsDataType)value) : ((SessionDiagnosticsDataType)extensionObject.Body));
			if (!Utils.IsEqual(m_value, newValue))
			{
				UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
				base.Timestamp = timestamp;
				m_value = (SessionDiagnosticsDataType)Write(newValue);
				m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
			}
		}
		return ServiceResult.Good;
	}

	private void UpdateChildrenChangeMasks(ISystemContext context, ref SessionDiagnosticsDataType newValue, ref StatusCode statusCode, ref DateTime timestamp)
	{
		if (!Utils.IsEqual(m_value.SessionId, newValue.SessionId))
		{
			UpdateChildVariableStatus(m_variable.SessionId, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SessionName, newValue.SessionName))
		{
			UpdateChildVariableStatus(m_variable.SessionName, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ClientDescription, newValue.ClientDescription))
		{
			UpdateChildVariableStatus(m_variable.ClientDescription, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ServerUri, newValue.ServerUri))
		{
			UpdateChildVariableStatus(m_variable.ServerUri, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.EndpointUrl, newValue.EndpointUrl))
		{
			UpdateChildVariableStatus(m_variable.EndpointUrl, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LocaleIds, newValue.LocaleIds))
		{
			UpdateChildVariableStatus(m_variable.LocaleIds, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ActualSessionTimeout, newValue.ActualSessionTimeout))
		{
			UpdateChildVariableStatus(m_variable.ActualSessionTimeout, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.MaxResponseMessageSize, newValue.MaxResponseMessageSize))
		{
			UpdateChildVariableStatus(m_variable.MaxResponseMessageSize, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ClientConnectionTime, newValue.ClientConnectionTime))
		{
			UpdateChildVariableStatus(m_variable.ClientConnectionTime, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ClientLastContactTime, newValue.ClientLastContactTime))
		{
			UpdateChildVariableStatus(m_variable.ClientLastContactTime, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CurrentSubscriptionsCount, newValue.CurrentSubscriptionsCount))
		{
			UpdateChildVariableStatus(m_variable.CurrentSubscriptionsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CurrentMonitoredItemsCount, newValue.CurrentMonitoredItemsCount))
		{
			UpdateChildVariableStatus(m_variable.CurrentMonitoredItemsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CurrentPublishRequestsInQueue, newValue.CurrentPublishRequestsInQueue))
		{
			UpdateChildVariableStatus(m_variable.CurrentPublishRequestsInQueue, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.TotalRequestCount, newValue.TotalRequestCount))
		{
			UpdateChildVariableStatus(m_variable.TotalRequestCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.UnauthorizedRequestCount, newValue.UnauthorizedRequestCount))
		{
			UpdateChildVariableStatus(m_variable.UnauthorizedRequestCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ReadCount, newValue.ReadCount))
		{
			UpdateChildVariableStatus(m_variable.ReadCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.HistoryReadCount, newValue.HistoryReadCount))
		{
			UpdateChildVariableStatus(m_variable.HistoryReadCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.WriteCount, newValue.WriteCount))
		{
			UpdateChildVariableStatus(m_variable.WriteCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.HistoryUpdateCount, newValue.HistoryUpdateCount))
		{
			UpdateChildVariableStatus(m_variable.HistoryUpdateCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CallCount, newValue.CallCount))
		{
			UpdateChildVariableStatus(m_variable.CallCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CreateMonitoredItemsCount, newValue.CreateMonitoredItemsCount))
		{
			UpdateChildVariableStatus(m_variable.CreateMonitoredItemsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ModifyMonitoredItemsCount, newValue.ModifyMonitoredItemsCount))
		{
			UpdateChildVariableStatus(m_variable.ModifyMonitoredItemsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SetMonitoringModeCount, newValue.SetMonitoringModeCount))
		{
			UpdateChildVariableStatus(m_variable.SetMonitoringModeCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SetTriggeringCount, newValue.SetTriggeringCount))
		{
			UpdateChildVariableStatus(m_variable.SetTriggeringCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.DeleteMonitoredItemsCount, newValue.DeleteMonitoredItemsCount))
		{
			UpdateChildVariableStatus(m_variable.DeleteMonitoredItemsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CreateSubscriptionCount, newValue.CreateSubscriptionCount))
		{
			UpdateChildVariableStatus(m_variable.CreateSubscriptionCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ModifySubscriptionCount, newValue.ModifySubscriptionCount))
		{
			UpdateChildVariableStatus(m_variable.ModifySubscriptionCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SetPublishingModeCount, newValue.SetPublishingModeCount))
		{
			UpdateChildVariableStatus(m_variable.SetPublishingModeCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.PublishCount, newValue.PublishCount))
		{
			UpdateChildVariableStatus(m_variable.PublishCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.RepublishCount, newValue.RepublishCount))
		{
			UpdateChildVariableStatus(m_variable.RepublishCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.TransferSubscriptionsCount, newValue.TransferSubscriptionsCount))
		{
			UpdateChildVariableStatus(m_variable.TransferSubscriptionsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.DeleteSubscriptionsCount, newValue.DeleteSubscriptionsCount))
		{
			UpdateChildVariableStatus(m_variable.DeleteSubscriptionsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.AddNodesCount, newValue.AddNodesCount))
		{
			UpdateChildVariableStatus(m_variable.AddNodesCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.AddReferencesCount, newValue.AddReferencesCount))
		{
			UpdateChildVariableStatus(m_variable.AddReferencesCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.DeleteNodesCount, newValue.DeleteNodesCount))
		{
			UpdateChildVariableStatus(m_variable.DeleteNodesCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.DeleteReferencesCount, newValue.DeleteReferencesCount))
		{
			UpdateChildVariableStatus(m_variable.DeleteReferencesCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.BrowseCount, newValue.BrowseCount))
		{
			UpdateChildVariableStatus(m_variable.BrowseCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.BrowseNextCount, newValue.BrowseNextCount))
		{
			UpdateChildVariableStatus(m_variable.BrowseNextCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.TranslateBrowsePathsToNodeIdsCount, newValue.TranslateBrowsePathsToNodeIdsCount))
		{
			UpdateChildVariableStatus(m_variable.TranslateBrowsePathsToNodeIdsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.QueryFirstCount, newValue.QueryFirstCount))
		{
			UpdateChildVariableStatus(m_variable.QueryFirstCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.QueryNextCount, newValue.QueryNextCount))
		{
			UpdateChildVariableStatus(m_variable.QueryNextCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.RegisterNodesCount, newValue.RegisterNodesCount))
		{
			UpdateChildVariableStatus(m_variable.RegisterNodesCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.UnregisterNodesCount, newValue.UnregisterNodesCount))
		{
			UpdateChildVariableStatus(m_variable.UnregisterNodesCount, ref statusCode, ref timestamp);
		}
	}

	private void UpdateParent(ISystemContext context, ref StatusCode statusCode, ref DateTime timestamp)
	{
		base.Timestamp = timestamp;
		m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
		m_variable.ClearChangeMasks(context, includeChildren: false);
	}

	private void UpdateChildVariableStatus(BaseVariableState child, ref StatusCode statusCode, ref DateTime timestamp)
	{
		if (child != null)
		{
			child.StatusCode = statusCode;
			if (timestamp == DateTime.MinValue)
			{
				timestamp = DateTime.UtcNow;
			}
			child.Timestamp = timestamp;
		}
	}

	private ServiceResult OnRead_SessionId(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<NodeId> baseDataVariableState = m_variable?.SessionId;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SessionId;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_SessionId(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SessionId, ref statusCode, ref timestamp);
			m_value.SessionId = (NodeId)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SessionName(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string> baseDataVariableState = m_variable?.SessionName;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SessionName;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_SessionName(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SessionName, ref statusCode, ref timestamp);
			m_value.SessionName = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ClientDescription(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ApplicationDescription> baseDataVariableState = m_variable?.ClientDescription;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ClientDescription;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_ClientDescription(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ClientDescription, ref statusCode, ref timestamp);
			m_value.ClientDescription = (ApplicationDescription)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ServerUri(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string> baseDataVariableState = m_variable?.ServerUri;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ServerUri;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_ServerUri(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ServerUri, ref statusCode, ref timestamp);
			m_value.ServerUri = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_EndpointUrl(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string> baseDataVariableState = m_variable?.EndpointUrl;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.EndpointUrl;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_EndpointUrl(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.EndpointUrl, ref statusCode, ref timestamp);
			m_value.EndpointUrl = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LocaleIds(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string[]> baseDataVariableState = m_variable?.LocaleIds;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LocaleIds;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_LocaleIds(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LocaleIds, ref statusCode, ref timestamp);
			m_value.LocaleIds = (StringCollection)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ActualSessionTimeout(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<double> baseDataVariableState = m_variable?.ActualSessionTimeout;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ActualSessionTimeout;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_ActualSessionTimeout(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ActualSessionTimeout, ref statusCode, ref timestamp);
			m_value.ActualSessionTimeout = (double)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_MaxResponseMessageSize(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.MaxResponseMessageSize;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.MaxResponseMessageSize;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_MaxResponseMessageSize(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.MaxResponseMessageSize, ref statusCode, ref timestamp);
			m_value.MaxResponseMessageSize = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ClientConnectionTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<DateTime> baseDataVariableState = m_variable?.ClientConnectionTime;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ClientConnectionTime;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_ClientConnectionTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ClientConnectionTime, ref statusCode, ref timestamp);
			m_value.ClientConnectionTime = (DateTime)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ClientLastContactTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<DateTime> baseDataVariableState = m_variable?.ClientLastContactTime;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ClientLastContactTime;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_ClientLastContactTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ClientLastContactTime, ref statusCode, ref timestamp);
			m_value.ClientLastContactTime = (DateTime)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CurrentSubscriptionsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.CurrentSubscriptionsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CurrentSubscriptionsCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_CurrentSubscriptionsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CurrentSubscriptionsCount, ref statusCode, ref timestamp);
			m_value.CurrentSubscriptionsCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CurrentMonitoredItemsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.CurrentMonitoredItemsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CurrentMonitoredItemsCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_CurrentMonitoredItemsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CurrentMonitoredItemsCount, ref statusCode, ref timestamp);
			m_value.CurrentMonitoredItemsCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CurrentPublishRequestsInQueue(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.CurrentPublishRequestsInQueue;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CurrentPublishRequestsInQueue;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_CurrentPublishRequestsInQueue(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CurrentPublishRequestsInQueue, ref statusCode, ref timestamp);
			m_value.CurrentPublishRequestsInQueue = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_TotalRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.TotalRequestCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.TotalRequestCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_TotalRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.TotalRequestCount, ref statusCode, ref timestamp);
			m_value.TotalRequestCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_UnauthorizedRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.UnauthorizedRequestCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.UnauthorizedRequestCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_UnauthorizedRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.UnauthorizedRequestCount, ref statusCode, ref timestamp);
			m_value.UnauthorizedRequestCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ReadCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.ReadCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ReadCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_ReadCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ReadCount, ref statusCode, ref timestamp);
			m_value.ReadCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_HistoryReadCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.HistoryReadCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.HistoryReadCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_HistoryReadCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.HistoryReadCount, ref statusCode, ref timestamp);
			m_value.HistoryReadCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_WriteCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.WriteCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.WriteCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_WriteCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.WriteCount, ref statusCode, ref timestamp);
			m_value.WriteCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_HistoryUpdateCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.HistoryUpdateCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.HistoryUpdateCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_HistoryUpdateCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.HistoryUpdateCount, ref statusCode, ref timestamp);
			m_value.HistoryUpdateCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CallCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.CallCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CallCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_CallCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CallCount, ref statusCode, ref timestamp);
			m_value.CallCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CreateMonitoredItemsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.CreateMonitoredItemsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CreateMonitoredItemsCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_CreateMonitoredItemsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CreateMonitoredItemsCount, ref statusCode, ref timestamp);
			m_value.CreateMonitoredItemsCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ModifyMonitoredItemsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.ModifyMonitoredItemsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ModifyMonitoredItemsCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_ModifyMonitoredItemsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ModifyMonitoredItemsCount, ref statusCode, ref timestamp);
			m_value.ModifyMonitoredItemsCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SetMonitoringModeCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.SetMonitoringModeCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SetMonitoringModeCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_SetMonitoringModeCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SetMonitoringModeCount, ref statusCode, ref timestamp);
			m_value.SetMonitoringModeCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SetTriggeringCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.SetTriggeringCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SetTriggeringCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_SetTriggeringCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SetTriggeringCount, ref statusCode, ref timestamp);
			m_value.SetTriggeringCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_DeleteMonitoredItemsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.DeleteMonitoredItemsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.DeleteMonitoredItemsCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_DeleteMonitoredItemsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.DeleteMonitoredItemsCount, ref statusCode, ref timestamp);
			m_value.DeleteMonitoredItemsCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CreateSubscriptionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.CreateSubscriptionCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CreateSubscriptionCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_CreateSubscriptionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CreateSubscriptionCount, ref statusCode, ref timestamp);
			m_value.CreateSubscriptionCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ModifySubscriptionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.ModifySubscriptionCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ModifySubscriptionCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_ModifySubscriptionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ModifySubscriptionCount, ref statusCode, ref timestamp);
			m_value.ModifySubscriptionCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SetPublishingModeCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.SetPublishingModeCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SetPublishingModeCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_SetPublishingModeCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SetPublishingModeCount, ref statusCode, ref timestamp);
			m_value.SetPublishingModeCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_PublishCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.PublishCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.PublishCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_PublishCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.PublishCount, ref statusCode, ref timestamp);
			m_value.PublishCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_RepublishCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.RepublishCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.RepublishCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_RepublishCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.RepublishCount, ref statusCode, ref timestamp);
			m_value.RepublishCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_TransferSubscriptionsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.TransferSubscriptionsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.TransferSubscriptionsCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_TransferSubscriptionsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.TransferSubscriptionsCount, ref statusCode, ref timestamp);
			m_value.TransferSubscriptionsCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_DeleteSubscriptionsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.DeleteSubscriptionsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.DeleteSubscriptionsCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_DeleteSubscriptionsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.DeleteSubscriptionsCount, ref statusCode, ref timestamp);
			m_value.DeleteSubscriptionsCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_AddNodesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.AddNodesCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.AddNodesCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_AddNodesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.AddNodesCount, ref statusCode, ref timestamp);
			m_value.AddNodesCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_AddReferencesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.AddReferencesCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.AddReferencesCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_AddReferencesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.AddReferencesCount, ref statusCode, ref timestamp);
			m_value.AddReferencesCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_DeleteNodesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.DeleteNodesCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.DeleteNodesCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_DeleteNodesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.DeleteNodesCount, ref statusCode, ref timestamp);
			m_value.DeleteNodesCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_DeleteReferencesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.DeleteReferencesCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.DeleteReferencesCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_DeleteReferencesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.DeleteReferencesCount, ref statusCode, ref timestamp);
			m_value.DeleteReferencesCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_BrowseCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.BrowseCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.BrowseCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_BrowseCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.BrowseCount, ref statusCode, ref timestamp);
			m_value.BrowseCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_BrowseNextCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.BrowseNextCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.BrowseNextCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_BrowseNextCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.BrowseNextCount, ref statusCode, ref timestamp);
			m_value.BrowseNextCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_TranslateBrowsePathsToNodeIdsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.TranslateBrowsePathsToNodeIdsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.TranslateBrowsePathsToNodeIdsCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_TranslateBrowsePathsToNodeIdsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.TranslateBrowsePathsToNodeIdsCount, ref statusCode, ref timestamp);
			m_value.TranslateBrowsePathsToNodeIdsCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_QueryFirstCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.QueryFirstCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.QueryFirstCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_QueryFirstCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.QueryFirstCount, ref statusCode, ref timestamp);
			m_value.QueryFirstCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_QueryNextCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.QueryNextCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.QueryNextCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_QueryNextCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.QueryNextCount, ref statusCode, ref timestamp);
			m_value.QueryNextCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_RegisterNodesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.RegisterNodesCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.RegisterNodesCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_RegisterNodesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.RegisterNodesCount, ref statusCode, ref timestamp);
			m_value.RegisterNodesCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_UnregisterNodesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<ServiceCounterDataType> baseDataVariableState = m_variable?.UnregisterNodesCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.UnregisterNodesCount;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (baseDataVariableState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = baseDataVariableState.Timestamp;
				if (statusCode != baseDataVariableState.StatusCode)
				{
					statusCode = baseDataVariableState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_UnregisterNodesCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.UnregisterNodesCount, ref statusCode, ref timestamp);
			m_value.UnregisterNodesCount = (ServiceCounterDataType)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}
}
