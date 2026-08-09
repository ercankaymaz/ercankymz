using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ServerDiagnosticsSummaryValue : BaseVariableValue
{
	private ServerDiagnosticsSummaryDataType m_value;

	private ServerDiagnosticsSummaryState m_variable;

	public ServerDiagnosticsSummaryState Variable => m_variable;

	public ServerDiagnosticsSummaryDataType Value
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

	public ServerDiagnosticsSummaryValue(ServerDiagnosticsSummaryState variable, ServerDiagnosticsSummaryDataType value, object dataLock)
		: base(dataLock)
	{
		m_value = value;
		if (m_value == null)
		{
			m_value = new ServerDiagnosticsSummaryDataType();
		}
		Initialize(variable);
	}

	private void Initialize(ServerDiagnosticsSummaryState variable)
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
			baseVariableState = m_variable.ServerViewCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ServerViewCount;
				baseVariableState.OnWriteValue = OnWrite_ServerViewCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CurrentSessionCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CurrentSessionCount;
				baseVariableState.OnWriteValue = OnWrite_CurrentSessionCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CumulatedSessionCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CumulatedSessionCount;
				baseVariableState.OnWriteValue = OnWrite_CumulatedSessionCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SecurityRejectedSessionCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SecurityRejectedSessionCount;
				baseVariableState.OnWriteValue = OnWrite_SecurityRejectedSessionCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.RejectedSessionCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_RejectedSessionCount;
				baseVariableState.OnWriteValue = OnWrite_RejectedSessionCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SessionTimeoutCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SessionTimeoutCount;
				baseVariableState.OnWriteValue = OnWrite_SessionTimeoutCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SessionAbortCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SessionAbortCount;
				baseVariableState.OnWriteValue = OnWrite_SessionAbortCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CurrentSubscriptionCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CurrentSubscriptionCount;
				baseVariableState.OnWriteValue = OnWrite_CurrentSubscriptionCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CumulatedSubscriptionCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CumulatedSubscriptionCount;
				baseVariableState.OnWriteValue = OnWrite_CumulatedSubscriptionCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.PublishingIntervalCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_PublishingIntervalCount;
				baseVariableState.OnWriteValue = OnWrite_PublishingIntervalCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SecurityRejectedRequestsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SecurityRejectedRequestsCount;
				baseVariableState.OnWriteValue = OnWrite_SecurityRejectedRequestsCount;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.RejectedRequestsCount;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_RejectedRequestsCount;
				baseVariableState.OnWriteValue = OnWrite_RejectedRequestsCount;
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
			ServerDiagnosticsSummaryDataType newValue = ((!(value is ExtensionObject extensionObject)) ? ((ServerDiagnosticsSummaryDataType)value) : ((ServerDiagnosticsSummaryDataType)extensionObject.Body));
			if (!Utils.IsEqual(m_value, newValue))
			{
				UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
				base.Timestamp = timestamp;
				m_value = (ServerDiagnosticsSummaryDataType)Write(newValue);
				m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
			}
		}
		return ServiceResult.Good;
	}

	private void UpdateChildrenChangeMasks(ISystemContext context, ref ServerDiagnosticsSummaryDataType newValue, ref StatusCode statusCode, ref DateTime timestamp)
	{
		if (!Utils.IsEqual(m_value.ServerViewCount, newValue.ServerViewCount))
		{
			UpdateChildVariableStatus(m_variable.ServerViewCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CurrentSessionCount, newValue.CurrentSessionCount))
		{
			UpdateChildVariableStatus(m_variable.CurrentSessionCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CumulatedSessionCount, newValue.CumulatedSessionCount))
		{
			UpdateChildVariableStatus(m_variable.CumulatedSessionCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SecurityRejectedSessionCount, newValue.SecurityRejectedSessionCount))
		{
			UpdateChildVariableStatus(m_variable.SecurityRejectedSessionCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.RejectedSessionCount, newValue.RejectedSessionCount))
		{
			UpdateChildVariableStatus(m_variable.RejectedSessionCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SessionTimeoutCount, newValue.SessionTimeoutCount))
		{
			UpdateChildVariableStatus(m_variable.SessionTimeoutCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SessionAbortCount, newValue.SessionAbortCount))
		{
			UpdateChildVariableStatus(m_variable.SessionAbortCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CurrentSubscriptionCount, newValue.CurrentSubscriptionCount))
		{
			UpdateChildVariableStatus(m_variable.CurrentSubscriptionCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CumulatedSubscriptionCount, newValue.CumulatedSubscriptionCount))
		{
			UpdateChildVariableStatus(m_variable.CumulatedSubscriptionCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.PublishingIntervalCount, newValue.PublishingIntervalCount))
		{
			UpdateChildVariableStatus(m_variable.PublishingIntervalCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SecurityRejectedRequestsCount, newValue.SecurityRejectedRequestsCount))
		{
			UpdateChildVariableStatus(m_variable.SecurityRejectedRequestsCount, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.RejectedRequestsCount, newValue.RejectedRequestsCount))
		{
			UpdateChildVariableStatus(m_variable.RejectedRequestsCount, ref statusCode, ref timestamp);
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

	private ServiceResult OnRead_ServerViewCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.ServerViewCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ServerViewCount;
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

	private ServiceResult OnWrite_ServerViewCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ServerViewCount, ref statusCode, ref timestamp);
			m_value.ServerViewCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CurrentSessionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.CurrentSessionCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CurrentSessionCount;
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

	private ServiceResult OnWrite_CurrentSessionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CurrentSessionCount, ref statusCode, ref timestamp);
			m_value.CurrentSessionCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CumulatedSessionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.CumulatedSessionCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CumulatedSessionCount;
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

	private ServiceResult OnWrite_CumulatedSessionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CumulatedSessionCount, ref statusCode, ref timestamp);
			m_value.CumulatedSessionCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SecurityRejectedSessionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.SecurityRejectedSessionCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SecurityRejectedSessionCount;
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

	private ServiceResult OnWrite_SecurityRejectedSessionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SecurityRejectedSessionCount, ref statusCode, ref timestamp);
			m_value.SecurityRejectedSessionCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_RejectedSessionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.RejectedSessionCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.RejectedSessionCount;
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

	private ServiceResult OnWrite_RejectedSessionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.RejectedSessionCount, ref statusCode, ref timestamp);
			m_value.RejectedSessionCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SessionTimeoutCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.SessionTimeoutCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SessionTimeoutCount;
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

	private ServiceResult OnWrite_SessionTimeoutCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SessionTimeoutCount, ref statusCode, ref timestamp);
			m_value.SessionTimeoutCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SessionAbortCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.SessionAbortCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SessionAbortCount;
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

	private ServiceResult OnWrite_SessionAbortCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SessionAbortCount, ref statusCode, ref timestamp);
			m_value.SessionAbortCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CurrentSubscriptionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.CurrentSubscriptionCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CurrentSubscriptionCount;
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

	private ServiceResult OnWrite_CurrentSubscriptionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CurrentSubscriptionCount, ref statusCode, ref timestamp);
			m_value.CurrentSubscriptionCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CumulatedSubscriptionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.CumulatedSubscriptionCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CumulatedSubscriptionCount;
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

	private ServiceResult OnWrite_CumulatedSubscriptionCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CumulatedSubscriptionCount, ref statusCode, ref timestamp);
			m_value.CumulatedSubscriptionCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_PublishingIntervalCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.PublishingIntervalCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.PublishingIntervalCount;
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

	private ServiceResult OnWrite_PublishingIntervalCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.PublishingIntervalCount, ref statusCode, ref timestamp);
			m_value.PublishingIntervalCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SecurityRejectedRequestsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.SecurityRejectedRequestsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SecurityRejectedRequestsCount;
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

	private ServiceResult OnWrite_SecurityRejectedRequestsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SecurityRejectedRequestsCount, ref statusCode, ref timestamp);
			m_value.SecurityRejectedRequestsCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_RejectedRequestsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.RejectedRequestsCount;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.RejectedRequestsCount;
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

	private ServiceResult OnWrite_RejectedRequestsCount(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.RejectedRequestsCount, ref statusCode, ref timestamp);
			m_value.RejectedRequestsCount = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}
}
