using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SubscriptionDiagnosticsValue : BaseVariableValue
{
	private SubscriptionDiagnosticsDataType m_value;

	private SubscriptionDiagnosticsState m_variable;

	public SubscriptionDiagnosticsState Variable => m_variable;

	public SubscriptionDiagnosticsDataType Value
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

	public SubscriptionDiagnosticsValue(SubscriptionDiagnosticsState variable, SubscriptionDiagnosticsDataType value, object dataLock)
		: base(dataLock)
	{
		m_value = value;
		if (m_value == null)
		{
			m_value = new SubscriptionDiagnosticsDataType();
		}
		Initialize(variable);
	}

	private void Initialize(SubscriptionDiagnosticsState variable)
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
			baseVariableState = m_variable.SubscriptionId;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SubscriptionId;
				baseVariableState.OnWriteValue = OnWrite_SubscriptionId;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.Priority;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_Priority;
				baseVariableState.OnWriteValue = OnWrite_Priority;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.PublishingInterval;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_PublishingInterval;
				baseVariableState.OnWriteValue = OnWrite_PublishingInterval;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.MaxKeepAliveCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_MaxKeepAliveCount;
				baseVariableState.OnWriteValue = OnWrite_MaxKeepAliveCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.MaxLifetimeCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_MaxLifetimeCount;
				baseVariableState.OnWriteValue = OnWrite_MaxLifetimeCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.MaxNotificationsPerPublish;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_MaxNotificationsPerPublish;
				baseVariableState.OnWriteValue = OnWrite_MaxNotificationsPerPublish;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.PublishingEnabled;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_PublishingEnabled;
				baseVariableState.OnWriteValue = OnWrite_PublishingEnabled;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ModifyCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ModifyCount;
				baseVariableState.OnWriteValue = OnWrite_ModifyCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.EnableCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_EnableCount;
				baseVariableState.OnWriteValue = OnWrite_EnableCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.DisableCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_DisableCount;
				baseVariableState.OnWriteValue = OnWrite_DisableCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.RepublishRequestCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_RepublishRequestCount;
				baseVariableState.OnWriteValue = OnWrite_RepublishRequestCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.RepublishMessageRequestCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_RepublishMessageRequestCount;
				baseVariableState.OnWriteValue = OnWrite_RepublishMessageRequestCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.RepublishMessageCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_RepublishMessageCount;
				baseVariableState.OnWriteValue = OnWrite_RepublishMessageCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.TransferRequestCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_TransferRequestCount;
				baseVariableState.OnWriteValue = OnWrite_TransferRequestCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.TransferredToAltClientCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_TransferredToAltClientCount;
				baseVariableState.OnWriteValue = OnWrite_TransferredToAltClientCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.TransferredToSameClientCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_TransferredToSameClientCount;
				baseVariableState.OnWriteValue = OnWrite_TransferredToSameClientCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.PublishRequestCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_PublishRequestCount;
				baseVariableState.OnWriteValue = OnWrite_PublishRequestCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.DataChangeNotificationsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_DataChangeNotificationsCount;
				baseVariableState.OnWriteValue = OnWrite_DataChangeNotificationsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.EventNotificationsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_EventNotificationsCount;
				baseVariableState.OnWriteValue = OnWrite_EventNotificationsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.NotificationsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_NotificationsCount;
				baseVariableState.OnWriteValue = OnWrite_NotificationsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LatePublishRequestCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LatePublishRequestCount;
				baseVariableState.OnWriteValue = OnWrite_LatePublishRequestCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CurrentKeepAliveCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CurrentKeepAliveCount;
				baseVariableState.OnWriteValue = OnWrite_CurrentKeepAliveCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CurrentLifetimeCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CurrentLifetimeCount;
				baseVariableState.OnWriteValue = OnWrite_CurrentLifetimeCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.UnacknowledgedMessageCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_UnacknowledgedMessageCount;
				baseVariableState.OnWriteValue = OnWrite_UnacknowledgedMessageCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.DiscardedMessageCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_DiscardedMessageCount;
				baseVariableState.OnWriteValue = OnWrite_DiscardedMessageCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.MonitoredItemCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_MonitoredItemCount;
				baseVariableState.OnWriteValue = OnWrite_MonitoredItemCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.DisabledMonitoredItemCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_DisabledMonitoredItemCount;
				baseVariableState.OnWriteValue = OnWrite_DisabledMonitoredItemCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.MonitoringQueueOverflowCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_MonitoringQueueOverflowCount;
				baseVariableState.OnWriteValue = OnWrite_MonitoringQueueOverflowCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.NextSequenceNumber;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_NextSequenceNumber;
				baseVariableState.OnWriteValue = OnWrite_NextSequenceNumber;
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
			SubscriptionDiagnosticsDataType newValue = ((!(value is ExtensionObject extensionObject)) ? ((SubscriptionDiagnosticsDataType)value) : ((SubscriptionDiagnosticsDataType)extensionObject.Body));
			if (!Utils.IsEqual(m_value, newValue))
			{
				UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
				base.Timestamp = timestamp;
				m_value = (SubscriptionDiagnosticsDataType)Write(newValue);
				m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
			}
		}
		return ServiceResult.Good;
	}

	private void UpdateChildrenChangeMasks(ISystemContext context, ref SubscriptionDiagnosticsDataType newValue, ref StatusCode statusCode, ref DateTime timestamp)
	{
		if (!Utils.IsEqual(m_value.SessionId, newValue.SessionId))
		{
			UpdateChildVariableStatus(m_variable.SessionId, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SubscriptionId, newValue.SubscriptionId))
		{
			UpdateChildVariableStatus(m_variable.SubscriptionId, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.Priority, newValue.Priority))
		{
			UpdateChildVariableStatus(m_variable.Priority, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.PublishingInterval, newValue.PublishingInterval))
		{
			UpdateChildVariableStatus(m_variable.PublishingInterval, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.MaxKeepAliveCount, newValue.MaxKeepAliveCount))
		{
			UpdateChildVariableStatus(m_variable.MaxKeepAliveCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.MaxLifetimeCount, newValue.MaxLifetimeCount))
		{
			UpdateChildVariableStatus(m_variable.MaxLifetimeCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.MaxNotificationsPerPublish, newValue.MaxNotificationsPerPublish))
		{
			UpdateChildVariableStatus(m_variable.MaxNotificationsPerPublish, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.PublishingEnabled, newValue.PublishingEnabled))
		{
			UpdateChildVariableStatus(m_variable.PublishingEnabled, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ModifyCount, newValue.ModifyCount))
		{
			UpdateChildVariableStatus(m_variable.ModifyCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.EnableCount, newValue.EnableCount))
		{
			UpdateChildVariableStatus(m_variable.EnableCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.DisableCount, newValue.DisableCount))
		{
			UpdateChildVariableStatus(m_variable.DisableCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.RepublishRequestCount, newValue.RepublishRequestCount))
		{
			UpdateChildVariableStatus(m_variable.RepublishRequestCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.RepublishMessageRequestCount, newValue.RepublishMessageRequestCount))
		{
			UpdateChildVariableStatus(m_variable.RepublishMessageRequestCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.RepublishMessageCount, newValue.RepublishMessageCount))
		{
			UpdateChildVariableStatus(m_variable.RepublishMessageCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.TransferRequestCount, newValue.TransferRequestCount))
		{
			UpdateChildVariableStatus(m_variable.TransferRequestCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.TransferredToAltClientCount, newValue.TransferredToAltClientCount))
		{
			UpdateChildVariableStatus(m_variable.TransferredToAltClientCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.TransferredToSameClientCount, newValue.TransferredToSameClientCount))
		{
			UpdateChildVariableStatus(m_variable.TransferredToSameClientCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.PublishRequestCount, newValue.PublishRequestCount))
		{
			UpdateChildVariableStatus(m_variable.PublishRequestCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.DataChangeNotificationsCount, newValue.DataChangeNotificationsCount))
		{
			UpdateChildVariableStatus(m_variable.DataChangeNotificationsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.EventNotificationsCount, newValue.EventNotificationsCount))
		{
			UpdateChildVariableStatus(m_variable.EventNotificationsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.NotificationsCount, newValue.NotificationsCount))
		{
			UpdateChildVariableStatus(m_variable.NotificationsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LatePublishRequestCount, newValue.LatePublishRequestCount))
		{
			UpdateChildVariableStatus(m_variable.LatePublishRequestCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CurrentKeepAliveCount, newValue.CurrentKeepAliveCount))
		{
			UpdateChildVariableStatus(m_variable.CurrentKeepAliveCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CurrentLifetimeCount, newValue.CurrentLifetimeCount))
		{
			UpdateChildVariableStatus(m_variable.CurrentLifetimeCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.UnacknowledgedMessageCount, newValue.UnacknowledgedMessageCount))
		{
			UpdateChildVariableStatus(m_variable.UnacknowledgedMessageCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.DiscardedMessageCount, newValue.DiscardedMessageCount))
		{
			UpdateChildVariableStatus(m_variable.DiscardedMessageCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.MonitoredItemCount, newValue.MonitoredItemCount))
		{
			UpdateChildVariableStatus(m_variable.MonitoredItemCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.DisabledMonitoredItemCount, newValue.DisabledMonitoredItemCount))
		{
			UpdateChildVariableStatus(m_variable.DisabledMonitoredItemCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.MonitoringQueueOverflowCount, newValue.MonitoringQueueOverflowCount))
		{
			UpdateChildVariableStatus(m_variable.MonitoringQueueOverflowCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.NextSequenceNumber, newValue.NextSequenceNumber))
		{
			UpdateChildVariableStatus(m_variable.NextSequenceNumber, ref statusCode, ref timestamp);
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

	private ServiceResult OnRead_SubscriptionId(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.SubscriptionId;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SubscriptionId;
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

	private ServiceResult OnWrite_SubscriptionId(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SubscriptionId, ref statusCode, ref timestamp);
			m_value.SubscriptionId = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_Priority(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<byte> baseDataVariableState = m_variable?.Priority;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.Priority;
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

	private ServiceResult OnWrite_Priority(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.Priority, ref statusCode, ref timestamp);
			m_value.Priority = (byte)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_PublishingInterval(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<double> baseDataVariableState = m_variable?.PublishingInterval;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.PublishingInterval;
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

	private ServiceResult OnWrite_PublishingInterval(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.PublishingInterval, ref statusCode, ref timestamp);
			m_value.PublishingInterval = (double)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_MaxKeepAliveCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.MaxKeepAliveCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.MaxKeepAliveCount;
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

	private ServiceResult OnWrite_MaxKeepAliveCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.MaxKeepAliveCount, ref statusCode, ref timestamp);
			m_value.MaxKeepAliveCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_MaxLifetimeCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.MaxLifetimeCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.MaxLifetimeCount;
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

	private ServiceResult OnWrite_MaxLifetimeCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.MaxLifetimeCount, ref statusCode, ref timestamp);
			m_value.MaxLifetimeCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_MaxNotificationsPerPublish(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.MaxNotificationsPerPublish;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.MaxNotificationsPerPublish;
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

	private ServiceResult OnWrite_MaxNotificationsPerPublish(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.MaxNotificationsPerPublish, ref statusCode, ref timestamp);
			m_value.MaxNotificationsPerPublish = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_PublishingEnabled(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<bool> baseDataVariableState = m_variable?.PublishingEnabled;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.PublishingEnabled;
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

	private ServiceResult OnWrite_PublishingEnabled(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.PublishingEnabled, ref statusCode, ref timestamp);
			m_value.PublishingEnabled = (bool)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ModifyCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.ModifyCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ModifyCount;
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

	private ServiceResult OnWrite_ModifyCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ModifyCount, ref statusCode, ref timestamp);
			m_value.ModifyCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_EnableCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.EnableCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.EnableCount;
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

	private ServiceResult OnWrite_EnableCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.EnableCount, ref statusCode, ref timestamp);
			m_value.EnableCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_DisableCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.DisableCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.DisableCount;
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

	private ServiceResult OnWrite_DisableCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.DisableCount, ref statusCode, ref timestamp);
			m_value.DisableCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_RepublishRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.RepublishRequestCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.RepublishRequestCount;
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

	private ServiceResult OnWrite_RepublishRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.RepublishRequestCount, ref statusCode, ref timestamp);
			m_value.RepublishRequestCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_RepublishMessageRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.RepublishMessageRequestCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.RepublishMessageRequestCount;
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

	private ServiceResult OnWrite_RepublishMessageRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.RepublishMessageRequestCount, ref statusCode, ref timestamp);
			m_value.RepublishMessageRequestCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_RepublishMessageCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.RepublishMessageCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.RepublishMessageCount;
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

	private ServiceResult OnWrite_RepublishMessageCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.RepublishMessageCount, ref statusCode, ref timestamp);
			m_value.RepublishMessageCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_TransferRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.TransferRequestCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.TransferRequestCount;
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

	private ServiceResult OnWrite_TransferRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.TransferRequestCount, ref statusCode, ref timestamp);
			m_value.TransferRequestCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_TransferredToAltClientCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.TransferredToAltClientCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.TransferredToAltClientCount;
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

	private ServiceResult OnWrite_TransferredToAltClientCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.TransferredToAltClientCount, ref statusCode, ref timestamp);
			m_value.TransferredToAltClientCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_TransferredToSameClientCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.TransferredToSameClientCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.TransferredToSameClientCount;
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

	private ServiceResult OnWrite_TransferredToSameClientCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.TransferredToSameClientCount, ref statusCode, ref timestamp);
			m_value.TransferredToSameClientCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_PublishRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.PublishRequestCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.PublishRequestCount;
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

	private ServiceResult OnWrite_PublishRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.PublishRequestCount, ref statusCode, ref timestamp);
			m_value.PublishRequestCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_DataChangeNotificationsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.DataChangeNotificationsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.DataChangeNotificationsCount;
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

	private ServiceResult OnWrite_DataChangeNotificationsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.DataChangeNotificationsCount, ref statusCode, ref timestamp);
			m_value.DataChangeNotificationsCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_EventNotificationsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.EventNotificationsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.EventNotificationsCount;
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

	private ServiceResult OnWrite_EventNotificationsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.EventNotificationsCount, ref statusCode, ref timestamp);
			m_value.EventNotificationsCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_NotificationsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.NotificationsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.NotificationsCount;
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

	private ServiceResult OnWrite_NotificationsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.NotificationsCount, ref statusCode, ref timestamp);
			m_value.NotificationsCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LatePublishRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.LatePublishRequestCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LatePublishRequestCount;
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

	private ServiceResult OnWrite_LatePublishRequestCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LatePublishRequestCount, ref statusCode, ref timestamp);
			m_value.LatePublishRequestCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CurrentKeepAliveCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.CurrentKeepAliveCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CurrentKeepAliveCount;
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

	private ServiceResult OnWrite_CurrentKeepAliveCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CurrentKeepAliveCount, ref statusCode, ref timestamp);
			m_value.CurrentKeepAliveCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CurrentLifetimeCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.CurrentLifetimeCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CurrentLifetimeCount;
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

	private ServiceResult OnWrite_CurrentLifetimeCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CurrentLifetimeCount, ref statusCode, ref timestamp);
			m_value.CurrentLifetimeCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_UnacknowledgedMessageCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.UnacknowledgedMessageCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.UnacknowledgedMessageCount;
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

	private ServiceResult OnWrite_UnacknowledgedMessageCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.UnacknowledgedMessageCount, ref statusCode, ref timestamp);
			m_value.UnacknowledgedMessageCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_DiscardedMessageCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.DiscardedMessageCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.DiscardedMessageCount;
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

	private ServiceResult OnWrite_DiscardedMessageCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.DiscardedMessageCount, ref statusCode, ref timestamp);
			m_value.DiscardedMessageCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_MonitoredItemCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.MonitoredItemCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.MonitoredItemCount;
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

	private ServiceResult OnWrite_MonitoredItemCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.MonitoredItemCount, ref statusCode, ref timestamp);
			m_value.MonitoredItemCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_DisabledMonitoredItemCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.DisabledMonitoredItemCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.DisabledMonitoredItemCount;
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

	private ServiceResult OnWrite_DisabledMonitoredItemCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.DisabledMonitoredItemCount, ref statusCode, ref timestamp);
			m_value.DisabledMonitoredItemCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_MonitoringQueueOverflowCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.MonitoringQueueOverflowCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.MonitoringQueueOverflowCount;
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

	private ServiceResult OnWrite_MonitoringQueueOverflowCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.MonitoringQueueOverflowCount, ref statusCode, ref timestamp);
			m_value.MonitoringQueueOverflowCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_NextSequenceNumber(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.NextSequenceNumber;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.NextSequenceNumber;
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

	private ServiceResult OnWrite_NextSequenceNumber(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.NextSequenceNumber, ref statusCode, ref timestamp);
			m_value.NextSequenceNumber = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}
}
